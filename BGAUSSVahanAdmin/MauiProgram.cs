using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace BGAUSSVahanAdmin;

public static class MauiProgram
{
    public static IPublicClientApplication PCA;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Initialize MSAL client
        PCA = PublicClientApplicationBuilder
            .Create("30c02e55-3684-45cf-b5f7-65d4251e12d2")  // from Azure AD
            .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient") // redirect URI
            .Build();

        return builder.Build();
    }
}