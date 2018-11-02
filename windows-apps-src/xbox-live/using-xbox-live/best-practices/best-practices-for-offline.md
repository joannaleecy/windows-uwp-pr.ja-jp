---
title: オフラインのベスト プラクティス
author: KevinAsgari
description: Xbox Live 対応のタイトルのオフライン シナリオを処理するためのベスト プラクティスについて説明します。
ms.assetid: 6290dd67-1145-4fe2-8ada-c3a29a9ad29a
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, オフライン
ms.localizationpriority: medium
ms.openlocfilehash: a552f275a69fde67f22d25a79b5b8c318c4f8dc3
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5922346"
---
# <a name="best-practices-for-offline"></a><span data-ttu-id="de3d5-104">オフラインのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="de3d5-104">Best practices for offline</span></span>

<span data-ttu-id="de3d5-105">Xbox One はインターネット接続を前提にしたデバイスとして設計されており、マルチプレイヤー ゲームやビデオ ストリーミングのような最高の体験を得るにはインターネット接続が必要です。</span><span class="sxs-lookup"><span data-stu-id="de3d5-105">Xbox One is designed as a connected device, and the best experiences, such as multiplayer gaming and video streaming, require connectivity.</span></span> <span data-ttu-id="de3d5-106">ただし、Xbox One はさまざまな形態のオフライン プレイもサポートします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-106">However, Xbox One does support many forms of offline play.</span></span> <span data-ttu-id="de3d5-107">このトピックでは、オフライン プレイの取り扱い方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-107">This topic discusses how to handle offline play.</span></span>

## <a name="overview"></a><span data-ttu-id="de3d5-108">概要</span><span class="sxs-lookup"><span data-stu-id="de3d5-108">Overview</span></span>

<span data-ttu-id="de3d5-109">インターネットにアクセスできる世界中のユーザーの数は増え続けています。</span><span class="sxs-lookup"><span data-stu-id="de3d5-109">An ever-growing number of consumers worldwide have access to the Internet.</span></span> <span data-ttu-id="de3d5-110">ただし、接続状況が予測不能な場所も世界にはまだ存在し、ルーターの故障、回線の切断、サーバーのクラッシュ、ワイヤレス サービスの停止などが起きる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-110">However, there are still places in the world where connectivity is unpredictable, and there are times when routers fail, fiber is cut, servers crash, or wireless services drop.</span></span>

<span data-ttu-id="de3d5-111">できるだけ多くのユーザー、多様な体験に対応するために、Xbox One ではインターネット接続がときどき失われる、または完全に利用不能となる一般的なケースを許容します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-111">To support the widest set of consumers and experiences, Xbox One allows for common cases where Internet connectivity is lost from time to time or is unavailable altogether.</span></span> <span data-ttu-id="de3d5-112">ゲームには接続障害が通知され、ゲーム側でどのように対応するか (完全なゲームプレイを継続するか、オフライン モードにダウングレードするか、それともゲームプレイを完全に終了するか) は自由に選択できます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-112">Your game is informed of connectivity failures, and you are free to choose how to respond—whether that’s continuing full gameplay, downgrading to an offline mode, or ending gameplay altogether.</span></span>

## <a name="normal-online-operation"></a><span data-ttu-id="de3d5-113">通常のオンライン動作</span><span class="sxs-lookup"><span data-stu-id="de3d5-113">Normal online operation</span></span>

<span data-ttu-id="de3d5-114">Xbox One は通常、完全に接続されている状態で動作します。これは、ユーザーが安定的にインターネットに接続し、Xbox Live およびサードパーティーのサービスに完全にアクセスできる状態のことです。</span><span class="sxs-lookup"><span data-stu-id="de3d5-114">In general, Xbox One consoles operate in a fully-connected state, where the user has a steady Internet connection and full access to Xbox Live and to third-party services.</span></span> <span data-ttu-id="de3d5-115">この接続状態では、Xbox Live サービスが定期的に本体の状態を検証したり、アップデートを提供したり、ゲームやユーザーのためにその他のバックグラウンド サービスを実行したりできます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-115">This connected state allows the Xbox Live service to periodically validate the console state, to provide updates, and to perform other background services that benefit your game and users.</span></span>

