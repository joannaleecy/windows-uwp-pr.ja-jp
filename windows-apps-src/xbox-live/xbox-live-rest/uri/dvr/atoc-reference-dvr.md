---
title: ゲーム DVR URI
assetID: 472f705e-bf28-7894-b1ba-80933d8746a6
permalink: en-us/docs/xboxlive/rest/atoc-reference-dvr.html
author: KevinAsgari
description: " ゲーム DVR URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7c9be3254d9264c1d06dd0a327c36b473a457a35
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4082552"
---
# <a name="game-dvr-uris"></a><span data-ttu-id="14f54-104">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="14f54-104">Game DVR URIs</span></span>
 
<span data-ttu-id="14f54-105">このセクションでは、*ゲーム DVR*の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="14f54-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *game DVR*.</span></span>
 
<span data-ttu-id="14f54-106">本体のみが、ゲーム クリップを記録できますにアクセスできる任意のデバイスにクリップを表示できます。</span><span class="sxs-lookup"><span data-stu-id="14f54-106">Only consoles can record a game clip, but any device that can access can display a clip.</span></span>
 
<span data-ttu-id="14f54-107">問題の URI の関数によってこれらの Uri のドメインは。</span><span class="sxs-lookup"><span data-stu-id="14f54-107">Depending on the function of the URI in question, the domains for these URIs are:</span></span>
 
   *  <span data-ttu-id="14f54-108">gameclipsmetadata.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="14f54-108">gameclipsmetadata.xboxlive.com</span></span> 
   *  <span data-ttu-id="14f54-109">gameclipstransfer.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="14f54-109">gameclipstransfer.xboxlive.com</span></span> 
  
<a id="ID4EZB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="14f54-110">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="14f54-110">In this section</span></span>

[<span data-ttu-id="14f54-111">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="14f54-111">/public/scids/{scid}/clips</span></span>](uri-publicscidclips.md)

<span data-ttu-id="14f54-112">&nbsp;&nbsp;クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="14f54-112">&nbsp;&nbsp;Access public clips.</span></span> <span data-ttu-id="14f54-113">この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="14f54-113">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="14f54-114">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="14f54-114">See below for more details.</span></span>

[<span data-ttu-id="14f54-115">/{uri}</span><span class="sxs-lookup"><span data-stu-id="14f54-115">/{uri}</span></span>](uri-uri.md)

<span data-ttu-id="14f54-116">&nbsp;&nbsp;ゲーム クリップ データにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="14f54-116">&nbsp;&nbsp;Access game clip data.</span></span>

[<span data-ttu-id="14f54-117">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="14f54-117">/users/me/scids/{scid}/clips</span></span>](uri-usersmescidclips.md)

<span data-ttu-id="14f54-118">&nbsp;&nbsp;最初のアクセスは、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="14f54-118">&nbsp;&nbsp;Access an initial upload request.</span></span>

[<span data-ttu-id="14f54-119">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="14f54-119">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

<span data-ttu-id="14f54-120">&nbsp;&nbsp;ゲーム クリップ データへのアクセスとメタデータ。</span><span class="sxs-lookup"><span data-stu-id="14f54-120">&nbsp;&nbsp;Access game clip data and metadata.</span></span>

[<span data-ttu-id="14f54-121">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="14f54-121">/users/{ownerId}/clips</span></span>](uri-usersowneridclips.md)

<span data-ttu-id="14f54-122">&nbsp;&nbsp;ユーザーのクリップのアクセスの一覧です。</span><span class="sxs-lookup"><span data-stu-id="14f54-122">&nbsp;&nbsp;Access list of user's clips.</span></span>

[<span data-ttu-id="14f54-123">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="14f54-123">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersowneridscidclipsgameclipid.md)

<span data-ttu-id="14f54-124">&nbsp;&nbsp;すべての Id を見つけることがわかっている場合はシステムから 1 つのゲーム クリップにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="14f54-124">&nbsp;&nbsp;Access a single game clip from the system if all the IDs to locate it are known.</span></span>
 
<a id="ID4EOC"></a>

 
## <a name="see-also"></a><span data-ttu-id="14f54-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="14f54-125">See also</span></span>
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a><span data-ttu-id="14f54-126">Parent</span><span class="sxs-lookup"><span data-stu-id="14f54-126">Parent</span></span> 

[<span data-ttu-id="14f54-127">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="14f54-127">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   