---
description: このトピックでは、C++/CX コードを C++/WinRT の同等のコードに移植する方法について説明します。
title: C++/CX から C++/WinRT への移行
ms.date: 01/17/2019
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, C++/CX
ms.localizationpriority: medium
ms.openlocfilehash: fe988bffbf024308fb5d43da7ed538e5330b58de
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635077"
---
# <a name="move-to-cwinrt-from-ccx"></a><span data-ttu-id="edd2a-104">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="edd2a-104">Move to C++/WinRT from C++/CX</span></span>

<span data-ttu-id="edd2a-105">このトピックでは、コードを移植する方法、 [C +/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx) 、それに対応するプロジェクト[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-105">This topic shows how to port the code in a [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) project to its equivalent in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span>

## <a name="porting-strategies"></a><span data-ttu-id="edd2a-106">移植の戦略</span><span class="sxs-lookup"><span data-stu-id="edd2a-106">Porting strategies</span></span>

<span data-ttu-id="edd2a-107">場合は、徐々 に移植すると、C +/cli c++/CX コード/cli WinRT、しすることができます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-107">If you want to gradually port your C++/CX code to C++/WinRT, then you can.</span></span> <span data-ttu-id="edd2a-108">C + +/CX および C++/cli WinRT コードは、XAML コンパイラ サポートと Windows ランタイム コンポーネントの例外を使用して、同じプロジェクトで共存できます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-108">C++/CX and C++/WinRT code can coexist in the same project, with the exceptions of XAML compiler support and Windows Runtime Components.</span></span> <span data-ttu-id="edd2a-109">これら 2 つの例外は、C + いずれかをターゲットする必要があります/cli/CX または C++/cli、同じプロジェクト内の WinRT します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-109">For those two exceptions, you'll need to target either C++/CX or C++/WinRT within the same project.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="edd2a-110">XAML アプリケーションをビルドするプロジェクトの場合、に、まず c++ のいずれかを使用して Visual Studio で新しいプロジェクトを作成する、推奨される 1 つのワークフローは/cli WinRT プロジェクト テンプレート (を参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package))。</span><span class="sxs-lookup"><span data-stu-id="edd2a-110">If your project builds a XAML application, then one workflow that we recommend is to first create a new project in Visual Studio using one of the C++/WinRT project templates (see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)).</span></span> <span data-ttu-id="edd2a-111">C++ からソース コードとマークアップをコピーし、開始/cli CX プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="edd2a-111">Then, start copying source code and markup over from the C++/CX project.</span></span> <span data-ttu-id="edd2a-112">新しい XAML ページを追加する**プロジェクト** \> **新しい項目の追加.**\> **Visual C** > **空白のページ (C +/cli WinRT)** します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-112">You can add new XAML pages with **Project** \> **Add New Item...** \> **Visual C++** > **Blank Page (C++/WinRT)**.</span></span>
>
> <span data-ttu-id="edd2a-113">要素のコードから、XAML C + への Windows ランタイム コンポーネントを使用する代わりに、/cli CX プロジェクトのように移植します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-113">Alternatively, you can use a Windows Runtime Component to factor code out of the XAML C++/CX project as you port it.</span></span> <span data-ttu-id="edd2a-114">移動するか、ほど C +/cli CX コード、コンポーネントには c++ XAML プロジェクトを変更すると/cli WinRT します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-114">Either move as much C++/CX code as you can into a component, and then change the XAML project to C++/WinRT.</span></span> <span data-ttu-id="edd2a-115">C + と XAML プロジェクトのままにそれ以外の場合、または/cli CX、作成するには新しい C +/cli WinRT コンポーネント、C + の移植を開始および/cli/CX コードを XAML プロジェクトとコンポーネントにします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-115">Or else leave the XAML project as C++/CX, create a new C++/WinRT component, and begin porting C++/CX code out of the XAML project and into the component.</span></span> <span data-ttu-id="edd2a-116">できます c++/cli CX コンポーネントのプロジェクトと共に C +/cli、同じソリューション内の WinRT コンポーネント プロジェクトがそれらの両方をアプリケーション プロジェクトから参照し、段階的に、他のいずれかからポートします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-116">You could also have a C++/CX component project alongside a C++/WinRT component project within the same solution, reference both of them from your application project, and gradually port from one to the other.</span></span> <span data-ttu-id="edd2a-117">参照してください[C + 間の相互運用/cli WinRT および C++/cli CX](interop-winrt-cx.md) 2 つの言語プロジェクションを使用して、同じプロジェクト内の詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-117">See [Interop between C++/WinRT and C++/CX](interop-winrt-cx.md) for more details on using the two language projections in the same project.</span></span>

> [!NOTE]
> <span data-ttu-id="edd2a-118">[C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) と Windows SDK の両方で、ルート名前空間 **Windows** で型を宣言します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-118">Both [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) and the Windows SDK declare types in the root namespace **Windows**.</span></span> <span data-ttu-id="edd2a-119">C++/WinRT に投影された Windows 型は Windows 型と同じ完全修飾名を持ちますが、 C++ **winrt** 名前空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-119">A Windows type projected into C++/WinRT has the same fully-qualified name as the Windows type, but it's placed in the C++ **winrt** namespace.</span></span> <span data-ttu-id="edd2a-120">これらの異なる名前空間では、独自のペースで C++/CX から C++/WinRT へ移植できます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-120">These distinct namespaces let you port from C++/CX to C++/WinRT at your own pace.</span></span>

<span data-ttu-id="edd2a-121">C++ の移植で最初の手順に注意してください、上記で説明した例外を方位、/cli C + CX プロジェクト/cli WinRT は、C + を手動で追加する/cli WinRT サポート (を参照してください[Visual Studio のサポートの C +/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package))。</span><span class="sxs-lookup"><span data-stu-id="edd2a-121">Bearing in mind the exceptions mentioned above, the first step in porting a C++/CX project to C++/WinRT is to manually add C++/WinRT support to it (see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)).</span></span> <span data-ttu-id="edd2a-122">インストール、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をプロジェクトにします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-122">To do that, install the [Microsoft.Windows.CppWinRT NuGet package](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/) into your project.</span></span> <span data-ttu-id="edd2a-123">開いている Visual Studio でプロジェクトをクリックして**プロジェクト** \> **NuGet パッケージの管理.**\> **[参照]** 入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**そのプロジェクトのパッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-123">Open the project in Visual Studio, click **Project** \> **Manage NuGet Packages...** \> **Browse**, type or paste **Microsoft.Windows.CppWinRT** in the search box, select the item in search results, and then click **Install** to install the package for that project.</span></span> <span data-ttu-id="edd2a-124">その変更による 1 つの効果は、C++/CX のサポートがプロジェクトで無効になることです。</span><span class="sxs-lookup"><span data-stu-id="edd2a-124">One effect of that change is that support for C++/CX is turned off in the project.</span></span> <span data-ttu-id="edd2a-125">C + のすべての依存関係のサポートを発見 (してポート) メッセージをビルドできるように、無効のままにことをお勧め/cli CX、または再度有効にできますサポート (プロジェクトのプロパティで**C/C++** \> **[全般]**\> **Windows ランタイム拡張機能の使用** \> **はい (/ZW)**)、およびポートを徐々 にします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-125">It's a good idea to leave support turned off so that build messages help you find (and port) all of your dependencies on C++/CX, or you can turn support back on (in project properties, **C/C++** \> **General** \> **Consume Windows Runtime Extension** \> **Yes (/ZW)**), and port gradually.</span></span>

