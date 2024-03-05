using Microsoft.EntityFrameworkCore;
using TaskMgmtApi.Data;
using TaskMgmtApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TaskMgmt API", Version = "v1" });
    // Include XML comments if available
    // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "YourApi.xml"));
});
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, DBUserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskMgmt API");
        c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root URL
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
