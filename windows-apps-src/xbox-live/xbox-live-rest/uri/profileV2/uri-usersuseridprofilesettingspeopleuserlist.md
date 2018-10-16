---
title: /users/{userId}/profile/settings/people/{userList}?settings={settings}
assetID: 0ba20eba-f0ab-28ab-61d3-b4f9e4c07bc5
permalink: en-us/docs/xboxlive/rest/uri-usersuseridprofilesettingspeopleuserlist.html
author: KevinAsgari
description: " /users/{userId}/profile/settings/people/{userList}?settings={settings}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 44341b5fc8f831e3a500f47a51b94978f587cb8c
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4681317"
---
# <a name="usersuseridprofilesettingspeopleuserlistsettingssettings"></a><span data-ttu-id="5f566-104">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span><span class="sxs-lookup"><span data-stu-id="5f566-104">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span></span>
<span data-ttu-id="5f566-105">People モニカー サポートでのユーザーのプロファイルにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="5f566-105">Access the profile for a user or users, with People Moniker support.</span></span> <span data-ttu-id="5f566-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="5f566-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="5f566-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5f566-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5f566-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5f566-108">URI parameters</span></span>
 
| <span data-ttu-id="5f566-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5f566-109">Parameter</span></span>| <span data-ttu-id="5f566-110">型</span><span class="sxs-lookup"><span data-stu-id="5f566-110">Type</span></span>| <span data-ttu-id="5f566-111">説明</span><span class="sxs-lookup"><span data-stu-id="5f566-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5f566-112">ユーザー Id</span><span class="sxs-lookup"><span data-stu-id="5f566-112">userId</span></span>| <span data-ttu-id="5f566-113">string</span><span class="sxs-lookup"><span data-stu-id="5f566-113">string</span></span>| <span data-ttu-id="5f566-114">'Xuid(12345)'、'gt(myGamertag)' の 'me' またはいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="5f566-114">Can be either 'xuid(12345)', 'gt(myGamertag)', or 'me'.</span></span>| 
| <span data-ttu-id="5f566-115">userList</span><span class="sxs-lookup"><span data-stu-id="5f566-115">userList</span></span>| <span data-ttu-id="5f566-116">string</span><span class="sxs-lookup"><span data-stu-id="5f566-116">string</span></span>| <span data-ttu-id="5f566-117">名前付きの設定を取得するユーザーの一覧。</span><span class="sxs-lookup"><span data-stu-id="5f566-117">A named list of people to get settings for.</span></span> <span data-ttu-id="5f566-118">現時点では、ユーザーは、サポートされている唯一の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="5f566-118">Currently, People is the only list supported.</span></span>| 
  
<a id="ID4E1B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="5f566-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5f566-119">Valid methods</span></span>

[<span data-ttu-id="5f566-120">GET (/users/{userId}/profile/settings/people/{userList})</span><span class="sxs-lookup"><span data-stu-id="5f566-120">GET (/users/{userId}/profile/settings/people/{userList})</span></span>](uri-usersuseridprofilesettingspeopleuserlistget.md)

<span data-ttu-id="5f566-121">&nbsp;&nbsp;ユーザーのプロファイルを取得またはユーザー, People モニカーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="5f566-121">&nbsp;&nbsp;Get the profile for a user or users, with People Moniker support.</span></span>
 
<a id="ID4EEC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5f566-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="5f566-122">See also</span></span>
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5f566-123">Parent</span><span class="sxs-lookup"><span data-stu-id="5f566-123">Parent</span></span> 

[<span data-ttu-id="5f566-124">プロフィール URI</span><span class="sxs-lookup"><span data-stu-id="5f566-124">Profiles URIs</span></span>](atoc-reference-profiles.md)

 [<span data-ttu-id="5f566-125">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="5f566-125">Profile (JSON)</span></span>](../../json/json-profile.md)

   