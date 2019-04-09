---
title: Device Portal の SMB API のリファレンス
description: SMB API にプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 1f0eb76e-fe3e-4674-a27e-229beec7e63d
ms.localizationpriority: medium
ms.openlocfilehash: a1040ec91af767d9472842b5ba656d347e7782d0
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244068"
---
# <a name="developer-folder-api-reference"></a><span data-ttu-id="e31c4-104">開発者向けフォルダー API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="e31c4-104">Developer folder API reference</span></span>

<span data-ttu-id="e31c4-105">標準的なエクスプローラーを使って、Xbox One の開発に関連するファイルにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e31c4-105">You can access development-related files on your Xbox One using a standard file explorer.</span></span> <span data-ttu-id="e31c4-106">これにより、ファイルを簡単に表示したり、PC から本体に置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="e31c4-106">This allows you to easily view and replace files from your PC to the console.</span></span>

**<span data-ttu-id="e31c4-107">要求</span><span class="sxs-lookup"><span data-stu-id="e31c4-107">Request</span></span>**

<span data-ttu-id="e31c4-108">次の要求を使用して、開発者向けフォルダーにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e31c4-108">You can access the developer folder using the following request.</span></span> <span data-ttu-id="e31c4-109">要求によって次の情報が返されます。</span><span class="sxs-lookup"><span data-stu-id="e31c4-109">The request will return:</span></span>

* <span data-ttu-id="e31c4-110">ファイル共有の場所。</span><span class="sxs-lookup"><span data-stu-id="e31c4-110">The location of the file share.</span></span> <span data-ttu-id="e31c4-111">この場所は、エクスプローラーのアドレス バーに入力できます。</span><span class="sxs-lookup"><span data-stu-id="e31c4-111">This location can be entered into the address bar in a file explorer.</span></span>
* <span data-ttu-id="e31c4-112">ファイル共有へのアクセスで使うユーザー名。</span><span class="sxs-lookup"><span data-stu-id="e31c4-112">The username to access the file share.</span></span>
* <span data-ttu-id="e31c4-113">ファイル共有へのアクセスで使うパスワード。</span><span class="sxs-lookup"><span data-stu-id="e31c4-113">The password to access the file share.</span></span>

<span data-ttu-id="e31c4-114">メソッド</span><span class="sxs-lookup"><span data-stu-id="e31c4-114">Method</span></span>      | <span data-ttu-id="e31c4-115">要求 URI</span><span class="sxs-lookup"><span data-stu-id="e31c4-115">Request URI</span></span>
:------     | :-----
<span data-ttu-id="e31c4-116">GET</span><span class="sxs-lookup"><span data-stu-id="e31c4-116">GET</span></span> | <span data-ttu-id="e31c4-117">/ext/smb/developerfolder</span><span class="sxs-lookup"><span data-stu-id="e31c4-117">/ext/smb/developerfolder</span></span>

**<span data-ttu-id="e31c4-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e31c4-118">URI parameters</span></span>**

- <span data-ttu-id="e31c4-119">なし</span><span class="sxs-lookup"><span data-stu-id="e31c4-119">None</span></span>

**<span data-ttu-id="e31c4-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e31c4-120">Request headers</span></span>**

- <span data-ttu-id="e31c4-121">なし</span><span class="sxs-lookup"><span data-stu-id="e31c4-121">None</span></span>

**<span data-ttu-id="e31c4-122">要求本文</span><span class="sxs-lookup"><span data-stu-id="e31c4-122">Request body</span></span>**

- <span data-ttu-id="e31c4-123">なし</span><span class="sxs-lookup"><span data-stu-id="e31c4-123">None</span></span>

**<span data-ttu-id="e31c4-124">応答</span><span class="sxs-lookup"><span data-stu-id="e31c4-124">Response</span></span>**   
<span data-ttu-id="e31c4-125">Path: 開発者向けファイル共有にあるファイルのパス。</span><span class="sxs-lookup"><span data-stu-id="e31c4-125">Path - the path to the file developer files share.</span></span>   
<span data-ttu-id="e31c4-126">Username: 開発者向けファイル共有にアクセスするために必要なユーザー名。</span><span class="sxs-lookup"><span data-stu-id="e31c4-126">Username - the username needed to access the developer files share.</span></span>   
<span data-ttu-id="e31c4-127">Password: 開発者向けファイル共有にアクセスするために必要なパスワード。</span><span class="sxs-lookup"><span data-stu-id="e31c4-127">Password - the password needed to access the developer files share.</span></span>   

**<span data-ttu-id="e31c4-128">状態コード</span><span class="sxs-lookup"><span data-stu-id="e31c4-128">Status code</span></span>**

<span data-ttu-id="e31c4-129">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e31c4-129">This API has the following expected status codes.</span></span>

<span data-ttu-id="e31c4-130">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e31c4-130">HTTP status code</span></span>      | <span data-ttu-id="e31c4-131">説明</span><span class="sxs-lookup"><span data-stu-id="e31c4-131">Description</span></span>
:------     | :-----
<span data-ttu-id="e31c4-132">200</span><span class="sxs-lookup"><span data-stu-id="e31c4-132">200</span></span> | <span data-ttu-id="e31c4-133">ファイル共有の資格情報にアクセスする要求が許可されました。</span><span class="sxs-lookup"><span data-stu-id="e31c4-133">The request to access the credentials for the file share was granted.</span></span>
<span data-ttu-id="e31c4-134">4XX</span><span class="sxs-lookup"><span data-stu-id="e31c4-134">4XX</span></span> | <span data-ttu-id="e31c4-135">エラー コード</span><span class="sxs-lookup"><span data-stu-id="e31c4-135">Error codes</span></span>
<span data-ttu-id="e31c4-136">5XX</span><span class="sxs-lookup"><span data-stu-id="e31c4-136">5XX</span></span> | <span data-ttu-id="e31c4-137">エラー コード</span><span class="sxs-lookup"><span data-stu-id="e31c4-137">Error codes</span></span>

**<span data-ttu-id="e31c4-138">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="e31c4-138">Available device families</span></span>**

* <span data-ttu-id="e31c4-139">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="e31c4-139">Windows Xbox</span></span>
