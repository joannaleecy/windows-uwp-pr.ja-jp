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
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2862608"
---
# <a name="author-events-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのイベントの作成

このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。 銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a>Windows ランタイム コンポーネントの作成 (BankAccountWRC)

まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 **Visual C++ Windows ランタイム コンポーネント (C++/WinRT)** プロジェクトを作成し、(「銀行口座 Windows ランタイム コンポーネント」用に) *BankAccountWRC* と名前を付けます。

新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。 ファイルの名前を変更する`BankAccount.idl`(名前を変更する、`.idl`ファイル従属変数の名前を自動的に変更する`.h`と`.cpp`ファイルも)。 目次を置き換える`BankAccount.idl`下の一覧にします。

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

ファイルを保存します。 現時点で完了するプロジェクトを作成できませんが、今すぐ建てる**BankAccount**ランタイム クラスを実装するが、ソース コード ファイルが生成されますので、便利なこと。 これを作成するようになりました (この段階で表示するビルド エラーがで実行する必要がある`Class.h`と`Class.g.h`が見つからない) します。 ビルド処理中に、`midl.exe`ツールを実行して、コンポーネントの Windows ランタイム メタデータ ファイルを作成するのには (これが`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`)。 次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL 内で宣言した**BankAccount**ランタイム クラスの実装を使い始めるときにスタブが含まれます。 これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。

エクスプ ローラーでスタブ ファイルをコピー`BankAccount.h`と`BankAccount.cpp`フォルダーから`\BankAccountWRC\BankAccountWRC\Generated Files\sources\`はプロジェクト ファイルを含むフォルダーに`\BankAccountWRC\BankAccountWRC\`、コピー先のファイルを置き換えます。 ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。 `BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。

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

上にあるわかるように、パラメーターの種類を特定の代理人の[**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体テンプレートは、イベントの実装します。

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

できない場合は、警告を文書から、それらを解決するか**C/C++** のプロジェクトのプロパティを設定する > **一般的な** > に**警告をエラーとして扱う****なし (/WX-)**、もう一度プロジェクトを作成します。

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a>コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。

ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。 **Visual C++ コア アプリ (C++/WinRT)** プロジェクトを作成し、*BankAccountCoreApp* と名前を付けます。

参照を追加しを参照`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`(または参照を追加するプロジェクト間、2 つのプロジェクトで同じソリューションの場合)。 **[追加]** をクリックして **[OK]** をクリックします。 ここで BankAccountCoreApp をビルドします。 予想外の場合に備えてエラーが表示される本体ファイル`readme.txt`が存在する、そのファイルを Windows ランタイム コンポーネントのプロジェクトから除外する、再構築] [BankAccountCoreApp を再構築しません。

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

ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。 想定どおりにイベントが発生することを示すためには、 **AccountIsInDebit**イベントを処理する λ 式内にブレークポイント、アプリを実行し、ウィンドウ内をクリックします。

## <a name="parameterized-delegates-and-simple-signals-across-an-abi"></a>パラメーターの代理人と ABI にわたって、単純なシグナル

アプリケーション バイナリ インターフェイス (ABI) の間でイベントをアクセス可能にする必要があるかどうか&mdash;コンポーネントとその消費アプリケーション間など&mdash;し、イベントが Windows ランタイム代理人の種類を使用する必要があります。 上記の例では、 [**Windows::Foundation::EventHandler\ < T\ >**](/uwp/api/windows.foundation.eventhandler) Windows ランタイム デリゲート型を使用します。 [**TypedEventHandler\ < TSender、TResult\ >**](/uwp/api/windows.foundation.eventhandler)では、Windows ランタイム代理人の種類の別の例を示します。

型のパラメーターが Windows ランタイムの種類] にもする必要がありますので、ABI を相互にする 2 つの代理人の種類の型のパラメーターがあります。 最初とサードパーティ ランタイム クラス] の番号と文字列などのプリミティブ型も含まれます。 コンパイラできます「*WinRT 型である必要があります*」のエラーがその制約を忘れた場合。

パラメーターまたはイベントの引数に渡す必要がない場合は、独自の簡単な Windows ランタイム代理人タイプを定義できます。 次の例では、 **BankAccount**ランタイム クラスの簡易バージョンが表示されます。 **SignalDelegate**という名前の代理人のタイプを宣言して、[を使用しているパラメーターを使ってイベントではなく信号の種類のイベントが発生します。

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

## <a name="parameterized-delegates-simple-signals-and-callbacks-within-a-project"></a>パラメーター化された代理人、単純なシグナルとプロジェクト内でコールバック

イベントが内部でのみ使用されている場合、C + 内 +/ [**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体テンプレートを使用するが、C + パラメーター化し、(バイナリ)、全体ではなく、WinRT がプロジェクト +/WinRT の非 Windows ランタイム[**winrt::delegate&lt;.T&gt;**](/uwp/cpp-ref-for-winrt/delegate)構造体テンプレートを効率的に使用、参照カウントの代理人。 パラメーターの任意の数がサポートされると、Windows ランタイム型に制限はします。

次の例は、パラメーター (基本的には、単純な信号) ほどかかりません署名と文字列は、1 つを代理人をまず表示されます。

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

追加する方法、イベントにだけのサブスクライブする代理人必要に応じてに注意してください。 ただし、イベントに関連付けられている一部の頭上ことができます。 単純なコールバックのみを 1 つサブスクライブする代理人] では、必要なかどうかは、 [**winrt::delegate を使用する&lt;.T&gt;**](/uwp/cpp-ref-for-winrt/delegate)専用にします。

```cppwinrt
winrt::delegate<> signalCallback;
signalCallback = [] { std::wcout << L"Hello, World!" << std::endl; };
signalCallback();

winrt::delegate<std::wstring> logCallback;
logCallback = [](std::wstring const& message) { std::wcout << message.c_str() << std::endl; }f;
logCallback(L"Hello, World!");
```

C + から移植する場合は、+/CX コードベースのイベントと代理人は、プロジェクト内で内部で使用し、[ **winrt::delegate**に役立つ C + でそのパターンを複製する場所 +/WinRT します。

## <a name="design-guidelines"></a>設計ガイドライン

関数のパラメーターとして、代理人いないと、イベントを通過することをお勧めします。 [**Winrt::event**](/uwp/cpp-ref-for-winrt/event)の関数を**追加**は、1 つの例外は、その場合は、代理人を渡す必要があります。 このガイドラインの理由は、代理人には、さまざまな形式 (かどうかが 1 つのクライアントの登録、または複数をサポート) は Windows ランタイム言語が異なるためにです。 イベントの複数のサブスクライバー モデルを予測可能で一貫性のあるオプションを構成します。

2 つのパラメーターのイベント ハンドラーの代理人の署名を含める必要があります:*送信者*(**IInspectable**)、および*引数*(一部のイベントの引数の型、[**特に**](/uwp/api/windows.ui.xaml.routedeventargs)など)。

内部 API を設計する場合、次のガイドラインは適用でないしないことに注意します。 ただし、内部 Api がちパブリック時間の経過します。

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の作成](author-apis.md)
* [C++/WinRT での API の使用](consume-apis.md)
* [C++/WinRT でデリゲートを使用してイベントを処理する](handle-events.md)
