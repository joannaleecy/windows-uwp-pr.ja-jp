---
title: /serviceconfigs/{scid}/sessions
assetID: d1932817-dcce-5a5c-d7e4-9fd97e1d287c
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessions.html
description: " /serviceconfigs/{scid}/sessions"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 700575ee9e9afa7bc7a1d34388dc071873d3b9ed
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612577"
---
# <a name="serviceconfigsscidsessions"></a><span data-ttu-id="d5a79-104">/serviceconfigs/{scid}/sessions</span><span class="sxs-lookup"><span data-stu-id="d5a79-104">/serviceconfigs/{scid}/sessions</span></span>
<span data-ttu-id="d5a79-105">セッションのドキュメントのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="d5a79-105">Supports a GET operation to retrieve a set of session documents.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="d5a79-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="d5a79-106">Domain</span></span>
<span data-ttu-id="d5a79-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="d5a79-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d5a79-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5a79-108">URI parameters</span></span>
 
| <span data-ttu-id="d5a79-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5a79-109">Parameter</span></span>| <span data-ttu-id="d5a79-110">種類</span><span class="sxs-lookup"><span data-stu-id="d5a79-110">Type</span></span>| <span data-ttu-id="d5a79-111">説明</span><span class="sxs-lookup"><span data-stu-id="d5a79-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d5a79-112">scid</span><span class="sxs-lookup"><span data-stu-id="d5a79-112">scid</span></span>| <span data-ttu-id="d5a79-113">GUID</span><span class="sxs-lookup"><span data-stu-id="d5a79-113">GUID</span></span>| <span data-ttu-id="d5a79-114">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="d5a79-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="d5a79-115">セッションの第 1 部 id。</span><span class="sxs-lookup"><span data-stu-id="d5a79-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="d5a79-116">キーワード</span><span class="sxs-lookup"><span data-stu-id="d5a79-116">keyword</span></span>| <span data-ttu-id="d5a79-117">string</span><span class="sxs-lookup"><span data-stu-id="d5a79-117">string</span></span>| <span data-ttu-id="d5a79-118">結果文字列で識別されるだけでセッションをフィルター処理するために使用するキーワードです。</span><span class="sxs-lookup"><span data-stu-id="d5a79-118">A keyword used to filter results to just sessions identified with that string.</span></span>| 
| <span data-ttu-id="d5a79-119">xuid</span><span class="sxs-lookup"><span data-stu-id="d5a79-119">xuid</span></span>| <span data-ttu-id="d5a79-120">GUID</span><span class="sxs-lookup"><span data-stu-id="d5a79-120">GUID</span></span>| <span data-ttu-id="d5a79-121">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="d5a79-121">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="d5a79-122">ユーザーは、セッションでアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5a79-122">The users must be active in the sessions.</span></span>| 
| <span data-ttu-id="d5a79-123">予約</span><span class="sxs-lookup"><span data-stu-id="d5a79-123">reservations</span></span>| <span data-ttu-id="d5a79-124">string</span><span class="sxs-lookup"><span data-stu-id="d5a79-124">string</span></span>| <span data-ttu-id="d5a79-125">セッションの一覧が、ユーザー同意していないものも含まれますかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="d5a79-125">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="d5a79-126">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="d5a79-126">This parameter can only be set to true.</span></span> <span data-ttu-id="d5a79-127">この設定は、呼び出し元に、セッションにサーバー レベルのアクセスを要求または呼び出し元の XUID は Xbox のユーザー ID のフィルターに一致する要求。</span><span class="sxs-lookup"><span data-stu-id="d5a79-127">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="d5a79-128">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="d5a79-128">inactive</span></span>| <span data-ttu-id="d5a79-129">string</span><span class="sxs-lookup"><span data-stu-id="d5a79-129">string</span></span>| <span data-ttu-id="d5a79-130">セッションの一覧が、ユーザーが承諾しましたが、積極的に再生しないものを含むかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="d5a79-130">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="d5a79-131">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="d5a79-131">This parameter can only be set to true.</span></span>| 
| <span data-ttu-id="d5a79-132">プライベート</span><span class="sxs-lookup"><span data-stu-id="d5a79-132">private</span></span>| <span data-ttu-id="d5a79-133">string</span><span class="sxs-lookup"><span data-stu-id="d5a79-133">string</span></span>| <span data-ttu-id="d5a79-134">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="d5a79-134">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="d5a79-135">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="d5a79-135">This parameter can only be set to true.</span></span> <span data-ttu-id="d5a79-136">サーバーからサーバーを照会するときに、または自身のセッションのクエリを実行する場合にのみ有効です。</span><span class="sxs-lookup"><span data-stu-id="d5a79-136">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="d5a79-137">Xbox のユーザー ID のフィルターに一致する要求の呼び出し元の XUID または、呼び出し元に、セッションにサーバー レベルのアクセスを必要このパラメーターを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="d5a79-137">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="d5a79-138">visibility</span><span class="sxs-lookup"><span data-stu-id="d5a79-138">visibility</span></span>| <span data-ttu-id="d5a79-139">string</span><span class="sxs-lookup"><span data-stu-id="d5a79-139">string</span></span>| <span data-ttu-id="d5a79-140">結果をフィルター処理で使用される表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="d5a79-140">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="d5a79-141">現在このパラメーターのみ設定できます開くを開いているセッションを含める。</span><span class="sxs-lookup"><span data-stu-id="d5a79-141">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="d5a79-142">参照してください<b>MultiplayerSessionVisibility</b>します。</span><span class="sxs-lookup"><span data-stu-id="d5a79-142">See <b>MultiplayerSessionVisibility</b>.</span></span>| 
| <span data-ttu-id="d5a79-143">version</span><span class="sxs-lookup"><span data-stu-id="d5a79-143">version</span></span>| <span data-ttu-id="d5a79-144">string</span><span class="sxs-lookup"><span data-stu-id="d5a79-144">string</span></span>| <span data-ttu-id="d5a79-145">正の整数バージョンの主要なセッションまたはセッションの下位に含めます。</span><span class="sxs-lookup"><span data-stu-id="d5a79-145">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="d5a79-146">値は 100 剰余の要求のコントラクトのバージョン以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5a79-146">The value must be less than or equal to the request's contract version modulo 100.</span></span>| 
| <span data-ttu-id="d5a79-147">Take</span><span class="sxs-lookup"><span data-stu-id="d5a79-147">take</span></span>| <span data-ttu-id="d5a79-148">string</span><span class="sxs-lookup"><span data-stu-id="d5a79-148">string</span></span>| <span data-ttu-id="d5a79-149">正の整数のセッションの最大数を取得します。</span><span class="sxs-lookup"><span data-stu-id="d5a79-149">A positive integer indicating the maximum number of sessions to retrieve.</span></span>| 
  
<a id="ID4E1D"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="d5a79-150">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d5a79-150">Valid methods</span></span>

[<span data-ttu-id="d5a79-151">GET (/serviceconfigs/{scid}/sessions)</span><span class="sxs-lookup"><span data-stu-id="d5a79-151">GET (/serviceconfigs/{scid}/sessions)</span></span>](uri-serviceconfigsscidsessionsget.md)

<span data-ttu-id="d5a79-152">&nbsp;&nbsp;指定したセッションの情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="d5a79-152">&nbsp;&nbsp;Retrieves specified session information.</span></span>
 
<a id="ID4EEE"></a>

 
## <a name="see-also"></a><span data-ttu-id="d5a79-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="d5a79-153">See also</span></span>
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a><span data-ttu-id="d5a79-154">Parent</span><span class="sxs-lookup"><span data-stu-id="d5a79-154">Parent</span></span> 

[<span data-ttu-id="d5a79-155">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="d5a79-155">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   