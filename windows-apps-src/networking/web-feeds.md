---
description: Windows.Web.Syndication 名前空間の機能を利用し、RSS や Atom の標準に従って生成される概要フィードを使って、最新の人気の高い Web コンテンツを取得または作成します。
title: RSS/Atom フィード
ms.assetid: B196E19B-4610-4EFA-8FDF-AF9B10D78843
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5b5312614c7060118fdb4678aa80ae51d6734486
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8204897"
---
# <a name="rssatom-feeds"></a>RSS/Atom フィード


**重要な API**

-   [**Windows.Data.Xml.Dom**](https://msdn.microsoft.com/library/windows/apps/br240819)
-   [**Windows.Web.AtomPub**](https://msdn.microsoft.com/library/windows/apps/br210609)
-   [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632)

[**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間の機能により、RSS や Atom に従って生成される概要フィードを使って、最新かつ人気の高い Web コンテンツを取得または作成します。

## <a name="what-is-a-feed"></a>フィードとは

Web フィードは、テキストやリンク、画像といった個々のエントリをいくつでも含むことのできるドキュメントです。 フィードに対する更新は、新規エントリの形式で行います。この新しいエントリを使って、最新のコンテンツが Web 上に配信されます。 コンテンツの利用者は、フィード リーダー アプリを使って、多数のコンテンツ作成者からのフィードを収集、監視でき、最新のコンテンツにすばやく手間をかけずにアクセスすることができます。

## <a name="which-feed-format-standards-are-supported"></a>サポートされるフィード形式

ユニバーサル Windows プラットフォーム (UWP) では、RSS 形式 (0.91 ～ 2.0) と Atom 形式 (0.3 ～ 1.0) のフィードを取得することができます。 [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間のクラスは、RSS と Atom のどちらの要素も表せるフィードとフィード項目を定義することができます。

加えて、Atom 1.0 形式と RSS 2.0 形式では、公式の仕様には定義されていない要素や属性をフィード ドキュメントに含めることができます。 やがて、こうしたカスタムの要素や属性が、他の Web サービスのデータ形式 (GData、OData など) によって使用されるドメイン固有の情報を定義するための手段となりました。 この追加機能をサポートするため、[**SyndicationNode**](https://msdn.microsoft.com/library/windows/apps/br243585) クラスは XML 要素全般を表します。 [**Windows.Data.Xml.Dom**](https://msdn.microsoft.com/library/windows/apps/br240819) 名前空間のクラスと **SyndicationNode** クラスを使うことによって、アプリは属性、拡張機能、含まれるすべてのコンテンツにアクセスできるようになります。

概要コンテンツの発行については、UWP による Atom Publication Protocol の実装 ([**Windows.Web.AtomPub**](https://msdn.microsoft.com/library/windows/apps/br210609)) は、Atom および Atom Publication に準拠したフィード コンテンツ操作のみをサポートする点に注意してください。

## <a name="using-syndicated-content-with-network-isolation"></a>概要コンテンツとネットワーク分離の併用

開発者は UWP のネットワーク分離機能を使って、UWP アプリによるネットワーク アクセスを制御および制限できます。 すべてのアプリにネットワークへのアクセスが必要なわけではありません。 ただし、アクセスが必要な場合は、UWP にはさまざまなレベルのネットワーク アクセスが用意されており、それは適切な機能を選ぶことで有効にできます。

ネットワーク分離では、開発者が必要なネットワーク アクセスのスコープをアプリごとに定義できます。 適切なスコープが定義されていないアプリは、特定の種類のネットワークや特定の種類のネットワーク要求 (クライアント側から開始される出力方向の要求、または相手から開始される入力方向の要求とクライアント側から開始される出力方向の要求の両方) にアクセスできません。 ネットワーク分離を設定して強制的に適用できるため、アプリのセキュリティが侵害されたとしても、そこからアクセスできるネットワークは、そのアプリに対して明示的に許可されている範囲に限られます。 そのため、他のアプリケーションや Windows そのものへの影響をきわめて小さくすることができます。

ネットワーク分離は、ネットワーク アクセスを試みる [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間と [**Windows.Web.AtomPub**](https://msdn.microsoft.com/library/windows/apps/br210609) 名前空間のすべてのクラス要素に影響します。 ネットワーク分離は、Windows によって能動的かつ強制的に適用されます。 適切なネットワーク機能が有効になっていなければ、ネットワーク アクセスを付随する **Windows.Web.Syndication** 名前空間や **Windows.Web.AtomPub** 名前空間のクラス要素の呼び出しは失敗する可能性があります。

アプリのネットワーク機能は、アプリのビルド時にアプリ マニフェストで構成します。 ネットワーク機能は通常、アプリを開発するときは、Microsoft Visual Studio2015 を使用して追加します。 アプリ マニフェスト ファイルをテキスト エディターで直接編集してネットワーク機能を設定することもできます。

ネットワーク分離とネットワーク機能について詳しくは、「[ネットワークの基本](networking-basics.md)」トピックの「機能」セクションをご覧ください。

## <a name="how-to-access-a-web-feed"></a>Web フィードにアクセスする方法

このセクションでは、C# または Javascript で記述された UWP アプリで [**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間のクラスを使って、Web フィードを取得および表示する方法について説明します。

**前提条件**

UWP アプリをネットワークに対応させるには、プロジェクトの **Package.appxmanifest** ファイルで必要なネットワーク機能を設定する必要があります。 アプリがクライアントとしてインターネット上のリモート サービスに接続する必要がある場合は、**internetClient** 機能が必要です。 詳しくは、「[ネットワークの基礎](networking-basics.md)」トピックの「機能」セクションをご覧ください。

**Web フィードからの概要コンテンツの取得**

ここでは、フィードを取得し、そこに含まれている個々の項目を表示するコードを見ていきます。 要求を構成して送信する前に、操作で必要ないくつかの変数を定義し、[**SyndicationClient**](https://msdn.microsoft.com/library/windows/apps/br243456) のインスタンスを初期化します。そうすることでフィードを取得して表示する際に必要なメソッドとプロパティを定義します。

[**Uri **](https://msdn.microsoft.com/library/windows/apps/br226017) コンストラクターは、渡された *uriString* が有効な URI ではない場合は、例外をスローします。 そこで、try/catch ブロックを使って *uriString* を検証します。

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

次に、必要なサーバーの資格情報 ([**ServerCredential**](https://msdn.microsoft.com/library/windows/apps/br243461) プロパティ)、プロキシの資格情報 ([**ProxyCredential**](https://msdn.microsoft.com/library/windows/apps/br243459) プロパティ)、HTTP ヘッダー ([**SetRequestHeader**](https://msdn.microsoft.com/library/windows/apps/br243462) メソッド) を設定して要求を構成します。 基本的な要求パラメーターが構成されると、アプリによって指定されたフィード URI 文字列を使って有効な [**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) オブジェクトが作成されます。 すると、**Uri** オブジェクトが [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) 関数に渡され、フィードが要求されます。

目的のフィード コンテンツが返されたら、**displayCurrentItem** (以下で定義) が呼び出され、それぞれのフィード項目が反復処理されます。そして当該の UI を介して項目とそのコンテンツがリストとして表示されます。

非同期ネットワーク メソッドの多くは、呼び出すとき、例外を処理するようにコードを記述する必要があります。 例外ハンドラーは例外の原因について詳細な情報を取得でき、エラーの理解と適切な判断に役立ちます。

[**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) メソッドは、ネットワーク サーバーとの接続が確立できなかった場合や、[**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) オブジェクトが有効な AtomPub や RSS フィードを指してない場合に、例外をスローします。 Javascript サンプル コードでは、**onError** 関数を使って、エラーが発生した場合に例外をキャッチし、例外に関する詳細な情報を出力するようにしています。

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

前段階では、[**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/br243460) で要求対象のフィード コンテンツを取得し、フィード項目を反復処理しました。 各項目は [**SyndicationItem**](https://msdn.microsoft.com/library/windows/apps/br243533)オブジェクトで表され、フィード配信規格 (RSS または Atom) でサポートされているすべての項目のプロパティとコンテンツはこのオブジェクトに格納されています。 次の例では、各項目を処理し、対応する UI 要素を介してその内容を表示する **displayCurrentItem** 関数を詳しく見ていきます。

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

先ほども触れましたが、[**SyndicationItem**](https://msdn.microsoft.com/library/windows/apps/br243533) オブジェクトによって表されるコンテンツの種類は、フィードの発行に採用されている規格 (RSS または Atom) によって異なります。 たとえば、Atom フィードは [**Contributors**](https://msdn.microsoft.com/library/windows/apps/br243540) のリスト化に対応していますが、RSS フィードは対応していません。 ただし、どちらの規格でもサポートされていないフィード項目内の拡張要素 (Dublin Core の extension 要素など) は、次のコード例のように [**SyndicationItem.ElementExtensions**](https://msdn.microsoft.com/library/windows/apps/br243543) プロパティでアクセスし、表示することができます。

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
