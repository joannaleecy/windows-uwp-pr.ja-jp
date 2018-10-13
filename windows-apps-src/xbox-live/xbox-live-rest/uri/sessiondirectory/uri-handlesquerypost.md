---
title: POST (/handles/query)
assetID: a1a47d49-5c3f-8021-a213-13eb8bddf16a
permalink: en-us/docs/xboxlive/rest/uri-handlesquerypost.html
author: KevinAsgari
description: " POST (/handles/query)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5caed8863133129c7bc2f0ee3dcb87f1c4a935e
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4572646"
---
# <a name="post-handlesquery"></a><span data-ttu-id="03717-104">POST (/handles/query)</span><span class="sxs-lookup"><span data-stu-id="03717-104">POST (/handles/query)</span></span>
<span data-ttu-id="03717-105">セッション ハンドルに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="03717-105">Creates queries for session handles.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="03717-106">このメソッドは、2015年マルチプレイヤーで使用し、および後でそのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="03717-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="03717-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダー要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="03717-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="03717-108">注釈</span><span class="sxs-lookup"><span data-stu-id="03717-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="03717-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03717-109">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="03717-110">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="03717-110">Query string parameters</span></span>](#ID4EQB)
  * [<span data-ttu-id="03717-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="03717-111">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="03717-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="03717-112">Request body</span></span>](#ID4EIF)
  * [<span data-ttu-id="03717-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="03717-113">Response body</span></span>](#ID4ETF)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="03717-114">注釈</span><span class="sxs-lookup"><span data-stu-id="03717-114">Remarks</span></span>

<span data-ttu-id="03717-115">この HTTP/REST メソッドは、セッション情報せず、ハンドルのデータのみのクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="03717-115">This HTTP/REST method creates queries for handle data only, without any session information.</span></span> <span data-ttu-id="03717-116">**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForSocialGroupAsync**によって折り返すことができます。</span><span class="sxs-lookup"><span data-stu-id="03717-116">It can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForSocialGroupAsync**.</span></span>

<span data-ttu-id="03717-117">このメソッドの要求本文で型フィールドは、「アクティビティ」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="03717-117">The type field in the request body for this method must be set to "activity".</span></span> <span data-ttu-id="03717-118">応答本文内の項目は、 **MultiplayerActivityDetails**のプロパティに直接マップされます。</span><span class="sxs-lookup"><span data-stu-id="03717-118">The items in the response body map directly to the properties of the **MultiplayerActivityDetails**.</span></span>

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="03717-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03717-119">URI parameters</span></span>

<a id="ID4EQB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="03717-120">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="03717-120">Query string parameters</span></span>

<span data-ttu-id="03717-121">クエリは、次の表にクエリ文字列パラメーターを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="03717-121">A query can be modified using the query string parameters in the next table.</span></span>

| <b><span data-ttu-id="03717-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="03717-122">Parameter</span></span></b>| <b><span data-ttu-id="03717-123">型</span><span class="sxs-lookup"><span data-stu-id="03717-123">Type</span></span></b>| <b><span data-ttu-id="03717-124">説明</span><span class="sxs-lookup"><span data-stu-id="03717-124">Description</span></span></b>|
| --- | --- | --- | --- |
| <span data-ttu-id="03717-125">キーワード</span><span class="sxs-lookup"><span data-stu-id="03717-125">keyword</span></span>| <span data-ttu-id="03717-126">string</span><span class="sxs-lookup"><span data-stu-id="03717-126">string</span></span>| <span data-ttu-id="03717-127">キーワード、たとえば、"foo"a を取得する場合は、セッションまたはテンプレートに含まれてする必要があります。</span><span class="sxs-lookup"><span data-stu-id="03717-127">A keyword, for example, "foo", that must be found in sessions or templates if they are to be retrieved.</span></span> |
| <span data-ttu-id="03717-128">xuid</span><span class="sxs-lookup"><span data-stu-id="03717-128">xuid</span></span>| <span data-ttu-id="03717-129">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="03717-129">64-bit unsigned integer</span></span>| <span data-ttu-id="03717-130">Xbox ユーザー ID で、たとえば、「123」、セッションをクエリに含めます。</span><span class="sxs-lookup"><span data-stu-id="03717-130">The Xbox user ID, for example, "123", for sessions to include in the query.</span></span> <span data-ttu-id="03717-131">既定では、ユーザーに含まれているため、セッション内でアクティブにある必要があります。</span><span class="sxs-lookup"><span data-stu-id="03717-131">By default, the user must be active in the session for it to be included.</span></span> |
| <span data-ttu-id="03717-132">予約</span><span class="sxs-lookup"><span data-stu-id="03717-132">reservations</span></span>| <span data-ttu-id="03717-133">boolean</span><span class="sxs-lookup"><span data-stu-id="03717-133">boolean</span></span>| <span data-ttu-id="03717-134">セッションを含める場合は、ユーザーによって予約済みプレイヤーとして設定されますが、しておらずアクティブのプレイヤーに参加していません。</span><span class="sxs-lookup"><span data-stu-id="03717-134">True to include sessions for which the user is set as a reserved player but has not joined to become an active player.</span></span> <span data-ttu-id="03717-135">自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。</span><span class="sxs-lookup"><span data-stu-id="03717-135">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="03717-136">非アクティブです</span><span class="sxs-lookup"><span data-stu-id="03717-136">inactive</span></span>| <span data-ttu-id="03717-137">boolean</span><span class="sxs-lookup"><span data-stu-id="03717-137">boolean</span></span>| <span data-ttu-id="03717-138">ユーザーが受け入れたがアクティブに再生されていないセッションを 場合は true。</span><span class="sxs-lookup"><span data-stu-id="03717-138">True to include sessions that the user has accepted but is not actively playing.</span></span> <span data-ttu-id="03717-139">セッションのユーザーが「準備完了」ですが「アクティブ」では、非アクティブとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="03717-139">Sessions in which the user is "ready" but not "active" count as inactive.</span></span> |
| <span data-ttu-id="03717-140">プライベート</span><span class="sxs-lookup"><span data-stu-id="03717-140">private</span></span>| <span data-ttu-id="03717-141">boolean</span><span class="sxs-lookup"><span data-stu-id="03717-141">boolean</span></span>| <span data-ttu-id="03717-142">プライベート セッションを含める場合は true。</span><span class="sxs-lookup"><span data-stu-id="03717-142">True to include private sessions.</span></span> <span data-ttu-id="03717-143">自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。</span><span class="sxs-lookup"><span data-stu-id="03717-143">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="03717-144">visibility</span><span class="sxs-lookup"><span data-stu-id="03717-144">visibility</span></span>| <span data-ttu-id="03717-145">string</span><span class="sxs-lookup"><span data-stu-id="03717-145">string</span></span>| <span data-ttu-id="03717-146">セッションの可視性の状態。</span><span class="sxs-lookup"><span data-stu-id="03717-146">Visibility state for the sessions.</span></span> <span data-ttu-id="03717-147">設定可能な値は、 <b>MultiplayerSessionVisibility</b>によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="03717-147">Possible values are defined by the <b>MultiplayerSessionVisibility</b>.</span></span> <span data-ttu-id="03717-148">このパラメーターは、「開く」に設定されている場合、クエリが開いている唯一のセッションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="03717-148">If this parameter is set to "open", the query should include only open sessions.</span></span> <span data-ttu-id="03717-149"><i>プライベート</i>のパラメーターを設定する必要があります「プライベート」に設定されている場合を true に設定します。</span><span class="sxs-lookup"><span data-stu-id="03717-149">If it is set to "private", the <i>private</i> parameter must be set to true.</span></span> |
| <span data-ttu-id="03717-150">version</span><span class="sxs-lookup"><span data-stu-id="03717-150">version</span></span>| <span data-ttu-id="03717-151">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="03717-151">32-bit signed integer</span></span>| <span data-ttu-id="03717-152">セッションの最大バージョンが含まれている場合があります。</span><span class="sxs-lookup"><span data-stu-id="03717-152">The maximum session version that should be included.</span></span> <span data-ttu-id="03717-153">たとえば、以下を含めるようにまたは 2 の値が 2 の主なセッションのバージョンでのみそのセッションを指定します。</span><span class="sxs-lookup"><span data-stu-id="03717-153">For example, a value of 2 specifies that only sessions with a major session version of 2 or less should be included.</span></span> <span data-ttu-id="03717-154">バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="03717-154">The version number must be less than or equal to the request's contract version mod 100.</span></span> |
| <span data-ttu-id="03717-155">アプリでは</span><span class="sxs-lookup"><span data-stu-id="03717-155">take</span></span>| <span data-ttu-id="03717-156">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="03717-156">32-bit signed integer</span></span>| <span data-ttu-id="03717-157">取得するセッションの最大数。</span><span class="sxs-lookup"><span data-stu-id="03717-157">The maximum number of sessions to retrieve.</span></span> <span data-ttu-id="03717-158">この数は 0 ~ 100 の間にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="03717-158">This number must be between 0 and 100.</span></span> |


<span data-ttu-id="03717-159">*プライベート*または*予約*のいずれかを true に設定するには、セッションにサーバー レベルのアクセスが必要です。</span><span class="sxs-lookup"><span data-stu-id="03717-159">Setting either *private* or *reservations* to true requires server-level access to the session.</span></span> <span data-ttu-id="03717-160">代わりに、これらの設定では、呼び出し元の XUID を要求 URI の XUID フィルターに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="03717-160">Alternatively, these settings require the caller's XUID claim to match the XUID filter in the URI.</span></span> <span data-ttu-id="03717-161">それ以外の場合、/403 HTTP ステータス コードが返されます、そのようなセッションが実際に存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="03717-161">Otherwise, the HTTP/403 status code is returned, whether or not any such sessions actually exist.</span></span>

<a id="ID4EBF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="03717-162">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="03717-162">HTTP status codes</span></span>
<span data-ttu-id="03717-163">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="03717-163">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EIF"></a>


## <a name="request-body"></a><span data-ttu-id="03717-164">要求本文</span><span class="sxs-lookup"><span data-stu-id="03717-164">Request body</span></span>

<span data-ttu-id="03717-165">ユーザーの「お気に入り」のソーシャル グラフのすべてのアクティビティ、要求本文は次のような。</span><span class="sxs-lookup"><span data-stu-id="03717-165">For all activities for a user's "favorites" social graph, the request body looks like this:</span></span>


```cpp
{
  "type": "activity",
  "scid": "B5B1F71F-A328-4371-89E0-C3AD222D0E92"  // optional filter on scid
  "owners": {
    "people": {
      "moniker": "favorites",
      "monikerXuid": "3210"
    }
  }
}

```


<a id="ID4ETF"></a>


## <a name="response-body"></a><span data-ttu-id="03717-166">応答本文</span><span class="sxs-lookup"><span data-stu-id="03717-166">Response body</span></span>

<span data-ttu-id="03717-167">ハンドルは、各構造体に埋め込まれている一意の id、ハンドルの構造体の配列として取得されます。</span><span class="sxs-lookup"><span data-stu-id="03717-167">The handles are retrieved as an array of handle structures, with a unique ID embedded in each structure.</span></span>


```cpp
{
  "results": [
    {
      "id": "11111111-ebe0-42da-885f-033860a818f6",
      "type": "activity",
      "version": 1,
      "sessionRef": {
        "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
        "templateName": "party",
        "name": "e3a836aeac6f4cbe9bcab985494d3175"
      },
      "titleId": "1234567",
      "ownerXuid": "3212",
      {
        "id": "11111111-ebe0-42da-885f-033860a818f7",
      "type": "activity",
      "version": 1,
      "sessionRef": {
         "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
        "templateName": "TitleStorageTestDefault",
        "name": "795fcaa7-8377-4281-bd7e-e86c12843632"
      },
      "titleId": "1234567",
      "ownerXuid": "3212",
    }
  }]
}

```


<a id="ID4E4F"></a>


## <a name="see-also"></a><span data-ttu-id="03717-168">関連項目</span><span class="sxs-lookup"><span data-stu-id="03717-168">See also</span></span>

<a id="ID4E6F"></a>


##### <a name="parent"></a><span data-ttu-id="03717-169">Parent</span><span class="sxs-lookup"><span data-stu-id="03717-169">Parent</span></span>

[<span data-ttu-id="03717-170">/handles/query</span><span class="sxs-lookup"><span data-stu-id="03717-170">/handles/query</span></span>](uri-handlesquery.md)
