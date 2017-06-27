using log4net;
using MehsCoreCommon.Exceptions.Security;
using MehsCoreCommon.Security.Core;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FcCommonCore.Security.Process
{
    public static class ProcessMd5
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProcessMd5));

        public static string GenerateWithMd5(string stringOriginal, bool upperCase)
        {
            string resultado = string.Empty;
            try
            {
                MD5 md = MD5.Create();
                byte[] getBytesString = Encoding.UTF8.GetBytes(stringOriginal);
                byte[] hash = md.ComputeHash(getBytesString);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    if (upperCase)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    else
                    {
                        sb.Append(hash[i].ToString("x2"));
                    }
                }
                resultado = sb.ToString();
            }
            catch (Exception e)
            {
                throw new ProcessMD5Exception("error al cifrar la cadena", e, log);
            }
            return resultado;
        }

        public static string GenerateWithMd5(string stringOriginal, bool upperCase, bool toHexa)
        {
            string resultado = string.Empty;
            try
            {
                MD5 md = MD5.Create();
                byte[] getBytesString = Encoding.UTF8.GetBytes(stringOriginal);
                byte[] hash = md.ComputeHash(getBytesString);
                if (toHexa)
                {
                    resultado = ProcessHexaDecimal.GenerateHexadecimal(Convert.ToBase64String(hash), upperCase);
                }
                else
                {
                    resultado = Convert.ToBase64String(hash);
                }
            }
            catch (Exception e)
            {
                throw new ProcessMD5Exception("error al cifrar la cadena", e, log);
            }
            return resultado;
        }

        public static bool ValidateWithMd5(string original, string toValidate)
        {
            bool equals = false;
            StringComparer sC = StringComparer.InvariantCultureIgnoreCase;
            equals = sC.Compare(original, toValidate) == 0;
            return equals;
        }
    }
}
