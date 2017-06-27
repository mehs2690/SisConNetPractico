using log4net;
using MehsCoreCommon.Exceptions.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MehsCoreCommon.Security.Core
{
    public static class ProcessDES
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProcessDES));
        private static List<ValidateStrings> toValidate;

        private static void ValidateStrings(params ValidateStrings[] toValidate)
        {
            foreach (var s in toValidate)
            {
                if (string.IsNullOrEmpty(s.valueToValdiate))
                {
                    throw new ArgumentNullException(s.nameToValidate, string.Format("El valor de {0}, no puede ser nulo o vacío", s.nameToValidate));
                }
            }
        }

        public static string GenerateWithDES(string toProcess, string password)
        {
            string resultado = string.Empty;
            try
            {
                toValidate = new List<ValidateStrings>() { new ValidateStrings() { nameToValidate = "toProcess", valueToValdiate = toProcess }, new ValidateStrings() { nameToValidate = "password", valueToValdiate = password } };
                ValidateStrings(toValidate.ToArray());
                byte[] bytes = Encoding.ASCII.GetBytes(password);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                                                  des.CreateEncryptor(bytes, bytes),
                                                  CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);
                sw.Write(toProcess);
                sw.Flush();
                cs.FlushFinalBlock();
                sw.Flush();
                resultado = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            catch (Exception e)
            {
                throw new ProcessDESException("Error al procesar la cadena para cifrado DES", e, log);
            }
            return resultado;
        }

        public static string InverseWithDES(string toInverse, string password)
        {
            string resultado = string.Empty;
            try
            {
                toValidate = new List<ValidateStrings>() { new ValidateStrings() { nameToValidate = "toInverse", valueToValdiate = toInverse }, new ValidateStrings() { nameToValidate = "password", valueToValdiate = password } };
                ValidateStrings(toValidate.ToArray());
                byte[] bytes = Encoding.ASCII.GetBytes(password);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(toInverse));
                CryptoStream cs = new CryptoStream(ms,
                                                  des.CreateDecryptor(bytes, bytes),
                                                  CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                resultado = sr.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new ProcessDESException("Error al realizar la inversa DES", e, log);
            }
            return resultado;
        }
    }

    class ValidateStrings
    {
        public string nameToValidate { get; set; }

        public string valueToValdiate { get; set; }
    }
}