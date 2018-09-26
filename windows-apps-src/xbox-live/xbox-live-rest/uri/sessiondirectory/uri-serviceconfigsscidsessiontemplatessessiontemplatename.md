---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}
assetID: cc306ca0-57f8-f676-6d4b-f9ddd716dcc0
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatename.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d1bf7735fabbc08f723dbaf77a020b205f66584d
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4175626"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatename"></a><span data-ttu-id="8b7ca-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span><span class="sxs-lookup"><span data-stu-id="8b7ca-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span></span>
<span data-ttu-id="8b7ca-105">セッション テンプレート名のセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="8b7ca-105">Supports a GET operation to retrieve a set of session template names.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="8b7ca-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="8b7ca-106">Domain</span></span>
<span data-ttu-id="8b7ca-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="8b7ca-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="8b7ca-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b7ca-108">URI parameters</span></span>
 
| <span data-ttu-id="8b7ca-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b7ca-109">Parameter</span></span>| <span data-ttu-id="8b7ca-110">型</span><span class="sxs-lookup"><span data-stu-id="8b7ca-110">Type</span></span>| <span data-ttu-id="8b7ca-111">説明</span><span class="sxs-lookup"><span data-stu-id="8b7ca-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8b7ca-112">scid</span><span class="sxs-lookup"><span data-stu-id="8b7ca-112">scid</span></span>| <span data-ttu-id="8b7ca-113">GUID</span><span class="sxs-lookup"><span data-stu-id="8b7ca-113">GUID</span></span>| <span data-ttu-id="8b7ca-114">サービス構成の識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="8b7ca-114">Service configuration identifer (SCID).</span></span> <span data-ttu-id="8b7ca-115">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="8b7ca-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="8b7ca-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="8b7ca-116">sessionTemplateName</span></span>| <span data-ttu-id="8b7ca-117">string</span><span class="sxs-lookup"><span data-stu-id="8b7ca-117">string</span></span>| <span data-ttu-id="8b7ca-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="8b7ca-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="8b7ca-119">パート 2 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="8b7ca-119">Part 2 of the session ID.</span></span> | 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="8b7ca-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="8b7ca-120">Valid methods</span></span>

[<span data-ttu-id="8b7ca-121">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})</span><span class="sxs-lookup"><span data-stu-id="8b7ca-121">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenameget.md)

<span data-ttu-id="8b7ca-122">&nbsp;&nbsp;セッション テンプレートの名前のセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="8b7ca-122">&nbsp;&nbsp;Retrieves a set of session template names.</span></span>
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="8b7ca-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="8b7ca-123">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="8b7ca-124">Parent</span><span class="sxs-lookup"><span data-stu-id="8b7ca-124">Parent</span></span> 

[<span data-ttu-id="8b7ca-125">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="8b7ca-125">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   