---
description: Microsoft Store analytics API でこのメソッドを使用して、Xbox One、ゲームでエラー用の CAB ファイルをダウンロードします。
title: Xbox One ゲームのエラーの CAB ファイルをダウンロードする
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: 736219533a254e6380c10600e97f707f15e37de6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604327"
---
# <a name="download-the-cab-file-for-an-error-in-your-xbox-one-game"></a>Xbox One ゲームのエラーの CAB ファイルをダウンロードする

Microsoft Store analytics API でこのメソッドを使用すると、Xbox 開発者ポータル (XDP) を通じてが取り込まれますが、Xbox One のゲームの特定のエラーに関連付け、XDP Analytics パートナー センター ダッシュ ボードで使用可能である CAB ファイルをダウンロードします。 このメソッドは、過去 30 日間に発生したエラー用の CAB ファイルのみをダウンロードできます。

最初に使用する必要があるこのメソッドを使用する前に、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)をダウンロードする CAB ファイルの ID を取得します。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* ダウンロードする CAB ファイルの ID を取得します。 この ID を取得するには、使用、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)アプリでは、特定のエラーの詳細を取得し、使用するメソッド、 **cabId**メソッドの応答本文内の値。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  |
|---------------|--------|---------------|------|
| applicationId | string | CAB ファイルをダウンロードする Xbox One のゲームの製品の ID。 ゲームの製品 ID を取得するには、Xbox デベロッパー ポータル (XDP) で目的のゲームに移動し、URL から製品 ID を取得します。 または、パートナー センターの Windows analytics レポートから、正常性データをダウンロードする場合は、.tsv ファイルで製品 ID が含まれます。 |  〇  |
| cabId | string | ダウンロードする CAB ファイルの一意の ID です。 この ID を取得するには、使用、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)アプリでは、特定のエラーの詳細を取得し、使用するメソッド、 **cabId**メソッドの応答本文内の値。 |  〇  |

 
### <a name="request-example"></a>要求の例

次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。 *applicationId* および *cabId* パラメーターを、アプリの適切な値に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload?applicationId=BRRT4NJ9B3D1&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。 呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
* [レポート データを Xbox One のエラーが発生するゲーム](get-error-reporting-data-for-your-xbox-one-game.md)
* [ゲーム、Xbox One でエラーの詳細を取得します。](get-details-for-an-error-in-your-xbox-one-game.md)
* [ゲーム、Xbox One でエラーのスタック トレースを取得します。](get-the-stack-trace-for-an-error-in-your-xbox-one-game.md)
