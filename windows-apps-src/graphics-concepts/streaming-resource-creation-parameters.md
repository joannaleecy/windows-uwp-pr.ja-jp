---
title: ストリーミング リソースの作成パラメーター
description: ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。
ms.assetid: 6FC5AD93-6F47-479E-947C-895C99B427BC
keywords:
- ストリーミング リソースの作成パラメーター
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0129b44b6f1c6c8b18555e3e0e0b350a695cabe1
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5814125"
---
# <a name="streaming-resource-creation-parameters"></a>ストリーミング リソースの作成パラメーター


ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。

<span id="Supported-Resource-Type"></span><span id="supported-resource-type"></span><span id="SUPPORTED-RESOURCE-TYPE"></span>**サポートされるリソースの種類**  
Texture2D\[配列\] (Texture2D\[配列\] のバリアントである TextureCube\[配列\] を含む) またはバッファー。

**サポートされていません:** Texture1d \ [配列 \]。

<span id="Supported-Resource-Usage"></span><span id="supported-resource-usage"></span><span id="SUPPORTED-RESOURCE-USAGE"></span>**サポートされるリソースの使用法**  
既定の使用法。

**サポートされていません:** 動的、ステージング、または不変。

<span id="Supported-Resource-Misc-Flags"></span><span id="supported-resource-misc-flags"></span><span id="SUPPORTED-RESOURCE-MISC-FLAGS"></span>**サポートされるリソースのその他のフラグ**  
タイル。つまり、(当然ながら) ストリーミング、テクスチャ キューブ、描画の間接的な引数、バッファー許可未加工ビュー、構造バッファー、リソース クランプ、または MIPS の生成が該当します。

**サポートされていません:** 共有、共有キー付きミュー テックス、GDI 互換、共有 NT ハンドル、制限されたコンテンツ、制限共有リソース、制限共有リソース ドライバー、保護、またはタイル プール。

<span id="Supported-Bind-Flags"></span><span id="supported-bind-flags"></span><span id="SUPPORTED-BIND-FLAGS"></span>**サポートされるバインド フラグ**  
シェーダー リソース、レンダー ターゲット、深度ステンシル、または順序指定なしアクセスとしてバインド。

**サポートされていません:** 定数バッファー、頂点バッファー (タイル化されたバッファーとしてのバインド、SRV/UAV/RTV がサポートされている)、インデックスとしてバインド バッファー、ストリーム出力、デコーダー、またはビデオ エンコーダーが開始します。

<span id="Supported-Formats"></span><span id="supported-formats"></span><span id="SUPPORTED-FORMATS"></span>**サポートされる形式**  
タイル化されるかどうかに関わらず、特定の構成に利用できるすべての形式に、何らかの例外があります。

<span id="Supported-Sample-Description--Multisample-count--quality-"></span><span id="supported-sample-description--multisample-count--quality-"></span><span id="SUPPORTED-SAMPLE-DESCRIPTION--MULTISAMPLE-COUNT--QUALITY-"></span>**サポートされるサンプルの説明 (マルチサンプルの数、質)**  
タイル化されるかどうかに関わらず、特定の構成でサポートされるすべてのものに、何らかの例外があります。

<span id="Supported-Width-Height-MipLevels-ArraySize"></span><span id="supported-width-height-miplevels-arraysize"></span><span id="SUPPORTED-WIDTH-HEIGHT-MIPLEVELS-ARRAYSIZE"></span>**サポートされる Width/Height/MipLevels/ArraySize**  
全範囲が Direct3D によってサポートされます。 ストリーミング リソースには、非ストリーミング リソースに課されるメモリの合計サイズの制限はありません。 ストリーミング リソースは、全体的な仮想アドレス空間の制限によってのみ制約されます。 「[ストリーミング リソースに利用可能なアドレス空間](address-space-available-for-streaming-resources.md)」を参照してください。

タイル プール メモリの初期コンテンツは定義されていません。

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
<td align="left"><p><a href="address-space-available-for-streaming-resources.md">ストリーミング リソースに利用可能なアドレス空間</a></p></td>
<td align="left"><p>このセクションでは、リソースのストリーミングに利用できる仮想アドレス空間を指定します。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースの作成](creating-streaming-resources.md)

 

 




