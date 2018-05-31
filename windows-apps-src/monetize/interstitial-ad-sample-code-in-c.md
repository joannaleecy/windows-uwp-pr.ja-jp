---
author: mcleanbyron
ms.assetid: 7a16b0ca-6b8e-4ade-9853-85690e06bda6
description: C# を使ってスポット広告を起動する方法について説明します。
title: C# を使ったスポット広告のサンプル コード
ms.author: mcleans
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP, 広告, Advertising, スポット, C#, サンプルコード
ms.localizationpriority: medium
ms.openlocfilehash: a92de70f09318b7509a9895aba6f23a152377c57
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1688928"
---
# <a name="interstitial-ad-sample-code-in-c"></a><span data-ttu-id="326af-104">C\# を使ったスポット広告のサンプル コード</span><span class="sxs-lookup"><span data-stu-id="326af-104">Interstitial ad sample code in C\#</span></span> #  

<span data-ttu-id="326af-105">このトピックでは、ビデオ スポット広告を表示する基本的な C# と XAML のユニバーサル Windows プラットフォーム (UWP) アプリの完全なサンプル コードを示します。</span><span class="sxs-lookup"><span data-stu-id="326af-105">This topic provides the complete sample code for a basic C# and XAML Universal Windows Platform (UWP) app that shows an interstitial video ad.</span></span> <span data-ttu-id="326af-106">このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="326af-106">For step-by-step instructions that show how to configure your project to use this code, see [Interstitial ads](interstitial-ads.md).</span></span> <span data-ttu-id="326af-107">完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="326af-107">For a complete sample project, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

## <a name="code-example"></a><span data-ttu-id="326af-108">コードの例</span><span class="sxs-lookup"><span data-stu-id="326af-108">Code example</span></span>

<span data-ttu-id="326af-109">このセクションでは、スポット広告を表示する基本的なアプリの MainPage.xaml と MainPage.xaml.cs ファイルの内容を示します。</span><span class="sxs-lookup"><span data-stu-id="326af-109">This section shows the contents of the MainPage.xaml and MainPage.xaml.cs files in a basic app that shows an interstitial ad.</span></span> <span data-ttu-id="326af-110">これらの例を使用するには、コードを Visual Studio の Visual C#** の空白のアプリ (ユニバーサル Windows)** プロジェクトにコピーします。</span><span class="sxs-lookup"><span data-stu-id="326af-110">To use these examples, copy the code into a Visual C# **Blank App (Universal Windows)** project in Visual Studio.</span></span>

<span data-ttu-id="326af-111">このサンプル アプリでは 2 つのボタンを使用して、スポット広告を要求して起動します。</span><span class="sxs-lookup"><span data-stu-id="326af-111">This sample app uses two buttons to request and then launch an interstitial ad.</span></span> <span data-ttu-id="326af-112">Microsoft Store にアプリを提出する前に、```myAppId``` フィールドと ```myAdUnitId``` フィールドの値を Windows デベロッパー センターから取得した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="326af-112">Replace the values of the ```myAppId``` and ```myAdUnitId``` fields with live values from Windows Dev Center before submitting your app to the Store.</span></span> <span data-ttu-id="326af-113">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="326af-113">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

> [!NOTE]
> <span data-ttu-id="326af-114">ビデオ スポット広告ではなくバナー スポット広告を表示するようにこの例を変更するには、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドの最初のパラメーターとして、**AdType.Video** の代わりに値 **AdType.Display** を渡します。</span><span class="sxs-lookup"><span data-stu-id="326af-114">To alter this example to show an interstitial banner ad instead of an interstitial video ad, pass the value **AdType.Display** to the first parameter of the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) method instead of **AdType.Video**.</span></span> <span data-ttu-id="326af-115">詳しくは、「[スポット広告](interstitial-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="326af-115">For more information, see [Interstitial ads](interstitial-ads.md).</span></span>

### <a name="mainpagexaml"></a><span data-ttu-id="326af-116">MainPage.xaml</span><span class="sxs-lookup"><span data-stu-id="326af-116">MainPage.xaml</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-xml[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml#L1-L13)]

### <a name="mainpagexamlcs"></a><span data-ttu-id="326af-117">MainPage.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="326af-117">MainPage.xaml.cs</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#CompleteSample)]

 
## <a name="related-topics"></a><span data-ttu-id="326af-118">関連トピック</span><span class="sxs-lookup"><span data-stu-id="326af-118">Related topics</span></span>

* [<span data-ttu-id="326af-119">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="326af-119">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
 
