using Lym.Common.Helpers;
using Lym.Common.MS;
using Lym.Model.ApiResult;
using Lym.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        #region 统一返回封装

        /// <summary>
        /// 返回封装
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static JsonResult toResponse(StatusCodeEnum statusCode)
        {
            ApiResult response = new ApiResult();
            response.head.resultcode = (int)statusCode;
            response.head.errmsg = statusCode.GetEnumText();

            return new JsonResult(response);
        }

        /// <summary>
        /// 返回封装
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="retMessage"></param>
        /// <returns></returns>
        public static JsonResult toResponse(StatusCodeEnum statusCode, string retMessage)
        {
            ApiResult response = new ApiResult();
            response.head.resultcode = (int)statusCode;
            response.head.errmsg = retMessage;

            return new JsonResult(response);
        }

        /// <summary>
        /// 返回封装
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JsonResult toResponse<T>(T data)
        {
            ApiResult response = new ApiResult();
            response.head.resultcode = (int)StatusCodeEnum.Success;
            response.head.errmsg = StatusCodeEnum.Success.GetEnumText();
            string dataStr = "";
            //加密
            if (AppSettings.Configuration["AppSettings:isSecret"].ToLower() == "true")
            {
                dataStr = MSHelper.GetDigest(JsonConvert.SerializeObject(data), AppSettings.Configuration["AppSettings:AppID"]);
            }
            else
            {
                dataStr = JsonConvert.SerializeObject(data);
            }

            response.data = dataStr;
            return new JsonResult(response);
        }

        #endregion

        #region 常用方法函数
        public static string GetGUID
        {
            get
            {
                return Guid.NewGuid().ToString().ToUpper();
            }
        }

        #endregion
    }
}
