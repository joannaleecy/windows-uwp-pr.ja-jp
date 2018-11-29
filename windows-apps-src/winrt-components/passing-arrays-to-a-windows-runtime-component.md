---
title: Windows ランタイム コンポーネントに配列を渡す
description: Windows ユニバーサル プラットフォーム (UWP) では、パラメーターは入力または出力のどちらかに使用され、両方に使用されることはありません。 つまり、メソッドに渡される配列の内容および配列自体は、入力か出力のどちらかに使用されます。
ms.assetid: 8DE695AC-CEF2-438C-8F94-FB783EE18EB9
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 60c2e2221cd174ffd75a45d6fe8e2f66744d67a0
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8191917"
---
# <a name="passing-arrays-to-a-windows-runtime-component"></a><span data-ttu-id="3c355-105">Windows ランタイム コンポーネントに配列を渡す</span><span class="sxs-lookup"><span data-stu-id="3c355-105">Passing arrays to a Windows Runtime Component</span></span>




<span data-ttu-id="3c355-106">Windows ユニバーサル プラットフォーム (UWP) では、パラメーターは入力または出力のどちらかに使用され、両方に使用されることはありません。</span><span class="sxs-lookup"><span data-stu-id="3c355-106">In the Windows Universal Platform (UWP), parameters are either for input or for output, never both.</span></span> <span data-ttu-id="3c355-107">つまり、メソッドに渡される配列の内容および配列自体は、入力か出力のどちらかに使用されます。</span><span class="sxs-lookup"><span data-stu-id="3c355-107">This means that the contents of an array that is passed to a method, as well as the array itself, are either for input or for output.</span></span> <span data-ttu-id="3c355-108">配列の内容が入力に使用される場合、メソッドは配列から読み取りを行いますが、書き込みはしません。</span><span class="sxs-lookup"><span data-stu-id="3c355-108">If the contents of the array are for input, the method reads from the array but doesn't write to it.</span></span> <span data-ttu-id="3c355-109">配列の内容が出力に使用される場合、メソッドは配列に書き込みを行いますが、読み取りはしません。</span><span class="sxs-lookup"><span data-stu-id="3c355-109">If the contents of the array are for output, the method writes to the array but doesn't read from it.</span></span> <span data-ttu-id="3c355-110">.NET framework の配列は参照型であり、配列の参照が値 (Visual Basic では **ByVal**) で渡されるときも配列の内容は変更可能であるため、これは配列パラメーターにとって問題となります。</span><span class="sxs-lookup"><span data-stu-id="3c355-110">This presents a problem for array parameters, because arrays in the .NET Framework are reference types, and the contents of an array are mutable even when the array reference is passed by value (**ByVal** in Visual Basic).</span></span> <span data-ttu-id="3c355-111">[Windows ランタイム メタデータのエクスポート ツール (Winmdexp.exe)](https://msdn.microsoft.com/library/hh925576.aspx) では、コンテキストから判別できない場合、パラメーターに ReadOnlyArrayAttribute 属性または WriteOnlyArrayAttribute 属性を適用して、配列の用途を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c355-111">The [Windows Runtime Metadata Export Tool (Winmdexp.exe)](https://msdn.microsoft.com/library/hh925576.aspx) requires you to specify the intended usage of the array if it is not clear from context, by applying the ReadOnlyArrayAttribute attribute or the WriteOnlyArrayAttribute attribute to the parameter.</span></span> <span data-ttu-id="3c355-112">配列の使用方法は、次のように決定されます。</span><span class="sxs-lookup"><span data-stu-id="3c355-112">Array usage is determined as follows:</span></span>

-   <span data-ttu-id="3c355-113">戻り値、または出力パラメーター (Visual Basic では、[OutAttribute](https://msdn.microsoft.com/library/system.runtime.interopservices.outattribute.aspx) 属性の **ByRef** パラメーター) の場合、配列は常に出力に使用されます。</span><span class="sxs-lookup"><span data-stu-id="3c355-113">For the return value or for an out parameter (a **ByRef** parameter with the [OutAttribute](https://msdn.microsoft.com/library/system.runtime.interopservices.outattribute.aspx) attribute in Visual Basic) the array is always for output only.</span></span> <span data-ttu-id="3c355-114">ReadOnlyArrayAttribute 属性は適用しないでください。</span><span class="sxs-lookup"><span data-stu-id="3c355-114">Do not apply the ReadOnlyArrayAttribute attribute.</span></span> <span data-ttu-id="3c355-115">出力パラメーターで WriteOnlyArrayAttribute 属性を適用することはできますが、冗長になります。</span><span class="sxs-lookup"><span data-stu-id="3c355-115">The WriteOnlyArrayAttribute attribute is allowed on output parameters, but it's redundant.</span></span>

    > <span data-ttu-id="3c355-116">**注意:** Visual Basic のコンパイラが出力専用の規則を強制しません。</span><span class="sxs-lookup"><span data-stu-id="3c355-116">**Caution**The Visual Basic compiler does not enforce output-only rules.</span></span> <span data-ttu-id="3c355-117">出力パラメーターからの読み取りは行わないでください。**Nothing** が含まれている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3c355-117">You should never read from an output parameter; it may contain **Nothing**.</span></span> <span data-ttu-id="3c355-118">常に新しい配列を割り当ててください。</span><span class="sxs-lookup"><span data-stu-id="3c355-118">Always assign a new array.</span></span>
 
-   <span data-ttu-id="3c355-119">**ref** 修飾子 (Visual Basic では **ByRef**) を持つパラメーターは使用できません。</span><span class="sxs-lookup"><span data-stu-id="3c355-119">Parameters that have the **ref** modifier (**ByRef** in Visual Basic) are not allowed.</span></span> <span data-ttu-id="3c355-120">Winmdexp.exe によりエラーが生成されます。</span><span class="sxs-lookup"><span data-stu-id="3c355-120">Winmdexp.exe generates an error.</span></span>
-   <span data-ttu-id="3c355-121">値で渡されるパラメーターの場合、[ReadOnlyArrayAttribute](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.readonlyarrayattribute.aspx) 属性または [WriteOnlyArrayAttribute](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.writeonlyarrayattribute.aspx) 属性を適用して、配列の内容が入力と出力のどちらで使用されるのかを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c355-121">For a parameter that is passed by value, you must specify whether the array contents are for input or output by applying either the [ReadOnlyArrayAttribute](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.readonlyarrayattribute.aspx) attribute or the [WriteOnlyArrayAttribute](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.writeonlyarrayattribute.aspx) attribute.</span></span> <span data-ttu-id="3c355-122">両方の属性を指定すると、エラーになります。</span><span class="sxs-lookup"><span data-stu-id="3c355-122">Specifying both attributes is an error.</span></span>

<span data-ttu-id="3c355-123">メソッドで、入力の配列を受け取り、配列の内容を変更して、呼び出し元に配列を返す必要がある場合、入力には読み取り専用のパラメーター、出力には書き込み専用のパラメーター (または戻り値) を使用します。</span><span class="sxs-lookup"><span data-stu-id="3c355-123">If a method must accept an array for input, modify the array contents, and return the array to the caller, use a read-only parameter for the input and a write-only parameter (or the return value) for the output.</span></span> <span data-ttu-id="3c355-124">次のコードは、このパターンを実装する 1 つの方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3c355-124">The following code shows one way to implement this pattern:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public int[] ChangeArray([ReadOnlyArray()] int[] input)
> {
>     int[] output = input.Clone();
>     // Manipulate the copy.
>     //   ...
>     return output;
> }
> ```
> ```vb
> Public Function ChangeArray(<ReadOnlyArray> input() As Integer) As Integer()
>     Dim output() As Integer = input.Clone()
>     ' Manipulate the copy.
>     '   ...
>     Return output
> End Function
> ```

<span data-ttu-id="3c355-125">すぐに入力の配列をコピーして、利用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3c355-125">We recommend that you make a copy of the input array immediately, and manipulate the copy.</span></span> <span data-ttu-id="3c355-126">コピーして利用することにより、コンポーネントを .NET Framework のコードで呼び出すかどうかに関係なく、メソッドが同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="3c355-126">This helps ensure that the method behaves the same whether or not your component is called by .NET Framework code.</span></span>

## <a name="using-components-from-managed-and-unmanaged-code"></a><span data-ttu-id="3c355-127">マネージ コードおよびアンマネージ コードからコンポーネントを使用する</span><span class="sxs-lookup"><span data-stu-id="3c355-127">Using components from managed and unmanaged code</span></span>


<span data-ttu-id="3c355-128">ReadOnlyArrayAttribute 属性または WriteOnlyArrayAttribute 属性を持つパラメーターは、呼び出し元がネイティブ コードで記述されているか、マネージ コードで記述されているかによって、動作が異なります。</span><span class="sxs-lookup"><span data-stu-id="3c355-128">Parameters that have the ReadOnlyArrayAttribute attribute or the WriteOnlyArrayAttribute attribute behave differently depending on whether the caller is written in native code or managed code.</span></span> <span data-ttu-id="3c355-129">呼び出し元が、ネイティブ コード (JavaScript、または VisualC++ コンポーネント拡張機能) の場合、配列の内容は次のように処理されます。</span><span class="sxs-lookup"><span data-stu-id="3c355-129">If the caller is native code (JavaScript or Visual C++ component extensions), the array contents are treated as follows:</span></span>

-   <span data-ttu-id="3c355-130">ReadOnlyArrayAttribute: アプリケーション バイナリ インターフェイス (ABI) の境界を越えた呼び出しの場合、配列はコピーされます。</span><span class="sxs-lookup"><span data-stu-id="3c355-130">ReadOnlyArrayAttribute: The array is copied when the call crosses the application binary interface (ABI) boundary.</span></span> <span data-ttu-id="3c355-131">要素は必要に応じて変換されます。</span><span class="sxs-lookup"><span data-stu-id="3c355-131">Elements are converted if necessary.</span></span> <span data-ttu-id="3c355-132">このため、入力専用の配列に、メソッドで誤って変更が加えられた場合でも、呼び出し元では認識されません。</span><span class="sxs-lookup"><span data-stu-id="3c355-132">Therefore, any accidental changes the method makes to an input-only array are not visible to the caller.</span></span>
-   <span data-ttu-id="3c355-133">WriteOnlyArrayAttribute: 呼び出されたメソッドでは、元の配列の内容を推測できません。</span><span class="sxs-lookup"><span data-stu-id="3c355-133">WriteOnlyArrayAttribute: The called method can't make any assumptions about the contents of the original array.</span></span> <span data-ttu-id="3c355-134">たとえば、メソッドが受け取る配列は、初期化されていなかったり既定値を含む可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3c355-134">For example, the array the method receives might not be initialized, or might contain default values.</span></span> <span data-ttu-id="3c355-135">メソッドは、配列内のすべての要素に値を設定することが求められます。</span><span class="sxs-lookup"><span data-stu-id="3c355-135">The method is expected to set the values of all the elements in the array.</span></span>

<span data-ttu-id="3c355-136">呼び出し元がマネージ コードの場合、元の配列は .NET framework のメソッド呼び出しの中にあるため、呼び出されたメソッドでも使用可能です。</span><span class="sxs-lookup"><span data-stu-id="3c355-136">If the caller is managed code, the original array is available to the called method, as it would be in any method call in the .NET Framework.</span></span> <span data-ttu-id="3c355-137">配列の内容は .NET Framework のコードで変更可能なため、メソッドが配列に加えた変更は、呼び出し元からも認識されます。</span><span class="sxs-lookup"><span data-stu-id="3c355-137">Array contents are mutable in .NET Framework code, so any changes the method makes to the array are visible to the caller.</span></span> <span data-ttu-id="3c355-138">これは、Windows ランタイム コンポーネント用に作成された単体テストに影響するため、注意してください。</span><span class="sxs-lookup"><span data-stu-id="3c355-138">This is important to remember because it affects unit tests written for a Windows Runtime Component.</span></span> <span data-ttu-id="3c355-139">テストがマネージ コードで作成された場合、配列の内容はテスト中に変更可能になります。</span><span class="sxs-lookup"><span data-stu-id="3c355-139">If the tests are written in managed code, the contents of an array will appear to be mutable during testing.</span></span>

## <a name="related-topics"></a><span data-ttu-id="3c355-140">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3c355-140">Related topics</span></span>

* [<span data-ttu-id="3c355-141">ReadOnlyArrayAttribute</span><span class="sxs-lookup"><span data-stu-id="3c355-141">ReadOnlyArrayAttribute</span></span>](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.readonlyarrayattribute.aspx)
* [<span data-ttu-id="3c355-142">WriteOnlyArrayAttribute</span><span class="sxs-lookup"><span data-stu-id="3c355-142">WriteOnlyArrayAttribute</span></span>](https://msdn.microsoft.com/library/system.runtime.interopservices.windowsruntime.writeonlyarrayattribute.aspx)
* [<span data-ttu-id="3c355-143">C# および Visual Basic での Windows ランタイム コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="3c355-143">Creating Windows Runtime Components in C# and Visual Basic</span></span>](creating-windows-runtime-components-in-csharp-and-visual-basic.md)
