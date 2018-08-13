---
author: jwmsft
description: マークアップとコード ビハインドの間で部分クラスを結合するための XAML コンパイルを設定します。 コードの部分クラスは個別のコード ファイルで定義され、マークアップ部分クラスは XAML コンパイル時のコード生成によって作成されます。
title: xClass 属性
ms.assetid: 40A7C036-133A-44DF-9D11-0D39232C948F
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: d3105e8ac345e1eb6f0d974f8ea29e741dae9f58
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "244536"
---
# <a name="xclass-attribute"></a><span data-ttu-id="b6e72-105">x:Class 属性</span><span class="sxs-lookup"><span data-stu-id="b6e72-105">x:Class attribute</span></span>

<span data-ttu-id="b6e72-106">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="b6e72-106">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="b6e72-107">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="b6e72-107">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="b6e72-108">マークアップとコード ビハインドの間で部分クラスを結合するための XAML コンパイルを設定します。</span><span class="sxs-lookup"><span data-stu-id="b6e72-108">Configures XAML compilation to join partial classes between markup and code-behind.</span></span> <span data-ttu-id="b6e72-109">コードの部分クラスは、個別のコード ファイルで定義され、マークアップ部分クラスは XAML コンパイル時のコード生成によって作成されます。</span><span class="sxs-lookup"><span data-stu-id="b6e72-109">The code partial class is defined in a separate code file, and the markup partial class is created by code generation during XAML compilation.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="b6e72-110">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="b6e72-110">XAML attribute usage</span></span>


``` syntax
<object x:Class="namespace.classname"...>
  ...
</object>
```

## <a name="xaml-values"></a><span data-ttu-id="b6e72-111">XAML 値</span><span class="sxs-lookup"><span data-stu-id="b6e72-111">XAML values</span></span>

| <span data-ttu-id="b6e72-112">用語</span><span class="sxs-lookup"><span data-stu-id="b6e72-112">Term</span></span> | <span data-ttu-id="b6e72-113">説明</span><span class="sxs-lookup"><span data-stu-id="b6e72-113">Description</span></span> |
|------|-------------|
| <span data-ttu-id="b6e72-114">名前空間</span><span class="sxs-lookup"><span data-stu-id="b6e72-114">namespace</span></span> | <span data-ttu-id="b6e72-115">省略可能。</span><span class="sxs-lookup"><span data-stu-id="b6e72-115">Optional.</span></span> <span data-ttu-id="b6e72-116">_classname_ で識別される部分クラスが含まれている名前空間を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6e72-116">Specifies a namespace that contains the partial class identified by _classname_.</span></span> <span data-ttu-id="b6e72-117">_名前空間_を指定すると、_名前空間_と_クラス名_がドット (.) で区切られます。</span><span class="sxs-lookup"><span data-stu-id="b6e72-117">If _namespace_ is specified, a dot (.) separates _namespace_ and _classname_.</span></span> <span data-ttu-id="b6e72-118">_名前空間_を省略すると、_クラス名_には名前空間がないものと見なされます。</span><span class="sxs-lookup"><span data-stu-id="b6e72-118">If _namespace_ is omitted, _classname_ is assumed to have no namespace.</span></span> |
| <span data-ttu-id="b6e72-119">classname</span><span class="sxs-lookup"><span data-stu-id="b6e72-119">classname</span></span> | <span data-ttu-id="b6e72-120">必須。</span><span class="sxs-lookup"><span data-stu-id="b6e72-120">Required.</span></span> <span data-ttu-id="b6e72-121">ロードされた XAML とその XAML のコード ビハインドを結び付ける部分クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6e72-121">Specifies the name of the partial class that connects the loaded XAML and your code-behind for that XAML.</span></span> | 

## <a name="remarks"></a><span data-ttu-id="b6e72-122">注釈</span><span class="sxs-lookup"><span data-stu-id="b6e72-122">Remarks</span></span>

