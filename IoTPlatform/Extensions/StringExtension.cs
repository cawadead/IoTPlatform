using System.Text;

namespace IoTPlatform.Extensions
{
    public static class StringExtension
    {
        public static byte[] ToByteArray(this string value) { 
            return Encoding.UTF8.GetBytes(value);
        }

        public static MemoryStream ToMemoryStream(this string value)
        {
            return new MemoryStream(value.ToByteArray());
        }
    }
}
