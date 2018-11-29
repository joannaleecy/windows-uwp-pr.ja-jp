---
ms.assetid: 82ab5fc9-3a7f-4d9e-9882-077ccfdd0ec9
title: Device Portal 用のカスタム プラグインの作成
description: Windows Device Portal を使用して Web ページをホストし、診断情報を提供する UWP アプリを作成する方法について説明します。
ms.date: 03/24/2017
ms.topic: article
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: d9e11445d77434320c8842608bf8183a078c0660
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8190416"
---
# <a name="write-a-custom-plugin-for-device-portal"></a>Device Portal 用のカスタム プラグインの作成

Windows Device Portal を使用して Web ページをホストし、診断情報を提供する UWP アプリを作成する方法について説明します。

Creators Update 以降では、Device Portal を使用してアプリの診断インターフェイスをホストすることができます。 この記事では、アプリ用の DevicePortalProvider の作成に必要な 3 つの要素である、appxmanifest の変更、Device Portal サービスへのアプリの接続の設定、着信要求の処理について説明します。 すぐに作業を開始するためのサンプル アプリも提供されます (近日提供予定)。 

## <a name="create-a-new-uwp-app-project"></a>新しい UWP アプリ プロジェクトを作成する
このガイドでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。

Microsoft Visual Studio 2017 で、新しい UWP アプリ プロジェクトを作成します。 [ファイル] の [新しいプロジェクト] に移動し、[テンプレート]、[Visual C#]、[Windows ユニバーサル]、[空白のアプリ (Windows ユニバーサル)] の順に選択します。 "DevicePortalProvider" という名前を付けます。 これは、アプリ サービスを格納するアプリです。 サポートする Creators Update SDK を選択していることを確認します。  Visual Studio の更新や新しい SDK のインストールが必要になる場合があります。詳しくは、[こちら](https://blogs.windows.com/buildingapps/2017/04/05/updating-tooling-windows-10-creators-update/)をご覧ください。 

## <a name="add-the-deviceportalprovider-extension-to-your-packageappxmanifest-file"></a>package.appxmanifest ファイルに devicePortalProvider 拡張機能を追加する
アプリを Device Portal プラグインとして機能させるために、*package.appxmanifest* ファイルにコードを追加する必要があります。 最初に、ファイルの先頭に次の名前空間の定義を追加します。 また、これらを `IgnorableNamespaces` 属性にも追加します。

```xml
<Package
    ... 
    xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    IgnorableNamespaces="uap mp rescap uap4">
    ...
```

アプリを Device Portal Provider として宣言するには、アプリ サービスと、それを使用する新しい Device Portal Provider 拡張機能を作成する必要があります。 windows.appService 拡張機能と windows.devicePortalProvider 拡張機能の両方を、`Application` の下の `Extensions` 要素に追加します。 各拡張機能で `AppServiceName` 属性が一致していることを確認します。 これにより、このアプリ サービスを起動してハンドラーの名前空間で要求を処理できることを、Device Portal サービスに指示します。 

```xml
...   
<Application 
    Id="App" 
    Executable="$targetnametoken$.exe"
    EntryPoint="DevicePortalProvider.App">
    ...
    <Extensions>
        <uap:Extension Category="windows.appService" EntryPoint="MySampleProvider.SampleProvider">
            <uap:AppService Name="com.sampleProvider.wdp" />
        </uap:Extension>
        <uap4:Extension Category="windows.devicePortalProvider">
            <uap4:DevicePortalProvider 
                DisplayName="My Device Portal Provider Sample App" 
                AppServiceName="com.sampleProvider.wdp" 
                HandlerRoute="/MyNamespace/api/" />
        </uap4:Extension>
    </Extensions>
</Application>
...
```

`HandlerRoute` 属性は、アプリによって要求される REST 名前空間を参照します。 Device Portal サービスによって受信された、その名前空間 (暗黙的にワイルドカードが続く) のすべての HTTP 要求は、アプリに送信されて処理されます。 この場合、`<ip_address>/MyNamespace/api/*` に対する、正常に認証されたすべての HTTP 要求がアプリに送信されます。 ハンドラー ルート間の競合は "最長一致" のチェックにより解決され、要求により多く一致するルートが選択されます。たとえば、"/MyNamespace/api/foo" に対する要求は、"/MyNamespace" ではなく、"/MyNamespace/api" のプロバイダーと一致することを意味します。  

この機能には、2 つの新しい機能が必要です。 また、これらを *package.appxmanifest* ファイルに追加する必要があります。

```xml
...
<Capabilities>
    ...
    <Capability Name="privateNetworkClientServer" />
    <rescap:Capability Name="devicePortalProvider" />
</Capabilities>
...
```

> [!NOTE]
> "devicePortalProvider" 機能は制限された機能 ("rescap") であり、ストアでアプリを公開する前に、ストアから事前に承認を受ける必要があります。 ただし、これは、サイドローディングによって、アプリをローカルでテストすることを禁止するものではありません。 制限された機能について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities)」をご覧ください。

