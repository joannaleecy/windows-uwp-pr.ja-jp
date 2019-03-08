---
title: Xbox Live SDK の新規事項 - April 2016
description: Xbox Live SDK の新規事項 - April 2016
ms.assetid: a6f26ffd-f136-4753-b0cd-92b0da522d93
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9ce63a0174fa0c4158764b8bca2443d58d0aefd9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660767"
---
# <a name="whats-new-for-the-xbox-live-sdk---april-2016"></a><span data-ttu-id="e0d39-104">Xbox Live SDK の新規事項 - April 2016</span><span class="sxs-lookup"><span data-stu-id="e0d39-104">What's new for the Xbox Live SDK - April 2016</span></span>

<span data-ttu-id="e0d39-105">2016 年 3 月に追加された内容については、「[新規事項 - March 2016](1603-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e0d39-105">Please see the [What's New - March 2016](1603-whats-new.md) article for what was added in 1603</span></span>

## <a name="os-and-tool-support"></a><span data-ttu-id="e0d39-106">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="e0d39-106">OS and tool support</span></span>
<span data-ttu-id="e0d39-107">Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="e0d39-107">The Xbox Live SDK supports Windows 10 RTM [Version 10.0.10240] and Visual Studio 2015 RTM [Version 14.0.23107.0].</span></span>

## <a name="tournaments"></a><span data-ttu-id="e0d39-108">トーナメント</span><span class="sxs-lookup"><span data-stu-id="e0d39-108">Tournaments</span></span>
- <span data-ttu-id="e0d39-109">Xbox Live Tournaments Tool が SDK に含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-109">The Xbox Live Tournaments Tool is now included with the SDK.</span></span>  <span data-ttu-id="e0d39-110">使い方に関する情報と共に、Tools ディレクトリに収められています。</span><span class="sxs-lookup"><span data-stu-id="e0d39-110">You can see it in the Tools directory, along with some information on how to use it.</span></span>
- <span data-ttu-id="e0d39-111">トーナメント用 API も使用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-111">The APIs for Tournaments are also available.</span></span>  <span data-ttu-id="e0d39-112">Xbox::Services::Tournaments 名前空間を参照してください</span><span class="sxs-lookup"><span data-stu-id="e0d39-112">See the Xbox::Services::Tournaments namespace</span></span>
- <span data-ttu-id="e0d39-113">ドキュメントはプログラミング ガイドにもあります。</span><span class="sxs-lookup"><span data-stu-id="e0d39-113">Documentation is also available in the Programming Guide.</span></span>

## <a name="documentation"></a><span data-ttu-id="e0d39-114">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="e0d39-114">Documentation</span></span>
- <span data-ttu-id="e0d39-115">「[サインインのトラブルシューティング](../using-xbox-live/troubleshooting/troubleshooting-sign-in.md)」に、サインインの失敗をデバッグするための一般的な方法と、エラー コード別の手順が示されています。</span><span class="sxs-lookup"><span data-stu-id="e0d39-115">[Sign-in Troubleshooting Guide](../using-xbox-live/troubleshooting/troubleshooting-sign-in.md) lists some general strategies to debug sign-in failures, as well as steps to follow based on error code.</span></span>
- <span data-ttu-id="e0d39-116">Xbox One デベロッパー向けの[マーケットプレース](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/xbox-marketplace/marketplace-and-downloadable-content)に関するドキュメントは、プログラミング ガイドだけで提供されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-116">The [Marketplace](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/xbox-marketplace/marketplace-and-downloadable-content) docs for Xbox One developers only can now be found in the Programming Guide.</span></span>  <span data-ttu-id="e0d39-117">UWP 開発者は、ストアのドキュメントについては、パートナー センターを参照してください続行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0d39-117">UWP developers should continue to consult Partner Center for documentation on the store.</span></span>
- <span data-ttu-id="e0d39-118">Xbox One タイトルをユニバーサル Windows プラットフォームに移行する方法については、「[XDK から UWP への Xbox Live コードの移植](../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e0d39-118">There is an [XDK to UWP porting guide](../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md) you can refer to if you are interested in bringing an Xbox One title to the Universal Windows Platform.</span></span>
- <span data-ttu-id="e0d39-119">さまざまな Xbox Live サービス エンドポイントとシナリオへのレート制限の適用についての説明、および制限に関する情報については、「[きめ細かなレート制限](../using-xbox-live/best-practices/fine-grained-rate-limiting.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e0d39-119">Please see the [Fine-Grained Rate Limiting](../using-xbox-live/best-practices/fine-grained-rate-limiting.md) article for a description of how these are enforced for various Xbox Live Service endpoints and scenarios, as well as information about what the limits are.</span></span>

## <a name="multiplayer-manager"></a><span data-ttu-id="e0d39-120">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="e0d39-120">Multiplayer Manager</span></span>
<span data-ttu-id="e0d39-121">[Multiplayer Manager](../multiplayer/multiplayer-manager.md) は試験的機能ではなくなりました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-121">The [Multiplayer Manager](../multiplayer/multiplayer-manager.md) is no longer in experimental.</span></span>  <span data-ttu-id="e0d39-122">この API を使用したデベロッパーからのフィードバックが組み込まれて、API 間の整合性が向上しました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-122">We have incorporated feedback from developers using this API and made some of the APIs more consistent with each other.</span></span>  <span data-ttu-id="e0d39-123">マルチプレイヤー開発の起点として Multiplayer Manager を使用してください。複雑なマルチプレイヤー 2015 API を簡単な API で管理できます。</span><span class="sxs-lookup"><span data-stu-id="e0d39-123">Please use the Multiplayer Manager as a starting point when doing your multiplayer development, as it provides a simpler API that manages many of the complexities of the Multiplayer 2015 API for you.</span></span>

<span data-ttu-id="e0d39-124">以下のセクションでは、API の新機能と、いくつかの大きな変更点について説明します。</span><span class="sxs-lookup"><span data-stu-id="e0d39-124">In the below sections, we have listed some of the new features to the API, as well as a small number of breaking changes.</span></span>

#### <a name="completed-events"></a><span data-ttu-id="e0d39-125">完了イベント</span><span class="sxs-lookup"><span data-stu-id="e0d39-125">Completed events</span></span>
<span data-ttu-id="e0d39-126">すべての API には対応する ``` _competed``` イベントが存在するようになり、すべてのイベントは成功か失敗かに関係なく生成されます。</span><span class="sxs-lookup"><span data-stu-id="e0d39-126">All APIs now have a corresponding``` _competed``` event and all events are fired regardless of success or failure.</span></span> <span data-ttu-id="e0d39-127">従来の動作では、タイトルが対処できるようにエラーがあったときにだけ生成されていました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-127">The previous behavior was that it only triggered upon failure, for the title to take action on.</span></span> <span data-ttu-id="e0d39-128">また、呼び出しはバッチ形式なので、完了時に、タイトルは複数の ```_competed``` イベントを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="e0d39-128">And since calls are batched, it means that upon completion, the title will get multiple ```_competed``` events.</span></span>

| <span data-ttu-id="e0d39-129">API</span><span class="sxs-lookup"><span data-stu-id="e0d39-129">API</span></span> | <span data-ttu-id="e0d39-130">返されるイベント</span><span class="sxs-lookup"><span data-stu-id="e0d39-130">Returned Event</span></span> |
|-----|----------------|
| ```lobby_session()->set_local_member_properties``` |  ```local_member_property_write_completed ```
| ```lobby_session()->set_local_member_connection_address``` | ```local_member_connection_address_write_completed``` |
| ```lobby_session()->set_properties``` | ```session_property_write_completed``` |
| ```lobby_session()->set_synchronized_properties``` | ```session_synchronized_property_write_completed``` |
| ```lobby_session()->set_synchronized_host``` | ```synchronized_host_write_completed``` |

<span data-ttu-id="e0d39-131">```game_session()``` と同じことが適用されます。</span><span class="sxs-lookup"><span data-stu-id="e0d39-131">The same applies for ```game_session()```.</span></span>

#### <a name="application-defined-context"></a><span data-ttu-id="e0d39-132">アプリケーション定義コンテキスト</span><span class="sxs-lookup"><span data-stu-id="e0d39-132">Application defined context</span></span>
<span data-ttu-id="e0d39-133">オプションのアプリケーション定義コンテキストを各 set_\* メソッドに渡して、マルチプレイヤー イベントを開始呼び出しに関連付けることができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-133">You can now pass in an optional application-defined context for each set_\* methods to correlate the multiplayer event to the initiating call.</span></span>
<span data-ttu-id="e0d39-134">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="e0d39-134">For example</span></span>

```cpp
_XSAPIIMP xbox_live_result<void> set_properties(
        _In_ const string_t& name,
        _In_ const web::json::value& valueJson,
        _In_ context_t context = nullptr
       );
```

<span data-ttu-id="e0d39-135">その後、コンテキストは ```_completed``` イベントによってタイトルに戻されます。</span><span class="sxs-lookup"><span data-stu-id="e0d39-135">The context would then be returned back to the title through the ```_completed``` event.</span></span>

#### <a name="breaking-changes"></a><span data-ttu-id="e0d39-136">重要な変更</span><span class="sxs-lookup"><span data-stu-id="e0d39-136">Breaking Changes</span></span>

1.  <span data-ttu-id="e0d39-137">両方の招待 API (```invite_friends``` & ```invite_users```) が同期するようになりました。</span><span class="sxs-lookup"><span data-stu-id="e0d39-137">Both invite APIs (```invite_friends``` & ```invite_users```) are now synchronous.</span></span> <span data-ttu-id="e0d39-138">完了すると、invite_sent イベントを返します。</span><span class="sxs-lookup"><span data-stu-id="e0d39-138">Upon completion, it returns an invite_sent event.</span></span>

2.  <span data-ttu-id="e0d39-139">```write_synchronized_properties_and_commit``` 名前に変更されました```set_synchronized_properties```します。</span><span class="sxs-lookup"><span data-stu-id="e0d39-139">```write_synchronized_properties_and_commit``` was renamed to ```set_synchronized_properties```.</span></span> <span data-ttu-id="e0d39-140">完了すると、```session_synchronized_property_write_completed``` イベントを返します。</span><span class="sxs-lookup"><span data-stu-id="e0d39-140">Upon completion, it returns a ```session_synchronized_property_write_completed``` event.</span></span>

3.  <span data-ttu-id="e0d39-141">```write_synchronized_host_and_commit``` 名前に変更されました```set_synchronized_host```します。</span><span class="sxs-lookup"><span data-stu-id="e0d39-141">```write_synchronized_host_and_commit``` was renamed to ```set_synchronized_host```.</span></span> <span data-ttu-id="e0d39-142">完了すると、```synchronized_host_write_completed``` イベントを返します。</span><span class="sxs-lookup"><span data-stu-id="e0d39-142">Upon completion, it returns a ```synchronized_host_write_completed``` event.</span></span>

4.  <span data-ttu-id="e0d39-143">On ```lobby_session()```</span><span class="sxs-lookup"><span data-stu-id="e0d39-143">On ```lobby_session()```</span></span>

  <span data-ttu-id="e0d39-144">*削除*</span><span class="sxs-lookup"><span data-stu-id="e0d39-144">*Removed*</span></span>

```cpp
_XSAPIIMP const std::unordered_map<string_t, xbox::services:: multiplayer::multiplayer_session_tournaments_server& tournaments_server() const;
```

  <span data-ttu-id="e0d39-145">*追加*</span><span class="sxs-lookup"><span data-stu-id="e0d39-145">*Added*</span></span>

```cpp
_XSAPIIMP const std::unordered_map<string_t, xbox::services::tournaments::tournament_team_result>& tournament_team_results() const;
```

5.  <span data-ttu-id="e0d39-146">On ```game_session()```</span><span class="sxs-lookup"><span data-stu-id="e0d39-146">On ```game_session()```</span></span>

  <span data-ttu-id="e0d39-147">*削除*</span><span class="sxs-lookup"><span data-stu-id="e0d39-147">*Removed*</span></span>

```cpp
_XSAPIIMP const std::unordered_map<string_t, xbox::services:: multiplayer::multiplayer_session_tournaments_server& tournaments_server() const;
_XSAPIIMP const std::unordered_map<string_t, xbox::services:: multiplayer::multiplayer_session_arbitration_server& arbitration_server() const;
```
  <span data-ttu-id="e0d39-148">*追加*</span><span class="sxs-lookup"><span data-stu-id="e0d39-148">*Added*</span></span>

```cpp
_XSAPIIMP const std::unordered_map<string_t, multiplayer_session_reference>& tournament_teams() const;
_XSAPIIMP const std::unordered_map<string_t, xbox::services::tournaments::tournament_team_result>& tournament_team_results() const;
```

6.  <span data-ttu-id="e0d39-149">イベントの種類の変更:</span><span class="sxs-lookup"><span data-stu-id="e0d39-149">Change in event types:</span></span>

  <span data-ttu-id="e0d39-150">*削除*</span><span class="sxs-lookup"><span data-stu-id="e0d39-150">*Removed*</span></span>

```cpp
write_pending_changes_failed,
tournament_property_changed,
arbitration_property_changed
```

  <span data-ttu-id="e0d39-151">*名前変更*</span><span class="sxs-lookup"><span data-stu-id="e0d39-151">*Renamed*</span></span>

  <span data-ttu-id="e0d39-152">```write_synchronized_properties_completed``` 名前に変更 ```session_synchronized_property_write_completed```</span><span class="sxs-lookup"><span data-stu-id="e0d39-152">```write_synchronized_properties_completed``` renamed to ```session_synchronized_property_write_completed```</span></span>

  <span data-ttu-id="e0d39-153">```write_synchronized_host_completed``` 名前に変更 ```synchronized_host_write_completed```</span><span class="sxs-lookup"><span data-stu-id="e0d39-153">```write_synchronized_host_completed``` renamed to ```synchronized_host_write_completed```</span></span>
