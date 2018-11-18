---
title: GET (/users/{userId}/profile/settings/people/{userList})
assetID: f6553499-89e2-f21b-a00f-7e5437c045ff
permalink: en-us/docs/xboxlive/rest/uri-usersuseridprofilesettingspeopleuserlistget.html
author: KevinAsgari
description: " GET (/users/{userId}/profile/settings/people/{userList})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d8f04950b5aff14bf943f9827f0a2af52ddbcb9c
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7163774"
---
# <a name="get-usersuseridprofilesettingspeopleuserlist"></a>GET (/users/{userId}/profile/settings/people/{userList})
ユーザーのプロファイルを取得またはユーザー, People モニカーをサポートします。 これらの Uri のドメインが`profile.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EKB)
  * [クエリ文字列パラメーター](#ID4EVB)
  * [必要な要求ヘッダー](#ID4EQC)
  * [要求本文](#ID4E2D)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
**userList**と**ユーザー Id**は、相互に排他的なパラメーターです。 いずれかまたは両方が指定されている場合は、 **BadRequest**をもう一度表示されます。 **userList**は、複数の名前付きリストが要求に便利なシナリオで将来の配列です。 **ユーザー Id**は Xuid の 10 進数の文字列の構成 - JSON は 64 ビットの符号なし整数をシリアル化するのには不適切です。 最後に、Xbox One の設定の名前は、通常のわかりやすい名前ではなく 64 ビットの符号なし整数またはあいまいな定数**XONLINE_PROFILE_ASDF**などの設定になります。
  
<a id="ID4EKB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| userId| string| 'Xuid(12345)'、'gt(myGamertag)' の 'me' またはいずれかを指定できます。| 
| userList| string| 名前付きの設定を取得するユーザーの一覧。 現時点では、ユーザーは、サポートされている唯一の一覧を示します。| 
  
<a id="ID4EVB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | --- | --- | --- | 
| settings| string| 設定名のコンマ区切りリスト。| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x xbl コントラクト バージョン| 32 ビット符号付き整数| 値 = 2| 
| コンテンツの種類| string| 値 = <code>application/json</code>| 
  
<a id="ID4E2D"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4EBE"></a>

 
### <a name="sample-request"></a>要求の例
 

```cpp
GET /users/me/profile/settings/people/people?settings=GameDisplayName,GameDisplayPicRaw,Gamerscore,Gamertag
      
```

  
<a id="ID4EKE"></a>

  
 
<a id="ID4EME"></a>

 
##### <a name="response-body"></a>応答本文 
応答は、 **ReadMultiSettingsResponseV2**オブジェクトです。 呼び出し元のユーザーと仮定すると、1 つだけのフレンドがあります。
  

```cpp
{
      "profileUsers":[
         {
            "id":"2533274791381930",
            "settings":[
               {
                  "id":"GameDisplayName",
                  "value":"John Smith"
               },
               {
                  "id":"GameDisplayPicRaw",
                  "value":"http://images-eds.xboxlive.com/image?url=z951ykn43p4FqWbbFvR2Ec.8vbDhj8G2Xe7JngaTToBrrCmIEEXHC9UNrdJ6P7KIN0gxC2r1YECCd3mf2w1FDdmFCpSokJWa2z7xtVrlzOyVSc6pPRdWEXmYtpS2xE4F&format=png&w=64&h=64"
               },
               {
                  "id":"Gamerscore",
                  "value":"0"
               },
               {
                  "id":"Gamertag",
                  "value":"CracklierJewel9"
               }
            ]
         }
      ]
   }
         
```

   
<a id="ID4E3E"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E5E"></a>

 
##### <a name="parent"></a>Parent 

[/users/{userId}/profile/settings/people/{userList}?settings={settings}](uri-usersuseridprofilesettingspeopleuserlist.md)

 [Profile (JSON)](../../json/json-profile.md)

   