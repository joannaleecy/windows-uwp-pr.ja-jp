---
title: マーケットプレース URI
assetID: 27b6035f-84b9-67a8-6a12-85c450d18a58
permalink: en-us/docs/xboxlive/rest/atoc-reference-marketplace.html
description: " マーケットプレース URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9fd8112c6e16b3e9d9fb70c34381e88ba5aa6273
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593877"
---
# <a name="marketplace-uris"></a><span data-ttu-id="7c53c-104">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="7c53c-104">Marketplace URIs</span></span>

<span data-ttu-id="7c53c-105">このセクションでは、Universal Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト転送プロトコル (HTTP) のメソッドに関する詳細情報を提供の Xbox Live サービスから*marketplace*サービスとも呼ばれる、エンターテイメント探索サービス (EDS)。</span><span class="sxs-lookup"><span data-stu-id="7c53c-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *marketplace* services, also known as Entertainment Discovery Services (EDS).</span></span>

<span data-ttu-id="7c53c-106">Xbox 360、Windows Phone デバイス、または Xbox.com を実行しているゲームだけでは、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="7c53c-106">Only games running on an Xbox 360, on a Windows Phone device, or on Xbox.com can use this service.</span></span>

<span data-ttu-id="7c53c-107">これらの Uri のドメインは eds.xboxlive.com、inventory.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="7c53c-107">The domains for these URIs are eds.xboxlive.com and inventory.xboxlive.com.</span></span>

<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="7c53c-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="7c53c-108">In this section</span></span>

[<span data-ttu-id="7c53c-109">/users/me/inventory</span><span class="sxs-lookup"><span data-stu-id="7c53c-109">/users/me/inventory</span></span>](uri-inventory.md)

<span data-ttu-id="7c53c-110">&nbsp;&nbsp;指定されたユーザーに関連付けられているインベントリのセットにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-110">&nbsp;&nbsp;Accesses the set of inventory currently associated with the provided user.</span></span>

[<span data-ttu-id="7c53c-111">/users/me/consumables/{itemID}</span><span class="sxs-lookup"><span data-stu-id="7c53c-111">/users/me/consumables/{itemID}</span></span>](uri-inventoryconsumablesitemurl.md)

<span data-ttu-id="7c53c-112">&nbsp;&nbsp;特定の消耗インベントリ項目の詳細の完全なセットにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-112">&nbsp;&nbsp;Accesses the full set of details for a specific consumable inventory item.</span></span>

[<span data-ttu-id="7c53c-113">/inventory/{itemID}</span><span class="sxs-lookup"><span data-stu-id="7c53c-113">/inventory/{itemID}</span></span>](uri-inventoryitemurl.md)

<span data-ttu-id="7c53c-114">&nbsp;&nbsp;特定のインベントリ項目の詳細の完全なセットにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-114">&nbsp;&nbsp;Accesses the full set of details for a specific inventory item.</span></span>

[<span data-ttu-id="7c53c-115">/media/{marketplaceId}/crossMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="7c53c-115">/media/{marketplaceId}/crossMediaGroupSearch</span></span>](uri-localecrossmediagroupsearch.md)

<span data-ttu-id="7c53c-116">&nbsp;&nbsp;いくつかの異なるメディア グループからのアクセスの項目。</span><span class="sxs-lookup"><span data-stu-id="7c53c-116">&nbsp;&nbsp;Accesses items from several different media groups.</span></span>

[<span data-ttu-id="7c53c-117">/media/{marketplaceId}/browse</span><span class="sxs-lookup"><span data-stu-id="7c53c-117">/media/{marketplaceId}/browse</span></span>](uri-medialocalebrowse.md)

<span data-ttu-id="7c53c-118">&nbsp;&nbsp;1 つのメディアのグループ内の項目を参照できます。</span><span class="sxs-lookup"><span data-stu-id="7c53c-118">&nbsp;&nbsp;Allows browsing for items within a single media group.</span></span>

[<span data-ttu-id="7c53c-119">/media/{marketplaceId}/contentRating</span><span class="sxs-lookup"><span data-stu-id="7c53c-119">/media/{marketplaceId}/contentRating</span></span>](uri-medialocalecontentrating.md)

<span data-ttu-id="7c53c-120">&nbsp;&nbsp;コンテンツのレーティング トークンにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-120">&nbsp;&nbsp;Access the content rating token.</span></span>

[<span data-ttu-id="7c53c-121">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="7c53c-121">/media/{marketplaceId}/details</span></span>](uri-medialocaledetails.md)

<span data-ttu-id="7c53c-122">&nbsp;&nbsp;プランの詳細、メタデータを返しますについて 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="7c53c-122">&nbsp;&nbsp;Returns offer details and metadata about one or more items.</span></span>

[<span data-ttu-id="7c53c-123">/media/{marketplaceId}/fields</span><span class="sxs-lookup"><span data-stu-id="7c53c-123">/media/{marketplaceId}/fields</span></span>](uri-medialocalefields.md)

