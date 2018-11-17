---
author: Jwmsft
Description: Learn how to enable peer-to-peer navigation between two basic pages in an Universal Windows Platform (UWP) app.
title: 2 ページ間でのピア ツー ピアのナビゲーション
ms.assetid: 0A364C8B-715F-4407-9426-92267E8FB525
label: Peer-to-peer navigation between two pages
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 07/13/2018
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 91a1ca0ee99833280aaa41ca4d9c94d043a78e0a
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7152221"
---
# <a name="implement-navigation-between-two-pages"></a><span data-ttu-id="f4135-103">2 ページ間でのナビゲーションを実装する</span><span class="sxs-lookup"><span data-stu-id="f4135-103">Implement navigation between two pages</span></span>

<span data-ttu-id="f4135-104">フレームおよびページを使用した、アプリでの基本的なピア ツー ピアのナビゲーションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="f4135-104">Learn how to use a frame and pages to enable basic peer-to-peer navigation in your app.</span></span> 

> <span data-ttu-id="f4135-105">**重要な APIs**: [**Windows.UI.Xaml.Controls.Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラス、[**Windows.UI.Xaml.Controls.Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラス、[**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300) 名前空間</span><span class="sxs-lookup"><span data-stu-id="f4135-105">**Important APIs**: [**Windows.UI.Xaml.Controls.Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) class, [**Windows.UI.Xaml.Controls.Page**](https://msdn.microsoft.com/library/windows/apps/br227503) class, [**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300) namespace</span></span>

![ピア ツー ピアのナビゲーション](images/peertopeer.png)

## <a name="1-create-a-blank-app"></a><span data-ttu-id="f4135-107">1. 空のアプリの作成</span><span class="sxs-lookup"><span data-stu-id="f4135-107">1. Create a blank app</span></span>

1.  <span data-ttu-id="f4135-108">Microsoft Visual Studio のメニューで、**[ファイル]** > **[新しいプロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-108">On the Microsoft Visual Studio menu, choose **File** > **New Project**.</span></span>
2.  <span data-ttu-id="f4135-109">**[新しいプロジェクト]** ダイアログ ボックスの左側のウィンドウで、**[Visual C#]** > **[Windows]** > **[ユニバーサル]** ノード、または **[Visual C++]** > **[Windows]** > **[ユニバーサル]** ノードの順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-109">In the left pane of the **New Project** dialog box, choose the **Visual C#** > **Windows** > **Universal** or the **Visual C++** > **Windows** > **Universal** node.</span></span>
3.  <span data-ttu-id="f4135-110">中央のウィンドウで、**[空のアプリケーション]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-110">In the center pane, choose **Blank App**.</span></span>
4.  <span data-ttu-id="f4135-111">**[名前]** ボックスに「**NavApp1**」と入力し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-111">In the **Name** box, enter **NavApp1**, and then choose the **OK** button.</span></span>
    <span data-ttu-id="f4135-112">ソリューションが作られ、プロジェクト ファイルが**ソリューション エクスプローラー**に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-112">The solution is created, and the project files appear in **Solution Explorer**.</span></span>
5.  <span data-ttu-id="f4135-113">プログラムを実行するには、メニューから **[デバッグ]** > **[デバッグの開始]** の順にクリックするか、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f4135-113">To run the program, choose **Debug** > **Start Debugging** from the menu, or press F5.</span></span>
    <span data-ttu-id="f4135-114">空白のページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-114">A blank page is displayed.</span></span>
6.  <span data-ttu-id="f4135-115">デバッグを終了して Visual Studio に戻るには、アプリを終了するか、メニューから **[デバッグの停止]** クリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-115">To stop debugging and return to Visual Studio, exit the app, or click **Stop Debugging** from the menu.</span></span>

## <a name="2-add-basic-pages"></a><span data-ttu-id="f4135-116">2. 基本ページの追加</span><span class="sxs-lookup"><span data-stu-id="f4135-116">2. Add basic pages</span></span>

<span data-ttu-id="f4135-117">次に、プロジェクトにページを 2 つ追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-117">Next, add two pages to the project.</span></span>

1.  <span data-ttu-id="f4135-118">**ソリューション エクスプローラー**で、**[BlankApp]** プロジェクト ノードを右クリックして、ショートカット メニューを開きます。</span><span class="sxs-lookup"><span data-stu-id="f4135-118">In **Solution Explorer**, right-click the **BlankApp** project node to open the shortcut menu.</span></span>
2.  <span data-ttu-id="f4135-119">ショートカット メニューから **[追加]** > **[新しい項目]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-119">Choose **Add** > **New Item** from the shortcut menu.</span></span>
3.  <span data-ttu-id="f4135-120">**[新しい項目の追加]** ダイアログ ボックスの中央のウィンドウで、**[空白のページ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-120">In the **Add New Item** dialog box, choose **Blank Page** in the middle pane.</span></span>
4.  <span data-ttu-id="f4135-121">**[名前]** ボックスに「**Page1**」(または「**Page2**」) と入力し、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-121">In the **Name** box, enter **Page1** (or **Page2**) and press the **Add** button.</span></span>
5. <span data-ttu-id="f4135-122">手順 1 ～ 4 を繰り返して、2 つ目のページを追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-122">Repeat steps 1-4 to add the second page.</span></span>

<span data-ttu-id="f4135-123">これで、NavApp1 プロジェクトの一部としてこれらのファイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-123">Now, these files should be listed as part of your NavApp1 project.</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f4135-124">C#</span><span class="sxs-lookup"><span data-stu-id="f4135-124">C#</span></span></th>
<th align="left"><span data-ttu-id="f4135-125">C++</span><span class="sxs-lookup"><span data-stu-id="f4135-125">C++</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><ul>
<li><span data-ttu-id="f4135-126">Page1.xaml</span><span class="sxs-lookup"><span data-stu-id="f4135-126">Page1.xaml</span></span></li>
<li><span data-ttu-id="f4135-127">Page1.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="f4135-127">Page1.xaml.cs</span></span></li>
<li><span data-ttu-id="f4135-128">Page2.xaml</span><span class="sxs-lookup"><span data-stu-id="f4135-128">Page2.xaml</span></span></li>
<li><span data-ttu-id="f4135-129">Page2.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="f4135-129">Page2.xaml.cs</span></span></li>
</ul></td>
<td style="vertical-align:top;"><ul>
<li><span data-ttu-id="f4135-130">Page1.xaml</span><span class="sxs-lookup"><span data-stu-id="f4135-130">Page1.xaml</span></span></li>
<li><span data-ttu-id="f4135-131">Page1.xaml.cpp</span><span class="sxs-lookup"><span data-stu-id="f4135-131">Page1.xaml.cpp</span></span></li>
<li><span data-ttu-id="f4135-132">Page1.xaml.h</span><span class="sxs-lookup"><span data-stu-id="f4135-132">Page1.xaml.h</span></span></li>
<li><span data-ttu-id="f4135-133">Page2.xaml</span><span class="sxs-lookup"><span data-stu-id="f4135-133">Page2.xaml</span></span></li>
<li><span data-ttu-id="f4135-134">Page2.xaml.cpp</span><span class="sxs-lookup"><span data-stu-id="f4135-134">Page2.xaml.cpp</span></span></li>
<li><span data-ttu-id="f4135-135">Page2.xaml.h</span><span class="sxs-lookup"><span data-stu-id="f4135-135">Page2.xaml.h</span></span>

</li>
</ul></td>
</tr>
</tbody>
</table>

<span data-ttu-id="f4135-136">Page1.xaml に次のコンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-136">In Page1.xaml, add the following content:</span></span>

-   <span data-ttu-id="f4135-137">`pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-137">A [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element named `pageTitle` as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704).</span></span> <span data-ttu-id="f4135-138">[**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティを `Page 1` に変更します。</span><span class="sxs-lookup"><span data-stu-id="f4135-138">Change the [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) property to `Page 1`.</span></span>
```xaml
<TextBlock x:Name="pageTitle" Text="Page 1" />
```

-   <span data-ttu-id="f4135-139">[**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739)要素をルート[**グリッド**](https://msdn.microsoft.com/library/windows/apps/br242704)の前後の子要素として、 `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652)要素です。</span><span class="sxs-lookup"><span data-stu-id="f4135-139">A [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) element as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) and after the `pageTitle`[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element.</span></span>
```xaml
<HyperlinkButton Content="Click to go to page 2"
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

<span data-ttu-id="f4135-140">Page1.xaml 分離コード ファイルに、Page2.xaml に移動するために追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-140">In the Page1.xaml code-behind file, add the following code to handle the `Click` event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added to navigate to Page2.xaml.</span></span>

```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2));
}
```

```cppwinrt
void Page1::HyperlinkButton_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args)
{
    Frame().Navigate(winrt::xaml_typename<NavApp1::Page2>());
}
```

```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid));
}
```

<span data-ttu-id="f4135-141">Page2.xaml に次のコンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-141">In Page2.xaml, add the following content:</span></span>

-   <span data-ttu-id="f4135-142">`pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-142">A [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element named `pageTitle` as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704).</span></span> <span data-ttu-id="f4135-143">[**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティの値を `Page 2` に変更します。</span><span class="sxs-lookup"><span data-stu-id="f4135-143">Change the value of the [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) property to `Page 2`.</span></span>
```xaml
<TextBlock x:Name="pageTitle" Text="Page 2" />
```

