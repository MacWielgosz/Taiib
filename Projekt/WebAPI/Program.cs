using DAL;
using BLL_EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebshopContext>();

// Register ProductImp in the DI container
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

app.UseHttpsRedirection();

// Configure CORS
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.UseRequestLocalization();
app.MapControllers();

app.Run();
