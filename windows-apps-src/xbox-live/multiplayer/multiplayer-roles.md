---
title: "マルチプレイヤーのロール"
author: KevinAsgari
description: "ロールを使用して Xbox Live マルチプレイヤーでのプレイヤー ロールを定義する方法について説明します。"
ms.author: kevinasg
ms.date: 06-29-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, ロール"
ms.openlocfilehash: 0d7856fa64e57e91172127064a6937badce8a055
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="roles"></a><span data-ttu-id="7c920-104">ロール</span><span class="sxs-lookup"><span data-stu-id="7c920-104">Roles</span></span>

<span data-ttu-id="7c920-105">ゲーム セッションによっては、特定のメンバーに支援、看護、突撃などの特定のゲームプレイ ロールを指定したり、特定のゲームプレイ ロールを持つプレイヤーのためにゲーム スロットを予約する必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-105">For some game sessions, you may want to specify that certain members have certain gameplay roles, such as support, medic, assault, etc. You may also wat to reserve game slots for players that will fill a specific gameplay role.</span></span> <span data-ttu-id="7c920-106">Xbox Live のロール機能を使用することで、サービスはプレイヤーに対するゲームプレイ ロールの割り当てを追跡し、特定のゲームプレイ ロールを選択できるプレイヤーの最大数を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="7c920-106">By using the Xbox Live roles feature, the service can track which players are assigned which gameplay roles, and enforce a maximum number of players that can select a specific gameplay role.</span></span>

<span data-ttu-id="7c920-107">ロールの最も一般的な用途は、そのゲーム セッションに対するゲーム固有のロールを決定することです。</span><span class="sxs-lookup"><span data-stu-id="7c920-107">The most common use of roles is to determine game specific roles for that game session.</span></span> <span data-ttu-id="7c920-108">たとえば、1 ～ 2 人の支援クラス、1 人以上の重戦車クラス、5 人以下の突撃クラスを必要とするゲーム モードを設定できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-108">For example, you can have a game mode that requires between 1 and 2 support classes, at least 1 tank/heavy class, and no more than 5 assault classes.</span></span>

<span data-ttu-id="7c920-109">厳密に 4 人のゲーム プレイヤー、最大 8 人の観戦者、1 人のアナウンサーで構成されるゲーム シナリオを指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="7c920-109">In another possible scenario, you may want to specify that a game session can have exactly 4 game players, up to 8 spectators, and 1 announcer.</span></span>

<span data-ttu-id="7c920-110">また、ロールを使用してフレンド用のスロットを予約し、残りのスロットはセッション参照などの他の手段で埋めることもできます。</span><span class="sxs-lookup"><span data-stu-id="7c920-110">You can also use roles to reserve slots for friends while filling the remaining slots through other means, such as session browse.</span></span>

## <a name="role-types"></a><span data-ttu-id="7c920-111">ロールの種類</span><span class="sxs-lookup"><span data-stu-id="7c920-111">Role types</span></span>

<span data-ttu-id="7c920-112">ロールの種類は、ロール定義のグループを表します。</span><span class="sxs-lookup"><span data-stu-id="7c920-112">A role type represents a group of role definitions.</span></span> <span data-ttu-id="7c920-113">すべてのロールは、ロールの種類の一部として定義されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-113">Every role must be defined as part of a role type.</span></span> <span data-ttu-id="7c920-114">ロールの種類は通常、マルチプレイヤー セッション ドキュメントで定義されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-114">Role types are defined in the multiplayer session document.</span></span>

<span data-ttu-id="7c920-115">特定のロールの種類から 1 人のメンバーに割り当てることができるロールは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="7c920-115">A member can only be assigned one role from a given role type.</span></span> <span data-ttu-id="7c920-116">たとえば、"クラス" というロールの種類にヒーラー、タンク、ダメージが含まれる場合、1 人のメンバーにはこれらのロールのいずれか 1 つだけを割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="7c920-116">For example, if a "class" role type includes healers, tanks, and damage, then a member can only be assigned to one of those roles.</span></span>

<span data-ttu-id="7c920-117">複数のロールの種類を定義でき、1 人のメンバーには各ロールの種類から 1 つのロールを割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="7c920-117">You can define multiple role types, and a member can be assigned one role from each role type.</span></span> <span data-ttu-id="7c920-118">前のシナリオで、スクワッド リーダー ロールが別のロールの種類で定義されている場合は、ヒーラー ロールを選択したメンバーに、スクワッド リーダー ロールも割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="7c920-118">In the previous scenario, a member may have chosen the healer role, but may also be assigned a squad leader role, if the squad leader role is defined in a separate role type.</span></span>

