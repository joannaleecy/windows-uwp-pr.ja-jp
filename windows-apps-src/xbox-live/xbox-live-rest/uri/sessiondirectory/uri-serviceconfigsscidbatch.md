---
title: /serviceconfigs/{scid}/batch
assetID: eb1b510f-d92e-ae9b-a3e6-0edf58b4f075
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidbatch.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/batch"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a48bf9c30370238adc83376a524e9c61abb4af13
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4056845"
---
# <a name="serviceconfigsscidbatch"></a><span data-ttu-id="b7ff6-104">/serviceconfigs/{scid}/batch</span><span class="sxs-lookup"><span data-stu-id="b7ff6-104">/serviceconfigs/{scid}/batch</span></span>
<span data-ttu-id="b7ff6-105">サービス構成の識別子レベルでバッチ クエリの POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b7ff6-105">Supports a POST operation for a batch query at the service configuration identifier level.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b7ff6-106">このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="b7ff6-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="b7ff6-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="b7ff6-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="b7ff6-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="b7ff6-108">Domain</span></span>
<span data-ttu-id="b7ff6-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="b7ff6-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a><span data-ttu-id="b7ff6-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b7ff6-110">URI parameters</span></span>

| <span data-ttu-id="b7ff6-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b7ff6-111">Parameter</span></span>| <span data-ttu-id="b7ff6-112">型</span><span class="sxs-lookup"><span data-stu-id="b7ff6-112">Type</span></span>| <span data-ttu-id="b7ff6-113">説明</span><span class="sxs-lookup"><span data-stu-id="b7ff6-113">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="b7ff6-114">scid</span><span class="sxs-lookup"><span data-stu-id="b7ff6-114">scid</span></span>| <span data-ttu-id="b7ff6-115">GUID</span><span class="sxs-lookup"><span data-stu-id="b7ff6-115">GUID</span></span>| <span data-ttu-id="b7ff6-116">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="b7ff6-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="b7ff6-117">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="b7ff6-117">Part 1 of the session identifier.</span></span>|

<a id="ID4ESB"></a>


## <a name="valid-methods"></a><span data-ttu-id="b7ff6-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b7ff6-118">Valid methods</span></span>

[<span data-ttu-id="b7ff6-119">POST (/serviceconfigs/{scid}/batch)</span><span class="sxs-lookup"><span data-stu-id="b7ff6-119">POST (/serviceconfigs/{scid}/batch)</span></span>](uri-serviceconfigsscidbatchpost.md)

<span data-ttu-id="b7ff6-120">&nbsp;&nbsp;サービス構成の複数の Xbox ユーザー Id には、バッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="b7ff6-120">&nbsp;&nbsp;Creates a batch query on multiple Xbox user IDs for the service configuration.</span></span>

<a id="ID4E3B"></a>


## <a name="see-also"></a><span data-ttu-id="b7ff6-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="b7ff6-121">See also</span></span>

<a id="ID4E5B"></a>


##### <a name="parent"></a><span data-ttu-id="b7ff6-122">Parent</span><span class="sxs-lookup"><span data-stu-id="b7ff6-122">Parent</span></span>

[<span data-ttu-id="b7ff6-123">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="b7ff6-123">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
