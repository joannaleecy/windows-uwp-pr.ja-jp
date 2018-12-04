---
title: スワップ チェーン
description: スワップ チェーンは、ユーザーにフレームを表示するために使用されるバッファーのコレクションです。
ms.assetid: A38E8BB7-1E77-4D93-B321-D3572A80D5DD
keywords:
- スワップ チェーン
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 486eb4adc1151bac1bf6a04a8f54b67530b426a3
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8482683"
---
# <a name="swap-chains"></a><span data-ttu-id="782c4-104">スワップ チェーン</span><span class="sxs-lookup"><span data-stu-id="782c4-104">Swap chains</span></span>


<span data-ttu-id="782c4-105">スワップ チェーンは、ユーザーにフレームを表示するために使用されるバッファーのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="782c4-105">A swap chain is a collection of buffers that are used for displaying frames to the user.</span></span> <span data-ttu-id="782c4-106">アプリケーションが表示する新しいフレームを提供するたびに、スワップ チェーンの最初のバッファーが、表示されているバッファーの場所を取得します。</span><span class="sxs-lookup"><span data-stu-id="782c4-106">Each time an application presents a new frame for display, the first buffer in the swap chain takes the place of the displayed buffer.</span></span> <span data-ttu-id="782c4-107">このプロセスは、*スワップ*または*フリップ*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="782c4-107">This process is called *swapping* or *flipping*.</span></span>

<span data-ttu-id="782c4-108">グラフィックス アダプターは、フロント バッファーと呼ばれる、モニター上に表示されるイメージを表すサーフェスへのポインターを保持します。</span><span class="sxs-lookup"><span data-stu-id="782c4-108">A graphics adapter holds a pointer to a surface that represents the image being displayed on the monitor, called a front buffer.</span></span> <span data-ttu-id="782c4-109">モニターが更新されると、グラフィック カードはフロント バッファーのコンテンツを表示先のモニターに送信します。</span><span class="sxs-lookup"><span data-stu-id="782c4-109">As the monitor is refreshed, the graphics card sends the contents of the front buffer to the monitor to be displayed.</span></span> <span data-ttu-id="782c4-110">ただし、リアルタイムのグラフィックをレンダリングする場合、"テアリング" の問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="782c4-110">However, this leads to a "tearing" problem when rendering real-time graphics.</span></span> <span data-ttu-id="782c4-111">この問題の核心は、コンピューターの他のコンポーネントと比べてモニターのリフレッシュ レートが極めて遅いということです。</span><span class="sxs-lookup"><span data-stu-id="782c4-111">The heart of the problem is that monitor refresh rates are very slow in comparison to the rest of the computer.</span></span> <span data-ttu-id="782c4-112">一般的なリフレッシュ レートは、60 Hz (秒当たり 60 回) から 100 Hz です。</span><span class="sxs-lookup"><span data-stu-id="782c4-112">Common refresh rates range from 60 Hz (60 times per second) to 100 Hz.</span></span>

<span data-ttu-id="782c4-113">モニターのリフレッシュの最中に、アプリケーションがフロント バッファーを更新すると、表示されるイメージは半分に分かれ、ディスプレイの上半分には以前のイメージが、下半分には新しいイメージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="782c4-113">If your application is updating the front buffer while the monitor is in the middle of a refresh, the image that is displayed will be cut in half with the upper half of the display containing the old image and the lower half containing the new image.</span></span> <span data-ttu-id="782c4-114">この問題は*テアリング*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="782c4-114">This problem is referred to as *tearing*.</span></span>

## <a name="span-idavoidingtearingspanspan-idavoidingtearingspanspan-idavoidingtearingspanavoiding-tearing"></a><span data-ttu-id="782c4-115"><span id="Avoiding_tearing"></span><span id="avoiding_tearing"></span><span id="AVOIDING_TEARING"></span>テアリングの回避</span><span class="sxs-lookup"><span data-stu-id="782c4-115"><span id="Avoiding_tearing"></span><span id="avoiding_tearing"></span><span id="AVOIDING_TEARING"></span>Avoiding tearing</span></span>


