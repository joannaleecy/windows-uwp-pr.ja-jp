---
Description: Build Universal Windows Platform (UWP) apps that support custom interactions from pen and stylus devices, including digital ink for natural writing and drawing experiences.
title: UWP アプリでのペン操作と Windows Ink
ms.assetid: 3DA4F2D2-5405-42A1-9ED9-3A87BCD84C43
label: Pen interactions and Windows Ink in UWP apps
template: detail.hbs
keywords: Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, 手書き認識, ユーザー操作, 入力
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 22477ab0facfcb67d44057a91c7c3a49df57f8b9
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8937992"
---
# <a name="pen-interactions-and-windows-ink-in-uwp-apps"></a><span data-ttu-id="08dd8-103">UWP アプリでのペン操作と Windows Ink</span><span class="sxs-lookup"><span data-stu-id="08dd8-103">Pen interactions and Windows Ink in UWP apps</span></span>

![Surface ペン](images/ink/hero-small.png)  
<span data-ttu-id="08dd8-105">*Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacepen)で購入できます)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-105">*Surface Pen* (available for purchase at the [Microsoft Store](https://aka.ms/purchasesurfacepen)).</span></span>

## <a name="overview"></a><span data-ttu-id="08dd8-106">概要</span><span class="sxs-lookup"><span data-stu-id="08dd8-106">Overview</span></span>

