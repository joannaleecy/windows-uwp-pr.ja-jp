---
Description: Here are the elements and attributes you use to create adaptive tiles.
title: アダプティブ タイル スキーマとテンプレート
ms.assetid: 858FB05E-87A2-49CF-BE48-570980AD36C8
label: Adaptive tile schema and templates
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ed9124b0b66239c10b277f070ac2c9594c336fdd
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7970196"
---
# <a name="adaptive-tile-templates-schema-and-guidance"></a><span data-ttu-id="1c320-103">アダプティブ タイル テンプレート: スキーマとガイダンス</span><span class="sxs-lookup"><span data-stu-id="1c320-103">Adaptive tile templates: schema and guidance</span></span>

 

<span data-ttu-id="1c320-104">アダプティブ タイルの作成に使う要素と属性を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1c320-104">Here are the elements and attributes you use to create adaptive tiles.</span></span> <span data-ttu-id="1c320-105">手順と例については、「[アダプティブ タイルの作成](create-adaptive-tiles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1c320-105">For instructions and examples, see [Create adaptive tiles](create-adaptive-tiles.md).</span></span>

## <a name="tile-element"></a><span data-ttu-id="1c320-106">tile 要素</span><span class="sxs-lookup"><span data-stu-id="1c320-106">tile element</span></span>


``` xml
<tile>
  
  <!-- Child elements -->
  visual
  
</tile>
```

## <a name="visual-element"></a><span data-ttu-id="1c320-107">visual 要素</span><span class="sxs-lookup"><span data-stu-id="1c320-107">visual element</span></span>


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

## <a name="binding-element"></a><span data-ttu-id="1c320-108">binding 要素</span><span class="sxs-lookup"><span data-stu-id="1c320-108">binding element</span></span>


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

## <a name="image-element"></a><span data-ttu-id="1c320-109">image 要素</span><span class="sxs-lookup"><span data-stu-id="1c320-109">image element</span></span>


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

## <a name="text-element"></a><span data-ttu-id="1c320-110">text 要素</span><span class="sxs-lookup"><span data-stu-id="1c320-110">text element</span></span>


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

<span data-ttu-id="1c320-111">textStyle の値: caption captionSubtle body bodySubtle base baseSubtle subtitle subtitleSubtle title titleSubtle titleNumeral subheader subheaderSubtle subheaderNumeral header headerSubtle headerNumeral</span><span class="sxs-lookup"><span data-stu-id="1c320-111">textStyle values: caption captionSubtle body bodySubtle base baseSubtle subtitle subtitleSubtle title titleSubtle titleNumeral subheader subheaderSubtle subheaderNumeral header headerSubtle headerNumeral</span></span>

## <a name="group-element"></a><span data-ttu-id="1c320-112">group 要素</span><span class="sxs-lookup"><span data-stu-id="1c320-112">group element</span></span>


``` xml
<group>

  <!-- Child elements -->
  subgroup+

</group>
```

## <a name="subgroup-element"></a><span data-ttu-id="1c320-113">subgroup 要素</span><span class="sxs-lookup"><span data-stu-id="1c320-113">subgroup element</span></span>


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

## <a name="related-topics"></a><span data-ttu-id="1c320-114">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1c320-114">Related topics</span></span>


* [<span data-ttu-id="1c320-115">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="1c320-115">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
 

 




