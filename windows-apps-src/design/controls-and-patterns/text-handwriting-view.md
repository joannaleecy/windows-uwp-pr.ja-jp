---
author: Karl-Bridge-Microsoft
Description: Customize the built-in handwriting view for ink to text input that is supported by UWP text controls such as the TextBox, RichEditBox (and controls like the AutoSuggestBox that provide a similar text input experience).
title: 手書きのビューでのテキスト入力
label: Text input with the handwriting view
template: detail.hbs
ms.author: kbridge
ms.date: 10/13/18
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: sewen
design-contact: minah.kim
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 3117cde7b8b00973c135fbc759fa99b6a48ec6ac
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4691078"
---
# <a name="text-input-with-the-handwriting-view"></a><span data-ttu-id="60047-103">手書きのビューでのテキスト入力</span><span class="sxs-lookup"><span data-stu-id="60047-103">Text input with the handwriting view</span></span>

![ペンでタップするとテキスト ボックスが展開する](images/handwritingview/handwritingview2.gif)

<span data-ttu-id="60047-105">[TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)、 [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)) (などのようなテキスト入力エクスペリエンスを提供するその他のコントロールなどの UWP テキスト コントロールでサポートされているテキスト入力をインクの手書き入力の組み込みビューをカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="60047-105">Customize the built-in handwriting view for ink to text input that is supported by UWP text controls such as the [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox), [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox), and other controls that provide a similar text input experience (like the [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)).</span></span>

## <a name="overview"></a><span data-ttu-id="60047-106">概要</span><span class="sxs-lookup"><span data-stu-id="60047-106">Overview</span></span>

<span data-ttu-id="60047-107">XAML テキスト入力ボックス機能は[Windows Ink](../input/pen-and-stylus-interactions.md)を使用して入力ペンの埋め込みをサポートします。</span><span class="sxs-lookup"><span data-stu-id="60047-107">XAML text input boxes feature embedded support for pen input using [Windows Ink](../input/pen-and-stylus-interactions.md).</span></span> <span data-ttu-id="60047-108">ユーザーは、Windows ペンを使用して、テキスト入力ボックスにタップ、テキスト ボックスは別の入力パネルを開くのではなく、手書き入力サーフェスに変換します。</span><span class="sxs-lookup"><span data-stu-id="60047-108">When a user taps into a text input box using a Windows pen, the text box transforms into a handwriting surface, rather than opening a separate input panel.</span></span>

<span data-ttu-id="60047-109">テキストは、ユーザーが任意の場所、テキスト ボックスで、候補ウィンドウには、認識結果が表示されます。 が認識されます。</span><span class="sxs-lookup"><span data-stu-id="60047-109">Text is recognized as the user writes anywhere in the text box, and a candidate window shows the recognition results.</span></span> <span data-ttu-id="60047-110">ユーザーは結果をタップしてそれを選択したり、さらに書き込んで提案された候補を受け入れたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="60047-110">The user can tap a result to choose it, or continue writing to accept the proposed candidate.</span></span> <span data-ttu-id="60047-111">リテラル (1 文字ずつ) による認識結果は候補ウィンドウに含まれているため、認識はディクショナリ内の単語に制限されません。</span><span class="sxs-lookup"><span data-stu-id="60047-111">The literal (letter-by-letter) recognition results are included in the candidate window, so recognition is not restricted to words in a dictionary.</span></span> <span data-ttu-id="60047-112">ユーザーが手書きで入力すると、受け入れられたテキスト入力は自然な手書き感を維持して Script フォントに変換されます。</span><span class="sxs-lookup"><span data-stu-id="60047-112">As the user writes, the accepted text input is converted to a script font that retains the feel of natural writing.</span></span>

> [!NOTE]
> <span data-ttu-id="60047-113">既定では、手書きの表示が有効になっているが、コントロールごとに無効にすることと、代わりに、テキスト入力パネルに戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="60047-113">The handwriting view is enabled by default, but you can disable it on a per-control basis and revert to the text input panel instead.</span></span>

![インクやご提案されたテキスト ボックス](images/handwritingview/handwritingview-inksuggestion1.gif)

<span data-ttu-id="60047-115">ユーザーは、次のような標準的なジェスチャや操作を使用してテキストを編集できます。</span><span class="sxs-lookup"><span data-stu-id="60047-115">A user can edit their text using standard gestures and actions, like these:</span></span>

- <span data-ttu-id="60047-116">_取り消し線_または_インクを消す_ - 単語や単語の一部を削除します</span><span class="sxs-lookup"><span data-stu-id="60047-116">_strike through_ or _scratch out_ - draw through to delete a word or part of a word</span></span>
- <span data-ttu-id="60047-117">_結合_ - 単語間に円弧を描き、単語間のスペースを削除します</span><span class="sxs-lookup"><span data-stu-id="60047-117">_join_ - draw an arc between words to delete the space between them</span></span>
- <span data-ttu-id="60047-118">_挿入_- スペースを挿入するキャレット記号を描画します</span><span class="sxs-lookup"><span data-stu-id="60047-118">_insert_ - draw a caret symbol to insert a space</span></span>
- <span data-ttu-id="60047-119">_上書き_- 既存のテキストの上に書き込み、それを置き換えます</span><span class="sxs-lookup"><span data-stu-id="60047-119">_overwrite_ - write over existing text to replace it</span></span>

![インク修正されたテキスト ボックス](images/handwritingview/handwritingview-inkcorrection1.gif)

## <a name="disable-the-handwriting-view"></a><span data-ttu-id="60047-121">手書きの表示を無効にします。</span><span class="sxs-lookup"><span data-stu-id="60047-121">Disable the handwriting view</span></span>

<span data-ttu-id="60047-122">組み込みの手書きビューは既定で有効にします。</span><span class="sxs-lookup"><span data-stu-id="60047-122">The built-in handwriting view is enabled by default.</span></span>

<span data-ttu-id="60047-123">アプリケーションで既にインクからテキストへの同等の機能を提供するか、何らかの書式設定や特殊文字 (などのタブ) 手書きからは利用できないに依存して、テキスト入力エクスペリエンス場合に、手書きビューを無効にする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="60047-123">You might want to disable the handwriting view if you already provide equivalent ink-to-text functionality in your application, or your text input experience relies on some kind of formatting or special character (such as a tab) not available through handwriting.</span></span>

<span data-ttu-id="60047-124">この例では、手書きビューを無効にによって、[テキスト ボックス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)コントロールの[IsHandwritingViewEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.ishandwritingviewenabled)プロパティを false に設定します。</span><span class="sxs-lookup"><span data-stu-id="60047-124">In this example, we disable the handwriting view by setting the [IsHandwritingViewEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.ishandwritingviewenabled) property of the [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) control to false.</span></span> <span data-ttu-id="60047-125">手書きのビューをサポートするすべてのテキスト コントロールでは、同様のプロパティをサポートします。</span><span class="sxs-lookup"><span data-stu-id="60047-125">All text controls that support the handwriting view support a similar property.</span></span>

```xaml
<TextBox Name="SampleTextBox"
    Height="50" Width="500" 
    FontSize="36" FontFamily="Segoe UI" 
    PlaceholderText="Try taping with your pen" 
    IsHandwritingViewEnabled="False">
</TextBox>
```

## <a name="specify-the-alignment-of-the-handwriting-view"></a><span data-ttu-id="60047-126">手書きのビューの配置を指定します。</span><span class="sxs-lookup"><span data-stu-id="60047-126">Specify the alignment of the handwriting view</span></span>

<span data-ttu-id="60047-127">手書きのビューを基になるテキスト コントロールの上にあるし、ユーザーの手書き入力の設定に合わせてサイズ (**設定のデバイス]-> [ペン]-> [し、Windows Ink 手書き]-> [テキスト フィールドに直接作成する際のフォント サイズ]-> [**).</span><span class="sxs-lookup"><span data-stu-id="60047-127">The handwriting view is located above the underlying text control and sized to accommodate the user's handwriting preferences (see **Settings -> Devices -> Pen & Windows Ink -> Handwriting -> Size of font when writing directly into text field**).</span></span> <span data-ttu-id="60047-128">ビューは、テキスト コントロールと、アプリ内での位置を基準としたも自動的に配置されます。</span><span class="sxs-lookup"><span data-stu-id="60047-128">The view is also automatically aligned relative to the text control and its location within the app.</span></span>

<span data-ttu-id="60047-129">アプリケーションの UI は、システム重要な UI が見えなくビューが発生する可能性がありますので、大型のコントロールを対応するために再配置されません。</span><span class="sxs-lookup"><span data-stu-id="60047-129">The application UI does not reflow to accommodate the larger control, so the system might cause the view to occlude important UI.</span></span>

<span data-ttu-id="60047-130">ここでは、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の[PlacementAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.placementalignment)プロパティを使用して、手書きのビューを配置するために、基になるテキスト コントロールでは、どのアンカーを使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="60047-130">Here, we show how to use the [PlacementAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.placementalignment) property of a [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) to specify which anchor on the underlying text control is used to align the handwriting view.</span></span>

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

## <a name="disable-auto-completion-candidates"></a><span data-ttu-id="60047-131">オートコンプリートの候補を無効にします。</span><span class="sxs-lookup"><span data-stu-id="60047-131">Disable auto-completion candidates</span></span>

<span data-ttu-id="60047-132">最上位のインクの一覧からユーザー選択最上位の候補が正しくない場合に認識候補を提供する、テキスト候補ポップアップは既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="60047-132">The text suggestion popup is enabled by default to provide a list of top ink recognition candidates from which the user can select in case the top candidate is incorrect.</span></span>

<span data-ttu-id="60047-133">アプリケーションで既に堅牢な場合は、カスタム認識機能では、プロパティを使用できます、 [AreCandidatesEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.arecandidatesenabled)組み込みの候補を無効にする次の例に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="60047-133">If your application already provides robust, custom recognition functionality, you can use the [AreCandidatesEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.arecandidatesenabled) property to disable the built-in suggestions, as shown in the following example.</span></span>

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

## <a name="use-handwriting-font-preferences"></a><span data-ttu-id="60047-134">手書きフォントの基本設定を使う</span><span class="sxs-lookup"><span data-stu-id="60047-134">Use handwriting font preferences</span></span>

<span data-ttu-id="60047-135">ユーザーが選択するときに使う手書きベースのフォントの定義済みのコレクションからインクの認識に基づくテキストのレンダリング (を参照してください**設定のデバイス]-> [ペン]-> [し、Windows Ink 手書き]-> [手書き入力を使用する場合、[フォント]-> [**)。</span><span class="sxs-lookup"><span data-stu-id="60047-135">A user can choose from a pre-defined collection of handwriting-based fonts to use when rendering text based on ink recognition (see **Settings -> Devices -> Pen & Windows Ink -> Handwriting -> Font when using handwriting**).</span></span>

> [!NOTE]
> <span data-ttu-id="60047-136">ユーザーは、独自の手書き入力に基づいてフォントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="60047-136">Users can even create a font based on their own handwriting.</span></span>
> [!VIDEO https://www.youtube.com/embed/YRR4qd4HCw8]

<span data-ttu-id="60047-137">アプリでは、この設定にアクセスでき、テキスト コントロールに認識されたテキストの選択されているフォントを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="60047-137">Your app can access this setting and use the selected font for the recognized text in the text control.</span></span>

<span data-ttu-id="60047-138">この例では、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)の[TextChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.textchanged)イベントをリッスンし、HandwritingView (または既定のフォント、ない場合) からテキストの変更が発生した場合、ユーザーの選択されているフォントを適用します。</span><span class="sxs-lookup"><span data-stu-id="60047-138">In this example, we listen for the [TextChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.textchanged) event of a [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) and apply the user's selected font if the text change originated from the HandwritingView (or a default font, if not).</span></span>

```csharp
private void SampleTextBox_TextChanged(object sender, TextChangedEventArgs e)
{
    ((TextBox)sender).FontFamily = 
        ((TextBox)sender).HandwritingView.IsOpen ?
            new FontFamily(PenAndInkSettings.GetDefault().FontFamilyName) : 
            new FontFamily("Segoe UI");
}
```

## <a name="access-the-handwritingview-in-composite-controls"></a><span data-ttu-id="60047-139">複合コントロールで HandwritingView へのアクセスします。</span><span class="sxs-lookup"><span data-stu-id="60047-139">Access the HandwritingView in composite controls</span></span>

<span data-ttu-id="60047-140">コントロールを使用して、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)または[RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox) 、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)なども複合コントロールは、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)をサポートします。</span><span class="sxs-lookup"><span data-stu-id="60047-140">Composite controls that use the [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) or [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox) controls, such as [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox) also support a [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview).</span></span>

