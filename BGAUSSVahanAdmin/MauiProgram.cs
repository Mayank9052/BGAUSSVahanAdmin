using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace BGAUSSVahanAdmin;

public static class MauiProgram
{
    //public static IPublicClientApplication PCA;
    public static IPublicClientApplication PCA { get; private set; }

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

        // ✅ Initialize MSAL client with Tenant-specific authority
        PCA = PublicClientApplicationBuilder
     .Create("30c02e55-3684-45cf-b5f7-65d4251e12d2")
     .WithAuthority("https://login.microsoftonline.com/a265301a-63b1-4aec-9d47-273b49c178b4")
#if WINDOWS
    .WithRedirectUri("http://localhost")
#else
     .WithRedirectUri("msauth://com.companyname.bgaussvahanadmin/RkPW28YqMFq30noUKxVIWoAox9w%3D")
#endif
     .Build();

    //    PCA = PublicClientApplicationBuilder
    //.Create("30c02e55-3684-45cf-b5f7-65d4251e12d2")
    //.WithAuthority("https://login.microsoftonline.com/a265301a-63b1-4aec-9d47-273b49c178b4")
    //.WithRedirectUri("msauth://com.companyname.bgaussvahanadmin/RkPW28YqMFq30noUKxVIWoAox9w%3D")
    //.Build();

        return builder.Build();
    }
}