<span data-ttu-id="de3d5-116">ユーザーがほぼ常時オンラインに接続していると想定することが推奨されます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-116">We recommend that you assume that users have online connectivity the majority of the time.</span></span>

## <a name="offline-play-principles"></a><span data-ttu-id="de3d5-117">オフライン プレイの原則</span><span class="sxs-lookup"><span data-stu-id="de3d5-117">Offline play principles</span></span>

<span data-ttu-id="de3d5-118">オンライン接続が利用できない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-118">There are cases where an online connection is unavailable.</span></span> <span data-ttu-id="de3d5-119">オフライン プレイに対応するため、Xbox One は以下の原則を念頭に置いて設計されています。</span><span class="sxs-lookup"><span data-stu-id="de3d5-119">For offline play, Xbox One is designed with the following principles in mind:</span></span>

-   <span data-ttu-id="de3d5-120">最も重要な点として、接続の問題が起きた場合でもユーザーがプレイを続けられるようにします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-120">Most importantly, keep users playing despite connectivity issues.</span></span>

-   <span data-ttu-id="de3d5-121">まったく接続していない場合でもユーザーがプレイを続けられるようにします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-121">Keep users playing even if they have no connection at all.</span></span>

-   <span data-ttu-id="de3d5-122">常時接続の主旨を保ちつつ、ユーザーにとってシンプルで予測しやすいオフライン プレイを提供します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-122">Make offline play simple and predictable for users, while still maintaining the spirit of an always-connected experience.</span></span>

## <a name="offline-modes"></a><span data-ttu-id="de3d5-123">オフライン モード</span><span class="sxs-lookup"><span data-stu-id="de3d5-123">Offline modes</span></span>

<span data-ttu-id="de3d5-124">*接続喪失*のシナリオは 2 つに大別されます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-124">There are two high-level *loss of connectivity* scenarios:</span></span>

-   <span data-ttu-id="de3d5-125">すべてのインターネット サービスにアクセスできない</span><span class="sxs-lookup"><span data-stu-id="de3d5-125">Complete loss of Internet service</span></span>

-   <span data-ttu-id="de3d5-126">1 つ以上のオンライン サービスにアクセスできない</span><span class="sxs-lookup"><span data-stu-id="de3d5-126">Loss of one or more online services</span></span>

<span data-ttu-id="de3d5-127">これらのモードのそれぞれにおいて、さまざまな状況が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-127">In each of these modes, there are a variety of situations that can arise.</span></span> <span data-ttu-id="de3d5-128">これらのモードについて、ゲームプレイに影響を及ぼす一般的なオフライン シナリオの例と共に以下で説明します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-128">These are explained below with examples of common offline scenarios that impact gameplay.</span></span>

## <a name="offline-scenario-no-internet-service-upon-game-start"></a><span data-ttu-id="de3d5-129">オフラインのシナリオ: ゲーム開始時にインターネット サービスが利用できない</span><span class="sxs-lookup"><span data-stu-id="de3d5-129">Offline scenario: no Internet service upon game start</span></span>

<span data-ttu-id="de3d5-130">以下の 3 つのタイプのいずれかとしてゲームを宣言することができます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-130">Games may declare themselves as one of three types:</span></span>

-   <span data-ttu-id="de3d5-131">*Xbox Live required (Xbox Live 必須)*: ゲームプレイのすべてのモードでインターネット接続が必要です。</span><span class="sxs-lookup"><span data-stu-id="de3d5-131">*Xbox Live required*: all modes of gameplay require Internet connectivity.</span></span>

-   <span data-ttu-id="de3d5-132">*Xbox Live Gold required (Xbox Live ゴールド必須)*: ゲームプレイのすべてのモードで、インターネット接続と Xbox Live ゴールド メンバーシップが必要です。</span><span class="sxs-lookup"><span data-stu-id="de3d5-132">*Xbox Live Gold required*: all modes of gameplay require Internet connectivity and an Xbox Live Gold membership.</span></span>

