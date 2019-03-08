---
title: /users/{ownerId}/clips
assetID: cc200b89-dc63-9ab5-b037-7a910f46dae9
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclips.html
description: " /users/{ownerId}/clips"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cd711777bcdf0b073dd0821222049b03aa35a23c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599517"
---
# <a name="usersowneridclips"></a><span data-ttu-id="ef3da-104">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="ef3da-104">/users/{ownerId}/clips</span></span>
<span data-ttu-id="ef3da-105">ユーザーのクリップのアクセス リスト。</span><span class="sxs-lookup"><span data-stu-id="ef3da-105">Access list of user's clips.</span></span> <span data-ttu-id="ef3da-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="ef3da-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="ef3da-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ef3da-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ef3da-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ef3da-108">URI parameters</span></span>
 
| <span data-ttu-id="ef3da-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ef3da-109">Parameter</span></span>| <span data-ttu-id="ef3da-110">種類</span><span class="sxs-lookup"><span data-stu-id="ef3da-110">Type</span></span>| <span data-ttu-id="ef3da-111">説明</span><span class="sxs-lookup"><span data-stu-id="ef3da-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ef3da-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="ef3da-112">ownerId</span></span>| <span data-ttu-id="ef3da-113">string</span><span class="sxs-lookup"><span data-stu-id="ef3da-113">string</span></span>| <span data-ttu-id="ef3da-114">リソースがアクセスされているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="ef3da-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="ef3da-115">サポートされている形式:"xuid(123456789)"または"me"。</span><span class="sxs-lookup"><span data-stu-id="ef3da-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="ef3da-116">最大長:16.</span><span class="sxs-lookup"><span data-stu-id="ef3da-116">Maximum length: 16.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ef3da-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ef3da-117">Valid methods</span></span>

[<span data-ttu-id="ef3da-118">GET (/users/{ownerId}/clips)</span><span class="sxs-lookup"><span data-stu-id="ef3da-118">GET (/users/{ownerId}/clips)</span></span>](uri-usersowneridclipsget.md)

<span data-ttu-id="ef3da-119">&nbsp;&nbsp;ユーザーのクリップの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="ef3da-119">&nbsp;&nbsp;Retrieve list of user's clips.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="ef3da-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="ef3da-120">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ef3da-121">Parent</span><span class="sxs-lookup"><span data-stu-id="ef3da-121">Parent</span></span> 

[<span data-ttu-id="ef3da-122">ゲーム録画 Uri</span><span class="sxs-lookup"><span data-stu-id="ef3da-122">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   