<span data-ttu-id="08dd8-107">ペン入力向けにユニバーサル Windows プラットフォーム (UWP) アプリを最適化して、標準の [**ポインター デバイス**](https://msdn.microsoft.com/library/windows/apps/br225633) 機能と最良の Windows Ink エクスペリエンスをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-107">Optimize your Universal Windows Platform (UWP) app for pen input to provide both standard [**pointer device**](https://msdn.microsoft.com/library/windows/apps/br225633) functionality and the best Windows Ink experience for your users.</span></span>

> [!NOTE]
> <span data-ttu-id="08dd8-108">ここでは主に、Windows Ink プラットフォームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-108">This topic focuses on the Windows Ink platform.</span></span> <span data-ttu-id="08dd8-109">ポインター入力処理 (マウス、タッチ、タッチパッドに類似) の概要については、「[ポインター入力の処理](handle-pointer-input.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08dd8-109">For general pointer input handling (similar to mouse, touch, and touchpad), see [Handle pointer input](handle-pointer-input.md).</span></span>

| <span data-ttu-id="08dd8-110">ビデオ</span><span class="sxs-lookup"><span data-stu-id="08dd8-110">Videos</span></span> |   |
| --- | --- |
| <iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-Ink-in-Your-UWP-App/player" width="300" height="200" allowFullScreen frameBorder="0"></iframe> | <iframe src="https://channel9.msdn.com/Events/Ignite/2016/BRK2060/player" width="300" height="200" allowFullScreen frameBorder="0"></iframe> |
| *<span data-ttu-id="08dd8-111">Using ink in your UWP app (UWP アプリでのインクの使用)</span><span class="sxs-lookup"><span data-stu-id="08dd8-111">Using ink in your UWP app</span></span>* | *<span data-ttu-id="08dd8-112">Windows ペンとインクを使用して、魅力的な enterpriseapps を構築するには</span><span class="sxs-lookup"><span data-stu-id="08dd8-112">Use Windows Pen and Ink to build more engaging enterpriseapps</span></span>* |

<span data-ttu-id="08dd8-113">Windows Ink プラットフォームでペン デバイスを使うと、自然な形でデジタルの手書きノート、描画、コメントを作れます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-113">The Windows Ink platform, together with a pen device, provides a natural way to create digital handwritten notes, drawings, and annotations.</span></span> <span data-ttu-id="08dd8-114">このプラットフォームは、デジタイザー入力のインク データとしてのキャプチャ、インク データの生成、インク データの管理、出力デバイスのインク ストロークとしてのインク データのレンダリング、手書き認識によるインクからテキストへの変換をサポートします。</span><span class="sxs-lookup"><span data-stu-id="08dd8-114">The platform supports capturing digitizer input as ink data, generating ink data, managing ink data, rendering ink data as ink strokes on the output device, and converting ink to text through handwriting recognition.</span></span>

<span data-ttu-id="08dd8-115">アプリでは、ユーザーが筆記や描画を行うときの基本的なペンの位置と動きのキャプチャに加えて、ストロークの筆圧の変化を追跡および収集することもできます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-115">In addition to capturing the basic position and movement of the pen as the user writes or draws, your app can also track and collect the varying amounts of pressure used throughout a stroke.</span></span> <span data-ttu-id="08dd8-116">この情報が、ペン先の形状、サイズ、回転や、インクの色、用途 (プレーン インク、消去、強調表示、選択) などの設定と組み合わされて、紙の上でペン、鉛筆、ブラシを使っているときに近いユーザー エクスペリエンスが実現されます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-116">This information, along with settings for pen tip shape, size, and rotation, ink color, and purpose (plain ink, erasing, highlighting, and selecting), enables you to provide user experiences that closely resemble writing or drawing on paper with a pen, pencil, or brush.</span></span>

> [!NOTE]
> <span data-ttu-id="08dd8-117">タッチ デジタイザーやマウス デバイスなど、他のポインター ベース デバイスからの手描き入力をアプリでサポートすることもできます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-117">Your app can also support ink input from other pointer-based devices, including touch digitizers and mouse devices.</span></span> 

<span data-ttu-id="08dd8-118">インク プラットフォームは非常に柔軟で、</span><span class="sxs-lookup"><span data-stu-id="08dd8-118">The ink platform is very flexible.</span></span> <span data-ttu-id="08dd8-119">必要に応じてさまざまなレベルの機能をサポートできるようになっています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-119">It is designed to support various levels of functionality, depending on your requirements.</span></span>

<span data-ttu-id="08dd8-120">Windows Ink UX のガイドラインについては、「[手描き入力コントロール](../controls-and-patterns/inking-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08dd8-120">For Windows Ink UX guidelines, see [Inking controls](../controls-and-patterns/inking-controls.md).</span></span>

## <a name="components-of-the-windows-ink-platform"></a><span data-ttu-id="08dd8-121">Windows Ink プラットフォームのコンポーネント</span><span class="sxs-lookup"><span data-stu-id="08dd8-121">Components of the Windows Ink platform</span></span>

| <span data-ttu-id="08dd8-122">コンポーネント</span><span class="sxs-lookup"><span data-stu-id="08dd8-122">Component</span></span> | <span data-ttu-id="08dd8-123">説明</span><span class="sxs-lookup"><span data-stu-id="08dd8-123">Description</span></span> |
| --- | --- |
| [**<span data-ttu-id="08dd8-124">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="08dd8-124">InkCanvas</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn858535) | <span data-ttu-id="08dd8-125">XAMLUI プラットフォーム コントロール、既定では、受信し、ペンからのすべての入力をインク ストロークか消去ストロークとして表示します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-125">A XAMLUI platform control that, by default, receives and displays all input from a pen as either an ink stroke or an erase stroke.</span></span><br/><span data-ttu-id="08dd8-126">InkCanvas の使用方法について詳しくは、「[Windows インク ストロークのテキスト認識](convert-ink-to-text.md)」と「[Windows Ink ストローク データの保存と取得](save-and-load-ink.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08dd8-126">For more information about how to use the InkCanvas, see [Recognize Windows Ink strokes as text](convert-ink-to-text.md) and [Store and retrieve Windows Ink stroke data](save-and-load-ink.md).</span></span> |
| [**<span data-ttu-id="08dd8-127">InkPresenter</span><span class="sxs-lookup"><span data-stu-id="08dd8-127">InkPresenter</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn922011) | <span data-ttu-id="08dd8-128">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールと共にインスタンス化される分離コード オブジェクトです ([**InkCanvas.InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) プロパティによって公開されます)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-128">A code-behind object, instantiated along with an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control (exposed through the [**InkCanvas.InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) property).</span></span> <span data-ttu-id="08dd8-129">**InkCanvas** によって公開される既定の手描き入力機能のすべてと、追加のカスタマイズや個人用設定のための包括的な API のセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-129">This object provides all default inking functionality exposed by the **InkCanvas**, along with a comprehensive set of APIs for additional customization and personalization.</span></span><br/><span data-ttu-id="08dd8-130">InkPresenter の使用方法について詳しくは、「[Windows Ink ストロークのテキスト認識](convert-ink-to-text.md)」と「[Windows Ink ストローク データの保存と取得](save-and-load-ink.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08dd8-130">For more information about how to use the InkPresenter, see [Recognize Windows Ink strokes as text](convert-ink-to-text.md) and [Store and retrieve Windows Ink stroke data](save-and-load-ink.md).</span></span> |
| [**<span data-ttu-id="08dd8-131">InkToolbar</span><span class="sxs-lookup"><span data-stu-id="08dd8-131">InkToolbar</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) | <span data-ttu-id="08dd8-132">カスタマイズと拡張、関連付けられた[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas)のインク関連機能をアクティブ化するボタンのコレクションが含まれている XAMLUI プラットフォーム コントロールです。</span><span class="sxs-lookup"><span data-stu-id="08dd8-132">A XAMLUI platform control containing a customizable and extensible collection of buttons that activate ink-related features in an associated [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas).</span></span><br/><span data-ttu-id="08dd8-133">InkToolbar の使用方法について詳しくは、「[InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手描き入力アプリに追加する](ink-toolbar.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08dd8-133">For more information about how to use the InkToolbar, see [Add an InkToolbar to a Universal Windows Platform (UWP) inking app](ink-toolbar.md).</span></span> |
| [**<span data-ttu-id="08dd8-134">IInkD2DRenderer</span><span class="sxs-lookup"><span data-stu-id="08dd8-134">IInkD2DRenderer</span></span>**](https://msdn.microsoft.com/library/mt147263) | <span data-ttu-id="08dd8-135">既定の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの代わりに、ユニバーサル Windows アプリが指定した Direct2D デバイス コンテキストにインク ストロークをレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-135">Enables the rendering of ink strokes onto the designated Direct2D device context of a Universal Windows app, instead of the default [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span> <span data-ttu-id="08dd8-136">これにより、手描き入力エクスペリエンスの全面的なカスタマイズが実現されます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-136">This enables full customization of the inking experience.</span></span><br/><span data-ttu-id="08dd8-137">詳しくは、「[複雑なインクのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620314)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08dd8-137">For more information, see the [Complex ink sample](https://go.microsoft.com/fwlink/p/?LinkID=620314).</span></span> |

## <a name="basic-inking-with-inkcanvas"></a><span data-ttu-id="08dd8-138">InkCanvas による基本的な手描き入力</span><span class="sxs-lookup"><span data-stu-id="08dd8-138">Basic inking with InkCanvas</span></span>

<span data-ttu-id="08dd8-139">基本的な手描き機能を追加するには、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) UWP プラットフォーム コントロールをアプリの適切なページに配置します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-139">To add basic inking functionality, just place an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) UWP platform control on the appropriate page in your app.</span></span>

<span data-ttu-id="08dd8-140">既定では、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) はペンからの手描き入力のみをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-140">By default, the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) supports ink input only from a pen.</span></span> <span data-ttu-id="08dd8-141">入力は、色と太さの既定の設定 (太さ 2 ピクセルの黒のボールペン) を使ってインク ストロークとしてレンダリングされるか、ストロークの消しゴムとして扱われます (ペンの消しゴムからの入力か、消しゴム ボタンで変更されたペン先からの入力の場合)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-141">The input is either rendered as an ink stroke using default settings for color and thickness (a black ballpoint pen with a thickness of 2 pixels), or treated as a stroke eraser (when input is from an eraser tip or the pen tip modified with an erase button).</span></span>

> [!NOTE]
> <span data-ttu-id="08dd8-142">ペンの消しゴムまたは消しゴム ボタンがない場合は、ペン先からの入力を消去ストロークとして処理するように InkCanvas を構成できます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-142">If an eraser tip or button is not present, the InkCanvas can be configured to process input from the pen tip as an erase stroke.</span></span>

<span data-ttu-id="08dd8-143">次の例では、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) を背景画像にオーバーレイしています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-143">In this example, an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) overlays a background image.</span></span>

> [!NOTE]
> <span data-ttu-id="08dd8-144">InkCanvas の[**高さ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Height)と[**幅**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Width)のプロパティは、子要素のサイズを自動的に設定する要素の子である場合を除き、既定では 0 です。</span><span class="sxs-lookup"><span data-stu-id="08dd8-144">An InkCanvas has default [**Height**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Height) and [**Width**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Width) properties of zero, unless it is the child of an element that automatically sizes its child elements.</span></span> 

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink sample"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />            
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

<span data-ttu-id="08dd8-145">次の一連の画像は、この [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールによってペン入力がどのようにレンダリングされるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-145">This series of images shows how pen input is rendered by this [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

| ![空の InkCanvas と背景画像](images/ink_basic_1_small.png) | ![インク ストロークを含む InkCanvas](images/ink_basic_2_small.png) | ![1 つのストロークが消去された InkCanvas](images/ink_basic_3_small.png) |
| --- | --- | ---|
| <span data-ttu-id="08dd8-149">空の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) と背景画像。</span><span class="sxs-lookup"><span data-stu-id="08dd8-149">The blank [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) with a background image.</span></span> | <span data-ttu-id="08dd8-150">インク ストロークを含む [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-150">The [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) with ink strokes.</span></span> | <span data-ttu-id="08dd8-151">ストロークの一部が削除された [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)  (削除が部分ではなく全体にどのように影響するかに注意してください)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-151">The [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) with one stroke erased (note how erase operates on an entire stroke, not a portion).</span></span> |

<span data-ttu-id="08dd8-152">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールでサポートされている手書き入力機能は、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) という分離コード オブジェクトによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-152">The inking functionality supported by the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control is provided by a code-behind object called the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).</span></span>

<span data-ttu-id="08dd8-153">基本的な手書き入力では [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) のことを気にする必要はありませんが、</span><span class="sxs-lookup"><span data-stu-id="08dd8-153">For basic inking, you don't have to concern yourself with the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).</span></span> <span data-ttu-id="08dd8-154">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) の手書き入力動作をカスタマイズしたり構成したりするには、対応する **InkPresenter** オブジェクトにアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-154">However, to customize and configure inking behavior on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), you must access its corresponding **InkPresenter** object.</span></span>

## <a name="basic-customization-with-inkpresenter"></a><span data-ttu-id="08dd8-155">InkPresenter による基本的なカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="08dd8-155">Basic customization with InkPresenter</span></span>

<span data-ttu-id="08dd8-156">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) オブジェクトは、各 [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールと共にインスタンス化されます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-156">An [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) object is instantiated with each [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

> [!NOTE]
> <span data-ttu-id="08dd8-157">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) を直接インスタンス化することはできません。</span><span class="sxs-lookup"><span data-stu-id="08dd8-157">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) cannot be instantiated directly.</span></span> <span data-ttu-id="08dd8-158">代わりに、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) の [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) プロパティを通じてアクセスします。</span><span class="sxs-lookup"><span data-stu-id="08dd8-158">Instead, it is accessed through the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) property of the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span> 

