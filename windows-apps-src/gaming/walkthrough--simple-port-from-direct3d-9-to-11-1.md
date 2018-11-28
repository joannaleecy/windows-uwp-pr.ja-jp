---
title: チュートリアル -- Direct3D 9 の DirectX 11 および UWP への移植
description: この移植作業では、Direct3D 9 から Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) に簡単なレンダリング フレームワークを移植する方法について説明します。
ms.assetid: d4467e1f-929b-a4b8-b233-e142a8714c96
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, 移植, Direct3D 9, Direct3D 11
ms.localizationpriority: medium
ms.openlocfilehash: c7569c6b2f041f5535e0eabe934a91da86b60b9a
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7993598"
---
# <a name="walkthrough-port-a-simple-direct3d-9-app-to-directx-11-and-universal-windows-platform-uwp"></a>チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植



この移植作業では、Direct3D 9 から Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) に簡単なレンダリング フレームワークを移植する方法について説明します。
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
<td align="left"><p><a href="simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md">Direct3D 11 の初期化</a></p></td>
<td align="left"><p>Direct3D デバイスとデバイス コンテキストへのハンドルを取得する方法や、DXGI を使ってスワップ チェーンを設定する方法など、Direct3D 9 の初期化コードを Direct3D 11 に変換する方法について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="simple-port-from-direct3d-9-to-11-1-part-2--rendering.md">レンダリング フレームワークの変換</a></p></td>
<td align="left"><p>ジオメトリ バッファーを移植する方法、HLSL シェーダー プログラムをコンパイルして読み込む方法、Direct3D 11 のレンダリング チェーンを実装する方法など、Direct3D 9 の簡単なレンダリング フレームワークを Direct3D 11 に変換する方法について説明します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md">ゲーム ループの移植</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/hh700478"><strong>IFrameworkView</strong></a> を作成して、全画面表示の <a href="https://msdn.microsoft.com/library/windows/apps/br208225"><strong>CoreWindow</strong></a> を制御する方法など、UWP ゲームのウィンドウを実装する方法とゲーム ループを移植する方法について説明します。</p></td>
</tr>
</tbody>
</table>

 

このトピックでは、頂点シェーディングされた回転する立方体を表示する同じ基本的なグラフィックス タスクを実行する 2 つのコード パスについて説明します。 いずれの場合でも、コードは次のプロセスに対応しています。

1.  Direct3D デバイスとスワップ チェーンを作成する。
2.  カラフルな立方体のメッシュを表す頂点バッファーとインデックス バッファーを作成する。
3.  頂点を画面領域に変換する頂点シェーダーと、色値をブレンドするピクセル シェーダーを作成し、シェーダーをコンパイルして、シェーダーを Direct3D リソースとして読み込む。
4.  レンダリング チェーンを実装し、描画された立方体を画面に表示する。
5.  ウィンドウを作成し、メイン ループを開始して、ウィンドウ メッセージの処理に対応する。

このチュートリアルを終了すると、Direct3D 9 と Direct3D 11 の次の基本的な違いを理解できます。

-   デバイス、デバイス コンテキスト、グラフィックス インフラストラクチャの分離。
-   シェーダーをコンパイルし、実行時にシェーダーのバイトコードを読み込むプロセス。
-   入力アセンブラー (IA) ステージの頂点ごとのデータを構成する方法。
-   [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を使って CoreWindow ビューを作成する方法。

このチュートリアルでは、簡素化のため [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) を使用しており、XAML の相互運用には対応しない点に注意してください。

## <a name="prerequisites"></a>前提条件


[UWP DirectX ゲームの開発環境を準備する](prepare-your-dev-environment-for-windows-store-directx-game-development.md)必要があります。 テンプレートはまだ必要ありませんが、このチュートリアルのコード サンプルを読み込むに Microsoft Visual Studio2015 必要があります。

このチュートリアルで説明する DirectX 11 と UWP のプログラミングの概念について詳しくは、「[DirectX 9 からの DirectX 11 と Windows ストアへの移行](porting-considerations.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

**Direct3D**

* [Direct3D 9 での HLSL シェーダーの記述](https://msdn.microsoft.com/library/windows/desktop/bb944006)
* [DirectX ゲーム プロジェクト テンプレート](user-interface.md)

**Microsoft Store**

* [**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx)
* [**オブジェクトへのハンドル演算子 (^)**](https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspx)

