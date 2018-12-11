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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8918315"
---
# <a name="handlesquery"></a><span data-ttu-id="5e975-104">/handles/query</span><span class="sxs-lookup"><span data-stu-id="5e975-104">/handles/query</span></span>
<span data-ttu-id="5e975-105">セッション ハンドルのクエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5e975-105">Supports POST operations to create queries for session handles.</span></span> 

> [!NOTE] 
> <span data-ttu-id="5e975-106">この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="5e975-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="5e975-107">テンプレート コントラクト 104/105 以降で使用されます。</span><span class="sxs-lookup"><span data-stu-id="5e975-107">It is intended for use with template contract 104/105 or later.</span></span>  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a><span data-ttu-id="5e975-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="5e975-108">Domain</span></span>
<span data-ttu-id="5e975-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="5e975-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="5e975-110">注釈</span><span class="sxs-lookup"><span data-stu-id="5e975-110">Remarks</span></span>
<span data-ttu-id="5e975-111">この URI は、ハンドルのクエリをサポートします。</span><span class="sxs-lookup"><span data-stu-id="5e975-111">This URI supports queries for handles.</span></span> <span data-ttu-id="5e975-112">クエリ文字列とバッチであり、セッション クエリとは異なりは、ハンドルのクエリは、クエリ プロセッサ スタイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="5e975-112">Unlike session queries, which are string and batch queries, handle queries use a query-processor style.</span></span> <span data-ttu-id="5e975-113">最大 100 ハンドルがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="5e975-113">Up to 100 handles are supported.</span></span>  
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5e975-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5e975-114">URI parameters</span></span>
 
<span data-ttu-id="5e975-115">なし</span><span class="sxs-lookup"><span data-stu-id="5e975-115">None</span></span>   
<a id="ID4EEB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="5e975-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5e975-116">Valid methods</span></span>

[<span data-ttu-id="5e975-117">POST (/handles/query)</span><span class="sxs-lookup"><span data-stu-id="5e975-117">POST (/handles/query)</span></span>](uri-handlesquerypost.md)

<span data-ttu-id="5e975-118">&nbsp;&nbsp;セッション ハンドルに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="5e975-118">&nbsp;&nbsp;Creates queries for session handles.</span></span>

[<span data-ttu-id="5e975-119">POST (/handles/query?include=relatedInfo)</span><span class="sxs-lookup"><span data-stu-id="5e975-119">POST (/handles/query?include=relatedInfo)</span></span>](uri-handlesqueryincludepost.md)

<span data-ttu-id="5e975-120">&nbsp;&nbsp;関連するセッションの情報が含まれるセッション ハンドルに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="5e975-120">&nbsp;&nbsp;Creates queries for session handles that include related session information.</span></span>
 
<a id="ID4EQB"></a>

 
## <a name="see-also"></a><span data-ttu-id="5e975-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="5e975-121">See also</span></span>
 
<a id="ID4ESB"></a>

 
##### <a name="parent"></a><span data-ttu-id="5e975-122">Parent</span><span class="sxs-lookup"><span data-stu-id="5e975-122">Parent</span></span> 

[<span data-ttu-id="5e975-123">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="5e975-123">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   