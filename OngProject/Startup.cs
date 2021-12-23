using Abstractions;
using Amazon.S3;
using Core.Business;
using Core.Business.Interfaces;
using Core.Helper;
using Core.Mapper;
using Core.Models;
using DataAccess;
using Entities;
using OngProject.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.IO;

namespace OngProject
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OngProject", Version = "v1" });
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                c.IncludeXmlComments(xmlpath);

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

                c.AddSecurityRequirement(securityRequirement);
            });

            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<ApiDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("OngProject")));

            services.AddAWSService<IAmazonS3>();
            services.AddTransient<IEntityMapper, EntityMapper>();
            services.AddTransient<IRepository<Organization>, Repository<Organization>>();
            services.AddTransient<IOrganizationBusiness, OrganizationBusiness>();
            services.AddTransient<IDbContext<Organization>, DbContext<Organization>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<ICategoryBusiness, CategoryBusiness>();
            services.AddTransient<IDbContext<Category>, DbContext<Category>>();
            services.AddTransient<IMembersBusiness, MembersBusiness>();
            services.AddTransient<IRepository<Member>, Repository<Member>>();
            services.AddTransient<IDbContext<Member>, DbContext<Member>>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Roles>, Repository<Roles>>();
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<ITokenHandler, Core.Helper.TokenHandler>();
            services.AddTransient<IDbContext<User>, DbContext<User>>();
            services.AddTransient<IDbContext<Roles>, DbContext<Roles>>();
            services.AddTransient<IRepository<Slides>, Repository<Slides>>();
            services.AddTransient<ISlidesBusiness, SlidesBusiness>();
            services.AddTransient<IDbContext<Slides>, DbContext<Slides>>();
            services.AddTransient<IContactsBusiness, ContactsBusiness>();
            services.AddTransient<IRepository<Contacts>, Repository<Contacts>>();
            services.AddTransient<IDbContext<Contacts>, DbContext<Contacts>>();
            services.AddTransient<IDbContext<Slides>, DbContext<Slides>>();
            services.AddTransient<IAmazonS3Business, AmazonS3Business>();
            services.AddTransient<IS3AwsHelper, S3AwsHelper>();
            services.AddTransient<IRepository<News>, Repository<News>>();
            services.AddTransient<INewsBusiness, NewsBusiness>();
            services.AddTransient<IDbContext<News>, DbContext<News>>();

            services.AddTransient<SendGInterface, SendG>();
            services.AddTransient<IRepository<Comment>, Repository<Comment>>();
            services.AddTransient<ICommentBusiness, CommentBusiness>();
            services.AddTransient<IDbContext<Comment>, DbContext<Comment>>();


            services.AddTransient<INewsBusiness, NewsBusiness>();
            services.AddTransient<IDbContext<News>, DbContext<News>>();
            services.AddTransient<IRepository<News>, Repository<News>>();

            services.AddTransient<IMembersBusiness, MembersBusiness>();
            services.AddTransient<IDbContext<Member>, DbContext<Member>>();
            services.AddTransient<IRepository<Member>, Repository<Member>>();

            services.AddTransient<ITestimonialsBusiness, TestimonialsBusiness>();
            services.AddTransient<IDbContext<Testimonials>, DbContext<Testimonials>>();
            services.AddTransient<IRepository<Testimonials>, Repository<Testimonials>>();


            services.AddTransient<IActivityBusiness, ActivityBusiness>();
            services.AddTransient<IDbContext<Activity>, DbContext<Activity>>();
            services.AddTransient<IRepository<Activity>, Repository<Activity>>();

            services.AddTransient<IPaginationFilter, PaginationFilter>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });




            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "api/docs/{documentname}/swagger.json";
                });


                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/api/docs/v1/swagger.json", "OngProject v1");
                    c.RoutePrefix = "api/docs";
                });
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOwnershipMiddleware();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

//          app.UseRoutesAdminMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
