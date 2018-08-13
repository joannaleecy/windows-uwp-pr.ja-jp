---
title: 喪失デバイス
description: Direct3D デバイスの状態は、動作状態と喪失状態のどちらかです。
ms.assetid: 1639CC02-8000-4208-AA95-91C1F0A3B08D
keywords:
- 喪失デバイス
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: e46adf3826749bd974951a54166a6e2afa3702e8
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1044581"
---
# <a name="lost-devices"></a><span data-ttu-id="24d2f-104">喪失デバイス</span><span class="sxs-lookup"><span data-stu-id="24d2f-104">Lost devices</span></span>


<span data-ttu-id="24d2f-105">Direct3D デバイスは、稼働状態または喪失状態に設定できます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-105">A Direct3D device can be in either an operational state or a lost state.</span></span> <span data-ttu-id="24d2f-106">*稼働*状態は、デバイスが実行され、期待どおりにすべてのレンダリングが表示される、デバイスの通常の状態です。</span><span class="sxs-lookup"><span data-stu-id="24d2f-106">The *operational* state is the normal state of the device in which the device runs and presents all rendering as expected.</span></span> <span data-ttu-id="24d2f-107">デバイスは、イベント (全画面アプリケーションにおけるキーボード フォーカスの喪失など) によってレンダリングが不可能になると*喪失*状態に遷移します。</span><span class="sxs-lookup"><span data-stu-id="24d2f-107">The device makes a transition to the *lost* state when an event, such as the loss of keyboard focus in a full-screen application, causes rendering to become impossible.</span></span> <span data-ttu-id="24d2f-108">喪失状態には、すべてのレンダリング操作のサイレント エラーという特徴があります。つまり、レンダリング操作に失敗しても、レンダリング メソッドが成功コードを返すことがあります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-108">The lost state is characterized by the silent failure of all rendering operations, which means that the rendering methods can return success codes even though the rendering operations fail.</span></span>

<span data-ttu-id="24d2f-109">仕様上、デバイスが喪失になる可能性があるあらゆるシナリオ セットが定められているわけではありません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-109">By design, the full set of scenarios that can cause a device to become lost is not specified.</span></span> <span data-ttu-id="24d2f-110">一般的な例には、ユーザーが Alt + Tab を押した場合やシステム ダイアログが初期化された場合など、フォーカスの喪失が含まれます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-110">Some typical examples include loss of focus, such as when the user presses ALT+TAB or when a system dialog is initialized.</span></span> <span data-ttu-id="24d2f-111">電源管理インベントや、別のアプリケーションが全画面操作を引き受けた場合などのためにデバイスが喪失することもあります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-111">Devices can also be lost due to a power management event, or when another application assumes full-screen operation.</span></span> <span data-ttu-id="24d2f-112">加えて、デバイスのリセットによるエラーによってもデバイスが喪失状態になります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-112">In addition, any failure from reseting a device puts the device into a lost state.</span></span>

<span data-ttu-id="24d2f-113">[**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) から派生したすべてのメソッドは、デバイスが喪失した後も動作することが保証されています。</span><span class="sxs-lookup"><span data-stu-id="24d2f-113">All methods that derive from [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) are guaranteed to work after a device is lost.</span></span> <span data-ttu-id="24d2f-114">デバイスの喪失後、各機能には一般に次の 3 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-114">After device loss, each function generally has the following three options:</span></span>

-   <span data-ttu-id="24d2f-115">"デバイス喪失" エラーによって失敗する - これは、何らかの操作が正常でないことをアプリケーションが識別できるように、そのデバイスが喪失したことをアプリケーションが認識する必要があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="24d2f-115">Fail with a "device lost" error - This means that the application needs to recognize that the device was lost, so that the application identifies that something isn't happening as expected.</span></span>
-   <span data-ttu-id="24d2f-116">サイレント エラーが発生し、S\_OK または他のリターン コードを返す - 機能でサイレント エラーが発生した場合、アプリケーションは "成功" の結果と "サイレント エラー" の結果を区別することができません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-116">Silently fail, returning S\_OK or any other return code - If a function silently fails, the application generally can't distinguish between the result of "success" and a "silent failure."</span></span>
-   <span data-ttu-id="24d2f-117">リターン コードを返す。</span><span class="sxs-lookup"><span data-stu-id="24d2f-117">Return a return code.</span></span>

