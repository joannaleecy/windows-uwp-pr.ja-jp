---
title: /media/{marketplaceId}/details
assetID: bc8758ed-2f90-b501-5c3f-6f253f02d754
permalink: en-us/docs/xboxlive/rest/uri-medialocaledetails.html
description: " /media/{marketplaceId}/details"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f58e5247c3fd52e84a3a9bab28c6926f74e864e3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655707"
---
# <a name="mediamarketplaceiddetails"></a>/media/{marketplaceId}/details
プランの詳細、メタデータを返しますについて 1 つまたは複数の項目。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
API は、関連する API と参照 API によって異なります詳細 (と ID で passin) 詳細 API には、追加情報が返されますが、これらの Api が明示的または暗黙的に、fiven ID に関連付けられているその他の項目に関する情報を返すよう。同じ項目。
 
1 つに、別のメディア項目の種類の複数の Id を渡すことができます (限り ProviderContentID - 以下を参照型のない)、呼び出しが同じメディア グループに属している必要がありますすべて。 ただし、呼び出し元がメディアのグループを認識しないクライアント シナリオをいくつかがあります。 API は、media group の「不明」の次の状況での特殊値を許可することでこれをサポートします。
 
   * idType = XboxHexTitle、AppType またはゲームの種類のいずれかの項目が得られます
   * idType = ProviderContentId、MovieType または TVType 項目が得られます
  
次の図は、ID の型に提供できるメディア グループ全体のマッピングをまとめたものです。
 
| ID の種類| appType| ゲームの種類| MovieType| MusicArtistType| MusicType| TVType| WebVideoType| Unknown| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Canonical| Y| Y| Y| Y| Y| Y| Y| N| 
| ZuneCatalog| N| N| Y| Y| Y| Y| N| N| 
| ZuneMediaInstance| N| N| Y| N| Y| Y| N| N| 
| プラン| Y| Y| Y| N| Y| Y| N| N| 
| AMG| N| N| N| N| Y| N| N| N| 
| MediaNet| N| N| N| N| Y| N| N| N| 
| XboxHexTitle| Y| Y| N| N| N| N| N| Y| 
| ProviderContentId| N| N| Y| N| N| Y| N| Y| 
 
  * [パラメーターのノート](#ID4EEH)
  * [URI パラメーター](#ID4EUH)
 
<a id="ID4EEH"></a>

 
## <a name="parameter-notes"></a>パラメーターのノート
 
<a id="ID4EIH"></a>

 
### <a name="providercontentid"></a>ProviderContentId
 
これは、使用する検索プロバイダー固有の id。例: Netflix Id または Hulu id
 
IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。 これは、ProviderContentIds が唯一の種類の ID を含めることができるため、'.' 文字。 '.' 文字が Id 間で使用される区切り記号でも、新機能、delimieter Id 間の間であいまいさがあるし、新機能、ID 自体の一部です。 API の rest 一括ルックアップ機能を除く、ProviderContentIds の同じように動作します。
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| marketplaceId| string| 必須。 文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/media/{marketplaceId}/details)](uri-medialocaledetailsget.md)

&nbsp;&nbsp;プランの詳細、メタデータを返しますについて 1 つまたは複数の項目。 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a>Parent 

[Marketplace の Uri](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   