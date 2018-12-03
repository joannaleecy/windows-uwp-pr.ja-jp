---
title: /users/xuid({xuid})/history/titles
assetID: 2f8eb79a-42c2-0267-cbf2-8682bb28f270
permalink: en-us/docs/xboxlive/rest/uri-titlehistoryusersxuidhistorytitlesv2.html
description: " /users/xuid({xuid})/history/titles"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7bb528f139e9db97f886f57fb98461ce15e77a42
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8341932"
---
# <a name="usersxuidxuidhistorytitles"></a><span data-ttu-id="9865f-104">/users/xuid({xuid})/history/titles</span><span class="sxs-lookup"><span data-stu-id="9865f-104">/users/xuid({xuid})/history/titles</span></span>
 
<span data-ttu-id="9865f-105">このユニバーサル リソース識別子 (URI) は、ユーザーの実績に関連するタイトル履歴へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="9865f-105">This Universal Resource Identifier (URI) provides access to a user's Achievement-related title history.</span></span>
 
<span data-ttu-id="9865f-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9865f-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9865f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9865f-107">URI parameters</span></span>
 
| <span data-ttu-id="9865f-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9865f-108">Parameter</span></span>| <span data-ttu-id="9865f-109">型</span><span class="sxs-lookup"><span data-stu-id="9865f-109">Type</span></span>| <span data-ttu-id="9865f-110">説明</span><span class="sxs-lookup"><span data-stu-id="9865f-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9865f-111">xuid</span><span class="sxs-lookup"><span data-stu-id="9865f-111">xuid</span></span>| <span data-ttu-id="9865f-112">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9865f-112">64-bit unsigned integer</span></span>| <span data-ttu-id="9865f-113">Xbox ユーザー ID (XUID) がタイトル履歴にアクセスしているユーザー。</span><span class="sxs-lookup"><span data-stu-id="9865f-113">Xbox User ID (XUID) of the user whose title history is being accessed.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="9865f-114">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9865f-114">Valid methods</span></span>

[<span data-ttu-id="9865f-115">GET</span><span class="sxs-lookup"><span data-stu-id="9865f-115">GET</span></span>](uri-titlehistoryusersxuidhistorytitlesgetv2.md)

<span data-ttu-id="9865f-116">&nbsp;&nbsp;タイトルは、ユーザーがロックを解除またはに対するその実績の進行状況の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="9865f-116">&nbsp;&nbsp;Gets a list of titles for which the user has unlocked or made progress on its achievements.</span></span> <span data-ttu-id="9865f-117">この API では、タイトルのプレイまたは起動したユーザーのすべての履歴は返されません。</span><span class="sxs-lookup"><span data-stu-id="9865f-117">This API does not return a user's full history of titles played or launched.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9865f-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="9865f-118">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9865f-119">Parent</span><span class="sxs-lookup"><span data-stu-id="9865f-119">Parent</span></span> 

[<span data-ttu-id="9865f-120">実績タイトル履歴 URI</span><span class="sxs-lookup"><span data-stu-id="9865f-120">Achievement Title History URIs</span></span>](atoc-reference-titlehistoryv2.md)

   