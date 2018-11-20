---
author: mtoepke
title: ユニバーサル Windows プラットフォーム (UWP) アプリのゲーム テクノロジ
description: このガイドでは、ユニバーサル Windows プラットフォーム UWP ゲームの開発に利用できるテクノロジについて説明します。
ms.assetid: bc4d4648-0d6e-efbb-7608-80bd09decd6e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, テクノロジ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: c6896bda0498483efb4d77e1fa2a6ef82e0f8789
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7422326"
---
# <a name="game-technologies-for-uwp-apps"></a>UWP アプリのゲーム テクノロジ



このガイドでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発に利用できるテクノロジについて説明します。

##  <a name="benefits-of-windows10-for-game-development"></a>ゲーム開発向けの windows 10 のメリット


Windows 10 で UWP の導入により、windows 10 のタイトルはすべての Microsoft プラットフォームに対応することになります。 以前のバージョンの Windows から無料で移行は、windows 10 クライアント数が徐々 に増加します。 これら 2 つの組み合わせは、windows 10 のタイトルが膨大な数の Microsoft Store を通じて顧客に到達できることを意味します。

さらに、windows 10 には、ゲームに特に便利な多くの新しい機能が用意されています。

-   メモリのページングの削減および全体的なメモリ システム サイズの削減
-   グラフィックス メモリの管理機能の向上により、フォアグラウンドのゲームに、より多くのメモリがアクティブに割り当てられ、保護されます。

## <a name="uwp-games-with-c-and-directx"></a>C++ と DirectX を使った UWP ゲーム


高パフォーマンスを必要とするリアルタイム ゲームでは、DirectX API を使用する必要があります。 DirectX は、3D ゲームなど、高パフォーマンスを必要とするゲームやマルチメディア アプリケーションを作成するための、ネイティブ API のコレクションです。

## <a name="development-environment"></a>開発環境


Uwp ゲームを作成するには、Visual Studio 2015 以降をインストールすることによって、開発環境をセットアップする必要があります。 お勧めします、Visual Studio の最新バージョンをインストールすることを最新の開発とセキュリティ更新プログラム。 Visual Studio では、UWP アプリを作成することができ、ゲームの開発ツールを提供します。

-   Visual Studio の DX ゲームのプログラミング用ツール: Visual Studio には、画像、モデル、シェーダー リソースを作成、編集、プレビュー、エクスポートするためのツールが用意されています。 また、ビルド時のリソースの変換や、DirectX グラフィックス コードのデバッグに使うことができるツールもあります。 詳しくは、「[ゲーム プログラミング用の Visual Studio ツールの使用](set-up-visual-studio-for-game-development.md)」をご覧ください。
-   Visual Studio グラフィックス診断機能: オプション機能として、グラフィックス診断ツールを Windows 内から利用できるようになりました。 診断ツールを使って、グラフィックス デバッグやグラフィックス フレーム分析を実行し、リアルタイムで GPU 使用率を監視できます。 詳しくは、「[DirectX ランタイムと Visual Studio グラフィックス診断機能の使用](use-the-directx-runtime-and-visual-studio-graphics-diagnostic-features.md)」をご覧ください。

詳しくは、「ユニバーサル Windows プラットフォームと [DirectX プログラミング](directx-programming.md)環境の準備」をご覧ください。

## <a name="getting-started-with-directx-game-project-templates"></a>DirectX ゲーム プロジェクト テンプレートの概要


