---
title: Achievements 2017
author: KevinAsgari
description: Achievements 2017
ms.assetid: d424db04-328d-470c-81d3-5d4b82cb792f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04d2fab9aa836d36a0dba202b2292c311b6d4979
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881686"
---
# <a name="achievements-2017"></a><span data-ttu-id="b97c2-104">Achievements 2017</span><span class="sxs-lookup"><span data-stu-id="b97c2-104">Achievements 2017</span></span>

<span data-ttu-id="b97c2-105">Achievements 2017 システムでは、ゲーム デベロッパーは直接呼び出しモデルを使用して、Xbox One、Windows 10、Windows 10 Phone、Android、iOS 上の新しい Xbox Live ゲームの実績をロックを解除できます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-105">The Achievements 2017 system enables game developers to use a direct calling model to unlock achievements for new Xbox Live games on Xbox One, Windows 10, Windows 10 Phone, Android, and iOS.</span></span>

## <a name="introduction"></a><span data-ttu-id="b97c2-106">概要</span><span class="sxs-lookup"><span data-stu-id="b97c2-106">Introduction</span></span>

<span data-ttu-id="b97c2-107">Xbox One では、ゲーム内テレメトリー イベントを送信するだけで、ユーザー統計、実績、リッチ プレゼンス、マルチプレイヤーなどの Xbox Live 機能のデータを活用できる、新しいクラウド版実績システムが導入されました。</span><span class="sxs-lookup"><span data-stu-id="b97c2-107">With Xbox One, we introduced a new Cloud-Powered Achievements system that empowers game developers to drive the data for their Xbox Live capabilities, such as user stats, achievements, rich presence, and multiplayer, by simply sending in-game telemetry events.</span></span> <span data-ttu-id="b97c2-108">これにより、1 つのイベントで複数の Xbox Live 機能のデータを更新できたり、Xbox Live の構成がクライアントではなくサーバーに保持されるといった、多くの新しい利点があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-108">This has opened up a multitude of new benefits – a single event can update data for multiple Xbox Live features; Xbox Live configuration lives on the server instead of in the client; and much more.</span></span>

<span data-ttu-id="b97c2-109">Xbox One の発売から数年、ゲーム デベロッパーからのフィードバックを聞いてきましたが、デベロッパーは一貫して次のような共通認識を持っています。</span><span class="sxs-lookup"><span data-stu-id="b97c2-109">In the years following the Xbox One launch, we have listened closely to game developer feedback, and developers have consistently shared the following:</span></span>

1.  **<span data-ttu-id="b97c2-110">直接呼び出しパターンを使用して実績のロックを解除したい。</span><span class="sxs-lookup"><span data-stu-id="b97c2-110">Desire to unlock achievements via a direct calling pattern.</span></span>** <span data-ttu-id="b97c2-111">多くのデベロッパーはさまざまなプラットフォーム向けのゲームを開発しており、その中には以前のバージョンの Xbox も含まれます。また、これらのプラットフォームでの実績類似システムでは直接呼び出し方式が使用されています。</span><span class="sxs-lookup"><span data-stu-id="b97c2-111">Many developers build games for various platforms, including previous versions of Xbox, and the achievement-like systems on those platforms use a direct calling method.</span></span> <span data-ttu-id="b97c2-112">Xbox One および他の最新世代の Xbox プラットフォームで直接ロック解除呼び出しがサポートされると、クロスプラットフォーム ゲーム開発のニーズが緩和され、開発時のコストを削減できます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-112">Supporting direct unlock calls on Xbox One and other current-gen Xbox platforms would ease their cross-platform game development needs and development time costs.</span></span>

