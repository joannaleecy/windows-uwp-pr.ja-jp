---
title: EDS 承認
assetID: bd0bdc8e-084a-7140-98da-6d3721bda112
permalink: en-us/docs/xboxlive/rest/edsauthorization.html
author: KevinAsgari
description: " EDS 承認"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7f160711474c3ec99bcfbbbf0dc94830a8600d3b
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4615918"
---
# <a name="eds-authorization"></a><span data-ttu-id="56d3e-104">EDS 承認</span><span class="sxs-lookup"><span data-stu-id="56d3e-104">EDS Authorization</span></span>
 
  * [<span data-ttu-id="56d3e-105">概要</span><span class="sxs-lookup"><span data-stu-id="56d3e-105">Introduction</span></span>](#ID4EN)
  * [<span data-ttu-id="56d3e-106">承認プロセス</span><span class="sxs-lookup"><span data-stu-id="56d3e-106">Authorization Process</span></span>](#ID4EFB)
  * [<span data-ttu-id="56d3e-107">3.0 トークン: マルチ ユーザーと単一のユーザー</span><span class="sxs-lookup"><span data-stu-id="56d3e-107">3.0 Tokens: Multiuser vs. Single User</span></span>](#ID4EEC)
  * [<span data-ttu-id="56d3e-108">EDS は複数のユーザーをサポートしますか。</span><span class="sxs-lookup"><span data-stu-id="56d3e-108">Does EDS support multi-users?</span></span>](#ID4EYC)
 
<a id="ID4EN"></a>

 
## <a name="introduction"></a><span data-ttu-id="56d3e-109">概要</span><span class="sxs-lookup"><span data-stu-id="56d3e-109">Introduction</span></span>
 
<span data-ttu-id="56d3e-110">エンターテイメント探索サービス (EDS) 3.1 は、匿名トラフィックをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="56d3e-110">Entertainment Discovery Services (EDS) 3.1 will not support Anonymous traffic.</span></span> <span data-ttu-id="56d3e-111">認証は、すべての要求を EDS 必要があります。</span><span class="sxs-lookup"><span data-stu-id="56d3e-111">Authentication is required for all requests to EDS.</span></span> <span data-ttu-id="56d3e-112">EDS には、クライアントを適切に認証を呼び出し元から、XToken が必要です。</span><span class="sxs-lookup"><span data-stu-id="56d3e-112">EDS will require an XToken from callers to properly authenticate clients.</span></span> <span data-ttu-id="56d3e-113">これらのトークンは、XSTS によって生成し、さまざまな Xbox 認証サービス (XAS) を通じて取得できます。</span><span class="sxs-lookup"><span data-stu-id="56d3e-113">These tokens are produced by XSTS and can be obtained through various Xbox Authentication Services (XAS).</span></span> <span data-ttu-id="56d3e-114">デバイス、ユーザーとタイトルはすべて、トークンの id を定義する別の認証サービスがあります。</span><span class="sxs-lookup"><span data-stu-id="56d3e-114">There are separate authentication services for Device, Users and Titles which will all define the identity of the token.</span></span>
 
<span data-ttu-id="56d3e-115">XSTS では、Xbox LIVE のゲートキーパーです。</span><span class="sxs-lookup"><span data-stu-id="56d3e-115">XSTS is the gatekeeper for Xbox LIVE.</span></span> <span data-ttu-id="56d3e-116">最初の行の防御の Xbox LIVE サービスに接続するユーザーまたはデバイスが承認されているかどうかを確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="56d3e-116">It is the first line of defense to determine if a user or device is authorized to connect to any of the Xbox LIVE services.</span></span> <span data-ttu-id="56d3e-117">ユーザーを認証するには後、は、XSTS は、サービスのコンポーネントを安全に識別に使用できる XToken を生成します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-117">After authenticating the user, the XSTS generates an XToken that they can use to securely identify themselves to any component on the service.</span></span> <span data-ttu-id="56d3e-118">この XToken では、passport LIVE にです。</span><span class="sxs-lookup"><span data-stu-id="56d3e-118">This XToken is your passport to LIVE.</span></span>
 
<span data-ttu-id="56d3e-119">ユーザーとサービスを使用することです。</span><span class="sxs-lookup"><span data-stu-id="56d3e-119">People and things, want to use our services.</span></span> <span data-ttu-id="56d3e-120">ほとんどのそれらモ ノと people サービスを使用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="56d3e-120">And we want most of those things and people to be able to use our services.</span></span> <span data-ttu-id="56d3e-121">しかし、どのようにことを確認することが、ユーザーに装ったいないし、ユーザーが実際に身元がでしょうか。</span><span class="sxs-lookup"><span data-stu-id="56d3e-121">But how do we make sure that the things aren't pretending to be people, and that the people are actually who they say they are?</span></span> <span data-ttu-id="56d3e-122">それらを提供し他のユーザーに識別するために使用するトークンを使用します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-122">We provide them with tokens which they can use to identify themselves to others.</span></span>
 
<span data-ttu-id="56d3e-123">これらのトークンは、XSTS によって生成されたされ、Xtoken として一般的に参照されます。</span><span class="sxs-lookup"><span data-stu-id="56d3e-123">These tokens are produced by the XSTS and are generally referred to as XTokens.</span></span> <span data-ttu-id="56d3e-124">XToken は、さまざまな異なる場合がありますが格納されている多くの異なる形式でトークンを対象に使用される広範な用語が、すべて作成、署名されている、必要に応じて、XSTS サーバーによって暗号化します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-124">XToken is a broad term that is used to cover tokens that contain a variety of different things and can come in many different forms, but they are all created, signed, and optionally encrypted by the XSTS server.</span></span> <span data-ttu-id="56d3e-125">内部では、XSTS では、MXAN を使用して作成し、トークンの書式を設定します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-125">Internally, XSTS uses MXAN to create and format the tokens.</span></span> <span data-ttu-id="56d3e-126">MXAN は、これまで、XToken から情報を抽出する唯一のコンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="56d3e-126">MXAN is the only component that ever extracts information from an XToken.</span></span> <span data-ttu-id="56d3e-127">トークンを使用するサービスを解読する MXAN に要求ヘッダーを渡します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-127">Services consuming the tokens pass the request headers to MXAN to be cracked.</span></span> <span data-ttu-id="56d3e-128">トークンが処理され、検証し、トークンで表されるクレームがサービスに返されます。</span><span class="sxs-lookup"><span data-stu-id="56d3e-128">The tokens are processed and validated and the claims expressed in the token are returned to the service.</span></span> <span data-ttu-id="56d3e-129">サービスは、これらの要求、呼び出し元のユーザーまたはデバイスを識別し、その情報に基づいてアクションを実行する値を使用します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-129">The service can then use these claim values to identify the calling user or device, and perform actions based on that information.</span></span>
 
<span data-ttu-id="56d3e-130">基本的な id トークンのユーザー、デバイス、およびタイトルのについて、Xbox 認証サービス (XAS) によってが提供されます。</span><span class="sxs-lookup"><span data-stu-id="56d3e-130">The basic identity tokens - for User, Device, and Title - are provided by the Xbox Authentication Services (XAS).</span></span> <span data-ttu-id="56d3e-131">各 XAS を担当しているさまざまな要求の値を指定する id トークンを生成します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-131">Each XAS is responsible for generating an identity token which specifies values for various claims that they are responsible for.</span></span>
 
   * <span data-ttu-id="56d3e-132">XASD (デバイスの XAS): デバイスの id を提供する DToken を作成します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-132">XASD (XAS for Devices): creates a DToken which provides a Device identity</span></span>
   * <span data-ttu-id="56d3e-133">XASU (ユーザーの XAS): ユーザー id を提供する UToken を作成します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-133">XASU (XAS for Users): creates a UToken which provides a User identity</span></span>
   * <span data-ttu-id="56d3e-134">XAST (XAS のタイトル): タイトルの id を提供する TToken を作成します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-134">XAST (XAS for Titles): creates a TToken which provides a Title identity</span></span>
   
<a id="ID4EFB"></a>

 
## <a name="authorization-process"></a><span data-ttu-id="56d3e-135">承認プロセス</span><span class="sxs-lookup"><span data-stu-id="56d3e-135">Authorization Process</span></span>
 
   * <span data-ttu-id="56d3e-136">1 つまたは複数のユーザー トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-136">Obtain one or more identity tokens.</span></span> <span data-ttu-id="56d3e-137">最大で 1 つずつ D、U、および T トークンを含む XToken を要求することができます。</span><span class="sxs-lookup"><span data-stu-id="56d3e-137">You can request an XToken with at most one each of D, U, and T tokens.</span></span> <span data-ttu-id="56d3e-138">D、または U の少なくとも 1 つを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="56d3e-138">You must provide at least one of D, or U.</span></span> 
     * <span data-ttu-id="56d3e-139">XASD からデバイスの認証の詳細を提供することによって、DToken を要求します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-139">Request a DToken from XASD by providing device authentication details</span></span>
     * <span data-ttu-id="56d3e-140">ユーザーの認証の形式を使った XASU から、UToken を要求します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-140">Request a UToken from XASU with some form of user authentication.</span></span> <span data-ttu-id="56d3e-141">ユーザーの認証は MSA (RPS) トークンの形式で提供される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="56d3e-141">The user auth is probably provided in the form of an MSA (RPS) token.</span></span>
     * <span data-ttu-id="56d3e-142">XAST から、TToken を要求します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-142">Request a TToken from XAST.</span></span> <span data-ttu-id="56d3e-143">使用可能なタイトルは、現在実行して、DToken XAST に提供することもする必要があるため、プラットフォームによって異なります。</span><span class="sxs-lookup"><span data-stu-id="56d3e-143">The titles that are available depend on the platform currently running so you must provide a DToken to XAST as well.</span></span>
  
   * <span data-ttu-id="56d3e-144">XSTS 要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-144">Create an XSTS Request.</span></span>
 
     * <span data-ttu-id="56d3e-145">トークンを要求している証明書利用者パーティーを定義します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-145">Define the relying party that you are requesting a token for.</span></span>
     * <span data-ttu-id="56d3e-146">D、U や T トークンと要求プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-146">Populate the request properties with the D, U, and/or T tokens.</span></span>
    * <span data-ttu-id="56d3e-147">XSTS 要求を実行し、結果として得られる XToken をキャッシュします。</span><span class="sxs-lookup"><span data-stu-id="56d3e-147">Execute the XSTS Request and cache the resulting XToken.</span></span> <span data-ttu-id="56d3e-148">返された XToken が含まれています (ほとんど) のすべての id トークンと追加の要求 (サブスクリプションの現在の状態、ユーザーのグループなど) からデバイス、ユーザー、およびタイトル id の情報の。</span><span class="sxs-lookup"><span data-stu-id="56d3e-148">The returned XToken contains (at most) all of the Device, User, and Title identity information from the identity tokens and any additional claims (current subscription status, user groups, etc.).</span></span>
   
<a id="ID4EEC"></a>

 
## <a name="30-tokens-multiuser-vs-single-user"></a><span data-ttu-id="56d3e-149">3.0 トークン: マルチ ユーザーと単一のユーザー</span><span class="sxs-lookup"><span data-stu-id="56d3e-149">3.0 Tokens: Multiuser vs. Single User</span></span>
 
<span data-ttu-id="56d3e-150">これは、3.0 トークンの形式です。</span><span class="sxs-lookup"><span data-stu-id="56d3e-150">This is the form of the 3.0 token:</span></span> `XBL3.0 x=&lt;hash>;&lt;token>`
 
<span data-ttu-id="56d3e-151">によって、&lt;ハッシュ >、トークンが異なる方法で処理します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-151">Depending on the &lt;hash>, the token is treated differently:</span></span>
 
   * <span data-ttu-id="56d3e-152">場合&lt;ハッシュ > に等しい \* (アスタリスク) し、特定のユーザーが要求を実行していないトークン内のすべてのユーザーが逆シリアル化されたプリンシパルに存在します。</span><span class="sxs-lookup"><span data-stu-id="56d3e-152">If &lt;hash> is equal to \* (asterisk), then no particular user is performing the request and all the users in the token are present in the deserialized principal.</span></span> <span data-ttu-id="56d3e-153">これは、true のマルチ ユーザーの形式です。</span><span class="sxs-lookup"><span data-stu-id="56d3e-153">This is the true multiuser form.</span></span>
   * <span data-ttu-id="56d3e-154">場合&lt;ハッシュ > - (dash) に等しいが要求を実行しているユーザーがありません。</span><span class="sxs-lookup"><span data-stu-id="56d3e-154">If &lt;hash> is equal to - (dash), then no users are performing the request.</span></span> <span data-ttu-id="56d3e-155">逆シリアル化されたプリンシパル内のユーザーは削除されます。</span><span class="sxs-lookup"><span data-stu-id="56d3e-155">Any users in the deserialized principal are stripped out.</span></span>
   * <span data-ttu-id="56d3e-156">場合&lt;ハッシュ > と等しくない \* または - トークンにユーザーが要求を行っていることを示す識別子がします。</span><span class="sxs-lookup"><span data-stu-id="56d3e-156">If &lt;hash> is not equal to \* or - then it is an identifier indicating which user in the token is making the request.</span></span> <span data-ttu-id="56d3e-157">表示されているユーザーのみが逆シリアル化されたプリンシパルになります。</span><span class="sxs-lookup"><span data-stu-id="56d3e-157">Only the indicated user will be present in the deserialized principal.</span></span> <span data-ttu-id="56d3e-158">その他のすべてのユーザーは削除されます。これは、シングル ユーザー 3.0 トークンです。</span><span class="sxs-lookup"><span data-stu-id="56d3e-158">All other users are stripped out. This is the single-user 3.0 token.</span></span>
   
<a id="ID4EYC"></a>

 
## <a name="does-eds-support-multi-users"></a><span data-ttu-id="56d3e-159">EDS は複数のユーザーをサポートしますか。</span><span class="sxs-lookup"><span data-stu-id="56d3e-159">Does EDS support multi-users?</span></span>
 * <span data-ttu-id="56d3e-160">答えはノーです。</span><span class="sxs-lookup"><span data-stu-id="56d3e-160">The answer is no.</span></span> <span data-ttu-id="56d3e-161">記載されている場合は、コンソールは 1 人のユーザー トークンを常に送信されます。</span><span class="sxs-lookup"><span data-stu-id="56d3e-161">In the case that was described, the console will always send single user tokens.</span></span> <span data-ttu-id="56d3e-162">複数のユーザーがサインインがある場合でも、指定された「、呼び出し元」その他のすべての id が削除されますが必要があります。</span><span class="sxs-lookup"><span data-stu-id="56d3e-162">Even if there are multiple users signed in, there must be an indicated "Caller", where all other identities are dropped.</span></span>
  
<a id="ID4E6C"></a>

 
## <a name="see-also"></a><span data-ttu-id="56d3e-163">関連項目</span><span class="sxs-lookup"><span data-stu-id="56d3e-163">See also</span></span>
 
<a id="ID4EBD"></a>

 
##### <a name="parent"></a><span data-ttu-id="56d3e-164">Parent</span><span class="sxs-lookup"><span data-stu-id="56d3e-164">Parent</span></span>  

[<span data-ttu-id="56d3e-165">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="56d3e-165">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4END"></a>

 
##### <a name="further-information"></a><span data-ttu-id="56d3e-166">詳細情報</span><span class="sxs-lookup"><span data-stu-id="56d3e-166">Further Information</span></span> 

[<span data-ttu-id="56d3e-167">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="56d3e-167">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   