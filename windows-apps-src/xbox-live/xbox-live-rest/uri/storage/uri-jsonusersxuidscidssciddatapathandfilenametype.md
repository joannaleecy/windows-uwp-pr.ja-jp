---
title: /json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json
assetID: d004d715-d73c-693e-2a0b-ce64f482642b
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype.html
description: " /json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ee2f21426f0fad1cdb84adba864aeebd0d8e1edc
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8936771"
---
# <a name="jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="03eee-104">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="03eee-104">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>
<span data-ttu-id="03eee-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="03eee-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="03eee-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="03eee-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="03eee-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03eee-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="03eee-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03eee-108">URI parameters</span></span>
 
| <span data-ttu-id="03eee-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="03eee-109">Parameter</span></span>| <span data-ttu-id="03eee-110">型</span><span class="sxs-lookup"><span data-stu-id="03eee-110">Type</span></span>| <span data-ttu-id="03eee-111">説明</span><span class="sxs-lookup"><span data-stu-id="03eee-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="03eee-112">xuid</span><span class="sxs-lookup"><span data-stu-id="03eee-112">xuid</span></span>| <span data-ttu-id="03eee-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="03eee-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="03eee-114">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="03eee-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="03eee-115">scid</span><span class="sxs-lookup"><span data-stu-id="03eee-115">scid</span></span>| <span data-ttu-id="03eee-116">guid</span><span class="sxs-lookup"><span data-stu-id="03eee-116">guid</span></span>| <span data-ttu-id="03eee-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="03eee-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="03eee-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="03eee-118">pathAndFileName</span></span>| <span data-ttu-id="03eee-119">string</span><span class="sxs-lookup"><span data-stu-id="03eee-119">string</span></span>| <span data-ttu-id="03eee-120">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="03eee-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="03eee-121">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="03eee-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="03eee-122">ファイル名を空にすることがありますはいない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="03eee-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="03eee-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="03eee-123">Valid methods</span></span>

[<span data-ttu-id="03eee-124">DELETE</span><span class="sxs-lookup"><span data-stu-id="03eee-124">DELETE</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="03eee-125">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="03eee-125">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="03eee-126">GET</span><span class="sxs-lookup"><span data-stu-id="03eee-126">GET</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="03eee-127">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="03eee-127">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="03eee-128">PUT</span><span class="sxs-lookup"><span data-stu-id="03eee-128">PUT</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="03eee-129">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="03eee-129">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="03eee-130">Json の種類のデータの複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="03eee-130">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="03eee-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="03eee-131">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="03eee-132">Parent</span><span class="sxs-lookup"><span data-stu-id="03eee-132">Parent</span></span> 

[<span data-ttu-id="03eee-133">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="03eee-133">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   