-   <span data-ttu-id="de3d5-133">*Xbox Live not required (Xbox Live 不要)*: インターネット接続を必要としない 1 つ以上のプレイ モードがゲームに用意されています。</span><span class="sxs-lookup"><span data-stu-id="de3d5-133">*Xbox Live not required*: the game has at least one mode of play that doesn’t require Internet connectivity.</span></span> <span data-ttu-id="de3d5-134">厳密には、このタイプはアプリケーション マニフェストで明示的に宣言されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-134">Technically, this type is not explicitly declared in the application manifest.</span></span> <span data-ttu-id="de3d5-135">最初の 2 つのタイプのどちらとしても宣言されないアプリが "Xbox Live not required"、つまりオフラインをサポートしていると見なされます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-135">An app that doesn’t declare itself as one of the first two types is considered “Xbox Live not required,” or offline supported.</span></span>

<span data-ttu-id="de3d5-136">ユーザーがゲームを開始した時点で本体がオフラインの場合、システムはゲームの接続に関するアプリケーション マニフェストの宣言をチェックします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-136">When a game is started by the user and the console is offline, the system checks the game connectivity declaration in the application manifest.</span></span> <span data-ttu-id="de3d5-137">ゲームに接続が必要な (前に挙げた最初の 2 つのケースのいずれかに該当する) 場合、システムは自動的にメッセージをユーザーに表示し、タイトルを起動しません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-137">If the game requires connectivity (either of the first two cases above), the system automatically displays a message to the user and does not launch the title.</span></span>

<span data-ttu-id="de3d5-138">本体がオフラインの場合、システムは、接続を必要としない 1 つ以上のプレイ モードがあるタイトルのみを起動します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-138">If the console is offline, the system will only launch titles that have at least one mode of play that doesn’t require connectivity.</span></span> <span data-ttu-id="de3d5-139">つまり、システムは "Xbox Live required" または "Xbox Live Gold required" のタイトルを起動しません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-139">In other words, the system will not launch “Xbox Live required” or “Xbox Live Gold required” titles.</span></span>

## <a name="offline-scenario-connectivity-lost-during-gameplay"></a><span data-ttu-id="de3d5-140">オフラインのシナリオ: ゲームプレイ中の接続の喪失</span><span class="sxs-lookup"><span data-stu-id="de3d5-140">Offline scenario: connectivity lost during gameplay</span></span>

<span data-ttu-id="de3d5-141">ゲームの実行中に接続が失われた場合、タイトルはシステムから通知を受けます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-141">If a game is already running when connectivity is lost, the title will be notified by the system.</span></span> <span data-ttu-id="de3d5-142">ゲームがオンライン サービスを使用していない場合、中断せずにセッションを継続してください。</span><span class="sxs-lookup"><span data-stu-id="de3d5-142">If the game is not using online services, continue the session without interruption.</span></span> <span data-ttu-id="de3d5-143">ゲームがオンライン サービスをアクティブに使用している場合、オンライン サービスが必要でないモードに切り替えるか、あるいは、オフライン状態が原因でゲーム セッションが終了することをプレイヤーに通知してください。</span><span class="sxs-lookup"><span data-stu-id="de3d5-143">If the game is actively using online services, either switch to a mode where those services are no longer needed or inform the player that the gaming session is ending due to the offline state.</span></span>

<span data-ttu-id="de3d5-144">"Xbox Live required" または "Xbox Live Gold required" と宣言されたタイトルは、本体が一定時間すべてのネットワーク接続を失った時点でシステムによって自動的に中断され、システムは自動的にエラー メッセージをユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-144">Titles that are declared “Xbox Live required” or “Xbox Live Gold required” will be automatically suspended by the system when the console loses all network connectivity for a period of time, and the system will automatically provide an error message to the user.</span></span>

<span data-ttu-id="de3d5-145">ゲームプレイの中断を伴う他のシナリオと同様、ユーザーがデータを失わないように、また、接続が復旧したらすぐにユーザーが元の状態に戻れるように状態を保存しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-145">As with any other scenario involving gameplay suspension, you should save state so the user doesn’t lose data and can quickly return to that state after regaining connectivity.</span></span>

## <a name="offline-scenario-when-a-single-xbox-live-service-is-down"></a><span data-ttu-id="de3d5-146">オフラインのシナリオ: Xbox Live サービスの 1 つがダウンしたとき</span><span class="sxs-lookup"><span data-stu-id="de3d5-146">Offline scenario: when a single Xbox Live service is down</span></span>