<span data-ttu-id="60047-141">複合コントロールに[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)にアクセスするには、 [VisualTreeHelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper) API を使用します。</span><span class="sxs-lookup"><span data-stu-id="60047-141">To access the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) in a composite control, use the [VisualTreeHelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper) API.</span></span>

<span data-ttu-id="60047-142">次の XAML コードでは、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)コントロールを表示します。</span><span class="sxs-lookup"><span data-stu-id="60047-142">The following XAML snippet displays an [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox) control.</span></span>

```xaml
<AutoSuggestBox Name="SampleAutoSuggestBox" 
    Height="50" Width="500" 
    PlaceholderText="Auto Suggest Example" 
    FontSize="16" FontFamily="Segoe UI"  
    Loaded="SampleAutoSuggestBox_Loaded">
</AutoSuggestBox>
```

<span data-ttu-id="60047-143">対応するコード ビハインドで、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)に[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)を無効にする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="60047-143">In the corresponding code-behind, we show how to disable the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) on the [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox).</span></span>

1. <span data-ttu-id="60047-144">最初に、ビジュアル ツリーの移動を開始する FindInnerTextBox 関数を呼び出しアプリケーションの読み込みイベントが処理します。</span><span class="sxs-lookup"><span data-stu-id="60047-144">First, we handle the application's Loaded event where we call a FindInnerTextBox function to start the visual tree traversal.</span></span>

    ```csharp
    private void SampleAutoSuggestBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (FindInnerTextBox((AutoSuggestBox)sender))
            autoSuggestInnerTextBox.IsHandwritingViewEnabled = false;
    }
    ```

