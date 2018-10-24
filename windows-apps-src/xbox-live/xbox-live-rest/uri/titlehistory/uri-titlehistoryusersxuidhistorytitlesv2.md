---
title: /users/xuid({xuid})/history/titles
assetID: 2f8eb79a-42c2-0267-cbf2-8682bb28f270
permalink: en-us/docs/xboxlive/rest/uri-titlehistoryusersxuidhistorytitlesv2.html
author: KevinAsgari
description: " /users/xuid({xuid})/history/titles"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a4780c92fc16adb697783ecee50d36523ff92998
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5437693"
---
# <a name="usersxuidxuidhistorytitles"></a><span data-ttu-id="86c73-104">/users/xuid({xuid})/history/titles</span><span class="sxs-lookup"><span data-stu-id="86c73-104">/users/xuid({xuid})/history/titles</span></span>
 
<span data-ttu-id="86c73-105">このユニバーサル リソース識別子 (URI) は、ユーザーの実績に関連するタイトル履歴へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="86c73-105">This Universal Resource Identifier (URI) provides access to a user's Achievement-related title history.</span></span>
 
<span data-ttu-id="86c73-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="86c73-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="86c73-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="86c73-107">URI parameters</span></span>
 
| <span data-ttu-id="86c73-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="86c73-108">Parameter</span></span>| <span data-ttu-id="86c73-109">型</span><span class="sxs-lookup"><span data-stu-id="86c73-109">Type</span></span>| <span data-ttu-id="86c73-110">説明</span><span class="sxs-lookup"><span data-stu-id="86c73-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="86c73-111">xuid</span><span class="sxs-lookup"><span data-stu-id="86c73-111">xuid</span></span>| <span data-ttu-id="86c73-112">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="86c73-112">64-bit unsigned integer</span></span>| <span data-ttu-id="86c73-113">Xbox ユーザー ID (XUID) がタイトル履歴にアクセスしているユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="86c73-113">Xbox User ID (XUID) of the user whose title history is being accessed.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="86c73-114">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="86c73-114">Valid methods</span></span>

[<span data-ttu-id="86c73-115">GET</span><span class="sxs-lookup"><span data-stu-id="86c73-115">GET</span></span>](uri-titlehistoryusersxuidhistorytitlesgetv2.md)

<span data-ttu-id="86c73-116">&nbsp;&nbsp;タイトルは、ユーザーがロックを解除またはその実績の進行状況を行ったの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="86c73-116">&nbsp;&nbsp;Gets a list of titles for which the user has unlocked or made progress on its achievements.</span></span> <span data-ttu-id="86c73-117">この API では、タイトルのプレイまたは起動のユーザーのすべての履歴は返されません。</span><span class="sxs-lookup"><span data-stu-id="86c73-117">This API does not return a user's full history of titles played or launched.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="86c73-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="86c73-118">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="86c73-119">Parent</span><span class="sxs-lookup"><span data-stu-id="86c73-119">Parent</span></span> 

[<span data-ttu-id="86c73-120">実績タイトル履歴 URI</span><span class="sxs-lookup"><span data-stu-id="86c73-120">Achievement Title History URIs</span></span>](atoc-reference-titlehistoryv2.md)

   