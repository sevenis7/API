using AspApplication.BLL.Interfaces;
using AspApplication.BLL.Service;
using AspApplication.DAL.DataContext;
using AspApplication.DAL.Interfaces;
using AspApplication.DAL.Repositories;
using AspApplication.Domain;
using AspApplication.Domain.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("Jwt"));
        builder.Services.AddDbContext<AspApplicationDbContext>(options =>
        {
            options.UseSqlServer(connection);
        });
        builder.Services.AddTransient<IBaseRepository<Contact>, ContactRepository>();
        builder.Services.AddTransient<IBaseRepository<User>, UserRepository>();
        builder.Services.AddTransient<IContactService, ContactService>();
        builder.Services.AddTransient<IAccountService, AccountService>();
        builder.Services.AddTransient<IJWT, JWT>();

        builder.Services.AddMvc(opt =>
        {
            opt.EnableEndpointRouting = false;
        });

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(e =>
        {
            e.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });
        builder.Services.AddAuthorization();

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMvc();
        app.Run();
    }
}