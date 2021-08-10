using Lym.Common.Helpers;
using Newtonsoft.Json.Linq; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lym.Common.Helpers
{
    /// <summary>
    /// 控制器公有类
    /// </summary>
    public static class PubHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text">要加密的文本</param>
        /// <returns></returns>
        public static string DESMD5Encrypt(string Text)
        {
            //MD5密钥
            string sKey = AppSettings.Configuration["AppSettings:MD5KEY"];
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string DESMD5Decrypt(string Text)
        {
            //MD5密钥
            string sKey = AppSettings.Configuration["AppSettings:MD5KEY"];
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(Md5Hash(sKey).Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string MD5EncryptNEW(string inputValue)
        {
            //32位大写
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(inputValue));
                var strResult = BitConverter.ToString(result);
                string result3 = strResult.Replace("-", "");
                return result3;
            }
        }

        #region 3DES 算法

        /// <summary>3DES加密
        /// 3DES加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DesEncrypt(string input, string key)
        {
            byte[] inputArray = Encoding.UTF8.GetBytes(input);
            var tripleDES = TripleDES.Create();
            var byteKey = Encoding.UTF8.GetBytes(key);
            byte[] allKey = new byte[24];
            Buffer.BlockCopy(byteKey, 0, allKey, 0, 16);
            Buffer.BlockCopy(byteKey, 0, allKey, 16, 8);
            tripleDES.Key = allKey;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>3DES解密
        /// 3DES解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DesDecrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            var tripleDES = TripleDES.Create();
            var byteKey = Encoding.UTF8.GetBytes(key);
            byte[] allKey = new byte[24];
            Buffer.BlockCopy(byteKey, 0, allKey, 0, 16);
            Buffer.BlockCopy(byteKey, 0, allKey, 16, 8);
            tripleDES.Key = allKey;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        #endregion 3DES 算法

        #region SHA-256 算法签名和验签

        private static string Sign(string contentForSign, string priKeyFile, string keyPwd)
        {
            var rsa = GetPrivateKey(priKeyFile, keyPwd);
            // Create a new RSACryptoServiceProvider
            var rsaClear = new RSACryptoServiceProvider();
            // Export RSA parameters from 'rsa' and import them into 'rsaClear'
            var paras = rsa.ExportParameters(true);
            rsaClear.ImportParameters(paras);
            var signData = rsa.SignData(Encoding.UTF8.GetBytes(contentForSign), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return BytesToHex(signData);
        }

        private static bool VerifySign(string contentForSign, string signedData, string pubKeyFile)
        {
            var rsa = GetPublicKey(pubKeyFile);
            return rsa.VerifyData(Encoding.UTF8.GetBytes(contentForSign), HexToBytes(signedData), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        /// <summary>
        /// 获取签名证书私钥
        /// </summary>
        /// <param name="priKeyFile"></param>
        /// <param name="keyPwd"></param>
        /// <returns></returns>
        private static RSACng GetPrivateKey(string priKeyFile, string keyPwd)
        {
            var pc = new X509Certificate2(priKeyFile, keyPwd, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
            return (RSACng)pc.PrivateKey;
        }

        /// <summary>
        /// 获取验签证书
        /// </summary>
        /// <param name="pubKeyFile"></param>
        /// <returns></returns>
        private static RSACng GetPublicKey(string pubKeyFile)
        {
            var pc = new X509Certificate2(pubKeyFile);
            return (RSACng)pc.PublicKey.Key;
        }

        public static byte[] HexToBytes(string text)
        {
            if (text.Length % 2 != 0)
                throw new ArgumentException("text 长度为奇数。");

            List<byte> lstRet = new List<byte>();
            for (int i = 0; i < text.Length; i = i + 2)
            {
                lstRet.Add(Convert.ToByte(text.Substring(i, 2), 16));
            }
            return lstRet.ToArray();
        }

        /// <summary>
        /// bytes转换hex
        /// </summary>
        /// <param name="data">bytes</param>
        /// <returns>转换后的hex字符串</returns>
        public static string BytesToHex(byte[] data)
        {
            StringBuilder sbRet = new StringBuilder(data.Length * 2);
            for (int i = 0; i < data.Length; i++)
            {
                sbRet.Append(Convert.ToString(data[i], 16).PadLeft(2, '0'));
            }
            return sbRet.ToString();
        }

        #endregion SHA-256 算法签名和验签

       
    }
}