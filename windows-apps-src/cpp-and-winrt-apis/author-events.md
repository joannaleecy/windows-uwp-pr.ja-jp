---
author: stevewhims
description: このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。
title: C++/WinRT でのイベントの作成
ms.author: stwhi
ms.date: 04/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、作成者、イベント
ms.localizationpriority: medium
ms.openlocfilehash: b7574f1a3406dae665ced80294f7bc1cf91aeb8c
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832026"
---
# <a name="author-events-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="b0ee8-105">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="b0ee8-105">Author events in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
> [!NOTE]
> **<span data-ttu-id="b0ee8-106">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-106">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="b0ee8-107">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-107">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="b0ee8-108">このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-108">This topic demonstrates how to author a Windows Runtime Component containing a runtime class representing a bank account, which raises an event when its balance goes into debit.</span></span> <span data-ttu-id="b0ee8-109">銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-109">It also demonstrates a Core App that consumes the bank account runtime class, calls a function to adjust the balance, and handles any events that result.</span></span>

> [!NOTE]
> <span data-ttu-id="b0ee8-110">現在利用可能な C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) の詳細については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-110">For info about the current availability of the C++/WinRT Visual Studio Extension (VSIX) (which provides project template support, as well as C++/WinRT MSBuild properties and targets) see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b0ee8-111">C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-111">For essential concepts and terms that support your understanding of how to consume and author runtime classes with C++/WinRT, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

## <a name="windowsfoundationeventhandlerlttgt-and-typedeventhandlerlttgt"></a><span data-ttu-id="b0ee8-112">Windows::Foundation::EventHandler&lt;T&gt; と TypedEventHandler&lt;T&gt;</span><span class="sxs-lookup"><span data-stu-id="b0ee8-112">Windows::Foundation::EventHandler&lt;T&gt; and TypedEventHandler&lt;T&gt;</span></span>
<span data-ttu-id="b0ee8-113">Windows ランタイム コンポーネントに実装されているランタイム クラスからイベントを発生する場合は、イベントのデリゲート型に [**Windows::Foundation::EventHandler**](/uwp/api/windows.foundation.eventhandler) または [**TypedEventHandler**](/uwp/api/windows.foundation.eventhandler) を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-113">If you want to raise an event from a runtime class implemented in a Windows Runtime Component, then you should use [**Windows::Foundation::EventHandler**](/uwp/api/windows.foundation.eventhandler) or [**TypedEventHandler**](/uwp/api/windows.foundation.eventhandler) for your event's delegate type.</span></span> <span data-ttu-id="b0ee8-114">型のパラメーターは、Windows ランタイム型でなければならないため、サード パーティ製のランタイム クラスとプリミティブ型が許可されています。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-114">The type parameters must be Windows Runtime types, so primitive types are allowed as well as third-party runtime classes.</span></span>

<span data-ttu-id="b0ee8-115">コンパイラは、この制約を忘れた場合に "*WinRT 型である必要があります*" エラーを使用してサポートします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-115">The compiler will help you with a "*must be WinRT type*" error if you forget this constraint.</span></span>

## <a name="winrtdelegatelttgt"></a><span data-ttu-id="b0ee8-116">winrt::delegate&lt;...T&gt;</span><span class="sxs-lookup"><span data-stu-id="b0ee8-116">winrt::delegate&lt;...T&gt;</span></span>
<span data-ttu-id="b0ee8-117">(同じプロジェクト内で作成および使用される) C++ 型からイベントを発生する場合、イベントのデリゲート型に C++/WinRT の **winrt::delegate&lt;...T&gt;** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-117">If you want to raise an event from a C++ type (authored and consumed within the same project), then you can use C++/WinRT's **winrt::delegate&lt;...T&gt;** for your event's delegate type.</span></span> <span data-ttu-id="b0ee8-118">その場合、型のパラメーターは Windows ランタイム型である必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-118">In that case, the type parameter needn't be a Windows Runtime type.</span></span>

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a><span data-ttu-id="b0ee8-119">Windows ランタイム コンポーネントの作成 (BankAccountWRC)</span><span class="sxs-lookup"><span data-stu-id="b0ee8-119">Create a Windows Runtime Component (BankAccountWRC)</span></span>
<span data-ttu-id="b0ee8-120">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-120">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="b0ee8-121">**Visual C++ Windows ランタイム コンポーネント (C++/WinRT)** プロジェクトを作成し、(「銀行口座 Windows ランタイム コンポーネント」用に) *BankAccountWRC* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-121">Create a **Visual C++ Windows Runtime Component (C++/WinRT)** project, and name it *BankAccountWRC* (for "bank account Windows Runtime Component").</span></span>

