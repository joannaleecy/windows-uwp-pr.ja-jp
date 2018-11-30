---
Description: View multiple parts of your app in separate windows.
title: アプリの複数のビューの表示
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 107c904dc4b89941c0f453efd830504d2d032534
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8210202"
---
# <a name="show-multiple-views-for-an-app"></a><span data-ttu-id="7f14a-103">アプリの複数のビューの表示</span><span class="sxs-lookup"><span data-stu-id="7f14a-103">Show multiple views for an app</span></span>

![複数のウィンドウでアプリを表示するワイヤーフレーム](images/multi-view.gif)

<span data-ttu-id="7f14a-105">アプリの独立した部分を別々のウィンドウで表示できるようにすることは、ユーザーが生産性を高めるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-105">Help your users be more productive by letting them view independent parts of your app in separate windows.</span></span> <span data-ttu-id="7f14a-106">アプリの複数のウィンドウを作成すると、各ウィンドウは別々に動作します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-106">When you create multiple windows for an app, each window behaves independently.</span></span> <span data-ttu-id="7f14a-107">タスク バーには各ウィンドウが別々に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-107">The taskbar shows each window separately.</span></span> <span data-ttu-id="7f14a-108">ユーザーはアプリ ウィンドウの移動、サイズ変更、表示、非表示を個別に行うことができます。また、個別のアプリの場合と同じように各アプリ ウィンドウを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-108">Users can move, resize, show, and hide app windows independently and can switch between app windows as if they were separate apps.</span></span> <span data-ttu-id="7f14a-109">各ウィンドウは、独自のスレッドで動作します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-109">Each window operates in its own thread.</span></span>

