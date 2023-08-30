using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using DemoJovenTranquilao.Data;

namespace DemoJovenTranquilao
{

    /*
     <Nullable>enable</Nullable>
    remove essa zica do csproject
    isso e novo para forçar string ser required
     
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mysqlDbVersion = Convert.ToInt32(builder.Configuration["MySqlDbVersion"]);
            var mysqlDbVersionMinor = Convert.ToInt32(builder.Configuration["MySqlDbVersionMinor"]);
            var serverVersion = new MySqlServerVersion(new Version(mysqlDbVersion, mysqlDbVersionMinor));
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<MyDbContext>((DbContextOptionsBuilder options) =>
               options.UseMySql(connectionString, serverVersion, (MySqlDbContextOptionsBuilder options) => 
               options.EnableRetryOnFailure()));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}