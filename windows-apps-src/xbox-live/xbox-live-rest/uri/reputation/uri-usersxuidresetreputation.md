---
title: /users/xuid({xuid})/resetreputation
assetID: 85c74beb-a12f-4015-e244-36942e366afc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidresetreputation.html
author: KevinAsgari
description: " /users/xuid({xuid})/resetreputation"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f9cc70b51809b1722db875580d6a9ad60c15acf0
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4085380"
---
# <a name="usersxuidxuidresetreputation"></a><span data-ttu-id="e68b2-104">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="e68b2-104">/users/xuid({xuid})/resetreputation</span></span>
<span data-ttu-id="e68b2-105">指定したユーザーの評判スコアにアクセスするために執行チームを使用できます。</span><span class="sxs-lookup"><span data-stu-id="e68b2-105">Enables the Enforcement team to access the specified user's Reputation scores.</span></span> <span data-ttu-id="e68b2-106">これらの Uri のドメインとポート番号を`reputation.xboxlive.com:10433`します。</span><span class="sxs-lookup"><span data-stu-id="e68b2-106">The domain and port number for these URIs is `reputation.xboxlive.com:10433`.</span></span>
 
  * [<span data-ttu-id="e68b2-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e68b2-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e68b2-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e68b2-108">URI parameters</span></span>
 
| <span data-ttu-id="e68b2-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e68b2-109">Parameter</span></span>| <span data-ttu-id="e68b2-110">型</span><span class="sxs-lookup"><span data-stu-id="e68b2-110">Type</span></span>| <span data-ttu-id="e68b2-111">説明</span><span class="sxs-lookup"><span data-stu-id="e68b2-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e68b2-112">xuid</span><span class="sxs-lookup"><span data-stu-id="e68b2-112">xuid</span></span>| <span data-ttu-id="e68b2-113">string</span><span class="sxs-lookup"><span data-stu-id="e68b2-113">string</span></span>| <span data-ttu-id="e68b2-114">Xbox ユーザー ID (XUID) の指定したユーザーです。</span><span class="sxs-lookup"><span data-stu-id="e68b2-114">The Xbox User ID (XUID) of the specified user.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e68b2-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e68b2-115">Valid methods</span></span>

[<span data-ttu-id="e68b2-116">POST (/users/xuid({xuid})/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="e68b2-116">POST (/users/xuid({xuid})/resetreputation)</span></span>](uri-usersxuidresetreputationpost.md)

<span data-ttu-id="e68b2-117">&nbsp;&nbsp;により、実施チームは、アカウント ハイジャック (たとえば) したら、任意の値をいくつかを指定したユーザーの評判スコアを設定します。</span><span class="sxs-lookup"><span data-stu-id="e68b2-117">&nbsp;&nbsp;Enables the Enforcement team to set the specified user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="e68b2-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="e68b2-118">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e68b2-119">Parent</span><span class="sxs-lookup"><span data-stu-id="e68b2-119">Parent</span></span> 

[<span data-ttu-id="e68b2-120">評判 URI</span><span class="sxs-lookup"><span data-stu-id="e68b2-120">Reputation URIs</span></span>](atoc-reference-reputation.md)

   