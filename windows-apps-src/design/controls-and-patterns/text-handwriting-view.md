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
# <a name="text-input-with-the-handwriting-view"></a><span data-ttu-id="0a897-104">ビューを手書きのテキスト入力</span><span class="sxs-lookup"><span data-stu-id="0a897-104">Text input with the handwriting view</span></span>

![ペンでタップするとテキスト ボックスが展開する](images/handwritingview/handwritingview2.gif)

<span data-ttu-id="0a897-106">など、UWP のテキスト コントロールでサポートされているテキスト入力をインクの組み込みの手書きのビューをカスタマイズ、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)、 [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)、およびこれらから派生したなどのコントロール、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)します。</span><span class="sxs-lookup"><span data-stu-id="0a897-106">Customize the built-in handwriting view for ink to text input supported by UWP text controls such as the [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox), [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox), and controls derived from these such as the [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox).</span></span>

## <a name="overview"></a><span data-ttu-id="0a897-107">概要</span><span class="sxs-lookup"><span data-stu-id="0a897-107">Overview</span></span>

<span data-ttu-id="0a897-108">XAML テキスト入力ボックス機能を使用して入力ペンのサポートが組み込ま[Windows インク](../input/pen-and-stylus-interactions.md)します。</span><span class="sxs-lookup"><span data-stu-id="0a897-108">XAML text input boxes feature embedded support for pen input using [Windows Ink](../input/pen-and-stylus-interactions.md).</span></span> <span data-ttu-id="0a897-109">ユーザーはタップ Windows ペンを使用して、テキスト入力ボックスに、テキスト ボックスは個別の入力パネルを開くのではなく、手書きの画面に変換します。</span><span class="sxs-lookup"><span data-stu-id="0a897-109">When a user taps into a text input box using a Windows pen, the text box transforms into a handwriting surface, rather than opening a separate input panel.</span></span>

<span data-ttu-id="0a897-110">テキストが認識するは、ユーザーを書き込む任意の場所で、テキスト ボックスと候補のウィンドウには、認識結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0a897-110">Text is recognized as the user writes anywhere in the text box, and a candidate window shows the recognition results.</span></span> <span data-ttu-id="0a897-111">ユーザーは結果をタップしてそれを選択したり、さらに書き込んで提案された候補を受け入れたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="0a897-111">The user can tap a result to choose it, or continue writing to accept the proposed candidate.</span></span> <span data-ttu-id="0a897-112">リテラル (1 文字ずつ) による認識結果は候補ウィンドウに含まれているため、認識はディクショナリ内の単語に制限されません。</span><span class="sxs-lookup"><span data-stu-id="0a897-112">The literal (letter-by-letter) recognition results are included in the candidate window, so recognition is not restricted to words in a dictionary.</span></span> <span data-ttu-id="0a897-113">ユーザーが手書きで入力すると、受け入れられたテキスト入力は自然な手書き感を維持して Script フォントに変換されます。</span><span class="sxs-lookup"><span data-stu-id="0a897-113">As the user writes, the accepted text input is converted to a script font that retains the feel of natural writing.</span></span>

> [!NOTE]
> <span data-ttu-id="0a897-114">既定では、手書きのビューが有効になっているが、コントロールごとでは無効にし、代わりに、テキスト入力パネルを元に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="0a897-114">The handwriting view is enabled by default, but you can disable it on a per-control basis and revert to the text input panel instead.</span></span>

![インクと提案されたテキスト ボックス](images/handwritingview/handwritingview-inksuggestion1.gif)

<span data-ttu-id="0a897-116">ユーザーは、次のような標準的なジェスチャや操作を使用してテキストを編集できます。</span><span class="sxs-lookup"><span data-stu-id="0a897-116">A user can edit their text using standard gestures and actions, like these:</span></span>

