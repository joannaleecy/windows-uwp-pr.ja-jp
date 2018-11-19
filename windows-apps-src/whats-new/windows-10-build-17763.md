---
author: QuinnRadich
title: Windows 10 の開発者向け新着情報、ツール、機能
description: Windows 10 ビルド 17763 と新しい開発者ツールは、ツール、機能、およびユニバーサル Windows プラットフォームによって強化されたエクスペリエンスを提供します。
keywords: 新着情報については、新機能, 更新, 更新プログラム, 機能, 新規, Windows 10, 最新, 開発者, 17763
ms.author: quradic
ms.date: 10/03/2018
ms.topic: article
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ff1f4327b82e2b81cc1ec3d64b352e4e85e7bb12
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7279346"
---
# <a name="whats-new-in-windows-10-for-developers-build-17763"></a>開発者は、ビルド 17763 新機能では、Windows 10 の新規作成

Windows 10 ビルド 17763 (とも呼ばれる、年 2018年 10 月 Update またはバージョン 1809)、Visual Studio 2017 および更新された SDK と組み合わせて、ツール、機能、およびさせる、優れたユニバーサル Windows プラットフォーム アプリのエクスペリエンスを提供します。 Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

ここには、Windows 開発者にとって重要なこのリリースの新機能、強化された機能、ガイダンスを集めました。 Windows SDK に追加された新しい名前空間の完全な一覧は、 [Windows 10 ビルド 17763 API の変更](windows-10-build-17763-api-diff.md)を参照してください。 Windows 10 での注目すべき機能について詳しくは、「[Windows 10 の優れた機能](http://go.microsoft.com/fwlink/?LinkId=823181)」をご覧ください。 また、Windows プラットフォームに過去に追加された機能と今後追加される機能の概要については、[Windows 開発者向けプラットフォーム機能に関するページ](https://developer.microsoft.com/windows/platform/features)をご覧ください。

## <a name="design--ui"></a>設計および UI

機能 | 説明
 :------ | :------
アプリのアイコンとロゴ | [アプリのアイコンとロゴ ページ](../design/style/app-icons-and-logos.md)書き換えられましたとできるようになりました最新の Visual Studio アイコン ツールを表示情報を提供します、Microsoft Store でアプリの登録情報に画像を追加します。
設計のランディング ページ | [ランディング ページ設計を更新](https://developer.microsoft.com/windows/apps/design)するにはデザイン領域を UWP と Fluent Design を最新の追加機能に関する情報の概要の概要を示します。
Fluent Design を制御します。 | Fluent Design System と、アプリの apparence を強化するために、次の新しい UI コントロールが追加されました。 </br> * [CommandBarFlyout](../design/controls-and-patterns/command-bar-flyout.md)では、UI のキャンバス上の項目のコンテキストでユーザーの一般的なタスクを表示できます。 </br> * [DropDownButton](../design/controls-and-patterns/buttons.md#create-a-drop-down-button)、 [SplitButton](../design/controls-and-patterns/buttons.md#create-a-split-button)、および[ToggleSplitButton](../design/controls-and-patterns/buttons.md#create-a-toggle-split-button)は、アプリのユーザー インターフェイスを強化するために特殊な機能を備えたボタン コントロールを提供します。 </br> * [メニュー バー](../design/controls-and-patterns/menus.md)では、水平方向の行で複数の最上位のメニューのセットを示しています。 </br> * [NavigationView](../design/controls-and-patterns/navigationview.md)をサポートしています上部のナビゲーションの場合、アプリのナビゲーション オプションの数を減らしてがあり、コンテンツの多くのスペースが必要です。 </br> * [ツリー ビュー](../design/controls-and-patterns/tree-view.md)は、データ バインディングをサポート、項目テンプレート、ドラッグ アンド ドロップを拡張されています。
Fluent Design の更新 | 次の Fluent Design ページ visual の更新プログラムと小規模な変更が追加されました。 </br> * [パディング、余白の配置](../design/layout/alignment-margin-padding.md) </br> * [色](../design/style/color.md) </br> * [Windows アプリ用の fluent Design](../design/fluent-design-system/index.md) </br> * [アプリの設計の概要](../design/basics/design-and-ui-intro.md) </br> * [ナビゲーションの基本](../design/basics/navigation-basics.md) </br> * [レスポンシブ デザイン テクニック](../design/layout/responsive-design.md) </br> * [画面サイズとブレークポイント](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md) </br> * [スタイルの概要](../design/style/index.md) </br> * [記述スタイル](../design/style/writing-style.md) </br> さらに、まったく新しい情報、コンテンツ領域上で次のページを書き換えるしたします。 </br> * [アイコン](../design/style/icons.md)は、アイコンを使用すると、クリック可能なする際に実用的な推奨事項を提供します。 </br> * [文字体裁](../design/style/typography.md)では、更新されたガイダンスと図を 1 つの場所に配置するすべてのものと同様の記事からの情報を統合します。
視線入力と操作 | [視線の操作](../design/input/gaze-interactions.md)には、ユーザーの視線、注意、および場所と、目の動きに基づくプレゼンスを追跡するアプリができるようにします。 この機能は、支援技術として使用でき、ゲームや従来型入力デバイスが利用可能ないないその他の対話型シナリオの機会を提供します。
手書きビュー | [HandwritingView](../design/controls-and-patterns/text-handwriting-view.md)では、新しいインク入力サーフェスの TextBox および RichEditBox です。 ユーザーは、書き込みサーフェスにコントロールを拡張するペンでテキスト コントロールをタップすることができます。 このガイドでは、管理し、アプリケーションで HandwritingView をカスタマイズする方法について説明します。
Fluent Design のモーション | タイミング、イージング、方向、および重力の基礎上に構築され、Fluent Design System のモーションの使用が進化しています。 これらの基礎を適用する、アプリを使用してユーザーに役立つし、その接続とそのデジタル エクスペリエンスによって、自然界を反映します。 さらに、次の記事をご覧ください。 </br> * これらの基礎を反映するように[、モーションの概要](../design/motion/index.md)が更新されました。 </br> * [モーションの演習で](../design/motion/motion-in-practice.md)は、アプリ内でこれらの基礎を適用する方法の例を示します。 暗黙的なアニメーションは、XAML 要素のプロパティが変更されたときに、古いと新しい値の間で補間を簡単に許可に関する情報も含まれています。 </br> * [方向性と重力](../design/motion/directionality-and-gravity.md)には、アプリのユーザーの概念的モデルが塗りつぶされます。 </br> * [タイミングとイージング](../design/motion/timing-and-easing.md)は、アプリでモーションにリアルさを追加します。 </br> * [XAML プロパティのアニメーション](../design/motion/xaml-property-animations.md)を使用して、直接を基になるコンポジションのビジュアルを操作することがなく、XAML 要素のプロパティをアニメーション化できます。
ページ切り替え効果 | [ページ切り替え](../design/motion/page-transitions.md)は、ユーザーがアプリ内のページ間を移動します。 これらには、ユーザーが、ナビゲーション階層にいるを理解し、ページ間の関係についてのフィードバックができるようにします。
テキストの拡大縮小 | 新しい[テキスト スケーリングのガイダンス](../design/input/text-scaling.md)には、新しいテキスト スケーリング動作、ユーザーが OS と個々 のアプリケーションの両方の間での相対的なフォント サイズを変更する機能を提供する対応するために、アプリケーションを更新する方法について説明します。 拡大鏡アプリ (これ通常だけ、画面の領域内のすべてを拡大し、独自の操作性の問題が導入されています) を使って、ディスプレイの解像度を変更または DPI スケーリングのサイズを変更ディスプレイと一般的な表示に基づくすべての証明書利用者ではなく距離)、ユーザーは、テキストだけで、100% (既定のサイズ) からの範囲のサイズを変更する設定にすばやくアクセスできる最大 225% です。
ツールキット | 新機能[Adobe XD、Adobe Illustrator ツールキット](../design/downloads/index.md)が更新されています。 これらの設計ツールキットは、UWP アプリを設計するためのコントロールとレイアウト テンプレートを提供します。
UI コマンド実行 | [UWP コマンド実行のインフラストラクチャ](../design/basics/commanding-basics.md)の更新プログラムは、コマンドのオブジェクト (動作、ラベル、アイコン、キーボード アクセラレータ、アクセス キー、および説明) の優れたカプセル化を含めると、標準の切り取り、コピーなどの一般的なコマンドのセットを貼り付ける、終了など、。これにより、これらのプロパティを手動で設定する必要があります。 </br> 新しい[XamlUICommand](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.xamluicommand)クラスは、呼び出されたときにアクションを実行する対話型の UI 要素のコマンドの動作を deveining の基底クラスを提供します。 これは、 [StandardUICommand](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.standarduicommand)、定義済みプロパティを使って標準的なプラットフォームのコマンドのセットを公開するための親クラスです。 
Windows UI ライブラリ | [Windows UI のライブラリ](https://aka.ms/winui-docs)とは、UWP アプリのコントロールとその他のユーザー インターフェイス要素を提供する NuGet パッケージのセットです。 これらのパッケージは、ユーザーが最新の OS バージョンに存在しない場合でも、アプリが機能するため、Windows 10 の以前のバージョンと互換性があります。 </br> Windows UI ライブラリの新機能について詳しくは、次を参照してください[この NuGet パッケージに含まれている API 名前空間の一覧。](https://docs.microsoft.com/uwp/api/overview/winui/) 。

## <a name="develop-windows-apps"></a>Windows アプリの開発

機能 | 説明
 :------ | :------
バーコード スキャナー | [バーコード スキャナー](https://docs.microsoft.com/windows/uwp/devices-sensors/pos-barcodescanner)のマニュアルは再編成、され、複数の詳細とコード スニペットを向上しています。 新しいトピックもが追加されました[取得バーコード データの理解と](https://docs.microsoft.com/windows/uwp/devices-sensors/pos-barcodescanner-scan-data)、取得およびバーコード スキャナーからデータを操作する方法について説明します。
C++/WinRT | [、C++/WinRT](https://aka.ms/cppwinrt)多くの新機能、変更、およびこのリリースで修正プログラムが含まれています。 新しい機能と、独自の[コレクション プロパティとコレクション型](/windows/uwp/cpp-and-winrt-apis/collections); の実装をサポートする基底クラスc++ で[{Binding}](/windows/uwp/xaml-platform/binding-markup-extension) XAML マークアップ拡張を使用できるようになりましたと/WinRT ランタイム クラス (コード例については、[データ バインディングの概要](/windows/uwp/data-binding/data-binding-quickstart)を参照してください)。 新しいと、このリリースで変更されたすべての完全な説明を参照してください。[新機能、C++/WinRT](../cpp-and-winrt-apis/news.md)します。</br></br>その他の新しい C + + WinRT コンテンツが含まれています: [XAML カスタム コントロール](/windows/uwp/cpp-and-winrt-apis/xaml-cust-ctrl)です。[作成者の COM コンポーネント](/windows/uwp/cpp-and-winrt-apis/author-coclasses)です。[値のカテゴリ](/windows/uwp/cpp-and-winrt-apis/cpp-value-categories)。[強力なと弱参照](../cpp-and-winrt-apis/weak-references.md)します。
C++/WinRT のコード例 | 250 C + が追加されました/WinRT コードの登録情報、ドキュメントは、付属の既存の C + のトピックを/CX コード例を紹介します。
ガイダンスの貢献に関するページ | [貢献ガイダンス](https://github.com/MicrosoftDocs/windows-uwp/blob/docs/CONTRIBUTING.md)UWP のドキュメントの更新されました。 この新しいガイダンスには、ワークフローと、ドキュメントを外部の貢献度に対する期待が明確化します。
DirectX グラフィックスのインフラストラクチャー (DXGI) | DXGI Api が不足している用の新しいドキュメントが追加されているし、Windows 10 を提示するときのベスト プラクティスに関する記事を提供してきました。 </br> * [最適なパフォーマンスを得るためには、DXGI フリップ モデルを使用して](https://docs.microsoft.com/windows/desktop/direct3ddxgi/for-best-performance--use-dxgi-flip-model): パフォーマンスと最新バージョンの Windows でのプレゼンテーション スタック内の効率を最大化する方法に関するガイダンスを提供します。 </br> * [IDXGIOutput6::CheckHardwareCompositionSupport メソッド](https://docs.microsoft.com/windows/desktop/api/dxgi1_6/nf-dxgi1_6-idxgioutput6-checkhardwarecompositionsupport): ハードウェアの拡大がサポートされていることをアプリケーションに通知します。 </br> * [DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS 列挙](https://docs.microsoft.com/windows/desktop/api/dxgi1_6/ne-dxgi1_6-dxgi_hardware_composition_support_flags): サポートされているレベルのハードウェア構成について説明します。
はじめに | [概要](../get-started/index.md)コンテンツは、開発者は新しい Windows 10 が、次の一般的なタスクに実現方法で情報とガイダンスを提供する新しいトピックと revitalized されました。 </br> * [フォームを作成します。](../get-started/construct-form-learning-track.md) </br> * [リスト内の顧客の表示](../get-started/display-customers-in-list-learning-track.md) </br> * [保存し、読み込みの設定](../get-started/settings-learning-track.md) </br> * [ファイルを操作します。](../get-started/fileio-learning-track.md)
マップ スタイル シート エディター | 対話的にマップに追加するアプリケーションの外観をカスタマイズするのにには、新しい[マップ スタイル シート エディター](https://www.microsoft.com/p/map-style-sheet-editor/9nbhtcjt72ft?rtc=1#activetab=pivot:overviewtab)アプリケーションを使用します。
Microsoft について説明します | 新しい[Microsoft Learn サイト](https://www.microsoft.com/learning/default.aspx)は、Microsoft 開発者向けに新しい実践的な学習とトレーニングの機会を提供します。 現時点では、Microsoft については、トレーニングと Microsoft 365、Microsoft Azure、Office 365、および Windows Server の認定を提供します。
メモ帳 | [メモ帳が更新されて](http://aka.ms/ant-man)、ズームを追加、検索/置換、折り返しおよび Unix/Linux (LF) と Mac (変更リクエスト) の行の末尾のサポート。
Project Rome | ようになりました["rome"プロジェクト](https://docs.microsoft.com/windows/project-rome/)は、サポートされているプラットフォームと Sdk の間で一貫性のあるプログラミング エクスペリエンスを提供します。 </br>  新しい[Microsoft Graph の通知](https://developer.microsoft.com/graph/docs/concepts/notifications-concept-overview)では、"rome"プロジェクトを使用して、アプリのユーザーを中心とした、クロスプラット フォームの通知プラットフォームを提供します。
画面の snipping | 新しい[URI スキーム](../launch-resume/launch-screen-snipping.md)では、アプリにプログラムで新しいの切り取り領域を開くか、注釈の特定のイメージの切り取り領域とスケッチ アプリを起動できます。
デスクトップ アプリケーションで UWP コントロール | これで、Windows 10 では、WPF、Windows フォーム、および C++ Win32 デスクトップ アプリケーションで UWP コントロールを使用できます。 つまり、外観、や、既存のデスクトップ アプリケーション、最新の Windows 10 の UI 機能のみで利用可能な Windows Ink と Fluent Design System をサポートするコントロールなどの UWP コントロールの機能を強化することができます。 この機能は、 *XAML 諸島*と呼ばれます。 </br> 使用しているアプリケーション プラットフォームに応じて、アプリケーションで XAML 諸島を使用するいくつかの方法を説明します。 WPF および Windows フォーム アプリケーションでは、一連のデザイナー指向の開発エクスペリエンスを提供する[Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)でコントロールを使用できます。 C++ Win32 アプリケーションでは、 [Windows.UI.Xaml.Hosting](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)名前空間で*API をホストしている UWP XAML*を使う必要があります。 詳細については、[デスクトップ アプリケーションで UWP コントロール](../xaml-platform/xaml-host-controls.md)を参照してください。 </br> **注:** Api と XAML 諸島を有効にするコントロールは開発者プレビューとして現在利用できます。 それらプロトタイプ コードで今すぐ試すことをお勧めしますがないことで使う運用コードこの時点でお勧めしますしないでください。
Windows Machine Learning | [Windows Machine Learning](https://docs.microsoft.com/windows/ai/)ができるようになりました正式に起動、最先端の機械学習モデルの評価を高速化とサポートなどの機能を提供することです。 アプリケーションに統合する必要がある開発者をサポートするためにいくつかの新規および更新されたリソースを新しいドキュメント サイトを作成します。 </br> * [チュートリアル: Windows Machine Learning のデスクトップ アプリケーション (C++) 作成](https://docs.microsoft.com/windows/ai/get-started-desktop): このチュートリアルは、デスクトップ用のシンプルな Windows ML アプリケーションを構築する方法を示しています。 </br> * [チュートリアル: Windows Machine Learning UWP アプリケーション (c#) 作成](https://docs.microsoft.com/windows/ai/get-started-uwp): このステップ バイ ステップ チュートリアルでは、Windows ML を使って、初めての UWP アプリケーションを作成します。 </br> * [Windows.AI.MachineLearning Namespace](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning): Windows 10 SDK の最新リリースのための API リファレンスは更新されており、開発者は Win32 および UWP の両方のアプリケーションのこの API を使用できるようになりました。
Windows Mixed Reality | 開発者は、ハードウェアで保護された要求バックバッファー テクスチャ ディスプレイのハードウェアでサポートされている場合は、これに PlayReady などのソースからのハードウェアで保護されたコンテンツを使用するアプリケーションを許可することができます。 ハードウェア保護のサポートと設定は、 [Windows.Graphics.Holographic.HolographicCamera](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamera)の新しいプロパティを使用してプライマリ レイヤーとクワッド レイヤー[経由で利用できます。Windows.Graphics.Holographic.HolographicQuadLayerUpdateParameters](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicquadlayerupdateparameters)します。

## <a name="iot-core"></a>IoT Core

機能 | 説明
 :------ | :------
AssignedAccessSettings | [[AssignedAccessSettings クラス](https://docs.microsoft.com/uwp/api/windows.system.userprofile.assignedaccesssettings)により、さまざまなメソッドの呼び出しと、ユーザーにアクセスするプロパティには、特定のデバイスのアクセスの設定が割り当てられています。
既定のアプリの概要 | [Windows 10 IoT Core 既定のアプリ](https://docs.microsoft.com/windows/iot-core/develop-your-app/iotcoredefaultapp)は、新機能や天気予報、手描き入力などの機能と更新されたとオーディオされました。
ダッシュボード | [Windows 10 Iot Core のダッシュ ボード](https://docs.microsoft.com/windows/iot-core/tutorials/quickstarter/devicesetup)では、Dragonboard 410 C または NXP を使用して、デバイスにカスタム FFUs flash の開発者ができるようになりました。
スクリーン キーボード | デスクトップ エディションの Windows として同じタッチ キーボードのコンポーネントを使用できるようになりました[IoT デバイスのスクリーン キーボードします](https://docs.microsoft.com/windows/iot-core/develop-your-app/onscreenkeyboard)。 これにより、ディクテーション モード、IME サポート、および入力スコープの完全なセットなどの機能です。
サインイン ダイアログのタイトル バー | Windows 10 IoT Core では、[システム ダイアログ ボックスのタイトル バー](https://docs.microsoft.com/windows/iot-core/develop-your-app/signindialogtitlebars)を構成するオプションが提供できるようになりました。
タッチでスリープ解除します。 | [タッチでスリープ解除](https://docs.microsoft.com/windows/iot-core/learn-about-hardware/wakeontouch)をすぐに有効にするユーザーの画面に触れたとき中の使用中でないときにオフにするデバイスの画面を使用できます。 
Windows.System.Update | 新しい[Windows.System.Update 名前空間](https://docs.microsoft.com/uwp/api/windows.system.update)では、システムの更新プログラムの対話型のコントロールを使用できます。 この名前空間は、Windows 10 IoT Core のみです。

## <a name="web-development"></a>Web 開発

機能 | 説明
 :------ | :------
EdgeHTML 18 | Windows 10 年 2018年 10 月は、 [EdgeHTML 18](https://docs.microsoft.com/microsoft-edge/dev-guide)、Microsoft Edge ブラウザーと UWP アプリ用の JavaScript エンジンを最新の更新プログラムでの船舶を更新します。 EdgeHTML 18 では、Web 認証 API、WebView コントロールの新しい機能、最先端および展開のサポートをもたらす! ツールの側では、EdgeHTML 18 は、Edge DevTools と Edge DevTools プロトコルに WebDriver の新機能と自動更新、および拡張機能をもたらします。 すべての詳細について[EdgeHTML 18 の新機能では](https://docs.microsoft.com/microsoft-edge/dev-guide)[最新の Windows 10 での非同期の更新 (EdgeHTML 18)](https://docs.microsoft.com/microsoft-edge/devtools-guide/whats-new)を確認します。
プログレッシブ Web アプリ | Windows 10 の JavaScript アプリ ( *WWAHost.exe*プロセスで実行される web アプリ) で現在サポートされたビューがアクティブ化される前に起動オプション[-アプリケーションのバック グラウンド スクリプト](https://docs.microsoft.com/en-us/microsoft-edge/dev-guide#progressive-web-apps)とプロセスの中に実行されます。 これにより、監視しナビゲーションの変更、ナビゲーション間の状態を追跡、ナビゲーションのエラーを監視して実行できるコード ビューがアクティブ化される前に、。 として指定する場合、[`StartPage`](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appxmanifestschema2010-v2/element-application)の新しいインスタンスとしてスクリプトに公開される各アプリのビュー (windows)、[アプリのマニフェスト](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appx-package-manifest)で[`WebUIView`](https://docs.microsoft.com/en-us/uwp/api/windows.ui.webui.webuiview)クラス、一般的な (Win32) [WebView](https://docs.microsoft.com/en-us/uwp/api/windows.web.ui.iwebviewcontrol)として同じイベント、プロパティ、およびメソッドを提供することです。
Web API の拡張機能 | Mozilla Developer Network ドキュメントには、ブラウザー間の web 開発、[従来の Microsoft API の拡張機能](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions)の一覧が追加されました。 これらの API の拡張機能は、Internet Explorer または Microsoft Edge に固有のもの MDN web ドキュメントの互換性とブラウザーのサポートに関する既存の情報を補足します。従来の Microsoft [CSS 拡張機能](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions)と[JavaScript の拡張機能](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions)は、利用可能なもとで直接リッチ web MDN から API の情報が表示されるかを確認できます[Visual Studio Code](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn) 。
WebVR | 主要な更新プログラムには、 [WebVR 開発者向けガイド](https://docs.microsoft.com/microsoft-edge/webvr/)、完全に再設計ホーム ページと内容のテーブルの再編成を含むなりました。 など、いくつかの新しいトピックも書き込んだ。 </br> * [WebVR とは何ですか。](https://docs.microsoft.com/microsoft-edge/webvr/what-is-webvr) WebVR、それを使用する理由との開発を開始する方法について説明します。 </br> * [プログレッシブ Web アプリで WebVR](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-pwas): WebVR をプログレッシブ Web アプリ (PWA) を追加する方法について説明します。 </br> * [WebView で WebVR](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-webview): Windows 10 アプリケーションの WebView コントロールに WebVR を追加する方法について説明します。 </br> * [WebVR デモ](https://docs.microsoft.com/microsoft-edge/webvr/demos): Microsoft Edge と Windows Mixed Reality のイマーシブ ヘッドセットを使用していくつかの WebVR デモを確認します。

## <a name="publish--monetize-windows-apps"></a>Windows アプリを公開および収益化する

機能 | 説明
 :------ | :------
MSIX | [MSIX](https://docs.microsoft.com/windows/msix/overview)は、すべての Windows アプリを最新のパッケージ化エクスペリエンスを提供する新しい Windows アプリ パッケージ形式です。 オープン ソース MSIX 形式では、最新の展開機能を有効にするときに、既存のパッケージの機能が保持されます。
MSIX パッケージ作成ツール | 新しい[MSIX パッケージ作成ツール](https://docs.microsoft.com/windows/msix/mpt-overview)) で、ソース コードにアクセスできない場合でも、MSIX 形式で、既存のデスクトップ アプリケーションを再パッケージ化することができます。 これは、コマンドライン、またはその対話型の UI を使って実行できます。
MSIX のデスクトップ アプリのコンバーターのサポート | 使用して、MSIX パッケージを出力する[Desktop App Converter](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root)を使用する、`-MakeMSIX`パラメーター。
MSIX の MakeAppx.exe ツールのサポート | MakeAppx.exe ツールを使用して、UWP アプリまたは従来のデスクトップ アプリケーションの MSIX パッケージを作成することができます。 このツールは、Windows 10 SDK に含まれており、コマンド プロンプトまたはスクリプト ファイルから使用できます。 </br> UWP アプリでは、 [MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)を参照してください。 </br> デスクトップ アプリケーションは、[デスクトップ アプリケーションを手動でパッケージ](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-manual-conversion)を参照してください。
パッケージのサポート フレームワーク | [パッケージのサポートのフレームワーク](https://docs.microsoft.com/windows/msix/package-support-framework-overview)では、修正プログラムの適用、既存のデスクトップ アプリケーションに、ソース コードにアクセスできないとき MSIX コンテナーで実行できるようにするために役立つオープン ソースのキットです。
Store 分析 API | [Microsoft Store 分析 API](../monetize/access-analytics-data-using-windows-store-services.md)には、次の新しいメソッドにはできるようになりましたが含まれています。 </br> * [UWP アプリのインサイト データを取得します。](../monetize/get-insights-data-for-your-app.md) </br> * [デスクトップ アプリケーションのインサイト データを取得します。](../monetize/get-insights-data-for-your-desktop-app.md) </br>* [デスクトップ アプリケーションのアップグレード ブロックを取得します。](../monetize/get-desktop-block-data.md) </br> * [デスクトップ アプリケーションのアップグレード ブロックに関する詳細を取得します。](../monetize/get-desktop-block-data-details.md)

## <a name="videos"></a>ビデオ

Fall Creators Update 以降、以下のビデオが公開されました。Windows 10 の開発者向け新機能および強化された機能が紹介されています。

### <a name="cwinrt"></a>C++/WinRT

C++/WinRT では、新しい方法の作成と Windows ランタイム Api を使用します。 ヘッダー ファイルに単独で実装は、最新のアプリの機能を最上位アクセス権を提供するために設計されています。 [ビデオ](https://www.youtube.com/watch?v=TLSul1XxppA&feature=youtu.be)をしくみ、し、[開発者ドキュメント](../cpp-and-winrt-apis/index.md)を詳しく説明します。

### <a name="get-started-for-devs-create-and-customize-a-form-on-windows-10"></a>開発者向けスタートアップ ガイド: を作成し、Windows 10 でのフォームをカスタマイズします。

Windows 開発者向け[ドキュメントの概要](../get-started/index.md)、基本的なアプリの開発タスクでの実践的なエクスペリエンスを提供します。 このビデオでは、これらのトピックでは、いずれかを紹介して、アプリでのフォームの UI の作成の基本について説明します。 [ビデオをご覧ください](https://www.youtube.com/watch?v=AgngKzq4hKI&feature=youtu.be)アクションを次のコードを確認する[」のトピックを確認します](http://aka.ms/CreateForms)。

### <a name="enhance-your-bot-with-project-personality-chat"></a>プロジェクトの個性チャットのボットを強化します。

プロジェクトの個性チャットでは、チャット ボットにカスタマイズ可能なペルソナを追加できます。 Microsoft ボット フレームワーク SDK との統合、顧客との対話をより親近感を与えるための方法の小さな話しかける機能を追加できます。 [ビデオを見る](https://www.youtube.com/watch?v=5C_uD8g2QKg&feature=youtu.be)をし、それには、実践的なエクスペリエンスの[対話型デモを試す](http://aka.ms/PersonalityChat)を実装する方法について説明します。

### <a name="multi-instance-uwp-apps"></a>マルチインスタンスの UWP アプリ

今すぐ Windows ではそれぞれ独自の別のプロセスで、UWP アプリの複数のインスタンスを実行することができます。 [ビデオをご覧ください](https://www.youtube.com/watch?v=clnnf4cigd0&feature=youtu.be)をする方法について、この機能では、その[開発者ドキュメント](../launch-resume/multi-instance-uwp.md)をサポートしている新しいアプリを作成する方法と、この機能を使用する理由について説明します。

### <a name="xbox-live-unity-plugin"></a>Xbox Live Unity プラグイン

Unity の Xbox Live プラグインには、Xbox Live への署名、統計情報、フレンド リスト、クラウド ストレージ、およびランキングをタイトルに追加するためのサポートが含まれています。 について[は、ビデオ](https://youtu.be/fVQZ-YgwNpY)をし、 [GitHub のパッケージをダウンロード](https://aka.ms/UnityPlugin)を開始します。

### <a name="one-dev-question"></a>1 つのデベロッパー質問

デベロッパー質問の 1 つのビデオ シリーズの長い Microsoft 開発者は一連の Windows の開発、チームのカルチャと履歴に関する質問について説明します。

* [Windows の開発と履歴に関する Raymond Chen](https://www.youtube.com/playlist?list=PLWs4_NfqMtoxjy3LrIdf2oamq1coolpZ7)

* [Windows の開発と履歴に関する Larry Osterman](https://www.youtube.com/playlist?list=PLWs4_NfqMtoyPUkYGpJU0RzvY6PBSEA4K)

* [プログレッシブ Web アプリで Aaron グスタフソン](https://www.youtube.com/playlist?list=PLWs4_NfqMtoyPHoI-CIB71mEq-om6m35I)

* [Chris Heilmann webhint ツール](https://www.youtube.com/playlist?list=PLWs4_NfqMtow00LM-vgyECAlMDxx84Q2v)

## <a name="samples"></a>サンプル

### <a name="customer-orders-database"></a>顧客注文データベース

[顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)[データ グリッド](https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid)、 [NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)、[拡張](https://docs.microsoft.com/windows/communitytoolkit/controls/expander)などの新しいコントロールを使用して更新されました。

### <a name="customer-database-tutorial"></a>顧客データベース チュートリアル

[顧客データベース チュートリアル](../enterprise/customer-database-tutorial.md)では、顧客の一覧を管理するための基本的な UWP アプリを作成し、概念とエンタープライズ開発で便利なプラクティスを紹介します。 紹介の UI 要素を実装して、ローカルの SQLite データベースに対して操作を追加して、さらに移動する場合は、リモートの残りの部分データベースに接続するための緩やかなガイダンスを提供します。

### <a name="photo-editor-cwinrt"></a>フォト エディター、C++/WinRT

[フォト エディター サンプル アプリ](https://github.com/Microsoft/Windows-appsample-photo-editor)の開発の紹介、 [、C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md)言語プロジェクションです。 アプリでは、**画像**ライブラリから写真を取得し、関連する写真効果で選択のイメージを編集することができます。

### <a name="windows-machine-learning"></a>Windows Machine Learning

[Windows-機械学習](https://github.com/Microsoft/Windows-Machine-Learning)リポジトリでは、最新の Windows 10 SDK の連携が更新され、c#、C++、および JavaScript で記述されたサンプルが含まれています。

### <a name="xaml-hosting-api"></a>XAML をホストしている API

[XAML をホストしている API のサンプル](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)は、Win32 デスクトップ アプリです API (XAML 諸島とも呼ばれます) をホストしている UWP XAML を使って、さまざまなシナリオを示しています。 プロジェクトには、Windows Ink、メディア プレーヤーとナビゲーション ビュー コントロール ギャラリー スタイルのプレゼンテーションが組み込まれています。 一般の外側では、使用量を制御するサンプルもで XAML とネイティブ Windows イベント/メッセージ、および基本的な XAML データ バインディングを処理します。
