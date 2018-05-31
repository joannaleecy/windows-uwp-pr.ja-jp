---
author: stevewhims
description: このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。
title: C++/WinRT でデリゲートを使用してイベントを処理する
ms.author: stwhi
ms.date: 04/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、プロジェクション、処理、イベント、デリゲート
ms.localizationpriority: medium
ms.openlocfilehash: 44eb49e0e9797ec363c160ef701e19b58f8227a1
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832016"
---
# <a name="handle-events-by-using-delegates-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="599a8-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのデリゲートを使用したイベントの処理</span><span class="sxs-lookup"><span data-stu-id="599a8-104">Handle events by using delegates in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
> [!NOTE]
> **<span data-ttu-id="599a8-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="599a8-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="599a8-106">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="599a8-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="599a8-107">このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="599a8-107">This topic shows how to register and revoke event-handling delegates using C++/WinRT.</span></span> <span data-ttu-id="599a8-108">標準的な C++ 関数のようなオブジェクトを使用してイベントを処理できます。</span><span class="sxs-lookup"><span data-stu-id="599a8-108">You can handle an event using any standard C++ function-like object.</span></span>

> [!NOTE]
> <span data-ttu-id="599a8-109">現在利用可能な C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) の詳細については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="599a8-109">For info about the current availability of the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

## <a name="register-a-delegate-to-handle-an-event"></a><span data-ttu-id="599a8-110">デリゲートを登録してイベントを処理する</span><span class="sxs-lookup"><span data-stu-id="599a8-110">Register a delegate to handle an event</span></span>
<span data-ttu-id="599a8-111">次に、ボタンのクリック イベントの処理例を示します。</span><span class="sxs-lookup"><span data-stu-id="599a8-111">A simple example is handling a button's click event.</span></span> <span data-ttu-id="599a8-112">通常、イベントを処理するメンバー関数を登録するには、次のように XAML マークアップを使用します。</span><span class="sxs-lookup"><span data-stu-id="599a8-112">It's typical to use XAML markup to register a member function to handle the event, like this.</span></span>

```xaml
// MainPage.xaml
<Button x:Name="Button" Click="ClickHandler">Click Me</Button>
```

```cppwinrt
// MainPage.cpp
void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
{
    Button().Content(box_value(L"Clicked"));
}
```

<span data-ttu-id="599a8-113">マークアップで宣言する代わりに、イベントを処理するメンバー関数を命令を使って登録することができます。</span><span class="sxs-lookup"><span data-stu-id="599a8-113">Instead of doing it declaratively in markup, you can imperatively register a member function to handle an event.</span></span> <span data-ttu-id="599a8-114">以下のコード例からは分かりにくいかもしれませんが、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) 呼び出しの引数は [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) デリゲートのインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="599a8-114">It may not be obvious from the code example below, but the argument to the [**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) call is an instance of the [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) delegate.</span></span> <span data-ttu-id="599a8-115">この場合、メンバー関数へのオブジェクトとポインターを取得する **RoutedEventHandler** コンストラクター オーバーロードを使用しています。</span><span class="sxs-lookup"><span data-stu-id="599a8-115">In this case, we're using the **RoutedEventHandler** constructor overload that takes an object and a pointer-to-member-function.</span></span>

```cppwinrt
// MainPage.cpp
MainPage::MainPage()
{
    InitializeComponent();

    Button().Click({ this, &MainPage::ClickHandler });
}
```

<span data-ttu-id="599a8-116">**RoutedEventHandler** の作成には他の方法もあります。</span><span class="sxs-lookup"><span data-stu-id="599a8-116">There are other ways to construct a **RoutedEventHandler**.</span></span> <span data-ttu-id="599a8-117">次に、[**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) のドキュメント内にある構文ブロックを示します (ページの [**言語**] ドロップダウンから [*C++/WinRT*] を選択)。</span><span class="sxs-lookup"><span data-stu-id="599a8-117">Below is the syntax block taken from the documentation topic for [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) (choose *C++/WinRT* from the **Language** drop-down on the page).</span></span> <span data-ttu-id="599a8-118">さまざまなコンストラクターがあることに注意してください。ラムダ、自由関数、メンバー関数へのオブジェクトとポインター (上記で使用したもの) を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="599a8-118">Notice the various constructors: one takes a lambda; another a free function; and another (the one we used above) takes an object and a pointer-to-member-function.</span></span>

