---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}
assetID: ae6c6a25-2251-6ffd-ec58-e6c0576a34db
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.html
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8698eabc57577746d32f9ee439d6cd7af4820b5e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617477"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersindex"></a><span data-ttu-id="a5f04-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span><span class="sxs-lookup"><span data-stu-id="a5f04-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span></span>
<span data-ttu-id="a5f04-105">指定したセッションのメンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="a5f04-105">Supports a DELETE operation to remove the specified session member.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="a5f04-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="a5f04-106">Domain</span></span>
<span data-ttu-id="a5f04-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="a5f04-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="a5f04-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a5f04-108">URI parameters</span></span>

| <span data-ttu-id="a5f04-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a5f04-109">Parameter</span></span>| <span data-ttu-id="a5f04-110">種類</span><span class="sxs-lookup"><span data-stu-id="a5f04-110">Type</span></span>| <span data-ttu-id="a5f04-111">説明</span><span class="sxs-lookup"><span data-stu-id="a5f04-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="a5f04-112">scid</span><span class="sxs-lookup"><span data-stu-id="a5f04-112">scid</span></span>| <span data-ttu-id="a5f04-113">GUID</span><span class="sxs-lookup"><span data-stu-id="a5f04-113">GUID</span></span>| <span data-ttu-id="a5f04-114">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="a5f04-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="a5f04-115">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="a5f04-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="a5f04-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="a5f04-116">sessionTemplateName</span></span>| <span data-ttu-id="a5f04-117">string</span><span class="sxs-lookup"><span data-stu-id="a5f04-117">string</span></span>| <span data-ttu-id="a5f04-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="a5f04-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="a5f04-119">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="a5f04-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="a5f04-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="a5f04-120">sessionName</span></span>| <span data-ttu-id="a5f04-121">GUID</span><span class="sxs-lookup"><span data-stu-id="a5f04-121">GUID</span></span>| <span data-ttu-id="a5f04-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="a5f04-122">Unique ID of the session.</span></span> <span data-ttu-id="a5f04-123">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="a5f04-123">Part 3 of the session identifier.</span></span>|

<a id="ID4EDC"></a>


## <a name="valid-methods"></a><span data-ttu-id="a5f04-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a5f04-124">Valid methods</span></span>

[<span data-ttu-id="a5f04-125">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span><span class="sxs-lookup"><span data-stu-id="a5f04-125">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindexdelete.md)

<span data-ttu-id="a5f04-126">&nbsp;&nbsp;セッションから、指定したメンバーを削除します。</span><span class="sxs-lookup"><span data-stu-id="a5f04-126">&nbsp;&nbsp;Removes the specified members from a session.</span></span>

<a id="ID4ENC"></a>


## <a name="see-also"></a><span data-ttu-id="a5f04-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="a5f04-127">See also</span></span>

<a id="ID4EPC"></a>


##### <a name="parent"></a><span data-ttu-id="a5f04-128">Parent</span><span class="sxs-lookup"><span data-stu-id="a5f04-128">Parent</span></span>

[<span data-ttu-id="a5f04-129">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="a5f04-129">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
