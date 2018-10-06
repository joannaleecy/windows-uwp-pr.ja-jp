---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting/count
assetID: 535c8d46-7001-c31e-3e9d-82ad275095ae
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingcount.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting/count"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2d563fde1f5c7aa430547e16771fa920786cd739
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4392949"
---
# <a name="usersxuidxuidgroupsmonikerbroadcastingcount"></a><span data-ttu-id="6d550-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span><span class="sxs-lookup"><span data-stu-id="6d550-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span></span>
<span data-ttu-id="6d550-105">アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。</span><span class="sxs-lookup"><span data-stu-id="6d550-105">Accesses the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="6d550-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6d550-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6d550-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6d550-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6d550-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6d550-108">URI parameters</span></span>
 
| <span data-ttu-id="6d550-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6d550-109">Parameter</span></span>| <span data-ttu-id="6d550-110">型</span><span class="sxs-lookup"><span data-stu-id="6d550-110">Type</span></span>| <span data-ttu-id="6d550-111">説明</span><span class="sxs-lookup"><span data-stu-id="6d550-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6d550-112">xuid</span><span class="sxs-lookup"><span data-stu-id="6d550-112">xuid</span></span>| <span data-ttu-id="6d550-113">string</span><span class="sxs-lookup"><span data-stu-id="6d550-113">string</span></span>| <span data-ttu-id="6d550-114">Xbox ユーザー ID (XUID)、グループ内の Xuid に関連するユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="6d550-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="6d550-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="6d550-115">moniker</span></span>| <span data-ttu-id="6d550-116">string</span><span class="sxs-lookup"><span data-stu-id="6d550-116">string</span></span>| <span data-ttu-id="6d550-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="6d550-117">String defining the group of users.</span></span> <span data-ttu-id="6d550-118">現時点では受け入れられるだけモニカーでは、'P' の首都を"People"でです。</span><span class="sxs-lookup"><span data-stu-id="6d550-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="6d550-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="6d550-119">Valid methods</span></span>

[<span data-ttu-id="6d550-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span><span class="sxs-lookup"><span data-stu-id="6d550-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span></span>](uri-usersxuidgroupsmonikerbroadcastingcountget.md)

<span data-ttu-id="6d550-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーの数を取得します。</span><span class="sxs-lookup"><span data-stu-id="6d550-121">&nbsp;&nbsp;Retrieves the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="6d550-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="6d550-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6d550-123">Parent</span><span class="sxs-lookup"><span data-stu-id="6d550-123">Parent</span></span> 

[<span data-ttu-id="6d550-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="6d550-124">Presence URIs</span></span>](atoc-reference-presence.md)

   