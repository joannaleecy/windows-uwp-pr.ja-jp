---
title: PermissionId 列挙
assetID: 3e7ee317-4946-1105-ecd7-1e26346deccb
permalink: en-us/docs/xboxlive/rest/privacy-enum-permissionid.html
author: KevinAsgari
description: " PermissionId 列挙"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f58c2d0f68e1f65820104928e45a09ccfdb259cb
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3927955"
---
# <a name="permissionid-enumeration"></a><span data-ttu-id="6c7b5-104">PermissionId 列挙</span><span class="sxs-lookup"><span data-stu-id="6c7b5-104">PermissionId Enumeration</span></span>
<span data-ttu-id="6c7b5-105">PermissionId 列挙をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-105">Details the PermissionId enumeration.</span></span>
<span data-ttu-id="6c7b5-106">アクセス許可の検証の Url とアクセス許可の Id を使用できます。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-106">Permission IDs can be used with the permission validation URLs:</span></span>

   * [<span data-ttu-id="6c7b5-107">取得する (アクセス許可が/users/{requestorId}/検証)</span><span class="sxs-lookup"><span data-stu-id="6c7b5-107">GET (/users/{requestorId}/permission/validate)</span></span>](../uri/privacy/uri-privacyusersrequestoridpermissionvalidateget.md)
   * [<span data-ttu-id="6c7b5-108">POST (アクセス許可が/users/{requestorId}/検証)</span><span class="sxs-lookup"><span data-stu-id="6c7b5-108">POST (/users/{requestorId}/permission/validate)</span></span>](../uri/privacy/uri-privacyusersrequestoridpermissionvalidatepost.md)

<span data-ttu-id="6c7b5-109">これらの Id には、ユーザーは、ターゲットまたは 1 つの特権アクターの 1 つのプライバシー設定の確認など、特定の設定に対して直接チェックが含まれます。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-109">These IDs include direct checks against a particular setting for a user, such as checking a single privacy setting of a target, or a single privilege actor.</span></span> <span data-ttu-id="6c7b5-110">さらに、Id を API アクセス許可を持つことができ、特定のユーザー操作の複数の設定に対してチェックを組み込むためのアクセス許可があります。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-110">In addition, there are permission IDs that can be used with the permission API and incorporate checks against multiple settings for specific user actions.</span></span>

<a id="ID4EIB"></a>


## <a name="permissions"></a><span data-ttu-id="6c7b5-111">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="6c7b5-111">Permissions</span></span>

<span data-ttu-id="6c7b5-112">これらは、特定の操作を実行できるかどうかを確認する、呼び出し元が使用できる値です。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-112">These are values that a caller can use to check whether a specific action can be performed.</span></span> <span data-ttu-id="6c7b5-113">上記の設定とは異なりはこれらサービスによって定義されたポリシーをカプセル化し、ポリシーが 1 つまたは複数の設定値を持つがユーザーによって定義された最上位に構築ほとんどの場合もに、ユーザーが直接変更されたことはできません。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-113">Unlike the settings above, these encapsulate policies defined by the service and cannot be directly changed by users, though in most cases, the policies build on top of one or more settings whose values are defined by users.</span></span> <span data-ttu-id="6c7b5-114">これらは、上記で定義した 1 つ以上の設定に対して通常複合チェックです。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-114">These are usually composite checks against more than one setting defined above.</span></span> <span data-ttu-id="6c7b5-115">例: <b>ViewProfile</b>アクセス許可では、ターゲットの<b>ShareProfile</b>プライバシー設定と、送信者の<b>AllowProfileViewing</b>特権をチェックします。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-115">Example: The <b>ViewProfile</b> permission does a check of the target's <b>ShareProfile</b> privacy setting and the requestor's <b>AllowProfileViewing</b> privilege.</span></span>

<span data-ttu-id="6c7b5-116">一般に、呼び出し元がプライバシー設定と権限を直接チェックではなく、オンにする必要がある操作のためのアクセス許可の ID を要求することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-116">In general, it's recommended that callers request a permission ID for actions that need to be checked, rather than directly checking privacy settings and privileges.</span></span> <span data-ttu-id="6c7b5-117">これにより、新しいチェックが組み込まれているように、サービスの間で一貫して変更するプライバシー ポリシーができます。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-117">This allows privacy policies to be changed consistently across the service as new checks are incorporated.</span></span>

