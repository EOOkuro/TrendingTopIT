using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Logging; 
using Microsoft.Extensions.Options; 
using Microsoft.IdentityModel.Tokens; 

namespace TrendingTopApi {
    public class Startup {
        public Startup(IConfiguration configuration,IHostingEnvironment env) {
        Configuration = configuration; 
        Environment=env;
    }
public IHostingEnvironment Environment { get; set; }
    public IConfiguration Configuration {get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors();
           ConfigureJwtAuthService(services);
            services.AddMvc(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
           app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
           app.UseAuthentication(); 
            app.UseMvc(); 
        }

        public void ConfigureJwtAuthService(IServiceCollection services) {
      
    var tokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "https://securetoken.google.com/trendingtopit-cb54b",
        ValidateAudience = true,
        ValidAudience =  "trendingtopit-cb54b",
        ValidateLifetime = true
    };
     
    services.AddAuthentication(options =>  {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
    })
    .AddJwtBearerAuthentication(o =>  {
        o.Authority = "https://securetoken.google.com/trendingtopit-cb54b";
        o.TokenValidationParameters = tokenValidationParameters; 
        o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.HandleResponse();

                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        if (Environment.IsDevelopment())
                        {
                            // Debug only, in production do not share exceptions with the remote host.
                            return c.Response.WriteAsync(c.Exception.ToString());
                        }
                        return c.Response.WriteAsync("An error occurred processing your authentication.");
                    }
                };
    }); 
}
    }
}
