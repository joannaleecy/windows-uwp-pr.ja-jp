---
title: POST (/users/batch/profile/settings)
assetID: 2a619148-a626-f413-bda1-a2790063075d
permalink: en-us/docs/xboxlive/rest/uri-usersbatchprofilesettingspost.html
description: " POST (/users/batch/profile/settings)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: aa029c0cffa369eeb802521b394a52b958b54557
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8729127"
---
# <a name="post-usersbatchprofilesettings"></a>POST (/users/batch/profile/settings)
ユーザーまたはユーザーのプロファイルを取得します。 これらの Uri のドメインが`profile.xboxlive.com`します。
 
  * [注釈](#ID4EV)
  * [Authorization](#ID4EFB)
  * [必要な要求ヘッダー](#ID4EOB)
  * [要求本文](#ID4EZC)
  * [応答本文](#ID4EJD)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a>注釈
 
これで許可されているのみ完全修飾プロファイル URL です。 クライアントからその他のすべてのプロファイル Api がブロックされます。
  
<a id="ID4EFB"></a>

 
## <a name="authorization"></a>Authorization
 
プロファイルにアクセスするに通常の認証トークンと要求のみが必要です。
  
<a id="ID4EOB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
| ヘッダー| 型| 説明| 
| --- | --- | --- | 
| x xbl コントラクト バージョン| 32 ビットの符号なし整数| コントラクト バージョンは、Xbox 360 の API 呼び出しは、このを区別するために 2 に設定する必要があります。| 
| コンテンツの種類| string| 値 = <code>application/json</code>| 
  
<a id="ID4EZC"></a>

 
## <a name="request-body"></a>要求本文
 
<a id="ID4E6C"></a>

 
### <a name="sample-request"></a>要求の例
 

```cpp
POST /users/batch/profile/settings
   {
      "userIds":[
         "2533274791381930"
       ],
      "settings":[
         "GameDisplayName",
         "GameDisplayPicRaw",
         "Gamerscore",
         "Gamertag"
      ]
   }
      
```

   
<a id="ID4EJD"></a>

 
## <a name="response-body"></a>応答本文
 
<a id="ID4EPD"></a>

 
### <a name="sample-response"></a>応答の例
 

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
                  "value":"http://images-eds.xboxlive.com/image?url=z951ykn43p4FqWbbFvR2Ec.8vbDhj8G2Xe7JngaTToBrrCmIEEXHC9UNrdJ6P7KIN0gxC2r1YECCd3mf2w1FDdmFCpSokJWa2z7xtVrlzOyVSc6pPRdWEXmYtpS2xE4F"
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

   
<a id="ID4EZD"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E2D"></a>

 
##### <a name="parent"></a>Parent 

[/users/batch/profile/settings](uri-usersbatchprofilesettings.md)

  
<a id="ID4EFE"></a>

 
##### <a name="reference"></a>リファレンス 

[Profile (JSON)](../../json/json-profile.md)

   