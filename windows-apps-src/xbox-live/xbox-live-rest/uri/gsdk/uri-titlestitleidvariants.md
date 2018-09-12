---
title: /titles/{titleId}/バリエーション
assetID: bca30c8f-1f09-729f-4955-38b7809404eb
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidvariants.html
author: KevinAsgari
description: " /titles/{titleId}/バリエーション"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9a11cf42c068883368db159e5cf679e4f38755ec
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882069"
---
# <a name="titlestitleidvariants"></a><span data-ttu-id="a486e-104">/titles/{titleId}/バリエーション</span><span class="sxs-lookup"><span data-stu-id="a486e-104">/titles/{titleId}/variants</span></span>
<span data-ttu-id="a486e-105">URI は、タイトルの利用可能な言語バリアントを取得するクライアントによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="a486e-105">URI called by a client to get the available variants for a title.</span></span> <span data-ttu-id="a486e-106">これらの Uri のドメイン`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a486e-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a486e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a486e-107">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="a486e-108">ホスト名</span><span class="sxs-lookup"><span data-stu-id="a486e-108">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="a486e-109">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a486e-109">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a486e-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a486e-110">URI Parameters</span></span>
 
| <span data-ttu-id="a486e-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a486e-111">Parameter</span></span>| <span data-ttu-id="a486e-112">説明</span><span class="sxs-lookup"><span data-stu-id="a486e-112">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="a486e-113">タイトル id</span><span class="sxs-lookup"><span data-stu-id="a486e-113">titleid</span></span>| <span data-ttu-id="a486e-114">要求の操作をタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="a486e-114">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="a486e-115">ホスト名</span><span class="sxs-lookup"><span data-stu-id="a486e-115">Host Name</span></span>
 
<span data-ttu-id="a486e-116">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="a486e-116">gameserverds.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a486e-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a486e-117">Valid Methods</span></span>
  
[<span data-ttu-id="a486e-118">POST</span><span class="sxs-lookup"><span data-stu-id="a486e-118">POST</span></span>](uri-titlestitleidvariants-post.md)
 
<span data-ttu-id="a486e-119">&nbsp;&nbsp;指定されたタイトル id。 用のバリアントをゲームの一覧を取得するクライアントによって呼び出される URI</span><span class="sxs-lookup"><span data-stu-id="a486e-119">&nbsp;&nbsp;URI called by a client that retrieves a list of game variants for the specified title Id.</span></span>
   