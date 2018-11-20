---
author: TylerMSFT
title: スプラッシュ画面の追加
description: Microsoft Visual Studio を使ってアプリのスプラッシュ画面の画像と背景色を設定します。
ms.assetid: 41F53046-8AB7-4782-9E90-964D744B7D66
ms.author: twhitney
ms.date: 05/08/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 143b96171091406fb91954685143e4f86c036ffb
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7282068"
---
# <a name="add-a-splash-screen"></a><span data-ttu-id="d595d-104">スプラッシュ画面の追加</span><span class="sxs-lookup"><span data-stu-id="d595d-104">Add a splash screen</span></span>

<span data-ttu-id="d595d-105">Microsoft Visual Studio を使ってアプリのスプラッシュ画面の画像と背景色を設定します。</span><span class="sxs-lookup"><span data-stu-id="d595d-105">Set your app's splash screen image and background color using Microsoft Visual Studio.</span></span>

## <a name="set-the-splash-screen-image-and-background-color-in-visual-studio"></a><span data-ttu-id="d595d-106">Visual Studio でスプラッシュ画面の画像と背景色を設定する</span><span class="sxs-lookup"><span data-stu-id="d595d-106">Set the splash screen image and background color in Visual Studio</span></span>

<span data-ttu-id="d595d-107">Visual Studio テンプレートを使ってアプリを作成すると、既定の画像がプロジェクトに追加され、スプラッシュ画面の画像として設定されます。</span><span class="sxs-lookup"><span data-stu-id="d595d-107">When you use a Visual Studio template to create your app, a default image is added to your project and set as the splash screen image.</span></span> <span data-ttu-id="d595d-108">スプラッシュ画面の既定の背景色は既定で薄い灰色に設定されます。</span><span class="sxs-lookup"><span data-stu-id="d595d-108">The background color for your splash screen defaults to a light gray.</span></span> <span data-ttu-id="d595d-109">アプリのスプラッシュ画面の既定の画像や色を変更する場合は、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="d595d-109">If you want to change the default image or color of your app's splash screen, follow these steps:</span></span>

