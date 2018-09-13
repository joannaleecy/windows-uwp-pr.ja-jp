---
title: GameClipState 列挙
assetID: 97fe5c1e-f7b5-537e-69eb-8284b69cd3e1
permalink: en-us/docs/xboxlive/rest/gvr-enum-gameclipstate.html
author: KevinAsgari
description: " GameClipState 列挙"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9865d626fe3c07645c8cb51f9bd5fe2274bf23f3
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3964483"
---
# <a name="gameclipstate-enumeration"></a><span data-ttu-id="713df-104">GameClipState 列挙</span><span class="sxs-lookup"><span data-stu-id="713df-104">GameClipState Enumeration</span></span>
<span data-ttu-id="713df-105">GameClipState 列挙をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="713df-105">Details the GameClipState enumeration.</span></span> 
<a id="ID4ET"></a>

 
## <a name="gameclipstate"></a><span data-ttu-id="713df-106">GameClipState</span><span class="sxs-lookup"><span data-stu-id="713df-106">GameClipState</span></span>
 
| <b><span data-ttu-id="713df-107">列挙子</span><span class="sxs-lookup"><span data-stu-id="713df-107">Enumerator</span></span></b>| <b><span data-ttu-id="713df-108">説明</span><span class="sxs-lookup"><span data-stu-id="713df-108">Description</span></span></b>| 
| --- | --- | 
| <span data-ttu-id="713df-109">None</span><span class="sxs-lookup"><span data-stu-id="713df-109">None</span></span> | <span data-ttu-id="713df-110">ゲーム クリップのサービスの状態は、不明なまたは設定されていないです。</span><span class="sxs-lookup"><span data-stu-id="713df-110">Game clip service state is unknown or not set.</span></span>| 
| <span data-ttu-id="713df-111">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="713df-111">PendingUpload</span></span> | <span data-ttu-id="713df-112">ゲーム クリップ サービスは、資産のアップロードを待機しています。</span><span class="sxs-lookup"><span data-stu-id="713df-112">Game clip service is waiting for the asset upload.</span></span>| 
| <span data-ttu-id="713df-113">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="713df-113">PendingDelete</span></span> | <span data-ttu-id="713df-114">ゲーム クリップでは、削除、キューにします。</span><span class="sxs-lookup"><span data-stu-id="713df-114">Game clip is in the queue for deletion.</span></span> <span data-ttu-id="713df-115">(実質的には、「削除」)。</span><span class="sxs-lookup"><span data-stu-id="713df-115">(Effectively means it is "deleted").</span></span>| 
| <span data-ttu-id="713df-116">処理済み</span><span class="sxs-lookup"><span data-stu-id="713df-116">Processed</span></span> | <span data-ttu-id="713df-117">ゲーム クリップには、すべての処理が完了します。</span><span class="sxs-lookup"><span data-stu-id="713df-117">Game clip has finished all processing.</span></span>| 
| <span data-ttu-id="713df-118">Processing</span><span class="sxs-lookup"><span data-stu-id="713df-118">Processing</span></span>| <span data-ttu-id="713df-119">ゲーム クリップが処理されている (エンコーディングは、サムネイルなどです。)。</span><span class="sxs-lookup"><span data-stu-id="713df-119">Game clip is being processed (encoding, thumbnails, etc.).</span></span>| 
| <span data-ttu-id="713df-120">Publishing</span><span class="sxs-lookup"><span data-stu-id="713df-120">Publishing</span></span>| <span data-ttu-id="713df-121">ゲーム クリップ アセットが公開されています。</span><span class="sxs-lookup"><span data-stu-id="713df-121">Game clip assets are being published.</span></span>| 
| <span data-ttu-id="713df-122">Published</span><span class="sxs-lookup"><span data-stu-id="713df-122">Published</span></span>| <span data-ttu-id="713df-123">ゲーム クリップ アセットが公開された – この状態は、すべてのセットを表示することを示します。</span><span class="sxs-lookup"><span data-stu-id="713df-123">Game clip assets are published – this state indicates it is all set to view.</span></span>| 
| <span data-ttu-id="713df-124">フラグ</span><span class="sxs-lookup"><span data-stu-id="713df-124">Flagged</span></span>| <span data-ttu-id="713df-125">ゲーム クリップを適用してマークされています。</span><span class="sxs-lookup"><span data-stu-id="713df-125">Game clip has been flagged for enforcement.</span></span>| 
| <span data-ttu-id="713df-126">禁止</span><span class="sxs-lookup"><span data-stu-id="713df-126">Banned</span></span>| <span data-ttu-id="713df-127">ゲーム クリップが禁止されましたが削除されていません。</span><span class="sxs-lookup"><span data-stu-id="713df-127">Game clip has been banned but not yet deleted.</span></span>| 
| <span data-ttu-id="713df-128">Uploaded</span><span class="sxs-lookup"><span data-stu-id="713df-128">Uploaded</span></span>| <span data-ttu-id="713df-129">ゲーム クリップには、アップロードが完了しました。</span><span class="sxs-lookup"><span data-stu-id="713df-129">Game clip has completed upload.</span></span>| 
| <span data-ttu-id="713df-130">削除済み</span><span class="sxs-lookup"><span data-stu-id="713df-130">Deleted</span></span>| <span data-ttu-id="713df-131">ゲーム クリップが削除されました。</span><span class="sxs-lookup"><span data-stu-id="713df-131">Game clip has been deleted.</span></span>| 
| <span data-ttu-id="713df-132">エラー</span><span class="sxs-lookup"><span data-stu-id="713df-132">Error</span></span>| <span data-ttu-id="713df-133">ゲーム クリップがエラー状態と使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="713df-133">Game clip is in an error state and unusable.</span></span>| 
  