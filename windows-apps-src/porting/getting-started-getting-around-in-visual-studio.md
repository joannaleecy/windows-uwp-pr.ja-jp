---
author: mcleblanc
description: Visual Studio の操作方法
title: Visual Studio の操作方法
ms.assetid: 7FBB50A2-6D22-4082-B333-5153DADDDE9A
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 30849b23e9fbdca38f8401afe0f6f7df4b498121
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243935"
---
# <a name="getting-started-getting-around-in-visual-studio"></a><span data-ttu-id="03e47-104">はじめに: Visual Studio の操作方法</span><span class="sxs-lookup"><span data-stu-id="03e47-104">Getting started: Getting around in Visual Studio</span></span>

<span data-ttu-id="03e47-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="03e47-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="03e47-106">Windows 8.x の記事については、「[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)」をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="03e47-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

## <a name="getting-around-in-microsoft-visual-studio"></a><span data-ttu-id="03e47-107">Microsoft Visual Studio の操作方法</span><span class="sxs-lookup"><span data-stu-id="03e47-107">Getting around in Microsoft Visual Studio</span></span>

<span data-ttu-id="03e47-108">ここでは、前の手順で作ったプロジェクトに戻り、Microsoft Visual Studio 統合開発環境 (IDE) の操作方法について示します。</span><span class="sxs-lookup"><span data-stu-id="03e47-108">Let's now get back to the project that we created earlier, and look at how you might find your way around the Microsoft Visual Studio integrated development environment (IDE).</span></span>

<span data-ttu-id="03e47-109">Xcode 開発者であれば、左側のウィンドウにソース ファイル、中央のウィンドウにエディター (UI またはソース コード)、コントロールとそのプロパティが右側のウィンドウにそれぞれ表示された、以下の既定のビューを見慣れていることと思われます。</span><span class="sxs-lookup"><span data-stu-id="03e47-109">If you are an Xcode developer, the default view below should be familiar, with source files in the left pane, the editor (either the UI or source code) in the center pane, and controls and their properties in the right pane.</span></span>

![Xcode の開発環境](images/ios-to-uwp/xcode-ide.png)

<span data-ttu-id="03e47-111">Microsoft Visual Studio もこれによく似ています。ただし、既定のビューでは、左側の**ツールボックス**にコントロールが表示されます。</span><span class="sxs-lookup"><span data-stu-id="03e47-111">Microsoft Visual Studio looks very similar, although the default view has the controls on the left side in the **Toolbox**.</span></span> <span data-ttu-id="03e47-112">ソース ファイルは右側の**ソリューション エクスプローラー**に表示され、プロパティは次のように、**[ソリューション エクスプローラー]** ウィンドウの **[プロパティ]** に表示されます。</span><span class="sxs-lookup"><span data-stu-id="03e47-112">The source files are in the **Solution Explorer** on the right side, and properties are in **Properties** under the **Solution Explorer** pane, like this:</span></span>

![Visual Studio の開発環境](images/ios-to-uwp/vs-ide.png)

<span data-ttu-id="03e47-114">これに少し違和感を感じる場合、Visual Studio ではウィンドウを並べ替えて、ソース ファイルを画面の左側に、ツールボックスを右側に配置することができます。</span><span class="sxs-lookup"><span data-stu-id="03e47-114">If this feels a little alien to you, you'll be pleased to know you can rearrange the panes in Visual Studio to place the source files on the left of the screen and the toolbox on the right.</span></span> <span data-ttu-id="03e47-115">実際に、任意のウィンドウのタイトル バーをクリックしてドラッグすることによって位置変更ができ、リリースするとドッキングされる位置を示すボックスが影付きで表示されます。</span><span class="sxs-lookup"><span data-stu-id="03e47-115">In fact, you can click and drag the title bar of any pane to reposition it, and Visual Studio will display a shaded box telling you where it will be docked once you release it.</span></span> <span data-ttu-id="03e47-116">多くのウィンドウのタイトル バーにも小さな描画ピン アイコンがあります。</span><span class="sxs-lookup"><span data-stu-id="03e47-116">Many panes also have a small drawing pin icon in their title bar.</span></span> <span data-ttu-id="03e47-117">これにより、パネルをそのまま固定して、その場所にロックできます。</span><span class="sxs-lookup"><span data-stu-id="03e47-117">This allows you to pin the panel as-is, locking it in place.</span></span> <span data-ttu-id="03e47-118">ウィンドウのピン留めを外して、領域を節約するために折りたたむことができます。これは、モニターが幅の狭い側にある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="03e47-118">Unpin the pane, and it can be collapsed to save space: useful if your monitor is on the smaller side.</span></span> <span data-ttu-id="03e47-119">失敗した場合 (ご安心ください。すべて対応できます) は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** をクリックして順序を復元します。</span><span class="sxs-lookup"><span data-stu-id="03e47-119">If you mess things up (don't worry, we've all done it), select **Reset Window Layout** from the **Window** menu to restore order.</span></span>

