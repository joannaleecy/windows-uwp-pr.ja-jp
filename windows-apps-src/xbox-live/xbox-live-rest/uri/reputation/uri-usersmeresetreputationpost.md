---
title: POST (/users/me/resetreputation)
assetID: 1a4fed45-f608-dac2-3384-2ee493112f7b
permalink: en-us/docs/xboxlive/rest/uri-usersmeresetreputationpost.html
description: " POST (/users/me/resetreputation)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fc770673ac7e4034004f58032c7fa66cb28413e7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632687"
---
# <a name="post-usersmeresetreputation"></a>POST (/users/me/resetreputation)
強制チーム アカウント ハイジャックでは (たとえば) 後、現在のユーザーの評価スコアをいくつかの任意の値に設定を有効にします。 これらの Uri のドメインが`reputation.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [承認](#ID4E5)
  * [必要な要求ヘッダー](#ID4ETB)
  * [要求本文](#ID4END)
  * [HTTP 状態コード](#ID4EDE)
  * [応答本文](#ID4EFH)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
テスト目的で、製品版を除くすべてのサンド ボックス内のユーザーと他のパートナーの製品版を除くすべてのサンド ボックスによって、このメソッドを呼び出すことも可能性があります。 この要求設定、ユーザーの「基本」評判のスコア、建設的なフィードバックの重み付けがすべてゼロ化ことに注意してください。この呼び出しを行った後、ユーザーの実際の評価は、これらの基本スコアと、アンバサダー ボーナスと自分のフォロワー ボーナスになります。
  
<a id="ID4E5"></a>

 
## <a name="authorization"></a>Authorization
 
パートナー: から小売サンド ボックスの**PartnerClaim**強制チームからは他のすべてのサンド ボックス**PartnerClaim**します。
 
ユーザー: から製品版を除くすべてのサンド ボックスの**XuidClaim**と**TitleClaim**します。
  
<a id="ID4ETB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
All: から**コンテンツの種類: アプリケーション/json**します。
 
パートナー: から**X Xbl コントラクト バージョン**(現在のバージョンが 101)、 **X-Xbl-サンド ボックス**します。
 
ユーザー: から**X Xbl コントラクト バージョン**(現在のバージョンでは 101 です)。
 
| Header| 種類| 説明| 
| --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
| X RequestedServiceVersion|  | この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:101.| 
  
<a id="ID4END"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4ETD"></a>

 
### <a name="sample-request"></a>要求のサンプル
 
要求本文は、単純な[ResetReputation (JSON)](../../json/json-resetreputation.md)ドキュメント。
 

```cpp
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
      
```

   
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | 
| 200| OK| OK。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 500| 内部サーバー エラー| サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。| 
| 503| サービス利用不可| 要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。| 
  
<a id="ID4EFH"></a>

 
## <a name="response-body"></a>応答本文
 
成功した場合、応答本文が空です。 失敗した場合、[サービス エラー (JSON)](../../json/json-serviceerror.md)ドキュメントが返されます。
 
<a id="ID4ERH"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
         
```

   
<a id="ID4E2H"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E4H"></a>

 
##### <a name="parent"></a>Parent 

[/users/me/resetreputation](uri-usersmeresetreputation.md)

   