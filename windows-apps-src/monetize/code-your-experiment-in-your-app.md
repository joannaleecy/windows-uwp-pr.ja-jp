---
Description: After you define your experiment in the Dev Center dashboard, you are ready to code the experiment in your app.
title: Code your app for experimentation
ms.assetid: 6A5063E1-28CD-4087-A4FA-FBB511E9CED5
---

# Code your app for experimentation

After you [define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md), you are ready to update the code in your Universal Windows Platform (UWP) app to get variation data for the experiment, use this data to modify the behavior of the feature you are testing, and log view event and conversion events to Dev Center.

The following sections describe the general process of getting variations for your experiment and logging events to Dev Center. For a walkthrough that demonstrates the end-to-end process of creating and running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).

## Configure your project

To get started, install the Microsoft Store Engagement and Monetization SDK on your development computer and add the necessary references to your project.

1. Install the [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk).
2. Open your project in Visual Studio.
3. In Solution Explorer, expand your project node, right-click **References**, and click **Add Reference**.
3. In **Reference Manager**, expand **Universal Windows** and click **Extensions**.
4. In the list of SDKs, select the check box next to **Microsoft Store Engagement SDK** and click **OK**.

## Add code to get variation settings

In your project, locate the code for the feature that you want to modify in your experiment. Add code that retrieves settings for a variation, and use this data to modify the behavior of the feature you are testing. The specific code you need will depend on your app, but here are the general steps. For complete code example, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).

1. Declare an [ExperimentClient](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.aspx) object that you will use to retrieve variations for your experiment and an [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) object that represents the current variation assignment.
```
private readonly ExperimentClient experiment;
private ExperimentVariation variation;
```

2. Initialize the [ExperimentClient](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.aspx) object, and pass the API key that you retrieved from the **Experiments** page of the dashboard to the constructor. For more information about the API key, see [Define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md#generate-an-api-key). The API key shown below is for example purposes only.
```
experiment = new ExperimentClient("F48AC670-4472-4387-AB7D-D65B095153FB");
```

3. Get the current cached variation assignment for your experiment by calling the [GetVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.getvariationasync.aspx) method. This method returns an [ExperimentVariationResult](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariationresult.aspx) object that provides access to the variation assignment via the [Variation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariationresult.variation.aspx) property.
```
ExperimentVariationResult result = await experiment.GetVariationAsync();
variation = result.Variation;
```

4. Check the [NeedsRefresh](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.needsrefresh.aspx) property to determine whether the cached variation assignment needs to be refreshed. If it does need to be refreshed, call the [RefreshVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.refreshvariationasync.aspx) method to check for an updated variation assignment from the server and refresh the local cached variation.
```
// Check whether the cached variation assignment needs to be refreshed.
// If so, then refresh it.
if (result.ErrorCode != EngagementErrorCode.Success || result.Variation.NeedsRefresh)
{
      result = await experiment.RefreshVariationAsync();

      // If the call succeeds, use the new result. Otherwise, use the
      // cached value we retrieved earlier.
      if (result.ErrorCode == EngagementErrorCode.Success)
      {
          variation = result.Variation;
      }
}
```

5. Use the [GetBoolean](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getboolean.aspx), [GetDouble](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getdouble.aspx), [GetInteger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getinteger.aspx), or [GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getstring.aspx) methods of the [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) object to get the settings for the variation assignment. In each method, the first parameter is the name of the setting that you want to retrieve (as you entered it in your Dev Center dashboard). The second parameter is the default value that the method should return if it is not able to retrieve the specified value from Dev Center (for example, if there is no network connectivity), and a cached version of the variation is not available.

  The following example uses [GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getstring.aspx) to get a setting named *buttonText* and specifies a default setting value of **Grey Button**.
```
var buttonText = currentVariation.GetString("buttonText", "Grey Button");
```
4. In your code, use the setting values to modify the behavior of the feature you are testing. For example, the following code assigns the *buttonText* value to the content of a button.
```
button.Content = buttonText;
```

## Add code to log view and conversion events to Dev Center

Next, add code that logs view and conversion events to the A/B testing service in Dev Center. Your code should log the view event when the user starts viewing a variation that is part of your experiment, and it should log the conversion event when the user reaches an objective for your experiment.

The specific code you need will depend on your app, but here are the general steps. For complete code example, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).

1. In code that runs when the user starts viewing a variation, call the static [Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.log.aspx) method of the [StoreServicesCustomEvents](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.aspx) object. Pass the name of the view event that you defined in your experiment on your Dev Center dashboard and the [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) object that represents the current variation assignment (this object provides context about the event to Dev Center). The following example logs a view event named **userViewedButton**.
```
StoreServicesCustomEvents.Log("userViewedButton", variation);
```
2. In code that runs when the user reaches an objective for one of the goals of the experiment, call the [Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.log.aspx) method again and pass the name of a conversion event that you defined in your experiment and the [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) object. The following example logs a conversion event named **userClickedButton**.
```
StoreServicesCustomEvents.Log("userClickedButton", variation);
```

## Next steps

After you define your experiment in the Dev Center dashboard and code the experiment in your app, you are ready to [run and manage your experiment in the Dev Center dashboard](manage-your-experiment.md).

## Related topics

  * [Define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md)
  * [Manage your experiment in the Dev Center dashboard](manage-your-experiment.md)
  * [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md)
  * [Run app experiments with A/B testing](run-app-experiments-with-a-b-testing.md)


<!--HONumber=Mar16_HO5-->