-   <span data-ttu-id="f4135-144">[**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739)要素をルート[**グリッド**](https://msdn.microsoft.com/library/windows/apps/br242704)の前後の子要素として、 `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652)要素です。</span><span class="sxs-lookup"><span data-stu-id="f4135-144">A [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) element as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) and after the `pageTitle`[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element.</span></span>
```xaml
<HyperlinkButton Content="Click to go to page 1" 
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

<span data-ttu-id="f4135-145">Page2.xaml 分離コード ファイルに、Page1.xaml に移動するための [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-145">In the Page2.xaml code-behind file, add the following code to handle the `Click` event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) to navigate to Page1.xaml.</span></span>

```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page1));
}
```

```cppwinrt
void Page2::HyperlinkButton_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args)
{
    Frame().Navigate(winrt::xaml_typename<NavApp1::Page1>());
}
```

```cpp
void Page2::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid));
}
```

> [!NOTE]
> <span data-ttu-id="f4135-146">C++ プロジェクトの場合は、別のページを参照する各ページのヘッダー ファイルに `#include` ディレクティブを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4135-146">For C++ projects, you must add a `#include` directive in the header file of each page that references another page.</span></span> <span data-ttu-id="f4135-147">ここで示したページ間のナビゲーションの例では、page1.xaml.h ファイルに `#include "Page2.xaml.h"` が、page2.xaml.h に `#include "Page1.xaml.h"` が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f4135-147">For the inter-page navigation example presented here, page1.xaml.h file contains `#include "Page2.xaml.h"`, in turn, page2.xaml.h contains `#include "Page1.xaml.h"`.</span></span>

