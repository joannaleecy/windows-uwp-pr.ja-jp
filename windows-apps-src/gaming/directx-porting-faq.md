---
author: mtoepke
title: "DirectX 11 の移植に関する FAQ"
description: "ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。"
ms.assetid: 79c3b4c0-86eb-5019-97bb-5feee5667a2d
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 908da9d15a49291f6a1c2467858b525c2f3dc7da

---

# DirectX 11 の移植に関する FAQ


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


ユニバーサル Windows プラットフォーム (UWP) へのゲームの移植についてよく寄せられる質問に対してお答えします。

## ゲームの移植作業は、API メソッドを検索して置き換える作業になりますか。それとも、より慎重な移植プロセスを計画する必要がありますか。


Direct3D 11 は Direct3D 9 からの大幅なアップグレードです。 仮想化されたグラフィックス アダプターとそのコンテキストのための独立した API や、デバイス リソースのポリモーフィズムの新しいレイヤーなど、いくつかのパラダイム シフトがあります。 ゲームでは、グラフィックス ハードウェアを実質的に同じ方法で使い続けることができますが、新しい Direct3D 11 API のアーキテクチャについて学び、正しい API コンポーネントが使われるようにグラフィックス コードの各部分を更新する必要があります。 「[DirectX 9 からの DirectX 11 と Windows ストアへの移行](porting-considerations.md)」をご覧ください。

## 新しいデバイス コンテキストの用途は何ですか。 自分の Direct3D 9 デバイスを Direct3D 11 デバイスに置き換えたり、Direct3D 9 デバイス コンテキストを Direct3D 11 デバイス コンテキストに置き換えたりする必要はありますか。その両方が必要でしょうか。


Direct3D デバイスは、ビデオ メモリにリソースを作成するために使われます。一方、デバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。 詳しくは、「[Direct3D 9 と Direct3D 11 の間の重要な変更点](understand-direct3d-11-1-concepts.md)」をご覧ください。

##  UWP 向けのゲーム タイマーを更新する必要はありますか。


