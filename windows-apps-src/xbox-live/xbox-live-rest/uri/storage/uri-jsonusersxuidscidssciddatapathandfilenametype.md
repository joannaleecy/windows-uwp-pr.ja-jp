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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57614027"
---
# <a name="jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="95098-104">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="95098-104">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>
<span data-ttu-id="95098-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="95098-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="95098-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="95098-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="95098-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="95098-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="95098-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="95098-108">URI parameters</span></span>
 
| <span data-ttu-id="95098-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="95098-109">Parameter</span></span>| <span data-ttu-id="95098-110">種類</span><span class="sxs-lookup"><span data-stu-id="95098-110">Type</span></span>| <span data-ttu-id="95098-111">説明</span><span class="sxs-lookup"><span data-stu-id="95098-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="95098-112">xuid</span><span class="sxs-lookup"><span data-stu-id="95098-112">xuid</span></span>| <span data-ttu-id="95098-113">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="95098-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="95098-114">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="95098-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="95098-115">scid</span><span class="sxs-lookup"><span data-stu-id="95098-115">scid</span></span>| <span data-ttu-id="95098-116">guid</span><span class="sxs-lookup"><span data-stu-id="95098-116">guid</span></span>| <span data-ttu-id="95098-117">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="95098-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="95098-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="95098-118">pathAndFileName</span></span>| <span data-ttu-id="95098-119">string</span><span class="sxs-lookup"><span data-stu-id="95098-119">string</span></span>| <span data-ttu-id="95098-120">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="95098-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="95098-121">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="95098-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="95098-122">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="95098-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="95098-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="95098-123">Valid methods</span></span>

[<span data-ttu-id="95098-124">DELETE</span><span class="sxs-lookup"><span data-stu-id="95098-124">DELETE</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="95098-125">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="95098-125">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="95098-126">取得</span><span class="sxs-lookup"><span data-stu-id="95098-126">GET</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="95098-127">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="95098-127">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="95098-128">PUT</span><span class="sxs-lookup"><span data-stu-id="95098-128">PUT</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="95098-129">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="95098-129">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="95098-130">データ型の json は、複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="95098-130">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="95098-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="95098-131">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="95098-132">Parent</span><span class="sxs-lookup"><span data-stu-id="95098-132">Parent</span></span> 

[<span data-ttu-id="95098-133">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="95098-133">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   