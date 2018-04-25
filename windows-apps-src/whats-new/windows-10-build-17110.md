---
author: QuinnRadich
title: Windows 10 の開発者向け新着情報、ツール、機能
description: Windows 10 ビルド 17110 と新しい開発者ツールでは、ユニバーサル Windows プラットフォームによって強化されたツール、機能、エクスペリエンスを利用できます。
keywords: 新着情報, 新機能, 更新, 更新情報, 機能, 新しい, Windows 10, 最新, 開発者, 17110, プレビュー
ms.author: quradic
ms.date: 3/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: high
ms.openlocfilehash: 518cc64fec2524bb3cc02daca72a990d016c8ce5
ms.sourcegitcommit: 1eabcf511c7c7803a19eb31f600c6ac4a0067786
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
---
# <a name="whats-new-in-windows-10-for-developers-sdk-preview-build-17110"></a>Windows 10 の開発者向け新着情報 (SDK プレビュー ビルド 17110)

Windows 10 SDK プレビュー ビルド 17110 には、Visual Studio 2017 および更新された SDK の組み合わせで、優れたユニバーサル Windows プラットフォーム アプリを作るためのツール、機能、エクスペリエンスが用意されています。 Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

ここには、Windows 開発者にとって重要な SDK プレビューの新機能、強化された機能、ガイダンスを集めました。 現時点では、これらの機能は [Windows Insider Program](https://insider.windows.com/) のメンバーからアクセス可能であり、Windows 10 の次の主要な更新プログラムで一般に公開される予定です。 Windows SDK に追加されたすべての新しい名前空間の一覧については、[Windows 10 ビルド 17110 の新しい API](windows-10-build-17110-api-diff.md) をご覧ください。Windows 10 での注目すべき機能について詳しくは、「[Windows 10 の優れた機能](http://go.microsoft.com/fwlink/?LinkId=823181)」をご覧ください。 また、Windows プラットフォームに過去に追加された機能と今後追加される機能の概要については、[Windows 開発者向けプラットフォーム機能に関するページ](https://developer.microsoft.com/windows/platform/features)をご覧ください。

## <a name="design--ui"></a>設計および UI

機能 | 説明
 :------ | :------
アダプティブ トースト通知と対話型トースト通知 | アダプティブ トースト通知と対話型トースト通知で、アプリを強化できます。 まず[トースト通知に関する最新のガイダンス](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)で、イメージ サイズの制限、進行状況バー、入力オプションの最新情報をご確認ください。
コンテンツ リンク | 新しい[コンテンツ リンク](../design/controls-and-patterns/content-links.md) コントロールを使用すると、テキスト コントロールにリッチ データを埋め込むことができます。これによってユーザーは、アプリのコンテキストから離れることなく、人物や場所に関する詳しい情報を見つけることができます。
設計のサンプル | [設計ツールキットとサンプル](../design/downloads/index.md)のページに、BuildCast サンプルが追加されました。 BuildCast は、Fluent Design System と、ユニバーサル Windows プラットフォームの他の機能を示すために組み込まれているエンド ツー エンドのサンプルです。
埋め込みの手書き入力機能 | [テキスト コントロール](../design/controls-and-patterns/text-controls.md)にペン入力機能が追加されました。ユーザーは Windows Ink を使用して、テキスト ボックスに手書きで直接入力できます。 ユーザーが手書きで入力すると、文字は自然な手書き感を維持して活字に変換されます。
Fluent Design の更新 | 多くの Fluent Design ページが新しい情報とガイダンスで更新されました。 </br> * [Fluent Design の概要](../design/fluent-design-system/index.md)ページも、最新の Fluent 機能を反映して更新されています。 </br> * 「[表示ハイライト](../design/style/reveal.md)」には、テーマおよびカスタム コントロールに関する新しいガイダンスが追加されています。 </br> * 「[ナビゲーション履歴と前に戻る移動](../design/basics/navigation-history-and-backwards-navigation.md)」は刷新され、詳しい例、デバイス最適化のガイダンス、カスタム動作に関するガイドラインが掲載されています。
ページ レイアウト | [XAML ページ レイアウト](../design/layout/layouts-with-xaml.md)に関するドキュメントが更新され、柔軟なレイアウトと表示状態の情報が新しく追加されました。 これらの機能を使用すると、使用できる表示領域に合わせてアプリ内の要素の位置がどのように呼応するかをさらに細かく制御できます。
引っ張って更新 | "[引っ張って更新](../design/controls-and-patterns/pull-to-refresh.md)" コントロールを使うと、ユーザーはデータのリストを引き下げて、より多くのデータを取得することができます。 この操作は、タッチ スクリーンを備えたデバイスで広く使用されます。
ナビゲーション ビュー | [ナビゲーション ビュー](../design/controls-and-patterns/navigationview.md) コントロールでは、アプリ内でトップレベルのナビゲーションを行うための折りたたみ可能なナビゲーション メニューを提供します。 このコントロールは、ナビゲーション ウィンドウ (またはハンバーガー メニュー) パターンを実装し、ウィンドウの表示モードをさまざまなウィンドウ サイズに自動的に合わせます。
表示フォーカス | 新しい[表示フォーカス](../design/style/reveal-focus.md)効果では、Xbox One やテレビ画面などのエクスペリエンスに発光効果を提供します。 ユーザーがゲームパッドやキーボードのフォーカスをボタンなどのフォーカス可能な要素に移動したときに、その要素の境界線がアニメーション化されます。
サウンド | XAML では、**SpatialAudioMode** プロパティで 3D オーディオがサポートされるようになりました。 構成方法については、「[サウンド](../design/style/sound.md)」をご覧ください。
ツリー ビュー | [TreeView](../design/controls-and-patterns/tree-view.md) コントロールを使用すると、階層リストが有効になり、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができるようになります。 フォルダー構造や入れ子になった関係を UI で視覚的に示すために使用できます。
記述スタイル | 文体と語調に関する記事を更新および拡張し、[記述スタイルに関するガイダンス](../design/style/writing-style.md)を作成しました。 この新しいガイドでは、アプリ内に効果的なテキストを作成するための原則と、エラー メッセージやダイアログなどのコントロールに使用する記述スタイルのベスト プラクティスを示しています。

## <a name="gaming"></a>ゲーム
機能 | 説明
 :------ | :------
ゲーム開発の概要 | Windows 10 用のゲーム開発に関心をお持ちですか?  新しい[ゲーム開発の作業の概要](../gaming/getting-started.md)ページでは、セットアップ、登録、アプリとゲームの申請準備のために必要な作業全体の概要を示します。
グラフィックス アダプター | 以下の DXGI API が追加されました。これらは、グラフィックス アダプターの基本設定と削除に関連しています。 </br> * [IDXGIFactory6](https://msdn.microsoft.com/library/windows/desktop/mt814823) インターフェイスでは、GPU 基本設定に基づいてグラフィックス アダプターを列挙する単一のメソッドが有効になります。 </br> * [DXGIDeclareAdapterRemovalSupport](https://msdn.microsoft.com/library/windows/desktop/mt814821) 関数を使用すると、グラフィックス デバイスの削除に対してプロセスで対応可能であると示すことができます。 </br> * [DXGI_GPU_PREFERENCE](https://msdn.microsoft.com/library/windows/desktop/mt814822) 列挙では、アプリを実行する GPU の基本設定を記述します。


## <a name="develop-windows-apps"></a>Windows アプリの開発

機能 | 説明
 :------ | :------
アダプティブ カード | [アダプティブ カード](https://docs.microsoft.com/adaptive-cards/)は、カード交換のオープン フォーマットであり、開発者は一貫性のある共通した方法で UI コンテンツを交換できます。 アダプティブ カードでは JSON オブジェクトとしてコンテンツを記述し、ホスト アプリケーションの外観に自動的に適合するようにレンダリングできます。
アプリ リソース グループ | [AppResourceGroupInfo](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupinfo) クラスには、アプリの状態を中断、アクティブ (再開済み)、または終了の状態に移行する処理を開始するための新しいメソッドが含まれています。
ファイル システムへの幅広いアクセス | **broadFileSystemAccess** 機能を使用すると、ファイル ピッカー スタイルのプロンプトを使用しなくても、アプリはファイル システムに対して、アプリを実行中のユーザーと同じアクセス許可を獲得できます。 詳しくは、「[ファイル アクセス許可](../files/file-access-permissions.md)」と、「[アプリ機能の宣言](../packaging/app-capability-declarations.md)」の **broadFileSystemAccess** をご覧ください。
コンソール UWP アプリ | C++ /WinRT または /CX の UWP コンソール アプリを作成して、DOS や PowerShell などのコンソール ウィンドウで実行できるようになりました。 コンソール アプリでは、入出力にコンソール ウィンドウを使用します。 UWP コンソール アプリは、Microsoft Store に公開することも、アプリの一覧に追加することもできます。また、プライマリ タイルとしてスタート メニューにピン留めすることもできます。 詳しくは、[ユニバーサル Windows プラットフォーム コンソール アプリの作成](../launch-resume/console-uwp.md)に関するページをご覧ください。
アクセシビリティ対応技術 (AT) 用にサポートされているランドマークと見出し | ランドマークと見出しは、ユーザー インターフェイスのセクションを定義し、スクリーン リーダーなどのアクセシビリティ対応技術のユーザーの効率的なナビゲーションに役立ちます。 詳しくは、[ランドマークと見出し](../design/accessibility/landmarks-and-headings.md)に関するページをご覧ください。
Machine Learning | Windows Machine Learning を使用すると、ローカルの事前学習済み機械学習モデルを Windows 10 デバイス上で評価するアプリを構築できます。 このプラットフォームについて詳しくは、「[Windows Machine Learning](../machine-learning/index.md)」をご覧ください。 </br> [MachineLearning](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview) 名前空間には、機械学習モデルを読み込み、データを入力としてバインドし、結果を評価するためのアプリを有効にするクラスが含まれています。
マップ コントロール | [MapControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol) クラスには、**Region** という名前の新しいプロパティが含まれています。これを使用すると、特定の地域 (州や県など) の言語に基づいてマップ コントロールにコンテンツを表示できます。
マップ要素 | [MapElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement) クラスには、**IsEnabled** という名前の新しいプロパティが含まれています。これを使用すると、ユーザーによる [MapElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement) との対話が可能かどうかを指定できます。
マップの場所の情報 | [PlaceInfo](https://docs.microsoft.com/uwp/api/windows.services.maps.placeinfo) クラスには、**CreateFromAddress** という新しいメソッドが含まれています。このメソッドでは、住所と表示名を使用して、[PlaceInfo](https://docs.microsoft.com/uwp/api/windows.services.maps.placeinfo) を作成できます。
マップ サービス | [MapRouteDrivingOptions](https://docs.microsoft.com/uwp/api/windows.services.maps.maproutedrivingoptions) クラスには、**DepartureTime** という名前の新しいプロパティが含まれています。これを使用すると、指定の日時に一般的な交通条件でルートを計算できます。
マルチインスタンスの UWP アプリ | UWP アプリでは、マルチインスタンスのサポートを選択できます。 マルチインスタンス UWP アプリのインスタンスが実行されていて、後続のライセンス認証要求が行われた場合、既存のインスタンスはアクティブ化されません。 代わりに、別のプロセスで実行される、新しいインスタンスが作成されます。 詳しくは、[マルチインスタンスのユニバーサル Windows アプリの作成](../launch-resume/multi-instance-uwp.md)に関するページをご覧ください。
PlayReady | Microsoft PlayReady は、デジタル コンテンツを保護して不正使用を防止するための一連のテクノロジです。 PlayReady は、デバイスやアプリの種類を問わず、あらゆるオペレーティング システム間で動作します。 [アプリに PlayReady を組み込む方法をご確認ください。](https://docs.microsoft.com/playready/)
画面のキャプチャ | [Windows.Graphics.Capture 名前空間](https://docs.microsoft.com/uwp/api/windows.graphics.capture) には、ディスプレイまたはアプリケーション ウィンドウからフレームを取得する API が用意されています。これにより、ビデオ ストリームやスナップショットを作成して、コラボレーティブでインタラクティブなエクスペリエンスを構築できます。 詳しくは、「[画面の取り込み](../audio-video-camera/screen-capture.md)」をご覧ください。
システム トリガー | [CustomSystemEventTrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.customsystemeventtrigger) を使用すると、必要なシステム トリガーが OS から提供されない場合に、システム トリガーを定義できます。 ハードウェア ドライバーと UWP アプリの両方がサード パーティ製であり、ハードウェア ドライバーでカスタム イベントを生成し、アプリで処理する必要がある場合などに必要になります。 例として、オーディオ ジャックが接続されたときに、オーディオ カードからユーザーに通知する場合などが該当します。
ユーザー アクティビティ | **UserActivitySessionHistoryItem**クラスには、最近のユーザー アクティビティを取得する新しいメソッドが含まれています。 詳しくは、[GetRecentUserActivitiesAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitychannel.getrecentuseractivitiesasync) およびそのオーバーロードの説明をご覧ください。
Windows Mixed Reality | 拡張中の Windows Mixed Reality プラットフォームをサポートするために、[Windows.Graphic.Holographic](https://docs.microsoft.com/uwp/api/Windows.Graphics.Holographic) 名前空間と [Windows.UI.Input.Spatial](https://docs.microsoft.com/uwp/api/Windows.UI.Input.Spatial) 名前空間に新しい API が追加されました。

## <a name="publish--monetize-windows-apps"></a>Windows アプリを公開および収益化する

機能 | 説明
 :------ | :------
特定市場の現地通貨で自由設定価格を入力する | 特定市場に対してアプリの基本価格を上書きすると、いずれかの標準価格帯を選択するという制約がなくなり、その市場の現地通貨で自由設定価格を入力できます。 詳しくは、「[アプリの価格の設定とスケジュール](../publish/set-and-schedule-app-pricing.md)」をご覧ください。 **この機能はすべての Windows 開発者が利用でき、更新された SDK は必要ありません。**
Microsoft Store コンテンツ | [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスが更新され、新しいメソッドが追加されました。 これらのメソッドでは、アプリのパッケージ更新プログラムおよびアドオンのダウンロードとインストールを管理します。
すべての開発者がサブスクリプション アドオンを利用できるようになりました | サブスクリプション アドオンを作成して公開すると、定期的な自動課金期間を設定して、アプリ内やゲーム内でデジタル製品 (アプリの機能やデジタル コンテンツなど) を販売できます。 詳しくは、「[アプリのサブスクリプション アドオンの有効化](../monetize/enable-subscription-add-ons-for-your-app.md)」をご覧ください。 **この機能はすべての Windows 開発者が利用でき、更新された SDK は必要ありません。**

## <a name="videos"></a>ビデオ

Fall Creators Update 以降、以下のビデオが公開されました。Windows 10 の開発者向け新機能および強化された機能が紹介されています。

### <a name="package-a-net-app-in-visual-studio"></a>Visual Studio で .NET アプリをパッケージ化する

デスクトップ アプリをこれまで以上に簡単にユニバーサル Windows プラットフォームに移行できます。 [ビデオ](https://www.youtube.com/watch?v=fJkbYPyd08w)で、配布用の .NET アプリをパッケージ化する方法をご覧ください。その後、[このページで詳細情報を確認](../porting/desktop-to-uwp-packaging-dot-net.md)してください。

### <a name="xbox-live-creators-program"></a>Xbox Live クリエーターズ プログラム

Xbox Live クリエーターズ プログラムでは、開発者が UWP ゲームを Xbox One と Windows 10 に簡単に公開できます。[ビデオ](https://www.youtube.com/watch?v=zpFfHHBkVq4)でプログラムの内容を確認し、[このページ](https://www.xbox.com/developers/creators-program)から開始してください。

### <a name="creating-3d-app-launchers-for-windows-mixed-reality"></a>Windows Mixed Reality 用 3D アプリ起動ツールの作成

3D 起動ツールとは、Mixed Reality のホーム環境にアプリの立体表現をユーザーが配置できるというユニークなものです。 3D モデルを準備してアプリの起動ツールとして割り当てる方法については、[ビデオをご覧ください](https://www.youtube.com/watch?v=TxIslHsEXno)。詳しくは、[開発者ドキュメント](https://developer.microsoft.com/windows/mixed-reality/implementing_3d_app_launchers)と[設計ガイダンス](https://developer.microsoft.com/windows/mixed-reality/3d_app_launcher_design_guidance)をご覧ください。

### <a name="motion-controller-tracking"></a>モーション コントローラーの追跡

Windows Mixed Reality では、モーション コントローラーがユーザーの手を表します。 モーション コントローラーが Mixed Reality ヘッドセットの視野の内外にあるときの動作については、[ビデオをご覧ください](https://www.youtube.com/watch?v=rkDpRllbLII)。[コントローラーのトラッキングについて詳しくは、こちらをご覧ください。](https://developer.microsoft.com/windows/mixed-reality/motion_controllers#controller_tracking_state%E2%80%9D)

### <a name="accessibility-tools-for-windows-developers"></a>Windows 開発者向けアクセシビリティ ツール

Windows 10 SDK には、アプリのアクセシビリティをテストして改善するために使用できるツールが含まれています。 アプリをすべてのユーザーが使用できるようにするには、検査ツールと AccEvent ツールが役立ちます。 これらのツールについては、[ビデオをご覧ください](https://www.youtube.com/watch?v=ce0hKQfY9B8&list=PLWs4_NfqMtoycBFndriDmkQlMLwflyoFF&t=0s&index=1)。[アクセシビリティのテストについて詳しくは、こちらをご覧ください](../design/accessibility/accessibility-testing.md)。