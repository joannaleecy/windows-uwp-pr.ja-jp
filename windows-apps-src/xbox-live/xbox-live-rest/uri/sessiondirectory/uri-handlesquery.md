---
title: /handles/query
assetID: e00d31ad-b9ba-8e52-1333-83192eab0446
permalink: en-us/docs/xboxlive/rest/uri-handlesquery.html
description: " /handles/query"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eaa148972ce1e65056470a6c4082cb4e50de3f09
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598567"
---
# <a name="handlesquery"></a><span data-ttu-id="5f56f-104">/handles/query</span><span class="sxs-lookup"><span data-stu-id="5f56f-104">/handles/query</span></span>
<span data-ttu-id="5f56f-105">セッション ハンドルのクエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5f56f-105">Supports POST operations to create queries for session handles.</span></span> 

> [!NOTE] 
> <span data-ttu-id="5f56f-106">この URI は、2015年マルチ プレーヤーによって使用され、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="5f56f-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="5f56f-107">テンプレートのコントラクト/104 105 またはそれ以降で使用するものでは。</span><span class="sxs-lookup"><span data-stu-id="5f56f-107">It is intended for use with template contract 104/105 or later.</span></span>  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a><span data-ttu-id="5f56f-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="5f56f-108">Domain</span></span>
<span data-ttu-id="5f56f-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="5f56f-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="5f56f-110">注釈</span><span class="sxs-lookup"><span data-stu-id="5f56f-110">Remarks</span></span>
<span data-ttu-id="5f56f-111">この URI は、ハンドルのクエリをサポートします。</span><span class="sxs-lookup"><span data-stu-id="5f56f-111">This URI supports queries for handles.</span></span> <span data-ttu-id="5f56f-112">セッションのクエリは、文字列とバッチのクエリとは異なりは、ハンドルのクエリは、クエリ プロセッサのスタイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="5f56f-112">Unlike session queries, which are string and batch queries, handle queries use a query-processor style.</span></span> <span data-ttu-id="5f56f-113">最大 100 のハンドルがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="5f56f-113">Up to 100 handles are supported.</span></span>  
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5f56f-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5f56f-114">URI parameters</span></span>
 
<span data-ttu-id="5f56f-115">なし</span><span class="sxs-lookup"><span data-stu-id="5f56f-115">None</span></span>   
<a id="ID4EEB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="5f56f-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5f56f-116">Valid methods</span></span>

[<span data-ttu-id="5f56f-117">POST (/handles/query)</span><span class="sxs-lookup"><span data-stu-id="5f56f-117">POST (/handles/query)</span></span>](uri-handlesquerypost.md)

<span data-ttu-id="5f56f-118">&nbsp;&nbsp;セッション ハンドルのクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="5f56f-118">&nbsp;&nbsp;Creates queries for session handles.</span></span>

[<span data-ttu-id="5f56f-119">POST (/handles/query?include=relatedInfo)</span><span class="sxs-lookup"><span data-stu-id="5f56f-119">POST (/handles/query?include=relatedInfo)</span></span>](uri-handlesqueryincludepost.md)

<span data-ttu-id="5f56f-120">&nbsp;&nbsp;関連するセッションの情報を含むセッション ハンドルのクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="5f56f-120">&nbsp;&nbsp;Creates queries for session handles that include related session information.</span></span>
 
<a id="ID4EQB"></a>

 
## <a name="see-also"></a><span data-ttu-id="5f56f-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="5f56f-121">See also</span></span>
 
<a id="ID4ESB"></a>

 
##### <a name="parent"></a><span data-ttu-id="5f56f-122">Parent</span><span class="sxs-lookup"><span data-stu-id="5f56f-122">Parent</span></span> 

[<span data-ttu-id="5f56f-123">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="5f56f-123">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   