<span data-ttu-id="de3d5-147">インターネット接続に問題はないが特定のオンライン サービスが利用できない、という状況が考えられます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-147">There are other situations in which specific online services may be unavailable even though Internet connectivity is fine.</span></span>

<span data-ttu-id="de3d5-148">たとえば、Xbox Live サービスの 1 つがオフラインになる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-148">For example, a single Xbox Live service could be offline for a short period of time.</span></span> <span data-ttu-id="de3d5-149">この場合、その特定のサービスを呼び出すとタイムアウトになるか、またはゲームにエラーが報告されます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-149">In this case, the call to the specific service will timeout or report an error to the game.</span></span> <span data-ttu-id="de3d5-150">Xbox 360 または Windows でそのような状況を扱う場合と同様に、サービスがオフラインになった状態を正しく取り扱う必要があります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-150">You should properly handle offline-service states just as you would handle those situations on Xbox 360 or on Windows.</span></span>

<span data-ttu-id="de3d5-151">少なくとも、ゲームがクラッシュまたはハングしてはなりません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-151">At a minimum, the game must not crash or hang.</span></span> <span data-ttu-id="de3d5-152">サービスを利用できなければゲームプレイを継続できない場合は、状況をユーザーに報告し、そのサービスを必要としないゲームの別の領域でユーザーがプレイを続けられるようにします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-152">If gameplay cannot continue without the service, then report the situation to the user, and allow the user to continue in another area of the game where the service is not required.</span></span>

<span data-ttu-id="de3d5-153">最も理想的なケースでは、ゲームプレイを継続した上で、データをキャッシュして後で送信する (ゲームがサービスにデータを書き込んでいた場合) か、またはデータに関する適切な仮定をたてて利用します (ゲームがサービスからデータを読み取っていた場合)。</span><span class="sxs-lookup"><span data-stu-id="de3d5-153">In the best case, continue gameplay and cache data to send later (if the game was writing to the service) or make reasonable assumptions about the data (if the game was reading from the service).</span></span>

## <a name="offline-scenario-when-a-third-party-service-is-down"></a><span data-ttu-id="de3d5-154">オフラインのシナリオ: サードパーティーのサービスがダウンしたとき</span><span class="sxs-lookup"><span data-stu-id="de3d5-154">Offline scenario: when a third-party service is down</span></span>

<span data-ttu-id="de3d5-155">ゲームがサードパーティーのオンライン サービスに依存する場合、そのサービスがダウンした状況をゲームが柔軟に処理できる必要もあります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-155">If your game relies on a third-party online service, then your game must also be resilient if that service fails.</span></span> <span data-ttu-id="de3d5-156">サービスがダウンした場合にゲームがクラッシュまたはハングしてはなりません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-156">If the service fails, then your game must not crash or hang.</span></span> <span data-ttu-id="de3d5-157">ゲームプレイを継続できない場合、サービスのエラーをユーザーに報告することができます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-157">You may report the service error to the user if gameplay cannot continue.</span></span> <span data-ttu-id="de3d5-158">可能であれば、ゲームプレイを継続するか、オンライン サービスを必要としないゲームの領域でユーザーがプレイを続けられるようにします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-158">Ideally, gameplay should continue or you should allow the user to continue in an area of the game that doesn’t require the online service.</span></span>

## <a name="offline-scenario-when-xbox-live-cloud-compute-is-down"></a><span data-ttu-id="de3d5-159">オフラインのシナリオ: Xbox Live クラウド コンピューティングがダウンしたとき</span><span class="sxs-lookup"><span data-stu-id="de3d5-159">Offline scenario: when Xbox Live cloud compute is down</span></span>

<span data-ttu-id="de3d5-160">Xbox One の目玉機能の 1 つはクラウドの処理能力です。</span><span class="sxs-lookup"><span data-stu-id="de3d5-160">One of the Xbox One showcases is cloud power.</span></span> <span data-ttu-id="de3d5-161">ゲームによっては、Xbox Live クラウド コンピューティングなどの常時接続型サービスに全面的に依存して、追加のコンピューティング機能または常時稼働のゲーム サーバーにアクセスする場合があります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-161">Some games may rely completely on an always-connected service such as Xbox Live cloud compute, which allows accessing additional compute capabilities or always-available game servers.</span></span> <span data-ttu-id="de3d5-162">このような常時接続モードは、プレイヤーにとっての体験を強化する場合にその利用が許可および奨励されます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-162">This always connected mode is both allowed and encouraged where it enhances the experience for players.</span></span>

