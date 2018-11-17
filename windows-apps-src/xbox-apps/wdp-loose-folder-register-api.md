---
author: WilliamsJason
title: Device Portal のルース フォルダー登録 API のリファレンス
description: ルース フォルダー登録 API にプログラムでアクセスする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: efdf4214-9738-4df6-bf1f-ed7141696ef6
ms.localizationpriority: medium
ms.openlocfilehash: cb80e2dbd7ebdfbb05bd642b9875a9cd7cc356f3
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7153625"
---
# <a name="register-an-app-in-a-loose-folder"></a><span data-ttu-id="5926f-104">アプリをルース フォルダーに登録する</span><span class="sxs-lookup"><span data-stu-id="5926f-104">Register an app in a loose folder</span></span>  

**<span data-ttu-id="5926f-105">要求</span><span class="sxs-lookup"><span data-stu-id="5926f-105">Request</span></span>**

<span data-ttu-id="5926f-106">次の要求形式を使用して、アプリをルース フォルダーに登録できます。</span><span class="sxs-lookup"><span data-stu-id="5926f-106">You can register an app in a loose folder by using the following request format.</span></span>

<span data-ttu-id="5926f-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="5926f-107">Method</span></span>      | <span data-ttu-id="5926f-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="5926f-108">Request URI</span></span>
:------     | :------
<span data-ttu-id="5926f-109">POST</span><span class="sxs-lookup"><span data-stu-id="5926f-109">POST</span></span> | <span data-ttu-id="5926f-110">/api/app/packagemanager/register</span><span class="sxs-lookup"><span data-stu-id="5926f-110">/api/app/packagemanager/register</span></span>
<br />
**<span data-ttu-id="5926f-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5926f-111">URI parameters</span></span>**

<span data-ttu-id="5926f-112">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="5926f-112">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="5926f-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5926f-113">URI Parameter</span></span>      | <span data-ttu-id="5926f-114">説明</span><span class="sxs-lookup"><span data-stu-id="5926f-114">Description</span></span>
:------     | :-----
<span data-ttu-id="5926f-115">folder (必須)</span><span class="sxs-lookup"><span data-stu-id="5926f-115">folder (required)</span></span> | <span data-ttu-id="5926f-116">登録するパッケージのターゲット フォルダー名です。</span><span class="sxs-lookup"><span data-stu-id="5926f-116">The destination folder name of the package to be registered.</span></span> <span data-ttu-id="5926f-117">このフォルダーは、本体の d:\developmentfiles\LooseApps の下に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5926f-117">This folder must exist under d:\developmentfiles\LooseApps on the console.</span></span> <span data-ttu-id="5926f-118">フォルダーが LooseApps の下のサブフォルダーである場合、フォルダー名にパスの区切り文字が含まれる可能性があるため、このフォルダー名は base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="5926f-118">This folder name should be base64 encoded as it may contain path separators if the folder is in a subfolder under LooseApps.</span></span>
<br />

**<span data-ttu-id="5926f-119">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5926f-119">Request headers</span></span>**

- <span data-ttu-id="5926f-120">なし</span><span class="sxs-lookup"><span data-stu-id="5926f-120">None</span></span>

**<span data-ttu-id="5926f-121">要求本文</span><span class="sxs-lookup"><span data-stu-id="5926f-121">Request body</span></span>**

- <span data-ttu-id="5926f-122">なし</span><span class="sxs-lookup"><span data-stu-id="5926f-122">None</span></span>

**<span data-ttu-id="5926f-123">応答</span><span class="sxs-lookup"><span data-stu-id="5926f-123">Response</span></span>**

**<span data-ttu-id="5926f-124">状態コード</span><span class="sxs-lookup"><span data-stu-id="5926f-124">Status code</span></span>**

<span data-ttu-id="5926f-125">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5926f-125">This API has the following expected status codes.</span></span>

<span data-ttu-id="5926f-126">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5926f-126">HTTP status code</span></span>      | <span data-ttu-id="5926f-127">説明</span><span class="sxs-lookup"><span data-stu-id="5926f-127">Description</span></span>
:------     | :-----
<span data-ttu-id="5926f-128">200</span><span class="sxs-lookup"><span data-stu-id="5926f-128">200</span></span> | <span data-ttu-id="5926f-129">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="5926f-129">Deploy request accepted and being processed</span></span>
<span data-ttu-id="5926f-130">4XX</span><span class="sxs-lookup"><span data-stu-id="5926f-130">4XX</span></span> | <span data-ttu-id="5926f-131">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5926f-131">Error codes</span></span>
<span data-ttu-id="5926f-132">5XX</span><span class="sxs-lookup"><span data-stu-id="5926f-132">5XX</span></span> | <span data-ttu-id="5926f-133">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5926f-133">Error codes</span></span>
<br />
**<span data-ttu-id="5926f-134">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="5926f-134">Available device families</span></span>**

* <span data-ttu-id="5926f-135">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="5926f-135">Windows Xbox</span></span>

**<span data-ttu-id="5926f-136">コメント</span><span class="sxs-lookup"><span data-stu-id="5926f-136">Notes</span></span>**

<span data-ttu-id="5926f-137">目的のフォルダーで本体のルース アプリを入手する方法は少なくとも 3 つあります。</span><span class="sxs-lookup"><span data-stu-id="5926f-137">There are at least three different ways to get the loose app on the console in the desired folder.</span></span> <span data-ttu-id="5926f-138">最も簡単な方法は、SMB を通じてファイルを \\<IP アドレス>\DevelopmentFiles\LooseApps にコピーする方法です。</span><span class="sxs-lookup"><span data-stu-id="5926f-138">The easiest is to simply copy the files via SMB to \\<IP_Address>\DevelopmentFiles\LooseApps.</span></span> <span data-ttu-id="5926f-139">これには、[/ext/smb/developerfolder](wdp-smb-api.md) を使って取得できる UWA キットのユーザー名とパスワードが必要です。</span><span class="sxs-lookup"><span data-stu-id="5926f-139">This will require a username and password on UWA kits which can be obtained via [/ext/smb/developerfolder](wdp-smb-api.md).</span></span> 

<span data-ttu-id="5926f-140">2 つ目の方法は、/api/filesystem/apps/file に対して POST を実行することで、個々のファイルを適切な場所にコピーする方法です。この場合、knownfolderid には DevelopmentFiles を指定し、packagefullname は空にして、ファイル名とパスを適切に提供します (パスは LooseApps で始まっている必要があります)。</span><span class="sxs-lookup"><span data-stu-id="5926f-140">The second way is by copying over individual files to the correct location by doing a POST to /api/filesystem/apps/file where knownfolderid is DevelopmentFiles, packagefullname is empty, and filename and path are properly supplied (path should begin with LooseApps).</span></span>

<span data-ttu-id="5926f-141">3 つ目の方法は、[/api/app/packagemanager/upload](wdp-folder-upload.md) を使ってフォルダー全体を一度にコピーする方法です。この場合、destinationFolder には d:\developmentfiles\looseapps の下に配置されるフォルダーの名前を指定し、ペイロードはディレクトリ コンテンツの原則に従ったマルチパートの http 本文になります。</span><span class="sxs-lookup"><span data-stu-id="5926f-141">The third way is to copy an entire folder at a time via [/api/app/packagemanager/upload](wdp-folder-upload.md) where destinationFolder is the name of the folder to be placed under d:\developmentfiles\looseapps and the payload is a multi-part conforming http body of the directory contents.</span></span>

