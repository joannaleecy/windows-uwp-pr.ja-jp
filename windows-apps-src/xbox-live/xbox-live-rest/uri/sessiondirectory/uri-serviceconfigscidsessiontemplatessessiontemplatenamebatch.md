---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch
assetID: 4f8e1ece-2ba8-9ea4-e551-2a69c499d7b9
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6cc0850d1fda69eae1c0f3774a3146de33c7b4c8
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4425585"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamebatch"></a><span data-ttu-id="73bd5-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span><span class="sxs-lookup"><span data-stu-id="73bd5-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span></span>
<span data-ttu-id="73bd5-105">セッション テンプレート レベルでバッチ クエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="73bd5-105">Supports a POST operation to create a batch query at the session template level.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="73bd5-106">このメソッドは、2015年マルチプレイヤーで使用し、および後でそのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="73bd5-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="73bd5-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダー要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="73bd5-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="73bd5-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="73bd5-108">Domain</span></span>
<span data-ttu-id="73bd5-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="73bd5-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a><span data-ttu-id="73bd5-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="73bd5-110">URI parameters</span></span>

| <span data-ttu-id="73bd5-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="73bd5-111">Parameter</span></span>| <span data-ttu-id="73bd5-112">型</span><span class="sxs-lookup"><span data-stu-id="73bd5-112">Type</span></span>| <span data-ttu-id="73bd5-113">説明</span><span class="sxs-lookup"><span data-stu-id="73bd5-113">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="73bd5-114">scid</span><span class="sxs-lookup"><span data-stu-id="73bd5-114">scid</span></span>| <span data-ttu-id="73bd5-115">GUID</span><span class="sxs-lookup"><span data-stu-id="73bd5-115">GUID</span></span>| <span data-ttu-id="73bd5-116">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="73bd5-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="73bd5-117">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="73bd5-117">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="73bd5-118">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="73bd5-118">sessionTemplateName</span></span>| <span data-ttu-id="73bd5-119">string</span><span class="sxs-lookup"><span data-stu-id="73bd5-119">string</span></span>| <span data-ttu-id="73bd5-120">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="73bd5-120">Name of the current instance of the session template.</span></span> <span data-ttu-id="73bd5-121">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="73bd5-121">Part 2 of the session identifier.</span></span>|

<a id="ID4E2B"></a>


## <a name="valid-methods"></a><span data-ttu-id="73bd5-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="73bd5-122">Valid methods</span></span>

[<span data-ttu-id="73bd5-123">POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)</span><span class="sxs-lookup"><span data-stu-id="73bd5-123">POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)</span></span>](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatchpost.md)

<span data-ttu-id="73bd5-124">&nbsp;&nbsp;複数の Xbox ユーザー Id には、バッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="73bd5-124">&nbsp;&nbsp;Creates a batch query on multiple Xbox user IDs.</span></span>

<a id="ID4EFC"></a>


## <a name="see-also"></a><span data-ttu-id="73bd5-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="73bd5-125">See also</span></span>

<a id="ID4EHC"></a>


##### <a name="parent"></a><span data-ttu-id="73bd5-126">Parent</span><span class="sxs-lookup"><span data-stu-id="73bd5-126">Parent</span></span>

[<span data-ttu-id="73bd5-127">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="73bd5-127">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
