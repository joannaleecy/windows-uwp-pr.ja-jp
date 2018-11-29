---
Description: This article is an overview of the concepts and technologies related to accessibility scenarios for Universal Windows Platform (UWP) apps.
ms.assetid: AA053196-F331-4CBE-B032-4E9CBEAC699C
title: アクセシビリティの概要
label: Accessibility overview
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 50e6c68841440120b783713ef0a591e39a7c7eec
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7975660"
---
# <a name="accessibility-overview"></a><span data-ttu-id="ebf4d-103">アクセシビリティの概要</span><span class="sxs-lookup"><span data-stu-id="ebf4d-103">Accessibility overview</span></span>  




<span data-ttu-id="ebf4d-104">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリのアクセシビリティ シナリオに関連する概念とテクノロジの概要を示します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-104">This article is an overview of the concepts and technologies related to accessibility scenarios for Universal Windows Platform (UWP) apps.</span></span>

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Developing-Apps-for-Accessibility/player]

<span id="Accessibility_and_your_app"/>
<span id="accessibility_and_your_app"/>
<span id="ACCESSIBILITY_AND_YOUR_APP"/>

## <a name="accessibility-and-your-app"></a><span data-ttu-id="ebf4d-105">アクセシビリティとアプリ</span><span class="sxs-lookup"><span data-stu-id="ebf4d-105">Accessibility and your app</span></span>  
<span data-ttu-id="ebf4d-106">障碍には、運動障碍、視覚障碍、色覚障碍、聴覚障碍、言語障碍、認知障碍、学習障碍など、さまざまな種類がありますが、</span><span class="sxs-lookup"><span data-stu-id="ebf4d-106">There are many possible disabilities or impairments, including limitations in mobility, vision, color perception, hearing, speech, cognition, and literacy.</span></span> <span data-ttu-id="ebf4d-107">ここで紹介するガイドラインに従うことで、そのほとんどの要件に対処できます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-107">However, you can address most requirements by following the guidelines offered here.</span></span> <span data-ttu-id="ebf4d-108">具体的には、次のものを提供します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-108">This means providing:</span></span>

* <span data-ttu-id="ebf4d-109">キーボード操作とスクリーン リーダーのサポート</span><span class="sxs-lookup"><span data-stu-id="ebf4d-109">Support for keyboard interactions and screen readers.</span></span>
* <span data-ttu-id="ebf4d-110">フォント、ズーム設定 (拡大)、色、ハイ コントラスト設定など、ユーザーによるカスタマイズのサポート</span><span class="sxs-lookup"><span data-stu-id="ebf4d-110">Support for user customization, such as font, zoom setting (magnification), color, and high-contrast settings.</span></span>
* <span data-ttu-id="ebf4d-111">一部の UI の代わりに利用できる手段やそれを補う手段</span><span class="sxs-lookup"><span data-stu-id="ebf4d-111">Alternatives or supplements for parts of your UI.</span></span>

<span data-ttu-id="ebf4d-112">XAML 向けのコントロールには、キーボードのサポートと、スクリーン リーダーなどの支援技術のサポートが組み込まれています。これらのサポートでは、UWP アプリや HTML などの他の UI テクノロジが既にサポートされたアクセシビリティ フレームワークを利用します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-112">Controls for XAML provide built-in keyboard support and support for assistive technologies such as screen readers, which take advantage of accessibility frameworks that already support UWP apps, HTML, and other UI technologies.</span></span> <span data-ttu-id="ebf4d-113">この組み込みのサポートを使えば、基本的なアクセシビリティをサポートし、いくつかのプロパティを設定するだけでカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-113">This built-in support enables a basic level of accessibility that you can customize with very little work, by setting just a handful of properties.</span></span> <span data-ttu-id="ebf4d-114">また、独自のカスタム XAML コンポーネントやコントロールを作成している場合は、*オートメーション ピア*の概念を使って、同様のサポートをそれらのコントロールに追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-114">If you are creating your own custom XAML components and controls, you can also add similar support to those controls by using the concept of an *automation peer*.</span></span>

<span data-ttu-id="ebf4d-115">さらに、データ バインディング、スタイル、テンプレートなどの機能を使うと、表示設定や代替 UI のテキストの動的な変更に簡単に対応できます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-115">In addition, data binding, style, and template features make it easy to implement support for dynamic changes to display settings and text for alternative UIs.</span></span>

<span id="UI_Automation"/>
<span id="ui_automation"/>
<span id="UI_AUTOMATION"/>

