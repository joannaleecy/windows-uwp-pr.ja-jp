---
title: QueryClipsResponse (JSON)
assetID: 5d668588-54d6-3cf3-20ad-bb2600a156b3
permalink: en-us/docs/xboxlive/rest/json-queryclipsresponse.html
description: " QueryClipsResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 23955d311d57fa3454bdb84df67ddae07a0c8548
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8787790"
---
# <a name="queryclipsresponse-json"></a><span data-ttu-id="4820a-104">QueryClipsResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="4820a-104">QueryClipsResponse (JSON)</span></span>
<span data-ttu-id="4820a-105">一覧のページング情報と共にゲーム クリップの戻り値の一覧をラップします。</span><span class="sxs-lookup"><span data-stu-id="4820a-105">Wraps the list of return game clips along with paging information for the list.</span></span> 
<a id="ID4EN"></a>

 
## <a name="queryclipsresponse"></a><span data-ttu-id="4820a-106">QueryClipsResponse</span><span class="sxs-lookup"><span data-stu-id="4820a-106">QueryClipsResponse</span></span>
 
<span data-ttu-id="4820a-107">QueryClipsResponse オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="4820a-107">The QueryClipsResponse object has the following specification.</span></span>
 
| <span data-ttu-id="4820a-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="4820a-108">Member</span></span>| <span data-ttu-id="4820a-109">種類</span><span class="sxs-lookup"><span data-stu-id="4820a-109">Type</span></span>| <span data-ttu-id="4820a-110">説明</span><span class="sxs-lookup"><span data-stu-id="4820a-110">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="4820a-111">ゲーム クリップ</span><span class="sxs-lookup"><span data-stu-id="4820a-111">gameClips</span></span></b>| <span data-ttu-id="4820a-112">GameClip の配列</span><span class="sxs-lookup"><span data-stu-id="4820a-112">array of GameClip</span></span>| <span data-ttu-id="4820a-113">要求の制限 (<b>maxItems</b>) までクエリが満たされるゲーム クリップの配列です。</span><span class="sxs-lookup"><span data-stu-id="4820a-113">An array of game clips that satisfied the query up to the request limit (<b>maxItems</b>).</span></span>| 
| <b><span data-ttu-id="4820a-114">pagingInfo</span><span class="sxs-lookup"><span data-stu-id="4820a-114">pagingInfo</span></span></b>| <span data-ttu-id="4820a-115">PagingInfo</span><span class="sxs-lookup"><span data-stu-id="4820a-115">PagingInfo</span></span>| <span data-ttu-id="4820a-116">必要な継続とリストの後続の呼び出しのページングする要求の制限を超える (<b>maxItems</b>) の情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4820a-116">Contains the information needed for continuation and paging for subsequent calls for lists that exceed the request limit (<b>maxItems</b>).</span></span>| 
  
<a id="ID4E2B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="4820a-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="4820a-117">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="4820a-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="4820a-118">See also</span></span>
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4820a-119">Parent</span><span class="sxs-lookup"><span data-stu-id="4820a-119">Parent</span></span> 

[<span data-ttu-id="4820a-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="4820a-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ESC"></a>

 
##### <a name="reference"></a><span data-ttu-id="4820a-121">リファレンス</span><span class="sxs-lookup"><span data-stu-id="4820a-121">Reference</span></span>   