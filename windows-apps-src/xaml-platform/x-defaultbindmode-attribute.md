---
author: jwmsft
description: XAML マークアップで、x:Bind の既定のモードを指定します。
title: xDefaultBindMode 属性
ms.author: jimwalk
ms.date: 02/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4eae77a51f925eaff27a7919ecfa60552d0fbae5
ms.sourcegitcommit: b8c77ac8e40a27cf762328d730c121c28de5fbc4
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2018
ms.locfileid: "1672979"
---
# <a name="xdefaultbindmode-attribute"></a><span data-ttu-id="f810e-104">x:DefaultBindMode 属性</span><span class="sxs-lookup"><span data-stu-id="f810e-104">x:DefaultBindMode attribute</span></span>

<span data-ttu-id="f810e-105">XAML マークアップで、x:Bind の既定のモードを指定します。</span><span class="sxs-lookup"><span data-stu-id="f810e-105">In XAML markup, specifies a default mode for x:Bind.</span></span>

<span data-ttu-id="f810e-106">**x:DefaultBindMode** は、Windows 10 バージョン 1607 (Anniversary Update) SDK バージョン 14393 以降で使用できます。</span><span class="sxs-lookup"><span data-stu-id="f810e-106">**x:DefaultBindMode** is available starting in Windows 10, version 1607 (Anniversary Update), SDK version 14393.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="f810e-107">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="f810e-107">XAML attribute usage</span></span>

``` syntax
<object x:DefaultBindMode="OneTime \| OneWay \| TwoWay" .../>
```

## <a name="remarks"></a><span data-ttu-id="f810e-108">注釈</span><span class="sxs-lookup"><span data-stu-id="f810e-108">Remarks</span></span>

<span data-ttu-id="f810e-109">[x:Bind](x-bind-markup-extension.md) の既定のモードは **OneTime** です。</span><span class="sxs-lookup"><span data-stu-id="f810e-109">[x:Bind](x-bind-markup-extension.md) has a default mode of **OneTime**.</span></span> <span data-ttu-id="f810e-110">これはパフォーマンス上の理由から選ばれました。**OneWay** を使うと、接続して変更検出を処理するために生成されるコードが多くなるためです。</span><span class="sxs-lookup"><span data-stu-id="f810e-110">This was chosen for performance reasons, as using **OneWay** causes more code to be generated to hookup and handle change detection.</span></span> <span data-ttu-id="f810e-111">マークアップ ツリーの特定のセグメントで x:Bind の既定のモードを変更するには、**x:DefaultBindMode** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f810e-111">You can use **x:DefaultBindMode** to change the default mode for x:Bind for a specific segment of the markup tree.</span></span> <span data-ttu-id="f810e-112">指定されたモードは、バインドの一部として明示的にモードが指定されている場合を除いて、対象の要素とその子に対するすべての x:Bind 式に適用されます。</span><span class="sxs-lookup"><span data-stu-id="f810e-112">The specified mode applies to any x:Bind expressions on that element and its children, that do not explicitly specify a mode as part of the binding.</span></span>

## <a name="related-topics"></a><span data-ttu-id="f810e-113">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f810e-113">Related topics</span></span>

* [<span data-ttu-id="f810e-114">x:Bind マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="f810e-114">x:Bind markup extension</span></span>](x-bind-markup-extension.md)
