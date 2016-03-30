---
xxxxx: Xxxxxx xxx xxxxxxx xx xxx xxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxx xxx xxxxxxx xxxxxxxx xx xxxxx XXX xxxx, xxx xxx xx xxxxxxx xxxxx xxxxxxxx.
xx.xxxxxxx: YXYYXYXY-XYXX-YXXY-YYXX-XYYYXYYYXYXY
---

# Xxxxxx xxx xxxxxxx xx xxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxx xxx xx xxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxx xxx xxxxxxx xxxxxxxx xx xxxxx XXX xxxx, xxx xxx xx xxxxxxx xxxxx xxxxxxxx.

## Xxxxxx x xxx xxx xxxxxxx xxxxxxxx xxxxxxx


Xx xxxx xxx-xx, xx'xx xxxxxx xxxxxxxxxx xx xxx xxxxxxxx xxx xxxxxxxxxx.

-   Xx Xxxxxxxxx Xxxxxx Xxxxxx YYYY, xxxxxx x xxx XXX xxx xxxxxxx xxx xxxx xx XxxXxxxxxxXxxxxxxx. (Xx xxx **Xxx Xxxxxxx** xxxxxx xxx, xxxxxx **Xxxxxxxxx &xx; Xxxxx Xxxxxxxxx &xx; Xxxxxx X\# &xx; Xxxxxxx &xx; Xxxxxxx Xxxxxxxxx &xx; Xxxxx xxx (Xxxxxxx Xxxxxxxxx)**). Xxxx xxxx xx xxx xxx xxxx xxxxxxxx xxx xxx xxxxxxx.

## Xxx xx xxx xxxxxxx xxxxxxxxx xx xxxxxxx.xxxxxxxxxxxx


Xx xxx XxxXxxxxxxXxxxxxxx xxxxxxx'x Xxxxxxx.xxxxxxxxxxxx xxxx, xxx xxx xxxxxxxxx XxxXxxxxxx xxxxxxxxx xx xxx **&xx;Xxxxxxxxxxx&xx;** xxxxxxx. Xxxx xxxxxxx xxxxxxxxxx xxx `com.Microsoft.Inventory` xxxxxxx xxx xx xxxx xxxxxxxxxx xxxx xxx xx xx xxx xxxxxxx xxxxxxxx. Xxx xxxxxx xxxxxxx xxxx xx xxxxxxxxxxx xx x xxxxxxxxxx xxxx. Xxx xxx xxxxxxx xxx xxxxxxx xxx xxxxxxx xx xxxxx xxxx. Xx xxxxxxxxx xxxxx x xxxxxxx xxxxxx xxxx xxxxx xxx xxx xxxxxxx xxxx.

``` syntax
... 
<Applications>
    <Application Id="App"
      Executable="$targetnametoken$.exe"
      EntryPoint="AppServiceProvider.App">
      <Extensions>
        <uap:Extension Category="windows.appService" EntryPoint="MyAppService.Inventory">
          <uap:AppService Name="com.microsoft.inventory"/>
        </uap:Extension>
      </Extensions>
      ...
    </Application>
</Applications>
```

Xxx **Xxxxxxxx** xxxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxx xx xx xxx xxxxxxx xxxxxxxx.

Xxx **XxxxxXxxxx** xxxxxxxxx xxxxxxxxxx xxx xxxxx xxxx xxxxxxxxxx xxx xxxxxxx, xxxxx xx'xx xxxxxxxxx xxxx.

## Xxxxxx xxx xxx xxxxxxx


1.  Xx xxx xxxxxxx xx xxxxxxxxxxx xx x xxxxxxxxxx xxxx. Xxxx xxxxxxx x xxxxxxxxxx xxxxxxxxxxx xx xxxxxx xx xxx xxxxxxx xx xxxxxxx xxxxxxxxxxx xx xxxxxxx xxxxx xxxxxx xxx xxxxxx. Xxx x xxx Xxxxxxx Xxxxxxx Xxxxxxxxx xxxxxxx xx xxx xxxxxxxx (**Xxxx &xx; Xxx &xx; Xxx Xxxxxxx**) xxxxx XxXxxXxxxxxx. (Xx xxx **Xxx Xxx Xxxxxxx** xxxxxx xxx, xxxxxx **Xxxxxxxxx &xx; Xxxxx Xxxxxxxxx &xx; Xxxxxx X\# &xx; Xxxxxxx &xx; Xxxxxxx Xxxxxxxxx &xx; Xxxxxxx Xxxxxxx Xxxxxxxxx (Xxxxxxx Xxxxxxxxx)**
2.  Xx xxx XxxXxxxxxxXxxxxxxx xxxxxxx, xxx x xxxxxxxxx xx xxx XxXxxXxxxxxx xxxxxxx.
3.  Xx xxx XxxxxXxxxxxx xxxxxxx, xxx xxx xxxxxxxxx **xxxxx** xxxxxxxxxx xx xxx xxx xx XxxxxY.xx:
    ```cs
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    ```

4.  Xxxxxxx xxx xxxx xxxx xxx **XxxxxY** xxxx x xxx xxxxxxxxxx xxxx xxxxx xxxxx **Xxxxxxxxx**:

    ```cs
    public sealed class Inventory : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
        private String[] inventoryItems = new string[] { "Robot vacuum", "Chair" };
        private double[] inventoryPrices = new double[] { 129.99, 88.99 };

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.backgroundTaskDeferral = taskInstance.GetDeferral(); // Get a deferral so that the service isn&#39;t terminated.
            taskInstance.Canceled += OnTaskCanceled; // Associate a cancellation handler with the background task.

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (this.backgroundTaskDeferral != null)
            {
                // Complete the service deferral.
                this.backgroundTaskDeferral.Complete();
            }
        }
    }
    ```

    Xxxx xxxxx xx xxxxx xxx xxx xxxxxxx xxxx xx xxx xxxx.

    **Xxx()** xx xxxxxx xxxx xxx xxxxxxxxxx xxxx xx xxxxxxx. Xxxxxxx xxxxxxxxxx xxxxx xxx xxxxxxxxxx xxxxx **Xxx** xxxxxxxxx, xxx xxxx xxxxx x xxxxxxxx xx xxxx xxx xxxxxxxxxx xxxx xxxx xxxx xx xx xxxxx xxxxxxxx.

    **XxXxxxXxxxxxxx()** xx xxxxxx xxxx xxx xxxx xx xxxxxxxx. Xxx xxxx xx xxxxxxxxx xxxx xxx xxxxxx xxx xxxxxxxx xxx [**XxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn921704), xxx xxxxxx xxx xx xxxxxxxxx, xxx XX xx xxxx xxxx xx xxxxxx, xx xxx XX xxxx xxx xx xxxxxxxxx xx xxx xxx xxxx.

## Xxxxx xxx xxxx xxx xxx xxx xxxxxxx


**XxXxxxxxxxxXxxxxxxx()** xx xxxxx xxx xxxx xxx xxx xxx xxxxxxx xxxx. Xxxxxxx xxx xxxx **XxXxxxxxxxxXxxxxxxx()** xx XxXxxXxxxxxx'x XxxxxY.xx xxxx xxx xxxx xxxx xxxx xxxxxxx. Xxxx xxxx xxxx xx xxxxx xxx xx xxxxxxxxx xxxx xxx xxxxxx xx, xxxxx xxxx x xxxxxxx xxxxxx, xx xxx xxxxxxx xx xxxxxxxx xxx xxxx xxx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxxx xxxx. Xxxxx xxxxxxxx xxxx xxx xxxx xxxxxxx xxx xxxxxxx.

```cs
private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    // Get a deferral because we use an awaitable API below to respond to the message
    // and we don&#39;t want this call to get cancelled while we are waiting.
    var messageDeferral = args.GetDeferral();

    ValueSet message = args.Request.Message;
    ValueSet returnData = new ValueSet();

    string command = message["Command"] as string;
    int? inventoryIndex = message["ID"] as int?;

    if ( inventoryIndex.HasValue &amp;&amp;
         inventoryIndex.Value >= 0 &amp;&amp;
         inventoryIndex.Value < inventoryItems.GetLength(0))
    {
        switch (command)
        {
            case "Price":
            {
                returnData.Add("Result", inventoryPrices[inventoryIndex.Value]);
                returnData.Add("Status", "OK");
                break;
            }

            case "Item":
            {
                returnData.Add("Result", inventoryItems[inventoryIndex.Value]);
                returnData.Add("Status", "OK");
                break;
            }

            default:
            {
                returnData.Add("Status", "Fail: unknown command");
                break;
            }
        }
    }
    else
    {
        returnData.Add("Status", "Fail: Index out of range");
    }

    await args.Request.SendResponseAsync(returnData); // Return the data to the caller.
    messageDeferral.Complete(); // Complete the deferral so that the platform knows that we&#39;re done responding to the app service call.
}
```

Xxxx xxxx **XxXxxxxxxxxXxxxxxxx()** xx **xxxxx** xxxxxxx xx xxxx xx xxxxxxxxx xxxxxx xxxx xx [**XxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn921722) xx xxxx xxxxxxx.

X xxxxxxxx xx xxxxx xx xxxx xxx xxxxxxx xxx xxx **xxxxx** xxxxxxx xx xxx XxXxxxxxxXxxxxxxx xxxxxxx. Xx xxxxxxx xxxx xxx xxxx xx XxXxxxxxxXxxxxxxx xxxx xxx xxxxxxxx xxxxx xx xx xxxx xxxxxxxxxx xxx xxxxxxx. [
            **XxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn921722) xx xxxx xx xxxx x xxxxxxxx xxxxxxxxx xxx xxxxxxxxxx. **XxxxXxxxxxxxXxxxx** xxxx xxx xxxxxx xxx xxxxxxxxxx xx xxx xxxx. Xx xx xxx xxxxxxxxxx xx xxx xxxxxxxx xxxx xxxxxxx xx [**XxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn921712) xxxx XxXxxxxxxXxxxxxxx xxx xxxxxxxxx.

Xxx xxxxxxxx xxx x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131) xx xxxxxxxx xxxxxxxxxxx. Xxx xxxx xx xxx xxxx xxx xxx xxxx xx xxxx xxxxxxx xx xxxxxx xxxxxxxxx. Xxxxx xxx xx xxxxxxxxxx xxxx xxx xxx xx xxx xx xxxx **XxxxxXxx**. Xxx xxxx xxxxxxxxx xxxxx xxx xxxxxx xxx xxxx xxx xx xxxxxx xxx xxxxxxxx xxx xxxx xxx xxxxxxx. Xxx xxxxxx xxxx xx xxxxxxx xxxx xxxx xxxxxxxx xx xxxx. Xx xxxx xxxxxxx, xx xxxx xxxxxx x xxx xxxxx "Xxxxxxx" xxxx xxx x xxxxx xxxx xxxxxxxxx xxxxxxx xx xxxx xxx xxx xxxxxxx xx xxxxxxx xxx xxxx xx xxx xxxxxxxxx xxxx xx xxx xxxxx. Xxx xxxxx xx xxx xxxxxxxxx xxxx xx xxxxxx xxxxx xxx "XX" xxx. Xxx xxxxxx xxxxx xx xxxxxx xxxxx xxx "Xxxxxx" xxx.

Xx [**XxxXxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn921703) xxxx xx xxxxxxxx xx xxx xxxxxx xx xxxxxxxx xxxxxxx xxx xxxx xx xxx xxx xxxxxxx xxxxxxxxx xx xxxxxx. Xx xxxxxxx xx xxx xxx xxxx xx xxx xxx xxxxxxx xxxxx xxxx xx xx xxx XX xxxxxx xxx xxxxxxx xxxxxxxx, xxxxxxxxx xxx xxxxxxxx, xxx xx xxxxx. Xxx xxx xxxxxx xxxxxxxxxx xxxxx xxxxxxxxxxx xxx xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131). Xx xxxx xxxxxxx, xx xxx x xxx xxxxx "Xxxxxx" xx xxxxxx xxxx xxxxxxxx xxxxx xxxxxxxxxxx xx xxx xxxxxx.

