---
title: DirectX 11 の移植に関する FAQ
description: ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。
ms.assetid: 79c3b4c0-86eb-5019-97bb-5feee5667a2d
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 11
ms.localizationpriority: medium
ms.openlocfilehash: 31c165d47beea8ee0e31a3213bdd0dbf0c2bc3d7
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8750110"
---
# <a name="directx-11-porting-faq"></a>DirectX 11 の移植に関する FAQ




ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。

## <a name="is-porting-my-game-going-to-be-a-set-of-search-and-replace-operations-on-api-methods-or-do-i-need-to-plan-for-a-more-thoughtful-porting-process"></a>ゲームの移植作業は、API メソッドを検索して置き換える作業になりますか。それとも、より慎重な移植プロセスを計画する必要がありますか。


Direct3D 11 は Direct3D 9 からの大幅なアップグレードです。 仮想化されたグラフィックス アダプターとそのコンテキストのための独立した API や、デバイス リソースのポリモーフィズムの新しいレイヤーなど、いくつかのパラダイム シフトがあります。 ゲームでは、グラフィックス ハードウェアを実質的に同じ方法で使い続けることができますが、新しい Direct3D 11 API のアーキテクチャについて学び、正しい API コンポーネントが使われるようにグラフィックス コードの各部分を更新する必要があります。 「[DirectX 9 からの DirectX 11 と Windows ストアへの移行](porting-considerations.md)」をご覧ください。

## <a name="what-is-the-new-device-context-for-am-i-supposed-to-replace-my-direct3d-9-device-with-the-direct3d-11-device-the-device-context-or-both"></a>新しいデバイス コンテキストの用途は何ですか。 自分の Direct3D 9 デバイスを Direct3D 11 デバイスに置き換えたり、Direct3D 9 デバイス コンテキストを Direct3D 11 デバイス コンテキストに置き換えたりする必要はありますか。その両方が必要でしょうか。


Direct3D デバイスは、ビデオ メモリにリソースを作成するために使われます。一方、デバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。 詳しくは、「[Direct3D 9 と Direct3D 11 の間の重要な変更点](understand-direct3d-11-1-concepts.md)」をご覧ください。

##  <a name="do-i-have-to-update-my-game-timer-for-uwp"></a>UWP 向けのゲーム タイマーを更新する必要はありますか。


