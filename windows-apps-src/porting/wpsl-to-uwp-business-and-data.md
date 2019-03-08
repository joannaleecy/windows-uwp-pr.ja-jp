---
description: UI の背後には、ビジネス レイヤーとデータ レイヤーがあります。
title: UWP に Windows Phone Silverlight のビジネス データおよびデータ層の移植
ms.assetid: 27c66759-2b35-41f5-9f7a-ceb97f4a0e3f
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3e5b97c236f71c95cdff9c56ccc205d3b0fbde5e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661687"
---
#  <a name="porting-windowsphone-silverlight-business-and-data-layers-to-uwp"></a><span data-ttu-id="e1a2c-104">UWP に Windows Phone Silverlight のビジネス データおよびデータ層の移植</span><span class="sxs-lookup"><span data-stu-id="e1a2c-104">Porting Windows Phone Silverlight business and data layers to UWP</span></span>


<span data-ttu-id="e1a2c-105">前のトピックは、「[入出力、デバイス、アプリ モデルの移植](wpsl-to-uwp-input-and-sensors.md)」でした。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-105">The previous topic was [Porting for I/O, device, and app model](wpsl-to-uwp-input-and-sensors.md).</span></span>

<span data-ttu-id="e1a2c-106">UI の背後には、ビジネス レイヤーとデータ レイヤーがあります。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-106">Behind your UI are your business and data layers.</span></span> <span data-ttu-id="e1a2c-107">こうしたレイヤーのコードでは、オペレーティング システムと .NET Framework API (たとえば、バックグラウンド処理、場所、カメラ、ファイル システム、ネットワーク、その他のデータ アクセスなど) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-107">The code in these layers calls operating system and .NET Framework APIs (for example, background processing, location, the camera, the file system, network, and other data access).</span></span> <span data-ttu-id="e1a2c-108">その大半が[ユニバーサル Windows プラットフォーム (UWP) アプリ](https://msdn.microsoft.com/library/windows/apps/br211369)で利用可能であり、したがって変更なくこのコードの大半を移植できると考えられます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-108">The vast majority of those are [available to a Universal Windows Platform (UWP) app](https://msdn.microsoft.com/library/windows/apps/br211369), so you can expect to be able to port much of this code without change.</span></span>

## <a name="asynchronous-methods"></a><span data-ttu-id="e1a2c-109">非同期メソッド</span><span class="sxs-lookup"><span data-stu-id="e1a2c-109">Asynchronous methods</span></span>

<span data-ttu-id="e1a2c-110">ユニバーサル Windows プラットフォーム (UWP) で優先されることの 1 つは、真に一貫して応答性が高いアプリを構築できるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-110">One of the priorities of the Universal Windows Platform (UWP) is to enable you to build apps that are truly, and consistently, responsive.</span></span> <span data-ttu-id="e1a2c-111">アニメーションは常にスムーズで、パンやスワイプなどのタッチ操作は遅延なく瞬時であり、UI が指に密着するように感じさせます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-111">Animations are always smooth, and touch interactions such as panning and swiping are instantaneous and free of lag, making it feel like the UI is glued to your finger.</span></span> <span data-ttu-id="e1a2c-112">これを実現するために、50 ミリ秒以内の完了が保証できないすべての UWP API は非同期になり、名前の後に **Async** が付加されています。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-112">To achieve this, any UWP API that can't guarantee to complete within 50ms has been made asynchronous and its name suffixed with **Async**.</span></span> <span data-ttu-id="e1a2c-113">UI スレッドは、**Async** メソッドの呼び出し後に直ちに戻り、別のスレッドで処理を実行します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-113">Your UI thread will return immediately from calling an **Async** method, and the work will take place on another thread.</span></span> <span data-ttu-id="e1a2c-114">**Async** メソッドの使用は、構文的に非常に簡単であり、C# の **await** 演算子、JavaScript promise オブジェクト、C++ 後続タスクを使います。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-114">Consuming an **Async** method is made very easy, syntactically, using the C# **await** operator, JavaScript promise objects, and C++ continuations.</span></span> <span data-ttu-id="e1a2c-115">詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-115">For more info, see [Asynchronous programming](https://msdn.microsoft.com/library/windows/apps/mt187335).</span></span>

## <a name="background-processing"></a><span data-ttu-id="e1a2c-116">バックグラウンド処理</span><span class="sxs-lookup"><span data-stu-id="e1a2c-116">Background processing</span></span>

<span data-ttu-id="e1a2c-117">Windows Phone Silverlight アプリを使用してマネージできます**ScheduledTaskAgent**アプリがフォア グラウンドにないときにタスクを実行するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-117">A Windows Phone Silverlight app can use a managed **ScheduledTaskAgent** object to perform a task while the app is not in the foreground.</span></span> <span data-ttu-id="e1a2c-118">UWP アプリでは、同様の方法でバックグラウンド タスクを作成、登録するために [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-118">A UWP app uses the [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) class to create and register a background task in a similar way.</span></span> <span data-ttu-id="e1a2c-119">バックグラウンド タスクの処理を実装するクラスを定義します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-119">You define a class that implements the work of your background task.</span></span> <span data-ttu-id="e1a2c-120">システムでは、バックグラウンド タスクを定期的に実行し、処理を実行するクラスの [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-120">The system runs your background task periodically, calling the [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method of your class to execute the work.</span></span> <span data-ttu-id="e1a2c-121">UWP アプリでは、アプリ パッケージ マニフェストで**バックグラウンド タスク**の宣言を忘れずに設定します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-121">In a UWP app, remember to set the **Background Tasks** declaration in the app package manifest.</span></span> <span data-ttu-id="e1a2c-122">詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/library/windows/apps/mt299103)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-122">For more info, see [Support your app with background tasks](https://msdn.microsoft.com/library/windows/apps/mt299103).</span></span>

<span data-ttu-id="e1a2c-123">Windows Phone Silverlight アプリを使用して、バック グラウンドでの大きなデータ ファイルを転送する、 **BackgroundTransferService**クラス。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-123">To transfer large data files in the background, a Windows Phone Silverlight app uses the **BackgroundTransferService** class.</span></span> <span data-ttu-id="e1a2c-124">UWP アプリは、このために [**Windows.Networking.BackgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242) 名前空間の API を使います。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-124">A UWP app uses APIs in the [**Windows.Networking.BackgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242) namespace to do this.</span></span> <span data-ttu-id="e1a2c-125">機能は同様のパターンを使って転送を開始しますが、新しい API では機能と性能が向上しています。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-125">The features use a similar pattern to initiate transfers, but the new API has improved capabilities and performance.</span></span> <span data-ttu-id="e1a2c-126">詳しくは、「[バックグラウンドでのデータの転送](https://msdn.microsoft.com/library/windows/apps/xaml/hh452975)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-126">For more info, see [Transferring data in the background](https://msdn.microsoft.com/library/windows/apps/xaml/hh452975).</span></span>

<span data-ttu-id="e1a2c-127">Windows Phone Silverlight アプリでのマネージ クラスを使用して、 **Microsoft.Phone.BackgroundAudio**フォア グラウンドでアプリの中にオーディオを再生する名前空間がないです。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-127">A Windows Phone Silverlight app uses the managed classes in the **Microsoft.Phone.BackgroundAudio** namespace to play audio while the app is not in the foreground.</span></span> <span data-ttu-id="e1a2c-128">UWP は Windows Phone ストア アプリ モデルを使います。詳しくは、「[バックグラウンド オーディオ](https://msdn.microsoft.com/library/windows/apps/mt282140)」および[バックグラウンド オーディオ](https://go.microsoft.com/fwlink/p/?linkid=619997)のサンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-128">The UWP uses the Windows Phone Store app model, see [Background Audio](https://msdn.microsoft.com/library/windows/apps/mt282140) and the [Background audio](https://go.microsoft.com/fwlink/p/?linkid=619997) sample.</span></span>

## <a name="cloud-services-networking-and-databases"></a><span data-ttu-id="e1a2c-129">クラウド サービス、ネットワーク、データベース</span><span class="sxs-lookup"><span data-stu-id="e1a2c-129">Cloud services, networking, and databases</span></span>

<span data-ttu-id="e1a2c-130">Azure を使ってクラウドでデータとアプリ サービスをホストできます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-130">Hosting data and app services in the cloud is possible using Azure.</span></span> <span data-ttu-id="e1a2c-131">「[Mobile Services の使用](https://go.microsoft.com/fwlink/p/?LinkID=403138)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-131">See [Getting Started with Mobile Services](https://go.microsoft.com/fwlink/p/?LinkID=403138).</span></span> <span data-ttu-id="e1a2c-132">オンラインとオフラインの両方のデータを必要とするソリューションを参照してください。[Mobile Services でのオフライン データ同期を使用して](https://azure.microsoft.com/documentation/articles/mobile-services-windows-store-dotnet-get-started-offline-data/)します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-132">For solutions that require both online and offline data see: [Using offline data sync in Mobile Services](https://azure.microsoft.com/documentation/articles/mobile-services-windows-store-dotnet-get-started-offline-data/).</span></span>

<span data-ttu-id="e1a2c-133">UWP は **System.Net.HttpWebRequest** クラスを部分的にサポートしていますが、**System.Net.WebClient** クラスはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-133">The UWP has partial support for the **System.Net.HttpWebRequest** class, but the **System.Net.WebClient** class is not supported.</span></span> <span data-ttu-id="e1a2c-134">お勧めできる将来的な代替案は、[**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または、.NET をサポートする他のプラットフォームにコードを移植可能にする場合は [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx)) です。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-134">The recommended, forward-looking alternative is the [**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) class (or [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx) if you need your code to be portable to other platforms that support .NET).</span></span> <span data-ttu-id="e1a2c-135">これらの API では、[System.Net.Http.HttpRequestMessage](https://msdn.microsoft.com/library/system.net.http.httprequestmessage.aspx) を使って HTTP 要求を表します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-135">These APIs use [System.Net.Http.HttpRequestMessage](https://msdn.microsoft.com/library/system.net.http.httprequestmessage.aspx) to represent an HTTP request.</span></span>

<span data-ttu-id="e1a2c-136">UWP アプリには、現在、大量のデータ アクセスを実行するシナリオ (基幹業務 (LOB) シナリオなど) を対象としたサポートは組み込まれていません。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-136">UWP apps do not currently include built-in support for data-intensive scenarios such as line of business (LOB) scenarios.</span></span> <span data-ttu-id="e1a2c-137">ただし、ローカル トランザクション データベース サービスのために SQLite を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-137">However, you can make use SQLite for local transactional database services.</span></span> <span data-ttu-id="e1a2c-138">詳しくは、「[SQLite](https://visualstudiogallery.msdn.microsoft.com/4913e7d5-96c9-4dde-a1a1-69820d615936)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-138">For more info, see [SQLite](https://visualstudiogallery.msdn.microsoft.com/4913e7d5-96c9-4dde-a1a1-69820d615936).</span></span>

<span data-ttu-id="e1a2c-139">相対 URI ではなく絶対 URI を Windows ランタイム型に渡します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-139">Pass absolute URIs, not relative URIs, to Windows Runtime types.</span></span> <span data-ttu-id="e1a2c-140">「[Windows ランタイムへの URI の引き渡し](https://msdn.microsoft.com/library/hh763341.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-140">See [Passing a URI to the Windows Runtime](https://msdn.microsoft.com/library/hh763341.aspx).</span></span>

## <a name="launchers-and-choosers"></a><span data-ttu-id="e1a2c-141">ランチャーとセレクター</span><span class="sxs-lookup"><span data-stu-id="e1a2c-141">Launchers and Choosers</span></span>

<span data-ttu-id="e1a2c-142">ランチャー、チューザーと (で見つかった、 **Microsoft.Phone.Tasks**名前空間)、Windows Phone Silverlight アプリ、写真を選択する、電子メールの構成などの一般的な操作を実行するオペレーティング システムと通信することができますか別のアプリとは、特定の種類のデータを共有します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-142">With Launchers and Choosers (found in the **Microsoft.Phone.Tasks** namespace), a Windows Phone Silverlight app can interact with the operating system to perform common operations such as composing an email, choosing a photo, or sharing certain kinds of data with another app.</span></span> <span data-ttu-id="e1a2c-143">検索**Microsoft.Phone.Tasks** 、トピックの「 [Windows 10 の名前空間とクラス マッピングを Windows Phone Silverlight](wpsl-to-uwp-namespace-and-class-mappings.md) UWP 同等型が見つかりません。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-143">Search for **Microsoft.Phone.Tasks** in the topic [Windows Phone Silverlight to Windows 10 namespace and class mappings](wpsl-to-uwp-namespace-and-class-mappings.md) to find the equivalent UWP type.</span></span> <span data-ttu-id="e1a2c-144">これには、ランチャーおよびピッカーと呼ばれる同様のメカニズムから、アプリ間でデータを共有するコントラクトの実装に至るまで、一連の型が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-144">These range from similar mechanisms, called launchers and pickers, to implementing a contract for sharing data between apps.</span></span>

<span data-ttu-id="e1a2c-145">Windows Phone Silverlight アプリを配置できるに休止状態または廃棄も、たとえば、写真の選択タスクを使用する場合。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-145">A Windows Phone Silverlight app can be put into a dormant state or even tombstoned when using, for example, the photo Chooser task.</span></span> <span data-ttu-id="e1a2c-146">UWP アプリは、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラスの使用中はアクティブで実行中のままになります。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-146">A UWP app remains active and running while using the [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) class.</span></span>

## <a name="monetization-trial-mode-and-in-app-purchases"></a><span data-ttu-id="e1a2c-147">収益化 (試用モードとアプリ内購入)</span><span class="sxs-lookup"><span data-stu-id="e1a2c-147">Monetization (trial mode and in-app purchases)</span></span>

<span data-ttu-id="e1a2c-148">Windows Phone Silverlight アプリが、UWP を使用できます [**CurrentApp** ](https://msdn.microsoft.com/library/windows/apps/hh779765)クラスの試用版モードとアプリ内のほとんどは、機能を購入できるように、コードを移植する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-148">A Windows Phone Silverlight app can use the UWP [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) class for most of its trial mode and in-app purchase functionality, so that code doesn't need to be ported.</span></span> <span data-ttu-id="e1a2c-149">しかし、Windows Phone Silverlight アプリを呼び出す**MarketplaceDetailTask.Show**購入アプリを提供します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-149">But, a Windows Phone Silverlight app calls **MarketplaceDetailTask.Show** to offer the app for purchase:</span></span>

```csharp
    private void Buy()
    {
        MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
        marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;
        marketplaceDetailTask.Show();
    }
```

<span data-ttu-id="e1a2c-150">UWP の  [**RequestAppPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/hh967813) メソッドを呼び出すコードを移植します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-150">Port that code to call the UWP [**RequestAppPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/hh967813) method:</span></span>

```csharp
    private async void Buy()
    {
        await Windows.ApplicationModel.Store.CurrentApp.RequestAppPurchaseAsync(false);
    }
```

<span data-ttu-id="e1a2c-151">テスト目的のためにアプリ購入機能およびアプリ内購入機能をシミュレートするコードがある場合は、代わりに [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスを使うようにこのコードを移植できます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-151">If you have code that simulates your app purchase and in-app purchase features for testing purposes, then you can port that to use the [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) class instead.</span></span>

## <a name="notifications-for-tile-or-toast-updates"></a><span data-ttu-id="e1a2c-152">タイルまたはトーストの更新通知</span><span class="sxs-lookup"><span data-stu-id="e1a2c-152">Notifications for tile or toast updates</span></span>

<span data-ttu-id="e1a2c-153">通知は、Windows Phone Silverlight アプリにプッシュ通知のモデルの拡張機能です。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-153">Notifications are an extension of the push notification model for Windows Phone Silverlight apps.</span></span> <span data-ttu-id="e1a2c-154">Windows プッシュ通知サービス (WNS) から通知を受信した場合、タイル更新またはトーストにより UI にこの情報を提示できます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-154">When you receive a notification from the Windows Push Notification Service (WNS), you can surface the info to the UI with a tile update or with a toast.</span></span> <span data-ttu-id="e1a2c-155">通知機能の UI 側の移植については、「[タイルとトースト](w8x-to-uwp-porting-xaml-and-ui.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-155">For porting the UI side of your notification features, see [Tiles and toasts](w8x-to-uwp-porting-xaml-and-ui.md).</span></span>

<span data-ttu-id="e1a2c-156">UWP アプリで通知を使う方法について詳しくは、「[トースト通知の送信](https://msdn.microsoft.com/library/windows/apps/xaml/hh868266)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-156">For more details on the use of notifications in a UWP app, see [Sending toast notifications](https://msdn.microsoft.com/library/windows/apps/xaml/hh868266).</span></span>

<span data-ttu-id="e1a2c-157">C++、C#、または Visual Basic を使った Windows ランタイム アプリでのタイル、トースト、バッジ、バナー、通知の使用についての情報とチュートリアルは、「[タイル、バッジ、トースト通知の操作](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-157">For info and tutorials on using tiles, toasts, badges, banners, and notifications in a Windows Runtime app using C++, C#, or Visual Basic, see [Working with tiles, badges, and toast notifications](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259).</span></span>

## <a name="storage-file-access"></a><span data-ttu-id="e1a2c-158">ストレージ (ファイル アクセス)</span><span class="sxs-lookup"><span data-stu-id="e1a2c-158">Storage (file access)</span></span>

<span data-ttu-id="e1a2c-159">分離ストレージ内のキー/値ペアとしてアプリの設定を格納する Windows Phone Silverlight コードは簡単に移植します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-159">Windows Phone Silverlight code that stores app settings as key-value pairs in isolated storage is easily ported.</span></span> <span data-ttu-id="e1a2c-160">ここで例を示します前に、と後、最初に、Windows Phone の Silverlight バージョン。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-160">Here is a before-and-after example, first the Windows Phone Silverlight version:</span></span>

```csharp
    var propertySet = IsolatedStorageSettings.ApplicationSettings;
    const string key = "favoriteAuthor";
    propertySet[key] = "Charles Dickens";
    propertySet.Save();
    string myFavoriteAuthor = propertySet.Contains(key) ? (string)propertySet[key] : "<none>";
```

<span data-ttu-id="e1a2c-161">次に相当する UWP の要素を示します。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-161">And the UWP equivalent:</span></span>

```csharp
    var propertySet = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
    const string key = "favoriteAuthor";
    propertySet[key] = "Charles Dickens";
    string myFavoriteAuthor = propertySet.ContainsKey(key) ? (string)propertySet[key] : "<none>";
```

<span data-ttu-id="e1a2c-162">サブセットですが、 **Windows.Storage**名前空間が使用できるようにするには、多くの Windows Phone Silverlight アプリの実行ファイルの i/o、 **IsolatedStorageFile**クラスではサポートされているため長くなります。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-162">Although a subset of the **Windows.Storage** namespace is available to them, many Windows Phone Silverlight apps perform file i/o with the **IsolatedStorageFile** class because it has been supported for longer.</span></span> <span data-ttu-id="e1a2c-163">仮定**IsolatedStorageFile**が記述して、まず、Windows Phone の Silverlight バージョンのファイルの読み取りの前に、と後例を示します。 使用されています。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-163">Assuming that **IsolatedStorageFile** is being used, here's a before-and-after example of writing and reading a file, first the Windows Phone Silverlight version:</span></span>

```csharp
    const string filename = "FavoriteAuthor.txt";
    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (var streamWriter = new StreamWriter(store.CreateFile(filename)))
        {
            streamWriter.Write("Charles Dickens");
        }
        using (var StreamReader = new StreamReader(store.OpenFile(filename, FileMode.Open, FileAccess.Read)))
        {
            string myFavoriteAuthor = StreamReader.ReadToEnd();
        }
    }
```

<span data-ttu-id="e1a2c-164">そして、UWP を使う同じ機能です。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-164">And the same functionality using the UWP:</span></span>

```csharp
    const string filename = "FavoriteAuthor.txt";
    var store = Windows.Storage.ApplicationData.Current.LocalFolder;
    Windows.Storage.StorageFile file = await store.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
    await Windows.Storage.FileIO.WriteTextAsync(file, "Charles Dickens");
    file = await store.GetFileAsync(filename);
    string myFavoriteAuthor = await Windows.Storage.FileIO.ReadTextAsync(file);
```

<span data-ttu-id="e1a2c-165">Windows Phone Silverlight アプリでは、オプションの SD カードに読み取り専用のアクセスを持ちます。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-165">A Windows Phone Silverlight app has read-only access to the optional SD card.</span></span> <span data-ttu-id="e1a2c-166">UWP アプリは、オプションの SD カードに読み取り専用のアクセスを行います。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-166">A UWP app has read-write access to the SD card.</span></span> <span data-ttu-id="e1a2c-167">詳しくは、「[SD カードへのアクセス](https://msdn.microsoft.com/library/windows/apps/mt188699)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-167">For more info, see [Access the SD card](https://msdn.microsoft.com/library/windows/apps/mt188699).</span></span>

<span data-ttu-id="e1a2c-168">UWP アプリでの写真、音楽、ビデオ ファイルへのアクセスについて詳しくは、「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](https://msdn.microsoft.com/library/windows/apps/mt188703)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-168">For info about accessing photos, music, and video files in a UWP app, see [Files and folders in the Music, Pictures, and Videos libraries](https://msdn.microsoft.com/library/windows/apps/mt188703).</span></span>

<span data-ttu-id="e1a2c-169">詳しくは、「[ファイル、フォルダー、およびライブラリ](https://msdn.microsoft.com/library/windows/apps/mt185399)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-169">For more info, see [Files, folders, and libraries](https://msdn.microsoft.com/library/windows/apps/mt185399).</span></span>

<span data-ttu-id="e1a2c-170">次のトピックは、「[フォーム ファクターと UX の移植](wpsl-to-uwp-form-factors-and-ux.md)」です。</span><span class="sxs-lookup"><span data-stu-id="e1a2c-170">The next topic is [Porting for form factor and UX](wpsl-to-uwp-form-factors-and-ux.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="e1a2c-171">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e1a2c-171">Related topics</span></span>

* [<span data-ttu-id="e1a2c-172">Namespace およびクラスのマッピング</span><span class="sxs-lookup"><span data-stu-id="e1a2c-172">Namespace and class mappings</span></span>](wpsl-to-uwp-namespace-and-class-mappings.md)
 

