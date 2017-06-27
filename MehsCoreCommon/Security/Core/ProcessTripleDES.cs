using log4net;
using MehsCoreCommon.Exceptions.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MehsCoreCommon.Security.Core
{
    public static class ProcessTripleDES
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProcessTripleDES));
        private static List<ValidateStrings> toValidate;
        private static readonly string CVE_SALT = "Fr1dH@c0D3Me><";

        private static void ValidateStrings(params ValidateStrings[] toValidate)
        {
            foreach (var s in toValidate)
            {
                if (string.IsNullOrEmpty(s.valueToValdiate))
                {
                    throw new ArgumentNullException(s.nameToValidate, string.Format("El valor de {0} no puede ser nulo o vacío", s.nameToValidate));
                }
            }
        }

        private static string FirstFormWithTripleDES(string toProcess, string password)
        {
            try
            {
                toValidate = new List<ValidateStrings>() { new ValidateStrings() { nameToValidate = "toProcess", valueToValdiate = toProcess }, new ValidateStrings() { nameToValidate = "password", valueToValdiate = password } };
                ValidateStrings(toValidate.ToArray());
                byte[] bytes = Encoding.ASCII.GetBytes(password);
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                                                   tdes.CreateEncryptor(bytes, bytes),
                                                   CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);
                sw.Write(toProcess);
                sw.Flush();
                cs.FlushFinalBlock();
                sw.Flush();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            catch (Exception e)
            {
                throw new ProcessTripleDESException("Error al procesar la cadena para cifrado TripleDES", e, log);
            }
        }

        private static string SecondFormWithTripleDES(string toProcess, string password)
        {
            try
            {
                byte[] keyArr;
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(toProcess);
                keyArr = Encoding.UTF8.GetBytes(password);
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArr;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tdes.CreateEncryptor();
                byte[] resultadoArray = transform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultadoArray, 0, resultadoArray.Length);
            }
            catch (Exception e)
            {
                throw new ProcessTripleDESException("Error al procesar la cadena para cifrado TripleDES", e, log);
            }
        }

        public static string Encrypt(string data, string key, string iv)
        {
            string complexkey = ProcessHexaDecimal.GenerateHexadecimal(string.Join("::", key, CVE_SALT), true);
            byte[] byteArrayData = Encoding.UTF8.GetBytes(data);
            byte[] byteArrayHexK = ProcessHexaDecimal.HexToByteArray(complexkey);
            byte[] byteArrayHexV = ProcessHexaDecimal.HexToByteArray(iv);

            TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des3.CreateEncryptor(byteArrayHexK, byteArrayHexV), CryptoStreamMode.Write);

            cs.Write(byteArrayData, 0, byteArrayData.Length);
            cs.FlushFinalBlock();
            cs.Close();

            var str = ProcessHexaDecimal.ByteArrayToHex(ms.ToArray());

            return str;
        }

        public static string Decrypt(string data, string key, string iv)
        {
            string complexkey = ProcessHexaDecimal.GenerateHexadecimal(string.Join("::", key, CVE_SALT), true);
            byte[] bdata = ProcessHexaDecimal.HexToByteArray(data);
            byte[] bkey = ProcessHexaDecimal.HexToByteArray(complexkey);
            byte[] biv = ProcessHexaDecimal.HexToByteArray(iv);

            TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static string GenerateWithTripleDES(string toProcess, string password)
        {
            string resultado = string.Empty;
            resultado = SecondFormWithTripleDES(toProcess, password);
            return resultado;
        }

        public static string InverseWithTripleDES(string toInverse, string password)
        {
            string resultado = string.Empty;
            try
            {
                byte[] keyArray;
                byte[] inverseArray = Convert.FromBase64String(toInverse);
                keyArray = Encoding.UTF8.GetBytes(password);
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform transform = tdes.CreateDecryptor();
                byte[] resultadoArray = transform.TransformFinalBlock(inverseArray, 0, inverseArray.Length);
                tdes.Clear();
                resultado = Encoding.UTF8.GetString(resultadoArray);
            }
            catch (Exception e)
            {
                throw new ProcessTripleDESException("Error al procesar la cadena para cifrado TripleDES", e, log);
            }
            return resultado;
        }
    }
}