> <span data-ttu-id="7f14a-110">**重要な API**: [**ApplicationViewSwitcher**](https://msdn.microsoft.com/library/windows/apps/dn281094)、[**CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278)</span><span class="sxs-lookup"><span data-stu-id="7f14a-110">**Important APIs**: [**ApplicationViewSwitcher**](https://msdn.microsoft.com/library/windows/apps/dn281094), [**CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278)</span></span>

## <a name="when-should-an-app-use-multiple-views"></a><span data-ttu-id="7f14a-111">アプリが複数のビューを使用する場合</span><span class="sxs-lookup"><span data-stu-id="7f14a-111">When should an app use multiple views?</span></span>
<span data-ttu-id="7f14a-112">複数のビューによるメリットを活用できる、さまざまなシナリオがあります。</span><span class="sxs-lookup"><span data-stu-id="7f14a-112">There's a variety of scenarios that can benefit from multiple views.</span></span> <span data-ttu-id="7f14a-113">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-113">Here are a few examples:</span></span>
 - <span data-ttu-id="7f14a-114">受信したメッセージの一覧を表示しながら、新しいメールを作成できるメール アプリ</span><span class="sxs-lookup"><span data-stu-id="7f14a-114">An email app that lets users view a list of received messages while composing a new email</span></span>
 - <span data-ttu-id="7f14a-115">複数の連絡先情報を並列に表示して比較できるアドレス帳アプリ</span><span class="sxs-lookup"><span data-stu-id="7f14a-115">An address book app that lets users compare contact info for multiple people side-by-side</span></span>
 - <span data-ttu-id="7f14a-116">再生中の曲の情報を表示しながら、その他の利用可能な曲のリストを閲覧できるミュージック プレイヤー アプリ</span><span class="sxs-lookup"><span data-stu-id="7f14a-116">A music player app that lets users see what's playing while browsing through a list of other available music</span></span>
 - <span data-ttu-id="7f14a-117">ノートの 1 つのページから別のページに情報をコピーできるメモ アプリ</span><span class="sxs-lookup"><span data-stu-id="7f14a-117">A note-taking app that lets users copy information from one page of notes to another</span></span>
 - <span data-ttu-id="7f14a-118">すべてのヘッドライン概要に目を通しながら、後から読むための記事を複数開くことができる閲覧アプリ</span><span class="sxs-lookup"><span data-stu-id="7f14a-118">A reading app that lets users open several articles for reading later, after an opportunity to peruse all high-level headlines</span></span>

<span data-ttu-id="7f14a-119">アプリの別のインスタンスを作成するには、「[マルチインスタンスの UWP アプリの作成](../../launch-resume/multi-instance-uwp.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7f14a-119">To create separate instances of your app, see [Create a multi-instance UWP app](../../launch-resume/multi-instance-uwp.md).</span></span>

## <a name="what-is-a-view"></a><span data-ttu-id="7f14a-120">ビューとは</span><span class="sxs-lookup"><span data-stu-id="7f14a-120">What is a view?</span></span>

<span data-ttu-id="7f14a-121">アプリのビューは、スレッドとウィンドウが 1:1 で対応したもので、アプリがコンテンツの表示に使います。</span><span class="sxs-lookup"><span data-stu-id="7f14a-121">An app view is the 1:1 pairing of a thread and a window that the app uses to display content.</span></span> <span data-ttu-id="7f14a-122">ビューは [**Windows.ApplicationModel.Core.CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) オブジェクトによって表現されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-122">It's represented by a [**Windows.ApplicationModel.Core.CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) object.</span></span>

<span data-ttu-id="7f14a-123">また、[**CoreApplication**](https://msdn.microsoft.com/library/windows/apps/br225016) オブジェクトによって管理されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-123">Views are managed by the [**CoreApplication**](https://msdn.microsoft.com/library/windows/apps/br225016) object.</span></span> <span data-ttu-id="7f14a-124">[**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) を呼び出して、[**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) オブジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-124">You call [**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) to create a [**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) object.</span></span> <span data-ttu-id="7f14a-125">**CoreApplicationView** は [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) と [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) ([**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br225019) プロパティと [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/dn433264) プロパティに格納) を関連付けます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-125">The **CoreApplicationView** brings together a [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) and a [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) (stored in the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br225019) and [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/dn433264) properties).</span></span> <span data-ttu-id="7f14a-126">**CoreApplicationView** は、Windows ランタイムがコア Windows システムとのやり取りに使うオブジェクトとして考えることができます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-126">You can think of the **CoreApplicationView** as the object that the Windows Runtime uses to interact with the core Windows system.</span></span>

<span data-ttu-id="7f14a-127">通常は [**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) を直接操作しません。</span><span class="sxs-lookup"><span data-stu-id="7f14a-127">You typically don’t work directly with the [**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017).</span></span> <span data-ttu-id="7f14a-128">代わりに Windows ランタイムでは、[**ApplicationView**](https://msdn.microsoft.com/library/windows/apps/hh701658) クラスは [**Windows.UI.ViewManagement**](https://msdn.microsoft.com/library/windows/apps/br242295) 名前空間にあります。</span><span class="sxs-lookup"><span data-stu-id="7f14a-128">Instead, the Windows Runtime provides the [**ApplicationView**](https://msdn.microsoft.com/library/windows/apps/hh701658) class in the [**Windows.UI.ViewManagement**](https://msdn.microsoft.com/library/windows/apps/br242295) namespace.</span></span> <span data-ttu-id="7f14a-129">このクラスには、アプリがウィンドウ システムとのやり取りに使うプロパティ、メソッド、イベントが用意されています。</span><span class="sxs-lookup"><span data-stu-id="7f14a-129">This class provides properties, methods, and events that you use when your app interacts with the windowing system.</span></span> <span data-ttu-id="7f14a-130">**ApplicationView** を操作するには、静的メソッド [**ApplicationView.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh701672) を呼び出して、現在の **CoreApplicationView** のスレッドに関連付けられている **ApplicationView** インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-130">To work with an **ApplicationView**, call the static [**ApplicationView.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh701672) method, which gets an **ApplicationView** instance tied to the current **CoreApplicationView**’s thread.</span></span>

<span data-ttu-id="7f14a-131">同様に、XAML フレーム ワークは [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトを [**Windows.UI.XAML.Window**](https://msdn.microsoft.com/library/windows/apps/br209041) オブジェクトにラップします。</span><span class="sxs-lookup"><span data-stu-id="7f14a-131">Likewise, the XAML framework wraps the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) object in a [**Windows.UI.XAML.Window**](https://msdn.microsoft.com/library/windows/apps/br209041) object.</span></span> <span data-ttu-id="7f14a-132">XAML アプリでは通常、**CoreWindow** を直接操作しないで、**Window** オブジェクトを操作します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-132">In a XAML app, you typically interact with the **Window** object rather than working directly with the **CoreWindow**.</span></span>

## <a name="show-a-new-view"></a><span data-ttu-id="7f14a-133">新しいビューの表示</span><span class="sxs-lookup"><span data-stu-id="7f14a-133">Show a new view</span></span>

<span data-ttu-id="7f14a-134">各アプリのレイアウトはそれぞれ異なりますが、「新しいウィンドウ」ボタンを予測可能な場所に含めることを推奨します。たとえば、新しいウィンドウで開くことができるコンテンツの右上隅などです。</span><span class="sxs-lookup"><span data-stu-id="7f14a-134">While each app layout is unique, we recommend including a "new window" button in a predictable location, such as the top right corner of the content that can be opened in a new window.</span></span> <span data-ttu-id="7f14a-135">さらに、[新しいウィンドウで開く] ためのコンテキスト メニュー オプションを含めることを検討します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-135">Also consider including a context menu option to "Open in a new window".</span></span>

<span data-ttu-id="7f14a-136">新しいビューを作成する手順を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="7f14a-136">Let's look at the steps to create a new view.</span></span> <span data-ttu-id="7f14a-137">ここでは、新しいビューがボタンのクリックに応じて起動されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-137">Here, the new view is launched in response to a button click.</span></span>

```csharp
private async void Button_Click(object sender, RoutedEventArgs e)
{
    CoreApplicationView newView = CoreApplication.CreateNewView();
    int newViewId = 0;
    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        Frame frame = new Frame();
        frame.Navigate(typeof(SecondaryPage), null);   
        Window.Current.Content = frame;
        // You have to activate the window in order to show it later.
        Window.Current.Activate();

        newViewId = ApplicationView.GetForCurrentView().Id;
    });
    bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
}
```

**<span data-ttu-id="7f14a-138">新しいビューを表示するには</span><span class="sxs-lookup"><span data-stu-id="7f14a-138">To show a new view</span></span>**

1.  <span data-ttu-id="7f14a-139">[**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297291) を呼び出して、ビュー コンテンツに使う新しいウィンドウとスレッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-139">Call [**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297291) to create a new window and thread for the view content.</span></span>

    ```csharp
    CoreApplicationView newView = CoreApplication.CreateNewView();
    ```

2.  <span data-ttu-id="7f14a-140">新しいビューの [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) を記録します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-140">Track the [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) of the new view.</span></span> <span data-ttu-id="7f14a-141">これは後でビューの表示に使います。</span><span class="sxs-lookup"><span data-stu-id="7f14a-141">You use this to show the view later.</span></span>

    <span data-ttu-id="7f14a-142">作成するビューの追跡に役立つ何らかのインフラストラクチャをアプリに構築することを検討することもできます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-142">You might want to consider building some infrastructure into your app to help with tracking the views you create.</span></span> <span data-ttu-id="7f14a-143">例については、[MultipleViews サンプル](http://go.microsoft.com/fwlink/p/?LinkId=620574)の `ViewLifetimeControl` クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7f14a-143">See the `ViewLifetimeControl` class in the [MultipleViews sample](http://go.microsoft.com/fwlink/p/?LinkId=620574) for an example.</span></span>

    ```csharp
    int newViewId = 0;
    ```

3.  <span data-ttu-id="7f14a-144">新しいスレッドで、ウィンドウにコンテンツを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-144">On the new thread, populate the window.</span></span>

    <span data-ttu-id="7f14a-145">[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) メソッドを使って、UI スレッドでの新しいビューの操作をスケジュールします。</span><span class="sxs-lookup"><span data-stu-id="7f14a-145">You use the [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) method to schedule work on the UI thread for the new view.</span></span> <span data-ttu-id="7f14a-146">[ラムダ式](http://go.microsoft.com/fwlink/p/?LinkId=389615)を使って、**RunAsync** メソッドの引数として関数を渡します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-146">You use a [lambda expression](http://go.microsoft.com/fwlink/p/?LinkId=389615) to pass a function as an argument to the **RunAsync** method.</span></span> <span data-ttu-id="7f14a-147">ラムダ関数による操作は新しいビューのスレッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-147">The work you do in the lambda function happens on the new view's thread.</span></span>

    <span data-ttu-id="7f14a-148">XAML では通常、[**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) の [**Content**](https://msdn.microsoft.com/library/windows/apps/br209051) プロパティに [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) を追加した後、**Frame** から、アプリのコンテンツを定義した XAML [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) に移ります。</span><span class="sxs-lookup"><span data-stu-id="7f14a-148">In XAML, you typically add a [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) to the [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041)'s [**Content**](https://msdn.microsoft.com/library/windows/apps/br209051) property, then navigate the **Frame** to a XAML [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) where you've defined your app content.</span></span> <span data-ttu-id="7f14a-149">詳しくは、「[2 ページ間のピア ツー ピア ナビゲーション](../basics/navigate-between-two-pages.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7f14a-149">For more info, see [Peer-to-peer navigation between two pages](../basics/navigate-between-two-pages.md).</span></span>

    <span data-ttu-id="7f14a-150">新しい [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) にコンテンツが読み込まれたら、後で **Window** を表示するには、**Window** の [**Activate**](https://msdn.microsoft.com/library/windows/apps/br209046) メソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f14a-150">After the new [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) is populated, you must call the **Window**'s [**Activate**](https://msdn.microsoft.com/library/windows/apps/br209046) method in order to show the **Window** later.</span></span> <span data-ttu-id="7f14a-151">この操作は新しいビューのスレッドで実行されるため、新しい **Window** がアクティブになります。</span><span class="sxs-lookup"><span data-stu-id="7f14a-151">This work happens on the new view's thread, so the new **Window** is activated.</span></span>

    <span data-ttu-id="7f14a-152">最後に、後でビューの表示に使う新しいビューの [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) を取得します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-152">Finally, get the new view's [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) that you use to show the view later.</span></span> <span data-ttu-id="7f14a-153">やはり、この操作も新しいビューのスレッドで実行されるため、[**ApplicationView.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh701672) は新しいビューの **Id** を取得します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-153">Again, this work is on the new view's thread, so [**ApplicationView.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh701672) gets the **Id** of the new view.</span></span>

    ```csharp
    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        Frame frame = new Frame();
        frame.Navigate(typeof(SecondaryPage), null);   
        Window.Current.Content = frame;
        // You have to activate the window in order to show it later.
        Window.Current.Activate();

        newViewId = ApplicationView.GetForCurrentView().Id;
    });
    ```

4.  <span data-ttu-id="7f14a-154">[**ApplicationViewSwitcher.TryShowAsStandaloneAsync**](https://msdn.microsoft.com/library/windows/apps/dn281101) を呼び出して、新しいビューを表示します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-154">Show the new view by calling [**ApplicationViewSwitcher.TryShowAsStandaloneAsync**](https://msdn.microsoft.com/library/windows/apps/dn281101).</span></span>

    <span data-ttu-id="7f14a-155">新しいビューを作成したら、[**ApplicationViewSwitcher.TryShowAsStandaloneAsync**](https://msdn.microsoft.com/library/windows/apps/dn281101) メソッドを呼び出して、そのビューを新しいウィンドウに表示できます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-155">After you create a new view, you can show it in a new window by calling the [**ApplicationViewSwitcher.TryShowAsStandaloneAsync**](https://msdn.microsoft.com/library/windows/apps/dn281101) method.</span></span> <span data-ttu-id="7f14a-156">このメソッドの *viewId* パラメーターはアプリの各ビューを一意に識別する整数です。</span><span class="sxs-lookup"><span data-stu-id="7f14a-156">The *viewId* parameter for this method is an integer that uniquely identifies each of the views in your app.</span></span> <span data-ttu-id="7f14a-157">ビュー [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) は、**ApplicationView.Id** プロパティまたは [**ApplicationView.GetApplicationViewIdForWindow**](https://msdn.microsoft.com/library/windows/apps/dn281109) メソッドを使って取得できます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-157">You retrieve the view [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) by using either the **ApplicationView.Id** property or the [**ApplicationView.GetApplicationViewIdForWindow**](https://msdn.microsoft.com/library/windows/apps/dn281109) method.</span></span>

    ```csharp
    bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
    ```

## <a name="the-main-view"></a><span data-ttu-id="7f14a-158">メイン ビュー</span><span class="sxs-lookup"><span data-stu-id="7f14a-158">The main view</span></span>


<span data-ttu-id="7f14a-159">アプリの起動時に最初に作成されるビューは、*メイン ビュー*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-159">The first view that’s created when your app starts is called the *main view*.</span></span> <span data-ttu-id="7f14a-160">このビューは、[**CoreApplication.MainView**](https://msdn.microsoft.com/library/windows/apps/hh700465) プロパティに格納され、その [**IsMain**](https://msdn.microsoft.com/library/windows/apps/hh700452) プロパティは true です。</span><span class="sxs-lookup"><span data-stu-id="7f14a-160">This view is stored in the [**CoreApplication.MainView**](https://msdn.microsoft.com/library/windows/apps/hh700465) property, and its [**IsMain**](https://msdn.microsoft.com/library/windows/apps/hh700452) property is true.</span></span> <span data-ttu-id="7f14a-161">このビューは作成しません。アプリによって作成されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-161">You don’t create this view; it’s created by the app.</span></span> <span data-ttu-id="7f14a-162">メイン ビューのスレッドはアプリのマネージャーとして機能し、すべてのアプリの起動イベントはこのスレッドに振り分けられます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-162">The main view's thread serves as the manager for the app, and all app activation events are delivered on this thread.</span></span>

<span data-ttu-id="7f14a-163">セカンダリ ビューが開いている場合は、ウィンドウのタイトル バーの閉じるボタン (x) をクリックするなどして、メイン ビューのウィンドウを非表示にすることができます。ただし、そのスレッドはアクティブのままになります。</span><span class="sxs-lookup"><span data-stu-id="7f14a-163">If secondary views are open, the main view’s window can be hidden – for example, by clicking the close (x) button in the window title bar - but its thread remains active.</span></span> <span data-ttu-id="7f14a-164">メイン ビューの [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) で [**Close**](https://msdn.microsoft.com/library/windows/apps/br209049) を呼び出すと、**InvalidOperationException** が発生します </span><span class="sxs-lookup"><span data-stu-id="7f14a-164">Calling [**Close**](https://msdn.microsoft.com/library/windows/apps/br209049) on the main view’s [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) causes an **InvalidOperationException** to occur.</span></span> <span data-ttu-id="7f14a-165">([**Application.Exit**](https://msdn.microsoft.com/library/windows/apps/br242327) を使ってアプリを閉じます)。メイン ビューのスレッドが終了した場合、アプリは終了します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-165">(Use [**Application.Exit**](https://msdn.microsoft.com/library/windows/apps/br242327) to close your app.) If the main view’s thread is terminated, the app closes.</span></span>

## <a name="secondary-views"></a><span data-ttu-id="7f14a-166">セカンダリ ビュー</span><span class="sxs-lookup"><span data-stu-id="7f14a-166">Secondary views</span></span>


<span data-ttu-id="7f14a-167">アプリのコードで [**CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) を呼び出すことで作成するすべてのビューなど、その他のビューがセカンダリ ビューです。</span><span class="sxs-lookup"><span data-stu-id="7f14a-167">Other views, including all views that you create by calling [**CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) in your app code, are secondary views.</span></span> <span data-ttu-id="7f14a-168">メイン ビューとセカンダリ ビューの両方が [**CoreApplication.Views**](https://msdn.microsoft.com/library/windows/apps/br205861) コレクションに格納されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-168">Both the main view and secondary views are stored in the [**CoreApplication.Views**](https://msdn.microsoft.com/library/windows/apps/br205861) collection.</span></span> <span data-ttu-id="7f14a-169">通常、ユーザーの操作に応じてセカンダリ ビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-169">Typically, you create secondary views in response to a user action.</span></span> <span data-ttu-id="7f14a-170">システムによってアプリのセカンダリ ビューが作成される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="7f14a-170">In some instances, the system creates secondary views for your app.</span></span>

> [!NOTE]
> <span data-ttu-id="7f14a-171">Windows の*割り当てられたアクセス*機能を使うと、[キオスク モード](https://technet.microsoft.com/library/mt219050.aspx)でアプリを実行できます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-171">You can use the Windows *assigned access* feature to run an app in [kiosk mode](https://technet.microsoft.com/library/mt219050.aspx).</span></span> <span data-ttu-id="7f14a-172">この場合、システムによってロック画面に、アプリの UI を表示するセカンダリ ビューが作成されます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-172">When you do this, the system creates a secondary view to present your app UI above the lock screen.</span></span> <span data-ttu-id="7f14a-173">アプリによるセカンダリ ビューの作成は許可されないため、キオスク モードで独自のセカンダリ ビューを表示しようとすると、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-173">App-created secondary views are not allowed, so if you try to show your own secondary view in kiosk mode, an exception is thrown.</span></span>

## <a name="switch-from-one-view-to-another"></a><span data-ttu-id="7f14a-174">ビュー間の切り替え</span><span class="sxs-lookup"><span data-stu-id="7f14a-174">Switch from one view to another</span></span>

<span data-ttu-id="7f14a-175">ユーザーには、セカンダリ ウィンドウから親ウィンドウに戻る方法を提供することを検討します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-175">Consider providing a way for the user to navigate from a secondary window back to its parent window.</span></span> <span data-ttu-id="7f14a-176">そのためには、[**ApplicationViewSwitcher.SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-176">To do this, use the [**ApplicationViewSwitcher.SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097) method.</span></span> <span data-ttu-id="7f14a-177">このメソッドを切り替え元のウィンドウのスレッドから呼び出し、切り替え先のウィンドウのビュー ID を渡します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-177">You call this method from the thread of the window you're switching from and pass the view ID of the window you're switching to.</span></span>

```csharp
await ApplicationViewSwitcher.SwitchAsync(viewIdToShow);
```

<span data-ttu-id="7f14a-178">[**SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097) を使うときは、[**ApplicationViewSwitchingOptions**](https://msdn.microsoft.com/library/windows/apps/dn281105) の値を指定することで、最初のウィンドウを閉じてタスク バーから削除するかどうかを選べます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-178">When you use [**SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097), you can choose if you want to close the initial window and remove it from the taskbar by specifying the value of [**ApplicationViewSwitchingOptions**](https://msdn.microsoft.com/library/windows/apps/dn281105).</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="7f14a-179">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="7f14a-179">Do's and don'ts</span></span>

* <span data-ttu-id="7f14a-180">「新しいウィンドウを開く」のグリフを利用することにより、セカンダリ ビューへの明確なエントリ ポイントを提供します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-180">Do provide a clear entry point to the secondary view by utilizing the "open new window" glyph.</span></span>
* <span data-ttu-id="7f14a-181">セカンダリ ビューの目的をユーザーに伝えます。</span><span class="sxs-lookup"><span data-stu-id="7f14a-181">Do communicate the purpose of the secondary view to users.</span></span>
* <span data-ttu-id="7f14a-182">アプリが単一のビューでも完全に機能することを確認します。セカンダリ ビューは利便性のためのみに提供します。</span><span class="sxs-lookup"><span data-stu-id="7f14a-182">Do ensure that your app works is fully functional in a single view and users will open a secondary view only for convenience.</span></span>
* <span data-ttu-id="7f14a-183">通知やその他の一時的な視覚効果を提供するためにセカンダリ ビューを使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="7f14a-183">Don't rely on the secondary view to provide notifications or other transient visuals.</span></span>

## <a name="related-topics"></a><span data-ttu-id="7f14a-184">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7f14a-184">Related topics</span></span>

* [<span data-ttu-id="7f14a-185">ApplicationViewSwitcher</span><span class="sxs-lookup"><span data-stu-id="7f14a-185">ApplicationViewSwitcher</span></span>](https://msdn.microsoft.com/library/windows/apps/dn281094)
* [<span data-ttu-id="7f14a-186">CreateNewView</span><span class="sxs-lookup"><span data-stu-id="7f14a-186">CreateNewView</span></span>](https://msdn.microsoft.com/library/windows/apps/dn297278)
 
