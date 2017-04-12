---
author: mcleanbyron
ms.assetid: 3D6EE7D7-7D75-499D-AA7A-55DA1C485BA6
description: "Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードするには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 このメソッドは、IHV のみを対象としています。"
title: "Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードする"
ms.author: mcleans
ms.date: 03/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア分析 API, CAB のダウンロード"
ms.openlocfilehash: 9a8539a3d9d8f85fd9277165eb393eb372459b0a
ms.sourcegitcommit: 64cfb79fd27b09d49df99e8c9c46792c884593a7
translationtype: HT
---
# <a name="download-the-cab-file-for-a-windows-10-driver-error"></a>Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードする

Windows 10 の特定のドライバー エラーに関連付けられている CAB ファイルをダウンロードするには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 このメソッドを使うには、事前に [Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを使用し、ダウンロードする CAB ファイルの ID を取得しておく必要があります。

Windows ストア分析 API に含まれる、[Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)メソッドおよび [Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを利用すると、OEM ハードウェア エラーに関する他の情報を取得することもできます。

> [!NOTE]
> このメソッドは、[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に参加している開発者アカウントでのみ使用できます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* ダウンロードする CAB ファイルの ID を取得します。 この ID を取得するには、[Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを使用して、特定のドライバー エラーに関する詳細情報を取得し、そのメソッドの応答本文にある **cabIdHash** の値を使います。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/cabdownload``` |

<span/> 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/> 

### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  |
|---------------|--------|---------------|------|
| cabIdHash | string | ダウンロードする CAB ファイルの一意の ID です。 この ID を取得するには、[Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを使用して、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文にある **cabIdHash** の値を使います。 |  必須  |

<span/>
 
### <a name="request-example"></a>要求の例

次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/cabdownload?cabIdHash=c1a51104-d682-4230-be14-7278b18e3555 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。 呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。

## <a name="related-topics"></a>関連トピック

* [Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)
* [Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)
