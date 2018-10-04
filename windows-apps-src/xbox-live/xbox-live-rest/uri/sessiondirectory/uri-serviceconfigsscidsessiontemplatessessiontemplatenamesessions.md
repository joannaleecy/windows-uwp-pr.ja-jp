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
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4355138"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessions"></a><span data-ttu-id="3cdbf-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span><span class="sxs-lookup"><span data-stu-id="3cdbf-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span></span>
<span data-ttu-id="3cdbf-105">指定したテンプレート名を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-105">Supports a GET operation to retrieve a set of session templates with the specified template names.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="3cdbf-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="3cdbf-106">Domain</span></span>
<span data-ttu-id="3cdbf-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="3cdbf-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3cdbf-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3cdbf-108">URI parameters</span></span>
 
| <span data-ttu-id="3cdbf-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3cdbf-109">Parameter</span></span>| <span data-ttu-id="3cdbf-110">型</span><span class="sxs-lookup"><span data-stu-id="3cdbf-110">Type</span></span>| <span data-ttu-id="3cdbf-111">説明</span><span class="sxs-lookup"><span data-stu-id="3cdbf-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3cdbf-112">scid</span><span class="sxs-lookup"><span data-stu-id="3cdbf-112">scid</span></span>| <span data-ttu-id="3cdbf-113">GUID</span><span class="sxs-lookup"><span data-stu-id="3cdbf-113">GUID</span></span>| <span data-ttu-id="3cdbf-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="3cdbf-115">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="3cdbf-116">キーワード</span><span class="sxs-lookup"><span data-stu-id="3cdbf-116">keyword</span></span>| <span data-ttu-id="3cdbf-117">string</span><span class="sxs-lookup"><span data-stu-id="3cdbf-117">string</span></span>| <span data-ttu-id="3cdbf-118">キーワードで文字列を識別するだけでセッションに結果をフィルター処理するために使用します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-118">A keyword used to filter results to just sessions identified with that string.</span></span>| 
| <span data-ttu-id="3cdbf-119">xuid</span><span class="sxs-lookup"><span data-stu-id="3cdbf-119">xuid</span></span>| <span data-ttu-id="3cdbf-120">GUID</span><span class="sxs-lookup"><span data-stu-id="3cdbf-120">GUID</span></span>| <span data-ttu-id="3cdbf-121">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-121">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="3cdbf-122">ユーザーは、セッション内でアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-122">The users must be active in the sessions.</span></span> | 
| <span data-ttu-id="3cdbf-123">予約</span><span class="sxs-lookup"><span data-stu-id="3cdbf-123">reservations</span></span>| <span data-ttu-id="3cdbf-124">string</span><span class="sxs-lookup"><span data-stu-id="3cdbf-124">string</span></span>| <span data-ttu-id="3cdbf-125">示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-125">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="3cdbf-126">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-126">This parameter can only be set to true.</span></span> <span data-ttu-id="3cdbf-127">この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-127">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="3cdbf-128">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="3cdbf-128">inactive</span></span>| <span data-ttu-id="3cdbf-129">string</span><span class="sxs-lookup"><span data-stu-id="3cdbf-129">string</span></span>| <span data-ttu-id="3cdbf-130">かどうかはセッションのリストが含まれているユーザーが受け入れがアクティブにプレイしていないものを示す値。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-130">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="3cdbf-131">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-131">This parameter can only be set to true.</span></span> | 
| <span data-ttu-id="3cdbf-132">プライベート</span><span class="sxs-lookup"><span data-stu-id="3cdbf-132">private</span></span>| <span data-ttu-id="3cdbf-133">string</span><span class="sxs-lookup"><span data-stu-id="3cdbf-133">string</span></span>| <span data-ttu-id="3cdbf-134">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-134">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="3cdbf-135">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-135">This parameter can only be set to true.</span></span> <span data-ttu-id="3cdbf-136">独自のセッションをクエリするときにのみ、またはサーバーからサーバーを照会すると、無効です。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-136">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="3cdbf-137">呼び出し元が、セッションにサーバー レベルのアクセスを true にこのパラメーターを設定する必要があります、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-137">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="3cdbf-138">visibility</span><span class="sxs-lookup"><span data-stu-id="3cdbf-138">visibility</span></span>| <span data-ttu-id="3cdbf-139">string</span><span class="sxs-lookup"><span data-stu-id="3cdbf-139">string</span></span>| <span data-ttu-id="3cdbf-140">結果のフィルタ リングで使われる表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-140">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="3cdbf-141">現在このパラメーターのみに設定できます開くを開いているセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-141">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="3cdbf-142"><b>MultiplayerSessionVisibility</b>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-142">See <b>MultiplayerSessionVisibility</b>.</span></span> | 
| <span data-ttu-id="3cdbf-143">version</span><span class="sxs-lookup"><span data-stu-id="3cdbf-143">version</span></span>| <span data-ttu-id="3cdbf-144">string</span><span class="sxs-lookup"><span data-stu-id="3cdbf-144">string</span></span>| <span data-ttu-id="3cdbf-145">正の整数セッションのメジャー バージョンまたはセッションの低下を示すが含まれます。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-145">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="3cdbf-146">値は 100 モジュロ要求のコントラクト バージョン以内である必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-146">The value must be less than or equal to the request's contract version modulo 100.</span></span> | 
| <span data-ttu-id="3cdbf-147">アプリ</span><span class="sxs-lookup"><span data-stu-id="3cdbf-147">take</span></span>| <span data-ttu-id="3cdbf-148">string</span><span class="sxs-lookup"><span data-stu-id="3cdbf-148">string</span></span>| <span data-ttu-id="3cdbf-149">正の整数セッションの最大数を示すを取得します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-149">A positive integer indicating the maximum number of sessions to retrieve.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="3cdbf-150">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="3cdbf-150">Valid methods</span></span>

[<span data-ttu-id="3cdbf-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span><span class="sxs-lookup"><span data-stu-id="3cdbf-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.md)

<span data-ttu-id="3cdbf-152">&nbsp;&nbsp;セッション テンプレートのドキュメントを取得します。</span><span class="sxs-lookup"><span data-stu-id="3cdbf-152">&nbsp;&nbsp;Retrieves session template documents.</span></span>
 
<a id="ID4EDE"></a>

 
## <a name="see-also"></a><span data-ttu-id="3cdbf-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="3cdbf-153">See also</span></span>
 
<a id="ID4EFE"></a>

 
##### <a name="parent"></a><span data-ttu-id="3cdbf-154">Parent</span><span class="sxs-lookup"><span data-stu-id="3cdbf-154">Parent</span></span> 

[<span data-ttu-id="3cdbf-155">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="3cdbf-155">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   