<span data-ttu-id="f4135-148">ページが用意できたら、Page1.xaml をアプリの開始時に表示されるように設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4135-148">Now that we've prepared the pages, we need to make Page1.xaml display when the app starts.</span></span>

<span data-ttu-id="f4135-149">App.xaml 分離コードファイルを開き、`OnLaunched` ハンドラーを変更します。</span><span class="sxs-lookup"><span data-stu-id="f4135-149">Open the App.xaml code-behind file and change the `OnLaunched` handler.</span></span>

<span data-ttu-id="f4135-150">次に、[**Frame.Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) の呼び出しに、`MainPage` ではなく `Page1` を追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-150">Here, we specify `Page1` in the call to [**Frame.Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) instead of `MainPage`.</span></span>

```csharp
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;
 
    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();
        rootFrame.NavigationFailed += OnNavigationFailed;
 
        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }
 
        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }
 
    if (rootFrame.Content == null)
    {
        // When the navigation stack isn't restored navigate to the first page,
        // configuring the new page by passing required information as a navigation
        // parameter
        rootFrame.Navigate(typeof(Page1), e.Arguments);
    }
    // Ensure the current window is active
    Window.Current.Activate();
}
```

```cppwinrt
void App::OnLaunched(LaunchActivatedEventArgs const& e)
{
    Frame rootFrame{ nullptr };
    auto content = Window::Current().Content();
    if (content)
    {
        rootFrame = content.try_as<Frame>();
    }

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == nullptr)
    {
        // Create a Frame to act as the navigation context and associate it with
        // a SuspensionManager key
        rootFrame = Frame();

        rootFrame.NavigationFailed({ this, &App::OnNavigationFailed });

        if (e.PreviousExecutionState() == ApplicationExecutionState::Terminated)
        {
            // Restore the saved session state only when appropriate, scheduling the
            // final launch steps after the restore is complete
        }

        if (e.PrelaunchActivated() == false)
        {
            if (rootFrame.Content() == nullptr)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(xaml_typename<NavApp1::Page1>(), box_value(e.Arguments()));
            }
            // Place the frame in the current Window
            Window::Current().Content(rootFrame);
            // Ensure the current window is active
            Window::Current().Activate();
        }
    }
    else
    {
        if (e.PrelaunchActivated() == false)
        {
            if (rootFrame.Content() == nullptr)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(xaml_typename<NavApp1::Page1>(), box_value(e.Arguments()));
            }
            // Ensure the current window is active
            Window::Current().Activate();
        }
    }
}
```

