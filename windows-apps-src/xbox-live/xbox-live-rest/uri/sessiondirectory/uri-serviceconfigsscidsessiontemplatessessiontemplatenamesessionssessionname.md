---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}
assetID: 55ce6459-1714-49bc-6231-b547ddf04143
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 43054e909ce6e4a3d472a6a6480cd0812afa5ad4
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4562945"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="224a8-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="224a8-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>
<span data-ttu-id="224a8-105">作成してセッションを取得する PUT と取得の操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="224a8-105">Supports PUT and GET operations to create and retrieve sessions.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="224a8-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="224a8-106">Domain</span></span>
<span data-ttu-id="224a8-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="224a8-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="224a8-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="224a8-108">URI parameters</span></span>

| <span data-ttu-id="224a8-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="224a8-109">Parameter</span></span>| <span data-ttu-id="224a8-110">型</span><span class="sxs-lookup"><span data-stu-id="224a8-110">Type</span></span>| <span data-ttu-id="224a8-111">説明</span><span class="sxs-lookup"><span data-stu-id="224a8-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="224a8-112">scid</span><span class="sxs-lookup"><span data-stu-id="224a8-112">scid</span></span>| <span data-ttu-id="224a8-113">GUID</span><span class="sxs-lookup"><span data-stu-id="224a8-113">GUID</span></span>| <span data-ttu-id="224a8-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="224a8-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="224a8-115">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="224a8-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="224a8-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="224a8-116">sessionTemplateName</span></span>| <span data-ttu-id="224a8-117">string</span><span class="sxs-lookup"><span data-stu-id="224a8-117">string</span></span>| <span data-ttu-id="224a8-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="224a8-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="224a8-119">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="224a8-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="224a8-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="224a8-120">sessionName</span></span>| <span data-ttu-id="224a8-121">GUID</span><span class="sxs-lookup"><span data-stu-id="224a8-121">GUID</span></span>| <span data-ttu-id="224a8-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="224a8-122">Unique ID of the session.</span></span> <span data-ttu-id="224a8-123">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="224a8-123">Part 3 of the session identifier.</span></span>| 

<a id="ID4EBC"></a>


## <a name="valid-methods"></a><span data-ttu-id="224a8-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="224a8-124">Valid methods</span></span>

[<span data-ttu-id="224a8-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="224a8-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.md)

<span data-ttu-id="224a8-126">&nbsp;&nbsp;セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="224a8-126">&nbsp;&nbsp;Gets a session object.</span></span>

[<span data-ttu-id="224a8-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="224a8-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

<span data-ttu-id="224a8-128">&nbsp;&nbsp;作成、更新、またはセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="224a8-128">&nbsp;&nbsp;Creates, updates, or joins a session.</span></span>

<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="224a8-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="224a8-129">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="224a8-130">Parent</span><span class="sxs-lookup"><span data-stu-id="224a8-130">Parent</span></span>

[<span data-ttu-id="224a8-131">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="224a8-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
