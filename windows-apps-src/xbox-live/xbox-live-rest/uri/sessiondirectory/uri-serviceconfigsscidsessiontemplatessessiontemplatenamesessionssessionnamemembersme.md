---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me
assetID: a6c2fa17-8bed-d0df-d7ff-db1aa60f44b3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0dc5fed7a9bbf18f04683875ba6a847601459f61
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5986358"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a><span data-ttu-id="2b524-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span><span class="sxs-lookup"><span data-stu-id="2b524-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>
<span data-ttu-id="2b524-105">セッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="2b524-105">Supports a DELETE operation to remove session members.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="2b524-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="2b524-106">Domain</span></span>
<span data-ttu-id="2b524-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="2b524-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="remarks"></a><span data-ttu-id="2b524-108">注釈</span><span class="sxs-lookup"><span data-stu-id="2b524-108">Remarks</span></span>

<span data-ttu-id="2b524-109">セッション メンバー リソースのすべての操作では、Xbox ユーザー ID (XUID)、ユーザー認証を要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b524-109">All session member resource operations require an Xbox User ID (XUID) user claim authorization.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="2b524-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b524-110">URI parameters</span></span>

| <span data-ttu-id="2b524-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b524-111">Parameter</span></span>| <span data-ttu-id="2b524-112">型</span><span class="sxs-lookup"><span data-stu-id="2b524-112">Type</span></span>| <span data-ttu-id="2b524-113">説明</span><span class="sxs-lookup"><span data-stu-id="2b524-113">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="2b524-114">scid</span><span class="sxs-lookup"><span data-stu-id="2b524-114">scid</span></span>| <span data-ttu-id="2b524-115">GUID</span><span class="sxs-lookup"><span data-stu-id="2b524-115">GUID</span></span>| <span data-ttu-id="2b524-116">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="2b524-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="2b524-117">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="2b524-117">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="2b524-118">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="2b524-118">sessionTemplateName</span></span>| <span data-ttu-id="2b524-119">string</span><span class="sxs-lookup"><span data-stu-id="2b524-119">string</span></span>| <span data-ttu-id="2b524-120">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="2b524-120">Name of the current instance of the session template.</span></span> <span data-ttu-id="2b524-121">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="2b524-121">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="2b524-122">セッション名</span><span class="sxs-lookup"><span data-stu-id="2b524-122">sessionName</span></span>| <span data-ttu-id="2b524-123">GUID</span><span class="sxs-lookup"><span data-stu-id="2b524-123">GUID</span></span>| <span data-ttu-id="2b524-124">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="2b524-124">Unique ID of the session.</span></span> <span data-ttu-id="2b524-125">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="2b524-125">Part 3 of the session identifier.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="2b524-126">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="2b524-126">Valid methods</span></span>

[<span data-ttu-id="2b524-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span><span class="sxs-lookup"><span data-stu-id="2b524-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.md)

<span data-ttu-id="2b524-128">&nbsp;&nbsp;メンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="2b524-128">&nbsp;&nbsp;Removes a member from a session.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="2b524-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="2b524-129">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="2b524-130">Parent</span><span class="sxs-lookup"><span data-stu-id="2b524-130">Parent</span></span>

[<span data-ttu-id="2b524-131">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="2b524-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
