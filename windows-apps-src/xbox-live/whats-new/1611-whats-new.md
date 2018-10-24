---
title: Xbox Live SDK の新規事項 - November 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - November 2016
ms.assetid: 5cf9ba9d-5a15-4e62-bc1f-45ff8b8bf3b0
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 642d15a85837ed23ea98dc3f9bd39b8d50d860b2
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5431473"
---
# <a name="whats-new-for-the-xbox-live-sdk---november-2016"></a><span data-ttu-id="18a41-104">Xbox Live SDK の新規事項 - November 2016</span><span class="sxs-lookup"><span data-stu-id="18a41-104">What's new for the Xbox Live SDK - November 2016</span></span>

<span data-ttu-id="18a41-105">August 2016 リリースで追加された内容については、「[新規事項 - August 2016](1608-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="18a41-105">Please see the [What's New - August 2016](1608-whats-new.md) article for what was added in the August 2016 release.</span></span>

## <a name="xbox-services-api"></a><span data-ttu-id="18a41-106">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="18a41-106">Xbox Services API</span></span>

### <a name="simplified-achievements"></a><span data-ttu-id="18a41-107">簡素化された実績</span><span class="sxs-lookup"><span data-stu-id="18a41-107">Simplified Achievements</span></span>

* <span data-ttu-id="18a41-108">[簡素化された実績](../achievements-2017/simplified-achievements.md)は、実績をより単純に構成および使用するための新しい手段です。</span><span class="sxs-lookup"><span data-stu-id="18a41-108">[Simplified Achievements](../achievements-2017/simplified-achievements.md) are a new and simpler way to configure and use achievements.</span></span>  <span data-ttu-id="18a41-109">実績がロック解除された際に、イベントを送信して Xbox Live サービスに判定してもらう必要がなくなりました。</span><span class="sxs-lookup"><span data-stu-id="18a41-109">You no longer have to send events and have the Xbox Live services decide if your achievement is unlocked.</span></span>  <span data-ttu-id="18a41-110">その判定は、タイトルによって行われます。</span><span class="sxs-lookup"><span data-stu-id="18a41-110">Your title is in charge of that decision.</span></span>
* <span data-ttu-id="18a41-111">簡素化された実績の早期パイロットに参加したユーザーにも、オフライン サポートが追加されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-111">If you have been part of the early pilot of Simplified Achievements we have also added offline support.</span></span>
* <span data-ttu-id="18a41-112">SimplifiedAchievements という新しいサンプルでは、非常に簡単に使用できることが示されています。</span><span class="sxs-lookup"><span data-stu-id="18a41-112">There's a new sample called SimplifiedAchievements that shows off how easy it is to use.</span></span>

### <a name="multiplayer"></a><span data-ttu-id="18a41-113">マルチプレイヤー</span><span class="sxs-lookup"><span data-stu-id="18a41-113">Multiplayer</span></span>

* <span data-ttu-id="18a41-114">[セッション ブラウズ](../multiplayer/session-browse.md)は、ユーザーがマルチプレイヤー ゲームを探すための新しい手段です。</span><span class="sxs-lookup"><span data-stu-id="18a41-114">[Session Browse](../multiplayer/session-browse.md) is a new way for your users to find a multiplayer game.</span></span>  <span data-ttu-id="18a41-115">セッション ブラウズを使用すると、指定された条件を満たすオープン マルチプレイヤー ゲーム セッションの一覧を検索できます。</span><span class="sxs-lookup"><span data-stu-id="18a41-115">Session Browse allows players to search for a list of open multiplayer game sessions that meet specified criteria.</span></span>
* <span data-ttu-id="18a41-116">[Multiplayer Manager](../multiplayer/multiplayer-manager.md) に自動入力機能が備わりました。</span><span class="sxs-lookup"><span data-stu-id="18a41-116">The [Multiplayer Manager](../multiplayer/multiplayer-manager.md) now has auto-fill capabilities.</span></span>  <span data-ttu-id="18a41-117">有効にすると、Multiplayer Manager はマッチメイキングを使用してメンバーを検索し、ゲームプレイ中に開いているスロットに入力します。</span><span class="sxs-lookup"><span data-stu-id="18a41-117">If enabled, Multiplayer Manager will find members via matchmaking to fill open slots during gameplay.</span></span>
* <span data-ttu-id="18a41-118">プレプロダクション バージョンの [XIM (Xbox Integrated Multiplayer)](../multiplayer/xbox-integrated-multiplayer.md) が、ERA 開発に利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="18a41-118">A pre-production version of [XIM (Xbox Integrated Multiplayer)](../multiplayer/xbox-integrated-multiplayer.md) is now available for XDK development.</span></span>  <span data-ttu-id="18a41-119">XIM は、Xbox Live サービスの機能を使用してマルチプレイヤー リアルタイム ネットワークおよびチャット コミュニケーションをゲームに簡単に追加できる自己完結型のインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="18a41-119">XIM is a self-contained interface for easily adding multiplayer real-time networking and chat communication to your game through the power of Xbox Live services.</span></span>

### <a name="social-manager"></a><span data-ttu-id="18a41-120">Social Manager</span><span class="sxs-lookup"><span data-stu-id="18a41-120">Social Manager</span></span>

* <span data-ttu-id="18a41-121">さまざまな [Social Manager](../social-platform/intro-to-social-manager.md) API の変更点:</span><span class="sxs-lookup"><span data-stu-id="18a41-121">Numerous [Social Manager](../social-platform/intro-to-social-manager.md) API changes:</span></span>
    * <span data-ttu-id="18a41-122">Social Manager により、実験的な名前空間が残されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-122">Social manager has left the experimental namespace.</span></span> <span data-ttu-id="18a41-123">早期に導入され、フィードバックをくださった方々に深く感謝します。</span><span class="sxs-lookup"><span data-stu-id="18a41-123">Special thanks to those who were early adopters and gave feedback!</span></span>
    * `xbox_social_user`
        * `string_t` <span data-ttu-id="18a41-124">オブジェクトが `char*` オブジェクトに変更されました</span><span class="sxs-lookup"><span data-stu-id="18a41-124">objects have been changed to `char*` objects</span></span>
        * <span data-ttu-id="18a41-125">6 個の `social_manager_presence_title_record` までのカスタム プレゼンス レコード (各: </span><span class="sxs-lookup"><span data-stu-id="18a41-125">Custom presence record with limit of six `social_manager_presence_title_record` per</span></span> `social_manager_presence_record`
    * `social_event`
        * <span data-ttu-id="18a41-126">次の代わりに `std::vector<xbox_user_id_container>` を返します。</span><span class="sxs-lookup"><span data-stu-id="18a41-126">Returns a `std::vector<xbox_user_id_container>` instead of</span></span> `std::vector<xbox_social_user>`
        * <span data-ttu-id="18a41-127">このベクトルは、新しい API に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="18a41-127">This vector can be passed into new API,</span></span> `xbox_social_user_group::get_users_from_xbox_user_ids()`
    * `xbox_social_user_group`
        * `users()` <span data-ttu-id="18a41-128">API が `std::vector<xbox_social_user*>` 返すようになりました。</span><span class="sxs-lookup"><span data-stu-id="18a41-128">API now returns a `std::vector<xbox_social_user*>`.</span></span> <span data-ttu-id="18a41-129">これらのポインターは、次の呼び出しで無効になります。</span><span class="sxs-lookup"><span data-stu-id="18a41-129">These pointers become invalidated on the next call to</span></span> `social_manager::do_work()`
        * `get_copy_of_users` <span data-ttu-id="18a41-130">は、social_user_group 内の現在のユーザーのコピーとして `std::vector<xbox_social_user>` を呼び出し元に返します。</span><span class="sxs-lookup"><span data-stu-id="18a41-130">return a `std::vector<xbox_social_user>` as a copy of the current users in the social_user_group to the caller.</span></span> <span data-ttu-id="18a41-131">この関数を呼び出すと、`do_work` の完了時間に影響を与える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="18a41-131">Calling this function may affect `do_work` completion time.</span></span>
* <span data-ttu-id="18a41-132">Social Manager が初期化後に失敗しなくなりました。</span><span class="sxs-lookup"><span data-stu-id="18a41-132">Social Manager now will never fail after initialization.</span></span> <span data-ttu-id="18a41-133">Social Manager は切断時に自動的に RTA を再試行します。</span><span class="sxs-lookup"><span data-stu-id="18a41-133">Social Manager will retry RTA automatically on disconnection.</span></span> <span data-ttu-id="18a41-134">`error` イベントと `rta_disconnect_error` イベントが推奨されなくなったため、削除されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-134">The `error` and `rta_disconnect_error` events have been deprecated and removed</span></span>
* <span data-ttu-id="18a41-135">タイトルでカスタム メモリー アロケーターを指定できます。</span><span class="sxs-lookup"><span data-stu-id="18a41-135">Title can specify custom memory allocators.</span></span> <span data-ttu-id="18a41-136">新しいドキュメント「[Social Manager のメモリーとパフォーマンス](../social-platform/social-manager-memory-and-performance-overview.md)」を参照してください</span><span class="sxs-lookup"><span data-stu-id="18a41-136">See the new documentation: [Social Manager Memory and Performance](../social-platform/social-manager-memory-and-performance-overview.md)</span></span>

### <a name="xbox-one-uwp"></a><span data-ttu-id="18a41-137">Xbox One UWP</span><span class="sxs-lookup"><span data-stu-id="18a41-137">Xbox One UWP</span></span>
* <span data-ttu-id="18a41-138">TCUI API に、Xbox One UWP アプリのマルチ ユーザー向けのサポートが追加されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-138">TCUI APIs adds support multi-user for Xbox One UWP apps.</span></span>  <span data-ttu-id="18a41-139">XSAPI C++ にユーザーを指定する新しい Windows::System::User^ パラメーターが追加され、XSAPI WinRT API に ForUserAsync API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-139">The XSAPI C++ adds new Windows::System::User^ parameters specify the user, and the XSAPI WinRT API adds ForUserAsync APIs.</span></span>
* <span data-ttu-id="18a41-140">Xbox のマルチ ユーザーをサポートするために更新された UWP のサンプル</span><span class="sxs-lookup"><span data-stu-id="18a41-140">Updated UWP samples to support multi-user on Xbox</span></span>

### <a name="other"></a><span data-ttu-id="18a41-141">その他</span><span class="sxs-lookup"><span data-stu-id="18a41-141">Other</span></span>

* <span data-ttu-id="18a41-142">C++/WinRT サポートが追加されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-142">C++/WinRT support added.</span></span>   <span data-ttu-id="18a41-143">詳細については、[ここ](../introduction-to-xbox-live-apis.md)を参照してください</span><span class="sxs-lookup"><span data-stu-id="18a41-143">More detail can be found [here](../introduction-to-xbox-live-apis.md)</span></span>
* <span data-ttu-id="18a41-144">自身のログ コールバックを追加および削除する新しい機能が追加されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-144">New functionality in to add and remove your own logging callbacks.</span></span>  <span data-ttu-id="18a41-145">診断のレベルは、動作を細かく調整できるように、コールバックに渡されます。</span><span class="sxs-lookup"><span data-stu-id="18a41-145">The diagnostic level will be passed to your callback so you can fine tune your behavior.</span></span>  <span data-ttu-id="18a41-146">`microsoft::xbox::services::system::xbox_live_services_settings` 名前空間の `add_logging_handler` と `remove_logging_handler` をご覧ください</span><span class="sxs-lookup"><span data-stu-id="18a41-146">See `add_logging_handler` and `remove_logging_handler` in the `microsoft::xbox::services::system::xbox_live_services_settings` namespace</span></span>

## <a name="documentation"></a><span data-ttu-id="18a41-147">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="18a41-147">Documentation</span></span>
* <span data-ttu-id="18a41-148">Xbox Live 向けの [Multiplayer Manager](../multiplayer/multiplayer-manager.md)、[XIM](../multiplayer/xbox-integrated-multiplayer.md)、および [multiplayer concepts](../multiplayer/multiplayer-concepts.md) についての新しいドキュメントがあります。</span><span class="sxs-lookup"><span data-stu-id="18a41-148">There is new documentation on the [Multiplayer Manager](../multiplayer/multiplayer-manager.md), [XIM](../multiplayer/xbox-integrated-multiplayer.md), and [multiplayer concepts](../multiplayer/multiplayer-concepts.md) for Xbox Live.</span></span>
* <span data-ttu-id="18a41-149">「[Xbox Live introduction](../get-started-with-partner/get-started-with-xbox-live-partner.md)」セクションが書き換えられました。</span><span class="sxs-lookup"><span data-stu-id="18a41-149">The [Xbox Live introduction](../get-started-with-partner/get-started-with-xbox-live-partner.md) sections have been rewritten.</span></span>  <span data-ttu-id="18a41-150">Xbox Live が有効な新しいタイトルを作成しているか、他の Xbox Live 機能をゲームに組み込むことに興味がある場合は、[ここ](../get-started-with-partner/get-started-with-xbox-live-partner.md)で新しいドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="18a41-150">If you are creating a new Xbox Live enabled title, or are curious about incorporating other Xbox Live functionality into your game, you can see the new docs [here](../get-started-with-partner/get-started-with-xbox-live-partner.md).</span></span>

## <a name="tools"></a><span data-ttu-id="18a41-151">ツール</span><span class="sxs-lookup"><span data-stu-id="18a41-151">Tools</span></span>
* <span data-ttu-id="18a41-152">Xbox Live Trace Analyzer に表示できる[http://aka.ms/XboxLiveTools](http://aka.ms/XboxLiveTools)に CERT モードがあります。</span><span class="sxs-lookup"><span data-stu-id="18a41-152">The Xbox Live Trace Analyzer which you can find at [http://aka.ms/XboxLiveTools](http://aka.ms/XboxLiveTools) now has a CERT mode.</span></span>  
* <span data-ttu-id="18a41-153">また、Xbox Live Trace Analyzer に複数の本体のサポートも追加されました。</span><span class="sxs-lookup"><span data-stu-id="18a41-153">Also in the Xbox Live Trace Analyzer is multi-console support.</span></span>  <span data-ttu-id="18a41-154">複数の本体の HTTP 要求が含まれる Fiddler トレースを渡すと、それぞれの独立したレポートが生成されます。</span><span class="sxs-lookup"><span data-stu-id="18a41-154">If you pass in a Fiddler trace that contains HTTP requests for multiple console, separate reports will be generated for each one.</span></span>
