using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MIS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AdminAcc>();
builder.Services.AddScoped<DBHelper>();
//builder.Services.AddSingleton<WeatherForecastService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
 
public class DBHelper
{
	public static MedDbContext _db = new MedDbContext();
}

public class AdminAcc
{
	private static string _isAdmin = "nonAdmin"; 

	public void setAdmin()
	{
		_isAdmin = "Admin";
	}

	public void deAdmin()
	{
        _isAdmin = "nonAdmin";
    }

	public string getAdmin()
	{
		return _isAdmin;
	}
}
