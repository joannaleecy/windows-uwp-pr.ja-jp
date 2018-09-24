---
title: Social Manager の概要
author: aablackm
description: オンラインのフレンドを追跡する Xbox Live Social Manager API について説明します。
ms.assetid: d4c6d5aa-e18c-4d59-91f8-63077116eda3
ms.author: aablackm
ms.date: 03/26/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: e022a2d2cdc9eb73877cafaa05d7b55c7e79c744
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4151740"
---
# <a name="introduction-to-social-manager"></a><span data-ttu-id="a5e33-104">Social Manager の概要</span><span class="sxs-lookup"><span data-stu-id="a5e33-104">Introduction to Social Manager</span></span>

## <a name="description"></a><span data-ttu-id="a5e33-105">説明</span><span class="sxs-lookup"><span data-stu-id="a5e33-105">Description</span></span>

<span data-ttu-id="a5e33-106">Xbox Live は、タイトルでさまざまなシナリオに使用できるリッチなソーシャル グラフを提供します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-106">Xbox Live provides a rich social graph that titles can use for various scenarios.</span></span>

<span data-ttu-id="a5e33-107">Xbox Live API (XSAPI) のソーシャル API を利用してソーシャル グラフの情報を取得および管理する作業は手間がかかり、この情報を最新に保つことも複雑になることがあります。</span><span class="sxs-lookup"><span data-stu-id="a5e33-107">Using the social APIs in the Xbox Live API (XSAPI) to obtain and maintain information about a social graph is complex, and keeping this information up to date can be complicated.</span></span>  <span data-ttu-id="a5e33-108">間違った方法でこれを行うと、パフォーマンスの問題、古いデータの使用、また、Xbox Live ソーシャル サービスの呼び出しが必要以上に多いことが原因でスロットリングが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a5e33-108">Not doing this correctly can result in performance issues, stale data, or being throttled due to calling the Xbox Live social services more frequently than necessary.</span></span>

<span data-ttu-id="a5e33-109">Social Manager は、以下の方法でこの問題を解決します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-109">The Social Manager solves this problem by:</span></span>

* <span data-ttu-id="a5e33-110">呼び出しがシンプルな API を作成する</span><span class="sxs-lookup"><span data-stu-id="a5e33-110">Creating a simple API to call</span></span>
* <span data-ttu-id="a5e33-111">バックグラウンドでリアルタイム アクティビティ サービスを使用して最新の情報を作成する</span><span class="sxs-lookup"><span data-stu-id="a5e33-111">Creating up to date information using the real time activity service behind the scenes</span></span>
* <span data-ttu-id="a5e33-112">デベロッパーは、サービスに余計な負荷をかけることなく、Social Manager API を同期的に呼び出すことができる</span><span class="sxs-lookup"><span data-stu-id="a5e33-112">Developers can call the Social Manager API synchronously without any extra strain on the service</span></span>

<span data-ttu-id="a5e33-113">Social Manager は、複数の RTA サブスクリプションの処理とユーザー用データの更新の複雑さを隠し、興味深いシナリオを作成するために必要な最新のグラフをデベロッパーが容易に取得できるようにします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-113">The Social Manager masks the complexity of dealing with multiple RTA subscriptions, and refreshing data for users and allows developers to easily get the up to date graph they want to create interesting scenarios.</span></span>

