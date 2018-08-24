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
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2832413"
---
# <a name="author-events-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="a5d45-105">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="a5d45-105">Author events in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

<span data-ttu-id="a5d45-106">このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-106">This topic demonstrates how to author a Windows Runtime Component containing a runtime class representing a bank account, which raises an event when its balance goes into debit.</span></span> <span data-ttu-id="a5d45-107">銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-107">It also demonstrates a Core App that consumes the bank account runtime class, calls a function to adjust the balance, and handles any events that result.</span></span>

> [!NOTE]
> <span data-ttu-id="a5d45-108">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a5d45-108">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a5d45-109">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a5d45-109">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a><span data-ttu-id="a5d45-110">Windows ランタイム コンポーネントの作成 (BankAccountWRC)</span><span class="sxs-lookup"><span data-stu-id="a5d45-110">Create a Windows Runtime Component (BankAccountWRC)</span></span>

<span data-ttu-id="a5d45-111">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-111">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="a5d45-112">**Visual C++ Windows ランタイム コンポーネント (C++/WinRT)** プロジェクトを作成し、(「銀行口座 Windows ランタイム コンポーネント」用に) *BankAccountWRC* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-112">Create a **Visual C++ Windows Runtime Component (C++/WinRT)** project, and name it *BankAccountWRC* (for "bank account Windows Runtime Component").</span></span>

<span data-ttu-id="a5d45-113">新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="a5d45-113">The newly-created project contains a file named `Class.idl`.</span></span> <span data-ttu-id="a5d45-114">ファイルの名前を変更する`BankAccount.idl`(名前を変更する、`.idl`ファイル従属変数の名前を自動的に変更する`.h`と`.cpp`ファイルも)。</span><span class="sxs-lookup"><span data-stu-id="a5d45-114">Rename that file `BankAccount.idl` (renaming the `.idl` file automatically renames the dependent `.h` and `.cpp` files, too).</span></span> <span data-ttu-id="a5d45-115">目次を置き換える`BankAccount.idl`下の一覧にします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-115">Replace the contents of `BankAccount.idl` with the listing below.</span></span>

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

<span data-ttu-id="a5d45-116">ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-116">Save the file.</span></span> <span data-ttu-id="a5d45-117">現時点で完了するプロジェクトを作成できませんが、今すぐ建てる**BankAccount**ランタイム クラスを実装するが、ソース コード ファイルが生成されますので、便利なこと。</span><span class="sxs-lookup"><span data-stu-id="a5d45-117">The project won't build to completion at the moment, but building now is a useful thing to do because it generates the source code files in which you'll implement the **BankAccount** runtime class.</span></span> <span data-ttu-id="a5d45-118">これを作成するようになりました (この段階で表示するビルド エラーがで実行する必要がある`Class.h`と`Class.g.h`が見つからない) します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-118">So go ahead and build now (the build errors you can expect to see at this stage have to do with `Class.h` and `Class.g.h` not being found).</span></span> <span data-ttu-id="a5d45-119">ビルド処理中に、`midl.exe`ツールを実行して、コンポーネントの Windows ランタイム メタデータ ファイルを作成するのには (これが`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`)。</span><span class="sxs-lookup"><span data-stu-id="a5d45-119">During the build process, the `midl.exe` tool is run to create your component's Windows Runtime metadata file (which is `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`).</span></span> <span data-ttu-id="a5d45-120">次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-120">Then, the `cppwinrt.exe` tool is run (with the `-component` option) to generate source code files to support you in authoring your component.</span></span> <span data-ttu-id="a5d45-121">これらのファイルには、IDL 内で宣言した**BankAccount**ランタイム クラスの実装を使い始めるときにスタブが含まれます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-121">These files include stubs to get you started implementing the **BankAccount** runtime class that you declared in your IDL.</span></span> <span data-ttu-id="a5d45-122">これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="a5d45-122">Those stubs are `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` and `BankAccount.cpp`.</span></span>

