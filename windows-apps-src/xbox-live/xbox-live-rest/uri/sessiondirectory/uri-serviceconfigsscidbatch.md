---
title: /serviceconfigs/{scid}/batch
assetID: eb1b510f-d92e-ae9b-a3e6-0edf58b4f075
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidbatch.html
description: " /serviceconfigs/{scid}/batch"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 208ee92106563372dd4d92a8c800cc08f513e8c7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589717"
---
# <a name="serviceconfigsscidbatch"></a><span data-ttu-id="714b9-104">/serviceconfigs/{scid}/batch</span><span class="sxs-lookup"><span data-stu-id="714b9-104">/serviceconfigs/{scid}/batch</span></span>
<span data-ttu-id="714b9-105">サービス構成の識別子のレベルでのバッチ クエリの POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="714b9-105">Supports a POST operation for a batch query at the service configuration identifier level.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="714b9-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="714b9-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="714b9-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="714b9-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

<a id="ID4ER"></a>


## <a name="domain"></a><span data-ttu-id="714b9-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="714b9-108">Domain</span></span>
<span data-ttu-id="714b9-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="714b9-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EW"></a>


## <a name="uri-parameters"></a><span data-ttu-id="714b9-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="714b9-110">URI parameters</span></span>

| <span data-ttu-id="714b9-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="714b9-111">Parameter</span></span>| <span data-ttu-id="714b9-112">種類</span><span class="sxs-lookup"><span data-stu-id="714b9-112">Type</span></span>| <span data-ttu-id="714b9-113">説明</span><span class="sxs-lookup"><span data-stu-id="714b9-113">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="714b9-114">scid</span><span class="sxs-lookup"><span data-stu-id="714b9-114">scid</span></span>| <span data-ttu-id="714b9-115">GUID</span><span class="sxs-lookup"><span data-stu-id="714b9-115">GUID</span></span>| <span data-ttu-id="714b9-116">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="714b9-116">Service configuration identifier (SCID).</span></span> <span data-ttu-id="714b9-117">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="714b9-117">Part 1 of the session identifier.</span></span>|

<a id="ID4ESB"></a>


## <a name="valid-methods"></a><span data-ttu-id="714b9-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="714b9-118">Valid methods</span></span>

[<span data-ttu-id="714b9-119">POST (/serviceconfigs/{scid}/batch)</span><span class="sxs-lookup"><span data-stu-id="714b9-119">POST (/serviceconfigs/{scid}/batch)</span></span>](uri-serviceconfigsscidbatchpost.md)

<span data-ttu-id="714b9-120">&nbsp;&nbsp;サービスの構成の複数の Xbox ユーザー Id には、バッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="714b9-120">&nbsp;&nbsp;Creates a batch query on multiple Xbox user IDs for the service configuration.</span></span>

<a id="ID4E3B"></a>


## <a name="see-also"></a><span data-ttu-id="714b9-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="714b9-121">See also</span></span>

<a id="ID4E5B"></a>


##### <a name="parent"></a><span data-ttu-id="714b9-122">Parent</span><span class="sxs-lookup"><span data-stu-id="714b9-122">Parent</span></span>

[<span data-ttu-id="714b9-123">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="714b9-123">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
