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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636967"
---
# <a name="usersuseridprofilesettingspeopleuserlistsettingssettings"></a><span data-ttu-id="95046-104">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span><span class="sxs-lookup"><span data-stu-id="95046-104">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span></span>
<span data-ttu-id="95046-105">ユーザーのプロファイルへのアクセスまたはユーザーのモニカーでのユーザーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="95046-105">Access the profile for a user or users, with People Moniker support.</span></span> <span data-ttu-id="95046-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="95046-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="95046-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="95046-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="95046-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="95046-108">URI parameters</span></span>
 
| <span data-ttu-id="95046-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="95046-109">Parameter</span></span>| <span data-ttu-id="95046-110">種類</span><span class="sxs-lookup"><span data-stu-id="95046-110">Type</span></span>| <span data-ttu-id="95046-111">説明</span><span class="sxs-lookup"><span data-stu-id="95046-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="95046-112">userId</span><span class="sxs-lookup"><span data-stu-id="95046-112">userId</span></span>| <span data-ttu-id="95046-113">string</span><span class="sxs-lookup"><span data-stu-id="95046-113">string</span></span>| <span data-ttu-id="95046-114">'Xuid(12345)'、'gt(myGamertag)' のいずれかまたは 'me' を指定できます。</span><span class="sxs-lookup"><span data-stu-id="95046-114">Can be either 'xuid(12345)', 'gt(myGamertag)', or 'me'.</span></span>| 
| <span data-ttu-id="95046-115">userList</span><span class="sxs-lookup"><span data-stu-id="95046-115">userList</span></span>| <span data-ttu-id="95046-116">string</span><span class="sxs-lookup"><span data-stu-id="95046-116">string</span></span>| <span data-ttu-id="95046-117">設定を取得するユーザーの名前付きのリスト。</span><span class="sxs-lookup"><span data-stu-id="95046-117">A named list of people to get settings for.</span></span> <span data-ttu-id="95046-118">現時点では、ユーザーは、サポートされているだけの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="95046-118">Currently, People is the only list supported.</span></span>| 
  
<a id="ID4E1B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="95046-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="95046-119">Valid methods</span></span>

[<span data-ttu-id="95046-120">GET (/users/{userId}/profile/settings/people/{userList})</span><span class="sxs-lookup"><span data-stu-id="95046-120">GET (/users/{userId}/profile/settings/people/{userList})</span></span>](uri-usersuseridprofilesettingspeopleuserlistget.md)

<span data-ttu-id="95046-121">&nbsp;&nbsp;ユーザーのプロファイルを取得またはユーザーのモニカーでのユーザーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="95046-121">&nbsp;&nbsp;Get the profile for a user or users, with People Moniker support.</span></span>
 
<a id="ID4EEC"></a>

 
## <a name="see-also"></a><span data-ttu-id="95046-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="95046-122">See also</span></span>
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a><span data-ttu-id="95046-123">Parent</span><span class="sxs-lookup"><span data-stu-id="95046-123">Parent</span></span> 

[<span data-ttu-id="95046-124">プロファイルの Uri</span><span class="sxs-lookup"><span data-stu-id="95046-124">Profiles URIs</span></span>](atoc-reference-profiles.md)

 [<span data-ttu-id="95046-125">プロファイル (JSON)</span><span class="sxs-lookup"><span data-stu-id="95046-125">Profile (JSON)</span></span>](../../json/json-profile.md)

   