---
author: mcleanbyron
ms.assetid: 3D6EE7D7-7D75-499D-AA7A-55DA1C485BA6
description: Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドは、IHV のみを対象としています。
title: Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードする
ms.author: mcleans
ms.date: 03/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: 98d83dd6bbaeb67f4601315dbb92b1d2cf8dfd23
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1664512"
---
# <a name="download-the-cab-file-for-a-windows-10-driver-error"></a>Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードする

Windows 10 の特定のドライバー エラーに関連付けられている CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドを使うには、事前に [Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを使用し、ダウンロードする CAB ファイルの ID を取得しておく必要があります。

Microsoft Store 分析 API の [Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)メソッドおよび [Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを使うと、OEM ハードウェア エラーに関する他の情報を取得できます。

> [!NOTE]
> このメソッドは、[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に参加している開発者アカウントでのみ使用できます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* ダウンロードする CAB ファイルの ID を取得します。 この ID を取得するには、[Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを使用して、特定のドライバー エラーに関する詳細情報を取得し、そのメソッドの応答本文にある **cabIdHash** の値を使います。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/cabdownload``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | 文字列 | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  |
|---------------|--------|---------------|------|
| applicationId | string | エラー データを取得するドライバーの製品 ID です。 |  ○  |
| cabIdHash | 文字列 | ダウンロードする CAB ファイルの一意の ID です。 この ID を取得するには、[Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを使用して、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文にある **cabIdHash** の値を使います。 |  必須  |

 
### <a name="request-example"></a>要求の例

次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/cabdownload?applicationId=18430592857500421&cabIdHash=c1a51104-d682-4230-be14-7278b18e3555 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。 呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。

## <a name="related-topics"></a>関連トピック

* [Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)
* [Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)
