---
description: Windows.Web.Syndication 名前空間の機能を利用し、RSS や Atom の標準に従って生成される概要フィードを使って、最新の人気の高い Web コンテンツを取得または作成します。
title: RSS/Atom フィード
ms.assetid: B196E19B-4610-4EFA-8FDF-AF9B10D78843
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5b5312614c7060118fdb4678aa80ae51d6734486
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8794172"
---
# <a name="rssatom-feeds"></a><span data-ttu-id="394fc-104">RSS/Atom フィード</span><span class="sxs-lookup"><span data-stu-id="394fc-104">RSS/Atom feeds</span></span>


**<span data-ttu-id="394fc-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="394fc-105">Important APIs</span></span>**

-   [**<span data-ttu-id="394fc-106">Windows.Data.Xml.Dom</span><span class="sxs-lookup"><span data-stu-id="394fc-106">Windows.Data.Xml.Dom</span></span>**](https://msdn.microsoft.com/library/windows/apps/br240819)
-   [**<span data-ttu-id="394fc-107">Windows.Web.AtomPub</span><span class="sxs-lookup"><span data-stu-id="394fc-107">Windows.Web.AtomPub</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210609)
-   [**<span data-ttu-id="394fc-108">Windows.Web.Syndication</span><span class="sxs-lookup"><span data-stu-id="394fc-108">Windows.Web.Syndication</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243632)

<span data-ttu-id="394fc-109">[**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間の機能により、RSS や Atom に従って生成される概要フィードを使って、最新かつ人気の高い Web コンテンツを取得または作成します。</span><span class="sxs-lookup"><span data-stu-id="394fc-109">Retrieve or create the most current and popular Web content using syndicated feeds generated according to the RSS and Atom standards using features in the [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) namespace.</span></span>

## <a name="what-is-a-feed"></a><span data-ttu-id="394fc-110">フィードとは</span><span class="sxs-lookup"><span data-stu-id="394fc-110">What is a feed?</span></span>

<span data-ttu-id="394fc-111">Web フィードは、テキストやリンク、画像といった個々のエントリをいくつでも含むことのできるドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="394fc-111">A web feed is a document that contains any number of individual entries made up of text, links, and images.</span></span> <span data-ttu-id="394fc-112">フィードに対する更新は、新規エントリの形式で行います。この新しいエントリを使って、最新のコンテンツが Web 上に配信されます。</span><span class="sxs-lookup"><span data-stu-id="394fc-112">Updates made to a feed are in the form of new entries used to promote the latest content across the Web.</span></span> <span data-ttu-id="394fc-113">コンテンツの利用者は、フィード リーダー アプリを使って、多数のコンテンツ作成者からのフィードを収集、監視でき、最新のコンテンツにすばやく手間をかけずにアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="394fc-113">Content consumers can use a feed reader app to aggregate and monitor feeds from any number of individual content authors, gaining access to the latest content quickly and conveniently.</span></span>

## <a name="which-feed-format-standards-are-supported"></a><span data-ttu-id="394fc-114">サポートされるフィード形式</span><span class="sxs-lookup"><span data-stu-id="394fc-114">Which feed format standards are supported?</span></span>

<span data-ttu-id="394fc-115">ユニバーサル Windows プラットフォーム (UWP) では、RSS 形式 (0.91 ～ 2.0) と Atom 形式 (0.3 ～ 1.0) のフィードを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="394fc-115">The Universal Windows Platform (UWP) supports feed retrieval for RSS format standards from 0.91 to RSS 2.0, and Atom standards from 0.3 to 1.0.</span></span> <span data-ttu-id="394fc-116">[**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間のクラスは、RSS と Atom のどちらの要素も表せるフィードとフィード項目を定義することができます。</span><span class="sxs-lookup"><span data-stu-id="394fc-116">Classes in the [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) namespace can define feeds and feed items capable of representing both RSS and Atom elements.</span></span>

<span data-ttu-id="394fc-117">加えて、Atom 1.0 形式と RSS 2.0 形式では、公式の仕様には定義されていない要素や属性をフィード ドキュメントに含めることができます。</span><span class="sxs-lookup"><span data-stu-id="394fc-117">Additionally, Atom 1.0 and RSS 2.0 formats both allow their feed documents to contain elements or attributes not defined in the official specifications.</span></span> <span data-ttu-id="394fc-118">やがて、こうしたカスタムの要素や属性が、他の Web サービスのデータ形式 (GData、OData など) によって使用されるドメイン固有の情報を定義するための手段となりました。</span><span class="sxs-lookup"><span data-stu-id="394fc-118">Over time, these custom elements and attributes have become a way to define domain-specific information consumed by other web service data formats like GData and OData.</span></span> <span data-ttu-id="394fc-119">この追加機能をサポートするため、[**SyndicationNode**](https://msdn.microsoft.com/library/windows/apps/br243585) クラスは XML 要素全般を表します。</span><span class="sxs-lookup"><span data-stu-id="394fc-119">To support this added feature, the [**SyndicationNode**](https://msdn.microsoft.com/library/windows/apps/br243585) class represents generic XML elements.</span></span> <span data-ttu-id="394fc-120">[**Windows.Data.Xml.Dom**](https://msdn.microsoft.com/library/windows/apps/br240819) 名前空間のクラスと **SyndicationNode** クラスを使うことによって、アプリは属性、拡張機能、含まれるすべてのコンテンツにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="394fc-120">Using **SyndicationNode** with classes in the [**Windows.Data.Xml.Dom**](https://msdn.microsoft.com/library/windows/apps/br240819) namespace, allows apps to access attributes, extensions, and any content that they may contain.</span></span>

<span data-ttu-id="394fc-121">概要コンテンツの発行については、UWP による Atom Publication Protocol の実装 ([**Windows.Web.AtomPub**](https://msdn.microsoft.com/library/windows/apps/br210609)) は、Atom および Atom Publication に準拠したフィード コンテンツ操作のみをサポートする点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="394fc-121">Note that, for publication of syndicated content, the UWP implementation of the Atom Publication Protocol ([**Windows.Web.AtomPub**](https://msdn.microsoft.com/library/windows/apps/br210609)) only supports feed content operations according to the Atom and Atom Publication standards.</span></span>

## <a name="using-syndicated-content-with-network-isolation"></a><span data-ttu-id="394fc-122">概要コンテンツとネットワーク分離の併用</span><span class="sxs-lookup"><span data-stu-id="394fc-122">Using syndicated content with network isolation</span></span>

<span data-ttu-id="394fc-123">開発者は UWP のネットワーク分離機能を使って、UWP アプリによるネットワーク アクセスを制御および制限できます。</span><span class="sxs-lookup"><span data-stu-id="394fc-123">The network isolation feature in the UWP enables a developer to control and limit network access by a UWP app.</span></span> <span data-ttu-id="394fc-124">すべてのアプリにネットワークへのアクセスが必要なわけではありません。</span><span class="sxs-lookup"><span data-stu-id="394fc-124">Not all apps may require access to the network.</span></span> <span data-ttu-id="394fc-125">ただし、アクセスが必要な場合は、UWP にはさまざまなレベルのネットワーク アクセスが用意されており、それは適切な機能を選ぶことで有効にできます。</span><span class="sxs-lookup"><span data-stu-id="394fc-125">However for those apps that do, UWP provides different levels of access to the network that can be enabled by selecting appropriate capabilities.</span></span>

<span data-ttu-id="394fc-126">ネットワーク分離では、開発者が必要なネットワーク アクセスのスコープをアプリごとに定義できます。</span><span class="sxs-lookup"><span data-stu-id="394fc-126">Network isolation allows a developer to define for each app the scope of required network access.</span></span> <span data-ttu-id="394fc-127">適切なスコープが定義されていないアプリは、特定の種類のネットワークや特定の種類のネットワーク要求 (クライアント側から開始される出力方向の要求、または相手から開始される入力方向の要求とクライアント側から開始される出力方向の要求の両方) にアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="394fc-127">An app without the appropriate scope defined is prevented from accessing the specified type of network, and specific type of network request (outbound client-initiated requests or both inbound unsolicited requests and outbound client-initiated requests).</span></span> <span data-ttu-id="394fc-128">ネットワーク分離を設定して強制的に適用できるため、アプリのセキュリティが侵害されたとしても、そこからアクセスできるネットワークは、そのアプリに対して明示的に許可されている範囲に限られます。</span><span class="sxs-lookup"><span data-stu-id="394fc-128">The ability to set and enforce network isolation ensures that if an app does get compromised, it can only access networks where the app has explicitly been granted access.</span></span> <span data-ttu-id="394fc-129">そのため、他のアプリケーションや Windows そのものへの影響をきわめて小さくすることができます。</span><span class="sxs-lookup"><span data-stu-id="394fc-129">This significantly reduces the scope of the impact on other applications and on Windows.</span></span>

<span data-ttu-id="394fc-130">ネットワーク分離は、ネットワーク アクセスを試みる [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間と [**Windows.Web.AtomPub**](https://msdn.microsoft.com/library/windows/apps/br210609) 名前空間のすべてのクラス要素に影響します。</span><span class="sxs-lookup"><span data-stu-id="394fc-130">Network isolation affects any class elements in the [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) and [**Windows.Web.AtomPub**](https://msdn.microsoft.com/library/windows/apps/br210609) namespaces that try to access the network.</span></span> <span data-ttu-id="394fc-131">ネットワーク分離は、Windows によって能動的かつ強制的に適用されます。</span><span class="sxs-lookup"><span data-stu-id="394fc-131">Windows actively enforces network isolation.</span></span> <span data-ttu-id="394fc-132">適切なネットワーク機能が有効になっていなければ、ネットワーク アクセスを付随する **Windows.Web.Syndication** 名前空間や **Windows.Web.AtomPub** 名前空間のクラス要素の呼び出しは失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="394fc-132">A call to a class element in the **Windows.Web.Syndication** or **Windows.Web.AtomPub** namespace that results in network access may fail because of network isolation if the appropriate network capability has not been enabled.</span></span>

<span data-ttu-id="394fc-133">アプリのネットワーク機能は、アプリのビルド時にアプリ マニフェストで構成します。</span><span class="sxs-lookup"><span data-stu-id="394fc-133">The network capabilities for an app are configured in the app manifest when the app is built.</span></span> <span data-ttu-id="394fc-134">ネットワーク機能は通常、アプリを開発するときは、Microsoft Visual Studio2015 を使用して追加します。</span><span class="sxs-lookup"><span data-stu-id="394fc-134">Network capabilities are usually added using Microsoft Visual Studio2015 when developing the app.</span></span> <span data-ttu-id="394fc-135">アプリ マニフェスト ファイルをテキスト エディターで直接編集してネットワーク機能を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="394fc-135">Network capabilities may also be set manually in the app manifest file using a text editor.</span></span>

<span data-ttu-id="394fc-136">ネットワーク分離とネットワーク機能について詳しくは、「[ネットワークの基本](networking-basics.md)」トピックの「機能」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="394fc-136">For more detailed information on network isolation and networking capabilities, see the "Capabilities" section in the [Networking basics](networking-basics.md) topic.</span></span>

## <a name="how-to-access-a-web-feed"></a><span data-ttu-id="394fc-137">Web フィードにアクセスする方法</span><span class="sxs-lookup"><span data-stu-id="394fc-137">How to access a web feed</span></span>

<span data-ttu-id="394fc-138">このセクションでは、C# または Javascript で記述された UWP アプリで [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間のクラスを使って、Web フィードを取得および表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="394fc-138">This section shows how to retrieve and display a web feed using classes in the [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) namespace in your UWP app written in C# or Javascript.</span></span>

**<span data-ttu-id="394fc-139">前提条件</span><span class="sxs-lookup"><span data-stu-id="394fc-139">Prerequisites</span></span>**

<span data-ttu-id="394fc-140">UWP アプリをネットワークに対応させるには、プロジェクトの **Package.appxmanifest** ファイルで必要なネットワーク機能を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="394fc-140">To ensure your UWP app is network ready, you must set any network capabilities that are needed in the project **Package.appxmanifest** file.</span></span> <span data-ttu-id="394fc-141">アプリがクライアントとしてインターネット上のリモート サービスに接続する必要がある場合は、**internetClient** 機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="394fc-141">If your app needs to connect as a client to remote services on the Internet, then the **internetClient** capability is needed.</span></span> <span data-ttu-id="394fc-142">詳しくは、「[ネットワークの基礎](networking-basics.md)」トピックの「機能」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="394fc-142">For more information, see the "Capabilities" section in the [Networking basics](networking-basics.md) topic.</span></span>

**<span data-ttu-id="394fc-143">Web フィードからの概要コンテンツの取得</span><span class="sxs-lookup"><span data-stu-id="394fc-143">Retrieving syndicated content from a web feed</span></span>**

<span data-ttu-id="394fc-144">ここでは、フィードを取得し、そこに含まれている個々の項目を表示するコードを見ていきます。</span><span class="sxs-lookup"><span data-stu-id="394fc-144">Now we will review some code that demonstrates how to retrieve a feed, and then display each individual item that the feed contains.</span></span> <span data-ttu-id="394fc-145">要求を構成して送信する前に、操作で必要ないくつかの変数を定義し、[**SyndicationClient**](https://msdn.microsoft.com/library/windows/apps/br243456) のインスタンスを初期化します。そうすることでフィードを取得して表示する際に必要なメソッドとプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="394fc-145">Before we can configure and send the request, we'll define a few variables we'll be using during the operation, and initialize an instance of [**SyndicationClient**](https://msdn.microsoft.com/library/windows/apps/br243456), which defines the methods and properties we'll use to retrieve and display the feed.</span></span>

<span data-ttu-id="394fc-146">[\*\*Uri \*\*](https://msdn.microsoft.com/library/windows/apps/br226017) コンストラクターは、渡された *uriString* が有効な URI ではない場合は、例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="394fc-146">The [**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) constructor throws an exception if the *uriString* passed to the constructor is not a valid URI.</span></span> <span data-ttu-id="394fc-147">そこで、try/catch ブロックを使って *uriString* を検証します。</span><span class="sxs-lookup"><span data-stu-id="394fc-147">So we validate the *uriString* using a try/catch block.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
Windows.Web.Syndication.SyndicationClient client = new Windows.Web.Syndication.SyndicationClient();
Windows.Web.Syndication.SyndicationFeed feed;
// The URI is validated by catching exceptions thrown by the Uri constructor.
Uri uri = null;
// Use your own uriString for the feed you are connecting to.
string uriString = "";
try
{
    uri = new Uri(uriString);
}
catch (Exception ex)
{
    // Handle the invalid URI here.
}
```
```javascript
var currentFeed = null;
var currentItemIndex = 0;
var client = new Windows.Web.Syndication.SyndicationClient();
// The URI is validated by catching exceptions thrown by the Uri constructor.
var uri = null;
try {
    uri = new Windows.Foundation.Uri(uriString);
} catch (error) {
    WinJS.log && WinJS.log("Error: Invalid URI");
    return;
}
```

<span data-ttu-id="394fc-148">次に、必要なサーバーの資格情報 ([**ServerCredential**](https://msdn.microsoft.com/library/windows/apps/br243461) プロパティ)、プロキシの資格情報 ([**ProxyCredential**](https://msdn.microsoft.com/library/windows/apps/br243459) プロパティ)、HTTP ヘッダー ([**SetRequestHeader**](https://msdn.microsoft.com/library/windows/apps/br243462) メソッド) を設定して要求を構成します。</span><span class="sxs-lookup"><span data-stu-id="394fc-148">Next we configure the request by setting any Server credentials (the [**ServerCredential**](https://msdn.microsoft.com/library/windows/apps/br243461) property), proxy credentials (the [**ProxyCredential**](https://msdn.microsoft.com/library/windows/apps/br243459) property), and HTTP headers (the [**SetRequestHeader**](https://msdn.microsoft.com/library/windows/apps/br243462) method) needed.</span></span> <span data-ttu-id="394fc-149">基本的な要求パラメーターが構成されると、アプリによって指定されたフィード URI 文字列を使って有効な [**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="394fc-149">With the basic request parameters configured, a valid [**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) object, created using a feed URI string provided by the app.</span></span> <span data-ttu-id="394fc-150">すると、**Uri** オブジェクトが [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) 関数に渡され、フィードが要求されます。</span><span class="sxs-lookup"><span data-stu-id="394fc-150">The **Uri** object is then passed to the [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) function to request the feed.</span></span>

<span data-ttu-id="394fc-151">目的のフィード コンテンツが返されたら、**displayCurrentItem** (以下で定義) が呼び出され、それぞれのフィード項目が反復処理されます。そして当該の UI を介して項目とそのコンテンツがリストとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="394fc-151">Assuming the desired feed content was returned, the example code iterates through each feed item, calling **displayCurrentItem** (which we define next), to display items and their contents as a list through the UI.</span></span>

<span data-ttu-id="394fc-152">非同期ネットワーク メソッドの多くは、呼び出すとき、例外を処理するようにコードを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="394fc-152">You must write code to handle exceptions when you call most asynchronous network methods.</span></span> <span data-ttu-id="394fc-153">例外ハンドラーは例外の原因について詳細な情報を取得でき、エラーの理解と適切な判断に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="394fc-153">Your exception handler can retrieve more detailed information on the cause of the exception to better understand the failure and make appropriate decisions.</span></span>

<span data-ttu-id="394fc-154">[**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) メソッドは、ネットワーク サーバーとの接続が確立できなかった場合や、[**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) オブジェクトが有効な AtomPub や RSS フィードを指してない場合に、例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="394fc-154">The [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) method throws an exception if a connection could not be established with the HTTP server or the [**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) object does not point to a valid AtomPub or RSS feed.</span></span> <span data-ttu-id="394fc-155">Javascript サンプル コードでは、**onError** 関数を使って、エラーが発生した場合に例外をキャッチし、例外に関する詳細な情報を出力するようにしています。</span><span class="sxs-lookup"><span data-stu-id="394fc-155">The Javascript sample code uses an **onError** function to catch any exceptions and print out more detailed information on the exception if an error occurs.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
try
{
    // Although most HTTP servers do not require User-Agent header, 
    // others will reject the request or return a different response if this header is missing.
    // Use the setRequestHeader() method to add custom headers.
    client.SetRequestHeader("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
    feed = await client.RetrieveFeedAsync(uri);
    // Retrieve the title of the feed and store it in a string.
    string title = feed.Title.Text;
    // Iterate through each feed item.
    foreach (Windows.Web.Syndication.SyndicationItem item in feed.Items)
    {
        displayCurrentItem(item);
    }
}
catch (Exception ex)
{
    // Handle the exception here.
}
```
```javascript
function onError(err) {
    WinJS.log && WinJS.log(err, "sample", "error");
    // Match error number with a ErrorStatus value.
    // Use Windows.Web.WebErrorStatus.getStatus() to retrieve HTTP error status codes.
    var errorStatus = Windows.Web.Syndication.SyndicationError.getStatus(err.number);
    if (errorStatus === Windows.Web.Syndication.SyndicationErrorStatus.invalidXml) {
        displayLog("An invalid XML exception was thrown. Please make sure to use a URI that points to a RSS or Atom feed.");
    }
}
// Retrieve and display feed at given feed address.
function retreiveFeed(uri) {
    // Although most HTTP servers do not require User-Agent header, 
    // others will reject the request or return a different response if this header is missing.
    // Use the setRequestHeader() method to add custom headers.
    client.setRequestHeader("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
    client.retrieveFeedAsync(uri).done(function (feed) {
        currentFeed = feed;
        WinJS.log && WinJS.log("Feed download complete.", "sample", "status");
        var title = "(no title)";
        if (currentFeed.title) {
            title = currentFeed.title.text;
        }
        document.getElementById("CurrentFeedTitle").innerText = title;
        currentItemIndex = 0;
        if (currentFeed.items.size > 0) {
            displayCurrentItem();
        }
        // List the items.
        displayLog("Items: " + currentFeed.items.size);
     }, onError);
}
```

<span data-ttu-id="394fc-156">前段階では、[**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) で要求対象のフィード コンテンツを取得し、フィード項目を反復処理しました。</span><span class="sxs-lookup"><span data-stu-id="394fc-156">In the previous step, [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) returned the requested feed content and the example code got to work iterating through available feed items.</span></span> <span data-ttu-id="394fc-157">各項目は [**SyndicationItem**](https://msdn.microsoft.com/library/windows/apps/br243533)オブジェクトで表され、フィード配信規格 (RSS または Atom) でサポートされているすべての項目のプロパティとコンテンツはこのオブジェクトに格納されています。</span><span class="sxs-lookup"><span data-stu-id="394fc-157">Each of these items is represented using a [**SyndicationItem**](https://msdn.microsoft.com/library/windows/apps/br243533) object that contains all of the item properties and content afforded by the relevant syndication standard (RSS or Atom).</span></span> <span data-ttu-id="394fc-158">次の例では、各項目を処理し、対応する UI 要素を介してその内容を表示する **displayCurrentItem** 関数を詳しく見ていきます。</span><span class="sxs-lookup"><span data-stu-id="394fc-158">In the following example we observe the **displayCurrentItem** function working through each item and displaying its content through various named UI elements.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
private void displayCurrentItem(Windows.Web.Syndication.SyndicationItem item)
{
    string itemTitle = item.Title == null ? "No title" : item.Title.Text;
    string itemLink = item.Links == null ? "No link" : item.Links.FirstOrDefault().ToString();
    string itemContent = item.Content == null ? "No content" : item.Content.Text;
    //displayCurrentItem is continued below.
```
```javascript
function displayCurrentItem() {
    var item = currentFeed.items[currentItemIndex];
    // Display item number.
    document.getElementById("Index").innerText = (currentItemIndex + 1) + " of " + currentFeed.items.size;
    // Display title.
    var title = "(no title)";
    if (item.title) {
        title = item.title.text;
    }
    document.getElementById("ItemTitle").innerText = title;
    // Display the main link.
    var link = "";
    if (item.links.size > 0) {
        link = item.links[0].uri.absoluteUri;
    }
    var link = document.getElementById("Link");
    link.innerText = link;
    link.href = link;
    // Display the body as HTML.
    var content = "(no content)";
    if (item.content) {
        content = item.content.text;
    }
    else if (item.summary) {
        content = item.summary.text;
    }
    document.getElementById("WebView").innerHTML = window.toStaticHTML(content);
                //displayCurrentItem is continued below.
```

<span data-ttu-id="394fc-159">先ほども触れましたが、[**SyndicationItem**](https://msdn.microsoft.com/library/windows/apps/br243533) オブジェクトによって表されるコンテンツの種類は、フィードの発行に採用されている規格 (RSS または Atom) によって異なります。</span><span class="sxs-lookup"><span data-stu-id="394fc-159">As suggested earlier, the type of content represented by a [**SyndicationItem**](https://msdn.microsoft.com/library/windows/apps/br243533) object will differ depending on the feed standard (RSS or Atom) employed to publish the feed.</span></span> <span data-ttu-id="394fc-160">たとえば、Atom フィードは [**Contributors**](https://msdn.microsoft.com/library/windows/apps/br243540) のリスト化に対応していますが、RSS フィードは対応していません。</span><span class="sxs-lookup"><span data-stu-id="394fc-160">For example, an Atom feed is capable of providing a list of [**Contributors**](https://msdn.microsoft.com/library/windows/apps/br243540), but an RSS feed is not.</span></span> <span data-ttu-id="394fc-161">ただし、どちらの規格でもサポートされていないフィード項目内の拡張要素 (Dublin Core の extension 要素など) は、次のコード例のように [**SyndicationItem.ElementExtensions**](https://msdn.microsoft.com/library/windows/apps/br243543) プロパティでアクセスし、表示することができます。</span><span class="sxs-lookup"><span data-stu-id="394fc-161">However, extension elements included in a feed item that are not supported by either standard (e.g., Dublin Core extension elements) can be accessed using the [**SyndicationItem.ElementExtensions**](https://msdn.microsoft.com/library/windows/apps/br243543) property and then displayed as demonstrated in the following example code.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
    //displayCurrentItem continued.
    string extensions = "";
    foreach (Windows.Web.Syndication.SyndicationNode node in item.ElementExtensions)
    {
        string nodeName = node.NodeName;
        string nodeNamespace = node.NodeNamespace;
        string nodeValue = node.NodeValue;
        extensions += nodeName + "\n" + nodeNamespace + "\n" + nodeValue + "\n";
    }
    this.listView.Items.Add(itemTitle + "\n" + itemLink + "\n" + itemContent + "\n" + extensions);
}
```
```javascript
    // displayCurrentItem function continued.
    var bindableNodes = [];
    for (var i = 0; i < item.elementExtensions.size; i++) {
        var bindableNode = {
            nodeName: item.elementExtensions[i].nodeName,
             nodeNamespace: item.elementExtensions[i].nodeNamespace,
             nodeValue: item.elementExtensions[i].nodeValue,
        };
        bindableNodes.push(bindableNode);
    }
    var dataList = new WinJS.Binding.List(bindableNodes);
    var listView = document.getElementById("extensionsListView").winControl;
    WinJS.UI.setOptions(listView, {
        itemDataSource: dataList.dataSource
    });
}
```
