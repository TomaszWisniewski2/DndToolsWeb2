var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ScraperService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles(); // aby index.html dzia�a� bez �cie�ki
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

// dodaj fallback dla SPA / index.html
app.MapFallbackToFile("index.html");

app.Run();
