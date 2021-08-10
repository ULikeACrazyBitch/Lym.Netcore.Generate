using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Text;

namespace Lym.Common.MS
{
    public class SM4Utils
    {
        public String secretKey = "";
        public String iv = "";
        public bool hexString = false;

        public String Encrypt_ECB(String plainText)
        {
            SM4_Context ctx = new SM4_Context();
            ctx.isPadding = true;
            ctx.mode = SM4.SM4_ENCRYPT;

            byte[] keyBytes;
            if (hexString)
            {
                keyBytes = Hex.Decode(secretKey);
            }
            else
            {
                keyBytes = Encoding.UTF8.GetBytes(secretKey);
            }

            SM4 sm4 = new SM4();
            sm4.sm4_setkey_enc(ctx, keyBytes);
            byte[] encrypted = sm4.sm4_crypt_ecb(ctx, Encoding.UTF8.GetBytes(plainText));

            String cipherText = Encoding.UTF8.GetString(Hex.Encode(encrypted));
            return cipherText;
        }

        public String Decrypt_ECB(String cipherText)
        {
            SM4_Context ctx = new SM4_Context();
            ctx.isPadding = true;
            ctx.mode = SM4.SM4_DECRYPT;

            byte[] keyBytes;
            if (hexString)
            {
                keyBytes = Hex.Decode(secretKey);
            }
            else
            {
                keyBytes = Encoding.UTF8.GetBytes(secretKey);
            }

            SM4 sm4 = new SM4();
            sm4.sm4_setkey_dec(ctx, keyBytes);
            byte[] decrypted = sm4.sm4_crypt_ecb(ctx, Hex.Decode(cipherText));
            return Encoding.UTF8.GetString(decrypted);
        }

        public String Encrypt_CBC(String plainText)
        {
            SM4_Context ctx = new SM4_Context();
            ctx.isPadding = true;
            ctx.mode = SM4.SM4_ENCRYPT;

            byte[] keyBytes;
            byte[] ivBytes;
            if (hexString)
            {
                keyBytes = Hex.Decode(secretKey);
                ivBytes = Hex.Decode(iv);
            }
            else
            {
                keyBytes = Encoding.Default.GetBytes(secretKey);
                ivBytes = Encoding.Default.GetBytes(iv);
            }

            SM4 sm4 = new SM4();
            sm4.sm4_setkey_enc(ctx, keyBytes);
            byte[] encrypted = sm4.sm4_crypt_cbc(ctx, ivBytes, Encoding.Default.GetBytes(plainText));

            String cipherText = Encoding.Default.GetString(Hex.Encode(encrypted));
            return cipherText;
        }

        public String Decrypt_CBC(String cipherText)
        {
            SM4_Context ctx = new SM4_Context();
            ctx.isPadding = true;
            ctx.mode = SM4.SM4_DECRYPT;

            byte[] keyBytes;
            byte[] ivBytes;
            if (hexString)
            {
                keyBytes = Hex.Decode(secretKey);
                ivBytes = Hex.Decode(iv);
            }
            else
            {
                keyBytes = Encoding.Default.GetBytes(secretKey);
                ivBytes = Encoding.Default.GetBytes(iv);
            }

            SM4 sm4 = new SM4();
            sm4.sm4_setkey_dec(ctx, keyBytes);
            byte[] decrypted = sm4.sm4_crypt_cbc(ctx, ivBytes, Hex.Decode(cipherText));
            return Encoding.Default.GetString(decrypted);
        }

        public static string GetSm4Str(string input, string appSecret)
        {
            var password = StringToHexString(appSecret).Substring(0, 32);
            SM4Utils sm4 = new SM4Utils();
            sm4.secretKey = password;
            sm4.hexString = true;
            string cipherText = sm4.Encrypt_ECB(input);
            return cipherText.ToUpper();
        }

        public static string GetSm4Decrpt(string input, string appSecret)
        {
            var password = StringToHexString(appSecret).Substring(0, 32);
            SM4Utils sm4 = new SM4Utils();
            sm4.secretKey = password;
            sm4.hexString = true;

            string cipherText = sm4.Decrypt_ECB(input);
            return cipherText;
        }

        public static string StringToHexString(string s)
        {
            Encoding encode = Encoding.UTF8;
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)
            {
                result += Convert.ToString(b[i], 16);//逐字节变为16进制字符
                //result += "%" + Convert.ToString(b[i], 16);//逐字节变为16进制字符，以%隔开
            }
            return result;
        }
    }

    public class HealthCardParams
    {
        public string message { get; set; }
        public string timestamp { get; set; }
        public string biz_content { get; set; }
        public string term_id { get; set; }
        public string method { get; set; }
        public string app_id { get; set; }
        public string digest { get; set; }
        public string code { get; set; }
        public string digest_type { get; set; }
        public string version { get; set; }
        public string enc_type { get; set; }
    }
}