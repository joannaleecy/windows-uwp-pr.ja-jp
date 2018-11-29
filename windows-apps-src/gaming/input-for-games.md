---
title: ゲームの入力
description: このセクションでは、ユニバーサル Windows プラットフォーム (UWP) ゲームのゲームパッドなどの入力デバイスを操作する方法を示します。
ms.assetid: 2DD0B384-8776-4599-9E52-4FC0AA682735
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力
ms.localizationpriority: medium
ms.openlocfilehash: 1f1daac8bc94d49c501307728c1e966ba89435f9
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7985080"
---
# <a name="input-for-games"></a><span data-ttu-id="966cb-104">ゲームの入力</span><span class="sxs-lookup"><span data-stu-id="966cb-104">Input for games</span></span>

<span data-ttu-id="966cb-105">このセクションでは、Windows 10 と Xbox One のユニバーサル Windows プラットフォーム (UWP) ゲームで使用可能なさまざまな種類の入力デバイスについて説明し、その基本的な使用方法を示して、ゲームで効果的な入力プログラミングについて推奨するパターンと手法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="966cb-105">This section describes the different kinds of input devices that can be used in Universal Windows Platform (UWP) games on Windows 10 and Xbox One, demonstrates their basic usage, and recommends patterns and techniques for effective input programming in games.</span></span>

> <span data-ttu-id="966cb-106">**注意**    UWP ゲームに使用できる入力デバイスには、ジャンル固有またはゲーム固有のカスタム入力デバイスなど、他の種類のデバイスもあります。</span><span class="sxs-lookup"><span data-stu-id="966cb-106">**Note**    Other kinds of input devices exist and are available to be used in UWP games such as custom input devices that might be genre-specific or game-specific.</span></span> <span data-ttu-id="966cb-107">そのようなデバイスとそのプログラミングについては、このセクションでは説明しません。</span><span class="sxs-lookup"><span data-stu-id="966cb-107">Such devices and their programming are not discussed in this section.</span></span> <span data-ttu-id="966cb-108">カスタム入力デバイスを使いやすくするインターフェイスnについて詳しくは、[Windows.Gaming.Input.Custom](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom) 名前空間をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="966cb-108">For information on the interfaces used to facilitate custom input devices, see the [Windows.Gaming.Input.Custom](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom) namespace.</span></span>

## <a name="gaming-input-devices"></a><span data-ttu-id="966cb-109">ゲーム入力デバイス</span><span class="sxs-lookup"><span data-stu-id="966cb-109">Gaming input devices</span></span>

