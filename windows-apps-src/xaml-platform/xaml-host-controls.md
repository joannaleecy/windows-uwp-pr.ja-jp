---
description: このガイドは、WPF および Windows フォーム アプリケーションで直接 Fluent ベースの UWP UI を作成するのに役立ちます。
title: デスクトップ アプリケーションの UWP コントロール
ms.date: 01/11/2019
ms.topic: article
keywords: windows 10, uwp, windows, フォーム, wpf
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: bf25fea6ca6e8809c12324ae57a42cc712ded2a5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57619707"
---
# <a name="uwp-controls-in-desktop-applications"></a>デスクトップ アプリケーションの UWP コントロール

> [!NOTE]
> XAML アイランドは、現在開発者プレビューとして使用できます。 実際に試してみて、プロトタイプのコードで今すぐするを勧めしますが、使用することに実稼働コードでこの時点でをしないでください。 これらの Api とコントロールが成熟し、将来のリリースの Windows を安定化を続けます。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。
>
> XAML 諸島に関するフィードバックをした場合で新しい問題を作成、 [WindowsCommunityToolkit リポジトリ](https://github.com/windows-toolkit/WindowsCommunityToolkit/issues)がコメントを残すとします。 プライベート フィードバックを送信する場合に送信できますXamlIslandsFeedback@microsoft.comします。 Insights とシナリオは弊社にとって非常に重要です。

今すぐ Windows 10 で、外観やのみ UWP コントロールを使用して利用できる最新の Windows 10 の UI 機能と既存のデスクトップ アプリケーションの機能を強化するように、デスクトップ アプリケーションを UWP 以外で UWP コントロールを使用することができます。 つまり、UWP の機能をなど、使用できる[Windows インク](../design/input/pen-and-stylus-interactions.md)サポートするコントロールと、 [Fluent Design System](../design/fluent-design-system/index.md)既存の WPF、Windows フォーム、および C++ の Win32 アプリケーション。 この開発シナ リオとも呼ばれます*XAML 諸島*します。

テクノロジまたは使用しているフレームワークに応じて、WPF、Windows フォーム、および C++ の Win32 アプリケーションで XAML 諸島を使用するいくつかの方法を紹介します。

## <a name="wrapped-controls"></a>ラップされたコントロール

WPF と Windows フォーム アプリケーションは、ラップされた UWP コントロールの選択範囲を使用できます、 [Windows Community Toolkit](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)します。 これらのコントロールとして呼ば*コントロールをラップ*インターフェイスと特定の UWP コントロールの機能をラップするためです。 これらのコントロールを WPF や Windows フォーム プロジェクトのデザイン画面に直接追加し、デザイナーで、他の WPF や Windows フォーム コントロールのように使用できます。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションのラップされたコントロールが利用できません。 この種のアプリケーションを使用する必要があります、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)します。

次のラップされた UWP コントロールは、WPF、Windows フォーム アプリケーションの現在使用できます。 ラップされた UWP コントロールの詳細については、Windows の Community Toolkit の将来のリリース予定です。

| コントロール | サポートされている OS の最小値 | 説明 |
|-----------------|-------------------------------|-------------|
| [WebView](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview) | Windows 10 バージョン 1803 | Web コンテンツを表示するのにには、Microsoft Edge のレンダリング エンジンを使用します。 |
| [WebViewCompatible](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webviewcompatible) | Windows 7 | バージョンを提供します**WebView**より多くの OS バージョンと互換性があります。 このコントロールが Windows 10 バージョン 1803 以降の web コンテンツを表示する Microsoft Edge のレンダリング エンジンと以前のバージョンの Windows 10、Windows 上の web コンテンツを表示する Internet Explorer のレンダリング エンジンを使用して、8.x および Windows 7。 |
| [InkCanvas](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inkcanvas)<br>[InkToolbar](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inktoolbar) | Windows 10 バージョン 1809 (17763 をビルドする) | Windows フォームまたは WPF デスクトップ アプリケーションでのインクの Windows ベースのユーザーの相互作用のサーフェスと関連するツールバーを提供します。 |
| [MediaPlayerElement](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/mediaplayerelement) | Windows 10 バージョン 1809 (17763 をビルドする) | ストリームし、Windows フォームまたは WPF デスクトップ アプリケーションでのビデオなどのメディア コンテンツをレンダリングするビューを埋め込みます。 |
| [MapControl](https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/wpf-winforms/mapcontrol) | Windows 10 バージョン 1809 (17763 をビルドする) | Windows フォームまたは WPF デスクトップ アプリケーションでシンボリックまたは写実的なマップを表示できます。 |

## <a name="host-controls"></a>ホスト コントロール

