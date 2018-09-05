---
author: stevewhims
description: このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。
title: C++/WinRT でデリゲートを使用してイベントを処理する
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、プロジェクション、処理、イベント、デリゲート
ms.localizationpriority: medium
ms.openlocfilehash: a29c095e49b49baa63bd547c0bb928ad7f78aa86
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3369918"
---
# <a name="handle-events-by-using-delegates-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのデリゲートを使用したイベントの処理
このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。 標準的な C++ 関数のようなオブジェクトを使用してイベントを処理できます。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

## <a name="register-a-delegate-to-handle-an-event"></a>デリゲートを登録してイベントを処理する
次に、ボタンのクリック イベントの処理例を示します。 通常、イベントを処理するメンバー関数を登録するには、次のように XAML マークアップを使用します。

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

マークアップで宣言する代わりに、イベントを処理するメンバー関数を命令を使って登録することができます。 以下のコード例からは分かりにくいかもしれませんが、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) 呼び出しの引数は [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) デリゲートのインスタンスです。 この場合、メンバー関数へのオブジェクトとポインターを取得する **RoutedEventHandler** コンストラクター オーバーロードを使用しています。

```cppwinrt
// MainPage.cpp
MainPage::MainPage()
{
    InitializeComponent();

    Button().Click({ this, &MainPage::ClickHandler });
}
```

**RoutedEventHandler** の作成には他の方法もあります。 次に、[**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) のドキュメント内にある構文ブロックを示します (ページの [**言語**] ドロップダウンから [*C++/WinRT*] を選択)。 さまざまなコンストラクターがあることに注意してください。ラムダ、自由関数、メンバー関数へのオブジェクトとポインター (上記で使用したもの) を受け取ります。

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

また、関数呼び出し演算子の構文も確認に役立ちます。 必要なデリケートのパラメーターを通知します。 ご覧のように、この場合、関数呼び出し演算子の構文は **MainPage::ClickHandler** のパラメーターと一致します。

イベント ハンドラーで多くの処理を行っていない場合は、メンバー関数の代わりにラムダ関数を使用できます。 以下のコード例からは分かりにくいかもしれませんが、**RoutedEventHandler** デリゲートはラムダ関数から作成されているため、関数呼び出し演算子の構文ともう一度一致させる必要があります。

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

デリゲートを作成する場合にもう少し明示的に指定することができます。 たとえば、次のように渡したり、何回も使用したりする場合です。

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

## <a name="revoke-a-registered-delegate"></a>登録済みデリゲートの取り消し
デリゲートを登録すると、通常、トークンがユーザーに返されます。 その後、このトークンを使用してデリゲートを取り消すことができます。つまり、このトークンはイベントから登録解除され、イベントが再び発生しても呼び出されることはありません。 説明を簡単にするために、上記の例にはその方法を示すコードは含まれていません。 ただし、次のコード例では、トークンを構造体のプライベート データ メンバーに格納し、デストラクターの該当するハンドラーを取り消しています。

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

上の例のような強参照の代わりに、弱参照をボタンに格納することができます (「[C++/WinRT の弱参照](weak-references.md)」を参照してください)。

または、デリゲートを登録するときは、(の種類の[**winrt::event_revoker**](/uwp/cpp-ref-for-winrt/event-revoker)) イベント リボーカーを要求する**winrt::auto_revoke** (つまり、値を型[**winrt::auto_revoke_t**](/uwp/cpp-ref-for-winrt/auto-revoke-t)) を指定できます。 イベント リボーカーのイベント ソース (イベントを発生させるオブジェクト) への弱参照を保持します。 **event_revoker::revoke** メンバー関数を呼び出して手動で取り消すことができますが、イベント リボーカーは参照が範囲外になったときに自動的にその関数自体を呼び出します。 **revoke** 関数は、イベント ソースがまだ存在するかどうかを確認し、存在する場合は、デリケートを取り消します。 次の例では、イベント ソースを格納する必要がないため、デストラクターは必要ありません。

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

次の構文ブロックは、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) イベントのドキュメント トピックからの抜粋です。 3 つの異なる登録と取り消し関数を示しています。 3 番目のオーバーロードから宣言する必要があるイベント リボーカーの型を正確に確認できます。

```cppwinrt
// Register
winrt::event_token Click(winrt::Windows::UI::Xaml::RoutedEventHandler const& handler) const;

// Revoke with event_token
void Click(winrt::event_token const& token) const;

// Revoke with event_revoker
winrt::event_revoker<winrt::Windows::UI::Xaml::Controls::Primitives::IButtonBase> Click(winrt::auto_revoke_t,
    winrt::Windows::UI::Xaml::RoutedEventHandler const& handler) const;
```

同じようなパターンがすべての C++/WinRT イベントに適用されます。

ページのナビゲーションのシナリオでハンドラーの取り消しを検討します。 あるページへの移動を繰り返す場合、そのページから移動する際にハンドラーを取り消すことができます。 または、同じページ インスタンスを再使用しているときは、トークンの値を確認し、(`if (!m_token){ ... }`) がまだ設定されていない場合のみ登録します。 3 番目のオプションでは、ページにイベント リボーカーをデータ メンバーとして格納します。 このトピック後半で紹介する 4 番目のオプションでは、ラムダ関数内の*この*オブジェクトの強参照または弱参照をキャプチャします。

