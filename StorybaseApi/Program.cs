using Microsoft.AspNetCore.Http.Json;
using StorybaseApi.Endpoints;
using StorybaseApi.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IJwtGenerator, JwtGenerator>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StorybaseDbContext"));
});

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapAuthEndpoints();
app.MapChapterEndpoints();
app.MapWriterEndpoints();
app.MapBookEndpoints();
app.MapGeneralEndpoints();

app.Run();
