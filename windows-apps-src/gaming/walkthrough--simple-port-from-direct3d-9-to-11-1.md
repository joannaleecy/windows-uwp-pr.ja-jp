---
title: チュートリアル-- DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植
description: この移植作業では、Direct3D 9 から Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) に簡単なレンダリング フレームワークを移植する方法について説明します。
ms.assetid: d4467e1f-929b-a4b8-b233-e142a8714c96
---

# チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

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
<td align="left"><p>[Initialize Direct3D 11](simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md)</p></td>
<td align="left"><p>Direct3D デバイスとデバイス コンテキストへのハンドルを取得する方法や、DXGI を使ってスワップ チェーンを設定する方法など、Direct3D 9 の初期化コードを Direct3D 11 に変換する方法について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Convert the rendering framework](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md)</p></td>
<td align="left"><p>ジオメトリ バッファーを移植する方法、HLSL シェーダー プログラムをコンパイルして読み込む方法、Direct3D 11 のレンダリング チェーンを実装する方法など、Direct3D 9 の簡単なレンダリング フレームワークを Direct3D 11 に変換する方法について説明します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[Port the game loop](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)</p></td>
<td align="left"><p>全画面の [<strong>CoreWindow</strong>](https://msdn.microsoft.com/library/windows/apps/br208225) を制御する [<strong>IFrameworkView</strong>](https://msdn.microsoft.com/library/windows/apps/hh700478) を構築する方法を含め、UWP ゲームのウィンドウを実装する方法とゲーム ループを移植する方法について説明します。</p></td>
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
-   [
            **IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を使って CoreWindow ビューを作成する方法。

このチュートリアルでは、簡素化のため [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) を使用しており、XAML の相互運用には対応しない点に注意してください。

## 前提条件


[UWP DirectX ゲームの開発環境を準備する](prepare-your-dev-environment-for-windows-store-directx-game-development.md)必要があります。 テンプレートはまだ必要ありませんが、このチュートリアルのコード サンプルを読み込むには Microsoft Visual Studio 2015 が必要です。

このチュートリアルで説明する DirectX 11 と UWP のプログラミングの概念について詳しくは、「[DirectX 9 からの DirectX 11 と Windows ストアへの移行](porting-considerations.md)」をご覧ください。

## 関連トピック


**Direct3D**
[Direct3D 9 での HLSL シェーダーの記述](https://msdn.microsoft.com/library/windows/desktop/bb944006)

[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)

**Windows ストア**
[**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx)

[**オブジェクト演算子 (^) へのハンドル (^)**]https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspx

 

 






<!--HONumber=Mar16_HO1-->


