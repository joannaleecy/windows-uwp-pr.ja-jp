---
description: UWP アプリでバナー広告を使用する方法について説明します。
title: バナー広告
ms.date: 08/23/2017
ms.topic: article
keywords: Windows 10, UWP, 広告, AdControl, バナー広告
ms.localizationpriority: medium
ms.openlocfilehash: 5f8aea8f204127a0f783f9b751a9f4178667753e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627247"
---
# <a name="banner-ads"></a><span data-ttu-id="af359-104">バナー広告</span><span class="sxs-lookup"><span data-stu-id="af359-104">Banner ads</span></span>

<span data-ttu-id="af359-105">このセクションの記事では、Microsoft Advertising SDK の [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) クラスを使用して、UWP アプリにバナー広告を追加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="af359-105">The articles in this section show how to use the [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) class in the Microsoft Advertising SDK to add banner ads to your UWP app.</span></span>

<span data-ttu-id="af359-106">バナー広告は、アプリ内のページの四角形の部分を利用してプロモーション用のコンテンツを表示する静的な表示広告です。</span><span class="sxs-lookup"><span data-stu-id="af359-106">Banner ads are static display ads that utilize a rectangular portion of a page in your app to display promotional content.</span></span> <span data-ttu-id="af359-107">これらの広告は、一定間隔で自動的に更新できます。</span><span class="sxs-lookup"><span data-stu-id="af359-107">These ads can refresh automatically at regular intervals.</span></span> <span data-ttu-id="af359-108">これは、初めてアプリで広告を行う場合はここから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="af359-108">This is a good place to start if you are new to advertising in your app.</span></span>

![addreferences](images/banner-ad.png)

## <a name="in-this-section"></a><span data-ttu-id="af359-110">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="af359-110">In this section</span></span>

|  <span data-ttu-id="af359-111">トピック</span><span class="sxs-lookup"><span data-stu-id="af359-111">Topic</span></span>    | <span data-ttu-id="af359-112">説明</span><span class="sxs-lookup"><span data-stu-id="af359-112">Description</span></span> |               
|----------|-------|
| [<span data-ttu-id="af359-113">XAML と .NET で AdControl</span><span class="sxs-lookup"><span data-stu-id="af359-113">AdControl in XAML and .NET</span></span>](adcontrol-in-xaml-and--net.md)     | <span data-ttu-id="af359-114">XAML/.NET アプリにバナー広告を追加します。</span><span class="sxs-lookup"><span data-stu-id="af359-114">Add a banner ad in your XAML/.NET app.</span></span>        |
| [<span data-ttu-id="af359-115">HTML 5 で AdControl および Javascript</span><span class="sxs-lookup"><span data-stu-id="af359-115">AdControl in HTML 5 and Javascript</span></span>](adcontrol-in-html-5-and-javascript.md)     | <span data-ttu-id="af359-116">HTML5/JavaScript アプリにバナー広告を追加します。</span><span class="sxs-lookup"><span data-stu-id="af359-116">Add a banner ad in your HTML5/JavaScript app.</span></span>        |
| [<span data-ttu-id="af359-117">サポートされているバナー広告サイズ</span><span class="sxs-lookup"><span data-stu-id="af359-117">Supported banner ad sizes</span></span>](supported-ad-sizes-for-banner-ads.md)    |  <span data-ttu-id="af359-118">UWP アプリのバナー広告でサポートされているサイズを説明します。</span><span class="sxs-lookup"><span data-stu-id="af359-118">Review the supported sizes for banner ads in UWP apps.</span></span>        |


## <a name="related-topics"></a><span data-ttu-id="af359-119">関連トピック</span><span class="sxs-lookup"><span data-stu-id="af359-119">Related topics</span></span>

* [<span data-ttu-id="af359-120">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="af359-120">Advertising samples on GitHub</span></span>](https://aka.ms/githubads)
* [<span data-ttu-id="af359-121">アプリの ad 単位を設定します</span><span class="sxs-lookup"><span data-stu-id="af359-121">Set up ad units for your app</span></span>](set-up-ad-units-in-your-app.md)
