using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewRelic.MAUI.Plugin;

namespace MauiApp2;

public partial class NextPage : ContentPage
{
    public NextPage()
    {
        InitializeComponent();
    }
    
    private async void OnHttpRequestSuccessClicked(object sender, EventArgs e)
    {
        Uri uri = new("https://reactnative.dev/movies.json");

        try
        {
            var httpClientHandler = HttpClientHandler();
            HttpClient myClient = new HttpClient(httpClientHandler);

            HttpResponseMessage response = await myClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
            }
        }
        catch (Exception ex)
        {
            await this.DisplayAlert("Error", ex.Message, "OK");
        }

    }

    private static HttpClientHandler HttpClientHandler()
    {
        HttpClientHandler httpClientHandler = CrossNewRelic.Current.GetHttpMessageHandler();
        return httpClientHandler;
    }

    private async void OnHttpRequestFailureClicked(object sender, EventArgs e)
    {
        Uri uri = new("https://reqres.in/api/login");
        var postData = new Dictionary<string, string>
        {
            { "email", "eve.holt@reqres.in" }
        };
        var content = new FormUrlEncodedContent(postData);

        try
        {
            var httpClientHandler = HttpClientHandler();
            HttpClient myClient = new HttpClient(httpClientHandler);

            HttpResponseMessage response = await myClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                String responseContent = await response.Content.ReadAsStringAsync();
                await this.DisplayAlert("Success", responseContent, "OK");
            }
            else
            {
                await this.DisplayAlert("Error", "Request failed", "OK");
            }
        }
        catch (Exception ex)
        {
            await this.DisplayAlert("Error", ex.Message, "OK");
        }
        
    }
    
    private void OnInterActionClicked(object sender, EventArgs e)
    {
        String id = CrossNewRelic.Current.StartInteraction("Interaction Example");
        
        // Do some work
        CreateForLoopTrace();
        
        CrossNewRelic.Current.EndInteraction(id);
        
    }

    private void CreateForLoopTrace()
    {
        int sum = 0;
        for (int i = 0; i < 10000; i++)
        {
            sum += i;
        }
    }

    private void OnHandledExcpetionClicked(object sender, EventArgs e)
    {
       String message  = "This is a test exception";
       
       try
       {
           message.Substring(100);
       } catch (Exception ex) {
           CrossNewRelic.Current.RecordException(ex);
       }
        
    }
    
    private void OnPagethreeClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PageFour());
    }
}