- <span data-ttu-id="0a897-117">_取り消し線_または_インクを消す_ - 単語や単語の一部を削除します</span><span class="sxs-lookup"><span data-stu-id="0a897-117">_strike through_ or _scratch out_ - draw through to delete a word or part of a word</span></span>
- <span data-ttu-id="0a897-118">_結合_ - 単語間に円弧を描き、単語間のスペースを削除します</span><span class="sxs-lookup"><span data-stu-id="0a897-118">_join_ - draw an arc between words to delete the space between them</span></span>
- <span data-ttu-id="0a897-119">_挿入_- スペースを挿入するキャレット記号を描画します</span><span class="sxs-lookup"><span data-stu-id="0a897-119">_insert_ - draw a caret symbol to insert a space</span></span>
- <span data-ttu-id="0a897-120">_上書き_- 既存のテキストの上に書き込み、それを置き換えます</span><span class="sxs-lookup"><span data-stu-id="0a897-120">_overwrite_ - write over existing text to replace it</span></span>

![テキスト ボックスにインクの修正](images/handwritingview/handwritingview-inkcorrection1.gif)

## <a name="disable-the-handwriting-view"></a><span data-ttu-id="0a897-122">手書きのビューを無効にします。</span><span class="sxs-lookup"><span data-stu-id="0a897-122">Disable the handwriting view</span></span>

<span data-ttu-id="0a897-123">組み込みの手書きのビューは、既定で有効です。</span><span class="sxs-lookup"><span data-stu-id="0a897-123">The built-in handwriting view is enabled by default.</span></span>

<span data-ttu-id="0a897-124">アプリケーションでは、既にインクからテキストへの同等の機能を提供するか、テキスト入力の経験がある種の書式設定や特殊文字 (タブ) など手書きからは利用できない依存手書きビューを無効にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="0a897-124">You might want to disable the handwriting view if you already provide equivalent ink-to-text functionality in your application, or your text input experience relies on some kind of formatting or special character (such as a tab) not available through handwriting.</span></span>

<span data-ttu-id="0a897-125">この例で手書きのビュー設定を無効に、 [IsHandwritingViewEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.ishandwritingviewenabled)のプロパティ、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)コントロールを false にします。</span><span class="sxs-lookup"><span data-stu-id="0a897-125">In this example, we disable the handwriting view by setting the [IsHandwritingViewEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.ishandwritingviewenabled) property of the [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) control to false.</span></span> <span data-ttu-id="0a897-126">手書きビューをサポートするすべてのテキスト コントロールのようなプロパティをサポートします。</span><span class="sxs-lookup"><span data-stu-id="0a897-126">All text controls that support the handwriting view support a similar property.</span></span>

```xaml
<TextBox Name="SampleTextBox"
    Height="50" Width="500" 
    FontSize="36" FontFamily="Segoe UI" 
    PlaceholderText="Try taping with your pen" 
    IsHandwritingViewEnabled="False">
</TextBox>
```

## <a name="specify-the-alignment-of-the-handwriting-view"></a><span data-ttu-id="0a897-127">手書きビューの配置を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a897-127">Specify the alignment of the handwriting view</span></span>

<span data-ttu-id="0a897-128">手書きビューの基になるテキスト コントロールの上にあるし、ユーザーの手書き認識の基本設定を格納できるだけのサイズ (を参照してください**設定]、[デバイスのペンを -> & Windows インクが手書きを -> に直接記述する場合は、フォントのサイズを ->テキスト フィールド**)。</span><span class="sxs-lookup"><span data-stu-id="0a897-128">The handwriting view is located above the underlying text control and sized to accommodate the user's handwriting preferences (see **Settings -> Devices -> Pen & Windows Ink -> Handwriting -> Size of font when writing directly into text field**).</span></span> <span data-ttu-id="0a897-129">ビューは、テキスト コントロールと、アプリ内での位置を基準も自動的に配置されます。</span><span class="sxs-lookup"><span data-stu-id="0a897-129">The view is also automatically aligned relative to the text control and its location within the app.</span></span>

<span data-ttu-id="0a897-130">アプリケーションの UI は、システムが重要な UI に表示が発生する可能性がありますので、大きい方のコントロールを対応するためにフローを変更できません。</span><span class="sxs-lookup"><span data-stu-id="0a897-130">The application UI does not reflow to accommodate the larger control, so the system might cause the view to occlude important UI.</span></span>

