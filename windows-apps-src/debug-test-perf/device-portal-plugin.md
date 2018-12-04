---
ms.assetid: 82ab5fc9-3a7f-4d9e-9882-077ccfdd0ec9
title: Device Portal 用のカスタム プラグインの作成
description: Windows Device Portal を使用して Web ページをホストし、診断情報を提供する UWP アプリを作成する方法について説明します。
ms.date: 03/24/2017
ms.topic: article
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: d9e11445d77434320c8842608bf8183a078c0660
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8480917"
---
# <a name="write-a-custom-plugin-for-device-portal"></a><span data-ttu-id="0bfad-104">Device Portal 用のカスタム プラグインの作成</span><span class="sxs-lookup"><span data-stu-id="0bfad-104">Write a custom plugin for Device Portal</span></span>

<span data-ttu-id="0bfad-105">Windows Device Portal を使用して Web ページをホストし、診断情報を提供する UWP アプリを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-105">Learn how to write a UWP app that uses th Windows Device Portal to host a web page and provide diagnostic information.</span></span>

<span data-ttu-id="0bfad-106">Creators Update 以降では、Device Portal を使用してアプリの診断インターフェイスをホストすることができます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-106">Starting with the Creators Update, you can use Device Portal to host your app's diagnostic interfaces.</span></span> <span data-ttu-id="0bfad-107">この記事では、アプリ用の DevicePortalProvider の作成に必要な 3 つの要素である、appxmanifest の変更、Device Portal サービスへのアプリの接続の設定、着信要求の処理について説明します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-107">This article covers the three pieces needed to create a DevicePortalProvider for your app – the appxmanifest changes, setting up your app’s connection to the Device Portal service, and handling an incoming request.</span></span> <span data-ttu-id="0bfad-108">すぐに作業を開始するためのサンプル アプリも提供されます (近日提供予定)。</span><span class="sxs-lookup"><span data-stu-id="0bfad-108">A sample app is also provided to get started (Coming soon) .</span></span> 

## <a name="create-a-new-uwp-app-project"></a><span data-ttu-id="0bfad-109">新しい UWP アプリ プロジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="0bfad-109">Create a new UWP app project</span></span>
<span data-ttu-id="0bfad-110">このガイドでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-110">In this guide, we'll create everything in one solution for simplicity.</span></span>

<span data-ttu-id="0bfad-111">Microsoft Visual Studio 2017 で、新しい UWP アプリ プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-111">In Microsoft Visual Studio 2017, create a new UWP app project.</span></span> <span data-ttu-id="0bfad-112">[ファイル] の [新しいプロジェクト] に移動し、[テンプレート]、[Visual C#]、[Windows ユニバーサル]、[空白のアプリ (Windows ユニバーサル)] の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-112">Go to File > New Project and select Templates > Visual C# > Windows Universal > Blank app (Windows Universal).</span></span> <span data-ttu-id="0bfad-113">"DevicePortalProvider" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-113">Name it "DevicePortalProvider".</span></span> <span data-ttu-id="0bfad-114">これは、アプリ サービスを格納するアプリです。</span><span class="sxs-lookup"><span data-stu-id="0bfad-114">This will be the app that contains the app service.</span></span> <span data-ttu-id="0bfad-115">サポートする Creators Update SDK を選択していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-115">Ensure that you choose the Creators Update SDK to support.</span></span>  <span data-ttu-id="0bfad-116">Visual Studio の更新や新しい SDK のインストールが必要になる場合があります。詳しくは、[こちら](https://blogs.windows.com/buildingapps/2017/04/05/updating-tooling-windows-10-creators-update/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bfad-116">You may need to update Visual Studio or install the new SDK - see [here](https://blogs.windows.com/buildingapps/2017/04/05/updating-tooling-windows-10-creators-update/) for details.</span></span> 

