---
author: mcleanbyron
ms.assetid: 646977ed-1705-4ea7-a3db-a6b9aac70703
description: JavaScript/HTML. を使ってスポット広告を起動する方法について説明します。
title: JavaScript を使ったスポット広告のサンプル コード
ms.author: mcleans
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP, 広告, Advertising, スポット, JavaScript, サンプルコード
ms.localizationpriority: medium
ms.openlocfilehash: f0cd50a8d3a08053f04dd0e6e8afbfafc8ef34dd
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1690348"
---
# <a name="interstitial-ad-sample-code-in-javascript"></a>JavaScript を使ったスポット広告のサンプル コード

このトピックでは、スポット広告を表示する基本的な JavaScript と HTML のユニバーサル Windows プラットフォーム (UWP) アプリの完全なサンプル コードを示します。 このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。 完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads) をご覧ください。

## <a name="code-example"></a>コードの例

このセクションでは、スポット広告を表示する基本的なアプリの HTML と JavaScript ファイルの内容を示します。 これらの例を使用するには、コードを Visual Studio の JavaScript の **WinJS アプリ (ユニバーサル Windows)** プロジェクトにコピーします。

このサンプル アプリでは 2 つのボタンを使用して、スポット広告を要求して起動します。 Visual Studio によって生成された main.js ファイルと index.html ファイルは変更されています。これらのファイルを次に示します。 次に示す script.js ファイルには、サンプルのコードの大半が含まれています。このファイルは **js** フォルダーのプロジェクトに追加します。

Microsoft Store にアプリを提出する前に、```applicationId``` 変数と ```adUnitId``` 変数の値を Windows デベロッパー センターから取得した実際の値に置き換えます。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。

> [!NOTE]
> ビデオ スポット広告ではなくバナー スポット広告を表示するようにこの例を変更するには、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドの最初のパラメーターとして、**InterstitialAdType.video** の代わりに値 **InterstitialAdType.display** を渡します。 詳しくは、「[スポット広告](interstitial-ads.md)」をご覧ください。

### <a name="indexhtml"></a>index.html

> [!div class="tabbedCodeSnippets"]
[!code-html[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/index.html#L1-L21)]

### <a name="scriptjs"></a>script.js

> [!div class="tabbedCodeSnippets"]
[!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#script)]

### <a name="mainjs"></a>main.js

> [!div class="tabbedCodeSnippets"]
[!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/main.js#main)]

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 
