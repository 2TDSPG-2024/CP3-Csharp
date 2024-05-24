using CP3.Models;
using CP3.Persistence;
using CP3.Persistence.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

 

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("CP3DbContext")!;

Console.WriteLine(conn);

Console.WriteLine("ASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASHASKHDASHJGHDHJASSDGSAGHSJADGASHJGDASJGJASHGDJASHGSAJDGASH");



builder.Services.AddDbContext<Cp3DbContext>(options =>
{
    options.UseOracle(conn);
});

builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
builder.Services.AddScoped<IRepository<StudentClass>, Repository<StudentClass>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
