using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lym.Common.Tools
{
    public class TemplateHelper
    {
        public const string EntityKey = "Lym.Generate";
        public static string  GetTemplateValue<T>(string key,string template,T model) 
        {
            var result = Engine.Razor.RunCompile(template, key, model.GetType(), model);
            return result;
        }
    }
}
