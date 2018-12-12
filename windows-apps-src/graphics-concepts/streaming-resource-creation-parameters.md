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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8936049"
---
# <a name="streaming-resource-creation-parameters"></a><span data-ttu-id="f79dc-104">ストリーミング リソースの作成パラメーター</span><span class="sxs-lookup"><span data-stu-id="f79dc-104">Streaming resource creation parameters</span></span>


<span data-ttu-id="f79dc-105">ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。</span><span class="sxs-lookup"><span data-stu-id="f79dc-105">There are some constraints on the type of Direct3D resources that you can create as a streaming resource.</span></span>

<span data-ttu-id="f79dc-106"><span id="Supported-Resource-Type"></span><span id="supported-resource-type"></span><span id="SUPPORTED-RESOURCE-TYPE"></span>**サポートされるリソースの種類**</span><span class="sxs-lookup"><span data-stu-id="f79dc-106"><span id="Supported-Resource-Type"></span><span id="supported-resource-type"></span><span id="SUPPORTED-RESOURCE-TYPE"></span>**Supported Resource Type**</span></span>  
<span data-ttu-id="f79dc-107">Texture2D\[配列\] (Texture2D\[配列\] のバリアントである TextureCube\[配列\] を含む) またはバッファー。</span><span class="sxs-lookup"><span data-stu-id="f79dc-107">Texture2D\[Array\] (including TextureCube\[Array\], which is a variant of Texture2D\[Array\]) or Buffer.</span></span>

<span data-ttu-id="f79dc-108">**サポートされていません:** Texture1d \ [配列 \]。</span><span class="sxs-lookup"><span data-stu-id="f79dc-108">**NOT supported:** Texture1D\[Array\] .</span></span>

<span data-ttu-id="f79dc-109"><span id="Supported-Resource-Usage"></span><span id="supported-resource-usage"></span><span id="SUPPORTED-RESOURCE-USAGE"></span>**サポートされるリソースの使用法**</span><span class="sxs-lookup"><span data-stu-id="f79dc-109"><span id="Supported-Resource-Usage"></span><span id="supported-resource-usage"></span><span id="SUPPORTED-RESOURCE-USAGE"></span>**Supported Resource Usage**</span></span>  
<span data-ttu-id="f79dc-110">既定の使用法。</span><span class="sxs-lookup"><span data-stu-id="f79dc-110">Default usage.</span></span>

<span data-ttu-id="f79dc-111">**サポートされていません:** 動的、ステージング、または不変。</span><span class="sxs-lookup"><span data-stu-id="f79dc-111">**NOT supported:** Dynamic, staging, or immutable.</span></span>

<span data-ttu-id="f79dc-112"><span id="Supported-Resource-Misc-Flags"></span><span id="supported-resource-misc-flags"></span><span id="SUPPORTED-RESOURCE-MISC-FLAGS"></span>**サポートされるリソースのその他のフラグ**</span><span class="sxs-lookup"><span data-stu-id="f79dc-112"><span id="Supported-Resource-Misc-Flags"></span><span id="supported-resource-misc-flags"></span><span id="SUPPORTED-RESOURCE-MISC-FLAGS"></span>**Supported Resource Misc Flags**</span></span>  
<span data-ttu-id="f79dc-113">タイル。つまり、(当然ながら) ストリーミング、テクスチャ キューブ、描画の間接的な引数、バッファー許可未加工ビュー、構造バッファー、リソース クランプ、または MIPS の生成が該当します。</span><span class="sxs-lookup"><span data-stu-id="f79dc-113">Tiled; that is, streaming (by definition), texture cube, draw indirect arguments, buffer allow raw views, structured buffer, resource clamp, or generate mips.</span></span>

<span data-ttu-id="f79dc-114">**サポートされていません:** 共有、共有キー付きミュー テックス、GDI 互換、共有 NT ハンドル、制限されたコンテンツ、制限共有リソース、制限共有リソース ドライバー、保護、またはタイル プール。</span><span class="sxs-lookup"><span data-stu-id="f79dc-114">**NOT supported:** shared, shared keyed mutex, GDI compatible, shared NT handle, restricted content, restrict shared resource, restrict shared resource driver, guarded, or tile pool.</span></span>

<span data-ttu-id="f79dc-115"><span id="Supported-Bind-Flags"></span><span id="supported-bind-flags"></span><span id="SUPPORTED-BIND-FLAGS"></span>**サポートされるバインド フラグ**</span><span class="sxs-lookup"><span data-stu-id="f79dc-115"><span id="Supported-Bind-Flags"></span><span id="supported-bind-flags"></span><span id="SUPPORTED-BIND-FLAGS"></span>**Supported Bind Flags**</span></span>  
<span data-ttu-id="f79dc-116">シェーダー リソース、レンダー ターゲット、深度ステンシル、または順序指定なしアクセスとしてバインド。</span><span class="sxs-lookup"><span data-stu-id="f79dc-116">Bind as shader resource, render target, depth stencil, or unordered access.</span></span>

