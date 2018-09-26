---
title: /sessions/{sessionId}/scids/{scid}/data/{path}
assetID: 932459b4-24b4-5b09-8146-ed214de0083a
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapath.html
author: KevinAsgari
description: " /sessions/{sessionId}/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8d6089bd7d758dffb75759ca2f079ee944dcb692
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4209547"
---
# <a name="sessionssessionidscidssciddatapath"></a><span data-ttu-id="234f9-104">/sessions/{sessionId}/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="234f9-104">/sessions/{sessionId}/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="234f9-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="234f9-105">Lists file information at a specified path.</span></span> <span data-ttu-id="234f9-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="234f9-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="234f9-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="234f9-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="234f9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="234f9-108">URI parameters</span></span>
 
| <span data-ttu-id="234f9-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="234f9-109">Parameter</span></span>| <span data-ttu-id="234f9-110">型</span><span class="sxs-lookup"><span data-stu-id="234f9-110">Type</span></span>| <span data-ttu-id="234f9-111">説明</span><span class="sxs-lookup"><span data-stu-id="234f9-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="234f9-112">sessionId</span><span class="sxs-lookup"><span data-stu-id="234f9-112">sessionId</span></span>| <span data-ttu-id="234f9-113">string</span><span class="sxs-lookup"><span data-stu-id="234f9-113">string</span></span>| <span data-ttu-id="234f9-114">検索するセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="234f9-114">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="234f9-115">scid</span><span class="sxs-lookup"><span data-stu-id="234f9-115">scid</span></span>| <span data-ttu-id="234f9-116">guid</span><span class="sxs-lookup"><span data-stu-id="234f9-116">guid</span></span>| <span data-ttu-id="234f9-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="234f9-117">The ID of the service config to look up.</span></span>| 
| <span data-ttu-id="234f9-118">path</span><span class="sxs-lookup"><span data-stu-id="234f9-118">path</span></span>| <span data-ttu-id="234f9-119">string</span><span class="sxs-lookup"><span data-stu-id="234f9-119">string</span></span>| <span data-ttu-id="234f9-120">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="234f9-120">The path to the data items to return.</span></span> <span data-ttu-id="234f9-121">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="234f9-121">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="234f9-122">有効な文字には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="234f9-122">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="234f9-123">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="234f9-123">May be empty.</span></span> <span data-ttu-id="234f9-124">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="234f9-124">Max length of 256.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="234f9-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="234f9-125">Valid methods</span></span>

[<span data-ttu-id="234f9-126">GET</span><span class="sxs-lookup"><span data-stu-id="234f9-126">GET</span></span>](uri-sessionssessionidscidssciddatapath-get.md)

<span data-ttu-id="234f9-127">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="234f9-127">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="234f9-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="234f9-128">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="234f9-129">Parent</span><span class="sxs-lookup"><span data-stu-id="234f9-129">Parent</span></span> 

[<span data-ttu-id="234f9-130">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="234f9-130">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   