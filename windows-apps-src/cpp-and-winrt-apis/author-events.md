---
author: stevewhims
description: このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。
title: C++/WinRT でのイベントの作成
ms.author: stwhi
ms.date: 07/18/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 作成者, イベント
ms.localizationpriority: medium
ms.openlocfilehash: 2c4d36fa22953bc4745b631303aae62985a5aa05
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5975164"
---
# <a name="author-events-in-cwinrt"></a><span data-ttu-id="967d4-105">C++/WinRT でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="967d4-105">Author events in C++/WinRT</span></span>

<span data-ttu-id="967d4-106">このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="967d4-106">This topic demonstrates how to author a Windows Runtime Component containing a runtime class representing a bank account, which raises an event when its balance goes into debit.</span></span> <span data-ttu-id="967d4-107">銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。</span><span class="sxs-lookup"><span data-stu-id="967d4-107">It also demonstrates a Core App that consumes the bank account runtime class, calls a function to adjust the balance, and handles any events that result.</span></span>

> [!NOTE]
> <span data-ttu-id="967d4-108">インストールと使用方法については、 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートと同様、C++ を提供する//winrt MSBuild プロパティとターゲット) を参照してください[、C++、Visual Studio サポート +/winrt と VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)します。</span><span class="sxs-lookup"><span data-stu-id="967d4-108">For info about installing and using the [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="967d4-109">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="967d4-109">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a><span data-ttu-id="967d4-110">Windows ランタイム コンポーネントの作成 (BankAccountWRC)</span><span class="sxs-lookup"><span data-stu-id="967d4-110">Create a Windows Runtime Component (BankAccountWRC)</span></span>

<span data-ttu-id="967d4-111">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="967d4-111">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="967d4-112">**Visual C**を作成 > **Windows ユニバーサル** > **Windows ランタイム コンポーネント (、C++/WinRT)** プロジェクト、および名前を付けます*BankAccountWRC* (「銀行口座 Windows ランタイム コンポーネント」)。</span><span class="sxs-lookup"><span data-stu-id="967d4-112">Create a **Visual C++** > **Windows Universal** > **Windows Runtime Component (C++/WinRT)** project, and name it *BankAccountWRC* (for "bank account Windows Runtime Component").</span></span>

<span data-ttu-id="967d4-113">新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="967d4-113">The newly-created project contains a file named `Class.idl`.</span></span> <span data-ttu-id="967d4-114">そのファイルの名前を変更`BankAccount.idl`(名前を変更する、`.idl`ファイル、依存の名前を自動的に変更する`.h`と`.cpp`ファイル、すぎます)。</span><span class="sxs-lookup"><span data-stu-id="967d4-114">Rename that file `BankAccount.idl` (renaming the `.idl` file automatically renames the dependent `.h` and `.cpp` files, too).</span></span> <span data-ttu-id="967d4-115">内容を置き換える`BankAccount.idl`以下のリストとします。</span><span class="sxs-lookup"><span data-stu-id="967d4-115">Replace the contents of `BankAccount.idl` with the listing below.</span></span>

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

<span data-ttu-id="967d4-116">ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="967d4-116">Save the file.</span></span> <span data-ttu-id="967d4-117">現時点で完了するまで、プロジェクトのビルドはありませんが、 **BankAccount**のランタイム クラスを実装するが、ソース コード ファイルが生成されるために有用なことは、構築できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="967d4-117">The project won't build to completion at the moment, but building now is a useful thing to do because it generates the source code files in which you'll implement the **BankAccount** runtime class.</span></span> <span data-ttu-id="967d4-118">ように指示してビルドできるようになりました (この段階で確認すると、ビルド エラーの処理が必要な`Class.h`と`Class.g.h`が見つかりません。)。</span><span class="sxs-lookup"><span data-stu-id="967d4-118">So go ahead and build now (the build errors you can expect to see at this stage have to do with `Class.h` and `Class.g.h` not being found).</span></span> <span data-ttu-id="967d4-119">ビルド プロセス中に、`midl.exe`ツールが実行され、コンポーネントの Windows ランタイム メタデータ ファイルを作成する (これは`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`)。</span><span class="sxs-lookup"><span data-stu-id="967d4-119">During the build process, the `midl.exe` tool is run to create your component's Windows Runtime metadata file (which is `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`).</span></span> <span data-ttu-id="967d4-120">次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="967d4-120">Then, the `cppwinrt.exe` tool is run (with the `-component` option) to generate source code files to support you in authoring your component.</span></span> <span data-ttu-id="967d4-121">これらのファイルには、IDL で宣言した**BankAccount**のランタイム クラスの実装を開始するためのスタブが含まれます。</span><span class="sxs-lookup"><span data-stu-id="967d4-121">These files include stubs to get you started implementing the **BankAccount** runtime class that you declared in your IDL.</span></span> <span data-ttu-id="967d4-122">これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="967d4-122">Those stubs are `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` and `BankAccount.cpp`.</span></span>

