using Microsoft.AspNetCore.Http.Json;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;
using Storybase.Core.Models.Payouts;
using StorybaseApi.Endpoints;
using StorybaseApi.Repositories;
using StorybaseApi.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StorybaseDbContext"));
});
builder.Services.AddScoped<ILiteraryWorkRepository, LiteraryWorkRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IRepository<Chapter>, ChapterRepository>();
builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWriterRepository, WriterRepository>();
builder.Services.AddScoped<IRepository<ReadingProgress>, GenericRepository<ReadingProgress>>();
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchasesRepository>();
builder.Services.AddScoped<IRepository<UserPayoutChoice>, GenericRepository<UserPayoutChoice>>();
builder.Services.AddScoped<IRepository<PayoutMethod>, GenericRepository<PayoutMethod>>();
builder.Services.AddScoped<IPayoutRequestRepository, PayoutRequestRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IUserPayoutMethodsRepository, UserPayoutMethodsRepository>();    
builder.Services.AddScoped<PayNowService>();
builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapChapterEndpoints();
app.MapLiteraryWorkEndpoints();
app.MapGenreEndpoints();
app.MapPurchaseEndpoints();
app.MapUserEndpoints();
app.MapWriterEndpoints();
app.MapBookmarkEndpoints();
app.MapLibraryEndpoints();
app.MapPaynowEndpoints();
app.MapPaymentsEndpoints();
app.MapSalesEndpoints();
app.MapPayoutsEndpoints();
app.MapUserPayoutMethodsEndpoints();
app.MapGeneralEndpoints();

app.Run();
