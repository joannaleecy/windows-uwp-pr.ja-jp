---
title: /global/scids/{scid}/data/{path}
assetID: d6353cd3-9127-98d4-bb99-5df690e07022
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapath.html
description: " /global/scids/{scid}/data/{path}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b8788ae6773c53c2f86b3f51ee9023876416feeb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618867"
---
# <a name="globalscidssciddatapath"></a><span data-ttu-id="b411f-104">/global/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="b411f-104">/global/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="b411f-105">指定されたパスにファイル情報を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="b411f-105">Lists file information at a specified path.</span></span> <span data-ttu-id="b411f-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b411f-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b411f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b411f-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b411f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b411f-108">URI parameters</span></span>
 
| <span data-ttu-id="b411f-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b411f-109">Parameter</span></span>| <span data-ttu-id="b411f-110">種類</span><span class="sxs-lookup"><span data-stu-id="b411f-110">Type</span></span>| <span data-ttu-id="b411f-111">説明</span><span class="sxs-lookup"><span data-stu-id="b411f-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b411f-112">scid</span><span class="sxs-lookup"><span data-stu-id="b411f-112">scid</span></span>| <span data-ttu-id="b411f-113">guid</span><span class="sxs-lookup"><span data-stu-id="b411f-113">guid</span></span>| <span data-ttu-id="b411f-114">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="b411f-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="b411f-115">パス</span><span class="sxs-lookup"><span data-stu-id="b411f-115">path</span></span>| <span data-ttu-id="b411f-116">string</span><span class="sxs-lookup"><span data-stu-id="b411f-116">string</span></span>| <span data-ttu-id="b411f-117">返されるデータのアイテムへのパス。</span><span class="sxs-lookup"><span data-stu-id="b411f-117">The path to the data items to return.</span></span> <span data-ttu-id="b411f-118">一致するすべてのディレクトリとサブディレクトリが返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="b411f-118">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="b411f-119">有効な文字には、大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_) およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b411f-119">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="b411f-120">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="b411f-120">May be empty.</span></span> <span data-ttu-id="b411f-121">最大長は 256 です。</span><span class="sxs-lookup"><span data-stu-id="b411f-121">Max length of 256.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b411f-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b411f-122">Valid methods</span></span>

[<span data-ttu-id="b411f-123">取得</span><span class="sxs-lookup"><span data-stu-id="b411f-123">GET</span></span>](uri-globalscidssciddatapath-get.md)

<span data-ttu-id="b411f-124">&nbsp;&nbsp;指定されたパスにファイル情報を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="b411f-124">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b411f-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="b411f-125">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b411f-126">Parent</span><span class="sxs-lookup"><span data-stu-id="b411f-126">Parent</span></span> 

[<span data-ttu-id="b411f-127">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="b411f-127">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   