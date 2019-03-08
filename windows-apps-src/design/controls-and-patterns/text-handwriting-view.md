---
Description: RichEditBox (と同様のテキスト入力エクスペリエンスを提供する、AutoSuggestBox などのコントロール) など、テキスト ボックスに、UWP テキスト コントロールでサポートされているテキスト入力をインクの組み込みの手書きビューをカスタマイズします。
title: ビューを手書きのテキスト入力
label: Text input with the handwriting view
template: detail.hbs
ms.date: 10/13/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: sewen
design-contact: minah.kim
doc-status: Draft
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: f7b31898e6a90410e4edc73ee36f71a7e4d94155
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634917"
---
# <a name="text-input-with-the-handwriting-view"></a>ビューを手書きのテキスト入力

![ペンでタップするとテキスト ボックスが展開する](images/handwritingview/handwritingview2.gif)

など、UWP のテキスト コントロールでサポートされているテキスト入力をインクの組み込みの手書きのビューをカスタマイズ、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)、 [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)、およびこれらから派生したなどのコントロール、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)します。

## <a name="overview"></a>概要

XAML テキスト入力ボックス機能を使用して入力ペンのサポートが組み込ま[Windows インク](../input/pen-and-stylus-interactions.md)します。 ユーザーはタップ Windows ペンを使用して、テキスト入力ボックスに、テキスト ボックスは個別の入力パネルを開くのではなく、手書きの画面に変換します。

テキストが認識するは、ユーザーを書き込む任意の場所で、テキスト ボックスと候補のウィンドウには、認識結果が表示されます。 ユーザーは結果をタップしてそれを選択したり、さらに書き込んで提案された候補を受け入れたりすることができます。 リテラル (1 文字ずつ) による認識結果は候補ウィンドウに含まれているため、認識はディクショナリ内の単語に制限されません。 ユーザーが手書きで入力すると、受け入れられたテキスト入力は自然な手書き感を維持して Script フォントに変換されます。

> [!NOTE]
> 既定では、手書きのビューが有効になっているが、コントロールごとでは無効にし、代わりに、テキスト入力パネルを元に戻すことができます。

![インクと提案されたテキスト ボックス](images/handwritingview/handwritingview-inksuggestion1.gif)

ユーザーは、次のような標準的なジェスチャや操作を使用してテキストを編集できます。

- _取り消し線_または_インクを消す_ - 単語や単語の一部を削除します
- _結合_ - 単語間に円弧を描き、単語間のスペースを削除します
- _挿入_- スペースを挿入するキャレット記号を描画します
- _上書き_- 既存のテキストの上に書き込み、それを置き換えます

![テキスト ボックスにインクの修正](images/handwritingview/handwritingview-inkcorrection1.gif)

## <a name="disable-the-handwriting-view"></a>手書きのビューを無効にします。

組み込みの手書きのビューは、既定で有効です。

アプリケーションでは、既にインクからテキストへの同等の機能を提供するか、テキスト入力の経験がある種の書式設定や特殊文字 (タブ) など手書きからは利用できない依存手書きビューを無効にすることがあります。

この例で手書きのビュー設定を無効に、 [IsHandwritingViewEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.ishandwritingviewenabled)のプロパティ、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)コントロールを false にします。 手書きビューをサポートするすべてのテキスト コントロールのようなプロパティをサポートします。

```xaml
<TextBox Name="SampleTextBox"
    Height="50" Width="500" 
    FontSize="36" FontFamily="Segoe UI" 
    PlaceholderText="Try taping with your pen" 
    IsHandwritingViewEnabled="False">
</TextBox>
```

## <a name="specify-the-alignment-of-the-handwriting-view"></a>手書きビューの配置を指定します。

手書きビューの基になるテキスト コントロールの上にあるし、ユーザーの手書き認識の基本設定を格納できるだけのサイズ (を参照してください**設定]、[デバイスのペンを -> & Windows インクが手書きを -> に直接記述する場合は、フォントのサイズを ->テキスト フィールド**)。 ビューは、テキスト コントロールと、アプリ内での位置を基準も自動的に配置されます。

アプリケーションの UI は、システムが重要な UI に表示が発生する可能性がありますので、大きい方のコントロールを対応するためにフローを変更できません。

ここでは、使用する方法を示します、 [PlacementAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.placementalignment)のプロパティを[TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)整列するために使用する、基になるテキスト コントロールのどのアンカーを指定する、手書き文字を表示します。

```xaml
<TextBox Name="SampleTextBox"
    Height="50" Width="500" 
    FontSize="36" FontFamily="Segoe UI" 
    PlaceholderText="Try taping with your pen">
        <TextBox.HandwritingView>
            <HandwritingView PlacementAlignment="TopLeft"/>
        </TextBox.HandwritingView>
</TextBox>
```

## <a name="disable-auto-completion-candidates"></a>オート コンプリートの候補を無効にします。

