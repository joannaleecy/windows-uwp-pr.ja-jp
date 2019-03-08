---
title: /handles/{handleId}/session
assetID: 4ed2dcf5-5d1f-91ce-4a3f-eb3ba68727bf
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsession.html
description: " /handles/{handleId}/session"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e7b6990917437c22dd4d9282492e2a0eab37893b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628147"
---
# <a name="handleshandleidsession"></a>/handles/{handleId}/session
PUT および GET の操作をサポート セッション ハンドルの逆参照を使用します。 

> [!NOTE] 
> この URI は、2015年マルチ プレーヤーによって使用され、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 テンプレートのコントラクト/104 105 またはそれ以降で使用するものでは。  

 

> [!NOTE] 
> この URI は、現在の Xbox One コンソールおよびサービスの識別子を使用してサーバーで外部からアクセスできるのみです。  

 
<a id="ID4ES"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 種類| 説明| 
| --- | --- | --- | --- | --- | 
| handleId| GUID| セッションのハンドルの一意の ID。| 
  
<a id="ID4ESB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/handles/{handleId}/session)](uri-handleshandleidsessionget.md)

&nbsp;&nbsp;指定したハンドル識別子のセッション オブジェクトを取得します。 

[配置 (/handles/{ハンドル id}/セッション)](uri-handleshandleidsessionput.md)

&nbsp;&nbsp;作成またはハンドルの逆参照でセッションを更新します。
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリの Uri](atoc-reference-sessiondirectory.md)

   