---
author: GrantMeStrength
ms.assetid: C9787269-B54F-4FFA-A884-D4A3BF28F80D
title: "ユニバーサル Windows プラットフォーム (UWP) アプリとは"
description: "さまざまな種類のユニバーサル Windows アプリ (Windows ストア アプリ、Windows Phone ストア アプリ、Windows ランタイム アプリ) について説明します。"
ms.author: jken
ms.date: 03/22/2017
ms.topic: article
pms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 3bbced2db33210952b6c8a45f98e36582330d7d9
ms.sourcegitcommit: 214a1dcb24e0811811bd7a4a07bfe707ecd93b18
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/15/2017
---
# <a name="whats-a-universal-windows-platform-uwp-app"></a><span data-ttu-id="8b820-104">ユニバーサル Windows プラットフォーム (UWP) アプリとは</span><span class="sxs-lookup"><span data-stu-id="8b820-104">What's a Universal Windows Platform (UWP) app?</span></span>

<span data-ttu-id="8b820-105">ユニバーサル Windows プラットフォーム (UWP) とは、Windows 10 用のアプリ プラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="8b820-105">The Universal Windows Platform (UWP) is the app platform for Windows 10.</span></span> <span data-ttu-id="8b820-106">API セット、アプリ パッケージ、ストアをそれぞれ 1 つ使うだけで、すべての Windows 10 デバイス (PC、タブレット、電話、Xbox、HoloLens、Surface Hub など) で利用可能な UWP 用アプリを開発できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-106">You can develop apps for UWP with just one API set, one app package, and one store to reach all Windows 10 devices – PC, tablet, phone, Xbox, HoloLens, Surface Hub and more.</span></span> <span data-ttu-id="8b820-107">また、多数の画面サイズや、さまざまな対話方式 (タッチ、マウスとキーボード、ゲーム コントローラー、ペン) をサポートすることも簡単になります。</span><span class="sxs-lookup"><span data-stu-id="8b820-107">It’s easier to support a number of screen sizes, and also a variety of interaction models, whether it be touch, mouse and keyboard, a game controller, or a pen.</span></span> <span data-ttu-id="8b820-108">UWP アプリの中核となるのは、ユーザーがすべてのデバイスでモバイル *エクスペリエンス*を手に入れたい、目の前の作業に一番便利で効率的なデバイスを使いたいという考え方です。</span><span class="sxs-lookup"><span data-stu-id="8b820-108">At the core of UWP apps is the idea that users want their *experiences* to be mobile across ALL their devices, and they want to use whatever device is most convenient or productive for the task at hand.</span></span>

<span data-ttu-id="8b820-109">UWP には柔軟性もあります。必要でなければ、C# や XAML を使用しなくても問題ありません。</span><span class="sxs-lookup"><span data-stu-id="8b820-109">UWP is also flexible: you don't have to use C# and XAML if you don't want to.</span></span> <span data-ttu-id="8b820-110">Unity や MonoGame での開発がお好みでも、</span><span class="sxs-lookup"><span data-stu-id="8b820-110">Do you like developing in Unity or MonoGame?</span></span> <span data-ttu-id="8b820-111">JavaScript がお好みでも</span><span class="sxs-lookup"><span data-stu-id="8b820-111">Prefer JavaScript?</span></span> <span data-ttu-id="8b820-112">問題はありません。お好きな言語を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-112">Not a problem, use them all you want.</span></span> <span data-ttu-id="8b820-113">UWP の機能を使って拡張し、ストアでの販売を希望する C++ デスクトップ アプリがある場合も</span><span class="sxs-lookup"><span data-stu-id="8b820-113">Have a C++ desktop app that you want to extend with UWP features and sell in the store?</span></span> <span data-ttu-id="8b820-114">問題ありません。</span><span class="sxs-lookup"><span data-stu-id="8b820-114">That's okay, too.</span></span> 

<span data-ttu-id="8b820-115">つまり、使い慣れたプログラミング言語、フレームワーク、API を選んで作業に取り組み、すべてを 1 つのプロジェクトで管理して、まったく同じコードを現在存在するさまざまな Windows ハードウェアで動作させることができるのです。</span><span class="sxs-lookup"><span data-stu-id="8b820-115">The bottom line: You can spend your time working with familiar programming languages, frameworks and APIs, all in single project, and have the very same code run on the huge range of Windows hardware that exists today.</span></span> <span data-ttu-id="8b820-116">UWP アプリが完成したら、ストアに公開して世界中に届けることができます。</span><span class="sxs-lookup"><span data-stu-id="8b820-116">Once you've written your UWP app, you can then publish it to the store for the world to see.</span></span>

