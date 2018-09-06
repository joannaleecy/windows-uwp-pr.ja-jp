---
author: stevewhims
description: このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。
title: C++/WinRT でのイベントの作成
ms.author: stwhi
ms.date: 07/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 作成者, イベント
ms.localizationpriority: medium
ms.openlocfilehash: 3b52bf8e33bbf111dd02c695d8c3baf77e1338ac
ms.sourcegitcommit: 914b38559852aaefe7e9468f6f53a7465bf36e30
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3399600"
---
# <a name="author-events-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのイベントの作成

このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。 銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a>Windows ランタイム コンポーネントの作成 (BankAccountWRC)

まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 **Visual C++ Windows ランタイム コンポーネント (C++/WinRT)** プロジェクトを作成し、(「銀行口座 Windows ランタイム コンポーネント」用に) *BankAccountWRC* と名前を付けます。

新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。 そのファイルの名前を変更`BankAccount.idl`(名前を変更する、`.idl`ファイル、依存の名前を自動的に変更する`.h`と`.cpp`ファイル、すぎます)。 内容を置き換えます`BankAccount.idl`で以下のリスト。

```idl
// BankAccountWRC.idl
namespace BankAccountWRC
{
    runtimeclass BankAccount
    {
        BankAccount();
        event Windows.Foundation.EventHandler<Single> AccountIsInDebit;
        void AdjustBalance(Single value);
    };
}
```

ファイルを保存します。 現時点で完了するまで、プロジェクトのビルドはありませんが、 **BankAccount**のランタイム クラスを実装するソース コード ファイルが生成されるために有用なことは、構築できるようになりました。 ように指示してビルドできるようになりました (この段階で確認すると、ビルド エラーをする必要は`Class.h`と`Class.g.h`が見つかりません。)。 ビルド プロセス中に、`midl.exe`ツールが実行され、コンポーネントの Windows ランタイム メタデータ ファイルを作成する (これは`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`)。 次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL で宣言した**BankAccount**のランタイム クラスの実装を開始するためのスタブが含まれます。 これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。

エクスプ ローラーでスタブ ファイルをコピー`BankAccount.h`と`BankAccount.cpp`フォルダーから`\BankAccountWRC\BankAccountWRC\Generated Files\sources\`これは、プロジェクト ファイルが含まれているフォルダーに`\BankAccountWRC\BankAccountWRC\`、コピー先のファイルを置き換えます。 ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。 `BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。

```cppwinrt
// BankAccount.h
...
namespace winrt::BankAccountWRC::implementation
{
    struct BankAccount : BankAccountT<BankAccount>
    {
        ...

    private:
        winrt::event<Windows::Foundation::EventHandler<float>> m_accountIsInDebitEvent;
        float m_balance{ 0.f };
    };
}
...
```

