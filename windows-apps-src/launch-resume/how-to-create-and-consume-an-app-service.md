---
title: アプリ サービスの作成と利用
description: 他の UWP アプリにサービスを提供できるユニバーサル Windows プラットフォーム (UWP) アプリを作成する方法と、それらのサービスを利用する方法について説明します。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
---

# アプリ サービスの作成と利用


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


他の UWP アプリにサービスを提供できるユニバーサル Windows プラットフォーム (UWP) アプリを作成する方法と、それらのサービスを利用する方法について説明します。

## 新しいアプリ サービス プロバイダー プロジェクトの作成


このトピックでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。

-   Microsoft Visual Studio 2015 で、新しい UWP アプリ プロジェクトを作成し、これに AppServiceProvider という名前を付けます。 ( **[新しいプロジェクト]** ダイアログ ボックスで、 **[テンプレート]、[他の言語]、[Visual C#]、[Windows]、[Windows ユニバーサル]、[空のアプリケーション (Windows ユニバーサル)]**の順にクリックします)。 これは、アプリ サービスを提供するアプリです。

## package.appxmanifest に、アプリ サービスの拡張機能を追加します。


AppServiceProvider プロジェクトの Package.appxmanifest ファイルで、次の AppService 拡張機能を **&lt;Application&gt;** 要素に追加します。 この例では、`com.Microsoft.Inventory` サービスをアドバタイズし、このアプリをアプリ サービス プロバイダーとして識別します。 実際のサービスは、バックグラウンド タスクとして実装されます。 アプリ サービスのアプリは、サービスを他のアプリに公開します。 サービス名には逆のドメイン名スタイルを使うことをお勧めします。

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

**Category** 属性は、このアプリケーションをアプリ サービス プロバイダーとして識別します。

**EntryPoint** 属性は、サービスを実装するクラスを識別します。これについては、次に実装します。

## アプリ サービスの作成


1.  アプリ サービスは、バックグラウンド タスクとして実装されます。 これにより、フォアグラウンド アプリケーションは、背後でタスクを実行する、別のアプリケーションのアプリ サービスを呼び出すことができます。 MyAppService という名前の新しい Windows ランタイム コンポーネント プロジェクトをソリューションに追加 (**[ファイル] &gt; [追加] &gt; [新しいプロジェクト]**) します。 ( **[新しいプロジェクトの追加]** ダイアログ ボックスで、 **Installed &gt; Other Languages &gt; Visual C# &gt; Windows &gt; Windows Universal &gt; Windows Runtime Component (Windows Universal)**の順に選びます)。
2.  AppServiceProvider プロジェクトで、MyAppService プロジェクトへの参照を追加します。
3.  MyappService プロジェクトで、Class1.cs の上部に、次の **using** ステートメントを追加します。
    ```cs
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    ```

4.  **Class1** のスタブ コードを、**Inventory** という名前の新しいバックグラウンド タスク クラスに置き換えます。

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

    このクラスは、アプリ サービスが作業を実行する場所です。

    バックグラウンド タスクが作成されると、**Run()** が呼び出されます。 バックグラウンド タスクは **Run** が完了すると終了するため、バックグラウンド タスクが要求に引き続き対応できるように、コードは保留されます。

    タスクが取り消されると、**OnTaskCanceled()** が呼び出されます。 タスクが取り消されるのは、クライアント アプリが [**AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704) を破棄したとき、クライアント アプリが中断されたとき、OS がシャットダウンまたはスリープ状態になったとき、または OS がリソース不足になりタスクを実行できなくなったときです。

## アプリ サービスのコードを記述する


**OnRequestedReceived()** は、アプリ サービスのコードが配置される場所です。 MyAppService の Class1.cs のスタブ **OnRequestedReceived()** を、次の例のコードに置き換えます。 このコードは、インベントリの項目のインデックスを取得し、コマンド文字列と共にサービスに渡して、指定したインベントリ項目の名前と価格を取得します。 エラー処理コードは、簡略にするために削除されています。

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

**OnRequestedReceived()** が **async** であることに注意してください。この例では、[**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) への待機可能なメソッド呼び出しを行うためです。

保留が行われるのは、サービスが OnRequestReceived ハンドラーで **async** メソッドを使用できるようにするためです。 これにより、OnRequestReceived への呼び出しは、メッセージの処理が完了するまで完了しません。 [**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) は、完了と共に応答を送信するために使われます。 **SendResponseAsync** は、呼び出しの完了時に通知しません。 OnRequestReceived が完了したことを [**SendMessageAsync**](https://msdn.microsoft.com/library/windows/apps/dn921712) に通知するのは、保留の完了時です。

アプリ サービスは [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) を使って情報を交換します。 渡すことができるデータのサイズは、システム リソースによってのみ制限されます。 **ValueSet** で使うことができる定義済みのキーはありません。 アプリ サービスのプロトコルの定義に使うキーの値を決定する必要があります。 呼び出し元は、そのプロトコルを念頭に置いて記述する必要があります。 この例では、アプリ サービスがインベントリ項目またはその価格の名前を提供するかどうかを示す値を持つ、"Command" という名前のキーを選びました。 インベントリ名のインデックスは、"ID" キーに保存されています。 戻り値は "Result" キーに保存されます。

[
            **AppServiceClosedStatus**](https://msdn.microsoft.com/library/windows/apps/dn921703) 列挙体が呼び出し元に返され、アプリ サービスの呼び出した成功したか失敗したかを示します。 アプリ サービスへの呼び出しが失敗する例として、OS がサービスのエンドポイントを中止した、リソースが超過したなどがあります。 [
            **ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) を通じて、さらにエラー情報を取得することができます。 この例では、"Status" という名前のキーを使って、より詳細なエラー情報を呼び出し元に返します。

[
            **SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) の呼び出しからは、[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) が呼び出し元に返されます。

## サービス アプリを展開して、パッケージ ファミリ名を取得する


クライアントから呼び出す前に、アプリ サービス プロバイダーのアプリを展開する必要があります。 これを呼び出すには、アプリ サービスのアプリのパッケージ ファミリ名も必要になります。

-   アプリ サービスのアプリのパッケージ ファミリ名を取得する 1 つの方法は、**AppServiceProvider** プロジェクト内から (たとえば、App.xaml.cs の `public App()` から) [**Windows.ApplicationModel.Package.Current.Id.FamilyName**](https://msdn.microsoft.com/library/windows/apps/br224670) を呼び出し、結果をメモします。 Microsoft Visual Studio で AppServiceProvider を実行するには、ソリューション エクスプローラー ウィンドウで、スタートアップ プロジェクトとして設定し、プロジェクトを実行します。
-   パッケージ ファミリ名を取得する別の方法として、ソリューションを配置し (**[ビルド] &gt; [ソリューションの配置]**)、出力ウィンドウで完全なパッケージ名をメモします (**[表示] &gt; [出力]**)。 パッケージ名を派生するには、出力ウィンドウの文字列からプラットフォーム情報を削除する必要があります。 たとえば、完全なパッケージ名が出力ウィンドウで "9fe3058b-3de0-4e05-bea7-84a06f0ee4f0\_1.0.0.0\_x86\_\_yd7nk54bq29ra" と報告された場合、"1.0.0.0\_x86\_\_" を削除し、"9fe3058b-3de0-4e05-bea7-84a06f0ee4f0\_yd7nk54bq29ra" がパッケージ ファミリ名となります。

## アプリ サービスを呼び出すクライアントを作成する


1.  ClientApp という名前の新しい空の Windows ユニバーサル アプリ プロジェクトをソリューションに追加 (**[ファイル] &gt; [追加] &gt; [新しいプロジェクト]**) します。 (**[新しいプロジェクトの追加]** ダイアログ ボックスで、**[インストール済み]、[他の言語]、[Visual C#]、[Windows]、[Windows ユニバーサル]、[空のアプリ (Windows ユニバーサル)]** の順に選びます)。
2.  ClientApp プロジェクトで、MainPage.xaml.cs の上部に、次の **using** ステートメントを追加します。
    ```cs
    >using Windows.ApplicationModel.AppService;
    ```

3.  テキスト ボックスとボタンを MainPage.xaml に追加します。
4.  ボタンのクリック ハンドラーを追加し、ボタン ハンドラーの署名にキーワード **async** を追加します。
5.  ボタンのクリック ハンドラーのスタブを、次のコードで置き換えます。 必ず、`inventoryService` フィールドの宣言を含めます。

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

## 関連トピック


* [バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)

 

 





<!--HONumber=Mar16_HO1-->


