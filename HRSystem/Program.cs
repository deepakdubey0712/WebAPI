using HRSystem.Data;
using Microsoft.EntityFrameworkCore;
using HRSystem.Services;
using HRSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IEmployeeGradeRepository, EmployeeGradeRepository>();
builder.Services.AddScoped<IEmployeeGradeService, EmployeeGradeService>();
builder.Services.AddScoped<IDeductionComponentService, DeductionComponentService>();
builder.Services.AddScoped<IDeductionComponentRepository, DeductionComponentRepository>();
builder.Services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentService>();
builder.Services.AddScoped<IEmployeeDepartmentRepository, EmployeeDepartmentRepository>();




var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