```cppwinrt
struct RoutedEventHandler : winrt::Windows::Foundation::IUnknown
{
    RoutedEventHandler(std::nullptr_t = nullptr) noexcept;
    template <typename L> RoutedEventHandler(L lambda);
    template <typename F> RoutedEventHandler(F* function);
    template <typename O, typename M> RoutedEventHandler(O* object, M method);
    void operator()(winrt::Windows::Foundation::IInspectable const& sender,
        winrt::Windows::UI::Xaml::RoutedEventArgs const& e) const;
};
```

<span data-ttu-id="599a8-119">また、関数呼び出し演算子の構文も確認に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="599a8-119">The syntax of the function call operator is also helpful to see.</span></span> <span data-ttu-id="599a8-120">必要なデリケートのパラメーターを通知します。</span><span class="sxs-lookup"><span data-stu-id="599a8-120">It tells you what your delegate's parameters need to be.</span></span> <span data-ttu-id="599a8-121">ご覧のように、この場合、関数呼び出し演算子の構文は **MainPage::ClickHandler** のパラメーターと一致します。</span><span class="sxs-lookup"><span data-stu-id="599a8-121">As you can see, in this case the function call operator syntax matches the parameters of our **MainPage::ClickHandler**.</span></span>

<span data-ttu-id="599a8-122">イベント ハンドラーで多くの処理を行っていない場合は、メンバー関数の代わりにラムダ関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="599a8-122">If you're not doing much work in your event handler, then you can use a lambda function instead of a member function.</span></span> <span data-ttu-id="599a8-123">以下のコード例からは分かりにくいかもしれませんが、**RoutedEventHandler** デリゲートはラムダ関数から作成されているため、関数呼び出し演算子の構文ともう一度一致させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="599a8-123">Again, it may not be obvious from the code example below, but a **RoutedEventHandler** delegate is being constructed from a lambda function which, again, needs to match the syntax of the function call operator.</span></span>

```cppwinrt
MainPage::MainPage()
{
    InitializeComponent();

    Button().Click([this](IInspectable const&, RoutedEventArgs const&)
    {
        Button().Content(box_value(L"Clicked"));
    });
}
```

<span data-ttu-id="599a8-124">デリゲートを作成する場合にもう少し明示的に指定することができます。</span><span class="sxs-lookup"><span data-stu-id="599a8-124">You can choose to be a little more explicit when you construct your delegate.</span></span> <span data-ttu-id="599a8-125">たとえば、次のように渡したり、何回も使用したりする場合です。</span><span class="sxs-lookup"><span data-stu-id="599a8-125">For example, if you want to pass it around, or use it more than once.</span></span>

```cppwinrt
MainPage::MainPage()
{
    InitializeComponent();

    auto click_handler = [](IInspectable const& sender, RoutedEventArgs const&)
    {
        sender.as<winrt::Windows::UI::Xaml::Controls::Button>().Content(box_value(L"Clicked"));
    };
    Button().Click(click_handler);
    AnotherButton().Click(click_handler);
}
```

