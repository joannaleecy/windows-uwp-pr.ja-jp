---
author: Karl-Bridge-Microsoft
Description: Incorporate speech into your apps using Cortana voice commands, speech recognition, and speech synthesis.
title: Surface Dial の操作
label: Surface Dial interactions
template: detail.hbs
keywords: Surface Dial, Windows ホイール, RadialController, ラジアル コントローラー, ユーザーの操作, 入力
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.assetid: e7deb1d6-feeb-471e-9a83-26386d1aaf37
ms.localizationpriority: medium
ms.openlocfilehash: 0a360bf936843450f5646c0e4e03ad9c3bac34d2
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6840814"
---
# <a name="surface-dial-interactions"></a><span data-ttu-id="85b60-103">Surface Dial の操作</span><span class="sxs-lookup"><span data-stu-id="85b60-103">Surface Dial interactions</span></span>

![Surface Dial と Surface Studio の画像](images/windows-wheel/dial-pen-studio-600px.png)  
<span data-ttu-id="85b60-105">*Surface Dial と Surface Studio、Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacedial)で購入できます)。</span><span class="sxs-lookup"><span data-stu-id="85b60-105">*Surface Dial with Surface Studio and Pen* (available for purchase at the [Microsoft Store](https://aka.ms/purchasesurfacedial)).</span></span>

## <a name="overview"></a><span data-ttu-id="85b60-106">概要</span><span class="sxs-lookup"><span data-stu-id="85b60-106">Overview</span></span>

<span data-ttu-id="85b60-107">Surface Dial などの Windows Wheel デバイスは、Windows や Windows アプリで魅力的でユニークなユーザー操作エクスペリエンスを実現する、新しいカテゴリの入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="85b60-107">Windows wheel devices, such as the Surface Dial, are a new category of input device that enable a host of compelling and unique user interaction experiences for Windows and Windows apps.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="85b60-108">このトピックでは、特に Surface Dial の操作について説明しますが、情報はすべての Windows Wheel デバイスに適用されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-108">In this topic, we refer specifically to Surface Dial interactions, but the info is applicable to all Windows wheel devices.</span></span> 

| <span data-ttu-id="85b60-109">ビデオ</span><span class="sxs-lookup"><span data-stu-id="85b60-109">Videos</span></span> |   |
| --- | --- |
| <iframe src="https://www.youtube-nocookie.com/embed/WMklcdzcNcU" width="300" height="200" allowFullScreen="true" frameBorder="0"></iframe> | <iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Programming-the-Microsoft-Surface-Dial/player" width="300" height="200" allowFullScreen="true" frameBorder="0"></iframe> |
| *<span data-ttu-id="85b60-110">Surface Dial のアプリ パートナー</span><span class="sxs-lookup"><span data-stu-id="85b60-110">Surface Dial app partners</span></span>* | *<span data-ttu-id="85b60-111">開発者向けの Surface Dial</span><span class="sxs-lookup"><span data-stu-id="85b60-111">Surface Dial for devs</span></span>* |

<span data-ttu-id="85b60-112">*回転*動作 (またはジェスチャ) に基づくフォームファクタを持つ Surface Dial は、プライマリ デバイスからの入力を補完または変更する、セカンダリのマルチ モーダル入力デバイスとして設計されています。</span><span class="sxs-lookup"><span data-stu-id="85b60-112">With a form factor based on a *rotate* action (or gesture), the Surface Dial is intended as a secondary, multi-modal input device that complements input from a primary device.</span></span> <span data-ttu-id="85b60-113">このデバイスは多くの場合、ユーザーが利き手でタスクを実行している間に (たとえばペンでインク操作をするときなど)、利き手ではない手で操作されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-113">In most cases, the device is manipulated by a user's non-dominant hand while performing a task with their dominant hand (such as inking with a pen).</span></span> <span data-ttu-id="85b60-114">高精度のポインター入力 (タッチ、ペン、マウスなど) 用に設計されていません。</span><span class="sxs-lookup"><span data-stu-id="85b60-114">It is not designed for precision pointer input (like touch, pen, or mouse).</span></span> 

<span data-ttu-id="85b60-115">Surface Dial は、*長押し*アクションと*クリック*アクションもサポートしています。</span><span class="sxs-lookup"><span data-stu-id="85b60-115">The Surface Dial also supports both a *press and hold* action and a *click* action.</span></span> <span data-ttu-id="85b60-116">長押しの機能は 1 つで、コマンドのメニューを表示します。</span><span class="sxs-lookup"><span data-stu-id="85b60-116">Press and hold has a single function: display a menu of commands.</span></span> <span data-ttu-id="85b60-117">メニューがアクティブになっている場合、回転とクリックの入力はメニューによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-117">If the menu is active, the rotate and click input is processed by the menu.</span></span> <span data-ttu-id="85b60-118">それ以外の場合、入力は、処理のためにアプリに渡されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-118">Otherwise, the input is passed to your app for processing.</span></span> 

**<span data-ttu-id="85b60-119">Windows の他の入力デバイスと同様に、アプリの機能に合わせて Surface Dial の操作エクスペリエンスをカスタマイズおよび調整できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-119">As with all Windows input devices, you can customize and tailor the Surface Dial interaction experience to suit the functionality in your apps.</span></span>**

> [!TIP]
> <span data-ttu-id="85b60-120">Surface Dial と新しい Surface Studio を一緒に使うことによって、さらに独創的なユーザー エクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-120">Used together, the Surface Dial and the new Surface Studio can provide an even more distinctive user experience.</span></span>  
>
><span data-ttu-id="85b60-121">先ほど説明した既定の長押しメニューのエクスペリエンスに加えて、Surface Dial は Surface Studio の画面上に直接配置できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-121">In addition to the default press and hold menu experience described, the Surface Dial can also be placed directly on the screen of the Surface Studio.</span></span> <span data-ttu-id="85b60-122">これにより、特殊な "オンスクリーン" メニューが実現されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-122">This enables a special "on-screen" menu.</span></span> 
>
><span data-ttu-id="85b60-123">Surface Dial の接触位置と境界の両方を検出することにより、システムはこの情報を使用してデバイスによるオクルージョンを処理し、Dial の外側を囲むように大きいバージョンのメニューを表示します。</span><span class="sxs-lookup"><span data-stu-id="85b60-123">By detecting both the contact location and bounds of the Surface Dial, the system uses this info to handle occlusion by the device and display a larger version of the menu that wraps around the outside of the Dial.</span></span> <span data-ttu-id="85b60-124">この同じ情報をアプリで使用して、デバイスの存在とその予想される使用状況 (ユーザーの手や腕の配置など) の両方に合わせて UI を調整することもできます。</span><span class="sxs-lookup"><span data-stu-id="85b60-124">This same info can also be used by your app to adapt the UI for both the presence of the device and its anticipated usage, such as the placement of the user's hand and arm.</span></span>

| <span data-ttu-id="85b60-125">Surface Dial のオフスクリーン メニュー</span><span class="sxs-lookup"><span data-stu-id="85b60-125">Surface Dial off-screen menu</span></span> | | <span data-ttu-id="85b60-126">Surface Dial のオンスクリーン メニュー</span><span class="sxs-lookup"><span data-stu-id="85b60-126">Surface Dial on-screen menu</span></span> |
| --- | --- | --- |
| ![Surface Dial のオフスクリーン メニュー](images/windows-wheel/surface-dial-menu-offscreen.png) | | ![Surface Dial のオンスクリーン メニュー](images/windows-wheel/surface-dial-menu-onscreen.png) |

## <a name="system-integration"></a><span data-ttu-id="85b60-129">システム統合</span><span class="sxs-lookup"><span data-stu-id="85b60-129">System integration</span></span>

<span data-ttu-id="85b60-130">Surface Dial は Windows と緊密に統合されており、システム ボリューム、スクロール、拡大/縮小、元に戻す/やり直しなど、一連の組み込みツールをメニューでサポートしています。</span><span class="sxs-lookup"><span data-stu-id="85b60-130">The Surface Dial is tightly integrated with Windows and supports a set of built-in tools on the menu: system volume, scroll, zoom in/out, and undo/redo.</span></span>

<span data-ttu-id="85b60-131">この組み込みツールのコレクションは、現在のシステム コンテキストに合わせて調整され、次のような機能が追加されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-131">This collection of built-in tools adapts to the current system context to include:</span></span>
- <span data-ttu-id="85b60-132">ユーザーが Windows デスクトップ システムで作業する場合のシステムの明るさツール</span><span class="sxs-lookup"><span data-stu-id="85b60-132">A system brightness tool when the user is on the Windows Desktop</span></span>
- <span data-ttu-id="85b60-133">メディアの再生中の前または次のトラック ツール</span><span class="sxs-lookup"><span data-stu-id="85b60-133">A previous/next track tool when media is playing</span></span>

<span data-ttu-id="85b60-134">この一般的なプラットフォームのサポートに加えて、Surface Dial は Windows Ink プラットフォームのコントロール ([**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) や [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar)) とも緊密に統合されています。</span><span class="sxs-lookup"><span data-stu-id="85b60-134">In addition to this general platform support, the Surface Dial is also tightly integrated with the Windows Ink platform controls ([**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) and [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar)).</span></span>

![Surface Dial と Surface ペン](images/windows-wheel/dial-and-pen-400px.png)  
*<span data-ttu-id="85b60-136">Surface Dial と Surface ペン</span><span class="sxs-lookup"><span data-stu-id="85b60-136">Surface Dial with Surface Pen</span></span>*

<span data-ttu-id="85b60-137">Surface Dial と共に使用する場合、これらのコントロールで、インクの属性を変更したり、インク ツールバーのルーラー ステンシルを制御したりするための追加の機能が有効になります。</span><span class="sxs-lookup"><span data-stu-id="85b60-137">When used with the Surface Dial, these controls enable additional functionality for modifying ink attributes and controlling the ink toolbar’s ruler stencil.</span></span>

<span data-ttu-id="85b60-138">インク ツール バーを使用している手描き入力アプリケーションで、Surface Dial メニューを開くと、ペンの種類とブラシの太さを制御するためのツールがメニューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-138">When you open the Surface Dial Menu in an inking application that uses the ink toolbar, the menu now includes tools for controlling pen type and brush thickness.</span></span> <span data-ttu-id="85b60-139">ルーラーが有効である場合、対応するツールがメニューに追加され、デバイスでルーラーの位置と角度を制御できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-139">When the ruler is enabled, a corresponding tool is added to the menu that lets the device control the position and angle of the ruler.</span></span>

![Surface Dial メニューと Windows Ink ツール バーのペン選択ツール](images/windows-wheel/surface-dial-menu-inktoolbar-pen.png)  
*<span data-ttu-id="85b60-141">Surface Dial メニューと Windows Ink ツール バーのペン選択ツール</span><span class="sxs-lookup"><span data-stu-id="85b60-141">Surface Dial menu with pen selection tool for the Windows Ink toolbar</span></span>*

![Surface Dial メニューと Windows Ink ツール バーのストローク サイズ ツール](images/windows-wheel/surface-dial-menu-inktoolbar-strokesize.png)  
*<span data-ttu-id="85b60-143">Surface Dial メニューと Windows Ink ツール バーのストローク サイズ ツール</span><span class="sxs-lookup"><span data-stu-id="85b60-143">Surface Dial menu with stroke size tool for the Windows Ink toolbar</span></span>*

![Surface Dial メニューと Windows Ink ツール バーのルーラー ツール](images/windows-wheel/surface-dial-menu-inktoolbar-ruler.png)  
*<span data-ttu-id="85b60-145">Surface Dial メニューと Windows Ink ツール バーのルーラー ツール</span><span class="sxs-lookup"><span data-stu-id="85b60-145">Surface Dial menu with ruler tool for the Windows Ink toolbar</span></span>*

## <a name="user-customization"></a><span data-ttu-id="85b60-146">ユーザーのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="85b60-146">User customization</span></span>

<span data-ttu-id="85b60-147">ユーザーは、既定のフォント、バイブレーション (または触覚フィードバック)、利き手など、Dial のエクスペリエンスの一部を、**[Windows の設定] -> [デバイス] -> [ホイール]** ページでカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="85b60-147">Users can customize some aspects of their Dial experience through the **Windows Settings -> Devices -> Wheel** page, including default tools, vibration (or haptic feedback), and writing (or dominant) hand.</span></span> 

<span data-ttu-id="85b60-148">Surface Dial ユーザー エクスペリエンスをカスタマイズする場合、特定の機能や動作が利用可能であり、ユーザーが有効にしていることを常に確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b60-148">When customizing the Surface Dial user experience, you should always ensure that a particular function or behavior is available and enabled by the user.</span></span>

## <a name="custom-tools"></a><span data-ttu-id="85b60-149">カスタム ツール</span><span class="sxs-lookup"><span data-stu-id="85b60-149">Custom tools</span></span>

<span data-ttu-id="85b60-150">ここでは、Surface Dial メニューで公開されるツールをカスタマイズするための UX と開発者の両方のガイダンスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="85b60-150">Here we discuss both UX and developer guidance for customizing the tools exposed on the Surface Dial menu.</span></span>

### <a name="ux-guidance"></a><span data-ttu-id="85b60-151">UX ガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-151">UX guidance</span></span>

<span data-ttu-id="85b60-152">**ツールを現在のコンテキストに確実に対応させる** ツールの目的や Surface Dial の操作方法を明確かつ直感的にしている場合、ユーザーは操作をすばやく習得し、作業に集中することができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-152">**Ensure your tools correspond to the current context** When you make it clear and intuitive what a tool does and how the Surface Dial interaction works, you help users learn quickly and stay focused on their task.</span></span>

**<span data-ttu-id="85b60-153">できるだけアプリ ツールの数を最小限に抑える</span><span class="sxs-lookup"><span data-stu-id="85b60-153">Minimize the number of app tools as much as possible</span></span>**  
<span data-ttu-id="85b60-154">Surface Dial メニューの領域には、7 つの項目を表示できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-154">The Surface Dial menu has room for seven items.</span></span> <span data-ttu-id="85b60-155">8 個以上の項目がある場合、ユーザーは Dial を回してオーバーフロー ポップアップで利用可能なツールを確認する必要があります。このため、メニューのナビゲーションが難しくなり、ツールを見つけて選択することも困難になります。</span><span class="sxs-lookup"><span data-stu-id="85b60-155">If there are eight or more items, the user needs to turn the Dial to see which tools are available in an overflow flyout, making the menu difficult to navigate and tools difficult to discover and select.</span></span>

<span data-ttu-id="85b60-156">アプリまたはアプリのコンテキストで、1 つのカスタム ツールを提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85b60-156">We recommend providing a single custom tool for your app or app context.</span></span> <span data-ttu-id="85b60-157">こうすることで、ユーザーが行っている作業に基づいてツールを設定することができ、ユーザーは Surface Dial メニューをアクティブ化してツールを選択する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="85b60-157">Doing so enables you to set that tool based on what the user is doing without requiring them to activate the Surface Dial menu and select a tool.</span></span> 

**<span data-ttu-id="85b60-158">ツールのコレクションを動的に更新する</span><span class="sxs-lookup"><span data-stu-id="85b60-158">Dynamically update the collection of tools</span></span>**  
<span data-ttu-id="85b60-159">Surface Dial メニュー項目は無効な状態をサポートしていないため、ユーザーのコンテキスト (現在のビューやフォーカスのあるウィンドウ) に基づいて、動的にツール (組み込みの既定のツールを含む) を追加および削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b60-159">Because Surface Dial menu items do not support a disabled state, you should dynamically add and remove tools (including built-in, default tools) based on user context (current view or focused window).</span></span> <span data-ttu-id="85b60-160">ツールが現在のアクティビティに関連していない場合や、重複している場合は、削除します。</span><span class="sxs-lookup"><span data-stu-id="85b60-160">If a tool is not relevant to the current activity or it’s redundant, remove it.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="85b60-161">メニューに項目を追加する場合は、その項目がまだ存在していないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="85b60-161">When you add an item to the menu, ensure the item does not already exist.</span></span>

**<span data-ttu-id="85b60-162">組み込みのシステム ボリューム設定ツールを削除しない</span><span class="sxs-lookup"><span data-stu-id="85b60-162">Don’t remove the built-in system volume setting tool</span></span>**  
<span data-ttu-id="85b60-163">通常、ユーザーは常にボリューム コントロールを必要とします。</span><span class="sxs-lookup"><span data-stu-id="85b60-163">Volume control is typically always required by user.</span></span> <span data-ttu-id="85b60-164">ユーザーは、アプリを使用しながら音楽を聴くことがあるため、ボリュームと次のトラック ツールは、常に、Surface Dial メニューからアクセスできる必要があります </span><span class="sxs-lookup"><span data-stu-id="85b60-164">They might be listening to music while using your app, so volume and next track tools should always be accessible from the Surface Dial menu.</span></span> <span data-ttu-id="85b60-165">(次のトラック ツールは、メディアの再生中に自動的にメニューに追加されます)。</span><span class="sxs-lookup"><span data-stu-id="85b60-165">(The next track tool is automatically added to the menu when media is playing.)</span></span>

**<span data-ttu-id="85b60-166">メニュー編成の一貫性を保つ</span><span class="sxs-lookup"><span data-stu-id="85b60-166">Be consistent with menu organization</span></span>**  
<span data-ttu-id="85b60-167">これにより、ユーザーはアプリを使用するときに利用可能なツールを見つけて習得することが容易になり、ツールの切り替える際の効率を向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-167">This helps users with discovering and learning what tools are available when using your app, and helps improve their efficiency when switching tools.</span></span>

**<span data-ttu-id="85b60-168">組み込みのアイコンと一貫性のある高品質なアイコンを提供する</span><span class="sxs-lookup"><span data-stu-id="85b60-168">Provide high-quality icons consistent with the built-in icons</span></span>**  
<span data-ttu-id="85b60-169">アイコンによってプロ意識と優秀さを伝え、ユーザーの信頼を呼び起こすことができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-169">Icons can convey professionalism and excellence, and inspire trust in users.</span></span>
- <span data-ttu-id="85b60-170">高品質な 64 x 64 ピクセルの PNG 画像を提供する (44 x 44 はサポートされている最小サイズ)</span><span class="sxs-lookup"><span data-stu-id="85b60-170">Provide a high-quality 64 x 64 pixel PNG image (44 x 44 is the smallest supported)</span></span>
- <span data-ttu-id="85b60-171">背景が透明であることを確認する</span><span class="sxs-lookup"><span data-stu-id="85b60-171">Ensure the background is transparent</span></span>
- <span data-ttu-id="85b60-172">アイコンは画像のほとんどの部分を占めている必要がある</span><span class="sxs-lookup"><span data-stu-id="85b60-172">The icon should fill most of the image</span></span>
- <span data-ttu-id="85b60-173">白いアイコンは、ハイ コントラスト モードで表示できるように黒い枠が必要である</span><span class="sxs-lookup"><span data-stu-id="85b60-173">A white icon should have a black outline to be visible in high contrast mode</span></span>

|   |   |   |
| --- | --- | --- |
| ![アルファによる背景付きのアイコン](images/windows-wheel/surface-dial-menu-icon1.png) | ![既定のテーマのアイコンでホイール メニューに表示されるアイコン](images/windows-wheel/surface-dial-menu-icon2.png) | ![Surface Dial のオンスクリーン メニュー](images/windows-wheel/surface-dial-menu-icon3.png) |
| *<span data-ttu-id="85b60-177">アルファによる背景付きのアイコン</span><span class="sxs-lookup"><span data-stu-id="85b60-177">Icon with alpha background</span></span>* | *<span data-ttu-id="85b60-178">既定のテーマでホイール メニューに表示されるアイコン</span><span class="sxs-lookup"><span data-stu-id="85b60-178">Icon displayed on wheel menu with default theme</span></span>* | *<span data-ttu-id="85b60-179">ハイコントラスト白のテーマでホイール メニューに表示されるアイコン</span><span class="sxs-lookup"><span data-stu-id="85b60-179">Icon displayed on wheel menu with High Contrast White theme</span></span>* |

**<span data-ttu-id="85b60-180">簡潔でわかりやすい名前を使う</span><span class="sxs-lookup"><span data-stu-id="85b60-180">Use concise and descriptive names</span></span>**  
<span data-ttu-id="85b60-181">ツール名は、ツールのアイコンと共にツール メニューに表示され、スクリーン リーダーでも使用されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-181">The tool name is displayed in the tool menu along with the tool icon and is also used by screen readers.</span></span> 
- <span data-ttu-id="85b60-182">名前は、ホイール メニューの中心の円内に収まるように短くする必要がある</span><span class="sxs-lookup"><span data-stu-id="85b60-182">Names should be short to fit inside the central circle of the wheel menu</span></span>
- <span data-ttu-id="85b60-183">名前は、プライマリ操作を明確に識別する (補完的な操作を暗示できる) 必要がある</span><span class="sxs-lookup"><span data-stu-id="85b60-183">Names should clearly identify the primary action (a complementary action can be implied):</span></span>
  - <span data-ttu-id="85b60-184">スクロールは両方の回転方向の効果を示す</span><span class="sxs-lookup"><span data-stu-id="85b60-184">Scroll indicates the effect of both rotation directions</span></span>
  - <span data-ttu-id="85b60-185">([元に戻す] はプライマリ操作を指定するが、ユーザーは簡単に [やり直し)] （補完的なアクション） を推測して検出できる</span><span class="sxs-lookup"><span data-stu-id="85b60-185">Undo specifies a primary action, but redo (the complementary action) can be inferred and easily discovered by the user</span></span>

### <a name="developer-guidance"></a><span data-ttu-id="85b60-186">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-186">Developer guidance</span></span>

<span data-ttu-id="85b60-187">包括的な一連の [Windows ランタイム API](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) を使用してアプリの機能を補完するために、Surface Dial エクスペリエンスをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="85b60-187">You can customize the Surface Dial experience to complement the functionality in your apps through a comprehensive set of [Windows Runtime APIs](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController).</span></span> 

<span data-ttu-id="85b60-188">前述のように、既定の Surface Dial メニューには、幅広い基本的なシステム機能 (システム ボリューム、システムの明るさ、スクロール、ズーム、取り消し、およびシステムで継続的なオーディオやビデオの再生が検出された場合のメディア コントロール) をカバーする組み込みツールのセットがあらかじめ含まれています。</span><span class="sxs-lookup"><span data-stu-id="85b60-188">As previously mentioned, the default Surface Dial menu is pre-populated with a set of built-in tools covering a broad range of basic system features (system volume, system brightness, scroll, zoom, undo, and media control when the system detects ongoing audio or video playback).</span></span> <span data-ttu-id="85b60-189">ただし、これらの既定のツールでは、アプリに必要な機能が提供されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="85b60-189">However, these default tools might not provide the functionality required by your app.</span></span> 

<span data-ttu-id="85b60-190">次のセクションでは、Surface Dial メニューにカスタム ツールを追加し、どの組み込みツールを公開するかを指定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="85b60-190">In the following sections, we describe how to add a custom tool to the Surface Dial menu and specify which built-in tools are exposed.</span></span>

**<span data-ttu-id="85b60-191">カスタム ツールを追加する</span><span class="sxs-lookup"><span data-stu-id="85b60-191">Add a custom tool</span></span>**

<span data-ttu-id="85b60-192">この例では、回転イベントとクリック イベントの両方からの入力データを、いくつかの XAML UI コントロールに渡す基本的なカスタム ツールを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b60-192">In this example, we add a basic custom tool that passes the input data from both the rotation and click events to some XAML UI controls.</span></span>

1. <span data-ttu-id="85b60-193">まず、XAMLで UI (スライダーとトグル ボタンのみ) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="85b60-193">First, we declare our UI (just a slider and toggle button) in XAML.</span></span>

   ![サンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool1.png)  
   *<span data-ttu-id="85b60-195">サンプル アプリの UI</span><span class="sxs-lookup"><span data-stu-id="85b60-195">The sample app UI</span></span>*

    ```Xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
      </Grid.RowDefinitions>
      <StackPanel x:Name="HeaderPanel" 
        Orientation="Horizontal" 
        Grid.Row="0">
          <TextBlock x:Name="Header"
            Text="RadialController customization sample"
            VerticalAlignment="Center"
            Style="{ThemeResource HeaderTextBlockStyle}"
            Margin="10,0,0,0" />
      </StackPanel>
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center"
        Grid.Row="1">
          <!-- Slider for rotation input -->
          <Slider x:Name="RotationSlider"
            Width="300"
            HorizontalAlignment="Left"/>
          <!-- Switch for click input -->
          <ToggleSwitch x:Name="ButtonToggle"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    ```

2. <span data-ttu-id="85b60-196">その後、分離コードで、Surface Dial メニューにカスタム ツールを追加し、[**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) 入力ハンドラーを宣言します。</span><span class="sxs-lookup"><span data-stu-id="85b60-196">Then, in code-behind, we add a custom tool to the Surface Dial menu and declare the [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) input handlers.</span></span> 

   <span data-ttu-id="85b60-197">[**CreateForCurrentView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.CreateForCurrentView) を呼び出すことによって、Surface Dial (myController) の [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) オブジェクトへの参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="85b60-197">We get a reference to the [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) object for the Surface Dial (myController) by calling [**CreateForCurrentView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.CreateForCurrentView).</span></span>

   <span data-ttu-id="85b60-198">次に [**RadialControllerMenuItem.CreateFromIcon**](https://msdn.microsoft.com/library/windows/apps/mt759255) を呼び出すことによって、[**RadialControllerMenuItem**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenuItem) (myItem) のインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="85b60-198">We then create an instance of a [**RadialControllerMenuItem**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenuItem) (myItem) by calling [**RadialControllerMenuItem.CreateFromIcon**](https://msdn.microsoft.com/library/windows/apps/mt759255).</span></span> 

   <span data-ttu-id="85b60-199">次に、その項目をメニュー項目のコレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="85b60-199">Next, we append that item to the collection of menu items.</span></span>

   <span data-ttu-id="85b60-200">[**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController)オブジェクトの入力イベント ハンドラー ([**ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) と [**RotationChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationChanged)) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="85b60-200">We declare the input event handlers ([**ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) and [**RotationChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationChanged)) for the [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) object.</span></span>

   <span data-ttu-id="85b60-201">最後に、イベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="85b60-201">Finally, we define the event handlers.</span></span>

    ```csharp
    public sealed partial class MainPage : Page
    {
        RadialController myController;

        public MainPage()
        {
            this.InitializeComponent();
            // Create a reference to the RadialController.
            myController = RadialController.CreateForCurrentView();

            // Create an icon for the custom tool.
            RandomAccessStreamReference icon =
              RandomAccessStreamReference.CreateFromUri(
                new Uri("ms-appx:///Assets/StoreLogo.png"));

            // Create a menu item for the custom tool.
            RadialControllerMenuItem myItem =
              RadialControllerMenuItem.CreateFromIcon("Sample", icon);

            // Add the custom tool to the RadialController menu.
            myController.Menu.Items.Add(myItem);

            // Declare input handlers for the RadialController.
            myController.ButtonClicked += MyController_ButtonClicked;
            myController.RotationChanged += MyController_RotationChanged;
        }

        // Handler for rotation input from the RadialController.
        private void MyController_RotationChanged(RadialController sender,
          RadialControllerRotationChangedEventArgs args)
        {
            if (RotationSlider.Value + args.RotationDeltaInDegrees > 100)
            {
                RotationSlider.Value = 100;
                return;
            }
            else if (RotationSlider.Value + args.RotationDeltaInDegrees < 0)
            {
                RotationSlider.Value = 0;
                return;
            }
            RotationSlider.Value += args.RotationDeltaInDegrees;
        }

        // Handler for click input from the RadialController.
        private void MyController_ButtonClicked(RadialController sender,
          RadialControllerButtonClickedEventArgs args)
        {
            ButtonToggle.IsOn = !ButtonToggle.IsOn;
        }
    }
    ```

<span data-ttu-id="85b60-202">アプリを実行するときに、Surface Dial を使用してアプリを操作します。</span><span class="sxs-lookup"><span data-stu-id="85b60-202">When we run the app, we use the Surface Dial to interact with it.</span></span> <span data-ttu-id="85b60-203">最初に、長押ししてメニューを開き、カスタム ツールを選択します。</span><span class="sxs-lookup"><span data-stu-id="85b60-203">First, we press and hold to open the menu and select our custom tool.</span></span> <span data-ttu-id="85b60-204">カスタム ツールがアクティブ化されると、Dial を回転することでスライダー コントロールを調整でき、Dial をクリックしてスイッチを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-204">Once the custom tool is activated, the slider control can be adjusted by rotating the Dial and the switch can be toggled by clicking the Dial.</span></span>

![Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool2.png)  
*<span data-ttu-id="85b60-206">Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI</span><span class="sxs-lookup"><span data-stu-id="85b60-206">The sample app UI activated using the Surface Dial custom tool</span></span>*

**<span data-ttu-id="85b60-207">組み込みのツールを指定する</span><span class="sxs-lookup"><span data-stu-id="85b60-207">Specify the built-in tools</span></span>**

<span data-ttu-id="85b60-208">[**RadialControllerConfiguration**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerConfiguration) クラスを使用して、アプリの組み込みのメニュー項目のコレクションをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="85b60-208">You can use the [**RadialControllerConfiguration**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerConfiguration) class to customize the collection of built-in menu items for your app.</span></span>

<span data-ttu-id="85b60-209">たとえば、アプリにスクロール領域やズーム領域がない場合や、元に戻す/やり直し機能が不要な場合は、これらのツールをメニューから削除できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-209">For example, if your app doesn’t have any scrolling or zooming regions and doesn’t require undo/redo functionality, these tools can be removed from the menu.</span></span> <span data-ttu-id="85b60-210">これにより、メニューにアプリのカスタム ツールを追加するための空き領域ができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-210">This opens space on the menu to add custom tools for your app.</span></span> 

> [!IMPORTANT] 
> <span data-ttu-id="85b60-211">Surface Dial メニューには、少なくとも 1 つのメニュー項目が必要です。</span><span class="sxs-lookup"><span data-stu-id="85b60-211">The Surface Dial menu must have at least one menu item.</span></span> <span data-ttu-id="85b60-212">カスタム ツールの 1 つを追加する前に、すべての既定のツールを削除した場合、既定のツールは復元され、ツールは既定のコレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-212">If all default tools are removed before you add one of your custom tools, the default tools are restored and your tool is appended to the default collection.</span></span>

<span data-ttu-id="85b60-213">設計のガイドラインとして、ユーザーは他のタスクを実行しながら BGM を再生していることが多いため、メディア コントロール ツール (ボリュームおよび前/次のトラック) は削除しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85b60-213">Per the design guidelines, we do not recommend removing the media control tools (volume and previous/next track) as users often have background music playing while they perform other tasks.</span></span>

<span data-ttu-id="85b60-214">ここでは、ボリュームと次/前のトラックのメディア コントロールのみを含む Surface Dial メニューを構成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="85b60-214">Here, we show how to configure the Surface Dial menu to include only media controls for volume and next/previous track.</span></span>

```csharp
public MainPage()
{
  ...
  //Remove a subset of the default system tools
  RadialControllerConfiguration myConfiguration = 
  RadialControllerConfiguration.GetForCurrentView();
  myConfiguration.SetDefaultMenuItems(new[] 
  {
    RadialControllerSystemMenuItemKind.Volume,
      RadialControllerSystemMenuItemKind.NextPreviousTrack
  });
}
```

## <a name="custom-interactions"></a><span data-ttu-id="85b60-215">カスタム操作</span><span class="sxs-lookup"><span data-stu-id="85b60-215">Custom interactions</span></span>

<span data-ttu-id="85b60-216">前述のように、Surface Dial は 3 つのジェスチャ (長押し、回転、クリック) をサポートしており、それぞれ既定の操作に対応します。</span><span class="sxs-lookup"><span data-stu-id="85b60-216">As mentioned, the Surface Dial supports three gestures (press and hold, rotate, click) with corresponding default interactions.</span></span> 

<span data-ttu-id="85b60-217">これらのジェスチャに基づくカスタム操作は、選択したアクションやツールで意味があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="85b60-217">Ensure any custom interactions based on these gestures make sense for the selected action or tool.</span></span> 

> [!NOTE]
> <span data-ttu-id="85b60-218">操作エクスペリエンスは、Surface Dial メニューの状態に依存します。</span><span class="sxs-lookup"><span data-stu-id="85b60-218">The interaction experience is dependent on the state of the Surface Dial menu.</span></span> <span data-ttu-id="85b60-219">メニューがアクティブな場合はメニューが入力を処理し、それ以外の場合はアプリが入力を処理します。</span><span class="sxs-lookup"><span data-stu-id="85b60-219">If the menu is active, it processes the input; otherwise, your app does.</span></span>

### <a name="press-and-hold"></a><span data-ttu-id="85b60-220">長押し</span><span class="sxs-lookup"><span data-stu-id="85b60-220">Press and hold</span></span>

<span data-ttu-id="85b60-221">このジェスチャは、Surface Dial メニューをアクティブにして表示します。このジェスチャに関連付けられているアプリの機能はありません。</span><span class="sxs-lookup"><span data-stu-id="85b60-221">This gesture activates and shows the Surface Dial menu, there is no app functionality associated with this gesture.</span></span> 

<span data-ttu-id="85b60-222">既定では、ユーザーの画面の中央にメニューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-222">By default, the menu is displayed at the center of the user’s screen.</span></span> <span data-ttu-id="85b60-223">ただし、ユーザーはメニューをつかんで、選択した任意の場所に移動できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-223">However, the user can grab it and move it anywhere they choose.</span></span>

> [!NOTE]
> <span data-ttu-id="85b60-224">Surface Dial を Surface Studio の画面上に配置している場合、Surface Dial の画面上の位置を中心として表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-224">When the Surface Dial is placed on the screen of the Surface Studio, the menu is centered at the on-screen location of the Surface Dial.</span></span>

### <a name="rotate"></a><span data-ttu-id="85b60-225">回転</span><span class="sxs-lookup"><span data-stu-id="85b60-225">Rotate</span></span>

<span data-ttu-id="85b60-226">Surface Dial は、アナログ値やコントロールのスムーズな増分の調整に関連する操作のための回転をサポートすることを主な目的として設計されています。</span><span class="sxs-lookup"><span data-stu-id="85b60-226">The Surface Dial is primarily designed to support rotation for interactions that involve smooth, incremental adjustments to analog values or controls.</span></span>

<span data-ttu-id="85b60-227">このデバイスは、時計回りと反時計回りの両方向に回転させることができ、個々の間隔を示す触覚フィードバックを提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="85b60-227">The device can be rotated both clockwise and counter-clockwise, and can also provide haptic feedback to indicate discrete distances.</span></span>

> [!NOTE]
> <span data-ttu-id="85b60-228">触覚フィードバックは、ユーザーが **[Windows の設定] -> [デバイス] -> [ホイール]** ページで無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-228">Haptic feedback can be disabled by the user in the **Windows Settings -> Devices -> Wheel** page.</span></span>

#### <a name="ux-guidance"></a><span data-ttu-id="85b60-229">UX ガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-229">UX guidance</span></span>

**<span data-ttu-id="85b60-230">連続的な高い回転感度のツールでは触覚フィードバックを無効にする</span><span class="sxs-lookup"><span data-stu-id="85b60-230">Tools with continuous or high rotational sensitivity should disable haptic feedback</span></span>**

<span data-ttu-id="85b60-231">触覚フィードバックは、アクティブなツールの回転感度と一致します。</span><span class="sxs-lookup"><span data-stu-id="85b60-231">Haptic feedback matches the rotational sensitivity of the active tool.</span></span> <span data-ttu-id="85b60-232">ユーザー エクスペリエンスが快適ではなくなる可能性があるため、連続的な高い回転感度のツールでは、触覚フィードバックを無効にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85b60-232">We recommend disabling haptic feedback for tools with continuous or high rotational sensitivity as the user experience can get uncomfortable.</span></span> 

**<span data-ttu-id="85b60-233">利き手が回転ベースの操作に影響しないようにする</span><span class="sxs-lookup"><span data-stu-id="85b60-233">Dominant hand should not affect rotation-based interactions</span></span>**

<span data-ttu-id="85b60-234">Surface Dial では使用されている手を検出できませんが、ユーザーは **[Windows の設定] -> [デバイス] -> [ペンと Windows Ink]** で利き手を設定できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-234">The Surface Dial cannot detect which hand is being used, but the user can set the writing (or dominant hand) in **Windows Settings -> Device -> Pen & Windows Ink**.</span></span>

**<span data-ttu-id="85b60-235">すべての回転操作でロケールを考慮する必要がある</span><span class="sxs-lookup"><span data-stu-id="85b60-235">Locale should be considered for all rotation interactions</span></span>**

<span data-ttu-id="85b60-236">対話式操作をロケールおよび右から左のレイアウトに対応させて調整することにより、顧客満足度を最大化します。</span><span class="sxs-lookup"><span data-stu-id="85b60-236">Maximize customer satisfaction by accomodating and adapting your interactions to locale and right-to-left layouts.</span></span>

<span data-ttu-id="85b60-237">Dial メニューの組み込みのツールとコマンドは、回転ベースの操作について以下のガイドラインに従っています。</span><span class="sxs-lookup"><span data-stu-id="85b60-237">The built-in tools and commands on the Dial menu follow these guidelines for rotation-based interactions:</span></span>

|   |   |   |
| --- | --- | --- |
| <span data-ttu-id="85b60-238">左</span><span class="sxs-lookup"><span data-stu-id="85b60-238">Left</span></span><br/><span data-ttu-id="85b60-239">上</span><span class="sxs-lookup"><span data-stu-id="85b60-239">Up</span></span><br/><span data-ttu-id="85b60-240">外</span><span class="sxs-lookup"><span data-stu-id="85b60-240">Out</span></span> | ![Surface Dial の画像](images/windows-wheel/surface-dial-rotate.png) | <span data-ttu-id="85b60-242">右</span><span class="sxs-lookup"><span data-stu-id="85b60-242">Right</span></span><br/><span data-ttu-id="85b60-243">下</span><span class="sxs-lookup"><span data-stu-id="85b60-243">Down</span></span><br/><span data-ttu-id="85b60-244">内</span><span class="sxs-lookup"><span data-stu-id="85b60-244">In</span></span> |
|   |   |   |

| <span data-ttu-id="85b60-245">概念的な方向</span><span class="sxs-lookup"><span data-stu-id="85b60-245">Conceptual direction</span></span> | <span data-ttu-id="85b60-246">Surface Dial へのマッピング</span><span class="sxs-lookup"><span data-stu-id="85b60-246">Mapping to Surface Dial</span></span> | <span data-ttu-id="85b60-247">時計回りの回転</span><span class="sxs-lookup"><span data-stu-id="85b60-247">Clockwise rotation</span></span> | <span data-ttu-id="85b60-248">反時計回りの回転</span><span class="sxs-lookup"><span data-stu-id="85b60-248">Counter-clockwise rotation</span></span> |
| --- | --- | --- | --- |
| <span data-ttu-id="85b60-249">横方向</span><span class="sxs-lookup"><span data-stu-id="85b60-249">Horizontal</span></span> | <span data-ttu-id="85b60-250">Surface Dial の上部に基づいて左右のマッピング</span><span class="sxs-lookup"><span data-stu-id="85b60-250">Left and right mapping based on the top of the Surface Dial</span></span> | <span data-ttu-id="85b60-251">右</span><span class="sxs-lookup"><span data-stu-id="85b60-251">Right</span></span> | <span data-ttu-id="85b60-252">左</span><span class="sxs-lookup"><span data-stu-id="85b60-252">Left</span></span> |
| <span data-ttu-id="85b60-253">縦方向</span><span class="sxs-lookup"><span data-stu-id="85b60-253">Vertical</span></span> | <span data-ttu-id="85b60-254">Surface Dial の左側に基づいて上下のマッピング</span><span class="sxs-lookup"><span data-stu-id="85b60-254">Up and down mapping based on the left side of the Surface Dial</span></span> | <span data-ttu-id="85b60-255">下</span><span class="sxs-lookup"><span data-stu-id="85b60-255">Down</span></span> | <span data-ttu-id="85b60-256">上</span><span class="sxs-lookup"><span data-stu-id="85b60-256">Up</span></span> |
| <span data-ttu-id="85b60-257">Z 軸</span><span class="sxs-lookup"><span data-stu-id="85b60-257">Z-axis</span></span> | <span data-ttu-id="85b60-258">内 (またはより近い) が上/右にマップ</span><span class="sxs-lookup"><span data-stu-id="85b60-258">In (or nearer) mapped to up/right</span></span><br/><span data-ttu-id="85b60-259">外 (またはより遠い) が下/左にマップ</span><span class="sxs-lookup"><span data-stu-id="85b60-259">Out (or further) mapped to down/left</span></span> | <span data-ttu-id="85b60-260">内</span><span class="sxs-lookup"><span data-stu-id="85b60-260">In</span></span> | <span data-ttu-id="85b60-261">外</span><span class="sxs-lookup"><span data-stu-id="85b60-261">Out</span></span> |

#### <a name="developer-guidance"></a><span data-ttu-id="85b60-262">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-262">Developer guidance</span></span>

<span data-ttu-id="85b60-263">ユーザーがデバイスを回転させると、[**RadialController.RotationChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationChanged) イベントが、回転の方向を基準としたデルタ ([**RadialControllerRotationChangedEventArgs.RotationDeltaInDegrees**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerRotationChangedEventArgs.RotationDeltaInDegrees)) に基づいて発生します。</span><span class="sxs-lookup"><span data-stu-id="85b60-263">As the user rotates the device, [**RadialController.RotationChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationChanged) events are fired based on a delta ([**RadialControllerRotationChangedEventArgs.RotationDeltaInDegrees**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerRotationChangedEventArgs.RotationDeltaInDegrees)) relative to the direction of rotation.</span></span> <span data-ttu-id="85b60-264">データの感度 (または解像度) は、[**RadialController.RotationResolutionInDegrees**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationResolutionInDegrees) プロパティで設定できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-264">The sensitivity (or resolution) of the data can be set with the [**RadialController.RotationResolutionInDegrees**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationResolutionInDegrees) property.</span></span>

> [!NOTE]
> <span data-ttu-id="85b60-265">既定では、デバイスが最小値の 10 度回転された場合に、初めて回転入力イベントが [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) オブジェクトに配信されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-265">By default, a rotational input event is delivered to a [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) object only when the device is rotated a minimum of 10 degrees.</span></span> <span data-ttu-id="85b60-266">各入力イベントによって、デバイスのバイブレーションが発生します。</span><span class="sxs-lookup"><span data-stu-id="85b60-266">Each input event causes the device to vibrate.</span></span>

<span data-ttu-id="85b60-267">一般的に、回転解像度が 5 度未満に設定されている場合は、触覚フィードバックを無効にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="85b60-267">In general, we recommend disabling haptic feedback when the rotation resolution is set to less than 5 degrees.</span></span> <span data-ttu-id="85b60-268">これにより、連続的な対話式操作でスムーズなエクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-268">This provides a smoother experience for continuous interactions.</span></span> 

<span data-ttu-id="85b60-269">カスタム ツールの触覚フィードバックを有効または無効にするには、[**RadialController.UseAutomaticHapticFeedback**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.UseAutomaticHapticFeedback) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="85b60-269">You can enable and disable haptic feedback for custom tools by setting the [**RadialController.UseAutomaticHapticFeedback**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.UseAutomaticHapticFeedback) property.</span></span>

> [!NOTE]
> <span data-ttu-id="85b60-270">ボリューム コントロールなどのシステム ツールの触覚動作をオーバーライドすることはできません。</span><span class="sxs-lookup"><span data-stu-id="85b60-270">You cannot override the haptic behavior for system tools such as the volume control.</span></span> <span data-ttu-id="85b60-271">これらのツールについては、ユーザーが [ホイールの設定] ページからのみ触覚フィードバックを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-271">For these tools, haptic feedback can be disabled only by the user from the wheel settings page.</span></span>

<span data-ttu-id="85b60-272">回転のデータの解像度をカスタマイズし、触覚フィードバックを有効または無効にする方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="85b60-272">Here’s an example of how to customize the resolution of the rotation data and enable or disable haptic feedback.</span></span>

```csharp
private void MyController_ButtonClicked(RadialController sender, 
  RadialControllerButtonClickedEventArgs args)
{
  ButtonToggle.IsOn = !ButtonToggle.IsOn;

  if(ButtonToggle.IsOn)
  {
    //high resolution mode
    RotationSlider.LargeChange = 1;
    myController.UseAutomaticHapticFeedback = false;
    myController.RotationResolutionInDegrees = 1;
  }
  else
  {
    //low resolution mode
    RotationSlider.LargeChange = 10;
    myController.UseAutomaticHapticFeedback = true;
    myController.RotationResolutionInDegrees = 10;
  }
}
```

### <a name="click"></a><span data-ttu-id="85b60-273">クリック</span><span class="sxs-lookup"><span data-stu-id="85b60-273">Click</span></span>

<span data-ttu-id="85b60-274">Surface Dial のクリックは、マウスの左ボタンのクリックと似ています (デバイスの回転状態は、この操作に影響しません)。</span><span class="sxs-lookup"><span data-stu-id="85b60-274">Clicking the Surface Dial is similar to clicking the left mouse button (the rotation state of the device has no effect on this action).</span></span>

#### <a name="ux-guidance"></a><span data-ttu-id="85b60-275">UX ガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-275">UX guidance</span></span>

**<span data-ttu-id="85b60-276">ユーザーが結果から簡単に回復できない場合は、このジェスチャに操作やコマンドをマップしない</span><span class="sxs-lookup"><span data-stu-id="85b60-276">Do not map an action or command to this gesture if the user cannot easily recover from the result</span></span>**

<span data-ttu-id="85b60-277">ユーザーによる Surface Dial のクリックに基づいてアプリが実行する操作は、元に戻すことができる必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b60-277">Any action taken by your app based on the user clicking the Surface Dial must be reversible.</span></span> <span data-ttu-id="85b60-278">常に、ユーザーが簡単にアプリのバック スタックを移動して、アプリの以前の状態を復元できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="85b60-278">Always enable the user to easily traverse the app back stack and restore a previous app state.</span></span>

<span data-ttu-id="85b60-279">ミュート/ミュート解除や表示/非表示などのバイナリ操作は、クリック ジェスチャによる優れたユーザー エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="85b60-279">Binary operations such as mute/unmute or show/hide provide good user experiences with the click gesture.</span></span>

**<span data-ttu-id="85b60-280">Surface Dial のクリックによってモーダル ツールを有効または無効にしない</span><span class="sxs-lookup"><span data-stu-id="85b60-280">Modal tools should not be enabled or disabled by clicking the Surface Dial</span></span>**

<span data-ttu-id="85b60-281">一部のアプリ/ツールのモードは、回転に依存する操作と競合する、つまり無効にする場合があります。</span><span class="sxs-lookup"><span data-stu-id="85b60-281">Some app/tool modes can conflict with, or disable, interactions that rely on rotation.</span></span> <span data-ttu-id="85b60-282">Windows Ink ツール バーのルーラーなどのツールは、他の UI アフォーダンスでオンとオフを切り替える必要があります (Ink ツール バーには、組み込みの [**ToggleButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.ToggleButton) コントロールがあります)。</span><span class="sxs-lookup"><span data-stu-id="85b60-282">Tools such as the ruler in the Windows Ink toolbar, should be toggled on or off through other UI affordances (the Ink Toolbar provides a built-in [**ToggleButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.ToggleButton) control).</span></span>

<span data-ttu-id="85b60-283">モーダル ツールの場合、アクティブな Surface Dial メニュー項目を、ターゲット ツールまたは以前に選択したメニュー項目にマップします。</span><span class="sxs-lookup"><span data-stu-id="85b60-283">For modal tools, map the active Surface Dial menu item to the target tool or to the previously selected menu item.</span></span>

#### <a name="developer-guidance"></a><span data-ttu-id="85b60-284">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-284">Developer guidance</span></span>

<span data-ttu-id="85b60-285">Surface Dial がクリックされると、[**RadialController.ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="85b60-285">When the Surface Dial is clicked, a [**RadialController.ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) event is fired.</span></span> <span data-ttu-id="85b60-286">[**RadialControllerButtonClickedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs) には、Surface Dial が Surface Studio の画面に接触している位置と境界領域を格納する [**Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs.Contact) プロパティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="85b60-286">The [**RadialControllerButtonClickedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs) include a [**Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs.Contact) property that contains the location and bounding area of the Surface Dial contact on the Surface Studio screen.</span></span> <span data-ttu-id="85b60-287">Surface Dial が画面に接触していない場合、このプロパティは null です。</span><span class="sxs-lookup"><span data-stu-id="85b60-287">If the Surface Dial is not in contact with the screen, this property is null.</span></span> 

### <a name="on-screen"></a><span data-ttu-id="85b60-288">オンスクリーン</span><span class="sxs-lookup"><span data-stu-id="85b60-288">On-screen</span></span>

<span data-ttu-id="85b60-289">前述のように、Surface Dial は Surface Studio と組み合わせて使用し、特殊なオンスクリーン モードで Surface Dial メニューを表示できます。</span><span class="sxs-lookup"><span data-stu-id="85b60-289">As described earlier, the Surface Dial can be used in conjunction with the Surface Studio to display the Surface Dial menu in a special on-screen mode.</span></span> 

<span data-ttu-id="85b60-290">このモードでは、Dial の操作エクスペリエンスとアプリをさらに統合してカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="85b60-290">When in this mode, you can integrate and customize your Dial interaction experiences with your apps even further.</span></span> <span data-ttu-id="85b60-291">Surface Dial と Surface Studio の組み合わせでのみ実現できるユニークなエクスペリエンスの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="85b60-291">Examples of unique experiences only possible with the Surface Dial and Surface Studio include:</span></span>
- <span data-ttu-id="85b60-292">Surface Dial の位置に基づいて、状況に応じたツール (カラー パレットなど) を表示し、ツールを簡単に見つけて使用できるようにする</span><span class="sxs-lookup"><span data-stu-id="85b60-292">Displaying contextual tools (such as a color palette) based on the position of the Surface Dial, which makes them easier to find and use</span></span>
- <span data-ttu-id="85b60-293">Surface Dial が配置されている UI に基づいて、アクティブなツールを設定する</span><span class="sxs-lookup"><span data-stu-id="85b60-293">Setting the active tool based on the UI the Surface Dial is placed on</span></span>
- <span data-ttu-id="85b60-294">Surface Dial の位置に基づいて、画面領域を拡大する</span><span class="sxs-lookup"><span data-stu-id="85b60-294">Magnifying a screen area based on location of the Surface Dial</span></span>
- <span data-ttu-id="85b60-295">画面の位置に基づくユニークなゲームの操作</span><span class="sxs-lookup"><span data-stu-id="85b60-295">Unique game interactions based on screen location</span></span>

#### <a name="ux-guidance"></a><span data-ttu-id="85b60-296">UX ガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-296">UX guidance</span></span>

**<span data-ttu-id="85b60-297">画面上で Surface Dial が検出されたときにアプリが応答する必要がある</span><span class="sxs-lookup"><span data-stu-id="85b60-297">Apps should respond when the Surface Dial is detected on-screen</span></span>**

<span data-ttu-id="85b60-298">視覚的なフィードバックは、アプリが Surface Studio の画面上のデバイスを検出したことをユーザーに知らせるのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="85b60-298">Visual feedback helps indicate to users that your app has detected the device on the screen of the Surface Studio.</span></span>

**<span data-ttu-id="85b60-299">デバイスの位置に基づいて Surface Dial 関連の UI を調整する</span><span class="sxs-lookup"><span data-stu-id="85b60-299">Adjust Surface Dial-related UI based on device location</span></span>**

<span data-ttu-id="85b60-300">ユーザーがデバイスを配置した場所によっては、デバイス (とユーザーの体) により重要な UI が見えなくなる場合があります。</span><span class="sxs-lookup"><span data-stu-id="85b60-300">The device (and the user's body) can occlude critical UI depending on where the user places it.</span></span>

**<span data-ttu-id="85b60-301">ユーザー操作に基づいて Surface Dial 関連の UI を調整する</span><span class="sxs-lookup"><span data-stu-id="85b60-301">Adjust Surface Dial-related UI based on user interaction</span></span>**

<span data-ttu-id="85b60-302">デバイスを使用するときに、ハードウェアに加えて、ユーザーの手や腕によって画面の一部が見えなくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="85b60-302">In addition to hardware occlusion, a user’s hand and arm can occlude part of the screen when using the device.</span></span> 

<span data-ttu-id="85b60-303">見えなくなる領域は、どちらの手でデバイスを使用しているかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="85b60-303">The occluded area depends on which hand is being used with the device.</span></span> <span data-ttu-id="85b60-304">Surface Dial は、主に利き手以外の手で使用するように設計されているため、Surface Dial 関連の UI はユーザーが指定した利き手 (**[Windowsの設定] > [デバイス] > [ペンと Windows Ink] > [利き手を選択してください]** の設定) に合わせて調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b60-304">As the device is designed to be used primarily with the non-dominant hand, Surface Dial-related UI should adjust for the opposite hand specified by the user (**Windows Settings > Devices > Pen & Windows Ink > Choose which hand you write with** setting).</span></span>

**<span data-ttu-id="85b60-305">操作は Surface Dial の動きではなく位置に対応する必要がある</span><span class="sxs-lookup"><span data-stu-id="85b60-305">Interactions should respond to Surface Dial position rather than movement</span></span>**

<span data-ttu-id="85b60-306">このデバイスは高精度ポインティング デバイスではないため、スライドするのではなく、画面に張り付くように設計されています。</span><span class="sxs-lookup"><span data-stu-id="85b60-306">The foot of the device is designed to stick to the screen rather than slide, as it is not a precision pointing device.</span></span> <span data-ttu-id="85b60-307">そのため、ユーザーは Surface Dial を画面上でドラッグするのではなく、持ち上げて配置する方が一般的であると想定しています。</span><span class="sxs-lookup"><span data-stu-id="85b60-307">Therefore, we expect it to be more common for users to lift and place the Surface Dial rather than drag it across the screen.</span></span>

**<span data-ttu-id="85b60-308">画面上の位置を使用してユーザーの意図を確認する</span><span class="sxs-lookup"><span data-stu-id="85b60-308">Use screen position to determine user intent</span></span>**

<span data-ttu-id="85b60-309">UI コンテキスト (コントロール、キャンバス、ウィンドウとの近さなど) に基づいてアクティブなツールを設定すると、タスクを実行するために必要な手順が減ることにより、ユーザー エクスペリエンスを向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-309">Setting the active tool based on UI context, such as proximity to a control, canvas, or window, can improve the user experience by reducing the steps required to perform a task.</span></span>

#### <a name="developer-guidance"></a><span data-ttu-id="85b60-310">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="85b60-310">Developer guidance</span></span>

<span data-ttu-id="85b60-311">Surface Dial が Surface Studio のデジタイザー サーフェス上に配置されると、[**RadialController.ScreenContactStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ScreenContactStarted) イベントが発生し、接触情報 ([**RadialControllerScreenContactStartedEventArgs.Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContactStartedEventArgs.Contact)) がアプリに提供されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-311">When the Surface Dial is placed onto the digitizer surface of the Surface Studio, a [**RadialController.ScreenContactStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ScreenContactStarted) event is fired and the contact info ([**RadialControllerScreenContactStartedEventArgs.Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContactStartedEventArgs.Contact)) is provided to your app.</span></span>

<span data-ttu-id="85b60-312">同様に、Surface Studio のデジタイザー サーフェスに接触しているときに、Surface Dial がクリックされた場合、[**RadialController.ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) イベントが発生し、接触情報 ([**RadialControllerButtonClickedEventArgs.Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs.Contact)) がアプリに提供されます。</span><span class="sxs-lookup"><span data-stu-id="85b60-312">Similarly, if the Surface Dial is clicked when in contact with the digitizer surface of the Surface Studio, a [**RadialController.ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) event is fired and the contact info ([**RadialControllerButtonClickedEventArgs.Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs.Contact)) is provided to your app.</span></span> 

<span data-ttu-id="85b60-313">接触情報 ([**RadialControllerScreenContact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact)) には、アプリの座標空間での Surface Dial の中心のX/Y座標 ([**RadialControllerScreenContact.Position**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact.Position)) と、デバイスに依存しないピクセル (DIP) での境界の四角形 ([**RadialControllerScreenContact.Bounds**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact.Bounds)) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="85b60-313">The contact info ([**RadialControllerScreenContact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact)) includes the X/Y coordinate of the center of the Surface Dial in the coordinate space of the app ([**RadialControllerScreenContact.Position**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact.Position)), as well as the bounding rectangle ([**RadialControllerScreenContact.Bounds**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact.Bounds)) in Device Independent Pixels (DIPs).</span></span> <span data-ttu-id="85b60-314">この情報は、アクティブなツールにコンテキストを提供し、ユーザーにデバイスに関連する視覚的なフィードバックを提供する場合に、非常に便利です。</span><span class="sxs-lookup"><span data-stu-id="85b60-314">This info is very useful for providing context to the active tool and providing device-related visual feedback to the user.</span></span>

<span data-ttu-id="85b60-315">次の例では、それぞれが 1 つのスライダーと 1 つのトグル スイッチを含む、4 つの異なるセクションを持つ基本的なアプリを作成したしました。</span><span class="sxs-lookup"><span data-stu-id="85b60-315">In the following example, we’ve created a basic app with four different sections, each of which includes one slider and one toggle.</span></span> <span data-ttu-id="85b60-316">Surface Dial の画面上の位置を使用して、Surface Dial で制御されるスライダーとトグル スイッチのセットを決定します。</span><span class="sxs-lookup"><span data-stu-id="85b60-316">We then use the onscreen position of the Surface Dial to dictate which set of sliders and toggles are controlled by the Surface Dial.</span></span>

1. <span data-ttu-id="85b60-317">最初に、XAMLで UI (4つのセクションと、それぞれのスライダーとトグル ボタン) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="85b60-317">First, we declare our UI (four sections, each with a slider and toggle button) in XAML.</span></span>

   ![サンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool3.png)  
   *<span data-ttu-id="85b60-319">サンプル アプリの UI</span><span class="sxs-lookup"><span data-stu-id="85b60-319">The sample app UI</span></span>*

   ```xaml 
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
  <Grid.RowDefinitions>
    <RowDefinition Height="Auto"/>
    <RowDefinition Height="*"/>
  </Grid.RowDefinitions>
  <StackPanel x:Name="HeaderPanel" 
        Orientation="Horizontal" 
        Grid.Row="0">
    <TextBlock x:Name="Header"
      Text="RadialController customization sample"
      VerticalAlignment="Center"
      Style="{ThemeResource HeaderTextBlockStyle}"
      Margin="10,0,0,0" />
  </StackPanel>
  <Grid Grid.Row="1" x:Name="RootGrid">
    <Grid.RowDefinitions>
      <RowDefinition Height="*"/>
      <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
      <ColumnDefinition Width="*"/>
      <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    <Grid x:Name="Grid0"
      Grid.Row="0"
      Grid.Column="0">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider0"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle0"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    <Grid x:Name="Grid1"
      Grid.Row="0"
      Grid.Column="1">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider1"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle1"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    <Grid x:Name="Grid2"
      Grid.Row="1"
      Grid.Column="0">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider2"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle2"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    <Grid x:Name="Grid3"
      Grid.Row="1"
      Grid.Column="1">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider3"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle3"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
  </Grid>
</Grid>
   ```

2. <span data-ttu-id="85b60-320">Surface Dial の画面上の位置に対して定義されているハンドラーを含む分離コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="85b60-320">Here's the code-behind with handlers defined for Surface Dial screen position.</span></span>

```csharp
Slider ActiveSlider;
ToggleSwitch ActiveSwitch;
Grid ActiveGrid;

public MainPage()
{
  ...

  myController.ScreenContactStarted += 
    MyController_ScreenContactStarted;
  myController.ScreenContactContinued += 
    MyController_ScreenContactContinued;
  myController.ScreenContactEnded += 
    MyController_ScreenContactEnded;
  myController.ControlLost += MyController_ControlLost;

  //Set initial grid for Surface Dial input.
  ActiveGrid = Grid0;
  ActiveSlider = RotationSlider0;
  ActiveSwitch = ButtonToggle0;
}

private void MyController_ScreenContactStarted(RadialController sender, 
  RadialControllerScreenContactStartedEventArgs args)
{
  //find grid at contact location, update visuals, selection
  ActivateGridAtLocation(args.Contact.Position);
}

private void MyController_ScreenContactContinued(RadialController sender, 
  RadialControllerScreenContactContinuedEventArgs args)
{
  //if a new grid is under contact location, update visuals, selection
  if (!VisualTreeHelper.FindElementsInHostCoordinates(
    args.Contact.Position, RootGrid).Contains(ActiveGrid))
  {
    ActiveGrid.Background = new 
      SolidColorBrush(Windows.UI.Colors.White);
    ActivateGridAtLocation(args.Contact.Position);
  }
}

private void MyController_ScreenContactEnded(RadialController sender, object args)
{
  //return grid color to normal when contact leaves screen
  ActiveGrid.Background = new 
  SolidColorBrush(Windows.UI.Colors.White);
}

private void MyController_ControlLost(RadialController sender, object args)
{
  //return grid color to normal when focus lost
  ActiveGrid.Background = new 
    SolidColorBrush(Windows.UI.Colors.White);
}

private void ActivateGridAtLocation(Point Location)
{
  var elementsAtContactLocation = 
    VisualTreeHelper.FindElementsInHostCoordinates(Location, 
      RootGrid);

  foreach (UIElement element in elementsAtContactLocation)
  {
    if (element as Grid == Grid0)
    {
      ActiveSlider = RotationSlider0;
      ActiveSwitch = ButtonToggle0;
      ActiveGrid = Grid0;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
    else if (element as Grid == Grid1)
    {
      ActiveSlider = RotationSlider1;
      ActiveSwitch = ButtonToggle1;
      ActiveGrid = Grid1;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
    else if (element as Grid == Grid2)
    {
      ActiveSlider = RotationSlider2;
      ActiveSwitch = ButtonToggle2;
      ActiveGrid = Grid2;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
    else if (element as Grid == Grid3)
    {
      ActiveSlider = RotationSlider3;
      ActiveSwitch = ButtonToggle3;
      ActiveGrid = Grid3;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
  }
}
```

<span data-ttu-id="85b60-321">アプリを実行するときに、Surface Dial を使用してアプリを操作します。</span><span class="sxs-lookup"><span data-stu-id="85b60-321">When we run the app, we use the Surface Dial to interact with it.</span></span> <span data-ttu-id="85b60-322">最初に、Surface Studio の画面にデバイスを配置します。アプリがデバイスを検出し、右下のセクションに関連付けます (画像を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="85b60-322">First, we place the device on the Surface Studio screen, which the app detects and associates with the lower right section (see image).</span></span> <span data-ttu-id="85b60-323">次に Surface Dial を長押ししてメニューを開き、カスタム ツールを選択します。</span><span class="sxs-lookup"><span data-stu-id="85b60-323">We then press and hold the Surface Dial to open the menu and select our custom tool.</span></span> <span data-ttu-id="85b60-324">カスタム ツールがアクティブ化されると、Surface Dial を回転することでスライダー コントロールを調整でき、Surface Dial をクリックしてスイッチを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="85b60-324">Once the custom tool is activated, the slider control can be adjusted by rotating the Surface Dial and the switch can be toggled by clicking the Surface Dial.</span></span>

![Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool4.png)  
*<span data-ttu-id="85b60-326">Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI</span><span class="sxs-lookup"><span data-stu-id="85b60-326">The sample app UI activated using the Surface Dial custom tool</span></span>*

## <a name="summary"></a><span data-ttu-id="85b60-327">まとめ</span><span class="sxs-lookup"><span data-stu-id="85b60-327">Summary</span></span>

<span data-ttu-id="85b60-328">このトピックでは、Surface Studio 入力デバイスの概要を、UX および開発者向けのガイダンスと共に示し、オフスクリーンのシナリオおよび Surface Studio と共に使用する場合のオンスクリーンのシナリオでユーザー エクスペリエンスをカスタマイズする方法について説明しました。</span><span class="sxs-lookup"><span data-stu-id="85b60-328">This topic provides an overview of the Surface Dial input device with UX and developer guidance on how to customize the user experience for off-screen scenarios as well as on-screen scenarios when used with Surface Studio.</span></span>

## <a name="feedback"></a><span data-ttu-id="85b60-329">フィードバック</span><span class="sxs-lookup"><span data-stu-id="85b60-329">Feedback</span></span>

<span data-ttu-id="85b60-330">質問、提案、フィードバックについては、[radialcontroller@microsoft.com](mailto:radialcontroller@microsoft.com) までお送りください。</span><span class="sxs-lookup"><span data-stu-id="85b60-330">Please send your questions, suggestions, and feedback to [radialcontroller@microsoft.com](mailto:radialcontroller@microsoft.com).</span></span>

## <a name="related-articles"></a><span data-ttu-id="85b60-331">関連記事</span><span class="sxs-lookup"><span data-stu-id="85b60-331">Related articles</span></span>

### <a name="api-reference"></a><span data-ttu-id="85b60-332">API リファレンス</span><span class="sxs-lookup"><span data-stu-id="85b60-332">API reference</span></span>

- [<span data-ttu-id="85b60-333">**RadialController** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-333">**RadialController** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController)
- [<span data-ttu-id="85b60-334">**RadialControllerButtonClickedEventArgs** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-334">**RadialControllerButtonClickedEventArgs** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs)
- [<span data-ttu-id="85b60-335">**RadialControllerConfiguration** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-335">**RadialControllerConfiguration** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerConfiguration) 
- [<span data-ttu-id="85b60-336">**RadialControllerControlAcquiredEventArgs** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-336">**RadialControllerControlAcquiredEventArgs** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerControlAcquiredEventArgs) 
- [<span data-ttu-id="85b60-337">**RadialControllerMenu** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-337">**RadialControllerMenu** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenu) 
- [<span data-ttu-id="85b60-338">**RadialControllerMenuItem** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-338">**RadialControllerMenuItem** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenuItem) 
- [<span data-ttu-id="85b60-339">**RadialControllerRotationChangedEventArgs** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-339">**RadialControllerRotationChangedEventArgs** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerRotationChangedEventArgs) 
- [<span data-ttu-id="85b60-340">**RadialControllerScreenContact** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-340">**RadialControllerScreenContact** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact) 
- [<span data-ttu-id="85b60-341">**RadialControllerScreenContactContinuedEventArgs** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-341">**RadialControllerScreenContactContinuedEventArgs** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContactContinuedEventArgs) 
- [<span data-ttu-id="85b60-342">**RadialControllerScreenContactStartedEventArgs** クラス</span><span class="sxs-lookup"><span data-stu-id="85b60-342">**RadialControllerScreenContactStartedEventArgs** class</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContactStartedEventArgs)
- [<span data-ttu-id="85b60-343">**RadialControllerMenuKnownIcon** 列挙型</span><span class="sxs-lookup"><span data-stu-id="85b60-343">**RadialControllerMenuKnownIcon** enum</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenuKnownIcon) 
- [<span data-ttu-id="85b60-344">**RadialControllerSystemMenuItemKind** 列挙型</span><span class="sxs-lookup"><span data-stu-id="85b60-344">**RadialControllerSystemMenuItemKind** enum</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerSystemMenuItemKind) 

### <a name="samples"></a><span data-ttu-id="85b60-345">サンプル</span><span class="sxs-lookup"><span data-stu-id="85b60-345">Samples</span></span>

[<span data-ttu-id="85b60-346">ユニバーサル Windows プラットフォーム のサンプル (C# と C++)</span><span class="sxs-lookup"><span data-stu-id="85b60-346">Universal Windows Platform samples (C# and C++)</span></span>](https://go.microsoft.com/fwlink/?linkid=832713)

[<span data-ttu-id="85b60-347">Windows の従来のデスクトップのサンプル</span><span class="sxs-lookup"><span data-stu-id="85b60-347">Windows classic desktop sample</span></span>](https://aka.ms/radialcontrollerclassicsample)