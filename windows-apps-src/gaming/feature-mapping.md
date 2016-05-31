---
author: mtoepke
title: DirectX 11 API への DirectX 9 の機能のマッピング
description: Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。
ms.assetid: 3aa8a114-4e47-ae0a-9447-88ba324377b8
---

# DirectX 11 API への DirectX 9 の機能のマッピング


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

**要約**

-   [DirectX の移植の計画](plan-your-directx-port.md)
-   [Direct3D 9 と Direct3D 11 の間の重要な変更点](understand-direct3d-11-1-concepts.md)
-   機能のマッピング


Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。

## DirectX 11 API への Direct3D 9 のマッピング


[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) はこれまでと同じく DirectX グラフィックスの土台ですが、API は DirectX 9 以降変更されています。

-   Microsoft DirectX Graphic Infrastructure (DXGI) はグラフィックス アダプターを設定するために使われます。 バッファー形式の選択、スワップ チェーンの作成、フレームの表示、共有リソースの作成には [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534) を使います。 「[DXGI の概要](https://msdn.microsoft.com/library/windows/desktop/bb205075)」をご覧ください。
-   Direct3D のデバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。 ほとんどのサンプルではイミディエイト コンテキストを使ってデバイスに直接レンダリングしていますが、Direct3D 11 ではマルチスレッド レンダリングもサポートされており、その場合は遅延コンテキストが使われます。 「[Direct3D 11 のデバイスについて](https://msdn.microsoft.com/library/windows/desktop/ff476880)」をご覧ください。
-   一部の機能は非推奨になっていますが、特に固定関数パイプラインが推奨されなくなりました。 「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。

Direct3D 11 の機能の完全な一覧については、「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/ff476342)」と「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/hh404562)」をご覧ください。

## Direct2D 9 から Direct2D 11 への移行


