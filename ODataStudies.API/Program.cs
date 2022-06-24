using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataStudies.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents("odata", GetEdmModel()).Select();
});

var ConnectionString = builder.Configuration.GetSection("ConnectionString")["SqlServer"];

builder.Services.AddDbContext<AppDbContext>(optionsAction: (opt) =>
{
    opt.UseSqlServer(ConnectionString);
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Product>("Products");
    builder.EntitySet<Category>("Categories");
    return builder.GetEdmModel();
}