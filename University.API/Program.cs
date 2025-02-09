
using Microsoft.EntityFrameworkCore;
using University.Repository.Data;

namespace University.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=DESKTOP-VU8IK37\\SQLEXPRESS;Database=University;Trusted_Connection=true;TrustServerCertificate=true"));

            var app = builder.Build();


            app.MapOpenApi();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
