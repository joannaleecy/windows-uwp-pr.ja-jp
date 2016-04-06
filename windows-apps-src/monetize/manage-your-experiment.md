---
Description: After you define your experiment in the Dev Center dashboard and code your experiment in your app, you are ready to active your experiment and use the Dev Center dashboard to review the results of your experiment.
title: Manage your experiment in the Dev Center dashboard
ms.assetid: D48EE0B4-47F2-455C-8FB9-630769AC5ACE
---

# Manage your experiment in the Dev Center dashboard

After you [define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md) and [code your app for experimentation](code-your-experiment-in-your-app.md), you are ready to activate your experiment and use the Dev Center dashboard to review the results of your experiment. After you have obtained all the data you need, you can end your experiment and choose whether to keep using the control variation settings in all your apps or switch to using the settings in one of your variations.

> **Note** When you activate an experiment, Dev Center immediately starts collecting data from any apps that are instrumented to log data for your experiment. However, it can take several hours for experiment data to appear in the dashboard.

For a walkthrough that demonstrates the end-to-end process of creating and running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).

## Activate your experiment

When you are satisfied with the parameters of your experiment on the dashboard and you have updated your app code, you are ready to activate your experiment so you can start collecting experiment data from your app. When the experiment is active, your app can retrieve variation settings and report view and conversion events to Dev Center.

1. Sign in to the [Dev Center dashboard](https://dev.windows.com/overview).
2. Under **Your apps**, select the app with the experiment that you want to activate.
3. In the navigation pane, select **Services** and then select **Experimentation**.
4. The **Experiments** section lists the draft, active, and completed experiments for the current app. Click the **Draft** filter and then click **Activate** for the experiment you want to activate.

> **Important**  After you activate an experiment, you can no longer modify the experiment parameters unless it is a test experiment (you clicked the **Test experiment** check box when you created the experiment). We recommend that you code the experiment in your app before activating your experiment.


## Review the results of your experiment

1. In Dev Center, return to the **Experimentation** page for your app.
2. In the **Experiments** section, click the **Active** filter and then click the name of your active experiment to go to the experiment page.
3. For an active or completed experiment, the first two sections in this page provide the results of your experiment:
  * The **Results summary** section lists your experiment goals and the conversion rate percentage for each variation.
  * The **Results details** section provides more details for each goal in your experiment, including the views, conversions, conversion rate, delta %, confidence, and significance. The *confidence* is a statistical measure of the reliability of an estimate, which calculates the margin of error. The *significance* is a statistical measure, based on sample size, to determine the likelihood that a result is not due to chance, but is instead attributed to a specific cause.

  >**Note** Dev Center reports only the first conversion event for each user in a 24-hour time period. If a user triggers multiple conversion events in your app within a 24-hour period, only the first conversion event is reported. This is intended to help prevent a single user with many conversion events from skewing the experiment results for a sample group of users.


## Complete your experiment

1. In the dashboard, return to your experiment page. For instructions, see the previous section.
2. In the **Results summary** section, do one of the following:
  * If you want to end the experiment and continue using the settings in the control variation in your app, click **Keep**.
  * If you want to end the experiment but switch to using the settings in a different variation in your app, click **Switch** under the variation to which you want to switch.
3. Click **OK** to confirm that you want to end the experiment.


## Related topics

  * [Define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md)
  * [Code your app for experimentation](code-your-experiment-in-your-app.md)
  * [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md)
  * [Run app experiments with A/B testing](run-app-experiments-with-a-b-testing.md)


<!--HONumber=Mar16_HO5-->


