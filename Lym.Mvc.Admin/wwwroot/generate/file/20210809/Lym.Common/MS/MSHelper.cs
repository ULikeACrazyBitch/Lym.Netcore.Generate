using System;

namespace Lym.Common.MS
{
    //外部调用加解密类
    public class MSHelper
    {
        /// <summary>获取秘钥
        /// 获取秘钥
        /// </summary>
        /// <param name="AppID">App账号</param>
        /// <param name="Timestamp">时间戳</param>
        /// <returns></returns>
        public static string GetKey(string AppID, string Timestamp)
        {
            string strKey = SM3Digest.GetSm3Str(AppID + Timestamp);
            return strKey;
        }

        /// <summary>加密
        /// 加密
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <param name="appSecret">秘钥</param>
        /// <returns></returns>
        public static string GetDigest(string str, string appSecret)
        {
            try
            {  //biz_contentSM4_ECB模式加密
                var new_Biz_content = SM4Utils.GetSm4Str(str, appSecret);
                return new_Biz_content;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>解密
        /// 解密
        /// </summary>
        /// <param name="str">解密字符串</param>
        /// <param name="appSecret">解密秘钥</param>
        /// <returns></returns>
        public static string Decrpt(string str, string appSecret)
        {
            try
            {
                //SM4解密
                var result = SM4Utils.GetSm4Decrpt(str, appSecret);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>加密
        /// 加密
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <param name="AppID">AppID</param>
        /// <param name="Timestamp">时间戳</param>
        /// <returns></returns>
        public static string GetDigest(string str, string AppID, string Timestamp)
        {
            try
            {
                //获取秘钥
                string Key = GetKey(AppID, Timestamp);
                //biz_contentSM4_ECB模式加密
                var new_Biz_content = SM4Utils.GetSm4Str(str, Key);
                return new_Biz_content;
            }
            catch (Exception ex)
            {
                throw new Exception("加密异常：" + ex.Message);
            }
        }

        /// <summary>解密
        /// 解密
        /// </summary>
        /// <param name="str">解密字符串</param>
        /// <param name="AppID">AppID</param>
        /// <param name="Timestamp">时间戳</param>
        /// <returns></returns>
        public static string Decrpt(string str, string AppID, string Timestamp)
        {
            try
            {
                //获取秘钥
                string Key = GetKey(AppID, Timestamp);
                string strDecrpt = Decrpt(str, Key);
                return strDecrpt;
            }
            catch (Exception ex)
            {
                throw new Exception("解密异常：" + ex.Message);
            }
        }
    }
}