## <a name="ui-automation"></a><span data-ttu-id="ebf4d-116">UI オートメーション</span><span class="sxs-lookup"><span data-stu-id="ebf4d-116">UI Automation</span></span>  
<span data-ttu-id="ebf4d-117">アクセシビリティ サポートは主に、Microsoft UI オートメーション フレームワークの統合サポートに基づいています。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-117">Accessibility support comes primarily from the integrated support for the Microsoft UI Automation framework.</span></span> <span data-ttu-id="ebf4d-118">このようなサポートは、基底クラス、コントロール型に対するクラス実装の組み込み動作、UI オートメーション プロバイダー API のインターフェイス表現を通じて提供されます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-118">That support is provided through base classes and the built-in behavior of the class implementation for control types, and an interface representation of the UI Automation provider API.</span></span> <span data-ttu-id="ebf4d-119">各コントロール クラスは、UI オートメーションの概念であるオートメーション ピアとオートメーション パターンを使って、コントロールの役割とコンテンツを UI オートメーション クライアントに報告します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-119">Each control class uses the UI Automation concepts of automation peers and automation patterns that report the control's role and content to UI Automation clients.</span></span> <span data-ttu-id="ebf4d-120">アプリは、UI オートメーションではトップレベル ウィンドウとして扱われ、UI オートメーション フレームワークを通じて、そのアプリ ウィンドウ内のすべてのアクセシビリティ関連のコンテンツが UI オートメーション クライアントに利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-120">The app is treated as a top-level window by UI Automation, and through the UI Automation framework all the accessibility-relevant content within that app window is available to a UI Automation client.</span></span> <span data-ttu-id="ebf4d-121">UI オートメーションについて詳しくは、「[UI オートメーションの概要](https://msdn.microsoft.com/library/windows/desktop/Ee684076)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-121">For more info about UI Automation, see [UI Automation Overview](https://msdn.microsoft.com/library/windows/desktop/Ee684076).</span></span>

<span id="Assistive_technology"/>
<span id="assistive_technology"/>
<span id="ASSISTIVE_TECHNOLOGY"/>

## <a name="assistive-technology"></a><span data-ttu-id="ebf4d-122">支援技術</span><span class="sxs-lookup"><span data-stu-id="ebf4d-122">Assistive technology</span></span>  
<span data-ttu-id="ebf4d-123">ユーザーが必要とするアクセシビリティの多くは、ユーザーがインストールする支援技術製品や、オペレーティング システムで提供されるツールと設定によって実現されます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-123">Many user accessibility needs are met by assistive technology products installed by the user or by tools and settings provided by the operating system.</span></span> <span data-ttu-id="ebf4d-124">これには、スクリーン リーダー、画面拡大、ハイ コントラスト設定などの機能が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-124">This includes functionality such as screen readers, screen magnification, and high-contrast settings.</span></span>

<span data-ttu-id="ebf4d-125">支援技術製品には、さまざまなソフトウェアやハードウェアがあります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-125">Assistive technology products include a wide variety of software and hardware.</span></span> <span data-ttu-id="ebf4d-126">これらの製品は、標準のキーボード インターフェイスと、UI のコンテンツと構造に関する情報をスクリーン リーダーなどの支援技術に報告するアクセシビリティ フレームワークで機能します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-126">These products work through the standard keyboard interface and accessibility frameworks that report information about the content and structure of a UI to screen readers and other assistive technologies.</span></span> <span data-ttu-id="ebf4d-127">支援技術製品にはたとえば次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-127">Examples of assistive technology products include:</span></span>

* <span data-ttu-id="ebf4d-128">オンスクリーン キーボード。ユーザーはキーボードの代わりにポインターを使用してテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-128">The On-Screen Keyboard, which enables people to use a pointer in place of a keyboard to type text.</span></span>
* <span data-ttu-id="ebf4d-129">音声認識ソフトウェア。音声がテキストに変換されます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-129">Voice-recognition software, which converts spoken words into typed text.</span></span>
* <span data-ttu-id="ebf4d-130">スクリーン リーダー。テキストが音声、ブライユ点字などの形式に変換されます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-130">Screen readers, which convert text into spoken words or other forms such as Braille.</span></span>
* <span data-ttu-id="ebf4d-131">ナレーター スクリーン リーダー。Windows 特有の機能です。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-131">The Narrator screen reader, which is specifically part of Windows.</span></span> <span data-ttu-id="ebf4d-132">ナレーターには、利用可能なキーボードがない場合を想定して、タッチ ジェスチャを処理することで画面を読み込むことができるタッチ モードがあります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-132">Narrator has a touch mode, which can perform screen reading tasks by processing touch gestures, for when there is no keyboard available.</span></span>
* <span data-ttu-id="ebf4d-133">ディスプレイまたはディスプレイの領域を調整するプログラムまたは設定 (ハイ コントラスト テーマなど)、ディスプレイの DPI (1 インチあたりのドット数) の設定、拡大鏡ツール。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-133">Programs or settings that adjust the display or areas of it, for example high contrast themes, dots per inch (dpi) settings of the display, or the Magnifier tool.</span></span>

<span data-ttu-id="ebf4d-134">アプリのキーボードとスクリーン リーダーのサポートが十分なものであれば、通常は各種の支援技術製品で適切に動作します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-134">Apps that have good keyboard and screen reader support usually work well with various assistive technology products.</span></span> <span data-ttu-id="ebf4d-135">多くの場合、UWP アプリは、情報や構造の追加変更なしでそれらの製品と連携できます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-135">In many cases, a UWP app works with these products without additional modification of information or structure.</span></span> <span data-ttu-id="ebf4d-136">ただし、最適なアクセシビリティ エクスペリエンスのためにいくつか設定を変更したり、追加のサポートを実装する場合もあります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-136">However, you may want to modify some settings for optimal accessibility experience or to implement additional support.</span></span>

<span data-ttu-id="ebf4d-137">支援技術による基本的なアクセシビリティのシナリオをテストするために使用できるオプションについては、「[アクセシビリティ テスト](accessibility-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-137">Some of the options that you can use for testing basic accessibility scenarios with assistive technologies are listed in [Accessibility testing](accessibility-testing.md).</span></span>

<span id="Screen_reader_support_and_basic_accessibility_information"/>
<span id="screen_reader_support_and_basic_accessibility_information"/>
<span id="SCREEN_READER_SUPPORT_AND_BASIC_ACCESSIBILITY_INFORMATION"/>

## <a name="screen-reader-support-and-basic-accessibility-information"></a><span data-ttu-id="ebf4d-138">スクリーン リーダーのサポートと基本的なアクセシビリティ情報</span><span class="sxs-lookup"><span data-stu-id="ebf4d-138">Screen reader support and basic accessibility information</span></span>  
<span data-ttu-id="ebf4d-139">スクリーン リーダーでは、音声やブライユ点字出力などの形式にレンダリングしてアプリのテキストを利用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-139">Screen readers provide access to the text in an app by rendering it in some other format, such as spoken language or Braille output.</span></span> <span data-ttu-id="ebf4d-140">スクリーン リーダーの実際の動作は、ソフトウェアやユーザーによるソフトウェアの構成によって異なります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-140">The exact behavior of a screen reader depends on the software and on the user's configuration of it.</span></span>

<span data-ttu-id="ebf4d-141">たとえば、一部のスクリーン リーダーでは、ユーザーが表示されているアプリを起動したり切り替えたりしたときに、アプリの UI 全体を読み取ります。この場合、ユーザーは、そのアプリへのナビゲーションを試みる前に利用可能な情報のコンテンツをすべて受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-141">For example, some screen readers read the entire app UI when the user starts or switches to the app being viewed, which enables the user to receive all of the available informational content before attempting to navigate it.</span></span> <span data-ttu-id="ebf4d-142">また、タブ ナビゲーションで各コントロールにフォーカスが移ったときに、そのコントロールに関連付けられたテキストを読み取るスクリーン リーダーもあります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-142">Some screen readers also read the text associated with an individual control when it receives focus during tab navigation.</span></span> <span data-ttu-id="ebf4d-143">この場合、ユーザーは、現在の位置を確認しながらアプリの入力コントロール間を移動することができます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-143">This enables users to orient themselves as they navigate among the input controls of an application.</span></span> <span data-ttu-id="ebf4d-144">ナレーターは、ユーザーの選択に応じて両方の動作を提供するスクリーン リーダーの一例です。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-144">Narrator is an example of a screen reader that provides both behaviors, depending on user choice.</span></span>

<span data-ttu-id="ebf4d-145">スクリーン リーダーなどの支援技術において、ユーザーがアプリを理解またはナビゲートするのに役立つ最も重要な情報となるのが、アプリの要素パーツに対する*アクセシビリティ対応の名前*です。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-145">The most important information that a screen reader or any other assistive technology needs in order to help users understand or navigate an app is an *accessible name* for the element parts of the app.</span></span> <span data-ttu-id="ebf4d-146">多くの場合、コントロールや要素には、別途指定した他のプロパティ値から計算されるアクセシビリティ対応の名前が既に設定されています。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-146">In many cases, a control or element already has an accessible name that is calculated from other property values that you have otherwise provided.</span></span> <span data-ttu-id="ebf4d-147">既に計算された名前を使うことができる最も一般的な例は、内部テキストのサポートと表示を行う要素です。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-147">The most common case in which you can use an already-calculated name is with an element that supports and displays inner text.</span></span> <span data-ttu-id="ebf4d-148">他の要素では、要素構造のベスト プラクティスに従って、アクセシビリティ対応の名前を他の方法で指定することが必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-148">For other elements, you sometimes need to account for other ways to provide an accessible name by following best practices for element structure.</span></span> <span data-ttu-id="ebf4d-149">また、アプリをアクセシビリティ対応にするために、アクセシビリティ対応の名前として使うことを目的とした名前の指定が必要な場合もあります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-149">And sometimes you need to provide a name that is explicitly intended as the accessible name for app accessibility.</span></span> <span data-ttu-id="ebf4d-150">一般的な UI 要素で使うことができるこれらの計算値の一覧や、一般的なアクセシビリティ対応の名前について詳しくは、「[基本的なアクセシビリティ情報](basic-accessibility-information.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-150">For a listing of how many of these calculated values work in common UI elements, and for more info about accessible names in general, see [Basic accessibility information](basic-accessibility-information.md).</span></span>

<span data-ttu-id="ebf4d-151">オートメーションのプロパティは、他にも利用可能なものがいくつかあります (次のセクションで説明するキーボードのプロパティなど)。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-151">There are several other automation properties available (including the keyboard properties described in the next section).</span></span> <span data-ttu-id="ebf4d-152">ただし、すべてのスクリーン リーダーですべてのオートメーションのプロパティがサポートされるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-152">However, not all screen readers support all automation properties.</span></span> <span data-ttu-id="ebf4d-153">一般に、該当するオートメーションのプロパティについてはすべて設定して、できるだけ多くのスクリーン リーダーに対応するようにテストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-153">In general, you should set all appropriate automation properties and test to provide the widest possible support for screen readers.</span></span>

<span id="Keyboard_support"/>
<span id="keyboard_support"/>
<span id="KEYBOARD_SUPPORT"/>

## <a name="keyboard-support"></a><span data-ttu-id="ebf4d-154">キーボードのサポート</span><span class="sxs-lookup"><span data-stu-id="ebf4d-154">Keyboard support</span></span>  
<span data-ttu-id="ebf4d-155">キーボードのサポートを十分なものにするには、アプリのすべての部分をキーボードで操作できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-155">To provide good keyboard support, you must ensure that every part of your application can be used with a keyboard.</span></span> <span data-ttu-id="ebf4d-156">アプリで使うコントロールのほとんどが標準のコントロールであり、カスタム コントロールを使っていない場合は、ほぼこれを実現できていると言えます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-156">If your app uses mostly the standard controls and doesn't use any custom controls, you are most of the way there already.</span></span> <span data-ttu-id="ebf4d-157">基本的な XAML コントロール モデルには、タブ ナビゲーション、テキスト入力、コントロール固有のサポートなど、キーボードのサポートが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-157">The basic XAML control model provides built-in keyboard support including tab navigation, text input, and control-specific support.</span></span> <span data-ttu-id="ebf4d-158">レイアウト コンテナー (パネルなど) として機能する要素では、レイアウトの順序を使って、既定のタブの順序を設定します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-158">The elements that serve as layout containers (such as panels) use the layout order to establish a default tab order.</span></span> <span data-ttu-id="ebf4d-159">この順序は通常、UI をアクセシビリティ対応で表示するのに適したタブの順序です。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-159">That order is often the correct tab order to use for an accessible representation of the UI.</span></span> <span data-ttu-id="ebf4d-160">データの表示に使う [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) コントロールと [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) コントロールには、方向キーのナビゲーションが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-160">If you use [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) and [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) controls to display data, they provide built-in arrow-key navigation.</span></span> <span data-ttu-id="ebf4d-161">また、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) コントロールを使う場合は、Space キーまたは Enter キーが自動で処理されてボタンがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-161">Or if you use a [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) control, it already handles the Spacebar or Enter keys for button activation.</span></span>

<span data-ttu-id="ebf4d-162">タブの順序やキー ベースのアクティブ化、ナビゲーションなど、キーボードのサポートのあらゆる側面について詳しくは、「[キーボードのアクセシビリティ](keyboard-accessibility.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-162">For more info about all the aspects of keyboard support, including tab order and key-based activation or navigation, see [Keyboard accessibility](keyboard-accessibility.md).</span></span>

<span id="Media_and_captioning"/>
<span id="media_and_captioning"/>
<span id="MEDIA_AND_CAPTIONING"/>

## <a name="media-and-captioning"></a><span data-ttu-id="ebf4d-163">メディアと字幕</span><span class="sxs-lookup"><span data-stu-id="ebf4d-163">Media and captioning</span></span>  
<span data-ttu-id="ebf4d-164">通常、オーディオビジュアル メディアを表示するには、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/BR242926) オブジェクトを使います。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-164">You typically display audiovisual media through a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/BR242926) object.</span></span> <span data-ttu-id="ebf4d-165">**MediaElement** API を使うとメディアの再生を制御できます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-165">You can use **MediaElement** APIs to control the media playback.</span></span> <span data-ttu-id="ebf4d-166">アクセシビリティ対応にするには、ユーザーが必要に応じてメディアを再生、一時停止、停止できるコントロールを用意します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-166">For accessibility purposes, provide controls that enable users to play, pause, and stop the media as needed.</span></span> <span data-ttu-id="ebf4d-167">メディアには、キャプションや、ナレーションによる説明が含まれている別のオーディオ トラックなど、アクセシビリティ用の追加コンポーネントが含まれている場合があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-167">Sometimes, media includes additional components that are intended for accessibility, such as captioning or alternative audio tracks that include narrative descriptions.</span></span>

<span id="Accessible_text"/>
<span id="accessible_text"/>
<span id="ACCESSIBLE_TEXT"/>

## <a name="accessible-text"></a><span data-ttu-id="ebf4d-168">アクセシビリティに対応したテキスト</span><span class="sxs-lookup"><span data-stu-id="ebf4d-168">Accessible text</span></span>  
<span data-ttu-id="ebf4d-169">テキストの次の 3 つの主な側面がアクセシビリティに関連しています。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-169">Three main aspects of text are relevant to accessibility:</span></span>

* <span data-ttu-id="ebf4d-170">ツールでは、テキストをタブ順のトラバーサルの一部として読み取るか、ドキュメント全体の表示の一部として読み取るかどうかを決める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-170">Tools must determine whether the text is to be read as part of a tab-sequence traversal or only as part of an overall document representation.</span></span> <span data-ttu-id="ebf4d-171">テキストの表示に適した要素を選ぶか、これらのテキスト要素のプロパティを調整することで、この決定の制御に役立てることができます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-171">You can help control this determination by choosing the appropriate element for displaying the text or by adjusting properties of those text elements.</span></span> <span data-ttu-id="ebf4d-172">各テキスト要素には、固有の目的があり、その目的には通常、対応する UI オートメーションの役割があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-172">Each text element has a specific purpose, and that purpose often has a corresponding UI Automation role.</span></span> <span data-ttu-id="ebf4d-173">不適切な要素を使うと、誤った役割が UI オートメーションに報告され、支援技術を使うユーザーの混乱を招くことになります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-173">Using the wrong element can result in reporting the wrong role to UI Automation and creating a confusing experience for an assistive technology user.</span></span>
* <span data-ttu-id="ebf4d-174">視覚に障碍があり、背景に対するコントラストが適切でないとテキストを読み取ることが困難なユーザーが多数います。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-174">Many users have sight limitations that make it difficult for them to read text unless it has adequate contrast against the background.</span></span> <span data-ttu-id="ebf4d-175">視覚に障碍がないアプリの開発者には、こうしたユーザーが受ける影響は直感的には理解できません。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-175">How this impacts the user is not intuitive for app designers who do not have that sight limitation.</span></span> <span data-ttu-id="ebf4d-176">たとえば、色覚に障碍がある場合、設計で不適切な色を選ぶと、テキストを読むことができないユーザーもいます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-176">For example, for color-blind users, poor color choices in the design can prevent some users from being able to read the text.</span></span> <span data-ttu-id="ebf4d-177">当初は Web コンテンツ用に作成された、アクセシビリティに関する推奨事項には、これらの問題をアプリで回避するためのコントラストの基準も定義されています。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-177">Accessibility recommendations that were originally made for web content define standards for contrast that can avoid these problems in apps as well.</span></span> <span data-ttu-id="ebf4d-178">詳しくは、「[アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-178">For more info, see [Accessible text requirements](accessible-text-requirements.md).</span></span>
* <span data-ttu-id="ebf4d-179">テキストが単に小さすぎるために読むことが難しい場合もよくあります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-179">Many users have difficulty reading text that is simply too small.</span></span> <span data-ttu-id="ebf4d-180">この問題は、アプリの UI のテキストを最初から適切な大きさにすることで防止できます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-180">You can prevent this issue by making the text in your app's UI reasonably large in the first place.</span></span> <span data-ttu-id="ebf4d-181">ただし、大量のテキストを表示するアプリや、テキストと他の視覚要素が混在するアプリでは、こうした変更が難しい場合があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-181">However, that's challenging for apps that display large quantities of text, or text interspersed with other visual elements.</span></span> <span data-ttu-id="ebf4d-182">このような場合は、ディスプレイを拡大できるシステム機能とアプリが正しくやり取りできるようにすることで、アプリ内のテキストも拡大します </span><span class="sxs-lookup"><span data-stu-id="ebf4d-182">In such cases, make sure that the app correctly interacts with the system features that can scale up the display, so that any text in apps scales up along with it.</span></span> <span data-ttu-id="ebf4d-183">(一部のユーザーはアクセシビリティのオプションとして DPI の値を変更します。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-183">(Some users change dpi values as an accessibility option.</span></span> <span data-ttu-id="ebf4d-184">このオプションは、**[コンピューターの簡単操作]** の **[画面上の項目を拡大します]** から利用できます。この操作は、**コントロール パネル**の UI の **[デスクトップのカスタマイズ]** / **[ディスプレイ]** にリダイレクトされます)。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-184">That option is available from **Make things on the screen larger** in **Ease of Access**, which redirects to a **Control Panel** UI for **Appearance and Personalization** / **Display**.)</span></span>

<span id="Supporting_high-contrast_themes"/>
<span id="supporting_high-contrast_themes"/>
<span id="SUPPORTING_HIGH-CONTRAST_THEMES"/>

## <a name="supporting-high-contrast-themes"></a><span data-ttu-id="ebf4d-185">ハイ コントラスト テーマのサポート</span><span class="sxs-lookup"><span data-stu-id="ebf4d-185">Supporting high-contrast themes</span></span>  
<span data-ttu-id="ebf4d-186">UI コントロールでは、テーマの XAML リソース ディクショナリの一部として定義されている視覚的な表示を使います。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-186">UI controls use a visual representation that is defined as part of a XAML resource dictionary of themes.</span></span> <span data-ttu-id="ebf4d-187">これらのテーマのうちの 1 つ以上は、システムがハイ コントラストに設定されている場合に使われます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-187">One or more of these themes is specifically used when the system is set for high contrast.</span></span> <span data-ttu-id="ebf4d-188">ユーザーが、リソース ディクショナリの適切なテーマを動的に参照してハイ コントラストに切り替えると、すべての UI コントロールも適切なハイ コントラスト テーマを使います。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-188">When the user switches to high contrast, by looking up the appropriate theme from a resource dictionary dynamically, all your UI controls will use an appropriate high-contrast theme too.</span></span> <span data-ttu-id="ebf4d-189">明示的なスタイルの指定により、またはハイ コントラスト テーマが読み込まれてスタイルの変更をオーバーライドするのを防ぐ、別のスタイル指定方法を使うことにより、これらのテーマを無効にすることがないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-189">Just make sure that you haven't disabled the themes by specifying an explicit style or using another styling technique that prevents the high-contrast themes from loading and overriding your style changes.</span></span> <span data-ttu-id="ebf4d-190">詳しくは、「[ハイ コントラスト テーマ](high-contrast-themes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-190">For more info, see [High-contrast themes](high-contrast-themes.md).</span></span>

<span id="Design_for_alternative_UI"/>
<span id="design_for_alternative_ui"/>
<span id="DESIGN_FOR_ALTERNATIVE_UI"/>

## <a name="design-for-alternative-ui"></a><span data-ttu-id="ebf4d-191">別の UI を設計する</span><span class="sxs-lookup"><span data-stu-id="ebf4d-191">Design for alternative UI</span></span>  
<span data-ttu-id="ebf4d-192">アプリを設計するときは、運動障碍、視覚障碍、聴覚障碍を持つユーザーがどのようにして使うのか考えながら設計する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-192">When you design your apps, consider how they may be used by people with limited mobility, vision, and hearing.</span></span> <span data-ttu-id="ebf4d-193">支援技術製品は標準の UI を広く利用するため、アクセシビリティについてそれ以外は調整しない場合でも、キーボードとスクリーン リーダーのサポートについては十分に調整することが特に重要です。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-193">Because assistive technology products make extensive use of standard UI, it is particularly important to provide good keyboard and screen-reader support even if you make no other adjustments for accessibility.</span></span>

<span data-ttu-id="ebf4d-194">多くの場合、幅広いユーザーが利用できるようにするために、重要な情報を複数の方法で伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-194">In many cases, you can convey essential information by using multiple techniques to widen your audience.</span></span> <span data-ttu-id="ebf4d-195">たとえば、アイコンと色の両方を使って情報を目立つようにすると、色覚に障碍があるユーザーが確認しやすくなります。また、効果音と一緒に視覚的な警告も表示すると、聴覚障碍があるユーザーに便利です。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-195">For example, you can highlight information using both icon and color information to help users who are color blind, and you can display visual alerts along with sound effects to help users who are hearing impaired.</span></span>

<span data-ttu-id="ebf4d-196">必要に応じて、不要な要素やアニメーションがまったくないアクセシビリティ対応のユーザー インターフェイス要素を代わりに使えるようにしたり、ユーザー操作が効率的になるように簡略化したりできます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-196">If necessary, you can provide alternative, accessible user interface elements that completely remove nonessential elements and animations, and provide other simplifications to streamline the user experience.</span></span> <span data-ttu-id="ebf4d-197">次のコード例は、1 つの [**UserControl**](https://msdn.microsoft.com/library/windows/apps/BR227647) インスタンスを表示して、ユーザー設定に応じて UserControl の別のインスタンスを表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-197">The following code example demonstrates how to display one [**UserControl**](https://msdn.microsoft.com/library/windows/apps/BR227647) instance in place of another depending on a user setting.</span></span>

<span data-ttu-id="ebf4d-198">XAML</span><span class="sxs-lookup"><span data-stu-id="ebf4d-198">XAML</span></span>
```xml
<StackPanel x:Name="LayoutRoot" Background="White">

  <CheckBox x:Name="ShowAccessibleUICheckBox" Click="ShowAccessibleUICheckBox_Click">
    Show Accessible UI
  </CheckBox>

  <UserControl x:Name="ContentBlock">
    <local:ContentPage/>
  </UserControl>

</StackPanel>
```

<span data-ttu-id="ebf4d-199">Visual Basic</span><span class="sxs-lookup"><span data-stu-id="ebf4d-199">Visual Basic</span></span>
```vb
Private Sub ShowAccessibleUICheckBox_Click(ByVal sender As Object,
    ByVal e As RoutedEventArgs)

    If (ShowAccessibleUICheckBox.IsChecked.Value) Then
        ContentBlock.Content = New AccessibleContentPage()
    Else
        ContentBlock.Content = New ContentPage()
    End If
End Sub
```

<span data-ttu-id="ebf4d-200">C#</span><span class="sxs-lookup"><span data-stu-id="ebf4d-200">C#</span></span>
```csharp
private void ShowAccessibleUICheckBox_Click(object sender, RoutedEventArgs e)
{
    if ((sender as CheckBox).IsChecked.Value)
    {
        ContentBlock.Content = new AccessibleContentPage();
    }
    else
    {
        ContentBlock.Content = new ContentPage();
    }
}
```

<span id="Verification_and_publishing"/>
<span id="verification_and_publishing"/>
<span id="VERIFICATION_AND_PUBLISHING"/>

## <a name="verification-and-publishing"></a><span data-ttu-id="ebf4d-201">検証と公開</span><span class="sxs-lookup"><span data-stu-id="ebf4d-201">Verification and publishing</span></span>  
<span data-ttu-id="ebf4d-202">アクセシビリティ対応と宣言してアプリを公開する方法については、「[ストア内のアクセシビリティ](accessibility-in-the-store.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-202">For more info about accessibility declarations and publishing your app, see [Accessibility in the Store](accessibility-in-the-store.md).</span></span>

> [!NOTE]
> <span data-ttu-id="ebf4d-203">アプリをアクセシビリティ対応として宣言する方法は、Microsoft Store にのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-203">Declaring the app as accessible is only relevant to the Microsoft Store.</span></span>

<span id="Assistive_technology_support_in_custom_controls"/>
<span id="assistive_technology_support_in_custom_controls"/>
<span id="ASSISTIVE_TECHNOLOGY_SUPPORT_IN_CUSTOM_CONTROLS"/>

## <a name="assistive-technology-support-in-custom-controls"></a><span data-ttu-id="ebf4d-204">カスタム コントロールでの支援技術のサポート</span><span class="sxs-lookup"><span data-stu-id="ebf4d-204">Assistive technology support in custom controls</span></span>  
<span data-ttu-id="ebf4d-205">カスタム コントロールを作るときは、1 つ以上の [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) サブクラスを実装または拡張してアクセシビリティをサポートすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-205">When you create a custom control, we recommend that you also implement or extend one or more [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) subclasses to provide accessibility support.</span></span> <span data-ttu-id="ebf4d-206">基本コントロール クラスで使われていたのと同じピア クラスを使う場合は、派生クラスのオートメーション サポートは基本レベルで十分ですが、</span><span class="sxs-lookup"><span data-stu-id="ebf4d-206">In some cases, so long as you use the same peer class as was used by the base control class, the automation support for your derived class is adequate at a basic level.</span></span> <span data-ttu-id="ebf4d-207">そのことをテストする必要があります。また、そのような場合でも、新しいコントロール クラスのクラス名を正しく報告できるように、ピアを実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-207">However, you should test this, and implementing a peer is still recommended as a best practice so that the peer can correctly report the class name of your new control class.</span></span> <span data-ttu-id="ebf4d-208">カスタム オートメーション ピアを実装するにはいくつかの手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-208">Implementing a custom automation peer has a few steps involved.</span></span> <span data-ttu-id="ebf4d-209">詳しくは、「[カスタム オートメーション ピア](custom-automation-peers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-209">For more info, see [Custom automation peers](custom-automation-peers.md).</span></span>

<span id="Assistive_technology_support_in_apps_that_support_XAML___Microsoft_DirectX_interop"/>
<span id="assistive_technology_support_in_apps_that_support_xaml___microsoft_directx_interop"/>
<span id="ASSISTIVE_TECHNOLOGY_SUPPORT_IN_APPS_THAT_SUPPORT_XAML___MICROSOFT_DIRECTX_INTEROP"/>

## <a name="assistive-technology-support-in-apps-that-support-xaml--microsoft-directx-interop"></a><span data-ttu-id="ebf4d-210">XAML/Microsoft DirectX の相互運用機能をサポートするアプリでの支援技術のサポート</span><span class="sxs-lookup"><span data-stu-id="ebf4d-210">Assistive technology support in apps that support XAML / Microsoft DirectX interop</span></span>  
<span data-ttu-id="ebf4d-211">([**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/Dn252834) または [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/Hh702041) を使って) XAML UI にホストされる Microsoft DirectX コンテンツには、既定ではアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-211">Microsoft DirectX content that's hosted in a XAML UI (using [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/Dn252834) or [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/Hh702041)) is not accessible by default.</span></span> <span data-ttu-id="ebf4d-212">ホストされた DirectX コンテンツの UI オートメーション ピアを作成する方法は、[XAML SwapChainPanel DirectX 相互運用性のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=309155) で確認できます。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-212">The [XAML SwapChainPanel DirectX interop sample](http://go.microsoft.com/fwlink/p/?LinkID=309155) shows how to create UI Automation peers for the hosted DirectX content.</span></span> <span data-ttu-id="ebf4d-213">この手法を利用すると、ホストされたコンテンツに UI オートメーションを通じてアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="ebf4d-213">This technique makes the hosted content accessible through UI Automation.</span></span>

## <a name="related-topics"></a><span data-ttu-id="ebf4d-214">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ebf4d-214">Related topics</span></span>  
* [**<span data-ttu-id="ebf4d-215">Windows.UI.Xaml.Automation</span><span class="sxs-lookup"><span data-stu-id="ebf4d-215">Windows.UI.Xaml.Automation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR209179)
* [<span data-ttu-id="ebf4d-216">アクセシビリティのための設計</span><span class="sxs-lookup"><span data-stu-id="ebf4d-216">Design for accessibility</span></span>](https://msdn.microsoft.com/library/windows/apps/Hh700407)
* [<span data-ttu-id="ebf4d-217">XAML アクセシビリティ サンプル</span><span class="sxs-lookup"><span data-stu-id="ebf4d-217">XAML accessibility sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [<span data-ttu-id="ebf4d-218">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="ebf4d-218">Accessibility</span></span>](accessibility.md)
* [<span data-ttu-id="ebf4d-219">ナレーターの概要</span><span class="sxs-lookup"><span data-stu-id="ebf4d-219">Get started with Narrator</span></span>](https://support.microsoft.com/help/22798/windows-10-narrator-get-started)
