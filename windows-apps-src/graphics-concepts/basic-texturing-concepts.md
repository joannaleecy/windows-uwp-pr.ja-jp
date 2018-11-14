---
title: テクスチャリングの基本概念
description: コンピューターで作成された初期の 3D 画像は、当時は高度な技術でしたが、ツルツルのプラスチックのような外観になりがちでした。
ms.assetid: 3CA3905D-E837-48EB-A81F-319AA1C6537E
keywords:
- テクスチャリングの基本概念
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c48b7b007c1af1eaf6013d5f6e99468713d50745
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6264338"
---
# <a name="basic-texturing-concepts"></a>テクスチャリングの基本概念


コンピューターで作成された初期の 3D 画像は、当時は高度な技術でしたが、ツルツルのプラスチックのような外観になりがちでした。 それらには、3D オブジェクトにリアルで複雑な外観を与える傷や割れ、指紋、汚れなどがありませんでした。 テクスチャは、コンピューターで作成された 3D 画像のリアルさを向上させるための一般的な手法になってきました。

テクスチャという単語は一般的には、オブジェクトのなめらかさや粗さを表します。 ただし、コンピューター グラフィックスでは、オブジェクトにテクスチャの外観を与えるピクセル カラーのビットマップを指します。

Direct3D のテクスチャはビットマップであるため、どんなビットマップも Direct3D プリミティブに適用できます。 たとえば、アプリケーションは、木目のパターンを持つように表示するオブジェクトを作成して処理できます。 丘を形成する一連の 3D プリミティブには草、土、岩を適用できます。 これによって、丘の中腹をよりリアルに見せることができます。 また、テクスチャを使用して道路沿いの標識、がけの岩石層、大理石模様の床などのエフェクトを作成することもできます。

さらに、Direct3D は透明度ありなしのテクスチャ ブレンディングやライト マッピングなど、さらに高度なテクスチャ テクニックをサポートしています。 詳しくは、「[テクスチャ ブレンディング](texture-blending.md)」および「[テクスチャによるライト マッピング](light-mapping-with-textures.md)」をご覧ください。

アプリケーションがハードウェア アブストラクション レイヤー (HAL) デバイスやソフトウェア デバイスを作成する場合、8、16、24、32、64、または 128 ビットのテクスチャを使用できます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャ](textures.md)

 

 




