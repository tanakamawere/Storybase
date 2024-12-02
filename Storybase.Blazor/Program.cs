using MudBlazor.Services;
using Storybase.Blazor;
using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpClient("StorybaseApiClient", client =>
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
builder.Services.AddSingleton<IApiRepository, ApiRepository>();

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
