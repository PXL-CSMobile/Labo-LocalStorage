using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using PieShop.App.Services;
using PieShop.App.ViewModels;
using PieShop.App.Views;
using System.Net.Http.Headers;

namespace PieShop.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            builder.Services.AddSingleton<IPieRepository,PieApiRepository>();
            builder.Services.AddSingleton<ICartRepository, CartRepository>();
            builder.Services.AddSingleton<PieOverviewViewModel>();
            builder.Services.AddSingleton<PieOverviewView>();
            builder.Services.AddTransient<PieDetailViewModel>();
            builder.Services.AddTransient<PieDetailView>();
            builder.Services.AddTransient<CartViewModel>();
            builder.Services.AddTransient<CartView>();
            builder.Services.AddSingleton<INavigationService,MauiNavigationService>();
            builder.Services.AddSingleton<HttpClient>(sp =>
            {
                return new HttpClient()
                {
                    BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5051/api/" : "http://localhost:5051/api/"),
                    Timeout = TimeSpan.FromSeconds(10)
                };
            });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