<span data-ttu-id="782c4-116">Direct3D にはテアリングを回避するための方法が 2 種類実装されています。</span><span class="sxs-lookup"><span data-stu-id="782c4-116">Direct3D implements two options to avoid tearing:</span></span>

-   <span data-ttu-id="782c4-117">垂直帰線 (垂直同期) 操作でモニターの更新のみを許可する方法。</span><span class="sxs-lookup"><span data-stu-id="782c4-117">An option to only allow updates of the monitor on the vertical retrace (or vertical sync) operation.</span></span> <span data-ttu-id="782c4-118">通常、モニターは光ピンを水平に移動することでイメージをリフレッシュします。モニターの左上からジグザグに移動して、右下で終了します。</span><span class="sxs-lookup"><span data-stu-id="782c4-118">A monitor typically refreshes its image by moving a light pin horizontally, zigzagging from the top left of the monitor and ending at the bottom right.</span></span> <span data-ttu-id="782c4-119">光ピンが一番下に到達すると、光ピンを左上に戻して、処理が再び開始されるように、光ピンを再補正します。</span><span class="sxs-lookup"><span data-stu-id="782c4-119">When the light pin reaches the bottom, the monitor recalibrates the light pin by moving it back to the upper left so that the process can start again.</span></span>

    <span data-ttu-id="782c4-120">この再補正は垂直同期と呼ばれます。、垂直同期中は、モニターは何も描画しません、ので、描画を再開する、モニターが開始されるまで、フロント バッファーに、更新プログラムは表示されません。</span><span class="sxs-lookup"><span data-stu-id="782c4-120">This recalibration is called a vertical sync. During a vertical sync, the monitor is not drawing anything, so any update to the front buffer will not be seen until the monitor starts to draw again.</span></span> <span data-ttu-id="782c4-121">垂直同期は比較的処理に時間がかかりますが、待機中に複雑なシーンをレンダリングできるほどではありません。</span><span class="sxs-lookup"><span data-stu-id="782c4-121">The vertical sync is relatively slow; however, not slow enough to render a complex scene while waiting.</span></span> <span data-ttu-id="782c4-122">テアリングを回避しつつ、複雑なシーンをレンダリングするには、バック バッファーリングと呼ばれる処理が必要です。</span><span class="sxs-lookup"><span data-stu-id="782c4-122">What is needed to avoid tearing and be able to render complex scenes is a process called back buffering.</span></span>

-   <span data-ttu-id="782c4-123">バック バッファーリングと呼ばれる手法を使用する方法。</span><span class="sxs-lookup"><span data-stu-id="782c4-123">An option to use a technique called back buffering.</span></span> <span data-ttu-id="782c4-124">バック バッファーリングとは、バック バッファーと呼ばれるオフスクリーン サーフェスにシーンを描画する処理です。</span><span class="sxs-lookup"><span data-stu-id="782c4-124">Back buffering is the process of drawing a scene to an off-screen surface, called a back buffer.</span></span> <span data-ttu-id="782c4-125">フロント バッファー以外のサーフェスは、モニターに直接表示されることがないため、オフスクリーン サーフェスと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="782c4-125">Any surface other than the front buffer is called an off-screen surface because it is never directly viewed by the monitor.</span></span>

    <span data-ttu-id="782c4-126">バック バッファーを使用することで、アプリケーションはシステムがアイドル状態 (つまり、ウィンドウ メッセージが待機していない) にあるときに常にシーンをモニターのリフレッシュ レートを考慮することなく自由にレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="782c4-126">By using a back buffer, an application has the freedom to render a scene whenever the system is idle (that is, no windows messages are waiting) without having to consider the monitor's refresh rate.</span></span> <span data-ttu-id="782c4-127">バック バッファーリングでは、バック バッファーをフロント バッファーに移動する方法とタイミングが複雑になります。</span><span class="sxs-lookup"><span data-stu-id="782c4-127">Back buffering brings in an additional complication of how and when to move the back buffer to the front buffer.</span></span>