<span data-ttu-id="08dd8-159">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) には、対応する [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの既定の手書き入力動作のすべてに加えて、ストロークの追加のカスタマイズのための包括的な API のセット、および手描き入力 (標準および変更) の細かい管理を提供します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-159">Along with providing all default inking behaviors of its corresponding [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control, the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) provides a comprehensive set of APIs for additional stroke customization and finer-grained management of the pen input (standard and modified).</span></span> <span data-ttu-id="08dd8-160">たとえば、ストロークのプロパティ、サポートされている入力デバイスの種類、入力をオブジェクトで処理するかアプリに渡して処理するかなどを指定できます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-160">This includes stroke properties, supported input device types, and whether input is processed by the object or passed to the app for processing.</span></span>

> [!NOTE]
> <span data-ttu-id="08dd8-161">標準のインク入力 (ペン先または消しゴムの先端やボタン) は、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタン、または類似のメカニズムなど) で変更されません。</span><span class="sxs-lookup"><span data-stu-id="08dd8-161">Standard ink input (from either pen tip or eraser tip/button) is not modified with a secondary hardware affordance, such as a pen barrel button, right mouse button, or similar mechanism.</span></span> 

<span data-ttu-id="08dd8-162">既定では、インクはペン入力のみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="08dd8-162">By default, ink is supported for pen input only.</span></span> <span data-ttu-id="08dd8-163">次の例では、ペンとマウスの両方の入力データをインク ストロークとして解釈するように [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) を構成しています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-163">Here, we configure the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) to interpret input data from both pen and mouse as ink strokes.</span></span> <span data-ttu-id="08dd8-164">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) へのストロークのレンダリングに使うインク ストロークの最初の属性も設定しています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-164">We also set some initial ink stroke attributes used for rendering strokes to the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>

<span data-ttu-id="08dd8-165">マウスとタッチによる手描き入力を有効化するには、[**InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter) の [**InputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter.InputDeviceTypes) プロパティを、必要な [**CoreInputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.core.coreinputdevicetypes) 値の組み合わせに設定します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-165">To enable mouse and touch inking, set the [**InputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter.InputDeviceTypes) property of the [**InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter) to the combination of [**CoreInputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.core.coreinputdevicetypes) values that you want.</span></span>

```csharp
public MainPage()
{
    this.InitializeComponent();

    // Set supported inking device types.
    inkCanvas.InkPresenter.InputDeviceTypes =
        Windows.UI.Core.CoreInputDeviceTypes.Mouse |
        Windows.UI.Core.CoreInputDeviceTypes.Pen;

    // Set initial ink stroke attributes.
    InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
    drawingAttributes.Color = Windows.UI.Colors.Black;
    drawingAttributes.IgnorePressure = false;
    drawingAttributes.FitToCurve = true;
    inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
}
```

<span data-ttu-id="08dd8-166">インク ストロークの属性は、ユーザー設定やアプリの要件に合わせて動的に設定できます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-166">Ink stroke attributes can be set dynamically to accommodate user preferences or app requirements.</span></span>

