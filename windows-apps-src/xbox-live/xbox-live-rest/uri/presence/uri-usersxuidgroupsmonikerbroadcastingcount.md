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
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5820178"
---
# <a name="usersxuidxuidgroupsmonikerbroadcastingcount"></a><span data-ttu-id="2cb3f-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span><span class="sxs-lookup"><span data-stu-id="2cb3f-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span></span>
<span data-ttu-id="2cb3f-105">アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。</span><span class="sxs-lookup"><span data-stu-id="2cb3f-105">Accesses the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="2cb3f-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2cb3f-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2cb3f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cb3f-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2cb3f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cb3f-108">URI parameters</span></span>
 
| <span data-ttu-id="2cb3f-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cb3f-109">Parameter</span></span>| <span data-ttu-id="2cb3f-110">型</span><span class="sxs-lookup"><span data-stu-id="2cb3f-110">Type</span></span>| <span data-ttu-id="2cb3f-111">説明</span><span class="sxs-lookup"><span data-stu-id="2cb3f-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2cb3f-112">xuid</span><span class="sxs-lookup"><span data-stu-id="2cb3f-112">xuid</span></span>| <span data-ttu-id="2cb3f-113">string</span><span class="sxs-lookup"><span data-stu-id="2cb3f-113">string</span></span>| <span data-ttu-id="2cb3f-114">Xbox ユーザー ID (XUID)、グループ内の Xuid に関連するユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="2cb3f-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="2cb3f-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="2cb3f-115">moniker</span></span>| <span data-ttu-id="2cb3f-116">string</span><span class="sxs-lookup"><span data-stu-id="2cb3f-116">string</span></span>| <span data-ttu-id="2cb3f-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="2cb3f-117">String defining the group of users.</span></span> <span data-ttu-id="2cb3f-118">現時点では受け入れられるモニカーだけでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="2cb3f-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="2cb3f-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="2cb3f-119">Valid methods</span></span>

[<span data-ttu-id="2cb3f-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span><span class="sxs-lookup"><span data-stu-id="2cb3f-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span></span>](uri-usersxuidgroupsmonikerbroadcastingcountget.md)

<span data-ttu-id="2cb3f-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーの数を取得します。</span><span class="sxs-lookup"><span data-stu-id="2cb3f-121">&nbsp;&nbsp;Retrieves the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="2cb3f-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="2cb3f-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2cb3f-123">Parent</span><span class="sxs-lookup"><span data-stu-id="2cb3f-123">Parent</span></span> 

[<span data-ttu-id="2cb3f-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="2cb3f-124">Presence URIs</span></span>](atoc-reference-presence.md)

   