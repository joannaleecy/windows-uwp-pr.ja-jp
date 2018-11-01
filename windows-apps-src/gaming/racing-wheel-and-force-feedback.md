---
author: eliotcowley
title: レーシング ハンドルとフォース フィードバック
description: レーシング ハンドルの検出、機能の特定、読み取り、およびレーシング ハンドルへのフォース フィードバック コマンドの送信には、Windows.Gaming.Input レーシング ハンドル API を使用します。
ms.assetid: 6287D87F-6F2E-4B67-9E82-3D6E51CBAFF9
ms.author: wdg-dev-content
ms.date: 05/09/2018
ms.topic: article
keywords: Windows 10, UWP, ゲーム, レーシング ハンドル, フォース フィードバック
ms.localizationpriority: medium
ms.openlocfilehash: 20b4b35bb729ee49dbfd3f2b2b2a029a4319521c
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5861097"
---
# <a name="racing-wheel-and-force-feedback"></a><span data-ttu-id="53e95-104">レーシング ハンドルとフォース フィードバック</span><span class="sxs-lookup"><span data-stu-id="53e95-104">Racing wheel and force feedback</span></span>

<span data-ttu-id="53e95-105">このページでは、[Windows.Gaming.Input.RacingWheel][racingwheel] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One レーシング ハンドルを対象にしたプログラミングの基礎について説明します。</span><span class="sxs-lookup"><span data-stu-id="53e95-105">This page describes the basics of programming for Xbox One racing wheels using [Windows.Gaming.Input.RacingWheel][racingwheel] and related APIs for the Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="53e95-106">ここでは、次の項目について紹介します。</span><span class="sxs-lookup"><span data-stu-id="53e95-106">By reading this page, you'll learn:</span></span>

* <span data-ttu-id="53e95-107">接続されているレーシング ハンドルとそのユーザーの一覧を収集する方法</span><span class="sxs-lookup"><span data-stu-id="53e95-107">how to gather a list of connected racing wheels and their users</span></span>
* <span data-ttu-id="53e95-108">レーシング ハンドルが追加または削除されたことを検出する方法</span><span class="sxs-lookup"><span data-stu-id="53e95-108">how to detect that a racing wheel has been added or removed</span></span>
* <span data-ttu-id="53e95-109">1 つ以上のレーシング ハンドルの入力を読み取る方法</span><span class="sxs-lookup"><span data-stu-id="53e95-109">how to read input from one or more racing wheels</span></span>
* <span data-ttu-id="53e95-110">フォース フィードバック コマンドを送信する方法</span><span class="sxs-lookup"><span data-stu-id="53e95-110">how to send force feedback commands</span></span>
* <span data-ttu-id="53e95-111">UI ナビゲーション デバイスとしてのレーシング ハンドルの動作</span><span class="sxs-lookup"><span data-stu-id="53e95-111">how racing wheels behave as UI navigation devices</span></span>

## <a name="racing-wheel-overview"></a><span data-ttu-id="53e95-112">レーシング ハンドルの概要</span><span class="sxs-lookup"><span data-stu-id="53e95-112">Racing wheel overview</span></span>

<span data-ttu-id="53e95-113">レーシング ハンドルは、本物のレースカーのコックピットを模した入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="53e95-113">Racing wheels are input devices that resemble the feel of a real racecar cockpit.</span></span> <span data-ttu-id="53e95-114">車やトラックが登場するレーシング ゲームで、アーケード スタイルとシミュレーション スタイルのどちらのゲームにも最適な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="53e95-114">Racing wheels are the perfect input device for both arcade-style and simulation-style racing games that feature cars or trucks.</span></span> <span data-ttu-id="53e95-115">レーシング ハンドルは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="53e95-115">Racing wheels are supported in Windows 10 and Xbox One UWP apps by the [Windows.Gaming.Input][] namespace.</span></span>

<span data-ttu-id="53e95-116">Xbox One レーシング ハンドルは、さまざまな価格で提供されています。概して、価格が高いほど、入力とフォース フィードバック機能が優れています。</span><span class="sxs-lookup"><span data-stu-id="53e95-116">Xbox One racing wheels are offered at a variety of price points, generally having more and better input and force feedback capabilities as their price points rise.</span></span> <span data-ttu-id="53e95-117">どのレーシング ハンドルにも、アナログのステアリング ハンドル、アナログのスロットルおよびブレーキのコントロール、ハンドル上のいくつかのボタンを備えています。</span><span class="sxs-lookup"><span data-stu-id="53e95-117">All racing wheels are equipped with an analog steering wheel, analog throttle and brake controls, and some on-wheel buttons.</span></span> <span data-ttu-id="53e95-118">一部のレーシング ハンドルには、さらに、アナログのクラッチとハンドブレーキのコントロール、シフト レバー、およびフォース フィードバック機能もあります。</span><span class="sxs-lookup"><span data-stu-id="53e95-118">Some racing wheels are additionally equipped with analog clutch and handbrake controls, pattern shifters, and force feedback capabilities.</span></span> <span data-ttu-id="53e95-119">レーシング ハンドルの機能セットはどれも同じではなく、特定の機能のサポート状況も異なる可能性があります &mdash; たとえば、ステアリング ハンドルがサポートする回転の範囲や、シフト レバーがサポートするギア数は異なっている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="53e95-119">Not all racing wheels are equipped with the same sets of features, and may also vary in their support for certain features&mdash;for example, steering wheels might support different ranges of rotation and pattern shifters might support different numbers of gears.</span></span>

### <a name="device-capabilities"></a><span data-ttu-id="53e95-120">デバイスの機能</span><span class="sxs-lookup"><span data-stu-id="53e95-120">Device capabilities</span></span>

<span data-ttu-id="53e95-121">Xbox One レーシング ハンドルでは、オプションのデバイス機能のセット内容には異なるパターンがあり、各オプション機能のサポート レベルも異なっています。同一種類の入力デバイス間でこのようなレベルの違いがあることは、[Windows.Gaming.Input][] API がサポートするデバイスの特徴です。</span><span class="sxs-lookup"><span data-stu-id="53e95-121">Different Xbox One racing wheels offer different sets of optional device capabilities and varying levels of support for those capabilities; this level of variation between a single kind of input device is unique among the devices supported by the [Windows.Gaming.Input][] APIs.</span></span> <span data-ttu-id="53e95-122">さらに、流通しているほとんどのデバイスでは、少なくともいくつかのオプションの機能またはその他のバリエーションをサポートします。</span><span class="sxs-lookup"><span data-stu-id="53e95-122">Furthermore, most devices you'll encounter will support at least some optional capabilities or other variations.</span></span> <span data-ttu-id="53e95-123">そのため、接続されている各レーシング ハンドルの機能を個別に特定し、ゲームに適した機能のバリエーションをすべてサポートすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="53e95-123">Because of this, it's important to determine the capabilities of each connected racing wheel individually and to support the full variation of capabilities that makes sense for your game.</span></span>