## <a name="add-the-deviceportalprovider-extension-to-your-packageappxmanifest-file"></a><span data-ttu-id="0bfad-117">package.appxmanifest ファイルに devicePortalProvider 拡張機能を追加する</span><span class="sxs-lookup"><span data-stu-id="0bfad-117">Add the devicePortalProvider extension to your package.appxmanifest file</span></span>
<span data-ttu-id="0bfad-118">アプリを Device Portal プラグインとして機能させるために、*package.appxmanifest* ファイルにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bfad-118">You will need to add some code to your *package.appxmanifest* file in order to make your app functional as a Device Portal plugin.</span></span> <span data-ttu-id="0bfad-119">最初に、ファイルの先頭に次の名前空間の定義を追加します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-119">First, add the following namespace definitions at the top of the file.</span></span> <span data-ttu-id="0bfad-120">また、これらを `IgnorableNamespaces` 属性にも追加します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-120">Also add them to the `IgnorableNamespaces` attribute.</span></span>

```xml
<Package
    ... 
    xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    IgnorableNamespaces="uap mp rescap uap4">
    ...
```

<span data-ttu-id="0bfad-121">アプリを Device Portal Provider として宣言するには、アプリ サービスと、それを使用する新しい Device Portal Provider 拡張機能を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bfad-121">In order to declare that your app is a Device Portal Provider, you need to create an app service and a new Device Portal Provider extension that uses it.</span></span> <span data-ttu-id="0bfad-122">windows.appService 拡張機能と windows.devicePortalProvider 拡張機能の両方を、`Application` の下の `Extensions` 要素に追加します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-122">Add both the windows.appService extension and the windows.devicePortalProvider extension in the `Extensions` element under `Application`.</span></span> <span data-ttu-id="0bfad-123">各拡張機能で `AppServiceName` 属性が一致していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-123">Make sure the `AppServiceName` attributes match in each extension.</span></span> <span data-ttu-id="0bfad-124">これにより、このアプリ サービスを起動してハンドラーの名前空間で要求を処理できることを、Device Portal サービスに指示します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-124">This indicates to the Device Portal service that this app service can be launched to handle requests on the handler namespace.</span></span> 

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

<span data-ttu-id="0bfad-125">`HandlerRoute` 属性は、アプリによって要求される REST 名前空間を参照します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-125">The `HandlerRoute` attribute references the REST namespace claimed by your app.</span></span> <span data-ttu-id="0bfad-126">Device Portal サービスによって受信された、その名前空間 (暗黙的にワイルドカードが続く) のすべての HTTP 要求は、アプリに送信されて処理されます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-126">Any HTTP requests on that namespace (implicitly followed by a wildcard) received by the Device Portal service will be sent to your app to be handled.</span></span> <span data-ttu-id="0bfad-127">この場合、`<ip_address>/MyNamespace/api/*` に対する、正常に認証されたすべての HTTP 要求がアプリに送信されます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-127">In this case, any successfully authenticated HTTP request to `<ip_address>/MyNamespace/api/*` will be sent to your app.</span></span> <span data-ttu-id="0bfad-128">ハンドラー ルート間の競合は "最長一致" のチェックにより解決され、要求により多く一致するルートが選択されます。たとえば、"/MyNamespace/api/foo" に対する要求は、"/MyNamespace" ではなく、"/MyNamespace/api" のプロバイダーと一致することを意味します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-128">Conflicts between handler routes are settled via a "longest wins" check: whichever route matches more of the requests is selected, meaning that a request to "/MyNamespace/api/foo" will match against a provider with "/MyNamespace/api" rather than one with "/MyNamespace".</span></span>  

