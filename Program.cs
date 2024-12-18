
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Identity;

//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #region Connection DB
            builder.Services.AddDbContext<ECommerceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefautCon"));
            });
            #endregion

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ECommerceContext>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

  
            app.MapControllers();

            app.Run();
        }
    }
}
