---
title: PermissionId 列挙型
assetID: 3e7ee317-4946-1105-ecd7-1e26346deccb
permalink: en-us/docs/xboxlive/rest/privacy-enum-permissionid.html
author: KevinAsgari
description: " PermissionId 列挙型"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f58c2d0f68e1f65820104928e45a09ccfdb259cb
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4092191"
---
# <a name="permissionid-enumeration"></a><span data-ttu-id="8adb1-104">PermissionId 列挙型</span><span class="sxs-lookup"><span data-stu-id="8adb1-104">PermissionId Enumeration</span></span>
<span data-ttu-id="8adb1-105">PermissionId 列挙をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-105">Details the PermissionId enumeration.</span></span>
<span data-ttu-id="8adb1-106">アクセス許可の検証の Url とアクセス許可の Id を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8adb1-106">Permission IDs can be used with the permission validation URLs:</span></span>

   * [<span data-ttu-id="8adb1-107">GET (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="8adb1-107">GET (/users/{requestorId}/permission/validate)</span></span>](../uri/privacy/uri-privacyusersrequestoridpermissionvalidateget.md)
   * [<span data-ttu-id="8adb1-108">POST (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="8adb1-108">POST (/users/{requestorId}/permission/validate)</span></span>](../uri/privacy/uri-privacyusersrequestoridpermissionvalidatepost.md)

<span data-ttu-id="8adb1-109">これらの Id には、ユーザーは、ターゲットまたは 1 つの特権アクターの 1 つのプライバシー設定の確認など、特定の設定に対して直接チェックが含まれます。</span><span class="sxs-lookup"><span data-stu-id="8adb1-109">These IDs include direct checks against a particular setting for a user, such as checking a single privacy setting of a target, or a single privilege actor.</span></span> <span data-ttu-id="8adb1-110">さらに、Id を API アクセス許可を持つことができ、特定のユーザー操作の複数の設定に対してチェックを組み込むためのアクセス許可があります。</span><span class="sxs-lookup"><span data-stu-id="8adb1-110">In addition, there are permission IDs that can be used with the permission API and incorporate checks against multiple settings for specific user actions.</span></span>

<a id="ID4EIB"></a>


## <a name="permissions"></a><span data-ttu-id="8adb1-111">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="8adb1-111">Permissions</span></span>

<span data-ttu-id="8adb1-112">これらは、特定の操作を実行できるかどうかを確認する、呼び出し元が使用できる値です。</span><span class="sxs-lookup"><span data-stu-id="8adb1-112">These are values that a caller can use to check whether a specific action can be performed.</span></span> <span data-ttu-id="8adb1-113">上記の設定とは異なりはこれらサービスによって定義されたポリシーをカプセル化し、ポリシーが 1 つまたは複数の設定値を持つがユーザーによって定義された最上位に構築ほとんどの場合もに、ユーザーが直接変更されたことはできません。</span><span class="sxs-lookup"><span data-stu-id="8adb1-113">Unlike the settings above, these encapsulate policies defined by the service and cannot be directly changed by users, though in most cases, the policies build on top of one or more settings whose values are defined by users.</span></span> <span data-ttu-id="8adb1-114">これらは、上記で定義した 1 つ以上の設定に対して通常複合チェックです。</span><span class="sxs-lookup"><span data-stu-id="8adb1-114">These are usually composite checks against more than one setting defined above.</span></span> <span data-ttu-id="8adb1-115">例: <b>ViewProfile</b>アクセス許可では、ターゲットの<b>ShareProfile</b>プライバシー設定と、送信者の<b>AllowProfileViewing</b>特権をチェックします。</span><span class="sxs-lookup"><span data-stu-id="8adb1-115">Example: The <b>ViewProfile</b> permission does a check of the target's <b>ShareProfile</b> privacy setting and the requestor's <b>AllowProfileViewing</b> privilege.</span></span>

<span data-ttu-id="8adb1-116">一般に、呼び出し元がプライバシー設定と権限を直接チェックではなく、オンにする必要がある操作のためのアクセス許可の ID を要求することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8adb1-116">In general, it's recommended that callers request a permission ID for actions that need to be checked, rather than directly checking privacy settings and privileges.</span></span> <span data-ttu-id="8adb1-117">これにより、新しいチェックを組み込むように、サービスの間で一貫して変更するプライバシー ポリシーができます。</span><span class="sxs-lookup"><span data-stu-id="8adb1-117">This allows privacy policies to be changed consistently across the service as new checks are incorporated.</span></span>

| <span data-ttu-id="8adb1-118">アクセス許可名</span><span class="sxs-lookup"><span data-stu-id="8adb1-118">Permission Name</span></span>| <span data-ttu-id="8adb1-119">説明</span><span class="sxs-lookup"><span data-stu-id="8adb1-119">Description</span></span>|
| --- | --- |
| <span data-ttu-id="8adb1-120">CommunicateUsingText</span><span class="sxs-lookup"><span data-stu-id="8adb1-120">CommunicateUsingText</span></span>| <span data-ttu-id="8adb1-121">ユーザーが対象ユーザーにテキスト コンテンツの付いたメッセージを送信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-121">Check whether or not the user can send a message with text content to the target user</span></span>|
| <span data-ttu-id="8adb1-122">CommunicateUsingVideo</span><span class="sxs-lookup"><span data-stu-id="8adb1-122">CommunicateUsingVideo</span></span>| <span data-ttu-id="8adb1-123">対象ユーザーにビデオを使用して、ユーザーが通信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-123">Check whether or not the user can communicate using video with the target user</span></span>|
| <span data-ttu-id="8adb1-124">CommunicateUsingVoice</span><span class="sxs-lookup"><span data-stu-id="8adb1-124">CommunicateUsingVoice</span></span>| <span data-ttu-id="8adb1-125">ターゲット ユーザーと音声を使用して、ユーザーが通信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-125">Check whether or not the user can communicate using voice with the target user</span></span>|
| <span data-ttu-id="8adb1-126">ViewTargetProfile</span><span class="sxs-lookup"><span data-stu-id="8adb1-126">ViewTargetProfile</span></span>| <span data-ttu-id="8adb1-127">ユーザーが対象ユーザーのプロファイルを表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-127">Check whether or not the user can view the profile of the target user</span></span>|
| <span data-ttu-id="8adb1-128">ViewTargetGameHistory</span><span class="sxs-lookup"><span data-stu-id="8adb1-128">ViewTargetGameHistory</span></span>| <span data-ttu-id="8adb1-129">ユーザーが対象ユーザーのゲームの履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-129">Check whether or not the user can view the game history of the target user</span></span>|
| <span data-ttu-id="8adb1-130">ViewTargetVideoHistory</span><span class="sxs-lookup"><span data-stu-id="8adb1-130">ViewTargetVideoHistory</span></span>| <span data-ttu-id="8adb1-131">ユーザーが対象ユーザーの詳細なビデオの視聴履歴を表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-131">Check whether or not the user can view the detailed video watching history of the target user</span></span>|
| <span data-ttu-id="8adb1-132">ViewTargetMusicHistory</span><span class="sxs-lookup"><span data-stu-id="8adb1-132">ViewTargetMusicHistory</span></span>| <span data-ttu-id="8adb1-133">ユーザーが対象ユーザーの詳細な音楽聞き取りの履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-133">Check whether or not the user can view the detailed music listening history of the target user</span></span>|
| <span data-ttu-id="8adb1-134">ViewTargetExerciseInfo</span><span class="sxs-lookup"><span data-stu-id="8adb1-134">ViewTargetExerciseInfo</span></span>| <span data-ttu-id="8adb1-135">ユーザーが対象ユーザーの作業では情報を表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-135">Check whether or not the user can view the exercise info of the target user</span></span>|
| <span data-ttu-id="8adb1-136">ViewTargetPresence</span><span class="sxs-lookup"><span data-stu-id="8adb1-136">ViewTargetPresence</span></span>| <span data-ttu-id="8adb1-137">ユーザーが対象ユーザーのオンライン状態を表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-137">Check whether or not the user can view the online status of the target user</span></span>|
| <span data-ttu-id="8adb1-138">ViewTargetVideoStatus</span><span class="sxs-lookup"><span data-stu-id="8adb1-138">ViewTargetVideoStatus</span></span>| <span data-ttu-id="8adb1-139">ユーザーがターゲット ビデオ ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-139">Check whether or not the user can view the details of the targets video status (extended online presence)</span></span>|
| <span data-ttu-id="8adb1-140">ViewTargetMusicStatus</span><span class="sxs-lookup"><span data-stu-id="8adb1-140">ViewTargetMusicStatus</span></span>| <span data-ttu-id="8adb1-141">ユーザーがターゲット音楽ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-141">Check whether or not the user can view the details of the targets music status (extended online presence)</span></span>|
| <span data-ttu-id="8adb1-142">ViewTargetUserCreatedContent</span><span class="sxs-lookup"><span data-stu-id="8adb1-142">ViewTargetUserCreatedContent</span></span>| <span data-ttu-id="8adb1-143">ユーザーが他のユーザーのユーザーが作成したコンテンツを表示するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8adb1-143">Check whether or not the user can view the user-created content of other users</span></span>|
