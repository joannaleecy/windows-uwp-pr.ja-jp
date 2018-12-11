---
ms.assetid: 7a16b0ca-6b8e-4ade-9853-85690e06bda6
description: C# を使ってスポット広告を起動する方法について説明します。
title: C# を使ったスポット広告のサンプル コード
ms.date: 03/22/2018
ms.topic: article
keywords: windows 10, UWP, 広告, Advertising, スポット, C#, サンプルコード
ms.localizationpriority: medium
ms.openlocfilehash: a8276e1a9639b23a965c5a608fb951d1e1035133
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8897829"
---
# <a name="interstitial-ad-sample-code-in-c"></a><span data-ttu-id="b9e64-104">C\# を使ったスポット広告のサンプル コード</span><span class="sxs-lookup"><span data-stu-id="b9e64-104">Interstitial ad sample code in C\#</span></span> #  

<span data-ttu-id="b9e64-105">このトピックでは、ビデオ スポット広告を表示する基本的な C# と XAML のユニバーサル Windows プラットフォーム (UWP) アプリの完全なサンプル コードを示します。</span><span class="sxs-lookup"><span data-stu-id="b9e64-105">This topic provides the complete sample code for a basic C# and XAML Universal Windows Platform (UWP) app that shows an interstitial video ad.</span></span> <span data-ttu-id="b9e64-106">このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9e64-106">For step-by-step instructions that show how to configure your project to use this code, see [Interstitial ads](interstitial-ads.md).</span></span> <span data-ttu-id="b9e64-107">完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9e64-107">For a complete sample project, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

## <a name="code-example"></a><span data-ttu-id="b9e64-108">コードの例</span><span class="sxs-lookup"><span data-stu-id="b9e64-108">Code example</span></span>

<span data-ttu-id="b9e64-109">このセクションでは、スポット広告を表示する基本的なアプリの MainPage.xaml と MainPage.xaml.cs ファイルの内容を示します。</span><span class="sxs-lookup"><span data-stu-id="b9e64-109">This section shows the contents of the MainPage.xaml and MainPage.xaml.cs files in a basic app that shows an interstitial ad.</span></span> <span data-ttu-id="b9e64-110">これらの例を使用するには、コードを Visual Studio の Visual C#\*\* の空白のアプリ (ユニバーサル Windows)\*\* プロジェクトにコピーします。</span><span class="sxs-lookup"><span data-stu-id="b9e64-110">To use these examples, copy the code into a Visual C# **Blank App (Universal Windows)** project in Visual Studio.</span></span>

<span data-ttu-id="b9e64-111">このサンプル アプリではスポット広告を要求し起動させる 2 つのボタンを使用します。</span><span class="sxs-lookup"><span data-stu-id="b9e64-111">This sample app uses two buttons to request and then launch an interstitial ad.</span></span> <span data-ttu-id="b9e64-112">値に置き換えます、```myAppId```と```myAdUnitId```フィールドをストアにアプリを提出する前にパートナー センターからの実際の値。</span><span class="sxs-lookup"><span data-stu-id="b9e64-112">Replace the values of the ```myAppId``` and ```myAdUnitId``` fields with live values from Partner Center before submitting your app to the Store.</span></span> <span data-ttu-id="b9e64-113">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9e64-113">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

> [!NOTE]
> <span data-ttu-id="b9e64-114">ビデオ スポット広告ではなくバナー スポット広告を表示するようにこの例を変更するには、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドの最初のパラメーターとして、**AdType.Video** の代わりに値 **AdType.Display** を渡します。</span><span class="sxs-lookup"><span data-stu-id="b9e64-114">To alter this example to show an interstitial banner ad instead of an interstitial video ad, pass the value **AdType.Display** to the first parameter of the [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) method instead of **AdType.Video**.</span></span> <span data-ttu-id="b9e64-115">詳しくは、「[スポット広告](interstitial-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9e64-115">For more information, see [Interstitial ads](interstitial-ads.md).</span></span>

### <a name="mainpagexaml"></a><span data-ttu-id="b9e64-116">MainPage.xaml</span><span class="sxs-lookup"><span data-stu-id="b9e64-116">MainPage.xaml</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-xml[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml#L1-L13)]

### <a name="mainpagexamlcs"></a><span data-ttu-id="b9e64-117">MainPage.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="b9e64-117">MainPage.xaml.cs</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#CompleteSample)]

 
## <a name="related-topics"></a><span data-ttu-id="b9e64-118">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b9e64-118">Related topics</span></span>

* [<span data-ttu-id="b9e64-119">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="b9e64-119">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
 
