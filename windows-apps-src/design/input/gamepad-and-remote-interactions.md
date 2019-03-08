---
Description: Xbox ゲームパッド、リモート コントロールからの入力にアプリを最適化します。
title: ゲームパッドとリモコンの操作
ms.assetid: 784a08dc-2736-4bd3-bea0-08da16b1bd47
label: Gamepad and remote interactions
template: detail.hbs
isNew: true
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1292051362b9751d41b530f6b47f226d36228252
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592807"
---
# <a name="gamepad-and-remote-control-interactions"></a><span data-ttu-id="392c8-104">ゲームパッドとリモコンの操作</span><span class="sxs-lookup"><span data-stu-id="392c8-104">Gamepad and remote control interactions</span></span>

![キーボードとゲームパッドのイメージ](images/keyboard/keyboard-gamepad.jpg)

<span data-ttu-id="392c8-106">***多くの相互作用のエクスペリエンスは、ゲーム パッド、リモート制御、およびキーボードの間で共有されます。***</span><span class="sxs-lookup"><span data-stu-id="392c8-106">***Many interaction experiences are shared between gamepad, remote control, and keyboard***</span></span>

<span data-ttu-id="392c8-107">アプリが利用でき、入力の型と同じように、両方の従来入力の種類の Pc、ラップトップ、およびタブレット (マウス、キーボード、タッチ、およびなど) からアクセスできることを確認するユニバーサル Windows プラットフォーム (UWP) アプリケーションの相互作用のエクスペリエンスを構築します。テレビ、Xbox の一般的な*10-foot*ゲームパッド、リモート制御などが発生します。</span><span class="sxs-lookup"><span data-stu-id="392c8-107">Build interaction experiences in your Universal Windows Platform (UWP) applications that ensure your app is usable and accessible through both the traditional input types of PCs, laptops, and tablets (mouse, keyboard, touch, and so on), as well as the input types typical of the TV and Xbox *10-foot* experience, such as the gamepad and remote control.</span></span>

<span data-ttu-id="392c8-108">参照してください[Xbox やテレビの設計](../devices/designing-for-tv.md)で UWP アプリケーションで一般的な設計のガイダンスについて、 *10-foot*が発生します。</span><span class="sxs-lookup"><span data-stu-id="392c8-108">See [Designing for Xbox and TV](../devices/designing-for-tv.md) for general design guidance on UWP applications in the *10-foot* experience.</span></span>

## <a name="overview"></a><span data-ttu-id="392c8-109">概要</span><span class="sxs-lookup"><span data-stu-id="392c8-109">Overview</span></span>

