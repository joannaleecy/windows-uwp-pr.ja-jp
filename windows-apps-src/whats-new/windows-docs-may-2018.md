---
title: 2018 年 5 月 Windows Docs の新 - UWP アプリを開発します。
description: 2018 年 5 月の Windows 10 開発者向けドキュメントを Microsoft Build カンファレンスの新機能、ビデオ、および開発者向けガイダンスが追加されました。
keywords: 新機能については、更新、機能、開発者向けのガイダンスについては、Windows 10、月、ビルド
ms.date: 05/07/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 69df2bbe8bc91fcf4a2631c0f257fc44851c24f2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598787"
---
# <a name="whats-new-in-the-windows-developer-docs-in-may-2018"></a>新機能については、Windows 開発者向けドキュメントで 2018 年 5 月です。

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 次の機能の概要、開発者ガイド、ビデオ、およびサンプル利用可能なと一致する月の 1 か月間、 [Microsoft Build 2018](https://www.microsoft.com/build)デベロッパー カンファレンス。

Windows 10 の[ツールと SDK をインストール](https://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="motion-in-fluent-design"></a>Fluent デザインの動作

タイミング、イージング、方向性、および重力の基礎の上に構築された、Fluent Design System のモーションのユーザーが進化しています。 これらの基本を適用する、アプリでは、ユーザーに役立ち、自然な世界を反映してデジタル エクスペリエンスを接続します。 この記事で詳細情報。

* [モーション概要](../design/motion/index.md)がこれらの基本を反映するように更新されました。
* [モーションの実習で](../design/motion/motion-in-practice.md)アプリ内でこれらの基本を適用する方法の例を示します。
* [方向性と重力](../design/motion/directionality-and-gravity.md)アプリのユーザーのメンタル モデルが塗りつぶされます。
* [タイミングと、イージング](../design/motion/timing-and-easing.md)リアリティをアプリ内のモーションに追加します。

![アニメーションの動作](../design/motion/images/contextual.gif)

### <a name="fluent-design-updates"></a>Fluent デザインの更新

次のページの Fluent デザイン、ビジュアルの更新と軽微な変更が加えられました。

* [配置、余白のパディング](../design/layout/alignment-margin-padding.md)
* [色](../design/style/color.md)
* [コマンドの基本](../design/basics/commanding-basics.md)
* [Windows アプリの Fluent デザイン](../design/fluent-design-system/index.md)
* [アプリの設計の概要](../design/basics/design-and-ui-intro.md)
* [ナビゲーションの基本](../design/basics/navigation-basics.md)
* [レスポンシブ デザイン手法](../design/layout/responsive-design.md)
* [画面のサイズとブレークポイント](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)
* [スタイルの概要](../design/style/index.md)
* [文書のスタイル](../design/style/writing-style.md)

さらに、すべて新しい情報のコンテンツ領域で、次のページを書き換えることしました。

* [アイコン](../design/style/icons.md)アイコンを使用して、クリック可能にすることのようになりました実際的な推奨事項を提供します。
* [文字体裁](../design/style/typography.md)更新されたガイダンスと図を 1 か所ですべて記述して、類似した記事からの情報を統合します。

![色パレットの画像](../design/style/images/color/accent-color-palette.svg)

### <a name="app-installer-files-in-visual-studio"></a>Visual Studio でアプリのインストーラー ファイル

アプリのインストーラー ファイルは、Visual Studio 2017 を更新 15.7 で今すぐ作成できます。 [Visual Studio を使用して、アプリのインストーラー ファイルを作成する方法について説明します](../packaging/create-appinstallerfile-vs.md)アプリへの自動更新を有効にします。 問題に実行する場合は、次を参照してください。[アプリのインストーラー ファイルのインストールの問題のトラブルシューティング](../packaging/troubleshoot-appinstaller-issues.md)一般的な問題とソリューションを表示します。

### <a name="edge-webview-control-for-windows-forms-and-wpf-applications"></a>Windows フォームおよび WPF アプリケーションの WebView コントロールをエッジします。

以前は UWP アプリケーションにのみ使用、WebView コントロールを使用して、デスクトップ アプリケーションで web コンテンツを表示します。 このコントロールは、リモート web サーバー、動的に生成されたコード、またはコンテンツ ファイルからコンテンツを埋め込むレンダリングは、HTML を表現力豊かな書式設定されたビュー エンジンをレンダリングする Microsoft Edge を使用します。 最新のリリースでは、WebView コントロールを検索、 [Windows コミュニティ ツールキット。](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)

Web ビューは、Windows の Community Toolkit の今後のリリースと同様に、その他のコントロールを探します。 詳細については、次を参照してください。 [WPF と Windows フォーム アプリケーションでホスト UWP を制御します。](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls)

### <a name="gaze-input-and-interactions"></a>視線入力との相互作用

[ユーザーの視線の先、注意、および場所と娘の動きに基づいてプレゼンスを追跡します。](../design/input/gaze-interactions.md) 強力な新しい方法を使用して、UWP アプリと対話は、支援技術として特に便利です。 視線入力には、ゲーム (追跡とターゲットの取得を含む) と従来の入力デバイス (キーボード、マウス、タッチ) は使用できませんの他の対話型のシナリオの両方の説得力のある機会も提供します。

### <a name="msix-packaging-format"></a>MSIX パッケージの形式

Microsoft Build 2018 conference で発表された、MSIX は、Win32、Windows フォーム、WPF、および UWP を含むすべての Windows アプリケーションに適用される、新しいパッケージのコンテナー化形式です。 この新しい形式では、UWP の優れた機能を継承します。

* 堅牢なインストールおよび更新します。 
* 柔軟な機能のシステムとセキュリティ モデルを管理します。
* Microsoft Store、エンタープライズ管理、および多くのカスタムの配布モデルをサポートします。

これらのパッケージを作成するツールは、Visual Studio と Windows SDK の将来のリリースで使用できるになります。

MSIX パッケージの形式は、簡単で、ツールやソリューション MSIX エコシステムをサポートするために、パートナーのオープン ソース形式です。 MSIX のパッケージ形式の詳細については、次を参照してください。 [MSIX SDK](https://github.com/Microsoft/msix-packaging)します。 

![MSIX パッケージのイメージ](images/msix.png)

### <a name="optional-packages-with-executable-code"></a>実行可能コードによるオプション パッケージ

アプリでの省略可能なパッケージが実行可能ファイルを含めることができますようになりましたC#コード。 [Visual Studio を使用して、メイン アプリ パッケージをサポートするために省略可能なアドオン パッケージを構成する方法について説明します。](../packaging/optional-packages-with-executable-code.md)

### <a name="page-transitions"></a>ページ切り替え効果

[ページの切り替え](../design/motion/page-transitions.md)ユーザー、アプリ内のページ間を移動します。 ユーザーが、ナビゲーション階層内を理解し、ページ間のリレーションシップに関するフィードバックを提供できます。

### <a name="project-rome"></a>Project Rome

プロジェクト ローマ チームは、iOS と Android Sdk、ユーザー アクティビティなどの新機能を追加して、各種の Sdk の間で一貫したプログラミング エクスペリエンスを提供するようにコードの多くをリファクタリングを一新しました。 [すべての新しい API のリファレンスと使い方 docs](https://docs.microsoft.com/windows/project-rome/) Build 2018 の開発者会議中にライブ移動します。

### <a name="sets"></a>セット

セット機能は、Windows の Insider preview ビルドで使用できます。 セットの機能を使用する場合は、タイトル バー内に独自のタブを持つ各アプリでの他のアプリで共有されるウィンドウにアプリが描画されます。 

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="get-started"></a>はじめに

Get revitalized した新しい学習トラックのコンテンツを開始します。 これらの新しいトピックは、開発者に提供する新しい Windows 10 を実行することがいくつかの一般的なタスクに関する情報を目指します。 携帯用チュートリアルを指定しないとが代わりに既存のドキュメントが存在し、その使用方法を指摘するチュートリアルがないです。 チェック アウト、刷新[コーディングを始める](../get-started/create-uwp-apps.md)ページ、または各個々 の学習トラックの詳細。

* [フォームを作成します。](../get-started/construct-form-learning-track.md)
* [一覧で顧客を表示](../get-started/display-customers-in-list-learning-track.md)
* [保存し、読み込みの設定](../get-started/settings-learning-track.md)
* [ファイルを使用します。](../get-started/fileio-learning-track.md)

![起動イメージを取得します。](../get-started/images/build-your-app.png)

### <a name="advertising-performance-report"></a>広告パフォーマンス レポート

[パフォーマンス レポートをアドバタイズ](../publish/advertising-performance-report.md)パートナー センターでの見やすさがメトリックを提供しますようになりました。 追加しました、 [ad ユニットの見やすさを最適化](../monetize/optimize-ad-unit-viewability.md)広告の見やすさを最適化するための推奨事項を提供する記事です。

### <a name="targeted-push-notifications"></a>ターゲット プッシュ通知

[通知](../publish/send-push-notifications-to-your-apps-customers.md)パートナー センターでのページは、グラフ、および世界中のマップ ビューのすべての通知の追加の分析データを提供するようになりました。

## <a name="videos"></a>ビデオ

### <a name="cwinrt"></a>C++/WinRT

C +/cli WinRT は、新しい方法を作成して、Windows ランタイム Api を使用します。 ヘッダー ファイルに唯一の実装は、最新のアプリの機能を最適にアクセスを提供するために設計されています。 [ビデオを見る](https://www.youtube.com/watch?v=TLSul1XxppA&feature=youtu.be)については、その動作し、[開発者向けドキュメントを読み取る](../cpp-and-winrt-apis/index.md)の詳細。

### <a name="multi-instance-uwp-apps"></a>マルチインスタンスの UWP アプリ

Windows を使用して、それぞれに個別のプロセスで、UWP アプリの複数のインスタンスを実行することできるようになりました。 [ビデオを見る](https://www.youtube.com/watch?v=clnnf4cigd0&feature=youtu.be)し、この機能をサポートする新しいアプリを作成する方法について[開発者向けドキュメントを読み取る](../launch-resume/multi-instance-uwp.md)方法の詳細についてのガイダンスとこの機能を使用する理由。

## <a name="samples"></a>サンプル

### <a name="customer-database-tutorial"></a>顧客データベースのチュートリアル

このチュートリアルでは、顧客の一覧を管理するための基本的な UWP アプリを作成し、概念と実践についてエンタープライズ開発に便利ですが導入されています。 UI 要素を実装して、ローカルの SQLite データベースに対する操作を追加することを説明し、さらに移動する場合は、REST のリモート データベースに接続するための緩やかなガイダンスを提供します。 [ここでチュートリアルをご覧ください。](../enterprise/customer-database-tutorial.md)