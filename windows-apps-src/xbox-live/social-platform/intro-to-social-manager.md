---
title: "Social Manager の概要"
author: KevinAsgari
description: "オンラインのフレンドを追跡する Xbox Live Social Manager API について説明します。"
ms.assetid: d4c6d5aa-e18c-4d59-91f8-63077116eda3
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one"
ms.openlocfilehash: 94b2c86b7572eb90ebb961dd0b8d6fa3bdb25d33
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="introduction-to-social-manager"></a>Social Manager の概要

## <a name="description"></a>説明
Xbox Live は、タイトルでさまざまなシナリオに使用できるリッチなソーシャル グラフを提供します。

Xbox Live API (XSAPI) のソーシャル API を利用してソーシャル グラフの情報を取得および管理する作業は手間がかかり、この情報を最新に保つことも複雑になることがあります。  間違った方法でこれを行うと、パフォーマンスの問題、古いデータの使用、また、Xbox Live ソーシャル サービスの呼び出しが必要以上に多いことが原因でスロットリングが発生する可能性があります。

Social Manager は、以下の方法でこの問題を解決します。

* 呼び出しがシンプルな API を作成する
* バックグラウンドでリアルタイム アクティビティ サービスを使用して最新の情報を作成する
* デベロッパーは、サービスに余計な負荷をかけることなく、Social Manager API を同期的に呼び出すことができる

Social Manager は、複数の RTA サブスクリプションの処理とユーザー用データの更新の複雑さを隠し、興味深いシナリオを作成するために必要な最新のグラフをデベロッパーが容易に取得できるようにします。

Social Manager のメモリーとパフォーマンスの特性については、「[Social Manager のメモリーとパフォーマンスの概要](social-manager-memory-and-performance-overview.md)」を参照してください。  

## <a name="features"></a>機能
Social Manager は以下の機能を提供します。

* 簡素化された Social API
* 最新のソーシャル グラフ
* 表示される情報の詳しさを制御する
* Xbox Live サービスの呼び出し回数を減らす
    * これはデータ取得における全体的な遅延低減に直接関係する
* スレッド セーフ
* データを効率良く最新の状態に保つ

## <a name="core-concepts"></a>核となる概念

**ソーシャル グラフ**: *ソーシャル グラフ*はデバイス上のローカル ユーザーに対して作成されます。 これにより、ユーザーのフレンド全員の情報を最新の状態に保つしくみが作成されます。

* 注: Windows ではローカル ユーザーは 1 人しか存在できません。

**Xbox ソーシャル ユーザー**: *Xbox ソーシャル ユーザー*は、グループのユーザーと関連付けられるソーシャル データの完全なセットです。

**Xbox ソーシャル ユーザー グループ**: グループは、UI への表示などに使用されるユーザーの集団です。 2 種類のグループがあります。

* **フィルター グループ**: フィルター グループはローカル (呼び出し側) ユーザーの*ソーシャル グラフ*を入力として、指定されたフィルター パラメーターに基づいて、常に最新のユーザー セットを返します。
* **ユーザー グループ**: ユーザー グループはユーザーのリストをとり、常にそれらのユーザーの最新のビューを返します。 これらのユーザーは、ユーザーのフレンド リストに含まれていなくてもかまいません。

*ソーシャル グラフ*を最新に保つためには、フレームごとに **do_work()** を呼び出す必要があります。

## <a name="api-overview"></a>API 概要
以下の重要なクラスを最も頻繁に使用することになります。

### <a name="social-manager"></a>Social Manager
これは、前述したビューである `xbox_social_user_groups` を取得するために使用できるシングルトン クラスです。

`social_manager` は `xbox_social_user_groups` を最新の状態に保ち、プレゼンスまたはユーザーとの関係によって `xbox_social_user_groups` をフィルタリングできます。  たとえば、ユーザーのフレンドのうち、オンラインであり、現在のタイトルをプレイしている全員を含む `xbox_social_user_groups` を作成できます。  フレンドがタイトルのプレイを開始または停止すると、このビューが最新の状態に更新されます。

### <a name="xbox-social-user-group"></a>Xbox のソーシャル ユーザー グループ
前述したような、特定の基準を満たすユーザーのグループ。 Xbox のソーシャル ユーザー グループは、グループのタイプ、追跡中のユーザーまたはグループに設定されているフィルター、および、グループが属するローカル ユーザーを公開します。

API の完全な説明は、`social_manager.h` ヘッダー、C++ API ドキュメントの `social_manager` クラスの項目、WinRT ドキュメントの `SocialManager` クラスの項目で参照できます。

## <a name="usage"></a>使い方

### <a name="creating-a-social-user-group-from-filters"></a>フィルターからソーシャル ユーザー グループを作成する

このシナリオで、このユーザーがフォローしている、またはお気に入りとしてタグ付けされたすべての人物など、フィルターからユーザーの一覧を作成します。

**C++ API を使用したソースのサンプル**

```cpp
    auto socialManager = social_manager::get_singleton_instance();

    socialManger->add_local_user(
      xboxLiveContext,
      social_manager_extra_detail_level::preferred_color_level | social_manager_extra_detail_level::title_history_level
      );

    auto socialUserGroup = socialManager->create_social_user_group_from_filters(
      xboxLiveContext,
      presence_filter::all,
      relationship_filter::following
      );

    while(true)
    {
      // some update loop in the game
      socialManager->do_work();
      // TODO: render the friends list using game UI, passing in socialUserGroup->users()
    }
```

