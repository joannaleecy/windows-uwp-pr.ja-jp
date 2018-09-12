---
title: /users/{userId}/プロファイルの設定/ユーザー/{userList} かどうか設定 = {設定}。
assetID: 0ba20eba-f0ab-28ab-61d3-b4f9e4c07bc5
permalink: en-us/docs/xboxlive/rest/uri-usersuseridprofilesettingspeopleuserlist.html
author: KevinAsgari
description: " /users/{userId}/プロファイルの設定/ユーザー/{userList} かどうか設定 = {設定}。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 44341b5fc8f831e3a500f47a51b94978f587cb8c
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881726"
---
# <a name="usersuseridprofilesettingspeopleuserlistsettingssettings"></a><span data-ttu-id="a8951-104">/users/{userId}/プロファイルの設定/ユーザー/{userList} かどうか設定 = {設定}。</span><span class="sxs-lookup"><span data-stu-id="a8951-104">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span></span>
<span data-ttu-id="a8951-105">People モニカー サポートでのユーザーのプロファイルにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="a8951-105">Access the profile for a user or users, with People Moniker support.</span></span> <span data-ttu-id="a8951-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a8951-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a8951-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8951-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a8951-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8951-108">URI parameters</span></span>
 
| <span data-ttu-id="a8951-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a8951-109">Parameter</span></span>| <span data-ttu-id="a8951-110">型</span><span class="sxs-lookup"><span data-stu-id="a8951-110">Type</span></span>| <span data-ttu-id="a8951-111">説明</span><span class="sxs-lookup"><span data-stu-id="a8951-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a8951-112">ユーザー Id</span><span class="sxs-lookup"><span data-stu-id="a8951-112">userId</span></span>| <span data-ttu-id="a8951-113">string</span><span class="sxs-lookup"><span data-stu-id="a8951-113">string</span></span>| <span data-ttu-id="a8951-114">'Xuid(12345)'、'gt(myGamertag)' の 'me' またはいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="a8951-114">Can be either 'xuid(12345)', 'gt(myGamertag)', or 'me'.</span></span>| 
| <span data-ttu-id="a8951-115">userList</span><span class="sxs-lookup"><span data-stu-id="a8951-115">userList</span></span>| <span data-ttu-id="a8951-116">string</span><span class="sxs-lookup"><span data-stu-id="a8951-116">string</span></span>| <span data-ttu-id="a8951-117">名前付きの設定を取得するユーザーの一覧。</span><span class="sxs-lookup"><span data-stu-id="a8951-117">A named list of people to get settings for.</span></span> <span data-ttu-id="a8951-118">現時点では、ユーザーは、サポートされている唯一の一覧です。</span><span class="sxs-lookup"><span data-stu-id="a8951-118">Currently, People is the only list supported.</span></span>| 
  
<a id="ID4E1B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a8951-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a8951-119">Valid methods</span></span>

[<span data-ttu-id="a8951-120">(/Users/{userId}/プロファイルの設定/ユーザー/{userList}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="a8951-120">GET (/users/{userId}/profile/settings/people/{userList})</span></span>](uri-usersuseridprofilesettingspeopleuserlistget.md)

<span data-ttu-id="a8951-121">&nbsp;&nbsp;ユーザーのプロファイルを取得またはユーザー, People モニカーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="a8951-121">&nbsp;&nbsp;Get the profile for a user or users, with People Moniker support.</span></span>
 
<a id="ID4EEC"></a>

 
## <a name="see-also"></a><span data-ttu-id="a8951-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="a8951-122">See also</span></span>
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a8951-123">Parent</span><span class="sxs-lookup"><span data-stu-id="a8951-123">Parent</span></span> 

[<span data-ttu-id="a8951-124">プロファイルの Uri</span><span class="sxs-lookup"><span data-stu-id="a8951-124">Profiles URIs</span></span>](atoc-reference-profiles.md)

 [<span data-ttu-id="a8951-125">プロファイル (JSON)</span><span class="sxs-lookup"><span data-stu-id="a8951-125">Profile (JSON)</span></span>](../../json/json-profile.md)

   