---
author: Xansky
description: アプリのメタデータ REST API を使用して、アプリの特定の種類のメタデータにアクセスする方法について説明します。 この API は、広告ネットワークで使用することにより、Microsoft Store 内のアプリに関する情報を取得し、広告主への広告スペースの販売を向上させることを目的としています。
title: 広告ネットワーク用のアプリのメタデータ API
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、広告ネットワーク、アプリのメタデータ
ms.assetid: f0904086-d61f-4adb-82b6-25968cbec7f3
ms.localizationpriority: medium
ms.openlocfilehash: 9533b244174cc5770a68f866c722db1781fdd544
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6029899"
---
# <a name="app-metadata-api-for-advertising-networks"></a>広告ネットワーク用のアプリのメタデータ API

広告ネットワークでは、*アプリのメタデータ API* を使用して、プログラムによって Microsoft Store 内のアプリに関するメタデータを取得します。これには、アプリの Store 登録情報の説明やカテゴリ、アプリが 13 歳未満の子供を対象とするかどうかなどの詳細が含まれます。 この API へのアクセスは、現在、Microsoft によって API へのアクセス許可が付与されている開発者に制限されています。

この記事では、[アプリのメタデータ API ポータル](https://admetadata.portal.azure-api.net/)を使用して API へのアクセスを要求する方法、API にアクセスするためのサブスクリプション キーを取得する方法、API を呼び出す方法について説明します。

## <a name="request-access"></a>アクセスを要求する

広告ネットワークでは、次の手順に従って、アプリのメタデータ API へのアクセスを要求できます。

1. アプリのメタデータ API ポータルの [https://admetadata.portal.azure-api.net/signup](https://admetadata.portal.azure-api.net/signup) ページに移動します。
2. 必要な情報を入力し、**[サインアップ]** をクリックします。
3. 同じサイトで、**[製品]** タブをクリックし、**[広告用のアプリの詳細]** をクリックします。
4. 次のページで、**[サブスクライブ]** をクリックします。 これにより、アプリのメタデータ API へのアクセスの要求が Microsoft に送信されます。

要求が送信されてから、約 24 時間以内に、要求が許可されたか、拒否されたかをメールで通知します。

<span id="get-key" />

## <a name="get-your-subscription-key"></a>サブスクリプション キーを取得する

アプリのメタデータ API へのアクセスが許可されている場合は、次の手順に従ってサブスクリプション キーを取得します。 API の呼び出しの要求ヘッダーでこのキーを渡す必要があります。

1. アプリのメタデータ API ポータルの [https://admetadata.portal.azure-api.net/signin](https://admetadata.portal.azure-api.net/signin) ページに移動し、メール アドレスとパスワードでサインインします。
2. サイトの右上隅にある自分の名前をクリックし、**[プロファイル]** をクリックします。
3. ページの **[サブスクリプション]** セクションで、**[主キー]** の横にある **[表示]** をクリックします。 これが自分のサブスクリプション キーです。 後で API を呼び出すときに使用できるように、このキーをコピーします。

<span id="call-the-api" />

## <a name="call-the-api"></a>API を呼び出す

サブスクリプション キーを確認したら、任意のプログラミング言語から、HTTP REST 構文を使用して、API を呼び出すことができます。 API の構文については、後の「[API 構文](#syntax)」をご覧ください。 C#、JavaScript、Python、およびその他のいくつかの言語でコード例を表示するには、アプリのメタデータ API ポータルの **[API]** タブをクリックし、**[アプリの詳細]** をクリックして、ページの下部にある **[コード サンプル]** セクションを参照します。

または、アプリのメタデータ API ポータルによって提供される UI を使って、API を呼び出すこともできます。
  1. ポータルで、**[API]** タブをクリックして、**[アプリの詳細]** をクリックします。
  2. 次のページで、メタデータを取得するアプリの [app_id](#request-parameters) を **[app_id]** フィールドに入力し、サブスクリプション キーを **[Ocp_Apim_Subscription-Key]** フィールドに入力します。
  3. **[送信]** をクリックします。 応答は、ページの下部に表示されます。


<span id="syntax" />

## <a name="api-syntax"></a>API 構文

このメソッドの要求の構文は次のとおりです。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET   | ```https://admetadata.azure-api.net/v1/app/{app_id}``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Ocp-Apim-Subscription-Key | 文字列 | 必須。 [アプリのメタデータ API ポータルから取得した](#get-key)サブスクリプション キー。  |

<span/>

### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------|
| app_id | 文字列 | 必須。 メタデータを取得する対象となるアプリの ID。 次のいずれかの値を使用できます。<br/><br/><ul><li>アプリのストア ID。 ストア ID の例は 9NBLGGH29DM8 です。</li><li>当初は Windows 8.x または Windows Phone 8.x 用にビルドされたアプリの製品ID (*アプリID* とも呼ばれる)。 製品 ID は GUID です。</li></ul> |

<span/>

### <a name="request-example"></a>要求の例

次の例は、ストア ID が 9NBLGGH29DM8 であるアプリのメタデータを取得する方法を示しています。

```syntax
GET https://admetadata.azure-api.net/v1/app/9NBLGGH29DM8 HTTP/1.1
Ocp-Apim-Subscription-Key: <subscription key>
```

### <a name="response-body"></a>応答本文

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。

```json
{
    "storeId":"9NBLGGH29DM8",
    "name":"Contoso Sports App",
    "description":"Catch the latest scores and replays using Contoso Sports App!",
    "phoneStoreGuid":"920217d7-90da-4019-99e8-46e4a6bd2594",
    "windowsStoreGuid":"d7e982e7-fbf3-42b5-9dad-72b65bd4e248",
    "storeCategory":"Sports",
    "iabCategory":"Sports",
    "iabCategoryId":"IAB17",
    "coppa":false,
    "downloadUrl":"https://www.microsoft.com/store/apps/9nblggh29dm8",
    "isLive":true,
    "iconUrls":[
      "//store-images.microsoft.com/image/apps.15753.13510798883747357.b6981489-6fdd-4fec-b655-a822247d5a76.33529096-a723-4204-9da9-a5dd8b328d4e"
    ],
    "type":"App",
    "devices":[
      "PC",
      "Phone"
    ],
    "platformVersions":[
      "Windows.Universal"
    ],
    "screenshotUrls":[
      "//store-images.microsoft.com/image/apps.15901.19810723133740207.c9781069-6fef-5fba-a055-c922051d59b6.40129896-d083-5604-ab79-aba68bfa084f"
    ]
}
```

応答本文の値について詳しくは、次の表をご覧ください。

| 値      | 型   | 説明    |
|------------|--------|--------------------|
| storeId           | 文字列  | アプリのストア ID。 ストア ID の例は 9NBLGGH29DM8 です。     |  
| name           | 文字列  | アプリの名前。   |
| description           | 文字列  | アプリのストア登録情報にある説明。  |
| phoneStoreGuid           | 文字列  | アプリの製品 ID (Windows Phone 8.x)。 これは GUID です。  |
| windowsStoreGuid           | 文字列  | アプリの製品 ID (Windows 8.x)。 これは GUID です。 |
| storeCategory           | 文字列  | ストアでのアプリのカテゴリ。 サポートされる値については、ストア内のアプリの[カテゴリとサブカテゴリの一覧](../publish/category-and-subcategory-table.md)をご覧ください。  |
| iabCategory           | 文字列  | Interactive Advertising Bureau (IAB) によって定義されているアプリのコンテンツのカテゴリ。 たとえば、**News** や **Sports** です。 コンテンツのカテゴリの一覧については、IAB の Web サイトで [IAB Tech Lab のコンテンツ分類](https://www.iab.com/guidelines/iab-quality-assurance-guidelines-qag-taxonomy)のページをご覧ください。   |
| iabCategoryId           | 文字列  | アプリのコンテンツ カテゴリの ID。 たとえば、**IAB12** はニュース カテゴリの ID で、**IAB17** はスポーツ カテゴリの ID です。 コンテンツ カテゴリ ID の一覧については、[OpenRTB API 仕様](http://www.iab.com/wp-content/uploads/2015/05/OpenRTB_API_Specification_Version_2_3_1.pdf)のセクション 5.1 をご覧ください。 |
| coppa           | ブール値  | アプリが 13 歳未満の子供を対象しており、児童オンライン プライバシー保護法 (COPPA) の義務がある場合は true。それ以外の場合は false です。  |
| downloadUrl           | 文字列  | ストア内のアプリの登録情報へのリンク。 このリンクは、```https://www.microsoft.com/store/apps/<Store ID>``` の形式で示されます。  |
| isLive           | ブール値  | アプリが現在ストアで利用可能な場合は true。それ以外の場合は false。  |
| iconUrls           | 配列  |  アプリに関連付けられたアイコン URL への相対パスを含む 1 つ以上の文字列の配列。 アイコンを取得するには、URL の先頭に *http* または *https* を付けます。  |
| type           | 文字列  | **App** または **Game** のいずれかの文字列。  |
| devices           |  配列  | アプリがサポートするデバイスの種類を指定する次の 1 つ以上の文字列の配列: **PC**、**Phone**、**Xbox**、**IoT**、**Server**、**Holographic**。  |
| platformVersions           | 配列  |  アプリがサポートするプラットフォームを指定する次の 1 つ以上の文字列の配列: **Windows.Universal**、**Windows.Windows8x**、**Windows.WindowsPhone8x**。  |
| screenshotUrls           | 配列  | このアプリのスクリーンショット URL への相対パスを含む 1 つ以上の文字列の配列。 スクリーンショットを取得するには、URL の先頭に *http* または *https* を付けます。  |

<span/>



 

 