## <a name="span-idrespondingtoalostdevicespanspan-idrespondingtoalostdevicespanspan-idrespondingtoalostdevicespanresponding-to-a-lost-device"></a><span data-ttu-id="24d2f-118"><span id="Responding_to_a_Lost_Device"></span><span id="responding_to_a_lost_device"></span><span id="RESPONDING_TO_A_LOST_DEVICE"></span>喪失デバイスへの対応</span><span class="sxs-lookup"><span data-stu-id="24d2f-118"><span id="Responding_to_a_Lost_Device"></span><span id="responding_to_a_lost_device"></span><span id="RESPONDING_TO_A_LOST_DEVICE"></span>Responding to a Lost Device</span></span>


<span data-ttu-id="24d2f-119">喪失デバイスは、リセット後にリソース (ビデオ メモリ リソースなど) を再作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-119">A lost device must re-create resources (including video memory resources) after it has been reset.</span></span> <span data-ttu-id="24d2f-120">デバイスが喪失した場合、アプリケーションは動作状態に復元できるかどうかを確認するようデバイスに問い合わせます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-120">If a device is lost, the application queries the device to see if it can be restored to the operational state.</span></span> <span data-ttu-id="24d2f-121">復元でない場合、アプリケーションはデバイスが復元可能になるまで待機します。</span><span class="sxs-lookup"><span data-stu-id="24d2f-121">If not, the application waits until the device can be restored.</span></span>

<span data-ttu-id="24d2f-122">デバイスが復元可能な場合、アプリケーションはすべてのビデオ メモリ リソースとスワップ チェーンを破棄することによってデバイスを準備します。</span><span class="sxs-lookup"><span data-stu-id="24d2f-122">If the device can be restored, the application prepares the device by destroying all video-memory resources and any swap chains.</span></span> <span data-ttu-id="24d2f-123">リセットは、デバイスが喪失したときに効果がある唯一の手順であり、アプリケーションがデバイスを喪失状態から動作状態に変えることができる唯一の方法です。</span><span class="sxs-lookup"><span data-stu-id="24d2f-123">Resetting is the only procedure that has an effect when a device is lost, and is the only way by which an application can change the device from a lost to an operational state.</span></span> <span data-ttu-id="24d2f-124">アプリケーションが割り当てられたすべてのリソース (レンダー ターゲットや深度ステンシル サーフェスなど) を解放しなければ、リセットに失敗します。</span><span class="sxs-lookup"><span data-stu-id="24d2f-124">Reset will fail unless the application releases all resources that are allocated, including render targets and depth-stencil surfaces.</span></span>

<span data-ttu-id="24d2f-125">ほとんどの場合、Direct3D を高頻度で呼び出すと、デバイスが喪失したかどうかに関する情報が返されません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-125">For the most part, the high-frequency calls of Direct3D do not return any information about whether the device has been lost.</span></span> <span data-ttu-id="24d2f-126">アプリケーションは、レンダリング メソッドの呼び出しを続けますが、喪失デバイスの通知は受け取りません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-126">The application can continue to call rendering methods, without receiving notification of a lost device.</span></span> <span data-ttu-id="24d2f-127">内部では、デバイスが動作状態にリセットされるまでこれらの操作は破棄されます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-127">Internally, these operations are discarded until the device is reset to the operational state.</span></span>

## <a name="span-idlockingoperationsspanspan-idlockingoperationsspanspan-idlockingoperationsspanlocking-operations"></a><span data-ttu-id="24d2f-128"><span id="Locking_Operations"></span><span id="locking_operations"></span><span id="LOCKING_OPERATIONS"></span>ロック操作</span><span class="sxs-lookup"><span data-stu-id="24d2f-128"><span id="Locking_Operations"></span><span id="locking_operations"></span><span id="LOCKING_OPERATIONS"></span>Locking Operations</span></span>


<span data-ttu-id="24d2f-129">内部では、デバイスが喪失した後にロック操作を成功させるための処理を Direct3D は十分に行いません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-129">Internally, Direct3D does enough work to ensure that a lock operation will succeed after a device is lost.</span></span> <span data-ttu-id="24d2f-130">ただし、ロック操作中にビデオ メモリ リソースのデータが正確であることは保証されません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-130">However, it is not guaranteed that the video-memory resource's data will be accurate during the lock operation.</span></span> <span data-ttu-id="24d2f-131">エラー コードが返されないことは保証されます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-131">It is guaranteed that no error code will be returned.</span></span> <span data-ttu-id="24d2f-132">このため、ロック操作中にデバイスが喪失することを気にせずにアプリケーションを記述できます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-132">This allows applications to be written without concern for device loss during a lock operation.</span></span>

## <a name="span-idresourcesspanspan-idresourcesspanspan-idresourcesspanresources"></a><span data-ttu-id="24d2f-133"><span id="Resources"></span><span id="resources"></span><span id="RESOURCES"></span>リソース</span><span class="sxs-lookup"><span data-stu-id="24d2f-133"><span id="Resources"></span><span id="resources"></span><span id="RESOURCES"></span>Resources</span></span>


