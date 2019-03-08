---
Description: このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。
ms.assetid: BA689C76-FE68-4B5B-9E8D-1E7697F737E6
title: アクセシビリティに対応したテキストの要件
label: Accessible text requirements
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3f474ec0c3017c3834d3eadb6f1caa989fc188a7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653337"
---
# <a name="accessible-text-requirements"></a>アクセシビリティに対応したテキストの要件  




このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。 また、ユニバーサル Windows プラットフォーム (UWP) アプリ内のテキスト要素に設定できる Microsoft UI オートメーションの役割と、グラフィックス内のテキストに関するベスト プラクティスについても説明します。

<span id="contrast_rations"/>
<span id="CONTRAST_RATIONS"/>

## <a name="contrast-ratios"></a>コントラスト比  
ユーザーはハイ コントラスト モードにいつでも切り替えることができますが、テキスト用のアプリ設計ではこのオプションを最後の手段にする必要があります。 これよりも、アプリのテキストが、テキストと背景とのコントラストのレベルに関して確立されているガイドラインに準拠するようにすることをお勧めします。 コントラストのレベルは、色合いを考慮しない確定的な方法に基づいて評価されます。 たとえば、緑の背景の上に赤のテキストを配置すると、色覚に障碍があるユーザーはそのテキストを読み取ることができない場合があります。 コントラスト比を確認して修正することで、このようなアクセシビリティの問題を防ぐことができます。

