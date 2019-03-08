---
title: /users/xuid({xuid})/outbox
assetID: 0b66b885-15ff-be55-f8be-e6e9d85d087e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidoutbox.html
description: " /users/xuid({xuid})/outbox"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 88f3f3753aeac99db0a8a53e0a2ddde21d034ac5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607547"
---
# <a name="usersxuidxuidoutbox"></a><span data-ttu-id="78116-104">/users/xuid({xuid})/outbox</span><span class="sxs-lookup"><span data-stu-id="78116-104">/users/xuid({xuid})/outbox</span></span>
<span data-ttu-id="78116-105">ユーザーに送信専用のアクセスのメッセージングを提供します。 Xbox LIVE サービスに送信トレイです。</span><span class="sxs-lookup"><span data-stu-id="78116-105">Provides send-only access to a user's messaging outbox for Xbox LIVE Services.</span></span> <span data-ttu-id="78116-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="78116-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="78116-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="78116-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="78116-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="78116-108">URI parameters</span></span> 
 
| <span data-ttu-id="78116-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="78116-109">Parameter</span></span>| <span data-ttu-id="78116-110">種類</span><span class="sxs-lookup"><span data-stu-id="78116-110">Type</span></span>| <span data-ttu-id="78116-111">説明</span><span class="sxs-lookup"><span data-stu-id="78116-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="78116-112">xuid</span><span class="sxs-lookup"><span data-stu-id="78116-112">xuid</span></span> | <span data-ttu-id="78116-113">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="78116-113">unsigned 64-bit integer</span></span> | <span data-ttu-id="78116-114">Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。</span><span class="sxs-lookup"><span data-stu-id="78116-114">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
  
<a id="ID4EXB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="78116-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="78116-115">Valid methods</span></span> 

[<span data-ttu-id="78116-116">POST (/users/xuid({xuid})/outbox)</span><span class="sxs-lookup"><span data-stu-id="78116-116">POST (/users/xuid({xuid})/outbox)</span></span>](uri-usersxuidoutboxpost.md)

<span data-ttu-id="78116-117">&nbsp;&nbsp;受信者の一覧を指定したメッセージを送信します。</span><span class="sxs-lookup"><span data-stu-id="78116-117">&nbsp;&nbsp;Sends a specified message to a list of recipients.</span></span> 
 
<a id="ID4EFC"></a>

 
## <a name="see-also"></a><span data-ttu-id="78116-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="78116-118">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="78116-119">Parent</span><span class="sxs-lookup"><span data-stu-id="78116-119">Parent</span></span>  

[<span data-ttu-id="78116-120">ユーザーの Uri</span><span class="sxs-lookup"><span data-stu-id="78116-120">Users URIs</span></span>](atoc-reference-users.md)

   