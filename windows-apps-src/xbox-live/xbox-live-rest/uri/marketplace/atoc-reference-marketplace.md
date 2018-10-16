---
title: マーケットプレース URI
assetID: 27b6035f-84b9-67a8-6a12-85c450d18a58
permalink: en-us/docs/xboxlive/rest/atoc-reference-marketplace.html
author: KevinAsgari
description: " マーケットプレース URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4be83e2d4301a708a705a8bec0a1d975b6435bc5
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4682286"
---
# <a name="marketplace-uris"></a>マーケットプレース URI

このセクションでは、*市場*サービスとも呼ばれますエンターテイメント探索サービス (EDS) 用の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) メソッドの詳細を提供します。

Xbox 360、Windows Phone デバイス、または Xbox.com を実行しているゲームのみでは、このサービスを使用できます。

これらの Uri ドメイン eds.xboxlive.com、inventory.xboxlive.com です。

<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/me/inventory](uri-inventory.md)

&nbsp;&nbsp;指定されたユーザーに関連付けられているインベントリのセットにアクセスします。

[/users/me/consumables/{itemID}](uri-inventoryconsumablesitemurl.md)

&nbsp;&nbsp;特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。

[/inventory/{itemID}](uri-inventoryitemurl.md)

&nbsp;&nbsp;特定のインベントリ項目の詳細情報の完全なセットにアクセスします。

[/media/{marketplaceId}/crossMediaGroupSearch](uri-localecrossmediagroupsearch.md)

&nbsp;&nbsp;いくつかの異なるメディア グループからの項目をアクセスします。

[/media/{marketplaceId}/browse](uri-medialocalebrowse.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目を参照できます。

[/media/{marketplaceId}/contentRating](uri-medialocalecontentrating.md)

&nbsp;&nbsp;コンテンツの規制トークンにアクセスします。

[/media/{marketplaceId}/details](uri-medialocaledetails.md)

&nbsp;&nbsp;返しますの詳細とメタデータを提供する方法の 1 つまたは複数の項目。

[/media/{marketplaceId}/fields](uri-medialocalefields.md)

&nbsp;&nbsp;フィールド トークンにアクセスします。

[/media/{marketplaceId}/metadata/mediaGroups](uri-medialocalemetadatamediagroups.md)

&nbsp;&nbsp;EDS の特定のバージョンのサポートされているすべての mediaGroups の一覧を示します。

[/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

&nbsp;&nbsp;EDS の特定のバージョンのメディアのグループごとの利用可能な mediaItemTypes にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields](uri-medialocalemetadatamediaitemtypefields.md)

&nbsp;&nbsp;指定された mediaitemtype と指定したバージョン EDS のために、データを期待いずれかからアクセス フィールド。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

&nbsp;&nbsp;指定したメディア項目の種類のクエリの絞り込み条件にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

&nbsp;&nbsp;指定されたクエリの絞り込み条件名、およびメディア項目の種類に利用可能な値にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

&nbsp;&nbsp;指定されたクエリの絞り込み条件値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes](uri-medialocalemetadatamediaitemtypes.md)

&nbsp;&nbsp;EDS の特定のバージョンのサポートされているすべての mediaItemTypes にアクセスします。

[/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders](uri-medialocalemetadatamediaitemtypesortorders.md)

&nbsp;&nbsp;利用可能なアクセスは、指定された mediaitem 型と指定したバージョン EDS の注文を並べ替えます。

[/media/{marketplaceId}/singleMediaGroupSearch](uri-medialocalesinglemediagroupsearch.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目の検索を許可します。

<a id="ID4EFD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EHD"></a>


##### <a name="parent"></a>Parent

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)


<a id="ID4ERD"></a>


##### <a name="further-information"></a>詳細情報

[その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)