Standard、web アクセシビリティのテキストのコントラストがここに記載の推奨事項は[G18:確認する、コントラスト比を少なくとも 4.5: 1 がテキスト (とテキストのイメージ) の間に存在して、テキストの背景](https://go.microsoft.com/fwlink/p/?linkid=221823)します。 このガイドラインは、*W3C Techniques for WCAG 2.0* 仕様に含まれています。

表示テキストがアクセシビリティに対応していると見なされるためには、背景に対する明暗のコントラスト比が最低でも 4.5:1 以上であることが必要です。 ただし、ロゴや、非アクティブな UI コンポーネントの一部のテキストなどの付随テキストは、例外です。

装飾テキストや、伝える情報がないテキストも例外になります。 たとえば、ランダムな文字を使って背景を作成し、意味を変えることなくその文字を再配置したり置換したりできる場合、文字は装飾と見なされ、この基準を満たす必要がありません。

色コントラスト ツールを使って、表示テキストのコントラスト比が適切であることを検証します。 コントラスト比をテストできるツールについては、[Techniques for WCAG 2.0 の G18 (リソース セクション)](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources) をご覧ください。

> [!NOTE]
> Techniques for WCAG 2.0 の G18 にリストされたツールのいくつかは、UWP アプリで対話的に使うことができません。 場合によっては、前景と背景の色の値を手動でツールに入力する必要があります。またアプリ UI の画面をキャプチャした後、そのキャプチャ画像に対してコントラスト比ツールを実行することが必要になる場合もあります。

<span id="Text_element_roles"/>
<span id="text_element_roles"/>
<span id="TEXT_ELEMENT_ROLES"/>

## <a name="text-element-roles"></a>テキスト要素の役割  
UWP アプリでは、次の既定の要素 (一般に*テキスト要素*または*テキスト編集コントロール*と呼ばれる) を使うことができます。

* [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652): 役割は、 [**テキスト**](https://msdn.microsoft.com/library/windows/apps/BR209182)
* [**テキスト ボックス**](https://msdn.microsoft.com/library/windows/apps/BR209683): 役割は、 [**編集**](https://msdn.microsoft.com/library/windows/apps/BR209182)
* [**RichTextBlock** ](https://msdn.microsoft.com/library/windows/apps/BR227565) (とクラスを overflow [ **RichTextBlockOverflow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.richtextblockoverflow)): 役割は、 [**テキスト**](https://msdn.microsoft.com/library/windows/apps/BR209182)
* [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/BR227548): 役割は、 [**編集**](https://msdn.microsoft.com/library/windows/apps/BR209182)

コントロールから [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182) の役割があることが報告されると、支援技術では、ユーザーが値を変更できると想定します。 このため、静的テキストを [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) に配置すると、役割が誤って報告され、この結果、アクセシビリティ対応を必要とするユーザーにアプリの構造が誤って報告されます。

XAML のテキスト モデルでは、静的なテキスト、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)、[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) で主に使われる 2 つの要素があります。 これらはいずれも [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) サブクラスではないため、キーボード フォーカス可能でなく、またタブ オーダーに含めることはできません。 ただし、支援技術でそれらを読み取ることができないか、または読み取られないわけではありません。 スクリーン リーダーは一般的に、「仮想カーソル」など、フォーカスとタブ オーダーを超える専用読み取り値モードやナビゲーション パターンを含めて、アプリ内のコンテンツを読み取る複数のモードをサポートするように設計されています。 したがって、タブ オーダーによりユーザーが移動できることのみを理由として、フォーカス可能なコンテナーに静的テキストを格納しないでください。 支援技術ユーザーは、タブ オーダー内では対話的であることを期待しており、そこに静的なテキストが存在するとその有用性にも増して、混乱を招くことになります。 アプリの静的テキストを調べるためにスクリーン リーダーを使う場合に、アプリに対するユーザー エクスペリエンスの感覚を得るために、自身で、ナレーターによりこの出力のテストを行う必要があります

<span id="Auto-suggest_accessibility"/>
<span id="auto-suggest_accessibility"/>
<span id="AUTO-SUGGEST_ACCESSIBILITY"/>

## <a name="auto-suggest-accessibility"></a>自動提案のアクセシビリティ  
ユーザーが入力フィールドに入力すると、潜在的な候補の一覧が表示される場合、この種のシナリオは自動提案と呼ばれます。 これは、メールの**宛先:** 行フィールド、Windows の Cortana 検索ボックス、Microsoft Edge の URL 入力フィールド、天気予報アプリの場所入力フィールドなどでよく使用されます。 XAML の [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) や HTML の組み込みコントロールを使用している場合、このエクスペリエンスは既定で用意されています。 このエクスペリエンスをアクセシビリティ対応にするには、入力フィールドと一覧を関連付ける必要があります。 これについては、「[自動提案の実装](#implementing_auto-suggest)」セクションで説明しています。

ナレーターは、特別な候補の表示モードによって、このタイプのエクスペリエンスをアクセシビリティ対応にするように更新されました。 大まかに言うと、編集フィールドと一覧が正しく接続されている場合、エンドユーザーには次のようなメリットがあります。

* 一覧が存在していることと一覧が閉じるタイミングを把握する
* 利用可能な入力候補の数を把握する
* 項目が選択されている場合は、選択項目を把握する
* ナレーターのフォーカスを一覧に移動できる
* 他のすべての閲覧モードで候補内を移動できる

![候補リスト](images/autosuggest-list.png)<br/>
_候補リストの例_

<span id="Implementing_auto-suggest"/>
<span id="implementing_auto-suggest"/>
<span id="IMPLEMENTING_AUTO-SUGGEST"/>

### <a name="implementing-auto-suggest"></a>自動提案の実装  
このエクスペリエンスをアクセシビリティ対応にするには、UIA ツリーで、入力フィールドと一覧が関連付けられている必要があります。 この関連付けは、デスクトップ アプリの [UIA_ControllerForPropertyId](https://msdn.microsoft.com/windows/desktop/ee684017) プロパティまたは UWP アプリの [ControlledPeers](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) プロパティを使って設定されます。

自動提案のエクスペリエンスには、大まかに 2 つの種類があります。

**既定の選択**  
一覧で既定の選択が行われる場合、ナレーターは、デスクトップ アプリでは [**UIA_SelectionItem_ElementSelectedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223) イベント、UWP アプリでは [**AutomationEvents.SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントの発生を検索します。 選択項目が変更されるたび、つまりユーザーが別の文字を入力して候補が更新されたときや、ユーザーが一覧内を移動したときに、**ElementSelected** イベントが発生する必要があります。

![既定値を選択した場合、ボックスの一覧します。](images/autosuggest-default-selection.png)<br/>
_例が、既定の選択_

**既定の選択がありません。**  
天気予報アプリの場所のボックスなど、既定の選択がない場合、ナレーターはデスクトップの [**UIA_LayoutInvalidatedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223 ) イベントまたは UWP の [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントの発生を検索します。

![既定値も選択されていないを一覧表示します。](images/autosuggest-no-default-selection.png)<br/>
_例を既定の選択が存在しません。_

### <a name="xaml-implementation"></a>XAML の実装  
XAML の既定の [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) を使用している場合、既にすべての準備が完了しています。 [  **TextBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox) と一覧を使って独自の自動提案エクスペリエンスを作成している場合は、**TextBox** で一覧を [**AutomationProperties.ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) として設定する必要があります。 [  **ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) プロパティを追加または削除するたびに、このプロパティの **AutomationPropertyChanged** イベントを発生させる必要があります。また、この記事で既に説明したシナリオのタイプに応じて、独自の [**SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントまたは [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントを発生させる必要があります。

### <a name="html-implementation"></a>HTML の実装  
HTML で組み込みのコントロールを使っている場合は、UIA 実装が既にマップされています。 既に準備されている実装の例を次に示します。

``` HTML
<label>Sites <input id="input1" type="text" list="datalist1" /></label>
<datalist id="datalist1">
        <option value="http://www.google.com/" label="Google"></option>
        <option value="http://www.reddit.com/" label="Reddit"></option>
</datalist>
```

 独自のコントロールを作成する場合は、W3C 標準で説明されている独自の ARIA コントロールを設定する必要があります。

<span id="Text_in_graphics"/>
<span id="text_in_graphics"/>
<span id="TEXT_IN_GRAPHICS"/>

## <a name="text-in-graphics"></a>グラフィックス内のテキスト

可能な限り、テキストをグラフィックスに含めないでください。 たとえば、アプリで [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) 要素として表示されるイメージ ソース ファイルにテキストを含めると、支援技術ではそのテキストのアクセスや読み取りを自動的に行うことはできません。 グラフィックス内でテキストを使う必要がある場合は、"alt テキスト" に相当するものとして指定する [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) の値に、そのテキストまたはテキストの意味の要約を含めてください。 これは、テキスト文字をベクトルから [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) の一部として作成する場合や、[**Glyphs**](https://msdn.microsoft.com/library/windows/apps/BR209921) を使って作成する場合も同様です。

<span id="Text_font_size"/>
<span id="text_font_size"/>
<span id="TEXT_FONT_SIZE"/>

## <a name="text-font-size-and-scale"></a>テキストのフォント サイズとスケール

ユーザーと、このフォントの用途は、単にアプリ内のテキストを読みづらくなってしまうことができますが小さすぎるように、アプリケーションで任意のテキストが妥当なサイズが最初に確認してください。

完了すると、明確な Windows にはさまざまなアクセシビリティ ツールとユーザーが活用し、独自のニーズとテキストを読み取るための基本設定を調整する設定が含まれます。 次のようなクラスがあります。

* 拡大鏡ツール、UI の選択範囲を拡大します。 アプリ内のテキストのレイアウトが困難に拡大鏡を使用して、読み取り用に行う必要があります。
* スケールと解像度の設定をグローバル**設定]、[システムの表示]-> [-> スケールとレイアウト**します。 正確にサイズ変更オプションが使用可能なディスプレイ デバイスの機能に依存とは異なります。
* テキスト サイズ設定**設定、アクセスの容易さの表示-> **します。 調整、**テキストを大きく**すべてのアプリケーションと画面 (すべての UWP テキスト コントロールは、テキストをカスタマイズまたはテンプレートなしのエクスペリエンスをスケーリングをサポート) 間でのサポート コントロールでテキストのサイズだけを指定する設定。 
> [!NOTE]
> **すべての大きな**設定により、ユーザーのプライマリ画面のみに一般にテキストとアプリの推奨サイズを指定します。

さまざまなテキスト要素とコントロールには [**IsTextScaleFactorEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.istextscalefactorenabled) プロパティがあります。 このプロパティの既定値は **true** です。 ときに**true**、その要素内のテキストのサイズをスケールできます。 スケーリングが小規模のテキストに影響を与えます**FontSize**が大規模なテキストに影響を与えるよりも高いに**FontSize**します。 要素の設定の自動サイズ変更を無効にした**IsTextScaleFactorEnabled**プロパティを**false**します。 

参照してください[テキスト スケーリング](https://docs.microsoft.com/windows/uwp/design/input/text-scaling)の詳細。

次のマークアップをアプリに追加し、それを実行します。 調整、**テキスト サイズ**を設定して、それぞれに何が起こるか見て**TextBlock**します。

XAML
```xml
<TextBlock Text="In this case, IsTextScaleFactorEnabled has been left set to its default value of true."
    Style="{StaticResource BodyTextBlockStyle}"/>

<TextBlock Text="In this case, IsTextScaleFactorEnabled has been set to false."
    Style="{StaticResource BodyTextBlockStyle}" IsTextScaleFactorEnabled="False"/>
```  

テキストのすべてのアプリ間で汎用的スケーリングの UI テキストがユーザーにとっては重要なユーザー補助のスケーリングを無効にすることをお勧めします。

[  **TextScaleFactorChanged**](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged) イベントと [**TextScaleFactor**](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactor) プロパティを使って、電話の **[テキスト サイズ]** 設定の変更に関する情報を確認することもできます。 方法は次のとおりです。

C#
```csharp
{
    ...
    var uiSettings = new Windows.UI.ViewManagement.UISettings();
    uiSettings.TextScaleFactorChanged += UISettings_TextScaleFactorChanged;
    ...
}

private async void UISettings_TextScaleFactorChanged(Windows.UI.ViewManagement.UISettings sender, object args)
{
    var messageDialog = new Windows.UI.Popups.MessageDialog(string.Format("It's now {0}", sender.TextScaleFactor), "The text scale factor has changed");
    await messageDialog.ShowAsync();
}
```

値**TextScaleFactor**が範囲内の二重\[1,2.25\]します。 最も小さい文字がこの大きさまで拡大されます。 たとえば、この値を使ってテキストに合わせてグラフィックスを拡大縮小できます。 ただし、すべてのテキストが同じ倍率で拡大縮小されるわけではないことに注意してください。 一般に、最初の状態のテキストのサイズが大きいほど、拡大縮小の影響は小さくなります。

次の型に **IsTextScaleFactorEnabled** プロパティがあります。  
* [**ContentPresenter**](https://msdn.microsoft.com/library/windows/apps/BR209378)
* [**コントロール**](https://msdn.microsoft.com/library/windows/apps/BR209390)と派生クラス
* [**FontIcon**](https://msdn.microsoft.com/library/windows/apps/Dn279514)
* [**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565)
* [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)
* [**TextElement** ](https://msdn.microsoft.com/library/windows/apps/BR209967)と派生クラス

<span id="related_topics"/>

## <a name="related-topics"></a>関連トピック  

* [テキストのスケーリング](https://docs.microsoft.com/windows/uwp/design/input/text-scaling)
* [アクセシビリティ](accessibility.md)
* [基本的なユーザー補助情報](basic-accessibility-information.md)
* [XAML テキスト表示のサンプル](https://go.microsoft.com/fwlink/p/?linkid=238579)
* [XAML テキスト編集のサンプル](https://go.microsoft.com/fwlink/p/?linkid=251417)
* [XAML のアクセシビリティのサンプル](https://go.microsoft.com/fwlink/p/?linkid=238570) 
