---
author: Xansky
Description: "このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。"
ms.assetid: BA689C76-FE68-4B5B-9E8D-1E7697F737E6
title: "アクセシビリティに対応したテキストの要件"
label: Accessible text requirements
template: detail.hbs
ms.sourcegitcommit: 50c37d71d3455fc2417d70f04e08a9daff2e881e
ms.openlocfilehash: 1307b4f70cf7ffed300f4254a7d92b67b5afd085

---

# アクセシビリティに対応したテキストの要件  




このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。 また、ユニバーサル Windows プラットフォーム (UWP) アプリ内のテキスト要素に設定できる Microsoft UI オートメーションの役割と、グラフィックス内のテキストに関するベスト プラクティスについても説明します。

<span id="contrast_rations"/>
<span id="CONTRAST_RATIONS"/>
## コントラスト比  
ユーザーはハイ コントラスト モードにいつでも切り替えることができますが、テキスト用のアプリ設計ではこのオプションを最後の手段にする必要があります。 これよりも、アプリのテキストが、テキストと背景とのコントラストのレベルに関して確立されているガイドラインに準拠するようにすることをお勧めします。 コントラストのレベルは、色合いを考慮しない確定的な方法に基づいて評価されます。 たとえば、緑の背景の上に赤のテキストを配置すると、色覚に障碍があるユーザーはそのテキストを読み取ることができない場合があります。 コントラスト比を確認して修正することで、このようなアクセシビリティの問題を防ぐことができます。

