---
title: POST (/users/xuid({xuid})/devices/current/titles/current)
assetID: d5e2d12d-ba75-2d04-2805-c69a4c143f73
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentpost.html
description: " POST (/users/xuid({xuid})/devices/current/titles/current)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b29a0bc796712d7b7c44a1fe8512f99bf09eb4fc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649527"
---
# <a name="post-usersxuidxuiddevicescurrenttitlescurrent"></a>POST (/users/xuid({xuid})/devices/current/titles/current)
ユーザーのプレゼンスとタイトルを更新します。 これらの Uri のドメインが`userpresence.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EEB)
  * [承認](#ID4EPB)
  * [必要な要求ヘッダー](#ID4ENE)
  * [省略可能な要求ヘッダー](#ID4ERG)
  * [要求本文](#ID4ERH)
  * [応答本文](#ID4EKAAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
この URI は、追加およびプレゼンス、機能豊富なプレゼンス、およびタイトルのメディアの状態データを更新するコンソール以外のプラットフォームでのすべてのタイトルで使用できます。
 
**SandboxId**今すぐ、XToken 内の要求から取得され、適用します。 場合、 **SandboxId**エンターテイメント検出サービス (EDS) は 400 Bad request エラーをスローしが存在しません。
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID) の対象ユーザーです。| 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a>Authorization
 
| 種類| 必須| 説明| 不足している場合の応答| 
| --- | --- | --- | --- | --- | --- | --- | 
| XUID| 〇| 呼び出し元の Xbox ユーザー ID (XUID)| 403 許可されていません| 
| titleId| 〇| タイトルのタイトルの Id| 403 許可されていません| 
| deviceId| Windows と Web 以外のすべての場合ははい| 呼び出し元の deviceId| 403 許可されていません| 
| deviceType| Web 以外のすべての場合ははい| 呼び出し元の deviceType| 403 許可されていません| 
| sandboxId| 呼び出しの場合ははい | 呼び出し元のサンド ボックス| 403 許可されていません| 
  
<a id="ID4ENE"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
| x-xbl-contract-version| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 値の例:3、vnext。| 
| Content-Type| string| 要求の値の例の本文の mime の種類: アプリケーション/json します。| 
| Content-Length| string| 要求の本文の長さ。 値の例:312.| 
| Host| string| サーバーのドメイン名。 値の例: presencebeta.xboxlive.com します。| 
  
<a id="ID4ERG"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. | 
  
<a id="ID4ERH"></a>

 
## <a name="request-body"></a>要求本文
 
要求オブジェクトが、 [TitleRequest](../../json/json-titlerequest.md)します。 本文に実際に存在するプロパティのみが更新されます。 任意のプロパティは、本文の一部ではありませんが上に存在するサーバーは変更されません。
 
<a id="ID4EAAAC"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

```cpp
{
  id:"12341234",
  placement:"snapped",
  state:"active"
}
      
```

   
<a id="ID4EKAAC"></a>

 
## <a name="response-body"></a>応答本文
 
成功した場合の場合は、200 または 201 作成済みの HTTP ステータス コードは、に応じて、返されたは。
 
エラー (HTTP 4 xx または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。
  
<a id="ID4EVAAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EXAAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/devices/current/titles/current](uri-usersxuiddevicescurrenttitlescurrent.md)

  
<a id="ID4EBBAC"></a>

 
##### <a name="further-information"></a>詳細情報 

[Marketplace の Uri](../marketplace/atoc-reference-marketplace.md)

 [その他の参照](../../additional/atoc-xboxlivews-reference-additional.md)

   