> <span data-ttu-id="7c920-119">**重要:** 現在の Xbox Live SDK では、1 人のメンバーに対しては 1 つのロールの種類と 1 つのロールだけがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="7c920-119">**Important:** The Xbox Live SDK currently only supports a single role type and a single role per member.</span></span>

## <a name="role-type-properties"></a><span data-ttu-id="7c920-120">ロールの種類のプロパティ</span><span class="sxs-lookup"><span data-stu-id="7c920-120">Role type properties</span></span>

<span data-ttu-id="7c920-121">ロールの種類を定義するときは、ロールの種類に対して次の情報を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-121">When you define a role type, you must specify the following information for role types:</span></span>

* <span data-ttu-id="7c920-122">ロールの種類の名前。</span><span class="sxs-lookup"><span data-stu-id="7c920-122">The name of the role type.</span></span> <span data-ttu-id="7c920-123">名前は 100 文字以下の小文字の英数字にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-123">The name must be lowercase and alpha-numeric, and no more than 100 characters long.</span></span>
* <span data-ttu-id="7c920-124">ロールの種類で定義されているロールが所有者によって管理されているかどうか。</span><span class="sxs-lookup"><span data-stu-id="7c920-124">If the roles defined in the role type are owner managed or not.</span></span>
* <span data-ttu-id="7c920-125">ロールの種類で定義されているロールのプロパティを、セッションの存在期間中に変更できるかどうか。</span><span class="sxs-lookup"><span data-stu-id="7c920-125">If the properties of the roles defined in the role type can be changed during the life of the session.</span></span>
* <span data-ttu-id="7c920-126">ロールの種類に含まれるロールの定義。</span><span class="sxs-lookup"><span data-stu-id="7c920-126">The role definitions that are include in the role type.</span></span>

<span data-ttu-id="7c920-127">ロールの種類が所有者によって管理されている場合は、セッションの所有者であるメンバーだけがその種類のロールをメンバーに割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="7c920-127">If a role type is owner managed, that means that only members that are owners of the session can assign roles of that type to members.</span></span> <span data-ttu-id="7c920-128">ロールの種類が所有者によって管理されていない場合は、メンバーが自分自身にロールを割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="7c920-128">If the role type is not owner managed, then members can assign roles to themselves.</span></span>

<span data-ttu-id="7c920-129">ロールの種類が所有者による管理であることを指定できるのは、セッションで "hasOwners" 機能が設定されている場合のみです。</span><span class="sxs-lookup"><span data-stu-id="7c920-129">You can only specify that a role type is owner managed on sessions that have the "hasOwners" capability set.</span></span>

> <span data-ttu-id="7c920-130">現在、Xbox Live SDK では所有者による他のメンバーへのロールの割り当てがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="7c920-130">The Xbox Live SDK does not currently support owners assigning roles to other members.</span></span>

## <a name="role-properties"></a><span data-ttu-id="7c920-131">ロールのプロパティ</span><span class="sxs-lookup"><span data-stu-id="7c920-131">Role properties</span></span>

<span data-ttu-id="7c920-132">ロールを定義するときは、各ロールに対して次の情報を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-132">When you define a role, you must specify the following information for each role:</span></span>

* <span data-ttu-id="7c920-133">ロールの名前。</span><span class="sxs-lookup"><span data-stu-id="7c920-133">The name of the role.</span></span> <span data-ttu-id="7c920-134">名前は 100 文字以下の小文字の英数字にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-134">The name must be lowercase and alpha-numeric, and no more than 100 characters long.</span></span>
* <span data-ttu-id="7c920-135">ロールに指定できるメンバーの最大数。</span><span class="sxs-lookup"><span data-stu-id="7c920-135">The maximum number of members that are allowed to fill the role.</span></span> <span data-ttu-id="7c920-136">ゼロより大きい値にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-136">Must be greater than zero.</span></span>
* <span data-ttu-id="7c920-137">ロールに指定する必要があるメンバーの目標数。</span><span class="sxs-lookup"><span data-stu-id="7c920-137">The target number of members that should fill the role.</span></span> <span data-ttu-id="7c920-138">目標数は 0 より大きく、ロールに指定できるメンバーの最大数以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c920-138">The target must be greater than zero, and less than or equal to the maximum number of members allowed to fill the role.</span></span>

