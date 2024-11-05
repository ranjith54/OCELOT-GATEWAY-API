using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add Ocelot configuration from ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
// Register Ocelot services
builder.Services.AddOcelot();

// JWT Authentication Configuration
var key = Encoding.ASCII.GetBytes("your_secret_key_for_jwt"); // Secret key for JWT token (replace with your own)

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "your_issuer",    // Issuer of the token
            ValidAudience = "your_audience", // Audience for the token
            ValidateLifetime = true, // Ensures token hasn't expired
            ClockSkew = TimeSpan.Zero // Reduces clock skew for token expiration
        };
    });
    // Add services to the container.

    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Use Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();
// Use Ocelot as middleware
await app.UseOcelot();
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
