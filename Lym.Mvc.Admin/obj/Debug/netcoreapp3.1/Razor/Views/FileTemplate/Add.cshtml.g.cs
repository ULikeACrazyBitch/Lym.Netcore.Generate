#pragma checksum "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4bd544453bb098a94f96b811b8c3c4bb529e9655"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FileTemplate_Add), @"mvc.1.0.view", @"/Views/FileTemplate/Add.cshtml")]
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
#line 1 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
using Lym.Models.Entity.Codegenerate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
using Lym.Model.Entity.CodeGenerate;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bd544453bb098a94f96b811b8c3c4bb529e9655", @"/Views/FileTemplate/Add.cshtml")]
    public class Views_FileTemplate_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
  
    ViewData["Title"] = "添加项目模版";
    Layout = "~/Views/_main.cshtml";
    var fileProjects = ViewBag.fileProjects as List<FileProject>;
    var fileProjecttypes = ViewBag.fileProjecttypes as List<FileProjecttype>;
    var fileFiletypes = ViewBag.fileFiletypes as List<FileFiletype>;
    var fileTemplates = ViewBag.fileTemplates as List<FileTemplate>;
    var generateTypes = ViewBag.generateTypes as List<GenerateType>;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""layui-fluid"">
    <form class=""layui-form"">
        <div class=""layui-card"">
            <div class=""layui-card-header"">
                添加项目模版
            </div>
            <div class=""layui-card-body layui-text"">
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">项目名称</label>
                    <div class=""layui-input-block"">
                        <select name=""ProjectId"" id=""ProjectId"" lay-filter=""ProjectId"">
");
#nullable restore
#line 25 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                              
                                foreach (var item in fileProjects)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 1185, "\"", 1201, 1);
