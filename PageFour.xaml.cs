using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewRelic.MAUI.Plugin;

namespace MauiApp2;

public partial class PageFour : ContentPage
{
    public PageFour()
    {
        InitializeComponent();
    }
    
    private void OnRecordMetricClicked(object sender, EventArgs e)
    {
        CrossNewRelic.Current.RecordMetric("This is a test metric", "category", 100);
    }
    
    private void OnCrashClicked(object sender, EventArgs e)
    {
        String message  = null;
        
        message.Substring(100);
    }
    
    private void OnANRClicked(object sender, EventArgs e)
    {
        while (true)
        {
            // Do nothing
        }
    }
}