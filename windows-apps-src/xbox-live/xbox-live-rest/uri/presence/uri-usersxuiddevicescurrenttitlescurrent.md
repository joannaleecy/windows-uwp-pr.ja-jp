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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645667"
---
# <a name="usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="e690e-104">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="e690e-104">/users/xuid({xuid})/devices/current/titles/current</span></span>
<span data-ttu-id="e690e-105">タイトルまたはタイトルのユーザーの存在にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="e690e-105">Access the presence of a title or a title's user.</span></span> <span data-ttu-id="e690e-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e690e-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e690e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e690e-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e690e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e690e-108">URI parameters</span></span>
 
| <span data-ttu-id="e690e-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e690e-109">Parameter</span></span>| <span data-ttu-id="e690e-110">種類</span><span class="sxs-lookup"><span data-stu-id="e690e-110">Type</span></span>| <span data-ttu-id="e690e-111">説明</span><span class="sxs-lookup"><span data-stu-id="e690e-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e690e-112">xuid</span><span class="sxs-lookup"><span data-stu-id="e690e-112">xuid</span></span>| <span data-ttu-id="e690e-113">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e690e-113">64-bit unsigned integer</span></span>| <span data-ttu-id="e690e-114">Xbox ユーザー ID (XUID) の対象ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="e690e-114">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e690e-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e690e-115">Valid methods</span></span>

[<span data-ttu-id="e690e-116">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="e690e-116">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentdelete.md)

<span data-ttu-id="e690e-117">&nbsp;&nbsp;待つのではなく、終了のタイトルのプレゼンスを削除、 [PresenceRecord](../../json/json-presencerecord.md)期限切れにします。</span><span class="sxs-lookup"><span data-stu-id="e690e-117">&nbsp;&nbsp;Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span>

[<span data-ttu-id="e690e-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="e690e-118">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](uri-usersxuiddevicescurrenttitlescurrentpost.md)

<span data-ttu-id="e690e-119">&nbsp;&nbsp;ユーザーのプレゼンスとタイトルを更新します。</span><span class="sxs-lookup"><span data-stu-id="e690e-119">&nbsp;&nbsp;Update a title with a user's presence.</span></span>
 
<a id="ID4EBC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e690e-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="e690e-120">See also</span></span>
 
<a id="ID4EDC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e690e-121">Parent</span><span class="sxs-lookup"><span data-stu-id="e690e-121">Parent</span></span> 

[<span data-ttu-id="e690e-122">プレゼンスの Uri</span><span class="sxs-lookup"><span data-stu-id="e690e-122">Presence URIs</span></span>](atoc-reference-presence.md)

   