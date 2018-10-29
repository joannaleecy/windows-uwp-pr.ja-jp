---
author: TylerMSFT
title: アプリ サービスの作成と利用
description: 他のユニバーサル Windows プラットフォーム (UWP) アプリにサービスを提供できる UWP アプリを作成する方法と、それらのサービスを利用する方法について説明します。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
keywords: アプリ間通信, プロセス間通信, IPC, バック グラウンド メッセージング, バック グラウンド通信, アプリをアプリ サービス
ms.author: twhitney
ms.date: 09/18/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1407187f9883f44bb9fdc56fd3ae80820b5920f8
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5744962"
---
# <a name="create-and-consume-an-app-service"></a>アプリ サービスの作成と利用

アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。 これは、デバイス上にある Web サービスのようなものです。 アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。 たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。 また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。  アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。

Windows 10 バージョン 1607 以降では、ホスト アプリと同じプロセスで実行されるアプリ サービスを作成できます。 この記事では、別のバックグラウンド プロセスで実行されるアプリ サービスの作成と利用に重点を置いて説明します。 プロバイダーと同じプロセスでアプリ サービスを実行する詳細については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。

アプリ サービスのコード サンプルについては、「[ユニバーサル Windows プラットフォーム (UWP) アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)」を参照してください。

## <a name="create-a-new-app-service-provider-project"></a>新しいアプリ サービス プロバイダー プロジェクトの作成

このトピックでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。

