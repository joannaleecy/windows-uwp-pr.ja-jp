---
title: ゲーム DVR URI
assetID: 472f705e-bf28-7894-b1ba-80933d8746a6
permalink: en-us/docs/xboxlive/rest/atoc-reference-dvr.html
description: " ゲーム DVR URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b4bfd6e51efce4c6ec85db99a10a44a776dcb840
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617847"
---
# <a name="game-dvr-uris"></a><span data-ttu-id="ff0d7-104">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="ff0d7-104">Game DVR URIs</span></span>
 
<span data-ttu-id="ff0d7-105">このセクションでは、Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供の Xbox Live サービスから*ゲーム録画*します。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *game DVR*.</span></span>
 
<span data-ttu-id="ff0d7-106">コンソールのみが、ゲームのクリップを記録できますが、アクセスできる任意のデバイスは、クリップを表示できます。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-106">Only consoles can record a game clip, but any device that can access can display a clip.</span></span>
 
<span data-ttu-id="ff0d7-107">対象の URI の関数によっては、これらの Uri のドメイン。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-107">Depending on the function of the URI in question, the domains for these URIs are:</span></span>
 
   *  <span data-ttu-id="ff0d7-108">gameclipsmetadata.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="ff0d7-108">gameclipsmetadata.xboxlive.com</span></span> 
   *  <span data-ttu-id="ff0d7-109">gameclipstransfer.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="ff0d7-109">gameclipstransfer.xboxlive.com</span></span> 
  
<a id="ID4EZB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="ff0d7-110">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="ff0d7-110">In this section</span></span>

[<span data-ttu-id="ff0d7-111">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="ff0d7-111">/public/scids/{scid}/clips</span></span>](uri-publicscidclips.md)

<span data-ttu-id="ff0d7-112">&nbsp;&nbsp;クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-112">&nbsp;&nbsp;Access public clips.</span></span> <span data-ttu-id="ff0d7-113">この URI 実際に指定できます 2 つの形式で`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-113">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="ff0d7-114">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-114">See below for more details.</span></span>

[<span data-ttu-id="ff0d7-115">/{uri}</span><span class="sxs-lookup"><span data-stu-id="ff0d7-115">/{uri}</span></span>](uri-uri.md)

<span data-ttu-id="ff0d7-116">&nbsp;&nbsp;クリップのゲーム データにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-116">&nbsp;&nbsp;Access game clip data.</span></span>

[<span data-ttu-id="ff0d7-117">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="ff0d7-117">/users/me/scids/{scid}/clips</span></span>](uri-usersmescidclips.md)

<span data-ttu-id="ff0d7-118">&nbsp;&nbsp;初期のアクセスは、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-118">&nbsp;&nbsp;Access an initial upload request.</span></span>

[<span data-ttu-id="ff0d7-119">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="ff0d7-119">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

<span data-ttu-id="ff0d7-120">&nbsp;&nbsp;ゲームのクリップのデータ アクセスとメタデータ。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-120">&nbsp;&nbsp;Access game clip data and metadata.</span></span>

[<span data-ttu-id="ff0d7-121">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="ff0d7-121">/users/{ownerId}/clips</span></span>](uri-usersowneridclips.md)

<span data-ttu-id="ff0d7-122">&nbsp;&nbsp;ユーザーのクリップのアクセス リスト。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-122">&nbsp;&nbsp;Access list of user's clips.</span></span>

[<span data-ttu-id="ff0d7-123">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="ff0d7-123">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersowneridscidclipsgameclipid.md)

<span data-ttu-id="ff0d7-124">&nbsp;&nbsp;特定するすべての Id がわかっている場合は、ゲームの 1 つのクリップをシステムからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ff0d7-124">&nbsp;&nbsp;Access a single game clip from the system if all the IDs to locate it are known.</span></span>
 
<a id="ID4EOC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ff0d7-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="ff0d7-125">See also</span></span>
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ff0d7-126">Parent</span><span class="sxs-lookup"><span data-stu-id="ff0d7-126">Parent</span></span> 

[<span data-ttu-id="ff0d7-127">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="ff0d7-127">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   