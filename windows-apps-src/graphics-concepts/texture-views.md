---
title: テクスチャ ビュー
description: Direct3D では、ビューを使ってテクスチャ リソースにアクセスします。ビューは、メモリ内のリソースをハードウェアで解釈するためのメカニズムです。
ms.assetid: 18DABFCE-8A36-4C4E-B08E-10428B05D701
keywords:
- テクスチャ ビュー
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9506b86fc16861984e539c52bdd92eed544079a8
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7559565"
---
# <a name="texture-views"></a>テクスチャ ビュー


Direct3D では、ビューを使ってテクスチャ リソースにアクセスします。ビューは、メモリ内のリソースをハードウェアで解釈するためのメカニズムです。 ビューを使うと、アプリケーションで要求される表現で、特定のパイプライン ステージから必要な[サブリソース](resource-types.md)だけにアクセスできるようになります。

ビューは、型指定なしのリソースの概念をサポートします。 型指定なしのリソースは、特定のサイズで作成され、特定のデータ型ではないリソースです。 データは、パイプラインにバインドされるときに動的に解釈されます。

次の図は、2D テクスチャ配列のシェーダー リソース ビューを作成することで、その配列をシェーダー リソースとして 6 つのテクスチャとバインドする例を示しています。 その後、リソースはテクスチャの配列として扱われます。 (注: サブリソースを入力および出力の両方で、パイプラインに同時にバインドすることはできません)。

![6 つのテクスチャを含むテクスチャ配列の図](images/d3d10-cube-texture-faces.png)

レンダー ターゲットとしてを 2D テクスチャ配列を使うと、リソースは複数のミップマップ レベル (この例では 3 レベル) の 2D テクスチャ (この例では 6 個) の配列として表示することができます。

CreateRenderTargetView を呼び出して、レンダー ターゲットのビュー オブジェクトを作成します。 そして、OMSetRenderTargets を呼び出して、レンダー ターゲット ビューをパイプラインに設定します。 Draw を呼び出し、RenderTargetArrayIndex を使用して配列内の適切なテクスチャへのインデックスを設定することで、レンダー ターゲットにレンダリングします。 サブリソース (ミップマップ レベル、配列インデックスの組み合わせ) を使用して、サブリソースの任意の配列にバインドできます。 次の図に示すように、2 番目のミップマップ レベルにバインドし、その特定のミップマップ レベルだけを更新することもできます。

![テクスチャ配列の 2 番目のミップマップ レベルにのみバインドしている図](images/d3d10-cube-texture-faces-subresource.png)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[リソース](resources.md)

 

 




