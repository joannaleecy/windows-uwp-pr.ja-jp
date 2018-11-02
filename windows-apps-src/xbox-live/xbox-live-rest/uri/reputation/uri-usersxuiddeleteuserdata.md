---
title: /users/xuid({xuid})/deleteuserdata
assetID: 1925da6f-f6c1-ae5b-5af9-e143b70e6717
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddeleteuserdata.html
author: KevinAsgari
description: " /users/xuid({xuid})/deleteuserdata"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5eaba6a02fa2ebb00ef4861a5bf37963796b78b5
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5930803"
---
# <a name="usersxuidxuiddeleteuserdata"></a><span data-ttu-id="2dd40-104">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="2dd40-104">/users/xuid({xuid})/deleteuserdata</span></span>
<span data-ttu-id="2dd40-105">テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="2dd40-105">Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="2dd40-106">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="2dd40-106">For testing only.</span></span> <span data-ttu-id="2dd40-107">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2dd40-107">The domain for these URIs is `reputation.xboxlive.com`.</span></span> <span data-ttu-id="2dd40-108">この URI は、常にポート 10443 で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="2dd40-108">This URI is always called on port 10443.</span></span>
 
  * [<span data-ttu-id="2dd40-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2dd40-109">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2dd40-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2dd40-110">URI parameters</span></span>
 
| <span data-ttu-id="2dd40-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2dd40-111">Parameter</span></span>| <span data-ttu-id="2dd40-112">型</span><span class="sxs-lookup"><span data-stu-id="2dd40-112">Type</span></span>| <span data-ttu-id="2dd40-113">説明</span><span class="sxs-lookup"><span data-stu-id="2dd40-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2dd40-114">xuid</span><span class="sxs-lookup"><span data-stu-id="2dd40-114">xuid</span></span>| <span data-ttu-id="2dd40-115">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="2dd40-115">64-bit unsigned integer</span></span>| <span data-ttu-id="2dd40-116">Xbox ユーザー ID (XUID)、ユーザーがデータを削除しています。</span><span class="sxs-lookup"><span data-stu-id="2dd40-116">Xbox User ID (XUID) of the user whose data is being deleted.</span></span>| 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="2dd40-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="2dd40-117">Valid methods</span></span>

[<span data-ttu-id="2dd40-118">POST (/users/xuid({xuid})/deleteuserdata)</span><span class="sxs-lookup"><span data-stu-id="2dd40-118">POST (/users/xuid({xuid})/deleteuserdata)</span></span>](uri-usersxuiddeleteuserdatapost.md)

<span data-ttu-id="2dd40-119">&nbsp;&nbsp;テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="2dd40-119">&nbsp;&nbsp;Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="2dd40-120">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="2dd40-120">For testing only.</span></span>
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="2dd40-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="2dd40-121">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2dd40-122">Parent</span><span class="sxs-lookup"><span data-stu-id="2dd40-122">Parent</span></span> 

[<span data-ttu-id="2dd40-123">評判 URI</span><span class="sxs-lookup"><span data-stu-id="2dd40-123">Reputation URIs</span></span>](atoc-reference-reputation.md)

   