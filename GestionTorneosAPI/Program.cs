using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GestionTorneosAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TorneosAPIContext>(options =>
                                 //options.UseSqlServer(builder.Configuration.GetConnectionString("TorneosAPIContext.sqlServer") ?? throw new InvalidOperationException("Connection string 'TorneosAPIContext' not found.")))
                                 //Usa PostgreSQL:
                                 options.UseNpgsql(builder.Configuration.GetConnectionString("TorneosAPIContext.postgresql") ?? throw new InvalidOperationException("Connection string 'TorneosAPIContext.postgresql' not found.")));


            // Add services to the container.

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