テキストの修正候補のポップアップは、上のインクの一覧に、ユーザーが元の候補の最上位に位置が正しくない場合に選択できる認識候補を提供する、既定で有効です。

既にアプリケーションが、堅牢なカスタムの認識機能を提供する場合は使用できます、 [AreCandidatesEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.arecandidatesenabled)プロパティを次の例に示すように、組み込みの推奨事項を無効にします。

```xaml
<TextBox Name="SampleTextBox"
    Height="50" Width="500" 
    FontSize="36" FontFamily="Segoe UI" 
    PlaceholderText="Try taping with your pen">
        <TextBox.HandwritingView>
            <HandwritingView AreCandidatesEnabled="False"/>
        </TextBox.HandwritingView>
</TextBox>
```

## <a name="use-handwriting-font-preferences"></a>手書き文字のフォント設定を使用して、

ユーザーが選択できるときに使用するフォントの手書き文字ベースの定義済みコレクション インクの認識に基づいてテキストのレンダリング (を参照してください**設定、デバイス ペンを -> & Windows インク手書き-> 手書きを使用する場合、フォント->**).

> [!NOTE]
> ユーザーは、自分の書いたに基づいてフォントを作成することもできます。
> [!VIDEO https://www.youtube.com/embed/YRR4qd4HCw8]

アプリでは、この設定にアクセスでき、テキスト コントロールに認識されたテキストの選択したフォントを使用することができます。

リッスンこの例で、 [TextChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.textchanged)のイベントを[TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) HandwritingView (または既定のフォント、ない場合) からのテキスト変更が発生した場合、ユーザーの選択したフォントを適用します。

```csharp
private void SampleTextBox_TextChanged(object sender, TextChangedEventArgs e)
{
    ((TextBox)sender).FontFamily = 
        ((TextBox)sender).HandwritingView.IsOpen ?
            new FontFamily(PenAndInkSettings.GetDefault().FontFamilyName) : 
            new FontFamily("Segoe UI");
}
```

## <a name="access-the-handwritingview-in-composite-controls"></a>複合コントロールで HandwritingView へのアクセスします。

複合コントロールを使用して、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)または[RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)などのコントロール[AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)サポートも、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)します。

アクセスする、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)複合コントロールで使用して、 [VisualTreeHelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper) API。

次の XAML スニペットが表示されます、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)コントロール。

```xaml
<AutoSuggestBox Name="SampleAutoSuggestBox" 
    Height="50" Width="500" 
    PlaceholderText="Auto Suggest Example" 
    FontSize="16" FontFamily="Segoe UI"  
    Loaded="SampleAutoSuggestBox_Loaded">
</AutoSuggestBox>
```

対応するコードの分離、無効にする方法を説明します、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)上、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)します。

1. アプリケーションの読み込まれたイベントを処理最初に、ビジュアル ツリーの走査を開始する FindInnerTextBox 関数を呼び出すことです。

    ```csharp
    private void SampleAutoSuggestBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (FindInnerTextBox((AutoSuggestBox)sender))
            autoSuggestInnerTextBox.IsHandwritingViewEnabled = false;
    }
    ```

2. FindVisualChildByName への呼び出しを FindInnerTextBox 関数には、(、AutoSuggestBox から始まります)、ビジュアル ツリーを反復処理すること、開始します。

    ```csharp
    private bool FindInnerTextBox(AutoSuggestBox autoSuggestBox)
    {
        if (autoSuggestInnerTextBox == null)
        {
            // Cache textbox to avoid multiple tree traversals. 
            autoSuggestInnerTextBox = 
                (TextBox)FindVisualChildByName<TextBox>(autoSuggestBox);
        }
        return (autoSuggestInnerTextBox != null);
    }
    ```

3. 最後に、テキスト ボックスが取得されるまでは、ビジュアル ツリーをこの関数が反復処理します。

    ```csharp
    private FrameworkElement FindVisualChildByName<T>(DependencyObject obj)
    {
        FrameworkElement element = null;
        int childrenCount = 
            VisualTreeHelper.GetChildrenCount(obj);
        for (int i = 0; (i < childrenCount) && (element == null); i++)
        {
            FrameworkElement child = 
                (FrameworkElement)VisualTreeHelper.GetChild(obj, i);
            if ((child.GetType()).Equals(typeof(T)) || (child.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
            {
                element = child;
            }
            else
            {
                element = FindVisualChildByName<T>(child);
            }
        }
        return (element);
    }
    ```

## <a name="reposition-the-handwritingview"></a>位置の変更、HandwritingView

場合によっては、ことを確認する必要があります、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)されませんが、それ以外の場合の UI 要素について説明します。

ここでは、音声入力 (テキスト ボックスと [ディクテーション] ボタンを StackPanel に配置することで実装) をサポートするテキスト ボックスを作成します。

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation.png)

