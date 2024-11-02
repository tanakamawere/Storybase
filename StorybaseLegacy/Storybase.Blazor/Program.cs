using MudBlazor.Services;
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

//MudBlazor
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Storybase.Components._Imports).Assembly);

app.Run();
