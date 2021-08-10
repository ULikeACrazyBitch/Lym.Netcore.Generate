using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Model.ApiResult
{
    /// <summary>
    /// 接口同意返回
    /// </summary>
    public class ApiResult
    {
        public ApiResult()
        {
            head = new Head();
        }
        /// <summary>
        /// 
        /// </summary>
        public Head head { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object data { get; set; }
    }

    public class Head
    {
        /// <summary>
        /// 
        /// </summary>
        public int resultcode { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string errmsg { get; set; }

        public string Timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
    }

    public class ApiResult<T> : ApiResult
    {
        /// <summary>
        /// 接口返回值
        /// </summary>
        public T Data { get; set; }

    }
}
