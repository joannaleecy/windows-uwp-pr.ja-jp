---
author: muhsinking
Description: This tutorial walks through how to create a basic application user interface. It explains and demonstrates the use of Grid and StackPanel, two of the most common XAML elements.
title: Grid と StackPanel を使った単純な天気予報アプリの作成。
template: detail.hbs
ms.author: mukin
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10、UWP
ms.assetid: 9794a04d-e67f-472c-8ba8-8ebe442f6ef2
ms.localizationpriority: medium
ms.openlocfilehash: 0327437c809455cf191dcfc572e4a5145b73eb49
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6196305"
---
# <a name="tutorial-use-grid-and-stackpanel-to-create-a-simple-weather-app"></a><span data-ttu-id="e1c5f-103">チュートリアル: Grid と StackPanel を使った単純な天気予報アプリの作成</span><span class="sxs-lookup"><span data-stu-id="e1c5f-103">Tutorial: Use Grid and StackPanel to create a simple weather app</span></span>

<span data-ttu-id="e1c5f-104">ここでは、XAML の **Grid** 要素と **StackPanel** 要素を使って単純な天気予報アプリのレイアウトを作成します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-104">Use XAML to create the layout for a simple weather app using the **Grid** and **StackPanel** elements.</span></span> <span data-ttu-id="e1c5f-105">これらのツールを使用すると、Windows 10 が実行されたすべてのデバイスで動作する魅力ある外観のアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-105">With these tools you can make great looking apps that work on any device running Windows 10.</span></span> <span data-ttu-id="e1c5f-106">このチュートリアルの所要時間は 10 ～ 20 分です。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-106">This tutorial takes 10-20 minutes.</span></span>

> <span data-ttu-id="e1c5f-107">**重要な API**:[ Grid クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.grid)、[StackPanel クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.stackpanel)</span><span class="sxs-lookup"><span data-stu-id="e1c5f-107">**Important APIs**: [Grid class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.grid), [StackPanel class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.stackpanel)</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e1c5f-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="e1c5f-108">Prerequisites</span></span>
- <span data-ttu-id="e1c5f-109">Windows 10 と Microsoft Visual Studio 2015 以降。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-109">Windows 10 and Microsoft Visual Studio 2015 or later.</span></span> <span data-ttu-id="e1c5f-110">(最新の Visual Studio 推奨される現在の開発とセキュリティ更新プログラム)[ここをクリックすると、Visual Studio での設定を取得する方法について説明します](../../get-started/get-set-up.md)して。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-110">(Newest Visual Studio recommended for current development and security updates) [Click here to learn how to get set up with Visual Studio](../../get-started/get-set-up.md).</span></span>
- <span data-ttu-id="e1c5f-111">XAML と C# を使って基本的な "Hello World" アプリを作成する方法に関する知識。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-111">Knowledge of how to create a basic "Hello World" app by using XAML and C#.</span></span> <span data-ttu-id="e1c5f-112">必要に応じて[ここをクリックし、"Hello World" アプリの作成方法を学習してください](https://msdn.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-112">If you don't have that yet, [click here to learn how to create a "Hello World" app](https://msdn.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span>

