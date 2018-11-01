---
title: /json/users/xuid({xuid})/scids/{scid}/data/{path}
assetID: c2745955-5e52-ea2b-7389-cb85202e01c3
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapath.html
author: KevinAsgari
description: " /json/users/xuid({xuid})/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: aed950c0b313d8e646529de42ed39ef41edfa3c8
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5876196"
---
# <a name="jsonusersxuidxuidscidssciddatapath"></a><span data-ttu-id="eecf6-104">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="eecf6-104">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="eecf6-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="eecf6-105">Lists file information at a specified path.</span></span> <span data-ttu-id="eecf6-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="eecf6-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="eecf6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="eecf6-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="eecf6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="eecf6-108">URI parameters</span></span>
 
| <span data-ttu-id="eecf6-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="eecf6-109">Parameter</span></span>| <span data-ttu-id="eecf6-110">型</span><span class="sxs-lookup"><span data-stu-id="eecf6-110">Type</span></span>| <span data-ttu-id="eecf6-111">説明</span><span class="sxs-lookup"><span data-stu-id="eecf6-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="eecf6-112">xuid</span><span class="sxs-lookup"><span data-stu-id="eecf6-112">xuid</span></span>| <span data-ttu-id="eecf6-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="eecf6-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="eecf6-114">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="eecf6-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="eecf6-115">scid</span><span class="sxs-lookup"><span data-stu-id="eecf6-115">scid</span></span>| <span data-ttu-id="eecf6-116">guid</span><span class="sxs-lookup"><span data-stu-id="eecf6-116">guid</span></span>| <span data-ttu-id="eecf6-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="eecf6-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="eecf6-118">path</span><span class="sxs-lookup"><span data-stu-id="eecf6-118">path</span></span>| <span data-ttu-id="eecf6-119">string</span><span class="sxs-lookup"><span data-stu-id="eecf6-119">string</span></span>| <span data-ttu-id="eecf6-120">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="eecf6-120">The path to the data items to return.</span></span> <span data-ttu-id="eecf6-121">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="eecf6-121">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="eecf6-122">有効な文字には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="eecf6-122">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="eecf6-123">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="eecf6-123">May be empty.</span></span> <span data-ttu-id="eecf6-124">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="eecf6-124">Max length of 256.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="eecf6-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="eecf6-125">Valid methods</span></span>

[<span data-ttu-id="eecf6-126">GET</span><span class="sxs-lookup"><span data-stu-id="eecf6-126">GET</span></span>](uri-jsonusersxuidscidssciddatapath-get.md)

<span data-ttu-id="eecf6-127">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="eecf6-127">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="eecf6-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="eecf6-128">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="eecf6-129">Parent</span><span class="sxs-lookup"><span data-stu-id="eecf6-129">Parent</span></span> 

[<span data-ttu-id="eecf6-130">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="eecf6-130">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   