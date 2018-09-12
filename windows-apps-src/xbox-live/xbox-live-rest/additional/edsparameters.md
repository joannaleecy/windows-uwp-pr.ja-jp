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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881961"
---
# <a name="eds-parameters"></a>EDS パラメーター

<a id="ID4EO"></a>


## <a name="query-string-parameters"></a>クエリ文字列パラメーター

これらのクエリ パラメーターは、必ずしもすべて[エンターテイメント探索サービス (EDS) Api](../uri/marketplace/atoc-reference-marketplace.md)では使用できませんが、すべてが 1 つ以上の API で承認されています。

| パラメーター| 型| 説明|
| --- | --- | --- |
| combinedContentRating| string| 省略可能。 表示[取得 (/media/{marketplaceId}/contentRating)](../uri/marketplace/uri-medialocalecontentratingget.md)します。|
| continuationToken| 文字列| 省略可能。 継続トークンは、特定のシナリオで改サービスが必要な情報が含まれている不透明なする blob です。 値を省略すると、結果の最初のページが返されます (ページのサイズが決定される maxItems パラメーターによって)、2 番目のページの結果を取得することができる継続トークンと共に。 2 番目のページは、結果の 3 番目のページの継続トークンが含まれ、ようにします。|
| 必要に応じてください。| string| 省略可能。 結合されたフィールド名の API を参照してください。|
| desiredMediaItemTypes| 文字列の配列| 省略可能。 このパラメーターは、応答で返される項目の種類を決定します。|
| ドメイン| string| 省略可能。 ドメインのパラメーターは、ゲームとアプリの市場のコンテキストを決定します。 クライアントがの呼び出しにします。 既定でドメインは、「最新」を示す、クライアントが Xbox One コンテンツを求めることのみです。 クライアントが Xbox 360 のサーフェスのコンテンツにドメインを切り替える場合、そのドメインを指定する"Xbox360"としてする必要があります。 現時点では、ドメインを越えた結果はサポートされていません。 設定可能な値は、次のとおりです。 <ul><li>Xbox360</li><li>最新</li></ul> "Xbox360"の値は、singleMediaGroupSearch ののみサポートされます。 参照と詳細がサポートされています。 crossMediaGroupSearch はサポートされておらず、400 エラーが返されます。|
| フィールド| string| 省略可能。 表示[取得 (/media/{marketplaceId} フィールド/)](../uri/marketplace/uri-medialocalefieldsget.md)。|
| firstPartyOnly| ブール値| 省略可能なフィルター パラメーター。 のみファースト パーティ コンテンツが返されるかどうか、または両方ファースト パーティとサード パーティ コンテンツが、クエリから返されるかどうかを決定します。 |
| freeOnly| ブール値| 省略可能なフィルター パラメーター。 のみコンテンツを解放するための結果を制限します。|
| GroupBy| TK| GroupBy パラメーターは、単一の結果セットではなく、結果のセットをグループに分類するために使用されます。 このパラメーターを指定すると、結果を maxItems パラメーターで各バケット内の項目の数が決定される項目の複数のリストを返すセットが変更されます。 <ul><li>MediaGroup - 結果が MediaGroup によってグループ化されます。</li></ul> |
| hasTrailer| ブール値| 省略可能なフィルター パラメーター。 返された項目にトレーラーを含める必要があるかどうか、またはトレーラーがあるかどうかは省略可能ですが決定します。 この値が true の場合、すべての項目は、トレーラーが必要です。|
| id| string| 省略可能。 指定した場合にその ID を持つ項目の子にのみする結果が制限されます。 このパラメーターが指定した場合、MediaItemType も指定する必要があります。 |
| id| 文字列の配列| 必須。 すべての詳細が返されます (最大 10) の Id。 注、いずれかの ID に不正な文字が含まれています (ProviderContentId 種類 Id は通常の完全な Url 自体と無効な文字を含めるため) の URL が正しく EDS に送信する URL エンコードされる必要があります。|
| idType| string| 省略可能。 Id パラメーターで渡される Id の種類です。 有効な値は次のとおりです。 <ul><li>正規 (Bing/Marketplace)</li><li>XboxHexTitle (本体でプレイしているアプリ)</li></ul>  提供されるすべての Id が同じ idType を共有する必要があります。 この値を省略すると、すべての Id は正規と想定されます。|
| latestOnly| ブール値| 省略可能なフィルター パラメーター。 結果を最新のリリース日のものだけに制限されます。|
| maxItems| 32 ビットの符号付き整数| 省略可能。 呼び出しから返される項目の最大数を決定します。 有効な値は、1 ~ 25、包括的な数値です。 パラメーターは、既定で 25 省略した場合。|
| mediaGroup| string| 省略可能。 Id のメディアのグループ。 提供されるすべての Id が同じメディアのグループを共有する必要があります。|
| MediaItemType| string| 省略可能。 ID を持つは id パラメーターで指定された項目の種類です。 Id パラメーターが指定した場合、このパラメーターが指定もする必要があります。|
| orderBy| string| 必須。 OrderBy パラメーターは、返される項目の並べ替え方法を決定します。 このフィールドに、一般的な値はここでは、リストされますが、一部の Api は、その他の値をサポート可能性があります。<ul><li>playCountDaily - 回数で直近の日付のメディアが再生されます。</li><li>freeAndPaidCountDaily - 無料および有料購入、直近の日付の数。</li><li>paidCountAllTime - すべての日付の唯一の有料購入の数。</li><li>paidCountDaily - 直近の日付の有料購入の数。</li><li>digitalReleaseDate - ダウンロードで利用可能な日付。</li><li>releaseDate -、ストアで利用可能な日付にフォールバックするデジタル リリース日 (該当する場合)。</li><li>userRatings - ユーザーの平均評価でします。</li></ul> |
| preferredProvider| string| 省略可能。 ユーザーが Comcast Xfinity や、Verizon FIOS など、優先するコンテンツ プロバイダーでそのプロバイダーの ID を渡すことができます。 中、各項目について、変更されず、アイテムの実際の順序指定、指定されたプロバイダーの情報はプロバイダーの一覧の上部に表示されます (優先するコンテンツ プロバイダーに利用可能な項目がある場合)。|
| q| string| 必須。 検索で使用される用語を照会します。|
| queryRefiners| 文字列の配列| 省略可能。 [EDS クエリの絞り込み条件](edsqueryrefiners.md)の一覧を参照してください。|
| 関係| string| 省略可能。 指定された関係型に一致するその他の製品を検索の基礎として ID パラメーターを使用するフィルター: <ul><li>bundledWith - ID パラメーターがそれらのバンドルの一部として含まバンドルの製品を検索します。</li><li>bundledProducts - ID パラメーターで指定されたバンドルに含まれている製品を検索します。</li></ul>  このパラメーターと共に marketplace (参照呼び出しで返すことができます) に表示されている製品だけが返されます。 バンドルに非表示の製品がある場合は、それが、バンドルの一部が、これらの結果は返されません。|
  | < | string | このパラメーターは、ビデオ メディアの逆引き参照のシナリオで使用します。 |
  | ScopeIdType | string | このパラメーターは、ビデオ メディアの逆引き参照のシナリオで使用します。 設定可能な値: タイトル。 |
  | skipItems | 32 ビットの符号付き整数 | 省略可能。 用クロス グループ以外のシナリオでは、ページング skipItems パラメーターは、項目の数に既に表示されているかを判断するために使用 (にしたがってどのような項目を表示する必要があります最初の結果に設定)。 値が 0 に基づく、その skipItems = 0 (または、単に skipItems を指定していない) は、一覧の開始時の取得を開始します。 skipItems = 3 は、リスト内の最初の 3 つの項目をスキップし、4 番目の項目の取得を開始します。 |
  | subscriptionLevel | 文字列の配列 | 省略可能なフィルター パラメーター。 (かどうか、ユーザーは、有料サブスクリプションや無料のサブスクリプションを持つ) などのユーザーのサブスクリプションの種類が subscriptionLevel パラメーターを決定します。 設定可能な値は次のとおりです。 <ul><li>gold: ユーザーが有料サブスクリプション</li><li>silver: ユーザーは、無料のサブスクリプションを持っています。</li></ul>  |
| ターゲット ・ デバイス| string| ターゲット デバイスにフィルター処理する柔軟性を提供 EDS を提供します。 項目の返されるプラン (ProviderContent または可用性) は、ターゲット デバイスに制限できます。|
| topRatedOnly| ブール値| 省略可能なフィルター パラメーター。 結果を揃えて評価コンテンツのみに制限されます。|

<a id="ID4EGEAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EIEAC"></a>


### <a name="parent"></a>Parent

[その他の参照](atoc-xboxlivews-reference-additional.md)


<a id="ID4EUEAC"></a>


### <a name="further-information"></a>詳細情報

[Marketplace Uri](../uri/marketplace/atoc-reference-marketplace.md)
