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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8324075"
---
# <a name="usersxuidxuidoutbox"></a><span data-ttu-id="b14de-104">/users/xuid({xuid})/outbox</span><span class="sxs-lookup"><span data-stu-id="b14de-104">/users/xuid({xuid})/outbox</span></span>
<span data-ttu-id="b14de-105">メッセージの送信のみのアクセスをユーザーには、Xbox LIVE サービスに送信トレイします。</span><span class="sxs-lookup"><span data-stu-id="b14de-105">Provides send-only access to a user's messaging outbox for Xbox LIVE Services.</span></span> <span data-ttu-id="b14de-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b14de-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b14de-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b14de-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b14de-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b14de-108">URI parameters</span></span> 
 
| <span data-ttu-id="b14de-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b14de-109">Parameter</span></span>| <span data-ttu-id="b14de-110">型</span><span class="sxs-lookup"><span data-stu-id="b14de-110">Type</span></span>| <span data-ttu-id="b14de-111">説明</span><span class="sxs-lookup"><span data-stu-id="b14de-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b14de-112">xuid</span><span class="sxs-lookup"><span data-stu-id="b14de-112">xuid</span></span> | <span data-ttu-id="b14de-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="b14de-113">unsigned 64-bit integer</span></span> | <span data-ttu-id="b14de-114">Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。</span><span class="sxs-lookup"><span data-stu-id="b14de-114">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
  
<a id="ID4EXB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b14de-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b14de-115">Valid methods</span></span> 

[<span data-ttu-id="b14de-116">POST (/users/xuid({xuid})/outbox)</span><span class="sxs-lookup"><span data-stu-id="b14de-116">POST (/users/xuid({xuid})/outbox)</span></span>](uri-usersxuidoutboxpost.md)

<span data-ttu-id="b14de-117">&nbsp;&nbsp;受信者の一覧に指定されたメッセージを送信します。</span><span class="sxs-lookup"><span data-stu-id="b14de-117">&nbsp;&nbsp;Sends a specified message to a list of recipients.</span></span> 
 
<a id="ID4EFC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b14de-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="b14de-118">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b14de-119">Parent</span><span class="sxs-lookup"><span data-stu-id="b14de-119">Parent</span></span>  

[<span data-ttu-id="b14de-120">ユーザー URI</span><span class="sxs-lookup"><span data-stu-id="b14de-120">Users URIs</span></span>](atoc-reference-users.md)

   