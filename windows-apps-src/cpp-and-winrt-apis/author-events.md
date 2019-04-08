---
description: このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。
title: C++/WinRT でのイベントの作成
ms.date: 07/18/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 作成者, イベント
ms.localizationpriority: medium
ms.openlocfilehash: ace1c276b878d07f5750483740dfe90ed8cb6211
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644487"
---
# <a name="author-events-in-cwinrt"></a>C++/WinRT でのイベントの作成

このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。 銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。

> [!NOTE]
> インストールと使用について、 [C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Visual Studio Extension (VSIX) (プロジェクト テンプレートのサポートを提供します) を参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a>Windows ランタイム コンポーネントの作成 (BankAccountWRC)

まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 作成、 **Visual C** > **Windows ユニバーサル** > **Windows ランタイム コンポーネント (C +/cli WinRT)** プロジェクト、および名前を付けます*BankAccountWRC* (の「銀行口座 Windows ランタイム コンポーネント」)。

新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。 そのファイルの名前を変更`BankAccount.idl`(名前変更、`.idl`ファイルは、依存ファイルを自動的に変更されます`.h`と`.cpp`ファイル、すぎます)。 内容を置き換える`BankAccount.idl`以下の一覧にします。

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

ファイルを保存します。 現時点では、完了するまで、プロジェクトをビルドしませんが、実装して、ソース コード ファイルが生成されますので、有用なことは、今すぐ構築、 **BankAccount**ランタイム クラスです。 したがってさあ、今すぐ作成 (この段階で表示するビルド エラーで行う必要がある`Class.h`と`Class.g.h`が見つかりません。)。 ビルド プロセス中に、`midl.exe`コンポーネントの Windows ランタイム メタデータ ファイルを作成するツールを実行 (ある`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`)。 次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。 これらのファイルは、スタブ実装を開始するため、 **BankAccount** IDL 内で宣言されているランタイム クラスです。 これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。

プロジェクト ノードを右クリックし、をクリックして**ファイル エクスプ ローラーでフォルダーを開く**します。 これは、ファイル エクスプ ローラーでプロジェクト フォルダーを開きます。 スタブ ファイルをコピー、`BankAccount.h`と`BankAccount.cpp`フォルダーから`\BankAccountWRC\BankAccountWRC\Generated Files\sources\`、プロジェクト ファイルを含むフォルダーにある`\BankAccountWRC\BankAccountWRC\`、し、変換先でファイルを置き換えます。 ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。 `BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。

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

観点で、イベントの実装の上をご覧のとおり、 [ **winrt::event** ](/uwp/cpp-ref-for-winrt/event)構造体のテンプレートを特定のデリゲート型でパラメーター化します。

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

イベント revoker のオーバー ロードを実装する必要はありません (詳細については、次を参照してください。[登録されたデリゲートを取り消す](handle-events.md#revoke-a-registered-delegate))&mdash;をが隠メ諶の c++/cli WinRT 投影します。 別のオーバーロードは、開発者がシナリオに最適な方法で柔軟に実装できるようにするため、プロジェクションに書き込まれません。 このような [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) および [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) の呼び出しは、効率的で同時実行の安全性を確保できるスレッド セーフな既定値です。 ただし、大量のイベントがある場合は、各イベントのイベント フィールドが必要ないことがあり、代わりに、ある種のスパース実装を選択します。

また、**AdjustBalance** 関数の実装によって、残高が負の値になった場合でも **AccountIsInDebit** イベントが発生することを上で確認できます。

すべての警告には、ビルドを妨げること場合、しそれらを解決するか、プロジェクト プロパティを設定**C/C++** > **全般** > **警告をエラーとして扱う**に**いいえ (/WX-)**、もう一度プロジェクトをビルドします。

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a>コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。

ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。 作成、 **Visual C** > **Windows ユニバーサル** > **Core アプリ (C +/cli WinRT)** プロジェクト、および名前を付けます*BankAccountCoreApp*.

参照を追加しを参照`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`(または、プロジェクト間参照を追加して、同じソリューション内に 2 つのプロジェクトがある場合)。 **[追加]** をクリックして **[OK]** をクリックします。 ここで BankAccountCoreApp をビルドします。 万一エラーが表示されるペイロード ファイル`readme.txt`存在、Windows ランタイム コンポーネント プロジェクトからそのファイルを除外する、再構築、BankAccountCoreApp を再構築しません。

ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。 コンポーネントのランタイム クラスの射影された型のヘッダー&mdash;という`BankAccountWRC.h`&mdash;フォルダーに生成される`\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\`します。

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

ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。 期待どおりに、イベントが生成されていることを示すためには、処理しているラムダ式内にブレークポイントを配置、 **AccountIsInDebit**イベントでは、アプリを実行し、ウィンドウ内をクリックします。

## <a name="parameterized-delegates-and-simple-signals-across-an-abi"></a>パラメーター化されたデリゲートと ABI 間での単純な信号

イベントをアプリケーション バイナリ インターフェイス (ABI) を越えてアクセスできる必要があるかどうか&mdash;このようなコンポーネントとそのコンシューマー側アプリケーション&mdash;イベントが Windows ランタイムのデリゲート型を使用する必要があります。 使用して上記の例、 [ **Windows::Foundation::EventHandler\<T\>**  ](/uwp/api/windows.foundation.eventhandler) Windows ランタイムのデリゲート型。 [**TypedEventHandler\<TSender, TResult\>**  ](/uwp/api/windows.foundation.eventhandler) Windows ランタイムのデリゲート型の別の例を示します。

これら 2 つのデリゲート型の型パラメーターは、型パラメーターでは、Windows ランタイムの型をもする必要がありますので、ABI を通過する必要があります。 1 つ目とサード パーティのランタイム クラスの数値や文字列などのプリミティブ型も含まれます。 コンパイラで、"*WinRT 型でなければなりません*"その制約を忘れた場合のエラー。

パラメーターや、イベントの引数を渡す不要な場合は、独自の単純な Windows ランタイム デリゲート型を定義できます。 次の例の単純なバージョンを示しています、 **BankAccount**ランタイム クラスです。 という名前のデリゲート型を宣言して**SignalDelegate**を使用しているパラメーターを持つイベントではなく信号の種類のイベントを生成します。

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

## <a name="parameterized-delegates-simple-signals-and-callbacks-within-a-project"></a>パラメーター化されたデリゲート、単純な信号、およびプロジェクト内でのコールバック

イベントを内部でのみ使用する場合、C + 内で/cli WinRT は、使用することも、(バイナリ)、全体ではなくプロジェクト、 [ **winrt::event** ](/uwp/cpp-ref-for-winrt/event)構造体のテンプレートがパラメーター C +/cli WinRT の非 Windows ランタイム[ **winrt::delegate&lt;.T&gt;**  ](/uwp/cpp-ref-for-winrt/delegate)構造体のテンプレートを効率的な参照カウントのデリゲートします。 任意の数のパラメーターをサポートし、Windows ランタイム型に限定されてはいません。

(基本的には単純な信号を)、パラメーターがない署名とは文字列を受け取り、1、次の例は最初にデリゲートを示します。

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

追加する方法、イベントに、必要に応じて多くのサブスクライブしているデリゲートに注意してください。 ただし、イベントに関連付けられているいくつかのオーバーヘッドがあります。 のみ単一サブスクライブするデリゲートで、単純なコールバックは、必要なかどうかを使用して[ **winrt::delegate&lt;.T&gt;**  ](/uwp/cpp-ref-for-winrt/delegate)独自にします。

```cppwinrt
winrt::delegate<> signalCallback;
signalCallback = [] { std::wcout << L"Hello, World!" << std::endl; };
signalCallback();

winrt::delegate<std::wstring> logCallback;
logCallback = [](std::wstring const& message) { std::wcout << message.c_str() << std::endl; }f;
logCallback(L"Hello, World!");
```

C++ から移植している場合/cli CX コードベースでイベントとデリゲートを内部的に使用されます、プロジェクト内で、 **winrt::delegate** C + では、そのパターンをレプリケートする際に役立つ/cli WinRT します。

## <a name="design-guidelines"></a>設計ガイドライン

関数のパラメーターとしては、イベント、およびいないのデリゲートを渡すことをお勧めします。 **追加**関数の[ **winrt::event** ](/uwp/cpp-ref-for-winrt/event) 1 つの例外は、ため、その場合は、デリゲートを渡す必要があります。 このガイドラインの理由デリゲート (かどうか、1 つのクライアントの登録、または複数をサポート) に関するさまざまな Windows ランタイム言語のさまざまなフォームがかかるためにです。 サブスクライバーが複数のモデルでのイベントより予測可能で一貫性のあるオプションを構成します。

イベント ハンドラー デリゲートのシグネチャが 2 つのパラメーターで構成されます:*送信者*(**IInspectable**)、および*args* (たとえば一部イベント引数の型[ **RoutedEventArgs**](/uwp/api/windows.ui.xaml.routedeventargs))。

次のガイドラインの内部 API を設計する場合は必ずしも当てはまらないことに注意してください。 ただし、多くの場合、内部 Api は時間のようになります公開します。

## <a name="related-topics"></a>関連トピック
* [C++/WinRT で API を作成する](author-apis.md)
* [C++/WinRT で API を使用する](consume-apis.md)
* [C + でデリゲートを使用してイベントを処理/cli WinRT](handle-events.md)
