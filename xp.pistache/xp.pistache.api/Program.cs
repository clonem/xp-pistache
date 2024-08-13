using xp.pistache.api.DependencyInjection;
using xp.pistache.core.Application;
using xp.pistache.core.Infra;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


builder.Services
    .AddDependencyInjection(config)
    .AddInfraServices(config)
    .AddAplicatioinServices();


// Add services to the container.
//builder.Services.AddControllers();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();/

//builder.Services.AddMediatR(configuration =>
//{
//    configuration.RegisterServicesFromAssembly(typeof(SqlDataAccess).Assembly);
//    // configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
//});

var app = builder.Build();

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
