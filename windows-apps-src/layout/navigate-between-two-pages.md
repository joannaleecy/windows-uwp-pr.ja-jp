---
author: Jwmsft
Description: "基本的な 2 ページのピア ツー ピア ユニバーサル Windows プラットフォーム (UWP) アプリでのナビゲーションの方法について説明します。"
title: "2 ページ間でのピア ツー ピアのナビゲーション"
ms.assetid: 0A364C8B-715F-4407-9426-92267E8FB525
label: Peer-to-peer navigation between two pages
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
ms.openlocfilehash: e5d0b0303218415d529b60e2dcaf28a21a28e430
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="implement-navigation-between-two-pages"></a><span data-ttu-id="22493-104">2 ページ間でのナビゲーションを実装する</span><span class="sxs-lookup"><span data-stu-id="22493-104">Implement navigation between two pages</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="22493-105">フレームおよびページを使用した、アプリでの基本的なナビゲーションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="22493-105">Learn how to use a frame and pages to enable basic navigation in your app.</span></span> 
<p></p>
<table>
    <tr>
        <td><span data-ttu-id="22493-106">重要な API:</span><span class="sxs-lookup"><span data-stu-id="22493-106">Important APIs:</span></span></td><td><span data-ttu-id="22493-107">[**Windows.UI.Xaml.Controls.Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラス、[**Windows.UI.Xaml.Controls.Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラス、[**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300) 名前空間</span><span class="sxs-lookup"><span data-stu-id="22493-107">[**Windows.UI.Xaml.Controls.Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) class, [**Windows.UI.Xaml.Controls.Page**](https://msdn.microsoft.com/library/windows/apps/br227503) class, [**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300) namespace</span></span></td>
    </tr>
</table>

## <a name="1-create-a-blank-app"></a><span data-ttu-id="22493-108">1. 空のアプリを作成する</span><span class="sxs-lookup"><span data-stu-id="22493-108">1. Create a blank app</span></span>


1.  <span data-ttu-id="22493-109">Microsoft Visual Studio の **[ファイル] メニューで、[新しいプロジェクト]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-109">On the Microsoft Visual Studio menu, choose **File &gt; New Project**.</span></span>
2.  <span data-ttu-id="22493-110">**[新しいプロジェクト]** ダイアログ ボックスの左側のウィンドウで、**[Visual C#]、[Windows]、[ユニバーサル]** ノードまたは **[Visual C++]、[Windows]、[ユニバーサル]** ノードの順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-110">In the left pane of the **New Project** dialog box, choose the **Visual C# -&gt; Windows -&gt; Universal** or the **Visual C++ -&gt; Windows -&gt; Universal** node.</span></span>
3.  <span data-ttu-id="22493-111">中央のウィンドウで、**[空のアプリケーション]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-111">In the center pane, choose **Blank App**.</span></span>
4.  <span data-ttu-id="22493-112">**[名前]** ボックスに「**NavApp1**」と入力し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-112">In the **Name** box, enter **NavApp1**, and then choose the **OK** button.</span></span>

    <span data-ttu-id="22493-113">ソリューションが作られ、プロジェクト ファイルが**ソリューション エクスプローラー**に表示されます。</span><span class="sxs-lookup"><span data-stu-id="22493-113">The solution is created and the project files appear in **Solution Explorer**.</span></span>

5.  <span data-ttu-id="22493-114">プログラムを実行するには、メニューで **[デバッグ]** をクリックして **[デバッグの開始]** をクリックするか、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="22493-114">To run the program, choose **Debug** &gt; **Start Debugging** from the menu, or press F5.</span></span>

    <span data-ttu-id="22493-115">空白のページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="22493-115">A blank page is displayed.</span></span>

6.  <span data-ttu-id="22493-116">デバッグを終了して Visual Studio に戻るには、Shift キーを押しながら F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="22493-116">Press Shift+F5 to stop debugging and return to Visual Studio.</span></span>

## <a name="2-add-basic-pages"></a><span data-ttu-id="22493-117">2. 基本ページの追加</span><span class="sxs-lookup"><span data-stu-id="22493-117">2. Add basic pages</span></span>

<span data-ttu-id="22493-118">次に、プロジェクトにコンテンツ ページを 2 つ追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-118">Next, add two content pages to the project.</span></span>

<span data-ttu-id="22493-119">次の手順を 2 回実行して、ナビゲーションを行う 2 つのページを追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-119">Do the following steps two times to add two pages to navigate between.</span></span>

1.  <span data-ttu-id="22493-120">**ソリューション エクスプローラー**で、**[BlankApp]** プロジェクト ノードを右クリックして、ショートカット メニューを開きます。</span><span class="sxs-lookup"><span data-stu-id="22493-120">In **Solution Explorer**, right-click the **BlankApp** project node to open the shortcut menu.</span></span>
2.  <span data-ttu-id="22493-121">ショートカット メニューで **[追加]**、**[新しい項目]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-121">Choose **Add** &gt; **New Item** from the shortcut menu.</span></span>
3.  <span data-ttu-id="22493-122">**[新しい項目の追加]** ダイアログ ボックスの中央のウィンドウで、**[空白のページ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-122">In the **Add New Item** dialog box, choose **Blank Page** in the middle pane.</span></span>
4.  <span data-ttu-id="22493-123">**[名前]** ボックスに「**Page1**」(または「**Page2**」) と入力し、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-123">In the **Name** box, enter **Page1** (or **Page2**) and press the **Add** button.</span></span>

<span data-ttu-id="22493-124">NavApp1 プロジェクトの一部としてこれらのファイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="22493-124">These files should now be listed as part of your NavApp1 project.</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="22493-125">C#</span><span class="sxs-lookup"><span data-stu-id="22493-125">C#</span></span></th>
<th align="left"><span data-ttu-id="22493-126">C++</span><span class="sxs-lookup"><span data-stu-id="22493-126">C++</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><ul>
<li><span data-ttu-id="22493-127">Page1.xaml</span><span class="sxs-lookup"><span data-stu-id="22493-127">Page1.xaml</span></span></li>
<li><span data-ttu-id="22493-128">Page1.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="22493-128">Page1.xaml.cs</span></span></li>
<li><span data-ttu-id="22493-129">Page2.xaml</span><span class="sxs-lookup"><span data-stu-id="22493-129">Page2.xaml</span></span></li>
<li><span data-ttu-id="22493-130">Page2.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="22493-130">Page2.xaml.cs</span></span></li>
</ul></td>
<td style="vertical-align:top;"><ul>
<li><span data-ttu-id="22493-131">Page1.xaml</span><span class="sxs-lookup"><span data-stu-id="22493-131">Page1.xaml</span></span></li>
<li><span data-ttu-id="22493-132">Page1.xaml.cpp</span><span class="sxs-lookup"><span data-stu-id="22493-132">Page1.xaml.cpp</span></span></li>
<li><span data-ttu-id="22493-133">Page1.xaml.h</span><span class="sxs-lookup"><span data-stu-id="22493-133">Page1.xaml.h</span></span></li>
<li><span data-ttu-id="22493-134">Page2.xaml</span><span class="sxs-lookup"><span data-stu-id="22493-134">Page2.xaml</span></span></li>
<li><span data-ttu-id="22493-135">Page2.xaml.cpp</span><span class="sxs-lookup"><span data-stu-id="22493-135">Page2.xaml.cpp</span></span></li>
<li><span data-ttu-id="22493-136">Page2.xaml.h</span><span class="sxs-lookup"><span data-stu-id="22493-136">Page2.xaml.h</span></span>

</li>
</ul></td>
</tr>
</tbody>
</table>

 

<span data-ttu-id="22493-137">Page1.xaml の UI に次のコンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-137">Add the following content to the UI of Page1.xaml.</span></span>

-   <span data-ttu-id="22493-138">`pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-138">Add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element named `pageTitle` as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704).</span></span> <span data-ttu-id="22493-139">[**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティを `Page 1` に変更します。</span><span class="sxs-lookup"><span data-stu-id="22493-139">Change the [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) property to `Page 1`.</span></span>

```xaml
<TextBlock x:Name="pageTitle" Text="Page 1" />
```

-   <span data-ttu-id="22493-140">次の [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として、`pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素の後に追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-140">Add the following [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) element as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) and after the `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element.</span></span>

    
```xaml
<HyperlinkButton Content="Click to go to page 2"
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

<span data-ttu-id="22493-141">前に追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを Page1.xaml 分離コード ファイルの `Page1` クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-141">Add the following code to the `Page1` class in the Page1.xaml code-behind file to handle the `Click` event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added previously.</span></span> <span data-ttu-id="22493-142">ここで、Page2.xaml に移動します。</span><span class="sxs-lookup"><span data-stu-id="22493-142">Here, we navigate to Page2.xaml.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2));
}
```
```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid));
}
```

<span data-ttu-id="22493-143">Page2.xaml の UI を次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="22493-143">Make the following changes to the UI of Page2.xaml.</span></span>

-   <span data-ttu-id="22493-144">`pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-144">Add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element named `pageTitle` as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704).</span></span> <span data-ttu-id="22493-145">[**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティの値を `Page 2` に変更します。</span><span class="sxs-lookup"><span data-stu-id="22493-145">Change the value of the [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) property to `Page 2`.</span></span>

```xaml
<TextBlock x:Name="pageTitle" Text="Page 2" />
```

-   <span data-ttu-id="22493-146">次の [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として、`pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素の後に追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-146">Add the following [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) element as a child element of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) and after the `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element.</span></span>

```xaml
<HyperlinkButton Content="Click to go to page 1" 
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

<span data-ttu-id="22493-147">前に追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを Page2.xaml 分離コード ファイルの `Page2` クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-147">Add the following code to the `Page2` class in the Page2.xaml code-behind file to handle the `Click` event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added previously.</span></span> <span data-ttu-id="22493-148">ここで、Page1.xaml に移動します。</span><span class="sxs-lookup"><span data-stu-id="22493-148">Here, we navigate to Page1.xaml.</span></span>

> [!NOTE]
> <span data-ttu-id="22493-149">C++ プロジェクトの場合は、別のページを参照する各ページのヘッダー ファイルに `#include` ディレクティブを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22493-149">For C++ projects, you must add a `#include` directive in the header file of each page that references another page.</span></span> <span data-ttu-id="22493-150">ここで示したページ間のナビゲーションの例では、page1.xaml.h ファイルに `#include "Page2.xaml.h"` が、page2.xaml.h に `#include "Page1.xaml.h"` が含まれています。</span><span class="sxs-lookup"><span data-stu-id="22493-150">For the inter-page navigation example presented here, page1.xaml.h file contains `#include "Page2.xaml.h"`, in turn, page2.xaml.h contains `#include "Page1.xaml.h"`.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page1));
}
```
```cpp
void Page2::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid));
}
```

<span data-ttu-id="22493-151">コンテンツ ページが用意できたら、Page1.xaml をアプリの開始時に表示されるように設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22493-151">Now that we've prepared the content pages, we need to make Page1.xaml display when the app starts.</span></span>

<span data-ttu-id="22493-152">app.xaml 分離コードファイルを開き、`OnLaunched` ハンドラーを変更します。</span><span class="sxs-lookup"><span data-stu-id="22493-152">Open the app.xaml code-behind file and change the `OnLaunched` handler.</span></span>

<span data-ttu-id="22493-153">次に、[**Frame.Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) の呼び出しに、`MainPage` ではなく `Page1` を追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-153">Here, we specify `Page1` in the call to [**Frame.Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) instead of `MainPage`.</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> protected override void OnLaunched(LaunchActivatedEventArgs e)
> {
>     Frame rootFrame = Window.Current.Content as Frame;
> 
>     // Do not repeat app initialization when the Window already has content,
>     // just ensure that the window is active
>     if (rootFrame == null)
>     {
>         // Create a Frame to act as the navigation context and navigate to the first page
>         rootFrame = new Frame();
> 
>         rootFrame.NavigationFailed += OnNavigationFailed;
> 
>         if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
>         {
>             //TODO: Load state from previously suspended application
>         }
> 
>         // Place the frame in the current Window
>         Window.Current.Content = rootFrame;
>     }
> 
>     if (rootFrame.Content == null)
>     {
>         // When the navigation stack isn't restored navigate to the first page,
>         // configuring the new page by passing required information as a navigation
>         // parameter
>         rootFrame.Navigate(typeof(Page1), e.Arguments);
>     }
>     // Ensure the current window is active
>     Window.Current.Activate();
> }
> ```
> ```cpp
> void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e)
> {
>     auto rootFrame = dynamic_cast<Frame^>(Window::Current->Content);
> 
>     // Do not repeat app initialization when the Window already has content,
>     // just ensure that the window is active
>     if (rootFrame == nullptr)
>     {
>         // Create a Frame to act as the navigation context and associate it with
>         // a SuspensionManager key
>         rootFrame = ref new Frame();
> 
>         rootFrame->NavigationFailed += 
>             ref new Windows::UI::Xaml::Navigation::NavigationFailedEventHandler(
>                 this, &App::OnNavigationFailed);
> 
>         if (e->PreviousExecutionState == ApplicationExecutionState::Terminated)
>         {
>             // TODO: Load state from previously suspended application
>         }
>         
>         // Place the frame in the current Window
>         Window::Current->Content = rootFrame;
>     }
> 
>     if (rootFrame->Content == nullptr)
>     {
>         // When the navigation stack isn't restored navigate to the first page,
>         // configuring the new page by passing required information as a navigation
>         // parameter
>         rootFrame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid), e->Arguments);
>     }
> 
>     // Ensure the current window is active
>     Window::Current->Activate();
> }
> ```

<span data-ttu-id="22493-154">**注:** このコードは、アプリの初期ウィンドウ フレームへのナビゲーションが失敗した場合に、[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) の戻り値を使ってアプリの例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="22493-154">**Note**  The code here uses the return value of [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) to throw an app exception if the navigation to the app's initial window frame fails.</span></span> <span data-ttu-id="22493-155">**Navigate** が **true** を返す場合は、ナビゲーションが行われます。</span><span class="sxs-lookup"><span data-stu-id="22493-155">When **Navigate** returns **true**, the navigation happens.</span></span>

<span data-ttu-id="22493-156">次に、アプリをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="22493-156">Now, build and run the app.</span></span> <span data-ttu-id="22493-157">"Click to go to page 2" と書かれているリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-157">Click the link that says "Click to go to page 2".</span></span> <span data-ttu-id="22493-158">上部に "Page 2" と書かれた 2 番目のページが読み込まれ、フレームに表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="22493-158">The second page that says "Page 2" at the top should be loaded and displayed in the frame.</span></span>

## <a name="about-the-frame-and-page-classes"></a><span data-ttu-id="22493-159">Frame クラスと Page クラスについて</span><span class="sxs-lookup"><span data-stu-id="22493-159">About the Frame and Page classes</span></span>

<span data-ttu-id="22493-160">アプリにさらに機能を加える前に、追加したページに用意されているアプリのナビゲーション サポートについて見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="22493-160">Before we add more functionality to our app, let's look at how the pages we added provide navigation support for the app.</span></span>

<span data-ttu-id="22493-161">まず、App.xaml 分離コード ファイルの `App.OnLaunched` メソッドで、アプリの [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) (`rootFrame`) が作成されます。</span><span class="sxs-lookup"><span data-stu-id="22493-161">First, a [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) (`rootFrame`) is created for the app in the `App.OnLaunched` method of the App.xaml code-behind file.</span></span> <span data-ttu-id="22493-162">[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) メソッドを使って、この **Frame** にコンテンツが表示されます。</span><span class="sxs-lookup"><span data-stu-id="22493-162">The [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) method is used to display content in this **Frame**.</span></span>

**<span data-ttu-id="22493-163">注:</span><span class="sxs-lookup"><span data-stu-id="22493-163">Note</span></span>**  
<span data-ttu-id="22493-164">[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラスは、[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694)、[**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568)、[**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693) などのさまざまなナビゲーション メソッドと、[**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543)、[**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547)、[**BackStackDepth**](https://msdn.microsoft.com/library/windows/apps/hh967995) などのプロパティをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="22493-164">The [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) class supports various navigation methods such as [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694), [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568), and [**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693), and properties such as [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543), [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547), and [**BackStackDepth**](https://msdn.microsoft.com/library/windows/apps/hh967995).</span></span>

 
<span data-ttu-id="22493-165">この例では、`Page1` が [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) メソッドに渡されます。</span><span class="sxs-lookup"><span data-stu-id="22493-165">In our example, `Page1` is passed to the [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) method.</span></span> <span data-ttu-id="22493-166">このメソッドは、アプリの現在のウィンドウの内容を [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) に設定し、指定したページの内容を **Frame** に読み込みます (この例では Page1.xaml、既定では MainPage.xaml)。</span><span class="sxs-lookup"><span data-stu-id="22493-166">This method sets the content of the app's current window to the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) and loads the content of the page you specify into the **Frame** (Page1.xaml in our example, or MainPage.xaml, by default).</span></span>

`Page1` <span data-ttu-id="22493-167"> は [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラスのサブクラスです。</span><span class="sxs-lookup"><span data-stu-id="22493-167">is a subclass of the [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) class.</span></span> <span data-ttu-id="22493-168">**Page** クラスには、**Page** が含まれる [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) を取得する読み取り専用の [**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="22493-168">The **Page** class has a read-only [**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) property that gets the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) containing the **Page**.</span></span> <span data-ttu-id="22493-169">[**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベント ハンドラーが ` Frame.Navigate(typeof(Page2))` を呼び出すと、アプリのウィンドウ内の **Frame** に Page2.xaml のコンテンツが表示されます。</span><span class="sxs-lookup"><span data-stu-id="22493-169">When the [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) event handler of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) calls` Frame.Navigate(typeof(Page2))`, the **Frame** in the app's window displays the content of Page2.xaml.</span></span>

<span data-ttu-id="22493-170">フレームにページが読み込まれるたびに、そのページが [**PageStackEntry**](https://msdn.microsoft.com/library/windows/apps/dn298572) として、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) の [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543) または [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547) に追加されます。</span><span class="sxs-lookup"><span data-stu-id="22493-170">Whenever a page is loaded into the frame, that page is added as a [**PageStackEntry**](https://msdn.microsoft.com/library/windows/apps/dn298572) to the [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543) or [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547) of the [**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504).</span></span>

## <a name="3-pass-information-between-pages"></a><span data-ttu-id="22493-171">3. ページ間での情報の受け渡し</span><span class="sxs-lookup"><span data-stu-id="22493-171">3. Pass information between pages</span></span>

<span data-ttu-id="22493-172">このアプリでは、ページ間の移動は行いますが、実際に何かの処理を行うわけではありません。</span><span class="sxs-lookup"><span data-stu-id="22493-172">Our app navigates between two pages, but it really doesn't do anything interesting yet.</span></span> <span data-ttu-id="22493-173">多くの場合、アプリに複数のページがあれば、ページ間で情報を共有する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22493-173">Often, when an app has multiple pages, the pages need to share information.</span></span> <span data-ttu-id="22493-174">最初のページから 2 番目のページへ情報を渡してみましょう。</span><span class="sxs-lookup"><span data-stu-id="22493-174">Let's pass some information from the first page to the second page.</span></span>

<span data-ttu-id="22493-175">Page1.xaml で、前に追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) を次の [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="22493-175">In Page1.xaml, replace the the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added earlier with the following [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635).</span></span>

<span data-ttu-id="22493-176">次に、テキスト文字列を入力するための [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) ラベルと [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (`name`) を追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-176">Here, we add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) label and a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (`name`) for entering a text string.</span></span>

```xaml
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Text="Enter your name"/>
    <TextBox HorizontalAlignment="Center" Width="200" Name="name"/>
    <HyperlinkButton Content="Click to go to page 2" 
                     Click="HyperlinkButton_Click"
                     HorizontalAlignment="Center"/>
</StackPanel>
```

<span data-ttu-id="22493-177">Page1.xaml 分離コード ファイルの `HyperlinkButton_Click` イベント ハンドラーで、`name` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) の `Text` プロパティを参照するパラメーターを `Navigate` メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="22493-177">In the `HyperlinkButton_Click` event handler of the Page1.xaml code-behind file, add a parameter referencing the `Text` property of the `name` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) to the `Navigate` method.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2), name.Text);
}
```
```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid), name->Text);
}
```

<span data-ttu-id="22493-178">Page2.xaml で、前に追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) を次の [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="22493-178">In Page2.xaml, replace the the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) you added earlier with the following [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635).</span></span>

<span data-ttu-id="22493-179">次に、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) を追加して、Page1 から渡された文字列を表示します。</span><span class="sxs-lookup"><span data-stu-id="22493-179">Here, we add a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) for displaying a text string passed from Page1.</span></span>

```xaml
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Name="greeting"/>
    <HyperlinkButton Content="Click to go to page 1" 
                     Click="HyperlinkButton_Click"
                     HorizontalAlignment="Center"/>
