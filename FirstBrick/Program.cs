using FirstBrick.Startup;
using FirstBrick.Data;
using Microsoft.EntityFrameworkCore;
using FirstBrick.Middleware;
using EasyNetQ;
using FirstBrick.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomCors()
                .AddCustomSwagger()
                .AddCustomDbContext(builder.Configuration)
                .AddCustomIdentity()
                .AddCustomAuthentication(builder.Configuration)
                .AddCustomServices();

// EasyNetQ Setup 
var messageBrokerHost = builder.Configuration["MessageBroker:Host"];
var messageBrokerUsername = builder.Configuration["MessageBroker:Username"];
var messageBrokerPassword = builder.Configuration["MessageBroker:Password"];
var connectionStringEasyNetQ = $"host={messageBrokerHost};username={messageBrokerUsername};password={messageBrokerPassword}";
builder.Services.AddSingleton(RabbitHutch.CreateBus(connectionStringEasyNetQ));
builder.Services.AddSingleton<IHostedService, RabbitMQListener>();

builder.Services.AddTransient<RoleSeeder>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Apply any pending migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();

    // Seed roles after applying migrations
    var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
    await roleSeeder.SeedRolesAsync(); 
}

app.UseCors("AllowAll"); // For easier testing since it's a simple assessment project

// TODO: hide swagger on production, if u implement production env later...
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
