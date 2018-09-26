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
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4207309"
---
# <a name="eds-parameters"></a>EDS パラメーター

<a id="ID4EO"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

これらのクエリ パラメーターは必ずしもすべて[エンターテイメント探索サービス (EDS) Api](../uri/marketplace/atoc-reference-marketplace.md)で受け入れられませんが、1 つ以上の API で受け入れられるすべて。

| パラメーター| 型| 説明|
| --- | --- | --- |
| combinedContentRating| string| 省略可能。 表示[を取得する (/media/{marketplaceId}/contentRating)](../uri/marketplace/uri-medialocalecontentratingget.md)します。|
| continuationToken| 文字列| 省略可能。 継続トークンは、特定のシナリオで改ページのサービスが必要な情報が含まれている不透明な blob です。 値を省略すると、結果の最初のページが返されます (、ページのサイズが決定 maxItems パラメーターによって) と共に継続トークン結果の 2 番目のページを取得するために使用できます。 2 番目のページを結果のページには 3 つ目の継続トークンを含むし、ようにします。|
| 必要に応じてください。| string| 省略可能。 結合されたフィールド名 API を参照してください。|
| desiredMediaItemTypes| 文字列の配列| 省略可能。 このパラメーターは、応答で返される項目の種類を決定します。|
| ドメイン| string| 省略可能。 ドメインのパラメーターは、ゲームとアプリの市場のコンテキストを決定します。 クライアントがの呼び出しにします。 既定では、ドメインは、「最新」を示す、クライアントが Xbox One コンテンツを求めることだけです。 クライアントが Xbox 360 のサーフェスのコンテンツにドメインを切り替える場合、そのドメインを指定する"Xbox360"としてする必要があります。 現時点では、ドメインを越えた結果はサポートされていません。 設定可能な値は、次のとおりです。 <ul><li>Xbox360</li><li>最新</li></ul> "Xbox360"の値は、singleMediaGroupSearch にのみサポートされます。 参照と詳細情報がサポートされています。 crossMediaGroupSearch はサポートされておらず、400 エラーが返されます。|
| フィールド| string| 省略可能。 表示[を取得する (/media/{marketplaceId} フィールド/)](../uri/marketplace/uri-medialocalefieldsget.md)します。|
| firstPartyOnly| ブール値| 省略可能なフィルターのパラメーターです。 ファースト パーティのみコンテンツが返されるかどうか、または両方ファースト パーティとサード パーティ コンテンツがクエリから返されるかどうかを決定します。 |
| freeOnly| ブール値| 省略可能なフィルターのパラメーターです。 のみコンテンツを解放するための結果を制限します。|
| GroupBy| TK| GroupBy パラメーターは、単一の結果セットではなく、結果セットをグループに分類するために使用されます。 このパラメーターを指定すると、結果を maxItems パラメーターによって各バケット内の項目の数を決定する場所の項目を複数のリストを返すセットが変更されます。 <ul><li>MediaGroup - 結果が MediaGroup によってグループ化されます。</li></ul> |
| hasTrailer| ブール値| 省略可能なフィルターのパラメーターです。 返された項目にトレーラーを含める必要があるかどうか、またはトレーラーがあるかどうかは省略可能を決定します。 値が true の場合、すべての項目にトレーラー必要があります。|
| id| string| 省略可能。 指定した場合、結果を特定の ID を持つ項目の子になるだけに制限します。 このパラメーターが指定されている場合、MediaItemType も指定する必要があります。 |
| id| 文字列の配列| 必須。 すべての詳細が返されます (最大 10) の Id。 注 ID いずれかにはで配置する不正な文字が含まれています (ProviderContentId 種類 Id は通常の完全な Url 自体したがって無効な文字が含まれます) の URL が正しく EDS に送信する URL エンコードされる必要があります。|
| idType| string| 省略可能。 Id パラメーターで渡される Id の種類です。 有効な値は次のとおりです。 <ul><li>正規 (Bing/Marketplace)</li><li>XboxHexTitle (本体でプレイしているアプリ)</li></ul>  すべて指定 Id は、同じ idType を共有する必要があります。 この値を省略すると、すべての Id が正規と見なされます。|
| latestOnly| ブール値| 省略可能なフィルターのパラメーターです。 結果を最新のリリース日のものだけに制限されます。|
| maxItems| 32 ビット符号付き整数| 省略可能。 呼び出しから返される項目の最大数を決定します。 有効な値は、1 ~ 25、包括的な数値です。 パラメーターは、既定で 25 省略した場合。|
| mediaGroup| string| 省略可能。 Id のメディアのグループ。 すべて指定 Id は、同じメディア グループを共有する必要があります。|
| MediaItemType| string| 省略可能。 ID を持つが id パラメーターで指定された項目の種類です。 Id パラメーターが指定されている場合、このパラメーターが指定もする必要があります。|
| orderBy| string| 必須。 OrderBy パラメーターは、返される項目の並べ替え方法を決定します。 このフィールドに共通の値がここでは、表示されているが、一部の Api が追加の値をサポート可能性があります。<ul><li>playCountDaily - 回数で直近の日付のメディアが再生されます。</li><li>freeAndPaidCountDaily - 無料および有料購入、直近の日付の数。</li><li>paidCountAllTime - すべての時間の唯一の有料購入の数。</li><li>paidCountDaily - 直近の日付の有料購入の数。</li><li>digitalReleaseDate - ダウンロードの利用可能な日付。</li><li>releaseDate -、ストアで利用可能な日付にフォールバックするデジタル リリース日 (利用可能な場合)。</li><li>userRatings - ユーザーの平均評価でします。</li></ul> |
| preferredProvider| string| 省略可能。 ユーザーが Comcast Xfinity や Verizon FIOS などの優先するコンテンツ プロバイダーでそのプロバイダーの ID を渡すことができます。 中、各項目について、変更されず、アイテムの実際の順序、指定されたプロバイダーの情報はプロバイダーの一覧の上部に表示されます (優先するコンテンツ プロバイダーに利用可能な項目がある場合)。|
| q| string| 必須。 検索で使用される用語を照会します。|
| queryRefiners| 文字列の配列| 省略可能。 [EDS クエリの絞り込み条件](edsqueryrefiners.md)の一覧を参照してください。|
| 関係| string| 省略可能。 指定した関係の種類に一致するその他の製品を検索するベースとして ID パラメーターを使用するフィルター: <ul><li>bundledWith - ID パラメーターがそれらのバンドルの一部として含まバンドルの製品を検索します。</li><li>bundledProducts - ID パラメーターで指定されたバンドルに含まれている製品を検索します。</li></ul>  このパラメーターと共に (参照呼び出しで返すことが) マーケットプ レースで表示されている製品だけが返されます。 バンドルに非表示の製品がある場合は、バンドルの一部では引き続きが、これらの結果は返されません。|
  | < | string | このパラメーターは、ビデオ メディアの逆引き参照のシナリオで使用されます。 |
  | ScopeIdType | string | このパラメーターは、ビデオ メディアの逆引き参照のシナリオで使用されます。 設定可能な値: タイトルです。 |
  | skipItems | 32 ビット符号付き整数 | 省略可能。 クロス グループ以外のシナリオでページング、skipItems パラメーターは、項目の数に既に表示されているかを判断するために使用 (とのでどのような項目を表示する必要があります最初に結果を設定)。 値は 0 から始まるため skipItems = 0 (または、単に skipItems を指定していない) は、リストの開始時の取得を開始します。 skipItems = 3 は、リスト内の最初の 3 つの項目を省略し、4 番目の項目の取得を開始します。 |
  | subscriptionLevel | 文字列の配列 | 省略可能なフィルターのパラメーターです。 (かどうか、ユーザーは、有料サブスクリプションや無料のサブスクリプションを持つ) などのユーザーのサブスクリプションの種類が subscriptionLevel パラメーターを決定します。 設定可能な値は次のとおりです。 <ul><li>gold: ユーザーが有料サブスクリプション</li><li>silver: ユーザーは、無料のサブスクリプションを持っています。</li></ul>  |
| ターゲット ・ デバイス| string| 対象のデバイス向けのフィルター処理する柔軟性を提供 EDS を提供します。 項目で返されたプラン (ProviderContent または可用性) は、ターゲット デバイスに制限することができます。|
| topRatedOnly| ブール値| 省略可能なフィルターのパラメーターです。 結果を揃えて評価のコンテンツのみに制限されます。|

<a id="ID4EGEAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EIEAC"></a>


### <a name="parent"></a>Parent

[その他の参照情報](atoc-xboxlivews-reference-additional.md)


<a id="ID4EUEAC"></a>


### <a name="further-information"></a>詳細情報

[マーケットプレース URI](../uri/marketplace/atoc-reference-marketplace.md)
