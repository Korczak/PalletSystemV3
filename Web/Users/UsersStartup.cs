using Core.Users.Common;
using Core.Users.Constants;
using Core.Users.Login;
using Core.Users.Register;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Configuration;

namespace Web.Users
{
    public class UsersStartup : IServiceStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PasswordHashGenerator>();
            services.AddSingleton<RandomPasswordGenerator>();
            services.AddSingleton<UserRegisterService>();
            services.AddSingleton<UserRegisterAccess>();
            services.AddSingleton<UserLoginService>();
            services.AddSingleton<UserLoginDataAccess>();

            services.AddAuthentication(
                    CookieAuthenticationDefaults.AuthenticationScheme
                )
                .AddCookie(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Events.OnRedirectToAccessDenied = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.CompletedTask;
                        };

                        options.Events.OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.CompletedTask;
                        };

                        options.LoginPath = "/login";
                        options.LogoutPath = "/logout";
                        options.SlidingExpiration = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);


                    }
                );

            services.AddAuthorization(o =>
            {
                o.AddPolicy("DefaultPolicy", b =>
                {
                    b.RequireAuthenticatedUser();
                });

                o.AddPolicy("FirstLoginPolicy", b =>
                {
                    b.RequirePasswordChangeAfterFirstLogin();
                });

                o.AddPolicy(PolicyCollection.Administrator, policy => policy.RequireRole(Role.Admin.ToString()));
                o.AddPolicy(PolicyCollection.Operator, policy => policy.RequireRole(Role.Admin.ToString(),
                                                                                     Role.Operator.ToString()));
                o.AddPolicy(PolicyCollection.User, policy => policy.RequireRole(Role.User.ToString(),
                                                                                Role.Operator.ToString(),
                                                                                Role.Admin.ToString()));
            });
        }
    }
}