[**QueryPerformanceCounter**](https://msdn.microsoft.com/library/windows/desktop/ms644904) と [**QueryPerformanceFrequency**](https://msdn.microsoft.com/library/windows/desktop/ms644905) は、引き続き UWP アプリのゲーム タイマーを実装する最適な手段です。

タイマーと UWP アプリのライフサイクルのニュアンスに注意する必要があります。 中断と再開は、プレーヤーによるデスクトップ ゲームの再起動とは異なります。ゲームでは、最後にプレイされていた時点のスナップショットを再開します。 数週間など、長時間経過した場合は、ゲーム タイマーの実装は適切に動作しない可能性があります。 ゲームの再開時にアプリのライフサイクル イベントを使ってタイマーをリセットできます。

まだ RDTSC 命令を使っているゲームはアップグレードする必要があります。 「[ゲームのタイミングとマルチコア プロセッサ](https://msdn.microsoft.com/library/windows/desktop/ee417693)」をご覧ください。

## 自分のゲーム コードは D3DX と DXUT に基づいています。 コードの移植に役立つものはありますか。


[DirectX ツール キット (DirectXTK)](http://go.microsoft.com/fwlink/p/?LinkID=248929) コミュニティのプロジェクトには、Direct3D 11 で利用できるヘルパー クラスが用意されています。

##  デスクトップと Windows ストアのコード パスを維持する方法を教えてください。


Chuck Walbourn 氏による[ゲームの二重用途のコーディング手法](http://go.microsoft.com/fwlink/p/?LinkID=286210)に関する記事シリーズで、デスクトップと Windows ストア コード パスの間でコードを共有する方法のガイダンスが提供されています。

##  DirectX UWP アプリの画像リソースを読み込む方法を教えてください。


画像を読み込むための API パスは 2 つあります。

-   コンテンツ パイプラインは Direct3D のテクスチャ リソースとして使われる DDS ファイルに画像を変換します。 「[ゲームまたはアプリケーションでの 3-D アセットの使用](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)」をご覧ください。
-   [Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902) を使うと、さまざまな形式から画像を読み込むことができます。このコンポーネントは、Direct2D ビットマップや、Direct3D のテクスチャ リソースに使用できます。

[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) または [DirectXTex](http://go.microsoft.com/fwlink/p/?LinkID=248926) の DDSTextureLoader と WICTextureLoader を使うこともできます。

## DirectX SDK の場所


DirectX SDK は Windows SDK に同梱されています。 Windows SDK に同梱されていない最新の DirectX SDK は、2010 年 6 月のものです。 Direct3D サンプルは、他の Windows アプリ サンプルと共にコード ギャラリーにあります。

## DirectX の再頒布可能パッケージについて教えてください。


Windows SDK の大半のコンポーネントは、サポートされているバージョンの OS に含まれていますが、DLL コンポーネントは含まれていません (DirectXMath など)。 UWP アプリで使うことができるすべての Direct3D API コンポーネントは、ゲームで既に使用できる状態です。再頒布する必要はありません。

Win32 デスクトップ アプリケーションは引き続き DirectSetup を使います。そのため、ゲームのデスクトップ バージョンをアップグレードする場合は、「[ゲーム開発者向けの Direct3D 11 の展開](https://msdn.microsoft.com/library/windows/desktop/ee416644)」をご覧ください。

## Effects から離れる前にデスクトップ コードを DirectX 11 に更新する方法はありますか。


[Direct3D 11 向けの Effects の更新に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=271568)をご覧ください。 Effects 11 は、レガシ DirectX SDK ヘッダーへの依存を排除します。移植のサポート用に作成されたものであり、デスクトップ アプリでのみ利用できます。

##  UWP に DirectX 8 ゲームを移植するためのパスはありますか。


はい、あります。

-   「[Direct3D 9 への変換](https://msdn.microsoft.com/library/windows/desktop/bb204851)」をご覧ください。
-   ゲームに固定パイプラインが残っていないことを確かめます。「[推奨されなくなった機能](https://msdn.microsoft.com/library/windows/desktop/cc308047)」をご覧ください。
-   次に、DirectX 9 移植パスに従います。「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」をご覧ください。

##  UWP に DirectX 10 または 11 ゲームを移植することはできますか。


DirectX 10.x と 11 のデスクトップ ゲームは、UWP に簡単に移植できます。 「[Direct3D 11 への移行](https://msdn.microsoft.com/library/windows/desktop/ff476190)」をご覧ください。

## マルチモニター システムで適切なディスプレイ デバイスを選ぶにはどうすればよいですか。


アプリを表示するモニターはユーザーが選びます。 最初のパラメーターを **nullptr** に設定して [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出すことで、Windows が正しいアダプターを提供できるようにしてください。 次にデバイスの [**IDXGIDevice interface**](https://msdn.microsoft.com/library/windows/desktop/bb174527) を取得し、[**GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) を呼び出して、DXGI アダプターを使ってスワップ チェーンを作成します。

## アンチエイリアシングをオンにするにはどうすればよいですか。


Direct3D デバイスを作成するとアンチエイリアシング (マルチサンプリング) が有効になります。 [**CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499) を呼び出してマルチサンプリングのサポートを列挙し、[**CreateSurface**](https://msdn.microsoft.com/library/windows/desktop/bb174530) を呼び出すときに [**DXGI\_SAMPLE\_DESC structure**](https://msdn.microsoft.com/library/windows/desktop/bb173072) でマルチサンプリングのオプションを設定します。

## 自分のゲームでは、マルチスレッドや遅延レンダリングを使ってレンダリングを行います。 Direct3D 11 向けに何を把握しておく必要がありますか。


まず、「[Direct3D 11 でのマルチスレッドの概要](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。 主な違いの一覧については、「[Direct3D のバージョン間におけるスレッドの違い](https://msdn.microsoft.com/library/windows/desktop/ff476890)」をご覧ください。 遅延レンダリングでは*イミディエイト コンテキスト*ではなくデバイスの*遅延コンテキスト*が使われることに注意してください。

## Direct3D 9 以降のプログラム可能なパイプラインに関する詳しい情報はどこにありますか。


次のトピックをご覧ください。

-   [HLSL 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/bb509635)
-   [Direct3D 10 のよく寄せられる質問](https://msdn.microsoft.com/library/windows/desktop/ee416643)

## モデルには .x ファイル形式の代わりに何を使えばよいですか。


.x ファイル形式に代わる公式のファイル形式はありませんが、サンプルの多くで SDKMesh 形式を利用しています。 Visual Studio には、一般的な形式を CMO ファイルにコンパイルする[コンテンツ パイプライン](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)があります。CMO ファイルは、Visual Studio 3D スターター キットのコードか、[DirectXTK](http://go.microsoft.com/fwlink/p/?LinkID=248929) を使って読み込むことができます。

## シェーダーをデバッグするにはどうしたらよいですか。


Microsoft Visual Studio 2015 には、DirectX グラフィックスの診断ツールが含まれています。 「[DirectX グラフィックスのデバッグ](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx)」をご覧ください。

##  *x* 関数に相当する Direct3D 11 の要素は何ですか。


「DirectX 11 API への DirectX 9 の機能のマッピング」の「[関数のマッピング](feature-mapping.md#function-mapping)」をご覧ください。

##  *y* サーフェス形式に相当する DXGI_FORMAT の要素は何ですか。


「DirectX 11 API への DirectX 9 の機能のマッピング」の「[サーフェス形式のマッピング](feature-mapping.md#surface-format-mapping)」をご覧ください。

 

 







<!--HONumber=Aug16_HO3-->