<span data-ttu-id="24d2f-134">リソースは、ビデオ メモリを消費する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-134">Resources can consume video memory.</span></span> <span data-ttu-id="24d2f-135">喪失デバイスはアダプターが所有するビデオ メモリから切断されるため、デバイス喪失したときにビデオ メモリの割り当てを保証することはできません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-135">Because a lost device is disconnected from the video memory owned by the adapter, it is not possible to guarantee allocation of video memory when the device is lost.</span></span> <span data-ttu-id="24d2f-136">このため、すべてのリソース作成メソッドが成功するように実装されていますが、実際にはダミー システム メモリのみ割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-136">As a result, all resource creation methods are implemented to succeed, but do in fact allocate only dummy system memory.</span></span> <span data-ttu-id="24d2f-137">デバイスをサイズ変更する前にビデオ メモリ リソースを破棄する必要があるため、ビデオ メモリの過剰割り当ての問題は発生しません。</span><span class="sxs-lookup"><span data-stu-id="24d2f-137">Because any video-memory resource must be destroyed before the device is resized, there is no issue of over-allocating video memory.</span></span> <span data-ttu-id="24d2f-138">これらのダミー サーフェスにより、そのデバイスが喪失したことをアプリケーションが検出するまでロック操作とコピー操作が正常に機能しているように見えます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-138">These dummy surfaces allow lock and copy operations to appear to function normally until the application discovers that the device has been lost.</span></span>

<span data-ttu-id="24d2f-139">デバイスを喪失状態から動作状態にリセットするには、すべてのビデオ メモリを解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-139">All video memory must be released before a device can be reset from a lost state to an operational state.</span></span> <span data-ttu-id="24d2f-140">他の状態データは、動作状態への遷移時に自動的に破棄されます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-140">Other state data is automatically destroyed by the transition to an operational state.</span></span>

<span data-ttu-id="24d2f-141">デバイス喪失に対応するため、単一のコード パスでアプリケーションを開発することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24d2f-141">You are encouraged to develop applications with a single code path to respond to device loss.</span></span> <span data-ttu-id="24d2f-142">このコード パスは、起動時にデバイスを初期化するコード パスとまったく同じとは言わないまでもほぼ同様です。</span><span class="sxs-lookup"><span data-stu-id="24d2f-142">This code path is likely to be similar, if not identical, to the code path taken to initialize the device at startup.</span></span>

## <a name="span-idretrieveddataspanspan-idretrieveddataspanspan-idretrieveddataspanretrieved-data"></a><span data-ttu-id="24d2f-143"><span id="Retrieved_Data"></span><span id="retrieved_data"></span><span id="RETRIEVED_DATA"></span>取得されたデータ</span><span class="sxs-lookup"><span data-stu-id="24d2f-143"><span id="Retrieved_Data"></span><span id="retrieved_data"></span><span id="RETRIEVED_DATA"></span>Retrieved Data</span></span>


<span data-ttu-id="24d2f-144">Direct3D を使うと、アプリケーションはテクスチャを検証し、ハードウェアによる単一パス レンダリングとは異なる方法で状態をレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-144">Direct3D allows applications to validate texture and render states against single pass rendering by the hardware.</span></span>

<span data-ttu-id="24d2f-145">さらに、Direct3D を使うと、アプリケーションは生成されたイメージや以前に書き込まれたイメージをビデオ メモリ リソースから不揮発性システム メモリ リソースにコピーできます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-145">Direct3D also allows applications to copy generated or previously written images from video-memory resources to nonvolatile system-memory resources.</span></span> <span data-ttu-id="24d2f-146">そのような転送のソース イメージはいつでも失われる可能性があるため、Direct3D ではデバイスが喪失するとそのコピー操作を失敗させることができます。</span><span class="sxs-lookup"><span data-stu-id="24d2f-146">Because the source images of such transfers might be lost at any time, Direct3D allows such copy operations to fail when the device is lost.</span></span>

<span data-ttu-id="24d2f-147">デバイスが喪失すると、プライマリ サーフェスがないためコピー操作が失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-147">Copy operations can fail as there is no primary surface when the device is lost.</span></span> <span data-ttu-id="24d2f-148">デバイスが喪失するとバック バッファーを作成できないため、スワップ チェーンの作成も失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="24d2f-148">Creating swap chains can also fail because a back buffer can't be created when the device is lost.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="24d2f-149"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="24d2f-149"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="24d2f-150">デバイス</span><span class="sxs-lookup"><span data-stu-id="24d2f-150">Devices</span></span>](devices.md)

 

 




