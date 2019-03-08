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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608457"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a><span data-ttu-id="1819b-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span><span class="sxs-lookup"><span data-stu-id="1819b-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>
<span data-ttu-id="1819b-105">セッションのメンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1819b-105">Supports a DELETE operation to remove session members.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="1819b-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="1819b-106">Domain</span></span>
<span data-ttu-id="1819b-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="1819b-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="remarks"></a><span data-ttu-id="1819b-108">注釈</span><span class="sxs-lookup"><span data-stu-id="1819b-108">Remarks</span></span>

<span data-ttu-id="1819b-109">すべてのセッションのメンバー リソース操作では、Xbox のユーザー ID (XUID) ユーザー要求の承認が必要です。</span><span class="sxs-lookup"><span data-stu-id="1819b-109">All session member resource operations require an Xbox User ID (XUID) user claim authorization.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="1819b-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1819b-110">URI parameters</span></span>

| <span data-ttu-id="1819b-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1819b-111">Parameter</span></span>| <span data-ttu-id="1819b-112">種類</span><span class="sxs-lookup"><span data-stu-id="1819b-112">Type</span></span>| <span data-ttu-id="1819b-113">説明</span><span class="sxs-lookup"><span data-stu-id="1819b-113">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="1819b-114">scid</span><span class="sxs-lookup"><span data-stu-id="1819b-114">scid</span></span>| <span data-ttu-id="1819b-115">GUID</span><span class="sxs-lookup"><span data-stu-id="1819b-115">GUID</span></span>| <span data-ttu-id="1819b-116">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="1819b-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="1819b-117">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="1819b-117">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="1819b-118">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="1819b-118">sessionTemplateName</span></span>| <span data-ttu-id="1819b-119">string</span><span class="sxs-lookup"><span data-stu-id="1819b-119">string</span></span>| <span data-ttu-id="1819b-120">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="1819b-120">Name of the current instance of the session template.</span></span> <span data-ttu-id="1819b-121">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="1819b-121">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="1819b-122">セッション名</span><span class="sxs-lookup"><span data-stu-id="1819b-122">sessionName</span></span>| <span data-ttu-id="1819b-123">GUID</span><span class="sxs-lookup"><span data-stu-id="1819b-123">GUID</span></span>| <span data-ttu-id="1819b-124">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="1819b-124">Unique ID of the session.</span></span> <span data-ttu-id="1819b-125">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="1819b-125">Part 3 of the session identifier.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="1819b-126">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="1819b-126">Valid methods</span></span>

[<span data-ttu-id="1819b-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span><span class="sxs-lookup"><span data-stu-id="1819b-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.md)

<span data-ttu-id="1819b-128">&nbsp;&nbsp;セッションからメンバーを削除します。</span><span class="sxs-lookup"><span data-stu-id="1819b-128">&nbsp;&nbsp;Removes a member from a session.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="1819b-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="1819b-129">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="1819b-130">Parent</span><span class="sxs-lookup"><span data-stu-id="1819b-130">Parent</span></span>

[<span data-ttu-id="1819b-131">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="1819b-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
