---
description: このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。
title: C++/WinRT でのデリゲートを使用したイベントの処理
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、プロジェクション、処理、イベント、デリゲート
ms.localizationpriority: medium
ms.openlocfilehash: 193d821b44722e150f38da7430504f5d528770a4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602427"
---
# <a name="handle-events-by-using-delegates-in-cwinrt"></a><span data-ttu-id="51f0b-104">C++/WinRT でのデリゲートを使用したイベントの処理</span><span class="sxs-lookup"><span data-stu-id="51f0b-104">Handle events by using delegates in C++/WinRT</span></span>

<span data-ttu-id="51f0b-105">このトピックでは、登録しを使用してイベント処理デリゲートを取り消す方法を示しています。 [C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-105">This topic shows how to register and revoke event-handling delegates using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span> <span data-ttu-id="51f0b-106">標準的な C++ 関数のようなオブジェクトを使用してイベントを処理できます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-106">You can handle an event using any standard C++ function-like object.</span></span>

> [!NOTE]
> <span data-ttu-id="51f0b-107">詳細については、インストールして、C + を使用して/cli WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレートのサポートだけでなく C + を提供する/cli WinRT MSBuild プロパティとターゲット) を参照してください[Visual Studio のサポートの C +/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-107">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package).</span></span>

## <a name="register-a-delegate-to-handle-an-event"></a><span data-ttu-id="51f0b-108">デリゲートを登録してイベントを処理する</span><span class="sxs-lookup"><span data-stu-id="51f0b-108">Register a delegate to handle an event</span></span>

<span data-ttu-id="51f0b-109">次に、ボタンのクリック イベントの処理例を示します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-109">A simple example is handling a button's click event.</span></span> <span data-ttu-id="51f0b-110">通常、イベントを処理するメンバー関数を登録するには、次のように XAML マークアップを使用します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-110">It's typical to use XAML markup to register a member function to handle the event, like this.</span></span>

```xaml
// MainPage.xaml
<Button x:Name="Button" Click="ClickHandler">Click Me</Button>
```

```cppwinrt
// MainPage.cpp
void MainPage::ClickHandler(IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
{
    Button().Content(box_value(L"Clicked"));
}
```

<span data-ttu-id="51f0b-111">マークアップで宣言する代わりに、イベントを処理するメンバー関数を命令を使って登録することができます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-111">Instead of doing it declaratively in markup, you can imperatively register a member function to handle an event.</span></span> <span data-ttu-id="51f0b-112">以下のコード例からは分かりにくいかもしれませんが、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) 呼び出しの引数は [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) デリゲートのインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="51f0b-112">It may not be obvious from the code example below, but the argument to the [**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) call is an instance of the [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) delegate.</span></span> <span data-ttu-id="51f0b-113">この場合、メンバー関数へのオブジェクトとポインターを取得する **RoutedEventHandler** コンストラクター オーバーロードを使用しています。</span><span class="sxs-lookup"><span data-stu-id="51f0b-113">In this case, we're using the **RoutedEventHandler** constructor overload that takes an object and a pointer-to-member-function.</span></span>

```cppwinrt
// MainPage.cpp
MainPage::MainPage()
{
    InitializeComponent();

    Button().Click({ this, &MainPage::ClickHandler });
}
```

> [!IMPORTANT]
> <span data-ttu-id="51f0b-114">デリゲートを登録するには、上記のコード例渡します raw*この*(現在のオブジェクトを指す) ポインター。</span><span class="sxs-lookup"><span data-stu-id="51f0b-114">When registered the delegate, the code example above passes a raw *this* pointer (pointing to the current object).</span></span> <span data-ttu-id="51f0b-115">強力なまたは現在のオブジェクトへの弱い参照を確立する方法についてを参照してください、**デリゲートとしてメンバー関数を使用する場合**サブセクションに記載[安全にアクセスする、*この*ポインターイベント処理デリゲートをで](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate)します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-115">To learn how to establish a strong or a weak reference to the current object, see the **If you use a member function as a delegate** sub-section in the section [Safely accessing the *this* pointer with an event-handling delegate](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate).</span></span>

<span data-ttu-id="51f0b-116">**RoutedEventHandler** の作成には他の方法もあります。</span><span class="sxs-lookup"><span data-stu-id="51f0b-116">There are other ways to construct a **RoutedEventHandler**.</span></span> <span data-ttu-id="51f0b-117">次に、[**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) のドキュメント内にある構文ブロックを示します (ページの **[言語]** ドロップダウンから [*C++/WinRT*] を選択)。</span><span class="sxs-lookup"><span data-stu-id="51f0b-117">Below is the syntax block taken from the documentation topic for [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) (choose *C++/WinRT* from the **Language** drop-down on the page).</span></span> <span data-ttu-id="51f0b-118">さまざまなコンストラクターがあることに注意してください。ラムダ、自由関数、メンバー関数へのオブジェクトとポインター (上記で使用したもの) を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="51f0b-118">Notice the various constructors: one takes a lambda; another a free function; and another (the one we used above) takes an object and a pointer-to-member-function.</span></span>

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

<span data-ttu-id="51f0b-119">また、関数呼び出し演算子の構文も確認に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-119">The syntax of the function call operator is also helpful to see.</span></span> <span data-ttu-id="51f0b-120">必要なデリケートのパラメーターを通知します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-120">It tells you what your delegate's parameters need to be.</span></span> <span data-ttu-id="51f0b-121">ご覧のように、この場合、関数呼び出し演算子の構文は **MainPage::ClickHandler** のパラメーターと一致します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-121">As you can see, in this case the function call operator syntax matches the parameters of our **MainPage::ClickHandler**.</span></span>

<span data-ttu-id="51f0b-122">イベント ハンドラーで多くの処理を行っていない場合は、メンバー関数の代わりにラムダ関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-122">If you're not doing much work in your event handler, then you can use a lambda function instead of a member function.</span></span> <span data-ttu-id="51f0b-123">以下のコード例からは分かりにくいかもしれませんが、**RoutedEventHandler** デリゲートはラムダ関数から作成されているため、関数呼び出し演算子の構文ともう一度一致させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="51f0b-123">Again, it may not be obvious from the code example below, but a **RoutedEventHandler** delegate is being constructed from a lambda function which, again, needs to match the syntax of the function call operator.</span></span>

```cppwinrt
MainPage::MainPage()
{
    InitializeComponent();

    Button().Click([this](IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
    {
        Button().Content(box_value(L"Clicked"));
    });
}
```

<span data-ttu-id="51f0b-124">デリゲートを作成する場合にもう少し明示的に指定することができます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-124">You can choose to be a little more explicit when you construct your delegate.</span></span> <span data-ttu-id="51f0b-125">たとえば、次のように渡したり、何回も使用したりする場合です。</span><span class="sxs-lookup"><span data-stu-id="51f0b-125">For example, if you want to pass it around, or use it more than once.</span></span>

```cppwinrt
MainPage::MainPage()
{
    InitializeComponent();

    auto click_handler = [](IInspectable const& sender, RoutedEventArgs const& /* args */)
    {
        sender.as<winrt::Windows::UI::Xaml::Controls::Button>().Content(box_value(L"Clicked"));
    };
    Button().Click(click_handler);
    AnotherButton().Click(click_handler);
}
```

## <a name="revoke-a-registered-delegate"></a><span data-ttu-id="51f0b-126">登録済みデリゲートの取り消し</span><span class="sxs-lookup"><span data-stu-id="51f0b-126">Revoke a registered delegate</span></span>

<span data-ttu-id="51f0b-127">デリゲートを登録すると、通常、トークンがユーザーに返されます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-127">When you register a delegate, typically a token is returned to you.</span></span> <span data-ttu-id="51f0b-128">その後、このトークンを使用してデリゲートを取り消すことができます。つまり、このトークンはイベントから登録解除され、イベントが再び発生しても呼び出されることはありません。</span><span class="sxs-lookup"><span data-stu-id="51f0b-128">You can subsequently use that token to revoke your delegate; meaning that the delegate is unregistered from the event, and won't be called should the event be raised again.</span></span> <span data-ttu-id="51f0b-129">説明を簡単にするために、上記の例にはその方法を示すコードは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="51f0b-129">For the sake of simplicity, none of the code examples above showed how to do that.</span></span> <span data-ttu-id="51f0b-130">ただし、次のコード例では、トークンを構造体のプライベート データ メンバーに格納し、デストラクターの該当するハンドラーを取り消しています。</span><span class="sxs-lookup"><span data-stu-id="51f0b-130">But this next code example stores the token in the struct's private data member, and revokes its handler in the destructor.</span></span>

```cppwinrt
struct Example : ExampleT<Example>
{
    Example(winrt::Windows::UI::Xaml::Controls::Button const& button) : m_button(button)
    {
        m_token = m_button.Click([this](IInspectable const&, RoutedEventArgs const&)
        {
            // ...
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

<span data-ttu-id="51f0b-131">上記の例のように、強力な参照の代わりに、ボタンへの弱い参照を格納できます (を参照してください[強力と脆弱の参照を c++/cli WinRT](weak-references.md))。</span><span class="sxs-lookup"><span data-stu-id="51f0b-131">Instead of a strong reference, as in the example above, you can store a weak reference to the button (see [Strong and weak references in C++/WinRT](weak-references.md)).</span></span>

<span data-ttu-id="51f0b-132">また、デリゲートを登録するときに指定できます**winrt::auto_revoke** (型の値である[ **winrt::auto_revoke_t**](/uwp/cpp-ref-for-winrt/auto-revoke-t))、イベント revoker (を要求するには型[ **winrt::event_revoker**](/uwp/cpp-ref-for-winrt/event-revoker))。</span><span class="sxs-lookup"><span data-stu-id="51f0b-132">Alternatively, when you register a delegate, you can specify **winrt::auto_revoke** (which is a value of type [**winrt::auto_revoke_t**](/uwp/cpp-ref-for-winrt/auto-revoke-t)) to request an event revoker (of type [**winrt::event_revoker**](/uwp/cpp-ref-for-winrt/event-revoker)).</span></span> <span data-ttu-id="51f0b-133">イベント revoker をイベント ソース (イベントを発生させるオブジェクト) への弱い参照を保持します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-133">The event revoker holds a weak reference to the event source (the object that raises the event) for you.</span></span> <span data-ttu-id="51f0b-134">**event_revoker::revoke** メンバー関数を呼び出して手動で取り消すことができますが、イベント リボーカーは参照が範囲外になったときに自動的にその関数自体を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-134">You can manually revoke by calling the **event_revoker::revoke** member function; but the event revoker calls that function itself automatically when it goes out of scope.</span></span> <span data-ttu-id="51f0b-135">**revoke** 関数は、イベント ソースがまだ存在するかどうかを確認し、存在する場合は、デリケートを取り消します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-135">The **revoke** function checks whether the event source still exists and, if so, revokes your delegate.</span></span> <span data-ttu-id="51f0b-136">次の例では、イベント ソースを格納する必要がないため、デストラクターは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="51f0b-136">In this example, there's no need to store the event source, and no need for a destructor.</span></span>

```cppwinrt
struct Example : ExampleT<Example>
{
    Example(winrt::Windows::UI::Xaml::Controls::Button button)
    {
        m_event_revoker = button.Click(winrt::auto_revoke, [this](IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
        {
            // ...
        });
    }

private:
    winrt::Windows::UI::Xaml::Controls::Button::Click_revoker m_event_revoker;
};
```

<span data-ttu-id="51f0b-137">次の構文ブロックは、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) イベントのドキュメント トピックからの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="51f0b-137">Below is the syntax block taken from the documentation topic for the [**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) event.</span></span> <span data-ttu-id="51f0b-138">3 つの異なる登録と取り消し関数を示しています。</span><span class="sxs-lookup"><span data-stu-id="51f0b-138">It shows the three different registration and revoking functions.</span></span> <span data-ttu-id="51f0b-139">3 番目のオーバーロードから宣言する必要があるイベント リボーカーの型を正確に確認できます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-139">You can see exactly what type of event revoker you need to declare from the third overload.</span></span>

```cppwinrt
// Register
winrt::event_token Click(winrt::Windows::UI::Xaml::RoutedEventHandler const& handler) const;

// Revoke with event_token
void Click(winrt::event_token const& token) const;

// Revoke with event_revoker
Button::Click_revoker Click(winrt::auto_revoke_t,
    winrt::Windows::UI::Xaml::RoutedEventHandler const& handler) const;
```

> [!NOTE]
> <span data-ttu-id="51f0b-140">上記のコード例で`Button::Click_revoker`型エイリアスの`winrt::event_revoker<winrt::Windows::UI::Xaml::Controls::Primitives::IButtonBase>`します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-140">In the code example above, `Button::Click_revoker` is a type alias for `winrt::event_revoker<winrt::Windows::UI::Xaml::Controls::Primitives::IButtonBase>`.</span></span> <span data-ttu-id="51f0b-141">同じようなパターンがすべての C++/WinRT イベントに適用されます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-141">A similar pattern applies to all C++/WinRT events.</span></span> <span data-ttu-id="51f0b-142">各 Windows ランタイム イベントでは、revoke 関数のオーバー ロードを返す、イベント revoker とイベント ソースのメンバーである revoker の種類があります。</span><span class="sxs-lookup"><span data-stu-id="51f0b-142">Each Windows Runtime event has a revoke function overload that returns an event revoker, and that revoker's type is a member of the event source.</span></span> <span data-ttu-id="51f0b-143">別の例を実行するように、 [ **CoreWindow::SizeChanged** ](/uwp/api/windows.ui.core.corewindow.sizechanged)イベント型の値を返す登録関数のオーバー ロードには、 **CoreWindow::SizeChanged_revoker**.</span><span class="sxs-lookup"><span data-stu-id="51f0b-143">So, to take another example, the [**CoreWindow::SizeChanged**](/uwp/api/windows.ui.core.corewindow.sizechanged) event has a registration function overload that returns a value of type **CoreWindow::SizeChanged_revoker**.</span></span>


<span data-ttu-id="51f0b-144">ページのナビゲーションのシナリオでハンドラーの取り消しを検討します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-144">You might consider revoking handlers in a page-navigation scenario.</span></span> <span data-ttu-id="51f0b-145">あるページへの移動を繰り返す場合、そのページから移動する際にハンドラーを取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="51f0b-145">If you're repeatedly navigating into a page and then back out, then you could revoke any handlers when you navigate away from the page.</span></span> <span data-ttu-id="51f0b-146">または、同じページ インスタンスを再使用しているときは、トークンの値を確認し、(`if (!m_token){ ... }`) がまだ設定されていない場合のみ登録します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-146">Alternatively, if you're re-using the same page instance, then check the value of your token and only register if it's not yet been set (`if (!m_token){ ... }`).</span></span> <span data-ttu-id="51f0b-147">3 番目のオプションでは、ページにイベント リボーカーをデータ メンバーとして格納します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-147">A third option is to store an event revoker in the page as a data member.</span></span> <span data-ttu-id="51f0b-148">このトピック後半で紹介する 4 番目のオプションでは、ラムダ関数内の*この*オブジェクトの強参照または弱参照をキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="51f0b-148">And a fourth option, as described later in this topic, is to capture a strong or a weak reference to the *this* object in your lambda function.</span></span>

## <a name="delegate-types-for-asynchronous-actions-and-operations"></a><span data-ttu-id="51f0b-149">非同期アクションと非同期操作のデリゲート型</span><span class="sxs-lookup"><span data-stu-id="51f0b-149">Delegate types for asynchronous actions and operations</span></span>

<span data-ttu-id="51f0b-150">上記の例では、**RoutedEventHandler** デリゲート型を使用していますが、他にも多くのデリゲート型があります。</span><span class="sxs-lookup"><span data-stu-id="51f0b-150">The examples above use the **RoutedEventHandler** delegate type, but there are of course many other delegate types.</span></span> <span data-ttu-id="51f0b-151">たとえば、非同期アクションと非同期操作 (進行状況ありとなし) には、対応するデリゲート型を必要とする完了イベントと進行状況イベントがあります。</span><span class="sxs-lookup"><span data-stu-id="51f0b-151">For example, asynchronous actions and operations (with and without progress) have completed and/or progress events that expect delegates of the corresponding type.</span></span> <span data-ttu-id="51f0b-152">たとえば、進行状況ありの非同期操作の進行状況イベント ([**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) を実装する任意のイベント) には、[**AsyncOperationProgressHandler**](/uwp/api/windows.foundation.asyncoperationprogresshandler) のデリゲート型が必要です。</span><span class="sxs-lookup"><span data-stu-id="51f0b-152">For example, the progress event of an asynchronous operation with progress (which is anything that implements [**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)) requires a delegate of type [**AsyncOperationProgressHandler**](/uwp/api/windows.foundation.asyncoperationprogresshandler).</span></span> <span data-ttu-id="51f0b-153">次に、ラムダ関数を使用してこの型のデリゲートを作成するコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-153">Here's a code example of authoring a delegate of that type using a lambda function.</span></span> <span data-ttu-id="51f0b-154">この例は、[**AsyncOperationWithProgressCompletedHandler**](/uwp/api/windows.foundation.asyncoperationwithprogresscompletedhandler) デリゲートの作成方法も示しています。</span><span class="sxs-lookup"><span data-stu-id="51f0b-154">The example also shows how to author an [**AsyncOperationWithProgressCompletedHandler**](/uwp/api/windows.foundation.asyncoperationwithprogresscompletedhandler) delegate.</span></span>

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
        [](IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress> const& /* sender */, RetrievalProgress const& args)
    {
        uint32_t bytes_retrieved = args.BytesRetrieved;
        // use bytes_retrieved;
    });

    async_op_with_progress.Completed(
        [](IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress> const& sender, AsyncStatus const /* asyncStatus */)
    {
        SyndicationFeed syndicationFeed = sender.GetResults();
        // use syndicationFeed;
    });
    
    // or (but this function must then be a coroutine, and return IAsyncAction)
    // SyndicationFeed syndicationFeed{ co_await async_op_with_progress };
}
```

<span data-ttu-id="51f0b-155">上記の "コルーチン" のコメントからも分かるように、非同期アクションと非同期操作の完了イベントでデリゲートを使用するよりも、コルーチンを使用するほうがより自然です。</span><span class="sxs-lookup"><span data-stu-id="51f0b-155">As the "coroutine" comment above suggests, instead of using a delegate with the completed events of asynchronous actions and operations, you'll probably find it more natural to use coroutines.</span></span> <span data-ttu-id="51f0b-156">詳細とコード例については、「[C++/WinRT を使用した同時実行操作と非同期操作](concurrency.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="51f0b-156">For details, and code examples, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md).</span></span>

> [!NOTE]
> <span data-ttu-id="51f0b-157">1 つ以上実装するために正しくない*完了ハンドラー*非同期アクションまたは操作します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-157">It's not correct to implement more than one *completion handler* for an asynchronous action or operation.</span></span> <span data-ttu-id="51f0b-158">、Completed イベントの 1 つのデリゲートがあることもできます`co_await`こと。</span><span class="sxs-lookup"><span data-stu-id="51f0b-158">You can have either a single delegate for its completed event, or you can `co_await` it.</span></span> <span data-ttu-id="51f0b-159">両方がある場合は、2 つ目は失敗します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-159">If you have both, then the second will fail.</span></span>

<span data-ttu-id="51f0b-160">コルーチンではなくデリゲートを読めば場合は、単純な構文を選択できますがします。</span><span class="sxs-lookup"><span data-stu-id="51f0b-160">If you stick with delegates instead of a coroutine, then you can opt for a simpler syntax.</span></span>

```cppwinrt
async_op_with_progress.Completed(
    [](auto&& /*sender*/, AsyncStatus const /* args */)
{
    // ...
});
```

## <a name="delegate-types-that-return-a-value"></a><span data-ttu-id="51f0b-161">値を返すデリゲート型</span><span class="sxs-lookup"><span data-stu-id="51f0b-161">Delegate types that return a value</span></span>

<span data-ttu-id="51f0b-162">一部のデリゲート型では自身に値を戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="51f0b-162">Some delegate types must themselves return a value.</span></span> <span data-ttu-id="51f0b-163">たとえば、[**ListViewItemToKeyHandler**](/uwp/api/windows.ui.xaml.controls.listviewitemtokeyhandler) は文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="51f0b-163">An example is [**ListViewItemToKeyHandler**](/uwp/api/windows.ui.xaml.controls.listviewitemtokeyhandler), which returns a string.</span></span> <span data-ttu-id="51f0b-164">次に、このような型のデリゲートの作成例を示します (ラムダ関数が値を返します)。</span><span class="sxs-lookup"><span data-stu-id="51f0b-164">Here's an example of authoring a delegate of that type (note that the lambda function returns a value).</span></span>

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

## <a name="safely-accessing-the-this-pointer-with-an-event-handling-delegate"></a><span data-ttu-id="51f0b-165">安全にアクセスする、*この*イベント処理デリゲートを使用してポインター</span><span class="sxs-lookup"><span data-stu-id="51f0b-165">Safely accessing the *this* pointer with an event-handling delegate</span></span>

<span data-ttu-id="51f0b-166">オブジェクトのメンバー関数をイベントを処理するかから、オブジェクトのメンバー関数内のラムダ関数内でする必要があるイベント受信者 (イベントを処理するオブジェクト) とイベント ソース (オブジェクトの相対的な有効期間について考えるイベントの発生)。</span><span class="sxs-lookup"><span data-stu-id="51f0b-166">If you handle an event with an object's member function, or from within a lambda function inside an object's member function, then you need to think about the relative lifetimes of the event recipient (the object handling the event) and the event source (the object raising the event).</span></span> <span data-ttu-id="51f0b-167">詳細については、およびコード例は、[強力と脆弱の参照を c++/cli WinRT](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="51f0b-167">For more info, and code examples, see [Strong and weak references in C++/WinRT](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate).</span></span>

## <a name="important-apis"></a><span data-ttu-id="51f0b-168">重要な API</span><span class="sxs-lookup"><span data-stu-id="51f0b-168">Important APIs</span></span>
* [<span data-ttu-id="51f0b-169">winrt::auto_revoke_t マーカー構造体</span><span class="sxs-lookup"><span data-stu-id="51f0b-169">winrt::auto_revoke_t marker struct</span></span>](/uwp/cpp-ref-for-winrt/auto-revoke-t)
* [<span data-ttu-id="51f0b-170">winrt::implements::get_weak 関数</span><span class="sxs-lookup"><span data-stu-id="51f0b-170">winrt::implements::get_weak function</span></span>](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)
* [<span data-ttu-id="51f0b-171">winrt::implements::get_strong 関数</span><span class="sxs-lookup"><span data-stu-id="51f0b-171">winrt::implements::get_strong function</span></span>](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)

## <a name="related-topics"></a><span data-ttu-id="51f0b-172">関連トピック</span><span class="sxs-lookup"><span data-stu-id="51f0b-172">Related topics</span></span>
* [<span data-ttu-id="51f0b-173">C + でのイベントを作成/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="51f0b-173">Author events in C++/WinRT</span></span>](author-events.md)
* [<span data-ttu-id="51f0b-174">同時実行と非同期操作を C +/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="51f0b-174">Concurrency and asynchronous operations with C++/WinRT</span></span>](concurrency.md)
* [<span data-ttu-id="51f0b-175">強力と脆弱の参照を c++/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="51f0b-175">Strong and weak references in C++/WinRT</span></span>](weak-references.md)
