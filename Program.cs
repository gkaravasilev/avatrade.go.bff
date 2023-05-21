using AvaTrade.Go.BFF.Features;
using AvaTrade.Go.BFF.Features.Filtering;
using AvaTrade.Go.BFF.Features.Providers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GetFilteredNews));

builder.Services.AddTransient<ITriesStructure, TriesStructure>();
builder.Services.AddTransient<ITextFilterer, TextFilterer>();
builder.Services.AddTransient<INewsProvider, NewsProvider>();


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
