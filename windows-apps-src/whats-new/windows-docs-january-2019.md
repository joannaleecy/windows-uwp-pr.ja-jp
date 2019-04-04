---
title: 2019 年 1 月の新 Windows ドキュメント - UWP アプリを開発します。
description: 2019 年 1 月の Windows 10 開発者向けドキュメントに追加された新機能、ビデオ、および開発者向けガイダンス
keywords: 新機能については、更新、機能、開発者ガイド、Windows 10 では、年 1 月
ms.date: 01/17/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: beb80c28866b8f8207f203b70cb504dcd034098d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636577"
---
# <a name="whats-new-in-the-windows-developer-docs-in-january-2019"></a>新機能については、Windows 開発者向けドキュメントで 2019 年 1 月です。

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 次の機能の概要、開発者ガイド、およびビデオが年 1 月の 1 か月間利用可能な加えられました。

Windows 10 の[ツールと SDK をインストール](https://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="windows-development-on-microsoft-learn"></a>Microsoft の学習での Windows 開発

Microsoft の学習は、Microsoft の開発者に新しい実践的な学習とトレーニングの機会を提供します。 Windows アプリを開発する方法を学習する場合は、チェック アウト[、新規のラーニング パス](https://docs.microsoft.com/learn/paths/develop-windows10-apps/)徹底的な概要については、プラットフォーム、ツール、および、最初のいくつかのアプリを記述する方法。

![ラーニング パス Windows 開発の画像](images/windows-learn.png)

### <a name="direct-3d-12"></a>Direct 3D 12

[Direct3d12 のレンダリング パス](/windows/desktop/direct3d12/direct3d-12-render-passes)パフォーマンスを向上できます、レンダラーの延期タイル ベースのレンダリング (TBDR) に基づく場合などのテクニックです。 リソースの表示順序要件とデータの依存関係を識別するために、アプリケーションを有効にするチップをメモリとの間のメモリ トラフィックを削減して GPU の効率を向上させるために、このレンダラーをによりします。

### <a name="msix-modification-packages"></a>MSIX 変更パッケージ

Windows 10 バージョン 1809 のサポート強化[MSIX 変更パッケージ](https://docs.microsoft.com/windows/msix/modification-package-1809-update)します。 変更のパッケージは、レジストリ ベースのプラグインと、関連付けられているカスタマイズを含めることができます、MSIX 仮想レジストリを使用して、想定どおりに実行を使用してデプロイされたアプリケーションを有効になります。

![MSIX 修正パッケージの作成](images/msix-modification-package.png)

### <a name="open-source-of-wpf-windows-forms-and-winui"></a>WPF、Windows フォーム、および WinUI のオープン ソース

GitHub のオープン ソース コントリビューションの WPF、Windows フォーム、および WinUI UX のフレームワークがあるようになりました。 詳細な情報とリンクについては、、 [building Windows アプリのブログ](https://blogs.windows.com/buildingapps/2018/12/04/announcing-open-source-of-wpf-windows-forms-and-winui-at-microsoft-connect-2018/#OKZjJs1VVTrMMtkL.97)を参照してください。

### <a name="progressive-web-apps-for-xbox"></a>プログレッシブ Web Apps for Xbox

[Xbox One の Web アプリをプログレッシブ](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/xbox-considerations)、web アプリケーションを拡張し、使用できるように Xbox One のアプリケーションとして Microsoft Store を使用して、既存のフレームワーク、CDN、およびサーバーのバックエンドを使用する継続しているときにすることができます。 ほとんどの場合、パッケージ化して、PWA Xbox One の Windows の場合と同じ方法で、ただし、このガイドの説明をいくつかの主な違いがあります。

### <a name="windows-machine-learning"></a>Windows Machine learning

私たちにして再構築した[WinML Api のランディング ページ](https://docs.microsoft.com/windows/ai/api-reference)、WinML カスタム演算子とネイティブ Api の新しいドキュメントを追加します。

[PyTorch を持つモデルをトレーニング](https://docs.microsoft.com/windows/ai/train-model-pytorch)PyTorch フレームワークをローカルまたはクラウドのいずれかを使用してモデルをトレーニングする方法について説明します。 このモデルを ONNX ファイルとしてダウンロードし、WinML アプリケーションで使用します。

![WinML グラフィック](images/winml-graphic.png)

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="choose-your-platform"></a>プラットフォームを選択します

新しいデスクトップ アプリケーションの作成に興味はあるでしょうか。 チェック アウト、刷新[プラットフォームを選択](https://docs.microsoft.com/windows/desktop/choose-your-technology)詳細な説明と、UWP、WPF、および Windows フォームのプラットフォームと Win32 API の詳細についての比較ページ。

### <a name="faqs-on-win32-webview"></a>Win32 の WebView でよく寄せられる質問

この[よく寄せられる質問](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview#frequently-asked-questions-faqs)サンプルとその他のリソースにリンクするほかのデスクトップ アプリケーションで Microsoft Edge の WebView を使用する場合は、よく寄せられる質問に対する回答を提供します。

### <a name="japanese-era-change"></a>日本語の時代 (年号) の変更

[日本語の時代 (年号) 変更するアプリケーションを準備](../design/globalizing/japanese-era-change.md)アプリケーションは、日本語の時代 (年号) をセットの変更の準備ができて、Windows は、2019 年 5 月 1 日に配置することを確認する方法を示します。 [このページは日本語で利用可能なも](https://docs.microsoft.com/ja-jp/windows/uwp/design/globalizing/japanese-era-change)します。

## <a name="videos"></a>ビデオ

### <a name="progressive-web-apps"></a>プログレッシブ Web アプリ

プログレッシブ Web アプリは、さまざまなブラウザーおよび Windows 10 デバイスのさまざまなネイティブ アプリのように機能する web サイトです。 [ビデオを見る](https://youtu.be/ugAewC3308Y)詳細については、し[ドキュメントのチェック アウト](https://aka.ms/Windows-PWA)を開始します。

### <a name="vs-code-series"></a>VS コード シリーズ

チェック アウト、 [Visual Studio Code での新しいビデオ シリーズ](https://www.youtube.com/playlist?list=PLlrxD0HtieHjQX77y-0sWH9IZBTmv1tTx)VSCode は、それを使用する方法との作成方法についてはします。

### <a name="one-dev-question"></a>開発用の 1 つの質問

開発用の 1 つの質問のビデオ シリーズでは、マイクロソフトのベテランの開発者は、一連の Windows の開発、チームのカルチャ、および履歴に関する質問を説明します。 お答えした最新の質問を次に示します。

Raymond Chen:

* [プログラム ファイルとプログラム ファイル (x86) があるなぜでしょうか。](https://youtu.be/N7o9eJpFYco)

Larry Osterman の場合:

* [COM を理由には複雑ではなさそうですか?](https://youtu.be/-gkXAV-StVA )
* [Microsoft のように、最初のインタビューとは何でしたか。](https://youtu.be/qRb6otsHG5c)
