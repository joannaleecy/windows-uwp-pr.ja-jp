---
title: EDS パラメーター
assetID: 9475b427-53bc-697b-6d24-1787320260b7
permalink: en-us/docs/xboxlive/rest/edsparameters.html
author: KevinAsgari
description: " EDS パラメーター"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6d3ab2880bee2e6a6f5cf7a5350244e786e5e615
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4535114"
---
# <a name="eds-parameters"></a>EDS パラメーター

<a id="ID4EO"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

これらのクエリ パラメーターは必ずしもすべて[エンターテイメント探索サービス (EDS) Api](../uri/marketplace/atoc-reference-marketplace.md)で受け入れられませんが、複数の 1 つの API で承認されてすべて。

| パラメーター| 型| 説明|
| --- | --- | --- |
| combinedContentRating| string| 省略可能。 参照してください[GET (/media/{marketplaceId}/contentRating)](../uri/marketplace/uri-medialocalecontentratingget.md)します。|
| continuationToken| 文字列| 省略可能。 継続トークンでは、特定のシナリオで改ページのサービスが必要な情報が含まれている不透明な blob です。 値を省略すると、結果の最初のページが返されます (、ページのサイズが決定 maxItems パラメーターによって) と共に継続トークン結果の 2 番目のページを取得するために使用できます。 2 番目のページを結果のページには 3 つ目の継続トークンを含むし、ようにします。|
| 必要に応じてください。| string| 省略可能。 結合されたフィールド名 API を参照してください。|
| desiredMediaItemTypes| 文字列の配列| 省略可能。 このパラメーターは、応答で返される項目の種類を決定します。|
| ドメイン| string| 省略可能。 ドメインのパラメーターは、ゲームとアプリの市場のコンテキストを決定します。 クライアントがの呼び出しにします。 既定では、ドメインは、「最新」を示す、クライアントが Xbox One コンテンツを求めることだけです。 クライアントが Xbox 360 のサーフェスのコンテンツにドメインを切り替える場合、そのドメインを指定する"Xbox360"としてする必要があります。 現時点では、ドメインを越えた結果はサポートされていません。 設定可能な値は、次のとおりです。 <ul><li>Xbox360</li><li>最新</li></ul> "Xbox360"の値は、singleMediaGroupSearch にのみサポートされます。 参照と詳細情報がサポートされています。 crossMediaGroupSearch はサポートされておらず、400 エラーが返されます。|
| フィールド| string| 省略可能。 参照してください[GET (/media/{marketplaceId}/fields)](../uri/marketplace/uri-medialocalefieldsget.md)します。|
| firstPartyOnly| ブール値| 省略可能なフィルターのパラメーターです。 ファースト パーティのみコンテンツが返されるかどうか、または両方ファースト パーティとサード パーティ コンテンツがクエリから返されるかどうかを決定します。 |
| freeOnly| ブール値| 省略可能なフィルターのパラメーターです。 のみコンテンツを解放するための結果を制限します。|
| GroupBy| TK| GroupBy パラメーターは、単一の結果セットではなく、結果セットをグループに分類のために使用されます。 このパラメーターを指定すると、結果を maxItems パラメーターによって各バケット内の項目の数を決定する場所の項目を複数のリストを返すセットが変更されます。 <ul><li>MediaGroup - 結果が MediaGroup によってグループ化されます。</li></ul> |
| hasTrailer| ブール値| 省略可能なフィルターのパラメーターです。 返された項目にトレーラーを含める必要があるかどうか、またはトレーラーを持つかどうかは省略可能を決定します。 値が true の場合、すべての項目は、トレーラーが必要です。|
| id| string| 省略可能。 指定した場合、その ID を持つ項目の子にのみする結果を制限します。 このパラメーターが指定されている場合、MediaItemType も指定する必要があります。 |
| id| 文字列の配列| 必須。 すべての詳細が返されます (最大 10) の Id。 注:、いずれかの ID をで配置する不正な文字が含まれています (ProviderContentId 種類 Id は通常の完全な Url 自体したがって無効な文字が含まれます) の URL が正しく EDS に送信する URL エンコードされる必要があります。|
| idType| string| 省略可能。 Id のパラメーターに渡された Id の種類です。 有効な値は次のとおりです。 <ul><li>正規 (Bing/Marketplace)</li><li>XboxHexTitle (本体でプレイしているアプリ)</li></ul>  すべて指定 Id は、同じ idType を共有する必要があります。 この値を省略すると、すべての Id が正規と見なされます。|
| latestOnly| ブール値| 省略可能なフィルターのパラメーターです。 結果を最新のリリース日のものだけに制限されます。|
| maxItems| 32 ビット符号付き整数| 省略可能。 呼び出しから返される項目の最大数を決定します。 有効な値は、1 ~ 25、包括的な数値です。 パラメーターは、既定で 25 を省略した場合。|
| mediaGroup| string| 省略可能。 Id のメディアのグループ。 すべて指定 Id は、同じメディア グループを共有する必要があります。|
| MediaItemType| string| 省略可能。 ID を持つが id パラメーターで指定された項目の種類。 Id パラメーターが指定されている場合、このパラメーターが指定もする必要があります。|
| orderBy| string| 必須。 OrderBy パラメーターは、返される項目の並べ替え方法を決定します。 このフィールドに共通の値がここでは、表示されているが、一部の Api は、その他の値をサポート可能性があります。<ul><li>playCountDaily - 回数で直近の日付のメディアが再生されます。</li><li>freeAndPaidCountDaily - 無料および有料購入、直近の日付の数。</li><li>paidCountAllTime - すべての時間の唯一の有料購入の数。</li><li>paidCountDaily - 直近の日付の有料購入の数。</li><li>digitalReleaseDate - ダウンロードの利用可能な日付。</li><li>releaseDate -、ストアで利用可能な日付別にフォールバックするデジタル リリース日 (該当する場合)。</li><li>userRatings - ユーザーの平均評価でします。</li></ul> |
| preferredProvider| string| 省略可能。 ユーザーが Verizon FIOS、Comcast Xfinity など、優先するコンテンツ プロバイダーでそのプロバイダーの ID を渡すことができます。 項目の実際の順序は変わらない各項目の中に、指定されたプロバイダーの情報が表示されますプロバイダーの一覧の上部 (優先するコンテンツ プロバイダーに利用可能な項目がある場合)。|
| q| string| 必須。 検索で使用される用語を照会します。|
| queryRefiners| 文字列の配列| 省略可能。 [EDS クエリの絞り込み条件](edsqueryrefiners.md)の一覧を参照してください。|
| 関係| string| 省略可能。 指定された関係型に一致するその他の製品を検索するベースとして ID パラメーターを使用するフィルター: <ul><li>bundledWith - ID パラメーターがそれらのバンドルの一部として含まバンドルの製品を検索します。</li><li>bundledProducts - ID パラメーターで指定されたバンドルに含まれている製品を検索します。</li></ul>  このパラメーターと共に (参照呼び出しで返すことができます) の市場で表示されている製品だけが返されます。 バンドルに非表示の製品がある場合は、バンドルの一部では引き続きが、これらの結果は返されません。|
  | < | string | このパラメーターは、ビデオ メディアの逆引き参照のシナリオで使用されます。 |
  | ScopeIdType | string | このパラメーターは、ビデオ メディアの逆引き参照のシナリオで使用されます。 設定可能な値: タイトル。 |
  | skipItems | 32 ビット符号付き整数 | 省略可能。 ページング クロス グループ以外のシナリオで、skipItems パラメーターは、項目の数に既に表示されているかを判断するために使用 (したがってどのような項目が表示される最初結果セット内の)。 値が 0 に基づくよう skipItems = 0 (または、単に skipItems を指定していない) は、リストの開始時の取得を開始します。 skipItems = 3 は、リスト内の最初の 3 つの項目を省略し、4 番目の項目の取得を開始します。 |
  | subscriptionLevel | 文字列の配列 | 省略可能なフィルターのパラメーターです。 (かどうか、ユーザーは、有料サブスクリプションや無料のサブスクリプションを持つ) など、ユーザーのサブスクリプションの種類には、subscriptionLevel パラメーターを決定します。 設定可能な値は次のとおりです。 <ul><li>gold: ユーザーに有料サブスクリプションがあります。</li><li>silver: ユーザーは、無料のサブスクリプションを持っています。</li></ul>  |
| ターゲット ・ デバイス| string| EDS では、対象のデバイス向けのフィルター処理する柔軟性を提供を提供します。 項目で返されたプラン (ProviderContent または可用性) は、ターゲット デバイスに制限することができます。|
| topRatedOnly| ブール値| 省略可能なフィルターのパラメーターです。 結果を揃えて評価のコンテンツのみに制限されます。|

<a id="ID4EGEAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EIEAC"></a>


### <a name="parent"></a>Parent

[その他の参照情報](atoc-xboxlivews-reference-additional.md)


<a id="ID4EUEAC"></a>


### <a name="further-information"></a>詳細情報

[マーケットプレース URI](../uri/marketplace/atoc-reference-marketplace.md)
