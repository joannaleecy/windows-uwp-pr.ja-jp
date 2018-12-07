---
title: スプラッシュ画面の表示時間の延長
description: アプリに追加スプラッシュ画面を作成すれば、より長い時間、スプラッシュ画面を表示することができます。 この追加画面は、アプリを起動したときに表示されるスプラッシュ画面に似ていますが、カスタマイズできます。
ms.assetid: CD3053EB-7F86-4D74-9C5A-950303791AE3
ms.date: 11/08/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 142ee642806ebba41d6ddb4d49fe55217e7a0e2e
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8785930"
---
# <a name="display-a-splash-screen-for-more-time"></a><span data-ttu-id="c94e0-105">スプラッシュ スクリーンの表示時間の延長</span><span class="sxs-lookup"><span data-stu-id="c94e0-105">Display a splash screen for more time</span></span>

**<span data-ttu-id="c94e0-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="c94e0-106">Important APIs</span></span>**

-   [**<span data-ttu-id="c94e0-107">SplashScreen クラス</span><span class="sxs-lookup"><span data-stu-id="c94e0-107">SplashScreen class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224763)
-   [**<span data-ttu-id="c94e0-108">Window.SizeChanged イベント</span><span class="sxs-lookup"><span data-stu-id="c94e0-108">Window.SizeChanged event</span></span>**](https://msdn.microsoft.com/library/windows/apps/br209055)
-   [**<span data-ttu-id="c94e0-109">Application.OnLaunched メソッド</span><span class="sxs-lookup"><span data-stu-id="c94e0-109">Application.OnLaunched method</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242335)

<span data-ttu-id="c94e0-110">アプリに追加スプラッシュ画面を作成すれば、より長い時間、スプラッシュ画面を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-110">Display a splash screen for more time by creating an extended splash screen for your app.</span></span> <span data-ttu-id="c94e0-111">この追加画面は、アプリを起動したときに表示されるスプラッシュ画面に似ていますが、カスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-111">This extended screen imitates the splash screen shown when your app is launched, but can be customized.</span></span> <span data-ttu-id="c94e0-112">読み込み状況をリアルタイムにユーザーに表示する場合や、アプリの最初の UI の準備に時間がかかる場合、追加スプラッシュ画面を使って起動時のエクスペリエンスを定義できます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-112">Whether you want to show real-time loading information or simply give your app extra time to prepare its initial UI, an extended splash screen lets you define the launch experience.</span></span>

> [!NOTE]
> <span data-ttu-id="c94e0-113">語句「追加スプラッシュ画面」、このトピックでは、表示されるスプラッシュ画面、画面上の一定の時間を表します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-113">The phrase "extended splash screen" in this topic refers to a splash screen that stays on the screen for an extended period of time.</span></span> <span data-ttu-id="c94e0-114">[**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) クラスを拡張するサブクラスやこのクラスから派生したサブクラスという意味ではありません。</span><span class="sxs-lookup"><span data-stu-id="c94e0-114">It does not mean a subclass that derives from the [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) class.</span></span>

<span data-ttu-id="c94e0-115">追加スプラッシュ画面の外観は、次の推奨事項に従って、既定のスプラッシュ画面に厳密に似せるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="c94e0-115">Make sure your extended splash screen accurately imitates the default splash screen by following these recommendations:</span></span>

-   <span data-ttu-id="c94e0-116">この追加スプラッシュ画面ページでは、アプリ マニフェスト内でスプラッシュ画面に指定したイメージ (アプリのスプラッシュ画面のイメージ) と一致する 620 x 300 ピクセルのイメージを使います。</span><span class="sxs-lookup"><span data-stu-id="c94e0-116">Your extended splash screen page should use a 620 x 300 pixel image that is consistent with the image specified for your splash screen in your app manifest (your app's splash screen image).</span></span> <span data-ttu-id="c94e0-117">Microsoft Visual の Studio2015 では、スプラッシュ画面の設定は、アプリ マニフェスト (Package.appxmanifest ファイル) で、[**ビジュアル資産**] タブの [**スプラッシュ画面**] セクションで保存されます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-117">In Microsoft Visual Studio2015, splash screen settings are stored in the **Splash Screen** section of the **Visual Assets** tab in your app manifest (Package.appxmanifest file).</span></span>
-   <span data-ttu-id="c94e0-118">追加スプラッシュ画面では、アプリ マニフェスト内でスプラッシュ画面に指定した背景色 (アプリのスプラッシュ画面の背景) と一致する背景色を使います。</span><span class="sxs-lookup"><span data-stu-id="c94e0-118">Your extended splash screen should use a background color that is consistent with the background color specified for your splash screen in your app manifest (your app's splash screen background).</span></span>
-   <span data-ttu-id="c94e0-119">コードでは、[**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) クラスを使って、アプリのスプラッシュ画面画像の座標が、既定のスプラッシュ画面と同じになるようにします。</span><span class="sxs-lookup"><span data-stu-id="c94e0-119">Your code should use the [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) class to position your app's splash screen image at the same screen coordinates as the default splash screen.</span></span>
-   <span data-ttu-id="c94e0-120">コードでは、[**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) クラスを使って追加スプラッシュ画面上の項目を配置し直すことで、ウィンドウ サイズ変更イベント (画面が回転されたり、画面上で次の別のアプリに移動したりするなど) に応答するようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c94e0-120">Your code should respond to window resize events (such as when the screen is rotated or your app is moved next to another app onscreen) by using the [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) class to reposition items on your extended splash screen.</span></span>

<span data-ttu-id="c94e0-121">次の手順を使うと、既定のスプラッシュ画面とよく似た追加スプラッシュ画面を作成できます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-121">Use the following steps to create an extended splash screen that effectively imitates the default splash screen.</span></span>

## <a name="add-a-blank-page-item-to-your-existing-app"></a><span data-ttu-id="c94e0-122">**[空白のページ]** 項目を既にあるアプリに追加する</span><span class="sxs-lookup"><span data-stu-id="c94e0-122">Add a **Blank Page** item to your existing app</span></span>


<span data-ttu-id="c94e0-123">また、このトピックでは、C#、Visual Basic、C++ を使って、既にあるユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクト用の追加スプラッシュ画面を作成することを想定しています。</span><span class="sxs-lookup"><span data-stu-id="c94e0-123">This topic assumes you want to add an extended splash screen to an existing Universal Windows Platform (UWP) app project using C#, Visual Basic, or C++.</span></span>

-   <span data-ttu-id="c94e0-124">Visual Studio でアプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-124">Open your app in Visual Studio.</span></span>
-   <span data-ttu-id="c94e0-125">メニュー バーから **[プロジェクト]** を開き、**[新しい項目の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c94e0-125">Press or open **Project** from the menu bar and click **Add New Item**.</span></span> <span data-ttu-id="c94e0-126">**[新しい項目の追加]** ダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-126">An **Add New Item** dialog box will appear.</span></span>
-   <span data-ttu-id="c94e0-127">このダイアログ ボックスから新しい**空白のページ**をアプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-127">From this dialog box, add a new **Blank Page** to your app.</span></span> <span data-ttu-id="c94e0-128">このトピックでは、追加スプラッシュ画面ページの名前を "ExtendedSplash" とします。</span><span class="sxs-lookup"><span data-stu-id="c94e0-128">This topic names the extended splash screen page "ExtendedSplash".</span></span>

<span data-ttu-id="c94e0-129">**[空白のページ]** 項目を追加すると、2 つのファイルが生成されます。1 つはマークアップ用 (ExtendedSplash.xaml)、もう 1 つはコード用 (ExtendedSplash.xaml.cs) です。</span><span class="sxs-lookup"><span data-stu-id="c94e0-129">Adding a **Blank Page** item generates two files, one for markup (ExtendedSplash.xaml) and another for code (ExtendedSplash.xaml.cs).</span></span>

## <a name="essential-xaml-for-an-extended-splash-screen"></a><span data-ttu-id="c94e0-130">追加スプラッシュ画面の基本的な XAML</span><span class="sxs-lookup"><span data-stu-id="c94e0-130">Essential XAML for an extended splash screen</span></span>


<span data-ttu-id="c94e0-131">次の手順に従って、追加スプラッシュ画面にイメージやプログレス コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-131">Follow these steps to add an image and progress control to your extended splash screen.</span></span>

<span data-ttu-id="c94e0-132">ExtendedSplash.xaml ファイルで次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="c94e0-132">In your ExtendedSplash.xaml file:</span></span>

-   <span data-ttu-id="c94e0-133">既定の [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) 要素の [**Background**](https://msdn.microsoft.com/library/windows/apps/br209396) プロパティを変更して、アプリ マニフェスト (Package.appxmanifest ファイルの **[ビジュアル資産]** セクション) でアプリのスプラッシュ画面に設定した背景色に合わせます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-133">Change the [**Background**](https://msdn.microsoft.com/library/windows/apps/br209396) property of the default [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) element to match the background color you set for your app's splash screen in your app manifest (in the **Visual Assets** section of your Package.appxmanifest file).</span></span> <span data-ttu-id="c94e0-134">既定のスプラッシュ画面の色は薄い灰色 (16 進数 #464646) です。</span><span class="sxs-lookup"><span data-stu-id="c94e0-134">The default splash screen color is a light gray (hex value \#464646).</span></span> <span data-ttu-id="c94e0-135">新しい**空白のページ**を作成すると、この **Grid** 要素が既定で使われることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c94e0-135">Note that this **Grid** element is provided by default when you create a new **Blank Page**.</span></span> <span data-ttu-id="c94e0-136">必ずしも **Grid** を使う必要はありません。追加スプラッシュ画面を作り始めるときに便利なだけです。</span><span class="sxs-lookup"><span data-stu-id="c94e0-136">You don't have to use a **Grid**; it's just a convenient base for building an extended splash screen.</span></span>
-   <span data-ttu-id="c94e0-137">[**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) に [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) 要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-137">Add a [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) element to the [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704).</span></span> <span data-ttu-id="c94e0-138">この **Canvas** を使って追加スプラッシュ画面にイメージを配置します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-138">You'll use this **Canvas** to position your extended splash screen image.</span></span>
-   <span data-ttu-id="c94e0-139">[**Image**](https://msdn.microsoft.com/library/windows/apps/br242752) 要素を [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) に追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-139">Add an [**Image**](https://msdn.microsoft.com/library/windows/apps/br242752) element to the [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267).</span></span> <span data-ttu-id="c94e0-140">既定のスプラッシュ画面用に選んだ同じ 600 × 320 ピクセルの画像を追加スプラッシュ画面に使います。</span><span class="sxs-lookup"><span data-stu-id="c94e0-140">Use the same 600 x 320 pixel image for your extended splash screen that you chose for the default splash screen.</span></span>
-   <span data-ttu-id="c94e0-141">(省略可能) アプリが読み込み中であることをユーザーに示すにはプログレス コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-141">(Optional) Add a progress control to show users that your app is loading.</span></span> <span data-ttu-id="c94e0-142">このトピックでは、確定または不定の [**ProgressBar**](https://msdn.microsoft.com/library/windows/apps/br227529) ではなく、[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) を追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-142">This topic adds a [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538), instead of a determinate or indeterminate [**ProgressBar**](https://msdn.microsoft.com/library/windows/apps/br227529).</span></span>

<span data-ttu-id="c94e0-143">次の例では、これらの追加や変更を持つ[**グリッド**](https://msdn.microsoft.com/library/windows/apps/br242704)を示します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-143">The following example demonstrates a [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) with these additions and changes.</span></span>

```xaml
    <Grid Background="#464646">
        <Canvas>
            <Image x:Name="extendedSplashImage" Source="Assets/SplashScreen.png"/>
            <ProgressRing Name="splashProgressRing" IsActive="True" Width="20" HorizontalAlignment="Center"></ProgressRing>
        </Canvas>
    </Grid>
```

> [!NOTE]
> <span data-ttu-id="c94e0-144">この例では、 [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538)の幅を 20 ピクセルに設定します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-144">This example sets the width of the [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) to 20 pixels.</span></span> <span data-ttu-id="c94e0-145">この幅はアプリに合わせて手動で設定できますが、20 ピクセル未満の幅ではコントロールがレンダリングされません。</span><span class="sxs-lookup"><span data-stu-id="c94e0-145">You can manually set its width to a value that works for your app, however, the control will not render at widths of less than 20 pixels.</span></span>

## <a name="essential-code-for-an-extended-splash-screen-class"></a><span data-ttu-id="c94e0-146">追加スプラッシュ画面クラスの基本的なコード</span><span class="sxs-lookup"><span data-stu-id="c94e0-146">Essential code for an extended splash screen class</span></span>


<span data-ttu-id="c94e0-147">追加スプラッシュ画面はウィンドウのサイズ (Windows のみ) や向きの変更に応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c94e0-147">Your extended splash screen needs to respond whenever the window size (Windows only) or orientation changes.</span></span> <span data-ttu-id="c94e0-148">ウィンドウのサイズがどのように変更されても追加スプラッシュ画面が適切に表示されるように、使う画像の位置は更新される必要があります。</span><span class="sxs-lookup"><span data-stu-id="c94e0-148">The position of the image you use must be updated so that your extended splash screen looks good no matter how the window changes.</span></span>

<span data-ttu-id="c94e0-149">これらの手順を使って、追加スプラッシュ画面を正しく表示するためのメソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-149">Use these steps to define methods to correctly display your extended splash screen.</span></span>

1.  **<span data-ttu-id="c94e0-150">必要な名前空間を追加する</span><span class="sxs-lookup"><span data-stu-id="c94e0-150">Add required namespaces</span></span>**

    <span data-ttu-id="c94e0-151">次の名前空間を ExtendedSplash.xaml.cs に追加して、[**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) クラス、[**Window.SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br209055) イベントにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="c94e0-151">You'll need to add the following namespaces to ExtendedSplash.xaml.cs to access the [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) class, [**Window.SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br209055) events.</span></span>

    ```cs
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Core;
    ```

2.  **<span data-ttu-id="c94e0-152">部分クラスを作成し、クラス変数を宣言する</span><span class="sxs-lookup"><span data-stu-id="c94e0-152">Create a partial class and declare class variables</span></span>**

    <span data-ttu-id="c94e0-153">次のコードを ExtendedSplash.xaml.cs に挿入して、追加スプラッシュ画面を表す部分クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-153">Include the following code in ExtendedSplash.xaml.cs to create a partial class to represent an extended splash screen.</span></span>

    ```cs
    partial class ExtendedSplash : Page
    {
        internal Rect splashImageRect; // Rect to store splash screen image coordinates.
        private SplashScreen splash; // Variable to hold the splash screen object.
        internal bool dismissed = false; // Variable to track splash screen dismissal status.
        internal Frame rootFrame;

       // Define methods and constructor
    }
    ```

    <span data-ttu-id="c94e0-154">これらのクラス変数は、複数のメソッドで使われます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-154">These class variables are used by several methods.</span></span> <span data-ttu-id="c94e0-155">`splashImageRect` は、アプリのスプラッシュ画面のイメージが表示された座標を格納する変数です。</span><span class="sxs-lookup"><span data-stu-id="c94e0-155">The `splashImageRect` variable stores the coordinates where the system displayed the splash screen image for the app.</span></span> <span data-ttu-id="c94e0-156">`splash` は [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) オブジェクトを格納する変数であり、`dismissed` は表示されたスプラッシュ画面が閉じられたかどうかを追跡する変数です。</span><span class="sxs-lookup"><span data-stu-id="c94e0-156">The `splash` variable stores a [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) object, and the `dismissed` variable tracks whether or not the splash screen that is displayed by the system has been dismissed.</span></span>

3.  **<span data-ttu-id="c94e0-157">画像を正しく配置するクラスのコンストラクターを定義する</span><span class="sxs-lookup"><span data-stu-id="c94e0-157">Define a constructor for your class that correctly positions the image</span></span>**

    <span data-ttu-id="c94e0-158">次のコードでは、ウィンドウ サイズ変更イベントをリッスンする追加スプラッシュ画面クラスのコンストラクターを定義し、追加スプラッシュ画面にイメージ (必要に応じてプログレス コントロール) を配置し、ナビゲーション用のフレームを作成し、保存済みのセッションを復元する非同期メソッドを呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="c94e0-158">The following code defines a constructor for the extended splash screen class that listens for window resizing events, positions the image and (optional) progress control on the extended splash screen, creates a frame for navigation, and calls an asynchronous method to restore a saved session state.</span></span>

    ```cs
    public ExtendedSplash(SplashScreen splashscreen, bool loadState)
    {
        InitializeComponent();

        // Listen for window resize events to reposition the extended splash screen image accordingly.
        // This ensures that the extended splash screen formats properly in response to window resizing.
        Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

        splash = splashscreen;
        if (splash != null)
        {
            // Register an event handler to be executed when the splash screen has been dismissed.
            splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(DismissedEventHandler);

            // Retrieve the window coordinates of the splash screen image.
            splashImageRect = splash.ImageLocation;
            PositionImage();

            // If applicable, include a method for positioning a progress control.
            PositionRing();
        }

        // Create a Frame to act as the navigation context
        rootFrame = new Frame();            
    }
    ```

    <span data-ttu-id="c94e0-159">アプリが追加スプラッシュ画面でイメージを正しく配置できるように、クラス コンストラクターに [**Window.SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br209055) ハンドラー (この例の `ExtendedSplash_OnResize`) を登録します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-159">Make sure to register your [**Window.SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br209055) handler (`ExtendedSplash_OnResize` in the example) in your class constructor so that your app positions the image correctly in your extended splash screen.</span></span>

4.  **<span data-ttu-id="c94e0-160">追加スプラッシュ画面にイメージを配置するクラスのメソッドを定義する</span><span class="sxs-lookup"><span data-stu-id="c94e0-160">Define a class method to position the image in your extended splash screen</span></span>**

    <span data-ttu-id="c94e0-161">次のコードでは、`splashImageRect` クラス変数を使って追加スプラッシュ画面ページにイメージを配置する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c94e0-161">This code demonstrates how to position the image on the extended splash screen page with the `splashImageRect` class variable.</span></span>

    ```cs
    void PositionImage()
    {
        extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X);
        extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y);
        extendedSplashImage.Height = splashImageRect.Height;
        extendedSplashImage.Width = splashImageRect.Width;
    }
    ```

5.  **<span data-ttu-id="c94e0-162">(省略可能) 追加スプラッシュ画面にプログレス コントロールを配置するクラスのメソッドを定義する</span><span class="sxs-lookup"><span data-stu-id="c94e0-162">(Optional) Define a class method to position a progress control in your extended splash screen</span></span>**

    <span data-ttu-id="c94e0-163">[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) を追加スプラッシュ画面に追加する場合、スプラッシュ画面のイメージに相対的に配置します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-163">If you chose to add a [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) to your extended splash screen, position it relative to the splash screen image.</span></span> <span data-ttu-id="c94e0-164">ExtendedSplash.xaml.cs で、**ProgressRing** をイメージの 32 ピクセル下の中央に配置する次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-164">Add the following code to ExtendedSplash.xaml.cs to center the **ProgressRing** 32 pixels below the image.</span></span>

    ```cs
    void PositionRing()
    {
        splashProgressRing.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width*0.5) - (splashProgressRing.Width*0.5));
        splashProgressRing.SetValue(Canvas.TopProperty, (splashImageRect.Y + splashImageRect.Height + splashImageRect.Height*0.1));
    }
    ```

6.  **<span data-ttu-id="c94e0-165">クラス内で Dismissed イベントのハンドラーを定義する</span><span class="sxs-lookup"><span data-stu-id="c94e0-165">Inside the class, define a handler for the Dismissed event</span></span>**

    <span data-ttu-id="c94e0-166">ExtendedSplash.xaml.cs で、`dismissed` クラス変数を true に設定することで、[**SplashScreen.Dismissed**](https://msdn.microsoft.com/library/windows/apps/br224764) イベントが発生したときに応答するようにします。</span><span class="sxs-lookup"><span data-stu-id="c94e0-166">In ExtendedSplash.xaml.cs, respond when the [**SplashScreen.Dismissed**](https://msdn.microsoft.com/library/windows/apps/br224764) event occurs by setting the `dismissed` class variable to true.</span></span> <span data-ttu-id="c94e0-167">アプリにセットアップ操作がある場合は、それらの操作をこのイベント ハンドラーに追加します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-167">If your app has setup operations, add them to this event handler.</span></span>

    ```cs
    // Include code to be executed when the system has transitioned from the splash screen to the extended splash screen (application's first view).
    void DismissedEventHandler(SplashScreen sender, object e)
    {
        dismissed = true;

        // Complete app setup operations here...
    }
    ```

    <span data-ttu-id="c94e0-168">アプリのセットアップが完了したら、追加スプラッシュ画面から移動するようにします。</span><span class="sxs-lookup"><span data-stu-id="c94e0-168">After app setup is complete, navigate away from your extended splash screen.</span></span> <span data-ttu-id="c94e0-169">次のコードでは、アプリの MainPage.xaml ファイルで定義されている `MainPage` に移動する `DismissExtendedSplash` というメソッドを定義しています。</span><span class="sxs-lookup"><span data-stu-id="c94e0-169">The following code defines a method called `DismissExtendedSplash` that navigates to the `MainPage` defined in your app's MainPage.xaml file.</span></span>

    ```cs
    async void DismissExtendedSplash()
      {
         await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() =>            {
              rootFrame = new Frame();
              rootFrame.Content = new MainPage(); Window.Current.Content = rootFrame;
            });
      }
      ```

7.  **<span data-ttu-id="c94e0-170">クラス内で Window.SizeChanged イベントのハンドラーを定義する</span><span class="sxs-lookup"><span data-stu-id="c94e0-170">Inside the class, define a handler for Window.SizeChanged events</span></span>**

    <span data-ttu-id="c94e0-171">ユーザーによってウィンドウのサイズが変更された場合にその要素を配置し直すように、追加スプラッシュ画面を準備します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-171">Prepare your extended splash screen to reposition its elements if a user resizes the window.</span></span> <span data-ttu-id="c94e0-172">このコードでは、新しい座標を取得してイメージを配置し直すことで、[**Window.SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br209055) イベントが発生したときに応答するようにしています。</span><span class="sxs-lookup"><span data-stu-id="c94e0-172">This code responds when a [**Window.SizeChanged**](https://msdn.microsoft.com/library/windows/apps/br209055) event occurs by capturing the new coordinates and repositioning the image.</span></span> <span data-ttu-id="c94e0-173">追加スプラッシュ画面にプログレス コントロールを追加した場合は、同様に、このイベント ハンドラー内でそのコントロールを配置し直すようにします。</span><span class="sxs-lookup"><span data-stu-id="c94e0-173">If you added a progress control to your extended splash screen, reposition it inside this event handler as well.</span></span>

    ```cs
    void ExtendedSplash_OnResize(Object sender, WindowSizeChangedEventArgs e)
    {
        // Safely update the extended splash screen image coordinates. This function will be executed when a user resizes the window.
        if (splash != null)
        {
            // Update the coordinates of the splash screen image.
            splashImageRect = splash.ImageLocation;
            PositionImage();

            // If applicable, include a method for positioning a progress control.
            // PositionRing();
        }
    }
    ```

    > [!NOTE]
    > <span data-ttu-id="c94e0-174">取得しようとする前に、イメージの場所を確認クラス変数 (`splash`) の例に示すように、有効な[**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763)オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c94e0-174">Before you try to get the image location make sure the class variable (`splash`) contains a valid [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) object, as shown in the example.</span></span>

     

8.  **<span data-ttu-id="c94e0-175">(省略可能) クラス メソッドを追加して保存済みのセッション状態を復元する</span><span class="sxs-lookup"><span data-stu-id="c94e0-175">(Optional) Add a class method to restore a saved session state</span></span>**

    <span data-ttu-id="c94e0-176">手順 4「[起動アクティブ化ハンドラーの変更](#modify-the-launch-activation-handler)」で [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドに追加したコードにより、アプリでは起動時に追加スプラッシュ画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-176">The code you added to the [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method in Step 4: [Modify the launch activation handler](#modify-the-launch-activation-handler) causes your app to display an extended splash screen when it launches.</span></span> <span data-ttu-id="c94e0-177">追加スプラッシュ画面クラスにアプリの起動に関連するすべてのメソッドを統合するには、ExtendedSplash.xaml.cs ファイルに、アプリの状態を復元するメソッドを追加することを検討する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c94e0-177">To consolidate all methods related to app launch in your extended splash screen class, you could consider adding a method to your ExtendedSplash.xaml.cs file to restore the app's state.</span></span>

    ```cs
    void RestoreState(bool loadState)
    {
        if (loadState)
        {
             // code to load your app's state here
        }
    }
    ```

    <span data-ttu-id="c94e0-178">App.xaml.cs ファイルで起動アクティブ化ハンドラーを変更するときは、アプリの以前の [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) が **Terminated** だった場合にも `loadstate` を true に設定します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-178">When you modify the launch activation handler in App.xaml.cs, you'll also set `loadstate` to true if the previous [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) of your app was **Terminated**.</span></span> <span data-ttu-id="c94e0-179">その場合、`RestoreState` メソッドは、アプリを前の状態に復元します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-179">If so, the `RestoreState` method restores the app to its previous state.</span></span> <span data-ttu-id="c94e0-180">アプリの起動、中断、終了の概要については、「[アプリのライフサイクル](app-lifecycle.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c94e0-180">For an overview of app launch, suspension, and termination, see [App lifecycle](app-lifecycle.md).</span></span>

## <a name="modify-the-launch-activation-handler"></a><span data-ttu-id="c94e0-181">起動アクティブ化ハンドラーの変更</span><span class="sxs-lookup"><span data-stu-id="c94e0-181">Modify the launch activation handler</span></span>


<span data-ttu-id="c94e0-182">アプリが起動されるとき、スプラッシュ画面の情報がアプリの起動アクティブ化イベント ハンドラーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-182">When your app is launched, the system passes splash screen information to the app's launch activation event handler.</span></span> <span data-ttu-id="c94e0-183">この情報を使って、追加スプラッシュ画面ページにイメージを適切に配置できます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-183">You can use this information to correctly position the image on your extended splash screen page.</span></span> <span data-ttu-id="c94e0-184">このスプラッシュ画面の情報は、アプリの [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) ハンドラーに渡されるアクティブ化イベント引数から取得できます (次のコードの `args` 変数を参照)。</span><span class="sxs-lookup"><span data-stu-id="c94e0-184">You can get this splash screen information from the activation event arguments that are passed to your app's [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) handler (see the `args` variable in the following code).</span></span>

<span data-ttu-id="c94e0-185">アプリの [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) ハンドラーをまだオーバーライドしていない場合、アクティブ化イベントを処理する方法については、「[アプリのライフサイクル](app-lifecycle.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c94e0-185">If you have not already overridden the [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) handler for your app, see [App lifecycle](app-lifecycle.md) to learn how to handle activation events.</span></span>

<span data-ttu-id="c94e0-186">App.xaml.cs ファイルで、追加スプラッシュ画面を作成して表示する次のコードを挿入します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-186">In App.xaml.cs, add the following code to create and display an extended splash screen.</span></span>

```cs
protected override void OnLaunched(LaunchActivatedEventArgs args)
{
    if (args.PreviousExecutionState != ApplicationExecutionState.Running)
    {
        bool loadState = (args.PreviousExecutionState == ApplicationExecutionState.Terminated);
        ExtendedSplash extendedSplash = new ExtendedSplash(args.SplashScreen, loadState);
        Window.Current.Content = extendedSplash;
    }

    Window.Current.Activate();
}
```

## <a name="complete-code"></a><span data-ttu-id="c94e0-187">コードを完成させる</span><span class="sxs-lookup"><span data-stu-id="c94e0-187">Complete code</span></span>

<span data-ttu-id="c94e0-188">次のコードは、前の手順に示したスニペットと若干異なります。</span><span class="sxs-lookup"><span data-stu-id="c94e0-188">The following code slightly differs from the snippets shown in the previous steps.</span></span>
-   <span data-ttu-id="c94e0-189">ExtendedSplash.xaml には `DismissSplash` ボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c94e0-189">ExtendedSplash.xaml includes a `DismissSplash` button.</span></span> <span data-ttu-id="c94e0-190">このボタンがクリックされると、イベント ハンドラーである `DismissSplashButton_Click` が `DismissExtendedSplash` メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-190">When this button is clicked, an event handler, `DismissSplashButton_Click`, calls the `DismissExtendedSplash` method.</span></span> <span data-ttu-id="c94e0-191">アプリで、リソースの読み込みまたは UI の初期化の完了時に `DismissExtendedSplash` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-191">In your app, call `DismissExtendedSplash` when your app is done loading resources or initializing its UI.</span></span>
-   <span data-ttu-id="c94e0-192">このアプリは、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) ナビゲーションを使う、UWP アプリのプロジェクト テンプレートも使います。</span><span class="sxs-lookup"><span data-stu-id="c94e0-192">This app also uses a UWP app project template, which uses [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) navigation.</span></span> <span data-ttu-id="c94e0-193">その結果、App.xaml.cs ファイルで、起動アクティブ化ハンドラー ([**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335)) は `rootFrame` を定義し、それを使ってアプリのウィンドウのコンテンツを設定します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-193">As a result, in App.xaml.cs, the launch activation handler ([**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335)) defines a `rootFrame` and uses it to set the content of the app window.</span></span>

### <a name="extendedsplashxaml"></a><span data-ttu-id="c94e0-194">ExtendedSplash.xaml</span><span class="sxs-lookup"><span data-stu-id="c94e0-194">ExtendedSplash.xaml</span></span>

<span data-ttu-id="c94e0-195">この例に含まれる、`DismissSplash`ボタンをアプリのリソースを読み込むことがあるないためです。</span><span class="sxs-lookup"><span data-stu-id="c94e0-195">This example includes a `DismissSplash` button because it doesn't have app resources to load.</span></span> <span data-ttu-id="c94e0-196">アプリでは、リソースの読み込みまたはその最初の UI の準備の完了時に追加スプラッシュ画面が自動的に閉じられます。</span><span class="sxs-lookup"><span data-stu-id="c94e0-196">In your app, dismiss the extended splash screen automatically when your app is done loading resources or preparing its initial UI.</span></span>

```xml
<Page
    x:Class="SplashScreenExample.ExtendedSplash"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:SplashScreenExample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="#464646">
        <Canvas>
            <Image x:Name="extendedSplashImage" Source="Assets/SplashScreen.png"/>
            <ProgressRing Name="splashProgressRing" IsActive="True" Width="20" HorizontalAlignment="Center"/>
        </Canvas>
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Bottom">
            <Button x:Name="DismissSplash" Content="Dismiss extended splash screen" HorizontalAlignment="Center" Click="DismissSplashButton_Click" />
        </StackPanel>
    </Grid>
</Page>
```

### <a name="extendedsplashxamlcs"></a><span data-ttu-id="c94e0-197">ExtendedSplash.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="c94e0-197">ExtendedSplash.xaml.cs</span></span>

<span data-ttu-id="c94e0-198">なお、`DismissExtendedSplash`のクリック イベント ハンドラーからメソッドが呼び出されます、`DismissSplash`ボタン。</span><span class="sxs-lookup"><span data-stu-id="c94e0-198">Note that the `DismissExtendedSplash` method is called from the click event handler for the `DismissSplash` button.</span></span> <span data-ttu-id="c94e0-199">アプリでは、`DismissSplash` ボタンは不要です。</span><span class="sxs-lookup"><span data-stu-id="c94e0-199">In your app, you won't need a `DismissSplash` button.</span></span> <span data-ttu-id="c94e0-200">その代わりに、アプリがリソースの読み込みの完了時に `DismissExtendedSplash` を呼び出し、そのメイン ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-200">Instead, call `DismissExtendedSplash` when your app is done loading resources and you want to navigate to its main page.</span></span>

```cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.ApplicationModel.Activation;
using SplashScreenExample.Common;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/p/?LinkID=234238

namespace SplashScreenExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    partial class ExtendedSplash : Page
    {
        internal Rect splashImageRect; // Rect to store splash screen image coordinates.
        private SplashScreen splash; // Variable to hold the splash screen object.
        internal bool dismissed = false; // Variable to track splash screen dismissal status.
        internal Frame rootFrame;

        public ExtendedSplash(SplashScreen splashscreen, bool loadState)
        {
            InitializeComponent();

            // Listen for window resize events to reposition the extended splash screen image accordingly.
            // This is important to ensure that the extended splash screen is formatted properly in response to snapping, unsnapping, rotation, etc...
            Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

            splash = splashscreen;

            if (splash != null)
            {
                // Register an event handler to be executed when the splash screen has been dismissed.
                splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(DismissedEventHandler);

                // Retrieve the window coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();

                // Optional: Add a progress ring to your splash screen to show users that content is loading
                PositionRing();
            }

            // Create a Frame to act as the navigation context
            rootFrame = new Frame();

            // Restore the saved session state if necessary
            RestoreState(loadState);
        }

        void RestoreState(bool loadState)
        {
            if (loadState)
            {
                // TODO: write code to load state
            }
        }

        // Position the extended splash screen image in the same location as the system splash screen image.
        void PositionImage()
        {
            extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X);
            extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y);
            extendedSplashImage.Height = splashImageRect.Height;
            extendedSplashImage.Width = splashImageRect.Width;

        }

        void PositionRing()
        {
            splashProgressRing.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width*0.5) - (splashProgressRing.Width*0.5));
            splashProgressRing.SetValue(Canvas.TopProperty, (splashImageRect.Y + splashImageRect.Height + splashImageRect.Height*0.1));
        }

        void ExtendedSplash_OnResize(Object sender, WindowSizeChangedEventArgs e)
        {
            // Safely update the extended splash screen image coordinates. This function will be fired in response to snapping, unsnapping, rotation, etc...
            if (splash != null)
            {
                // Update the coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();
                PositionRing();
            }
        }

        // Include code to be executed when the system has transitioned from the splash screen to the extended splash screen (application's first view).
        void DismissedEventHandler(SplashScreen sender, object e)
        {
            dismissed = true;

            // Complete app setup operations here...
        }

        void DismissExtendedSplash()
        {
            // Navigate to mainpage
            rootFrame.Navigate(typeof(MainPage));
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        void DismissSplashButton_Click(object sender, RoutedEventArgs e)
        {
            DismissExtendedSplash();
        }
    }
}
```

### <a name="appxamlcs"></a><span data-ttu-id="c94e0-201">App.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="c94e0-201">App.xaml.cs</span></span>

<span data-ttu-id="c94e0-202">このプロジェクトは、Visual Studio で UWP アプリの**空白のアプリ (XAML)** のプロジェクト テンプレートを使用して作成されました。</span><span class="sxs-lookup"><span data-stu-id="c94e0-202">This project was created using the UWP app **Blank App (XAML)** project template in Visual Studio.</span></span> <span data-ttu-id="c94e0-203">`OnNavigationFailed` と `OnSuspending` の両方のイベント ハンドラーは自動的に生成され、追加スプラッシュ画面を実装するために変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c94e0-203">Both the `OnNavigationFailed` and `OnSuspending` event handlers are automatically generated and don't need to be changed to implement an extended splash screen.</span></span> <span data-ttu-id="c94e0-204">このトピックでは、`OnLaunched` のみを変更します。</span><span class="sxs-lookup"><span data-stu-id="c94e0-204">This topic only modifies `OnLaunched`.</span></span>

<span data-ttu-id="c94e0-205">アプリにプロジェクト テンプレートを使わなかった場合、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) ナビゲーションを使用しないように変更した `OnLaunched` の例については、手順 4「[起動アクティブ化ハンドラーの変更](#modify-the-launch-activation-handler)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c94e0-205">If you didn't use a project template for your app, see Step 4: [Modify the launch activation handler](#modify-the-launch-activation-handler) for an example of a modified `OnLaunched` that doesn't use [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) navigation.</span></span>

```cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/p/?LinkID=234227

namespace SplashScreenExample
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
            Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
            Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                //  Display an extended splash screen if app was not previously running.
                if (e.PreviousExecutionState != ApplicationExecutionState.Running)
                {
                    bool loadState = (e.PreviousExecutionState == ApplicationExecutionState.Terminated);
                    ExtendedSplash extendedSplash = new ExtendedSplash(e.SplashScreen, loadState);
                    rootFrame.Content = extendedSplash;
                    Window.Current.Content = rootFrame;
                }
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // TODO: Save applicaiton state and stop any background activity
            deferral.Complete();
        }
    }
}
```

## <a name="related-topics"></a><span data-ttu-id="c94e0-206">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c94e0-206">Related topics</span></span>


* [<span data-ttu-id="c94e0-207">アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="c94e0-207">App lifecycle</span></span>](app-lifecycle.md)

**<span data-ttu-id="c94e0-208">リファレンス</span><span class="sxs-lookup"><span data-stu-id="c94e0-208">Reference</span></span>**

* [**<span data-ttu-id="c94e0-209">Windows.ApplicationModel.Activation 名前空間</span><span class="sxs-lookup"><span data-stu-id="c94e0-209">Windows.ApplicationModel.Activation namespace</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224766)
* [**<span data-ttu-id="c94e0-210">Windows.ApplicationModel.Activation.SplashScreen クラス</span><span class="sxs-lookup"><span data-stu-id="c94e0-210">Windows.ApplicationModel.Activation.SplashScreen class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224763)
* [**<span data-ttu-id="c94e0-211">Windows.ApplicationModel.Activation.SplashScreen.ImageLocation プロパティ</span><span class="sxs-lookup"><span data-stu-id="c94e0-211">Windows.ApplicationModel.Activation.SplashScreen.ImageLocation property</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224765)
* [**<span data-ttu-id="c94e0-212">Windows.ApplicationModel.Core.CoreApplicationView.Activated イベント</span><span class="sxs-lookup"><span data-stu-id="c94e0-212">Windows.ApplicationModel.Core.CoreApplicationView.Activated event</span></span>**](https://msdn.microsoft.com/library/windows/apps/br225018)

 

 
