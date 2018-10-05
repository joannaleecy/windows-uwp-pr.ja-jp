---
title: リスト URI
assetID: 84dcbd11-86a0-8a1e-7db9-bcecf9b7f853
permalink: en-us/docs/xboxlive/rest/atoc-reference-lists.html
author: KevinAsgari
description: " リスト URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 00d09d5b1246e5a5d77a2d9bb9dec7b87f7847c8
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4386338"
---
# <a name="lists-uris"></a><span data-ttu-id="8a406-104">リスト URI</span><span class="sxs-lookup"><span data-stu-id="8a406-104">Lists URIs</span></span>
 
<span data-ttu-id="8a406-105">このセクションでは、*ピン*の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="8a406-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *Pins*.</span></span>
 
<span data-ttu-id="8a406-106">ゲームと Xbox 360 で、Windows Phone デバイスで、SmartGlass、または Xbox.com で実行されているアプリケーションのみには、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8a406-106">Only games and applications running on an Xbox 360, on a Windows Phone device, on SmartGlass, or on Xbox.com can use this service.</span></span>
 
<span data-ttu-id="8a406-107">これらの Uri のドメインは、eplists.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="8a406-107">The domain for these URIs is eplists.xboxlive.com.</span></span>
 
<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="8a406-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="8a406-108">In this section</span></span>

[<span data-ttu-id="8a406-109">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="8a406-109">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

<span data-ttu-id="8a406-110">&nbsp;&nbsp;リストの項目にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="8a406-110">&nbsp;&nbsp;Accesses items in a list.</span></span>

[<span data-ttu-id="8a406-111">/users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span><span class="sxs-lookup"><span data-stu-id="8a406-111">/users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span></span>](uri-usersxuidlistspinslistnamecontainsitems.md)

<span data-ttu-id="8a406-112">&nbsp;&nbsp;全体の一覧を取得することがなく一連項目 (itemId により指定) にはが一覧に含まれているかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="8a406-112">&nbsp;&nbsp;Determines whether a set of items (specified by itemId) are contained in a list without retrieving the entire list.</span></span>

[<span data-ttu-id="8a406-113">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="8a406-113">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>](uri-usersxuidlistspinslistnameindex.md)

<span data-ttu-id="8a406-114">&nbsp;&nbsp;一覧内の項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="8a406-114">&nbsp;&nbsp;Moves an item within a list.</span></span>

[<span data-ttu-id="8a406-115">/users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span><span class="sxs-lookup"><span data-stu-id="8a406-115">/users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span></span>](uri-usersxuidlistspinslistnameremoveitems.md)

<span data-ttu-id="8a406-116">&nbsp;&nbsp;一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="8a406-116">&nbsp;&nbsp;Removes items from a list.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="8a406-117">関連項目</span><span class="sxs-lookup"><span data-stu-id="8a406-117">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="8a406-118">Parent</span><span class="sxs-lookup"><span data-stu-id="8a406-118">Parent</span></span> 

[<span data-ttu-id="8a406-119">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="8a406-119">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   