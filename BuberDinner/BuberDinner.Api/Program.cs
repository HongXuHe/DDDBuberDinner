using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
builder.Services.AddPresentation().AddApplication().AddInfrastructure(configuration:builder.Configuration);
// builder.Services.AddControllers(o =>
// {
//     o.Filters.Add<ErrorHandlingFilterAttribute>();
// });
   
}
var app = builder.Build();
{
   // app.UseExceptionHandler("/error");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

 app.UseAuthorization();

app.MapControllers();

app.Run();
}