特定のデリゲート型によってパラメーター化[**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体テンプレートは、イベントは前述したように実装されています。

`BankAccount.cpp` で、次のコード例に示すように関数を実装します。 C++/WinRT では、IDL で宣言したイベントは過負荷の状態である関数のセットとして実装されます (プロパティが過負荷の状態の Get および Set 関数のペアとして実装される方法と同様です)。 1 つのオーバーロードが登録するデリゲートを受け取り、トークンを返します。 別のオーバーロードはトークンを受け取り、関連付けられているデリゲートの登録を取り消します。

```cppwinrt
// BankAccount.cpp
...
namespace winrt::BankAccountWRC::implementation
{
    winrt::event_token BankAccount::AccountIsInDebit(Windows::Foundation::EventHandler<float> const& handler)
    {
        return m_accountIsInDebitEvent.add(handler);
    }

    void BankAccount::AccountIsInDebit(winrt::event_token const& token)
    {
        m_accountIsInDebitEvent.remove(token);
    }

    void BankAccount::AdjustBalance(float value)
    {
        m_balance += value;
        if (m_balance < 0.f) m_accountIsInDebitEvent(*this, m_balance);
    }
}
```

イベント リボーカーのオーバーロードを実装する必要はありません (詳細については、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください)。これは C++/WinRT プロジェクションで自動的に行われます。 別のオーバーロードは、開発者がシナリオに最適な方法で柔軟に実装できるようにするため、プロジェクションに書き込まれません。 このような [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) および [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) の呼び出しは、効率的で同時実行の安全性を確保できるスレッド セーフな既定値です。 ただし、大量のイベントがある場合は、各イベントのイベント フィールドが必要ないことがあり、代わりに、ある種のスパース実装を選択します。

また、**AdjustBalance** 関数の実装によって、残高が負の値になった場合でも **AccountIsInDebit** イベントが発生することを上で確認できます。

警告がビルドを妨げる場合、それを解決または**C/C++** プロジェクトのプロパティを設定 > **一般的な** > に**警告をエラーとして扱う****いいえ (/WX-)**、もう一度プロジェクトをビルドします。

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a>コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。

ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。 **Visual C++ コア アプリ (C++/WinRT)** プロジェクトを作成し、*BankAccountCoreApp* と名前を付けます。

参照を追加しを参照`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`(または 2 つのプロジェクトが同じソリューションに属している場合は、プロジェクト間の参照を追加)。 **[追加]** をクリックして **[OK]** をクリックします。 ここで BankAccountCoreApp をビルドします。 エラーが表示される万が一のイベントをペイロード ファイル`readme.txt`しない存在、Windows ランタイム コンポーネント プロジェクトからそのファイルを除外するしてから、BankAccountCoreApp を再構築します。

ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。 コンポーネントのランタイム クラス (`BankAccountWRC.h`という名前) の投影型のヘッダーは、フォルダー `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\` 内に生成されます。

そのヘッダーを `App.cpp` に含めます。

```cppwinrt
#include <winrt/BankAccountWRC.h>
```

`App.cpp` でも、(投影型の既定のコンストラクターを使用して) BankAccount のインスタンスを作成するために次のコードを追加し、イベント ハンドラーを登録して、口座が借方に入るようにします。

```cppwinrt
struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    BankAccountWRC::BankAccount m_bankAccount;
    winrt::event_token m_eventToken;
    ...
    
    void Initialize(CoreApplicationView const &)
    {
        m_eventToken = m_bankAccount.AccountIsInDebit([](const auto &, float balance)
        {
            WINRT_ASSERT(balance < 0.f);
        });
    }
    ...

    void Uninitialize()
    {
        m_bankAccount.AccountIsInDebit(m_eventToken);
    }
    ...

    void OnPointerPressed(IInspectable const &, PointerEventArgs const & args)
    {
        m_bankAccount.AdjustBalance(-1.f);
        ...
    }
    ...
};
```

ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。 期待どおりにイベントが発生することを示すためには、 **AccountIsInDebit**イベントを処理するラムダ式内にブレークポイントを配置、アプリを実行および、ウィンドウ内をクリックします。

## <a name="parameterized-delegates-and-simple-signals-across-an-abi"></a>パラメーターのデリゲートと ABI 間での単純な信号

イベントにアプリケーション バイナリ インターフェイス (ABI) の間でアクセスできる必要があります&mdash;コンポーネントとその使用中のアプリケーション間など&mdash;、イベントは、Windows ランタイムのデリゲート型を使用する必要があります。 上記の例では、Windows ランタイムの[**Windows::Foundation::EventHandler\ < t \ >**](/uwp/api/windows.foundation.eventhandler)のデリゲート型を使用します。 [**< TSender, TResult\ > TypedEventHandler\**](/uwp/api/windows.foundation.eventhandler)では、Windows ランタイムのデリゲート型の別の例を示します。

これら 2 つのデリゲート型の型のパラメーターは、型のパラメーターは、Windows ランタイム型をもする必要がありますので、ABI を通過する必要があります。 数字と文字列などのプリミティブ型と同様に、ファーストおよびサード パーティ製のランタイム クラスが含まれています。 コンパイラは、「*WinRT 型である必要があります*」というエラーでその制約を忘れた場合するように役立ちます。

任意のパラメーターや、イベント引数を渡す必要があるしない、独自の単純な Windows ランタイム デリゲート型を定義できます。 次の例は、 **BankAccount**のランタイム クラスの簡易バージョンを示しています。 **SignalDelegate**をという名前のデリゲート型を宣言しが、パラメーターを持つイベントではなく信号の種類のイベントを発生させるを使用します。

```idl
// BankAccountWRC.idl
namespace BankAccountWRC
{
    delegate void SignalDelegate();

    runtimeclass BankAccount
    {
        BankAccount();
        event BankAccountWRC.SignalDelegate SignalAccountIsInDebit;
        void AdjustBalance(Single value);
    };
}
```

```cppwinrt
// BankAccount.h
...
namespace winrt::BankAccountWRC::implementation
{
    struct BankAccount : BankAccountT<BankAccount>
    {
        ...

        winrt::event_token SignalAccountIsInDebit(BankAccountWRC::SignalDelegate const& handler);
        void SignalAccountIsInDebit(winrt::event_token const& token);
        void AdjustBalance(float value);

