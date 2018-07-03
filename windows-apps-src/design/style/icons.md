---
author: mijacobs
Description: Good icons harmonize with typography and with the rest of the design language. They don’t mix metaphors, and they communicate only what’s needed, as speedily and simply as possible.
title: アイコン
ms.assetid: b90ac02d-5467-4304-99bd-292d6272a014
label: Icons
template: detail.hbs
ms.author: mijacobs
ms.date: 05/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
design-contact: Judysa
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 077967c37f76c8f1d0942f365344de65db13b041
ms.sourcegitcommit: ce45a2bc5ca6794e97d188166172f58590e2e434
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/06/2018
ms.locfileid: "1983575"
---
# <a name="icons-for-uwp-apps"></a><span data-ttu-id="3c5d7-103">UWP アプリのアイコン</span><span class="sxs-lookup"><span data-stu-id="3c5d7-103">Icons for UWP apps</span></span>

![アイコンのヘッダー画像](images/icons/header-icons.png)

<span data-ttu-id="3c5d7-105">アイコンは、アクション、概念、または製品の簡潔にした視覚表現を提供します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-105">Icons provide a visual shorthand for an action, concept, or product.</span></span> <span data-ttu-id="3c5d7-106">シンボリック イメージに意味を凝縮することによって、アイコンは言語の壁を乗り越えることができ、非常に価値のあるリソースである画面領域を節約するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-106">By compressing meaning into a symbolic image, icons can cross language barriers and help conserve an extremely valuable resource: screen space.</span></span> 

<span data-ttu-id="3c5d7-107">アイコンはアプリ内、およびアプリの外部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-107">Icons can appear in apps—and outside them:</span></span> 

<span data-ttu-id="3c5d7-108">:::row::: :::column::: **アプリ内のアイコン**</span><span class="sxs-lookup"><span data-stu-id="3c5d7-108">:::row::: :::column::: **Icons inside the app**</span></span>

        ![icons inside the app](images/icons/inside-icons.png)
        Inside your app, you use icons to represent an action, such as copying text or navigating to the settings page.
    :::column-end:::
    :::column:::
        **Icons outside the app**

        ![icons outside the app](images/icons/outside-icons.jpg)
         Outside your app, Windows uses an icon to represent your app in the start menu and in the taskbar. If the user chooses to pin your app to the start menu, your app's start tile can feature your app's icon. Your app's icon appears in the title bar and you can choose to create a splash screen with your app's logo.
    :::column-end:::
<span data-ttu-id="3c5d7-109">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-109">:::row-end:::</span></span>

<span data-ttu-id="3c5d7-110">この記事では、アプリ内のアイコンについて説明します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-110">This article describes icons within your app.</span></span> <span data-ttu-id="3c5d7-111">アプリの外部のアイコン (アプリ アイコン) の詳細については、「[アプリおよびタイル アイコンに関する記事](/windows/uwp/design/shell/tiles-and-notifications/app-assets)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-111">To learn about icons outside your app (app icons), see the [app and tile icons article](/windows/uwp/design/shell/tiles-and-notifications/app-assets).</span></span>

## <a name="when-to-use-icons"></a><span data-ttu-id="3c5d7-112">アイコンを使う状況</span><span class="sxs-lookup"><span data-stu-id="3c5d7-112">When to use icons</span></span>

<span data-ttu-id="3c5d7-113">アイコンは領域を節約できますが、アイコンをいつ使用する必要があるか説明します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-113">Icons can save space, but when should you use them?</span></span> 

