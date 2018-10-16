---
title: /titles/{titleId}/variants
assetID: bca30c8f-1f09-729f-4955-38b7809404eb
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidvariants.html
author: KevinAsgari
description: " /titles/{titleId}/variants"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9a11cf42c068883368db159e5cf679e4f38755ec
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4621884"
---
# <a name="titlestitleidvariants"></a><span data-ttu-id="ba97f-104">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="ba97f-104">/titles/{titleId}/variants</span></span>
<span data-ttu-id="ba97f-105">URI は、タイトルの利用可能な言語バリアントを取得するクライアントによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="ba97f-105">URI called by a client to get the available variants for a title.</span></span> <span data-ttu-id="ba97f-106">これらの Uri のドメイン`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ba97f-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ba97f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ba97f-107">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="ba97f-108">ホスト名</span><span class="sxs-lookup"><span data-stu-id="ba97f-108">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="ba97f-109">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ba97f-109">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ba97f-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ba97f-110">URI Parameters</span></span>
 
| <span data-ttu-id="ba97f-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ba97f-111">Parameter</span></span>| <span data-ttu-id="ba97f-112">説明</span><span class="sxs-lookup"><span data-stu-id="ba97f-112">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="ba97f-113">タイトル id</span><span class="sxs-lookup"><span data-stu-id="ba97f-113">titleid</span></span>| <span data-ttu-id="ba97f-114">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="ba97f-114">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="ba97f-115">ホスト名</span><span class="sxs-lookup"><span data-stu-id="ba97f-115">Host Name</span></span>
 
<span data-ttu-id="ba97f-116">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="ba97f-116">gameserverds.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ba97f-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ba97f-117">Valid Methods</span></span>
  
[<span data-ttu-id="ba97f-118">POST</span><span class="sxs-lookup"><span data-stu-id="ba97f-118">POST</span></span>](uri-titlestitleidvariants-post.md)
 
<span data-ttu-id="ba97f-119">&nbsp;&nbsp;指定されたタイトル id。 用のバリアントをゲームの一覧を取得するクライアントによって呼び出される URI</span><span class="sxs-lookup"><span data-stu-id="ba97f-119">&nbsp;&nbsp;URI called by a client that retrieves a list of game variants for the specified title Id.</span></span>
   