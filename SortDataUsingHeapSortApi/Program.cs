
using Microsoft.EntityFrameworkCore;
using SortDataUsingHeapSort.DataAccess.Data;
using SortDataUsingHeapSort.DataAccess.UnitOfWork;

namespace SortDataUsingHeapSortApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            #region AddEndpointsApiExplorer
            builder.Services.AddEndpointsApiExplorer();
            #endregion

            #region AddSwaggerGen
            builder.Services.AddSwaggerGen();
            #endregion

            #region DefaultConnection
            builder.Services.AddDbContext<HeapSortDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

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