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

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}