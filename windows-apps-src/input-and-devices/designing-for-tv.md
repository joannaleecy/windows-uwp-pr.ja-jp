---
author: eliotcowley
Description: "テレビで見栄えよく表示され適切に機能するアプリを設計します。"
title: "Xbox およびテレビ向け設計"
ms.assetid: 780209cb-3e8a-4cf7-8f80-8b8f449580bf
label: Designing for Xbox and TV
template: detail.hbs
isNew: True
keywords: "Xbox, テレビ, 10 フィート エクスペリエンス, ゲームパッド, リモコン, 入力, 操作"
ms.author: elcowle
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
pm-contact: chigy
design-contact: jeffarn
dev-contact: niallm
doc-status: Published
ms.openlocfilehash: afc51f977d8e94977fa7ec47fad3b96ddac26197
ms.sourcegitcommit: a2908889b3566882c7494dc81fa9ece7d1d19580
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/31/2017
---
# <a name="designing-for-xbox-and-tv"></a><span data-ttu-id="36591-104">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="36591-104">Designing for Xbox and TV</span></span>

<span data-ttu-id="36591-105">Xbox One とテレビ画面で見栄えよく表示され、適切に機能するようにユニバーサル Windows プラットフォーム (UWP) アプリの設計を行います。</span><span class="sxs-lookup"><span data-stu-id="36591-105">Design your Universal Windows Platform (UWP) app so that it looks good and functions well on Xbox One and television screens.</span></span>

## <a name="overview"></a><span data-ttu-id="36591-106">概要</span><span class="sxs-lookup"><span data-stu-id="36591-106">Overview</span></span>

<span data-ttu-id="36591-107">ユニバーサル Windows プラットフォームでは、複数の Windows 10 デバイスで魅力的なエクスペリエンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="36591-107">The Universal Windows Platform lets you create delightful experiences across multiple Windows 10 devices.</span></span>
<span data-ttu-id="36591-108">UWP フレームワークで提供される機能のほとんどは、追加の作業を行わなくても、これらのデバイス間で同じユーザー インターフェイス (UI) をアプリに使用できます。</span><span class="sxs-lookup"><span data-stu-id="36591-108">Most of the functionality provided by the UWP framework enables apps to use the same user interface (UI) across these devices, without additional work.</span></span>
<span data-ttu-id="36591-109">ただし、Xbox One とテレビ画面で快適に機能するようにアプリを調整し最適化するには、特別な注意事項があります。</span><span class="sxs-lookup"><span data-stu-id="36591-109">However, tailoring and optimizing your app to work great on Xbox One and TV screens requires special considerations.</span></span>

<span data-ttu-id="36591-110">ソファーに座りながらゲームパッドやリモコンを使って部屋の反対側にあるテレビを操作することを、**10 フィート エクスペリエンス**といいます。</span><span class="sxs-lookup"><span data-stu-id="36591-110">The experience of sitting on your couch across the room, using a gamepad or remote to interact with your TV, is called the **10-foot experience**.</span></span>
<span data-ttu-id="36591-111">通常は画面から約 10 フィート (約 3 m) の距離に座るため、このように呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="36591-111">It is so named because the user is generally sitting approximately 10 feet away from the screen.</span></span>
<span data-ttu-id="36591-112">この場合、たとえば PC の操作 (*2 フィート* エクスペリエンスと呼ばれます) には見られない、特有の課題があります。</span><span class="sxs-lookup"><span data-stu-id="36591-112">This provides unique challenges that aren't present in, say, the *2-foot* experience, or interacting with a PC.</span></span>
<span data-ttu-id="36591-113">Xbox One や、コントローラーを使って入力しテレビ画面に出力するその他のデバイス向けアプリを開発している場合、この点を常に意識しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-113">If you are developing an app for Xbox One or any other device that outputs to the TV screen and uses a controller for input, you should always keep this in mind.</span></span>

<span data-ttu-id="36591-114">アプリを 10 フィート エクスペリエンス向けに適切に動作させるためにこの記事のすべての手順が必要なわけではありませんが、手順を理解し、アプリにとって何が適切かを判断することで、アプリ特有のニーズに合わせてカスタマイズされた、優れた 10 フィート エクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="36591-114">Not all of the steps in this article are required to make your app work well for 10-foot experiences, but understanding them and making the appropriate decisions for your app will result in a better 10-foot experience tailored for your app's specific needs.</span></span>
<span data-ttu-id="36591-115">10 フィート環境でアプリを使う場合、次のデザイン原則を検討してください。</span><span class="sxs-lookup"><span data-stu-id="36591-115">As you bring your app to life in the 10-foot environment, consider the following design principles.</span></span>

### <a name="simple"></a><span data-ttu-id="36591-116">シンプル</span><span class="sxs-lookup"><span data-stu-id="36591-116">Simple</span></span>

<span data-ttu-id="36591-117">10 フィート環境向けのデザインには特有の課題があります。</span><span class="sxs-lookup"><span data-stu-id="36591-117">Designing for the 10-foot environment presents a unique set of challenges.</span></span> <span data-ttu-id="36591-118">解像度と視聴距離の点から、ユーザーはあまり多くの情報を処理できない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-118">Resolution and viewing distance can make it difficult for people to process too much information.</span></span>
<span data-ttu-id="36591-119">単純なデザインになるように、ごくシンプルなコンポーネントだけに絞り込むようにしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-119">Try to keep your design clean, reduced to the simplest possible components.</span></span> <span data-ttu-id="36591-120">テレビに表示される情報の量は、デスクトップではなく、携帯電話と同程度にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-120">The amount of information displayed on a TV should be comparable to what you'd see on a mobile phone, rather than on a desktop.</span></span>

![Xbox One ホーム画面](images/designing-for-tv/xbox-home-screen.png)

### <a name="coherent"></a><span data-ttu-id="36591-122">一貫性</span><span class="sxs-lookup"><span data-stu-id="36591-122">Coherent</span></span>

<span data-ttu-id="36591-123">10 フィート環境の UWP アプリは、直感的で簡単に使えるようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-123">UWP apps in the 10-foot environment should be intuitive and easy to use.</span></span> <span data-ttu-id="36591-124">何がポイントなのかを明快、明確にしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-124">Make the focus clear and unmistakable.</span></span>
<span data-ttu-id="36591-125">コンテンツの配置を工夫し、コンテンツ間の移動に一貫性を持たせてユーザーが予測できるようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-125">Arrange content so that movement across the space is consistent and predictable.</span></span> <span data-ttu-id="36591-126">ユーザーが目的の操作を最短で実行できるように配慮しましょう。</span><span class="sxs-lookup"><span data-stu-id="36591-126">Give people the shortest path to what they want to do.</span></span>

![Xbox One 映画アプリ](images/designing-for-tv/xbox-movies-app.png)

_**<span data-ttu-id="36591-128">スクリーンショットに示す映画はすべて、Microsoft 映画 & テレビでご利用いただけます。</span><span class="sxs-lookup"><span data-stu-id="36591-128">All movies shown in the screenshot are available on Microsoft Movies & TV.</span></span>**_  

### <a name="captivating"></a><span data-ttu-id="36591-129">魅力的</span><span class="sxs-lookup"><span data-stu-id="36591-129">Captivating</span></span>

<span data-ttu-id="36591-130">最もイマーシブで臨場感のあるエクスペリエンスは、大画面で引き出されます。</span><span class="sxs-lookup"><span data-stu-id="36591-130">The most immersive, cinematic experiences take place on the big screen.</span></span> <span data-ttu-id="36591-131">画面いっぱいに広がる風景、洗練された動作、鮮やかな色使い、生き生きとした文字が、アプリをワンランク上に引き上げます。</span><span class="sxs-lookup"><span data-stu-id="36591-131">Edge-to-edge scenery, elegant motion, and vibrant use of color and typography take your apps to the next level.</span></span> <span data-ttu-id="36591-132">大胆で美しいデザインにしましょう。</span><span class="sxs-lookup"><span data-stu-id="36591-132">Be bold and beautiful.</span></span>

![Xbox One アバター アプリ](images/designing-for-tv/xbox-avatar-app.png)

### <a name="optimizations-for-the-10-foot-experience"></a><span data-ttu-id="36591-134">10 フィート エクスペリエンス向けの最適化</span><span class="sxs-lookup"><span data-stu-id="36591-134">Optimizations for the 10-foot experience</span></span>

<span data-ttu-id="36591-135">ここまで、10 フィート エクスペリエンス向けに優れた UWP アプリを設計する原則を説明しました。次に、アプリを最適化して優れたユーザー エクスペリエンスを提供する具体的な方法について、概要を示します。</span><span class="sxs-lookup"><span data-stu-id="36591-135">Now that you know the principles of good UWP app design for the 10-foot experience, read through the following overview of the specific ways you can optimize your app and make for a great user experience.</span></span>

