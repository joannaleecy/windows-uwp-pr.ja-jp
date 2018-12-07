---
title: /users/{userId}/profile/settings/people/{userList}?settings={settings}
assetID: 0ba20eba-f0ab-28ab-61d3-b4f9e4c07bc5
permalink: en-us/docs/xboxlive/rest/uri-usersuseridprofilesettingspeopleuserlist.html
description: " /users/{userId}/profile/settings/people/{userList}?settings={settings}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 24b58c817156a7c372a8e6acfab895e6b7c51207
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8757179"
---
# <a name="usersuseridprofilesettingspeopleuserlistsettingssettings"></a><span data-ttu-id="19f4c-104">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span><span class="sxs-lookup"><span data-stu-id="19f4c-104">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span></span>
<span data-ttu-id="19f4c-105">ユーザーのプロファイルへのアクセスや、ユーザー, People モニカーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="19f4c-105">Access the profile for a user or users, with People Moniker support.</span></span> <span data-ttu-id="19f4c-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="19f4c-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="19f4c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="19f4c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="19f4c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="19f4c-108">URI parameters</span></span>
 
| <span data-ttu-id="19f4c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="19f4c-109">Parameter</span></span>| <span data-ttu-id="19f4c-110">型</span><span class="sxs-lookup"><span data-stu-id="19f4c-110">Type</span></span>| <span data-ttu-id="19f4c-111">説明</span><span class="sxs-lookup"><span data-stu-id="19f4c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="19f4c-112">ユーザー Id</span><span class="sxs-lookup"><span data-stu-id="19f4c-112">userId</span></span>| <span data-ttu-id="19f4c-113">string</span><span class="sxs-lookup"><span data-stu-id="19f4c-113">string</span></span>| <span data-ttu-id="19f4c-114">'Xuid(12345)'、'gt(myGamertag)' の 'me' またはいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="19f4c-114">Can be either 'xuid(12345)', 'gt(myGamertag)', or 'me'.</span></span>| 
| <span data-ttu-id="19f4c-115">userList</span><span class="sxs-lookup"><span data-stu-id="19f4c-115">userList</span></span>| <span data-ttu-id="19f4c-116">string</span><span class="sxs-lookup"><span data-stu-id="19f4c-116">string</span></span>| <span data-ttu-id="19f4c-117">名前付きの設定を取得するユーザーの一覧。</span><span class="sxs-lookup"><span data-stu-id="19f4c-117">A named list of people to get settings for.</span></span> <span data-ttu-id="19f4c-118">現時点では、ユーザーは、サポートされている唯一の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="19f4c-118">Currently, People is the only list supported.</span></span>| 
  
<a id="ID4E1B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="19f4c-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="19f4c-119">Valid methods</span></span>

[<span data-ttu-id="19f4c-120">GET (/users/{userId}/profile/settings/people/{userList})</span><span class="sxs-lookup"><span data-stu-id="19f4c-120">GET (/users/{userId}/profile/settings/people/{userList})</span></span>](uri-usersuseridprofilesettingspeopleuserlistget.md)

<span data-ttu-id="19f4c-121">&nbsp;&nbsp;ユーザーのプロファイルを取得またはユーザー, People モニカーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="19f4c-121">&nbsp;&nbsp;Get the profile for a user or users, with People Moniker support.</span></span>
 
<a id="ID4EEC"></a>

 
## <a name="see-also"></a><span data-ttu-id="19f4c-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="19f4c-122">See also</span></span>
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a><span data-ttu-id="19f4c-123">Parent</span><span class="sxs-lookup"><span data-stu-id="19f4c-123">Parent</span></span> 

[<span data-ttu-id="19f4c-124">プロフィール URI</span><span class="sxs-lookup"><span data-stu-id="19f4c-124">Profiles URIs</span></span>](atoc-reference-profiles.md)

 [<span data-ttu-id="19f4c-125">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="19f4c-125">Profile (JSON)</span></span>](../../json/json-profile.md)

   