using Microsoft.EntityFrameworkCore;
using WebAppAPIPatchExample.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddDbContext<DatabaseContext>(config =>
{
    config.UseMySql("Server=127.0.0.1;Port=3306;Database=test;Uid=root;Pwd=senha;", ServerVersion.Parse("8.0.43"));
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();