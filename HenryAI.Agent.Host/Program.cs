using HenryAI.Agent.ExternalDependencies.DependencyInjectons.Extensions;
using OpenAI.Chat;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ChatClient>(serviceProvider =>
{
    var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    var model = "gpt-5-nano";

    return new ChatClient(model, apiKey);
});

builder.Services.RegisterAllDependencies();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();