<span data-ttu-id="0bfad-129">この機能には、2 つの新しい機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="0bfad-129">Two new capabilities are required for this functionality.</span></span> <span data-ttu-id="0bfad-130">また、これらを *package.appxmanifest* ファイルに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bfad-130">they must also be added to your *package.appxmanifest* file.</span></span>

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
> <span data-ttu-id="0bfad-131">"devicePortalProvider" 機能は制限された機能 ("rescap") であり、ストアでアプリを公開する前に、ストアから事前に承認を受ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bfad-131">The capability "devicePortalProvider" is restricted ("rescap"), which means you must get prior approval from the Store before your app can be published there.</span></span> <span data-ttu-id="0bfad-132">ただし、これは、サイドローディングによって、アプリをローカルでテストすることを禁止するものではありません。</span><span class="sxs-lookup"><span data-stu-id="0bfad-132">However, this does not prevent you from testing your app locally through sideloading.</span></span> <span data-ttu-id="0bfad-133">制限された機能について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bfad-133">For more information about restricted capabilities, see [App capability declarations](https://msdn.microsoft.com/en-us/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities).</span></span>

## <a name="set-up-your-background-task-and-winrt-component"></a><span data-ttu-id="0bfad-134">バック グラウンド タスクと WinRT コンポーネントを設定する</span><span class="sxs-lookup"><span data-stu-id="0bfad-134">Set up your background task and WinRT Component</span></span>
<span data-ttu-id="0bfad-135">Device Portal の接続を設定するために、アプリでは、アプリ内で実行されている Device Portal のインスタンスを使用して、Device Portal サービスからアプリ サービスの接続をフックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bfad-135">In order to set up the Device Portal connection, your app must hook up an app service connection from the Device Portal service with the instance of Device Portal running within your app.</span></span> <span data-ttu-id="0bfad-136">これを行うには、[**IBackgroundTask**](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.background.ibackgroundtask) を実装するクラスを使用して、アプリケーションに新しい WinRT コンポーネントを追加します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-136">To do this, add a new WinRT Component to your application with a class that implements [**IBackgroundTask**](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.background.ibackgroundtask).</span></span>

```csharp
namespace MySampleProvider {
    // Implementing a DevicePortalConnection in a background task
    public sealed class SampleProvider : IBackgroundTask {
        //...
    }
```

<span data-ttu-id="0bfad-137">その名前が、AppService EntryPoint ("MySampleProvider.SampleProvider") によって設定された名前空間やクラス名が一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-137">Make sure that its name matches the namespace and class name set up by the AppService EntryPoint ("MySampleProvider.SampleProvider").</span></span> <span data-ttu-id="0bfad-138">Device Portal Provider に対して最初の要求を行うときに、Device Portal は要求を格納し、アプリのバック グラウンド タスクを起動して、その **Run** メソッドを呼び出し、[**IBackgroundTaskInstance**](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.background.ibackgroundtaskinstance) を渡します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-138">When you make your first request to your Device Portal provider, Device Portal will stash the request, launch your app's background task, call its **Run** method, and pass in an [**IBackgroundTaskInstance**](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.background.ibackgroundtaskinstance).</span></span> <span data-ttu-id="0bfad-139">アプリはこれを使用して [**DevicePortalConnection**](https://docs.microsoft.com/en-us/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnection) インスタンスを設定します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-139">Your app then uses it to set up a [**DevicePortalConnection**](https://docs.microsoft.com/en-us/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnection) instance.</span></span>

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

<span data-ttu-id="0bfad-140">イベントには 2 つが要求処理ループを完了するアプリで処理する必要があります:**終了**のたびに、Device Portal サービスがシャット ダウンし、 [**RequestReceived**](https://docs.microsoft.com/en-us/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnectionrequestreceivedeventargs)、着信 HTTP のサーフェスを要求し、メインを提供します。Device Portal プロバイダーの機能です。</span><span class="sxs-lookup"><span data-stu-id="0bfad-140">There are two events that must be handled by the app to complete the request handling loop: **Closed**, for whenever the Device Portal service shuts down, and [**RequestReceived**](https://docs.microsoft.com/en-us/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnectionrequestreceivedeventargs), which surfaces incoming HTTP requests and provides the main functionality of the Device Portal provider.</span></span> 

## <a name="handle-the-requestreceived-event"></a><span data-ttu-id="0bfad-141">RequestReceived イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="0bfad-141">Handle the RequestReceived event</span></span>
<span data-ttu-id="0bfad-142">**RequestReceived** イベントは、プラグインの指定されたハンドラー ルートで行われる各 HTTP 要求について 1 回生成されます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-142">The **RequestReceived** event will be raised once for every HTTP request that is made on your plugin's specified Handler Route.</span></span> <span data-ttu-id="0bfad-143">Device Portal プロバイダーの要求処理ループは、NodeJS Express での要求処理ループと似ています。イベントと共に要求と応答のオブジェクトが提供され、ハンドラーは応答オブジェクトを入力することで応答します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-143">The request handling loop for Device Portal providers is similar to that in NodeJS Express: the request and response objects are provided together with the event, and the handler responds by filling in the response object.</span></span> <span data-ttu-id="0bfad-144">Device Portal プロバイダーでは、**RequestReceived** イベントとそのハンドラーが [**Windows.Web.Http.HttpRequestMessage**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httprequestmessage) オブジェクトと [**HttpResponseMessage**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpresponsemessage) オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-144">In Device Portal providers, the **RequestReceived** event and its handlers use [**Windows.Web.Http.HttpRequestMessage**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httprequestmessage) and [**HttpResponseMessage**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpresponsemessage) objects.</span></span>   

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

<span data-ttu-id="0bfad-145">このサンプル要求ハンドラーでは、まず *args*パラメーターから要求と応答のオブジェクトを取り出し、要求 URL やその他の HTML 書式設定を含む文字列を作成します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-145">In this sample request handler, we first pull the request and response objects out of the *args* parameter, then create a string with the request URL and some additional HTML formatting.</span></span> <span data-ttu-id="0bfad-146">これが、[**HttpStringContent**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpstringcontent) インスタンスとして応答オブジェクトに追加されます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-146">This is added into the Response object as an [**HttpStringContent**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpstringcontent) instance.</span></span> <span data-ttu-id="0bfad-147">その他の [**IHttpContent**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.ihttpcontent) クラス ("String" や "Buffer" などのクラス) も使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-147">Other [**IHttpContent**](https://docs.microsoft.com/en-us/uwp/api/windows.web.http.ihttpcontent) classes, such as those for "String" and "Buffer," are also allowed.</span></span>

<span data-ttu-id="0bfad-148">応答は、HTTP 応答として設定され、200 (OK) 状態コードが指定されます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-148">The response is then set as an HTTP response and given a 200 (OK) status code.</span></span> <span data-ttu-id="0bfad-149">元の呼び出しを行ったブラウザーでは、期待どおりにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-149">It should render as expected in the browser that made the original call.</span></span> <span data-ttu-id="0bfad-150">**RequestReceived** イベント ハンドラーが制御を戻すときに、応答メッセージはユーザー エージェントに自動的に返されます。追加の "send" メソッドは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="0bfad-150">Note that when the **RequestReceived** event handler returns, the response message is automatically returned to the user agent: no additional "send" method is needed.</span></span>

![Device Portal の応答メッセージ](images/device-portal/plugin-response-message.png)

## <a name="providing-static-content"></a><span data-ttu-id="0bfad-152">静的コンテンツを提供する</span><span class="sxs-lookup"><span data-stu-id="0bfad-152">Providing static content</span></span>
<span data-ttu-id="0bfad-153">静的コンテンツは、パッケージ内のフォルダーから直接提供することができ、プロバイダーに UI を追加することは非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="0bfad-153">Static content can be served directly from a folder within your package, making it very easy to add a UI to your provider.</span></span>  <span data-ttu-id="0bfad-154">静的コンテンツを提供する最も簡単な方法では、プロジェクト内で、URL にマップできるコンテンツ フォルダーを作成することです。</span><span class="sxs-lookup"><span data-stu-id="0bfad-154">The easiest way to serve static content is to create a content folder in your project that can map to a URL.</span></span>

![Device Portal の静的コンテンツ フォルダー](images/device-portal/plugin-static-content.png)
 
<span data-ttu-id="0bfad-156">次に、**RequestReceived** イベント ハンドラーに、静的コンテンツのルートを検出し、要求を適切にマップするルート ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-156">Then, add a route handler in your **RequestReceived** event handler that detects static content routes and maps a request appropriately.</span></span>  

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
<span data-ttu-id="0bfad-157">コンテンツのフォルダー内のすべてのファイルが "コンテンツ" としてマークされ、Visual Studio の [プロパティ] メニューで [新しい場合はコピーする] または [常にコピーする] に設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-157">Make sure that all files inside of the content folder are marked as "Content" and set to "Copy if newer" or "Copy always" in Visual Studio’s Properties menu.</span></span>  <span data-ttu-id="0bfad-158">これにより、展開するときに、ファイルが AppX パッケージに含められます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-158">This ensures that the files will be inside your AppX Package when you deploy it.</span></span>  

![静的コンテンツのファイルのコピーを構成する](images/device-portal/plugin-file-copying.png)

## <a name="using-existing-device-portal-resources-and-apis"></a><span data-ttu-id="0bfad-160">既存の Device Portal のリソースと API を使用する</span><span class="sxs-lookup"><span data-stu-id="0bfad-160">Using existing Device Portal resources and APIs</span></span>
<span data-ttu-id="0bfad-161">Device Portal プロバイダーによって提供される静的コンテンツは、コア Device Portal サービスと同じポートで提供されます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-161">Static content served by a Device Portal provider is served on the same port as the core Device Portal service.</span></span>  <span data-ttu-id="0bfad-162">つまり、HTML の単純な `<link>` および `<script>` タグで、Device Portal に含まれている既存の JS および CSS を参照できます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-162">This means that you can reference the existing JS and CSS included with Device Portal with simple `<link>` and `<script>` tags in your HTML.</span></span> <span data-ttu-id="0bfad-163">一般的に、すべてのコア Device Portal の REST API を便利な webbRest オブジェクトにラップする *rest.js* と、Device Portal の UI の他の部分に合わせてコンテンツのスタイルを設定できる *common.css* ファイルを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bfad-163">In general, we suggest the use of *rest.js*, which wraps all the core Device Portal REST APIs in a convenient webbRest object, and the *common.css* file, which will allow you to style your content to fit with the rest of Device Portal's UI.</span></span> <span data-ttu-id="0bfad-164">この例については、サンプルに含まれる *index.html* ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bfad-164">You can see an example of this in the *index.html* page included in the sample.</span></span> <span data-ttu-id="0bfad-165">この例では、*rest.js* を使用して、Device Portal からデバイス名と実行中のプロセスを取得します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-165">It uses *rest.js* to retrieve the device name and running processes from Device Portal.</span></span> 

![Device Portal プラグインの出力](images/device-portal/plugin-output.png)
 
<span data-ttu-id="0bfad-167">重要な点は、webbRest で HttpPost/DeleteExpect200 メソッドを使用すると、自動的に [CSRF 処理](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/preventing-cross-site-request-forgery-csrf-attacks) が実行されるため、Web ページで状態が変化する REST API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="0bfad-167">Importantly, use of the HttpPost/DeleteExpect200 methods on webbRest will automatically do the [CSRF handling](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/preventing-cross-site-request-forgery-csrf-attacks) for you, which allows your webpage to call state-changing REST APIs.</span></span>  

> [!NOTE] 
> <span data-ttu-id="0bfad-168">Device Portal に含まれている静的コンテンツは、重大な変更に対する保証は行われません。</span><span class="sxs-lookup"><span data-stu-id="0bfad-168">The static content included with Device Portal does not come with a guarantee against breaking changes.</span></span> <span data-ttu-id="0bfad-169">API は頻繁に変更することは想定されていませんが、特に *common.js* や *controls.js* ファイルでは変更されることもあるため、プロバイダーでは使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="0bfad-169">While the APIs are not expected to change often, they may, especially in the *common.js* and *controls.js* files, which your provider should not use.</span></span> 

## <a name="debugging-the-device-portal-connection"></a><span data-ttu-id="0bfad-170">Device Portal の接続をデバッグする</span><span class="sxs-lookup"><span data-stu-id="0bfad-170">Debugging the Device Portal connection</span></span>
<span data-ttu-id="0bfad-171">バック グラウンド タスクをデバッグするには、Visual Studio でコードを実行する方法を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bfad-171">In order to debug your background task, you must change the way Visual Studio runs your code.</span></span> <span data-ttu-id="0bfad-172">アプリ サービスの接続をデバッグして、プロバイダーが HTTP 要求を処理する方法を調べるには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="0bfad-172">Follow the steps below for debugging an app service connection to inspect how your provider is handling the HTTP requests:</span></span>

1.  <span data-ttu-id="0bfad-173">[デバッグ] メニューから [DevicePortalProvider のプロパティ] を選択します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-173">From the Debug menu, select DevicePortalProvider Properties.</span></span> 
2.  <span data-ttu-id="0bfad-174">[デバッグ] タブの [開始動作] で、[起動しないが、開始時にマイ コードをデバッグする] を選択します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-174">Under the Debugging tab, in the Start action section, select “Do not launch, but debug my code when it starts”.</span></span>  
![プラグインをデバッグ モードにする](images/device-portal/plugin-debug-mode.png)
3.  <span data-ttu-id="0bfad-176">RequestReceived ハンドラー関数にブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-176">Set a breakpoint in your RequestReceived handler function.</span></span>
![RequestReceived ハンドラーでのブレークポイント](images/device-portal/plugin-requestreceived-breakpoint.png)
> [!NOTE] 
> <span data-ttu-id="0bfad-178">ビルドのアーキテクチャがターゲットのアーキテクチャと正確に一致することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="0bfad-178">Make sure the build architecture matches the architecture of the target exactly.</span></span> <span data-ttu-id="0bfad-179">64 ビット PC を使用している場合は、AMD64 ビルドを使って展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bfad-179">If you are using a 64-bit PC, you must deploy using an AMD64 build.</span></span> 
4.  <span data-ttu-id="0bfad-180">F5 キーを押してアプリを展開します。</span><span class="sxs-lookup"><span data-stu-id="0bfad-180">Press F5 to deploy your app</span></span>
5.  <span data-ttu-id="0bfad-181">Device Portal をオフにし、再度オンにしてアプリを検出できるようにします (アプリ マニフェストを変更した場合にのみ必要。その他の場合は、単に再配置し、この手順を省略できます)。</span><span class="sxs-lookup"><span data-stu-id="0bfad-181">Turn Device Portal off, then turn it back on so that it finds your app (only needed when you change your app manifest – the rest of the time you can simply re-deploy and skip this step).</span></span> 
6.  <span data-ttu-id="0bfad-182">ブラウザーで、プロバイダーの名前空間にアクセスすると、ブレークポイントにヒットします。</span><span class="sxs-lookup"><span data-stu-id="0bfad-182">In your browser, access the provider's namespace, and the breakpoint should be hit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="0bfad-183">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0bfad-183">Related topics</span></span>
* [<span data-ttu-id="0bfad-184">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="0bfad-184">Windows Device Portal overview</span></span>](device-portal.md)
* [<span data-ttu-id="0bfad-185">アプリ サービスの作成と利用</span><span class="sxs-lookup"><span data-stu-id="0bfad-185">Create and consume an app service</span></span>](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)


