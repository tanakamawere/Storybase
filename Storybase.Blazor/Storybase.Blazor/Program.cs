using Storybase.Blazor.Components;
using StorybaseLibrary.Interfaces;
using StorybaseLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSingleton<IApiRepository, ApiRepository>();
builder.Services.AddHttpClient<IApiRepository, ApiRepository>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["StorybaseApi:StorybaseApiEndpoint"]);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
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
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Storybase.Blazor.Client._Imports).Assembly)
    .AddAdditionalAssemblies(typeof(Storybase.Components._Imports).Assembly);

app.Run();
