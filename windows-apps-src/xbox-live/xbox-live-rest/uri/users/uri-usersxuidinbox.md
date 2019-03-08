---
title: /users/xuid({xuid})/inbox
assetID: 352740c6-42e2-0000-495d-bf384dc3e941
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinbox.html
description: " /users/xuid({xuid})/inbox"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8ded70b32dfd291d17a43a1741b26710f681a397
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640897"
---
# <a name="usersxuidxuidinbox"></a><span data-ttu-id="c7cb1-104">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="c7cb1-104">/users/xuid({xuid})/inbox</span></span>
<span data-ttu-id="c7cb1-105">ユーザーへのアクセスには、Xbox LIVE サービスの受信トレイがのメッセージングを提供します。</span><span class="sxs-lookup"><span data-stu-id="c7cb1-105">Provides access to a user's messaging inbox for Xbox LIVE Services.</span></span> <span data-ttu-id="c7cb1-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c7cb1-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c7cb1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c7cb1-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c7cb1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c7cb1-108">URI parameters</span></span> 
 
| <span data-ttu-id="c7cb1-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c7cb1-109">Parameter</span></span>| <span data-ttu-id="c7cb1-110">種類</span><span class="sxs-lookup"><span data-stu-id="c7cb1-110">Type</span></span>| <span data-ttu-id="c7cb1-111">説明</span><span class="sxs-lookup"><span data-stu-id="c7cb1-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c7cb1-112">xuid</span><span class="sxs-lookup"><span data-stu-id="c7cb1-112">xuid</span></span> | <span data-ttu-id="c7cb1-113">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c7cb1-113">unsigned 64-bit integer</span></span> | <span data-ttu-id="c7cb1-114">Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。</span><span class="sxs-lookup"><span data-stu-id="c7cb1-114">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
| <span data-ttu-id="c7cb1-115">メッセージ Id</span><span class="sxs-lookup"><span data-stu-id="c7cb1-115">messageId</span></span> | <span data-ttu-id="c7cb1-116">string[50]</span><span class="sxs-lookup"><span data-stu-id="c7cb1-116">string[50]</span></span> | <span data-ttu-id="c7cb1-117">メッセージの取得中または削除の ID。</span><span class="sxs-lookup"><span data-stu-id="c7cb1-117">ID of the message being retrieved or deleted.</span></span> | 
  
<a id="ID4EDC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="c7cb1-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="c7cb1-118">Valid methods</span></span> 

[<span data-ttu-id="c7cb1-119">GET (/users/xuid({xuid})/inbox)</span><span class="sxs-lookup"><span data-stu-id="c7cb1-119">GET (/users/xuid({xuid})/inbox)</span></span>](uri-usersxuidinboxget.md)

<span data-ttu-id="c7cb1-120">&nbsp;&nbsp;サービスから、指定された数のユーザー メッセージの概要を取得します。</span><span class="sxs-lookup"><span data-stu-id="c7cb1-120">&nbsp;&nbsp;Retrieves a specified number of user message summaries from the service.</span></span> 

[<span data-ttu-id="c7cb1-121">DELETE (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="c7cb1-121">DELETE (/users/xuid({xuid})/inbox/{messageId})</span></span>](uri-usersxuidinboxmessageiddelete.md)

<span data-ttu-id="c7cb1-122">&nbsp;&nbsp;ユーザーの受信トレイ内のユーザー メッセージを削除します。</span><span class="sxs-lookup"><span data-stu-id="c7cb1-122">&nbsp;&nbsp;Deletes a user message in the user's inbox.</span></span>

[<span data-ttu-id="c7cb1-123">GET (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="c7cb1-123">GET (/users/xuid({xuid})/inbox/{messageId})</span></span>](uri-usersxuidinboxmessageidget.md)

<span data-ttu-id="c7cb1-124">&nbsp;&nbsp;開封済みにサービスで、特定のユーザー メッセージの詳細なメッセージ テキストを取得します。</span><span class="sxs-lookup"><span data-stu-id="c7cb1-124">&nbsp;&nbsp;Retrieves the detailed message text for a particular user message, marking it as read on the service.</span></span> 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c7cb1-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="c7cb1-125">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c7cb1-126">Parent</span><span class="sxs-lookup"><span data-stu-id="c7cb1-126">Parent</span></span>  

[<span data-ttu-id="c7cb1-127">ユーザーの Uri</span><span class="sxs-lookup"><span data-stu-id="c7cb1-127">Users URIs</span></span>](atoc-reference-users.md)

   