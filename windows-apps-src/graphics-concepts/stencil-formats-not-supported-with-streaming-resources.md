---
title: "ステンシルの書式はストリーミング リソースでサポートされない"
description: "ステンシルを含む書式は、ストリーミング リソースではサポートされません。"
ms.assetid: 90A572A4-3C76-4795-BAE9-FCC72B5F07AD
keywords: "ステンシルの書式はストリーミング リソースでサポートされない"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 15e64263a6b529fbc14be936195d33ad7ec69a1c
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="stencil-formats-not-supported-with-streaming-resources"></a>ステンシルの書式はストリーミング リソースでサポートされない


ステンシルを含む書式は、ストリーミング リソースではサポートされません。

ステンシルを含む書式には、DXGI\_FORMAT\_D24\_UNORM\_S8\_UINT (および R24G8 ファミリーの関連書式) と DXGI\_FORMAT\_D32\_FLOAT\_S8X24\_UINT (および R32G8X24 ファミリーの関連書式) が含まれます。

深度とステンシルを別々の割り当てに保存する実装もあれば、一緒に保存する実装もあります。 これら 2 つのスキーマ間でタイルの管理方法を変える必要がありますが、違いを抽象化または合理化できる単一の API はありません。 今後のハードウェアでは、深度とステンシルで個別のサーフェスをサポートし、それぞれにタイルを用意することをお勧めします。

32 ビットの深度には 128 x 128 のタイル、8 ビットのステンシルには 256 x 256 タイルがあります。 したがって、アプリケーションは深度とステンシル間のタイルの図形の不一致に対応する必要があります。 ただし、他のレンダー ターゲット サーフェスの書式にも、これと同じ問題が既に存在します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースのプロセスとデバイス間での共有](streaming-resource-cross-process-and-device-sharing.md)

 

 