Xxx xxxx xx [**XxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn921722) xxxxxxx xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636131) xx xxx xxxxxx.

## Xxxxxx xxx xxxxxxx xxx xxx xxx xxx xxxxxxx xxxxxx xxxx


Xxx xxx xxxxxxx xxxxxxxx xxx xxxx xx xxxxxxxx xxxxxx xxx xxx xxxx xx xxxx x xxxxxx. Xxx xxxx xxxx xxxx xxx xxxxxxx xxxxxx xxxx xx xxx xxx xxxxxxx xxx xx xxxxx xx xxxx xx.

-   Xxx xxx xx xxx xxx xxxxxxx xxxxxx xxxx xx xxx xxx xxxxxxx xxxxxxxxxxx xx xx xxxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxx.Xxxxxxx.Xx.XxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224670) xxxx xxxxxx xxx **XxxXxxxxxxXxxxxxxx** xxxxxxx (xxx xxxxxxx, xxxx `public App()` xx Xxx.xxxx.xx) xxx xxxx xxx xxxxxx. Xx xxx XxxXxxxxxxXxxxxxxx xx Xxxxxxxxx Xxxxxx Xxxxxx, xxx xx xx xxx xxxxxxx xxxxxxx xx xxx Xxxxxxxx Xxxxxxxx xxxxxx xxx xxx xxx xxxxxxx.
-   Xxxxxxx xxx xx xxx xxx xxxxxxx xxxxxx xxxx xx xx xxxxxx xxx xxxxxxxx (**Xxxxx &xx; Xxxxxx xxxxxxxx**) xxx xxxx xxx xxxx xxxxxxx xxxx xx xxx xxxxxx xxxxxx (**Xxxx &xx; Xxxxxx**). Xxx xxxx xxxxxx xxx xxxxxxxx xxxxxxxxxxx xxxx xxx xxxxxx xx xxx xxxxxx xxxxxx xx xxxxxx xxx xxxxxxx xxxx. Xxx xxxxxxx, xx xxx xxxx xxxxxxx xxxx xxxxxxxx xx xxx xxxxxx xxxxxx xxx "YxxYYYYx-YxxY-YxYY-xxxY-YYxYYxYxxYxY\_Y.Y.Y.Y\_xYY\_\_xxYxxYYxxYYxx", xxx xxxxx xxxxxxx "Y.Y.Y.Y\_xYY\_\_" xxxxxxx "YxxYYYYx-YxxY-YxYY-xxxY-YYxYYxYxxYxY\_xxYxxYYxxYYxx" xx xxx xxxxxxx xxxxxx xxxx.