## <a name="revoke-a-registered-delegate"></a><span data-ttu-id="599a8-126">登録済みデリゲートの取り消し</span><span class="sxs-lookup"><span data-stu-id="599a8-126">Revoke a registered delegate</span></span>
<span data-ttu-id="599a8-127">デリゲートを登録すると、通常、トークンがユーザーに返されます。</span><span class="sxs-lookup"><span data-stu-id="599a8-127">When you register a delegate, typically a token is returned to you.</span></span> <span data-ttu-id="599a8-128">その後、このトークンを使用してデリゲートを取り消すことができます。つまり、このトークンはイベントから登録解除され、イベントが再び発生しても呼び出されることはありません。</span><span class="sxs-lookup"><span data-stu-id="599a8-128">You can subsequently use that token to revoke your delegate; meaning that the delegate is unregistered from the event, and won't be called should the event be raised again.</span></span> <span data-ttu-id="599a8-129">説明を簡単にするために、上記の例にはその方法を示すコードは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="599a8-129">For the sake of simplicity, none of the code examples above showed how to do that.</span></span> <span data-ttu-id="599a8-130">ただし、次のコード例では、トークンを構造体のプライベート データ メンバーに格納し、デストラクターの該当するハンドラーを取り消しています。</span><span class="sxs-lookup"><span data-stu-id="599a8-130">But this next code example stores the token in the struct's private data member, and revokes its handler in the destructor.</span></span>

```cppwinrt
struct Example : ExampleT<Example>
{
    Example(winrt::Windows::UI::Xaml::Controls::Button const& button) : m_button(button)
    {
        m_token = m_button.Click([this](IInspectable const&, RoutedEventArgs const&)
        {
            ...
        });
    }
    ~Example()
    {
        m_button.Click(m_token);
    }

private:
    winrt::Windows::UI::Xaml::Controls::Button m_button;
    winrt::event_token m_token;
};
```

<span data-ttu-id="599a8-131">または、デリゲートを登録する場合、**winrt::auto_revoke** (型 [**winrt::auto_revoke_t**](/uwp/cpp-ref-for-winrt/auto-revoke-t) の値) を指定してイベント リボーカーを要求できます。</span><span class="sxs-lookup"><span data-stu-id="599a8-131">Alternatively, when you register a delegate, you can specify **winrt::auto_revoke** (which is a value of type [**winrt::auto_revoke_t**](/uwp/cpp-ref-for-winrt/auto-revoke-t)) to request an event revoker.</span></span> <span data-ttu-id="599a8-132">このリボーカーが範囲外になると、デリゲートが自動的に取り消されます。</span><span class="sxs-lookup"><span data-stu-id="599a8-132">When that revoker goes out of scope, it automatically revokes your delegate.</span></span> <span data-ttu-id="599a8-133">次の例では、イベント ソースを格納する必要がないため、デストラクターは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="599a8-133">In this example, there's no need to store the event source, and no need for a destructor.</span></span>

```cppwinrt
struct Example : ExampleT<Example>
{
    Example(winrt::Windows::UI::Xaml::Controls::Button button)
    {
        m_event_revoker = button.Click(winrt::auto_revoke, [this](IInspectable const&, RoutedEventArgs const&)
        {
            ...
        });
    }

private:
    winrt::event_revoker<winrt::Windows::UI::Xaml::Controls::Primitives::IButtonBase> m_event_revoker;
};
```

<span data-ttu-id="599a8-134">次の構文ブロックは、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) イベントのドキュメント トピックからの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="599a8-134">Below is the syntax block taken from the documentation topic for the [**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) event.</span></span> <span data-ttu-id="599a8-135">3 つの異なる登録と取り消し関数を示しています。</span><span class="sxs-lookup"><span data-stu-id="599a8-135">It shows the three different registration and revoking functions.</span></span> <span data-ttu-id="599a8-136">3 番目のオーバーロードから宣言する必要があるイベント リボーカーの型を正確に確認できます。</span><span class="sxs-lookup"><span data-stu-id="599a8-136">You can see exactly what type of event revoker you need to declare from the third overload.</span></span>

```cppwinrt
// Register
winrt::event_token Click(winrt::Windows::UI::Xaml::RoutedEventHandler const& handler) const;

// Revoke with event_token
void Click(winrt::event_token const& token) const;

// Revoke with event_revoker
event_revoker<winrt::Windows::UI::Xaml::Controls::Primitives::IButtonBase> Click(winrt::auto_revoke_t,
    winrt::Windows::UI::Xaml::RoutedEventHandler const& handler) const;
```

