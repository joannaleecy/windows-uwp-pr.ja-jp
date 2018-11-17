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
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7145098"
---
# <a name="map-opengl-es-20-to-direct3d-11"></a>Direct3D 11 への OpenGL ES 2.0 のマッピング



OpenGL ES 2.0 から Direct3D へのグラフィックス アーキテクチャの移植プロセスを初めて開始する場合は、API 間の主要な違いについて把握しておいてください。 このセクションのトピックは、グラフィックスの処理を Direct3D に移行する際に必ず必要な API の変更と移植戦略を計画するのに役立ちます。
## 
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
<td align="left"><p><a href="compare-opengl-es-2-0-api-design-to-directx.md">OpenGL ES 2.0 から Direct3D への移植の計画</a></p></td>
<td align="left"><p>iOS または Android プラットフォームからゲームを移植している場合、OpenGL ES 2.0 に多大な投資を行ってこられたものと思われます。 グラフィックス パイプラインのコードベースを Direct3D 11 と Windows ランタイムに移す準備をしているときは、開始する前に何点か注意してください。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="moving-from-egl-to-dxgi.md">EGL コードと DXGI および Direct3D の比較</a></p></td>
<td align="left"><p>DirectX Graphics Interface (DXGI) といくつかの Direct3D API は EGL と同じ役割を果たします。 このトピックは EGL の観点から DXGI と Direct3D 11 を理解するのに役立ちます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="porting-uniforms-and-attributes.md">OpenGL ES 2.0 のバッファー、uniform、頂点属性と Direct3D の比較</a></p></td>
<td align="left"><p>OpenGL ES 2.0 から Direct3D 11 に移植するプロセスでは、アプリとシェーダー プログラムの間でデータを受け渡すための構文と API の動作を変更する必要があります。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="change-your-shader-loading-code.md">OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較</a></p></td>
<td align="left"><p>概念的には、Direct3D 11 のシェーダー パイプラインは OpenGL ES 2.0 のそれとよく似ています。 ただし、API の設計という点では、シェーダー ステージを作成、管理するための主要コンポーネントは、<a href="https://msdn.microsoft.com/library/windows/desktop/hh404575"><strong>ID3D11Device1</strong></a> と <a href="https://msdn.microsoft.com/library/windows/desktop/hh404598"><strong>ID3D11DeviceContext1</strong></a> という 2 つのプライマリ インターフェイスに含まれています。 このトピックでは、OpenGL ES 2.0 の一般的なシェーダー パイプライン API パターンが、Direct3D 11 におけるこれらのインターフェイスの何に対応するかを説明します。</p></td>
</tr>
</tbody>
</table>

 

## <a name="notes-on-specific-opengl-es-20-providers"></a>特定の OpenGL ES 2.0 プロバイダーに関する注意事項


これらのトピックでは、Khronos OpenGL ES 2.0 仕様とプラットフォームにとらわれない C を使います。iOS と Android はいずれも同じ仕様を使い、これらのプラットフォーム向けに作成された OpenGL ES 2.0 コードは、ここで解説するコード スニペットに非常によく似ています。ただし、これらは通常、オブジェクト指向の API として公開されます。 また、各プラットフォームの複雑さと言語の違いが原因で、特にメソッドのパラメーターの型や、一般的な言語構文に若干の相違がある場合があります。 たとえば iOS は、Objective-C を使います。 Android は C++ を使うことができますが、開発者は純粋な Java の実装に依存している場合があります。 この点を考慮しても、これらのトピックは全体的な概念としては有益であり、OpenGL ES API の構造と用途は異なりません。

 

 




