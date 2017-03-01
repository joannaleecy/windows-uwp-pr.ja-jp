---
author: mcleanbyron
ms.assetid: 7a16b0ca-6b8e-4ade-9853-85690e06bda6
description: "C# を使ってスポット広告を起動する方法について説明します。"
title: "C# を使ったスポット広告のサンプル コード#"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, UWP, 広告, Advertising, スポット, C#, サンプルコード"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 4c57cf4909028d5aa81c75d9e1b6f1bf28d41ad7
ms.lasthandoff: 02/07/2017

---

# <a name="interstitial-ad-sample-code-in-c"></a>C# を使ったスポット広告のサンプル コード# #  

このトピックでは、スポット広告を表示する基本的な C# と XAML のユニバーサル Windows プラットフォーム (UWP) アプリの完全なサンプル コードを示します。 このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。 完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

## <a name="code-example"></a>コードの例

このセクションでは、スポット広告を表示する基本的なアプリの MainPage.xaml と MainPage.xaml.cs ファイルの内容を示します。 これらの例を使用するには、コードを Visual Studio 2015 の Visual C#** の空白のアプリ (ユニバーサル Windows)** プロジェクトにコピーします。

このサンプル アプリでは 2 つのボタンを使用して、スポット広告を要求して起動します。 ストアにアプリを提出する前に ```myAppId``` と ```myAdUnitId``` フィールドの値を Windows デベロッパー センターから取得した実際の値に置き換えます。 詳しくは、「[アプリで広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。

### <a name="mainpagexaml"></a>MainPage.xaml

> [!div class="tabbedCodeSnippets"]
[!code-xml[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml#L1-L13)]

### <a name="mainpagexamlcs"></a>MainPage.xaml.cs

> [!div class="tabbedCodeSnippets"]
[!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#CompleteSample)]

 
## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
 

