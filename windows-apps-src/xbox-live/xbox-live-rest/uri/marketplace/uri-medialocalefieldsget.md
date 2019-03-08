---
title: GET (/media/{marketplaceId}/fields)
assetID: 1d535344-8522-0fd1-4daa-cd0f0a0f1121
permalink: en-us/docs/xboxlive/rest/uri-medialocalefieldsget.html
description: " GET (/media/{marketplaceId}/fields)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cc3ae8abfe04b7a0b9728d07b9488f9ed7c27816
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606677"
---
# <a name="get-mediamarketplaceidfields"></a>GET (/media/{marketplaceId}/fields)
フィールドのトークンを取得します。 これらの Uri のドメインが`eds.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EGC)
  * [クエリ文字列パラメーター](#ID4ERC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
エンターテイメント検出サービス (EDS) Api は、既定では、各項目のフィールドの場合は、非常に小さい最小セットが返されます。
 
   * メディア項目の種類
   * メディアのグループ
   * ID
   * 名前
  
詳細情報を表示するには、Api 同意、**フィールド**する追加のデータを返す必要があるかを指定するパラメーターです。 多くの使用可能なフィールドがあるため、各 API 呼び出しの場合は full での名前を指定することは大幅に膨張要求。 代わりに、名前は、他の Api に渡すことができるくらい小さな値を生成するこの API に渡すことができます。
 
このパラメーターを受け取る任意の API、指定された値は指定されたメディアのすべての項目の種類のすべてのフィールドのスーパー セットである必要があります。 場合によっては、別のメディア項目の種類のフィールドのセットを指定することはできません。 ただし、フィールドが 1 つのメディア項目の種類がない別、それに適用される場合にのみ表示されます、メディア項目の種類のデータが存在します (への呼び出しで"AvatarBodyType"が含まれている場合など、[取得 (/media/{marketplaceId} フィールド/)](uri-medialocalefields.md)のみAvatarItems にはフィールドが含まれて、)。
 
この API から返される値は、実際にキャッシュ可能 -、EDS のデプロイの間を除く、変更する必要がありますされません。 キャッシュが必要な場合、キャッシュいいえよりも長く、ユーザーのセッションをお勧めします。
 
実際のフィールド名を受け入れるだけでなくこの API は、"all"を有効な値として受け取ります。 これにより、指定することは、各フィールドが含まれる値が生成されます。 「すべて」の値の使用は、開発、デバッグ、およびテスト目的でのみ推奨されます。
 
送信する代わりに、`desired={list of fields separated by a '.'}`を受け入れる任意の API に、**フィールド**トークンです。
 
両方に渡すことはできません**目的**と**フィールド**化します。
  
<a id="ID4EGC"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| marketplaceId| string| 必須。 文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。| 
  
<a id="ID4ERC"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 必要な| string| 必須。 '.'-だけでなく、最小セットが返されるフィールドの区切りのリスト。 指定されたすべてのフィールド (データが単に存在しない特定の項目) の各オブジェクトに対して返されることが保証されますが、ここで指定されていない最小セットの範囲外のフィールドは返されません。 | 
  
<a id="ID4EMD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOD"></a>

 
##### <a name="parent"></a>Parent 

[/media/{marketplaceId}/fields](uri-medialocalefields.md)

  
<a id="ID4EYD"></a>

 
##### <a name="further-information"></a>詳細情報 

[EDS の一般的なヘッダー](../../additional/edscommonheaders.md)

 [EDS パラメーター](../../additional/edsparameters.md)

 [EDS は、絞り込み条件をクエリします。](../../additional/edsqueryrefiners.md)

 [Marketplace の Uri](atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   