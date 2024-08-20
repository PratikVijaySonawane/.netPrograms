using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


/* These are the methods for returning the single String */
//app.Map("/Home", () => "Hello World!");
/*app.MapGet("/Home", () => "This is the Get Method ");
app.MapPost("/Home", () => "This is the Post Method ");
app.MapPut("/Home", () => "This is the Put Method ");
app.MapDelete("/Home", () => "This is the delete Method ");*/

/* Declaring the Methods in Advanced Level */
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/Home", async (context) =>
    {

        await context.Response.WriteAsync("This is the GET Method");
    });

    endpoints.MapPost("/Home", async (context) =>
    {

        await context.Response.WriteAsync("This is the POST Method");
    });

    endpoints.MapPut("/Home", async (context) =>
    {

        await context.Response.WriteAsync("This is the PUT Method");
    });

    endpoints.MapDelete("/Home", async (context) =>
    {

        await context.Response.WriteAsync("This is the DELETE Method");
    });

});

/* Message for page not Found */
app.Run(async (HttpContext context) => {

    await context.Response.WriteAsync("Page-not Found");
});

app.Run();
