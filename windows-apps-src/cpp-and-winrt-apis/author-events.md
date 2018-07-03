---
author: stevewhims
description: このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。
title: C++/WinRT でのイベントの作成
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 作成者, イベント
ms.localizationpriority: medium
ms.openlocfilehash: 192000f937989d7218931ce1465bd96d5d9b71c6
ms.sourcegitcommit: 834992ec14a8a34320c96e2e9b887a2be5477a53
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/14/2018
ms.locfileid: "1880883"
---
# <a name="author-events-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="f0837-105">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="f0837-105">Author events in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="f0837-106">このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f0837-106">This topic demonstrates how to author a Windows Runtime Component containing a runtime class representing a bank account, which raises an event when its balance goes into debit.</span></span> <span data-ttu-id="f0837-107">銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。</span><span class="sxs-lookup"><span data-stu-id="f0837-107">It also demonstrates a Core App that consumes the bank account runtime class, calls a function to adjust the balance, and handles any events that result.</span></span>

> [!NOTE]
> <span data-ttu-id="f0837-108">C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f0837-108">For info about installing and using the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f0837-109">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f0837-109">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="windowsfoundationeventhandlerlttgt-and-typedeventhandlerlttgt"></a><span data-ttu-id="f0837-110">Windows::Foundation::EventHandler&lt;T&gt; と TypedEventHandler&lt;T&gt;</span><span class="sxs-lookup"><span data-stu-id="f0837-110">Windows::Foundation::EventHandler&lt;T&gt; and TypedEventHandler&lt;T&gt;</span></span>
<span data-ttu-id="f0837-111">Windows ランタイム コンポーネントに実装されているランタイム クラスからイベントを発生する場合は、イベントのデリゲート型に [**Windows::Foundation::EventHandler**](/uwp/api/windows.foundation.eventhandler) または [**TypedEventHandler**](/uwp/api/windows.foundation.eventhandler) を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0837-111">If you want to raise an event from a runtime class implemented in a Windows Runtime Component, then you should use [**Windows::Foundation::EventHandler**](/uwp/api/windows.foundation.eventhandler) or [**TypedEventHandler**](/uwp/api/windows.foundation.eventhandler) for your event's delegate type.</span></span> <span data-ttu-id="f0837-112">型のパラメーターは、Windows ランタイム型でなければならないため、サード パーティ製のランタイム クラスとプリミティブ型が許可されています。</span><span class="sxs-lookup"><span data-stu-id="f0837-112">The type parameters must be Windows Runtime types, so primitive types are allowed as well as third-party runtime classes.</span></span>

<span data-ttu-id="f0837-113">コンパイラは、この制約を忘れた場合に "*WinRT 型である必要があります*" エラーを使用してサポートします。</span><span class="sxs-lookup"><span data-stu-id="f0837-113">The compiler will help you with a "*must be WinRT type*" error if you forget this constraint.</span></span>