2. <span data-ttu-id="60047-145">また、FindVisualChildByName を呼び出して FindInnerTextBox 関数では、(AutoSuggestBox から開始)、ビジュアル ツリーを反復処理し、開始します。</span><span class="sxs-lookup"><span data-stu-id="60047-145">We then begin iterating through the visual tree (starting at an AutoSuggestBox) in the FindInnerTextBox function with a call to FindVisualChildByName.</span></span>

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

3. <span data-ttu-id="60047-146">最後に、この関数は、ビジュアル ツリーの TextBox が取得されるまでです。</span><span class="sxs-lookup"><span data-stu-id="60047-146">Finally, this function iterates through the visual tree until the TextBox is retrieved.</span></span>

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

## <a name="reposition-the-handwritingview"></a><span data-ttu-id="60047-147">位置変更、HandwritingView</span><span class="sxs-lookup"><span data-stu-id="60047-147">Reposition the HandwritingView</span></span>

<span data-ttu-id="60047-148">場合によっては、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)がされませんが、それ以外の場合の UI 要素を説明することを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="60047-148">In some cases, you might need to ensure that the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) covers UI elements that it otherwise might not.</span></span>

<span data-ttu-id="60047-149">ここでは、ディクテーション (StackPanel にテキスト ボックスとディクテーションのボタンを配置することによって実装される) をサポートしているテキスト ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="60047-149">Here, we create a TextBox that supports dictation (implemented by placing a TextBox and a dictation button into a StackPanel).</span></span>

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation.png)

