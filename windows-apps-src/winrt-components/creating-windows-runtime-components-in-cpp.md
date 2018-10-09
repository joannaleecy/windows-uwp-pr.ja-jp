---
author: msatranjr
title: C++ での Windows ランタイム コンポーネントの作成
description: このトピックでは、C++ を使用する方法を示しています。 + CX コンポーネントは、c#、Visual Basic、C++、または Javascript を使って構築されたユニバーサル Windows アプリから呼び出すことができるのは、Windows ランタイム コンポーネントを作成します。
ms.assetid: F7E06AA2-DCEC-427E-BD5D-9CA2A0ED2612
ms.author: misatran
ms.date: 05/14/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b5515d0ed5dc6e200c7c4fc9a7785c993d4cab59
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4464462"
---
# <a name="creating-windows-runtime-components-in-ccx"></a><span data-ttu-id="5a67a-104">C++/CX での Windows ランタイム コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="5a67a-104">Creating Windows Runtime Components in C++/CX</span></span>
> [!NOTE]
> <span data-ttu-id="5a67a-105">このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-105">This topic exists to help you maintain your C++/CX application.</span></span> <span data-ttu-id="5a67a-106">ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5a67a-106">But we recommend that you use [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) for new applications.</span></span> <span data-ttu-id="5a67a-107">C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-107">C++/WinRT is an entirely standard modern C++17 language projection for Windows Runtime (WinRT) APIs, implemented as a header-file-based library, and designed to provide you with first-class access to the modern Windows API.</span></span> <span data-ttu-id="5a67a-108">使用して、C++ の Windows ランタイム コンポーネントを作成する方法について//winrt を参照してください[、C++ でのイベントの作成/WinRT](../cpp-and-winrt-apis/author-events.md)します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-108">To learn how to create a Windows Runtime Component using C++/WinRT, see [Author events in C++/WinRT](../cpp-and-winrt-apis/author-events.md).</span></span>

<span data-ttu-id="5a67a-109">このトピックでは、C++ を使用する方法を示しています。 + CX コンポーネントは、c#、Visual Basic、C++、または Javascript を使って構築されたユニバーサル Windows アプリから呼び出すことができるのは、Windows ランタイム コンポーネントを作成します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-109">This topic shows how to use C++/CX to create a Windows Runtime component, which is a component that's callable from a Universal Windows app built using C#, Visual Basic, C++, or Javascript.</span></span>

<span data-ttu-id="5a67a-110">Windows ランタイム コンポーネントを構築するためのいくつかの理由があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-110">There are several reasons for building a Windows Runtime component.</span></span>
- <span data-ttu-id="5a67a-111">複雑な操作または負荷の高い操作で C++ のパフォーマンス上のメリットを得る。</span><span class="sxs-lookup"><span data-stu-id="5a67a-111">To get the performance advantage of C++ in complex or computationally intensive operations.</span></span>
- <span data-ttu-id="5a67a-112">既に作成されテストされている既存のコードを再利用する。</span><span class="sxs-lookup"><span data-stu-id="5a67a-112">To reuse code that's already written and tested.</span></span>

