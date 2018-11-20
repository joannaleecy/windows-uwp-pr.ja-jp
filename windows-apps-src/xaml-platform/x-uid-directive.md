---
author: jwmsft
description: マークアップ要素の一意の識別子を提供します。 ユニバーサル Windows プラットフォーム (UWP) XAML では、.resw リソース ファイルのリソースを使うときなど、XAML のローカライズのプロセスとツールでこの一意の識別子が使われます。
title: xUid ディレクティブ
ms.assetid: 9FD6B62E-D345-44C6-B739-17ED1A187D69
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4bec4bd5d35fc2bb3013b37c1386520a769ddeb6
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7420859"
---
# <a name="xuid-directive"></a><span data-ttu-id="3eec6-105">x:Uid ディレクティブ</span><span class="sxs-lookup"><span data-stu-id="3eec6-105">x:Uid directive</span></span>


<span data-ttu-id="3eec6-106">マークアップ要素の一意の識別子を提供します。</span><span class="sxs-lookup"><span data-stu-id="3eec6-106">Provides a unique identifier for markup elements.</span></span> <span data-ttu-id="3eec6-107">ユニバーサル Windows プラットフォーム (UWP) XAML では、.resw リソース ファイルのリソースを使うときなど、XAML のローカライズのプロセスとツールでこの一意の識別子が使われます。</span><span class="sxs-lookup"><span data-stu-id="3eec6-107">For Universal Windows Platform (UWP) XAML, this unique identifier is used by XAML localization processes and tools, such as using resources from a .resw resource file.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="3eec6-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="3eec6-108">XAML attribute usage</span></span>

``` syntax
<object x:Uid="stringID".../>
```

## <a name="xaml-values"></a><span data-ttu-id="3eec6-109">XAML 値</span><span class="sxs-lookup"><span data-stu-id="3eec6-109">XAML values</span></span>

| <span data-ttu-id="3eec6-110">用語</span><span class="sxs-lookup"><span data-stu-id="3eec6-110">Term</span></span> | <span data-ttu-id="3eec6-111">説明</span><span class="sxs-lookup"><span data-stu-id="3eec6-111">Description</span></span> |
|------|-------------|
| <span data-ttu-id="3eec6-112">stringID</span><span class="sxs-lookup"><span data-stu-id="3eec6-112">stringID</span></span> | <span data-ttu-id="3eec6-113">アプリ内の XAML 要素を一意に識別し、リソース ファイルのリソース パスの一部となる文字列です。</span><span class="sxs-lookup"><span data-stu-id="3eec6-113">A string that uniquely identifies a XAML element in an app, and becomes part of the resource path in a resource file.</span></span> <span data-ttu-id="3eec6-114">注釈をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3eec6-114">See Remarks.</span></span>| 

## <a name="remarks"></a><span data-ttu-id="3eec6-115">注釈</span><span class="sxs-lookup"><span data-stu-id="3eec6-115">Remarks</span></span>

<span data-ttu-id="3eec6-116">XAML でオブジェクト要素を識別するには **x:Uid** を使います。</span><span class="sxs-lookup"><span data-stu-id="3eec6-116">Use **x:Uid** to identify an object element in your XAML.</span></span> <span data-ttu-id="3eec6-117">このオブジェクト要素は通常、コントロール クラスか、UI に表示される要素のインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="3eec6-117">Typically this object element is an instance of a control class or other element that is displayed in a UI.</span></span> <span data-ttu-id="3eec6-118">**x:Uid** で使う文字列とリソース ファイルで使う文字列の関係として、リソース ファイルの文字列は **x:Uid** の後にドット (.)、その次にローカライズ対象要素の特定のプロパティの名前が続きます。</span><span class="sxs-lookup"><span data-stu-id="3eec6-118">The relationship between the string you use in **x:Uid** and the strings you use in a resources file is that the resource file strings are the **x:Uid** followed by a dot (.) and then by the name of a specific property of the element that's being localized.</span></span> <span data-ttu-id="3eec6-119">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="3eec6-119">Consider this example:</span></span>

``` syntax
<Button x:Uid="GoButton" Content="Go"/>
```

<span data-ttu-id="3eec6-120">**Go** という表示テキストを置き換えるコンテンツを指定するには、リソース ファイルの新しいリソースを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3eec6-120">To specify content to replace the display text **Go**, you must specify a new resource that comes from a resource file.</span></span> <span data-ttu-id="3eec6-121">リソース ファイルには "GoButton.Content" という名前のリソースのエントリを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3eec6-121">Your resource file should contain an entry for the resource named "GoButton.Content".</span></span> <span data-ttu-id="3eec6-122">この場合、[**Content**](/uwp/api/windows.ui.xaml.controls.contentcontrol.content) が [**Button**](/uwp/api/windows.ui.xaml.controls.button) クラスに継承される特定のプロパティです。</span><span class="sxs-lookup"><span data-stu-id="3eec6-122">[**Content**](/uwp/api/windows.ui.xaml.controls.contentcontrol.content) in this case is a specific property that's inherited by the [**Button**](/uwp/api/windows.ui.xaml.controls.button) class.</span></span> <span data-ttu-id="3eec6-123">"GoButton.FlowDirection" にリソースに基づく値を指定するなど、このボタンの他のプロパティにローカライズ値を指定することがあります。</span><span class="sxs-lookup"><span data-stu-id="3eec6-123">You might also provide localized values for other properties of this button, for example you could provide a resource-based value for "GoButton.FlowDirection".</span></span> <span data-ttu-id="3eec6-124">**x:Uid** とリソース ファイルを一緒に使用する方法の詳細については、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../app-resources/localize-strings-ui-manifest.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3eec6-124">For more info on how to use **x:Uid** and resource files together, see [Localize strings in your UI and app package manifest](../app-resources/localize-strings-ui-manifest.md).</span></span>

