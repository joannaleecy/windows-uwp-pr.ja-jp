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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8342470"
---
# <a name="profile-json"></a><span data-ttu-id="e60e1-104">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="e60e1-104">Profile (JSON)</span></span>
<span data-ttu-id="e60e1-105">ユーザーの個人用プロファイル設定します。</span><span class="sxs-lookup"><span data-stu-id="e60e1-105">The personal profile settings for a user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="profile"></a><span data-ttu-id="e60e1-106">プロファイル</span><span class="sxs-lookup"><span data-stu-id="e60e1-106">Profile</span></span>
 
<span data-ttu-id="e60e1-107">プロファイル オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="e60e1-107">The Profile object has the following specification.</span></span>
 
| <span data-ttu-id="e60e1-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="e60e1-108">Member</span></span>| <span data-ttu-id="e60e1-109">種類</span><span class="sxs-lookup"><span data-stu-id="e60e1-109">Type</span></span>| <span data-ttu-id="e60e1-110">説明</span><span class="sxs-lookup"><span data-stu-id="e60e1-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e60e1-111">AppDisplayName</span><span class="sxs-lookup"><span data-stu-id="e60e1-111">AppDisplayName</span></span>| <span data-ttu-id="e60e1-112">string</span><span class="sxs-lookup"><span data-stu-id="e60e1-112">string</span></span>| <span data-ttu-id="e60e1-113">アプリで表示するための名前です。</span><span class="sxs-lookup"><span data-stu-id="e60e1-113">Name for displaying in apps.</span></span> <span data-ttu-id="e60e1-114">これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e60e1-114">This could be the user's "real name" or their gamertag, depending on privacy.</span></span> <span data-ttu-id="e60e1-115">この設定は、アプリに表示するために使用するユーザーの id 文字列を表します。</span><span class="sxs-lookup"><span data-stu-id="e60e1-115">This setting represents the user's identity string that should be used for display in apps.</span></span>| 
| <span data-ttu-id="e60e1-116">GameDisplayName</span><span class="sxs-lookup"><span data-stu-id="e60e1-116">GameDisplayName</span></span>| <span data-ttu-id="e60e1-117">string</span><span class="sxs-lookup"><span data-stu-id="e60e1-117">string</span></span>| <span data-ttu-id="e60e1-118">ゲームで表示するための名前です。</span><span class="sxs-lookup"><span data-stu-id="e60e1-118">Name for displaying in games.</span></span> <span data-ttu-id="e60e1-119">これにより、ユーザーの「実際の名前」またはプライバシーに応じて、そのユーザーのゲーマータグ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e60e1-119">This could be the user's "real name" or their gamertag, depending on privacy.</span></span> <span data-ttu-id="e60e1-120">この設定は、ゲームで表示するために使用するユーザーの id 文字列を表します。</span><span class="sxs-lookup"><span data-stu-id="e60e1-120">This setting represents the user's identity string that should be used for display in games.</span></span>| 
| <span data-ttu-id="e60e1-121">Gamertag</span><span class="sxs-lookup"><span data-stu-id="e60e1-121">Gamertag</span></span>| <span data-ttu-id="e60e1-122">string</span><span class="sxs-lookup"><span data-stu-id="e60e1-122">string</span></span>| <span data-ttu-id="e60e1-123">ユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="e60e1-123">The user's gamertag.</span></span>| 
| <span data-ttu-id="e60e1-124">AppDisplayPicRaw</span><span class="sxs-lookup"><span data-stu-id="e60e1-124">AppDisplayPicRaw</span></span>| <span data-ttu-id="e60e1-125">string</span><span class="sxs-lookup"><span data-stu-id="e60e1-125">string</span></span>| <span data-ttu-id="e60e1-126">アプリを直接表示 pic URL (下記参照)。</span><span class="sxs-lookup"><span data-stu-id="e60e1-126">Raw app display pic URL (see below).</span></span>| 
| <span data-ttu-id="e60e1-127">GameDisplayPicRaw</span><span class="sxs-lookup"><span data-stu-id="e60e1-127">GameDisplayPicRaw</span></span>| <span data-ttu-id="e60e1-128">string</span><span class="sxs-lookup"><span data-stu-id="e60e1-128">string</span></span>| <span data-ttu-id="e60e1-129">未加工のゲーム表示 pic URL (下記参照)。</span><span class="sxs-lookup"><span data-stu-id="e60e1-129">Raw game display pic URL (see below).</span></span>| 
| <span data-ttu-id="e60e1-130">AccountTier</span><span class="sxs-lookup"><span data-stu-id="e60e1-130">AccountTier</span></span>| <span data-ttu-id="e60e1-131">string</span><span class="sxs-lookup"><span data-stu-id="e60e1-131">string</span></span>| <span data-ttu-id="e60e1-132">ユーザーには、アカウントの種類はありますか。</span><span class="sxs-lookup"><span data-stu-id="e60e1-132">What type of account does the user have?</span></span> <span data-ttu-id="e60e1-133">ゴールド、シルバー、または FamilyGold かどうか。</span><span class="sxs-lookup"><span data-stu-id="e60e1-133">Gold, Silver, or FamilyGold?</span></span>| 
| <span data-ttu-id="e60e1-134">TenureLevel</span><span class="sxs-lookup"><span data-stu-id="e60e1-134">TenureLevel</span></span>| <span data-ttu-id="e60e1-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e60e1-135">32-bit unsigned integer</span></span>| <span data-ttu-id="e60e1-136">数年間ユーザーされた Xbox Live を使用しますか。</span><span class="sxs-lookup"><span data-stu-id="e60e1-136">How many years has the user been with Xbox Live?</span></span>| 
| <span data-ttu-id="e60e1-137">ゲーマースコア</span><span class="sxs-lookup"><span data-stu-id="e60e1-137">Gamerscore</span></span>| <span data-ttu-id="e60e1-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e60e1-138">32-bit unsigned integer</span></span>| <span data-ttu-id="e60e1-139">ユーザーのゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="e60e1-139">Gamerscore of the user.</span></span>| 
  