<span data-ttu-id="599a8-137">同じようなパターンがすべての C++/WinRT イベントに適用されます。</span><span class="sxs-lookup"><span data-stu-id="599a8-137">A similar pattern applies to all C++/WinRT events.</span></span>

<span data-ttu-id="599a8-138">ページのナビゲーションのシナリオでハンドラーの取り消しを検討します。</span><span class="sxs-lookup"><span data-stu-id="599a8-138">You might consider revoking handlers in a page-navigation scenario.</span></span> <span data-ttu-id="599a8-139">あるページへの移動を繰り返す場合、そのページから移動する際にハンドラーを取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="599a8-139">If you're repeatedly navigating into a page and then back out, then you could revoke any handlers when you navigate away from the page.</span></span> <span data-ttu-id="599a8-140">または、同じページ インスタンスを再使用しているときは、トークンの値を確認し、(`if (!m_token){ ... }`) がまだ設定されていない場合のみ登録します。</span><span class="sxs-lookup"><span data-stu-id="599a8-140">Alternatively, if you're re-using the same page instance, then check the value of your token and only register if it's not yet been set (`if (!m_token){ ... }`).</span></span> <span data-ttu-id="599a8-141">3 番目のオプションでは、ページにイベント リボーカーをデータ メンバーとして格納します。</span><span class="sxs-lookup"><span data-stu-id="599a8-141">A third option is to store an event revoker in the page as a data member.</span></span> <span data-ttu-id="599a8-142">このトピック後半で紹介する 4 番目のオプションでは、ラムダ関数内の*この*オブジェクトの強参照または弱参照をキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="599a8-142">And a fourth option, as described later in this topic, is to capture a strong or a weak reference to the *this* object in your lambda function.</span></span>

## <a name="delegate-types-for-asynchronous-actions-and-operations"></a><span data-ttu-id="599a8-143">非同期アクションと非同期操作のデリゲート型</span><span class="sxs-lookup"><span data-stu-id="599a8-143">Delegate types for asynchronous actions and operations</span></span>
<span data-ttu-id="599a8-144">上記の例では、**RoutedEventHandler** デリゲート型を使用していますが、他にも多くのデリゲート型があります。</span><span class="sxs-lookup"><span data-stu-id="599a8-144">The examples above use the **RoutedEventHandler** delegate type, but there are of course many other delegate types.</span></span> <span data-ttu-id="599a8-145">たとえば、非同期アクションと非同期操作 (進行状況ありとなし) には、対応するデリゲート型を必要とする完了イベントと進行状況イベントがあります。</span><span class="sxs-lookup"><span data-stu-id="599a8-145">For example, asynchronous actions and operations (with and without progress) have completed and/or progress events that expect delegates of the corresponding type.</span></span> <span data-ttu-id="599a8-146">たとえば、進行状況ありの非同期操作の進行状況イベント ([**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) を実装する任意のイベント) には、[**AsyncOperationProgressHandler**](/uwp/api/windows.foundation.asyncoperationprogresshandler) のデリゲート型が必要です。</span><span class="sxs-lookup"><span data-stu-id="599a8-146">For example, the progress event of an asynchronous operation with progress (which is anything that implements [**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)) requires a delegate of type [**AsyncOperationProgressHandler**](/uwp/api/windows.foundation.asyncoperationprogresshandler).</span></span> <span data-ttu-id="599a8-147">次に、ラムダ関数を使用してこの型のデリゲートを作成するコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="599a8-147">Here's a code example of authoring a delegate of that type using a lambda function.</span></span> <span data-ttu-id="599a8-148">この例は、[**AsyncOperationWithProgressCompletedHandler**](/uwp/api/windows.foundation.asyncoperationwithprogresscompletedhandler) デリゲートの作成方法も示しています。</span><span class="sxs-lookup"><span data-stu-id="599a8-148">The example also shows how to author an [**AsyncOperationWithProgressCompletedHandler**](/uwp/api/windows.foundation.asyncoperationwithprogresscompletedhandler) delegate.</span></span>

