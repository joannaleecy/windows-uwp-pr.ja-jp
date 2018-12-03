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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8348638"
---
# <a name="game-dvr-uris"></a><span data-ttu-id="21cf2-104">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="21cf2-104">Game DVR URIs</span></span>
 
<span data-ttu-id="21cf2-105">このセクションでは、*ゲーム DVR*の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法についての詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="21cf2-105">This section provides detail about the Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *game DVR*.</span></span>
 
<span data-ttu-id="21cf2-106">本体のみが、ゲーム クリップを記録できますにアクセスできる任意のデバイスにクリップを表示できます。</span><span class="sxs-lookup"><span data-stu-id="21cf2-106">Only consoles can record a game clip, but any device that can access can display a clip.</span></span>
 
<span data-ttu-id="21cf2-107">によっては、対象の URI の関数にはこれらの Uri のドメインです。</span><span class="sxs-lookup"><span data-stu-id="21cf2-107">Depending on the function of the URI in question, the domains for these URIs are:</span></span>
 
   *  <span data-ttu-id="21cf2-108">gameclipsmetadata.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="21cf2-108">gameclipsmetadata.xboxlive.com</span></span> 
   *  <span data-ttu-id="21cf2-109">gameclipstransfer.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="21cf2-109">gameclipstransfer.xboxlive.com</span></span> 
  
<a id="ID4EZB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="21cf2-110">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="21cf2-110">In this section</span></span>

[<span data-ttu-id="21cf2-111">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="21cf2-111">/public/scids/{scid}/clips</span></span>](uri-publicscidclips.md)

<span data-ttu-id="21cf2-112">&nbsp;&nbsp;クリップをパブリックにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="21cf2-112">&nbsp;&nbsp;Access public clips.</span></span> <span data-ttu-id="21cf2-113">この URI に実際にで指定できる 2 つのフォーム`/public/scids/{scid}/clips`と`/public/titles/{titleId}/clips`します。</span><span class="sxs-lookup"><span data-stu-id="21cf2-113">This URI actually can be specified in two forms, `/public/scids/{scid}/clips` and `/public/titles/{titleId}/clips`.</span></span> <span data-ttu-id="21cf2-114">詳しくは、後のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21cf2-114">See below for more details.</span></span>

[<span data-ttu-id="21cf2-115">/{uri}</span><span class="sxs-lookup"><span data-stu-id="21cf2-115">/{uri}</span></span>](uri-uri.md)

<span data-ttu-id="21cf2-116">&nbsp;&nbsp;ゲーム クリップ データにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="21cf2-116">&nbsp;&nbsp;Access game clip data.</span></span>

[<span data-ttu-id="21cf2-117">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="21cf2-117">/users/me/scids/{scid}/clips</span></span>](uri-usersmescidclips.md)

<span data-ttu-id="21cf2-118">&nbsp;&nbsp;最初のアクセスは、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="21cf2-118">&nbsp;&nbsp;Access an initial upload request.</span></span>

[<span data-ttu-id="21cf2-119">/users/me/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="21cf2-119">/users/me/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersmescidclipsgameclipid.md)

<span data-ttu-id="21cf2-120">&nbsp;&nbsp;ゲーム クリップ データへのアクセスとメタデータ。</span><span class="sxs-lookup"><span data-stu-id="21cf2-120">&nbsp;&nbsp;Access game clip data and metadata.</span></span>

[<span data-ttu-id="21cf2-121">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="21cf2-121">/users/{ownerId}/clips</span></span>](uri-usersowneridclips.md)

<span data-ttu-id="21cf2-122">&nbsp;&nbsp;ユーザーのクリップのアクセスの一覧です。</span><span class="sxs-lookup"><span data-stu-id="21cf2-122">&nbsp;&nbsp;Access list of user's clips.</span></span>

[<span data-ttu-id="21cf2-123">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span><span class="sxs-lookup"><span data-stu-id="21cf2-123">/users/{ownerId}/scids/{scid}/clips/{gameClipId}</span></span>](uri-usersowneridscidclipsgameclipid.md)

<span data-ttu-id="21cf2-124">&nbsp;&nbsp;すべての Id を見つけることがわかっている場合はシステムから 1 つのゲーム クリップにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="21cf2-124">&nbsp;&nbsp;Access a single game clip from the system if all the IDs to locate it are known.</span></span>
 
<a id="ID4EOC"></a>

 
## <a name="see-also"></a><span data-ttu-id="21cf2-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="21cf2-125">See also</span></span>
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a><span data-ttu-id="21cf2-126">Parent</span><span class="sxs-lookup"><span data-stu-id="21cf2-126">Parent</span></span> 

[<span data-ttu-id="21cf2-127">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="21cf2-127">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   