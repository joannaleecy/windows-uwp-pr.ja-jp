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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645687"
---
# <a name="usersxuidxuidhistorytitles"></a><span data-ttu-id="f2281-104">/users/xuid({xuid})/history/titles</span><span class="sxs-lookup"><span data-stu-id="f2281-104">/users/xuid({xuid})/history/titles</span></span>
 
<span data-ttu-id="f2281-105">この Universal Resource Identifier (URI) は、ユーザーのタイトルの達成に関連する履歴へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="f2281-105">This Universal Resource Identifier (URI) provides access to a user's Achievement-related title history.</span></span>
 
<span data-ttu-id="f2281-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f2281-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
<a id="ID4E1"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f2281-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2281-107">URI parameters</span></span>
 
| <span data-ttu-id="f2281-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2281-108">Parameter</span></span>| <span data-ttu-id="f2281-109">種類</span><span class="sxs-lookup"><span data-stu-id="f2281-109">Type</span></span>| <span data-ttu-id="f2281-110">説明</span><span class="sxs-lookup"><span data-stu-id="f2281-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f2281-111">xuid</span><span class="sxs-lookup"><span data-stu-id="f2281-111">xuid</span></span>| <span data-ttu-id="f2281-112">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f2281-112">64-bit unsigned integer</span></span>| <span data-ttu-id="f2281-113">Xbox ユーザー ID (XUID)、ユーザーがタイトル履歴にアクセスしているのです。</span><span class="sxs-lookup"><span data-stu-id="f2281-113">Xbox User ID (XUID) of the user whose title history is being accessed.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f2281-114">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f2281-114">Valid methods</span></span>

[<span data-ttu-id="f2281-115">取得</span><span class="sxs-lookup"><span data-stu-id="f2281-115">GET</span></span>](uri-titlehistoryusersxuidhistorytitlesgetv2.md)

<span data-ttu-id="f2281-116">&nbsp;&nbsp;ユーザーがロックを解除またはその成績の進歩をタイトルの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="f2281-116">&nbsp;&nbsp;Gets a list of titles for which the user has unlocked or made progress on its achievements.</span></span> <span data-ttu-id="f2281-117">この API では、タイトルの再生または起動のユーザーの完全な履歴は返されません。</span><span class="sxs-lookup"><span data-stu-id="f2281-117">This API does not return a user's full history of titles played or launched.</span></span>
 
<a id="ID4EKC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f2281-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="f2281-118">See also</span></span>
 
<a id="ID4EMC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f2281-119">Parent</span><span class="sxs-lookup"><span data-stu-id="f2281-119">Parent</span></span> 

[<span data-ttu-id="f2281-120">アチーブメントのタイトルの履歴の Uri</span><span class="sxs-lookup"><span data-stu-id="f2281-120">Achievement Title History URIs</span></span>](atoc-reference-titlehistoryv2.md)

   