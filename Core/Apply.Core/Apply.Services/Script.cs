using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Apply.Services
{
    class Script
    {
        #region MANIPULAÇÃO DE STRINGS
        /// <summary>
        /// Converte uma string em array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static Byte[] ConvertStringToByArray(string s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        /// <summary>
        /// Encripta no formato MD5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            //cria um hash de bytes
            Byte[] toHash = ConvertStringToByArray(s);
            //criptografa o hash em SHA1
            byte[] hashValue = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(toHash);
            return BitConverter.ToString(hashValue);
        }

        /// <summary>
        /// Converte string para Base64
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Base64Encode(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "";

            byte[] buffer = Encoding.UTF8.GetBytes(key);
            return Convert.ToBase64String(buffer);
        }

        /// <summary>
        /// Reverte string de Base64
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Base64Decode(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "";

            byte[] buffer = Convert.FromBase64String(key);
            return Encoding.UTF8.GetString(buffer);
        }
        #endregion

        #region CRIPTOGRAFIA REVERSA
        // Arbitrary key and iv vector. 
        // You will want to generate (and protect) your own when using encryption.
        private const string actionKey = "EA81AA1D5FC1EC53E84F30AA746139EEBAFF8A9B76638895";
        private const string actionIv = "87AF7EA221F3FFF5";

        private TripleDESCryptoServiceProvider des3;

        /// <summary>
        /// Default constructor. Initializes the DES3 encryption provider. 
        /// </summary>
        public Script()
        {
            des3 = new TripleDESCryptoServiceProvider();
            des3.Mode = CipherMode.CBC;
        }

        /// <summary>
        /// Generates a 24 byte Hex key.
        /// </summary>
        /// <returns>Generated Hex key.</returns>
        public string GenerateKey()
        {
            // Length is 24
            des3.GenerateKey();
            return BytesToHex(des3.Key);
        }

        /// <summary>
        /// Generates an 8 byte Hex IV (Initialization Vector).
        /// </summary>
        /// <returns>Initialization vector.</returns>
        public string GenerateIV()
        {
            // Length = 8
            des3.GenerateIV();
            return BytesToHex(des3.IV);
        }

        /// <summary>
        /// Converts a hex string to a byte array.
        /// </summary>
        /// <param name="hex">Hex string.</param>
        /// <returns>Byte array.</returns>
        private byte[] HexToBytes(string hex)
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
        /// Converts a byte array to a hex string.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <returns>Converted hex string</returns>
        private string BytesToHex(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                hex.AppendFormat("{0:X2}", bytes[i]);
            return hex.ToString();
        }

        /// <summary>
        /// Encrypts a memory string (i.e. variable).
        /// </summary>
        /// <param name="data">String to be encrypted.</param>
        /// <param name="key">Encryption key.</param>
        /// <param name="iv">Encryption initialization vector.</param>
        /// <returns>Encrypted string.</returns>
        public string Encrypt(string data, string key, string iv)
        {
            byte[] bdata = Encoding.UTF8.GetBytes(data);
            byte[] bkey = HexToBytes(key);
            byte[] biv = HexToBytes(iv);

            MemoryStream stream = new MemoryStream();
            CryptoStream encStream = new CryptoStream(stream,
                des3.CreateEncryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return BytesToHex(stream.ToArray());
        }

        /// <summary>
        /// Decrypts a memory string (i.e. variable).
        /// </summary>
        /// <param name="data">String to be decrypted.</param>
        /// <param name="key">Original encryption key.</param>
        /// <param name="iv">Original initialization vector.</param>
        /// <returns>Decrypted string.</returns>
        public string Decrypt(string data, string key, string iv)
        {
            byte[] bdata = HexToBytes(data);
            byte[] bkey = HexToBytes(key);
            byte[] biv = HexToBytes(iv);

            MemoryStream stream = new MemoryStream();
            CryptoStream encStream = new CryptoStream(stream,
                des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// Standard encrypt method for Patterns in DoFactory.
        /// Uses the predefined key and iv.
        /// </summary>
        /// <param name="data">String to be encrypted.</param>
        /// <returns>Encrypted string</returns>
        public string ActionEncrypt(string data)
        {
            return Encrypt(data, actionKey, actionIv);
        }

        /// <summary>
        /// Standard decrypt method for Patterns in DoFactory.
        /// Uses the predefined key and iv.
        /// </summary>
        /// <param name="data">String to be decrypted.</param>
        /// <returns>Decrypted string.</returns>
        public string ActionDecrypt(string data)
        {
            return Decrypt(data, actionKey, actionIv);
        }

        #endregion
    }
}