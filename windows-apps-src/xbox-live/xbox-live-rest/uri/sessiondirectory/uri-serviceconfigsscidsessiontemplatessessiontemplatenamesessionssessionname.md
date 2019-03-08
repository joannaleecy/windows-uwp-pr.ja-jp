---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}
assetID: 55ce6459-1714-49bc-6231-b547ddf04143
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.html
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: da8d61634d0a849d51e2ab6ff143469ec05cc75c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57657477"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="cd50e-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="cd50e-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>
<span data-ttu-id="cd50e-105">作成およびセッションを取得する PUT および GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="cd50e-105">Supports PUT and GET operations to create and retrieve sessions.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="cd50e-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="cd50e-106">Domain</span></span>
<span data-ttu-id="cd50e-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="cd50e-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="cd50e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd50e-108">URI parameters</span></span>

| <span data-ttu-id="cd50e-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd50e-109">Parameter</span></span>| <span data-ttu-id="cd50e-110">種類</span><span class="sxs-lookup"><span data-stu-id="cd50e-110">Type</span></span>| <span data-ttu-id="cd50e-111">説明</span><span class="sxs-lookup"><span data-stu-id="cd50e-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="cd50e-112">scid</span><span class="sxs-lookup"><span data-stu-id="cd50e-112">scid</span></span>| <span data-ttu-id="cd50e-113">GUID</span><span class="sxs-lookup"><span data-stu-id="cd50e-113">GUID</span></span>| <span data-ttu-id="cd50e-114">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="cd50e-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="cd50e-115">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="cd50e-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="cd50e-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="cd50e-116">sessionTemplateName</span></span>| <span data-ttu-id="cd50e-117">string</span><span class="sxs-lookup"><span data-stu-id="cd50e-117">string</span></span>| <span data-ttu-id="cd50e-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="cd50e-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="cd50e-119">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="cd50e-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="cd50e-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="cd50e-120">sessionName</span></span>| <span data-ttu-id="cd50e-121">GUID</span><span class="sxs-lookup"><span data-stu-id="cd50e-121">GUID</span></span>| <span data-ttu-id="cd50e-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="cd50e-122">Unique ID of the session.</span></span> <span data-ttu-id="cd50e-123">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="cd50e-123">Part 3 of the session identifier.</span></span>| 

<a id="ID4EBC"></a>


## <a name="valid-methods"></a><span data-ttu-id="cd50e-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cd50e-124">Valid methods</span></span>

[<span data-ttu-id="cd50e-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="cd50e-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.md)

<span data-ttu-id="cd50e-126">&nbsp;&nbsp;セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="cd50e-126">&nbsp;&nbsp;Gets a session object.</span></span>

[<span data-ttu-id="cd50e-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="cd50e-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

<span data-ttu-id="cd50e-128">&nbsp;&nbsp;作成、更新、またはセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="cd50e-128">&nbsp;&nbsp;Creates, updates, or joins a session.</span></span>

<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="cd50e-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="cd50e-129">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="cd50e-130">Parent</span><span class="sxs-lookup"><span data-stu-id="cd50e-130">Parent</span></span>

[<span data-ttu-id="cd50e-131">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="cd50e-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