<span data-ttu-id="7c53c-124">&nbsp;&nbsp;フィールドのトークンにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-124">&nbsp;&nbsp;Accesses the fields token.</span></span>

[<span data-ttu-id="7c53c-125">/media/{marketplaceId}/metadata/mediaGroups</span><span class="sxs-lookup"><span data-stu-id="7c53c-125">/media/{marketplaceId}/metadata/mediaGroups</span></span>](uri-medialocalemetadatamediagroups.md)

<span data-ttu-id="7c53c-126">&nbsp;&nbsp;指定した EDS バージョンはサポートされているすべての mediaGroups を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="7c53c-126">&nbsp;&nbsp;Lists all supported mediaGroups for the given EDS version.</span></span>

[<span data-ttu-id="7c53c-127">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="7c53c-127">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

<span data-ttu-id="7c53c-128">&nbsp;&nbsp;EDS の特定のバージョンのメディアのグループごとの使用可能な mediaItemTypes にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-128">&nbsp;&nbsp;Accesses the available mediaItemTypes per media group for the given version of EDS.</span></span>

[<span data-ttu-id="7c53c-129">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="7c53c-129">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>](uri-medialocalemetadatamediaitemtypefields.md)

<span data-ttu-id="7c53c-130">&nbsp;&nbsp;元のいずれかを特定 mediaitemtype と EDS の特定のバージョンのデータに期待できるアクセス フィールドです。</span><span class="sxs-lookup"><span data-stu-id="7c53c-130">&nbsp;&nbsp;Accesses fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span>

[<span data-ttu-id="7c53c-131">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="7c53c-131">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

<span data-ttu-id="7c53c-132">&nbsp;&nbsp;特定のメディア項目の種類のクエリの絞り込み条件にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-132">&nbsp;&nbsp;Accesses the query refiners for the given media item type.</span></span>

[<span data-ttu-id="7c53c-133">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span><span class="sxs-lookup"><span data-stu-id="7c53c-133">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

<span data-ttu-id="7c53c-134">&nbsp;&nbsp;指定されたクエリ絞り込み条件の名前と特定のメディア項目の種類は、使用可能な値にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-134">&nbsp;&nbsp;Accesses the acceptable values for the given query refiner name and given media item type.</span></span>

[<span data-ttu-id="7c53c-135">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="7c53c-135">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span></span>](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

<span data-ttu-id="7c53c-136">&nbsp;&nbsp;指定されたクエリの調整値 ("subgenres には、特定のジャンル"など) のサブの値の一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-136">&nbsp;&nbsp;Access the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span>

[<span data-ttu-id="7c53c-137">/media/{marketplaceId}/metadata/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="7c53c-137">/media/{marketplaceId}/metadata/mediaItemTypes</span></span>](uri-medialocalemetadatamediaitemtypes.md)

<span data-ttu-id="7c53c-138">&nbsp;&nbsp;指定した EDS バージョンはサポートされているすべての mediaItemTypes にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c53c-138">&nbsp;&nbsp;Accesses all supported mediaItemTypes for the given EDS version.</span></span>

[<span data-ttu-id="7c53c-139">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="7c53c-139">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>](uri-medialocalemetadatamediaitemtypesortorders.md)

<span data-ttu-id="7c53c-140">&nbsp;&nbsp;使用可能なアクセスは、特定 mediaitem 型と EDS の特定バージョンの注文を並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="7c53c-140">&nbsp;&nbsp;Accesses available sort orders for a given mediaitem type and a given version of EDS.</span></span>

[<span data-ttu-id="7c53c-141">/media/{marketplaceId}/singleMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="7c53c-141">/media/{marketplaceId}/singleMediaGroupSearch</span></span>](uri-medialocalesinglemediagroupsearch.md)

<span data-ttu-id="7c53c-142">&nbsp;&nbsp;1 つのメディアのグループ内の項目を検索をできます。</span><span class="sxs-lookup"><span data-stu-id="7c53c-142">&nbsp;&nbsp;Allows search for items within a single media group.</span></span>

<a id="ID4EFD"></a>


## <a name="see-also"></a><span data-ttu-id="7c53c-143">関連項目</span><span class="sxs-lookup"><span data-stu-id="7c53c-143">See also</span></span>

<a id="ID4EHD"></a>


##### <a name="parent"></a><span data-ttu-id="7c53c-144">Parent</span><span class="sxs-lookup"><span data-stu-id="7c53c-144">Parent</span></span>

[<span data-ttu-id="7c53c-145">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="7c53c-145">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)


<a id="ID4ERD"></a>


##### <a name="further-information"></a><span data-ttu-id="7c53c-146">詳細情報</span><span class="sxs-lookup"><span data-stu-id="7c53c-146">Further Information</span></span>

[<span data-ttu-id="7c53c-147">その他の参照</span><span class="sxs-lookup"><span data-stu-id="7c53c-147">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
