---
title: バッファーのタイリング
description: バッファー リソースは 64 KB のタイルに分割されます。サイズが 64 KB の倍数でない場合は、最後のタイルに空きが生じます。
ms.assetid: 577DC6B0-F373-4748-AD80-2784C597C366
keywords:
- バッファーのタイリング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 03769964bfe3eff13314e62b8594edd5509b26fb
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1044250"
---
# <a name="buffer-tiling"></a>バッファーのタイリング


[バッファー ](introduction-to-buffers.md) リソースは 64 KB のタイルに分割されます。サイズが 64 KB の倍数でない場合は、最後のタイルに空きが生じます。

構造化バッファーでは、タイリングのストライドに制約があってはなりません。 しかし、[**StructuredBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff471514) を使用するためのハードウェアで可能となるパフォーマンスの最適化が、最初にタイリングを行うことにより損なわれる場合があります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースの領域をタイル表示する方法](how-a-streaming-resource-s-area-is-tiled.md)

 

 




