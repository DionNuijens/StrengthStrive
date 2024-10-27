using Interfaces;
using StrengthStrive_DAL;
using StrengthStrive_Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IOefeningDal, OefeningDal>(_ => new OefeningDal(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<OefeningLogic>();

//builder.Services.AddScoped<ITraining, TrainingDAL>();
builder.Services.AddScoped<ITraining, TrainingDAL>(_ => new TrainingDAL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<TrainingLogica>();


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