## <a name="adding-controls-setting-their-properties-and-responding-to-events"></a><span data-ttu-id="03e47-120">コントロールの追加、プロパティの設定、イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="03e47-120">Adding controls, setting their properties, and responding to events</span></span>

<span data-ttu-id="03e47-121">次は、プロジェクトにコントロールをいくつか追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="03e47-121">Let's now add some controls to your project.</span></span> <span data-ttu-id="03e47-122">ここでは、コントロールのプロパティをいくつか変更した後、コントロールのイベントの 1 つに応答するコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="03e47-122">We'll then change some of their properties, and write some code to respond to one of the control's events.</span></span>

<span data-ttu-id="03e47-123">Xcode でコントロールを追加するには、目的の .xib ファイルまたはストーリーボードを開いた後、次に示すように、コントロールをドラッグ アンド ドロップします (**[Round Rect Button]** (角丸四角形ボタン) または **[Label]** (ラベル))。</span><span class="sxs-lookup"><span data-stu-id="03e47-123">To add controls in Xcode, you open up the desired .xib file or the Storyboard and then drag and drop controls, such as a**Round Rect Button** or a **Label**, as shown below:</span></span>

![Xcode での UI の設計](images/ios-to-uwp/xcode-add-button-label.png)

<span data-ttu-id="03e47-125">次に、Visual Studio で同じような操作を行ってみましょう。</span><span class="sxs-lookup"><span data-stu-id="03e47-125">Let's do something similar in Visual Studio.</span></span> <span data-ttu-id="03e47-126">**ツールボックス**の **Button** コントロールをドラッグし、MainPage.xaml ファイルのデザイン サーフェスにドロップします。</span><span class="sxs-lookup"><span data-stu-id="03e47-126">From the **Toolbox**, drag the **Button** control, and then drop it onto the MainPage.xaml file's design surface.</span></span>

<span data-ttu-id="03e47-127">**TextBlock** コントロールについても同じ操作を行うと、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="03e47-127">Do the same with the **TextBlock** control, so it looks like this:</span></span>

![Visual Studio での UI の設計](images/ios-to-uwp/vs-add-button-label.png)

<span data-ttu-id="03e47-129">レイアウトとバインド情報が .xib ファイルまたはストーリーボード ファイル内に格納される Xcode とは異なり、Visual Studio では、これらの詳細を格納するために使用される XAML ファイルを、そのリッチで編集可能な宣言型の XML のような言語で編集することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="03e47-129">Unlike Xcode, which hides the layout and binding information inside a .xib or Storyboard file, Visual Studio encourages you to edit the XAML files used to store these details it its rich, editable, declarative, XML-like language.</span></span> <span data-ttu-id="03e47-130">Extensible Application Markup Language (XAML) について詳しくは、「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03e47-130">For more info about Extensible Application Markup Language (XAML), see [XAML overview](https://msdn.microsoft.com/library/windows/apps/mt185595).</span></span> <span data-ttu-id="03e47-131">ここでは、**[デザイン]** ウィンドウに表示されているものはすべて **[XAML]** ウィンドウに定義されていることを覚えておいてください。</span><span class="sxs-lookup"><span data-stu-id="03e47-131">For now, know that everything displayed in the **Design** pane is defined in the **XAML** pane.</span></span> <span data-ttu-id="03e47-132">**[XAML]** ウィンドウでは必要に応じて細かな調整を行うことができるため、慣れるにつれてユーザー インターフェイス コードを手動ですばやく開発できるようになります。</span><span class="sxs-lookup"><span data-stu-id="03e47-132">The **XAML** pane allows for fine control where necessary, and as you learn more about it, you can quickly develop user interface code manually.</span></span> <span data-ttu-id="03e47-133">ただし、ここでは、**[デザイン]** ウィンドウと **[プロパティ]** ウィンドウにのみ注目します。</span><span class="sxs-lookup"><span data-stu-id="03e47-133">For now, however, let's focus on just the **Design** and **Properties** panes.</span></span>

<span data-ttu-id="03e47-134">次に、ボタンの詳細を変更します。</span><span class="sxs-lookup"><span data-stu-id="03e47-134">Let's change the button's details.</span></span> <span data-ttu-id="03e47-135">おわかりのように、Xcode でボタンの名前を変更するには、ボタンのプロパティ パネルの **Title** フィールドの値を変更します。</span><span class="sxs-lookup"><span data-stu-id="03e47-135">As you will know, to change the button's name in Xcode, you would change the value of the **Title** field in its properties panel.</span></span>

