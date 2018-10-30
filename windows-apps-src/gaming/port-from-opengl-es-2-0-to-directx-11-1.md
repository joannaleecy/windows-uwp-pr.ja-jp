---
author: mtoepke
title: OpenGL ES 2.0 から Direct3D 11 への移植
description: OpenGL ES 2.0 グラフィックス パイプラインを Direct3D 11 と Windows ランタイムに移植するための記事、概要、チュートリアルを紹介します。
ms.assetid: 1e1cf668-a15f-0c7b-8daf-3260d27c6d9c
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、OpenGL、Direct3D 11, 移植, グラフィックス
ms.localizationpriority: medium
ms.openlocfilehash: 6421f5a5a71828d5234a11bab9e442a5accecda5
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5763336"
---
# <a name="port-from-opengl-es-20-to-direct3d-11"></a><span data-ttu-id="0f4dd-104">OpenGL ES 2.0 から Direct3D 11 への移植</span><span class="sxs-lookup"><span data-stu-id="0f4dd-104">Port from OpenGL ES 2.0 to Direct3D 11</span></span>



<span data-ttu-id="0f4dd-105">OpenGL ES 2.0 グラフィックス パイプラインを Direct3D 11 と Windows ランタイムに移植するための記事、概要、チュートリアルを紹介します。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-105">Includes articles, overviews, and walkthroughs for porting an OpenGL ES 2.0 graphics pipeline to a Direct3D 11 and the Windows Runtime.</span></span>

> <span data-ttu-id="0f4dd-106">**注:**  OpenGL ES 2.0 プロジェクトを移植する中間の手順は、Microsoft ストアの角度を使用します。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-106">**Note** An intermediate step to porting your OpenGL ES 2.0 project is to use ANGLE for Microsoft Store.</span></span> <span data-ttu-id="0f4dd-107">ANGLE では、OpenGL ES API 呼び出しを DirectX 11 API 呼び出しに変換することにより、Windows で OpenGL ES コンテンツを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-107">ANGLE allows you to run OpenGL ES content on Windows by translating OpenGL ES API calls to DirectX 11 API calls.</span></span> <span data-ttu-id="0f4dd-108">ANGLE について詳しくは、[Microsoft Store 用の ANGLE に関する Wiki ページ](http://go.microsoft.com/fwlink/p/?linkid=618387)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-108">For more information about ANGLE, go to the [ANGLE for Microsoft Store Wiki](http://go.microsoft.com/fwlink/p/?linkid=618387).</span></span>

 

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="0f4dd-109">トピック</span><span class="sxs-lookup"><span data-stu-id="0f4dd-109">Topic</span></span></th>
<th align="left"><span data-ttu-id="0f4dd-110">説明</span><span class="sxs-lookup"><span data-stu-id="0f4dd-110">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="map-concepts-and-infrastructure.md"><span data-ttu-id="0f4dd-111">Direct3D 11.1 への OpenGL ES 2.0 のマッピング</span><span class="sxs-lookup"><span data-stu-id="0f4dd-111">Map OpenGL ES 2.0 to Direct3D 11.1</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="0f4dd-112">OpenGL ES 2.0 から Direct3D へのグラフィックス アーキテクチャの移植プロセスを初めて開始する場合は、API 間の主要な違いについて把握しておいてください。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-112">When starting the process of porting your graphics architecture from OpenGL ES 2.0 to Direct3D for the first time, familiarize yourself with the key differences between the APIs.</span></span> <span data-ttu-id="0f4dd-113">このセクションのトピックは、グラフィックスの処理を Direct3D に移行する際に必ず必要な API の変更と移植戦略を計画するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-113">The topics in this section help you plan your port strategy and the API changes that you must make when moving your graphics processing to Direct3D.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md"><span data-ttu-id="0f4dd-114">簡単な OpenGL ES 2.0 レンダラーを Direct3D 11.1 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="0f4dd-114">How to: port a simple OpenGL ES 2.0 renderer to Direct3D 11.1</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="0f4dd-115">この移植作業では、基本から始めます。Visual Studio 2015 の DirectX 11 アプリ (ユニバーサル Windows) テンプレートに対応するように、頂点シェーディングされた回転する立方体の簡単なレンダラーを OpenGL ES 2.0 から Direct3D に移植します。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-115">For this porting exercise, we'll start with the basics: bringing a simple renderer for a spinning, vertex-shaded cube from OpenGL ES 2.0 into Direct3D, such that it matches the DirectX 11 App (Universal Windows) template from Visual Studio 2015.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="opengl-es-2-0-to-directx-11-1-reference.md"><span data-ttu-id="0f4dd-116">OpenGL ES 2.0 から Direct3D 11.1 への移行のためのリファレンス</span><span class="sxs-lookup"><span data-stu-id="0f4dd-116">OpenGL ES 2.0 to Direct3D 11.1 reference</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="0f4dd-117">OpenGL ES 2.0 から Direct3D 11 への移植の際に API マッピングや簡単なコード サンプルを探す場合は、これらのリファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f4dd-117">Use these reference topics to look up API mapping and short code samples when porting from OpenGL ES 2.0 to Direct3D 11.</span></span></p></td>
</tr>
</tbody>
</table>

 

 

 




