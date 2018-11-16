---
author: mtoepke
title: Direct3D 11 への OpenGL ES 2.0 のマッピング
description: OpenGL ES 2.0 から Direct3D へのグラフィックス アーキテクチャの移植プロセスを初めて開始する場合は、API 間の主要な違いについて把握しておいてください。
ms.assetid: 7f9b136c-aa22-04b3-d385-6e9e1f38b948
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, OpenGL, Direct3D, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 532c2a0a9779ae3eaedb2217175dc0805514f792
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6991538"
---
# <a name="map-opengl-es-20-to-direct3d-11"></a><span data-ttu-id="737d3-104">Direct3D 11 への OpenGL ES 2.0 のマッピング</span><span class="sxs-lookup"><span data-stu-id="737d3-104">Map OpenGL ES 2.0 to Direct3D 11</span></span>



<span data-ttu-id="737d3-105">OpenGL ES 2.0 から Direct3D へのグラフィックス アーキテクチャの移植プロセスを初めて開始する場合は、API 間の主要な違いについて把握しておいてください。</span><span class="sxs-lookup"><span data-stu-id="737d3-105">When starting the process of porting your graphics architecture from OpenGL ES 2.0 to Direct3D for the first time, familiarize yourself with the key differences between the APIs.</span></span> <span data-ttu-id="737d3-106">このセクションのトピックは、グラフィックスの処理を Direct3D に移行する際に必ず必要な API の変更と移植戦略を計画するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="737d3-106">The topics in this section help you plan your port strategy and the API changes that you must make when moving your graphics processing to Direct3D.</span></span>
## 
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="737d3-107">トピック</span><span class="sxs-lookup"><span data-stu-id="737d3-107">Topic</span></span></th>
<th align="left"><span data-ttu-id="737d3-108">説明</span><span class="sxs-lookup"><span data-stu-id="737d3-108">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="compare-opengl-es-2-0-api-design-to-directx.md"><span data-ttu-id="737d3-109">OpenGL ES 2.0 から Direct3D への移植の計画</span><span class="sxs-lookup"><span data-stu-id="737d3-109">Plan your port from OpenGL ES 2.0 to Direct3D</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="737d3-110">iOS または Android プラットフォームからゲームを移植している場合、OpenGL ES 2.0 に多大な投資を行ってこられたものと思われます。</span><span class="sxs-lookup"><span data-stu-id="737d3-110">If you are porting a game from the iOS or Android platforms, you have probably made a significant investment in OpenGL ES 2.0.</span></span> <span data-ttu-id="737d3-111">グラフィックス パイプラインのコードベースを Direct3D 11 と Windows ランタイムに移す準備をしているときは、開始する前に何点か注意してください。</span><span class="sxs-lookup"><span data-stu-id="737d3-111">When preparing to move your graphics pipeline codebase to Direct3D 11 and the Windows Runtime, there are a few things you should consider before you start.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="moving-from-egl-to-dxgi.md"><span data-ttu-id="737d3-112">EGL コードと DXGI および Direct3D の比較</span><span class="sxs-lookup"><span data-stu-id="737d3-112">Compare EGL code to DXGI and Direct3D</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="737d3-113">DirectX Graphics Interface (DXGI) といくつかの Direct3D API は EGL と同じ役割を果たします。</span><span class="sxs-lookup"><span data-stu-id="737d3-113">The DirectX Graphics Interface (DXGI) and several Direct3D APIs serve the same role as EGL.</span></span> <span data-ttu-id="737d3-114">このトピックは EGL の観点から DXGI と Direct3D 11 を理解するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="737d3-114">This topic helps you understand DXGI and Direct3D 11 from the perspective of EGL.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="porting-uniforms-and-attributes.md"><span data-ttu-id="737d3-115">OpenGL ES 2.0 のバッファー、uniform、頂点属性と Direct3D の比較</span><span class="sxs-lookup"><span data-stu-id="737d3-115">Compare OpenGL ES 2.0 buffers, uniforms, and vertex attributes to Direct3D</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="737d3-116">OpenGL ES 2.0 から Direct3D 11 に移植するプロセスでは、アプリとシェーダー プログラムの間でデータを受け渡すための構文と API の動作を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="737d3-116">During the process of porting to Direct3D 11 from OpenGL ES 2.0, you must change the syntax and API behavior for passing data between the app and the shader programs.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="change-your-shader-loading-code.md"><span data-ttu-id="737d3-117">OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較</span><span class="sxs-lookup"><span data-stu-id="737d3-117">Compare the OpenGL ES 2.0 shader pipeline to Direct3D</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="737d3-118">概念的には、Direct3D 11 のシェーダー パイプラインは OpenGL ES 2.0 のそれとよく似ています。</span><span class="sxs-lookup"><span data-stu-id="737d3-118">Conceptually, the Direct3D 11 shader pipeline is very similar to the one in OpenGL ES 2.0.</span></span> <span data-ttu-id="737d3-119">ただし、API の設計という点では、シェーダー ステージを作成、管理するための主要コンポーネントは、<a href="https://msdn.microsoft.com/library/windows/desktop/hh404575"><strong>ID3D11Device1</strong></a> と <a href="https://msdn.microsoft.com/library/windows/desktop/hh404598"><strong>ID3D11DeviceContext1</strong></a> という 2 つのプライマリ インターフェイスに含まれています。</span><span class="sxs-lookup"><span data-stu-id="737d3-119">In terms of API design, however, the major components for creating and managing the shader stages are parts of two primary interfaces, <a href="https://msdn.microsoft.com/library/windows/desktop/hh404575"><strong>ID3D11Device1</strong></a> and <a href="https://msdn.microsoft.com/library/windows/desktop/hh404598"><strong>ID3D11DeviceContext1</strong></a>.</span></span> <span data-ttu-id="737d3-120">このトピックでは、OpenGL ES 2.0 の一般的なシェーダー パイプライン API パターンが、Direct3D 11 におけるこれらのインターフェイスの何に対応するかを説明します。</span><span class="sxs-lookup"><span data-stu-id="737d3-120">This topic attempts to map common OpenGL ES 2.0 shader pipeline API patterns to the Direct3D 11 equivalents in these interfaces.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="notes-on-specific-opengl-es-20-providers"></a><span data-ttu-id="737d3-121">特定の OpenGL ES 2.0 プロバイダーに関する注意事項</span><span class="sxs-lookup"><span data-stu-id="737d3-121">Notes on specific OpenGL ES 2.0 providers</span></span>