```cppwinrt
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

void ProcessFeedAsync()
{
    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;

    auto async_op_with_progress = syndicationClient.RetrieveFeedAsync(rssFeedUri);

    async_op_with_progress.Progress(
        [](IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress> const&, RetrievalProgress const& args)
    {
        uint32_t bytes_retrieved = args.BytesRetrieved;
        // use bytes_retrieved;
    });

    async_op_with_progress.Completed(
        [](IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress> const& sender, AsyncStatus const)
    {
        SyndicationFeed syndicationFeed = sender.GetResults();
        // use syndicationFeed;
    });
    
    // or (but this function must then return IAsyncAction)
    // SyndicationFeed syndicationFeed = co_await async_op_with_progress;
}
```

<span data-ttu-id="599a8-149">上記のコメントからも分かるように、非同期アクションと非同期操作の完了イベントでデリゲートを使用するよりも、コルーチンを使用するほうがより自然です。</span><span class="sxs-lookup"><span data-stu-id="599a8-149">As the comment above suggests, instead of using a delegate with the completed events of asynchronous actions and operations, you'll probably find it more natural to use coroutines.</span></span> <span data-ttu-id="599a8-150">詳細とコード例については、「[C++/WinRT を使用した同時実行操作と非同期操作](concurrency.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="599a8-150">For details, and code examples, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md).</span></span>

## <a name="delegate-types-that-return-a-value"></a><span data-ttu-id="599a8-151">値を返すデリゲート型</span><span class="sxs-lookup"><span data-stu-id="599a8-151">Delegate types that return a value</span></span>
<span data-ttu-id="599a8-152">一部のデリゲート型では自身に値を戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="599a8-152">Some delegate types must themselves return a value.</span></span> <span data-ttu-id="599a8-153">たとえば、[**ListViewItemToKeyHandler**](/uwp/api/windows.ui.xaml.controls.listviewitemtokeyhandler) は文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="599a8-153">An example is [**ListViewItemToKeyHandler**](/uwp/api/windows.ui.xaml.controls.listviewitemtokeyhandler), which returns a string.</span></span> <span data-ttu-id="599a8-154">次に、このような型のデリゲートの作成例を示します (ラムダ関数が値を返します)。</span><span class="sxs-lookup"><span data-stu-id="599a8-154">Here's an example of authoring a delegate of that type (note that the lambda function returns a value).</span></span>

```cppwinrt
using namespace winrt::Windows::UI::Xaml::Controls;

winrt::hstring f(ListView listview)
{
    return ListViewPersistenceHelper::GetRelativeScrollPosition(listview, [](IInspectable const& item)
    {
        return L"key for item goes here";
    });
}
```

## <a name="using-the-this-object-in-an-event-handler"></a><span data-ttu-id="599a8-155">イベント ハンドラーでの*この*オブジェクトの使用</span><span class="sxs-lookup"><span data-stu-id="599a8-155">Using the *this* object in an event handler</span></span>
<span data-ttu-id="599a8-156">オブジェクトのメンバー関数内にあるラムダ関数のイベントを処理する場合は、イベント受信側 (イベントを処理するオブジェクト) とイベント ソース (イベントを発生させるオブジェクト) の相対的な有効期間を考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="599a8-156">If you handle an event from within a lambda function inside an object's member function, then you need to think about the relative lifetimes of the event recipient (the object handling the event) and the event source (the object raising the event).</span></span>

