---
title: アプリ サービスの作成と利用
description: 他のユニバーサル Windows プラットフォーム (UWP) アプリにサービスを提供できる UWP アプリを作成する方法と、それらのサービスを利用する方法について説明します。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
keywords: アプリへの通信、IPC、メッセージング、バック グラウンドの通信、アプリへのアプリ サービス バック グラウンドのプロセス間の通信
ms.date: 01/16/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 96ecad8494ad82dc4927b3675ad322f07a8ca7f3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57643577"
---
# <a name="create-and-consume-an-app-service"></a>アプリ サービスの作成と利用

アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。 これは、デバイス上にある Web サービスのようなものです。 アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。 たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。 また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。  アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。

Windows 10 バージョン 1607 以降では、ホスト アプリと同じプロセスで実行されるアプリ サービスを作成できます。 この記事では、別のバックグラウンド プロセスで実行されるアプリ サービスの作成と利用に重点を置いて説明します。 プロバイダーと同じプロセスでアプリ サービスを実行する詳細については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。

アプリ サービスのコード サンプルについては、「[ユニバーサル Windows プラットフォーム (UWP) アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)」を参照してください。

## <a name="create-a-new-app-service-provider-project"></a>新しいアプリ サービス プロバイダー プロジェクトの作成

このトピックでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。

1. Visual Studio 2015 以降では、新しい UWP アプリ プロジェクトを作成し、名前**AppServiceProvider**します。
    1. 選択**ファイル > 新規 > プロジェクト.** 
    2. **新しいプロジェクト**ダイアログ ボックスで、**インストール済み > Visual C# > 空のアプリ (ユニバーサル Windows)** します。 これは、他の UWP アプリがアプリ サービスを利用できるアプリとなります。
    3. プロジェクトに名前を**AppServiceProvider**の場所の選択およびクリックして**OK**します。

2. 選択を求められたら、**ターゲット**と**最小バージョン**、プロジェクトの選択には少なくとも**10.0.14393**します。 新たに使用する場合**SupportsMultipleInstances**属性に、Visual Studio 2017 とターゲットを使用する必要があります**10.0.15063 追加されたため**(**Windows 10 Creators Update**) またはそれ以降。

<span id="appxmanifest"/>

## <a name="add-an-app-service-extension-to-packageappxmanifest"></a>Package.appxmanifest にアプリ サービスの拡張機能を追加します。

**AppServiceProvider**プロジェクトを開き、 **Package.appxmanifest**ファイルをテキスト エディターで。 

1. を右クリックし、**ソリューション エクスプ ローラー**します。 
2. 選択**プログラムから開く**します。 
3. 選択**XML (テキスト) エディター**します。 

次の追加`AppService`内に拡張機能、`<Application>`要素。 この例では、`com.microsoft.inventory` サービスをアドバタイズし、このアプリをアプリ サービス プロバイダーとして識別します。 実際のサービスは、バックグラウンド タスクとして実装されます。 アプリ サービスのプロジェクトは、サービスを他のアプリに公開します。 サービス名には逆のドメイン名スタイルを使うことをお勧めします。

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

`Category`属性は、アプリのサービス プロバイダーとしては、このアプリケーションを識別します。

`EntryPoint`属性は、次を実装すると、サービスを実装する名前空間で修飾クラスを識別します。

`SupportsMultipleInstances`属性は、app service が呼び出されるたびに実行する新しいプロセスを示します。 これは必要ありませんが、その機能を必要とし、10.0.15063 追加されたため、対象とする場合は、使用する SDK (**Windows 10 Creators Update**) またはそれ以降。 また、先頭に `uap4` 名前空間を付ける必要があります。

## <a name="create-the-app-service"></a>アプリ サービスの作成

1.  アプリ サービスは、バックグラウンド タスクとして実装できます。 これにより、フォアグラウンド アプリケーションは、別のアプリケーションのアプリ サービスを呼び出すことができます。 バック グラウンド タスクとして、app service を作成するには、ソリューションに新しい Windows ランタイム コンポーネント プロジェクトを追加 (**ファイル&gt;追加&gt;新しいプロジェクト**) という名前の**MyAppService**します。 **新しいプロジェクトの追加** ダイアログ ボックスで、選択**インストール済み > Visual C# > Windows ランタイム コンポーネント (ユニバーサル Windows)** します。
2.  **AppServiceProvider**プロジェクトに、新しいプロジェクト間参照を追加**MyAppService**プロジェクト (で、**ソリューション エクスプ ローラー**、右クリックし、 **AppServiceProvider**プロジェクト >**追加** > **参照** > **プロジェクト** >  **ソリューション**、 **MyAppService** > **OK**)。 参照を追加しない場合でも、アプリ サービスは実行時に接続されないため、この手順は重要です。
3.  **MyAppService**プロジェクトで、次の追加**を使用して**ステートメントの先頭に**Class1.cs**:
    ```cs
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    ```

