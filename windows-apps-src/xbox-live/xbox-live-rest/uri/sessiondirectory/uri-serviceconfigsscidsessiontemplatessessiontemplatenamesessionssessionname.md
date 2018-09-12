---
title: /serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}
assetID: 55ce6459-1714-49bc-6231-b547ddf04143
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.html
author: KevinAsgari
description: " /serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 43054e909ce6e4a3d472a6a6480cd0812afa5ad4
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881545"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="3c72d-104">/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}</span><span class="sxs-lookup"><span data-stu-id="3c72d-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>
<span data-ttu-id="3c72d-105">作成してセッションを取得する PUT を取得する操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="3c72d-105">Supports PUT and GET operations to create and retrieve sessions.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="3c72d-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="3c72d-106">Domain</span></span>
<span data-ttu-id="3c72d-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="3c72d-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="3c72d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3c72d-108">URI parameters</span></span>

| <span data-ttu-id="3c72d-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3c72d-109">Parameter</span></span>| <span data-ttu-id="3c72d-110">型</span><span class="sxs-lookup"><span data-stu-id="3c72d-110">Type</span></span>| <span data-ttu-id="3c72d-111">説明</span><span class="sxs-lookup"><span data-stu-id="3c72d-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="3c72d-112">scid</span><span class="sxs-lookup"><span data-stu-id="3c72d-112">scid</span></span>| <span data-ttu-id="3c72d-113">GUID</span><span class="sxs-lookup"><span data-stu-id="3c72d-113">GUID</span></span>| <span data-ttu-id="3c72d-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="3c72d-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="3c72d-115">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="3c72d-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="3c72d-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="3c72d-116">sessionTemplateName</span></span>| <span data-ttu-id="3c72d-117">string</span><span class="sxs-lookup"><span data-stu-id="3c72d-117">string</span></span>| <span data-ttu-id="3c72d-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="3c72d-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="3c72d-119">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="3c72d-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="3c72d-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="3c72d-120">sessionName</span></span>| <span data-ttu-id="3c72d-121">GUID</span><span class="sxs-lookup"><span data-stu-id="3c72d-121">GUID</span></span>| <span data-ttu-id="3c72d-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="3c72d-122">Unique ID of the session.</span></span> <span data-ttu-id="3c72d-123">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="3c72d-123">Part 3 of the session identifier.</span></span>| 

<a id="ID4EBC"></a>


## <a name="valid-methods"></a><span data-ttu-id="3c72d-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="3c72d-124">Valid methods</span></span>

[<span data-ttu-id="3c72d-125">(/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="3c72d-125">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.md)

<span data-ttu-id="3c72d-126">&nbsp;&nbsp;セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="3c72d-126">&nbsp;&nbsp;Gets a session object.</span></span>

[<span data-ttu-id="3c72d-127">PUT (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション})</span><span class="sxs-lookup"><span data-stu-id="3c72d-127">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

<span data-ttu-id="3c72d-128">&nbsp;&nbsp;作成、更新、またはセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="3c72d-128">&nbsp;&nbsp;Creates, updates, or joins a session.</span></span>

<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="3c72d-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="3c72d-129">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="3c72d-130">Parent</span><span class="sxs-lookup"><span data-stu-id="3c72d-130">Parent</span></span>

[<span data-ttu-id="3c72d-131">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="3c72d-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