2.  **<span data-ttu-id="b97c2-113">構成の複雑さを最小限に抑える。</span><span class="sxs-lookup"><span data-stu-id="b97c2-113">Minimize configuration complexity.</span></span>** <span data-ttu-id="b97c2-114">クラウド版実績システムでは、タイトルの統計データを解釈する方法およびユーザーの実績をロック解除するタイミングをサービスが認識できるように、実績のロック解除ロジックを Xbox Live で構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-114">With the Cloud-Powered Achievements system, an achievement’s unlock logic must be configured in Xbox Live so that the services know how to interpret the title’s stats data and when to unlock the achievement for a user.</span></span> <span data-ttu-id="b97c2-115">この機能は、それ以前は存在しなかった実績の構成の新しい実績ルール セクションを使用して実現されました。</span><span class="sxs-lookup"><span data-stu-id="b97c2-115">This was done via a new Achievement Rules section of an achievement’s configuration that did not previously exist.</span></span> <span data-ttu-id="b97c2-116">クラウドにロック解除ロジックを置くことは非常に強力ですが、この追加構成要件によってタイトルの実績の設計と作成の複雑さが増します。</span><span class="sxs-lookup"><span data-stu-id="b97c2-116">While having unlock logic in the cloud can be quite powerful, this additional configuration requirement adds complexity into the design & creation of a title’s achievements.</span></span>

3.  **<span data-ttu-id="b97c2-117">トラブルシューティングが困難です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-117">Difficult to troubleshoot.</span></span>** <span data-ttu-id="b97c2-118">クラウド版実績システムではさまざまな便利な機能が導入されましたが、実績のロック解除が、ゲーム自体によって直接制御されるのではなく、サービス上に存在するルールによって間接的にトリガーされるため、ゲーム デベロッパーによる実績の検証とトラブルシューティングの困難さも増します。</span><span class="sxs-lookup"><span data-stu-id="b97c2-118">While the Cloud-Powered Achievements system introduces a variety of helpful capabilities, it can also be more difficult for game developers to validate and troubleshoot issues with their achievements since achievement unlocks are triggered indirectly by rules that live on the service rather than directly controlled by the game itself.</span></span>

<span data-ttu-id="b97c2-119">フィードバックではクラウド版実績システムと共に導入された特定の機能がたびたび高く評価されていることにも注目する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-119">It is worth noting that game developers have also repeatedly shared feedback that they appreciate and value certain features that were introduced along with the Cloud-Powered Achievements system:</span></span>

1.  <span data-ttu-id="b97c2-120">実績の進行状況、リアルタイム更新、コンセプト アート リワード、アクティビティ フィードへのロック解除の送信などの新しいユーザー エクスペリエンス機能。</span><span class="sxs-lookup"><span data-stu-id="b97c2-120">New user experience features such as achievement progression, real-time updates, concept art rewards, and posting unlocks into activity feed.</span></span>

2.  <span data-ttu-id="b97c2-121">ゲーム パッケージに含める必要があるローカル構成の代わりのサービス構成 (つまり、gameconfig、XLAST、SPA など) や、ゲーム出荷後に実績の文字列とイメージを簡単に編集する機能などの、構成機能の改善。</span><span class="sxs-lookup"><span data-stu-id="b97c2-121">Configuration improvements such as a service config instead of a local config that must be included in the game package (i.e. gameconfig, XLAST, SPA, etc.) and the ability to easily edit achievement strings & images after the game has shipped.</span></span>

<span data-ttu-id="b97c2-122">既存のクラウド版実績システムに代わるものとして将来のタイトルのために作成されている Achievements 2017 では、実績の構成、ゲーム コードへの実績のロック解除と更新の統合、実績が期待どおりに動作していることの検証が、容易になっています。</span><span class="sxs-lookup"><span data-stu-id="b97c2-122">With Achievements 2017, we are building a replacement of the existing Cloud-Powered Achievements system for future titles to use that makes it even easier for Xbox game developers to configure achievements, integrate achievement unlocks & updates into the game code, and validate that the achievements are working as expected.</span></span>

## <a name="whats-different-with-achievements-2017"></a><span data-ttu-id="b97c2-123">Achievements 2017 の特長</span><span class="sxs-lookup"><span data-stu-id="b97c2-123">What’s different with Achievements 2017</span></span>

