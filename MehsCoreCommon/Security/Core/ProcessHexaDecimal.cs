using log4net;
using MehsCoreCommon.Exceptions.Security;
using System;
using System.Linq;
using System.Text;

namespace MehsCoreCommon.Security.Core
{
    public static class ProcessHexaDecimal
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProcessHexaDecimal));
        private static StringBuilder sb = new StringBuilder();

        public static string GenerateHexadecimal(string toProcess, bool upperCase)
        {
            string resultado = string.Empty;
            try
            {
                sb.Clear();
                char[] caracteres = toProcess.ToCharArray();
                foreach (var c in caracteres)
                {
                    int iNumberValue = Convert.ToInt32(c);
                    if (upperCase)
                    {
                        sb.Append(string.Format("{0:X}", iNumberValue));
                    }
                    else
                    {
                        sb.Append(string.Format("{0:x}", iNumberValue));
                    }
                }
                resultado = sb.ToString();
            }
            catch (Exception e)
            {
                throw new ProcessHexaDecimalException("Ocurrió un error al procesar la cadena en Hexadecimal", e, log);
            }
            return resultado;
        }

        public static string InverseHexadecimal(string toInverse)
        {
            string resultado = string.Empty;
            try
            {
                sb.Clear();
                char[] caracteres = toInverse.ToCharArray();
                for (int i = 0; i < caracteres.Length; i++)
                {
                    int valor = 0;
                    if ((i + 1) < caracteres.Length)
                    {
                        valor = Convert.ToInt32(string.Format("{0}{1}",
                                                       caracteres[i].ToString(),
                                                       caracteres[i + 1].ToString()), 16);
                        sb.Append((char)valor);
                    }
                    i++;
                }
                resultado = sb.ToString();
            }
            catch (Exception e)
            {
                throw new ProcessHexaDecimalException("Ocurrió un error al procesar la cadena en Hexadecimal", e, log);
            }
            return resultado;
        }

        public static byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ByteArrayToHex(byte[] data)
        {
            return string.Concat(data.Select(b => b.ToString("X2")).ToArray());
        }
    }
}
