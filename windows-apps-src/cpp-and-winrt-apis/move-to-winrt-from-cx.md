---
author: stevewhims
description: このトピックでは、C++/CX コードを C++/WinRT の同等のコードに移植する方法について説明します。
title: C++/CX から C++/WinRT への移行
ms.author: stwhi
ms.date: 07/20/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, C++/CX
ms.localizationpriority: medium
ms.openlocfilehash: 68a631153c104f14f22839077c4c62d34626ed2a
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4575201"
---
# <a name="move-to-cwinrt-from-ccx"></a><span data-ttu-id="a3264-104">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="a3264-104">Move to C++/WinRT from C++/CX</span></span>

<span data-ttu-id="a3264-105">このトピックでは、移植する方法を示しています。 [、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx) 、それに対応するコードを[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="a3264-105">This topic shows how to port [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) code to its equivalent in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a3264-106">段階的に移植する場合、 [、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx)を C++ コード//winrt では、そのことができます。</span><span class="sxs-lookup"><span data-stu-id="a3264-106">If you want to gradually port your [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) code to C++/WinRT, then you can.</span></span> <span data-ttu-id="a3264-107">C++/cli/CX と C++/WinRT コードに XAML コンパイラ サポート、および Windows ランタイム コンポーネントを除いて、同じプロジェクトに共存することができます。</span><span class="sxs-lookup"><span data-stu-id="a3264-107">C++/CX and C++/WinRT code can coexist in the same project, with the exception of XAML compiler support, and Windows Runtime Components.</span></span> <span data-ttu-id="a3264-108">これらの例外が必要になりますか、C++ をターゲットに//CX または/同じプロジェクト内で WinRT。</span><span class="sxs-lookup"><span data-stu-id="a3264-108">For those exceptions, you'll need to target either C++/CX or C++/WinRT within the same project.</span></span> <span data-ttu-id="a3264-109">移植するには、XAML アプリ外係数のコードを Windows ランタイム コンポーネントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="a3264-109">But you can use a Windows Runtime Component to factor code out of your XAML app as you port it.</span></span> <span data-ttu-id="a3264-110">移動するか、できるだけ多く C + + CX コードをコンポーネントを作成して、C++ を XAML プロジェクトを変更する/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="a3264-110">Either move as much C++/CX code as you can into a component, and then change the XAML project to C++/WinRT.</span></span> <span data-ttu-id="a3264-111">またはそれ以外の場合、C++ と XAML プロジェクトのままに + CX、作成新しい C + + WinRT コンポーネント、C++ の移植を開始し、+/CX コード、XAML プロジェクトからコンポーネントにします。</span><span class="sxs-lookup"><span data-stu-id="a3264-111">Or else leave the XAML project as C++/CX, create a new C++/WinRT component, and begin porting C++/CX code out of the XAML project and into the component.</span></span> <span data-ttu-id="a3264-112">場合もあります C + + と共に c++ コンポーネント プロジェクトを CX/WinRT コンポーネントのプロジェクトで、同じソリューション内でアプリケーション プロジェクトからそれらの両方を参照し、段階的に、他のいずれかから移植します。</span><span class="sxs-lookup"><span data-stu-id="a3264-112">You could also have a C++/CX component project alongside a C++/WinRT component project within the same solution, reference both of them from your application project, and gradually port from one to the other.</span></span>

> [!NOTE]
> <span data-ttu-id="a3264-113">[C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) と Windows SDK の両方で、ルート名前空間 **Windows** で型を宣言します。</span><span class="sxs-lookup"><span data-stu-id="a3264-113">Both [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) and the Windows SDK declare types in the root namespace **Windows**.</span></span> <span data-ttu-id="a3264-114">C++/WinRT に投影された Windows 型は Windows 型と同じ完全修飾名を持ちますが、 C++ **winrt** 名前空間に配置されます。</span><span class="sxs-lookup"><span data-stu-id="a3264-114">A Windows type projected into C++/WinRT has the same fully-qualified name as the Windows type, but it's placed in the C++ **winrt** namespace.</span></span> <span data-ttu-id="a3264-115">これらの異なる名前空間では、独自のペースで C++/CX から C++/WinRT へ移植できます。</span><span class="sxs-lookup"><span data-stu-id="a3264-115">These distinct namespaces let you port from C++/CX to C++/WinRT at your own pace.</span></span>

<span data-ttu-id="a3264-116">C++ プロジェクトの移植の最初の手順は上で説明した例外に注意してください方位、+ を手動で追加すると、C++/winrt は +/winrt サポート (を参照してください[、C++、Visual Studio サポート +/winrt と VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix))。</span><span class="sxs-lookup"><span data-stu-id="a3264-116">Bearing in mind the exceptions mentioned above, the first step in porting a project to C++/WinRT is to manually add C++/WinRT support (see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)).</span></span> <span data-ttu-id="a3264-117">これを行うには、`.vcxproj` ファイルを編集し、`<PropertyGroup Label="Globals">` を見つけ、そのプロパティ グループ内で、プロパティ `<CppWinRTEnabled>true</CppWinRTEnabled>` を設定します。</span><span class="sxs-lookup"><span data-stu-id="a3264-117">To do that, edit your `.vcxproj` file, find `<PropertyGroup Label="Globals">` and, inside that property group, set the property `<CppWinRTEnabled>true</CppWinRTEnabled>`.</span></span> <span data-ttu-id="a3264-118">その変更による 1 つの効果は、C++/CX のサポートがプロジェクトで無効になることです。</span><span class="sxs-lookup"><span data-stu-id="a3264-118">One effect of that change is that support for C++/CX is turned off in the project.</span></span> <span data-ttu-id="a3264-119">C++ でのすべての依存関係オフになりメッセージをビルドする際に役立つ検索 (ポート) のサポートを残すことをお勧め + CX、またはすることがサポートを有効に戻す (プロジェクトのプロパティで**C/C++** \> **一般的な** \> **消費 Windows ランタイム拡張** \> **[はい (/ZW)**)、徐々 にポートとします。</span><span class="sxs-lookup"><span data-stu-id="a3264-119">It's a good idea to leave support turned off so that build messages help you find (and port) all of your dependencies on C++/CX, or you can turn support back on (in project properties, **C/C++** \> **General** \> **Consume Windows Runtime Extension** \> **Yes (/ZW)**), and port gradually.</span></span>

<span data-ttu-id="a3264-120">プロジェクトのプロパティ (**[全般]** \> **[ターゲット プラットフォーム バージョン]**) を 10.0.17134.0 (Windows 10 バージョン 1803) 以上に設定します。</span><span class="sxs-lookup"><span data-stu-id="a3264-120">Set project property **General** \> **Target Platform Version** to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="a3264-121">プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。</span><span class="sxs-lookup"><span data-stu-id="a3264-121">In your precompiled header file (usually `pch.h`), include `winrt/base.h`.</span></span>

```cppwinrt
#include <winrt/base.h>
```

<span data-ttu-id="a3264-122">C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a3264-122">If you include any C++/WinRT projected Windows API headers (for example, `winrt/Windows.Foundation.h`), then you don't need to explicitly include `winrt/base.h` like this because it will be included automatically for you.</span></span>

<span data-ttu-id="a3264-123">プロジェクトで [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) 型も使用している場合は、「[WRL から C++/WinRT への移行](move-to-winrt-from-wrl.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a3264-123">If your project is also using [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) types, then see [Move to C++/WinRT from WRL](move-to-winrt-from-wrl.md).</span></span>

## <a name="parameter-passing"></a><span data-ttu-id="a3264-124">パラメーターの引き渡し</span><span class="sxs-lookup"><span data-stu-id="a3264-124">Parameter-passing</span></span>
<span data-ttu-id="a3264-125">C++/CX ソース コードを記述するときに、ハット (\^) が参照する C++/CX 型を関数パラメーターとして渡します。</span><span class="sxs-lookup"><span data-stu-id="a3264-125">When writing C++/CX source code, you pass C++/CX types as function parameters as hat (\^) references.</span></span>

```cpp
void LogPresenceRecord(PresenceRecord^ record);
```

<span data-ttu-id="a3264-126">C++/WinRT では、同期関数に既定で `const&` パラメーターを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a3264-126">In C++/WinRT, for synchronous functions, you should use `const&` parameters by default.</span></span> <span data-ttu-id="a3264-127">これにより、コピーとインター ロック オーバーヘッドが回避されます。</span><span class="sxs-lookup"><span data-stu-id="a3264-127">That will avoid copies and interlocked overhead.</span></span> <span data-ttu-id="a3264-128">ただし、コルーチンが値による呼び出しをして有効期間の問題を回避するように、値渡しを使用する必要があります (詳細については、「[C++/WinRT を使用した同時実行と非同期操作](concurrency.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="a3264-128">But your coroutines should use pass-by-value to ensure that they capture by value and avoid lifetime issues (for more details, see [Concurrency and asynchronous operations with C++/WinRT](concurrency.md)).</span></span>

```cppwinrt
void LogPresenceRecord(PresenceRecord const& record);
IASyncAction LogPresenceRecordAsync(PresenceRecord const record);
```

<span data-ttu-id="a3264-129">C++/WinRT オブジェクトは、基本的に Windows ランタイムのバッキング オブジェクトへのインターフェイス ポインターを保持する値です。</span><span class="sxs-lookup"><span data-stu-id="a3264-129">A C++/WinRT object is fundamentally a value that holds an interface pointer to the backing Windows Runtime object.</span></span> <span data-ttu-id="a3264-130">C++/WinRT オブジェクトをコピーすると、コンパイラはカプセル化されたインターフェイス ポインターをコピーし、その参照カウントをインクリメントします。</span><span class="sxs-lookup"><span data-stu-id="a3264-130">When you copy a C++/WinRT object, the compiler copies the encapsulated interface pointer, incrementing its reference count.</span></span> <span data-ttu-id="a3264-131">コピーの最終的なデストラクションには、参照カウントのデクリメントも含まれます。</span><span class="sxs-lookup"><span data-stu-id="a3264-131">Eventual destruction of the copy involves decrementing the reference count.</span></span> <span data-ttu-id="a3264-132">そのため、必要な場合にのみ、コピーのオーバーヘッドが発生します。</span><span class="sxs-lookup"><span data-stu-id="a3264-132">So, only incur the overhead of a copy when necessary.</span></span>

## <a name="variable-and-field-references"></a><span data-ttu-id="a3264-133">変数とフィールドの参照</span><span class="sxs-lookup"><span data-stu-id="a3264-133">Variable and field references</span></span>
<span data-ttu-id="a3264-134">C++/CX ソース コードを記述するときに、ハット (\^) 変数を使用して Windows ランタイム オブジェクトを参照し、矢印 (-&gt;) 演算子を使用してハット変数を逆参照します。</span><span class="sxs-lookup"><span data-stu-id="a3264-134">When writing C++/CX source code, you use hat (\^) variables to reference Windows Runtime objects, and the arrow (-&gt;) operator to dereference a hat variable.</span></span>

```cpp
IVectorView<User^>^ userList = User::Users;

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList->Size; ++iUser)
    ...
```

<span data-ttu-id="a3264-135">同等の C++ + に移植するとき/WinRT コードでは、基本的には、ハットを削除し、矢印演算子を変更する (-&gt;) ドット演算子 (.) にため、C++//winrt の投影された型は値、およびポインターではありません。</span><span class="sxs-lookup"><span data-stu-id="a3264-135">When porting to the equivalent C++/WinRT code, you basically remove the hats and change the arrow operator (-&gt;) to the dot operator (.), because C++/WinRT projected types are values, and not pointers.</span></span>

```cppwinrt
IVectorView<User> userList = User::Users();

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList.Size(); ++iUser)
    ...
```

## <a name="properties"></a><span data-ttu-id="a3264-136">プロパティ</span><span class="sxs-lookup"><span data-stu-id="a3264-136">Properties</span></span>
<span data-ttu-id="a3264-137">C++/CX 言語拡張機能には、プロパティの概念が含まれています。</span><span class="sxs-lookup"><span data-stu-id="a3264-137">The C++/CX language extensions include the concept of properties.</span></span> <span data-ttu-id="a3264-138">C++/CX ソース コードを記述するときに、フィールドと同様にプロパティにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a3264-138">When writing C++/CX source code, you can access a property as if it were a field.</span></span> <span data-ttu-id="a3264-139">標準 C++ にはプロパティの概念がないため、C++/WinRT では、Get 関数と Set 関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a3264-139">Standard C++ does not have the concept of a property so, in C++/WinRT, you call get and set functions.</span></span>

<span data-ttu-id="a3264-140">次の例では、**XboxUserId**、**UserState**、**PresenceDeviceRecords**、**Size** はすべてプロパティです。</span><span class="sxs-lookup"><span data-stu-id="a3264-140">In the examples that follow, **XboxUserId**, **UserState**, **PresenceDeviceRecords**, and **Size** are all properties.</span></span>

### <a name="retrieving-a-value-from-a-property"></a><span data-ttu-id="a3264-141">プロパティからの値の取得</span><span class="sxs-lookup"><span data-stu-id="a3264-141">Retrieving a value from a property</span></span>
<span data-ttu-id="a3264-142">C++/CX でプロパティの値を取得する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a3264-142">Here's how you get a property value in C++/CX.</span></span>

```cpp
void Sample::LogPresenceRecord(PresenceRecord^ record)
{
    auto id = record->XboxUserId;
    auto state = record->UserState;
    auto size = record->PresenceDeviceRecords->Size;
}
```

<span data-ttu-id="a3264-143">同等の C++/WinRT ソース コードは、プロパティと同じ名前を持ち、パラメーターのない関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a3264-143">The equivalent C++/WinRT source code calls a function with the same name as the property, but with no parameters.</span></span>

```cppwinrt
void Sample::LogPresenceRecord(PresenceRecord const& record)
{
    auto id = record.XboxUserId();
    auto state = record.UserState();
    auto size = record.PresenceDeviceRecords().Size();
}
```

<span data-ttu-id="a3264-144">**PresenceDeviceRecords** 関数は、それ自体が **Size** 関数を持つ Windows ランタイム オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="a3264-144">Note that the **PresenceDeviceRecords** function returns a Windows Runtime object that itself has a **Size** function.</span></span> <span data-ttu-id="a3264-145">返されたオブジェクトは C++/WinRT の投影された型でもあるため、ドット演算子を使用して逆参照し、**Size** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a3264-145">As the returned object is also a C++/WinRT projected type, we dereference using the dot operator to call **Size**.</span></span>

### <a name="setting-a-property-to-a-new-value"></a><span data-ttu-id="a3264-146">新しい値へのプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="a3264-146">Setting a property to a new value</span></span>
<span data-ttu-id="a3264-147">新しい値にプロパティを設定するには、同様のパターンに従います。</span><span class="sxs-lookup"><span data-stu-id="a3264-147">Setting a property to a new value follows a similar pattern.</span></span> <span data-ttu-id="a3264-148">まず、C++/CX で次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="a3264-148">First, in C++/CX.</span></span>

```cpp
record->UserState = newValue;
```

<span data-ttu-id="a3264-149">C++/WinRT で対応する操作を行うには、プロパティと同じ名前の関数を呼び出し、引数を渡します。</span><span class="sxs-lookup"><span data-stu-id="a3264-149">To do the equivalent in C++/WinRT, you call a function with the same name as the property, and pass an argument.</span></span>

```cppwinrt
record.UserState(newValue);
```

## <a name="creating-an-instance-of-a-class"></a><span data-ttu-id="a3264-150">クラスのインスタンスの作成</span><span class="sxs-lookup"><span data-stu-id="a3264-150">Creating an instance of a class</span></span>
<span data-ttu-id="a3264-151">C++/CX オブジェクトは、それに対するハンドル (通常はハット (\^) 参照と呼ばれます) を介して操作します。</span><span class="sxs-lookup"><span data-stu-id="a3264-151">You work with a C++/CX object via a handle to it, commonly known as a hat (\^) reference.</span></span> <span data-ttu-id="a3264-152">`ref new` キーワードにより新しいオブジェクトを作成します。これにより、[**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) が呼び出され、ランタイム クラスの新しいインスタンスがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="a3264-152">You create a new object via the `ref new` keyword, which in turn calls [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) to activate a new instance of the runtime class.</span></span>

```cpp
using namespace Windows::Storage::Streams;

class Sample
{
private:
    Buffer^ m_gamerPicBuffer = ref new Buffer(MAX_IMAGE_SIZE);
};
```

<span data-ttu-id="a3264-153">C++/WinRT オブジェクトは値であるため、スタックに割り当てるか、オブジェクトのフィールドとして割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="a3264-153">A C++/WinRT object is a value; so you can allocate it on the stack, or as a field of an object.</span></span> <span data-ttu-id="a3264-154">C++/WinRT オブジェクトを割り当てるために、`ref new` (または `new`) は使用*しません*。</span><span class="sxs-lookup"><span data-stu-id="a3264-154">You *never* use `ref new` (nor `new`) to allocate a C++/WinRT object.</span></span> <span data-ttu-id="a3264-155">バックグラウンドで **RoActivateInstance** は引き続き呼び出されています。</span><span class="sxs-lookup"><span data-stu-id="a3264-155">Behind the scenes, **RoActivateInstance** is still being called.</span></span>

```cppwinrt
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
private:
    Buffer m_gamerPicBuffer{ MAX_IMAGE_SIZE };
};
```

<span data-ttu-id="a3264-156">リソースを初期化するコストが高い場合は、実際に必要になるまで初期化を遅延するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="a3264-156">If a resource is expensive to initialize, then it's common to delay initialization of it until it's actually needed.</span></span>

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

<span data-ttu-id="a3264-157">同じコードが C++/WinRT に移植されました。</span><span class="sxs-lookup"><span data-stu-id="a3264-157">The same code ported to C++/WinRT.</span></span> <span data-ttu-id="a3264-158">`nullptr` コンストラクターを使っていることに注目してください。</span><span class="sxs-lookup"><span data-stu-id="a3264-158">Note the use of the `nullptr` constructor.</span></span> <span data-ttu-id="a3264-159">コンストラクターの詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a3264-159">For more info about that constructor, see [Consume APIs with C++/WinRT](consume-apis.md).</span></span>

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

## <a name="converting-from-a-base-runtime-class-to-a-derived-one"></a><span data-ttu-id="a3264-160">基本のランタイム クラスから派生した 1 つに変換します。</span><span class="sxs-lookup"><span data-stu-id="a3264-160">Converting from a base runtime class to a derived one</span></span>
<span data-ttu-id="a3264-161">参照から基本派生型のオブジェクトを参照することがわかっているが一般的です。</span><span class="sxs-lookup"><span data-stu-id="a3264-161">It's common to have a reference-to-base that you know refers to an object of a derived type.</span></span> <span data-ttu-id="a3264-162">C + +/CX を使用する`dynamic_cast`に*キャスト*ベースに参照を参照する-派生にします。</span><span class="sxs-lookup"><span data-stu-id="a3264-162">In C++/CX, you use `dynamic_cast` to *cast* the reference-to-base into a reference-to-derived.</span></span> <span data-ttu-id="a3264-163">`dynamic_cast` [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521)するために非表示の呼び出しにすぎません。</span><span class="sxs-lookup"><span data-stu-id="a3264-163">The `dynamic_cast` is really just a hidden call to [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521).</span></span> <span data-ttu-id="a3264-164">典型的な例を次に示します&mdash;、依存関係プロパティの変更イベントを処理して、 **DependencyObject**から依存関係プロパティを所有している実際の型にキャストします。</span><span class="sxs-lookup"><span data-stu-id="a3264-164">Here's a typical example&mdash;you're handling a dependency property changed event, and you want to cast from **DependencyObject** back to the actual type that owns the dependency property.</span></span>

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

<span data-ttu-id="a3264-165">同等の C + +/winrt コードを置き換えます、`dynamic_cast`カプセル化**QueryInterface** [**iunknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)関数を呼び出して、します。</span><span class="sxs-lookup"><span data-stu-id="a3264-165">The equivalent C++/WinRT code replaces the `dynamic_cast` with a call to the [**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function) function, which encapsulates **QueryInterface**.</span></span> <span data-ttu-id="a3264-166">必要なインターフェイス (要求している種類の既定のインターフェイス) の照会が返されない場合、例外をスローする代わりに、 [**iunknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)を呼び出してオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="a3264-166">You also have the option to call [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function), instead, which throws an exception if querying for the required interface (the default interface of the type you're requesting) is not returned.</span></span> <span data-ttu-id="a3264-167">ここでは、C++/WinRT のコード例です。</span><span class="sxs-lookup"><span data-stu-id="a3264-167">Here's a C++/WinRT code example.</span></span>

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

## <a name="event-handling-with-a-delegate"></a><span data-ttu-id="a3264-168">デリゲートを使用したイベント処理</span><span class="sxs-lookup"><span data-stu-id="a3264-168">Event-handling with a delegate</span></span>
<span data-ttu-id="a3264-169">この場合はデリゲートとしてラムダ関数を使用して、C++/CX でイベントを処理する典型的な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a3264-169">Here's a typical example of handling an event in C++/CX, using a lambda function as a delegate in this case.</span></span>

```cpp
auto token = myButton->Click += ref new RoutedEventHandler([&](Platform::Object^ sender, RoutedEventArgs^ args)
{
    // Handle the event.
});
```

<span data-ttu-id="a3264-170">C++/WinRT で対応するコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a3264-170">This is the equivalent in C++/WinRT.</span></span>

```cppwinrt
auto token = myButton().Click([&](IInspectable const& sender, RoutedEventArgs const& args)
{
    // Handle the event.
});
```

<span data-ttu-id="a3264-171">ラムダ関数の代わりに、デリゲートを自由関数として実装するか、またはメンバー関数へのポインターとして実装するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="a3264-171">Instead of a lambda function, you can choose to implement your delegate as a free function, or as a pointer-to-member-function.</span></span> <span data-ttu-id="a3264-172">詳細については、「[C++/WinRT でのデリゲートを使用したイベントの処理](handle-events.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a3264-172">For more info, see [Handle events by using delegates in C++/WinRT](handle-events.md).</span></span>

<span data-ttu-id="a3264-173">イベントとデリゲートが内部的に使用される C++/CX コードベース (バイナリではなく) から移植する場合は、[**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) を使用すると、C++/WinRT でそのパターンを複製できます。</span><span class="sxs-lookup"><span data-stu-id="a3264-173">If you're porting from a C++/CX codebase where events and delegates are used internally (not across binaries), then [**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) will help you to replicate that pattern in C++/WinRT.</span></span> <span data-ttu-id="a3264-174">[パラメーター化されたデリゲート、シンプルな信号は、プロジェクト内でコールバック](author-events.md#parameterized-delegates-simple-signals-and-callbacks-within-a-project)」も参照してください。</span><span class="sxs-lookup"><span data-stu-id="a3264-174">Also see [Parameterized delegates, simple signals, and callbacks within a project](author-events.md#parameterized-delegates-simple-signals-and-callbacks-within-a-project).</span></span>

## <a name="revoking-a-delegate"></a><span data-ttu-id="a3264-175">デリゲートの取り消し</span><span class="sxs-lookup"><span data-stu-id="a3264-175">Revoking a delegate</span></span>
<span data-ttu-id="a3264-176">C++/CX では、`-=` 演算子を使用して前のイベント登録を取り消します。</span><span class="sxs-lookup"><span data-stu-id="a3264-176">In C++/CX you use the `-=` operator to revoke a prior event registration.</span></span>

```cpp
myButton->Click -= token;
```

<span data-ttu-id="a3264-177">C++/WinRT で対応するコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a3264-177">This is the equivalent in C++/WinRT.</span></span>

```cppwinrt
myButton().Click(token);
```

<span data-ttu-id="a3264-178">詳細とオプションについては、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a3264-178">For more info and options, see [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate).</span></span>

## <a name="mapping-ccx-platform-types-to-cwinrt-types"></a><span data-ttu-id="a3264-179">C++/WinRT 型への C++/CX **Platform** 型のマッピング</span><span class="sxs-lookup"><span data-stu-id="a3264-179">Mapping C++/CX **Platform** types to C++/WinRT types</span></span>
<span data-ttu-id="a3264-180">C++/CX は **Platform** 名前空間でいくつかのデータ型を提供します。</span><span class="sxs-lookup"><span data-stu-id="a3264-180">C++/CX provides several data types in the **Platform** namespace.</span></span> <span data-ttu-id="a3264-181">これらの型は標準 C++ ではないため、Windows ランタイム言語拡張機能を有効にしたとき (Visual Studio プロジェクトのプロパティの **[C/C++]** > **[全般]** > **[Windows ランタイム拡張機能の使用]** > **[はい (/ZW)]**) にのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="a3264-181">These types are not standard C++, so you can only use them when you enable Windows Runtime language extensions (Visual Studio project property **C/C++** > **General** > **Consume Windows Runtime Extension** > **Yes (/ZW)**).</span></span> <span data-ttu-id="a3264-182">下の表は、**Platform** 型を C++/WinRT の同等の型に移植するときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a3264-182">The table below helps you port from **Platform** types to their equivalents in C++/WinRT.</span></span> <span data-ttu-id="a3264-183">完了したら、C++/WinRT は標準 C++ であるため、`/ZW` オプションをオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="a3264-183">Once you've done that, since C++/WinRT is standard C++, you can turn off the `/ZW` option.</span></span>

| <span data-ttu-id="a3264-184">C++/CX</span><span class="sxs-lookup"><span data-stu-id="a3264-184">C++/CX</span></span> | <span data-ttu-id="a3264-185">C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="a3264-185">C++/WinRT</span></span> |
| ---- | ---- |
| **<span data-ttu-id="a3264-186">プラットフォーム: Agile\ ^</span><span class="sxs-lookup"><span data-stu-id="a3264-186">Platform::Agile\^</span></span>** | [**<span data-ttu-id="a3264-187">winrt::agile_ref</span><span class="sxs-lookup"><span data-stu-id="a3264-187">winrt::agile_ref</span></span>**](/uwp/cpp-ref-for-winrt/agile-ref) |
| **<span data-ttu-id="a3264-188">Platform::Exception\^</span><span class="sxs-lookup"><span data-stu-id="a3264-188">Platform::Exception\^</span></span>** | [**<span data-ttu-id="a3264-189">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-189">winrt::hresult_error</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) |
| **<span data-ttu-id="a3264-190">Platform::InvalidArgumentException\^</span><span class="sxs-lookup"><span data-stu-id="a3264-190">Platform::InvalidArgumentException\^</span></span>** | [**<span data-ttu-id="a3264-191">winrt::hresult_invalid_argument</span><span class="sxs-lookup"><span data-stu-id="a3264-191">winrt::hresult_invalid_argument</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) |
| **<span data-ttu-id="a3264-192">Platform::Object\^</span><span class="sxs-lookup"><span data-stu-id="a3264-192">Platform::Object\^</span></span>** | **<span data-ttu-id="a3264-193">winrt::Windows::Foundation::IInspectable</span><span class="sxs-lookup"><span data-stu-id="a3264-193">winrt::Windows::Foundation::IInspectable</span></span>** |
| **<span data-ttu-id="a3264-194">Platform::String\^</span><span class="sxs-lookup"><span data-stu-id="a3264-194">Platform::String\^</span></span>** | [**<span data-ttu-id="a3264-195">winrt::hstring</span><span class="sxs-lookup"><span data-stu-id="a3264-195">winrt::hstring</span></span>**](/uwp/cpp-ref-for-winrt/hstring) |

### <a name="port-platformagile-to-winrtagileref"></a><span data-ttu-id="a3264-196">ポート**プラットフォーム: Agile\ ^** **winrt::agile_ref**する</span><span class="sxs-lookup"><span data-stu-id="a3264-196">Port **Platform::Agile\^** to **winrt::agile_ref**</span></span>
<span data-ttu-id="a3264-197">**プラットフォーム: Agile\ ^** 、C++ の型/CX が任意のスレッドからアクセスできる Windows ランタイム クラスを表します。</span><span class="sxs-lookup"><span data-stu-id="a3264-197">The **Platform::Agile\^** type in C++/CX represents a Windows Runtime class that can be accessed from any thread.</span></span> <span data-ttu-id="a3264-198">C++/ [**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref)は WinRT に相当します。</span><span class="sxs-lookup"><span data-stu-id="a3264-198">The C++/WinRT equivalent is [**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref).</span></span>

<span data-ttu-id="a3264-199">C++/CX で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="a3264-199">In C++/CX.</span></span>

```cpp
Platform::Agile<Windows::UI::Core::CoreWindow> m_window;
```

<span data-ttu-id="a3264-200">C++/WinRT で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="a3264-200">In C++/WinRT.</span></span>

```cppwinrt
winrt::agile_ref<Windows::UI::Core::CoreWindow> m_window;
```

### <a name="port-platformexception-to-winrthresulterror"></a><span data-ttu-id="a3264-201">**Platform::Exception\^** の **winrt::hresult_error** への移植</span><span class="sxs-lookup"><span data-stu-id="a3264-201">Port **Platform::Exception\^** to **winrt::hresult_error**</span></span>
<span data-ttu-id="a3264-202">Windows ランタイム API が S\_OK HRESULT 以外を返すときに、**Platform::Exception\^** 型が C++/CX で生成されます。</span><span class="sxs-lookup"><span data-stu-id="a3264-202">The **Platform::Exception\^** type is produced in C++/CX when a Windows Runtime API returns a non S\_OK HRESULT.</span></span> <span data-ttu-id="a3264-203">C++/WinRT の同等の型は [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) です。</span><span class="sxs-lookup"><span data-stu-id="a3264-203">The C++/WinRT equivalent is [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error).</span></span>

<span data-ttu-id="a3264-204">C++/WinRT に移植するには、**Platform::Exception\^** を使用するすべてのコードを  **winrt::hresult_error** を使用するように変更します。</span><span class="sxs-lookup"><span data-stu-id="a3264-204">To port to C++/WinRT, change all code that uses **Platform::Exception\^** to use **winrt::hresult_error**.</span></span>

<span data-ttu-id="a3264-205">C++/CX で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="a3264-205">In C++/CX.</span></span>

```cpp
catch (Platform::Exception^ ex)
```

<span data-ttu-id="a3264-206">C++/WinRT で、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="a3264-206">In C++/WinRT.</span></span>

```cppwinrt
catch (winrt::hresult_error const& ex)
```

<span data-ttu-id="a3264-207">C++/WinRT には、これらの例外クラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="a3264-207">C++/WinRT provides these exception classes.</span></span>

| <span data-ttu-id="a3264-208">例外の型</span><span class="sxs-lookup"><span data-stu-id="a3264-208">Exception type</span></span> | <span data-ttu-id="a3264-209">基本クラス</span><span class="sxs-lookup"><span data-stu-id="a3264-209">Base class</span></span> | <span data-ttu-id="a3264-210">HRESULT</span><span class="sxs-lookup"><span data-stu-id="a3264-210">HRESULT</span></span> |
| ---- | ---- | ---- |
| [**<span data-ttu-id="a3264-211">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-211">winrt::hresult_error</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) | | <span data-ttu-id="a3264-212">[**hresult_error::to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 呼び出し</span><span class="sxs-lookup"><span data-stu-id="a3264-212">call [**hresult_error::to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function)</span></span> |
| [**<span data-ttu-id="a3264-213">winrt::hresult_access_denied</span><span class="sxs-lookup"><span data-stu-id="a3264-213">winrt::hresult_access_denied</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-access-denied) | **<span data-ttu-id="a3264-214">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-214">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-215">E_ACCESSDENIED</span><span class="sxs-lookup"><span data-stu-id="a3264-215">E_ACCESSDENIED</span></span> |
| [**<span data-ttu-id="a3264-216">winrt::hresult_canceled</span><span class="sxs-lookup"><span data-stu-id="a3264-216">winrt::hresult_canceled</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-canceled) | **<span data-ttu-id="a3264-217">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-217">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-218">ERROR_CANCELLED</span><span class="sxs-lookup"><span data-stu-id="a3264-218">ERROR_CANCELLED</span></span> |
| [**<span data-ttu-id="a3264-219">winrt::hresult_changed_state</span><span class="sxs-lookup"><span data-stu-id="a3264-219">winrt::hresult_changed_state</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-changed-state) | **<span data-ttu-id="a3264-220">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-220">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-221">E_CHANGED_STATE</span><span class="sxs-lookup"><span data-stu-id="a3264-221">E_CHANGED_STATE</span></span> |
| [**<span data-ttu-id="a3264-222">winrt::hresult_class_not_available</span><span class="sxs-lookup"><span data-stu-id="a3264-222">winrt::hresult_class_not_available</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-class-not-available) | **<span data-ttu-id="a3264-223">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-223">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-224">CLASS_E_CLASSNOTAVAILABLE</span><span class="sxs-lookup"><span data-stu-id="a3264-224">CLASS_E_CLASSNOTAVAILABLE</span></span> |
| [**<span data-ttu-id="a3264-225">winrt::hresult_illegal_delegate_assignment</span><span class="sxs-lookup"><span data-stu-id="a3264-225">winrt::hresult_illegal_delegate_assignment</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-delegate-assignment) | **<span data-ttu-id="a3264-226">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-226">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-227">E_ILLEGAL_DELEGATE_ASSIGNMENT</span><span class="sxs-lookup"><span data-stu-id="a3264-227">E_ILLEGAL_DELEGATE_ASSIGNMENT</span></span> |
| [**<span data-ttu-id="a3264-228">winrt::hresult_illegal_method_call</span><span class="sxs-lookup"><span data-stu-id="a3264-228">winrt::hresult_illegal_method_call</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-method-call) | **<span data-ttu-id="a3264-229">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-229">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-230">E_ILLEGAL_METHOD_CALL</span><span class="sxs-lookup"><span data-stu-id="a3264-230">E_ILLEGAL_METHOD_CALL</span></span> |
| [**<span data-ttu-id="a3264-231">winrt::hresult_illegal_state_change</span><span class="sxs-lookup"><span data-stu-id="a3264-231">winrt::hresult_illegal_state_change</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-state-change) | **<span data-ttu-id="a3264-232">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-232">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-233">E_ILLEGAL_STATE_CHANGE</span><span class="sxs-lookup"><span data-stu-id="a3264-233">E_ILLEGAL_STATE_CHANGE</span></span> |
| [**<span data-ttu-id="a3264-234">winrt::hresult_invalid_argument</span><span class="sxs-lookup"><span data-stu-id="a3264-234">winrt::hresult_invalid_argument</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) | **<span data-ttu-id="a3264-235">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-235">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-236">E_INVALIDARG</span><span class="sxs-lookup"><span data-stu-id="a3264-236">E_INVALIDARG</span></span> |
| [**<span data-ttu-id="a3264-237">winrt::hresult_no_interface</span><span class="sxs-lookup"><span data-stu-id="a3264-237">winrt::hresult_no_interface</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-no-interface) | **<span data-ttu-id="a3264-238">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-238">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-239">E_NOINTERFACE</span><span class="sxs-lookup"><span data-stu-id="a3264-239">E_NOINTERFACE</span></span> |
| [**<span data-ttu-id="a3264-240">winrt::hresult_not_implemented</span><span class="sxs-lookup"><span data-stu-id="a3264-240">winrt::hresult_not_implemented</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-not-implemented) | **<span data-ttu-id="a3264-241">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-241">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-242">E_NOTIMPL</span><span class="sxs-lookup"><span data-stu-id="a3264-242">E_NOTIMPL</span></span> |
| [**<span data-ttu-id="a3264-243">winrt::hresult_out_of_bounds</span><span class="sxs-lookup"><span data-stu-id="a3264-243">winrt::hresult_out_of_bounds</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-out-of-bounds) | **<span data-ttu-id="a3264-244">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-244">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-245">E_BOUNDS</span><span class="sxs-lookup"><span data-stu-id="a3264-245">E_BOUNDS</span></span> |
| [**<span data-ttu-id="a3264-246">winrt::hresult_wrong_thread</span><span class="sxs-lookup"><span data-stu-id="a3264-246">winrt::hresult_wrong_thread</span></span>**](/uwp/cpp-ref-for-winrt/error-handling/hresult-wrong-thread) | **<span data-ttu-id="a3264-247">winrt::hresult_error</span><span class="sxs-lookup"><span data-stu-id="a3264-247">winrt::hresult_error</span></span>** | <span data-ttu-id="a3264-248">RPC_E_WRONG_THREAD</span><span class="sxs-lookup"><span data-stu-id="a3264-248">RPC_E_WRONG_THREAD</span></span> |

<span data-ttu-id="a3264-249">各クラスは (**hresult_error** 基本クラスを介して)、エラーの HRESULT を返す [**to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 関数を指定し、その HRESULT の文字列表現を返す [**message**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrormessage-function) 関数を指定します。</span><span class="sxs-lookup"><span data-stu-id="a3264-249">Note that each class (via the **hresult_error** base class) provides a [**to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) function, which returns the HRESULT of the error, and a [**message**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrormessage-function) function, which returns the string representation of that HRESULT.</span></span>

<span data-ttu-id="a3264-250">C++/CX で例外をスローする例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a3264-250">Here's an example of throwing an exception in C++/CX.</span></span>

```cpp
throw ref new Platform::InvalidArgumentException(L"A valid User is required");
```

<span data-ttu-id="a3264-251">また、C++/WinRT での同等のコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a3264-251">And the equivalent in C++/WinRT.</span></span>

```cppwinrt
throw winrt::hresult_invalid_argument{ L"A valid User is required" };
```

### <a name="port-platformobject-to-winrtwindowsfoundationiinspectable"></a><span data-ttu-id="a3264-252">**Platform::Object\^** の **winrt::Windows::Foundation::IInspectable** への移植</span><span class="sxs-lookup"><span data-stu-id="a3264-252">Port **Platform::Object\^** to **winrt::Windows::Foundation::IInspectable**</span></span>
<span data-ttu-id="a3264-253">すべての C++/WinRT 型と同様に、**winrt::Windows::Foundation::IInspectable** は値の型です。</span><span class="sxs-lookup"><span data-stu-id="a3264-253">Like all C++/WinRT types, **winrt::Windows::Foundation::IInspectable** is a value type.</span></span> <span data-ttu-id="a3264-254">その型の変数を null に初期化する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a3264-254">Here's how you initialize a variable of that type to null.</span></span>

```cppwinrt
winrt::Windows::Foundation::IInspectable var{ nullptr };
```

### <a name="port-platformstring-to-winrthstring"></a><span data-ttu-id="a3264-255">**Platform::String\^** の **winrt::hstring** への移植</span><span class="sxs-lookup"><span data-stu-id="a3264-255">Port **Platform::String\^** to **winrt::hstring**</span></span>
<span data-ttu-id="a3264-256">**Platform::String\^** は Windows ランタイム HSTRING ABI 型と同等です。</span><span class="sxs-lookup"><span data-stu-id="a3264-256">**Platform::String\^** is equivalent to the Windows Runtime HSTRING ABI type.</span></span> <span data-ttu-id="a3264-257">C++/WinRT では、同等の型は [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) です。</span><span class="sxs-lookup"><span data-stu-id="a3264-257">For C++/WinRT, the equivalent is [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring).</span></span> <span data-ttu-id="a3264-258">ただし、C++/WinRT では、**std::wstring** などの C++ 標準ライブラリのワイド文字列型、およびワイド文字列リテラルを使用して Windows ランタイム API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="a3264-258">But with C++/WinRT, you can call Windows Runtime APIs using C++ Standard Library wide string types such as **std::wstring**, and/or wide string literals.</span></span> <span data-ttu-id="a3264-259">詳細とコード例については、「[[C++/WinRT での文字列の処理](strings.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a3264-259">For more details, and code examples, see [String handling in C++/WinRT](strings.md).</span></span>

<span data-ttu-id="a3264-260">C++/CX では、[**Platform::String::Data**](https://docs.microsoft.com/en-us/cpp/cppcx/platform-string-class#data) プロパティにアクセスして、C スタイルの **const wchar_t\*** 配列 (たとえば、それを **std::wcout** に渡すために) として文字列を取得できます。</span><span class="sxs-lookup"><span data-stu-id="a3264-260">With C++/CX, you can access the [**Platform::String::Data**](https://docs.microsoft.com/en-us/cpp/cppcx/platform-string-class#data) property to retrieve the string as a C-style **const wchar_t\*** array (for example, to pass it to **std::wcout**).</span></span>

```C++
auto var = titleRecord->TitleName->Data();
```

<span data-ttu-id="a3264-261">C++/WinRT で同じ操作を行うには、[**hstring::c_str**](/uwp/api/windows.foundation.uri#hstringcstr-function) 関数を使用して null で終了する C スタイルの文字列バージョンを取得します。これは **std::wstring** から取得する場合と同様です。</span><span class="sxs-lookup"><span data-stu-id="a3264-261">To do the same with C++/WinRT, you can use the [**hstring::c_str**](/uwp/api/windows.foundation.uri#hstringcstr-function) function to get a null-terminated C-style string version, just as you can from **std::wstring**.</span></span>

```C++
auto var = titleRecord.TitleName().c_str();
```

<span data-ttu-id="a3264-262">文字列を取るか、文字列を返す API の実装に関しては、通常、**Platform::String\^** を使用する C++/CX コードを変更して、代わりに **winrt::hstring** を使用します。</span><span class="sxs-lookup"><span data-stu-id="a3264-262">When it comes to implementing APIs that take or return strings, you typically change any C++/CX code that uses **Platform::String\^** to use **winrt::hstring** instead.</span></span>

<span data-ttu-id="a3264-263">文字列を取る C++/CX API の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a3264-263">Here's an example of a C++/CX API that takes a string.</span></span>

```cpp
void LogWrapLine(Platform::String^ str);
```

<span data-ttu-id="a3264-264">C++/WinRT では、次のようにその API を [MIDL 3.0](/uwp/midl-3) で宣言できます。</span><span class="sxs-lookup"><span data-stu-id="a3264-264">For C++/WinRT you could declare that API in [MIDL 3.0](/uwp/midl-3) like this.</span></span>

```idl
// LogType.idl
void LogWrapLine(String str);
```

<span data-ttu-id="a3264-265">次に C++/WinRT ツール チェーンは次のようなソース コードを生成します。</span><span class="sxs-lookup"><span data-stu-id="a3264-265">The C++/WinRT toolchain will then generate source code for you that looks like this.</span></span>

```cppwinrt
void LogWrapLine(winrt::hstring const& str);
```

## <a name="important-apis"></a><span data-ttu-id="a3264-266">重要な API</span><span class="sxs-lookup"><span data-stu-id="a3264-266">Important APIs</span></span>
* [<span data-ttu-id="a3264-267">winrt::delegate 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="a3264-267">winrt::delegate struct template</span></span>](/uwp/cpp-ref-for-winrt/delegate)
* [<span data-ttu-id="a3264-268">winrt::hresult_error 構造体</span><span class="sxs-lookup"><span data-stu-id="a3264-268">winrt::hresult_error struct</span></span>](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)
* [<span data-ttu-id="a3264-269">winrt::hstring 構造体</span><span class="sxs-lookup"><span data-stu-id="a3264-269">winrt::hstring struct</span></span>](/uwp/cpp-ref-for-winrt/hstring)
* [<span data-ttu-id="a3264-270">winrt 名前空間</span><span class="sxs-lookup"><span data-stu-id="a3264-270">winrt namespace</span></span>](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a><span data-ttu-id="a3264-271">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a3264-271">Related topics</span></span>
* [<span data-ttu-id="a3264-272">C++/CX</span><span class="sxs-lookup"><span data-stu-id="a3264-272">C++/CX</span></span>](/cpp/cppcx/visual-c-language-reference-c-cx)
* [<span data-ttu-id="a3264-273">C++/WinRT でのイベントの作成</span><span class="sxs-lookup"><span data-stu-id="a3264-273">Author events in C++/WinRT</span></span>](author-events.md)
* [<span data-ttu-id="a3264-274">C++/WinRT を使用した同時実行操作と非同期操作</span><span class="sxs-lookup"><span data-stu-id="a3264-274">Concurrency and asynchronous operations with C++/WinRT</span></span>](concurrency.md)
* [<span data-ttu-id="a3264-275">C++/WinRT での API の使用</span><span class="sxs-lookup"><span data-stu-id="a3264-275">Consume APIs with C++/WinRT</span></span>](consume-apis.md)
* [<span data-ttu-id="a3264-276">C++/WinRT でのデリゲートを使用したイベントの処理</span><span class="sxs-lookup"><span data-stu-id="a3264-276">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
* [<span data-ttu-id="a3264-277">Microsoft インターフェイス定義言語 3.0 リファレンス</span><span class="sxs-lookup"><span data-stu-id="a3264-277">Microsoft Interface Definition Language 3.0 reference</span></span>](/uwp/midl-3)
* [<span data-ttu-id="a3264-278">WRL から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="a3264-278">Move to C++/WinRT from WRL</span></span>](move-to-winrt-from-wrl.md)
* [<span data-ttu-id="a3264-279">C++/WinRT での文字列の処理</span><span class="sxs-lookup"><span data-stu-id="a3264-279">String handling in C++/WinRT</span></span>](strings.md)
