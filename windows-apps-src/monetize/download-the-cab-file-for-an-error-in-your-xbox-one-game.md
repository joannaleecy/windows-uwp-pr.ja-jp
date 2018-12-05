---
description: Xbox One ゲームのエラーに関する CAB ファイルをダウンロードするのに、Microsoft Store 分析 API の以下のメソッドを使用します。
title: Xbox One ゲームのエラーに関する CAB ファイルをダウンロードします。
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: 736219533a254e6380c10600e97f707f15e37de6
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8729839"
---
# <a name="download-the-cab-file-for-an-error-in-your-xbox-one-game"></a>Xbox One ゲームのエラーに関する CAB ファイルをダウンロードします。

Xbox デベロッパー ポータル (XDP) を通じてが取り込まれる、Xbox One ゲームの特定のエラーに関連付けられていると、XDP 分析パートナー センター ダッシュ ボードで利用可能な CAB ファイルをダウンロードするのに、Microsoft Store 分析 API の以下のメソッドを使用します。 このメソッドは、過去 30 日以内に発生したエラーの CAB ファイルのみをダウンロードできます。

以下のメソッドを使用する前に、まずをダウンロードする CAB ファイルの ID を取得するのにことで、 [Xbox One ゲームのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用する必要があります。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* ダウンロードする CAB ファイルの ID を取得します。 この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリで特定のエラーに関する詳細を取得し、そのメソッドの応答本文で**cabId**値を使用します。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  |
|---------------|--------|---------------|------|
| applicationId | string | CAB ファイルをダウンロードする Xbox One ゲームの製品 ID です。 ゲームの製品 ID を取得するには、Xbox デベロッパー ポータル (XDP) で目的のゲームに移動し、URL から製品 ID を取得します。 または、Windows パートナー センターの分析レポートから正常性データをダウンロードした場合、製品 ID は .tsv ファイルに含まれています。 |  必須  |
| cabId | string | ダウンロードする CAB ファイルの一意の ID です。 この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリで特定のエラーに関する詳細を取得し、そのメソッドの応答本文で**cabId**値を使用します。 |  はい  |

 
### <a name="request-example"></a>要求の例

次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。 *applicationId* および *cabId* パラメーターを、アプリの適切な値に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload?applicationId=BRRT4NJ9B3D1&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。 呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [ゲームの Xbox One に関するエラー報告データを取得します。](get-error-reporting-data-for-your-xbox-one-game.md)
* [ゲームの Xbox One のエラーに関する詳細を取得します。](get-details-for-an-error-in-your-xbox-one-game.md)
* [ゲーム、Xbox One でのエラーに関するスタック トレースを取得します。](get-the-stack-trace-for-an-error-in-your-xbox-one-game.md)
