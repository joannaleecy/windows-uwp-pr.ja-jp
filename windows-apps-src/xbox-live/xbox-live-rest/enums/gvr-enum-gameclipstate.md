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
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4503585"
---
# <a name="gameclipstate-enumeration"></a><span data-ttu-id="449eb-104">GameClipState 列挙型</span><span class="sxs-lookup"><span data-stu-id="449eb-104">GameClipState Enumeration</span></span>
<span data-ttu-id="449eb-105">GameClipState 列挙型をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="449eb-105">Details the GameClipState enumeration.</span></span> 
<a id="ID4ET"></a>

 
## <a name="gameclipstate"></a><span data-ttu-id="449eb-106">GameClipState</span><span class="sxs-lookup"><span data-stu-id="449eb-106">GameClipState</span></span>
 
| <b><span data-ttu-id="449eb-107">列挙子</span><span class="sxs-lookup"><span data-stu-id="449eb-107">Enumerator</span></span></b>| <b><span data-ttu-id="449eb-108">説明</span><span class="sxs-lookup"><span data-stu-id="449eb-108">Description</span></span></b>| 
| --- | --- | 
| <span data-ttu-id="449eb-109">None</span><span class="sxs-lookup"><span data-stu-id="449eb-109">None</span></span> | <span data-ttu-id="449eb-110">ゲーム クリップ サービスの状態が、不明なまたは設定されていません。</span><span class="sxs-lookup"><span data-stu-id="449eb-110">Game clip service state is unknown or not set.</span></span>| 
| <span data-ttu-id="449eb-111">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="449eb-111">PendingUpload</span></span> | <span data-ttu-id="449eb-112">ゲーム クリップ サービスは、資産のアップロードを待機しています。</span><span class="sxs-lookup"><span data-stu-id="449eb-112">Game clip service is waiting for the asset upload.</span></span>| 
| <span data-ttu-id="449eb-113">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="449eb-113">PendingDelete</span></span> | <span data-ttu-id="449eb-114">削除のキューがゲーム クリップにします。</span><span class="sxs-lookup"><span data-stu-id="449eb-114">Game clip is in the queue for deletion.</span></span> <span data-ttu-id="449eb-115">(実質的には、「削除」)。</span><span class="sxs-lookup"><span data-stu-id="449eb-115">(Effectively means it is "deleted").</span></span>| 
| <span data-ttu-id="449eb-116">処理済み</span><span class="sxs-lookup"><span data-stu-id="449eb-116">Processed</span></span> | <span data-ttu-id="449eb-117">ゲーム クリップには、すべての処理が完了します。</span><span class="sxs-lookup"><span data-stu-id="449eb-117">Game clip has finished all processing.</span></span>| 
| <span data-ttu-id="449eb-118">Processing</span><span class="sxs-lookup"><span data-stu-id="449eb-118">Processing</span></span>| <span data-ttu-id="449eb-119">ゲーム クリップが処理されている (エンコーディングは、サムネイルなどです。)。</span><span class="sxs-lookup"><span data-stu-id="449eb-119">Game clip is being processed (encoding, thumbnails, etc.).</span></span>| 
| <span data-ttu-id="449eb-120">Publishing</span><span class="sxs-lookup"><span data-stu-id="449eb-120">Publishing</span></span>| <span data-ttu-id="449eb-121">ゲーム クリップ アセットが公開されています。</span><span class="sxs-lookup"><span data-stu-id="449eb-121">Game clip assets are being published.</span></span>| 
| <span data-ttu-id="449eb-122">Published</span><span class="sxs-lookup"><span data-stu-id="449eb-122">Published</span></span>| <span data-ttu-id="449eb-123">ゲーム クリップ アセットが公開された – この状態は、すべてのセットを表示することを示します。</span><span class="sxs-lookup"><span data-stu-id="449eb-123">Game clip assets are published – this state indicates it is all set to view.</span></span>| 
| <span data-ttu-id="449eb-124">フラグが設定</span><span class="sxs-lookup"><span data-stu-id="449eb-124">Flagged</span></span>| <span data-ttu-id="449eb-125">ゲーム クリップを適用してマークされています。</span><span class="sxs-lookup"><span data-stu-id="449eb-125">Game clip has been flagged for enforcement.</span></span>| 
| <span data-ttu-id="449eb-126">禁止</span><span class="sxs-lookup"><span data-stu-id="449eb-126">Banned</span></span>| <span data-ttu-id="449eb-127">ゲーム クリップが禁止されましたが削除されていません。</span><span class="sxs-lookup"><span data-stu-id="449eb-127">Game clip has been banned but not yet deleted.</span></span>| 
| <span data-ttu-id="449eb-128">Uploaded</span><span class="sxs-lookup"><span data-stu-id="449eb-128">Uploaded</span></span>| <span data-ttu-id="449eb-129">ゲーム クリップには、アップロードが完了しました。</span><span class="sxs-lookup"><span data-stu-id="449eb-129">Game clip has completed upload.</span></span>| 
| <span data-ttu-id="449eb-130">削除済み</span><span class="sxs-lookup"><span data-stu-id="449eb-130">Deleted</span></span>| <span data-ttu-id="449eb-131">ゲーム クリップが削除されました。</span><span class="sxs-lookup"><span data-stu-id="449eb-131">Game clip has been deleted.</span></span>| 
| <span data-ttu-id="449eb-132">エラー</span><span class="sxs-lookup"><span data-stu-id="449eb-132">Error</span></span>| <span data-ttu-id="449eb-133">ゲーム クリップはエラー状態と使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="449eb-133">Game clip is in an error state and unusable.</span></span>| 
  