開発環境をセットアップすると、DirectX 関連のプロジェクト テンプレートのいずれかを使って UWP DirectX ゲームを作成できます。 Visual Studio 2015 には、新しい UWP DirectX プロジェクトを作成するためのテンプレートとして、**DirectX 11 アプリ (ユニバーサル Windows)**、**DirectX 12 アプリ (ユニバーサル Windows)**、**DirectX 11 および XAML アプリ (ユニバーサル Windows)** の 3 つがあります。 詳しくは、「[テンプレートからのユニバーサル Windows プラットフォームおよび DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。

## <a name="windows-10-apis"></a>Windows 10 API


Windows 10 では、ゲーム開発に役立つさまざまな API を利用できます。 3D グラフィックス、2D グラフィックス、オーディオ、入力、テキスト リソース、ユーザー インターフェイス、ネットワークなど、ゲームのほとんどすべての側面にかかわる API が用意されています。

ゲーム開発に関連する API は数多くありますが、すべてのゲームですべての API を使用する必要はありません。 たとえば、3D グラフィックスと Direct3D のみを利用するゲームもあれば、2D グラフィックスと Direct2D のみを利用するゲームもあります。また、その両方を使用するゲームもあります。 次の図は、ゲーム開発に関連する API を機能別にグループ分けしています。

![ゲーム プラットフォーム テクノロジ](images/gameplatformtechnologies.png)

-   3D グラフィックス: Windows 10 では、Direct3D 11 と [Direct3D 12](https://msdn.microsoft.com/library/windows/desktop/dn899121) の 2 つの 3D グラフィックス API セットをサポートしています。 これら API はいずれも、3D および 2D グラフィックスを作成する機能を提供します。 Direct3D 11 と Direct3D 12 を同時に使うことはありませんが、いずれも 2D グラフィックスおよび UI グループのすべての API と共に使うことができます。 ゲームでグラフィックス API を使う方法について詳しくは、「[DirectX ゲームの基本的な 3D グラフィックス](an-introduction-to-3d-graphics-with-directx.md)」をご覧ください。

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">API</th>
    <th align="left">説明</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left">Direct3D 12</td>
    <td align="left"><p>Direct3D 12 では、DirectX の核となる 3D グラフィックス API である Direct3D の次期バージョンが導入されます。 このバージョンの Direct3D は、以前のバージョンの Direct3D よりも高速かつ効率的になるように設計されています。 Direct3D 12 の速度の向上のトレードオフは、より下位レベルで動作することであり、グラフィックス リソースを自分で管理する必要があることです。また、速度の向上を実現するには、広範なグラフィックスのプログラミングの経験が必要です。</p>
    <p><strong>使う状況</strong></p>
    <p>Direct3D 12 は、ゲームのパフォーマンスを最大化する必要があり、ゲームが CPU バウンドである場合に使います。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/dn899121">Direct3d 12</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    <tr class="even">
    <td align="left">Direct3D 11</td>
    <td align="left"><p>Direct3D 11 は、以前のバージョンの Direct3D であり、D3D 12 より上位レベルのハードウェア アブストラクションを使用して 3D グラフィックスを作成できます。</p>
    <p><strong>使う状況</strong></p>
    <p>Direct3D 11 のコードが既にある場合、ゲームが CPU バウンドではない場合、またはリソースが自動的に管理されるメリットが必要な場合は、Direct3D 11 を使います。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/ff476080">Direct3D 11</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    </tbody>
    </table>

     

-   2D グラフィックスおよび UI API: テキストやユーザー インターフェイスなどの 2D グラフィックスに関する API です。 すべての 2D グラフィックスおよび UI API はオプションです。

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">API</th>
    <th align="left">説明</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left">Direct2D</td>
    <td align="left"><p>Direct2D は、2D ジオメトリ、ビットマップ、テキストの高パフォーマンスかつ高品質のレンダリングを実現する、ハードウェア アクセラレータによる、即時モードの 2D グラフィックス API です。 Direct2D API は Direct3D を基にして構築されており、GDI、GDI+、Direct3D とも適切に相互運用できるように設計されています。</p>
    <p><strong>使う状況</strong></p>
    <p>Direct2D は、横スクロール ゲームやボード ゲームなどの純粋な 2D ゲーム用のグラフィックスを提供するために、Direct3D の代わりに使うことができます。また、ユーザー インターフェイスやヘッドアップ ディスプレイなど、3D ゲーム内での 2D グラフィックスの作成を簡素化するために Direct3D と共に使うこともできます。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/dd370990">Direct2D</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    <tr class="even">
    <td align="left">DirectWrite</td>
    <td align="left"><p>DirectWrite は、テキストを操作するための追加の機能を提供します。Direct3D や Direct2D と共に使用して、ユーザー インターフェイスや、テキストが必要なその他の領域にテキスト出力を提供できます。 DirectWrite は、複数形式のテキストの測定、描画、ヒット テストをサポートします。 DirectWrite は、グローバル アプリケーションとローカライズされたアプリケーションで、サポートされているすべての言語のテキストを処理します。 DirectWrite は、独自のレイアウトと Unicode からグリフへの処理を実行する必要がある開発者に、下位レベルのグリフ レンダリング API も提供します。</p>
    <p><strong>使う状況</strong></p>
    <p></p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/dd368038">DirectWrite</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    <tr class="odd">
    <td align="left">DirectComposition</td>
    <td align="left"><p>DirectComposition は、変換、効果、アニメーションを使って、高パフォーマンスのビットマップ合成を実現できる Windows コンポーネントです。 アプリケーション開発者は、DirectComposition API によって、ビジュアル要素間で機能豊富で柔軟な切り替えのアニメーションを使った、視覚的に魅力のあるユーザー インターフェイスを作成できます。</p>
    <p><strong>使う状況</strong></p>
    <p>DirectComposition は、視覚要素を合成し、切り替えのアニメーションを作成するプロセスを簡略化するように設計されています。 複雑なユーザー インターフェイスがゲームに必要な場合、DirectComposition を使って、簡単に UI を作成および管理できます。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/hh437371">DirectComposition</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    </tbody>
    </table>

     

-   オーディオ: オーディオの再生やオーディオ エフェクトの適用に関する API です。 ゲームでオーディオ API を使う方法について詳しくは、「[ゲームのオーディオ](working-with-audio-in-your-directx-game.md)」をご覧ください。

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">API</th>
    <th align="left">説明</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left">XAudio2</td>
    <td align="left"><p>XAudio2 は、信号処理とミキシングの基礎を提供する下位レベルのオーディオ API です。 XAudio は、カスタム オーディオ エフェクトや、オーディオ エフェクトとフィルターの複雑なチェーンを作成する機能を維持しながら、ゲーム オーディオ エンジンに対する応答性が高くなるように設計されています。</p>
    <p><strong>使う状況</strong></p>
    <p>ゲームでオーバーヘッドと遅延を最小限に抑えながらサウンドを再生する必要がある場合、XAudio2 を使用します。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/hh405049">XAudio2</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    <tr class="even">
    <td align="left">メディア ファンデーション</td>
    <td align="left"><p>Microsoft メディア ファンデーションは、オーディオとビデオの両方のメディア ファイルやストリームの再生用として設計されていますが、XAudio2 よりも高いレベルの機能が必要とされている場合や、追加のオーバーヘッドを許容できる場合にゲームで利用することもできます。</p>
    <p><strong>使う状況</strong></p>
    <p>メディア ファンデーションは、特に、ゲーム中の映画的なシーンや非対話型のコンポーネントに利用できます。 また、メディア ファンデーションは、XAudio2 を使って再生するオーディオ ファイルをデコードするのに便利です。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/ms694197">Microsoft メディア ファンデーション</a>の概要をご覧ください。</p></td>
    </tr>
    </tbody>
    </table>

     

-   入力: キーボード、マウス、ゲームパッド、その他のユーザー入力ソースからの入力に関する API です。

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">API</th>
    <th align="left">説明</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left">XInput</td>
    <td align="left"><p>XInput ゲーム コント ローラー API によって、アプリケーションでゲーム コントローラーからの入力を受信できます。</p>
    <p><strong>使う状況</strong></p>
    <p>ゲームでゲームパッドからの入力をサポートする必要がある場合や、XInput のコードが既にある場合は、引き続き XInput を利用できます。 UWP の場合、XInput は Windows.Gaming.Input に置き換えられたため、新しい入力コードを記述する場合は、XInput ではなく Windows.Gaming.Input を使う必要があります。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/hh405053">XInput</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    <tr class="even">
    <td align="left">Windows.Gaming.Input</td>
    <td align="left"><p>Windows.Gaming.Input API は XInput を置き換える API であり、同じ機能を提供すると共に、XInput に比べて次のような利点があります。</p>
    <ul>
    <li>リソースの使用量が少ない</li>
    <li>入力を取得するための API 呼び出しの待ち時間が短い</li>
    <li>同時に 4 つ以上のゲームパッドを処理する機能</li>
    <li>トリガー バイブレーション モーターなど、追加の Xbox One ゲームパッド機能にアクセスする機能</li>
    <li>コントローラー接続/切断をポーリングではなくイベントで通知する機能</li>
    <li>入力を特定のユーザー (Windows.System.User) に関連付ける機能</li>
    </ul>
    <p><strong>使う状況</strong></p>
    <p>ゲームでゲームパッド入力をサポートする必要があるが、XInput の既存のコードを使っていない場合や、上に示したメリットのいずれかが必要である場合は、Windows.Gaming.Input を使う必要があります。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/apps/dn707817">Windows.Gaming.Input</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    <tr class="odd">
    <td align="left">Windows.UI.Core.CoreWindow</td>
    <td align="left"><p>Windows.UI.Core.CoreWindow クラスは、ポインターのボタンの押下や移動を追跡するためのイベント、キーの押下やリリースのイベントを提供します。</p>
    <p><strong>使う状況</strong></p>
    <p>ゲームでマウスやキーの押下を追跡する必要がある場合、Windows.UI.Core.CoreWindows のイベントを使います。</p>
    <p><strong>詳細情報</strong></p>
    <p>ゲームでマウスやキーボードを使う方法について詳しくは、「<a href="https://docs.microsoft.com/windows/uwp/gaming/tutorial--adding-move-look-controls-to-your-directx-game">ゲームのムーブ/ルック コントロール</a>」をご覧ください。</p></td>
    </tr>
    </tbody>
    </table>

     

-   数値演算: 一般的に使用される数値演算の簡素化に関する API です。

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">API</th>
    <th align="left">説明</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left">DirectXMath</td>
    <td align="left"><p>DirectXMath API は、ゲームで一般的な線形代数およびグラフィックスの数値演算用の SIMD フレンドリな C++ の型および関数を提供します。</p>
    <p><strong>使う状況</strong></p>
    <p>DirectXMath の使用はオプションであり、一般的な数値演算を簡素化します。</p>
    <p><strong>詳細情報</strong></p>
    <p><a href="https://msdn.microsoft.com/library/windows/desktop/hh437833">DirectXMath</a> に関連するドキュメントをご覧ください。</p></td>
    </tr>
    </tbody>
    </table>

     

-   ネットワーク: インターネットまたはプライベート ネットワーク上の他のコンピューターやデバイスとの通信に関する API です。

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">API</th>
    <th align="left">説明</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left">Windows.Networking.Sockets</td>
    <td align="left"><p>Windows.Networking.Sockets 名前空間は、信頼性の高いまたは信頼性の低いネットワーク通信を実現する TCP および UDP ソケットを提供します。</p>
    <p><strong>使う状況</strong></p>
    <p>Windows.Networking.Sockets は、ゲームがネットワーク経由で他のコンピューターやデバイスと通信する必要がある場合に使用します。</p>
    <p><strong>詳細情報</strong></p>
    <p>「<a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">ゲームでのネットワークの使用</a>」をご覧ください。</p></td>
    </tr>
    <tr class="even">
    <td align="left">Windows.Web.HTTP</td>
    <td align="left"><p>Windows.Web.HTTP 名前空間では、Web サイトへのアクセスに利用できる、HTTP サーバーへの信頼性の高い接続を実現できます。</p>
    <p><strong>使う状況</strong></p>
    <p>ゲームで Web サイトにアクセスして情報を取得または保存する必要がある場合に、Windows.Web.HTTP を使います。</p>
    <p><strong>詳細情報</strong></p>
    <p>「<a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">ゲームでのネットワークの使用</a>」をご覧ください。</p></td>
    </tr>
    </tbody>
    </table>

     

-   サポート ユーティリティ: Windows 10 API に基づいて構築されたライブラリです。

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">ライブラリ</th>
    <th align="left">説明</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left">DirectX ツール キット</td>
    <td align="left"><p>DirectX ツール キット (DirectXTK) は、C++ で DirectX 11.x コードを作成するためのヘルパー クラスのコレクションです。</p>
    <p><strong>使う状況</strong></p>
    <p>C++ を使っている開発者がレガシ D3DX ユーティリティ コードに代わる最新のユーティリティを探している場合や、XNA Game Studio を使っている開発者がネイティブ C++ に移行する場合に、DirectX ツール キットを使います。</p>
    <p><strong>詳細情報</strong></p>
    <p>DirectX ツール キットのプロジェクト ページ <a href="https://github.com/Microsoft/DirectXTK">https://github.com/Microsoft/DirectXTK</a> を参照してください。</p></td>
    </tr>
    <tr class="even">
    <td align="left">Win2D</td>
    <td align="left"><p>Win2D は、即時モードの 2D グラフィックス レンダリング用の、使いやすい Windows ランタイム API です。</p>
    <p><strong>使う状況</strong></p>
    <p>C++ を使っている開発者が Direct2D と DirectWrite の使いやすい WinRT ラッパーを必要としている場合や、C# を使っている開発者が Direct2D と DirectWrite を使う必要がある場合に、Win2D を使います。</p>
    <p><strong>詳細情報</strong></p>
    <p>Win2D プロジェクト ページ <a href="https://github.com/Microsoft/Win2D">https://github.com/Microsoft/Win2D</a> を参照してください。</p></td>
    </tr>
    </tbody>
    </table>

     

## <a name="xbox-live-services"></a>Xbox Live サービス

[Xbox Live クリエーターズ プログラム](https://developer.microsoft.com/games/xbox/xboxlive/creator)には、自分の UWP ゲームに Xbox Live を統合して、Xbox One と windows 10 に公開するすべての開発者ができます。 最小限の開発時間で、サインイン、プレゼンス、ランキングなどの Xbox Live ソーシャル エクスペリエンスをタイトルに統合できます。 Xbox Live のソーシャル機能では、5,500 万人以上のアクティブ ゲーマーに情報を発信して、オーディエンスを自然に増やすことができます。

Xbox Live の他の機能にアクセスしたり、マーケティングと開発に関する専用のサポートを受けたり、Xbox One ストアのメイン ページで取り上げられたりすることを希望する場合は、[ID@Xbox](http://www.xbox.com/developers/id) プログラムへの登録を申し込んでください。 Xbox Live クリエーターズ プログラム、および ID@Xbox プログラムで利用できる機能については、[機能表](../xbox-live/developer-program-overview.md#feature-table)をご覧ください。

詳しくは、「[ゲームへの Xbox Live の追加](e2e.md#adding-xbox-live-to-your-game)」をご覧ください。

##  <a name="alternatives-to-writing-games-with-directx-and-uwp"></a>DirectX と UWP を使ったゲーム作成の代替手段


### <a name="uwp-games-without-directx"></a>DirectX を使わない UWP ゲーム

カード ゲームやボード ゲームなど、最低限のパフォーマンスの要件を満たす単純なゲームは、DirectX を使わずに作成でき、必ずしも C++ で記述されている必要はありません。 このような種類のゲームでは、C#、Visual Basic、C++、HTML/JavaScript など、UWP でサポートされている言語のいずれかを利用できます。 パフォーマンスと負荷の高いグラフィックスがゲームで必要な場合は、[JavaScript と HTML5 のタッチ ゲームのサンプル](http://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031)を参考にしてください。

### <a name="game-engines"></a>ゲーム エンジン

Windows ゲーム開発 API を使って独自のゲーム エンジンを作成する代替手段として、Windows ゲーム開発 API を基にして作成された多くの高品質ゲーム エンジンを、Windows プラットフォームでのゲームの開発に利用できます。 ゲーム エンジンまたはライブラリを検討する場合、複数のオプションがあります。

-   フル ゲーム エンジン: フル ゲーム エンジンは、ゲーム エンジンをゼロから作成する場合に使用する、グラフィックス、オーディオ、入力、ネットワークなどの Windows 10 API のほとんどまたはすべてをカプセル化します。 また、フル ゲーム エンジンは、人工知能や経路探索などのゲーム ロジック機能も備えています。
-   グラフィックス エンジン: グラフィックス エンジンは、Windows 10 のグラフィックス API をカプセル化して、グラフィックス リソースを管理し、さまざまなモデルとワールドの形式をサポートします。
-   オーディオ エンジン: オーディオ エンジンは Windows 10 のオーディオ API をカプセル化して、オーディオ リソースを管理し、高度なオーディオ処理とエフェクトを提供します。
-   ネットワーク エンジン: ネットワーク エンジンは、Windows 10 のネットワーク API をカプセル化して、ピア ツー ピアまたはサーバー ベースのマルチプレイヤーのサポートをゲームに追加します。また、多数のプレイヤーをサポートするための高度なネットワーク機能が含まれる場合もあります。
-   人工知能と経路探索エンジン: AI と経路探索エンジンは、ゲーム内でエージェントの動作を制御するためのフレームワークを提供します。
-   特殊な用途のエンジン: インベントリ システムやダイアログ ツリーなど、発生する可能性があるほぼすべてのゲーム開発関連タスクを処理するために、さまざまな追加のエンジンが存在します。

## <a name="submitting-a-game-to-the-store"></a>ストアへのゲームの提出


ゲームを公開する準備ができたら、開発者アカウントを作成して、ゲームを Microsoft Store に提出する必要があります。

Microsoft Store へのゲームの提出については、「[ゲームの申請と公開](e2e.md#submitting-and-publishing-your-game)」をご覧ください。

 

 