![Windows デバイス](images/1894834-hig-device-primer-01-500.png)
 
##<a name="so-what-exactly-is-a-uwp-app"></a><span data-ttu-id="8b820-118">それでは、UWP アプリとは厳密に**どのようなものでしょうか。</span><span class="sxs-lookup"><span data-stu-id="8b820-118">So, what *exactly* is a UWP app?</span></span>

<span data-ttu-id="8b820-119">UWP アプリの一番の特徴は何でしょうか。</span><span class="sxs-lookup"><span data-stu-id="8b820-119">What makes a UWP app special?</span></span> <span data-ttu-id="8b820-120">以下に、Windows 10 の UWP アプリの特徴をいくつか挙げます。</span><span class="sxs-lookup"><span data-stu-id="8b820-120">Here are some of the characteristics that make UWP apps on Windows 10 different.</span></span>

-   **<span data-ttu-id="8b820-121">すべてのデバイスに共通の API セットが用意されている。</span><span class="sxs-lookup"><span data-stu-id="8b820-121">There's a common API surface across all devices.</span></span>**

    <span data-ttu-id="8b820-122">ユニバーサル Windows プラットフォーム (UWP) のコア API は、すべてのクラスの Windows デバイスに共通です。</span><span class="sxs-lookup"><span data-stu-id="8b820-122">The Universal Windows Platform (UWP) core APIs are the same for all classes of Windows device.</span></span> <span data-ttu-id="8b820-123">アプリがコア API のみを使う場合は、対象となるのがデスクトップ PC か、Xbox か、または Mixed Reality ヘッドセットかに関係なく、そのアプリはどの Windows 10 デバイスでも動作します。</span><span class="sxs-lookup"><span data-stu-id="8b820-123">If your app uses only the core APIs, it will run on any Windows 10 device, no matter if you are targeting a desktop PC, an Xbox or a Mixed Reality headset.</span></span>

-   **<span data-ttu-id="8b820-124">拡張 SDK により、特定のデバイスの種類でアプリが優れた機能を実現できる。</span><span class="sxs-lookup"><span data-stu-id="8b820-124">Extension SDKs let your app do cool stuff on specific device types.</span></span>**

    <span data-ttu-id="8b820-125">拡張 SDK により、各デバイス クラスに特化した API が追加されます。</span><span class="sxs-lookup"><span data-stu-id="8b820-125">Extension SDKs add specialized APIs for each device class.</span></span> <span data-ttu-id="8b820-126">たとえば、UWP アプリが HoloLens を対象としている場合、通常の UWP のコア API に加えて、HoloLens 機能を追加できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-126">For example, if your UWP app targets HoloLens, you can add HoloLens features in addition to the normal UWP core APIs.</span></span>
    <span data-ttu-id="8b820-127">ユニバーサル API を対象としている場合は、アプリ パッケージは Windows 10 が動作しているすべてのデバイスで実行できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-127">If you target the universal APIs, your app package can run on all devices that run Windows 10.</span></span> <span data-ttu-id="8b820-128">ただし、UWP アプリが、特定のデバイス クラスで実行している際にデバイス固有の API を利用する場合は、API を呼び出す前に、API が存在するかどうかを実行時に確認してください。</span><span class="sxs-lookup"><span data-stu-id="8b820-128">But if you want your UWP app to take advantage of device specific APIs in the event it is running on a particular class of device, you can check at run-time if an API exists before calling it.</span></span> 

-   **<span data-ttu-id="8b820-129">アプリは .AppX パッケージ形式を使ってパッケージ化され、ストアで配布される。</span><span class="sxs-lookup"><span data-stu-id="8b820-129">Apps are packaged using the .AppX packaging format and distributed from the Store.</span></span>**

    <span data-ttu-id="8b820-130">すべての UWP アプリは、AppX パッケージとして配布されます。</span><span class="sxs-lookup"><span data-stu-id="8b820-130">All UWP apps are distributed as an AppX package.</span></span> <span data-ttu-id="8b820-131">これにより、信頼できるインストール方法をユーザーに提供でき、アプリはシームレスに展開、更新できるようになります。</span><span class="sxs-lookup"><span data-stu-id="8b820-131">This provides a trustworthy installation mechanism and ensures that your apps can be deployed and updated seamlessly.</span></span>

