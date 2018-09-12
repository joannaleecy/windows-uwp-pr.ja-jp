---
title: ユーザー/xuid/users/{ownerId}
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
author: KevinAsgari
description: " ユーザー/xuid/users/{ownerId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 715659b8bb001697fc9386be6ec587b3682793c5
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882396"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="02633-104">ユーザー/xuid/users/{ownerId}</span><span class="sxs-lookup"><span data-stu-id="02633-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="02633-105">XUID によってユーザーを呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="02633-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="02633-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="02633-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="02633-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="02633-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="02633-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="02633-108">URI parameters</span></span>
 
| <span data-ttu-id="02633-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="02633-109">Parameter</span></span>| <span data-ttu-id="02633-110">型</span><span class="sxs-lookup"><span data-stu-id="02633-110">Type</span></span>| <span data-ttu-id="02633-111">説明</span><span class="sxs-lookup"><span data-stu-id="02633-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="02633-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="02633-112">ownerId</span></span>| <span data-ttu-id="02633-113">string</span><span class="sxs-lookup"><span data-stu-id="02633-113">string</span></span>| <span data-ttu-id="02633-114">そのリソースにアクセスしているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="02633-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="02633-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="02633-115">Must match the authenticated user.</span></span> <span data-ttu-id="02633-116">設定可能な値とは、"me"、だけ、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="02633-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="02633-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="02633-117">Valid methods</span></span>

[<span data-ttu-id="02633-118">POST</span><span class="sxs-lookup"><span data-stu-id="02633-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="02633-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="02633-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="02633-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="02633-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="02633-121">Parent</span><span class="sxs-lookup"><span data-stu-id="02633-121">Parent</span></span> 

[<span data-ttu-id="02633-122">ユニバーサル リソース識別子 (URI) の参照</span><span class="sxs-lookup"><span data-stu-id="02633-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   