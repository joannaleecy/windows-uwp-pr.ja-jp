---
Description: Design your app so that it looks good and functions well on your television.
title: Xbox およびテレビ向け設計
ms.assetid: 780209cb-3e8a-4cf7-8f80-8b8f449580bf
label: Designing for Xbox and TV
template: detail.hbs
isNew: true
keywords: Xbox, テレビ, 10 フィート エクスペリエンス, ゲームパッド, リモコン, 入力, 操作
ms.date: 11/13/2018
ms.topic: article
pm-contact: chigy
design-contact: jeffarn
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 04a5285c39e46019275b3dd6fb3843d932b53901
ms.sourcegitcommit: 888a4679fa45637b1cc35f62843727ce44322e57
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/06/2019
ms.locfileid: "9059753"
---
# <a name="designing-for-xbox-and-tv"></a><span data-ttu-id="54dc6-103">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="54dc6-103">Designing for Xbox and TV</span></span>

<span data-ttu-id="54dc6-104">Xbox One とテレビ画面で見栄えよく表示され、適切に機能するようにユニバーサル Windows プラットフォーム (UWP) アプリの設計を行います。</span><span class="sxs-lookup"><span data-stu-id="54dc6-104">Design your Universal Windows Platform (UWP) app so that it looks good and functions well on Xbox One and television screens.</span></span>

