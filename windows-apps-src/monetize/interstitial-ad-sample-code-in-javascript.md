---
author: mcleanbyron
ms.assetid: 646977ed-1705-4ea7-a3db-a6b9aac70703
description: "JavaScript/HTML. を使ってスポット広告を起動する方法について説明します。"
title: "JavaScript を使ったスポット広告のサンプル コード"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, UWP, 広告, Advertising, スポット, JavaScript, サンプルコード"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 91a54bdd2e41b3e7df0ee0aad32448ab9ed66ac0
ms.lasthandoff: 02/07/2017

---

# <a name="interstitial-ad-sample-code-in-javascript"></a>JavaScript を使ったスポット広告のサンプル コード

このトピックでは、スポット広告を表示する基本的な JavaScript と HTML のユニバーサル Windows プラットフォーム (UWP) アプリの完全なサンプル コードを示します。 このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。 完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads) をご覧ください。

## <a name="code-example"></a>コードの例

このセクションでは、スポット広告を表示する基本的なアプリの HTML と JavaScript ファイルの内容を示します。 これらの例を使用するには、コードをVisual Studio 2015 の JavaScript の **WinJS アプリ (ユニバーサル Windows)** プロジェクトにコピーします。

このサンプル アプリではスポット広告を要求し起動させる 2 つのボタンを使用します。 Visual Studio によって生成された main.js ファイルと index.html ファイルは変更されています。これらのファイルを次に示します。 次に示す script.js ファイルには、サンプルのコードの大半が含まれています。このファイルは **js** フォルダーのプロジェクトに追加します。

>**Windows 8.x と Windows Phone 8.1 に関する注意**&nbsp;&nbsp;プロジェクトのターゲットが Windows 8.1 または Windows Phone 8.1の場合、プロジェクトの既定の HTML ファイル名は index.html ではなく default.html で、プロジェクトの既定の JavaScript ファイル名は main.js ではなく default.js です。

ストアにアプリを提出する前に、```applicationId``` と ```adUnitId``` 変数の値を Windows デベロッパー センターから取得した実際の値に置き換えてください。詳細については、「[アプリで広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。

### <a name="indexhtml"></a>index.html

> [!div class="tabbedCodeSnippets"]
[!code-html[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/index.html#L1-L21)]

<span/>
>**Windows 8.x と Windows Phone 8.1 に関する注意**&nbsp;&nbsp;プロジェクトのターゲットが Windows 8.1 または Windows Phone 8.1の場合、サンプルの ```<script src="//Microsoft.Advertising.JavaScript/ad.js"></script>``` 行を ```<script src="/MSAdvertisingJS/ads/ad.js"></script>``` に置き換えます。

### <a name="scriptjs"></a>script.js

> [!div class="tabbedCodeSnippets"]
[!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#script)]

### <a name="mainjs"></a>main.js

> [!div class="tabbedCodeSnippets"]
[!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/main.js#main)]

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 

