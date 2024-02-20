using Teatro.Data;
using Teatro.Business;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IObraServices, ObraServices>();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TeatroDB");


//EFCore Usuario
builder.Services.AddDbContext<TeatroContext>(options =>
  options.UseSqlServer(connectionString));
builder.Services.AddScoped<IObraRepository, ObraEFRepository>();

builder.Services.AddDbContext<TeatroContext>(options =>
  options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUsuarioRepository, UsuarioEFRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TeatroContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        throw new Exception("Error durante la migración de la base de datos.", ex);
    }
}

app.Run();
