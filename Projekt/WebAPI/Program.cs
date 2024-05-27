using DAL;
using BLL_EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

 
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:4200",
            ValidAudience = "http://localhost:4200",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret"))
        };
    }
);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebshopContext>();

builder.Services.AddScoped<ProductImp>();
builder.Services.AddScoped<OrderImp>();
builder.Services.AddScoped<BasketPositionImp>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseAuthentication();

// Configure CORS
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRequestLocalization();
app.MapControllers();

app.Run();
