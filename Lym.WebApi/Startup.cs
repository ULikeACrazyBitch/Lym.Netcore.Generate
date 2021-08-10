using Autofac;
using Autofac.Extras.DynamicProxy;
using IGeekFan.AspNetCore.Knife4jUI;
using Lym.Common.Helpers;
using Lym.Core.Redis;
using Lym.WebApi.Global;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Lym.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 跨域设置
            services.AddCors(c =>
            {
                c.AddPolicy("Requests", policy =>
                {
                    policy
                    .WithOrigins(AppSettings.Configuration["Startup:AllowOrigins"].Split('|'))
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            });
            #endregion

            #region 说明文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = AppSettings.Configuration["Startup:ApiName"], Version = "v1" });
                c.AddServer(new OpenApiServer()
                {
                    Url = "",
                    Description = "vvv"
                });
                c.CustomOperationIds(apiDesc =>
                {
                    var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
                    return controllerAction.ControllerName + "-" + controllerAction.ActionName;
                });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Lym.WebApi.xml");//这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
            }); 
            #endregion

            #region 配置Json格式
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                // 忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // 不使用驼峰
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                // 设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                // 如字段为null值，该字段不会返回到前端
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            #endregion

            #region
            //配置使用异步读取Body
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            #endregion

            #region 获取客户端 IP
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
            #endregion

            //注入缓存
            services.AddMemoryCache();

            //注入 HTTPCONTEXT
            services.AddHttpContextAccessor();
            //注入实体映射服务
            services.AddScoped<IMapper, ServiceMapper>();
            //注入全局异常过滤
            services.AddControllers(options =>
            {
                //全局模型过滤器
                options.Filters.Add<GlobalModelFilter>();
                //全局错误日志过滤器
                options.Filters.Add<GlobalExceptionsFleter>();

            })
            .ConfigureApiBehaviorOptions(options =>
            {
                //抑制系统自带模型验证
                options.SuppressModelStateInvalidFilter = true;
            });

            //注册REDIS 服务
            RedisServer.Initalize();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region 跨域设置
            app.UseCors("Requests");
            #endregion

            #region 说明文档
            app.UseSwagger();
            app.UseKnife4UI(c =>
            {
                var ApiName = AppSettings.Configuration["Startup:ApiName"];
                c.RoutePrefix = "swagger"; // serve the UI at root
                c.SwaggerEndpoint("/v1/api-docs", ApiName);
            });
            //app.UseSwaggerUI(c =>
            //{
            //    var ApiName = AppSettings.Configuration["Startup:ApiName"];

            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiName);
            //    //c.RoutePrefix = string.Empty;
            //    c.RoutePrefix = "swagger";
            //});
            #endregion

            // 请求日志监控
            app.UseMiddleware<Middleware.RequestLogMiddleware>();
            // 请求参数验证
            app.UseMiddleware<Middleware.ValidationMiddleware>();
            // 使用静态文件
            app.UseForwardedHeaders();
            // 使用静态文件
            app.UseStaticFiles();
            // 使用cookie
            app.UseCookiePolicy();
            // 使用Routing
            app.UseRouting();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger("{documentName}/api-docs");
            });
        }

        #region 自动注入服务
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblysServices = Assembly.Load("Lym.Respository.Service");
            var assemblysBusiness = Assembly.Load("Lym.Business");



            builder.RegisterAssemblyTypes(assemblysServices)
                .InstancePerDependency()//瞬时单例
               .AsImplementedInterfaces()////自动以其实现的所有接口类型暴露（包括IDisposable接口）
               .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;

            builder.RegisterAssemblyTypes(assemblysBusiness);
        }
        #endregion
    }
}
