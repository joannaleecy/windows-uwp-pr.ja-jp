---
title: GET (/users/{userId}/profile/settings/people/{userList})
assetID: f6553499-89e2-f21b-a00f-7e5437c045ff
permalink: en-us/docs/xboxlive/rest/uri-usersuseridprofilesettingspeopleuserlistget.html
description: " GET (/users/{userId}/profile/settings/people/{userList})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f868fdf4f3d5cd36000784d9c5a3437fa5d67ffa
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8326735"
---
# <a name="get-usersuseridprofilesettingspeopleuserlist"></a><span data-ttu-id="d11d0-104">GET (/users/{userId}/profile/settings/people/{userList})</span><span class="sxs-lookup"><span data-stu-id="d11d0-104">GET (/users/{userId}/profile/settings/people/{userList})</span></span>
<span data-ttu-id="d11d0-105">ユーザーのプロファイルを取得またはユーザー, People モニカーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="d11d0-105">Get the profile for a user or users, with People Moniker support.</span></span> <span data-ttu-id="d11d0-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d11d0-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d11d0-107">注釈</span><span class="sxs-lookup"><span data-stu-id="d11d0-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="d11d0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d11d0-108">URI parameters</span></span>](#ID4EKB)
  * [<span data-ttu-id="d11d0-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="d11d0-109">Query string parameters</span></span>](#ID4EVB)
  * [<span data-ttu-id="d11d0-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d11d0-110">Required Request Headers</span></span>](#ID4EQC)
  * [<span data-ttu-id="d11d0-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="d11d0-111">Request body</span></span>](#ID4E2D)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="d11d0-112">注釈</span><span class="sxs-lookup"><span data-stu-id="d11d0-112">Remarks</span></span>
 
<span data-ttu-id="d11d0-113">**userList**と**ユーザー Id**は、相互に排他的なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="d11d0-113">**userList** and **userIds** are mutually-exclusive parameters.</span></span> <span data-ttu-id="d11d0-114">いずれかまたは両方が指定されている場合は、 **BadRequest**をもう一度表示されます。</span><span class="sxs-lookup"><span data-stu-id="d11d0-114">If both or either are specified, you'll get a **BadRequest** back.</span></span> <span data-ttu-id="d11d0-115">**userList**は、複数の名前付きリストが要求に便利なシナリオで将来の配列です。</span><span class="sxs-lookup"><span data-stu-id="d11d0-115">**userList** is an array for future-proofing in scenarios where multiple named lists are useful to request.</span></span> <span data-ttu-id="d11d0-116">**ユーザー Id**が Xuid の 10 進数の文字列の構成 - JSON は 64 ビットの符号なし整数のシリアル化に悪いです。</span><span class="sxs-lookup"><span data-stu-id="d11d0-116">**userIds** is composed of decimal strings for XUIDs - JSON is bad at serializing 64-bit unsigned integers.</span></span> <span data-ttu-id="d11d0-117">最後に、Xbox One での設定の名前は、通常のわかりやすい名前ではなく 64 ビットの符号なし整数またはあいまいな定数**XONLINE_PROFILE_ASDF**などの設定になります。</span><span class="sxs-lookup"><span data-stu-id="d11d0-117">Finally, settings in Xbox One will be named settings, with normal human-readable names, rather than 64-bit unsigned integers or obscure constants like **XONLINE_PROFILE_ASDF**.</span></span>
  
<a id="ID4EKB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d11d0-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d11d0-118">URI parameters</span></span>
 
| <span data-ttu-id="d11d0-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d11d0-119">Parameter</span></span>| <span data-ttu-id="d11d0-120">型</span><span class="sxs-lookup"><span data-stu-id="d11d0-120">Type</span></span>| <span data-ttu-id="d11d0-121">説明</span><span class="sxs-lookup"><span data-stu-id="d11d0-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d11d0-122">ユーザー Id</span><span class="sxs-lookup"><span data-stu-id="d11d0-122">userId</span></span>| <span data-ttu-id="d11d0-123">string</span><span class="sxs-lookup"><span data-stu-id="d11d0-123">string</span></span>| <span data-ttu-id="d11d0-124">'Xuid(12345)'、'gt(myGamertag)' の 'me' またはいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="d11d0-124">Can be either 'xuid(12345)', 'gt(myGamertag)', or 'me'.</span></span>| 
| <span data-ttu-id="d11d0-125">userList</span><span class="sxs-lookup"><span data-stu-id="d11d0-125">userList</span></span>| <span data-ttu-id="d11d0-126">string</span><span class="sxs-lookup"><span data-stu-id="d11d0-126">string</span></span>| <span data-ttu-id="d11d0-127">名前付きの設定を取得するユーザーの一覧。</span><span class="sxs-lookup"><span data-stu-id="d11d0-127">A named list of people to get settings for.</span></span> <span data-ttu-id="d11d0-128">現時点では、ユーザーは、サポートされている唯一の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="d11d0-128">Currently, People is the only list supported.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="d11d0-129">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="d11d0-129">Query string parameters</span></span>
 
| <span data-ttu-id="d11d0-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d11d0-130">Parameter</span></span>| <span data-ttu-id="d11d0-131">型</span><span class="sxs-lookup"><span data-stu-id="d11d0-131">Type</span></span>| <span data-ttu-id="d11d0-132">説明</span><span class="sxs-lookup"><span data-stu-id="d11d0-132">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d11d0-133">settings</span><span class="sxs-lookup"><span data-stu-id="d11d0-133">settings</span></span>| <span data-ttu-id="d11d0-134">string</span><span class="sxs-lookup"><span data-stu-id="d11d0-134">string</span></span>| <span data-ttu-id="d11d0-135">設定名のコンマ区切りの一覧。</span><span class="sxs-lookup"><span data-stu-id="d11d0-135">A comma-delimited list of setting names.</span></span>| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="d11d0-136">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d11d0-136">Required Request Headers</span></span>
 
| <span data-ttu-id="d11d0-137">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d11d0-137">Header</span></span>| <span data-ttu-id="d11d0-138">型</span><span class="sxs-lookup"><span data-stu-id="d11d0-138">Type</span></span>| <span data-ttu-id="d11d0-139">説明</span><span class="sxs-lookup"><span data-stu-id="d11d0-139">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d11d0-140">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="d11d0-140">x-xbl-contract-version</span></span>| <span data-ttu-id="d11d0-141">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="d11d0-141">32-bit signed integer</span></span>| <span data-ttu-id="d11d0-142">値 = 2</span><span class="sxs-lookup"><span data-stu-id="d11d0-142">Value = 2</span></span>| 
| <span data-ttu-id="d11d0-143">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="d11d0-143">content-type</span></span>| <span data-ttu-id="d11d0-144">string</span><span class="sxs-lookup"><span data-stu-id="d11d0-144">string</span></span>| <span data-ttu-id="d11d0-145">値 =</span><span class="sxs-lookup"><span data-stu-id="d11d0-145">Value =</span></span> <code>application/json</code>| 
  
<a id="ID4E2D"></a>

 
## <a name="request-body"></a><span data-ttu-id="d11d0-146">要求本文</span><span class="sxs-lookup"><span data-stu-id="d11d0-146">Request body</span></span>
 
<a id="ID4EBE"></a>

 
### <a name="sample-request"></a><span data-ttu-id="d11d0-147">要求の例</span><span class="sxs-lookup"><span data-stu-id="d11d0-147">Sample request</span></span>
 

```cpp
GET /users/me/profile/settings/people/people?settings=GameDisplayName,GameDisplayPicRaw,Gamerscore,Gamertag
      
```

  
<a id="ID4EKE"></a>

  
 
<a id="ID4EME"></a>

 
##### <a name="response-body"></a><span data-ttu-id="d11d0-148">応答本文</span><span class="sxs-lookup"><span data-stu-id="d11d0-148">Response body</span></span> 
<span data-ttu-id="d11d0-149">応答は、 **ReadMultiSettingsResponseV2**オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="d11d0-149">The response is a **ReadMultiSettingsResponseV2** object.</span></span> <span data-ttu-id="d11d0-150">呼び出し元のユーザーと仮定すると、1 つだけのフレンドがあります。</span><span class="sxs-lookup"><span data-stu-id="d11d0-150">Assuming the calling user has only one friend:</span></span>
  

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
                  "value":"http://images-eds.xboxlive.com/image?url=z951ykn43p4FqWbbFvR2Ec.8vbDhj8G2Xe7JngaTToBrrCmIEEXHC9UNrdJ6P7KIN0gxC2r1YECCd3mf2w1FDdmFCpSokJWa2z7xtVrlzOyVSc6pPRdWEXmYtpS2xE4F&format=png&w=64&h=64"
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

   
<a id="ID4E3E"></a>

 
## <a name="see-also"></a><span data-ttu-id="d11d0-151">関連項目</span><span class="sxs-lookup"><span data-stu-id="d11d0-151">See also</span></span>
 
<a id="ID4E5E"></a>

 
##### <a name="parent"></a><span data-ttu-id="d11d0-152">Parent</span><span class="sxs-lookup"><span data-stu-id="d11d0-152">Parent</span></span> 

[<span data-ttu-id="d11d0-153">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span><span class="sxs-lookup"><span data-stu-id="d11d0-153">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span></span>](uri-usersuseridprofilesettingspeopleuserlist.md)

 [<span data-ttu-id="d11d0-154">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="d11d0-154">Profile (JSON)</span></span>](../../json/json-profile.md)

   