#nullable restore
#line 28 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
WriteAttributeValue("", 1193, item.Id, 1193, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 28 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                                        Write(item.ProjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 29 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">项目类型</label>
                    <div class=""layui-input-block"">
                        <select name=""ProjectTypeId"" id=""ProjectTypeId"" lay-filter=""ProjectTypeId"">
");
#nullable restore
#line 38 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                              
                                foreach (var item in fileProjecttypes)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 1833, "\"", 1849, 1);
#nullable restore
#line 41 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
WriteAttributeValue("", 1841, item.Id, 1841, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 41 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                                        Write(item.ProjectTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 42 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">文件类型</label>
                    <div class=""layui-input-block"">
                        <select name=""FileTypeId"" id=""FileTypeId"">
");
#nullable restore
#line 51 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                              
                                foreach (var item in fileFiletypes)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 2449, "\"", 2465, 1);
#nullable restore
#line 54 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
WriteAttributeValue("", 2457, item.Id, 2457, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 54 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                                        Write(item.FileTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 55 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">上一级目录</label>
                    <div class=""layui-input-block"">
                        <select name=""UpperlevelDirectoryId"" id=""UpperlevelDirectoryId"" lay-filter=""UpperlevelDirectoryId"">
");
            WriteLiteral("                                <option value=\"0\" selected=\"selected\">无</option>\r\n");
#nullable restore
#line 66 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                foreach (var item in fileTemplates)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 3202, "\"", 3218, 1);
#nullable restore
#line 68 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
WriteAttributeValue("", 3210, item.Id, 3210, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 68 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                                        Write(item.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 69 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label""> 文件名称 </label>
                    <div class=""layui-input-block"">
                        <input type=""text"" name=""FileName"" id=""FileName""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 3638, "\"", 3706, 3);
            WriteAttributeValue("", 3652, "可使用参数：", 3652, 6, true);
            WriteLiteral("@");
            WriteAttributeValue("", 3660, "(Model.ProjectName)、", 3660, 20, true);
            WriteLiteral("@");
            WriteAttributeValue("", 3682, "(Model.TableName)与循环生成混用", 3682, 24, true);
            EndWriteAttribute();
            WriteLiteral(@" required lay-verify=""required"" autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label"">生成循环类型选择</label>
                    <div class=""layui-input-block"">
                        <select name=""GenerateTypeId"" id=""GenerateTypeId"">
");
            WriteLiteral("                                <option value=\"0\" selected=\"selected\">无</option>\r\n");
#nullable restore
#line 86 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                foreach (var item in generateTypes)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <option");
            BeginWriteAttribute("value", " value=\"", 4339, "\"", 4355, 1);
#nullable restore
#line 88 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
WriteAttributeValue("", 4347, item.Id, 4347, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 88 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                                        Write(item.GenerateTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 89 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label""> 文件内容 </label>
                    <div class=""layui-input-block"">
                        <textarea name=""Content"" id=""Content"" style=""height:600px;"" placeholder=""请输入内容"" class=""layui-textarea""></textarea>
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <label class=""layui-form-label""> 文件内容可用参数 </label>
                    <div class=""layui-input-block"">
                        <pre class=""layui-code"">
{
""ProjectName"":""Lym"",                                //项目名称
""ProjectType"":""Respository.Interface"",              //项目类型
""DatabaseName"": ""sdt_queuesystem"",                  //数据库名称
""DatabaseFileName"": ""SdtQueuesystem"",               //数据库名称（驼峰命名）
""TableName"":""test2table"",                           //数据库表名称
""ClassName"":""Test2table"",                 ");
            WriteLiteral(@"          //class类名称（驼峰命名）
""NameSpace"":""Lym.Respository.Interface.Test2"",     //命名空间
""Description"":null,                                 //表备注
""PropertyGenList"":
    [{
        ""IsPrimaryKey"":false,               //是否主键
        ""Description"":"""",                   //数据字段备注
        ""DbColumnName"":""name"",              //数据库字段名称
        ""Type"":""string"",                    //class类 属性类型
        ""IsIdentity"":false,                 //是否自增
        ""Required"":false,                   //是否可以为空
        ""CodeTableId"":null,                 //暂无
        ""ClassProperName"":""Name""            //class类 属性名称
    }]
}
      </pre>
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
#line 142 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
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

            form.on('select(ProjectId)', function (data) {
                var val = data.value;
                $.post('");
#nullable restore
#line 153 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                   Write(Url.Action("GetProjectTypeSelect", "FileTemplate"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { projectid: val}, function (result) {
                    if (result.code == 0) {
                        //执行清空
                        $(""#ProjectTypeId"").empty();
                        $.each(result.data, function (index, item) {
                            $('#ProjectTypeId').append(new Option(item.projectTypeName, item.id));
                        });
                        layui.form.render(""select"");
                        getDirectory();
                    }
                    else {
                        layer.msg('操作失败', { icon: 2 });
                    }

                });

            })
                form.on('select(ProjectTypeId)', function (data) {
                    getDirectory();

                });
                function getDirectory() {
                    var projectid = $(""#ProjectId"").val();
                    var projectTypeid = $(""#ProjectTypeId"").val();
                    $.post('");
#nullable restore
#line 177 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                       Write(Url.Action("GetUpperlevelDirectory", "FileTemplate"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { projectId: projectid, projectTypeid: projectTypeid}, function (result) {
                    if (result.code == 0) {
                        //执行清空
                        $(""#UpperlevelDirectoryId"").empty();

                        $('#UpperlevelDirectoryId').append(new Option(""无"", 0)); 
                        $.each(result.data, function (index, item) {
                            $('#UpperlevelDirectoryId').append(new Option(item.fileName+""(""+item.fileType+"")"", item.id));
                        });
                        layui.form.render(""select"");
                    }
                    else {
                        layer.msg('操作失败', { icon: 2 });
                    }

                });
            }
                getDirectory();
            //提交保存
            form.on('submit(go)', function (data) {

                $.post('");
#nullable restore
#line 198 "D:\mycode\NetCore代码生成器\lym-netcore-web-api-template\Lym.Mvc.Admin\Views\FileTemplate\Add.cshtml"
                   Write(Url.Action("Save", "FileTemplate"));

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