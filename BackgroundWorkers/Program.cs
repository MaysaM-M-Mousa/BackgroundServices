using BackgroundWorkers.Repositories;
using BackgroundWorkers.Services;
using BackgroundWorkers.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IShiftRepository, ShiftRepository>();     // fake in-memory database
builder.Services.AddScoped<IShiftService, ShiftService>();


// This is the way we handle registering a hosted service that is using a scoped class
builder.Services.AddScoped<IShiftImportService, ShiftImportService>();
builder.Services.AddSingleton<ImportShiftWorker>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<ImportShiftWorker>());

builder.Services.AddHttpClient<IShiftImportService, ShiftImportService>(
    httpClient => httpClient.BaseAddress = new Uri("https://localhost:7191"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// ref: https://medium.com/medialesson/run-and-manage-periodic-background-tasks-in-asp-net-core-6-with-c-578a31f4b7a3 
