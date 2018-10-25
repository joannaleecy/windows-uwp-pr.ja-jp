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
ms.openlocfilehash: 57856872fc664670756c310410223acaf9708bc5
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483622"
---
# <a name="icons-for-uwp-apps"></a><span data-ttu-id="0d36a-103">UWP アプリのアイコン</span><span class="sxs-lookup"><span data-stu-id="0d36a-103">Icons for UWP apps</span></span>

![アイコンのヘッダー画像](images/icons/header-icons.png)

<span data-ttu-id="0d36a-105">アイコンは、アクション、概念、または製品の簡潔にした視覚表現を提供します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-105">Icons provide a visual shorthand for an action, concept, or product.</span></span> <span data-ttu-id="0d36a-106">シンボリック イメージに意味を凝縮することによって、アイコンは言語の壁を乗り越えることができ、非常に価値のあるリソースである画面領域を節約するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-106">By compressing meaning into a symbolic image, icons can cross language barriers and help conserve an extremely valuable resource: screen space.</span></span> 

<span data-ttu-id="0d36a-107">アイコンはアプリ内、およびアプリの外部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-107">Icons can appear in apps—and outside them:</span></span> 

:::row:::
    :::column:::
        **Icons inside the app**

        ![icons inside the app](images/icons/inside-icons.png)
        Inside your app, you use icons to represent an action, such as copying text or navigating to the settings page.
    :::column-end:::
    :::column:::
        **Icons outside the app**

        ![icons outside the app](images/icons/outside-icons.jpg)
         Outside your app, Windows uses an icon to represent your app in the start menu and in the taskbar. If the user chooses to pin your app to the start menu, your app's start tile can feature your app's icon. Your app's icon appears in the title bar and you can choose to create a splash screen with your app's logo.
    :::column-end:::
:::row-end:::

<span data-ttu-id="0d36a-108">この記事では、アプリ内のアイコンについて説明します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-108">This article describes icons within your app.</span></span> <span data-ttu-id="0d36a-109">アプリの外部のアイコン (アプリ アイコン) の詳細については、「[アプリおよびタイル アイコンに関する記事](/windows/uwp/design/shell/tiles-and-notifications/app-assets)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0d36a-109">To learn about icons outside your app (app icons), see the [app and tile icons article](/windows/uwp/design/shell/tiles-and-notifications/app-assets).</span></span>

## <a name="when-to-use-icons"></a><span data-ttu-id="0d36a-110">アイコンを使う状況</span><span class="sxs-lookup"><span data-stu-id="0d36a-110">When to use icons</span></span>

<span data-ttu-id="0d36a-111">アイコンは領域を節約できますが、アイコンをいつ使用する必要があるか説明します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-111">Icons can save space, but when should you use them?</span></span> 

:::row:::
    :::column:::
        ![do](images/do.svg)
        ![icons standard image](images/icons/icons-standard.svg)<br>

        Use an icon for actions, like cut, copy, paste, and save, or for navigation items in a navigation menu.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        ![icons concept image](images/icons/icons-concept.svg)<br>

        Use an icon if one already exists for the concept you want to represent. (To see whether an icon exists, check the Segoe icon list.)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![do](images/do.svg)
        ![icon shopping cart](images/icons/icon-shopping-cart.svg)<br>

        Use an icon if it's easy for the user to understand what the icon means and it's simple enough to be clear at small sizes.
    :::column-end:::
    :::column:::
        ![dont](images/dont.svg)
        ![icons concept image](images/icons/icon-bad-example.png)<br>

        Don't use an icon if its meaning isn't clear, or if making it clear requires a complex shape.
    :::column-end:::
:::row-end:::



## <a name="using-the-right-type-of-icon"></a><span data-ttu-id="0d36a-112">適切な種類のアイコンの使用</span><span class="sxs-lookup"><span data-stu-id="0d36a-112">Using the right type of icon</span></span>

<span data-ttu-id="0d36a-113">アイコンを作成する方法は数多くあります。</span><span class="sxs-lookup"><span data-stu-id="0d36a-113">There are many ways to create an icon.</span></span> <span data-ttu-id="0d36a-114">Segoe MDL2 アセットなどの記号フォントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-114">You can use a symbol font like Segoe MDL2 Assets.</span></span> <span data-ttu-id="0d36a-115">独自のベクター ベースのイメージを作成できます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-115">You could create you own vector-based image.</span></span> <span data-ttu-id="0d36a-116">ビットマップ画像も使用できますが、お勧めしません。</span><span class="sxs-lookup"><span data-stu-id="0d36a-116">You can even use a bitmap image, although we don't recommend it.</span></span> <span data-ttu-id="0d36a-117">アプリにアイコンを追加するさまざまな方法の概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-117">Here's a summary of the different ways you can add an icon to your app.</span></span> 