<span data-ttu-id="60047-151">として、StackPanel、TextBox よりも大きい、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)可能性がありますいない見えなくすべての複合コントロール。</span><span class="sxs-lookup"><span data-stu-id="60047-151">As the StackPanel is now larger than the TextBox, the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) might not occlude all of the composite cotnrol.</span></span>

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation-handwritingview.png)

<span data-ttu-id="60047-153">これに対処するには、UI 要素を配置する必要がありますに[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の PlacementTarget プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="60047-153">To address this, set the PlacementTarget property of the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) to the UI element to which it should be aligned.</span></span>

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

## <a name="resize-the-handwritingview"></a><span data-ttu-id="60047-154">HandwritingView のサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="60047-154">Resize the HandwritingView</span></span>

<span data-ttu-id="60047-155">設定することも[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)のサイズ、ビューは、重要な UI をオクルードしないことを確認する必要がある場合に便利ですができます。</span><span class="sxs-lookup"><span data-stu-id="60047-155">You can also set the size of the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview), which can be useful when you need to ensure the view doesn't occlude important UI.</span></span>

<span data-ttu-id="60047-156">前の例と同様に、ディクテーション (StackPanel にテキスト ボックスとディクテーションのボタンを配置することによって実装される) をサポートしているテキスト ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="60047-156">Like the previous example, we create a TextBox that supports dictation (implemented by placing a TextBox and a dictation button into a StackPanel).</span></span>

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation.png)

