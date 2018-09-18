---
title: /global/scids/{scid}/data/{path}
assetID: d6353cd3-9127-98d4-bb99-5df690e07022
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapath.html
author: KevinAsgari
description: " /global/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b091f3bbb5e03808d04a255b204c13eee93f7fdb
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4017647"
---
# <a name="globalscidssciddatapath"></a><span data-ttu-id="23146-104">/global/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="23146-104">/global/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="23146-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="23146-105">Lists file information at a specified path.</span></span> <span data-ttu-id="23146-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="23146-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="23146-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="23146-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="23146-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="23146-108">URI parameters</span></span>
 
| <span data-ttu-id="23146-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="23146-109">Parameter</span></span>| <span data-ttu-id="23146-110">型</span><span class="sxs-lookup"><span data-stu-id="23146-110">Type</span></span>| <span data-ttu-id="23146-111">説明</span><span class="sxs-lookup"><span data-stu-id="23146-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="23146-112">scid</span><span class="sxs-lookup"><span data-stu-id="23146-112">scid</span></span>| <span data-ttu-id="23146-113">guid</span><span class="sxs-lookup"><span data-stu-id="23146-113">guid</span></span>| <span data-ttu-id="23146-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="23146-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="23146-115">path</span><span class="sxs-lookup"><span data-stu-id="23146-115">path</span></span>| <span data-ttu-id="23146-116">string</span><span class="sxs-lookup"><span data-stu-id="23146-116">string</span></span>| <span data-ttu-id="23146-117">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="23146-117">The path to the data items to return.</span></span> <span data-ttu-id="23146-118">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="23146-118">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="23146-119">有効な文字には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23146-119">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="23146-120">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="23146-120">May be empty.</span></span> <span data-ttu-id="23146-121">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="23146-121">Max length of 256.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="23146-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="23146-122">Valid methods</span></span>

[<span data-ttu-id="23146-123">GET</span><span class="sxs-lookup"><span data-stu-id="23146-123">GET</span></span>](uri-globalscidssciddatapath-get.md)

<span data-ttu-id="23146-124">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="23146-124">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="23146-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="23146-125">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="23146-126">Parent</span><span class="sxs-lookup"><span data-stu-id="23146-126">Parent</span></span> 

[<span data-ttu-id="23146-127">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="23146-127">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   