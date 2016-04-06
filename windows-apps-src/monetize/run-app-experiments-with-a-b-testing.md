---
Description: You can use the Windows Dev Center dashboard to run experiments for your Universal Windows Platform (UWP) apps with A/B testing.
title: Run app experiments with A/B testing
ms.assetid: 790B4B37-C72D-4CEA-97AF-D226B2216DCC
---

# Run app experiments with A/B testing

You can use the Windows Dev Center dashboard to run experiments for your Universal Windows Platform (UWP) apps with A/B testing.

In an A/B test, you experiment with program variable assignments in your apps through Dev Center. By building app logic around A/B testable program variables, you can enable variations of your app for randomized segments of your user audience. The goal of your A/B test is to identify a variation that is likely to earn you improved conversion rates (for example, more in-app purchases).

After you have identified a variation that best meets your business goals, you can immediately end the experiment and enable that variation for your entire user audience from the Dev Center dashboard, without having to republish your app.

## Create and run an A/B test

To create and run an A/B test, follow these steps:

1. [Define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md). Each experiment consists of:
  * A *view event* that indicates when the user starts viewing a variation that is part of your experiment.
  * One or more goals with *conversion events* that indicate when an objective has been reached.
  * One or more *variations* that define the settings used by your experiment.
2. [Code your app for experimentation](code-your-experiment-in-your-app.md). Use an API in the Microsoft Store Engagement and Monetization SDK to get variation settings for the experiment, use this data to modify the behavior of the feature you are testing, and send view event and conversion events to Dev Center.
3. [Run and manage your experiment in the Dev Center dashboard](manage-your-experiment.md). Use the dashboard to review the results of the experiment and complete the experiment.

For a walkthrough that demonstrates the end-to-end process, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).

## Requirements

A/B testing in Windows Dev Center is supported only for UWP apps.

Before you can run experiments with A/B testing, you must set up your development computer:

* Follow the instructions [here](../get-started/get-set-up.md) to set up your development computer for UWP development.
* Install the [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk). In addition to the API for experiments, this SDK also provides APIs for other features such as displaying ads and directing your customers to Feedback Hub to collect feedback on your app. For more information about this SDK, see [Monetize your app with the Store Engagement and Monetization SDK](monetize-your-app-with-the-microsoft-store-engagement-and-monetization-sdk.md).

## Best practices

For the most useful results, we recommend that you follow these recommendations when running experiments with A/B testing:

* Consider running experiments with only two variations with a randomized 50/50 split distribution for variation assignments.
* Run experiments for at least 2 – 4 weeks to gather sufficient data that is statistically significant and actionable.

## Related topics

* [Define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md)
* [Code your app for experimentation](code-your-experiment-in-your-app.md)
* [Manage your experiment in the Dev Center dashboard](manage-your-experiment.md)
* [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md)


<!--HONumber=Mar16_HO5-->