<span data-ttu-id="08dd8-167">次の例では、ユーザーがインクの色を一覧から選べるようにしています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-167">Here, we let a user choose from a list of ink colors.</span></span>

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink customization sample"
                   VerticalAlignment="Center"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />
        <TextBlock Text="Color:"
                   Style="{StaticResource SubheaderTextBlockStyle}"
                   VerticalAlignment="Center"
                   Margin="50,0,10,0"/>
        <ComboBox x:Name="PenColor"
                  VerticalAlignment="Center"
                  SelectedIndex="0"
                  SelectionChanged="OnPenColorChanged">
            <ComboBoxItem Content="Black"/>
            <ComboBoxItem Content="Red"/>
        </ComboBox>
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

<span data-ttu-id="08dd8-168">ユーザーが色を選択したら、その変更を処理して、それに合わせてインク ストロークの属性を更新します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-168">We then handle changes to the selected color and update the ink stroke attributes accordingly.</span></span>

```csharp
// Update ink stroke color for new strokes.
private void OnPenColorChanged(object sender, SelectionChangedEventArgs e)
{
    if (inkCanvas != null)
    {
        InkDrawingAttributes drawingAttributes =
            inkCanvas.InkPresenter.CopyDefaultDrawingAttributes();

        string value = ((ComboBoxItem)PenColor.SelectedItem).Content.ToString();

        switch (value)
        {
            case "Black":
                drawingAttributes.Color = Windows.UI.Colors.Black;
                break;
            case "Red":
                drawingAttributes.Color = Windows.UI.Colors.Red;
                break;
            default:
                drawingAttributes.Color = Windows.UI.Colors.Black;
                break;
        };

        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
    }
}
```

<span data-ttu-id="08dd8-169">次の画像は、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によるペン入力の処理とカスタマイズがどのように行われるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-169">These images shows how pen input is processed and customized by the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081).</span></span>

| ![既定の黒のインク ストロークを含む InkCanvas](images/ink-basic-custom-1-small.png) | ![ユーザーが選択した赤のインク ストロークを含む InkCanvas](images/ink-basic-custom-2-small.png) |
| --- | --- |
| <span data-ttu-id="08dd8-172">既定の黒のインク ストロークを含む [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-172">The [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) with default black ink strokes.</span></span> | <span data-ttu-id="08dd8-173">ユーザーが選択した赤のインク ストロークを含む [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-173">The [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) with user selected red ink strokes.</span></span> | 

<span data-ttu-id="08dd8-174">手書き入力と消去以外の機能 (ストロークの選択など) を提供するには、アプリで処理するために [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) では未処理のままパススルーする入力をアプリで識別する必要があります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-174">To provide functionality beyond inking and erasing, such as stroke selection, your app must identify specific input for the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) to pass through unprocessed for handling by your app.</span></span>

## <a name="pass-through-input-for-advanced-processing"></a><span data-ttu-id="08dd8-175">高度な処理のための入力のパススルー</span><span class="sxs-lookup"><span data-stu-id="08dd8-175">Pass-through input for advanced processing</span></span>

<span data-ttu-id="08dd8-176">既定では、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によって、すべての入力がインク ストロークまたは消去ストロークとして処理されます。こうした入力には、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタンなど) によって変更された入力も含まれます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-176">By default, [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) processes all input as either an ink stroke or an erase stroke, including input modified by a secondary hardware affordance such as a pen barrel button, a right mouse button, or similar.</span></span> <span data-ttu-id="08dd8-177">ただし、ユーザーは通常、これらのセカンダリ アフォーダンスを使うときに、追加機能や動作の変更を期待します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-177">However, users typically expect some additional functionality or modified behavior with these secondary affordances.</span></span>

<span data-ttu-id="08dd8-178">場合によっては、アプリの UI でユーザーが選択した内容に基づいて、セカンダリ アフォーダンス (通常はペン先に関連付けられていない機能) を持たないペンのための追加機能、その他の入力デバイスの種類、または変更された動作を公開することも必要になります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-178">In some cases, you might also need to expose additional functionality for pens without secondary affordances (functionality not usually associated with the pen tip), other input device types, or some type of modified behavior based on a user selection in your app's UI.</span></span>

<span data-ttu-id="08dd8-179">そのような場合のために、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、特定の入力を処理しないように構成することができます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-179">To support this, [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) can be configured to leave specific input unprocessed.</span></span> <span data-ttu-id="08dd8-180">この未処理の入力は、アプリにパススルーされて処理されます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-180">This unprocessed input is then passed through to your app for processing.</span></span>

### <a name="example---use-unprocessed-input-to-implement-stroke-selection"></a><span data-ttu-id="08dd8-181">例 - 未処理の入力を使って、ストロークの選択を実装する</span><span class="sxs-lookup"><span data-stu-id="08dd8-181">Example - Use unprocessed input to implement stroke selection</span></span> 

<span data-ttu-id="08dd8-182">Windows Ink プラットフォームには、変更された入力を必要とする操作のためのサポート (ストロークの選択など) が組み込まれていません。</span><span class="sxs-lookup"><span data-stu-id="08dd8-182">The Windows Ink platform does not provide built-in support for actions that require modified input, such as stroke selection.</span></span> <span data-ttu-id="08dd8-183">このような機能をサポートするには、アプリでカスタム ソリューションを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-183">To support features like this, you must provide a custom solution in your apps.</span></span> 

<span data-ttu-id="08dd8-184">次のコード例は、ペン バレル ボタン (またはマウスの右ボタン) で入力が変更された場合にストロークを選択できるようにする手順を示しています (すべてのコードは MainPage.xaml ファイルと MainPage.xaml.cs ファイルに含まれています)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-184">The following code example (all code is in the MainPage.xaml and MainPage.xaml.cs files) steps through how to enable stroke selection when input is modified with a pen barrel button (or right mouse button).</span></span>

