---
title: ヘッドセット
description: Windows.Gaming.Input ヘッドセット API を使用して、ヘッドセットの検出、プレイヤーの音声のキャプチャ、オーディオの再生を行います。
ms.assetid: 021CCA26-D339-4C8B-B084-0D499BD83ABE
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, ヘッドセット
ms.localizationpriority: medium
ms.openlocfilehash: b3de68cc59c9928a52eba5caeb840e9e825eecf0
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7989445"
---
# <a name="headset"></a><span data-ttu-id="d833c-104">ヘッドセット</span><span class="sxs-lookup"><span data-stu-id="d833c-104">Headset</span></span>

<span data-ttu-id="d833c-105">このページでは、[Windows.Gaming.Input.Headset][headset] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、ヘッドセットを対象にしたプログラミングの基礎について説明します。</span><span class="sxs-lookup"><span data-stu-id="d833c-105">This page describes the basics of programming for headsets using [Windows.Gaming.Input.Headset][headset] and related APIs for the Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="d833c-106">ここでは、次の項目について紹介します。</span><span class="sxs-lookup"><span data-stu-id="d833c-106">By reading this page, you'll learn:</span></span>
* <span data-ttu-id="d833c-107">入力デバイスまたはナビゲーション デバイスに接続されているヘッドセットにアクセスする方法</span><span class="sxs-lookup"><span data-stu-id="d833c-107">How to access a headset that's connected to an input or navigation device</span></span>
* <span data-ttu-id="d833c-108">ヘッドセットが接続されている、またはヘッドセットが切断されていることを検出する方法</span><span class="sxs-lookup"><span data-stu-id="d833c-108">How to detect that a headset has been connected or disconnected</span></span>


## <a name="headset-overview"></a><span data-ttu-id="d833c-109">ヘッドセットの概要</span><span class="sxs-lookup"><span data-stu-id="d833c-109">Headset overview</span></span>

<span data-ttu-id="d833c-110">ヘッドセットはオーディオのキャプチャと再生を行うデバイスで、オンライン ゲームで他のプレイヤーと通信するために使用することが多く、ゲームプレイや他の創作活動で使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="d833c-110">Headsets are audio capture and playback devices most often used to communicate with other players in online games but can also be used in gameplay or for other creative uses.</span></span> <span data-ttu-id="d833c-111">ヘッドセットは、Windows 10 および Xbox UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。</span><span class="sxs-lookup"><span data-stu-id="d833c-111">Headsets are supported in Windows 10 and Xbox UWP apps by the [Windows.Gaming.Input][] namespace.</span></span>


## <a name="detect-and-track-headsets"></a><span data-ttu-id="d833c-112">ヘッドセットの検出と追跡</span><span class="sxs-lookup"><span data-stu-id="d833c-112">Detect and track headsets</span></span>

<span data-ttu-id="d833c-113">ヘッドセットはシステムによって管理されるため、ヘッドセットを自分で作成したり初期化する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d833c-113">Headsets are managed by the system, therefore you don't have to create or initialize them.</span></span> <span data-ttu-id="d833c-114">システムによって、ヘッドセットが接続されている入力デバイスを通じてヘッドセットへのアクセスが提供され、ヘッドセットが接続または切断されたときにはイベントが通知されます。</span><span class="sxs-lookup"><span data-stu-id="d833c-114">The system provides access to a headset through the input device its connected to and events to notify you when a headset is connected or disconnected.</span></span>

### <a name="igamecontrollerheadset"></a><span data-ttu-id="d833c-115">IGameController.Headset</span><span class="sxs-lookup"><span data-stu-id="d833c-115">IGameController.Headset</span></span>

<span data-ttu-id="d833c-116">[Windows.Gaming.Input][] 名前空間のすべての入力デバイスでは、[IGameController][] インターフェイスが実装されます。このインターフェイスでは、現在デバイスに接続されているヘッドセットとなるように [Headset][igamecontroller.headset] プロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="d833c-116">All input devices in the [Windows.Gaming.Input][] namespace implement the [IGameController][] interface which defines the [Headset][igamecontroller.headset] property to be the headset currently connected to the device.</span></span>