<span data-ttu-id="53e95-124">詳しくは、「[レーシング ハンドル機能の特定](#determining-racing-wheel-capabilities)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="53e95-124">For more information, see [Determining racing wheel capabilities](#determining-racing-wheel-capabilities).</span></span>

### <a name="force-feedback"></a><span data-ttu-id="53e95-125">フォース フィードバック</span><span class="sxs-lookup"><span data-stu-id="53e95-125">Force feedback</span></span>

<span data-ttu-id="53e95-126">Some Xbox One racing wheels offer true force feedback&mdash;that is, they can apply actual forces on an axis of control such as their steering wheel&mdash;not just simple vibration.</span><span class="sxs-lookup"><span data-stu-id="53e95-126">Some Xbox One racing wheels offer true force feedback&mdash;that is, they can apply actual forces on an axis of control such as their steering wheel&mdash;not just simple vibration.</span></span> <span data-ttu-id="53e95-127">ゲームはこの機能を利用して、一層の没入感を演出し (_クラッシュ ダメージのシミュレーション_、"道路の感覚")、運転をさらに難しくします。</span><span class="sxs-lookup"><span data-stu-id="53e95-127">Games use this ability to create a greater sense of immersion (_simulated crash damage_, "road feel") and to increase the challenge of driving well.</span></span>

<span data-ttu-id="53e95-128">詳しくは、「[フォース フィードバックの概要](#force-feedback-overview)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="53e95-128">For more information, see [Force feedback overview](#force-feedback-overview).</span></span>

### <a name="ui-navigation"></a><span data-ttu-id="53e95-129">UI のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="53e95-129">UI navigation</span></span>

<span data-ttu-id="53e95-130">ユーザー インターフェイスの操作に異なる入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、ほとんどの物理__ 入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の論理__ 入力デバイスとして同時に機能します。</span><span class="sxs-lookup"><span data-stu-id="53e95-130">In order to ease the burden of supporting the different input devices for user interface navigation and to encourage consistency between games and devices, most _physical_ input devices simultaneously act as a separate _logical_ input device called a [UI navigation controller](ui-navigation-controller.md).</span></span> <span data-ttu-id="53e95-131">UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。</span><span class="sxs-lookup"><span data-stu-id="53e95-131">The UI navigation controller provides a common vocabulary for UI navigation commands across input devices.</span></span>

<span data-ttu-id="53e95-132">デバイスによってアナログ制御をどの程度重視しているかは異なり、レーシング ハンドル間のバリエーションが広いことから、通常は、[ゲームパッド](gamepad-and-vibration.md) と同様の、デジタルの方向パッド、**ビュー**、**メニュー**、**A**、**B**、**X**、および **Y** ボタンが搭載されています。これらのボタンはゲームプレイ コマンドのサポートを意図したものではなく、レーシング ハンドル ボタンとしてすぐに利用できるものではありません。</span><span class="sxs-lookup"><span data-stu-id="53e95-132">Due to their unique focus on analog controls and the degree of variation between different racing wheels, they're typically equipped with a digital D-pad, **View**, **Menu**, **A**, **B**, **X**, and **Y** buttons that resemble those of a [gamepad](gamepad-and-vibration.md); these buttons aren't intended to support gameplay commands and can't be readily accessed as racing wheel buttons.</span></span>

<span data-ttu-id="53e95-133">UI ナビゲーション コントローラーとして、レーシング ハンドルは、ナビゲーション コマンドの[必須セット](ui-navigation-controller.md#required-set)を左のサムスティック、方向パッド、**ビュー** ボタン、**メニュー** ボタン、**A**  ボタン、および**B** ボタンにマップします。</span><span class="sxs-lookup"><span data-stu-id="53e95-133">As a UI navigation controller, racing wheels map the [required set](ui-navigation-controller.md#required-set) of navigation commands to the left thumbstick, D-pad, **View**, **Menu**, **A**, and **B** buttons.</span></span>

| <span data-ttu-id="53e95-134">ナビゲーション コマンド</span><span class="sxs-lookup"><span data-stu-id="53e95-134">Navigation command</span></span> | <span data-ttu-id="53e95-135">レーシング ハンドル入力</span><span class="sxs-lookup"><span data-stu-id="53e95-135">Racing wheel input</span></span> |
| ------------------:| ------------------ |
|                 <span data-ttu-id="53e95-136">Up</span><span class="sxs-lookup"><span data-stu-id="53e95-136">Up</span></span> | <span data-ttu-id="53e95-137">方向パッドを上</span><span class="sxs-lookup"><span data-stu-id="53e95-137">D-pad up</span></span>           |
|               <span data-ttu-id="53e95-138">Down</span><span class="sxs-lookup"><span data-stu-id="53e95-138">Down</span></span> | <span data-ttu-id="53e95-139">方向パッドを下</span><span class="sxs-lookup"><span data-stu-id="53e95-139">D-pad down</span></span>         |
|               <span data-ttu-id="53e95-140">Left</span><span class="sxs-lookup"><span data-stu-id="53e95-140">Left</span></span> | <span data-ttu-id="53e95-141">方向パッドを左</span><span class="sxs-lookup"><span data-stu-id="53e95-141">D-pad left</span></span>         |
|              <span data-ttu-id="53e95-142">Right</span><span class="sxs-lookup"><span data-stu-id="53e95-142">Right</span></span> | <span data-ttu-id="53e95-143">方向パッドを右</span><span class="sxs-lookup"><span data-stu-id="53e95-143">D-pad right</span></span>        |
|               <span data-ttu-id="53e95-144">View</span><span class="sxs-lookup"><span data-stu-id="53e95-144">View</span></span> | <span data-ttu-id="53e95-145">ビュー ボタン</span><span class="sxs-lookup"><span data-stu-id="53e95-145">View button</span></span>        |
|               <span data-ttu-id="53e95-146">Menu</span><span class="sxs-lookup"><span data-stu-id="53e95-146">Menu</span></span> | <span data-ttu-id="53e95-147">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="53e95-147">Menu button</span></span>        |
|             <span data-ttu-id="53e95-148">Accept</span><span class="sxs-lookup"><span data-stu-id="53e95-148">Accept</span></span> | <span data-ttu-id="53e95-149">A ボタン</span><span class="sxs-lookup"><span data-stu-id="53e95-149">A button</span></span>           |
|             <span data-ttu-id="53e95-150">Cancel</span><span class="sxs-lookup"><span data-stu-id="53e95-150">Cancel</span></span> | <span data-ttu-id="53e95-151">B ボタン</span><span class="sxs-lookup"><span data-stu-id="53e95-151">B button</span></span>           |

<span data-ttu-id="53e95-152">また、一部のレーシング ハンドルでは、ナビゲーション コマンドの[オプション セット](ui-navigation-controller.md#optional-set)を、サポートする他の入力にマップしますが、コマンドのマッピングはデバイスによって異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="53e95-152">Additionally, some racing wheels might map some of the [optional set](ui-navigation-controller.md#optional-set) of navigation commands to other inputs they support, but command mappings can vary from device to device.</span></span> <span data-ttu-id="53e95-153">以下のコマンドもサポートすることを検討してください。ただし、ゲームのインターフェイスのナビゲーションの基本コマンドにはしないでください。</span><span class="sxs-lookup"><span data-stu-id="53e95-153">Consider supporting these commands as well, but make sure that these commands are not essential to navigating your game's interface.</span></span>

| <span data-ttu-id="53e95-154">ナビゲーション コマンド</span><span class="sxs-lookup"><span data-stu-id="53e95-154">Navigation command</span></span> | <span data-ttu-id="53e95-155">レーシング ハンドル入力</span><span class="sxs-lookup"><span data-stu-id="53e95-155">Racing wheel input</span></span>    |
| ------------------:| --------------------- |
|            <span data-ttu-id="53e95-156">PageUp</span><span class="sxs-lookup"><span data-stu-id="53e95-156">Page Up</span></span> | _<span data-ttu-id="53e95-157">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-157">varies</span></span>_              |
|          <span data-ttu-id="53e95-158">PageDown</span><span class="sxs-lookup"><span data-stu-id="53e95-158">Page Down</span></span> | _<span data-ttu-id="53e95-159">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-159">varies</span></span>_              |
|          <span data-ttu-id="53e95-160">Page Left</span><span class="sxs-lookup"><span data-stu-id="53e95-160">Page Left</span></span> | _<span data-ttu-id="53e95-161">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-161">varies</span></span>_              |
|         <span data-ttu-id="53e95-162">Page Right</span><span class="sxs-lookup"><span data-stu-id="53e95-162">Page Right</span></span> | _<span data-ttu-id="53e95-163">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-163">varies</span></span>_              |
|          <span data-ttu-id="53e95-164">Scroll Up</span><span class="sxs-lookup"><span data-stu-id="53e95-164">Scroll Up</span></span> | _<span data-ttu-id="53e95-165">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-165">varies</span></span>_              |
|        <span data-ttu-id="53e95-166">Scroll Down</span><span class="sxs-lookup"><span data-stu-id="53e95-166">Scroll Down</span></span> | _<span data-ttu-id="53e95-167">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-167">varies</span></span>_              |
|        <span data-ttu-id="53e95-168">Scroll Left</span><span class="sxs-lookup"><span data-stu-id="53e95-168">Scroll Left</span></span> | _<span data-ttu-id="53e95-169">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-169">varies</span></span>_              |
|       <span data-ttu-id="53e95-170">Scroll Right</span><span class="sxs-lookup"><span data-stu-id="53e95-170">Scroll Right</span></span> | _<span data-ttu-id="53e95-171">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-171">varies</span></span>_              |
|          <span data-ttu-id="53e95-172">Context 1</span><span class="sxs-lookup"><span data-stu-id="53e95-172">Context 1</span></span> | <span data-ttu-id="53e95-173">X ボタン (_一般的な場合_)</span><span class="sxs-lookup"><span data-stu-id="53e95-173">X Button (_commonly_)</span></span> |
|          <span data-ttu-id="53e95-174">Context 2</span><span class="sxs-lookup"><span data-stu-id="53e95-174">Context 2</span></span> | <span data-ttu-id="53e95-175">Y ボタン (_一般的な場合_)</span><span class="sxs-lookup"><span data-stu-id="53e95-175">Y Button (_commonly_)</span></span> |
|          <span data-ttu-id="53e95-176">Context 3</span><span class="sxs-lookup"><span data-stu-id="53e95-176">Context 3</span></span> | _<span data-ttu-id="53e95-177">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-177">varies</span></span>_              |
|          <span data-ttu-id="53e95-178">Context 4</span><span class="sxs-lookup"><span data-stu-id="53e95-178">Context 4</span></span> | _<span data-ttu-id="53e95-179">状況により異なる</span><span class="sxs-lookup"><span data-stu-id="53e95-179">varies</span></span>_              |

## <a name="detect-and-track-racing-wheels"></a><span data-ttu-id="53e95-180">レーシング ハンドルの検出と追跡</span><span class="sxs-lookup"><span data-stu-id="53e95-180">Detect and track racing wheels</span></span>

<span data-ttu-id="53e95-181">レーシング ハンドルの検出と追跡の方法はゲームパッドの場合とまったく同じですが、[Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) クラスの代わりに [RacingWheel][] クラスを使用する点だけが異なります。</span><span class="sxs-lookup"><span data-stu-id="53e95-181">Detecting and tracking racing wheels works in exactly the same way as it does for gamepads, except with the [RacingWheel][] class instead of the [Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) class.</span></span> <span data-ttu-id="53e95-182">詳細については、「[ゲームパッドと振動](gamepad-and-vibration.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53e95-182">See [Gamepad and vibration](gamepad-and-vibration.md) for more information.</span></span>

<!-- Racing wheels are managed by the system, therefore you don't have to create or initialize them. The system provides a list of connected racing wheels and events to notify you when a racing wheel is added or removed.

### The racing wheels list

The [RacingWheel][] class provides a static property, [RacingWheels][], which is a read-only list of racing wheels that are currently connected. Because you might only be interested in some of the connected racing wheels, it's recommended that you maintain your own collection instead of accessing them through the `RacingWheels` property.

The following example copies all connected racing wheels into a new collection.
```cpp
auto myRacingWheels = ref new Vector<RacingWheel^>();

for (auto racingwheel : RacingWheel::RacingWheels)
{
    // This code assumes that you're interested in all racing wheels.
    myRacingWheels->Append(racingwheel);
}
```

### Adding and removing racing wheels

When a racing wheel is added or removed the [RacingWheelAdded][] and [RacingWheelRemoved][] events are raised. You can register handlers for these events to keep track of the racing wheels that are currently connected.

The following example starts tracking an racing wheels that's been added.
```cpp
RacingWheel::RacingWheelAdded += ref new EventHandler<RacingWheel^>(Platform::Object^, RacingWheel^ args)
{
    // This code assumes that you're interested in all new racing wheels.
    myRacingWheels->Append(args);
}
```

The following example stops tracking a racing wheel that's been removed.
```cpp
RacingWheel::RacingWheelRemoved += ref new EventHandler<RacingWheel^>(Platform::Object^, RacingWheel^ args)
{
    unsigned int indexRemoved;

    if(myRacingWheels->IndexOf(args, &indexRemoved))
    {
        myRacingWheels->RemoveAt(indexRemoved);
    }
}
```

### Users and headsets

Each racing wheel can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features. To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md). -->

## <a name="reading-the-racing-wheel"></a><span data-ttu-id="53e95-183">レーシング ハンドルの読み取り</span><span class="sxs-lookup"><span data-stu-id="53e95-183">Reading the racing wheel</span></span>

<span data-ttu-id="53e95-184">目的のレーシング ハンドルを特定したら、入力を収集する準備は完了です。</span><span class="sxs-lookup"><span data-stu-id="53e95-184">After you identify the racing wheels that you're interested in, you're ready to gather input from them.</span></span> <span data-ttu-id="53e95-185">ただし、なじみのある一部の他の種類の入力とは違い、レーシング ハンドルはイベントを発生することによって状態の変化を伝えるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="53e95-185">However, unlike some other kinds of input that you might be used to, racing wheels don't communicate state-change by raising events.</span></span> <span data-ttu-id="53e95-186">代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="53e95-186">Instead, you take regular readings of their current states by _polling_ them.</span></span>

### <a name="polling-the-racing-wheel"></a><span data-ttu-id="53e95-187">レーシング ハンドルのポーリング</span><span class="sxs-lookup"><span data-stu-id="53e95-187">Polling the racing wheel</span></span>

<span data-ttu-id="53e95-188">ポーリングでは、明確な時点におけるレーシング ハンドルのスナップショットをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="53e95-188">Polling captures a snapshot of the racing wheel at a precise point in time.</span></span> <span data-ttu-id="53e95-189">入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="53e95-189">This approach to input gathering is a good fit for most games because their logic typically runs in a deterministic loop rather than being event-driven; it's also typically simpler to interpret game commands from input gathered all at once than it is from many single inputs gathered over time.</span></span>

<span data-ttu-id="53e95-190">レーシング ハンドルをポーリングするには、[GetCurrentReading][] を呼び出します。この関数はレーシング ハンドルの状態が格納された [RacingWheelReading][] を返します。</span><span class="sxs-lookup"><span data-stu-id="53e95-190">You poll a racing wheel by calling [GetCurrentReading][]; this function returns a [RacingWheelReading][] that contains the state of the racing wheel.</span></span>

<span data-ttu-id="53e95-191">次の例では、レーシング ハンドルをポーリングして現在の状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="53e95-191">The following example polls a racing wheel for its current state.</span></span>

```cpp
auto racingwheel = myRacingWheels[0];

RacingWheelReading reading = racingwheel->GetCurrentReading();
```

<span data-ttu-id="53e95-192">読み取りデータには、レーシング ハンドルの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　</span><span class="sxs-lookup"><span data-stu-id="53e95-192">In addition to the racing wheel state, each reading includes a timestamp that indicates precisely when the state was retrieved.</span></span> <span data-ttu-id="53e95-193">このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。</span><span class="sxs-lookup"><span data-stu-id="53e95-193">The timestamp is useful for relating to the timing of previous readings or to the timing of the game simulation.</span></span>

### <a name="determining-racing-wheel-capabilities"></a><span data-ttu-id="53e95-194">レーシング ハンドル機能の特定</span><span class="sxs-lookup"><span data-stu-id="53e95-194">Determining racing wheel capabilities</span></span>

<span data-ttu-id="53e95-195">レーシング ハンドル コントロールの多くはオプションであるか、必須のコントロールであっても複数のバリエーションをサポートするため、レーシング ハンドルの各読み取りで収集された入力の処理を開始する前に、各レーシング ハンドルの機能を個別に特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="53e95-195">Many of the racing wheel controls are optional or support different variations even in the required controls, so you have to determine the capabilities of each racing wheel individually before you can process the input gathered in each reading of the racing wheel.</span></span>

<span data-ttu-id="53e95-196">オプションのコントロールは、ハンドブレーキ、クラッチ、およびシフトレバーです。接続されているレーシング ハンドルがこれらのコントロールをサポートするかどうかは、レーシング ハンドルの [HasHandbrake][]、[HasClutch][]、および [HasPatternShifter][] プロパティをそれぞれ読み取ることで特定できます。</span><span class="sxs-lookup"><span data-stu-id="53e95-196">The optional controls are the handbrake, clutch, and pattern shifter; you can determine whether a connected racing wheel supports these controls by reading the [HasHandbrake][], [HasClutch][], and [HasPatternShifter][] properties of the racing wheel, respectively.</span></span> <span data-ttu-id="53e95-197">プロパティの値が **true** の場合、コントロールはサポートされています。そうでない場合は、サポートされません。</span><span class="sxs-lookup"><span data-stu-id="53e95-197">The control is supported if the value of the property is **true**; otherwise it's not supported.</span></span>

```cpp
if (racingwheel->HasHandbrake)
{
    // the handbrake is supported
}

if (racingwheel->HasClutch)
{
    // the clutch is supported
}

if (racingwheel->HasPatternShifter)
{
    // the pattern shifter is supported
}
```

<span data-ttu-id="53e95-198">また、ステアリング ハンドルとシフトレバーも、バリエーションがある可能性があるコントロールです。</span><span class="sxs-lookup"><span data-stu-id="53e95-198">Additionally, the controls that may vary are the steering wheel and pattern shifter.</span></span> <span data-ttu-id="53e95-199">ステアリング ハンドルでは、実際のハンドルがサポートする物理的な回転の度合いが異なり、シフトレバーでは、各レバーがサポートする前進ギアの数が異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="53e95-199">The steering wheel can vary by the degree of physical rotation that the actual wheel can support, while the pattern shifter can vary by the number of distinct forward gears it supports.</span></span> <span data-ttu-id="53e95-200">レーシング ハンドルの `MaxWheelAngle` プロパティを読み取ることで、実際のハンドルがサポートする回転の最大角度を特定できます。この値は、サポートされる物理的な最大角度を時計回り (正) と反時計回り (負) で表します。</span><span class="sxs-lookup"><span data-stu-id="53e95-200">You can determine the greatest angle of rotation the actual wheel supports by reading the `MaxWheelAngle` property of the racing wheel; its value is the maximum supported physical angle in degrees clock-wise (positive) which is likewise supported in the counter-clock-wise direction (negative degrees).</span></span> <span data-ttu-id="53e95-201">シフトレバーがサポートする最大の前進ギアは、レーシング ハンドルの `MaxPatternShifterGear` プロパティを読み取ることで特定できます。この値は、サポートされる最大の前進ギアを表します。&mdash; つまり、値が 4 の場合、バック ギア、ニュートラル、第 1 ギア、第 2 ギア、第 3 ギア、および第 4 ギアまでサポートされます。</span><span class="sxs-lookup"><span data-stu-id="53e95-201">You can determine the greatest forward gear the pattern shifter supports by reading the `MaxPatternShifterGear` property of the racing wheel; its value is the highest forward gear supported, inclusive&mdash;that is, if its value is 4, then the pattern shifter supports reverse, neutral, first, second, third, and fourth gears.</span></span>

```cpp
auto maxWheelDegrees = racingwheel->MaxWheelAngle;
auto maxShifterGears = racingwheel->MaxPatternShifterGear;
```

<span data-ttu-id="53e95-202">また、一部のレーシング ハンドルでは、ステアリング ハンドルを介したフォース フィードバックをサポートします。</span><span class="sxs-lookup"><span data-stu-id="53e95-202">Finally, some racing wheels support force feedback through the steering wheel.</span></span> <span data-ttu-id="53e95-203">接続されているレーシング ハンドルがフォース フィードバックをサポートするかどうかは、レーシング ハンドルの [WheelMotor][] プロパティを読み取ることで特定できます。</span><span class="sxs-lookup"><span data-stu-id="53e95-203">You can determine whether a connected racing wheel supports force feedback by reading the [WheelMotor][] property of the racing wheel.</span></span> <span data-ttu-id="53e95-204">`WheelMotor` プロパティの値が **null** ではない場合、フォース フィードバックはサポートされています。そうでない場合は、サポートされません。</span><span class="sxs-lookup"><span data-stu-id="53e95-204">Force feedback is supported if `WheelMotor` is not **null**; otherwise it's not supported.</span></span>

```cpp
if (racingwheel->WheelMotor != nullptr)
{
    // force feedback is supported
}
```

<span data-ttu-id="53e95-205">フォース フィードバックをサポートするレーシング ハンドルのフォース フィードバック機能の使い方の詳細については、「[フォース フィードバックの概要](#force-feedback-overview)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53e95-205">For information on how to use the force feedback capability of racing wheels that support it, see [Force feedback overview](#force-feedback-overview).</span></span>

### <a name="reading-the-buttons"></a><span data-ttu-id="53e95-206">ボタンの読み取り</span><span class="sxs-lookup"><span data-stu-id="53e95-206">Reading the buttons</span></span>

<span data-ttu-id="53e95-207">レーシング ハンドルの各ボタン &mdash; 方向パッドの 4 方向、**前のギア** ボタンと**次のギア** ボタン、その他 16 個のボタン &mdash; は、デジタルの読み取り値によって、押されている (ダウン) か離されている (アップ) かを示します。</span><span class="sxs-lookup"><span data-stu-id="53e95-207">Each of the racing wheel buttons&mdash;the four directions of the D-pad, the **Previous Gear** and **Next Gear** buttons, and 16 additional buttons&mdash;provides a digital reading that indicates whether it's pressed (down) or released (up).</span></span> <span data-ttu-id="53e95-208">効率を高めるため、ボタンの読み取り値は個別のブール値としては表されません。代わりに、読み取り値はすべて、[RacingWheelButtons][] 列挙型で表される単一のビットフィールドにパックされます。</span><span class="sxs-lookup"><span data-stu-id="53e95-208">For efficiency, button readings aren't represented as individual boolean values; instead they're all packed into a single bitfield that's represented by the [RacingWheelButtons][] enumeration.</span></span>

> [!NOTE]
> <span data-ttu-id="53e95-209">レーシング ハンドルには、**ビュー** ボタンや**メニュー** ボタンなど、他にも UI 操作に使用するボタンが搭載されています。</span><span class="sxs-lookup"><span data-stu-id="53e95-209">Racing wheels are equipped with additional buttons used for UI navigation such as the **View** and **Menu** buttons.</span></span> <span data-ttu-id="53e95-210">これらのボタンは `RacingWheelButtons` 列挙型には含まれず、UI ナビゲーション デバイスとしてレーシング ハンドルを利用する場合にしか、読み取られません。</span><span class="sxs-lookup"><span data-stu-id="53e95-210">These buttons are not a part of the `RacingWheelButtons` enumeration and can only be read by accessing the racing wheel as a UI navigation device.</span></span> <span data-ttu-id="53e95-211">詳しくは、「[UI ナビゲーション デバイス](ui-navigation-controller.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="53e95-211">For more information, see [UI Navigation Device](ui-navigation-controller.md).</span></span>

<span data-ttu-id="53e95-212">ボタンの値は、[RacingWheelReading][] 構造体の `Buttons` プロパティから読み取ります。</span><span class="sxs-lookup"><span data-stu-id="53e95-212">The button values are read from the `Buttons` property of the [RacingWheelReading][] structure.</span></span> <span data-ttu-id="53e95-213">このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。</span><span class="sxs-lookup"><span data-stu-id="53e95-213">Because this property is a bitfield, bitwise masking is used to isolate the value of the button that you're interested in.</span></span> <span data-ttu-id="53e95-214">対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。</span><span class="sxs-lookup"><span data-stu-id="53e95-214">The button is pressed (down) when the corresponding bit is set; otherwise, it's released (up).</span></span>

<span data-ttu-id="53e95-215">次の例では、**次のギア** ボタンが押されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="53e95-215">The following example determines whether the **Next Gear** button is pressed.</span></span>

```cpp
if (RacingWheelButtons::NextGear == (reading.Buttons & RacingWheelButtons::NextGear))
{
    // Next Gear is pressed
}
```

<span data-ttu-id="53e95-216">次の例では、次のギア ボタンが離されているかどうかを判別します。</span><span class="sxs-lookup"><span data-stu-id="53e95-216">The following example determines whether the Next Gear button is released.</span></span>

```cpp
if (RacingWheelButtons::None == (reading.Buttons & RacingWheelButtons::NextGear))
{
    // Next Gear is released (not pressed)
}
```

<span data-ttu-id="53e95-217">場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか &mdash; (一部が押されていて、一部が押されていない) を特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="53e95-217">Sometimes you might want to determine when a button transitions from pressed to released or released to pressed, whether multiple buttons are pressed or released, or if a set of buttons are arranged in a particular way&mdash;some pressed, some not.</span></span> <span data-ttu-id="53e95-218">これらの状態を検出する方法の詳細については、「[Detecting button transitions (ボタンの移行の検出)](input-practices-for-games.md#detecting-button-transitions)」および「[Detecting complex button arrangements (複雑なボタンのパターンの検出)](input-practices-for-games.md#detecting-complex-button-arrangements)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53e95-218">For information on how to detect these conditions, see [Detecting button transitions](input-practices-for-games.md#detecting-button-transitions) and [Detecting complex button arrangements](input-practices-for-games.md#detecting-complex-button-arrangements).</span></span>

### <a name="reading-the-wheel"></a><span data-ttu-id="53e95-219">ハンドルの読み取り</span><span class="sxs-lookup"><span data-stu-id="53e95-219">Reading the wheel</span></span>

<span data-ttu-id="53e95-220">ステアリング ハンドルは、-1.0 ～ +1.0 のアナログの読み取り値を提供する必須のコントロールです。</span><span class="sxs-lookup"><span data-stu-id="53e95-220">The steering wheel is a required control that provides an analog reading between -1.0 and +1.0.</span></span> <span data-ttu-id="53e95-221">-1.0 の値はハンドルを最も左に回転した位置に対応し、+1.0 の値はハンドルを最も右に回転した位置に対応します。</span><span class="sxs-lookup"><span data-stu-id="53e95-221">A value of -1.0 corresponds to the left-most wheel position; a value of +1.0 corresponds to the right-most position.</span></span> <span data-ttu-id="53e95-222">ステアリング ハンドルの値は、[RacingWheelReading][] 構造体の `Wheel` プロパティから読み取ります。</span><span class="sxs-lookup"><span data-stu-id="53e95-222">The value of the steering wheel is read from the `Wheel` property of the [RacingWheelReading][] structure.</span></span>

```cpp
float wheel = reading.Wheel;  // returns a value between -1.0 and +1.0.
```

<span data-ttu-id="53e95-223">ハンドルの読み取り値は、物理的なレーシング ハンドルがサポートする回転の範囲に応じて異なる実際のハンドルの物理的な回転の角度に対応しますが、通常はハンドルの読み取り値はハンドルに合わせて調整しません。ハンドルのサポートする回転角度が広くなれば、精度も高くなります。</span><span class="sxs-lookup"><span data-stu-id="53e95-223">Although wheel readings correspond to different degrees of physical rotation in the actual wheel depending on the range of rotation supported by the physical racing wheel, you don't usually want to scale the wheel readings; wheels that support greater degrees of rotation just provide greater precision.</span></span>

### <a name="reading-the-throttle-and-brake"></a><span data-ttu-id="53e95-224">スロットルとブレーキの読み取り</span><span class="sxs-lookup"><span data-stu-id="53e95-224">Reading the throttle and brake</span></span>

<span data-ttu-id="53e95-225">スロットルとブレーキは、0.0 (完全に離された状態) ～ 1.0 (完全に押された状態) の間の浮動小数点値として表されたアナログ読み取り値をそれぞれ提供する必須のコントロールです。</span><span class="sxs-lookup"><span data-stu-id="53e95-225">The throttle and brake are required controls that each provide analog readings between 0.0 (fully released) and 1.0 (fully pressed) represented as floating-point values.</span></span> <span data-ttu-id="53e95-226">スロットル コントロールの値は、[RacingWheelReading][] 構造体の `Throttle` プロパティから、ブレーキ コントロールの値は `Brake` プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="53e95-226">The value of the throttle control is read from the `Throttle` property of the [RacingWheelReading][] struct; the value of the brake control is read from the `Brake` property.</span></span>

```cpp
float throttle = reading.Throttle;  // returns a value between 0.0 and 1.0
float brake    = reading.Brake;     // returns a value between 0.0 and 1.0
```

### <a name="reading-the-handbrake-and-clutch"></a><span data-ttu-id="53e95-227">ハンドブレーキとクラッチの読み取り</span><span class="sxs-lookup"><span data-stu-id="53e95-227">Reading the handbrake and clutch</span></span>

<span data-ttu-id="53e95-228">ハンドブレーキとクラッチは、0.0 (完全に離された状態) ～ 1.0 (完全に押された状態) の間の浮動小数点値として表されたアナログ読み取り値をそれぞれ提供するオプションのコントロールです。</span><span class="sxs-lookup"><span data-stu-id="53e95-228">The handbrake and clutch are optional controls that each provide analog readings between 0.0 (fully released) and 1.0 (fully engaged) represented as floating-point values.</span></span> <span data-ttu-id="53e95-229">ハンドブレーキ コントロールの値は、[RacingWheelReading][] 構造体の `Handbrake` プロパティから、クラッチ コントロールの値は `Clutch` プロパティから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="53e95-229">The value of the handbrake control is read from the `Handbrake` property of the [RacingWheelReading][] struct; the value of the clutch control is read from the `Clutch` property.</span></span>

```cpp
float handbrake = 0.0;
float clutch = 0.0;

if(racingwheel->HasHandbrake)
{
    handbrake = reading.Handbrake;  // returns a value between 0.0 and 1.0
}

if(racingwheel->HasClutch)
{
    clutch = reading.Clutch;        // returns a value between 0.0 and 1.0
}
```

### <a name="reading-the-pattern-shifter"></a><span data-ttu-id="53e95-230">シフトレバーの読み取り</span><span class="sxs-lookup"><span data-stu-id="53e95-230">Reading the pattern shifter</span></span>

<span data-ttu-id="53e95-231">シフトレバーは、-1 ～ [MaxPatternShifterGear][] の符号付き整数値として表されたデジタルの読み取り値を提供するオプションのコントロールです。</span><span class="sxs-lookup"><span data-stu-id="53e95-231">The pattern shifter is an optional control that provides a digital reading between -1 and [MaxPatternShifterGear][] represented as a signed integer value.</span></span> <span data-ttu-id="53e95-232">-1 または 0 は_バック_ ギアと _ニュートラル_ ギアにそれぞれ対応し、正の値が大きくなるほど、高いレベルの前進ギアに対応し、最大のギアは [MaxPatternShifterGear][] になります。</span><span class="sxs-lookup"><span data-stu-id="53e95-232">A value of -1 or 0 correspond to the _reverse_ and _neutral_ gears, respectively; increasingly positive values correspond to greater forward gears up to [MaxPatternShifterGear][], inclusive.</span></span> <span data-ttu-id="53e95-233">シフトレバーの値は、[RacingWheelReading][] 構造体の `PatternShifterGear` プロパティから読み取ります。</span><span class="sxs-lookup"><span data-stu-id="53e95-233">The value of the pattern shifter is read from the `PatternShifterGear` property of the [RacingWheelReading][] struct.</span></span>

```cpp
if (racingwheel->HasPatternShifter)
{
    gear = reading.PatternShifterGear;
}
```

> [!NOTE]
> <span data-ttu-id="53e95-234">シフトレバーは、サポートされる場合、必須の**前のギア** ボタンと**次のギア** ボタンと併せて存在します。これらのボタンも、プレイヤーの車の現在のギア操作に使用されます。</span><span class="sxs-lookup"><span data-stu-id="53e95-234">The pattern shifter, where supported, exists alongside the required **Previous Gear** and **Next Gear** buttons which also affect the current gear of the player's car.</span></span> <span data-ttu-id="53e95-235">シフトレバーとギア ボタンの両方が存在する場合にギアの入力を統合する簡単な方法は、プレイヤーが車に AT (オートマチック トランスミッション) を選択しているときは、シフトレバー (とクラッチ) を無視することです。レーシング ハンドルにシフトレバー コントロールしか搭載されていなくて、プレイヤーが車に MT (マニュアル トランスミッション) を選択しているときは、**前のギア** ボタンと **次のギア** ボタンを無視します。</span><span class="sxs-lookup"><span data-stu-id="53e95-235">A simple strategy for unifying these inputs where both are present is to ignore the pattern shifter (and clutch) when a player chooses an automatic transmission for their car, and to ignore the **Previous** and **Next Gear** buttons when a player chooses a manual transmission for their car only if their racing wheel is equipped with a pattern shifter control.</span></span> <span data-ttu-id="53e95-236">この方法がゲームに適さない場合は、別の統合方法を実装できます。</span><span class="sxs-lookup"><span data-stu-id="53e95-236">You can implement a different unification strategy if this isn't suitable for your game.</span></span>

## <a name="run-the-inputinterfacing-sample"></a><span data-ttu-id="53e95-237">InputInterfacing サンプルの実行</span><span class="sxs-lookup"><span data-stu-id="53e95-237">Run the InputInterfacing sample</span></span>

<span data-ttu-id="53e95-238">[InputInterfacingUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) は、レーシング ハンドルと、種類の異なる入力デバイスとを組み合わせて使用する方法と、これらの入力デバイスが UI ナビゲーション コントローラーとしてどのように動作するかを示します。</span><span class="sxs-lookup"><span data-stu-id="53e95-238">The [InputInterfacingUWP sample _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) demonstrates how to use racing wheels and different kinds of input devices in tandem, as well as how these input devices behave as UI navigation controllers.</span></span>

## <a name="force-feedback-overview"></a><span data-ttu-id="53e95-239">フォース フィードバックの概要</span><span class="sxs-lookup"><span data-stu-id="53e95-239">Force feedback overview</span></span>

<span data-ttu-id="53e95-240">多くのレーシング ハンドルには、より没入型で、難易度の高いドライブ エクスペリエンスを提供するため、フォース フィードバック機能があります。</span><span class="sxs-lookup"><span data-stu-id="53e95-240">Many racing wheels have force feedback capability to provide a more immersive and challenging driving experience.</span></span> <span data-ttu-id="53e95-241">フォース フィードバックをサポートするレーシング ハンドルには、通常、単一の軸 (ハンドルの回転軸) に沿ってステアリング ハンドルに力を適用する単一のモーターが搭載されています。</span><span class="sxs-lookup"><span data-stu-id="53e95-241">Racing wheels that support force feedback are typically equipped with a single motor that applies force to the steering wheel along a single axis, the axis of wheel rotation.</span></span> <span data-ttu-id="53e95-242">フォース フィードバックは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input.ForceFeedback][] 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="53e95-242">Force feedback is supported in Windows 10 and Xbox One UWP apps by the [Windows.Gaming.Input.ForceFeedback][] namespace.</span></span>

> [!NOTE]
> <span data-ttu-id="53e95-243">フォース フィードバック API は、複数軸のフォースをサポートできますが、現時点では、ハンドルの回転軸以外の軸でフィードバックをサポートしている Xbox One レーシング ハンドルはありません。</span><span class="sxs-lookup"><span data-stu-id="53e95-243">The force feedback APIs are capable of supporting several axes of force, but no Xbox One racing wheel currently supports any feedback axis other than that of wheel rotation.</span></span>

## <a name="using-force-feedback"></a><span data-ttu-id="53e95-244">フォース フィードバックの使用</span><span class="sxs-lookup"><span data-stu-id="53e95-244">Using force feedback</span></span>

<span data-ttu-id="53e95-245">以下のセクションでは、Xbox One レーシング ハンドルのフォース フィードバック効果のプログラミングの基本を説明します。</span><span class="sxs-lookup"><span data-stu-id="53e95-245">These sections describe the basics of programming force feedback effects for Xbox One racing wheels.</span></span> <span data-ttu-id="53e95-246">フィードバックは効果を使用して適用されます。効果は、サウンド効果と同様に、まず、フォース フィードバック デバイスに読み込まれたうえで、開始、一時停止、再開、停止の順で実行できるようになります。ただし、レーシング ハンドルのフィードバック機能を最初に特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="53e95-246">Feedback is applied using effects, which are first loaded onto the force feedback device and then can be started, paused, resumed, and stopped in a manner similar to sound effects; however, you must first determine the feedback capabilities of the racing wheel.</span></span>

### <a name="determining-force-feedback-capabilities"></a><span data-ttu-id="53e95-247">フォース フィードバック機能の特定</span><span class="sxs-lookup"><span data-stu-id="53e95-247">Determining force feedback capabilities</span></span>

<span data-ttu-id="53e95-248">接続されているレーシング ハンドルがフォース フィードバックをサポートするかどうかは、レーシング ハンドルの [WheelMotor][] プロパティを読み取ることで特定できます。</span><span class="sxs-lookup"><span data-stu-id="53e95-248">You can determine whether a connected racing wheel supports force feedback by reading the [WheelMotor][] property of the racing wheel.</span></span> <span data-ttu-id="53e95-249">`WheelMotor` が **null** の場合は、フォース フィードバックはサポートされません。そうでない場合は、フォース フィードバックはサポートされているので、フォース フィードバックが適用される軸など、モーターの特定のフィードバック機能を特定します。</span><span class="sxs-lookup"><span data-stu-id="53e95-249">Force feedback isn't supported if `WheelMotor` is **null**; otherwise, force feedback is supported and you can proceed to determine the specific feedback capabilities of the motor, such as the axes it can affect.</span></span>

```cpp
if (racingwheel->WheelMotor != nullptr)
{
    auto axes = racingwheel->WheelMotor->SupportedAxes;

    if(ForceFeedbackEffectAxes::X == (axes & ForceFeedbackEffectAxes::X))
    {
        // Force can be applied through the X axis
    }

    if(ForceFeedbackEffectAxes::Y == (axes & ForceFeedbackEffectAxes::Y))
    {
        // Force can be applied through the Y axis
    }

    if(ForceFeedbackEffectAxes::Z == (axes & ForceFeedbackEffectAxes::Z))
    {
        // Force can be applied through the Z axis
    }
}
```

### <a name="loading-force-feedback-effects"></a><span data-ttu-id="53e95-250">フォース フィードバック効果の読み込み</span><span class="sxs-lookup"><span data-stu-id="53e95-250">Loading force feedback effects</span></span>

<span data-ttu-id="53e95-251">フォース フィードバック効果は、ゲームのコマンドに対して自律的に "再生" されるフィードバック デバイスに読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="53e95-251">Force feedback effects are loaded onto the feedback device where they are "played" autonomously at the command of your game.</span></span> <span data-ttu-id="53e95-252">いくつか基本の効果が提供されています。カスタムの効果は、[IForceFeedbackEffect][] インターフェイスを実装するクラスを利用して作成できます。</span><span class="sxs-lookup"><span data-stu-id="53e95-252">A number of basic effects are provided; custom effects can be created through a class that implements the [IForceFeedbackEffect][] interface.</span></span>

| <span data-ttu-id="53e95-253">Effect クラス</span><span class="sxs-lookup"><span data-stu-id="53e95-253">Effect class</span></span>         | <span data-ttu-id="53e95-254">効果の説明</span><span class="sxs-lookup"><span data-stu-id="53e95-254">Effect description</span></span>                                                                     |
| -------------------- | -------------------------------------------------------------------------------------- |
| <span data-ttu-id="53e95-255">ConditionForceEffect</span><span class="sxs-lookup"><span data-stu-id="53e95-255">ConditionForceEffect</span></span> | <span data-ttu-id="53e95-256">デバイス内の現在のセンサーに応じて、異なる力を適用する効果です。</span><span class="sxs-lookup"><span data-stu-id="53e95-256">An effect that applies variable force in response to current sensor within the device.</span></span> |
| <span data-ttu-id="53e95-257">ConstantForceEffect</span><span class="sxs-lookup"><span data-stu-id="53e95-257">ConstantForceEffect</span></span>  | <span data-ttu-id="53e95-258">一定の力を特定のベクトルに沿って適用する効果です。</span><span class="sxs-lookup"><span data-stu-id="53e95-258">An effect that applies constant force along a vector.</span></span>                                  |
| <span data-ttu-id="53e95-259">PeriodicForceEffect</span><span class="sxs-lookup"><span data-stu-id="53e95-259">PeriodicForceEffect</span></span>  | <span data-ttu-id="53e95-260">波形によって定義される可変の力を特定のベクトルに沿って適用する効果です。</span><span class="sxs-lookup"><span data-stu-id="53e95-260">An effect that applies variable force defined by a waveform, along a vector.</span></span>           |
| <span data-ttu-id="53e95-261">RampForceEffect</span><span class="sxs-lookup"><span data-stu-id="53e95-261">RampForceEffect</span></span>      | <span data-ttu-id="53e95-262">線形に増加/減少する力を特定のベクトルに沿って適用する効果です。</span><span class="sxs-lookup"><span data-stu-id="53e95-262">An effect that applies a linearly increasing/decreasing force along a vector.</span></span>          |

```cpp
using FFLoadEffectResult = ForceFeedback::ForceFeedbackLoadEffectResult;

auto effect = ref new Windows.Gaming::Input::ForceFeedback::ConstantForceEffect();
auto time = TimeSpan(10000);

effect->SetParameters(Windows::Foundation::Numerics::float3(1.0f, 0.0f, 0.0f), time);

// Here, we assume 'racingwheel' is valid and supports force feedback

IAsyncOperation<FFLoadEffectResult>^ request
    = racingwheel->WheelMotor->LoadEffectAsync(effect);

auto loadEffectTask = Concurrency::create_task(request);

loadEffectTask.then([this](FFLoadEffectResult result)
{
    if (FFLoadEffectResult::Succeeded == result)
    {
        // effect successfully loaded
    }
    else
    {
        // effect failed to load
    }
}).wait();
```

### <a name="using-force-feedback-effects"></a><span data-ttu-id="53e95-263">フォース フィードバック効果の使用</span><span class="sxs-lookup"><span data-stu-id="53e95-263">Using force feedback effects</span></span>

<span data-ttu-id="53e95-264">効果は読み込まれると、レーシング ハンドルの `WheelMotor` プロパティで関数を呼び出して同期的にまとめて開始、一時停止、再開、停止を行うことも、フィードバック効果自体で関数を呼び出して個別に行うこともできrます。</span><span class="sxs-lookup"><span data-stu-id="53e95-264">Once loaded, effects can all be started, paused, resumed, and stopped synchronously by calling functions on the `WheelMotor` property of the racing wheel, or individually by calling functions on the feedback effect itself.</span></span> <span data-ttu-id="53e95-265">通常は、ゲームプレイを開始する前に使用するすべての効果をフィードバック デバイスに読み込んでおき、ゲームプレイの進行に合わせて、それぞれの `SetParameters` 関数を使用して効果を更新することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="53e95-265">Typically, you should load all the effects that you want to use onto the feedback device before gameplay begins and then use their respective `SetParameters` functions to update the effects as gameplay progresses.</span></span>

```cpp
if (ForceFeedbackEffectState::Running == effect->State)
{
    effect->Stop();
}
else
{
    effect->Start();
}
```

<span data-ttu-id="53e95-266">また、必要な場合はいつでも、特定のレーシング ハンドルで、フォース フィードバック システム全体を非同期に有効化、無効化、またはリセットできます。</span><span class="sxs-lookup"><span data-stu-id="53e95-266">Finally, you can asynchronously enable, disable, or reset the entire force feedback system on a particular racing wheel whenever you need.</span></span>

## <a name="see-also"></a><span data-ttu-id="53e95-267">関連項目</span><span class="sxs-lookup"><span data-stu-id="53e95-267">See also</span></span>

* [<span data-ttu-id="53e95-268">Windows.Gaming.Input.UINavigationController</span><span class="sxs-lookup"><span data-stu-id="53e95-268">Windows.Gaming.Input.UINavigationController</span></span>][]
* [<span data-ttu-id="53e95-269">Windows.Gaming.Input.IGameController</span><span class="sxs-lookup"><span data-stu-id="53e95-269">Windows.Gaming.Input.IGameController</span></span>][]
* [<span data-ttu-id="53e95-270">ゲームの入力プラクティス</span><span class="sxs-lookup"><span data-stu-id="53e95-270">Input practices for games</span></span>](input-practices-for-games.md)

[<span data-ttu-id="53e95-271">Windows.Gaming.Input</span><span class="sxs-lookup"><span data-stu-id="53e95-271">Windows.Gaming.Input</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[<span data-ttu-id="53e95-272">Windows.Gaming.Input.UINavigationController</span><span class="sxs-lookup"><span data-stu-id="53e95-272">Windows.Gaming.Input.UINavigationController</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.aspx
[<span data-ttu-id="53e95-273">Windows.Gaming.Input.IGameController</span><span class="sxs-lookup"><span data-stu-id="53e95-273">Windows.Gaming.Input.IGameController</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[<span data-ttu-id="53e95-274">racingwheel</span><span class="sxs-lookup"><span data-stu-id="53e95-274">racingwheel</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.aspx
[racingwheels]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.racingwheels.aspx
[racingwheeladded]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.racingwheeladded.aspx
[racingwheelremoved]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.racingwheelremoved.aspx
[<span data-ttu-id="53e95-275">haspatternshifter</span><span class="sxs-lookup"><span data-stu-id="53e95-275">haspatternshifter</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.haspatternshifter.aspx
[<span data-ttu-id="53e95-276">hashandbrake</span><span class="sxs-lookup"><span data-stu-id="53e95-276">hashandbrake</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.hashandbrake.aspx
[<span data-ttu-id="53e95-277">hasclutch</span><span class="sxs-lookup"><span data-stu-id="53e95-277">hasclutch</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.hasclutch.aspx
[<span data-ttu-id="53e95-278">maxpatternshiftergear</span><span class="sxs-lookup"><span data-stu-id="53e95-278">maxpatternshiftergear</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.maxpatternshiftergear.aspx
[maxwheelangle]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.maxwheelangle.aspx
[<span data-ttu-id="53e95-279">getcurrentreading</span><span class="sxs-lookup"><span data-stu-id="53e95-279">getcurrentreading</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.getcurrentreading.aspx
[<span data-ttu-id="53e95-280">wheelmotor</span><span class="sxs-lookup"><span data-stu-id="53e95-280">wheelmotor</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.wheelmotor.aspx
[<span data-ttu-id="53e95-281">racingwheelreading</span><span class="sxs-lookup"><span data-stu-id="53e95-281">racingwheelreading</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheelreading.aspx
[<span data-ttu-id="53e95-282">racingwheelbuttons</span><span class="sxs-lookup"><span data-stu-id="53e95-282">racingwheelbuttons</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheelbuttons.aspx
