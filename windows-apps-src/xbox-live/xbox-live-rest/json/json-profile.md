---
title: Profile (JSON)
assetID: b92b1750-c2df-39b6-6c5c-f9e8068c8097
permalink: en-us/docs/xboxlive/rest/json-profile.html
description: " Profile (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7299fcb4d375a3fc35ad67306b70f5fa4afde963
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607517"
---
# <a name="profile-json"></a><span data-ttu-id="d5d11-104">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="d5d11-104">Profile (JSON)</span></span>
<span data-ttu-id="d5d11-105">ユーザーの個人プロファイルの設定。</span><span class="sxs-lookup"><span data-stu-id="d5d11-105">The personal profile settings for a user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="profile"></a><span data-ttu-id="d5d11-106">Profile</span><span class="sxs-lookup"><span data-stu-id="d5d11-106">Profile</span></span>
 
<span data-ttu-id="d5d11-107">プロファイル オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d5d11-107">The Profile object has the following specification.</span></span>
 
| <span data-ttu-id="d5d11-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="d5d11-108">Member</span></span>| <span data-ttu-id="d5d11-109">種類</span><span class="sxs-lookup"><span data-stu-id="d5d11-109">Type</span></span>| <span data-ttu-id="d5d11-110">説明</span><span class="sxs-lookup"><span data-stu-id="d5d11-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d5d11-111">AppDisplayName</span><span class="sxs-lookup"><span data-stu-id="d5d11-111">AppDisplayName</span></span>| <span data-ttu-id="d5d11-112">string</span><span class="sxs-lookup"><span data-stu-id="d5d11-112">string</span></span>| <span data-ttu-id="d5d11-113">アプリで表示するための名前。</span><span class="sxs-lookup"><span data-stu-id="d5d11-113">Name for displaying in apps.</span></span> <span data-ttu-id="d5d11-114">ユーザーの「実際の名前」またはプライバシーによってそのゲーマータグことが考えられます。</span><span class="sxs-lookup"><span data-stu-id="d5d11-114">This could be the user's "real name" or their gamertag, depending on privacy.</span></span> <span data-ttu-id="d5d11-115">この設定は、アプリでの表示に使用するユーザーの id 文字列を表します。</span><span class="sxs-lookup"><span data-stu-id="d5d11-115">This setting represents the user's identity string that should be used for display in apps.</span></span>| 
| <span data-ttu-id="d5d11-116">GameDisplayName</span><span class="sxs-lookup"><span data-stu-id="d5d11-116">GameDisplayName</span></span>| <span data-ttu-id="d5d11-117">string</span><span class="sxs-lookup"><span data-stu-id="d5d11-117">string</span></span>| <span data-ttu-id="d5d11-118">ゲームで表示するための名前。</span><span class="sxs-lookup"><span data-stu-id="d5d11-118">Name for displaying in games.</span></span> <span data-ttu-id="d5d11-119">ユーザーの「実際の名前」またはプライバシーによってそのゲーマータグことが考えられます。</span><span class="sxs-lookup"><span data-stu-id="d5d11-119">This could be the user's "real name" or their gamertag, depending on privacy.</span></span> <span data-ttu-id="d5d11-120">この設定は、ゲームでの表示に使用するユーザーの id 文字列を表します。</span><span class="sxs-lookup"><span data-stu-id="d5d11-120">This setting represents the user's identity string that should be used for display in games.</span></span>| 
| <span data-ttu-id="d5d11-121">Gamertag</span><span class="sxs-lookup"><span data-stu-id="d5d11-121">Gamertag</span></span>| <span data-ttu-id="d5d11-122">string</span><span class="sxs-lookup"><span data-stu-id="d5d11-122">string</span></span>| <span data-ttu-id="d5d11-123">ユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="d5d11-123">The user's gamertag.</span></span>| 
| <span data-ttu-id="d5d11-124">AppDisplayPicRaw</span><span class="sxs-lookup"><span data-stu-id="d5d11-124">AppDisplayPicRaw</span></span>| <span data-ttu-id="d5d11-125">string</span><span class="sxs-lookup"><span data-stu-id="d5d11-125">string</span></span>| <span data-ttu-id="d5d11-126">未加工のアプリ表示 pic URL (下記参照)。</span><span class="sxs-lookup"><span data-stu-id="d5d11-126">Raw app display pic URL (see below).</span></span>| 
| <span data-ttu-id="d5d11-127">GameDisplayPicRaw</span><span class="sxs-lookup"><span data-stu-id="d5d11-127">GameDisplayPicRaw</span></span>| <span data-ttu-id="d5d11-128">string</span><span class="sxs-lookup"><span data-stu-id="d5d11-128">string</span></span>| <span data-ttu-id="d5d11-129">未処理のゲーム表示 pic URL (下記参照)。</span><span class="sxs-lookup"><span data-stu-id="d5d11-129">Raw game display pic URL (see below).</span></span>| 
| <span data-ttu-id="d5d11-130">AccountTier</span><span class="sxs-lookup"><span data-stu-id="d5d11-130">AccountTier</span></span>| <span data-ttu-id="d5d11-131">string</span><span class="sxs-lookup"><span data-stu-id="d5d11-131">string</span></span>| <span data-ttu-id="d5d11-132">ユーザーには、アカウントの種類はありますか。</span><span class="sxs-lookup"><span data-stu-id="d5d11-132">What type of account does the user have?</span></span> <span data-ttu-id="d5d11-133">Gold、Silver、または FamilyGold でしょうか。</span><span class="sxs-lookup"><span data-stu-id="d5d11-133">Gold, Silver, or FamilyGold?</span></span>| 
| <span data-ttu-id="d5d11-134">TenureLevel</span><span class="sxs-lookup"><span data-stu-id="d5d11-134">TenureLevel</span></span>| <span data-ttu-id="d5d11-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d5d11-135">32-bit unsigned integer</span></span>| <span data-ttu-id="d5d11-136">数年の Xbox Live、ユーザーがでしたか。</span><span class="sxs-lookup"><span data-stu-id="d5d11-136">How many years has the user been with Xbox Live?</span></span>| 
| <span data-ttu-id="d5d11-137">ゲーマースコア</span><span class="sxs-lookup"><span data-stu-id="d5d11-137">Gamerscore</span></span>| <span data-ttu-id="d5d11-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d5d11-138">32-bit unsigned integer</span></span>| <span data-ttu-id="d5d11-139">ユーザーのゲーマーします。</span><span class="sxs-lookup"><span data-stu-id="d5d11-139">Gamerscore of the user.</span></span>| 
  