<span data-ttu-id="7c920-139">セッション メンバーにロールが割り当てられると、その情報がマルチプレイヤー セッション ドキュメントのメンバー ロールに記録されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-139">When a session member is assigned a role, that information is recorded in the member roles in the multiplayer session document.</span></span>

<span data-ttu-id="7c920-140">ロールに割り当てることができるメンバーの最大数はサービスによって強制されますが、目標数は強制されません。</span><span class="sxs-lookup"><span data-stu-id="7c920-140">The service enforces the maximum number of members that can be assigned to a role, but does not enforce the target number.</span></span>

## <a name="create-roles"></a><span data-ttu-id="7c920-141">ロールを作成する</span><span class="sxs-lookup"><span data-stu-id="7c920-141">Create roles</span></span>

<span data-ttu-id="7c920-142">ロールとロールの種類は通常、[セッション テンプレート](service-configuration/session-templates.md)で定義されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-142">Roles and role types are typically defined in the [session template](service-configuration/session-templates.md).</span></span> <span data-ttu-id="7c920-143">サービスはセッション作成の間にロールおよびロールの種類の定義をサポートしますが、Xbox Live SDK はサポートしません。</span><span class="sxs-lookup"><span data-stu-id="7c920-143">The service supports role and role type definition during session creation, however the Xbox Live SDK does not.</span></span>

### <a name="define-role-types-and-roles-in-a-session-template"></a><span data-ttu-id="7c920-144">セッション テンプレートでロールの種類とロールを定義する</span><span class="sxs-lookup"><span data-stu-id="7c920-144">Define role types and roles in a session template</span></span>

<span data-ttu-id="7c920-145">Xbox Live の構成時にセッション テンプレートを作成するときに、ロールの種類とロールを定義できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-145">You can define role types and roles when you create a session template during the Xbox Live configuration.</span></span>

<span data-ttu-id="7c920-146">ロールの種類およびロールの情報は、次の形式で、セッション テンプレートの基本レベルの "roleTypes" 要素として指定されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-146">The role type and role information is specified as a base level "roleTypes" element in the session template, in the following format:</span></span>

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

## <a name="retrieve-role-information-for-a-multiplayer-session"></a><span data-ttu-id="7c920-147">マルチプレイヤー セッションのロール情報を取得する</span><span class="sxs-lookup"><span data-stu-id="7c920-147">Retrieve role information for a multiplayer session</span></span>

<span data-ttu-id="7c920-148">マルチプレイヤー セッションまたはマルチプレイヤー検索ハンドルから、ロールの種類、ロール、各ロールに割り当てられているメンバーの数に関する情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-148">You can get the information about the role types, roles, and how many members are assigned to each role from either a multiplayer session, or from a multiplayer search handle.</span></span>

<span data-ttu-id="7c920-149">Xbox Live SDK では、ロールの種類とロールに関する情報はマップ構造内に格納されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-149">In the Xbox Live SDK, information about the role types and roles is stored inside a map structure.</span></span> <span data-ttu-id="7c920-150">C++ API では `unordered_map` クラスが使用され、WinRT API では `IMapView` クラスが使用されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-150">The C++ APIs use the `unordered_map` class and the WinRT APIs use the `IMapView` class.</span></span>

### <a name="get-the-role-information-from-a-search-handle"></a><span data-ttu-id="7c920-151">検索ハンドルからロールの情報を取得する</span><span class="sxs-lookup"><span data-stu-id="7c920-151">Get the role information from a search handle</span></span>

<span data-ttu-id="7c920-152">検索要求から返される `multiplayer_search_handle_details` オブジェクトでは、必要なロールの種類の名前を使用して `role_types` マップをインデックス指定することにより、ロールの種類の情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-152">In the `multiplayer_search_handle_details` object returned from a search request, you can get the role type information by indexing the `role_types` map with the name of the role type you're interested in.</span></span>

<span data-ttu-id="7c920-153">これにより、`multiplayer_role_type` オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-153">This returns a `multiplayer_role_type` object.</span></span> <span data-ttu-id="7c920-154">`roles` マップをインデックス指定することによりロールを取得でき、`multiplayer_role_info` オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-154">You can get the roles by indexing the `roles` map, which returns a `multiplayer_role_info` object.</span></span>