<span data-ttu-id="edd2a-126">そのプロジェクトのプロパティを確認します。**全般** \> **ターゲット プラットフォーム バージョン**10.0.17134.0 (Windows 10、バージョン 1803) に設定されている以上。</span><span class="sxs-lookup"><span data-stu-id="edd2a-126">Ensure that project property **General** \> **Target Platform Version** is set to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="edd2a-127">プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-127">In your precompiled header file (usually `pch.h`), include `winrt/base.h`.</span></span>

```cppwinrt
#include <winrt/base.h>
```

<span data-ttu-id="edd2a-128">C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。</span><span class="sxs-lookup"><span data-stu-id="edd2a-128">If you include any C++/WinRT projected Windows API headers (for example, `winrt/Windows.Foundation.h`), then you don't need to explicitly include `winrt/base.h` like this because it will be included automatically for you.</span></span>

<span data-ttu-id="edd2a-129">プロジェクトで [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) 型も使用している場合は、「[WRL から C++/WinRT への移行](move-to-winrt-from-wrl.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="edd2a-129">If your project is also using [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) types, then see [Move to C++/WinRT from WRL](move-to-winrt-from-wrl.md).</span></span>

## <a name="parameter-passing"></a><span data-ttu-id="edd2a-130">パラメーターの引き渡し</span><span class="sxs-lookup"><span data-stu-id="edd2a-130">Parameter-passing</span></span>
<span data-ttu-id="edd2a-131">書き込み中に C +/cli 渡す CX ソース コードでは、C +/cli hat として関数のパラメーターとして/CX 型 (\^) 参照。</span><span class="sxs-lookup"><span data-stu-id="edd2a-131">When writing C++/CX source code, you pass C++/CX types as function parameters as hat (\^) references.</span></span>

```cppcx
void LogPresenceRecord(PresenceRecord^ record);
```

<span data-ttu-id="edd2a-132">C++/WinRT では、同期関数に既定で `const&` パラメーターを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="edd2a-132">In C++/WinRT, for synchronous functions, you should use `const&` parameters by default.</span></span> <span data-ttu-id="edd2a-133">これにより、コピーとインター ロック オーバーヘッドが回避されます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-133">That will avoid copies and interlocked overhead.</span></span> <span data-ttu-id="edd2a-134">ただし、コルーチンが値による呼び出しをして有効期間の問題を回避するように、値渡しを使用する必要があります (詳細については、「[C++/WinRT を使用した同時実行と非同期操作](concurrency.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="edd2a-134">But your coroutines should use pass-by-value to ensure that they capture by value and avoid lifetime issues (for more details, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md)).</span></span>

```cppwinrt
void LogPresenceRecord(PresenceRecord const& record);
IASyncAction LogPresenceRecordAsync(PresenceRecord const record);
```

<span data-ttu-id="edd2a-135">C++/WinRT オブジェクトは、基本的に Windows ランタイムのバッキング オブジェクトへのインターフェイス ポインターを保持する値です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-135">A C++/WinRT object is fundamentally a value that holds an interface pointer to the backing Windows Runtime object.</span></span> <span data-ttu-id="edd2a-136">C++/WinRT オブジェクトをコピーすると、コンパイラはカプセル化されたインターフェイス ポインターをコピーし、その参照カウントをインクリメントします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-136">When you copy a C++/WinRT object, the compiler copies the encapsulated interface pointer, incrementing its reference count.</span></span> <span data-ttu-id="edd2a-137">コピーの最終的なデストラクションには、参照カウントのデクリメントも含まれます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-137">Eventual destruction of the copy involves decrementing the reference count.</span></span> <span data-ttu-id="edd2a-138">そのため、必要な場合にのみ、コピーのオーバーヘッドが発生します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-138">So, only incur the overhead of a copy when necessary.</span></span>

## <a name="variable-and-field-references"></a><span data-ttu-id="edd2a-139">変数とフィールドの参照</span><span class="sxs-lookup"><span data-stu-id="edd2a-139">Variable and field references</span></span>
<span data-ttu-id="edd2a-140">書き込み中に C +/cli CX ソース コードでは、hat を使用する (\^) で Windows ランタイム オブジェクトと、矢印を参照する変数 (-&gt;) hat 変数を逆参照演算子。</span><span class="sxs-lookup"><span data-stu-id="edd2a-140">When writing C++/CX source code, you use hat (\^) variables to reference Windows Runtime objects, and the arrow (-&gt;) operator to dereference a hat variable.</span></span>

```cppcx
IVectorView<User^>^ userList = User::Users;

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList->Size; ++iUser)
    ...
```

<span data-ttu-id="edd2a-141">同等の C + に移植するときに/cli、WinRT コード、帽子を削除し、矢印の演算子を変更すると、的を取得できます (-&gt;)、ドット演算子 (.) にします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-141">When porting to the equivalent C++/WinRT code, you can get a long way by removing the hats, and changing the arrow operator (-&gt;) to the dot operator (.).</span></span> <span data-ttu-id="edd2a-142">C +/cli 投影 WinRT 型は値、およびポインターではありません。</span><span class="sxs-lookup"><span data-stu-id="edd2a-142">C++/WinRT projected types are values, and not pointers.</span></span>

```cppwinrt
IVectorView<User> userList = User::Users();

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList.Size(); ++iUser)
    ...
```

<span data-ttu-id="edd2a-143">既定のコンス トラクターの c++/cli CX hat ポインターを null に初期化します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-143">The default constructor for a C++/CX hat pointer initializes it to null.</span></span> <span data-ttu-id="edd2a-144">ここでは、c++/cli CX のコード例が初期化されていないか、適切な型の変数/フィールドを作成します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-144">Here's a C++/CX code example in which we create a variable/field of the correct type, but one that's uninitialized.</span></span> <span data-ttu-id="edd2a-145">つまり、それを参照しない最初に、 **TextBlock**; 以降の参照を代入する予定です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-145">In other words, it doesn't initially refer to a **TextBlock**; we intend to assign a reference later.</span></span>

```cppcx
TextBlock^ textBlock;

class MyClass
{
    TextBlock^ textBlock;
};
```

<span data-ttu-id="edd2a-146">同等の c++/cli WinRT を参照してください[遅延初期化](consume-apis.md#delayed-initialization)します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-146">For the equivalent in C++/WinRT, see [Delayed initialization](consume-apis.md#delayed-initialization).</span></span>

## <a name="properties"></a><span data-ttu-id="edd2a-147">プロパティ</span><span class="sxs-lookup"><span data-stu-id="edd2a-147">Properties</span></span>
<span data-ttu-id="edd2a-148">C++/CX 言語拡張機能には、プロパティの概念が含まれています。</span><span class="sxs-lookup"><span data-stu-id="edd2a-148">The C++/CX language extensions include the concept of properties.</span></span> <span data-ttu-id="edd2a-149">C++/CX ソース コードを記述するときに、フィールドと同様にプロパティにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-149">When writing C++/CX source code, you can access a property as if it were a field.</span></span> <span data-ttu-id="edd2a-150">標準 C++ にはプロパティの概念がないため、C++/WinRT では、Get 関数と Set 関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-150">Standard C++ does not have the concept of a property so, in C++/WinRT, you call get and set functions.</span></span>

<span data-ttu-id="edd2a-151">次の例では、**XboxUserId**、**UserState**、**PresenceDeviceRecords**、**Size** はすべてプロパティです。</span><span class="sxs-lookup"><span data-stu-id="edd2a-151">In the examples that follow, **XboxUserId**, **UserState**, **PresenceDeviceRecords**, and **Size** are all properties.</span></span>

### <a name="retrieving-a-value-from-a-property"></a><span data-ttu-id="edd2a-152">プロパティからの値の取得</span><span class="sxs-lookup"><span data-stu-id="edd2a-152">Retrieving a value from a property</span></span>
<span data-ttu-id="edd2a-153">C++/CX でプロパティの値を取得する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="edd2a-153">Here's how you get a property value in C++/CX.</span></span>

```cppcx
void Sample::LogPresenceRecord(PresenceRecord^ record)
{
    auto id = record->XboxUserId;
    auto state = record->UserState;
    auto size = record->PresenceDeviceRecords->Size;
}
```

<span data-ttu-id="edd2a-154">同等の C++/WinRT ソース コードは、プロパティと同じ名前を持ち、パラメーターのない関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-154">The equivalent C++/WinRT source code calls a function with the same name as the property, but with no parameters.</span></span>

```cppwinrt
void Sample::LogPresenceRecord(PresenceRecord const& record)
{
    auto id = record.XboxUserId();
    auto state = record.UserState();
    auto size = record.PresenceDeviceRecords().Size();
}
```

<span data-ttu-id="edd2a-155">**PresenceDeviceRecords** 関数は、それ自体が **Size** 関数を持つ Windows ランタイム オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-155">Note that the **PresenceDeviceRecords** function returns a Windows Runtime object that itself has a **Size** function.</span></span> <span data-ttu-id="edd2a-156">返されたオブジェクトは C++/WinRT の投影された型でもあるため、ドット演算子を使用して逆参照し、**Size** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-156">As the returned object is also a C++/WinRT projected type, we dereference using the dot operator to call **Size**.</span></span>

### <a name="setting-a-property-to-a-new-value"></a><span data-ttu-id="edd2a-157">新しい値へのプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="edd2a-157">Setting a property to a new value</span></span>
<span data-ttu-id="edd2a-158">新しい値にプロパティを設定するには、同様のパターンに従います。</span><span class="sxs-lookup"><span data-stu-id="edd2a-158">Setting a property to a new value follows a similar pattern.</span></span> <span data-ttu-id="edd2a-159">まず、C++/CX で次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="edd2a-159">First, in C++/CX.</span></span>

```cppcx
record->UserState = newValue;
```

<span data-ttu-id="edd2a-160">C++/WinRT で対応する操作を行うには、プロパティと同じ名前の関数を呼び出し、引数を渡します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-160">To do the equivalent in C++/WinRT, you call a function with the same name as the property, and pass an argument.</span></span>

```cppwinrt
record.UserState(newValue);
```

## <a name="creating-an-instance-of-a-class"></a><span data-ttu-id="edd2a-161">クラスのインスタンスの作成</span><span class="sxs-lookup"><span data-stu-id="edd2a-161">Creating an instance of a class</span></span>
<span data-ttu-id="edd2a-162">使用する c++/cli CX オブジェクト、hat とよく呼ばれることを識別するハンドルを使用して (\^) 参照。</span><span class="sxs-lookup"><span data-stu-id="edd2a-162">You work with a C++/CX object via a handle to it, commonly known as a hat (\^) reference.</span></span> <span data-ttu-id="edd2a-163">`ref new` キーワードにより新しいオブジェクトを作成します。これにより、[**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) が呼び出され、ランタイム クラスの新しいインスタンスがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-163">You create a new object via the `ref new` keyword, which in turn calls [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) to activate a new instance of the runtime class.</span></span>

```cppcx
using namespace Windows::Storage::Streams;

class Sample
{
private:
    Buffer^ m_gamerPicBuffer = ref new Buffer(MAX_IMAGE_SIZE);
};
```

<span data-ttu-id="edd2a-164">C++/WinRT オブジェクトは値であるため、スタックに割り当てるか、オブジェクトのフィールドとして割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-164">A C++/WinRT object is a value; so you can allocate it on the stack, or as a field of an object.</span></span> <span data-ttu-id="edd2a-165">C++/WinRT オブジェクトを割り当てるために、`ref new` (または `new`) は使用*しません*。</span><span class="sxs-lookup"><span data-stu-id="edd2a-165">You *never* use `ref new` (nor `new`) to allocate a C++/WinRT object.</span></span> <span data-ttu-id="edd2a-166">バックグラウンドで **RoActivateInstance** は引き続き呼び出されています。</span><span class="sxs-lookup"><span data-stu-id="edd2a-166">Behind the scenes, **RoActivateInstance** is still being called.</span></span>

```cppwinrt
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
private:
    Buffer m_gamerPicBuffer{ MAX_IMAGE_SIZE };
};
```

<span data-ttu-id="edd2a-167">リソースを初期化するコストが高い場合は、実際に必要になるまで初期化を遅延するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-167">If a resource is expensive to initialize, then it's common to delay initialization of it until it's actually needed.</span></span>

```cppcx
using namespace Windows::Storage::Streams;

class Sample
{
public:
    void DelayedInit()
    {
        // Allocate the actual buffer.
        m_gamerPicBuffer = ref new Buffer(MAX_IMAGE_SIZE);
    }

private:
    Buffer^ m_gamerPicBuffer;
};
```

<span data-ttu-id="edd2a-168">同じコードが C++/WinRT に移植されました。</span><span class="sxs-lookup"><span data-stu-id="edd2a-168">The same code ported to C++/WinRT.</span></span> <span data-ttu-id="edd2a-169">`nullptr` コンストラクターを使っていることに注目してください。</span><span class="sxs-lookup"><span data-stu-id="edd2a-169">Note the use of the `nullptr` constructor.</span></span> <span data-ttu-id="edd2a-170">コンストラクターの詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="edd2a-170">For more info about that constructor, see [Consume APIs with C++/WinRT](consume-apis.md).</span></span>

```cppwinrt
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
    void DelayedInit()
    {
        // Allocate the actual buffer.
        m_gamerPicBuffer = Buffer(MAX_IMAGE_SIZE);
    }

private:
    Buffer m_gamerPicBuffer{ nullptr };
};
```

## <a name="converting-from-a-base-runtime-class-to-a-derived-one"></a><span data-ttu-id="edd2a-171">ランタイムの基本クラスから派生の 1 つに変換します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-171">Converting from a base runtime class to a derived one</span></span>
<span data-ttu-id="edd2a-172">参照を基本の派生型のオブジェクトを参照することがわかっているが一般的です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-172">It's common to have a reference-to-base that you know refers to an object of a derived type.</span></span> <span data-ttu-id="edd2a-173">C++/cli CX を使用する`dynamic_cast`に*キャスト*に、参照から derived へのベースの参照。</span><span class="sxs-lookup"><span data-stu-id="edd2a-173">In C++/CX, you use `dynamic_cast` to *cast* the reference-to-base into a reference-to-derived.</span></span> <span data-ttu-id="edd2a-174">`dynamic_cast`を非表示の呼び出しにすぎません[ **QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521)します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-174">The `dynamic_cast` is really just a hidden call to [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521).</span></span> <span data-ttu-id="edd2a-175">典型的な例を次に示します&mdash;からキャストして、依存関係プロパティ変更イベントを処理している**DependencyObject**依存関係プロパティを所有する実際の型に戻します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-175">Here's a typical example&mdash;you're handling a dependency property changed event, and you want to cast from **DependencyObject** back to the actual type that owns the dependency property.</span></span>

```cppcx
void BgLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject^ d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs^ e)
{
    BgLabelControl^ theControl{ dynamic_cast<BgLabelControl^>(d) };

    if (theControl != nullptr)
    {
        // succeeded ...
    }
}
```

<span data-ttu-id="edd2a-176">同等の C +/cli WinRT コードで置き換えます、`dynamic_cast`を呼び出して、 [ **IUnknown::try_as** ](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)関数をカプセル化する**QueryInterface**します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-176">The equivalent C++/WinRT code replaces the `dynamic_cast` with a call to the [**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function) function, which encapsulates **QueryInterface**.</span></span> <span data-ttu-id="edd2a-177">また、オプションを呼び出す、ある[ **IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)例外をスローする代わりに、必要なインターフェイス (要求している型の既定のインターフェイス) のクエリが返されない場合。</span><span class="sxs-lookup"><span data-stu-id="edd2a-177">You also have the option to call [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function), instead, which throws an exception if querying for the required interface (the default interface of the type you're requesting) is not returned.</span></span> <span data-ttu-id="edd2a-178">ここでは、c++/cli WinRT のコード例です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-178">Here's a C++/WinRT code example.</span></span>

```cppwinrt
void BgLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e)
{
    if (BgLabelControlApp::BgLabelControl theControl{ d.try_as<BgLabelControlApp::BgLabelControl>() })
    {
        // succeeded ...
    }

    try
    {
        BgLabelControlApp::BgLabelControl theControl{ d.as<BgLabelControlApp::BgLabelControl>() };
        // succeeded ...
    }
    catch (winrt::hresult_no_interface const&)
    {
        // failed ...
    }
}
```

## <a name="event-handling-with-a-delegate"></a><span data-ttu-id="edd2a-179">デリゲートを使用したイベント処理</span><span class="sxs-lookup"><span data-stu-id="edd2a-179">Event-handling with a delegate</span></span>
<span data-ttu-id="edd2a-180">この場合はデリゲートとしてラムダ関数を使用して、C++/CX でイベントを処理する典型的な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-180">Here's a typical example of handling an event in C++/CX, using a lambda function as a delegate in this case.</span></span>

```cppcx
auto token = myButton->Click += ref new RoutedEventHandler([=](Platform::Object^ sender, RoutedEventArgs^ args)
{
    // Handle the event.
    // Note: locals are captured by value, not reference, since this handler is delayed.
});
```

<span data-ttu-id="edd2a-181">C++/WinRT で対応するコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="edd2a-181">This is the equivalent in C++/WinRT.</span></span>

```cppwinrt
auto token = myButton().Click([=](IInspectable const& sender, RoutedEventArgs const& args)
{
    // Handle the event.
    // Note: locals are captured by value, not reference, since this handler is delayed.
});
```

<span data-ttu-id="edd2a-182">ラムダ関数の代わりに、デリゲートを自由関数として実装するか、またはメンバー関数へのポインターとして実装するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-182">Instead of a lambda function, you can choose to implement your delegate as a free function, or as a pointer-to-member-function.</span></span> <span data-ttu-id="edd2a-183">詳細については、「[C++/WinRT でのデリゲートを使用したイベントの処理](handle-events.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="edd2a-183">For more info, see [Handle events by using delegates in C++/WinRT](handle-events.md).</span></span>

<span data-ttu-id="edd2a-184">イベントとデリゲートが内部的に使用される C++/CX コードベース (バイナリではなく) から移植する場合は、[**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) を使用すると、C++/WinRT でそのパターンを複製できます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-184">If you're porting from a C++/CX codebase where events and delegates are used internally (not across binaries), then [**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) will help you to replicate that pattern in C++/WinRT.</span></span> <span data-ttu-id="edd2a-185">参照してください[デリゲート、単純な信号、およびプロジェクト内でのコールバックをパラメーター化された](author-events.md#parameterized-delegates-simple-signals-and-callbacks-within-a-project)します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-185">Also see [Parameterized delegates, simple signals, and callbacks within a project](author-events.md#parameterized-delegates-simple-signals-and-callbacks-within-a-project).</span></span>

## <a name="revoking-a-delegate"></a><span data-ttu-id="edd2a-186">デリゲートの取り消し</span><span class="sxs-lookup"><span data-stu-id="edd2a-186">Revoking a delegate</span></span>
<span data-ttu-id="edd2a-187">C++/CX では、`-=` 演算子を使用して前のイベント登録を取り消します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-187">In C++/CX you use the `-=` operator to revoke a prior event registration.</span></span>

```cppcx
myButton->Click -= token;
```

<span data-ttu-id="edd2a-188">C++/WinRT で対応するコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="edd2a-188">This is the equivalent in C++/WinRT.</span></span>

```cppwinrt
myButton().Click(token);
```

<span data-ttu-id="edd2a-189">詳細とオプションについては、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="edd2a-189">For more info and options, see [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate).</span></span>

## <a name="mapping-ccx-platform-types-to-cwinrt-types"></a><span data-ttu-id="edd2a-190">C++/WinRT 型への C++/CX **Platform** 型のマッピング</span><span class="sxs-lookup"><span data-stu-id="edd2a-190">Mapping C++/CX **Platform** types to C++/WinRT types</span></span>
<span data-ttu-id="edd2a-191">C++/CX は **Platform** 名前空間でいくつかのデータ型を提供します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-191">C++/CX provides several data types in the **Platform** namespace.</span></span> <span data-ttu-id="edd2a-192">これらの型は標準 C++ ではないため、Windows ランタイム言語拡張機能を有効にしたとき (Visual Studio プロジェクトのプロパティの **[C/C++]** > **[全般]** > **[Windows ランタイム拡張機能の使用]** > **[はい (/ZW)]**) にのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-192">These types are not standard C++, so you can only use them when you enable Windows Runtime language extensions (Visual Studio project property **C/C++** > **General** > **Consume Windows Runtime Extension** > **Yes (/ZW)**).</span></span> <span data-ttu-id="edd2a-193">下の表は、**Platform** 型を C++/WinRT の同等の型に移植するときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-193">The table below helps you port from **Platform** types to their equivalents in C++/WinRT.</span></span> <span data-ttu-id="edd2a-194">完了したら、C++/WinRT は標準 C++ であるため、`/ZW` オプションをオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-194">Once you've done that, since C++/WinRT is standard C++, you can turn off the `/ZW` option.</span></span>

| <span data-ttu-id="edd2a-195">C++/CX</span><span class="sxs-lookup"><span data-stu-id="edd2a-195">C++/CX</span></span> | <span data-ttu-id="edd2a-196">C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="edd2a-196">C++/WinRT</span></span> |
| ---- | ---- |
| <span data-ttu-id="edd2a-197">**Platform::agile\^**</span><span class="sxs-lookup"><span data-stu-id="edd2a-197">**Platform::Agile\^**</span></span> | [<span data-ttu-id="edd2a-198">**winrt::agile_ref**</span><span class="sxs-lookup"><span data-stu-id="edd2a-198">**winrt::agile_ref**</span></span>](/uwp/cpp-ref-for-winrt/agile-ref) |
| <span data-ttu-id="edd2a-199">**Platform::array\^**</span><span class="sxs-lookup"><span data-stu-id="edd2a-199">**Platform::Array\^**</span></span> | <span data-ttu-id="edd2a-200">参照してください[ポート**platform::array\^**](#port-platformarray)</span><span class="sxs-lookup"><span data-stu-id="edd2a-200">See [Port **Platform::Array\^**](#port-platformarray)</span></span> |
| <span data-ttu-id="edd2a-201">**Platform::exception\^**</span><span class="sxs-lookup"><span data-stu-id="edd2a-201">**Platform::Exception\^**</span></span> | [<span data-ttu-id="edd2a-202">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-202">**winrt::hresult_error**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) |
| <span data-ttu-id="edd2a-203">**Platform::invalidargumentexception\^**</span><span class="sxs-lookup"><span data-stu-id="edd2a-203">**Platform::InvalidArgumentException\^**</span></span> | [<span data-ttu-id="edd2a-204">**winrt::hresult_invalid_argument**</span><span class="sxs-lookup"><span data-stu-id="edd2a-204">**winrt::hresult_invalid_argument**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) |
| <span data-ttu-id="edd2a-205">**Platform::object\^**</span><span class="sxs-lookup"><span data-stu-id="edd2a-205">**Platform::Object\^**</span></span> | <span data-ttu-id="edd2a-206">**winrt::Windows::Foundation::IInspectable**</span><span class="sxs-lookup"><span data-stu-id="edd2a-206">**winrt::Windows::Foundation::IInspectable**</span></span> |
| <span data-ttu-id="edd2a-207">**Platform::string\^**</span><span class="sxs-lookup"><span data-stu-id="edd2a-207">**Platform::String\^**</span></span> | [<span data-ttu-id="edd2a-208">**winrt::hstring**</span><span class="sxs-lookup"><span data-stu-id="edd2a-208">**winrt::hstring**</span></span>](/uwp/cpp-ref-for-winrt/hstring) |

### <a name="port-platformagile-to-winrtagileref"></a><span data-ttu-id="edd2a-209">ポート**platform::agile\^** に**winrt::agile_ref**</span><span class="sxs-lookup"><span data-stu-id="edd2a-209">Port **Platform::Agile\^** to **winrt::agile_ref**</span></span>
<span data-ttu-id="edd2a-210">**Platform::agile\^** 型 c++/cli CX は任意のスレッドからアクセスできる Windows ランタイム クラスを表します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-210">The **Platform::Agile\^** type in C++/CX represents a Windows Runtime class that can be accessed from any thread.</span></span> <span data-ttu-id="edd2a-211">C++/cli では WinRT 相当[ **winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref)します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-211">The C++/WinRT equivalent is [**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref).</span></span>

<span data-ttu-id="edd2a-212">C++/CX で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="edd2a-212">In C++/CX.</span></span>

```cppcx
Platform::Agile<Windows::UI::Core::CoreWindow> m_window;
```

<span data-ttu-id="edd2a-213">C++/WinRT で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="edd2a-213">In C++/WinRT.</span></span>

```cppwinrt
winrt::agile_ref<Windows::UI::Core::CoreWindow> m_window;
```

### <a name="port-platformarray"></a><span data-ttu-id="edd2a-214">ポート**platform::array\^**</span><span class="sxs-lookup"><span data-stu-id="edd2a-214">Port **Platform::Array\^**</span></span>
<span data-ttu-id="edd2a-215">オプションには、初期化子リストを使用して、 **std::array**、または**std::vector**します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-215">Your options include using an initializer list, a **std::array**, or a **std::vector**.</span></span> <span data-ttu-id="edd2a-216">詳細については、およびコード例は、次を参照してください。[標準的な初期化子リスト](/windows/uwp/cpp-and-winrt-apis/std-cpp-data-types#standard-initializer-lists)と[標準配列とベクター](/windows/uwp/cpp-and-winrt-apis/std-cpp-data-types#standard-arrays-and-vectors)します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-216">For more info, and code examples, see [Standard initializer lists](/windows/uwp/cpp-and-winrt-apis/std-cpp-data-types#standard-initializer-lists) and [Standard arrays and vectors](/windows/uwp/cpp-and-winrt-apis/std-cpp-data-types#standard-arrays-and-vectors).</span></span>

### <a name="port-platformexception-to-winrthresulterror"></a><span data-ttu-id="edd2a-217">ポート**platform::exception\^** に**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-217">Port **Platform::Exception\^** to **winrt::hresult_error**</span></span>
<span data-ttu-id="edd2a-218">**Platform::exception\^**  c++ 型が生成される/cli CX、Windows ランタイム API に非 S が返されるときに\_OK HRESULT。</span><span class="sxs-lookup"><span data-stu-id="edd2a-218">The **Platform::Exception\^** type is produced in C++/CX when a Windows Runtime API returns a non S\_OK HRESULT.</span></span> <span data-ttu-id="edd2a-219">C++/WinRT の同等の型は [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-219">The C++/WinRT equivalent is [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error).</span></span>

<span data-ttu-id="edd2a-220">C + に移植する/cli WinRT を使用するすべてのコードを変更**platform::exception\^** を使用する**winrt::hresult_error**します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-220">To port to C++/WinRT, change all code that uses **Platform::Exception\^** to use **winrt::hresult_error**.</span></span>

<span data-ttu-id="edd2a-221">C++/CX で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="edd2a-221">In C++/CX.</span></span>

```cppcx
catch (Platform::Exception^ ex)
```

<span data-ttu-id="edd2a-222">C++/WinRT で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="edd2a-222">In C++/WinRT.</span></span>

```cppwinrt
catch (winrt::hresult_error const& ex)
```

<span data-ttu-id="edd2a-223">C++/WinRT には、これらの例外クラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="edd2a-223">C++/WinRT provides these exception classes.</span></span>

| <span data-ttu-id="edd2a-224">例外の型</span><span class="sxs-lookup"><span data-stu-id="edd2a-224">Exception type</span></span> | <span data-ttu-id="edd2a-225">基本クラス</span><span class="sxs-lookup"><span data-stu-id="edd2a-225">Base class</span></span> | <span data-ttu-id="edd2a-226">HRESULT</span><span class="sxs-lookup"><span data-stu-id="edd2a-226">HRESULT</span></span> |
| ---- | ---- | ---- |
| [<span data-ttu-id="edd2a-227">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-227">**winrt::hresult_error**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) | | <span data-ttu-id="edd2a-228">[  **hresult_error::to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 呼び出し</span><span class="sxs-lookup"><span data-stu-id="edd2a-228">call [**hresult_error::to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function)</span></span> |
| [<span data-ttu-id="edd2a-229">**winrt::hresult_access_denied**</span><span class="sxs-lookup"><span data-stu-id="edd2a-229">**winrt::hresult_access_denied**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-access-denied) | <span data-ttu-id="edd2a-230">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-230">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-231">E_ACCESSDENIED</span><span class="sxs-lookup"><span data-stu-id="edd2a-231">E_ACCESSDENIED</span></span> |
| [<span data-ttu-id="edd2a-232">**winrt::hresult_canceled**</span><span class="sxs-lookup"><span data-stu-id="edd2a-232">**winrt::hresult_canceled**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-canceled) | <span data-ttu-id="edd2a-233">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-233">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-234">ERROR_CANCELLED</span><span class="sxs-lookup"><span data-stu-id="edd2a-234">ERROR_CANCELLED</span></span> |
| [<span data-ttu-id="edd2a-235">**winrt::hresult_changed_state**</span><span class="sxs-lookup"><span data-stu-id="edd2a-235">**winrt::hresult_changed_state**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-changed-state) | <span data-ttu-id="edd2a-236">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-236">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-237">E_CHANGED_STATE</span><span class="sxs-lookup"><span data-stu-id="edd2a-237">E_CHANGED_STATE</span></span> |
| [<span data-ttu-id="edd2a-238">**winrt::hresult_class_not_available**</span><span class="sxs-lookup"><span data-stu-id="edd2a-238">**winrt::hresult_class_not_available**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-class-not-available) | <span data-ttu-id="edd2a-239">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-239">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-240">CLASS_E_CLASSNOTAVAILABLE</span><span class="sxs-lookup"><span data-stu-id="edd2a-240">CLASS_E_CLASSNOTAVAILABLE</span></span> |
| [<span data-ttu-id="edd2a-241">**winrt::hresult_illegal_delegate_assignment**</span><span class="sxs-lookup"><span data-stu-id="edd2a-241">**winrt::hresult_illegal_delegate_assignment**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-delegate-assignment) | <span data-ttu-id="edd2a-242">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-242">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-243">E_ILLEGAL_DELEGATE_ASSIGNMENT</span><span class="sxs-lookup"><span data-stu-id="edd2a-243">E_ILLEGAL_DELEGATE_ASSIGNMENT</span></span> |
| [<span data-ttu-id="edd2a-244">**winrt::hresult_illegal_method_call**</span><span class="sxs-lookup"><span data-stu-id="edd2a-244">**winrt::hresult_illegal_method_call**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-method-call) | <span data-ttu-id="edd2a-245">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-245">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-246">E_ILLEGAL_METHOD_CALL</span><span class="sxs-lookup"><span data-stu-id="edd2a-246">E_ILLEGAL_METHOD_CALL</span></span> |
| [<span data-ttu-id="edd2a-247">**winrt::hresult_illegal_state_change**</span><span class="sxs-lookup"><span data-stu-id="edd2a-247">**winrt::hresult_illegal_state_change**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-state-change) | <span data-ttu-id="edd2a-248">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-248">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-249">E_ILLEGAL_STATE_CHANGE</span><span class="sxs-lookup"><span data-stu-id="edd2a-249">E_ILLEGAL_STATE_CHANGE</span></span> |
| [<span data-ttu-id="edd2a-250">**winrt::hresult_invalid_argument**</span><span class="sxs-lookup"><span data-stu-id="edd2a-250">**winrt::hresult_invalid_argument**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) | <span data-ttu-id="edd2a-251">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-251">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-252">E_INVALIDARG</span><span class="sxs-lookup"><span data-stu-id="edd2a-252">E_INVALIDARG</span></span> |
| [<span data-ttu-id="edd2a-253">**winrt::hresult_no_interface**</span><span class="sxs-lookup"><span data-stu-id="edd2a-253">**winrt::hresult_no_interface**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-no-interface) | <span data-ttu-id="edd2a-254">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-254">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-255">E_NOINTERFACE</span><span class="sxs-lookup"><span data-stu-id="edd2a-255">E_NOINTERFACE</span></span> |
| [<span data-ttu-id="edd2a-256">**winrt::hresult_not_implemented**</span><span class="sxs-lookup"><span data-stu-id="edd2a-256">**winrt::hresult_not_implemented**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-not-implemented) | <span data-ttu-id="edd2a-257">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-257">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-258">E_NOTIMPL</span><span class="sxs-lookup"><span data-stu-id="edd2a-258">E_NOTIMPL</span></span> |
| [<span data-ttu-id="edd2a-259">**winrt::hresult_out_of_bounds**</span><span class="sxs-lookup"><span data-stu-id="edd2a-259">**winrt::hresult_out_of_bounds**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-out-of-bounds) | <span data-ttu-id="edd2a-260">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-260">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-261">E_BOUNDS</span><span class="sxs-lookup"><span data-stu-id="edd2a-261">E_BOUNDS</span></span> |
| [<span data-ttu-id="edd2a-262">**winrt::hresult_wrong_thread**</span><span class="sxs-lookup"><span data-stu-id="edd2a-262">**winrt::hresult_wrong_thread**</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-wrong-thread) | <span data-ttu-id="edd2a-263">**winrt::hresult_error**</span><span class="sxs-lookup"><span data-stu-id="edd2a-263">**winrt::hresult_error**</span></span> | <span data-ttu-id="edd2a-264">RPC_E_WRONG_THREAD</span><span class="sxs-lookup"><span data-stu-id="edd2a-264">RPC_E_WRONG_THREAD</span></span> |

<span data-ttu-id="edd2a-265">各クラスは (**hresult_error** 基本クラスを介して)、エラーの HRESULT を返す [**to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 関数を指定し、その HRESULT の文字列表現を返す [**message**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrormessage-function) 関数を指定します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-265">Note that each class (via the **hresult_error** base class) provides a [**to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) function, which returns the HRESULT of the error, and a [**message**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrormessage-function) function, which returns the string representation of that HRESULT.</span></span>

<span data-ttu-id="edd2a-266">C++/CX で例外をスローする例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-266">Here's an example of throwing an exception in C++/CX.</span></span>

```cppcx
throw ref new Platform::InvalidArgumentException(L"A valid User is required");
```

<span data-ttu-id="edd2a-267">また、C++/WinRT での同等のコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="edd2a-267">And the equivalent in C++/WinRT.</span></span>

```cppwinrt
throw winrt::hresult_invalid_argument{ L"A valid User is required" };
```

### <a name="port-platformobject-to-winrtwindowsfoundationiinspectable"></a><span data-ttu-id="edd2a-268">ポート**platform::object\^** に**winrt::Windows::Foundation::IInspectable**</span><span class="sxs-lookup"><span data-stu-id="edd2a-268">Port **Platform::Object\^** to **winrt::Windows::Foundation::IInspectable**</span></span>
<span data-ttu-id="edd2a-269">すべての C++/WinRT 型と同様に、**winrt::Windows::Foundation::IInspectable** は値の型です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-269">Like all C++/WinRT types, **winrt::Windows::Foundation::IInspectable** is a value type.</span></span> <span data-ttu-id="edd2a-270">その型の変数を null に初期化する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="edd2a-270">Here's how you initialize a variable of that type to null.</span></span>

```cppwinrt
winrt::Windows::Foundation::IInspectable var{ nullptr };
```

### <a name="port-platformstring-to-winrthstring"></a><span data-ttu-id="edd2a-271">ポート**platform::string\^** に**winrt::hstring**</span><span class="sxs-lookup"><span data-stu-id="edd2a-271">Port **Platform::String\^** to **winrt::hstring**</span></span>
<span data-ttu-id="edd2a-272">**Platform::string\^** は Windows ランタイム HSTRING ABI の型に相当します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-272">**Platform::String\^** is equivalent to the Windows Runtime HSTRING ABI type.</span></span> <span data-ttu-id="edd2a-273">C++/WinRT では、同等の型は [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-273">For C++/WinRT, the equivalent is [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring).</span></span> <span data-ttu-id="edd2a-274">ただし、C++/WinRT では、**std::wstring** などの C++ 標準ライブラリのワイド文字列型、およびワイド文字列リテラルを使用して Windows ランタイム API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-274">But with C++/WinRT, you can call Windows Runtime APIs using C++ Standard Library wide string types such as **std::wstring**, and/or wide string literals.</span></span> <span data-ttu-id="edd2a-275">詳細とコード例については、「[C++/WinRT での文字列の処理](strings.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="edd2a-275">For more details, and code examples, see [String handling in C++/WinRT](strings.md).</span></span>

<span data-ttu-id="edd2a-276">C++/cli CX にアクセスできます、 [ **Platform::String::Data** ](https://docs.microsoft.com/en-us/cpp/cppcx/platform-string-class#data) C スタイルとして文字列を取得するプロパティ**const wchar_t\***  (たとえば、通過するための配列**std::wcout**)。</span><span class="sxs-lookup"><span data-stu-id="edd2a-276">With C++/CX, you can access the [**Platform::String::Data**](https://docs.microsoft.com/en-us/cpp/cppcx/platform-string-class#data) property to retrieve the string as a C-style **const wchar_t\*** array (for example, to pass it to **std::wcout**).</span></span>

```cppcx
auto var{ titleRecord->TitleName->Data() };
```

<span data-ttu-id="edd2a-277">C++/WinRT で同じ操作を行うには、[**hstring::c_str**](/uwp/api/windows.foundation.uri.-ctor#Windows_Foundation_Uri__ctor_System_String_) 関数を使用して null で終了する C スタイルの文字列バージョンを取得します。これは **std::wstring** から取得する場合と同様です。</span><span class="sxs-lookup"><span data-stu-id="edd2a-277">To do the same with C++/WinRT, you can use the [**hstring::c_str**](/uwp/api/windows.foundation.uri.-ctor#Windows_Foundation_Uri__ctor_System_String_) function to get a null-terminated C-style string version, just as you can from **std::wstring**.</span></span>

```cppwinrt
auto var{ titleRecord.TitleName().c_str() };
```

<span data-ttu-id="edd2a-278">実行したり、文字列を返す Api を実装する際に通常を変更する、C +/cli/CX コードを使用する**platform::string\^** を使用する**winrt::hstring**代わりにします。</span><span class="sxs-lookup"><span data-stu-id="edd2a-278">When it comes to implementing APIs that take or return strings, you typically change any C++/CX code that uses **Platform::String\^** to use **winrt::hstring** instead.</span></span>

<span data-ttu-id="edd2a-279">文字列を取る C++/CX API の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-279">Here's an example of a C++/CX API that takes a string.</span></span>

```cppcx
void LogWrapLine(Platform::String^ str);
```

<span data-ttu-id="edd2a-280">C++/WinRT では、次のようにその API を [MIDL 3.0](/uwp/midl-3) で宣言できます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-280">For C++/WinRT you could declare that API in [MIDL 3.0](/uwp/midl-3) like this.</span></span>

```idl
// LogType.idl
void LogWrapLine(String str);
```

<span data-ttu-id="edd2a-281">次に C++/WinRT ツール チェーンは次のようなソース コードを生成します。</span><span class="sxs-lookup"><span data-stu-id="edd2a-281">The C++/WinRT toolchain will then generate source code for you that looks like this.</span></span>

```cppwinrt
void LogWrapLine(winrt::hstring const& str);
```

#### <a name="tostring"></a><span data-ttu-id="edd2a-282">ToString()</span><span class="sxs-lookup"><span data-stu-id="edd2a-282">ToString()</span></span>

<span data-ttu-id="edd2a-283">C + + CX の提供、 [object::tostring](/cpp/cppcx/platform-object-class?view=vs-2017#tostring)メソッド。</span><span class="sxs-lookup"><span data-stu-id="edd2a-283">C++/CX provides the [Object::ToString](/cpp/cppcx/platform-object-class?view=vs-2017#tostring) method.</span></span>

```cppcx
int i{ 2 };
auto s{ i.ToString() }; // s is a Platform::String^ with value L"2".
```

<span data-ttu-id="edd2a-284">C +/cli WinRT がこの機能を提供して直接いませんが、代替にすることができます。</span><span class="sxs-lookup"><span data-stu-id="edd2a-284">C++/WinRT doesn't directly provide this facility, but you can turn to alternatives.</span></span>

```cppwinrt
int i{ 2 };
auto s{ std::to_wstring(i) }; // s is a std::wstring with value L"2".
```

## <a name="important-apis"></a><span data-ttu-id="edd2a-285">重要な API</span><span class="sxs-lookup"><span data-stu-id="edd2a-285">Important APIs</span></span>
* [<span data-ttu-id="edd2a-286">winrt::delegate 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="edd2a-286">winrt::delegate struct template</span></span>](/uwp/cpp-ref-for-winrt/delegate)
* [<span data-ttu-id="edd2a-287">winrt::hresult_error 構造体</span><span class="sxs-lookup"><span data-stu-id="edd2a-287">winrt::hresult_error struct</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)
* [<span data-ttu-id="edd2a-288">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="edd2a-288">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="edd2a-289">winrt 名前空間</span><span class="sxs-lookup"><span data-stu-id="edd2a-289">winrt namespace</span></span>](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a><span data-ttu-id="edd2a-290">関連トピック</span><span class="sxs-lookup"><span data-stu-id="edd2a-290">Related topics</span></span>
* [<span data-ttu-id="edd2a-291">C++/CX</span><span class="sxs-lookup"><span data-stu-id="edd2a-291">C++/CX</span></span>](/cpp/cppcx/visual-c-language-reference-c-cx)
* [<span data-ttu-id="edd2a-292">C + でのイベントを作成/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="edd2a-292">Author events in C++/WinRT</span></span>](author-events.md)
* [<span data-ttu-id="edd2a-293">同時実行と非同期操作を C +/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="edd2a-293">Concurrency and asynchronous operations with C++/WinRT</span></span>](concurrency.md)
* [<span data-ttu-id="edd2a-294">C++/WinRT で API を使用する</span><span class="sxs-lookup"><span data-stu-id="edd2a-294">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="edd2a-295">C + でデリゲートを使用してイベントを処理/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="edd2a-295">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
* [<span data-ttu-id="edd2a-296">C++/WinRT と C++/CX 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="edd2a-296">Interop between C++/WinRT and C++/CX</span></span>](interop-winrt-cx.md)
* [<span data-ttu-id="edd2a-297">Microsoft インターフェイス定義言語の 3.0 の参照</span><span class="sxs-lookup"><span data-stu-id="edd2a-297">Microsoft Interface Definition Language 3.0 reference</span></span>](/uwp/midl-3)
* [<span data-ttu-id="edd2a-298">WRL から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="edd2a-298">Move to C++/WinRT from WRL</span></span>](move-to-winrt-from-wrl.md)
* [<span data-ttu-id="edd2a-299">文字列処理 c++/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="edd2a-299">String handling in C++/WinRT</span></span>](strings.md)
