---
title: /titles/{titleId}/variants
assetID: bca30c8f-1f09-729f-4955-38b7809404eb
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidvariants.html
description: " /titles/{titleId}/variants"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a0a0df14b442babec363dfebc96a0c33935563e
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8730117"
---
# <a name="titlestitleidvariants"></a><span data-ttu-id="47db7-104">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="47db7-104">/titles/{titleId}/variants</span></span>
<span data-ttu-id="47db7-105">URI は、タイトルの利用可能な言語バリアントを取得するのには、クライアントによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="47db7-105">URI called by a client to get the available variants for a title.</span></span> <span data-ttu-id="47db7-106">これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="47db7-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="47db7-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="47db7-107">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="47db7-108">ホスト名</span><span class="sxs-lookup"><span data-stu-id="47db7-108">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="47db7-109">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="47db7-109">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="47db7-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="47db7-110">URI Parameters</span></span>
 
| <span data-ttu-id="47db7-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="47db7-111">Parameter</span></span>| <span data-ttu-id="47db7-112">説明</span><span class="sxs-lookup"><span data-stu-id="47db7-112">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="47db7-113">タイトル id</span><span class="sxs-lookup"><span data-stu-id="47db7-113">titleid</span></span>| <span data-ttu-id="47db7-114">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="47db7-114">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="47db7-115">ホスト名</span><span class="sxs-lookup"><span data-stu-id="47db7-115">Host Name</span></span>
 
<span data-ttu-id="47db7-116">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="47db7-116">gameserverds.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="47db7-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="47db7-117">Valid Methods</span></span>
  
[<span data-ttu-id="47db7-118">POST</span><span class="sxs-lookup"><span data-stu-id="47db7-118">POST</span></span>](uri-titlestitleidvariants-post.md)
 
<span data-ttu-id="47db7-119">&nbsp;&nbsp;指定されたタイトル id。 用のバリアントをゲームの一覧を取得するクライアントによって呼び出される URI</span><span class="sxs-lookup"><span data-stu-id="47db7-119">&nbsp;&nbsp;URI called by a client that retrieves a list of game variants for the specified title Id.</span></span>
   