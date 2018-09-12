---
title: 取得する (/media/{marketplaceId} フィールド/)
assetID: 1d535344-8522-0fd1-4daa-cd0f0a0f1121
permalink: en-us/docs/xboxlive/rest/uri-medialocalefieldsget.html
author: KevinAsgari
description: " 取得する (/media/{marketplaceId} フィールド/)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4c46981121393ce80228d857c32a01784d58af96
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881836"
---
# <a name="get-mediamarketplaceidfields"></a>取得する (/media/{marketplaceId} フィールド/)
フィールド トークンを取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EGC)
  * [クエリ文字列パラメーター](#ID4ERC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
エンターテイメント探索サービス (EDS) Api は、既定では、各項目のフィールドの非常に小さい最小セットを返します。
 
   * メディア項目の種類
   * メディアのグループ
   * ID
   * 名前
  
詳細を取得するのには、Api は、返されるデータや追加コンポーネントを指定する**フィールド**パラメーターを受け入れます。 多くの使用可能なフィールドがあるため、API 呼び出しごとに完全に名前を指定することが大幅に膨張要求します。 代わりに、名前は、他の Api に渡すことができるより小さい値を生成するこの API に渡すことができます。
 
このパラメーターを受け取るいずれかの API、指定された値がすべて指定したメディア項目の種類のすべてのフィールドのスーパー セットである必要があります。 別のメディア項目の種類のフィールドのセットを指定することはできません。 ただし、フィールドは、1 つのメディア項目の種類がない別、それに適用する場合はでのみ表示、メディア項目の種類のデータが存在する (の呼び出しで"AvatarBodyType"が含まれている場合など、[を取得する (/media/{marketplaceId} フィールド/)]()、AvatarItems のみがフィールドを含む)。
 
この API から返される値は実際に強くキャッシュ -、それらは変更されません以外 EDS の展開の間でします。 キャッシュが必要な場合、キャッシュ最後のユーザーのセッションよりもしなくなったことをお勧めします。
 
実際のフィールド名を受け入れ、だけでなくこの API は、"all"を有効な値として受け取ります。 これにより、指定することは、各フィールドが含まれている値が生成されます。 開発、デバッグ、テスト目的でのみの"all"の値の使用をお勧めします。
 
または、送信することができます`desired={list of fields separated by a '.'}`**フィールド**トークンを受け取るいずれかの API にします。
 
一緒**目的**と**フィールド**の両方に渡すことはできません。
  
<a id="ID4EGC"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。| 
  
<a id="ID4ERC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 目的| string| 必須。 '."-で区切られた最小セットのほかに返されるフィールドの一覧。 指定したすべてのフィールドは保証されています (データだけが存在しないの特定の項目の) オブジェクトごとに、返されるが、ここで指定されていない最小セットの外部のフィールドは返されません。 | 
  
<a id="ID4EMD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOD"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/フィールド](uri-medialocalefields.md)

  
<a id="ID4EYD"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS 一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   