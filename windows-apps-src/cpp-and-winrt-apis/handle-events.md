---
description: このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。
title: C++/WinRT でデリゲートを使用してイベントを処理する
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、プロジェクション、処理、イベント、デリゲート
ms.localizationpriority: medium
ms.openlocfilehash: 193d821b44722e150f38da7430504f5d528770a4
ms.sourcegitcommit: 2d2483819957619b6de21b678caf887f3b1342af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/01/2019
ms.locfileid: "9042394"
---
# <a name="handle-events-by-using-delegates-in-cwinrt"></a>C++/WinRT でのデリゲートを使用したイベントの処理

このトピックでは、登録とを使用したイベント処理デリゲートの取り消し方法を示しています。 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。 標準的な C++ 関数のようなオブジェクトを使用してイベントを処理できます。

> [!NOTE]
> インストールと c++ を使用してについては/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートと同様、C++ を提供する//winrt MSBuild プロパティとターゲット) を参照してください[、C++、Visual Studio サポート/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

## <a name="register-a-delegate-to-handle-an-event"></a>デリゲートを登録してイベントを処理する

次に、ボタンのクリック イベントの処理例を示します。 通常、イベントを処理するメンバー関数を登録するには、次のように XAML マークアップを使用します。

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

マークアップで宣言する代わりに、イベントを処理するメンバー関数を命令を使って登録することができます。 以下のコード例からは分かりにくいかもしれませんが、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) 呼び出しの引数は [**RoutedEventHandler**](/uwp/api/windows.ui.xaml.routedeventhandler) デリゲートのインスタンスです。 この場合、メンバー関数へのオブジェクトとポインターを取得する **RoutedEventHandler** コンストラクター オーバーロードを使用しています。

```cppwinrt
// MainPage.cpp
MainPage::MainPage()
{
    InitializeComponent();

    Button().Click({ this, &MainPage::ClickHandler });
}
```

> [!IMPORTANT]
> デリゲートを登録するには、上記のコード例は、直接*この*ポインター (現在のオブジェクトを指す) を渡します。 強参照または弱参照を現在のオブジェクトを確立する方法については、[安全に、イベント処理デリゲートを使用して*この*ポインターへのアクセス](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate)のセクションで**デリゲートとしてメンバー関数を使用する場合**のサブ セクションを参照してください。

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

    Button().Click([this](IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
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

    auto click_handler = [](IInspectable const& sender, RoutedEventArgs const& /* args */)
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

上記の例のように、強参照ではなく、ボタンへの弱参照を保存することができます (を参照してください[強参照と弱参照 c++/WinRT](weak-references.md))。

または、デリゲートを登録する場合は、(の種類の[**winrt::event_revoker**](/uwp/cpp-ref-for-winrt/event-revoker)) イベント リボーカーを要求する**winrt::auto_revoke** (される型[**winrt::auto_revoke_t**](/uwp/cpp-ref-for-winrt/auto-revoke-t)の値) を指定できます。 イベント リボーカーのイベント ソース (イベントを発生させるオブジェクト) への弱参照を保持します。 **event_revoker::revoke** メンバー関数を呼び出して手動で取り消すことができますが、イベント リボーカーは参照が範囲外になったときに自動的にその関数自体を呼び出します。 **revoke** 関数は、イベント ソースがまだ存在するかどうかを確認し、存在する場合は、デリケートを取り消します。 次の例では、イベント ソースを格納する必要がないため、デストラクターは必要ありません。

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

次の構文ブロックは、[**ButtonBase::Click**](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) イベントのドキュメント トピックからの抜粋です。 3 つの異なる登録と取り消し関数を示しています。 3 番目のオーバーロードから宣言する必要があるイベント リボーカーの型を正確に確認できます。

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
> 上記のコード例で`Button::Click_revoker`の種類の別名`winrt::event_revoker<winrt::Windows::UI::Xaml::Controls::Primitives::IButtonBase>`します。 同じようなパターンがすべての C++/WinRT イベントに適用されます。 各 Windows ランタイムのイベントには、取り消し関数オーバー ロード イベント リボーカーを返すし、イベント ソースのメンバーであるリボーカーの型があります。 そのため、別の例を[**corewindow::sizechanged**](/uwp/api/windows.ui.core.corewindow.sizechanged)イベントに**CoreWindow::SizeChanged_revoker**の種類の数値を返します。 登録関数のオーバー ロードがあります。


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

上記の "コルーチン" のコメントからも分かるように、非同期アクションと非同期操作の完了イベントでデリゲートを使用するよりも、コルーチンを使用するほうがより自然です。 詳細とコード例については、「[C++/WinRT を使用した同時実行操作と非同期操作](concurrency.md)」を参照してください。

> [!NOTE]
> 正しい非同期アクションまたは操作中には、複数の*完了ハンドラー*を実装することはできません。 その完了のイベントの 1 つのデリゲートしたりすることができます`co_await`ことです。 両方がある場合は、2 つ目は失敗します。

コルーチンではなくデリゲートを使用する場合、単純な構文のオプトアウトすることができます。

```cppwinrt
async_op_with_progress.Completed(
    [](auto&& /*sender*/, AsyncStatus const /* args */)
{
    // ...
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

## <a name="safely-accessing-the-this-pointer-with-an-event-handling-delegate"></a>イベント処理デリゲートは、*この*ポインターに安全にアクセスします。

オブジェクトのメンバー関数を使用したイベントを処理するからオブジェクトのメンバー関数内にあるラムダ関数しする必要がある場合、イベント受信側 (イベントを処理するオブジェクト) と、イベント ソース (オブジェクトの相対的な有効期間について検討するにはイベントを発生させる)。 詳細とコード例は、「[強参照と弱参照 c++/WinRT](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate)します。

## <a name="important-apis"></a>重要な API
* [winrt::auto_revoke_t マーカー構造体](/uwp/cpp-ref-for-winrt/auto-revoke-t)
* [winrt::implements::get_weak 関数](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)
* [winrt::implements::get_strong 関数](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT でのイベントの作成](author-events.md)
* [C++/WinRT を使用した同時実行操作と非同期操作](concurrency.md)
* [強参照と弱参照 c++/WinRT](weak-references.md)
