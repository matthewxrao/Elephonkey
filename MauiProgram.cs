using Elephonkey.Models;
using Elephonkey.Service;
using Elephonkey.ViewModels;
using Elephonkey.Views;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;

namespace Elephonkey
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterAppServices()
                .RegisterViewModels()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("NotoSerif-Bold.ttf", "Serif");
                    fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                    fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSB");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsB");
                    fonts.AddFont("MaterialIconsOutlined-Regular.ttf", "Material");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INewsService, ElephonkeyNewsService>();
            mauiAppBuilder.Services.AddSingleton<SQLiteArticles>(); // Register SQLiteArticles as a singleton service

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<HomePageViewModel>();
            mauiAppBuilder.Services.AddTransient<ArticleViewModel>();

            mauiAppBuilder.Services.AddTransient<HomePage>();
            mauiAppBuilder.Services.AddTransient<ArticlePage>();

            return mauiAppBuilder;
        }
    }
}