---
title: DirectX ゲームの最適化と高度なトピック
description: DirectX ゲーム プログラミングの最適化と高度なトピックについて説明します。
ms.assetid: b5f29fb2-3bcf-43b2-9a68-f8819473bf62
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, 最適化, マルチサンプリング, スワップ チェーン
ms.localizationpriority: medium
ms.openlocfilehash: e9618a35ecd8f9d1a37b627494c0f00a5ed84806
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7854683"
---
# <a name="optimization-and-advanced-topics-for-directx-games"></a>DirectX ゲームの最適化と高度なトピック

このセクションでは、DirectX ゲームのパフォーマンスの最適化と他の高度なトピックについて説明します。

「ゲームの非同期プログラミング」トピックでは、非同期プログラミングを使用して一部のコンポーネントを並列化し、マルチスレッドを使用して強力な GPU は最大限に活用する際のさまざまな考慮事項について取り上げます。

「Direct3D 11 でのデバイス削除シナリオの処理」トピックでは、チュートリアルを使用して、Direct3D 11 で開発したゲームがグラフィックス アダプターのリセット、取り外し、変更の状況をどのように検出し対応するかについて説明します。

「UWP アプリでのマルチサンプリング」トピックでは、マルチサンプル アンチエイリアシングの使用方法の概要について説明します。マルチサンプル アンチエイリアシングとは、Direct3D を使って構築された UWP ゲームでエッジを滑らかに描画するために使用されるグラフィックス技法です。

「入力とレンダリング ループの最適化」トピックでは、入力待ち時間の管理とレンダリング ループの最適化で必要となる適切な入力イベント処理オプションを選ぶ方法のガイダンスを示します。

「DXGI 1.3 スワップ チェーンによる遅延の減少」トピックでは、スワップ チェーンが新しいフレームのレンダリング開始の適切な時間を通知するまで待機することによって実質的なフレーム待機時間を短縮する方法について説明します。

「スワップ チェーンのスケーリングとオーバーレイ」トピックでは、レンダリングにかかる時間を改善する方法について説明します。そのためには、スケーリングされたスワップ チェーンを使用し、ディスプレイのネイティブの機能よりも低い解像度でリアルタイムのゲーム コンテンツをレンダリングします。 また、ハードウェア オーバーレイ機能を使ってデバイスのオーバーレイ スワップ チェーンを作成する方法についても説明します。この方法を使用して、スワップ チェーンのスケーリングが原因で発生する、縮小された UI の問題を改善することができます。

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
<td align="left"><p><a href="asynchronous-programming-directx-and-cpp.md">ゲームの非同期プログラミング</a></p></td>
<td align="left"><p>DirectX での非同期プログラミングとスレッド化について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="handling-device-lost-scenarios.md">Direct3D 11 でのデバイス削除シナリオの処理</a></p></td>
<td align="left"><p>グラフィックス アダプターの取り外しや再初期化が行われたときに Direct3D と DXGI デバイス インターフェイス チェーンを再作成します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="multisampling--multi-sample-anti-aliasing--in-windows-store-apps.md">UWP アプリでのマルチサンプリング</a></p></td>
<td align="left"><p>Direct3D を使って構築された UWP ゲームでマルチサンプリングを使用します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="optimize-performance-for-windows-store-direct3d-11-apps-with-coredispatcher.md">入力とレンダリング ループの最適化</a></p></td>
<td align="left"><p>入力待ち時間を短縮し、レンダリング ループを最適化します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="reduce-latency-with-dxgi-1-3-swap-chains.md">DXGI 1.3 スワップ チェーンによる遅延の減少</a></p></td>
<td align="left"><p>DXGI 1.3を使って、実質的なフレーム待機時間を短縮します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="multisampling--scaling--and-overlay-swap-chains.md">スワップ チェーンのスケーリングとオーバーレイ</a></p></td>
<td align="left"><p>モバイル デバイスでのレンダリングを高速化するためにスケーリングされたスワップ チェーンを作成し、オーバーレイ スワップ チェーンを使用して画質を改善します。</p></td>
</tr>
</tbody>
</table>