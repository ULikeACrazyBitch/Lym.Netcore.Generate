using Lym.Model.ApiResult;
using Lym.Model.Enum;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lym.WebApi.Extension
{
    public static class HttpContextExtension
    {
        /// <summary>
        /// 同意返回错误信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="code"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static async Task ToErrorResponseResultAsync(this HttpContext httpContext, StatusCodeEnum statusCodeEnum)
        {
            ApiResult response = new ApiResult();
            response.head.errmsg = statusCodeEnum.GetEnumText();
            response.head.resultcode = (int)statusCodeEnum;

            httpContext.Response.ContentType = "application/json;charset=utf-8";
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response), UTF8Encoding.UTF8);
        }
    }
}