<span data-ttu-id="0a897-131">ここでは、使用する方法を示します、 [PlacementAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.placementalignment)のプロパティを[TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)整列するために使用する、基になるテキスト コントロールのどのアンカーを指定する、手書き文字を表示します。</span><span class="sxs-lookup"><span data-stu-id="0a897-131">Here, we show how to use the [PlacementAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.placementalignment) property of a [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) to specify which anchor on the underlying text control is used to align the handwriting view.</span></span>

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

## <a name="disable-auto-completion-candidates"></a><span data-ttu-id="0a897-132">オート コンプリートの候補を無効にします。</span><span class="sxs-lookup"><span data-stu-id="0a897-132">Disable auto-completion candidates</span></span>

<span data-ttu-id="0a897-133">テキストの修正候補のポップアップは、上のインクの一覧に、ユーザーが元の候補の最上位に位置が正しくない場合に選択できる認識候補を提供する、既定で有効です。</span><span class="sxs-lookup"><span data-stu-id="0a897-133">The text suggestion popup is enabled by default to provide a list of top ink recognition candidates from which the user can select in case the top candidate is incorrect.</span></span>

<span data-ttu-id="0a897-134">既にアプリケーションが、堅牢なカスタムの認識機能を提供する場合は使用できます、 [AreCandidatesEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.arecandidatesenabled)プロパティを次の例に示すように、組み込みの推奨事項を無効にします。</span><span class="sxs-lookup"><span data-stu-id="0a897-134">If your application already provides robust, custom recognition functionality, you can use the [AreCandidatesEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.arecandidatesenabled) property to disable the built-in suggestions, as shown in the following example.</span></span>

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

## <a name="use-handwriting-font-preferences"></a><span data-ttu-id="0a897-135">手書き文字のフォント設定を使用して、</span><span class="sxs-lookup"><span data-stu-id="0a897-135">Use handwriting font preferences</span></span>

<span data-ttu-id="0a897-136">ユーザーが選択できるときに使用するフォントの手書き文字ベースの定義済みコレクション インクの認識に基づいてテキストのレンダリング (を参照してください**設定、デバイス ペンを -> & Windows インク手書き-> 手書きを使用する場合、フォント->**).</span><span class="sxs-lookup"><span data-stu-id="0a897-136">A user can choose from a pre-defined collection of handwriting-based fonts to use when rendering text based on ink recognition (see **Settings -> Devices -> Pen & Windows Ink -> Handwriting -> Font when using handwriting**).</span></span>

> [!NOTE]
> <span data-ttu-id="0a897-137">ユーザーは、自分の書いたに基づいてフォントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="0a897-137">Users can even create a font based on their own handwriting.</span></span>
> [!VIDEO https://www.youtube.com/embed/YRR4qd4HCw8]

<span data-ttu-id="0a897-138">アプリでは、この設定にアクセスでき、テキスト コントロールに認識されたテキストの選択したフォントを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="0a897-138">Your app can access this setting and use the selected font for the recognized text in the text control.</span></span>

<span data-ttu-id="0a897-139">リッスンこの例で、 [TextChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.textchanged)のイベントを[TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) HandwritingView (または既定のフォント、ない場合) からのテキスト変更が発生した場合、ユーザーの選択したフォントを適用します。</span><span class="sxs-lookup"><span data-stu-id="0a897-139">In this example, we listen for the [TextChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox.textchanged) event of a [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) and apply the user's selected font if the text change originated from the HandwritingView (or a default font, if not).</span></span>

```csharp
private void SampleTextBox_TextChanged(object sender, TextChangedEventArgs e)
{
    ((TextBox)sender).FontFamily = 
        ((TextBox)sender).HandwritingView.IsOpen ?
            new FontFamily(PenAndInkSettings.GetDefault().FontFamilyName) : 
            new FontFamily("Segoe UI");
}
```

## <a name="access-the-handwritingview-in-composite-controls"></a><span data-ttu-id="0a897-140">複合コントロールで HandwritingView へのアクセスします。</span><span class="sxs-lookup"><span data-stu-id="0a897-140">Access the HandwritingView in composite controls</span></span>

<span data-ttu-id="0a897-141">複合コントロールを使用して、 [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox)または[RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)などのコントロール[AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)サポートも、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)します。</span><span class="sxs-lookup"><span data-stu-id="0a897-141">Composite controls that use the [TextBox](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.textbox) or [RichEditBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox) controls, such as [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox) also support a [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview).</span></span>