<span data-ttu-id="392c8-110">このトピックでは、について説明しますとする必要があり、について検討する、対話デザイン (またはしないか、プラットフォームの後に次の場合)、ガイダンス、推奨事項、およびに関係なく使用する快適に利用される UWP アプリケーションを構築するための推奨事項を提供デバイス、入力の型またはユーザー機能および設定します。</span><span class="sxs-lookup"><span data-stu-id="392c8-110">In this topic, we discuss what you should consider in your interaction design (or what you don't, if the platform looks after it for you), and provide guidance, recommendations, and suggestions for building UWP applications that are enjoyable to use regardless of device, input type, or user abilities and preferences.</span></span>

<span data-ttu-id="392c8-111">最後の行で直感的なとで簡単に使用、アプリケーションをする必要があります、 *2 フィート*として、環境が、 *10-foot*環境 (その逆)。</span><span class="sxs-lookup"><span data-stu-id="392c8-111">Bottom line, your application should be as intuitive and easy to use in the *2-foot* environment as it is in the *10-foot* environment (and vice versa).</span></span> <span data-ttu-id="392c8-112">ユーザーの任意のデバイスのサポートは、実行に必要なものに集中明確かつ異質、ナビゲーションは一貫性があり、予測可能なために、コンテンツを配置および最短パスをユーザーに付与の UI を可能します。</span><span class="sxs-lookup"><span data-stu-id="392c8-112">Support the user's preferred devices, make the UI focus clear and unmistakable, arrange content so navigation is consistent and predictable, and give users the shortest path possible to what they want to do.</span></span>

> [!NOTE]
> <span data-ttu-id="392c8-113">このトピックで示すコード スニペットはほとんどが XAMLで/c# ですが、基本原則と概念はすべての UWP アプリに共通です。</span><span class="sxs-lookup"><span data-stu-id="392c8-113">Most of the code snippets in this topic are in XAML/C#; however, the principles and concepts apply to all UWP apps.</span></span> <span data-ttu-id="392c8-114">Xbox 向けの HTML/JavaScript UWP アプリを開発している場合は、GitHub の [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) ライブラリを参照することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="392c8-114">If you're developing an HTML/JavaScript UWP app for Xbox, check out the excellent [TVHelpers](https://github.com/Microsoft/TVHelpers/wiki) library on GitHub.</span></span>


## <a name="optimize-for-both-2-foot-and-10-foot-experiences"></a><span data-ttu-id="392c8-115">2 フィートと 10 フィート エクスペリエンスの最適化します。</span><span class="sxs-lookup"><span data-stu-id="392c8-115">Optimize for both 2-foot and 10-foot experiences</span></span>

<span data-ttu-id="392c8-116">少なくとも、お勧めします 2 フィートと 10-foot の両方のシナリオで正常に動作することを確認して、アプリケーションをテストすることと、すべての機能が検出および Xbox にアクセスできる[ゲームパッドとリモート制御](#gamepad-and-remote-control)します。</span><span class="sxs-lookup"><span data-stu-id="392c8-116">At a minimum, we recommend that you test your applications to ensure they work well in both 2-foot and 10-foot scenarios, and that all functionality is discoverable and accessible to the Xbox [gamepad and remote-control](#gamepad-and-remote-control).</span></span>

<span data-ttu-id="392c8-117">すべての入力デバイス (各ここでは、該当するセクションにリンク) を使用して 2 フィートと 10 フィート エクスペリエンスで使用するためにアプリを最適化する他のいくつかの方法を示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-117">Here are some other ways you can optimize your app for use in both 2-foot and 10-foot experiences and with all input devices (each links to the appropriate section in this topic).</span></span>

> [!NOTE]
> <span data-ttu-id="392c8-118">Xbox ゲームパッドとリモコンは、多くの UWP のキーボード動作とエクスペリエンスをサポートして、ために、これらの推奨事項は、両方の入力の種類に適しています。</span><span class="sxs-lookup"><span data-stu-id="392c8-118">Because Xbox gamepads and remote controls support many UWP keyboard behaviors and experiences, these recommendations are appropriate for both input types.</span></span> <span data-ttu-id="392c8-119">参照してください[の相互作用をキーボード](keyboard-interactions.md)キーボード情報の詳細。</span><span class="sxs-lookup"><span data-stu-id="392c8-119">See [Keyboard interactions](keyboard-interactions.md) for more detailed keyboard info.</span></span>

| <span data-ttu-id="392c8-120">機能</span><span class="sxs-lookup"><span data-stu-id="392c8-120">Feature</span></span>        | <span data-ttu-id="392c8-121">説明</span><span class="sxs-lookup"><span data-stu-id="392c8-121">Description</span></span>           |
| -------------------------------------------------------------- |--------------------------------|
| [<span data-ttu-id="392c8-122">お客様 xy のところフォーカスのナビゲーションと相互作用</span><span class="sxs-lookup"><span data-stu-id="392c8-122">XY focus navigation and interaction</span></span>](#xy-focus-navigation-and-interaction) | <span data-ttu-id="392c8-123">**お客様 xy のところフォーカスのナビゲーション**ユーザーがアプリの UI を移動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="392c8-123">**XY focus navigation** enables the user to navigate around your app's UI.</span></span> <span data-ttu-id="392c8-124">ただし、ユーザーの移動は上下左右に制限されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-124">However, this limits the user to navigating up, down, left, and right.</span></span> <span data-ttu-id="392c8-125">このセクションでは、この点に対応するための推奨事項とその他の考慮事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="392c8-125">Recommendations for dealing with this and other considerations are outlined in this section.</span></span> |
| [<span data-ttu-id="392c8-126">マウス モード</span><span class="sxs-lookup"><span data-stu-id="392c8-126">Mouse mode</span></span>](#mouse-mode)|<span data-ttu-id="392c8-127">お客様 xy のところフォーカスのナビゲーションは、実用的でも、可能性もいくつかの種類のマップまたは描画とペイント アプリなどのアプリケーションがありません。</span><span class="sxs-lookup"><span data-stu-id="392c8-127">XY focus navigation isn't practical, or even possible, for some types of applications, such as maps or drawing and painting apps.</span></span> <span data-ttu-id="392c8-128">このような場合は、**マウス モード**ゲームパッドまたはリモート コントロール、ユーザーが自由に移動できますが、PC 上のマウスと同様です。</span><span class="sxs-lookup"><span data-stu-id="392c8-128">In these cases, **mouse mode** lets users navigate freely with a gamepad or remote control, just like a mouse on a PC.</span></span>|
| [<span data-ttu-id="392c8-129">フォーカス ビジュアル</span><span class="sxs-lookup"><span data-stu-id="392c8-129">Focus visual</span></span>](#focus-visual)  | <span data-ttu-id="392c8-130">フォーカスのビジュアルでは、現在フォーカスがある UI 要素を強調表示する罫線です。</span><span class="sxs-lookup"><span data-stu-id="392c8-130">The focus visual is a border that highlights the currently focused UI element.</span></span> <span data-ttu-id="392c8-131">これにより、ユーザーの間の移動またはとの対話は、UI をすばやく識別できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-131">This helps the user quickly identify the UI they are navigating through or interacting with.</span></span>  |
| [<span data-ttu-id="392c8-132">フォーカス engagement</span><span class="sxs-lookup"><span data-stu-id="392c8-132">Focus engagement</span></span>](#focus-engagement) | <span data-ttu-id="392c8-133">フォーカス engagement には、キーを押すユーザーが必要があります、**する/選択**ゲームパッドまたは UI 要素にフォーカスがある場合は、対話するために、リモート コントロールのボタン。</span><span class="sxs-lookup"><span data-stu-id="392c8-133">Focus engagement requires the user to press the **A/Select** button on a gamepad or remote control when a UI element has focus in order to interact with it.</span></span> |
| [<span data-ttu-id="392c8-134">ハードウェア ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-134">Hardware buttons</span></span>](#hardware-buttons) | <span data-ttu-id="392c8-135">ゲームパッド、リモート_コントロールは、非常にさまざまなボタンと構成を提供します。</span><span class="sxs-lookup"><span data-stu-id="392c8-135">The gamepad and remote control provide very different buttons and configurations.</span></span> |

## <a name="gamepad-and-remote-control"></a><span data-ttu-id="392c8-136">ゲームパッドとリモート制御</span><span class="sxs-lookup"><span data-stu-id="392c8-136">Gamepad and remote control</span></span>

<span data-ttu-id="392c8-137">PC でキーボードやマウス、電話とタブレットでタッチを使うように、10 フィート エクスペリエンスではゲームパッドとリモコンがメイン入力デバイスになります。</span><span class="sxs-lookup"><span data-stu-id="392c8-137">Just like keyboard and mouse are for PC, and touch is for phone and tablet, gamepad and remote control are the main input devices for the 10-foot experience.</span></span>
<span data-ttu-id="392c8-138">このセクションでは、ハードウェア ボタンとはどのようなもので何に使うかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="392c8-138">This section introduces what the hardware buttons are and what they do.</span></span>
<span data-ttu-id="392c8-139">「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」と「[マウス モード](#mouse-mode)」では、これらの入力デバイスを使うときにアプリを最適化する方法について学びます。</span><span class="sxs-lookup"><span data-stu-id="392c8-139">In [XY focus navigation and interaction](#xy-focus-navigation-and-interaction) and [Mouse mode](#mouse-mode), you will learn how to optimize your app when using these input devices.</span></span>

<span data-ttu-id="392c8-140">設定なしの場合のゲームパッドとリモコンの動作の品質は、アプリでキーボードがどの程度サポートされているかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="392c8-140">The quality of gamepad and remote behavior that you get out-of-the-box depends on how well keyboard is supported in your app.</span></span> <span data-ttu-id="392c8-141">アプリがゲームパッドとリモコンでうまく動作することを確認する良い方法は、アプリが PC でキーボードを使ってうまく動作するか確認してから、ゲームパッドとリモコンでテストして UI で不十分な箇所を見つけることです。</span><span class="sxs-lookup"><span data-stu-id="392c8-141">A good way to ensure that your app will work well with gamepad/remote is to make sure that it works well with keyboard on PC, and then test with gamepad/remote to find weak spots in your UI.</span></span>

### <a name="hardware-buttons"></a><span data-ttu-id="392c8-142">ハードウェア ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-142">Hardware buttons</span></span>

<span data-ttu-id="392c8-143">このドキュメントでは、次の図に示すボタン名を使っています。</span><span class="sxs-lookup"><span data-stu-id="392c8-143">Throughout this document, buttons will be referred to by the names given in the following diagram.</span></span>

![ゲームパッドとリモコンのボタンの図](images/designing-for-tv/hardware-buttons-gamepad-remote.png)

<span data-ttu-id="392c8-145">図からわかるように、ゲームパッドでサポートされているボタンのいくつかはリモコンでサポートされておらず、逆に、リモコンでサポートされているボタンのいくつかはゲームパッドでサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="392c8-145">As you can see from the diagram, there are some buttons that are supported on gamepad that are not supported on remote control, and vice versa.</span></span> <span data-ttu-id="392c8-146">1 つの入力デバイスのみでサポートされているボタンを使って UI の移動を速くすることもできますが、そのようなボタンを重要な操作に使うように設計してしまうと、ユーザーが一部の UI を操作できなくなる可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="392c8-146">While you can use buttons that are only supported on one input device to make navigating the UI faster, be aware that using them for critical interactions may create a situation where the user is unable to interact with certain parts of the UI.</span></span>

<span data-ttu-id="392c8-147">次の表に、UWP アプリでサポートされているすべてのハードウェア ボタンと、各ボタンがサポートされている入力デバイスを示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-147">The following table lists all of the hardware buttons supported by UWP apps, and which input device supports them.</span></span>

| <span data-ttu-id="392c8-148">Button</span><span class="sxs-lookup"><span data-stu-id="392c8-148">Button</span></span>                    | <span data-ttu-id="392c8-149">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="392c8-149">Gamepad</span></span>   | <span data-ttu-id="392c8-150">リモコン</span><span class="sxs-lookup"><span data-stu-id="392c8-150">Remote control</span></span>    |
|---------------------------|-----------|-------------------|
| <span data-ttu-id="392c8-151">A/[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-151">A/Select button</span></span>           | <span data-ttu-id="392c8-152">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-152">Yes</span></span>       | <span data-ttu-id="392c8-153">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-153">Yes</span></span>               |
| <span data-ttu-id="392c8-154">B/[戻る] ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-154">B/Back button</span></span>             | <span data-ttu-id="392c8-155">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-155">Yes</span></span>       | <span data-ttu-id="392c8-156">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-156">Yes</span></span>               |
| <span data-ttu-id="392c8-157">方向パッド</span><span class="sxs-lookup"><span data-stu-id="392c8-157">Directional pad (D-pad)</span></span>   | <span data-ttu-id="392c8-158">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-158">Yes</span></span>       | <span data-ttu-id="392c8-159">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-159">Yes</span></span>               |
| <span data-ttu-id="392c8-160">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-160">Menu button</span></span>               | <span data-ttu-id="392c8-161">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-161">Yes</span></span>       | <span data-ttu-id="392c8-162">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-162">Yes</span></span>               |
| <span data-ttu-id="392c8-163">表示ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-163">View button</span></span>               | <span data-ttu-id="392c8-164">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-164">Yes</span></span>       | <span data-ttu-id="392c8-165">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-165">Yes</span></span>               |
| <span data-ttu-id="392c8-166">X ボタン、Y ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-166">X and Y buttons</span></span>           | <span data-ttu-id="392c8-167">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-167">Yes</span></span>       | <span data-ttu-id="392c8-168">X</span><span class="sxs-lookup"><span data-stu-id="392c8-168">No</span></span>                |
| <span data-ttu-id="392c8-169">左スティック</span><span class="sxs-lookup"><span data-stu-id="392c8-169">Left stick</span></span>                | <span data-ttu-id="392c8-170">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-170">Yes</span></span>       | <span data-ttu-id="392c8-171">X</span><span class="sxs-lookup"><span data-stu-id="392c8-171">No</span></span>                |
| <span data-ttu-id="392c8-172">右スティック</span><span class="sxs-lookup"><span data-stu-id="392c8-172">Right stick</span></span>               | <span data-ttu-id="392c8-173">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-173">Yes</span></span>       | <span data-ttu-id="392c8-174">X</span><span class="sxs-lookup"><span data-stu-id="392c8-174">No</span></span>                |
| <span data-ttu-id="392c8-175">左トリガー、右トリガー</span><span class="sxs-lookup"><span data-stu-id="392c8-175">Left and right triggers</span></span>   | <span data-ttu-id="392c8-176">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-176">Yes</span></span>       | <span data-ttu-id="392c8-177">X</span><span class="sxs-lookup"><span data-stu-id="392c8-177">No</span></span>                |
| <span data-ttu-id="392c8-178">L ボタン、R ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-178">Left and right bumpers</span></span>    | <span data-ttu-id="392c8-179">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-179">Yes</span></span>       | <span data-ttu-id="392c8-180">X</span><span class="sxs-lookup"><span data-stu-id="392c8-180">No</span></span>                |
| <span data-ttu-id="392c8-181">OneGuide ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-181">OneGuide button</span></span>           | <span data-ttu-id="392c8-182">X</span><span class="sxs-lookup"><span data-stu-id="392c8-182">No</span></span>        | <span data-ttu-id="392c8-183">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-183">Yes</span></span>               |
| <span data-ttu-id="392c8-184">[音量] ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-184">Volume button</span></span>             | <span data-ttu-id="392c8-185">X</span><span class="sxs-lookup"><span data-stu-id="392c8-185">No</span></span>        | <span data-ttu-id="392c8-186">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-186">Yes</span></span>               |
| <span data-ttu-id="392c8-187">チャネル ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-187">Channel button</span></span>            | <span data-ttu-id="392c8-188">X</span><span class="sxs-lookup"><span data-stu-id="392c8-188">No</span></span>        | <span data-ttu-id="392c8-189">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-189">Yes</span></span>               |
| <span data-ttu-id="392c8-190">メディア コントロール ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-190">Media control buttons</span></span>     | <span data-ttu-id="392c8-191">X</span><span class="sxs-lookup"><span data-stu-id="392c8-191">No</span></span>        | <span data-ttu-id="392c8-192">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-192">Yes</span></span>               |
| <span data-ttu-id="392c8-193">[ミュート] ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-193">Mute button</span></span>               | <span data-ttu-id="392c8-194">X</span><span class="sxs-lookup"><span data-stu-id="392c8-194">No</span></span>        | <span data-ttu-id="392c8-195">〇</span><span class="sxs-lookup"><span data-stu-id="392c8-195">Yes</span></span>               |

### <a name="built-in-button-support"></a><span data-ttu-id="392c8-196">組み込みボタンのサポート</span><span class="sxs-lookup"><span data-stu-id="392c8-196">Built-in button support</span></span>

<span data-ttu-id="392c8-197">UWP は、既存のキーボード入力動作をゲームパッドとリモコンの入力に自動的にマップします。</span><span class="sxs-lookup"><span data-stu-id="392c8-197">The UWP automatically maps existing keyboard input behavior to gamepad and remote control input.</span></span> <span data-ttu-id="392c8-198">次の表に、これらの組み込みのマッピングを示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-198">The following table lists these built-in mappings.</span></span>

| <span data-ttu-id="392c8-199">キーボード</span><span class="sxs-lookup"><span data-stu-id="392c8-199">Keyboard</span></span>              | <span data-ttu-id="392c8-200">ゲームパッド/リモコン</span><span class="sxs-lookup"><span data-stu-id="392c8-200">Gamepad/remote</span></span>                        |
|-----------------------|---------------------------------------|
| <span data-ttu-id="392c8-201">方向キー</span><span class="sxs-lookup"><span data-stu-id="392c8-201">Arrow keys</span></span>            | <span data-ttu-id="392c8-202">方向パッド (ゲームパッドの左スティックも同じ)</span><span class="sxs-lookup"><span data-stu-id="392c8-202">D-pad (also left stick on gamepad)</span></span>    |
| <span data-ttu-id="392c8-203">Space キー</span><span class="sxs-lookup"><span data-stu-id="392c8-203">Spacebar</span></span>              | <span data-ttu-id="392c8-204">A/[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-204">A/Select button</span></span>                       |
| <span data-ttu-id="392c8-205">以下に</span><span class="sxs-lookup"><span data-stu-id="392c8-205">Enter</span></span>                 | <span data-ttu-id="392c8-206">A/[選択] ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-206">A/Select button</span></span>                       |
| <span data-ttu-id="392c8-207">Esc キー</span><span class="sxs-lookup"><span data-stu-id="392c8-207">Escape</span></span>                | <span data-ttu-id="392c8-208">B/[戻る] ボタン\*</span><span class="sxs-lookup"><span data-stu-id="392c8-208">B/Back button\*</span></span>                        |

<span data-ttu-id="392c8-209">\*どちらの場合、 [KeyDown](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keydown)も[KeyUp](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keyup) B ボタンのイベントは、アプリによって処理されます、 [SystemNavigationManager.BackRequested](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.backrequested)をする、イベントは発生します。背面に、アプリ内のナビゲーションが発生します。</span><span class="sxs-lookup"><span data-stu-id="392c8-209">\*When neither the [KeyDown](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keydown) nor [KeyUp](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.keyup) events for the B button are handled by the app, the [SystemNavigationManager.BackRequested](https://docs.microsoft.com/uwp/api/windows.ui.core.systemnavigationmanager.backrequested) event will be fired, which should result in back navigation within the app.</span></span> <span data-ttu-id="392c8-210">ただし、次のコード スニペットのように、これを自分で実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-210">However, you have to implement this yourself, as in the following code snippet:</span></span>

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

> [!NOTE]
> <span data-ttu-id="392c8-211">B ボタンを使用して戻る場合は、UI に [戻る] ボタンを表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="392c8-211">If the B button is used to go back, then don't show a back button in the UI.</span></span> <span data-ttu-id="392c8-212">[ナビゲーション ビュー](../controls-and-patterns/navigationview.md) を使用している場合、[戻る] ボタンは自動的に非表示になります。</span><span class="sxs-lookup"><span data-stu-id="392c8-212">If you're using a [Navigation view](../controls-and-patterns/navigationview.md), the back button will be hidden automatically.</span></span> <span data-ttu-id="392c8-213">前に戻る移動の詳細については、「[UWP アプリのナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-213">For more information about backwards navigation, see [Navigation history and backwards navigation for UWP apps](../basics/navigation-history-and-backwards-navigation.md).</span></span>

<span data-ttu-id="392c8-214">Xbox One の UWP アプリでは、**メニュー** ボタンを押してコンテキスト メニューを開く操作もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="392c8-214">UWP apps on Xbox One also support pressing the **Menu** button to open context menus.</span></span> <span data-ttu-id="392c8-215">詳しくは、「[CommandBar と ContextFlyout](#commandbar-and-contextflyout)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-215">For more information, see [CommandBar and ContextFlyout](#commandbar-and-contextflyout).</span></span>

### <a name="accelerator-support"></a><span data-ttu-id="392c8-216">アクセラレータのサポート</span><span class="sxs-lookup"><span data-stu-id="392c8-216">Accelerator support</span></span>

<span data-ttu-id="392c8-217">アクセラレータ ボタンは、UI でナビゲーションを高速化するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="392c8-217">Accelerator buttons are buttons that can be used to speed up navigation through a UI.</span></span> <span data-ttu-id="392c8-218">ただし、これらのボタンは特定の入力デバイスにしかない可能性があるため、すべてのユーザーが機能を使用できるとは限らないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="392c8-218">However, these buttons may be unique to a certain input device, so keep in mind that not all users will be able to use these functions.</span></span> <span data-ttu-id="392c8-219">事実、現在 Xbox One で UWP アプリのアクセラレータ機能をサポートしている入力デバイスは、ゲームパッドだけです。</span><span class="sxs-lookup"><span data-stu-id="392c8-219">In fact, gamepad is currently the only input device that supports accelerator functions for UWP apps on Xbox One.</span></span>

<span data-ttu-id="392c8-220">次の表に、UWP に組み込まれているアクセラレータのサポートと自分で実装することができるアクセラレータのサポートを示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-220">The following table lists the accelerator support built into the UWP, as well as that which you can implement on your own.</span></span> <span data-ttu-id="392c8-221">一貫性のあるわかりやすいユーザー エクスペリエンスを提供するために、これらの動作をカスタム UI で利用してください。</span><span class="sxs-lookup"><span data-stu-id="392c8-221">Utilize these behaviors in your custom UI to provide a consistent and friendly user experience.</span></span>

| <span data-ttu-id="392c8-222">操作</span><span class="sxs-lookup"><span data-stu-id="392c8-222">Interaction</span></span>   | <span data-ttu-id="392c8-223">キーボード/マウス</span><span class="sxs-lookup"><span data-stu-id="392c8-223">Keyboard/Mouse</span></span>   | <span data-ttu-id="392c8-224">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="392c8-224">Gamepad</span></span>      | <span data-ttu-id="392c8-225">組み込み済み:</span><span class="sxs-lookup"><span data-stu-id="392c8-225">Built-in for:</span></span>  | <span data-ttu-id="392c8-226">推奨:</span><span class="sxs-lookup"><span data-stu-id="392c8-226">Recommended for:</span></span> |
|---------------|------------|--------------|----------------|------------------|
| <span data-ttu-id="392c8-227">ページ アップ/ダウン</span><span class="sxs-lookup"><span data-stu-id="392c8-227">Page up/down</span></span>  | <span data-ttu-id="392c8-228">ページ アップ/ダウン</span><span class="sxs-lookup"><span data-stu-id="392c8-228">Page up/down</span></span> | <span data-ttu-id="392c8-229">左/右トリガー</span><span class="sxs-lookup"><span data-stu-id="392c8-229">Left/right triggers</span></span> | <span data-ttu-id="392c8-230">[CalendarView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CalendarView)、[ListBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox)、[ListViewBase](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListViewBase)、[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView)、`ScrollViewer`、[Selector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.Selector)、[LoopingSelector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.LoopingSelector)、[ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、[FlipView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView)</span><span class="sxs-lookup"><span data-stu-id="392c8-230">[CalendarView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CalendarView), [ListBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox), [ListViewBase](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListViewBase), [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView), `ScrollViewer`, [Selector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.Selector), [LoopingSelector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.LoopingSelector), [ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox), [FlipView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView)</span></span> | <span data-ttu-id="392c8-231">垂直スクロールをサポートするビュー</span><span class="sxs-lookup"><span data-stu-id="392c8-231">Views that support vertical scrolling</span></span>
| <span data-ttu-id="392c8-232">ページの左/右</span><span class="sxs-lookup"><span data-stu-id="392c8-232">Page left/right</span></span> | <span data-ttu-id="392c8-233">なし</span><span class="sxs-lookup"><span data-stu-id="392c8-233">None</span></span> | <span data-ttu-id="392c8-234">L/R ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-234">Left/right bumpers</span></span> | <span data-ttu-id="392c8-235">[Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)、[ListBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox)、[ListViewBase](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListViewBase)、[ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView)、`ScrollViewer`、[Selector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.Selector)、[LoopingSelector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.LoopingSelector)、[FlipView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView)</span><span class="sxs-lookup"><span data-stu-id="392c8-235">[Pivot](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot), [ListBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox), [ListViewBase](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListViewBase), [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView), `ScrollViewer`, [Selector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.Selector), [LoopingSelector](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.LoopingSelector), [FlipView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView)</span></span> | <span data-ttu-id="392c8-236">水平スクロールをサポートするビュー</span><span class="sxs-lookup"><span data-stu-id="392c8-236">Views that support horizontal scrolling</span></span>
| <span data-ttu-id="392c8-237">ズーム イン/アウト</span><span class="sxs-lookup"><span data-stu-id="392c8-237">Zoom in/out</span></span>        | <span data-ttu-id="392c8-238">Ctrl + 正符号 (+)/マイナス記号 (-)</span><span class="sxs-lookup"><span data-stu-id="392c8-238">Ctrl +/-</span></span> | <span data-ttu-id="392c8-239">左/右トリガー</span><span class="sxs-lookup"><span data-stu-id="392c8-239">Left/right triggers</span></span> | <span data-ttu-id="392c8-240">なし</span><span class="sxs-lookup"><span data-stu-id="392c8-240">None</span></span> | <span data-ttu-id="392c8-241">`ScrollViewer`、拡大縮小をサポートするビュー</span><span class="sxs-lookup"><span data-stu-id="392c8-241">`ScrollViewer`, views that support zooming in and out</span></span> |
| <span data-ttu-id="392c8-242">ナビゲーション ウィンドウを開く/閉じる</span><span class="sxs-lookup"><span data-stu-id="392c8-242">Open/close nav pane</span></span> | <span data-ttu-id="392c8-243">なし</span><span class="sxs-lookup"><span data-stu-id="392c8-243">None</span></span> | <span data-ttu-id="392c8-244">ビュー</span><span class="sxs-lookup"><span data-stu-id="392c8-244">View</span></span> | <span data-ttu-id="392c8-245">なし</span><span class="sxs-lookup"><span data-stu-id="392c8-245">None</span></span> | <span data-ttu-id="392c8-246">ナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="392c8-246">Navigation panes</span></span> |
| [<span data-ttu-id="392c8-247">検索</span><span class="sxs-lookup"><span data-stu-id="392c8-247">Search</span></span>](#search-experience) | <span data-ttu-id="392c8-248">なし</span><span class="sxs-lookup"><span data-stu-id="392c8-248">None</span></span> | <span data-ttu-id="392c8-249">Y ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-249">Y button</span></span> | <span data-ttu-id="392c8-250">なし</span><span class="sxs-lookup"><span data-stu-id="392c8-250">None</span></span> | <span data-ttu-id="392c8-251">アプリのメインの検索機能へのショートカット</span><span class="sxs-lookup"><span data-stu-id="392c8-251">Shortcut to the main search function in the app</span></span> |
| [<span data-ttu-id="392c8-252">コンテキスト メニューを開く</span><span class="sxs-lookup"><span data-stu-id="392c8-252">Open context menu</span></span>](#commandbar-and-contextflyout) | <span data-ttu-id="392c8-253">右クリック</span><span class="sxs-lookup"><span data-stu-id="392c8-253">Right-click</span></span> | <span data-ttu-id="392c8-254">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="392c8-254">Menu button</span></span> | [<span data-ttu-id="392c8-255">ContextFlyout</span><span class="sxs-lookup"><span data-stu-id="392c8-255">ContextFlyout</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement.ContextFlyout) | <span data-ttu-id="392c8-256">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="392c8-256">Context menus</span></span> |

## <a name="xy-focus-navigation-and-interaction"></a><span data-ttu-id="392c8-257">XY フォーカス ナビゲーションと操作</span><span class="sxs-lookup"><span data-stu-id="392c8-257">XY focus navigation and interaction</span></span>

<span data-ttu-id="392c8-258">アプリがキーボードの適切なフォーカス ナビゲーションをサポートしている場合、ゲームパッドとリモコンでも適切にサポートされます。</span><span class="sxs-lookup"><span data-stu-id="392c8-258">If your app supports proper focus navigation for keyboard, this will translate well to gamepad and remote control.</span></span>
<span data-ttu-id="392c8-259">方向キーを使ったナビゲーションは**方向パッド** (とゲームパッドの**左スティック**) にマップされ、UI 要素の対話式操作は **Enter/[選択]** キーにマップされます (「[ゲームパッドとリモコン](#gamepad-and-remote-control)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="392c8-259">Navigation with the arrow keys is mapped to the **D-pad** (as well as the **left stick** on gamepad), and interaction with UI elements is mapped to the **Enter/Select** key (see [Gamepad and remote control](#gamepad-and-remote-control)).</span></span>

<span data-ttu-id="392c8-260">多くのイベントやプロパティがキーボードとゲームパッドの両方で使用されます。キーボードとゲームパッドはいずれも `KeyDown` イベントと `KeyUp` イベントを発生させ、`IsTabStop="True"` プロパティと `Visibility="Visible"` プロパティを持つコントロール間のみを移動します。</span><span class="sxs-lookup"><span data-stu-id="392c8-260">Many events and properties are used by both keyboard and gamepad&mdash;they both fire `KeyDown` and `KeyUp` events, and they both will only navigate to controls that have the properties `IsTabStop="True"` and `Visibility="Visible"`.</span></span> <span data-ttu-id="392c8-261">キーボードの設計ガイダンスについては、「[キーボード操作](../input/keyboard-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-261">For keyboard design guidance, see [Keyboard interactions](../input/keyboard-interactions.md).</span></span>

<span data-ttu-id="392c8-262">キーボードのサポートが適切に実装されている場合、アプリはかなり適切に機能します。ただし、すべてのシナリオをサポートするためには追加の作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="392c8-262">If keyboard support is implemented properly, your app will work reasonably well; however, there may be some extra work required to support every scenario.</span></span> <span data-ttu-id="392c8-263">最適なユーザー エクスペリエンスを提供するために、アプリ固有のニーズについて考えてください。</span><span class="sxs-lookup"><span data-stu-id="392c8-263">Think about your app's specific needs to provide the best user experience possible.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="392c8-264">マウス モードは、Xbox One で実行されている UWP アプリでは既定で有効です。</span><span class="sxs-lookup"><span data-stu-id="392c8-264">Mouse mode is enabled by default for UWP apps running on Xbox One.</span></span> <span data-ttu-id="392c8-265">マウス モードを無効にし、XY フォーカス ナビゲーションを有効にするには、`Application.RequiresPointerMode=WhenRequested` を設定します。</span><span class="sxs-lookup"><span data-stu-id="392c8-265">To disable mouse mode and enable XY focus navigation, set `Application.RequiresPointerMode=WhenRequested`.</span></span>

### <a name="debugging-focus-issues"></a><span data-ttu-id="392c8-266">フォーカスの問題のデバッグ</span><span class="sxs-lookup"><span data-stu-id="392c8-266">Debugging focus issues</span></span>

<span data-ttu-id="392c8-267">[FocusManager.GetFocusedElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager.getfocusedelement) メソッドによって、現在、どの要素にフォーカスがあるかがわかります。</span><span class="sxs-lookup"><span data-stu-id="392c8-267">The [FocusManager.GetFocusedElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager.getfocusedelement) method will tell you which element currently has focus.</span></span> <span data-ttu-id="392c8-268">これは、フォーカス表示の場所が明確ではない場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="392c8-268">This is useful for situations where the location of the focus visual may not be obvious.</span></span> <span data-ttu-id="392c8-269">この情報は、Visual Studio の出力ウィンドウに次のように記録できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-269">You can log this information to the Visual Studio output window like so:</span></span>

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

<span data-ttu-id="392c8-270">XY ナビゲーションが期待どおりに動作しない場合の一般的な理由には、次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="392c8-270">There are three common reasons why XY navigation might not work the way you expect:</span></span>

* <span data-ttu-id="392c8-271">[IsTabStop](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istabstop) プロパティまたは [Visibility](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.visibility) プロパティが正しく設定されていません。</span><span class="sxs-lookup"><span data-stu-id="392c8-271">The [IsTabStop](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istabstop) or [Visibility](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.visibility) property is set wrong.</span></span>
* <span data-ttu-id="392c8-272">フォーカスを取得するコントロールが、実際には想定以上の大きさです。XY ナビゲーションでは、関心のあるものをレンダリングするコントロールの部分だけでなく、コントロールの合計サイズ ([ActualWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualwidth) と [ActualHeight](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualheight)) が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-272">The control getting focus is actually bigger than you think&mdash;XY navigation looks at the total size of the control ([ActualWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualwidth) and [ActualHeight](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.actualheight)), not just the portion of the control that renders something interesting.</span></span>
* <span data-ttu-id="392c8-273">フォーカス対応コントロールが別のコントロールの上に配置されています。XY ナビゲーションでは、重なり合ったコントロールはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="392c8-273">One focusable control is on top of another&mdash;XY navigation doesn't support controls that are overlapped.</span></span>

<span data-ttu-id="392c8-274">これらの問題を解決しても XY ナビゲーションが引き続き機能しない場合は、「[既定のナビゲーションのオーバーライド](#overriding-the-default-navigation)」で説明されている方法を使って、フォーカスを取得する要素を手動で指定できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-274">If XY navigation is still not working the way you expect after fixing these issues, you can manually point to the element that you want to get focus using the method described in [Overriding the default navigation](#overriding-the-default-navigation).</span></span>

<span data-ttu-id="392c8-275">XY ナビゲーションは意図したとおりに動作するが、フォーカス表示が表示されない場合は、次のいずれかの問題が原因である可能性があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-275">If XY navigation is working as intended but no focus visual is displayed, one of the following issues may be the cause:</span></span>

* <span data-ttu-id="392c8-276">コントロールを再テンプレート化しましたが、フォーカス表示を含めていませんでした。</span><span class="sxs-lookup"><span data-stu-id="392c8-276">You re-templated the control and didn't include a focus visual.</span></span> <span data-ttu-id="392c8-277">`UseSystemFocusVisuals="True"` を設定するか、フォーカス表示を手動で追加します。</span><span class="sxs-lookup"><span data-stu-id="392c8-277">Set `UseSystemFocusVisuals="True"` or add a focus visual manually.</span></span>
* <span data-ttu-id="392c8-278">`Focus(FocusState.Pointer)` を呼び出してフォーカスを移動しました。</span><span class="sxs-lookup"><span data-stu-id="392c8-278">You moved the focus by calling `Focus(FocusState.Pointer)`.</span></span> <span data-ttu-id="392c8-279">[FocusState](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.FocusState) パラメーターによって、フォーカス表示の処理を制御できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-279">The [FocusState](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.FocusState) parameter controls what happens to the focus visual.</span></span> <span data-ttu-id="392c8-280">一般的には、これを `FocusState.Programmatic` に設定してください。これにより、フォーカスが以前に表示されていた場合は表示され、以前に非表示であった場合は非表示になります。</span><span class="sxs-lookup"><span data-stu-id="392c8-280">Generally you should set this to `FocusState.Programmatic`, which keeps the focus visual visible if it was visible before, and hidden if it was hidden before.</span></span>

<span data-ttu-id="392c8-281">このセクションの残りの部分では、XY ナビゲーションを使用する場合の一般的な設計上の課題と、その解決方法のいくつかについて詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="392c8-281">The rest of this section goes into detail about common design challenges when using XY navigation, and offers several ways to solve them.</span></span>

### <a name="inaccessible-ui"></a><span data-ttu-id="392c8-282">アクセスできない UI</span><span class="sxs-lookup"><span data-stu-id="392c8-282">Inaccessible UI</span></span>

<span data-ttu-id="392c8-283">XY フォーカス ナビゲーションはユーザーの動作を上下左右への移動に制限しているため、UI の一部にアクセスできなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-283">Because XY focus navigation limits the user to moving up, down, left, and right, you may end up with scenarios where parts of the UI are inaccessible.</span></span>
<span data-ttu-id="392c8-284">次の図は、XY フォーカス ナビゲーションでサポートされていない UI レイアウトの例を示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-284">The following diagram illustrates an example of the kind of UI layout that XY focus navigation doesn't support.</span></span>
<span data-ttu-id="392c8-285">垂直および水平方向ナビゲーションが優先され、中央の要素はフォーカスを獲得できるほど優先順位が高くないため、ゲームパッド/リモコンを使って中央の要素にアクセスできないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="392c8-285">Note that the element in the middle is not accessible by using gamepad/remote because the vertical and horizontal navigation will be prioritized and the middle element will never be high enough priority to get focus.</span></span>

![4 隅の要素と、アクセスできない中央の要素](images/designing-for-tv/2d-navigation-best-practices-ui-layout-to-avoid.png)

<span data-ttu-id="392c8-287">何らかの理由で UI の配置を変更できない場合は、次のセクションで説明する手法のいずれかを使って、フォーカスの既定の動作をオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="392c8-287">If for some reason rearranging the UI is not possible, use one of the techniques discussed in the next section to override the default focus behavior.</span></span>

### <a name="overriding-the-default-navigation"></a><span data-ttu-id="392c8-288">既定のナビゲーションのオーバーライド </span><span class="sxs-lookup"><span data-stu-id="392c8-288">Overriding the default navigation</span></span>

<span data-ttu-id="392c8-289">ユニバーサル Windows プラットフォームは、方向パッド/左スティックによるナビゲーションがユーザーにとって意味のあるものであることを確認しようとしますが、アプリの目的に沿って最適化された動作を保証することはできません。</span><span class="sxs-lookup"><span data-stu-id="392c8-289">While the Universal Windows Platform tries to ensure that D-pad/left stick navigation makes sense to the user, it cannot guarantee behavior that is optimized for your app's intentions.</span></span>
<span data-ttu-id="392c8-290">ナビゲーションがアプリ用に最適化されていることを確認する最善の方法は、ゲームパッドを使ってナビゲーションをテストし、アプリのシナリオにとって適切な方法でユーザーがすべての UI 要素にアクセスできることを確認することです。</span><span class="sxs-lookup"><span data-stu-id="392c8-290">The best way to ensure that navigation is optimized for your app is to test it with a gamepad and confirm that every UI element can be accessed by the user in a manner that makes sense for your app's scenarios.</span></span> <span data-ttu-id="392c8-291">アプリのシナリオで、提供されている XY フォーカス ナビゲーションでは実現できない動作が必要となる場合は、次のセクションの推奨事項に従ったり、動作をオーバーライドして適切な項目にフォーカスを設定したりことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="392c8-291">In case your app's scenarios call for a behavior not achieved through the XY focus navigation provided, consider following the recommendations in the following sections and/or overriding the behavior to place the focus on a logical item.</span></span>

<span data-ttu-id="392c8-292">次のコード スニペットは、XY フォーカス ナビゲーションの動作をオーバーライドする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="392c8-292">The following code snippet shows how you might override the XY focus navigation behavior:</span></span>

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

<span data-ttu-id="392c8-293">この場合、フォーカスが `Home` ボタンにある状態でユーザーが左に移動すると、フォーカスは `MyBtnLeft` ボタンに移ります。ユーザーが右に移動すると、フォーカスは `MyBtnRight` ボタンに移ります (以下、同様です)。</span><span class="sxs-lookup"><span data-stu-id="392c8-293">In this case, when focus is on the `Home` button and the user navigates to the left, focus will move to the `MyBtnLeft` button; if the user navigates to the right, focus will move to the `MyBtnRight` button; and so on.</span></span>

<span data-ttu-id="392c8-294">フォーカスが特定の方向でコントロールから移動することを防ぐには、`XYFocus*` プロパティを使ってそのコントロールで方向を指定します。</span><span class="sxs-lookup"><span data-stu-id="392c8-294">To prevent the focus from moving from a control in a certain direction, use the `XYFocus*` property to point it at the same control:</span></span>

```xml
<Button Name="HomeButton"  
        Content="Home"  
        XYFocusLeft ="{x:Bind HomeButton}" />
```

<span data-ttu-id="392c8-295">これらの `XYFocus` プロパティを使用して、コントロールの親は、次のフォーカスの候補がビジュアル ツリー外である場合、子のナビゲーションを強制することができます。ただし、フォーカスを持つ子が同じ `XYFocus` プロパティを使用している場合を除きます。</span><span class="sxs-lookup"><span data-stu-id="392c8-295">Using these `XYFocus` properties, a control parent can also force the navigation of its children when the next focus candidate is out of its visual tree, unless the child who has the focus uses the same `XYFocus` property.</span></span>

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

<span data-ttu-id="392c8-296">上記のサンプルでは、フォーカスが `Button` Two にあり、ユーザーが右に移動した場合、最適なフォーカスの候補は `Button` Four ですが、フォーカスは `Button` Three に移動します。これは、親の `UserControl` で、ビジュアル ツリー外である場合はその場所に移動するように強制されているためです。</span><span class="sxs-lookup"><span data-stu-id="392c8-296">In the sample above, if the focus is on `Button` Two and the user navigates to the right, the best focus candidate is `Button` Four; however, the focus is moved to `Button` Three because the parent `UserControl` forces it to navigate there when it is out of its visual tree.</span></span>

### <a name="path-of-least-clicks"></a><span data-ttu-id="392c8-297">最小回数のクリック数</span><span class="sxs-lookup"><span data-stu-id="392c8-297">Path of least clicks</span></span>

<span data-ttu-id="392c8-298">ユーザーが最も一般的なタスクを最小クリック回数で実行できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="392c8-298">Try to allow the user to perform the most common tasks in the least number of clicks.</span></span> <span data-ttu-id="392c8-299">次の例では、(最初にフォーカスがある) **再生**ボタンとよく使われる要素の間に [TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) が配置されているため、優先順位の高いタスクの間に不要な要素が入り込んでいます。</span><span class="sxs-lookup"><span data-stu-id="392c8-299">In the following example, the [TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) is placed between the **Play** button (which initially gets focus) and a commonly used element, so that an unnecessary element is placed in between priority tasks.</span></span>

![ナビゲーションのベスト プラクティスは最小限のクリックのパスを提供すること](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks.png)

<span data-ttu-id="392c8-301">次の例では、[TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) は**再生**ボタンの上に配置されています。</span><span class="sxs-lookup"><span data-stu-id="392c8-301">In the following example, the [TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) is placed above the **Play** button instead.</span></span>
<span data-ttu-id="392c8-302">優先順位の高いタスクの間に不要な要素が配置されないように UI を並べ替えるだけで、アプリの操作性が大幅に向上します。</span><span class="sxs-lookup"><span data-stu-id="392c8-302">Simply rearranging the UI so that unnecessary elements are not placed in between priority tasks will greatly improve your app's usability.</span></span>

![優先順位の高いタスクの間から再生ボタンの上に移動した TextBlock](images/designing-for-tv/2d-navigation-best-practices-provide-path-with-least-clicks-2.png)

### <a name="commandbar-and-contextflyout"></a><span data-ttu-id="392c8-304">CommandBar と ContextFlyout</span><span class="sxs-lookup"><span data-stu-id="392c8-304">CommandBar and ContextFlyout</span></span>

<span data-ttu-id="392c8-305">使用する場合、 [CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar)で説明したように、一覧をスクロールの問題に留意[問題。UI 要素が時間の長いスクロール リスト/グリッドの後にある](#problem-ui-elements-located-after-long-scrolling-list-grid)します。</span><span class="sxs-lookup"><span data-stu-id="392c8-305">When using a [CommandBar](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar), keep in mind the issue of scrolling through a list as mentioned in [Problem: UI elements located after long scrolling list/grid](#problem-ui-elements-located-after-long-scrolling-list-grid).</span></span> <span data-ttu-id="392c8-306">次の図は、`CommandBar` がリストやグリッドの下にある UI レイアウトです。</span><span class="sxs-lookup"><span data-stu-id="392c8-306">The following image shows a UI layout with the `CommandBar` on the bottom of a list/grid.</span></span> <span data-ttu-id="392c8-307">ユーザーはリストやグリッド全体をスクロールしなければ `CommandBar` に到達できません。</span><span class="sxs-lookup"><span data-stu-id="392c8-307">The user would need to scroll all the way down through the list/grid to reach the `CommandBar`.</span></span>

![リストやグリッドの下にある CommandBar](images/designing-for-tv/2d-navigation-best-practices-commandbar-and-contextflyout.png)

<span data-ttu-id="392c8-309">配置する場合、 `CommandBar` *上*リスト/グリッドでしょうか。</span><span class="sxs-lookup"><span data-stu-id="392c8-309">What if you put the `CommandBar` *above* the list/grid?</span></span> <span data-ttu-id="392c8-310">リストやグリッドを下へスクロールしたユーザーは `CommandBar` に戻るために上へスクロールして戻る必要がありますが、前の構成よりもナビゲーションはわずかに少なくなります。</span><span class="sxs-lookup"><span data-stu-id="392c8-310">While a user who scrolled down the list/grid would have to scroll back up to reach the `CommandBar`, it is slightly less navigation than the previous configuration.</span></span> <span data-ttu-id="392c8-311">ただし、これは、アプリの最初のフォーカスが `CommandBar` の横または上に配置されている場合です。最初のフォーカスがリストやグリッドの下にある場合、この方法はうまく機能しません。</span><span class="sxs-lookup"><span data-stu-id="392c8-311">Note that this is assuming that your app's initial focus is placed next to or above the `CommandBar`; this approach won't work as well if the initial focus is below the list/grid.</span></span> <span data-ttu-id="392c8-312">これらの `CommandBar` 項目があまりアクセスする必要のないグローバルな操作の項目の場合 (**同期** ボタンなど)、リストやグリッドの上に置いても問題ありません。</span><span class="sxs-lookup"><span data-stu-id="392c8-312">If these `CommandBar` items are global action items that don't have to be accessed very often (such as a **Sync** button), it may be acceptable to have them above the list/grid.</span></span>

<span data-ttu-id="392c8-313">`CommandBar` の項目を縦方向に重ねることはできませんが、UI レイアウトで適切な場合はスクロール方向と異なる向き (たとえば、縦方向にスクロールするリストの左右や、横方向にスクロールするリストの上下) に項目を配置することも検討できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-313">While you can't stack a `CommandBar`'s items vertically, placing them against the scroll direction (for example, to the left or right of a vertically scrolling list, or the top or bottom of a horizontally scrolling list) is another option you may want to consider if it works well for your UI layout.</span></span>

<span data-ttu-id="392c8-314">ユーザーが項目に簡単にアクセスできる必要がある `CommandBar` をアプリで使う場合、それらの項目を [ContextFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout) 内に配置して `CommandBar` から削除することを検討できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-314">If your app has a `CommandBar` whose items need to be readily accessible by users, you may want to consider placing these items inside a [ContextFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout) and removing them from the `CommandBar`.</span></span> <span data-ttu-id="392c8-315">`ContextFlyout` プロパティである[UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement)であり、[コンテキスト メニュー](../controls-and-patterns/dialogs-and-flyouts/index.md)その要素に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="392c8-315">`ContextFlyout` is a property of [UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) and is the [context menu](../controls-and-patterns/dialogs-and-flyouts/index.md) associated with that element.</span></span> <span data-ttu-id="392c8-316">PC では、`ContextFlyout` を持つ要素を右クリックすると、そのコンテキスト メニューがポップアップ表示されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-316">On PC, when you right-click on an element with a `ContextFlyout`, that context menu will pop up.</span></span> <span data-ttu-id="392c8-317">Xbox One では、このような要素にフォーカスがあるときに**メニュー** ボタンを押すと、コンテキスト メニューがポップアップ表示されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-317">On Xbox One, this will happen when you press the **Menu** button while the focus is on such an element.</span></span>

### <a name="ui-layout-challenges"></a><span data-ttu-id="392c8-318">UI レイアウトの問題</span><span class="sxs-lookup"><span data-stu-id="392c8-318">UI layout challenges</span></span>

<span data-ttu-id="392c8-319">XY フォーカス ナビゲーションの特性により、一部の UI レイアウトは設定が難しく、状況ごとに評価が必要です。</span><span class="sxs-lookup"><span data-stu-id="392c8-319">Some UI layouts are more challenging due to the nature of XY focus navigation, and should be evaluated on a case-by-case basis.</span></span> <span data-ttu-id="392c8-320">"正解" は 1 つではなく、どの解決策を選ぶかはアプリのニーズ次第ですが、優れたテレビ エクスペリエンスを提供するために利用できる方法がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="392c8-320">While there is no single "right" way, and which solution you choose is up to your app's specific needs, there are some techniques that you can employ to make a great TV experience.</span></span>

<span data-ttu-id="392c8-321">このことをさらに理解するために、架空のアプリでこれらの問題のいくつかとそれを克服する手法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="392c8-321">To understand this better, let's look at an imaginary app that illustrates some of these issues and techniques to overcome them.</span></span>

> [!NOTE]
> <span data-ttu-id="392c8-322">この架空のアプリは、UI の問題とその解決策を示すことを目的としており、実際のアプリの最適なユーザー エクスペリエンスを示すものではありません。</span><span class="sxs-lookup"><span data-stu-id="392c8-322">This fake app is meant to illustrate UI problems and potential solutions to them, and is not intended to show the best user experience for your particular app.</span></span>

<span data-ttu-id="392c8-323">次の架空の不動産アプリは、販売中の家の一覧、地図、不動産の説明などの情報を表示するものです。</span><span class="sxs-lookup"><span data-stu-id="392c8-323">The following is an imaginary real estate app which shows a list of houses available for sale, a map, a description of a property, and other information.</span></span> <span data-ttu-id="392c8-324">このアプリでは、次の方法で克服できる 3 つの課題が生じます。</span><span class="sxs-lookup"><span data-stu-id="392c8-324">This app poses three challenges that you can overcome by using the following techniques:</span></span>

- [<span data-ttu-id="392c8-325">UI の再配置</span><span class="sxs-lookup"><span data-stu-id="392c8-325">UI rearrange</span></span>](#ui-rearrange)
- [<span data-ttu-id="392c8-326">フォーカス engagement</span><span class="sxs-lookup"><span data-stu-id="392c8-326">Focus engagement</span></span>](#engagement)
- [<span data-ttu-id="392c8-327">マウス モード</span><span class="sxs-lookup"><span data-stu-id="392c8-327">Mouse mode</span></span>](#mouse-mode)

![架空の不動産アプリ](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app.png)

#### <span data-ttu-id="392c8-329">問題: 時間スクロール リスト/グリッドの後にある UI 要素 <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a></span><span class="sxs-lookup"><span data-stu-id="392c8-329">Problem: UI elements located after long scrolling list/grid <a name="problem-ui-elements-located-after-long-scrolling-list-grid"></a></span></span>

<span data-ttu-id="392c8-330">次の図に示すプロパティの [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) は、非常に長いスクロールをするリストです。</span><span class="sxs-lookup"><span data-stu-id="392c8-330">The [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) of properties shown in the following image is a very long scrolling list.</span></span> <span data-ttu-id="392c8-331">この `ListView` で[エンゲージメント](#focus-engagement)が要求され*ない*場合、ユーザーがリストに移動するとフォーカスはリストの最初の項目に設定されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-331">If [engagement](#focus-engagement) is *not* required on the `ListView`, when the user navigates to the list, focus will be placed on the first item in the list.</span></span> <span data-ttu-id="392c8-332">ユーザーが **[前へ]** または **[次へ]** ボタンにアクセスするには、リスト内のすべての項目を移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-332">For the user to reach the **Previous** or **Next** button, they must go through all the items in the list.</span></span> <span data-ttu-id="392c8-333">このような、リスト全体を移動する必要がある設計は、ユーザーがそのエクスペリエンスを許容できるほどリストが短くなければ煩わしくなるため、その他のオプションを検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="392c8-333">In cases like this where requiring the user to traverse the entire list is painful&mdash;that is, when the list is not short enough for this experience to be acceptable&mdash;you may want to consider other options.</span></span>

![不動産アプリ: 50 個の項目があるリストは、下のボタンに移動するまでに 51 回のクリックが必要](images/designing-for-tv/2d-focus-navigation-and-interaction-real-estate-app-list.png)

#### <a name="solutions"></a><span data-ttu-id="392c8-335">解決策</span><span class="sxs-lookup"><span data-stu-id="392c8-335">Solutions</span></span>

<span data-ttu-id="392c8-336">**UI の再配置 <a name="ui-rearrange"></a>**</span><span class="sxs-lookup"><span data-stu-id="392c8-336">**UI rearrange <a name="ui-rearrange"></a>**</span></span>

<span data-ttu-id="392c8-337">最初のフォーカスがページの下部に設定されない限り、通常、長いスクロールをするリストの上に配置した UI 要素の方が、下に配置した場合よりも簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="392c8-337">Unless your initial focus is placed at the bottom of the page, UI elements placed above a long scrolling list are typically more easily accessible than if placed below.</span></span>
<span data-ttu-id="392c8-338">この新しいレイアウトが他のデバイスでも有効な場合、Xbox One のためだけに UI に特別な変更を行うのでなく、すべてのデバイス ファミリ用にレイアウトを変更する方が、低コストのアプローチになる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-338">If this new layout works for other devices, changing the layout for all device families instead of doing special UI changes just for Xbox One might be a less costly approach.</span></span>
<span data-ttu-id="392c8-339">また、スクロール方向と異なる向き (縦方向にスクロールするリストでは横方向、横方向にスクロールするリストでは縦方向) に UI 要素を配置すると、アクセシビリティがさらに向上します。</span><span class="sxs-lookup"><span data-stu-id="392c8-339">Additionally, placing UI elements against the scrolling direction (that is, horizontally to a vertically scrolling list, or vertically to a horizontally scrolling list) will make for even better accessibility.</span></span>

![不動産アプリ: 長いスクロールをするリストの上にボタンを配置](images/designing-for-tv/2d-focus-navigation-and-interaction-ui-rearrange.png)

<span data-ttu-id="392c8-341">**フォーカス engagement <a name="engagement"></a>**</span><span class="sxs-lookup"><span data-stu-id="392c8-341">**Focus engagement <a name="engagement"></a>**</span></span>

<span data-ttu-id="392c8-342">エンゲージメントが*要求される*場合、`ListView` 全体が 1 つのフォーカスの対象になります。</span><span class="sxs-lookup"><span data-stu-id="392c8-342">When engagement is *required*, the entire `ListView` becomes a single focus target.</span></span> <span data-ttu-id="392c8-343">ユーザーはリストの内容をバイパスして、フォーカス可能な次の要素にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="392c8-343">The user will be able to bypass the contents of the list to get to the next focusable element.</span></span> <span data-ttu-id="392c8-344">エンゲージメントをサポートしているコントロールとその使用方法について詳しくは、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-344">Read more about what controls support engagement and how to use them in [Focus engagement](#focus-engagement).</span></span>

![不動産アプリ: エンゲージメントの要求を設定して 1 クリックのみで [前へ]/[次へ] ボタンにアクセス](images/designing-for-tv/2d-focus-navigation-and-interaction-engagement.png)

#### <a name="problem-scrollviewer-without-any-focusable-elements"></a><span data-ttu-id="392c8-346">問題: フォーカスを設定できる任意の要素を使用せずに ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="392c8-346">Problem: ScrollViewer without any focusable elements</span></span>

<span data-ttu-id="392c8-347">XY フォーカス ナビゲーションは、フォーカス可能な UI 要素に 1 回で移動できることを前提としているため、フォーカス可能な要素を 1 つも含まない [ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer) (この例ではテキストのみの要素) は、ユーザーが `ScrollViewer` のすべてのコンテンツを表示することができない状況を招く可能性があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-347">Because XY focus navigation relies on navigating to one focusable UI element at a time, a [ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer) that doesn't contain any focusable elements (such as one with only text, as in this example) may cause a scenario where the user isn't able to view all of the content in the `ScrollViewer`.</span></span>
<span data-ttu-id="392c8-348">この問題の解決策とその他の関連するシナリオについては、「[フォーカス エンゲージメント](#focus-engagement)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-348">For solutions to this and other related scenarios, see [Focus engagement](#focus-engagement).</span></span>

![不動産アプリ:テキストのみのある ScrollViewer](images/designing-for-tv/2d-focus-navigation-and-interaction-scrollviewer.png)

#### <a name="problem-free-scrolling-ui"></a><span data-ttu-id="392c8-350">問題: 無料のスクロール UI</span><span class="sxs-lookup"><span data-stu-id="392c8-350">Problem: Free-scrolling UI</span></span>

<span data-ttu-id="392c8-351">描画面や次の例にある地図など、アプリに自由スクロール UI が必要な場合、XY フォーカス ナビゲーションのみでは機能しません。</span><span class="sxs-lookup"><span data-stu-id="392c8-351">When your app requires a freely scrolling UI, such as a drawing surface or, in this example, a map, XY focus navigation simply doesn't work.</span></span>
<span data-ttu-id="392c8-352">このような場合は、[マウス モード](#mouse-mode)をオンにして、ユーザーが UI 要素内を自由に移動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="392c8-352">In such cases, you can turn on [mouse mode](#mouse-mode) to allow the user to navigate freely inside a UI element.</span></span>

![マウス モードを使う地図の UI 要素](images/designing-for-tv/map-mouse-mode.png)

## <a name="mouse-mode"></a><span data-ttu-id="392c8-354">[マウス モード]</span><span class="sxs-lookup"><span data-stu-id="392c8-354">Mouse mode</span></span>

<span data-ttu-id="392c8-355">「[XY フォーカス ナビゲーションと対話式操作](#xy-focus-navigation-and-interaction)」で説明するとおり、Xbox One でフォーカスを移動するには、XY ナビゲーション システムを使います。ユーザーは、フォーカスを上下左右に動かしてコントロール間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-355">As described in [XY focus navigation and interaction](#xy-focus-navigation-and-interaction), on Xbox One the focus is moved by using an XY navigation system, allowing the user to shift the focus from control to control by moving up, down, left, and right.</span></span>
<span data-ttu-id="392c8-356">ただし、[WebView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.WebView) や [MapControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Maps.MapControl) などの一部のコントロールでは、ユーザーがコントロールの境界内でポインターを自由に動かせる、マウスのような対話式操作が必要です。</span><span class="sxs-lookup"><span data-stu-id="392c8-356">However, some controls, such as [WebView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.WebView) and [MapControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Maps.MapControl), require a mouse-like interaction where users can freely move the pointer inside the boundaries of the control.</span></span>
<span data-ttu-id="392c8-357">また、ユーザーがページ全体でポインターを動かせるようにして、PC でマウスを使うときと同じようなエクスペリエンスをゲームパッド/リモコンで体験できるようにする必要があるアプリもあります。</span><span class="sxs-lookup"><span data-stu-id="392c8-357">There are also some apps where it makes sense for the user to be able to move the pointer across the entire page, having an experience with gamepad/remote similar to what users can find on a PC with a mouse.</span></span>

<span data-ttu-id="392c8-358">このような場合、ページ全体に対して、または、ページ内のいずれかのコントロールに対して、ポインター (マウス モード) を要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-358">For these scenarios, you should request a pointer (mouse mode) for the entire page, or on a control inside a page.</span></span>
<span data-ttu-id="392c8-359">たとえば、アプリのページで `WebView` コントロールを使い、そのコントロール内ではマウス モード、それ以外はすべて XY フォーカス ナビゲーションを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="392c8-359">For example, your app could have a page that has a `WebView` control that uses mouse mode only while inside the control, and XY focus navigation everywhere else.</span></span>
<span data-ttu-id="392c8-360">ポインターを要求する場合、**コントロールまたはページが有効になったとき**、または**ページにフォーカスがあるとき**のどちらでポインターを要求するかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-360">To request a pointer, you can specify whether you want it **when a control or page is engaged** or **when a page has focus**.</span></span>

> [!NOTE]
> <span data-ttu-id="392c8-361">コントロールにフォーカスがある場合にポインターを要求することはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="392c8-361">Requesting a pointer when a control gets focus is not supported.</span></span>

<span data-ttu-id="392c8-362">Xbox One で実行されている XAML アプリとホスト型 Web アプリのいずれの場合も、マウス モードがアプリ全体で既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="392c8-362">For both XAML and hosted web apps running on Xbox One, mouse mode is turned on by default for the entire app.</span></span> <span data-ttu-id="392c8-363">これを無効にして、XY ナビゲーション用にアプリを最適化することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="392c8-363">It is highly recommended that you turn this off and optimize your app for XY navigation.</span></span> <span data-ttu-id="392c8-364">これを行うには、`Application.RequiresPointerMode` プロパティを `WhenRequested` に設定して、コントロールやページから呼び出された場合にのみマウス モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="392c8-364">To do this, set the `Application.RequiresPointerMode` property to `WhenRequested` so that you only enable mouse mode when a control or page calls for it.</span></span>

<span data-ttu-id="392c8-365">XAML アプリでこれを行うには、`App` クラスで次のコードを使います。</span><span class="sxs-lookup"><span data-stu-id="392c8-365">To do this in a XAML app, use the following code in your `App` class:</span></span>

```csharp
public App()
{
    this.InitializeComponent();
    this.RequiresPointerMode =
        Windows.UI.Xaml.ApplicationRequiresPointerMode.WhenRequested;
    this.Suspending += OnSuspending;
}
```

<span data-ttu-id="392c8-366">HTML/JavaScript のサンプル コードなどの詳細情報については、「[マウス モードを無効にする方法](../../xbox-apps/how-to-disable-mouse-mode.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-366">For more information, including sample code for HTML/JavaScript, see [How to disable mouse mode](../../xbox-apps/how-to-disable-mouse-mode.md).</span></span>

<span data-ttu-id="392c8-367">次の図は、マウス モードでのゲームパッド/リモコンのボタンのマッピングを示しています。</span><span class="sxs-lookup"><span data-stu-id="392c8-367">The following diagram shows the button mappings for gamepad/remote in mouse mode.</span></span>

![マウス モードでのゲームパッド/リモコンのボタンのマッピング](images/designing-for-tv/10ft_infographics_mouse-mode.png)

> [!NOTE]
> <span data-ttu-id="392c8-369">マウス モードは Xbox One のゲームパッド/リモコンのみでサポートされています。</span><span class="sxs-lookup"><span data-stu-id="392c8-369">Mouse mode is only supported on Xbox One with gamepad/remote.</span></span> <span data-ttu-id="392c8-370">その他のデバイス ファミリや入力タイプでは自動的に無視されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-370">On other device families and input types it is silently ignored.</span></span>

<span data-ttu-id="392c8-371">コントロールまたはページでマウス モードをアクティブ化するには、そのコントロールまたはページで [RequiresPointer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.requirespointer) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="392c8-371">Use the [RequiresPointer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.requirespointer) property on a control or page to activate mouse mode on it.</span></span> <span data-ttu-id="392c8-372">このプロパティには `Never` (既定値)、`WhenEngaged`、`WhenFocused` の 3 つの値があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-372">This property has three possible values: `Never` (the default value), `WhenEngaged`, and `WhenFocused`.</span></span>

### <a name="activating-mouse-mode-on-a-control"></a><span data-ttu-id="392c8-373">コントロールでのマウス モードのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="392c8-373">Activating mouse mode on a control</span></span>

<span data-ttu-id="392c8-374">`RequiresPointer="WhenEngaged"` の状態でユーザーがコントロールを使うと、ユーザーが解除するまでコントロールでマウス モードがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-374">When the user engages a control with `RequiresPointer="WhenEngaged"`, mouse mode is activated on the control until the user disengages it.</span></span> <span data-ttu-id="392c8-375">次のコード スニペットは、使用時にマウス モードをアクティブ化する単純な `MapControl` を示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-375">The following code snippet demonstrates a simple `MapControl` that activates mouse mode when engaged:</span></span>

```xml
<Page>
    <Grid>
        <MapControl IsEngagementRequired="true"
                    RequiresPointer="WhenEngaged"/>
    </Grid>
</Page>
```

> [!NOTE]
> <span data-ttu-id="392c8-376">コントロールを使うときにマウス モードをアクティブ化する場合、`IsEngagementRequired="true"` も指定する必要があります。そうしないと、マウス モードがアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="392c8-376">If a control activates mouse mode when engaged, it must also require engagement with `IsEngagementRequired="true"`; otherwise, mouse mode will never be activated.</span></span>

<span data-ttu-id="392c8-377">コントロールがマウス モードになると、そのコントロールの入れ子になったコントロールもマウス モードになります。</span><span class="sxs-lookup"><span data-stu-id="392c8-377">When a control is in mouse mode, its nested controls will be in mouse mode as well.</span></span> <span data-ttu-id="392c8-378">その子の要求モードは無視されます。親をマウス モードにして子はマウス モードにしないということはできません。</span><span class="sxs-lookup"><span data-stu-id="392c8-378">The requested mode of its children will be ignored&mdash;it's impossible for a parent to be in mouse mode but a child not to be.</span></span>

<span data-ttu-id="392c8-379">また、コントロールの要求モードはフォーカスがあるときにのみ調べられます。そのため、フォーカスがある間はモードは動的に変更されません。</span><span class="sxs-lookup"><span data-stu-id="392c8-379">Additionally, the requested mode of a control is only inspected when it gets focus, so the mode won't change dynamically while it has focus.</span></span>

### <a name="activating-mouse-mode-on-a-page"></a><span data-ttu-id="392c8-380">ページでのマウス モードのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="392c8-380">Activating mouse mode on a page</span></span>

<span data-ttu-id="392c8-381">ページに `RequiresPointer="WhenFocused"` プロパティを設定している場合、フォーカスがあるとページ全体に対してマウス モードがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-381">When a page has the property `RequiresPointer="WhenFocused"`, mouse mode will be activated for the whole page when it gets focus.</span></span> <span data-ttu-id="392c8-382">次のコード スニペットは、ページでこのプロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="392c8-382">The following code snippet demonstrates giving a page this property:</span></span>

```xml
<Page RequiresPointer="WhenFocused">
    ...
</Page>
```

> [!NOTE]
> <span data-ttu-id="392c8-383">`WhenFocused` の値は [Page](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page) オブジェクトでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="392c8-383">The `WhenFocused` value is only supported on [Page](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page) objects.</span></span> <span data-ttu-id="392c8-384">コントロールにこの値を設定しようとすると、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="392c8-384">If you try to set this value on a control, an exception will be thrown.</span></span>

### <a name="disabling-mouse-mode-for-full-screen-content"></a><span data-ttu-id="392c8-385">全画面コンテンツのマウス モードの無効化</span><span class="sxs-lookup"><span data-stu-id="392c8-385">Disabling mouse mode for full screen content</span></span>

<span data-ttu-id="392c8-386">通常、全画面表示でビデオやその他の種類のコンテンツを表示する場合、ユーザーの注意をそらす可能性があるため、カーソルを非表示にします。</span><span class="sxs-lookup"><span data-stu-id="392c8-386">Usually when displaying video or other types of content in full screen, you will want to hide the cursor because it can distract the user.</span></span> <span data-ttu-id="392c8-387">このシナリオは、アプリの他の部分ではマウス モードを使用するが、全画面コンテンツを表示するときはマウス モードを無効にする必要がある場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="392c8-387">This scenario occurs when the rest of the app uses mouse mode, but you want to turn it off when showing full screen content.</span></span> <span data-ttu-id="392c8-388">これを実現するには、全画面コンテンツを独自の `Page` に配置し、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="392c8-388">To accomplish this, put the full screen content on its own `Page`, and follow the steps below.</span></span>

1. <span data-ttu-id="392c8-389">`App` オブジェクトで、`RequiresPointerMode="WhenRequested"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="392c8-389">In the `App` object, set `RequiresPointerMode="WhenRequested"`.</span></span>
2. <span data-ttu-id="392c8-390">全画面表示の `Page` を*除く*すべての `Page` オブジェクトで、`RequiresPointer="WhenFocused"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="392c8-390">In every `Page` object *except* for the full screen `Page`, set `RequiresPointer="WhenFocused"`.</span></span>
3. <span data-ttu-id="392c8-391">全画面表示の `Page` で、`RequiresPointer="Never"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="392c8-391">For the full screen `Page`, set `RequiresPointer="Never"`.</span></span>

<span data-ttu-id="392c8-392">これにより、全画面コンテンツを表示するときに、カーソルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="392c8-392">This way, the cursor will never appear when showing full screen content.</span></span>

## <a name="focus-visual"></a><span data-ttu-id="392c8-393">フォーカスの視覚効果</span><span class="sxs-lookup"><span data-stu-id="392c8-393">Focus visual</span></span>

<span data-ttu-id="392c8-394">フォーカス表示とは、現在フォーカスがある UI 要素を囲む境界線のことです。</span><span class="sxs-lookup"><span data-stu-id="392c8-394">The focus visual is the border around the UI element that currently has focus.</span></span> <span data-ttu-id="392c8-395">この機能を使ってユーザーの現在位置をわかりやすく示すことで、ユーザーが自分の位置を見失わずに UI を移動しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="392c8-395">This helps orient the user so that they can easily navigate your UI without getting lost.</span></span>

<span data-ttu-id="392c8-396">フォーカス表示は、表示が更新され、多数のカスタマイズ オプションが追加されているため、開発者は 1 つのフォーカス表示を用意すれば、PC と Xbox One、さらにはキーボードやゲームパッド/リモコンをサポートするその他の Windows 10 デバイスで正しく動作することを期待できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-396">With a visual update and numerous customization options added to focus visual, developers can trust that a single focus visual will work well on PCs and Xbox One, as well as on any other Windows 10 devices that support keyboard and/or gamepad/remote.</span></span>

<span data-ttu-id="392c8-397">ただし、異なるプラットフォームで同じフォーカス表示を使うことはできますが、10 フィート エクスペリエンスではフォーカス表示の利用状況がやや異なります。</span><span class="sxs-lookup"><span data-stu-id="392c8-397">While the same focus visual can be used across different platforms, the context in which the user encounters it is slightly different for the 10-foot experience.</span></span> <span data-ttu-id="392c8-398">この場合、ユーザーはテレビ画面全体に十分注意を払っていないと想定し、ユーザーが表示を探す際にフラストレーションを感じないように、現在フォーカスのある要素を常に明確に表示することが重要です。</span><span class="sxs-lookup"><span data-stu-id="392c8-398">You should assume that the user is not paying full attention to the entire TV screen, and therefore it is important that the currently focused element is clearly visible to the user at all times to avoid the frustration of searching for the visual.</span></span>

<span data-ttu-id="392c8-399">また、フォーカス表示は、ゲームパッドやリモコンを使うときは既定で表示されますが、キーボードを使うときは既定で表示*されない*ことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="392c8-399">It is also important to keep in mind that the focus visual is displayed by default when using a gamepad or remote control, but *not* a keyboard.</span></span> <span data-ttu-id="392c8-400">したがって、実装していなくても Xbox One でアプリを実行すると表示されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-400">Thus, even if you don't implement it, it will appear when you run your app on Xbox One.</span></span>

### <a name="initial-focus-visual-placement"></a><span data-ttu-id="392c8-401">フォーカス表示の初期設定</span><span class="sxs-lookup"><span data-stu-id="392c8-401">Initial focus visual placement</span></span>

<span data-ttu-id="392c8-402">アプリを起動したりページに移動したりするときは、ユーザーがアクションを実行する最初の要素として意味のある UI 要素にフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="392c8-402">When launching an app or navigating to a page, place the focus on a UI element that makes sense as the first element on which the user would take action.</span></span> <span data-ttu-id="392c8-403">たとえば、フォト アプリではギャラリー内の最初の項目にフォーカスを設定し、音楽アプリで曲の詳細ビューに移動する場合は音楽を再生しやすいように再生ボタンにフォーカスを設定できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-403">For example, a photo app may place focus on the first item in the gallery, and a music app navigated to a detailed view of a song might place focus on the play button for ease of playing music.</span></span>

<span data-ttu-id="392c8-404">初期フォーカスは、アプリの左上 (右から左へ移動する場合は右上) の領域に設定するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="392c8-404">Try to put initial focus in the top left region of your app (or top right for a right-to-left flow).</span></span> <span data-ttu-id="392c8-405">通常、アプリのコンテンツ フローはそこから開始されるため、ほとんどのユーザーは最初にその隅を意識する傾向があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-405">Most users tend to focus on that corner first because that's where app content flow generally begins.</span></span>

### <a name="making-focus-clearly-visible"></a><span data-ttu-id="392c8-406">フォーカスの明確な表示</span><span class="sxs-lookup"><span data-stu-id="392c8-406">Making focus clearly visible</span></span>

<span data-ttu-id="392c8-407">ユーザーがフォーカスを探さなくても前回の終了位置を選べるように、1 つのフォーカス表示が常に画面に表示されているようにします。</span><span class="sxs-lookup"><span data-stu-id="392c8-407">One focus visual should always be visible on the screen so that the user can pick up where they left off without searching for the focus.</span></span> <span data-ttu-id="392c8-408">同様に、フォーカス可能な項目を常に画面上に表示する必要があります。たとえば、フォーカス可能な要素がない、テキストのみのポップアップを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="392c8-408">Similarly, there should be a focusable item onscreen at all times&mdash;for example, don't use pop-ups with only text and no focusable elements.</span></span>

<span data-ttu-id="392c8-409">このルールの例外は、ビデオの視聴や画像の表示などの全画面表示エクスペリエンスです。この場合、フォーカス表示を行うことは適切ではありません。</span><span class="sxs-lookup"><span data-stu-id="392c8-409">An exception to this rule would be for full-screen experiences, such as watching videos or viewing images, in which cases it would not be appropriate to show the focus visual.</span></span>

### <a name="reveal-focus"></a><span data-ttu-id="392c8-410">表示フォーカス</span><span class="sxs-lookup"><span data-stu-id="392c8-410">Reveal focus</span></span>

<span data-ttu-id="392c8-411">表示フォーカスは、ユーザーがゲームパッドやキーボードのフォーカスをフォーカス可能な要素 (ボタンなど) に移動したときに、その要素の境界線をアニメーション化する発光効果です。</span><span class="sxs-lookup"><span data-stu-id="392c8-411">Reveal focus is a lighting effect that animates the border of focusable elements, such as a button, when the user moves gamepad or keyboard focus to them.</span></span> <span data-ttu-id="392c8-412">フォーカス対象要素の境界線周囲でグローをアニメーション化すると、表示フォーカスにより、フォーカスの位置とフォーカスの方向を把握しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="392c8-412">By animating the glow around the border of the focused elements, Reveal focus gives users a better understanding of where focus is and where focus is going.</span></span>

<span data-ttu-id="392c8-413">既定では、表示フォーカスは無効になっています。</span><span class="sxs-lookup"><span data-stu-id="392c8-413">Reveal focus is off by default.</span></span> <span data-ttu-id="392c8-414">10 フィート エクスペリエンスの場合、アプリ コンストラクターで [Application.FocusVisualKind プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind) を設定して表示フォーカスにオプトインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-414">For 10 foot experiences you should opt-in to reveal focus by setting the [Application.FocusVisualKind property](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind) in your app constructor.</span></span>

```csharp
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
    {
        this.FocusVisualKind = FocusVisualKind.Reveal;
    }
```

<span data-ttu-id="392c8-415">詳しくは、[表示フォーカス](/windows/uwp/design/style/reveal-focus) のガイダンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-415">For more information see the guidance for [Reveal focus](/windows/uwp/design/style/reveal-focus).</span></span>

### <a name="customizing-the-focus-visual"></a><span data-ttu-id="392c8-416">フォーカスの表示のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="392c8-416">Customizing the focus visual</span></span>

<span data-ttu-id="392c8-417">フォーカス表示をカスタマイズする場合は、各コントロールのフォーカス表示に関連するプロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="392c8-417">If you'd like to customize the focus visual, you can do so by modifying the properties related to the focus visual for each control.</span></span> <span data-ttu-id="392c8-418">アプリのパーソナル設定に活用できるこのようなプロパティはいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="392c8-418">There are several such properties that you can take advantage of to personalize your app.</span></span>

<span data-ttu-id="392c8-419">表示状態を使って独自のフォーカス表示を描画することにより、システムが提供するフォーカス表示を除外することもできます。</span><span class="sxs-lookup"><span data-stu-id="392c8-419">You can even opt out of the system-provided focus visuals by drawing your own using visual states.</span></span> <span data-ttu-id="392c8-420">詳しくは、「[VisualState](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.VisualState)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-420">To learn more, see [VisualState](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.VisualState).</span></span>

### <a name="light-dismiss-overlay"></a><span data-ttu-id="392c8-421">簡易非表示オーバーレイ</span><span class="sxs-lookup"><span data-stu-id="392c8-421">Light dismiss overlay</span></span>

<span data-ttu-id="392c8-422">ユーザーが現在ゲーム コントローラーまたはリモコンで操作している UI 要素にユーザーの注意を引きつけるために、アプリが Xbox One で実行されている場合は、UWP ではポップアップ UI 以外の領域をカバーする「スモーク」レイヤーが自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-422">To call the user's attention to the UI elements that the user is currently manipulating with the game controller or remote control, the UWP automatically adds a "smoke" layer that covers areas outside of the popup UI when the app is running on Xbox One.</span></span> <span data-ttu-id="392c8-423">このための追加作業は必要ありませんが、UI を設計する際に留意してください。</span><span class="sxs-lookup"><span data-stu-id="392c8-423">This requires no extra work, but is something to keep in mind when designing your UI.</span></span> <span data-ttu-id="392c8-424">いずれかの `FlyoutBase` で `LightDismissOverlayMode` プロパティを設定して、スモーク レイヤーを有効または無効にすることができます。既定の設定は `Auto` で、Xbox では有効になり、その他の場所では無効になります。</span><span class="sxs-lookup"><span data-stu-id="392c8-424">You can set the `LightDismissOverlayMode` property on any `FlyoutBase` to enable or disable the smoke layer; it defaults to `Auto`, meaning that it is enabled on Xbox and disabled elsewhere.</span></span> <span data-ttu-id="392c8-425">詳しくは、「[モーダルと簡易非表示](../controls-and-patterns/menus.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="392c8-425">For more information, see [Modal vs light dismiss](../controls-and-patterns/menus.md).</span></span>

## <a name="focus-engagement"></a><span data-ttu-id="392c8-426">フォーカス エンゲージメント</span><span class="sxs-lookup"><span data-stu-id="392c8-426">Focus engagement</span></span>

<span data-ttu-id="392c8-427">フォーカス エンゲージメントは、ゲームパッドやリモコンでアプリを操作しやすくするためのものです。</span><span class="sxs-lookup"><span data-stu-id="392c8-427">Focus engagement is intended to make it easier to use a gamepad or remote to interact with an app.</span></span>

> [!NOTE]
> <span data-ttu-id="392c8-428">フォーカス エンゲージメントを設定しても、キーボードなどの他の入力デバイスには影響しません。</span><span class="sxs-lookup"><span data-stu-id="392c8-428">Setting focus engagement does not impact keyboard or other input devices.</span></span>

<span data-ttu-id="392c8-429">[FrameworkElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.FrameworkElement) オブジェクトのプロパティ `IsFocusEngagementEnabled` を `True` に設定すると、コントロールがフォーカス エンゲージメントを要求するよう設定されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-429">When the property `IsFocusEngagementEnabled` on a [FrameworkElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.FrameworkElement) object is set to `True`, it marks the control as requiring focus engagement.</span></span> <span data-ttu-id="392c8-430">この場合、コントロールを "獲得" して操作するには、ユーザーが **A/[選択]** ボタンをクリックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-430">This means that the user must press the **A/Select** button to "engage" the control and interact with it.</span></span> <span data-ttu-id="392c8-431">終了したら、**B/[戻る]** ボタンをクリックしてコントロールのエンゲージメントを解除すると、コントロールから移動できるようになります。</span><span class="sxs-lookup"><span data-stu-id="392c8-431">When they are finished, they can press the **B/Back** button to disengage the control and navigate out of it.</span></span>

> [!NOTE]
> <span data-ttu-id="392c8-432">`IsFocusEngagementEnabled` は新しい API で、まだ文書化されていません。</span><span class="sxs-lookup"><span data-stu-id="392c8-432">`IsFocusEngagementEnabled` is a new API and not yet documented.</span></span>

### <a name="focus-trapping"></a><span data-ttu-id="392c8-433">フォーカスのトラップ</span><span class="sxs-lookup"><span data-stu-id="392c8-433">Focus trapping</span></span>

<span data-ttu-id="392c8-434">フォーカスのトラップとは、ユーザーがアプリの UI を移動しようとしているときにコントロール内に "捕まる" ことで、そのコントロールの外に移動することが困難または不可能になることです。</span><span class="sxs-lookup"><span data-stu-id="392c8-434">Focus trapping is what happens when a user attempts to navigate an app's UI but becomes "trapped" within a control, making it difficult or even impossible to move outside of that control.</span></span>

<span data-ttu-id="392c8-435">次の例では、フォーカスのトラップが発生する UI を示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-435">The following example shows UI that creates focus trapping.</span></span>

![水平方向のスライダーの左右のボタン](images/designing-for-tv/focus-engagement-focus-trapping.png)

<span data-ttu-id="392c8-437">ユーザーが左のボタンから右のボタンに移動する場合、方向パッド/左スティックの右を 2 回クリックするだけでよいと考えることは論理的です。</span><span class="sxs-lookup"><span data-stu-id="392c8-437">If the user wants to navigate from the left button to the right button, it would be logical to assume that all they'd have to do is press right on the D-pad/left stick twice.</span></span>
<span data-ttu-id="392c8-438">しかし、[Slider](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Slider) がエンゲージメントを必要としない場合、ユーザーが最初に右に押したときにフォーカスは `Slider` に移動し、もう一度右に押したときに `Slider` のハンドルが右に移動します。</span><span class="sxs-lookup"><span data-stu-id="392c8-438">However, if the [Slider](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Slider) doesn't require engagement, the following behavior would occur: when the user presses right the first time, focus would shift to the `Slider`, and when they press right again, the `Slider`'s handle would move to the right.</span></span> <span data-ttu-id="392c8-439">ユーザーはハンドルを右に動かし続けるだけで、ボタンに移ることはできません。</span><span class="sxs-lookup"><span data-stu-id="392c8-439">The user would keep moving the handle to the right and wouldn't be able to get to the button.</span></span>

<span data-ttu-id="392c8-440">この問題を回避する方法はいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="392c8-440">There are several approaches to getting around this issue.</span></span> <span data-ttu-id="392c8-441">その 1 つは、「[XY フォーカス ナビゲーションと操作](#xy-focus-navigation-and-interaction)」の不動産アプリで **[前へ]** ボタンと **[次へ]** ボタンの位置を `ListView` の上に変更する例のように、別のレイアウトを設計することです。</span><span class="sxs-lookup"><span data-stu-id="392c8-441">One is to design a different layout, similar to the real estate app example in [XY focus navigation and interaction](#xy-focus-navigation-and-interaction) where we relocated the **Previous** and **Next** buttons above the `ListView`.</span></span> <span data-ttu-id="392c8-442">次の図のように、水平方向ではなく垂直方向にコントロールを重ねて配置すると、問題が解決します。</span><span class="sxs-lookup"><span data-stu-id="392c8-442">Stacking the controls vertically instead of horizontally as in the following image would solve the problem.</span></span>

![水平方向のスライダーの上下のボタン](images/designing-for-tv/focus-engagement-focus-trapping-2.png)

<span data-ttu-id="392c8-444">これでユーザーは期待どおり、方向パッド/左スティックを上下に押して各コントロールに移動でき、`Slider` にフォーカスがあるときは左右に押して `Slider` ハンドルを動かすことができます。</span><span class="sxs-lookup"><span data-stu-id="392c8-444">Now the user can navigate to each of the controls by pressing up and down on the D-pad/left stick, and when the `Slider` has focus, they can press left and right to move the `Slider` handle, as expected.</span></span>

<span data-ttu-id="392c8-445">この問題を解決するためのもう 1 つの方法は、`Slider` でエンゲージメントを要求することです。</span><span class="sxs-lookup"><span data-stu-id="392c8-445">Another approach to solving this problem is to require engagement on the `Slider`.</span></span> <span data-ttu-id="392c8-446">`IsFocusEngagementEnabled="True"` を設定すると、次の動作が発生します。</span><span class="sxs-lookup"><span data-stu-id="392c8-446">If you set `IsFocusEngagementEnabled="True"`, this will result in the following behavior.</span></span>

![ユーザーが右側のボタンに移動できるように、スライダーでフォーカス エンゲージメントを要求する](images/designing-for-tv/focus-engagement-slider.png)

<span data-ttu-id="392c8-448">`Slider` でフォーカス エンゲージメントを要求すると、ユーザーは方向パッド/左スティックを右に 2 回押すだけで右側のボタンに移動できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-448">When the `Slider` requires focus engagement, the user can get to the button on the right simply by pressing right on the D-pad/left stick twice.</span></span> <span data-ttu-id="392c8-449">この解決策は、UI の調整なしで予期する動作を実現できるので便利です。</span><span class="sxs-lookup"><span data-stu-id="392c8-449">This solution is great because it requires no UI adjustment and produces the expected behavior.</span></span>

### <a name="items-controls"></a><span data-ttu-id="392c8-450">項目コントロール</span><span class="sxs-lookup"><span data-stu-id="392c8-450">Items controls</span></span>

<span data-ttu-id="392c8-451">[Slider](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Slider) コントロール以外にもエンゲージメントを要求できるコントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="392c8-451">Aside from the [Slider](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Slider) control, there are other controls which you may want to require engagement, such as:</span></span>

- [<span data-ttu-id="392c8-452">ListBox</span><span class="sxs-lookup"><span data-stu-id="392c8-452">ListBox</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListBox)
- [<span data-ttu-id="392c8-453">ListView</span><span class="sxs-lookup"><span data-stu-id="392c8-453">ListView</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView)
- [<span data-ttu-id="392c8-454">GridView</span><span class="sxs-lookup"><span data-stu-id="392c8-454">GridView</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.GridView)
- <span data-ttu-id="392c8-455">[FlipView]https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView)</span><span class="sxs-lookup"><span data-stu-id="392c8-455">[FlipView]https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.FlipView)</span></span>

<span data-ttu-id="392c8-456">`Slider` コントロールと異なり、これらのコントロールはフォーカスを捕捉しませんが、大量のデータを含めると操作性の問題が生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-456">Unlike the `Slider` control, these controls don't trap focus within themselves; however, they can cause usability issues when they contain large amounts of data.</span></span> <span data-ttu-id="392c8-457">次の例は、大量のデータが含まれる `ListView` です。</span><span class="sxs-lookup"><span data-stu-id="392c8-457">The following is an example of a `ListView` that contains a large amount of data.</span></span>

![大量のデータと上下のボタンが含まれる ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls.png)

<span data-ttu-id="392c8-459">`Slider` の例と同様に、ゲームパッド/リモコンで上のボタンから下のボタンに移動してみましょう。</span><span class="sxs-lookup"><span data-stu-id="392c8-459">Similar to the `Slider` example, let's try to navigate from the button at the top to the button at the bottom with a gamepad/remote.</span></span>
<span data-ttu-id="392c8-460">上ボタンにフォーカスがある状態で方向パッド/スティックを押すと、`ListView` の最初の項目 ("Item 1") にフォーカスが設定されます。</span><span class="sxs-lookup"><span data-stu-id="392c8-460">Starting with focus on the top button, pressing down on the D-pad/stick will place the focus on the first item in the `ListView` ("Item 1").</span></span>
<span data-ttu-id="392c8-461">ユーザーがもう一度押すと、下にあるボタンではなく、一覧の次の項目がフォーカスを獲得します。</span><span class="sxs-lookup"><span data-stu-id="392c8-461">When the user presses down again, the next item in the list gets focus, not the button on the bottom.</span></span>
<span data-ttu-id="392c8-462">ボタンに移動するには、ユーザーは `ListView` のすべての項目を移動していく必要があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-462">To get to the button, the user must navigate through every item in the `ListView` first.</span></span>
<span data-ttu-id="392c8-463">`ListView` に大量のデータが含まれている場合は、この操作に手間がかかり、最適なユーザー エクスペリエンスになりません。</span><span class="sxs-lookup"><span data-stu-id="392c8-463">If the `ListView` contains a large amount of data, this could be inconvenient and not an optimal user experience.</span></span>

<span data-ttu-id="392c8-464">この問題を解決するには、`ListView` でプロパティ `IsFocusEngagementEnabled="True"` を設定し、エンゲージメントを要求します。</span><span class="sxs-lookup"><span data-stu-id="392c8-464">To solve this problem, set the property `IsFocusEngagementEnabled="True"` on the `ListView` to require engagement on it.</span></span>
<span data-ttu-id="392c8-465">この結果、ユーザーは下に押すだけで `ListView` まで迅速にスキップできます。</span><span class="sxs-lookup"><span data-stu-id="392c8-465">This will allow the user to quickly skip over the `ListView` by simply pressing down.</span></span> <span data-ttu-id="392c8-466">ただし、一覧にエンゲージメントを設定しないと、一覧をスクロールしたり、一覧から項目を選んだりすることはできません。エンゲージメントを設定するには、フォーカスがある状態で **A/[選択]** ボタンを押します。エンゲージメントを解除するには、**B/[戻る]** ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="392c8-466">However, they will not be able to scroll through the list or choose an item from it unless they engage it by pressing the **A/Select** button when it has focus, and then pressing the **B/Back** button to disengage.</span></span>

![エンゲージメントが要求される ListView](images/designing-for-tv/focus-engagement-list-and-grid-controls-2.png)

#### <a name="scrollviewer"></a><span data-ttu-id="392c8-468">ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="392c8-468">ScrollViewer</span></span>

<span data-ttu-id="392c8-469">これらのコントロールと少し異なる点は、[ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer) です。ScrollViewer には、考慮すべき独自の Quirk があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-469">Slightly different from these controls is the [ScrollViewer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer), which has its own quirks to consider.</span></span> <span data-ttu-id="392c8-470">フォーカス可能なコンテンツを含む `ScrollViewer` がある場合、`ScrollViewer` に移動すると既定でフォーカス可能なコンテンツ間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-470">If you have a `ScrollViewer` with focusable content, by default navigating to the `ScrollViewer` will allow you to move through its focusable elements.</span></span> <span data-ttu-id="392c8-471">`ListView` の場合と同様に、`ScrollViewer` 以外の場所に移動するには、各項目をスクロールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-471">Like in a `ListView`, you must scroll through each item to navigate outside of the `ScrollViewer`.</span></span>

<span data-ttu-id="392c8-472">`ScrollViewer` にフォーカス可能なコンテンツが*ない*場合 (テキストのみが含まれる場合など)、ユーザーが **A/[選択]** ボタンを使って `ScrollViewer` にエンゲージメントを設定できるように、`IsFocusEngagementEnabled="True"` を設定できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-472">If the `ScrollViewer` has *no* focusable content&mdash;for example, if it only contains text&mdash;you can set `IsFocusEngagementEnabled="True"` so the user can engage the `ScrollViewer` by using the **A/Select** button.</span></span> <span data-ttu-id="392c8-473">エンゲージメントの設定後、**方向パッド/左スティック**を使ってテキストをスクロールできます。作業が終わったら、**B/[戻る]** ボタンを押してエンゲージメントを解除できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-473">After they have engaged, they can scroll through the text by using the **D-pad/left stick**, and then press the **B/Back** button to disengage when they're finished.</span></span>

<span data-ttu-id="392c8-474">別の方法としては、ユーザーがコントロールにエンゲージメントを設定しなくてすむように `ScrollViewer` で `IsTabStop="True"` を設定します。`ScrollViewer` 内にフォーカス可能な要素がない場合にも、**D パッド/左スティック**を使って、単にフォーカスしてからスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="392c8-474">Another approach would be to set `IsTabStop="True"` on the `ScrollViewer` so that the user doesn't have to engage the control&mdash;they can simply place focus on it and then scroll by using the **D-pad/left stick** when there are no focusable elements within the `ScrollViewer`.</span></span>

### <a name="focus-engagement-defaults"></a><span data-ttu-id="392c8-475">フォーカス エンゲージメントの既定値</span><span class="sxs-lookup"><span data-stu-id="392c8-475">Focus engagement defaults</span></span>

<span data-ttu-id="392c8-476">一部のコントロールでは、フォーカスのトラップがよく発生するため、既定の設定でフォーカス エンゲージメントを要求する方が良い場合があります。また、コントロールによっては既定でフォーカス エンゲージメントが無効になっていますが、有効にする方が良い場合があります。</span><span class="sxs-lookup"><span data-stu-id="392c8-476">Some controls cause focus trapping commonly enough to warrant their default settings to require focus engagement, while others have focus engagement turned off by default but can benefit from turning it on.</span></span> <span data-ttu-id="392c8-477">次の表は、これらのコントロールと、既定のフォーカス エンゲージメントの動作を示します。</span><span class="sxs-lookup"><span data-stu-id="392c8-477">The following table lists these controls and their default focus engagement behaviors.</span></span>

| <span data-ttu-id="392c8-478">コントロール</span><span class="sxs-lookup"><span data-stu-id="392c8-478">Control</span></span>               | <span data-ttu-id="392c8-479">フォーカス エンゲージメントの既定値</span><span class="sxs-lookup"><span data-stu-id="392c8-479">Focus engagement default</span></span>  |
|-----------------------|---------------------------|
| <span data-ttu-id="392c8-480">CalendarDatePicker</span><span class="sxs-lookup"><span data-stu-id="392c8-480">CalendarDatePicker</span></span>    | <span data-ttu-id="392c8-481">オン</span><span class="sxs-lookup"><span data-stu-id="392c8-481">On</span></span>                        |
| <span data-ttu-id="392c8-482">FlipView</span><span class="sxs-lookup"><span data-stu-id="392c8-482">FlipView</span></span>              | <span data-ttu-id="392c8-483">オフ</span><span class="sxs-lookup"><span data-stu-id="392c8-483">Off</span></span>                       |
| <span data-ttu-id="392c8-484">GridView</span><span class="sxs-lookup"><span data-stu-id="392c8-484">GridView</span></span>              | <span data-ttu-id="392c8-485">オフ</span><span class="sxs-lookup"><span data-stu-id="392c8-485">Off</span></span>                       |
| <span data-ttu-id="392c8-486">ListBox</span><span class="sxs-lookup"><span data-stu-id="392c8-486">ListBox</span></span>               | <span data-ttu-id="392c8-487">オフ</span><span class="sxs-lookup"><span data-stu-id="392c8-487">Off</span></span>                       |
| <span data-ttu-id="392c8-488">ListView</span><span class="sxs-lookup"><span data-stu-id="392c8-488">ListView</span></span>              | <span data-ttu-id="392c8-489">オフ</span><span class="sxs-lookup"><span data-stu-id="392c8-489">Off</span></span>                       |
| <span data-ttu-id="392c8-490">ScrollViewer</span><span class="sxs-lookup"><span data-stu-id="392c8-490">ScrollViewer</span></span>          | <span data-ttu-id="392c8-491">オフ</span><span class="sxs-lookup"><span data-stu-id="392c8-491">Off</span></span>                       |
| <span data-ttu-id="392c8-492">SemanticZoom</span><span class="sxs-lookup"><span data-stu-id="392c8-492">SemanticZoom</span></span>          | <span data-ttu-id="392c8-493">オフ</span><span class="sxs-lookup"><span data-stu-id="392c8-493">Off</span></span>                       |
| <span data-ttu-id="392c8-494">スライダー</span><span class="sxs-lookup"><span data-stu-id="392c8-494">Slider</span></span>                | <span data-ttu-id="392c8-495">オン</span><span class="sxs-lookup"><span data-stu-id="392c8-495">On</span></span>                        |

<span data-ttu-id="392c8-496">他のすべての UWP コントロールは、`IsFocusEngagementEnabled="True"` のとき、動作の変更または視覚的な変更はありません。</span><span class="sxs-lookup"><span data-stu-id="392c8-496">All other UWP controls will result in no behavioral or visual changes when `IsFocusEngagementEnabled="True"`.</span></span>

## <a name="summary"></a><span data-ttu-id="392c8-497">概要</span><span class="sxs-lookup"><span data-stu-id="392c8-497">Summary</span></span>

<span data-ttu-id="392c8-498">特定のデバイスやエクスペリエンス、用に最適化された UWP アプリケーションを構築することができます。 が、ユニバーサル Windows プラットフォームでは 2 フィートと 10-foot の両方のエクスペリエンスでは入力に関係なく、デバイス間で正常に使用できるアプリを構築することもできます。デバイスまたはユーザーの権限です。</span><span class="sxs-lookup"><span data-stu-id="392c8-498">You can build UWP applications that are optimized for a specific device or experience, but the Universal Windows Platform also enables you to build apps that can be used successfully across devices, in both 2-foot and 10-foot experiences, and regardless of input device or user ability.</span></span> <span data-ttu-id="392c8-499">この記事では、推奨事項を使用して、アプリが、テレビと PC の両方で可能な限り適切ことを確認できます。</span><span class="sxs-lookup"><span data-stu-id="392c8-499">Using the recommendations in this article can ensure that your app is as good as it can be on both the TV and a PC.</span></span>

## <a name="related-articles"></a><span data-ttu-id="392c8-500">関連記事</span><span class="sxs-lookup"><span data-stu-id="392c8-500">Related articles</span></span>

- [<span data-ttu-id="392c8-501">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="392c8-501">Designing for Xbox and TV</span></span>](../devices/designing-for-tv.md)
- [<span data-ttu-id="392c8-502">ユニバーサル Windows プラットフォーム (UWP) アプリ向けのデバイス入門</span><span class="sxs-lookup"><span data-stu-id="392c8-502">Device primer for Universal Windows Platform (UWP) apps</span></span>](index.md)
