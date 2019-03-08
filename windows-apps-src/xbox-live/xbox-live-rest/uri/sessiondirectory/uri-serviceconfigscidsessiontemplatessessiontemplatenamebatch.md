---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch
assetID: 4f8e1ece-2ba8-9ea4-e551-2a69c499d7b9
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigscidsessiontemplatessessiontemplatenamebatch.html
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 93ecaa95488493fa8779a44d76bf7d635d1751ad
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612597"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamebatch"></a><span data-ttu-id="074cb-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span><span class="sxs-lookup"><span data-stu-id="074cb-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch</span></span>
<span data-ttu-id="074cb-105">セッションのテンプレート レベルで、バッチ クエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="074cb-105">Supports a POST operation to create a batch query at the session template level.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="074cb-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="074cb-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="074cb-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="074cb-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="074cb-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="074cb-108">Domain</span></span>
<span data-ttu-id="074cb-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="074cb-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a><span data-ttu-id="074cb-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="074cb-110">URI parameters</span></span>

| <span data-ttu-id="074cb-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="074cb-111">Parameter</span></span>| <span data-ttu-id="074cb-112">種類</span><span class="sxs-lookup"><span data-stu-id="074cb-112">Type</span></span>| <span data-ttu-id="074cb-113">説明</span><span class="sxs-lookup"><span data-stu-id="074cb-113">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="074cb-114">scid</span><span class="sxs-lookup"><span data-stu-id="074cb-114">scid</span></span>| <span data-ttu-id="074cb-115">GUID</span><span class="sxs-lookup"><span data-stu-id="074cb-115">GUID</span></span>| <span data-ttu-id="074cb-116">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="074cb-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="074cb-117">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="074cb-117">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="074cb-118">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="074cb-118">sessionTemplateName</span></span>| <span data-ttu-id="074cb-119">string</span><span class="sxs-lookup"><span data-stu-id="074cb-119">string</span></span>| <span data-ttu-id="074cb-120">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="074cb-120">Name of the current instance of the session template.</span></span> <span data-ttu-id="074cb-121">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="074cb-121">Part 2 of the session identifier.</span></span>|

<a id="ID4E2B"></a>


## <a name="valid-methods"></a><span data-ttu-id="074cb-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="074cb-122">Valid methods</span></span>

[<span data-ttu-id="074cb-123">POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)</span><span class="sxs-lookup"><span data-stu-id="074cb-123">POST (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/batch)</span></span>](uri-serviceconfigscidsessiontemplatessessiontemplatenamebatchpost.md)

<span data-ttu-id="074cb-124">&nbsp;&nbsp;Xbox の複数のユーザー Id には、バッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="074cb-124">&nbsp;&nbsp;Creates a batch query on multiple Xbox user IDs.</span></span>

<a id="ID4EFC"></a>


## <a name="see-also"></a><span data-ttu-id="074cb-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="074cb-125">See also</span></span>

<a id="ID4EHC"></a>


##### <a name="parent"></a><span data-ttu-id="074cb-126">Parent</span><span class="sxs-lookup"><span data-stu-id="074cb-126">Parent</span></span>

[<span data-ttu-id="074cb-127">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="074cb-127">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
