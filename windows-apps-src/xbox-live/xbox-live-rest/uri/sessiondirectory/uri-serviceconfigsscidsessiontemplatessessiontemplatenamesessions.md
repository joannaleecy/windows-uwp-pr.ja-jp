---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions
assetID: 8d55818f-99fd-146a-896b-0f100e78799f
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.html
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 99d9a82cb419e6598fc1113692b031487950aa8b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656097"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessions"></a><span data-ttu-id="73928-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span><span class="sxs-lookup"><span data-stu-id="73928-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span></span>
<span data-ttu-id="73928-105">指定したテンプレートの名前を持つセッション テンプレートのセットを取得する GET 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="73928-105">Supports a GET operation to retrieve a set of session templates with the specified template names.</span></span> 
<a id="ID4EO"></a>

 
## <a name="domain"></a><span data-ttu-id="73928-106">ドメイン</span><span class="sxs-lookup"><span data-stu-id="73928-106">Domain</span></span>
<span data-ttu-id="73928-107">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="73928-107">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="73928-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="73928-108">URI parameters</span></span>
 
| <span data-ttu-id="73928-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="73928-109">Parameter</span></span>| <span data-ttu-id="73928-110">種類</span><span class="sxs-lookup"><span data-stu-id="73928-110">Type</span></span>| <span data-ttu-id="73928-111">説明</span><span class="sxs-lookup"><span data-stu-id="73928-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="73928-112">scid</span><span class="sxs-lookup"><span data-stu-id="73928-112">scid</span></span>| <span data-ttu-id="73928-113">GUID</span><span class="sxs-lookup"><span data-stu-id="73928-113">GUID</span></span>| <span data-ttu-id="73928-114">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="73928-114">Service configuration identifier (SCID).</span></span> <span data-ttu-id="73928-115">セッションの第 1 部 id。</span><span class="sxs-lookup"><span data-stu-id="73928-115">Part 1 of the session ID.</span></span>| 
| <span data-ttu-id="73928-116">キーワード</span><span class="sxs-lookup"><span data-stu-id="73928-116">keyword</span></span>| <span data-ttu-id="73928-117">string</span><span class="sxs-lookup"><span data-stu-id="73928-117">string</span></span>| <span data-ttu-id="73928-118">結果文字列で識別されるだけでセッションをフィルター処理するために使用するキーワードです。</span><span class="sxs-lookup"><span data-stu-id="73928-118">A keyword used to filter results to just sessions identified with that string.</span></span>| 
| <span data-ttu-id="73928-119">xuid</span><span class="sxs-lookup"><span data-stu-id="73928-119">xuid</span></span>| <span data-ttu-id="73928-120">GUID</span><span class="sxs-lookup"><span data-stu-id="73928-120">GUID</span></span>| <span data-ttu-id="73928-121">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="73928-121">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="73928-122">ユーザーは、セッションでアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="73928-122">The users must be active in the sessions.</span></span> | 
| <span data-ttu-id="73928-123">予約</span><span class="sxs-lookup"><span data-stu-id="73928-123">reservations</span></span>| <span data-ttu-id="73928-124">string</span><span class="sxs-lookup"><span data-stu-id="73928-124">string</span></span>| <span data-ttu-id="73928-125">セッションの一覧が、ユーザー同意していないものも含まれますかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="73928-125">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="73928-126">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="73928-126">This parameter can only be set to true.</span></span> <span data-ttu-id="73928-127">この設定は、呼び出し元に、セッションにサーバー レベルのアクセスを要求または呼び出し元の XUID は Xbox のユーザー ID のフィルターに一致する要求。</span><span class="sxs-lookup"><span data-stu-id="73928-127">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="73928-128">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="73928-128">inactive</span></span>| <span data-ttu-id="73928-129">string</span><span class="sxs-lookup"><span data-stu-id="73928-129">string</span></span>| <span data-ttu-id="73928-130">セッションの一覧が、ユーザーが承諾しましたが、積極的に再生しないものを含むかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="73928-130">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="73928-131">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="73928-131">This parameter can only be set to true.</span></span> | 
| <span data-ttu-id="73928-132">プライベート</span><span class="sxs-lookup"><span data-stu-id="73928-132">private</span></span>| <span data-ttu-id="73928-133">string</span><span class="sxs-lookup"><span data-stu-id="73928-133">string</span></span>| <span data-ttu-id="73928-134">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="73928-134">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="73928-135">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="73928-135">This parameter can only be set to true.</span></span> <span data-ttu-id="73928-136">サーバーからサーバーを照会するときに、または自身のセッションのクエリを実行する場合にのみ有効です。</span><span class="sxs-lookup"><span data-stu-id="73928-136">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="73928-137">Xbox のユーザー ID のフィルターに一致する要求の呼び出し元の XUID または、呼び出し元に、セッションにサーバー レベルのアクセスを必要このパラメーターを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="73928-137">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> | 
| <span data-ttu-id="73928-138">visibility</span><span class="sxs-lookup"><span data-stu-id="73928-138">visibility</span></span>| <span data-ttu-id="73928-139">string</span><span class="sxs-lookup"><span data-stu-id="73928-139">string</span></span>| <span data-ttu-id="73928-140">結果をフィルター処理で使用される表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="73928-140">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="73928-141">現在このパラメーターのみ設定できます開くを開いているセッションを含める。</span><span class="sxs-lookup"><span data-stu-id="73928-141">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="73928-142">参照してください<b>MultiplayerSessionVisibility</b>します。</span><span class="sxs-lookup"><span data-stu-id="73928-142">See <b>MultiplayerSessionVisibility</b>.</span></span> | 
| <span data-ttu-id="73928-143">version</span><span class="sxs-lookup"><span data-stu-id="73928-143">version</span></span>| <span data-ttu-id="73928-144">string</span><span class="sxs-lookup"><span data-stu-id="73928-144">string</span></span>| <span data-ttu-id="73928-145">正の整数バージョンの主要なセッションまたはセッションの下位に含めます。</span><span class="sxs-lookup"><span data-stu-id="73928-145">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="73928-146">値は 100 剰余の要求のコントラクトのバージョン以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="73928-146">The value must be less than or equal to the request's contract version modulo 100.</span></span> | 
| <span data-ttu-id="73928-147">Take</span><span class="sxs-lookup"><span data-stu-id="73928-147">take</span></span>| <span data-ttu-id="73928-148">string</span><span class="sxs-lookup"><span data-stu-id="73928-148">string</span></span>| <span data-ttu-id="73928-149">正の整数のセッションの最大数を取得します。</span><span class="sxs-lookup"><span data-stu-id="73928-149">A positive integer indicating the maximum number of sessions to retrieve.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="73928-150">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="73928-150">Valid methods</span></span>

[<span data-ttu-id="73928-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span><span class="sxs-lookup"><span data-stu-id="73928-151">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.md)

<span data-ttu-id="73928-152">&nbsp;&nbsp;セッション テンプレートのドキュメントを取得します。</span><span class="sxs-lookup"><span data-stu-id="73928-152">&nbsp;&nbsp;Retrieves session template documents.</span></span>
 
<a id="ID4EDE"></a>

 
## <a name="see-also"></a><span data-ttu-id="73928-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="73928-153">See also</span></span>
 
<a id="ID4EFE"></a>

 
##### <a name="parent"></a><span data-ttu-id="73928-154">Parent</span><span class="sxs-lookup"><span data-stu-id="73928-154">Parent</span></span> 

[<span data-ttu-id="73928-155">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="73928-155">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   