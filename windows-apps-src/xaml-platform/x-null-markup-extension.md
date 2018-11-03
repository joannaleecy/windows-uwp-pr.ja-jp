---
author: jwmsft
description: XAML マークアップで、プロパティに null 値を指定します。
title: xNull マークアップ拡張
ms.assetid: E6A4038E-4ADA-4E82-9824-582FC16AB037
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b6033a01ee811977b3a37f820217005fdbd80616
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5996329"
---
# <a name="xnull-markup-extension"></a><span data-ttu-id="bcf2d-104">{x:Null} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="bcf2d-104">{x:Null} markup extension</span></span>


<span data-ttu-id="bcf2d-105">XAML マークアップで、プロパティに **null** 値を指定します。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-105">In XAML markup, specifies a **null** value for a property.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="bcf2d-106">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="bcf2d-106">XAML attribute usage</span></span>

``` syntax
<object property="{x:Null}" .../>
```

## <a name="remarks"></a><span data-ttu-id="bcf2d-107">注釈</span><span class="sxs-lookup"><span data-stu-id="bcf2d-107">Remarks</span></span>

<span data-ttu-id="bcf2d-108">**null** は、C# と C++ の null 参照キーワードです。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-108">**null** is the null reference keyword for C# and C++.</span></span> <span data-ttu-id="bcf2d-109">Microsoft Visual Basic の null 参照キーワードは **Nothing** です。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-109">The Microsoft Visual Basic keyword for a null reference is **Nothing**.</span></span>

<span data-ttu-id="bcf2d-110">初期の既定値は、依存関係プロパティごとに異なる場合があり、必ずしも **null** というわけではありません。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-110">The initial default value can vary between dependency properties, and it is not necessarily **null**.</span></span> <span data-ttu-id="bcf2d-111">また、依存関係プロパティの多くは、その内部実装により、(マークアップまたはコードのいずれによる場合でも) **null** を値として受け入れません。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-111">Further, many dependency properties will not accept **null** as a value (whether through markup or code) due to their internal implementation.</span></span> <span data-ttu-id="bcf2d-112">このような場合、**{x:Null}** で XAML 属性値を設定すると、パーサー例外が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-112">In such cases, setting a XAML attribute value with **{x:Null}** can result in a parser exception.</span></span>

<span data-ttu-id="bcf2d-113">一部の Windows ランタイム型では、null を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-113">Some Windows Runtime types are nullable.</span></span> <span data-ttu-id="bcf2d-114">null 許容型に **null** が既定値として設定されていない場合に備え、**{x:Null}** を使って XAML 内で **null** 値に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-114">In cases where a nullable type does not already have **null** as the default, you could use **{x:Null}** in XAML to set to the **null** value.</span></span> <span data-ttu-id="bcf2d-115">VisualC ではコンポーネント拡張機能を使用する場合 (、C++/cli CX)、null 許容型として表されます[**platform::ibox<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/jj606120.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-115">If using VisualC++ component extensions (C++/CX), nullable types are represented as [**Platform::IBox<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/jj606120.aspx).</span></span> <span data-ttu-id="bcf2d-116">Microsoft .NET 言語を使う場合、null 許容型は [**Nullable<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx) として表されます。</span><span class="sxs-lookup"><span data-stu-id="bcf2d-116">If using Microsoft .NET languages, nullable types are represented as [**Nullable<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx).</span></span>

## <a name="related-topics"></a><span data-ttu-id="bcf2d-117">関連トピック</span><span class="sxs-lookup"><span data-stu-id="bcf2d-117">Related topics</span></span>

* [**<span data-ttu-id="bcf2d-118">Nullable</span><span class="sxs-lookup"><span data-stu-id="bcf2d-118">Nullable</span></span><T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx)
* [**<span data-ttu-id="bcf2d-119">IReference</span><span class="sxs-lookup"><span data-stu-id="bcf2d-119">IReference</span></span><T>**](https://msdn.microsoft.com/library/windows/apps/br225864)
 

