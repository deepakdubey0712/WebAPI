using HRSystem.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using HRSystem.WebAPI.Services;
using HRSystem.WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HRSystem API", Version = "v1" });
});

// PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));


// Run SQL scripts to create tables, seed data, and stored procedures
 static void RunSqlScripts(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var connection = context.Database.GetDbConnection();

    string[] scriptPaths = {
        "Scripts/CreateTables.sql",
        "Scripts/InsertData.sql"
    };

    foreach (var path in scriptPaths)
    {
        var script = File.ReadAllText(path);
        using var command = connection.CreateCommand();
        command.CommandText = script;
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}

builder.Services.AddScoped<IDeductionComponentService, DeductionComponentService>();
builder.Services.AddScoped<IDeductionComponentRepository, DeductionComponentRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentService>();
builder.Services.AddScoped<IEmployeeDepartmentRepository, EmployeeDepartmentRepository>();
builder.Services.AddScoped<IEmployeeGradeRepository, EmployeeGradeRepository>();
builder.Services.AddScoped<IEmployeeGradeService, EmployeeGradeService>();
builder.Services.AddScoped<IEmployeeSalaryService, EmployeeSalaryService>();
builder.Services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IPayslipRepository, PayslipRepository>();
builder.Services.AddScoped<IPayslipService, PayslipService>();
builder.Services.AddScoped<IPayslipComponentRepository, PayslipComponentRepository>();
builder.Services.AddScoped<IPayslipComponentService, PayslipComponentService>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<ISalaryComponentService, SalaryComponentService>();
builder.Services.AddScoped<ISalaryComponentRepository, SalaryComponentRepository>();



var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

//RunSqlScripts(app);
app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();
