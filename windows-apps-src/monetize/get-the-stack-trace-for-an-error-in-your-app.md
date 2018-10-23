---
author: Xansky
ms.assetid: b556a245-6359-4ddc-a4bd-76f9873ab694
description: アプリのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: アプリのエラーに関するスタック トレースの取得
ms.author: mhopkins
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, スタック トレース, エラー
ms.localizationpriority: medium
ms.openlocfilehash: 54c39d157bc2fcab6a67bd273f5d00eedd80be54
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5430863"
---
# <a name="get-the-stack-trace-for-an-error-in-your-app"></a>アプリのエラーに関するスタック トレースの取得

アプリのエラーに関するスタック トレースを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドでダウンロードできるのは、過去 30 日以内に発生したアプリのエラーに関するスタック トレースのみです。 スタック トレースは、Windows デベロッパー センター ダッシュボードの[状態レポート](../publish/health-report.md)の **[エラー]** セクションでも確認できます。

このメソッドを使うには、その前にまず「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID を取得する必要があります。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* スタック トレースを取得するエラーに関連付けられた CAB ファイルの ID を取得します。 この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/stacktrace``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  |
|---------------|--------|---------------|------|
| applicationId | string | スタック トレースを取得するアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。 |  必須  |
| cabId | string | スタック トレースを取得するエラーに関連付けられた CAB ファイルの一意の ID を取得します。 この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。 |  必須  |

 
### <a name="request-example"></a>要求の例

次の例は、このメソッドを使ってスタック トレースを取得する方法を示しています。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/stacktrace?applicationId=9NBLGGGZ5QDR&cabId=1336373323853 HTTP/1.1
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
| function | string  |  このスタック フレームで呼び出される関数の名前。 これは、アプリが実行可能ファイルまたはライブラリのシンボルを含んでいる場合のみ使用可能です。              |
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

* [[正常性] レポート](../publish/health-report.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)
* [アプリのエラーの CAB ファイルをダウンロードする](download-the-cab-file-for-an-error-in-your-app.md)