<span data-ttu-id="b0ee8-122">新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-122">The newly-created project contains a file named `Class.idl`.</span></span> <span data-ttu-id="b0ee8-123">そのファイルの名前を `BankAccountWRC.idl` に変更して、ビルドするときにコンポーネントの Windows ランタイム メタデータ ファイルがコンポーネント自体の名前になるようにします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-123">Rename that file `BankAccountWRC.idl` so that, when you build, your component's Windows Runtime metadata file is named for the component itself.</span></span> <span data-ttu-id="b0ee8-124">`BankAccountWRC.idl` で、以下のリストに示すようにインターフェイスを定義します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-124">In `BankAccountWRC.idl`, define your interface as in the listing below.</span></span>

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

<span data-ttu-id="b0ee8-125">ファイルを保存し、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-125">Save the file and build the project.</span></span> <span data-ttu-id="b0ee8-126">ビルドは、まだ成功しません。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-126">The build won't succeed just yet.</span></span> <span data-ttu-id="b0ee8-127">ただし、ビルド プロセス中に、`midl.exe` ツールが実行されてコンポーネントの Windows ランタイム メタデータ ファイルが作成されます (これは `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` です)。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-127">But, during the build process, the `midl.exe` tool is run to create your component's Windows Runtime metadata file (which is `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`).</span></span> <span data-ttu-id="b0ee8-128">次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-128">Then, the `cppwinrt.exe` tool is run (with the `-component` option) to generate source code files to support you in authoring your component.</span></span> <span data-ttu-id="b0ee8-129">これらのファイルには、IDL で宣言した `BankAccount`ランタイム クラスの実装を開始するためのスタブが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-129">These files include stubs to get you started implementing the `BankAccount` runtime class that you declared in your IDL.</span></span> <span data-ttu-id="b0ee8-130">これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-130">Those stubs are `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` and `BankAccount.cpp`.</span></span>

<span data-ttu-id="b0ee8-131">スタブ ファイル `BankAccount.h` と `BankAccount.cpp` を `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` からプロジェクト フォルダー `\BankAccountWRC\BankAccountWRC\` にコピーします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-131">Copy the stub files `BankAccount.h` and `BankAccount.cpp` from `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` into the project folder, which is `\BankAccountWRC\BankAccountWRC\`.</span></span> <span data-ttu-id="b0ee8-132">**ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-132">In **Solution Explorer**, make sure **Show All Files** is toggled on.</span></span> <span data-ttu-id="b0ee8-133">コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-133">Right-click the stub files that you copied, and click **Include In Project**.</span></span> <span data-ttu-id="b0ee8-134">また、`Class.h` と `Class.cpp` を右クリックし、**[プロジェクトから除外する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-134">Also, right-click `Class.h` and `Class.cpp`, and click **Exclude From Project**.</span></span>

<span data-ttu-id="b0ee8-135">ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-135">Now, let's open `BankAccount.h` and `BankAccount.cpp` and implement our runtime class.</span></span> <span data-ttu-id="b0ee8-136">`BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-136">In `BankAccount.h`, add two private members to the implementation (*not* the factory implementation) of BankAccount.</span></span>

```cppwinrt
// BankAccount.h
...
namespace winrt::BankAccountWRC::implementation
{
    struct BankAccount : BankAccountT<BankAccount>
    {
        ...

    private:
        event<Windows::Foundation::EventHandler<float>> accountIsInDebitEvent;
        float balance{ 0.f };
    };
}
...
```

<span data-ttu-id="b0ee8-137">`BankAccount.cpp` では、次のように関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-137">In `BankAccount.cpp`, implement the functions like this.</span></span>

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

