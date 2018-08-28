---
author: Jwmsft
Description: You create the UI for your app by using controls such as buttons, text boxes, and combo boxes to display data and get user input. Here, we show you how to add controls to your app.
title: コントロールとパターンの概要
ms.assetid: 64740BF2-CAA1-419E-85D1-42EE7E15F1A5
label: Intro to controls and patterns
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6f8f86a6988e68e3ff8d2dfef32512633b3761fd
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2882575"
---
# <a name="intro-to-controls-and-patterns"></a><span data-ttu-id="e83b3-103">コントロールとパターンの概要</span><span class="sxs-lookup"><span data-stu-id="e83b3-103">Intro to controls and patterns</span></span>

<span data-ttu-id="e83b3-104">UWP アプリ開発では、*コントロール*は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="e83b3-104">In UWP app development, a *control* is a UI element that displays content or enables interaction.</span></span> <span data-ttu-id="e83b3-105">ボタン、テキスト ボックス、コンボ ボックスなどのコントロールを使って、データを表示し、ユーザー入力を取得するためのアプリの UI を作ります。</span><span class="sxs-lookup"><span data-stu-id="e83b3-105">You create the UI for your app by using controls such as buttons, text boxes, and combo boxes to display data and get user input.</span></span>

> <span data-ttu-id="e83b3-106">**重要な API**: [Windows.UI.Xaml.Controls 名前空間](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.aspx)</span><span class="sxs-lookup"><span data-stu-id="e83b3-106">**Important APIs**: [Windows.UI.Xaml.Controls namespace](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.aspx)</span></span>