<span data-ttu-id="599a8-157">多くの場合、受信側は、任意のラムダ関数内にある自身の*この*ポインターのすべての依存関係を失います。</span><span class="sxs-lookup"><span data-stu-id="599a8-157">In many cases, a recipient outlives all dependencies on its *this* pointer from within a given lambda function.</span></span> <span data-ttu-id="599a8-158">UI ページでそのページ上にあるコントロールで発生したイベントを処理するときなど、明らかな場合があります。</span><span class="sxs-lookup"><span data-stu-id="599a8-158">Some of these cases are obvious, such as when a UI page handles an event raised by a control that's on the page.</span></span> <span data-ttu-id="599a8-159">ボタンがページ上に表示されないため、ハンドラーも表示されません。</span><span class="sxs-lookup"><span data-stu-id="599a8-159">The button doesn't outlive the page, so neither does the handler.</span></span> <span data-ttu-id="599a8-160">これは、受信側がソースを所有する場合 (データ メンバーとしてなど)、または受信側とソースが兄弟関係にあり、他のオブジェクトによって直接所有されている場合に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="599a8-160">This holds true any time the recipient owns the source (as a data member, for example), or any time the recipient and the source are siblings and directly owned by some other object.</span></span> <span data-ttu-id="599a8-161">ハンドラーが依存する*このオブジェクト*に表示されない場合、有効期間の強弱を気にしなくても、通常どおり*このオブジェクト*をキャプチャできます。</span><span class="sxs-lookup"><span data-stu-id="599a8-161">If you're sure you have a case where the handler won't outlive the *this* that it depends on, then you can capture *this* normally, without consideration for strong or weak lifetime.</span></span>

<span data-ttu-id="599a8-162">ただし、*このオブジェクト*がハンドラー内の自身の用途に表示されない場合などもあります (非同期アクションと非同期操作によって発生する完了イベントと進行状況イベントのハンドラーなど)。</span><span class="sxs-lookup"><span data-stu-id="599a8-162">But there are still cases where *this* doesn't outlive its use in a handler (including handlers for completion and progress events raised by asynchronous actions and operations).</span></span>

- <span data-ttu-id="599a8-163">非同期メソッドを実装するためにコルーチンを作成する場合は可能です。</span><span class="sxs-lookup"><span data-stu-id="599a8-163">If you're authoring a coroutine to implement an asynchronous method, then it's possible.</span></span>
- <span data-ttu-id="599a8-164">特定の XAML UI フレームワーク オブジェクト ([**SwapChainPanel**](/uwp/api/windows.ui.xaml.controls.swapchainpanel) など) を使用するまれなケースで、イベント ソースから登録解除しなくても、受信側が最終処理される場合は可能です。</span><span class="sxs-lookup"><span data-stu-id="599a8-164">In rare cases with certain XAML UI framework objects ([**SwapChainPanel**](/uwp/api/windows.ui.xaml.controls.swapchainpanel), for example), then it's possible, if the recipient is finalized without unregistering from the event source.</span></span>

<span data-ttu-id="599a8-165">このような場合、*この*無効なオブジェクトを使用してハンドラーまたはコルーチンが継続するため、アクセス違反になります。</span><span class="sxs-lookup"><span data-stu-id="599a8-165">In these cases, an access violation results from code in a handler or in a coroutine's continuation attempting to use the invalid *this* object.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="599a8-166">このいずれかの状況になった場合は、キャプチャした*この*オブジェクトのキャプチャの状態を続けるかどうか、*この*オブジェクトの有効期間を検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="599a8-166">If you encounter one of these situations, then you'll need to think about the lifetime of the *this* object; and whether or not the captured *this* object outlives the capture.</span></span> <span data-ttu-id="599a8-167">それ以外の場合は、強参照または弱参照を使用してオブジェクトを必要に応じてキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="599a8-167">If it doesn't, then capture it with a strong or a weak reference, as appropriate.</span></span> <span data-ttu-id="599a8-168">[**implements::get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) と [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="599a8-168">See [**implements::get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function), and [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function).</span></span>
> <span data-ttu-id="599a8-169">または、シナリオに適している場合、およびスレッドの考慮事項にも対応する場合、受信側のイベントの完了後や受信側のデストラクターで、ハンドラーを取り消すといった別のオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="599a8-169">Or&mdash;if it makes sense for your scenario and if threading considerations make it even possible&mdash;then another option is to revoke the handler after the recipient is done with the event, or in the recipient's destructor.</span></span>