4.  名前を変更**Class1.cs**に**Inventory.cs**のスタブのコードに置き換えます**Class1**という名前の新しいバック グラウンド タスク クラスを使用して**インベントリ**:

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

    **実行**バック グラウンド タスクが作成されるときに呼び出されます。 バックグラウンド タスクは **Run** が完了すると終了するため、バックグラウンド タスクが要求に引き続き対応できるように、コードは保留されます。 バック グラウンド タスクとして実装されている app service は、その時間枠内でもう一度呼び出されたか、遅延を除外しない限り、呼び出しを受信した後、約 30 秒間有効で維持されます。App service は、呼び出し元と同じプロセスで実装されている場合、app service の有効期間は、呼び出し元の有効期間に関連付けられています。

    アプリ サービスの有効期間は、呼び出し元に依存します。

    * 呼び出し元がフォア グラウンドである場合は、アプリ サービスの有効期間は、呼び出し元の場合と同じです。
    * 呼び出し元は、バック グラウンドでは、app service は 30 秒の実行を取得します。 保留されると、1 回 5 秒追加されます。

    **OnTaskCanceled**タスクが取り消されたときに呼び出されます。 クライアント アプリを破棄するときにタスクが取り消された、 [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)、クライアント アプリケーションが中断された、OS がシャット ダウンしたり、スリープ状態になり、または OS のタスクを実行するリソースが不足します。

## <a name="write-the-code-for-the-app-service"></a>アプリ サービスのコードを記述する

**OnRequestReceived** app service のコードの行き先が。 スタブを置換**OnRequestReceived**で**MyAppService**の**Inventory.cs**この例のコードを使用します。 このコードは、インベントリの項目のインデックスを取得し、コマンド文字列と共にサービスに渡して、指定したインベントリ項目の名前と価格を取得します。 独自のプロジェクトには、エラー処理コードを追加します。

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

なお**OnRequestReceived**は**async** 、この待機可能なメソッドを呼び出すため、 [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)この例では。

