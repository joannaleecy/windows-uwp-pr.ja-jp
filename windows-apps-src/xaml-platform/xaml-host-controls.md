---
description: このガイドは、WPF および Windows フォーム アプリケーションで直接 Fluent ベースの UWP UI を作成するのに役立ちます。
title: デスクトップ アプリケーションの UWP コントロール
ms.date: 09/21/2018
ms.topic: article
keywords: windows 10, uwp, windows, フォーム, wpf
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: bd22aa761d4a9a79c95c7bc424ab1d2a31ca6cdf
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8923994"
---
# <a name="uwp-controls-in-desktop-applications"></a>デスクトップ アプリケーションの UWP コントロール

> [!NOTE]
> Api と、この記事で説明するコントロールは開発者プレビューとして現在利用できます。 それらプロトタイプ コードで今すぐ試すをお勧めしますがない使用することに運用コードでこの時点でお勧めしますしないでください。 これらの Api とコントロールは引き続き成熟して、今後の Windows リリースに安定します。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

これで、Windows 10 を使用すると、外観や操作感をのみで利用可能な UWP コントロールを最新の Windows 10 の UI 機能によって、既存のデスクトップ アプリケーションの機能を高めることができるように、UWP 以外のデスクトップ アプリケーションで UWP コントロールを使用できます。 つまり、 [Windows Ink](../design/input/pen-and-stylus-interactions.md)と、既存の WPF、Windows フォーム、および C++ Win32 アプリケーションで、 [Fluent Design System](../design/fluent-design-system/index.md)をサポートするコントロールなどの UWP 機能を使用することができます。 この開発者シナリオは、 *XAML 諸島*と呼ばれます。

XAML 諸島テクノロジやを使用しているフレームワークによって、WPF、Windows フォーム、および C++ の Win32 アプリケーションで使用するいくつかの方法を説明します。

## <a name="wrapped-controls"></a>ラップされたコントロール

WPF および Windows フォーム アプリケーションでは、 [Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)でラップされた UWP コントロールの選択項目を使用できます。 これらのコントロールといいます*コントロールをラップ*インターフェイスと特定の UWP コントロールの機能をラップするためです。 直接 WPF または Windows フォーム プロジェクトのデザイン サーフェイスにこれらのコントロールを追加でき、デザイナーで、他の WPF または Windows フォームなどのコントロールと同様に使用することができます。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションにラップされたコントロールが利用できません。 この種類のアプリケーションでは、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)を使う必要があります。

次のラップされた UWP コントロールは、WPF および Windows フォーム アプリケーションでは現在使用します。 さらにラップする UWP のコントロールは、Windows コミュニティ ツールキットの今後のリリースの予定です。

| コントロール | サポートされる最小の OS | 説明 |
|-----------------|-------------------------------|-------------|
| [WebView](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview) | Windows 10 バージョン 1803 | Web コンテンツを表示するのにには、Microsoft Edge レンダリング エンジンを使用します。 |
| [WebViewCompatible](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webviewcompatible) | Windows 7 | 多くの OS バージョンと互換性がある**WebView**のバージョンを提供します。 このコントロールを Windows 10 バージョン 1803 以降で web コンテンツを表示する Microsoft Edge レンダリング エンジンと以前のバージョンの Windows 10、Windows 上の web コンテンツを表示する Internet Explorer のレンダリング エンジンを使用して、8.x と Windows 7 です。 |
| [InkCanvas](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inkcanvas)<br>[InkToolbar](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inktoolbar) | Windows 10 Insider Preview SDK ビルド 17709 | Windows フォームや WPF デスクトップ アプリケーションでの Windows Ink ベースのユーザー操作のサーフェスと関連するツールバーを提供します。 |
| [MediaPlayerElement](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/mediaplayerelement) | Windows 10 Insider Preview SDK ビルド 17709 | ストリームし、Windows フォームや WPF デスクトップ アプリケーションのビデオなどのメディア コンテンツをレンダリングするビューを埋め込みます。 |

## <a name="host-controls"></a>コントロールをホストします。

