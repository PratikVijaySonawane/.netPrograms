//using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

/* Adding the Middleware for the Convention based routing */
app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}");

app.Run();