</StackPanel>
```

<span data-ttu-id="22493-180">Page2.xaml 分離コード ファイルで、`OnNavigatedTo` メソッドを次のように上書きします。</span><span class="sxs-lookup"><span data-stu-id="22493-180">In the Page2.xaml code-behind file, override the `OnNavigatedTo` method with the following:</span></span>

> [!div class="tabbedCodeSnippets"]
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
```cpp
void Page2::OnNavigatedTo(NavigationEventArgs^ e)
{
    if (dynamic_cast<Platform::String^>(e->Parameter) != nullptr)
    {
        greeting->Text = "Hi," + e->Parameter->ToString();
    }
    else
    {
        greeting->Text = "Hi!";
    }
    ::Windows::UI::Xaml::Controls::Page::OnNavigatedTo(e);
}
```

<span data-ttu-id="22493-181">アプリを実行し、テキスト ボックスに自分の名前を入力し、**[Click to go to page 2]** と書かれているリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="22493-181">Run the app, type your name in the text box, and then click the link that says **Click to go to page 2**.</span></span> <span data-ttu-id="22493-182">[**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントで `this.Frame.Navigate(typeof(Page2), name.Text)` を呼び出したときに、`name.Text` プロパティが `Page2` に渡され、イベント データの値がページに表示されるメッセージに使用されます。</span><span class="sxs-lookup"><span data-stu-id="22493-182">When you called `this.Frame.Navigate(typeof(Page2), name.Text)` in the [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) event of the [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739), the `name.Text` property was passed to `Page2` and the value from the event data is used for the message displayed on the page.</span></span>

## <a name="4-cache-a-page"></a><span data-ttu-id="22493-183">4. ページのキャッシュ</span><span class="sxs-lookup"><span data-stu-id="22493-183">4. Cache a page</span></span>

<span data-ttu-id="22493-184">ページのコンテンツと状態は既定ではキャッシュされないため、アプリの各ページで有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="22493-184">Page content and state is not cached by default, you must enable it in each page of your app.</span></span>

<span data-ttu-id="22493-185">この基本的なピア ツー ピアの例では、戻るボタンはありませんが (戻るナビゲーションは「[[戻る] ボタンによるナビゲーション](navigation-history-and-backwards-navigation.md)」で示しました)、`Page2` で戻るボタンをクリックした場合、`Page1` の [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (およびその他のすべてのフィールド) は既定の状態に設定されます。</span><span class="sxs-lookup"><span data-stu-id="22493-185">In our basic peer-to-peer example, there is no back button (we demonstrate back navigation in [Back button navigation](navigation-history-and-backwards-navigation.md)), but if you did click a back button on `Page2`, the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (and any other field) on `Page1` would be set to its default state.</span></span> <span data-ttu-id="22493-186">これを回避する方法の 1 つは、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) プロパティを使って、ページがフレームのページ キャッシュに追加されるように指定することです。</span><span class="sxs-lookup"><span data-stu-id="22493-186">One way to work around this is to use the [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) property to specify that a page be added to the frame's page cache.</span></span>

<span data-ttu-id="22493-187">`Page1` のコンストラクターで、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) を [**Enabled**](https://msdn.microsoft.com/library/windows/apps/br243284) に設定します。</span><span class="sxs-lookup"><span data-stu-id="22493-187">In the constructor of `Page1`, set [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) to [**Enabled**](https://msdn.microsoft.com/library/windows/apps/br243284).</span></span> <span data-ttu-id="22493-188">これにより、フレームのページ キャッシュを超えるまで、ページのすべてのコンテンツや状態値が保持されます。</span><span class="sxs-lookup"><span data-stu-id="22493-188">This retains all content and state values for the page until the page cache for the frame is exceeded.</span></span>

<span data-ttu-id="22493-189">フレームのキャッシュ サイズの制限を無視する場合は、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) を [**Required**](https://msdn.microsoft.com/library/windows/apps/br243284) に設定します。</span><span class="sxs-lookup"><span data-stu-id="22493-189">Set [**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) to [**Required**](https://msdn.microsoft.com/library/windows/apps/br243284) if you want to ignore cache size limits for the frame.</span></span> <span data-ttu-id="22493-190">ただし、キャッシュ サイズの制限は、デバイスのメモリの制限に依存しており、重要である可能性があります。</span><span class="sxs-lookup"><span data-stu-id="22493-190">However, cache size limits might be crucial, depending on the memory limits of a device.</span></span>

> [!NOTE]
> <span data-ttu-id="22493-191">[**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) プロパティは、フレームにキャッシュできる、ナビゲーション履歴内のページ数を指定します。</span><span class="sxs-lookup"><span data-stu-id="22493-191">The [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) property specifies the number of pages in the navigation history that can be cached for the frame.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
public Page1()
{
    this.InitializeComponent();
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```
```cpp
Page1::Page1()
{
    this->InitializeComponent();
    this->NavigationCacheMode = Windows::UI::Xaml::Navigation::NavigationCacheMode::Enabled;
}
```

## <a name="related-articles"></a><span data-ttu-id="22493-192">関連記事</span><span class="sxs-lookup"><span data-stu-id="22493-192">Related articles</span></span>

* [<span data-ttu-id="22493-193">UWP アプリのナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="22493-193">Navigation design basics for UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn958438)
* [<span data-ttu-id="22493-194">タブとピボットのガイドライン</span><span class="sxs-lookup"><span data-stu-id="22493-194">Guidelines for tabs and pivots</span></span>](https://msdn.microsoft.com/library/windows/apps/dn997788)
* [<span data-ttu-id="22493-195">ナビゲーション ウィンドウのガイドライン</span><span class="sxs-lookup"><span data-stu-id="22493-195">Guidelines for navigation panes</span></span>](https://msdn.microsoft.com/library/windows/apps/dn997766)
 

 




