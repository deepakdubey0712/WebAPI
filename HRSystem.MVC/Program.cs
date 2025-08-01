var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<EmployeeApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});

builder.Services.AddHttpClient<DepartmentApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});

builder.Services.AddHttpClient<EmployeeAssignmentApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});
builder.Services.AddHttpClient<EmployeeGradeApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});
builder.Services.AddHttpClient<DeductionComponentApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();

app.UseDeveloperExceptionPage();

app.Run();