<span data-ttu-id="3c5d7-114">:::row::: :::column::: ![適切](images/do.svg) ![標準イメージのアイコン</span><span class="sxs-lookup"><span data-stu-id="3c5d7-114">:::row::: :::column::: ![do](images/do.svg) ![icons standard image</span></span>](images/icons/icons-standard.svg)<br>

        Use an icon for actions, like cut, copy, paste, and save, or for navigation items in a navigation menu.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        ![icons concept image](images/icons/icons-concept.svg)<br>

        Use an icon if one already exists for the concept you want to represent. (To see whether an icon exists, check the Segoe icon list.)
    :::column-end:::
<span data-ttu-id="3c5d7-115">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-115">:::row-end:::</span></span>

<span data-ttu-id="3c5d7-116">:::row::: :::column::: ![適切](images/do.svg) ![ショッピング カート アイコン</span><span class="sxs-lookup"><span data-stu-id="3c5d7-116">:::row::: :::column::: ![do](images/do.svg) ![icon shopping cart</span></span>](images/icons/icon-shopping-cart.svg)<br>

        Use an icon if it's easy for the user to understand what the icon means and it's simple enough to be clear at small sizes.
    :::column-end:::
    :::column:::
        ![dont](images/dont.svg)
        ![icons concept image](images/icons/icon-bad-example.png)<br>

        Don't use an icon if its meaning isn't clear, or if making it clear requires a complex shape.
    :::column-end:::
<span data-ttu-id="3c5d7-117">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-117">:::row-end:::</span></span>



## <a name="using-the-right-type-of-icon"></a><span data-ttu-id="3c5d7-118">適切な種類のアイコンの使用</span><span class="sxs-lookup"><span data-stu-id="3c5d7-118">Using the right type of icon</span></span>

<span data-ttu-id="3c5d7-119">アイコンを作成する方法は数多くあります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-119">There are many ways to create an icon.</span></span> <span data-ttu-id="3c5d7-120">Segoe MDL2 アセットなどの記号フォントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-120">You can use a symbol font like Segoe MDL2 Assets.</span></span> <span data-ttu-id="3c5d7-121">独自のベクター ベースのイメージを作成できます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-121">You could create you own vector-based image.</span></span> <span data-ttu-id="3c5d7-122">ビットマップ画像も使用できますが、お勧めしません。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-122">You can even use a bitmap image, although we don't recommend it.</span></span> <span data-ttu-id="3c5d7-123">アプリにアイコンを追加するさまざまな方法の概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-123">Here's a summary of the different ways you can add an icon to your app.</span></span> 

### <a name="use-a-predefined-icon"></a><span data-ttu-id="3c5d7-124">定義済みのアイコンを使用します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-124">Use a predefined icon.</span></span>
<span data-ttu-id="3c5d7-125">:::row::: :::column::: マイクロソフトは、Segoe MDL2 アセット フォントの形式で 1000 以上のアイコンを提供します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-125">:::row::: :::column::: Microsoft provides over 1000 icons in the form of the Segoe MDL2 Assets font.</span></span> <span data-ttu-id="3c5d7-126">フォントからアイコンを取得するのは直感的ではない可能性がありますが、マイクロソフトのフォントの表示テクノロジでは、これらのアイコンが任意のディスプレイ、解像度、サイズではっきりと鮮明に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-126">It might not be intuitive to get an icon from a font, but our font display technology means these icons will look crisp and sharp on any display, at any resolution, and at any size.</span></span> <span data-ttu-id="3c5d7-127">:::column-end::: :::column::: ![事前定義されたアイコンの画像](images/icons/predefined-icon.png) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-127">:::column-end::: :::column::: ![pre-defined icon image](images/icons/predefined-icon.png) :::column-end::: :::row-end:::</span></span>

### <a name="use-a-font"></a><span data-ttu-id="3c5d7-128">フォントを使用します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-128">Use a font.</span></span>
<span data-ttu-id="3c5d7-129">:::row::: :::column::: Segoe MDL2 アセット フォントを使用する必要はありません。Wingdings や Webdings など、ユーザーがシステムにインストールしている任意のフォントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-129">:::row::: :::column::: You don't have to use the Segoe MDL2 Assets font--you can use any font the user has installed on their system, such as Wingdings or Webdings.</span></span>
<span data-ttu-id="3c5d7-130">:::column-end::: :::column::: ![Wingdings のイメージ](images/icons/wingdings.png) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-130">:::column-end::: :::column::: ![wingdings image](images/icons/wingdings.png) :::column-end::: :::row-end:::</span></span>

### <a name="use-a-scalable-vector-graphics-svg-file"></a><span data-ttu-id="3c5d7-131">スケーラブル ベクター グラフィックス (SVG) ファイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-131">Use a Scalable Vector Graphics (SVG) file.</span></span>
<span data-ttu-id="3c5d7-132">:::row::: :::column::: SVG リソースは、任意のサイズや解像度で常に鮮明に表示されるため、アイコンに最適です。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-132">:::row::: :::column::: SVG resources are ideal for icons, because they always look sharp at any size or resolution.</span></span> <span data-ttu-id="3c5d7-133">ほとんどの描画アプリケーションは、SVG にエクスポートできます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-133">Most drawing applications can export to SVG.</span></span> <span data-ttu-id="3c5d7-134">:::column-end::: :::column::: ![SVG イメージ](images/icons/icon-scale.gif) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-134">:::column-end::: :::column::: ![SVG image](images/icons/icon-scale.gif) :::column-end::: :::row-end:::</span></span>

### <a name="use-geometry-objects"></a><span data-ttu-id="3c5d7-135">ジオメトリ オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-135">Use Geometry objects.</span></span>
<span data-ttu-id="3c5d7-136">:::row::: :::column::: SVG ファイルのように、ジオメトリはベクター ベースのリソースであるため、常に鮮明に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-136">:::row::: :::column::: Like SVG files, geometries are a vector-based resource, so they always look sharp.</span></span> <span data-ttu-id="3c5d7-137">ただし、それぞれの点と曲線を個々に指定する必要があるため、ジオメトリの作成は複雑です。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-137">However, creating a geometry is complicated because you have to individually specify each point and curve.</span></span> <span data-ttu-id="3c5d7-138">実際にはアプリの実行中にアイコンを変更する必要がある場合のみ最適です (アプリをアニメーション化する場合など)。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-138">It's really only a good choice if you need to modify the icon while your app is running (to animate it, for example).</span></span> <span data-ttu-id="3c5d7-139">手順については、「[ジオメトリのコマンドの移動と描画](../../xaml-platform/move-draw-commands-syntax.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-139">For instructions, see [Move and draw commands for geometries](../../xaml-platform/move-draw-commands-syntax.md).</span></span> <span data-ttu-id="3c5d7-140">:::column-end::: :::column::: ![ジオメトリ オブジェクトのイメージ](images/icons/geometry-objects.png) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-140">:::column-end::: :::column::: ![Geometry objects image](images/icons/geometry-objects.png) :::column-end::: :::row-end:::</span></span>

### <a name="you-can-also-use-a-bitmap-image-such-as-png-gif-or-jpeg-although-we-dont-recommend-it"></a><span data-ttu-id="3c5d7-141">お勧めしませんが、PNG、GIF、JPEG などのビットマップ画像を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-141">You can also use a bitmap image, such as PNG, GIF, or JPEG, although we don't recommend it.</span></span>
<span data-ttu-id="3c5d7-142">:::row::: :::column::: ビットマップ画像は特定のサイズで作成されるため、希望するアイコンの大きさと画面の解像度に応じて拡大縮小する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-142">:::row::: :::column::: Bitmap images are created at a specific size, so they have to be scaled up or down depending on how large you want the icon to be and the resolution of the screen.</span></span> <span data-ttu-id="3c5d7-143">画像を縮小すると、ぼやけて見えることがあります。画像を拡大すると、むらのあるピクセル化された外観になることがあります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-143">When the image is scaled down (shrunk), it can appear blurry; when it's scaled up, it can appear blocky and pixelated.</span></span> <span data-ttu-id="3c5d7-144">ビットマップ画像を使用する必要がある場合は、JPEG ではなく PNG または GIF を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-144">If you have to use a bitmap image we recommend using a PNG or GIF over a JPEG.</span></span> <span data-ttu-id="3c5d7-145">:::column-end::: :::column::: ![不適切](images/dont.svg) ![ビットマップ画像](images/icons/bitmap-image.png) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-145">:::column-end::: :::column::: ![don't](images/dont.svg) ![Bitmap image](images/icons/bitmap-image.png) :::column-end::: :::row-end:::</span></span>

## <a name="make-the-icon-do-something"></a><span data-ttu-id="3c5d7-146">アイコンで何かを行う</span><span class="sxs-lookup"><span data-stu-id="3c5d7-146">Make the icon do something</span></span>

<span data-ttu-id="3c5d7-147">アイコンができたら、次の手順として、それをコマンドやナビゲーション操作に関連付けて、何かを行うようにすることです。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-147">Once you you have an icon, the next step is to make it do something by associating it with command or a navigation action.</span></span> <span data-ttu-id="3c5d7-148">これを行う最も良い方法は、アイコンをボタンやコマンド バーに追加することです。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-148">The best way to to do this is to add the icon to a button or a command bar.</span></span> 

![コマンド バーのイメージ](images/icons/app-bar-desktop.svg)

## <a name="create-an-icon-button"></a><span data-ttu-id="3c5d7-150">アイコン ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="3c5d7-150">Create an icon button</span></span>

<span data-ttu-id="3c5d7-151">アイコンは標準的なボタンに配置することができます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-151">You can put an icon in a standard button.</span></span> <span data-ttu-id="3c5d7-152">ボタンは幅広い場所で使用できるため、アクション アイコンが表示される場所に関して、柔軟性がやや高くなります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-152">Since you can use buttons in a wider variet of places, this gives you a little more flexibility for where your action icon appears.</span></span> 

<span data-ttu-id="3c5d7-153">ボタンにアイコンを追加する方法は次のようにいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-153">The are a few ways to add an icon to a button:</span></span>

<span data-ttu-id="3c5d7-154">:::row::: :::column span="2"::: <b>手順1</b></span><span class="sxs-lookup"><span data-stu-id="3c5d7-154">:::row::: :::column span="2"::: <b>Step 1</b></span></span><br>
        <span data-ttu-id="3c5d7-155">ボタンのフォント ファミリを `Segoe MDL2 Assets` に設定し、そのコンテンツ プロパティを使用するグリフの Unicode 値 に設定します。 :::column-end::: :::column::: ![アイコン ボタンの作成の手順 1](images/icons/create-icon-step-1.svg) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-155">Set the button's font family to `Segoe MDL2 Assets` and its content property to the unicode value of the glyph you want to use: :::column-end::: :::column::: ![Create an icon button step 1](images/icons/create-icon-step-1.svg) :::column-end::: :::row-end:::</span></span>

```xaml 
<Button FontFamily="Segoe MDL2 Assets" Content="&#xE102;" />
```

<span data-ttu-id="3c5d7-156">:::row::: :::column span="2"::: <b>手順 2</b></span><span class="sxs-lookup"><span data-stu-id="3c5d7-156">:::row::: :::column span="2"::: <b>Step 2</b></span></span><br>
        <span data-ttu-id="3c5d7-157">次のアイコンの要素オブジェクトのいずれかを使用します。[BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon)、[FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)、[PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon)、または [SymbolIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbolicon)。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-157">You can use one of the icon element objects: [BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon), [FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon), [PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon), or [SymbolIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbolicon).</span></span> <span data-ttu-id="3c5d7-158">これにより、選択するアイコンの種類が多くなり、必要に応じて、テキストなどのその他の種類のコンテンツとアイコンを組み合わせることができるようになります。 :::column-end::: :::column::: ![Create an icon button step 2](images/icons/icon-text-step-2.svg) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-158">This gives you more types of icons to choose from, and enables you to combine icons and other types of content, such as text, if you want: :::column-end::: :::column::: ![Create an icon button step 2](images/icons/icon-text-step-2.svg) :::column-end::: :::row-end:::</span></span>

```xaml 
<Button>
    <StackPanel>
        <SymbolIcon Symbol="Play" />
        <TextBlock>Play the movie</TextBlock>
    </StackPanel>
</Button>
```

## <a name="create-a-series-of-icons-in-a-command-bar"></a><span data-ttu-id="3c5d7-159">コマンド バーでの一連のアイコンの作成</span><span class="sxs-lookup"><span data-stu-id="3c5d7-159">Create a series of icons in a command bar</span></span>

<span data-ttu-id="3c5d7-160">:::row::: :::column span::: 切り取り/コピー/貼り付けや、写真編集プログラムの一連の描画コマンドなど、組み合わされる一連のコマンドがある場合は、それらを[コマンド バー](../controls-and-patterns/app-bars.md)にまとめます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-160">:::row::: :::column span::: When you have a series of commands that go together, such as cut/copy/paste or a set of drawing commands for a photo-editing program, put them together in a [command bar](../controls-and-patterns/app-bars.md).</span></span> <span data-ttu-id="3c5d7-161">コマンド バーは、1 つ以上のアプリ バーのボタンまたはアプリ バーのトグル ボタンを取得します。それぞれのボタンはアクションを表します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-161">A command bar takes one or more app bar buttons or app bar toggle buttons, each of which represents an action.</span></span> <span data-ttu-id="3c5d7-162">それぞれのボタンには、表示されるアイコンを制御するために使用する[アイコン](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.appbarbutton#Windows_UI_Xaml_Controls_AppBarButton_Icon) プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-162">Each button has an [Icon](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.appbarbutton#Windows_UI_Xaml_Controls_AppBarButton_Icon) property you use to control which icon it displays.</span></span> <span data-ttu-id="3c5d7-163">アイコンを指定するには、さまざまな方法があります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-163">There are a variety of ways to specify the icon.</span></span> <span data-ttu-id="3c5d7-164">:::column-end::: :::column::: ![アイコンを含むコマンド バーの例](images/icons/create-icon-command-bar.svg) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3c5d7-164">:::column-end::: :::column::: ![Example of a command bar with icons](images/icons/create-icon-command-bar.svg) :::column-end::: :::row-end:::</span></span>

<span data-ttu-id="3c5d7-165">最も簡単な方法は、指定した定義済みのアイコンの一覧を使用することです。"戻る" または "停止" などのアイコン名を指定するだけで、システムが描画します。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-165">The easiest way is to use the list of predefined icons we provide—simply specify the icon name, such as "Back" or "Stop", and the system will draw it:</span></span> 

``` xaml
<CommandBar>
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle" Click="AppBarButton_Click" />
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat" Click="AppBarButton_Click"/>
    <AppBarSeparator/>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Forward" Label="Forward" Click="AppBarButton_Click"/>
</CommandBar>

```
<span data-ttu-id="3c5d7-166">アイコン名の完全な一覧については、「[Symbol 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-166">For the complete list of icon names, see the [Symbol enumeration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol).</span></span> 

<span data-ttu-id="3c5d7-167">コマンド バーにあるボタンにアイコンを指定する方法は他にもあります。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-167">There are other ways to provide icons for a button in a command bar:</span></span>

+ <span data-ttu-id="3c5d7-168">[FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon) - アイコンは指定されたフォント ファミリのグリフに基づきます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-168">[FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon) - the icon is based on a glyph from the specified font family.</span></span>
+ <span data-ttu-id="3c5d7-169">[BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon) - アイコンは指定された **URI** を持つビットマップ画像ファイルに基づきます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-169">[BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon) - the icon is based on a bitmap image file with the specified **Uri**.</span></span>
+ <span data-ttu-id="3c5d7-170">[PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon) - アイコンは [Path](/uwp/api/windows.ui.xaml.shapes.path) データに基づきます。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-170">[PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon) - the icon is based on [Path](/uwp/api/windows.ui.xaml.shapes.path) data.</span></span>

<span data-ttu-id="3c5d7-171">コマンド バーの詳細については、「[コマンド バーの記事](../controls-and-patterns/app-bars.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3c5d7-171">To learn more about command bars, see the [command bar article](../controls-and-patterns/app-bars.md).</span></span> 



## <a name="related-articles"></a><span data-ttu-id="3c5d7-172">関連記事</span><span class="sxs-lookup"><span data-stu-id="3c5d7-172">Related articles</span></span>

* [<span data-ttu-id="3c5d7-173">タイルとアイコン アセットのガイドライン</span><span class="sxs-lookup"><span data-stu-id="3c5d7-173">Guidelines for tile and icon assets</span></span>](../shell/tiles-and-notifications/app-assets.md)
