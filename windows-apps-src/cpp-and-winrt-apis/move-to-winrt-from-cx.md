---
author: stevewhims
description: このトピックでは、C++/CX コードを C++/WinRT の同等のコードに移植する方法について説明します。
title: C++/CX から C++/WinRT への移行
ms.author: stwhi
ms.date: 10/18/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, C++/CX
ms.localizationpriority: medium
ms.openlocfilehash: 35fe84747624c9a855df5520322546b83772379b
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5754362"
---
# <a name="move-to-cwinrt-from-ccx"></a><span data-ttu-id="bd114-104">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="bd114-104">Move to C++/WinRT from C++/CX</span></span>

<span data-ttu-id="bd114-105">このトピックでは、コードを移植する方法を示しています。、 [、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx)プロジェクトで同等額を[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="bd114-105">This topic shows how to port the code in a [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) project to its equivalent in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span>

## <a name="porting-strategies"></a><span data-ttu-id="bd114-106">戦略の移植</span><span class="sxs-lookup"><span data-stu-id="bd114-106">Porting strategies</span></span>

<span data-ttu-id="bd114-107">C++ の段階的に移植する場合 +/CX コードを C++//winrt では、そのことができます。</span><span class="sxs-lookup"><span data-stu-id="bd114-107">If you want to gradually port your C++/CX code to C++/WinRT, then you can.</span></span> <span data-ttu-id="bd114-108">C++/cli/CX と C++/WinRT コードに XAML コンパイラ サポートと Windows ランタイム コンポーネントの例外を除き、同じプロジェクトに共存することができます。</span><span class="sxs-lookup"><span data-stu-id="bd114-108">C++/CX and C++/WinRT code can coexist in the same project, with the exceptions of XAML compiler support and Windows Runtime Components.</span></span> <span data-ttu-id="bd114-109">これら 2 つの例外が必要になりますか C + をターゲットに +/CX または + 同じプロジェクト内で WinRT します。</span><span class="sxs-lookup"><span data-stu-id="bd114-109">For those two exceptions, you'll need to target either C++/CX or C++/WinRT within the same project.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="bd114-110">プロジェクトが XAML アプリケーションをビルドする場合推奨される 1 つのワークフローは、まず、C++ のいずれかを使用して Visual Studio で新しいプロジェクトを作成する/WinRT プロジェクト テンプレート (を参照してください[、C++、Visual Studio サポート +/winrt と VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix))。</span><span class="sxs-lookup"><span data-stu-id="bd114-110">If your project builds a XAML application, then one workflow that we recommend is to first create a new project in Visual Studio using one of the C++/WinRT project templates (see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)).</span></span> <span data-ttu-id="bd114-111">次に、開始から、C++ 経由でソース コードとマークアップをコピー/CX プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="bd114-111">Then, start copying source code and markup over from the C++/CX project.</span></span> <span data-ttu-id="bd114-112">**プロジェクト**に新しい XAML ページを追加する \> **新しい項目の追加]** \>  **Visual C** > **空白のページ (、C++/WinRT)** します。</span><span class="sxs-lookup"><span data-stu-id="bd114-112">You can add new XAML pages with **Project** \> **Add New Item...** \> **Visual C++** > **Blank Page (C++/WinRT)**.</span></span>
>
> <span data-ttu-id="bd114-113">要素のコードから、XAML、C++ の Windows ランタイム コンポーネントを使用する代わりに、/CX プロジェクトの移植するとします。</span><span class="sxs-lookup"><span data-stu-id="bd114-113">Alternatively, you can use a Windows Runtime Component to factor code out of the XAML C++/CX project as you port it.</span></span> <span data-ttu-id="bd114-114">移動するか、できるだけ多く C + + CX コードのコンポーネントを作成して c++ XAML プロジェクトを変更する/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="bd114-114">Either move as much C++/CX code as you can into a component, and then change the XAML project to C++/WinRT.</span></span> <span data-ttu-id="bd114-115">またはそれ以外の場合、C++ と XAML プロジェクトのままに/CX、作成新しい C + + WinRT コンポーネント、C + の移植を開始し、+/CX コード、XAML プロジェクトからコンポーネントにします。</span><span class="sxs-lookup"><span data-stu-id="bd114-115">Or else leave the XAML project as C++/CX, create a new C++/WinRT component, and begin porting C++/CX code out of the XAML project and into the component.</span></span> <span data-ttu-id="bd114-116">場合もあります C + + と共に c++ コンポーネント プロジェクトを CX/WinRT コンポーネントのプロジェクトで、同じソリューション内でアプリケーション プロジェクトからそれらの両方を参照し、段階的に、他のいずれかから移植します。</span><span class="sxs-lookup"><span data-stu-id="bd114-116">You could also have a C++/CX component project alongside a C++/WinRT component project within the same solution, reference both of them from your application project, and gradually port from one to the other.</span></span> <span data-ttu-id="bd114-117">参照してください[、C++ の間の相互運用機能//winrt と C++/cli CX](interop-winrt-cx.md)同じプロジェクトで、2 つの言語プロジェクションの使用について詳しくします。</span><span class="sxs-lookup"><span data-stu-id="bd114-117">See [Interop between C++/WinRT and C++/CX](interop-winrt-cx.md) for more details on using the two language projections in the same project.</span></span>

> [!NOTE]
> <span data-ttu-id="bd114-118">[C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) と Windows SDK の両方で、ルート名前空間 **Windows** で型を宣言します。</span><span class="sxs-lookup"><span data-stu-id="bd114-118">Both [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) and the Windows SDK declare types in the root namespace **Windows**.</span></span> <span data-ttu-id="bd114-119">C++/WinRT に投影された Windows 型は Windows 型と同じ完全修飾名を持ちますが、 C++ **winrt** 名前空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="bd114-119">A Windows type projected into C++/WinRT has the same fully-qualified name as the Windows type, but it's placed in the C++ **winrt** namespace.</span></span> <span data-ttu-id="bd114-120">これらの異なる名前空間では、独自のペースで C++/CX から C++/WinRT へ移植できます。</span><span class="sxs-lookup"><span data-stu-id="bd114-120">These distinct namespaces let you port from C++/CX to C++/WinRT at your own pace.</span></span>

<span data-ttu-id="bd114-121">C++ の移植の最初の手順は上で説明した例外に注意してください方位、/を C++ プロジェクトを CX/を手動で追加すると、C++/winrt は/WinRT サポート (を参照してください[、C++、Visual Studio サポート +/winrt と VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix))。</span><span class="sxs-lookup"><span data-stu-id="bd114-121">Bearing in mind the exceptions mentioned above, the first step in porting a C++/CX project to C++/WinRT is to manually add C++/WinRT support to it (see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)).</span></span> <span data-ttu-id="bd114-122">これを行うには、`.vcxproj` ファイルを編集し、`<PropertyGroup Label="Globals">` を見つけ、そのプロパティ グループ内で、プロパティ `<CppWinRTEnabled>true</CppWinRTEnabled>` を設定します。</span><span class="sxs-lookup"><span data-stu-id="bd114-122">To do that, edit your `.vcxproj` file, find `<PropertyGroup Label="Globals">` and, inside that property group, set the property `<CppWinRTEnabled>true</CppWinRTEnabled>`.</span></span> <span data-ttu-id="bd114-123">その変更による 1 つの効果は、C++/CX のサポートがプロジェクトで無効になることです。</span><span class="sxs-lookup"><span data-stu-id="bd114-123">One effect of that change is that support for C++/CX is turned off in the project.</span></span> <span data-ttu-id="bd114-124">C++ でのすべての依存関係オフになりメッセージをビルドする際に役立つ検索 (ポート) のサポートを残すことをお勧め/CX、またはすることが再びオンにサポート (プロジェクトのプロパティで**C/C++** \> **一般的な** \> **消費 Windows ランタイム拡張** \> **[はい (/ZW)**)、徐々 にポートとします。</span><span class="sxs-lookup"><span data-stu-id="bd114-124">It's a good idea to leave support turned off so that build messages help you find (and port) all of your dependencies on C++/CX, or you can turn support back on (in project properties, **C/C++** \> **General** \> **Consume Windows Runtime Extension** \> **Yes (/ZW)**), and port gradually.</span></span>

<span data-ttu-id="bd114-125">**一般的な**プロジェクト プロパティを確認します。 \> **ターゲット プラットフォーム バージョン**10.0.17134.0 (Windows 10、バージョン 1803) に設定以上。</span><span class="sxs-lookup"><span data-stu-id="bd114-125">Ensure that project property **General** \> **Target Platform Version** is set to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="bd114-126">プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。</span><span class="sxs-lookup"><span data-stu-id="bd114-126">In your precompiled header file (usually `pch.h`), include `winrt/base.h`.</span></span>

```cppwinrt
#include <winrt/base.h>
```

<span data-ttu-id="bd114-127">C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。</span><span class="sxs-lookup"><span data-stu-id="bd114-127">If you include any C++/WinRT projected Windows API headers (for example, `winrt/Windows.Foundation.h`), then you don't need to explicitly include `winrt/base.h` like this because it will be included automatically for you.</span></span>

<span data-ttu-id="bd114-128">プロジェクトで [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) 型も使用している場合は、「[WRL から C++/WinRT への移行](move-to-winrt-from-wrl.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bd114-128">If your project is also using [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) types, then see [Move to C++/WinRT from WRL](move-to-winrt-from-wrl.md).</span></span>

## <a name="parameter-passing"></a><span data-ttu-id="bd114-129">パラメーターの引き渡し</span><span class="sxs-lookup"><span data-stu-id="bd114-129">Parameter-passing</span></span>
<span data-ttu-id="bd114-130">C++/CX ソース コードを記述するときに、ハット (\^) が参照する C++/CX 型を関数パラメーターとして渡します。</span><span class="sxs-lookup"><span data-stu-id="bd114-130">When writing C++/CX source code, you pass C++/CX types as function parameters as hat (\^) references.</span></span>

```cpp
void LogPresenceRecord(PresenceRecord^ record);
```

<span data-ttu-id="bd114-131">C++/WinRT では、同期関数に既定で `const&` パラメーターを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bd114-131">In C++/WinRT, for synchronous functions, you should use `const&` parameters by default.</span></span> <span data-ttu-id="bd114-132">これにより、コピーとインター ロック オーバーヘッドが回避されます。</span><span class="sxs-lookup"><span data-stu-id="bd114-132">That will avoid copies and interlocked overhead.</span></span> <span data-ttu-id="bd114-133">ただし、コルーチンが値による呼び出しをして有効期間の問題を回避するように、値渡しを使用する必要があります (詳細については、「[C++/WinRT を使用した同時実行と非同期操作](concurrency.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="bd114-133">But your coroutines should use pass-by-value to ensure that they capture by value and avoid lifetime issues (for more details, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md)).</span></span>

```cppwinrt
void LogPresenceRecord(PresenceRecord const& record);
IASyncAction LogPresenceRecordAsync(PresenceRecord const record);
```

<span data-ttu-id="bd114-134">C++/WinRT オブジェクトは、基本的に Windows ランタイムのバッキング オブジェクトへのインターフェイス ポインターを保持する値です。</span><span class="sxs-lookup"><span data-stu-id="bd114-134">A C++/WinRT object is fundamentally a value that holds an interface pointer to the backing Windows Runtime object.</span></span> <span data-ttu-id="bd114-135">C++/WinRT オブジェクトをコピーすると、コンパイラはカプセル化されたインターフェイス ポインターをコピーし、その参照カウントをインクリメントします。</span><span class="sxs-lookup"><span data-stu-id="bd114-135">When you copy a C++/WinRT object, the compiler copies the encapsulated interface pointer, incrementing its reference count.</span></span> <span data-ttu-id="bd114-136">コピーの最終的なデストラクションには、参照カウントのデクリメントも含まれます。</span><span class="sxs-lookup"><span data-stu-id="bd114-136">Eventual destruction of the copy involves decrementing the reference count.</span></span> <span data-ttu-id="bd114-137">そのため、必要な場合にのみ、コピーのオーバーヘッドが発生します。</span><span class="sxs-lookup"><span data-stu-id="bd114-137">So, only incur the overhead of a copy when necessary.</span></span>

## <a name="variable-and-field-references"></a><span data-ttu-id="bd114-138">変数とフィールドの参照</span><span class="sxs-lookup"><span data-stu-id="bd114-138">Variable and field references</span></span>
<span data-ttu-id="bd114-139">C++/CX ソース コードを記述するときに、ハット (\^) 変数を使用して Windows ランタイム オブジェクトを参照し、矢印 (-&gt;) 演算子を使用してハット変数を逆参照します。</span><span class="sxs-lookup"><span data-stu-id="bd114-139">When writing C++/CX source code, you use hat (\^) variables to reference Windows Runtime objects, and the arrow (-&gt;) operator to dereference a hat variable.</span></span>

```cpp
IVectorView<User^>^ userList = User::Users;

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList->Size; ++iUser)
    ...
```

<span data-ttu-id="bd114-140">同等の C++ + に移植するとき/WinRT コードでは、基本的には、ハットを削除し、矢印演算子を変更する (-&gt;) ドット演算子 (.) にため、C++//winrt の投影された型は値、およびポインターではありません。</span><span class="sxs-lookup"><span data-stu-id="bd114-140">When porting to the equivalent C++/WinRT code, you basically remove the hats and change the arrow operator (-&gt;) to the dot operator (.), because C++/WinRT projected types are values, and not pointers.</span></span>

```cppwinrt
IVectorView<User> userList = User::Users();

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList.Size(); ++iUser)
    ...
```

## <a name="properties"></a><span data-ttu-id="bd114-141">プロパティ</span><span class="sxs-lookup"><span data-stu-id="bd114-141">Properties</span></span>
<span data-ttu-id="bd114-142">C++/CX 言語拡張機能には、プロパティの概念が含まれています。</span><span class="sxs-lookup"><span data-stu-id="bd114-142">The C++/CX language extensions include the concept of properties.</span></span> <span data-ttu-id="bd114-143">C++/CX ソース コードを記述するときに、フィールドと同様にプロパティにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="bd114-143">When writing C++/CX source code, you can access a property as if it were a field.</span></span> <span data-ttu-id="bd114-144">標準 C++ にはプロパティの概念がないため、C++/WinRT では、Get 関数と Set 関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="bd114-144">Standard C++ does not have the concept of a property so, in C++/WinRT, you call get and set functions.</span></span>

<span data-ttu-id="bd114-145">次の例では、**XboxUserId**、**UserState**、**PresenceDeviceRecords**、**Size** はすべてプロパティです。</span><span class="sxs-lookup"><span data-stu-id="bd114-145">In the examples that follow, **XboxUserId**, **UserState**, **PresenceDeviceRecords**, and **Size** are all properties.</span></span>

### <a name="retrieving-a-value-from-a-property"></a><span data-ttu-id="bd114-146">プロパティからの値の取得</span><span class="sxs-lookup"><span data-stu-id="bd114-146">Retrieving a value from a property</span></span>
<span data-ttu-id="bd114-147">C++/CX でプロパティの値を取得する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bd114-147">Here's how you get a property value in C++/CX.</span></span>

```cpp
void Sample::LogPresenceRecord(PresenceRecord^ record)
{
    auto id = record->XboxUserId;
    auto state = record->UserState;
    auto size = record->PresenceDeviceRecords->Size;
}
```

<span data-ttu-id="bd114-148">同等の C++/WinRT ソース コードは、プロパティと同じ名前を持ち、パラメーターのない関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="bd114-148">The equivalent C++/WinRT source code calls a function with the same name as the property, but with no parameters.</span></span>

```cppwinrt
void Sample::LogPresenceRecord(PresenceRecord const& record)
{
    auto id = record.XboxUserId();
    auto state = record.UserState();
    auto size = record.PresenceDeviceRecords().Size();
}
```

<span data-ttu-id="bd114-149">**PresenceDeviceRecords** 関数は、それ自体が **Size** 関数を持つ Windows ランタイム オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="bd114-149">Note that the **PresenceDeviceRecords** function returns a Windows Runtime object that itself has a **Size** function.</span></span> <span data-ttu-id="bd114-150">返されたオブジェクトは C++/WinRT の投影された型でもあるため、ドット演算子を使用して逆参照し、**Size** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="bd114-150">As the returned object is also a C++/WinRT projected type, we dereference using the dot operator to call **Size**.</span></span>

### <a name="setting-a-property-to-a-new-value"></a><span data-ttu-id="bd114-151">新しい値へのプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="bd114-151">Setting a property to a new value</span></span>
<span data-ttu-id="bd114-152">新しい値にプロパティを設定するには、同様のパターンに従います。</span><span class="sxs-lookup"><span data-stu-id="bd114-152">Setting a property to a new value follows a similar pattern.</span></span> <span data-ttu-id="bd114-153">まず、C++/CX で次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="bd114-153">First, in C++/CX.</span></span>

```cpp
record->UserState = newValue;
```

<span data-ttu-id="bd114-154">C++/WinRT で対応する操作を行うには、プロパティと同じ名前の関数を呼び出し、引数を渡します。</span><span class="sxs-lookup"><span data-stu-id="bd114-154">To do the equivalent in C++/WinRT, you call a function with the same name as the property, and pass an argument.</span></span>

```cppwinrt
record.UserState(newValue);
```

## <a name="creating-an-instance-of-a-class"></a><span data-ttu-id="bd114-155">クラスのインスタンスの作成</span><span class="sxs-lookup"><span data-stu-id="bd114-155">Creating an instance of a class</span></span>
<span data-ttu-id="bd114-156">C++/CX オブジェクトは、それに対するハンドル (通常はハット (\^) 参照と呼ばれます) を介して操作します。</span><span class="sxs-lookup"><span data-stu-id="bd114-156">You work with a C++/CX object via a handle to it, commonly known as a hat (\^) reference.</span></span> <span data-ttu-id="bd114-157">`ref new` キーワードにより新しいオブジェクトを作成します。これにより、[**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) が呼び出され、ランタイム クラスの新しいインスタンスがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="bd114-157">You create a new object via the `ref new` keyword, which in turn calls [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) to activate a new instance of the runtime class.</span></span>

```cpp
using namespace Windows::Storage::Streams;

class Sample
{
private:
    Buffer^ m_gamerPicBuffer = ref new Buffer(MAX_IMAGE_SIZE);
};
```

<span data-ttu-id="bd114-158">C++/WinRT オブジェクトは値であるため、スタックに割り当てるか、オブジェクトのフィールドとして割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="bd114-158">A C++/WinRT object is a value; so you can allocate it on the stack, or as a field of an object.</span></span> <span data-ttu-id="bd114-159">C++/WinRT オブジェクトを割り当てるために、`ref new` (または `new`) は使用*しません*。</span><span class="sxs-lookup"><span data-stu-id="bd114-159">You *never* use `ref new` (nor `new`) to allocate a C++/WinRT object.</span></span> <span data-ttu-id="bd114-160">バックグラウンドで **RoActivateInstance** は引き続き呼び出されています。</span><span class="sxs-lookup"><span data-stu-id="bd114-160">Behind the scenes, **RoActivateInstance** is still being called.</span></span>

```cppwinrt
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
private:
    Buffer m_gamerPicBuffer{ MAX_IMAGE_SIZE };
};
```

<span data-ttu-id="bd114-161">リソースを初期化するコストが高い場合は、実際に必要になるまで初期化を遅延するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="bd114-161">If a resource is expensive to initialize, then it's common to delay initialization of it until it's actually needed.</span></span>

```cpp
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

<span data-ttu-id="bd114-162">同じコードが C++/WinRT に移植されました。</span><span class="sxs-lookup"><span data-stu-id="bd114-162">The same code ported to C++/WinRT.</span></span> <span data-ttu-id="bd114-163">`nullptr` コンストラクターを使っていることに注目してください。</span><span class="sxs-lookup"><span data-stu-id="bd114-163">Note the use of the `nullptr` constructor.</span></span> <span data-ttu-id="bd114-164">コンストラクターの詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bd114-164">For more info about that constructor, see [Consume APIs with C++/WinRT](consume-apis.md).</span></span>

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

## <a name="converting-from-a-base-runtime-class-to-a-derived-one"></a><span data-ttu-id="bd114-165">基本のランタイム クラスから派生した 1 つに変換します。</span><span class="sxs-lookup"><span data-stu-id="bd114-165">Converting from a base runtime class to a derived one</span></span>
<span data-ttu-id="bd114-166">参照から基本派生型のオブジェクトを参照することがわかっているが一般的です。</span><span class="sxs-lookup"><span data-stu-id="bd114-166">It's common to have a reference-to-base that you know refers to an object of a derived type.</span></span> <span data-ttu-id="bd114-167">C + +/CX を使用する`dynamic_cast`に*キャスト*ベースに参照を参照する-派生にします。</span><span class="sxs-lookup"><span data-stu-id="bd114-167">In C++/CX, you use `dynamic_cast` to *cast* the reference-to-base into a reference-to-derived.</span></span> <span data-ttu-id="bd114-168">`dynamic_cast` [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521)するために非表示の呼び出しにすぎません。</span><span class="sxs-lookup"><span data-stu-id="bd114-168">The `dynamic_cast` is really just a hidden call to [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521).</span></span> <span data-ttu-id="bd114-169">典型的な例を次に示します&mdash;、依存関係プロパティの変更イベントを処理して、依存関係プロパティを所有している実際の型に**DependencyObject**からキャストします。</span><span class="sxs-lookup"><span data-stu-id="bd114-169">Here's a typical example&mdash;you're handling a dependency property changed event, and you want to cast from **DependencyObject** back to the actual type that owns the dependency property.</span></span>

```cpp
void BgLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject^ d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs^ e)
{
    BgLabelControl^ theControl{ dynamic_cast<BgLabelControl^>(d) };

    if (theControl != nullptr)
    {
        // succeeded ...
    }
}
```

<span data-ttu-id="bd114-170">同等の C + +/winrt コードを置き換えます、`dynamic_cast`カプセル化**QueryInterface** [**iunknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)関数を呼び出して、します。</span><span class="sxs-lookup"><span data-stu-id="bd114-170">The equivalent C++/WinRT code replaces the `dynamic_cast` with a call to the [**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function) function, which encapsulates **QueryInterface**.</span></span> <span data-ttu-id="bd114-171">必要なインターフェイス (要求している種類の既定のインターフェイス) の照会が返されない場合、例外をスローする代わりに、 [**iunknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)を呼び出してオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="bd114-171">You also have the option to call [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function), instead, which throws an exception if querying for the required interface (the default interface of the type you're requesting) is not returned.</span></span> <span data-ttu-id="bd114-172">ここでは、C++/WinRT のコード例です。</span><span class="sxs-lookup"><span data-stu-id="bd114-172">Here's a C++/WinRT code example.</span></span>

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

## <a name="event-handling-with-a-delegate"></a><span data-ttu-id="bd114-173">デリゲートを使用したイベント処理</span><span class="sxs-lookup"><span data-stu-id="bd114-173">Event-handling with a delegate</span></span>
<span data-ttu-id="bd114-174">この場合はデリゲートとしてラムダ関数を使用して、C++/CX でイベントを処理する典型的な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bd114-174">Here's a typical example of handling an event in C++/CX, using a lambda function as a delegate in this case.</span></span>

```cpp
auto token = myButton->Click += ref new RoutedEventHandler([&](Platform::Object^ sender, RoutedEventArgs^ args)
{
    // Handle the event.
});
```

<span data-ttu-id="bd114-175">C++/WinRT で対応するコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bd114-175">This is the equivalent in C++/WinRT.</span></span>

```cppwinrt
auto token = myButton().Click([&](IInspectable const& sender, RoutedEventArgs const& args)
{
    // Handle the event.
});
```

<span data-ttu-id="bd114-176">ラムダ関数の代わりに、デリゲートを自由関数として実装するか、またはメンバー関数へのポインターとして実装するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="bd114-176">Instead of a lambda function, you can choose to implement your delegate as a free function, or as a pointer-to-member-function.</span></span> <span data-ttu-id="bd114-177">詳細については、「[C++/WinRT でのデリゲートを使用したイベントの処理](handle-events.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bd114-177">For more info, see [Handle events by using delegates in C++/WinRT](handle-events.md).</span></span>

<span data-ttu-id="bd114-178">イベントとデリゲートが内部的に使用される C++/CX コードベース (バイナリではなく) から移植する場合は、[**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) を使用すると、C++/WinRT でそのパターンを複製できます。</span><span class="sxs-lookup"><span data-stu-id="bd114-178">If you're porting from a C++/CX codebase where events and delegates are used internally (not across binaries), then [**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) will help you to replicate that pattern in C++/WinRT.</span></span> <span data-ttu-id="bd114-179">[パラメーター化されたデリゲート、単純な信号は、プロジェクト内でコールバック](author-events.md#parameterized-delegates-simple-signals-and-callbacks-within-a-project)」も参照してください。</span><span class="sxs-lookup"><span data-stu-id="bd114-179">Also see [Parameterized delegates, simple signals, and callbacks within a project](author-events.md#parameterized-delegates-simple-signals-and-callbacks-within-a-project).</span></span>

## <a name="revoking-a-delegate"></a><span data-ttu-id="bd114-180">デリゲートの取り消し</span><span class="sxs-lookup"><span data-stu-id="bd114-180">Revoking a delegate</span></span>
<span data-ttu-id="bd114-181">C++/CX では、`-=` 演算子を使用して前のイベント登録を取り消します。</span><span class="sxs-lookup"><span data-stu-id="bd114-181">In C++/CX you use the `-=` operator to revoke a prior event registration.</span></span>

```cpp
myButton->Click -= token;
```

<span data-ttu-id="bd114-182">C++/WinRT で対応するコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bd114-182">This is the equivalent in C++/WinRT.</span></span>

```cppwinrt
myButton().Click(token);
```

<span data-ttu-id="bd114-183">詳細とオプションについては、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bd114-183">For more info and options, see [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate).</span></span>

## <a name="mapping-ccx-platform-types-to-cwinrt-types"></a><span data-ttu-id="bd114-184">C++/WinRT 型への C++/CX **Platform** 型のマッピング</span><span class="sxs-lookup"><span data-stu-id="bd114-184">Mapping C++/CX **Platform** types to C++/WinRT types</span></span>
<span data-ttu-id="bd114-185">C++/CX は **Platform** 名前空間でいくつかのデータ型を提供します。</span><span class="sxs-lookup"><span data-stu-id="bd114-185">C++/CX provides several data types in the **Platform** namespace.</span></span> <span data-ttu-id="bd114-186">これらの型は標準 C++ ではないため、Windows ランタイム言語拡張機能を有効にしたとき (Visual Studio プロジェクトのプロパティの **[C/C++]** > **[全般]** > **[Windows ランタイム拡張機能の使用]** > **[はい (/ZW)]**) にのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="bd114-186">These types are not standard C++, so you can only use them when you enable Windows Runtime language extensions (Visual Studio project property **C/C++** > **General** > **Consume Windows Runtime Extension** > **Yes (/ZW)**).</span></span> <span data-ttu-id="bd114-187">下の表は、**Platform** 型を C++/WinRT の同等の型に移植するときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="bd114-187">The table below helps you port from **Platform** types to their equivalents in C++/WinRT.</span></span> <span data-ttu-id="bd114-188">完了したら、C++/WinRT は標準 C++ であるため、`/ZW` オプションをオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="bd114-188">Once you've done that, since C++/WinRT is standard C++, you can turn off the `/ZW` option.</span></span>

| <span data-ttu-id="bd114-189">C++/CX</span><span class="sxs-lookup"><span data-stu-id="bd114-189">C++/CX</span></span> | <span data-ttu-id="bd114-190">C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="bd114-190">C++/WinRT</span></span> |
| ---- | ---- |
| **<span data-ttu-id="bd114-191">プラットフォーム: Agile\ ^</span><span class="sxs-lookup"><span data-stu-id="bd114-191">Platform::Agile\^</span></span>** | [**<span data-ttu-id="bd114-192">winrt::agile_ref</span><span class="sxs-lookup"><span data-stu-id="bd114-192">winrt::agile_ref</span></span>**](/uwp/cpp-ref-for-winrt/agile-ref) |
| **<span data-ttu-id="bd114-193">Platform::Exception\^</span><span class="sxs-lookup"><span data-stu-id="bd114-193">Platform::Exception\^</span></span>** | [**<span data-ttu-id="bd114-194">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-194">winrt::hresult_error</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) |
| **<span data-ttu-id="bd114-195">Platform::InvalidArgumentException\^</span><span class="sxs-lookup"><span data-stu-id="bd114-195">Platform::InvalidArgumentException\^</span></span>** | [**<span data-ttu-id="bd114-196">winrt::hresult_invalid_argument</span><span class="sxs-lookup"><span data-stu-id="bd114-196">winrt::hresult_invalid_argument</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) |
| **<span data-ttu-id="bd114-197">Platform::Object\^</span><span class="sxs-lookup"><span data-stu-id="bd114-197">Platform::Object\^</span></span>** | **<span data-ttu-id="bd114-198">winrt::Windows::Foundation::IInspectable</span><span class="sxs-lookup"><span data-stu-id="bd114-198">winrt::Windows::Foundation::IInspectable</span></span>** |
| **<span data-ttu-id="bd114-199">Platform::String\^</span><span class="sxs-lookup"><span data-stu-id="bd114-199">Platform::String\^</span></span>** | [**<span data-ttu-id="bd114-200">winrt::hstring</span><span class="sxs-lookup"><span data-stu-id="bd114-200">winrt::hstring</span></span>**](/uwp/cpp-ref-for-winrt/hstring) |

### <a name="port-platformagile-to-winrtagileref"></a><span data-ttu-id="bd114-201">ポート**プラットフォーム: Agile\ ^** **winrt::agile_ref**する</span><span class="sxs-lookup"><span data-stu-id="bd114-201">Port **Platform::Agile\^** to **winrt::agile_ref**</span></span>
<span data-ttu-id="bd114-202">**プラットフォーム: Agile\ ^** c++ の型/CX が任意のスレッドからアクセスできる Windows ランタイム クラスを表します。</span><span class="sxs-lookup"><span data-stu-id="bd114-202">The **Platform::Agile\^** type in C++/CX represents a Windows Runtime class that can be accessed from any thread.</span></span> <span data-ttu-id="bd114-203">C++/WinRT 相当する[**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref)します。</span><span class="sxs-lookup"><span data-stu-id="bd114-203">The C++/WinRT equivalent is [**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref).</span></span>

<span data-ttu-id="bd114-204">C++/CX で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="bd114-204">In C++/CX.</span></span>

```cpp
Platform::Agile<Windows::UI::Core::CoreWindow> m_window;
```

<span data-ttu-id="bd114-205">C++/WinRT で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="bd114-205">In C++/WinRT.</span></span>

```cppwinrt
winrt::agile_ref<Windows::UI::Core::CoreWindow> m_window;
```

### <a name="port-platformexception-to-winrthresulterror"></a><span data-ttu-id="bd114-206">**Platform::Exception\^** の **winrt::hresult_error** への移植</span><span class="sxs-lookup"><span data-stu-id="bd114-206">Port **Platform::Exception\^** to **winrt::hresult_error**</span></span>
<span data-ttu-id="bd114-207">Windows ランタイム API が S\_OK HRESULT 以外を返すときに、**Platform::Exception\^** 型が C++/CX で生成されます。</span><span class="sxs-lookup"><span data-stu-id="bd114-207">The **Platform::Exception\^** type is produced in C++/CX when a Windows Runtime API returns a non S\_OK HRESULT.</span></span> <span data-ttu-id="bd114-208">C++/WinRT の同等の型は [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) です。</span><span class="sxs-lookup"><span data-stu-id="bd114-208">The C++/WinRT equivalent is [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error).</span></span>

<span data-ttu-id="bd114-209">C++/WinRT に移植するには、**Platform::Exception\^** を使用するすべてのコードを  **winrt::hresult_error** を使用するように変更します。</span><span class="sxs-lookup"><span data-stu-id="bd114-209">To port to C++/WinRT, change all code that uses **Platform::Exception\^** to use **winrt::hresult_error**.</span></span>

<span data-ttu-id="bd114-210">C++/CX で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="bd114-210">In C++/CX.</span></span>

```cpp
catch (Platform::Exception^ ex)
```

<span data-ttu-id="bd114-211">C++/WinRT で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="bd114-211">In C++/WinRT.</span></span>

```cppwinrt
catch (winrt::hresult_error const& ex)
```

<span data-ttu-id="bd114-212">C++/WinRT には、これらの例外クラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="bd114-212">C++/WinRT provides these exception classes.</span></span>

| <span data-ttu-id="bd114-213">例外の型</span><span class="sxs-lookup"><span data-stu-id="bd114-213">Exception type</span></span> | <span data-ttu-id="bd114-214">基本クラス</span><span class="sxs-lookup"><span data-stu-id="bd114-214">Base class</span></span> | <span data-ttu-id="bd114-215">HRESULT</span><span class="sxs-lookup"><span data-stu-id="bd114-215">HRESULT</span></span> |
| ---- | ---- | ---- |
| [**<span data-ttu-id="bd114-216">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-216">winrt::hresult_error</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) | | <span data-ttu-id="bd114-217">[**hresult_error::to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 呼び出し</span><span class="sxs-lookup"><span data-stu-id="bd114-217">call [**hresult_error::to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function)</span></span> |
| [**<span data-ttu-id="bd114-218">winrt::hresult_access_denied</span><span class="sxs-lookup"><span data-stu-id="bd114-218">winrt::hresult_access_denied</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-access-denied) | **<span data-ttu-id="bd114-219">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-219">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-220">E_ACCESSDENIED</span><span class="sxs-lookup"><span data-stu-id="bd114-220">E_ACCESSDENIED</span></span> |
| [**<span data-ttu-id="bd114-221">winrt::hresult_canceled</span><span class="sxs-lookup"><span data-stu-id="bd114-221">winrt::hresult_canceled</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-canceled) | **<span data-ttu-id="bd114-222">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-222">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-223">ERROR_CANCELLED</span><span class="sxs-lookup"><span data-stu-id="bd114-223">ERROR_CANCELLED</span></span> |
| [**<span data-ttu-id="bd114-224">winrt::hresult_changed_state</span><span class="sxs-lookup"><span data-stu-id="bd114-224">winrt::hresult_changed_state</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-changed-state) | **<span data-ttu-id="bd114-225">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-225">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-226">E_CHANGED_STATE</span><span class="sxs-lookup"><span data-stu-id="bd114-226">E_CHANGED_STATE</span></span> |
| [**<span data-ttu-id="bd114-227">winrt::hresult_class_not_available</span><span class="sxs-lookup"><span data-stu-id="bd114-227">winrt::hresult_class_not_available</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-class-not-available) | **<span data-ttu-id="bd114-228">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-228">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-229">CLASS_E_CLASSNOTAVAILABLE</span><span class="sxs-lookup"><span data-stu-id="bd114-229">CLASS_E_CLASSNOTAVAILABLE</span></span> |
| [**<span data-ttu-id="bd114-230">winrt::hresult_illegal_delegate_assignment</span><span class="sxs-lookup"><span data-stu-id="bd114-230">winrt::hresult_illegal_delegate_assignment</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-delegate-assignment) | **<span data-ttu-id="bd114-231">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-231">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-232">E_ILLEGAL_DELEGATE_ASSIGNMENT</span><span class="sxs-lookup"><span data-stu-id="bd114-232">E_ILLEGAL_DELEGATE_ASSIGNMENT</span></span> |
| [**<span data-ttu-id="bd114-233">winrt::hresult_illegal_method_call</span><span class="sxs-lookup"><span data-stu-id="bd114-233">winrt::hresult_illegal_method_call</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-method-call) | **<span data-ttu-id="bd114-234">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-234">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-235">E_ILLEGAL_METHOD_CALL</span><span class="sxs-lookup"><span data-stu-id="bd114-235">E_ILLEGAL_METHOD_CALL</span></span> |
| [**<span data-ttu-id="bd114-236">winrt::hresult_illegal_state_change</span><span class="sxs-lookup"><span data-stu-id="bd114-236">winrt::hresult_illegal_state_change</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-state-change) | **<span data-ttu-id="bd114-237">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-237">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-238">E_ILLEGAL_STATE_CHANGE</span><span class="sxs-lookup"><span data-stu-id="bd114-238">E_ILLEGAL_STATE_CHANGE</span></span> |
| [**<span data-ttu-id="bd114-239">winrt::hresult_invalid_argument</span><span class="sxs-lookup"><span data-stu-id="bd114-239">winrt::hresult_invalid_argument</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) | **<span data-ttu-id="bd114-240">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-240">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-241">E_INVALIDARG</span><span class="sxs-lookup"><span data-stu-id="bd114-241">E_INVALIDARG</span></span> |
| [**<span data-ttu-id="bd114-242">winrt::hresult_no_interface</span><span class="sxs-lookup"><span data-stu-id="bd114-242">winrt::hresult_no_interface</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-no-interface) | **<span data-ttu-id="bd114-243">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-243">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-244">E_NOINTERFACE</span><span class="sxs-lookup"><span data-stu-id="bd114-244">E_NOINTERFACE</span></span> |
| [**<span data-ttu-id="bd114-245">winrt::hresult_not_implemented</span><span class="sxs-lookup"><span data-stu-id="bd114-245">winrt::hresult_not_implemented</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-not-implemented) | **<span data-ttu-id="bd114-246">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-246">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-247">E_NOTIMPL</span><span class="sxs-lookup"><span data-stu-id="bd114-247">E_NOTIMPL</span></span> |
| [**<span data-ttu-id="bd114-248">winrt::hresult_out_of_bounds</span><span class="sxs-lookup"><span data-stu-id="bd114-248">winrt::hresult_out_of_bounds</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-out-of-bounds) | **<span data-ttu-id="bd114-249">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-249">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-250">E_BOUNDS</span><span class="sxs-lookup"><span data-stu-id="bd114-250">E_BOUNDS</span></span> |
| [**<span data-ttu-id="bd114-251">winrt::hresult_wrong_thread</span><span class="sxs-lookup"><span data-stu-id="bd114-251">winrt::hresult_wrong_thread</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-wrong-thread) | **<span data-ttu-id="bd114-252">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="bd114-252">winrt::hresult_error</span></span>** | <span data-ttu-id="bd114-253">RPC_E_WRONG_THREAD</span><span class="sxs-lookup"><span data-stu-id="bd114-253">RPC_E_WRONG_THREAD</span></span> |

<span data-ttu-id="bd114-254">各クラスは (**hresult_error** 基本クラスを介して)、エラーの HRESULT を返す [**to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 関数を指定し、その HRESULT の文字列表現を返す [**message**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrormessage-function) 関数を指定します。</span><span class="sxs-lookup"><span data-stu-id="bd114-254">Note that each class (via the **hresult_error** base class) provides a [**to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) function, which returns the HRESULT of the error, and a [**message**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrormessage-function) function, which returns the string representation of that HRESULT.</span></span>

<span data-ttu-id="bd114-255">C++/CX で例外をスローする例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bd114-255">Here's an example of throwing an exception in C++/CX.</span></span>

```cpp
throw ref new Platform::InvalidArgumentException(L"A valid User is required");
```

<span data-ttu-id="bd114-256">また、C++/WinRT での同等のコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bd114-256">And the equivalent in C++/WinRT.</span></span>

```cppwinrt
throw winrt::hresult_invalid_argument{ L"A valid User is required" };
```

### <a name="port-platformobject-to-winrtwindowsfoundationiinspectable"></a><span data-ttu-id="bd114-257">**Platform::Object\^** の **winrt::Windows::Foundation::IInspectable** への移植</span><span class="sxs-lookup"><span data-stu-id="bd114-257">Port **Platform::Object\^** to **winrt::Windows::Foundation::IInspectable**</span></span>
<span data-ttu-id="bd114-258">すべての C++/WinRT 型と同様に、**winrt::Windows::Foundation::IInspectable** は値の型です。</span><span class="sxs-lookup"><span data-stu-id="bd114-258">Like all C++/WinRT types, **winrt::Windows::Foundation::IInspectable** is a value type.</span></span> <span data-ttu-id="bd114-259">その型の変数を null に初期化する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bd114-259">Here's how you initialize a variable of that type to null.</span></span>

```cppwinrt
winrt::Windows::Foundation::IInspectable var{ nullptr };
```

### <a name="port-platformstring-to-winrthstring"></a><span data-ttu-id="bd114-260">**Platform::String\^** の **winrt::hstring** への移植</span><span class="sxs-lookup"><span data-stu-id="bd114-260">Port **Platform::String\^** to **winrt::hstring**</span></span>
<span data-ttu-id="bd114-261">**Platform::String\^** は Windows ランタイム HSTRING ABI 型と同等です。</span><span class="sxs-lookup"><span data-stu-id="bd114-261">**Platform::String\^** is equivalent to the Windows Runtime HSTRING ABI type.</span></span> <span data-ttu-id="bd114-262">C++/WinRT では、同等の型は [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) です。</span><span class="sxs-lookup"><span data-stu-id="bd114-262">For C++/WinRT, the equivalent is [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring).</span></span> <span data-ttu-id="bd114-263">ただし、C++/WinRT では、**std::wstring** などの C++ 標準ライブラリのワイド文字列型、およびワイド文字列リテラルを使用して Windows ランタイム API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="bd114-263">But with C++/WinRT, you can call Windows Runtime APIs using C++ Standard Library wide string types such as **std::wstring**, and/or wide string literals.</span></span> <span data-ttu-id="bd114-264">詳細とコード例については、「[[C++/WinRT での文字列の処理](strings.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bd114-264">For more details, and code examples, see [String handling in C++/WinRT](strings.md).</span></span>

<span data-ttu-id="bd114-265">C++/CX では、[**Platform::String::Data**](https://docs.microsoft.com/en-us/cpp/cppcx/platform-string-class#data) プロパティにアクセスして、C スタイルの **const wchar_t\*** 配列 (たとえば、それを **std::wcout** に渡すために) として文字列を取得できます。</span><span class="sxs-lookup"><span data-stu-id="bd114-265">With C++/CX, you can access the [**Platform::String::Data**](https://docs.microsoft.com/en-us/cpp/cppcx/platform-string-class#data) property to retrieve the string as a C-style **const wchar_t\*** array (for example, to pass it to **std::wcout**).</span></span>

```C++
auto var = titleRecord->TitleName->Data();
```

<span data-ttu-id="bd114-266">C++/WinRT で同じ操作を行うには、[**hstring::c_str**](/uwp/api/windows.foundation.uri#hstringcstr-function) 関数を使用して null で終了する C スタイルの文字列バージョンを取得します。これは **std::wstring** から取得する場合と同様です。</span><span class="sxs-lookup"><span data-stu-id="bd114-266">To do the same with C++/WinRT, you can use the [**hstring::c_str**](/uwp/api/windows.foundation.uri#hstringcstr-function) function to get a null-terminated C-style string version, just as you can from **std::wstring**.</span></span>

```C++
auto var = titleRecord.TitleName().c_str();
```

<span data-ttu-id="bd114-267">文字列を取るか、文字列を返す API の実装に関しては、通常、**Platform::String\^** を使用する C++/CX コードを変更して、代わりに **winrt::hstring** を使用します。</span><span class="sxs-lookup"><span data-stu-id="bd114-267">When it comes to implementing APIs that take or return strings, you typically change any C++/CX code that uses **Platform::String\^** to use **winrt::hstring** instead.</span></span>

<span data-ttu-id="bd114-268">文字列を取る C++/CX API の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bd114-268">Here's an example of a C++/CX API that takes a string.</span></span>

```cpp
void LogWrapLine(Platform::String^ str);
```

<span data-ttu-id="bd114-269">C++/WinRT では、次のようにその API を [MIDL 3.0](/uwp/midl-3) で宣言できます。</span><span class="sxs-lookup"><span data-stu-id="bd114-269">For C++/WinRT you could declare that API in [MIDL 3.0](/uwp/midl-3) like this.</span></span>

```idl
// LogType.idl
void LogWrapLine(String str);
```

<span data-ttu-id="bd114-270">次に C++/WinRT ツール チェーンは次のようなソース コードを生成します。</span><span class="sxs-lookup"><span data-stu-id="bd114-270">The C++/WinRT toolchain will then generate source code for you that looks like this.</span></span>

```cppwinrt
void LogWrapLine(winrt::hstring const& str);
```

## <a name="important-apis"></a><span data-ttu-id="bd114-271">重要な API</span><span class="sxs-lookup"><span data-stu-id="bd114-271">Important APIs</span></span>
* [<span data-ttu-id="bd114-272">winrt::delegate 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="bd114-272">winrt::delegate struct template</span></span>](/uwp/cpp-ref-for-winrt/delegate)
* [<span data-ttu-id="bd114-273">winrt::hresult_error 構造体</span><span class="sxs-lookup"><span data-stu-id="bd114-273">winrt::hresult_error struct</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)
* [<span data-ttu-id="bd114-274">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="bd114-274">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="bd114-275">winrt 名前空間</span><span class="sxs-lookup"><span data-stu-id="bd114-275">winrt namespace</span></span>](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a><span data-ttu-id="bd114-276">関連トピック</span><span class="sxs-lookup"><span data-stu-id="bd114-276">Related topics</span></span>
* [<span data-ttu-id="bd114-277">C++/CX</span><span class="sxs-lookup"><span data-stu-id="bd114-277">C++/CX</span></span>](/cpp/cppcx/visual-c-language-reference-c-cx)
* [<span data-ttu-id="bd114-278">C++/WinRT でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="bd114-278">Author events in C++/WinRT</span></span>](author-events.md)
* [<span data-ttu-id="bd114-279">C++/WinRT を使用した同時実行操作と非同期操作</span><span class="sxs-lookup"><span data-stu-id="bd114-279">Concurrency and asynchronous operations with C++/WinRT</span></span>](concurrency.md)
* [<span data-ttu-id="bd114-280">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="bd114-280">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="bd114-281">C++/WinRT でのデリゲートを使用したイベントの処理</span><span class="sxs-lookup"><span data-stu-id="bd114-281">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
* [<span data-ttu-id="bd114-282">C++/WinRT と C++/CX 間の相互運用</span><span class="sxs-lookup"><span data-stu-id="bd114-282">Interop between C++/WinRT and C++/CX</span></span>](interop-winrt-cx.md)
* [<span data-ttu-id="bd114-283">Microsoft インターフェイス定義言語 3.0 リファレンス</span><span class="sxs-lookup"><span data-stu-id="bd114-283">Microsoft Interface Definition Language 3.0 reference</span></span>](/uwp/midl-3)
* [<span data-ttu-id="bd114-284">WRL から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="bd114-284">Move to C++/WinRT from WRL</span></span>](move-to-winrt-from-wrl.md)
* [<span data-ttu-id="bd114-285">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="bd114-285">String handling in C++/WinRT</span></span>](strings.md)
