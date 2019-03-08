---
title: POST (/handles/query)
assetID: a1a47d49-5c3f-8021-a213-13eb8bddf16a
permalink: en-us/docs/xboxlive/rest/uri-handlesquerypost.html
description: " POST (/handles/query)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7540c117931c01c24c79cef6c8ab6540cb65bbcb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651507"
---
# <a name="post-handlesquery"></a><span data-ttu-id="36dc0-104">POST (/handles/query)</span><span class="sxs-lookup"><span data-stu-id="36dc0-104">POST (/handles/query)</span></span>
<span data-ttu-id="36dc0-105">セッション ハンドルのクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="36dc0-105">Creates queries for session handles.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="36dc0-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="36dc0-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="36dc0-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="36dc0-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="36dc0-108">注釈</span><span class="sxs-lookup"><span data-stu-id="36dc0-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="36dc0-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="36dc0-109">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="36dc0-110">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="36dc0-110">Query string parameters</span></span>](#ID4EQB)
  * [<span data-ttu-id="36dc0-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="36dc0-111">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="36dc0-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="36dc0-112">Request body</span></span>](#ID4EIF)
  * [<span data-ttu-id="36dc0-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="36dc0-113">Response body</span></span>](#ID4ETF)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="36dc0-114">注釈</span><span class="sxs-lookup"><span data-stu-id="36dc0-114">Remarks</span></span>

<span data-ttu-id="36dc0-115">この HTTP/REST メソッドでは、任意のセッション情報がない場合のみ、ハンドルのデータに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="36dc0-115">This HTTP/REST method creates queries for handle data only, without any session information.</span></span> <span data-ttu-id="36dc0-116">これによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForSocialGroupAsync**します。</span><span class="sxs-lookup"><span data-stu-id="36dc0-116">It can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForSocialGroupAsync**.</span></span>

<span data-ttu-id="36dc0-117">このメソッドの要求本文の型フィールドは、「アクティビティ」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-117">The type field in the request body for this method must be set to "activity".</span></span> <span data-ttu-id="36dc0-118">応答本文内の項目がマップのプロパティに直接、 **MultiplayerActivityDetails**します。</span><span class="sxs-lookup"><span data-stu-id="36dc0-118">The items in the response body map directly to the properties of the **MultiplayerActivityDetails**.</span></span>

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="36dc0-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="36dc0-119">URI parameters</span></span>

<a id="ID4EQB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="36dc0-120">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="36dc0-120">Query string parameters</span></span>

<span data-ttu-id="36dc0-121">クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="36dc0-121">A query can be modified using the query string parameters in the next table.</span></span>

| <span data-ttu-id="36dc0-122"><b>パラメーター</b></span><span class="sxs-lookup"><span data-stu-id="36dc0-122"><b>Parameter</b></span></span>| <span data-ttu-id="36dc0-123"><b>型</b></span><span class="sxs-lookup"><span data-stu-id="36dc0-123"><b>Type</b></span></span>| <span data-ttu-id="36dc0-124"><b>説明</b></span><span class="sxs-lookup"><span data-stu-id="36dc0-124"><b>Description</b></span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="36dc0-125">キーワード</span><span class="sxs-lookup"><span data-stu-id="36dc0-125">keyword</span></span>| <span data-ttu-id="36dc0-126">string</span><span class="sxs-lookup"><span data-stu-id="36dc0-126">string</span></span>| <span data-ttu-id="36dc0-127">キーワード、たとえば、"foo"と、a を取得する場合は、セッションまたはテンプレート内で検出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-127">A keyword, for example, "foo", that must be found in sessions or templates if they are to be retrieved.</span></span> |
| <span data-ttu-id="36dc0-128">xuid</span><span class="sxs-lookup"><span data-stu-id="36dc0-128">xuid</span></span>| <span data-ttu-id="36dc0-129">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="36dc0-129">64-bit unsigned integer</span></span>| <span data-ttu-id="36dc0-130">Xbox ユーザー ID で、たとえば、「123」、セッション、クエリに含める。</span><span class="sxs-lookup"><span data-stu-id="36dc0-130">The Xbox user ID, for example, "123", for sessions to include in the query.</span></span> <span data-ttu-id="36dc0-131">既定では、ユーザーに含まれているセッションでアクティブにある必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-131">By default, the user must be active in the session for it to be included.</span></span> |
| <span data-ttu-id="36dc0-132">予約</span><span class="sxs-lookup"><span data-stu-id="36dc0-132">reservations</span></span>| <span data-ttu-id="36dc0-133">boolean</span><span class="sxs-lookup"><span data-stu-id="36dc0-133">boolean</span></span>| <span data-ttu-id="36dc0-134">対象のセッションが含まれる場合は true、ユーザーは、予約済みのプレーヤーとして設定されますが、作業中のプレーヤーに参加していません。</span><span class="sxs-lookup"><span data-stu-id="36dc0-134">True to include sessions for which the user is set as a reserved player but has not joined to become an active player.</span></span> <span data-ttu-id="36dc0-135">このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。</span><span class="sxs-lookup"><span data-stu-id="36dc0-135">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="36dc0-136">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="36dc0-136">inactive</span></span>| <span data-ttu-id="36dc0-137">boolean</span><span class="sxs-lookup"><span data-stu-id="36dc0-137">boolean</span></span>| <span data-ttu-id="36dc0-138">ユーザーが受け入れたにもかかわらず再生されていないセッションは、true です。</span><span class="sxs-lookup"><span data-stu-id="36dc0-138">True to include sessions that the user has accepted but is not actively playing.</span></span> <span data-ttu-id="36dc0-139">セッションのユーザーが"ready"ですが「アクティブ」では、非アクティブとしてカウントします。</span><span class="sxs-lookup"><span data-stu-id="36dc0-139">Sessions in which the user is "ready" but not "active" count as inactive.</span></span> |
| <span data-ttu-id="36dc0-140">プライベート</span><span class="sxs-lookup"><span data-stu-id="36dc0-140">private</span></span>| <span data-ttu-id="36dc0-141">boolean</span><span class="sxs-lookup"><span data-stu-id="36dc0-141">boolean</span></span>| <span data-ttu-id="36dc0-142">プライベート セッションを含めるには true です。</span><span class="sxs-lookup"><span data-stu-id="36dc0-142">True to include private sessions.</span></span> <span data-ttu-id="36dc0-143">このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。</span><span class="sxs-lookup"><span data-stu-id="36dc0-143">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="36dc0-144">visibility</span><span class="sxs-lookup"><span data-stu-id="36dc0-144">visibility</span></span>| <span data-ttu-id="36dc0-145">string</span><span class="sxs-lookup"><span data-stu-id="36dc0-145">string</span></span>| <span data-ttu-id="36dc0-146">セッションの表示状態。</span><span class="sxs-lookup"><span data-stu-id="36dc0-146">Visibility state for the sessions.</span></span> <span data-ttu-id="36dc0-147">使用可能な値が定義されている、 <b>MultiplayerSessionVisibility</b>します。</span><span class="sxs-lookup"><span data-stu-id="36dc0-147">Possible values are defined by the <b>MultiplayerSessionVisibility</b>.</span></span> <span data-ttu-id="36dc0-148">このパラメーターが「開いている」に設定されている場合、クエリはのみ開いているセッションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-148">If this parameter is set to "open", the query should include only open sessions.</span></span> <span data-ttu-id="36dc0-149">"Private"で、設定されている場合、<i>プライベート</i>パラメーターを設定する必要がありますを true にします。</span><span class="sxs-lookup"><span data-stu-id="36dc0-149">If it is set to "private", the <i>private</i> parameter must be set to true.</span></span> |
| <span data-ttu-id="36dc0-150">version</span><span class="sxs-lookup"><span data-stu-id="36dc0-150">version</span></span>| <span data-ttu-id="36dc0-151">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="36dc0-151">32-bit signed integer</span></span>| <span data-ttu-id="36dc0-152">組み込む必要があるセッションの最大バージョン。</span><span class="sxs-lookup"><span data-stu-id="36dc0-152">The maximum session version that should be included.</span></span> <span data-ttu-id="36dc0-153">たとえば、2 の値が 2 の主要なセッションのバージョンでのみそのセッションを指定または小さい必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-153">For example, a value of 2 specifies that only sessions with a major session version of 2 or less should be included.</span></span> <span data-ttu-id="36dc0-154">バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-154">The version number must be less than or equal to the request's contract version mod 100.</span></span> |
| <span data-ttu-id="36dc0-155">Take</span><span class="sxs-lookup"><span data-stu-id="36dc0-155">take</span></span>| <span data-ttu-id="36dc0-156">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="36dc0-156">32-bit signed integer</span></span>| <span data-ttu-id="36dc0-157">取得するセッションの最大数。</span><span class="sxs-lookup"><span data-stu-id="36dc0-157">The maximum number of sessions to retrieve.</span></span> <span data-ttu-id="36dc0-158">この数は、0 ~ 100 の範囲にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-158">This number must be between 0 and 100.</span></span> |


<span data-ttu-id="36dc0-159">いずれかを設定*プライベート*または*予約*に true の場合、セッションにサーバー レベルのアクセスが必要です。</span><span class="sxs-lookup"><span data-stu-id="36dc0-159">Setting either *private* or *reservations* to true requires server-level access to the session.</span></span> <span data-ttu-id="36dc0-160">または、これらの設定では、呼び出し元の XUID 要求の URI に XUID フィルターに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-160">Alternatively, these settings require the caller's XUID claim to match the XUID filter in the URI.</span></span> <span data-ttu-id="36dc0-161">それ以外の場合、HTTP/403 状態コードが返されます、このようなすべてのセッションが実際に存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="36dc0-161">Otherwise, the HTTP/403 status code is returned, whether or not any such sessions actually exist.</span></span>

<a id="ID4EBF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="36dc0-162">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="36dc0-162">HTTP status codes</span></span>
<span data-ttu-id="36dc0-163">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="36dc0-163">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EIF"></a>


## <a name="request-body"></a><span data-ttu-id="36dc0-164">要求本文</span><span class="sxs-lookup"><span data-stu-id="36dc0-164">Request body</span></span>

<span data-ttu-id="36dc0-165">ユーザーの「お気に入り」ソーシャル グラフのすべてのアクティビティの要求本文はようになります。</span><span class="sxs-lookup"><span data-stu-id="36dc0-165">For all activities for a user's "favorites" social graph, the request body looks like this:</span></span>


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


## <a name="response-body"></a><span data-ttu-id="36dc0-166">応答本文</span><span class="sxs-lookup"><span data-stu-id="36dc0-166">Response body</span></span>

<span data-ttu-id="36dc0-167">ハンドルは、各構造体に埋め込まれている一意の id、ハンドルの構造体の配列として取得されます。</span><span class="sxs-lookup"><span data-stu-id="36dc0-167">The handles are retrieved as an array of handle structures, with a unique ID embedded in each structure.</span></span>


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


## <a name="see-also"></a><span data-ttu-id="36dc0-168">関連項目</span><span class="sxs-lookup"><span data-stu-id="36dc0-168">See also</span></span>

<a id="ID4E6F"></a>


##### <a name="parent"></a><span data-ttu-id="36dc0-169">Parent</span><span class="sxs-lookup"><span data-stu-id="36dc0-169">Parent</span></span>

[<span data-ttu-id="36dc0-170">/handles/query</span><span class="sxs-lookup"><span data-stu-id="36dc0-170">/handles/query</span></span>](uri-handlesquery.md)
