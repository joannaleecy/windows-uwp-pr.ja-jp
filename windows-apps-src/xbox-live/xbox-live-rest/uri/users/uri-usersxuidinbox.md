---
title: /users/xuid({xuid})/inbox
assetID: 352740c6-42e2-0000-495d-bf384dc3e941
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinbox.html
author: KevinAsgari
description: " /users/xuid({xuid})/inbox"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 944b2c9f0e5758444295ef9ec189d84728a3845d
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4680220"
---
# <a name="usersxuidxuidinbox"></a><span data-ttu-id="7daf4-104">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="7daf4-104">/users/xuid({xuid})/inbox</span></span>
<span data-ttu-id="7daf4-105">ユーザーへのアクセスの Xbox LIVE サービスの受信トレイのメッセージを提供します。</span><span class="sxs-lookup"><span data-stu-id="7daf4-105">Provides access to a user's messaging inbox for Xbox LIVE Services.</span></span> <span data-ttu-id="7daf4-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7daf4-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7daf4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7daf4-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7daf4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7daf4-108">URI parameters</span></span> 
 
| <span data-ttu-id="7daf4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7daf4-109">Parameter</span></span>| <span data-ttu-id="7daf4-110">型</span><span class="sxs-lookup"><span data-stu-id="7daf4-110">Type</span></span>| <span data-ttu-id="7daf4-111">説明</span><span class="sxs-lookup"><span data-stu-id="7daf4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7daf4-112">xuid</span><span class="sxs-lookup"><span data-stu-id="7daf4-112">xuid</span></span> | <span data-ttu-id="7daf4-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="7daf4-113">unsigned 64-bit integer</span></span> | <span data-ttu-id="7daf4-114">Xbox ユーザー ID (XUID) 要求を行っているプレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="7daf4-114">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
| <span data-ttu-id="7daf4-115">メッセージ Id</span><span class="sxs-lookup"><span data-stu-id="7daf4-115">messageId</span></span> | <span data-ttu-id="7daf4-116">文字列 [50]</span><span class="sxs-lookup"><span data-stu-id="7daf4-116">string[50]</span></span> | <span data-ttu-id="7daf4-117">取得または削除されるメッセージの ID です。</span><span class="sxs-lookup"><span data-stu-id="7daf4-117">ID of the message being retrieved or deleted.</span></span> | 
  
<a id="ID4EDC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="7daf4-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="7daf4-118">Valid methods</span></span> 

[<span data-ttu-id="7daf4-119">GET (/users/xuid({xuid})/inbox)</span><span class="sxs-lookup"><span data-stu-id="7daf4-119">GET (/users/xuid({xuid})/inbox)</span></span>](uri-usersxuidinboxget.md)

<span data-ttu-id="7daf4-120">&nbsp;&nbsp;サービスから指定されたユーザー メッセージ概要数を取得します。</span><span class="sxs-lookup"><span data-stu-id="7daf4-120">&nbsp;&nbsp;Retrieves a specified number of user message summaries from the service.</span></span> 

[<span data-ttu-id="7daf4-121">DELETE (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="7daf4-121">DELETE (/users/xuid({xuid})/inbox/{messageId})</span></span>](uri-usersxuidinboxmessageiddelete.md)

<span data-ttu-id="7daf4-122">&nbsp;&nbsp;ユーザーの受信トレイでユーザーのメッセージを削除します。</span><span class="sxs-lookup"><span data-stu-id="7daf4-122">&nbsp;&nbsp;Deletes a user message in the user's inbox.</span></span>

[<span data-ttu-id="7daf4-123">GET (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="7daf4-123">GET (/users/xuid({xuid})/inbox/{messageId})</span></span>](uri-usersxuidinboxmessageidget.md)

<span data-ttu-id="7daf4-124">&nbsp;&nbsp;サービスのマーキング、特定のユーザー メッセージの詳細なメッセージ テキストを取得します。</span><span class="sxs-lookup"><span data-stu-id="7daf4-124">&nbsp;&nbsp;Retrieves the detailed message text for a particular user message, marking it as read on the service.</span></span> 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="7daf4-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="7daf4-125">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7daf4-126">Parent</span><span class="sxs-lookup"><span data-stu-id="7daf4-126">Parent</span></span>  

[<span data-ttu-id="7daf4-127">ユーザー URI</span><span class="sxs-lookup"><span data-stu-id="7daf4-127">Users URIs</span></span>](atoc-reference-users.md)

   