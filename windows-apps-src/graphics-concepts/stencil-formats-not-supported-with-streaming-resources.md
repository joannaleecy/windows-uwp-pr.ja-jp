---
title: ストリーミング リソースでサポートされていないステンシルの書式
description: ステンシルを含む書式は、ストリーミング リソースではサポートされません。
ms.assetid: 90A572A4-3C76-4795-BAE9-FCC72B5F07AD
keywords:
- ストリーミング リソースでサポートされていないステンシルの書式
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1d35813a6242abd555e87329c25a413285d1d948
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660987"
---
# <a name="stencil-formats-not-supported-with-streaming-resources"></a>ストリーミング リソースでサポートされていないステンシルの書式


ステンシルを含む書式は、ストリーミング リソースではサポートされません。

ステンシルが含まれている形式は、DXGI\_形式\_D24\_UNORM\_S8\_UINT (および関連 R24G8 ファミリの形式) と DXGI\_形式\_D32\_FLOAT\_S8X24\_UINT (および関連 R32G8X24 ファミリの形式)。

深度とステンシルを別々の割り当てに保存する実装もあれば、一緒に保存する実装もあります。 これら 2 つのスキーマ間でタイルの管理方法を変える必要がありますが、違いを抽象化または合理化できる単一の API はありません。 今後のハードウェアでは、深度とステンシルで個別のサーフェスをサポートし、それぞれにタイルを用意することをお勧めします。

32 ビットの深度には 128 x 128 のタイル、8 ビットのステンシルには 256 x 256 タイルがあります。 したがって、アプリケーションは深度とステンシル間のタイルの図形の不一致に対応する必要があります。 ただし、他のレンダー ターゲット サーフェスの書式にも、これと同じ問題が既に存在します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング プロセス間のリソースとデバイスの共有](streaming-resource-cross-process-and-device-sharing.md)

 

 




