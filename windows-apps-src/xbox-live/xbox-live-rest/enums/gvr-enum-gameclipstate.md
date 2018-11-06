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
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6033438"
---
# <a name="gameclipstate-enumeration"></a><span data-ttu-id="15a01-104">GameClipState 列挙型</span><span class="sxs-lookup"><span data-stu-id="15a01-104">GameClipState Enumeration</span></span>
<span data-ttu-id="15a01-105">GameClipState 列挙型をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="15a01-105">Details the GameClipState enumeration.</span></span> 
<a id="ID4ET"></a>

 
## <a name="gameclipstate"></a><span data-ttu-id="15a01-106">GameClipState</span><span class="sxs-lookup"><span data-stu-id="15a01-106">GameClipState</span></span>
 
| <b><span data-ttu-id="15a01-107">列挙子</span><span class="sxs-lookup"><span data-stu-id="15a01-107">Enumerator</span></span></b>| <b><span data-ttu-id="15a01-108">説明</span><span class="sxs-lookup"><span data-stu-id="15a01-108">Description</span></span></b>| 
| --- | --- | 
| <span data-ttu-id="15a01-109">None</span><span class="sxs-lookup"><span data-stu-id="15a01-109">None</span></span> | <span data-ttu-id="15a01-110">ゲーム クリップ サービスの状態は、不明なまたは設定されていないです。</span><span class="sxs-lookup"><span data-stu-id="15a01-110">Game clip service state is unknown or not set.</span></span>| 
| <span data-ttu-id="15a01-111">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="15a01-111">PendingUpload</span></span> | <span data-ttu-id="15a01-112">ゲーム クリップ サービスは、資産のアップロードを待機しています。</span><span class="sxs-lookup"><span data-stu-id="15a01-112">Game clip service is waiting for the asset upload.</span></span>| 
| <span data-ttu-id="15a01-113">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="15a01-113">PendingDelete</span></span> | <span data-ttu-id="15a01-114">ゲーム クリップでは、削除、キューにします。</span><span class="sxs-lookup"><span data-stu-id="15a01-114">Game clip is in the queue for deletion.</span></span> <span data-ttu-id="15a01-115">(実質的には、「削除」)。</span><span class="sxs-lookup"><span data-stu-id="15a01-115">(Effectively means it is "deleted").</span></span>| 
| <span data-ttu-id="15a01-116">処理済み</span><span class="sxs-lookup"><span data-stu-id="15a01-116">Processed</span></span> | <span data-ttu-id="15a01-117">ゲーム クリップには、すべての処理が完了します。</span><span class="sxs-lookup"><span data-stu-id="15a01-117">Game clip has finished all processing.</span></span>| 
| <span data-ttu-id="15a01-118">Processing</span><span class="sxs-lookup"><span data-stu-id="15a01-118">Processing</span></span>| <span data-ttu-id="15a01-119">ゲーム クリップが処理されている (エンコーディングは、サムネイルなどです。)。</span><span class="sxs-lookup"><span data-stu-id="15a01-119">Game clip is being processed (encoding, thumbnails, etc.).</span></span>| 
| <span data-ttu-id="15a01-120">Publishing</span><span class="sxs-lookup"><span data-stu-id="15a01-120">Publishing</span></span>| <span data-ttu-id="15a01-121">ゲーム クリップ アセットが公開されています。</span><span class="sxs-lookup"><span data-stu-id="15a01-121">Game clip assets are being published.</span></span>| 
| <span data-ttu-id="15a01-122">Published</span><span class="sxs-lookup"><span data-stu-id="15a01-122">Published</span></span>| <span data-ttu-id="15a01-123">ゲーム クリップ アセットが公開された – この状態は、すべてのセットを表示することを示します。</span><span class="sxs-lookup"><span data-stu-id="15a01-123">Game clip assets are published – this state indicates it is all set to view.</span></span>| 
| <span data-ttu-id="15a01-124">フラグが設定</span><span class="sxs-lookup"><span data-stu-id="15a01-124">Flagged</span></span>| <span data-ttu-id="15a01-125">ゲーム クリップを適用してマークされています。</span><span class="sxs-lookup"><span data-stu-id="15a01-125">Game clip has been flagged for enforcement.</span></span>| 
| <span data-ttu-id="15a01-126">禁止</span><span class="sxs-lookup"><span data-stu-id="15a01-126">Banned</span></span>| <span data-ttu-id="15a01-127">ゲーム クリップが禁止されましたが削除されていません。</span><span class="sxs-lookup"><span data-stu-id="15a01-127">Game clip has been banned but not yet deleted.</span></span>| 
| <span data-ttu-id="15a01-128">Uploaded</span><span class="sxs-lookup"><span data-stu-id="15a01-128">Uploaded</span></span>| <span data-ttu-id="15a01-129">ゲーム クリップには、アップロードが完了しました。</span><span class="sxs-lookup"><span data-stu-id="15a01-129">Game clip has completed upload.</span></span>| 
| <span data-ttu-id="15a01-130">削除済み</span><span class="sxs-lookup"><span data-stu-id="15a01-130">Deleted</span></span>| <span data-ttu-id="15a01-131">ゲーム クリップが削除されました。</span><span class="sxs-lookup"><span data-stu-id="15a01-131">Game clip has been deleted.</span></span>| 
| <span data-ttu-id="15a01-132">エラー</span><span class="sxs-lookup"><span data-stu-id="15a01-132">Error</span></span>| <span data-ttu-id="15a01-133">ゲーム クリップがエラー状態と使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="15a01-133">Game clip is in an error state and unusable.</span></span>| 
  