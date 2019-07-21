using System.IO;
using System.Security.Cryptography;
using System.Linq;

namespace CarpoolApi.Api.Hashing
{
    public class HashingService : IHashingService
    {
        private static readonly byte[] SALT = new byte[] { 0x2c, 0xdc, 0xfa, 0x19, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xbf, 0x4d, 0x08, 0x32, 0x3c };

        // Note: There are libraries for generating the key but I'm doing this for simplicity
        private byte[] GetKey(Rfc2898DeriveBytes pdb) => pdb.GetBytes(32);

        private byte[] GetIv(Rfc2898DeriveBytes pdb, string password)
        {
            var source = pdb.GetBytes(32);
            var pwLength = password.Length;

            while (source.Length < (pwLength + 16))
                source = source.Concat(source).ToArray();

            var segment = source.Skip(pwLength).Take(16).ToArray();
            return segment;
        }

        private void SetKeys(string plainText, RijndaelManaged rijAlg)
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(plainText, SALT);
            rijAlg.Key = GetKey(pdb);
            rijAlg.IV = GetIv(pdb, plainText);
        }

        public byte[] Encrypt(string plainText)
        {
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                SetKeys(plainText, rijAlg);

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        public string Decrypt(byte[] cipherText, string plainText)
        {
            string retString; 

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(plainText, SALT);
                rijAlg.Key = GetKey(pdb);
                rijAlg.IV = GetIv(pdb, plainText);

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            retString = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return retString;
        }
    }
}
