---
author: mcleanbyron
ms.assetid: 8C1E9E36-13AF-4386-9D0F-F9CB320F02F5
description: "Windows ストア申請 API のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを作成します。"
title: "Windows ストア申請 API を使用したパッケージ フライトの作成"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 35823bd1fd0c059ebc9b2107c31400a7ad788a1e

---

# Windows ストア申請 API を使用したパッケージ フライトの作成




Windows ストア申請 API のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを作成します。

>**注:**&nbsp;&nbsp;このメソッドは、申請なしでパッケージ フライトを作成します。 パッケージ フライトの申請を作成するには、「[パッケージ フライト申請の管理](manage-flight-submissions.md)」のメソッドをご覧ください。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 パッケージ フライトを作成するアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |

<span/>

### 要求本文

要求本文には次のパラメーターがあります。
 
|  パラメーター  |  型  |  説明  |  必須かどうか  |
|------|------|------|------|
|  friendlyName  |  string  |  開発者によって指定されているパッケージ フライトの名前。  |  いいえ  |
|  groupIds  |  array  |  パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。 フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。  |  いいえ  |
|  rankHigherThan  |  string  |  現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。 このパラメーターを設定しない場合、新しいパッケージ フライトの順位は、すべてのパッケージ フライトで最も高くなります。 フライト グループの順位について詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。    |  いいえ  |

<span/>

### 要求の例

次の例は、ストア ID 9WZDNCRD911W を持つアプリの新しいパッケージ フライトを作成する方法を示しています。

```syntax
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1Q...
Content-Type: application/json
{
  "friendlyName": "myflight",
  "groupIds": [
    0
  ],
  "rankHigherThan": null
}

```

## 応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、次のセクションをご覧ください。

```json
{
  "flightId": "43e448df-97c9-4a43-a0bc-2a445e736bcd",
  "friendlyName": "myflight",
  "groupIds": [
    "0"
  ],
  "rankHigherThan": "671c2857-725e-4faf-9e9e-ea1191ef879c"
}
```

### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| flightId            | string  | パッケージ フライトの ID。 この値は、デベロッパー センターによって提供されます。  |
| friendlyName           | string  | 要求で指定されているパッケージ フライトの名前。   |  
| groupIds           | array  | 要求で指定されている、パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。 フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。   |
| rankHigherThan           | string  | 要求で指定されている、現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。 フライト グループの順位について詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。  |

<span/>

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 400  | 要求が無効です。 |
| 409  | 現在の状態が原因でパッケージ フライトを作成できませんでした。または、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。 |   
<span/>

## 関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージ フライトの取得](get-a-flight.md)
* [パッケージ フライトの削除](delete-a-flight.md)



<!--HONumber=Aug16_HO5-->


