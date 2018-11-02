---
author: Karl-Bridge-Microsoft
Description: Customize the built-in handwriting view for ink to text input that is supported by UWP text controls such as the TextBox, RichEditBox (and controls like the AutoSuggestBox that provide a similar text input experience).
title: テキスト入力と手書きビュー
label: Text input with the handwriting view
template: detail.hbs
ms.author: kbridge
ms.date: 10/13/18
ms.topic: article
keywords: Windows 10, UWP
pm-contact: sewen
design-contact: minah.kim
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: aa235086f2410fb97ea60e35fb03c586824928a2
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5928751"
---
# <a name="text-input-with-the-handwriting-view"></a>テキスト入力と手書きビュー

![ペンでタップするとテキスト ボックスが展開する](images/handwritingview/handwritingview2.gif)

[TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)、 [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)などの UWP テキスト コントロールでサポートされているテキスト入力をインクの手書き入力の組み込みビューをカスタマイズし、コントロールがこれらの[AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)などから派生します。

## <a name="overview"></a>概要

XAML テキスト入力ボックス機能は[Windows Ink](../input/pen-and-stylus-interactions.md)を使用して入力ペンの埋め込みをサポートします。 Windows ペンを使用して、テキスト入力ボックスにタップ、テキスト ボックスは、別の入力パネルを開くのではなく、手書き入力サーフェスに変換します。

テキストは、ユーザーが任意の場所、テキスト ボックスで、候補ウィンドウには、認識結果が表示されますが認識されます。 ユーザーは結果をタップしてそれを選択したり、さらに書き込んで提案された候補を受け入れたりすることができます。 リテラル (1 文字ずつ) による認識結果は候補ウィンドウに含まれているため、認識はディクショナリ内の単語に制限されません。 ユーザーが手書きで入力すると、受け入れられたテキスト入力は自然な手書き感を維持して Script フォントに変換されます。

> [!NOTE]
> 既定では、手書きのビューが有効になっているが、コントロールごとに無効にし、代わりに、テキスト入力パネルに戻すことができます。

![インクやご提案されたテキスト ボックス](images/handwritingview/handwritingview-inksuggestion1.gif)

ユーザーは、次のような標準的なジェスチャや操作を使用してテキストを編集できます。

- _取り消し線_または_インクを消す_ - 単語や単語の一部を削除します
- _結合_ - 単語間に円弧を描き、単語間のスペースを削除します
- _挿入_- スペースを挿入するキャレット記号を描画します
- _上書き_- 既存のテキストの上に書き込み、それを置き換えます

![インク修正されたテキスト ボックス](images/handwritingview/handwritingview-inkcorrection1.gif)

## <a name="disable-the-handwriting-view"></a>手書きの表示を無効にします。

組み込みの手書きビューは既定で有効にします。

手書きビューを無効にする場合は、アプリケーションで既にインクからテキストへの同等の機能を提供する、またはテキスト入力エクスペリエンスが何らかの書式設定または特殊文字 (は、タブなど) 手書きからは利用できないに依存する可能性があります。

この例で、手書きのビューを無効にによって、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)コントロールの[IsHandwritingViewEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.ishandwritingviewenabled)プロパティを false に設定します。 手書きのビューをサポートするすべてのテキスト コントロールでは、同様のプロパティをサポートします。

```xaml
<TextBox Name="SampleTextBox"
    Height="50" Width="500" 
    FontSize="36" FontFamily="Segoe UI" 
    PlaceholderText="Try taping with your pen" 
    IsHandwritingViewEnabled="False">
</TextBox>
```

## <a name="specify-the-alignment-of-the-handwriting-view"></a>手書きのビューの配置を指定します。

手書きのビューを基になるテキスト コントロールの上にあるし、ユーザーの手書き入力の設定に合わせてサイズ (**設定のデバイス]-> [ペン]-> [し、Windows Ink 手書き]-> [テキスト フィールドに直接作成する際のフォント サイズ]-> [**). ビューは、テキスト コントロールと、アプリ内での位置を基準としたも自動的に配置されます。

アプリケーションの UI は、システム重要な UI が見えなくビューが発生する可能性がありますので、大型のコントロールを対応するために再配置されません。

ここでは、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の[PlacementAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.placementalignment)プロパティを使用して、基になるテキスト コントロールでは、どのアンカーが手書きのビューを配置するために使用する方法を示します。

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

## <a name="disable-auto-completion-candidates"></a>オートコンプリートの候補を無効にします。

テキストの候補ポップアップは最上位のインクの一覧からユーザー選択最上位の候補が正しくない場合に認識候補を提供する既定で有効にします。

