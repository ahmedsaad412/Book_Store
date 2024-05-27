
using Book_Store.Core.Interfaces;
using Book_Store.EF;
using Book_Store.EF.Reposatory;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                         options.UseSqlServer(
                           builder.Configuration.GetConnectionString("DefaultConnection"),
                           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //builder.Services.AddTransient(typeof(IBaseReposatory<>), typeof(BaseReposatory<>));
            builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
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
