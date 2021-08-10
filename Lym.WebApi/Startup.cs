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
            #region ��������
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

            #region ˵���ĵ�
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
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Lym.WebApi.xml");//������Ǹո����õ�xml�ļ���
                c.IncludeXmlComments(xmlPath, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�
            }); 
            #endregion

            #region ����Json��ʽ
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                // ����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // ��ʹ���շ�
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                // ����ʱ���ʽ
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                // ���ֶ�Ϊnullֵ�����ֶβ��᷵�ص�ǰ��
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            #endregion

            #region
            //����ʹ���첽��ȡBody
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            #endregion

            #region ��ȡ�ͻ��� IP
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
            #endregion

            //ע�뻺��
            services.AddMemoryCache();

            //ע�� HTTPCONTEXT
            services.AddHttpContextAccessor();
            //ע��ʵ��ӳ�����
            services.AddScoped<IMapper, ServiceMapper>();
            //ע��ȫ���쳣����
            services.AddControllers(options =>
            {
                //ȫ��ģ�͹�����
                options.Filters.Add<GlobalModelFilter>();
                //ȫ�ִ�����־������
                options.Filters.Add<GlobalExceptionsFleter>();

            })
            .ConfigureApiBehaviorOptions(options =>
            {
                //����ϵͳ�Դ�ģ����֤
                options.SuppressModelStateInvalidFilter = true;
            });

            //ע��REDIS ����
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

            #region ��������
            app.UseCors("Requests");
            #endregion

            #region ˵���ĵ�
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

            // ������־���
            app.UseMiddleware<Middleware.RequestLogMiddleware>();
            // ���������֤
            app.UseMiddleware<Middleware.ValidationMiddleware>();
            // ʹ�þ�̬�ļ�
            app.UseForwardedHeaders();
            // ʹ�þ�̬�ļ�
            app.UseStaticFiles();
            // ʹ��cookie
            app.UseCookiePolicy();
            // ʹ��Routing
            app.UseRouting();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger("{documentName}/api-docs");
            });
        }

        #region �Զ�ע�����
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblysServices = Assembly.Load("Lym.Respository.Service");
            var assemblysBusiness = Assembly.Load("Lym.Business");



            builder.RegisterAssemblyTypes(assemblysServices)
                .InstancePerDependency()//˲ʱ����
               .AsImplementedInterfaces()////�Զ�����ʵ�ֵ����нӿ����ͱ�¶������IDisposable�ӿڣ�
               .EnableInterfaceInterceptors(); //����Autofac.Extras.DynamicProxy;

            builder.RegisterAssemblyTypes(assemblysBusiness);
        }
        #endregion
    }
}