アプリケーションで既に堅牢な場合は、カスタム認識機能では、プロパティを使用できます、 [AreCandidatesEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.arecandidatesenabled)組み込みの候補を無効にする次の例に示すようにします。

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

## <a name="use-handwriting-font-preferences"></a>手書きフォントの基本設定を使う

ユーザーが選択するときに使う手書きベースのフォントの事前に定義されたコレクションからインクの認識に基づくテキストのレンダリング (を参照してください**設定のデバイス]-> [ペン]-> [し、Windows Ink 手書き]-> [手書き入力を使用する場合、[フォント]-> [**)。

> [!NOTE]
> ユーザーは、独自の手書き入力に基づいてフォントを作成することもできます。
> [!VIDEO https://www.youtube.com/embed/YRR4qd4HCw8]

アプリでは、この設定にアクセスでき、テキスト コントロールに認識されたテキストの選択されているフォントを使用することができます。

この例では、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)の[TextChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.textchanged)イベントをリッスンし、HandwritingView (または既定のフォント、ない場合) からテキストの変更が発生した場合、ユーザーの選択されているフォントを適用します。

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

コントロールを使用して、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)または[RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox) 、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)なども複合コントロールは、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)をサポートします。

複合コントロールに[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)にアクセスするには、 [VisualTreeHelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper) API を使用します。

次の XAML コードでは、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)コントロールが表示されます。

```xaml
<AutoSuggestBox Name="SampleAutoSuggestBox" 
    Height="50" Width="500" 
    PlaceholderText="Auto Suggest Example" 
    FontSize="16" FontFamily="Segoe UI"  
    Loaded="SampleAutoSuggestBox_Loaded">
</AutoSuggestBox>
```

対応するコード ビハインドで、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)に[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)を無効にする方法を説明します。

1. 最初に、ビジュアル ツリーの移動を開始する FindInnerTextBox 関数を呼び出して、アプリケーションの読み込みイベントが処理します。

    ```csharp
    private void SampleAutoSuggestBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (FindInnerTextBox((AutoSuggestBox)sender))
            autoSuggestInnerTextBox.IsHandwritingViewEnabled = false;
    }
    ```

2. また、FindVisualChildByName を呼び出して FindInnerTextBox 関数では、(AutoSuggestBox から開始)、ビジュアル ツリーを反復処理し、開始します。

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

3. 最後に、この関数は、ビジュアル ツリーで、TextBox が取得されるまでです。

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

## <a name="reposition-the-handwritingview"></a>位置変更、HandwritingView

場合によっては、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)が、それ以外の場合は実行できない UI 要素を説明することを確認する必要があります。

ここでは、ディクテーション (StackPanel にテキスト ボックスとディクテーションのボタンを配置することによって実装される) をサポートしているテキスト ボックスを作成します。

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation.png)

として、StackPanel、TextBox よりも大きい、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)可能性がありますいない見えなくすべての複合コントロール。

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation-handwritingview.png)

これに対処するには、配置する必要があります、UI 要素を[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の PlacementTarget プロパティを設定します。

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

設定することも[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)のサイズ、ビューは、重要な UI をオクルードしないことを確認する必要がある場合に便利ですができます。

前の例と同様に、ディクテーション (StackPanel にテキスト ボックスとディクテーションのボタンを配置することによって実装される) をサポートしているテキスト ボックスを作成します。

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation.png)

この例では、ディクテーション ボタンが常に表示されていることを確認します。

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation-handwritingview-resize.png)

これを行うに見えなく必要がありますが、UI 要素の幅に[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の MaxWidth プロパティにバインドします。

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

## <a name="reposition-custom-ui"></a>カスタム UI を位置変更します。

情報のポップアップなどのテキスト入力への応答として表示されるカスタム UI がある場合は、手書きのビューをオクルードがないため、UI の位置を変更する必要があります。

![カスタム UI を設定した TextBox](images/handwritingview/textbox-with-customui.png)

次の例は、[ポップアップ](https://docs.microsoft.com/uwp/api/windows.ui.popups)の位置を設定する[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の[Opened](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.opened)[終了](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.closed
)、 [SizeChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.sizechanged)イベントをリッスンする方法を示しています。

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

## <a name="retemplate-the-handwritingview-control"></a>HandwritingView コントロールを再テンプレート化

XAML フレームワークのすべてのコントロールと同様、特定の要件の視覚的構造や[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の視覚的動作の両方をカスタマイズできます。

[カスタム トランスポート コントロールを作成する](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/custom-transport-controls)方法や[カスタム編集コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl)のチェック_アウトをカスタム テンプレートを作成する完全な例を参照してください。