<span data-ttu-id="b6e72-123">**x:Class** は、XAML ファイル/オブジェクト ツリーのルートであり、ビルド アクションによってコンパイルされる任意の要素か、コンパイルされたアプリケーションのアプリケーション定義中の [**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) ルートの属性として宣言できます。</span><span class="sxs-lookup"><span data-stu-id="b6e72-123">**x:Class** can be declared as an attribute for any element that is the root of a XAML file/object tree and is being compiled by build actions, or for the [**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) root in the application definition of a compiled application.</span></span> <span data-ttu-id="b6e72-124">ルート ノード以外の任意の要素に対して **x:Class** を宣言した場合、XAML ファイルが **Page** ビルド動作でコンパイルされていない任意の状況下で、コンパイル時エラーになります。</span><span class="sxs-lookup"><span data-stu-id="b6e72-124">Declaring **x:Class** on any element other than a root node, and under any circumstances for a XAML file that is not compiled with the **Page** build action, results in a compile-time error.</span></span>

<span data-ttu-id="b6e72-125">**x:Class** として使われたクラスは、ネストされたクラスにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="b6e72-125">The class used as **x:Class** cannot be a nested class.</span></span>

<span data-ttu-id="b6e72-126">**x:Class** 属性の値は、クラスの完全修飾名を指定する文字列であることが必要です。</span><span class="sxs-lookup"><span data-stu-id="b6e72-126">The value of the **x:Class** attribute must be a string that specifies the fully qualified name of a class.</span></span> <span data-ttu-id="b6e72-127">コード ビハインドに名前空間情報がない場合に限り、名前空間情報を省略できます (クラス定義はクラス レベルで開始されます)</span><span class="sxs-lookup"><span data-stu-id="b6e72-127">You can omit namespace information so long as that is how the code-behind is structured also (your class definition starts at the class level).</span></span> <span data-ttu-id="b6e72-128">ページまたはアプリケーション定義のコード ビハインド ファイルは、プロジェクトの一部として含まれているコード ファイルの中にあることが必要です。</span><span class="sxs-lookup"><span data-stu-id="b6e72-128">The code-behind file for a page or application definition must be within a code file that is included as part of the project.</span></span> <span data-ttu-id="b6e72-129">コード ビハインド クラスはパブリックであることが必要です。</span><span class="sxs-lookup"><span data-stu-id="b6e72-129">The code-behind class must be public.</span></span> <span data-ttu-id="b6e72-130">コード ビハインド クラスは部分的であることが必要です。</span><span class="sxs-lookup"><span data-stu-id="b6e72-130">The code-behind class must be partial.</span></span>

## <a name="clr-language-rules"></a><span data-ttu-id="b6e72-131">CLR 言語規則</span><span class="sxs-lookup"><span data-stu-id="b6e72-131">CLR language rules</span></span>

<span data-ttu-id="b6e72-132">コード ビハインド ファイルとしては C++ ファイルが使用可能ですが、XAML 構文に違いが出ないようにするため、CLR の言語形式に従う特定の構文があります。</span><span class="sxs-lookup"><span data-stu-id="b6e72-132">Although your code-behind file can be a C++ file, there are certain conventions that still follow the CLR language form, so that there is no difference in the XAML syntax.</span></span> <span data-ttu-id="b6e72-133">特に、任意の **x:Class** 値の名前空間とクラス名の間の区切り文字は、XAML に関連付けられた C++ コード ファイルの名前空間とクラス名の間の区切り文字が "::" であっても、常にドット (".") になります。</span><span class="sxs-lookup"><span data-stu-id="b6e72-133">In particular, the separator between the namespace and classname components of any **x:Class** value is always a dot ("."), even though the separator between namespace and classname in the C++ code file associated with the XAML is "::".</span></span> <span data-ttu-id="b6e72-134">**x:Class** 値の *namespace* 部分を指定する場合、C++ で入れ子になった名前空間を宣言すると、以降の入れ子になった名前空間の文字列間の区切り文字も "::" ではなく "." である必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6e72-134">If you declare nested namespaces in C++, then the separator between the successive nested namespace strings should also be "." rather than "::" when you specify the *namespace* part of the **x:Class** value.</span></span>

