---
ms.assetid: 7a16b0ca-6b8e-4ade-9853-85690e06bda6
description: C# を使ってスポット広告を起動する方法について説明します。
title: C# を使ったスポット広告のサンプル コード
ms.date: 03/22/2018
ms.topic: article
keywords: windows 10, UWP, 広告, Advertising, スポット, C#, サンプルコード
ms.localizationpriority: medium
ms.openlocfilehash: a8276e1a9639b23a965c5a608fb951d1e1035133
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8947890"
---
# <a name="interstitial-ad-sample-code-in-c"></a>C\# を使ったスポット広告のサンプル コード #  

このトピックでは、ビデオ スポット広告を表示する基本的な C# と XAML のユニバーサル Windows プラットフォーム (UWP) アプリの完全なサンプル コードを示します。 このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。 完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads) をご覧ください。

## <a name="code-example"></a>コードの例

このセクションでは、スポット広告を表示する基本的なアプリの MainPage.xaml と MainPage.xaml.cs ファイルの内容を示します。 これらの例を使用するには、コードを Visual Studio の Visual C#** の空白のアプリ (ユニバーサル Windows)** プロジェクトにコピーします。

このサンプル アプリではスポット広告を要求し起動させる 2 つのボタンを使用します。 値に置き換えます、```myAppId```と```myAdUnitId```フィールドをストアにアプリを提出する前にパートナー センターからの実際の値。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。

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
 
