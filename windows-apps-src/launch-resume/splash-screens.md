---
title: スプラッシュ画面
description: このセクションでは、アプリのスプラッシュ画面を設定および構成する方法について説明します。
ms.assetid: 6b954bb3-e5b0-46d1-8afc-fb805536cf6d
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: df3fc8f54a4174006fd28f319d7cab09142a81fd
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8936337"
---
# <a name="splash-screens"></a><span data-ttu-id="ddabd-104">スプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="ddabd-104">Splash screens</span></span>

<span data-ttu-id="ddabd-105">すべての UWP アプリにはスプラッシュ画面が必要です。スプラッシュ画面は、画像と背景色を合成したもので、どちらもカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-105">All UWP apps must have a splash screen, which is a composite of an image and a background color, both of which can be customized.</span></span>

<span data-ttu-id="ddabd-106">スプラッシュ画面は、ユーザーがアプリを起動するとすぐに表示されます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-106">Your splash screen is displayed immediately when the user launches your app.</span></span> <span data-ttu-id="ddabd-107">これによって、アプリ リソースの初期化中であることがユーザーに示されます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-107">This provides immediate feedback to users while app resources are initialized.</span></span> <span data-ttu-id="ddabd-108">アプリが操作できる状態になると、スプラッシュ画面が閉じます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-108">As soon as your app is ready for interaction, the splash screen is dismissed.</span></span>

<span data-ttu-id="ddabd-109">スプラッシュ画面が適切にデザインされていると、アプリがより魅力的なものになります。</span><span class="sxs-lookup"><span data-stu-id="ddabd-109">A well-designed splash screen can make your app more inviting.</span></span> <span data-ttu-id="ddabd-110">装飾の少ないシンプルなスプラッシュ画面の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ddabd-110">Here's a simple, understated splash screen:</span></span>

![スプラッシュ画面のサンプルから取り込んだ 75% 縮小のスプラッシュ画面のスクリーン キャプチャ](images/regularsplashscreen.png)

<span data-ttu-id="ddabd-112">このスプラッシュ画面は、緑の背景色と透過的なバックグラウンド PNG 画像を組み合わせて作成されています。</span><span class="sxs-lookup"><span data-stu-id="ddabd-112">This splash screen is created by combining a green background color with a transparent-background PNG image.</span></span>

<span data-ttu-id="ddabd-113">背景色とシンプルな画像の組み合わせは、どのデバイスでアプリを実行する場合にも適切に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-113">A simple image with a background color looks good regardless of the device your app is running on.</span></span> <span data-ttu-id="ddabd-114">背景のサイズだけがさまざまな画面サイズに合わせて変更されます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-114">Only the size of the background changes to compensate for a variety of screen sizes.</span></span> <span data-ttu-id="ddabd-115">画像のサイズは常に変わりません。</span><span class="sxs-lookup"><span data-stu-id="ddabd-115">Your image always remains intact.</span></span>

<span data-ttu-id="ddabd-116">また、[**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) クラスを使うと、アプリの起動エクスペリエンスをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-116">Additionally, you can use the [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) class to customize your app's launch experience.</span></span> <span data-ttu-id="ddabd-117">アプリ UI の準備やネットワーク操作の完了などの追加のタスクをアプリが実行する時間を作るために、追加のスプラッシュ画面を作成して配置できます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-117">You can position an extended splash screen, which you create, to give your app more time to complete additional tasks like preparing app UI or completing networking operations.</span></span> <span data-ttu-id="ddabd-118">さらに、**SplashScreen** クラスを使うと、スプラッシュ画面が消えるときに通知を受け取って、導入アニメーションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-118">You can also use the **SplashScreen** class to notify you when the splash screen is dismissed, so that you can begin entrance animations.</span></span>

| <span data-ttu-id="ddabd-119">トピック</span><span class="sxs-lookup"><span data-stu-id="ddabd-119">Topic</span></span> | <span data-ttu-id="ddabd-120">説明</span><span class="sxs-lookup"><span data-stu-id="ddabd-120">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="ddabd-121">スプラッシュ画面の追加</span><span class="sxs-lookup"><span data-stu-id="ddabd-121">Add a splash screen</span></span>](add-a-splash-screen.md) | <span data-ttu-id="ddabd-122">アプリのスプラッシュ画面の画像と背景色を設定します。</span><span class="sxs-lookup"><span data-stu-id="ddabd-122">Set your app's splash screen image and background color.</span></span> |
| [<span data-ttu-id="ddabd-123">スプラッシュ画面の表示時間の延長</span><span class="sxs-lookup"><span data-stu-id="ddabd-123">Display a splash screen for more time</span></span>](create-a-customized-splash-screen.md) | <span data-ttu-id="ddabd-124">アプリに追加スプラッシュ画面を作成すれば、より長い時間、スプラッシュ画面を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-124">Display a splash screen for more time by creating an extended splash screen for your app.</span></span> <span data-ttu-id="ddabd-125">この追加画面は、アプリを起動したときに表示されるスプラッシュ画面に似ていますが、カスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="ddabd-125">This extended screen imitates the splash screen shown when your app is launched, and can be customized.</span></span> |