---
title: /users/xuid({xuid})/outbox
assetID: 0b66b885-15ff-be55-f8be-e6e9d85d087e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidoutbox.html
author: KevinAsgari
description: " /users/xuid({xuid})/outbox"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a10fbb4b2008a3c953d101111d064c6f06491e10
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7165128"
---
# <a name="usersxuidxuidoutbox"></a><span data-ttu-id="bac03-104">/users/xuid({xuid})/outbox</span><span class="sxs-lookup"><span data-stu-id="bac03-104">/users/xuid({xuid})/outbox</span></span>
<span data-ttu-id="bac03-105">ユーザーに送信専用アクセスが許可のメッセージは、Xbox LIVE サービスのトレイします。</span><span class="sxs-lookup"><span data-stu-id="bac03-105">Provides send-only access to a user's messaging outbox for Xbox LIVE Services.</span></span> <span data-ttu-id="bac03-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bac03-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bac03-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bac03-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bac03-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bac03-108">URI parameters</span></span> 
 
| <span data-ttu-id="bac03-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bac03-109">Parameter</span></span>| <span data-ttu-id="bac03-110">型</span><span class="sxs-lookup"><span data-stu-id="bac03-110">Type</span></span>| <span data-ttu-id="bac03-111">説明</span><span class="sxs-lookup"><span data-stu-id="bac03-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bac03-112">xuid</span><span class="sxs-lookup"><span data-stu-id="bac03-112">xuid</span></span> | <span data-ttu-id="bac03-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bac03-113">unsigned 64-bit integer</span></span> | <span data-ttu-id="bac03-114">Xbox ユーザー ID (XUID) 要求を行っているプレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="bac03-114">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
  
<a id="ID4EXB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="bac03-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="bac03-115">Valid methods</span></span> 

[<span data-ttu-id="bac03-116">POST (/users/xuid({xuid})/outbox)</span><span class="sxs-lookup"><span data-stu-id="bac03-116">POST (/users/xuid({xuid})/outbox)</span></span>](uri-usersxuidoutboxpost.md)

<span data-ttu-id="bac03-117">&nbsp;&nbsp;受信者の一覧を指定されたメッセージを送信します。</span><span class="sxs-lookup"><span data-stu-id="bac03-117">&nbsp;&nbsp;Sends a specified message to a list of recipients.</span></span> 
 
<a id="ID4EFC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bac03-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="bac03-118">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bac03-119">Parent</span><span class="sxs-lookup"><span data-stu-id="bac03-119">Parent</span></span>  

[<span data-ttu-id="bac03-120">ユーザー URI</span><span class="sxs-lookup"><span data-stu-id="bac03-120">Users URIs</span></span>](atoc-reference-users.md)

   