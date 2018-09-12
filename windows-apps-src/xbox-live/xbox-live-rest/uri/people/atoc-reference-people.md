---
title: ユーザーの Uri
assetID: e4e6e3c9-7051-a90b-be1c-931816a22b36
permalink: en-us/docs/xboxlive/rest/atoc-reference-people.html
author: KevinAsgari
description: " ユーザーの Uri"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 03a96c69415a8ad13bdafaa821df66a919296f61
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882209"
---
# <a name="people-uris"></a><span data-ttu-id="26351-104">ユーザーの Uri</span><span class="sxs-lookup"><span data-stu-id="26351-104">People URIs</span></span>
 
<span data-ttu-id="26351-105">このセクションでは、 *people*システムの Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法についての詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="26351-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for the *people* system.</span></span>
 
<span data-ttu-id="26351-106">Xbox 360、Windows Phone デバイスの場合、または Xbox.com を実行しているゲームのみでは、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="26351-106">Only games running on an Xbox 360, on a Windows Phone device, or on Xbox.com can use this service.</span></span>
 
<span data-ttu-id="26351-107">これらの Uri のドメインは、social.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="26351-107">The domain for these URIs is social.xboxlive.com.</span></span>
 
<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="26351-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="26351-108">In this section</span></span>

[<span data-ttu-id="26351-109">/users/{ownerId}/ユーザー</span><span class="sxs-lookup"><span data-stu-id="26351-109">/users/{ownerId}/people</span></span>](uri-usersowneridpeople.md)

<span data-ttu-id="26351-110">&nbsp;&nbsp;呼び出し元のユーザーのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="26351-110">&nbsp;&nbsp;Accesses caller's people collection.</span></span>

[<span data-ttu-id="26351-111">/users/{ownerId} そして {targetid}</span><span class="sxs-lookup"><span data-stu-id="26351-111">/users/{ownerId}/people/{targetid}</span></span>](uri-usersowneridpeopletargetid.md)

<span data-ttu-id="26351-112">&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲット ID によって、ユーザーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="26351-112">&nbsp;&nbsp;Accesses a person by target ID from caller's people collection.</span></span>

[<span data-ttu-id="26351-113">ユーザー/xuid/users/{ownerId}</span><span class="sxs-lookup"><span data-stu-id="26351-113">/users/{ownerId}/people/xuids</span></span>](uri-usersowneridpeoplexuids.md)

<span data-ttu-id="26351-114">&nbsp;&nbsp;XUID によってユーザーを呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="26351-114">&nbsp;&nbsp;Accesses people by XUID from caller's people collection.</span></span>

[<span data-ttu-id="26351-115">/users/{ownerId}/概要</span><span class="sxs-lookup"><span data-stu-id="26351-115">/users/{ownerId}/summary</span></span>](uri-usersowneridsummary.md)

<span data-ttu-id="26351-116">&nbsp;&nbsp;呼び出し元の観点から所有者に関する集計データにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="26351-116">&nbsp;&nbsp;Accesses summary data about the owner from the caller's perspective.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="26351-117">関連項目</span><span class="sxs-lookup"><span data-stu-id="26351-117">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="26351-118">Parent</span><span class="sxs-lookup"><span data-stu-id="26351-118">Parent</span></span> 

[<span data-ttu-id="26351-119">ユニバーサル リソース識別子 (URI) の参照</span><span class="sxs-lookup"><span data-stu-id="26351-119">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   