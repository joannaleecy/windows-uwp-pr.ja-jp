---
description: Microsoft Store analytics API でこのメソッドを使用して、ゲーム、Xbox One でエラーのスタック トレースを取得します。
title: Xbox One ゲームのエラーに関するスタック トレースの取得
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, スタック トレース, エラー
ms.localizationpriority: medium
ms.openlocfilehash: fd43305c54245c3281a0e840d3df4c5c87ff7ad8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658687"
---
# <a name="get-the-stack-trace-for-an-error-in-your-xbox-one-game"></a>Xbox One ゲームのエラーに関するスタック トレースの取得

このメソッドを使用して、Microsoft Store analytics API ゲーム、Xbox One でエラーのスタック トレースを取得する Xbox 開発者ポータル (XDP) を取り込んだして XDP Analytics パートナー センター ダッシュ ボードに表示します。 このメソッドでダウンロードできるのは、過去 30 日以内に発生したエラーに関するスタック トレースのみです。

最初に使用する必要があるこのメソッドを使用する前に、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)スタック トレースを取得するエラーに関連付けられている CAB ファイルの ID を取得します。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID を取得します。 この ID を取得するには、使用、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)アプリでは、特定のエラーの詳細を取得し、使用するメソッド、 **cabId**メソッドの応答本文内の値。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/stacktrace``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  |
|---------------|--------|---------------|------|
| applicationId | string | スタック トレースを取得する Xbox One のゲームの製品の ID。 ゲームの製品 ID を取得するには、Xbox デベロッパー ポータル (XDP) で目的のゲームに移動し、URL から製品 ID を取得します。 または、パートナー センターの Windows analytics レポートから、正常性データをダウンロードする場合は、.tsv ファイルで製品 ID が含まれます。 |  〇  |
| cabId | string | スタック トレースを取得するエラーに関連付けられた CAB ファイルの一意の ID を取得します。 この ID を取得するには、使用、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)アプリでは、特定のエラーの詳細を取得し、使用するメソッド、 **cabId**メソッドの応答本文内の値。 |  〇  |

 
### <a name="request-example"></a>要求の例

次の例では、このメソッドを使用してゲームを Xbox One のスタック トレースを取得する方法を示します。 置換、 *applicationId*ゲームの製品 ID を持つ値。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/stacktrace?applicationId=BRRT4NJ9B3D1&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| Value      | 種類    | 説明                  |
|------------|---------|--------------------------------|
| Value      | array   | 各オブジェクトにスタック トレース データの 1 つのフレームが格納されたオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[スタック トレースの値](#stack-trace-values)」セクションをご覧ください。 |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。 |
| TotalCount | 整数 | クエリの結果データ内の行の総数です。          |


### <a name="stack-trace-values"></a>スタック トレースの値

*Value* 配列の要素には、次の値が含まれます。

| Value           | 種類    | 説明      |
|-----------------|---------|----------------|
| level            | string  |  コール スタックでこの要素が表すフレーム番号です。  |
| image   | string  |   このスタック フレームで呼び出される関数が含まれている実行可能ファイルまたはライブラリ イメージの名前です。           |
| function | string  |  このスタック フレームで呼び出される関数の名前。 これは、ゲームには、実行可能ファイルまたはライブラリのシンボルが含まれています。 場合にのみ使用できます。              |
| offset     | string  |  関数の先頭を基準とした現在の命令のバイト オフセットです。      |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Value": [
    {
      "level": "0",
      "image": "Contoso.ContosoApp",
      "function": "Contoso.ContosoApp.MainPage.DoWork",
      "offset": "0x25C"
    }
    {
      "level": "1",
      "image": "Contoso.ContosoApp",
      "function": "Contoso.ContosoApp.MainPage.Initialize",
      "offset": "0x26"
    }
    {
      "level": "2",
      "image": "Contoso.ContosoApp",
      "function": "Contoso.ContosoApp.Start",
      "offset": "0x66"
    }
  ],
  "@nextLink": null,
  "TotalCount": 3
}

```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
* [レポート データを Xbox One のエラーが発生するゲーム](get-error-reporting-data-for-your-xbox-one-game.md)
* [ゲーム、Xbox One でエラーの詳細を取得します。](get-details-for-an-error-in-your-xbox-one-game.md)
* [Xbox One、ゲームでエラー用の CAB ファイルをダウンロードします。](download-the-cab-file-for-an-error-in-your-xbox-one-game.md)