1.  <span data-ttu-id="08dd8-185">まず、MainPage.xaml で UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-185">First, we set up the UI in MainPage.xaml.</span></span>

    <span data-ttu-id="08dd8-186">ここでは、選択ストロークを描画するためのキャンバスを ([**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) の下に) 追加しています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-186">Here, we add a canvas (below the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)) to draw the selection stroke.</span></span> <span data-ttu-id="08dd8-187">別のレイヤーを使って選択ストロークを描画すると、**InkCanvas** とそのコンテンツに影響を与えずに済みます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-187">Using a separate layer to draw the selection stroke leaves the **InkCanvas** and its content untouched.</span></span>

    ![下に選択キャンバスがある空の InkCanvas](images/ink-unprocessed-1-small.png)

      ```xaml
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
          <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
          </Grid.RowDefinitions>
          <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="Header"
              Text="Advanced ink customization sample"
              VerticalAlignment="Center"
              Style="{ThemeResource HeaderTextBlockStyle}"
              Margin="10,0,0,0" />
          </StackPanel>
          <Grid Grid.Row="1">
            <!-- Canvas for displaying selection UI. -->
            <Canvas x:Name="selectionCanvas"/>
            <!-- Inking area -->
            <InkCanvas x:Name="inkCanvas"/>
          </Grid>
        </Grid>
      ```

2.  <span data-ttu-id="08dd8-189">MainPage.xaml.cs で、選択 UI のいくつかの要素への参照を保持するグローバル変数を宣言します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-189">In MainPage.xaml.cs, we declare a couple of global variables for keeping references to aspects of the selection UI.</span></span> <span data-ttu-id="08dd8-190">具体的には、なげなわ選択ストロークと、選択されたストロークを強調表示する境界の四角形への参照を保持します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-190">Specifically, the selection lasso stroke and the bounding rectangle that highlights the selected strokes.</span></span>

      ```csharp
        // Stroke selection tool.
        private Polyline lasso;
        // Stroke selection area.
        private Rect boundingRect;
      ```

3.  <span data-ttu-id="08dd8-191">次に、ペンとマウスの両方の入力データをインク ストロークとして解釈するように [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) を構成し、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) へのストロークのレンダリングに使うインク ストロークの最初の属性をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-191">Next, we configure the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) to interpret input data from both pen and mouse as ink strokes, and set some initial ink stroke attributes used for rendering strokes to the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535).</span></span>

    <span data-ttu-id="08dd8-192">ここで最も重要なのは、[InkPresenter](https://msdn.microsoft.com/library/windows/apps/dn899081) の [**InputProcessingConfiguration**](https://msdn.microsoft.com/library/windows/apps/dn948764) プロパティを使って、変更された入力がアプリで処理されるように指定することです。</span><span class="sxs-lookup"><span data-stu-id="08dd8-192">Most importantly, we use the [**InputProcessingConfiguration**](https://msdn.microsoft.com/library/windows/apps/dn948764) property of the [InkPresenter](https://msdn.microsoft.com/library/windows/apps/dn899081) to indicate that any modified input should be processed by the app.</span></span> <span data-ttu-id="08dd8-193">**InputProcessingConfiguration.RightDragAction** に [**InkInputRightDragAction.LeaveUnprocessed**](https://msdn.microsoft.com/library/windows/apps/dn948760) という値を割り当てて、変更された入力を指定します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-193">Modified input is specified by assigning **InputProcessingConfiguration.RightDragAction** a value of [**InkInputRightDragAction.LeaveUnprocessed**](https://msdn.microsoft.com/library/windows/apps/dn948760).</span></span> <span data-ttu-id="08dd8-194">この値が設定されると、[InkPresenter](https://msdn.microsoft.com/library/windows/apps/dn899081) によって [InkUnprocessedInput](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkunprocessedinput) クラス (ユーザーが処理できるポインター イベントのセット) にパススルーされます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-194">When this value is set, the [InkPresenter](https://msdn.microsoft.com/library/windows/apps/dn899081) passes through to the [InkUnprocessedInput](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkunprocessedinput) class, a set of pointer events for you to handle.</span></span>

    <span data-ttu-id="08dd8-195">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってパススルーされる [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/dn914712)、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/dn914711)、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/dn914713) の各未処理イベントのリスナーが割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-195">We assign listeners for the unprocessed [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/dn914712), [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/dn914711), and [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/dn914713) events passed through by the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081).</span></span> <span data-ttu-id="08dd8-196">選択機能はすべてこれらのイベントのハンドラーに実装します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-196">All selection functionality is implemented in the handlers for these events.</span></span>

    <span data-ttu-id="08dd8-197">最後に、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) の [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702) イベントと [**StrokesErased**](https://msdn.microsoft.com/library/windows/apps/dn948767) イベントのリスナーを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-197">Finally, we assign listeners for the [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702) and [**StrokesErased**](https://msdn.microsoft.com/library/windows/apps/dn948767) events of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081).</span></span> <span data-ttu-id="08dd8-198">これらのイベントのハンドラーを使って、新しいストロークが開始された場合や既にあるストロークが消去された場合に選択 UI をクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="08dd8-198">We use the handlers for these events to clean up the selection UI if a new stroke is started or an existing stroke is erased.</span></span>

    ![既定の黒のインク ストロークを含む InkCanvas](images/ink-unprocessed-2-small.png)

      ```csharp
        public MainPage()
        {
          this.InitializeComponent();

          // Set supported inking device types.
          inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

          // Set initial ink stroke attributes.
          InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
          drawingAttributes.Color = Windows.UI.Colors.Black;
          drawingAttributes.IgnorePressure = false;
          drawingAttributes.FitToCurve = true;
          inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

          // By default, the InkPresenter processes input modified by
          // a secondary affordance (pen barrel button, right mouse
          // button, or similar) as ink.
          // To pass through modified input to the app for custom processing
          // on the app UI thread instead of the background ink thread, set
          // InputProcessingConfiguration.RightDragAction to LeaveUnprocessed.
          inkCanvas.InkPresenter.InputProcessingConfiguration.RightDragAction =
              InkInputRightDragAction.LeaveUnprocessed;

          // Listen for unprocessed pointer events from modified input.
          // The input is used to provide selection functionality.
          inkCanvas.InkPresenter.UnprocessedInput.PointerPressed +=
              UnprocessedInput_PointerPressed;
          inkCanvas.InkPresenter.UnprocessedInput.PointerMoved +=
              UnprocessedInput_PointerMoved;
          inkCanvas.InkPresenter.UnprocessedInput.PointerReleased +=
              UnprocessedInput_PointerReleased;

          // Listen for new ink or erase strokes to clean up selection UI.
          inkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
              StrokeInput_StrokeStarted;
          inkCanvas.InkPresenter.StrokesErased +=
              InkPresenter_StrokesErased;
        }
      ```

4.  <span data-ttu-id="08dd8-200">次に、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってパススルーされる [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/dn914712)、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/dn914711)、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/dn914713) の未処理イベントのハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-200">We then define handlers for the unprocessed [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/dn914712), [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/dn914711), and [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/dn914713) events passed through by the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081).</span></span>

    <span data-ttu-id="08dd8-201">なげなわストロークと境界の四角形を含むすべての選択機能をこれらのハンドラーに実装します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-201">All selection functionality is implemented in these handlers, including the lasso stroke and the bounding rectangle.</span></span>

    ![なげなわ選択](images/ink-unprocessed-3-small.png)

      ```csharp
        // Handle unprocessed pointer events from modified input.
        // The input is used to provide selection functionality.
        // Selection UI is drawn on a canvas under the InkCanvas.
        private void UnprocessedInput_PointerPressed(
          InkUnprocessedInput sender, PointerEventArgs args)
        {
          // Initialize a selection lasso.
          lasso = new Polyline()
          {
            Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
              StrokeThickness = 1,
              StrokeDashArray = new DoubleCollection() { 5, 2 },
              };

              lasso.Points.Add(args.CurrentPoint.RawPosition);

              selectionCanvas.Children.Add(lasso);
          }

          private void UnprocessedInput_PointerMoved(
            InkUnprocessedInput sender, PointerEventArgs args)
          {
            // Add a point to the lasso Polyline object.
            lasso.Points.Add(args.CurrentPoint.RawPosition);
          }

          private void UnprocessedInput_PointerReleased(
            InkUnprocessedInput sender, PointerEventArgs args)
          {
            // Add the final point to the Polyline object and
            // select strokes within the lasso area.
            // Draw a bounding box on the selection canvas
            // around the selected ink strokes.
            lasso.Points.Add(args.CurrentPoint.RawPosition);

            boundingRect =
              inkCanvas.InkPresenter.StrokeContainer.SelectWithPolyLine(
                lasso.Points);

            DrawBoundingRect();
          }
      ```

