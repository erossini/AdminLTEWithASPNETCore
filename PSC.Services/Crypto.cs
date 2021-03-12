using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PSC.Services
{
    /// <summary>
    /// Collection of cryptographic methods
    /// </summary>
    public static class Crypto
    {
        #region Variables
        // private key and initialization vector. use different ones in your own work. 
        private static readonly byte[] key = HexToBytes("A152AA1E5FC0EC53E84F30AAA46139EEBAFF8A9B7463DE5F");
        private static readonly byte[] iv = HexToBytes("3BB17E9111E4F652");

        private static readonly TripleDESCryptoServiceProvider des3;
        #endregion

        /// <summary>
        /// Initializes static members of the <see cref="Crypto"/> class.
        /// </summary>
        static Crypto()
        {
            des3 = new TripleDESCryptoServiceProvider();
            des3.Mode = CipherMode.CBC;
        }

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.String.</returns>
        public static string Encrypt(string data)
        {
            if (data == null) return null;

            byte[] bytes = Encoding.ASCII.GetBytes(data);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                des3.CreateEncryptor(key, iv), CryptoStreamMode.Write);

            encStream.Write(bytes, 0, bytes.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return BytesToHex(stream.ToArray());
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.String.</returns>
        public static string Decrypt(string data)
        {
            if (data == null) return null;

            byte[] bytes = HexToBytes(data);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                des3.CreateDecryptor(key, iv), CryptoStreamMode.Write);

            encStream.Write(bytes, 0, bytes.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.ASCII.GetString(stream.ToArray());
        }

        /// <summary>
        /// Randoms the string (lowercase string)
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string RandomString(int length)
        {
            string c = "abcdefghjklmnopqrstuvwxyz0123456789";
            var random = new Random(Environment.TickCount);
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = c[(int)((c.Length) * random.NextDouble())];
            }

            return new string(chars);
        }

        #region Helpers
        /// <summary>
        /// Hexadecimals to bytes.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                string code = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(code, System.Globalization.NumberStyles.HexNumber);
            }
            return bytes;
        }

        /// <summary>
        /// Byteses to hexadecimal.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string BytesToHex(byte[] bytes)
        {
            var hex = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                hex.AppendFormat("{0:X2}", bytes[i]);

            return hex.ToString();
        }
        #endregion
    }
}
