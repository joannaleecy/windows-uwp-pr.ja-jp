---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting
assetID: cf8319f6-46a2-b263-ea4c-f1ce403b571b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcasting.html
author: KevinAsgari
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a3d2e5c0bcbb0c59eabdffdd148e4b7f013c3f40
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4679292"
---
# <a name="usersxuidxuidgroupsmonikerbroadcasting"></a><span data-ttu-id="ff9b3-104">/users/xuid({xuid})/groups/{moniker}/broadcasting</span><span class="sxs-lookup"><span data-stu-id="ff9b3-104">/users/xuid({xuid})/groups/{moniker}/broadcasting</span></span>
<span data-ttu-id="ff9b3-105">URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンス レコードをアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ff9b3-105">Accesses the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="ff9b3-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ff9b3-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ff9b3-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ff9b3-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ff9b3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ff9b3-108">URI parameters</span></span>
 
| <span data-ttu-id="ff9b3-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ff9b3-109">Parameter</span></span>| <span data-ttu-id="ff9b3-110">型</span><span class="sxs-lookup"><span data-stu-id="ff9b3-110">Type</span></span>| <span data-ttu-id="ff9b3-111">説明</span><span class="sxs-lookup"><span data-stu-id="ff9b3-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ff9b3-112">xuid</span><span class="sxs-lookup"><span data-stu-id="ff9b3-112">xuid</span></span>| <span data-ttu-id="ff9b3-113">string</span><span class="sxs-lookup"><span data-stu-id="ff9b3-113">string</span></span>| <span data-ttu-id="ff9b3-114">Xbox ユーザー ID (XUID)、グループ内の Xuid に関連するユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="ff9b3-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="ff9b3-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="ff9b3-115">moniker</span></span>| <span data-ttu-id="ff9b3-116">string</span><span class="sxs-lookup"><span data-stu-id="ff9b3-116">string</span></span>| <span data-ttu-id="ff9b3-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="ff9b3-117">String defining the group of users.</span></span> <span data-ttu-id="ff9b3-118">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="ff9b3-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ff9b3-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ff9b3-119">Valid methods</span></span>

[<span data-ttu-id="ff9b3-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span><span class="sxs-lookup"><span data-stu-id="ff9b3-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span></span>](uri-usersxuidgroupsmonikerbroadcastingget.md)

<span data-ttu-id="ff9b3-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンス レコードを取得します。</span><span class="sxs-lookup"><span data-stu-id="ff9b3-121">&nbsp;&nbsp;Retrieves the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ff9b3-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="ff9b3-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ff9b3-123">Parent</span><span class="sxs-lookup"><span data-stu-id="ff9b3-123">Parent</span></span> 

[<span data-ttu-id="ff9b3-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="ff9b3-124">Presence URIs</span></span>](atoc-reference-presence.md)

   