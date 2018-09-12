---
title: Marketplace Uri
assetID: 27b6035f-84b9-67a8-6a12-85c450d18a58
permalink: en-us/docs/xboxlive/rest/atoc-reference-marketplace.html
author: KevinAsgari
description: " Marketplace Uri"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4be83e2d4301a708a705a8bec0a1d975b6435bc5
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3930223"
---
# <a name="marketplace-uris"></a>Marketplace Uri

このセクションでは、*市場*サービスとも呼ばれますエンターテイメント探索サービス (EDS) 用の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。

Xbox 360、Windows Phone デバイス、または Xbox.com を実行しているゲームだけでは、このサービスを使用できます。

これらの Uri ドメインは eds.xboxlive.com inventory.xboxlive.com です。

<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/me/inventory](uri-inventory.md)

&nbsp;&nbsp;指定されたユーザーに関連付けられているインベントリのセットにアクセスします。

[ユーザー/me/コンシューマブル/{itemID}](uri-inventoryconsumablesitemurl.md)

&nbsp;&nbsp;特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。

[/inventory/{itemID}](uri-inventoryitemurl.md)

&nbsp;&nbsp;特定のインベントリ項目の詳細情報の完全なセットにアクセスします。

[/media/{marketplaceId}/crossMediaGroupSearch](uri-localecrossmediagroupsearch.md)

&nbsp;&nbsp;いくつかの異なるメディア グループからの項目にアクセスします。

[/media/{marketplaceId} 参照/](uri-medialocalebrowse.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目を参照できます。

[/media/{marketplaceId}/contentRating](uri-medialocalecontentrating.md)

&nbsp;&nbsp;コンテンツの規制トークンにアクセスします。

[/media/{marketplaceId}/詳細](uri-medialocaledetails.md)

&nbsp;&nbsp;返します提供の詳細とメタデータについての 1 つまたは複数の項目です。

[/media/{marketplaceId} フィールド/](uri-medialocalefields.md)

&nbsp;&nbsp;フィールド トークンにアクセスします。

[メタデータ/mediaGroups/media/{marketplaceId}](uri-medialocalemetadatamediagroups.md)

&nbsp;&nbsp;指定した EDS バージョンのサポートされているすべての mediaGroups の一覧を示します。

[/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

&nbsp;&nbsp;指定されたバージョン EDS のメディアのグループごとの利用可能な mediaItemTypes にアクセスします。

[/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaItemType} フィールド/](uri-medialocalemetadatamediaitemtypefields.md)

&nbsp;&nbsp;指定された mediaitemtype と EDS の特定のバージョンのデータを期待いずれかからアクセス フィールド。

[/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/queryrefiners](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

&nbsp;&nbsp;指定したメディア項目の種類のクエリ絞り込み条件にアクセスします。

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

&nbsp;&nbsp;メディア項目の種類が与えられると、指定されたクエリの絞り込み条件名は、利用可能な値にアクセスします。

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

&nbsp;&nbsp;指定されたクエリ調整値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧にアクセスします。

[メタデータ/mediaItemTypes/media/{marketplaceId}](uri-medialocalemetadatamediaitemtypes.md)

&nbsp;&nbsp;指定した EDS バージョンのサポートされているすべての mediaItemTypes にアクセスします。

[/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/sortorders](uri-medialocalemetadatamediaitemtypesortorders.md)

&nbsp;&nbsp;利用可能なアクセスは、特定 mediaitem 型と EDS の特定のバージョン向けの注文を並べ替えます。

[/media/{marketplaceId}/singleMediaGroupSearch](uri-medialocalesinglemediagroupsearch.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目の検索を許可します。

<a id="ID4EFD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EHD"></a>


##### <a name="parent"></a>Parent

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)


<a id="ID4ERD"></a>


##### <a name="further-information"></a>詳細情報

[その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)
