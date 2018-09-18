---
title: /users/xuid({xuid})/devices/current/titles/current
assetID: f149c68b-9874-e348-4e1d-6acf5d305c49
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrent.html
author: KevinAsgari
description: " /users/xuid({xuid})/devices/current/titles/current"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1fe5e366c48dc5cc7586604584adb6af00207b85
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4020233"
---
# <a name="usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="c290d-104">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="c290d-104">/users/xuid({xuid})/devices/current/titles/current</span></span>
<span data-ttu-id="c290d-105">タイトルまたはタイトルのユーザーのプレゼンスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="c290d-105">Access the presence of a title or a title's user.</span></span> <span data-ttu-id="c290d-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c290d-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c290d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c290d-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c290d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c290d-108">URI parameters</span></span>
 
| <span data-ttu-id="c290d-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c290d-109">Parameter</span></span>| <span data-ttu-id="c290d-110">型</span><span class="sxs-lookup"><span data-stu-id="c290d-110">Type</span></span>| <span data-ttu-id="c290d-111">説明</span><span class="sxs-lookup"><span data-stu-id="c290d-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c290d-112">xuid</span><span class="sxs-lookup"><span data-stu-id="c290d-112">xuid</span></span>| <span data-ttu-id="c290d-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c290d-113">64-bit unsigned integer</span></span>| <span data-ttu-id="c290d-114">Xbox ユーザー ID (XUID) 対象ユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="c290d-114">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="c290d-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="c290d-115">Valid methods</span></span>

[<span data-ttu-id="c290d-116">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="c290d-116">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentdelete.md)

<span data-ttu-id="c290d-117">&nbsp;&nbsp;[Presencerecord を要求して](../../json/json-presencerecord.md)有効期限が切れるまで待つの終了タイトルのプレゼンスを削除します。</span><span class="sxs-lookup"><span data-stu-id="c290d-117">&nbsp;&nbsp;Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span>

[<span data-ttu-id="c290d-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="c290d-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentpost.md)

<span data-ttu-id="c290d-119">&nbsp;&nbsp;ユーザーのプレゼンスでタイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="c290d-119">&nbsp;&nbsp;Update a title with a user's presence.</span></span>
 
<a id="ID4EBC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c290d-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="c290d-120">See also</span></span>
 
<a id="ID4EDC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c290d-121">Parent</span><span class="sxs-lookup"><span data-stu-id="c290d-121">Parent</span></span> 

[<span data-ttu-id="c290d-122">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="c290d-122">Presence URIs</span></span>](atoc-reference-presence.md)

   