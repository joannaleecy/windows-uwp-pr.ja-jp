---
title: POST (/users/batch/profile/settings)
assetID: 2a619148-a626-f413-bda1-a2790063075d
permalink: en-us/docs/xboxlive/rest/uri-usersbatchprofilesettingspost.html
description: " POST (/users/batch/profile/settings)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0f859a58e32624223d59d918d46f6230a3abd6db
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662227"
---
# <a name="post-usersbatchprofilesettings"></a><span data-ttu-id="b8999-104">POST (/users/batch/profile/settings)</span><span class="sxs-lookup"><span data-stu-id="b8999-104">POST (/users/batch/profile/settings)</span></span>
<span data-ttu-id="b8999-105">ユーザーまたはユーザーのプロファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="b8999-105">Get the profile for a user or users.</span></span> <span data-ttu-id="b8999-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b8999-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b8999-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b8999-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="b8999-108">承認</span><span class="sxs-lookup"><span data-stu-id="b8999-108">Authorization</span></span>](#ID4EFB)
  * [<span data-ttu-id="b8999-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b8999-109">Required Request Headers</span></span>](#ID4EOB)
  * [<span data-ttu-id="b8999-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="b8999-110">Request body</span></span>](#ID4EZC)
  * [<span data-ttu-id="b8999-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="b8999-111">Response body</span></span>](#ID4EJD)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="b8999-112">注釈</span><span class="sxs-lookup"><span data-stu-id="b8999-112">Remarks</span></span>
 
<span data-ttu-id="b8999-113">許可されているのみ完全修飾のプロファイル URL です。</span><span class="sxs-lookup"><span data-stu-id="b8999-113">This is the only fully-qualified Profile URL allowed in .</span></span> <span data-ttu-id="b8999-114">クライアントからその他のすべてのプロファイル Api はブロックされます。</span><span class="sxs-lookup"><span data-stu-id="b8999-114">All other Profile APIs from clients are blocked.</span></span>
  
<a id="ID4EFB"></a>

 
## <a name="authorization"></a><span data-ttu-id="b8999-115">Authorization</span><span class="sxs-lookup"><span data-stu-id="b8999-115">Authorization</span></span>
 
<span data-ttu-id="b8999-116">プロファイルにアクセスするには、通常の認証トークンとクレームだけが必要です。</span><span class="sxs-lookup"><span data-stu-id="b8999-116">To access a profile, only a normal auth token and claims are needed.</span></span>
  
<a id="ID4EOB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="b8999-117">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b8999-117">Required Request Headers</span></span>
 
| <span data-ttu-id="b8999-118">Header</span><span class="sxs-lookup"><span data-stu-id="b8999-118">Header</span></span>| <span data-ttu-id="b8999-119">種類</span><span class="sxs-lookup"><span data-stu-id="b8999-119">Type</span></span>| <span data-ttu-id="b8999-120">説明</span><span class="sxs-lookup"><span data-stu-id="b8999-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b8999-121">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="b8999-121">x-xbl-contract-version</span></span>| <span data-ttu-id="b8999-122">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="b8999-122">32-bit unsigned integer</span></span>| <span data-ttu-id="b8999-123">コントラクトのバージョンは、Xbox 360 の API からのこの呼び出しを区別するために、2 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8999-123">The contract version must be set to 2, to distinguish this call from the Xbox 360 API.</span></span>| 
| <span data-ttu-id="b8999-124">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="b8999-124">content-type</span></span>| <span data-ttu-id="b8999-125">string</span><span class="sxs-lookup"><span data-stu-id="b8999-125">string</span></span>| <span data-ttu-id="b8999-126">値 = <code>application/json</code></span><span class="sxs-lookup"><span data-stu-id="b8999-126">Value = <code>application/json</code></span></span>| 
  
<a id="ID4EZC"></a>

 
## <a name="request-body"></a><span data-ttu-id="b8999-127">要求本文</span><span class="sxs-lookup"><span data-stu-id="b8999-127">Request body</span></span>
 
<a id="ID4E6C"></a>

 
### <a name="sample-request"></a><span data-ttu-id="b8999-128">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="b8999-128">Sample request</span></span>
 

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

 
## <a name="response-body"></a><span data-ttu-id="b8999-129">応答本文</span><span class="sxs-lookup"><span data-stu-id="b8999-129">Response body</span></span>
 
<a id="ID4EPD"></a>

 
### <a name="sample-response"></a><span data-ttu-id="b8999-130">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="b8999-130">Sample response</span></span>
 

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
                  "value":"https://images-eds.xboxlive.com/image?url=z951ykn43p4FqWbbFvR2Ec.8vbDhj8G2Xe7JngaTToBrrCmIEEXHC9UNrdJ6P7KIN0gxC2r1YECCd3mf2w1FDdmFCpSokJWa2z7xtVrlzOyVSc6pPRdWEXmYtpS2xE4F"
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

 
## <a name="see-also"></a><span data-ttu-id="b8999-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="b8999-131">See also</span></span>
 
<a id="ID4E2D"></a>

 
##### <a name="parent"></a><span data-ttu-id="b8999-132">Parent</span><span class="sxs-lookup"><span data-stu-id="b8999-132">Parent</span></span> 

[<span data-ttu-id="b8999-133">/users/batch/profile/settings</span><span class="sxs-lookup"><span data-stu-id="b8999-133">/users/batch/profile/settings</span></span>](uri-usersbatchprofilesettings.md)

  
<a id="ID4EFE"></a>

 
##### <a name="reference"></a><span data-ttu-id="b8999-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="b8999-134">Reference</span></span> 

[<span data-ttu-id="b8999-135">プロファイル (JSON)</span><span class="sxs-lookup"><span data-stu-id="b8999-135">Profile (JSON)</span></span>](../../json/json-profile.md)

   