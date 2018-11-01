---
author: mtoepke
title: チュートリアル -- Direct3D 11 のシャドウ ボリュームの深度バッファー
description: このチュートリアルでは、すべての Direct3D 機能レベルのデバイスで Direct3D 11 を使い、深度マップを利用してシャドウ ボリュームをレンダリングする方法について説明します。
ms.assetid: d15e6501-1a1d-d99c-d1d8-ad79b849db90
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, シャドウ ボリューム, 深度バッファー, DirectX 11
ms.localizationpriority: medium
ms.openlocfilehash: 269f8423795d7c2515ce555cf8e65f14a8c63431
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919687"
---
# <a name="walkthrough-implement-shadow-volumes-using-depth-buffers-in-direct3d-11"></a>チュートリアル: Direct3D 11 の深度バッファーを使ったシャドウ ボリュームの実装



このチュートリアルでは、すべての Direct3D 機能レベルのデバイスで Direct3D 11 を使い、深度マップを利用してシャドウ ボリュームをレンダリングする方法について説明します。
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
<td align="left"><p><a href="create-depth-buffer-resource--view--and-sampler-state.md">深度バッファーのデバイス リソースの作成</a></p></td>
<td align="left"><p>シャドウ ボリュームの深度のテストをサポートするために必要な Direct3D デバイス リソースを作成する方法について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="render-the-shadow-map-to-the-depth-buffer.md">深度バッファーへのシャドウ マップのレンダリング</a></p></td>
<td align="left"><p>ライトの視点からレンダリングして、シャドウ ボリュームを表す 2 次元の深度マップを作成します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="render-the-scene-with-depth-testing.md">深度のテストを使ったシーンのレンダリング</a></p></td>
<td align="left"><p>シャドウ効果を作成するには、頂点 (またはジオメトリ) シェーダーとピクセル シェーダーに深度のテストを追加します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="target-a-range-of-hardware.md">ハードウェアの範囲でのシャドウ マップのサポート</a></p></td>
<td align="left"><p>より高速なデバイスでは高品質なシャドウを、性能が低いデバイスではよりすばやいシャドウをレンダリングします。</p></td>
</tr>
</tbody>
</table>

 

## <a name="shadow-mapping-application-to-direct3d-9-desktop-porting"></a>Direct3D 9 デスクトップに対するシャドウ マップの適用の移植


Windows8 adde d 深度比較の機能レベルの 9\_1 と 9\_3 の機能にします。 シャドウ ボリュームを含むレンダリング コードを DirectX 11 に移行できるようになりました。Direct3D 11 レンダラーは機能レベル 9 のデバイスと下位互換性を持ちます。 このチュートリアルでは、Direct3D 11 のアプリやゲームで深度のテストを使って従来のシャドウ ボリュームを実装する方法を説明します。 コードは次のプロセスに対応しています。

1.  シャドウ マッピング用の Direct3D デバイス リソースを作成する。
2.  レンダリング パスを追加して深度マップを作成する。
3.  深度のテストをメイン レンダリング パスに渡す。
4.  必要なシェーダー コードを実行する。
5.  下位レベル ハードウェアでのレンダリングを高速化するためのオプション。

このチュートリアルを終了すると、機能レベル 9\_1 以上と互換性のある Direct3D 11 で互換性のある基本的なシャドウ ボリュームの手法を実装する方法を理解できます。

## <a name="prerequisites"></a>前提条件


[ユニバーサル Windows プラットフォーム (UWP) DirectX ゲームの開発環境を準備する](prepare-your-dev-environment-for-windows-store-directx-game-development.md)必要があります。 テンプレートは、必要ありませんが、このチュートリアルのコード サンプルをビルドするのには、Microsoft Visual Studio2015 する必要があります。

## <a name="related-topics"></a>関連トピック


**Direct3D**

* [Direct3D 9 での HLSL シェーダーの記述](https://msdn.microsoft.com/library/windows/desktop/bb944006)
* [テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)

**シャドウ マッピングに関する技術記事**

* [シャドウ深度マップを向上させるための一般的な方法](https://msdn.microsoft.com/library/windows/desktop/ee416324)
* [カスケードされたシャドウ マップ](https://msdn.microsoft.com/library/windows/desktop/ee416307)

 

 




