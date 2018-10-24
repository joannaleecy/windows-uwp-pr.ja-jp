---
title: POST (/users/xuid({xuid})/devices/current/titles/current)
assetID: d5e2d12d-ba75-2d04-2805-c69a4c143f73
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/devices/current/titles/current)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ac24fb580696f1524ce7a6cf09dc1e492e9d2378
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5434386"
---
# <a name="post-usersxuidxuiddevicescurrenttitlescurrent"></a>POST (/users/xuid({xuid})/devices/current/titles/current)
ユーザーのプレゼンスでタイトルを更新します。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [Authorization](#ID4EPB)
  * [必要な要求ヘッダー](#ID4ENE)
  * [オプションの要求ヘッダー](#ID4ERG)
  * [要求本文](#ID4ERH)
  * [応答本文](#ID4EKAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
この URI は、コンソール以外のプラットフォームでのすべてのタイトルを追加し、プレゼンス、リッチ プレゼンスは、タイトルのメディアのプレゼンス データを更新するために使用できます。
 
**SandboxId**はここで、XToken で要求から取得され、適用されます。 **SandboxId**が存在しない場合は、エンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) 対象ユーザーのです。| 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a>Authorization
 
| 型| 必須かどうか| 説明| 不足している場合、応答| 
| --- | --- | --- | --- | --- | --- | --- | 
| XUID| はい| 呼び出し元のように、Xbox ユーザー ID (XUID)| 403 Forbidden| 
| titleId| はい| タイトルのタイトル Id| 403 Forbidden| 
| deviceId| Windows と Web 以外のすべての [はい] します。| 呼び出し元の deviceId| 403 Forbidden| 
| deviceType| Web 以外のすべての [はい]| 呼び出し元の deviceType| 403 Forbidden| 
| sandboxId| 呼び出しの [はい] | 呼び出し元のサンド ボックス| 403 Forbidden| 
  
<a id="ID4ENE"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。| 
| x xbl コントラクト バージョン| string| この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 値の例: 3, vnext します。| 
| Content-Type| string| 値の例の要求の本文の mime タイプ: アプリケーション/json します。| 
| Content-Length| string| 要求の本文の長さ。 値の例: 312 します。| 
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。| 
  
<a id="ID4ERG"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 1 です。| 
  
<a id="ID4ERH"></a>

 
## <a name="request-body"></a>要求本文
 
要求、 [TitleRequest](../../json/json-titlerequest.md)です。 本体で実際に存在するプロパティのみが更新されます。 任意のプロパティは、本文の一部ではないが、上に存在するサーバーは変更されません。
 
<a id="ID4EAAAC"></a>

 
### <a name="sample-request"></a>要求の例
 

```cpp
{
  id:"12341234",
  placement:"snapped",
  state:"active"
}
      
```

   
<a id="ID4EKAAC"></a>

 
## <a name="response-body"></a>応答本文
 
成功した場合、発生時または 200 201 Created の HTTP ステータス コードが返されますで適切なします。
 
エラー (HTTP 4 xx または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。
  
<a id="ID4EVAAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EXAAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/devices/current/titles/current](uri-usersxuiddevicescurrenttitlescurrent.md)

  
<a id="ID4EBBAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[マーケットプレース URI](../marketplace/atoc-reference-marketplace.md)

 [その他の参照情報](../../additional/atoc-xboxlivews-reference-additional.md)

   