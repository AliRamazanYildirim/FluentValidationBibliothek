using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationMit.NetCore6.Web.FluentValidierer;
using FluentValidationMit.NetCore6.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbKontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlVerbindung"));
});
//Wenn man  mit db verbinden möchte, kann AddScoped verwenden

//builder.Services.AddScoped<IValidator<Kunde>, KundeValidierer>();

//Wenn die Validator-Klasse in der Anwendung nicht geändert und nur eine erstellt wird, ist es bequemer,
//den AddSingleton-Dienst hinzuzufügen.

//builder.Services.AddSingleton<IValidator<Kunde>, KundeValidierer>();

builder.Services.AddControllersWithViews().AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssemblyContaining<KundeValidierer>();

    //conf.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    /*(typeof(Program).Assembly)*/
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;//Mit dieser Paramater kann man ErrorsMessage selber filtern
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
