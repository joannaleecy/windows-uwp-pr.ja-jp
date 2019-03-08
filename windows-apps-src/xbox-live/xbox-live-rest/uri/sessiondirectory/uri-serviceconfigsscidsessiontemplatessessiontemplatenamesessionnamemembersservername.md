---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}
assetID: aed0764f-4e3d-e0b3-1ea0-543c32f3f822
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.html
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 450562e882010239d44638fb5c2b461a0018748b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594567"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a><span data-ttu-id="305d2-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span><span class="sxs-lookup"><span data-stu-id="305d2-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span></span>
<span data-ttu-id="305d2-105">セッションの指定したサーバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="305d2-105">Supports a DELETE operation to remove the specified server of a session.</span></span>
<a id="ID4EO"></a>


## <a name="uri-parameters"></a><span data-ttu-id="305d2-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="305d2-106">URI parameters</span></span>

| <span data-ttu-id="305d2-107">パラメーター</span><span class="sxs-lookup"><span data-stu-id="305d2-107">Parameter</span></span>| <span data-ttu-id="305d2-108">種類</span><span class="sxs-lookup"><span data-stu-id="305d2-108">Type</span></span>| <span data-ttu-id="305d2-109">説明</span><span class="sxs-lookup"><span data-stu-id="305d2-109">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="305d2-110">scid</span><span class="sxs-lookup"><span data-stu-id="305d2-110">scid</span></span>| <span data-ttu-id="305d2-111">GUID</span><span class="sxs-lookup"><span data-stu-id="305d2-111">GUID</span></span>| <span data-ttu-id="305d2-112">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="305d2-112">Service configuration identifier (SCID).</span></span> <span data-ttu-id="305d2-113">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="305d2-113">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="305d2-114">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="305d2-114">sessionTemplateName</span></span>| <span data-ttu-id="305d2-115">string</span><span class="sxs-lookup"><span data-stu-id="305d2-115">string</span></span>| <span data-ttu-id="305d2-116">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="305d2-116">Name of the current instance of the session template.</span></span> <span data-ttu-id="305d2-117">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="305d2-117">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="305d2-118">セッション名</span><span class="sxs-lookup"><span data-stu-id="305d2-118">sessionName</span></span>| <span data-ttu-id="305d2-119">GUID</span><span class="sxs-lookup"><span data-stu-id="305d2-119">GUID</span></span>| <span data-ttu-id="305d2-120">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="305d2-120">Unique ID of the session.</span></span> <span data-ttu-id="305d2-121">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="305d2-121">Part 3 of the session identifier.</span></span>| 

<a id="ID4E3B"></a>


## <a name="valid-methods"></a><span data-ttu-id="305d2-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="305d2-122">Valid methods</span></span>

[<span data-ttu-id="305d2-123">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span><span class="sxs-lookup"><span data-stu-id="305d2-123">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.md)

<span data-ttu-id="305d2-124">&nbsp;&nbsp;セッションから、指定したサーバーを削除します。</span><span class="sxs-lookup"><span data-stu-id="305d2-124">&nbsp;&nbsp;Removes the specified server from a session.</span></span>

<a id="ID4EGC"></a>


## <a name="see-also"></a><span data-ttu-id="305d2-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="305d2-125">See also</span></span>

<a id="ID4EIC"></a>


##### <a name="parent"></a><span data-ttu-id="305d2-126">Parent</span><span class="sxs-lookup"><span data-stu-id="305d2-126">Parent</span></span>

[<span data-ttu-id="305d2-127">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="305d2-127">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
