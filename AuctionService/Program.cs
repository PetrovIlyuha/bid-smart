using AuctionService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
        
builder.Services.AddControllers();

builder.Services.AddDbContext<AuctionDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthorization();
        
app.MapControllers();

try
{
    DbInitializer.InitializeDatabase(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();