<span data-ttu-id="967d4-123">エクスプ ローラーでスタブ ファイルをコピー`BankAccount.h`と`BankAccount.cpp`フォルダーから`\BankAccountWRC\BankAccountWRC\Generated Files\sources\`は、プロジェクト ファイルが含まれているフォルダーに`\BankAccountWRC\BankAccountWRC\`、コピー先のファイルを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="967d4-123">In File Explorer, copy the stub files `BankAccount.h` and `BankAccount.cpp` from the folder `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` into the folder that contains your project files, which is `\BankAccountWRC\BankAccountWRC\`, and replace the files in the destination.</span></span> <span data-ttu-id="967d4-124">ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="967d4-124">Now, let's open `BankAccount.h` and `BankAccount.cpp` and implement our runtime class.</span></span> <span data-ttu-id="967d4-125">`BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="967d4-125">In `BankAccount.h`, add two private members to the implementation (*not* the factory implementation) of BankAccount.</span></span>

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

<span data-ttu-id="967d4-126">上わかるように、特定のデリゲート型によってパラメーター化[**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体のテンプレートの観点から、イベントが実装されます。</span><span class="sxs-lookup"><span data-stu-id="967d4-126">As you can see above, the event is implemented in terms of the [**winrt::event**](/uwp/cpp-ref-for-winrt/event) struct template, parameterized by a particular delegate type.</span></span>

<span data-ttu-id="967d4-127">`BankAccount.cpp` で、次のコード例に示すように関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="967d4-127">In `BankAccount.cpp`, implement the functions as shown in the code example below.</span></span> <span data-ttu-id="967d4-128">C++/WinRT では、IDL で宣言したイベントは過負荷の状態である関数のセットとして実装されます (プロパティが過負荷の状態の Get および Set 関数のペアとして実装される方法と同様です)。</span><span class="sxs-lookup"><span data-stu-id="967d4-128">In C++/WinRT, an IDL-declared event is implemented as a set of overloaded functions (similar to the way a property is implemented as a pair of overloaded get and set functions).</span></span> <span data-ttu-id="967d4-129">1 つのオーバーロードが登録するデリゲートを受け取り、トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="967d4-129">One overload takes a delegate to be registered, and returns a token.</span></span> <span data-ttu-id="967d4-130">別のオーバーロードはトークンを受け取り、関連付けられているデリゲートの登録を取り消します。</span><span class="sxs-lookup"><span data-stu-id="967d4-130">The other takes a token, and revokes the registration of the associated delegate.</span></span>

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

<span data-ttu-id="967d4-131">イベント リボーカーのオーバーロードを実装する必要はありません (詳細については、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください)。これは C++/WinRT プロジェクションで自動的に行われます。</span><span class="sxs-lookup"><span data-stu-id="967d4-131">You don't need to implement the overload for the event revoker (for details, see [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate))&mdash;that's taken care of for you by the C++/WinRT projection.</span></span> <span data-ttu-id="967d4-132">別のオーバーロードは、開発者がシナリオに最適な方法で柔軟に実装できるようにするため、プロジェクションに書き込まれません。</span><span class="sxs-lookup"><span data-stu-id="967d4-132">The other overloads are not baked into the projection, in order to give you the flexibility to implement them optimally for your scenario.</span></span> <span data-ttu-id="967d4-133">このような [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) および [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) の呼び出しは、効率的で同時実行の安全性を確保できるスレッド セーフな既定値です。</span><span class="sxs-lookup"><span data-stu-id="967d4-133">Calling [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) and [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) like this is an efficient and concurrency/thread-safe default.</span></span> <span data-ttu-id="967d4-134">ただし、大量のイベントがある場合は、各イベントのイベント フィールドが必要ないことがあり、代わりに、ある種のスパース実装を選択します。</span><span class="sxs-lookup"><span data-stu-id="967d4-134">But if you have a very large number of events, then you may not want an event field for each, but rather opt for some kind of sparse implementation instead.</span></span>

<span data-ttu-id="967d4-135">また、**AdjustBalance** 関数の実装によって、残高が負の値になった場合でも **AccountIsInDebit** イベントが発生することを上で確認できます。</span><span class="sxs-lookup"><span data-stu-id="967d4-135">You can also see above that the implementation of the **AdjustBalance** function raises the **AccountIsInDebit** event if the balance goes negative.</span></span>

<span data-ttu-id="967d4-136">警告がビルドを妨げる場合、それを解決または**C/C++** プロジェクトのプロパティを設定 > **一般的な** > に**警告をエラーとして扱う\*\*\*\*いいえ (/WX-)**、もう一度プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="967d4-136">If any warnings prevent you from building, then either resolve them or set the project property **C/C++** > **General** > **Treat Warnings As Errors** to **No (/WX-)**, and build the project again.</span></span>

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a><span data-ttu-id="967d4-137">コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。</span><span class="sxs-lookup"><span data-stu-id="967d4-137">Create a Core App (BankAccountCoreApp) to test the Windows Runtime Component</span></span>

<span data-ttu-id="967d4-138">ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="967d4-138">Now create a new project (either in your `BankAccountWRC` solution, or in a new one).</span></span> <span data-ttu-id="967d4-139">**Visual C**を作成 > **Windows ユニバーサル** > **コア アプリ (、C++/WinRT)** プロジェクト、および*BankAccountCoreApp*名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="967d4-139">Create a **Visual C++** > **Windows Universal** > **Core App (C++/WinRT)** project, and name it *BankAccountCoreApp*.</span></span>

<span data-ttu-id="967d4-140">参照を追加しを参照`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`(または 2 つのプロジェクトが同じソリューションに属している場合は、プロジェクト間の参照を追加)。</span><span class="sxs-lookup"><span data-stu-id="967d4-140">Add a reference, and browse to `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` (or add a project-to-project reference, if the two projects are in the same solution).</span></span> <span data-ttu-id="967d4-141">**[追加]** をクリックして **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="967d4-141">Click **Add**, and then **OK**.</span></span> <span data-ttu-id="967d4-142">ここで BankAccountCoreApp をビルドします。</span><span class="sxs-lookup"><span data-stu-id="967d4-142">Now build BankAccountCoreApp.</span></span> <span data-ttu-id="967d4-143">エラーが表示される万が一のイベントをペイロード ファイル`readme.txt`しない存在 Windows ランタイム コンポーネント プロジェクトからそのファイルを除外する、してから、BankAccountCoreApp を再構築します。</span><span class="sxs-lookup"><span data-stu-id="967d4-143">In the unlikely event that you see an error that the payload file `readme.txt` doesn't exist, exclude that file from the Windows Runtime Component project, rebuild it, then rebuild BankAccountCoreApp.</span></span>

<span data-ttu-id="967d4-144">ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。</span><span class="sxs-lookup"><span data-stu-id="967d4-144">During the build process, the `cppwinrt.exe` tool is run to process the referenced `.winmd` file into source code files containing projected types to support you in consuming your component.</span></span> <span data-ttu-id="967d4-145">コンポーネントのランタイム クラス (`BankAccountWRC.h`という名前) の投影型のヘッダーは、フォルダー `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\` 内に生成されます。</span><span class="sxs-lookup"><span data-stu-id="967d4-145">The header for the projected types for your component's runtime classes&mdash;named `BankAccountWRC.h`&mdash;is generated into the folder `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\`.</span></span>

<span data-ttu-id="967d4-146">そのヘッダーを `App.cpp` に含めます。</span><span class="sxs-lookup"><span data-stu-id="967d4-146">Include that header in `App.cpp`.</span></span>

```cppwinrt
#include <winrt/BankAccountWRC.h>
```

<span data-ttu-id="967d4-147">`App.cpp` でも、(投影型の既定のコンストラクターを使用して) BankAccount のインスタンスを作成するために次のコードを追加し、イベント ハンドラーを登録して、口座が借方に入るようにします。</span><span class="sxs-lookup"><span data-stu-id="967d4-147">Also in `App.cpp`, add the following code to instantiate a BankAccount (using the projected type's default constructor), register an event handler, and then cause the account to go into debit.</span></span>

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

<span data-ttu-id="967d4-148">ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。</span><span class="sxs-lookup"><span data-stu-id="967d4-148">Each time you click the window, you subtract 1 from the bank account's balance.</span></span> <span data-ttu-id="967d4-149">期待どおりにイベントが発生することを示すためには、 **AccountIsInDebit**イベントを処理するラムダ式内にブレークポイントを配置、アプリを実行し、ウィンドウ内をクリックします。</span><span class="sxs-lookup"><span data-stu-id="967d4-149">To demonstrate that the event is being raised as expected, put a breakpoint inside the lambda expression that's handling the **AccountIsInDebit** event, run the app, and click inside the window.</span></span>

## <a name="parameterized-delegates-and-simple-signals-across-an-abi"></a><span data-ttu-id="967d4-150">パラメーターのデリゲートと ABI 間での単純な信号</span><span class="sxs-lookup"><span data-stu-id="967d4-150">Parameterized delegates, and simple signals, across an ABI</span></span>

<span data-ttu-id="967d4-151">イベントをアプリケーション バイナリ インターフェイス (ABI) の間でアクセスできる必要があるかどうか&mdash;コンポーネントとその使用中のアプリケーション間など&mdash;、イベントは、Windows ランタイムのデリゲート型を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="967d4-151">If your event must be accessible across an application binary interface (ABI)&mdash;such as between a component and its consuming application&mdash;then your event must use a Windows Runtime delegate type.</span></span> <span data-ttu-id="967d4-152">上記の例では、Windows ランタイムの[**Windows::Foundation::EventHandler\ < t \ >**](/uwp/api/windows.foundation.eventhandler)のデリゲート型を使用します。</span><span class="sxs-lookup"><span data-stu-id="967d4-152">The example above uses the [**Windows::Foundation::EventHandler\<T\>**](/uwp/api/windows.foundation.eventhandler) Windows Runtime delegate type.</span></span> <span data-ttu-id="967d4-153">[**TypedEventHandler\ < TSender, TResult\ >**](/uwp/api/windows.foundation.eventhandler)は、Windows ランタイムのデリゲート型の別の例を示します。</span><span class="sxs-lookup"><span data-stu-id="967d4-153">[**TypedEventHandler\<TSender, TResult\>**](/uwp/api/windows.foundation.eventhandler) is another example of a Windows Runtime delegate type.</span></span>

<span data-ttu-id="967d4-154">これらの 2 つのデリゲート型の型のパラメーターは、型のパラメーターでは、Windows ランタイム型をもする必要がありますので、ABI を通過する必要があります。</span><span class="sxs-lookup"><span data-stu-id="967d4-154">The type parameters for those two delegate types have to cross the ABI, so the type parameters must be Windows Runtime types, too.</span></span> <span data-ttu-id="967d4-155">数字と文字列などのプリミティブ型と同様に、ファーストおよびサード パーティ製のランタイム クラスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="967d4-155">That includes first- and third-party runtime classes, as well as primitive types such as numbers and strings.</span></span> <span data-ttu-id="967d4-156">コンパイラは、"*WinRT 型である必要がある*"エラーのためにその制約を忘れた場合するように役立ちます。</span><span class="sxs-lookup"><span data-stu-id="967d4-156">The compiler helps you with a "*must be WinRT type*" error if you forget that constraint.</span></span>

<span data-ttu-id="967d4-157">任意のパラメーターやイベントの引数を渡す必要があるしない、独自の単純な Windows ランタイム デリゲート型を定義できます。</span><span class="sxs-lookup"><span data-stu-id="967d4-157">If you don't need to pass any parameters or arguments with your event, then you can define your own simple Windows Runtime delegate type.</span></span> <span data-ttu-id="967d4-158">次の例は、 **BankAccount**のランタイム クラスの簡易バージョンを示しています。</span><span class="sxs-lookup"><span data-stu-id="967d4-158">The example below shows a simpler version of the **BankAccount** runtime class.</span></span> <span data-ttu-id="967d4-159">**SignalDelegate**をという名前のデリゲート型を宣言し、それを使用しているパラメーターを持つイベントではなく信号の種類のイベントを発生させます。</span><span class="sxs-lookup"><span data-stu-id="967d4-159">It declares a delegate type named **SignalDelegate** and then it uses that to raise a signal-type event instead of an event with a parameter.</span></span>

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

## <a name="parameterized-delegates-simple-signals-and-callbacks-within-a-project"></a><span data-ttu-id="967d4-160">デリゲートをパラメーター化された、単純な信号は、プロジェクト内でコールバック</span><span class="sxs-lookup"><span data-stu-id="967d4-160">Parameterized delegates, simple signals, and callbacks within a project</span></span>

<span data-ttu-id="967d4-161">イベントが内部でのみ使われる場合内で c++/cli [**winrt::event**](/uwp/cpp-ref-for-winrt/event)構造体のテンプレートを使用するが、c++ パラメーター化し、(バイナリ) ではなくプロジェクトの WinRT/WinRT の Windows ランタイムではない[\*\*winrt::delegate&lt;.T&gt; \*\*](/uwp/cpp-ref-for-winrt/delegate) 、効率的で参照カウントのデリゲートは、構造体のテンプレートです。</span><span class="sxs-lookup"><span data-stu-id="967d4-161">If your event is used only internally within your C++/WinRT project (not across binaries), then you still use the [**winrt::event**](/uwp/cpp-ref-for-winrt/event) struct template, but you parameterize it with C++/WinRT's non-Windows-Runtime [**winrt::delegate&lt;... T&gt;**](/uwp/cpp-ref-for-winrt/delegate) struct template, which is an efficient, reference-counted delegate.</span></span> <span data-ttu-id="967d4-162">任意の数のパラメーターをサポートしていると、Windows ランタイム型に制限はないです。</span><span class="sxs-lookup"><span data-stu-id="967d4-162">It supports any number of parameters, and they are not limited to Windows Runtime types.</span></span>

<span data-ttu-id="967d4-163">次の例は、パラメーター (本質的には、単純な信号) を実行しない署名し、文字列をいずれかに最初にデリゲートを示します。</span><span class="sxs-lookup"><span data-stu-id="967d4-163">The example below first shows a delegate signature that doesn't take any parameters (essentially a simple signal), and then one that takes a string.</span></span>

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

<span data-ttu-id="967d4-164">追加する方法、イベントに必要な数のサブスクライブするデリゲートに注意してください。</span><span class="sxs-lookup"><span data-stu-id="967d4-164">Notice how you can add to the event as many subscribing delegates as you wish.</span></span> <span data-ttu-id="967d4-165">ただし、これにはイベントに関連付けられているいくつかのオーバーヘッドがあります。</span><span class="sxs-lookup"><span data-stu-id="967d4-165">However, there is some overhead associated with an event.</span></span> <span data-ttu-id="967d4-166">デリゲートを使用したのみ単一サブスクライブする、シンプルなコールバックが必要なすべてのかどうか、 [**winrt::delegate を使用する&lt;.T&gt;**](/uwp/cpp-ref-for-winrt/delegate)独自にします。</span><span class="sxs-lookup"><span data-stu-id="967d4-166">If all you need is a simple callback with only a single subscribing delegate, then you can use [**winrt::delegate&lt;... T&gt;**](/uwp/cpp-ref-for-winrt/delegate) on its own.</span></span>

```cppwinrt
winrt::delegate<> signalCallback;
signalCallback = [] { std::wcout << L"Hello, World!" << std::endl; };
signalCallback();

winrt::delegate<std::wstring> logCallback;
logCallback = [](std::wstring const& message) { std::wcout << message.c_str() << std::endl; }f;
logCallback(L"Hello, World!");
```

<span data-ttu-id="967d4-167">C++ から移植している場合 +/CX コードベース場所、プロジェクト内にイベントとデリゲートが内部的に使用されるし、C++ でそのパターンをレプリケートするため**winrt::delegate** /WinRT します。</span><span class="sxs-lookup"><span data-stu-id="967d4-167">If you're porting from a C++/CX codebase where events and delegates are used internally within a project, then **winrt::delegate** will help you to replicate that pattern in C++/WinRT.</span></span>

## <a name="design-guidelines"></a><span data-ttu-id="967d4-168">設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="967d4-168">Design guidelines</span></span>

<span data-ttu-id="967d4-169">イベント、およびいないのデリゲートを関数パラメーターとして渡すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="967d4-169">We recommend that you pass events, and not delegates, as function parameters.</span></span> <span data-ttu-id="967d4-170">[**Winrt::event**](/uwp/cpp-ref-for-winrt/event)の**追加**機能では、1 つの例外はその場合はデリゲートを渡す必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="967d4-170">The **add** function of [**winrt::event**](/uwp/cpp-ref-for-winrt/event) is the one exception, because you must pass a delegate in that case.</span></span> <span data-ttu-id="967d4-171">デリゲートは、さまざまな形式が (の観点からするかどうか 1 つのクライアントの登録、または複数のサポート) のさまざまな Windows ランタイム言語間でこのガイドラインの理由です。</span><span class="sxs-lookup"><span data-stu-id="967d4-171">The reason for this guideline is because delegates can take different forms across different Windows Runtime languages (in terms of whether they support one client registration, or multiple).</span></span> <span data-ttu-id="967d4-172">複数のサブスクライバー モデルでのイベントは、予測可能で一貫性のあるオプションを構成します。</span><span class="sxs-lookup"><span data-stu-id="967d4-172">Events, with their multiple subscriber model, constitute a much more predictable and consistent option.</span></span>

<span data-ttu-id="967d4-173">イベント ハンドラー デリゲートの署名がの 2 つのパラメーターで構成する必要があります:*送信者*(**IInspectable**) と*引数*(一部イベント引数の型、 [**RoutedEventArgs**](/uwp/api/windows.ui.xaml.routedeventargs)など)。</span><span class="sxs-lookup"><span data-stu-id="967d4-173">The signature for an event handler delegate should consist of two parameters: *sender* (**IInspectable**), and *args* (some event argument type, for example [**RoutedEventArgs**](/uwp/api/windows.ui.xaml.routedeventargs)).</span></span>

<span data-ttu-id="967d4-174">内部の API を設計している場合、これらのガイドラインを適用必ずしもしないことに注意します。</span><span class="sxs-lookup"><span data-stu-id="967d4-174">Note that these guidelines don't necessarily apply if you're designing an internal API.</span></span> <span data-ttu-id="967d4-175">ただし、内部 Api は通常なるパブリック時間の経過と共に。</span><span class="sxs-lookup"><span data-stu-id="967d4-175">Although, internal APIs often become public over time.</span></span>

## <a name="related-topics"></a><span data-ttu-id="967d4-176">関連トピック</span><span class="sxs-lookup"><span data-stu-id="967d4-176">Related topics</span></span>
* [<span data-ttu-id="967d4-177">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="967d4-177">Author APIs with C++/WinRT</span></span>](author-apis.md)
* [<span data-ttu-id="967d4-178">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="967d4-178">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="967d4-179">C++/WinRT でデリゲートを使用してイベントを処理する</span><span class="sxs-lookup"><span data-stu-id="967d4-179">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
