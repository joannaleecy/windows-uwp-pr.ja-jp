---
title: リスト URI
assetID: 84dcbd11-86a0-8a1e-7db9-bcecf9b7f853
permalink: en-us/docs/xboxlive/rest/atoc-reference-lists.html
description: " リスト URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a6f1e743542e70ee96ad93ee1cf2a7f2c3ed7158
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599327"
---
# <a name="lists-uris"></a><span data-ttu-id="bbb8e-104">リスト URI</span><span class="sxs-lookup"><span data-stu-id="bbb8e-104">Lists URIs</span></span>
 
<span data-ttu-id="bbb8e-105">このセクションでは、Universal Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト転送プロトコル (HTTP) のメソッドに関する詳細情報を提供の Xbox Live サービスから*ピン*します。</span><span class="sxs-lookup"><span data-stu-id="bbb8e-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *Pins*.</span></span>
 
<span data-ttu-id="bbb8e-106">ゲームと Xbox 360、Windows Phone デバイスで、SmartGlass、または Xbox.com で実行されているアプリケーションのみが、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="bbb8e-106">Only games and applications running on an Xbox 360, on a Windows Phone device, on SmartGlass, or on Xbox.com can use this service.</span></span>
 
<span data-ttu-id="bbb8e-107">これらの Uri のドメインとは、eplists.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="bbb8e-107">The domain for these URIs is eplists.xboxlive.com.</span></span>
 
<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="bbb8e-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="bbb8e-108">In this section</span></span>

[<span data-ttu-id="bbb8e-109">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="bbb8e-109">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

<span data-ttu-id="bbb8e-110">&nbsp;&nbsp;リスト内の項目にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="bbb8e-110">&nbsp;&nbsp;Accesses items in a list.</span></span>

[<span data-ttu-id="bbb8e-111">/users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span><span class="sxs-lookup"><span data-stu-id="bbb8e-111">/users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span></span>](uri-usersxuidlistspinslistnamecontainsitems.md)

<span data-ttu-id="bbb8e-112">&nbsp;&nbsp;全体の一覧を取得せず、(itemId で指定された) 項目のセットが一覧で含まれるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="bbb8e-112">&nbsp;&nbsp;Determines whether a set of items (specified by itemId) are contained in a list without retrieving the entire list.</span></span>

[<span data-ttu-id="bbb8e-113">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="bbb8e-113">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>](uri-usersxuidlistspinslistnameindex.md)

<span data-ttu-id="bbb8e-114">&nbsp;&nbsp;一覧内の項目に移動します。</span><span class="sxs-lookup"><span data-stu-id="bbb8e-114">&nbsp;&nbsp;Moves an item within a list.</span></span>

[<span data-ttu-id="bbb8e-115">/users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span><span class="sxs-lookup"><span data-stu-id="bbb8e-115">/users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span></span>](uri-usersxuidlistspinslistnameremoveitems.md)

<span data-ttu-id="bbb8e-116">&nbsp;&nbsp;一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="bbb8e-116">&nbsp;&nbsp;Removes items from a list.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="bbb8e-117">関連項目</span><span class="sxs-lookup"><span data-stu-id="bbb8e-117">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bbb8e-118">Parent</span><span class="sxs-lookup"><span data-stu-id="bbb8e-118">Parent</span></span> 

[<span data-ttu-id="bbb8e-119">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="bbb8e-119">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   