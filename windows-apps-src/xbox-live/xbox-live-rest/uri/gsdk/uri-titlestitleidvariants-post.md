---
title: POST (/titles/{titleId}/variants)
assetID: 84303448-5a11-d96f-907d-77f57f859741
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidvariants-post.html
description: " POST (/titles/{titleId}/variants)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 17974ddf7dec26abac18ccee9fda5249bc9d656f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618497"
---
# <a name="post-titlestitleidvariants"></a>POST (/titles/{titleId}/variants)
URI の id。 指定したタイトルのゲームのバリアントのリストを取得するクライアントによって呼び出されますこれらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EZ)
  * [必要な要求ヘッダー](#ID4EIB)
  * [省略可能な要求ヘッダー](#ID4EED)
  * [承認](#ID4E3D)
  * [要求本文](#ID4EEE)
  * [必要な応答ヘッダー](#ID4ELF)
  * [省略可能な応答ヘッダー](#ID4EMG)
  * [応答本文](#ID4EEH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 説明| 
| --- | --- | 
| タイトル id| 要求の操作対象のタイトルの ID。| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a>ホスト名

gameserverds.xboxlive.com
 
<a id="ID4EIB"></a>

 
## <a name="required-request-headers"></a>必要な要求ヘッダー
 
要求を行う場合は、次の表に示されているヘッダーが必要です。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | 
| Content-Type| application/json| 送信されるデータの型。| 
| Host| gameserverds.xboxlive.com|  | 
| Content-Length|  | 要求オブジェクトの長さ。| 
| x-xbl-contract-version| 1| API コントラクトのバージョン。| 
| Authorization| XBL3.0 x = [ハッシュ] です。[トークン]| 認証トークンです。| 
  
<a id="ID4EED"></a>

 
## <a name="optional-request-headers"></a>省略可能な要求ヘッダー
 
要求を行う場合は、次の表に示されているヘッダーを省略できます。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| X-XblCorrelationId|  | 要求の本文の mime の種類。| 
  
<a id="ID4E3D"></a>

 
## <a name="authorization"></a>Authorization

要求には、有効な Xbox Live の authorization ヘッダーを含める必要があります。 呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは応答 403 Forbidden を返します。 ヘッダーが無効であるか不足している場合、サービスは応答で 401 Unauthorized を返します。
 
<a id="ID4EEE"></a>

 
## <a name="request-body"></a>要求本文
 
要求には、次のメンバーを持つ JSON オブジェクトを含める必要があります。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| locale| 返されるバリアントのローカルです。| 
| maxVariants| 返されるバリアントの最大数。| 
| publisherOnly|  | 
| 制限|  | 
 
<a id="ID4EDF"></a>

 
### <a name="sample-request"></a>要求のサンプル
 

```cpp
{
  "locale": "en-us",
  "maxVariants": "100",
  "publisherOnly": "false",
  "restriction": null
}

```

   
<a id="ID4ELF"></a>

 
## <a name="required-response-headers"></a>必要な応答ヘッダー
 
応答には、常に、次の表に示すようにヘッダーが含まれます。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| Content-Type| application/json| 応答本文でデータの型。| 
| Content-Length|  | 応答本文の長さ。| 
  
<a id="ID4EMG"></a>

 
## <a name="optional-response-headers"></a>省略可能な応答ヘッダー
 
応答には、各自では、次に示すようにヘッダーが可能性があります。
 
| Header| Value| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| X-XblCorrelationId|  | 応答本文の mime の種類。| 
  
<a id="ID4EEH"></a>

 
## <a name="response-body"></a>応答本文
 
呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。
 
| メンバー| 説明| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| バリアント| Variant の配列。| 
| バリエーション| バリアント型の Id。| 
| name| バリアントの名前。| 
| isPublisher|  | 
| ランク|  | 
| gameVariantSchemaId|  | 
| variantSchemas| バリアント型のスキーマの配列。| 
| variantSchemaId| スキーマの Id。| 
| schemaContent| スキーマの内容| 
| name| スキーマの名前| 
| gsiSets| GSI の配列を設定します。| 
| minRequiredPlayers| バリアントのプレイヤーの最小数。| 
| maxAllowedPlayers| バリアントのプレイヤーの最大数。| 
| gsiSetId| GSI セットの Id。| 
| gsiSetName| GSI セットの名前。| 
| selectionOrder|  | 
| variantSchemaId| GSI で使用される varaint スキーマの id を設定します。| 
 
<a id="ID4EYBAC"></a>

 
### <a name="sample-response"></a>応答のサンプル
 

```cpp
{
 "variants": [
     { 
       "variantId": "8B6EF8A0-7807-42C4-9CB0-1D9B8B8CE742", 
       "name": "tankWarsV2.0",
       "isPublisher": "true",
       "rank": "1",
       "gameVariantSchemaId": "9742DBA5-23FD-4760-9D74-6CFA211B9CFB"
     }],
  "variantSchemas": [
     {
        "variantSchemaId": "9742DBA5-23FD-4760-9D74-6CFA211B9CFB",
        "schemaContent": "&lt;?xml version=\"1.0\" encoding=\"UTF-8\" ?>&lt;xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">&lt;xs:element name=\"root\">&lt;/xs:element>&lt;/xs:schema>"
        "name": "tanksSchema"
     }],
     "gsiSets":
     [{ 
          "minRequiredPlayers": "5", 
          "maxAllowedPlayers": "10", 
          "gsiSetId": "B28047F5-B52F-477E-97C2-4C1C39E31D42",
          "gsiSetName": "TanksGSISet",
          "selectionOrder": "1",
          "variantSchemaId": "9742DBA5-23FD-4760-9D74-6CFA211B9CFB"
     }]
 }

  

```

   
<a id="ID4ERCAC"></a>

 
## <a name="see-also"></a>関連項目
 [/titles/{titleId}/variants](uri-titlestitleidvariants.md)

  