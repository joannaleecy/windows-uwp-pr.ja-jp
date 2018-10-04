---
title: POST (/users/batch/profile/settings)
assetID: 2a619148-a626-f413-bda1-a2790063075d
permalink: en-us/docs/xboxlive/rest/uri-usersbatchprofilesettingspost.html
author: KevinAsgari
description: " POST (/users/batch/profile/settings)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 66d32e448f7db8558ea6ef02714b6112e230e711
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4354970"
---
# <a name="post-usersbatchprofilesettings"></a><span data-ttu-id="3c258-104">POST (/users/batch/profile/settings)</span><span class="sxs-lookup"><span data-stu-id="3c258-104">POST (/users/batch/profile/settings)</span></span>
<span data-ttu-id="3c258-105">ユーザーまたはユーザーのプロファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="3c258-105">Get the profile for a user or users.</span></span> <span data-ttu-id="3c258-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3c258-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3c258-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3c258-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="3c258-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="3c258-108">Authorization</span></span>](#ID4EFB)
  * [<span data-ttu-id="3c258-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3c258-109">Required Request Headers</span></span>](#ID4EOB)
  * [<span data-ttu-id="3c258-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="3c258-110">Request body</span></span>](#ID4EZC)
  * [<span data-ttu-id="3c258-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="3c258-111">Response body</span></span>](#ID4EJD)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="3c258-112">注釈</span><span class="sxs-lookup"><span data-stu-id="3c258-112">Remarks</span></span>
 
<span data-ttu-id="3c258-113">これは、URL では、のみ完全に修飾されたプロファイルで許可されています。</span><span class="sxs-lookup"><span data-stu-id="3c258-113">This is the only fully-qualified Profile URL allowed in .</span></span> <span data-ttu-id="3c258-114">クライアントからその他のすべてのプロファイル Api がブロックされます。</span><span class="sxs-lookup"><span data-stu-id="3c258-114">All other Profile APIs from clients are blocked.</span></span>
  
<a id="ID4EFB"></a>

 
## <a name="authorization"></a><span data-ttu-id="3c258-115">Authorization</span><span class="sxs-lookup"><span data-stu-id="3c258-115">Authorization</span></span>
 
<span data-ttu-id="3c258-116">プロファイルにアクセスするには、通常の認証トークンと要求のみが必要です。</span><span class="sxs-lookup"><span data-stu-id="3c258-116">To access a profile, only a normal auth token and claims are needed.</span></span>
  
<a id="ID4EOB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="3c258-117">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3c258-117">Required Request Headers</span></span>
 
| <span data-ttu-id="3c258-118">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3c258-118">Header</span></span>| <span data-ttu-id="3c258-119">型</span><span class="sxs-lookup"><span data-stu-id="3c258-119">Type</span></span>| <span data-ttu-id="3c258-120">説明</span><span class="sxs-lookup"><span data-stu-id="3c258-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3c258-121">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="3c258-121">x-xbl-contract-version</span></span>| <span data-ttu-id="3c258-122">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3c258-122">32-bit unsigned integer</span></span>| <span data-ttu-id="3c258-123">コントラクト バージョンは、Xbox 360 の API 呼び出しは、このを区別するために 2 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c258-123">The contract version must be set to 2, to distinguish this call from the Xbox 360 API.</span></span>| 
| <span data-ttu-id="3c258-124">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="3c258-124">content-type</span></span>| <span data-ttu-id="3c258-125">string</span><span class="sxs-lookup"><span data-stu-id="3c258-125">string</span></span>| <span data-ttu-id="3c258-126">値 =</span><span class="sxs-lookup"><span data-stu-id="3c258-126">Value =</span></span> <code>application/json</code>| 
  
<a id="ID4EZC"></a>

 
## <a name="request-body"></a><span data-ttu-id="3c258-127">要求本文</span><span class="sxs-lookup"><span data-stu-id="3c258-127">Request body</span></span>
 
<a id="ID4E6C"></a>

 
### <a name="sample-request"></a><span data-ttu-id="3c258-128">要求の例</span><span class="sxs-lookup"><span data-stu-id="3c258-128">Sample request</span></span>
 

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

 
## <a name="response-body"></a><span data-ttu-id="3c258-129">応答本文</span><span class="sxs-lookup"><span data-stu-id="3c258-129">Response body</span></span>
 
<a id="ID4EPD"></a>

 
### <a name="sample-response"></a><span data-ttu-id="3c258-130">応答の例</span><span class="sxs-lookup"><span data-stu-id="3c258-130">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3c258-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="3c258-131">See also</span></span>
 
<a id="ID4E2D"></a>

 
##### <a name="parent"></a><span data-ttu-id="3c258-132">Parent</span><span class="sxs-lookup"><span data-stu-id="3c258-132">Parent</span></span> 

[<span data-ttu-id="3c258-133">/users/batch/profile/settings</span><span class="sxs-lookup"><span data-stu-id="3c258-133">/users/batch/profile/settings</span></span>](uri-usersbatchprofilesettings.md)

  
<a id="ID4EFE"></a>

 
##### <a name="reference"></a><span data-ttu-id="3c258-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="3c258-134">Reference</span></span> 

[<span data-ttu-id="3c258-135">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="3c258-135">Profile (JSON)</span></span>](../../json/json-profile.md)

   