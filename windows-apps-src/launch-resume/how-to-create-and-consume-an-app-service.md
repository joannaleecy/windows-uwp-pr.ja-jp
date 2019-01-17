---
title: アプリ サービスの作成と利用
description: 他のユニバーサル Windows プラットフォーム (UWP) アプリにサービスを提供できる UWP アプリを作成する方法と、それらのサービスを利用する方法について説明します。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
keywords: アプリ間通信, プロセス間通信, IPC, バック グラウンド メッセージング, バック グラウンド通信, アプリをアプリ サービス
ms.date: 1/16/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5239bff53bb0e5383bce28b4d781a0ab6a41c3af
ms.sourcegitcommit: cfdc854fede8e586202523cdb59d3d0a2f5b4b36
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/17/2019
ms.locfileid: "9013961"
---
# <a name="create-and-consume-an-app-service"></a>アプリ サービスの作成と利用

アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。 これは、デバイス上にある Web サービスのようなものです。 アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。 たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。 また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。  アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。

Windows 10 バージョン 1607 以降では、ホスト アプリと同じプロセスで実行されるアプリ サービスを作成できます。 この記事では、別のバックグラウンド プロセスで実行されるアプリ サービスの作成と利用に重点を置いて説明します。 プロバイダーと同じプロセスでアプリ サービスを実行する詳細については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。

アプリ サービスのコード サンプルについては、「[ユニバーサル Windows プラットフォーム (UWP) アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)」を参照してください。

## <a name="create-a-new-app-service-provider-project"></a>新しいアプリ サービス プロバイダー プロジェクトの作成

このトピックでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。

1. Visual Studio 2015 以降では、新しい UWP アプリ プロジェクトを作成し、 **AppServiceProvider**という名前を付けます。
    1. **ファイル _gt 新しい _gt**プロジェクト] 
    2. **新しいプロジェクト**] ダイアログ ボックスで、**インストール済み _gt Visual C#] _gt 空白のアプリ (ユニバーサル Windows)** を選択します。 これは、他の UWP アプリがアプリ サービスを利用できるアプリとなります。
    3. **AppServiceProvider**プロジェクトの名前、場所を選択して、 **[ok]** をクリックします。

2. プロジェクトの**ターゲット**と**最小バージョン**を選択するメッセージが表示されたら、少なくとも選択**10.0.14393**します。 Visual Studio 2017 およびターゲット**10.0.15063** (**Windows 10 Creators Update**) が使用する必要があります、新しい**SupportsMultipleInstances**属性を使用する場合は、以上。

<span id="appxmanifest"/>

## <a name="add-an-app-service-extension-to-packageappxmanifest"></a>Package.appxmanifest へのアプリ サービスの拡張機能を追加します。

**AppServiceProvider**プロジェクトでは、テキスト エディターで、 **Package.appxmanifest**ファイルを開きます。 

