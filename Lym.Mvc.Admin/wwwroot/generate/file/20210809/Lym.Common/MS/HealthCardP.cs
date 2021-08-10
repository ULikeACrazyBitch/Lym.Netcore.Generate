using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Text;

//using System.Web.Script.Serialization;

namespace Lym.Common.MS
{
    public class HealthCardP
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="data"></param>
        public static void BubbleSort(ref string[] data)
        {
            string temp;
            int FirstAsc = 0;
            int SecondAsc = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = data.Length - 1; j > i; j--)
                {
                    for (int k = 0; k < (data[j].Length > data[j - 1].Length ? data[j - 1].Length : data[j].Length); k++)
                    {
                        FirstAsc = Asc(data[j].Substring(k, 1));
                        SecondAsc = Asc(data[j - 1].Substring(k, 1));
                        if (FirstAsc < SecondAsc)
                        {
                            temp = data[j];
                            data[j] = data[j - 1];
                            data[j - 1] = temp;
                            break;
                        }
                        else if (FirstAsc >= SecondAsc)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("输入的字符串不正确");
            }
        }

        /// <summary>
        /// 按照ASCII码排序
        /// </summary>
        /// <param name="sArray"></param>
        /// <returns></returns>

        public static string GetDigest(string jStr, string app_id_value, string enc_type_value, string methodValue, string digest_type_value, string term_id_value, string timestamValue, string versionValue)
        {
            string strDigest = "";
            string strValue = "";
            string[] arrayDigest = { "app_id", "biz_content", "enc_type", "method", "digest_type", "term_id", "timestamp", "version" };
            BubbleSort(ref arrayDigest);
            for (int i = 0; i < arrayDigest.Length; i++)
            {
                switch (arrayDigest[i])
                {
                    case "app_id":
                        strValue = app_id_value;
                        break;

                    case "biz_content":
                        strValue = jStr;
                        break;

                    case "enc_type":
                        strValue = enc_type_value;
                        break;

                    case "method":
                        strValue = methodValue;
                        break;

                    case "digest_type":
                        strValue = digest_type_value;
                        break;

                    case "term_id":
                        strValue = term_id_value;
                        break;

                    case "timestamp":
                        strValue = timestamValue;
                        break;

                    case "version":
                        strValue = versionValue;
                        break;
                }
                strDigest += (strDigest == "" ? "" : "&") + arrayDigest[i] + "=" + strValue;
            }
            return strDigest;
        }

        /// <summary>
        /// 字典转JSON
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string DictionaryToJson(Dictionary<string, string> dic)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, string> 类型的对象
                return jss.Serialize(dic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// json字符串转对象
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static T FromJSON<T>(string jsonString)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Deserialize<T>(jsonString);
        }
    }
}