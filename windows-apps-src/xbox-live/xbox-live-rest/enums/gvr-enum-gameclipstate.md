---
title: GameClipState 列挙型
assetID: 97fe5c1e-f7b5-537e-69eb-8284b69cd3e1
permalink: en-us/docs/xboxlive/rest/gvr-enum-gameclipstate.html
author: KevinAsgari
description: " GameClipState 列挙型"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9ce2ec90377dcd78797fa5708577f24028c3ccf2
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6164054"
---
# <a name="gameclipstate-enumeration"></a><span data-ttu-id="eaee4-104">GameClipState 列挙型</span><span class="sxs-lookup"><span data-stu-id="eaee4-104">GameClipState Enumeration</span></span>
<span data-ttu-id="eaee4-105">GameClipState 列挙型をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="eaee4-105">Details the GameClipState enumeration.</span></span> 
<a id="ID4ET"></a>

 
## <a name="gameclipstate"></a><span data-ttu-id="eaee4-106">GameClipState</span><span class="sxs-lookup"><span data-stu-id="eaee4-106">GameClipState</span></span>
 
| <b><span data-ttu-id="eaee4-107">列挙子</span><span class="sxs-lookup"><span data-stu-id="eaee4-107">Enumerator</span></span></b>| <b><span data-ttu-id="eaee4-108">説明</span><span class="sxs-lookup"><span data-stu-id="eaee4-108">Description</span></span></b>| 
| --- | --- | 
| <span data-ttu-id="eaee4-109">None</span><span class="sxs-lookup"><span data-stu-id="eaee4-109">None</span></span> | <span data-ttu-id="eaee4-110">ゲーム クリップ サービスの状態が、不明なまたは設定されていません。</span><span class="sxs-lookup"><span data-stu-id="eaee4-110">Game clip service state is unknown or not set.</span></span>| 
| <span data-ttu-id="eaee4-111">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="eaee4-111">PendingUpload</span></span> | <span data-ttu-id="eaee4-112">ゲーム クリップ サービスは、資産のアップロードを待機しています。</span><span class="sxs-lookup"><span data-stu-id="eaee4-112">Game clip service is waiting for the asset upload.</span></span>| 
| <span data-ttu-id="eaee4-113">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="eaee4-113">PendingDelete</span></span> | <span data-ttu-id="eaee4-114">ゲーム クリップは、削除、キューにです。</span><span class="sxs-lookup"><span data-stu-id="eaee4-114">Game clip is in the queue for deletion.</span></span> <span data-ttu-id="eaee4-115">(実質的に「は」)。</span><span class="sxs-lookup"><span data-stu-id="eaee4-115">(Effectively means it is "deleted").</span></span>| 
| <span data-ttu-id="eaee4-116">処理済み</span><span class="sxs-lookup"><span data-stu-id="eaee4-116">Processed</span></span> | <span data-ttu-id="eaee4-117">ゲーム クリップには、すべての処理が完了します。</span><span class="sxs-lookup"><span data-stu-id="eaee4-117">Game clip has finished all processing.</span></span>| 
| <span data-ttu-id="eaee4-118">Processing</span><span class="sxs-lookup"><span data-stu-id="eaee4-118">Processing</span></span>| <span data-ttu-id="eaee4-119">ゲーム クリップが処理されている (エンコーディングは、サムネイルなどです。)。</span><span class="sxs-lookup"><span data-stu-id="eaee4-119">Game clip is being processed (encoding, thumbnails, etc.).</span></span>| 
| <span data-ttu-id="eaee4-120">Publishing</span><span class="sxs-lookup"><span data-stu-id="eaee4-120">Publishing</span></span>| <span data-ttu-id="eaee4-121">ゲーム クリップ アセットが公開されています。</span><span class="sxs-lookup"><span data-stu-id="eaee4-121">Game clip assets are being published.</span></span>| 
| <span data-ttu-id="eaee4-122">Published</span><span class="sxs-lookup"><span data-stu-id="eaee4-122">Published</span></span>| <span data-ttu-id="eaee4-123">ゲーム クリップ アセットが公開された – この状態は、すべてのセットを表示することを示します。</span><span class="sxs-lookup"><span data-stu-id="eaee4-123">Game clip assets are published – this state indicates it is all set to view.</span></span>| 
| <span data-ttu-id="eaee4-124">フラグ</span><span class="sxs-lookup"><span data-stu-id="eaee4-124">Flagged</span></span>| <span data-ttu-id="eaee4-125">ゲーム クリップは実施のフラグが設定されています。</span><span class="sxs-lookup"><span data-stu-id="eaee4-125">Game clip has been flagged for enforcement.</span></span>| 
| <span data-ttu-id="eaee4-126">禁止</span><span class="sxs-lookup"><span data-stu-id="eaee4-126">Banned</span></span>| <span data-ttu-id="eaee4-127">ゲーム クリップが禁止されましたが削除されていません。</span><span class="sxs-lookup"><span data-stu-id="eaee4-127">Game clip has been banned but not yet deleted.</span></span>| 
| <span data-ttu-id="eaee4-128">Uploaded</span><span class="sxs-lookup"><span data-stu-id="eaee4-128">Uploaded</span></span>| <span data-ttu-id="eaee4-129">ゲーム クリップには、アップロードが完了しました。</span><span class="sxs-lookup"><span data-stu-id="eaee4-129">Game clip has completed upload.</span></span>| 
| <span data-ttu-id="eaee4-130">削除済み</span><span class="sxs-lookup"><span data-stu-id="eaee4-130">Deleted</span></span>| <span data-ttu-id="eaee4-131">ゲーム クリップが削除されました。</span><span class="sxs-lookup"><span data-stu-id="eaee4-131">Game clip has been deleted.</span></span>| 
| <span data-ttu-id="eaee4-132">エラー</span><span class="sxs-lookup"><span data-stu-id="eaee4-132">Error</span></span>| <span data-ttu-id="eaee4-133">ゲーム クリップがエラー状態と使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="eaee4-133">Game clip is in an error state and unusable.</span></span>| 
  