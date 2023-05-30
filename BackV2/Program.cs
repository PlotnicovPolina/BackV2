using Back.Data;
using BackV2.AutoMapperProfile;
using BackV2.Data.Repositories;
using BackV2.Middleware;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDBContext>(
    options => {
        options
        .UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Back - DB connection",
        Version = "v1",
        Description = "Back Web API"
    });

    c.CustomSchemaIds(type => type.FullName);
    c.EnableAnnotations();

});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<EFCoreRaceRepository>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elk.srl365.com:65100"))
    {
        IndexFormat = "backv2-serilog-index-{0:yyyy.MM}",
        TemplateName = "backv2_Serilog",
        AutoRegisterTemplate = true,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
    })
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.UseMiddleware<Middleware>();

app.UseRouting();

app.MapControllers();

app.Run();
