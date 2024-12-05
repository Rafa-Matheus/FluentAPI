using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI;

public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<AppDataContext>(options
            => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();
        app.MapControllers();

        app.Run();
    }
}
