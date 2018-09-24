---
author: normesta
description: このガイドは、WPF および Windows フォーム アプリケーションで直接 Fluent ベースの UWP UI を作成するのに役立ちます。
title: デスクトップ アプリケーションで UWP コントロール
ms.author: normesta
ms.date: 09/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp, windows forms, wpf
keywords: windows 10, uwp, windows, フォーム, wpf
ms.localizationpriority: medium
ms.openlocfilehash: d5a4865f403685752225a729bf68abb15237dd90
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4156585"
---
# <a name="uwp-controls-in-desktop-applications"></a><span data-ttu-id="bca07-104">デスクトップ アプリケーションで UWP コントロール</span><span class="sxs-lookup"><span data-stu-id="bca07-104">UWP controls in desktop applications</span></span>

> [!NOTE]
> <span data-ttu-id="bca07-105">Api と、この記事で説明するコントロールは開発者プレビューとして現在利用可能です。</span><span class="sxs-lookup"><span data-stu-id="bca07-105">The APIs and controls discussed in this article are currently available as a developer preview.</span></span> <span data-ttu-id="bca07-106">それらプロトタイプ コードで今すぐ試すをお勧めしますがないことで使う運用コードこの時点でお勧めしますしないでください。</span><span class="sxs-lookup"><span data-stu-id="bca07-106">Although we encourage you to try them out in your own prototype code now, we do not recommend that you use them in production code at this time.</span></span> <span data-ttu-id="bca07-107">これらの Api とコントロールは引き続き成熟し、今後の Windows のリリースに安定します。</span><span class="sxs-lookup"><span data-stu-id="bca07-107">These APIs and controls will continue to mature and stabilize in future Windows releases.</span></span> <span data-ttu-id="bca07-108">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="bca07-108">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="bca07-109">Windows 10 の次期リリースで追加しています UWP コントロール UWP 以外にデスクトップ アプリケーションの外観、や、既存のデスクトップ アプリケーション、最新の Windows 10 の UI 機能のみで利用可能な UWP コントロールの機能を高めることができるように.</span><span class="sxs-lookup"><span data-stu-id="bca07-109">In the next release of Windows 10 we're bringing UWP controls to non-UWP desktop applications so that you can enhance the look, feel, and functionality of your existing desktop applications with the latest Windows 10 UI features that are only available via UWP control.</span></span> <span data-ttu-id="bca07-110">つまり、 [Fluent Design System](../design/fluent-design-system/index.md)と既存の WPF、Windows フォーム、C/C++ Win32 アプリケーションでは、 [Windows Ink](../design/input/pen-and-stylus-interactions.md)などの UWP 機能を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="bca07-110">This means that you can use UWP features such as [Fluent Design System](../design/fluent-design-system/index.md) and [Windows Ink](../design/input/pen-and-stylus-interactions.md) in your existing WPF, Windows Forms, and C/C++ Win32 applications.</span></span> <span data-ttu-id="bca07-111">このシナリオは、 *XAML 諸島*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="bca07-111">This developer scenario is sometimes called *XAML islands*.</span></span>

<span data-ttu-id="bca07-112">XAML 諸島テクノロジやフレームワークを使用しているによって、デスクトップ アプリケーションで使用するいくつかの方法が提供されます。</span><span class="sxs-lookup"><span data-stu-id="bca07-112">We will provide several ways to use XAML islands in your desktop applications, depending on the technology or framework you are using.</span></span>

## <a name="wrapped-controls"></a><span data-ttu-id="bca07-113">ラップされたコントロール</span><span class="sxs-lookup"><span data-stu-id="bca07-113">Wrapped controls</span></span>

<span data-ttu-id="bca07-114">[Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)の WPF および Windows フォーム アプリケーションにラップされた UWP のコントロールの選択項目が提供されます。</span><span class="sxs-lookup"><span data-stu-id="bca07-114">We will provide a selection of wrapped UWP controls for WPF and Windows Forms applications in the [Windows Community Toolkit](https://docs.microsoft.com/windows/uwpcommunitytoolkit/).</span></span> <span data-ttu-id="bca07-115">これらのコントロールを直接 WPF または Windows フォーム プロジェクトのデザイン サーフェイスに追加し、デザイナーで、他の WPF または Windows フォームなどのコントロールと同様に使用できます。</span><span class="sxs-lookup"><span data-stu-id="bca07-115">You can add these controls directly to the design surface of your WPF or Windows Forms project and then use like any other WPF or Windows Forms control in your designer.</span></span> <span data-ttu-id="bca07-116">これらのコントロールといいます*コントロールをラップ*インターフェイスと特定の UWP コントロールの機能をラップするためです。</span><span class="sxs-lookup"><span data-stu-id="bca07-116">We refer to these controls as *wrapped controls* because they wrap the interface and functionality of a specific UWP control.</span></span>

<span data-ttu-id="bca07-117">Windows コミュニティ ツールキットでこれを[WebView](https://docs.microsoft.com/windows/communitytoolkit/controls/webview)で今すぐを制御してみてください。</span><span class="sxs-lookup"><span data-stu-id="bca07-117">Try this out today with the [WebView](https://docs.microsoft.com/windows/communitytoolkit/controls/webview) control in the Windows Community Toolkit.</span></span> <span data-ttu-id="bca07-118">このコントロールは、WPF または Windows フォーム アプリケーションで web コンテンツを表示するのに Microsoft Edge レンダリング エンジンを使用します。</span><span class="sxs-lookup"><span data-stu-id="bca07-118">This control uses the Microsoft Edge rendering engine to show web content in a WPF or Windows Forms application.</span></span>  

<span data-ttu-id="bca07-119">WPF をラップされたその他の UWP コントロールを計画しますもと Windows コミュニティ ツールキットの今後のリリースにおける Windows フォーム アプリケーションも含め。</span><span class="sxs-lookup"><span data-stu-id="bca07-119">We are also planning additional wrapped UWP controls for WPF and Windows Forms applications in future releases of the Windows Community Toolkit, including:</span></span>

* <span data-ttu-id="bca07-120">**WebViewCompatible**します。</span><span class="sxs-lookup"><span data-stu-id="bca07-120">**WebViewCompatible**.</span></span> <span data-ttu-id="bca07-121">このコントロールは、Windows 10 と互換性がある**WebView**のバージョンと Windows の以前のバージョンです。</span><span class="sxs-lookup"><span data-stu-id="bca07-121">This control is a version of **WebView** that is compatible with Windows 10 and previous versions of Windows.</span></span> <span data-ttu-id="bca07-122">このコントロールは、Windows 10 で web コンテンツを表示する Microsoft Edge レンダリング エンジンと以前のバージョンで web コンテンツを表示する Internet Explorer のレンダリング エンジンを使用します。</span><span class="sxs-lookup"><span data-stu-id="bca07-122">This control uses the Microsoft Edge rendering engine to show web content on Windows 10, and the Internet Explorer rendering engine to show web content on earlier versions.</span></span>
* <span data-ttu-id="bca07-123">**InkCanvas**と**InkToolbar**します。</span><span class="sxs-lookup"><span data-stu-id="bca07-123">**InkCanvas** and **InkToolbar**.</span></span> <span data-ttu-id="bca07-124">これらのコントロールは、Windows フォームや WPF デスクトップ アプリケーションでの Windows Ink ベースのユーザー操作のサーフェスと関連するツールバーを提供します。</span><span class="sxs-lookup"><span data-stu-id="bca07-124">These controls provide a surface and related toolbars for Windows Ink-based user interaction in your Windows Forms or WPF desktop application.</span></span>
* <span data-ttu-id="bca07-125">**MediaPlayerElement**します。</span><span class="sxs-lookup"><span data-stu-id="bca07-125">**MediaPlayerElement**.</span></span> <span data-ttu-id="bca07-126">このコントロールは、ストリームし、Windows フォームや WPF デスクトップ アプリケーションのビデオなどのメディア コンテンツをレンダリングするビューを埋め込みます。</span><span class="sxs-lookup"><span data-stu-id="bca07-126">This control embeds a view that streams and renders media content such as video in your Windows Forms or WPF desktop application.</span></span>

<span data-ttu-id="bca07-127">複数の UWP では、コントロールをラップ wpf と Windows コミュニティ ツールキットの今後のリリースの Windows フォーム アプリケーションが計画されています。</span><span class="sxs-lookup"><span data-stu-id="bca07-127">More UWP wrapped controls for WPF and Windows Forms applications are planned for future releases of the Windows Community Toolkit.</span></span>

> [!NOTE]
> <span data-ttu-id="bca07-128">ラップされたコントロールでは、C/C++ Win32 デスクトップ アプリケーションを利用できません。</span><span class="sxs-lookup"><span data-stu-id="bca07-128">Wrapped controls are not available for C/C++ Win32 desktop applications.</span></span> <span data-ttu-id="bca07-129">この種類のアプリケーションでは、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bca07-129">These types of applications must use the [UWP XAML hosting API](#uwp-xaml-hosting-api).</span></span>

## <a name="host-controls"></a><span data-ttu-id="bca07-130">コントロールをホストします。</span><span class="sxs-lookup"><span data-stu-id="bca07-130">Host controls</span></span>

<span data-ttu-id="bca07-131">利用可能なラップされたコントロールでカバーされている以外のシナリオで WPF および Windows フォーム アプリケーションは[WindowsXamlHost](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/docs/controls/WindowsXAMLHost.md)コントロールを[Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)で使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="bca07-131">For scenarios beyond those covered by the available wrapped controls, WPF and Windows Forms applications can also use the [WindowsXamlHost](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/docs/controls/WindowsXAMLHost.md) control in the [Windows Community Toolkit](https://docs.microsoft.com/windows/uwpcommunitytoolkit/).</span></span> <span data-ttu-id="bca07-132">このコントロールは、 [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)、Windows SDK とカスタム ユーザー コントロールによって提供されるすべての UWP コントロールを含むから派生したすべての UWP コントロールをホストできます。</span><span class="sxs-lookup"><span data-stu-id="bca07-132">This control can host any UWP control that derives from [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement), including any UWP control provided by the Windows SDK as well as custom user controls.</span></span>

> [!NOTE]
> <span data-ttu-id="bca07-133">ホスト コントロールでは、C/C++ Win32 デスクトップ アプリケーションを利用できません。</span><span class="sxs-lookup"><span data-stu-id="bca07-133">Host controls are not available for C/C++ Win32 desktop applications.</span></span> <span data-ttu-id="bca07-134">この種類のアプリケーションでは、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bca07-134">These types of applications must use the [UWP XAML hosting API](#uwp-xaml-hosting-api).</span></span>

## <a name="uwp-xaml-hosting-api"></a><span data-ttu-id="bca07-135">UWP XAML API をホストしています。</span><span class="sxs-lookup"><span data-stu-id="bca07-135">UWP XAML hosting API</span></span>

<span data-ttu-id="bca07-136">C/C++ WinRT アプリケーションがある場合は、関連付けられているウィンドウ ハンドル (HWND) には、アプリケーション内の任意の UI 要素で[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)から派生したすべての UWP コントロールをホストする*API をホストしている UWP XAML*を使用できます。</span><span class="sxs-lookup"><span data-stu-id="bca07-136">If you have a C/C++ WinRT application, you can use the *UWP XAML hosting API* to host any UWP control that derives from [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) in any UI element in your application that has an associated window handle (HWND).</span></span> <span data-ttu-id="bca07-137">この API の使用について詳しくは、[デスクトップ アプリケーションでの API をホストしている XAML を使って](using-the-xaml-hosting-api.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bca07-137">For more information about using this API, see [Using the XAML hosting API in a desktop application](using-the-xaml-hosting-api.md).</span></span>

> [!NOTE]
> <span data-ttu-id="bca07-138">C/C++ Win32 デスクトップ アプリケーションでは、UWP コントロールをホストする API をホストしている UWP XAML を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bca07-138">C/C++ Win32 desktop applications must use the UWP XAML hosting API to host UWP controls.</span></span> <span data-ttu-id="bca07-139">ラップされたコントロールとホスト コントロールでは、この種類のアプリケーションを利用できません。</span><span class="sxs-lookup"><span data-stu-id="bca07-139">Wrapped controls and host controls are not available for these types of applications.</span></span> <span data-ttu-id="bca07-140">WPF および Windows フォーム アプリケーションでは、お勧めします UWP XAML ではなく Windows コミュニティ ツールキットでラップされたコントロールとホスト コントロールが使用して API をホストしています。</span><span class="sxs-lookup"><span data-stu-id="bca07-140">For WPF and Windows Forms applications, we recommend that you use the wrapped controls and host controls in the Windows Community Toolkit instead of the UWP XAML hosting API.</span></span> <span data-ttu-id="bca07-141">これらのコントロールでは、内部的に API をホストしている UWP XAML を使用し、シンプルな開発エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="bca07-141">These controls use the UWP XAML hosting API internally and provide a simpler development experience.</span></span> <span data-ttu-id="bca07-142">ただし、選択した場合、WPF および Windows フォーム アプリケーションで直接 API をホストしている UWP XAML を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="bca07-142">However, you can use the UWP XAML hosting API directly in WPF and Windows Forms applications if you choose.</span></span>

## <a name="architecture-overview"></a><span data-ttu-id="bca07-143">アーキテクチャの概要</span><span class="sxs-lookup"><span data-stu-id="bca07-143">Architecture overview</span></span>

<span data-ttu-id="bca07-144">これらのコントロールがアーキテクチャ的に編成されるしくみの概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bca07-144">Here's a quick look at how these controls are organized architecturally.</span></span> <span data-ttu-id="bca07-145">この図で使用される名前は変更されることがあります。</span><span class="sxs-lookup"><span data-stu-id="bca07-145">The names used in this diagram are subject to change.</span></span>  

![ホスト コントロール アーキテクチャ](images/host-controls.png)

<span data-ttu-id="bca07-147">この図の下部に表示されている API は、Windows SDK に付属しています。</span><span class="sxs-lookup"><span data-stu-id="bca07-147">The APIs that appear at the bottom of this diagram ship with the Windows SDK.</span></span> <span data-ttu-id="bca07-148">デザイナーに追加するコントロールは、Windows コミュニティ ツールキットで Nuget パッケージとしてリリースされます。</span><span class="sxs-lookup"><span data-stu-id="bca07-148">The controls that you'll add to your designer ship as Nuget packages in the Windows Community Toolkit.</span></span>

<span data-ttu-id="bca07-149">これらの新しいコントロールには制限事項があるため、それらを使用する前に、まだサポートされていない機能、また回避策を使用してのみ動作する機能を少し時間を取って確認してください。</span><span class="sxs-lookup"><span data-stu-id="bca07-149">These new controls have limitations so before you use them, please take a moment to review what's not yet supported, and what's functional only with workarounds.</span></span>

## <a name="limitations"></a><span data-ttu-id="bca07-150">制限事項</span><span class="sxs-lookup"><span data-stu-id="bca07-150">Limitations</span></span>

### <a name="whats-supported"></a><span data-ttu-id="bca07-151">サポートされている内容</span><span class="sxs-lookup"><span data-stu-id="bca07-151">What's supported</span></span>

<span data-ttu-id="bca07-152">ほとんどの場合、次の一覧で明示されていない限り、すべてがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="bca07-152">For the most part, everything is supported unless explicitly called out in the list below.</span></span>

### <a name="whats-supported-only-with-workarounds"></a><span data-ttu-id="bca07-153">回避策を使用した場合にのみサポートされている内容</span><span class="sxs-lookup"><span data-stu-id="bca07-153">What's supported only with workarounds</span></span>

<span data-ttu-id="bca07-154">:heavy_check_mark: 複数のウィンドウの内部での複数のインボックス コントロールのホスティング。</span><span class="sxs-lookup"><span data-stu-id="bca07-154">:heavy_check_mark: Hosting multiple inbox controls inside of multiple windows.</span></span> <span data-ttu-id="bca07-155">独自のスレッドに各ウィンドウを配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bca07-155">You'll have to place each window in its own thread.</span></span>

<span data-ttu-id="bca07-156">:heavy_check_mark: ホストされたコントロールでの ``x:Bind`` の使用。</span><span class="sxs-lookup"><span data-stu-id="bca07-156">:heavy_check_mark: Using ``x:Bind`` with hosted controls.</span></span> <span data-ttu-id="bca07-157">.NET Standard ライブラリ内でデータ モデルを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bca07-157">You'll have to declare the data model in a .NET Standard library.</span></span>

<span data-ttu-id="bca07-158">:heavy_check_mark: C# ベースのサードパーティのコントロール。</span><span class="sxs-lookup"><span data-stu-id="bca07-158">:heavy_check_mark: C#-based third-party controls.</span></span> <span data-ttu-id="bca07-159">サードパーティのコントロールへのソース コードがある場合は、それに対してコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="bca07-159">If you have the source code to a third-party control, you can compile against it.</span></span>

### <a name="whats-not-yet-supported"></a><span data-ttu-id="bca07-160">まだサポートされていない内容</span><span class="sxs-lookup"><span data-stu-id="bca07-160">What's not yet supported</span></span>

<span data-ttu-id="bca07-161">:no_entry_sign: アプリケーションおよびホストされたコントロールでシームレスに動作するアクセシビリティ ツール。</span><span class="sxs-lookup"><span data-stu-id="bca07-161">:no_entry_sign: Accessibility tools that work seamlessly across the application and hosted controls.</span></span>

<span data-ttu-id="bca07-162">:no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーションに追加するコントロール内のローカライズされたコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="bca07-162">:no_entry_sign: Localized content in controls that you add to applications which don't contain a Windows app package.</span></span>

<span data-ttu-id="bca07-163">: no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーション内で XAML で行われたアセット参照。</span><span class="sxs-lookup"><span data-stu-id="bca07-163">:no_entry_sign: Asset references made in XAML within applications that don't contain a Windows app package.</span></span>

<span data-ttu-id="bca07-164">:no_entry_sign:  DPI と倍率の変更に適切に対応するコントロール。</span><span class="sxs-lookup"><span data-stu-id="bca07-164">:no_entry_sign: Controls properly responding to changes in DPI and scale.</span></span>

<span data-ttu-id="bca07-165">:no_entry_sign: カスタム ユーザー コントロールへの **WebView** コントロールの追加 (スレッド上、オフ スレッド、proc 外のいずれか)</span><span class="sxs-lookup"><span data-stu-id="bca07-165">:no_entry_sign: Adding a **WebView** control to a custom user control, (Either on-thread, off-thread, or out of proc).</span></span>

<span data-ttu-id="bca07-166">:no_entry_sign: [表示ハイライト](https://docs.microsoft.com/windows/uwp/design/style/reveal)  の Fluent 効果。</span><span class="sxs-lookup"><span data-stu-id="bca07-166">:no_entry_sign: The [Reveal highlight](https://docs.microsoft.com/windows/uwp/design/style/reveal) Fluent effect.</span></span>

<span data-ttu-id="bca07-167">:no_entry_sign: 入力コントロールのためのインライン インク、@Places
、@People。</span><span class="sxs-lookup"><span data-stu-id="bca07-167">:no_entry_sign: Inline inking, @Places, and @People for input controls.</span></span>

<span data-ttu-id="bca07-168">:no_entry_sign: ショートカット キーの割り当て。</span><span class="sxs-lookup"><span data-stu-id="bca07-168">:no_entry_sign: Assigning accelerator keys.</span></span>

<span data-ttu-id="bca07-169">:no_entry_sign: C++ ベースのサードパーティのコントロール。</span><span class="sxs-lookup"><span data-stu-id="bca07-169">:no_entry_sign: C++-based third-party controls.</span></span>

<span data-ttu-id="bca07-170">:no_entry_sign: カスタム ユーザー コントロールのホスティング。</span><span class="sxs-lookup"><span data-stu-id="bca07-170">:no_entry_sign: Hosting custom user controls.</span></span>

<span data-ttu-id="bca07-171">Fluent をデスクトップに導入するエクスペリエンスの向上を続けていくうえで、この一覧の項目は変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bca07-171">The items in this list will likely change as we continue to improve the experience of bringing Fluent to the desktop.</span></span>  
