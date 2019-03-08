---
title: /serviceconfigs/{scid}/batch
assetID: eb1b510f-d92e-ae9b-a3e6-0edf58b4f075
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidbatch.html
description: " /serviceconfigs/{scid}/batch"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 208ee92106563372dd4d92a8c800cc08f513e8c7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589717"
---
# <a name="serviceconfigsscidbatch"></a>/serviceconfigs/{scid}/batch
サービス構成の識別子のレベルでのバッチ クエリの POST 操作をサポートしています。

> [!IMPORTANT]
> このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。 104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。

<a id="ID4ER"></a>


## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- | --- |
| scid| GUID| サービス構成の識別子 (SCID) です。 パート 1 のセッション識別子。|

<a id="ID4ESB"></a>


## <a name="valid-methods"></a>有効なメソッド

[POST (/serviceconfigs/{scid}/batch)](uri-serviceconfigsscidbatchpost.md)

&nbsp;&nbsp;サービスの構成の複数の Xbox ユーザー Id には、バッチ クエリを作成します。

<a id="ID4E3B"></a>


## <a name="see-also"></a>関連項目

<a id="ID4E5B"></a>


##### <a name="parent"></a>Parent

[セッション ディレクトリの Uri](atoc-reference-sessiondirectory.md)