<span data-ttu-id="f79dc-117">**サポートされていません:** バインド定数バッファー、頂点バッファー (、SRV/UAV/RTV がサポートされているタイル化されたバッファーのバインド)、インデックス バッファー、ストリーム出力、デコーダー、またはビデオ エンコーダーが開始します。</span><span class="sxs-lookup"><span data-stu-id="f79dc-117">**NOT supported:** Bind as constant buffer, vertex buffer (binding a tiled Buffer as an SRV/UAV/RTV is supported), index buffer, stream output, decoder, or video encoder.</span></span>

<span data-ttu-id="f79dc-118"><span id="Supported-Formats"></span><span id="supported-formats"></span><span id="SUPPORTED-FORMATS"></span>**サポートされる形式**</span><span class="sxs-lookup"><span data-stu-id="f79dc-118"><span id="Supported-Formats"></span><span id="supported-formats"></span><span id="SUPPORTED-FORMATS"></span>**Supported Formats**</span></span>  
<span data-ttu-id="f79dc-119">タイル化されるかどうかに関わらず、特定の構成に利用できるすべての形式に、何らかの例外があります。</span><span class="sxs-lookup"><span data-stu-id="f79dc-119">All formats that would be available for the given configuration regardless of it being tiled, with some exceptions.</span></span>

<span data-ttu-id="f79dc-120"><span id="Supported-Sample-Description--Multisample-count--quality-"></span><span id="supported-sample-description--multisample-count--quality-"></span><span id="SUPPORTED-SAMPLE-DESCRIPTION--MULTISAMPLE-COUNT--QUALITY-"></span>**サポートされるサンプルの説明 (マルチサンプルの数、質)**</span><span class="sxs-lookup"><span data-stu-id="f79dc-120"><span id="Supported-Sample-Description--Multisample-count--quality-"></span><span id="supported-sample-description--multisample-count--quality-"></span><span id="SUPPORTED-SAMPLE-DESCRIPTION--MULTISAMPLE-COUNT--QUALITY-"></span>**Supported Sample Description (Multisample count, quality)**</span></span>  
<span data-ttu-id="f79dc-121">タイル化されるかどうかに関わらず、特定の構成でサポートされるすべてのものに、何らかの例外があります。</span><span class="sxs-lookup"><span data-stu-id="f79dc-121">Whatever would be supported for the given configuration regardless of it being tiled, with some exceptions.</span></span>

<span data-ttu-id="f79dc-122"><span id="Supported-Width-Height-MipLevels-ArraySize"></span><span id="supported-width-height-miplevels-arraysize"></span><span id="SUPPORTED-WIDTH-HEIGHT-MIPLEVELS-ARRAYSIZE"></span>**サポートされる Width/Height/MipLevels/ArraySize**</span><span class="sxs-lookup"><span data-stu-id="f79dc-122"><span id="Supported-Width-Height-MipLevels-ArraySize"></span><span id="supported-width-height-miplevels-arraysize"></span><span id="SUPPORTED-WIDTH-HEIGHT-MIPLEVELS-ARRAYSIZE"></span>**Supported Width/Height/MipLevels/ArraySize**</span></span>  
<span data-ttu-id="f79dc-123">全範囲が Direct3D によってサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f79dc-123">Full extents supported by Direct3D.</span></span> <span data-ttu-id="f79dc-124">ストリーミング リソースには、非ストリーミング リソースに課されるメモリの合計サイズの制限はありません。</span><span class="sxs-lookup"><span data-stu-id="f79dc-124">Streaming resources don't have the restriction on total memory size imposed on non-streaming resources.</span></span> <span data-ttu-id="f79dc-125">ストリーミング リソースは、全体的な仮想アドレス空間の制限によってのみ制約されます。</span><span class="sxs-lookup"><span data-stu-id="f79dc-125">Streaming resources are only constrained by overall virtual address space limits.</span></span> <span data-ttu-id="f79dc-126">「[ストリーミング リソースに利用可能なアドレス空間](address-space-available-for-streaming-resources.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f79dc-126">See [Address space available for streaming resources](address-space-available-for-streaming-resources.md).</span></span>

<span data-ttu-id="f79dc-127">タイル プール メモリの初期コンテンツは定義されていません。</span><span class="sxs-lookup"><span data-stu-id="f79dc-127">The initial contents of tile pool memory are undefined.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="f79dc-128"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="f79dc-128"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f79dc-129">トピック</span><span class="sxs-lookup"><span data-stu-id="f79dc-129">Topic</span></span></th>
<th align="left"><span data-ttu-id="f79dc-130">説明</span><span class="sxs-lookup"><span data-stu-id="f79dc-130">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="address-space-available-for-streaming-resources.md"><span data-ttu-id="f79dc-131">ストリーミング リソースに利用可能なアドレス空間</span><span class="sxs-lookup"><span data-stu-id="f79dc-131">Address space available for streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f79dc-132">このセクションでは、リソースのストリーミングに利用できる仮想アドレス空間を指定します。</span><span class="sxs-lookup"><span data-stu-id="f79dc-132">This section specifies the virtual address space that is available for streaming resources.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="f79dc-133"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="f79dc-133"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="f79dc-134">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="f79dc-134">Creating streaming resources</span></span>](creating-streaming-resources.md)

 

 




