---
title: /media/{marketplaceId}/details
assetID: bc8758ed-2f90-b501-5c3f-6f253f02d754
permalink: en-us/docs/xboxlive/rest/uri-medialocaledetails.html
author: KevinAsgari
description: " /media/{marketplaceId}/details"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7b8dcea7c0987a2bc783adae0398c9579ded2fe8
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4054909"
---
# <a name="mediamarketplaceiddetails"></a>/media/{marketplaceId}/details
返しますプランの詳細とメタデータについての 1 つまたは複数の項目です。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
API は、関連する API と参照 API によって異なります詳細 (とき、ID で passin) 詳細 API には、追加の情報が返されますが、それらの Api は、暗黙的または明示的に fiven ID に関連付けられているその他の項目に関する情報を返すよう。同じ項目。
 
別のメディア項目の種類の複数の Id は、1 つに渡すことができます (限り ProviderContentID - 以下を参照型のわからない)、呼び出しが同じメディア グループに属するすべてする必要があります。 ただし、これには、呼び出し元がメディアのグループを認識しないクライアントのシナリオのいくつかがあります。 API では、これを使用して、次のような状況でのメディアのグループには、"Unknown"の特殊値のことを許可します。
 
   * idType = XboxHexTitle で、AppType またはゲームの種類のいずれかの項目が生成されます
   * idType = ProviderContentId で、MovieType または TVType 項目が生成されます
  
次の図は、どのメディア グループと ID の種類を指定できます全体のマッピングをまとめたものです。
 
| ID の種類| AppType| ゲームの種類| MovieType| MusicArtistType| MusicType| TVType| WebVideoType| Unknown| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 正規| Y| Y| Y| Y| Y| Y| Y| N| 
| ZuneCatalog| N| N| Y| Y| Y| Y| N| N| 
| ZuneMediaInstance| N| N| Y| N| Y| Y| N| N| 
| 提案| Y| Y| Y| N| Y| Y| N| N| 
| AMG| N| N| N| N| Y| N| N| N| 
| MediaNet| N| N| N| N| Y| N| N| N| 
| XboxHexTitle| Y| Y| N| N| N| N| N| Y| 
| ProviderContentId| N| N| Y| N| N| Y| N| Y| 
 
  * [パラメーターの注意事項](#ID4EEH)
  * [URI パラメーター](#ID4EUH)
 
<a id="ID4EEH"></a>

 
## <a name="parameter-notes"></a>パラメーターの注意事項
 
<a id="ID4EIH"></a>

 
### <a name="providercontentid"></a>ProviderContentId
 
これは、検索プロバイダーを使用特定 id。 例。 Netflix Id または Hulu id。
 
IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。 これは、ProviderContentIds は種類の ID が含まれるだけであるため、'.' 文字です。 '.' 文字は使用 Id 間の区切り文字でも、新機能の Id の間で delimieter の間にあいまいさがおよび ID 自体の一部は何です。 API の残りの部分一括検索機能を除く、ProviderContentIds の同じように動作します。
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/media/{marketplaceId}/details)](uri-medialocaledetailsget.md)

&nbsp;&nbsp;返しますプランの詳細とメタデータについての 1 つまたは複数の項目です。 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a>Parent 

[マーケットプレース URI](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   