[Direct2D (Windows)](https://msdn.microsoft.com/library/windows/desktop/dd370990) は、これまでどおり DirectX グラフィックスと Windows の重要な一部です。 これまでどおり Direct2D を使って 2D ゲームを描画したり、Direct3D の上にオーバーレイ (HUD) を描画したりできます。

Direct2D は Direct3D の上で実行されます。2D ゲームは API を使って実装できます。 たとえば、Direct3D を使って実装される 2D ゲームでは、正投影を使ったり、Z 値を設定してプリミティブの描画の順序を制御したり、ピクセル シェーダーを使って特殊効果を追加したりできます。

Direct2D は Direct3D に基づいているため、DXGI とデバイス コンテキストも使います。 「[Direct2D API の概要](https://msdn.microsoft.com/library/windows/desktop/dd317121)」をご覧ください。

[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) API は、Direct2D を使って書式付きテキストのサポートを追加します。 「[DirectWrite の紹介](https://msdn.microsoft.com/library/windows/desktop/dd371554)」をご覧ください。

## 推奨されなくなったヘルパー ライブラリの置き換え


D3DX と DXUT は推奨されなくなったため、UWP ゲームでは使うことができません。 これらのヘルパー ライブラリでは、テクスチャの読み込みやメッシュの読み込みなどのタスク用にリソースが提供されていました。

-   「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」では、ウィンドウの設定、Direct3D の初期化、基本的な 3D レンダリングの方法を示します。
-   「[DirectX を使った単純なユニバーサル Windows プラットフォーム (UWP) ゲームの作成](tutorial--create-your-first-metro-style-directx-game.md)」では、グラフィックス、ファイルの読み込み、UI、コントロール、サウンドなど、一般的なゲーム プログラミング タスクを示します。
-   [DirectX ツール キット](http://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 および UWP アプリで利用できるヘルパー クラスが用意されています。

## FX から HLSL へのシェーダー プログラムの移行


Effects を含め、D3DX ユーティリティ ライブラリ (D3DX 9、D3DX 10、D3DX 11) は、UWP では推奨されなくなりました。 UWP のすべての DirectX ゲームは、Effects を使わずに、[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561) を使ってグラフィックス パイプラインを実行します。

Visual Studio は、シェーダー オブジェクトをコンパイルするために FXC をバックグラウンドで使います。 UWP ゲームのシェーダーは事前にコンパイルされます。 バイトコードは実行時に読み込まれ、各シェーダー リソースは適切なレンダリング パスの間にグラフィックス パイプラインにバインドされます。 シェーダーを独自の別の .HLSL ファイルに移し、レンダリング テクノロジを C++ コードで実装する必要があります。

シェーダー リソースの読み込みの概要については、「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。

Direct3D 11 ではシェーダー モデル 5 が導入されましたが、これには Direct3D 機能レベル 11\_0 以上が必要です。 「[Direct3D 11 の HLSL シェーダー モデル 5 の機能](https://msdn.microsoft.com/library/windows/desktop/ff471419)」をご覧ください。

## XNAMath と D3DXMath の置き換え


XNAMath (または D3DXMath) を使ったコードは [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) に移行する必要があります。 DirectXMath には、x86、x64、ARM の間で移植可能な型が含まれています。 「[XNA Math ライブラリからのコードの移行](https://msdn.microsoft.com/library/windows/desktop/ee418730)」をご覧ください。

DirectXMath の浮動小数点型はシェーダーで使うと便利です。 たとえば、[**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) と [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) は、定数バッファーのデータの整列に便利です。

## XAudio2 (とバックグラウンド オーディオ) への DirectSound の置き換え


DirectSound では、UWP はサポートされていません。

-   ゲームにサウンド効果を追加するには [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使います。

##  XInput と UWP API への DirectInput の置き換え


DirectInput では、UWP はサポートされていません。

-   マウス、キーボード、タッチ入力には [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の入力イベント コールバックを使います。
-   ゲーム コントローラーのサポート (とゲーム コントローラーのヘッドセットのサポート) には [XInput](https://msdn.microsoft.com/library/windows/desktop/ee417001) 1.4 を使います。 デスクトップと UWP に共有コード ベースを使う場合は、下位互換性について、「[XInput のバージョン](https://msdn.microsoft.com/library/windows/desktop/hh405051)」をご覧ください。
-   ゲームでアプリ バーを使う必要がある場合は、[**EdgeGesture**](https://msdn.microsoft.com/library/windows/apps/hh701600) イベントに登録します。

## DirectShow の代わりに Microsoft メディア ファンデーションを使う


DirectShow は DirectX API (または Windows API) にはもう含まれていません。 [Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197)は共有サーフェイスを使って Direct3D にビデオ コンテンツを提供します。 「[Direct3D 11 のビデオ API](https://msdn.microsoft.com/library/windows/desktop/hh447677)」をご覧ください。

## ネットワーク コードへの DirectPlay の置き換え


Microsoft DirectPlay は推奨されなくなりました。 ゲームでネットワーク サービスを使う場合は、UWP の要件に準拠しているネットワーク コードを提供する必要があります。 次の API を使います。

-   [Windows ストア アプリの Win32 および COM (ネットワーク) (Windows)](https://msdn.microsoft.com/library/windows/apps/br205759)
-   [**Windows.Networking 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br207124)
-   [**Windows.Networking.Sockets 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br226960)
-   [**Windows.Networking.Connectivity 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br207308)
-   [**Windows.ApplicationModel.Background 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br224847)

次の記事は、ネットワーク機能を追加し、アプリのパッケージ マニフェストでネットワークのサポートを宣言するうえで役立ちます。

-   [ソケットを使った接続 (C#/VB/C++ と XAML を使った Windows ストア アプリ) (Windows)](https://msdn.microsoft.com/library/windows/apps/xaml/hh452976)
-   [WebSocket を使った接続 (C#/VB/C++ と XAML を使った Windows ストア アプリ) (Windows)](https://msdn.microsoft.com/library/windows/apps/xaml/hh994396)
-   [Web サービスへの接続 (C#/VB/C++ と XAML を使った Windows ストア アプリ) (Windows)](https://msdn.microsoft.com/library/windows/apps/xaml/hh761504)
-   [ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)

アプリの中断中は、すべての UWP アプリ (ゲームを含む) で特定の種類のバックグラウンド タスクを使って接続を維持します。 中断されている間、ゲームが接続状態を保存する必要がある場合は、「[ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)」をご覧ください。

## 関数のマッピング


Direct3D 9 から Direct3D 11 にコードの変換を行う場合は、次の表を参考にしてください。 これは、デバイスとデバイス コンテキストの区別にも役立ちます。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Direct3D9</th>
<th align="left">相当する Direct3D 11 の要素</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[<strong>IDirect3DDevice9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174336)</p></td>
<td align="left"><p>[<strong>ID3D11Device2</strong>](https://msdn.microsoft.com/library/windows/desktop/dn280493)</p>
<p>[<strong>ID3D11DeviceContext2</strong>](https://msdn.microsoft.com/library/windows/desktop/dn280498)</p>
<p>グラフィックス パイプラインのステージについては、「[グラフィックス パイプライン](https://msdn.microsoft.com/library/windows/desktop/ff476882)」で説明されています。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>IDirect3D9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174300)</p></td>
<td align="left"><p>[<strong>IDXGIFactory2</strong>](https://msdn.microsoft.com/library/windows/desktop/hh404556)</p>
<p>[<strong>IDXGIAdapter2</strong>](https://msdn.microsoft.com/library/windows/desktop/hh404537)</p>
<p>[<strong>IDXGIDevice3</strong>](https://msdn.microsoft.com/library/windows/desktop/dn280345)</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>IDirect3DDevice9::Present</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174423)</p></td>
<td align="left"><p>[<strong>IDXGISwapChain1::Present1</strong>](https://msdn.microsoft.com/library/windows/desktop/hh446797)</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>IDirect3DDevice9::TestCooperativeLevel</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174472)</p></td>
<td align="left"><p>[<strong>IDXGISwapChain1::Present1</strong>](https://msdn.microsoft.com/library/windows/desktop/hh446797) を DXGI_PRESENT_TEST フラグを設定して呼び出します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>IDirect3DBaseTexture9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174322)</p>
<p>[<strong>IDirect3DTexture9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205909)</p>
<p>[<strong>IDirect3DCubeTexture9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174329)</p>
<p>[<strong>IDirect3DVolumeTexture9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205941)</p>
<p>[<strong>IDirect3DIndexBuffer9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205865)</p>
<p>[<strong>IDirect3DVertexBuffer9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205915)</p></td>
<td align="left"><p>[<strong>ID3D11Buffer</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476351)</p>
<p>[<strong>ID3D11Texture1D</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476633)</p>
<p>[<strong>ID3D11Texture2D</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476635)</p>
<p>[<strong>ID3D11Texture3D</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476637)</p>
<p>[<strong>ID3D11ShaderResourceView</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476628)</p>
<p>[<strong>ID3D11RenderTargetView</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476582)</p>
<p>[<strong>ID3D11DepthStencilView</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476377)</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>IDirect3DVertexShader9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205922)</p>
<p>[<strong>IDirect3DPixelShader9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205869)</p></td>
<td align="left"><p>[<strong>ID3D11VertexShader</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476641)</p>
<p>[<strong>ID3D11PixelShader</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476576)</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>IDirect3DVertexDeclaration9</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205919)</p></td>
<td align="left"><p>[<strong>ID3D11InputLayout</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476575)</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>IDirect3DDevice9::SetRenderState</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205805)</p>
<p>[<strong>IDirect3DDevice9::SetSamplerState</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205806)</p></td>
<td align="left"><p>[<strong>ID3D11BlendState1</strong>](https://msdn.microsoft.com/library/windows/desktop/hh404571)</p>
<p>[<strong>ID3D11DepthStencilState</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476375)</p>
<p>[<strong>ID3D11RasterizerState1</strong>](https://msdn.microsoft.com/library/windows/desktop/hh446828)</p>
<p>[<strong>ID3D11SamplerState</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476588)</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>IDirect3DDevice9::DrawIndexedPrimitive</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174369)</p>
<p>[<strong>IDirect3DDevice9::DrawPrimitive</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174371)</p></td>
<td align="left"><p>[<strong>ID3D11DeviceContext::Draw</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476407)</p>
<p>[<strong>ID3D11DeviceContext::DrawIndexed</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476409)</p>
<p>[<strong>ID3D11DeviceContext::DrawIndexedInstanced</strong>](https://msdn.microsoft.com/library/windows/desktop/bb173566)</p>
<p>[<strong>ID3D11DeviceContext::DrawInstanced</strong>](https://msdn.microsoft.com/library/windows/desktop/bb173567)</p>
<p>[<strong>ID3D11DeviceContext::IASetPrimitiveTopology</strong>](https://msdn.microsoft.com/library/windows/desktop/bb173590)</p>
<p>[<strong>ID3D11DeviceContext::DrawAuto</strong>](https://msdn.microsoft.com/library/windows/desktop/bb173564)</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>IDirect3DDevice9::BeginScene</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174350)</p>
<p>[<strong>IDirect3DDevice9::EndScene</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174375)</p>
<p>[<strong>IDirect3DDevice9::DrawPrimitiveUP</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174372)</p>
<p>[<strong>IDirect3DDevice9::DrawIndexedPrimitiveUP</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174370)</p></td>
<td align="left"><p>直接相当する要素はなし</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>IDirect3DDevice9::ShowCursor</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174470)</p>
<p>[<strong>IDirect3DDevice9::SetCursorPosition</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174429)</p>
<p>[<strong>IDirect3DDevice9::SetCursorProperties</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174430)</p></td>
<td align="left"><p>標準的なカーソル API を使います。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>IDirect3DDevice9::Reset</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174425)</p></td>
<td align="left"><p>LOST デバイスと POOL_MANAGED はもう存在しません。 [<strong>IDXGISwapChain1::Present1</strong>](https://msdn.microsoft.com/library/windows/desktop/hh446797) は、[<strong>DXGI_ERROR_DEVICE_REMOVED</strong>](https://msdn.microsoft.com/library/windows/desktop/bb509553) 返り値で失敗する可能性があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<strong>IDirect3DDevice9:DrawRectPatch</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174373)</p>
<p>[<strong>IDirect3DDevice9:DrawTriPatch</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174374)</p>
<p>[<strong>IDirect3DDevice9:LightEnable</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174421)</p>
<p>[<strong>IDirect3DDevice9:MultiplyTransform</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174422)</p>
<p>[<strong>IDirect3DDevice9:SetLight</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205798)</p>
<p>[<strong>IDirect3DDevice9:SetMaterial</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174437)</p>
<p>[<strong>IDirect3DDevice9:SetNPatchMode</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174438)</p>
<p>[<strong>IDirect3DDevice9:SetTransform</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174463)</p>
<p>[<strong>IDirect3DDevice9:SetFVF</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174433)</p>
<p>[<strong>IDirect3DDevice9:SetTextureStageState</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174462)</p></td>
<td align="left"><p>固定関数パイプラインは推奨されなくなりました。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[<strong>IDirect3DDevice9:CheckDepthStencilMatch</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174308)</p>
<p>[<strong>IDirect3DDevice9:CheckDeviceFormat</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174309)</p>
<p>[<strong>IDirect3DDevice9:GetDeviceCaps</strong>](https://msdn.microsoft.com/library/windows/desktop/bb174320)</p>
<p>[<strong>IDirect3DDevice9:ValidateDevice</strong>](https://msdn.microsoft.com/library/windows/desktop/bb205859)</p></td>
<td align="left"><p>互換性ビットは機能レベルに置き換えられます。 特定の機能レベルでは、いくつかの形式と機能の使用のみオプションです。 これらは、[<strong>ID3D11Device::CheckFeatureSupport</strong>](https://msdn.microsoft.com/library/windows/desktop/ff476497) と [<strong>ID3D11Device::CheckFormatSupport</strong>](https://msdn.microsoft.com/library/windows/desktop/bb173536) を使用してチェックできます。</p></td>
</tr>
</tbody>
</table>

 

## サーフェス形式のマッピング


Direct3D 9 形式から DXGI 形式への変換を行う場合は、次の表を参考にしてください。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Direct3D 9 形式</th>
<th align="left">Direct3D 11 形式</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>D3DFMT_UNKNOWN</p></td>
<td align="left"><p>DXGI_FORMAT_UNKNOWN</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_R8G8B8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A8R8G8B8</p></td>
<td align="left"><p>DXGI_FORMAT_B8G8R8A8_UNORM</p>
<p>DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_X8R8G8B8</p></td>
<td align="left"><p>DXGI_FORMAT_B8G8R8X8_UNORM</p>
<p>DXGI_FORMAT_B8G8R8X8_UNORM_SRGB</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_R5G6B5</p></td>
<td align="left"><p>DXGI_FORMAT_B5G6R5_UNORM</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_X1R5G5B5</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A1R5G5B5</p></td>
<td align="left"><p>DXGI_FORMAT_B5G5R5A1_UNORM</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A4R4G4B4</p></td>
<td align="left"><p>DXGI_FORMAT_B4G4R4A4_UNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_R3G3B2</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A8</p></td>
<td align="left"><p>DXGI_FORMAT_A8_UNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A8R3G3B2</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_X4R4G4B4</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A2B10G10R10</p></td>
<td align="left"><p>DXGI_FORMAT_R10G10B10A2</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A8B8G8R8</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8B8A8_UNORM</p>
<p>DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_X8B8G8R8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_G16R16</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_UNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A2R10G10B10</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A16B16G16R16</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_UNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A8P8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_P8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_L8</p></td>
<td align="left"><p>DXGI_FORMAT_R8_UNORM</p>
<div class="alert">
<strong>注:</strong> Direct3D 9 の動作を得るには、シェーダーで .r スウィズルを使って赤を他の成分に複製します。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A8L8</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8_UNORM</p>
<div class="alert">
<strong>注:</strong> Direct3D 9 の動作を得るには、シェーダーでスウィズル .rrrg を使ってアルファ成分に赤を複製し、緑を移動します。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A4L4</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_V8U8</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8_SNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_L6V5U5</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_X8L8V8U8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_Q8W8V8U8</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8B8A8_SNORM</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_V16U16</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_SNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_W11V11U10</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A2W10V10U10</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_UYVY</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_R8G8_B8G8</p></td>
<td align="left"><p>DXGI_FORMAT_G8R8_G8B8_UNORM</p>
<div class="alert">
<strong>注:</strong> Direct3D 9 ではデータは 255.0f だけスケールアップされましたが、これはシェーダーで処理できます。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_YUY2</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_G8R8_G8B8</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8_B8G8_UNORM</p>
<div class="alert">
<strong>注:</strong> Direct3D 9 ではデータは 255.0f だけスケールアップされましたが、これはシェーダーで処理できます。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_DXT1</p></td>
<td align="left"><p>DXGI_FORMAT_BC1_UNORM と DXGI_FORMAT_BC1_UNORM_SRGB</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_DXT2</p></td>
<td align="left"><p>DXGI_FORMAT_BC1_UNORM と DXGI_FORMAT_BC1_UNORM_SRGB</p>
<div class="alert">
<strong>注:</strong> API とハードウェアの観点からは、DXT1 と DXT2 は同じです。 唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_DXT3</p></td>
<td align="left"><p>DXGI_FORMAT_BC2_UNORM と DXGI_FORMAT_BC2_UNORM_SRGB</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_DXT4</p></td>
<td align="left"><p>DXGI_FORMAT_BC2_UNORM と DXGI_FORMAT_BC2_UNORM_SRGB</p>
<div class="alert">
<strong>注:</strong> API とハードウェアの観点からは、DXT3 と DXT4 は同じです。 唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_DXT5</p></td>
<td align="left"><p>DXGI_FORMAT_BC3_UNORM と DXGI_FORMAT_BC3_UNORM_SRGB</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_D16 と D3DFMT_D16_LOCKABLE</p></td>
<td align="left"><p>DXGI_FORMAT_D16_UNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_D32</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_D15S1</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_D24S8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_D24X8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_D24X4S4</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_D16</p></td>
<td align="left"><p>DXGI_FORMAT_D16_UNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_D32F_LOCKABLE</p></td>
<td align="left"><p>DXGI_FORMAT_D32_FLOAT</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_D24FS8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_S1D15</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_S8D24</p></td>
<td align="left"><p>DXGI_FORMAT_D24_UNORM_S8_UINT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_X8D24</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_X4S4D24</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_L16</p></td>
<td align="left"><p>DXGI_FORMAT_R16_UNORM</p>
<div class="alert">
<strong>注:</strong> D3D9 の動作を得るには、シェーダーで .r スウィズルを使って赤を他の成分に複製します。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_INDEX16</p></td>
<td align="left"><p>DXGI_FORMAT_R16_UINT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_INDEX32</p></td>
<td align="left"><p>DXGI_FORMAT_R32_UINT</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_Q16W16V16U16</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_SNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_MULTI2_ARGB8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_R16F</p></td>
<td align="left"><p>DXGI_FORMAT_R16_FLOAT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_G16R16F</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_FLOAT</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A16B16G16R16F</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_FLOAT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_R32F</p></td>
<td align="left"><p>DXGI_FORMAT_R32_FLOAT</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_G32R32F</p></td>
<td align="left"><p>DXGI_FORMAT_R32G32_FLOAT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DFMT_A32B32G32R32F</p></td>
<td align="left"><p>DXGI_FORMAT_R32G32B32A32_FLOAT</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_CxV8U8</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_FLOAT1</p></td>
<td align="left"><p>DXGI_FORMAT_R32_FLOAT</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_FLOAT2</p></td>
<td align="left"><p>DXGI_FORMAT_R32G32_FLOAT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_FLOAT3</p></td>
<td align="left"><p>DXGI_FORMAT_R32G32B32_FLOAT</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_FLOAT4</p></td>
<td align="left"><p>DXGI_FORMAT_R32G32B32A32_FLOAT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPED3DCOLOR</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_UBYTE4</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8B8A8_UINT</p>
<div class="alert">
<strong>注:</strong> シェーダーは UINT 値を取得しますが、Direct3D 9 スタイルの integral float (0.0f、1.0f... 255.f) が必要な場合、UINT をシェーダーで float32 に変換できます。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_SHORT2</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_SINT</p>
<div class="alert">
<strong>注:</strong> シェーダーは SINT 値を取得しますが、Direct3D 9 スタイルの integral float が必要な場合、SINT をシェーダーで float32 に変換できます。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_SHORT4</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_SINT</p>
<div class="alert">
<strong>注:</strong> シェーダーは SINT 値を取得しますが、Direct3D 9 スタイルの integral float が必要な場合、SINT をシェーダーで float32 に変換できます。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_UBYTE4N</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8B8A8_UNORM</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_SHORT2N</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_SNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_SHORT4N</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_SNORM</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_USHORT2N</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_UNORM</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_USHORT4N</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_UNORM</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_UDEC3</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_DEC3N</p></td>
<td align="left"><p>使用できません</p></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_FLOAT16_2</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_FLOAT</p></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_FLOAT16_4</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_FLOAT</p></td>
</tr>
<tr class="even">
<td align="left"><p>FourCC 'ATI1'</p></td>
<td align="left"><p>DXGI_FORMAT_BC4_UNORM</p>
<div class="alert">
<strong>注:</strong> 機能レベル 10.0 以降が必要です。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>FourCC 'ATI2'</p></td>
<td align="left"><p>DXGI_FORMAT_BC5_UNORM</p>
<div class="alert">
<strong>注:</strong> 機能レベル 10.0 以降が必要です。
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

 

 






<!--HONumber=May16_HO2-->