## <a name="winrtdelegatelt-tgt"></a><span data-ttu-id="f0837-114">winrt::delegate&lt;...T&gt;</span><span class="sxs-lookup"><span data-stu-id="f0837-114">winrt::delegate&lt;... T&gt;</span></span>
<span data-ttu-id="f0837-115">(同じプロジェクト内で作成および使用される) C++ 型からイベントを発生する場合、イベントのデリゲート型に C++/WinRT の [**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f0837-115">If you want to raise an event from a C++ type (authored and consumed within the same project), then you can use C++/WinRT's [**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) for your event's delegate type.</span></span> <span data-ttu-id="f0837-116">その場合、デリゲートの型のパラメーターは Windows ランタイム型である必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f0837-116">In that case, the delegate's type parameters needn't be Windows Runtime types.</span></span> <span data-ttu-id="f0837-117">イベントとデリゲートが (バイナリ間ではなく) 内部的に使用される C++/CX コードベースから移植している場合、**winrt::delegate** を使用すると、C++/WinRT でそのパターンをレプリケートできます。</span><span class="sxs-lookup"><span data-stu-id="f0837-117">If you're porting from a C++/CX codebase where events and delegates are used internally (not across binaries), then **winrt::delegate** will help you to replicate that pattern in C++/WinRT.</span></span>

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a><span data-ttu-id="f0837-118">Windows ランタイム コンポーネントの作成 (BankAccountWRC)</span><span class="sxs-lookup"><span data-stu-id="f0837-118">Create a Windows Runtime Component (BankAccountWRC)</span></span>
<span data-ttu-id="f0837-119">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="f0837-119">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="f0837-120">**Visual C++ Windows ランタイム コンポーネント (C++/WinRT)** プロジェクトを作成し、(「銀行口座 Windows ランタイム コンポーネント」用に) *BankAccountWRC* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="f0837-120">Create a **Visual C++ Windows Runtime Component (C++/WinRT)** project, and name it *BankAccountWRC* (for "bank account Windows Runtime Component").</span></span>

<span data-ttu-id="f0837-121">新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f0837-121">The newly-created project contains a file named `Class.idl`.</span></span> <span data-ttu-id="f0837-122">そのファイルの名前を `BankAccountWRC.idl` に変更して、ビルドするときにコンポーネントの Windows ランタイム メタデータ ファイルがコンポーネント自体の名前になるようにします。</span><span class="sxs-lookup"><span data-stu-id="f0837-122">Rename that file `BankAccountWRC.idl` so that, when you build, your component's Windows Runtime metadata file is named for the component itself.</span></span> <span data-ttu-id="f0837-123">`BankAccountWRC.idl` で、以下のリストに示すようにインターフェイスを定義します。</span><span class="sxs-lookup"><span data-stu-id="f0837-123">In `BankAccountWRC.idl`, define your interface as in the listing below.</span></span>

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

<span data-ttu-id="f0837-124">ファイルを保存し、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="f0837-124">Save the file and build the project.</span></span> <span data-ttu-id="f0837-125">ビルドは、まだ成功しません。</span><span class="sxs-lookup"><span data-stu-id="f0837-125">The build won't succeed just yet.</span></span> <span data-ttu-id="f0837-126">ただし、ビルド プロセス中に、`midl.exe` ツールが実行されてコンポーネントの Windows ランタイム メタデータ ファイルが作成されます (これは `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` です)。</span><span class="sxs-lookup"><span data-stu-id="f0837-126">But, during the build process, the `midl.exe` tool is run to create your component's Windows Runtime metadata file (which is `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`).</span></span> <span data-ttu-id="f0837-127">次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="f0837-127">Then, the `cppwinrt.exe` tool is run (with the `-component` option) to generate source code files to support you in authoring your component.</span></span> <span data-ttu-id="f0837-128">これらのファイルには、IDL で宣言した `BankAccount`ランタイム クラスの実装を開始するためのスタブが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f0837-128">These files include stubs to get you started implementing the `BankAccount` runtime class that you declared in your IDL.</span></span> <span data-ttu-id="f0837-129">これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="f0837-129">Those stubs are `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` and `BankAccount.cpp`.</span></span>

<span data-ttu-id="f0837-130">スタブ ファイル `BankAccount.h` と `BankAccount.cpp` を `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` からプロジェクト フォルダー `\BankAccountWRC\BankAccountWRC\` にコピーします。</span><span class="sxs-lookup"><span data-stu-id="f0837-130">Copy the stub files `BankAccount.h` and `BankAccount.cpp` from `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` into the project folder, which is `\BankAccountWRC\BankAccountWRC\`.</span></span> <span data-ttu-id="f0837-131">**ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f0837-131">In **Solution Explorer**, make sure **Show All Files** is toggled on.</span></span> <span data-ttu-id="f0837-132">コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f0837-132">Right-click the stub files that you copied, and click **Include In Project**.</span></span> <span data-ttu-id="f0837-133">また、`Class.h` と `Class.cpp` を右クリックし、**[プロジェクトから除外する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f0837-133">Also, right-click `Class.h` and `Class.cpp`, and click **Exclude From Project**.</span></span>

<span data-ttu-id="f0837-134">ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="f0837-134">Now, let's open `BankAccount.h` and `BankAccount.cpp` and implement our runtime class.</span></span> <span data-ttu-id="f0837-135">`BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="f0837-135">In `BankAccount.h`, add two private members to the implementation (*not* the factory implementation) of BankAccount.</span></span>

```cppwinrt
// BankAccount.h
...
namespace winrt::BankAccountWRC::implementation
{
    struct BankAccount : BankAccountT<BankAccount>
    {
        ...

    private:
        winrt::event<Windows::Foundation::EventHandler<float>> accountIsInDebitEvent;
        float balance{ 0.f };
    };
}
...
```

<span data-ttu-id="f0837-136">`BankAccount.cpp` で、次のコード例に示すように関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="f0837-136">In `BankAccount.cpp`, implement the functions as shown in the code example below.</span></span> <span data-ttu-id="f0837-137">C++/WinRT では、IDL で宣言したイベントは過負荷の状態である関数のセットとして実装されます (プロパティが過負荷の状態の Get および Set 関数のペアとして実装される方法と同様です)。</span><span class="sxs-lookup"><span data-stu-id="f0837-137">In C++/WinRT, an IDL-declared event is implemented as a set of overloaded functions (similar to the way a property is implemented as a pair of overloaded get and set functions).</span></span> <span data-ttu-id="f0837-138">1 つのオーバーロードが登録するデリゲートを受け取り、トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="f0837-138">One overload takes a delegate to be registered, and returns a token.</span></span> <span data-ttu-id="f0837-139">別のオーバーロードはトークンを受け取り、関連付けられているデリゲートの登録を取り消します。</span><span class="sxs-lookup"><span data-stu-id="f0837-139">The other takes a token, and revokes the registration of the associated delegate.</span></span>

```cppwinrt
// BankAccount.cpp
...
namespace winrt::BankAccountWRC::implementation
{
    event_token BankAccount::AccountIsInDebit(Windows::Foundation::EventHandler<float> const& handler)
    {
        return accountIsInDebitEvent.add(handler);
    }

    void BankAccount::AccountIsInDebit(event_token const& token)
    {
        accountIsInDebitEvent.remove(token);
    }

    void BankAccount::AdjustBalance(float value)
    {
        balance += value;
        if (balance < 0.f) accountIsInDebitEvent(*this, balance);
    }
}
```

<span data-ttu-id="f0837-140">イベント リボーカーのオーバーロードを実装する必要はありません (詳細については、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください)。これは C++/WinRT プロジェクションで自動的に行われます。</span><span class="sxs-lookup"><span data-stu-id="f0837-140">You don't need to implement the overload for the event revoker (for details, see [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate))&mdash;that's taken care of for you by the C++/WinRT projection.</span></span> <span data-ttu-id="f0837-141">別のオーバーロードは、開発者がシナリオに最適な方法で柔軟に実装できるようにするため、プロジェクションに書き込まれません。</span><span class="sxs-lookup"><span data-stu-id="f0837-141">The other overloads are not baked into the projection, in order to give you the flexibility to implement them optimally for your scenario.</span></span> <span data-ttu-id="f0837-142">このような [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) および [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) の呼び出しは、効率的で同時実行の安全性を確保できるスレッド セーフな既定値です。</span><span class="sxs-lookup"><span data-stu-id="f0837-142">Calling [**event::add**](/uwp/cpp-ref-for-winrt/event#eventadd-function) and [**event::remove**](/uwp/cpp-ref-for-winrt/event#eventremove-function) like this is an efficient and concurrency/thread-safe default.</span></span> <span data-ttu-id="f0837-143">ただし、大量のイベントがある場合は、各イベントのイベント フィールドが必要ないことがあり、代わりに、ある種のスパース実装を選択します。</span><span class="sxs-lookup"><span data-stu-id="f0837-143">But if you have a very large number of events, then you may not want an event field for each, but rather opt for some kind of sparse implementation instead.</span></span>

<span data-ttu-id="f0837-144">また、**AdjustBalance** 関数の実装によって、残高が負の値になった場合でも **AccountIsInDebit** イベントが発生することを上で確認できます。</span><span class="sxs-lookup"><span data-stu-id="f0837-144">You can also see above that the implementation of the **AdjustBalance** function raises the **AccountIsInDebit** event if the balance goes negative.</span></span>

<span data-ttu-id="f0837-145">任意の警告がビルドを妨げる場合は、プロジェクトのプロパティ **C/C++** > **General** > **Treat Warnings As Errors** を **No (/WX-)** に設定して、もう一度プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="f0837-145">If any warnings prevent you from building, then set the project property **C/C++** > **General** > **Treat Warnings As Errors** to **No (/WX-)**, and build the project again.</span></span>

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a><span data-ttu-id="f0837-146">コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。</span><span class="sxs-lookup"><span data-stu-id="f0837-146">Create a Core App (BankAccountCoreApp) to test the Windows Runtime Component</span></span>
<span data-ttu-id="f0837-147">ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="f0837-147">Now create a new project (either in your `BankAccountWRC` solution, or in a new one).</span></span> <span data-ttu-id="f0837-148">**Visual C++ コア アプリ (C++/WinRT)** プロジェクトを作成し、*BankAccountCoreApp* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="f0837-148">Create a **Visual C++ Core App (C++/WinRT)** project, and name it *BankAccountCoreApp*.</span></span>

<span data-ttu-id="f0837-149">参照を追加し、`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` へブラウズします (または 2 つのプロジェクトが同じソリューションに属している場合は、プロジェクト参照を追加します)。</span><span class="sxs-lookup"><span data-stu-id="f0837-149">Add a reference, and browse to `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` (or add a project reference, if the two projects are in the same solution).</span></span> <span data-ttu-id="f0837-150">**[追加]** をクリックして **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f0837-150">Click **Add**, and then **OK**.</span></span> <span data-ttu-id="f0837-151">ここで BankAccountCoreApp をビルドします。</span><span class="sxs-lookup"><span data-stu-id="f0837-151">Now build BankAccountCoreApp.</span></span> <span data-ttu-id="f0837-152">ペイロード ファイル `readme.txt` が存在しないというエラーが表示される場合、Windows ランタイム コンポーネント プロジェクトからそのファイルを除外し、これを再ビルドしてから、BankAccountCoreApp を再ビルドします。</span><span class="sxs-lookup"><span data-stu-id="f0837-152">If you see an error that the payload file `readme.txt` doesn't exist, then exclude that file from the Windows Runtime Component project, rebuild it, then rebuild BankAccountCoreApp.</span></span>

<span data-ttu-id="f0837-153">ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。</span><span class="sxs-lookup"><span data-stu-id="f0837-153">During the build process, the `cppwinrt.exe` tool is run to process the referenced `.winmd` file into source code files containing projected types to support you in consuming your component.</span></span> <span data-ttu-id="f0837-154">コンポーネントのランタイム クラス (`BankAccountWRC.h`という名前) の投影型のヘッダーは、フォルダー `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\` 内に生成されます。</span><span class="sxs-lookup"><span data-stu-id="f0837-154">The header for the projected types for your component's runtime classes&mdash;named `BankAccountWRC.h`&mdash;is generated into the folder `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\`.</span></span>

<span data-ttu-id="f0837-155">そのヘッダーを `App.cpp` に含めます。</span><span class="sxs-lookup"><span data-stu-id="f0837-155">Include that header in `App.cpp`.</span></span>

```cppwinrt
#include <winrt/BankAccountWRC.h>
```

<span data-ttu-id="f0837-156">`App.cpp` でも、(投影型の既定のコンストラクターを使用して) BankAccount のインスタンスを作成するために次のコードを追加し、イベント ハンドラーを登録して、口座が借方に入るようにします。</span><span class="sxs-lookup"><span data-stu-id="f0837-156">Also in `App.cpp`, add the following code to instantiate a BankAccount (using the projected type's default constructor), register an event handler, and then cause the account to go into debit.</span></span>

```cppwinrt
struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    BankAccountWRC::BankAccount bankAccount;
    event_token eventToken;
    ...
    
    void Initialize(CoreApplicationView const &)
    {
        eventToken = bankAccount.AccountIsInDebit([](const auto &, float balance)
        {
            assert(balance < 0.f);
        });
    }
    ...

    void Uninitialize()
    {
        bankAccount.AccountIsInDebit(eventToken);
    }
    ...

    void OnPointerPressed(IInspectable const &, PointerEventArgs const & args)
    {
        bankAccount.AdjustBalance(-1.f);
        ...
    }
    ...
};
```

<span data-ttu-id="f0837-157">ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。</span><span class="sxs-lookup"><span data-stu-id="f0837-157">Each time you click the window, you subtract 1 from the bank account's balance.</span></span> <span data-ttu-id="f0837-158">期待どおりにイベントが発生することを実証するには、ラムダ式内にブレークポイントを置き、アプリを実行して、ウィンドウ内をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f0837-158">To demonstrate that the event is being raised as expected, put a breakpoint inside the lambda expression, run the app, and click inside the window.</span></span>

## <a name="related-topics"></a><span data-ttu-id="f0837-159">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f0837-159">Related topics</span></span>
* [<span data-ttu-id="f0837-160">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="f0837-160">Author APIs with C++/WinRT</span></span>](author-apis.md)
* [<span data-ttu-id="f0837-161">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="f0837-161">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="f0837-162">C++/WinRT でデリゲートを使用してイベントを処理する</span><span class="sxs-lookup"><span data-stu-id="f0837-162">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
