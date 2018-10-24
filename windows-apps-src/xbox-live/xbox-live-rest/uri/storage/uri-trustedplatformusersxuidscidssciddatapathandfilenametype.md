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
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483518"
---
# <a name="trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a>/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}
ダウンロード、アップロード、またはファイルを削除します。 これらの Uri のドメインは、 `titlestorage.xboxlive.com`。
 
  * [URI パラメーター](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID を (XUID) プレーヤーの要求を行っています。| 
| scid| guid| 検索するサービスの構成の ID です。| 
| pathAndFileName| string| アクセスするアイテムのパスとファイル名です。 パスの部分と最後のスラッシュを含む) に有効な文字は、大文字の英字 (A-Z)、英小文字 (a から z)、数字 (0-9)、アンダー スコア (_) が含まれます、スラッシュ (/)。パスの部分を空にすることがあります。ファイル名の部分 (最後のスラッシュ以降後のすべて) に含まれている大文字の英字 (A-Z)、英小文字 (a から z)、数字 (0-9)、アンダー スコア文字の有効な (_)、ピリオド (.)、およびハイフン (-) です。 ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。| 
| type| 文字列| データの形式です。 使用可能な値は、バイナリまたは json です。| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a>有効な方法

[DELETE](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-delete.md)

&nbsp;&nbsp;ファイルを削除します。 

[GET](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-get.md)

&nbsp;&nbsp;ファイルをダウンロードします。

[PUT](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.md)

&nbsp;&nbsp;ファイルをアップロードします。 データは、完全なデータとメタデータが送信される 1 つまたは一連の小さなブロックのデータとメタデータが送信される複数のブロックのアップロードとアップロードでアップロードできます。 4 メガバイト未満のファイルだけは、1 つのメッセージとして送信できます。 型の json のデータには、複数のブロックのアップロードはサポートされていません。 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a>Parent 

[タイトル ストレージ URI](atoc-reference-storagev2.md)

   