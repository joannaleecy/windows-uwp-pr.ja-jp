---
title: Profile (JSON)
assetID: b92b1750-c2df-39b6-6c5c-f9e8068c8097
permalink: en-us/docs/xboxlive/rest/json-profile.html
author: KevinAsgari
description: " Profile (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0ae5e95befc6611c5905e6efe2bb01a396167626
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4147676"
---
# <a name="profile-json"></a><span data-ttu-id="457d1-104">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="457d1-104">Profile (JSON)</span></span>
<span data-ttu-id="457d1-105">ユーザーの個人用プロファイル設定します。</span><span class="sxs-lookup"><span data-stu-id="457d1-105">The personal profile settings for a user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="profile"></a><span data-ttu-id="457d1-106">プロファイル</span><span class="sxs-lookup"><span data-stu-id="457d1-106">Profile</span></span>
 
<span data-ttu-id="457d1-107">プロファイル オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="457d1-107">The Profile object has the following specification.</span></span>
 
| <span data-ttu-id="457d1-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="457d1-108">Member</span></span>| <span data-ttu-id="457d1-109">種類</span><span class="sxs-lookup"><span data-stu-id="457d1-109">Type</span></span>| <span data-ttu-id="457d1-110">説明</span><span class="sxs-lookup"><span data-stu-id="457d1-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="457d1-111">AppDisplayName</span><span class="sxs-lookup"><span data-stu-id="457d1-111">AppDisplayName</span></span>| <span data-ttu-id="457d1-112">string</span><span class="sxs-lookup"><span data-stu-id="457d1-112">string</span></span>| <span data-ttu-id="457d1-113">アプリで表示するための名前です。</span><span class="sxs-lookup"><span data-stu-id="457d1-113">Name for displaying in apps.</span></span> <span data-ttu-id="457d1-114">これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="457d1-114">This could be the user's "real name" or their gamertag, depending on privacy.</span></span> <span data-ttu-id="457d1-115">この設定は、アプリに表示するために使用するユーザーの id 文字列を表します。</span><span class="sxs-lookup"><span data-stu-id="457d1-115">This setting represents the user's identity string that should be used for display in apps.</span></span>| 
| <span data-ttu-id="457d1-116">GameDisplayName</span><span class="sxs-lookup"><span data-stu-id="457d1-116">GameDisplayName</span></span>| <span data-ttu-id="457d1-117">string</span><span class="sxs-lookup"><span data-stu-id="457d1-117">string</span></span>| <span data-ttu-id="457d1-118">ゲームで表示するための名前です。</span><span class="sxs-lookup"><span data-stu-id="457d1-118">Name for displaying in games.</span></span> <span data-ttu-id="457d1-119">これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="457d1-119">This could be the user's "real name" or their gamertag, depending on privacy.</span></span> <span data-ttu-id="457d1-120">この設定は、ゲームで表示するために使用するユーザーの id 文字列を表します。</span><span class="sxs-lookup"><span data-stu-id="457d1-120">This setting represents the user's identity string that should be used for display in games.</span></span>| 
| <span data-ttu-id="457d1-121">Gamertag</span><span class="sxs-lookup"><span data-stu-id="457d1-121">Gamertag</span></span>| <span data-ttu-id="457d1-122">string</span><span class="sxs-lookup"><span data-stu-id="457d1-122">string</span></span>| <span data-ttu-id="457d1-123">ユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="457d1-123">The user's gamertag.</span></span>| 
| <span data-ttu-id="457d1-124">AppDisplayPicRaw</span><span class="sxs-lookup"><span data-stu-id="457d1-124">AppDisplayPicRaw</span></span>| <span data-ttu-id="457d1-125">string</span><span class="sxs-lookup"><span data-stu-id="457d1-125">string</span></span>| <span data-ttu-id="457d1-126">アプリを直接表示 pic URL (下記参照)。</span><span class="sxs-lookup"><span data-stu-id="457d1-126">Raw app display pic URL (see below).</span></span>| 
| <span data-ttu-id="457d1-127">GameDisplayPicRaw</span><span class="sxs-lookup"><span data-stu-id="457d1-127">GameDisplayPicRaw</span></span>| <span data-ttu-id="457d1-128">string</span><span class="sxs-lookup"><span data-stu-id="457d1-128">string</span></span>| <span data-ttu-id="457d1-129">未加工のゲーム表示 pic URL (下記参照)。</span><span class="sxs-lookup"><span data-stu-id="457d1-129">Raw game display pic URL (see below).</span></span>| 
| <span data-ttu-id="457d1-130">AccountTier</span><span class="sxs-lookup"><span data-stu-id="457d1-130">AccountTier</span></span>| <span data-ttu-id="457d1-131">string</span><span class="sxs-lookup"><span data-stu-id="457d1-131">string</span></span>| <span data-ttu-id="457d1-132">ユーザーには、アカウントの種類はありますか。</span><span class="sxs-lookup"><span data-stu-id="457d1-132">What type of account does the user have?</span></span> <span data-ttu-id="457d1-133">ゴールド、シルバー、または FamilyGold かどうか。</span><span class="sxs-lookup"><span data-stu-id="457d1-133">Gold, Silver, or FamilyGold?</span></span>| 
| <span data-ttu-id="457d1-134">TenureLevel</span><span class="sxs-lookup"><span data-stu-id="457d1-134">TenureLevel</span></span>| <span data-ttu-id="457d1-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="457d1-135">32-bit unsigned integer</span></span>| <span data-ttu-id="457d1-136">数年間ユーザーされた Xbox Live を使用しますか。</span><span class="sxs-lookup"><span data-stu-id="457d1-136">How many years has the user been with Xbox Live?</span></span>| 
| <span data-ttu-id="457d1-137">ゲーマースコア</span><span class="sxs-lookup"><span data-stu-id="457d1-137">Gamerscore</span></span>| <span data-ttu-id="457d1-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="457d1-138">32-bit unsigned integer</span></span>| <span data-ttu-id="457d1-139">ユーザーのゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="457d1-139">Gamerscore of the user.</span></span>| 
  


