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
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5395423"
---
# <a name="usersxuidxuidgroupsmonikerbroadcasting"></a><span data-ttu-id="1632c-104">/users/xuid({xuid})/groups/{moniker}/broadcasting</span><span class="sxs-lookup"><span data-stu-id="1632c-104">/users/xuid({xuid})/groups/{moniker}/broadcasting</span></span>
<span data-ttu-id="1632c-105">URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンス レコードをアクセスします。</span><span class="sxs-lookup"><span data-stu-id="1632c-105">Accesses the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="1632c-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="1632c-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="1632c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1632c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="1632c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1632c-108">URI parameters</span></span>
 
| <span data-ttu-id="1632c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1632c-109">Parameter</span></span>| <span data-ttu-id="1632c-110">型</span><span class="sxs-lookup"><span data-stu-id="1632c-110">Type</span></span>| <span data-ttu-id="1632c-111">説明</span><span class="sxs-lookup"><span data-stu-id="1632c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="1632c-112">xuid</span><span class="sxs-lookup"><span data-stu-id="1632c-112">xuid</span></span>| <span data-ttu-id="1632c-113">string</span><span class="sxs-lookup"><span data-stu-id="1632c-113">string</span></span>| <span data-ttu-id="1632c-114">Xbox ユーザー ID (XUID)、グループ内の Xuid に関連するユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="1632c-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="1632c-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="1632c-115">moniker</span></span>| <span data-ttu-id="1632c-116">string</span><span class="sxs-lookup"><span data-stu-id="1632c-116">string</span></span>| <span data-ttu-id="1632c-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="1632c-117">String defining the group of users.</span></span> <span data-ttu-id="1632c-118">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="1632c-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="1632c-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="1632c-119">Valid methods</span></span>

[<span data-ttu-id="1632c-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span><span class="sxs-lookup"><span data-stu-id="1632c-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span></span>](uri-usersxuidgroupsmonikerbroadcastingget.md)

<span data-ttu-id="1632c-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンス レコードを取得します。</span><span class="sxs-lookup"><span data-stu-id="1632c-121">&nbsp;&nbsp;Retrieves the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="1632c-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="1632c-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="1632c-123">Parent</span><span class="sxs-lookup"><span data-stu-id="1632c-123">Parent</span></span> 

[<span data-ttu-id="1632c-124">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="1632c-124">Presence URIs</span></span>](atoc-reference-presence.md)

   