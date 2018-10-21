---
title: POST (/users/xuid({xuid})/resetreputation)
assetID: 3b76857f-b043-2c76-cf0c-c8f355fe3849
permalink: en-us/docs/xboxlive/rest/uri-usersxuidresetreputationpost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/resetreputation)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5fefcfd0f49449095b08a1463931513440bc69c1
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5171722"
---
# <a name="post-usersxuidxuidresetreputation"></a>POST (/users/xuid({xuid})/resetreputation)
により、実施チームは、アカウント ハイジャック (たとえば) したら、任意の値をいくつかを指定したユーザーの評判スコアを設定します。 これらの Uri のドメインが`reputation.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [Authorization](#ID4EJB)
  * [必要な要求ヘッダー](#ID4E5B)
  * [要求本文](#ID4EYD)
  * [HTTP ステータス コード](#ID4EOE)
  * [応答本文](#ID4EQH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
Retail を除くすべてのサンド ボックスの他のパートナー様とテストのために、Retail を除くすべてのサンド ボックス内のユーザーによって、このメソッドを呼び出すも可能性があります。 この要求設定、ユーザーの評判スコアを「基本」、肯定的なフィードバック良い評価の彼は重みをすべて消去をことに注意してください。この呼び出しを行った後、ユーザーの実際の評判は、この基本スコアと自分のアンバサダー ボーナスと自分のフォロワー ボーナスになります。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID)、指定したユーザーの。| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a>Authorization
 
パートナーから:、市販のサンド ボックス、実施チームから**PartnerClaim**すべてのサンド ボックスに対して、 **PartnerClaim**します。
 
ユーザーから: 製品版、 **XuidClaim** **TitleClaim**を除くすべてのサンド ボックスにします。
  
<a id="ID4E5B"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
すべてから:**コンテンツの種類: アプリケーション/json**します。
 
パートナーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)、 **X の Xbl のサンド ボックス**。
 
ユーザーから: **X Xbl コントラクト バージョン**(現在のバージョンは 101)。
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。| 
| X RequestedServiceVersion|  | この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 101 します。| 
  
<a id="ID4EYD"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4E5D"></a>

 
### <a name="sample-request"></a>要求の例
 
要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメントです。
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EOE"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| OK。| 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 404| 見つかりません。| 指定されたリソースは見つかりませんでした。| 
| 500| 内部サーバー エラー| サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。| 
| 503| Service Unavailable| 要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度やり直してください。| 
  
<a id="ID4EQH"></a>

 
## <a name="response-body"></a>応答本文
 
成功した場合、応答本文は空です。 失敗した場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。
 
<a id="ID4E3H"></a>

 
### <a name="sample-response"></a>応答の例
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4EHAAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EJAAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/resetreputation](uri-usersxuidresetreputation.md)

   