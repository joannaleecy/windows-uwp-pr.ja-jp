---
Description: Design your app so that it looks good and functions well in Mixed Reality.
title: Mixed Reality 向けの設計
ms.assetid: ''
label: Designing for Mixed Reality
template: detail.hbs
isNew: true
keywords: Mixed Reality、Hololens、拡張現実、視線、音声、コントローラー
ms.date: 2/5/2018
ms.topic: article
pm-contact: chigy
design-contact: jeffarn
dev-contact: ''
doc-status: ''
ms.localizationpriority: medium
ms.openlocfilehash: e6aebac45dc32933f55d917c0b1153cba952d819
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8707396"
---
# <a name="designing-for-mixed-reality"></a><span data-ttu-id="1949a-103">Mixed Reality 向けの設計</span><span class="sxs-lookup"><span data-stu-id="1949a-103">Designing for Mixed Reality</span></span>

<span data-ttu-id="1949a-104">Mixed Reality で適切に表示されるようにアプリを設計し、新しい入力方法を活用します。</span><span class="sxs-lookup"><span data-stu-id="1949a-104">Design your app to look good in Mixed Reality, and take advantage of new input methods.</span></span>

## <a name="overview"></a><span data-ttu-id="1949a-105">概要</span><span class="sxs-lookup"><span data-stu-id="1949a-105">Overview</span></span>

