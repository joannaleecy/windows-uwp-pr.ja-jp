---
title: /users/xuid({xuid})/devices/current/titles/current
assetID: f149c68b-9874-e348-4e1d-6acf5d305c49
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrent.html
description: " /users/xuid({xuid})/devices/current/titles/current"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0b5c17f1791d69ca8a4c902b6c37736c4da28a31
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8928246"
---
# <a name="usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="7c476-104">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="7c476-104">/users/xuid({xuid})/devices/current/titles/current</span></span>
<span data-ttu-id="7c476-105">タイトルまたはタイトルのユーザーのプレゼンスにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7c476-105">Access the presence of a title or a title's user.</span></span> <span data-ttu-id="7c476-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7c476-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7c476-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7c476-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7c476-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7c476-108">URI parameters</span></span>
 
| <span data-ttu-id="7c476-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7c476-109">Parameter</span></span>| <span data-ttu-id="7c476-110">型</span><span class="sxs-lookup"><span data-stu-id="7c476-110">Type</span></span>| <span data-ttu-id="7c476-111">説明</span><span class="sxs-lookup"><span data-stu-id="7c476-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7c476-112">xuid</span><span class="sxs-lookup"><span data-stu-id="7c476-112">xuid</span></span>| <span data-ttu-id="7c476-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="7c476-113">64-bit unsigned integer</span></span>| <span data-ttu-id="7c476-114">Xbox ユーザー ID (XUID) 対象ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="7c476-114">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="7c476-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="7c476-115">Valid methods</span></span>

[<span data-ttu-id="7c476-116">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="7c476-116">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentdelete.md)

<span data-ttu-id="7c476-117">&nbsp;&nbsp;[PresenceRecord](../../json/json-presencerecord.md)有効期限が切れるのを待っているではなく、終了のタイトルのプレゼンスを削除します。</span><span class="sxs-lookup"><span data-stu-id="7c476-117">&nbsp;&nbsp;Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span>

[<span data-ttu-id="7c476-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="7c476-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentpost.md)

<span data-ttu-id="7c476-119">&nbsp;&nbsp;ユーザーのプレゼンスでは、タイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="7c476-119">&nbsp;&nbsp;Update a title with a user's presence.</span></span>
 
<a id="ID4EBC"></a>

 
## <a name="see-also"></a><span data-ttu-id="7c476-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="7c476-120">See also</span></span>
 
<a id="ID4EDC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7c476-121">Parent</span><span class="sxs-lookup"><span data-stu-id="7c476-121">Parent</span></span> 

[<span data-ttu-id="7c476-122">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="7c476-122">Presence URIs</span></span>](atoc-reference-presence.md)

   