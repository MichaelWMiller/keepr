﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;


namespace keepr
{
    public class Startup
    {
        private readonly string _connectionString; 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           _connectionString = configuration.GetSection("DB").GetValue<string>("MySQLConnectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddAuthentication(CookieAuthenticationDefaults
           .AuthenticationScheme).AddCookie(o => {
               o.LoginPath = "/account/login";
               o.Events.OnRedirectToLogin = (context) =>
               {
                   context.Response.StatusCode = 401;
                   return Task.CompletedTask;
               };
           });
           services.AddCors(o => {
               o.AddPolicy("CORS_ENV_DEV", builder =>{
                   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
               });
           });
           
            services.AddMvc();
            services.AddTransient<IDbConnection>(x => CreateDBContext());
            services.AddTransient<UserRepository>();
            services.AddTransient<VaultRepository>();
            services.AddTransient<KeepRepository>();
        }
        private IDbConnection CreateDBContext () {
            var connection = new MySqlConnection(_connectionString); 
            connection.Open ();
            return connection;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CORS_ENV_DEV");
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            
        }
    }
}
