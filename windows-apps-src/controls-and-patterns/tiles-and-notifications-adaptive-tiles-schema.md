---
author: mijacobs
Description: "アダプティブ タイルの作成に使う要素と属性を次に示します。"
title: "アダプティブ タイル スキーマとテンプレート"
ms.assetid: 858FB05E-87A2-49CF-BE48-570980AD36C8
label: Adaptive tile schema and templates
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: ae33540e8b088fc68841b95115ae9c6cda20a662
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="adaptive-tile-templates-schema-and-guidance"></a><span data-ttu-id="fdaec-104">アダプティブ タイル テンプレート: スキーマとガイダンス</span><span class="sxs-lookup"><span data-stu-id="fdaec-104">Adaptive tile templates: schema and guidance</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="fdaec-105">アダプティブ タイルの作成に使う要素と属性を次に示します。</span><span class="sxs-lookup"><span data-stu-id="fdaec-105">Here are the elements and attributes you use to create adaptive tiles.</span></span> <span data-ttu-id="fdaec-106">手順と例については、「[アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fdaec-106">For instructions and examples, see [Create adaptive tiles](tiles-and-notifications-create-adaptive-tiles.md).</span></span>

## <a name="tile-element"></a><span data-ttu-id="fdaec-107">tile 要素</span><span class="sxs-lookup"><span data-stu-id="fdaec-107">tile element</span></span>


``` xml
<tile>
  
  <!-- Child elements -->
  visual
  
</tile>
```

## <a name="visual-element"></a><span data-ttu-id="fdaec-108">visual 要素</span><span class="sxs-lookup"><span data-stu-id="fdaec-108">visual element</span></span>


``` xml
<visual
  version? = integer
  lang? = string
  baseUri? = anyURI
  branding? = "none" | "logo" | "name" | "nameAndLogo"
  addImageQuery? = boolean
  contentId? = string
  displayName? = string >
    
  <!-- Child elements -->
  binding+

</visual>
```

## <a name="binding-element"></a><span data-ttu-id="fdaec-109">binding 要素</span><span class="sxs-lookup"><span data-stu-id="fdaec-109">binding element</span></span>


``` xml
<binding
  template = tileTemplateNameV3
  fallback? = tileTemplateNameV1
  lang? = string
  baseUri? = anyURI
  branding? = "none" | "logo" | "name" | "nameAndLogo"
  addImageQuery? = boolean
  contentId? = string
  displayName? = string
  hint-textStacking? = "top" | "center" | "bottom"
  hint-overlay? = [0-100] >

  <!-- Child elements -->
  ( image
  | text
  | group
  )*

</binding>
```

## <a name="image-element"></a><span data-ttu-id="fdaec-110">image 要素</span><span class="sxs-lookup"><span data-stu-id="fdaec-110">image element</span></span>


``` xml
<image
  src = string
  placement? = "inline" | "background" | "peek"
  alt? = string
  addImageQuery? = boolean
  hint-crop? = "none" | "circle"
  hint-removeMargin? = boolean
  hint-align? = "stretch" | "left" | "center" | "right" />
```

## <a name="text-element"></a><span data-ttu-id="fdaec-111">text 要素</span><span class="sxs-lookup"><span data-stu-id="fdaec-111">text element</span></span>


``` xml
<text
  lang? = string
  hint-style? = textStyle
  hint-wrap? = boolean
  hint-maxLines? = integer
  hint-minLines? = integer
  hint-align? = "left" | "center" | "right" >

  <!-- text goes here -->

</text>
```

<span data-ttu-id="fdaec-112">textStyle の値: caption captionSubtle body bodySubtle base baseSubtle subtitle subtitleSubtle title titleSubtle titleNumeral subheader subheaderSubtle subheaderNumeral header headerSubtle headerNumeral</span><span class="sxs-lookup"><span data-stu-id="fdaec-112">textStyle values: caption captionSubtle body bodySubtle base baseSubtle subtitle subtitleSubtle title titleSubtle titleNumeral subheader subheaderSubtle subheaderNumeral header headerSubtle headerNumeral</span></span>

## <a name="group-element"></a><span data-ttu-id="fdaec-113">group 要素</span><span class="sxs-lookup"><span data-stu-id="fdaec-113">group element</span></span>


``` xml
<group>

  <!-- Child elements -->
  subgroup+

</group>
```

## <a name="subgroup-element"></a><span data-ttu-id="fdaec-114">subgroup 要素</span><span class="sxs-lookup"><span data-stu-id="fdaec-114">subgroup element</span></span>


``` xml
<subgroup
  hint-weight? = [0-100]
  hint-textStacking? = "top" | "center" | "bottom" >

  <!-- Child elements -->
  ( text
  | image
  )*

</subgroup>
```

## <a name="related-topics"></a><span data-ttu-id="fdaec-115">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fdaec-115">Related topics</span></span>


* [<span data-ttu-id="fdaec-116">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="fdaec-116">Create adaptive tiles</span></span>](tiles-and-notifications-create-adaptive-tiles.md)
 

 




