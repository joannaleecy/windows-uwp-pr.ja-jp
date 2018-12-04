---
title: OpenGL ES 2.0 から Direct3D への移植の計画
description: iOS または Android プラットフォームからゲームを移植している場合、OpenGL ES 2.0 に多大な投資を行ってこられたものと思われます。
ms.assetid: a31b8c5a-5577-4142-fc60-53217302ec3a
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、OpenGL、Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: b17f18876ebc2faead08d8c777c7502e937aef86
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8470524"
---
# <a name="plan-your-port-from-opengl-es-20-to-direct3d"></a>OpenGL ES 2.0 から Direct3D への移植の計画




**重要な API**

-   [Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476080)
-   [Visual C++](https://msdn.microsoft.com/library/windows/apps/60k1461a.aspx)

iOS または Android プラットフォームからゲームを移植している場合、OpenGL ES 2.0 に多大な投資を行ってこられたものと思われます。 グラフィックス パイプラインのコードベースを Direct3D 11 と Windows ランタイムに移す準備をしているときは、開始する前に何点か注意してください。

ほとんどの移植作業では、通常、最初にコードベースを調べて、2 つのモデル間で共通する API とパターンをマップします。 このトピックを読んで内容を確かめれば、このプロセスが少し楽になるはずです。

OpenGL ES 2.0 から Direct3D 11 にグラフィックスを移植する際に注意する必要のある事柄を次に示します。

## <a name="notes-on-specific-opengl-es-20-providers"></a>特定の OpenGL ES 2.0 プロバイダーに関する注意事項


このセクションの移植に関するトピックでは、Khronos Group によって作成された OpenGL ES 2.0 仕様の Windows 実装を参照します。 OpenGL ES 2.0 コード サンプルは、いずれも Visual Studio 2012 と基本的な Windows C 構文を使って開発されたものです。 Objective-C (iOS) または Java (Android) コードベースから移植する場合は、用意されている OpenGL ES 2.0 コード サンプルで、類似の API 呼び出し構文またはパラメーターが使われていない可能性があることに注意してください。 このガイダンスでは、できるだけプラットフォームにとらわれずに説明します。

このドキュメントでは、OpenGL ES のコードと参照に 2.0 仕様の API のみを使います。 OpenGL ES 1.1 または 3.0 から移植する場合もこのコンテンツは有用ですが、OpenGL ES 2.0 のコード例とコンテキストの一部に馴染みがない可能性があります。

これらのトピックの Direct3D 11 のサンプルでは、Microsoft Windows C++ とコンポーネント拡張 (CX) を使います。 このバージョンの C++ の構文について詳しくは、「[Visual C++](https://msdn.microsoft.com/library/windows/apps/60k1461a.aspx)」、「[ランタイム プラットフォーム向けのコンポーネント拡張](https://msdn.microsoft.com/library/windows/apps/xey702bw.aspx)」、「[クイック リファレンス (C++\\CX)](https://msdn.microsoft.com/library/windows/apps/br212455.aspx)」をご覧ください。

## <a name="understand-your-hardware-requirements-and-resources"></a>ハードウェア要件とリソースについて


OpenGL ES 2.0 でサポートされる一連のグラフィックス処理機能は、Direct3D 9.1 で提供される機能にほぼ対応しています。 Direct3D 11 で提供される高度な機能を利用する場合は、移植の計画段階では [Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476080) のドキュメントを、最初の作業を終えた段階では「[DirectX 9 からユニバーサル Windows プラットフォーム (UWP) への移植](porting-your-directx-9-game-to-windows-store.md)」のトピックをご覧ください。

初期移植作業を簡単にするには、Visual Studio の Direct3D テンプレートを利用してください。 基本的なレンダラーが既に構成されており、ウィンドウの変更と Direct3D 機能レベルに関するリソースの再作成などの UWP アプリ機能がサポートされています。

## <a name="understand-direct3d-feature-levels"></a>Direct3D の機能レベルについて


Direct3D 11 は、9\_1 (Direct3D 9.1) から 11\_1 のハードウェア "機能レベル" をサポートしています。 これらの機能レベルは、特定のグラフィックス機能とリソースの可用性を示します。 通常、ほとんどの OpenGL ES 2.0 プラットフォームで Direct3D 9.1 (機能レベル 9\_1) の機能セットがサポートされています。

## <a name="review-directx-graphics-features-and-apis"></a>DirectX のグラフィックス機能と API の確認


| API ファミリ                                                | 説明                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|-----------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [DXGI](https://msdn.microsoft.com/library/windows/desktop/hh404534)                     | DirectX Graphic Infrastructure (DXGI) は、グラフィックス ハードウェアと Direct3D の間のインターフェイスを提供します。 これは [**IDXGIAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174523) と [**IDXGIDevice1**](https://msdn.microsoft.com/library/windows/desktop/hh404543) の COM インターフェイスを使ってデバイス アダプターとハードウェア構成を設定します。 バッファーなどのウィンドウ リソースを作成および構成する場合に使います。 特に、[**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556) ファクトリ パターンは、スワップ チェーン (フレーム バッファーのセット) などのグラフィックス リソースを取得するために使われます。 DXGI がスワップ チェーンを所有するため、画面にフレームを表示するために [**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) インターフェイスが使われます。 |
| [Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff476080)       | Direct3D は API のセットであり、グラフィックス インターフェイスの仮想表示を提供し、それを使ってグラフィックスを描画できるようにします。 バージョン 11 は、機能的に OpenGL 4.3 とほぼ同等です  (一方、OpenGL ES 2.0 は機能的に DirectX9 および OpenGL 2.0 と似ていますが、OpenGL 3.0 の統合シェーダー パイプラインがあります)。重要な作業の大半は、個々のリソースとサブリソースへのアクセスを提供する ID3D11Device1 インターフェイスと、レンダリング コンテキストを提供する ID3D11DeviceContext1 インターフェイスで行われます。                                                                                                                                          |
| [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990)                      | Direct2D は、GPU アクセラレーションが活用された 2D レンダリング用の API のセットです。 用途は OpenVG と似ています。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038)            | DirectWrite は、GPU アクセラレーションが活用された高品質なフォント レンダリング用の API のセットです。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833)                  | DirectXMath は、一般的な線形代数と三角法の種類、値、関数を処理するための API とマクロのセットを提供します。 これらの型と関数は、Direct3D とそのシェーダーの操作に対応しています。                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| [DirectX HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509580) | Direct3D シェーダーで使われる現在の HLSL 構文です。 Direct3D Shader Model 5.0 を実装します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |

 

## <a name="review-the-windows-runtime-apis-and-template-library"></a>Windows ランタイム API とテンプレート ライブラリの確認


Windows ランタイム API は、UWP アプリの全体的なインフラストラクチャを提供します。 詳しくは、[ここ](https://msdn.microsoft.com/library/windows/apps/br211377) をご覧ください。

グラフィックス パイプラインの移植で使われる主要な Windows ランタイム API は次のとおりです。

-   [**Windows::UI::Core::CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225)
-   [**Windows::UI::Core::CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211)
-   [**Windows::ApplicationModel::Core::IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478)
-   [**Windows::ApplicationModel::Core::CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017)

また、Windows ランタイム C++ テンプレート ライブラリ (WRL) は、Windows ランタイム コンポーネントを作成して使うための下位レベルの方法を提供するテンプレート ライブラリです。 UWP アプリ用の Direct3D 11 API は、スマート ポインター ([ComPtr](https://msdn.microsoft.com/library/windows/apps/br244983.aspx)) など、このライブラリ内のインターフェイスおよび型と組み合わせたときに最適に動作します。 WRL について詳しくは、「[Windows ランタイム C++ テンプレート ライブラリ (WRL)](https://msdn.microsoft.com/library/windows/apps/hh438466.aspx)」をご覧ください。

## <a name="change-your-coordinate-system"></a>座標系の変更


ときとして初期移植作業に混乱を招く違いは、OpenGL の従来の右手による座標系から Direct3D の既定の左手による座標系への変更です。 座標モデルにおけるこの変更は、頂点バッファーの設定と構成から、マトリックスの数学関数の多くに至るまで、ゲームの多くの部分に影響します。 2 つの最も重要な変更は次のとおりです。

-   三角形の頂点の順序を逆にし、Direct3D が前から時計回りにそれらをスキャンするようにします。 たとえば、頂点のインデックスが OpenGL パイプラインで 0、1、2 のとき、Direct3D に 0、2、1 として渡します。
-   効果的に z 軸座標を反転させるために、ビュー マトリックスを使って z 方向に -1.0f だけワールド空間を拡大します。 そのためには、ビュー マトリックスの位置 M31、M32、M33 にある値の符号を逆にします ([**Matrix**](https://msdn.microsoft.com/library/windows/desktop/bb147180) 型に移植するとき)。 M34 が 0 でない場合は、その符号を同様に逆にします。

ただし、Direct3D は右手による座標系をサポートできます。 DirectXMath は、左手による座標系と右手による座標系を操作するさまざまな関数を提供します。 元のメッシュ データおよびマトリックスの処理の一部を維持するために使うことができます。 これには次のものがあります。

| DirectXMath のマトリックス関数                                                   | 説明                                                                                                                 |
|-------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------|
| [**XMMatrixLookAtLH**](https://msdn.microsoft.com/library/windows/desktop/ee419969)                               | カメラの位置、上方向、焦点を使って、左手による座標系のビュー マトリックスを作成します。       |
| [**XMMatrixLookAtRH**](https://msdn.microsoft.com/library/windows/desktop/ee419970)                               | カメラの位置、上方向、焦点を使って、右手による座標系のビュー マトリックスを作成します。      |
| [**XMMatrixLookToLH**](https://msdn.microsoft.com/library/windows/desktop/ee419971)                               | カメラの位置、上方向、カメラの向きを使って、左手による座標系のビュー マトリックスを作成します。  |
| [**XMMatrixLookToRH**](https://msdn.microsoft.com/library/windows/desktop/ee419972)                               | カメラの位置、上方向、カメラの向きを使って、右手による座標系のビュー マトリックスを作成します。 |
| [**XMMatrixOrthographicLH**](https://msdn.microsoft.com/library/windows/desktop/ee419975)                   | 左手による座標系の正投影マトリックスを作成します。                                                 |
| [**XMMatrixOrthographicOffCenterLH**](https://msdn.microsoft.com/library/windows/desktop/ee419976) | 左手による座標系のカスタム正投影マトリックスを作成します。                                           |
| [**XMMatrixOrthographicOffCenterRH**](https://msdn.microsoft.com/library/windows/desktop/ee419977) | 右手による座標系のカスタム正投影マトリックスを作成します。                                          |
| [**XMMatrixOrthographicRH**](https://msdn.microsoft.com/library/windows/desktop/ee419978)                   | 右手による座標系の正投影マトリックスを作成します。                                                |
| [**XMMatrixPerspectiveFovLH**](https://msdn.microsoft.com/library/windows/desktop/ee419979)               | 視野に基づいて左手による遠近投影マトリックスを作成します。                                                |
| [**XMMatrixPerspectiveFovRH**](https://msdn.microsoft.com/library/windows/desktop/ee419980)               | 視野に基づいて右手による遠近投影マトリックスを作成します。                                               |
| [**XMMatrixPerspectiveLH**](https://msdn.microsoft.com/library/windows/desktop/ee419981)                     | 左手による遠近投影マトリックスを作成します。                                                                         |
| [**XMMatrixPerspectiveOffCenterLH**](https://msdn.microsoft.com/library/windows/desktop/ee419982)   | 左手による遠近投影マトリックスのカスタム バージョンを作成します。                                                     |
| [**XMMatrixPerspectiveOffCenterRH**](https://msdn.microsoft.com/library/windows/desktop/ee419983)   | 右手による遠近投影マトリックスのカスタム バージョンを作成します。                                                    |
| [**XMMatrixPerspectiveRH**](https://msdn.microsoft.com/library/windows/desktop/ee419984)                     | 右手による遠近投影マトリックスを作成します。                                                                        |

 

## <a name="opengl-es20-to-direct3d-11-porting-frequently-asked-questions"></a>OpenGL ES2.0 から Direct3D 11 への移植についてよく寄せられる質問


-   質問: "通常、自分の OpenGL コードで特定の文字列やパターンを検索し、それを対応する Direct3D の要素と置き換えることはできますか"
-   回答: いいえ。 OpenGL ES 2.0 と Direct3D 11 は、グラフィックス パイプライン モデルの異なる世代に基づいています。 レンダリング コンテキストやシェーダーのインスタンス化など、概念と API の間に表面的な類似点はありますが、このガイダンスと Direct3D 11 のリファレンスを調べて、1 対 1 のマッピングを試みる代わりに、パイプラインを再作成するときに最適な選択ができるようにしてください。 ただし、GLSL から HLSL に移植する場合、GLSL の変数、組み込みメソッド、関数の一連の共通エイリアスを作成すると、移植が容易になるだけでなく、1 ペアのシェーダー コード ファイルだけを維持することができます。

 

 