<span data-ttu-id="de3d5-163">ゲームでこのモードを使用する場合は、インターネットからの完全な切断または特定のクラウド サービスのダウンによって、数秒から最大 1 分間にわたってサービスが中断する状況をゲームで柔軟に処理できるようにすることを推奨します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-163">If your game uses this mode, then we recommend that your game be resilient to service interruptions (of multiple seconds and up to one minute) that are due to either total loss of Internet connectivity or loss of a particular cloud service.</span></span> <span data-ttu-id="de3d5-164">ただし、ゲームがオフライン モードを備えることは必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-164">However, the game is not required to have an offline mode.</span></span> <span data-ttu-id="de3d5-165">ゲームの進行にインターネット接続が必須の状況で接続が利用できない場合は、ユーザーにそのことを通知してゲームプレイ セッションを終了します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-165">If the game truly needs connectivity and connectivity is not available, then inform the user and end the gameplay session.</span></span>

## <a name="xbox-requirements"></a><span data-ttu-id="de3d5-166">Xbox 要件</span><span class="sxs-lookup"><span data-stu-id="de3d5-166">Xbox Requirements</span></span>

<span data-ttu-id="de3d5-167">オフラインのシナリオを扱うときに最も重要な要件は、ゲームの安定性です。</span><span class="sxs-lookup"><span data-stu-id="de3d5-167">The most important requirement when dealing with offline scenarios is game stability.</span></span> <span data-ttu-id="de3d5-168">インターネットにまったく接続できなくなった、あるいは単に特定のオンライン サービスがダウンしたなど、どのような原因であれ、ゲームがハングまたはクラッシュしたり、ユーザーの状態が失われたりしてはなりません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-168">Whether it’s complete connectivity loss or just the loss of a specific online service, your game must not hang, crash, or cause the user to lose state.</span></span> <span data-ttu-id="de3d5-169">ネットワークのタイムアウトのシナリオに対応したり、オンライン サービスにアクセスする API から返されたエラーを処理したりするための堅牢なシステムをゲームに備える必要があります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-169">Your game must have a robust system for handling network-timeout scenarios and for handling errors returned from any API that accesses an online service.</span></span>

<span data-ttu-id="de3d5-170">ゲームでオフライン プレイをサポートすることは必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-170">Games are not required to support offline play.</span></span> <span data-ttu-id="de3d5-171">サービスに接続できないためどうしてもゲームを継続できない場合は、ユーザーに通知して、ゲーム セッションを終了し、メイン メニューまたは初期のインタラクティブ状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-171">If your game simply cannot continue because of a loss of service connectivity, then notify the user, end the gaming session, and return to the main menu or initial interactive state.</span></span>

## <a name="best-practices"></a><span data-ttu-id="de3d5-172">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="de3d5-172">Best practices</span></span>

<span data-ttu-id="de3d5-173">オフラインの状況を取り扱うためのベスト プラクティスを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-173">Here are best practices for dealing with offline situations:</span></span>

-   <span data-ttu-id="de3d5-174">ユーザーがほぼ常時オンラインに接続していると想定してゲームを設計します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-174">Design games to assume that users have online connectivity the majority of the time.</span></span>

-   <span data-ttu-id="de3d5-175">ゲームの設計と整合性がある場合、本体がオフライン状態でもユーザーが楽しい体験を得ることができるゲームプレイ モードを設計することを検討します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-175">If it makes sense for your game design, then consider designing modes of gameplay that allow the user to have an enjoyable experience even if the console is in an offline state.</span></span>

-   <span data-ttu-id="de3d5-176">サービスが利用できなくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-176">Services can become unavailable.</span></span> <span data-ttu-id="de3d5-177">接続障害が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-177">Connections can fail.</span></span> <span data-ttu-id="de3d5-178">オンライン サービスがダウンしているときやインターネット接続が失われたときに、タイムアウトすることがある API または障害状況を報告することがある API のために堅牢なエラー処理を構築します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-178">Build robust error handling for APIs that can timeout, or report failure conditions when an online service is down or when Internet connectivity is lost.</span></span> <span data-ttu-id="de3d5-179">可能であれば常に、これらの問題が起きた場合でもユーザーがプレイを続けられるようにします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-179">Whenever possible, keep users playing despite these issues.</span></span>