[**QueryPerformanceCounter**](https://msdn.microsoft.com/library/windows/desktop/ms644904) と [**QueryPerformanceFrequency**](https://msdn.microsoft.com/library/windows/desktop/ms644905) は、引き続き UWP アプリのゲーム タイマーを実装する最適な手段です。

タイマーと UWP アプリのライフサイクルのニュアンスに注意する必要があります。 中断と再開は、プレーヤーによるデスクトップ ゲームの再起動とは異なります。ゲームでは、最後にプレイされていた時点のスナップショットを再開します。 数週間など、長時間経過した場合は、ゲーム タイマーの実装は適切に動作しない可能性があります。 ゲームの再開時にアプリのライフサイクル イベントを使ってタイマーをリセットできます。

まだ RDTSC 命令を使っているゲームはアップグレードする必要があります。 「[ゲームのタイミングとマルチコア プロセッサ](https://msdn.microsoft.com/library/windows/desktop/ee417693)」をご覧ください。

## <a name="my-game-code-is-based-on-d3dx-and-dxut-is-there-anything-available-that-can-help-me-migrate-my-code"></a>自分のゲーム コードは D3DX と DXUT に基づいています。 コードの移植に役立つものはありますか。


[DirectX ツール キット (DirectXTK)](http://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 で利用できるヘルパー クラスが用意されています。

##  <a name="how-do-i-maintain-code-paths-for-the-desktop-and-the-microsoft-store"></a>デスクトップと Microsoft Store のコード パスを維持する方法


Chuck Walbourn の記事シリーズで[ゲームの二重用途のコーディング手法](http://go.microsoft.com/fwlink/p/?LinkID=286210)では、デスクトップと Microsoft Store のコード パスの間でコードを共有に関するガイダンスを提供します。

##  <a name="how-do-i-load-image-resources-in-my-directx-uwp-app"></a>DirectX UWP アプリの画像リソースを読み込む方法を教えてください。


画像を読み込むための API パスは 2 つあります。

-   コンテンツ パイプラインは Direct3D のテクスチャ リソースとして使われる DDS ファイルに画像を変換します。 「[ゲームまたはアプリケーションでの 3-D アセットの使用](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)」をご覧ください。
-   [Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902) を使うと、さまざまな形式から画像を読み込むことができます。このコンポーネントは、Direct2D ビットマップや、Direct3D のテクスチャ リソースに使用できます。

[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) または [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926) の DDSTextureLoader と WICTextureLoader を使うこともできます。

## <a name="where-is-the-directx-sdk"></a>DirectX SDK の場所


DirectX SDK は Windows SDK に同梱されています。 Windows SDK に同梱されていない最新の DirectX SDK は、2010 年 6 月のものです。 Direct3D サンプルは、他の Windows アプリ サンプルと共にコード ギャラリーにあります。

## <a name="what-about-directx-redistributables"></a>DirectX の再頒布可能パッケージについて教えてください。


Windows SDK の大半のコンポーネントは、サポートされているバージョンの OS に含まれていますが、DLL コンポーネントは含まれていません (DirectXMath など)。 UWP アプリで使うことができるすべての Direct3D API コンポーネントは、ゲームで既に使用できる状態です。再頒布する必要はありません。

Win32 デスクトップ アプリケーションは引き続き DirectSetup を使います。そのため、ゲームのデスクトップ バージョンをアップグレードする場合は、「[ゲーム開発者向けの Direct3D 11 の展開](https://msdn.microsoft.com/library/windows/desktop/ee416644)」をご覧ください。

## <a name="is-there-any-way-i-can-update-my-desktop-code-to-directx-11-before-moving-away-from-effects"></a>Effects から離れる前にデスクトップ コードを DirectX 11 に更新する方法はありますか。


[Direct3D 11 向けの Effects の更新に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=271568)をご覧ください。 Effects 11 は、レガシ DirectX SDK ヘッダーへの依存を排除します。移植のサポート用に作成されたものであり、デスクトップ アプリでのみ利用できます。

##  <a name="is-there-a-path-for-porting-my-directx-8-game-to-uwp"></a>UWP に DirectX 8 ゲームを移植するためのパスはありますか。


はい、あります。

-   「[Direct3D 9 への変換](https://msdn.microsoft.com/library/windows/desktop/bb204851)」をご覧ください。
-   ゲームに固定パイプラインが残っていないことを確かめます。「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。
-   次に、DirectX 9 移植パスに従います。「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。

##  <a name="can-i-port-my-directx-10-or-11-game-to-uwp"></a>UWP に DirectX 10 または 11 ゲームを移植することはできますか。


DirectX 10.x と 11 のデスクトップ ゲームは、UWP に簡単に移植できます。 「[Direct3D 11 への移行](https://msdn.microsoft.com/library/windows/desktop/ff476190)」をご覧ください。

## <a name="how-do-i-choose-the-right-display-device-in-a-multi-monitor-system"></a>マルチモニター システムで適切なディスプレイ デバイスを選ぶにはどうすればよいですか。


アプリを表示するモニターはユーザーが選びます。 最初のパラメーターを **nullptr** に設定して [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出すことで、Windows が正しいアダプターを提供できるようにしてください。 次にデバイスの [**IDXGIDevice interface**](https://msdn.microsoft.com/library/windows/desktop/bb174527) を取得し、[**GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) を呼び出して、DXGI アダプターを使ってスワップ チェーンを作成します。

## <a name="how-do-i-turn-on-antialiasing"></a>アンチエイリアシングをオンにするにはどうすればよいですか。


Direct3D デバイスを作成するとアンチエイリアシング (マルチサンプリング) が有効になります。 [**CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499) を呼び出してマルチサンプリングのサポートを列挙し、[**CreateSurface**](https://msdn.microsoft.com/library/windows/desktop/bb174530) を呼び出すときに [**DXGI\_SAMPLE\_DESC structure**](https://msdn.microsoft.com/library/windows/desktop/bb173072) でマルチサンプリングのオプションを設定します。

## <a name="my-game-renders-using-multithreading-andor-deferred-rendering-what-do-i-need-to-know-for-direct3d-11"></a>自分のゲームでは、マルチスレッドや遅延レンダリングを使ってレンダリングを行います。 Direct3D 11 向けに何を把握しておく必要がありますか。


まず、「[Direct3D 11 でのマルチスレッドの概要](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。 主な違いの一覧については、「[Direct3D のバージョン間におけるスレッドの違い](https://msdn.microsoft.com/library/windows/desktop/ff476890)」をご覧ください。 遅延レンダリングでは*イミディエイト コンテキスト*ではなくデバイスの*遅延コンテキスト*が使われることに注意してください。

## <a name="where-can-i-read-more-about-the-programmable-pipeline-since-direct3d-9"></a>Direct3D 9 以降のプログラム可能なパイプラインに関する詳しい情報はどこにありますか。


次のトピックをご覧ください。

-   [HLSL 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/bb509635)
-   [Direct3D 10 のよく寄せられる質問](https://msdn.microsoft.com/library/windows/desktop/ee416643)

## <a name="what-should-i-use-instead-of-the-x-file-format-for-my-models"></a>モデルには .x ファイル形式の代わりに何を使えばよいですか。


.x ファイル形式に代わる公式のファイル形式はありませんが、サンプルの多くで SDKMesh 形式を利用しています。 Visual Studio には、一般的な形式を CMO ファイルにコンパイルする[コンテンツ パイプライン](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)があります。CMO ファイルは、Visual Studio 3D スターター キットのコードか、[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) を使って読み込むことができます。

## <a name="how-do-i-debug-my-shaders"></a>シェーダーをデバッグするにはどうしたらよいですか。


Microsoft Visual Studio2015 には、DirectX グラフィックスの診断ツールが含まれています。 「[DirectX グラフィックスのデバッグ](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx)」をご覧ください。

##  <a name="what-is-the-direct3d-11-equivalent-for-x-function"></a>*x* 関数に相当する Direct3D 11 の要素は何ですか。


「DirectX 11 API への DirectX 9 の機能のマッピング」の「[関数のマッピング](feature-mapping.md#function-mapping)」をご覧ください。

##  <a name="what-is-the-dxgiformat-equivalent-of-y-surface-format"></a>*y* サーフェス形式に相当する DXGI_FORMAT の要素は何ですか。


「DirectX 11 API への DirectX 9 の機能のマッピング」の「[サーフェス形式のマッピング](feature-mapping.md#surface-format-mapping)」をご覧ください。

 

 




