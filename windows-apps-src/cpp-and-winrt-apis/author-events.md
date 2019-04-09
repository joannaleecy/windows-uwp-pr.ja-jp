---
description: このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。
title: C++/WinRT でのイベントの作成
ms.date: 07/18/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 作成者, イベント
ms.localizationpriority: medium
ms.openlocfilehash: 5c410d209972a0221928548901f79bd599c67eae
ms.sourcegitcommit: c315ec3e17489aeee19f5095ec4af613ad2837e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2019
ms.locfileid: "58921698"
---
# <a name="author-events-in-cwinrt"></a><span data-ttu-id="75033-105">C++/WinRT でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="75033-105">Author events in C++/WinRT</span></span>

<span data-ttu-id="75033-106">このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="75033-106">This topic demonstrates how to author a Windows Runtime Component containing a runtime class representing a bank account, which raises an event when its balance goes into debit.</span></span> <span data-ttu-id="75033-107">銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。</span><span class="sxs-lookup"><span data-stu-id="75033-107">It also demonstrates a Core App that consumes the bank account runtime class, calls a function to adjust the balance, and handles any events that result.</span></span>

> [!NOTE]
> <span data-ttu-id="75033-108">インストールと使用について、 [ C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Visual Studio Extension (VSIX) と (をまとめてプロジェクト テンプレートを提供し、ビルドのサポート)、NuGet パッケージを参照してください[Visual Studio のサポートC++/。WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。</span><span class="sxs-lookup"><span data-stu-id="75033-108">For info about installing and using the [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Visual Studio Extension (VSIX) and the NuGet package (which together provide project template and build support), see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="75033-109">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="75033-109">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a><span data-ttu-id="75033-110">Windows ランタイム コンポーネントの作成 (BankAccountWRC)</span><span class="sxs-lookup"><span data-stu-id="75033-110">Create a Windows Runtime Component (BankAccountWRC)</span></span>

<span data-ttu-id="75033-111">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="75033-111">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="75033-112">作成、 **Visual C** > **Windows ユニバーサル** > **Windows ランタイム コンポーネント (C +/cli WinRT)** プロジェクト、および名前を付けます*BankAccountWRC* (の「銀行口座 Windows ランタイム コンポーネント」)。</span><span class="sxs-lookup"><span data-stu-id="75033-112">Create a **Visual C++** > **Windows Universal** > **Windows Runtime Component (C++/WinRT)** project, and name it *BankAccountWRC* (for "bank account Windows Runtime Component").</span></span>

<span data-ttu-id="75033-113">新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="75033-113">The newly-created project contains a file named `Class.idl`.</span></span> <span data-ttu-id="75033-114">そのファイルの名前を変更`BankAccount.idl`(名前変更、`.idl`ファイルは、依存ファイルを自動的に変更されます`.h`と`.cpp`ファイル、すぎます)。</span><span class="sxs-lookup"><span data-stu-id="75033-114">Rename that file `BankAccount.idl` (renaming the `.idl` file automatically renames the dependent `.h` and `.cpp` files, too).</span></span> <span data-ttu-id="75033-115">内容を置き換える`BankAccount.idl`以下の一覧にします。</span><span class="sxs-lookup"><span data-stu-id="75033-115">Replace the contents of `BankAccount.idl` with the listing below.</span></span>

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

<span data-ttu-id="75033-116">ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="75033-116">Save the file.</span></span> <span data-ttu-id="75033-117">現時点では、完了するまで、プロジェクトをビルドしませんが、実装して、ソース コード ファイルが生成されますので、有用なことは、今すぐ構築、 **BankAccount**ランタイム クラスです。</span><span class="sxs-lookup"><span data-stu-id="75033-117">The project won't build to completion at the moment, but building now is a useful thing to do because it generates the source code files in which you'll implement the **BankAccount** runtime class.</span></span> <span data-ttu-id="75033-118">したがってさあ、今すぐ作成 (この段階で表示するビルド エラーで行う必要がある`Class.h`と`Class.g.h`が見つかりません。)。</span><span class="sxs-lookup"><span data-stu-id="75033-118">So go ahead and build now (the build errors you can expect to see at this stage have to do with `Class.h` and `Class.g.h` not being found).</span></span> <span data-ttu-id="75033-119">ビルド プロセス中に、`midl.exe`コンポーネントの Windows ランタイム メタデータ ファイルを作成するツールを実行 (ある`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`)。</span><span class="sxs-lookup"><span data-stu-id="75033-119">During the build process, the `midl.exe` tool is run to create your component's Windows Runtime metadata file (which is `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`).</span></span> <span data-ttu-id="75033-120">次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="75033-120">Then, the `cppwinrt.exe` tool is run (with the `-component` option) to generate source code files to support you in authoring your component.</span></span> <span data-ttu-id="75033-121">これらのファイルは、スタブ実装を開始するため、 **BankAccount** IDL 内で宣言されているランタイム クラスです。</span><span class="sxs-lookup"><span data-stu-id="75033-121">These files include stubs to get you started implementing the **BankAccount** runtime class that you declared in your IDL.</span></span> <span data-ttu-id="75033-122">これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="75033-122">Those stubs are `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` and `BankAccount.cpp`.</span></span>

<span data-ttu-id="75033-123">プロジェクト ノードを右クリックし、をクリックして**ファイル エクスプ ローラーでフォルダーを開く**します。</span><span class="sxs-lookup"><span data-stu-id="75033-123">Right-click the project node and click **Open Folder in File Explorer**.</span></span> <span data-ttu-id="75033-124">これは、ファイル エクスプ ローラーでプロジェクト フォルダーを開きます。</span><span class="sxs-lookup"><span data-stu-id="75033-124">This opens the project folder in File Explorer.</span></span> <span data-ttu-id="75033-125">スタブ ファイルをコピー、`BankAccount.h`と`BankAccount.cpp`フォルダーから`\BankAccountWRC\BankAccountWRC\Generated Files\sources\`、プロジェクト ファイルを含むフォルダーにある`\BankAccountWRC\BankAccountWRC\`、し、変換先でファイルを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="75033-125">There, copy the stub files `BankAccount.h` and `BankAccount.cpp` from the folder `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` and into the folder that contains your project files, which is `\BankAccountWRC\BankAccountWRC\`, and replace the files in the destination.</span></span> <span data-ttu-id="75033-126">ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="75033-126">Now, let's open `BankAccount.h` and `BankAccount.cpp` and implement our runtime class.</span></span> <span data-ttu-id="75033-127">`BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="75033-127">In `BankAccount.h`, add two private members to the implementation (*not* the factory implementation) of BankAccount.</span></span>

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

<span data-ttu-id="75033-128">観点で、イベントの実装の上をご覧のとおり、 [ **winrt::event** ](/uwp/cpp-ref-for-winrt/event)構造体のテンプレートを特定のデリゲート型でパラメーター化します。</span><span class="sxs-lookup"><span data-stu-id="75033-128">As you can see above, the event is implemented in terms of the [**winrt::event**](/uwp/cpp-ref-for-winrt/event) struct template, parameterized by a particular delegate type.</span></span>

<span data-ttu-id="75033-129">`BankAccount.cpp` で、次のコード例に示すように関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="75033-129">In `BankAccount.cpp`, implement the functions as shown in the code example below.</span></span> <span data-ttu-id="75033-130">C++/WinRT では、IDL で宣言したイベントは過負荷の状態である関数のセットとして実装されます (プロパティが過負荷の状態の Get および Set 関数のペアとして実装される方法と同様です)。</span><span class="sxs-lookup"><span data-stu-id="75033-130">In C++/WinRT, an IDL-declared event is implemented as a set of overloaded functions (similar to the way a property is implemented as a pair of overloaded get and set functions).</span></span> <span data-ttu-id="75033-131">1 つのオーバーロードが登録するデリゲートを受け取り、トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="75033-131">One overload takes a delegate to be registered, and returns a token.</span></span> <span data-ttu-id="75033-132">別のオーバーロードはトークンを受け取り、関連付けられているデリゲートの登録を取り消します。</span><span class="sxs-lookup"><span data-stu-id="75033-132">The other takes a token, and revokes the registration of the associated delegate.</span></span>

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

<span data-ttu-id="75033-133">イベント revoker のオーバー ロードを実装する必要はありません (詳細については、次を参照してください。[登録されたデリゲートを取り消す](handle-events.md#revoke-a-registered-delegate))&mdash;をが隠メ諶の c++/cli WinRT 投影します。</span><span class="sxs-lookup"><span data-stu-id="75033-133">You don't need to implement the overload for the event revoker (for details, see [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate))&mdash;that's taken care of for you by the C++/WinRT projection.</span></span> <span data-ttu-id="75033-134">別のオーバーロードは、開発者がシナリオに最適な方法で柔軟に実装できるようにするため、プロジェクションに書き込まれません。</span><span class="sxs-lookup"><span data-stu-id="75033-134">The other overloads are not baked into the projection, in order to give you the flexibility to implement them optimally for your scenario.</span></span> <span data-ttu-id="75033-135">このような [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) および [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) の呼び出しは、効率的で同時実行の安全性を確保できるスレッド セーフな既定値です。</span><span class="sxs-lookup"><span data-stu-id="75033-135">Calling [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) and [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) like this is an efficient and concurrency/thread-safe default.</span></span> <span data-ttu-id="75033-136">ただし、大量のイベントがある場合は、各イベントのイベント フィールドが必要ないことがあり、代わりに、ある種のスパース実装を選択します。</span><span class="sxs-lookup"><span data-stu-id="75033-136">But if you have a very large number of events, then you may not want an event field for each, but rather opt for some kind of sparse implementation instead.</span></span>

<span data-ttu-id="75033-137">また、**AdjustBalance** 関数の実装によって、残高が負の値になった場合でも **AccountIsInDebit** イベントが発生することを上で確認できます。</span><span class="sxs-lookup"><span data-stu-id="75033-137">You can also see above that the implementation of the **AdjustBalance** function raises the **AccountIsInDebit** event if the balance goes negative.</span></span>

<span data-ttu-id="75033-138">すべての警告には、ビルドを妨げること場合、しそれらを解決するか、プロジェクト プロパティを設定**C/C++** > **全般** > **警告をエラーとして扱う**に**いいえ (/WX-)**、もう一度プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="75033-138">If any warnings prevent you from building, then either resolve them or set the project property **C/C++** > **General** > **Treat Warnings As Errors** to **No (/WX-)**, and build the project again.</span></span>

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a><span data-ttu-id="75033-139">コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。</span><span class="sxs-lookup"><span data-stu-id="75033-139">Create a Core App (BankAccountCoreApp) to test the Windows Runtime Component</span></span>

<span data-ttu-id="75033-140">ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="75033-140">Now create a new project (either in your `BankAccountWRC` solution, or in a new one).</span></span> <span data-ttu-id="75033-141">作成、 **Visual C** > **Windows ユニバーサル** > **Core アプリ (C +/cli WinRT)** プロジェクト、および名前を付けます*BankAccountCoreApp*.</span><span class="sxs-lookup"><span data-stu-id="75033-141">Create a **Visual C++** > **Windows Universal** > **Core App (C++/WinRT)** project, and name it *BankAccountCoreApp*.</span></span>

<span data-ttu-id="75033-142">参照を追加しを参照`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`(または、プロジェクト間参照を追加して、同じソリューション内に 2 つのプロジェクトがある場合)。</span><span class="sxs-lookup"><span data-stu-id="75033-142">Add a reference, and browse to `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` (or add a project-to-project reference, if the two projects are in the same solution).</span></span> <span data-ttu-id="75033-143">**[追加]** をクリックして **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="75033-143">Click **Add**, and then **OK**.</span></span> <span data-ttu-id="75033-144">ここで BankAccountCoreApp をビルドします。</span><span class="sxs-lookup"><span data-stu-id="75033-144">Now build BankAccountCoreApp.</span></span> <span data-ttu-id="75033-145">万一エラーが表示されるペイロード ファイル`readme.txt`存在、Windows ランタイム コンポーネント プロジェクトからそのファイルを除外する、再構築、BankAccountCoreApp を再構築しません。</span><span class="sxs-lookup"><span data-stu-id="75033-145">In the unlikely event that you see an error that the payload file `readme.txt` doesn't exist, exclude that file from the Windows Runtime Component project, rebuild it, then rebuild BankAccountCoreApp.</span></span>

<span data-ttu-id="75033-146">ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。</span><span class="sxs-lookup"><span data-stu-id="75033-146">During the build process, the `cppwinrt.exe` tool is run to process the referenced `.winmd` file into source code files containing projected types to support you in consuming your component.</span></span> <span data-ttu-id="75033-147">コンポーネントのランタイム クラスの射影された型のヘッダー&mdash;という`BankAccountWRC.h`&mdash;フォルダーに生成される`\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\`します。</span><span class="sxs-lookup"><span data-stu-id="75033-147">The header for the projected types for your component's runtime classes&mdash;named `BankAccountWRC.h`&mdash;is generated into the folder `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\`.</span></span>

<span data-ttu-id="75033-148">そのヘッダーを `App.cpp` に含めます。</span><span class="sxs-lookup"><span data-stu-id="75033-148">Include that header in `App.cpp`.</span></span>

```cppwinrt
#include <winrt/BankAccountWRC.h>
```

<span data-ttu-id="75033-149">`App.cpp` でも、(投影型の既定のコンストラクターを使用して) BankAccount のインスタンスを作成するために次のコードを追加し、イベント ハンドラーを登録して、口座が借方に入るようにします。</span><span class="sxs-lookup"><span data-stu-id="75033-149">Also in `App.cpp`, add the following code to instantiate a BankAccount (using the projected type's default constructor), register an event handler, and then cause the account to go into debit.</span></span>

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

<span data-ttu-id="75033-150">ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。</span><span class="sxs-lookup"><span data-stu-id="75033-150">Each time you click the window, you subtract 1 from the bank account's balance.</span></span> <span data-ttu-id="75033-151">期待どおりに、イベントが生成されていることを示すためには、処理しているラムダ式内にブレークポイントを配置、 **AccountIsInDebit**イベントでは、アプリを実行し、ウィンドウ内をクリックします。</span><span class="sxs-lookup"><span data-stu-id="75033-151">To demonstrate that the event is being raised as expected, put a breakpoint inside the lambda expression that's handling the **AccountIsInDebit** event, run the app, and click inside the window.</span></span>

## <a name="parameterized-delegates-and-simple-signals-across-an-abi"></a><span data-ttu-id="75033-152">パラメーター化されたデリゲートと ABI 間での単純な信号</span><span class="sxs-lookup"><span data-stu-id="75033-152">Parameterized delegates, and simple signals, across an ABI</span></span>

<span data-ttu-id="75033-153">イベントをアプリケーション バイナリ インターフェイス (ABI) を越えてアクセスできる必要があるかどうか&mdash;このようなコンポーネントとそのコンシューマー側アプリケーション&mdash;イベントが Windows ランタイムのデリゲート型を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="75033-153">If your event must be accessible across an application binary interface (ABI)&mdash;such as between a component and its consuming application&mdash;then your event must use a Windows Runtime delegate type.</span></span> <span data-ttu-id="75033-154">使用して上記の例、 [ **Windows::Foundation::EventHandler\<T\>**  ](/uwp/api/windows.foundation.eventhandler) Windows ランタイムのデリゲート型。</span><span class="sxs-lookup"><span data-stu-id="75033-154">The example above uses the [**Windows::Foundation::EventHandler\<T\>**](/uwp/api/windows.foundation.eventhandler) Windows Runtime delegate type.</span></span> <span data-ttu-id="75033-155">[**TypedEventHandler\<TSender, TResult\>**  ](/uwp/api/windows.foundation.eventhandler) Windows ランタイムのデリゲート型の別の例を示します。</span><span class="sxs-lookup"><span data-stu-id="75033-155">[**TypedEventHandler\<TSender, TResult\>**](/uwp/api/windows.foundation.eventhandler) is another example of a Windows Runtime delegate type.</span></span>

<span data-ttu-id="75033-156">これら 2 つのデリゲート型の型パラメーターは、型パラメーターでは、Windows ランタイムの型をもする必要がありますので、ABI を通過する必要があります。</span><span class="sxs-lookup"><span data-stu-id="75033-156">The type parameters for those two delegate types have to cross the ABI, so the type parameters must be Windows Runtime types, too.</span></span> <span data-ttu-id="75033-157">1 つ目とサード パーティのランタイム クラスの数値や文字列などのプリミティブ型も含まれます。</span><span class="sxs-lookup"><span data-stu-id="75033-157">That includes first- and third-party runtime classes, as well as primitive types such as numbers and strings.</span></span> <span data-ttu-id="75033-158">コンパイラで、"*WinRT 型でなければなりません*"その制約を忘れた場合のエラー。</span><span class="sxs-lookup"><span data-stu-id="75033-158">The compiler helps you with a "*must be WinRT type*" error if you forget that constraint.</span></span>

<span data-ttu-id="75033-159">パラメーターや、イベントの引数を渡す不要な場合は、独自の単純な Windows ランタイム デリゲート型を定義できます。</span><span class="sxs-lookup"><span data-stu-id="75033-159">If you don't need to pass any parameters or arguments with your event, then you can define your own simple Windows Runtime delegate type.</span></span> <span data-ttu-id="75033-160">次の例の単純なバージョンを示しています、 **BankAccount**ランタイム クラスです。</span><span class="sxs-lookup"><span data-stu-id="75033-160">The example below shows a simpler version of the **BankAccount** runtime class.</span></span> <span data-ttu-id="75033-161">という名前のデリゲート型を宣言して**SignalDelegate**を使用しているパラメーターを持つイベントではなく信号の種類のイベントを生成します。</span><span class="sxs-lookup"><span data-stu-id="75033-161">It declares a delegate type named **SignalDelegate** and then it uses that to raise a signal-type event instead of an event with a parameter.</span></span>

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

## <a name="parameterized-delegates-simple-signals-and-callbacks-within-a-project"></a><span data-ttu-id="75033-162">パラメーター化されたデリゲート、単純な信号、およびプロジェクト内でのコールバック</span><span class="sxs-lookup"><span data-stu-id="75033-162">Parameterized delegates, simple signals, and callbacks within a project</span></span>

<span data-ttu-id="75033-163">イベントを内部でのみ使用する場合、C + 内で/cli WinRT は、使用することも、(バイナリ)、全体ではなくプロジェクト、 [ **winrt::event** ](/uwp/cpp-ref-for-winrt/event)構造体のテンプレートがパラメーター C +/cli WinRT の非 Windows ランタイム[ **winrt::delegate&lt;.T&gt;**  ](/uwp/cpp-ref-for-winrt/delegate)構造体のテンプレートを効率的な参照カウントのデリゲートします。</span><span class="sxs-lookup"><span data-stu-id="75033-163">If your event is used only internally within your C++/WinRT project (not across binaries), then you still use the [**winrt::event**](/uwp/cpp-ref-for-winrt/event) struct template, but you parameterize it with C++/WinRT's non-Windows-Runtime [**winrt::delegate&lt;... T&gt;**](/uwp/cpp-ref-for-winrt/delegate) struct template, which is an efficient, reference-counted delegate.</span></span> <span data-ttu-id="75033-164">任意の数のパラメーターをサポートし、Windows ランタイム型に限定されてはいません。</span><span class="sxs-lookup"><span data-stu-id="75033-164">It supports any number of parameters, and they are not limited to Windows Runtime types.</span></span>

<span data-ttu-id="75033-165">(基本的には単純な信号を)、パラメーターがない署名とは文字列を受け取り、1、次の例は最初にデリゲートを示します。</span><span class="sxs-lookup"><span data-stu-id="75033-165">The example below first shows a delegate signature that doesn't take any parameters (essentially a simple signal), and then one that takes a string.</span></span>

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

<span data-ttu-id="75033-166">追加する方法、イベントに、必要に応じて多くのサブスクライブしているデリゲートに注意してください。</span><span class="sxs-lookup"><span data-stu-id="75033-166">Notice how you can add to the event as many subscribing delegates as you wish.</span></span> <span data-ttu-id="75033-167">ただし、イベントに関連付けられているいくつかのオーバーヘッドがあります。</span><span class="sxs-lookup"><span data-stu-id="75033-167">However, there is some overhead associated with an event.</span></span> <span data-ttu-id="75033-168">のみ単一サブスクライブするデリゲートで、単純なコールバックは、必要なかどうかを使用して[ **winrt::delegate&lt;.T&gt;**  ](/uwp/cpp-ref-for-winrt/delegate)独自にします。</span><span class="sxs-lookup"><span data-stu-id="75033-168">If all you need is a simple callback with only a single subscribing delegate, then you can use [**winrt::delegate&lt;... T&gt;**](/uwp/cpp-ref-for-winrt/delegate) on its own.</span></span>

```cppwinrt
winrt::delegate<> signalCallback;
signalCallback = [] { std::wcout << L"Hello, World!" << std::endl; };
signalCallback();

winrt::delegate<std::wstring> logCallback;
logCallback = [](std::wstring const& message) { std::wcout << message.c_str() << std::endl; }f;
logCallback(L"Hello, World!");
```

<span data-ttu-id="75033-169">C++ から移植している場合/cli CX コードベースでイベントとデリゲートを内部的に使用されます、プロジェクト内で、 **winrt::delegate** C + では、そのパターンをレプリケートする際に役立つ/cli WinRT します。</span><span class="sxs-lookup"><span data-stu-id="75033-169">If you're porting from a C++/CX codebase where events and delegates are used internally within a project, then **winrt::delegate** will help you to replicate that pattern in C++/WinRT.</span></span>

## <a name="design-guidelines"></a><span data-ttu-id="75033-170">設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="75033-170">Design guidelines</span></span>

<span data-ttu-id="75033-171">関数のパラメーターとしては、イベント、およびいないのデリゲートを渡すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="75033-171">We recommend that you pass events, and not delegates, as function parameters.</span></span> <span data-ttu-id="75033-172">**追加**関数の[ **winrt::event** ](/uwp/cpp-ref-for-winrt/event) 1 つの例外は、ため、その場合は、デリゲートを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="75033-172">The **add** function of [**winrt::event**](/uwp/cpp-ref-for-winrt/event) is the one exception, because you must pass a delegate in that case.</span></span> <span data-ttu-id="75033-173">このガイドラインの理由デリゲート (かどうか、1 つのクライアントの登録、または複数をサポート) に関するさまざまな Windows ランタイム言語のさまざまなフォームがかかるためにです。</span><span class="sxs-lookup"><span data-stu-id="75033-173">The reason for this guideline is because delegates can take different forms across different Windows Runtime languages (in terms of whether they support one client registration, or multiple).</span></span> <span data-ttu-id="75033-174">サブスクライバーが複数のモデルでのイベントより予測可能で一貫性のあるオプションを構成します。</span><span class="sxs-lookup"><span data-stu-id="75033-174">Events, with their multiple subscriber model, constitute a much more predictable and consistent option.</span></span>

<span data-ttu-id="75033-175">イベント ハンドラー デリゲートのシグネチャが 2 つのパラメーターで構成されます:*送信者*(**IInspectable**)、および*args* (たとえば一部イベント引数の型[ **RoutedEventArgs**](/uwp/api/windows.ui.xaml.routedeventargs))。</span><span class="sxs-lookup"><span data-stu-id="75033-175">The signature for an event handler delegate should consist of two parameters: *sender* (**IInspectable**), and *args* (some event argument type, for example [**RoutedEventArgs**](/uwp/api/windows.ui.xaml.routedeventargs)).</span></span>

<span data-ttu-id="75033-176">次のガイドラインの内部 API を設計する場合は必ずしも当てはまらないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="75033-176">Note that these guidelines don't necessarily apply if you're designing an internal API.</span></span> <span data-ttu-id="75033-177">ただし、多くの場合、内部 Api は時間のようになります公開します。</span><span class="sxs-lookup"><span data-stu-id="75033-177">Although, internal APIs often become public over time.</span></span>

## <a name="related-topics"></a><span data-ttu-id="75033-178">関連トピック</span><span class="sxs-lookup"><span data-stu-id="75033-178">Related topics</span></span>
* [<span data-ttu-id="75033-179">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="75033-179">Author APIs with C++/WinRT</span></span>](author-apis.md)
* [<span data-ttu-id="75033-180">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="75033-180">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="75033-181">C++/WinRT でのデリゲートを使用したイベントの処理</span><span class="sxs-lookup"><span data-stu-id="75033-181">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