```cpp
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e)
{
    auto rootFrame = dynamic_cast<Frame^>(Window::Current->Content);

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == nullptr)
    {
        // Create a Frame to act as the navigation context and associate it with
        // a SuspensionManager key
        rootFrame = ref new Frame();

        rootFrame->NavigationFailed += 
            ref new Windows::UI::Xaml::Navigation::NavigationFailedEventHandler(
                this, &App::OnNavigationFailed);

        if (e->PreviousExecutionState == ApplicationExecutionState::Terminated)
        {
            // TODO: Load state from previously suspended application
        }
        
        // Place the frame in the current Window
        Window::Current->Content = rootFrame;
    }

    if (rootFrame->Content == nullptr)
    {
        // When the navigation stack isn't restored navigate to the first page,
        // configuring the new page by passing required information as a navigation
        // parameter
        rootFrame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid), e->Arguments);
    }

    // Ensure the current window is active
    Window::Current->Activate();
}
```

> [!NOTE]
> <span data-ttu-id="f4135-151">このコードは、アプリの初期ウィンドウ フレームへのナビゲーションが失敗した場合にアプリの例外をスローするのに[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694)の戻り値を使用します。</span><span class="sxs-lookup"><span data-stu-id="f4135-151">The code here uses the return value of [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) to throw an app exception if the navigation to the app's initial window frame fails.</span></span> <span data-ttu-id="f4135-152">**Navigate** が **true** を返す場合は、ナビゲーションが行われます。</span><span class="sxs-lookup"><span data-stu-id="f4135-152">When **Navigate** returns **true**, the navigation happens.</span></span>

<span data-ttu-id="f4135-153">次に、アプリをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="f4135-153">Now, build and run the app.</span></span> <span data-ttu-id="f4135-154">"Click to go to page 2" と書かれているリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-154">Click the link that says "Click to go to page 2".</span></span> <span data-ttu-id="f4135-155">上部に "Page 2" と書かれた 2 番目のページが読み込まれ、フレームに表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4135-155">The second page that says "Page 2" at the top should be loaded and displayed in the frame.</span></span>

### <a name="about-the-frame-and-page-classes"></a><span data-ttu-id="f4135-156">Frame クラスと Page クラスについて</span><span class="sxs-lookup"><span data-stu-id="f4135-156">About the Frame and Page classes</span></span>

<span data-ttu-id="f4135-157">アプリにさらに機能を加える前に、追加したページに用意されているアプリ内のナビゲーションについて見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f4135-157">Before we add more functionality to our app, let's look at how the pages we added provide navigation within our app.</span></span>

