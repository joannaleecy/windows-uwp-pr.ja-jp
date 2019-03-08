---
title: GET (/serviceconfigs/{scid}/hoppers/{name}/stats)
assetID: 4de5b07d-93e1-8ff0-05dd-1d3bb1802088
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestatsget.html
description: " GET (/serviceconfigs/{scid}/hoppers/{name}/stats)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 95de95b35de496331dd3fe0a4c69f18e047c1020
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621697"
---
# <a name="get-serviceconfigsscidhoppersnamestats"></a>GET (/serviceconfigs/{scid}/hoppers/{name}/stats)

Hopper の統計情報を取得します。

> [!IMPORTANT]
> このメソッドは、コントラクト 103 以降で使用するためのものがし、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。

  * [注釈](#ID4ET)
  * [URI パラメーター](#ID4E5)
  * [承認](#ID4EJB)
  * [HTTP 状態コード](#ID4E3C)
  * [要求本文](#ID4EFD)
  * [応答本文](#ID4EQD)

<a id="ID4ET"></a>


## <a name="remarks"></a>注釈
この HTTP/REST メソッドは、サービス構成の ID (SCID) レベルで名前付き hopper から統計を取得します。 このメソッドをラップすることができます、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.GetHopperStatisticsAsync** API。  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| セッションのサービス構成識別子 (SCID)。|
| name| string| Hopper の名前。|

<a id="ID4EJB"></a>


## <a name="authorization"></a>Authorization

| 種類| 必須| 説明| 不足している場合の応答|
| --- | --- | --- | --- | --- | --- | --- | --- |
| XUID (ユーザー ID)| ○| 要求を行うユーザーは、チケットによって参照されるチケット セッションのメンバーである必要があります。 | 403|
| 特権とデバイスの種類| ○| ユーザーの deviceType は、コンソールに設定されている場合は、それぞれのクレームでマルチ プレーヤーの特権を持つユーザーのみがマッチメイ キング サービスを呼び出すことが許可されます。 | 403|
| タイトルの購入/デバイスの種類 ID/実証| ○| 一致するタイトルは、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。 | 403|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a>HTTP 状態コード
MPSD に適用される、サービスは、HTTP 状態コードを返します。  
<a id="ID4EFD"></a>


## <a name="request-body"></a>要求本文

この要求の本文には、オブジェクトは送信されません。

<a id="ID4EQD"></a>


## <a name="response-body"></a>応答本文

| メンバー| 種類| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| hopperName| string| 選択した hopper の名前。|
| 待機時間| 32 ビット符号付き整数| 平均時間 (秒単位の整数) hopper の一致します。 |
| カタログの作成| 32 ビット符号付き整数| 一致するもの、hopper で待機しているユーザーの数。|

<a id="ID4E1D"></a>


### <a name="sample-response"></a>応答のサンプル


```cpp
{
      "hopperName":"contosoawesome2",
      "waitTime":30,
      "population":1
    }


```


<a id="ID4EJE"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ELE"></a>


##### <a name="parent"></a>Parent  

[/serviceconfigs/{scid}/hoppers/{name}/stats](uri-serviceconfigsscidhoppershoppernamestats.md)