ここで説明するテキストのコントラストに関する推奨事項は、「[G18: テキスト (および画像化された文字) とテキストの背景のコントラスト比を 4.5:1 以上にする](http://go.microsoft.com/fwlink/p/?linkid=221823)」という Web アクセシビリティ標準に基づいています。 このガイドラインは、*W3C Techniques for WCAG 2.0* 仕様に含まれています。

表示テキストがアクセシビリティに対応していると見なされるためには、背景に対する明暗のコントラスト比が最低でも 4.5:1 以上であることが必要です。 ただし、ロゴや、非アクティブな UI コンポーネントの一部のテキストなどの付随テキストは、例外です。

装飾テキストや、伝える情報がないテキストも例外になります。 たとえば、ランダムな文字を使って背景を作成し、意味を変えることなくその文字を再配置したり置換したりできる場合、文字は装飾と見なされ、この基準を満たす必要がありません。

色コントラスト ツールを使って、表示テキストのコントラスト比が適切であることを検証します。 コントラスト比をテストできるツールについては、[Techniques for WCAG 2.0 の G18 (リソース セクション)](http://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources) をご覧ください。

> [!NOTE]
> Techniques for WCAG 2.0 の G18 にリストされたツールのいくつかは、UWP アプリで対話的に使うことができません。 場合によっては、前景と背景の色の値を手動でツールに入力する必要があります。またアプリ UI の画面をキャプチャした後、そのキャプチャ画像に対してコントラスト比ツールを実行することが必要になる場合もあります。

<span id="Text_element_roles"/>
<span id="text_element_roles"/>
<span id="TEXT_ELEMENT_ROLES"/>
## テキスト要素の役割  
UWP アプリでは、次の既定の要素 (一般に*テキスト要素*または*テキスト編集コントロール*と呼ばれる) を使うことができます。

* [
              **TextBlock**
            ](https://msdn.microsoft.com/library/windows/apps/BR209652): 役割は [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)
* [
              **TextBox**
            ](https://msdn.microsoft.com/library/windows/apps/BR209683): 役割は [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)
* [
              **RichTextBlock**
            ](https://msdn.microsoft.com/library/windows/apps/BR227565) (とオーバーフロー クラス [**RichTextBlockOverflow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.richtextblockoverflow)): 役割は [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)
* [
              **RichEditBox**
            ](https://msdn.microsoft.com/library/windows/apps/BR227548): 役割は [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)

コントロールから [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182) の役割があることが報告されると、支援技術では、ユーザーが値を変更できると想定します。 このため、静的テキストを [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) に配置すると、役割が誤って報告され、この結果、アクセシビリティ対応を必要とするユーザーにアプリの構造が誤って報告されます。

XAML のテキスト モデルでは、静的なテキスト、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)、[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) で主に使われる 2 つの要素があります。 これらはいずれも [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) サブクラスではないため、キーボード フォーカス可能でなく、またタブ オーダーに含めることはできません。 ただし、支援技術でそれらを読み取ることができないか、または読み取られないわけではありません。 スクリーン リーダーは一般的に、「仮想カーソル」など、フォーカスとタブ オーダーを超える専用読み取り値モードやナビゲーション パターンを含めて、アプリ内のコンテンツを読み取る複数のモードをサポートするように設計されています。 したがって、タブ オーダーによりユーザーが移動できることのみを理由として、フォーカス可能なコンテナーに静的テキストを格納しないでください。 支援技術ユーザーは、タブ オーダー内では対話的であることを期待しており、そこに静的なテキストが存在するとその有用性にも増して、混乱を招くことになります。 アプリの静的テキストを調べるためにスクリーン リーダーを使う場合に、アプリに対するユーザー エクスペリエンスの感覚を得るために、自身で、ナレーターによりこの出力のテストを行う必要があります

<span id="Text_in_graphics"/>
<span id="text_in_graphics"/>
<span id="TEXT_IN_GRAPHICS"/>
## グラフィックス内のテキスト  
可能な限り、テキストをグラフィックスに含めないでください。 たとえば、アプリで [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) 要素として表示されるイメージ ソース ファイルにテキストを含めると、支援技術ではそのテキストのアクセスや読み取りを自動的に行うことはできません。 グラフィックス内でテキストを使う必要がある場合は、"alt テキスト" に相当するものとして指定する [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) の値に、そのテキストまたはテキストの意味の要約を含めてください。 これは、テキスト文字をベクトルから [**Path**](https://msdn.microsoft.com/library/windows/apps/BR243355) の一部として作成する場合や、[**Glyphs**](https://msdn.microsoft.com/library/windows/apps/BR209921) を使って作成する場合も同様です。

<span id="Text_font_size"/>
<span id="text_font_size"/>
<span id="TEXT_FONT_SIZE"/>
## テキストのフォント サイズ  
小さすぎて読むことができないサイズのテキスト フォントが使われているだけで、多くのユーザーが、アプリのテキストを読みにくいと感じます。 この問題は、アプリの UI のテキストを最初から適切な大きさにすることで防止できます。 Windows に含まれる支援技術もあり、これらの支援技術では、ユーザーがアプリの表示サイズや通常の表示を変更できるようにします。

* 一部のユーザーはアクセシビリティ対応オプションとして 1 インチあたりのドット数 (dpi) の値を変更します。 このオプションは、**[コンピューターの簡単操作]** の **[画面上の項目を拡大します]** から利用できます。この操作は、**コントロール パネル**の UI の **[デスクトップのカスタマイズ]** / **[ディスプレイ]** にリダイレクトされます。 ディスプレイ デバイスの機能に左右されるため、実際に使用できるサイズ変更のオプションは異なる場合があります。
* 拡大鏡ツールは UI で選択された領域を拡大できます。 ただし、テキストを読むために拡大鏡ツールを使うのは困難です。

<span id="Text_scale_factor"/>
<span id="text_scale_factor"/>
<span id="TEXT_SCALE_FACTOR"/>
## テキストの倍率  
さまざまなテキスト要素とコントロールには [**IsTextScaleFactorEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.istextscalefactorenabled) プロパティがあります。 このプロパティの既定値は **true** です。 値が **true** の場合、電話の **[テキストの拡大縮小]** 設定 (**[設定] &gt; [コンピューターの簡単操作]**) に応じて、対象要素のテキストのサイズが拡大されます。 拡大縮小は、**FontSize** が大きいテキストよりも、**FontSize** が小さいテキストにより大きな影響を及ぼします。 ただし、要素の **IsTextScaleFactorEnabled** プロパティを **false** に設定することで自動拡大を無効にすることができます。 次のマークアップを使って電話の **[テキスト サイズ]** 設定を調整し、**TextBlock** がどうなるのかを確認してください。

XAML
```xml
<TextBlock Text="In this case, IsTextScaleFactorEnabled has been left set to its default value of true."
    Style="{StaticResource BodyTextBlockStyle}"/>

<TextBlock Text="In this case, IsTextScaleFactorEnabled has been set to false."
    Style="{StaticResource BodyTextBlockStyle}" IsTextScaleFactorEnabled="False"/>
```  

ただし、通常は自動拡大を無効にしないでください。一般に、UI テキストの拡大縮小はユーザーにとって重要なアクセシビリティ エクスペリエンスであり、どのアプリでもこの機能が動作することが求められています。

[
            **TextScaleFactorChanged**](https://msdn.microsoft.com/library/windows/apps/Dn633867) イベントと [**TextScaleFactor**](https://msdn.microsoft.com/library/windows/apps/Dn633866) プロパティを使って、電話の **[テキスト サイズ]** 設定の変更に関する情報を確認することもできます。 方法は次のとおりです。

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

**TextScaleFactor** の値は、範囲 \[1,2\] の倍精度浮動小数点数です。 最も小さい文字がこの大きさまで拡大されます。 たとえば、この値を使ってテキストに合わせてグラフィックスを拡大縮小できます。 ただし、すべてのテキストが同じ倍率で拡大縮小されるわけではないことに注意してください。 一般に、最初の状態のテキストのサイズが大きいほど、拡大縮小の影響は小さくなります。

次の型に **IsTextScaleFactorEnabled** プロパティがあります。  
* [**ContentPresenter**](https://msdn.microsoft.com/library/windows/apps/BR209378)
* [
              **Control**
            ](https://msdn.microsoft.com/library/windows/apps/BR209390) クラスと派生クラス
* [**FontIcon**](https://msdn.microsoft.com/library/windows/apps/Dn279514)
* [**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565)
* [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)
* [
              **TextElement**
            ](https://msdn.microsoft.com/library/windows/apps/BR209967) クラスと派生クラス

<span id="related_topics"/>
## 関連トピック  
* [アクセシビリティ](accessibility.md)
* [基本的なアクセシビリティ情報](basic-accessibility-information.md)
* [XAML テキスト表示のサンプル](http://go.microsoft.com/fwlink/p/?linkid=238579)
* [XAML テキスト編集のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=251417)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)



<!--HONumber=Jun16_HO4-->


