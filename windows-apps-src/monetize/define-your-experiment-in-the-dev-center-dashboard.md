---
Description: Before you can run an experiment in your Universal Windows Platform (UWP) app with A/B testing, you must define your experiment in the Dev Center dashboard.
title: Define your experiment in the Dev Center dashboard
ms.assetid: 675F2ADE-0D4B-41EB-AA4E-56B9C8F32C41
---

# Define your experiment in the Dev Center dashboard

To run an experiment in your Universal Windows Platform (UWP) app with A/B testing, start by defining your experiment in the Dev Center dashboard.

The following sections describe the general process to define an experiment in the dashboard. For a walkthrough that demonstrates the end-to-end process of creating and running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).

## Get an API key

To get started, go to the **Experimentation** page of the Dev Center dashboard and get an *API key* for your experiment.

An API key is a unique ID that associates your app with an experiment in your Dev Center account. Each experiment is associated with exactly one API key. However, an app can have multiple API keys, and each API key can be associated with multiple experiments. You can use API keys to help differentiate between different sets of experiments. For example, you might have one set of experiments that you release to testers in your organization and another set of experiments that you release only to external users of your app.

You must use this API key to connect with the A/B testing service in your app code. For more information, see [Code your app for experimentation](code-your-experiment-in-your-app.md).

1. Sign in to the [Dev Center dashboard](https://dev.windows.com/overview).
2. Under **Your apps**, select the app for which you want to create an experiment.
3. In the navigation pane, select **Services** and then select **Experimentation**.
4. The **API keys** section provides a default API key for your app that is named **API key #1**. If you want to use this key, optionally type a friendly name for this key and copy it to use in your app code. To generate a new API key, select **New API key** and enter a friendly name for the API key.

## Create an experiment

Next, create a new experiment and define the goals for the experiment.

1. In the **Experiments** section, click the **New experiment** button.
2. In the **API key name** section, choose the API key you want to associate with this experiment. If you have only one API key, that API key will be selected by default.
3. In the **Experiment name** field, type a name that you can use to easily identify the experiment. After you create an experiment, this name appears in the list of draft, active, and completed experiments on the **Experimentation** page.
4. If you want to create a test experiment, click the **Test experiment** check box. The difference between test experiments and regular experiments is that only test experiments can be changed after they are activated.

  Test experiments are intended to help you test all the variations on a client device before you release your experiment to customers. To make sure that a variation is served to clients as expected, you can activate a test experiment with 100% distribution allocated to one variation and 0% allocated to other variations. After you verify this variation, you can repeat the process for other variations.
  > **Note**  Check this box only if you are creating a test experiment to validate parameters through internal testing. Do not check this box if you are creating an experiment that you will release to customers.

5. In the **View event name** field, type the name of the *view event* for your experiment. The view event is an arbitrary string that represents an activity when the user starts viewing a variation that is part of your experiment. Your app code will send this view event string to Dev Center when the user starts viewing a variation. For more information, see [Code your app for experimentation](code-your-experiment-in-your-app.md).
6. In the **Goals and conversion events** section, define at least one goal for your experiment:
  * In the **Goal name** field, type a descriptive name for your goal. After you run an experiment, this name appears in the results summary for the experiment.
  * In the **Conversion event name** field, type the name of the *conversion event* for this goal. A conversion event is an arbitrary string that represents an objective for this goal. Your app code will send this conversion event string to Dev Center when the user reaches an objective. For more information, see [Code your app for experimentation](code-your-experiment-in-your-app.md).
  * In the **Objective** field, choose **Maximize** or **Minimize**, depending on whether you want to maximize or minimize the occurrences of the conversion event. This information is used in the results summary for the experiment.

  >**Note** Dev Center reports only the first conversion event for each user view in a 24-hour time period. If a user triggers multiple conversion events in your app within a 24-hour period, only the first conversion event is reported. This is intended to help prevent a single user from skewing the experiment results for a sample group of users when the goal is to maximize the number of users who perform a conversion.

## Define the variations and settings for the experiment

Next, define the variations and settings for your experiment.

* A *variation* is a collection of one or more settings that you are testing in your experiment. Every experiment must have at least one setting and two variations (including the control). An experiment can have up to five variations.
* A *setting* is a value that your app uses to initialize a program variable. During the experiment, the value of the setting changes from variation to variation. After you end the experiment, the setting is assigned the value from the variation that you choose release to all users of your app. Settings can have the following types: string, Boolean, double, and integer.

To define the variations and settings for your experiment:
1. In the **Variations and settings** section, you should see two default variations, **Variation A (Control)** and **Variation B**. If you want more variations, click **Add variation**. Optionally, you can rename each variation.
2. Next, create the settings for your variations. Click **Add setting** to create each new setting, and type the setting name and the value of the setting in each variation.
3. By default, variations are distributed equally to your app users. If you want to choose a specific distribution percentage, clear the **Distribute equally** check box and type the percentages in the **Distribution (%)** row.

## Save your experiment

When you finish entering the required fields for your experiment, click **Save** to save your experiment.

> **Important** After you save an experiment, you can no longer change the API key for the experiment, even if you haven't yet activated the experiment.

If you are satisfied with the parameters of your experiment and you are ready to activate it so you can start collecting experiment data from your app, click **Activate**. When the experiment is active, your app can retrieve variation settings and report view and conversion events to Dev Center.

> **Important**  After you activate an experiment, you can no longer modify the experiment parameters unless it is a test experiment (you clicked the **Test experiment** check box when you created the experiment). We recommend that you code the experiment in your app before activating your experiment.

## Next steps

After you define your experiment in the Dev Center dashboard, you are ready for the following steps:
1. [Code your app for experimentation](code-your-experiment-in-your-app.md). Use an API in the Microsoft Store Engagement and Monetization SDK to get variation settings for the experiment, use this data to modify the behavior of the feature you are testing, and send view event and conversion events to Dev Center.
2. [Run and manage your experiment in the Dev Center dashboard](manage-your-experiment.md). Use the dashboard to review the results of the experiment and complete the experiment.

## Related topics

  * [Code your app for experimentation](code-your-experiment-in-your-app.md)
  * [Manage your experiment in the Dev Center dashboard](manage-your-experiment.md)
  * [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md)
  * [Run app experiments with A/B testing](run-app-experiments-with-a-b-testing.md)


<!--HONumber=Mar16_HO5-->