## <a name="set-up-your-background-task-and-winrt-component"></a>バック グラウンド タスクと WinRT コンポーネントを設定する
Device Portal の接続を設定するために、アプリでは、アプリ内で実行されている Device Portal のインスタンスを使用して、Device Portal サービスからアプリ サービスの接続をフックする必要があります。 これを行うには、[**IBackgroundTask**](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.background.ibackgroundtask) を実装するクラスを使用して、アプリケーションに新しい WinRT コンポーネントを追加します。

```csharp
namespace MySampleProvider {
    // Implementing a DevicePortalConnection in a background task
    public sealed class SampleProvider : IBackgroundTask {
        //...
    }
```

その名前が、AppService EntryPoint ("MySampleProvider.SampleProvider") によって設定された名前空間やクラス名が一致することを確認します。 Device Portal Provider に対して最初の要求を行うときに、Device Portal は要求を格納し、アプリのバック グラウンド タスクを起動して、その **Run** メソッドを呼び出し、[**IBackgroundTaskInstance**](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.background.ibackgroundtaskinstance) を渡します。 アプリはこれを使用して [**DevicePortalConnection**](https://docs.microsoft.com/en-us/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnection) インスタンスを設定します。

```csharp
// Implement background task handler with a DevicePortalConnection
public void Run(IBackgroundTaskInstance taskInstance) {
    // Take a deferral to allow the background task to continue executing 
    this.taskDeferral = taskInstance.GetDeferral();
    taskInstance.Canceled += TaskInstance_Canceled;

    // Create a DevicePortal client from an AppServiceConnection 
    var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
    var appServiceConnection = details.AppServiceConnection;
    this.devicePortalConnection = DevicePortalConnection.GetForAppServiceConnection(appServiceConnection);

    // Add Closed, RequestReceived handlers 
    devicePortalConnection.Closed += DevicePortalConnection_Closed;
    devicePortalConnection.RequestReceived += DevicePortalConnection_RequestReceived;
}
```

イベントには 2 つが要求処理ループを完了するアプリで処理する必要があります:**終了**のたびに、Device Portal サービスがシャット ダウンし、 [**RequestReceived**](https://docs.microsoft.com/en-us/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnectionrequestreceivedeventargs)、着信 HTTP のサーフェスを要求し、メインを提供します。Device Portal プロバイダーの機能です。 

## <a name="handle-the-requestreceived-event"></a>RequestReceived イベントを処理する
**RequestReceived** イベントは、プラグインの指定されたハンドラー ルートで行われる各 HTTP 要求について 1 回生成されます。 Device Portal プロバイダーの要求処理ループは、NodeJS Express での要求処理ループと似ています。イベントと共に要求と応答のオブジェクトが提供され、ハンドラーは応答オブジェクトを入力することで応答します。 Device Portal プロバイダーでは、**RequestReceived** イベントとそのハンドラーが [**Windows.Web.Http.HttpRequestMessage**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httprequestmessage) オブジェクトと [**HttpResponseMessage**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpresponsemessage) オブジェクトを使用します。   

```csharp
// Sample RequestReceived echo handler: respond with an HTML page including the query and some additional process information. 
private void DevicePortalConnection_RequestReceived(DevicePortalConnection sender, DevicePortalConnectionRequestReceivedEventArgs args)
{
    var req = args.RequestMessage;
    var res = args.ResponseMessage;

    if (req.RequestUri.AbsolutePath.EndsWith("/echo"))
    {
        // construct an html response message
        string con = "<h1>" + req.RequestUri.AbsoluteUri + "</h1><br/>";
        var proc = Windows.System.Diagnostics.ProcessDiagnosticInfo.GetForCurrentProcess();
        con += String.Format("This process is consuming {0} bytes (Working Set)<br/>", proc.MemoryUsage.GetReport().WorkingSetSizeInBytes);
        con += String.Format("The process PID is {0}<br/>", proc.ProcessId);
        con += String.Format("The executable filename is {0}", proc.ExecutableFileName);
        res.Content = new HttpStringContent(con);
        res.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("text/html");
        res.StatusCode = HttpStatusCode.Ok;            
    }
    //...
}
```

このサンプル要求ハンドラーでは、まず *args*パラメーターから要求と応答のオブジェクトを取り出し、要求 URL やその他の HTML 書式設定を含む文字列を作成します。 これが、[**HttpStringContent**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpstringcontent) インスタンスとして応答オブジェクトに追加されます。 その他の [**IHttpContent**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.ihttpcontent) クラス ("String" や "Buffer" などのクラス) も使用できます。

応答は、HTTP 応答として設定され、200 (OK) 状態コードが指定されます。 元の呼び出しを行ったブラウザーでは、期待どおりにレンダリングされます。 **RequestReceived** イベント ハンドラーが制御を戻すときに、応答メッセージはユーザー エージェントに自動的に返されます。追加の "send" メソッドは必要ありません。

![Device Portal の応答メッセージ](images/device-portal/plugin-response-message.png)

## <a name="providing-static-content"></a>静的コンテンツを提供する
静的コンテンツは、パッケージ内のフォルダーから直接提供することができ、プロバイダーに UI を追加することは非常に簡単です。  静的コンテンツを提供する最も簡単な方法では、プロジェクト内で、URL にマップできるコンテンツ フォルダーを作成することです。

![Device Portal の静的コンテンツ フォルダー](images/device-portal/plugin-static-content.png)
 
次に、**RequestReceived** イベント ハンドラーに、静的コンテンツのルートを検出し、要求を適切にマップするルート ハンドラーを追加します。  

```csharp
if (req.RequestUri.LocalPath.ToLower().Contains("/www/")) {
    var filePath = req.RequestUri.AbsolutePath.Replace('/', '\\').ToLower();
    filePath = filePath.Replace("\\backgroundprovider", "")
    try {
        var fileStream = Windows.ApplicationModel.Package.Current.InstalledLocation.OpenStreamForReadAsync(filePath).GetAwaiter().GetResult();
        res.StatusCode = HttpStatusCode.Ok;
        res.Content = new HttpStreamContent(fileStream.AsInputStream());
        res.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("text/html");
    } catch(FileNotFoundException e) {
        string con = String.Format("<h1>{0} - not found</h1>\r\n", filePath);
        con += "Exception: " + e.ToString();
        res.Content = new HttpStringContent(con);
        res.StatusCode = HttpStatusCode.NotFound;
        res.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("text/html");
    }
}
```
コンテンツのフォルダー内のすべてのファイルが "コンテンツ" としてマークされ、Visual Studio の [プロパティ] メニューで [新しい場合はコピーする] または [常にコピーする] に設定されていることを確認します。  これにより、展開するときに、ファイルが AppX パッケージに含められます。  

![静的コンテンツのファイルのコピーを構成する](images/device-portal/plugin-file-copying.png)

## <a name="using-existing-device-portal-resources-and-apis"></a>既存の Device Portal のリソースと API を使用する
Device Portal プロバイダーによって提供される静的コンテンツは、コア Device Portal サービスと同じポートで提供されます。  つまり、HTML の単純な `<link>` および `<script>` タグで、Device Portal に含まれている既存の JS および CSS を参照できます。 一般的に、すべてのコア Device Portal の REST API を便利な webbRest オブジェクトにラップする *rest.js* と、Device Portal の UI の他の部分に合わせてコンテンツのスタイルを設定できる *common.css* ファイルを使用することをお勧めします。 この例については、サンプルに含まれる *index.html* ページをご覧ください。 この例では、*rest.js* を使用して、Device Portal からデバイス名と実行中のプロセスを取得します。 

![Device Portal プラグインの出力](images/device-portal/plugin-output.png)
 
重要な点は、webbRest で HttpPost/DeleteExpect200 メソッドを使用すると、自動的に [CSRF 処理](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/preventing-cross-site-request-forgery-csrf-attacks) が実行されるため、Web ページで状態が変化する REST API を呼び出すことができます。  

> [!NOTE] 
> Device Portal に含まれている静的コンテンツは、重大な変更に対する保証は行われません。 API は頻繁に変更することは想定されていませんが、特に *common.js* や *controls.js* ファイルでは変更されることもあるため、プロバイダーでは使用しないでください。 

## <a name="debugging-the-device-portal-connection"></a>Device Portal の接続をデバッグする
バック グラウンド タスクをデバッグするには、Visual Studio でコードを実行する方法を変更する必要があります。 アプリ サービスの接続をデバッグして、プロバイダーが HTTP 要求を処理する方法を調べるには、次の手順に従います。

1.  [デバッグ] メニューから [DevicePortalProvider のプロパティ] を選択します。 
2.  [デバッグ] タブの [開始動作] で、[起動しないが、開始時にマイ コードをデバッグする] を選択します。  
![プラグインをデバッグ モードにする](images/device-portal/plugin-debug-mode.png)
3.  RequestReceived ハンドラー関数にブレークポイントを設定します。
![RequestReceived ハンドラーでのブレークポイント](images/device-portal/plugin-requestreceived-breakpoint.png)
> [!NOTE] 
> ビルドのアーキテクチャがターゲットのアーキテクチャと正確に一致することを確認してください。 64 ビット PC を使用している場合は、AMD64 ビルドを使って展開する必要があります。 
4.  F5 キーを押してアプリを展開します。
5.  Device Portal をオフにし、再度オンにしてアプリを検出できるようにします (アプリ マニフェストを変更した場合にのみ必要。その他の場合は、単に再配置し、この手順を省略できます)。 
6.  ブラウザーで、プロバイダーの名前空間にアクセスすると、ブレークポイントにヒットします。

## <a name="related-topics"></a>関連トピック
* [Windows Device Portal の概要](device-portal.md)
* [アプリ サービスの作成と利用](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)


