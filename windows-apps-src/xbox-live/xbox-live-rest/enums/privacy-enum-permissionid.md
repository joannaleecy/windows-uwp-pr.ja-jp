---
title: PermissionId 列挙型
assetID: 3e7ee317-4946-1105-ecd7-1e26346deccb
permalink: en-us/docs/xboxlive/rest/privacy-enum-permissionid.html
description: " PermissionId 列挙型"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: aff463e2268af972536984a00e29348bf0a6859e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594687"
---
# <a name="permissionid-enumeration"></a><span data-ttu-id="938cc-104">PermissionId 列挙型</span><span class="sxs-lookup"><span data-stu-id="938cc-104">PermissionId Enumeration</span></span>
<span data-ttu-id="938cc-105">PermissionId 列挙体をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="938cc-105">Details the PermissionId enumeration.</span></span>
<span data-ttu-id="938cc-106">アクセス許可の検証 Url でアクセス許可 Id を使用できます。</span><span class="sxs-lookup"><span data-stu-id="938cc-106">Permission IDs can be used with the permission validation URLs:</span></span>

   * [<span data-ttu-id="938cc-107">GET (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="938cc-107">GET (/users/{requestorId}/permission/validate)</span></span>](../uri/privacy/uri-privacyusersrequestoridpermissionvalidateget.md)
   * [<span data-ttu-id="938cc-108">POST (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="938cc-108">POST (/users/{requestorId}/permission/validate)</span></span>](../uri/privacy/uri-privacyusersrequestoridpermissionvalidatepost.md)

<span data-ttu-id="938cc-109">これらの Id には、ターゲット、または 1 つの特権のあるアクターの 1 つのプライバシー設定の確認など、ユーザーに対して特定の設定に対して直接チェックが含まれます。</span><span class="sxs-lookup"><span data-stu-id="938cc-109">These IDs include direct checks against a particular setting for a user, such as checking a single privacy setting of a target, or a single privilege actor.</span></span> <span data-ttu-id="938cc-110">さらに、API アクセス許可で使用できる、特定のユーザー操作に対して複数の設定に対してチェックを組み込む Id アクセス許可があります。</span><span class="sxs-lookup"><span data-stu-id="938cc-110">In addition, there are permission IDs that can be used with the permission API and incorporate checks against multiple settings for specific user actions.</span></span>

<a id="ID4EIB"></a>


## <a name="permissions"></a><span data-ttu-id="938cc-111">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="938cc-111">Permissions</span></span>

<span data-ttu-id="938cc-112">これらは、特定のアクションを実行できるかどうかを確認する呼び出し元を使用する値です。</span><span class="sxs-lookup"><span data-stu-id="938cc-112">These are values that a caller can use to check whether a specific action can be performed.</span></span> <span data-ttu-id="938cc-113">上記の設定とは異なりはこれらサービスによって定義されたポリシーをカプセル化し、直接では変更できません、ユーザーが、ほとんどの場合、ポリシーをユーザーが値を持つが定義されている 1 つ以上の設定の上に構築します。</span><span class="sxs-lookup"><span data-stu-id="938cc-113">Unlike the settings above, these encapsulate policies defined by the service and cannot be directly changed by users, though in most cases, the policies build on top of one or more settings whose values are defined by users.</span></span> <span data-ttu-id="938cc-114">これらは、上記で定義された 1 つ以上の設定に対して、通常は複合チェックです。</span><span class="sxs-lookup"><span data-stu-id="938cc-114">These are usually composite checks against more than one setting defined above.</span></span> <span data-ttu-id="938cc-115">以下に例を示します。<b>ViewProfile</b>アクセス許可には、ターゲットのチェックを<b>ShareProfile</b>プライバシー設定と、要求元の<b>AllowProfileViewing</b>特権。</span><span class="sxs-lookup"><span data-stu-id="938cc-115">Example: The <b>ViewProfile</b> permission does a check of the target's <b>ShareProfile</b> privacy setting and the requestor's <b>AllowProfileViewing</b> privilege.</span></span>

<span data-ttu-id="938cc-116">一般に、呼び出し元が直接プライバシーの設定および権限のチェックではなく、確認する必要のあるアクションのアクセス許可 ID を要求することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="938cc-116">In general, it's recommended that callers request a permission ID for actions that need to be checked, rather than directly checking privacy settings and privileges.</span></span> <span data-ttu-id="938cc-117">これにより、新しいチェックが組み込まれるように、サービス間で一貫して変更するプライバシー ポリシーができます。</span><span class="sxs-lookup"><span data-stu-id="938cc-117">This allows privacy policies to be changed consistently across the service as new checks are incorporated.</span></span>

| <span data-ttu-id="938cc-118">アクセス許可の名前</span><span class="sxs-lookup"><span data-stu-id="938cc-118">Permission Name</span></span>| <span data-ttu-id="938cc-119">説明</span><span class="sxs-lookup"><span data-stu-id="938cc-119">Description</span></span>|
| --- | --- |
| <span data-ttu-id="938cc-120">CommunicateUsingText</span><span class="sxs-lookup"><span data-stu-id="938cc-120">CommunicateUsingText</span></span>| <span data-ttu-id="938cc-121">対象ユーザーに、ユーザーがテキスト コンテンツを含むメッセージを送信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-121">Check whether or not the user can send a message with text content to the target user</span></span>|
| <span data-ttu-id="938cc-122">CommunicateUsingVideo</span><span class="sxs-lookup"><span data-stu-id="938cc-122">CommunicateUsingVideo</span></span>| <span data-ttu-id="938cc-123">対象ユーザーとビデオを使用して、ユーザーが通信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-123">Check whether or not the user can communicate using video with the target user</span></span>|
| <span data-ttu-id="938cc-124">CommunicateUsingVoice</span><span class="sxs-lookup"><span data-stu-id="938cc-124">CommunicateUsingVoice</span></span>| <span data-ttu-id="938cc-125">対象ユーザーに音声を使用して、ユーザーが通信できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-125">Check whether or not the user can communicate using voice with the target user</span></span>|
| <span data-ttu-id="938cc-126">ViewTargetProfile</span><span class="sxs-lookup"><span data-stu-id="938cc-126">ViewTargetProfile</span></span>| <span data-ttu-id="938cc-127">ターゲット ユーザーのプロファイルを表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-127">Check whether or not the user can view the profile of the target user</span></span>|
| <span data-ttu-id="938cc-128">ViewTargetGameHistory</span><span class="sxs-lookup"><span data-stu-id="938cc-128">ViewTargetGameHistory</span></span>| <span data-ttu-id="938cc-129">ユーザーが対象ユーザーのゲーム履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-129">Check whether or not the user can view the game history of the target user</span></span>|
| <span data-ttu-id="938cc-130">ViewTargetVideoHistory</span><span class="sxs-lookup"><span data-stu-id="938cc-130">ViewTargetVideoHistory</span></span>| <span data-ttu-id="938cc-131">ターゲット ユーザーの詳細なビデオ監視履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-131">Check whether or not the user can view the detailed video watching history of the target user</span></span>|
| <span data-ttu-id="938cc-132">ViewTargetMusicHistory</span><span class="sxs-lookup"><span data-stu-id="938cc-132">ViewTargetMusicHistory</span></span>| <span data-ttu-id="938cc-133">ユーザーが対象ユーザーの詳細な音楽リッスンしている履歴を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-133">Check whether or not the user can view the detailed music listening history of the target user</span></span>|
| <span data-ttu-id="938cc-134">ViewTargetExerciseInfo</span><span class="sxs-lookup"><span data-stu-id="938cc-134">ViewTargetExerciseInfo</span></span>| <span data-ttu-id="938cc-135">ユーザーが対象ユーザーの演習の情報を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-135">Check whether or not the user can view the exercise info of the target user</span></span>|
| <span data-ttu-id="938cc-136">ViewTargetPresence</span><span class="sxs-lookup"><span data-stu-id="938cc-136">ViewTargetPresence</span></span>| <span data-ttu-id="938cc-137">ユーザーがターゲット ユーザーのオンライン ステータスを確認できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-137">Check whether or not the user can view the online status of the target user</span></span>|
| <span data-ttu-id="938cc-138">ViewTargetVideoStatus</span><span class="sxs-lookup"><span data-stu-id="938cc-138">ViewTargetVideoStatus</span></span>| <span data-ttu-id="938cc-139">ユーザーがターゲット ビデオ状態 (オンライン プレゼンスの拡張) の詳細を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-139">Check whether or not the user can view the details of the targets video status (extended online presence)</span></span>|
| <span data-ttu-id="938cc-140">ViewTargetMusicStatus</span><span class="sxs-lookup"><span data-stu-id="938cc-140">ViewTargetMusicStatus</span></span>| <span data-ttu-id="938cc-141">ユーザーがターゲット音楽状態 (オンライン プレゼンスの拡張) の詳細を表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-141">Check whether or not the user can view the details of the targets music status (extended online presence)</span></span>|
| <span data-ttu-id="938cc-142">ViewTargetUserCreatedContent</span><span class="sxs-lookup"><span data-stu-id="938cc-142">ViewTargetUserCreatedContent</span></span>| <span data-ttu-id="938cc-143">ユーザーが他のユーザーのユーザーが作成したコンテンツを表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="938cc-143">Check whether or not the user can view the user-created content of other users</span></span>|
