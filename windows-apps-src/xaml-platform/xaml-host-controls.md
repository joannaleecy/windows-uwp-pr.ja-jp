---
author: normesta
description: このガイドは、WPF および Windows フォーム アプリケーションで直接 Fluent ベースの UWP UI を作成するのに役立ちます。
title: デスクトップ アプリケーションで UWP コントロール
ms.author: normesta
ms.date: 09/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp, windows forms, wpf
keywords: windows 10, uwp, windows, フォーム, wpf
ms.localizationpriority: medium
ms.openlocfilehash: 6b8c263b030cbb8f945ffb13a24b6dff3af28fcc
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4173635"
---
# <a name="uwp-controls-in-desktop-applications"></a>デスクトップ アプリケーションで UWP コントロール

> [!NOTE]
> Api と、この記事で説明するコントロールは開発者プレビューとして現在利用可能です。 それらプロトタイプ コードで今すぐ試すをお勧めしますがないことで使う運用コードこの時点でお勧めしますしないでください。 これらの Api とコントロールは引き続き成熟し、今後の Windows のリリースに安定します。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

ここで、Windows 10 では、外観や操作感を既存のデスクトップ アプリケーション、最新の Windows 10 の UI 機能のみで利用可能な UWP コントロールの機能を高めることができるように、UWP 以外のデスクトップ アプリケーションで UWP コントロールを使用できます。 つまり、 [Fluent Design System](../design/fluent-design-system/index.md)と、既存の WPF、Windows フォーム、および C++ Win32 アプリケーションでは、 [Windows Ink](../design/input/pen-and-stylus-interactions.md)などの UWP 機能を使用することができます。 このシナリオは、 *XAML 諸島*と呼ばれます。

テクノロジやフレームワークを使用しているによって、デスクトップ アプリケーションで XAML 諸島を使用する方法をいくつか用意されています。

## <a name="wrapped-controls"></a>ラップされたコントロール

WPF および Windows フォーム アプリケーションでは、 [Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)でラップされた UWP のコントロールの選択を使用できます。 これらのコントロールを直接 WPF または Windows フォーム プロジェクトのデザイン サーフェイスに追加し、デザイナーで、他の WPF または Windows フォームなどのコントロールと同様に使用できます。 これらのコントロールといいます*コントロールをラップ*インターフェイスと特定の UWP コントロールの機能をラップするためです。

次のラップされたコントロールでは、Windows 10 バージョン 1803 以降をサポートします。

* [WebView](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview)します。 このコントロールは、WPF または Windows フォーム アプリケーションで web コンテンツを表示するのに Microsoft Edge レンダリング エンジンを使用します。
* [WebViewCompatible](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webviewcompatible)します。 このコントロールは、Windows 10 と互換性がある**WebView**のバージョンと Windows の以前のバージョンです。 このコントロールは、Windows 10 (バージョン 1803 以降) で web コンテンツを表示する Microsoft Edge レンダリング エンジンと Windows 7 および Windows 上の web コンテンツを表示する Internet Explorer のレンダリング エンジンを使います 8.x します。

次のラップされたコントロールでは、Windows 10 Insider Preview SDK ビルド 17709 以降のリリースをサポートします。

* [InkCanvas](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inkcanvas)と[InkToolbar](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inktoolbar)します。 これらのコントロールは、Windows フォームや WPF デスクトップ アプリケーションでの Windows Ink ベースのユーザー操作のサーフェスと関連するツールバーを提供します。
* [MediaPlayerElement](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/mediaplayerelement)します。 このコントロールは、ストリームし、Windows フォームや WPF デスクトップ アプリケーションのビデオなどのメディア コンテンツをレンダリングするビューを埋め込みます。

複数の UWP では、コントロールをラップ wpf と Windows コミュニティ ツールキットの今後のリリースの Windows フォーム アプリケーションが計画されています。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションにラップされたコントロールが利用できません。 この種類のアプリケーションでは、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)を使う必要があります。

## <a name="host-controls"></a>コントロールをホストします。

利用可能なラップされたコントロールでカバーされている以外のシナリオで WPF および Windows フォーム アプリケーションは[WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost)コントロールを[Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)で使用することもできます。 このコントロールは、 [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)、Windows SDK とカスタム ユーザー コントロールによって提供されるすべての UWP コントロールを含むから派生したすべての UWP コントロールをホストできます。 このコントロールには、Windows 10 Insider Preview SDK ビルド 17709 以降のリリースがサポートしています。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションのホスト コントロールが利用できません。 この種類のアプリケーションでは、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)を使う必要があります。

## <a name="uwp-xaml-hosting-api"></a>UWP XAML API をホストしています。

C++ Win32 アプリケーションがある場合は、関連付けられているウィンドウ ハンドル (HWND) には、アプリケーション内の任意の UI 要素で[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)から派生したすべての UWP コントロールをホストする*API をホストしている UWP XAML*を使用できます。 この API は、Windows 10 Insider Preview SDK ビルド 17709 で導入されました。 この API の使用について詳しくは、[デスクトップ アプリケーションでの API をホストしている XAML を使って](using-the-xaml-hosting-api.md)を参照してください。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションでは、UWP コントロールをホストする API をホストしている UWP XAML を使う必要があります。 ラップされたコントロールとホスト コントロールでは、この種類のアプリケーションを利用できません。 WPF および Windows フォーム アプリケーションでは、お勧めします UWP XAML ではなく Windows コミュニティ ツールキットでラップされたコントロールとホスト コントロールが使用して API をホストしています。 これらのコントロールでは、内部的に API をホストしている UWP XAML を使用し、シンプルな開発エクスペリエンスを提供します。 ただし、選択した場合、WPF および Windows フォーム アプリケーションで直接 API をホストしている UWP XAML を使用することができます。

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
