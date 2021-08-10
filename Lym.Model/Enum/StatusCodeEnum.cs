using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lym.Model.Enum
{
    public enum StatusCodeEnum
    {
        /// <summary>
        /// 请求(或处理)成功
        /// </summary>
        [Text("请求成功")]
        Success = 0,
        /// <summary>
        /// 内部请求出错
        /// </summary>
        [Text("内部请求出错")]
        Error = 500,
        /// <summary>
        /// 访问请求未授权! 当前 SESSION 失效, 请重新登陆
        /// </summary>
        [Text("访问请求未授权! 当前 SESSION 失效, 请重新登陆")]
        Unauthorized = 401,
        /// <summary>
        /// 请求参数不完整或不正确
        /// </summary>
        [Text("请求参数不完整或不正确")]
        ParameterError = 400,
        /// <summary>
        /// 您无权进行此操作，请求执行已拒绝
        /// </summary>
        [Text("您无权进行此操作，请求执行已拒绝")]
        Forbidden = 403,
        /// <summary>
        /// 找不到与请求匹配的 HTTP 资源
        /// </summary>
        [Text("找不到与请求匹配的 HTTP 资源")]
        NotFound = 404,
        /// <summary>
        /// HTTP请求类型不合法
        /// </summary>
        [Text("HTTP请求类型不合法")]
        HttpMehtodError = 405,
        /// <summary>
        /// HTTP请求不合法,请求参数可能被篡改
        /// </summary>
        [Text("HTTP请求不合法,请求参数可能被篡改")]
        HttpRequestError = 406,
        /// <summary>
        /// 该URL已经失效
        /// </summary>
        [Text("该URL已经失效")]
        URLExpireError = 407,
        /// <summary>
        /// 入参不能为空
        /// </summary>
        [Text("入参不能为空")]
        ParameterCannotEmpty = 201,
        /// <summary>
        /// 参数的json数据格式错误
        /// </summary>
        [Text("参数的json数据格式错误")]
        BodyIsNotJson = 202,
        /// <summary>
        /// 未传入Head
        /// </summary>
        [Text("未传入Head")]
        ParameterNotHead = 203,
        /// <summary>
        /// head参数值为空
        /// </summary>
        [Text("head参数值为空")]
        ParameterHeadIsEmpty = 204,
        /// <summary>
        /// 参数head的Json格式错误
        /// </summary>
        [Text("参数head的Json格式错误")]
        ParameterHeadIsNotJson = 205,
        /// <summary>
        /// 参数timestamp不存在
        /// </summary>
        [Text("参数timestamp不存在")]
        ParameterNotHaveTimestamp = 206,
        /// <summary>
        /// 参数auth_token不存在
        /// </summary>
        [Text("参数auth_token不存在")]
        ParameterNotHaveAuthToken = 207,
        /// <summary>
        /// 验证token值失败
        /// </summary>
        [Text("验证token值失败")]
        ParameterAuthTokenCheckError = 208,

    }

    public class TextAttribute : Attribute
    {
        public TextAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }

    /// <summary>
    /// 枚举扩展属性
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获得枚举提示文本
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetEnumText(this StatusCodeEnum obj)
        {
            Type type = obj.GetType();
            FieldInfo field = type.GetField(obj.ToString());
            TextAttribute attribute = (TextAttribute)field.GetCustomAttribute(typeof(TextAttribute));
            return attribute.Value;
        }
    }
}
