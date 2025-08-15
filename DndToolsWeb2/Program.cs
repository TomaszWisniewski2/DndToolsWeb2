var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ScraperService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles(); // aby index.html dzia³a³ bez œcie¿ki
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

// dodaj fallback dla SPA / index.html
app.MapFallbackToFile("index.html");

app.Run();
