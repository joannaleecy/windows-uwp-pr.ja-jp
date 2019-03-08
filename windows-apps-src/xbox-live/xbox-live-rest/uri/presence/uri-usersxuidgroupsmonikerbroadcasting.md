---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting
assetID: cf8319f6-46a2-b263-ea4c-f1ce403b571b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcasting.html
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 98eaa60204e3c98eb1b09a13372f7b0c084a6608
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651467"
---
# <a name="usersxuidxuidgroupsmonikerbroadcasting"></a><span data-ttu-id="a037f-104">/users/xuid({xuid})/groups/{moniker}/broadcasting</span><span class="sxs-lookup"><span data-stu-id="a037f-104">/users/xuid({xuid})/groups/{moniker}/broadcasting</span></span>
<span data-ttu-id="a037f-105">アクセス グループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンスのレコードに関連する XUID URI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="a037f-105">Accesses the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="a037f-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a037f-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a037f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a037f-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a037f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a037f-108">URI parameters</span></span>
 
| <span data-ttu-id="a037f-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a037f-109">Parameter</span></span>| <span data-ttu-id="a037f-110">種類</span><span class="sxs-lookup"><span data-stu-id="a037f-110">Type</span></span>| <span data-ttu-id="a037f-111">説明</span><span class="sxs-lookup"><span data-stu-id="a037f-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a037f-112">xuid</span><span class="sxs-lookup"><span data-stu-id="a037f-112">xuid</span></span>| <span data-ttu-id="a037f-113">string</span><span class="sxs-lookup"><span data-stu-id="a037f-113">string</span></span>| <span data-ttu-id="a037f-114">Xbox ユーザー ID (XUID) のグループで Xuid に関連するユーザーです。</span><span class="sxs-lookup"><span data-stu-id="a037f-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="a037f-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="a037f-115">moniker</span></span>| <span data-ttu-id="a037f-116">string</span><span class="sxs-lookup"><span data-stu-id="a037f-116">string</span></span>| <span data-ttu-id="a037f-117">ユーザーのグループを定義する文字列。</span><span class="sxs-lookup"><span data-stu-id="a037f-117">String defining the group of users.</span></span> <span data-ttu-id="a037f-118">現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。</span><span class="sxs-lookup"><span data-stu-id="a037f-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a037f-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a037f-119">Valid methods</span></span>

[<span data-ttu-id="a037f-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span><span class="sxs-lookup"><span data-stu-id="a037f-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting )</span></span>](uri-usersxuidgroupsmonikerbroadcastingget.md)

<span data-ttu-id="a037f-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーのプレゼンスのレコードを取得します。</span><span class="sxs-lookup"><span data-stu-id="a037f-121">&nbsp;&nbsp;Retrieves the presence record of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="a037f-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="a037f-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a037f-123">Parent</span><span class="sxs-lookup"><span data-stu-id="a037f-123">Parent</span></span> 

[<span data-ttu-id="a037f-124">プレゼンスの Uri</span><span class="sxs-lookup"><span data-stu-id="a037f-124">Presence URIs</span></span>](atoc-reference-presence.md)

   