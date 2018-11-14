---
title: /users/xuid({xuid})/inbox
assetID: 352740c6-42e2-0000-495d-bf384dc3e941
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinbox.html
author: KevinAsgari
description: " /users/xuid({xuid})/inbox"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 890ee500cc29ca6766830e7a8b648865dfbb159d
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6277000"
---
# <a name="usersxuidxuidinbox"></a><span data-ttu-id="40570-104">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="40570-104">/users/xuid({xuid})/inbox</span></span>
<span data-ttu-id="40570-105">ユーザーへのアクセスの Xbox LIVE サービスの受信トレイのメッセージを提供します。</span><span class="sxs-lookup"><span data-stu-id="40570-105">Provides access to a user's messaging inbox for Xbox LIVE Services.</span></span> <span data-ttu-id="40570-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="40570-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="40570-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="40570-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="40570-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="40570-108">URI parameters</span></span> 
 
| <span data-ttu-id="40570-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="40570-109">Parameter</span></span>| <span data-ttu-id="40570-110">型</span><span class="sxs-lookup"><span data-stu-id="40570-110">Type</span></span>| <span data-ttu-id="40570-111">説明</span><span class="sxs-lookup"><span data-stu-id="40570-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="40570-112">xuid</span><span class="sxs-lookup"><span data-stu-id="40570-112">xuid</span></span> | <span data-ttu-id="40570-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="40570-113">unsigned 64-bit integer</span></span> | <span data-ttu-id="40570-114">Xbox ユーザー ID (XUID) 要求を行っているプレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="40570-114">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
| <span data-ttu-id="40570-115">メッセージ Id</span><span class="sxs-lookup"><span data-stu-id="40570-115">messageId</span></span> | <span data-ttu-id="40570-116">文字列 [50]</span><span class="sxs-lookup"><span data-stu-id="40570-116">string[50]</span></span> | <span data-ttu-id="40570-117">取得または削除されるメッセージの ID です。</span><span class="sxs-lookup"><span data-stu-id="40570-117">ID of the message being retrieved or deleted.</span></span> | 
  
<a id="ID4EDC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="40570-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="40570-118">Valid methods</span></span> 

[<span data-ttu-id="40570-119">GET (/users/xuid({xuid})/inbox)</span><span class="sxs-lookup"><span data-stu-id="40570-119">GET (/users/xuid({xuid})/inbox)</span></span>](uri-usersxuidinboxget.md)

<span data-ttu-id="40570-120">&nbsp;&nbsp;サービスから指定したメッセージの概要をユーザー数を取得します。</span><span class="sxs-lookup"><span data-stu-id="40570-120">&nbsp;&nbsp;Retrieves a specified number of user message summaries from the service.</span></span> 

[<span data-ttu-id="40570-121">DELETE (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="40570-121">DELETE (/users/xuid({xuid})/inbox/{messageId})</span></span>](uri-usersxuidinboxmessageiddelete.md)

<span data-ttu-id="40570-122">&nbsp;&nbsp;ユーザーの受信トレイでユーザーのメッセージを削除します。</span><span class="sxs-lookup"><span data-stu-id="40570-122">&nbsp;&nbsp;Deletes a user message in the user's inbox.</span></span>

[<span data-ttu-id="40570-123">GET (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="40570-123">GET (/users/xuid({xuid})/inbox/{messageId})</span></span>](uri-usersxuidinboxmessageidget.md)

<span data-ttu-id="40570-124">&nbsp;&nbsp;サービスの読み取りとしてマークすること、特定のユーザーのメッセージの詳細なメッセージ テキストを取得します。</span><span class="sxs-lookup"><span data-stu-id="40570-124">&nbsp;&nbsp;Retrieves the detailed message text for a particular user message, marking it as read on the service.</span></span> 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="40570-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="40570-125">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="40570-126">Parent</span><span class="sxs-lookup"><span data-stu-id="40570-126">Parent</span></span>  

[<span data-ttu-id="40570-127">ユーザー URI</span><span class="sxs-lookup"><span data-stu-id="40570-127">Users URIs</span></span>](atoc-reference-users.md)

   