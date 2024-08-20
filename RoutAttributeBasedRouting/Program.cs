
var builder = WebApplication.CreateBuilder(args);

/* Using this Line we can add the Controllers with views */
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

/* Adding the middlewares */
app.MapControllers();

app.Run();