> [!NOTE] 
> <span data-ttu-id="457d1-140">画像は、ユーザーの '実際の画像' またはプライバシーに応じて、XboxOne ゲーマー アイコンを指定できます。</span><span class="sxs-lookup"><span data-stu-id="457d1-140">Pictures can be the user's 'real picture' or their XboxOne gamerpic, depending on privacy.</span></span> <span data-ttu-id="457d1-141">これらの設定は、クライアント上に表示するために使用するユーザーの画像の url を表します。</span><span class="sxs-lookup"><span data-stu-id="457d1-141">These settings represent the user's picture url that should be used for display on the client.</span></span> <span data-ttu-id="457d1-142">この画像は、(ユーザーが任意の画像を設定していないことを示す) が空にする場合があります。</span><span class="sxs-lookup"><span data-stu-id="457d1-142">This image may be empty (indicating that the user hasn't set any picture).</span></span> 


 
<span data-ttu-id="457d1-143">生の URL は、サイズ変更できる URL です。</span><span class="sxs-lookup"><span data-stu-id="457d1-143">The Raw URL is a resizable URL.</span></span> <span data-ttu-id="457d1-144">サイズし、形式を追加して、次のいずれかを指定するために使用できる`&format={format}&w={width}&h={height}`をその URI:</span><span class="sxs-lookup"><span data-stu-id="457d1-144">It can be used to specify one of the following sizes and formats using by appending `&format={format}&w={width}&h={height}` to the URI:</span></span>
 
<span data-ttu-id="457d1-145">形式: png</span><span class="sxs-lookup"><span data-stu-id="457d1-145">Format: png</span></span>
 
<span data-ttu-id="457d1-146">サイズ: 64 x 64、208 x 208、424 x 424</span><span class="sxs-lookup"><span data-stu-id="457d1-146">Sizes: 64x64, 208x208, 424x424</span></span>
 
<a id="ID4E2D"></a>

 
## <a name="see-also"></a><span data-ttu-id="457d1-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="457d1-147">See also</span></span>
 
<a id="ID4E4D"></a>

 
##### <a name="parent"></a><span data-ttu-id="457d1-148">Parent</span><span class="sxs-lookup"><span data-stu-id="457d1-148">Parent</span></span> 

[<span data-ttu-id="457d1-149">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="457d1-149">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   