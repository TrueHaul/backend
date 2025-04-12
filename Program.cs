var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()   // Allow any origin
            .AllowAnyMethod()   // Allow any HTTP method
            .AllowAnyHeader();  // Allow any header
    });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");

// No HTTPS redirection
// No HSTS

app.MapControllers();

// Optional: Root test
app.MapGet("/", () => "Backend is running!");
app.Run();
