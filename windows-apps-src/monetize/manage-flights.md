---
author: mcleanbyron
ms.assetid: 37F2C162-4910-4336-BEED-8536C88DCA65
description: Use these methods in the Windows Store submission API to manage package flights for apps that are registered to your Windows Dev Center account.
title: Manage package flights using the Windows Store submission API
---

# Manage package flights using the Windows Store submission API




Use the following methods in the Windows Store submission API to manage package flights for apps that are registered to your Windows Dev Center account. For an introduction to the Windows Store submission API, including prerequisites for using the API, see [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md).

>**Note**&nbsp;&nbsp;These methods can only be used for Windows Dev Center accounts that have been given permission to use the Windows Store submission API. Not all accounts have this permission enabled. These methods can only be used to get, create, or delete package flights. To create submissions for package flights, see the methods in [Manage package flight submissions](manage-flight-submissions.md).

| Method        | URI    | Description                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` | Gets data for a package flight for an app that is registered to your Windows Dev Center account. For more information, see [Get a package flight](get-a-flight.md). |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights``` | Creates a new package flight. For more information, see [Create a package flight](create-a-flight.md).|
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` | Deletes a package flight. For more information, see [Delete a package flight](delete-a-flight.md). |


## Prerequisites

If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API before trying to use any of these methods.

## Related topics

* [Create and manage submissions using Windows Store services](create-and-manage-submissions-using-windows-store-services.md)
* [Manage package flight submissions](manage-flight-submissions.md)