利用可能なラップされたコントロールで対応できないシナリオでは、WPF と Windows フォーム アプリケーションを使用できますも、 [WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost)を制御、 [Windows Community Toolkit](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)します。 このコントロールから派生した任意の UWP コントロールをホストできる[ **Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)など、UWP、Windows SDK によって提供されるだけではなくカスタム ユーザー コントロール。 このコントロールは、Windows 10 Insider Preview SDK ビルド 17709 およびそれ以降のリリースをサポートします。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションのホスト コントロールが利用できません。 この種のアプリケーションを使用する必要があります、 [API をホストしている UWP XAML](#uwp-xaml-hosting-api)します。

## <a name="uwp-xaml-hosting-api"></a>API をホストしている UWP XAML

C++ の Win32 アプリケーションがある場合を使用できます、 *API をホストしている UWP XAML*から派生した任意の UWP コントロールをホストする[ **Windows.UI.Xaml.UIElement** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)で任意の UI 要素で、アプリケーションが関連付けられているウィンドウ ハンドル (HWND) です。 この API は、Windows 10 Insider Preview SDK ビルド 17709 で導入されました。 詳細については、この API を使用して、次を参照してください。[デスクトップ アプリケーションで API をホストしている XAML を使用して](using-the-xaml-hosting-api.md)します。

> [!NOTE]
> C++ Win32 デスクトップ アプリケーションでは、UWP コントロールをホストする API をホストしている UWP XAML を使用する必要があります。 ラップされたコントロールとホスト コントロールでは、この種のアプリケーションを使用できません。 WPF と Windows フォーム アプリケーションをお勧め UWP XAML ではなく Windows Community Toolkit でラップされたコントロールとホスト コントロールが使用して API をホストします。 これらのコントロールは、内部的に API をホストしている UWP XAML を使用して、および単純な開発エクスペリエンスを提供します。 ただし、選択した場合、WPF、Windows フォーム アプリケーションで直接 API をホストしている UWP XAML を使用することができます。

## <a name="architecture-overview"></a>アーキテクチャの概要

これらのコントロールがアーキテクチャ的に編成されるしくみの概要を次に示します。 この図で使用される名前は変更されることがあります。  

![ホスト コントロール アーキテクチャ](images/host-controls.png)

この図の下部に表示されている API は、Windows SDK に付属しています。 デザイナーに追加するコントロールは、Windows コミュニティ ツールキットで Nuget パッケージとしてリリースされます。

これらの新しいコントロールには制限事項があるため、それらを使用する前に、まだサポートされていない機能、また回避策を使用してのみ動作する機能を少し時間を取って確認してください。

## <a name="limitations"></a>制限事項

### <a name="whats-supported"></a>サポートされている内容

ほとんどの場合、次の一覧で明示されていない限り、すべてがサポートされます。

### <a name="whats-supported-only-with-workarounds"></a>回避策を使用した場合にのみサポートされている内容

:heavy_check_mark:複数のウィンドウ内で複数の受信トレイ コントロールをホストします。 独自のスレッドに各ウィンドウを配置する必要があります。

:heavy_check_mark:使用して``x:Bind``でコントロールをホストします。 .NET Standard ライブラリ内でデータ モデルを宣言する必要があります。

:heavy_check_mark:C#-ベースのサードパーティ製のコントロール。 サードパーティのコントロールへのソース コードがある場合は、それに対してコンパイルできます。

### <a name="whats-not-yet-supported"></a>まだサポートされていない内容

: no_entry_sign:アプリケーション間でシームレスに動作し、ホスト コントロール ユーザー補助ツールです。

: no_entry_sign:Windows アプリ パッケージが含まれていないアプリケーションを追加するコントロールのローカライズされたコンテンツ。

: no_entry_sign:Windows アプリ パッケージが含まれていないアプリケーション内で XAML で行われた資産の参照。

: no_entry_sign:DPI とスケールの変更に適切に応答を制御します。

: no_entry_sign:追加、 **WebView**コントロールをカスタム ユーザー コントロール、(スレッドで、オフ スレッドまたはプロセス外)。

: no_entry_sign:[表示の強調表示](https://docs.microsoft.com/windows/uwp/design/style/reveal)Fluent 効果。

: no_entry_sign:インラインで手描き入力機能、 @Places、および@People入力コントロール。

: no_entry_sign:アクセラレータ キーを割り当てます。

: no_entry_sign:C++ ベースのサードパーティ製のコントロール。

: no_entry_sign:カスタム ユーザー コントロールをホストします。

Fluent をデスクトップに導入するエクスペリエンスの向上を続けていくうえで、この一覧の項目は変更される可能性があります。  