<span data-ttu-id="03e47-136">Visual Studio を使う場合、同じような操作を行ってみましょう。</span><span class="sxs-lookup"><span data-stu-id="03e47-136">When using Visual Studio you do something very similar.</span></span> <span data-ttu-id="03e47-137">**[デザイン]** ウィンドウで、このボタンをタップしてフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="03e47-137">In the **Design** pane, tap the button to give it focus.</span></span> <span data-ttu-id="03e47-138">**[プロパティ]** ウィンドウで、**[コンテンツ]** の値を "Button" から "Press Me" に変更します。</span><span class="sxs-lookup"><span data-stu-id="03e47-138">Then in the **Properties** pane, alter the **Content** value from "Button" to "Press Me".</span></span> <span data-ttu-id="03e47-139">次に、ボタン コントロールの名前を更新するために、ここで示すように、**[名前]** の値を "&lt;名前なし&gt;" から "myButton" に変更します。</span><span class="sxs-lookup"><span data-stu-id="03e47-139">Next, update the name of the button control, by changing the **Name** value from "&lt;No Name&gt;" to "myButton", as shown here:</span></span>

![Visual Studio の [ボタンのプロパティ] ウィンドウ](images/ios-to-uwp/vs-button-properties.png)

<span data-ttu-id="03e47-141">次に、ユーザーによってボタンがタップされたときに **TextBlock** コントロールの内容を "Hello, World!" に変更する</span><span class="sxs-lookup"><span data-stu-id="03e47-141">Now, let's write some code to change the **TextBlock** control's contents to "Hello, World!"</span></span> <span data-ttu-id="03e47-142">コードを記述します。</span><span class="sxs-lookup"><span data-stu-id="03e47-142">after the user taps the button.</span></span>

<span data-ttu-id="03e47-143">Xcode では、次に示すように、コードを記述した後でコントロールに関連付けることによって (多くの場合、そのボタンをソース コードにコントロールドラッグすることによって)、イベントをコントロールに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="03e47-143">In Xcode, you would associate an event with a control by writing code and then associating that code with the control, often by control-dragging the button into the source code, like this:</span></span>

![Xcode でのボタンとイベントの関連付け](images/ios-to-uwp/xcode-add-button-event.png)

```swift
// Swift implementation.

@IBAction func buttonPressed(sender: UIButton) {
    
}
```

<span data-ttu-id="03e47-145">Visual Studio の操作も似ています。</span><span class="sxs-lookup"><span data-stu-id="03e47-145">Visual Studio is similar.</span></span> <span data-ttu-id="03e47-146">**[プロパティ]** の右上隅には、稲妻ボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="03e47-146">At the top right of **Properties** is a lightning bolt button.</span></span> <span data-ttu-id="03e47-147">このボタンを使うと、次のように、選んだコントロールに関連付けられている可能なイベントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="03e47-147">This is where the possible events associated with the selected control are listed, like this:</span></span>

![Visual Studio でのボタンのイベントの一覧](images/ios-to-uwp/vs-button-event.png)

<span data-ttu-id="03e47-149">ボタンのクリック イベントにコードを追加するには、**[デザイン]** ウィンドウで、まずそのボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="03e47-149">To add code for the button's click event, first select the button in the **Design** pane.</span></span> <span data-ttu-id="03e47-150">次に、稲妻ボタンをクリックし、**[Click]** という名前の横の空のボックスをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="03e47-150">Next, click the lightning bolt button, and double-click the empty box next to the name **Click**.</span></span> <span data-ttu-id="03e47-151">その後、Visual Studio によってイベント "myButton\_Click" が **[Click]** ボックスに追加されます。さらに、次のように、対応するイベント ハンドラーが MainPage.xaml.cs ファイルに追加され、表示されます。</span><span class="sxs-lookup"><span data-stu-id="03e47-151">Visual Studio then adds the event "myButton\_Click" to the **Click** box, and then adds and displays the corresponding event handler in the MainPage.xaml.cs file, like this.</span></span>

```csharp
private void myButton_Click(object sender, RoutedEventArgs e)
{

}
```

<span data-ttu-id="03e47-152">次に、**TextBlock** コントロールをフックします。</span><span class="sxs-lookup"><span data-stu-id="03e47-152">Let's now hook-up the **TextBlock** control.</span></span> <span data-ttu-id="03e47-153">Xcode では、このように、ボタンをソース コード ファイルにコントロールドラッグし、コントロールをその定義に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="03e47-153">In Xcode, you would control-drag the button to the source code file to associate the control with its definition, like this.</span></span>

![Xcode でのラベルと定義の関連付け](images/ios-to-uwp/xcode-add-button-reference.png)

```swift
// Swift implentation.

@IBOutlet weak var myLabel : UILabel
```

