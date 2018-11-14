---
title: EDS の補助 API
assetID: 5729ab80-e88d-0190-fb61-bd0cc4f134f6
permalink: en-us/docs/xboxlive/rest/eds-apis.html
author: KevinAsgari
description: " EDS の補助 API"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 791ec5e593d90cf52b91cca863df02da2db97f5f
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6254225"
---
# <a name="auxiliary-eds-apis"></a>EDS の補助 API

これにはいくつかのエンターテインメント探索サービス (EDS) については、コンテンツを直接指定しませんが、サービスを使用またはドライブの一般的な UI のモデルを支援する方法に関する一般的な情報を提供する Api があります。

<a id="ID4EQ"></a>


## <a name="auxiliary-apis"></a>補助 Api

| API| URI| 説明|
| --- | --- | --- |
| API のパラメーター値| /{ロケール}/メタデータ| サービスの呼び出しで使用できるパラメーターの値の列挙|
| コンテンツの規制ジェネレーターを組み合わせる| /{ロケール}/contentRating| 可能性のある好ましくないまたは明示的なコンテンツをフィルター処理するため、その他の Api で使用できる値を作成します。 詳細については以下をご覧ください。|
| 結合されたフィールド名ジェネレーター| /{ロケール}/fields| フィールドが返されるコントロールに詳細 Api で使用できる値を作成します。 詳細については以下をご覧ください。|

<a id="ID4EBC"></a>


### <a name="api-parameter-values"></a>API のパラメーター値

この API では、サービスで使用できるパラメーターについて説明します。 返された情報は、ローカライズされたテキストには、各パラメーターが付属しているため、クライアントの UI で使用できます。

None の下の Api は、クエリ パラメーターを受け入れます。

| API| URI| 説明|
| --- | --- | --- | --- | --- | --- |
| 型| /{ロケール} メタデータ/mediaGroups| メディアのグループの完全な一覧|
| メディア項目のメディアのグループごとの種類| /{ロケール}//metadata/mediagroups/{mediaItemTypeGroup}/mediaItemTypes| メディアのリスト項目の型指定されたメディア グループ内に含まれます。|
| すべてのメディア項目の種類| /{ロケール} メタデータ/mediaItemTypes| メディア項目の種類の完全な一覧|
| メディア項目の種類ごとのフィールド| /{ロケール}//metadata/mediaitemtypes/{mediaItemType}/fields| 1 つのメディア項目の種類のフィールドの一覧|
| クエリの絞り込み条件| /{ロケール}//metadata/mediaitemtypes/{mediaItemType}/queryRefiners| 指定したメディア項目の種類のサポートされているクエリの絞り込み条件の一覧|
| すべてのクエリ絞り込み条件値| /{ロケール}/メタデータ/metadata/mediaitemtypes/{mediaItemType}/queryrefiners/{queryRefiner}| 項目の種類を指定したメディアの指定されたクエリの絞り込み条件の値|
| 調整のサブ値を照会すべて| /{ロケール}/{queryRefiner} のメタデータ/metadata/mediaitemtypes/{mediaItemType}/queryrefiners//subQueryRefinerValues| 指定されたクエリの絞り込み条件値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧。 クエリの絞り込み条件値は、"queryRefinerValue"は、値を許可するクエリ絞り込み条件を渡すことが URI 語幹で禁止されている文字で行うという名前のクエリ文字列パラメーターとしてに渡されます。|
| 順に並べ替えます。| /{ロケール}//metadata/mediaitemtypes/{mediaItemType}/sortOrders| 指定したメディア項目の種類の並べ替え順序の一覧|

<a id="ID4EEF"></a>


### <a name="combined-content-rating-generator"></a>コンテンツの規制ジェネレーターを組み合わせる

保護者子が表示できるコンテンツを適用することは、複雑な作業です。 だけでなく各メディア項目の種類は、独自の評価システムがそれらの評価システムは国によって異なることができます。 これはすべての項目を正しくフィルターを指定する必要があるデータの複数の異なる部分があることを意味します。

すべての API 呼び出しでは、すべてのパラメーターを指定することではなくは、この API は、他の Api で combinedContentRating パラメーターに渡すし、引き続き同じ情報を伝える値を生成します。 これは、この API に渡されるいくつかのパラメーターは、その他の Api の 1 つの再利用可能な値に折りたたまれたとき、Api を使用し、保守、やすくするために設計されています。

頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース EDS の間など)、したがって、長期間のキャッシュ可能性があります。 CombinedContentRating パラメーターは、これを示すはわかりやすいエラー メッセージで渡した値が有効である場合、呼び出し元だけを受け入れ、いずれかの API は、更新された値を取得するには、もう一度この API を呼び出す必要があります。 指定されていなければ、API が combinedContentRating パラメーターを受け取る場合、コンテンツのフィルター処理は行われません保護者による制限に基づく

> [!NOTE]
> これとは限りません。 のみ"安全"コンテンツが返されること - すべてのコンテンツが返されること、明示的な可能性のあるコンテンツを含むことを意味)。



<a id="ID4EWF"></a>


### <a name="combined-field-name"></a>結合されたフィールド名

EDS Api では、既定では、非常に小さいフィールドの最小セット項目ごとに返されます。

   * メディア項目の種類
   * メディア グループ
   * ID
   * 名前

詳細を取得するのには、Api は、返されるデータや追加コンポーネントを指定する「フィールド」パラメーターを受け入れます。 多くの使用可能なフィールドがあるため、API 呼び出しごとに完全に自分の名前を指定することが大幅に膨張要求します。 代わりに、名前は、その他の Api に渡すことができるより小さい値を生成するこの API に渡すことができます。

このパラメーターを受け取る API, 指定された値が指定したメディア項目のすべての種類のすべてのフィールドのスーパー セットである必要があります。 さまざまなさまざまなメディア項目の種類のフィールドのセットを指定することはできません。 ただし、フィールドは、1 つのメディア項目の種類がない別、それに適用する場合にのみ表示、メディア項目の種類のデータが存在する (例: AvatarItems のみ"AvatarBodyType"がフィールド名の結合 API への呼び出しに含まれている場合は、フィールドが含まれて)。

この API から返される値は、実際に強くキャッシュ-、それらは変更されません除く EDS の展開の間でします。 キャッシュが必要な場合、キャッシュ最後のユーザーのセッションしなくなったことをお勧めします。

実際のフィールド名を受け付けるだけでなくこの API は、"all"を有効な値として受け取ります。 これにより、指定することは、各フィールドが含まれている値が生成されます。 "All"の値は、開発、デバッグ、テスト目的にのみ使用される可能性があります。

<a id="ID4ERG"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ETG"></a>


##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)


<a id="ID4E6G"></a>


##### <a name="further-information"></a>詳細情報

[マーケットプレース URI](../uri/marketplace/atoc-reference-marketplace.md)