1. **ソリューション エクスプ ローラー**で右クリックします。 
2. **[ファイルを開く**を選択します。 
3. **XML (テキスト) エディター**を選択します。 

次の追加`AppService`内で拡張機能、`<Application>`要素です。 この例では、`com.microsoft.inventory` サービスをアドバタイズし、このアプリをアプリ サービス プロバイダーとして識別します。 実際のサービスは、バックグラウンド タスクとして実装されます。 アプリ サービスのプロジェクトは、サービスを他のアプリに公開します。 サービス名には逆のドメイン名スタイルを使うことをお勧めします。

`xmlns:uap4` 名前空間のプレフィックスと `uap4:SupportsMultipleInstances` 属性は、Windows SDK バージョン 10.0.15063 以降をターゲットとしている場合のみ有効です。 以前のバージョンの SDK をターゲットとしている場合には、それらは安全に削除できます。

``` xml
<Package
    ...
    xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    ...
    <Applications>
        <Application Id="AppServiceProvider.App"
          Executable="$targetnametoken$.exe"
          EntryPoint="AppServiceProvider.App">
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

`Category`属性は、アプリ サービス プロバイダーとしてこのアプリケーションを識別します。

`EntryPoint`属性は、次に実装するサービスを実装する名前空間修飾クラスを識別します。

`SupportsMultipleInstances`属性は、アプリ サービスが呼び出されるたびに実行される新しいプロセスでを示します。 これは必要ありませんは、その機能を必要し、10.0.15063 をターゲットとしている場合に利用可能な SDK (**Windows 10 Creators Update**) 以上。 また、先頭に `uap4` 名前空間を付ける必要があります。

## <a name="create-the-app-service"></a>アプリ サービスの作成

1.  アプリ サービスは、バックグラウンド タスクとして実装できます。 これにより、フォアグラウンド アプリケーションは、別のアプリケーションのアプリ サービスを呼び出すことができます。 バック グラウンド タスクとしてアプリ サービスを作成するには、ソリューションに新しい Windows ランタイム コンポーネント プロジェクトを追加 (**ファイル&gt;追加&gt;新しいプロジェクト**) **MyAppService**という名前です。 **新しいプロジェクトの追加**] ダイアログ ボックスで、**インストール済み _gt Visual C#] _gt Windows ランタイム コンポーネント (ユニバーサル Windows)** を選択します。
2.  **AppServiceProvider**プロジェクトで、新しい**MyAppService**プロジェクトへのプロジェクト間の参照を追加します (**ソリューション エクスプ ローラー**で、 **AppServiceProvider**プロジェクト _gt**追加**で右クリック > **参照** > **プロジェクト** > **ソリューション**、選択**MyAppService** > **[ok]**)。 参照を追加しない場合でも、アプリ サービスは実行時に接続されないため、この手順は重要です。
3.  **MyAppService**プロジェクトで、 **Class1.cs**の上部に、次の**using**ステートメントを追加します。
    ```cs
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    ```

4.  **Inventory.cs**、 **Class1.cs**の名前を変更し、 **Class1**の**インベントリ**をという名前の新しいバック グラウンド タスク クラスのスタブ コードを置き換えます。

    ```cs
    public sealed class Inventory : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
        private String[] inventoryItems = new string[] { "Robot vacuum", "Chair" };
        private double[] inventoryPrices = new double[] { 129.99, 88.99 };

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get a deferral so that the service isn't terminated.
            this.backgroundTaskDeferral = taskInstance.GetDeferral();

            // Associate a cancellation handler with the background task.
            taskInstance.Canceled += OnTaskCanceled;

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // This function is called when the app service receives a request.
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

    **実行**は、バック グラウンド タスクが作成されたときに呼び出されます。 バックグラウンド タスクは **Run** が完了すると終了するため、バックグラウンド タスクが要求に引き続き対応できるように、コードは保留されます。 バックグラウンド タスクとして実装されたアプリ サービスは、呼び出しを受け取った後、約 30 秒間に再度呼び出されない限り、または保留されない限り、約 30 秒間有効になっています。アプリ サービスが同じプロセスで呼び出し元として実装されると、アプリ サービスの有効期間は呼び出し元の有効期間に関連付けられます。

    アプリ サービスの有効期間は、呼び出し元に依存します。

    * 呼び出し元がフォア グラウンドである場合は、アプリ サービスの有効期間は、呼び出し元と同じです。
    * 呼び出し元がバック グラウンドである場合は、アプリ サービスは 30 秒間実行を取得します。 保留されると、1 回 5 秒追加されます。

    タスクが取り消さ**OnTaskCanceled**が呼び出されます。 クライアント アプリ破棄[AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)、クライアント アプリが一時停止、OS がシャット ダウンまたはスリープ状態になり、または OS がタスクを実行するリソース不足と、タスクが取り消されます。

## <a name="write-the-code-for-the-app-service"></a>アプリ サービスのコードを記述する

**OnRequestReceived**は、アプリ サービスのコードが移動します。 **OnRequestReceived** **MyAppService**を**Inventory.cs**でスタブを次の例のコードに置き換えます。 このコードは、インベントリの項目のインデックスを取得し、コマンド文字列と共にサービスに渡して、指定したインベントリ項目の名前と価格を取得します。 独自のプロジェクトには、エラー処理コードを追加します。

```cs
private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    // Get a deferral because we use an awaitable API below to respond to the message
    // and we don't want this call to get canceled while we are waiting.
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

    try
    {
        // Return the data to the caller.
        await args.Request.SendResponseAsync(returnData);
    }
    catch (Exception e)
    {
        // Your exception handling code here.
    }
    finally
    {
        // Complete the deferral so that the platform knows that we're done responding to the app service call.
        // Note for error handling: this must be called even if SendResponseAsync() throws an exception.
        messageDeferral.Complete();
    }
}
```

**OnRequestReceived**が**非同期の**ため、この例では[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)を呼び出して待機可能なメソッドに注意してください。

サービスが**OnRequestReceived**ハンドラーで**非同期**メソッドを使用できるように、遅延が取得されます。 これにより、**OnRequestReceived** への呼び出しは、メッセージの処理が完了するまで完了しません。  [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) が結果を呼び出し元に送ります。 **SendResponseAsync** は、呼び出しの完了時に通知しません。 **OnRequestReceived**が完了したことを[SendMessageAsync](https://msdn.microsoft.com/library/windows/apps/dn921712)に通知するは、保留の完了することをお勧めします。 **SendResponseAsync**への呼び出しは、 **SendResponseAsync**例外をスローする場合でも、保留を完了する必要があるために、try/finally ブロックでラップされます。

アプリ サービスは、情報を交換[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)オブジェクトを使用します。 渡すことができるデータのサイズは、システム リソースによってのみ制限されます。 **ValueSet** で使うことができる定義済みのキーはありません。 アプリ サービスのプロトコルの定義に使うキーの値を決定する必要があります。 呼び出し元は、そのプロトコルを念頭に置いて記述する必要があります。 この例では、アプリ サービスがインベントリ項目またはその価格の名前を提供するかどうかを示す値を持つ、`Command` という名前のキーを選びました。 インベントリ名のインデックスは、`ID` キーに保存されています。 戻り値は `Result` キーに保存されます。

[AppServiceClosedStatus](https://msdn.microsoft.com/library/windows/apps/dn921703) 列挙体が呼び出し元に返され、アプリ サービスの呼び出した成功したか失敗したかを示します。 アプリ サービスへの呼び出しが失敗する例として、OS がサービスのエンドポイントを中止した、リソースが超過したなどがあります。 [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) を通じて、さらにエラー情報を取得することができます。 この例では、`Status` という名前のキーを使って、より詳細なエラー情報を呼び出し元に返します。

[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) の呼び出しからは、[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) が呼び出し元に返されます。

## <a name="deploy-the-service-app-and-get-the-package-family-name"></a>サービス アプリを展開して、パッケージ ファミリ名を取得する

アプリ サービス プロバイダーは、クライアントから呼び出すことができます前に展開する必要があります。 Visual Studio で **_gt 展開ソリューションのビルド**を選択して展開することができます。

これを呼び出すに、アプリ サービス プロバイダーのパッケージ ファミリ名も必要になります。 デザイナー ビューで、 **AppServiceProvider**プロジェクトの**Package.appxmanifest**ファイルを開くことによって取得することができます (**ソリューション エクスプ ローラー**でダブルクリックして)。 **パッケージ**] タブを選択、**パッケージ ファミリ名**の横にある値をコピーし、貼り付けますどこかメモ帳などのようになりました。

## <a name="write-a-client-to-call-the-app-service"></a>アプリ サービスを呼び出すクライアントを作成する

1.  **[ファイル] &gt; [追加] &gt; [新しいプロジェクト]** で、新しい空の Windows ユニバーサル アプリ プロジェクトをソリューションに追加します。 **新しいプロジェクトの追加**] ダイアログ ボックスで、**インストール済み _gt Visual C#] _gt 空白のアプリ (ユニバーサル Windows)** を選択し、 **ClientApp**名前を付けます。

2.  **ClientApp**プロジェクトで、 **MainPage.xaml.cs**の上部に、次の**using**ステートメントを追加します。
    ```cs
    using Windows.ApplicationModel.AppService;
    ```

3.  **テキスト ボックス**とボタンを**MainPage.xaml**と呼ばれるテキスト ボックスを追加します。

4.  ボタンを追加する**button_Click**と呼ばれるボタンのクリックしてハンドラーと、ボタン ハンドラーの署名にキーワード**非同期**を追加します。

5. ボタンのクリック ハンドラーのスタブを、次のコードで置き換えます。 必ず、`inventoryService` フィールドの宣言を含めます。
    ```cs
   private AppServiceConnection inventoryService;

   private async void button_Click(object sender, RoutedEventArgs e)
   {
       // Add the connection.
       if (this.inventoryService == null)
       {
           this.inventoryService = new AppServiceConnection();

           // Here, we use the app service name defined in the app service 
           // provider's Package.appxmanifest file in the <Extension> section.
           this.inventoryService.AppServiceName = "com.microsoft.inventory";

           // Use Windows.ApplicationModel.Package.Current.Id.FamilyName 
           // within the app service provider to get this value.
           this.inventoryService.PackageFamilyName = "Replace with the package family name";

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
           // Get the data  that the service sent to us.
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
    
    行 `this.inventoryService.PackageFamilyName = "Replace with the package family name";` のパッケージ ファミリ名を、「[サービス アプリを展開して、パッケージ ファミリ名を取得する](#deploy-the-service-app-and-get-the-package-family-name)」で得た **AppServiceProvider** プロジェクトのパッケージ ファミリ名に置き換えます。

    > [!NOTE]
    > 文字列リテラルに配置し、変数にペーストすることを確認してください。 変数を使用する場合は機能しません。

    最初に、コードによってアプリ サービスとの接続が確立されます。 接続は、`this.inventoryService` を破棄するまで開いたままになります。 アプリ サービス名に一致する必要があります、`AppService`要素の`Name`属性**AppServiceProvider**プロジェクトの**Package.appxmanifest**ファイルに追加します。 この例では `<uap3:AppService Name="com.microsoft.inventory"/>` です。

    名前付き[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) `message`アプリ サービスに送信するコマンドを指定するために作成されます。 この例のアプリ サービスでは、2 つのアクションのどちらを実行するかをコマンドが示すことを想定しています。 ここでは、クライアント アプリ内のテキスト ボックスからインデックスを取得し、サービスを呼び出して、`Item`コマンドの項目の説明を取得します。 その後、`Price` コマンドで呼び出しを行い、項目の価格を取得します。 ボタンのテキストは結果に設定されています。

    オペレーティング システムがアプリ サービスに呼び出しを接続できたかどうかを示すのは [AppServiceResponseStatus](https://msdn.microsoft.com/library/windows/apps/dn921724) のみです。このため、アプリ サービスが要求を満たすことができたことを確認するために、アプリ サービスから受け取る [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) の `Status` キーをチェックします。

6. **ClientApp**プロジェクトをスタートアップ プロジェクトに設定 (**ソリューション エクスプ ローラー**で右クリックして > **スタートアップ プロジェクトとして設定**) とソリューションを実行します。 数値 1 をテキスト ボックスに入力し、ボタンをクリックします。 サービスから "Chair : Price = 88.99" が返されます。

    ![Chair : price = 88.99 を表示するサンプル アプリ](images/appserviceclientapp.png)

アプリ サービスの呼び出しが失敗した場合は、 **ClientApp**プロジェクトで、以下を確認します。

1.  インベントリ サービスの接続に割り当てられたパッケージ ファミリ名が、 **AppServiceProvider**アプリのパッケージ ファミリ名と一致することを確認します。 **Button \_click**での行が表示`this.inventoryService.PackageFamilyName = "...";`します。
2.  **Button \_click**では、インベントリ サービスの接続に割り当てられているアプリ サービス名が、 **AppServiceProvider**の**Package.appxmanifest**ファイルでアプリ サービス名に一致することを確認します。 `this.inventoryService.AppServiceName = "com.microsoft.inventory";` をご覧ください。
3.  **AppServiceProvider**アプリが展開されたことを確認します。 (**ソリューション エクスプ ローラー**で、ソリューションを右クリックし、[**ソリューションの配置**) します。

## <a name="debug-the-app-service"></a>アプリ サービスのデバッグ

1.  サービスを呼び出す前にアプリ サービス プロバイダーのアプリが配置される必要があるため、ソリューションがデバッグする前に展開されるようにします。 (Visual Studio で、**[ビルド] &gt; [ソリューションの配置]** の順にクリックします)。
2.  **ソリューション エクスプ ローラー**で、 **AppServiceProvider**プロジェクトを右クリックし、**プロパティ**を選択します。 **[デバッグ]** タブで、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に変更します。 (C++ を使ってアプリ サービス プロバイダーを実装した場合、**[デバッグ]** タブから **[アプリケーションの起動]** を **[いいえ]** に変更します)。
3.  **MyAppService**プロジェクトで、 **Inventory.cs**ファイルで**OnRequestReceived**内のブレークポイントを設定します。
4.  **AppServiceProvider**プロジェクトをスタートアップ プロジェクトとなるし、 **f5 キー**を押してを設定します。
5.  (Visual Studio) からではなく [スタート] メニューから**ClientApp**を起動します。
6.  数値 1 をテキスト ボックスに入力し、ボタンを押します。 デバッガーは、アプリ サービス内のブレークポイントでアプリ サービスの呼び出しを停止します。

## <a name="debug-the-client"></a>クライアントのデバッグ

1.  前の手順に従って、アプリ サービスを呼び出すクライアントをデバッグします。
2.  [スタート] メニューから**ClientApp**を起動します。
3.  ( **ApplicationFrameHost.exe**プロセスではなく) **ClientApp.exe**プロセスにデバッガーをアタッチします。 (Visual Studio で、**[デバッグ] &gt; [プロセスにアタッチ]** の順に選びます)。
4.  **ClientApp**プロジェクトでは、 **button \_click**にブレークポイントを設定します。
5.  **ClientApp**のテキスト ボックスに数値 1 を入力ボタンをクリックすると、クライアントと、アプリ サービスの両方のブレークポイントにヒットできるようになりました。

## <a name="general-app-service-troubleshooting"></a>一般的なアプリ サービスのトラブルシューティング

アプリ サービスに接続しようとした後、 **AppUnavailable**状態が発生した場合は、次を確かめます。

- アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。 クライアントを実行する前に、両方が展開されている必要があります。展開されていない場合、クライアントには接続先がありません。 Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。
- **ソリューション エクスプ ローラー**では、アプリ サービス プロバイダー プロジェクトにアプリ サービスを実装するプロジェクトへの参照をプロジェクトにいることを確認します。
- 確認、`<Extensions>`エントリとその子要素が[Package.appxmanifest をアプリ サービスの拡張機能](#appxmanifest)の追加は、上記で説明したアプリ サービス プロバイダー プロジェクトに属する**Package.appxmanifest**ファイルに追加されました。
- アプリ サービス プロバイダーを呼び出すクライアントの[AppServiceConnection.AppServiceName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.appservicename)文字列と一致するように、`<uap3:AppService Name="..." />`アプリ サービス プロバイダー プロジェクトの**Package.appxmanifest**ファイルで指定します。
- [AppServiceConnection.PackageFamilyName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.packagefamilyname)が[Package.appxmanifest をアプリ サービスの拡張機能を追加するの](#appxmanifest)には、上記で説明したアプリ サービス プロバイダーのコンポーネントのパッケージ ファミリ名と一致していることを確認します。
- アウト アプリなどのサービスのいずれかのこの例では、検証、`EntryPoint`で指定されている、`<uap:Extension ...>`アプリ サービス プロバイダー プロジェクトの**Package.appxmanifest**ファイルの要素に一致する名前空間とクラスのパブリックのクラス名アプリ サービス プロジェクトで、 [IBackgroundTask](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask)を実装します。

### <a name="troubleshoot-debugging"></a>デバッグのトラブルシューティング

アプリ サービス プロバイダーまたはアプリ サービス プロジェクトのブレークポイントでデバッガーが停止しない場合は、以下を確認します。

- アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。 クライアントを実行する前に、両方が展開されている必要があります。 Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。
- デバッグするプロジェクトをスタートアップ プロジェクトとして設定されていると、 **f5 キー**が押されたときに、プロジェクトを実行しないようにそのプロジェクトのデバッグ プロパティを設定することを確認します。 プロジェクトを右クリックし、**[プロパティ]**、**[デバッグ]** (または C++ では **[デバッグ]**) の順にクリックします。 C# では、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に設定します。 C++ では、**[アプリケーションの起動]** を **[いいえ]** に設定します。

## <a name="remarks"></a>注釈

この例では、バックグラウンド タスクとして実行されるアプリ サービスを作成して、それを別のアプリから呼び出す概要を示しています。 重要な点に注意してください。

* アプリ サービスをホストするバック グラウンド タスクを作成します。
* 追加の`windows.appService`アプリ サービス プロバイダーの**Package.appxmanifest**ファイルに拡張します。
* クライアント アプリからそれに接続できるように、アプリ サービス プロバイダーのパッケージ ファミリ名を取得します。
* アプリ サービス プロジェクトに、アプリ サービス プロバイダー プロジェクトからプロジェクト間の参照を追加します。
* [Windows.ApplicationModel.AppService.AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)を使用して、サービスを呼び出します。

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
            // Get a deferral so that the service isn't terminated.
            this.backgroundTaskDeferral = taskInstance.GetDeferral();

            // Associate a cancellation handler with the background task.
            taskInstance.Canceled += OnTaskCanceled;

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // Get a deferral because we use an awaitable API below to respond to the message
            // and we don't want this call to get canceled while we are waiting.
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

            // Return the data to the caller.
            await args.Request.SendResponseAsync(returnData);

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