|                          | <span data-ttu-id="b97c2-124">Achievements 2017 システム</span><span class="sxs-lookup"><span data-stu-id="b97c2-124">Achievements 2017 system</span></span>        | <span data-ttu-id="b97c2-125">クラウド版実績システム</span><span class="sxs-lookup"><span data-stu-id="b97c2-125">Cloud-Powered Achievements system</span></span>      |
|--------------------------|---------------------------------------|----------------------------------------|
| <span data-ttu-id="b97c2-126">ロック解除トリガー</span><span class="sxs-lookup"><span data-stu-id="b97c2-126">Unlock Trigger</span></span>           | <span data-ttu-id="b97c2-127">API 呼び出しによって直接的</span><span class="sxs-lookup"><span data-stu-id="b97c2-127">Directly via API call</span></span>                 | <span data-ttu-id="b97c2-128">テレメトリー イベントによって間接的</span><span class="sxs-lookup"><span data-stu-id="b97c2-128">Indirectly via telemetry events</span></span>        |
| <span data-ttu-id="b97c2-129">ロック解除の所有者</span><span class="sxs-lookup"><span data-stu-id="b97c2-129">Unlock Owner</span></span>             | <span data-ttu-id="b97c2-130">タイトル</span><span class="sxs-lookup"><span data-stu-id="b97c2-130">Title</span></span>                                 | <span data-ttu-id="b97c2-131">Xbox Live</span><span class="sxs-lookup"><span data-stu-id="b97c2-131">Xbox Live</span></span>                              |
| <span data-ttu-id="b97c2-132">構成</span><span class="sxs-lookup"><span data-stu-id="b97c2-132">Configuration</span></span>            | <span data-ttu-id="b97c2-133">文字列、イメージ、リワード</span><span class="sxs-lookup"><span data-stu-id="b97c2-133">Strings, images, rewards</span></span>              | <span data-ttu-id="b97c2-134">文字列、イメージ、リワード、ロック解除ルール \[+ 統計情報、+ イベント\]</span><span class="sxs-lookup"><span data-stu-id="b97c2-134">Strings, images, rewards, unlock rules  \[+ stats, +events\]</span></span>                    |
| <span data-ttu-id="b97c2-135">進行状況</span><span class="sxs-lookup"><span data-stu-id="b97c2-135">Progression</span></span>              | <span data-ttu-id="b97c2-136">サポートされる</span><span class="sxs-lookup"><span data-stu-id="b97c2-136">Supported</span></span> <br>*<span data-ttu-id="b97c2-137">API 呼び出しによって直接的</span><span class="sxs-lookup"><span data-stu-id="b97c2-137">directly via API call</span></span>*                | <span data-ttu-id="b97c2-138">サポートされる</span><span class="sxs-lookup"><span data-stu-id="b97c2-138">Supported</span></span> <br> *<span data-ttu-id="b97c2-139">テレメトリー イベントによって間接的</span><span class="sxs-lookup"><span data-stu-id="b97c2-139">indirectly via telemetry events</span></span>*       |
| <span data-ttu-id="b97c2-140">リアルタイム アクティビティ (RTA)</span><span class="sxs-lookup"><span data-stu-id="b97c2-140">Real-Time Activity (RTA)</span></span> | <span data-ttu-id="b97c2-141">サポートされる</span><span class="sxs-lookup"><span data-stu-id="b97c2-141">Supported</span></span>                             | <span data-ttu-id="b97c2-142">サポートされる</span><span class="sxs-lookup"><span data-stu-id="b97c2-142">Supported</span></span>                              |
| <span data-ttu-id="b97c2-143">チャレンジ</span><span class="sxs-lookup"><span data-stu-id="b97c2-143">Challenges</span></span>               | <span data-ttu-id="b97c2-144">サポートされない</span><span class="sxs-lookup"><span data-stu-id="b97c2-144">Not Supported</span></span>   | <span data-ttu-id="b97c2-145">サポートされる</span><span class="sxs-lookup"><span data-stu-id="b97c2-145">Supported</span></span>                      |

