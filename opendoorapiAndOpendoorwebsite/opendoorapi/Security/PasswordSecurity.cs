using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace OpenDoorAPI
{

    public static class PasswordSecurity
    {
        const string EncryptionKey = "OpenDoorRuppin2017";
        public static string Encrypt(string strText)
        {
            //return strText;
            string EncryptText;
            //string EncryptionKey = "CustomerRetentionSystem_NashefSystems";
            byte[] clearBytes = Encoding.Unicode.GetBytes(strText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    EncryptText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return EncryptText;
        }

        public static string randPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }


        public static string Decrypt(string EncryptText)
        {
            // return EncryptText;
            string strText;
            //string EncryptionKey = "CustomerRetentionSystem_NashefSystems";
            byte[] cipherBytes = Convert.FromBase64String(EncryptText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    strText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return strText;
        }
		public static string SetTokenData(TokenData Data)
		{
			JavaScriptSerializer seralizer = new JavaScriptSerializer();			
			return Encrypt(seralizer.Serialize(Data));
		}

		public static TokenData GetTokenData(string Token)
		{
			JavaScriptSerializer seralizer = new JavaScriptSerializer();
			return seralizer.Deserialize<TokenData>(Decrypt(Token));
		}
	}

	
	

}