---
title: TitleBlob (JSON)
assetID: fd1c904d-e8d0-f61f-e403-40b25bd4ac14
permalink: en-us/docs/xboxlive/rest/json-titleblob.html
description: " TitleBlob (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 51a0b17a46d1c71ffdf9098d4637ca59d840c90a
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8889944"
---
# <a name="titleblob-json"></a><span data-ttu-id="49d9d-104">TitleBlob (JSON)</span><span class="sxs-lookup"><span data-stu-id="49d9d-104">TitleBlob (JSON)</span></span>
<span data-ttu-id="49d9d-105">記憶域からのタイトルに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="49d9d-105">Contains information about a title from storage.</span></span> 
<a id="ID4EP"></a>

 
## <a name="titleblob"></a><span data-ttu-id="49d9d-106">TitleBlob</span><span class="sxs-lookup"><span data-stu-id="49d9d-106">TitleBlob</span></span>
 
<span data-ttu-id="49d9d-107">TitleBlob オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="49d9d-107">The TitleBlob object has the following specification.</span></span>
 
| <span data-ttu-id="49d9d-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="49d9d-108">Member</span></span>| <span data-ttu-id="49d9d-109">種類</span><span class="sxs-lookup"><span data-stu-id="49d9d-109">Type</span></span>| <span data-ttu-id="49d9d-110">説明</span><span class="sxs-lookup"><span data-stu-id="49d9d-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="49d9d-111">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="49d9d-111">clientFileTime</span></span>| <span data-ttu-id="49d9d-112">DateTime</span><span class="sxs-lookup"><span data-stu-id="49d9d-112">DateTime</span></span>| <span data-ttu-id="49d9d-113">[オプション]ファイルの最後のアップロードの日時。</span><span class="sxs-lookup"><span data-stu-id="49d9d-113">[optional] Date and time of the last upload of the file.</span></span>| 
| <span data-ttu-id="49d9d-114">displayName</span><span class="sxs-lookup"><span data-stu-id="49d9d-114">displayName</span></span>| <span data-ttu-id="49d9d-115">string</span><span class="sxs-lookup"><span data-stu-id="49d9d-115">string</span></span>| <span data-ttu-id="49d9d-116">[オプション]ユーザーに表示されているファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="49d9d-116">[optional] Name of the file that is shown to the user.</span></span>| 
| <span data-ttu-id="49d9d-117">etag</span><span class="sxs-lookup"><span data-stu-id="49d9d-117">etag</span></span>| <span data-ttu-id="49d9d-118">string</span><span class="sxs-lookup"><span data-stu-id="49d9d-118">string</span></span>| <span data-ttu-id="49d9d-119">タグで使用されるファイルをダウンロードして要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="49d9d-119">Tag for the file used in download and upload requests.</span></span>| 
| <span data-ttu-id="49d9d-120">fileName</span><span class="sxs-lookup"><span data-stu-id="49d9d-120">fileName</span></span>| <span data-ttu-id="49d9d-121">string</span><span class="sxs-lookup"><span data-stu-id="49d9d-121">string</span></span>| <span data-ttu-id="49d9d-122">ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="49d9d-122">Name of the file.</span></span>| 
| <span data-ttu-id="49d9d-123">size</span><span class="sxs-lookup"><span data-stu-id="49d9d-123">size</span></span>| <span data-ttu-id="49d9d-124">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="49d9d-124">64-bit signed integer</span></span>| <span data-ttu-id="49d9d-125">ファイルのバイトのサイズ。</span><span class="sxs-lookup"><span data-stu-id="49d9d-125">Size of the file in bytes.</span></span>| 
| <span data-ttu-id="49d9d-126">smartBlobType</span><span class="sxs-lookup"><span data-stu-id="49d9d-126">smartBlobType</span></span>| <span data-ttu-id="49d9d-127">string</span><span class="sxs-lookup"><span data-stu-id="49d9d-127">string</span></span>| <span data-ttu-id="49d9d-128">[オプション]データの種類です。</span><span class="sxs-lookup"><span data-stu-id="49d9d-128">[optional] Type of data.</span></span> <span data-ttu-id="49d9d-129">使用可能な値: config、json、バイナリ。</span><span class="sxs-lookup"><span data-stu-id="49d9d-129">Possible values are: config, json, binary.</span></span>| 
  
<a id="ID4E6C"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="49d9d-130">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="49d9d-130">Sample JSON syntax</span></span>
 

```json
{
    "fileName":"foo\bar\blob.txt,binary",
    "clientFileTime":"2012-01-01T01:02:03.1234567Z",
    "displayName":"Friendly Name",
    "size":12,
    "etag":"0x8CEB3E4F8F3A5BF",
    "smartBlobType":"binary"
}
      
```

  
<a id="ID4EID"></a>

 
## <a name="see-also"></a><span data-ttu-id="49d9d-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="49d9d-131">See also</span></span>
 
<a id="ID4EKD"></a>

 
##### <a name="parent"></a><span data-ttu-id="49d9d-132">Parent</span><span class="sxs-lookup"><span data-stu-id="49d9d-132">Parent</span></span> 

[<span data-ttu-id="49d9d-133">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="49d9d-133">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   