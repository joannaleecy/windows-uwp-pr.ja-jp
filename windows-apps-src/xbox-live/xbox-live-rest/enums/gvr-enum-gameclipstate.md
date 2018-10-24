---
title: GameClipState 列挙型
assetID: 97fe5c1e-f7b5-537e-69eb-8284b69cd3e1
permalink: en-us/docs/xboxlive/rest/gvr-enum-gameclipstate.html
author: KevinAsgari
description: " GameClipState 列挙型"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9865d626fe3c07645c8cb51f9bd5fe2274bf23f3
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5439838"
---
# <a name="gameclipstate-enumeration"></a><span data-ttu-id="16758-104">GameClipState 列挙型</span><span class="sxs-lookup"><span data-stu-id="16758-104">GameClipState Enumeration</span></span>
<span data-ttu-id="16758-105">GameClipState 列挙型をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="16758-105">Details the GameClipState enumeration.</span></span> 
<a id="ID4ET"></a>

 
## <a name="gameclipstate"></a><span data-ttu-id="16758-106">GameClipState</span><span class="sxs-lookup"><span data-stu-id="16758-106">GameClipState</span></span>
 
| <b><span data-ttu-id="16758-107">列挙子</span><span class="sxs-lookup"><span data-stu-id="16758-107">Enumerator</span></span></b>| <b><span data-ttu-id="16758-108">説明</span><span class="sxs-lookup"><span data-stu-id="16758-108">Description</span></span></b>| 
| --- | --- | 
| <span data-ttu-id="16758-109">None</span><span class="sxs-lookup"><span data-stu-id="16758-109">None</span></span> | <span data-ttu-id="16758-110">ゲーム クリップ サービスの状態は、不明なまたは設定されていないです。</span><span class="sxs-lookup"><span data-stu-id="16758-110">Game clip service state is unknown or not set.</span></span>| 
| <span data-ttu-id="16758-111">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="16758-111">PendingUpload</span></span> | <span data-ttu-id="16758-112">ゲーム クリップ サービスは、資産のアップロードを待機しています。</span><span class="sxs-lookup"><span data-stu-id="16758-112">Game clip service is waiting for the asset upload.</span></span>| 
| <span data-ttu-id="16758-113">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="16758-113">PendingDelete</span></span> | <span data-ttu-id="16758-114">ゲーム クリップは、削除のキューにあります。</span><span class="sxs-lookup"><span data-stu-id="16758-114">Game clip is in the queue for deletion.</span></span> <span data-ttu-id="16758-115">(実質的に「は」)。</span><span class="sxs-lookup"><span data-stu-id="16758-115">(Effectively means it is "deleted").</span></span>| 
| <span data-ttu-id="16758-116">処理済み</span><span class="sxs-lookup"><span data-stu-id="16758-116">Processed</span></span> | <span data-ttu-id="16758-117">ゲーム クリップには、すべての処理が完了します。</span><span class="sxs-lookup"><span data-stu-id="16758-117">Game clip has finished all processing.</span></span>| 
| <span data-ttu-id="16758-118">Processing</span><span class="sxs-lookup"><span data-stu-id="16758-118">Processing</span></span>| <span data-ttu-id="16758-119">ゲーム クリップが処理されている (エンコーディングは、サムネイルなどです。)。</span><span class="sxs-lookup"><span data-stu-id="16758-119">Game clip is being processed (encoding, thumbnails, etc.).</span></span>| 
| <span data-ttu-id="16758-120">Publishing</span><span class="sxs-lookup"><span data-stu-id="16758-120">Publishing</span></span>| <span data-ttu-id="16758-121">ゲーム クリップ アセットが公開されています。</span><span class="sxs-lookup"><span data-stu-id="16758-121">Game clip assets are being published.</span></span>| 
| <span data-ttu-id="16758-122">Published</span><span class="sxs-lookup"><span data-stu-id="16758-122">Published</span></span>| <span data-ttu-id="16758-123">ゲーム クリップ アセットが公開された – この状態は、すべてのセットを表示することを示します。</span><span class="sxs-lookup"><span data-stu-id="16758-123">Game clip assets are published – this state indicates it is all set to view.</span></span>| 
| <span data-ttu-id="16758-124">フラグ</span><span class="sxs-lookup"><span data-stu-id="16758-124">Flagged</span></span>| <span data-ttu-id="16758-125">ゲーム クリップは強制のフラグが設定されています。</span><span class="sxs-lookup"><span data-stu-id="16758-125">Game clip has been flagged for enforcement.</span></span>| 
| <span data-ttu-id="16758-126">禁止</span><span class="sxs-lookup"><span data-stu-id="16758-126">Banned</span></span>| <span data-ttu-id="16758-127">ゲーム クリップが禁止されているされましたが削除されていません。</span><span class="sxs-lookup"><span data-stu-id="16758-127">Game clip has been banned but not yet deleted.</span></span>| 
| <span data-ttu-id="16758-128">Uploaded</span><span class="sxs-lookup"><span data-stu-id="16758-128">Uploaded</span></span>| <span data-ttu-id="16758-129">ゲーム クリップには、アップロードが完了しました。</span><span class="sxs-lookup"><span data-stu-id="16758-129">Game clip has completed upload.</span></span>| 
| <span data-ttu-id="16758-130">削除済み</span><span class="sxs-lookup"><span data-stu-id="16758-130">Deleted</span></span>| <span data-ttu-id="16758-131">ゲーム クリップが削除されました。</span><span class="sxs-lookup"><span data-stu-id="16758-131">Game clip has been deleted.</span></span>| 
| <span data-ttu-id="16758-132">エラー</span><span class="sxs-lookup"><span data-stu-id="16758-132">Error</span></span>| <span data-ttu-id="16758-133">ゲーム クリップがエラー状態と使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="16758-133">Game clip is in an error state and unusable.</span></span>| 
  