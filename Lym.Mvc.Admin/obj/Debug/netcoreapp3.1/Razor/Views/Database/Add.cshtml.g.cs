#pragma checksum "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "685f325ea909d3ef6c669b1ca28b355db5884836"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Database_Add), @"mvc.1.0.view", @"/Views/Database/Add.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
using Lym.Mvc.Admin.Tools;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"685f325ea909d3ef6c669b1ca28b355db5884836", @"/Views/Database/Add.cshtml")]
    public class Views_Database_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
  
    ViewData["Title"] = "添加数据库";
    Layout = "~/Views/_main.cshtml";
    var SqlSugarDbTypeList = ViewBag.SqlSugarDbTypeList as List<SqlSugarDbType>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""layui-fluid"">
    <form class=""layui-form"">
        <div class=""layui-card"">
            <div class=""layui-card-header"">
                添加数据库
            </div>
            <div class=""layui-card-body layui-text"">
                <div class=""layui-form-item"">
                    <label class=""layui-form-label""> 描述 </label>
                    <div class=""layui-input-block"">
                        <input type=""text"" name=""Desc"" id=""Desc"" placeholder=""Desc"" required lay-verify=""required"" autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">数据库连接</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" name=""Connection"" id=""Connection"" placeholder=""数据库连接"" required lay-verify=""required"" autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
                <div class");
            WriteLiteral(@"=""layui-form-item"">
                    <label class=""layui-form-label"">数据库名称</label>
                    <div class=""layui-input-block"">
                        <input type=""text"" name=""DatabaseName"" id=""DatabaseName"" placeholder=""数据库名称"" required lay-verify=""required"" autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">数据库类型</label>
                    <div class=""layui-input-block"">
                        <select name=""DbType"" id=""DbType"">
");
#nullable restore
#line 37 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
                              

                                foreach (var item in SqlSugarDbTypeList)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 1992, "\"", 2008, 1);
#nullable restore
#line 41 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
WriteAttributeValue("", 2000, item.Id, 2000, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 41 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
                                                        Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 42 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
                                } 
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <div class=""layui-input-block"">
                        <button class=""layui-btn"" type=""button"" lay-submit lay-filter=""go"">立即提交</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</div>

");
            DefineSection("js", async() => {
                WriteLiteral("\r\n    <script>\r\n        layui.config({\r\n            base: \'");
#nullable restore
#line 60 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
              Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' //静态资源所在路径
        }).extend({
            index: 'lib/index' //主入口模块
            }).use(['index', 'form','layer', 'upload'], function () {
            var $ = layui.$
                , upload = layui.upload
                , layer = layui.layer
                , form = layui.form;


            //提交保存
            form.on('submit(go)', function (data) {

                $.post('");
#nullable restore
#line 73 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\Database\Add.cshtml"
                   Write(Url.Action("Save", "Database"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', data.field, function (result) {
                    if (parent.layer.getFrameIndex(window.name)) {
                        var index = parent.layer.getFrameIndex(window.name);//先得到当前iframe层的索引
                        var action = ""记录添加"";
                        $(window.parent.document).find(""#status"").val(result.code);
                        parent.returnBackMsg(index, result, action);
                    } else {
                        if (result.code == 0) {
                            layer.msg('操作成功', {icon:1});
                        }
                        else {
                            layer.msg('操作失败', {icon:2});
                        }
                    }

                });
                return true;
            });

        });
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591