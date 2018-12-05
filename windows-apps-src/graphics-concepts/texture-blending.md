---
title: テクスチャ ブレンド
description: Direct3D では、1 つのパスでプリミティブに 8 個までのテクスチャをブレンドできます。
ms.assetid: 9AD388FA-B2B9-44A9-B73E-EDBD7357ACFB
keywords:
- テクスチャ ブレンド
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c40c7d3bd080bd927fc52cb7f740e1dc4a6358c0
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8734700"
---
# <a name="texture-blending"></a>テクスチャ ブレンド


Direct3D では、1 つのパスでプリミティブに 8 個までのテクスチャをブレンドできます。 複数のテクスチャ ブレンドを使うと、Direct3D アプリケーションのフレーム レートが大幅に増えることがあります。 アプリケーションは複数のテクスチャを使って、テクスチャ、シャドウ、鏡面反射、拡散光、およびその他の特殊効果を 1 つのパスで適用します。

テクスチャ ブレンドを使用するには、最初にアプリケーションでユーザーのハードウェアがテクスチャ ブレンドをサポートしているかどうかを確認する必要があります。

## <a name="span-idtexture-stages-and-the-texture-blending-cascadespanspan-idtexture-stages-and-the-texture-blending-cascadespanspan-idtexture-stages-and-the-texture-blending-cascadespantexture-stages-and-the-texture-blending-cascade"></a><span id="Texture-Stages-and-the-Texture-Blending-Cascade"></span><span id="texture-stages-and-the-texture-blending-cascade"></span><span id="TEXTURE-STAGES-AND-THE-TEXTURE-BLENDING-CASCADE"></span>テクスチャ ステージとテクスチャ ブレンディング カスケード


Direct3D では、テクスチャ ステージの使用によって、単一パスでの複数のテクスチャ ブレンドがサポートされます。 テクスチャ ステージは 2 つの引数を受け取り、それらに対してブレンド処理を実行して、その後の処理またはラスター化に結果を渡します。 テクスチャ ステージを具体的に表すと、次の図のようになります。

![テクスチャ ステージの図](images/texstg.png)

上の図のように、テクスチャ ステージは、指定された演算子を使用して、2 つの引数をブレンドします。 一般的な演算には、引数のカラーまたはアルファ成分の単純な乗算や加算がありますが、実際にサポートされている演算は 24 を超えます。 ステージの引数には、関連付けられたテクスチャ、反復処理されるカラーまたはアルファ (グーロー シェーディング時に反復処理)、任意のカラーとアルファ、以前のテクスチャ ステージの結果などがあります。

**注:**  Direct3D は、色のアルファ ブレンドのブレンドを区別します。 アプリケーションでは、カラーとアルファについて個々にブレンドの演算と引数を設定し、これらの設定の結果は互いに独立しています。

 

複数のブレンド ステージで、引数と演算を組み合わせて使用することによって、単純なフローベースのブレンド言語を定義できます。 1 つのステージの結果は別のステージに移行し、さらにそのステージから次のステージに移行します。 その後も同様に続きます。結果が、ステージからステージに渡され、最終的にポリゴンでラスター化される概念を、一般にテクスチャ ブレンディング カスケードと呼びます。 次の図は、個々のテクスチャ ステージがテクスチャ ブレンディング カスケードを構成しているようすを示しています。

![テクスチャ ブレンディング カスケードのテクスチャ ステージの図](images/tcascade.png)

デバイス内の各ステージには、ゼロから始まるインデックスがあります。 Direct3D では、最大 8 つのブレンド ステージを使用することができますが、必ずデバイスの能力をチェックして、現在のハードウェアでサポートされるステージの数を確認する必要があります。 最初のブレンド ステージはインデックス 0 にあり、2 番目のブレンド ステージはインデックス 1 にあり、その後、インデックス 7 まで同様に続きます。 システムは、インデックスの昇順でステージをブレンドします。

ステージは必要な数だけ使用してください。未使用のブレンド ステージは既定で無効になります。 つまり、アプリケーションで最初の 2 つのステージのみを使用する場合、演算と引数の設定が必要なのは、ステージ 0 と 1 のみです。 システムでは 2 つのステージがブレンドされ、無効なステージは無視されます。

4 つのステージを使用するオブジェクトや、2 つのステージのみを使用するオブジェクトなど、状況に応じてアプリケーションで使用するステージの数が変わる場合は、以前に使用したすべてのステージを明示的に無効にする必要はありません。 1 つのオプションとして、最初の未使用のステージについてカラー処理を無効にすると、それよりもインデックスが大きいステージはすべて適用されなくなります。 別のオプションとして、最初のテクスチャ ステージ (ステージ 0) のカラー処理を無効な状態に設定すると、テクスチャ マッピングをまとめて無効にすることができます。

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
<td align="left"><p><a href="blending-stages.md">ブレンド ステージ</a></p></td>
<td align="left"><p>ブレンド ステージは、テクスチャ操作のセットと、テクスチャのブレンド方法を定義する引数です。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="multipass-texture-blending.md">マルチパス テクスチャ ブレンド</a></p></td>
<td align="left"><p>Direct3D アプリケーションでは、複数のレンダリング パスでさまざまなテクスチャを 1 つのプリミティブに適用することで、多彩な特殊効果を実現することができます。 これを表す一般的な用語が<em>マルチパス テクスチャ ブレンド</em>です。 通常、マルチパス テクスチャ ブレンドは、さまざまなテクスチャから複数のカラーを適用して、複雑なライティング モデルやシェーディング モデルの効果をエミュレートするために使用されます。 このようなアプリケーションを<em>ライト マッピング</em>と呼びます。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャ](textures.md)

 

 




