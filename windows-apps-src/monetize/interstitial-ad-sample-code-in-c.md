---
author: Xansky
ms.assetid: 7a16b0ca-6b8e-4ade-9853-85690e06bda6
description: C# を使ってスポット広告を起動する方法について説明します。
title: C# を使ったスポット広告のサンプル コード
ms.author: mhopkins
ms.date: 03/22/2018
ms.topic: article
keywords: windows 10, UWP, 広告, Advertising, スポット, C#, サンプルコード
ms.localizationpriority: medium
ms.openlocfilehash: 94baaa490859baf57e0bd12bc5a3800ed3b2312a
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5759099"
---
# <a name="interstitial-ad-sample-code-in-c"></a>C\# を使ったスポット広告のサンプル コード #  

このトピックでは、ビデオ スポット広告を表示する基本的な C# と XAML のユニバーサル Windows プラットフォーム (UWP) アプリの完全なサンプル コードを示します。 このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。 完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads) をご覧ください。

## <a name="code-example"></a>コードの例

このセクションでは、スポット広告を表示する基本的なアプリの MainPage.xaml と MainPage.xaml.cs ファイルの内容を示します。 これらの例を使用するには、コードを Visual Studio の Visual C#** の空白のアプリ (ユニバーサル Windows)** プロジェクトにコピーします。

このサンプル アプリでは 2 つのボタンを使用して、スポット広告を要求して起動します。 ストアにアプリを提出する前に ```myAppId``` と ```myAdUnitId``` フィールドの値を Windows デベロッパー センターから取得した実際の値に置き換えます。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。

> [!NOTE]
> ビデオ スポット広告ではなくバナー スポット広告を表示するようにこの例を変更するには、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドの最初のパラメーターとして、**AdType.Video** の代わりに値 **AdType.Display** を渡します。 詳しくは、「[スポット広告](interstitial-ads.md)」をご覧ください。

### <a name="mainpagexaml"></a>MainPage.xaml

> [!div class="tabbedCodeSnippets"]
[!code-xml[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml#L1-L13)]

### <a name="mainpagexamlcs"></a>MainPage.xaml.cs

> [!div class="tabbedCodeSnippets"]
[!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#CompleteSample)]

 
## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
 
