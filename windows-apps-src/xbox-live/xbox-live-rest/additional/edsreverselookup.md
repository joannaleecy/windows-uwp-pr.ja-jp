---
title: ビデオの EDS 逆引き参照
assetID: 773f7a8e-7571-3aec-96d6-478437696ea6
permalink: en-us/docs/xboxlive/rest/edsreverselookup.html
author: KevinAsgari
description: " ビデオの EDS 逆引き参照"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e46bfb70ad377723694bfedb1dde0448564a97a8
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6192928"
---
# <a name="eds-reverse-lookup-for-video"></a><span data-ttu-id="5622c-104">ビデオの EDS 逆引き参照</span><span class="sxs-lookup"><span data-stu-id="5622c-104">EDS Reverse Lookup for Video</span></span>
 
  * [<span data-ttu-id="5622c-105">逆の検索手順</span><span class="sxs-lookup"><span data-stu-id="5622c-105">Reverse Lookup steps</span></span>](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="reverse-lookup-steps"></a><span data-ttu-id="5622c-106">逆の検索手順</span><span class="sxs-lookup"><span data-stu-id="5622c-106">Reverse Lookup steps</span></span>
 
<span data-ttu-id="5622c-107">すべてのビデオ メディアの種類 (**MediaItemType.Movie**、 **MediaItemType.TVSeries**、 **MediaItemType.TVEpisode**、 **MediaItemType.TVSeason**、および**エンターテイメント探索サービス (EDS) の逆引き参照がサポートされています。MediaItemType.TVShow**)、および**MediaItemType.Unknown**します。</span><span class="sxs-lookup"><span data-stu-id="5622c-107">Entertainment Discovery Services (EDS) Reverse Lookup is supported for all Video media types (**MediaItemType.Movie**, **MediaItemType.TVSeries**, **MediaItemType.TVEpisode**, **MediaItemType.TVSeason**, and **MediaItemType.TVShow**), as well as **MediaItemType.Unknown**.</span></span>
 
<span data-ttu-id="5622c-108">逆引き参照では、4 つのパラメーターを渡すことが必要です。</span><span class="sxs-lookup"><span data-stu-id="5622c-108">Reverse lookup requires 4 parameters to be passed:</span></span> 
   * `idType=ScopedMediaId`
   * `ids=` <span data-ttu-id="5622c-109">プロバイダーのメディア ID</span><span class="sxs-lookup"><span data-stu-id="5622c-109">the provider media ID</span></span>
   * `ScopeIdType=Title`
   * `ScopeId=` <span data-ttu-id="5622c-110">プロバイダーのタイトル ID</span><span class="sxs-lookup"><span data-stu-id="5622c-110">the provider title ID</span></span>
 
 
<span data-ttu-id="5622c-111">通常の逆引き参照では、2 つの手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="5622c-111">Usually the reverse lookup requires 2 steps:</span></span> 
   * <span data-ttu-id="5622c-112">利用できない場合 (たとえば、詳細呼び出し) からプロバイダー メディアの id を取得します。</span><span class="sxs-lookup"><span data-stu-id="5622c-112">Retrieve provider media id (for example, from a details call) if it's not available.</span></span> 

```cpp
GET /media/en-us/details?ids=4eeaf5b4-9af2-56e4-a738-68b48e954494&desiredMediaItemTypes=Movie&desired=Providers
```

 
   * <span data-ttu-id="5622c-113">以前の応答から**ProviderMediaId**フィールドを使用した逆引き参照の呼び出しを発行するには。</span><span class="sxs-lookup"><span data-stu-id="5622c-113">Issue the call for reverse lookup using the **ProviderMediaId** field from the previous response:</span></span> 

```cpp
GET /media/en-us/details?ids=047d19ca-3a7d-462c-bdbb-163543125583&idType=ScopedMediaId&desiredMediaItemTypes=Movie&fields=all&ScopeIdType=Title&ScopeId=0x5848085B
```

 
  
 
<span data-ttu-id="5622c-114">**ProviderMediaId**フィールドが EDS から取得されていない場合、フィールドは、EDS に正しく渡される URL エンコードである必要があります。</span><span class="sxs-lookup"><span data-stu-id="5622c-114">If the **ProviderMediaId** field has not been retrieved from EDS then the field must be URL-encoded to be passed correctly to EDS.</span></span>
  
<a id="ID4EOC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5622c-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="5622c-115">See also</span></span>
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5622c-116">Parent</span><span class="sxs-lookup"><span data-stu-id="5622c-116">Parent</span></span>  

[<span data-ttu-id="5622c-117">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="5622c-117">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4E3C"></a>

 
##### <a name="further-information"></a><span data-ttu-id="5622c-118">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5622c-118">Further Information</span></span> 

[<span data-ttu-id="5622c-119">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="5622c-119">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   