<span data-ttu-id="599a8-170">次のコード例では、[**SwapChainPanel.CompositionScaleChanged**](/uwp/api/windows.ui.xaml.controls.swapchainpanel.compositionscalechanged) イベントを使用しています。</span><span class="sxs-lookup"><span data-stu-id="599a8-170">This code example uses the [**SwapChainPanel.CompositionScaleChanged**](/uwp/api/windows.ui.xaml.controls.swapchainpanel.compositionscalechanged) event as an illustration.</span></span> <span data-ttu-id="599a8-171">受信側の弱参照をキャプチャするラムダを使用して、イベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="599a8-171">It registers an event handler using a lambda that captures a weak reference to the recipient.</span></span> <span data-ttu-id="599a8-172">弱参照の詳細については、「[C++/WinRT の弱参照](weak-references.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="599a8-172">For more info about weak references, see [Weak references in C++/WinRT](weak-references.md).</span></span> 

```cppwinrt
winrt::Windows::UI::Xaml::Controls::SwapChainPanel m_swapChainPanel;
winrt::event_token m_compositionScaleChangedEventToken;

void RegisterEventHandler()
{
    m_compositionScaleChangedEventToken = m_swapChainPanel.CompositionScaleChanged([weakReferenceToThis{ get_weak() }]
        (Windows::UI::Xaml::Controls::SwapChainPanel const& sender,
        Windows::Foundation::IInspectable const& object)
    {
        if (auto strongReferenceToThis = weakReferenceToThis.get())
        {
            strongReferenceToThis->OnCompositionScaleChanged(sender, object);
        }
    });
}

void OnCompositionScaleChanged(Windows::UI::Xaml::Controls::SwapChainPanel const& sender,
    Windows::Foundation::IInspectable const& object)
{
    // Here, we know that the "this" object is valid.
}
```

<span data-ttu-id="599a8-173">ラムダのキャプチャ句で、一時変数を作成し、*このオブジェクト*の弱参照を表示します。</span><span class="sxs-lookup"><span data-stu-id="599a8-173">In the lamba capture clause, a temporary variable is created, representing a weak reference to *this*.</span></span> <span data-ttu-id="599a8-174">ラムダ式の本文で、*このオブジェクト*の強参照を取得する場合は、**OnCompositionScaleChanged** 関数が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="599a8-174">In the body of the lambda, if a strong reference to *this* can be obtained, then the **OnCompositionScaleChanged** function is called.</span></span> <span data-ttu-id="599a8-175">これにより、**OnCompositionScaleChanged** 内で*このオブジェクト*を安全に使用することができます。</span><span class="sxs-lookup"><span data-stu-id="599a8-175">That way, inside **OnCompositionScaleChanged**, *this* can safely be used.</span></span>

## <a name="important-apis"></a><span data-ttu-id="599a8-176">重要な API</span><span class="sxs-lookup"><span data-stu-id="599a8-176">Important APIs</span></span>
* [<span data-ttu-id="599a8-177">winrt::auto_revoke_t</span><span class="sxs-lookup"><span data-stu-id="599a8-177">winrt::auto_revoke_t</span></span>](/uwp/cpp-ref-for-winrt/auto-revoke-t)
* [<span data-ttu-id="599a8-178">winrt::implements::get_weak 関数</span><span class="sxs-lookup"><span data-stu-id="599a8-178">winrt::implements::get_weak function</span></span>](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)
* [<span data-ttu-id="599a8-179">winrt::implements::get_strong 関数</span><span class="sxs-lookup"><span data-stu-id="599a8-179">winrt::implements::get_strong function</span></span>](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)

## <a name="related-topics"></a><span data-ttu-id="599a8-180">関連トピック</span><span class="sxs-lookup"><span data-stu-id="599a8-180">Related topics</span></span>
* [<span data-ttu-id="599a8-181">C++/WinRT でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="599a8-181">Author events in C++/WinRT</span></span>](author-events.md)
* [<span data-ttu-id="599a8-182">C++/WinRT の弱参照</span><span class="sxs-lookup"><span data-stu-id="599a8-182">Weak references in C++/WinRT</span></span>](weak-references.md)

