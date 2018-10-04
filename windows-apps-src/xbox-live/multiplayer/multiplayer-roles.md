---
title: マルチプレイヤーのロール
author: KevinAsgari
description: ロールを使用して Xbox Live マルチプレイヤーでのプレイヤー ロールを定義する方法について説明します。
ms.author: kevinasg
ms.date: 06/29/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, ロール
ms.localizationpriority: medium
ms.openlocfilehash: 0ab0a8fd83e94af9a06582faebc2923eb459996b
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4312761"
---
# <a name="roles"></a>ロール

ゲーム セッションによっては、特定のメンバーに支援、看護、突撃などの特定のゲームプレイ ロールを指定したり、特定のゲームプレイ ロールを持つプレイヤーのためにゲーム スロットを予約する必要がある場合があります。 Xbox Live のロール機能を使用することで、サービスはプレイヤーに対するゲームプレイ ロールの割り当てを追跡し、特定のゲームプレイ ロールを選択できるプレイヤーの最大数を設定することができます。

ロールの最も一般的な用途は、そのゲーム セッションに対するゲーム固有のロールを決定することです。 たとえば、1 ～ 2 人の支援クラス、1 人以上の重戦車クラス、5 人以下の突撃クラスを必要とするゲーム モードを設定できます。

厳密に 4 人のゲーム プレイヤー、最大 8 人の観戦者、1 人のアナウンサーで構成されるゲーム シナリオを指定することもできます。

また、ロールを使用してフレンド用のスロットを予約し、残りのスロットはセッション参照などの他の手段で埋めることもできます。

## <a name="role-types"></a>ロールの種類

ロールの種類は、ロール定義のグループを表します。 すべてのロールは、ロールの種類の一部として定義されている必要があります。 ロールの種類は通常、マルチプレイヤー セッション ドキュメントで定義されます。

特定のロールの種類から 1 人のメンバーに割り当てることができるロールは 1 つだけです。 たとえば、"クラス" というロールの種類にヒーラー、タンク、ダメージが含まれる場合、1 人のメンバーにはこれらのロールのいずれか 1 つだけを割り当てることができます。

複数のロールの種類を定義でき、1 人のメンバーには各ロールの種類から 1 つのロールを割り当てることができます。 前のシナリオで、スクワッド リーダー ロールが別のロールの種類で定義されている場合は、ヒーラー ロールを選択したメンバーに、スクワッド リーダー ロールも割り当てることができます。

> **重要:** 現在の Xbox Live SDK では、1 人のメンバーに対しては 1 つのロールの種類と 1 つのロールだけがサポートされます。

## <a name="role-type-properties"></a>ロールの種類のプロパティ

ロールの種類を定義するときは、ロールの種類に対して次の情報を指定する必要があります。

* ロールの種類の名前。 名前は 100 文字以下の小文字の英数字にする必要があります。
* ロールの種類で定義されているロールが所有者によって管理されているかどうか。
* ロールの種類で定義されているロールのプロパティを、セッションの存在期間中に変更できるかどうか。
* ロールの種類に含まれるロールの定義。

ロールの種類が所有者によって管理されている場合は、セッションの所有者であるメンバーだけがその種類のロールをメンバーに割り当てることができます。 ロールの種類が所有者によって管理されていない場合は、メンバーが自分自身にロールを割り当てることができます。

ロールの種類が所有者による管理であることを指定できるのは、セッションで "hasOwners" 機能が設定されている場合のみです。

> 現在、Xbox Live SDK では所有者による他のメンバーへのロールの割り当てがサポートされていません。

## <a name="role-properties"></a>ロールのプロパティ

ロールを定義するときは、各ロールに対して次の情報を指定する必要があります。

* ロールの名前。 名前は 100 文字以下の小文字の英数字にする必要があります。
* ロールに指定できるメンバーの最大数。 ゼロより大きい値にする必要があります。
* ロールに指定する必要があるメンバーの目標数。 目標数は 0 より大きく、ロールに指定できるメンバーの最大数以下である必要があります。

セッション メンバーにロールが割り当てられると、その情報がマルチプレイヤー セッション ドキュメントのメンバー ロールに記録されます。

ロールに割り当てることができるメンバーの最大数はサービスによって強制されますが、目標数は強制されません。

