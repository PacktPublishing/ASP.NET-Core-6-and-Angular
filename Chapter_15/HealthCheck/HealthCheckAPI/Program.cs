global using HealthCheckAPI;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHealthChecks()
    .AddCheck("ICMP_01",
        new ICMPHealthCheck("www.ryadel.com", 100))
    .AddCheck("ICMP_02",
        new ICMPHealthCheck("www.google.com", 100))
    .AddCheck("ICMP_03",
        new ICMPHealthCheck($"10.0.0.0", 100));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy(name: "AngularPolicy",
        cfg => {
            cfg.AllowAnyHeader();
            cfg.AllowAnyMethod();
            cfg.WithOrigins(builder.Configuration["AllowedCORS"]);
        }));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.MapGet("/Error", () => Results.Problem());
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AngularPolicy");

app.UseHealthChecks(new PathString("/api/health"),
    new CustomHealthCheckOptions());

app.MapControllers();

app.MapMethods("/api/heartbeat", new[] { "HEAD" },
    () => Results.Ok());

app.MapHub<HealthCheckHub>("/api/health-hub");

app.MapGet("/api/broadcast/update2", (IHubContext<HealthCheckHub> hub) =>
{
    hub.Clients.All.SendAsync("Update", "test");
    return Results.Text("Update message sent.");
});

app.Run();
