---
author: mcleanbyron
ms.assetid: 48a1ef86-8514-4af8-9c93-81e869d36de7
description: "JavaScript を使ってプログラムで **AdControl** を作成する方法について説明します。"
title: "JavaScript での AdControl の作成"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、広告、AdControl、javascript"
ms.openlocfilehash: 5a64f58c7f66dd1177549562364a483641b1fd32
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="create-an-adcontrol-in-javascript"></a><span data-ttu-id="0e6bd-104">JavaScript での AdControl の作成</span><span class="sxs-lookup"><span data-stu-id="0e6bd-104">Create an AdControl in Javascript</span></span>

<span data-ttu-id="0e6bd-105">この記事の例では、JavaScript を使ってプログラムで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) を作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-105">The examples in this article shows how to programmatically create an [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) using JavaScript.</span></span> <span data-ttu-id="0e6bd-106">この記事では、**AdControl** を使用するために必要なプロジェクトへの参照が既に追加していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-106">This article assumes that you have already added the necessary references to your project to use an **AdControl**.</span></span> <span data-ttu-id="0e6bd-107">JavaScript ではなく HTML マークアップで **AdControl** を作成し初期化する方法の詳しいチュートリアルも含め、詳しくは「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-107">For more information, including a detailed walkthrough for creating and initializing an **AdControl** in HTML markup instead of JavaScript, see [AdControl in HTML 5 and Javascript](adcontrol-in-html-5-and-javascript.md).</span></span>

## <a name="html-div-for-an-adcontrol"></a><span data-ttu-id="0e6bd-108">AdControl 用の HTML の div</span><span class="sxs-lookup"><span data-stu-id="0e6bd-108">HTML div for an AdControl</span></span>

<span data-ttu-id="0e6bd-109">**AdControl** で広告を表示するには、対象の html ページに **div** を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-109">An **AdControl** needs to have a **div** on the html page that will show the ad.</span></span> <span data-ttu-id="0e6bd-110">この **div** のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-110">The code below provides an example of such a **div**.</span></span>

> [!div class="tabbedCodeSnippets"]
``` html
<div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
    data-win-control="MicrosoftNSJS.Advertising.AdControl">
</div>
```

## <a name="javascript-for-creating-an-adcontrol"></a><span data-ttu-id="0e6bd-111">AdControl を作成するための JavaScript</span><span class="sxs-lookup"><span data-stu-id="0e6bd-111">JavaScript for creating an AdControl</span></span>

<span data-ttu-id="0e6bd-112">次の例では、HTML に **div** が既にあることを前提にしています。ID は **myAd** です。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-112">The following example assumes that you are using an existing **div** in your HTML with the ID **myAd**.</span></span>

<span data-ttu-id="0e6bd-113">**AdControl** を **app.onactivated** 関数でインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-113">Instantiate the **AdControl** in the **app.onactivated** function.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-javascript[<span data-ttu-id="0e6bd-114">AdControl</span><span class="sxs-lookup"><span data-stu-id="0e6bd-114">AdControl</span></span>](./code/AdvertisingSamples/AdControlSamples/js/main.js#DeclareAdControl)]

<span data-ttu-id="0e6bd-115">この例では、**myAdError**、**myAdRefreshed**、および **myAdEngagedChanged** という名前のイベント ハンドラー メソッドを既に宣言していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-115">This example assumes that you have already declared event handler methods named **myAdError**, **myAdRefreshed**, and **myAdEngagedChanged**.</span></span>

> [!NOTE]
> <span data-ttu-id="0e6bd-116">この例の *applicationId* の値と *adUnitId* の値は、[テスト モードの値](test-mode-values.md)です。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-116">The *applicationId* and *adUnitId* values shown in this example are [test mode values](test-mode-values.md).</span></span> <span data-ttu-id="0e6bd-117">申請のためにアプリを提出する前に、Windows デベロッパー センターから[実際の値にこれらの値を置き換える](set-up-ad-units-in-your-app.md)必要があります。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-117">You must [replace these values with live values](set-up-ad-units-in-your-app.md) from Windows Dev Center before submitting your app for submission.</span></span>

<span data-ttu-id="0e6bd-118">このコードで広告が表示されない場合は、**AdControl** を含む **div** に **position:relative** の属性を挿入してみてください。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-118">If you use this code and do not see ads, you can try inserting an attribute of **position:relative** in the **div** that contains the **AdControl**.</span></span> <span data-ttu-id="0e6bd-119">これにより、**IFrame** の既定の設定が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-119">This will override the default setting of the **IFrame**.</span></span> <span data-ttu-id="0e6bd-120">この属性の値が原因でなければ、広告が正しく表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-120">Ads will be displayed correctly, unless they are not being shown due to the value of this attribute.</span></span> <span data-ttu-id="0e6bd-121">新しい広告ユニットが利用可能になるまでに最大で 30 分かかる場合があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0e6bd-121">Note that new ad units may not be available for up to 30 minutes.</span></span>

## <a name="related-topics"></a><span data-ttu-id="0e6bd-122">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0e6bd-122">Related topics</span></span>

* [<span data-ttu-id="0e6bd-123">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="0e6bd-123">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)

 

 
