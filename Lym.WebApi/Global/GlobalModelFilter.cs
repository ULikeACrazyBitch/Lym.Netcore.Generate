using Lym.Model.ApiResult;
using Lym.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.WebApi.Global
{
    public class GlobalModelFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            #region 模型验证
            if (context.ModelState.IsValid) return;

            ApiResult response = new ApiResult();
            response.head.resultcode = (int)StatusCodeEnum.ParameterError;

            foreach (var item in context.ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    if (!string.IsNullOrEmpty(response.head.errmsg))
                    {
                        response.head.errmsg += " | ";
                    }

                    response.head.errmsg += error.ErrorMessage;
                }
            }

            context.Result = new JsonResult(response);
            #endregion
        }
    }
}