StackPanel がテキスト ボックスより大きい、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)複合コントロールのすべてがない可能性があります。

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation-handwritingview.png)

これに対処の PlacementTarget プロパティを設定、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)に UI 要素を配置する必要があります。

```xaml
<StackPanel Name="DictationBox" 
    Orientation="Horizontal" 
    VerticalAlignment="Top" 
    HorizontalAlignment="Left" 
    BorderThickness="1" BorderBrush="DarkGray" 
    Height="55" Width="500" Margin="50">
    <TextBox Name="DictationTextBox" 
        Width="450" BorderThickness="0" 
        FontSize="24" VerticalAlignment="Center">
        <TextBox.HandwritingView>
            <HandwritingView PlacementTarget="{Binding ElementName=DictationBox}"/>
        </TextBox.HandwritingView>
    </TextBox>
    <Button Name="DictationButton" 
        Height="48" Width="48" 
        FontSize="24" 
        FontFamily="Segoe MDL2 Assets" 
        Content="&#xE720;" 
        Background="White" Foreground="DarkGray"     Tapped="DictationButton_Tapped" />
</StackPanel>
```

## <a name="resize-the-handwritingview"></a>HandwritingView のサイズを変更します。

サイズを設定することも、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)、重要な UI がしません、ビューを確認する必要がある場合に便利ですができます。

前の例のように、音声入力 (テキスト ボックスと [ディクテーション] ボタンを StackPanel に配置することで実装) をサポートするテキスト ボックスを作成します。

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation.png)

この場合、ディクテーション ボタンが常に表示されていることを確認します。

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation-handwritingview-resize.png)

これを行うには、バインドの MaxWidth プロパティ、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)する必要がありますが、UI 要素の幅にします。

```xaml
<StackPanel Name="DictationBox" 
    Orientation="Horizontal" 
    VerticalAlignment="Top" 
    HorizontalAlignment="Left" 
    BorderThickness="1" 
    BorderBrush="DarkGray" 
    Height="55" Width="500" 
    Margin="50">
    <TextBox Name="DictationTextBox" 
        Width="450" 
        BorderThickness="0" 
        FontSize="24" 
        VerticalAlignment="Center">
        <TextBox.HandwritingView>
            <HandwritingView 
                PlacementTarget="{Binding ElementName=DictationBox}“
                MaxWidth="{Binding ElementName=DictationTextBox, Path=Width"/>
        </TextBox.HandwritingView>
    </TextBox>
    <Button Name="DictationButton" 
        Height="48" Width="48" 
        FontSize="24" 
        FontFamily="Segoe MDL2 Assets" 
        Content="&#xE720;" 
        Background="White" Foreground="DarkGray" 
        Tapped="DictationButton_Tapped" />
</StackPanel>
```

## <a name="reposition-custom-ui"></a>カスタム UI の位置を変更します。

情報のポップアップなどのテキスト入力に応答に表示されるカスタムの UI がある場合は、手書きのビューがそのしないようにその UI の位置を変更する必要があります。

![カスタム UI を含む TextBox](images/handwritingview/textbox-with-customui.png)

次の例では、リッスンする方法を示しています、 [Opened](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.opened)、 [Closed](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.closed
)、および[SizeChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.sizechanged)のイベント、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)を設定する、位置を[ポップアップ](https://docs.microsoft.com/uwp/api/windows.ui.popups)します。

```csharp
private void Search_HandwritingViewOpened(
    HandwritingView sender, HandwritingPanelOpenedEventArgs args)
{
    UpdatePopupPositionForHandwritingView();
}

private void Search_HandwritingViewClosed(
    HandwritingView sender, HandwritingPanelClosedEventArgs args)
{
    UpdatePopupPositionForHandwritingView();
}

private void Search_HandwritingViewSizeChanged(
    object sender, SizeChangedEventArgs e)
{
    UpdatePopupPositionForHandwritingView();
}

private void UpdatePopupPositionForHandwritingView()
{
if (CustomSuggestionUI.IsOpen)
    CustomSuggestionUI.VerticalOffset = GetPopupVerticalOffset();
}

private double GetPopupVerticalOffset()
{
    if (SearchTextBox.HandwritingView.IsOpen)
        return (SearchTextBox.Margin.Top + SearchTextBox.HandwritingView.ActualHeight);
    else
        return (SearchTextBox.Margin.Top + SearchTextBox.ActualHeight);    
}
```

## <a name="retemplate-the-handwritingview-control"></a>Retemplate HandwritingView コントロール

XAML フレームワークのすべてのコントロールで、視覚的な構造との視覚的な動作をカスタマイズすることができます、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)特定の要件。

カスタム テンプレートのチェック アウトを作成する完全な例を表示する、[カスタム トランスポート コントロールを作成](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/custom-transport-controls)に関する「方法」、または[カスタム編集コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl)します。








