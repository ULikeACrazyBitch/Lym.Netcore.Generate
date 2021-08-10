using Lym.Common.Helpers;
using Lym.Common.MS;
using Lym.Core.Redis;
using Lym.Model.ApiResult;
using Lym.Model.Enum;
using Lym.WebApi.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lym.WebApi.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;


        /// <summary>
        /// 中间件注入
        /// </summary>
        /// <param name="next"></param>
        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 唤起中间件
        /// </summary>
        /// <param name="httpContext">请求报文</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        { 
            try
            {
                //是否加解密
                string isSecret = AppSettings.Configuration["AppSettings:isSecret"];
                //APPID
                string AppID = AppSettings.Configuration["AppSettings:AppID"];

                //请求路径白名单
                string postUrl = httpContext.Request.Path;
                if (postUrl.Contains("QiantoonService", StringComparison.CurrentCultureIgnoreCase) && isSecret.Equals("true"))
                {
                    //获取请求Body
                    var request = httpContext.Request;
                    StreamReader sr = new StreamReader(request.Body);
                    string body = await sr.ReadToEndAsync();
                    //入参数校验
                    if (string.IsNullOrEmpty(body))
                    {
                        await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterCannotEmpty);
                        return;
                    }
                    Dictionary<string, object> paramObj = new Dictionary<string, object>();
                    try
                    {
                        paramObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
                    }
                    catch (Exception)
                    {
                        await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.BodyIsNotJson);
                        return;
                    }
                    //根据加解密配置选择是否进行解密
                    if (isSecret == "true")
                    {
                        if (paramObj == null)
                        {
                            await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterCannotEmpty);
                            return;
                        }
                        if (!paramObj.ContainsKey("head"))
                        {
                            await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterNotHead);
                            return;
                        }
                        if (paramObj != null && paramObj.ContainsKey("head"))
                        {
                            //head参数校验
                            string head = paramObj.GetValueOrDefault("head").ToString();
                            JObject headObj = new JObject();
                            if (string.IsNullOrEmpty(head))
                            {
                                await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterHeadIsEmpty);
                                return;
                            }
                            //把head加入请求头方便日志记录
                            request.Headers.Add("head", head);
                            try
                            {
                                headObj = JObject.Parse(head);
                            }
                            catch (Exception)
                            {
                                await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterHeadIsNotJson);
                                return;
                            }

                            if (headObj.Property("Timestamp", StringComparison.CurrentCultureIgnoreCase) == null)
                            {
                                await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterNotHaveTimestamp);
                                return;
                            }
                            if (headObj.Property("auth_token", StringComparison.CurrentCultureIgnoreCase) == null)
                            {
                                await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterNotHaveAuthToken);
                                return;
                            } 

                            //获取时间戳
                            string timeStamp = Convert.ToString(headObj.GetValue("Timestamp", StringComparison.CurrentCultureIgnoreCase));
                            //获取token
                            string token = Convert.ToString(headObj.GetValue("auth_token", StringComparison.CurrentCultureIgnoreCase));
                            //token验证
                            if (string.IsNullOrEmpty(RedisServer.Cache.Get(token)))
                            {
                                await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.ParameterAuthTokenCheckError);
                                return; 
                            }
                            //获取解密数据
                            if (paramObj.ContainsKey("data") && !string.IsNullOrEmpty(Convert.ToString(paramObj.GetValueOrDefault("data"))))
                            {
                                string strDecrpt = MSHelper.Decrpt(paramObj.GetValueOrDefault("data").ToString(), AppID, timeStamp);
                                //把head加入请求头方便日志记录
                                request.Headers.Add("dataDcp", strDecrpt); 
                                //重新赋值请求参数便于接口接收实体类
                                byte[] array = Encoding.UTF8.GetBytes(strDecrpt);
                                MemoryStream stream = new MemoryStream(array);
                                httpContext.Request.Body = stream;
                            }
                        }
                    }
                }
                await _next(httpContext);
            }
            catch (Exception ex)
            { 
                await httpContext.ToErrorResponseResultAsync(StatusCodeEnum.Error);
            }
        }

    }


}