-   Microsoft Visual Studio で、新しい UWP アプリ プロジェクトを作成し、これに **AppServiceProvider** という名前を付けます。 (**[新しいプロジェクト]** ダイアログ ボックスで、**[テンプレート] &gt; [他の言語] &gt; [Visual C#] &gt; [Windows] &gt; [Windows ユニバーサル] &gt; [空白のアプリ (Windows ユニバーサル)]** の順にクリックします)。 これは、他の UWP アプリがアプリ サービスを利用できるアプリとなります。
-   プロジェクトの**ターゲット バージョン**の選択を求められたら、**10.0.14393** 以上を選びます。 新しい `SupportsMultipleInstances` 属性を使用する場合には、Visual Studio 2017 を使用して、**10.0.15063** (**Windows 10 Creators Update**) 以降をターゲットとする必要があります。

<span id="appxmanifest"/>

## <a name="add-an-app-service-extension-to-packageappxmanifest"></a>package.appxmanifest へのアプリ サービスの拡張機能の追加

AppServiceProvider プロジェクトの Package.appxmanifest ファイルで、次の AppService 拡張機能を `&lt;Application&gt;` 要素内に追加します。 この例では、`com.Microsoft.Inventory` サービスをアドバタイズし、このアプリをアプリ サービス プロバイダーとして識別します。 実際のサービスは、バックグラウンド タスクとして実装されます。 アプリ サービスのプロジェクトは、サービスを他のアプリに公開します。 サービス名には逆のドメイン名スタイルを使うことをお勧めします。

`xmlns:uap4` 名前空間のプレフィックスと `uap4:SupportsMultipleInstances` 属性は、Windows SDK バージョン 10.0.15063 以降をターゲットとしている場合のみ有効です。 以前のバージョンの SDK をターゲットとしている場合には、それらは安全に削除できます。

``` xml
<Package
    ...
    xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    ...
    <Applications>
        <Application Id="AppServicesProvider.App"
          Executable="$targetnametoken$.exe"
          EntryPoint="AppServicesProvider.App">
          ...
          <Extensions>
            <uap:Extension Category="windows.appService" EntryPoint="MyAppService.Inventory">
              <uap3:AppService Name="com.microsoft.inventory" uap4:SupportsMultipleInstances="true"/>
            </uap:Extension>
          </Extensions>
          ...
        </Application>
    </Applications>
```

**Category** 属性は、このアプリケーションをアプリ サービス プロバイダーとして識別します。

**EntryPoint** 属性は、サービスを実装する名前空間修飾クラスを識別します。これについては、次に実装します。

**SupportsMultipleInstances** 属性は、アプリ サービスが呼び出されるたびに、新しいプロセスで実行する必要があることを示します。 これは必須ではありませんが、その機能を必要とし、`10.0.15063` SDK (**Windows 10 Creators Update**) 以降をターゲットとしている場合には、利用できます。 また、先頭に `uap4` 名前空間を付ける必要があります。

## <a name="create-the-app-service"></a>アプリ サービスの作成

1.  アプリ サービスは、バックグラウンド タスクとして実装できます。 これにより、フォアグラウンド アプリケーションは、別のアプリケーションのアプリ サービスを呼び出すことができます。 アプリ サービスをバックグラウンド タスクとして作成するには、MyAppService という名前の新しい Windows ランタイム コンポーネント プロジェクトをソリューションに追加 (**[ファイル] &gt; [追加] &gt; [新しいプロジェクト]**) します。 (**[新しいプロジェクトの追加]** ダイアログ ボックスで、**[インストール済み] &gt; [他の言語] &gt; [Visual C#] &gt; [Windows] &gt; [Windows ユニバーサル] &gt; [Windows ランタイム コンポーネント (Windows ユニバーサル)]** の順に選びます。)
2.  **AppServiceProvider**プロジェクトで、新しい **MyAppService**プロジェクト (ソリューション エクスプ ローラーで、**[AppServiceProvider]** を右クリックし、[プロジェクト] > **[追加]** > **[リファレンス]** > **[プロジェクト]** > **[ソリューション]** から **[MyAppService]** > **[OK]** をクリック) へのプロジェクト間の参照を追加します。 参照を追加しない場合でも、アプリ サービスは実行時に接続されないため、この手順は重要です。
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
            this.backgroundTaskDeferral = taskInstance.GetDeferral(); // Get a deferral so that the service isn't terminated.
            taskInstance.Canceled += OnTaskCanceled; // Associate a cancellation handler with the background task.

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // This function is called when the app service receives a request
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

    バックグラウンド タスクが作成されると、**Run()** が呼び出されます。 バックグラウンド タスクは **Run** が完了すると終了するため、バックグラウンド タスクが要求に引き続き対応できるように、コードは保留されます。 バックグラウンド タスクとして実装されたアプリ サービスは、呼び出しを受け取った後、約 30 秒間に再度呼び出されない限り、または保留されない限り、約 30 秒間有効になっています。アプリ サービスが同じプロセスで呼び出し元として実装されると、アプリ サービスの有効期間は呼び出し元の有効期間に関連付けられます。

    アプリ サービスの有効期間は、呼び出し元に依存します。

    1. 呼び出し元がフォアグラウンドである場合は、アプリ サービスの有効期間は、呼び出し元と同じです。
    2. 呼び出し元がバックグラウンドである場合は、アプリ サービスの有効期間は 30 秒です。 保留されると、1 回 5 秒追加されます。

    タスクが取り消されると、**OnTaskCanceled()** が呼び出されます。 タスクが取り消されるのは、クライアント アプリが [**AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704) を破棄したとき、クライアント アプリが中断されたとき、OS がシャットダウンまたはスリープ状態になったとき、または OS がリソース不足になりタスクを実行できなくなったときです。

## <a name="write-the-code-for-the-app-service"></a>アプリ サービスのコードを記述する

**OnRequestReceived()** は、アプリ サービスのコードが配置される場所です。 MyAppService の Class1.cs のスタブ **OnRequestReceived()** を、次の例のコードに置き換えます。 このコードは、インベントリの項目のインデックスを取得し、コマンド文字列と共にサービスに渡して、指定したインベントリ項目の名前と価格を取得します。 独自のプロジェクトには、エラー処理コードを追加します。

```cs
private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    // Get a deferral because we use an awaitable API below to respond to the message
    // and we don't want this call to get cancelled while we are waiting.
    var messageDeferral = args.GetDeferral();

    ValueSet message = args.Request.Message;
    ValueSet returnData = new ValueSet();

    string command = message["Command"] as string;
    int? inventoryIndex = message["ID"] as int?;

    if ( inventoryIndex.HasValue &&
         inventoryIndex.Value >= 0 &&
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

    try
    {
        await args.Request.SendResponseAsync(returnData); // Return the data to the caller.
    }
    catch (Exception e)
    {
        // your exception handling code here
    }
    finally
    {
        // Complete the deferral so that the platform knows that we're done responding to the app service call.
        // Note for error handling: this must be called even if SendResponseAsync() throws an exception.
        messageDeferral.Complete();
    }
}
```

**OnRequestReceived()** が **async** であることに注意してください。この例では、[**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) への待機可能なメソッド呼び出しを行うためです。

保留が行われるのは、サービスが OnRequestReceived ハンドラーで **async** メソッドを使用できるようにするためです。 これにより、**OnRequestReceived** への呼び出しは、メッセージの処理が完了するまで完了しません。  [**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) が結果を呼び出し元に送ります。 **SendResponseAsync** は、呼び出しの完了時に通知しません。 **OnRequestReceived** が完了したことを [**SendMessageAsync**](https://msdn.microsoft.com/library/windows/apps/dn921712) に通知するのは、保留の完了時です。 **SendResponseAsync()** の呼び出しは、**SendResponseAsync()** が例外をスローした場合でも保留を完了する必要があるため、try/finally ブロックでラップされます。

アプリ サービスは [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) を使って情報を交換します。 渡すことができるデータのサイズは、システム リソースによってのみ制限されます。 **ValueSet** で使うことができる定義済みのキーはありません。 アプリ サービスのプロトコルの定義に使うキーの値を決定する必要があります。 呼び出し元は、そのプロトコルを念頭に置いて記述する必要があります。 この例では、アプリ サービスがインベントリ項目またはその価格の名前を提供するかどうかを示す値を持つ、`Command` という名前のキーを選びました。 インベントリ名のインデックスは、`ID` キーに保存されています。 戻り値は `Result` キーに保存されます。

[**AppServiceClosedStatus**](https://msdn.microsoft.com/library/windows/apps/dn921703) 列挙体が呼び出し元に返され、アプリ サービスの呼び出した成功したか失敗したかを示します。 アプリ サービスへの呼び出しが失敗する例として、OS がサービスのエンドポイントを中止した、リソースが超過したなどがあります。 [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) を通じて、さらにエラー情報を取得することができます。 この例では、`Status` という名前のキーを使って、より詳細なエラー情報を呼び出し元に返します。

[**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) の呼び出しからは、[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) が呼び出し元に返されます。

## <a name="deploy-the-service-app-and-get-the-package-family-name"></a>サービス アプリを展開して、パッケージ ファミリ名を取得する

クライアントから呼び出す前に、アプリ サービス プロバイダーのアプリを展開する必要があります。 これを呼び出すには、アプリ サービスのアプリのパッケージ ファミリ名も必要になります。

アプリ サービスのアプリのパッケージ ファミリ名を取得する 1 つの方法は、**AppServiceProvider** プロジェクト内から (たとえば、App.xaml.cs の `public App()` から) [**Windows.ApplicationModel.Package.Current.Id.FamilyName**](https://msdn.microsoft.com/library/windows/apps/br224670) を呼び出し、結果をメモします。 Microsoft Visual Studio で AppServiceProvider を実行するには、ソリューション エクスプローラー ウィンドウで、スタートアップ プロジェクトとして設定し、プロジェクトを実行します。

パッケージ ファミリ名を取得する別の方法として、ソリューションを配置し (**[ビルド] &gt; [ソリューションの配置]**)、出力ウィンドウで完全なパッケージ名をメモします (**[表示] &gt; [出力]**)。 パッケージ名を派生するには、出力ウィンドウの文字列からプラットフォーム情報を削除する必要があります。 たとえば、完全なパッケージ名が出力ウィンドウで `Microsoft.SDKSamples.AppServicesProvider.CPP_1.0.0.0_x86__8wekyb3d8bbwe` と報告された場合、Microsoft.SDKSamples.AppServicesProvider.CPP_8wekyb3d8bbwe" を削除し、"1.0.0.0_x86__"(`1.0.0.0\_x86\_\_" leaving "Microsoft.SDKSamples.AppServicesProvider.CPP_8wekyb3d8bbwe`) がパッケージ ファミリ名となります。

## <a name="write-a-client-to-call-the-app-service"></a>アプリ サービスを呼び出すクライアントを作成する

1.  **[ファイル] &gt; [追加] &gt; [新しいプロジェクト]** で、新しい空の Windows ユニバーサル アプリ プロジェクトをソリューションに追加します。 **[新しいプロジェクトの追加]** ダイアログ ボックスで、**[インストール済み] &gt; [他の言語] &gt; [Visual C#] &gt; [Windows] &gt; [Windows ユニバーサル] &gt; [空のアプリ (Windows ユニバーサル)] ** の順に選び、**[ClientApp]** と名前を付けます。
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

           // Here, we use the app service name defined in the app service provider's Package.appxmanifest file in the <Extension> section.
           this.inventoryService.AppServiceName = "com.microsoft.inventory";

           // Use Windows.ApplicationModel.Package.Current.Id.FamilyName within the app service provider to get this value.
           this.inventoryService.PackageFamilyName = "replace with the package family name";

           var status = await this.inventoryService.OpenAsync();
           if (status != AppServiceConnectionStatus.Success)
           {
               textBox.Text= "Failed to connect";
               this.inventoryService = null;
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

       textBox.Text = result;
   }
   ```
行 `this.inventoryService.PackageFamilyName = "replace with the package family name";` のパッケージ ファミリ名を、「[サービス アプリを展開して、パッケージ ファミリ名を取得する](#deploy-the-service-app-and-get-the-package-family-name)」で得た **AppServiceProvider** プロジェクトのパッケージ ファミリ名に置き換えます。

最初に、コードによってアプリ サービスとの接続が確立されます。 接続は、`this.inventoryService` を破棄するまで開いたままになります。 アプリ サービス名は、AppServiceProvider プロジェクトの Package.appxmanifest ファイルに追加した **AppService Name** 属性と一致する必要があります。 この例では `<uap:AppService Name="com.microsoft.inventory"/>` です。

**message** という名前の [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) が、アプリ サービスに送信するコマンドを指定するために作成されます。 この例のアプリ サービスでは、2 つのアクションのどちらを実行するかをコマンドが示すことを想定しています。 クライアント アプリのテキスト ボックスからインデックスを取得し、`Item` コマンドでサービスを呼び出して項目の説明を取得します。 その後、`Price` コマンドで呼び出しを行い、項目の価格を取得します。 ボタンのテキストは結果に設定されています。

オペレーティング システムがアプリ サービスに呼び出しを接続できたかどうかを示すのは [**AppServiceResponseStatus**](https://msdn.microsoft.com/library/windows/apps/dn921724) のみです。このため、アプリ サービスが要求を満たすことができたことを確認するために、アプリ サービスから受け取る [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) の `Status` キーをチェックします。

6.  Visual Studio で、ClientApp プロジェクトをソリューション エクスプローラー ウィンドウで、スタートアップ プロジェクトとなるように設定し、プロジェクトを実行します。 数値 1 をテキスト ボックスに入力し、ボタンをクリックします。 サービスから "Chair : Price = 88.99" が返されます。

    ![Chair : price = 88.99 を表示するサンプル アプリ](images/appserviceclientapp.png)

アプリ サービスの呼び出しが失敗した場合は、ClientApp で次のことを確認します。

1.  インベントリ サービスの接続に割り当てられたパッケージ ファミリ名が、AppServiceProvider アプリのパッケージ ファミリ名と一致することを確認します。 **button\_Click()**`this.inventoryService.PackageFamilyName = "...";` をご覧ください。
2.  **button\_Click()** で、インベントリ サービスの接続に割り当てられたアプリ サービス名が、AppServiceProvider の Package.appxmanifest ファイルのアプリ サービス名と一致することを確認します。 `this.inventoryService.AppServiceName = "com.microsoft.inventory";` をご覧ください。
3.  AppServiceProvider アプリが展開されたことを確認します (ソリューション エクスプローラーでソリューションを右クリックし、**[展開]** をクリックします)。

## <a name="debug-the-app-service"></a>アプリ サービスのデバッグ

1.  サービスを呼び出す前にアプリ サービス プロバイダーのアプリが配置される必要があるため、ソリューションがデバッグする前に展開されるようにします。 (Visual Studio で、**[ビルド] &gt; [ソリューションの配置]** の順にクリックします)。
2.  ソリューション エクスプローラーで、**AppServiceProvider** プロジェクトを右クリックして、**[プロパティ]** をクリックします。 **[デバッグ]** タブで、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に変更します。 (C++ を使ってアプリ サービス プロバイダーを実装した場合、**[デバッグ]** タブから **[アプリケーションの起動]** を **[いいえ]** に変更します)。
3.  MyAppService プロジェクトの Class1.cs ファイルで、`OnRequestReceived()` にブレークポイントを設定します。
4.  AppServiceProvider プロジェクトをスタートアップ プロジェクトとなるように設定し、F5 キーを押します。
5.  (Visual Studio からではなく) [スタート] メニューから ClientApp を起動します。
6.  数値 1 をテキスト ボックスに入力し、ボタンを押します。 デバッガーは、アプリ サービス内のブレークポイントでアプリ サービスの呼び出しを停止します。

## <a name="debug-the-client"></a>クライアントのデバッグ

1.  前の手順に従って、アプリ サービスを呼び出すクライアントをデバッグします。
2.  [スタート] メニューから ClientApp を起動します。
3.  (ApplicationFrameHost.exe プロセスではなく) ClientApp.exe プロセスにデバッガーをアタッチします。 (Visual Studio で、**[デバッグ] &gt; [プロセスにアタッチ]** の順に選びます)。
4.  ClientApp プロジェクトで、**button\_Click()** にブレークポイントを設定します。
5.  ClientApp のテキスト ボックスに数値 1 を入力してボタンをクリックすると、クライアントとアプリ サービスの両方のブレークポイントがヒットするようになります。

## <a name="general-app-service-troubleshooting"></a>一般的なアプリ サービスのトラブルシューティング ##

アプリ サービスに接続しようとして **AppUnavailable** 状態が発生した場合、以下を確認します。

- アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。 クライアントを実行する前に、両方が展開されている必要があります。展開されていない場合、クライアントには接続先がありません。 Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。
- ソリューション エクスプローラーを使って、アプリ サービス プロバイダー プロジェクトで、アプリ サービスを実装したプロジェクトへの、プロジェクト間の参照が設定されていることを確認します。
- `<Extensions>` エントリとその子要素が、アプリ サービス プロバイダー プロジェクトに属する Package.appxmanifest ファイルに追加されていることを確認します。詳しくは上述の「[package.appxmanifest へのアプリ サービスの拡張機能の追加](#appxmanifest)」をご覧ください。
- アプリ サービス プロバイダーを呼び出すクライアントの `AppServiceConnection.AppServiceName` 文字列が、アプリ サービス プロバイダー プロジェクトの Package.appxmanifest ファイルで指定された `<uap3:AppService Name="..." />` と一致していることを確認します。
- `AppServiceConnection.PackageFamilyName` が、アプリ サービス プロバイダーのコンポーネントのパッケージ ファミリ名と一致していることを確認します。詳しくは上述の「[package.appxmanifest へのアプリ サービスの拡張機能の追加](#appxmanifest)」をご覧ください。
- この例のようなアウトプロセスのアプリ サービスでは、アプリ サービス プロバイダー プロジェクトの Package.appxmanifest ファイルの `<uap:Extension ...>` 要素で指定された `EntryPoint` が、アプリ サービス プロジェクトで `IBackgroundTask` を実装する公開クラスの名前空間とクラスの名前と一致していることを検証します。

### <a name="troubleshoot-debugging"></a>デバッグのトラブルシューティング

アプリ サービス プロバイダーまたはアプリ サービス プロジェクトのブレークポイントでデバッガーが停止しない場合は、以下を確認します。

- アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。 クライアントを実行する前に、両方が展開されている必要があります。 Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。
- デバッグするプロジェクトがスタートアップ プロジェクトとして設定されていることを確認します。そのプロジェクトのデバッグ プロパティを確認し、F5 キーが押されたときにプロジェクトを実行しないように設定されていることを確認します。 プロジェクトを右クリックし、**[プロパティ]**、**[デバッグ]** (または C++ では **[デバッグ]**) の順にクリックします。 C# では、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に設定します。 C++ では、**[アプリケーションの起動]** を **[いいえ]** に設定します。

## <a name="remarks"></a>注釈

この例では、バックグラウンド タスクとして実行されるアプリ サービスを作成して、それを別のアプリから呼び出す概要を示しています。 重要な点は、アプリ サービスをホストするためのバックグラウンド タスクの作成、アプリ サービス プロバイダーのアプリの Package.appxmanifest ファイルへの windows.appservice 拡張機能の追加、クライアント アプリから接続するためのアプリ サービス プロバイダーのアプリのパッケージ ファミリ名の取得、アプリ サービス プロバイダー プロジェクトからアプリ サービス プロジェクトへのプロジェクト間の参照の追加、[**Windows.ApplicationModel.AppService.AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704) を使ったサービスの呼び出しです。

## <a name="full-code-for-myappservice"></a>MyAppService の完全なコード

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
            this.backgroundTaskDeferral = taskInstance.GetDeferral(); // Get a deferral so that the service isn't terminated.
            taskInstance.Canceled += OnTaskCanceled; // Associate a cancellation handler with the background task.

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // Get a deferral because we use an awaitable API below to respond to the message
            // and we don't want this call to get cancelled while we are waiting.
            var messageDeferral = args.GetDeferral();

            ValueSet message = args.Request.Message;
            ValueSet returnData = new ValueSet();

            string command = message["Command"] as string;
            int? inventoryIndex = message["ID"] as int?;

            if (inventoryIndex.HasValue &&
                 inventoryIndex.Value >= 0 &&
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
            // Complete the deferral so that the platform knows that we're done responding to the app service call.
            // Note for error handling: this must be called even if SendResponseAsync() throws an exception.
            messageDeferral.Complete();
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

## <a name="related-topics"></a>関連トピック

* [ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)
* [バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)
* [アプリ サービスのコード サンプル (C#、C++、および VB)](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)
