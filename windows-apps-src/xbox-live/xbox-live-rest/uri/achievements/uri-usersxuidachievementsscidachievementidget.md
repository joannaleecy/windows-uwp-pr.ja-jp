---
title: GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})
assetID: 27318886-f084-d6a8-e582-3eb070ccbc38
permalink: en-us/docs/xboxlive/rest/uri-usersxuidachievementsscidachievementidget.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d64dc9fbae0e53880578ebff7576b028d6ecdf49
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4388751"
---
# <a name="get-usersxuidxuidachievementsscidachievementid"></a>GET (/users/xuid({xuid})/achievements/{scid}/{achievementid})
実績の詳細を取得します。 これらの Uri のドメインが`achievements.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
  * [Authorization](#ID4EAB)
  * [リソースのプライバシーの設定の効果](#ID4E4C)
  * [必要な要求ヘッダー](#ID4EPG)
  * [オプションの要求ヘッダー](#ID4EPH)
  * [要求本文](#ID4ECBAC)
  * [HTTP ステータス コード](#ID4ENBAC)
  * [応答本文](#ID4EBGAC)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID) がリソースにアクセスしているユーザー。 認証されたユーザーの XUID に一致する必要があります。| 
| scid| GUID| 対象の実績にアクセスしているサービス構成の一意の識別子。| 
| achievementid| 32 ビット符号なし整数| アクセスされている実績を (指定された SCID) 内で一意の識別子です。| 
  
<a id="ID4EAB"></a>

 
## <a name="authorization"></a>Authorization
 
承認要求の使用 | 要求| 必須?| 説明| 不足している場合の動作| 
| --- | --- | --- | --- | --- | --- | --- | 
| ユーザー| はい| Xbox live、要求が作成されている対象の有効なユーザーです。| 403 Forbidden| 
| Title (タイトル)| いいえ| 呼び出し元のタイトルです。| AuthZ によって異なります。 2013 月 1 日の時点で AuthZ は不足するいると、パブリックとしてマークされていないすべての Scid にアクセスが拒否されるための要求を提供しません。| 
| サンド ボックス| いいえ| サンド ボックスが、結果を取得する必要があります。| AuthZ によって異なります。 2013 月 1 日の時点で AuthZ は既定の要求を提供しません不足している場合。| 
  
<a id="ID4E4C"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a>リソースのプライバシーの設定の効果
 
リソースのプライバシーの設定の効果 | ユーザーの要求| ターゲット ユーザーのプライバシー設定| 動作| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| me| -| 前述のようにします。| 
| フレンド登録の依頼| すべてのユーザー| OK| 
| フレンド登録の依頼| フレンドのみ| OK| 
| フレンド登録の依頼| ブロック| 禁止されています。| 
| フレンド以外のユーザー| すべてのユーザー| OK| 
| フレンド以外のユーザー| フレンドのみ| 禁止されています。| 
| フレンド以外のユーザー| ブロック| 禁止されています。| 
| サード パーティのサイト| すべてのユーザー| OK| 
| サード パーティのサイト| フレンドのみ| 禁止されています。| 
| サード パーティのサイト| ブロック| 禁止されています。| 
  
<a id="ID4EPG"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Authorization| string| HTTP の認証の資格情報を認証します。 値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"です。| 
  
<a id="ID4EPH"></a>

 
## <a name="optional-request-headers"></a>オプションの要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X RequestedServiceVersion| string| この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。 要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。 既定値: 1 です。| 
| x xbl コントラクト バージョン| string| V1 既定値です。| 
| 同意言語| string| 目的のロケールとフォールバック (FR-FR, fr, EN-GB、en 世界、EN-US など) の一覧です。 ローカライズされた文字列の一致が見つかるまで、実績サービスは、一覧で動作します。 見つからない場合は、ユーザーの IP アドレスに由来するユーザー トークンで定義されている場所と一致しようとします。 まだ一致するローカライズされた文字列はありません。 が見つかった場合、タイトル開発者/発行元によって提供される既定の文字列を使用します。 | 
  
<a id="ID4ECBAC"></a>

 
## <a name="request-body"></a>要求本文
 
この要求の本文には、オブジェクトは送信されません。
  
<a id="ID4ENBAC"></a>

 
## <a name="http-status-codes"></a>HTTP ステータス コード
 
サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| 200| OK| セッションが正常に取得されました。| 
| 301| 完全に移動| サービスは、さまざまな URI に移動しました。| 
| 307| 一時的なリダイレクト| このリソースの URI が一時的に変更されました。| 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。| リソースのバージョンがサポートされていません。MVC レイヤーによって拒否する必要があります。| 
| 408| 要求のタイムアウト| 要求にかかった時間が長すぎます。| 
| 410| なった| 要求されたリソースが利用可能ではなくなりました。| 
  
<a id="ID4EBGAC"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EHGAC"></a>

 
### <a name="sample-response"></a>応答の例
 

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
                "url":"http://www.xbox.com"
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

   