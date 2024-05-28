using BLL_EF;
using DAL;
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
        ValidIssuer = "https://localhost:7154", // Adres serwera API
        ValidAudience = "https://localhost:4200", // Adres frontendowego klienta
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bardzoseketrynykodktorymusibycwtajemnicy")),

    };
     options.Events = new JwtBearerEvents
     {
         OnAuthenticationFailed = context =>
         {
             // Logowanie b³êdów autoryzacji
             Console.WriteLine($"Authentication failed: {context.Exception.Message}");
             return Task.CompletedTask;
         }
     };
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebshopContext>();

builder.Services.AddScoped<ProductImp>();
builder.Services.AddScoped<OrderImp>();
builder.Services.AddScoped<BasketPositionImp>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// Configure CORS
app.UseCors(opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();
app.UseRequestLocalization();
app.MapControllers();

app.Run();
