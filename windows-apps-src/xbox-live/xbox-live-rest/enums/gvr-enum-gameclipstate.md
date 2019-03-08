---
title: GameClipState 列挙型
assetID: 97fe5c1e-f7b5-537e-69eb-8284b69cd3e1
permalink: en-us/docs/xboxlive/rest/gvr-enum-gameclipstate.html
description: " GameClipState 列挙型"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f7b20224eeab1b98c7c80f0e4b551420b5a15e7d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630717"
---
# <a name="gameclipstate-enumeration"></a><span data-ttu-id="10722-104">GameClipState 列挙型</span><span class="sxs-lookup"><span data-stu-id="10722-104">GameClipState Enumeration</span></span>
<span data-ttu-id="10722-105">GameClipState 列挙体をについて説明します。</span><span class="sxs-lookup"><span data-stu-id="10722-105">Details the GameClipState enumeration.</span></span> 
<a id="ID4ET"></a>

 
## <a name="gameclipstate"></a><span data-ttu-id="10722-106">GameClipState</span><span class="sxs-lookup"><span data-stu-id="10722-106">GameClipState</span></span>
 
| <span data-ttu-id="10722-107"><b>列挙子</b></span><span class="sxs-lookup"><span data-stu-id="10722-107"><b>Enumerator</b></span></span>| <span data-ttu-id="10722-108"><b>説明</b></span><span class="sxs-lookup"><span data-stu-id="10722-108"><b>Description</b></span></span>| 
| --- | --- | 
| <span data-ttu-id="10722-109">なし</span><span class="sxs-lookup"><span data-stu-id="10722-109">None</span></span> | <span data-ttu-id="10722-110">ゲームのクリップのサービスの状態が、不明なまたは設定されていません。</span><span class="sxs-lookup"><span data-stu-id="10722-110">Game clip service state is unknown or not set.</span></span>| 
| <span data-ttu-id="10722-111">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="10722-111">PendingUpload</span></span> | <span data-ttu-id="10722-112">ゲームのクリップのサービスは、資産のアップロードを待機しています。</span><span class="sxs-lookup"><span data-stu-id="10722-112">Game clip service is waiting for the asset upload.</span></span>| 
| <span data-ttu-id="10722-113">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="10722-113">PendingDelete</span></span> | <span data-ttu-id="10722-114">ゲームのクリップは、キューの削除です。</span><span class="sxs-lookup"><span data-stu-id="10722-114">Game clip is in the queue for deletion.</span></span> <span data-ttu-id="10722-115">(実質的には、「削除」)。</span><span class="sxs-lookup"><span data-stu-id="10722-115">(Effectively means it is "deleted").</span></span>| 
| <span data-ttu-id="10722-116">処理</span><span class="sxs-lookup"><span data-stu-id="10722-116">Processed</span></span> | <span data-ttu-id="10722-117">ゲームのクリップには、すべての処理が完了しました。</span><span class="sxs-lookup"><span data-stu-id="10722-117">Game clip has finished all processing.</span></span>| 
| <span data-ttu-id="10722-118">Processing</span><span class="sxs-lookup"><span data-stu-id="10722-118">Processing</span></span>| <span data-ttu-id="10722-119">ゲームのクリップが処理される (エンコード、サムネイルなど。)。</span><span class="sxs-lookup"><span data-stu-id="10722-119">Game clip is being processed (encoding, thumbnails, etc.).</span></span>| 
| <span data-ttu-id="10722-120">公開</span><span class="sxs-lookup"><span data-stu-id="10722-120">Publishing</span></span>| <span data-ttu-id="10722-121">クリップのゲーム アセットが公開されています。</span><span class="sxs-lookup"><span data-stu-id="10722-121">Game clip assets are being published.</span></span>| 
| <span data-ttu-id="10722-122">公開済み</span><span class="sxs-lookup"><span data-stu-id="10722-122">Published</span></span>| <span data-ttu-id="10722-123">クリップのゲーム アセットを発行 – この状態は、すべてのセットを表示することを示します。</span><span class="sxs-lookup"><span data-stu-id="10722-123">Game clip assets are published – this state indicates it is all set to view.</span></span>| 
| <span data-ttu-id="10722-124">フラグが設定されました。</span><span class="sxs-lookup"><span data-stu-id="10722-124">Flagged</span></span>| <span data-ttu-id="10722-125">強制ゲーム クリップ フラグが設定されています。</span><span class="sxs-lookup"><span data-stu-id="10722-125">Game clip has been flagged for enforcement.</span></span>| 
| <span data-ttu-id="10722-126">禁止されています</span><span class="sxs-lookup"><span data-stu-id="10722-126">Banned</span></span>| <span data-ttu-id="10722-127">ゲームのクリップが禁止されましたが、削除されていません。</span><span class="sxs-lookup"><span data-stu-id="10722-127">Game clip has been banned but not yet deleted.</span></span>| 
| <span data-ttu-id="10722-128">Uploaded</span><span class="sxs-lookup"><span data-stu-id="10722-128">Uploaded</span></span>| <span data-ttu-id="10722-129">ゲームのクリップには、アップロードが完了しました。</span><span class="sxs-lookup"><span data-stu-id="10722-129">Game clip has completed upload.</span></span>| 
| <span data-ttu-id="10722-130">削除済み</span><span class="sxs-lookup"><span data-stu-id="10722-130">Deleted</span></span>| <span data-ttu-id="10722-131">ゲームのクリップが削除されました。</span><span class="sxs-lookup"><span data-stu-id="10722-131">Game clip has been deleted.</span></span>| 
| <span data-ttu-id="10722-132">エラー</span><span class="sxs-lookup"><span data-stu-id="10722-132">Error</span></span>| <span data-ttu-id="10722-133">ゲームのクリップがエラー状態と使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="10722-133">Game clip is in an error state and unusable.</span></span>| 
  