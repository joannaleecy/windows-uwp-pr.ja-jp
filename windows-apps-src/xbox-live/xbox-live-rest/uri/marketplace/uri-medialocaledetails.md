---
title: /media/{marketplaceId}/詳細
assetID: bc8758ed-2f90-b501-5c3f-6f253f02d754
permalink: en-us/docs/xboxlive/rest/uri-medialocaledetails.html
author: KevinAsgari
description: " /media/{marketplaceId}/詳細"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7b8dcea7c0987a2bc783adae0398c9579ded2fe8
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881502"
---
# <a name="mediamarketplaceiddetails"></a>/media/{marketplaceId}/詳細
返しますの詳細とメタデータを提供する方法の 1 つまたは複数の項目。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
API は、関連する API と参照 API によって異なります詳細 (とき、ID で passin) は、詳細 API には、追加の情報が返されます。 一方、それらの Api が、暗黙的または明示的に fiven ID に関連付けられているその他の項目に関する情報を返す。同じ項目。
 
別のメディア項目の種類の複数の Id は、1 つに渡すことができます (限り ProviderContentID - 以下を参照型の不明) を呼び出してが同じメディア グループに属するすべてする必要があります。 ただし、これには、呼び出し元がメディアのグループを認識しないクライアントのシナリオのいくつかがあります。 API では、これを使用して、次のような状況でのメディアのグループには、"Unknown"の特殊値のことを許可します。
 
   * idType = AppType またはゲームの種類のいずれかの項目が生成される XboxHexTitle
   * idType = MovieType または TVType 項目が生成される ProviderContentId
  
次の図は、どのメディア グループと ID の種類を提供できます全体のマッピングをまとめたものです。
 
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
 
これ検索プロバイダーを使用して、特定の id など。 Netflix Id または Hulu id。
 
IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。 これは、ProviderContentIds は種類の ID が含まれるだけであるため、'.' 文字です。 '.' 文字がする Id 間の区切り文字でも、新機能、delimieter Id 間の間にあいまいさがおよび ID 自体の一部はします。 API の残りの部分、一括検索機能を除く、ProviderContentIds の同じように動作します。
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| marketplaceId| string| 必須。 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[取得する (/media/{marketplaceId}/詳細)](uri-medialocaledetailsget.md)

&nbsp;&nbsp;返しますの詳細とメタデータを提供する方法の 1 つまたは複数の項目。 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a>Parent 

[Marketplace Uri](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   