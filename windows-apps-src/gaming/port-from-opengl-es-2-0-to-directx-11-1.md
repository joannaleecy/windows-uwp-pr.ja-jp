---
author: mtoepke
title: "OpenGL ES 2.0 から Direct3D 11 への移植"
description: "OpenGL ES 2.0 グラフィックス パイプラインを Direct3D 11 と Windows ランタイムに移植するための記事、概要、チュートリアルを紹介します。"
ms.assetid: 1e1cf668-a15f-0c7b-8daf-3260d27c6d9c
ms.sourcegitcommit: 814f056eaff5419b9c28ba63cf32012bd82cc554
ms.openlocfilehash: 40380582a9210cb705a5e7e591d4a8f37c42f8dd

---

# OpenGL ES 2.0 から Direct3D 11 への移植


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

OpenGL ES 2.0 グラフィックス パイプラインを Direct3D 11 と Windows ランタイムに移植するための記事、概要、チュートリアルを紹介します。

> **注:** OpenGL ES 2.0 プロジェクトを移植する中間の手順では、Windows ストア用の ANGLE を使います。 ANGLE では、OpenGL ES API 呼び出しを DirectX 11 API 呼び出しに変換することにより、Windows で OpenGL ES コンテンツを実行することができます。 ANGLE について詳しくは、[Windows ストア用の ANGLE に関する Wiki ページ](http://go.microsoft.com/fwlink/p/?linkid=618387)をご覧ください。

 

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
<td align="left"><p>[Direct3D 11.1 への OpenGL ES 2.0 のマッピング](map-concepts-and-infrastructure.md)</p></td>
<td align="left"><p>OpenGL ES 2.0 から Direct3D へのグラフィックス アーキテクチャの移植プロセスを初めて開始する場合は、API 間の主要な違いについて把握しておいてください。 このセクションのトピックは、グラフィックスの処理を Direct3D に移行する際に必ず必要な API の変更と移植戦略を計画するのに役立ちます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[簡単な OpenGL ES 2.0 レンダラーを Direct3D 11.1 に移植する方法](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)</p></td>
<td align="left"><p>この移植作業では、基本から始めます。Visual Studio 2015 の DirectX 11 アプリ (ユニバーサル Windows) テンプレートに対応するように、頂点シェーディングされた回転する立方体の簡単なレンダラーを OpenGL ES 2.0 から Direct3D に移植します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[OpenGL ES 2.0 から Direct3D 11.1 への移行のためのリファレンス](opengl-es-2-0-to-directx-11-1-reference.md)</p></td>
<td align="left"><p>OpenGL ES 2.0 から Direct3D 11 への移植の際に API マッピングや簡単なコード サンプルを探す場合は、これらのリファレンス トピックをご覧ください。</p></td>
</tr>
</tbody>
</table>

 

> **注:**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

 

 







<!--HONumber=Jun16_HO5-->


