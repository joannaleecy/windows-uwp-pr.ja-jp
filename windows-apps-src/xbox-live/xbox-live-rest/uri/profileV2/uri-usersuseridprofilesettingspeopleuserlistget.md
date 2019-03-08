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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593857"
---
# <a name="get-usersuseridprofilesettingspeopleuserlist"></a><span data-ttu-id="661b4-104">GET (/users/{userId}/profile/settings/people/{userList})</span><span class="sxs-lookup"><span data-stu-id="661b4-104">GET (/users/{userId}/profile/settings/people/{userList})</span></span>
<span data-ttu-id="661b4-105">ユーザーのプロファイルを取得またはユーザーのモニカーでのユーザーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="661b4-105">Get the profile for a user or users, with People Moniker support.</span></span> <span data-ttu-id="661b4-106">これらの Uri のドメインが`profile.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="661b4-106">The domain for these URIs is `profile.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="661b4-107">注釈</span><span class="sxs-lookup"><span data-stu-id="661b4-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="661b4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="661b4-108">URI parameters</span></span>](#ID4EKB)
  * [<span data-ttu-id="661b4-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="661b4-109">Query string parameters</span></span>](#ID4EVB)
  * [<span data-ttu-id="661b4-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="661b4-110">Required Request Headers</span></span>](#ID4EQC)
  * [<span data-ttu-id="661b4-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="661b4-111">Request body</span></span>](#ID4E2D)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="661b4-112">注釈</span><span class="sxs-lookup"><span data-stu-id="661b4-112">Remarks</span></span>
 
<span data-ttu-id="661b4-113">**userList**と**の userid と**は相互に排他的なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="661b4-113">**userList** and **userIds** are mutually-exclusive parameters.</span></span> <span data-ttu-id="661b4-114">両方またはいずれかが指定されている場合、られます、 **BadRequest**戻ります。</span><span class="sxs-lookup"><span data-stu-id="661b4-114">If both or either are specified, you'll get a **BadRequest** back.</span></span> <span data-ttu-id="661b4-115">**userList**は複数の名前付きリストが要求する便利なシナリオで将来の配列です。</span><span class="sxs-lookup"><span data-stu-id="661b4-115">**userList** is an array for future-proofing in scenarios where multiple named lists are useful to request.</span></span> <span data-ttu-id="661b4-116">**userid と**で構成されます - Xuid の 10 進数値の文字列の JSON は、64 ビット符号なし整数のシリアル化に正しくないです。</span><span class="sxs-lookup"><span data-stu-id="661b4-116">**userIds** is composed of decimal strings for XUIDs - JSON is bad at serializing 64-bit unsigned integers.</span></span> <span data-ttu-id="661b4-117">64 ビット符号なし整数またはあいまいな定数のようにするのではなく、最後に、Xbox One での設定の名前、設定は通常の人間が判読できる名前**XONLINE_PROFILE_ASDF**します。</span><span class="sxs-lookup"><span data-stu-id="661b4-117">Finally, settings in Xbox One will be named settings, with normal human-readable names, rather than 64-bit unsigned integers or obscure constants like **XONLINE_PROFILE_ASDF**.</span></span>
  
<a id="ID4EKB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="661b4-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="661b4-118">URI parameters</span></span>
 
| <span data-ttu-id="661b4-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="661b4-119">Parameter</span></span>| <span data-ttu-id="661b4-120">種類</span><span class="sxs-lookup"><span data-stu-id="661b4-120">Type</span></span>| <span data-ttu-id="661b4-121">説明</span><span class="sxs-lookup"><span data-stu-id="661b4-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="661b4-122">userId</span><span class="sxs-lookup"><span data-stu-id="661b4-122">userId</span></span>| <span data-ttu-id="661b4-123">string</span><span class="sxs-lookup"><span data-stu-id="661b4-123">string</span></span>| <span data-ttu-id="661b4-124">'Xuid(12345)'、'gt(myGamertag)' のいずれかまたは 'me' を指定できます。</span><span class="sxs-lookup"><span data-stu-id="661b4-124">Can be either 'xuid(12345)', 'gt(myGamertag)', or 'me'.</span></span>| 
| <span data-ttu-id="661b4-125">userList</span><span class="sxs-lookup"><span data-stu-id="661b4-125">userList</span></span>| <span data-ttu-id="661b4-126">string</span><span class="sxs-lookup"><span data-stu-id="661b4-126">string</span></span>| <span data-ttu-id="661b4-127">設定を取得するユーザーの名前付きのリスト。</span><span class="sxs-lookup"><span data-stu-id="661b4-127">A named list of people to get settings for.</span></span> <span data-ttu-id="661b4-128">現時点では、ユーザーは、サポートされているだけの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="661b4-128">Currently, People is the only list supported.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="661b4-129">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="661b4-129">Query string parameters</span></span>
 
| <span data-ttu-id="661b4-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="661b4-130">Parameter</span></span>| <span data-ttu-id="661b4-131">種類</span><span class="sxs-lookup"><span data-stu-id="661b4-131">Type</span></span>| <span data-ttu-id="661b4-132">説明</span><span class="sxs-lookup"><span data-stu-id="661b4-132">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="661b4-133">settings</span><span class="sxs-lookup"><span data-stu-id="661b4-133">settings</span></span>| <span data-ttu-id="661b4-134">string</span><span class="sxs-lookup"><span data-stu-id="661b4-134">string</span></span>| <span data-ttu-id="661b4-135">設定名のコンマ区切りの一覧。</span><span class="sxs-lookup"><span data-stu-id="661b4-135">A comma-delimited list of setting names.</span></span>| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="661b4-136">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="661b4-136">Required Request Headers</span></span>
 
| <span data-ttu-id="661b4-137">Header</span><span class="sxs-lookup"><span data-stu-id="661b4-137">Header</span></span>| <span data-ttu-id="661b4-138">種類</span><span class="sxs-lookup"><span data-stu-id="661b4-138">Type</span></span>| <span data-ttu-id="661b4-139">説明</span><span class="sxs-lookup"><span data-stu-id="661b4-139">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="661b4-140">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="661b4-140">x-xbl-contract-version</span></span>| <span data-ttu-id="661b4-141">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="661b4-141">32-bit signed integer</span></span>| <span data-ttu-id="661b4-142">値 = 2</span><span class="sxs-lookup"><span data-stu-id="661b4-142">Value = 2</span></span>| 
| <span data-ttu-id="661b4-143">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="661b4-143">content-type</span></span>| <span data-ttu-id="661b4-144">string</span><span class="sxs-lookup"><span data-stu-id="661b4-144">string</span></span>| <span data-ttu-id="661b4-145">値 = <code>application/json</code></span><span class="sxs-lookup"><span data-stu-id="661b4-145">Value = <code>application/json</code></span></span>| 
  
<a id="ID4E2D"></a>

 
## <a name="request-body"></a><span data-ttu-id="661b4-146">要求本文</span><span class="sxs-lookup"><span data-stu-id="661b4-146">Request body</span></span>
 
<a id="ID4EBE"></a>

 
### <a name="sample-request"></a><span data-ttu-id="661b4-147">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="661b4-147">Sample request</span></span>
 

```cpp
GET /users/me/profile/settings/people/people?settings=GameDisplayName,GameDisplayPicRaw,Gamerscore,Gamertag
      
```

  
<a id="ID4EKE"></a>

  
 
<a id="ID4EME"></a>

 
##### <a name="response-body"></a><span data-ttu-id="661b4-148">応答本文</span><span class="sxs-lookup"><span data-stu-id="661b4-148">Response body</span></span> 
<span data-ttu-id="661b4-149">応答は、 **ReadMultiSettingsResponseV2**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="661b4-149">The response is a **ReadMultiSettingsResponseV2** object.</span></span> <span data-ttu-id="661b4-150">呼び出し元のユーザーと仮定した場合に、1 つだけのフレンドがあります。</span><span class="sxs-lookup"><span data-stu-id="661b4-150">Assuming the calling user has only one friend:</span></span>
  

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

 
## <a name="see-also"></a><span data-ttu-id="661b4-151">関連項目</span><span class="sxs-lookup"><span data-stu-id="661b4-151">See also</span></span>
 
<a id="ID4E5E"></a>

 
##### <a name="parent"></a><span data-ttu-id="661b4-152">Parent</span><span class="sxs-lookup"><span data-stu-id="661b4-152">Parent</span></span> 

[<span data-ttu-id="661b4-153">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span><span class="sxs-lookup"><span data-stu-id="661b4-153">/users/{userId}/profile/settings/people/{userList}?settings={settings}</span></span>](uri-usersuseridprofilesettingspeopleuserlist.md)

 [<span data-ttu-id="661b4-154">プロファイル (JSON)</span><span class="sxs-lookup"><span data-stu-id="661b4-154">Profile (JSON)</span></span>](../../json/json-profile.md)

   