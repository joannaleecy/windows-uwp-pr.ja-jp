---
ms.assetid: ''
description: アプリのエラーの CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。
title: アプリのエラーの CAB ファイルをダウンロードする
ms.date: 06/16/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: a4643f94236e62c46c12fd656ab5ddba5e1e0632
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8696878"
---
# <a name="download-the-cab-file-for-an-error-in-your-app"></a>アプリのエラーの CAB ファイルをダウンロードする

パートナー センターに報告されたアプリの特定のエラーに関連付けられている CAB ファイルをダウンロードするのに、Microsoft Store 分析 API の以下のメソッドを使用します。 このメソッドでダウンロードできるのは、過去 30 日以内に発生したアプリのエラーに関する CAB ファイルのみです。 [正常性レポート](../publish/health-report.md)では、パートナー センターの [**エラー** ] セクションでは、CAB ファイルのダウンロードを利用できます。

このメソッドを使うには、事前に 「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使用し、ダウンロードする CAB ファイルの ID を取得しておく必要があります。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* ダウンロードする CAB ファイルの ID を取得します。 この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/cabdownload``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  |
|---------------|--------|---------------|------|
| applicationId | string | CAB ファイルをダウンロードするアプリのストア ID です。 ストア ID は、パートナー センターの[アプリ id] ページ](../publish/view-app-identity-details.md)で利用できます。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。 |  必須  |
| cabId | string | ダウンロードする CAB ファイルの一意の ID です。 この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。 |  必須  |

 
### <a name="request-example"></a>要求の例

次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。 *applicationId* および *cabId* パラメーターを、アプリの適切な値に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/cabdownload?applicationId=9NBLGGGZ5QDR&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。 呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。

## <a name="related-topics"></a>関連トピック

* [[正常性] レポート](../publish/health-report.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)
* [アプリのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-app.md)