<span data-ttu-id="a5e33-114">Social Manager のメモリーとパフォーマンスの特性については、「[Social Manager のメモリーとパフォーマンスの概要](social-manager-memory-and-performance-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a5e33-114">For a look at the Social Manager memory and performance characteristics take a look at [Social Manager Memory and Performance Overview](social-manager-memory-and-performance-overview.md)</span></span>

## <a name="features"></a><span data-ttu-id="a5e33-115">機能</span><span class="sxs-lookup"><span data-stu-id="a5e33-115">Features</span></span>

<span data-ttu-id="a5e33-116">Social Manager は以下の機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-116">The Social Manager provides the following features:</span></span>

* <span data-ttu-id="a5e33-117">簡素化された Social API</span><span class="sxs-lookup"><span data-stu-id="a5e33-117">Simplified Social API</span></span>
* <span data-ttu-id="a5e33-118">最新のソーシャル グラフ</span><span class="sxs-lookup"><span data-stu-id="a5e33-118">Up to date social graph</span></span>
* <span data-ttu-id="a5e33-119">表示される情報の詳しさを制御する</span><span class="sxs-lookup"><span data-stu-id="a5e33-119">Control over the verbosity of information displayed</span></span>
* <span data-ttu-id="a5e33-120">Xbox Live サービスの呼び出し回数を減らす</span><span class="sxs-lookup"><span data-stu-id="a5e33-120">Reduce number of calls to Xbox Live services</span></span>
  * <span data-ttu-id="a5e33-121">これはデータ取得における全体的な遅延低減に直接関係する</span><span class="sxs-lookup"><span data-stu-id="a5e33-121">This directly correlates to overall latency reduction in data acquisition</span></span>
* <span data-ttu-id="a5e33-122">スレッド セーフ</span><span class="sxs-lookup"><span data-stu-id="a5e33-122">Thread safe</span></span>
* <span data-ttu-id="a5e33-123">データを効率良く最新の状態に保つ</span><span class="sxs-lookup"><span data-stu-id="a5e33-123">Efficiently keeping data up to date</span></span>

## <a name="core-concepts"></a><span data-ttu-id="a5e33-124">核となる概念</span><span class="sxs-lookup"><span data-stu-id="a5e33-124">Core Concepts</span></span>

<span data-ttu-id="a5e33-125">**ソーシャル グラフ**: *ソーシャル グラフ*はデバイス上のローカル ユーザーに対して作成されます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-125">**Social Graph**: A *social graph* is created for a local user on the device.</span></span> <span data-ttu-id="a5e33-126">これにより、ユーザーのフレンド全員の情報を最新の状態に保つしくみが作成されます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-126">This creates a structure that keeps information about all of a users friends up to date.</span></span>

> [!NOTE]
> <span data-ttu-id="a5e33-127">Windows ではローカル ユーザーは 1 人しか存在できません。</span><span class="sxs-lookup"><span data-stu-id="a5e33-127">On Windows there can only be one local user</span></span>

<span data-ttu-id="a5e33-128">**Xbox ソーシャル ユーザー**: *Xbox ソーシャル ユーザー*は、グループのユーザーと関連付けられるソーシャル データの完全なセットです。</span><span class="sxs-lookup"><span data-stu-id="a5e33-128">**Xbox Social User**: An *Xbox social user* is a full set of social data associated with a user from a group</span></span>

<span data-ttu-id="a5e33-129">**Xbox ソーシャル ユーザー グループ**: グループは、UI への表示などに使用されるユーザーの集団です。</span><span class="sxs-lookup"><span data-stu-id="a5e33-129">**Xbox Social User Group**: A group is a collection of users that is used for things like populating UI.</span></span> <span data-ttu-id="a5e33-130">2 種類のグループがあります。</span><span class="sxs-lookup"><span data-stu-id="a5e33-130">There are two types of groups</span></span>

* <span data-ttu-id="a5e33-131">**フィルター グループ**: フィルター グループはローカル (呼び出し側) ユーザーの*ソーシャル グラフ*を入力として、指定されたフィルター パラメーターに基づいて、常に最新のユーザー セットを返します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-131">**Filter Groups**: A filter group takes a local (calling) user's *social graph* and returns a consistently fresh set of users based on specified filter parameters</span></span>
* <span data-ttu-id="a5e33-132">**ユーザー グループ**: ユーザー グループはユーザーのリストをとり、常にそれらのユーザーの最新のビューを返します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-132">**User Groups**: A user group takes a list of users and returns a consistently fresh view of those users.</span></span> <span data-ttu-id="a5e33-133">これらのユーザーは、ユーザーのフレンド リストに含まれていなくてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="a5e33-133">These users can be outside of a user's friends list.</span></span>

<span data-ttu-id="a5e33-134">*ソーシャル ユーザー グループ*を最新に保つためには、フレームごとに `social_manager::do_work()` 関数を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="a5e33-134">In order to keep a *social user group* up to date the function `social_manager::do_work()` must be called every frame.</span></span>

## <a name="api-overview"></a><span data-ttu-id="a5e33-135">API 概要</span><span class="sxs-lookup"><span data-stu-id="a5e33-135">API Overview</span></span>

<span data-ttu-id="a5e33-136">以下の重要なクラスを最も頻繁に使用することになります。</span><span class="sxs-lookup"><span data-stu-id="a5e33-136">You will most frequently use the following key classes:</span></span>

### <a name="social-manager"></a><span data-ttu-id="a5e33-137">Social Manager</span><span class="sxs-lookup"><span data-stu-id="a5e33-137">Social Manager</span></span>

* <span data-ttu-id="a5e33-138">C++ API クラス名: social_manager</span><span class="sxs-lookup"><span data-stu-id="a5e33-138">C++ API class name: social_manager</span></span>
* <span data-ttu-id="a5e33-139">WinRT(C#) API クラス名: [SocialManager](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xbox.services.social.manager.socialmanager?view=xboxlive-dotnet-2017.11.20171204.01)</span><span class="sxs-lookup"><span data-stu-id="a5e33-139">WinRT(C#) API class name: [SocialManager](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xbox.services.social.manager.socialmanager?view=xboxlive-dotnet-2017.11.20171204.01)</span></span>

<span data-ttu-id="a5e33-140">これは、前述したビューである **Xbox social user groups** を取得するために使用できるシングルトン クラスです。</span><span class="sxs-lookup"><span data-stu-id="a5e33-140">This is a singleton class that can be used to get **Xbox social user groups** which are the views described above.</span></span>

<span data-ttu-id="a5e33-141">Social Manager は Xbox ソーシャル ユーザー グループを最新の状態に保ち、プレゼンスまたはユーザーとの関係によってユーザー グループをフィルタリングできます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-141">The Social Manager will keep xbox social user groups up to date, and can filter user groups by presence or relationship to the user.</span></span>  <span data-ttu-id="a5e33-142">たとえば、ユーザーのフレンドのうち、オンラインであり、現在のタイトルをプレイしている全員を含む Xbox ソーシャル ユーザー グループを作成できます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-142">For example, an xbox social user group containing all of the user's friends who are online and playing the current title could be created.</span></span>  <span data-ttu-id="a5e33-143">フレンドがタイトルのプレイを開始または停止すると、このビューが最新の状態に更新されます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-143">This would be kept up to date as friends start or stop playing the title.</span></span>

### <a name="xbox-social-user-group"></a><span data-ttu-id="a5e33-144">Xbox のソーシャル ユーザー グループ</span><span class="sxs-lookup"><span data-stu-id="a5e33-144">Xbox social user group</span></span>

* <span data-ttu-id="a5e33-145">C++ API クラス名: xbox_social_user_group</span><span class="sxs-lookup"><span data-stu-id="a5e33-145">C++ API class name: xbox_social_user_group</span></span>
* <span data-ttu-id="a5e33-146">WinRT(C#) API クラス名: [XboxSocialUserGroup](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xbox.services.social.manager.xboxsocialusergroup?view=xboxlive-dotnet-2017.11.20171204.01)</span><span class="sxs-lookup"><span data-stu-id="a5e33-146">WinRT(C#) API class name: [XboxSocialUserGroup](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xbox.services.social.manager.xboxsocialusergroup?view=xboxlive-dotnet-2017.11.20171204.01)</span></span>

<span data-ttu-id="a5e33-147">前述したような、特定の基準を満たすユーザーのグループ。</span><span class="sxs-lookup"><span data-stu-id="a5e33-147">A group of users that meet certain criteria, as described above.</span></span> <span data-ttu-id="a5e33-148">Xbox のソーシャル ユーザー グループは、グループのタイプ、追跡中のユーザーまたはグループに設定されているフィルター、および、グループが属するローカル ユーザーを公開します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-148">Xbox social user groups expose what type of a group they are, which users are being tracked or what the filter set is on them, and the local user which the group belongs to.</span></span>

<span data-ttu-id="a5e33-149">Social Manager API の詳しい説明については、「[Xbox Live API リファレンス](https://aka.ms/xboxliveuwpdocs)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a5e33-149">You can find a complete description of the Social Manager APIs in the [Xbox Live API reference](https://aka.ms/xboxliveuwpdocs).</span></span>
<span data-ttu-id="a5e33-150">WinRT API は、[Microsoft.Xbox.Services.Social.Manager.Namespace のドキュメント](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xbox.services.social.manager?view=xboxlive-dotnet-2017.11.20171204.01)でも説明されています。</span><span class="sxs-lookup"><span data-stu-id="a5e33-150">You can also find the WinRT APIs in the [Microsoft.Xbox.Services.Social.Manager.Namespace documentation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.xbox.services.social.manager?view=xboxlive-dotnet-2017.11.20171204.01)</span></span>

## <a name="usage"></a><span data-ttu-id="a5e33-151">使い方</span><span class="sxs-lookup"><span data-stu-id="a5e33-151">Usage</span></span>

### <a name="creating-a-social-user-group-from-filters"></a><span data-ttu-id="a5e33-152">フィルターからソーシャル ユーザー グループを作成する</span><span class="sxs-lookup"><span data-stu-id="a5e33-152">Creating a social user group from filters</span></span>

<span data-ttu-id="a5e33-153">このシナリオで、このユーザーがフォローしている、またはお気に入りとしてタグ付けされたすべての人物など、フィルターからユーザーの一覧を作成します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-153">In this scenario, you want a list of users from a filter, such as all the people this user is following or tagged as favorite.</span></span>

#### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-154">C++ API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-154">Source example using the C++ API</span></span>

```cpp
//#include "Social.h"

auto socialManager = social_manager::get_singleton_instance();

socialManger->add_local_user(
    xboxLiveContext->user(),
    social_manager_extra_detail_level::preferred_color_level | social_manager_extra_detail_level::title_history_level
    );

auto socialUserGroup = socialManager->create_social_user_group_from_filters(
    xboxLiveContext->user(),
    presence_filter::all,
    relationship_filter::friends
    );

while(true)
{
    // some update loop in the game
    socialManager->do_work();
    // TODO: render the friends list using game UI, passing in socialUserGroup->users()
}
```

#### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-155">C# API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-155">Source example using the C# API</span></span>

```csharp
// using Microsoft.Xbox.Services;
// using Microsoft.Xbox.Services.System;
// using Microsoft.Xbox.Services.Social.Manager;

socialManager = SocialManager.SingletonInstance;

socialManager.AddLocalUser(
     xboxLiveContext.User,
     SocialManagerExtraDetailLevel.PreferredColorLevel | SocialManagerExtraDetailLevel.TitleHistoryLevel
     );

socialUserGroup = socialManager.CreateSocialUserGroupFromFilters(
     xboxLiveContext.User,
     PresenceFilter.All,
     RelationshipFilter.Friends
     );

while(true)
{
     // some update loop in the game
     socialManager.DoWork();
     // // TODO: render the friends list using game UI, passing in socialUserGroup.Users
}

```

#### <a name="events-returned"></a><span data-ttu-id="a5e33-156">返されるイベント</span><span class="sxs-lookup"><span data-stu-id="a5e33-156">Events Returned</span></span>

`local_user_added`<span data-ttu-id="a5e33-157">(C++) | `LocalUserAdded`(C#) - ユーザーのソーシャル グラフの読み込みが完了したときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-157">(C++) | `LocalUserAdded`(C#) - Triggers when loading of users social graph is complete.</span></span> <span data-ttu-id="a5e33-158">初期化中に何らかのエラーが発生した場合、そのことを示します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-158">Will indicate if any errors occurred during initialization</span></span>

`social_user_group_loaded`<span data-ttu-id="a5e33-159">(C++) | `SocialUserGroupLoaded`(C#) - ソーシャル ユーザー グループが作成されたときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-159">(C++) | `SocialUserGroupLoaded`(C#) - Triggers when social user group has been created</span></span>

`users_added_to_social_graph`<span data-ttu-id="a5e33-160">(C++) | `UsersAddedToSocialGraph`(C#) - ユーザーが読み込まれるときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-160">(C++) | `UsersAddedToSocialGraph`(C#) - Triggers when users are loaded in</span></span>

#### <a name="additional-details"></a><span data-ttu-id="a5e33-161">追加情報</span><span class="sxs-lookup"><span data-stu-id="a5e33-161">Additional details</span></span>

<span data-ttu-id="a5e33-162">上の例は、ユーザーに対して Social Manager を初期化する方法、そのユーザーに対してソーシャル ユーザー グループを作成する方法、グループを最新の状態に保つ方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a5e33-162">The above example shows how to initialize the Social Manager for a user, create a social user group for that user, and keep it up to date.</span></span>

<span data-ttu-id="a5e33-163">フィルタリング オプションは `presence_filter` および `relationship_filter` 列挙で確認できます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-163">The filtering options can be seen in the `presence_filter` and `relationship_filter` enums</span></span>

<span data-ttu-id="a5e33-164">ゲーム ループで、`do_work` 関数は、すべての作成済みビューをそのグループにいるユーザーの最新スナップショットで更新します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-164">In the game loop, the `do_work` function updates all created views with the latest snapshot of the users in that group.</span></span>

<span data-ttu-id="a5e33-165">ビューにいるユーザーは `xbox_social_user_group::get_users()` 関数を呼び出して取得できます。この関数は `xbox_social_user` オブジェクトのリストを返します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-165">The users in the view can be obtained by calling the `xbox_social_user_group::get_users()` function which returns a list of `xbox_social_user` objects.</span></span>  <span data-ttu-id="a5e33-166">`xbox_social_user` には、ゲーマータグ、ゲーマーアイコン URI などのソーシャル情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-166">The `xbox_social_user` contains the social information such as gamertag, gamerpic uri, etc.</span></span>

### <a name="create-and-update-a-social-user-group-from-list"></a><span data-ttu-id="a5e33-167">リストからソーシャル ユーザー グループを作成および更新する</span><span class="sxs-lookup"><span data-stu-id="a5e33-167">Create and update a social user group from list</span></span>

<span data-ttu-id="a5e33-168">このシナリオで、マルチプレイヤー セッションのユーザーなど、ユーザー一覧のソーシャル情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-168">In this scenario, you want the social information of a list of users such as users in a multiplayer session.</span></span>

#### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-169">C++ API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-169">Source example using the C++ API</span></span>

```cpp
//#include "Social.h"

auto socialManager = social_manager::get_singleton_instance();

socialManger->add_local_user(
    xboxLiveContext->user(),
    social_manager_extra_detail_level::preferred_color_level | social_manager_extra_detail_level::title_history_level
    );

auto socialUserGroup = socialManager->create_social_user_group_from_list(
    xboxLiveContext->user(),
    userList  // this is a std::vector<string_t> (list of xuids)
    );

while(true)
{
    // some update loop in the game
    socialManager->do_work();
    // TODO: render the friends list using game UI, passing in socialUserGroup->users()
}
```

#### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-170">C# API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-170">Source example using the C# API</span></span>

```csharp
// using Microsoft.Xbox.Services;
// using Microsoft.Xbox.Services.System;
// using Microsoft.Xbox.Services.Social.Manager;

socialManager = SocialManager.SingletonInstance;

socialManager.AddLocalUser(
     xboxLiveContext.User,
     SocialManagerExtraDetailLevel.PreferredColorLevel | SocialManagerExtraDetailLevel.TitleHistoryLevel
     );

socialUserGroup = socialManager.CreateSocialUserGroupFromList(
     xboxLiveContext.User,
     userList //this is a IReadOnlyList<string> (list of xbox user ids a.k.a. xuids)
    );

while(true)
{
     // some update loop in the game
     socialManager.DoWork();
     // // TODO: render the friends list using game UI, passing in socialUserGroup.Users
}
```

#### <a name="events-returned"></a><span data-ttu-id="a5e33-171">返されるイベント</span><span class="sxs-lookup"><span data-stu-id="a5e33-171">Events Returned</span></span>

`local_user_added`<span data-ttu-id="a5e33-172">(C++) | `LocalUserAdded`(C#) - ユーザーのソーシャル グラフの読み込みが完了したときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-172">(C++) | `LocalUserAdded`(C#) - Triggers when loading of users social graph is complete.</span></span> <span data-ttu-id="a5e33-173">初期化中に何らかのエラーが発生した場合、そのことを示します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-173">Will indicate if any errors occurred during initialization</span></span>

`social_user_group_loaded`<span data-ttu-id="a5e33-174">(C++) | `SocialUserGroupLoaded`(C#) - ソーシャル ユーザー グループが作成されたときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-174">(C++) | `SocialUserGroupLoaded`(C#)- Triggers when social user group has been created</span></span>

`users_added_to_social_graph`<span data-ttu-id="a5e33-175">(C++) | `UsersAddedToSocialGraph`(C#) - ユーザーが読み込まれるときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-175">(C++) | `UsersAddedToSocialGraph`(C#)- Triggers when users are loaded in</span></span>

### <a name="updating-social-user-group-from-list"></a><span data-ttu-id="a5e33-176">リストからソーシャル ユーザー グループを更新する</span><span class="sxs-lookup"><span data-stu-id="a5e33-176">Updating Social User Group From List</span></span>

<span data-ttu-id="a5e33-177">update_social_user_group() を呼び出すことによって、ソーシャル ユーザー グループで追跡対象ユーザーの一覧を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-177">You can also change the list of tracked users in the social user group by calling update_social_user_group()</span></span>

#### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-178">C++ API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-178">Source example using the C++ API</span></span>

```cpp
//#include "Social.h"

socialManager->update_social_user_group(
    xboxSocialUserGroup,
    newUserList    // std::vector<string_t> (list of xuids)
    );

    while(true)
    {
    // some update loop in the game
    socialManager->do_work();
    // TODO: render the friends list using game UI, passing in socialUserGroup->users()
    }
```

#### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-179">C# API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-179">Source example using the C# API</span></span>

```csharp
// using Microsoft.Xbox.Services.Social.Manager;

socialManager.UpdateSocialUserGroup(
     xboxSocialUserGroup,
     newUserList //IReadOnlyList<string> (list of xbox user ids a.k.a. xuids)
     );

while(true)
{
     // some update loop in the game
     socialManager.DoWork();
     // // TODO: render the friends list using game UI, passing in socialUserGroup.Users
}
```

#### <a name="events-returned"></a><span data-ttu-id="a5e33-180">返されるイベント</span><span class="sxs-lookup"><span data-stu-id="a5e33-180">Events Returned</span></span>

`social_user_group_updated`<span data-ttu-id="a5e33-181">(C++) | `SocialUserGroupUpdated`(C#) - ソーシャル ユーザー グループの更新が完了したときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-181">(C++) | `SocialUserGroupUpdated`(C#) - Triggers when social user group updating is complete.</span></span>

`users_added_to_social_graph`<span data-ttu-id="a5e33-182"> | `UsersAddedToSocialGraph\`(C#) - ユーザーが読み込まれるときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-182"> | `UsersAddedToSocialGraph\`(C#) - Triggers when users are loaded in.</span></span> <span data-ttu-id="a5e33-183">リストから追加されるユーザーが既にグラフにいる場合、このイベントはトリガーしません。</span><span class="sxs-lookup"><span data-stu-id="a5e33-183">If users added via list are already in graph, this event will not trigger</span></span>

### <a name="using-social-manager-events"></a><span data-ttu-id="a5e33-184">Social Manager イベントの使用</span><span class="sxs-lookup"><span data-stu-id="a5e33-184">Using Social Manager events</span></span>

<span data-ttu-id="a5e33-185">Social Manager からイベントの形で発生したことも通知されます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-185">Social Manager will also tell you what happened in the form of events.</span></span>  <span data-ttu-id="a5e33-186">これらのイベントを使用して、UI を更新またはその他のロジックを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-186">You can use those events to update your UI or perform other logic.</span></span>

#### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-187">C++ API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-187">Source example using the C++ API</span></span>

```cpp
//#include "Social.h"

auto socialManager = social_manager::get_singleton_instance();
socialManger->add_local_user(
    xboxLiveContext->user(),
    social_manager_extra_detail_level::no_extra_detail
    );

auto socialUserGroup = socialManager->create_social_user_group_from_filters(
    xboxLiveContext->user(),
    presence_filter::all,
    relationship_filter::friends
    );

socialManager->do_work();
// TODO: initialize the game UI containing the friends list using game UI, socialUserGroup->users()

while(true)
{
    // some update loop in the game
    auto events = socialManager->do_work();
    for(auto evt : events)
    {
        auto affectedUsersFromGraph = socialUserGroup->get_users_from_xbox_user_ids(evt.users_affected());
        // TODO: render the changes to the friends list using game UI, passing in affectedUsersFromGraph
    }
}
```

##### <a name="source-example-using-the-c-api"></a><span data-ttu-id="a5e33-188">C# API を使用したソースのサンプル</span><span class="sxs-lookup"><span data-stu-id="a5e33-188">Source example using the C# API</span></span>

```csharp
// using Microsoft.Xbox.Services;
// using Microsoft.Xbox.Services.System;
// using Microsoft.Xbox.Services.Social.Manager;

socialManager = SocialManager.SingletonInstance;

socialManager.AddLocalUser(
     xboxLiveContext.User,
     SocialManagerExtraDetailLevel.PreferredColorLevel | SocialManagerExtraDetailLevel.TitleHistoryLevel
     );

socialUserGroup = socialManager.CreateSocialUserGroupFromFilters(
     xboxLiveContext.User,
     PresenceFilter.All,
     RelationshipFilter.Friends
     );

socialManager.DoWork();
// TODO: initialize the game UI containing the friends list using game UI, socialUserGroup->users()

while(true)
{
    // some update loop in the game
    IReadOnlyList<SocialEvent> Events = socialManager.DoWork();
    IReadOnlyList<XboxSocialUser> affectedUsersFromGraph;
    foreach(SocialEvent managerEvent in Events)
    {
        affectedUsersFromGraph = socialUserGroup.GetUsersFromXboxUserIds(managerEvent.UsersAffected);
    }
}

```

#### <a name="events-returned"></a><span data-ttu-id="a5e33-189">返されるイベント</span><span class="sxs-lookup"><span data-stu-id="a5e33-189">Events Returned</span></span>

`local_user_added`<span data-ttu-id="a5e33-190">(C++) | `LocalUserAdded`(C#) - ユーザーのソーシャル グラフの読み込みが完了したときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-190">(C++) | `LocalUserAdded`(C#) - Triggers when loading of users social graph is complete.</span></span> <span data-ttu-id="a5e33-191">初期化中に何らかのエラーが発生した場合、そのことを示します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-191">Will indicate if any errors occurred during initialization</span></span>

`social_user_group_loaded`<span data-ttu-id="a5e33-192">(C++) | `SocialUserGroupLoaded`(C#) - ソーシャル ユーザー グループが作成されたときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-192">(C++) | `SocialUserGroupLoaded`(C#)- Triggers when social user group has been created</span></span>

`users_added_to_social_graph`<span data-ttu-id="a5e33-193">(C++) | `UsersAddedToSocialGraph`(C#) - ユーザーが読み込まれるときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-193">(C++) | `UsersAddedToSocialGraph`(C#)- Triggers when users are loaded in</span></span>

#### <a name="additional-details"></a><span data-ttu-id="a5e33-194">追加情報</span><span class="sxs-lookup"><span data-stu-id="a5e33-194">Additional details</span></span>

<span data-ttu-id="a5e33-195">この例は、提供されている追加制御の一部を示しています。</span><span class="sxs-lookup"><span data-stu-id="a5e33-195">This example shows some of the additional control offered.</span></span>  <span data-ttu-id="a5e33-196">ゲーム ループの間、ソーシャル ユーザー グループ フィルターに依拠して最新のユーザー リストを取得する代わりに、ゲーム ループの外側でソーシャル グラフを初期化します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-196">Rather than relying on the social user group filters to provide a fresh user list during the game loop, the social graph is initialized outside the game loop.</span></span>  <span data-ttu-id="a5e33-197">タイトルはその後、`socialManager->do_work()` 関数によって返される `events` に依拠します。</span><span class="sxs-lookup"><span data-stu-id="a5e33-197">Then the title relies upon the `events` returned by the `socialManager->do_work()` function.</span></span>  `events` <span data-ttu-id="a5e33-198">は `social_event` のリストであり、各 `social_event` には、最終フレームの間に発生したソーシャル グラフへの変更が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-198">is a list of `social_event`, and each `social_event` contains a change to the social graph that occurred during the last frame.</span></span>  <span data-ttu-id="a5e33-199">たとえば、`profiles_changed`、`users_added` などです。詳しくは、`social_event` API ドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a5e33-199">For example `profiles_changed`, `users_added`, etc.  More information can be found in the `social_event` API documentation.</span></span>

### <a name="cleanup"></a><span data-ttu-id="a5e33-200">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="a5e33-200">Cleanup</span></span>

#### <a name="cleaning-up-social-user-groups"></a><span data-ttu-id="a5e33-201">ソーシャル ユーザー グラフをクリーンアップする</span><span class="sxs-lookup"><span data-stu-id="a5e33-201">Cleaning Up Social User Groups</span></span>

```cpp
//#include "Social.h"

socialManger->destroy_social_user_group(
    socialUserGroup
    );
```

```csharp
// using Microsoft.Xbox.Services.Social.Manager;

socialManager.DestroySocialUserGroup(
     socialUserGroup
     );
```

<span data-ttu-id="a5e33-202">作成されたソーシャル ユーザー グループをクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-202">Cleans up the social user group that was created.</span></span> <span data-ttu-id="a5e33-203">作成されたソーシャル ユーザー グループに含まれているデータは古くなっているため、そのソーシャル ユーザー グループへの参照が呼び出し元にある場合、そのような参照もすべて削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a5e33-203">Caller should also remove any references they have to any created social user group as it now contains stale data.</span></span>

#### <a name="cleaning-up-local-users"></a><span data-ttu-id="a5e33-204">ローカル ユーザーをクリーンアップする</span><span class="sxs-lookup"><span data-stu-id="a5e33-204">Cleaning Up Local Users</span></span>

```cpp
//#include "Social.h"

socialManger->remove_local_user(
    xboxLiveContext->user()
    );
```

```csharp
// using Microsoft.Xbox.Services.Social.Manager;

socialManager.RemoveLocalUser(
     xboxLiveContext.User
     );
```

<span data-ttu-id="a5e33-205">remove_local_user では、読み込まれたユーザーのソーシャル グラフに加えて、そのユーザーを使用して作成されたすべてのソーシャル ユーザー グループが削除されます。</span><span class="sxs-lookup"><span data-stu-id="a5e33-205">Remove local user removes the loaded users social graph, as well as any social user groups that were created using that user.</span></span>

#### <a name="events-returned"></a><span data-ttu-id="a5e33-206">返されるイベント</span><span class="sxs-lookup"><span data-stu-id="a5e33-206">Events Returned</span></span>

`local_user_removed`<span data-ttu-id="a5e33-207">(C++) | `LocalUserRemoved`(C#) - ローカル ユーザーが正常に削除されたときにトリガーします。</span><span class="sxs-lookup"><span data-stu-id="a5e33-207">(C++) | `LocalUserRemoved`(C#) - Triggers when a local user has been removed successfully</span></span>