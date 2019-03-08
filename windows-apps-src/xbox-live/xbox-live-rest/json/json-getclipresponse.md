---
title: GetClipResponse (JSON)
assetID: ef128790-dc6a-6055-92d5-2ac08b708443
permalink: en-us/docs/xboxlive/rest/json-getclipresponse.html
description: " GetClipResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ef6875bfecfe7ee90fb1794164240116fd39ed91
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649497"
---
# <a name="getclipresponse-json"></a><span data-ttu-id="9609c-104">GetClipResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="9609c-104">GetClipResponse (JSON)</span></span>
<span data-ttu-id="9609c-105">ゲームのクリップをラップします。</span><span class="sxs-lookup"><span data-stu-id="9609c-105">Wraps the game clip.</span></span> 
<a id="ID4EN"></a>

 
## <a name="getclipresponse"></a><span data-ttu-id="9609c-106">GetClipResponse</span><span class="sxs-lookup"><span data-stu-id="9609c-106">GetClipResponse</span></span>
 
<span data-ttu-id="9609c-107">GetClipResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9609c-107">The GetClipResponse object has the following specification.</span></span>
 
| <span data-ttu-id="9609c-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="9609c-108">Member</span></span>| <span data-ttu-id="9609c-109">種類</span><span class="sxs-lookup"><span data-stu-id="9609c-109">Type</span></span>| <span data-ttu-id="9609c-110">説明</span><span class="sxs-lookup"><span data-stu-id="9609c-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9609c-111">ゲーム クリップだった</span><span class="sxs-lookup"><span data-stu-id="9609c-111">gameClip</span></span>| [<span data-ttu-id="9609c-112">GameClip</span><span class="sxs-lookup"><span data-stu-id="9609c-112">GameClip</span></span>](json-gameclip.md)| <span data-ttu-id="9609c-113">クエリを満たす 1 つのゲーム クリップします。</span><span class="sxs-lookup"><span data-stu-id="9609c-113">A single game clip that satisfied the query.</span></span>| 
  
<a id="ID4ELB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="9609c-114">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="9609c-114">Sample JSON syntax</span></span>
 

```json
{
 "gameClip": {
   "xuid": "2716903703773872",
   "clipName": "1234567890",
   "titleName": "",
   "gameClipId": "cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000",
   "state": "Published",
   "dateRecorded": "2013-05-08T21:32:17.4201279Z",
   "lastModified": "2013-05-08T21:34:48.8117829Z",
   "userCaption": "",
   "type": "DeveloperInitiated",
   "source": "Console",
   "visibility": "Public",
   "durationInSeconds": 30,
   "scid": "00000000-0000-0012-0023-000000000070",
   "titleId": 0,
   "rating": 0,
   "ratingCount": 0,
   "views": 0,
   "titleData": "",
   "systemProperties": "",
   "savedByUser": false,
   "thumbnails": [
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000\/thumbnails\/large",
       "fileSize": 0,
       "thumbnailType": "Large"
     },
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000\/thumbnails\/small",
       "fileSize": 0,
       "thumbnailType": "Small"
     }
   ],
   "gameClipUris": [
     {
       "uri": "http:\/\/localhost\/users\/xuid(2716903703773872)\/scids\/00000000-0000-0012-0023-000000000070\/clips\/cd42452a-8ec0-4289-9e9e-e4cd89d7d674-000",
       "fileSize": 9332015,
       "uriType": "Download",
       "expiration": "9999-12-31T23:59:59.9999999"
     }
   ]
 }
}
    
```

  
<a id="ID4EUB"></a>

 
## <a name="see-also"></a><span data-ttu-id="9609c-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="9609c-115">See also</span></span>
 
<a id="ID4EWB"></a>

 
##### <a name="parent"></a><span data-ttu-id="9609c-116">Parent</span><span class="sxs-lookup"><span data-stu-id="9609c-116">Parent</span></span> 

[<span data-ttu-id="9609c-117">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="9609c-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   