---
title: /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}
assetID: a60a231c-359a-ee6a-6d18-f9e8c6afd0fc
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapath.html
description: " /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ff0d2589eb970ef05f8746bb407857de7ebb3256
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589727"
---
# <a name="trustedplatformusersxuidxuidscidssciddatapath"></a><span data-ttu-id="df57b-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="df57b-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="df57b-105">指定されたパスにファイル情報を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="df57b-105">Lists file information at a specified path.</span></span> <span data-ttu-id="df57b-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="df57b-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="df57b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="df57b-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="df57b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="df57b-108">URI parameters</span></span>
 
| <span data-ttu-id="df57b-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="df57b-109">Parameter</span></span>| <span data-ttu-id="df57b-110">種類</span><span class="sxs-lookup"><span data-stu-id="df57b-110">Type</span></span>| <span data-ttu-id="df57b-111">説明</span><span class="sxs-lookup"><span data-stu-id="df57b-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="df57b-112">xuid</span><span class="sxs-lookup"><span data-stu-id="df57b-112">xuid</span></span>| <span data-ttu-id="df57b-113">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="df57b-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="df57b-114">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="df57b-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="df57b-115">scid</span><span class="sxs-lookup"><span data-stu-id="df57b-115">scid</span></span>| <span data-ttu-id="df57b-116">guid</span><span class="sxs-lookup"><span data-stu-id="df57b-116">guid</span></span>| <span data-ttu-id="df57b-117">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="df57b-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="df57b-118">パス</span><span class="sxs-lookup"><span data-stu-id="df57b-118">path</span></span>| <span data-ttu-id="df57b-119">string</span><span class="sxs-lookup"><span data-stu-id="df57b-119">string</span></span>| <span data-ttu-id="df57b-120">返されるデータのアイテムへのパス。</span><span class="sxs-lookup"><span data-stu-id="df57b-120">The path to the data items to return.</span></span> <span data-ttu-id="df57b-121">一致するすべてのディレクトリとサブディレクトリが返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="df57b-121">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="df57b-122">有効な文字には、大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_) およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="df57b-122">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="df57b-123">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="df57b-123">May be empty.</span></span> <span data-ttu-id="df57b-124">最大長は 256 です。</span><span class="sxs-lookup"><span data-stu-id="df57b-124">Max length of 256.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="df57b-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="df57b-125">Valid methods</span></span>

[<span data-ttu-id="df57b-126">取得</span><span class="sxs-lookup"><span data-stu-id="df57b-126">GET</span></span>](uri-trustedplatformusersxuidscidssciddatapath-get.md)

<span data-ttu-id="df57b-127">&nbsp;&nbsp;指定されたパスにファイル情報を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="df57b-127">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="df57b-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="df57b-128">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="df57b-129">Parent</span><span class="sxs-lookup"><span data-stu-id="df57b-129">Parent</span></span> 

[<span data-ttu-id="df57b-130">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="df57b-130">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   