5.  <span data-ttu-id="08dd8-203">PointerReleased イベント ハンドラーの最後の処理として、選択レイヤーのすべてのコンテンツ (なげなわストローク) をクリアして、なげなわの領域で囲まれたインク ストロークの周りに境界の四角形を 1 つ描画します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-203">To conclude the PointerReleased event handler, we clear the selection layer of all content (the lasso stroke) and then draw a single bounding rectangle around the ink strokes encompassed by the lasso area.</span></span>

    ![選択範囲の境界の四角形](images/ink-unprocessed-4-small.png)

      ```csharp
        // Draw a bounding rectangle, on the selection canvas, encompassing
        // all ink strokes within the lasso area.
        private void DrawBoundingRect()
        {
          // Clear all existing content from the selection canvas.
          selectionCanvas.Children.Clear();

          // Draw a bounding rectangle only if there are ink strokes
          // within the lasso area.
          if (!((boundingRect.Width == 0) ||
            (boundingRect.Height == 0) ||
            boundingRect.IsEmpty))
            {
              var rectangle = new Rectangle()
              {
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                  StrokeThickness = 1,
                  StrokeDashArray = new DoubleCollection() { 5, 2 },
                  Width = boundingRect.Width,
                  Height = boundingRect.Height
              };

              Canvas.SetLeft(rectangle, boundingRect.X);
              Canvas.SetTop(rectangle, boundingRect.Y);

              selectionCanvas.Children.Add(rectangle);
            }
          }
      ```

6.  <span data-ttu-id="08dd8-205">最後に、InkPresenter の [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702) イベントと [**StrokesErased**](https://msdn.microsoft.com/library/windows/apps/dn948767) イベントのハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-205">Finally, we define handlers for the [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702) and [**StrokesErased**](https://msdn.microsoft.com/library/windows/apps/dn948767) InkPresenter events.</span></span>

    <span data-ttu-id="08dd8-206">これらは両方とも同じクリーンアップ関数を呼び出します。これにより、新しいストロークが検出されるたびに現在の選択がクリアされます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-206">These both just call the same cleanup function to clear the current selection whenever a new stroke is detected.</span></span>

      ```csharp
        // Handle new ink or erase strokes to clean up selection UI.
        private void StrokeInput_StrokeStarted(
          InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
        {
          ClearSelection();
        }

        private void InkPresenter_StrokesErased(
          InkPresenter sender, InkStrokesErasedEventArgs args)
        {
          ClearSelection();
        }
      ```

7.  <span data-ttu-id="08dd8-207">次の例は、新しいストロークが開始された場合や既にあるストロークが消去された場合に選択キャンバスからすべての選択 UI を削除する関数を示しています。</span><span class="sxs-lookup"><span data-stu-id="08dd8-207">Here's the function to remove all selection UI from the selection canvas when a new stroke is started or an existing stroke is erased.</span></span>

      ```csharp
        // Clean up selection UI.
        private void ClearSelection()
        {
          var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
          foreach (var stroke in strokes)
          {
            stroke.Selected = false;
          }
          ClearDrawnBoundingRect();
         }

        private void ClearDrawnBoundingRect()
        {
          if (selectionCanvas.Children.Any())
          {
            selectionCanvas.Children.Clear();
            boundingRect = Rect.Empty;
          }
        }
      ```

## <a name="custom-ink-rendering"></a><span data-ttu-id="08dd8-208">カスタム インク レンダリング</span><span class="sxs-lookup"><span data-stu-id="08dd8-208">Custom ink rendering</span></span>

<span data-ttu-id="08dd8-209">既定では、手書き入力は待機時間が短いバックグラウンド スレッドで処理され、描画と同時にレンダリングが実行中となります ("ウェット" レンダリングが実行されます)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-209">By default, ink input is processed on a low-latency background thread and rendered in-progress, or "wet", as it is drawn.</span></span> <span data-ttu-id="08dd8-210">ストロークが完了すると (ペンまたは指が画面を離れるか、マウスのボタンが離されると)、UI スレッドでストロークが処理されて、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) レイヤーへの "ドライ" レンダリングが行われます (アプリケーション コンテンツの上にレンダリングされてウェット インクが置き換えられます)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-210">When the stroke is completed (pen or finger lifted, or mouse button released), the stroke is processed on the UI thread and rendered "dry" to the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) layer (above the application content and replacing the wet ink).</span></span>

