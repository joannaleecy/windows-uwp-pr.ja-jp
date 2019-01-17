---
title: Windows ドキュメントの年 1 月 2019 - UWP アプリの開発
description: 新機能、ビデオ、および開発者向けガイダンスが 2019年 1 月の Windows 10 開発者向けドキュメントに追加されました
keywords: 新機能, 更新, 機能, 開発者向けガイダンス, Windows 10 年 1 月
ms.date: 1/17/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 4f224663506cbb60f6c1476caccb5ecffefeaf7b
ms.sourcegitcommit: cfdc854fede8e586202523cdb59d3d0a2f5b4b36
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/17/2019
ms.locfileid: "9014404"
---
# <a name="whats-new-in-the-windows-developer-docs-in-january-2019"></a>新機能、Windows 開発者向けドキュメントの年 2019年 1 月

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 次の機能概要、開発者向けガイダンス、およびビデオには 1 月で利用可能ななりました。

Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="windows-development-on-microsoft-learn"></a>Microsoft の学習で Windows の開発

Microsoft については、Microsoft の開発者に新しい実践的な学習とトレーニングを提供します。 Windows アプリを開発する方法を学習する場合[、新しい学習パス](https://docs.microsoft.com/learn/paths/develop-windows10-apps/)徹底的な紹介については、プラットフォーム、ツール、および、最初のいくつかのアプリを記述する方法をご覧ください。

![パスの学習 Windows 開発用の画像](images/windows-learn.png)

### <a name="direct-3d-12"></a>Direct 3D 12

[Direct3d12 のレンダリング パスが](/windows/desktop/direct3d12/direct3d-12-render-passes)するはその他の手法の間でタイル ベースの遅延レンダリング (TBDR) に基づいている場合に、レンダラーのパフォーマンスが向上することができます。 手法は、レンダラーをリソース レンダリング順序指定の要件とデータの依存関係を識別しやすく、アプリケーションを有効にして、短く、メモリへのトラフィックをオフ チップ メモリから GPU の効率を向上させるために役立ちます。

### <a name="msix-modification-packages"></a>MSIX 変更パッケージ

[MSIX 変更用のパッケージ](https://docs.microsoft.com/windows/msix/modification-package-1809-update)の Windows 10 version 1809 の向上のサポート。 変更パッケージでは、レジストリ ベースのプラグインと関連付けられたカスタマイズは、含めることができ、仮想レジストリを使用して、期待どおりに動作 MSIX を通じて展開されたアプリケーションを有効になります。

![MSIX 変更パッケージの作成](images/msix-modification-package.png)

### <a name="open-source-of-wpf-windows-forms-and-winui"></a>WPF、Windows フォーム、および WinUI のオープン ソース

Github のオープン ソースの貢献度の WPF、Windows フォーム、および WinUI UX のフレームワークが利用できるようになりました。 詳細とリンクは、[ビルドの Windows アプリのブログ](https://blogs.windows.com/buildingapps/2018/12/04/announcing-open-source-of-wpf-windows-forms-and-winui-at-microsoft-connect-2018/#OKZjJs1VVTrMMtkL.97)をご覧ください。

### <a name="progressive-web-apps-for-xbox"></a>Xbox 用のプログレッシブ Web アプリ

[Xbox One のプログレッシブ Web アプリ](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/xbox-considerations)、web アプリケーションの拡張でき、利用できるように、Xbox One アプリとして Microsoft Store 経由でながら、引き続き、既存のフレームワーク、CDN とサーバーのバックエンドを使用できます。 ほとんどの場合、パッケージ化して、PWA Xbox One の Windows の場合と同じ方法で、ただし、このガイドの説明をいくつかの主な違いがあります。

### <a name="windows-machine-learning"></a>Windows Machine learning

[WinML Api のランディング ページ](https://docs.microsoft.com/windows/ai/api-reference)で、再構築して、ネイティブ Api とカスタムの演算子を WinML 用の新しいドキュメントを追加しますがあります。

[PyTorch、モデルのトレーニング](https://docs.microsoft.com/windows/ai/train-model-pytorch)PyTorch フレームワークを使用して、ローカルとクラウドのモデルをトレーニングする方法のガイダンスを提供します。 このモデルを ONNX ファイルとしてダウンロードし、WinML アプリケーションで使用します。

![WinML グラフィック](images/winml-graphic.png)

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="choose-your-platform"></a>プラットフォームを選択します。

新しいデスクトップ アプリケーションの作成に関心があるかどうか。 詳しい説明については、UWP、Windows フォーム、WPF、プラットフォーム、および詳細については、Win32 API の比較の改良、[プラットフォームの選択](https://docs.microsoft.com/windows/desktop/choose-your-technology)] ページを確認します。

### <a name="faqs-on-win32-webview"></a>Win32 WebView の Faq

サンプルとその他のリソースへのリンクと同様に、デスクトップ アプリケーションで Microsoft Edge WebView を使用すると、当社の[よく寄せられる質問](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview#frequently-asked-questions-faqs)、よく寄せられる質問に対する回答が提供されます。

### <a name="japanese-era-change"></a>日本語の era 変更

[日本語の era のためにアプリケーションの環境の準備を変更する](../design/globalizing/japanese-era-change.md)と、アプリケーションは、日本語の時代を設定を変更する準備が、Windows が 2019 年 5 月 1 日に配置することを確認する方法を示します。 [このページは日本語でも利用できます](https://docs.microsoft.com/ja-jp/windows/uwp/design/globalizing/japanese-era-change)。

## <a name="videos"></a>ビデオ

### <a name="progressive-web-apps"></a>プログレッシブ Web アプリ

プログレッシブ Web アプリは、さまざまなブラウザーやさまざまな Windows 10 デバイス間でネイティブのアプリと同様に機能する web サイトです。 について[は、ビデオ](https://youtu.be/ugAewC3308Y)をし、[チェック アウト、ドキュメント](http://aka.ms/Windows-PWA)を開始します。

### <a name="vs-code-series"></a>VS コード シリーズ

VSCode は、それを使用する方法およびがその作成方法については、 [Visual Studio Code で新しいビデオ シリーズ](https://www.youtube.com/playlist?list=PLlrxD0HtieHjQX77y-0sWH9IZBTmv1tTx)を確認します。

### <a name="one-dev-question"></a>1 つのデベロッパー質問

デベロッパー質問の 1 つのビデオ シリーズの長い Microsoft 開発者は一連の Windows の開発、チームのカルチャと履歴に関する質問について説明します。 お答えした最新の質問を以下に示します。

Raymond Chen:

* [Program Files と Program Files (x86) と理由があるかどうか。](https://youtu.be/N7o9eJpFYco)

Larry Osterman:

* [COM はなぜですので複雑なかどうか。](https://youtu.be/-gkXAV-StVA )
* [Microsoft のように、最初のインタビューされたかどうか。](https://youtu.be/qRb6otsHG5c)
