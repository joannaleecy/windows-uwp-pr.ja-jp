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
# <a name="marketplace-uris"></a>マーケットプレース URI

このセクションでは、Universal Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト転送プロトコル (HTTP) のメソッドに関する詳細情報を提供の Xbox Live サービスから*marketplace*サービスとも呼ばれる、エンターテイメント探索サービス (EDS)。

Xbox 360、Windows Phone デバイス、または Xbox.com を実行しているゲームだけでは、このサービスを使用できます。

これらの Uri のドメインは eds.xboxlive.com、inventory.xboxlive.com です。

<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/me/inventory](uri-inventory.md)

&nbsp;&nbsp;指定されたユーザーに関連付けられているインベントリのセットにアクセスします。

[/users/me/consumables/{itemID}](uri-inventoryconsumablesitemurl.md)

&nbsp;&nbsp;特定の消耗インベントリ項目の詳細の完全なセットにアクセスします。

[/inventory/{itemID}](uri-inventoryitemurl.md)

&nbsp;&nbsp;特定のインベントリ項目の詳細の完全なセットにアクセスします。

[/media/{marketplaceId}/crossMediaGroupSearch](uri-localecrossmediagroupsearch.md)

&nbsp;&nbsp;いくつかの異なるメディア グループからのアクセスの項目。

[/media/{marketplaceId}/browse](uri-medialocalebrowse.md)

&nbsp;&nbsp;1 つのメディアのグループ内の項目を参照できます。

[/media/{marketplaceId}/contentRating](uri-medialocalecontentrating.md)

&nbsp;&nbsp;コンテンツのレーティング トークンにアクセスします。

[/media/{marketplaceId}/details](uri-medialocaledetails.md)

&nbsp;&nbsp;プランの詳細、メタデータを返しますについて 1 つまたは複数の項目。

[/media/{marketplaceId}/fields](uri-medialocalefields.md)

&nbsp;&nbsp;フィールドのトークンにアクセスします。

[/media/{marketplaceId}/metadata/mediaGroups](uri-medialocalemetadatamediagroups.md)

&nbsp;&nbsp;指定した EDS バージョンはサポートされているすべての mediaGroups を一覧表示します。

[/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

&nbsp;&nbsp;EDS の特定のバージョンのメディアのグループごとの使用可能な mediaItemTypes にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields](uri-medialocalemetadatamediaitemtypefields.md)

&nbsp;&nbsp;元のいずれかを特定 mediaitemtype と EDS の特定のバージョンのデータに期待できるアクセス フィールドです。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

&nbsp;&nbsp;特定のメディア項目の種類のクエリの絞り込み条件にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

&nbsp;&nbsp;指定されたクエリ絞り込み条件の名前と特定のメディア項目の種類は、使用可能な値にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

&nbsp;&nbsp;指定されたクエリの調整値 ("subgenres には、特定のジャンル"など) のサブの値の一覧にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes](uri-medialocalemetadatamediaitemtypes.md)

&nbsp;&nbsp;指定した EDS バージョンはサポートされているすべての mediaItemTypes にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders](uri-medialocalemetadatamediaitemtypesortorders.md)

&nbsp;&nbsp;使用可能なアクセスは、特定 mediaitem 型と EDS の特定バージョンの注文を並べ替えます。

[/media/{marketplaceId}/singleMediaGroupSearch](uri-medialocalesinglemediagroupsearch.md)

&nbsp;&nbsp;1 つのメディアのグループ内の項目を検索をできます。

<a id="ID4EFD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EHD"></a>


##### <a name="parent"></a>Parent

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)


<a id="ID4ERD"></a>


##### <a name="further-information"></a>詳細情報

[その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)
