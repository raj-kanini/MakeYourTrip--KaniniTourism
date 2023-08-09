
using Kanini_Tourism.Models;
using Kanini_Tourism.Repository;
using Microsoft.EntityFrameworkCore;

namespace Kanini_Tourism
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

            builder.Services.AddDbContext<TourismDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("conStr")));

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<ITravelAgentRepository, TravelAgentRepository>();
            builder.Services.AddScoped<ITravelerRepository, TravelerRepository>();
            builder.Services.AddScoped<ITravelDetailRepository, TravelDetailRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<IBookingDetailsRepository, BookingDetailsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyCorsPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}