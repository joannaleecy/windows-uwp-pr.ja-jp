---
description: XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定のプライベートの動作ではなくパブリック アクセスとして定義されるようにします。
title: xFieldModifier 属性
ms.assetid: 6FBCC00B-848D-4454-8B1F-287CA8406DDF
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 751cda36fc58d0e6add9204327a74ec947c9fc53
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8485976"
---
# <a name="xfieldmodifier-attribute"></a><span data-ttu-id="4a3cc-104">x:FieldModifier 属性</span><span class="sxs-lookup"><span data-stu-id="4a3cc-104">x:FieldModifier attribute</span></span>


<span data-ttu-id="4a3cc-105">XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定の**プライベート**の動作ではなく**パブリック** アクセスとして定義されるようにします。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-105">Modifies XAML compilation behavior, such that fields for named object references are defined with **public** access rather than the **private** default behavior.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="4a3cc-106">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="4a3cc-106">XAML attribute usage</span></span>

``` syntax
<object x:FieldModifier="public".../>
```

## <a name="dependencies"></a><span data-ttu-id="4a3cc-107">依存関係</span><span class="sxs-lookup"><span data-stu-id="4a3cc-107">Dependencies</span></span>

<span data-ttu-id="4a3cc-108">[x:Name attribute](x-name-attribute.md) は、同じ要素で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-108">[x:Name attribute](x-name-attribute.md) must also be provided on the same element.</span></span>

## <a name="remarks"></a><span data-ttu-id="4a3cc-109">注釈</span><span class="sxs-lookup"><span data-stu-id="4a3cc-109">Remarks</span></span>

<span data-ttu-id="4a3cc-110">**x:FieldModifier** 属性の値はプログラミング言語によって異なります。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-110">The value for the **x:FieldModifier** attribute will vary by programming language.</span></span> <span data-ttu-id="4a3cc-111">有効な値は、**private**、**public**、**protected**、**internal**、**friend** です。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-111">Valid values are **private**, **public**, **protected**, **internal** or **friend**.</span></span> <span data-ttu-id="4a3cc-112">C#、Microsoft Visual Basic または VisualC ではコンポーネント拡張機能 (、C++/cli CX)、文字列を提供する値"public"または"Public"パーサーには、この属性の値の大文字を区別しません。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-112">For C#, Microsoft Visual Basic or VisualC++ component extensions (C++/CX), you can give the string value "public" or "Public"; the parser doesn't enforce case on this attribute value.</span></span>

<span data-ttu-id="4a3cc-113">既定値は **Private** アクセスです。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-113">**Private** access is the default.</span></span>

<span data-ttu-id="4a3cc-114">**x:FieldModifier** は、[x:Name 属性](x-name-attribute.md)を含む要素にのみ関係します。なぜなら、この名前はパブリックであるときにのみフィールドを参照するために使われるためです。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-114">**x:FieldModifier** is only relevant for elements with an [x:Name attribute](x-name-attribute.md), because that name is used to reference the field once it is public.</span></span>

<span data-ttu-id="4a3cc-115">**注:** **X:classmodifier**または**X:subclass**Windows ランタイム XAML はサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="4a3cc-115">**Note**Windows Runtime XAML doesn't support **x:ClassModifier** or **x:Subclass**.</span></span>