<span data-ttu-id="a5d45-123">エクスプ ローラーでスタブ ファイルをコピー`BankAccount.h`と`BankAccount.cpp`フォルダーから`\BankAccountWRC\BankAccountWRC\Generated Files\sources\`はプロジェクト ファイルを含むフォルダーに`\BankAccountWRC\BankAccountWRC\`、コピー先のファイルを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-123">In File Explorer, copy the stub files `BankAccount.h` and `BankAccount.cpp` from the folder `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` into the folder that contains your project files, which is `\BankAccountWRC\BankAccountWRC\`, and replace the files in the destination.</span></span> <span data-ttu-id="a5d45-124">ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="a5d45-124">Now, let's open `BankAccount.h` and `BankAccount.cpp` and implement our runtime class.</span></span> <span data-ttu-id="a5d45-125">`BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-125">In `BankAccount.h`, add two private members to the implementation (*not* the factory implementation) of BankAccount.</span></span>

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

<span data-ttu-id="a5d45-126">上にあるわかるように、パラメーターの種類を特定の代理人の[**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体テンプレートは、イベントの実装します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-126">As you can see above, the event is implemented in terms of the [**winrt::event**](/uwp/cpp-ref-for-winrt/event) struct template, parameterized by a particular delegate type.</span></span>

<span data-ttu-id="a5d45-127">`BankAccount.cpp` で、次のコード例に示すように関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-127">In `BankAccount.cpp`, implement the functions as shown in the code example below.</span></span> <span data-ttu-id="a5d45-128">C++/WinRT では、IDL で宣言したイベントは過負荷の状態である関数のセットとして実装されます (プロパティが過負荷の状態の Get および Set 関数のペアとして実装される方法と同様です)。</span><span class="sxs-lookup"><span data-stu-id="a5d45-128">In C++/WinRT, an IDL-declared event is implemented as a set of overloaded functions (similar to the way a property is implemented as a pair of overloaded get and set functions).</span></span> <span data-ttu-id="a5d45-129">1 つのオーバーロードが登録するデリゲートを受け取り、トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-129">One overload takes a delegate to be registered, and returns a token.</span></span> <span data-ttu-id="a5d45-130">別のオーバーロードはトークンを受け取り、関連付けられているデリゲートの登録を取り消します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-130">The other takes a token, and revokes the registration of the associated delegate.</span></span>

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

<span data-ttu-id="a5d45-131">イベント リボーカーのオーバーロードを実装する必要はありません (詳細については、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください)。これは C++/WinRT プロジェクションで自動的に行われます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-131">You don't need to implement the overload for the event revoker (for details, see [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate))&mdash;that's taken care of for you by the C++/WinRT projection.</span></span> <span data-ttu-id="a5d45-132">別のオーバーロードは、開発者がシナリオに最適な方法で柔軟に実装できるようにするため、プロジェクションに書き込まれません。</span><span class="sxs-lookup"><span data-stu-id="a5d45-132">The other overloads are not baked into the projection, in order to give you the flexibility to implement them optimally for your scenario.</span></span> <span data-ttu-id="a5d45-133">このような [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) および [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) の呼び出しは、効率的で同時実行の安全性を確保できるスレッド セーフな既定値です。</span><span class="sxs-lookup"><span data-stu-id="a5d45-133">Calling [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) and [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) like this is an efficient and concurrency/thread-safe default.</span></span> <span data-ttu-id="a5d45-134">ただし、大量のイベントがある場合は、各イベントのイベント フィールドが必要ないことがあり、代わりに、ある種のスパース実装を選択します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-134">But if you have a very large number of events, then you may not want an event field for each, but rather opt for some kind of sparse implementation instead.</span></span>

<span data-ttu-id="a5d45-135">また、**AdjustBalance** 関数の実装によって、残高が負の値になった場合でも **AccountIsInDebit** イベントが発生することを上で確認できます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-135">You can also see above that the implementation of the **AdjustBalance** function raises the **AccountIsInDebit** event if the balance goes negative.</span></span>

<span data-ttu-id="a5d45-136">できない場合は、警告を文書から、それらを解決するか**C/C++** のプロジェクトのプロパティを設定する > **一般的な** > に**警告をエラーとして扱う****なし (/WX-)**、もう一度プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-136">If any warnings prevent you from building, then either resolve them or set the project property **C/C++** > **General** > **Treat Warnings As Errors** to **No (/WX-)**, and build the project again.</span></span>

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a><span data-ttu-id="a5d45-137">コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-137">Create a Core App (BankAccountCoreApp) to test the Windows Runtime Component</span></span>

<span data-ttu-id="a5d45-138">ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-138">Now create a new project (either in your `BankAccountWRC` solution, or in a new one).</span></span> <span data-ttu-id="a5d45-139">**Visual C++ コア アプリ (C++/WinRT)** プロジェクトを作成し、*BankAccountCoreApp* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-139">Create a **Visual C++ Core App (C++/WinRT)** project, and name it *BankAccountCoreApp*.</span></span>

<span data-ttu-id="a5d45-140">参照を追加しを参照`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`(または参照を追加するプロジェクト間、2 つのプロジェクトで同じソリューションの場合)。</span><span class="sxs-lookup"><span data-stu-id="a5d45-140">Add a reference, and browse to `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` (or add a project-to-project reference, if the two projects are in the same solution).</span></span> <span data-ttu-id="a5d45-141">**[追加]** をクリックして **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-141">Click **Add**, and then **OK**.</span></span> <span data-ttu-id="a5d45-142">ここで BankAccountCoreApp をビルドします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-142">Now build BankAccountCoreApp.</span></span> <span data-ttu-id="a5d45-143">予想外の場合に備えてエラーが表示される本体ファイル`readme.txt`が存在する、そのファイルを Windows ランタイム コンポーネントのプロジェクトから除外する、再構築] [BankAccountCoreApp を再構築しません。</span><span class="sxs-lookup"><span data-stu-id="a5d45-143">In the unlikely event that you see an error that the payload file `readme.txt` doesn't exist, exclude that file from the Windows Runtime Component project, rebuild it, then rebuild BankAccountCoreApp.</span></span>

<span data-ttu-id="a5d45-144">ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-144">During the build process, the `cppwinrt.exe` tool is run to process the referenced `.winmd` file into source code files containing projected types to support you in consuming your component.</span></span> <span data-ttu-id="a5d45-145">コンポーネントのランタイム クラス (`BankAccountWRC.h`という名前) の投影型のヘッダーは、フォルダー `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\` 内に生成されます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-145">The header for the projected types for your component's runtime classes&mdash;named `BankAccountWRC.h`&mdash;is generated into the folder `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\`.</span></span>

<span data-ttu-id="a5d45-146">そのヘッダーを `App.cpp` に含めます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-146">Include that header in `App.cpp`.</span></span>

```cppwinrt
#include <winrt/BankAccountWRC.h>
```

<span data-ttu-id="a5d45-147">`App.cpp` でも、(投影型の既定のコンストラクターを使用して) BankAccount のインスタンスを作成するために次のコードを追加し、イベント ハンドラーを登録して、口座が借方に入るようにします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-147">Also in `App.cpp`, add the following code to instantiate a BankAccount (using the projected type's default constructor), register an event handler, and then cause the account to go into debit.</span></span>

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

<span data-ttu-id="a5d45-148">ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-148">Each time you click the window, you subtract 1 from the bank account's balance.</span></span> <span data-ttu-id="a5d45-149">想定どおりにイベントが発生することを示すためには、 **AccountIsInDebit**イベントを処理する λ 式内にブレークポイント、アプリを実行し、ウィンドウ内をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-149">To demonstrate that the event is being raised as expected, put a breakpoint inside the lambda expression that's handling the **AccountIsInDebit** event, run the app, and click inside the window.</span></span>

## <a name="parameterized-delegates-and-simple-signals-across-an-abi"></a><span data-ttu-id="a5d45-150">パラメーターの代理人と ABI にわたって、単純なシグナル</span><span class="sxs-lookup"><span data-stu-id="a5d45-150">Parameterized delegates, and simple signals, across an ABI</span></span>

<span data-ttu-id="a5d45-151">アプリケーション バイナリ インターフェイス (ABI) の間でイベントをアクセス可能にする必要があるかどうか&mdash;コンポーネントとその消費アプリケーション間など&mdash;し、イベントが Windows ランタイム代理人の種類を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a5d45-151">If your event must be accessible across an application binary interface (ABI)&mdash;such as between a component and its consuming application&mdash;then your event must use a Windows Runtime delegate type.</span></span> <span data-ttu-id="a5d45-152">上記の例では、 [**Windows::Foundation::EventHandler\ < T\ >**](/uwp/api/windows.foundation.eventhandler) Windows ランタイム デリゲート型を使用します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-152">The example above uses the [**Windows::Foundation::EventHandler\<T\>**](/uwp/api/windows.foundation.eventhandler) Windows Runtime delegate type.</span></span> <span data-ttu-id="a5d45-153">[**TypedEventHandler\ < TSender、TResult\ >**](/uwp/api/windows.foundation.eventhandler)では、Windows ランタイム代理人の種類の別の例を示します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-153">[**TypedEventHandler\<TSender, TResult\>**](/uwp/api/windows.foundation.eventhandler) is another example of a Windows Runtime delegate type.</span></span>

<span data-ttu-id="a5d45-154">型のパラメーターが Windows ランタイムの種類] にもする必要がありますので、ABI を相互にする 2 つの代理人の種類の型のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="a5d45-154">The type parameters for those two delegate types have to cross the ABI, so the type parameters must be Windows Runtime types, too.</span></span> <span data-ttu-id="a5d45-155">最初とサードパーティ ランタイム クラス] の番号と文字列などのプリミティブ型も含まれます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-155">That includes first- and third-party runtime classes, as well as primitive types such as numbers and strings.</span></span> <span data-ttu-id="a5d45-156">コンパイラできます「*WinRT 型である必要があります*」のエラーがその制約を忘れた場合。</span><span class="sxs-lookup"><span data-stu-id="a5d45-156">The compiler helps you with a "*must be WinRT type*" error if you forget that constraint.</span></span>

