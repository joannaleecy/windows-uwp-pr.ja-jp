---
title: プレゼンス URI
assetID: 4ba44d9c-8615-cacc-2eee-7ff5e7c74383
permalink: en-us/docs/xboxlive/rest/atoc-reference-presence.html
author: KevinAsgari
description: " プレゼンス URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f4c2a34d47f894e2ac9aeaf6228c8ebd41348306
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4019119"
---
# <a name="presence-uris"></a><span data-ttu-id="65681-104">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="65681-104">Presence URIs</span></span>
 
<span data-ttu-id="65681-105">このセクションでは、*プレゼンス*の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="65681-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *presence*.</span></span>
 
<span data-ttu-id="65681-106">Xbox 360、Windows Phone デバイス、または Windows を実行しているゲームだけでは、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="65681-106">Only games running on an Xbox 360, on a Windows Phone device, or on Windows can use this service.</span></span>
 
<span data-ttu-id="65681-107">これらの Uri のドメインは、userpresence.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="65681-107">The domain for these URIs is userpresence.xboxlive.com.</span></span>
 
<span data-ttu-id="65681-108">リアルタイム アクティビティ (RTA) サービスを使用して、ユーザーのプレゼンスの変更をサブスクライブすることができます。</span><span class="sxs-lookup"><span data-stu-id="65681-108">You can subscribe to a user's presence changes by using the Real Time Activity (RTA) service.</span></span>
 
<a id="ID4ERB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="65681-109">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="65681-109">In this section</span></span>

[<span data-ttu-id="65681-110">/users/batch</span><span class="sxs-lookup"><span data-stu-id="65681-110">/users/batch</span></span>](uri-usersbatch.md)

<span data-ttu-id="65681-111">&nbsp;&nbsp;ユーザーのバッチのプレゼンスをアクセスします。</span><span class="sxs-lookup"><span data-stu-id="65681-111">&nbsp;&nbsp;Access presence for a batch of users.</span></span>

[<span data-ttu-id="65681-112">/users/me</span><span class="sxs-lookup"><span data-stu-id="65681-112">/users/me</span></span>](uri-usersme.md)

<span data-ttu-id="65681-113">&nbsp;&nbsp;現在のユーザーのプレゼンスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="65681-113">&nbsp;&nbsp;Access the current user's presence.</span></span>

[<span data-ttu-id="65681-114">/users/me/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="65681-114">/users/me/groups/{moniker}</span></span>](uri-usersmegroupsmoniker.md)

<span data-ttu-id="65681-115">&nbsp;&nbsp;[グループの presencerecord を要求してにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="65681-115">&nbsp;&nbsp;Accesses the PresenceRecord for my group.</span></span>

[<span data-ttu-id="65681-116">/users/xuid({xuid})</span><span class="sxs-lookup"><span data-stu-id="65681-116">/users/xuid({xuid})</span></span>](uri-usersxuid.md)

<span data-ttu-id="65681-117">&nbsp;&nbsp;別のユーザーまたはクライアントの有無にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="65681-117">&nbsp;&nbsp;Access the presence of another user or client.</span></span>

[<span data-ttu-id="65681-118">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="65681-118">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

<span data-ttu-id="65681-119">&nbsp;&nbsp;タイトルまたはタイトルのユーザーのプレゼンスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="65681-119">&nbsp;&nbsp;Access the presence of a title or a title's user.</span></span>

[<span data-ttu-id="65681-120">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="65681-120">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

<span data-ttu-id="65681-121">&nbsp;&nbsp;グループの presencerecord を要求してにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="65681-121">&nbsp;&nbsp;Accesses the PresenceRecord for a group.</span></span>

[<span data-ttu-id="65681-122">/users/xuid({xuid})/groups/{moniker}/broadcasting</span><span class="sxs-lookup"><span data-stu-id="65681-122">/users/xuid({xuid})/groups/{moniker}/broadcasting</span></span>](uri-usersxuidgroupsmonikerbroadcasting.md)

<span data-ttu-id="65681-123">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーのプレゼンス レコードにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="65681-123">&nbsp;&nbsp;Accesses the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>

[<span data-ttu-id="65681-124">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span><span class="sxs-lookup"><span data-stu-id="65681-124">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span></span>](uri-usersxuidgroupsmonikerbroadcastingcount.md)

<span data-ttu-id="65681-125">&nbsp;&nbsp;アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。</span><span class="sxs-lookup"><span data-stu-id="65681-125">&nbsp;&nbsp;Accesses the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a><span data-ttu-id="65681-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="65681-126">See also</span></span>
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a><span data-ttu-id="65681-127">Parent</span><span class="sxs-lookup"><span data-stu-id="65681-127">Parent</span></span> 

[<span data-ttu-id="65681-128">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="65681-128">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   