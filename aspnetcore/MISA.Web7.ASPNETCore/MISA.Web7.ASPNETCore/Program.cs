

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MISA.Web7.ASPNETCore.Application;
using MISA.Web7.ASPNETCore.Domain;
using MISA.Web7.ASPNETCore.Infrastructure;
using MISA.Web7.ASPNETCore.Infrastructure.Repository;

namespace MISA.Web7.ASPNETCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors);
                    return new BadRequestObjectResult(new BaseException()
                    {
                        ErrorCode = 400,
                        UserMsg = Domain.Resources.ResourceVN.ValidationError,
                        DevMsg = Domain.Resources.ResourceVN.ValidationError,
                        TraceId = "",
                        MoreInfo = "",
                        Data = errors
                    }.ToString());
                };
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new LocalTimeZoneConverter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Khai báo Denpendency Injection

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeValidate, EmployeeValidate>();

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();



            builder.Services.AddCors(policy => policy.AddPolicy("corpolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corpolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseMiddleware<ExceptionMiddleware>();

            app.Run();
        }
    }
}