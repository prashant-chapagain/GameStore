using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);


var app = builder.Build();

await app.Services.InitializeDbAsync();

app.MapGamesEndpoints();



app.Run();
