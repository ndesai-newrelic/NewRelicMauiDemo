# NewRelic.MAUI.Plugin Sample Application

MauiApp2 is a .NET MAUI application that demonstrates various features and integrations with New Relic.

## Features

- **HTTP Requests**: Demonstrates making HTTP GET and POST requests.
- **New Relic Integration**: Logs various events, metrics, and exceptions to New Relic.
- **Navigation**: Includes navigation between multiple pages.
- **Error Handling**: Demonstrates handling and logging exceptions.

## Pages

### MainPage

- **OnCounterClicked**: Increments a counter and logs various messages and attributes to New Relic.
- **OnRecordBreadCrumbClicked**: Records a breadcrumb event with attributes.
- **OnRecordCustomEventClicked**: Records a custom event with attributes.
- **OnSetAttributetClicked**: Sets a global attribute.
- **OnSetUserIdtClicked**: Sets the user ID.
- **OnNextPageClicked**: Navigates to `NextPage`.

### NextPage

- **OnHttpRequestSuccessClicked**: Makes an HTTP GET request and handles the response.
- **OnHttpRequestFailureClicked**: Makes an HTTP POST request and handles the response.
- **OnInterActionClicked**: Starts and ends a New Relic interaction.
- **OnHandledExcpetionClicked**: Demonstrates handling and logging an exception.
- **OnPagethreeClicked**: Navigates to `PageFour`.

### PageFour

- **OnRecordMetricClicked**: Records a metric to New Relic.
- **OnCrashClicked**: Simulates a crash by causing a `NullReferenceException`.
- **OnANRClicked**: Simulates an Application Not Responding (ANR) state.

## Setup

1. Clone the repository.
2. Open the solution in JetBrains Rider.
3. Restore the NuGet packages.
4. Build and run the application.

## Dependencies

- .NET MAUI
- NewRelic.MAUI.Plugin

## License

This project is licensed under the MIT License.