| <span data-ttu-id="36591-136">機能</span><span class="sxs-lookup"><span data-stu-id="36591-136">Feature</span></span>        | <span data-ttu-id="36591-137">説明</span><span class="sxs-lookup"><span data-stu-id="36591-137">Description</span></span>           |
| -------------------------------------------------------------- |--------------------------------|
| [<span data-ttu-id="36591-138">ゲームパッドとリモコン</span><span class="sxs-lookup"><span data-stu-id="36591-138">Gamepad and remote control</span></span>](#gamepad-and-remote-control)      | <span data-ttu-id="36591-139">アプリがゲームパッドやリモコンで正しく動作するか確認することは、10 フィート エクスペリエンス向けの最適化で最も重要な手順です。</span><span class="sxs-lookup"><span data-stu-id="36591-139">Making sure that your app works well with gamepad and remote is the most important step in optimizing for 10-foot experiences.</span></span> <span data-ttu-id="36591-140">操作がある程度制限されたデバイスでユーザーの対話式操作エクスペリエンスを最適化できる、ゲームパッドやリモコン固有の改善点がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="36591-140">There are several gamepad and remote-specific improvements that you can make to optimize the user interaction experience on a device where their actions are somewhat limited.</span></span> |
| [<span data-ttu-id="36591-141">XY フォーカス ナビゲーションと対話式操作</span><span class="sxs-lookup"><span data-stu-id="36591-141">XY focus navigation and interaction</span></span>](#xy-focus-navigation-and-interaction) | <span data-ttu-id="36591-142">UWP では、ユーザーは **XY フォーカス ナビゲーション**を使ってアプリの UI 内を移動できます。</span><span class="sxs-lookup"><span data-stu-id="36591-142">The UWP provides **XY focus navigation** that allows the user to navigate around your app's UI.</span></span> <span data-ttu-id="36591-143">ただし、ユーザーの移動は上下左右に制限されます。</span><span class="sxs-lookup"><span data-stu-id="36591-143">However, this limits the user to navigating up, down, left, and right.</span></span> <span data-ttu-id="36591-144">このセクションでは、この点に対応するための推奨事項とその他の考慮事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="36591-144">Recommendations for dealing with this and other considerations are outlined in this section.</span></span> |
| [<span data-ttu-id="36591-145">マウス モード</span><span class="sxs-lookup"><span data-stu-id="36591-145">Mouse mode</span></span>](#mouse-mode)|<span data-ttu-id="36591-146">地図や描画サーフェイスなど一部のユーザー インターフェイスでは、XY フォーカス ナビゲーションの使用は不可能または非実用的です。</span><span class="sxs-lookup"><span data-stu-id="36591-146">In some user interfaces, such as maps and drawing surfaces, it is not possible or practical to use XY focus navigation.</span></span> <span data-ttu-id="36591-147">UWP ではこれらのインターフェイス用に**マウス モード**が用意されており、デスクトップ コンピューターでマウスを操作するように、ゲームパッド/リモコンを使って自由に移動できます。</span><span class="sxs-lookup"><span data-stu-id="36591-147">For these interfaces, the UWP provides **mouse mode** to let the gamepad/remote navigate freely, like a mouse on a desktop computer.</span></span>|
| [<span data-ttu-id="36591-148">フォーカス表示</span><span class="sxs-lookup"><span data-stu-id="36591-148">Focus visual</span></span>](#focus-visual)  | <span data-ttu-id="36591-149">フォーカス表示とは、現在フォーカスがある UI 要素を囲む境界線のことです。</span><span class="sxs-lookup"><span data-stu-id="36591-149">The focus visual is the border around the UI element that currently has focus.</span></span> <span data-ttu-id="36591-150">この機能を使ってユーザーの現在位置をわかりやすく示すことで、ユーザーが自分の位置を見失わずに UI を移動しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="36591-150">This helps orient the user so that they can easily navigate your UI without getting lost.</span></span> <span data-ttu-id="36591-151">フォーカスがよく見えないとユーザーが UI 内で自分の位置を見失ってしまい、優れたエクスペリエンスを得られない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-151">If the focus is not clearly visible, the user could get lost in your UI and not have a great experience.</span></span>  |
| [<span data-ttu-id="36591-152">フォーカス エンゲージメント</span><span class="sxs-lookup"><span data-stu-id="36591-152">Focus engagement</span></span>](#focus-engagement) | <span data-ttu-id="36591-153">UI 要素にフォーカス エンゲージメントを設定すると、ユーザーは、対話式操作するために [**A/選択**] ボタンを押す必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-153">Setting focus engagement on a UI element requires the user to press the **A/Select** button in order to interact with it.</span></span> <span data-ttu-id="36591-154">こうすることで、アプリの UI を移動するときのユーザー エクスペリエンスをより良くすることができます。</span><span class="sxs-lookup"><span data-stu-id="36591-154">This can help create a better experience for the user when navigating your app's UI.</span></span>
| [<span data-ttu-id="36591-155">UI 要素のサイズ</span><span class="sxs-lookup"><span data-stu-id="36591-155">UI element sizing</span></span>](#ui-element-sizing)  | <span data-ttu-id="36591-156">ユニバーサル Windows プラットフォームは、[スケーリングと有効ピクセル](..\layout\design-and-ui-intro.md#effective-pixels-and-scaling)を使い、視聴距離に合わせて UI をスケーリングします。</span><span class="sxs-lookup"><span data-stu-id="36591-156">The Universal Windows Platform uses [scaling and effective pixels](..\layout\design-and-ui-intro.md#effective-pixels-and-scaling) to scale the UI according to the viewing distance.</span></span> <span data-ttu-id="36591-157">サイズについて理解し UI 全体に適用すれば、アプリを 10 フィート環境用に最適化するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="36591-157">Understanding sizing and applying it across your UI will help optimize your app for the 10-foot environment.</span></span>  |
|  [<span data-ttu-id="36591-158">テレビのセーフ エリア</span><span class="sxs-lookup"><span data-stu-id="36591-158">TV-safe area</span></span>](#tv-safe-area) | <span data-ttu-id="36591-159">UWP は既定で、テレビのセーフ エリア以外の領域 (画面の端に近い部分) に UI を表示することを自動的に避けます。</span><span class="sxs-lookup"><span data-stu-id="36591-159">The UWP will automatically avoid displaying any UI in TV-unsafe areas (areas close to the edges of the screen) by default.</span></span> <span data-ttu-id="36591-160">ただし、この場合、アスペクト比が変わり、UI がレターボックス化されてしまいます。</span><span class="sxs-lookup"><span data-stu-id="36591-160">However, this creates a "boxed-in" effect in which the UI looks letterboxed.</span></span> <span data-ttu-id="36591-161">テレビでイマーシブなアプリにするには、サポートしているテレビで、画面の端まで広がるようにアプリを変更します。</span><span class="sxs-lookup"><span data-stu-id="36591-161">For your app to be truly immersive on TV, you will want to modify it so that it extends to the edges of the screen on TVs that support it.</span></span> |
| [<span data-ttu-id="36591-162">カラー</span><span class="sxs-lookup"><span data-stu-id="36591-162">Colors</span></span>](#colors)  |  <span data-ttu-id="36591-163">UWP は配色テーマをサポートしています。システム テーマを引き継ぐアプリは、Xbox One では既定で**濃色**になります。</span><span class="sxs-lookup"><span data-stu-id="36591-163">The UWP supports color themes, and an app that respects the system theme will default to **dark** on Xbox One.</span></span> <span data-ttu-id="36591-164">アプリに特定の配色テーマがある場合、テレビではうまく表示されないために一部の色を避ける必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-164">If your app has a specific color theme, you should consider that some colors don't work well for TV and should be avoided.</span></span> |
| [<span data-ttu-id="36591-165">サウンド</span><span class="sxs-lookup"><span data-stu-id="36591-165">Sound</span></span>](../style/sound.md)    | <span data-ttu-id="36591-166">サウンドは、ユーザーを没頭させたりユーザーにフィードバックを提供したりする上で役立ち、10 フィート エクスペリエンスで重要な役割を果たします。</span><span class="sxs-lookup"><span data-stu-id="36591-166">Sounds play a key role in the 10-foot experience, helping to immerse and give feedback to the user.</span></span> <span data-ttu-id="36591-167">UWP には、アプリが Xbox One で実行されているときは一般的なコントロールのサウンドを自動的に有効にする機能があります。</span><span class="sxs-lookup"><span data-stu-id="36591-167">The UWP provides functionality that automatically turns on sounds for common controls when the app is running on Xbox One.</span></span> <span data-ttu-id="36591-168">UWP に組み込まれているサウンド サポートの詳細とその活用方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="36591-168">Find out more about the sound support built into the UWP and learn how to take advantage of it.</span></span>    |
| [<span data-ttu-id="36591-169">UI コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="36591-169">Guidelines for UI controls</span></span>](#guidelines-for-ui-controls)  |  <span data-ttu-id="36591-170">いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。</span><span class="sxs-lookup"><span data-stu-id="36591-170">There are several UI controls that work well across multiple devices, but have certain considerations when used on TV.</span></span> <span data-ttu-id="36591-171">10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="36591-171">Read about some best practices for using these controls when designing for the 10-foot experience.</span></span> |
| [<span data-ttu-id="36591-172">Xbox のカスタム表示状態トリガー</span><span class="sxs-lookup"><span data-stu-id="36591-172">Custom visual state trigger for Xbox</span></span>](#custom-visual-state-trigger-for-xbox) | <span data-ttu-id="36591-173">UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、カスタム*表示状態トリガー*を使用して、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-173">To tailor your UWP app for the 10-foot experience, we recommend that you use a custom *visual state trigger* to make layout changes when the app detects that it has been launched on an Xbox console.</span></span>

> [!NOTE]
> <span data-ttu-id="36591-174">このトピックで示すコード スニペットはほとんどが XAMLで/c# ですが、基本原則と概念はすべての UWP アプリに共通です。</span><span class="sxs-lookup"><span data-stu-id="36591-174">Most of the code snippets in this topic are in XAML/C#; however, the principles and concepts apply to all UWP apps.</span></span> <span data-ttu-id="36591-175">Xbox 向けの HTML/JavaScript UWP アプリを開発している場合は、GitHub の [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) ライブラリを参照することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-175">If you're developing an HTML/JavaScript UWP app for Xbox, check out the excellent [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) library on GitHub.</span></span>

## <a name="gamepad-and-remote-control"></a><span data-ttu-id="36591-176">ゲームパッドとリモコン</span><span class="sxs-lookup"><span data-stu-id="36591-176">Gamepad and remote control</span></span>

<span data-ttu-id="36591-177">PC でキーボードやマウス、電話とタブレットでタッチを使うように、10 フィート エクスペリエンスではゲームパッドとリモコンがメイン入力デバイスになります。</span><span class="sxs-lookup"><span data-stu-id="36591-177">Just like keyboard and mouse are for PC, and touch is for phone and tablet, gamepad and remote control are the main input devices for the 10-foot experience.</span></span>
<span data-ttu-id="36591-178">このセクションでは、ハードウェア ボタンとはどのようなもので何に使うかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="36591-178">This section introduces what the hardware buttons are and what they do.</span></span>
<span data-ttu-id="36591-179">「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」と「[マウス モード](#mouse-mode)」では、これらの入力デバイスを使うときにアプリを最適化する方法について学びます。</span><span class="sxs-lookup"><span data-stu-id="36591-179">In [XY focus navigation and interaction](#xy-focus-navigation-and-interaction) and [Mouse mode](#mouse-mode), you will learn how to optimize your app when using these input devices.</span></span>

<span data-ttu-id="36591-180">設定なしの場合のゲームパッドとリモコンの動作の品質は、アプリでキーボードがどの程度サポートされているかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="36591-180">The quality of gamepad and remote behavior that you get out-of-the-box depends on how well keyboard is supported in your app.</span></span> <span data-ttu-id="36591-181">アプリがゲームパッドとリモコンでうまく動作することを確認する良い方法は、アプリが PC でキーボードを使ってうまく動作するか確認してから、ゲームパッドとリモコンでテストして UI で不十分な箇所を見つけることです。</span><span class="sxs-lookup"><span data-stu-id="36591-181">A good way to ensure that your app will work well with gamepad/remote is to make sure that it works well with keyboard on PC, and then test with gamepad/remote to find weak spots in your UI.</span></span>

### <a name="hardware-buttons"></a><span data-ttu-id="36591-182">ハードウェア ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-182">Hardware buttons</span></span>

<span data-ttu-id="36591-183">このドキュメントでは、次の図に示すボタン名を使っています。</span><span class="sxs-lookup"><span data-stu-id="36591-183">Throughout this document, buttons will be referred to by the names given in the following diagram.</span></span>

![ゲームパッドとリモコンのボタンの図](images/designing-for-tv/hardware-buttons-gamepad-remote.png)

<span data-ttu-id="36591-185">図からわかるように、ゲームパッドでサポートされているボタンのいくつかはリモコンでサポートされておらず、逆に、リモコンでサポートされているボタンのいくつかはゲームパッドでサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="36591-185">As you can see from the diagram, there are some buttons that are supported on gamepad that are not supported on remote control, and vice versa.</span></span> <span data-ttu-id="36591-186">1 つの入力デバイスのみでサポートされているボタンを使って UI の移動を速くすることもできますが、そのようなボタンを重要な操作に使うように設計してしまうと、ユーザーが一部の UI を操作できなくなる可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-186">While you can use buttons that are only supported on one input device to make navigating the UI faster, be aware that using them for critical interactions may create a situation where the user is unable to interact with certain parts of the UI.</span></span>

<span data-ttu-id="36591-187">次の表に、UWP アプリでサポートされているすべてのハードウェア ボタンと、各ボタンがサポートされている入力デバイスを示します。</span><span class="sxs-lookup"><span data-stu-id="36591-187">The following table lists all of the hardware buttons supported by UWP apps, and which input device supports them.</span></span>

| <span data-ttu-id="36591-188">ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-188">Button</span></span>                    | <span data-ttu-id="36591-189">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="36591-189">Gamepad</span></span>   | <span data-ttu-id="36591-190">リモコン</span><span class="sxs-lookup"><span data-stu-id="36591-190">Remote control</span></span>    |
|---------------------------|-----------|-------------------|
| <span data-ttu-id="36591-191">A/[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-191">A/Select button</span></span>           | <span data-ttu-id="36591-192">○</span><span class="sxs-lookup"><span data-stu-id="36591-192">Yes</span></span>       | <span data-ttu-id="36591-193">○</span><span class="sxs-lookup"><span data-stu-id="36591-193">Yes</span></span>               |
| <span data-ttu-id="36591-194">B/[戻る] ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-194">B/Back button</span></span>             | <span data-ttu-id="36591-195">○</span><span class="sxs-lookup"><span data-stu-id="36591-195">Yes</span></span>       | <span data-ttu-id="36591-196">○</span><span class="sxs-lookup"><span data-stu-id="36591-196">Yes</span></span>               |
| <span data-ttu-id="36591-197">方向パッド</span><span class="sxs-lookup"><span data-stu-id="36591-197">Directional pad (D-pad)</span></span>   | <span data-ttu-id="36591-198">○</span><span class="sxs-lookup"><span data-stu-id="36591-198">Yes</span></span>       | <span data-ttu-id="36591-199">○</span><span class="sxs-lookup"><span data-stu-id="36591-199">Yes</span></span>               |
| <span data-ttu-id="36591-200">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-200">Menu button</span></span>               | <span data-ttu-id="36591-201">○</span><span class="sxs-lookup"><span data-stu-id="36591-201">Yes</span></span>       | <span data-ttu-id="36591-202">○</span><span class="sxs-lookup"><span data-stu-id="36591-202">Yes</span></span>               |
| <span data-ttu-id="36591-203">ビュー ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-203">View button</span></span>               | <span data-ttu-id="36591-204">○</span><span class="sxs-lookup"><span data-stu-id="36591-204">Yes</span></span>       | <span data-ttu-id="36591-205">○</span><span class="sxs-lookup"><span data-stu-id="36591-205">Yes</span></span>               |
| <span data-ttu-id="36591-206">X ボタン、Y ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-206">X and Y buttons</span></span>           | <span data-ttu-id="36591-207">○</span><span class="sxs-lookup"><span data-stu-id="36591-207">Yes</span></span>       | <span data-ttu-id="36591-208">×</span><span class="sxs-lookup"><span data-stu-id="36591-208">No</span></span>                |
| <span data-ttu-id="36591-209">左スティック</span><span class="sxs-lookup"><span data-stu-id="36591-209">Left stick</span></span>                | <span data-ttu-id="36591-210">○</span><span class="sxs-lookup"><span data-stu-id="36591-210">Yes</span></span>       | <span data-ttu-id="36591-211">×</span><span class="sxs-lookup"><span data-stu-id="36591-211">No</span></span>                |
| <span data-ttu-id="36591-212">右スティック</span><span class="sxs-lookup"><span data-stu-id="36591-212">Right stick</span></span>               | <span data-ttu-id="36591-213">○</span><span class="sxs-lookup"><span data-stu-id="36591-213">Yes</span></span>       | <span data-ttu-id="36591-214">×</span><span class="sxs-lookup"><span data-stu-id="36591-214">No</span></span>                |
| <span data-ttu-id="36591-215">左トリガー、右トリガー</span><span class="sxs-lookup"><span data-stu-id="36591-215">Left and right triggers</span></span>   | <span data-ttu-id="36591-216">○</span><span class="sxs-lookup"><span data-stu-id="36591-216">Yes</span></span>       | <span data-ttu-id="36591-217">×</span><span class="sxs-lookup"><span data-stu-id="36591-217">No</span></span>                |
| <span data-ttu-id="36591-218">L ボタン、R ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-218">Left and right bumpers</span></span>    | <span data-ttu-id="36591-219">○</span><span class="sxs-lookup"><span data-stu-id="36591-219">Yes</span></span>       | <span data-ttu-id="36591-220">×</span><span class="sxs-lookup"><span data-stu-id="36591-220">No</span></span>                |
| <span data-ttu-id="36591-221">OneGuide ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-221">OneGuide button</span></span>           | <span data-ttu-id="36591-222">×</span><span class="sxs-lookup"><span data-stu-id="36591-222">No</span></span>        | <span data-ttu-id="36591-223">○</span><span class="sxs-lookup"><span data-stu-id="36591-223">Yes</span></span>               |
| <span data-ttu-id="36591-224">[音量] ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-224">Volume button</span></span>             | <span data-ttu-id="36591-225">×</span><span class="sxs-lookup"><span data-stu-id="36591-225">No</span></span>        | <span data-ttu-id="36591-226">○</span><span class="sxs-lookup"><span data-stu-id="36591-226">Yes</span></span>               |
| <span data-ttu-id="36591-227">チャネル ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-227">Channel button</span></span>            | <span data-ttu-id="36591-228">×</span><span class="sxs-lookup"><span data-stu-id="36591-228">No</span></span>        | <span data-ttu-id="36591-229">○</span><span class="sxs-lookup"><span data-stu-id="36591-229">Yes</span></span>               |
| <span data-ttu-id="36591-230">メディア コントロール ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-230">Media control buttons</span></span>     | <span data-ttu-id="36591-231">×</span><span class="sxs-lookup"><span data-stu-id="36591-231">No</span></span>        | <span data-ttu-id="36591-232">○</span><span class="sxs-lookup"><span data-stu-id="36591-232">Yes</span></span>               |
| <span data-ttu-id="36591-233">[ミュート] ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-233">Mute button</span></span>               | <span data-ttu-id="36591-234">×</span><span class="sxs-lookup"><span data-stu-id="36591-234">No</span></span>        | <span data-ttu-id="36591-235">○</span><span class="sxs-lookup"><span data-stu-id="36591-235">Yes</span></span>               |

### <a name="built-in-button-support"></a><span data-ttu-id="36591-236">組み込みボタンのサポート</span><span class="sxs-lookup"><span data-stu-id="36591-236">Built-in button support</span></span>

<span data-ttu-id="36591-237">UWP は、既存のキーボード入力動作をゲームパッドとリモコンの入力に自動的にマップします。</span><span class="sxs-lookup"><span data-stu-id="36591-237">The UWP automatically maps existing keyboard input behavior to gamepad and remote control input.</span></span> <span data-ttu-id="36591-238">次の表に、これらの組み込みのマッピングを示します。</span><span class="sxs-lookup"><span data-stu-id="36591-238">The following table lists these built-in mappings.</span></span>

| <span data-ttu-id="36591-239">キーボード</span><span class="sxs-lookup"><span data-stu-id="36591-239">Keyboard</span></span>              | <span data-ttu-id="36591-240">ゲームパッド/リモコン</span><span class="sxs-lookup"><span data-stu-id="36591-240">Gamepad/remote</span></span>                        |
|-----------------------|---------------------------------------|
| <span data-ttu-id="36591-241">方向キー</span><span class="sxs-lookup"><span data-stu-id="36591-241">Arrow keys</span></span>            | <span data-ttu-id="36591-242">方向パッド (ゲームパッドの左スティックも同じ)</span><span class="sxs-lookup"><span data-stu-id="36591-242">D-pad (also left stick on gamepad)</span></span>    |
| <span data-ttu-id="36591-243">Space</span><span class="sxs-lookup"><span data-stu-id="36591-243">Spacebar</span></span>              | <span data-ttu-id="36591-244">A/[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-244">A/Select button</span></span>                       |
| <span data-ttu-id="36591-245">Enter</span><span class="sxs-lookup"><span data-stu-id="36591-245">Enter</span></span>                 | <span data-ttu-id="36591-246">A/[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-246">A/Select button</span></span>                       |
| <span data-ttu-id="36591-247">Esc キー</span><span class="sxs-lookup"><span data-stu-id="36591-247">Escape</span></span>                | <span data-ttu-id="36591-248">B/[戻る] ボタン*</span><span class="sxs-lookup"><span data-stu-id="36591-248">B/Back button*</span></span>                        |

<span data-ttu-id="36591-249">\* B ボタンの [KeyDown](https://msdn.microsoft.com/library/windows/apps/br208941.aspx) イベントまたは [KeyUp](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.keyup.aspx) イベントのどちらもアプリで処理されない場合、[SystemNavigationManager.BackRequested](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.systemnavigationmanager.backrequested.aspx) イベントが発生し、アプリで "戻る" ナビゲーションが発生します。</span><span class="sxs-lookup"><span data-stu-id="36591-249">\*When neither the [KeyDown](https://msdn.microsoft.com/library/windows/apps/br208941.aspx) nor [KeyUp](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.keyup.aspx) events for the B button are handled by the app, the [SystemNavigationManager.BackRequested](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.systemnavigationmanager.backrequested.aspx) event will be fired, which should result in back navigation within the app.</span></span> <span data-ttu-id="36591-250">ただし、次のコード スニペットのように、これを自分で実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-250">However, you have to implement this yourself, as in the following code snippet:</span></span>

```csharp
// This code goes in the MainPage class

public MainPage()
{
    this.InitializeComponent();

    // Handling Page Back navigation behaviors
    SystemNavigationManager.GetForCurrentView().BackRequested +=
        SystemNavigationManager_BackRequested;
}

private void SystemNavigationManager_BackRequested(
    object sender,
    BackRequestedEventArgs e)
{
    if (!e.Handled)
    {
        e.Handled = this.BackRequested();
    }
}

public Frame AppFrame { get { return this.Frame; } }

private bool BackRequested()
{
    // Get a hold of the current frame so that we can inspect the app back stack
    if (this.AppFrame == null)
        return false;

    // Check to see if this is the top-most page on the app back stack
    if (this.AppFrame.CanGoBack)
    {
        // If not, set the event to handled and go back to the previous page in the
        // app.
        this.AppFrame.GoBack();
        return true;
    }
    return false;
}
```

<span data-ttu-id="36591-251">Xbox One の UWP アプリでは、**メニュー** ボタンを押してコンテキスト メニューを開く操作もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="36591-251">UWP apps on Xbox One also support pressing the **Menu** button to open context menus.</span></span> <span data-ttu-id="36591-252">詳しくは、「[CommandBar と ContextFlyout](#commandbar-and-contextflyout)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-252">For more information, see [CommandBar and ContextFlyout](#commandbar-and-contextflyout).</span></span>

### <a name="accelerator-support"></a><span data-ttu-id="36591-253">アクセラレータのサポート</span><span class="sxs-lookup"><span data-stu-id="36591-253">Accelerator support</span></span>

<span data-ttu-id="36591-254">アクセラレータ ボタンは、UI でナビゲーションを高速化するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="36591-254">Accelerator buttons are buttons that can be used to speed up navigation through a UI.</span></span> <span data-ttu-id="36591-255">ただし、これらのボタンは特定の入力デバイスにしかない可能性があるため、すべてのユーザーが機能を使用できるとは限らないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-255">However, these buttons may be unique to a certain input device, so keep in mind that not all users will be able to use these functions.</span></span> <span data-ttu-id="36591-256">事実、現在 Xbox One で UWP アプリのアクセラレータ機能をサポートしている入力デバイスは、ゲームパッドだけです。</span><span class="sxs-lookup"><span data-stu-id="36591-256">In fact, gamepad is currently the only input device that supports accelerator functions for UWP apps on Xbox One.</span></span>

<span data-ttu-id="36591-257">次の表に、UWP に組み込まれているアクセラレータのサポートと自分で実装することができるアクセラレータのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="36591-257">The following table lists the accelerator support built into the UWP, as well as that which you can implement on your own.</span></span> <span data-ttu-id="36591-258">一貫性のあるわかりやすいユーザー エクスペリエンスを提供するために、これらの動作をカスタム UI で利用してください。</span><span class="sxs-lookup"><span data-stu-id="36591-258">Utilize these behaviors in your custom UI to provide a consistent and friendly user experience.</span></span>

| <span data-ttu-id="36591-259">操作</span><span class="sxs-lookup"><span data-stu-id="36591-259">Interaction</span></span>   | <span data-ttu-id="36591-260">キーボード/マウス</span><span class="sxs-lookup"><span data-stu-id="36591-260">Keyboard/Mouse</span></span>   | <span data-ttu-id="36591-261">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="36591-261">Gamepad</span></span>      | <span data-ttu-id="36591-262">組み込み済み:</span><span class="sxs-lookup"><span data-stu-id="36591-262">Built-in for:</span></span>  | <span data-ttu-id="36591-263">推奨:</span><span class="sxs-lookup"><span data-stu-id="36591-263">Recommended for:</span></span> |
|---------------|------------|--------------|----------------|------------------|
| <span data-ttu-id="36591-264">ページ アップ/ダウン</span><span class="sxs-lookup"><span data-stu-id="36591-264">Page up/down</span></span>  | <span data-ttu-id="36591-265">ページ アップ/ダウン</span><span class="sxs-lookup"><span data-stu-id="36591-265">Page up/down</span></span> | <span data-ttu-id="36591-266">左/右トリガー</span><span class="sxs-lookup"><span data-stu-id="36591-266">Left/right triggers</span></span> | <span data-ttu-id="36591-267">[CalendarView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.calendarview.aspx)、[ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)、[ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx)、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、`ScrollViewer`、[Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx)、[LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx)、[ComboBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx)、[FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx)</span><span class="sxs-lookup"><span data-stu-id="36591-267">[CalendarView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.calendarview.aspx), [ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx), [ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx), [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx), `ScrollViewer`, [Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx), [LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx), [ComboBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx), [FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx)</span></span> | <span data-ttu-id="36591-268">垂直スクロールをサポートするビュー</span><span class="sxs-lookup"><span data-stu-id="36591-268">Views that support vertical scrolling</span></span>
| <span data-ttu-id="36591-269">ページの左/右</span><span class="sxs-lookup"><span data-stu-id="36591-269">Page left/right</span></span> | <span data-ttu-id="36591-270">なし</span><span class="sxs-lookup"><span data-stu-id="36591-270">None</span></span> | <span data-ttu-id="36591-271">L/R ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-271">Left/right bumpers</span></span> | <span data-ttu-id="36591-272">[Pivot](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx)、[ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)、[ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx)、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、`ScrollViewer`、[Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx)、[LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx)、[FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx)</span><span class="sxs-lookup"><span data-stu-id="36591-272">[Pivot](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx), [ListBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx), [ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx), [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx), `ScrollViewer`, [Selector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.selector.aspx), [LoopingSelector](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.loopingselector.aspx), [FlipView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx)</span></span> | <span data-ttu-id="36591-273">水平スクロールをサポートするビュー</span><span class="sxs-lookup"><span data-stu-id="36591-273">Views that support horizontal scrolling</span></span>
| <span data-ttu-id="36591-274">ズーム イン/アウト</span><span class="sxs-lookup"><span data-stu-id="36591-274">Zoom in/out</span></span>        | <span data-ttu-id="36591-275">Ctrl + 正符号 (+)/負符号 (-)</span><span class="sxs-lookup"><span data-stu-id="36591-275">Ctrl +/-</span></span> | <span data-ttu-id="36591-276">左/右トリガー</span><span class="sxs-lookup"><span data-stu-id="36591-276">Left/right triggers</span></span> | <span data-ttu-id="36591-277">なし</span><span class="sxs-lookup"><span data-stu-id="36591-277">None</span></span> | `ScrollViewer`<span data-ttu-id="36591-278">、拡大と縮小をサポートするビュー</span><span class="sxs-lookup"><span data-stu-id="36591-278">, views that support zooming in and out</span></span> |
| <span data-ttu-id="36591-279">ナビゲーション ウィンドウを開く/閉じる</span><span class="sxs-lookup"><span data-stu-id="36591-279">Open/close nav pane</span></span> | <span data-ttu-id="36591-280">なし</span><span class="sxs-lookup"><span data-stu-id="36591-280">None</span></span> | <span data-ttu-id="36591-281">表示</span><span class="sxs-lookup"><span data-stu-id="36591-281">View</span></span> | <span data-ttu-id="36591-282">なし</span><span class="sxs-lookup"><span data-stu-id="36591-282">None</span></span> | <span data-ttu-id="36591-283">ナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="36591-283">Navigation panes</span></span> |
| [<span data-ttu-id="36591-284">検索</span><span class="sxs-lookup"><span data-stu-id="36591-284">Search</span></span>](#search-experience) | <span data-ttu-id="36591-285">なし</span><span class="sxs-lookup"><span data-stu-id="36591-285">None</span></span> | <span data-ttu-id="36591-286">Y ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-286">Y button</span></span> | <span data-ttu-id="36591-287">なし</span><span class="sxs-lookup"><span data-stu-id="36591-287">None</span></span> | <span data-ttu-id="36591-288">アプリのメインの検索機能へのショートカット</span><span class="sxs-lookup"><span data-stu-id="36591-288">Shortcut to the main search function in the app</span></span> |
| [<span data-ttu-id="36591-289">コンテキスト メニューを開く</span><span class="sxs-lookup"><span data-stu-id="36591-289">Open context menu</span></span>](#commandbar-and-contextflyout) | <span data-ttu-id="36591-290">右クリック</span><span class="sxs-lookup"><span data-stu-id="36591-290">Right-click</span></span> | <span data-ttu-id="36591-291">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="36591-291">Menu button</span></span> | [<span data-ttu-id="36591-292">ContextFlyout</span><span class="sxs-lookup"><span data-stu-id="36591-292">ContextFlyout</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_ContextFlyout) | <span data-ttu-id="36591-293">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="36591-293">Context menus</span></span> |

## <a name="xy-focus-navigation-and-interaction"></a><span data-ttu-id="36591-294">XY フォーカス ナビゲーションと対話式操作</span><span class="sxs-lookup"><span data-stu-id="36591-294">XY focus navigation and interaction</span></span>

<span data-ttu-id="36591-295">アプリがキーボードの適切なフォーカス ナビゲーションをサポートしている場合、ゲームパッドとリモコンでも適切にサポートされます。</span><span class="sxs-lookup"><span data-stu-id="36591-295">If your app supports proper focus navigation for keyboard, this will translate well to gamepad and remote control.</span></span>
<span data-ttu-id="36591-296">方向キーを使ったナビゲーションは**方向パッド** (とゲームパッドの**左スティック**) にマップされ、UI 要素の対話式操作は **Enter/[選択]** キーにマップされます (「[ゲームパッドとリモコン](#gamepad-and-remote-control)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="36591-296">Navigation with the arrow keys is mapped to the **D-pad** (as well as the **left stick** on gamepad), and interaction with UI elements is mapped to the **Enter/Select** key (see [Gamepad and remote control](#gamepad-and-remote-control)).</span></span>

<span data-ttu-id="36591-297">多くのイベントやプロパティがキーボードとゲームパッドの両方で使用されます。キーボードとゲームパッドはいずれも `KeyDown` イベントと `KeyUp` イベントを発生させ、`IsTabStop="True"` プロパティと `Visibility="Visible"` プロパティを持つコントロール間のみを移動します。</span><span class="sxs-lookup"><span data-stu-id="36591-297">Many events and properties are used by both keyboard and gamepad&mdash;they both fire `KeyDown` and `KeyUp` events, and they both will only navigate to controls that have the properties `IsTabStop="True"` and `Visibility="Visible"`.</span></span> <span data-ttu-id="36591-298">キーボードの設計ガイダンスについては、「[キーボード操作](keyboard-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-298">For keyboard design guidance, see [Keyboard interactions](keyboard-interactions.md).</span></span>

<span data-ttu-id="36591-299">キーボードのサポートが適切に実装されている場合、アプリはかなり適切に機能します。ただし、すべてのシナリオをサポートするためには追加の作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="36591-299">If keyboard support is implemented properly, your app will work reasonably well; however, there may be some extra work required to support every scenario.</span></span> <span data-ttu-id="36591-300">最適なユーザー エクスペリエンスを提供するために、アプリ固有のニーズについて考えてください。</span><span class="sxs-lookup"><span data-stu-id="36591-300">Think about your app's specific needs to provide the best user experience possible.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="36591-301">マウス モードは、Xbox One で実行されている UWP アプリでは既定で有効です。</span><span class="sxs-lookup"><span data-stu-id="36591-301">Mouse mode is enabled by default for UWP apps running on Xbox One.</span></span> <span data-ttu-id="36591-302">マウス モードを無効にし、XY フォーカス ナビゲーションを有効にするには、`Application.RequiresPointerMode=WhenRequested` を設定します。</span><span class="sxs-lookup"><span data-stu-id="36591-302">To disable mouse mode and enable XY focus navigation, set `Application.RequiresPointerMode=WhenRequested`.</span></span>

### <a name="debugging-focus-issues"></a><span data-ttu-id="36591-303">フォーカスの問題のデバッグ</span><span class="sxs-lookup"><span data-stu-id="36591-303">Debugging focus issues</span></span>

<span data-ttu-id="36591-304">[FocusManager.GetFocusedElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.focusmanager.getfocusedelement.aspx) メソッドによって、現在、どの要素にフォーカスがあるかがわかります。</span><span class="sxs-lookup"><span data-stu-id="36591-304">The [FocusManager.GetFocusedElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.focusmanager.getfocusedelement.aspx) method will tell you which element currently has focus.</span></span> <span data-ttu-id="36591-305">これは、フォーカス表示の場所が明確ではない場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="36591-305">This is useful for situations where the location of the focus visual may not be obvious.</span></span> <span data-ttu-id="36591-306">この情報は、Visual Studio の出力ウィンドウに次のように記録できます。</span><span class="sxs-lookup"><span data-stu-id="36591-306">You can log this information to the Visual Studio output window like so:</span></span>

```csharp
page.GotFocus += (object sender, RoutedEventArgs e) =>
{
    FrameworkElement focus = FocusManager.GetFocusedElement() as FrameworkElement;
    if (focus != null)
    {
        Debug.WriteLine("got focus: " + focus.Name + " (" +
            focus.GetType().ToString() + ")");
    }
};
```

<span data-ttu-id="36591-307">XY ナビゲーションが期待どおりに動作しない場合の一般的な理由には、次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="36591-307">There are three common reasons why XY navigation might not work the way you expect:</span></span>

* <span data-ttu-id="36591-308">[IsTabStop](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.istabstop.aspx) プロパティまたは [Visibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.visibility.aspx) プロパティが正しく設定されていません。</span><span class="sxs-lookup"><span data-stu-id="36591-308">The [IsTabStop](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.istabstop.aspx) or [Visibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.visibility.aspx) property is set wrong.</span></span>
* <span data-ttu-id="36591-309">フォーカスを取得するコントロールが、実際には想定以上の大きさです。XY ナビゲーションでは、関心のあるものをレンダリングするコントロールの部分だけでなく、コントロールの合計サイズ ([ActualWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.actualwidth.aspx) と [ActualHeight](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.actualheight.aspx)) が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="36591-309">The control getting focus is actually bigger than you think&mdash;XY navigation looks at the total size of the control ([ActualWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.actualwidth.aspx) and [ActualHeight](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.actualheight.aspx)), not just the portion of the control that renders something interesting.</span></span>
* <span data-ttu-id="36591-310">フォーカス対応コントロールが別のコントロールの上に配置されています。XY ナビゲーションでは、重なり合ったコントロールはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="36591-310">One focusable control is on top of another&mdash;XY navigation doesn't support controls that are overlapped.</span></span>

<span data-ttu-id="36591-311">これらの問題を解決しても XY ナビゲーションが引き続き機能しない場合は、「[既定のナビゲーションのオーバーライド](#overriding-the-default-navigation)」で説明されている方法を使って、フォーカスを取得する要素を手動で指定できます。</span><span class="sxs-lookup"><span data-stu-id="36591-311">If XY navigation is still not working the way you expect after fixing these issues, you can manually point to the element that you want to get focus using the method described in [Overriding the default navigation](#overriding-the-default-navigation).</span></span>

<span data-ttu-id="36591-312">XY ナビゲーションは意図したとおりに動作するが、フォーカス表示が表示されない場合は、次のいずれかの問題が原因である可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-312">If XY navigation is working as intended but no focus visual is displayed, one of the following issues may be the cause:</span></span>

* <span data-ttu-id="36591-313">コントロールを再テンプレート化しましたが、フォーカス表示を含めていませんでした。</span><span class="sxs-lookup"><span data-stu-id="36591-313">You re-templated the control and didn't include a focus visual.</span></span> <span data-ttu-id="36591-314">`UseSystemFocusVisuals="True"` を設定するか、フォーカス表示を手動で追加します。</span><span class="sxs-lookup"><span data-stu-id="36591-314">Set `UseSystemFocusVisuals="True"` or add a focus visual manually.</span></span>
* <span data-ttu-id="36591-315">`Focus(FocusState.Pointer)` を呼び出してフォーカスを移動しました。</span><span class="sxs-lookup"><span data-stu-id="36591-315">You moved the focus by calling `Focus(FocusState.Pointer)`.</span></span> <span data-ttu-id="36591-316">[FocusState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.focusstate.aspx) パラメーターによって、フォーカス表示の処理を制御できます。</span><span class="sxs-lookup"><span data-stu-id="36591-316">The [FocusState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.focusstate.aspx) parameter controls what happens to the focus visual.</span></span> <span data-ttu-id="36591-317">一般的には、これを `FocusState.Programmatic` に設定してください。これにより、フォーカスが以前に表示されていた場合は表示され、以前に非表示であった場合は非表示になります。</span><span class="sxs-lookup"><span data-stu-id="36591-317">Generally you should set this to `FocusState.Programmatic`, which keeps the focus visual visible if it was visible before, and hidden if it was hidden before.</span></span>

<span data-ttu-id="36591-318">このセクションの残りの部分では、XY ナビゲーションを使用する場合の一般的な設計上の課題と、その解決方法のいくつかについて詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="36591-318">The rest of this section goes into detail about common design challenges when using XY navigation, and offers several ways to solve them.</span></span>

### <a name="inaccessible-ui"></a><span data-ttu-id="36591-319">アクセスできない UI</span><span class="sxs-lookup"><span data-stu-id="36591-319">Inaccessible UI</span></span>

<span data-ttu-id="36591-320">XY フォーカス ナビゲーションはユーザーの動作を上下左右への移動に制限しているため、UI の一部にアクセスできなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-320">Because XY focus navigation limits the user to moving up, down, left, and right, you may end up with scenarios where parts of the UI are inaccessible.</span></span>
<span data-ttu-id="36591-321">次の図は、XY フォーカス ナビゲーションでサポートされていない UI レイアウトの例を示します。</span><span class="sxs-lookup"><span data-stu-id="36591-321">The following diagram illustrates an example of the kind of UI layout that XY focus navigation doesn't support.</span></span>
<span data-ttu-id="36591-322">垂直および水平方向ナビゲーションが優先され、中央の要素はフォーカスを獲得できるほど優先順位が高くないため、ゲームパッド/リモコンを使って中央の要素にアクセスできないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-322">Note that the element in the middle is not accessible by using gamepad/remote because the vertical and horizontal navigation will be prioritized and the middle element will never be high enough priority to get focus.</span></span>

![4 隅の要素と、アクセスできない中央の要素](images/designing-for-tv/2d-navigation-best-practices-ui-layout-to-avoid.png)

<span data-ttu-id="36591-324">何らかの理由で UI の配置を変更できない場合は、次のセクションで説明する手法のいずれかを使って、フォーカスの既定の動作をオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="36591-324">If for some reason rearranging the UI is not possible, use one of the techniques discussed in the next section to override the default focus behavior.</span></span>

### <a name="overriding-the-default-navigation"></a><span data-ttu-id="36591-325">既定のナビゲーションのオーバーライド</span><span class="sxs-lookup"><span data-stu-id="36591-325">Overriding the default navigation</span></span>

<span data-ttu-id="36591-326">ユニバーサル Windows プラットフォームは、方向パッド/左スティックによるナビゲーションがユーザーにとって意味のあるものであることを確認しようとしますが、アプリの目的に沿って最適化された動作を保証することはできません。</span><span class="sxs-lookup"><span data-stu-id="36591-326">While the Universal Windows Platform tries to ensure that D-pad/left stick navigation makes sense to the user, it cannot guarantee behavior that is optimized for your app's intentions.</span></span>
<span data-ttu-id="36591-327">ナビゲーションがアプリ用に最適化されていることを確認する最善の方法は、ゲームパッドを使ってナビゲーションをテストし、アプリのシナリオにとって適切な方法でユーザーがすべての UI 要素にアクセスできることを確認することです。</span><span class="sxs-lookup"><span data-stu-id="36591-327">The best way to ensure that navigation is optimized for your app is to test it with a gamepad and confirm that every UI element can be accessed by the user in a manner that makes sense for your app's scenarios.</span></span> <span data-ttu-id="36591-328">アプリのシナリオで、提供されている XY フォーカス ナビゲーションでは実現できない動作が必要となる場合は、次のセクションの推奨事項に従ったり、動作をオーバーライドして適切な項目にフォーカスを設定したりことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="36591-328">In case your app's scenarios call for a behavior not achieved through the XY focus navigation provided, consider following the recommendations in the following sections and/or overriding the behavior to place the focus on a logical item.</span></span>

<span data-ttu-id="36591-329">次のコード スニペットは、XY フォーカス ナビゲーションの動作をオーバーライドする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="36591-329">The following code snippet shows how you might override the XY focus navigation behavior:</span></span>

```xml
<StackPanel>
    <Button x:Name="MyBtnLeft"
            Content="Search" />
    <Button x:Name="MyBtnRight"
            Content="Delete"/>
    <Button x:Name="MyBtnTop"
            Content="Update" />
    <Button x:Name="MyBtnDown"
            Content="Undo" />
    <Button Content="Home"  
            XYFocusLeft="{x:Bind MyBtnLeft}"
            XYFocusRight="{x:Bind MyBtnRight}"
            XYFocusDown="{x:Bind MyBtnDown}"
            XYFocusUp="{x:Bind MyBtnTop}" />
</StackPanel>
```

<span data-ttu-id="36591-330">この場合、フォーカスが `Home` ボタンにある状態でユーザーが左に移動すると、フォーカスは `MyBtnLeft` ボタンに移ります。ユーザーが右に移動すると、フォーカスは `MyBtnRight` ボタンに移ります (以下、同様です)。</span><span class="sxs-lookup"><span data-stu-id="36591-330">In this case, when focus is on the `Home` button and the user navigates to the left, focus will move to the `MyBtnLeft` button; if the user navigates to the right, focus will move to the `MyBtnRight` button; and so on.</span></span>

<span data-ttu-id="36591-331">フォーカスが特定の方向でコントロールから移動することを防ぐには、`XYFocus*` プロパティを使ってそのコントロールで方向を指定します。</span><span class="sxs-lookup"><span data-stu-id="36591-331">To prevent the focus from moving from a control in a certain direction, use the `XYFocus*` property to point it at the same control:</span></span>

```xml
<Button Name="HomeButton"  
        Content="Home"  
        XYFocusLeft ="{x:Bind HomeButton}" />
```

<span data-ttu-id="36591-332">これらの `XYFocus` プロパティを使用して、コントロールの親は、次のフォーカスの候補がビジュアル ツリー外である場合、子のナビゲーションを強制することができます。ただし、フォーカスを持つ子が同じ `XYFocus` プロパティを使用している場合を除きます。</span><span class="sxs-lookup"><span data-stu-id="36591-332">Using these `XYFocus` properties, a control parent can also force the navigation of its children when the next focus candidate is out of its visual tree, unless the child who has the focus uses the same `XYFocus` property.</span></span>

```xml
<StackPanel Orientation="Horizontal" Margin="300,300">
    <UserControl XYFocusRight="{x:Bind ButtonThree}">
        <StackPanel>
            <Button Content="One"/>
            <Button Content="Two"/>
        </StackPanel>
    </UserControl>
    <StackPanel>
        <Button x:Name="ButtonThree" Content="Three"/>
        <Button Content="Four"/>
    </StackPanel>
</StackPanel>
```

<span data-ttu-id="36591-333">上記のサンプルでは、フォーカスが `Button` Two にあり、ユーザーが右に移動した場合、最適なフォーカスの候補は `Button` Four ですが、フォーカスは `Button` Three に移動します。これは、親の `UserControl` で、ビジュアル ツリー外である場合はその場所に移動するように強制されているためです。</span><span class="sxs-lookup"><span data-stu-id="36591-333">In the sample above, if the focus is on `Button` Two and the user navigates to the right, the best focus candidate is `Button` Four; however, the focus is moved to `Button` Three because the parent `UserControl` forces it to navigate there when it is out of its visual tree.</span></span>

### <a name="path-of-least-clicks"></a><span data-ttu-id="36591-334">最小回数のクリック数</span><span class="sxs-lookup"><span data-stu-id="36591-334">Path of least clicks</span></span>

<span data-ttu-id="36591-335">ユーザーが最も一般的なタスクを最小クリック回数で実行できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-335">Try to allow the user to perform the most common tasks in the least number of clicks.</span></span> <span data-ttu-id="36591-336">次の例では、(最初にフォーカスがある) **再生**ボタンとよく使われる要素の間に [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) が配置されているため、優先順位の高いタスクの間に不要な要素が入り込んでいます。</span><span class="sxs-lookup"><span data-stu-id="36591-336">In the following example, the [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) is placed between the **Play** button (which initially gets focus) and a commonly used element, so that an unnecessary element is placed in between priority tasks.</span></span>

![ナビゲーションのベスト プラクティスは最小限のクリックのパスを提供すること](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks.png)

<span data-ttu-id="36591-338">次の例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) は**再生**ボタンの上に配置されています。</span><span class="sxs-lookup"><span data-stu-id="36591-338">In the following example, the [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) is placed above the **Play** button instead.</span></span>
<span data-ttu-id="36591-339">優先順位の高いタスクの間に不要な要素が配置されないように UI を並べ替えるだけで、アプリの操作性が大幅に向上します。</span><span class="sxs-lookup"><span data-stu-id="36591-339">Simply rearranging the UI so that unnecessary elements are not placed in between priority tasks will greatly improve your app's usability.</span></span>

![優先順位の高いタスクの間から再生ボタンの上に移動した TextBlock](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks-2.png)

### <a name="commandbar-and-contextflyout"></a><span data-ttu-id="36591-341">CommandBar と ContextFlyout</span><span class="sxs-lookup"><span data-stu-id="36591-341">CommandBar and ContextFlyout</span></span>

<span data-ttu-id="36591-342">「[問題: 長いスクロールをするリストやグリッドの後にある UI 要素](#problem-ui-elements-located-after-long-scrolling-list-grid)」で説明するように、[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) を使う場合はリストのスクロールの問題に配慮してください。</span><span class="sxs-lookup"><span data-stu-id="36591-342">When using a [CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx), keep in mind the issue of scrolling through a list as mentioned in [Problem: UI elements located after long scrolling list/grid](#problem-ui-elements-located-after-long-scrolling-list-grid).</span></span> <span data-ttu-id="36591-343">次の図は、`CommandBar` がリストやグリッドの下にある UI レイアウトです。</span><span class="sxs-lookup"><span data-stu-id="36591-343">The following image shows a UI layout with the `CommandBar` on the bottom of a list/grid.</span></span> <span data-ttu-id="36591-344">ユーザーはリストやグリッド全体をスクロールしなければ `CommandBar` に到達できません。</span><span class="sxs-lookup"><span data-stu-id="36591-344">The user would need to scroll all the way down through the list/grid to reach the `CommandBar`.</span></span>

![リストやグリッドの下にある CommandBar](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout.png)

<span data-ttu-id="36591-346">リストやグリッドの*上*に `CommandBar` を配置した場合はどうなるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="36591-346">What if you put the `CommandBar` *above* the list/grid?</span></span> <span data-ttu-id="36591-347">リストやグリッドを下へスクロールしたユーザーは `CommandBar` に戻るために上へスクロールして戻る必要がありますが、前の構成よりもナビゲーションはわずかに少なくなります。</span><span class="sxs-lookup"><span data-stu-id="36591-347">While a user who scrolled down the list/grid would have to scroll back up to reach the `CommandBar`, it is slightly less navigation than the previous configuration.</span></span> <span data-ttu-id="36591-348">ただし、これは、アプリの最初のフォーカスが `CommandBar` の横または上に配置されている場合です。最初のフォーカスがリストやグリッドの下にある場合、この方法はうまく機能しません。</span><span class="sxs-lookup"><span data-stu-id="36591-348">Note that this is assuming that your app's initial focus is placed next to or above the `CommandBar`; this approach won't work as well if the initial focus is below the list/grid.</span></span> <span data-ttu-id="36591-349">これらの `CommandBar` 項目があまりアクセスする必要のないグローバルな操作の項目の場合 (**同期** ボタンなど)、リストやグリッドの上に置いても問題ありません。</span><span class="sxs-lookup"><span data-stu-id="36591-349">If these `CommandBar` items are global action items that don't have to be accessed very often (such as a **Sync** button), it may be acceptable to have them above the list/grid.</span></span>

<span data-ttu-id="36591-350">`CommandBar` の項目を縦方向に重ねることはできませんが、UI レイアウトで適切な場合はスクロール方向と異なる向き (たとえば、縦方向にスクロールするリストの左右や、横方向にスクロールするリストの上下) に項目を配置することも検討できます。</span><span class="sxs-lookup"><span data-stu-id="36591-350">While you can't stack a `CommandBar`'s items vertically, placing them against the scroll direction (for example, to the left or right of a vertically scrolling list, or the top or bottom of a horizontally scrolling list) is another option you may want to consider if it works well for your UI layout.</span></span>

<span data-ttu-id="36591-351">ユーザーが項目に簡単にアクセスできる必要がある `CommandBar` をアプリで使う場合、それらの項目を [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) 内に配置して `CommandBar` から削除することを検討できます。</span><span class="sxs-lookup"><span data-stu-id="36591-351">If your app has a `CommandBar` whose items need to be readily accessible by users, you may want to consider placing these items inside a [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) and removing them from the `CommandBar`.</span></span> `ContextFlyout` <span data-ttu-id="36591-352">は、[UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx) のプロパティであり、その要素に関連づけられた[コンテキスト メニュー](../controls-and-patterns/dialogs-popups-menus.md)です。</span><span class="sxs-lookup"><span data-stu-id="36591-352">is a property of [UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx) and is the [context menu](../controls-and-patterns/dialogs-popups-menus.md) associated with that element.</span></span> <span data-ttu-id="36591-353">PC では、`ContextFlyout` を持つ要素を右クリックすると、そのコンテキスト メニューがポップアップ表示されます。</span><span class="sxs-lookup"><span data-stu-id="36591-353">On PC, when you right-click on an element with a `ContextFlyout`, that context menu will pop up.</span></span> <span data-ttu-id="36591-354">Xbox One では、このような要素にフォーカスがあるときに**メニュー** ボタンを押すと、コンテキスト メニューがポップアップ表示されます。</span><span class="sxs-lookup"><span data-stu-id="36591-354">On Xbox One, this will happen when you press the **Menu** button while the focus is on such an element.</span></span>

<!--The following XAML code demonstrates a simple `ContextFlyout`:

```xml
<Button HorizontalAlignment="Center"
        Content="Context Flyout">
    <Button.ContextFlyout>
        <MenuFlyout>
            <MenuFlyoutItem Text="Item 1"/>
        </MenuFlyout>
    </Button.ContextFlyout>
</Button>
```

In the above example, when you press the **Menu** button while the [Button](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx) has focus, the context menu appears with the menu item labeled **Item 1**.

`ContextFlyout` takes any element of type [FlyoutBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.aspx); however, most of the time you will likely use [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.aspx) or [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyout.aspx).

Alternatively, you can listen for the [ContextRequested](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextrequested.aspx) event, which occurs when the user has completed a context input gesture (pressing the **Menu** button). In this case you can, in the code-behind, create the context menu, attach it to the **UIElement**, and show the flyout when the event is raised.

The following C# code demonstrates a simple example of this:

```csharp
MenuFlyout myFlyout = new MenuFlyout();
MenuFlyoutItem item1 = new MenuFlyoutItem();
item1.Text = "Item 1";
myFlyout.Items.Add(item1);
MyButton.ContextFlyout = myFlyout;

private void MyButton_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
{
    Point point = new Point(0, 0);
    if (args.TryGetPosition(sender, out point)
    {
        myFlyout.ShowAt(sender, point);
    }
    else
    {
        myFlyout.ShowAt(sender as FrameworkElement);
    }
}
```
> **Note** Don't use both of these options, as `ContextFlyout` already handles the `ContextRequested` event.-->

### <a name="ui-layout-challenges"></a><span data-ttu-id="36591-355">UI レイアウトの問題</span><span class="sxs-lookup"><span data-stu-id="36591-355">UI layout challenges</span></span>

<span data-ttu-id="36591-356">XY フォーカス ナビゲーションの特性により、一部の UI レイアウトは設定が難しく、状況ごとに評価が必要です。</span><span class="sxs-lookup"><span data-stu-id="36591-356">Some UI layouts are more challenging due to the nature of XY focus navigation, and should be evaluated on a case-by-case basis.</span></span> <span data-ttu-id="36591-357">"正解" は 1 つではなく、どの解決策を選ぶかはアプリのニーズ次第ですが、優れたテレビ エクスペリエンスを提供するために利用できる方法がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="36591-357">While there is no single "right" way, and which solution you choose is up to your app's specific needs, there are some techniques that you can employ to make a great TV experience.</span></span>

<span data-ttu-id="36591-358">このことをさらに理解するために、架空のアプリでこれらの問題のいくつかとそれを克服する手法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="36591-358">To understand this better, let's look at an imaginary app that illustrates some of these issues and techniques to overcome them.</span></span>

> [!NOTE]
> <span data-ttu-id="36591-359">この架空のアプリは、UI の問題とその解決策を示すことを目的としており、実際のアプリの最適なユーザー エクスペリエンスを示すものではありません。</span><span class="sxs-lookup"><span data-stu-id="36591-359">This fake app is meant to illustrate UI problems and potential solutions to them, and is not intended to show the best user experience for your particular app.</span></span>

<span data-ttu-id="36591-360">次の架空の不動産アプリは、販売中の家の一覧、地図、不動産の説明などの情報を表示するものです。</span><span class="sxs-lookup"><span data-stu-id="36591-360">The following is an imaginary real estate app which shows a list of houses available for sale, a map, a description of a property, and other information.</span></span> <span data-ttu-id="36591-361">このアプリでは、次の方法で克服できる 3 つの課題が生じます。</span><span class="sxs-lookup"><span data-stu-id="36591-361">This app poses three challenges that you can overcome by using the following techniques:</span></span>

- [<span data-ttu-id="36591-362">UI の並べ替え</span><span class="sxs-lookup"><span data-stu-id="36591-362">UI rearrange</span></span>](#ui-rearrange)
- [<span data-ttu-id="36591-363">フォーカス エンゲージメント</span><span class="sxs-lookup"><span data-stu-id="36591-363">Focus engagement</span></span>](#engagement)
- [<span data-ttu-id="36591-364">マウス モード</span><span class="sxs-lookup"><span data-stu-id="36591-364">Mouse mode</span></span>](#mouse-mode)

![架空の不動産アプリ](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app.png)

#### <span data-ttu-id="36591-366">問題: 長いスクロールをするリストやグリッドの後にある UI 要素 <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a></span><span class="sxs-lookup"><span data-stu-id="36591-366">Problem: UI elements located after long scrolling list/grid <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a></span></span>

<span data-ttu-id="36591-367">次の図に示すプロパティの [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) は、非常に長いスクロールをするリストです。</span><span class="sxs-lookup"><span data-stu-id="36591-367">The [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) of properties shown in the following image is a very long scrolling list.</span></span> <span data-ttu-id="36591-368">この `ListView` で[エンゲージメント](#focus-engagement)が要求され*ない*場合、ユーザーがリストに移動するとフォーカスはリストの最初の項目に設定されます。</span><span class="sxs-lookup"><span data-stu-id="36591-368">If [engagement](#focus-engagement) is *not* required on the `ListView`, when the user navigates to the list, focus will be placed on the first item in the list.</span></span> <span data-ttu-id="36591-369">ユーザーが **[前へ]** または **[次へ]** ボタンにアクセスするには、リスト内のすべての項目を移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-369">For the user to reach the **Previous** or **Next** button, they must go through all the items in the list.</span></span> <span data-ttu-id="36591-370">このような、リスト全体を移動する必要がある設計は、ユーザーがそのエクスペリエンスを許容できるほどリストが短くなければ煩わしくなるため、その他のオプションを検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-370">In cases like this where requiring the user to traverse the entire list is painful&mdash;that is, when the list is not short enough for this experience to be acceptable&mdash;you may want to consider other options.</span></span>

![不動産アプリ: 50 個の項目があるリストは、下のボタンに移動するまでに 51 回のクリックが必要](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app-list.png)

#### <a name="solutions"></a><span data-ttu-id="36591-372">解決策</span><span class="sxs-lookup"><span data-stu-id="36591-372">Solutions</span></span>

**<span data-ttu-id="36591-373">UI の並べ替え <a name="ui-rearrange"></a></span><span class="sxs-lookup"><span data-stu-id="36591-373">UI rearrange <a name="ui-rearrange"></a></span></span>**

<span data-ttu-id="36591-374">最初のフォーカスがページの下部に設定されない限り、通常、長いスクロールをするリストの上に配置した UI 要素の方が、下に配置した場合よりも簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="36591-374">Unless your initial focus is placed at the bottom of the page, UI elements placed above a long scrolling list are typically more easily accessible than if placed below.</span></span>
<span data-ttu-id="36591-375">この新しいレイアウトが他のデバイスでも有効な場合、Xbox One のためだけに UI に特別な変更を行うのでなく、すべてのデバイス ファミリ用にレイアウトを変更する方が、低コストのアプローチになる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-375">If this new layout works for other devices, changing the layout for all device families instead of doing special UI changes just for Xbox One might be a less costly approach.</span></span>
<span data-ttu-id="36591-376">また、スクロール方向と異なる向き (縦方向にスクロールするリストでは横方向、横方向にスクロールするリストでは縦方向) に UI 要素を配置すると、アクセシビリティがさらに向上します。</span><span class="sxs-lookup"><span data-stu-id="36591-376">Additionally, placing UI elements against the scrolling direction (that is, horizontally to a vertically scrolling list, or vertically to a horizontally scrolling list) will make for even better accessibility.</span></span>

![不動産アプリ: 長いスクロールをするリストの上にボタンを配置](images/designing-for-tv/2d-focus-navigation-and-interaction-ui-rearrange.png)

**<span data-ttu-id="36591-378">フォーカス エンゲージメント <a name="engagement"></a></span><span class="sxs-lookup"><span data-stu-id="36591-378">Focus engagement <a name="engagement"></a></span></span>**

<span data-ttu-id="36591-379">エンゲージメントが*要求される*場合、`ListView` 全体が 1 つのフォーカスの対象になります。</span><span class="sxs-lookup"><span data-stu-id="36591-379">When engagement is *required*, the entire `ListView` becomes a single focus target.</span></span> <span data-ttu-id="36591-380">ユーザーはリストの内容をバイパスして、フォーカス可能な次の要素にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="36591-380">The user will be able to bypass the contents of the list to get to the next focusable element.</span></span> <span data-ttu-id="36591-381">エンゲージメントをサポートしているコントロールとその使用方法について詳しくは、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-381">Read more about what controls support engagement and how to use them in [Focus engagement](#focus-engagement).</span></span>

![不動産アプリ: エンゲージメントの要求を設定して 1 クリックのみで [前へ]/[次へ] ボタンにアクセス](images/designing-for-tv/2d-focus-navigation-and-interaction-engagement.png)

#### <a name="problem-scrollviewer-without-any-focusable-elements"></a><span data-ttu-id="36591-383">問題: フォーカス可能な要素がない ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="36591-383">Problem: ScrollViewer without any focusable elements</span></span>

<span data-ttu-id="36591-384">XY フォーカス ナビゲーションは、フォーカス可能な UI 要素に 1 回で移動できることを前提としているため、フォーカス可能な要素を 1 つも含まない [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) (この例ではテキストのみの要素) は、ユーザーが `ScrollViewer` のすべてのコンテンツを表示することができない状況を招く可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-384">Because XY focus navigation relies on navigating to one focusable UI element at a time, a [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) that doesn't contain any focusable elements (such as one with only text, as in this example) may cause a scenario where the user isn't able to view all of the content in the `ScrollViewer`.</span></span>
<span data-ttu-id="36591-385">この問題の解決策とその他の関連するシナリオについては、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-385">For solutions to this and other related scenarios, see [Focus engagement](#focus-engagement).</span></span>

![不動産アプリ: テキストのみが含まれる ScrollViewer](images/designing-for-tv/2d-focus-navigation-and-interaction-scrollviewer.png)

#### <a name="problem-free-scrolling-ui"></a><span data-ttu-id="36591-387">問題: 自由スクロール UI</span><span class="sxs-lookup"><span data-stu-id="36591-387">Problem: Free-scrolling UI</span></span>

<span data-ttu-id="36591-388">描画面や次の例にある地図など、アプリに自由スクロール UI が必要な場合、XY フォーカス ナビゲーションのみでは機能しません。</span><span class="sxs-lookup"><span data-stu-id="36591-388">When your app requires a freely scrolling UI, such as a drawing surface or, in this example, a map, XY focus navigation simply doesn't work.</span></span>
<span data-ttu-id="36591-389">このような場合は、[マウス モード](#mouse-mode)をオンにして、ユーザーが UI 要素内を自由に移動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-389">In such cases, you can turn on [mouse mode](#mouse-mode) to allow the user to navigate freely inside a UI element.</span></span>

![マウス モードを使う地図の UI 要素](images/designing-for-tv/map-mouse-mode.png)

## <a name="mouse-mode"></a><span data-ttu-id="36591-391">マウス モード</span><span class="sxs-lookup"><span data-stu-id="36591-391">Mouse mode</span></span>

<span data-ttu-id="36591-392">「[XY フォーカス ナビゲーションと対話式操作](#xy-focus-navigation-and-interaction)」で説明するとおり、Xbox One でフォーカスを移動するには、XY ナビゲーション システムを使います。ユーザーは、フォーカスを上下左右に動かしてコントロール間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="36591-392">As described in [XY focus navigation and interaction](#xy-focus-navigation-and-interaction), on Xbox One the focus is moved by using an XY navigation system, allowing the user to shift the focus from control to control by moving up, down, left, and right.</span></span>
<span data-ttu-id="36591-393">ただし、[WebView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx) や [MapControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.maps.mapcontrol.aspx) などの一部のコントロールでは、ユーザーがコントロールの境界内でポインターを自由に動かせる、マウスのような対話式操作が必要です。</span><span class="sxs-lookup"><span data-stu-id="36591-393">However, some controls, such as [WebView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx) and [MapControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.maps.mapcontrol.aspx), require a mouse-like interaction where users can freely move the pointer inside the boundaries of the control.</span></span>
<span data-ttu-id="36591-394">また、ユーザーがページ全体でポインターを動かせるようにして、PC でマウスを使うときと同じようなエクスペリエンスをゲームパッド/リモコンで体験できるようにする必要があるアプリもあります。</span><span class="sxs-lookup"><span data-stu-id="36591-394">There are also some apps where it makes sense for the user to be able to move the pointer across the entire page, having an experience with gamepad/remote similar to what users can find on a PC with a mouse.</span></span>

<span data-ttu-id="36591-395">このような場合、ページ全体に対して、または、ページ内のいずれかのコントロールに対して、ポインター (マウス モード) を要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-395">For these scenarios, you should request a pointer (mouse mode) for the entire page, or on a control inside a page.</span></span>
<span data-ttu-id="36591-396">たとえば、アプリのページで `WebView` コントロールを使い、そのコントロール内ではマウス モード、それ以外はすべて XY フォーカス ナビゲーションを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="36591-396">For example, your app could have a page that has a `WebView` control that uses mouse mode only while inside the control, and XY focus navigation everywhere else.</span></span>
<span data-ttu-id="36591-397">ポインターを要求する場合、**コントロールまたはページが有効になったとき**、または**ページにフォーカスがあるとき**のどちらでポインターを要求するかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="36591-397">To request a pointer, you can specify whether you want it **when a control or page is engaged** or **when a page has focus**.</span></span>

> [!NOTE]
> <span data-ttu-id="36591-398">コントロールにフォーカスがある場合にポインターを要求することはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="36591-398">Requesting a pointer when a control gets focus is not supported.</span></span>

<span data-ttu-id="36591-399">Xbox One で実行されている XAML アプリとホスト型 Web アプリのいずれの場合も、マウス モードがアプリ全体で既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="36591-399">For both XAML and hosted web apps running on Xbox One, mouse mode is turned on by default for the entire app.</span></span> <span data-ttu-id="36591-400">これを無効にして、XY ナビゲーション用にアプリを最適化することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-400">It is highly recommended that you turn this off and optimize your app for XY navigation.</span></span> <span data-ttu-id="36591-401">これを行うには、`Application.RequiresPointerMode` プロパティを `WhenRequested` に設定して、コントロールやページから呼び出された場合にのみマウス モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="36591-401">To do this, set the `Application.RequiresPointerMode` property to `WhenRequested` so that you only enable mouse mode when a control or page calls for it.</span></span>

<span data-ttu-id="36591-402">XAML アプリでこれを行うには、`App` クラスで次のコードを使います。</span><span class="sxs-lookup"><span data-stu-id="36591-402">To do this in a XAML app, use the following code in your `App` class:</span></span>

```csharp
public App()
{
    this.InitializeComponent();
    this.RequiresPointerMode =
        Windows.UI.Xaml.ApplicationRequiresPointerMode.WhenRequested;
    this.Suspending += OnSuspending;
}
```

<span data-ttu-id="36591-403">HTML/JavaScript のサンプル コードなどの詳細情報については、「[マウス モードを無効にする方法](../xbox-apps/how-to-disable-mouse-mode.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-403">For more information, including sample code for HTML/JavaScript, see [How to disable mouse mode](../xbox-apps/how-to-disable-mouse-mode.md).</span></span>

<span data-ttu-id="36591-404">次の図は、マウス モードでのゲームパッド/リモコンのボタンのマッピングを示しています。</span><span class="sxs-lookup"><span data-stu-id="36591-404">The following diagram shows the button mappings for gamepad/remote in mouse mode.</span></span>

![マウス モードでのゲームパッド/リモコンのボタンのマッピング](images/designing-for-tv/10ft_infographics_mouse-mode.png)

> [!NOTE]
> <span data-ttu-id="36591-406">マウス モードは Xbox One のゲームパッド/リモコンのみでサポートされています。</span><span class="sxs-lookup"><span data-stu-id="36591-406">Mouse mode is only supported on Xbox One with gamepad/remote.</span></span> <span data-ttu-id="36591-407">その他のデバイス ファミリや入力タイプでは自動的に無視されます。</span><span class="sxs-lookup"><span data-stu-id="36591-407">On other device families and input types it is silently ignored.</span></span>

<span data-ttu-id="36591-408">コントロールまたはページでマウス モードをアクティブ化するには、そのコントロールまたはページで `RequiresPointer` プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="36591-408">Use the `RequiresPointer` property on a control or page to activate mouse mode on it.</span></span> `RequiresPointer` <span data-ttu-id="36591-409">には `Never` (既定値)、`WhenEngaged`、`WhenFocused` の 3 つの値があります。</span><span class="sxs-lookup"><span data-stu-id="36591-409">has three possible values: `Never` (the default value), `WhenEngaged`, and `WhenFocused`.</span></span>

> [!NOTE]
> `RequiresPointer` <span data-ttu-id="36591-410">は新しい API で、まだ文書化されていません。</span><span class="sxs-lookup"><span data-stu-id="36591-410">is a new API and not yet documented.</span></span>

<!--TODO: Link to doc-->

### <a name="activating-mouse-mode-on-a-control"></a><span data-ttu-id="36591-411">コントロールでのマウス モードのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="36591-411">Activating mouse mode on a control</span></span>

<span data-ttu-id="36591-412">`RequiresPointer="WhenEngaged"` の状態でユーザーがコントロールを使うと、ユーザーが解除するまでコントロールでマウス モードがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="36591-412">When the user engages a control with `RequiresPointer="WhenEngaged"`, mouse mode is activated on the control until the user disengages it.</span></span> <span data-ttu-id="36591-413">次のコード スニペットは、使用時にマウス モードをアクティブ化する単純な `MapControl` を示します。</span><span class="sxs-lookup"><span data-stu-id="36591-413">The following code snippet demonstrates a simple `MapControl` that activates mouse mode when engaged:</span></span>

```xml
<Page>
    <Grid>
        <MapControl IsEngagementRequired="true"
                    RequiresPointer="WhenEngaged"/>
    </Grid>
</Page>
```

> [!NOTE]
> <span data-ttu-id="36591-414">コントロールを使うときにマウス モードをアクティブ化する場合、`IsEngagementRequired="true"` も指定する必要があります。そうしないと、マウス モードがアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="36591-414">If a control activates mouse mode when engaged, it must also require engagement with `IsEngagementRequired="true"`; otherwise, mouse mode will never be activated.</span></span>

<span data-ttu-id="36591-415">コントロールがマウス モードになると、そのコントロールの入れ子になったコントロールもマウス モードになります。</span><span class="sxs-lookup"><span data-stu-id="36591-415">When a control is in mouse mode, its nested controls will be in mouse mode as well.</span></span> <span data-ttu-id="36591-416">その子の要求モードは無視されます。親をマウス モードにして子はマウス モードにしないということはできません。</span><span class="sxs-lookup"><span data-stu-id="36591-416">The requested mode of its children will be ignored&mdash;it's impossible for a parent to be in mouse mode but a child not to be.</span></span>

<span data-ttu-id="36591-417">また、コントロールの要求モードはフォーカスがあるときにのみ調べられます。そのため、フォーカスがある間はモードは動的に変更されません。</span><span class="sxs-lookup"><span data-stu-id="36591-417">Additionally, the requested mode of a control is only inspected when it gets focus, so the mode won't change dynamically while it has focus.</span></span>

### <a name="activating-mouse-mode-on-a-page"></a><span data-ttu-id="36591-418">ページでのマウス モードのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="36591-418">Activating mouse mode on a page</span></span>

<span data-ttu-id="36591-419">ページに `RequiresPointer="WhenFocused"` プロパティを設定している場合、フォーカスがあるとページ全体に対してマウス モードがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="36591-419">When a page has the property `RequiresPointer="WhenFocused"`, mouse mode will be activated for the whole page when it gets focus.</span></span> <span data-ttu-id="36591-420">次のコード スニペットは、ページでこのプロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="36591-420">The following code snippet demonstrates giving a page this property:</span></span>

```xml
<Page RequiresPointer="WhenFocused">
    ...
</Page>
```

> [!NOTE]
> <span data-ttu-id="36591-421">`WhenFocused` の値は [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) オブジェクトでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="36591-421">The `WhenFocused` value is only supported on [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) objects.</span></span> <span data-ttu-id="36591-422">コントロールにこの値を設定しようとすると、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="36591-422">If you try to set this value on a control, an exception will be thrown.</span></span>

### <a name="disabling-mouse-mode-for-full-screen-content"></a><span data-ttu-id="36591-423">全画面コンテンツのマウス モードの無効化</span><span class="sxs-lookup"><span data-stu-id="36591-423">Disabling mouse mode for full screen content</span></span>

<span data-ttu-id="36591-424">通常、全画面表示でビデオやその他の種類のコンテンツを表示する場合、ユーザーの注意をそらす可能性があるため、カーソルを非表示にします。</span><span class="sxs-lookup"><span data-stu-id="36591-424">Usually when displaying video or other types of content in full screen, you will want to hide the cursor because it can distract the user.</span></span> <span data-ttu-id="36591-425">このシナリオは、アプリの他の部分ではマウス モードを使用するが、全画面コンテンツを表示するときはマウス モードを無効にする必要がある場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="36591-425">This scenario occurs when the rest of the app uses mouse mode, but you want to turn it off when showing full screen content.</span></span> <span data-ttu-id="36591-426">これを実現するには、全画面コンテンツを独自の `Page` に配置し、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="36591-426">To accomplish this, put the full screen content on its own `Page`, and follow the steps below.</span></span>

1. <span data-ttu-id="36591-427">`App` オブジェクトで、`RequiresPointerMode="WhenRequested"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="36591-427">In the `App` object, set `RequiresPointerMode="WhenRequested"`.</span></span>
2. <span data-ttu-id="36591-428">全画面表示の `Page` を*除く*すべての `Page` オブジェクトで、`RequiresPointer="WhenFocused"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="36591-428">In every `Page` object *except* for the full screen `Page`, set `RequiresPointer="WhenFocused"`.</span></span>
3. <span data-ttu-id="36591-429">全画面表示の `Page` で、`RequiresPointer="Never"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="36591-429">For the full screen `Page`, set `RequiresPointer="Never"`.</span></span>

<span data-ttu-id="36591-430">これにより、全画面コンテンツを表示するときに、カーソルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="36591-430">This way, the cursor will never appear when showing full screen content.</span></span>

## <a name="focus-visual"></a><span data-ttu-id="36591-431">フォーカス表示</span><span class="sxs-lookup"><span data-stu-id="36591-431">Focus visual</span></span>

<span data-ttu-id="36591-432">フォーカス表示とは、現在フォーカスがある UI 要素を囲む境界線のことです。</span><span class="sxs-lookup"><span data-stu-id="36591-432">The focus visual is the border around the UI element that currently has focus.</span></span> <span data-ttu-id="36591-433">この機能を使ってユーザーの現在位置をわかりやすく示すことで、ユーザーが自分の位置を見失わずに UI を移動しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="36591-433">This helps orient the user so that they can easily navigate your UI without getting lost.</span></span>

<span data-ttu-id="36591-434">フォーカス表示は、表示が更新され、多数のカスタマイズ オプションが追加されているため、開発者は 1 つのフォーカス表示を用意すれば、PC と Xbox One、さらにはキーボードやゲームパッド/リモコンをサポートするその他の Windows 10 デバイスで正しく動作することを期待できます。</span><span class="sxs-lookup"><span data-stu-id="36591-434">With a visual update and numerous customization options added to focus visual, developers can trust that a single focus visual will work well on PCs and Xbox One, as well as on any other Windows 10 devices that support keyboard and/or gamepad/remote.</span></span>

<span data-ttu-id="36591-435">ただし、異なるプラットフォームで同じフォーカス表示を使うことはできますが、10 フィート エクスペリエンスではフォーカス表示の利用状況がやや異なります。</span><span class="sxs-lookup"><span data-stu-id="36591-435">While the same focus visual can be used across different platforms, the context in which the user encounters it is slightly different for the 10-foot experience.</span></span> <span data-ttu-id="36591-436">この場合、ユーザーはテレビ画面全体に十分注意を払っていないと想定し、ユーザーが表示を探す際にフラストレーションを感じないように、現在フォーカスのある要素を常に明確に表示することが重要です。</span><span class="sxs-lookup"><span data-stu-id="36591-436">You should assume that the user is not paying full attention to the entire TV screen, and therefore it is important that the currently focused element is clearly visible to the user at all times to avoid the frustration of searching for the visual.</span></span>

<span data-ttu-id="36591-437">また、フォーカス表示は、ゲームパッドやリモコンを使うときは既定で表示されますが、キーボードを使うときは既定で表示*されない*ことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-437">It is also important to keep in mind that the focus visual is displayed by default when using a gamepad or remote control, but *not* a keyboard.</span></span> <span data-ttu-id="36591-438">したがって、実装していなくても Xbox One でアプリを実行すると表示されます。</span><span class="sxs-lookup"><span data-stu-id="36591-438">Thus, even if you don't implement it, it will appear when you run your app on Xbox One.</span></span>

### <a name="initial-focus-visual-placement"></a><span data-ttu-id="36591-439">フォーカス表示の初期設定</span><span class="sxs-lookup"><span data-stu-id="36591-439">Initial focus visual placement</span></span>

<span data-ttu-id="36591-440">アプリを起動したりページに移動したりするときは、ユーザーがアクションを実行する最初の要素として意味のある UI 要素にフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="36591-440">When launching an app or navigating to a page, place the focus on a UI element that makes sense as the first element on which the user would take action.</span></span> <span data-ttu-id="36591-441">たとえば、フォト アプリではギャラリー内の最初の項目にフォーカスを設定し、音楽アプリで曲の詳細ビューに移動する場合は音楽を再生しやすいように再生ボタンにフォーカスを設定できます。</span><span class="sxs-lookup"><span data-stu-id="36591-441">For example, a photo app may place focus on the first item in the gallery, and a music app navigated to a detailed view of a song might place focus on the play button for ease of playing music.</span></span>

<span data-ttu-id="36591-442">初期フォーカスは、アプリの左上 (右から左へ移動する場合は右上) の領域に設定するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-442">Try to put initial focus in the top left region of your app (or top right for a right-to-left flow).</span></span> <span data-ttu-id="36591-443">通常、アプリのコンテンツ フローはそこから開始されるため、ほとんどのユーザーは最初にその隅を意識する傾向があります。</span><span class="sxs-lookup"><span data-stu-id="36591-443">Most users tend to focus on that corner first because that's where app content flow generally begins.</span></span>

### <a name="making-focus-clearly-visible"></a><span data-ttu-id="36591-444">フォーカスの明確な表示</span><span class="sxs-lookup"><span data-stu-id="36591-444">Making focus clearly visible</span></span>

<span data-ttu-id="36591-445">ユーザーがフォーカスを探さなくても前回の終了位置を選べるように、1 つのフォーカス表示が常に画面に表示されているようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-445">One focus visual should always be visible on the screen so that the user can pick up where they left off without searching for the focus.</span></span> <span data-ttu-id="36591-446">同様に、フォーカス可能な項目を常に画面上に表示する必要があります。たとえば、フォーカス可能な要素がない、テキストのみのポップアップを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="36591-446">Similarly, there should be a focusable item onscreen at all times&mdash;for example, don't use pop-ups with only text and no focusable elements.</span></span>

<span data-ttu-id="36591-447">このルールの例外は、ビデオの視聴や画像の表示などの全画面表示エクスペリエンスです。この場合、フォーカス表示を行うことは適切ではありません。</span><span class="sxs-lookup"><span data-stu-id="36591-447">An exception to this rule would be for full-screen experiences, such as watching videos or viewing images, in which cases it would not be appropriate to show the focus visual.</span></span>

### <a name="customizing-the-focus-visual"></a><span data-ttu-id="36591-448">フォーカスの表示のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="36591-448">Customizing the focus visual</span></span>

<span data-ttu-id="36591-449">フォーカス表示をカスタマイズする場合は、各コントロールのフォーカス表示に関連するプロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="36591-449">If you'd like to customize the focus visual, you can do so by modifying the properties related to the focus visual for each control.</span></span> <span data-ttu-id="36591-450">アプリのパーソナル設定に活用できるこのようなプロパティはいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="36591-450">There are several such properties that you can take advantage of to personalize your app.</span></span>

<span data-ttu-id="36591-451">表示状態を使って独自のフォーカス表示を描画することにより、システムが提供するフォーカス表示を除外することもできます。</span><span class="sxs-lookup"><span data-stu-id="36591-451">You can even opt out of the system-provided focus visuals by drawing your own using visual states.</span></span> <span data-ttu-id="36591-452">詳しくは、「[VisualState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.visualstate.Aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-452">To learn more, see [VisualState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.visualstate.Aspx).</span></span>

### <a name="light-dismiss-overlay"></a><span data-ttu-id="36591-453">簡易非表示オーバーレイ</span><span class="sxs-lookup"><span data-stu-id="36591-453">Light dismiss overlay</span></span>

<span data-ttu-id="36591-454">ユーザーが現在ゲーム コントローラーまたはリモコンで操作している UI 要素にユーザーの注意を引きつけるために、アプリが Xbox One で実行されている場合は、UWP ではポップアップ UI 以外の領域をカバーする「スモーク」レイヤーが自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="36591-454">To call the user's attention to the UI elements that the user is currently manipulating with the game controller or remote control, the UWP automatically adds a "smoke" layer that covers areas outside of the popup UI when the app is running on Xbox One.</span></span> <span data-ttu-id="36591-455">このための追加作業は必要ありませんが、UI を設計する際に留意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-455">This requires no extra work, but is something to keep in mind when designing your UI.</span></span> <span data-ttu-id="36591-456">いずれかの `FlyoutBase` で `LightDismissOverlayMode` プロパティを設定して、スモーク レイヤーを有効または無効にすることができます。既定の設定は `Auto` で、Xbox では有効になり、その他の場所では無効になります。</span><span class="sxs-lookup"><span data-stu-id="36591-456">You can set the `LightDismissOverlayMode` property on any `FlyoutBase` to enable or disable the smoke layer; it defaults to `Auto`, meaning that it is enabled on Xbox and disabled elsewhere.</span></span> <span data-ttu-id="36591-457">詳しくは、「[モーダルと簡易非表示](../controls-and-patterns/menus.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-457">For more information, see [Modal vs light dismiss](../controls-and-patterns/menus.md).</span></span>

## <a name="focus-engagement"></a><span data-ttu-id="36591-458">フォーカス エンゲージメント</span><span class="sxs-lookup"><span data-stu-id="36591-458">Focus engagement</span></span>

<span data-ttu-id="36591-459">フォーカス エンゲージメントは、ゲームパッドやリモコンでアプリを操作しやすくするためのものです。</span><span class="sxs-lookup"><span data-stu-id="36591-459">Focus engagement is intended to make it easier to use a gamepad or remote to interact with an app.</span></span>

> [!NOTE]
> <span data-ttu-id="36591-460">フォーカス エンゲージメントを設定しても、キーボードなどの他の入力デバイスには影響しません。</span><span class="sxs-lookup"><span data-stu-id="36591-460">Setting focus engagement does not impact keyboard or other input devices.</span></span>

<span data-ttu-id="36591-461">[FrameworkElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) オブジェクトのプロパティ `IsFocusEngagementEnabled` を `True` に設定すると、コントロールがフォーカス エンゲージメントを要求するよう設定されます。</span><span class="sxs-lookup"><span data-stu-id="36591-461">When the property `IsFocusEngagementEnabled` on a [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) object is set to `True`, it marks the control as requiring focus engagement.</span></span> <span data-ttu-id="36591-462">この場合、コントロールを "獲得" して操作するには、ユーザーが **A/[選択]** ボタンをクリックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-462">This means that the user must press the **A/Select** button to "engage" the control and interact with it.</span></span> <span data-ttu-id="36591-463">終了したら、**B/[戻る]** ボタンをクリックしてコントロールのエンゲージメントを解除すると、コントロールから移動できるようになります。</span><span class="sxs-lookup"><span data-stu-id="36591-463">When they are finished, they can press the **B/Back** button to disengage the control and navigate out of it.</span></span>

> [!NOTE]
> `IsFocusEngagementEnabled` <span data-ttu-id="36591-464">は新しい API で、まだ文書化されていません。</span><span class="sxs-lookup"><span data-stu-id="36591-464">is a new API and not yet documented.</span></span>

### <a name="focus-trapping"></a><span data-ttu-id="36591-465">フォーカスのトラップ</span><span class="sxs-lookup"><span data-stu-id="36591-465">Focus trapping</span></span>

<span data-ttu-id="36591-466">フォーカスのトラップとは、ユーザーがアプリの UI を移動しようとしているときにコントロール内に "捕まる" ことで、そのコントロールの外に移動することが困難または不可能になることです。</span><span class="sxs-lookup"><span data-stu-id="36591-466">Focus trapping is what happens when a user attempts to navigate an app's UI but becomes "trapped" within a control, making it difficult or even impossible to move outside of that control.</span></span>

<span data-ttu-id="36591-467">次の例では、フォーカスのトラップが発生する UI を示します。</span><span class="sxs-lookup"><span data-stu-id="36591-467">The following example shows UI that creates focus trapping.</span></span>

![水平方向のスライダーの左右のボタン](images/designing-for-tv/focus-engagement-focus-trapping.png)

<span data-ttu-id="36591-469">ユーザーが左のボタンから右のボタンに移動する場合、方向パッド/左スティックの右を 2 回クリックするだけでよいと考えることは論理的です。</span><span class="sxs-lookup"><span data-stu-id="36591-469">If the user wants to navigate from the left button to the right button, it would be logical to assume that all they'd have to do is press right on the D-pad/left stick twice.</span></span>
<span data-ttu-id="36591-470">しかし、[Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) がエンゲージメントを必要としない場合、ユーザーが最初に右に押したときにフォーカスは `Slider` に移動し、もう一度右に押したときに `Slider` のハンドルが右に移動します。</span><span class="sxs-lookup"><span data-stu-id="36591-470">However, if the [Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) doesn't require engagement, the following behavior would occur: when the user presses right the first time, focus would shift to the `Slider`, and when they press right again, the `Slider`'s handle would move to the right.</span></span> <span data-ttu-id="36591-471">ユーザーはハンドルを右に動かし続けるだけで、ボタンに移ることはできません。</span><span class="sxs-lookup"><span data-stu-id="36591-471">The user would keep moving the handle to the right and wouldn't be able to get to the button.</span></span>

<span data-ttu-id="36591-472">この問題を回避する方法はいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="36591-472">There are several approaches to getting around this issue.</span></span> <span data-ttu-id="36591-473">その 1 つは、「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」の不動産アプリで **[前へ]** ボタンと **[次へ]** ボタンの位置を `ListView` の上に変更する例のように、別のレイアウトを設計することです。</span><span class="sxs-lookup"><span data-stu-id="36591-473">One is to design a different layout, similar to the real estate app example in [XY focus navigation and interaction](#xy-focus-navigation-and-interaction) where we relocated the **Previous** and **Next** buttons above the `ListView`.</span></span> <span data-ttu-id="36591-474">次の図のように、水平方向ではなく垂直方向にコントロールを重ねて配置すると、問題が解決します。</span><span class="sxs-lookup"><span data-stu-id="36591-474">Stacking the controls vertically instead of horizontally as in the following image would solve the problem.</span></span>

![水平方向のスライダーの上下のボタン](images/designing-for-tv/focus-engagement-focus-trapping-2.png)

<span data-ttu-id="36591-476">これでユーザーは期待どおり、方向パッド/左スティックを上下に押して各コントロールに移動でき、`Slider` にフォーカスがあるときは左右に押して `Slider` ハンドルを動かすことができます。</span><span class="sxs-lookup"><span data-stu-id="36591-476">Now the user can navigate to each of the controls by pressing up and down on the D-pad/left stick, and when the `Slider` has focus, they can press left and right to move the `Slider` handle, as expected.</span></span>

<span data-ttu-id="36591-477">この問題を解決するためのもう 1 つの方法は、`Slider` でエンゲージメントを要求することです。</span><span class="sxs-lookup"><span data-stu-id="36591-477">Another approach to solving this problem is to require engagement on the `Slider`.</span></span> <span data-ttu-id="36591-478">`IsFocusEngagementEnabled="True"` を設定すると、次の動作が発生します。</span><span class="sxs-lookup"><span data-stu-id="36591-478">If you set `IsFocusEngagementEnabled="True"`, this will result in the following behavior.</span></span>

![ユーザーが右側のボタンに移動できるように、スライダーでフォーカス エンゲージメントを要求する](images/designing-for-tv/focus-engagement-slider.png)

<span data-ttu-id="36591-480">`Slider` でフォーカス エンゲージメントを要求すると、ユーザーは方向パッド/左スティックを右に 2 回押すだけで右側のボタンに移動できます。</span><span class="sxs-lookup"><span data-stu-id="36591-480">When the `Slider` requires focus engagement, the user can get to the button on the right simply by pressing right on the D-pad/left stick twice.</span></span> <span data-ttu-id="36591-481">この解決策は、UI の調整なしで予期する動作を実現できるので便利です。</span><span class="sxs-lookup"><span data-stu-id="36591-481">This solution is great because it requires no UI adjustment and produces the expected behavior.</span></span>

### <a name="items-controls"></a><span data-ttu-id="36591-482">項目コントロール</span><span class="sxs-lookup"><span data-stu-id="36591-482">Items controls</span></span>

<span data-ttu-id="36591-483">[Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) コントロール以外にもエンゲージメントを要求できるコントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="36591-483">Aside from the [Slider](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx) control, there are other controls which you may want to require engagement, such as:</span></span>

- [<span data-ttu-id="36591-484">ListBox</span><span class="sxs-lookup"><span data-stu-id="36591-484">ListBox</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listbox.aspx)
- [<span data-ttu-id="36591-485">ListView</span><span class="sxs-lookup"><span data-stu-id="36591-485">ListView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)
- [<span data-ttu-id="36591-486">GridView</span><span class="sxs-lookup"><span data-stu-id="36591-486">GridView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)
- [<span data-ttu-id="36591-487">FlipView</span><span class="sxs-lookup"><span data-stu-id="36591-487">FlipView</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview)

<span data-ttu-id="36591-488">`Slider` コントロールと異なり、これらのコントロールはフォーカスを捕捉しませんが、大量のデータを含めると操作性の問題が生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-488">Unlike the `Slider` control, these controls don't trap focus within themselves; however, they can cause usability issues when they contain large amounts of data.</span></span> <span data-ttu-id="36591-489">次の例は、大量のデータが含まれる `ListView` です。</span><span class="sxs-lookup"><span data-stu-id="36591-489">The following is an example of a `ListView` that contains a large amount of data.</span></span>

![大量のデータと上下のボタンが含まれる ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls.png)

<span data-ttu-id="36591-491">`Slider` の例と同様に、ゲームパッド/リモコンで上のボタンから下のボタンに移動してみましょう。</span><span class="sxs-lookup"><span data-stu-id="36591-491">Similar to the `Slider` example, let's try to navigate from the button at the top to the button at the bottom with a gamepad/remote.</span></span>
<span data-ttu-id="36591-492">上ボタンにフォーカスがある状態で方向パッド/スティックを押すと、`ListView` の最初の項目 ("Item 1") にフォーカスが設定されます。</span><span class="sxs-lookup"><span data-stu-id="36591-492">Starting with focus on the top button, pressing down on the D-pad/stick will place the focus on the first item in the `ListView` ("Item 1").</span></span>
<span data-ttu-id="36591-493">ユーザーがもう一度押すと、下にあるボタンではなく、一覧の次の項目がフォーカスを獲得します。</span><span class="sxs-lookup"><span data-stu-id="36591-493">When the user presses down again, the next item in the list gets focus, not the button on the bottom.</span></span>
<span data-ttu-id="36591-494">ボタンに移動するには、ユーザーは `ListView` のすべての項目を移動していく必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-494">To get to the button, the user must navigate through every item in the `ListView` first.</span></span>
<span data-ttu-id="36591-495">`ListView` に大量のデータが含まれている場合は、この操作に手間がかかり、最適なユーザー エクスペリエンスになりません。</span><span class="sxs-lookup"><span data-stu-id="36591-495">If the `ListView` contains a large amount of data, this could be inconvenient and not an optimal user experience.</span></span>

<span data-ttu-id="36591-496">この問題を解決するには、`ListView` でプロパティ `IsFocusEngagementEnabled="True"` を設定し、エンゲージメントを要求します。</span><span class="sxs-lookup"><span data-stu-id="36591-496">To solve this problem, set the property `IsFocusEngagementEnabled="True"` on the `ListView` to require engagement on it.</span></span>
<span data-ttu-id="36591-497">この結果、ユーザーは下に押すだけで `ListView` まで迅速にスキップできます。</span><span class="sxs-lookup"><span data-stu-id="36591-497">This will allow the user to quickly skip over the `ListView` by simply pressing down.</span></span> <span data-ttu-id="36591-498">ただし、一覧にエンゲージメントを設定しないと、一覧をスクロールしたり、一覧から項目を選んだりすることはできません。エンゲージメントを設定するには、フォーカスがある状態で **A/[選択]** ボタンを押します。エンゲージメントを解除するには、**B/[戻る]** ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="36591-498">However, they will not be able to scroll through the list or choose an item from it unless they engage it by pressing the **A/Select** button when it has focus, and then pressing the **B/Back** button to disengage.</span></span>

![エンゲージメントが要求される ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls-2.png)

#### <a name="scrollviewer"></a><span data-ttu-id="36591-500">ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="36591-500">ScrollViewer</span></span>

<span data-ttu-id="36591-501">これらのコントロールと少し異なる点は、[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) です。ScrollViewer には、考慮すべき独自の Quirk があります。</span><span class="sxs-lookup"><span data-stu-id="36591-501">Slightly different from these controls is the [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx), which has its own quirks to consider.</span></span> <span data-ttu-id="36591-502">フォーカス可能なコンテンツを含む `ScrollViewer` がある場合、`ScrollViewer` に移動すると既定でフォーカス可能なコンテンツ間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="36591-502">If you have a `ScrollViewer` with focusable content, by default navigating to the `ScrollViewer` will allow you to move through its focusable elements.</span></span> <span data-ttu-id="36591-503">`ListView` の場合と同様に、`ScrollViewer` 以外の場所に移動するには、各項目をスクロールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-503">Like in a `ListView`, you must scroll through each item to navigate outside of the `ScrollViewer`.</span></span>

<span data-ttu-id="36591-504">`ScrollViewer` にフォーカス可能なコンテンツが*ない*場合 (テキストのみが含まれる場合など)、ユーザーが **A/[選択]** ボタンを使って `ScrollViewer` にエンゲージメントを設定できるように、`IsFocusEngagementEnabled="True"` を設定できます。</span><span class="sxs-lookup"><span data-stu-id="36591-504">If the `ScrollViewer` has *no* focusable content&mdash;for example, if it only contains text&mdash;you can set `IsFocusEngagementEnabled="True"` so the user can engage the `ScrollViewer` by using the **A/Select** button.</span></span> <span data-ttu-id="36591-505">エンゲージメントの設定後、**方向パッド/左スティック**を使ってテキストをスクロールできます。作業が終わったら、**B/[戻る]** ボタンを押してエンゲージメントを解除できます。</span><span class="sxs-lookup"><span data-stu-id="36591-505">After they have engaged, they can scroll through the text by using the **D-pad/left stick**, and then press the **B/Back** button to disengage when they're finished.</span></span>

<span data-ttu-id="36591-506">別の方法としては、ユーザーがコントロールにエンゲージメントを設定しなくてすむように `ScrollViewer` で `IsTabStop="True"` を設定します。`ScrollViewer` 内にフォーカス可能な要素がない場合にも、**D パッド/左スティック**を使って、単にフォーカスしてからスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="36591-506">Another approach would be to set `IsTabStop="True"` on the `ScrollViewer` so that the user doesn't have to engage the control&mdash;they can simply place focus on it and then scroll by using the **D-pad/left stick** when there are no focusable elements within the `ScrollViewer`.</span></span>

### <a name="focus-engagement-defaults"></a><span data-ttu-id="36591-507">フォーカス エンゲージメントの既定値</span><span class="sxs-lookup"><span data-stu-id="36591-507">Focus engagement defaults</span></span>

<span data-ttu-id="36591-508">一部のコントロールでは、フォーカスのトラップがよく発生するため、既定の設定でフォーカス エンゲージメントを要求する方が良い場合があります。また、コントロールによっては既定でフォーカス エンゲージメントが無効になっていますが、有効にする方が良い場合があります。</span><span class="sxs-lookup"><span data-stu-id="36591-508">Some controls cause focus trapping commonly enough to warrant their default settings to require focus engagement, while others have focus engagement turned off by default but can benefit from turning it on.</span></span> <span data-ttu-id="36591-509">次の表は、これらのコントロールと、既定のフォーカス エンゲージメントの動作を示します。</span><span class="sxs-lookup"><span data-stu-id="36591-509">The following table lists these controls and their default focus engagement behaviors.</span></span>

| <span data-ttu-id="36591-510">コントロール</span><span class="sxs-lookup"><span data-stu-id="36591-510">Control</span></span>               | <span data-ttu-id="36591-511">フォーカス エンゲージメントの既定値</span><span class="sxs-lookup"><span data-stu-id="36591-511">Focus engagement default</span></span>  |
|-----------------------|---------------------------|
| <span data-ttu-id="36591-512">CalendarDatePicker</span><span class="sxs-lookup"><span data-stu-id="36591-512">CalendarDatePicker</span></span>    | <span data-ttu-id="36591-513">オン</span><span class="sxs-lookup"><span data-stu-id="36591-513">On</span></span>                        |
| <span data-ttu-id="36591-514">FlipView</span><span class="sxs-lookup"><span data-stu-id="36591-514">FlipView</span></span>              | <span data-ttu-id="36591-515">オフ</span><span class="sxs-lookup"><span data-stu-id="36591-515">Off</span></span>                       |
| <span data-ttu-id="36591-516">GridView</span><span class="sxs-lookup"><span data-stu-id="36591-516">GridView</span></span>              | <span data-ttu-id="36591-517">オフ</span><span class="sxs-lookup"><span data-stu-id="36591-517">Off</span></span>                       |
| <span data-ttu-id="36591-518">ListBox</span><span class="sxs-lookup"><span data-stu-id="36591-518">ListBox</span></span>               | <span data-ttu-id="36591-519">オフ</span><span class="sxs-lookup"><span data-stu-id="36591-519">Off</span></span>                       |
| <span data-ttu-id="36591-520">ListView</span><span class="sxs-lookup"><span data-stu-id="36591-520">ListView</span></span>              | <span data-ttu-id="36591-521">オフ</span><span class="sxs-lookup"><span data-stu-id="36591-521">Off</span></span>                       |
| <span data-ttu-id="36591-522">ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="36591-522">ScrollViewer</span></span>          | <span data-ttu-id="36591-523">オフ</span><span class="sxs-lookup"><span data-stu-id="36591-523">Off</span></span>                       |
| <span data-ttu-id="36591-524">SemanticZoom</span><span class="sxs-lookup"><span data-stu-id="36591-524">SemanticZoom</span></span>          | <span data-ttu-id="36591-525">オフ</span><span class="sxs-lookup"><span data-stu-id="36591-525">Off</span></span>                       |
| <span data-ttu-id="36591-526">Slider</span><span class="sxs-lookup"><span data-stu-id="36591-526">Slider</span></span>                | <span data-ttu-id="36591-527">オン</span><span class="sxs-lookup"><span data-stu-id="36591-527">On</span></span>                        |

<span data-ttu-id="36591-528">他のすべての UWP コントロールは、`IsFocusEngagementEnabled="True"` のとき、動作の変更または視覚的な変更はありません。</span><span class="sxs-lookup"><span data-stu-id="36591-528">All other UWP controls will result in no behavioral or visual changes when `IsFocusEngagementEnabled="True"`.</span></span>

## <a name="ui-element-sizing"></a><span data-ttu-id="36591-529">UI 要素のサイズ</span><span class="sxs-lookup"><span data-stu-id="36591-529">UI element sizing</span></span>

<span data-ttu-id="36591-530">10 フィート環境でアプリを使うユーザーは、画面から数フィート離れた場所に座ってリモコンやゲームパッドを使っています。そのため、UI のデザインに関して考慮する必要がある注意事項がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="36591-530">Because the user of an app in the 10-foot environment is using a remote control or gamepad and is sitting several feet away from the screen, there are some UI considerations that need to be factored into your design.</span></span>
<span data-ttu-id="36591-531">ユーザーが簡単に要素間を移動したり要素を選んだりできるように、UI があまり雑然とせず、適切なコンテンツの密度になるようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-531">Make sure that the UI has an appropriate content density and is not too cluttered so that the user can easily navigate and select elements.</span></span> <span data-ttu-id="36591-532">簡潔さが重要です。</span><span class="sxs-lookup"><span data-stu-id="36591-532">Remember: simplicity is key.</span></span>

### <a name="scale-factor-and-adaptive-layout"></a><span data-ttu-id="36591-533">拡大縮小率とアダプティブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="36591-533">Scale factor and adaptive layout</span></span>

<span data-ttu-id="36591-534">**拡大縮小率**は、アプリが実行されているデバイスにおける適切なサイズで UI 要素が表示されることを保証します。</span><span class="sxs-lookup"><span data-stu-id="36591-534">**Scale factor** helps with ensuring that UI elements are displayed with the right sizing for the device on which the app is running.</span></span>
<span data-ttu-id="36591-535">デスクトップでは、この設定は **[設定] > [システム] > [表示]** からスライダーで値を指定します。</span><span class="sxs-lookup"><span data-stu-id="36591-535">On desktop, this setting can be found in **Settings > System > Display** as a sliding value.</span></span>
<span data-ttu-id="36591-536">この設定が電話でサポートされている場合、電話にも同じ設定があります。</span><span class="sxs-lookup"><span data-stu-id="36591-536">This same setting exists on phone as well if the device supports it.</span></span>

![テキスト、アプリ、その他の項目のサイズを変更する](images/designing-for-tv/ui-scaling.png)

<span data-ttu-id="36591-538">Xbox One ではこのようなシステム設定はありません。ただし、UWP の UI 要素をテレビ用に適切なサイズにするために、拡大縮小率は既定で **200%** (XAML アプリの場合) および **150%** (HTML アプリの場合) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="36591-538">On Xbox One, there is no such system setting; however, for UWP UI elements to be sized appropriately for TV, they are scaled at a default of **200%** for XAML apps and **150%** for HTML apps.</span></span>
<span data-ttu-id="36591-539">他のデバイスで UI 要素のサイズが適切に設定されていれば、テレビでも適切なサイズになります。</span><span class="sxs-lookup"><span data-stu-id="36591-539">As long as UI elements are appropriately sized for other devices, they will be appropriately sized for TV.</span></span>
<span data-ttu-id="36591-540">Xbox One ではアプリは 1080 p (1920 x 1080 ピクセル) で表示されます。</span><span class="sxs-lookup"><span data-stu-id="36591-540">Xbox One renders your app at 1080p (1920 x 1080 pixels).</span></span> <span data-ttu-id="36591-541">そのため、PC などの他のデバイスからアプリを移植する場合は、[アダプティブ手法](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を利用して 960 x 540 ピクセル、100% のスケーリング (または HTML アプリの場合、1280 x 720 ピクセル、100% のスケーリング) で UI が適切に表示されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-541">Therefore, when bringing an app from other devices such as PC, ensure that the UI looks great at 960 x 540 px at 100% scale (or 1280 x 720 px at 100% scale for HTML apps) utilizing [adaptive techniques](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

<span data-ttu-id="36591-542">Xbox 用の設計では、1 つの解像度 (1920 x 1080) だけを考慮すればよいため、PC の設計とは少し異なります。</span><span class="sxs-lookup"><span data-stu-id="36591-542">Designing for Xbox is a little different from designing for PC because you only need to worry about one resolution, 1920 x 1080.</span></span>
<span data-ttu-id="36591-543">ユーザーがそれ以上の解像度のテレビを使っていても関係ありません。UWP アプリは常に 1080 p に拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="36591-543">It doesn't matter if the user has a TV that has better resolution&mdash;UWP apps will always scale to 1080p.</span></span>

<span data-ttu-id="36591-544">また、テレビの解像度に関係なく、アプリが Xbox One で実行されている場合は適切なアセット サイズが 200% (または HTML アプリの場合は 150%) のセットから取得されます。</span><span class="sxs-lookup"><span data-stu-id="36591-544">Correct asset sizes from the 200% (or 150% for HTML apps) set will also be pulled in for your app when running on Xbox One, regardless of TV resolution.</span></span>

### <a name="content-density"></a><span data-ttu-id="36591-545">コンテンツの密度</span><span class="sxs-lookup"><span data-stu-id="36591-545">Content density</span></span>

<span data-ttu-id="36591-546">アプリを設計する際には、ユーザーは離れた位置から UI を見るということに注意してください。また、リモコンやゲーム コントローラーを使ってアプリを操作するために、マウスやタッチ入力を使うよりも移動に時間がかかることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-546">When designing your app, remember that the user will be viewing the UI from a distance and interacting with it by using a remote or game controller, which takes more time to navigate than using mouse or touch input.</span></span>

#### <a name="sizes-of-ui-controls"></a><span data-ttu-id="36591-547">UI コントロールのサイズ</span><span class="sxs-lookup"><span data-stu-id="36591-547">Sizes of UI controls</span></span>

<span data-ttu-id="36591-548">対話型の UI 要素は、最小の高さである 32 epx (有効ピクセル) でサイズを調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-548">Interactive UI elements should be sized at a minimum height of 32 epx (effective pixels).</span></span> <span data-ttu-id="36591-549">これは一般的な UWP コントロールの既定の設定で、拡大縮小率が 200% のときに UI 要素が遠くから確実に見えるようにし、コンテンツの密度を抑えるためのものです。</span><span class="sxs-lookup"><span data-stu-id="36591-549">This is the default for common UWP controls, and when used at 200% scale, it ensures that UI elements are visible from a distance and helps reduce content density.</span></span>

![拡大縮小率 100% と 200% の UWP ボタン](images/designing-for-tv/button-100-200.png)

#### <a name="number-of-clicks"></a><span data-ttu-id="36591-551">クリックの回数</span><span class="sxs-lookup"><span data-stu-id="36591-551">Number of clicks</span></span>

<span data-ttu-id="36591-552">UI を簡略化するために、ユーザーがテレビ画面の端から端まで移動するときに、**クリックは 6 回**以内になるようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-552">When the user is navigating from one edge of the TV screen to the other, it should take no more than **six clicks** to simplify your UI.</span></span> <span data-ttu-id="36591-553">ここでも**簡潔さ**の原則が重要です。</span><span class="sxs-lookup"><span data-stu-id="36591-553">Again, the principle of **simplicity** applies here.</span></span> <span data-ttu-id="36591-554">詳しくは、「[最小回数のクリック数](#path-of-least-clicks)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-554">For more details, see [Path of least clicks](#path-of-least-clicks).</span></span>

![6 つのアイコン分の幅](images/designing-for-tv/six-clicks.png)

### <a name="text-sizes"></a><span data-ttu-id="36591-556">テキスト サイズ</span><span class="sxs-lookup"><span data-stu-id="36591-556">Text sizes</span></span>

<span data-ttu-id="36591-557">UI を離れた位置から見えるようにするために、次の経験則に従ってください。</span><span class="sxs-lookup"><span data-stu-id="36591-557">To make your UI visible from a distance, use the following rules of thumb:</span></span>

* <span data-ttu-id="36591-558">メイン テキストと読解コンテンツ: 最小 15 epx</span><span class="sxs-lookup"><span data-stu-id="36591-558">Main text and reading content: 15 epx minimum</span></span>
* <span data-ttu-id="36591-559">不可欠ではないテキストと補助コンテンツ: 最小 12 epx</span><span class="sxs-lookup"><span data-stu-id="36591-559">Non-critical text and supplemental content: 12 epx minimum</span></span>

<span data-ttu-id="36591-560">UI でさらに大きなテキストを使う場合は、画面領域をあまり狭めないサイズを選び、他のコンテンツのためのスペースを圧迫しないようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-560">When using larger text in your UI, pick a size that does not limit screen real estate too much, taking up space that other content could potentially fill.</span></span>

### <a name="opting-out-of-scale-factor"></a><span data-ttu-id="36591-561">拡大縮小率の無効化</span><span class="sxs-lookup"><span data-stu-id="36591-561">Opting out of scale factor</span></span>

<span data-ttu-id="36591-562">アプリでは拡大縮小率のサポートを利用することをお勧めします。この機能は、各デバイスの種類に合わせて拡大縮小することで、すべてのデバイスでアプリを適切に実行するためのものです。</span><span class="sxs-lookup"><span data-stu-id="36591-562">We recommend that your app take advantage of scale factor support, which will help it run appropriately on all devices by scaling for each device type.</span></span>
<span data-ttu-id="36591-563">しかし、この動作を無効にして、すべての UI を 100% の拡大縮小率で設計することもできます。</span><span class="sxs-lookup"><span data-stu-id="36591-563">However, it is possible to opt out of this behavior and design all of your UI at 100% scale.</span></span> <span data-ttu-id="36591-564">100% 以外の拡大縮小率には変更できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-564">Note that you cannot change the scale factor to anything other than 100%.</span></span>

<span data-ttu-id="36591-565">XAML アプリでは、次のコード スニペットを使って倍率を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="36591-565">For XAML apps, you can opt out of scale factor by using the following code snippet:</span></span>

```csharp
bool result =
    Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```

`result` <span data-ttu-id="36591-566">無効化に成功したかどうかが通知されます。</span><span class="sxs-lookup"><span data-stu-id="36591-566">will inform you whether you successfully opted out.</span></span>

<span data-ttu-id="36591-567">HTML/JavaScript のサンプル コードなどの詳細情報については、「[スケーリングを無効にする方法](../xbox-apps/disable-scaling.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-567">For more information, including sample code for HTML/JavaScript, see [How to turn off scaling](../xbox-apps/disable-scaling.md).</span></span>

<span data-ttu-id="36591-568">UI 要素の適切なサイズを計算するときに、このトピックで説明した*有効*ピクセルの値を倍にして (または HTML アプリの場合は 1.5 倍にして) *実際*のピクセル値にすることを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="36591-568">Please be sure to calculate the appropriate sizes of UI elements by doubling the *effective* pixel values mentioned in this topic to *actual* pixel values (or multiplying by 1.5 for HTML apps).</span></span>

## <a name="tv-safe-area"></a><span data-ttu-id="36591-569">テレビのセーフ エリア</span><span class="sxs-lookup"><span data-stu-id="36591-569">TV-safe area</span></span>

<span data-ttu-id="36591-570">歴史的な経緯や技術的な理由により、すべてのテレビで画面の端までコンテンツが表示されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="36591-570">Not all TVs display content all the way to the edges of the screen due to historical and technological reasons.</span></span> <span data-ttu-id="36591-571">既定では、UWP はテレビのセーフ エリア以外に UI コンテンツを表示せず、ページの背景のみを描画します。</span><span class="sxs-lookup"><span data-stu-id="36591-571">By default, the UWP will avoid displaying any UI content in TV-unsafe areas and instead will only draw the page background.</span></span>

<span data-ttu-id="36591-572">次の図に、テレビのセーフ エリア以外の領域を青色で示します。</span><span class="sxs-lookup"><span data-stu-id="36591-572">The TV-unsafe area is represented by the blue area in the following image.</span></span>

![テレビのセーフ エリア以外の領域](images/designing-for-tv/tv-unsafe-area.png)

<span data-ttu-id="36591-574">次のコード スニペットに示すように、背景は静的な色、テーマの色、または画像に設定できます。</span><span class="sxs-lookup"><span data-stu-id="36591-574">You can set the background to a static or themed color, or to an image, as the following code snippets demonstrate.</span></span>

### <a name="theme-color"></a><span data-ttu-id="36591-575">テーマの色</span><span class="sxs-lookup"><span data-stu-id="36591-575">Theme color</span></span>

```xml
<Page x:Class="Sample.MainPage"
      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"/>
```

### <a name="image"></a><span data-ttu-id="36591-576">画像</span><span class="sxs-lookup"><span data-stu-id="36591-576">Image</span></span>

```xml
<Page x:Class="Sample.MainPage"
      Background="\Assets\Background.png"/>
```

<span data-ttu-id="36591-577">追加の作業を行わない場合、アプリは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="36591-577">This is what your app will look like without additional work.</span></span>

![テレビのセーフ エリア](images/designing-for-tv/tv-safe-area.png)

<span data-ttu-id="36591-579">この場合、アプリのアスペクト比が変わり、ナビゲーション ウィンドウやグリッドなど UI の一部が切れて表示されるため、最適とはいえません。</span><span class="sxs-lookup"><span data-stu-id="36591-579">This is not optimal because it gives the app a "boxed-in" effect, with parts of the UI such as the nav pane and grid seemingly cut off.</span></span> <span data-ttu-id="36591-580">ただし、UI の一部を画面の端まで拡張し、アプリに映画のような効果を持たせることで最適化することができます。</span><span class="sxs-lookup"><span data-stu-id="36591-580">However, you can make optimizations to extend parts of the UI to the edges of the screen to give the app a more cinematic effect.</span></span>

### <a name="drawing-ui-to-the-edge"></a><span data-ttu-id="36591-581">端までの UI の描画</span><span class="sxs-lookup"><span data-stu-id="36591-581">Drawing UI to the edge</span></span>

<span data-ttu-id="36591-582">ユーザーに没入感を提供するために、特定の UI 要素を使って画面の端まで拡張することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-582">We recommend that you use certain UI elements to extend to the edges of the screen to provide more immersion to the user.</span></span> <span data-ttu-id="36591-583">[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx)、[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)、[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) などを使えます。</span><span class="sxs-lookup"><span data-stu-id="36591-583">These include [ScrollViewers](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx), [nav panes](../controls-and-patterns/navigationview.md), and [CommandBars](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx).</span></span>

<span data-ttu-id="36591-584">一方、対話型の要素とテキストは画面の端に表示されることを常に避け、一部のテレビで表示が切れないようにすることも重要です。</span><span class="sxs-lookup"><span data-stu-id="36591-584">On the other hand, it's also important that interactive elements and text always avoid the screen edges to ensure that they won't be cut off on some TVs.</span></span> <span data-ttu-id="36591-585">画面の端 5% 以内には重要でない視覚効果のみを描画することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-585">We recommend that you draw only non-essential visuals within 5% of the screen edges.</span></span> <span data-ttu-id="36591-586">「[UI 要素のサイズ](#ui-element-sizing)」で説明したように、Xbox One コンソールの既定の拡大縮小率 200% に従っている UWP アプリは、960 x 540 epx の領域を使います。そのため、アプリの UI では重要な UI を以下の領域に置かないようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-586">As mentioned in [UI element sizing](#ui-element-sizing), a UWP app following the Xbox One console's default scale factor of 200% will utilize an area of 960 x 540 epx, so in your app's UI, you should avoid putting essential UI in the following areas:</span></span>

- <span data-ttu-id="36591-587">上部と下部から 27 epx</span><span class="sxs-lookup"><span data-stu-id="36591-587">27 epx from the top and bottom</span></span>
- <span data-ttu-id="36591-588">左側と右側から 48 epx</span><span class="sxs-lookup"><span data-stu-id="36591-588">48 epx from the left and right sides</span></span>

<span data-ttu-id="36591-589">以下のセクションでは、UI を画面の端まで広げる方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="36591-589">The following sections describe how to make your UI extend to the screen edges.</span></span>

#### <a name="core-window-bounds"></a><span data-ttu-id="36591-590">コア ウィンドウの境界</span><span class="sxs-lookup"><span data-stu-id="36591-590">Core window bounds</span></span>

<span data-ttu-id="36591-591">10 フィート エクスペリエンスのみを対象とする UWP アプリでは、コア ウィンドウの境界を使う方が簡単です。</span><span class="sxs-lookup"><span data-stu-id="36591-591">For UWP apps targeting only the 10-foot experience, using core window bounds is a more straightforward option.</span></span>

<span data-ttu-id="36591-592">`App.xaml.cs` の `OnLaunched` メソッドで、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="36591-592">In the `OnLaunched` method of `App.xaml.cs`, add the following code:</span></span>

```csharp
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode
    (Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```

<span data-ttu-id="36591-593">このコード行で、アプリ ウィンドウは画面の端まで拡張されます。そのため、前に説明したテレビのセーフ エリアへ、すべての対話型 UI と重要な UI を移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-593">With this line of code, the app window will extend to the edges of the screen, so you will need to move all interactive and essential UI into the TV-safe area described earlier.</span></span> <span data-ttu-id="36591-594">コンテキスト メニューや開かれた状態の [ComboBox](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) などの一時的な UI は、テレビのセーフ エリア内に自動的に残ります。</span><span class="sxs-lookup"><span data-stu-id="36591-594">Transient UI, such as context menus and opened [ComboBoxes](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx), will automatically remain inside the TV-safe area.</span></span>

![コア ウィンドウの境界](images/designing-for-tv/core-window-bounds.png)

#### <a name="pane-backgrounds"></a><span data-ttu-id="36591-596">ウィンドウの背景</span><span class="sxs-lookup"><span data-stu-id="36591-596">Pane backgrounds</span></span>

<span data-ttu-id="36591-597">通常、ナビゲーション ウィンドウは画面の端近くに描画されるため、不自然なギャップが入らないように背景をテレビのセーフ エリア以外まで広げる必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-597">Navigation panes are typically drawn near the edge of the screen, so the background should extend into the TV-unsafe area so as not to introduce awkward gaps.</span></span> <span data-ttu-id="36591-598">ナビゲーション ウィンドウの背景の色をアプリの背景の色に変更するだけで、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="36591-598">You can do this by simply changing the color of the nav pane's background to the color of the app's background.</span></span>

<span data-ttu-id="36591-599">既に説明したように、コア ウィンドウの境界を使用すると、画面の端まで UI を描画することができますが、さらに [SplitView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.splitview.aspx) のコンテンツで正の余白を使用してコンテンツがテレビ セーフ エリア内に収まるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-599">Using the core window bounds as previously described will allow you to draw your UI to the edges of the screen, but you should then use positive margins on the [SplitView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.splitview.aspx)'s content to keep it within the TV-safe area.</span></span>

![画面の端まで拡張されたナビゲーション ウィンドウ](images/designing-for-tv/tv-safe-areas-2.png)

<span data-ttu-id="36591-601">ここでは、ナビゲーション ウィンドウの背景は画面の端まで拡張され、ナビゲーション項目はテレビのセーフ エリア内に収まっています。</span><span class="sxs-lookup"><span data-stu-id="36591-601">Here, the nav pane's background has been extended to the edges of the screen, while its navigation items are kept in the TV-safe area.</span></span>
<span data-ttu-id="36591-602">`SplitView` のコンテンツ (この場合は項目のグリッド) は、途切れずに続いているように見せるために、画面の下部まで拡張されています。一方、グリッドの上部はテレビのセーフ エリア内に収まったままです </span><span class="sxs-lookup"><span data-stu-id="36591-602">The content of the `SplitView` (in this case, a grid of items) has been extended to the bottom of the screen so that it looks like it continues and isn't cut off, while the top of the grid is still within the TV-safe area.</span></span> <span data-ttu-id="36591-603">(この方法ついて詳しくは、「[リストとグリッドのスクロールの端](#scrolling-ends-of-lists-and-grids)」で説明します)。</span><span class="sxs-lookup"><span data-stu-id="36591-603">(Learn more about how to do this in [Scrolling ends of lists and grids](#scrolling-ends-of-lists-and-grids)).</span></span>

<span data-ttu-id="36591-604">次のコード スニペットでは、この効果を実現します。</span><span class="sxs-lookup"><span data-stu-id="36591-604">The following code snippet achieves this effect:</span></span>

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

<span data-ttu-id="36591-605">[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) も、アプリの 1 つまたは複数の端の近くに置かれることが多いウィンドウの例ですが、そのためにテレビではその背景を画面の端まで拡張する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-605">[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) is another example of a pane that is commonly positioned near one or more edges of the app, and as such on TV its background should extend to the edges of the screen.</span></span> <span data-ttu-id="36591-606">これには通常、**[その他]** ボタンも含まれます。[その他] ボタンは右側に表示する "..." で表し、テレビのセーフ エリア内に収める必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-606">It also usually contains a **More** button, represented by "..." on the right side, which should remain in the TV-safe area.</span></span> <span data-ttu-id="36591-607">目的の操作と視覚効果を実現するためのいくつかの異なる方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="36591-607">The following are a few different strategies to achieve the desired interactions and visual effects.</span></span>

<span data-ttu-id="36591-608">**オプション 1**: `CommandBar` の背景色を透明またはページの背景と同じ色に変更します。</span><span class="sxs-lookup"><span data-stu-id="36591-608">**Option 1**: Change the `CommandBar` background color to either transparent or the same color as the page background:</span></span>

```xml
<CommandBar x:Name="topbar"
            Background="{ThemeResource SystemControlBackgroundAltHighBrush}">
            ...
</CommandBar>
```

<span data-ttu-id="36591-609">これで、`CommandBar` がページの残りの部分と同じ背景の上にあるように見え、背景が画面の端まで切れ目なく続きます。</span><span class="sxs-lookup"><span data-stu-id="36591-609">Doing this will make the `CommandBar` look like it is on top of the same background as the rest of the page, so the background seamlessly flows to the edge of the screen.</span></span>

<span data-ttu-id="36591-610">**オプション 2**: `CommandBar` の背景と同じ色で塗りつぶした背景の四角形を追加し、その四角形を `CommandBar` の下、ページの残りの部分に配置します。</span><span class="sxs-lookup"><span data-stu-id="36591-610">**Option 2**: Add a background rectangle whose fill is the same color as the `CommandBar` background, and have it lie below the `CommandBar` and across the rest of the page:</span></span>

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
> <span data-ttu-id="36591-611">この方法を使う場合、アイコンの下に `AppBarButton` のラベルを表示できるように、開いた状態の `CommandBar` の高さが **[その他]** ボタンによって必要に応じて変更されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-611">If using this approach, be aware that the **More** button changes the height of the opened `CommandBar` if necessary, in order to show the labels of the `AppBarButton`s below their icons.</span></span> <span data-ttu-id="36591-612">サイズ変更を避けるために、アイコンの*右側*へラベルを移動することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-612">We recommend that you move the labels to the *right* of their icons to avoid this resizing.</span></span> <span data-ttu-id="36591-613">詳しくは、「[CommandBar のラベル](#commandbar-labels)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-613">For more information, see [CommandBar labels](#commandbar-labels).</span></span>

<span data-ttu-id="36591-614">これらのアプローチはいずれも、このセクションに示されている他の種類のコントロールにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="36591-614">Both of these approaches also apply to the other types of controls listed in this section.</span></span>

#### <a name="scrolling-ends-of-lists-and-grids"></a><span data-ttu-id="36591-615">リストとグリッドのスクロールの端</span><span class="sxs-lookup"><span data-stu-id="36591-615">Scrolling ends of lists and grids</span></span>

<span data-ttu-id="36591-616">リストとグリッドに一度に画面に表示できるよりも多くの項目を含めることはよくあります。</span><span class="sxs-lookup"><span data-stu-id="36591-616">It's common for lists and grids to contain more items than can fit onscreen at the same time.</span></span> <span data-ttu-id="36591-617">この場合、リストまたはグリッドを画面の端まで拡張することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-617">When this is the case, we recommend that you extend the list or grid to the edge of the screen.</span></span> <span data-ttu-id="36591-618">リストとグリッドを横方向にスクロールする場合は右端まで、垂直方向にスクロールする場合は一番下まで拡張するようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-618">Horizontally scrolling lists and grids should extend to the right edge, and vertically scrolling ones should extend to the bottom.</span></span>

![テレビのセーフ エリアでのグリッドの切り捨て](images/designing-for-tv/tv-safe-area-grid-cutoff.png)

<span data-ttu-id="36591-620">リストまたはグリッドは次のように拡張されますが、フォーカス表示とその関連項目をテレビのセーフ エリア内に収めることが重要です。</span><span class="sxs-lookup"><span data-stu-id="36591-620">While a list or grid is extended like this, it's important to keep the focus visual and its associated item inside the TV-safe area.</span></span>

![グリッドのフォーカスのスクロールをテレビのセーフ エリア内に収める](images/designing-for-tv/scrolling-grid-focus.png)

<span data-ttu-id="36591-622">UWP にはフォーカス表示を [VisibleBounds](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.applicationview.visiblebounds.aspx) 内に保持する機能がありますが、リストやグリッドの項目をセーフ エリアの表示領域内までスクロールできるように余白を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-622">The UWP has functionality that will keep the focus visual inside the [VisibleBounds](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.applicationview.visiblebounds.aspx), but you need to add padding to ensure that the list/grid items can scroll into view of the safe area.</span></span> <span data-ttu-id="36591-623">具体的には、次のコード スニペットのように、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) または [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) の [ItemsPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemspresenter.aspx) に正の余白を追加します。</span><span class="sxs-lookup"><span data-stu-id="36591-623">Specifically, you add a positive margin to the [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) or [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)'s [ItemsPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemspresenter.aspx), as in the following code snippet:</span></span>

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

<span data-ttu-id="36591-624">前のコード スニペットをページまたはアプリのリソースに含め、次のようにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="36591-624">You would put the previous code snippet in either the page or app resources, and then access it in the following way:</span></span>

```xml
<Page>
    <Grid>
        <ListView Style="{StaticResource TitleSafeListViewStyle}"
                  ... />
```

> [!NOTE]
> <span data-ttu-id="36591-625">このコード スニペットは `ListView` 専用です。`GridView` のスタイルの場合、[ControlTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.controltemplate.aspx) と [Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.aspx) の両方の [TargetType](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.controltemplate.targettype.aspx) 属性を `GridView` に設定します。</span><span class="sxs-lookup"><span data-stu-id="36591-625">This code snippet is specifically for `ListView`s; for a `GridView` style, set the [TargetType](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.controltemplate.targettype.aspx) attribute for both the [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.controltemplate.aspx) and the [Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.style.aspx) to `GridView`.</span></span>

## <a name="colors"></a><span data-ttu-id="36591-626">カラー</span><span class="sxs-lookup"><span data-stu-id="36591-626">Colors</span></span>

<span data-ttu-id="36591-627">既定では、ユニバーサル Windows プラットフォームはアプリの色を変更しません。</span><span class="sxs-lookup"><span data-stu-id="36591-627">By default, the Universal Windows Platform doesn't do anything to alter your app's colors.</span></span> <span data-ttu-id="36591-628">ただし、テレビでのビジュアル エクスペリエンスを向上させるために、アプリで使う色のセットを改善できます。</span><span class="sxs-lookup"><span data-stu-id="36591-628">That said, there are improvements that you can make to the set of colors your app uses to improve the visual experience on TV.</span></span>

### <a name="application-theme"></a><span data-ttu-id="36591-629">アプリケーション テーマ</span><span class="sxs-lookup"><span data-stu-id="36591-629">Application theme</span></span>

<span data-ttu-id="36591-630">アプリに合わせて適切な**アプリケーション テーマ** (濃色または淡色) を選ぶか、テーマを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="36591-630">You can choose an **Application theme** (dark or light) according to what is right for your app, or you can opt out of theming.</span></span> <span data-ttu-id="36591-631">テーマの一般的な推奨事項については、「[配色テーマ](../style/color.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-631">Read more about general recommendations for themes in [Color themes](../style/color.md).</span></span>

<span data-ttu-id="36591-632">UWP では、アプリが実行されているデバイスから提供されるシステム設定に基づいて、アプリでテーマを動的に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="36591-632">The UWP also allows apps to dynamically set the theme based on the system settings provided by the devices on which they run.</span></span>
<span data-ttu-id="36591-633">UWP では、ユーザーが指定したテーマ設定が常に適用されますが、各デバイスは、適切な既定のテーマも提供します。</span><span class="sxs-lookup"><span data-stu-id="36591-633">While the UWP always respects the theme settings specified by the user, each device also provides an appropriate default theme.</span></span>
<span data-ttu-id="36591-634">Xbox One はその性質上、*生産性*エクスペリエンスよりも*メディア* エクスペリエンスを期待されているため、既定で濃色のシステム テーマに設定されます。</span><span class="sxs-lookup"><span data-stu-id="36591-634">Because of the nature of Xbox One, which is expected to have more *media* experiences than *productivity* experiences, it defaults to a dark system theme.</span></span>
<span data-ttu-id="36591-635">アプリのテーマがシステム設定を基にしている場合、Xbox One では既定で濃色に設定されるはずです。</span><span class="sxs-lookup"><span data-stu-id="36591-635">If your app's theme is based on the system settings, expect it to default to dark on Xbox One.</span></span>

### <a name="accent-color"></a><span data-ttu-id="36591-636">アクセント カラー</span><span class="sxs-lookup"><span data-stu-id="36591-636">Accent color</span></span>

<span data-ttu-id="36591-637">UWP には、ユーザーがシステム設定から選んだ**アクセント カラー**を公開する便利な方法が用意されています。</span><span class="sxs-lookup"><span data-stu-id="36591-637">The UWP provides a convenient way to expose the **accent color** that the user has selected from their system settings.</span></span>

<span data-ttu-id="36591-638">PC でアクセント カラーを選べるように、ユーザーは Xbox One でユーザーの色を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="36591-638">On Xbox One, the user is able to select a user color, just as they can select an accent color on a PC.</span></span>
<span data-ttu-id="36591-639">アプリでブラシやカラー リソースからこれらのアクセント カラーを呼び出していれば、ユーザーがシステム設定で選んだ色が使われます。</span><span class="sxs-lookup"><span data-stu-id="36591-639">As long as your app calls these accent colors through brushes or color resources, the color that the user selected in the system settings will be used.</span></span> <span data-ttu-id="36591-640">Xbox One ではアクセント カラーはシステムごとではなくユーザーごとであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-640">Note that accent colors on Xbox One are per user, not per system.</span></span>

<span data-ttu-id="36591-641">また、Xbox One と PC、電話、その他のデバイスでは、ユーザーの色のセットが異なることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-641">Please also note that the set of user colors on Xbox One is not the same as that on PCs, phones, and other devices.</span></span>
<span data-ttu-id="36591-642">この理由の 1 つとして、これらの色は、Xbox One で最適な 10 フィート エクスペリエンスを提供できるように、この記事で説明するのと同じ方法で厳選されているということがあります。</span><span class="sxs-lookup"><span data-stu-id="36591-642">This is partly due to the fact that these colors are hand-picked to make for the best 10-foot experience on Xbox One, following the same methodologies and strategies explained in this article.</span></span>

<span data-ttu-id="36591-643">アプリで **SystemControlForegroundAccentBrush** などのブラシ リソースやカラー リソース (**SystemAccentColor**) を使うか、代わりに [UIColorType.Accent*](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) API からアクセント カラーを直接呼び出していれば、これらの色はテレビ用に適切なアクセント カラーに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="36591-643">As long as your app uses a brush resource such as **SystemControlForegroundAccentBrush**, or a color resource (**SystemAccentColor**), or instead calls accent colors directly through the [UIColorType.Accent*](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.uicolortype.aspx) API, those colors are replaced with accent colors appropriate for TV.</span></span> <span data-ttu-id="36591-644">ハイ コントラストのブラシの色も、PC、電話と同じ方法で (ただし、テレビに適切な色が) システムから取得されます。</span><span class="sxs-lookup"><span data-stu-id="36591-644">High contrast brush colors are also pulled in from the system the same way as on a PC and phone, but with TV-appropriate colors.</span></span>

<span data-ttu-id="36591-645">アクセント カラー全般について詳しくは、「[アクセント カラー](../style/color.md#accent-color)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-645">To learn more about accent color in general, see [Accent color](../style/color.md#accent-color).</span></span>

### <a name="color-variance-among-tvs"></a><span data-ttu-id="36591-646">テレビごとのカラーの変化</span><span class="sxs-lookup"><span data-stu-id="36591-646">Color variance among TVs</span></span>

<span data-ttu-id="36591-647">テレビ向けに設計するときには、レンダリングされるテレビごとに色の表示が大きく異なることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="36591-647">When designing for TV, note that colors display quite differently depending on the TV on which they are rendered.</span></span> <span data-ttu-id="36591-648">モニター上とまったく同じ色に見えるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="36591-648">Don't assume colors will look exactly as they do on your monitor.</span></span> <span data-ttu-id="36591-649">アプリで UI の各部を区別するために色のわずかな違いを利用している場合、色が混ざり合ってユーザーが混乱する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-649">If your app relies on subtle differences in color to differentiate parts of the UI, colors could blend together and users could get confused.</span></span> <span data-ttu-id="36591-650">どのテレビであっても、ユーザーがはっきり区別できる違いがある色を使うようにしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-650">Try to use colors that are different enough that users will be able to clearly differentiate them, regardless of the TV they are using.</span></span>

### <a name="tv-safe-colors"></a><span data-ttu-id="36591-651">テレビ セーフ カラー</span><span class="sxs-lookup"><span data-stu-id="36591-651">TV-safe colors</span></span>

<span data-ttu-id="36591-652">色の RGB 値は、赤、緑、青の輝度を表します。</span><span class="sxs-lookup"><span data-stu-id="36591-652">A color's RGB values represent intensities for red, green, and blue.</span></span> <span data-ttu-id="36591-653">テレビでは、極端な輝度をあまりうまく処理できません。そのため、10 フィート エクスペリエンス向けに設計する際に、そのような色は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="36591-653">TVs don't handle extreme intensities very well; therefore, you should avoid using these colors when designing for the 10-foot experience.</span></span> <span data-ttu-id="36591-654">不自然な縞模様になったり、一部のテレビでは色あせて表示されたりする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-654">They can produce an odd banded effect, or appear washed out on certain TVs.</span></span> <span data-ttu-id="36591-655">また、高輝度色はブルーミング (隣接するピクセルが同じ色を描画する現象) を起こす可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-655">Additionally, high-intensity colors may cause blooming (nearby pixels start drawing the same colors).</span></span>

<span data-ttu-id="36591-656">どのような色をテレビ セーフ カラーと見なすかについてはいくつかの考え方がありますが、一般に、RGB 値 16 ～ 235 (16 進数では 10 ～ EB) の色はテレビで使っても安全です。</span><span class="sxs-lookup"><span data-stu-id="36591-656">While there are different schools of thought in what are considered TV-safe colors, colors within the RGB values of 16-235 (or 10-EB in hexadecimal) are generally safe to use for TV.</span></span>

![テレビ セーフ カラーの範囲](images/designing-for-tv/tv-safe-colors.png)

### <a name="fixing-tv-unsafe-colors"></a><span data-ttu-id="36591-658">テレビ セーフ カラー以外の修正</span><span class="sxs-lookup"><span data-stu-id="36591-658">Fixing TV-unsafe colors</span></span>

<span data-ttu-id="36591-659">テレビ セーフ カラー以外の色を個々に調整して、RGB 値がテレビ セーフな範囲内に収まるように修正することを、一般に**カラー クランプ**と呼びます。</span><span class="sxs-lookup"><span data-stu-id="36591-659">Fixing TV-unsafe colors individually by adjusting their RGB values to be within the TV-safe range is typically referred to as **color clamping**.</span></span> <span data-ttu-id="36591-660">この方法は、色数の多いカラー パレットを使わないアプリに適している場合があります。</span><span class="sxs-lookup"><span data-stu-id="36591-660">This method may be appropriate for an app that doesn't use a rich color palette.</span></span> <span data-ttu-id="36591-661">ただし、この方法だけで色を修正すると、色がうまく調和せず、最適な 10 フィート エクスペリエンスを提供できない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-661">However, fixing colors using only this method may cause colors to collide with each other, which doesn't provide for the best 10-foot experience.</span></span>

<span data-ttu-id="36591-662">カラー パレットをテレビ向けに最適化するには、カラー クランプなどの方法で色がテレビ セーフであることを確認した後で、**スケーリング**という方法を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-662">To optimize your color palette for TV, we recommend that you first ensure that your colors are TV-safe through a method such as color clamping, then use a method called **scaling**.</span></span>

<span data-ttu-id="36591-663">この方法では、すべての色の RGB 値を特定の係数でスケーリングしてテレビ セーフの範囲に収めます。</span><span class="sxs-lookup"><span data-stu-id="36591-663">This involves scaling all of your colors' RGB values by a certain factor to get them within the TV-safe range.</span></span> <span data-ttu-id="36591-664">色が被ることを防ぎ、優れた 10 フィート エクスペリエンスを提供するために、アプリのすべての色をスケーリングすることは効果的な方法です。</span><span class="sxs-lookup"><span data-stu-id="36591-664">Scaling all of your app's colors helps prevent color collision and makes for a better 10-foot experience.</span></span>

![クランプとスケーリング](images/designing-for-tv/clamping-vs-scaling.png)

### <a name="assets"></a><span data-ttu-id="36591-666">アセット</span><span class="sxs-lookup"><span data-stu-id="36591-666">Assets</span></span>

<span data-ttu-id="36591-667">色に変更を加える場合は、それに応じてアセットも必ず更新します。</span><span class="sxs-lookup"><span data-stu-id="36591-667">When making changes to colors, make sure to also update assets accordingly.</span></span> <span data-ttu-id="36591-668">アプリで、アセット カラーと同じように見えると思われる色を XAML で使う場合、XAML コードだけを更新すると、アセットの色が違って見えます。</span><span class="sxs-lookup"><span data-stu-id="36591-668">If your app uses a color in XAML that is supposed to look the same as an asset color, but you only update the XAML code, your assets will look off-color.</span></span>

### <a name="uwp-color-sample"></a><span data-ttu-id="36591-669">UWP の色のサンプル</span><span class="sxs-lookup"><span data-stu-id="36591-669">UWP color sample</span></span>

<span data-ttu-id="36591-670">[UWP の配色テーマ](../style/color.md)は、アプリの背景 (濃色テーマ用の**黒**または淡色テーマ用の**白**のいずれかになります) をベースに設計されています。</span><span class="sxs-lookup"><span data-stu-id="36591-670">[UWP color themes](../style/color.md) are designed around the app's background being either **black** for the dark theme or **white** for the light theme.</span></span> <span data-ttu-id="36591-671">黒と白のどちらもテレビ セーフではないため、これらの色は*クランプ*を使って修正する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="36591-671">Because neither black nor white are TV-safe, these colors needed to be fixed by using *clamping*.</span></span> <span data-ttu-id="36591-672">また、修正後に、必要なコントラストを保持するために*スケーリング*を使ってその他のすべての色を調整する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="36591-672">After they were fixed, all the other colors needed to be adjusted through *scaling* to retain the necessary contrast.</span></span>

<!--[v-lcap to eliot]why is the above paragraph in the past tense?-->
<!--[elcowle] Because this is something that Microsoft had to do to the UWP color themes to accommodate TV-safe colors for Xbox. These themes are then provided in the below code sample.-->

<span data-ttu-id="36591-673">次のサンプル コードは、テレビ向けに最適化された配色テーマを提供します。</span><span class="sxs-lookup"><span data-stu-id="36591-673">The following sample code provides a color theme that has been optimized for TV use:</span></span>

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="ApplicationPageBackgroundThemeBrush"
                                 Color="#FF101010"/>
                <Color x:Key="SystemAltHighColor">#FF101010</Color>
                <Color x:Key="SystemAltLowColor">#33101010</Color>
                <Color x:Key="SystemAltMediumColor">#99101010</Color>
                <Color x:Key="SystemAltMediumHighColor">#CC101010</Color>
                <Color x:Key="SystemAltMediumLowColor">#66101010</Color>
                <Color x:Key="SystemBaseHighColor">#FFEBEBEB</Color>
                <Color x:Key="SystemBaseLowColor">#33EBEBEB</Color>
                <Color x:Key="SystemBaseMediumColor">#99EBEBEB</Color>
                <Color x:Key="SystemBaseMediumHighColor">#CCEBEBEB</Color>
                <Color x:Key="SystemBaseMediumLowColor">#66EBEBEB</Color>
                <Color x:Key="SystemChromeAltLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeBlackHighColor">#FF101010</Color>
                <Color x:Key="SystemChromeBlackLowColor">#33101010</Color>
                <Color x:Key="SystemChromeBlackMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeBlackMediumColor">#CC101010</Color>
                <Color x:Key="SystemChromeDisabledHighColor">#FF333333</Color>
                <Color x:Key="SystemChromeDisabledLowColor">#FF858585</Color>
                <Color x:Key="SystemChromeHighColor">#FF767676</Color>
                <Color x:Key="SystemChromeLowColor">#FF1F1F1F</Color>
                <Color x:Key="SystemChromeMediumColor">#FF262626</Color>
                <Color x:Key="SystemChromeMediumLowColor">#FF2B2B2B</Color>
                <Color x:Key="SystemChromeWhiteColor">#FFEBEBEB</Color>
                <Color x:Key="SystemListLowColor">#19EBEBEB</Color>
                <Color x:Key="SystemListMediumColor">#33EBEBEB</Color>
            </ResourceDictionary>
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="ApplicationPageBackgroundThemeBrush"
                                 Color="#FFEBEBEB" /> 
                <Color x:Key="SystemAltHighColor">#FFEBEBEB</Color>
                <Color x:Key="SystemAltLowColor">#33EBEBEB</Color>
                <Color x:Key="SystemAltMediumColor">#99EBEBEB</Color>
                <Color x:Key="SystemAltMediumHighColor">#CCEBEBEB</Color>
                <Color x:Key="SystemAltMediumLowColor">#66EBEBEB</Color>
                <Color x:Key="SystemBaseHighColor">#FF101010</Color>
                <Color x:Key="SystemBaseLowColor">#33101010</Color>
                <Color x:Key="SystemBaseMediumColor">#99101010</Color>
                <Color x:Key="SystemBaseMediumHighColor">#CC101010</Color>
                <Color x:Key="SystemBaseMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeAltLowColor">#FF1F1F1F</Color>
                <Color x:Key="SystemChromeBlackHighColor">#FF101010</Color>
                <Color x:Key="SystemChromeBlackLowColor">#33101010</Color>
                <Color x:Key="SystemChromeBlackMediumLowColor">#66101010</Color>
                <Color x:Key="SystemChromeBlackMediumColor">#CC101010</Color>
                <Color x:Key="SystemChromeDisabledHighColor">#FFCCCCCC</Color>
                <Color x:Key="SystemChromeDisabledLowColor">#FF7A7A7A</Color>
                <Color x:Key="SystemChromeHighColor">#FFB2B2B2</Color>
                <Color x:Key="SystemChromeLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeMediumColor">#FFCCCCCC</Color>
                <Color x:Key="SystemChromeMediumLowColor">#FFDDDDDD</Color>
                <Color x:Key="SystemChromeWhiteColor">#FFEBEBEB</Color>
                <Color x:Key="SystemListLowColor">#19101010</Color>
                <Color x:Key="SystemListMediumColor">#33101010</Color>
            </ResourceDictionary> 
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

> [!NOTE]
> <span data-ttu-id="36591-674">淡色テーマ **SystemChromeMediumLowColor** と **SystemChromeMediumLowColor** は、クランプの結果ではなく、意図的に同じ色になっています。</span><span class="sxs-lookup"><span data-stu-id="36591-674">The light theme **SystemChromeMediumLowColor** and **SystemChromeMediumLowColor** are the same color on purpose and not caused as a result of clamping.</span></span>

> [!NOTE]
> <span data-ttu-id="36591-675">16 進数の色は **ARGB** (アルファ、赤、緑、青) で指定します。</span><span class="sxs-lookup"><span data-stu-id="36591-675">Hexadecimal colors are specified in **ARGB** (Alpha Red Green Blue).</span></span>

<span data-ttu-id="36591-676">クランプなしですべての範囲を表示できるモニターでは、テレビ セーフ カラーを使わないことをお勧めします。色があせて見えます。</span><span class="sxs-lookup"><span data-stu-id="36591-676">We don't recommend using TV-safe colors on a monitor able to display the full range without clamping because the colors will look washed out.</span></span> <span data-ttu-id="36591-677">代わりに、Xbox でアプリを実行し他のプラットフォームで実行*しない*場合は、リソース ディクショナリ (前のサンプル) を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="36591-677">Instead, load the resource dictionary (previous sample) when your app is running on Xbox but *not* other platforms.</span></span> <span data-ttu-id="36591-678">`App.xaml.cs` の `OnLaunched` メソッドに、次のチェックを追加します。</span><span class="sxs-lookup"><span data-stu-id="36591-678">In the `OnLaunched` method of `App.xaml.cs`, add the following check:</span></span>

```csharp
if (IsTenFoot)
{ 
    this.Resources.MergedDictionaries.Add(new ResourceDictionary
    {
        Source = new Uri("ms-appx:///TenFootStylesheet.xaml")
    }); 
}
```

> [!NOTE]
> <span data-ttu-id="36591-679">`IsTenFoot` 変数は、「[Xbox 用のカスタム表示状態のトリガー](#custom-visual-state-trigger-for-xbox)」で定義されています。</span><span class="sxs-lookup"><span data-stu-id="36591-679">The `IsTenFoot` variable is defined in [Custom visual state trigger for Xbox](#custom-visual-state-trigger-for-xbox).</span></span>

<span data-ttu-id="36591-680">これにより、どのデバイスでアプリを実行していても正しい色が表示され、美的に優れた、より良いエクスペリエンスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="36591-680">This will ensure that the correct colors will display on whichever device the app is running, providing the user with a better, more aesthetically pleasing experience.</span></span>

## <a name="guidelines-for-ui-controls"></a><span data-ttu-id="36591-681">UI コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="36591-681">Guidelines for UI controls</span></span>

<span data-ttu-id="36591-682">いくつかの UI コントロールは、複数のデバイスで問題なく動作しますが、テレビで使用する場合には特定の考慮事項があります。</span><span class="sxs-lookup"><span data-stu-id="36591-682">There are several UI controls that work well across multiple devices, but have certain considerations when used on TV.</span></span> <span data-ttu-id="36591-683">10 フィート エクスペリエンスを設計する際にこのようなコントロールを使う場合のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="36591-683">Read about some best practices for using these controls when designing for the 10-foot experience.</span></span>

### <a name="pivot-control"></a><span data-ttu-id="36591-684">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="36591-684">Pivot control</span></span>

<span data-ttu-id="36591-685">[ピボット](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx)は、別のヘッダーやタブを選択することにより、アプリ内でビューのすばやいナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="36591-685">A [Pivot](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.aspx) provides quick navigation of views within an app through selecting different headers or tabs.</span></span> <span data-ttu-id="36591-686">このコントロールでは、フォーカスがあるヘッダーに下線が引かれ、ゲームパッド/リモコンを使用している場合に、現在選択されているヘッダーがわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="36591-686">The control underlines whichever header has focus, making it more obvious which header is currently selected when using gamepad/remote.</span></span>

![ピボットの下線](images/designing-for-tv/pivot-underline.png)

<!--By default, when you navigate to a `Pivot`, one of the [PivotItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivotitem.aspx)s will get focus. However, you can show focus around all the headers by setting `Pivot.HeaderFocusVisualPlacement="ItemHeaders"`.

![Pivot focus around headers](images/designing-for-tv/pivot-headers-focus.png)-->

<span data-ttu-id="36591-688">[Pivot.IsHeaderItemsCarouselEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.isheaderitemscarouselenabled.aspx) プロパティを `true` に設定すると、選択したピボット ヘッダーが常に最初の位置に移動する代わりに、ピボットが常に同じ位置に固定されます。</span><span class="sxs-lookup"><span data-stu-id="36591-688">You can set the [Pivot.IsHeaderItemsCarouselEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.pivot.isheaderitemscarouselenabled.aspx) property to `true` so that pivots always keep the same position, rather than having the selected pivot header always move to the first position.</span></span> <span data-ttu-id="36591-689">ヘッダーの折り返しを煩わしいと感じるユーザーもいるため、これでテレビなどの大画面表示でエクスペリエンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="36591-689">This is a better experience for large-screen displays such as TV, because header wrapping can be distracting to users.</span></span> <span data-ttu-id="36591-690">すべてのピボット ヘッダーが同時に画面に収まらない場合、ユーザーは表示されるスクロール バーを使って他のヘッダーを表示できますが、最良のエクスペリエンスを提供するためには、すべてのピボット ヘッダーが画面に収まることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-690">If all of the pivot headers don't fit onscreen at once, there will be a scrollbar to let customers see the other headers; however, you should make sure that they all fit on the screen to provide the best experience.</span></span> <span data-ttu-id="36591-691">詳しくは、「[タブとピボット](../controls-and-patterns/tabs-pivot.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-691">For more information, see [Tabs and pivots](../controls-and-patterns/tabs-pivot.md).</span></span>

<!--If you find it necessary to wrap headers, you can set it so that it doesn't show the selected header in the left-most position, like it does by default. When you set `Pivot.IsHeaderItemsCarouselEnabled="False"`, the selected header will move left by the minimal amount required to become fully visible. This is the recommended approach for 10-foot design.

![Pivot headers carousel disabled](images/designing-for-tv/pivot-headers-carousel.png)-->

### <a name="navigation-pane-a-namenavigation-pane"></a><span data-ttu-id="36591-692">ナビゲーション ウィンドウ <a name="navigation-pane"></span><span class="sxs-lookup"><span data-stu-id="36591-692">Navigation pane <a name="navigation-pane"></span></span>

<span data-ttu-id="36591-693">ナビゲーション ウィンドウ (*ハンバーガー メニュー*とも呼ばれる) は、UWP アプリでよく使われるナビゲーション コントロールです。</span><span class="sxs-lookup"><span data-stu-id="36591-693">A navigation pane (also known as a *hamburger menu*) is a navigation control commonly used in UWP apps.</span></span> <span data-ttu-id="36591-694">通常、リスト スタイルのメニューから選択できる複数のオプションを表示するウィンドウであり、ユーザーに異なるページを表示します。</span><span class="sxs-lookup"><span data-stu-id="36591-694">Typically it is a pane with several options to choose from in a list style menu that will take the user to different pages.</span></span> <span data-ttu-id="36591-695">一般的に、このウィンドウは領域を節約するために折りたたまれた状態で表示され、ユーザーがボタンをクリックすることで開くことができます。</span><span class="sxs-lookup"><span data-stu-id="36591-695">Generally this pane starts out collapsed to save space, and the user can open it by clicking on a button.</span></span>

<span data-ttu-id="36591-696">ナビゲーション ウィンドウは、マウスやタッチを使う場合に非常にアクセシビリティが高く、ゲームパッド/リモコンを使う場合はウィンドウを開くボタンに移動する必要があるためアクセシビリティは低くなります。</span><span class="sxs-lookup"><span data-stu-id="36591-696">While nav panes are very accessible with mouse and touch, gamepad/remote makes them less accessible since the user has to navigate to a button to open the pane.</span></span> <span data-ttu-id="36591-697">そのため、ユーザーがページの左端まで移動してナビゲーション ウィンドウを開くことができるだけでなく、**表示**ボタンでナビゲーション ウィンドウを開く操作を可能にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-697">Therefore, a good practice is to have the **View** button open the nav pane, as well as allow the user to open it by navigating all the way to the left of the page.</span></span> <span data-ttu-id="36591-698">この設計パターンを実装する方法を示すコード サンプルは、「[フォーカス ナビゲーションの管理](managing-focus-navigation.md#split-view-code-sample)」にあります。</span><span class="sxs-lookup"><span data-stu-id="36591-698">Code sample on how to implement this design pattern can be found in [Managing focus navigation](managing-focus-navigation.md#split-view-code-sample) document.</span></span> <span data-ttu-id="36591-699">これにより、ユーザーは非常に簡単にウィンドウの内容にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="36591-699">This will provide the user with very easy access to the contents of the pane.</span></span> <span data-ttu-id="36591-700">さまざまな画面サイズでのナビゲーション ウィンドウの動作と、ゲームパッド/リモコンでのナビゲーションのベスト プラクティスについては、「[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-700">For more information about how nav panes behave in different screen sizes as well as best practices for gamepad/remote navigation, see [Nav panes](../controls-and-patterns/navigationview.md).</span></span>

### <a name="commandbar-labels"></a><span data-ttu-id="36591-701">CommandBar のラベル</span><span class="sxs-lookup"><span data-stu-id="36591-701">CommandBar labels</span></span>

<span data-ttu-id="36591-702">[CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) のアイコンの高さを最小化し、一貫性が保たれるようにするために、アイコンの右側にラベルを配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-702">It is a good idea to have the labels placed to the right of the icons on a [CommandBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx) so that its height is minimized and stays consistent.</span></span> <span data-ttu-id="36591-703">[CommandBar.DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) プロパティを `CommandBarDefaultLabelPosition.Right` に設定することによって、これを実現できます。</span><span class="sxs-lookup"><span data-stu-id="36591-703">You can do this by setting the [CommandBar.DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) property to `CommandBarDefaultLabelPosition.Right`.</span></span>

![アイコンの右側にラベルが配置された CommandBar](images/designing-for-tv/commandbar.png)

<span data-ttu-id="36591-705">また、このプロパティを設定するとラベルが常に表示されるようになり、ユーザーのクリック数を最小限に抑えることができるため、10 フィート エクスペリエンスに適しています。</span><span class="sxs-lookup"><span data-stu-id="36591-705">Setting this property will also cause the labels to always be displayed, which works well for the 10-foot experience because it minimizes the number of clicks for the user.</span></span> <span data-ttu-id="36591-706">また、これは他の種類のデバイスでも従うべき優れたモデルです。</span><span class="sxs-lookup"><span data-stu-id="36591-706">This is also a great model for other device types to follow.</span></span>

<!--When there isn't enough space in the window to fit all of the `AppBarButton`s, buttons move into an overflow menu, which is accessed by selecting the "..." button. This happens dynamically as the screen resizes. This generally shouldn't be a problem for TV because the screen size is so large, but if you find that you have overflow buttons, you can specify which appear first using the `AppBarButton.DynamicOverflowOrder` property.

![CommandBar with overflow commands](images/designing-for-tv/commandbar-overflow.png)-->

### <a name="tooltip"></a><span data-ttu-id="36591-707">ヒント</span><span class="sxs-lookup"><span data-stu-id="36591-707">Tooltip</span></span>

<span data-ttu-id="36591-708">[Tooltip](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltip.aspx) コントロールは、ユーザーが要素の上にマウスを置くか、要素をタップして長押ししたときに UI の詳しい情報を提供する方法として導入されました。</span><span class="sxs-lookup"><span data-stu-id="36591-708">The [Tooltip](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltip.aspx) control was introduced as a way to provide more information in the UI when the user hovers the mouse over, or taps and holds their figure on, an element.</span></span> <span data-ttu-id="36591-709">ゲームパッドとリモコンの場合、`Tooltip` は、要素にフォーカスが設定されて少し時間が経つと表示され、しばらく画面に表示された後で消えます。</span><span class="sxs-lookup"><span data-stu-id="36591-709">For gamepad and remote, `Tooltip` appears after a brief moment when the element gets focus, stays onscreen for a short time, and then disappears.</span></span> <span data-ttu-id="36591-710">使う `Tooltip` が多すぎると、ユーザーがこの動作を煩わしいと感じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-710">This behavior could be distracting if too many `Tooltip`s are used.</span></span> <span data-ttu-id="36591-711">テレビを設計するときには `Tooltip` を使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-711">Try to avoid using `Tooltip` when designing for TV.</span></span>

### <a name="button-styles"></a><span data-ttu-id="36591-712">ボタンのスタイル</span><span class="sxs-lookup"><span data-stu-id="36591-712">Button styles</span></span>

<span data-ttu-id="36591-713">標準的な UWP ボタンもテレビで適切に機能しますが、ボタンのいくつかの視覚スタイルは、より UI に注意を引きます。そのため、すべてのプラットフォーム、特に 10 フィート エクスペリエンスでは、どこにフォーカスがあるかを明確に通知できるというメリットがあるため、検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-713">While the standard UWP buttons work well on TV, some visual styles of buttons call attention to the UI better, which you may want to consider for all platforms, particularly in the 10-foot experience, which benefits from clearly communicating where the focus is located.</span></span> <span data-ttu-id="36591-714">そのようなスタイルについて詳しくは、「[ボタン](../controls-and-patterns/buttons.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-714">To read more about these styles, see [Buttons](../controls-and-patterns/buttons.md).</span></span>

### <a name="nested-ui-elements"></a><span data-ttu-id="36591-715">入れ子になった UI 要素</span><span class="sxs-lookup"><span data-stu-id="36591-715">Nested UI elements</span></span>

<span data-ttu-id="36591-716">入れ子になった UI は、コンテナー UI 要素内部に囲まれた、操作できる入れ子になったアイテムを公開します。入れ子になったアイテムとコンテナー アイテムはどちらも互いに、個別のフォーカスを取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="36591-716">Nested UI exposes nested actionable items enclosed inside a container UI element where both the nested item as well as the container item can take independent focus from each other.</span></span>

<span data-ttu-id="36591-717">入れ子になった UI がうまく機能する入力の種類もありますが、XY ナビゲーションに依存するゲームパッドやリモコンでは、うまく機能するとは限りません。</span><span class="sxs-lookup"><span data-stu-id="36591-717">Nested UI works well for some input types, but not always for gamepad and remote, which rely on XY navigation.</span></span> <span data-ttu-id="36591-718">このトピックのガイダンスに従い、UI が 10 フィート環境に最適化され、ユーザーが対話可能なすべての要素に容易にアクセスできるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="36591-718">Be sure to follow the guidance in this topic to ensure that your UI is optimized for the 10-foot environment, and that the user can access all interactable elements easily.</span></span> <span data-ttu-id="36591-719">よく使用される解決策の 1 つは、`ContextFlyout` に入れ子になった UI 要素を配置することです ([CommandBarとContextFlyout](#commandbar-and-contextflyout) をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="36591-719">One common solution is to place nested UI elements in a `ContextFlyout` (see [CommandBar and ContextFlyout](#commandbar-and-contextflyout)).</span></span>

<span data-ttu-id="36591-720">入れ子になった UI について詳しくは、「[リスト項目の入れ子になった UI](../controls-and-patterns/nested-ui.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-720">For more information on nested UI, see [Nested UI in list items](../controls-and-patterns/nested-ui.md).</span></span>

### <a name="mediatransportcontrols"></a><span data-ttu-id="36591-721">MediaTransportControls</span><span class="sxs-lookup"><span data-stu-id="36591-721">MediaTransportControls</span></span>

<span data-ttu-id="36591-722">[MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediatransportcontrols.aspx) 要素によって、ユーザーが再生、一時停止、クローズド キャプションの有効化などの操作を実行できる既定の再生エクスペリエンスが提供され、ユーザーはメディアを操作することができます。</span><span class="sxs-lookup"><span data-stu-id="36591-722">The [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediatransportcontrols.aspx) element lets users interact with their media by providing a default playback experience that allows them to play, pause, turn on closed captions, and more.</span></span> <span data-ttu-id="36591-723">このコントロールは、[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.aspx) のプロパティであり、*1 行*と *2 行*の 2 つのレイアウト オプションをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="36591-723">This control is a property of [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.aspx) and supports two layout options: *single-row* and *double-row*.</span></span> <span data-ttu-id="36591-724">1 行のレイアウトでは、スライダーと再生ボタンはすべて 1 つの行に配置され、スライダーの左側に再生/一時停止ボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="36591-724">In the single-row layout, the slider and playback buttons are all located in one row, with the play/pause button located to the left of the slider.</span></span> <span data-ttu-id="36591-725">2 行のレイアウトでは、スライダーは独自の行に配置され、再生ボタンは下側の別の行に配置されます。</span><span class="sxs-lookup"><span data-stu-id="36591-725">In the double-row layout, the slider occupies its own row, with the playback buttons on a separate lower row.</span></span> <span data-ttu-id="36591-726">10 フィート エクスペリエンス向けに設計する場合は、ゲームパッドでのナビゲーションが向上するため、2 行のレイアウトを使用してください。</span><span class="sxs-lookup"><span data-stu-id="36591-726">When designing for the 10-foot experience, the double-row layout should be used, as it provides better navigation for gamepad.</span></span> <span data-ttu-id="36591-727">2 行のレイアウトを有効にするには、`MediaPlayerElement` の [TransportControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.transportcontrols.aspx) プロパティの `MediaTransportControls` 要素で `IsCompact="False"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="36591-727">To enable the double-row layout, set `IsCompact="False"` on the `MediaTransportControls` element in the [TransportControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.transportcontrols.aspx) property of the `MediaPlayerElement`.</span></span>

```xml
<MediaPlayerElement x:Name="mediaPlayerElement1"  
                    Source="Assets/video.mp4"
                    AreTransportControlsEnabled="True">
    <MediaPlayerElement.TransportControls>
        <MediaTransportControls IsCompact="False"/>
    </MediaPlayerElement.TransportControls>
</MediaPlayerElement>
```  

<span data-ttu-id="36591-728">アプリにメディアを追加する方法について詳しくは、「[メディア再生](../controls-and-patterns/media-playback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-728">Visit [Media playback](../controls-and-patterns/media-playback.md) to learn more about adding media to your app.</span></span>

> <span data-ttu-id="36591-729">![注] `MediaPlayerElement` は Windows 10 バージョン 1607 以降でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="36591-729">![NOTE] `MediaPlayerElement` is only available in Windows 10, version 1607 and later.</span></span> <span data-ttu-id="36591-730">Windows 10 の以前のバージョン用にアプリを開発する場合は、代わりに [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36591-730">If you're developing an app for an earlier version of Windows 10, you'll need to use [MediaElement](https://msdn.microsoft.com/library/windows/apps/br242926) instead.</span></span> <span data-ttu-id="36591-731">上記の推奨事項は `MediaElement` にも適用され、`TransportControls` プロパティも同じ方法でアクセスされます。</span><span class="sxs-lookup"><span data-stu-id="36591-731">The recommendations above apply to `MediaElement` as well, and the `TransportControls` property is accessed in the same way.</span></span>

### <a name="search-experience"></a><span data-ttu-id="36591-732">検索エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="36591-732">Search experience</span></span>

<span data-ttu-id="36591-733">コンテンツの検索は 10 フィート エクスペリエンスで最もよく実行される機能の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="36591-733">Searching for content is one of the most commonly performed functions in the 10-foot experience.</span></span> <span data-ttu-id="36591-734">アプリが検索エクスペリエンスを提供する場合、ユーザーがゲームパッドの **Y** ボタンをアクセラレータとして使用して、検索へのクイックアクセスができるようにすると便利です。</span><span class="sxs-lookup"><span data-stu-id="36591-734">If your app provides a search experience, it is helpful for the user to have quick access to it by using the **Y** button on the gamepad as an accelerator.</span></span>

<span data-ttu-id="36591-735">このアクセラレータは既に多くのユーザーに使用されていますが、必要に応じて UI に視覚的な **Y** グリフを追加して、ユーザーがこのボタンを使用して検索機能にアクセスできることを示すことも可能です。</span><span class="sxs-lookup"><span data-stu-id="36591-735">Most customers should already be familiar with this accelerator, but if you like you can add a visual **Y** glyph to the UI to indicate that the customer can use the button to access search functionality.</span></span> <span data-ttu-id="36591-736">このヒントを追加する場合は、Xbox のシェルやその他のアプリとの一貫性を維持するため、必ず **Segoe Xbox シンボル MDL2** フォント (XAML アプリの場合は `&#xE3CC;`、HTML アプリの場合は `\E426`) のシンボルを使用します。</span><span class="sxs-lookup"><span data-stu-id="36591-736">If you do add this cue, be sure to use the symbol from the **Segoe Xbox MDL2 Symbol** font (`&#xE3CC;` for XAML apps, `\E426` for HTML apps) to provide consistency with the Xbox shell and other apps.</span></span>

> [!NOTE]
> <span data-ttu-id="36591-737">**Segoe Xbox MDL2 シンボル** フォントは Xbox にのみ対応するフォントであるため、PC ではシンボルが正しく表示されません。</span><span class="sxs-lookup"><span data-stu-id="36591-737">Because the **Segoe Xbox MDL2 Symbol** font is only available on Xbox, the symbol won't appear correctly on your PC.</span></span> <span data-ttu-id="36591-738">ただし、テレビに Xbox を展開した後はテレビで表示できます。</span><span class="sxs-lookup"><span data-stu-id="36591-738">However, it will show up on the TV once you deploy to Xbox.</span></span>

<span data-ttu-id="36591-739">**Y** ボタンはゲームパッドのみで利用できるため、検索にアクセスするための他の方法 (UI のボタンなど) を提供するようにします。</span><span class="sxs-lookup"><span data-stu-id="36591-739">Since the **Y** button is only available on gamepad, make sure to provide other methods of access to search, such as buttons in the UI.</span></span> <span data-ttu-id="36591-740">そうしない場合、一部のユーザーが検索機能にアクセスすることができない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="36591-740">Otherwise, some customers may not be able to access the functionality.</span></span>

<span data-ttu-id="36591-741">10 フィート エクスペリエンスではディスプレイのスペースが限られるため、通常、ユーザーは全画面表示の検索エクスペリエンスを使うほうが便利です。</span><span class="sxs-lookup"><span data-stu-id="36591-741">In the 10-foot experience, it is often easier for customers to use a full screen search experience because there is limited room on the display.</span></span> <span data-ttu-id="36591-742">全画面表示でも部分的な表示でも、「インプレース」検索により、ユーザーが検索エクスペリエンスを開いたときにスクリーン キーボードが表示され、ユーザーが検索用語を入力できるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-742">Whether you have full screen or partial-screen, "in-place" search, we recommend that when the user opens the search experience, the onscreen keyboard appears already opened, ready for the customer to enter search terms.</span></span>

## <a name="custom-visual-state-trigger-for-xbox"></a><span data-ttu-id="36591-743">Xbox のカスタム表示状態トリガー</span><span class="sxs-lookup"><span data-stu-id="36591-743">Custom visual state trigger for Xbox</span></span>

<span data-ttu-id="36591-744">UWP アプリを 10 フィート エクスペリエンス用にカスタマイズする場合、アプリが Xbox コンソールで起動されたことを検出したときにアプリのレイアウトが変わるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36591-744">To tailor your UWP app for the 10-foot experience, we recommend that you make layout changes when the app detects that it has been launched on an Xbox console.</span></span> <span data-ttu-id="36591-745">これを行う方法の 1 つが、カスタム*表示状態トリガー*を使用することです。</span><span class="sxs-lookup"><span data-stu-id="36591-745">One way to do this is by using a custom *visual state trigger*.</span></span> <span data-ttu-id="36591-746">表示状態トリガーは、**Blend for Visual Studio** で編集する場合に最も有用です。</span><span class="sxs-lookup"><span data-stu-id="36591-746">Visual state triggers are most useful when you want to edit in **Blend for Visual Studio**.</span></span> <span data-ttu-id="36591-747">次のコード スニペットは、Xbox の表示状態トリガーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="36591-747">The following code snippet shows how to create a visual state trigger for Xbox:</span></span>

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

<span data-ttu-id="36591-748">このようなトリガーを作成するには、アプリに次のクラスを追加します。</span><span class="sxs-lookup"><span data-stu-id="36591-748">To create the trigger, add the following class to your app.</span></span> <span data-ttu-id="36591-749">これは、前の XAML コードで参照されているクラスです。</span><span class="sxs-lookup"><span data-stu-id="36591-749">This is the class that is referenced by the XAML code above:</span></span>

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

<span data-ttu-id="36591-750">カスタム トリガーを追加した場合、アプリは、Xbox One コンソールで実行されていることを検出すると XAML コードで指定されたレイアウトを自動的に変更します。</span><span class="sxs-lookup"><span data-stu-id="36591-750">After you've added your custom trigger, your app will automatically make the layout modifications you specified in your XAML code whenever it detects that it is running on an Xbox One console.</span></span>

<span data-ttu-id="36591-751">アプリが Xbox で実行されていることを確認した後、適切な調整を行うためのもう 1 つの方法は、コードを使うことです。</span><span class="sxs-lookup"><span data-stu-id="36591-751">Another way you can check whether your app is running on Xbox and then make the appropriate adjustments is through code.</span></span> <span data-ttu-id="36591-752">次の単純な変数を使って、Xbox でアプリが実行されているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="36591-752">You can use the following simple variable to check if your app is running on Xbox:</span></span>

```csharp
bool IsTenFoot = (Windows.System.Profile.AnaylticsInfo.VersionInfo.DeviceFamily ==
                    "Windows.Xbox");
```

<span data-ttu-id="36591-753">次に、このチェックに続くコード ブロックで、UI に適切な調整を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="36591-753">Then, you can make the appropriate adjustments to your UI in the code block following this check.</span></span> <span data-ttu-id="36591-754">この例については、「[UWP 色のサンプル](#uwp-color-sample)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="36591-754">An example of this is shown in [UWP color sample](#uwp-color-sample).</span></span>

## <a name="summary"></a><span data-ttu-id="36591-755">まとめ</span><span class="sxs-lookup"><span data-stu-id="36591-755">Summary</span></span>

<span data-ttu-id="36591-756">10 フィート エクスペリエンスの設計には、他のプラットフォーム向けの設計とは対応を変える必要がある、特別な考慮事項があります。</span><span class="sxs-lookup"><span data-stu-id="36591-756">Designing for the 10-foot experience has special considerations to take into account that make it different from designing for any other platform.</span></span> <span data-ttu-id="36591-757">UWP アプリを Xbox One に単純に移植し、うまく動かすことができたとしも、必ずしも 10 フィート エクスペリエンス向けに最適化されるわけではありません。ユーザーのフラストレーションを招くことさえあります。</span><span class="sxs-lookup"><span data-stu-id="36591-757">While you can certainly do a straight port of your UWP app to Xbox One and it will work, it won't necessarily be optimized for the 10-foot experience and can lead to user frustration.</span></span> <span data-ttu-id="36591-758">この記事のガイドラインに従うと、テレビに組み込まれているかのようなすばらしいアプリにすることができます。</span><span class="sxs-lookup"><span data-stu-id="36591-758">Following the guidelines in this article will make sure that your app is as good as it can be on TV.</span></span>

## <a name="related-articles"></a><span data-ttu-id="36591-759">関連記事</span><span class="sxs-lookup"><span data-stu-id="36591-759">Related articles</span></span>

- [<span data-ttu-id="36591-760">ユニバーサル Windows プラットフォーム (UWP) アプリ用デバイスの基本情報</span><span class="sxs-lookup"><span data-stu-id="36591-760">Device primer for Universal Windows Platform (UWP) apps</span></span>](device-primer.md)
- [<span data-ttu-id="36591-761">ゲームパッドとリモコンの操作</span><span class="sxs-lookup"><span data-stu-id="36591-761">Gamepad and remote control interactions</span></span>](gamepad-and-remote-interactions.md)
- [<span data-ttu-id="36591-762">UWP アプリのサウンド</span><span class="sxs-lookup"><span data-stu-id="36591-762">Sound in UWP apps</span></span>](../style/sound.md)
