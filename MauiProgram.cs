using Camera.MAUI;
using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;
using Microsoft.Extensions.Logging;

namespace AppComida
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()               
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // AMEL a TODOS: Servicio para abrir la aplicacion de e-mail por defaul del dispositivo
            builder.Services.AddSingleton<IEmail>(Email.Default);

            // ApiKey
            builder.UseArcGISRuntime(config => config.UseApiKey("AAPKb38cbc5553334941b9a91067b2e3edb6qjLlpStmqVteq4an7tLkI5scHEzkzeuFazeWLtqUh6C95KvK9qLG8uMoPdqSNUOh"));

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}