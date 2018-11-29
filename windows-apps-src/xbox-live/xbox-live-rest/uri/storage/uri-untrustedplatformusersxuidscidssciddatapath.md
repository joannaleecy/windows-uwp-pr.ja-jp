---
title: /untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}
assetID: d1e05113-c7a3-d615-52d7-d54f08b30b44
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersxuidscidssciddatapath.html
description: " /untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1d722656412e0864b338c5444407572a13f5fbd0
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8217786"
---
# <a name="untrustedplatformusersxuidxuidscidssciddatapath"></a><span data-ttu-id="6c970-104">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="6c970-104">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="6c970-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="6c970-105">Lists file information at a specified path.</span></span> <span data-ttu-id="6c970-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6c970-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6c970-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c970-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6c970-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c970-108">URI parameters</span></span>
 
| <span data-ttu-id="6c970-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c970-109">Parameter</span></span>| <span data-ttu-id="6c970-110">型</span><span class="sxs-lookup"><span data-stu-id="6c970-110">Type</span></span>| <span data-ttu-id="6c970-111">説明</span><span class="sxs-lookup"><span data-stu-id="6c970-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6c970-112">xuid</span><span class="sxs-lookup"><span data-stu-id="6c970-112">xuid</span></span>| <span data-ttu-id="6c970-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6c970-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="6c970-114">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="6c970-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="6c970-115">scid</span><span class="sxs-lookup"><span data-stu-id="6c970-115">scid</span></span>| <span data-ttu-id="6c970-116">guid</span><span class="sxs-lookup"><span data-stu-id="6c970-116">guid</span></span>| <span data-ttu-id="6c970-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="6c970-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="6c970-118">path</span><span class="sxs-lookup"><span data-stu-id="6c970-118">path</span></span>| <span data-ttu-id="6c970-119">string</span><span class="sxs-lookup"><span data-stu-id="6c970-119">string</span></span>| <span data-ttu-id="6c970-120">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="6c970-120">The path to the data items to return.</span></span> <span data-ttu-id="6c970-121">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="6c970-121">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="6c970-122">有効な文字には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6c970-122">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="6c970-123">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="6c970-123">May be empty.</span></span> <span data-ttu-id="6c970-124">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="6c970-124">Max length of 256.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="6c970-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="6c970-125">Valid methods</span></span>

[<span data-ttu-id="6c970-126">GET</span><span class="sxs-lookup"><span data-stu-id="6c970-126">GET</span></span>](uri-untrustedplatformusersxuidscidssciddatapath-get.md)

<span data-ttu-id="6c970-127">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="6c970-127">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="6c970-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="6c970-128">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6c970-129">Parent</span><span class="sxs-lookup"><span data-stu-id="6c970-129">Parent</span></span> 

[<span data-ttu-id="6c970-130">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="6c970-130">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   