## Xxxxx x xxxxxx xx xxxx xxx xxx xxxxxxx


1.  Xxx x xxx xxxxx Xxxxxxx Xxxxxxxxx xxx xxxxxxx xx xxx xxxxxxxx (**Xxxx &xx; Xxx &xx; Xxx Xxxxxxx**) xxxxx XxxxxxXxx. (Xx xxx **Xxx Xxx Xxxxxxx** xxxxxx xxx, xxxxxx **Xxxxxxxxx &xx; Xxxxx xxxxxxxxx &xx; Xxxxxx X\# &xx; Xxxxxxx &xx; Xxxxxxx Xxxxxxxxx &xx; Xxxxx Xxx (Xxxxxxx Xxxxxxxxx)**).
2.  Xx xxx XxxxxxXxx xxxxxxx, xxx xxx xxxxxxxxx **xxxxx** xxxxxxxxx xx xxx xxx xx XxxxXxxx.xxxx.xx:
    ```cs
    >using Windows.ApplicationModel.AppService;
    ```

3.  Xxx x xxxx xxx xxx x xxxxxx xx XxxxXxxx.xxxx.
4.  Xxx x xxxxxx xxxxx xxxxxxx xxx xxx xxxxxx xxx xxx xxx xxxxxxx **xxxxx** xx xxx xxxxxx xxxxxxx'x xxxxxxxxx.
5.  Xxxxxxx xxx xxxx xx xxxx xxxxxx xxxxx xxxxxxx xxxx xxx xxxxxxxxx xxxx. Xx xxxx xx xxxxxxx xxx `inventoryService` xxxxx xxxxxxxxxxx.

   ```cs
   private AppServiceConnection inventoryService;
    private async void button_Click(object sender, RoutedEventArgs e)
    {
        // Add the connection.
        if (this.inventoryService == null)
        {
            this.inventoryService = new AppServiceConnection();

            // Here, we use the app service name defined in the app service provider&#39;s Package.appxmanifest file in the &lt;Extension&gt; section. 
            this.inventoryService.AppServiceName = "com.microsoft.inventory";

            // Use Windows.ApplicationModel.Package.Current.Id.FamilyName within the app service provider to get this value.
            this.inventoryService.PackageFamilyName = "replace with the package family name";

            var status = await this.inventoryService.OpenAsync();
            if (status != AppServiceConnectionStatus.Success)
            {
                button.Content = "Failed to connect";
                return;
            }
        }

        // Call the service.
        int idx = int.Parse(textBox.Text);
        var message = new ValueSet();
        message.Add("Command", "Item");
        message.Add("ID", idx);
        AppServiceResponse response = await this.inventoryService.SendMessageAsync(message);
        string result = "";

        if (response.Status == AppServiceResponseStatus.Success)
        {
            // Get the data  that the service sent  to us.
            if (response.Message["Status"] as string == "OK")
            {
                result = response.Message["Result"] as string;
            }
        }

        message.Clear();
        message.Add("Command", "Price");
        message.Add("ID", idx);
        response = await this.inventoryService.SendMessageAsync(message);

        if (response.Status == AppServiceResponseStatus.Success)
        {
            // Get the data that the service sent to us.
            if (response.Message["Status"] as string == "OK")
            {
                result += " : Price = " + response.Message["Result"] as string;
            }
        }

        button.Content = result;
    }
    ```

    Replace the package family name in the line `this.inventoryService.PackageFamilyName = "replace with the package family name";` with the package family name of the **AppServiceProvider** project that you obtained in \[Step 5: Deploy the service app and get the package family name\].

    The code first establishes a connection with the app service. The connection will remain open until you dispose **this.inventoryService**. The app service name must match the **AppService Name** attribute that you added to the AppServiceProvider project's Package.appxmanifest file. In this example, it is `<uap:AppService Name="com.microsoft.inventory"/>`.

    A [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) named **message** is created to specify the command that we want to send to the app service. The example app service expects a command to indicate which of two actions to take. We get the index from the textbox in the ClientApp, and then call the service with the "Item" command to get the description of the item. Then, we make the call with the "Price" command to get the item's price. The button text is set to the result.

    Because [**AppServiceResponseStatus**](https://msdn.microsoft.com/library/windows/apps/dn921724) only indicates whether the operating system was able to connect the call to the app service, we check the "Status" key in the [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) we receive from the app service to ensure that it was able to fulfill the request.

6.  In Visual Studio, set the ClientApp project to be the startup project in the Solution Explorer window and run the solution. Enter the number 1 into the text box and click the button. You should get "Chair : Price = 88.99" back from the service.

    ![sample app displaying chair price=88.99](images/appserviceclientapp.png)

If the app service call fails, check the following in the ClientApp:

1.  Verify that the package family name assigned to the inventory service connection matches the package family name of the AppServiceProvider app. See: **button\_Click()**`this.inventoryService.PackageFamilyName = "...";`).
2.  In **button\_Click()**, verify that the app service name that is assigned to the inventory service connection matches the app service name in the AppServiceProvider's Package.appxmanifest file. See: `this.inventoryService.AppServiceName = "com.microsoft.inventory";`.
3.  Ensure that the AppServiceProvider app has been deployed (In the Solution Explorer, right-click the solution and choose **Deploy**).

## Debug the app service


1.  Ensure that the entire solution is deployed before debugging because the app service provider app must be deployed before the service can be called. (In Visual Studio, **Build &gt; Deploy Solution**).
2.  In the Solution Explorer, right-click the AppServiceProvider project and choose **Properties**. From the **Debug** tab, change the **Start action** to **Do not launch, but debug my code when it starts**.
3.  In the MyAppService project, in the Class1.cs file, set a breakpoint in OnRequestReceived().
4.  Set the AppServiceProvider project to be the startup project and press F5.
5.  Start ClientApp from the Start menu (not from Visual Studio).
6.  Enter the number 1 into the text box and press the button. The debugger will stop in the app service call on the breakpoint in your app service.

## Debug the client


1.  Follow the instructions in the preceding step to debug the app service.
2.  Launch ClientApp from the Start menu.
3.  Attach the debugger to the ClientApp.exe process (not the ApplicationFrameHost.exe process). (In Visual Studio, choose **Debug &gt; Attach to Process...**.)
4.  In the ClientApp project, set a breakpoint in **button\_Click()**.
5.  The breakpoints in both the client and the app service will now be hit when you enter the number 1 into the text box of the ClientApp and click the button.

## Remarks


This example provides a simple introduction to creating an app service and calling it from another app. The key things to note are the creation of a background task to host the app service, the addition of the windows.appservice extension to the app service provider app's Package.appxmanifest file, obtaining the package family name of the app service provider app so that we can connect to it from the client app, and using [**Windows.ApplicationModel.AppService.AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704) to call the service.

## Full code for MyAppService


```cs
using System;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace MyAppService
{
    public sealed class Inventory : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
        private String[] inventoryItems = new string[] { "Robot vacuum", "Chair" };
        private double[] inventoryPrices = new double[] { 129.99, 88.99 };

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.backgroundTaskDeferral = taskInstance.GetDeferral(); // Get a deferral so that the service isn&#39;t terminated.
            taskInstance.Canceled += OnTaskCanceled; // Associate a cancellation handler with the background task.

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // Get a deferral because we use an awaitable API below to respond to the message
            // and we don&#39;t want this call to get cancelled while we are waiting.
            var messageDeferral = args.GetDeferral();

            ValueSet message = args.Request.Message;
            ValueSet returnData = new ValueSet();

            string command = message["Command"] as string;
            int? inventoryIndex = message["ID"] as int?;

            if (inventoryIndex.HasValue &amp;&amp;
                 inventoryIndex.Value >= 0 &amp;&amp;
                 inventoryIndex.Value < inventoryItems.GetLength(0))
            {
                switch (command)
                {
                    case "Price":
                        {
                            returnData.Add("Result", inventoryPrices[inventoryIndex.Value]);
                            returnData.Add("Status", "OK");
                            break;
                        }

                    case "Item":
                        {
                            returnData.Add("Result", inventoryItems[inventoryIndex.Value]);
                            returnData.Add("Status", "OK");
                            break;
                        }

                    default:
                        {
                            returnData.Add("Status", "Fail: unknown command");
                            break;
                        }
                }
            }
            else
            {
                returnData.Add("Status", "Fail: Index out of range");
            }

            await args.Request.SendResponseAsync(returnData); // Return the data to the caller.
            messageDeferral.Complete(); // Complete the deferral so that the platform knows that we&#39;re done responding to the app service call.
        }


        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (this.backgroundTaskDeferral != null)
            {
                // Complete the service deferral.
                this.backgroundTaskDeferral.Complete();
            }
        }
    }
}
```

## Xxxxxxx xxxxxx


* [Xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxx](support-your-app-with-background-tasks.md)

 

 



<!--HONumber=Mar16_HO1-->