<span data-ttu-id="54dc6-105">*10 フィート*エクスペリエンスでの UWP アプリケーションで対話式操作エクスペリエンスに関するガイダンスについては、[ゲームパッドとリモコンの操作](../input/gamepad-and-remote-interactions.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-105">See [Gamepad and remote control interactions](../input/gamepad-and-remote-interactions.md) for guidance on interaction experiences in UWP applications in the *10-foot* experience.</span></span>

## <a name="overview"></a><span data-ttu-id="54dc6-106">概要</span><span class="sxs-lookup"><span data-stu-id="54dc6-106">Overview</span></span>

<span data-ttu-id="54dc6-107">ユニバーサル Windows プラットフォームでは、複数の Windows 10 デバイスで魅力的なエクスペリエンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-107">The Universal Windows Platform lets you create delightful experiences across multiple Windows 10 devices.</span></span>
<span data-ttu-id="54dc6-108">UWP フレームワークで提供される機能のほとんどは、追加の作業を行わなくても、これらのデバイス間で同じユーザー インターフェイス (UI) をアプリに使用できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-108">Most of the functionality provided by the UWP framework enables apps to use the same user interface (UI) across these devices, without additional work.</span></span>
<span data-ttu-id="54dc6-109">ただし、Xbox One とテレビ画面で快適に機能するようにアプリを調整し最適化するには、特別な注意事項があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-109">However, tailoring and optimizing your app to work great on Xbox One and TV screens requires special considerations.</span></span>

<span data-ttu-id="54dc6-110">ソファーに座りながらゲームパッドやリモコンを使って部屋の反対側にあるテレビを操作することを、**10 フィート エクスペリエンス**といいます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-110">The experience of sitting on your couch across the room, using a gamepad or remote to interact with your TV, is called the **10-foot experience**.</span></span>
<span data-ttu-id="54dc6-111">通常は画面から約 10 フィート (約 3 m) の距離に座るため、このように呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-111">It is so named because the user is generally sitting approximately 10 feet away from the screen.</span></span>
<span data-ttu-id="54dc6-112">この場合、たとえば PC の操作 (*2 フィート* エクスペリエンスと呼ばれます) には見られない、特有の課題があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-112">This provides unique challenges that aren't present in, say, the *2-foot* experience, or interacting with a PC.</span></span>
<span data-ttu-id="54dc6-113">Xbox One や、コントローラーを使って入力しテレビ画面に出力するその他のデバイス向けアプリを開発している場合、この点を常に意識しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-113">If you are developing an app for Xbox One or any other device that outputs to the TV screen and uses a controller for input, you should always keep this in mind.</span></span>

<span data-ttu-id="54dc6-114">アプリを 10 フィート エクスペリエンス向けに適切に動作させるためにこの記事のすべての手順が必要なわけではありませんが、手順を理解し、アプリにとって何が適切かを判断することで、アプリ特有のニーズに合わせてカスタマイズされた、優れた 10 フィート エクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-114">Not all of the steps in this article are required to make your app work well for 10-foot experiences, but understanding them and making the appropriate decisions for your app will result in a better 10-foot experience tailored for your app's specific needs.</span></span>
<span data-ttu-id="54dc6-115">10 フィート環境でアプリを使う場合、次のデザイン原則を検討してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-115">As you bring your app to life in the 10-foot environment, consider the following design principles.</span></span>

### <a name="simple"></a><span data-ttu-id="54dc6-116">シンプル</span><span class="sxs-lookup"><span data-stu-id="54dc6-116">Simple</span></span>

<span data-ttu-id="54dc6-117">10 フィート環境向けのデザインには特有の課題があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-117">Designing for the 10-foot environment presents a unique set of challenges.</span></span> <span data-ttu-id="54dc6-118">解像度と視聴距離の点から、ユーザーはあまり多くの情報を処理できない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-118">Resolution and viewing distance can make it difficult for people to process too much information.</span></span>
<span data-ttu-id="54dc6-119">単純なデザインになるように、ごくシンプルなコンポーネントだけに絞り込むようにしてください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-119">Try to keep your design clean, reduced to the simplest possible components.</span></span> <span data-ttu-id="54dc6-120">テレビに表示される情報の量は、デスクトップではなく、携帯電話と同程度にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-120">The amount of information displayed on a TV should be comparable to what you'd see on a mobile phone, rather than on a desktop.</span></span>

![Xbox One ホーム画面](images/designing-for-tv/xbox-home-screen.png)

### <a name="coherent"></a><span data-ttu-id="54dc6-122">一貫性</span><span class="sxs-lookup"><span data-stu-id="54dc6-122">Coherent</span></span>

<span data-ttu-id="54dc6-123">10 フィート環境の UWP アプリは、直感的で簡単に使えるようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-123">UWP apps in the 10-foot environment should be intuitive and easy to use.</span></span> <span data-ttu-id="54dc6-124">何がポイントなのかを明快、明確にしてください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-124">Make the focus clear and unmistakable.</span></span>
<span data-ttu-id="54dc6-125">コンテンツの配置を工夫し、コンテンツ間の移動に一貫性を持たせてユーザーが予測できるようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-125">Arrange content so that movement across the space is consistent and predictable.</span></span> <span data-ttu-id="54dc6-126">ユーザーが目的の操作を最短で実行できるように配慮しましょう。</span><span class="sxs-lookup"><span data-stu-id="54dc6-126">Give people the shortest path to what they want to do.</span></span>

![Xbox One 映画アプリ](images/designing-for-tv/xbox-movies-app.png)

_**<span data-ttu-id="54dc6-128">スクリーンショットに示す映画はすべて、Microsoft 映画 & テレビでご利用いただけます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-128">All movies shown in the screenshot are available on Microsoft Movies & TV.</span></span>**_  

### <a name="captivating"></a><span data-ttu-id="54dc6-129">魅力的</span><span class="sxs-lookup"><span data-stu-id="54dc6-129">Captivating</span></span>

<span data-ttu-id="54dc6-130">最もイマーシブで臨場感のあるエクスペリエンスは、大画面で引き出されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-130">The most immersive, cinematic experiences take place on the big screen.</span></span> <span data-ttu-id="54dc6-131">画面いっぱいに広がる風景、洗練された動作、鮮やかな色使い、生き生きとした文字が、アプリをワンランク上に引き上げます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-131">Edge-to-edge scenery, elegant motion, and vibrant use of color and typography take your apps to the next level.</span></span> <span data-ttu-id="54dc6-132">大胆で美しいデザインにしましょう。</span><span class="sxs-lookup"><span data-stu-id="54dc6-132">Be bold and beautiful.</span></span>

![Xbox One アバター アプリ](images/designing-for-tv/xbox-avatar-app.png)

### <a name="optimizations-for-the-10-foot-experience"></a><span data-ttu-id="54dc6-134">10 フィート エクスペリエンス向けの最適化</span><span class="sxs-lookup"><span data-stu-id="54dc6-134">Optimizations for the 10-foot experience</span></span>

<span data-ttu-id="54dc6-135">ここまで、10 フィート エクスペリエンス向けに優れた UWP アプリを設計する原則を説明しました。次に、アプリを最適化して優れたユーザー エクスペリエンスを提供する具体的な方法について、概要を示します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-135">Now that you know the principles of good UWP app design for the 10-foot experience, read through the following overview of the specific ways you can optimize your app and make for a great user experience.</span></span>

| <span data-ttu-id="54dc6-136">機能</span><span class="sxs-lookup"><span data-stu-id="54dc6-136">Feature</span></span>        | <span data-ttu-id="54dc6-137">説明</span><span class="sxs-lookup"><span data-stu-id="54dc6-137">Description</span></span>           |
| -------------------------------------------------------------- |--------------------------------|
| [<span data-ttu-id="54dc6-138">UI 要素のサイズ</span><span class="sxs-lookup"><span data-stu-id="54dc6-138">UI element sizing</span></span>](#ui-element-sizing)  | <span data-ttu-id="54dc6-139">ユニバーサル Windows プラットフォームは、[スケーリングと有効ピクセル](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)を使い、視聴距離に合わせて UI をスケーリングします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-139">The Universal Windows Platform uses [scaling and effective pixels](../basics/design-and-ui-intro.md#effective-pixels-and-scaling) to scale the UI according to the viewing distance.</span></span> <span data-ttu-id="54dc6-140">サイズについて理解し UI 全体に適用すれば、アプリを 10 フィート環境用に最適化するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-140">Understanding sizing and applying it across your UI will help optimize your app for the 10-foot environment.</span></span>  |
|  [<span data-ttu-id="54dc6-141">テレビのセーフ エリア</span><span class="sxs-lookup"><span data-stu-id="54dc6-141">TV-safe area</span></span>](#tv-safe-area) | <span data-ttu-id="54dc6-142">UWP は既定で、テレビのセーフ エリア以外の領域 (画面の端に近い部分) に UI を表示することを自動的に避けます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-142">The UWP will automatically avoid displaying any UI in TV-unsafe areas (areas close to the edges of the screen) by default.</span></span> <span data-ttu-id="54dc6-143">ただし、この場合、アスペクト比が変わり、UI がレターボックス化されてしまいます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-143">However, this creates a "boxed-in" effect in which the UI looks letterboxed.</span></span> <span data-ttu-id="54dc6-144">テレビでイマーシブなアプリにするには、サポートしているテレビで、画面の端まで広がるようにアプリを変更します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-144">For your app to be truly immersive on TV, you will want to modify it so that it extends to the edges of the screen on TVs that support it.</span></span> |
| [<span data-ttu-id="54dc6-145">カラー</span><span class="sxs-lookup"><span data-stu-id="54dc6-145">Colors</span></span>](#colors)  |  <span data-ttu-id="54dc6-146">UWP は配色テーマをサポートしています。システム テーマを引き継ぐアプリは、Xbox One では既定で**濃色**になります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-146">The UWP supports color themes, and an app that respects the system theme will default to **dark** on Xbox One.</span></span> <span data-ttu-id="54dc6-147">アプリに特定の配色テーマがある場合、テレビではうまく表示されないために一部の色を避ける必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-147">If your app has a specific color theme, you should consider that some colors don't work well for TV and should be avoided.</span></span> |
| [<span data-ttu-id="54dc6-148">サウンド</span><span class="sxs-lookup"><span data-stu-id="54dc6-148">Sound</span></span>](../style/sound.md)    | <span data-ttu-id="54dc6-149">サウンドは、ユーザーを没頭させたりユーザーにフィードバックを提供したりする上で役立ち、10 フィート エクスペリエンスで重要な役割を果たします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-149">Sounds play a key role in the 10-foot experience, helping to immerse and give feedback to the user.</span></span> <span data-ttu-id="54dc6-150">UWP には、アプリが Xbox One で実行されているときは一般的なコントロールのサウンドを自動的に有効にする機能があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-150">The UWP provides functionality that automatically turns on sounds for common controls when the app is running on Xbox One.</span></span> <span data-ttu-id="54dc6-151">UWP に組み込まれているサウンド サポートの詳細とその活用方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-151">Find out more about the sound support built into the UWP and learn how to take advantage of it.</span></span>    |
| [<span data-ttu-id="54dc6-152">UI コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="54dc6-152">Guidelines for UI controls</span></span>](#guidelines-for-ui-controls)  |  <span data-ttu-id="54dc6-153">いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-153">There are several UI controls that work well across multiple devices, but have certain considerations when used on TV.</span></span> <span data-ttu-id="54dc6-154">10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-154">Read about some best practices for using these controls when designing for the 10-foot experience.</span></span> |
| [<span data-ttu-id="54dc6-155">Xbox のカスタム表示状態トリガー</span><span class="sxs-lookup"><span data-stu-id="54dc6-155">Custom visual state trigger for Xbox</span></span>](#custom-visual-state-trigger-for-xbox) | <span data-ttu-id="54dc6-156">UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、カスタム*表示状態トリガー*を使用して、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-156">To tailor your UWP app for the 10-foot experience, we recommend that you use a custom *visual state trigger* to make layout changes when the app detects that it has been launched on an Xbox console.</span></span> |

<span data-ttu-id="54dc6-157">だけでなく、前のデザインとレイアウトに関する考慮事項がいくつかの[ゲームパッドとリモコンの対話式操作](../input/gamepad-and-remote-interactions.md)の最適化がアプリをビルドするときに考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-157">In addition to the preceding design and layout considerations, there are a number of [gamepad and remote control interaction](../input/gamepad-and-remote-interactions.md) optimizations you should consider when building your app.</span></span>

| <span data-ttu-id="54dc6-158">機能</span><span class="sxs-lookup"><span data-stu-id="54dc6-158">Feature</span></span>        | <span data-ttu-id="54dc6-159">説明</span><span class="sxs-lookup"><span data-stu-id="54dc6-159">Description</span></span>           |
| -------------------------------------------------------------- |--------------------------------|
| [<span data-ttu-id="54dc6-160">XY フォーカス ナビゲーションと対話式操作</span><span class="sxs-lookup"><span data-stu-id="54dc6-160">XY focus navigation and interaction</span></span>](../input/gamepad-and-remote-interactions.md#xy-focus-navigation-and-interaction) | <span data-ttu-id="54dc6-161">**XY フォーカス ナビゲーション**では、ユーザーがアプリの UI を移動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-161">**XY focus navigation** enables the user to navigate around your app's UI.</span></span> <span data-ttu-id="54dc6-162">ただし、ユーザーの移動は上下左右に制限されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-162">However, this limits the user to navigating up, down, left, and right.</span></span> <span data-ttu-id="54dc6-163">このセクションでは、この点に対応するための推奨事項とその他の考慮事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-163">Recommendations for dealing with this and other considerations are outlined in this section.</span></span> |
| [<span data-ttu-id="54dc6-164">マウス モード</span><span class="sxs-lookup"><span data-stu-id="54dc6-164">Mouse mode</span></span>](../input/gamepad-and-remote-interactions.md#mouse-mode)|<span data-ttu-id="54dc6-165">XY フォーカス ナビゲーションは、実用的なまたはでも可能であれば、マップや描画およびペイント アプリなど、アプリケーションの種類によってはありません。</span><span class="sxs-lookup"><span data-stu-id="54dc6-165">XY focus navigation isn't practical, or even possible, for some types of applications, such as maps or drawing and painting apps.</span></span> <span data-ttu-id="54dc6-166">このような場合では、**マウス モード**は、ユーザーがゲームパッドやリモコン、PC でのマウスと同様に自由に移動を使用できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-166">In these cases, **mouse mode** lets users navigate freely with a gamepad or remote control, just like a mouse on a PC.</span></span>|
| [<span data-ttu-id="54dc6-167">フォーカス表示</span><span class="sxs-lookup"><span data-stu-id="54dc6-167">Focus visual</span></span>](../input/gamepad-and-remote-interactions.md#focus-visual)  | <span data-ttu-id="54dc6-168">フォーカス表示は、現在フォーカスが置かれた UI 要素を強調表示の境界線です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-168">The focus visual is a border that highlights the currently focused UI element.</span></span> <span data-ttu-id="54dc6-169">これにより、ユーザーが間を移動するかとやり取りする UI をすばやく識別です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-169">This helps the user quickly identify the UI they are navigating through or interacting with.</span></span>  |
| [<span data-ttu-id="54dc6-170">フォーカス エンゲージメント</span><span class="sxs-lookup"><span data-stu-id="54dc6-170">Focus engagement</span></span>](../input/gamepad-and-remote-interactions.md#focus-engagement) | <span data-ttu-id="54dc6-171">フォーカス エンゲージメントは、ユーザーに UI 要素にフォーカスがある場合は、操作するために、ゲームパッドやリモコンで**A/選択**] ボタンを押す必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-171">Focus engagement requires the user to press the **A/Select** button on a gamepad or remote control when a UI element has focus in order to interact with it.</span></span> |
| [<span data-ttu-id="54dc6-172">ハードウェア ボタン</span><span class="sxs-lookup"><span data-stu-id="54dc6-172">Hardware buttons</span></span>](../input/gamepad-and-remote-interactions.md#hardware-buttons) | <span data-ttu-id="54dc6-173">ゲームパッドとリモコンは、非常に異なるボタンと構成を提供します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-173">The gamepad and remote control provide very different buttons and configurations.</span></span> |

> [!NOTE]
> <span data-ttu-id="54dc6-174">このトピックで示すコード スニペットはほとんどが XAMLで/c# ですが、基本原則と概念はすべての UWP アプリに共通です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-174">Most of the code snippets in this topic are in XAML/C#; however, the principles and concepts apply to all UWP apps.</span></span> <span data-ttu-id="54dc6-175">Xbox 向けの HTML/JavaScript UWP アプリを開発している場合は、GitHub の [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) ライブラリを参照することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-175">If you're developing an HTML/JavaScript UWP app for Xbox, check out the excellent [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) library on GitHub.</span></span>

## <a name="ui-element-sizing"></a><span data-ttu-id="54dc6-176">UI 要素のサイズ</span><span class="sxs-lookup"><span data-stu-id="54dc6-176">UI element sizing</span></span>

<span data-ttu-id="54dc6-177">10 フィート環境でアプリを使うユーザーは、画面から数フィート離れた場所に座ってリモコンやゲームパッドを使っています。そのため、UI のデザインに関して考慮する必要がある注意事項がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-177">Because the user of an app in the 10-foot environment is using a remote control or gamepad and is sitting several feet away from the screen, there are some UI considerations that need to be factored into your design.</span></span>
<span data-ttu-id="54dc6-178">ユーザーが簡単に要素間を移動したり要素を選んだりできるように、UI があまり雑然とせず、適切なコンテンツの密度になるようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-178">Make sure that the UI has an appropriate content density and is not too cluttered so that the user can easily navigate and select elements.</span></span> <span data-ttu-id="54dc6-179">簡潔さが重要です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-179">Remember: simplicity is key.</span></span>

### <a name="scale-factor-and-adaptive-layout"></a><span data-ttu-id="54dc6-180">拡大縮小率とアダプティブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="54dc6-180">Scale factor and adaptive layout</span></span>

<span data-ttu-id="54dc6-181">**拡大縮小率**は、アプリが実行されているデバイスにおける適切なサイズで UI 要素が表示されることを保証します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-181">**Scale factor** helps with ensuring that UI elements are displayed with the right sizing for the device on which the app is running.</span></span>
<span data-ttu-id="54dc6-182">デスクトップでは、この設定は **[設定] > [システム] > [表示]** からスライダーで値を指定します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-182">On desktop, this setting can be found in **Settings > System > Display** as a sliding value.</span></span>
<span data-ttu-id="54dc6-183">この設定が電話でサポートされている場合、電話にも同じ設定があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-183">This same setting exists on phone as well if the device supports it.</span></span>

![テキスト、アプリ、その他の項目のサイズを変更する](images/designing-for-tv/ui-scaling.png)

<span data-ttu-id="54dc6-185">Xbox One ではこのようなシステム設定はありません。ただし、UWP の UI 要素をテレビ用に適切なサイズにするために、拡大縮小率は既定で **200%** (XAML アプリの場合) および **150%** (HTML アプリの場合) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-185">On Xbox One, there is no such system setting; however, for UWP UI elements to be sized appropriately for TV, they are scaled at a default of **200%** for XAML apps and **150%** for HTML apps.</span></span>
<span data-ttu-id="54dc6-186">他のデバイスで UI 要素のサイズが適切に設定されていれば、テレビでも適切なサイズになります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-186">As long as UI elements are appropriately sized for other devices, they will be appropriately sized for TV.</span></span>
<span data-ttu-id="54dc6-187">Xbox One ではアプリは 1080 p (1920 x 1080 ピクセル) で表示されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-187">Xbox One renders your app at 1080p (1920 x 1080 pixels).</span></span> <span data-ttu-id="54dc6-188">そのため、PC などの他のデバイスからアプリを移植する場合は、[アダプティブ手法](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を利用して 960 x 540 ピクセル、100% のスケーリング (または HTML アプリの場合、1280 x 720 ピクセル、100% のスケーリング) で UI が適切に表示されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-188">Therefore, when bringing an app from other devices such as PC, ensure that the UI looks great at 960 x 540 px at 100% scale (or 1280 x 720 px at 100% scale for HTML apps) utilizing [adaptive techniques](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

<span data-ttu-id="54dc6-189">Xbox 用の設計では、1 つの解像度 (1920 x 1080) だけを考慮すればよいため、PC の設計とは少し異なります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-189">Designing for Xbox is a little different from designing for PC because you only need to worry about one resolution, 1920 x 1080.</span></span>
<span data-ttu-id="54dc6-190">ユーザーがそれ以上の解像度のテレビを使っていても関係ありません。UWP アプリは常に 1080 p に拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-190">It doesn't matter if the user has a TV that has better resolution&mdash;UWP apps will always scale to 1080p.</span></span>

<span data-ttu-id="54dc6-191">また、テレビの解像度に関係なく、アプリが Xbox One で実行されている場合は適切なアセット サイズが 200% (または HTML アプリの場合は 150%) のセットから取得されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-191">Correct asset sizes from the 200% (or 150% for HTML apps) set will also be pulled in for your app when running on Xbox One, regardless of TV resolution.</span></span>

### <a name="content-density"></a><span data-ttu-id="54dc6-192">コンテンツの密度</span><span class="sxs-lookup"><span data-stu-id="54dc6-192">Content density</span></span>

<span data-ttu-id="54dc6-193">アプリを設計する際には、ユーザーは離れた位置から UI を見るということに注意してください。また、リモコンやゲーム コントローラーを使ってアプリを操作するために、マウスやタッチ入力を使うよりも移動に時間がかかることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-193">When designing your app, remember that the user will be viewing the UI from a distance and interacting with it by using a remote or game controller, which takes more time to navigate than using mouse or touch input.</span></span>

#### <a name="sizes-of-ui-controls"></a><span data-ttu-id="54dc6-194">UI コントロールのサイズ</span><span class="sxs-lookup"><span data-stu-id="54dc6-194">Sizes of UI controls</span></span>

<span data-ttu-id="54dc6-195">対話型の UI 要素は、最小の高さである 32 epx (有効ピクセル) でサイズを調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-195">Interactive UI elements should be sized at a minimum height of 32 epx (effective pixels).</span></span> <span data-ttu-id="54dc6-196">これは一般的な UWP コントロールの既定の設定で、拡大縮小率が 200% のときに UI 要素が遠くから確実に見えるようにし、コンテンツの密度を抑えるためのものです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-196">This is the default for common UWP controls, and when used at 200% scale, it ensures that UI elements are visible from a distance and helps reduce content density.</span></span>

![拡大縮小率 100% と 200% の UWP ボタン](images/designing-for-tv/button-100-200.png)

#### <a name="number-of-clicks"></a><span data-ttu-id="54dc6-198">クリックの回数</span><span class="sxs-lookup"><span data-stu-id="54dc6-198">Number of clicks</span></span>

<span data-ttu-id="54dc6-199">UI を簡略化するために、ユーザーがテレビ画面の端から端まで移動するときに、**クリックは 6 回**以内になるようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-199">When the user is navigating from one edge of the TV screen to the other, it should take no more than **six clicks** to simplify your UI.</span></span> <span data-ttu-id="54dc6-200">ここでも**簡潔さ**の原則が重要です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-200">Again, the principle of **simplicity** applies here.</span></span> <span data-ttu-id="54dc6-201">詳しくは、「[最小回数のクリック数](#path-of-least-clicks)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-201">For more details, see [Path of least clicks](#path-of-least-clicks).</span></span>

![6 つのアイコン分の幅](images/designing-for-tv/six-clicks.png)

### <a name="text-sizes"></a><span data-ttu-id="54dc6-203">テキスト サイズ</span><span class="sxs-lookup"><span data-stu-id="54dc6-203">Text sizes</span></span>

<span data-ttu-id="54dc6-204">UI を離れた位置から見えるようにするために、次の経験則に従ってください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-204">To make your UI visible from a distance, use the following rules of thumb:</span></span>

* <span data-ttu-id="54dc6-205">メイン テキストと読解コンテンツ: 最小 15 epx</span><span class="sxs-lookup"><span data-stu-id="54dc6-205">Main text and reading content: 15 epx minimum</span></span>
* <span data-ttu-id="54dc6-206">不可欠ではないテキストと補助コンテンツ: 最小 12 epx</span><span class="sxs-lookup"><span data-stu-id="54dc6-206">Non-critical text and supplemental content: 12 epx minimum</span></span>

<span data-ttu-id="54dc6-207">UI でさらに大きなテキストを使う場合は、画面領域をあまり狭めないサイズを選び、他のコンテンツのためのスペースを圧迫しないようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-207">When using larger text in your UI, pick a size that does not limit screen real estate too much, taking up space that other content could potentially fill.</span></span>

### <a name="opting-out-of-scale-factor"></a><span data-ttu-id="54dc6-208">拡大縮小率の無効化</span><span class="sxs-lookup"><span data-stu-id="54dc6-208">Opting out of scale factor</span></span>

<span data-ttu-id="54dc6-209">アプリでは拡大縮小率のサポートを利用することをお勧めします。この機能は、各デバイスの種類に合わせて拡大縮小することで、すべてのデバイスでアプリを適切に実行するためのものです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-209">We recommend that your app take advantage of scale factor support, which will help it run appropriately on all devices by scaling for each device type.</span></span>
<span data-ttu-id="54dc6-210">しかし、この動作を無効にして、すべての UI を 100% の拡大縮小率で設計することもできます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-210">However, it is possible to opt out of this behavior and design all of your UI at 100% scale.</span></span> <span data-ttu-id="54dc6-211">100% 以外の拡大縮小率には変更できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-211">Note that you cannot change the scale factor to anything other than 100%.</span></span>

<span data-ttu-id="54dc6-212">XAML アプリでは、次のコード スニペットを使って倍率を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-212">For XAML apps, you can opt out of scale factor by using the following code snippet:</span></span>

```csharp
bool result =
    Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```

`result` <span data-ttu-id="54dc6-213">無効化に成功したかどうかが通知されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-213">will inform you whether you successfully opted out.</span></span>

<span data-ttu-id="54dc6-214">HTML/JavaScript のサンプル コードなどの詳細情報については、「[スケーリングを無効にする方法](../../xbox-apps/disable-scaling.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-214">For more information, including sample code for HTML/JavaScript, see [How to turn off scaling](../../xbox-apps/disable-scaling.md).</span></span>

<span data-ttu-id="54dc6-215">UI 要素の適切なサイズを計算するときに、このトピックで説明した*有効*ピクセルの値を倍にして (または HTML アプリの場合は 1.5 倍にして) *実際*のピクセル値にすることを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-215">Please be sure to calculate the appropriate sizes of UI elements by doubling the *effective* pixel values mentioned in this topic to *actual* pixel values (or multiplying by 1.5 for HTML apps).</span></span>

## <a name="tv-safe-area"></a><span data-ttu-id="54dc6-216">テレビのセーフ エリア</span><span class="sxs-lookup"><span data-stu-id="54dc6-216">TV-safe area</span></span>

<span data-ttu-id="54dc6-217">歴史的な経緯や技術的な理由により、すべてのテレビで画面の端までコンテンツが表示されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="54dc6-217">Not all TVs display content all the way to the edges of the screen due to historical and technological reasons.</span></span> <span data-ttu-id="54dc6-218">既定では、UWP はテレビのセーフ エリア以外に UI コンテンツを表示せず、ページの背景のみを描画します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-218">By default, the UWP will avoid displaying any UI content in TV-unsafe areas and instead will only draw the page background.</span></span>

<span data-ttu-id="54dc6-219">次の図に、テレビのセーフ エリア以外の領域を青色で示します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-219">The TV-unsafe area is represented by the blue area in the following image.</span></span>

![テレビのセーフ エリア以外の領域](images/designing-for-tv/tv-unsafe-area.png)

<span data-ttu-id="54dc6-221">次のコード スニペットに示すように、背景は静的な色、テーマの色、または画像に設定できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-221">You can set the background to a static or themed color, or to an image, as the following code snippets demonstrate.</span></span>

### <a name="theme-color"></a><span data-ttu-id="54dc6-222">テーマの色</span><span class="sxs-lookup"><span data-stu-id="54dc6-222">Theme color</span></span>

```xml
<Page x:Class="Sample.MainPage"
      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"/>
```

### <a name="image"></a><span data-ttu-id="54dc6-223">画像</span><span class="sxs-lookup"><span data-stu-id="54dc6-223">Image</span></span>

```xml
<Page x:Class="Sample.MainPage"
      Background="\Assets\Background.png"/>
```

<span data-ttu-id="54dc6-224">追加の作業を行わない場合、アプリは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-224">This is what your app will look like without additional work.</span></span>

![テレビのセーフ エリア](images/designing-for-tv/tv-safe-area.png)

<span data-ttu-id="54dc6-226">この場合、アプリのアスペクト比が変わり、ナビゲーション ウィンドウやグリッドなど UI の一部が切れて表示されるため、最適とはいえません。</span><span class="sxs-lookup"><span data-stu-id="54dc6-226">This is not optimal because it gives the app a "boxed-in" effect, with parts of the UI such as the nav pane and grid seemingly cut off.</span></span> <span data-ttu-id="54dc6-227">ただし、UI の一部を画面の端まで拡張し、アプリに映画のような効果を持たせることで最適化することができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-227">However, you can make optimizations to extend parts of the UI to the edges of the screen to give the app a more cinematic effect.</span></span>

### <a name="drawing-ui-to-the-edge"></a><span data-ttu-id="54dc6-228">端までの UI の描画</span><span class="sxs-lookup"><span data-stu-id="54dc6-228">Drawing UI to the edge</span></span>

<span data-ttu-id="54dc6-229">ユーザーに没入感を提供するために、特定の UI 要素を使って画面の端まで拡張することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-229">We recommend that you use certain UI elements to extend to the edges of the screen to provide more immersion to the user.</span></span> <span data-ttu-id="54dc6-230">[ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer)、[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)、[CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) などを使えます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-230">These include [ScrollViewers](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer), [nav panes](../controls-and-patterns/navigationview.md), and [CommandBars](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar).</span></span>

<span data-ttu-id="54dc6-231">一方、対話型の要素とテキストは画面の端に表示されることを常に避け、一部のテレビで表示が切れないようにすることも重要です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-231">On the other hand, it's also important that interactive elements and text always avoid the screen edges to ensure that they won't be cut off on some TVs.</span></span> <span data-ttu-id="54dc6-232">画面の端 5% 以内には重要でない視覚効果のみを描画することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-232">We recommend that you draw only non-essential visuals within 5% of the screen edges.</span></span> <span data-ttu-id="54dc6-233">「[UI 要素のサイズ](#ui-element-sizing)」で説明したように、Xbox One コンソールの既定の拡大縮小率 200% に従っている UWP アプリは、960 x 540 epx の領域を使います。そのため、アプリの UI では重要な UI を以下の領域に置かないようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-233">As mentioned in [UI element sizing](#ui-element-sizing), a UWP app following the Xbox One console's default scale factor of 200% will utilize an area of 960 x 540 epx, so in your app's UI, you should avoid putting essential UI in the following areas:</span></span>

- <span data-ttu-id="54dc6-234">上部と下部から 27 epx</span><span class="sxs-lookup"><span data-stu-id="54dc6-234">27 epx from the top and bottom</span></span>
- <span data-ttu-id="54dc6-235">左側と右側から 48 epx</span><span class="sxs-lookup"><span data-stu-id="54dc6-235">48 epx from the left and right sides</span></span>

<span data-ttu-id="54dc6-236">以下のセクションでは、UI を画面の端まで広げる方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-236">The following sections describe how to make your UI extend to the screen edges.</span></span>

#### <a name="core-window-bounds"></a><span data-ttu-id="54dc6-237">コア ウィンドウの境界</span><span class="sxs-lookup"><span data-stu-id="54dc6-237">Core window bounds</span></span>

<span data-ttu-id="54dc6-238">10 フィート エクスペリエンスのみを対象とする UWP アプリでは、コア ウィンドウの境界を使う方が簡単です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-238">For UWP apps targeting only the 10-foot experience, using core window bounds is a more straightforward option.</span></span>

<span data-ttu-id="54dc6-239">`App.xaml.cs` の `OnLaunched` メソッドで、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-239">In the `OnLaunched` method of `App.xaml.cs`, add the following code:</span></span>

```csharp
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode
    (Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```

<span data-ttu-id="54dc6-240">このコード行で、アプリ ウィンドウは画面の端まで拡張されます。そのため、前に説明したテレビのセーフ エリアへ、すべての対話型 UI と重要な UI を移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-240">With this line of code, the app window will extend to the edges of the screen, so you will need to move all interactive and essential UI into the TV-safe area described earlier.</span></span> <span data-ttu-id="54dc6-241">コンテキスト メニューや開かれた状態の [ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox) などの一時的な UI は、テレビのセーフ エリア内に自動的に残ります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-241">Transient UI, such as context menus and opened [ComboBoxes](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox), will automatically remain inside the TV-safe area.</span></span>

![コア ウィンドウの境界](images/designing-for-tv/core-window-bounds.png)

#### <a name="pane-backgrounds"></a><span data-ttu-id="54dc6-243">ウィンドウの背景</span><span class="sxs-lookup"><span data-stu-id="54dc6-243">Pane backgrounds</span></span>

<span data-ttu-id="54dc6-244">通常、ナビゲーション ウィンドウは画面の端近くに描画されるため、不自然なギャップが入らないように背景をテレビのセーフ エリア以外まで広げる必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-244">Navigation panes are typically drawn near the edge of the screen, so the background should extend into the TV-unsafe area so as not to introduce awkward gaps.</span></span> <span data-ttu-id="54dc6-245">ナビゲーション ウィンドウの背景の色をアプリの背景の色に変更するだけで、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-245">You can do this by simply changing the color of the nav pane's background to the color of the app's background.</span></span>

<span data-ttu-id="54dc6-246">既に説明したように、コア ウィンドウの境界を使用すると、画面の端まで UI を描画することができますが、さらに [SplitView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SplitView) のコンテンツで正の余白を使用してコンテンツがテレビ セーフ エリア内に収まるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-246">Using the core window bounds as previously described will allow you to draw your UI to the edges of the screen, but you should then use positive margins on the [SplitView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SplitView)'s content to keep it within the TV-safe area.</span></span>

![画面の端まで拡張されたナビゲーション ウィンドウ](images/designing-for-tv/tv-safe-areas-2.png)

<span data-ttu-id="54dc6-248">ここでは、ナビゲーション ウィンドウの背景は画面の端まで拡張され、ナビゲーション項目はテレビのセーフ エリア内に収まっています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-248">Here, the nav pane's background has been extended to the edges of the screen, while its navigation items are kept in the TV-safe area.</span></span>
<span data-ttu-id="54dc6-249">`SplitView` のコンテンツ (この場合は項目のグリッド) は、途切れずに続いているように見せるために、画面の下部まで拡張されています。一方、グリッドの上部はテレビのセーフ エリア内に収まったままです </span><span class="sxs-lookup"><span data-stu-id="54dc6-249">The content of the `SplitView` (in this case, a grid of items) has been extended to the bottom of the screen so that it looks like it continues and isn't cut off, while the top of the grid is still within the TV-safe area.</span></span> <span data-ttu-id="54dc6-250">(この方法ついて詳しくは、「[リストとグリッドのスクロールの端](#scrolling-ends-of-lists-and-grids)」で説明します)。</span><span class="sxs-lookup"><span data-stu-id="54dc6-250">(Learn more about how to do this in [Scrolling ends of lists and grids](#scrolling-ends-of-lists-and-grids)).</span></span>

<span data-ttu-id="54dc6-251">次のコード スニペットでは、この効果を実現します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-251">The following code snippet achieves this effect:</span></span>

```xml
<SplitView x:Name="RootSplitView"
           Margin="48,0,48,0">
    <SplitView.Pane>
        <ListView x:Name="NavMenuList"
                  ContainerContentChanging="NavMenuItemContainerContentChanging"
                  ItemContainerStyle="{StaticResource NavMenuItemContainerStyle}"
                  ItemTemplate="{StaticResource NavMenuItemTemplate}"
                  ItemInvoked="NavMenuList_ItemInvoked"
                  ItemsSource="{Binding NavMenuListItems}"/>
    </SplitView.Pane>
    <Frame x:Name="frame"
           Navigating="OnNavigatingToPage"
           Navigated="OnNavigatedToPage"/>
</SplitView>
```

<span data-ttu-id="54dc6-252">[CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) も、アプリの 1 つまたは複数の端の近くに置かれることが多いウィンドウの例ですが、そのためにテレビではその背景を画面の端まで拡張する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-252">[CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) is another example of a pane that is commonly positioned near one or more edges of the app, and as such on TV its background should extend to the edges of the screen.</span></span> <span data-ttu-id="54dc6-253">これには通常、**[その他]** ボタンも含まれます。[その他] ボタンは右側に表示する "..." で表し、テレビのセーフ エリア内に収める必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-253">It also usually contains a **More** button, represented by "..." on the right side, which should remain in the TV-safe area.</span></span> <span data-ttu-id="54dc6-254">目的の操作と視覚効果を実現するためのいくつかの異なる方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-254">The following are a few different strategies to achieve the desired interactions and visual effects.</span></span>

<span data-ttu-id="54dc6-255">**オプション 1**: `CommandBar` の背景色を透明またはページの背景と同じ色に変更します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-255">**Option 1**: Change the `CommandBar` background color to either transparent or the same color as the page background:</span></span>

```xml
<CommandBar x:Name="topbar"
            Background="{ThemeResource SystemControlBackgroundAltHighBrush}">
            ...
</CommandBar>
```

<span data-ttu-id="54dc6-256">これで、`CommandBar` がページの残りの部分と同じ背景の上にあるように見え、背景が画面の端まで切れ目なく続きます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-256">Doing this will make the `CommandBar` look like it is on top of the same background as the rest of the page, so the background seamlessly flows to the edge of the screen.</span></span>

<span data-ttu-id="54dc6-257">**オプション 2**: `CommandBar` の背景と同じ色で塗りつぶした背景の四角形を追加し、その四角形を `CommandBar` の下、ページの残りの部分に配置します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-257">**Option 2**: Add a background rectangle whose fill is the same color as the `CommandBar` background, and have it lie below the `CommandBar` and across the rest of the page:</span></span>

```xml
<Rectangle VerticalAlignment="Top"
            HorizontalAlignment="Stretch"      
            Fill="{ThemeResource SystemControlBackgroundChromeMediumBrush}"/>
<CommandBar x:Name="topbar"
            VerticalAlignment="Top"
            HorizontalContentAlignment="Stretch">
            ...
</CommandBar>
```

> [!NOTE]
> <span data-ttu-id="54dc6-258">この方法を使う場合、アイコンの下に `AppBarButton` のラベルを表示できるように、開いた状態の `CommandBar` の高さが **[その他]** ボタンによって必要に応じて変更されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-258">If using this approach, be aware that the **More** button changes the height of the opened `CommandBar` if necessary, in order to show the labels of the `AppBarButton`s below their icons.</span></span> <span data-ttu-id="54dc6-259">サイズ変更を避けるために、アイコンの*右側*へラベルを移動することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-259">We recommend that you move the labels to the *right* of their icons to avoid this resizing.</span></span> <span data-ttu-id="54dc6-260">詳しくは、「[CommandBar のラベル](#commandbar-labels)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-260">For more information, see [CommandBar labels](#commandbar-labels).</span></span>

<span data-ttu-id="54dc6-261">これらのアプローチはいずれも、このセクションに示されている他の種類のコントロールにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-261">Both of these approaches also apply to the other types of controls listed in this section.</span></span>

#### <a name="scrolling-ends-of-lists-and-grids"></a><span data-ttu-id="54dc6-262">リストとグリッドのスクロールの端</span><span class="sxs-lookup"><span data-stu-id="54dc6-262">Scrolling ends of lists and grids</span></span>

<span data-ttu-id="54dc6-263">リストとグリッドに一度に画面に表示できるよりも多くの項目を含めることはよくあります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-263">It's common for lists and grids to contain more items than can fit onscreen at the same time.</span></span> <span data-ttu-id="54dc6-264">この場合、リストまたはグリッドを画面の端まで拡張することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-264">When this is the case, we recommend that you extend the list or grid to the edge of the screen.</span></span> <span data-ttu-id="54dc6-265">リストとグリッドを横方向にスクロールする場合は右端まで、垂直方向にスクロールする場合は一番下まで拡張するようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-265">Horizontally scrolling lists and grids should extend to the right edge, and vertically scrolling ones should extend to the bottom.</span></span>

![テレビのセーフ エリアでのグリッドの切り捨て](images/designing-for-tv/tv-safe-area-grid-cutoff.png)

<span data-ttu-id="54dc6-267">リストまたはグリッドは次のように拡張されますが、フォーカス表示とその関連項目をテレビのセーフ エリア内に収めることが重要です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-267">While a list or grid is extended like this, it's important to keep the focus visual and its associated item inside the TV-safe area.</span></span>

![グリッドのフォーカスのスクロールをテレビのセーフ エリア内に収める](images/designing-for-tv/scrolling-grid-focus.png)

<span data-ttu-id="54dc6-269">UWP にはフォーカス表示を [VisibleBounds](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview.visiblebounds) 内に保持する機能がありますが、リストやグリッドの項目をセーフ エリアの表示領域内までスクロールできるように余白を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-269">The UWP has functionality that will keep the focus visual inside the [VisibleBounds](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview.visiblebounds), but you need to add padding to ensure that the list/grid items can scroll into view of the safe area.</span></span> <span data-ttu-id="54dc6-270">具体的には、次のコード スニペットのように、[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) または [GridView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.GridView) の [ItemsPresenter](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ItemsPresenter) に正の余白を追加します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-270">Specifically, you add a positive margin to the [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) or [GridView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.GridView)'s [ItemsPresenter](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ItemsPresenter), as in the following code snippet:</span></span>

```xml
<Style x:Key="TitleSafeListViewStyle"
       TargetType="ListView">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ListView">
                <Border BorderBrush="{TemplateBinding BorderBrush}"
                        Background="{TemplateBinding Background}"
                        BorderThickness="{TemplateBinding BorderThickness}">
                    <ScrollViewer x:Name="ScrollViewer"
                                  TabNavigation="{TemplateBinding TabNavigation}"
                                  HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}"
                                  HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                                  IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}"
                                  VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}"
                                  VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}"
                                  IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}"
                                  IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}"
                                  IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}"
                                  ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}"
                                  IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}"
                                  BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}"
                                  AutomationProperties.AccessibilityView="Raw">
                        <ItemsPresenter Header="{TemplateBinding Header}"
                                        HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                        HeaderTransitions="{TemplateBinding HeaderTransitions}"
                                        Footer="{TemplateBinding Footer}"
                                        FooterTemplate="{TemplateBinding FooterTemplate}"
                                        FooterTransitions="{TemplateBinding FooterTransitions}"
                                        Padding="{TemplateBinding Padding}"
                                        Margin="0,27,0,27"/>
                    </ScrollViewer>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

<span data-ttu-id="54dc6-271">前のコード スニペットをページまたはアプリのリソースに含め、次のようにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-271">You would put the previous code snippet in either the page or app resources, and then access it in the following way:</span></span>

```xml
<Page>
    <Grid>
        <ListView Style="{StaticResource TitleSafeListViewStyle}"
                  ... />
```

> [!NOTE]
> <span data-ttu-id="54dc6-272">このコード スニペットは `ListView` 専用です。`GridView` のスタイルの場合、[ControlTemplate](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ControlTemplate) と [Style](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Style) の両方の [TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype) 属性を `GridView` に設定します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-272">This code snippet is specifically for `ListView`s; for a `GridView` style, set the [TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype) attribute for both the [ControlTemplate](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ControlTemplate) and the [Style](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Style) to `GridView`.</span></span>

<span data-ttu-id="54dc6-273">方法をより細かく管理の項目をビューに読み込むは、アプリケーションがバージョン 1803 をターゲットとする[UIElement.BringIntoViewRequested イベント](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.bringintoviewrequested)を使用した後で場合。</span><span class="sxs-lookup"><span data-stu-id="54dc6-273">For more fine-grained control over how items are brought into view, if your application targets version 1803 or later, you can use the [UIElement.BringIntoViewRequested event](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.bringintoviewrequested).</span></span> <span data-ttu-id="54dc6-274">**ListView**の[ItemsPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemspanel)に配置できる/**GridView**内部**ScrollViewer**は、次のコード スニペットに示すように前に、それをキャッチします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-274">You can put it on the [ItemsPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemspanel) for the **ListView**/**GridView** to catch it before the internal **ScrollViewer** does, as in the following code snippets:</span></span>

```xaml
<GridView x:Name="gridView">
    <GridView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsWrapGrid Orientation="Horizontal"
                           BringIntoViewRequested="ItemsWrapGrid_BringIntoViewRequested"/>
        </ItemsPanelTemplate>
    </GridView.ItemsPanel>
</GridView>
```

```cs
// The BringIntoViewRequested event is raised by the framework when items receive keyboard (or Narrator) focus or 
// someone triggers it with a call to UIElement.StartBringIntoView.
private void ItemsWrapGrid_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
{
    if (args.VerticalAlignmentRatio != 0.5)  // Guard against our own request
    {
        args.Handled = true;
        // Swallow this request and restart it with a request to center the item.  We could instead have chosen
        // to adjust the TargetRect’s Y and Height values to add a specific amount of padding as it bubbles up, 
        // but if we just want to center it then this is easier.

        // (Optional) Account for sticky headers if they exist
        var headerOffset = 0.0;
        var itemsWrapGrid = sender as ItemsWrapGrid;
        if (gridView.IsGrouping && itemsWrapGrid.AreStickyGroupHeadersEnabled)
        {
            var header = gridView.GroupHeaderContainerFromItemContainer(args.TargetElement as GridViewItem);
            if (header != null)
            {
                headerOffset = ((FrameworkElement)header).ActualHeight;
            }
        }

        // Issue a new request
        args.TargetElement.StartBringIntoView(new BringIntoViewOptions()
        {
            AnimationDesired = true,
            VerticalAlignmentRatio = 0.5, // a normalized alignment position (0 for the top, 1 for the bottom)
            VerticalOffset = headerOffset, // applied after meeting the alignment ratio request
        });
    }
}
```

## <a name="colors"></a><span data-ttu-id="54dc6-275">カラー</span><span class="sxs-lookup"><span data-stu-id="54dc6-275">Colors</span></span>

<span data-ttu-id="54dc6-276">既定では、アプリが適切に表示されるように、ユニバーサル Windows プラットフォームはアプリの色をテレビ セーフの範囲 (詳しくは「[テレビ セーフ カラー](#tv-safe-colors)」を参照) に対応させています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-276">By default, the Universal Windows Platform scales your app's colors to the TV-safe range (see [TV-safe colors](#tv-safe-colors) for more information) so that your app looks good on any TV.</span></span> <span data-ttu-id="54dc6-277">また、テレビでの視覚エクスペリエンスを向上させるために、アプリで使う色のセットを改善できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-277">In addition, there are improvements that you can make to the set of colors your app uses to improve the visual experience on TV.</span></span>

### <a name="application-theme"></a><span data-ttu-id="54dc6-278">アプリケーション テーマ</span><span class="sxs-lookup"><span data-stu-id="54dc6-278">Application theme</span></span>

<span data-ttu-id="54dc6-279">アプリに合わせて適切な**アプリケーション テーマ** (濃色または淡色) を選ぶか、テーマを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-279">You can choose an **Application theme** (dark or light) according to what is right for your app, or you can opt out of theming.</span></span> <span data-ttu-id="54dc6-280">テーマの一般的な推奨事項については、「[配色テーマ](../style/color.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-280">Read more about general recommendations for themes in [Color themes](../style/color.md).</span></span>

<span data-ttu-id="54dc6-281">UWP では、アプリが実行されているデバイスから提供されるシステム設定に基づいて、アプリでテーマを動的に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-281">The UWP also allows apps to dynamically set the theme based on the system settings provided by the devices on which they run.</span></span>
<span data-ttu-id="54dc6-282">UWP では、ユーザーが指定したテーマ設定が常に適用されますが、各デバイスは、適切な既定のテーマも提供します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-282">While the UWP always respects the theme settings specified by the user, each device also provides an appropriate default theme.</span></span>
<span data-ttu-id="54dc6-283">Xbox One はその性質上、*生産性*エクスペリエンスよりも*メディア* エクスペリエンスを期待されているため、既定で濃色のシステム テーマに設定されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-283">Because of the nature of Xbox One, which is expected to have more *media* experiences than *productivity* experiences, it defaults to a dark system theme.</span></span>
<span data-ttu-id="54dc6-284">アプリのテーマがシステム設定を基にしている場合、Xbox One では既定で濃色に設定されるはずです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-284">If your app's theme is based on the system settings, expect it to default to dark on Xbox One.</span></span>

### <a name="accent-color"></a><span data-ttu-id="54dc6-285">アクセント カラー</span><span class="sxs-lookup"><span data-stu-id="54dc6-285">Accent color</span></span>

<span data-ttu-id="54dc6-286">UWP には、ユーザーがシステム設定から選んだ**アクセント カラー**を公開する便利な方法が用意されています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-286">The UWP provides a convenient way to expose the **accent color** that the user has selected from their system settings.</span></span>

<span data-ttu-id="54dc6-287">PC でアクセント カラーを選べるように、ユーザーは Xbox One でユーザーの色を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-287">On Xbox One, the user is able to select a user color, just as they can select an accent color on a PC.</span></span>
<span data-ttu-id="54dc6-288">アプリでブラシやカラー リソースからこれらのアクセント カラーを呼び出していれば、ユーザーがシステム設定で選んだ色が使われます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-288">As long as your app calls these accent colors through brushes or color resources, the color that the user selected in the system settings will be used.</span></span> <span data-ttu-id="54dc6-289">Xbox One ではアクセント カラーはシステムごとではなくユーザーごとであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-289">Note that accent colors on Xbox One are per user, not per system.</span></span>

<span data-ttu-id="54dc6-290">また、Xbox One と PC、電話、その他のデバイスでは、ユーザーの色のセットが異なることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-290">Please also note that the set of user colors on Xbox One is not the same as that on PCs, phones, and other devices.</span></span>

<span data-ttu-id="54dc6-291">アプリで **SystemControlForegroundAccentBrush** などのブラシ リソースやカラー リソース (**SystemAccentColor**) を使うか、代わりに [UIColorType.Accent\*](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) API からアクセント カラーを直接呼び出していれば、これらの色は Xbox One で利用可能なアクセント カラーに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-291">As long as your app uses a brush resource such as **SystemControlForegroundAccentBrush**, or a color resource (**SystemAccentColor**), or instead calls accent colors directly through the [UIColorType.Accent\*](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) API, those colors are replaced with accent colors available on Xbox One.</span></span> <span data-ttu-id="54dc6-292">ハイ コントラストのブラシの色も、PC や電話と同じ方法でシステムから取得されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-292">High contrast brush colors are also pulled in from the system the same way as on a PC and phone.</span></span>

<span data-ttu-id="54dc6-293">アクセント カラー全般について詳しくは、「[アクセント カラー](../style/color.md#accent-color)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-293">To learn more about accent color in general, see [Accent color](../style/color.md#accent-color).</span></span>

### <a name="color-variance-among-tvs"></a><span data-ttu-id="54dc6-294">テレビごとのカラーの変化</span><span class="sxs-lookup"><span data-stu-id="54dc6-294">Color variance among TVs</span></span>

<span data-ttu-id="54dc6-295">テレビ向けに設計するときには、レンダリングされるテレビごとに色の表示が大きく異なることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-295">When designing for TV, note that colors display quite differently depending on the TV on which they are rendered.</span></span> <span data-ttu-id="54dc6-296">モニター上とまったく同じ色に見えるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="54dc6-296">Don't assume colors will look exactly as they do on your monitor.</span></span> <span data-ttu-id="54dc6-297">アプリで UI の各部を区別するために色のわずかな違いを利用している場合、色が混ざり合ってユーザーが混乱する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-297">If your app relies on subtle differences in color to differentiate parts of the UI, colors could blend together and users could get confused.</span></span> <span data-ttu-id="54dc6-298">どのテレビであっても、ユーザーがはっきり区別できる違いがある色を使うようにしてください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-298">Try to use colors that are different enough that users will be able to clearly differentiate them, regardless of the TV they are using.</span></span>

### <a name="tv-safe-colors"></a><span data-ttu-id="54dc6-299">テレビ セーフ カラー</span><span class="sxs-lookup"><span data-stu-id="54dc6-299">TV-safe colors</span></span>

<span data-ttu-id="54dc6-300">色の RGB 値は、赤、緑、青の輝度を表します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-300">A color's RGB values represent intensities for red, green, and blue.</span></span> <span data-ttu-id="54dc6-301">テレビでは、極端な輝度をあまりうまく処理できません。不自然な縞模様になったり、一部のテレビでは色あせて表示されたりする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-301">TVs don't handle extreme intensities very well&mdash;they can produce an odd banded effect, or appear washed out on certain TVs.</span></span> <span data-ttu-id="54dc6-302">また、高輝度色はブルーミング (隣接するピクセルが同じ色を描画する現象) を起こす可能性があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-302">Additionally, high-intensity colors may cause blooming (nearby pixels start drawing the same colors).</span></span> <span data-ttu-id="54dc6-303">どのような色をテレビ セーフ カラーと見なすかについてはいくつかの考え方がありますが、一般に、RGB 値 16 ～ 235 (16 進数では 10 ～ EB) の色はテレビで使っても安全です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-303">While there are different schools of thought in what are considered TV-safe colors, colors within the RGB values of 16-235 (or 10-EB in hexadecimal) are generally safe to use for TV.</span></span>

![テレビ セーフ カラーの範囲](images/designing-for-tv/tv-safe-colors-2.png)

<span data-ttu-id="54dc6-305">従来、Xbox 上のアプリは、この "テレビ セーフ" カラーの範囲内に収まるように色を調整する必要がありました。ただし、Fall Creators Update 以降、Xbox One はすべての範囲のコンテンツをテレビ セーフ範囲に自動的に対応させています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-305">Historically, apps on Xbox had to tailor their colors to fall within this "TV-safe" color range; however, starting with the Fall Creators Update, Xbox One automatically scales full range content into the TV-safe range.</span></span> <span data-ttu-id="54dc6-306">つまり、ほとんどのアプリ開発者がテレビ セーフ カラーについて心配する必要がなくなりました。</span><span class="sxs-lookup"><span data-stu-id="54dc6-306">This means that most app developers no longer have to worry about TV-safe colors.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="54dc6-307">既にテレビ セーフ カラーの範囲内にあるビデオ コンテンツは、[メディア ファンデーション](https://docs.microsoft.com/windows/desktop/medfound/microsoft-media-foundation-sdk) を使用して再生する場合、このカラー スケール効果は適用されません。</span><span class="sxs-lookup"><span data-stu-id="54dc6-307">Video content that's already in the TV-safe color range doesn't have this color scaling effect applied when played back using [Media Foundation](https://docs.microsoft.com/windows/desktop/medfound/microsoft-media-foundation-sdk).</span></span>

<span data-ttu-id="54dc6-308">DirectX 11 または DirectX 12 を使ってアプリを開発し、UI またはビデオをレンダリングするために独自のスワップ チェーンを作成している場合、[IDXGISwapChain3::SetColorSpace1](https://docs.microsoft.com/windows/desktop/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-setcolorspace1) を呼び出して使用する色空間を指定できるため、色の操作が必要かどうかをシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-308">If you're developing an app using DirectX 11 or DirectX 12 and creating your own swap chain to render UI or video, you can specify the color space you use by calling [IDXGISwapChain3::SetColorSpace1](https://docs.microsoft.com/windows/desktop/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-setcolorspace1), which will let the system know if it needs to scale colors or not.</span></span>

## <a name="guidelines-for-ui-controls"></a><span data-ttu-id="54dc6-309">UI コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="54dc6-309">Guidelines for UI controls</span></span>

<span data-ttu-id="54dc6-310">いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-310">There are several UI controls that work well across multiple devices, but have certain considerations when used on TV.</span></span> <span data-ttu-id="54dc6-311">10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-311">Read about some best practices for using these controls when designing for the 10-foot experience.</span></span>

### <a name="pivot-control"></a><span data-ttu-id="54dc6-312">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="54dc6-312">Pivot control</span></span>

<span data-ttu-id="54dc6-313">[ピボット](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)は、別のヘッダーやタブを選択することにより、アプリ内でビューのすばやいナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-313">A [Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot) provides quick navigation of views within an app through selecting different headers or tabs.</span></span> <span data-ttu-id="54dc6-314">このコントロールでは、フォーカスがあるヘッダーに下線が引かれ、ゲームパッド/リモコンを使用している場合に、現在選択されているヘッダーがわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-314">The control underlines whichever header has focus, making it more obvious which header is currently selected when using gamepad/remote.</span></span>

![ピボットの下線](images/designing-for-tv/pivot-underline.png)

<span data-ttu-id="54dc6-316">[Pivot.IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pivot.isheaderitemscarouselenabledproperty) プロパティを `true` に設定すると、選択したピボット ヘッダーが常に最初の位置に移動する代わりに、ピボットが常に同じ位置に固定されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-316">You can set the [Pivot.IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pivot.isheaderitemscarouselenabledproperty) property to `true` so that pivots always keep the same position, rather than having the selected pivot header always move to the first position.</span></span> <span data-ttu-id="54dc6-317">ヘッダーの折り返しを煩わしいと感じるユーザーもいるため、これでテレビなどの大画面表示でエクスペリエンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-317">This is a better experience for large-screen displays such as TV, because header wrapping can be distracting to users.</span></span> <span data-ttu-id="54dc6-318">すべてのピボット ヘッダーが同時に画面に収まらない場合、ユーザーは表示されるスクロール バーを使って他のヘッダーを表示できますが、最良のエクスペリエンスを提供するためには、すべてのピボット ヘッダーが画面に収まることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-318">If all of the pivot headers don't fit onscreen at once, there will be a scrollbar to let customers see the other headers; however, you should make sure that they all fit on the screen to provide the best experience.</span></span> <span data-ttu-id="54dc6-319">詳しくは、「[タブとピボット](../controls-and-patterns/tabs-pivot.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-319">For more information, see [Tabs and pivots](../controls-and-patterns/tabs-pivot.md).</span></span>

### <a name="navigation-pane-a-namenavigation-pane-"></a><span data-ttu-id="54dc6-320">ナビゲーション ウィンドウ <a name="navigation-pane" /></span><span class="sxs-lookup"><span data-stu-id="54dc6-320">Navigation pane <a name="navigation-pane" /></span></span>

<span data-ttu-id="54dc6-321">ナビゲーション ウィンドウ (*ハンバーガー メニュー*とも呼ばれる) は、UWP アプリでよく使われるナビゲーション コントロールです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-321">A navigation pane (also known as a *hamburger menu*) is a navigation control commonly used in UWP apps.</span></span> <span data-ttu-id="54dc6-322">通常、リスト スタイルのメニューから選択できる複数のオプションを表示するウィンドウであり、ユーザーに異なるページを表示します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-322">Typically it is a pane with several options to choose from in a list style menu that will take the user to different pages.</span></span> <span data-ttu-id="54dc6-323">一般的に、このウィンドウは領域を節約するために折りたたまれた状態で表示され、ユーザーがボタンをクリックすることで開くことができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-323">Generally this pane starts out collapsed to save space, and the user can open it by clicking on a button.</span></span>

<span data-ttu-id="54dc6-324">ナビゲーション ウィンドウは、マウスやタッチを使う場合に非常にアクセシビリティが高く、ゲームパッド/リモコンを使う場合はウィンドウを開くボタンに移動する必要があるためアクセシビリティは低くなります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-324">While nav panes are very accessible with mouse and touch, gamepad/remote makes them less accessible since the user has to navigate to a button to open the pane.</span></span> <span data-ttu-id="54dc6-325">そのため、ユーザーがページの左端まで移動してナビゲーション ウィンドウを開くことができるだけでなく、**表示**ボタンでナビゲーション ウィンドウを開く操作を可能にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-325">Therefore, a good practice is to have the **View** button open the nav pane, as well as allow the user to open it by navigating all the way to the left of the page.</span></span> <span data-ttu-id="54dc6-326">この設計パターンを実装する方法を示すコード サンプルは、「[プログラムによるフォーカス ナビゲーション](../input/focus-navigation-programmatic.md#split-view-code-sample)」にあります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-326">Code sample on how to implement this design pattern can be found in [Programmatic focus navigation](../input/focus-navigation-programmatic.md#split-view-code-sample) document.</span></span> <span data-ttu-id="54dc6-327">これにより、ユーザーは非常に簡単にウィンドウの内容にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-327">This will provide the user with very easy access to the contents of the pane.</span></span> <span data-ttu-id="54dc6-328">さまざまな画面サイズでのナビゲーション ウィンドウの動作と、ゲームパッド/リモコンでのナビゲーションのベスト プラクティスについては、「[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-328">For more information about how nav panes behave in different screen sizes as well as best practices for gamepad/remote navigation, see [Nav panes](../controls-and-patterns/navigationview.md).</span></span>

### <a name="commandbar-labels"></a><span data-ttu-id="54dc6-329">CommandBar のラベル</span><span class="sxs-lookup"><span data-stu-id="54dc6-329">CommandBar labels</span></span>

<span data-ttu-id="54dc6-330">[CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) のアイコンの高さを最小化し、一貫性が保たれるようにするために、アイコンの右側にラベルを配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-330">It is a good idea to have the labels placed to the right of the icons on a [CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar) so that its height is minimized and stays consistent.</span></span> <span data-ttu-id="54dc6-331">[CommandBar.DefaultLabelPosition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar.defaultlabelpositionproperty) プロパティを `CommandBarDefaultLabelPosition.Right` に設定することによって、これを実現できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-331">You can do this by setting the [CommandBar.DefaultLabelPosition](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar.defaultlabelpositionproperty) property to `CommandBarDefaultLabelPosition.Right`.</span></span>

![アイコンの右側にラベルが配置された CommandBar](images/designing-for-tv/commandbar.png)

<span data-ttu-id="54dc6-333">また、このプロパティを設定するとラベルが常に表示されるようになり、ユーザーのクリック数を最小限に抑えることができるため、10 フィート エクスペリエンスに適しています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-333">Setting this property will also cause the labels to always be displayed, which works well for the 10-foot experience because it minimizes the number of clicks for the user.</span></span> <span data-ttu-id="54dc6-334">また、これは他の種類のデバイスでも従うべき優れたモデルです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-334">This is also a great model for other device types to follow.</span></span>

### <a name="tooltip"></a><span data-ttu-id="54dc6-335">ヒント</span><span class="sxs-lookup"><span data-stu-id="54dc6-335">Tooltip</span></span>

<span data-ttu-id="54dc6-336">[Tooltip](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ToolTip) コントロールは、ユーザーが要素の上にマウスを置くか、要素をタップして長押ししたときに UI の詳しい情報を提供する方法として導入されました。</span><span class="sxs-lookup"><span data-stu-id="54dc6-336">The [Tooltip](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ToolTip) control was introduced as a way to provide more information in the UI when the user hovers the mouse over, or taps and holds their figure on, an element.</span></span> <span data-ttu-id="54dc6-337">ゲームパッドとリモコンの場合、`Tooltip` は、要素にフォーカスが設定されて少し時間が経つと表示され、しばらく画面に表示された後で消えます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-337">For gamepad and remote, `Tooltip` appears after a brief moment when the element gets focus, stays onscreen for a short time, and then disappears.</span></span> <span data-ttu-id="54dc6-338">使う `Tooltip` が多すぎると、ユーザーがこの動作を煩わしいと感じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-338">This behavior could be distracting if too many `Tooltip`s are used.</span></span> <span data-ttu-id="54dc6-339">テレビを設計するときには `Tooltip` を使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-339">Try to avoid using `Tooltip` when designing for TV.</span></span>

### <a name="button-styles"></a><span data-ttu-id="54dc6-340">ボタンのスタイル</span><span class="sxs-lookup"><span data-stu-id="54dc6-340">Button styles</span></span>

<span data-ttu-id="54dc6-341">標準的な UWP ボタンもテレビで適切に機能しますが、ボタンのいくつかの視覚スタイルは、より UI に注意を引きます。そのため、すべてのプラットフォーム、特に 10 フィート エクスペリエンスでは、どこにフォーカスがあるかを明確に通知できるというメリットがあるため、検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-341">While the standard UWP buttons work well on TV, some visual styles of buttons call attention to the UI better, which you may want to consider for all platforms, particularly in the 10-foot experience, which benefits from clearly communicating where the focus is located.</span></span> <span data-ttu-id="54dc6-342">そのようなスタイルについて詳しくは、「[ボタン](../controls-and-patterns/buttons.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-342">To read more about these styles, see [Buttons](../controls-and-patterns/buttons.md).</span></span>

### <a name="nested-ui-elements"></a><span data-ttu-id="54dc6-343">入れ子になった UI 要素</span><span class="sxs-lookup"><span data-stu-id="54dc6-343">Nested UI elements</span></span>

<span data-ttu-id="54dc6-344">入れ子になった UI は、コンテナー UI 要素内部に囲まれた、操作できる入れ子になったアイテムを公開します。入れ子になったアイテムとコンテナー アイテムはどちらも互いに、個別のフォーカスを取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-344">Nested UI exposes nested actionable items enclosed inside a container UI element where both the nested item as well as the container item can take independent focus from each other.</span></span>

<span data-ttu-id="54dc6-345">入れ子になった UI がうまく機能する入力の種類もありますが、XY ナビゲーションに依存するゲームパッドやリモコンでは、うまく機能するとは限りません。</span><span class="sxs-lookup"><span data-stu-id="54dc6-345">Nested UI works well for some input types, but not always for gamepad and remote, which rely on XY navigation.</span></span> <span data-ttu-id="54dc6-346">このトピックのガイダンスに従い、UI が 10 フィート環境に最適化され、ユーザーが対話可能なすべての要素に容易にアクセスできるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-346">Be sure to follow the guidance in this topic to ensure that your UI is optimized for the 10-foot environment, and that the user can access all interactable elements easily.</span></span> <span data-ttu-id="54dc6-347">よく使用される解決策の 1 つは、`ContextFlyout` に入れ子になった UI 要素を配置することです ([CommandBarとContextFlyout](#commandbar-and-contextflyout) をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="54dc6-347">One common solution is to place nested UI elements in a `ContextFlyout` (see [CommandBar and ContextFlyout](#commandbar-and-contextflyout)).</span></span>

<span data-ttu-id="54dc6-348">入れ子になった UI について詳しくは、「[リスト項目の入れ子になった UI](../controls-and-patterns/nested-ui.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-348">For more information on nested UI, see [Nested UI in list items](../controls-and-patterns/nested-ui.md).</span></span>

### <a name="mediatransportcontrols"></a><span data-ttu-id="54dc6-349">MediaTransportControls</span><span class="sxs-lookup"><span data-stu-id="54dc6-349">MediaTransportControls</span></span>

<span data-ttu-id="54dc6-350">[MediaTransportControls](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaTransportControls) 要素によって、ユーザーが再生、一時停止、クローズド キャプションの有効化などの操作を実行できる既定の再生エクスペリエンスが提供され、ユーザーはメディアを操作することができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-350">The [MediaTransportControls](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaTransportControls) element lets users interact with their media by providing a default playback experience that allows them to play, pause, turn on closed captions, and more.</span></span> <span data-ttu-id="54dc6-351">このコントロールは、[MediaPlayerElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaPlayerElement) のプロパティであり、*1 行*と *2 行*の 2 つのレイアウト オプションをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-351">This control is a property of [MediaPlayerElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaPlayerElement) and supports two layout options: *single-row* and *double-row*.</span></span> <span data-ttu-id="54dc6-352">1 行のレイアウトでは、スライダーと再生ボタンはすべて 1 つの行に配置され、スライダーの左側に再生/一時停止ボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-352">In the single-row layout, the slider and playback buttons are all located in one row, with the play/pause button located to the left of the slider.</span></span> <span data-ttu-id="54dc6-353">2 行のレイアウトでは、スライダーは独自の行に配置され、再生ボタンは下側の別の行に配置されます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-353">In the double-row layout, the slider occupies its own row, with the playback buttons on a separate lower row.</span></span> <span data-ttu-id="54dc6-354">10 フィート エクスペリエンス向けに設計する場合は、ゲームパッドでのナビゲーションが向上するため、2 行のレイアウトを使用してください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-354">When designing for the 10-foot experience, the double-row layout should be used, as it provides better navigation for gamepad.</span></span> <span data-ttu-id="54dc6-355">2 行のレイアウトを有効にするには、`MediaPlayerElement` の [TransportControls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement.transportcontrols) プロパティの `MediaTransportControls` 要素で `IsCompact="False"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-355">To enable the double-row layout, set `IsCompact="False"` on the `MediaTransportControls` element in the [TransportControls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement.transportcontrols) property of the `MediaPlayerElement`.</span></span>

```xml
<MediaPlayerElement x:Name="mediaPlayerElement1"  
                    Source="Assets/video.mp4"
                    AreTransportControlsEnabled="True">
    <MediaPlayerElement.TransportControls>
        <MediaTransportControls IsCompact="False"/>
    </MediaPlayerElement.TransportControls>
</MediaPlayerElement>
```  

<span data-ttu-id="54dc6-356">アプリにメディアを追加する方法について詳しくは、「[メディア再生](../controls-and-patterns/media-playback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-356">Visit [Media playback](../controls-and-patterns/media-playback.md) to learn more about adding media to your app.</span></span>

> <span data-ttu-id="54dc6-357">![注] `MediaPlayerElement` は Windows 10 バージョン 1607 以降でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-357">![NOTE] `MediaPlayerElement` is only available in Windows 10, version 1607 and later.</span></span> <span data-ttu-id="54dc6-358">Windows 10 の以前のバージョン用にアプリを開発する場合は、代わりに [MediaElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaElement) を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-358">If you're developing an app for an earlier version of Windows 10, you'll need to use [MediaElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaElement) instead.</span></span> <span data-ttu-id="54dc6-359">上記の推奨事項は `MediaElement` にも適用され、`TransportControls` プロパティも同じ方法でアクセスされます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-359">The recommendations above apply to `MediaElement` as well, and the `TransportControls` property is accessed in the same way.</span></span>

### <a name="search-experience"></a><span data-ttu-id="54dc6-360">検索エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="54dc6-360">Search experience</span></span>

<span data-ttu-id="54dc6-361">コンテンツの検索は 10 フィート エクスペリエンスで最もよく実行される機能の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-361">Searching for content is one of the most commonly performed functions in the 10-foot experience.</span></span> <span data-ttu-id="54dc6-362">アプリが検索エクスペリエンスを提供する場合、ユーザーがゲームパッドの **Y** ボタンをアクセラレータとして使用して、検索へのクイックアクセスができるようにすると便利です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-362">If your app provides a search experience, it is helpful for the user to have quick access to it by using the **Y** button on the gamepad as an accelerator.</span></span>

<span data-ttu-id="54dc6-363">このアクセラレータは既に多くのユーザーに使用されていますが、必要に応じて UI に視覚的な **Y** グリフを追加して、ユーザーがこのボタンを使用して検索機能にアクセスできることを示すことも可能です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-363">Most customers should already be familiar with this accelerator, but if you like you can add a visual **Y** glyph to the UI to indicate that the customer can use the button to access search functionality.</span></span> <span data-ttu-id="54dc6-364">このヒントを追加する場合は、Xbox のシェルやその他のアプリとの一貫性を維持するため、必ず **Segoe Xbox シンボル MDL2** フォント (XAML アプリの場合は `&#xE3CC;`、HTML アプリの場合は `\E426`) のシンボルを使用します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-364">If you do add this cue, be sure to use the symbol from the **Segoe Xbox MDL2 Symbol** font (`&#xE3CC;` for XAML apps, `\E426` for HTML apps) to provide consistency with the Xbox shell and other apps.</span></span>

> [!NOTE]
> <span data-ttu-id="54dc6-365">**Segoe Xbox MDL2 シンボル** フォントは Xbox にのみ対応するフォントであるため、PC ではシンボルが正しく表示されません。</span><span class="sxs-lookup"><span data-stu-id="54dc6-365">Because the **Segoe Xbox MDL2 Symbol** font is only available on Xbox, the symbol won't appear correctly on your PC.</span></span> <span data-ttu-id="54dc6-366">ただし、テレビに Xbox を展開した後はテレビで表示できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-366">However, it will show up on the TV once you deploy to Xbox.</span></span>

<span data-ttu-id="54dc6-367">**Y** ボタンはゲームパッドのみで利用できるため、検索にアクセスするための他の方法 (UI のボタンなど) を提供するようにします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-367">Since the **Y** button is only available on gamepad, make sure to provide other methods of access to search, such as buttons in the UI.</span></span> <span data-ttu-id="54dc6-368">そうしない場合、一部のユーザーが検索機能にアクセスすることができない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-368">Otherwise, some customers may not be able to access the functionality.</span></span>

<span data-ttu-id="54dc6-369">10 フィート エクスペリエンスではディスプレイのスペースが限られるため、通常、ユーザーは全画面表示の検索エクスペリエンスを使うほうが便利です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-369">In the 10-foot experience, it is often easier for customers to use a full screen search experience because there is limited room on the display.</span></span> <span data-ttu-id="54dc6-370">全画面表示でも部分的な表示でも、「インプレース」検索により、ユーザーが検索エクスペリエンスを開いたときにスクリーン キーボードが表示され、ユーザーが検索用語を入力できるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-370">Whether you have full screen or partial-screen, "in-place" search, we recommend that when the user opens the search experience, the onscreen keyboard appears already opened, ready for the customer to enter search terms.</span></span>

## <a name="custom-visual-state-trigger-for-xbox"></a><span data-ttu-id="54dc6-371">Xbox のカスタム表示状態トリガー</span><span class="sxs-lookup"><span data-stu-id="54dc6-371">Custom visual state trigger for Xbox</span></span>

<span data-ttu-id="54dc6-372">UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="54dc6-372">To tailor your UWP app for the 10-foot experience, we recommend that you make layout changes when the app detects that it has been launched on an Xbox console.</span></span> <span data-ttu-id="54dc6-373">これを行う方法の 1 つが、カスタム*表示状態トリガー*を使用することです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-373">One way to do this is by using a custom *visual state trigger*.</span></span> <span data-ttu-id="54dc6-374">表示状態トリガーは、**Blend for Visual Studio** で編集する場合に最も有用です。</span><span class="sxs-lookup"><span data-stu-id="54dc6-374">Visual state triggers are most useful when you want to edit in **Blend for Visual Studio**.</span></span> <span data-ttu-id="54dc6-375">次のコード スニペットは、Xbox の表示状態トリガーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="54dc6-375">The following code snippet shows how to create a visual state trigger for Xbox:</span></span>

```xml
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
        <VisualState>
            <VisualState.StateTriggers>
                <triggers:DeviceFamilyTrigger DeviceFamily="Windows.Xbox"/>
            </VisualState.StateTriggers>
            <VisualState.Setters>
                <Setter Target="RootSplitView.OpenPaneLength"
                        Value="368"/>
                <Setter Target="RootSplitView.CompactPaneLength"
                        Value="96"/>
                <Setter Target="NavMenuList.Margin"
                        Value="0,75,0,27"/>
                <Setter Target="Frame.Margin"
                        Value="0,27,48,27"/>
                <Setter Target="NavMenuList.ItemContainerStyle"
                        Value="{StaticResource NavMenuItemContainerXboxStyle}"/>
            </VisualState.Setters>
        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

<span data-ttu-id="54dc6-376">このようなトリガーを作成するには、アプリに次のクラスを追加します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-376">To create the trigger, add the following class to your app.</span></span> <span data-ttu-id="54dc6-377">これは、前の XAML コードで参照されているクラスです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-377">This is the class that is referenced by the XAML code above:</span></span>

```csharp
class DeviceFamilyTrigger : StateTriggerBase
{
    private string _currentDeviceFamily, _queriedDeviceFamily;

    public string DeviceFamily
    {
        get
        {
            return _queriedDeviceFamily;
        }

        set
        {
            _queriedDeviceFamily = value;
            _currentDeviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
            SetActive(_queriedDeviceFamily == _currentDeviceFamily);
        }
    }
}
```

<span data-ttu-id="54dc6-378">カスタム トリガーを追加した場合、アプリは、Xbox One コンソールで実行されていることを検出すると XAML コードで指定されたレイアウトを自動的に変更します。</span><span class="sxs-lookup"><span data-stu-id="54dc6-378">After you've added your custom trigger, your app will automatically make the layout modifications you specified in your XAML code whenever it detects that it is running on an Xbox One console.</span></span>

<span data-ttu-id="54dc6-379">アプリが Xbox で実行されていることを確認した後、適切な調整を行うためのもう 1 つの方法は、コードを使うことです。</span><span class="sxs-lookup"><span data-stu-id="54dc6-379">Another way you can check whether your app is running on Xbox and then make the appropriate adjustments is through code.</span></span> <span data-ttu-id="54dc6-380">次の単純な変数を使って、Xbox でアプリが実行されているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-380">You can use the following simple variable to check if your app is running on Xbox:</span></span>

```csharp
bool IsTenFoot = (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily ==
                    "Windows.Xbox");
```

<span data-ttu-id="54dc6-381">次に、このチェックに続くコード ブロックで、UI に適切な調整を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-381">Then, you can make the appropriate adjustments to your UI in the code block following this check.</span></span> <span data-ttu-id="54dc6-382">この例については、「[UWP 色のサンプル](#uwp-color-sample)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54dc6-382">An example of this is shown in [UWP color sample](#uwp-color-sample).</span></span>

## <a name="summary"></a><span data-ttu-id="54dc6-383">まとめ</span><span class="sxs-lookup"><span data-stu-id="54dc6-383">Summary</span></span>

<span data-ttu-id="54dc6-384">10 フィート エクスペリエンスの設計には、他のプラットフォーム向けの設計とは対応を変える必要がある、特別な考慮事項があります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-384">Designing for the 10-foot experience has special considerations to take into account that make it different from designing for any other platform.</span></span> <span data-ttu-id="54dc6-385">UWP アプリを Xbox One に単純に移植し、うまく動かすことができたとしも、必ずしも 10 フィート エクスペリエンス向けに最適化されるわけではありません。ユーザーのフラストレーションを招くことさえあります。</span><span class="sxs-lookup"><span data-stu-id="54dc6-385">While you can certainly do a straight port of your UWP app to Xbox One and it will work, it won't necessarily be optimized for the 10-foot experience and can lead to user frustration.</span></span> <span data-ttu-id="54dc6-386">この記事のガイドラインに従うと、テレビに組み込まれているかのようなすばらしいアプリにすることができます。</span><span class="sxs-lookup"><span data-stu-id="54dc6-386">Following the guidelines in this article will make sure that your app is as good as it can be on TV.</span></span>

## <a name="related-articles"></a><span data-ttu-id="54dc6-387">関連記事</span><span class="sxs-lookup"><span data-stu-id="54dc6-387">Related articles</span></span>

- [<span data-ttu-id="54dc6-388">ユニバーサル Windows プラットフォーム (UWP) アプリ用デバイスの基本情報</span><span class="sxs-lookup"><span data-stu-id="54dc6-388">Device primer for Universal Windows Platform (UWP) apps</span></span>](index.md)
- [<span data-ttu-id="54dc6-389">ゲームパッドとリモコンの操作</span><span class="sxs-lookup"><span data-stu-id="54dc6-389">Gamepad and remote control interactions</span></span>](../input/gamepad-and-remote-interactions.md)
- [<span data-ttu-id="54dc6-390">UWP アプリのサウンド</span><span class="sxs-lookup"><span data-stu-id="54dc6-390">Sound in UWP apps</span></span>](../style/sound.md)
