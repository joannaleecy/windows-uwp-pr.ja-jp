---
title: QueryClipsResponse (JSON)
assetID: 5d668588-54d6-3cf3-20ad-bb2600a156b3
permalink: en-us/docs/xboxlive/rest/json-queryclipsresponse.html
description: " QueryClipsResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a0369de617fd60fcc71e7d69b46ced6b499e8de5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650507"
---
# <a name="queryclipsresponse-json"></a><span data-ttu-id="747f8-104">QueryClipsResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="747f8-104">QueryClipsResponse (JSON)</span></span>
<span data-ttu-id="747f8-105">ゲームの一覧のページング情報と共にクリップの戻り値の一覧をラップします。</span><span class="sxs-lookup"><span data-stu-id="747f8-105">Wraps the list of return game clips along with paging information for the list.</span></span> 
<a id="ID4EN"></a>

 
## <a name="queryclipsresponse"></a><span data-ttu-id="747f8-106">QueryClipsResponse</span><span class="sxs-lookup"><span data-stu-id="747f8-106">QueryClipsResponse</span></span>
 
<span data-ttu-id="747f8-107">QueryClipsResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="747f8-107">The QueryClipsResponse object has the following specification.</span></span>
 
| <span data-ttu-id="747f8-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="747f8-108">Member</span></span>| <span data-ttu-id="747f8-109">種類</span><span class="sxs-lookup"><span data-stu-id="747f8-109">Type</span></span>| <span data-ttu-id="747f8-110">説明</span><span class="sxs-lookup"><span data-stu-id="747f8-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="747f8-111"><b>gameClips</b></span><span class="sxs-lookup"><span data-stu-id="747f8-111"><b>gameClips</b></span></span>| <span data-ttu-id="747f8-112">ゲーム クリップだったの配列</span><span class="sxs-lookup"><span data-stu-id="747f8-112">array of GameClip</span></span>| <span data-ttu-id="747f8-113">要求の上限に達するまで、クエリを満たすゲームのクリップの配列 (<b>maxItems</b>)。</span><span class="sxs-lookup"><span data-stu-id="747f8-113">An array of game clips that satisfied the query up to the request limit (<b>maxItems</b>).</span></span>| 
| <span data-ttu-id="747f8-114"><b>pagingInfo</b></span><span class="sxs-lookup"><span data-stu-id="747f8-114"><b>pagingInfo</b></span></span>| <span data-ttu-id="747f8-115">PagingInfo</span><span class="sxs-lookup"><span data-stu-id="747f8-115">PagingInfo</span></span>| <span data-ttu-id="747f8-116">必要な継続と後続の呼び出しリストのページングを上限を超える要求情報が含まれています (<b>maxItems</b>)。</span><span class="sxs-lookup"><span data-stu-id="747f8-116">Contains the information needed for continuation and paging for subsequent calls for lists that exceed the request limit (<b>maxItems</b>).</span></span>| 
  
<a id="ID4E2B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="747f8-117">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="747f8-117">Sample JSON syntax</span></span>
 

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
         "uri": "https://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "https://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
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
         "uri": "https://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "https://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234567,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       },
       {
         "uri": "https://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/manifest",
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

 
## <a name="see-also"></a><span data-ttu-id="747f8-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="747f8-118">See also</span></span>
 
<a id="ID4EGC"></a>

 
##### <a name="parent"></a><span data-ttu-id="747f8-119">Parent</span><span class="sxs-lookup"><span data-stu-id="747f8-119">Parent</span></span> 

[<span data-ttu-id="747f8-120">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="747f8-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ESC"></a>

 
##### <a name="reference"></a><span data-ttu-id="747f8-121">リファレンス</span><span class="sxs-lookup"><span data-stu-id="747f8-121">Reference</span></span>   