## <a name="create-roles"></a>ロールを作成する

ロールとロールの種類は通常、[セッション テンプレート](service-configuration/session-templates.md)で定義されます。 サービスはセッション作成の間にロールおよびロールの種類の定義をサポートしますが、Xbox Live SDK はサポートしません。

### <a name="define-role-types-and-roles-in-a-session-template"></a>セッション テンプレートでロールの種類とロールを定義する

Xbox Live の構成時にセッション テンプレートを作成するときに、ロールの種類とロールを定義できます。

ロールの種類およびロールの情報は、次の形式で、セッション テンプレートの基本レベルの "roleTypes" 要素として指定されます。

```json
"roleTypes": {
  "myroletype1": { // must be lowercase alpha-numeric.
    "ownerManaged": true, // Can only be true on sessions with the "hasOwners" capability set. If true, only the owner of the session can assign this role to members.
    "mutableRoleSettings": ["max", "target"], // Which role settings for roles in this role type can be modified throughout the life of the session. Exclude role settings to lock them.
    "roles": {
      "role1": { // must be lowercase alpha-numeric.
        "max": 3, // Max number of members assigned to this role at a time, enforced by MPSD.
        "target": 2 // Target number of members to assign this role to. Like max, but not enforced (can be exceeded).
      },
      "role2": {
        ...
      }
  },
  "myroletype2": {
    ...
  }
},
```

## <a name="retrieve-role-information-for-a-multiplayer-session"></a>マルチプレイヤー セッションのロール情報を取得する

マルチプレイヤー セッションまたはマルチプレイヤー検索ハンドルから、ロールの種類、ロール、各ロールに割り当てられているメンバーの数に関する情報を取得できます。

Xbox Live SDK では、ロールの種類とロールに関する情報はマップ構造内に格納されます。 C++ API では `unordered_map` クラスが使用され、WinRT API では `IMapView` クラスが使用されます。

### <a name="get-the-role-information-from-a-search-handle"></a>検索ハンドルからロールの情報を取得する

検索要求から返される `multiplayer_search_handle_details` オブジェクトでは、必要なロールの種類の名前を使用して `role_types` マップをインデックス指定することにより、ロールの種類の情報を取得できます。

これにより、`multiplayer_role_type` オブジェクトが返されます。 `roles` マップをインデックス指定することによりロールを取得でき、`multiplayer_role_info` オブジェクトが返されます。

`multiplayer_role_info` オブジェクトには、`max_members_count`、`member_xbox_user_ids`、`members_count`、`target_count` など、ロールに関する情報が含まれています。

### <a name="get-the-role-information-from-a-search-handle"></a>検索ハンドルからロールの情報を取得する

セッションからロールの情報を取得する流れは、検索ハンドルから情報を取得する流れと似ていますが、異なるクラスがいくつか使用されます。

`multiplayer_session` オブジェクトでは、`multiplayer_session_role_types` クラスである `session_role_types` オブジェクトを参照することにより、ロールの種類の情報を取得できます。 このオブジェクトでは、必要なロールの種類の名前を使用して `role_types` マップをインデックス指定できます。

これにより、`multiplayer_role_type` オブジェクトが返されます。 `roles` マップをインデックス指定することによりロールを取得でき、`multiplayer_role_info` オブジェクトが返されます。

`multiplayer_role_info` オブジェクトには、`max_members_count`、`member_xbox_user_ids`、`members_count`、`target_count` など、ロールに関する情報が含まれています。

## <a name="change-mutable-role-settings"></a>変更可能なロールの設定を変更する

ロールの種類で一部のロール設定を変更できること (変更可能) が示されている場合、`multiplayer_role_type.set_roles()` メソッドを使用して変更可能な設定を変更できます。 セッション所有者に指定されているメンバーだけが、ロールの設定を変更できます。

## <a name="assign-a-role-to-a-member"></a>メンバーにロールを割り当てる

Xbox Live SDK では現在、メンバーは自分のロールのみを割り当てることができます。 `multiplayer_session` オブジェクトでは、`set_current_user_role_info(role_type, role_name)` メソッドを呼び出して現在のメンバーのロールの種類とロールを指定できます。

セッションをサービスに書き込もうとした時点でロールに既に空きがない場合は、MPSD によって書き込みが拒否されます。
