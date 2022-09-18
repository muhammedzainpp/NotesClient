using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Notes.Web;
using Notes.Web.Models;
using Notes.Web.Models.Configurations;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.AccountViewModels;
using Notes.Web.ViewModel.AccountViewModels.Interfaces;
using Notes.Web.ViewModel.NoteViewModels;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;
using Notes.Web.ViewModel.UserProfileViewModals;
using Notes.Web.ViewModel.UserProfileViewModals.InterFaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var services = builder.Services;

AddHttp(builder);

services.AddScoped<IApiService, ApiService>();
services.AddScoped<IIdentityService, IdentityService>();
services.AddSingleton<ISettings, Settings>();

services.AddBlazoredLocalStorage();
services.AddAuthorizationCore();
services.AddScoped<CustomStateProvider>();
services.AddScoped<AuthenticationStateProvider, CustomStateProvider>(s => s.GetRequiredService<CustomStateProvider>());

//inject view models
AddViewModels(services);

await builder.Build().RunAsync();

static void AddHttp(WebAssemblyHostBuilder builder)
{
    var config = builder.Configuration.Get<LocalConfigurations>();
    var url = config.ApiConfigurations.BaseUri;
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });
}

static void AddViewModels(IServiceCollection services)
{
    services.AddScoped<ISaveNoteVm, SaveNoteVm>();
    services.AddScoped<IListNoteVm, ListNoteVm>();
    services.AddScoped<IRegisterVm, RegisterVm>();
    services.AddScoped<ILoginVm, LoginVm>();
    services.AddScoped<ILogoutVm, LogoutVm>();
    services.AddScoped<IUserProfileVm, UserProfileVm>();
    services.AddScoped<IFullNameVm, FullNameVm>();
}