using MudBlazor.Services;
using Storybase.Blazor;
using Storybase.Blazor.Components;
using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IApiRepository, ApiRepository>();
builder.Services.AddHttpClient<IApiRepository, ApiRepository>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["StorybaseApiEndpoint"]);
});

var app = builder.Build();

app.MapDefaultEndpoints();

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