    private:
        winrt::event<BankAccountWRC::SignalDelegate> m_signal;
        float m_balance{ 0.f };
    };
}
```

```cppwinrt
// BankAccount.cpp
...
namespace winrt::BankAccountWRC::implementation
{
    winrt::event_token BankAccount::SignalAccountIsInDebit(BankAccountWRC::SignalDelegate const& handler)
    {
        return m_signal.add(handler);
    }

    void BankAccount::SignalAccountIsInDebit(winrt::event_token const& token)
    {
        m_signal.remove(token);
    }

    void BankAccount::AdjustBalance(float value)
    {
        m_balance += value;
        if (m_balance < 0.f)
        {
            m_signal();
        }
    }
}
```

```cppwinrt
// App.cpp
struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    BankAccountWRC::BankAccount m_bankAccount;
    winrt::event_token m_eventToken;
    ...
    
    void Initialize(CoreApplicationView const &)
    {
        m_eventToken = m_bankAccount.SignalAccountIsInDebit([] { /* ... */ });
    }
    ...

    void Uninitialize()
    {
        m_bankAccount.SignalAccountIsInDebit(m_eventToken);
    }
    ...

    void OnPointerPressed(IInspectable const &, PointerEventArgs const & args)
    {
        m_bankAccount.AdjustBalance(-1.f);
        ...
    }
    ...
};
```

## <a name="parameterized-delegates-simple-signals-and-callbacks-within-a-project"></a>デリゲートをパラメーター化された、シンプルな信号は、プロジェクト内でコールバック

イベントが内部でのみ使われる場合内で c++/cli [**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体のテンプレートを使用するが、c++ パラメーター化し、(バイナリ) ではなくプロジェクトの WinRT/WinRT の Windows ランタイム[**winrt::delegate&lt;.T&gt;**](/uwp/cpp-ref-for-winrt/delegate)構造体テンプレートでは、これは、効率的で参照カウントのデリゲートします。 任意の数のパラメーターがサポートしているし、Windows ランタイム型に制限はありません。

次の例は、パラメーター (本質的には、単純な信号) を実行しない署名し、文字列をいずれかに最初にデリゲートを示します。

```cppwinrt
winrt::event<winrt::delegate<>> signal;
signal.add([] { std::wcout << L"Hello, "; });
signal.add([] { std::wcout << L"World!" << std::endl; });
signal();

winrt::event<winrt::delegate<std::wstring>> log;
log.add([](std::wstring const& message) { std::wcout << message.c_str() << std::endl; });
log.add([](std::wstring const& message) { Persist(message); });
log(L"Hello, World!");
```

追加する方法、イベントに必要な数のサブスクライブするデリゲートに注意してください。 ただし、イベントに関連付けられているいくつかのオーバーヘッドがあります。 デリゲートを使用したのみ単一サブスクライブする、シンプルなコールバックが必要なすべてのかどうか、 [**winrt::delegate を使用する&lt;.T&gt;**](/uwp/cpp-ref-for-winrt/delegate)独自にします。

```cppwinrt
winrt::delegate<> signalCallback;
signalCallback = [] { std::wcout << L"Hello, World!" << std::endl; };
signalCallback();

winrt::delegate<std::wstring> logCallback;
logCallback = [](std::wstring const& message) { std::wcout << message.c_str() << std::endl; }f;
logCallback(L"Hello, World!");
```

C++ から移植している場合 +/CX コードベースで、プロジェクト内にイベントとデリゲートが内部的に使用される、 **:delegate、C++ でそのパターンをレプリケートする**/WinRT します。

## <a name="design-guidelines"></a>設計ガイドライン

イベント、およびいないのデリゲートを関数パラメーターとして渡すことをお勧めします。 [**Winrt::event**](/uwp/cpp-ref-for-winrt/event)の**追加**機能では、1 つの例外をその場合、デリゲートを渡す必要があるためです。 このガイドラインの理由とは、デリゲートが (かどうか 1 つのクライアントの登録、または複数のサポート) という点でさまざまな Windows ランタイム言語間で異なる形式を実行できるためです。 イベントを複数のサブスクライバー モデルより予測可能なで一貫性のあるオプションを構成します。

2 つのパラメーターのイベント ハンドラー デリゲートのシグネチャで構成されます。*送信者*(**IInspectable**) と*引数*(一部イベント引数の型、 [**RoutedEventArgs**](/uwp/api/windows.ui.xaml.routedeventargs)など)。

次のガイドラインでは内部の API を設計している場合を適用しない必ずしもことに注意してください。 ただし、内部 Api は通常なるパブリック時間の経過と共に。

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の作成](author-apis.md)
* [C++/WinRT での API の使用](consume-apis.md)
* [C++/WinRT でデリゲートを使用してイベントを処理する](handle-events.md)
