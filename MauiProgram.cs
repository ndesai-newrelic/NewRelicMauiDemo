using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;
using NewRelic.MAUI.Plugin;

namespace MauiApp2;

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

        
        // Example usage
        Console.WriteLine("This is a test message for stdout.");
        Console.Error.WriteLine("This is a test message for stderr.");
        // CrossNewRelic.Current.HandleUncaughtException();
        builder.ConfigureLifecycleEvents(AppLifecycle => {
#if ANDROID
            AppLifecycle.AddAndroid(android => android
               .OnCreate((activity, savedInstanceState) => StartNewRelic()));
#endif
#if IOS

            AppLifecycle.AddiOS(iOS => iOS.WillFinishLaunching((_,__) => {
                StartNewRelic();
                return false;
            }));
#endif
        });
        return builder.Build();
    }
    
    private static void StartNewRelic()
    {
        
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            CrossNewRelic.Current.RecordException((Exception)e.ExceptionObject);
        };
    
    
        // Set optional agent configuration
        // Options are: crashReportingEnabled, loggingEnabled, logLevel, collectorAddress, crashCollectorAddress,analyticsEventEnabled, networkErrorRequestEnabled, networkRequestEnabled, interactionTracingEnabled,webViewInstrumentation, fedRampEnabled
        AgentStartConfiguration agentConfig = new AgentStartConfiguration();
    
    
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            CrossNewRelic.Current.Start("AAaa2ce539162d079b80b492350152aaffb353f0a0-NRMA");
            // Start with optional agent configuration 
            // CrossNewRelic.Current.Start("<APP-TOKEN-HERE", agentConfig);
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
        {
            CrossNewRelic.Current.Start("AAaa2ce539162d079b80b492350152aaffb353f0a0-NRMA");
            // Start with optional agent configuration 
            // CrossNewRelic.Current.Start("<APP-TOKEN-HERE", agentConfig);
        }

    }
}