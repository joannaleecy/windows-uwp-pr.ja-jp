---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch
assetID: 4f8e1ece-2ba8-9ea4-e551-2a69c499d7b9
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c1f1add0104ad166620dbdff79936e6a99379df3
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5831757"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamebatch"></a><span data-ttu-id="73023-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span><span class="sxs-lookup"><span data-stu-id="73023-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span></span>
<span data-ttu-id="73023-105">セッション テンプレート レベルでバッチ クエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="73023-105">Supports a POST operation to create a batch query at the session template level.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="73023-106">このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="73023-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="73023-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="73023-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="73023-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="73023-108">Domain</span></span>
<span data-ttu-id="73023-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="73023-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a><span data-ttu-id="73023-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="73023-110">URI parameters</span></span>

| <span data-ttu-id="73023-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="73023-111">Parameter</span></span>| <span data-ttu-id="73023-112">型</span><span class="sxs-lookup"><span data-stu-id="73023-112">Type</span></span>| <span data-ttu-id="73023-113">説明</span><span class="sxs-lookup"><span data-stu-id="73023-113">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="73023-114">scid</span><span class="sxs-lookup"><span data-stu-id="73023-114">scid</span></span>| <span data-ttu-id="73023-115">GUID</span><span class="sxs-lookup"><span data-stu-id="73023-115">GUID</span></span>| <span data-ttu-id="73023-116">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="73023-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="73023-117">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="73023-117">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="73023-118">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="73023-118">sessionTemplateName</span></span>| <span data-ttu-id="73023-119">string</span><span class="sxs-lookup"><span data-stu-id="73023-119">string</span></span>| <span data-ttu-id="73023-120">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="73023-120">Name of the current instance of the session template.</span></span> <span data-ttu-id="73023-121">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="73023-121">Part 2 of the session identifier.</span></span>|

<a id="ID4E2B"></a>


## <a name="valid-methods"></a><span data-ttu-id="73023-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="73023-122">Valid methods</span></span>

[<span data-ttu-id="73023-123">POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)</span><span class="sxs-lookup"><span data-stu-id="73023-123">POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)</span></span>](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatchpost.md)

<span data-ttu-id="73023-124">&nbsp;&nbsp;複数の Xbox ユーザー Id には、バッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="73023-124">&nbsp;&nbsp;Creates a batch query on multiple Xbox user IDs.</span></span>

<a id="ID4EFC"></a>


## <a name="see-also"></a><span data-ttu-id="73023-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="73023-125">See also</span></span>

<a id="ID4EHC"></a>


##### <a name="parent"></a><span data-ttu-id="73023-126">Parent</span><span class="sxs-lookup"><span data-stu-id="73023-126">Parent</span></span>

[<span data-ttu-id="73023-127">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="73023-127">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
