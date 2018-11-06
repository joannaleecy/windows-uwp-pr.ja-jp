---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}
assetID: 55ce6459-1714-49bc-6231-b547ddf04143
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 84fd31c4dded819467bf5538183480bdfb9bdd04
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6028169"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="46378-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="46378-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>
<span data-ttu-id="46378-105">PUT と取得の操作を作成してセッションを取得をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="46378-105">Supports PUT and GET operations to create and retrieve sessions.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="46378-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="46378-106">Domain</span></span>
<span data-ttu-id="46378-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="46378-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="46378-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="46378-108">URI parameters</span></span>

| <span data-ttu-id="46378-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="46378-109">Parameter</span></span>| <span data-ttu-id="46378-110">型</span><span class="sxs-lookup"><span data-stu-id="46378-110">Type</span></span>| <span data-ttu-id="46378-111">説明</span><span class="sxs-lookup"><span data-stu-id="46378-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="46378-112">scid</span><span class="sxs-lookup"><span data-stu-id="46378-112">scid</span></span>| <span data-ttu-id="46378-113">GUID</span><span class="sxs-lookup"><span data-stu-id="46378-113">GUID</span></span>| <span data-ttu-id="46378-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="46378-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="46378-115">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="46378-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="46378-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="46378-116">sessionTemplateName</span></span>| <span data-ttu-id="46378-117">string</span><span class="sxs-lookup"><span data-stu-id="46378-117">string</span></span>| <span data-ttu-id="46378-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="46378-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="46378-119">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="46378-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="46378-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="46378-120">sessionName</span></span>| <span data-ttu-id="46378-121">GUID</span><span class="sxs-lookup"><span data-stu-id="46378-121">GUID</span></span>| <span data-ttu-id="46378-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="46378-122">Unique ID of the session.</span></span> <span data-ttu-id="46378-123">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="46378-123">Part 3 of the session identifier.</span></span>| 

<a id="ID4EBC"></a>


## <a name="valid-methods"></a><span data-ttu-id="46378-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="46378-124">Valid methods</span></span>

[<span data-ttu-id="46378-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="46378-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.md)

<span data-ttu-id="46378-126">&nbsp;&nbsp;セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="46378-126">&nbsp;&nbsp;Gets a session object.</span></span>

[<span data-ttu-id="46378-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="46378-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

<span data-ttu-id="46378-128">&nbsp;&nbsp;作成、更新、またはセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="46378-128">&nbsp;&nbsp;Creates, updates, or joins a session.</span></span>

<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="46378-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="46378-129">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="46378-130">Parent</span><span class="sxs-lookup"><span data-stu-id="46378-130">Parent</span></span>

[<span data-ttu-id="46378-131">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="46378-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
