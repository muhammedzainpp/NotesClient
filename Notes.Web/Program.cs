using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Notes.Web;
using Notes.Web.Models.Configurations;
using Notes.Web.Models.Settings;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModels.AccountViewModels;
using Notes.Web.ViewModels.AccountViewModels.Interfaces;
using Notes.Web.ViewModels.ButtonWithSpinnerViewModels;
using Notes.Web.ViewModels.ModalViewModals;
using Notes.Web.ViewModels.NoteViewModels;
using Notes.Web.ViewModels.NoteViewModels.Interfaces;
using Notes.Web.ViewModels.NotifierViewModels;
using Notes.Web.ViewModels.NotifierViewModels.Interfaces;
using Notes.Web.ViewModels.UserProfileViewModals;
using Notes.Web.ViewModels.UserProfileViewModals.InterFaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var services = builder.Services;

AddHttp(builder);

AddServices(services);
services.AddSingleton<ISetting, Setting>();

services.AddBlazoredLocalStorage();
services.AddAuthorizationCore();

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
    services.AddTransient<ISaveNoteVm, SaveNoteVm>();
    services.AddTransient<IListNoteVm, ListNoteVm>();
    services.AddTransient<IRegisterVm, RegisterVm>();
    services.AddTransient<ILoginVm, LoginVm>();
    services.AddTransient<ILogoutVm, LogoutVm>();
    services.AddTransient<IUserProfileVm, UserProfileVm>();
    services.AddScoped<IFullNameVm, FullNameVm>();
    services.AddTransient<IButtonWithSpinnerVm, ButtonWithSpinnerVm>();
    services.AddSingleton<INotifierViewModel, NotifierViewModel>();
    services.AddSingleton<IModalVm, ModalVm>();
}

static void AddServices(IServiceCollection services)
{
    services.AddScoped<CustomStateProvider>();
    services.AddScoped<AuthenticationStateProvider, 
        CustomStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
    services.AddScoped<IApiService, ApiService>();
    services.AddScoped<IIdentityService, IdentityService>();
    services.AddScoped<IAccountService, AccountService>();
    services.AddScoped<INoteService, NoteService>();
    services.AddScoped<IUserProfileService, UserProfileService>();
}