<span data-ttu-id="737d3-122">これらのトピックでは、Khronos OpenGL ES 2.0 仕様とプラットフォームにとらわれない C を使います。iOS と Android はいずれも同じ仕様を使い、これらのプラットフォーム向けに作成された OpenGL ES 2.0 コードは、ここで解説するコード スニペットに非常によく似ています。ただし、これらは通常、オブジェクト指向の API として公開されます。</span><span class="sxs-lookup"><span data-stu-id="737d3-122">These topics use the Khronos OpenGL ES 2.0 specification with platform-agnostic C. Both iOS and Android utilize the same specification and OpenGL ES 2.0 code developed for those platforms is very similar to the code snippets we will walk through, although they are typically exposed as object-oriented APIs.</span></span> <span data-ttu-id="737d3-123">また、各プラットフォームの複雑さと言語の違いが原因で、特にメソッドのパラメーターの型や、一般的な言語構文に若干の相違がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="737d3-123">Also, due to the intricacies and language differences of each platform, there may be minor differences, especially in method parameter types, or in general language syntax.</span></span> <span data-ttu-id="737d3-124">たとえば iOS は、Objective-C を使います。</span><span class="sxs-lookup"><span data-stu-id="737d3-124">iOS, for instance, uses Objective-C.</span></span> <span data-ttu-id="737d3-125">Android は C++ を使うことができますが、開発者は純粋な Java の実装に依存している場合があります。</span><span class="sxs-lookup"><span data-stu-id="737d3-125">Android has the capability to use C++; however, some developers may have relied on a pure Java implementation.</span></span> <span data-ttu-id="737d3-126">この点を考慮しても、これらのトピックは全体的な概念としては有益であり、OpenGL ES API の構造と用途は異なりません。</span><span class="sxs-lookup"><span data-stu-id="737d3-126">With that in mind, these topics should still be useful as the overall concepts, structure and usage of the OpenGL ES APIs do not differ.</span></span>

 

 




