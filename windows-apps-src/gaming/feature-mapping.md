---
author: mtoepke
title: DirectX 11 API への DirectX 9 の機能のマッピング
description: Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。
ms.assetid: 3aa8a114-4e47-ae0a-9447-88ba324377b8
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 9, DirectX 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 8dcf1749f1e7db4d514466d6a753d6f8cace5713
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5555522"
---
# <a name="map-directx-9-features-to-directx-11-apis"></a>DirectX 11 API への DirectX 9 の機能のマッピング



**概要**

-   [DirectX の移植の計画](plan-your-directx-port.md)
-   [Direct3D 9 と Direct3D 11 の間の重要な変更点](understand-direct3d-11-1-concepts.md)
-   機能のマッピング


Direct3D 9 ゲームで使う機能が Direct3D 11 とユニバーサル Windows プラットフォーム (UWP) にどのように変換されるかについて説明します。

## <a name="mapping-direct3d-9-to-directx-11-apis"></a>DirectX 11 API への Direct3D 9 のマッピング


[Direct3D](https://msdn.microsoft.com/library/windows/desktop/hh309466) はこれまでと同じく DirectX グラフィックスの土台ですが、API は DirectX 9 以降変更されています。

-   Microsoft DirectX Graphic Infrastructure (DXGI) はグラフィックス アダプターを設定するために使われます。 バッファー形式の選択、スワップ チェーンの作成、フレームの表示、共有リソースの作成には [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534) を使います。 「[DXGI の概要](https://msdn.microsoft.com/library/windows/desktop/bb205075)」をご覧ください。
-   Direct3D のデバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。 ほとんどのサンプルではイミディエイト コンテキストを使ってデバイスに直接レンダリングしていますが、Direct3D 11 ではマルチスレッド レンダリングもサポートされており、その場合は遅延コンテキストが使われます。 「[Direct3D 11 のデバイスについて](https://msdn.microsoft.com/library/windows/desktop/ff476880)」をご覧ください。
-   一部の機能は非推奨になっていますが、特に固定関数パイプラインが推奨されなくなりました。 「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。

Direct3D 11 の機能の完全な一覧については、「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/ff476342)」と「[Direct3D 11 の機能](https://msdn.microsoft.com/library/windows/desktop/hh404562)」をご覧ください。

## <a name="moving-from-direct2d-9-to-direct2d-11"></a>Direct2D 9 から Direct2D 11 への移行


[Direct2D (Windows)](https://msdn.microsoft.com/library/windows/desktop/dd370990) は、これまでどおり DirectX グラフィックスと Windows の重要な一部です。 これまでどおり Direct2D を使って 2D ゲームを描画したり、Direct3D の上にオーバーレイ (HUD) を描画したりできます。

Direct2D は Direct3D の上で実行されます。2D ゲームは API を使って実装できます。 たとえば、Direct3D を使って実装される 2D ゲームでは、正投影を使ったり、Z 値を設定してプリミティブの描画の順序を制御したり、ピクセル シェーダーを使って特殊効果を追加したりできます。

Direct2D は Direct3D に基づいているため、DXGI とデバイス コンテキストも使います。 「[Direct2D API の概要](https://msdn.microsoft.com/library/windows/desktop/dd317121)」をご覧ください。

[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) API は、Direct2D を使って書式付きテキストのサポートを追加します。 「[DirectWrite の紹介](https://msdn.microsoft.com/library/windows/desktop/dd371554)」をご覧ください。

## <a name="replace-deprecated-helper-libraries"></a>推奨されなくなったヘルパー ライブラリの置き換え


D3DX と DXUT は推奨されなくなったため、UWP ゲームでは使うことができません。 これらのヘルパー ライブラリでは、テクスチャの読み込みやメッシュの読み込みなどのタスク用にリソースが提供されていました。

-   「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」では、ウィンドウの設定、Direct3D の初期化、基本的な 3D レンダリングの方法を示します。
-   「[DirectX を使った単純なユニバーサル Windows プラットフォーム (UWP) ゲームの作成](tutorial--create-your-first-uwp-directx-game.md)」では、グラフィックス、ファイルの読み込み、UI、コントロール、サウンドなど、一般的なゲーム プログラミング タスクを示します。
-   [DirectX ツール キット](http://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 および UWP アプリで利用できるヘルパー クラスが用意されています。

## <a name="move-shader-programs-from-fx-to-hlsl"></a>FX から HLSL へのシェーダー プログラムの移行


Effects を含め、D3DX ユーティリティ ライブラリ (D3DX 9、D3DX 10、D3DX 11) は、UWP では推奨されなくなりました。 UWP のすべての DirectX ゲームは、Effects を使わずに、[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561) を使ってグラフィックス パイプラインを実行します。

Visual Studio は、シェーダー オブジェクトをコンパイルするために FXC をバックグラウンドで使います。 UWP ゲームのシェーダーは事前にコンパイルされます。 バイトコードは実行時に読み込まれ、各シェーダー リソースは適切なレンダリング パスの間にグラフィックス パイプラインにバインドされます。 シェーダーを独自の別の .HLSL ファイルに移し、レンダリング テクノロジを C++ コードで実装する必要があります。

シェーダー リソースの読み込みの概要については、「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。

Direct3D 11 ではシェーダー モデル 5 が導入されましたが、これには Direct3D 機能レベル 11\_0 以上が必要です。 「[Direct3D 11 の HLSL シェーダー モデル 5 の機能](https://msdn.microsoft.com/library/windows/desktop/ff471419)」をご覧ください。

## <a name="replace-xnamath-and-d3dxmath"></a>XNAMath と D3DXMath の置き換え


XNAMath (または D3DXMath) を使ったコードは [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) に移行する必要があります。 DirectXMath には、x86、x64、ARM の間で移植可能な型が含まれています。 「[XNA Math ライブラリからのコードの移行](https://msdn.microsoft.com/library/windows/desktop/ee418730)」をご覧ください。

DirectXMath の浮動小数点型はシェーダーで使うと便利です。 たとえば、[**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) と [**XMFLOAT4X4**](https://msdn.microsoft.com/library/windows/desktop/ee419621) は、定数バッファーのデータの整列に便利です。

## <a name="replace-directsound-with-xaudio2-and-background-audio"></a>XAudio2 (とバックグラウンド オーディオ) への DirectSound の置き換え


DirectSound では、UWP はサポートされていません。

-   ゲームにサウンド効果を追加するには [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使います。

##  <a name="replace-directinput-with-xinput-and-uwp-apis"></a>XInput と UWP API への DirectInput の置き換え


DirectInput では、UWP はサポートされていません。

-   マウス、キーボード、タッチ入力には [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の入力イベント コールバックを使います。
-   ゲーム コントローラーのサポート (とゲーム コントローラーのヘッドセットのサポート) には [XInput](https://msdn.microsoft.com/library/windows/desktop/ee417001) 1.4 を使います。 デスクトップと UWP に共有コード ベースを使う場合は、下位互換性について、「[XInput のバージョン](https://msdn.microsoft.com/library/windows/desktop/hh405051)」をご覧ください。
-   ゲームでアプリ バーを使う必要がある場合は、[**EdgeGesture**](https://msdn.microsoft.com/library/windows/apps/hh701600) イベントに登録します。

## <a name="use-microsoft-media-foundation-instead-of-directshow"></a>DirectShow の代わりに Microsoft メディア ファンデーションを使う


DirectShow は DirectX API (または Windows API) にはもう含まれていません。 [Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197)は共有サーフェイスを使って Direct3D にビデオ コンテンツを提供します。 「[Direct3D 11 のビデオ API](https://msdn.microsoft.com/library/windows/desktop/hh447677)」をご覧ください。

## <a name="replace-directplay-with-networking-code"></a>ネットワーク コードへの DirectPlay の置き換え


Microsoft DirectPlay は推奨されなくなりました。 ゲームでネットワーク サービスを使う場合は、UWP の要件に準拠しているネットワーク コードを提供する必要があります。 次の API を使います。

-   [UWP アプリの Win32 と COM (ネットワーク) (Windows)](https://msdn.microsoft.com/library/windows/apps/br205759)
-   [**Windows.Networking 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br207124)
-   [**Windows.Networking.Sockets 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br226960)
-   [**Windows.Networking.Connectivity 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br207308)
-   [**Windows.ApplicationModel.Background 名前空間 (Windows)**](https://msdn.microsoft.com/library/windows/apps/br224847)

次の記事は、ネットワーク機能を追加し、アプリのパッケージ マニフェストでネットワークのサポートを宣言するうえで役立ちます。

-   [ソケットを使った接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)](https://msdn.microsoft.com/library/windows/apps/xaml/hh452976)
-   [WebSocket を使った接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)](https://msdn.microsoft.com/library/windows/apps/xaml/hh994396)
-   [Web サービスへの接続 (C#/VB/C++ と XAML を使った UWP アプリ) (Windows)](https://msdn.microsoft.com/library/windows/apps/xaml/hh761504)
-   [ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)

アプリの中断中は、すべての UWP アプリ (ゲームを含む) で特定の種類のバックグラウンド タスクを使って接続を維持します。 中断されている間、ゲームが接続状態を保存する必要がある場合は、「[ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)」をご覧ください。

## <a name="function-mapping"></a>関数のマッピング


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
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174336">IDirect3DDevice9</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280493">ID3D11Device2</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280498">ID3D11DeviceContext2</a></p>
<p>グラフィックス パイプラインのステージについては、「<a href="https://msdn.microsoft.com/library/windows/desktop/ff476882">グラフィックス パイプライン</a>」で説明されています。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174300">IDirect3D9</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404556">IDXGIFactory2</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404537">IDXGIAdapter2</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/dn280345">IDXGIDevice3</a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174423">IDirect3DDevice9::Present</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174472">IDirect3DDevice9::TestCooperativeLevel</a></p></td>
<td align="left"><p>DXGI_PRESENT_TEST フラグを設定して <a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> を呼び出します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174322">IDirect3DBaseTexture9</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205909">IDirect3DTexture9</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174329">IDirect3DCubeTexture9</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205941">IDirect3DVolumeTexture9</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205865">IDirect3DIndexBuffer9</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205915">IDirect3DVertexBuffer9</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476351">ID3D11Buffer</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476633">ID3D11Texture1D</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476635">ID3D11Texture2D</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476637">ID3D11Texture3D</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476628">ID3D11ShaderResourceView</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476582">ID3D11RenderTargetView</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476377">ID3D11DepthStencilView</a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205922">IDirect3DVertexShader9</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205869">IDirect3DPixelShader9</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476641">ID3D11VertexShader</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476576">ID3D11PixelShader</a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205919">IDirect3DVertexDeclaration9</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476575">ID3D11InputLayout</a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205805">IDirect3DDevice9::SetRenderState</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205806">IDirect3DDevice9::SetSamplerState</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/hh404571">ID3D11BlendState1</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476375">ID3D11DepthStencilState</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/hh446828">ID3D11RasterizerState1</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476588">ID3D11SamplerState</a></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174369">IDirect3DDevice9::DrawIndexedPrimitive</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174371">IDirect3DDevice9::DrawPrimitive</a></p></td>
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476407">ID3D11DeviceContext::Draw</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476409">ID3D11DeviceContext::DrawIndexed</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173566">ID3D11DeviceContext::DrawIndexedInstanced</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173567">ID3D11DeviceContext::DrawInstanced</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173590">ID3D11DeviceContext::IASetPrimitiveTopology</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb173564">ID3D11DeviceContext::DrawAuto</a></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174350">IDirect3DDevice9::BeginScene</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174375">IDirect3DDevice9::EndScene</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174372">IDirect3DDevice9::DrawPrimitiveUP</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174370">IDirect3DDevice9::DrawIndexedPrimitiveUP</a></p></td>
<td align="left"><p>直接相当する要素はなし</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174470">IDirect3DDevice9::ShowCursor</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174429">IDirect3DDevice9::SetCursorPosition</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174430">IDirect3DDevice9::SetCursorProperties</a></p></td>
<td align="left"><p>標準的なカーソル API を使います。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174425">IDirect3DDevice9::Reset</a></p></td>
<td align="left"><p>LOST デバイスと POOL_MANAGED はもう存在しません。 <a href="https://msdn.microsoft.com/library/windows/desktop/hh446797">IDXGISwapChain1::Present1</a> は戻り値 <a href="https://msdn.microsoft.com/library/windows/desktop/bb509553">DXGI_ERROR_DEVICE_REMOVED</a> で失敗する可能性があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174373">IDirect3DDevice9:DrawRectPatch</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174374">IDirect3DDevice9:DrawTriPatch</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174421">IDirect3DDevice9:LightEnable</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174422">IDirect3DDevice9:MultiplyTransform</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205798">IDirect3DDevice9:SetLight</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174437">IDirect3DDevice9:SetMaterial</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174438">IDirect3DDevice9:SetNPatchMode</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174463">IDirect3DDevice9:SetTransform</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174433">IDirect3DDevice9:SetFVF</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174462">IDirect3DDevice9:SetTextureStageState</a></p></td>
<td align="left"><p>固定関数パイプラインは推奨されなくなりました。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174308">IDirect3DDevice9:CheckDepthStencilMatch</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174309">IDirect3DDevice9:CheckDeviceFormat</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb174320">IDirect3DDevice9:GetDeviceCaps</a></p>
<p><a href="https://msdn.microsoft.com/library/windows/desktop/bb205859">IDirect3DDevice9:ValidateDevice</a></p></td>
<td align="left"><p>互換性ビットは機能レベルに置き換えられます。 特定の機能レベルでは、いくつかの形式と機能の使用のみオプションです。 これは <a href="https://msdn.microsoft.com/library/windows/desktop/ff476497">ID3D11Device::CheckFeatureSupport</a> と <a href="https://msdn.microsoft.com/library/windows/desktop/bb173536">ID3D11Device::CheckFormatSupport</a> でチェックできます。</p></td>
</tr>
</tbody>
</table>

 

## <a name="surface-format-mapping"></a>サーフェス形式のマッピング


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
<strong>注:</strong>  direct3d9 の動作を取得するのには、その他のコンポーネントを赤を複製するシェーダーで .r スウィズルを使用します。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p>D3DFMT_A8L8</p></td>
<td align="left"><p>DXGI_FORMAT_R8G8_UNORM</p>
<div class="alert">
<strong>注:</strong> 赤を複製し、direct3d9 の動作を取得するアルファ成分を緑を移動するシェーダーでスウィズル .rrrg を使用します。
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
<strong>注:</strong>  direct3d9 でのデータは 255.0f、スケール アップが、これは、シェーダーで処理できます。
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
<strong>注:</strong>  direct3d9 でのデータは 255.0f、スケール アップが、これは、シェーダーで処理できます。
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
<strong>注:</strong>  DXT1 と DXT2 API とハードウェアの観点から同じです。 唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。
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
<strong>注:</strong>  DXT3 と DXT4 API とハードウェアの観点から同じです。 唯一の違いは、プリマルチプライ済みアルファが使われるかどうかです。これはアプリケーションで追跡でき、別の形式は必要ありません。
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
<strong>注:</strong>  D3D9 の動作を取得するには、その他のコンポーネントを赤を複製するシェーダーで .r スウィズルを使用します。
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
<strong>注:</strong> シェーダーは UINT 値を取得しますが、浮動小数点値が必要な場合は、direct3d9 スタイル (0.0 f、1.0 f.255.f)、UINT をシェーダーで float32 に変換できます。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>D3DDECLTYPE_SHORT2</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16_SINT</p>
<div class="alert">
<strong>注:</strong> シェーダーは SINT 値を取得しますが、だけ SINT をシェーダーで float32 に変換する direct3d9 スタイルの integral が必要な場合です。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p>D3DDECLTYPE_SHORT4</p></td>
<td align="left"><p>DXGI_FORMAT_R16G16B16A16_SINT</p>
<div class="alert">
<strong>注:</strong> シェーダーは SINT 値を取得しますが、だけ SINT をシェーダーで float32 に変換する direct3d9 スタイルの integral が必要な場合です。
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
<strong>注:</strong> 機能レベル 10.0 以降が必要です
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>FourCC 'ATI2'</p></td>
<td align="left"><p>DXGI_FORMAT_BC5_UNORM</p>
<div class="alert">
<strong>注:</strong> 機能レベル 10.0 以降が必要です
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

 

 




