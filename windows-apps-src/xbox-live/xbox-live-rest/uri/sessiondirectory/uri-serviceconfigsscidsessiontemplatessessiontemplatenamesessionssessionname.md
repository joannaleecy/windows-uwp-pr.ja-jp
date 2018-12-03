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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8339121"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="e84ac-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="e84ac-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>
<span data-ttu-id="e84ac-105">作成してセッションを取得する PUT と取得の操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e84ac-105">Supports PUT and GET operations to create and retrieve sessions.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="e84ac-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="e84ac-106">Domain</span></span>
<span data-ttu-id="e84ac-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="e84ac-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="e84ac-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e84ac-108">URI parameters</span></span>

| <span data-ttu-id="e84ac-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e84ac-109">Parameter</span></span>| <span data-ttu-id="e84ac-110">型</span><span class="sxs-lookup"><span data-stu-id="e84ac-110">Type</span></span>| <span data-ttu-id="e84ac-111">説明</span><span class="sxs-lookup"><span data-stu-id="e84ac-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="e84ac-112">scid</span><span class="sxs-lookup"><span data-stu-id="e84ac-112">scid</span></span>| <span data-ttu-id="e84ac-113">GUID</span><span class="sxs-lookup"><span data-stu-id="e84ac-113">GUID</span></span>| <span data-ttu-id="e84ac-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="e84ac-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="e84ac-115">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="e84ac-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="e84ac-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="e84ac-116">sessionTemplateName</span></span>| <span data-ttu-id="e84ac-117">string</span><span class="sxs-lookup"><span data-stu-id="e84ac-117">string</span></span>| <span data-ttu-id="e84ac-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="e84ac-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="e84ac-119">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="e84ac-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="e84ac-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="e84ac-120">sessionName</span></span>| <span data-ttu-id="e84ac-121">GUID</span><span class="sxs-lookup"><span data-stu-id="e84ac-121">GUID</span></span>| <span data-ttu-id="e84ac-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="e84ac-122">Unique ID of the session.</span></span> <span data-ttu-id="e84ac-123">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="e84ac-123">Part 3 of the session identifier.</span></span>| 

<a id="ID4EBC"></a>


## <a name="valid-methods"></a><span data-ttu-id="e84ac-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e84ac-124">Valid methods</span></span>

[<span data-ttu-id="e84ac-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="e84ac-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.md)

<span data-ttu-id="e84ac-126">&nbsp;&nbsp;セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="e84ac-126">&nbsp;&nbsp;Gets a session object.</span></span>

[<span data-ttu-id="e84ac-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="e84ac-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

<span data-ttu-id="e84ac-128">&nbsp;&nbsp;作成、更新、またはセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="e84ac-128">&nbsp;&nbsp;Creates, updates, or joins a session.</span></span>

<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="e84ac-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="e84ac-129">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="e84ac-130">Parent</span><span class="sxs-lookup"><span data-stu-id="e84ac-130">Parent</span></span>

[<span data-ttu-id="e84ac-131">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="e84ac-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