> [!NOTE] 
> <span data-ttu-id="e60e1-140">画像は、ユーザーの '実際の図' またはプライバシーに応じて、XboxOne ゲーマー アイコンであることができます。</span><span class="sxs-lookup"><span data-stu-id="e60e1-140">Pictures can be the user's 'real picture' or their XboxOne gamerpic, depending on privacy.</span></span> <span data-ttu-id="e60e1-141">これらの設定は、クライアント上に表示するために使用するユーザーの画像の url を表します。</span><span class="sxs-lookup"><span data-stu-id="e60e1-141">These settings represent the user's picture url that should be used for display on the client.</span></span> <span data-ttu-id="e60e1-142">この画像は、(ユーザーが任意の画像を設定していないことを示す) が空にする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e60e1-142">This image may be empty (indicating that the user hasn't set any picture).</span></span> 


 
<span data-ttu-id="e60e1-143">生の URL は、サイズ変更できる URL です。</span><span class="sxs-lookup"><span data-stu-id="e60e1-143">The Raw URL is a resizable URL.</span></span> <span data-ttu-id="e60e1-144">サイズし、形式を追加して、次のいずれかを指定するために使用できる`&format={format}&w={width}&h={height}`をその URI:</span><span class="sxs-lookup"><span data-stu-id="e60e1-144">It can be used to specify one of the following sizes and formats using by appending `&format={format}&w={width}&h={height}` to the URI:</span></span>
 
<span data-ttu-id="e60e1-145">形式: png</span><span class="sxs-lookup"><span data-stu-id="e60e1-145">Format: png</span></span>
 
<span data-ttu-id="e60e1-146">サイズ: 64 x 64、208 x 208、424 x 424</span><span class="sxs-lookup"><span data-stu-id="e60e1-146">Sizes: 64x64, 208x208, 424x424</span></span>
 
<a id="ID4E2D"></a>

 
## <a name="see-also"></a><span data-ttu-id="e60e1-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="e60e1-147">See also</span></span>
 
<a id="ID4E4D"></a>

 
##### <a name="parent"></a><span data-ttu-id="e60e1-148">Parent</span><span class="sxs-lookup"><span data-stu-id="e60e1-148">Parent</span></span> 

[<span data-ttu-id="e60e1-149">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="e60e1-149">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   