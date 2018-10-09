---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}
assetID: aed0764f-4e3d-e0b3-1ea0-543c32f3f822
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b451d5aca9e855e204cb1178bf8ae30fb33ed015
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4422010"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a><span data-ttu-id="1d0b8-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span><span class="sxs-lookup"><span data-stu-id="1d0b8-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span></span>
<span data-ttu-id="1d0b8-105">セッションの指定されたサーバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-105">Supports a DELETE operation to remove the specified server of a session.</span></span>
<a id="ID4EO"></a>


## <a name="uri-parameters"></a><span data-ttu-id="1d0b8-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1d0b8-106">URI parameters</span></span>

| <span data-ttu-id="1d0b8-107">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1d0b8-107">Parameter</span></span>| <span data-ttu-id="1d0b8-108">型</span><span class="sxs-lookup"><span data-stu-id="1d0b8-108">Type</span></span>| <span data-ttu-id="1d0b8-109">説明</span><span class="sxs-lookup"><span data-stu-id="1d0b8-109">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="1d0b8-110">scid</span><span class="sxs-lookup"><span data-stu-id="1d0b8-110">scid</span></span>| <span data-ttu-id="1d0b8-111">GUID</span><span class="sxs-lookup"><span data-stu-id="1d0b8-111">GUID</span></span>| <span data-ttu-id="1d0b8-112">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-112">Service configuration identifier (SCID).</span></span> <span data-ttu-id="1d0b8-113">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-113">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="1d0b8-114">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="1d0b8-114">sessionTemplateName</span></span>| <span data-ttu-id="1d0b8-115">string</span><span class="sxs-lookup"><span data-stu-id="1d0b8-115">string</span></span>| <span data-ttu-id="1d0b8-116">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-116">Name of the current instance of the session template.</span></span> <span data-ttu-id="1d0b8-117">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-117">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="1d0b8-118">セッション名</span><span class="sxs-lookup"><span data-stu-id="1d0b8-118">sessionName</span></span>| <span data-ttu-id="1d0b8-119">GUID</span><span class="sxs-lookup"><span data-stu-id="1d0b8-119">GUID</span></span>| <span data-ttu-id="1d0b8-120">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-120">Unique ID of the session.</span></span> <span data-ttu-id="1d0b8-121">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-121">Part 3 of the session identifier.</span></span>| 

<a id="ID4E3B"></a>


## <a name="valid-methods"></a><span data-ttu-id="1d0b8-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="1d0b8-122">Valid methods</span></span>

[<span data-ttu-id="1d0b8-123">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span><span class="sxs-lookup"><span data-stu-id="1d0b8-123">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.md)

<span data-ttu-id="1d0b8-124">&nbsp;&nbsp;指定されたサーバーは、セッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="1d0b8-124">&nbsp;&nbsp;Removes the specified server from a session.</span></span>

<a id="ID4EGC"></a>


## <a name="see-also"></a><span data-ttu-id="1d0b8-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="1d0b8-125">See also</span></span>

<a id="ID4EIC"></a>


##### <a name="parent"></a><span data-ttu-id="1d0b8-126">Parent</span><span class="sxs-lookup"><span data-stu-id="1d0b8-126">Parent</span></span>

[<span data-ttu-id="1d0b8-127">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="1d0b8-127">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