-   **<span data-ttu-id="8b820-132">1 つのストアですべてのデバイスに対応する。</span><span class="sxs-lookup"><span data-stu-id="8b820-132">There's one store for all devices.</span></span>**

    <span data-ttu-id="8b820-133">アプリ開発者として登録した後、アプリをストアに提出し、すべてまたは特定の種類のデバイス向けに販売できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-133">After you register as an app developer, you can submit your app to the store and make it available on all types device, or only those you choose.</span></span> <span data-ttu-id="8b820-134">Windows デバイス向けのすべてのアプリを 1 か所で提出、管理できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-134">You submit and manage all your apps for Windows devices in one place.</span></span>

-   **<span data-ttu-id="8b820-135">アプリはアダプティブ コントロールと入力をサポートする。</span><span class="sxs-lookup"><span data-stu-id="8b820-135">Apps support adaptive controls and input</span></span>**

    <span data-ttu-id="8b820-136">UI 要素には*有効ピクセル* (「[UWP アプリ用レスポンシブ デザイン 101](https://msdn.microsoft.com/library/windows/apps/Dn958435)」を参照) が使われるため、UI 要素は、デバイスで利用可能な画面のピクセル数に基づいて動作するレイアウトに応じて最適化されます。</span><span class="sxs-lookup"><span data-stu-id="8b820-136">UI elements use *effective pixels* (see [Responsive design 101 for UWP apps](https://msdn.microsoft.com/library/windows/apps/Dn958435)), so they can respond with a layout that works based on the number of screen pixels available on the device.</span></span> <span data-ttu-id="8b820-137">また、キーボード、マウス、タッチ、ペン、Xbox One コントローラーなど、さまざまな種類の入力デバイスで問題なく機能します。</span><span class="sxs-lookup"><span data-stu-id="8b820-137">And they work well with multiple types of input such as keyboard, mouse, touch, pen, and Xbox One controllers.</span></span> <span data-ttu-id="8b820-138">アプリが実行される特定のデバイスや画面サイズに合わせて UI をさらに調整する場合は、新しく追加されたレイアウト パネルとツールが便利です。</span><span class="sxs-lookup"><span data-stu-id="8b820-138">If you need to further tailor your UI to a specific screen size or device, new layout panels and tooling help you adapt your UI to the devices your app may run on.</span></span>



## <a name="use-a-language-you-already-know"></a><span data-ttu-id="8b820-139">使い慣れた言語の使用</span><span class="sxs-lookup"><span data-stu-id="8b820-139">Use a language you already know</span></span>


<span data-ttu-id="8b820-140">UWP アプリは、オペレーティング システムに組み込まれているネイティブな API である Windows ランタイムを使います。</span><span class="sxs-lookup"><span data-stu-id="8b820-140">UWP apps use the Windows Runtime, a native API built into the operating system.</span></span> <span data-ttu-id="8b820-141">この API は C++ で実装され、C#、Visual Basic、C++、JavaScript でサポートされます。</span><span class="sxs-lookup"><span data-stu-id="8b820-141">This API is implemented in C++ and supported in C#, Visual Basic, C++, and JavaScript.</span></span> <span data-ttu-id="8b820-142">UWP でアプリを作成するための一部のオプションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="8b820-142">Some options for writing apps in UWP include:</span></span>
-   <span data-ttu-id="8b820-143">XAML UI、および C#、VB、C++ のバックエンド</span><span class="sxs-lookup"><span data-stu-id="8b820-143">XAML UI and a C#, VB, or C++ backend</span></span>
-   <span data-ttu-id="8b820-144">DirectX UI および C++ バックエンド</span><span class="sxs-lookup"><span data-stu-id="8b820-144">DirectX UI and a C++ backend</span></span>
-   <span data-ttu-id="8b820-145">JavaScript と HTML</span><span class="sxs-lookup"><span data-stu-id="8b820-145">JavaScript and HTML</span></span>

<span data-ttu-id="8b820-146">Microsoft Visual Studio 2017 には、各言語の UWP アプリ用テンプレートが用意されており、すべてのデバイスを対象とした単一のプロジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-146">Microsoft Visual Studio 2017 provides a UWP app template for each language that lets you create a single project for all devices.</span></span> <span data-ttu-id="8b820-147">作業が終わったら、Visual Studio 内でアプリ パッケージを生成し、Windows ストアに提出できます。これで、すべての Windows 10 デバイスのユーザーがそのアプリを利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="8b820-147">When your work is finished, you can produce an app package and submit it to the Windows Store from within Visual Studio to get your app out to customers on any Windows 10 device.</span></span>

## <a name="uwp-apps-come-to-life-on-windows"></a><span data-ttu-id="8b820-148">Windows での UWP アプリの実現</span><span class="sxs-lookup"><span data-stu-id="8b820-148">UWP apps come to life on Windows</span></span>


<span data-ttu-id="8b820-149">Windows では、アプリが、関連するリアルタイム情報をユーザーに表示し、ユーザーが何度も戻ってくるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="8b820-149">On Windows, your app can deliver relevant, real-time info to your users and keep them coming back for more.</span></span> <span data-ttu-id="8b820-150">最新のアプリの経済活動において、アプリは、ユーザーの生活の中で常に最初に思い出されるように魅力的なものにしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b820-150">In the modern app economy, your app has to be engaging to stay at the front of your users’ lives.</span></span> <span data-ttu-id="8b820-151">Windows では、ユーザーが繰り返しアプリを使うように、次のような多くのリソースを提供しています。</span><span class="sxs-lookup"><span data-stu-id="8b820-151">Windows provides you with lots of resources to help keep your users returning to your app:</span></span>

-   <span data-ttu-id="8b820-152">ライブ タイルとロック画面は、コンテキストに関連したタイムリーな情報をひとめでわかるように表示します。</span><span class="sxs-lookup"><span data-stu-id="8b820-152">Live tiles and the lock screen show contextually relevant and timely info at a glance.</span></span>

-   <span data-ttu-id="8b820-153">プッシュ通知は、ユーザーが必要なときにリアルタイムの最新の通知に注目できるようにします。</span><span class="sxs-lookup"><span data-stu-id="8b820-153">Push notifications bring real-time, breaking alerts to your user’s attention when they're needed.</span></span>

-   <span data-ttu-id="8b820-154">アクション センターでは、ユーザーの操作を必要とする通知やコンテンツを整理して表示できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-154">The Action Center is a place where you can organize and display notifications and content that users need to take action on.</span></span>

-   <span data-ttu-id="8b820-155">バックグラウンドの実行とトリガーにより、ユーザーが必要とするときだけアプリが有効になります。</span><span class="sxs-lookup"><span data-stu-id="8b820-155">Background execution and triggers bring your app to life just when the user needs it.</span></span>

-   <span data-ttu-id="8b820-156">アプリで音声と Bluetooth LE デバイスを使うと、ユーザーはそれらのデバイスを中心に広がる世界とやり取りすることができます。</span><span class="sxs-lookup"><span data-stu-id="8b820-156">Your app can use voice and Bluetooth LE devices to help users interact with the world around them.</span></span>

-   <span data-ttu-id="8b820-157">リッチなデジタル インクと革新的な Dial をサポートします。</span><span class="sxs-lookup"><span data-stu-id="8b820-157">Support for rich, digital ink and the innovative Dial.</span></span>

-   <span data-ttu-id="8b820-158">Cortana によって、ソフトウェアに個性が加わります。</span><span class="sxs-lookup"><span data-stu-id="8b820-158">Cortana adds personality to your software.</span></span>

-   <span data-ttu-id="8b820-159">XAML には、スムーズなアニメーション効果を持つユーザー インターフェイスを作成するためのツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="8b820-159">XAML provides you with the tools to create smooth, animated user interfaces.</span></span>

<span data-ttu-id="8b820-160">最終的に、ローミング データと Windows 資格情報保管ボックスを使うと、ユーザーがアプリを実行するすべての Windows 画面で一貫したローミング エクスペリエンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-160">Finally, you can use roaming data and the Windows Credential Locker to enable a consistent roaming experience across all of the Windows screens where users run your app.</span></span> <span data-ttu-id="8b820-161">ローミング データを使うと、独自の同期インフラストラクチャを構築する必要なく、ユーザーの基本設定とその他の設定をクラウドに簡単に保存できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-161">Roaming data gives you an easy way to store a user’s preferences and settings in the cloud, without having to build your own sync infrastructure.</span></span> <span data-ttu-id="8b820-162">資格情報保管ボックスには、ユーザーの資格情報を保存できます。このボックスにおける最優先事項はセキュリティと信頼性です。</span><span class="sxs-lookup"><span data-stu-id="8b820-162">And you can store user credentials in the Credential Locker, where security and reliability are the top priority.</span></span>

##  <a name="monetize-your-app"></a><span data-ttu-id="8b820-163">アプリの収益の獲得</span><span class="sxs-lookup"><span data-stu-id="8b820-163">Monetize your app</span></span>


<span data-ttu-id="8b820-164">Windows では、好きな方法で (電話、タブレット、PC、その他のデバイス) アプリから収益を得る方法を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="8b820-164">On Windows, you can choose how you'll monetize your app—across phones, tablets, PCs, and other devices.</span></span> <span data-ttu-id="8b820-165">ここでは、アプリとアプリが提供するサービスで収益を得るさまざまな方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8b820-165">We give you a number of ways to make money with your app and the services it delivers.</span></span> <span data-ttu-id="8b820-166">必要なのは、ニーズに合った最適な方法を選ぶことだけです。</span><span class="sxs-lookup"><span data-stu-id="8b820-166">All you need to do is choose the one that works best for you:</span></span>

-   <span data-ttu-id="8b820-167">有料のダウンロードは最も簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="8b820-167">A paid download is the simplest option.</span></span> <span data-ttu-id="8b820-168">必要な作業は価格の指定だけです。</span><span class="sxs-lookup"><span data-stu-id="8b820-168">Just name your price.</span></span>
-   <span data-ttu-id="8b820-169">試用版を使うとユーザーは購入前にアプリを試すことができ、従来の "フリーミアム" オプションよりも目につきやすく、コンバージョンも簡単です。</span><span class="sxs-lookup"><span data-stu-id="8b820-169">Trials let users try your app before buying it, providing easier discoverability and conversion than the more traditional "freemium" options.</span></span>
-   <span data-ttu-id="8b820-170">アプリとアドオンの販売価格を使用します。</span><span class="sxs-lookup"><span data-stu-id="8b820-170">Use sale prices for apps and add-ons.</span></span>
-   <span data-ttu-id="8b820-171">アプリ内購入と広告も利用できます。</span><span class="sxs-lookup"><span data-stu-id="8b820-171">In-app purchases and ads are also available.</span></span>

## <a name="lets-get-started"></a><span data-ttu-id="8b820-172">作業の開始</span><span class="sxs-lookup"><span data-stu-id="8b820-172">Let's get started</span></span>


<span data-ttu-id="8b820-173">UWP について詳しくは、[ユニバーサル Windows プラットフォーム アプリのガイド](universal-application-platform-guide.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b820-173">For a more detailed look at the UWP, read the [Guide to Universal Windows Platform apps](universal-application-platform-guide.md).</span></span> <span data-ttu-id="8b820-174">その後で、「[準備](get-set-up.md)」を確認し、アプリの作成を始めるために必要なツールをダウンロードしてから、[初めてのアプリ](your-first-app.md)を作成してください。</span><span class="sxs-lookup"><span data-stu-id="8b820-174">Then, check out [Get set up](get-set-up.md) to download the tools you need to start creating apps, and then write [your first app](your-first-app.md)!</span></span>


## <a name="more-advanced-topics"></a><span data-ttu-id="8b820-175">高度なトピック</span><span class="sxs-lookup"><span data-stu-id="8b820-175">More advanced topics</span></span>

* [<span data-ttu-id="8b820-176">.NET Native - ユニバーサル Windows プラットフォーム (UWP) 開発者にとっての意味</span><span class="sxs-lookup"><span data-stu-id="8b820-176">.NET Native - What it means for Universal Windows Platform (UWP) developers</span></span>](https://blogs.windows.com/buildingapps/2015/08/20/net-native-what-it-means-for-universal-windows-platform-uwp-developers/#TYsD3tJuBJpK3Hc7.97)
* [<span data-ttu-id="8b820-177">.NET でのユニバーサル Windows アプリ</span><span class="sxs-lookup"><span data-stu-id="8b820-177">Universal Windows apps in .NET</span></span>](https://blogs.msdn.microsoft.com/dotnet/2015/07/30/universal-windows-apps-in-net)
* [<span data-ttu-id="8b820-178">UWP アプリの .NET</span><span class="sxs-lookup"><span data-stu-id="8b820-178">.NET for UWP apps</span></span>](https://msdn.microsoft.com/library/mt185501.aspx)
