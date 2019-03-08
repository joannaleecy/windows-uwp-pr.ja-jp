---
title: Device Portal のフォルダー アップロード API のリファレンス
description: フォルダー アップロード API にプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: e1a2c7f0-0040-4ce7-94de-17224736e20b
ms.localizationpriority: medium
ms.openlocfilehash: 0805dbeedcf66bc3596f3d284f51e8f177608396
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617607"
---
# <a name="upload-a-folder-to-the-development-directory"></a><span data-ttu-id="1c653-104">開発ディレクトリにフォルダーをアップロードする</span><span class="sxs-lookup"><span data-stu-id="1c653-104">Upload a folder to the development directory</span></span>

<span data-ttu-id="1c653-105">**要求**</span><span class="sxs-lookup"><span data-stu-id="1c653-105">**Request**</span></span>

<span data-ttu-id="1c653-106">フォルダー全体を DevelopmentFiles の既知のフォルダー ID (またはそのフォルダーのサブフォルダー) に一度にアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="1c653-106">You can upload an entire folder at once to the Known Folder Id for the DevelopmentFiles (or to a subfolder within that folder).</span></span>

<span data-ttu-id="1c653-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="1c653-107">Method</span></span>      | <span data-ttu-id="1c653-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="1c653-108">Request URI</span></span>
:------     | :------
<span data-ttu-id="1c653-109">POST</span><span class="sxs-lookup"><span data-stu-id="1c653-109">POST</span></span> | <span data-ttu-id="1c653-110">/api/app/packagemanager/upload</span><span class="sxs-lookup"><span data-stu-id="1c653-110">/api/app/packagemanager/upload</span></span> 
<br />
<span data-ttu-id="1c653-111">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="1c653-111">**URI parameters**</span></span>

<span data-ttu-id="1c653-112">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="1c653-112">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="1c653-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1c653-113">URI Parameter</span></span>      | <span data-ttu-id="1c653-114">説明</span><span class="sxs-lookup"><span data-stu-id="1c653-114">Description</span></span>
:------     | :-----
<span data-ttu-id="1c653-115">destinationFolder (必須)</span><span class="sxs-lookup"><span data-stu-id="1c653-115">destinationFolder  (required)</span></span> | <span data-ttu-id="1c653-116">アップロードするフォルダーのターゲット フォルダー名です。</span><span class="sxs-lookup"><span data-stu-id="1c653-116">The destination folder name of the folder to be uploaded.</span></span> <span data-ttu-id="1c653-117">このフォルダーは、本体の d:\developmentfiles\LooseApps に配置されます。</span><span class="sxs-lookup"><span data-stu-id="1c653-117">This folder will be placed under d:\developmentfiles\LooseApps on the console.</span></span> <span data-ttu-id="1c653-118">フォルダーが LooseApps の下のサブフォルダーである場合、フォルダー名にパスの区切り文字が含まれる可能性があるため、このフォルダー名は base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="1c653-118">This folder name should be base64 encoded as it may contain path separators if the folder is a subfolder under LooseApps.</span></span>
<br />

<span data-ttu-id="1c653-119">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="1c653-119">**Request headers**</span></span>

- <span data-ttu-id="1c653-120">なし</span><span class="sxs-lookup"><span data-stu-id="1c653-120">None</span></span>

<span data-ttu-id="1c653-121">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="1c653-121">**Request body**</span></span>

- <span data-ttu-id="1c653-122">ディレクトリ コンテンツの原則に従ったマルチパートの http 本文。</span><span class="sxs-lookup"><span data-stu-id="1c653-122">multi-part conforming http body of the directory contents.</span></span>

<span data-ttu-id="1c653-123">**応答**</span><span class="sxs-lookup"><span data-stu-id="1c653-123">**Response**</span></span>

<span data-ttu-id="1c653-124">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="1c653-124">**Status code**</span></span>

<span data-ttu-id="1c653-125">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1c653-125">This API has the following expected status codes.</span></span>

<span data-ttu-id="1c653-126">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="1c653-126">HTTP status code</span></span>      | <span data-ttu-id="1c653-127">説明</span><span class="sxs-lookup"><span data-stu-id="1c653-127">Description</span></span>
:------     | :-----
<span data-ttu-id="1c653-128">200</span><span class="sxs-lookup"><span data-stu-id="1c653-128">200</span></span> | <span data-ttu-id="1c653-129">成功</span><span class="sxs-lookup"><span data-stu-id="1c653-129">Success</span></span>
<span data-ttu-id="1c653-130">4XX</span><span class="sxs-lookup"><span data-stu-id="1c653-130">4XX</span></span> | <span data-ttu-id="1c653-131">エラー コード</span><span class="sxs-lookup"><span data-stu-id="1c653-131">Error codes</span></span>
<span data-ttu-id="1c653-132">5XX</span><span class="sxs-lookup"><span data-stu-id="1c653-132">5XX</span></span> | <span data-ttu-id="1c653-133">エラー コード</span><span class="sxs-lookup"><span data-stu-id="1c653-133">Error codes</span></span>
<br />
<span data-ttu-id="1c653-134">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="1c653-134">**Available device families**</span></span>

* <span data-ttu-id="1c653-135">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="1c653-135">Windows Xbox</span></span>

