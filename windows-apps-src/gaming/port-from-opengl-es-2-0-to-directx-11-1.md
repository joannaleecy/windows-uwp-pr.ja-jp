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
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5570520"
---
# <a name="port-from-opengl-es-20-to-direct3d-11"></a>OpenGL ES 2.0 から Direct3D 11 への移植



OpenGL ES 2.0 グラフィックス パイプラインを Direct3D 11 と Windows ランタイムに移植するための記事、概要、チュートリアルを紹介します。

> **注:**  OpenGL ES 2.0 プロジェクトを移植する中間の手順は、Microsoft ストアの角度を使用します。 ANGLE では、OpenGL ES API 呼び出しを DirectX 11 API 呼び出しに変換することにより、Windows で OpenGL ES コンテンツを実行することができます。 ANGLE について詳しくは、[Microsoft Store 用の ANGLE に関する Wiki ページ](http://go.microsoft.com/fwlink/p/?linkid=618387)をご覧ください。

 

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
<td align="left"><p><a href="map-concepts-and-infrastructure.md">Direct3D 11.1 への OpenGL ES 2.0 のマッピング</a></p></td>
<td align="left"><p>OpenGL ES 2.0 から Direct3D へのグラフィックス アーキテクチャの移植プロセスを初めて開始する場合は、API 間の主要な違いについて把握しておいてください。 このセクションのトピックは、グラフィックスの処理を Direct3D に移行する際に必ず必要な API の変更と移植戦略を計画するのに役立ちます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md">簡単な OpenGL ES 2.0 レンダラーを Direct3D 11.1 に移植する方法</a></p></td>
<td align="left"><p>この移植作業では、基本から始めます。Visual Studio 2015 の DirectX 11 アプリ (ユニバーサル Windows) テンプレートに対応するように、頂点シェーディングされた回転する立方体の簡単なレンダラーを OpenGL ES 2.0 から Direct3D に移植します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="opengl-es-2-0-to-directx-11-1-reference.md">OpenGL ES 2.0 から Direct3D 11.1 への移行のためのリファレンス</a></p></td>
<td align="left"><p>OpenGL ES 2.0 から Direct3D 11 への移植の際に API マッピングや簡単なコード サンプルを探す場合は、これらのリファレンス トピックをご覧ください。</p></td>
</tr>
</tbody>
</table>

 

 

 