<span data-ttu-id="0a897-142">アクセスする、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)複合コントロールで使用して、 [VisualTreeHelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper) API。</span><span class="sxs-lookup"><span data-stu-id="0a897-142">To access the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) in a composite control, use the [VisualTreeHelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper) API.</span></span>

<span data-ttu-id="0a897-143">次の XAML スニペットが表示されます、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)コントロール。</span><span class="sxs-lookup"><span data-stu-id="0a897-143">The following XAML snippet displays an [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox) control.</span></span>

```xaml
<AutoSuggestBox Name="SampleAutoSuggestBox" 
    Height="50" Width="500" 
    PlaceholderText="Auto Suggest Example" 
    FontSize="16" FontFamily="Segoe UI"  
    Loaded="SampleAutoSuggestBox_Loaded">
</AutoSuggestBox>
```

<span data-ttu-id="0a897-144">対応するコードの分離、無効にする方法を説明します、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)上、 [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox)します。</span><span class="sxs-lookup"><span data-stu-id="0a897-144">In the corresponding code-behind, we show how to disable the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) on the [AutoSuggestBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.autosuggestbox).</span></span>

1. <span data-ttu-id="0a897-145">アプリケーションの読み込まれたイベントを処理最初に、ビジュアル ツリーの走査を開始する FindInnerTextBox 関数を呼び出すことです。</span><span class="sxs-lookup"><span data-stu-id="0a897-145">First, we handle the application's Loaded event where we call a FindInnerTextBox function to start the visual tree traversal.</span></span>

    ```csharp
    private void SampleAutoSuggestBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (FindInnerTextBox((AutoSuggestBox)sender))
            autoSuggestInnerTextBox.IsHandwritingViewEnabled = false;
    }
    ```

2. <span data-ttu-id="0a897-146">FindVisualChildByName への呼び出しを FindInnerTextBox 関数には、(、AutoSuggestBox から始まります)、ビジュアル ツリーを反復処理すること、開始します。</span><span class="sxs-lookup"><span data-stu-id="0a897-146">We then begin iterating through the visual tree (starting at an AutoSuggestBox) in the FindInnerTextBox function with a call to FindVisualChildByName.</span></span>

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

3. <span data-ttu-id="0a897-147">最後に、テキスト ボックスが取得されるまでは、ビジュアル ツリーをこの関数が反復処理します。</span><span class="sxs-lookup"><span data-stu-id="0a897-147">Finally, this function iterates through the visual tree until the TextBox is retrieved.</span></span>

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

## <a name="reposition-the-handwritingview"></a><span data-ttu-id="0a897-148">位置の変更、HandwritingView</span><span class="sxs-lookup"><span data-stu-id="0a897-148">Reposition the HandwritingView</span></span>

<span data-ttu-id="0a897-149">場合によっては、ことを確認する必要があります、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)されませんが、それ以外の場合の UI 要素について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a897-149">In some cases, you might need to ensure that the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) covers UI elements that it otherwise might not.</span></span>

<span data-ttu-id="0a897-150">ここでは、音声入力 (テキスト ボックスと [ディクテーション] ボタンを StackPanel に配置することで実装) をサポートするテキスト ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="0a897-150">Here, we create a TextBox that supports dictation (implemented by placing a TextBox and a dictation button into a StackPanel).</span></span>

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation.png)

<span data-ttu-id="0a897-152">StackPanel がテキスト ボックスより大きい、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)複合コントロールのすべてがない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0a897-152">As the StackPanel is now larger than the TextBox, the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) might not occlude all of the composite cotnrol.</span></span>

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation-handwritingview.png)