| <span data-ttu-id="6c7b5-118">アクセス許可名</span><span class="sxs-lookup"><span data-stu-id="6c7b5-118">Permission Name</span></span>| <span data-ttu-id="6c7b5-119">説明</span><span class="sxs-lookup"><span data-stu-id="6c7b5-119">Description</span></span>|
| --- | --- |
| <span data-ttu-id="6c7b5-120">CommunicateUsingText</span><span class="sxs-lookup"><span data-stu-id="6c7b5-120">CommunicateUsingText</span></span>| <span data-ttu-id="6c7b5-121">ユーザーが対象ユーザーにテキスト コンテンツの付いたメッセージを送信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-121">Check whether or not the user can send a message with text content to the target user</span></span>|
| <span data-ttu-id="6c7b5-122">CommunicateUsingVideo</span><span class="sxs-lookup"><span data-stu-id="6c7b5-122">CommunicateUsingVideo</span></span>| <span data-ttu-id="6c7b5-123">ターゲット ユーザーとビデオを使用して、ユーザーが通信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-123">Check whether or not the user can communicate using video with the target user</span></span>|
| <span data-ttu-id="6c7b5-124">CommunicateUsingVoice</span><span class="sxs-lookup"><span data-stu-id="6c7b5-124">CommunicateUsingVoice</span></span>| <span data-ttu-id="6c7b5-125">ターゲット ユーザーと音声を使用して、ユーザーが通信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-125">Check whether or not the user can communicate using voice with the target user</span></span>|
| <span data-ttu-id="6c7b5-126">ViewTargetProfile</span><span class="sxs-lookup"><span data-stu-id="6c7b5-126">ViewTargetProfile</span></span>| <span data-ttu-id="6c7b5-127">ユーザーが対象ユーザーのプロファイルを表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-127">Check whether or not the user can view the profile of the target user</span></span>|
| <span data-ttu-id="6c7b5-128">ViewTargetGameHistory</span><span class="sxs-lookup"><span data-stu-id="6c7b5-128">ViewTargetGameHistory</span></span>| <span data-ttu-id="6c7b5-129">ユーザーが対象ユーザーのゲームの履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-129">Check whether or not the user can view the game history of the target user</span></span>|
| <span data-ttu-id="6c7b5-130">ViewTargetVideoHistory</span><span class="sxs-lookup"><span data-stu-id="6c7b5-130">ViewTargetVideoHistory</span></span>| <span data-ttu-id="6c7b5-131">対象ユーザーの詳細なビデオの視聴履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-131">Check whether or not the user can view the detailed video watching history of the target user</span></span>|
| <span data-ttu-id="6c7b5-132">ViewTargetMusicHistory</span><span class="sxs-lookup"><span data-stu-id="6c7b5-132">ViewTargetMusicHistory</span></span>| <span data-ttu-id="6c7b5-133">ユーザーが対象ユーザーの詳細な音楽リッスン履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-133">Check whether or not the user can view the detailed music listening history of the target user</span></span>|
| <span data-ttu-id="6c7b5-134">ViewTargetExerciseInfo</span><span class="sxs-lookup"><span data-stu-id="6c7b5-134">ViewTargetExerciseInfo</span></span>| <span data-ttu-id="6c7b5-135">対象ユーザーの演習情報に表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-135">Check whether or not the user can view the exercise info of the target user</span></span>|
| <span data-ttu-id="6c7b5-136">ViewTargetPresence</span><span class="sxs-lookup"><span data-stu-id="6c7b5-136">ViewTargetPresence</span></span>| <span data-ttu-id="6c7b5-137">ユーザーが対象ユーザーのオンライン状態を表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-137">Check whether or not the user can view the online status of the target user</span></span>|
| <span data-ttu-id="6c7b5-138">ViewTargetVideoStatus</span><span class="sxs-lookup"><span data-stu-id="6c7b5-138">ViewTargetVideoStatus</span></span>| <span data-ttu-id="6c7b5-139">ユーザーがターゲット ビデオ ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-139">Check whether or not the user can view the details of the targets video status (extended online presence)</span></span>|
| <span data-ttu-id="6c7b5-140">ViewTargetMusicStatus</span><span class="sxs-lookup"><span data-stu-id="6c7b5-140">ViewTargetMusicStatus</span></span>| <span data-ttu-id="6c7b5-141">ユーザーがターゲット音楽ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-141">Check whether or not the user can view the details of the targets music status (extended online presence)</span></span>|
| <span data-ttu-id="6c7b5-142">ViewTargetUserCreatedContent</span><span class="sxs-lookup"><span data-stu-id="6c7b5-142">ViewTargetUserCreatedContent</span></span>| <span data-ttu-id="6c7b5-143">ユーザーが他のユーザーのユーザーが作成したコンテンツを表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6c7b5-143">Check whether or not the user can view the user-created content of other users</span></span>|