<span data-ttu-id="a5d45-157">パラメーターまたはイベントの引数に渡す必要がない場合は、独自の簡単な Windows ランタイム代理人タイプを定義できます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-157">If you don't need to pass any parameters or arguments with your event, then you can define your own simple Windows Runtime delegate type.</span></span> <span data-ttu-id="a5d45-158">次の例では、 **BankAccount**ランタイム クラスの簡易バージョンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-158">The example below shows a simpler version of the **BankAccount** runtime class.</span></span> <span data-ttu-id="a5d45-159">**SignalDelegate**という名前の代理人のタイプを宣言して、[を使用しているパラメーターを使ってイベントではなく信号の種類のイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-159">It declares a delegate type named **SignalDelegate** and then it uses that to raise a signal-type event instead of an event with a parameter.</span></span>

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

## <a name="parameterized-delegates-simple-signals-and-callbacks-within-a-project"></a><span data-ttu-id="a5d45-160">パラメーター化された代理人、単純なシグナルとプロジェクト内でコールバック</span><span class="sxs-lookup"><span data-stu-id="a5d45-160">Parameterized delegates, simple signals, and callbacks within a project</span></span>

<span data-ttu-id="a5d45-161">イベントが内部でのみ使用されている場合、C + 内 +/ [**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体テンプレートを使用するが、C + パラメーター化し、(バイナリ)、全体ではなく、WinRT がプロジェクト +/WinRT の非 Windows ランタイム[**winrt::delegate&lt;.T&gt;**](/uwp/cpp-ref-for-winrt/delegate)構造体テンプレートを効率的に使用、参照カウントの代理人。</span><span class="sxs-lookup"><span data-stu-id="a5d45-161">If your event is used only internally within your C++/WinRT project (not across binaries), then you still use the [**winrt::event**](/uwp/cpp-ref-for-winrt/event) struct template, but you parameterize it with C++/WinRT's non-Windows-Runtime [**winrt::delegate&lt;... T&gt;**](/uwp/cpp-ref-for-winrt/delegate) struct template, which is an efficient, reference-counted delegate.</span></span> <span data-ttu-id="a5d45-162">パラメーターの任意の数がサポートされると、Windows ランタイム型に制限はします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-162">It supports any number of parameters, and they are not limited to Windows Runtime types.</span></span>

<span data-ttu-id="a5d45-163">次の例は、パラメーター (基本的には、単純な信号) ほどかかりません署名と文字列は、1 つを代理人をまず表示されます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-163">The example below first shows a delegate signature that doesn't take any parameters (essentially a simple signal), and then one that takes a string.</span></span>

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

<span data-ttu-id="a5d45-164">追加する方法、イベントにだけのサブスクライブする代理人必要に応じてに注意してください。</span><span class="sxs-lookup"><span data-stu-id="a5d45-164">Notice how you can add to the event as many subscribing delegates as you wish.</span></span> <span data-ttu-id="a5d45-165">ただし、イベントに関連付けられている一部の頭上ことができます。</span><span class="sxs-lookup"><span data-stu-id="a5d45-165">However, there is some overhead associated with an event.</span></span> <span data-ttu-id="a5d45-166">単純なコールバックのみを 1 つサブスクライブする代理人] では、必要なかどうかは、 [**winrt::delegate を使用する&lt;.T&gt;**](/uwp/cpp-ref-for-winrt/delegate)専用にします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-166">If all you need is a simple callback with only a single subscribing delegate, then you can use [**winrt::delegate&lt;... T&gt;**](/uwp/cpp-ref-for-winrt/delegate) on its own.</span></span>

```cppwinrt
winrt::delegate<> signalCallback;
signalCallback = [] { std::wcout << L"Hello, World!" << std::endl; };
signalCallback();

winrt::delegate<std::wstring> logCallback;
logCallback = [](std::wstring const& message) { std::wcout << message.c_str() << std::endl; }f;
logCallback(L"Hello, World!");
```

<span data-ttu-id="a5d45-167">C + から移植する場合は、+/CX コードベースのイベントと代理人は、プロジェクト内で内部で使用し、[ **winrt::delegate**に役立つ C + でそのパターンを複製する場所 +/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-167">If you're porting from a C++/CX codebase where events and delegates are used internally within a project, then **winrt::delegate** will help you to replicate that pattern in C++/WinRT.</span></span>

## <a name="design-guidelines"></a><span data-ttu-id="a5d45-168">設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="a5d45-168">Design guidelines</span></span>

<span data-ttu-id="a5d45-169">関数のパラメーターとして、代理人いないと、イベントを通過することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a5d45-169">We recommend that you pass events, and not delegates, as function parameters.</span></span> <span data-ttu-id="a5d45-170">[**Winrt::event**](/uwp/cpp-ref-for-winrt/event)の関数を**追加**は、1 つの例外は、その場合は、代理人を渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="a5d45-170">The **add** function of [**winrt::event**](/uwp/cpp-ref-for-winrt/event) is the one exception, because you must pass a delegate in that case.</span></span> <span data-ttu-id="a5d45-171">このガイドラインの理由は、代理人には、さまざまな形式 (かどうかが 1 つのクライアントの登録、または複数をサポート) は Windows ランタイム言語が異なるためにです。</span><span class="sxs-lookup"><span data-stu-id="a5d45-171">The reason for this guideline is because delegates can take different forms across different Windows Runtime languages (in terms of whether they support one client registration, or multiple).</span></span> <span data-ttu-id="a5d45-172">イベントの複数のサブスクライバー モデルを予測可能で一貫性のあるオプションを構成します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-172">Events, with their multiple subscriber model, constitute a much more predictable and consistent option.</span></span>

<span data-ttu-id="a5d45-173">2 つのパラメーターのイベント ハンドラーの代理人の署名を含める必要があります:*送信者*(**IInspectable**)、および*引数*(一部のイベントの引数の型、[**特に**](/uwp/api/windows.ui.xaml.routedeventargs)など)。</span><span class="sxs-lookup"><span data-stu-id="a5d45-173">The signature for an event handler delegate should consist of two parameters: *sender* (**IInspectable**), and *args* (some event argument type, for example [**RoutedEventArgs**](/uwp/api/windows.ui.xaml.routedeventargs)).</span></span>

<span data-ttu-id="a5d45-174">内部 API を設計する場合、次のガイドラインは適用でないしないことに注意します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-174">Note that these guidelines don't necessarily apply if you're designing an internal API.</span></span> <span data-ttu-id="a5d45-175">ただし、内部 Api がちパブリック時間の経過します。</span><span class="sxs-lookup"><span data-stu-id="a5d45-175">Although, internal APIs often become public over time.</span></span>

## <a name="related-topics"></a><span data-ttu-id="a5d45-176">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a5d45-176">Related topics</span></span>
* [<span data-ttu-id="a5d45-177">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="a5d45-177">Author APIs with C++/WinRT</span></span>](author-apis.md)
* [<span data-ttu-id="a5d45-178">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="a5d45-178">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="a5d45-179">C++/WinRT でデリゲートを使用してイベントを処理する</span><span class="sxs-lookup"><span data-stu-id="a5d45-179">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
