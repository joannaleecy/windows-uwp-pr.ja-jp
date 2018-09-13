---
title: /serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}
assetID: ae6c6a25-2251-6ffd-ec58-e6c0576a34db
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.html
author: KevinAsgari
description: " /serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e8d56b9d7079e26973595de093b581ef39bd41c0
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3961823"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersindex"></a><span data-ttu-id="5ad27-104">/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}</span><span class="sxs-lookup"><span data-stu-id="5ad27-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span></span>
<span data-ttu-id="5ad27-105">指定されたセッション メンバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5ad27-105">Supports a DELETE operation to remove the specified session member.</span></span>
<a id="ID4EO"></a>


## <a name="domain"></a><span data-ttu-id="5ad27-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="5ad27-106">Domain</span></span>
<span data-ttu-id="5ad27-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="5ad27-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="5ad27-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ad27-108">URI parameters</span></span>

| <span data-ttu-id="5ad27-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ad27-109">Parameter</span></span>| <span data-ttu-id="5ad27-110">型</span><span class="sxs-lookup"><span data-stu-id="5ad27-110">Type</span></span>| <span data-ttu-id="5ad27-111">説明</span><span class="sxs-lookup"><span data-stu-id="5ad27-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="5ad27-112">scid</span><span class="sxs-lookup"><span data-stu-id="5ad27-112">scid</span></span>| <span data-ttu-id="5ad27-113">GUID</span><span class="sxs-lookup"><span data-stu-id="5ad27-113">GUID</span></span>| <span data-ttu-id="5ad27-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="5ad27-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="5ad27-115">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="5ad27-115">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="5ad27-116">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="5ad27-116">sessionTemplateName</span></span>| <span data-ttu-id="5ad27-117">string</span><span class="sxs-lookup"><span data-stu-id="5ad27-117">string</span></span>| <span data-ttu-id="5ad27-118">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="5ad27-118">Name of the current instance of the session template.</span></span> <span data-ttu-id="5ad27-119">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="5ad27-119">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="5ad27-120">セッション名</span><span class="sxs-lookup"><span data-stu-id="5ad27-120">sessionName</span></span>| <span data-ttu-id="5ad27-121">GUID</span><span class="sxs-lookup"><span data-stu-id="5ad27-121">GUID</span></span>| <span data-ttu-id="5ad27-122">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="5ad27-122">Unique ID of the session.</span></span> <span data-ttu-id="5ad27-123">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="5ad27-123">Part 3 of the session identifier.</span></span>|

<a id="ID4EDC"></a>


## <a name="valid-methods"></a><span data-ttu-id="5ad27-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5ad27-124">Valid methods</span></span>

[<span data-ttu-id="5ad27-125">(/Serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/members/{インデックス}) を削除します。</span><span class="sxs-lookup"><span data-stu-id="5ad27-125">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindexdelete.md)

<span data-ttu-id="5ad27-126">&nbsp;&nbsp;指定したメンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="5ad27-126">&nbsp;&nbsp;Removes the specified members from a session.</span></span>

<a id="ID4ENC"></a>


## <a name="see-also"></a><span data-ttu-id="5ad27-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="5ad27-127">See also</span></span>

<a id="ID4EPC"></a>


##### <a name="parent"></a><span data-ttu-id="5ad27-128">Parent</span><span class="sxs-lookup"><span data-stu-id="5ad27-128">Parent</span></span>

[<span data-ttu-id="5ad27-129">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="5ad27-129">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