> [!NOTE] 
> <span data-ttu-id="d5d11-140">画像には、ユーザーの '実際の画像' またはプライバシーによってその XboxOne gamerpic を指定できます。</span><span class="sxs-lookup"><span data-stu-id="d5d11-140">Pictures can be the user's 'real picture' or their XboxOne gamerpic, depending on privacy.</span></span> <span data-ttu-id="d5d11-141">これらの設定は、クライアントの表示に使用するユーザーの画像の url を表します。</span><span class="sxs-lookup"><span data-stu-id="d5d11-141">These settings represent the user's picture url that should be used for display on the client.</span></span> <span data-ttu-id="d5d11-142">このイメージは、(ユーザーが任意の画像を設定していないことを示す) が空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="d5d11-142">This image may be empty (indicating that the user hasn't set any picture).</span></span> 


 
<span data-ttu-id="d5d11-143">生の URL は、サイズ変更可能な URL です。</span><span class="sxs-lookup"><span data-stu-id="d5d11-143">The Raw URL is a resizable URL.</span></span> <span data-ttu-id="d5d11-144">サイズし、形式を使用して追加することで、次のいずれかを指定するために使用できる`&format={format}&w={width}&h={height}`uri:</span><span class="sxs-lookup"><span data-stu-id="d5d11-144">It can be used to specify one of the following sizes and formats using by appending `&format={format}&w={width}&h={height}` to the URI:</span></span>
 
<span data-ttu-id="d5d11-145">形式: png</span><span class="sxs-lookup"><span data-stu-id="d5d11-145">Format: png</span></span>
 
<span data-ttu-id="d5d11-146">サイズ:64 x 64、208 x 208、424 x 424</span><span class="sxs-lookup"><span data-stu-id="d5d11-146">Sizes: 64x64, 208x208, 424x424</span></span>
 
<a id="ID4E2D"></a>

 
## <a name="see-also"></a><span data-ttu-id="d5d11-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="d5d11-147">See also</span></span>
 
<a id="ID4E4D"></a>

 
##### <a name="parent"></a><span data-ttu-id="d5d11-148">Parent</span><span class="sxs-lookup"><span data-stu-id="d5d11-148">Parent</span></span> 

[<span data-ttu-id="d5d11-149">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="d5d11-149">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   