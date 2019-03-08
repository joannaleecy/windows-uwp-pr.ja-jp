---
title: GET (/users/{userId}/profile/settings/people/{userList})
assetID: f6553499-89e2-f21b-a00f-7e5437c045ff
permalink: en-us/docs/xboxlive/rest/uri-usersuseridprofilesettingspeopleuserlistget.html
description: " GET (/users/{userId}/profile/settings/people/{userList})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f868fdf4f3d5cd36000784d9c5a3437fa5d67ffa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593857"
---
# <a name="get-usersuseridprofilesettingspeopleuserlist"></a>GET (/users/{userId}/profile/settings/people/{userList})
ユーザーのプロファイルを取得またはユーザーのモニカーでのユーザーをサポートします。 これらの Uri のドメインが`profile.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [URI パラメーター](#ID4EKB)
  * [クエリ文字列パラメーター](#ID4EVB)
  * [必要な要求ヘッダー](#ID4EQC)
  * [要求本文](#ID4E2D)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
**userList**と**の userid と**は相互に排他的なパラメーターです。 両方またはいずれかが指定されている場合、られます、 **BadRequest**戻ります。 **userList**は複数の名前付きリストが要求する便利なシナリオで将来の配列です。 **userid と**で構成されます - Xuid の 10 進数値の文字列の JSON は、64 ビット符号なし整数のシリアル化に正しくないです。 64 ビット符号なし整数またはあいまいな定数のようにするのではなく、最後に、Xbox One での設定の名前、設定は通常の人間が判読できる名前**XONLINE_PROFILE_ASDF**します。
  
<a id="ID4EKB"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | 
| userId| string| 'Xuid(12345)'、'gt(myGamertag)' のいずれかまたは 'me' を指定できます。| 
| userList| string| 設定を取得するユーザーの名前付きのリスト。 現時点では、ユーザーは、サポートされているだけの一覧を示します。| 
  
<a id="ID4EVB"></a>

 
## <a name="query-string-parameters"></a>クエリ文字列パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | 
| settings| string| 設定名のコンマ区切りの一覧。| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| Header| 種類| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| x-xbl-contract-version| 32 ビット符号付き整数| 値 = 2| 
| コンテンツの種類| string| 値 = <code>application/json</code>| 
  
<a id="ID4E2D"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4EBE"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

```cpp
GET /users/me/profile/settings/people/people?settings=GameDisplayName,GameDisplayPicRaw,Gamerscore,Gamertag
      
```

  
<a id="ID4EKE"></a>

  
 
<a id="ID4EME"></a>

 
##### <a name="response-body"></a>応答本文 
応答は、 **ReadMultiSettingsResponseV2**オブジェクト。 呼び出し元のユーザーと仮定した場合に、1 つだけのフレンドがあります。
  

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

 [プロファイル (JSON)](../../json/json-profile.md)

   