---
title: /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
assetID: edcb19bd-87a5-732b-0c45-6f7355fc2dd1
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindex.html
author: KevinAsgari
description: " /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3d95d3f0f171fa0e529d57ab5deca8160ddc3c43
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5929266"
---
# <a name="usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a><span data-ttu-id="f9c08-104">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="f9c08-104">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>
<span data-ttu-id="f9c08-105">一覧内の項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="f9c08-105">Moves an item within a list.</span></span> <span data-ttu-id="f9c08-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f9c08-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f9c08-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9c08-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f9c08-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9c08-108">URI parameters</span></span> 
 
| <span data-ttu-id="f9c08-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f9c08-109">Parameter</span></span>| <span data-ttu-id="f9c08-110">型</span><span class="sxs-lookup"><span data-stu-id="f9c08-110">Type</span></span>| <span data-ttu-id="f9c08-111">説明</span><span class="sxs-lookup"><span data-stu-id="f9c08-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f9c08-112">XUID</span><span class="sxs-lookup"><span data-stu-id="f9c08-112">XUID</span></span>| <span data-ttu-id="f9c08-113">string</span><span class="sxs-lookup"><span data-stu-id="f9c08-113">string</span></span>| <span data-ttu-id="f9c08-114">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="f9c08-114">XUID of the user.</span></span>| 
| <span data-ttu-id="f9c08-115">リスト</span><span class="sxs-lookup"><span data-stu-id="f9c08-115">listname</span></span>| <span data-ttu-id="f9c08-116">string</span><span class="sxs-lookup"><span data-stu-id="f9c08-116">string</span></span>| <span data-ttu-id="f9c08-117">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="f9c08-117">Name of the list to manipulate.</span></span>| 
| <span data-ttu-id="f9c08-118">インデックス</span><span class="sxs-lookup"><span data-stu-id="f9c08-118">index</span></span>| <span data-ttu-id="f9c08-119">string</span><span class="sxs-lookup"><span data-stu-id="f9c08-119">string</span></span>| <span data-ttu-id="f9c08-120">移動する項目の現在のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="f9c08-120">Specifies the current index of the item to be moved.</span></span> <span data-ttu-id="f9c08-121">インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを参照し、呼び出しの要求本文は空にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c08-121">If the index value is zero or a positive integer, this refers to the current index of the item, and the request body of the call should be empty.</span></span> <span data-ttu-id="f9c08-122">ただし、インデックス値が「-1」の場合は、ItemId または呼び出しの要求本文には、プロバイダー/ProviderID によって移動する項目を指定してください。</span><span class="sxs-lookup"><span data-stu-id="f9c08-122">However, if the index value is "-1", the item to be moved must be specified by ItemId or Provider/ProviderID in the request body of the call.</span></span> | 
  
<a id="ID4EHC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f9c08-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f9c08-123">Valid methods</span></span>

[<span data-ttu-id="f9c08-124">POST</span><span class="sxs-lookup"><span data-stu-id="f9c08-124">POST</span></span>](uri-usersxuidlistspinslistnameindexpost.md)

<span data-ttu-id="f9c08-125">&nbsp;&nbsp;リスト項目をリスト内の異なる位置に移動します。</span><span class="sxs-lookup"><span data-stu-id="f9c08-125">&nbsp;&nbsp;Moves an item in a list to a different position within the list.</span></span>
 
<a id="ID4ERC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f9c08-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="f9c08-126">See also</span></span>
 
<a id="ID4ETC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f9c08-127">Parent</span><span class="sxs-lookup"><span data-stu-id="f9c08-127">Parent</span></span> 

[<span data-ttu-id="f9c08-128">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="f9c08-128">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   