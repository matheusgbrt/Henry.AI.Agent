using Mgb.Api.Extensions;
using Mgb.Consul.Dtos;
using Mgb.Consul.Extensions;
using Mgb.DependencyInjections.DependencyInjectons.Extensions;
using Mgb.ServiceBus.ServiceBus.Extensions;
using OpenAI.Chat;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Configuration["AppId"] = "Henry.AI.Agent";

builder.Services.RegisterAllDependencies();
await builder.Configuration.AddConsulConfigurationAsync(new ConsulConfig(){AppId = "Henry.AI.Agent"});
builder.Services.AddConsulRegistration("Henry.AI.Agent");
builder.ConfigureKestrelWithNetworkHelper();
builder.Services.RegisterServiceBus(builder.Configuration);


builder.Services.AddSingleton<ChatClient>(serviceProvider =>
{
    var apiKey = builder.Configuration["OpenAI:ApiKey"];
    var model = "gpt-5-nano";

    return new ChatClient(model, apiKey);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.AddConsulHealthCheck();
app.UseAuthorization();

app.MapControllers();

app.Run();