<span data-ttu-id="08dd8-211">ウェット インク ストロークを "カスタム ドライ レンダリング" することによって、この既定の動作を上書きし、手描き入力エクスペリエンスを完全に制御することができます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-211">You can override this default behavior and completely control the inking experience by "custom drying" the wet ink strokes.</span></span> <span data-ttu-id="08dd8-212">ほとんどのアプリケーションでは、通常、既定の動作で十分ですが、場合によっては、カスタム ドライ レンダリングが必要になります。次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-212">While the default behavior is typically sufficient for most applications, there are a few cases where custom drying might be required, these include:</span></span>
- <span data-ttu-id="08dd8-213">大きく複雑なインク ストロークのコレクションをより効率的に管理する場合</span><span class="sxs-lookup"><span data-stu-id="08dd8-213">More efficient management of large, or complex, collections of ink strokes</span></span>
- <span data-ttu-id="08dd8-214">大きなインク キャンバスでより効率的にパンやズームのサポートを行う場合</span><span class="sxs-lookup"><span data-stu-id="08dd8-214">More efficient panning and zooming support on large ink canvases</span></span>
- <span data-ttu-id="08dd8-215">Z オーダーを維持しながら、インクや他のオブジェクト (図形やテキストなど) をインターリーブする場合</span><span class="sxs-lookup"><span data-stu-id="08dd8-215">Interleaving ink and other objects, such as shapes or text, while maintaining z-order</span></span> 
- <span data-ttu-id="08dd8-216">ドライ レンダリングを行い、インクを DirectX 図形に同期的に変換する場合 (たとえば、ラスタライズされ、アプリケーション コンテンツに (個別の **InkCanvas** レイヤーとしてではなく) 統合される直線や図形など)。</span><span class="sxs-lookup"><span data-stu-id="08dd8-216">Drying and converting ink synchronously into a DirectX shape (for example, a straight line or shape rasterized and integrated into application content instead of as a separate **InkCanvas** layer).</span></span>