<span data-ttu-id="60047-158">この例では、ディクテーション ボタンが常に表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="60047-158">In this case, we want to ensure that the dictation button is always visible.</span></span>

![ディクテーションを設定した TextBox](images/handwritingview/textbox-with-dictation-handwritingview-resize.png)

<span data-ttu-id="60047-160">これを行う必要がありますが、UI 要素の幅に[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の MaxWidth プロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="60047-160">To do this, we bind the MaxWidth property of the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) to the width of the UI element that it should occlude.</span></span>

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

## <a name="reposition-custom-ui"></a><span data-ttu-id="60047-161">カスタム UI を位置変更します。</span><span class="sxs-lookup"><span data-stu-id="60047-161">Reposition custom UI</span></span>

<span data-ttu-id="60047-162">情報のポップアップなどのテキスト入力への応答として表示されるカスタム UI がある場合は、手書きのビューをオクルードしないため、UI の位置を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="60047-162">If you have custom UI that appears in response to text input, such as an informational popup, you might need to reposition that UI so it doesn't occlude the handwriting view.</span></span>

![カスタム UI を設定した TextBox](images/handwritingview/textbox-with-customui.png)

<span data-ttu-id="60047-164">次の例は、[ポップアップ](https://docs.microsoft.com/uwp/api/windows.ui.popups)の位置を設定する[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の[Opened](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.opened)[終了](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.closed
)、 [SizeChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.sizechanged)イベントをリッスンする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="60047-164">The following example shows how to listen for the [Opened](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.opened), [Closed](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.closed
), and [SizeChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.sizechanged) events of the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) to set the position of a [Popup](https://docs.microsoft.com/uwp/api/windows.ui.popups).</span></span>

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

## <a name="retemplate-the-handwritingview-control"></a><span data-ttu-id="60047-165">HandwritingView コントロールを再テンプレート化</span><span class="sxs-lookup"><span data-stu-id="60047-165">Retemplate the HandwritingView control</span></span>

<span data-ttu-id="60047-166">XAML フレームワークのすべてのコントロールと同様、特定の要件の視覚的構造や[HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)の視覚的な動作の両方をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="60047-166">As with all XAML framework controls, you can customize both the visual structure and visual behavior of a [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) for your specific requirements.</span></span>

<span data-ttu-id="60047-167">[カスタム トランスポート コントロールを作成する](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/custom-transport-controls)方法や[カスタム編集コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl)のチェック_アウトをカスタム テンプレートを作成する完全な例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="60047-167">To see a full example of creating a custom template check out the [Create custom transport controls](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/custom-transport-controls) how-to or the [Custom Edit Control sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl).</span></span>







