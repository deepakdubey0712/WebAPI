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


RunSqlScripts(app);
app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
