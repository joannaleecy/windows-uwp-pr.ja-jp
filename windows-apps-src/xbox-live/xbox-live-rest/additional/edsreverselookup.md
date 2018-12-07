---
title: ビデオの EDS 逆引き参照
assetID: 773f7a8e-7571-3aec-96d6-478437696ea6
permalink: en-us/docs/xboxlive/rest/edsreverselookup.html
description: " ビデオの EDS 逆引き参照"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d535dec8a95eba4d486bfc6946e187e2da66ae49
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8751998"
---
# <a name="eds-reverse-lookup-for-video"></a><span data-ttu-id="4ee86-104">ビデオの EDS 逆引き参照</span><span class="sxs-lookup"><span data-stu-id="4ee86-104">EDS Reverse Lookup for Video</span></span>
 
  * [<span data-ttu-id="4ee86-105">逆の検索手順</span><span class="sxs-lookup"><span data-stu-id="4ee86-105">Reverse Lookup steps</span></span>](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="reverse-lookup-steps"></a><span data-ttu-id="4ee86-106">逆の検索手順</span><span class="sxs-lookup"><span data-stu-id="4ee86-106">Reverse Lookup steps</span></span>
 
<span data-ttu-id="4ee86-107">すべてのビデオ メディアの種類 (**MediaItemType.Movie**、 **MediaItemType.TVSeries**、 **MediaItemType.TVEpisode**、 **MediaItemType.TVSeason**、および**エンターテイメント探索サービス (EDS) の逆引き参照がサポートされています。MediaItemType.TVShow**)、および**MediaItemType.Unknown**します。</span><span class="sxs-lookup"><span data-stu-id="4ee86-107">Entertainment Discovery Services (EDS) Reverse Lookup is supported for all Video media types (**MediaItemType.Movie**, **MediaItemType.TVSeries**, **MediaItemType.TVEpisode**, **MediaItemType.TVSeason**, and **MediaItemType.TVShow**), as well as **MediaItemType.Unknown**.</span></span>
 
<span data-ttu-id="4ee86-108">逆引き参照では、4 つのパラメーターを渡すことが必要です。</span><span class="sxs-lookup"><span data-stu-id="4ee86-108">Reverse lookup requires 4 parameters to be passed:</span></span> 
   * `idType=ScopedMediaId`
   * `ids=` <span data-ttu-id="4ee86-109">プロバイダーのメディア ID</span><span class="sxs-lookup"><span data-stu-id="4ee86-109">the provider media ID</span></span>
   * `ScopeIdType=Title`
   * `ScopeId=` <span data-ttu-id="4ee86-110">プロバイダーのタイトル ID</span><span class="sxs-lookup"><span data-stu-id="4ee86-110">the provider title ID</span></span>
 
 
<span data-ttu-id="4ee86-111">通常の逆引き参照では、2 つの手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="4ee86-111">Usually the reverse lookup requires 2 steps:</span></span> 
   * <span data-ttu-id="4ee86-112">利用できない場合 (たとえば、詳細呼び出し) からプロバイダー メディアの id を取得します。</span><span class="sxs-lookup"><span data-stu-id="4ee86-112">Retrieve provider media id (for example, from a details call) if it's not available.</span></span> 

```cpp
GET /media/en-us/details?ids=4eeaf5b4-9af2-56e4-a738-68b48e954494&desiredMediaItemTypes=Movie&desired=Providers
```

 
   * <span data-ttu-id="4ee86-113">以前の応答から**ProviderMediaId**フィールドを使用して逆引き参照の呼び出しを発行します。</span><span class="sxs-lookup"><span data-stu-id="4ee86-113">Issue the call for reverse lookup using the **ProviderMediaId** field from the previous response:</span></span> 

```cpp
GET /media/en-us/details?ids=047d19ca-3a7d-462c-bdbb-163543125583&idType=ScopedMediaId&desiredMediaItemTypes=Movie&fields=all&ScopeIdType=Title&ScopeId=0x5848085B
```

 
  
 
<span data-ttu-id="4ee86-114">**ProviderMediaId**フィールドが EDS から取得されていない場合、フィールドは、EDS に正しく渡される URL エンコードである必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ee86-114">If the **ProviderMediaId** field has not been retrieved from EDS then the field must be URL-encoded to be passed correctly to EDS.</span></span>
  
<a id="ID4EOC"></a>

 
## <a name="see-also"></a><span data-ttu-id="4ee86-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="4ee86-115">See also</span></span>
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4ee86-116">Parent</span><span class="sxs-lookup"><span data-stu-id="4ee86-116">Parent</span></span>  

[<span data-ttu-id="4ee86-117">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="4ee86-117">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4E3C"></a>

 
##### <a name="further-information"></a><span data-ttu-id="4ee86-118">詳細情報</span><span class="sxs-lookup"><span data-stu-id="4ee86-118">Further Information</span></span> 

[<span data-ttu-id="4ee86-119">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="4ee86-119">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   