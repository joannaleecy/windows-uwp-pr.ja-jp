---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions
assetID: 8d55818f-99fd-146a-896b-0f100e78799f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7b87625ec3ddd9b746b55adf33b10376c8bace69
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5864501"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessions"></a><span data-ttu-id="567c8-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span><span class="sxs-lookup"><span data-stu-id="567c8-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span></span>
<span data-ttu-id="567c8-105">指定したテンプレート名を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="567c8-105">Supports a GET operation to retrieve a set of session templates with the specified template names.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="567c8-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="567c8-106">Domain</span></span>
<span data-ttu-id="567c8-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="567c8-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="567c8-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="567c8-108">URI parameters</span></span>
 
| <span data-ttu-id="567c8-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="567c8-109">Parameter</span></span>| <span data-ttu-id="567c8-110">型</span><span class="sxs-lookup"><span data-stu-id="567c8-110">Type</span></span>| <span data-ttu-id="567c8-111">説明</span><span class="sxs-lookup"><span data-stu-id="567c8-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="567c8-112">scid</span><span class="sxs-lookup"><span data-stu-id="567c8-112">scid</span></span>| <span data-ttu-id="567c8-113">GUID</span><span class="sxs-lookup"><span data-stu-id="567c8-113">GUID</span></span>| <span data-ttu-id="567c8-114">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="567c8-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="567c8-115">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="567c8-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="567c8-116">キーワード</span><span class="sxs-lookup"><span data-stu-id="567c8-116">keyword</span></span>| <span data-ttu-id="567c8-117">string</span><span class="sxs-lookup"><span data-stu-id="567c8-117">string</span></span>| <span data-ttu-id="567c8-118">キーワードで文字列を識別するだけでセッションに結果をフィルター処理するために使用します。</span><span class="sxs-lookup"><span data-stu-id="567c8-118">A keyword used to filter results to just sessions identified with that string.</span></span>| 
| <span data-ttu-id="567c8-119">xuid</span><span class="sxs-lookup"><span data-stu-id="567c8-119">xuid</span></span>| <span data-ttu-id="567c8-120">GUID</span><span class="sxs-lookup"><span data-stu-id="567c8-120">GUID</span></span>| <span data-ttu-id="567c8-121">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="567c8-121">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="567c8-122">ユーザーは、セッション内でアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="567c8-122">The users must be active in the sessions.</span></span> | 
| <span data-ttu-id="567c8-123">予約</span><span class="sxs-lookup"><span data-stu-id="567c8-123">reservations</span></span>| <span data-ttu-id="567c8-124">string</span><span class="sxs-lookup"><span data-stu-id="567c8-124">string</span></span>| <span data-ttu-id="567c8-125">示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。</span><span class="sxs-lookup"><span data-stu-id="567c8-125">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="567c8-126">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="567c8-126">This parameter can only be set to true.</span></span> <span data-ttu-id="567c8-127">この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="567c8-127">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="567c8-128">非アクティブです</span><span class="sxs-lookup"><span data-stu-id="567c8-128">inactive</span></span>| <span data-ttu-id="567c8-129">string</span><span class="sxs-lookup"><span data-stu-id="567c8-129">string</span></span>| <span data-ttu-id="567c8-130">セッションのリストが含まれますをユーザーが受け入れられますがアクティブにプレイしていないかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="567c8-130">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="567c8-131">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="567c8-131">This parameter can only be set to true.</span></span> | 
| <span data-ttu-id="567c8-132">プライベート</span><span class="sxs-lookup"><span data-stu-id="567c8-132">private</span></span>| <span data-ttu-id="567c8-133">string</span><span class="sxs-lookup"><span data-stu-id="567c8-133">string</span></span>| <span data-ttu-id="567c8-134">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="567c8-134">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="567c8-135">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="567c8-135">This parameter can only be set to true.</span></span> <span data-ttu-id="567c8-136">自分のセッションをクエリするときにのみ、またはサーバーからサーバーを照会すると、無効です。</span><span class="sxs-lookup"><span data-stu-id="567c8-136">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="567c8-137">セッションへのサーバー レベルのアクセスが呼び出し元を true にこのパラメーターを設定する必要があります、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="567c8-137">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="567c8-138">visibility</span><span class="sxs-lookup"><span data-stu-id="567c8-138">visibility</span></span>| <span data-ttu-id="567c8-139">string</span><span class="sxs-lookup"><span data-stu-id="567c8-139">string</span></span>| <span data-ttu-id="567c8-140">結果のフィルタ リングで使われる表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="567c8-140">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="567c8-141">現在このパラメーターのみに設定できます開くを開いているセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="567c8-141">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="567c8-142"><b>MultiplayerSessionVisibility</b>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="567c8-142">See <b>MultiplayerSessionVisibility</b>.</span></span> | 
| <span data-ttu-id="567c8-143">version</span><span class="sxs-lookup"><span data-stu-id="567c8-143">version</span></span>| <span data-ttu-id="567c8-144">string</span><span class="sxs-lookup"><span data-stu-id="567c8-144">string</span></span>| <span data-ttu-id="567c8-145">正の整数を示すセッションのメジャー バージョンまたはセッションの下に含めます。</span><span class="sxs-lookup"><span data-stu-id="567c8-145">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="567c8-146">値は 100 モジュロ要求のコントラクト バージョン以内である必要があります。</span><span class="sxs-lookup"><span data-stu-id="567c8-146">The value must be less than or equal to the request's contract version modulo 100.</span></span> | 
| <span data-ttu-id="567c8-147">アプリ</span><span class="sxs-lookup"><span data-stu-id="567c8-147">take</span></span>| <span data-ttu-id="567c8-148">string</span><span class="sxs-lookup"><span data-stu-id="567c8-148">string</span></span>| <span data-ttu-id="567c8-149">正の整数セッションの最大数を示すを取得します。</span><span class="sxs-lookup"><span data-stu-id="567c8-149">A positive integer indicating the maximum number of sessions to retrieve.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="567c8-150">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="567c8-150">Valid methods</span></span>

[<span data-ttu-id="567c8-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span><span class="sxs-lookup"><span data-stu-id="567c8-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.md)

<span data-ttu-id="567c8-152">&nbsp;&nbsp;セッション テンプレートのドキュメントを取得します。</span><span class="sxs-lookup"><span data-stu-id="567c8-152">&nbsp;&nbsp;Retrieves session template documents.</span></span>
 
<a id="ID4EDE"></a>

 
## <a name="see-also"></a><span data-ttu-id="567c8-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="567c8-153">See also</span></span>
 
<a id="ID4EFE"></a>

 
##### <a name="parent"></a><span data-ttu-id="567c8-154">Parent</span><span class="sxs-lookup"><span data-stu-id="567c8-154">Parent</span></span> 

[<span data-ttu-id="567c8-155">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="567c8-155">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   