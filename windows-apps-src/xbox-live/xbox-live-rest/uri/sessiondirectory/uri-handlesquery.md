---
title: /handles/query
assetID: e00d31ad-b9ba-8e52-1333-83192eab0446
permalink: en-us/docs/xboxlive/rest/uri-handlesquery.html
author: KevinAsgari
description: " /handles/query"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fbb8a823581f357e42cd13bb1331808584301f5e
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4017987"
---
# <a name="handlesquery"></a><span data-ttu-id="14064-104">/handles/query</span><span class="sxs-lookup"><span data-stu-id="14064-104">/handles/query</span></span>
<span data-ttu-id="14064-105">セッション ハンドルのクエリを作成する POST 操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="14064-105">Supports POST operations to create queries for session handles.</span></span> 

> [!NOTE] 
> <span data-ttu-id="14064-106">この URI は、2015年マルチプレイヤーで使用し、そのマルチプレイヤーのバージョンにのみとを適用します。</span><span class="sxs-lookup"><span data-stu-id="14064-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="14064-107">テンプレート コントラクト 104/105 以降で使用されます。</span><span class="sxs-lookup"><span data-stu-id="14064-107">It is intended for use with template contract 104/105 or later.</span></span>  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a><span data-ttu-id="14064-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="14064-108">Domain</span></span>
<span data-ttu-id="14064-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="14064-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="14064-110">注釈</span><span class="sxs-lookup"><span data-stu-id="14064-110">Remarks</span></span>
<span data-ttu-id="14064-111">この URI は、ハンドルのクエリをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="14064-111">This URI supports queries for handles.</span></span> <span data-ttu-id="14064-112">セッションのクエリ文字列とバッチのクエリであるとは異なり、ハンドルのクエリはクエリ プロセッサ スタイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="14064-112">Unlike session queries, which are string and batch queries, handle queries use a query-processor style.</span></span> <span data-ttu-id="14064-113">最大 100 ハンドルがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="14064-113">Up to 100 handles are supported.</span></span>  
<a id="ID4E2"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="14064-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="14064-114">URI parameters</span></span>
 
<span data-ttu-id="14064-115">なし</span><span class="sxs-lookup"><span data-stu-id="14064-115">None</span></span>   
<a id="ID4EEB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="14064-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="14064-116">Valid methods</span></span>

[<span data-ttu-id="14064-117">POST (/handles/query)</span><span class="sxs-lookup"><span data-stu-id="14064-117">POST (/handles/query)</span></span>](uri-handlesquerypost.md)

<span data-ttu-id="14064-118">&nbsp;&nbsp;セッション ハンドルに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="14064-118">&nbsp;&nbsp;Creates queries for session handles.</span></span>

[<span data-ttu-id="14064-119">POST (/handles/query?include=relatedInfo)</span><span class="sxs-lookup"><span data-stu-id="14064-119">POST (/handles/query?include=relatedInfo)</span></span>](uri-handlesqueryincludepost.md)

<span data-ttu-id="14064-120">&nbsp;&nbsp;関連するセッションの情報が含まれるセッション ハンドルに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="14064-120">&nbsp;&nbsp;Creates queries for session handles that include related session information.</span></span>
 
<a id="ID4EQB"></a>

 
## <a name="see-also"></a><span data-ttu-id="14064-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="14064-121">See also</span></span>
 
<a id="ID4ESB"></a>

 
##### <a name="parent"></a><span data-ttu-id="14064-122">Parent</span><span class="sxs-lookup"><span data-stu-id="14064-122">Parent</span></span> 

[<span data-ttu-id="14064-123">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="14064-123">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   