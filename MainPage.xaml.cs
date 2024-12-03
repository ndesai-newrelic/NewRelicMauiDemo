using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using NewRelic.MAUI.Plugin;

namespace MauiApp2;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        On<iOS>().SetUseSafeArea(true);
        CrossNewRelic.Current.TrackShellNavigatedEvents();

    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        var attr = new Dictionary<string, object>
        {
            { "application", "Test APP" },
            { "DeviceId", 1234555 },
            { "UserId", "Test USER" ?? "" }
        };
        attr.Add("level", "DEBUG");
        attr.Add("message", "This is From Maui");
        CrossNewRelic.Current.LogAttributes(attr);
        //
        //
        CrossNewRelic.Current.LogInfo("This is From Maui");
        CrossNewRelic.Current.LogDebug("This is From Maui");
        CrossNewRelic.Current.LogVerbose("This is From Maui");
        CrossNewRelic.Current.LogWarning("This is From Maui");
        CrossNewRelic.Current.LogError("This is From Maui");
        CrossNewRelic.Current.Log(LogLevel.VERBOSE, "This is From Maui");
        //
        // Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
        // keyValuePairs.Add("message", "This is From Attribute");
        // keyValuePairs.Add("eat", "Pizza");
        // keyValuePairs.Add("food", "tell me");
        //
        // CrossNewRelic.Current.LogAttributes(keyValuePairs);
        //

        // throw new Exception("This is a test exception");

       
    }

    private void OnRecordBreadCrumbClicked(object sender, EventArgs e)
    {

        var attr = new Dictionary<string, object>
        {
            { "Attribute1", "TestAttribute" },
            { "Attribute2", 1234555 },
        };
        CrossNewRelic.Current.RecordBreadcrumb("This is RecordBreadCrumb Clicked", attr);
    }
    
    private void OnRecordCustomEventClicked(object sender, EventArgs e)
    {
        var attr = new Dictionary<string, object>
        {
            { "CustomAttribute1", "TestAttribute" },
            { "CustomAttribute2", 1234555 },
        };
        CrossNewRelic.Current.RecordCustomEvent("CustomEvent", "TestName", attr);
    }
    
    private void OnSetAttributetClicked(object sender, EventArgs e)
    {
        CrossNewRelic.Current.SetAttribute("Global Attribute", "Global Value");
        
    }
    
    private void OnSetUserIdtClicked(object sender, EventArgs e)
    {
        CrossNewRelic.Current.SetUserId("NewRelicUser");
        
    }
    private void OnNextPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NextPage());
        
    }
    
    


}