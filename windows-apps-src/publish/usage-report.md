---
Description: The Usage report in the Windows Dev Center dashboard lets you see how customers are using your app.
title: Usage report
ms.assetid: 5F0E7F94-D121-4AD3-A6E5-9C0DEC437BD3
---

# Usage report


> **Important**  The **Usage** report only provides data if you have activated the [Visual Studio Application Insights SDK](http://go.microsoft.com/fwlink/?LinkId=615086) in your app (or enable it by checking the box for “Show telemetry in the Windows Dev Center” when building your package). You also must submit the app in the unified Dev Center dashboard before data will be shown in this report, and you must have app usage telemetry enabled in your Account settings.

The **Usage** report in the Windows Dev Center dashboard lets you see how customers are using your app. You can view this data in your dashboard, or [download the report](download-analytic-reports.md) to view offline.

This report provides a high-level look at your app's usage. If you have associated an Azure subscription with the Visual Studio Application Insights SDK for your app, you can get more detailed app usage telemetry info in the Azure Portal. Links to your app's Azure Portal reports will be provided near the top of this report.

Note that the Microsoft account associated with your developer account must be associated with the Azure subscription used for Application Insights. If you're not using the same Microsoft account in both places, you'll need to log into the Azure Management Portal, then add the Microsoft account associated with your developer account as a Service Administrator, Co-Administrator, or in the Owner role for this subscription.

## Apply filters


Near the top of the page, you can expand **Apply filters** to filter all of the data on this page by date range and/or by product group (related OS versions).

-   **Date**: The default filter is **Last 72 hours**, but you can expand this up to **Last 12 months**.
-   **Product groups**: The default setting is **All**. If your app includes more than one product group, you can choose a specific one here.

The info in all of the charts listed below will reflect the period of time selected in **Apply filters**. By default this will include data for all of your supported product groups, unless you've used the **Apply filters** section to filter for only one.

## Total user sessions


The **Total user sessions** chart shows the number of daily user sessions for your app over the selected period of time.

Each user session represents a customer launching and using your app over a period of time. This chart does not track unique users (that is, multiple user sessions shown here could be from the same customer).

## Active users


The **Active users** chart shows the number of customers who used your app on a specific day during the selected period of time.

Each active user represents a customer who used your app that day. This chart does not track unique user sessions (that is, a customer is represented in this chart whether they used your app just once or multiple times that day).

## Average user session length in seconds


The **Average user session length in seconds** chart shows average length of time that a customer used your app on a specific day during the selected period of time.

You can also click **Average time between sessions in seconds** to have this chart display the average time that elapses between separate sessions of using your app over the selected period of time.

## Custom events over last 30 days


The **Custom events over last 30 days** chart shows the total occurrences for any custom events that you have defined for your app. This may include multiple occurrences for the same customer.

## Page views over last 30 days


The **Page views over last 30 days** chart shows the total number of views for specific pages in your app. This may include multiple views from the same customer.

 

 






<!--HONumber=Mar16_HO1-->


