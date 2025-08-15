var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles(); // Umo�liwia serwowanie plik�w statycznych

app.UseRouting();

app.MapControllers();

// Obs�uguje nieznane �cie�ki i przekierowuje do index.html
app.MapFallbackToFile("index.html");

app.Run();
