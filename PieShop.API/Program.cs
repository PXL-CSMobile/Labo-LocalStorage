
using Microsoft.EntityFrameworkCore;
using PieShop.API.Data;
using PieShop.API.Repositories;

namespace PieShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Register DbContext
            builder.Services.AddDbContext<PieShopDbContext>(opts => {
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:PieShopDBConnectionString"]);
            });

            //Register PieRepository
            builder.Services.AddScoped<IPieRepository, PieRepository>();

            builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
