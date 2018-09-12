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
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3928715"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatename"></a><span data-ttu-id="bcbf3-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span><span class="sxs-lookup"><span data-stu-id="bcbf3-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span></span>
<span data-ttu-id="bcbf3-105">セッション テンプレート名のセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="bcbf3-105">Supports a GET operation to retrieve a set of session template names.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="bcbf3-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="bcbf3-106">Domain</span></span>
<span data-ttu-id="bcbf3-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="bcbf3-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bcbf3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bcbf3-108">URI parameters</span></span>
 
| <span data-ttu-id="bcbf3-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bcbf3-109">Parameter</span></span>| <span data-ttu-id="bcbf3-110">型</span><span class="sxs-lookup"><span data-stu-id="bcbf3-110">Type</span></span>| <span data-ttu-id="bcbf3-111">説明</span><span class="sxs-lookup"><span data-stu-id="bcbf3-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bcbf3-112">scid</span><span class="sxs-lookup"><span data-stu-id="bcbf3-112">scid</span></span>| <span data-ttu-id="bcbf3-113">GUID</span><span class="sxs-lookup"><span data-stu-id="bcbf3-113">GUID</span></span>| <span data-ttu-id="bcbf3-114">サービス構成の識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="bcbf3-114">Service configuration identifer (SCID).</span></span> <span data-ttu-id="bcbf3-115">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="bcbf3-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="bcbf3-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="bcbf3-116">sessionTemplateName</span></span>| <span data-ttu-id="bcbf3-117">string</span><span class="sxs-lookup"><span data-stu-id="bcbf3-117">string</span></span>| <span data-ttu-id="bcbf3-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="bcbf3-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="bcbf3-119">パート 2、セッションの id。</span><span class="sxs-lookup"><span data-stu-id="bcbf3-119">Part 2 of the session ID.</span></span> | 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="bcbf3-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="bcbf3-120">Valid methods</span></span>

[<span data-ttu-id="bcbf3-121">(/Serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="bcbf3-121">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenameget.md)

<span data-ttu-id="bcbf3-122">&nbsp;&nbsp;セッション テンプレートの名前のセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="bcbf3-122">&nbsp;&nbsp;Retrieves a set of session template names.</span></span>
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bcbf3-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="bcbf3-123">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bcbf3-124">Parent</span><span class="sxs-lookup"><span data-stu-id="bcbf3-124">Parent</span></span> 

[<span data-ttu-id="bcbf3-125">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="bcbf3-125">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   