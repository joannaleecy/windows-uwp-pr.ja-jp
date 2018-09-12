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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882194"
---
# <a name="marketplace-uris"></a>Marketplace Uri

このセクションでは、*市場*のサービスとも呼ばれるエンターテイメント探索サービス (EDS) 用の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。

Xbox 360、Windows Phone デバイスの場合、または Xbox.com を実行しているゲームのみでは、このサービスを使用できます。

これらの Uri のドメイン eds.xboxlive.com、inventory.xboxlive.com です。

<a id="ID4EPB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/me/inventory](uri-inventory.md)

&nbsp;&nbsp;指定されたユーザーに関連付けられているインベントリのセットにアクセスします。

[ユーザー/me/コンシューマブル/{itemID}](uri-inventoryconsumablesitemurl.md)

&nbsp;&nbsp;特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。

[/inventory/{itemID}](uri-inventoryitemurl.md)

&nbsp;&nbsp;特定のインベントリ項目の詳細情報の完全なセットにアクセスします。

[/media/{marketplaceId}/crossMediaGroupSearch](uri-localecrossmediagroupsearch.md)

&nbsp;&nbsp;いくつかの異なるメディア グループからアクセス項目。

[/media/{marketplaceId} 参照/](uri-medialocalebrowse.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目を参照できます。

[/media/{marketplaceId}/contentRating](uri-medialocalecontentrating.md)

&nbsp;&nbsp;コンテンツの規制トークンにアクセスします。

[/media/{marketplaceId}/詳細](uri-medialocaledetails.md)

&nbsp;&nbsp;返しますの詳細とメタデータを提供する方法の 1 つまたは複数の項目。

[/media/{marketplaceId}/フィールド](uri-medialocalefields.md)

&nbsp;&nbsp;フィールド トークンにアクセスします。

[/media/{marketplaceId}/メタデータ/mediaGroups](uri-medialocalemetadatamediagroups.md)

&nbsp;&nbsp;すべてのサポートされている mediaGroups EDS の特定のバージョンの一覧を示します。

[/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

&nbsp;&nbsp;指定されたバージョン EDS のメディアのグループごとの利用可能な mediaItemTypes にアクセスします。

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType}/フィールド](uri-medialocalemetadatamediaitemtypefields.md)

&nbsp;&nbsp;いずれか、特定の mediaitemtype と EDS の特定のバージョンのデータとアクセス フィールド。

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

&nbsp;&nbsp;特定のメディア項目の種類のクエリ絞り込み条件にアクセスします。

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

&nbsp;&nbsp;指定されたクエリの調整名と、特定のメディア項目の種類で許容される値にアクセスします。

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

&nbsp;&nbsp;指定されたクエリの調整値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧にアクセスします。

[/media/{marketplaceId}/メタデータ/mediaItemTypes](uri-medialocalemetadatamediaitemtypes.md)

&nbsp;&nbsp;特定の EDS バージョンのサポートされているすべての mediaItemTypes にアクセスします。

[/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/sortorders](uri-medialocalemetadatamediaitemtypesortorders.md)

&nbsp;&nbsp;利用可能なアクセス mediaitem の特定の種類と EDS の特定のバージョンの注文を並べ替えます。

[/media/{marketplaceId}/singleMediaGroupSearch](uri-medialocalesinglemediagroupsearch.md)

&nbsp;&nbsp;1 つのメディア グループ内の項目を検索をできます。

<a id="ID4EFD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EHD"></a>


##### <a name="parent"></a>Parent

[ユニバーサル リソース識別子 (URI) の参照](../atoc-xboxlivews-reference-uris.md)


<a id="ID4ERD"></a>


##### <a name="further-information"></a>詳細情報

[その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)
