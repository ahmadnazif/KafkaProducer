global using System.Text.Json;
global using KafkaProducer.Models;
global using KafkaProducer.Services;
global using KafkaProducer.Helpers;
using KafkaProducer.Serializer;
using Confluent.Kafka;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddSingleton(sp =>
{
    ProducerConfig clientConfig = new()
    {
        BootstrapServers = config["Kafka:BootstrapServers"],
    };

    // Message is internally serialized using SmsSerializer
    return new ProducerBuilder<Null, SmsBase>(clientConfig).SetValueSerializer(new SmsSerializer()).Build();
});

builder.Services.AddScoped<IProducerService, ProducerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x => x.AddDefaultPolicy(y => y.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.WebHost.ConfigureKestrel(x =>
{
    var port = int.Parse(config["Port"]);
    x.ListenAnyIP(port);
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