<span data-ttu-id="03e47-155">Visual Studio では、これは常に実行されるため、コントロールの関連付けの必要はありません。</span><span class="sxs-lookup"><span data-stu-id="03e47-155">In Visual Studio, you don't need associated the control as this is always done for you.</span></span> <span data-ttu-id="03e47-156">プロパティをいくつかを変更してみましょう。</span><span class="sxs-lookup"><span data-stu-id="03e47-156">Let's change some of the properties though:</span></span>

1.  <span data-ttu-id="03e47-157">MainPage.xaml ファイルのタブをタップします。</span><span class="sxs-lookup"><span data-stu-id="03e47-157">Tap the MainPage.xaml file tab.</span></span>
2.  <span data-ttu-id="03e47-158">**[デザイン]** ウィンドウで、**TextBlock** コントロールをタップします。</span><span class="sxs-lookup"><span data-stu-id="03e47-158">In the **Design** pane, tap the **TextBlock** control.</span></span>
3.  <span data-ttu-id="03e47-159">**[プロパティ]** ウィンドウで、レンチ ボタンをタップしてプロパティを表示します。</span><span class="sxs-lookup"><span data-stu-id="03e47-159">In the **Properties** pane, tap the wrench button to display its properties.</span></span>
4.  <span data-ttu-id="03e47-160">**[名前]** ボックスで、"&lt;No Name&gt;" を "myLabel" に変更します。</span><span class="sxs-lookup"><span data-stu-id="03e47-160">In the **Name** box, change "&lt;No Name&gt;" to "myLabel".</span></span>

![Visual Studio の [ラベルのプロパティ] ウィンドウ](images/ios-to-uwp/vs-label-properties.png)

<span data-ttu-id="03e47-162">次に、ボタンのクリック イベントにコードを追加してみましょう。</span><span class="sxs-lookup"><span data-stu-id="03e47-162">Let's now add some code to the button's click event.</span></span> <span data-ttu-id="03e47-163">このためには、MainPage.xaml.cs ファイルをタップし、次のコードを myButton\_Click イベント ハンドラーに追加します。</span><span class="sxs-lookup"><span data-stu-id="03e47-163">To do this, tap the MainPage.xaml.cs file, and add the following code to the myButton\_Click event handler.</span></span>

```csharp
private void myButton_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.    
    myLabel.Text = "Hello, World!";
}
```

<span data-ttu-id="03e47-164">これは Swift で記述した場合に似ています。</span><span class="sxs-lookup"><span data-stu-id="03e47-164">This is similar to what you would write in Swift:</span></span>

```swift
@IBAction func buttonPressed(sender: UIButton) {
    myLabel.text = "Hello, World!"
}
```

<span data-ttu-id="03e47-165">最後に、アプリを実行します。**[デバッグ]** メニュー、**[デバッグの開始]** の順に選択します (または、単に F5 キーを押します)。</span><span class="sxs-lookup"><span data-stu-id="03e47-165">Finally, to run the app, select the **Debug** menu, and then select **Start Debugging** (or just press F5).</span></span> <span data-ttu-id="03e47-166">アプリが起動されたら、[Press Me] ボタンをクリックして、次の図に示すように、ラベルの内容が "TextBlock" から "Hello, World!" に変わることを確かめます。</span><span class="sxs-lookup"><span data-stu-id="03e47-166">After the app starts, click the "Press Me" button, and see the label's contents change from "TextBlock" to "Hello, World!", as shown in the following figure.</span></span>

![最初のチュートリアルを実行した結果: Hello, World!](images/ios-to-uwp/vs-hello-world.png)

<span data-ttu-id="03e47-168">アプリを中止するには、Visual Studio に戻り、**[デバッグ]** メニュー、**[デバッグの停止]** の順にタップします (または、単に Shift キーを押しながら F5 キーを押します)。</span><span class="sxs-lookup"><span data-stu-id="03e47-168">To quit the app, return to Visual Studio, tap the **Debug** menu, and then tap **Stop Debugging** (or just press SHIFT + F5).</span></span> <span data-ttu-id="03e47-169">Visual Studio では、多数の異なるデバイスでアプリを試して、各デバイスでの動作を確認してみてください。</span><span class="sxs-lookup"><span data-stu-id="03e47-169">Notice that Visual Studio lets you try the app in many different devices, to check how it will perform in each.</span></span>

## <a name="next-step"></a><span data-ttu-id="03e47-170">次のステップ</span><span class="sxs-lookup"><span data-stu-id="03e47-170">Next step</span></span>

[<span data-ttu-id="03e47-171">はじめに: コモン コントロール</span><span class="sxs-lookup"><span data-stu-id="03e47-171">Getting started: Common Controls</span></span>](getting-started-common-controls.md)

