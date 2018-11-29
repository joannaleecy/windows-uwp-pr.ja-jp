---
title: ストリーミング リソースで利用可能な操作
description: このセクションでは、ストリーミング リソースで実行できる操作を示します。
ms.assetid: 700D8C54-0E20-4B2B-BEA3-20F6F72B8E24
keywords:
- ストリーミング リソースで利用可能な操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 922798fad97754421541297a5434a81e9c660b2b
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8195041"
---
# <a name="operations-available-on-streaming-resources"></a>ストリーミング リソースで利用可能な操作


このセクションでは、ストリーミング リソースで実行できる操作を示します。

-   void を返すタイル マッピングの更新操作、および void を返すタイル マッピングのコピー操作 - これらの操作は、ストリーミング リソース内のタイル位置をタイル プール内の位置、NULL、またはその両方にポイントします。 これらの操作では、タイル ポインターの分離したサブセットを更新できます。
-   コピーおよび更新操作 - 既定のプール サーフェスとの間でデータをコピーできるすべての API は、ストリーミング リソースで機能します。 マップされていないタイルからの読み取りは 0 を生成し、マップされていないタイルへの書き込みは破棄されます。
-   タイルのコピーおよびタイルの更新操作 - これらの操作は、正規メモリ レイアウト内のストリーミング リソースおよびバッファー リソースとの間で、64 KB の精度でタイルをコピーするために存在します。 ディスプレイ ドライバーとハードウェアは、ストリーミング リソースに必要なメモリ "スウィズル" を実行します。
-   非ストリーミング リソースで機能する Direct3D パイプライン バインドとビューの作成/バインドは、ストリーミング リソースでも機能します。

タイル コントロールは、イミディエイト コンテキストまたは遅延コンテキストで使うことができ (一般的なリソースの更新と同様)、実行するとタイルへのその後のアクセス (以前に送信された操作ではなく) に影響が及びます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースの作成](creating-streaming-resources.md)

 

 




