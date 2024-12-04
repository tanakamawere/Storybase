using MudBlazor.Services;
using Storybase.Application.Interfaces;
using Storybase.Application.Services;
using Storybase.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpClient<IApiClient, ApiClient>("StorybaseApiClient", client =>
{
    var baseAddress = builder.Configuration["StorybaseApiEndpoint"];
    if (string.IsNullOrEmpty(baseAddress))
    {
        throw new ArgumentNullException(nameof(baseAddress), "StorybaseApiEndpoint configuration is missing or empty.");
    }
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddMudServices();

//Repository registrations  
builder.Services.AddScoped<BookmarkClient>();
builder.Services.AddScoped<ChapterClient>();
builder.Services.AddScoped<LiteraryWorkClient>();
builder.Services.AddScoped<PurchaseClient>();
builder.Services.AddScoped<ReadingProgressClient>();
builder.Services.AddScoped<UserClient>();
builder.Services.AddScoped<WriterClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddAdditionalAssemblies(typeof(Storybase.Components._Imports).Assembly);

app.Run();
