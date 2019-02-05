---
title: ナビゲーションの概要
description: ナビゲーションの概要
ms.assetid: F4DF5C5F-C886-4483-BBDA-498C4E2C1BAF
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 682a743e45626939242af963fba47ca82a13a90e
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9048509"
---
# <a name="getting-started-navigation"></a><span data-ttu-id="a73d9-104">はじめに: ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="a73d9-104">Getting started: Navigation</span></span>


## <a name="adding-navigation"></a><span data-ttu-id="a73d9-105">ナビゲーションの追加</span><span class="sxs-lookup"><span data-stu-id="a73d9-105">Adding navigation</span></span>

<span data-ttu-id="a73d9-106">iOS では、アプリのナビゲーション用に **UINavigationController** クラスが用意されています。ビューのプッシュ/ポップ操作を通じて、アプリを定義する **UIViewControllers** の階層を作ることができます。</span><span class="sxs-lookup"><span data-stu-id="a73d9-106">iOS provides the **UINavigationController** class to help with in-app navigation: you can push and pop views to create the hierarchy of **UIViewControllers** that define your app.</span></span>

<span data-ttu-id="a73d9-107">これに対し、複数のビューを含む windows 10 アプリには、web サイト アプローチのナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="a73d9-107">In contrast, a Windows10 app containing multiple views takes more of a web-site approach to navigation.</span></span> <span data-ttu-id="a73d9-108">ユーザーがコントロールをクリックしてページ間を移動し、アプリ内を進むことを考えてみることができます。</span><span class="sxs-lookup"><span data-stu-id="a73d9-108">You can imagine your users hopping from page to page as they click on controls to work their way through the app.</span></span> <span data-ttu-id="a73d9-109">詳しくは、「[ナビゲーション デザインの基本](https://msdn.microsoft.com/library/windows/apps/dn958438)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a73d9-109">For more info, see [Navigation design basics](https://msdn.microsoft.com/library/windows/apps/dn958438).</span></span>

<span data-ttu-id="a73d9-110">Windows 10 アプリでこのナビゲーションを管理する方法の 1 つは、[**フレーム**](https://msdn.microsoft.com/library/windows/apps/br242682)クラスを使用します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-110">One of the ways to manage this navigation in a Windows10 app is to use the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) class.</span></span> <span data-ttu-id="a73d9-111">以下のチュートリアルでは実際に試す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a73d9-111">The following walkthrough shows you how to try this out.</span></span>

<span data-ttu-id="a73d9-112">以前に開始したソリューションに戻り、**MainPage.xaml** ファイルを開いて、**[デザイン]** ビューにボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-112">Continuing with the solution you started earlier, open the **MainPage.xaml** file, and add a button in the **Design** view.</span></span> <span data-ttu-id="a73d9-113">このボタンの **Content** プロパティを "Button" から "Go To Page" に変更します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-113">Change the button's **Content** property from "Button" to "Go To Page".</span></span> <span data-ttu-id="a73d9-114">次に、ボタンの **Click** イベントのハンドラーを、次の図に示すように作成します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-114">Then, create a handler for the button's **Click** event, as shown in the following figure.</span></span> <span data-ttu-id="a73d9-115">作成方法がわからない場合は、前のセクションのチュートリアルを見直してください (ヒント: **[デザイン]** ビューにあるボタンをダブルクリックします)。</span><span class="sxs-lookup"><span data-stu-id="a73d9-115">If you don't remember how to do this, review the walkthrough in the previous section (Hint: double-click the button in the **Design** view).</span></span>

![Visual Studio でのボタンとそのクリック イベントの追加](images/ios-to-uwp/vs-go-to-page.png)

<span data-ttu-id="a73d9-117">新しいページを追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="a73d9-117">Let's add a new page.</span></span> <span data-ttu-id="a73d9-118">**[ソリューション]** ビューで、**[プロジェクト]** メニュー、**[新しい項目の追加]** の順にタップします。</span><span class="sxs-lookup"><span data-stu-id="a73d9-118">In the **Solution** view, tap the **Project** menu, and tap **Add New Item**.</span></span> <span data-ttu-id="a73d9-119">次の図に示すように、**[空白のページ]** をタップし、**[追加]** をタップします。</span><span class="sxs-lookup"><span data-stu-id="a73d9-119">Tap **Blank Page** as shown in the following figure, and then tap **Add**.</span></span>

![Visual Studio での新しいページの追加](images/ios-to-uwp/vs-add-new-page.png)

<span data-ttu-id="a73d9-121">次に、BlankPage.xaml ファイルにボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-121">Next, add a button to the BlankPage.xaml file.</span></span> <span data-ttu-id="a73d9-122">ここでは、AppBarButton コントロールを使い、ボタンに "前に戻る矢印" の画像を設定します。**[XAML]** ビューで、` <AppBarButton Icon="Back"/>` を `<Grid> </Grid>` 要素の間に追加します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-122">Let's use the AppBarButton control, and let's give it a back arrow image: in the **XAML** view, add ` <AppBarButton Icon="Back"/>` between the `<Grid> </Grid>` elements.</span></span>

<span data-ttu-id="a73d9-123">次に、ボタンにイベント ハンドラー追加します。**[デザイン]** ビュー内のコントロールをダブルクリックすると、次の図に示すように、Microsoft Visual Studio によってテキスト "AppBarButton\_Click" が **[Click]** ボックスに追加されます。続いて、対応するイベント ハンドラーが BlankPage.xaml.cs ファイルに追加され、表示されます。</span><span class="sxs-lookup"><span data-stu-id="a73d9-123">Now, let's add an event handler to the button: double-click the control in the **Design** view and Microsoft Visual Studio adds the text "AppBarButton\_Click" to the **Click** box, as shown in the following figure, and then adds and displays the corresponding event handler in the BlankPage.xaml.cs file.</span></span>

![Visual Studio での戻るボタンとそのクリック イベントの追加](images/ios-to-uwp/vs-add-back-button.png)

<span data-ttu-id="a73d9-125">BlankPage.xaml ファイルの **XAML** ビューに戻り、`<AppBarButton>` 要素の Extensible Application Markup Language (XAML) コードが次のようになっていることを確かめます。</span><span class="sxs-lookup"><span data-stu-id="a73d9-125">If you return to the BlankPage.xaml file's **XAML** view, the `<AppBarButton>` element's Extensible Application Markup Language (XAML) code should now look like this:</span></span>

` <AppBarButton Icon="Back" Click="AppBarButton_Click"/>`

<span data-ttu-id="a73d9-126">BlankPage.xaml.cs ファイルに戻り、以下のコードを追加して、ユーザーがボタンをタップすると前のページに戻るようにします。</span><span class="sxs-lookup"><span data-stu-id="a73d9-126">Return to the BlankPage.xaml.cs file, and add this code to go to the previous page after the user taps the button.</span></span>

```csharp
private void AppBarButton_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.    
    Frame.GoBack();
}
```

<span data-ttu-id="a73d9-127">最後に、MainPage.xaml.cs ファイルを開き、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-127">Finally, open the MainPage.xaml.cs file and add this code.</span></span> <span data-ttu-id="a73d9-128">このコードは、ユーザーがボタンをタップしたときに BlankPage を開くためのコードです。</span><span class="sxs-lookup"><span data-stu-id="a73d9-128">It opens BlankPage after the user taps the button.</span></span>

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.
    Frame.Navigate(typeof(BlankPage1));
}
```

<span data-ttu-id="a73d9-129">それでは、プログラムを実行してみましょう。</span><span class="sxs-lookup"><span data-stu-id="a73d9-129">Now, run the program.</span></span> <span data-ttu-id="a73d9-130">[Go To Page] ボタンをタップすると、他のページに進みます。矢印スタイルの戻るボタンをタップすると、前のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="a73d9-130">Tap the "Go To Page" button to go to the other page, and then tap the back-arrow button to return to the previous page.</span></span>

<span data-ttu-id="a73d9-131">ページのナビゲーションは、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラスによって管理されます。</span><span class="sxs-lookup"><span data-stu-id="a73d9-131">Page navigation is managed by the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) class.</span></span> <span data-ttu-id="a73d9-132">IOS で**UINavigationController**クラスは、 **pushViewController**および**popViewController**メソッドを使用するいると、UWP アプリの**フレーム**クラスは、[**移動**](https://msdn.microsoft.com/library/windows/apps/br242694)と[**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568)メソッドを提供します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-132">As the **UINavigationController** class in iOS uses **pushViewController** and **popViewController** methods, the **Frame** class for UWP apps provides [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) and [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568) methods.</span></span> <span data-ttu-id="a73d9-133">**Frame** クラスには、名前から推測されるとおりに動作する [**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693) というメソッドもあります。</span><span class="sxs-lookup"><span data-stu-id="a73d9-133">The **Frame** class also has a method called [**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693), which does what you might expect.</span></span>

<span data-ttu-id="a73d9-134">このチュートリアルでは、ナビゲーションを行うたびに BlankPage の新しいインスタンスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="a73d9-134">This walkthrough creates a new instance of BlankPage each time you navigate to it.</span></span> <span data-ttu-id="a73d9-135">(前のインスタンスは自動的に*解放*されます)。</span><span class="sxs-lookup"><span data-stu-id="a73d9-135">(The previous instance will be freed, or *released*, automatically).</span></span> <span data-ttu-id="a73d9-136">毎回新しいインスタンスが作成されることがないようにするには、BlankPage.xaml.cs ファイル内の BlankPage クラスのコンストラクターに以下のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-136">If you don't want a new instance to be created each time, add the following code to the BlankPage class's constructor in the BlankPage.xaml.cs file.</span></span> <span data-ttu-id="a73d9-137">これにより、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) 動作が有効になります。</span><span class="sxs-lookup"><span data-stu-id="a73d9-137">This will enable the [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) behavior.</span></span>

```csharp
public BlankPage()
{
    this.InitializeComponent();
    // Add the following line of code.
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```

<span data-ttu-id="a73d9-138">また、**Frame** クラスの [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) プロパティを取得または設定すると、キャッシュするナビゲーションの履歴のページ数を管理できます。</span><span class="sxs-lookup"><span data-stu-id="a73d9-138">You can also get or set the **Frame** class's [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) property to manage how many pages in the navigation history can be cached.</span></span>

<span data-ttu-id="a73d9-139">ナビゲーションについて詳しくは、「[ナビゲーション](https://msdn.microsoft.com/library/windows/apps/mt187344)」と「[XAML パーソナリティ アニメーションのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=242401)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a73d9-139">For more info about navigation, see [Navigation](https://msdn.microsoft.com/library/windows/apps/mt187344) and [XAML personality animations sample](https://go.microsoft.com/fwlink/p/?LinkID=242401).</span></span>

<span data-ttu-id="a73d9-140">**注:** JavaScript と HTML を使った UWP アプリのナビゲーションについて詳しくは、次を参照してください。[クイック スタート: 単一ページのナビゲーションを使用して](https://msdn.microsoft.com/library/windows/apps/hh452768)します。</span><span class="sxs-lookup"><span data-stu-id="a73d9-140">**Note**For info about navigation for UWP apps using JavaScript and HTML, see [Quickstart: Using single-page navigation](https://msdn.microsoft.com/library/windows/apps/hh452768).</span></span>
 
### <a name="next-step"></a><span data-ttu-id="a73d9-141">次のステップ</span><span class="sxs-lookup"><span data-stu-id="a73d9-141">Next step</span></span>

[<span data-ttu-id="a73d9-142">はじめに: アニメーション</span><span class="sxs-lookup"><span data-stu-id="a73d9-142">Getting started: Animation</span></span>](getting-started-animation.md)

