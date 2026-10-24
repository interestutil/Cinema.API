using Cinema.BL.Services.Customers;
using Cinema.BL.Services.Halls;
using Cinema.BL.Services.Movies;
using Cinema.DAL.Data;
using Cinema.DAL.Repos.Customers;
using Cinema.DAL.Repos.Halls;
using Cinema.DAL.Repos.Movies;
using Microsoft.EntityFrameworkCore;

namespace Cinema.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<IHallRepo, HallRepo>();
            builder.Services.AddScoped<IMovieRepo, MovieRepo>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IHallService, HallService>();
            builder.Services.AddScoped<IMovieService, MovieService>();

            var app = builder.Build();

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