<span data-ttu-id="e83b3-107">*パターン*とは、コントロールを変更するか、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。</span><span class="sxs-lookup"><span data-stu-id="e83b3-107">A *pattern* is a recipe for modifying a control or combining several controls to make something new.</span></span> <span data-ttu-id="e83b3-108">たとえば、[マスター/詳細](master-details.md)パターンは、アプリのナビゲーションの[SplitView](split-view.md)コントロールを使用するには、方法です。</span><span class="sxs-lookup"><span data-stu-id="e83b3-108">For example, the [master/details](master-details.md) pattern is a way that you can use a [SplitView](split-view.md) control for app navigation.</span></span> <span data-ttu-id="e83b3-109">同様に、タブの [パターンを実装する[NavigationView](navigationview.md)コントロールのテンプレートをカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-109">Similarly, you can customize the template of a [NavigationView](navigationview.md) control to implement the tab pattern.</span></span>

<span data-ttu-id="e83b3-110">多くの場合、コントロールはそのまま使用できます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-110">In many cases, you can use a control as-is.</span></span> <span data-ttu-id="e83b3-111">ただし、XAML コントロールでは、機能が構造や外観とは分離されているため、ニーズに合わせてさまざまなレベルで変更することができます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-111">But XAML controls separate function from structure and appearance, so you can make various levels of modification to make them fit your needs.</span></span> <span data-ttu-id="e83b3-112">[XAML スタイル](xaml-styles.md)と[コントロール テンプレート](control-templates.md)を使用してコントロールを変更する方法については、「[スタイル](../style/index.md)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e83b3-112">In the [Style](../style/index.md) section, you can learn how to use [XAML styles](xaml-styles.md) and [control templates](control-templates.md) to modify a control.</span></span>

<span data-ttu-id="e83b3-113">このセクションでは、アプリ UI の構築に使用できる各 XAML コントロールに関するガイダンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-113">In this section, we provide guidance for each of the XAML controls you can use to build your app UI.</span></span> <span data-ttu-id="e83b3-114">まず、この記事では、アプリにコントロールを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-114">To start, this article shows you how to add controls to your app.</span></span> <span data-ttu-id="e83b3-115">アプリでコントロールを使用するには、次の 3 つの重要な手順があります。</span><span class="sxs-lookup"><span data-stu-id="e83b3-115">There are 3 key steps to using controls to your app:</span></span>

- <span data-ttu-id="e83b3-116">アプリの UI にコントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-116">Add a control to your app UI.</span></span>
- <span data-ttu-id="e83b3-117">幅、高さ、前景色など、コントロールのプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-117">Set properties on the control, such as width, height, or foreground color.</span></span>
- <span data-ttu-id="e83b3-118">動作を行うためのコードをコントロールに追加します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-118">Add code to the control's event handlers so that it does something.</span></span> 

## <a name="add-a-control"></a><span data-ttu-id="e83b3-119">コントロールの追加</span><span class="sxs-lookup"><span data-stu-id="e83b3-119">Add a control</span></span>
<span data-ttu-id="e83b3-120">アプリにコントロールを追加するには、いくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="e83b3-120">You can add a control to an app in several ways:</span></span>
 
- <span data-ttu-id="e83b3-121">Blend for Visual Studio や Microsoft Visual Studio Extensible Application Markup Language (XAML) デザイナーなどのデザイン ツールを使用する。</span><span class="sxs-lookup"><span data-stu-id="e83b3-121">Use a design tool like Blend for Visual Studio or the Microsoft Visual Studio Extensible Application Markup Language (XAML) designer.</span></span> 
- <span data-ttu-id="e83b3-122">Visual Studio XAML エディターで XAML マークアップにコントロールを追加する。</span><span class="sxs-lookup"><span data-stu-id="e83b3-122">Add the control to the XAML markup in the Visual Studio XAML editor.</span></span> 
- <span data-ttu-id="e83b3-123">コードでコントロールを追加する。</span><span class="sxs-lookup"><span data-stu-id="e83b3-123">Add the control in code.</span></span> <span data-ttu-id="e83b3-124">コードで追加するコントロールは、アプリを実行するときには表示されますが、Visual Studio XAML デザイナーでは表示されません。</span><span class="sxs-lookup"><span data-stu-id="e83b3-124">Controls that you add in code are visible when the app runs, but are not visible in the Visual Studio XAML designer.</span></span>

<span data-ttu-id="e83b3-125">Visual Studio でアプリにコントロールを追加して操作するときには、[ツールボックス]、XAML デザイナー、XAML エディター、[プロパティ] ウィンドウなど、Visual Studio の多くの機能を利用できます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-125">In Visual Studio, when you add and manipulate controls in your app, you can use many of the program's features, including the Toolbox, XAML designer, XAML editor, and the Properties window.</span></span> 

<span data-ttu-id="e83b3-126">Visual Studio の [ツールボックス] には、アプリで使用できる多くのコントロールが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-126">The Visual Studio Toolbox displays many of the controls that you can use in your app.</span></span> <span data-ttu-id="e83b3-127">コントロールをアプリに追加するには、[ツールボックス] でそのコントロールをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="e83b3-127">To add a control to your app, double-click it in the Toolbox.</span></span> <span data-ttu-id="e83b3-128">たとえば、TextBox コントロールをダブルクリックすると、この XAML が [XAML] ビューに追加されます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-128">For example, when you double-click the TextBox control, this XAML is added to the XAML view.</span></span> 

```xaml
<TextBox HorizontalAlignment="Left" Text="TextBox" VerticalAlignment="Top"/>
```

<span data-ttu-id="e83b3-129">また、コントロールを [ツールボックス] から XAML デザイナーにドラッグすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-129">You can also drag the control from the Toolbox to the XAML designer.</span></span>

## <a name="set-the-name-of-a-control"></a><span data-ttu-id="e83b3-130">コントロールの名前の設定</span><span class="sxs-lookup"><span data-stu-id="e83b3-130">Set the name of a control</span></span>

<span data-ttu-id="e83b3-131">コントロールをコードで操作する場合は、コントロールの [x:Name](../../xaml-platform/x-name-attribute.md) 属性を設定し、コードでは名前でコントロールを参照します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-131">To work with a control in code, you set its [x:Name](../../xaml-platform/x-name-attribute.md) attribute and reference it by name in your code.</span></span> <span data-ttu-id="e83b3-132">名前は、Visual Studio の [プロパティ] ウィンドウまたは XAML で設定できます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-132">You can set the name in the Visual Studio Properties window or in XAML.</span></span> <span data-ttu-id="e83b3-133">以下では、[プロパティ] ウィンドウの上部にある [名前] ボックスを使って、現在選択されているコントロールの名前を設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e83b3-133">Here's how to set the name of the currently selected control by using the Name text box at the top of the Properties window.</span></span>

<span data-ttu-id="e83b3-134">コントロールに名前を付けるには</span><span class="sxs-lookup"><span data-stu-id="e83b3-134">To name a control</span></span>
1. <span data-ttu-id="e83b3-135">名前を付ける要素を選びます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-135">Select the element to name.</span></span>
2. <span data-ttu-id="e83b3-136">[プロパティ] パネルで、[名前] ボックスに名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-136">In the Properties panel, type a name into the Name text box.</span></span>
3. <span data-ttu-id="e83b3-137">Enter キーを押して、名前をコミットします。</span><span class="sxs-lookup"><span data-stu-id="e83b3-137">Press Enter to commit the name.</span></span>

![Visual Studio デザイナーでの Name プロパティ](images/add-controls-control-name-designer.png)

<span data-ttu-id="e83b3-139">XAML エディターで x:Name 属性を追加してコントロールの名前を設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-139">Here's how to set the name of a control in the XAML editor by adding the x:Name attribute.</span></span>

```xaml
<Button x:Name="Button1" Content="Button"/>
```

## <a name="set-the-control-properties"></a><span data-ttu-id="e83b3-140">コントロールのプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="e83b3-140">Set the control properties</span></span> 

<span data-ttu-id="e83b3-141">プロパティを使って、コントロールの外観、内容、その他の属性を指定します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-141">You use properties to specify the appearance, content, and other attributes of controls.</span></span> <span data-ttu-id="e83b3-142">デザイン ツールを使ってコントロールを追加すると、Visual Studio によってサイズ、位置、コンテンツを制御するプロパティが設定されることがあります。</span><span class="sxs-lookup"><span data-stu-id="e83b3-142">When you add a control using a design tool, some properties that control size, position, and content might be set for you by Visual Studio.</span></span> <span data-ttu-id="e83b3-143">Width、Height、Margin など、いくつかのプロパティは、[デザイン] ビューでコントロールを選んで操作することで変更できます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-143">You can change some properties, such as Width, Height or Margin, by selecting and manipulating the control in the Design view.</span></span> <span data-ttu-id="e83b3-144">次の図は、[デザイン] ビューで使用できるサイズ変更ツールの一部を示しています。</span><span class="sxs-lookup"><span data-stu-id="e83b3-144">This illustration shows some of the resizing tools available in Design view.</span></span> 

![Visual Studio デザイナーでのサイズ変更ツール](images/add-controls-resizing-designer.png)

<span data-ttu-id="e83b3-146">コントロールのサイズと位置が自動的に調整されることが望ましいということも考えられます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-146">You might want to let the control be sized and positioned automatically.</span></span> <span data-ttu-id="e83b3-147">この場合、Visual Studio によって設定されるサイズと位置に関するプロパティをリセットできます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-147">In this case, you can reset the size and position properties that Visual Studio set for you.</span></span>

<span data-ttu-id="e83b3-148">プロパティをリセットするには</span><span class="sxs-lookup"><span data-stu-id="e83b3-148">To reset a property</span></span>
1. <span data-ttu-id="e83b3-149">[プロパティ] パネルで、プロパティ値の横のプロパティ マーカーをクリックします。</span><span class="sxs-lookup"><span data-stu-id="e83b3-149">In the Properties panel, click the property marker next to the property value.</span></span> <span data-ttu-id="e83b3-150">プロパティ メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-150">The property menu opens.</span></span>
2. <span data-ttu-id="e83b3-151">プロパティ メニューで、[リセット] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e83b3-151">In the property menu, click Reset.</span></span>

![Visual Studio のプロパティ メニューのリセット オプション](images/add-controls-property-reset.png)

<span data-ttu-id="e83b3-153">コントロールのプロパティは、[プロパティ] ウィンドウ、XAML、またはコードで設定できます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-153">You can set control properties in the Properties window, in XAML, or in code.</span></span> <span data-ttu-id="e83b3-154">たとえば、Button の前景色を変更するには、コントロールの Foreground プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-154">For example, to change the foreground color for a Button, you set the control's Foreground property.</span></span> <span data-ttu-id="e83b3-155">次の図は、[プロパティ] ウィンドウのカラー ピッカーを使って Foreground プロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e83b3-155">This illustration shows how to set the Foreground property by using the color picker in the Properties window.</span></span> 

![Visual Studio デザイナーでのカラー ピッカー](images/add-controls-foreground-designer.png)

<span data-ttu-id="e83b3-157">次に、XAML エディターの Foreground プロパティを設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-157">Here's how to set the Foreground property in the XAML editor.</span></span> <span data-ttu-id="e83b3-158">構文の入力を簡単にするために、Visual Studio の IntelliSense ウィンドウが開いています。</span><span class="sxs-lookup"><span data-stu-id="e83b3-158">Notice the Visual Studio IntelliSense window that opens to help you with the syntax.</span></span> 

![XAML での Intellisense パート 1](images/add-controls-foreground-xaml.png)

![XAML での Intellisense パート 2](images/add-controls-foreground-xaml-2.png)

<span data-ttu-id="e83b3-161">Foreground プロパティを設定した後の結果の XAML を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-161">Here's the resulting XAML after you set the Foreground property.</span></span> 

```xaml
<Button x:Name="Button1" Content="Button" 
        HorizontalAlignment="Left" VerticalAlignment="Top"
        Foreground="Beige"/>
```

<span data-ttu-id="e83b3-162">次に、Foreground プロパティをコードで設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-162">Here's how to set the Foreground property in code.</span></span> 

```csharp
Button1.Foreground = new SolidColorBrush(Windows.UI.Colors.Beige);
```

## <a name="create-an-event-handler"></a><span data-ttu-id="e83b3-163">イベント ハンドラーの作成</span><span class="sxs-lookup"><span data-stu-id="e83b3-163">Create an event handler</span></span> 

<span data-ttu-id="e83b3-164">各コントロールには、ユーザーの操作またはアプリ内での他の変更に対して応答するためのイベントが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e83b3-164">Each control has events that enable you to respond to actions from your user or other changes in your app.</span></span> <span data-ttu-id="e83b3-165">たとえば、Button コントロールには、ユーザーがボタンをクリックしたときに発生する Click イベントがあります。</span><span class="sxs-lookup"><span data-stu-id="e83b3-165">For example, a Button control has a Click event that is raised when a user clicks the Button.</span></span> <span data-ttu-id="e83b3-166">イベントを処理するために、イベント ハンドラーと呼ばれるメソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-166">You create a method, called an event handler, to handle the event.</span></span> <span data-ttu-id="e83b3-167">[プロパティ] ウィンドウでは、XAML またはコードでイベント ハンドラー メソッドとコントロールのイベントを関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-167">You can associate a control's event with an event handler method in the Properties window, in XAML, or in code.</span></span> <span data-ttu-id="e83b3-168">イベントについて詳しくは、「[イベントとルーティング イベントの概要](../../xaml-platform/events-and-routed-events-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e83b3-168">For more info about events, see [Events and routed events overview](../../xaml-platform/events-and-routed-events-overview.md).</span></span>

<span data-ttu-id="e83b3-169">イベント ハンドラーを作成するには、コントロールを選んだ後、[プロパティ] ウィンドウの上部にある [イベント] タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="e83b3-169">To create an event handler, select the control and then click the Events tab at the top of the Properties window.</span></span> <span data-ttu-id="e83b3-170">[プロパティ] ウィンドウに、そのコントロールに対して利用可能なすべてのイベントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-170">The Properties window lists all of the events available for that control.</span></span> <span data-ttu-id="e83b3-171">Button のイベントの一部を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-171">Here are some of the events for a Button.</span></span>

![Visual Studio のイベント一覧](images/add-controls-add-event-designer.png)

<span data-ttu-id="e83b3-173">イベント ハンドラーを既定の名前で作成するには、[プロパティ] ウィンドウ内でイベント名の横にあるテキスト ボックスをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="e83b3-173">To create an event handler with the default name, double-click the text box next to the event name in the Properties window.</span></span> <span data-ttu-id="e83b3-174">イベント ハンドラーをカスタム名で作成するには、テキスト ボックスに名前を入力して Enter キーを押します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-174">To create an event handler with a custom name, type the name of your choice into the text box and press enter.</span></span> <span data-ttu-id="e83b3-175">イベント ハンドラーが作成され、コード ビハインド ファイルがコード エディターで開きます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-175">The event handler is created and the code-behind file is opened in the code editor.</span></span> <span data-ttu-id="e83b3-176">イベント ハンドラーのメソッドには、パラメーターが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="e83b3-176">The event handler method has 2 parameters.</span></span> <span data-ttu-id="e83b3-177">1 つが `sender` です。これは、ハンドラーがアタッチされているオブジェクトへの参照です。</span><span class="sxs-lookup"><span data-stu-id="e83b3-177">The first is `sender`, which is a reference to the object where the handler is attached.</span></span> <span data-ttu-id="e83b3-178">`sender` パラメーターは **Object** 型です。</span><span class="sxs-lookup"><span data-stu-id="e83b3-178">The `sender` parameter is an **Object** type.</span></span> <span data-ttu-id="e83b3-179">`sender` オブジェクト自体で状態を確認または変更する必要がある場合には、通常、`sender` をもっと正確な型にキャストします。</span><span class="sxs-lookup"><span data-stu-id="e83b3-179">You typically cast `sender` to a more precise type if you expect to check or change the state on the `sender` object itself.</span></span> <span data-ttu-id="e83b3-180">それぞれのアプリ設計に基づき、`sender` のキャスト先として安全な型をハンドラーのアタッチ先を基に把握する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e83b3-180">Based on your own app design, you expect a type that is safe to cast the `sender` to, based on where the handler is attached.</span></span> <span data-ttu-id="e83b3-181">2 つ目の値はイベント データです。これは通常、`e` パラメーターまたは `args` パラメーターとしてシグネチャに表示されます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-181">The second value is event data, which generally appears in signatures as the `e` or `args` parameter.</span></span>

<span data-ttu-id="e83b3-182">`Button1` という名前が付いた Button の Click イベントを処理するコードを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-182">Here's code that handles the Click event of a Button named `Button1`.</span></span> <span data-ttu-id="e83b3-183">ボタンをクリックすると、クリックした Button の Foreground プロパティが青色に設定されます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-183">When you click the button, the Foreground property of the Button you clicked is set to blue.</span></span> 

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    Button b = (Button)sender;
    b.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
}
```

<span data-ttu-id="e83b3-184">また、イベント ハンドラーを XAML で関連付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-184">You can also associate an event handler in XAML.</span></span> <span data-ttu-id="e83b3-185">XAML エディターで、処理するイベント名を入力します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-185">In the XAML editor, type in the event name that you want to handle.</span></span> <span data-ttu-id="e83b3-186">入力を始めると、Visual Studio に IntelliSense ウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-186">Visual Studio shows an IntelliSense window when you begin typing.</span></span> <span data-ttu-id="e83b3-187">イベントを指定した後は、IntelliSense ウィンドウで `<New Event Handler>` をダブルクリックして新しいイベント ハンドラーを既定の名前で作成するか、一覧から既にあるイベント ハンドラーを選びます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-187">After you specify the event, you can double-click `<New Event Handler>` in the IntelliSense window to create a new event handler with the default name, or select an existing event handler from the list.</span></span> 

<span data-ttu-id="e83b3-188">表示される IntelliSense ウィンドウを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-188">Here's the IntelliSense window that appears.</span></span> <span data-ttu-id="e83b3-189">IntelliSense ウィンドウは、新しいイベント ハンドラーを作成したり、既存のイベント ハンドラーを選択するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-189">It helps you create a new event handler or select an existing event handler.</span></span>

![クリック イベント用の Intellisense](images/add-controls-add-event-xaml.png)

<span data-ttu-id="e83b3-191">次の例では、XAML で Click イベントを Button_Click という名前のイベント ハンドラーと関連付ける方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e83b3-191">This example shows how to associate a Click event with an event handler named Button_Click in XAML.</span></span> 

```xaml
<Button Name="Button1" Content="Button" Click="Button_Click"/>
```

<span data-ttu-id="e83b3-192">イベントは、コード ビハインド内でイベント ハンドラーに関連付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="e83b3-192">You can also associate an event with its event handler in the code-behind.</span></span> <span data-ttu-id="e83b3-193">イベント ハンドラーをコードで関連付ける方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e83b3-193">Here's how to associate an event handler in code.</span></span>

```csharp
Button1.Click += new RoutedEventHandler(Button_Click);
```

## <a name="related-topics"></a><span data-ttu-id="e83b3-194">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e83b3-194">Related topics</span></span>

-   [<span data-ttu-id="e83b3-195">機能別コントロールのインデックス</span><span class="sxs-lookup"><span data-stu-id="e83b3-195">Index of controls by function</span></span>](controls-by-function.md)
-   [<span data-ttu-id="e83b3-196">Windows.UI.Xaml.Controls 名前空間</span><span class="sxs-lookup"><span data-stu-id="e83b3-196">Windows.UI.Xaml.Controls namespace</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.aspx)
-   [<span data-ttu-id="e83b3-197">レイアウト</span><span class="sxs-lookup"><span data-stu-id="e83b3-197">Layout</span></span>](../layout/index.md)
-   [<span data-ttu-id="e83b3-198">スタイル</span><span class="sxs-lookup"><span data-stu-id="e83b3-198">Style</span></span>](../style/index.md)
-   [<span data-ttu-id="e83b3-199">ユーザビリティ</span><span class="sxs-lookup"><span data-stu-id="e83b3-199">Usability</span></span>](../usability/index.md)
