---
title: /users/xuid({xuid})/deleteuserdata
assetID: 1925da6f-f6c1-ae5b-5af9-e143b70e6717
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddeleteuserdata.html
description: " /users/xuid({xuid})/deleteuserdata"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: efcf214c366edb891e13301da0eedbc87627ca79
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617467"
---
# <a name="usersxuidxuiddeleteuserdata"></a><span data-ttu-id="9c89b-104">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="9c89b-104">/users/xuid({xuid})/deleteuserdata</span></span>
<span data-ttu-id="9c89b-105">テスト ユーザーの評価データを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="9c89b-105">Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="9c89b-106">テスト目的専用です。</span><span class="sxs-lookup"><span data-stu-id="9c89b-106">For testing only.</span></span> <span data-ttu-id="9c89b-107">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9c89b-107">The domain for these URIs is `reputation.xboxlive.com`.</span></span> <span data-ttu-id="9c89b-108">この URI は常にポート 10443 で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="9c89b-108">This URI is always called on port 10443.</span></span>
 
  * [<span data-ttu-id="9c89b-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9c89b-109">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9c89b-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9c89b-110">URI parameters</span></span>
 
| <span data-ttu-id="9c89b-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9c89b-111">Parameter</span></span>| <span data-ttu-id="9c89b-112">種類</span><span class="sxs-lookup"><span data-stu-id="9c89b-112">Type</span></span>| <span data-ttu-id="9c89b-113">説明</span><span class="sxs-lookup"><span data-stu-id="9c89b-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9c89b-114">xuid</span><span class="sxs-lookup"><span data-stu-id="9c89b-114">xuid</span></span>| <span data-ttu-id="9c89b-115">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9c89b-115">64-bit unsigned integer</span></span>| <span data-ttu-id="9c89b-116">Xbox ユーザー ID (XUID) のデータが削除されるユーザーです。</span><span class="sxs-lookup"><span data-stu-id="9c89b-116">Xbox User ID (XUID) of the user whose data is being deleted.</span></span>| 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="9c89b-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9c89b-117">Valid methods</span></span>

[<span data-ttu-id="9c89b-118">POST (/users/xuid({xuid})/deleteuserdata)</span><span class="sxs-lookup"><span data-stu-id="9c89b-118">POST (/users/xuid({xuid})/deleteuserdata)</span></span>](uri-usersxuiddeleteuserdatapost.md)

<span data-ttu-id="9c89b-119">&nbsp;&nbsp;テスト ユーザーの評価データを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="9c89b-119">&nbsp;&nbsp;Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="9c89b-120">テスト目的専用です。</span><span class="sxs-lookup"><span data-stu-id="9c89b-120">For testing only.</span></span>
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9c89b-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="9c89b-121">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9c89b-122">Parent</span><span class="sxs-lookup"><span data-stu-id="9c89b-122">Parent</span></span> 

[<span data-ttu-id="9c89b-123">評価の Uri</span><span class="sxs-lookup"><span data-stu-id="9c89b-123">Reputation URIs</span></span>](atoc-reference-reputation.md)

   