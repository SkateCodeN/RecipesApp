using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data;
using DotNetEnv;

// Load environment variables from the .env file
Env.Load();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//Register the DbContext using connection string
builder.Services.AddDbContext<RecipesDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 3-17-2025 Adding the HttpClient to make remote calls to api's
// WHY: Register this dependancy to use the Service

builder.Services.AddHttpClient<NoteApp.Services.DataService>();

// Configure CORS to allow requests from your frontend
//Middleware
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowDevFrontend", policy =>
    {
        // Allow requests from your frontend's origin (adjust the URL as needed)
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Use CORS before other middlewares
app.UseCors("AllowDevFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.MapControllers();


// Enable serving default files (like index.html) automatically.
app.UseDefaultFiles();
// Enable serving static files from wwwroot.
app.UseStaticFiles();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