## <a name="delegate-types-for-asynchronous-actions-and-operations"></a>非同期アクションと非同期操作のデリゲート型
上記の例では、**RoutedEventHandler** デリゲート型を使用していますが、他にも多くのデリゲート型があります。 たとえば、非同期アクションと非同期操作 (進行状況ありとなし) には、対応するデリゲート型を必要とする完了イベントと進行状況イベントがあります。 たとえば、進行状況ありの非同期操作の進行状況イベント ([**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) を実装する任意のイベント) には、[**AsyncOperationProgressHandler**](/uwp/api/windows.foundation.asyncoperationprogresshandler) のデリゲート型が必要です。 次に、ラムダ関数を使用してこの型のデリゲートを作成するコード例を示します。 この例は、[**AsyncOperationWithProgressCompletedHandler**](/uwp/api/windows.foundation.asyncoperationwithprogresscompletedhandler) デリゲートの作成方法も示しています。

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
    
    // or (but this function must then be a coroutine and return IAsyncAction)
    // SyndicationFeed syndicationFeed{ co_await async_op_with_progress };
}
```

上記の "コルーチン" のコメントからも分かるように、非同期アクションと非同期操作の完了イベントでデリゲートを使用するよりも、コルーチンを使用するほうがより自然です。 詳細とコード例については、「[C++/WinRT を使用した同時実行操作と非同期操作](concurrency.md)」を参照してください。

ただし、デリゲートを使用する場合は、単純な形式の構文を選択できます。

```cppwinrt
async_op_with_progress.Completed(
    [](auto&& /*sender*/, AsyncStatus const)
{
    ....
});
```

## <a name="delegate-types-that-return-a-value"></a>値を返すデリゲート型
一部のデリゲート型では自身に値を戻す必要があります。 たとえば、[**ListViewItemToKeyHandler**](/uwp/api/windows.ui.xaml.controls.listviewitemtokeyhandler) は文字列を返します。 次に、このような型のデリゲートの作成例を示します (ラムダ関数が値を返します)。

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

## <a name="using-the-this-object-in-an-event-handler"></a>イベント ハンドラーでの*この*オブジェクトの使用
オブジェクトのメンバー関数内にあるラムダ関数のイベントを処理する場合は、イベント受信側 (イベントを処理するオブジェクト) とイベント ソース (イベントを発生させるオブジェクト) の相対的な有効期間を考慮する必要があります。

多くの場合、受信側は、任意のラムダ関数内にある自身の*この*ポインターのすべての依存関係を失います。 UI ページでそのページ上にあるコントロールで発生したイベントを処理するときなど、明らかな場合があります。 ボタンがページ上に表示されないため、ハンドラーも表示されません。 これは、受信側がソースを所有する場合 (データ メンバーとしてなど)、または受信側とソースが兄弟関係にあり、他のオブジェクトによって直接所有されている場合に当てはまります。 ハンドラーが依存する*このオブジェクト*に表示されない場合、有効期間の強弱を気にしなくても、通常どおり*このオブジェクト*をキャプチャできます。

ただし、*このオブジェクト*がハンドラー内の自身の用途に表示されない場合などもあります (非同期アクションと非同期操作によって発生する完了イベントと進行状況イベントのハンドラーなど)。

- 非同期メソッドを実装するためにコルーチンを作成する場合は可能です。
- 特定の XAML UI フレームワーク オブジェクト ([**SwapChainPanel**](/uwp/api/windows.ui.xaml.controls.swapchainpanel) など) を使用するまれなケースで、イベント ソースから登録解除しなくても、受信側が最終処理される場合は可能です。

このような場合、*この*無効なオブジェクトを使用してハンドラーまたはコルーチンが継続するため、アクセス違反になります。

> [!IMPORTANT]
> このいずれかの状況になった場合は、キャプチャした*この*オブジェクトのキャプチャの状態を続けるかどうか、*この*オブジェクトの有効期間を検討する必要があります。 それ以外の場合は、強参照または弱参照を使用してオブジェクトを必要に応じてキャプチャします。 [**implements::get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) と [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) をご覧ください。
> または、シナリオに適している場合、およびスレッドの考慮事項にも対応する場合、受信側のイベントの完了後や受信側のデストラクターで、ハンドラーを取り消すといった別のオプションがあります。

次のコード例では、[**SwapChainPanel.CompositionScaleChanged**](/uwp/api/windows.ui.xaml.controls.swapchainpanel.compositionscalechanged) イベントを使用しています。 受信側の弱参照をキャプチャするラムダを使用して、イベント ハンドラーを登録します。 弱参照の詳細については、「[C++/WinRT の弱参照](weak-references.md)」をご覧ください。 

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

ラムダのキャプチャ句で、一時変数を作成し、*このオブジェクト*の弱参照を表示します。 ラムダ式の本文で、*このオブジェクト*の強参照を取得する場合は、**OnCompositionScaleChanged** 関数が呼び出されます。 これにより、**OnCompositionScaleChanged** 内で*このオブジェクト*を安全に使用することができます。

## <a name="important-apis"></a>重要な API
* [winrt::auto_revoke_t](/uwp/cpp-ref-for-winrt/auto-revoke-t)
* [winrt::implements::get_weak 関数](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)
* [winrt::implements::get_strong 関数](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT でのイベントの作成](author-events.md)
* [C++/WinRT を使用した同時実行操作と非同期操作](concurrency.md)
* [C++/WinRT の弱参照](weak-references.md)
