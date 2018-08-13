---
author: jwmsft
description: XAML マークアップで、プロパティに null 値を指定します。
title: xNull マークアップ拡張
ms.assetid: E6A4038E-4ADA-4E82-9824-582FC16AB037
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: a367594cab5e1f29ce6c5f45ee869b025c4bf47e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "246533"
---
# <a name="xnull-markup-extension"></a><span data-ttu-id="bad9e-104">{x:Null} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="bad9e-104">{x:Null} markup extension</span></span>

<span data-ttu-id="bad9e-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="bad9e-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="bad9e-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="bad9e-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="bad9e-107">XAML マークアップで、プロパティに **null** 値を指定します。</span><span class="sxs-lookup"><span data-stu-id="bad9e-107">In XAML markup, specifies a **null** value for a property.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="bad9e-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="bad9e-108">XAML attribute usage</span></span>

``` syntax
<object property="{x:Null}" .../>
```

## <a name="remarks"></a><span data-ttu-id="bad9e-109">注釈</span><span class="sxs-lookup"><span data-stu-id="bad9e-109">Remarks</span></span>

<span data-ttu-id="bad9e-110">**null** は、C# と C++ の null 参照キーワードです。</span><span class="sxs-lookup"><span data-stu-id="bad9e-110">**null** is the null reference keyword for C# and C++.</span></span> <span data-ttu-id="bad9e-111">Microsoft Visual Basic の null 参照キーワードは **Nothing** です。</span><span class="sxs-lookup"><span data-stu-id="bad9e-111">The Microsoft Visual Basic keyword for a null reference is **Nothing**.</span></span>

<span data-ttu-id="bad9e-112">初期の既定値は、依存関係プロパティごとに異なる場合があり、必ずしも **null** というわけではありません。</span><span class="sxs-lookup"><span data-stu-id="bad9e-112">The initial default value can vary between dependency properties, and it is not necessarily **null**.</span></span> <span data-ttu-id="bad9e-113">また、依存関係プロパティの多くは、その内部実装により、(マークアップまたはコードのいずれによる場合でも) **null** を値として受け入れません。</span><span class="sxs-lookup"><span data-stu-id="bad9e-113">Further, many dependency properties will not accept **null** as a value (whether through markup or code) due to their internal implementation.</span></span> <span data-ttu-id="bad9e-114">このような場合、**{x:Null}** で XAML 属性値を設定すると、パーサー例外が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="bad9e-114">In such cases, setting a XAML attribute value with **{x:Null}** can result in a parser exception.</span></span>

<span data-ttu-id="bad9e-115">一部の Windows ランタイム型では、null を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="bad9e-115">Some Windows Runtime types are nullable.</span></span> <span data-ttu-id="bad9e-116">null 許容型に **null** が既定値として設定されていない場合に備え、**{x:Null}** を使って XAML 内で **null** 値に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="bad9e-116">In cases where a nullable type does not already have **null** as the default, you could use **{x:Null}** in XAML to set to the **null** value.</span></span> <span data-ttu-id="bad9e-117">Visual C++ コンポーネント拡張機能 (C++/CX) を使う場合、null 許容型は [**Platform::IBox<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/jj606120.aspx) として表されます。</span><span class="sxs-lookup"><span data-stu-id="bad9e-117">If using Visual C++ component extensions (C++/CX), nullable types are represented as [**Platform::IBox<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/jj606120.aspx).</span></span> <span data-ttu-id="bad9e-118">Microsoft .NET 言語を使う場合、null 許容型は [**Nullable<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx) として表されます。</span><span class="sxs-lookup"><span data-stu-id="bad9e-118">If using Microsoft .NET languages, nullable types are represented as [**Nullable<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx).</span></span>

## <a name="related-topics"></a><span data-ttu-id="bad9e-119">関連トピック</span><span class="sxs-lookup"><span data-stu-id="bad9e-119">Related topics</span></span>

* [**<span data-ttu-id="bad9e-120">Nullable</span><span class="sxs-lookup"><span data-stu-id="bad9e-120">Nullable</span></span><T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx)
* [**<span data-ttu-id="bad9e-121">IReference</span><span class="sxs-lookup"><span data-stu-id="bad9e-121">IReference</span></span><T>**](https://msdn.microsoft.com/library/windows/apps/br225864)
 