<span data-ttu-id="5a67a-113">JavaScript プロジェクトまたは .NET プロジェクト、および Windows ランタイム コンポーネント プロジェクトを含むソリューションを構築すると、JavaScript プロジェクト ファイルとコンパイル済みの DLL が 1 つのパッケージにマージされます。これを、シミュレーターを使ってローカルでデバッグしたり、テザリングされたデバイス上でリモートでデバッグしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-113">When you build a solution that contains a JavaScript or .NET project, and a Windows Runtime component project, the JavaScript project files and the compiled DLL are merged into one package, which you can debug locally in the simulator or remotely on a tethered device.</span></span> <span data-ttu-id="5a67a-114">また、拡張 SDK としてコンポーネント プロジェクトだけを配布することもできます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-114">You can also distribute just the component project as an Extension SDK.</span></span> <span data-ttu-id="5a67a-115">詳しくは、[ソフトウェア開発キットの作成に関するページ](https://msdn.microsoft.com/library/hh768146.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a67a-115">For more information, see [Creating a Software Development Kit](https://msdn.microsoft.com/library/hh768146.aspx).</span></span>

<span data-ttu-id="5a67a-116">一般に、コーディングするとき、C + + CX のコンポーネントを使用して、標準の C++ ライブラリと組み込み型を除く抽象バイナリ インターフェイス (ABI) の境界で他の .winmd パッケージとコードからデータを渡しています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-116">In general, when you code your C++/CX component, use the regular C++ library and built-in types, except at the abstract binary interface (ABI) boundary where you are passing data to and from code in another .winmd package.</span></span> <span data-ttu-id="5a67a-117">Windows ランタイム型と、特別な構文を使用して、C + + CX の作成とそれらの型の操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-117">There, use Windows Runtime types and the special syntax that C++/CX supports for creating and manipulating those types.</span></span> <span data-ttu-id="5a67a-118">さらで c++/cli CX コード, JavaScript、Visual Basic、C++、または c# でのコンポーネントから発生して処理されることができるイベントの実装に delegate や event などの使用の種類。</span><span class="sxs-lookup"><span data-stu-id="5a67a-118">In addition, in your C++/CX code, use types such as delegate and event to implement events that can be raised from your component and handled in JavaScript, Visual Basic, C++, or C#.</span></span> <span data-ttu-id="5a67a-119">C++ の詳細については + CX の構文を参照してください[Visual C 言語のリファレンス (、C++/cli CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-119">For more information about the C++/CX syntax, see [Visual C++ Language Reference (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx).</span></span>

## <a name="casing-and-naming-rules"></a><span data-ttu-id="5a67a-120">大文字小文字の区別と名前付け規則</span><span class="sxs-lookup"><span data-stu-id="5a67a-120">Casing and naming rules</span></span>

### <a name="javascript"></a><span data-ttu-id="5a67a-121">JavaScript の場合</span><span class="sxs-lookup"><span data-stu-id="5a67a-121">JavaScript</span></span>
<span data-ttu-id="5a67a-122">JavaScript では、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-122">JavaScript is case-sensitive.</span></span> <span data-ttu-id="5a67a-123">したがって、次に示す大文字小文字の区別の規則に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-123">Therefore, you must follow these casing conventions:</span></span>

-   <span data-ttu-id="5a67a-124">C++ の名前空間とクラスを参照する場合、C++ の側と同じ大文字小文字の区別を使います。</span><span class="sxs-lookup"><span data-stu-id="5a67a-124">When you reference C++ namespaces and classes, use the same casing that's used on the C++ side.</span></span>
-   <span data-ttu-id="5a67a-125">メソッドを呼び出す場合、メソッド名が C++ の側で大文字になっていても、camel 規約に従った大文字小文字の区別を使います。</span><span class="sxs-lookup"><span data-stu-id="5a67a-125">When you call methods, use camel casing even if the method name is capitalized on the C++ side.</span></span> <span data-ttu-id="5a67a-126">たとえば、C++ のメソッド GetDate() は、JavaScript では getDate() として呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-126">For example, a C++ method GetDate() must be called from JavaScript as getDate().</span></span>
-   <span data-ttu-id="5a67a-127">アクティブ化可能なクラス名や名前空間名には、UNICODE 文字を含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-127">An activatable class name and namespace name can't contain UNICODE characters.</span></span>

### <a name="net"></a><span data-ttu-id="5a67a-128">.NET の場合</span><span class="sxs-lookup"><span data-stu-id="5a67a-128">.NET</span></span>
<span data-ttu-id="5a67a-129">.NET 言語では、各言語の通常の大文字と小文字の規則が適用されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-129">The .NET languages follow their normal casing rules.</span></span>

## <a name="instantiating-the-object"></a><span data-ttu-id="5a67a-130">オブジェクトのインスタンス化</span><span class="sxs-lookup"><span data-stu-id="5a67a-130">Instantiating the object</span></span>
<span data-ttu-id="5a67a-131">Windows ランタイム型のみ ABI の境界を越えて渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-131">Only Windows Runtime types can be passed across the ABI boundary.</span></span> <span data-ttu-id="5a67a-132">コンパイラは、コンポーネントのパブリック メソッドでの戻り値の型または戻り値パラメーターが std::wstring などの型である場合、エラーを発生させます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-132">The compiler will raise an error if the component has a type like std::wstring as a return type or parameter in a public method.</span></span> <span data-ttu-id="5a67a-133">Visual C コンポーネント拡張機能 (、C++/cli CX) 組み込み型は、int、double、およびその typedef int32、float64 などの通常のスカラーし、ようにします。</span><span class="sxs-lookup"><span data-stu-id="5a67a-133">The Visual C++ component extensions (C++/CX) built-in types include the usual scalars such as int and double, and also their typedef equivalents int32, float64, and so on.</span></span> <span data-ttu-id="5a67a-134">詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a67a-134">For more information, see [Type System (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx).</span></span>

```cpp
// ref class definition in C++
public ref class SampleRefClass sealed
{
    // Class members...

    // #include <valarray>
public:
    double LogCalc(double input)
    {
        // Use C++ standard library as usual.
        return std::log(input);
    }

};
```

```javascript
//Instantiation in JavaScript (requires "Add reference > Project reference")
var nativeObject = new CppComponent.SampleRefClass();
```

```csharp
//Call a method and display result in a XAML TextBlock
var num = nativeObject.LogCalc(21.5);
ResultText.Text = num.ToString();
```

## <a name="ccx-built-in-types-library-types-and-windows-runtime-types"></a><span data-ttu-id="5a67a-135">C++/cli CX 組み込み型、ライブラリの型、および Windows ランタイム型</span><span class="sxs-lookup"><span data-stu-id="5a67a-135">C++/CX built-in types, library types, and Windows Runtime types</span></span>
<span data-ttu-id="5a67a-136">アクティブ化可能なクラス (ref クラスとも呼ばれます) は、JavaScript、C#、Visual Basic などの他の言語からインスタンス化できるクラスです。</span><span class="sxs-lookup"><span data-stu-id="5a67a-136">An activatable class (also known as a ref class) is one that can be instantiated from another language such as JavaScript, C# or Visual Basic.</span></span> <span data-ttu-id="5a67a-137">他の言語から利用できるようにするには、コンポーネントに 1 個以上のアクティブ化可能なクラスを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-137">To be consumable from another language, a component must contain at least one activatable class.</span></span>

<span data-ttu-id="5a67a-138">Windows ランタイム コンポーネントには、複数のアクティブ化可能なパブリック クラスだけでなく、コンポーネント内部でのみ認識される他のクラスも含めることができます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-138">A Windows Runtime component can contain multiple public activatable classes as well as additional classes that are known only internally to the component.</span></span> <span data-ttu-id="5a67a-139">C++ [WebHostHidden](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.webhosthiddenattribute.aspx)属性を適用/CX の種類を JavaScript に表示されるものではありません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-139">Apply the [WebHostHidden](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.webhosthiddenattribute.aspx) attribute to C++/CX types that are not intended to be visible to JavaScript.</span></span>

<span data-ttu-id="5a67a-140">すべてのパブリック クラスが、コンポーネントのメタデータ ファイルと同じ名前を持つ同じルート名前空間に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-140">All public classes must reside in the same root namespace which has the same name as the component metadata file.</span></span> <span data-ttu-id="5a67a-141">たとえば、A.B.C.MyClass という名前のクラスは、A.winmd、A.B.winmd、または A.B.C.winmd という名前のメタデータ ファイルで定義されている場合のみインスタンス化できます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-141">For example, a class that's named A.B.C.MyClass can be instantiated only if it's defined in a metadata file that's named A.winmd or A.B.winmd or A.B.C.winmd.</span></span> <span data-ttu-id="5a67a-142">DLL の名前は .winmd ファイルの名前と一致する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-142">The name of the DLL is not required to match the .winmd file name.</span></span>

<span data-ttu-id="5a67a-143">クライアント コードでは、他のクラスと同様に、**new** キーワード (Visual Basic の場合は **New**) を使って、コンポーネントのインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-143">Client code creates an instance of the component by using the **new** (**New** in Visual Basic) keyword just as for any class.</span></span>

<span data-ttu-id="5a67a-144">アクティブ化可能なクラスは **public ref class sealed** として宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-144">An activatable class must be declared as **public ref class sealed**.</span></span> <span data-ttu-id="5a67a-145">**ref class** キーワードは、Windows ランタイムと互換性のある型としてクラスを作成するようにコンパイラに指示し、sealed キーワードは、クラスが継承できないことを指定します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-145">The **ref class** keyword tells the compiler to create the class as a Windows Runtime compatible type, and the sealed keyword specifies that the class cannot be inherited.</span></span> <span data-ttu-id="5a67a-146">現在、Windows ランタイムは汎用の継承モデルをサポートしていません。限定的な継承モデルによって、カスタム XAML コントロールの作成をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-146">The Windows Runtime does not currently support a generalized inheritance model; a limited inheritance model supports creation of custom XAML controls.</span></span> <span data-ttu-id="5a67a-147">詳しくは、「[Ref クラスと構造体 (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699870.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a67a-147">For more information, see [Ref classes and structs (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699870.aspx).</span></span>

<span data-ttu-id="5a67a-148">C++/cli CX、すべてのプリミティブ数値型が既定の名前空間で定義されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-148">For C++/CX, all the numeric primitives are defined in the default namespace.</span></span> <span data-ttu-id="5a67a-149">[Platform](https://msdn.microsoft.com/library/windows/apps/xaml/hh710417.aspx)名前空間を含む、C++/cli CX クラスには、Windows ランタイムの専用システムと入力します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-149">The [Platform](https://msdn.microsoft.com/library/windows/apps/xaml/hh710417.aspx) namespace contains C++/CX classes that are specific to the Windows Runtime type system.</span></span> <span data-ttu-id="5a67a-150">このようなクラスには、[Platform::String](https://msdn.microsoft.com/library/windows/apps/xaml/hh755812.aspx) クラスと [Platform::Object](https://msdn.microsoft.com/library/windows/apps/xaml/hh748265.aspx) クラスがあります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-150">These include [Platform::String](https://msdn.microsoft.com/library/windows/apps/xaml/hh755812.aspx) class and [Platform::Object](https://msdn.microsoft.com/library/windows/apps/xaml/hh748265.aspx) class.</span></span> <span data-ttu-id="5a67a-151">[Platform::Collections::Map](https://msdn.microsoft.com/library/windows/apps/xaml/hh441508.aspx) クラスや [Platform::Collections::Vector](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx) クラスなどの具象コレクション型は、[Platform::Collections](https://msdn.microsoft.com/library/windows/apps/xaml/hh710418.aspx) 名前空間で定義されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-151">The concrete collection types such as [Platform::Collections::Map](https://msdn.microsoft.com/library/windows/apps/xaml/hh441508.aspx) class and [Platform::Collections::Vector](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx) class are defined in the [Platform::Collections](https://msdn.microsoft.com/library/windows/apps/xaml/hh710418.aspx) namespace.</span></span> <span data-ttu-id="5a67a-152">これらの型によって実装されるパブリック インターフェイスは、[Windows::Foundation::Collections 名前空間 (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh441496.aspx) で定義されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-152">The public interfaces that these types implement are defined in [Windows::Foundation::Collections Namespace (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh441496.aspx).</span></span> <span data-ttu-id="5a67a-153">JavaScript、C#、および Visual Basic で利用されるのは、この種類のインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="5a67a-153">It is these interface types that are consumed by JavaScript, C# and Visual Basic.</span></span> <span data-ttu-id="5a67a-154">詳しくは、「[型システム (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a67a-154">For more information, see [Type System (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx).</span></span>

## <a name="method-that-returns-a-value-of-built-in-type"></a><span data-ttu-id="5a67a-155">組み込み型の値を返すメソッド</span><span class="sxs-lookup"><span data-stu-id="5a67a-155">Method that returns a value of built-in type</span></span>
```cpp
    // #include <valarray>
public:
    double LogCalc(double input)
    {
        // Use C++ standard library as usual.
        return std::log(input);
    }
```

```javascript
//Call a method
var nativeObject = new CppComponent.SampleRefClass;
var num = nativeObject.logCalc(21.5);
document.getElementById('P2').innerHTML = num;
```

## <a name="method-that-returns-a-custom-value-struct"></a><span data-ttu-id="5a67a-156">カスタム値の構造体を返すメソッド</span><span class="sxs-lookup"><span data-stu-id="5a67a-156">Method that returns a custom value struct</span></span>
```cpp
namespace CppComponent
{
    // Custom struct
    public value struct PlayerData
    {
        Platform::String^ Name;
        int Number;
        double ScoringAverage;
    };

    public ref class Player sealed
    {
    private:
        PlayerData m_player;
    public:
        property PlayerData PlayerStats
        {
            PlayerData get(){ return m_player; }
            void set(PlayerData data) {m_player = data;}
        }
    };
}
```

<span data-ttu-id="5a67a-157">ユーザー定義の値の境界を越えて渡す ABI に、C++ で定義されている値の構造体と同じメンバーを持つ JavaScript オブジェクトを定義/CX します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-157">To pass user-defined value structs across the ABI, define a JavaScript object that has the same members as the value struct that's defined in C++/CX.</span></span> <span data-ttu-id="5a67a-158">C++ を引数としてそのオブジェクトを渡すことができますし、+ CX メソッド、オブジェクトは c++ を暗黙的に変換できるように + CX の種類。</span><span class="sxs-lookup"><span data-stu-id="5a67a-158">You can then pass that object as an argument to a C++/CX method so that the object is implicitly converted to the C++/CX type.</span></span>

```javascript
// Get and set the value struct
function GetAndSetPlayerData() {
    // Create an object to pass to C++
    var myData =
        { name: "Bob Homer", number: 12, scoringAverage: .357 };
    var nativeObject = new CppComponent.Player();
    nativeObject.playerStats = myData;

    // Retrieve C++ value struct into new JavaScript object
    var myData2 = nativeObject.playerStats;
    document.getElementById('P3').innerHTML = myData.name + " , " + myData.number + " , " + myData.scoringAverage.toPrecision(3);
}
```

<span data-ttu-id="5a67a-159">もう 1 つの方法は、IPropertySet を実装するクラスを定義することです (ここでは例は示されていません)。</span><span class="sxs-lookup"><span data-stu-id="5a67a-159">Another approach is to define a class that implements IPropertySet (not shown).</span></span>

<span data-ttu-id="5a67a-160">.NET 言語でだけを作成する、C++ で定義されている型の変数/CX コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="5a67a-160">In the .NET languages, you just create a variable of the type that's defined in the C++/CX component.</span></span>

```csharp
private void GetAndSetPlayerData()
{
    // Create a ref class
    var player = new CppComponent.Player();

    // Create a variable of a value struct
    // type that is defined in C++
    CppComponent.PlayerData myPlayer;
    myPlayer.Name = "Babe Ruth";
    myPlayer.Number = 12;
    myPlayer.ScoringAverage = .398;

    // Set the property
    player.PlayerStats = myPlayer;

    // Get the property and store it in a new variable
    CppComponent.PlayerData myPlayer2 = player.PlayerStats;
    ResultText.Text += myPlayer.Name + " , " + myPlayer.Number.ToString() +
        " , " + myPlayer.ScoringAverage.ToString();
}
```

## <a name="overloaded-methods"></a><span data-ttu-id="5a67a-161">オーバー ロードされたメソッド</span><span class="sxs-lookup"><span data-stu-id="5a67a-161">Overloaded Methods</span></span>
<span data-ttu-id="5a67a-162">C++/cli CX のパブリック ref クラスは、オーバー ロードされたメソッドを含めることができますが、JavaScript のオーバー ロードされたメソッドを区別する機能が限定されています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-162">A C++/CX public ref class can contain overloaded methods, but JavaScript has limited ability to differentiate overloaded methods.</span></span> <span data-ttu-id="5a67a-163">たとえば、以下のシグネチャの相違を区別できます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-163">For example, it can tell the difference between these signatures:</span></span>

```cpp
public ref class NumberClass sealed
{
public:
    int GetNumber(int i);
    int GetNumber(int i, Platform::String^ str);
    double GetNumber(int i, MyData^ d);
};
```

<span data-ttu-id="5a67a-164">ただし、以下のシグネチャの相違は区別できません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-164">But it can’t tell the difference between these:</span></span>

```cpp
int GetNumber(int i);
double GetNumber(double d);
```

<span data-ttu-id="5a67a-165">あいまいな場合、JavaScript で特定のオーバーロードを常に呼び出すようにすることができます。そのためには、ヘッダー ファイルのメソッド シグネチャに [Windows::Foundation::Metadata::DefaultOverload](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.defaultoverloadattribute.aspx) 属性を適用します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-165">In ambiguous cases, you can ensure that JavaScript always calls a specific overload by applying the [Windows::Foundation::Metadata::DefaultOverload](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.defaultoverloadattribute.aspx) attribute to the method signature in the header file.</span></span>

<span data-ttu-id="5a67a-166">次の JavaScript は、属性付きオーバーロードを常に呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-166">This JavaScript always calls the attributed overload:</span></span>

```javascript
var nativeObject = new CppComponent.NumberClass();
var num = nativeObject.getNumber(9);
document.getElementById('P4').innerHTML = num;
```

## <a name="net"></a><span data-ttu-id="5a67a-167">.NET</span><span class="sxs-lookup"><span data-stu-id="5a67a-167">.NET</span></span>
<span data-ttu-id="5a67a-168">.NET 言語の認識のオーバー ロードを c++/cli .NET Framework クラスの場合と同様の CX ref クラス。</span><span class="sxs-lookup"><span data-stu-id="5a67a-168">The .NET languages recognize overloads in a C++/CX ref class just as in any .NET Framework class.</span></span>

## <a name="datetime"></a><span data-ttu-id="5a67a-169">DateTime</span><span class="sxs-lookup"><span data-stu-id="5a67a-169">DateTime</span></span>
<span data-ttu-id="5a67a-170">Windows ランタイムでは、[Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/windows.foundation.datetime.aspx) オブジェクトは 1601 年 1 月 1 日の前または後の時間の長さを 100 ナノ秒単位で表した単純な 64 ビットの符号付き整数です。</span><span class="sxs-lookup"><span data-stu-id="5a67a-170">In the Windows Runtime, a [Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/windows.foundation.datetime.aspx) object is just a 64-bit signed integer that represents the number of 100-nanosecond intervals either before or after January 1, 1601.</span></span> <span data-ttu-id="5a67a-171">Windows:Foundation::DateTime オブジェクトには、メソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-171">There are no methods on a Windows:Foundation::DateTime object.</span></span> <span data-ttu-id="5a67a-172">代わりに、各言語では DateTime をその言語独自の方法で算出します。JavaScript では Date オブジェクト、.NET Framework では System.DateTime 型および System.DateTimeOffset 型を利用します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-172">Instead, each language projects the DateTime in the way that is native to that language: the Date object in JavaScript and the System.DateTime and System.DateTimeOffset types in the .NET Framework.</span></span>

```cpp
public  ref class MyDateClass sealed
{
public:
    property Windows::Foundation::DateTime TimeStamp;
    void SetTime(Windows::Foundation::DateTime dt)
    {
        auto cal = ref new Windows::Globalization::Calendar();
        cal->SetDateTime(dt);
        TimeStamp = cal->GetDateTime(); // or TimeStamp = dt;
    }
};
```

<span data-ttu-id="5a67a-173">C + から DateTime 値を渡すこと/JavaScript に CX、JavaScript は Date オブジェクトとして受け取ります、既定では、長い形式の日付文字列として表示されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-173">When you pass a DateTime value from C++/CX to JavaScript, JavaScript accepts it as a Date object and displays it by default as a long-form date string.</span></span>

```javascript
function SetAndGetDate() {
    var nativeObject = new CppComponent.MyDateClass();

    var myDate = new Date(1956, 4, 21);
    nativeObject.setTime(myDate);

    var myDate2 = nativeObject.timeStamp;

    //prints long form date string
    document.getElementById('P5').innerHTML = myDate2;

}
```

<span data-ttu-id="5a67a-174">.NET 言語に system.datetime を c++/cli CX コンポーネント、メソッドとして受け取ります:datetime します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-174">When a .NET language passes a System.DateTime to a C++/CX component, the method accepts it as a Windows::Foundation::DateTime.</span></span> <span data-ttu-id="5a67a-175">コンポーネントが .NET Framework メソッドに Windows::Foundation::DateTime を渡すと、その .NET Framework メソッドはこの値を DateTimeOffset として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-175">When the component passes a Windows::Foundation::DateTime to a .NET Framework method, the Framework method accepts it as a DateTimeOffset.</span></span>

```csharp
private void DateTimeExample()
{
    // Pass a System.DateTime to a C++ method
    // that takes a Windows::Foundation::DateTime
    DateTime dt = DateTime.Now;
    var nativeObject = new CppComponent.MyDateClass();
    nativeObject.SetTime(dt);

    // Retrieve a Windows::Foundation::DateTime as a
    // System.DateTimeOffset
    DateTimeOffset myDate = nativeObject.TimeStamp;

    // Print the long-form date string
    ResultText.Text += myDate.ToString();
}
```

## <a name="collections-and-arrays"></a><span data-ttu-id="5a67a-176">コレクションと配列</span><span class="sxs-lookup"><span data-stu-id="5a67a-176">Collections and arrays</span></span>
<span data-ttu-id="5a67a-177">コレクションは、常に、Windows::Foundation::Collections::IVector^ や Windows::Foundation::Collections::IMap^ などの Windows ランタイム型へのハンドルとして ABI の境界を越えて渡されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-177">Collections are always passed across the ABI boundary as handles to Windows Runtime types such as Windows::Foundation::Collections::IVector^ and Windows::Foundation::Collections::IMap^.</span></span> <span data-ttu-id="5a67a-178">たとえば、Platform::Collections::Map にハンドルを返す場合、Windows::Foundation::Collections::IMap^ に暗黙的に変換されます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-178">For example, if you return a handle to a Platform::Collections::Map, it implicitly converts to a Windows::Foundation::Collections::IMap^.</span></span> <span data-ttu-id="5a67a-179">コレクション インターフェイスが、C++ とは別の名前空間に定義されている/具体的な実装を提供する CX クラスです。</span><span class="sxs-lookup"><span data-stu-id="5a67a-179">The collection interfaces are defined in a namespace that's separate from the C++/CX classes that provide the concrete implementations.</span></span> <span data-ttu-id="5a67a-180">そのインターフェイスを JavaScript 言語と .NET 言語で利用します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-180">JavaScript and .NET languages consume the interfaces.</span></span> <span data-ttu-id="5a67a-181">詳しくは、「[コレクション (C++/CX)](https://msdn.microsoft.com//library/windows/apps/hh700103.aspx)」と「[Array と WriteOnlyArray (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh700131.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a67a-181">For more information, see [Collections (C++/CX)](https://msdn.microsoft.com//library/windows/apps/hh700103.aspx) and [Array and WriteOnlyArray (C++/CX)](https://msdn.microsoft.com/library/windows/apps/hh700131.aspx).</span></span>

## <a name="passing-ivector"></a><span data-ttu-id="5a67a-182">IVector を渡す場合</span><span class="sxs-lookup"><span data-stu-id="5a67a-182">Passing IVector</span></span>
```cpp
// Windows::Foundation::Collections::IVector across the ABI.
//#include <algorithm>
//#include <collection.h>
Windows::Foundation::Collections::IVector<int>^ SortVector(Windows::Foundation::Collections::IVector<int>^ vec)
{
    std::sort(begin(vec), end(vec));
    return vec;
}
```

```javascript
var nativeObject = new CppComponent.CollectionExample();
// Call the method to sort an integer array
var inVector = [14, 12, 45, 89, 23];
var outVector = nativeObject.sortVector(inVector);
var result = "Sorted vector to array:";
for (var i = 0; i < outVector.length; i++)
{
    outVector[i];
    result += outVector[i].toString() + ",";
}
document.getElementById('P6').innerHTML = result;
```

<span data-ttu-id="5a67a-183">.NET 言語は IVector&lt;T&gt; を IList&lt;T&gt; として認識します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-183">The .NET languages see IVector&lt;T&gt; as IList&lt;T&gt;.</span></span>

```csharp
private void SortListItems()
{
    IList<int> myList = new List<int>();
    myList.Add(5);
    myList.Add(9);
    myList.Add(17);
    myList.Add(2);

    var nativeObject = new CppComponent.CollectionExample();
    IList<int> mySortedList = nativeObject.SortVector(myList);

    foreach (var item in mySortedList)
    {
        ResultText.Text += " " + item.ToString();
    }
}
```

## <a name="passing-imap"></a><span data-ttu-id="5a67a-184">IMap を渡す場合</span><span class="sxs-lookup"><span data-stu-id="5a67a-184">Passing IMap</span></span>
```cpp
// #include <map>
//#include <collection.h>
Windows::Foundation::Collections::IMap<int, Platform::String^> ^GetMap(void)
{    
    Windows::Foundation::Collections::IMap<int, Platform::String^> ^ret =
        ref new Platform::Collections::Map<int, Platform::String^>;
    ret->Insert(1, "One ");
    ret->Insert(2, "Two ");
    ret->Insert(3, "Three ");
    ret->Insert(4, "Four ");
    ret->Insert(5, "Five ");
    return ret;
}
```

```javascript
// Call the method to get the map
var outputMap = nativeObject.getMap();
var mStr = "Map result:" + outputMap.lookup(1) + outputMap.lookup(2)
    + outputMap.lookup(3) + outputMap.lookup(4) + outputMap.lookup(5);
document.getElementById('P7').innerHTML = mStr;
```

<span data-ttu-id="5a67a-185">.NET 言語は IMap を IDictionary&lt;K, V&gt; として認識します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-185">The .NET languages see IMap and IDictionary&lt;K, V&gt;.</span></span>

```csharp
private void GetDictionary()
{
    var nativeObject = new CppComponent.CollectionExample();
    IDictionary<int, string> d = nativeObject.GetMap();
    ResultText.Text += d[2].ToString();
}
```

## <a name="properties"></a><span data-ttu-id="5a67a-186">プロパティ</span><span class="sxs-lookup"><span data-stu-id="5a67a-186">Properties</span></span>
<span data-ttu-id="5a67a-187">C++ のパブリック ref クラス/CX コンポーネント拡張機能は、パブリック データ メンバーをプロパティとして、property キーワードを使用して公開します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-187">A public ref class in C++/CX component extensions exposes public data members as properties, by using the property keyword.</span></span> <span data-ttu-id="5a67a-188">この概念は .NET Framework のプロパティと同じです。</span><span class="sxs-lookup"><span data-stu-id="5a67a-188">The concept is identical to .NET Framework properties.</span></span> <span data-ttu-id="5a67a-189">単純プロパティは機能が暗黙的であるため、データ メンバーに似ています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-189">A trivial property resembles a data member because its functionality is implicit.</span></span> <span data-ttu-id="5a67a-190">非単純プロパティには、明示的な get アクセサーと set アクセサーがあり、値の "バッキング ストア" である名前付きのプライベート変数があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-190">A non-trivial property has explicit get and set accessors and a named private variable that's the "backing store" for the value.</span></span> <span data-ttu-id="5a67a-191">この例では、プライベート メンバー変数 \_propertyAValue は PropertyA のバッキング ストアです。</span><span class="sxs-lookup"><span data-stu-id="5a67a-191">In this example, the private member variable \_propertyAValue is the backing store for PropertyA.</span></span> <span data-ttu-id="5a67a-192">プロパティの値が変化するときにイベントを生成できます。またクライアント アプリは、そのイベントを受け取るように登録することができます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-192">A property can fire an event when its value changes, and a client app can register to receive that event.</span></span>

```cpp
//Properties
public delegate void PropertyChangedHandler(Platform::Object^ sender, int arg);
public ref class PropertyExample  sealed
{
public:
    PropertyExample(){}

    // Event that is fired when PropertyA changes
    event PropertyChangedHandler^ PropertyChangedEvent;

    // Property that has custom setter/getter
    property int PropertyA
    {
        int get() { return m_propertyAValue; }
        void set(int propertyAValue)
        {
            if (propertyAValue != m_propertyAValue)
            {
                m_propertyAValue = propertyAValue;
                // Fire event. (See event example below.)
                PropertyChangedEvent(this, propertyAValue);
            }
        }
    }

    // Trivial get/set property that has a compiler-generated backing store.
    property Platform::String^ PropertyB;

private:
    // Backing store for propertyA.
    int m_propertyAValue;
};
```

```javascript
var nativeObject = new CppComponent.PropertyExample();
var propValue = nativeObject.propertyA;
document.getElementById('P8').innerHTML = propValue;

//Set the string property
nativeObject.propertyB = "What is the meaning of the universe?";
document.getElementById('P9').innerHTML += nativeObject.propertyB;
```

<span data-ttu-id="5a67a-193">.NET 言語でネイティブの C + プロパティにアクセス +/CX オブジェクトを .NET Framework オブジェクトで場合と同様です。</span><span class="sxs-lookup"><span data-stu-id="5a67a-193">The .NET languages access properties on a native C++/CX object just as they would on a .NET Framework object.</span></span>

```csharp
private void GetAProperty()
{
    // Get the value of the integer property
    // Instantiate the C++ object
    var obj = new CppComponent.PropertyExample();

    // Get an integer property
    var propValue = obj.PropertyA;
    ResultText.Text += propValue.ToString();

    // Set a string property
    obj.PropertyB = " What is the meaning of the universe?";
    ResultText.Text += obj.PropertyB;

}
```

## <a name="delegates-and-events"></a><span data-ttu-id="5a67a-194">デリゲートおよびイベント</span><span class="sxs-lookup"><span data-stu-id="5a67a-194">Delegates and events</span></span>
<span data-ttu-id="5a67a-195">デリゲートは、関数オブジェクトを表す Windows ランタイム型です。</span><span class="sxs-lookup"><span data-stu-id="5a67a-195">A delegate is a Windows Runtime type that represents a function object.</span></span> <span data-ttu-id="5a67a-196">デリゲートは、後で実行するアクションを指定するために、イベント、コールバック、非同期メソッド呼び出しに関連して使います。</span><span class="sxs-lookup"><span data-stu-id="5a67a-196">You can use delegates in connection with events, callbacks, and asynchronous method calls to specify an action to be performed later.</span></span> <span data-ttu-id="5a67a-197">デリゲートは、関数オブジェクトのように、関数の戻り値の型とパラメーターの型を確認するためにコンパイラを有効にすることによってタイプ セーフを提供します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-197">Like a function object, the delegate provides type-safety by enabling the compiler to verify the return type and parameter types of the function.</span></span> <span data-ttu-id="5a67a-198">デリゲートの宣言は関数のシグネチャに似ており、実装はクラス定義に、また呼び出しは関数の呼び出しに似ています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-198">The declaration of a delegate resembles a function signature, the implementation resembles a class definition, and the invocation resembles a function invocation.</span></span>

## <a name="adding-an-event-listener"></a><span data-ttu-id="5a67a-199">イベント リスナーの追加</span><span class="sxs-lookup"><span data-stu-id="5a67a-199">Adding an event listener</span></span>
<span data-ttu-id="5a67a-200">指定されたデリゲート型のパブリック メンバーを宣言するために event キーワードを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-200">You can use the event keyword to declare a public member of a specified delegate type.</span></span> <span data-ttu-id="5a67a-201">クライアント コードは、特定の言語に用意されている標準機能を使ってイベントをサブスクライブします。</span><span class="sxs-lookup"><span data-stu-id="5a67a-201">Client code subscribes to the event by using the standard mechanisms that are provided in the particular language.</span></span>

```cpp
public:
    event SomeHandler^ someEvent;
```

<span data-ttu-id="5a67a-202">この例では、前のプロパティに関するセクションと同じ C++ コードを使います。</span><span class="sxs-lookup"><span data-stu-id="5a67a-202">This example uses the same C++ code as for the previous properties section.</span></span>

```javascript
function Button_Click() {
    var nativeObj = new CppComponent.PropertyExample();
    // Define an event handler method
    var singlecasthandler = function (ev) {
        document.getElementById('P10').innerHTML = "The button was clicked and the value is " + ev;
    };

    // Subscribe to the event
    nativeObj.onpropertychangedevent = singlecasthandler;

    // Set the value of the property and fire the event
    var propValue = 21;
    nativeObj.propertyA = 2 * propValue;

}
```

<span data-ttu-id="5a67a-203">.NET 言語の場合、C++ コンポーネントのイベントをサブスクライブすることは、.NET Framework クラスのイベントをサブスクライブすることと同じです。</span><span class="sxs-lookup"><span data-stu-id="5a67a-203">In the .NET languages, subscribing to an event in a C++ component is the same as subscribing to an event in a .NET Framework class:</span></span>

```csharp
//Subscribe to event and call method that causes it to be fired.
private void TestMethod()
{
    var objWithEvent = new CppComponent.PropertyExample();
    objWithEvent.PropertyChangedEvent += objWithEvent_PropertyChangedEvent;

    objWithEvent.PropertyA = 42;
}

//Event handler method
private void objWithEvent_PropertyChangedEvent(object __param0, int __param1)
{
    ResultText.Text = "the event was fired and the result is " +
         __param1.ToString();
}
```

## <a name="adding-multiple-event-listeners-for-one-event"></a><span data-ttu-id="5a67a-204">1 つのイベントに複数のイベント リスナーを追加する</span><span class="sxs-lookup"><span data-stu-id="5a67a-204">Adding multiple event listeners for one event</span></span>
<span data-ttu-id="5a67a-205">JavaScript には、複数のハンドラーで単一のイベントをサブスクライブできるようにする addEventListener メソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-205">JavaScript has an addEventListener method that enables multiple handlers to subscribe to a single event.</span></span>

```cpp
public delegate void SomeHandler(Platform::String^ str);

public ref class LangSample sealed
{
public:
    event SomeHandler^ someEvent;
    property Platform::String^ PropertyA;

    // Method that fires an event
    void FireEvent(Platform::String^ str)
    {
        someEvent(Platform::String::Concat(str, PropertyA->ToString()));
    }
    //...
};
```

```javascript
// Add two event handlers
var multicast1 = function (ev) {
    document.getElementById('P11').innerHTML = "Handler 1: " + ev.target;
};
var multicast2 = function (ev) {
    document.getElementById('P12').innerHTML = "Handler 2: " + ev.target;
};

var nativeObject = new CppComponent.LangSample();
//Subscribe to the same event
nativeObject.addEventListener("someevent", multicast1);
nativeObject.addEventListener("someevent", multicast2);

nativeObject.propertyA = "42";

// This method should fire an event
nativeObject.fireEvent("The answer is ");
```

<span data-ttu-id="5a67a-206">C# では、前の例で示したように += 演算子を使うことで、任意の数のイベント ハンドラーがイベントをサブスクライブできるようになります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-206">In C#, any number of event handlers can subscribe to the event by using the += operator as shown in the previous example.</span></span>

## <a name="enums"></a><span data-ttu-id="5a67a-207">列挙型</span><span class="sxs-lookup"><span data-stu-id="5a67a-207">Enums</span></span>
<span data-ttu-id="5a67a-208">C++ Windows ランタイム列挙型/CX は、public class enum; を使って宣言されますこれには、標準的な C++ のスコープ列挙型は似ています。</span><span class="sxs-lookup"><span data-stu-id="5a67a-208">A Windows Runtime enum in C++/CX is declared by using public class enum; it resembles a scoped enum in standard C++.</span></span>

```cpp
public enum class Direction {North, South, East, West};

public ref class EnumExampleClass sealed
{
public:
    property Direction CurrentDirection
    {
        Direction  get(){return m_direction; }
    }

private:
    Direction m_direction;
};
```

<span data-ttu-id="5a67a-209">列挙値は、C++ の間で渡される +/CX および整数として JavaScript します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-209">Enum values are passed between C++/CX and JavaScript as integers.</span></span> <span data-ttu-id="5a67a-210">必要に応じて c++ と同じ名前付きの値を含む JavaScript オブジェクトを宣言することができます + CX 列挙型を使用しとしてに依存します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-210">You can optionally declare a JavaScript object that contains the same named values as the C++/CX enum and use it as follows.</span></span>

```javascript
var Direction = { 0: "North", 1: "South", 2: "East", 3: "West" };
//. . .

var nativeObject = new CppComponent.EnumExampleClass();
var curDirection = nativeObject.currentDirection;
document.getElementById('P13').innerHTML =
Direction[curDirection];
```

<span data-ttu-id="5a67a-211">C# と Visual Basic のどちらの言語でも列挙型がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-211">Both C# and Visual Basic have language support for enums.</span></span> <span data-ttu-id="5a67a-212">この 2 つの言語では、.NET Framework の列挙型と同様に C ++ パブリック列挙型クラスを認識します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-212">These languages see a C++ public enum class just as they would see a .NET Framework enum.</span></span>

## <a name="asynchronous-methods"></a><span data-ttu-id="5a67a-213">非同期メソッド</span><span class="sxs-lookup"><span data-stu-id="5a67a-213">Asynchronous methods</span></span>
<span data-ttu-id="5a67a-214">他の Windows ランタイム オブジェクトによって公開される非同期メソッドを利用するには、[task クラス (同時実行ランタイム)](https://msdn.microsoft.com/library/hh750113.aspx) を使います。</span><span class="sxs-lookup"><span data-stu-id="5a67a-214">To consume asynchronous methods that are exposed by other Windows Runtime objects, use the [task Class (Concurrency Runtime)](https://msdn.microsoft.com/library/hh750113.aspx).</span></span> <span data-ttu-id="5a67a-215">詳しくは、「[タスクの並列処理 (同時実行ランタイム)](https://msdn.microsoft.com/library/dd492427.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5a67a-215">For more information, see and [Task Parallelism (Concurrency Runtime)](https://msdn.microsoft.com/library/dd492427.aspx).</span></span>

<span data-ttu-id="5a67a-216">C++ で非同期メソッドを実装する +/CX ppltasks.h で定義されている[create \_async](https://msdn.microsoft.com/library/hh750102.aspx)関数を使用します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-216">To implement asynchronous methods in C++/CX, use the [create\_async](https://msdn.microsoft.com/library/hh750102.aspx) function that's defined in ppltasks.h.</span></span> <span data-ttu-id="5a67a-217">詳細については、次を参照してください。 [、C++ で非同期操作の作成/UWP アプリの CX](https://msdn.microsoft.com/library/vstudio/hh750082.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-217">For more information, see [Creating Asynchronous Operations in C++/CX for UWP apps](https://msdn.microsoft.com/library/vstudio/hh750082.aspx).</span></span> <span data-ttu-id="5a67a-218">例については、次を参照してください。[チュートリアル: C++ で基本的な Windows ランタイム コンポーネントの作成/CX と JavaScript または c# からの呼び出し](walkthrough-creating-a-basic-windows-runtime-component-in-cpp-and-calling-it-from-javascript-or-csharp.md)します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-218">For an example, see [Walkthrough: Creating a basic Windows Runtime component in C++/CX and calling it from JavaScript or C#](walkthrough-creating-a-basic-windows-runtime-component-in-cpp-and-calling-it-from-javascript-or-csharp.md).</span></span> <span data-ttu-id="5a67a-219">.NET 言語で利用 C + + CX 非同期メソッドは、.NET Framework で定義されている任意の非同期メソッドの場合と同様です。</span><span class="sxs-lookup"><span data-stu-id="5a67a-219">The .NET languages consume C++/CX asynchronous methods just as they would any asynchronous method that's defined in the .NET Framework.</span></span>

## <a name="exceptions"></a><span data-ttu-id="5a67a-220">例外</span><span class="sxs-lookup"><span data-stu-id="5a67a-220">Exceptions</span></span>
<span data-ttu-id="5a67a-221">Windows ランタイムによって定義された任意の例外の型をスローできます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-221">You can throw any exception type that's defined by the Windows Runtime.</span></span> <span data-ttu-id="5a67a-222">Windows ランタイムのどの例外の型からもカスタム型は取得できません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-222">You cannot derive custom types from any Windows Runtime exception type.</span></span> <span data-ttu-id="5a67a-223">ただし、COMException をスローし、例外をキャッチするコードがアクセスできるカスタム HRESULT を提供できます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-223">However, you can throw COMException and provide a custom HRESULT that can be accessed by the code that catches the exception.</span></span> <span data-ttu-id="5a67a-224">COMException でカスタム メッセージを指定する方法はありません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-224">There's no way to specify a custom Message in a COMException.</span></span>

## <a name="debugging-tips"></a><span data-ttu-id="5a67a-225">デバッグのヒント</span><span class="sxs-lookup"><span data-stu-id="5a67a-225">Debugging tips</span></span>
<span data-ttu-id="5a67a-226">コンポーネント DLL を含む JavaScript ソリューションをデバッグするときは、コンポーネントでスクリプトのステップ実行またはネイティブ コードのステップ実行を有効にするようにデバッガーを設定できますが、この両方を同時に有効にすることはできません。</span><span class="sxs-lookup"><span data-stu-id="5a67a-226">When you debug a JavaScript solution that has a component DLL, you can set the debugger to enable either stepping through script, or stepping through native code in the component, but not both at the same time.</span></span> <span data-ttu-id="5a67a-227">設定を変更するには、ソリューション エクスプローラーで JavaScript プロジェクト ノードを選んでから、[プロパティ]、[デバッグ]、[デバッガーの種類] の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-227">To change the setting, select the JavaScript project node in Solution Explorer and then choose Properties, Debugging, Debugger Type.</span></span>

<span data-ttu-id="5a67a-228">パッケージ デザイナーで必ず適切な機能を選んでください。</span><span class="sxs-lookup"><span data-stu-id="5a67a-228">Be sure to select appropriate capabilities in the package designer.</span></span> <span data-ttu-id="5a67a-229">たとえば、Windows ランタイム API を使ってユーザーの画像ライブラリにある画像ファイルを開く場合は、マニフェスト デザイナーの [機能] ウィンドウの [画像ライブラリ] チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="5a67a-229">For example, if you are attempting to open an image file in the user's Pictures library by using the Windows Runtime APIs, be sure to select the Pictures Library check box in the Capabilities pane of the manifest designer.</span></span>

<span data-ttu-id="5a67a-230">JavaScript コードがコンポーネントのパブリック プロパティまたはパブリック メソッドを認識しないと考えられる場合は、JavaScript で camel 規約を使っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="5a67a-230">If your JavaScript code doesn't seem to be recognizing the public properties or methods in the component, make sure that in JavaScript you are using camel casing.</span></span> <span data-ttu-id="5a67a-231">LogCalc 内容など、+ CX メソッドは、JavaScript では logCalc として参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-231">For example, the LogCalc C++/CX method must be referenced as logCalc in JavaScript.</span></span>

<span data-ttu-id="5a67a-232">C++ を削除した場合 + CX Windows ランタイム コンポーネント プロジェクトをソリューションからは、JavaScript プロジェクトからプロジェクト参照も手動で削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5a67a-232">If you remove a C++/CX Windows Runtime component project from a solution, you must also manually remove the project reference from the JavaScript project.</span></span> <span data-ttu-id="5a67a-233">これを行わないと、後続のデバッグまたはビルド操作が妨げられます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-233">Failure to do so prevents subsequent debug or build operations.</span></span> <span data-ttu-id="5a67a-234">その後、必要に応じてアセンブリ参照を DLL に追加できます。</span><span class="sxs-lookup"><span data-stu-id="5a67a-234">If necessary, you can then add an assembly reference to the DLL.</span></span>

## <a name="related-topics"></a><span data-ttu-id="5a67a-235">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5a67a-235">Related topics</span></span>
* [<span data-ttu-id="5a67a-236">チュートリアル: C++/CX での基本的な Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し</span><span class="sxs-lookup"><span data-stu-id="5a67a-236">Walkthrough: Creating a basic Windows Runtime component in C++/CX and calling it from JavaScript or C#</span></span>](walkthrough-creating-a-basic-windows-runtime-component-in-cpp-and-calling-it-from-javascript-or-csharp.md)
