using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lym.Common.Helpers
{
    /// <summary>
    /// 驼峰命名
    /// </summary>
    public static class HumpNameHelper
    {
        /// <summary>
        /// 转换驼峰命名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToHumpName(string str)
        {
            //驼峰正则表达式
            Regex reg = new Regex("(\\s|_|-)+");
            //正则表达式转换驼峰命名
            foreach (Match item in reg.Matches(str))
            {
                str = str.Replace(item.Value, "");
                var UpperStr = str[item.Index].ToString().ToUpper();
                str = str.Remove(item.Index, 1);
                str = str.Insert(item.Index, UpperStr); 
            }
            //首字母是不是小写字母
            if (Regex.IsMatch(str[0].ToString(), "[a-z]"))
            {
                var firstStr = str[0].ToString().ToUpper();
                str = str.Remove(0,1);
                str = str.Insert(0, firstStr); 
            }
            return str;
        }
    }
}