### <a name="use-a-predefined-icon"></a><span data-ttu-id="0d36a-118">定義済みのアイコンを使用します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-118">Use a predefined icon.</span></span>
:::row:::
    :::column:::
        Microsoft provides over 1000 icons in the form of the Segoe MDL2 Assets font. It might not be intuitive to get an icon from a font, but our font display technology means these icons will look crisp and sharp on any display, at any resolution, and at any size. 
    :::column-end:::
    :::column:::
        ![pre-defined icon image](images/icons/predefined-icon.png)
    :::column-end:::
:::row-end:::

### <a name="use-a-font"></a><span data-ttu-id="0d36a-119">フォントを使用します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-119">Use a font.</span></span>
:::row:::
    :::column:::
        You don't have to use the Segoe MDL2 Assets font--you can use any font the user has installed on their system, such as Wingdings or Webdings.
    :::column-end:::
    :::column:::
        ![wingdings image](images/icons/wingdings.png)
    :::column-end:::
:::row-end:::

### <a name="use-a-scalable-vector-graphics-svg-file"></a><span data-ttu-id="0d36a-120">スケーラブル ベクター グラフィックス (SVG) ファイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-120">Use a Scalable Vector Graphics (SVG) file.</span></span>
:::row:::
    :::column:::
        SVG resources are ideal for icons, because they always look sharp at any size or resolution. Most drawing applications can export to SVG. 
    :::column-end:::
    :::column:::
        ![SVG image](images/icons/icon-scale.gif)
    :::column-end:::
:::row-end:::

### <a name="use-geometry-objects"></a><span data-ttu-id="0d36a-121">ジオメトリ オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-121">Use Geometry objects.</span></span>
:::row:::
    :::column:::
        Like SVG files, geometries are a vector-based resource, so they always look sharp. However, creating a geometry is complicated because you have to individually specify each point and curve. It's really only a good choice if you need to modify the icon while your app is running (to animate it, for example). For instructions, see [Move and draw commands for geometries](../../xaml-platform/move-draw-commands-syntax.md). 
    :::column-end:::
    :::column:::
        ![Geometry objects image](images/icons/geometry-objects.png)
    :::column-end:::
:::row-end:::

### <a name="you-can-also-use-a-bitmap-image-such-as-png-gif-or-jpeg-although-we-dont-recommend-it"></a><span data-ttu-id="0d36a-122">お勧めしませんが、PNG、GIF、JPEG などのビットマップ画像を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-122">You can also use a bitmap image, such as PNG, GIF, or JPEG, although we don't recommend it.</span></span>
:::row:::
    :::column:::
        Bitmap images are created at a specific size, so they have to be scaled up or down depending on how large you want the icon to be and the resolution of the screen. When the image is scaled down (shrunk), it can appear blurry; when it's scaled up, it can appear blocky and pixelated. If you have to use a bitmap image we recommend using a PNG or GIF over a JPEG. 
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        ![Bitmap image](images/icons/bitmap-image.png)
    :::column-end:::
:::row-end:::

## <a name="make-the-icon-do-something"></a><span data-ttu-id="0d36a-123">アイコンで何かを行う</span><span class="sxs-lookup"><span data-stu-id="0d36a-123">Make the icon do something</span></span>

<span data-ttu-id="0d36a-124">アイコンができたら、次の手順として、それをコマンドやナビゲーション操作に関連付けて、何かを行うようにすることです。</span><span class="sxs-lookup"><span data-stu-id="0d36a-124">Once you you have an icon, the next step is to make it do something by associating it with command or a navigation action.</span></span> <span data-ttu-id="0d36a-125">これを行うには、最善の方法では、ボタンまたはコマンド バーにアイコンを追加します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-125">The best way to do this is to add the icon to a button or a command bar.</span></span> 

![コマンド バーのイメージ](images/icons/app-bar-desktop.svg)

## <a name="create-an-icon-button"></a><span data-ttu-id="0d36a-127">アイコン ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="0d36a-127">Create an icon button</span></span>

<span data-ttu-id="0d36a-128">アイコンは標準的なボタンに配置することができます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-128">You can put an icon in a standard button.</span></span> <span data-ttu-id="0d36a-129">ボタンは幅広い場所で使用できるため、アクション アイコンが表示される場所に関して、柔軟性がやや高くなります。</span><span class="sxs-lookup"><span data-stu-id="0d36a-129">Since you can use buttons in a wider variet of places, this gives you a little more flexibility for where your action icon appears.</span></span> 