<span data-ttu-id="0a897-154">これに対処の PlacementTarget プロパティを設定、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)に UI 要素を配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a897-154">To address this, set the PlacementTarget property of the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) to the UI element to which it should be aligned.</span></span>

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

## <a name="resize-the-handwritingview"></a><span data-ttu-id="0a897-155">HandwritingView のサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="0a897-155">Resize the HandwritingView</span></span>

<span data-ttu-id="0a897-156">サイズを設定することも、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)、重要な UI がしません、ビューを確認する必要がある場合に便利ですができます。</span><span class="sxs-lookup"><span data-stu-id="0a897-156">You can also set the size of the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview), which can be useful when you need to ensure the view doesn't occlude important UI.</span></span>

<span data-ttu-id="0a897-157">前の例のように、音声入力 (テキスト ボックスと [ディクテーション] ボタンを StackPanel に配置することで実装) をサポートするテキスト ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="0a897-157">Like the previous example, we create a TextBox that supports dictation (implemented by placing a TextBox and a dictation button into a StackPanel).</span></span>

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation.png)

<span data-ttu-id="0a897-159">この場合、ディクテーション ボタンが常に表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0a897-159">In this case, we want to ensure that the dictation button is always visible.</span></span>

![ディクテーションを含む TextBox](images/handwritingview/textbox-with-dictation-handwritingview-resize.png)

<span data-ttu-id="0a897-161">これを行うには、バインドの MaxWidth プロパティ、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)する必要がありますが、UI 要素の幅にします。</span><span class="sxs-lookup"><span data-stu-id="0a897-161">To do this, we bind the MaxWidth property of the [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) to the width of the UI element that it should occlude.</span></span>

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

## <a name="reposition-custom-ui"></a><span data-ttu-id="0a897-162">カスタム UI の位置を変更します。</span><span class="sxs-lookup"><span data-stu-id="0a897-162">Reposition custom UI</span></span>

<span data-ttu-id="0a897-163">情報のポップアップなどのテキスト入力に応答に表示されるカスタムの UI がある場合は、手書きのビューがそのしないようにその UI の位置を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a897-163">If you have custom UI that appears in response to text input, such as an informational popup, you might need to reposition that UI so it doesn't occlude the handwriting view.</span></span>

![カスタム UI を含む TextBox](images/handwritingview/textbox-with-customui.png)

<span data-ttu-id="0a897-165">次の例では、リッスンする方法を示しています、 [Opened](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.opened)、 [Closed](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.closed
)、および[SizeChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.sizechanged)のイベント、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)を設定する、位置を[ポップアップ](https://docs.microsoft.com/uwp/api/windows.ui.popups)します。</span><span class="sxs-lookup"><span data-stu-id="0a897-165">The following example shows how to listen for the [Opened](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.opened), [Closed](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview.closed
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

## <a name="retemplate-the-handwritingview-control"></a><span data-ttu-id="0a897-166">Retemplate HandwritingView コントロール</span><span class="sxs-lookup"><span data-stu-id="0a897-166">Retemplate the HandwritingView control</span></span>

<span data-ttu-id="0a897-167">XAML フレームワークのすべてのコントロールで、視覚的な構造との視覚的な動作をカスタマイズすることができます、 [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)特定の要件。</span><span class="sxs-lookup"><span data-stu-id="0a897-167">As with all XAML framework controls, you can customize both the visual structure and visual behavior of a [HandwritingView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview) for your specific requirements.</span></span>

<span data-ttu-id="0a897-168">カスタム テンプレートのチェック アウトを作成する完全な例を表示する、[カスタム トランスポート コントロールを作成](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/custom-transport-controls)に関する「方法」、または[カスタム編集コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl)します。</span><span class="sxs-lookup"><span data-stu-id="0a897-168">To see a full example of creating a custom template check out the [Create custom transport controls](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/custom-transport-controls) how-to or the [Custom Edit Control sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl).</span></span>