利用可能なラップされたコントロールで対応できない場合、WPF および Windows フォーム アプリケーションは[WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost)コントロールを[Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)で使用することもできます。 このコントロールは、 [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)、Windows SDK とカスタム ユーザー コントロールによって提供されるすべての UWP コントロールを含むから派生したすべての UWP コントロールをホストできます。 このコントロールには、Windows 10 Insider Preview SDK ビルド 17709 以降のリリースがサポートされています。

> [!NOTE]
> ホスト コントロールでは、C++ Win32 デスクトップ アプリケーションを利用できません。 この種類のアプリケーションでは、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)を使う必要があります。

## <a name="uwp-xaml-hosting-api"></a>UWP XAML の API をホストしています。

C++ Win32 アプリケーションがある場合は、任意の UI 要素を関連付けられているウィンドウ ハンドル (HWND) を持つアプリケーションで[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)から派生したすべての UWP コントロールをホストする*API をホストしている UWP XAML*を使用できます。 この API は、Windows 10 Insider Preview SDK ビルド 17709 で導入されました。 この API の使用について詳しくは、 [XAML をホストするデスクトップ アプリケーションでの API を使用して](using-the-xaml-hosting-api.md)を参照してください。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションでは、UWP コントロールをホストする API をホストしている UWP XAML を使う必要があります。 ラップされたコントロールとホスト コントロールでは、この種類のアプリケーションは利用できません。 WPF および Windows フォーム アプリケーションでは、お勧めします UWP XAML ではなく、Windows コミュニティ ツールキットでラップされたコントロールとホスト コントロールが使用して API をホストしています。 これらのコントロールでは、社内で API をホストしている UWP XAML を使用し、シンプルな開発エクスペリエンスを提供します。 ただし、選択した場合、WPF および Windows フォーム アプリケーションで直接 API をホストしている UWP XAML を使用することができます。

## <a name="architecture-overview"></a>アーキテクチャの概要

これらのコントロールがアーキテクチャ的に編成されるしくみの概要を次に示します。 この図で使用される名前は変更されることがあります。  

![ホスト コントロール アーキテクチャ](images/host-controls.png)

この図の下部に表示されている API は、Windows SDK に付属しています。 デザイナーに追加するコントロールは、Windows コミュニティ ツールキットで Nuget パッケージとしてリリースされます。

これらの新しいコントロールには制限事項があるため、それらを使用する前に、まだサポートされていない機能、また回避策を使用してのみ動作する機能を少し時間を取って確認してください。

## <a name="limitations"></a>制限事項

### <a name="whats-supported"></a>サポートされている内容

ほとんどの場合、次の一覧で明示されていない限り、すべてがサポートされます。

### <a name="whats-supported-only-with-workarounds"></a>回避策を使用した場合にのみサポートされている内容

:heavy_check_mark: 複数のウィンドウの内部での複数のインボックス コントロールのホスティング。 独自のスレッドに各ウィンドウを配置する必要があります。

:heavy_check_mark: ホストされたコントロールでの ``x:Bind`` の使用。 .NET Standard ライブラリ内でデータ モデルを宣言する必要があります。

:heavy_check_mark: C# ベースのサードパーティのコントロール。 サードパーティのコントロールへのソース コードがある場合は、それに対してコンパイルできます。

### <a name="whats-not-yet-supported"></a>まだサポートされていない内容

:no_entry_sign: アプリケーションおよびホストされたコントロールでシームレスに動作するアクセシビリティ ツール。

:no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーションに追加するコントロール内のローカライズされたコンテンツ。

: no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーション内で XAML で行われたアセット参照。

:no_entry_sign:  DPI と倍率の変更に適切に対応するコントロール。

:no_entry_sign: カスタム ユーザー コントロールへの **WebView** コントロールの追加 (スレッド上、オフ スレッド、proc 外のいずれか)

:no_entry_sign: [表示ハイライト](https://docs.microsoft.com/windows/uwp/design/style/reveal)  の Fluent 効果。

:no_entry_sign: 入力コントロールのためのインライン インク、@Places
、@People。

:no_entry_sign: ショートカット キーの割り当て。

:no_entry_sign: C++ ベースのサードパーティのコントロール。

:no_entry_sign: カスタム ユーザー コントロールのホスティング。

Fluent をデスクトップに導入するエクスペリエンスの向上を続けていくうえで、この一覧の項目は変更される可能性があります。  