-   <span data-ttu-id="de3d5-180">Xbox 認定要件 (XR) に従います。</span><span class="sxs-lookup"><span data-stu-id="de3d5-180">Obey Xbox Requirements (XRs).</span></span> <span data-ttu-id="de3d5-181">ハングまたはクラッシュしてはなりません。</span><span class="sxs-lookup"><span data-stu-id="de3d5-181">Don’t hang or crash.</span></span>

-   <span data-ttu-id="de3d5-182">PLM タイトル中断通知を受け取ったら、状態を保存して、ユーザーがデータを失わないように、また、ゲーム再開時にユーザーがすぐに元の状態に戻れるようにします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-182">Upon receiving a PLM title suspension notification, save state so that the user doesn’t lose data and can quickly return to that state when resuming the game.</span></span>

-   <span data-ttu-id="de3d5-183">アプリケーション マニフェストでタイトルに適切なフラグを付けます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-183">Flag your title appropriately in the application manifest.</span></span> <span data-ttu-id="de3d5-184">すべてのゲームプレイ モードで接続が必要な場合のみ、"Xbox Live required" としてタイトルをマークします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-184">Only mark your title as “Xbox Live required” if all modes of gameplay require connectivity.</span></span>

-   <span data-ttu-id="de3d5-185">Xbox One のゲームはすべてのゲーム モードでオンライン サービスを利用でき、それらのサービスに依存できます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-185">Xbox One games are allowed to use and rely on online services in all game modes.</span></span> <span data-ttu-id="de3d5-186">サービスに接続できないためどうしてもゲームを継続できない場合は、ユーザーに通知し、ゲーム セッションを終了し、メイン メニューまたは初期のインタラクティブ状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-186">If the game simply cannot continue because of a loss of service connectivity, then notify the user, end the gaming session, and return to the main menu or initial interactive state.</span></span>

-   <span data-ttu-id="de3d5-187">オフライン状態に関連するエラー メッセージやヘルプを Xbox ヘルプ サービスに頼らないでください。</span><span class="sxs-lookup"><span data-stu-id="de3d5-187">Do not rely on the Xbox Help service for error messages and help related to offline states.</span></span> <span data-ttu-id="de3d5-188">Xbox ヘルプ サービスには Xbox Live への接続が必要です。</span><span class="sxs-lookup"><span data-stu-id="de3d5-188">The Xbox Help service requires a connection to Xbox Live.</span></span>

## <a name="conclusion"></a><span data-ttu-id="de3d5-189">まとめ</span><span class="sxs-lookup"><span data-stu-id="de3d5-189">Conclusion</span></span>

<span data-ttu-id="de3d5-190">Xbox One は常時接続を想定して設計されています。</span><span class="sxs-lookup"><span data-stu-id="de3d5-190">Xbox One is designed for an always connected world.</span></span> <span data-ttu-id="de3d5-191">ただし、今はまだそのビジョンの途上であり、プレイヤーはオフラインのシナリオを楽しむことができます。</span><span class="sxs-lookup"><span data-stu-id="de3d5-191">However, on the way to that vision, the console allows players to enjoy offline scenarios.</span></span> <span data-ttu-id="de3d5-192">ゲームは接続障害に対して堅牢である必要があります。</span><span class="sxs-lookup"><span data-stu-id="de3d5-192">Games must be robust in the face of connectivity failures.</span></span> <span data-ttu-id="de3d5-193">オフライン プレイが可能なゲームでは、プレイヤーがオフラインでの体験を最大限に楽しめるようにします。</span><span class="sxs-lookup"><span data-stu-id="de3d5-193">For games with offline play experiences, allow your players to enjoy those experiences to the fullest.</span></span> <span data-ttu-id="de3d5-194">オンライン専用のゲームでネットワーク接続が失われたときは、ユーザーをオフラインの状態に正常に戻します。</span><span class="sxs-lookup"><span data-stu-id="de3d5-194">For games that are always online when network connectivity is lost, gracefully return the user to an offline state.</span></span>