<span data-ttu-id="7c920-155">`multiplayer_role_info` オブジェクトには、`max_members_count`、`member_xbox_user_ids`、`members_count`、`target_count` など、ロールに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7c920-155">The `multiplayer_role_info` object contains information about the role, including `max_members_count`, `member_xbox_user_ids`, `members_count`, and `target_count`.</span></span>

### <a name="get-the-role-information-from-a-search-handle"></a><span data-ttu-id="7c920-156">検索ハンドルからロールの情報を取得する</span><span class="sxs-lookup"><span data-stu-id="7c920-156">Get the role information from a search handle</span></span>

<span data-ttu-id="7c920-157">セッションからロールの情報を取得する流れは、検索ハンドルから情報を取得する流れと似ていますが、異なるクラスがいくつか使用されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-157">The flow for getting role information from a session is similar to the flow for getting information from a search handle, but some different classes are used.</span></span>

<span data-ttu-id="7c920-158">`multiplayer_session` オブジェクトでは、`multiplayer_session_role_types` クラスである `session_role_types` オブジェクトを参照することにより、ロールの種類の情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-158">In the `multiplayer_session` object, you can get the role type information by referencing the `session_role_types` object, which is a `multiplayer_session_role_types` class.</span></span> <span data-ttu-id="7c920-159">このオブジェクトでは、必要なロールの種類の名前を使用して `role_types` マップをインデックス指定できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-159">In this object, you can index the `role_types` map with the name of the role type you're interested in.</span></span>

<span data-ttu-id="7c920-160">これにより、`multiplayer_role_type` オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-160">This returns a `multiplayer_role_type` object.</span></span> <span data-ttu-id="7c920-161">`roles` マップをインデックス指定することによりロールを取得でき、`multiplayer_role_info` オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-161">You can get the roles by indexing the `roles` map, which returns a `multiplayer_role_info` object.</span></span>

<span data-ttu-id="7c920-162">`multiplayer_role_info` オブジェクトには、`max_members_count`、`member_xbox_user_ids`、`members_count`、`target_count` など、ロールに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7c920-162">The `multiplayer_role_info` object contains information about the role, including `max_members_count`, `member_xbox_user_ids`, `members_count`, and `target_count`.</span></span>

## <a name="change-mutable-role-settings"></a><span data-ttu-id="7c920-163">変更可能なロールの設定を変更する</span><span class="sxs-lookup"><span data-stu-id="7c920-163">Change mutable role settings</span></span>

<span data-ttu-id="7c920-164">ロールの種類で一部のロール設定を変更できること (変更可能) が示されている場合、`multiplayer_role_type.set_roles()` メソッドを使用して変更可能な設定を変更できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-164">If a role type indicates that some role settings can be changed (mutable), you can use the `multiplayer_role_type.set_roles()` method to modify the mutable settings.</span></span> <span data-ttu-id="7c920-165">セッション所有者に指定されているメンバーだけが、ロールの設定を変更できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-165">Only members that are marked as session owners can change role settings.</span></span>

## <a name="assign-a-role-to-a-member"></a><span data-ttu-id="7c920-166">メンバーにロールを割り当てる</span><span class="sxs-lookup"><span data-stu-id="7c920-166">Assign a role to a member</span></span>

<span data-ttu-id="7c920-167">Xbox Live SDK では現在、メンバーは自分のロールのみを割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="7c920-167">Currently, only a member can assign their own role in the Xbox Live SDK.</span></span> <span data-ttu-id="7c920-168">`multiplayer_session` オブジェクトでは、`set_current_user_role_info(role_type, role_name)` メソッドを呼び出して現在のメンバーのロールの種類とロールを指定できます。</span><span class="sxs-lookup"><span data-stu-id="7c920-168">In the `multiplayer_session` object, you can call the `set_current_user_role_info(role_type, role_name)` method to specify the role type and role for the current member.</span></span>

<span data-ttu-id="7c920-169">セッションをサービスに書き込もうとした時点でロールに既に空きがない場合は、MPSD によって書き込みが拒否されます。</span><span class="sxs-lookup"><span data-stu-id="7c920-169">If the role is already full when you try to write the session to the service, MPSD will reject the write.</span></span>