**返されるイベント**

`local_user_added` - ユーザーのソーシャル グラフの読み込みが完了したときにトリガーします。 初期化中に何らかのエラーが発生した場合、そのことを示します。

`social_user_group_loaded`- ソーシャル ユーザー グループが作成されたときにトリガーします。

`users_added_to_social_graph`- ユーザーが読み込まれるときにトリガーします。

**追加情報**

上の例は、ユーザーに対して Social Manager を初期化し、そのユーザーに対してソーシャル ユーザー グループを作成し、グループを最新の状態に保つ方法を示しています。

フィルタリング オプションは `presence_filter` および `relationship_filter` 列挙で確認できます。

ゲーム ループで、`do_work` 関数は、すべての作成済みビューをそのグループにいるユーザーの最新スナップショットで更新します。

ビューにいるユーザーは `xbox_social_user_group::get_users()` 関数を呼び出して取得できます。この関数は `xbox_social_user` のリストを返します。  `xbox_social_user` には、ゲーマータグ、ゲーマーアイコン URI などのソーシャル情報が含まれます。

### <a name="create-and-update-a-social-user-group-from-list"></a>リストからソーシャル ユーザー グループを作成および更新する

このシナリオで、マルチプレイヤー セッションのユーザーなど、ユーザー一覧のソーシャル情報を取得します。

**C++ API を使用したソースのサンプル**

```cpp
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

**返されるイベント**

`local_user_added` - ユーザーのソーシャル グラフの読み込みが完了したときにトリガーします。 初期化中に何らかのエラーが発生した場合、そのことを示します。

`social_user_group_loaded`- ソーシャル ユーザー グループが作成されたときにトリガーします。

`users_added_to_social_graph`- ユーザーが読み込まれるときにトリガーします。

**リストからソーシャル ユーザー グループを更新する**

update_social_user_group() を呼び出すことによって、ソーシャル ユーザー グループで追跡対象ユーザーの一覧を変更することもできます。

**C++ API を使用したソースのサンプル**

```cpp
    socialManager->update_social_user_group(
       socialUserGroup,
       newUserList  // std::vector<string_t> (list of xuids)
       );

     while(true)
     {
       // some update loop in the game
       socialManager->do_work();
       // TODO: render the friends list using game UI, passing in socialUserGroup->users()
     }
```

**返されるイベント**

`social_user_group_updated`- ソーシャル ユーザー グループの更新が完了したときにトリガーします。

`users_added_to_social_graph`- ユーザーが読み込まれるときにトリガーします。 リストから追加されるユーザーが既にグラフにいる場合、このイベントはトリガーしません。

### <a name="using-social-manager-events"></a>ソーシャル マネージャー イベントの使用

ソーシャル マネージャーからイベントの形で発生したことも通知されます。  これらのイベントを使用して、UI を更新またはその他のロジックを実行することができます。

**C++ API を使用したソースのサンプル**

```cpp
    auto socialManager = social_manager::get_singleton_instance();
    socialManger->add_local_user(
        xboxLiveContext->user(),
        social_manager_extra_detail_level::no_extra_detail
        );

    auto socialUserGroup = socialManager->create_social_user_group_from_filters(
        xboxLiveContext->user(),
        presence_filter::all,
        relationship_filter::following
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

**返されるイベント**

`local_user_added` - ユーザーのソーシャル グラフの読み込みが完了したときにトリガーします。 初期化中に何らかのエラーが発生した場合、そのことを示します。

`social_user_group_loaded`- ソーシャル ユーザー グループが作成されたときにトリガーします。

`users_added_to_social_graph`- ユーザーが読み込まれるときにトリガーします。

**追加情報**

この例は、提供されている追加制御の一部を示しています。  ゲーム ループの間、ソーシャル ユーザー グループ フィルターに依拠して最新のユーザー リストを取得する代わりに、ゲーム ループの外側でソーシャル グラフを初期化します。  タイトルはその後、`socialManager->do_work()` 関数によって返される `events` に依拠します。  `events` は `social_event` のリストであり、各 `social_event` には、最終フレームの間に発生したソーシャル グラフへの変更が含まれます。  たとえば、`profiles_changed`、`users_added` などです。詳しくは、`social_event` API ドキュメントをご覧ください。

### <a name="cleanup"></a>クリーンアップ
**ソーシャル ユーザー グラフをクリーンアップする**

```cpp
    socialManger->destroy_social_user_group(
       socialUserGroup
       );
```

作成されたソーシャル ユーザー グループをクリーンアップします。 作成されたソーシャル ユーザー グループに含まれているデータは古くなっているため、そのソーシャル ユーザー グループへの参照が呼び出し元にある場合、そのような参照もすべて削除する必要があります。

**ローカル ユーザーをクリーンアップする**

```cpp
    socialManger->remove_local_user(
       xboxLiveContext->user()
       );
```

remove_local_user では、読み込まれたユーザーのソーシャル グラフに加えて、そのユーザーを使用して作成されたすべてのソーシャル ユーザー グループが削除されます。

**返されるイベント**

`local_user_removed` ローカル ユーザーが正常に削除されたときにトリガーします。
