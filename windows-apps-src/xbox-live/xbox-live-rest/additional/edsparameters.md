---
title: EDS パラメーター
assetID: 9475b427-53bc-697b-6d24-1787320260b7
permalink: en-us/docs/xboxlive/rest/edsparameters.html
description: " EDS パラメーター"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5412bcebc73dfd25d81b2073527e64e81de1bba4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655417"
---
# <a name="eds-parameters"></a>EDS パラメーター

<a id="ID4EO"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

これらのクエリ パラメーターは、必ずしもすべてでは受け入れられません[エンターテイメント検出サービス (EDS) Api](../uri/marketplace/atoc-reference-marketplace.md)、すべてが 1 つ以上の API で受け入れられますが、します。

| パラメーター| 種類| 説明|
| --- | --- | --- |
| combinedContentRating| string| (省略可能)。 参照してください[取得 (/media/{marketplaceId}/contentRating)](../uri/marketplace/uri-medialocalecontentratingget.md)します。|
| continuationToken| string| (省略可能)。 継続トークンは、特定のシナリオでの改ページのサービスが必要な情報を含む非透過 blob です。 値を省略すると、結果の最初のページが返されます (ページ サイズはによって決まり、maxItems パラメーター)、結果の 2 ページ目を取得するために使用する継続トークンと共にします。 2 番目のページを結果の 3 番目のページの継続トークンが含まれてし、します。|
| 必要な| string| (省略可能)。 結合されたフィールド名の API を参照してください。|
| desiredMediaItemTypes| 文字列の配列| (省略可能)。 このパラメーターは、応答で返される項目の種類を決定します。|
| ドメイン| string| (省略可能)。 ドメインのパラメーターは、ゲームとアプリ marketplace コンテキストを指定します。 でのクライアントが呼び出すことです。 既定では、ドメインは、「最新」クライアントが Xbox One のコンテンツを求めることのみを示すしますは。 クライアントが画面の Xbox 360 コンテンツにドメインを切り替える場合、"Xbox360"としてドメインを指定にする必要があります。 現時点では、クロス ドメインの結果はサポートされていません。 設定可能な値は、次のとおりです。 <ul><li>Xbox360</li><li>最新</li></ul> "Xbox360"値は、singleMediaGroupSearch にのみサポートされます。 参照と詳細がサポートされています。 crossMediaGroupSearch はサポートされていませんし、400 エラーが返されます。|
| フィールド| string| (省略可能)。 参照してください[取得 (/media/{marketplaceId} フィールド/)](../uri/marketplace/uri-medialocalefieldsget.md)します。|
| firstPartyOnly| ブール値| オプションのフィルター パラメーターです。 のみファースト パーティのコンテンツが返されるかどうか、または両方最初に、サード パーティ コンテンツ クエリから返されるかどうかを判断します。 |
| freeOnly| ブール値| オプションのフィルター パラメーターです。 コンテンツにのみ解放する結果を制限します。|
| GroupBy| TK| GroupBy パラメーターは、1 つの結果セットではなく、結果セットのグループに分類するために使用されます。 このパラメーターを指定すると、結果の各バケット内の項目の数の maxItems パラメーターによって決まり、項目の複数のリストを返すように設定を変更します。 <ul><li>MediaGroup - 結果が MediaGroup によってグループ化されます。</li></ul> |
| hasTrailer| ブール値| オプションのフィルター パラメーターです。 返された項目がトレーラーを含める必要があるかどうか、またはトレーラーを持つかどうかは省略可能を決定します。 値が true の場合、すべての項目は、トレーラーが必要です。|
| id| string| (省略可能)。 指定した場合、その ID を持つ項目の子にのみ結果を制限します。 このパラメーターが指定されている場合 MediaItemType も指定する必要があります。 |
| id| 文字列の配列| 必須。 すべての詳細情報が返されます (最大 10) の Id。 いずれかの ID をメモに無効な文字が含まれています (ProviderContentId 型 Id は通常の完全な Url 自体およびしたがって無効な文字が含まれて) の URL は、EDS に正しく送信される URL エンコードする必要があります。|
| idType| string| (省略可能)。 Id パラメーターに渡された Id の型。 有効な値は次のとおりです。 <ul><li>正規 (Bing と Marketplace)</li><li>XboxHexTitle (アプリ、コンソールでの再生)</li></ul>  すべて提供される Id が同じ idType を共有する必要があります。 この値を省略した場合、すべての Id が Canonical と見なされます。|
| latestOnly| ブール値| オプションのフィルター パラメーターです。 結果は、最新のリリース日付のものだけを制限します。|
| maxItems| 32 ビット符号付き整数| (省略可能)。 呼び出しから返される項目の最大数を決定します。 有効な値は、1 から 25 まで、包括的な番号です。 パラメーターは、省略した場合に、25 既定値です。|
| mediaGroup| string| (省略可能)。 Id のメディアのグループ。 すべて提供される Id が同じメディア グループを共有する必要があります。|
| MediaItemType| string| (省略可能)。 ID を持つが、id パラメーターで指定された項目の種類。 Id パラメーターが指定されている場合、このパラメーターも指定してください。|
| OrderBy| string| 必須。 OrderBy パラメーターは、返される項目の並べ替え方法を決定します。 このフィールドの一般的な値がここでは、表示されているが、一部の Api は、追加の値をサポート可能性があります。<ul><li>playCountDaily の回数が最も新しい日、メディアの再生します。</li><li>freeAndPaidCountDaily - で最新の日付の無料および有料の購入の数。</li><li>paidCountAllTime - 唯一有料購買、すべての期間の数。</li><li>paidCountDaily - 最新の日の有料購入回数によって。</li><li>digitalReleaseDate - ダウンロードの利用可能な日付。</li><li>releaseDate - ストアで使用可能な日付 (該当する場合)、デジタルのリリース日にフォールバックします。</li><li>userRatings - 平均ユーザー評価をします。</li></ul> |
| preferredProvider| string| (省略可能)。 ユーザーに推奨コンテンツ プロバイダー、Comcast Xfinity または Verizon FIOS などがある場合でそのプロバイダーの ID を渡すことできます。 項目ごとに、変更されない項目の実際の順序指定されたプロバイダーの情報が表示されますプロバイダーの一覧の上部にある (優先コンテンツ プロバイダーに使用可能な項目がある場合)。|
| q| string| 必須。 検索で使用される用語のクエリを実行します。|
| queryRefiners| 文字列の配列| (省略可能)。 一覧を参照してください。 [EDS クエリ絞り込み条件](edsqueryrefiners.md)します。|
| 関係| string| (省略可能)。 指定されたリレーションシップ型に一致するその他の製品を検索するベースとして ID パラメーターを使用するフィルター。 <ul><li>bundledWith - ID パラメーターがこれらのバンドルの一部として含めるバンドルの製品を検索します。</li><li>bundledProducts - は、ID パラメーターで指定されたバンドルに含まれている製品を検索します。</li></ul>  (参照呼び出しで返されることができます)、marketplace に表示される唯一の製品は、このパラメーターで返されます。 バンドルに非表示の製品がある場合は、バンドルの一部ではまだが、これらの結果では返されません。|
  | ScopeId | string | このパラメーターは、ビデオ メディアの逆引き参照シナリオに使用されます。 |
  | ScopeIdType | string | このパラメーターは、ビデオ メディアの逆引き参照シナリオに使用されます。 設定可能な値:タイトル。 |
  | skipItems | 32 ビット符号付き整数 | (省略可能)。 クロス グループ以外のシナリオでのページング、skipItems パラメーターは項目の数が既に確認されているかを判断するために使用 (およびそのためどのような項目を表示する必要があります最初に、結果セット)。 値が 0 から始まるため skipItems = 0 (または単に skipItems を指定していない)、リストの先頭の取得を開始します。 skipItems = 3 は、リスト内の最初の 3 つの項目をスキップし、4 番目の項目を使用した取得を開始します。 |
  | subscriptionLevel | 文字列の配列 | オプションのフィルター パラメーターです。 SubscriptionLevel パラメーターは、(かどうか、ユーザーは、有料のサブスクリプションまたは無料のサブスクリプションが) などのユーザーのサブスクリプションの種類が決定します。 使用可能な値は次のとおりです。 <ul><li>ゴールド:ユーザーが有料サブスクリプション</li><li>シルバー:ユーザーは、無料のサブスクリプションです。</li></ul>  |
| ターゲット ・ デバイス| string| デバイスを対象にフィルター処理する柔軟性を提供 EDS を提供します。 項目の返されるオファー (ProviderContent または可用性) は、ターゲット デバイスに制限できます。|
| topRatedOnly| ブール値| オプションのフィルター パラメーターです。 結果は、で揃えてコンテンツのみを制限します。|

<a id="ID4EGEAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EIEAC"></a>


### <a name="parent"></a>Parent

[その他の参照](atoc-xboxlivews-reference-additional.md)


<a id="ID4EUEAC"></a>


### <a name="further-information"></a>詳細情報

[Marketplace の Uri](../uri/marketplace/atoc-reference-marketplace.md)