### <a name="connecting-and-disconnecting-headsets"></a><span data-ttu-id="d833c-117">ヘッドセットの接続と切断</span><span class="sxs-lookup"><span data-stu-id="d833c-117">Connecting and disconnecting headsets.</span></span>

<span data-ttu-id="d833c-118">ヘッドセットを接続または切断すると、[HeadsetConnected][igamecontroller.headsetconnected] および [HeadsetDisconnected][igamecontroller.headsetdisconnected] イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="d833c-118">When a headset is connected or disconnected, the [HeadsetConnected][igamecontroller.headsetconnected] and [HeadsetDisconnected][igamecontroller.headsetdisconnected] events are raised.</span></span> <span data-ttu-id="d833c-119">入力デバイスに現在ヘッドセットが接続されているかどうかを追跡するため、これらのイベントのハンドラーを登録できます。</span><span class="sxs-lookup"><span data-stu-id="d833c-119">You can register handlers for these events to keep track of whether an input device currently has a headset connected to it.</span></span>

<span data-ttu-id="d833c-120">次の例は、`HeadsetConnected` イベントのハンドラーを登録する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d833c-120">The following example shows how to register a handler for the `HeadsetConnected` event.</span></span>

```cpp
auto inputDevice = myGamepads[0]; // or arcade stick, racing wheel

inputDevice.HeadsetConnected += ref new TypedEventHandler<IGameController^, Headset^>(IGameController^ device, Headset^ headset)
{
    // enable headset capture and playback on this device
}
```

<span data-ttu-id="d833c-121">次の例は、`HeadsetDisconnected` イベントのハンドラーを登録する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d833c-121">The following example shows how to register a handler for the `HeadsetDisconnected` event.</span></span>

```cpp
auto inputDevice = myGamepads[0]; // or arcade stick, racing wheel

inputDevice.HeadsetDisconnected += ref new TypedEventHandler<IGameController^, Headset^>(IGameController^ device, Headset^ headset)
{
    // disable headset capture and playback on this device
}
```

## <a name="using-the-headset"></a><span data-ttu-id="d833c-122">ヘッドセットの使用</span><span class="sxs-lookup"><span data-stu-id="d833c-122">Using the headset</span></span>

<span data-ttu-id="d833c-123">[Headset][] クラスは、XAudio エンドポイント ID を表す 2 つの文字列で構成されています。1 つはオーディオ キャプチャ (ヘッドセット マイクからの録音) 用の文字列で、もう 1 つはオーディオ レンダリング (ヘッドセットのイヤホンを使用した再生) 用の文字列です。</span><span class="sxs-lookup"><span data-stu-id="d833c-123">The [Headset][] class is made up of two strings that represent XAudio endpoint IDs--one for audio capture (recording from the headset microphone) and one for audio rendering (playback through the headset earpiece).</span></span>

<span data-ttu-id="d833c-124">ここでは XAudio の使用の詳細については説明しませんが、詳しくは、[XAudio2 プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/ee415737.aspx)や [XAudio2 API リファレンス](https://msdn.microsoft.com/library/windows/desktop/ee415899.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d833c-124">The details of working with XAudio are not discussed here, for more information see the [XAudio2 programming guide](https://msdn.microsoft.com/library/windows/desktop/ee415737.aspx) and [XAudio2 API reference](https://msdn.microsoft.com/library/windows/desktop/ee415899.aspx).</span></span>


[<span data-ttu-id="d833c-125">Windows.Gaming.Input</span><span class="sxs-lookup"><span data-stu-id="d833c-125">Windows.Gaming.Input</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[<span data-ttu-id="d833c-126">igamecontroller</span><span class="sxs-lookup"><span data-stu-id="d833c-126">igamecontroller</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[igamecontroller.headset]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.headset.aspx
[igamecontroller.headsetconnected]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.headsetconnected.aspx
[igamecontroller.headsetdisconnected]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.headsetdisconnected.aspx
[<span data-ttu-id="d833c-127">headset</span><span class="sxs-lookup"><span data-stu-id="d833c-127">headset</span></span>]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.headset.aspx
