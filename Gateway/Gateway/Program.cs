using Gateway;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{


    options.AddPolicy(name: "AllowAllOrigin", builderx =>
    {
        builderx.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
              ;
    });
});
FindJson.FindJsonAll(builder.Configuration);
builder.Configuration.AddJsonFile("ocelot.global.json", false, true);
builder.Services.AddOcelot(builder.Configuration).AddConsul();
var app = builder.Build();



app.UseRouting();
app.UseCors("AllowAllOrigin");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});
app.MapControllers();
app.UseOcelot();
app.Run();
