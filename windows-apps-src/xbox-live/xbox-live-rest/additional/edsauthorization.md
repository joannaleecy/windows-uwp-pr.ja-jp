---
title: EDS 承認
assetID: bd0bdc8e-084a-7140-98da-6d3721bda112
permalink: en-us/docs/xboxlive/rest/edsauthorization.html
description: " EDS 承認"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3e5c5ef3bf3c864215544391bc291a26f6c05d0f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607607"
---
# <a name="eds-authorization"></a><span data-ttu-id="51bdb-104">EDS 承認</span><span class="sxs-lookup"><span data-stu-id="51bdb-104">EDS Authorization</span></span>
 
  * [<span data-ttu-id="51bdb-105">はじめに</span><span class="sxs-lookup"><span data-stu-id="51bdb-105">Introduction</span></span>](#ID4EN)
  * [<span data-ttu-id="51bdb-106">承認プロセス</span><span class="sxs-lookup"><span data-stu-id="51bdb-106">Authorization Process</span></span>](#ID4EFB)
  * [<span data-ttu-id="51bdb-107">3.0 のトークン:Vs のマルチ ユーザー。1 人のユーザー</span><span class="sxs-lookup"><span data-stu-id="51bdb-107">3.0 Tokens: Multiuser vs. Single User</span></span>](#ID4EEC)
  * [<span data-ttu-id="51bdb-108">EDS は複数のユーザーをサポートしますか。</span><span class="sxs-lookup"><span data-stu-id="51bdb-108">Does EDS support multi-users?</span></span>](#ID4EYC)
 
<a id="ID4EN"></a>

 
## <a name="introduction"></a><span data-ttu-id="51bdb-109">概要</span><span class="sxs-lookup"><span data-stu-id="51bdb-109">Introduction</span></span>
 
<span data-ttu-id="51bdb-110">エンターテイメント検出サービス (EDS) 3.1 では、匿名のトラフィックはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="51bdb-110">Entertainment Discovery Services (EDS) 3.1 will not support Anonymous traffic.</span></span> <span data-ttu-id="51bdb-111">認証は、EDS にすべての要求に必要です。</span><span class="sxs-lookup"><span data-stu-id="51bdb-111">Authentication is required for all requests to EDS.</span></span> <span data-ttu-id="51bdb-112">EDS、XToken 正しくクライアントを認証する呼び出し元から必要になります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-112">EDS will require an XToken from callers to properly authenticate clients.</span></span> <span data-ttu-id="51bdb-113">これらのトークンは XSTS によって生成され、さまざまな Xbox 認証サービス (XAS) を介して取得できます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-113">These tokens are produced by XSTS and can be obtained through various Xbox Authentication Services (XAS).</span></span> <span data-ttu-id="51bdb-114">デバイス、ユーザーはすべて、トークンの id を定義するタイトルの別の認証サービスがあります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-114">There are separate authentication services for Device, Users and Titles which will all define the identity of the token.</span></span>
 
<span data-ttu-id="51bdb-115">XSTS では、Xbox LIVE のゲートキーパーです。</span><span class="sxs-lookup"><span data-stu-id="51bdb-115">XSTS is the gatekeeper for Xbox LIVE.</span></span> <span data-ttu-id="51bdb-116">ユーザーまたはデバイスがいずれかの Xbox LIVE サービスに接続するために承認されているかどうかを判断する防御の最前線になります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-116">It is the first line of defense to determine if a user or device is authorized to connect to any of the Xbox LIVE services.</span></span> <span data-ttu-id="51bdb-117">ユーザーを認証した後、XSTS に安全に、サービス上のコンポーネントを識別するために使用できる、XToken が生成されます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-117">After authenticating the user, the XSTS generates an XToken that they can use to securely identify themselves to any component on the service.</span></span> <span data-ttu-id="51bdb-118">この XToken は、passport to LIVE です。</span><span class="sxs-lookup"><span data-stu-id="51bdb-118">This XToken is your passport to LIVE.</span></span>
 
<span data-ttu-id="51bdb-119">人や物、当社のサービスを使用します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-119">People and things, want to use our services.</span></span> <span data-ttu-id="51bdb-120">あり当社のサービスを使用できるこれらの物や人間のほとんどが必要です。</span><span class="sxs-lookup"><span data-stu-id="51bdb-120">And we want most of those things and people to be able to use our services.</span></span> <span data-ttu-id="51bdb-121">しかし、方法をどうやって確認事項は、人のユーザーになりすましていることと、ユーザーが実際にはユーザーでしょうか。</span><span class="sxs-lookup"><span data-stu-id="51bdb-121">But how do we make sure that the things aren't pretending to be people, and that the people are actually who they say they are?</span></span> <span data-ttu-id="51bdb-122">他のユーザーを識別するために使用するトークンを使用して提供します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-122">We provide them with tokens which they can use to identify themselves to others.</span></span>
 
<span data-ttu-id="51bdb-123">これらのトークンは、XSTS によって生成され、XTokens として一般的に参照されます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-123">These tokens are produced by the XSTS and are generally referred to as XTokens.</span></span> <span data-ttu-id="51bdb-124">XToken がカバーする、さまざまな異なるものを含めることがあり、さまざまな形式をトークンに使用される広義の用語がすべて作成、署名済み、および必要に応じて、XSTS サーバーによって暗号化します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-124">XToken is a broad term that is used to cover tokens that contain a variety of different things and can come in many different forms, but they are all created, signed, and optionally encrypted by the XSTS server.</span></span> <span data-ttu-id="51bdb-125">内部的には、XSTS では、MXAN を使用して作成し、トークンの書式を設定します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-125">Internally, XSTS uses MXAN to create and format the tokens.</span></span> <span data-ttu-id="51bdb-126">MXAN は、これまで、XToken から情報を抽出する唯一のコンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="51bdb-126">MXAN is the only component that ever extracts information from an XToken.</span></span> <span data-ttu-id="51bdb-127">トークンを使用するサービスは、パスワードを解読する MXAN に要求ヘッダーを渡します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-127">Services consuming the tokens pass the request headers to MXAN to be cracked.</span></span> <span data-ttu-id="51bdb-128">トークンの処理および検証し、トークンで表されるクレームは、サービスに返されます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-128">The tokens are processed and validated and the claims expressed in the token are returned to the service.</span></span> <span data-ttu-id="51bdb-129">これらの要求を呼び出し元のユーザーまたはデバイスを特定し、その情報に基づいてアクションを実行値を使用してサービスのことができます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-129">The service can then use these claim values to identify the calling user or device, and perform actions based on that information.</span></span>
 
<span data-ttu-id="51bdb-130">基本的な id トークン - ユーザー、デバイス、および [タイトル] -、Xbox 認証サービス (XAS) によってが提供されます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-130">The basic identity tokens - for User, Device, and Title - are provided by the Xbox Authentication Services (XAS).</span></span> <span data-ttu-id="51bdb-131">各 XAS が担当するさまざまなクレームの値を指定します。 id トークンを生成する責任を負います。</span><span class="sxs-lookup"><span data-stu-id="51bdb-131">Each XAS is responsible for generating an identity token which specifies values for various claims that they are responsible for.</span></span>
 
   * <span data-ttu-id="51bdb-132">XASD (XAS デバイス用): デバイス id を提供する DToken を作成します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-132">XASD (XAS for Devices): creates a DToken which provides a Device identity</span></span>
   * <span data-ttu-id="51bdb-133">XASU (XAS ユーザー向け): ユーザー id を提供する UToken を作成します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-133">XASU (XAS for Users): creates a UToken which provides a User identity</span></span>
   * <span data-ttu-id="51bdb-134">XAST (XAS タイトル): タイトル、id を提供する ttoken であるを作成します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-134">XAST (XAS for Titles): creates a TToken which provides a Title identity</span></span>
   
<a id="ID4EFB"></a>

 
## <a name="authorization-process"></a><span data-ttu-id="51bdb-135">承認プロセス</span><span class="sxs-lookup"><span data-stu-id="51bdb-135">Authorization Process</span></span>
 
   * <span data-ttu-id="51bdb-136">1 つまたは複数の id トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-136">Obtain one or more identity tokens.</span></span> <span data-ttu-id="51bdb-137">XToken 多くて 1 つずつ D、U、および T のトークンの使用を要求することができます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-137">You can request an XToken with at most one each of D, U, and T tokens.</span></span> <span data-ttu-id="51bdb-138">D、または U の少なくとも 1 つを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-138">You must provide at least one of D, or U.</span></span> 
     * <span data-ttu-id="51bdb-139">デバイス認証の詳細を提供することで、DToken を XASD から要求します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-139">Request a DToken from XASD by providing device authentication details</span></span>
     * <span data-ttu-id="51bdb-140">ユーザー認証の形式を使った XASU から、UToken を要求します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-140">Request a UToken from XASU with some form of user authentication.</span></span> <span data-ttu-id="51bdb-141">ユーザー認証は、MSA (RPS) トークンの形式で提供される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-141">The user auth is probably provided in the form of an MSA (RPS) token.</span></span>
     * <span data-ttu-id="51bdb-142">XAST から、ttoken であるを要求します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-142">Request a TToken from XAST.</span></span> <span data-ttu-id="51bdb-143">使用可能なタイトルは、DToken XAST に提供することも必要がありますのでが現在実行されているプラットフォームに依存します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-143">The titles that are available depend on the platform currently running so you must provide a DToken to XAST as well.</span></span>
  
   * <span data-ttu-id="51bdb-144">XSTS 要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-144">Create an XSTS Request.</span></span>
 
     * <span data-ttu-id="51bdb-145">証明書利用者のトークンを要求しているパーティを定義します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-145">Define the relying party that you are requesting a token for.</span></span>
     * <span data-ttu-id="51bdb-146">D、U、および T トークンと要求のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-146">Populate the request properties with the D, U, and/or T tokens.</span></span>
    * <span data-ttu-id="51bdb-147">XSTS 要求を実行し、結果として得られる XToken をキャッシュします。</span><span class="sxs-lookup"><span data-stu-id="51bdb-147">Execute the XSTS Request and cache the resulting XToken.</span></span> <span data-ttu-id="51bdb-148">返される XToken が含まれています (最大) すべての id トークンと他にも要求 (サブスクリプションの現在の状態、ユーザー グループなど) からのデバイス、ユーザー、およびタイトルの id 情報。</span><span class="sxs-lookup"><span data-stu-id="51bdb-148">The returned XToken contains (at most) all of the Device, User, and Title identity information from the identity tokens and any additional claims (current subscription status, user groups, etc.).</span></span>
   
<a id="ID4EEC"></a>

 
## <a name="30-tokens-multiuser-vs-single-user"></a><span data-ttu-id="51bdb-149">3.0 のトークン:Vs のマルチ ユーザー。1 人のユーザー</span><span class="sxs-lookup"><span data-stu-id="51bdb-149">3.0 Tokens: Multiuser vs. Single User</span></span>
 
<span data-ttu-id="51bdb-150">これは、3.0 のトークンの形式です。 `XBL3.0 x=&lt;hash>;&lt;token>`</span><span class="sxs-lookup"><span data-stu-id="51bdb-150">This is the form of the 3.0 token: `XBL3.0 x=&lt;hash>;&lt;token>`</span></span>
 
<span data-ttu-id="51bdb-151">に応じて、&lt;ハッシュ >、トークンは異なる方法で扱われます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-151">Depending on the &lt;hash>, the token is treated differently:</span></span>
 
   * <span data-ttu-id="51bdb-152">場合&lt;ハッシュ > と等しい \* (アスタリスク)、特定のユーザーが要求を実行していないし、トークン内のすべてのユーザーが、逆シリアル化されたプリンシパルは存在します。</span><span class="sxs-lookup"><span data-stu-id="51bdb-152">If &lt;hash> is equal to \* (asterisk), then no particular user is performing the request and all the users in the token are present in the deserialized principal.</span></span> <span data-ttu-id="51bdb-153">これは、true のマルチ ユーザー フォームです。</span><span class="sxs-lookup"><span data-stu-id="51bdb-153">This is the true multiuser form.</span></span>
   * <span data-ttu-id="51bdb-154">場合&lt;ハッシュ > - (ダッシュ) に等しいが、要求を実行しているユーザーがありません。</span><span class="sxs-lookup"><span data-stu-id="51bdb-154">If &lt;hash> is equal to - (dash), then no users are performing the request.</span></span> <span data-ttu-id="51bdb-155">逆シリアル化されたプリンシパルのすべてのユーザーは削除されます。</span><span class="sxs-lookup"><span data-stu-id="51bdb-155">Any users in the deserialized principal are stripped out.</span></span>
   * <span data-ttu-id="51bdb-156">場合&lt;ハッシュ > が等しくない \* または - トークンのユーザーが要求を行っていることを示す識別子になります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-156">If &lt;hash> is not equal to \* or - then it is an identifier indicating which user in the token is making the request.</span></span> <span data-ttu-id="51bdb-157">指定したユーザーのみが、逆シリアル化されたプリンシパルは存在になります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-157">Only the indicated user will be present in the deserialized principal.</span></span> <span data-ttu-id="51bdb-158">その他のすべてのユーザーは削除されます。これは、シングル ユーザー 3.0 トークンです。</span><span class="sxs-lookup"><span data-stu-id="51bdb-158">All other users are stripped out. This is the single-user 3.0 token.</span></span>
   
<a id="ID4EYC"></a>

 
## <a name="does-eds-support-multi-users"></a><span data-ttu-id="51bdb-159">EDS は複数のユーザーをサポートしますか。</span><span class="sxs-lookup"><span data-stu-id="51bdb-159">Does EDS support multi-users?</span></span>
 * <span data-ttu-id="51bdb-160">答えはノーです。</span><span class="sxs-lookup"><span data-stu-id="51bdb-160">The answer is no.</span></span> <span data-ttu-id="51bdb-161">説明した場合は、コンソールは常に 1 人のユーザー トークンを送信していました。</span><span class="sxs-lookup"><span data-stu-id="51bdb-161">In the case that was described, the console will always send single user tokens.</span></span> <span data-ttu-id="51bdb-162">サインインしている複数のユーザーがある場合でも、指定された「呼び出し元」、他のすべての id が削除されますが必要があります。</span><span class="sxs-lookup"><span data-stu-id="51bdb-162">Even if there are multiple users signed in, there must be an indicated "Caller", where all other identities are dropped.</span></span>
  
<a id="ID4E6C"></a>

 
## <a name="see-also"></a><span data-ttu-id="51bdb-163">関連項目</span><span class="sxs-lookup"><span data-stu-id="51bdb-163">See also</span></span>
 
<a id="ID4EBD"></a>

 
##### <a name="parent"></a><span data-ttu-id="51bdb-164">Parent</span><span class="sxs-lookup"><span data-stu-id="51bdb-164">Parent</span></span>  

[<span data-ttu-id="51bdb-165">その他の参照</span><span class="sxs-lookup"><span data-stu-id="51bdb-165">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4END"></a>

 
##### <a name="further-information"></a><span data-ttu-id="51bdb-166">詳細情報</span><span class="sxs-lookup"><span data-stu-id="51bdb-166">Further Information</span></span> 

[<span data-ttu-id="51bdb-167">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="51bdb-167">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   