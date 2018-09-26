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
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4207197"
---
# <a name="usersxuidxuiddeleteuserdata"></a><span data-ttu-id="c1289-104">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="c1289-104">/users/xuid({xuid})/deleteuserdata</span></span>
<span data-ttu-id="c1289-105">テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="c1289-105">Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="c1289-106">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="c1289-106">For testing only.</span></span> <span data-ttu-id="c1289-107">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c1289-107">The domain for these URIs is `reputation.xboxlive.com`.</span></span> <span data-ttu-id="c1289-108">この URI は、常にポート 10443 で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c1289-108">This URI is always called on port 10443.</span></span>
 
  * [<span data-ttu-id="c1289-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c1289-109">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c1289-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c1289-110">URI parameters</span></span>
 
| <span data-ttu-id="c1289-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c1289-111">Parameter</span></span>| <span data-ttu-id="c1289-112">型</span><span class="sxs-lookup"><span data-stu-id="c1289-112">Type</span></span>| <span data-ttu-id="c1289-113">説明</span><span class="sxs-lookup"><span data-stu-id="c1289-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c1289-114">xuid</span><span class="sxs-lookup"><span data-stu-id="c1289-114">xuid</span></span>| <span data-ttu-id="c1289-115">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c1289-115">64-bit unsigned integer</span></span>| <span data-ttu-id="c1289-116">Xbox ユーザー ID (XUID)、ユーザーがデータが削除されるのです。</span><span class="sxs-lookup"><span data-stu-id="c1289-116">Xbox User ID (XUID) of the user whose data is being deleted.</span></span>| 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="c1289-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="c1289-117">Valid methods</span></span>

[<span data-ttu-id="c1289-118">POST (/users/xuid({xuid})/deleteuserdata)</span><span class="sxs-lookup"><span data-stu-id="c1289-118">POST (/users/xuid({xuid})/deleteuserdata)</span></span>](uri-usersxuiddeleteuserdatapost.md)

<span data-ttu-id="c1289-119">&nbsp;&nbsp;テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="c1289-119">&nbsp;&nbsp;Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="c1289-120">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="c1289-120">For testing only.</span></span>
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c1289-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="c1289-121">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c1289-122">Parent</span><span class="sxs-lookup"><span data-stu-id="c1289-122">Parent</span></span> 

[<span data-ttu-id="c1289-123">評判 URI</span><span class="sxs-lookup"><span data-stu-id="c1289-123">Reputation URIs</span></span>](atoc-reference-reputation.md)

   