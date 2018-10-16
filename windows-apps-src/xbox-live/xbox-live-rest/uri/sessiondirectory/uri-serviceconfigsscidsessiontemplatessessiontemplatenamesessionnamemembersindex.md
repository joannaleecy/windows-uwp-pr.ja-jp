---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}
assetID: ae6c6a25-2251-6ffd-ec58-e6c0576a34db
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e8d56b9d7079e26973595de093b581ef39bd41c0
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4618670"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersindex"></a><span data-ttu-id="381b4-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span><span class="sxs-lookup"><span data-stu-id="381b4-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span></span>
<span data-ttu-id="381b4-105">指定されたセッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="381b4-105">Supports a DELETE operation to remove the specified session member.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="381b4-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="381b4-106">Domain</span></span>
<span data-ttu-id="381b4-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="381b4-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="381b4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="381b4-108">URI parameters</span></span>

| <span data-ttu-id="381b4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="381b4-109">Parameter</span></span>| <span data-ttu-id="381b4-110">型</span><span class="sxs-lookup"><span data-stu-id="381b4-110">Type</span></span>| <span data-ttu-id="381b4-111">説明</span><span class="sxs-lookup"><span data-stu-id="381b4-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="381b4-112">scid</span><span class="sxs-lookup"><span data-stu-id="381b4-112">scid</span></span>| <span data-ttu-id="381b4-113">GUID</span><span class="sxs-lookup"><span data-stu-id="381b4-113">GUID</span></span>| <span data-ttu-id="381b4-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="381b4-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="381b4-115">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="381b4-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="381b4-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="381b4-116">sessionTemplateName</span></span>| <span data-ttu-id="381b4-117">string</span><span class="sxs-lookup"><span data-stu-id="381b4-117">string</span></span>| <span data-ttu-id="381b4-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="381b4-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="381b4-119">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="381b4-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="381b4-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="381b4-120">sessionName</span></span>| <span data-ttu-id="381b4-121">GUID</span><span class="sxs-lookup"><span data-stu-id="381b4-121">GUID</span></span>| <span data-ttu-id="381b4-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="381b4-122">Unique ID of the session.</span></span> <span data-ttu-id="381b4-123">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="381b4-123">Part 3 of the session identifier.</span></span>|

<a id="ID4EDC"></a>


## <a name="valid-methods"></a><span data-ttu-id="381b4-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="381b4-124">Valid methods</span></span>

[<span data-ttu-id="381b4-125">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span><span class="sxs-lookup"><span data-stu-id="381b4-125">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindexdelete.md)

<span data-ttu-id="381b4-126">&nbsp;&nbsp;指定されたメンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="381b4-126">&nbsp;&nbsp;Removes the specified members from a session.</span></span>

<a id="ID4ENC"></a>


## <a name="see-also"></a><span data-ttu-id="381b4-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="381b4-127">See also</span></span>

<a id="ID4EPC"></a>


##### <a name="parent"></a><span data-ttu-id="381b4-128">Parent</span><span class="sxs-lookup"><span data-stu-id="381b4-128">Parent</span></span>

[<span data-ttu-id="381b4-129">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="381b4-129">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