<span data-ttu-id="08dd8-217">カスタム ドライ レンダリングでは、手書き入力を管理して、既定の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの代わりにユニバーサル Windows アプリの Direct2D デバイス コンテキストにレンダリングするための [**IInkD2DRenderer**](https://msdn.microsoft.com/library/mt147263) オブジェクトが必要です。</span><span class="sxs-lookup"><span data-stu-id="08dd8-217">Custom drying requires an [**IInkD2DRenderer**](https://msdn.microsoft.com/library/mt147263) object to manage the ink input and render it to the Direct2D device context of your Universal Windows app, instead of the default [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span>

<span data-ttu-id="08dd8-218">[**ActivateCustomDrying**](https://msdn.microsoft.com/library/windows/apps/dn922012) を ([**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が読み込まれる前に) 呼び出すと、[**SurfaceImageSource**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Media.Imaging.SurfaceImageSource) または [**VirtualSurfaceImageSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.virtualsurfaceimagesource) へのインク ストロークのドライ レンダリングの方法をカスタマイズするための [**InkSynchronizer**](https://msdn.microsoft.com/library/windows/apps/dn903979) オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="08dd8-218">By calling [**ActivateCustomDrying**](https://msdn.microsoft.com/library/windows/apps/dn922012) (before the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) is loaded), an app creates an [**InkSynchronizer**](https://msdn.microsoft.com/library/windows/apps/dn903979) object to customize how an ink stroke is rendered dry to a [**SurfaceImageSource**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Media.Imaging.SurfaceImageSource) or [**VirtualSurfaceImageSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.virtualsurfaceimagesource).</span></span> 

<span data-ttu-id="08dd8-219">[**SurfaceImageSource**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Media.Imaging.SurfaceImageSource) と [**VirtualSurfaceImageSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.virtualsurfaceimagesource) はどちらも、アプリがアプリケーションのコンテンツに描画し、組み込むための DirectX 共有サーフェスを提供します。ただし VSIS は、効率的なパンやズームのために、画面よりも大きい仮想サーフェスを提供します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-219">Both [**SurfaceImageSource**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Media.Imaging.SurfaceImageSource) and [**VirtualSurfaceImageSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.virtualsurfaceimagesource) provide a DirectX shared surface for your app to draw into and compose into your application's content, although VSIS provides a virtual surface that’s larger than the screen for performant panning and zooming.</span></span> <span data-ttu-id="08dd8-220">これらのサーフェスの表示更新は XAML の UI スレッドと同期されるため、インクをいずれかにレンダリングしたとき、同時にウェット インクが InkCanvas から取り除かれる場合があります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-220">Because visual updates to these surfaces are synchronized with the XAML UI thread, when ink is rendered to either, the wet ink can be removed from the InkCanvas  simultaneously.</span></span> 

<span data-ttu-id="08dd8-221">ドライ インクを [SwapChainPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swapchainpanel) 用にカスタマイズすることもできますが、UI スレッドとの同期は保証されません。インクを SwapChainPanel にレンダリングしたタイミングと、インクが InkCanvas から取り除かれるタイミングの間にずれが生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-221">You can also custom dry ink to a [SwapChainPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swapchainpanel), but synchronization with the UI thread is not guaranteed and there might be a delay between when the ink is rendered to your SwapChainPanel and when ink is removed from the InkCanvas.</span></span>

<span data-ttu-id="08dd8-222">この機能の完全な例については、「[複雑なインクのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620314)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08dd8-222">For a full example of this functionality, see the [Complex ink sample](https://go.microsoft.com/fwlink/p/?LinkID=620314).</span></span>

> [!NOTE]
> <span data-ttu-id="08dd8-223">カスタム ドライ レンダリングと [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="08dd8-223">Custom drying and the [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)</span></span>  
> <span data-ttu-id="08dd8-224">カスタム ドライの実装によって、アプリが [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の既定のインク レンダリング動作を上書きすると、レンダリングされたインク ストロークが InkToolbar で利用できなくなり、InkToolbar の組み込みの消去コマンドが正常に機能しなくなります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-224">If your app overrides the default ink rendering behavior of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) with a custom drying implementation, the rendered ink strokes are no longer available to the InkToolbar and the built-in erase commands of the InkToolbar do not work as expected.</span></span> <span data-ttu-id="08dd8-225">消去機能を提供するには、すべてのポインター イベントを処理し、ストロークごとにヒット テストを実行すると共に、組み込みの [すべてのインクのデータを消去] コマンドをオーバーライドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="08dd8-225">To provide erase functionality, you must handle all pointer events, perform hit-testing on each stroke, and override the built-in "Erase all ink" command.</span></span>

## <a name="other-articles-in-this-section"></a><span data-ttu-id="08dd8-226">このセクションの他の記事</span><span class="sxs-lookup"><span data-stu-id="08dd8-226">Other articles in this section</span></span>

| <span data-ttu-id="08dd8-227">トピック</span><span class="sxs-lookup"><span data-stu-id="08dd8-227">Topic</span></span> | <span data-ttu-id="08dd8-228">説明</span><span class="sxs-lookup"><span data-stu-id="08dd8-228">Description</span></span> |
| --- | --- |
| [<span data-ttu-id="08dd8-229">インク ストロークの認識</span><span class="sxs-lookup"><span data-stu-id="08dd8-229">Recognize ink strokes</span></span>](convert-ink-to-text.md) | <span data-ttu-id="08dd8-230">インク ストロークを手書き認識によりテキストに変換したり、カスタム認識により図形に変換したりします。</span><span class="sxs-lookup"><span data-stu-id="08dd8-230">Convert ink strokes to text using handwriting recognition, or to shapes using custom recognition.</span></span> |
| [<span data-ttu-id="08dd8-231">インク ストロークの保存と取得</span><span class="sxs-lookup"><span data-stu-id="08dd8-231">Store and retrieve ink strokes</span></span>](save-and-load-ink.md) | <span data-ttu-id="08dd8-232">埋め込みの Ink Serialized Format (ISF) メタデータを使って、インク ストローク データをグラフィックス交換形式 (GIF) ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="08dd8-232">Store ink stroke data in a Graphics Interchange Format (GIF) file using embedded Ink Serialized Format (ISF) metadata.</span></span> |
| [<span data-ttu-id="08dd8-233">UWP 手描き入力アプリへの InkToolbar の追加</span><span class="sxs-lookup"><span data-stu-id="08dd8-233">Add an InkToolbar to a UWP inking app</span></span>](ink-toolbar.md) | <span data-ttu-id="08dd8-234">既定の InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加し、カスタム ペン ボタンを InkToolbar に追加して、カスタム ペン ボタンをカスタム ペン定義にバインドします。</span><span class="sxs-lookup"><span data-stu-id="08dd8-234">Add a default InkToolbar to a Universal Windows Platform (UWP) inking app, add a custom pen button to the InkToolbar, and bind the custom pen button to a custom pen definition.</span></span> |

## <a name="related-articles"></a><span data-ttu-id="08dd8-235">関連記事</span><span class="sxs-lookup"><span data-stu-id="08dd8-235">Related articles</span></span>

* [<span data-ttu-id="08dd8-236">作業の開始: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="08dd8-236">Get started: Support ink in your UWP app</span></span>](../../get-started/ink-walkthrough.md)
* [<span data-ttu-id="08dd8-237">ポインター入力の処理</span><span class="sxs-lookup"><span data-stu-id="08dd8-237">Handle pointer input</span></span>](handle-pointer-input.md)
* [<span data-ttu-id="08dd8-238">入力デバイスの識別</span><span class="sxs-lookup"><span data-stu-id="08dd8-238">Identify input devices</span></span>](identify-input-devices.md)

**<span data-ttu-id="08dd8-239">API</span><span class="sxs-lookup"><span data-stu-id="08dd8-239">APIs</span></span>**

* [**<span data-ttu-id="08dd8-240">Windows.Devices.Input</span><span class="sxs-lookup"><span data-stu-id="08dd8-240">Windows.Devices.Input</span></span>**](https://msdn.microsoft.com/library/windows/apps/br225648)
* [**<span data-ttu-id="08dd8-241">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="08dd8-241">Windows.UI.Input.Inking</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208524)
* [**<span data-ttu-id="08dd8-242">Windows.UI.Input.Inking.Core</span><span class="sxs-lookup"><span data-stu-id="08dd8-242">Windows.UI.Input.Inking.Core</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn958452)

**<span data-ttu-id="08dd8-243">サンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-243">Samples</span></span>**
* [<span data-ttu-id="08dd8-244">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="08dd8-244">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="08dd8-245">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="08dd8-245">Simple ink sample (C#/C++)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="08dd8-246">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="08dd8-246">Complex ink sample (C++)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="08dd8-247">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="08dd8-247">Ink sample (JavaScript)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="08dd8-248">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-248">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="08dd8-249">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-249">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)
* [<span data-ttu-id="08dd8-250">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-250">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="08dd8-251">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-251">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="08dd8-252">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-252">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="08dd8-253">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-253">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="08dd8-254">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="08dd8-254">Archive Samples</span></span>**
* [<span data-ttu-id="08dd8-255">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-255">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="08dd8-256">入力: XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-256">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="08dd8-257">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="08dd8-257">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="08dd8-258">入力: GestureRecognizer によるジェスチャと操作</span><span class="sxs-lookup"><span data-stu-id="08dd8-258">Input: Gestures and manipulations with GestureRecognizer</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231605)
