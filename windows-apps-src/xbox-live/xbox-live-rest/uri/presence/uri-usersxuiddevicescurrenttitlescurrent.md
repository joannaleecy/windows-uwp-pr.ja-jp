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
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3958077"
---
# <a name="usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="e4f52-104">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="e4f52-104">/users/xuid({xuid})/devices/current/titles/current</span></span>
<span data-ttu-id="e4f52-105">タイトルまたはタイトルのユーザーの有無にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="e4f52-105">Access the presence of a title or a title's user.</span></span> <span data-ttu-id="e4f52-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e4f52-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e4f52-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4f52-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e4f52-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4f52-108">URI parameters</span></span>
 
| <span data-ttu-id="e4f52-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4f52-109">Parameter</span></span>| <span data-ttu-id="e4f52-110">型</span><span class="sxs-lookup"><span data-stu-id="e4f52-110">Type</span></span>| <span data-ttu-id="e4f52-111">説明</span><span class="sxs-lookup"><span data-stu-id="e4f52-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e4f52-112">xuid</span><span class="sxs-lookup"><span data-stu-id="e4f52-112">xuid</span></span>| <span data-ttu-id="e4f52-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e4f52-113">64-bit unsigned integer</span></span>| <span data-ttu-id="e4f52-114">Xbox ユーザー ID (XUID) 対象ユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="e4f52-114">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e4f52-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e4f52-115">Valid methods</span></span>

[<span data-ttu-id="e4f52-116">削除 (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="e4f52-116">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentdelete.md)

<span data-ttu-id="e4f52-117">&nbsp;&nbsp;[Presencerecord を要求して](../../json/json-presencerecord.md)有効期限が切れるのを待っているではなく、終了のタイトルのプレゼンスを削除します。</span><span class="sxs-lookup"><span data-stu-id="e4f52-117">&nbsp;&nbsp;Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span>

[<span data-ttu-id="e4f52-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="e4f52-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentpost.md)

<span data-ttu-id="e4f52-119">&nbsp;&nbsp;ユーザーのプレゼンスでは、タイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="e4f52-119">&nbsp;&nbsp;Update a title with a user's presence.</span></span>
 
<a id="ID4EBC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e4f52-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="e4f52-120">See also</span></span>
 
<a id="ID4EDC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e4f52-121">Parent</span><span class="sxs-lookup"><span data-stu-id="e4f52-121">Parent</span></span> 

[<span data-ttu-id="e4f52-122">プレゼンス Uri</span><span class="sxs-lookup"><span data-stu-id="e4f52-122">Presence URIs</span></span>](atoc-reference-presence.md)

   