<span data-ttu-id="0d36a-130">ボタンにアイコンを追加する方法は次のようにいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="0d36a-130">The are a few ways to add an icon to a button:</span></span>

:::row:::
    :::column span="2":::
        <b>Step 1</b><br>
        Set the button's font family to `Segoe MDL2 Assets` and its content property to the unicode value of the glyph you want to use:
    :::column-end:::
    :::column:::
        ![Create an icon button step 1](images/icons/create-icon-step-1.svg)
    :::column-end:::
:::row-end:::

```xaml 
<Button FontFamily="Segoe MDL2 Assets" Content="&#xE102;" />
```

:::row:::
    :::column span="2":::
        <b>Step 2</b><br>
        You can use one of the icon element objects: [BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon),
        [FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon), 
        [PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon), or
        [SymbolIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbolicon). This gives you more types of icons to choose from, and enables you to combine icons and other types of content, such as text, if you want:
    :::column-end:::
    :::column:::
        ![Create an icon button step 2](images/icons/icon-text-step-2.svg)
    :::column-end:::
:::row-end:::

```xaml 
<Button>
    <StackPanel>
        <SymbolIcon Symbol="Play" />
        <TextBlock>Play the movie</TextBlock>
    </StackPanel>
</Button>
```

## <a name="create-a-series-of-icons-in-a-command-bar"></a><span data-ttu-id="0d36a-131">コマンド バーでの一連のアイコンの作成</span><span class="sxs-lookup"><span data-stu-id="0d36a-131">Create a series of icons in a command bar</span></span>

:::row:::
    :::column span:::
        When you have a series of commands that go together, such as cut/copy/paste or a set of drawing commands for a photo-editing program, put them together in a [command bar](../controls-and-patterns/app-bars.md). A command bar takes one or more app bar buttons or app bar toggle buttons, each of which represents an action. Each button has an [Icon](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.appbarbutton#Windows_UI_Xaml_Controls_AppBarButton_Icon) property you use to control which icon it displays. There are a variety of ways to specify the icon. 
    :::column-end:::
    :::column:::
        ![Example of a command bar with icons](images/icons/create-icon-command-bar.svg)
    :::column-end:::
:::row-end:::

<span data-ttu-id="0d36a-132">最も簡単な方法は、指定した定義済みのアイコンの一覧を使用することです。"戻る" または "停止" などのアイコン名を指定するだけで、システムが描画します。</span><span class="sxs-lookup"><span data-stu-id="0d36a-132">The easiest way is to use the list of predefined icons we provide—simply specify the icon name, such as "Back" or "Stop", and the system will draw it:</span></span> 

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
<span data-ttu-id="0d36a-133">アイコン名の完全な一覧については、「[Symbol 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0d36a-133">For the complete list of icon names, see the [Symbol enumeration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol).</span></span> 

<span data-ttu-id="0d36a-134">コマンド バーにあるボタンにアイコンを指定する方法は他にもあります。</span><span class="sxs-lookup"><span data-stu-id="0d36a-134">There are other ways to provide icons for a button in a command bar:</span></span>

+ <span data-ttu-id="0d36a-135">[FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon) - アイコンは指定されたフォント ファミリのグリフに基づきます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-135">[FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon) - the icon is based on a glyph from the specified font family.</span></span>
+ <span data-ttu-id="0d36a-136">[BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon) - アイコンは指定された **URI** を持つビットマップ画像ファイルに基づきます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-136">[BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon) - the icon is based on a bitmap image file with the specified **Uri**.</span></span>
+ <span data-ttu-id="0d36a-137">[PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon) - アイコンは [Path](/uwp/api/windows.ui.xaml.shapes.path) データに基づきます。</span><span class="sxs-lookup"><span data-stu-id="0d36a-137">[PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon) - the icon is based on [Path](/uwp/api/windows.ui.xaml.shapes.path) data.</span></span>

<span data-ttu-id="0d36a-138">コマンド バーの詳細については、「[コマンド バーの記事](../controls-and-patterns/app-bars.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0d36a-138">To learn more about command bars, see the [command bar article](../controls-and-patterns/app-bars.md).</span></span> 



## <a name="related-articles"></a><span data-ttu-id="0d36a-139">関連記事</span><span class="sxs-lookup"><span data-stu-id="0d36a-139">Related articles</span></span>

* [<span data-ttu-id="0d36a-140">タイルとアイコン アセットのガイドライン</span><span class="sxs-lookup"><span data-stu-id="0d36a-140">Guidelines for tile and icon assets</span></span>](../shell/tiles-and-notifications/app-assets.md)