<span data-ttu-id="f4135-158">まず、App.xaml 分離コード ファイルの `App.OnLaunched` メソッドで、アプリの [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) (`rootFrame`) が作成されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-158">First, a [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) called `rootFrame` is created for the app in the `App.OnLaunched` method in the App.xaml code-behind file.</span></span> <span data-ttu-id="f4135-159">**Frame** クラスは、[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694)、[**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568)、[**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693) などのさまざまなナビゲーション メソッドと、[**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543)、[**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547)、[**BackStackDepth**](https://msdn.microsoft.com/library/windows/apps/hh967995) などのプロパティをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="f4135-159">The **Frame** class supports various navigation methods such as [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694), [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568), and [**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693), and properties such as [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543), [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547), and [**BackStackDepth**](https://msdn.microsoft.com/library/windows/apps/hh967995).</span></span>
 
<span data-ttu-id="f4135-160">[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) メソッドを使って、この **Frame** にコンテンツが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-160">The [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) method is used to display content in this **Frame**.</span></span> <span data-ttu-id="f4135-161">既定では、このメソッドは MainPage.xaml を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="f4135-161">By default, this method loads MainPage.xaml.</span></span> <span data-ttu-id="f4135-162">この例では、`Page1` が **Navigate** メソッドに渡されるため、メソッドは **Frame** に `Page1` を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="f4135-162">In our example, `Page1` is passed to the **Navigate** method, so the method loads `Page1` in the **Frame**.</span></span> 

`Page1` <span data-ttu-id="f4135-163"> は [*\*Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラスのサブクラスです。</span><span class="sxs-lookup"><span data-stu-id="f4135-163">is a subclass of the [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) class.</span></span> <span data-ttu-id="f4135-164">**Page** クラスには、**Page** が含まれる **Frame** を取得する読み取り専用の **Frame** プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="f4135-164">The **Page** class has a read-only **Frame** property that gets the **Frame** containing the **Page**.</span></span> <span data-ttu-id="f4135-165">`Page1` で **HyperlinkButton** の **Click** イベント ハンドラーが `this.Frame.Navigate(typeof(Page2))` を呼び出すと、**Frame** に Page2.xaml のコンテンツが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-165">When the **Click** event handler of the **HyperlinkButton** in `Page1` calls `this.Frame.Navigate(typeof(Page2))`, the **Frame** displays the content of Page2.xaml.</span></span>

<span data-ttu-id="f4135-166">最後に、フレームにページが読み込まれるたびに、そのページが [**PageStackEntry**](https://msdn.microsoft.com/library/windows/apps/dn298572) として、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) の [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543) または [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547) に追加され、[履歴と前に戻る移動](navigation-history-and-backwards-navigation.md)が可能になります。</span><span class="sxs-lookup"><span data-stu-id="f4135-166">Finally, whenever a page is loaded into the frame, that page is added as a [**PageStackEntry**](https://msdn.microsoft.com/library/windows/apps/dn298572) to the [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543) or [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547) of the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504), allowing for [history and backwards navigation](navigation-history-and-backwards-navigation.md).</span></span>

## <a name="3-pass-information-between-pages"></a><span data-ttu-id="f4135-167">3. ページ間での情報の受け渡し</span><span class="sxs-lookup"><span data-stu-id="f4135-167">3. Pass information between pages</span></span>

<span data-ttu-id="f4135-168">このアプリでは、ページ間の移動は行いますが、実際に何かの処理を行うわけではありません。</span><span class="sxs-lookup"><span data-stu-id="f4135-168">Our app navigates between two pages, but it really doesn't do anything interesting yet.</span></span> <span data-ttu-id="f4135-169">多くの場合、アプリに複数のページがあれば、ページ間で情報を共有する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4135-169">Often, when an app has multiple pages, the pages need to share information.</span></span> <span data-ttu-id="f4135-170">最初のページから 2 番目のページへ情報を渡してみましょう。</span><span class="sxs-lookup"><span data-stu-id="f4135-170">Let's pass some information from the first page to the second page.</span></span>

<span data-ttu-id="f4135-171">Page1.xaml、追加した**HyperlinkButton**を次[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635)で以前置き換えます。</span><span class="sxs-lookup"><span data-stu-id="f4135-171">In Page1.xaml, replace the **HyperlinkButton** you added earlier with the following [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635).</span></span>

<span data-ttu-id="f4135-172">次に、テキスト文字列を入力するための [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) ラベルと [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) `name` を追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-172">Here, we add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) label and a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) `name` for entering a text string.</span></span>

```xaml
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Text="Enter your name"/>
    <TextBox HorizontalAlignment="Center" Width="200" Name="name"/>
    <HyperlinkButton Content="Click to go to page 2" 
                     Click="HyperlinkButton_Click"
                     HorizontalAlignment="Center"/>
</StackPanel>
```

<span data-ttu-id="f4135-173">Page1.xaml 分離コード ファイルの `HyperlinkButton_Click` イベント ハンドラーで、`name`**TextBox** の `Text` プロパティを参照するパラメーターを `Navigate` メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="f4135-173">In the `HyperlinkButton_Click` event handler of the Page1.xaml code-behind file, add a parameter referencing the `Text` property of the `name`**TextBox** to the `Navigate` method.</span></span>

```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2), name.Text);
}
```

```cppwinrt
void Page1::HyperlinkButton_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args)
{
    Frame().Navigate(winrt::xaml_typename<NavApp1::Page2>(), winrt::box_value(name().Text()));
}
```

```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid), name->Text);
}
```

<span data-ttu-id="f4135-174">Page2.xaml で、前に追加した **HyperlinkButton** を次の **StackPanel** に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="f4135-174">In Page2.xaml, replace the **HyperlinkButton** you added earlier with the following **StackPanel**.</span></span>

<span data-ttu-id="f4135-175">次に、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) を追加して、Page1 から渡された文字列を表示します。</span><span class="sxs-lookup"><span data-stu-id="f4135-175">Here, we add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) for displaying the text string passed from Page1.</span></span>

