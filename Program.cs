var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

// No HTTPS redirection
// No HSTS
// No CORS for now

app.MapControllers();

// Optional: Root test
app.MapGet("/", () => "Backend is running!");

app.Run();
