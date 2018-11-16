---
author: Xansky
Description: Testing procedures to follow to ensure that your Universal Windows Platform (UWP) app is accessible.
ms.assetid: 272D9C9E-B179-4F5A-8493-926D007A0225
title: アクセシビリティ テスト
label: Accessibility testing
template: detail.hbs
ms.author: mhopkins
ms.date: 05/18/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9b23d06f84a0d798a1e8b9c45a41d33751037402
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6972991"
---
# <a name="accessibility-testing"></a>アクセシビリティ テスト  

ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするためのテスト手順です。

<span id="run_accessibility_testing_tools"/>
<span id="RUN_ACCESSIBILITY_TESTING_TOOLS"/>

## <a name="run-accessibility-testing-tools"></a>アクセシビリティ テスト ツールを実行する  
Windows ソフトウェア開発キット (Windows SDK) には、[**AccScope**](https://msdn.microsoft.com/library/windows/desktop/Dn433239)、[**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521)、[**UI Accessibility Checker**](https://msdn.microsoft.com/library/windows/desktop/Hh920985) などアクセシビリティのテスト ツールが複数用意されています。 これらのツールは、アプリのアクセシビリティを確認するのに役立ちます。 アプリのすべてのシナリオと UI 要素を確認してください。

アクセシビリティ テスト ツールは、Microsoft Visual Studio のコマンド プロンプト、または Windows SDK のツール フォルダー (開発コンピューター上の Windows SDK のインストール ディレクトリの bin サブディレクトリ) から起動できます。
  
> [!VIDEO https://www.youtube.com/embed/ce0hKQfY9B8]
  
<span id="AccScope"/>
<span id="accscope"/>
<span id="ACCSCOPE"/>

### **<a name="accscope"></a>AccScope**  

開発者やテスト担当者は、[**AccScope**](https://msdn.microsoft.com/library/windows/desktop/Dn433239) ツールを使って、アプリ開発サイクルの遅い段階のテスト フェーズではなく、アプリの開発フェーズ、設計フェーズ、場合によってはより早い段階のプロトタイプ フェーズで、アプリのアクセシビリティを評価できます。 このツールは、特にアプリのナレーター アクセシビリティ シナリオのテストを意図しています。

<span id="inspect"/>
<span id="INSPECT"/>

### **<a name="inspect"></a>Inspect**  

[**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) を使うと、任意の UI 要素を選んで、そのアクセシビリティ データを表示できます。 Microsoft UI オートメーションのプロパティと制御パターンを表示し、UI オートメーション ツリー内のオートメーション要素のナビゲーション構造をテストできます。 UI の開発時に **Inspect** を使って、アクセシビリティ属性が UI オートメーションでどのように現れるか確認します。 属性は、既定の XAML コントロールに既に実装されている UI オートメーション サポートのものである場合や、 [**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties) 添付プロパティとして、XAML マークアップで設定した特定の値のものである場合があります。

次の図は、メモ帳の **[編集]** メニュー要素の UI オートメーション プロパティを照会する [**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) ツールを示しています。

![Inspect ツールのスクリーン ショット。](./images/inspect.png)

<span id="ui_accessibility_checker"/>
<span id="UI_ACCESSIBILITY_CHECKER"/>

### **<a name="ui-accessibility-checker"></a>UI Accessibility Checker**  
**UI Accessibility Checker (AccChecker)** は、実行時にアクセシビリティの問題を検出するのに役立ちます。 UI が完成したら、**AccChecker** を使って、さまざまなシナリオをテストし、実行時のアクセシビリティ情報が正しいことを確認して、実行時の問題を検出します。 **AccChecker** は UI モードまたはコマンド ライン モードで実行できます。 UI モード ツールを実行するには、Windows ソフトウェア開発キット (Windows SDK) の bin ディレクトリの **AccChecker** ディレクトリを開き、acccheckui.exe を実行し、**[ヘルプ]** メニューをクリックしてください。

<span id="ui_automation_verify"/>
<span id="UI_AUTOMATION_VERIFY"/>

### **<a name="ui-automation-verify"></a>UI Automation Verify**  
**UI Automation Verify (UIA Verify)** は、UI オートメーション実装のテストと検証を自動で行うフレームワークです。 **UIA Verify** は、テスト コードに統合することができ、UI オートメーション シナリオの定期的な自動テストやスポット チェックを行うことができます。 **UIA Verify** を実行するには、UIAVerify サブディレクトリから VisualUIAVerifyNative.exe を実行します。

<span id="accessible_event_watcher"/>
<span id="ACCESSIBLE_EVENT_WATCHER"/>

### **<a name="accessible-event-watcher"></a>Accessible Event Watcher**  
[**Accessible Event Watcher (AccEvent)**](https://msdn.microsoft.com/library/windows/desktop/Dd317979) は、UI の変更が発生した場合に、アプリの UI 要素が UI オートメーションと Microsoft Active Accessibility の適切なイベントを発生させるかどうかをテストします。 UI の変更は、フォーカスが移動したときや、UI 要素の呼び出しまたは選択が行われたとき、状態またはプロパティが変更された場合に発生することがあります。

> [!NOTE]
> ドキュメントで説明したほとんどのアクセシビリティ テスト ツールは、PC で動作し、電話では動作しません。 一部のツールは開発中にエミュレーターを使って実行できますが、それらのツールのほとんどはエミュレーターで UI オートメーション ツリーを表示できません。

<span id="test_keyboard_accessibility"/>
<span id="TEST_KEYBOARD_ACCESSIBILITY"/>

## <a name="test-keyboard-accessibility"></a>キーボード アクセシビリティをテストする  
キーボード アクセシビリティをテストするには、マウスを取り外す (タブレット デバイスを使っている場合は、スクリーン キーボードを使う) ことが最も良い方法です。 キーボード アクセシビリティのナビゲーションをテストするには、_Tab_ キーを使います。 すべての対話型 UI 要素に _Tab_ キーで移動できる必要があります。 コンポジット UI 要素については、方向キーを使って要素の部分間を移動できることを確認します。 たとえば、キーボードのキーを使って項目の一覧間を移動できる必要があります。 さらに、すべての対話型 UI 要素を、フォーカスがあるときにキーボードで実行できる (通常は Enter キーまたは Space キーを使う) ことを確認します。

<span id="verify_the_contrast_ratio_of_visible_text"/>
<span id="VERIFY_THE_CONTRAST_RATIO_OF_VISIBLE_TEXT"/>

## <a name="verify-the-contrast-ratio-of-visible-text"></a>表示テキストのコントラスト比を確認する  
色コントラスト ツールを使って、表示テキストのコントラスト比が適切であることを検証します。 ただし、非アクティブな UI 要素や、何も情報を伝えず、意味を変えることなく再配置できるロゴまたは装飾テキストは、例外です。 コントラスト比と例外について詳しくは、「[アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)」をご覧ください。 コントラスト比をテストできるツールについては、[Techniques for WCAG 2.0 の G18 (リソース セクション)](http://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources) をご覧ください。

> [!NOTE]
> Techniques for WCAG 2.0 の G18 にリストされたツールのいくつかは、UWP アプリで対話的に使うことができません。 場合によっては、前景と背景の色の値を手動でツールに入力する必要があります。またアプリ UI の画面をキャプチャした後、そのキャプチャ画像に対してコントラスト比ツールを実行することが必要になる場合もあります。また、画像編集プログラムでソース ビットマップ ファイルを開いている間 (その画像がアプリによって読み込まれているときではなく) にツールを実行することが必要になる場合もあります。

<span id="verify_your_app_in_high_contrast"/>
<span id="VERIFY_YOUR_APP_IN_HIGH_CONTRAST"/>

## <a name="verify-your-app-in-high-contrast"></a>アプリをハイ コントラストで確認する  
ハイ コントラスト テーマがアクティブになっている状態でアプリを使って、すべての UI 要素が適切に表示されることを確認します。 すべてのテキストを読み取ることができ、すべての画像がクリアに表示されている必要があります。 XAML テーマ ディクショナリのリソースまたはコントロール テンプレートを調整し、コントロールが原因であるテーマの問題があれば修正します。 ハイ コントラストの重大な問題の原因がテーマまたはコントロール (イメージ ファイルなど) でない場合は、ハイ コントラスト テーマがアクティブになっているときに使う別のバージョンを用意します。

<span id="verify_your_app_with_make_everything_on_your_screen_bigger"/>
<span id="VERIFY_YOUR_APP_WITH_MAKE_EVERYTHING_ON_YOUR_SCREEN_BIGGER"/>

## <a name="verify-your-app-with-display-settings"></a>アプリの表示設定を確認する  

ディスプレイの 1 インチあたりのドット数 (dpi) の値を調整するシステム ディスプレイ オプションを使い、DPI の値の変更に合わせてアプリの UI が正常に拡大縮小されることを確認します  (一部のユーザーはアクセシビリティ対応オプションとして DPI の値を変更します。これは、**[コンピューターの簡単操作]** からだけでなく各種の表示プロパティでも設定できます)。問題が見つかった場合は、[レイアウトとスケーリングのガイドライン](https://msdn.microsoft.com/library/windows/apps/Dn611863) に従い、さまざまなスケール ファクター用のリソースを追加します。

<span id="verify_main_app_scenarios_by_using_narrator"/>
<span id="VERIFY_MAIN_APP_SCENARIOS_BY_USING_NARRATOR"/>

## <a name="verify-main-app-scenarios-by-using-narrator"></a>ナレーターでアプリの主要なシナリオを確認する  
ナレーターを使ってアプリの画面の読み上げをテストします。

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-Narrator-and-Dev-Mode/player]

**次の手順に従って、マウスとキーボードでナレーターを使ってアプリをテストします。**
1.  _Windows ロゴ キー、Ctrl キー、Enter キー_を同時に押して、ナレーターを起動します。 Windows 10 Version 1607 より前のバージョンでは、_Windows ロゴ キーと Enter キー_を同時に押して、ナレーターを起動します。
2.  キーボードを使ってアプリ内を移動するには、_Tab_ キーと方向キーを使うか、_CapsLock キーを押しながら方向キー_を使います。
3.  アプリ内を移動しながら、ナレーターが UI 要素を読み上げるのを聞き取り、次の点を確かめます。
    * コントロールごとに、すべての表示コンテンツがナレーターによって読み上げられるのを確かめます。 また、各コントロールの名前、該当する状態 (オン、選択済みなど)、種類 (ボタン、チェック ボックス、一覧項目など) がナレーターによって読み上げられるのを確かめます。
    * 要素が対話型である場合は、_CapsLock キーを押しながら Enter キー_を押すことにより、操作を起動するためにナレーターを使用できることを確認します。
    * 表ごとに、表の名前、説明 (存在する場合)、行見出しと列見出しがナレーターによって正しく読み上げられるのを確かめます。

4.  _CapsLock キー、Shift キー、Enter キー_を同時に押すことでアプリを検索し、すべてのコントロールが検索一覧に表示されることとコントロール名がローカライズされて読み取り可能であることを確かめます。
5.  モニターをオフにし、キーボードとナレーターのみを使ってアプリの主要なシナリオを実行できることを確かめます。 ナレーターのすべてのコマンドとショートカットの一覧を表示するには、_CapsLock キーを押しながら F1 キー_を押します。

Windows 10 バージョン 1607 以降では、ナレーターで新しい開発者モードが導入されました。 ナレーターがオンになっている場合、_CapsLock キー、Shift キー、F12 キー_を同時に押して、開発者モードをオンにします。 開発者モードを有効にすると、画面がマスクされ、アクセス可能なオブジェクトとナレーターにプログラムで公開されている関連のテキストのみが強調表示されます。 これにより、ナレーターに公開されている情報が適切な方法で視覚的に表示されます。

**ナレーターのタッチ モードを使ってアプリをテストするには、次の手順を実行します。**

> [!NOTE]
> 4 つ以上のコンタクトをサポートするデバイスの場合、ナレーターは自動的にタッチ モードに移行します。 ナレーターは、マルチモニターや主要画面でのマルチタッチ デジタイザーをサポートしません。

1.  UI を操作し、レイアウトを確かめます。

    * **指 1 本のスワイプ ジェスチャを使って、UI を操作します。** 項目間を移動するには左右のスワイプを使い、項目のカテゴリを変更するには上下のスワイプを使います。 カテゴリには、すべての項目、リンク、表、見出しなどがあります。 指 1 本のスワイプ ジェスチャによるナビゲーションは、_CapsLock キーを押しながら方向キー_を押すことによるナビゲーションとほぼ同じです。
    * **タブ ジェスチャを使って、フォーカス可能な要素を移動します。** 指 3 本を使った左右のスワイプは、キーボードで _Tab_ キーを押したり、_Shift キーを押しながら Tab キー_ を押したりするのと同じです。
    * **指 1 本を使って UI を空間的に調査します。** 1 本の指を上下左右にドラッグして、ナレーターに指の下の項目を読み上げさせます。 代わりにマウスを使うこともできます。マウスでも 1 本指でのドラッグと同じヒット テスト ロジックを使っているためです。
    * **3 本指で上方向へスワイプすることで、ウィンドウ全体とウィンドウの全内容を読み上げます**。 これは、_CapsLock キーを押しながら W キー_を押すのと同じです。

    重要な UI にアクセスできない場合、アクセシビリティに問題が存在する可能性があります。

2.  コントロールを操作して、プライマリ操作、セカンダリ操作、スクロール動作をテストします。

    プライマリ操作には、ボタンのアクティブ化、テキスト キャレットの配置、コントロールへのフォーカスの設定などが含まれます。 セカンダリ操作には、一覧項目の選択、オプションが複数あるボタンの展開などの操作が含まれます。

    * プライマリ操作のテスト: ダブルタップするか、指で押しながら別の指でタップします。
    * セカンダリ操作のテスト: トリプルタップするか、指で押しながら別の指でダブルタップします。
    * スクロール操作のテスト: 2 本指でスワイプし、目的の方向にスクロールします。

    一部のコントロールには、その他の操作も用意されています。 すべての一覧を表示するには、4 本指で 1 回タップします。

    マウスまたはキーボードに応答し、プライマリ タッチ操作またはセカンダリ タッチ操作に応答しないコントロールの場合、新しい [UI オートメーション](https://msdn.microsoft.com/library/windows/desktop/Ee684009) コントロール パターンを実装する必要があります。

また、[**AccScope**](https://msdn.microsoft.com/library/windows/desktop/Dn433239) ツールを使ってアプリのナレーター アクセシビリティ シナリオをテストすることも検討してください。 「[**AccScope ツール トピック**](https://msdn.microsoft.com/library/windows/desktop/Dn433239)」では、ナレーター シナリオをテストするための **AccScope** の構成方法について説明しています。

<span id="Examine_the_UI_Automation_representation_for_your_app"/>
<span id="examine_the_ui_automation_representation_for_your_app"/>
<span id="EXAMINE_THE_UI_AUTOMATION_REPRESENTATION_FOR_YOUR_APP"/>

## <a name="examine-the-ui-automation-representation-for-your-app"></a>アプリの UI オートメーションの表現を確認する  
前述したいくつかの UI オートメーション テスト ツールでは、アプリがどのように見えるかを緩慢に考慮するのではなく、UI オートメーション要素の構造としてアプリを表現する方法についてアプリを確認する手段を提供しています。 この方法によって、UI オートメーション クライアント (主に支援技術) がアクセシビリティのシナリオでアプリを操作します。

[**AccScope**](https://msdn.microsoft.com/library/windows/desktop/Dn433239) ツールでは、視覚的な表現またはリストのいずれかとして UI オートメーション要素を表示できるので、アプリについて特に興味深いビューが得られます。 視覚エフェクトを使うと、アプリの UI の視覚的な外観に関連するように各部にドリルダウンできます。 すべてのロジックを UI に割り当てる前に、最初期の UI プロトタイプのアクセシビリティをテストすることさえ可能であり、アプリの視覚的な対話操作とアクセシビリティ シナリオのナビゲーションについて双方のバランスを確認できます。

テスト可能な側面の 1 つとして、表示したくない要素が UI オートメーション要素ビューに表示されるかどうかがあります。 ビューから除外したい要素、または反対に欠落する要素が見つかった場合に、アクセシビリティ ビューで XAML コントロールの表示を調整するために [**AutomationProperties.AccessibilityView XAML**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.accessibilityview) 添付プロパティを使用できます。 基本的なアクセシビリティ ビューを確認した後、コントロール ビューに公開される対話型の各部分にユーザーがアクセスできるかどうかについて、方向キーによって使用可能なタブ シーケンスまたは空間的なナビゲーションを再確認することもお勧めします。

<span id="related_topics"/>

## <a name="related-topics"></a>関連トピック  
* [アクセシビリティ](accessibility.md)
* [避ける事項](practices-to-avoid.md)
* [UI オートメーション](https://msdn.microsoft.com/library/windows/desktop/Ee684009)
* [Windows のアクセシビリティ](http://go.microsoft.com/fwlink/p/?LinkId=320802)
* [ナレーターの概要](https://support.microsoft.com/help/22798/windows-10-narrator-get-started)
