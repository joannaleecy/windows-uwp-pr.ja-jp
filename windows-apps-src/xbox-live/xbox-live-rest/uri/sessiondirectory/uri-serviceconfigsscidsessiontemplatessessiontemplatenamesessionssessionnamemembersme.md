---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me
assetID: a6c2fa17-8bed-d0df-d7ff-db1aa60f44b3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.html
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2b0ecadb543434383ef32c7fd2a749760d5bcc98
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8800839"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a><span data-ttu-id="75e2a-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span><span class="sxs-lookup"><span data-stu-id="75e2a-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>
<span data-ttu-id="75e2a-105">セッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="75e2a-105">Supports a DELETE operation to remove session members.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="75e2a-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="75e2a-106">Domain</span></span>
<span data-ttu-id="75e2a-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="75e2a-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="remarks"></a><span data-ttu-id="75e2a-108">注釈</span><span class="sxs-lookup"><span data-stu-id="75e2a-108">Remarks</span></span>

<span data-ttu-id="75e2a-109">セッション メンバー リソースのすべての操作は、Xbox ユーザー ID (XUID) ユーザーの承認を要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="75e2a-109">All session member resource operations require an Xbox User ID (XUID) user claim authorization.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="75e2a-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="75e2a-110">URI parameters</span></span>

| <span data-ttu-id="75e2a-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="75e2a-111">Parameter</span></span>| <span data-ttu-id="75e2a-112">型</span><span class="sxs-lookup"><span data-stu-id="75e2a-112">Type</span></span>| <span data-ttu-id="75e2a-113">説明</span><span class="sxs-lookup"><span data-stu-id="75e2a-113">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="75e2a-114">scid</span><span class="sxs-lookup"><span data-stu-id="75e2a-114">scid</span></span>| <span data-ttu-id="75e2a-115">GUID</span><span class="sxs-lookup"><span data-stu-id="75e2a-115">GUID</span></span>| <span data-ttu-id="75e2a-116">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="75e2a-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="75e2a-117">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="75e2a-117">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="75e2a-118">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="75e2a-118">sessionTemplateName</span></span>| <span data-ttu-id="75e2a-119">string</span><span class="sxs-lookup"><span data-stu-id="75e2a-119">string</span></span>| <span data-ttu-id="75e2a-120">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="75e2a-120">Name of the current instance of the session template.</span></span> <span data-ttu-id="75e2a-121">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="75e2a-121">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="75e2a-122">セッション名</span><span class="sxs-lookup"><span data-stu-id="75e2a-122">sessionName</span></span>| <span data-ttu-id="75e2a-123">GUID</span><span class="sxs-lookup"><span data-stu-id="75e2a-123">GUID</span></span>| <span data-ttu-id="75e2a-124">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="75e2a-124">Unique ID of the session.</span></span> <span data-ttu-id="75e2a-125">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="75e2a-125">Part 3 of the session identifier.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="75e2a-126">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="75e2a-126">Valid methods</span></span>

[<span data-ttu-id="75e2a-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span><span class="sxs-lookup"><span data-stu-id="75e2a-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.md)

<span data-ttu-id="75e2a-128">&nbsp;&nbsp;メンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="75e2a-128">&nbsp;&nbsp;Removes a member from a session.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="75e2a-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="75e2a-129">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="75e2a-130">Parent</span><span class="sxs-lookup"><span data-stu-id="75e2a-130">Parent</span></span>

[<span data-ttu-id="75e2a-131">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="75e2a-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
