---
title: GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})
assetID: 27318886-f084-d6a8-e582-3eb070ccbc38
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementidget.html
description: " GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 19083937d48d8c312215f1734513d83c59f52f0d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627507"
---
# <a name="get-usersxuidxuidachievementsscidachievementid"></a>GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})
実績の詳細を取得します。 これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
  * [承認](#ID4EAB)
  * [リソースのプライバシーの設定の効果](#ID4E4C)
  * [必要な要求ヘッダー](#ID4EPG)
  * [省略可能な要求ヘッダー](#ID4EPH)
  * [要求本文](#ID4ECBAC)
  * [HTTP 状態コード](#ID4ENBAC)
  * [応答本文](#ID4EBGAC)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID)、ユーザーがリソースにアクセスされているのです。 認証されたユーザーの XUID に一致する必要があります。| 
| scid| GUID| 達成にアクセスしているサービス構成の一意の識別子。| 
| achievementid| 32 ビット符号なし整数| アクセスされている実績を (指定された SCID) 内で一意の識別子です。| 
  
<a id="ID4EAB"></a>

 
## <a name="authorization"></a>Authorization
 
承認要求の使用 | 要求| 必須?| 説明| 不足している場合の動作| 
| --- | --- | --- | --- | --- | --- | --- | 
| ユーザー| 〇| Xbox LIVE、要求が行われるに有効なユーザー。| 403 許可されていません| 
| タイトル| X| 呼び出し元のタイトル。| AuthZ に依存します。 2013 年 5 月 1 日現在 AuthZ は不足するいると、public としてマークされていない任意の SCIDs にアクセスが拒否されますので、要求を提供していません。| 
| サンドボックス| X| 結果の取得元のサンド ボックス。| AuthZ に依存します。 2013 年 5 月 1 日現在 AuthZ は既定の要求を指定しない不足しているときにします。| 
  
<a id="ID4E4C"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果
 
リソースのプライバシーの設定の効果 | 要求元のユーザー| ターゲット ユーザーのプライバシーの設定| 動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Me| -| 前述のようにします。| 
| friend| すべてのユーザー| OK| 
| friend| 友達のみ| OK| 
| friend| ブロック済み| 禁止されています。| 
| フレンド以外のユーザー| すべてのユーザー| OK| 
| フレンド以外のユーザー| 友達のみ| 禁止されています。| 
| フレンド以外のユーザー| ブロック済み| 禁止されています。| 
| サード パーティのサイト| すべてのユーザー| OK| 
| サード パーティのサイト| 友達のみ| 禁止されています。| 
| サード パーティのサイト| ブロック済み| 禁止されています。| 
  
<a id="ID4EPG"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP 認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。| 
  
<a id="ID4EPH"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。 要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。 ［既定値］:1. | 
| x-xbl-contract-version| string| V1 の既定値です。| 
| Accept Language| string| 目的のロケールとフォールバック (FR-FR、fr、EN-GB、en WW、EN-US など) の一覧です。 ローカライズされた文字列の一致が見つかるまで一覧をアチーブメント サービスの動作します。 見つからない場合、ユーザーの IP アドレスから付属しているユーザー トークンで定義されている場所を照合しようと試みます。 いない対応するローカライズされた文字列もが見つかった場合は、タイトルの開発者/発行元によって提供される既定の文字列を使用します。 | 
  
<a id="ID4ECBAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4ENBAC"></a>

 
## <a name="http-status-codes"></a>HTTP 状態コード
 
サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。
 
| コード| 理由語句| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得します。| 
| 301| 完全に移動| サービスが別の URI に移動します。| 
| 307| 一時的なリダイレクト| このリソースの URI が一時的に変更されました。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable| リソースのバージョンはサポートされていません。MVC のレイヤーによって拒否されます必要があります。| 
| 408| 要求のタイムアウト| 要求がかかり過ぎて、完了します。| 
| 410| なった| 要求されたリソースは使用できなくします。| 
  
<a id="ID4EBGAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EHGAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{
    "achievement":
    {
        "id":"3",
        "serviceConfigId":"b5dd9daf-0000-0000-0000-000000000000",
        "name":"Default NameString for Microsoft Achievements Sample Achievement 3",
        "titleAssociations":
        [{
                "name":"Microsoft Achievements Sample",
                "id":3051199919,
                "version":"abc"
        }],
        "progressState":"Achieved",
        "progression":
        {
                "requirements":null,
                "timeUnlocked":"2013-01-17T03:19:00.3087016Z",
        },
        "mediaAssets":
        [{
                "name":"Icon Name",
                "type":"Icon",
                "url":"https://www.xbox.com"
        }],
        "platform":"D",
        "isSecret":true,
        "description":"Default DescriptionString for Microsoft Achievements Sample Achievement 3",
        "lockedDescription":"Default UnachievedString for Microsoft Achievements Sample Achievement 3",
        "productId":"12345678-1234-1234-1234-123456789012",
        "achievementType":"Challenge",
        "participationType":"Individual",
        "timeWindow":
        {
                "startDate":"2013-02-01T00:00:00Z",
                "endDate":"2100-07-01T00:00:00Z"
        },
        "rewards":
        [{
                "name":null,
                "description":null,
                "value":"10",
                "type":"Gamerscore",
                "valueType":"Int"
        },
        {
                "name":"Default Name for InAppReward for Microsoft Achievements Sample Achievement 3",
                "description":"Default Description for InAppReward for Microsoft Achievements Sample Achievement 3",
                "value":"1",
                "type":"InApp",
                "valueType":"String"
        }],
        "estimatedTime":"06:12:14",
        "deeplink":"aWFtYWRlZXBsaW5r",
        "isRevoked":false
    }
}
         
```

   
<a id="ID4ERGAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ETGAC"></a>

 
##### <a name="parent"></a>Parent 

[/users/xuid({xuid})/achievements/{scid}/{achievementid}](uri-usersxuidachievementsscidachievementid.md)

   