---
title: POST (/users/xuid({xuid})/resetreputation)
assetID: 3b76857f-b043-2c76-cf0c-c8f355fe3849
permalink: en-us/docs/xboxlive/rest/uri-usersxuidresetreputationpost.html
description: " POST (/users/xuid({xuid})/resetreputation)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2918249eaf359b383e89f24b8a37352bc3fe5132
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623527"
---
# <a name="post-usersxuidxuidresetreputation"></a>POST (/users/xuid({xuid})/resetreputation)
強制チーム アカウント ハイジャックでは (たとえば) 後、指定したユーザーの評価スコアをいくつかの任意の値に設定を有効にします。 これらの Uri のドメインが`reputation.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4E5)
  * [承認](#ID4EJB)
  * [必要な要求ヘッダー](#ID4E5B)
  * [要求本文](#ID4EYD)
  * [HTTP 状態コード](#ID4EOE)
  * [応答本文](#ID4EQH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
テスト目的で、製品版を除くすべてのサンド ボックス内のユーザーと他のパートナーの製品版を除くすべてのサンド ボックスによって、このメソッドを呼び出すことも可能性があります。 この要求設定、ユーザーの「基本」評判のスコア、建設的なフィードバックの重み付けがすべてゼロ化ことに注意してください。この呼び出しを行った後、ユーザーの実際の評価は、これらの基本スコアと、アンバサダー ボーナスと自分のフォロワー ボーナスになります。
  
<a id="ID4E5"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| string| Xbox ユーザー ID (XUID) の指定したユーザー。| 
  
<a id="ID4EJB"></a>

 
## <a name="authorization"></a>Authorization
 
パートナー: から小売サンド ボックスの**PartnerClaim**強制チームからは他のすべてのサンド ボックス**PartnerClaim**します。
 
ユーザー: から製品版を除くすべてのサンド ボックスの**XuidClaim**と**TitleClaim**します。
  
<a id="ID4E5B"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
All: から**コンテンツの種類: アプリケーション/json**します。
 
パートナー: から**X Xbl コントラクト バージョン**(現在のバージョンが 101)、 **X-Xbl-サンド ボックス**します。
 
ユーザー: から**X Xbl コントラクト バージョン**(現在のバージョンでは 101 です)。
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:101.| 
  
<a id="ID4EYD"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4E5D"></a>

 
### <a name="sample-request"></a>要求のサンプル
 
要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメント。
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EOE"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| OK。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 500| 内部サーバー エラー| サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。| 
| 503| サービス利用不可| 要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。| 
  
<a id="ID4EQH"></a>

 
## <a name="response-body"></a>応答本文
 
成功した場合、応答本文が空です。 失敗した場合、[サービス エラー (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。
 
<a id="ID4E3H"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

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

   