---
Description: In this walkthrough, you will create and run your first experiment with A/B testing.
title: Create and run your first experiment with A/B testing
ms.assetid: 16A2B129-14E1-4C68-86E8-52F1BE58F256
---

# Create and run your first experiment with A/B testing

In this walkthrough, you will:
* Create an experiment on the Windows Dev Center dashboard that tests whether changing the background color of an app button successfully increases the number of button clicks.
* Create an app that retrieves variation settings from Dev Center, uses this data to change the background color of a button, and logs view and conversion event data to Dev Center.
* Run the app to gather experiment data.
* Review the experiment results on the Dev Center dashboard, choose a variation to enable for all users of the app, and complete the experiment.

For an overview of A/B testing with Dev Center, see [Run app experiments with A/B testing](run-app-experiments-with-a-b-testing.md).

## Prerequisites

To follow this walkthrough, you must have a Windows Dev Center account and you must configure your development computer as described in [Run app experiments with A/B testing](run-app-experiments-with-a-b-testing.md).

## Create the experiment in Windows Dev Center

1. Sign in to the [Dev Center dashboard](https://dev.windows.com/overview).
2. If you already have an app in Dev Center that you want to use to create an experiment, under **Your apps**, select the app. If you do not yet have an app in your dashboard, [create a new app by reserving a name](../publish/create-your-app-by-reserving-a-name.md) and then select that app in your dashboard.
3. In the navigation pane, click **Services** and then click **Experimentation**.
4. In the **API keys** section, select **New API key** to generate a new API key, and enter the name **My First Experiment** for the API key. You will use this API key in the next section of this walkthrough.
5. In the **Experiments** section, click **New experiment**. In the **Experiment name** field, type the name **Optimize Button Clicks**.
6. In the **View event name** field, type the name **userViewedButton**. Later in this walkthrough, you will add code that logs this view event when the main page for your app is initialized and the button is visible to the user.
7. In the **Goals and conversion events** section, enter the following values:
  * In the **Goal name** field, type **Increase Button Clicks**.
  * In the **Conversion event name** field, type the name **userClickedButton**. Later in this walkthrough, you will add code that logs this conversion event in the click event handler for the button.
  * In the **Objective** field, choose **Maximize**.
8. In the **Variations and settings** section, click **Add setting** three times. You should now have four rows of empty settings.
  * In the first row, type **buttonText** for the setting name, type **Grey Button** in the **Variation A** column, and type **Blue Button** in the **Variation B** column.
  * In the second row, type **r** for the setting name, type **128** in the **Variation A** column, and type **1** in the **Variation B** column.
  * In the third row, type **g** for the setting name, type **128** in the **Variation A** column, and type **1** in the **Variation B** column.
  * In the fourth row, type **b** for the setting name, type **128** in the **Variation A** column, and type **255** in the **Variation B** column.  
9. Confirm that the **Distribute equally** check box is selected so that the variations will be distributed equally to your app.
10. Click **Save** and then click **Activate**.

> **Important**  After you activate an experiment, you can no longer modify the experiment parameters unless it is a test experiment (you clicked the **Test experiment** check box when you created the experiment). Typically, we recommend that you code the experiment in your app before activating your experiment. For simplicity, in this walkthrough you can activate the experiment now.

## Code the experiment in your app

1. In Visual Studio 2015, create a new Universal Windows Platform project using Visual C#. Name the project **SampleExperiment**.
2. In Solution Explorer, expand your project node, right-click **References**, and click **Add Reference**.
3. In **Reference Manager**, expand **Universal Windows** and click **Extensions**.
4. In the list of SDKs, select the check box next to **Microsoft Store Engagement SDK** and click **OK**.
5. In **Solution Explorer**, double-click MainPage.xaml to open the designer for the main page in the app.
6. Drag a **Button** from **Toolbox** to the page.
7. Double-click the button on the designer to open the code file and add an event handler for the **Click** event.  
8. Replace the entire contents of the code file with the following code.

  ```CSharp
  using System;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls;
  using Windows.UI.Xaml.Media;
  using System.Threading.Tasks;
  using Windows.UI;
  using Windows.UI.Core;

  // Namespace for A/B testing.
  using Microsoft.Services.Store.Engagement;

  namespace SampleExperiment
  {  
    public sealed partial class MainPage : Page
    {
        private readonly ExperimentClient experiment;
        private ExperimentVariation variation;

        // Assign this variable to your API key from Dev Center. The API key
        // shown below is for example purposes only.
        private string apiKey = "F48AC670-4472-4387-AB7D-D65B095153FB";    

        public MainPage()
        {
            this.InitializeComponent();

            // Initialize the ExperimentClient for A/B testing.
            experiment = new ExperimentClient(apiKey);

            // Because this call is not awaited, execution of the current method
            // continues before the call is completed.
            #pragma warning disable CS4014
            Initialize();
            #pragma warning restore CS4014
        }

        private async Task Initialize()
        {
            // Get the current cached variation assignment for the experiment.
            ExperimentVariationResult result = await experiment.GetVariationAsync();
            variation = result.Variation;

            // Check whether the cached variation assignment needs to be refreshed.
            // If so, then refresh it.
            if (result.ErrorCode != EngagementErrorCode.Success || result.Variation.NeedsRefresh)
            {
                result = await experiment.RefreshVariationAsync();

                // If the call succeeds, use the new result. Otherwise, use the cached value.
                if (result.ErrorCode == EngagementErrorCode.Success)
                {
                    variation = result.Variation;
                }
            }

            // Get settings named "buttonText", "r", "g", and "b" from the variation
            // assignment. If no variation assignment is available, the settings default
            // to "Grey button" for the button text and grey RGB value for the button color.
            var buttonText = variation.GetString("buttonText", "Grey Button");
            var r = (byte)variation.GetInteger("r", 128);
            var g = (byte)variation.GetInteger("g", 128);
            var b = (byte)variation.GetInteger("b", 128);

            // Assign button text and color.
            await button.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    button.Background = new SolidColorBrush(Color.FromArgb(255, r, g, b));
                    button.Content = buttonText;
                    button.Visibility = Visibility.Visible;
                });

            // Log the view event named "userViewedButton" to Dev Center.
            StoreServicesCustomEvents.Log("userViewedButton", variation);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Log the conversion event named "userClickedButton" to Dev Center.
            StoreServicesCustomEvents.Log("userClickedButton", variation);
        }
     }
  }
  ```
9. In the following line of code, assign the *apiKey* variable to the API key you obtained from the Dev Center dashboard in the previous section. The API key shown below is for example purposes only.
```CSharp
private string apiKey = "F48AC670-4472-4387-AB7D-D65B095153FB";
```
10. Save the code file and build the project.

## Run the app to gather experiment data

1. Run the **SampleExperiment** app you created in the previous section.
2. Confirm that you see either a grey or blue button. Click the button and then close the app.
3. Repeat the above steps several times on the same computer to confirm that your app shows the same button color.

## Review the results and complete the experiment

Wait at least several hours after completing the previous section, and then follow these steps to review the results of your experiment and complete the experiment.

> **Note** As soon as you activate an experiment, Dev Center immediately starts collecting data from any apps that are instrumented to log data for your experiment. However, it can take several hours for experiment data to appear in the dashboard.

1. In Dev Center, return to the **Experimentation** page for your app.
2. In the **Experiments** section, click the **Active** filter and then click **Optimize Button Clicks** to go to the page for this experiment.
3. Confirm that the results shown in the **Results summary** and **Results details** sections matches what you expect to see. For more details about these sections, see [Manage your experiment in the Dev Center dashboard](manage-your-experiment.md#review-the-results-of-your-experiment).

  >**Note** Dev Center reports only the first conversion event for each user in a 24-hour time period. If a user triggers multiple conversion events in your app within a 24-hour period, only the first conversion event is reported. This is intended to help prevent a single user with many conversion events from skewing the experiment results for a sample group of users.

4. Now you are ready to end the experiment. In the **Results summary** section, in the **Variation B** column, click **Switch**. This switches all users of your app to the blue button.
5. Click **OK** to confirm that you want to end the experiment.
6. Run the **SampleExperiment** app you created in the previous section.
7. Confirm that you see a blue button. Note that it may take up to two minutes for your app to receive an updated variation assignment.

## Related topics

  * [Define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md)
  * [Code your app for experimentation](code-your-experiment-in-your-app.md)
  * [Manage your experiment in the Dev Center dashboard](manage-your-experiment.md)
  * [Run app experiments with A/B testing](run-app-experiments-with-a-b-testing.md)


<!--HONumber=Mar16_HO5-->


