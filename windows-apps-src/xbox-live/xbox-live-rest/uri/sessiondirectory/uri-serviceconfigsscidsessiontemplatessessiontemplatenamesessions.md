---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions
assetID: 8d55818f-99fd-146a-896b-0f100e78799f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0eff47ed041502838b5101cd5700dbba7a03f383
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5443696"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessions"></a><span data-ttu-id="020f4-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span><span class="sxs-lookup"><span data-stu-id="020f4-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span></span>
<span data-ttu-id="020f4-105">指定したテンプレート名を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="020f4-105">Supports a GET operation to retrieve a set of session templates with the specified template names.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="020f4-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="020f4-106">Domain</span></span>
<span data-ttu-id="020f4-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="020f4-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="020f4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="020f4-108">URI parameters</span></span>
 
| <span data-ttu-id="020f4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="020f4-109">Parameter</span></span>| <span data-ttu-id="020f4-110">型</span><span class="sxs-lookup"><span data-stu-id="020f4-110">Type</span></span>| <span data-ttu-id="020f4-111">説明</span><span class="sxs-lookup"><span data-stu-id="020f4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="020f4-112">scid</span><span class="sxs-lookup"><span data-stu-id="020f4-112">scid</span></span>| <span data-ttu-id="020f4-113">GUID</span><span class="sxs-lookup"><span data-stu-id="020f4-113">GUID</span></span>| <span data-ttu-id="020f4-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="020f4-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="020f4-115">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="020f4-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="020f4-116">キーワード</span><span class="sxs-lookup"><span data-stu-id="020f4-116">keyword</span></span>| <span data-ttu-id="020f4-117">string</span><span class="sxs-lookup"><span data-stu-id="020f4-117">string</span></span>| <span data-ttu-id="020f4-118">その文字列で識別されるだけのセッションに結果をフィルター処理するためのキーワードです。</span><span class="sxs-lookup"><span data-stu-id="020f4-118">A keyword used to filter results to just sessions identified with that string.</span></span>| 
| <span data-ttu-id="020f4-119">xuid</span><span class="sxs-lookup"><span data-stu-id="020f4-119">xuid</span></span>| <span data-ttu-id="020f4-120">GUID</span><span class="sxs-lookup"><span data-stu-id="020f4-120">GUID</span></span>| <span data-ttu-id="020f4-121">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="020f4-121">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="020f4-122">ユーザーは、セッション内でアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="020f4-122">The users must be active in the sessions.</span></span> | 
| <span data-ttu-id="020f4-123">予約</span><span class="sxs-lookup"><span data-stu-id="020f4-123">reservations</span></span>| <span data-ttu-id="020f4-124">string</span><span class="sxs-lookup"><span data-stu-id="020f4-124">string</span></span>| <span data-ttu-id="020f4-125">示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。</span><span class="sxs-lookup"><span data-stu-id="020f4-125">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="020f4-126">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="020f4-126">This parameter can only be set to true.</span></span> <span data-ttu-id="020f4-127">この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="020f4-127">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="020f4-128">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="020f4-128">inactive</span></span>| <span data-ttu-id="020f4-129">string</span><span class="sxs-lookup"><span data-stu-id="020f4-129">string</span></span>| <span data-ttu-id="020f4-130">セッションのリストが含まれますをユーザーが受け入れられますがアクティブにプレイしていないかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="020f4-130">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="020f4-131">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="020f4-131">This parameter can only be set to true.</span></span> | 
| <span data-ttu-id="020f4-132">プライベート</span><span class="sxs-lookup"><span data-stu-id="020f4-132">private</span></span>| <span data-ttu-id="020f4-133">string</span><span class="sxs-lookup"><span data-stu-id="020f4-133">string</span></span>| <span data-ttu-id="020f4-134">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="020f4-134">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="020f4-135">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="020f4-135">This parameter can only be set to true.</span></span> <span data-ttu-id="020f4-136">独自のセッションをクエリするときにのみ、またはサーバー間を照会すると、無効です。</span><span class="sxs-lookup"><span data-stu-id="020f4-136">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="020f4-137">セッションへのサーバー レベルのアクセスが呼び出し元を true にこのパラメーターを設定する必要があります、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="020f4-137">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="020f4-138">visibility</span><span class="sxs-lookup"><span data-stu-id="020f4-138">visibility</span></span>| <span data-ttu-id="020f4-139">string</span><span class="sxs-lookup"><span data-stu-id="020f4-139">string</span></span>| <span data-ttu-id="020f4-140">結果のフィルタ リングで使われる表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="020f4-140">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="020f4-141">現在このパラメーターのみに設定できます開くを開いているセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="020f4-141">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="020f4-142"><b>MultiplayerSessionVisibility</b>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="020f4-142">See <b>MultiplayerSessionVisibility</b>.</span></span> | 
| <span data-ttu-id="020f4-143">version</span><span class="sxs-lookup"><span data-stu-id="020f4-143">version</span></span>| <span data-ttu-id="020f4-144">string</span><span class="sxs-lookup"><span data-stu-id="020f4-144">string</span></span>| <span data-ttu-id="020f4-145">正の整数を示すセッションのメジャー バージョンまたはセッションの下に含めます。</span><span class="sxs-lookup"><span data-stu-id="020f4-145">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="020f4-146">値は 100 モジュロ要求のコントラクト バージョン以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="020f4-146">The value must be less than or equal to the request's contract version modulo 100.</span></span> | 
| <span data-ttu-id="020f4-147">アプリでは</span><span class="sxs-lookup"><span data-stu-id="020f4-147">take</span></span>| <span data-ttu-id="020f4-148">string</span><span class="sxs-lookup"><span data-stu-id="020f4-148">string</span></span>| <span data-ttu-id="020f4-149">正の整数セッションの最大数を示すを取得します。</span><span class="sxs-lookup"><span data-stu-id="020f4-149">A positive integer indicating the maximum number of sessions to retrieve.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="020f4-150">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="020f4-150">Valid methods</span></span>

[<span data-ttu-id="020f4-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span><span class="sxs-lookup"><span data-stu-id="020f4-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.md)

<span data-ttu-id="020f4-152">&nbsp;&nbsp;セッション テンプレートのドキュメントを取得します。</span><span class="sxs-lookup"><span data-stu-id="020f4-152">&nbsp;&nbsp;Retrieves session template documents.</span></span>
 
<a id="ID4EDE"></a>

 
## <a name="see-also"></a><span data-ttu-id="020f4-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="020f4-153">See also</span></span>
 
<a id="ID4EFE"></a>

 
##### <a name="parent"></a><span data-ttu-id="020f4-154">Parent</span><span class="sxs-lookup"><span data-stu-id="020f4-154">Parent</span></span> 

[<span data-ttu-id="020f4-155">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="020f4-155">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   