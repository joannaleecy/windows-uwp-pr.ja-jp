---
title: QueryClipsResponse (JSON)
assetID: 5d668588-54d6-3cf3-20ad-bb2600a156b3
permalink: en-us/docs/xboxlive/rest/json-queryclipsresponse.html
author: KevinAsgari
description: " QueryClipsResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4efe0e93527560e31a471fce2c74b1cc254101ad
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4152082"
---
# <a name="queryclipsresponse-json"></a><span data-ttu-id="19212-104">QueryClipsResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="19212-104">QueryClipsResponse (JSON)</span></span>
<span data-ttu-id="19212-105">一覧のページング情報と共にゲーム クリップの戻り値の一覧をラップします。</span><span class="sxs-lookup"><span data-stu-id="19212-105">Wraps the list of return game clips along with paging information for the list.</span></span> 
<a id="ID4EN"></a>

 
## <a name="queryclipsresponse"></a><span data-ttu-id="19212-106">QueryClipsResponse</span><span class="sxs-lookup"><span data-stu-id="19212-106">QueryClipsResponse</span></span>
 
<span data-ttu-id="19212-107">QueryClipsResponse オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="19212-107">The QueryClipsResponse object has the following specification.</span></span>
 
| <span data-ttu-id="19212-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="19212-108">Member</span></span>| <span data-ttu-id="19212-109">種類</span><span class="sxs-lookup"><span data-stu-id="19212-109">Type</span></span>| <span data-ttu-id="19212-110">説明</span><span class="sxs-lookup"><span data-stu-id="19212-110">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="19212-111">ゲーム クリップ</span><span class="sxs-lookup"><span data-stu-id="19212-111">gameClips</span></span></b>| <span data-ttu-id="19212-112">ゲーム クリップだったの配列</span><span class="sxs-lookup"><span data-stu-id="19212-112">array of GameClip</span></span>| <span data-ttu-id="19212-113">要求の制限 (<b>maxItems</b>) までクエリが満たされるゲーム クリップの配列です。</span><span class="sxs-lookup"><span data-stu-id="19212-113">An array of game clips that satisfied the query up to the request limit (<b>maxItems</b>).</span></span>| 
| <b><span data-ttu-id="19212-114">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="19212-114">pagingInfo</span></span></b>| <span data-ttu-id="19212-115">PagingInfo</span><span class="sxs-lookup"><span data-stu-id="19212-115">PagingInfo</span></span>| <span data-ttu-id="19212-116">必要な継続とリストの後続の呼び出しのページングする要求の制限を超える (<b>maxItems</b>) の情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="19212-116">Contains the information needed for continuation and paging for subsequent calls for lists that exceed the request limit (<b>maxItems</b>).</span></span>| 
  
<a id="ID4E2B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="19212-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="19212-117">Sample JSON syntax</span></span>
 

```json
{
 "gameClips": [
   {
     "id": "7ce5c1a7-1255-46d3-a90e-34a0e2dfab06",
     "xuid": "2716903703773872",
     "state": "Published", 
     "dateRecorded": "2012-12-23T12:00:00Z",
     "lastModified": "2012-10-31T10:45:00Z",
     "clipName": "Forza 4",
     "userCaption": "My awesome car flip",
     "eventId": "mymagicmomentABCDEFG",
     "type": "DeveloperInitiated, Achievement",
     "source": "TitleDirect",
     "visibility": "Default",
     "durationInSeconds": 30,
     "scid": "ecb5497e-76d4-4a8a-870d-e76a26306b7d",
     "rating": 1.0,
     "views": 5,
     "thumbnails": [
       {
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234565,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       }
     ]
   },
   {
     "id": "7ce5c1a7-1255-46d3-a90e-34a0e2dfab06",
     "xuid": "2716903703773872",
     "state": "Published", 
     "dateRecorded": "2012-12-23T12:00:00Z",
     "lastModified": "2012-12-23T12:00:00Z",
     "clipName": "Halo 4 Magic Moment",
     "userCaption": "You've been pwn3d!",
     "eventId": "123456",
     "type": "Achievement",
     "source": "Console",
     "visibility": "Public",
     "durationInSeconds": 50,
     "scid": "d4dd889f-813f-42cf-ad2f-3063e6ded066",
     "rating": 0.5,
     "views": 5,
     "properties": "{ 'Boss': 'The Invincible' }",
     "systemProperties": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }",
     "thumbnails": [
       {
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234567,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       },
       {
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/manifest",
         "fileSize": 0,
         "uriType": "SmoothStreaming",
         "expiration": "2013-01-18T11:25:51.6522794Z"
       }
     ]
   }
 ],
 "pagingInfo": {
   "continuationToken": "",
   "totalItems": 2
 }
}
    
```

  
<a id="ID4EEC"></a>

 
## <a name="see-also"></a><span data-ttu-id="19212-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="19212-118">See also</span></span>
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a><span data-ttu-id="19212-119">Parent</span><span class="sxs-lookup"><span data-stu-id="19212-119">Parent</span></span> 

[<span data-ttu-id="19212-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="19212-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ESC"></a>

 
##### <a name="reference"></a><span data-ttu-id="19212-121">リファレンス</span><span class="sxs-lookup"><span data-stu-id="19212-121">Reference</span></span>   