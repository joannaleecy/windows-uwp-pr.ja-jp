---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me
assetID: a6c2fa17-8bed-d0df-d7ff-db1aa60f44b3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0d7e61fe76fc0f322c93d55448d53ee6444ffec5
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4505362"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a><span data-ttu-id="39274-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span><span class="sxs-lookup"><span data-stu-id="39274-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>
<span data-ttu-id="39274-105">セッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="39274-105">Supports a DELETE operation to remove session members.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="39274-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="39274-106">Domain</span></span>
<span data-ttu-id="39274-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="39274-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="remarks"></a><span data-ttu-id="39274-108">注釈</span><span class="sxs-lookup"><span data-stu-id="39274-108">Remarks</span></span>

<span data-ttu-id="39274-109">セッション メンバー リソースのすべての操作は、Xbox ユーザー ID (XUID) ユーザーの承認を要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39274-109">All session member resource operations require an Xbox User ID (XUID) user claim authorization.</span></span>

<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="39274-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="39274-110">URI parameters</span></span>

| <span data-ttu-id="39274-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="39274-111">Parameter</span></span>| <span data-ttu-id="39274-112">型</span><span class="sxs-lookup"><span data-stu-id="39274-112">Type</span></span>| <span data-ttu-id="39274-113">説明</span><span class="sxs-lookup"><span data-stu-id="39274-113">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="39274-114">scid</span><span class="sxs-lookup"><span data-stu-id="39274-114">scid</span></span>| <span data-ttu-id="39274-115">GUID</span><span class="sxs-lookup"><span data-stu-id="39274-115">GUID</span></span>| <span data-ttu-id="39274-116">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="39274-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="39274-117">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="39274-117">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="39274-118">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="39274-118">sessionTemplateName</span></span>| <span data-ttu-id="39274-119">string</span><span class="sxs-lookup"><span data-stu-id="39274-119">string</span></span>| <span data-ttu-id="39274-120">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="39274-120">Name of the current instance of the session template.</span></span> <span data-ttu-id="39274-121">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="39274-121">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="39274-122">セッション名</span><span class="sxs-lookup"><span data-stu-id="39274-122">sessionName</span></span>| <span data-ttu-id="39274-123">GUID</span><span class="sxs-lookup"><span data-stu-id="39274-123">GUID</span></span>| <span data-ttu-id="39274-124">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="39274-124">Unique ID of the session.</span></span> <span data-ttu-id="39274-125">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="39274-125">Part 3 of the session identifier.</span></span>|

<a id="ID4EOC"></a>


## <a name="valid-methods"></a><span data-ttu-id="39274-126">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="39274-126">Valid methods</span></span>

[<span data-ttu-id="39274-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span><span class="sxs-lookup"><span data-stu-id="39274-127">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.md)

<span data-ttu-id="39274-128">&nbsp;&nbsp;メンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="39274-128">&nbsp;&nbsp;Removes a member from a session.</span></span>

<a id="ID4EYC"></a>


## <a name="see-also"></a><span data-ttu-id="39274-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="39274-129">See also</span></span>

<a id="ID4E1C"></a>


##### <a name="parent"></a><span data-ttu-id="39274-130">Parent</span><span class="sxs-lookup"><span data-stu-id="39274-130">Parent</span></span>

[<span data-ttu-id="39274-131">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="39274-131">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