<span data-ttu-id="3eec6-125">**x:Uid** 値に使用可能な文字列の正当性は、リソース ファイル内の識別子やリソース パスとして正当な文字列はどれかという実質的な意味合いにおいて制御されます。</span><span class="sxs-lookup"><span data-stu-id="3eec6-125">The validity of which strings can be used for an **x:Uid** value is controlled in a practical sense by which strings are legal as an identifier in a resource file and a resource path.</span></span>

<span data-ttu-id="3eec6-126">規定された XAML のローカライズ シナリオにより、**x:Uid** は **x:Name** から分離されています。したがって、ローカライズで使われる識別子は、プログラミング モデルの関連において **x:Name** への依存関係はありません。</span><span class="sxs-lookup"><span data-stu-id="3eec6-126">**x:Uid** is discrete from **x:Name** both because of the stated XAML localization scenario, and so that identifiers that are used for localization have no dependencies on the programming model implications of **x:Name**.</span></span> <span data-ttu-id="3eec6-127">また、**x:Name** は XAML 名前スコープの概念で管理されるのに対して、**x:Uid** の一意性はパッケージ リソース インデックス (PRI) システムによって制御されます。</span><span class="sxs-lookup"><span data-stu-id="3eec6-127">Also, **x:Name** is governed by the XAML namescope concept, whereas uniqueness for **x:Uid** is controlled by the package resource index (PRI) system.</span></span> <span data-ttu-id="3eec6-128">詳しくは、「[リソース管理システム](../app-resources/resource-management-system.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3eec6-128">For more info, see [Resource Management System](../app-resources/resource-management-system.md).</span></span>

<span data-ttu-id="3eec6-129">UWP XAML での **x:Uid** の一意性の規則は、以前使われていた XAML を利用したテクノロジと比べると、いくらか異なります。</span><span class="sxs-lookup"><span data-stu-id="3eec6-129">UWP XAML has somewhat different rules for **x:Uid** uniqueness than previous XAML-utilizing technologies used.</span></span> <span data-ttu-id="3eec6-130">UWP XAML では、複数の XAML 要素上で同一の **x:Uid** ID 値がディレクティブとして存在することは正当とされています。</span><span class="sxs-lookup"><span data-stu-id="3eec6-130">For UWP XAML it is legal for the same **x:Uid** ID value to exist as a directive on multiple XAML elements.</span></span> <span data-ttu-id="3eec6-131">ただし、そうした各要素は、リソース ファイル内のリソースを解決するときに、同じ解決ロジックを共有する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3eec6-131">However, each such element must then share the same resolution logic when resolving the resources in a resource file.</span></span> <span data-ttu-id="3eec6-132">また、プロジェクト内のすべての XAML ファイルも、**x:Uid** 解決の目的で、1 つのリソース範囲を共有します。個々の XAML ファイルに合わせた **x:Uid** 範囲の概念は存在しません。</span><span class="sxs-lookup"><span data-stu-id="3eec6-132">Also, all XAML files in a project share a single resource scope for purposes of **x:Uid** resolution, there is no concept of **x:Uid** scopes being aligned to individual XAML files.</span></span>

<span data-ttu-id="3eec6-133">場合によっては、パッケージ リソース インデックスの (PRI) システムの組み込みの機能ではなく、リソース パスを使います。</span><span class="sxs-lookup"><span data-stu-id="3eec6-133">In some cases you'll be using a resource path rather than built-in functionality of the package resource index (PRI) system.</span></span> <span data-ttu-id="3eec6-134">**x:Uid** 値として使われる文字列はいずれも、ms-resource:///Resources/ で始まり **x:Uid** 文字列を含むリソース パスを定義します。</span><span class="sxs-lookup"><span data-stu-id="3eec6-134">Any string used as an **x:Uid** value defines a resource path that begins with ms-resource:///Resources/ and includes the **x:Uid** string.</span></span> <span data-ttu-id="3eec6-135">パスは、リソース ファイルで指定するプロパティ名か、ターゲットに設定するプロパティ名で終わります。</span><span class="sxs-lookup"><span data-stu-id="3eec6-135">The path is completed by the names of the properties you specify in a resources file or are otherwise targeting.</span></span>

<span data-ttu-id="3eec6-136">Windows ランタイム XAML では、プロパティ要素に **x:Uid** を含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="3eec6-136">Don't put **x:Uid** on property elements, that isn't allowed in Windows Runtime XAML.</span></span>

