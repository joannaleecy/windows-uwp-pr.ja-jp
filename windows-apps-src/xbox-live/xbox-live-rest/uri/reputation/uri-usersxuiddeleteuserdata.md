---
title: /users/xuid({xuid})/deleteuserdata
assetID: 1925da6f-f6c1-ae5b-5af9-e143b70e6717
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddeleteuserdata.html
author: KevinAsgari
description: " /users/xuid({xuid})/deleteuserdata"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fe1129db6154d842cbadf0e7918d2fe460166ba1
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4051619"
---
# <a name="usersxuidxuiddeleteuserdata"></a><span data-ttu-id="21f4b-104">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="21f4b-104">/users/xuid({xuid})/deleteuserdata</span></span>
<span data-ttu-id="21f4b-105">テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="21f4b-105">Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="21f4b-106">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="21f4b-106">For testing only.</span></span> <span data-ttu-id="21f4b-107">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="21f4b-107">The domain for these URIs is `reputation.xboxlive.com`.</span></span> <span data-ttu-id="21f4b-108">この URI は、常にポート 10443 で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="21f4b-108">This URI is always called on port 10443.</span></span>
 
  * [<span data-ttu-id="21f4b-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21f4b-109">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="21f4b-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="21f4b-110">URI parameters</span></span>
 
| <span data-ttu-id="21f4b-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="21f4b-111">Parameter</span></span>| <span data-ttu-id="21f4b-112">型</span><span class="sxs-lookup"><span data-stu-id="21f4b-112">Type</span></span>| <span data-ttu-id="21f4b-113">説明</span><span class="sxs-lookup"><span data-stu-id="21f4b-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="21f4b-114">xuid</span><span class="sxs-lookup"><span data-stu-id="21f4b-114">xuid</span></span>| <span data-ttu-id="21f4b-115">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="21f4b-115">64-bit unsigned integer</span></span>| <span data-ttu-id="21f4b-116">Xbox ユーザー ID (XUID)、ユーザーがデータが削除されるのです。</span><span class="sxs-lookup"><span data-stu-id="21f4b-116">Xbox User ID (XUID) of the user whose data is being deleted.</span></span>| 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="21f4b-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="21f4b-117">Valid methods</span></span>

[<span data-ttu-id="21f4b-118">POST (/users/xuid({xuid})/deleteuserdata)</span><span class="sxs-lookup"><span data-stu-id="21f4b-118">POST (/users/xuid({xuid})/deleteuserdata)</span></span>](uri-usersxuiddeleteuserdatapost.md)

<span data-ttu-id="21f4b-119">&nbsp;&nbsp;テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="21f4b-119">&nbsp;&nbsp;Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="21f4b-120">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="21f4b-120">For testing only.</span></span>
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="21f4b-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="21f4b-121">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="21f4b-122">Parent</span><span class="sxs-lookup"><span data-stu-id="21f4b-122">Parent</span></span> 

[<span data-ttu-id="21f4b-123">評判 URI</span><span class="sxs-lookup"><span data-stu-id="21f4b-123">Reputation URIs</span></span>](atoc-reference-reputation.md)

   