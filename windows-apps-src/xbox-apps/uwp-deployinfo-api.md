---
title: デバイス ポータル展開情報 API リファレンス
description: 展開情報 API にプログラムでアクセスする方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: c44089313b100880b419e9b55a26101e877496f3
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8487254"
---
# <a name="requests-deployment-information-for-one-or-more-installed-packages"></a><span data-ttu-id="3ff37-103">1 つ以上のインストール パッケージの展開情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="3ff37-103">Requests deployment information for one or more installed packages.</span></span>

**<span data-ttu-id="3ff37-104">要求</span><span class="sxs-lookup"><span data-stu-id="3ff37-104">Request</span></span>**

<span data-ttu-id="3ff37-105">メソッド</span><span class="sxs-lookup"><span data-stu-id="3ff37-105">Method</span></span>      | <span data-ttu-id="3ff37-106">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3ff37-106">Request URI</span></span>
:------     | :------
<span data-ttu-id="3ff37-107">POST</span><span class="sxs-lookup"><span data-stu-id="3ff37-107">POST</span></span> | <span data-ttu-id="3ff37-108">/ext/app/deployinfo</span><span class="sxs-lookup"><span data-stu-id="3ff37-108">/ext/app/deployinfo</span></span>
<br />
**<span data-ttu-id="3ff37-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3ff37-109">URI parameters</span></span>**

 - <span data-ttu-id="3ff37-110">なし</span><span class="sxs-lookup"><span data-stu-id="3ff37-110">None</span></span>

**<span data-ttu-id="3ff37-111">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3ff37-111">Request headers</span></span>**

- <span data-ttu-id="3ff37-112">なし</span><span class="sxs-lookup"><span data-stu-id="3ff37-112">None</span></span>

**<span data-ttu-id="3ff37-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="3ff37-113">Request body</span></span>**

<span data-ttu-id="3ff37-114">次の形式の JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="3ff37-114">A JSON array in the following format:</span></span>

* <span data-ttu-id="3ff37-115">DeployInfo</span><span class="sxs-lookup"><span data-stu-id="3ff37-115">DeployInfo</span></span>
  * <span data-ttu-id="3ff37-116">PackageFullName - 情報を要求するパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="3ff37-116">PackageFullName - Name of the package that we are requesting information about.</span></span>
  * <span data-ttu-id="3ff37-117">OverlayFolder - この機能を使用する場合の、オーバーレイ フォルダーのパスへのオプションのパス。</span><span class="sxs-lookup"><span data-stu-id="3ff37-117">OverlayFolder - Optional path to an overlay folder path if using this feature.</span></span>

###<a name="response"></a><span data-ttu-id="3ff37-118">応答</span><span class="sxs-lookup"><span data-stu-id="3ff37-118">Response</span></span>

**<span data-ttu-id="3ff37-119">応答本文</span><span class="sxs-lookup"><span data-stu-id="3ff37-119">Response body</span></span>**

<span data-ttu-id="3ff37-120">次の形式での JSON 配列 (一部のフィールドは省略可能)。</span><span class="sxs-lookup"><span data-stu-id="3ff37-120">A JSON array in the following format (some fields are optional):</span></span>

* <span data-ttu-id="3ff37-121">DeployInfo</span><span class="sxs-lookup"><span data-stu-id="3ff37-121">DeployInfo</span></span>
  * <span data-ttu-id="3ff37-122">PackageFullName - 情報を受け取るパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="3ff37-122">PackageFullName - Name of the package that we are receiving information about.</span></span>
  * <span data-ttu-id="3ff37-123">DeployType - 展開の種類。</span><span class="sxs-lookup"><span data-stu-id="3ff37-123">DeployType - The type of deployment.</span></span>
  * <span data-ttu-id="3ff37-124">DeployPathOrSpecifiers - ルーズ展開の展開パスまたはパッケージ化された展開のインストール済み指定子。</span><span class="sxs-lookup"><span data-stu-id="3ff37-124">DeployPathOrSpecifiers - A deploy path for loose deployments or installed specifiers for packaged deployments.</span></span>
  * <span data-ttu-id="3ff37-125">DeployDrive - 該当する展開の種類のパッケージが展開されているドライブです。</span><span class="sxs-lookup"><span data-stu-id="3ff37-125">DeployDrive - The drive the package is deployed to for applicable deployment types.</span></span>
  * <span data-ttu-id="3ff37-126">DeploySizeInBytes - 該当する展開の種類のパッケージのサイズ (バイト単位) です。</span><span class="sxs-lookup"><span data-stu-id="3ff37-126">DeploySizeInBytes - The size in bytes of the package for applicable deployment types.</span></span>
  * <span data-ttu-id="3ff37-127">OverlayFolder - この機能をサポートする展開のオーバーレイ フォルダーです。</span><span class="sxs-lookup"><span data-stu-id="3ff37-127">OverlayFolder - The overlay folder for deployments which support this feature.</span></span>

**<span data-ttu-id="3ff37-128">状態コード</span><span class="sxs-lookup"><span data-stu-id="3ff37-128">Status code</span></span>**

<span data-ttu-id="3ff37-129">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3ff37-129">This API has the following expected status codes.</span></span>

<span data-ttu-id="3ff37-130">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3ff37-130">HTTP status code</span></span>      | <span data-ttu-id="3ff37-131">説明</span><span class="sxs-lookup"><span data-stu-id="3ff37-131">Description</span></span>
:------     | :-----
<span data-ttu-id="3ff37-132">200</span><span class="sxs-lookup"><span data-stu-id="3ff37-132">200</span></span> | <span data-ttu-id="3ff37-133">成功</span><span class="sxs-lookup"><span data-stu-id="3ff37-133">Success</span></span>
<span data-ttu-id="3ff37-134">4XX</span><span class="sxs-lookup"><span data-stu-id="3ff37-134">4XX</span></span> | <span data-ttu-id="3ff37-135">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3ff37-135">Error codes</span></span>
<span data-ttu-id="3ff37-136">5XX</span><span class="sxs-lookup"><span data-stu-id="3ff37-136">5XX</span></span> | <span data-ttu-id="3ff37-137">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3ff37-137">Error codes</span></span>
<br />

**<span data-ttu-id="3ff37-138">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="3ff37-138">Available device families</span></span>**

* <span data-ttu-id="3ff37-139">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="3ff37-139">Windows Xbox</span></span>