<span data-ttu-id="1949a-106">[Mixed Reality](https://developer.microsoft.com/windows/mixed-reality/mixed_reality) は現実世界とデジタル世界を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="1949a-106">[Mixed Reality](https://developer.microsoft.com/windows/mixed-reality/mixed_reality) is the result of blending the physical world with the digital world.</span></span> <span data-ttu-id="1949a-107">Mixed Reality のさまざまなエクスペリエンスには、HoloLens (コンピューターで生成されたコンテンツと現実世界を組み合わせるデバイス) など、1 つの優れたデバイスによるものと、他の Virtual Reality の完全なイマーシブ ビュー (Windows Mixed Reality ヘッドセットに表示される) によるものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="1949a-107">The spectrum of mixed reality experiences includes at one extreme devices such as the HoloLens (a device that mixes computer generated content with the real world), and at the other a completely immersive view of Virtual Reality (as viewed with a Windows Mixed Reality headset).</span></span> <span data-ttu-id="1949a-108">さまざまなエクスペリエンスの例については、「[Mixed Reality アプリの種類](https://developer.microsoft.com/en-us/windows/mixed-reality/types_of_mixed_reality_apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-108">See [Types of mixed reality apps](https://developer.microsoft.com/en-us/windows/mixed-reality/types_of_mixed_reality_apps) for examples of how experiences will vary.</span></span>

<span data-ttu-id="1949a-109">このトピックのいくつかのガイダンスを実行してユーザー エクスペリエンスを改善しますが、既存のほぼすべての UWP アプリは、変更しなくても Mixed Reality 環境で 2D アプリとして実行されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-109">Almost all existing UWP apps will run in the Mixed Reality environment as 2D apps with no changes, although the experience for the user can be improved by following some of the guidance in this topic.</span></span>

![Mixed Reality ビュー](images/MR-01.png)

<span data-ttu-id="1949a-111">HoloLens と Windows Mixed Reality ヘッドセットの両方が UWP プラットフォーム上で実行されるアプリケーションをサポートし、両方とも 2 つの異なる種類のエクスペリエンスをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1949a-111">Both the HoloLens and Windows Mixed Reality headsets support applications running on the UWP platform, and both support two distinct types of experience.</span></span> 

### <a name="2d-vs-immersive-experience"></a><span data-ttu-id="1949a-112">2D とイマーシブ エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="1949a-112">2D vs. Immersive Experience</span></span>

<span data-ttu-id="1949a-113">イマーシブ アプリはユーザーに表示される画面全体を制御し、アプリによって作成されるビューの中央にユーザーが配置されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-113">An immersive app takes over the entire display visible to the user, placing her at the center of a view created by the app.</span></span> <span data-ttu-id="1949a-114">たとえば、イマーシブなゲームでは、エイリアンの惑星の地表にユーザーが配置されたり、ツアー ガイド アプリでは、南米の村にユーザーが配置されることもあります。</span><span class="sxs-lookup"><span data-stu-id="1949a-114">For example, an immersive game might place the user on the surface of an alien planet, or a tour guide app might place the user in a South American village.</span></span> <span data-ttu-id="1949a-115">イマーシブ アプリを作成するには、3 D グラフィックスまたはキャプチャした立体映像が必要です。</span><span class="sxs-lookup"><span data-stu-id="1949a-115">Creating an immersive app requires 3D graphics or captured stereographic video.</span></span> <span data-ttu-id="1949a-116">多くの場合、Unity や DirectX など、サード パーティのゲーム エンジンを使用してイマーシブ アプリを開発します。</span><span class="sxs-lookup"><span data-stu-id="1949a-116">Immersive apps are often developed using a 3rd party game engine such as Unity, or with DirectX.</span></span>

<span data-ttu-id="1949a-117">イマーシブ アプリを作成する場合、詳細については、[Windows Mixed Reality デベロッパー センター](https://developer.microsoft.com/windows/mixed-reality) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1949a-117">If you are creating immersive apps, you should visit the [Windows Mixed Reality Dev Center](https://developer.microsoft.com/windows/mixed-reality) for more information.</span></span>

<span data-ttu-id="1949a-118">2D アプリは、ユーザーのビュー内で従来のフラット ウィンドウとして実行します。</span><span class="sxs-lookup"><span data-stu-id="1949a-118">A 2D app runs as a traditional flat window within the user's view.</span></span> <span data-ttu-id="1949a-119">HoloLens では、ユーザー独自の現実世界でリビング ルームやオフィスの空間内にある壁またはポイントに固定されたビューを指します。</span><span class="sxs-lookup"><span data-stu-id="1949a-119">On the HoloLens, that means a view pinned to the wall or a point in space in the users own real-world living room or office.</span></span> <span data-ttu-id="1949a-120">Windows Mixed Reality ヘッドセットで、アプリは [Mixed Reality ホーム](https://docs.microsoft.com/windows/mixed-reality/enthusiast-guide/your-mixed-reality-home) (*クリフ ハウス*とも呼ばれる) の壁に固定されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-120">In a Windows Mixed Reality headset, the app is pinned to a wall in the [mixed reality home](https://docs.microsoft.com/windows/mixed-reality/enthusiast-guide/your-mixed-reality-home) (sometimes called the *Cliff House*).</span></span>

![Mixed Reality で実行される複数のアプリ](images/MR-multiple.png)


<span data-ttu-id="1949a-122">これらの 2D アプリはビュー全体を制御するのではなく、ビュー内に配置されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-122">These 2D apps do not take over the entire view: they are placed within it.</span></span> <span data-ttu-id="1949a-123">環境内には一度に複数の 2D アプリが存在することができます。</span><span class="sxs-lookup"><span data-stu-id="1949a-123">Multiple 2D apps can exist in the environment at once.</span></span>

<span data-ttu-id="1949a-124">このトピックの残りの部分では、2D エクスペリエンスの設計に関する考慮事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="1949a-124">The remainder of this topic discusses design considerations for the 2D experience.</span></span>

## <a name="launching-2d-apps"></a><span data-ttu-id="1949a-125">2D アプリの起動</span><span class="sxs-lookup"><span data-stu-id="1949a-125">Launching 2D apps</span></span>

![Mixed Reality の [スタート] メニュー](images/MR-start-options.png)

<span data-ttu-id="1949a-127">すべてのアプリは [スタート] メニューから起動しますが、アプリの起動ツールとして動作する 3D オブジェクトを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="1949a-127">All apps are launched from the Start Menu, but it's also possible to create a 3D object to act as an app launcher.</span></span> <span data-ttu-id="1949a-128">詳しくは、[このビデオ](https://www.youtube.com/watch?v=TxIslHsEXno) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-128">See [this video](https://www.youtube.com/watch?v=TxIslHsEXno) for details.</span></span>

## <a name="the-2d-app-input-overview"></a><span data-ttu-id="1949a-129">2D アプリの入力概要</span><span class="sxs-lookup"><span data-stu-id="1949a-129">The 2D App Input Overview</span></span>

<span data-ttu-id="1949a-130">HoloLens と Mixed Reality の両方のプラットフォームでは、キーボードおよびマウスがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="1949a-130">Keyboards and mice are supported on both HoloLens and Mixed Reality platforms.</span></span> <span data-ttu-id="1949a-131">Bluetooth を介してキーボードおよびマウスを HoloLens と直接ペアリングすることができます。</span><span class="sxs-lookup"><span data-stu-id="1949a-131">You can pair a keyboard and mouse directly with the HoloLens over Bluetooth.</span></span> <span data-ttu-id="1949a-132">Mixed Reality アプリは、ホスト コンピューターに接続されたマウスとキーボードをサポートします。</span><span class="sxs-lookup"><span data-stu-id="1949a-132">Mixed Reality apps support the mouse and keyboard connected to the host computer.</span></span> <span data-ttu-id="1949a-133">両方とも微調整が必要な場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="1949a-133">Both may be useful in situations when a fine-level of control is necessary.</span></span>

<span data-ttu-id="1949a-134">また、他の一般的な入力方法もサポートされています。ユーザーがオフィスにいない場合や微調整が必要な場合などに特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="1949a-134">Other, more natural, input methods are also supported, and these may be particularly useful when the user isn't sitting at a desk with a real keyboard in front of them, or when fine control is needed.</span></span>

<span data-ttu-id="1949a-135">ハードウェアまたはコーディングを追加しなくても、2D アプリの使用時のマウス ポインターとして、視線、つまりユーザーが見ているベクトルを使用します。</span><span class="sxs-lookup"><span data-stu-id="1949a-135">Without any extra hardware or coding, apps will use gaze - the vector your user is looking along - as a mouse pointer when working with 2D apps.</span></span> <span data-ttu-id="1949a-136">仮想シーン内のものにマウス ポインターを合わせているかのように実装されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-136">It is implemented as if a mouse pointer was hovering over something in the virtual scene.</span></span>

<span data-ttu-id="1949a-137">一般的な操作では、ユーザーがアプリのコントロールを見ると、このコントロールは強調されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-137">In a typical interaction, your user will look at a control in your app, causing it to highlight.</span></span> <span data-ttu-id="1949a-138">ユーザーは、ジェスチャ (HoloLens 上) またはコントローラーや音声コマンドを使用して動作をトリガーするタイミングを指定します。</span><span class="sxs-lookup"><span data-stu-id="1949a-138">The user will when trigger an action, using either a gesture (on the HoloLens), or a contoller or by giving a voice command.</span></span> <span data-ttu-id="1949a-139">ユーザーがテキスト入力フィールドを選択すると、ソフトウェア キーボードが表示されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-139">If the user selects a text input field, the software keyboard will appear.</span></span> 


![Mixed Reality のポップアップ キーボード](images/MR-keyboard.png)

<span data-ttu-id="1949a-141">重要なことは、UWP プラットフォーム上で実行することで、自分でコーディングを追加しなくても、これらすべての操作が自動的に行われる点です。</span><span class="sxs-lookup"><span data-stu-id="1949a-141">It's important to note that all these interactions will happen automatically with no extra coding on your part, as a consequence of running on the UWP platform.</span></span> <span data-ttu-id="1949a-142">HoloLens と Mixed Reality ヘッドセットからの入力は、タッチ入力として 2D アプリに表示されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-142">Input from the HoloLens and Mixed Reality headset will appear as touch input to the 2D app.</span></span> <span data-ttu-id="1949a-143">つまり、既定では、多くの UWP アプリを実行し、Mixed Reality で使用することができます。</span><span class="sxs-lookup"><span data-stu-id="1949a-143">This means that many UWP apps will run and be usable in Mixed Reality, by default.</span></span> 

<span data-ttu-id="1949a-144">ただし、作業を少し追加すると、エクスペリエンスを大幅に向上できます。</span><span class="sxs-lookup"><span data-stu-id="1949a-144">That said, with some extra work, the experience can be improved greatly.</span></span> <span data-ttu-id="1949a-145">たとえば、[音声コントロール](https://developer.microsoft.com/windows/mixed-reality/voice_design)は特に有効です。</span><span class="sxs-lookup"><span data-stu-id="1949a-145">For example, [voice control](https://developer.microsoft.com/windows/mixed-reality/voice_design) can be especially effective.</span></span> <span data-ttu-id="1949a-146">HoloLens と Mixed Reality の両方の環境でアプリの起動と操作の音声コマンドがサポートされており、音声サポートなどはこの方法の一般的な拡張機能として表示されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-146">Both HoloLens and Mixed Reality environments support voice commands for launching and interacting with apps, and including voice support will appear as a natural extension of this approach.</span></span> <span data-ttu-id="1949a-147">音声サポートを UWP アプリに追加する際の詳細については、「[音声操作]( https://docs.microsoft.com/windows/uwp/design/input/speech-interactions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-147">See [Speech interactions]( https://docs.microsoft.com/windows/uwp/design/input/speech-interactions) for more information on adding voice support to your UWP app.</span></span> 


### <a name="selecting-the-right-controller"></a><span data-ttu-id="1949a-148">適切なコントローラーの選択</span><span class="sxs-lookup"><span data-stu-id="1949a-148">Selecting the right controller</span></span>

![Mixed Reality モーション コントローラー](images/MR-controllers.png)

<span data-ttu-id="1949a-150">Mixed Reality 専用のいくつかの新しい入力方法が設計されました。</span><span class="sxs-lookup"><span data-stu-id="1949a-150">Several novel input methods have been designed especially for use with Mixed Reality, specifically:</span></span>

* <span data-ttu-id="1949a-151">[ハンド ジェスチャ](https://developer.microsoft.com/windows/mixed-reality/gestures) (HoloLens のみ、2D アプリの起動専用)</span><span class="sxs-lookup"><span data-stu-id="1949a-151">[Hand gestures](https://developer.microsoft.com/windows/mixed-reality/gestures) (HoloLens only, but only used for launching 2D apps)</span></span>
* <span data-ttu-id="1949a-152">[ゲームパッド サポート](https://developer.microsoft.com/windows/mixed-reality/hardware_accessories) (両方の環境)</span><span class="sxs-lookup"><span data-stu-id="1949a-152">[Gamepad support](https://developer.microsoft.com/windows/mixed-reality/hardware_accessories) (both environments)</span></span>
* <span data-ttu-id="1949a-153">[クリッカー デバイス](https://developer.microsoft.com/windows/mixed-reality/hardware_accessories) (HoloLens のみ)</span><span class="sxs-lookup"><span data-stu-id="1949a-153">[Clicker device](https://developer.microsoft.com/windows/mixed-reality/hardware_accessories) (HoloLens only)</span></span>
* <span data-ttu-id="1949a-154">[モーション コントローラー](https://developer.microsoft.com/windows/mixed-reality/motion_controllers) (Mixed Reality デバイスのみ、上述のとおり)</span><span class="sxs-lookup"><span data-stu-id="1949a-154">[Motion Controllers](https://developer.microsoft.com/windows/mixed-reality/motion_controllers) (Mixed Reality devices only, shown above.)</span></span>

<span data-ttu-id="1949a-155">これらのコントローラーにより、仮想オブジェクトの操作が自然かつ正確になります。</span><span class="sxs-lookup"><span data-stu-id="1949a-155">These controllers make interacting with virtual objects seem natural and precise.</span></span> <span data-ttu-id="1949a-156">いくつかの操作は無料で利用できます。</span><span class="sxs-lookup"><span data-stu-id="1949a-156">Some of the interactions you get for free.</span></span> <span data-ttu-id="1949a-157">たとえば、HoloLens の選択ジェスチャまたはモーション コント ローラーの Windows キーやトリガーをクリックすると、入力の応答は、予想される、ここでも、ユーザー側でコーディングしなくてが生成されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-157">For example, the HoloLens select gesture or clicking on the Motion Controller's Windows key or trigger will generate the input response you would expect, again, with no coding on your part.</span></span>

<span data-ttu-id="1949a-158">それ以外の場合は、追加情報と利用可能な入力情報を活用するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="1949a-158">At other times, you will want to add code to take advantage of the extra information and inputs that are made available.</span></span> <span data-ttu-id="1949a-159">たとえば、位置とボタン操作を考慮するコードを作成する場合、モーション コントローラーを使用すると、オブジェクトを細かく操作できます。</span><span class="sxs-lookup"><span data-stu-id="1949a-159">For example, the Motion Controllers can be used to manipulate objects with a fine level of control, if you write code that takes their position and button presses into account.</span></span>

> [!NOTE]
> <span data-ttu-id="1949a-160">要約: 基本理念では、常にできるだけ自然でスムーズな入力方法をユーザーに提供するようにしています。</span><span class="sxs-lookup"><span data-stu-id="1949a-160">In summary: the guiding principal should be to always provide the user with as natural and frictionless an input method as possible.</span></span>


## <a name="2d-app-design-considerations-functionality"></a><span data-ttu-id="1949a-161">2D アプリ設計の考慮事項: 機能</span><span class="sxs-lookup"><span data-stu-id="1949a-161">2D App Design considerations: Functionality</span></span>

<span data-ttu-id="1949a-162">Mixed Reality プラットフォームで使用する可能性がある UWP アプリを作成する場合は、次の点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="1949a-162">When creating a UWP app that will potentially be used on a Mixed Reality platform, there are several things to keep in mind.</span></span>

* <span data-ttu-id="1949a-163">モーション コントローラー、ゲームパッド、またはジェスチャを使用すると、ドラッグ アンド ドロップが適切に動作しない場合があります。</span><span class="sxs-lookup"><span data-stu-id="1949a-163">Drag and drop may not work well when used with Motion Controllers, gamepads or gestures.</span></span> <span data-ttu-id="1949a-164">ドラッグ アンド ドロップを頻繁に使用するアプリケーションの場合は、オブジェクトを新しい場所に移動するかどうかを確認するダイアログを表示するなど、この操作をサポートする代替方法を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1949a-164">If your application depends heavily on drag and drop, you will need to provide an alternative method of supporting this action, such as presenting a dialog confirming if objects to be moved to a new location.</span></span>

* <span data-ttu-id="1949a-165">音の変化に注意してください。</span><span class="sxs-lookup"><span data-stu-id="1949a-165">Be aware how sound changes.</span></span> <span data-ttu-id="1949a-166">アプリでサウンド エフェクトを生成する場合、音源はアプリの仮想世界で固定された場所に表示されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-166">If your app generates sound effects, the source of the sound will appear to be your app's pinned location in the virtual world.</span></span> <span data-ttu-id="1949a-167">ユーザーがアプリから離れると、音が消えます。</span><span class="sxs-lookup"><span data-stu-id="1949a-167">As the user moves away from the app, sound will diminish.</span></span> <span data-ttu-id="1949a-168">詳しくは、「[立体音響](https://developer.microsoft.com/windows/mixed-reality/spatial_sound)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-168">See [Spatial sound](https://developer.microsoft.com/windows/mixed-reality/spatial_sound) for more information.</span></span>

* <span data-ttu-id="1949a-169">視野を考慮して、アフォーダンスを用意します。</span><span class="sxs-lookup"><span data-stu-id="1949a-169">Consider the field of view and provide affordances.</span></span> <span data-ttu-id="1949a-170">すべてのデバイスでコンピューター モニターと同じ大きさの視野が用意されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="1949a-170">Not every device will provide as large a field of view as a computer monitor.</span></span> <span data-ttu-id="1949a-171">詳しくは、「[ホログラフィック フレーム](https://developer.microsoft.com/windows/mixed-reality/holographic_frame)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-171">See [Holographic frame](https://developer.microsoft.com/windows/mixed-reality/holographic_frame) for complete details.</span></span> <span data-ttu-id="1949a-172">さらに、ユーザーが実行中のアプリから離れている場合があります。</span><span class="sxs-lookup"><span data-stu-id="1949a-172">Furthermore, the user may be some distance away from a running app.</span></span> <span data-ttu-id="1949a-173">つまり、アプリが現実世界または仮想世界の異なる場所にある壁に固定されている場合があります。</span><span class="sxs-lookup"><span data-stu-id="1949a-173">That is, the app may appear pinned to the wall at a different location in the world (real or virtual).</span></span> <span data-ttu-id="1949a-174">ユーザーの注意を引く必要があったり、ビューが常に表示されていないことを考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1949a-174">Your app may need to get the users attention, or take into account that the entire view is not visible at all times.</span></span> <span data-ttu-id="1949a-175">トースト通知は使用できますが、音または[音声](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/SpeechRecognitionAndSynthesis/cs/Scenario_SynthesizeText.xaml.cs) アラートを使用してユーザーの注意を引く別の方法もあります。</span><span class="sxs-lookup"><span data-stu-id="1949a-175">Toast notifications are available, but another way to get the user's attention might be to generate a sound or [speech](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/SpeechRecognitionAndSynthesis/cs/Scenario_SynthesizeText.xaml.cs) alert.</span></span>

* <span data-ttu-id="1949a-176">2D アプリには[アプリ バー](https://developer.microsoft.com/windows/mixed-reality/app_bar_and_bounding_box) が自動的に用意されるため、ユーザーは仮想環境で移動および拡大縮小を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="1949a-176">A 2D app is automatically given an [app bar](https://developer.microsoft.com/windows/mixed-reality/app_bar_and_bounding_box)  to allow the user to move and scale them in the virtual environment.</span></span> <span data-ttu-id="1949a-177">ビューは、垂直方向にサイズ変更したり、同じ縦横比を維持するようにサイズ変更できます。</span><span class="sxs-lookup"><span data-stu-id="1949a-177">The views can be resized vertically, or resized maintaining the same aspect ratio.</span></span>


## <a name="2d-app-design-considerations-uiux"></a><span data-ttu-id="1949a-178">2D アプリ設計の考慮事項: UI/UX</span><span class="sxs-lookup"><span data-stu-id="1949a-178">2D app design considerations: UI/UX</span></span>

* <span data-ttu-id="1949a-179">[ナビゲーション ビュー](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/navigationview) などの[Fluent Design System](https://docs.microsoft.com/windows/uwp/design/fluent-design-system/) を実装する XAML コントロールと [アクリル](https://docs.microsoft.com/windows/uwp/design/style/acrylic) などのエフェクトはすべて、2D Mixed Reality アプリに特化して適切に動作します。</span><span class="sxs-lookup"><span data-stu-id="1949a-179">XAML controls which implement the [Fluent Design System](https://docs.microsoft.com/windows/uwp/design/fluent-design-system/) such as the [Navigation view](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/navigationview), and effects such as [Acrylic](https://docs.microsoft.com/windows/uwp/design/style/acrylic) all work especially well in 2D Mixed Reality apps.</span></span>

* <span data-ttu-id="1949a-180">Mixed Reality デバイス、または少なくとも Mixed Reality シミュレーターでアプリのテキストとウィンドウのサイズをテストします。</span><span class="sxs-lookup"><span data-stu-id="1949a-180">Test your app's text and windows size in a Mixed Reality device, or at the very least in the Mixed Reality Simulator.</span></span> <span data-ttu-id="1949a-181">アプリの既定のウィンドウ サイズは 853 x 480 有効ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="1949a-181">Your app will have a default windows size of 853x480 effective pixels.</span></span> <span data-ttu-id="1949a-182">フォント サイズを大きくし (推奨ポイント サイズは約 32)、「[Hololens 用の既存のユニバーサル アプリを更新する](https://developer.microsoft.com/windows/mixed-reality/updating_your_existing_universal_app_for_hololens)」を確認します。</span><span class="sxs-lookup"><span data-stu-id="1949a-182">Use larger font sizes (a point size of approximately 32 is recommended), and read [Updating your existing universal app for Hololens](https://developer.microsoft.com/windows/mixed-reality/updating_your_existing_universal_app_for_hololens).</span></span> <span data-ttu-id="1949a-183">記事「[文字体裁](https://developer.microsoft.com/windows/mixed-reality/typography)」では、このトピックの詳細について説明しています。</span><span class="sxs-lookup"><span data-stu-id="1949a-183">The article [Typography](https://developer.microsoft.com/windows/mixed-reality/typography) covers this topic in detail.</span></span> <span data-ttu-id="1949a-184">Visual Studio で作業する場合は、57 インチ HoloLens 2D アプリ用に設定された XAML 設計エディターがあるため、正しいスケールと寸法のビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="1949a-184">When working in Visual Studio, there is a XAML design editor setting for a 57" HoloLens 2D App which provides a view with the correct scale and dimensions.</span></span> 

![Mixed Reality アプリに表示されるテキストは大きくなります。](images/MR-text.png)

* <span data-ttu-id="1949a-186">[視線がマウスになります](https://developer.microsoft.com/windows/mixed-reality/gaze_targeting)。</span><span class="sxs-lookup"><span data-stu-id="1949a-186">[Your gaze is your mouse](https://developer.microsoft.com/windows/mixed-reality/gaze_targeting).</span></span> <span data-ttu-id="1949a-187">ユーザーが何かを見ると、**タッチ ホバー** イベントとして動作するため、オブジェクトを見るだけで、不要なホップアップが表示されたり、他の不要な操作が実行される場合があります。</span><span class="sxs-lookup"><span data-stu-id="1949a-187">When the user looks at something, it acts as a **touch hover** event, so simply looking at an object may trigger an inadvertent pop-up or other unwanted interaction.</span></span> <span data-ttu-id="1949a-188">アプリが Mixed Reality で現在実行されているかどうかを検出し、この動作の変更が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="1949a-188">You may need to detect if the app is currently running in Mixed Reality and change this behavior.</span></span> <span data-ttu-id="1949a-189">下記の「**ランタイム サポート**」のご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-189">See **Runtime support**, below.</span></span> 

* <span data-ttu-id="1949a-190">ユーザーがモーション コントローラーを使用してどこかの方向やポイントを見ると、**タッチ ホバー** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="1949a-190">When a user gazes towards something or points with a motion controller, a **touch hover** event will occur.</span></span> <span data-ttu-id="1949a-191">これは [**PointerPoint**] で構成されます。この場合、[**PointerType**] は [**Touch**]、[**IsInContact**] は [**false**] です。</span><span class="sxs-lookup"><span data-stu-id="1949a-191">This consists of a **PointerPoint** where **PointerType** is **Touch**, but **IsInContact** is **false**.</span></span> <span data-ttu-id="1949a-192">何かが確定すると (たとえば、ゲームパッドの A ボタンが押された場合、クリッカー デバイスが押された場合、モーション コントローラーのトリガーが押された場合、または音声認識で [選択] を選んだ場合)、[**PointerPoint**] の [**IsInContact**] が [**true**] となり、**タッチ プレス**が発生します。</span><span class="sxs-lookup"><span data-stu-id="1949a-192">When some form of commit occurs (for example, gamepad A button is pressed, a clicker device is pressed, a motion controller trigger pressed, or voice recognition heads "Select"), a **touch press** occurs, with the **PointerPoint** having **IsInContact** become **true**.</span></span> <span data-ttu-id="1949a-193">入力イベントの詳細については、「[タッチ操作](https://docs.microsoft.com/windows/uwp/design/input/touch-interactions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-193">See [Touch interactions](https://docs.microsoft.com/windows/uwp/design/input/touch-interactions) for more information on these input events.</span></span>

* <span data-ttu-id="1949a-194">視線はマウス ポインターほど正確でありません。</span><span class="sxs-lookup"><span data-stu-id="1949a-194">Remember, gaze is not as accurate as mouse pointing.</span></span> <span data-ttu-id="1949a-195">マウス ターゲットまたはボタンが小さくなるほど、ユーザーには不便になるため、コントロールのサイズを適切に変更します。</span><span class="sxs-lookup"><span data-stu-id="1949a-195">Smaller mouse targets or buttons may cause frustration for your users, so resize controls accordingly.</span></span> <span data-ttu-id="1949a-196">タッチ操作用に設計した場合は、Mixed Reality で動作しますが、実行時にいくつかのボタンを大きくすることもあります。</span><span class="sxs-lookup"><span data-stu-id="1949a-196">If they are designed for touch, they will work in Mixed Reality, but you may decide to enlarge some buttons at runtime.</span></span> <span data-ttu-id="1949a-197">「[Hololens 用の既存のユニバーサル アプリを更新する](https://developer.microsoft.com/windows/mixed-reality/updating_your_existing_universal_app_for_hololens)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1949a-197">See [Updating your existing universal app for Hololens](https://developer.microsoft.com/windows/mixed-reality/updating_your_existing_universal_app_for_hololens).</span></span>

* <span data-ttu-id="1949a-198">HoloLens では、光の有無を黒色で定義します。</span><span class="sxs-lookup"><span data-stu-id="1949a-198">The HoloLens defines the color black as the absence of light.</span></span> <span data-ttu-id="1949a-199">これはレンダリングされないだけでなく、「現実世界」では透けて見えます。</span><span class="sxs-lookup"><span data-stu-id="1949a-199">It's simply not rendered, allowing the "real world" so show through.</span></span> <span data-ttu-id="1949a-200">このことが混乱を招く場合は、アプリケーションで黒色を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="1949a-200">Your application should not use black if this is would cause confusion.</span></span> <span data-ttu-id="1949a-201">Mixed Reality ヘッドセットでは、黒色は黒色を指します。</span><span class="sxs-lookup"><span data-stu-id="1949a-201">In a Mixed Reality headset, black is black.</span></span>

* <span data-ttu-id="1949a-202">HoloLens はアプリのカラー テーマをサポートしていないため、ユーザーに最適なエクスペリエンスを実現できるように既定値は青色に設定されています。</span><span class="sxs-lookup"><span data-stu-id="1949a-202">The HoloLens does not support color themes in apps, and defaults to blue to ensure the best experience for users.</span></span> <span data-ttu-id="1949a-203">色の選択の詳細については、[このトピック](https://developer.microsoft.com/windows/mixed-reality/color,_light_and_materials) を参照してください。ここでは、Mixed Reality 設計での色とマテリアルの使用方法について説明しています。</span><span class="sxs-lookup"><span data-stu-id="1949a-203">For more advice about selecting colors, you should consult [this topic](https://developer.microsoft.com/windows/mixed-reality/color,_light_and_materials) which discusses the use of color and material in Mixed Reality designs.</span></span>


## <a name="other-points-to-consider"></a><span data-ttu-id="1949a-204">他に考慮する点</span><span class="sxs-lookup"><span data-stu-id="1949a-204">Other points to consider</span></span>

* <span data-ttu-id="1949a-205">[デスクトップ ブリッジ](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root) により、既存の (Win32) デスクトップ アプリを Windows 10 および Microsoft Store に移植できますが、現時点で HoloLens または Mixed Reality で実行できるアプリを作成することはできません。</span><span class="sxs-lookup"><span data-stu-id="1949a-205">Although the [Desktop Bridge](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root) can help bring existing (Win32) desktop apps to Windows 10 and the Microsoft Store, it cannot create apps that run on HoloLens or in Mixed Reality at this time.</span></span>




## <a name="runtime-support"></a><span data-ttu-id="1949a-206">ランタイム サポート</span><span class="sxs-lookup"><span data-stu-id="1949a-206">Runtime support</span></span>

<span data-ttu-id="1949a-207">実行時に Mixed Reality デバイスで実行するかどうかを判断したり、コントロールのサイズを変更し、ヘッドセットで使用するアプリを他の方法で最適化する機会としてこのアプリを使用したりできます。</span><span class="sxs-lookup"><span data-stu-id="1949a-207">It is possible for your app to determine if it is running on a Mixed Reality device at runtime, and use this as an opportunity to resize controls or in other ways optimize the app for use on a headset.</span></span>

<span data-ttu-id="1949a-208">次に、アプリを Mixed Reality デバイスで使用している場合にのみ、XAML の TextBlock コントロール内のテキストのサイズを変更するコードを示します。</span><span class="sxs-lookup"><span data-stu-id="1949a-208">Here's a short piece of code that resizes the text inside a XAML TextBlock control only if the app is being used on a Mixed Reality device.</span></span>

```csharp

bool isViewingInMR = Windows.ApplicationModel.Preview.Holographic.HolographicApplicationPreview.IsCurrentViewPresentedOnHolographicDisplay();

            if (isViewingInMR)
            {
                // Running on headset, resize the XAML text
                textBlock.Text = "I'm running in Mixed Reality!";
                textBlock.FontSize = 32;
            }
            else
            {
                // Running on desktop
                textBlock.Text = "I'm running on the desktop.";
                textBlock.FontSize = 16;
            }

```





## <a name="related-articles"></a><span data-ttu-id="1949a-209">関連記事</span><span class="sxs-lookup"><span data-stu-id="1949a-209">Related articles</span></span>


* [<span data-ttu-id="1949a-210">シェルから API を使用するアプリの現在の制限事項</span><span class="sxs-lookup"><span data-stu-id="1949a-210">Current limitations for apps using APIs from the shell</span></span>](https://developer.microsoft.com/windows/mixed-reality/current_limitations_for_apps_using_apis_from_the_shell)
* [<span data-ttu-id="1949a-211">2D アプリのビルド</span><span class="sxs-lookup"><span data-stu-id="1949a-211">Building 2D apps</span></span>](https://developer.microsoft.com/windows/mixed-reality/building_2d_apps)
* [<span data-ttu-id="1949a-212">HoloLens: Microsoft HoloLens 用の UWP 2D アプリのビルド</span><span class="sxs-lookup"><span data-stu-id="1949a-212">HoloLens: Building UWP 2D Apps for Microsoft HoloLens</span></span>](https://channel9.msdn.com/Events/Build/2016/B854)
* [<span data-ttu-id="1949a-213">条件付き XAML</span><span class="sxs-lookup"><span data-stu-id="1949a-213">Conditional XAML</span></span>](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/conditional-xaml)


