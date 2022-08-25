using poker_hand_card_service.Interfaces;
using poker_hand_card_service.Services;
using poker_hand_card_service.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddScoped<IDeck, Deck>();
builder.Services.AddScoped<IHandEvaluator, HandEvaluator>();
builder.Services.AddScoped<ICardService, CardService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
