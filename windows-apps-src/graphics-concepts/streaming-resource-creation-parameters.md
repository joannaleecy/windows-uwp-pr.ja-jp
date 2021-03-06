---
title: ストリーミング リソースの作成パラメーター
description: ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。
ms.assetid: 6FC5AD93-6F47-479E-947C-895C99B427BC
keywords:
- ストリーミング リソースの作成パラメーター
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1ddb150e570e25af7162a50309b9b0fc30cedf60
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617337"
---
# <a name="streaming-resource-creation-parameters"></a>ストリーミング リソースの作成パラメーター


ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。

<span id="Supported-Resource-Type"></span><span id="supported-resource-type"></span><span id="SUPPORTED-RESOURCE-TYPE"></span>**サポートされているリソースの種類**  
Texture2D\[配列\](TextureCube を含む\[配列\]、Texture2D の一種である\[配列\]) またはバッファー。

**サポートされていません:  **Texture1D\[配列\]します。

<span id="Supported-Resource-Usage"></span><span id="supported-resource-usage"></span><span id="SUPPORTED-RESOURCE-USAGE"></span>**サポートされているリソースの使用状況**  
既定の使用法。

**サポートされていません:  **動的、ステージング、または変更できません。

<span id="Supported-Resource-Misc-Flags"></span><span id="supported-resource-misc-flags"></span><span id="SUPPORTED-RESOURCE-MISC-FLAGS"></span>**サポートされているリソースの他のフラグ**  
タイル。つまり、(当然ながら) ストリーミング、テクスチャ キューブ、描画の間接的な引数、バッファー許可未加工ビュー、構造バッファー、リソース クランプ、または MIPS の生成が該当します。

**サポートされていません:  **共有の共有キー付きミュー テックス、互換性のある、GDI NT ハンドルを共有、制限されたコンテンツの共有リソースを制限する、ドライバーの共有リソースを制限する、保護された、またはプールを並べて表示します。

<span id="Supported-Bind-Flags"></span><span id="supported-bind-flags"></span><span id="SUPPORTED-BIND-FLAGS"></span>**サポートされているバインド フラグ**  
シェーダー リソース、レンダー ターゲット、深度ステンシル、または順序指定なしアクセスとしてバインド。

**サポートされていません:  **バインド定数バッファー、頂点バッファーを (、SRV/UAV/RTV がサポートされているタイル化されたバッファーをバインド)、インデックス バッファー、ストリームの出力、デコーダー、またはビデオ エンコーダー。

<span id="Supported-Formats"></span><span id="supported-formats"></span><span id="SUPPORTED-FORMATS"></span>**サポートされている形式**  
タイル化されるかどうかに関わらず、特定の構成に利用できるすべての形式に、何らかの例外があります。

<span id="Supported-Sample-Description--Multisample-count--quality-"></span><span id="supported-sample-description--multisample-count--quality-"></span><span id="SUPPORTED-SAMPLE-DESCRIPTION--MULTISAMPLE-COUNT--QUALITY-"></span>**サポートされているサンプルの説明 (マルチ サンプル数、品質)**  
タイル化されるかどうかに関わらず、特定の構成でサポートされるすべてのものに、何らかの例外があります。

<span id="Supported-Width-Height-MipLevels-ArraySize"></span><span id="supported-width-height-miplevels-arraysize"></span><span id="SUPPORTED-WIDTH-HEIGHT-MIPLEVELS-ARRAYSIZE"></span>**サポートされている幅/高さ/MipLevels/ArraySize**  
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
<td align="left"><p><a href="address-space-available-for-streaming-resources.md">アドレス空間のリソースをストリーミングできます。</a></p></td>
<td align="left"><p>このセクションでは、リソースのストリーミングに利用できる仮想アドレス空間を指定します。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミングのリソースを作成します。](creating-streaming-resources.md)

 

 




