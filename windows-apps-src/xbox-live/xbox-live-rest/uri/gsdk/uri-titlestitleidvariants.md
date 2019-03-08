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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658547"
---
# <a name="titlestitleidvariants"></a><span data-ttu-id="1acff-104">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="1acff-104">/titles/{titleId}/variants</span></span>
<span data-ttu-id="1acff-105">タイトルの使用可能なバリエーションを取得するクライアントから呼び出す URI。</span><span class="sxs-lookup"><span data-stu-id="1acff-105">URI called by a client to get the available variants for a title.</span></span> <span data-ttu-id="1acff-106">これらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="1acff-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="1acff-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1acff-107">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="1acff-108">ホスト名</span><span class="sxs-lookup"><span data-stu-id="1acff-108">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="1acff-109">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="1acff-109">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="1acff-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1acff-110">URI Parameters</span></span>
 
| <span data-ttu-id="1acff-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1acff-111">Parameter</span></span>| <span data-ttu-id="1acff-112">説明</span><span class="sxs-lookup"><span data-stu-id="1acff-112">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="1acff-113">タイトル id</span><span class="sxs-lookup"><span data-stu-id="1acff-113">titleid</span></span>| <span data-ttu-id="1acff-114">要求の操作対象のタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="1acff-114">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="1acff-115">ホスト名</span><span class="sxs-lookup"><span data-stu-id="1acff-115">Host Name</span></span>
 
<span data-ttu-id="1acff-116">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="1acff-116">gameserverds.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="1acff-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="1acff-117">Valid Methods</span></span>
  
[<span data-ttu-id="1acff-118">投稿</span><span class="sxs-lookup"><span data-stu-id="1acff-118">POST</span></span>](uri-titlestitleidvariants-post.md)
 
<span data-ttu-id="1acff-119">&nbsp;&nbsp;URI の id。 指定したタイトルのゲームのバリアントのリストを取得するクライアントによって呼び出されます</span><span class="sxs-lookup"><span data-stu-id="1acff-119">&nbsp;&nbsp;URI called by a client that retrieves a list of game variants for the specified title Id.</span></span>
   