## <a name="step-1-create-a-blank-app"></a><span data-ttu-id="e1c5f-113">手順 1: 空のアプリを作成する</span><span class="sxs-lookup"><span data-stu-id="e1c5f-113">Step 1: Create a blank app</span></span>
1. <span data-ttu-id="e1c5f-114">Visual Studio のメニューで、**[ファイル]** > **[新しいプロジェクト]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-114">In Visual Studio menu, select **File** > **New Project**.</span></span>
2. <span data-ttu-id="e1c5f-115">**[新しいプロジェクト]** ダイアログ ボックスの左側のウィンドウで、**[Visual C#]** > **[Windows]** > **[ユニバーサル]** を選択するか、**[Visual C++]** > **[Windows]** > **[ユニバーサル]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-115">In the left pane of the **New Project** dialog box, select **Visual C#** > **Windows** > **Universal** or **Visual C++** > **Windows** > **Universal**.</span></span>
3. <span data-ttu-id="e1c5f-116">中央のウィンドウで、**[空のアプリケーション]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-116">In the center pane, select **Blank App**.</span></span>
4. <span data-ttu-id="e1c5f-117">**[名前]** ボックスに「**WeatherPanel**」と入力し、**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-117">In the **Name** box, enter **WeatherPanel**, and select **OK**.</span></span>
5. <span data-ttu-id="e1c5f-118">プログラムを実行するには、メニューで **[デバッグ]** > **[デバッグの開始]** を選択するか、F5 を選択します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-118">To run the program, select **Debug** > **Start Debugging** from the menu, or select F5.</span></span>

## <a name="step-2-define-a-grid"></a><span data-ttu-id="e1c5f-119">手順 2: Grid を定義する</span><span class="sxs-lookup"><span data-stu-id="e1c5f-119">Step 2: Define a Grid</span></span>
<span data-ttu-id="e1c5f-120">XAML において、**Grid** は一連の行と列で構成されます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-120">In XAML a **Grid** is made up of a series of rows and columns.</span></span> <span data-ttu-id="e1c5f-121">**Grid** で要素の行と列を指定することで、ユーザー インターフェイス内に要素を配置し、他の要素との間の余白を設定できます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-121">By specifying the row and column of an element within a **Grid**, you can place and space other elements within a user interface.</span></span> <span data-ttu-id="e1c5f-122">行と列は、**RowDefinition** 要素と**ColumnDefinition** 要素で定義します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-122">Rows and columns are defined with the **RowDefinition** and **ColumnDefinition** elements.</span></span>

<span data-ttu-id="e1c5f-123">レイアウトの作成を開始するには、**ソリューション エクスプローラー**を使って **MainPage.xaml** を開き、自動的に生成される **Grid** 要素を以下のコードに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-123">To start creating a layout, open **MainPage.xaml** by using the **Solution Explorer**, and replace the automatically generated **Grid** element with this code.</span></span>

```xml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="3*"/>
        <ColumnDefinition Width="5*"/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="2*"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
</Grid>
```

<span data-ttu-id="e1c5f-124">この新しい **Grid** によって 2 行 x 2 列のセットが作成され、このアプリ インターフェイスのレイアウトが定義されます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-124">The new **Grid** creates a set of two rows and columns, which defines the layout of the app interface.</span></span> <span data-ttu-id="e1c5f-125">2 つの列は、1 列目の **Width** が "3\*" で、2 列目が "5\*" です。したがって、水平方向の領域は、これら 2 つの列の間で 3:5 の比率で分割されます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-125">The first column has a **Width** of "3\*", while the second has "5\*", dividing the horizontal space between the two columns at a ratio of 3:5.</span></span> <span data-ttu-id="e1c5f-126">同様に、2 つの行はそれぞれの **Height** が "2\*" と "\*" です。したがって、この **Grid** では、1 行目に対し、2 行目の 2 倍の領域が割り当てられます ("\*" は "1\*" と同じです)。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-126">In the same way, the two rows have a **Height** of "2\*" and "\*" respectively, so the **Grid** allocates two times as much space for the first row as for the second ("\*" is the same as "1\*").</span></span> <span data-ttu-id="e1c5f-127">これらの比率は、ウィンドウのサイズを変更したり、異なるデバイスを使ったりしても変わりません。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-127">These ratios are maintained even if the window is resized or the device is changed.</span></span>

<span data-ttu-id="e1c5f-128">行や列のサイズを指定するその他の方法については、「[XAML を使ったページ レイアウトの定義](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml#layout-properties)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-128">To learn about other methods of sizing rows and columns, see [Define layouts with XAML](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml#layout-properties).</span></span>

<span data-ttu-id="e1c5f-129">この時点では、**Grid** 領域にコンテンツがまったく含まれていないため、アプリケーションを実行しても空白のページが表示されるだけです。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-129">If you run the application now you won't see anything except a blank page, because none of the **Grid** areas have any content.</span></span> <span data-ttu-id="e1c5f-130">そこで **Grid** を表示するために、色を付けることにします。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-130">To show the **Grid** let's give it some color.</span></span>

## <a name="step-3-color-the-grid"></a><span data-ttu-id="e1c5f-131">手順 3: Grid に色を付ける</span><span class="sxs-lookup"><span data-stu-id="e1c5f-131">Step 3: Color the Grid</span></span>
<span data-ttu-id="e1c5f-132">**Grid** に色を付けるために、ここでは異なる背景色を持つ 3 つの **Border** 要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-132">To color the **Grid** we add three **Border** elements, each with a different background color.</span></span> <span data-ttu-id="e1c5f-133">また **Grid.Row** 属性と **Grid.Column** 属性を使って、各要素を親 **Grid** の行と列に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-133">Each is also assigned to a row and column in the parent **Grid** by using the **Grid.Row** and **Grid.Column** attributes.</span></span> <span data-ttu-id="e1c5f-134">これらの属性は既定値が 0 であるため、最初の **Border** には属性値を割り当てる必要がありません。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-134">The values of these attributes default to 0, so you don't need to assign them to the first **Border**.</span></span> <span data-ttu-id="e1c5f-135">**Grid** 要素の行と列の定義の後に、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-135">Add the following code to the **Grid** element after the row and column definitions.</span></span>

```xml
<Border Background="#2f5cb6"/>
<Border Grid.Column ="1" Background="#1f3d7a"/>
<Border Grid.Row="1" Grid.ColumnSpan="2" Background="#152951"/>
```

<span data-ttu-id="e1c5f-136">3 番目の **Border** で、**Grid.ColumnSpan** という追加の属性が使われていることに注意してください。これにより、この **Border** が下側の行の両方の列にスパンします。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-136">Notice that for the third **Border** we use an extra attribute, **Grid.ColumnSpan**, which causes this **Border** to span both columns in the lower row.</span></span> <span data-ttu-id="e1c5f-137">同様の方法で **Grid.RowSpan** を使うことができ、これらの属性によって、任意の数の行や列に要素をスパンすることができます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-137">You can use **Grid.RowSpan** in the same way, and together these attributes let you span an element over any number of rows and columns.</span></span> <span data-ttu-id="e1c5f-138">このようなスパンの左上隅は、常に、要素の属性で指定した **Grid.Column** と **Grid.Row** です。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-138">The upper-left corner of such a span is always the **Grid.Column** and **Grid.Row** specified in the element attributes.</span></span>

<span data-ttu-id="e1c5f-139">ここでアプリを実行すると、結果が次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-139">If you run the app, the result looks something like this.</span></span>

![グリッドの色を付ける](images/grid-weather-1.png)

## <a name="step-4-organize-content-by-using-stackpanel-elements"></a><span data-ttu-id="e1c5f-141">手順 4: StackPanel 要素を使ってコンテンツを配置する</span><span class="sxs-lookup"><span data-stu-id="e1c5f-141">Step 4: Organize content by using StackPanel elements</span></span>
<span data-ttu-id="e1c5f-142">この天気予報アプリの作成で使用する 2 番目の要素は、**StackPanel** です。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-142">**StackPanel** is the second UI element we'll use to create our weather app.</span></span> <span data-ttu-id="e1c5f-143">**StackPanel** は多くの基本的なアプリのレイアウトで使われている要素であり、複数の要素を上下または左右にスタックすることができます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-143">The **StackPanel** is a fundamental part of many basic app layouts, allowing you to stack elements vertically or horizontally.</span></span>

<span data-ttu-id="e1c5f-144">次のコードでは、2 つの **StackPanel** 要素を作成し、それぞれに 3 つの**TextBlocks** を設定しています。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-144">In the following code, we create two **StackPanel** elements and fill each with three **TextBlocks**.</span></span> <span data-ttu-id="e1c5f-145">これらの **StackPanel** 要素を、**Grid** の手順 3 で作成した **Border** 要素の下に追加します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-145">Add these **StackPanel** elements to the **Grid** below the **Border** elements from Step 3.</span></span> <span data-ttu-id="e1c5f-146">これにより、先ほど作成した色付きの **Grid** の上にこれらの **TextBlock** 要素が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-146">This causes the **TextBlock** elements to render on top of the colored **Grid** we created earlier.</span></span>

```xml
<StackPanel Grid.Column="1" Margin="40,0,0,0" VerticalAlignment="Center">
    <TextBlock Foreground="White" FontSize="25" Text="Today - 64° F"/>
    <TextBlock Foreground="White" FontSize="25" Text="Partially Cloudy"/>
    <TextBlock Foreground="White" FontSize="25" Text="Precipitation: 25%"/>
</StackPanel>
<StackPanel Grid.Row="1" Grid.ColumnSpan="2" Orientation="Horizontal"
            HorizontalAlignment="Center" VerticalAlignment="Center">
    <TextBlock Foreground="White" FontSize="25" Text="High: 66°" Margin="0,0,20,0"/>
    <TextBlock Foreground="White" FontSize="25" Text="Low: 43°" Margin="0,0,20,0"/>
    <TextBlock Foreground="White" FontSize="25" Text="Feels like: 63°"/>
</StackPanel>
```

<span data-ttu-id="e1c5f-147">最初の **Stackpanel** では、各 **TextBlock** が上から順に上下にスタックされます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-147">In the first **Stackpanel**, each **TextBlock** stacks vertically below the next.</span></span> <span data-ttu-id="e1c5f-148">これは StackPanel の既定の動作であるため、**Orientation** 属性を設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-148">This is the default behavior of a StackPanel, so we don't need to set the **Orientation** attribute.</span></span> <span data-ttu-id="e1c5f-149">2 番目の StackPanel では、子要素を左から右へ左右にスタックするために、**Orientation** 属性を "Horizontal" に設定しています。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-149">In the second StackPanel, we want the child elements to stack horizontally from left to right, so we set the **Orientation** attribute to "Horizontal".</span></span> <span data-ttu-id="e1c5f-150">またテキストを下側の **Border** 全体にわたって中央揃えで配置するためには、**Grid.ColumnSpan** 属性を "2" に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-150">We must also set the **Grid.ColumnSpan** attribute to "2", so that the text is centered over the lower **Border**.</span></span>

<span data-ttu-id="e1c5f-151">ここでアプリを実行すると、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-151">If you run the app now, you'll see something like this.</span></span>

![StackPanels を追加する](images/grid-weather-2.png)

## <a name="step-5-add-an-image-icon"></a><span data-ttu-id="e1c5f-153">手順 5: 画像アイコンを追加する</span><span class="sxs-lookup"><span data-stu-id="e1c5f-153">Step 5: Add an image icon</span></span>

<span data-ttu-id="e1c5f-154">最後にこの **Grid** の空のセクションに、今日の天気である "partially cloudy (晴れ時々曇り)" を表す画像を配置します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-154">Finally, let's fill the empty section in our **Grid** with an image that represents today's weather—something that says "partially cloudy."</span></span>

<span data-ttu-id="e1c5f-155">次の画像をダウンロードし、"partially-cloudy" という名前の PNG ファイルとして保存します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-155">Download the image below and save it as a PNG named "partially-cloudy".</span></span>

![Partially cloudy](images/partially-cloudy.PNG)

<span data-ttu-id="e1c5f-157">**ソリューション エクスプローラー**で **Assets** フォルダーを右クリックし、**[追加]** -> **[既存の項目...]** を選択します。ポップアップ表示されるブラウザーで partially-cloudy.png を見つけ、選択して **[追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-157">In the **Solution Explorer**, right click the **Assets** folder, and select **Add** -> **Existing Item...** Find partially-cloudy.png in the browser that pops up, select it, and click **Add**.</span></span>

<span data-ttu-id="e1c5f-158">次に **MainPage.xaml** で、手順 4 で指定した StackPanel の下に次の **Image** 要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-158">Next, in **MainPage.xaml**, add the following **Image** element below the StackPanels from Step 4.</span></span>

```xml
<Image Margin="20" Source="Assets/partially-cloudy.png"/>
```

<span data-ttu-id="e1c5f-159">この画像は最初の行と列に配置されるため、**Grid.Row** 属性や **Grid.Column** 属性を設定する必要がなく、既定値の "0" をそのまま使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-159">Because we want the Image in the first row and column, we don't need to set its **Grid.Row** or **Grid.Column** attributes, allowing them to default to "0".</span></span>

<span data-ttu-id="e1c5f-160">以上で作業は終了です。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-160">And that's it!</span></span> <span data-ttu-id="e1c5f-161">単純な天気予報アプリケーションのレイアウトが作成されました。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-161">You've successfully created the layout for a simple weather application.</span></span> <span data-ttu-id="e1c5f-162">**F5** キーを押してアプリケーションを実行すると、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-162">If you run the application by pressing **F5**, you should see something like this:</span></span>

![天気予報ウィンドウのサンプル](images/grid-weather-3.PNG)

<span data-ttu-id="e1c5f-164">さらに理解を深めたい場合は、上のレイアウトを自由に変更して、天気データをさまざまな方法で表示してみてください。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-164">If you like, try experimenting with the layout above, and explore different ways you might represent weather data.</span></span>

## <a name="related-articles"></a><span data-ttu-id="e1c5f-165">関連記事</span><span class="sxs-lookup"><span data-stu-id="e1c5f-165">Related articles</span></span>
<span data-ttu-id="e1c5f-166">UWP アプリのレイアウト設計の概要については、「[UWP アプリ設計の概要](https://msdn.microsoft.com/windows/uwp/layout/design-and-ui-intro)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-166">For an introduction to designing UWP app layouts, see [Introduction to UWP app design](https://msdn.microsoft.com/windows/uwp/layout/design-and-ui-intro)</span></span>

<span data-ttu-id="e1c5f-167">さまざまな画面サイズに適応できるレスポンシブ レイアウトの作成については、「[XAML を使ったページ レイアウトの定義](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e1c5f-167">To learn about creating responsive layouts that adapt to different screen sizes, see [Define Page Layouts with XAML](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml)</span></span>
