using System.Security.Cryptography;
using System.Text;

namespace IoTPlatform.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Конвертация string в byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string str) { 
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// Конвертация string в MemoryStream
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this string str)
        {
            return new MemoryStream(str.ToByteArray());
        }

        /// <summary>
        /// Получить хэш string в виде byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetHash(this string str)
        {
            using(HashAlgorithm algorithm = SHA256.Create())
            {
                return algorithm.ComputeHash(str.ToByteArray());
            }
        }

        /// <summary>
        /// Получить хэш string в виде string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetHashString(this string str)
        {
            return BitConverter.ToString(str.GetHash());
        }

        /// <summary>
        /// Получить хэш string в виде int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetHashCode(this string str)
        {
            return BitConverter.ToInt32(str.GetHash(), 0);
        }
    }
}
