---
title: ストリーミング リソースの作成
description: ストリーミング リソースは、リソースを作成するときにフラグを指定することによって作成され、リソースがストリーミング リソースであることを示します。
ms.assetid: B3F3E43C-54D4-458C-9E16-E13CB382C83F
keywords:
- ストリーミング リソースの作成
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ec96f6245969d32357563c44107f539fb9043aac
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618247"
---
# <a name="creating-streaming-resources"></a>ストリーミング リソースの作成


ストリーミング リソースは、リソースを作成するときにフラグを指定することによって作成され、リソースがストリーミング リソースであることを示します。

リソースをストリーミング リソースとして作成できる場合の制限については、「[ストリーミング リソース作成のパラメーター](streaming-resource-creation-parameters.md)」で説明されています。

2D テクスチャの配列の割り当てなど、非ストリーミング リソースのストレージは、リソースの作成時にグラフィック システムに割り当てられます。

ストリーミング リソースが作成される場合、グラフィック システムはリソース コンテンツにはストレージを割り当てません。 代わりに、アプリケーションがストリーミング リソースを作成する場合には、グラフィック システムはタイル サーフェスの領域のみのアドレス空間予約を行い、タイルのマッピングをアプリケーションが制御できるようにします。 タイルの「マッピング」とは、リソース内の論理タイルがポイントするメモリ内の物理的な位置 (またはマップされていないタイルの場合は**NULL**) です。

この概念を、Direct3D リソースを CPU アクセス用にマッピングするという概念と混同しないでください。これは同じ名前を使用していますが、全く別のものです。 必要に応じて、個々のタイルのマッピングを個別に定義して変更することができます。サーフェスのすべてのタイルを一度にマップする必要がないため、使用可能なメモリ量を有効に活用できます。

## <a name="span-idin-this-sectionspanin-this-section"></a><span id="in-this-section"></span>このセクションの内容


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="mappings-are-into-a-tile-pool.md">マッピングは、タイルのプールには</a></p></td>
<td align="left"><p>リソースがストリーミング リソースとして作成された場合、そのリソースを構成するタイルはタイル プール内の位置をポイントすることによって生成されます。 タイル プールは、メモリのプールです (背後にある 1 つ以上の割り当てによってサポートされていますが、アプリケーションには見えません)。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resource-creation-parameters.md">リソースの作成パラメーターのストリーミング</a></p></td>
<td align="left"><p>ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="tile-pool-creation-parameters.md">タイルのプールの作成パラメーター</a></p></td>
<td align="left"><p>このセクションのパラメーターを使用して、バッファーを作成するときにタイル プールを定義します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resource-cross-process-and-device-sharing.md">ストリーミング プロセス間のリソースとデバイスの共有</a></p></td>
<td align="left"><p>タイル プールは、従来のリソースと同様に、他のプロセスと共有することができます。 タイル プールを参照するストリーミング リソースは、デバイスやプロセス間で共有できません。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="operations-available-on-streaming-resources.md">リソースのストリーミングで使用できる操作</a></p></td>
<td align="left"><p>このセクションでは、ストリーミング リソースで実行できる操作を示します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="operations-available-on-tile-pools.md">タイルのプールで使用できる操作</a></p></td>
<td align="left"><p>タイル プールでの操作には、タイル プールのサイズ変更、リソースの提供 (タイル プール全体のためにメモリをシステムに一時的に生成)、リソースの解放などがあります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="how-a-streaming-resource-s-area-is-tiled.md">ストリーミングのリソースの領域は並べて表示する方法</a></p></td>
<td align="left"><p>ストリーミング リソースを作成するときは、次元、フォーマット要素のサイズ、およびミップマップや配列スライスの数 (該当する場合) によって、サーフェス領域全体をサポートするために必要なタイルの数が決まります。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[リソースのストリーミング](streaming-resources.md)

 

 




