---
title: POST (/users/batch/profile/settings)
assetID: 2a619148-a626-f413-bda1-a2790063075d
permalink: en-us/docs/xboxlive/rest/uri-usersbatchprofilesettingspost.html
author: KevinAsgari
description: " POST (/users/batch/profile/settings)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b947bf1d9897416623472e078bc49e9ea9df164d
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5934583"
---
# <a name="post-usersbatchprofilesettings"></a><span data-ttu-id="6175f-104">POST (/users/batch/profile/settings)</span><span class="sxs-lookup"><span data-stu-id="6175f-104">POST (/users/batch/profile/settings)</span></span>
<span data-ttu-id="6175f-105">ユーザーまたはユーザーのプロファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="6175f-105">Get the profile for a user or users.</span></span> <span data-ttu-id="6175f-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6175f-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6175f-107">注釈</span><span class="sxs-lookup"><span data-stu-id="6175f-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="6175f-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="6175f-108">Authorization</span></span>](#ID4EFB)
  * [<span data-ttu-id="6175f-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6175f-109">Required Request Headers</span></span>](#ID4EOB)
  * [<span data-ttu-id="6175f-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="6175f-110">Request body</span></span>](#ID4EZC)
  * [<span data-ttu-id="6175f-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="6175f-111">Response body</span></span>](#ID4EJD)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="6175f-112">注釈</span><span class="sxs-lookup"><span data-stu-id="6175f-112">Remarks</span></span>
 
<span data-ttu-id="6175f-113">これで許可されているのみ完全修飾プロファイル URL です。</span><span class="sxs-lookup"><span data-stu-id="6175f-113">This is the only fully-qualified Profile URL allowed in .</span></span> <span data-ttu-id="6175f-114">クライアントからその他のすべてのプロファイル Api がブロックされます。</span><span class="sxs-lookup"><span data-stu-id="6175f-114">All other Profile APIs from clients are blocked.</span></span>
  
<a id="ID4EFB"></a>

 
## <a name="authorization"></a><span data-ttu-id="6175f-115">Authorization</span><span class="sxs-lookup"><span data-stu-id="6175f-115">Authorization</span></span>
 
<span data-ttu-id="6175f-116">プロファイルにアクセスするに通常の認証トークンと要求のみが必要です。</span><span class="sxs-lookup"><span data-stu-id="6175f-116">To access a profile, only a normal auth token and claims are needed.</span></span>
  
<a id="ID4EOB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="6175f-117">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6175f-117">Required Request Headers</span></span>
 
| <span data-ttu-id="6175f-118">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6175f-118">Header</span></span>| <span data-ttu-id="6175f-119">型</span><span class="sxs-lookup"><span data-stu-id="6175f-119">Type</span></span>| <span data-ttu-id="6175f-120">説明</span><span class="sxs-lookup"><span data-stu-id="6175f-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6175f-121">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="6175f-121">x-xbl-contract-version</span></span>| <span data-ttu-id="6175f-122">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6175f-122">32-bit unsigned integer</span></span>| <span data-ttu-id="6175f-123">コントラクト バージョンは、Xbox 360 の API 呼び出しは、このを区別するために 2 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6175f-123">The contract version must be set to 2, to distinguish this call from the Xbox 360 API.</span></span>| 
| <span data-ttu-id="6175f-124">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="6175f-124">content-type</span></span>| <span data-ttu-id="6175f-125">string</span><span class="sxs-lookup"><span data-stu-id="6175f-125">string</span></span>| <span data-ttu-id="6175f-126">値 =</span><span class="sxs-lookup"><span data-stu-id="6175f-126">Value =</span></span> <code>application/json</code>| 
  
<a id="ID4EZC"></a>

 
## <a name="request-body"></a><span data-ttu-id="6175f-127">要求本文</span><span class="sxs-lookup"><span data-stu-id="6175f-127">Request body</span></span>
 
<a id="ID4E6C"></a>

 
### <a name="sample-request"></a><span data-ttu-id="6175f-128">要求の例</span><span class="sxs-lookup"><span data-stu-id="6175f-128">Sample request</span></span>
 

```cpp
POST /users/batch/profile/settings
   {
      "userIds":[
         "2533274791381930"
       ],
      "settings":[
         "GameDisplayName",
         "GameDisplayPicRaw",
         "Gamerscore",
         "Gamertag"
      ]
   }
      
```

   
<a id="ID4EJD"></a>

 
## <a name="response-body"></a><span data-ttu-id="6175f-129">応答本文</span><span class="sxs-lookup"><span data-stu-id="6175f-129">Response body</span></span>
 
<a id="ID4EPD"></a>

 
### <a name="sample-response"></a><span data-ttu-id="6175f-130">応答の例</span><span class="sxs-lookup"><span data-stu-id="6175f-130">Sample response</span></span>
 

```cpp
{
      "profileUsers":[
         {
            "id":"2533274791381930",
            "settings":[
               {
                  "id":"GameDisplayName",
                  "value":"John Smith"
               },
               {
                  "id":"GameDisplayPicRaw",
                  "value":"http://images-eds.xboxlive.com/image?url=z951ykn43p4FqWbbFvR2Ec.8vbDhj8G2Xe7JngaTToBrrCmIEEXHC9UNrdJ6P7KIN0gxC2r1YECCd3mf2w1FDdmFCpSokJWa2z7xtVrlzOyVSc6pPRdWEXmYtpS2xE4F"
               },
               {
                  "id":"Gamerscore",
                  "value":"0"
               },
               {
                  "id":"Gamertag",
                  "value":"CracklierJewel9"
               }
            ]
         }
      ]
   }
         
```

   
<a id="ID4EZD"></a>

 
## <a name="see-also"></a><span data-ttu-id="6175f-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="6175f-131">See also</span></span>
 
<a id="ID4E2D"></a>

 
##### <a name="parent"></a><span data-ttu-id="6175f-132">Parent</span><span class="sxs-lookup"><span data-stu-id="6175f-132">Parent</span></span> 

[<span data-ttu-id="6175f-133">/users/batch/profile/settings</span><span class="sxs-lookup"><span data-stu-id="6175f-133">/users/batch/profile/settings</span></span>](uri-usersbatchprofilesettings.md)

  
<a id="ID4EFE"></a>

 
##### <a name="reference"></a><span data-ttu-id="6175f-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="6175f-134">Reference</span></span> 

[<span data-ttu-id="6175f-135">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="6175f-135">Profile (JSON)</span></span>](../../json/json-profile.md)

   