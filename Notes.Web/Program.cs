using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Notes.Web;
using Notes.Web.Models.Configurations;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.ViewModel.NoteViewModels;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

AddHttp(builder);

builder.Services.AddScoped<IApiService, ApiService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());

//inject view models
AddViewModels(builder);

await builder.Build().RunAsync();

static void AddHttp(WebAssemblyHostBuilder builder)
{
    var config = builder.Configuration.Get<LocalConfigurations>();
    var url = config.ApiConfigurations.BaseUri;
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });
}

static void AddViewModels(WebAssemblyHostBuilder builder)
{
    builder.Services.AddScoped<ISaveNoteVm, SaveNoteVm>();
    builder.Services.AddScoped<IListNoteVm, ListNoteVm>();
    builder.Services.AddScoped<IRegisterVm, RegisterVm>();
    builder.Services.AddScoped<ILoginVm, LoginVm>();
}