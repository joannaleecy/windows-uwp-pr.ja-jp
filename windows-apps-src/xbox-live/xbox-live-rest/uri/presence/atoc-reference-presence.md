---
title: プレゼンス URI
assetID: 4ba44d9c-8615-cacc-2eee-7ff5e7c74383
permalink: en-us/docs/xboxlive/rest/atoc-reference-presence.html
description: " プレゼンス URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a46ecd48c2b0bf523ab234a5f20cf9ed6669e75
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632607"
---
# <a name="presence-uris"></a><span data-ttu-id="6c91e-104">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="6c91e-104">Presence URIs</span></span>
 
<span data-ttu-id="6c91e-105">このセクションでは、Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供の Xbox Live サービスから*プレゼンス*します。</span><span class="sxs-lookup"><span data-stu-id="6c91e-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *presence*.</span></span>
 
<span data-ttu-id="6c91e-106">Xbox 360、Windows Phone デバイス、または Windows を実行しているゲームだけでは、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="6c91e-106">Only games running on an Xbox 360, on a Windows Phone device, or on Windows can use this service.</span></span>
 
<span data-ttu-id="6c91e-107">これらの Uri のドメインとは、userpresence.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="6c91e-107">The domain for these URIs is userpresence.xboxlive.com.</span></span>
 
<span data-ttu-id="6c91e-108">リアルタイムのアクティビティ (RTA) サービスを使用して、ユーザーのプレゼンスの変更をサブスクライブできます。</span><span class="sxs-lookup"><span data-stu-id="6c91e-108">You can subscribe to a user's presence changes by using the Real Time Activity (RTA) service.</span></span>
 
<a id="ID4ERB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="6c91e-109">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="6c91e-109">In this section</span></span>

[<span data-ttu-id="6c91e-110">/users/batch</span><span class="sxs-lookup"><span data-stu-id="6c91e-110">/users/batch</span></span>](uri-usersbatch.md)

<span data-ttu-id="6c91e-111">&nbsp;&nbsp;ユーザーのバッチのアクセスが存在します。</span><span class="sxs-lookup"><span data-stu-id="6c91e-111">&nbsp;&nbsp;Access presence for a batch of users.</span></span>

[<span data-ttu-id="6c91e-112">/users/me</span><span class="sxs-lookup"><span data-stu-id="6c91e-112">/users/me</span></span>](uri-usersme.md)

<span data-ttu-id="6c91e-113">&nbsp;&nbsp;現在のユーザーのプレゼンスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6c91e-113">&nbsp;&nbsp;Access the current user's presence.</span></span>

[<span data-ttu-id="6c91e-114">/users/me/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="6c91e-114">/users/me/groups/{moniker}</span></span>](uri-usersmegroupsmoniker.md)

<span data-ttu-id="6c91e-115">&nbsp;&nbsp;自分のグループの PresenceRecord にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6c91e-115">&nbsp;&nbsp;Accesses the PresenceRecord for my group.</span></span>

[<span data-ttu-id="6c91e-116">/users/xuid({xuid})</span><span class="sxs-lookup"><span data-stu-id="6c91e-116">/users/xuid({xuid})</span></span>](uri-usersxuid.md)

<span data-ttu-id="6c91e-117">&nbsp;&nbsp;別のユーザーまたはクライアントの存在にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6c91e-117">&nbsp;&nbsp;Access the presence of another user or client.</span></span>

[<span data-ttu-id="6c91e-118">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="6c91e-118">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

<span data-ttu-id="6c91e-119">&nbsp;&nbsp;タイトルまたはタイトルのユーザーの存在にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6c91e-119">&nbsp;&nbsp;Access the presence of a title or a title's user.</span></span>

[<span data-ttu-id="6c91e-120">/users/xuid({xuid})/groups/{moniker}</span><span class="sxs-lookup"><span data-stu-id="6c91e-120">/users/xuid({xuid})/groups/{moniker}</span></span>](uri-usersxuidgroupsmoniker.md)

<span data-ttu-id="6c91e-121">&nbsp;&nbsp;グループの PresenceRecord にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6c91e-121">&nbsp;&nbsp;Accesses the PresenceRecord for a group.</span></span>

[<span data-ttu-id="6c91e-122">/users/xuid({xuid})/groups/{moniker}/broadcasting</span><span class="sxs-lookup"><span data-stu-id="6c91e-122">/users/xuid({xuid})/groups/{moniker}/broadcasting</span></span>](uri-usersxuidgroupsmonikerbroadcasting.md)

<span data-ttu-id="6c91e-123">&nbsp;&nbsp;アクセス グループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンスのレコードに関連する XUID URI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="6c91e-123">&nbsp;&nbsp;Accesses the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>

[<span data-ttu-id="6c91e-124">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span><span class="sxs-lookup"><span data-stu-id="6c91e-124">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span></span>](uri-usersxuidgroupsmonikerbroadcastingcount.md)

<span data-ttu-id="6c91e-125">&nbsp;&nbsp;アクセス グループ モニカーによって指定されたブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。</span><span class="sxs-lookup"><span data-stu-id="6c91e-125">&nbsp;&nbsp;Accesses the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a><span data-ttu-id="6c91e-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="6c91e-126">See also</span></span>
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6c91e-127">Parent</span><span class="sxs-lookup"><span data-stu-id="6c91e-127">Parent</span></span> 

[<span data-ttu-id="6c91e-128">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="6c91e-128">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   