<span data-ttu-id="b0ee8-138">**AdjustBalance** 関数の実装によって、残高が負の値になった場合に **AccountIsInDebit** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-138">The implementation of the **AdjustBalance** function raises the **AccountIsInDebit** event if the balance goes negative.</span></span>

<span data-ttu-id="b0ee8-139">任意の警告がビルドを妨げる場合は、プロジェクトのプロパティ **C/C++** > **General** > **Treat Warnings As Errors** を **No (/WX-)** に設定して、もう一度プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-139">If any warnings prevent you from building, then set the project property **C/C++** > **General** > **Treat Warnings As Errors** to **No (/WX-)**, and build the project again.</span></span>

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a><span data-ttu-id="b0ee8-140">コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-140">Create a Core App (BankAccountCoreApp) to test the Windows Runtime Component</span></span>
<span data-ttu-id="b0ee8-141">ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-141">Now create a new project (either in your `BankAccountWRC` solution, or in a new one).</span></span> <span data-ttu-id="b0ee8-142">**Visual C++ コア アプリ (C++/WinRT)** プロジェクトを作成し、*BankAccountCoreApp* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-142">Create a **Visual C++ Core App (C++/WinRT)** project, and name it *BankAccountCoreApp*.</span></span>

<span data-ttu-id="b0ee8-143">参照を追加し、`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` へブラウズします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-143">Add a reference, and browse to `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd`.</span></span> <span data-ttu-id="b0ee8-144">**[追加]** をクリックして **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-144">Click **Add**, and then **OK**.</span></span> <span data-ttu-id="b0ee8-145">ここで BankAccountCoreApp をビルドします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-145">Now build BankAccountCoreApp.</span></span> <span data-ttu-id="b0ee8-146">ペイロード ファイル `readme.txt` が存在しないというエラーが表示される場合、Windows ランタイム コンポーネント プロジェクトからそのファイルを除外し、これを再ビルドしてから、BankAccountCoreApp を再ビルドします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-146">If you see an error that the payload file `readme.txt` doesn't exist, then exclude that file from the Windows Runtime Component project, rebuild it, then rebuild BankAccountCoreApp.</span></span>

<span data-ttu-id="b0ee8-147">ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-147">During the build process, the `cppwinrt.exe` tool is run to process the referenced `.winmd` file into source code files containing projected types to support you in consuming your component.</span></span> <span data-ttu-id="b0ee8-148">コンポーネントのランタイム クラス (`BankAccountWRC.h`という名前) の投影型のヘッダーは、フォルダー `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\` 内に生成されます。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-148">The header for the projected types for your component's runtime classes&mdash;named `BankAccountWRC.h`&mdash;is generated into the folder `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\`.</span></span>

<span data-ttu-id="b0ee8-149">そのヘッダーを `App.cpp` に含めます。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-149">Include that header in `App.cpp`.</span></span>

```cppwinrt
#include <winrt/BankAccountWRC.h>
```

<span data-ttu-id="b0ee8-150">`App.cpp` でも、(投影型の既定のコンストラクターを使用して) BankAccount のインスタンスを作成するために次のコードを追加し、イベント ハンドラーを登録して、口座が借方に入るようにします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-150">Also in `App.cpp`, add the following code to instantiate a BankAccount (using the projected type's default constructor), register an event handler, and then cause the account to go into debit.</span></span>

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

<span data-ttu-id="b0ee8-151">ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-151">Each time you click the window, you subtract 1 from the bank account's balance.</span></span> <span data-ttu-id="b0ee8-152">期待どおりにイベントが発生することを実証するには、ラムダ式内にブレークポイントを置き、アプリを実行して、ウィンドウ内をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b0ee8-152">To demonstrate that the event is being raised as expected, put a breakpoint inside the lambda expression, run the app, and click inside the window.</span></span>

## <a name="related-topics"></a><span data-ttu-id="b0ee8-153">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b0ee8-153">Related topics</span></span>
* [<span data-ttu-id="b0ee8-154">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="b0ee8-154">Author APIs with C++/WinRT</span></span>](author-apis.md)
* [<span data-ttu-id="b0ee8-155">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="b0ee8-155">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="b0ee8-156">C++/WinRT でデリゲートを使用してイベントを処理する</span><span class="sxs-lookup"><span data-stu-id="b0ee8-156">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