## <a name="title-requirements"></a><span data-ttu-id="b97c2-146">タイトルの要件</span><span class="sxs-lookup"><span data-stu-id="b97c2-146">Title requirements</span></span>

<span data-ttu-id="b97c2-147">Achievements 2017 システムを使用するタイトルの要件を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b97c2-147">The following are the requirements of any title that will use the Achievements 2017 system.</span></span>

1.  **<span data-ttu-id="b97c2-148">新しい (未リリースの) タイトルでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="b97c2-148">Must be a new (unreleased) title.</span></span>** <span data-ttu-id="b97c2-149">既にリリースされていてクラウド版実績システムを使用しているタイトルは対象外です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-149">Titles that have already been released and are using the Cloud-Powered Achievements system are ineligible.</span></span> <span data-ttu-id="b97c2-150">詳しくは、「[既存のタイトルを新しい Achievements 2017 システムに "移行" できないのはなぜですか?](#_Why_can’t_existing)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b97c2-150">For more, see [Why can’t existing titles “migrate” onto the new Achievements 2017 system?](#_Why_can’t_existing)</span></span>

2.  **<span data-ttu-id="b97c2-151">August 2016 XDK 以降を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-151">Must use August 2016 XDK or newer.</span></span>** <span data-ttu-id="b97c2-152">Update_Achievement API は、August 2016 XDK でリリースされました。</span><span class="sxs-lookup"><span data-stu-id="b97c2-152">The Update_Achievement API was released in the August 2016 XDK.</span></span>

3.  **<span data-ttu-id="b97c2-153">XDK または UWP タイトルでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="b97c2-153">Must be an XDK or UWP title.</span></span>** <span data-ttu-id="b97c2-154">Achievements 2017 システムは、Xbox 360、Windows 8.x 以前、Windows Phone 8 以前などの従来のプラットフォームでは使用できません。</span><span class="sxs-lookup"><span data-stu-id="b97c2-154">The Achievements 2017 system is not available for legacy platforms, including Xbox 360, Windows 8.x or older, nor Windows Phone 8 or older.</span></span>

## <a name="updateachievement-api"></a><span data-ttu-id="b97c2-155">Update_Achievement API</span><span class="sxs-lookup"><span data-stu-id="b97c2-155">Update_Achievement API</span></span>

<span data-ttu-id="b97c2-156">XDP または [UDC](../configure-xbl/dev-center/achievements-in-udc.md) を介して実績を構成し、開発サンドボックスに公開したら、タイトルで Update_Achievement API を呼び出して実績のロックを解除できます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-156">Once your achievements are configured via XDP or [UDC](../configure-xbl/dev-center/achievements-in-udc.md) and published to your dev sandbox, your title can unlock them by calling the Update_Achievement API.</span></span>

<span data-ttu-id="b97c2-157">この API は XDK と Xbox Live SDK の両方で使用できます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-157">The API is available in both the XDK and the Xbox Live SDK.</span></span>

### <a name="api-signature"></a><span data-ttu-id="b97c2-158">API のシグネチャ</span><span class="sxs-lookup"><span data-stu-id="b97c2-158">API signature</span></span>

<span data-ttu-id="b97c2-159">API のシグネチャは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b97c2-159">The API signature is as follows:</span></span>

```c++
/// <summary>
    /// Allow achievement progress to be updated and achievements to be unlocked.  
    /// This API will work even when offline. On PC and Xbox One, updates will be posted by the system when connection is re-established even if the title isn't running
    /// </summary>
    /// <param name="xboxUserId">The Xbox User ID of the player.</param>
    /// <param name="titleId">The title ID.</param>
    /// <param name="serviceConfigurationId">The service configuration ID (SCID) for the title.</param>
    /// <param name="achievementId">The achievement ID as defined by XDP or Dev Center.</param>
    /// <param name="percentComplete">The completion percentage of the achievement to indicate progress.
    /// Valid values are from 1 to 100. Set to 100 to unlock the achievement.  
    /// Progress will be set by the server to the highest value sent</param>
    /// <remarks>
    /// Returns a task<T> object that represents the state of the asynchronous operation.
    ///
    /// This method calls V2 GET /users/xuid({xuid})/achievements/{scid}/update
    /// </remarks>
    _XSAPIIMP pplx::task<xbox::services::xbox_live_result<void>> update_achievement(
        _In_ const string_t& xboxUserId,
        _In_ uint32_t titleId,
        _In_ const string_t& serviceConfigurationId,
        _In_ const string_t& achievementId,
        _In_ uint32_t percentComplete
        );
```

`xbox::services::xbox_live_result<T>` <span data-ttu-id="b97c2-160">は、すべての C++ Xbox Live Services API 呼び出しに対する戻りの呼び出しです。</span><span class="sxs-lookup"><span data-stu-id="b97c2-160">is the return call for all C++ Xbox Live Services API calls.</span></span>

<span data-ttu-id="b97c2-161">詳細については、Xfest 2015 の講演「XSAPI: C++, No Exceptions!」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b97c2-161">For more information, check out the Xfest 2015 talk, “XSAPI: C++, No Exceptions!”</span></span><br>
<span data-ttu-id="b97c2-162">[ビデオ](http://go.microsoft.com/?linkid=9888207) |  [スライド](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Documents/Xfest_2015/Xbox_Live_Track/XSAPI_Cpp_No_Exceptions.pptx)</span><span class="sxs-lookup"><span data-stu-id="b97c2-162">[video](http://go.microsoft.com/?linkid=9888207) |  [slides](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Documents/Xfest_2015/Xbox_Live_Track/XSAPI_Cpp_No_Exceptions.pptx)</span></span>

### <a name="unlocking-via-updateachievement-api"></a><span data-ttu-id="b97c2-163">Update_Achievement API によるロック解除</span><span class="sxs-lookup"><span data-stu-id="b97c2-163">Unlocking via Update_Achievement API</span></span>

<span data-ttu-id="b97c2-164">実績のロックを解除するには、*percentComplete* を 100 に設定します。</span><span class="sxs-lookup"><span data-stu-id="b97c2-164">To unlock an achievement, set the *percentComplete* to 100.</span></span>

<span data-ttu-id="b97c2-165">ユーザーがオンラインの場合、要求は Xbox Live 実績サービスに直ちに送信されて、次のユーザー エクスペリエンスをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="b97c2-165">If the user is online, the request will be immediately sent to the Xbox Live Achievements service and will trigger the following user experiences:</span></span>

-   <span data-ttu-id="b97c2-166">ユーザーは実績ロック解除通知を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-166">The user will receive an Achievement Unlocked notification;</span></span>

-   <span data-ttu-id="b97c2-167">指定された実績が、ユーザーのタイトルの実績リストに Unlocked として表示されます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-167">The specified achievement will appear as Unlocked in the user’s achievement list for the title;</span></span>

-   <span data-ttu-id="b97c2-168">ロック解除された実績が、ユーザーのアクティビティ フィードに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-168">The unlocked achievement will be added to the user’s activity feed.</span></span>

> *<span data-ttu-id="b97c2-169">注意: タイトルが Achievements 2017 システムまたはクラウド版実績システムのどちらを使用していても、実績のユーザー エクスペリエンスの表示に違いはありません。</span><span class="sxs-lookup"><span data-stu-id="b97c2-169">Note: There will be no visible difference in user experiences for achievements that use the Achievements 2017 system and the Cloud-Powered Achievements.</span></span>*

<span data-ttu-id="b97c2-170">ユーザーがオフラインの場合は、ロック解除要求はユーザーのデバイスのローカルなキューに入れられます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-170">If the user is offline, the unlock request will be queued locally on the user’s device.</span></span> <span data-ttu-id="b97c2-171">ユーザーのデバイスがネットワークに再び接続すると、要求は実績サービスに自動的に送信され (注: このトリガーにゲームのアクションは必要ありません)、上記のエクスペリエンスが説明したとおりに行われます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-171">When the user’s device has reestablished network connectivity, the request will automatically be sent to the Achievements service – note: no action is required from the game to trigger this – and the above user experiences will occur as described.</span></span>

### <a name="updating-completion-progress-via-updateachievement-api"></a><span data-ttu-id="b97c2-172">Update_Achievement API による進行状況の更新</span><span class="sxs-lookup"><span data-stu-id="b97c2-172">Updating completion progress via Update_Achievement API</span></span>

<span data-ttu-id="b97c2-173">実績のロック解除に向けたユーザーの進行状況を更新するには、*percentComplete* を 1 ～ 100 の範囲の適切な整数に設定します。</span><span class="sxs-lookup"><span data-stu-id="b97c2-173">To update a user’s progress toward unlocking an achievement, set the *percentComplete* to the appropriate whole number between 1-100.</span></span>

<span data-ttu-id="b97c2-174">実績の進行状況は増やすことだけが可能です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-174">An achievement’s progress can only increase.</span></span> <span data-ttu-id="b97c2-175">*percentComplete* を実績の最後の *percentComplete* 値より小さい値に設定すると、更新は無視されます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-175">If *percentComplete* is set to a number less than the achievement’s last *percentComplete* value, the update will be ignored.</span></span> <span data-ttu-id="b97c2-176">たとえば、実績の *percentComplete* の前回の値が 75 の場合、値 25 を指定して更新を送信すると無視されて、実績の進行状況の表示は 75% のままになります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-176">For example, if the achievement’s *percentComplete* had previously been set to 75, sending an update with a value of 25 will be ignored and the achievement will still be displayed as 75% complete.</span></span>

<span data-ttu-id="b97c2-177">*percentComplete* を 100 に設定すると、実績のロックが解除されます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-177">If *percentComplete* is set to 100, the achievement will unlock.</span></span>

<span data-ttu-id="b97c2-178">*percentComplete* を 100 より大きい値に設定すると、API は 100 ちょうどに設定した場合と同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="b97c2-178">If *percentComplete* is set to a number greater than 100, the API will behave as if you set it to exactly 100.</span></span>

## <a name="frequently-asked-questions"></a><span data-ttu-id="b97c2-179">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="b97c2-179">Frequently asked questions</span></span>

### <a name="span-idwhyarechallenges-classanchorspancan-i-ship-my-title-using-the-achievements-2017-system-yet"></a><span data-ttu-id="b97c2-180"><span id="_Why_are_Challenges" class="anchor"></span>Achievements 2017 システムを使用するタイトルはもう出荷できますか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-180"><span id="_Why_are_Challenges" class="anchor"></span>Can I ship my title using the Achievements 2017 system yet?</span></span>

<span data-ttu-id="b97c2-181">もちろんです。</span><span class="sxs-lookup"><span data-stu-id="b97c2-181">Absolutely!</span></span> <span data-ttu-id="b97c2-182">すべての新規タイトルでは、クラウド版実績システムの代わりに Achievements 2017 システムを使用することが歓迎され、奨励されます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-182">All new titles are welcomed and encouraged to make use of the Achievements 2017 system in lieu of the Cloud-Powered Achievements system.</span></span>

### <a name="why-are-challenges-not-supported-in-the-achievements-2017-system"></a><span data-ttu-id="b97c2-183">Achievements 2017 システムでチャレンジがサポートされていないのはなぜですか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-183">Why are Challenges not supported in the Achievements 2017 system?</span></span>

<span data-ttu-id="b97c2-184">Xbox ゲーム全体の使用データを調べたところ、チャレンジの現在の実装と提供はほとんどのゲーム デベロッパーのニーズを満たしていないことがわかりました。</span><span class="sxs-lookup"><span data-stu-id="b97c2-184">Usage data across Xbox games has shown that the current implementation and presentation of challenges does not fulfill a need for most game developers.</span></span> <span data-ttu-id="b97c2-185">引き続きこの部分に関するデベロッパーの意見とフィードバックを収集し、デベロッパーのニーズにいっそう沿った機能を提供する予定です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-185">We will continue gathering developer input and feedback in this space and endeavor to deliver future features that are more on point with developer needs.</span></span> <span data-ttu-id="b97c2-186">新しくリリースされる Xbox Arena は、新しくはあっても大きくは異ならない方向で Xbox ゲームに新しい対戦型環境を導入する機能の例です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-186">The newly released Xbox Arena is an example of a feature that introduces new competitive capabilities for Xbox games a new, but similar, direction.</span></span>

### <a name="can-i-still-add-new-achievements-every-calendar-quarter-if-my-title-is-using-the-achievements-2017-system"></a><span data-ttu-id="b97c2-187">タイトルが Achievements 2017 システムを使用している場合でも、3 か月ごとに新しい実績を追加できますか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-187">Can I still add new achievements every calendar quarter if my title is using the Achievements 2017 system?</span></span>

<span data-ttu-id="b97c2-188">できます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-188">Yes.</span></span> <span data-ttu-id="b97c2-189">実績ポリシーの変更はありません。</span><span class="sxs-lookup"><span data-stu-id="b97c2-189">The Achievements policy is unchanged.</span></span>

### <a name="span-idwhycantexisting-classanchorspanwhy-cant-existing-titles-migrate-onto-the-new-achievements-2017-system"></a><span data-ttu-id="b97c2-190"><span id="_Why_can’t_existing" class="anchor"></span>既存のタイトルを新しい Achievements 2017 システムに "移行" できないのはなぜですか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-190"><span id="_Why_can’t_existing" class="anchor"></span>Why can’t existing titles “migrate” onto the new Achievements 2017 system?</span></span>

<span data-ttu-id="b97c2-191">既存タイトルの大部分については、Achievements 2017 システムへの "移行" は、サービス構成の更新と、実績ロック解除呼び出しのイベント書き込みの変更だけでは済みません。しかも、これらの変更だけでも、非常にコストがかかり、実績が修復不可能なほど破損するようなエラーと意図しない動作が発生する大きなリスクがあります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-191">For the vast majority of existing titles, a ‘migration’ to the Achievements 2017 system would not be limited to simply updating their service configurations and swapping out event writes for achievement unlock calls – although these changes alone would be very costly and would carry significant risk of error and unintended behavior that could result in the achievements being irreparably broken.</span></span> <span data-ttu-id="b97c2-192">さらに、ほとんどの既存タイトルには、既存のデータを持っているユーザーがいます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-192">Rather, most existing titles also have users with existing data.</span></span> <span data-ttu-id="b97c2-193">クラウド版実績システムを既に使用しているライブ ゲームの変換は、デベロッパーと Xbox の双方にとって、それほどコストのかかる作業ではありませんが、既存のユーザーのプロフィールとゲーム エクスペリエンスは大きな危険にさらされます。</span><span class="sxs-lookup"><span data-stu-id="b97c2-193">Attempting to convert a live game that is already using the Cloud-Powered Achievements system would not only be a very costly effort, for both the developer and Xbox, but would significantly jeopardize existing users’ profiles and/or game experiences.</span></span>

### <a name="if-my-title-was-released-using-the-cloud-powered-achievements-system-can-any-future-dlc-for-the-title-switch-to-achievements-2017"></a><span data-ttu-id="b97c2-194">クラウド版実績システムを使用しているリリース済みタイトルは、タイトルの将来の DLC で Achievements 2017 に切り替えることができますか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-194">If my title was released using the Cloud-Powered Achievements system, can any future DLC for the title switch to Achievements 2017?</span></span>

<span data-ttu-id="b97c2-195">タイトルのすべての実績は、同じ実績システムを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-195">All achievements for a title must use the same Achievements system.</span></span> <span data-ttu-id="b97c2-196">ベース ゲームの実績で使用されている実績システムを、タイトルの将来のすべての実績に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-196">Whichever Achievements system is used by the base game’s achievements is the system that must be used for all future achievements for the title.</span></span>

### <a name="while-testing-achievements-in-my-dev-sandbox-can-i-mix-and-match-between-using-the-achievements-2017-system-and-the-cloud-powered-achievements-system"></a><span data-ttu-id="b97c2-197">開発サンドボックスで実績をテストするときに、Achievements 2017 システムとクラウド版実績システムを組み合わせて使用することはできますか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-197">While testing achievements in my dev sandbox, can I mix-and-match between using the Achievements 2017 system and the Cloud-Powered Achievements system?</span></span>

<span data-ttu-id="b97c2-198">できません。</span><span class="sxs-lookup"><span data-stu-id="b97c2-198">No.</span></span> <span data-ttu-id="b97c2-199">タイトルのすべての実績は、同じ実績システムを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-199">All achievements for a title must use the same Achievements system.</span></span>

### <a name="does-achievements-2017-also-include-offline-unlocks"></a><span data-ttu-id="b97c2-200">Achievements 2017 にはオフライン ロック解除も含まれていますか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-200">Does Achievements 2017 also include offline unlocks?</span></span>

<span data-ttu-id="b97c2-201">デバイスがオフラインの間にタイトルで実績をロック解除すると、Update_Achievement API はオフライン ロック解除要求を自動的にキューに入れ、デバイスが再びネットワークに接続すると、Xbox Live と自動的に同期します。これは、現在のクラウド版実績システムのオフライン エクスペリエンスと同様です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-201">If the title unlocks an achievement while the device is offline, the Update_Achievement API will automatically queue the offline unlock requests and will auto-sync to Xbox Live when the device has reestablished network connectivity, similar to the current Cloud-Powered Achievements system’s offline experience.</span></span> <span data-ttu-id="b97c2-202">ユーザーがオフラインの間は、実績のロック解除は行われません。</span><span class="sxs-lookup"><span data-stu-id="b97c2-202">Achievements unlocks will not occur while the user is offline.</span></span>

### <a name="i-see-a-new-achievementupdate-event-in-xdp-if-my-title-uses-that-event-does-that-mean-it-has-achievements-2017"></a><span data-ttu-id="b97c2-203">XDP には新しい "AchievementUpdate" イベントがあります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-203">I see a new “AchievementUpdate” event in XDP.</span></span> <span data-ttu-id="b97c2-204">タイトルでそのイベントを使用すると、タイトルは Achievements 2017 を使用していることになりますか?</span><span class="sxs-lookup"><span data-stu-id="b97c2-204">If my title uses that event, does that mean it has Achievements 2017?</span></span>

<span data-ttu-id="b97c2-205">*AchievementUpdate* ベース イベントは、バックエンド用に Xbox Live で必要です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-205">The *AchievementUpdate* base event is required by Xbox Live for backend purposes.</span></span> <span data-ttu-id="b97c2-206">このイベントは無視しても安全です。</span><span class="sxs-lookup"><span data-stu-id="b97c2-206">You can safely ignore it.</span></span> <span data-ttu-id="b97c2-207">このベース イベント タイプを使用するイベントをタイトルで構成した場合、Xbox Live はそのイベントによる書き込みを無視します。</span><span class="sxs-lookup"><span data-stu-id="b97c2-207">If your title configures an event using this base event type, those event writes will be ignored by Xbox Live.</span></span> <span data-ttu-id="b97c2-208">クラウド版実績システムを使用するタイトルでは、引き続き他のベース イベント タイプを使用してイベントを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b97c2-208">Titles that are built on the Cloud-Powered Achievements system should continue to configure their events by using the other base event types.</span></span> <span data-ttu-id="b97c2-209">Achievements 2017 システムを使用するタイトルでは、実績のためにイベントを構成する必要は一切ありません\*\*。</span><span class="sxs-lookup"><span data-stu-id="b97c2-209">Titles that are built on the Achievements 2017 system need not configure *any* events for achievement purposes.</span></span>
