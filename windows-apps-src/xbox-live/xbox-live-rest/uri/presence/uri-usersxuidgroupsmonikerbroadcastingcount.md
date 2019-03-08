---
title: /users/xuid({xuid})/groups/{moniker}/broadcasting/count
assetID: 535c8d46-7001-c31e-3e9d-82ad275095ae
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingcount.html
description: " /users/xuid({xuid})/groups/{moniker}/broadcasting/count"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7a39bc9c3302ba26949700774997355a216fe70d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651357"
---
# <a name="usersxuidxuidgroupsmonikerbroadcastingcount"></a><span data-ttu-id="11ff4-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span><span class="sxs-lookup"><span data-stu-id="11ff4-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span></span>
<span data-ttu-id="11ff4-105">アクセス グループ モニカーによって指定されたブロードキャスト ユーザーの数は、URI に表示される XUID に関連します。</span><span class="sxs-lookup"><span data-stu-id="11ff4-105">Accesses the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="11ff4-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="11ff4-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="11ff4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="11ff4-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="11ff4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="11ff4-108">URI parameters</span></span>
 
| <span data-ttu-id="11ff4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="11ff4-109">Parameter</span></span>| <span data-ttu-id="11ff4-110">種類</span><span class="sxs-lookup"><span data-stu-id="11ff4-110">Type</span></span>| <span data-ttu-id="11ff4-111">説明</span><span class="sxs-lookup"><span data-stu-id="11ff4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="11ff4-112">xuid</span><span class="sxs-lookup"><span data-stu-id="11ff4-112">xuid</span></span>| <span data-ttu-id="11ff4-113">string</span><span class="sxs-lookup"><span data-stu-id="11ff4-113">string</span></span>| <span data-ttu-id="11ff4-114">Xbox ユーザー ID (XUID) のグループで Xuid に関連するユーザーです。</span><span class="sxs-lookup"><span data-stu-id="11ff4-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="11ff4-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="11ff4-115">moniker</span></span>| <span data-ttu-id="11ff4-116">string</span><span class="sxs-lookup"><span data-stu-id="11ff4-116">string</span></span>| <span data-ttu-id="11ff4-117">ユーザーのグループを定義する文字列。</span><span class="sxs-lookup"><span data-stu-id="11ff4-117">String defining the group of users.</span></span> <span data-ttu-id="11ff4-118">現時点ではのみ受け入れられたモニカーでは、"People"が大文字の 'P' です。</span><span class="sxs-lookup"><span data-stu-id="11ff4-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="11ff4-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="11ff4-119">Valid methods</span></span>

[<span data-ttu-id="11ff4-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span><span class="sxs-lookup"><span data-stu-id="11ff4-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span></span>](uri-usersxuidgroupsmonikerbroadcastingcountget.md)

<span data-ttu-id="11ff4-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーによって指定されたブロードキャスト ユーザーの数を取得します。</span><span class="sxs-lookup"><span data-stu-id="11ff4-121">&nbsp;&nbsp;Retrieves the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="11ff4-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="11ff4-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="11ff4-123">Parent</span><span class="sxs-lookup"><span data-stu-id="11ff4-123">Parent</span></span> 

[<span data-ttu-id="11ff4-124">プレゼンスの Uri</span><span class="sxs-lookup"><span data-stu-id="11ff4-124">Presence URIs</span></span>](atoc-reference-presence.md)

   