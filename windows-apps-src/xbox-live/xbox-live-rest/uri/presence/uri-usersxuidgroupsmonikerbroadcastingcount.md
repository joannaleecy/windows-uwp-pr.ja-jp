---
title: ユーザー/xuid ({xuid})/groups/{モニカー} ブロードキャスト/カウント
assetID: 535c8d46-7001-c31e-3e9d-82ad275095ae
permalink: en-us/docs/xboxlive/rest/uri-usersxuidgroupsmonikerbroadcastingcount.html
author: KevinAsgari
description: " ユーザー/xuid ({xuid})/groups/{モニカー} ブロードキャスト/カウント"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2d563fde1f5c7aa430547e16771fa920786cd739
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3933746"
---
# <a name="usersxuidxuidgroupsmonikerbroadcastingcount"></a><span data-ttu-id="36c6c-104">ユーザー/xuid ({xuid})/groups/{モニカー} ブロードキャスト/カウント</span><span class="sxs-lookup"><span data-stu-id="36c6c-104">/users/xuid({xuid})/groups/{moniker}/broadcasting/count</span></span>
<span data-ttu-id="36c6c-105">アクセス グループ モニカーで指定されているブロードキャスト ユーザーの数は、URI 内に表示される XUID に関連します。</span><span class="sxs-lookup"><span data-stu-id="36c6c-105">Accesses the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span> <span data-ttu-id="36c6c-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="36c6c-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="36c6c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="36c6c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="36c6c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="36c6c-108">URI parameters</span></span>
 
| <span data-ttu-id="36c6c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="36c6c-109">Parameter</span></span>| <span data-ttu-id="36c6c-110">型</span><span class="sxs-lookup"><span data-stu-id="36c6c-110">Type</span></span>| <span data-ttu-id="36c6c-111">説明</span><span class="sxs-lookup"><span data-stu-id="36c6c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="36c6c-112">xuid</span><span class="sxs-lookup"><span data-stu-id="36c6c-112">xuid</span></span>| <span data-ttu-id="36c6c-113">string</span><span class="sxs-lookup"><span data-stu-id="36c6c-113">string</span></span>| <span data-ttu-id="36c6c-114">Xbox ユーザー ID (XUID)、ユーザー、グループ内の Xuid に関連するのです。</span><span class="sxs-lookup"><span data-stu-id="36c6c-114">Xbox User ID (XUID) of the user related to the XUIDs in the Group.</span></span>| 
| <span data-ttu-id="36c6c-115">モニカー</span><span class="sxs-lookup"><span data-stu-id="36c6c-115">moniker</span></span>| <span data-ttu-id="36c6c-116">string</span><span class="sxs-lookup"><span data-stu-id="36c6c-116">string</span></span>| <span data-ttu-id="36c6c-117">ユーザーのグループを定義する文字列です。</span><span class="sxs-lookup"><span data-stu-id="36c6c-117">String defining the group of users.</span></span> <span data-ttu-id="36c6c-118">現時点では受け入れられるだけモニカーでは、大文字の 'P'"People"でです。</span><span class="sxs-lookup"><span data-stu-id="36c6c-118">The only accepted moniker at present is "People", with a capital 'P'.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="36c6c-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="36c6c-119">Valid methods</span></span>

[<span data-ttu-id="36c6c-120">(ユーザー/xuid ({xuid})/groups/{モニカー} ブロードキャスト/数) を取得します。</span><span class="sxs-lookup"><span data-stu-id="36c6c-120">GET (/users/xuid({xuid})/groups/{moniker}/broadcasting/count )</span></span>](uri-usersxuidgroupsmonikerbroadcastingcountget.md)

<span data-ttu-id="36c6c-121">&nbsp;&nbsp;URI に表示される XUID に関連するグループ モニカーで指定されているブロードキャスト ユーザーの数を取得します。</span><span class="sxs-lookup"><span data-stu-id="36c6c-121">&nbsp;&nbsp;Retrieves the count of the broadcasting users specified by the groups moniker related to the XUID that appears in the URI.</span></span>
 
<a id="ID4EHC"></a>

 
## <a name="see-also"></a><span data-ttu-id="36c6c-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="36c6c-122">See also</span></span>
 
<a id="ID4EJC"></a>

 
##### <a name="parent"></a><span data-ttu-id="36c6c-123">Parent</span><span class="sxs-lookup"><span data-stu-id="36c6c-123">Parent</span></span> 

[<span data-ttu-id="36c6c-124">プレゼンス Uri</span><span class="sxs-lookup"><span data-stu-id="36c6c-124">Presence URIs</span></span>](atoc-reference-presence.md)

   