## <a name="span-idsurfaceflippingspanspan-idsurfaceflippingspanspan-idsurfaceflippingspansurface-flipping"></a><span data-ttu-id="782c4-128"><span id="Surface_flipping"></span><span id="surface_flipping"></span><span id="SURFACE_FLIPPING"></span>サーフェスの反転</span><span class="sxs-lookup"><span data-stu-id="782c4-128"><span id="Surface_flipping"></span><span id="surface_flipping"></span><span id="SURFACE_FLIPPING"></span>Surface flipping</span></span>


<span data-ttu-id="782c4-129">バック バッファーをフロント バッファーに移動する処理は、サーフェスの反転と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="782c4-129">The process of moving the back buffer to the front buffer is called surface flipping.</span></span> <span data-ttu-id="782c4-130">グラフィック カードでは、単純にサーフェスへのポインターを使用してフロント バッファーを表すため、ポインターを変更するだけでバック バッファーをフロント バッファーに設定できます。</span><span class="sxs-lookup"><span data-stu-id="782c4-130">Because the graphics card simply uses a pointer to a surface to represent the front buffer, a simple pointer change is all that is needed to set the back buffer to the front buffer.</span></span> <span data-ttu-id="782c4-131">アプリケーションが Direct3D にバック バッファーをフロント バッファーに表示するように要求すると、Direct3D は単純に 2 つのサーフェス ポインターを "反転" します。</span><span class="sxs-lookup"><span data-stu-id="782c4-131">When an application asks Direct3D to present the back buffer to the front buffer, Direct3D simply "flips" the two surface pointers.</span></span> <span data-ttu-id="782c4-132">これによって、バック バッファーは新しいフロント バッファーになり、古いフロント バッファーは新しいバック バッファーになります。</span><span class="sxs-lookup"><span data-stu-id="782c4-132">The result is that the back buffer is now the new front buffer, and the old front buffer is the new back buffer.</span></span>

<span data-ttu-id="782c4-133">サーフェス フリップはアプリケーションがバック バッファーを表示するように Direct3D デバイスに要求するたびに呼び出されます。ただし、垂直同期が発生するまで要求をキューに入れるように Direct3D を設定できます。</span><span class="sxs-lookup"><span data-stu-id="782c4-133">A surface flip is invoked whenever an application asks the Direct3D device to present the back buffer; however, Direct3D can be set up to queue the requests until a vertical sync occurs.</span></span> <span data-ttu-id="782c4-134">このオプションは、Direct3D デバイスの表示間隔と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="782c4-134">This option is referred to as the Direct3D device's presentation interval.</span></span> <span data-ttu-id="782c4-135">アプリケーションが Direct3D でサーフェスの反転を処理する方法を指定している方法によっては、新しいバック バッファーのデータは、再利用できないことがあります。</span><span class="sxs-lookup"><span data-stu-id="782c4-135">The data in the new back buffer may not be reusable, depending on how an application specifies how Direct3D should handle surface flipping.</span></span>

<span data-ttu-id="782c4-136">サーフェスの反転は、マルチメディア、アニメーション、ゲーム ソフトウェアでは重要です。これはパラパラ漫画を作成する方法と同じです。</span><span class="sxs-lookup"><span data-stu-id="782c4-136">Surface flipping is key in multimedia, animation, and game software; it is equivalent to the way you can do animation with a pad of paper.</span></span> <span data-ttu-id="782c4-137">作成者は図を 1 ページずつ変えて行き、紙をすばやくめくると絵が動いているように見えます。</span><span class="sxs-lookup"><span data-stu-id="782c4-137">On each page, the artist changes the figures slightly, so that when you flip rapidly between sheets, the drawing appears animated.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="782c4-138"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="782c4-138"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="782c4-139">デバイス</span><span class="sxs-lookup"><span data-stu-id="782c4-139">Devices</span></span>](devices.md)

 

 




