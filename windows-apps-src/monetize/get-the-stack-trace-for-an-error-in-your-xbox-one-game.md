---
description: ゲーム、Xbox One でのエラーに関するスタック トレースを取得するのに、Microsoft Store 分析 API の以下のメソッドを使用します。
title: ゲーム、Xbox One でのエラーに関するスタック トレースを取得します。
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, スタック トレース, エラー
ms.localizationpriority: medium
ms.openlocfilehash: fd43305c54245c3281a0e840d3df4c5c87ff7ad8
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8194445"
---
# <a name="get-the-stack-trace-for-an-error-in-your-xbox-one-game"></a>ゲーム、Xbox One でのエラーに関するスタック トレースを取得します。

Microsoft Store 分析 API ゲーム、Xbox One でのエラーに関するスタック トレースを取得する Xbox デベロッパー ポータル (XDP) を通じて取り込まれ、XDP 分析パートナー センター ダッシュ ボードで利用するには、このメソッドを使います。 このメソッドでダウンロードできるのは、過去 30 日以内に発生したエラーに関するスタック トレースのみです。

以下のメソッドを使用する前に、まずは、スタック トレースを取得するエラーに関連付けられている CAB ファイルの ID を取得するのにことで、 [Xbox One ゲームのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用する必要があります。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID を取得します。 この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリで特定のエラーに関する詳細を取得し、そのメソッドの応答本文で**cabId**値を使用します。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/stacktrace``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  |
|---------------|--------|---------------|------|
| applicationId | string | スタック トレースを取得して、Xbox One ゲームの製品 ID です。 ゲームの製品 ID を取得するには、Xbox デベロッパー ポータル (XDP) で目的のゲームに移動し、URL から製品 ID を取得します。 または、Windows パートナー センターの分析レポートから正常性データをダウンロードした場合、製品 ID は .tsv ファイルに含まれています。 |  必須  |
| cabId | string | スタック トレースを取得するエラーに関連付けられた CAB ファイルの一意の ID を取得します。 この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリで特定のエラーに関する詳細を取得し、そのメソッドの応答本文で**cabId**値を使用します。 |  はい  |

 
### <a name="request-example"></a>要求の例

次の例は、以下のメソッドを使用してゲームの Xbox One のスタック トレースを取得する方法を示しています。 *ApplicationId*値をゲームの製品 ID に置き換えます。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/stacktrace?applicationId=BRRT4NJ9B3D1&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型    | 説明                  |
|------------|---------|--------------------------------|
| Value      | array   | 各オブジェクトにスタック トレース データの 1 つのフレームが格納されたオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[スタック トレースの値](#stack-trace-values)」セクションをご覧ください。 |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。 |
| TotalCount | 整数 | クエリの結果データ内の行の総数です。          |


### <a name="stack-trace-values"></a>スタック トレースの値

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明      |
|-----------------|---------|----------------|
| level            | string  |  コール スタックでこの要素が表すフレーム番号です。  |
| image   | string  |   このスタック フレームで呼び出される関数が含まれている実行可能ファイルまたはライブラリ イメージの名前です。           |
| function | string  |  このスタック フレームで呼び出される関数の名前。 これは、ゲームには、実行可能ファイルまたはライブラリのシンボルが含まれている場合のみ利用可能です。              |
| offset     | string  |  関数の先頭を基準とした現在の命令のバイト オフセットです。      |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

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

* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [ゲームの Xbox One に関するエラー報告データを取得します。](get-error-reporting-data-for-your-xbox-one-game.md)
* [ゲームの Xbox One のエラーに関する詳細を取得します。](get-details-for-an-error-in-your-xbox-one-game.md)
* [Xbox One ゲームのエラーに関する CAB ファイルをダウンロードします。](download-the-cab-file-for-an-error-in-your-xbox-one-game.md)
