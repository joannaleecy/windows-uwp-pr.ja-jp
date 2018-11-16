---
title: インデックス バッファー
description: インデックス バッファー は、インデックス データを格納するメモリ バッファーです。インデックス データは頂点バッファーへの整数オフセットで、プリミティブのレンダリングに使われます。
ms.assetid: 14D3DEC5-CF74-488B-BE41-16BF5E3201BE
keywords:
- インデックス バッファー
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0df56ebeefdbdabe5904547d77e90077549422c2
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7128832"
---
# <a name="index-buffers"></a>インデックス バッファー


*インデックス バッファー*は、インデックス データを含むメモリ バッファーであり、プリミティブのレンダリングに使用される、頂点バッファーへの整数オフセットです。

インデックス バッファーは、インデックス データを含むメモリ バッファーです。 インデックス データ (つまり、インデックス) は、頂点バッファーへの整数オフセットであり、プリミティブのレンダリングに使用されます。

頂点バッファーには、頂点が含まれているため、インデックス化されたプリミティブがあってもなくても頂点バッファーを描画できます。 ただし、インデックス バッファーにはインデックスが含まれているため、対応する頂点バッファーがなければインデックス バッファーを使うことができません。

## <a name="span-idindexbufferdescriptionspanspan-idindexbufferdescriptionspanspan-idindexbufferdescriptionspanindex-buffer-description"></a><span id="Index_Buffer_Description"></span><span id="index_buffer_description"></span><span id="INDEX_BUFFER_DESCRIPTION"></span>インデックス バッファーの記述


インデックス バッファーは、メモリ内のどこに存在するか、読み取りと書き込みをサポートするかどうか、含めることができるインデックスの種類と数など、機能の観点から記述されます。

インデックス バッファーの記述は、既存のバッファーがどのように作成されたかをアプリケーションに示します。 以前に作成されたインデックス バッファーを埋めるには、システムに空の記述構造を提供します。

## <a name="span-idindexprocessingrequirementsspanspan-idindexprocessingrequirementsspanspan-idindexprocessingrequirementsspanindex-processing-requirements"></a><span id="Index_Processing_Requirements"></span><span id="index_processing_requirements"></span><span id="INDEX_PROCESSING_REQUIREMENTS"></span>インデックス処理の要件


インデックス処理操作のパフォーマンスは、インデックス バッファーがメモリ内のどこに存在するかと、使われるレンダリング デバイスの種類に大きく依存します。 アプリケーションは、インデックス バッファーの作成時にそのメモリ割り当てを制御します。

アプリケーションは、ドライバー用に最適化されたメモリに割り当てられたインデックス バッファーにインデックスを直接書き込みます。 この手法を使うと、後で冗長コピー操作を実行できなくなります。 アプリケーションがインデックス バッファーからデータを読み戻す場合、この手法は適切に機能しません。ドライバー用に最適化されたメモリからホストにより実行される読み取り操作は非常に遅いためです。 したがって、アプリケーションがデータの処理時に読み取りを行う必要がある場合や、バッファーにデータを不規則に書き込む場合、システム メモリ インデックス バッファーの方が適しています。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[頂点バッファーとインデックス バッファー](vertex-and-index-buffers.md)

 

 




