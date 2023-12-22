using System.Security.Cryptography;
using System.Text;

namespace IoTPlatform.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string str) { 
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// Convert string to stream
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this string str)
        {
            return new MemoryStream(str.ToByteArray());
        }

        /// <summary>
        /// Get string hash
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
        /// Get string hash as string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetHashString(this string str)
        {
            return BitConverter.ToString(str.GetHash());
        }

        /// <summary>
        /// Get string hash code as integer
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetHashCode(this string str)
        {
            return BitConverter.ToInt32(str.GetHash(), 0);
        }
    }
}
