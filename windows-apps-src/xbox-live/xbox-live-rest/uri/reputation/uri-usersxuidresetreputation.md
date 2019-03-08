---
title: /users/xuid({xuid})/resetreputation
assetID: 85c74beb-a12f-4015-e244-36942e366afc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidresetreputation.html
description: " /users/xuid({xuid})/resetreputation"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c6cd2f28833cdc86fb3fd01bb85890dcb0654901
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607527"
---
# <a name="usersxuidxuidresetreputation"></a><span data-ttu-id="166ec-104">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="166ec-104">/users/xuid({xuid})/resetreputation</span></span>
<span data-ttu-id="166ec-105">指定したユーザーの評価スコアにアクセスする強制チームを有効にします。</span><span class="sxs-lookup"><span data-stu-id="166ec-105">Enables the Enforcement team to access the specified user's Reputation scores.</span></span> <span data-ttu-id="166ec-106">これらの Uri のドメインとポート番号が`reputation.xboxlive.com:10433`します。</span><span class="sxs-lookup"><span data-stu-id="166ec-106">The domain and port number for these URIs is `reputation.xboxlive.com:10433`.</span></span>
 
  * [<span data-ttu-id="166ec-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="166ec-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="166ec-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="166ec-108">URI parameters</span></span>
 
| <span data-ttu-id="166ec-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="166ec-109">Parameter</span></span>| <span data-ttu-id="166ec-110">種類</span><span class="sxs-lookup"><span data-stu-id="166ec-110">Type</span></span>| <span data-ttu-id="166ec-111">説明</span><span class="sxs-lookup"><span data-stu-id="166ec-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="166ec-112">xuid</span><span class="sxs-lookup"><span data-stu-id="166ec-112">xuid</span></span>| <span data-ttu-id="166ec-113">string</span><span class="sxs-lookup"><span data-stu-id="166ec-113">string</span></span>| <span data-ttu-id="166ec-114">Xbox ユーザー ID (XUID) の指定したユーザー。</span><span class="sxs-lookup"><span data-stu-id="166ec-114">The Xbox User ID (XUID) of the specified user.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="166ec-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="166ec-115">Valid methods</span></span>

[<span data-ttu-id="166ec-116">POST (/users/xuid({xuid})/resetreputation)</span><span class="sxs-lookup"><span data-stu-id="166ec-116">POST (/users/xuid({xuid})/resetreputation)</span></span>](uri-usersxuidresetreputationpost.md)

<span data-ttu-id="166ec-117">&nbsp;&nbsp;強制チーム アカウント ハイジャックでは (たとえば) 後、指定したユーザーの評価スコアをいくつかの任意の値に設定を有効にします。</span><span class="sxs-lookup"><span data-stu-id="166ec-117">&nbsp;&nbsp;Enables the Enforcement team to set the specified user's Reputation Scores to some arbitrary values after (for example) an account hijacking.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="166ec-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="166ec-118">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="166ec-119">Parent</span><span class="sxs-lookup"><span data-stu-id="166ec-119">Parent</span></span> 

[<span data-ttu-id="166ec-120">評価の Uri</span><span class="sxs-lookup"><span data-stu-id="166ec-120">Reputation URIs</span></span>](atoc-reference-reputation.md)

   