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
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8896084"
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
<td align="left"><p><a href="mappings-are-into-a-tile-pool.md">タイル プールにマッピングされます</a></p></td>
<td align="left"><p>リソースがストリーミング リソースとして作成される場合、リソースを構成するタイルは、タイル プール内の場所をポイントすることに基づきます。 タイル プールは、メモリのプールです (背後にある 1 つ以上の割り当てによってサポートされていますが、アプリケーションには見えません)。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resource-creation-parameters.md">ストリーミング リソースの作成パラメーター</a></p></td>
<td align="left"><p>ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="tile-pool-creation-parameters.md">タイル プールの作成パラメーター</a></p></td>
<td align="left"><p>このセクションのパラメーターを使用して、バッファーを作成するときにタイル プールを定義します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resource-cross-process-and-device-sharing.md">ストリーミング リソースのプロセスとデバイス間での共有</a></p></td>
<td align="left"><p>タイル プールは、従来のリソースと同様に、他のプロセスと共有することができます。 タイル プールを参照するストリーミング リソースは、デバイスやプロセス間で共有できません。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="operations-available-on-streaming-resources.md">ストリーミング リソースで利用可能な操作</a></p></td>
<td align="left"><p>このセクションでは、ストリーミング リソースで実行できる操作を示します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="operations-available-on-tile-pools.md">タイル プールで利用可能な操作</a></p></td>
<td align="left"><p>タイル プールの操作には、タイル プールのサイズ変更、リソースの提供 (タイル プール全体のためシステムに一時的にメモリを与えます)、およびリソースの再利用が含まれます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="how-a-streaming-resource-s-area-is-tiled.md">ストリーミング リソースの領域をタイル表示する方法</a></p></td>
<td align="left"><p>ストリーミング リソースを作成するときは、次元、フォーマット要素のサイズ、およびミップマップや配列スライスの数 (該当する場合) によって、サーフェス領域全体をサポートするために必要なタイルの数が決まります。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソース](streaming-resources.md)

 

 




