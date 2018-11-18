---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting/count
assetID: 535c8d46-7001-c31e-3e9d-82ad275095ae
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingcount.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting/count"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dbfe207483f5814d2cd32ffcd5ac651c0ab5aa52
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7152174"
---
# <a name="usersxuidxuidgroupsmonikerbroadcastingcount"></a><span data-ttu-id="4ad04-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span><span class="sxs-lookup"><span data-stu-id="4ad04-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span></span>
<span data-ttu-id="4ad04-105">アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI 内に表示される XUID に関連します。</span><span class="sxs-lookup"><span data-stu-id="4ad04-105">Accesses the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="4ad04-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4ad04-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4ad04-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4ad04-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4ad04-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4ad04-108">URI parameters</span></span>
 
| <span data-ttu-id="4ad04-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4ad04-109">Parameter</span></span>| <span data-ttu-id="4ad04-110">型</span><span class="sxs-lookup"><span data-stu-id="4ad04-110">Type</span></span>| <span data-ttu-id="4ad04-111">説明</span><span class="sxs-lookup"><span data-stu-id="4ad04-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4ad04-112">xuid</span><span class="sxs-lookup"><span data-stu-id="4ad04-112">xuid</span></span>| <span data-ttu-id="4ad04-113">string</span><span class="sxs-lookup"><span data-stu-id="4ad04-113">string</span></span>| <span data-ttu-id="4ad04-114">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連します。</span><span class="sxs-lookup"><span data-stu-id="4ad04-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="4ad04-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="4ad04-115">moniker</span></span>| <span data-ttu-id="4ad04-116">string</span><span class="sxs-lookup"><span data-stu-id="4ad04-116">string</span></span>| <span data-ttu-id="4ad04-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="4ad04-117">String defining the group of users.</span></span> <span data-ttu-id="4ad04-118">現時点でのみ受け入れたモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="4ad04-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="4ad04-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="4ad04-119">Valid methods</span></span>

[<span data-ttu-id="4ad04-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span><span class="sxs-lookup"><span data-stu-id="4ad04-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span></span>](uri-usersxuidgroupsmonikerbroadcastingcountget.md)

<span data-ttu-id="4ad04-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーの数を取得します。</span><span class="sxs-lookup"><span data-stu-id="4ad04-121">&nbsp;&nbsp;Retrieves the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="4ad04-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="4ad04-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4ad04-123">Parent</span><span class="sxs-lookup"><span data-stu-id="4ad04-123">Parent</span></span> 

[<span data-ttu-id="4ad04-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="4ad04-124">Presence URIs</span></span>](atoc-reference-presence.md)

   