---
title: EDS の補助 API
assetID: 5729ab80-e88d-0190-fb61-bd0cc4f134f6
permalink: en-us/docs/xboxlive/rest/eds-apis.html
description: " EDS の補助 API"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3f2f729359f52b09879e7227ede71e238fe63801
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603237"
---
# <a name="auxiliary-eds-apis"></a>EDS の補助 API

これにはいくつかエンターテイメント検出サービス (EDS)、コンテンツに関する情報を直接提供はありませんが、ドライブの一般的な UI モデルをしたり、サービスを使用する方法に関する一般的な情報を提供する Api があります。

<a id="ID4EQ"></a>


## <a name="auxiliary-apis"></a>補助 Api

| API| URI| 説明|
| --- | --- | --- |
| API パラメーターの値| /{locale}/metadata| サービスの呼び出しで使用できるパラメーターの使用可能な値の列挙体|
| コンテンツのレーティングのジェネレーターを組み合わせる| /{locale}/contentRating| 好ましくないまたは明示的な可能性があるコンテンツをフィルター処理するため、他の Api で使用できる値を作成します。 詳細については、以下を参照してください。|
| 結合されたフィールド名ジェネレーター| /{locale}/fields| どのフィールドが返されるコントロールに Api の詳細に使用できる値を作成します。 詳細については、以下を参照してください。|

<a id="ID4EBC"></a>


### <a name="api-parameter-values"></a>API パラメーターの値

この API では、サービスで使用できるパラメーターについて説明します。 返される情報は、ローカライズされたテキストには、各パラメーターが付属しているためにクライアント UI で使用可能です。

以下に示した Api のいずれもには、すべてのクエリ パラメーターがそのまま使用します。

| API| URI| 説明|
| --- | --- | --- | --- | --- | --- |
| 型| /{locale}/metadata/mediaGroups| メディアのグループの完全な一覧|
| メディア アイテムの 1 つのメディアのグループの種類| /{locale}/metadata/mediaGroups/{mediaItemTypeGroup}/mediaItemTypes| メディアの一覧は、型指定されたメディアのグループに含まれる項目します。|
| すべてのメディア アイテムの種類| /{locale}/metadata/mediaItemTypes| メディア項目の種類の完全な一覧|
| メディア項目の種類ごとのフィールド| /{locale}/metadata/mediaItemTypes/{mediaItemType}/fields| 1 つのメディア項目の種類のフィールドの一覧|
| クエリの絞り込み条件| /{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners| 特定のメディア項目の種類のサポートされているクエリの絞り込み条件の一覧|
| すべてのクエリの調整値| /{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}| 指定されたメディアの指定されたクエリの絞り込み条件の値は、項目の種類|
| すべてのクエリの絞り込み条件のサブ値| /{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}/subQueryRefinerValues| 指定されたクエリの調整値 ("subgenres には、特定のジャンル"など) のサブの値のリスト。 クエリの絞り込み条件値でという名前の"queryRefinerValue"は、クエリに渡される URI のステムで禁止された文字を含むの絞り込み条件値を許可するには、クエリ文字列パラメーターとして渡されます。|
| 並べ替え| /{locale}/metadata/mediaItemTypes/{mediaItemType}/sortOrders| 特定のメディア項目の種類で並べ替え順の一覧|

<a id="ID4EEF"></a>


### <a name="combined-content-rating-generator"></a>コンテンツのレーティングのジェネレーターを組み合わせる

複雑なタスクは、子が参照を許可するコンテンツに対する保護者による制御を適用します。 だけでなくは各メディア項目の種類が、独自の評価システムが、これらの評価システムは、国を変更できます。 これはすべての項目を適切にフィルターを指定する必要があるデータのいくつかの異なる部分があることを意味します。

すべてのパラメーターを指定する、すべての API 呼び出しで、代わりには、この API は、他の Api で combinedContentRating パラメーターに渡すし、も同じ情報を通信に値を生成します。 これは、やすく Api を使用して、保守がその他の Api の 1 つの再利用可能な値にこの API に渡されるいくつかのパラメーターが折りたたまれている設計されています。

頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(EDS のリリース間など)、したがって、長期間のキャッシュ可能性があります。 CombinedContentRating パラメーターは、これを示す値には意味のあるエラー メッセージに渡された値が有効でない場合、呼び出し元だけを受け入れる任意の API は、更新された値を取得するには、もう一度この API を呼び出す必要があります。 API が受け取る combinedContentRating パラメーターでは、いずれかが指定されない場合、コンテンツのフィルター処理は行われません保護者による制限に基づく

> [!NOTE]
> 唯一の「安全な」コンテンツが返されるか--すべてのコンテンツが返されるか、明示的な可能性のあるコンテンツを含むことを意味からといって)。



<a id="ID4EWF"></a>


### <a name="combined-field-name"></a>結合されたフィールド名

EDS Api では、既定では、各項目のフィールドの場合は、非常に小さい最小セットを返します。

   * メディア項目の種類
   * メディアのグループ
   * ID
   * 名前

詳細を取得するには、Api は、する追加のデータを返す必要があるかを示す"fields"パラメーターを受け取ります。 多くの使用可能なフィールドがあるため、各 API 呼び出しの場合は full での名前を指定することは大幅に膨張要求。 代わりに、名前は、他の Api に渡すことができるくらい小さな値を生成するこの API に渡すことができます。

このパラメーターを受け取る任意の API、指定された値は指定されたメディアのすべての項目の種類のすべてのフィールドのスーパー セットである必要があります。 場合によっては、別のメディア項目の種類のフィールドのセットを指定することはできません。 ただし、フィールドが 1 つのメディア項目の種類がない別、それに適用される場合にのみ表示されます、メディア項目の種類のデータが存在します (例:"AvatarBodyType"は、フィールド名の組み合わせ API の呼び出しに含まれますが、AvatarItems のみ、フィールドが含まれます)。

この API から返される値は、実際にキャッシュ可能-、EDS のデプロイの間を除く、変更する必要がありますされません。 キャッシュが必要な場合、キャッシュいいえよりも長く、ユーザーのセッションをお勧めします。

実際のフィールド名を受け入れるだけでなくこの API は、"all"を有効な値として受け取ります。 これにより、指定することは、各フィールドが含まれる値が生成されます。 「すべて」の値は、開発、デバッグ、およびテスト目的でのみ使用される可能性があります。

<a id="ID4ERG"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ETG"></a>


##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)


<a id="ID4E6G"></a>


##### <a name="further-information"></a>詳細情報

[Marketplace の Uri](../uri/marketplace/atoc-reference-marketplace.md)
