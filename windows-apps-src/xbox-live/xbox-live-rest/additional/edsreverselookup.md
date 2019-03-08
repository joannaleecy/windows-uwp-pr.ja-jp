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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598437"
---
# <a name="eds-reverse-lookup-for-video"></a><span data-ttu-id="3d8f1-104">ビデオの EDS 逆引き参照</span><span class="sxs-lookup"><span data-stu-id="3d8f1-104">EDS Reverse Lookup for Video</span></span>
 
  * [<span data-ttu-id="3d8f1-105">逆引き参照手順</span><span class="sxs-lookup"><span data-stu-id="3d8f1-105">Reverse Lookup steps</span></span>](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="reverse-lookup-steps"></a><span data-ttu-id="3d8f1-106">逆引き参照手順</span><span class="sxs-lookup"><span data-stu-id="3d8f1-106">Reverse Lookup steps</span></span>
 
<span data-ttu-id="3d8f1-107">すべてのビデオ メディアの種類のエンターテイメント検出サービス (EDS) の逆引き参照がサポートされています (**MediaItemType.Movie**、 **MediaItemType.TVSeries**、 **MediaItemType.TVEpisode**、 **MediaItemType.TVSeason**、および**MediaItemType.TVShow**)、および**MediaItemType.Unknown**します。</span><span class="sxs-lookup"><span data-stu-id="3d8f1-107">Entertainment Discovery Services (EDS) Reverse Lookup is supported for all Video media types (**MediaItemType.Movie**, **MediaItemType.TVSeries**, **MediaItemType.TVEpisode**, **MediaItemType.TVSeason**, and **MediaItemType.TVShow**), as well as **MediaItemType.Unknown**.</span></span>
 
<span data-ttu-id="3d8f1-108">逆引き参照では、渡される 4 つのパラメーターが必要です。</span><span class="sxs-lookup"><span data-stu-id="3d8f1-108">Reverse lookup requires 4 parameters to be passed:</span></span> 
   * `idType=ScopedMediaId`
   * <span data-ttu-id="3d8f1-109">`ids=` プロバイダーのメディア ID</span><span class="sxs-lookup"><span data-stu-id="3d8f1-109">`ids=` the provider media ID</span></span>
   * `ScopeIdType=Title`
   * <span data-ttu-id="3d8f1-110">`ScopeId=` プロバイダー ID のタイトル</span><span class="sxs-lookup"><span data-stu-id="3d8f1-110">`ScopeId=` the provider title ID</span></span>
 
 
<span data-ttu-id="3d8f1-111">通常、逆引き参照では、2 つの手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="3d8f1-111">Usually the reverse lookup requires 2 steps:</span></span> 
   * <span data-ttu-id="3d8f1-112">使用できない場合 (たとえば、詳細の呼び出し) からプロバイダー メディア id を取得します。</span><span class="sxs-lookup"><span data-stu-id="3d8f1-112">Retrieve provider media id (for example, from a details call) if it's not available.</span></span> 

```cpp
GET /media/en-us/details?ids=4eeaf5b4-9af2-56e4-a738-68b48e954494&desiredMediaItemTypes=Movie&desired=Providers
```

 
   * <span data-ttu-id="3d8f1-113">逆引き参照を使用するための呼び出しを発行、 **ProviderMediaId**前の応答からフィールド。</span><span class="sxs-lookup"><span data-stu-id="3d8f1-113">Issue the call for reverse lookup using the **ProviderMediaId** field from the previous response:</span></span> 

```cpp
GET /media/en-us/details?ids=047d19ca-3a7d-462c-bdbb-163543125583&idType=ScopedMediaId&desiredMediaItemTypes=Movie&fields=all&ScopeIdType=Title&ScopeId=0x5848085B
```

 
  
 
<span data-ttu-id="3d8f1-114">場合、 **ProviderMediaId** EDS からフィールドが取得されていないし、フィールドは、EDS に正しく渡す URL エンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d8f1-114">If the **ProviderMediaId** field has not been retrieved from EDS then the field must be URL-encoded to be passed correctly to EDS.</span></span>
  
<a id="ID4EOC"></a>

 
## <a name="see-also"></a><span data-ttu-id="3d8f1-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="3d8f1-115">See also</span></span>
 
<a id="ID4EQC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3d8f1-116">Parent</span><span class="sxs-lookup"><span data-stu-id="3d8f1-116">Parent</span></span>  

[<span data-ttu-id="3d8f1-117">その他の参照</span><span class="sxs-lookup"><span data-stu-id="3d8f1-117">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4E3C"></a>

 
##### <a name="further-information"></a><span data-ttu-id="3d8f1-118">詳細情報</span><span class="sxs-lookup"><span data-stu-id="3d8f1-118">Further Information</span></span> 

[<span data-ttu-id="3d8f1-119">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="3d8f1-119">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   