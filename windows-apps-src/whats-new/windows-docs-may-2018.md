---
author: QuinnRadich
title: 月 2018年で Windows ドキュメントの新機能 - UWP アプリの開発
description: Windows 10 の開発者が 2018年ドキュメントを Microsoft ビルド会議、新機能やビデオなど、開発者向けのガイダンスが追加されました。
keywords: 新機能は、更新、機能、開発については、Windows 10、月、ビルド
ms.author: quradic
ms.date: 5/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 322bc056411095019dfc027078cbfef7de0883fb
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2887871"
---
# <a name="whats-new-in-the-windows-developer-docs-in-may-2018"></a>月 2018年では、Windows の開発ドキュメントの新機能します。

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 次の機能の概要、開発者向けのガイダンス、ビデオ、およびサンプル加えられた、5 月[Microsoft ビルド 2018年](https://www.microsoft.com/build)開発会議と一致するのでは使用できます。

Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="motion-in-fluent-design"></a>Fluent デザインのアニメーション

タイミングを容易に、方向、重要性、およびの基礎に組み込まれ、アニメーション Fluent デザイン システムでのユーザーが発展します。 これらの基礎を適用するアプリでは、ユーザーに役立つし、その接続、デジタル エクスペリエンスで自然世界を反映しています。 この記事の詳細情報。

* これらの基礎を反映するように、 [[アニメーションの概要](../design/motion/index.md)が更新されました。
* [アニメーション-での演習](../design/motion/motion-in-practice.md)では、アプリ内でこれらの基礎を適用する方法の例を示します。
* [重要性、および方向](../design/motion/directionality-and-gravity.md)には、アプリのユーザーの頭の中のモデルが塗りつぶされます。
* [タイミングと容易に](../design/motion/timing-and-easing.md)は、アプリのアニメーションにリアルを追加します。

![アニメーションの使用例](../design/motion/images/contextual.gif)

### <a name="fluent-design-updates"></a>Fluent デザインの更新プログラム

次の Fluent デザイン ページに視覚的な更新プログラムと小さな変更が加えられました。

* [配置、間隔、余白](../design/layout/alignment-margin-padding.md)
* [Color](../design/style/color.md)
* [コマンドの基本](../design/basics/commanding-basics.md)
* [Windows アプリの fluent デザイン](../design/fluent-design-system/index.md)
* [アプリのデザインの概要](../design/basics/design-and-ui-intro.md)
* [ナビゲーションの基本](../design/basics/navigation-basics.md)
* [レスポンシブ デザインの手法](../design/layout/responsive-design.md)
* [画面のサイズとブレークポイント](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)
* [スタイルの概要](../design/style/index.md)
* [記述スタイル](../design/style/writing-style.md)

さらに、そのコンテンツ領域に新しい情報では、次のページを再作成したこと。

* [アイコン](../design/style/icons.md)には、アイコンを使用して、選択できるようにするためのアドバイスが用意されています。
* [文字体裁](../design/style/typography.md)では、更新されたガイダンスやイラストを 1 つの場所に配置するすべてのような記事、情報を統合します。

![カラー パレットの画像](../design/style/images/color/accent-color-palette.svg)

### <a name="app-installer-files-in-visual-studio"></a>Visual Studio でアプリのインストーラー ファイル

アプリのインストーラー ファイルは、Visual Studio 2017、更新 15.7 を今すぐ作成できます。 アプリを自動更新を[App インストーラー ファイルを作成するのには、Visual Studio を使用する方法について説明](../packaging/create-appinstallerfile-vs.md)し、有効にします。 問題が発生を実行している場合は、一般的な問題と解決策を表示する[アプリのインストーラー ファイルがインストールに関する問題のトラブルシューティング](../packaging/troubleshoot-appinstaller-issues.md)を参照してください。

### <a name="edge-webview-control-for-windows-forms-and-wpf-applications"></a>Windows フォームと WPF アプリケーションの web 表示コントロールをエッジします。

デスクトップ アプリケーションでのみアプリケーションで使用 UWP web 表示コントロールを使用して web コンテンツを表示します。 このコントロールを埋め込むことレンダリング リッチ テキスト書式を HTML ビュー エンジンをリモート web サーバー、動的に生成されたコードやコンテンツ ファイルのコンテンツを表示する Microsoft Edge を使用します。 最新リリースでビューのコントロールを検索、 [Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)。

ビューは、Windows のコミュニティ ツールキットの今後のリリースと同様に、その他のコントロールを探します。 詳細については、次を参照してください[WPF と Windows フォームのアプリケーションでホスト UWP を制御します。](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-host-controls) 。

### <a name="gaze-input-and-interactions"></a>入力と相互作用された様子を確認します。

[ユーザーの視線、注意、および場所とユーザーの目の動きに基づくプレゼンスを追跡します。](../design/input/gaze-interactions.md) この強力な新しい方法を使用して、操作 UWP アプリでは、名前を付けて、支援技術製便利です。 注視入力ゲーム (進捗管理および購入の対象を含む) とその他の入力の旧式のデバイス (キーボード、マウス、タッチ) は使用できません対話型のシナリオの両方の説得力のある営業案件を提供します。

### <a name="msix-packaging-format"></a>MSIX パッケージの書式設定

Microsoft ビルド 2018年会議で発表、MSIX は、Win32、Windows フォーム、WPF UWP を含むすべての Windows アプリケーションに適用する新しいコンテナリゼーション パッケージ形式です。 この新しい形式では、UWP からとても便利な機能を継承します。

* 堅牢なインストールおよび更新します。 
* 柔軟な機能をシステムとセキュリティ モデルを管理します。
* Microsoft ストア、エンタープライズ管理、およびカスタム分布モデルの多くをサポートします。

これらのパッケージを作成するツールは、Visual Studio と Windows SDK の将来のリリースで表示されます。

MSIX パッケージの書式設定は、ファイルを開く形式のツールとソリューション MSIX システムをサポートするパートナーに簡単です。 MSIX パッケージ形式の詳細については、 [MSIX SDK](https://github.com/Microsoft/msix-packaging)を参照してください。 

![MSIX パッケージの画像](images/msix.png)

### <a name="optional-packages-with-executable-code"></a>実行可能コードによるオプション パッケージ

オプションのパッケージのアプリでは、実行可能な c# コードを含めることができますようになりました。 [Visual Studio を使って、メインのアプリ パッケージをサポートするオプションのアドオン パッケージを構成する方法について説明します。](../packaging/optional-packages-with-executable-code.md)

### <a name="page-transitions"></a>ページ切り替え効果

[ページの画面切り替え](../design/motion/page-transitions.md)には、アプリ内のページ間でユーザーが移動します。 やすく、ナビゲーション階層] になっているを理解し、ページ間のリレーションシップに関するフィードバックを提供します。

### <a name="project-rome"></a>Project Rome

プロジェクト ローマ チームは、その iOS および Android Sdk、ユーザーのアクティビティなどの新しい機能を追加して、リファクタリング異なる Sdk 全体で一貫したプログラミング エクスペリエンスを提供する、コードの多くを一新しました。 [すべての新しい API 参照と操作方法のドキュメント](https://docs.microsoft.com/windows/project-rome/)が移動ライブ ビルド 2018年開発会議中にします。

### <a name="sets"></a>セット

設定機能は、プレビュー ビルド Windows 内部で使用します。 セット機能を使用している場合は、タイトル バーに固有のタブを持つ各アプリでは、その他のアプリと共有できるウィンドウにするアプリが描画されます。 [セットのデザイン](../design/shell/design-for-sets.md)の設定の UI に最適な操作性を提供するアプリを最適化する方法のガイダンスがあります。

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="get-started"></a>はじめに

弊社 Get お revitalized した新しいラーニング トラックのコンテンツを開始します。 新しいトピックについての一般的なタスクを実行するように、新しい Windows 10 の開発者を提供することを目的とします。 チュートリアルではない携帯チュートリアルについては提供されませんが、代わりに、既存のドキュメントが存在してその使い方をポイントします。 チェック アウト改良[コーディングを開始](../get-started/create-uwp-apps.md)] ページまたは各個々 のラーニング履歴の記録を使ってみる。

* [フォームの作成](../get-started/construct-form-learning-track.md)
* [一覧での顧客の表示](../get-started/display-customers-in-list-learning-track.md)
* [保存と読み込みの設定](../get-started/settings-learning-track.md)
* [ファイルの操作](../get-started/fileio-learning-track.md)

![開始のイメージを取得します。](../get-started/images/build-your-app.png)

### <a name="advertising-performance-report"></a>広告パフォーマンス レポート

デベロッパー センターのダッシュ ボードで[広告のパフォーマンス レポート](../publish/advertising-performance-report.md)は、今すぐ見やすさメトリックを提供します。 また、広告の見やすさを最適化するための推奨事項を提供する[最適化見やすさが、ad 単位の](../monetize/optimize-ad-unit-viewability.md)記事を追加しました。

### <a name="targeted-push-notifications"></a>対象となるプッシュ通知

これで、デベロッパー センターのダッシュ ボードの [[通知](../publish/send-push-notifications-to-your-apps-customers.md)] ページは、グラフ、および世界地図のビューで、すべての通知の分析を追加データを提供します。

## <a name="videos"></a>ビデオ

### <a name="cwinrt"></a>C++/WinRT

C + +/WinRT は新しい方法のドキュメントの編集と Windows ランタイム Api を使用します。 単独を実装してヘッダー ファイルには、モダンなアプリの機能への最上位のアクセスを提供するために設計されています。 [ビデオを見る](https://www.youtube.com/watch?v=TLSul1XxppA&feature=youtu.be)をについては、実際の操作、し、さらに詳しい情報[開発ドキュメントを参照](../cpp-and-winrt-apis/index.md)します。

### <a name="multi-instance-uwp-apps"></a>マルチインスタンスの UWP アプリ

Windows を使用して、別のプロセスでは、独自の各 UWP アプリの複数のインスタンスを実行できるようになりました。 この機能を使用する理由と方法の詳細について、この機能は、[[開発ドキュメントを参照](../launch-resume/multi-instance-uwp.md)をサポートしている新しいアプリを作成する方法については、[ビデオを見ます](https://www.youtube.com/watch?v=clnnf4cigd0&feature=youtu.be)。

## <a name="samples"></a>サンプル

### <a name="customer-database-tutorial"></a>顧客のデータベースのチュートリアル

このチュートリアルでは、顧客の一覧を管理するための基本的な UWP アプリを作成し、概念とエンタープライズ開発で便利な方法を紹介します。 UI 要素を実装すると、ローカル SQLite データベースに対する操作の追加について説明し、さらに移動したい場合は、残りのリモート データベースに接続するための柔軟なガイダンスを提供します。 [チェック アウトは、次のチュートリアル](../enterprise/customer-database-tutorial.md)