<span data-ttu-id="966cb-110">Windows 10 と Xbox One の UWP ゲームおよび UWP アプリ でのゲーム入力デバイスは、[Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="966cb-110">Game input devices are supported in UWP games and apps for Windows 10 and Xbox One by the [Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) namespace.</span></span>

### <a name="gamepads"></a><span data-ttu-id="966cb-111">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="966cb-111">Gamepads</span></span>

<span data-ttu-id="966cb-112">ゲームパッドは Xbox One の標準入力デバイスです。一般的に、キーボードやマウスを好まない Windows のゲーマーが選びます。</span><span class="sxs-lookup"><span data-stu-id="966cb-112">Gamepads are the standard input device on Xbox One and a common choice for Windows gamers when they don't favor a keyboard and mouse.</span></span> <span data-ttu-id="966cb-113">ゲームパッドでは、デジタルとアナログのさまざまなコントロールを用意して、ほとんどの種類のゲームに適合させています。また、埋め込みバイブレーション モーターを使って触覚的なフィードバックも提供しています。</span><span class="sxs-lookup"><span data-stu-id="966cb-113">They provide a variety of digital and analog controls making them suitable for almost any kind of game and also provide tactile feedback through embedded vibration motors.</span></span>

<span data-ttu-id="966cb-114">UWP ゲームでゲームパッドを使用する方法について詳しくは、「[ゲームパッドとバイブレーション](gamepad-and-vibration.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="966cb-114">For information on how to use gamepads in your UWP game, see [Gamepad and vibration](gamepad-and-vibration.md).</span></span>

### <a name="arcade-sticks"></a><span data-ttu-id="966cb-115">アーケード スティック</span><span class="sxs-lookup"><span data-stu-id="966cb-115">Arcade sticks</span></span>

<span data-ttu-id="966cb-116">アーケード スティックは、店頭のアーケード マシンの雰囲気を再現できる完全デジタルの入力デバイスで、格闘ゲームなどのアーケード ゲームに最適な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="966cb-116">Arcade sticks are all-digital input devices valued for reproducing the feel of stand-up arcade machines and are the perfect input device for head-to-head-fighting or other arcade-style games.</span></span>

<span data-ttu-id="966cb-117">UWP ゲームでのアーケード スティックの使用方法について詳しくは、「[アーケード スティック](arcade-stick.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="966cb-117">For information on how to use arcade sticks in your UWP game, see [Arcade stick](arcade-stick.md).</span></span>

### <a name="racing-wheels"></a><span data-ttu-id="966cb-118">レース ホイール</span><span class="sxs-lookup"><span data-stu-id="966cb-118">Racing wheels</span></span>

<span data-ttu-id="966cb-119">レース ホイールは、実際のレーシングカーのコックピットの操縦性を模した入力デバイスで、自動車やトラックを主役にしたレーシング ゲームに最適な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="966cb-119">Racing wheels are input devices that resemble the feel of a real racecar cockpit and are the perfect input device for any racing game that features cars or trucks.</span></span> <span data-ttu-id="966cb-120">多くのレース ホイールには、単なるバイブレーションではなく、真のフォース フィードバックが備わっています。フォース フィードバックでは、ハンドルなどのコントロール軸に実際の力を加えることができます。</span><span class="sxs-lookup"><span data-stu-id="966cb-120">Many racing wheels are equipped with true force feedback--that is, they can apply actual forces on an axis of control such as the steering wheel--not just simple vibration.</span></span>

<span data-ttu-id="966cb-121">UWP ゲームでのレース ホイールの使用方法について詳しくは、「[レース ホイールとフォースフィードバック](racing-wheel-and-force-feedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="966cb-121">For information on how to use racing wheels in your UWP game, see [Racing Wheel and force feedback](racing-wheel-and-force-feedback.md).</span></span>

### <a name="flight-sticks"></a><span data-ttu-id="966cb-122">フライト スティック</span><span class="sxs-lookup"><span data-stu-id="966cb-122">Flight sticks</span></span>

<span data-ttu-id="966cb-123">フライト スティックは、航空機や宇宙船のコックピットにあるフライト スティックの操作感を再現するゲームの入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="966cb-123">Flight sticks are gaming input devices that reproduce the feel of flight sticks that would be found in a plane or spaceship's cockpit.</span></span> <span data-ttu-id="966cb-124">フライトを迅速かつ正確に制御するのに最適な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="966cb-124">They're the perfect input device for quick and accurate control of flight.</span></span>

<span data-ttu-id="966cb-125">UWP ゲームでフライト スティックの使用方法の詳細については、[フライト スティック](flight-stick.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="966cb-125">For more information on how to use flight sticks in your UWP game, see [Flight stick](flight-stick.md).</span></span>

### <a name="raw-game-controllers"></a><span data-ttu-id="966cb-126">未加工のゲーム コント ローラー</span><span class="sxs-lookup"><span data-stu-id="966cb-126">Raw game controllers</span></span>

<span data-ttu-id="966cb-127">未加工のゲーム コントローラーは、さまざまな種類の一般的なゲーム コントローラーの入力を備えた、ゲーム コントローラーの汎用的な表現です。</span><span class="sxs-lookup"><span data-stu-id="966cb-127">A raw game controller is a generic representation of a game controller, with inputs found on many different kinds of common game controllers.</span></span> <span data-ttu-id="966cb-128">これらの入力は、名前のないボタン、スイッチ、軸の単純な配列として公開されます。</span><span class="sxs-lookup"><span data-stu-id="966cb-128">These inputs are exposed as simple arrays of unnamed buttons, switches, and axes.</span></span> <span data-ttu-id="966cb-129">未加工のゲーム コントローラーを使用すると、ユーザーが使っているコントローラーの種類に関係なく、カスタム入力マッピングを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="966cb-129">Using a raw game controller, you can allow customers to create custom input mappings no matter what type of controller they're using.</span></span>

<span data-ttu-id="966cb-130">UWP ゲームで未加工のゲーム コント ローラーを使用する方法の詳細については、[未加工のゲーム コント ローラー](raw-game-controller.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="966cb-130">For more information on how to use raw game controllers in your UWP game, see [Raw game controller](raw-game-controller.md).</span></span>

### <a name="ui-navigation-controllers"></a><span data-ttu-id="966cb-131">UI ナビゲーション コント ローラー</span><span class="sxs-lookup"><span data-stu-id="966cb-131">UI navigation controllers</span></span>

<span data-ttu-id="966cb-132">UI ナビゲーション コントローラーは、UI ナビゲーション コマンドの共通ボキャブラリを提供するために存在する論理入力デバイスです。UI ナビゲーション コマンドは、複数の異なるゲームや物理入力デバイス間に一貫性のあるユーザー エクスペリエンスを生み出します。</span><span class="sxs-lookup"><span data-stu-id="966cb-132">UI Navigation controllers are a logical input device that exists to provide a common vocabulary for UI navigation commands that promotes a consistent user experience across different games and physical input devices.</span></span> <span data-ttu-id="966cb-133">ゲームのユーザー インターフェイスには、デバイス固有のインターフェイスではなく、UINavigationController インターフェイスを使用するようにします。</span><span class="sxs-lookup"><span data-stu-id="966cb-133">A game's user interface should use the UINavigationController interfaces instead of device-specific interfaces.</span></span>

<span data-ttu-id="966cb-134">UWP ゲームでの UI ナビゲーション コントローラーの使用方法について詳しくは、「[UI ナビゲーション コント ローラー](ui-navigation-controller.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="966cb-134">For information on how to use UI navigation controllers in your UWP game, see [UI navigation controller](ui-navigation-controller.md).</span></span>

### <a name="headsets"></a><span data-ttu-id="966cb-135">ヘッドセット</span><span class="sxs-lookup"><span data-stu-id="966cb-135">Headsets</span></span>

<span data-ttu-id="966cb-136">ヘッドセットは、オーディオ キャプチャと再生を行うデバイスです。ヘッドセットを入力デバイス経由で接続すると、特定のユーザーに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="966cb-136">Headsets are audio capture and playback devices that are associated with a specific user when connected through their input device.</span></span> <span data-ttu-id="966cb-137">ヘッドセットは、通常ボイス チャット用オンライン ゲームで使用されます。ただし、ゲームの没入性を高めたり、オンライン ゲームとオフライン ゲームの両方でゲームプレイの機能を提供する場合にも使用できます。</span><span class="sxs-lookup"><span data-stu-id="966cb-137">They're commonly used by online games for voice chat but can also be used to enhance immersion or provide gameplay features in both online and offline games.</span></span>

<span data-ttu-id="966cb-138">UWP ゲームでのヘッドセットの使用方法について詳しくは、「[ヘッドセット](headset.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="966cb-138">For information on how to use headsets in your UWP game, see [Headset](headset.md)</span></span>

### <a name="users"></a><span data-ttu-id="966cb-139">ユーザー</span><span class="sxs-lookup"><span data-stu-id="966cb-139">Users</span></span>

<span data-ttu-id="966cb-140">各入力デバイスとそこに接続するヘッドセットに特定のユーザーを関連付け、そのユーザーの ID をそのユーザーのゲームプレイにリンクすることができます。</span><span class="sxs-lookup"><span data-stu-id="966cb-140">Each input device and its connected headset can be associated with a specific user to link their identity to their gameplay.</span></span> <span data-ttu-id="966cb-141">ユーザー ID は、物理入力デバイスからの入力を論理 UI ナビゲーション コント ローラーからの入力に関連付けるための手段でもあります。</span><span class="sxs-lookup"><span data-stu-id="966cb-141">The user identity is also the means by which input from a physical input device is correlated to input from its logical UI navigation controller.</span></span>

<span data-ttu-id="966cb-142">ユーザーと入力デバイスの管理方法について詳しくは、「[ユーザーおよびそのデバイスの追跡](input-practices-for-games.md#tracking-users-and-their-devices)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="966cb-142">For information on how to manage users and their input devices, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices).</span></span>

## <a name="see-also"></a><span data-ttu-id="966cb-143">関連項目</span><span class="sxs-lookup"><span data-stu-id="966cb-143">See Also</span></span>

* [<span data-ttu-id="966cb-144">ゲームの入力プラクティス</span><span class="sxs-lookup"><span data-stu-id="966cb-144">Input practices for games</span></span>](input-practices-for-games.md)
* [<span data-ttu-id="966cb-145">Windows.Gaming.Input 名前空間</span><span class="sxs-lookup"><span data-stu-id="966cb-145">Windows.Gaming.Input namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [<span data-ttu-id="966cb-146">Windows.Gaming.Input.Custom 名前空間</span><span class="sxs-lookup"><span data-stu-id="966cb-146">Windows.Gaming.Input.Custom namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom)