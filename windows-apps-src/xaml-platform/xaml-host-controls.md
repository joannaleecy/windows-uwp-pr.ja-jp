---
author: normesta
description: このガイドは、WPF および Windows フォーム アプリケーションで直接 Fluent ベースの UWP UI を作成するのに役立ちます。
title: WPF および Windows フォーム アプリケーションで UWP コントロールをホストする
ms.author: normesta
ms.date: 05/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp, windows forms, wpf
keywords: windows 10, uwp, windows, フォーム, wpf
ms.localizationpriority: medium
ms.openlocfilehash: 4823654bce3373ace5b04ced8ec14c4b6c1b6f1d
ms.sourcegitcommit: 3500825bc2e5698394a8b1d2efece7f071f296c1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/09/2018
ms.locfileid: "1862071"
---
# <a name="host-uwp-controls-in-wpf-and-windows-forms-applications"></a><span data-ttu-id="a94d0-104">WPF および Windows フォーム アプリケーションで UWP コントロールをホストする</span><span class="sxs-lookup"><span data-stu-id="a94d0-104">Host UWP controls in WPF and Windows Forms applications</span></span>

> [!NOTE]
> <span data-ttu-id="a94d0-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a94d0-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="a94d0-106">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="a94d0-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="a94d0-107">Fluent Design 機能を使用して既存の WPF または Windows アプリケーションの外観や機能を高めることができるように、UWP コントロールをデスクトップに追加しています。</span><span class="sxs-lookup"><span data-stu-id="a94d0-107">We're bringing UWP controls to the desktop so that you can enhance the look, feel, and functionality of your existing WPF or Windows applications with Fluent Design features.</span></span> <span data-ttu-id="a94d0-108">これには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="a94d0-108">There's two ways to do this.</span></span>

