using MehsCoreCommon.Dtos.Users;
using MehsCoreCommon.Exceptions.Security;
using System.Security.Cryptography;
using System.Text;

namespace MehsCoreCommon.Security.Core
{
    public static class AGenerateToken
    {
        private static string GetHashPassword(string password, string salt, string algoritmo)
        {
            string hashKey = string.Join(":", password, salt);
            using (HMAC hmac = HMAC.Create(algoritmo))
            {
                hmac.Key = Encoding.UTF8.GetBytes(salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hashKey));
                hashKey = ProcessHexaDecimal.ByteArrayToHex(hmac.Hash);
            }
            return hashKey;
        }

        private static string CreateToken(string userId, string profileId, long ticks, string algoritmo, string salt, string userPassword)
        {
            string token = string.Empty, mainHash = string.Empty;
            mainHash = string.Join(":", userId, profileId, ticks);
            try
            {
                using (HMAC hmac = HMAC.Create(algoritmo))
                {
                    hmac.Key = Encoding.UTF8.GetBytes(GetHashPassword(userPassword, salt, algoritmo));
                    hmac.ComputeHash(Encoding.UTF8.GetBytes(mainHash));
                    token = ProcessHexaDecimal.ByteArrayToHex(hmac.Hash);
                }
            }
            catch (GenerateTokenException e)
            {
                throw e;
            }
            return token;
        }

        public static string Generate(DtoUser user, string profileId, string ip, string userAgent, long ticks, string algoritmo, string salt)
        {
            return CreateToken(user.Id.ToString()
                               , profileId
                               , ticks
                               , algoritmo
                               , salt
                               , user.Password);
        }
    }
}
