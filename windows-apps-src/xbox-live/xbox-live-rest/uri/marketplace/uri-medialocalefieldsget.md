---
title: GET (/media/{marketplaceId}/fields)
assetID: 1d535344-8522-0fd1-4daa-cd0f0a0f1121
permalink: en-us/docs/xboxlive/rest/uri-medialocalefieldsget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/fields)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4c46981121393ce80228d857c32a01784d58af96
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4612556"
---
# <a name="get-mediamarketplaceidfields"></a>GET (/media/{marketplaceId}/fields)
フィールド トークンを取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EGC)
  * [クエリ文字列パラメーター](#ID4ERC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
エンターテイメント探索サービス (EDS) 既定では、Api は、各項目のフィールドの場合は、非常に小さい最小セットを返します。
 
   * メディア項目の種類
   * メディア グループ
   * ID
   * 名前
  
詳細を取得するのには、Api は、返されるデータや追加コンポーネントを指定する**フィールド**パラメーターを受け入れます。 多くの使用可能なフィールドがあるため、API 呼び出しごとに完全にその名前を指定することが大幅に膨張要求します。 代わりに、名前は、その他の Api に渡すことができるより小さい値を生成するこの API に渡すことができます。
 
このパラメーターを受け取る API, 指定された値が指定したメディア項目のすべての種類のすべてのフィールドのスーパー セットである必要があります。 別のメディア項目の種類のフィールドの別のセットを指定することはできません。 ただし、フィールドは、1 つのメディア項目の種類がない別、それに適用する場合にのみ表示、メディア項目の種類のデータが存在する (への呼び出しで"AvatarBodyType"が含まれている場合に、[を取得する (/media/{marketplaceId}/fields)]()、AvatarItems のみがフィールドを含む)。
 
この API から返される値は、実際に強くキャッシュ--、それらは変更されません以外 EDS の展開の間でします。 キャッシュが必要な場合、キャッシュ最後のユーザーのセッションよりもしなくなったことをお勧めします。
 
実際のフィールド名を受け付けるだけでなくこの API は、"all"を有効な値として受け取ります。 これにより、指定することは、各フィールドが含まれている値が生成されます。 "All"の値の使用は、開発、デバッグ、テスト目的でに対してのみお勧めします。
 
または、送信することができます`desired={list of fields separated by a '.'}`**フィールド**トークンを受け取るいずれかの API にします。
 
一緒**目的**と**フィールド**の両方に渡すことはできません。
  
<a id="ID4EGC"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。| 
  
<a id="ID4ERC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 目的| string| 必須。 '."-で区切られた最小セットのほかに返されるフィールドの一覧。 指定したすべてのフィールドは保証されています (データだけが存在しないの特定の項目の) オブジェクトごとに、返されるが、ここで指定されていない最小セットの外部のフィールドは返されません。 | 
  
<a id="ID4EMD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOD"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/fields](uri-medialocalefields.md)

  
<a id="ID4EYD"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 共通ヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS クエリの絞り込み条件](../../additional/edsqueryrefiners.md)

 [マーケットプレース URI](atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   