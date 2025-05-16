using Accessor.Buisness.Services;
using BookHavenWebAPI.Buisness.Services;
using BookHavenWebAPI.Core.Abstractions;
using BookHavenWebAPI.CQS.Commands.AccountCommands;
using BookHavenWebAPI.Database; 
using BookHavenWebAPI.Utils.JWTUtil;  
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace BookHavenWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. 

            // Настройка Serilog
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            //dependency Injection DataBase
            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<BookHavenContext>(optionsBuilder => optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            //dependency Injection AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //dependency Injection Handlers  
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddAccountCommand>());
             
            //Dependency Injection Services
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<ICollectionService, CollectionService>();
            builder.Services.AddScoped<ICollectionBookService, CollectionBookService>();
            builder.Services.AddScoped<IJWTUtil, JWTUtilSha256>();
             

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi  
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            { 

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                    "Enter 'Bearer' [space] and then your token in the text input belown. \r\n\r\n" +
                    "Example: \"Bearer 1233213qwewefe1343242\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme{

                            Reference = new OpenApiReference{

                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"

                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header

                        },
                        new List<string>()
                    }
                });
            });

            //Configurating Authentication with JWT Token 
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Token:Issuer"],
                    ValidAudience = builder.Configuration["Token:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:JWTSecret"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookHavenContext>();
                db.Database.Migrate();
            }

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