サービスが使用できるように、遅延が実行される**async**メソッド、 **OnRequestReceived**ハンドラー。 これにより、**OnRequestReceived** への呼び出しは、メッセージの処理が完了するまで完了しません。  [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)呼び出し元に結果を送信します。 **SendResponseAsync** は、呼び出しの完了時に通知しません。 信号を遅延の完了が[SendMessageAsync](https://msdn.microsoft.com/library/windows/apps/dn921712)を**OnRequestReceived**が完了します。 呼び出し**SendResponseAsync**いても、遅延を完了する必要がありますので、try/finally ブロックでラップされて**SendResponseAsync**例外をスローします。

App services の使用[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)情報を交換するオブジェクト。 渡すことができるデータのサイズは、システム リソースによってのみ制限されます。 **ValueSet** で使うことができる定義済みのキーはありません。 アプリ サービスのプロトコルの定義に使うキーの値を決定する必要があります。 呼び出し元は、そのプロトコルを念頭に置いて記述する必要があります。 この例では、アプリ サービスがインベントリ項目またはその価格の名前を提供するかどうかを示す値を持つ、`Command` という名前のキーを選びました。 インベントリ名のインデックスは、`ID` キーに保存されています。 戻り値は `Result` キーに保存されます。

[AppServiceClosedStatus](https://msdn.microsoft.com/library/windows/apps/dn921703)列挙型は、app service への呼び出しが成功または失敗するかどうかを示すために、呼び出し元に返されます。 アプリ サービスへの呼び出しが失敗する例として、OS がサービスのエンドポイントを中止した、リソースが超過したなどがあります。 使用して追加のエラー情報を返すことができます、 [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)します。 この例では、`Status` という名前のキーを使って、より詳細なエラー情報を呼び出し元に返します。

呼び出し[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)を返します、 [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)呼び出し元にします。

## <a name="deploy-the-service-app-and-get-the-package-family-name"></a>サービス アプリを展開して、パッケージ ファミリ名を取得する

クライアントから呼び出せる前に、アプリのサービス プロバイダーを配置する必要があります。 選択してデプロイする**ビルド > ソリューションの配置**Visual Studio でします。

これを呼び出すために、アプリのサービス プロバイダーのパッケージ ファミリ名も必要になります。 開いて表示できます、 **AppServiceProvider**プロジェクトの**Package.appxmanifest**デザイナーのビュー内のファイル (でそれをダブルクリックして、**ソリューション エクスプ ローラー**)。 選択、**パッケージ** タブで、次に、値をコピーします。**パッケージ ファミリ名**、などに貼り付けメモ帳の今とします。

## <a name="write-a-client-to-call-the-app-service"></a>アプリ サービスを呼び出すクライアントを作成する

1.  **[ファイル] &gt; [追加] &gt; [新しいプロジェクト]** で、新しい空の Windows ユニバーサル アプリ プロジェクトをソリューションに追加します。 **新しいプロジェクトの追加** ダイアログ ボックスで、選択**インストール済み > Visual C# > 空のアプリ (ユニバーサル Windows)** 名前を付けます**ClientApp**します。

2.  **ClientApp**プロジェクトで、次の追加**を使用して**ステートメントの先頭に**MainPage.xaml.cs**:
    ```cs
    using Windows.ApplicationModel.AppService;
    ```

3.  呼ばれるテキスト ボックスを追加**textBox**ボタンを**MainPage.xaml**します。

4.  ボタンを追加するハンドラーというボタンをクリックします**button_Click**、キーワードを追加および**非同期**をボタン ハンドラーのシグネチャにします。

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
    > 必ず、文字列リテラルに配置し、変数に貼り付けます。 変数を使用する場合は機能しません。

    最初に、コードによってアプリ サービスとの接続が確立されます。 接続は、`this.inventoryService` を破棄するまで開いたままになります。 App service の名前に一致する必要があります、`AppService`要素の`Name`に追加する属性、 **AppServiceProvider**プロジェクトの**Package.appxmanifest**ファイル。 この例では `<uap3:AppService Name="com.microsoft.inventory"/>` です。

    A [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)という`message`を app service に送信するコマンドを指定するが作成されます。 この例のアプリ サービスでは、2 つのアクションのどちらを実行するかをコマンドが示すことを想定しています。 クライアント アプリでテキスト ボックスからインデックスを取得し、使用して、サービスを呼び出して、`Item`項目の説明を取得するコマンド。 その後、`Price` コマンドで呼び出しを行い、項目の価格を取得します。 ボタンのテキストは結果に設定されています。

    [AppServiceResponseStatus](https://msdn.microsoft.com/library/windows/apps/dn921724)オペレーティング システムがチェックを app service への呼び出しに接続できるかどうかを示します、`Status`キー、 [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)アプリからの受信サービス要求を処理することであったことをします。

6. 設定、 **ClientApp**プロジェクトをスタートアップ プロジェクト (で右クリックし、**ソリューション エクスプ ローラー** > **スタートアップ プロジェクトとして設定**) し、ソリューションを実行します。 数値 1 をテキスト ボックスに入力し、ボタンをクリックします。 取得する必要があります"椅子。価格 = 88.99"、サービスから返信します。

    ![Chair : price = 88.99 を表示するサンプル アプリ](images/appserviceclientapp.png)

アプリ サービスの呼び出しに失敗した場合、次を確認してください。、 **ClientApp**プロジェクト。

1.  インベントリ サービスの接続に割り当てられたパッケージ ファミリ名のパッケージ ファミリ名と一致していることを確認、 **AppServiceProvider**アプリ。 内の行を参照してください**ボタン\_クリックして**で`this.inventoryService.PackageFamilyName = "...";`します。
2.  **ボタン\_クリックして**、インベントリ サービスの接続に割り当てられている app service の名前の app service の名前と一致していることを確認、 **AppServiceProvider**の**Package.appxmanifest**ファイル。 `this.inventoryService.AppServiceName = "com.microsoft.inventory";` をご覧ください。
3.  いることを確認、 **AppServiceProvider**アプリが展開されています。 (で、**ソリューション エクスプ ローラー**ソリューションを右クリックし、選択、**ソリューションの配置**)。

## <a name="debug-the-app-service"></a>アプリ サービスのデバッグ

1.  サービスを呼び出す前にアプリ サービス プロバイダーのアプリが配置される必要があるため、ソリューションがデバッグする前に展開されるようにします。 (Visual Studio で、**[ビルド] &gt; [ソリューションの配置]** の順にクリックします)。
2.  **ソリューション エクスプ ローラー**を右クリックし、 **AppServiceProvider**プロジェクト**プロパティ**します。 **[デバッグ]** タブで、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に変更します。 (C++ を使ってアプリ サービス プロバイダーを実装した場合、**[デバッグ]** タブから **[アプリケーションの起動]** を **[いいえ]** に変更します)。
3.  **MyAppService**プロジェクトの**Inventory.cs**にブレークポイントを設定ファイルで、 **OnRequestReceived**します。
4.  設定、 **AppServiceProvider**プロジェクトをスタートアップ プロジェクトとキーを押して**F5**します。
5.  開始**ClientApp** (Visual Studio) からではなく [スタート] メニューから。
6.  数値 1 をテキスト ボックスに入力し、ボタンを押します。 デバッガーは、アプリ サービス内のブレークポイントでアプリ サービスの呼び出しを停止します。

## <a name="debug-the-client"></a>クライアントのデバッグ

1.  前の手順に従って、アプリ サービスを呼び出すクライアントをデバッグします。
2.  起動**ClientApp** [スタート] メニュー。
3.  デバッガーをアタッチ、 **ClientApp.exe**プロセス (いない、 **ApplicationFrameHost.exe**プロセス)。 (Visual Studio で、**[デバッグ] &gt; [プロセスにアタッチ]** の順に選びます)。
4.  **ClientApp**プロジェクトでのブレークポイントを設定、**ボタン\_クリックして**。
5.  テキスト ボックスに数字 1 を入力すると、クライアントと、app service の両方でブレークポイントにヒット今すぐ**ClientApp**ボタンをクリックします。

## <a name="general-app-service-troubleshooting"></a>一般的なアプリ サービスのトラブルシューティング

発生した場合、 **AppUnavailable** app service に接続しようとしました。 後のステータスは、次を確認します。

- アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。 クライアントを実行する前に、両方が展開されている必要があります。展開されていない場合、クライアントには接続先がありません。 Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。
- **ソリューション エクスプ ローラー**、アプリ サービスのプロバイダー プロジェクトが、app service を実装するプロジェクトへのプロジェクト間参照であることを確認します。
- いることを確認、`<Extensions>`エントリとその子要素が追加されました、 **Package.appxmanifest**で上で指定したアプリ サービス プロバイダーのプロジェクトに属しているファイル[するアプリ サービスの拡張機能の追加Package.appxmanifest](#appxmanifest)します。
- いることを確認、 [AppServiceConnection.AppServiceName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.appservicename)をアプリのサービス プロバイダーを呼び出すクライアントでの文字列に一致する、`<uap3:AppService Name="..." />`アプリ サービス プロバイダー プロジェクトで指定された**Package.appxmanifest**ファイル。
- いることを確認、 [AppServiceConnection.PackageFamilyName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.packagefamilyname)で上で指定したアプリのサービス プロバイダー コンポーネントのパッケージ ファミリ名と一致する[Package.appxmanifest にアプリ サービスの拡張機能を追加します。](#appxmanifest)
- この例では、1 つなど、アウト プロセス アプリケーション サービスのことを検証、`EntryPoint`で指定されている、`<uap:Extension ...>`アプリ サービス プロバイダー プロジェクトの要素**Package.appxmanifest**ファイル名前空間に一致し、実装するパブリック クラスのクラス名[IBackgroundTask](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask)アプリ サービス プロジェクト。

### <a name="troubleshoot-debugging"></a>デバッグのトラブルシューティング

アプリ サービス プロバイダーまたはアプリ サービス プロジェクトのブレークポイントでデバッガーが停止しない場合は、以下を確認します。

- アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。 クライアントを実行する前に、両方が展開されている必要があります。 Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。
- デバッグするプロジェクトがスタートアップ プロジェクトとして設定されていると、プロジェクトを実行しない、そのプロジェクトのデバッグのプロパティが設定されていることを確認時に**F5**が押されました。 プロジェクトを右クリックし、**[プロパティ]**、**[デバッグ]** (または C++ では **[デバッグ]**) の順にクリックします。 C# では、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に設定します。 C++ では、**[アプリケーションの起動]** を **[いいえ]** に設定します。

## <a name="remarks"></a>注釈

この例では、バックグラウンド タスクとして実行されるアプリ サービスを作成して、それを別のアプリから呼び出す概要を示しています。 注意することは、次のとおりです。

* アプリ サービスをホストするバック グラウンド タスクを作成します。
* 追加、`windows.appService`をアプリ サービス プロバイダーの拡張機能**Package.appxmanifest**ファイル。
* クライアント アプリからそれに接続できるように、アプリのサービス プロバイダーのパッケージ ファミリ名を取得します。
* アプリのサービス プロバイダーのプロジェクトからアプリ サービスのプロジェクトにプロジェクト間参照を追加します。
* 使用[Windows.ApplicationModel.AppService.AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)サービスを呼び出します。

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

* [ホスト アプリケーションと同じプロセスで実行する app service を変換します。](convert-app-service-in-process.md)
* [バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)
* [アプリ サービスのコード サンプル (C#、C++、および VB)](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)
