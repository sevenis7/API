using AspApplication;
using AspApplication.BLL.Interfaces;
using AspApplication.BLL.Service;
using AspApplication.Controllers;
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
        builder.Services.AddSession();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddHttpClient<IContactService, ApiService>(client =>
        {
            client.BaseAddress = new Uri(@"https://localhost:7111/api/values");
        });
        builder.Services.AddHttpClient<IAccountService, ApiAccountService>(client =>
        {
            client.BaseAddress = new Uri(@"https://localhost:7111/api");
        });

        builder.Services.AddMvc(options =>
        {
            options.EnableEndpointRouting = false;
        });
        builder.Services.AddHttpContextAccessor();

        var app = builder.Build();
        app.UseSession();
        app.UseMvcWithDefaultRoute();
        app.Run();
    }
}