1. <span data-ttu-id="d595d-110">Visual Studio で既にあるユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="d595d-110">Open your existing Universal Windows Platform (UWP) app project in Visual Studio.</span></span>
2. <span data-ttu-id="d595d-111">**ソリューション エクスプ ローラー**から "Package.appxmanifest" ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="d595d-111">From **Solution Explorer**, open the "Package.appxmanifest" file.</span></span> <span data-ttu-id="d595d-112">メニュー バーから **[プロジェクト]** &gt; **[ストア]** &gt; **[アプリケーション マニフェストの編集]** を選んで、このファイルを開くこともできます。</span><span class="sxs-lookup"><span data-stu-id="d595d-112">You can also open this file from the menu bar by choosing **Project** &gt; **Store** &gt; **Edit App Manifest**.</span></span>
3. <span data-ttu-id="d595d-113">**[ビジュアル資産]** タブを開き、[Package.appxmanifest] ウィンドウの左側にある **[すべてのビジュアル資産]** ウィンドウから **[スプラッシュ画面]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="d595d-113">Open the **Visual Assets** tab and select **Splash Screen** from the **All Visual Assets** pane on the left side of the "Package.appxmanifest" window.</span></span> <span data-ttu-id="d595d-114">初めてスプラッシュ画面を変更する場合は、**[スプラッシュ画面]** に "Assets\\SplashScreen.png" というパスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d595d-114">If you're changing your splash screen for the first time, you'll see the "Assets\\SplashScreen.png" path in the **Splash Screen** field.</span></span>

    <span data-ttu-id="d595d-115">次のスクリーン ショットは、Visual Studio での [Package.appxmanifest] ウィンドウを示しています。</span><span class="sxs-lookup"><span data-stu-id="d595d-115">The following screen shot shows the "Package.appxmanifest" window in Visual Studio.</span></span> <span data-ttu-id="d595d-116">プロジェクトの種類に応じて、表示されるビジュアル資産が若干異なります。</span><span class="sxs-lookup"><span data-stu-id="d595d-116">Depending on the type of project, you will see a slightly different set of visual assets.</span></span>

    ![Visual Studio 2017 で表示される [package.appxmanifest] ウィンドウのスクリーン ショット](images/appmanifest.png)

    <span data-ttu-id="d595d-118">テキスト エディターで "Package.appxmanifest" を開くと、[**VisualElements 要素**](https://msdn.microsoft.com/library/windows/apps/br211471) の子として [**SplashScreen 要素**](https://msdn.microsoft.com/library/windows/apps/br211467) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d595d-118">If you open "Package.appxmanifest" in a text editor, the [**SplashScreen element**](https://msdn.microsoft.com/library/windows/apps/br211467) appears as a child of the [**VisualElements element**](https://msdn.microsoft.com/library/windows/apps/br211471).</span></span> <span data-ttu-id="d595d-119">マニフェスト ファイル内の既定のスプラッシュ画面のマークアップはテキスト エディターで次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d595d-119">The default splash screen markup in the manifest file looks like this in a text editor:</span></span>

    ```xml
    <uap:SplashScreen Image="Assets\SplashScreen.png" />
    ```

4. <span data-ttu-id="d595d-120">UWP アプリ用の新しいスプラッシュ画面の画像を選ぶには、**[スケーリングされた資産]** で **[1240 x 600 px]** ラベルの横にある省略記号のボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="d595d-120">To select a new splash screen image for a UWP app, press the button with an ellipsis that appears next to the **1240 x 600 px** label below **Scaled Assets**.</span></span> <span data-ttu-id="d595d-121">スプラッシュ画面の画像に使う 1240 × 600 ピクセルの画像 (.png、.jpg、または .jpeg) を選びます。</span><span class="sxs-lookup"><span data-stu-id="d595d-121">Choose the 1240 x 600 pixel image (.png, .jpg, or .jpeg) you'd like to use for your splash screen image.</span></span>

    <span data-ttu-id="d595d-122">**重要な**選択するスプラッシュ画面の画像はスケール ファクター x 1 を使った 620 x 300 ピクセルである必要があります。</span><span class="sxs-lookup"><span data-stu-id="d595d-122">**Important**The splash screen image you choose must be 620 x 300 pixels using a 1x scaling factor.</span></span> <span data-ttu-id="d595d-123">また、スプラッシュ画面を設計するときは、画面より小さく、中央に表示されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d595d-123">Also, when designing your splash screen, note that it is smaller than the screen, and centered.</span></span> <span data-ttu-id="d595d-124">Windows Phone ストア アプリのスプラッシュ画面のように画面全体に表示されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="d595d-124">It does not fill the screen like a splash screen for a Windows Phone Store app does.</span></span>

5. <span data-ttu-id="d595d-125">新しい Windows Phone ストア アプリ用スプラッシュ画面の画像を選ぶには、**[スケーリングされた資産]** で **[1152 x 1920 px]** ラベルの横にある省略記号のボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="d595d-125">To select a new splash screen image for a Windows Phone Store app, press the button with an ellipsis that appears next to the **1152 x 1920 px** label below **Scaled Assets**.</span></span> <span data-ttu-id="d595d-126">スプラッシュ画面の画像に使う 1152 × 1920 ピクセルの画像 (.png、.jpg、または .jpeg) を選びます。</span><span class="sxs-lookup"><span data-stu-id="d595d-126">Choose the 1152 x 1920 pixel image (.png, .jpg, or .jpeg) you'd like to use for your splash screen image.</span></span>

    <span data-ttu-id="d595d-127">**重要な**スプラッシュ画面の画像を選択する必要があります 1152 x 1920 ピクセルを 2.4 倍のスケール ファクターの適切なサイズです。</span><span class="sxs-lookup"><span data-stu-id="d595d-127">**Important**The splash screen image you choose must be 1152 x 1920 pixels which is the correct size for a 2.4x scaling factor.</span></span> <span data-ttu-id="d595d-128">提供する資産がこれだけである場合は、1.4 倍と等倍の倍率にスケール ダウンされます。</span><span class="sxs-lookup"><span data-stu-id="d595d-128">If this is the only asset you provide then it will be scaled down for 1.4x and 1x scaling factors.</span></span>

6. <span data-ttu-id="d595d-129">**[スプラッシュ画面]** セクションの **[背景色]** で、スプラッシュ画面の画像と共に表示される背景色を設定します。</span><span class="sxs-lookup"><span data-stu-id="d595d-129">In the **Background Color** field of the **Splash Screen** section, set the background color displayed with your splash screen image.</span></span> <span data-ttu-id="d595d-130">色の名前を指定することも、'\#' と色を表す 16 進数を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="d595d-130">You can enter either the name of a color or '\#' and the hex value of a color.</span></span> <span data-ttu-id="d595d-131">利用可能な色の名前の一覧については、「[**SplashScreen 要素**](https://msdn.microsoft.com/library/windows/apps/br211467)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d595d-131">For a list of the names of available colors, see [**SplashScreen element**](https://msdn.microsoft.com/library/windows/apps/br211467).</span></span> <span data-ttu-id="d595d-132">スプラッシュ画面の背景色の設定は省略できます。</span><span class="sxs-lookup"><span data-stu-id="d595d-132">Setting a background color for your splash screen is optional.</span></span> <span data-ttu-id="d595d-133">UWP アプリの色を指定しない場合は、スプラッシュ画面の背景色が既定で、薄い灰色 (16 進数 \#464646) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="d595d-133">If you don't specify a color for a UWP app, the splash screen background color defaults to a light gray (hex value \#464646).</span></span> <span data-ttu-id="d595d-134">これは、**[タイル]** の既定の背景色 (**[ビジュアル資産]** タブの **[タイル イメージとロゴ]** セクションの **[背景色]** を参照) と同じ色です。</span><span class="sxs-lookup"><span data-stu-id="d595d-134">This is the same color as the default **Tile** background color (see the **Background Color** field of the **Tile Images and Logos** section in the **Visual Assets** tab).</span></span> <span data-ttu-id="d595d-135">Windows Phone の色を指定しないか、「透明」に設定した場合は、スプラッシュ画面の背景色が透明になります。</span><span class="sxs-lookup"><span data-stu-id="d595d-135">If you don't specify a color for a Windows Phone, or set it to "transparent", then the splash screen background color will be transparent.</span></span>

## <a name="summary-and-next-steps"></a><span data-ttu-id="d595d-136">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="d595d-136">Summary and next steps</span></span>

<span data-ttu-id="d595d-137">アプリの読み込みに時間がかかる場合は、追加スプラッシュ画面の追加を検討してください。</span><span class="sxs-lookup"><span data-stu-id="d595d-137">If your app takes a while to load, consider adding an extended splash screen.</span></span> <span data-ttu-id="d595d-138">手順については、「[カスタマイズしたスプラッシュ画面の作成](create-a-customized-splash-screen.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d595d-138">For step-by-step guidance, see [Create a customized splash screen](create-a-customized-splash-screen.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="d595d-139">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d595d-139">Related topics</span></span>

* [<span data-ttu-id="d595d-140">カスタマイズしたスプラッシュ スクリーンの作成</span><span class="sxs-lookup"><span data-stu-id="d595d-140">Create a customized splash screen</span></span>](create-a-customized-splash-screen.md)
* [<span data-ttu-id="d595d-141">パッケージ マニフェスト スキーマ リファレンス: SplashScreen 要素</span><span class="sxs-lookup"><span data-stu-id="d595d-141">Package manifest schema reference: SplashScreen element</span></span>](https://msdn.microsoft.com/library/windows/apps/br211467)
* [<span data-ttu-id="d595d-142">Windows.ApplicationModel.Activation.SplashScreen クラス</span><span class="sxs-lookup"><span data-stu-id="d595d-142">Windows.ApplicationModel.Activation.SplashScreen class</span></span>](https://msdn.microsoft.com/library/windows/apps/br224763)