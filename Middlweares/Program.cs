var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


/* Declaring the Coustomized Middlewares with the run() Where we have to declare with the lambda Function */
//app.Run(async (context) => {

//    await context.Response.WriteAsync("Hi this is the dotnet Framework ");

//});

/* Declaring the Use Method to Execute the multiple Middle-wares */

app.Use(async (context,next) =>
{
    await context.Response.WriteAsync("Firts Middle Ware\n");

    await next(context);
});

app.Use(async(context, next) =>
{
    await context.Response.WriteAsync("Second Middle Ware\n");

    await next(context);
});

app.Run(async(context) =>
{
    await context.Response.WriteAsync("Final Middleware\n");
});

app.Run();
