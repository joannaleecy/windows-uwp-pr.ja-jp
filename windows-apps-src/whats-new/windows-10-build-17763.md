---
title: Windows 10 の開発者向け新着情報、ツール、機能
description: Windows 10 が 17763 をビルドし、新しい開発者ツールは、ツール、機能、およびユニバーサル Windows プラットフォームを利用したエクスペリエンスを提供します。
keywords: 新機能については、何が起こって、新しい更新プログラム、更新プログラム、機能、新しい Windows 10 で、最新の開発者、17763
ms.date: 10/03/2018
ms.topic: article
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 2b172844e75d9af3d0112e03f155708af3ca6bed
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57637747"
---
# <a name="whats-new-in-windows-10-for-developers-build-17763"></a>開発者は、ビルド 17763 が追加された Windows 10 です。

Windows 10 ビルド 17763 (年 2018年 10 月とも呼ばれる更新プログラムまたはバージョンは 1809)、Visual Studio 2017 と更新された SDK と組み合わせて、ツール、機能、および優れたユニバーサル Windows プラットフォーム アプリを作成するエクスペリエンスを提供します。 Windows 10 の[ツールと SDK をインストール](https://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

ここには、Windows 開発者にとって重要なこのリリースの新機能、強化された機能、ガイダンスを集めました。 Windows SDK に追加された新しい名前空間の一覧については、次を参照してください。、 [Windows 10 ビルド API の変更点を 17763](windows-10-build-17763-api-diff.md)します。 Windows 10 での注目すべき機能について詳しくは、「[Windows 10 の優れた機能](https://go.microsoft.com/fwlink/?LinkId=823181)」をご覧ください。 また、Windows プラットフォームに過去に追加された機能と今後追加される機能の概要については、[Windows 開発者向けプラットフォーム機能に関するページ](https://developer.microsoft.com/windows/platform/features)をご覧ください。

## <a name="design--ui"></a>設計および UI

機能 | 説明
 :------ | :------
アプリのアイコンとロゴ | [アプリ アイコンとロゴ ページ](../design/style/app-icons-and-logos.md)書き直しました、およびようになりましたは最新の Visual Studio アイコン ツールを紹介し、Microsoft Store でアプリの一覧にイメージを追加する方法の情報を提供します。
ランディング ページのデザイン | [ランディング ページ デザインの更新](https://developer.microsoft.com/windows/apps/design)が UWP デザイン領域の Fluent デザインの最新機能についての概要について概説します。
Fluent デザインを制御します。 | Fluent Design System と、アプリの apparence を強化するために、次の新しい UI コントロールが追加されました。 </br> * [CommandBarFlyout](../design/controls-and-patterns/command-bar-flyout.md) UI キャンバス上の項目のコンテキストでユーザーの一般的なタスクを表示することができます。 </br> * [DropDownButton](../design/controls-and-patterns/buttons.md#create-a-drop-down-button)、 [SplitButton](../design/controls-and-patterns/buttons.md#create-a-split-button)、および[ToggleSplitButton](../design/controls-and-patterns/buttons.md#create-a-toggle-split-button)ボタン コントロールをアプリのユーザー インターフェイスを強化するために特別な機能を提供します。 </br> * [メニュー バー](../design/controls-and-patterns/menus.md)横の行で複数のトップレベル メニューを示しています。 </br> * [NavigationView](../design/controls-and-patterns/navigationview.md)のケースをアプリが、少数のナビゲーション オプションとコンテンツのより多くの領域が必要です、上部のナビゲーションになりました。 </br> * [TreeView](../design/controls-and-patterns/tree-view.md)データ バインディング、項目テンプレートをサポートし、ドラッグ アンド ドロップに拡張されています。
Fluent Design の更新 | 次のページの Fluent デザイン、ビジュアルの更新と軽微な変更が加えられました。 </br> * [配置、余白のパディング](../design/layout/alignment-margin-padding.md) </br> * [色](../design/style/color.md) </br> * [Windows アプリの Fluent デザイン](../design/fluent-design-system/index.md) </br> * [アプリの設計の概要](../design/basics/design-and-ui-intro.md) </br> * [ナビゲーションの基本](../design/basics/navigation-basics.md) </br> * [レスポンシブ デザイン手法](../design/layout/responsive-design.md) </br> * [画面サイズやブレークポイント](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md) </br> * [スタイルの概要](../design/style/index.md) </br> * [文書のスタイル](../design/style/writing-style.md) </br> さらに、すべて新しい情報のコンテンツ領域で、次のページを書き換えることしました。 </br> * [アイコン](../design/style/icons.md)アイコンを使用して、クリック可能にすることのようになりました実際的な推奨事項を提供します。 </br> * [文字体裁](../design/style/typography.md)更新されたガイダンスと図を 1 か所ですべて記述して、類似した記事からの情報を統合します。
視線入力との相互作用 | [相互作用の視線](../design/input/gaze-interactions.md)アプリ ユーザーの視線の先、注意、娘の移動と場所に基づいてプレゼンスを追跡することを許可します。 この機能は、支援テクノロジとして使用できる、ゲーム、および従来の入力デバイスが利用できないその他の対話型のシナリオの機会を提供します。
手書きビュー | [HandwritingView](../design/controls-and-patterns/text-handwriting-view.md)は、新しいインク入力画面、テキスト ボックスと RichEditBox します。 ユーザーは、タッチ面にコントロールを拡張するペンでテキスト コントロールをタップすることができます。 このガイドでは、管理し、アプリケーションで HandwritingView をカスタマイズする方法について説明します。
Fluent デザインの動作 | タイミング、イージング、方向性、および重力の基礎の上に構築された、Fluent Design System のモーションの使用が進化しています。 これらの基本を適用する、アプリでは、ユーザーに役立ち、自然な世界を反映してデジタル エクスペリエンスを接続します。 次の記事で詳細情報。 </br> * [モーション概要](../design/motion/index.md)がこれらの基本を反映するように更新されました。 </br> * [モーションの実習で](../design/motion/motion-in-practice.md)アプリ内でこれらの基本を適用する方法の例を示します。 暗黙のアニメーションは、XAML 要素のプロパティが変更されたときに、新旧の値間の補間を簡単にするための情報も含まれています。 </br> * [方向性と重力](../design/motion/directionality-and-gravity.md)アプリのユーザーのメンタル モデルが塗りつぶされます。 </br> * [タイミングと、イージング](../design/motion/timing-and-easing.md)リアリティをアプリ内のモーションに追加します。 </br> * [XAML プロパティのアニメーション](../design/motion/xaml-property-animations.md)基になる合成ビジュアルと対話することがなく、XAML 要素のプロパティを直接アニメーション化することを許可します。
ページ切り替え効果 | [ページの切り替え](../design/motion/page-transitions.md)ユーザー、アプリ内のページ間を移動します。 ユーザーが、ナビゲーション階層内を理解し、ページ間のリレーションシップに関するフィードバックを提供できます。
テキストの拡大縮小 | 新しい[スケーリング ガイダンス テキスト](../design/input/text-scaling.md)スケーリングの動作は、ユーザーが、OS と個々 のアプリケーション間での相対的なフォント サイズを変更する機能を提供する新しいテキストに合わせてアプリケーションを更新する方法について説明します。 拡大鏡アプリ (を通常だけ、画面の領域内のすべてを拡大し、独自の使いやすさの問題が発生する) を使用して、ディスプレイの解像度を変更または DPI スケール (を表示し、一般的な表示に基づくすべてのサイズ変更に依存する代わりに距離)、ユーザーがテキストだけで、100% (既定のサイズ) の範囲のサイズを変更する設定をすばやくアクセス 225% です。
ツールキット | [Adobe XD および Adobe Illustrator ツールキット](../design/downloads/index.md)の新機能が更新されました。 これらのデザイン ツールキットは、UWP アプリを設計するためのコントロールとレイアウトのテンプレートを提供します。
UI コマンドを実行 | 更新、 [UWP コマンド インフラストラクチャ](../design/basics/commanding-basics.md)(動作、ラベル、アイコン、キーボード アクセラレータ、アクセス キー、および説明) は、コマンド オブジェクトのカプセル化を向上し、切り取り、コピーなどの一般的なコマンドの標準セットが含まれます、貼り付け、終了、など、これらのプロパティを手動で設定する必要があります。 </br> 新しい[XamlUICommand](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.xamluicommand)クラスが呼び出されたときにアクションを実行する対話型の UI 要素のコマンドの動作を定義するための基本クラスを提供します。 これは、親クラスに[StandardUICommand](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.standarduicommand)、定義済みのプロパティを持つ標準プラットフォームのコマンドのセットを公開します。 
Windows の UI ライブラリ | [Windows UI ライブラリ](https://aka.ms/winui-docs)コントロールとその他のユーザー インターフェイス要素を UWP アプリの提供する NuGet パッケージのセットです。 これらのパッケージは、ユーザーは最新の OS バージョンがあるない場合でも、アプリが動作するように以前のバージョンの Windows 10 と互換性があります。 </br> Windows の UI ライブラリの項目の詳細については、次を参照してください。[この NuGet パッケージに含まれる API 名前空間の一覧。](https://docs.microsoft.com/uwp/api/overview/winui/)

## <a name="develop-windows-apps"></a>Windows アプリを開発

機能 | 説明
 :------ | :------
バーコード スキャナー | [バーコード スキャナー](https://docs.microsoft.com/windows/uwp/devices-sensors/pos-barcodescanner)ドキュメントを再編成、および、さらに詳細とコード スニペットで向上しています。 新しいトピックを追加しました[取得バーコード データおよび理解](https://docs.microsoft.com/windows/uwp/devices-sensors/pos-barcodescanner-scan-data)、取得して、バーコード スキャナーからのデータを操作する方法を説明しています。
C++/WinRT | [C +/cli WinRT](https://aka.ms/cppwinrt)多くの新機能、変更、およびこのリリースの修正が含まれています。 新しい関数とサポートを実装する独自の基本クラスがある[コレクションのプロパティおよびコレクション型](/windows/uwp/cpp-and-winrt-apis/collections); し、使用できるように、 [{binding}](/windows/uwp/xaml-platform/binding-markup-extension) C + と XAML マークアップ拡張機能/cli WinRTランタイム クラス (コード例については、次を参照してください。[データ バインディングの概要](/windows/uwp/data-binding/data-binding-quickstart))。 新しいと、このリリースで変更されたすべての項目の詳細については、次を参照してください。[は新しい c++/cli WinRT](../cpp-and-winrt-apis/news.md)します。</br></br>その他の新しい C +/cli WinRT コンテンツが含まれます。[カスタム コントロールの XAML](/windows/uwp/cpp-and-winrt-apis/xaml-cust-ctrl);[作成者 COM コンポーネント](/windows/uwp/cpp-and-winrt-apis/author-coclasses);[カテゴリ値](/windows/uwp/cpp-and-winrt-apis/cpp-value-categories); と[強力と脆弱の参照](../cpp-and-winrt-apis/weak-references.md)します。
C +/cli WinRT コードの例 | 追加した 250 C +/cli WinRT コードの一覧で、ドキュメントの既存の C + に付属するトピックへ/cli CX のコード例。
ガイダンスの貢献 | 変更を加えました[関係しているガイダンス](https://github.com/MicrosoftDocs/windows-uwp/blob/docs/CONTRIBUTING.md)UWP ドキュメントについては、します。 ワークフローと、ドキュメントへの外部の投稿に対する期待を明確にこの新しいガイダンス。
DirectX グラフィックスのインフラストラクチャー (DXGI) | DXGI Api では、不足している新しいドキュメントが追加され、Windows 10 を提示するときのベスト プラクティスに関する記事を用意しました。 </br> * [最適なパフォーマンス、DXGI フリップ モデルを使用して、](https://docs.microsoft.com/windows/desktop/direct3ddxgi/for-best-performance--use-dxgi-flip-model):最新バージョンの Windows 上のプレゼンテーション スタックで効率性とパフォーマンスを最大化する方法について説明します。 </br> * [IDXGIOutput6::CheckHardwareCompositionSupport メソッド](https://docs.microsoft.com/windows/desktop/api/dxgi1_6/nf-dxgi1_6-idxgioutput6-checkhardwarecompositionsupport):ハードウェアの拡大がサポートされていることをアプリケーションに通知します。 </br> * [DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS 列挙](https://docs.microsoft.com/windows/desktop/api/dxgi1_6/ne-dxgi1_6-dxgi_hardware_composition_support_flags):サポートされているレベルのハードウェア構成について説明します。
はじめに | この[開始](../get-started/index.md)コンテンツが初めて使用する Windows 10 開発者は、次の一般的なタスクを実行する方法の情報とガイダンスを提供する、新しいトピックと revitalized されました。 </br> * [フォームを作成します。](../get-started/construct-form-learning-track.md) </br> * [一覧で顧客を表示](../get-started/display-customers-in-list-learning-track.md) </br> * [保存し、読み込みの設定](../get-started/settings-learning-track.md) </br> * [ファイルを使用します。](../get-started/fileio-learning-track.md)
マップ スタイル シートの編集 | 使用して、新しい[マップ スタイル シート エディター](https://www.microsoft.com/p/map-style-sheet-editor/9nbhtcjt72ft?rtc=1#activetab=pivot:overviewtab)対話形式で、アプリケーションに追加するマップの外観をカスタマイズするアプリケーション。
Microsoft がについて説明します | 新しい[Microsoft 学習サイト](https://www.microsoft.com/learning/default.aspx)Microsoft 開発者に新しい実践的な学習とトレーニングの機会を提供します。 現時点では、Microsoft の情報は、Microsoft 365、Microsoft Azure、Office 365、および Windows Server のトレーニングと認定を提供します。
メモ帳 | [メモ帳が更新された](https://aka.ms/ant-man)追加、ズーム、検索/置換、折り返してと改行 (LF) Unix または Linux と Mac (CR) をサポートします。
Project Rome | [プロジェクトのローマ](https://docs.microsoft.com/windows/project-rome/)サポートされているプラットフォームと Sdk の間で一貫性のあるプログラミング エクスペリエンスを提供します。 </br>  新しい[Microsoft Graph 通知](https://developer.microsoft.com/graph/docs/concepts/notifications-concept-overview)プロジェクト ローマを使用して、アプリのユーザーを中心とした、クロス プラットフォームの通知プラットフォームを提供します。
画面の snipping | 新しい[URI スキーム](../launch-resume/launch-screen-snipping.md)プログラムで新しい切り取り領域を開き、アプリまたは特定のイメージの注釈のスケッチ (&)、切り取り領域のアプリを起動します。
デスクトップ アプリケーションでの UWP コントロール | 今すぐ Windows 10 では WPF、Windows フォーム、および C++ の Win32 デスクトップ アプリケーションで UWP コントロールを使用することができます。 これは、外観、外観とのみ Windows インクと Fluent Design System をサポートするコントロールなど、UWP コントロールを使用して利用できる最新の Windows 10 の UI 機能と既存のデスクトップ アプリケーションの機能を拡張できることを意味します。 この機能は呼*XAML 諸島*します。 </br> お使いのアプリケーション プラットフォームによって、アプリケーションで XAML 諸島を使用するいくつかの方法を紹介します。 WPF と Windows フォーム アプリケーションでコントロールのセットを使用できます、 [Windows Community Toolkit](https://docs.microsoft.com/windows/uwpcommunitytoolkit/)者指向の開発エクスペリエンスを提供します。 C++ の Win32 アプリケーションを使用する必要があります、 *API をホストしている UWP XAML*で、 [Windows.UI.Xaml.Hosting](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)名前空間。 詳細については、次を参照してください。[デスクトップ アプリケーションでの UWP コントロール](../xaml-platform/xaml-host-controls.md)します。 </br> **注:** Api と XAML 諸島を有効にするコントロールは、現在開発者プレビューとして使用できます。 実際に試してみて、プロトタイプのコードで今すぐするを勧めしますが、使用することに実稼働コードでこの時点でをしないでください。
Windows Machine Learning | [Windows Machine Learning](https://docs.microsoft.com/windows/ai/)が今すぐ正式に起動、最先端の機械学習モデルの評価を速くやサポートなどの機能を提供します。 アプリケーションに統合する開発者をサポートするためにいくつかの新規および更新されたリソースで新しいドキュメント サイトを作成します。 </br> * [チュートリアル:Windows Machine Learning のデスクトップ アプリケーション (C++) の作成](https://docs.microsoft.com/windows/ai/get-started-desktop):このチュートリアルでは、デスクトップの単純な Windows ML アプリケーションを構築する方法を示します。 </br> * [チュートリアル:Windows Machine Learning の UWP アプリケーションの作成 (C#)](https://docs.microsoft.com/windows/ai/get-started-uwp):このステップ バイ ステップ チュートリアルでは、Windows の ML を使用した最初の UWP アプリケーションを作成します。 </br> * [Windows.AI.MachineLearning Namespace](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning):API リファレンスが、Windows 10 SDK の最新リリースに更新され、開発者が UWP と Win32 の両方のアプリケーションのこの API を使用できますようになりました。
Windows Mixed Reality | 開発者は、ハードウェアで保護されている要求バックバッファー テクスチャ ディスプレイ ハードウェアでサポートされている場合は、これで PlayReady などのソースからのハードウェアで保護されたコンテンツを使用するアプリケーションを許可することができます。 ハードウェア保護のサポートと設定のある主要なレイヤーの新しいプロパティを使用して[Windows.Graphics.Holographic.HolographicCamera](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamera)、しを使用してクワド レイヤーの[Windows.Graphics.Holographic.HolographicQuadLayerUpdateParameters](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicquadlayerupdateparameters)します。

## <a name="iot-core"></a>IoT Core

機能 | 説明
 :------ | :------
AssignedAccessSettings | [AssignedAccessSettings クラス](https://docs.microsoft.com/uwp/api/windows.system.userprofile.assignedaccesssettings)有効をさまざまな方法について呼び出しをユーザーにアクセスするプロパティには、特定のデバイス アクセス設定が割り当てられています。
既定のアプリの概要 | [Windows 10 IoT Core 既定アプリ](https://docs.microsoft.com/windows/iot-core/develop-your-app/iotcoredefaultapp)新機能で、天気、手描き入力機能、およびオーディオなどの機能が更新されました。
ダッシュボード | [Windows 10 Iot Core Dashboard](https://docs.microsoft.com/windows/iot-core/tutorials/quickstarter/devicesetup) Dragonboard 410 C または NXP を使用して、自分のデバイス上にカスタム FFUs の flash 開発者ができるようになりました。
スクリーン キーボード | [IoT デバイスのスクリーン キーボード](https://docs.microsoft.com/windows/iot-core/develop-your-app/onscreenkeyboard)今すぐ Windows のデスクトップ エディションとしてタッチ キーボードと同じコンポーネントを使用します。 これにより、ディクテーション モード、IME サポート、および入力スコープの完全なセットなどの機能です。
サインイン ダイアログ ボックスのタイトル バー | Windows 10 IoT Core では、構成するオプションを提供[システムの範囲 ダイアログ ボックスのタイトル](https://docs.microsoft.com/windows/iot-core/develop-your-app/signindialogtitlebars)します。
Wake on タッチ | [タッチでスリープ解除](https://docs.microsoft.com/windows/iot-core/learn-about-hardware/wakeontouch)をオフに、ユーザーは、その画面をタッチするとすぐに有効化中に、使用中でないときに、デバイスの画面を使用します。
Windows.System.Update | 新しい[Windows.System.Update 名前空間](https://docs.microsoft.com/uwp/api/windows.system.update)システムの更新プログラムの対話型コントロールできるようにします。 この名前空間には、Windows 10 IoT Core をできるだけです。

## <a name="web-development"></a>Web 開発

機能 | 説明
 :------ | :------
EdgeHTML 18 | Windows 10 年 2018年 10 月 update 付属[EdgeHTML 18](https://docs.microsoft.com/microsoft-edge/dev-guide)最も最近の更新は、Microsoft Edge ブラウザーと UWP アプリ用 JavaScript エンジン。 EdgeHTML 18 は Web 認証 API、WebView コントロールの新機能、革新的と拡張のサポートを提供! ツールの側では、EdgeHTML 18 は、Edge DevTools と Edge DevTools Protocol に WebDriver の新機能と、自動更新と拡張機能をもたらします。 チェック アウト[EdgeHTML 18 の新](https://docs.microsoft.com/microsoft-edge/dev-guide)と[で最新の Windows 10 更新プログラム (EdgeHTML 18) DevTools](https://docs.microsoft.com/microsoft-edge/devtools-guide/whats-new)詳細についてはします。
プログレッシブ Web アプリ | Windows 10 の JavaScript アプリ (web アプリで実行されている、 *WWAHost.exe*プロセス) 省略可能なようになりました[アプリケーションごとのバック グラウンド スクリプト](https://docs.microsoft.com/en-us/microsoft-edge/dev-guide#progressive-web-apps)を任意のビューがアクティブ化される前に起動し、実行中プロセスです。 これにより、監視しナビゲーションの変更、ナビゲーション間をまたいで状態を追跡、ナビゲーションのエラーを監視してビューがアクティブ化する前に、コードを実行します。 指定する場合、 [ `StartPage` ](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appxmanifestschema2010-v2/element-application)で、[アプリ マニフェスト](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appx-package-manifest)の新しいインスタンスとしてスクリプトに公開されるアプリのビュー (windows) の各[ `WebUIView` ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.webui.webuiview)全般 (Win32) として同じイベント、プロパティ、およびメソッドを提供するクラス[WebView](https://docs.microsoft.com/en-us/uwp/api/windows.web.ui.iwebviewcontrol)します。
Web API の拡張機能 | 一連の[従来の Microsoft API 拡張機能](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions)クロスブラウザー web 開発用 Mozilla Developer Network のドキュメントに追加されました。 これらの API 拡張機能は Internet Explorer または Microsoft Edge、一意であり、MDN の web ドキュメントの互換性とブラウザーのサポートに関する既存の情報を補完します。レガシの Microsoft [CSS の拡張機能](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions)と[JavaScript 拡張](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions)も利用してリッチな web API については、MDN の表示で直接を検索できます[Visual Studio Code。](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)
WebVR | 主要更新プログラムを行いましたが、 [WebVR Developer's Guide](https://docs.microsoft.com/microsoft-edge/webvr/)、ホーム ページの完全な再設計やコンテンツのテーブルの再編成など。 など、いくつかの新しいトピックも作成済み。 </br> * [WebVR とは何ですか。](https://docs.microsoft.com/microsoft-edge/webvr/what-is-webvr) WebVR は、それを使用する理由およびその開発を開始する方法について説明します。 </br> * [プログレッシブ Web アプリで WebVR](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-pwas):WebVR にプログレッシブ Web App (PWA) を追加する方法について説明します。 </br> * [WebView の WebVR](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-webview):Windows 10 のアプリケーションで WebView コントロールを WebVR を追加する方法について説明します。 </br> * [WebVR デモ](https://docs.microsoft.com/microsoft-edge/webvr/demos):Microsoft Edge と Windows Mixed Reality イマーシブ ヘッドセットを使用していくつかの WebVR デモをご覧ください。

## <a name="publish--monetize-windows-apps"></a>Windows アプリを公開および収益化する

機能 | 説明
 :------ | :------
MSIX | [MSIX](https://docs.microsoft.com/windows/msix/overview)すべての Windows アプリを最新のパッケージ化エクスペリエンスを提供する新しい Windows アプリ パッケージ形式です。 オープン ソースの MSIX 形式により、既存のパッケージ機能を維持しつつ、最新の展開機能を有効にすることができます。
MSIX パッケージ化ツール | 新しい[MSIX パッケージ化ツール](https://docs.microsoft.com/windows/msix/mpt-overview))、ソース コードへのアクセス権がない場合でも、MSIX 形式で既存のデスクトップ アプリケーションを再パッケージ化することができます。 これは、コマンドライン、またはその対話型の UI を使用して実行できます。
MSIX Desktop App Converter のサポート | 使用することができます、 [Desktop App Converter](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root)を使用して、MSIX パッケージを出力する、`-MakeMSIX`パラメーター。
MSIX の MakeAppx.exe ツールのサポート | MakeAppx.exe ツールを使用して、UWP アプリまたは従来のデスクトップ アプリケーションの MSIX パッケージを作成することができます。 このツールは、Windows 10 SDK に含まれており、コマンド プロンプトまたはスクリプト ファイルから使用できます。 </br> UWP アプリでは、次を参照してください。 [MakeAppx.exe ツールを使用してアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)です。 </br> デスクトップ アプリケーションは、次を参照してください。[デスクトップ アプリケーションを手動でパッケージ化](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-manual-conversion)します。
パッケージのサポートのフレームワーク | [パッケージ サポート フレームワーク](https://docs.microsoft.com/windows/msix/package-support-framework-overview)には、するのに役立つオープン ソース キット適用の修正、既存のデスクトップ アプリケーションと、ソース コードへのアクセスができないときに、MSIX コンテナーで実行できるようにします。
Analytics API を保存します。 | [Microsoft Store analytics API](../monetize/access-analytics-data-using-windows-store-services.md)次のメソッドが含まれています。 </br> * [UWP アプリの insights のデータを取得します。](../monetize/get-insights-data-for-your-app.md) </br> * [お客様のデスクトップ アプリケーションの insights データを取得します。](../monetize/get-insights-data-for-your-desktop-app.md) </br>* [お客様のデスクトップ アプリケーションのアップグレードのブロックを取得します。](../monetize/get-desktop-block-data.md) </br> * [お客様のデスクトップ アプリケーションのアップグレードはブロックの詳細を取得します。](../monetize/get-desktop-block-data-details.md)

## <a name="videos"></a>ビデオ

Fall Creators Update 以降、以下のビデオが公開されました。Windows 10 の開発者向け新機能および強化された機能が紹介されています。

### <a name="cwinrt"></a>C++/WinRT

C +/cli WinRT は、新しい方法を作成して、Windows ランタイム Api を使用します。 ヘッダー ファイルにのみ実装は、最新のアプリの機能を最適にアクセスを提供するために設計されています。 [ビデオを見る](https://www.youtube.com/watch?v=TLSul1XxppA&feature=youtu.be)については、その動作し、[開発者向けドキュメントを読み取る](../cpp-and-winrt-apis/index.md)の詳細。

### <a name="get-started-for-devs-create-and-customize-a-form-on-windows-10"></a>開発者向け概要します。作成し、Windows 10 でのフォームをカスタマイズします。

[開始 docs](../get-started/index.md) Windows の開発者実践的なエクスペリエンスを提供の基本的なアプリの開発タスク。 このビデオでは、これらのトピックのいずれかを説明し、アプリでのフォームの UI の作成の基本について説明します。 [ビデオを見る](https://www.youtube.com/watch?v=AgngKzq4hKI&feature=youtu.be)しアクションでコードを表示する[トピックを確認します。](https://aka.ms/CreateForms)

### <a name="enhance-your-bot-with-project-personality-chat"></a>プロジェクトのパーソナリティ チャット ボットを強化します。

プロジェクト パーソナリティ チャットでは、チャット ボットにカスタマイズ可能なペルソナを追加できます。 Microsoft Bot Framework SDK を統合することで、顧客とやり取りする複数の会話方法の小さなトーク機能を追加できます。 [ビデオを見る](https://www.youtube.com/watch?v=5C_uD8g2QKg&feature=youtu.be)し、実装する方法について[対話型デモを試す](https://aka.ms/PersonalityChat)の実地体験について。

### <a name="multi-instance-uwp-apps"></a>マルチインスタンスの UWP アプリ

Windows を使用して、それぞれに個別のプロセスで、UWP アプリの複数のインスタンスを実行することできるようになりました。 [ビデオを見る](https://www.youtube.com/watch?v=clnnf4cigd0&feature=youtu.be)し、この機能をサポートする新しいアプリを作成する方法について[開発者向けドキュメントを読み取る](../launch-resume/multi-instance-uwp.md)方法の詳細についてのガイダンスとこの機能を使用する理由。

### <a name="xbox-live-unity-plugin"></a>Xbox Live の Unity プラグイン

Unity の Xbox Live プラグインには、タイトルを署名 Xbox Live、統計、フレンド リスト、クラウドの記憶域、およびスコアボードを追加するためのサポートが含まれています。 [ビデオを見る](https://youtu.be/fVQZ-YgwNpY)、詳細については、 [GitHub パッケージをダウンロード](https://aka.ms/UnityPlugin)を開始します。

### <a name="one-dev-question"></a>開発用の 1 つの質問

開発用の 1 つの質問のビデオ シリーズでは、マイクロソフトのベテランの開発者は、一連の Windows の開発、チームのカルチャ、および履歴に関する質問を説明します。

* [Windows 開発と履歴 Raymond Chen](https://www.youtube.com/playlist?list=PLWs4_NfqMtoxjy3LrIdf2oamq1coolpZ7)

* [Windows 開発と履歴の Larry Osterman](https://www.youtube.com/playlist?list=PLWs4_NfqMtoyPUkYGpJU0RzvY6PBSEA4K)

* [プログレッシブ Web Apps での Aaron グスタフソン](https://www.youtube.com/playlist?list=PLWs4_NfqMtoyPHoI-CIB71mEq-om6m35I)

* [Chris Heilmann webhint ツール](https://www.youtube.com/playlist?list=PLWs4_NfqMtow00LM-vgyECAlMDxx84Q2v)

## <a name="samples"></a>サンプル

### <a name="customer-orders-database"></a>顧客注文データベース

[顧客注文データベース サンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)のような新しいコントロールを使用するが更新されました[DataGrid](https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid)、 [NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)、および[Expander](https://docs.microsoft.com/windows/communitytoolkit/controls/expander)します。

### <a name="customer-database-tutorial"></a>顧客データベースのチュートリアル

[顧客データベース チュートリアル](../enterprise/customer-database-tutorial.md)顧客の一覧を管理するための基本的な UWP アプリを作成し、概念およびエンタープライズ開発に役立つプラクティスを紹介します。 UI 要素を実装して、ローカルの SQLite データベースに対する操作を追加することを説明し、さらに移動する場合は、REST のリモート データベースに接続するための緩やかなガイダンスを提供します。

### <a name="photo-editor-cwinrt"></a>C + フォト エディター/cli WinRT

[フォト エディターのサンプル アプリ](https://github.com/Microsoft/Windows-appsample-photo-editor)を使用した開発では紹介、 [C +/cli WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md)言語プロジェクションです。 写真を取得することができます、アプリ、**画像**ライブラリ、および関連付けられている画像の効果を選択したイメージを編集します。

### <a name="windows-machine-learning"></a>Windows Machine Learning

[Windows Machine Learning](https://github.com/Microsoft/Windows-Machine-Learning)リポジトリは、最新の Windows 10 SDK を使用するが更新されで記述されたサンプルが含まれていますC#、C++、および JavaScript。

### <a name="xaml-hosting-api"></a>XAML ホスト API

[XAML をホストしている API のサンプル](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)API (XAML 諸島とも呼ばれます) をホストしている UWP XAML を使用してさまざまなシナリオを強調表示する Win32 デスクトップ アプリです。 プロジェクトには、ギャラリー スタイル プレゼンテーションの Windows Ink、Media Player、およびナビゲーション ビューのコントロールが組み込まれています。 [全般] の外側では、使用量を制御する、サンプルも示します XAML とネイティブの Windows イベント/メッセージ、および基本的な XAML データ バインディングを処理します。
