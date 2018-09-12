---
title: /serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/members
assetID: ae6c6a25-2251-6ffd-ec58-e6c0576a34db
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.html
author: KevinAsgari
description: " /serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/members"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e8d56b9d7079e26973595de093b581ef39bd41c0
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881912"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersindex"></a><span data-ttu-id="741f7-104">/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/members</span><span class="sxs-lookup"><span data-stu-id="741f7-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span></span>
<span data-ttu-id="741f7-105">指定されたセッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="741f7-105">Supports a DELETE operation to remove the specified session member.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="741f7-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="741f7-106">Domain</span></span>
<span data-ttu-id="741f7-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="741f7-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="741f7-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="741f7-108">URI parameters</span></span>

| <span data-ttu-id="741f7-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="741f7-109">Parameter</span></span>| <span data-ttu-id="741f7-110">型</span><span class="sxs-lookup"><span data-stu-id="741f7-110">Type</span></span>| <span data-ttu-id="741f7-111">説明</span><span class="sxs-lookup"><span data-stu-id="741f7-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="741f7-112">scid</span><span class="sxs-lookup"><span data-stu-id="741f7-112">scid</span></span>| <span data-ttu-id="741f7-113">GUID</span><span class="sxs-lookup"><span data-stu-id="741f7-113">GUID</span></span>| <span data-ttu-id="741f7-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="741f7-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="741f7-115">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="741f7-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="741f7-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="741f7-116">sessionTemplateName</span></span>| <span data-ttu-id="741f7-117">string</span><span class="sxs-lookup"><span data-stu-id="741f7-117">string</span></span>| <span data-ttu-id="741f7-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="741f7-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="741f7-119">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="741f7-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="741f7-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="741f7-120">sessionName</span></span>| <span data-ttu-id="741f7-121">GUID</span><span class="sxs-lookup"><span data-stu-id="741f7-121">GUID</span></span>| <span data-ttu-id="741f7-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="741f7-122">Unique ID of the session.</span></span> <span data-ttu-id="741f7-123">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="741f7-123">Part 3 of the session identifier.</span></span>|

<a id="ID4EDC"></a>


## <a name="valid-methods"></a><span data-ttu-id="741f7-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="741f7-124">Valid methods</span></span>

[<span data-ttu-id="741f7-125">(/Serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/members) を削除します。</span><span class="sxs-lookup"><span data-stu-id="741f7-125">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindexdelete.md)

<span data-ttu-id="741f7-126">&nbsp;&nbsp;指定されたメンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="741f7-126">&nbsp;&nbsp;Removes the specified members from a session.</span></span>

<a id="ID4ENC"></a>


## <a name="see-also"></a><span data-ttu-id="741f7-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="741f7-127">See also</span></span>

<a id="ID4EPC"></a>


##### <a name="parent"></a><span data-ttu-id="741f7-128">Parent</span><span class="sxs-lookup"><span data-stu-id="741f7-128">Parent</span></span>

[<span data-ttu-id="741f7-129">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="741f7-129">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
