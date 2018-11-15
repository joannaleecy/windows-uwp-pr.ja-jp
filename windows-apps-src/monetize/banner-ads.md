---
author: Xansky
description: UWP アプリでバナー広告を使用する方法について説明します。
title: バナー広告
ms.author: mhopkins
ms.date: 08/23/2017
ms.topic: article
keywords: windows 10, uwp, 広告, 宣伝, AdControl, バナー広告
ms.localizationpriority: medium
ms.openlocfilehash: 4a8a08f81328be5dcf28a3f73a592e88e1edd135
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6661282"
---
# <a name="banner-ads"></a><span data-ttu-id="667ee-104">バナー広告</span><span class="sxs-lookup"><span data-stu-id="667ee-104">Banner ads</span></span>

<span data-ttu-id="667ee-105">このセクションの記事では、UWP アプリにバナー広告を追加する、Microsoft Advertising SDK で[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol)クラスを使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="667ee-105">The articles in this section show how to use the [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) class in the Microsoft Advertising SDK to add banner ads to your UWP app.</span></span>

<span data-ttu-id="667ee-106">バナー広告とは、プロモーション用のコンテンツを表示するアプリ内のページの四角形の部分を利用する静的な表示広告です。</span><span class="sxs-lookup"><span data-stu-id="667ee-106">Banner ads are static display ads that utilize a rectangular portion of a page in your app to display promotional content.</span></span> <span data-ttu-id="667ee-107">これらの広告は、一定間隔で自動的に更新できます。</span><span class="sxs-lookup"><span data-stu-id="667ee-107">These ads can refresh automatically at regular intervals.</span></span> <span data-ttu-id="667ee-108">これは、初めてアプリで広告を行う場合はここから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="667ee-108">This is a good place to start if you are new to advertising in your app.</span></span>

![addreferences](images/banner-ad.png)

## <a name="in-this-section"></a><span data-ttu-id="667ee-110">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="667ee-110">In this section</span></span>

|  <span data-ttu-id="667ee-111">トピック</span><span class="sxs-lookup"><span data-stu-id="667ee-111">Topic</span></span>    | <span data-ttu-id="667ee-112">説明</span><span class="sxs-lookup"><span data-stu-id="667ee-112">Description</span></span> |               
|----------|-------|
| [<span data-ttu-id="667ee-113">XAML および .NET の AdControl</span><span class="sxs-lookup"><span data-stu-id="667ee-113">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)     | <span data-ttu-id="667ee-114">XAML/.NET アプリにバナー広告を追加します。</span><span class="sxs-lookup"><span data-stu-id="667ee-114">Add a banner ad in your XAML/.NET app.</span></span>        |
| [<span data-ttu-id="667ee-115">HTML 5 および Javascript の AdControl</span><span class="sxs-lookup"><span data-stu-id="667ee-115">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)     | <span data-ttu-id="667ee-116">HTML5/JavaScript アプリにバナー広告を追加します。</span><span class="sxs-lookup"><span data-stu-id="667ee-116">Add a banner ad in your HTML5/JavaScript app.</span></span>        |
| [<span data-ttu-id="667ee-117">サポートされているバナー広告のサイズ</span><span class="sxs-lookup"><span data-stu-id="667ee-117">Supported banner ad sizes</span></span>](supported-ad-sizes-for-banner-ads.md)    |  <span data-ttu-id="667ee-118">UWP アプリでバナー広告でサポートされているサイズを確認します。</span><span class="sxs-lookup"><span data-stu-id="667ee-118">Review the supported sizes for banner ads in UWP apps.</span></span>        |


## <a name="related-topics"></a><span data-ttu-id="667ee-119">関連トピック</span><span class="sxs-lookup"><span data-stu-id="667ee-119">Related topics</span></span>

* [<span data-ttu-id="667ee-120">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="667ee-120">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
* [<span data-ttu-id="667ee-121">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="667ee-121">Set up ad units for your app</span></span>](set-up-ad-units-in-your-app.md)
