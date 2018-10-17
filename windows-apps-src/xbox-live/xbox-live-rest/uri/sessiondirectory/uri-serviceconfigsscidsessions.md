---
title: /serviceconfigs/{scid}/sessions
assetID: d1932817-dcce-5a5c-d7e4-9fd97e1d287c
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessions.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessions"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04176c4b2d2839df07fb55eceb5bb752c61d9c65
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4750805"
---
# <a name="serviceconfigsscidsessions"></a><span data-ttu-id="d5fd1-104">/serviceconfigs/{scid}/sessions</span><span class="sxs-lookup"><span data-stu-id="d5fd1-104">/serviceconfigs/{scid}/sessions</span></span>
<span data-ttu-id="d5fd1-105">セッション ドキュメントのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-105">Supports a GET operation to retrieve a set of session documents.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="d5fd1-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="d5fd1-106">Domain</span></span>
<span data-ttu-id="d5fd1-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="d5fd1-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d5fd1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5fd1-108">URI parameters</span></span>
 
| <span data-ttu-id="d5fd1-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5fd1-109">Parameter</span></span>| <span data-ttu-id="d5fd1-110">型</span><span class="sxs-lookup"><span data-stu-id="d5fd1-110">Type</span></span>| <span data-ttu-id="d5fd1-111">説明</span><span class="sxs-lookup"><span data-stu-id="d5fd1-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d5fd1-112">scid</span><span class="sxs-lookup"><span data-stu-id="d5fd1-112">scid</span></span>| <span data-ttu-id="d5fd1-113">GUID</span><span class="sxs-lookup"><span data-stu-id="d5fd1-113">GUID</span></span>| <span data-ttu-id="d5fd1-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="d5fd1-115">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="d5fd1-116">キーワード</span><span class="sxs-lookup"><span data-stu-id="d5fd1-116">keyword</span></span>| <span data-ttu-id="d5fd1-117">string</span><span class="sxs-lookup"><span data-stu-id="d5fd1-117">string</span></span>| <span data-ttu-id="d5fd1-118">その文字列で識別されるだけのセッションに結果をフィルター処理するためのキーワードです。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-118">A keyword used to filter results to just sessions identified with that string.</span></span>| 
| <span data-ttu-id="d5fd1-119">xuid</span><span class="sxs-lookup"><span data-stu-id="d5fd1-119">xuid</span></span>| <span data-ttu-id="d5fd1-120">GUID</span><span class="sxs-lookup"><span data-stu-id="d5fd1-120">GUID</span></span>| <span data-ttu-id="d5fd1-121">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-121">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="d5fd1-122">ユーザーは、セッション内でアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-122">The users must be active in the sessions.</span></span>| 
| <span data-ttu-id="d5fd1-123">予約</span><span class="sxs-lookup"><span data-stu-id="d5fd1-123">reservations</span></span>| <span data-ttu-id="d5fd1-124">string</span><span class="sxs-lookup"><span data-stu-id="d5fd1-124">string</span></span>| <span data-ttu-id="d5fd1-125">示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-125">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="d5fd1-126">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-126">This parameter can only be set to true.</span></span> <span data-ttu-id="d5fd1-127">この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-127">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="d5fd1-128">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="d5fd1-128">inactive</span></span>| <span data-ttu-id="d5fd1-129">string</span><span class="sxs-lookup"><span data-stu-id="d5fd1-129">string</span></span>| <span data-ttu-id="d5fd1-130">セッションのリストが含まれますをユーザーが受け入れられますがアクティブにプレイしていないかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-130">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="d5fd1-131">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-131">This parameter can only be set to true.</span></span>| 
| <span data-ttu-id="d5fd1-132">プライベート</span><span class="sxs-lookup"><span data-stu-id="d5fd1-132">private</span></span>| <span data-ttu-id="d5fd1-133">string</span><span class="sxs-lookup"><span data-stu-id="d5fd1-133">string</span></span>| <span data-ttu-id="d5fd1-134">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-134">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="d5fd1-135">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-135">This parameter can only be set to true.</span></span> <span data-ttu-id="d5fd1-136">独自のセッションをクエリするときにのみ、またはサーバー間を照会すると、無効です。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-136">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="d5fd1-137">セッションへのサーバー レベルのアクセスが呼び出し元を true にこのパラメーターを設定する必要があります、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-137">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="d5fd1-138">visibility</span><span class="sxs-lookup"><span data-stu-id="d5fd1-138">visibility</span></span>| <span data-ttu-id="d5fd1-139">string</span><span class="sxs-lookup"><span data-stu-id="d5fd1-139">string</span></span>| <span data-ttu-id="d5fd1-140">結果のフィルタ リングで使われる表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-140">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="d5fd1-141">現在このパラメーターのみに設定できます開くを開いているセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-141">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="d5fd1-142"><b>MultiplayerSessionVisibility</b>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-142">See <b>MultiplayerSessionVisibility</b>.</span></span>| 
| <span data-ttu-id="d5fd1-143">version</span><span class="sxs-lookup"><span data-stu-id="d5fd1-143">version</span></span>| <span data-ttu-id="d5fd1-144">string</span><span class="sxs-lookup"><span data-stu-id="d5fd1-144">string</span></span>| <span data-ttu-id="d5fd1-145">正の整数を示すセッションのメジャー バージョンまたはセッションの下に含めます。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-145">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="d5fd1-146">値は 100 モジュロ要求のコントラクト バージョン以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-146">The value must be less than or equal to the request's contract version modulo 100.</span></span>| 
| <span data-ttu-id="d5fd1-147">アプリでは</span><span class="sxs-lookup"><span data-stu-id="d5fd1-147">take</span></span>| <span data-ttu-id="d5fd1-148">string</span><span class="sxs-lookup"><span data-stu-id="d5fd1-148">string</span></span>| <span data-ttu-id="d5fd1-149">正の整数セッションの最大数を示すを取得します。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-149">A positive integer indicating the maximum number of sessions to retrieve.</span></span>| 
  
<a id="ID4E1D"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="d5fd1-150">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d5fd1-150">Valid methods</span></span>

[<span data-ttu-id="d5fd1-151">GET (/serviceconfigs/{scid}/sessions)</span><span class="sxs-lookup"><span data-stu-id="d5fd1-151">GET (/serviceconfigs/{scid}/sessions)</span></span>](uri-serviceconfigsscidsessionsget.md)

<span data-ttu-id="d5fd1-152">&nbsp;&nbsp;指定したセッション情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="d5fd1-152">&nbsp;&nbsp;Retrieves specified session information.</span></span>
 
<a id="ID4EEE"></a>

 
## <a name="see-also"></a><span data-ttu-id="d5fd1-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="d5fd1-153">See also</span></span>
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a><span data-ttu-id="d5fd1-154">Parent</span><span class="sxs-lookup"><span data-stu-id="d5fd1-154">Parent</span></span> 

[<span data-ttu-id="d5fd1-155">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="d5fd1-155">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   