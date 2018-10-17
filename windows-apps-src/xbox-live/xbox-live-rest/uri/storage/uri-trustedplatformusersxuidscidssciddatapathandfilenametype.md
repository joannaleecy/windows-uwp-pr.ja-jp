---
title: /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}
assetID: be789e70-517d-383e-ea35-b0c39e846081
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b0c776c3aae1978edb501d41fffccafcc76f799e
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4746474"
---
# <a name="trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a>/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}
ダウンロード、アップロード、またはファイルを削除します。 これらの Uri のドメインが`titlestorage.xboxlive.com`します。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。| 
| scid| guid| 検索するサービス構成の ID。| 
| pathAndFileName| string| アクセスできる項目のパスとファイルの名前です。 パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。 ファイル名を空にする可能性がありますはいない期間の終了または 2 つの連続したピリオドは。| 
| type| 文字列| データの形式です。 可能な値は、バイナリまたは json です。| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[DELETE](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-delete.md)

&nbsp;&nbsp;ファイルを削除します。 

[GET](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-get.md)

&nbsp;&nbsp;ファイルをダウンロードします。

[PUT](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.md)

&nbsp;&nbsp;ファイルをアップロードします。 メタデータとデータが送信される 1 つのメッセージで、または一連の小さいブロックのデータやメタデータが送信される複数のブロック アップロードとして完全なアップロードでは、データをアップロードできます。 単一のメッセージとしては 4 つのメガバイトよりも小さいファイルのみを送信できます。 Json の種類のデータの複数のブロックのアップロードがサポートされていません。 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   