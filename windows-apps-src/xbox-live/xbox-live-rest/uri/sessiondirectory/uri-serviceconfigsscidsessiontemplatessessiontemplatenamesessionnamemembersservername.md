---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}
assetID: aed0764f-4e3d-e0b3-1ea0-543c32f3f822
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d799db37aef00aaaa7a992b2bda5cb535a12b569
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5829576"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a><span data-ttu-id="743bc-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span><span class="sxs-lookup"><span data-stu-id="743bc-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span></span>
<span data-ttu-id="743bc-105">セッションの指定されたサーバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="743bc-105">Supports a DELETE operation to remove the specified server of a session.</span></span>
<a id="ID4EO"></a>


## <a name="uri-parameters"></a><span data-ttu-id="743bc-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="743bc-106">URI parameters</span></span>

| <span data-ttu-id="743bc-107">パラメーター</span><span class="sxs-lookup"><span data-stu-id="743bc-107">Parameter</span></span>| <span data-ttu-id="743bc-108">型</span><span class="sxs-lookup"><span data-stu-id="743bc-108">Type</span></span>| <span data-ttu-id="743bc-109">説明</span><span class="sxs-lookup"><span data-stu-id="743bc-109">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="743bc-110">scid</span><span class="sxs-lookup"><span data-stu-id="743bc-110">scid</span></span>| <span data-ttu-id="743bc-111">GUID</span><span class="sxs-lookup"><span data-stu-id="743bc-111">GUID</span></span>| <span data-ttu-id="743bc-112">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="743bc-112">Service configuration identifier (SCID).</span></span> <span data-ttu-id="743bc-113">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="743bc-113">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="743bc-114">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="743bc-114">sessionTemplateName</span></span>| <span data-ttu-id="743bc-115">string</span><span class="sxs-lookup"><span data-stu-id="743bc-115">string</span></span>| <span data-ttu-id="743bc-116">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="743bc-116">Name of the current instance of the session template.</span></span> <span data-ttu-id="743bc-117">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="743bc-117">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="743bc-118">セッション名</span><span class="sxs-lookup"><span data-stu-id="743bc-118">sessionName</span></span>| <span data-ttu-id="743bc-119">GUID</span><span class="sxs-lookup"><span data-stu-id="743bc-119">GUID</span></span>| <span data-ttu-id="743bc-120">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="743bc-120">Unique ID of the session.</span></span> <span data-ttu-id="743bc-121">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="743bc-121">Part 3 of the session identifier.</span></span>| 

<a id="ID4E3B"></a>


## <a name="valid-methods"></a><span data-ttu-id="743bc-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="743bc-122">Valid methods</span></span>

[<span data-ttu-id="743bc-123">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span><span class="sxs-lookup"><span data-stu-id="743bc-123">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.md)

<span data-ttu-id="743bc-124">&nbsp;&nbsp;指定されたサーバーは、セッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="743bc-124">&nbsp;&nbsp;Removes the specified server from a session.</span></span>

<a id="ID4EGC"></a>


## <a name="see-also"></a><span data-ttu-id="743bc-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="743bc-125">See also</span></span>

<a id="ID4EIC"></a>


##### <a name="parent"></a><span data-ttu-id="743bc-126">Parent</span><span class="sxs-lookup"><span data-stu-id="743bc-126">Parent</span></span>

[<span data-ttu-id="743bc-127">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="743bc-127">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