<span data-ttu-id="a94d0-109">まず、コントロールを直接 WPF または Windows フォーム プロジェクトのデザイン サーフェイスに追加し、それをデザイナーの他のコントロールと同様に使用することができます。</span><span class="sxs-lookup"><span data-stu-id="a94d0-109">First, you can add controls directly to the design surface of your WPF or Windows Forms project, and then use them like any other control in your designer.</span></span>  <span data-ttu-id="a94d0-110">新しい **WebView** コントロールで今すぐこれをお試しください。</span><span class="sxs-lookup"><span data-stu-id="a94d0-110">Try this out today with the new **WebView** control.</span></span> <span data-ttu-id="a94d0-111">このコントロールは、Microsoft Edge レンダリング エンジンを使用しています。また、これまで、このコントロールは UWP アプリケーションでのみ利用可能でした。</span><span class="sxs-lookup"><span data-stu-id="a94d0-111">This control uses the Microsoft Edge rendering engine, and until now, this control was available only to UWP applications.</span></span> <span data-ttu-id="a94d0-112">[Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/) の最新リリースで **WebView** を参照できます。</span><span class="sxs-lookup"><span data-stu-id="a94d0-112">You can find the **WebView** in the latest release of the [Windows Community Toolkit](https://docs.microsoft.com/windows/uwpcommunitytoolkit/).</span></span>

<span data-ttu-id="a94d0-113">間もなく、Fluent Design のその他の機能にアクセスできます。さまざまな UWP コントロールをホストできるコントロールを提供する予定です。</span><span class="sxs-lookup"><span data-stu-id="a94d0-113">Soon, you'll have access to even more Fluent Design features: we'll be providing a control that lets you host a variety of UWP controls.</span></span> <span data-ttu-id="a94d0-114">Windows コミュニティ ツールキットの今後のリリースでこのコントロールとその他の多くのコントロールを確認してください。</span><span class="sxs-lookup"><span data-stu-id="a94d0-114">Look for this control and many other controls in future releases of the Windows Community Toolkit.</span></span>

<span data-ttu-id="a94d0-115">これらのコントロールがアーキテクチャ的に編成されるしくみの概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a94d0-115">Here's a quick look at how these controls are organized architecturally.</span></span> <span data-ttu-id="a94d0-116">この図で使用される名前は変更されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a94d0-116">The names used in this diagram are subject to change.</span></span>  

![ホスト コントロール アーキテクチャ](images/host-controls.png)

<span data-ttu-id="a94d0-118">この図の下部に表示されている API は、Windows SDK に付属しています。</span><span class="sxs-lookup"><span data-stu-id="a94d0-118">The APIs that appear at the bottom of this diagram ship with the Windows SDK.</span></span>  <span data-ttu-id="a94d0-119">デザイナーに追加するコントロールは、Windows コミュニティ ツールキットで Nuget パッケージとしてリリースされます。</span><span class="sxs-lookup"><span data-stu-id="a94d0-119">The controls that you'll add to your designer ship as Nuget packages in the Windows Community Toolkit.</span></span>

<span data-ttu-id="a94d0-120">これらの新しいコントロールには制限事項があるため、それらを使用する前に、まだサポートされていない機能、また回避策を使用してのみ動作する機能を少し時間を取って確認してください。</span><span class="sxs-lookup"><span data-stu-id="a94d0-120">These new controls have limitations so before you use them, please take a moment to review what's not yet supported, and what's functional only with workarounds.</span></span>

### <a name="whats-supported"></a><span data-ttu-id="a94d0-121">サポートされている内容</span><span class="sxs-lookup"><span data-stu-id="a94d0-121">What's supported</span></span>

<span data-ttu-id="a94d0-122">ほとんどの場合、次の一覧で明示されていない限り、すべてがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="a94d0-122">For the most part, everything is supported unless explicitly called out in the list below.</span></span>

### <a name="whats-supported-only-with-workarounds"></a><span data-ttu-id="a94d0-123">回避策を使用した場合にのみサポートされている内容</span><span class="sxs-lookup"><span data-stu-id="a94d0-123">What's supported only with workarounds</span></span>

<span data-ttu-id="a94d0-124">:heavy_check_mark: 複数のウィンドウの内部での複数のインボックス コントロールのホスティング。</span><span class="sxs-lookup"><span data-stu-id="a94d0-124">:heavy_check_mark: Hosting multiple inbox controls inside of multiple windows.</span></span> <span data-ttu-id="a94d0-125">独自のスレッドに各ウィンドウを配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a94d0-125">You'll have to place each window in its own thread.</span></span>

<span data-ttu-id="a94d0-126">:heavy_check_mark: ホストされたコントロールでの ``x:Bind`` の使用。</span><span class="sxs-lookup"><span data-stu-id="a94d0-126">:heavy_check_mark: Using ``x:Bind`` with hosted controls.</span></span> <span data-ttu-id="a94d0-127">.NET Standard ライブラリ内でデータ モデルを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a94d0-127">You'll have to declare the data model in a .NET Standard library.</span></span>

<span data-ttu-id="a94d0-128">:heavy_check_mark: C# ベースのサードパーティのコントロール。</span><span class="sxs-lookup"><span data-stu-id="a94d0-128">:heavy_check_mark: C#-based third-party controls.</span></span> <span data-ttu-id="a94d0-129">サードパーティのコントロールへのソース コードがある場合は、それに対してコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="a94d0-129">If you have the source code to a third-party control, you can compile against it.</span></span>

### <a name="whats-not-yet-supported"></a><span data-ttu-id="a94d0-130">まだサポートされていない内容</span><span class="sxs-lookup"><span data-stu-id="a94d0-130">What's not yet supported</span></span>

<span data-ttu-id="a94d0-131">:no_entry_sign: アプリケーションおよびホストされたコントロールでシームレスに動作するアクセシビリティ ツール。</span><span class="sxs-lookup"><span data-stu-id="a94d0-131">:no_entry_sign: Accessibility tools that work seamlessly across the application and hosted controls.</span></span>

<span data-ttu-id="a94d0-132">:no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーションに追加するコントロール内のローカライズされたコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="a94d0-132">:no_entry_sign: Localized content in controls that you add to applications which don't contain a Windows app package.</span></span>

<span data-ttu-id="a94d0-133">: no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーション内で XAML で行われたアセット参照。</span><span class="sxs-lookup"><span data-stu-id="a94d0-133">:no_entry_sign: Asset references made in XAML within applications that don't contain a Windows app package.</span></span>

<span data-ttu-id="a94d0-134">:no_entry_sign:  DPI と倍率の変更に適切に対応するコントロール。</span><span class="sxs-lookup"><span data-stu-id="a94d0-134">:no_entry_sign: Controls properly responding to changes in DPI and scale.</span></span>

<span data-ttu-id="a94d0-135">:no_entry_sign: カスタム ユーザー コントロールへの **WebView** コントロールの追加 (スレッド上、オフ スレッド、proc 外のいずれか)</span><span class="sxs-lookup"><span data-stu-id="a94d0-135">:no_entry_sign: Adding a **WebView** control to a custom user control, (Either on-thread, off-thread, or out of proc).</span></span>

<span data-ttu-id="a94d0-136">:no_entry_sign: [表示ハイライト](https://docs.microsoft.com/windows/uwp/design/style/reveal)  の Fluent 効果。</span><span class="sxs-lookup"><span data-stu-id="a94d0-136">:no_entry_sign: The [Reveal highlight](https://docs.microsoft.com/windows/uwp/design/style/reveal) Fluent effect.</span></span>

<span data-ttu-id="a94d0-137">:no_entry_sign: 入力コントロールのためのインライン インク、@Places
、@People。</span><span class="sxs-lookup"><span data-stu-id="a94d0-137">:no_entry_sign: Inline inking, @Places, and @People for input controls.</span></span>

<span data-ttu-id="a94d0-138">:no_entry_sign: ショートカット キーの割り当て。</span><span class="sxs-lookup"><span data-stu-id="a94d0-138">:no_entry_sign: Assigning accelerator keys.</span></span>

<span data-ttu-id="a94d0-139">:no_entry_sign: C++ ベースのサードパーティのコントロール。</span><span class="sxs-lookup"><span data-stu-id="a94d0-139">:no_entry_sign: C++-based third-party controls.</span></span>

<span data-ttu-id="a94d0-140">:no_entry_sign: カスタム ユーザー コントロールのホスティング。</span><span class="sxs-lookup"><span data-stu-id="a94d0-140">:no_entry_sign: Hosting custom user controls.</span></span>

<span data-ttu-id="a94d0-141">Fluent をデスクトップに導入するエクスペリエンスの向上を続けていくうえで、この一覧の項目は変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a94d0-141">The items in this list will likely change as we continue to improve the experience of bringing Fluent to the desktop.</span></span>  