```xaml
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Name="greeting"/>
    <HyperlinkButton Content="Click to go to page 1" 
                     Click="HyperlinkButton_Click"
                     HorizontalAlignment="Center"/>
</StackPanel>
```

<span data-ttu-id="f4135-176">Page2.xaml 分離コード ファイルで、次のコードを追加して `OnNavigatedTo` メソッドをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="f4135-176">In the Page2.xaml code-behind file, add the following to override the `OnNavigatedTo` method:</span></span>

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
    {
        greeting.Text = $"Hi, {e.Parameter.ToString()}";
    }
    else
    {
        greeting.Text = "Hi!";
    }
    base.OnNavigatedTo(e);
}
```

```cppwinrt
void Page2::OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs const& e)
{
    auto propertyValue{ e.Parameter().as<Windows::Foundation::IPropertyValue>() };
    if (propertyValue.Type() == Windows::Foundation::PropertyType::String)
    {
        greeting().Text(L"Hi, " + winrt::unbox_value<winrt::hstring>(e.Parameter()));
    }
    else
    {
        greeting().Text(L"Hi!");
    }
    __super::OnNavigatedTo(e);
}
```

```cpp
void Page2::OnNavigatedTo(NavigationEventArgs^ e)
{
    if (dynamic_cast<Platform::String^>(e->Parameter) != nullptr)
    {
        greeting->Text = "Hi, " + e->Parameter->ToString();
    }
    else
    {
        greeting->Text = "Hi!";
    }
    ::Windows::UI::Xaml::Controls::Page::OnNavigatedTo(e);
}
```

<span data-ttu-id="f4135-177">アプリを実行し、テキスト ボックスに自分の名前を入力し、**[Click to go to page 2]** と書かれているリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f4135-177">Run the app, type your name in the text box, and then click the link that says **Click to go to page 2**.</span></span> 

<span data-ttu-id="f4135-178">`Page1` の **HyperlinkButton** の **Click** イベントで `this.Frame.Navigate(typeof(Page2), name.Text)` を呼び出すと、`name.Text` プロパティが `Page2` に渡され、イベント データの値がページに表示されるメッセージに使用されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-178">When the **Click** event of the **HyperlinkButton** in `Page1` calls `this.Frame.Navigate(typeof(Page2), name.Text)`, the `name.Text` property is passed to `Page2`, and the value from the event data is used for the message displayed on the page.</span></span>

## <a name="4-cache-a-page"></a><span data-ttu-id="f4135-179">4. ページのキャッシュ</span><span class="sxs-lookup"><span data-stu-id="f4135-179">4. Cache a page</span></span>

<span data-ttu-id="f4135-180">ページのコンテンツと状態は既定ではキャッシュされないため、情報をキャッシュする場合は、アプリの各ページでキャッシュを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4135-180">Page content and state is not cached by default, so if you'd like to cache information, you must enable it in each page of your app.</span></span>

<span data-ttu-id="f4135-181">この基本的なピア ツー ピアの例では、戻るボタンはありませんが (戻るナビゲーションは「[前に戻る移動](navigation-history-and-backwards-navigation.md)」で示しました)、`Page2` で戻るボタンをクリックした場合、`Page1` の **TextBox** (およびその他のすべてのフィールド) は既定の状態に設定されます。</span><span class="sxs-lookup"><span data-stu-id="f4135-181">In our basic peer-to-peer example, there is no back button (we demonstrate back navigation in [backwards navigation](navigation-history-and-backwards-navigation.md)), but if you did click a back button on `Page2`, the **TextBox** (and any other field) on `Page1` would be set to its default state.</span></span> <span data-ttu-id="f4135-182">これを回避する方法の 1 つは、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) プロパティを使って、ページがフレームのページ キャッシュに追加されるように指定することです。</span><span class="sxs-lookup"><span data-stu-id="f4135-182">One way to work around this is to use the [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) property to specify that a page be added to the frame's page cache.</span></span> 

<span data-ttu-id="f4135-183">`Page1` のコンストラクターで、**NavigationCacheMode** を **Enabled** に設定して、フレームのページ キャッシュを超えるまでページのすべてのコンテンツと状態の値を保持することができます。</span><span class="sxs-lookup"><span data-stu-id="f4135-183">In the constructor of `Page1`, you can set **NavigationCacheMode** to **Enabled** to retains all content and state values for the page until the page cache for the frame is exceeded.</span></span> <span data-ttu-id="f4135-184">[**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) の制限を無視する場合は、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) を [**Required**](https://msdn.microsoft.com/library/windows/apps/br243284) に設定します。これで、フレームにキャッシュできる、ナビゲーション履歴内のページ数を指定します。</span><span class="sxs-lookup"><span data-stu-id="f4135-184">Set [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) to [**Required**](https://msdn.microsoft.com/library/windows/apps/br243284) if you want to ignore [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) limits, which specify the number of pages in the navigation history that can be cached for the frame.</span></span> <span data-ttu-id="f4135-185">ただし、キャッシュ サイズの制限は、デバイスのメモリの制限に依存しており、重要である可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f4135-185">However, keep in mind that cache size limits might be crucial, depending on the memory limits of a device.</span></span>

```csharp
public Page1()
{
    this.InitializeComponent();
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```

```cppwinrt
Page1::Page1()
{
    InitializeComponent();
    NavigationCacheMode(Windows::UI::Xaml::Navigation::NavigationCacheMode::Enabled);
}
```

```cpp
Page1::Page1()
{
    this->InitializeComponent();
    this->NavigationCacheMode = Windows::UI::Xaml::Navigation::NavigationCacheMode::Enabled;
}
```

## <a name="related-articles"></a><span data-ttu-id="f4135-186">関連記事</span><span class="sxs-lookup"><span data-stu-id="f4135-186">Related articles</span></span>
* [<span data-ttu-id="f4135-187">UWP アプリのナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="f4135-187">Navigation design basics for UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn958438)
* [<span data-ttu-id="f4135-188">タブとピボットのガイドライン</span><span class="sxs-lookup"><span data-stu-id="f4135-188">Guidelines for tabs and pivots</span></span>](https://msdn.microsoft.com/library/windows/apps/dn997788)
* [<span data-ttu-id="f4135-189">ナビゲーション ウィンドウのガイドライン</span><span class="sxs-lookup"><span data-stu-id="f4135-189">Guidelines for navigation panes</span></span>](https://msdn.microsoft.com/library/windows/apps/dn997766)
