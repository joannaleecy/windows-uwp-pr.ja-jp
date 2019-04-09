---
title: Device Portal のフォルダー アップロード API のリファレンス
description: フォルダー アップロード API にプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: e1a2c7f0-0040-4ce7-94de-17224736e20b
ms.localizationpriority: medium
ms.openlocfilehash: 870d203271cb75ecf5531106bb2c10b3736db9b9
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244048"
---
# <a name="upload-a-folder-to-the-development-directory"></a><span data-ttu-id="ae229-104">開発ディレクトリにフォルダーをアップロードする</span><span class="sxs-lookup"><span data-stu-id="ae229-104">Upload a folder to the development directory</span></span>

**<span data-ttu-id="ae229-105">要求</span><span class="sxs-lookup"><span data-stu-id="ae229-105">Request</span></span>**

<span data-ttu-id="ae229-106">フォルダー全体を DevelopmentFiles の既知のフォルダー ID (またはそのフォルダーのサブフォルダー) に一度にアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="ae229-106">You can upload an entire folder at once to the Known Folder Id for the DevelopmentFiles (or to a subfolder within that folder).</span></span>

<span data-ttu-id="ae229-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="ae229-107">Method</span></span>      | <span data-ttu-id="ae229-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="ae229-108">Request URI</span></span>
:------     | :------
<span data-ttu-id="ae229-109">POST</span><span class="sxs-lookup"><span data-stu-id="ae229-109">POST</span></span> | <span data-ttu-id="ae229-110">/api/app/packagemanager/upload</span><span class="sxs-lookup"><span data-stu-id="ae229-110">/api/app/packagemanager/upload</span></span> 

**<span data-ttu-id="ae229-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ae229-111">URI parameters</span></span>**

<span data-ttu-id="ae229-112">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="ae229-112">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="ae229-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ae229-113">URI Parameter</span></span>      | <span data-ttu-id="ae229-114">説明</span><span class="sxs-lookup"><span data-stu-id="ae229-114">Description</span></span>
:------     | :-----
<span data-ttu-id="ae229-115">destinationFolder (必須)</span><span class="sxs-lookup"><span data-stu-id="ae229-115">destinationFolder  (required)</span></span> | <span data-ttu-id="ae229-116">アップロードするフォルダーのターゲット フォルダー名です。</span><span class="sxs-lookup"><span data-stu-id="ae229-116">The destination folder name of the folder to be uploaded.</span></span> <span data-ttu-id="ae229-117">このフォルダーは、本体の d:\developmentfiles\LooseApps に配置されます。</span><span class="sxs-lookup"><span data-stu-id="ae229-117">This folder will be placed under d:\developmentfiles\LooseApps on the console.</span></span> <span data-ttu-id="ae229-118">フォルダーが LooseApps の下のサブフォルダーである場合、フォルダー名にパスの区切り文字が含まれる可能性があるため、このフォルダー名は base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae229-118">This folder name should be base64 encoded as it may contain path separators if the folder is a subfolder under LooseApps.</span></span>


**<span data-ttu-id="ae229-119">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ae229-119">Request headers</span></span>**

- <span data-ttu-id="ae229-120">なし</span><span class="sxs-lookup"><span data-stu-id="ae229-120">None</span></span>

**<span data-ttu-id="ae229-121">要求本文</span><span class="sxs-lookup"><span data-stu-id="ae229-121">Request body</span></span>**

- <span data-ttu-id="ae229-122">ディレクトリ コンテンツの原則に従ったマルチパートの http 本文。</span><span class="sxs-lookup"><span data-stu-id="ae229-122">multi-part conforming http body of the directory contents.</span></span>

**<span data-ttu-id="ae229-123">応答</span><span class="sxs-lookup"><span data-stu-id="ae229-123">Response</span></span>**

**<span data-ttu-id="ae229-124">状態コード</span><span class="sxs-lookup"><span data-stu-id="ae229-124">Status code</span></span>**

<span data-ttu-id="ae229-125">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ae229-125">This API has the following expected status codes.</span></span>

<span data-ttu-id="ae229-126">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="ae229-126">HTTP status code</span></span>      | <span data-ttu-id="ae229-127">説明</span><span class="sxs-lookup"><span data-stu-id="ae229-127">Description</span></span>
:------     | :-----
<span data-ttu-id="ae229-128">200</span><span class="sxs-lookup"><span data-stu-id="ae229-128">200</span></span> | <span data-ttu-id="ae229-129">成功</span><span class="sxs-lookup"><span data-stu-id="ae229-129">Success</span></span>
<span data-ttu-id="ae229-130">4XX</span><span class="sxs-lookup"><span data-stu-id="ae229-130">4XX</span></span> | <span data-ttu-id="ae229-131">エラー コード</span><span class="sxs-lookup"><span data-stu-id="ae229-131">Error codes</span></span>
<span data-ttu-id="ae229-132">5XX</span><span class="sxs-lookup"><span data-stu-id="ae229-132">5XX</span></span> | <span data-ttu-id="ae229-133">エラー コード</span><span class="sxs-lookup"><span data-stu-id="ae229-133">Error codes</span></span>

**<span data-ttu-id="ae229-134">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="ae229-134">Available device families</span></span>**

* <span data-ttu-id="ae229-135">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="ae229-135">Windows Xbox</span></span>

