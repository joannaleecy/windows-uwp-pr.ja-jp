---
author: drewbatgit
ms.assetid: 05E418B4-5A62-42BD-BF66-A0762216D033
description: このトピックでは、メディア キャプチャのプレビュー ストリームから単一のプレビュー フレームを取得する方法について説明します。
title: プレビュー フレームの取得
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 211bd4ce660726030f8b90d29c4ea4d8a14564de
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6657965"
---
# <a name="get-a-preview-frame"></a><span data-ttu-id="7979d-104">プレビュー フレームの取得</span><span class="sxs-lookup"><span data-stu-id="7979d-104">Get a preview frame</span></span>


<span data-ttu-id="7979d-105">このトピックでは、メディア キャプチャのプレビュー ストリームから単一のプレビュー フレームを取得する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7979d-105">This topic shows you how to get a single preview frame from the media capture preview stream.</span></span>

> [!NOTE] 
> <span data-ttu-id="7979d-106">この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。</span><span class="sxs-lookup"><span data-stu-id="7979d-106">This article builds on concepts and code discussed in [Basic photo, video, and audio capture with MediaCapture](basic-photo-video-and-audio-capture-with-MediaCapture.md), which describes the steps for implementing basic photo and video capture.</span></span> <span data-ttu-id="7979d-107">そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7979d-107">We recommend that you familiarize yourself with the basic media capture pattern in that article before moving on to more advanced capture scenarios.</span></span> <span data-ttu-id="7979d-108">この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され適切に初期化されていることと、アクティブなビデオ プレビュー ストリームを含んだ [**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) が存在することを前提としています。</span><span class="sxs-lookup"><span data-stu-id="7979d-108">The code in this article assumes that your app already has an instance of MediaCapture that has been properly initialized, and that you have a [**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) with an active video preview stream.</span></span>

<span data-ttu-id="7979d-109">プレビュー フレームをキャプチャするためには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間が必要となります。</span><span class="sxs-lookup"><span data-stu-id="7979d-109">In addition to the namespaces required for basic media capture, capturing a preview frame requires the following namespace.</span></span>

[!code-cs[PreviewFrameUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPreviewFrameUsing)]

<span data-ttu-id="7979d-110">プレビュー フレームを要求するとき、フレームの受信に使う形式を指定するには、必要な形式を指定して [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="7979d-110">When you request a preview frame, you can specify the format in which you would like to receive the frame by creating a [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) object with the format you desire.</span></span> <span data-ttu-id="7979d-111">この例では、[**VideoDeviceController.GetMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211995) の呼び出しで [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) を指定し、プレビュー ストリームのプロパティを要求することで、プレビュー ストリームと同じ解像度でビデオ フレームを作成します。</span><span class="sxs-lookup"><span data-stu-id="7979d-111">This example creates a video frame that is the same resolution as the preview stream by calling [**VideoDeviceController.GetMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211995) and specifying [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) to request the properties for the preview stream.</span></span> <span data-ttu-id="7979d-112">プレビュー ストリームの幅と高さを使って新しいビデオ フレームを作成しています。</span><span class="sxs-lookup"><span data-stu-id="7979d-112">The width and height of the preview stream is used to create the new video frame.</span></span>

[!code-cs[CreateFormatFrame](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCreateFormatFrame)]

<span data-ttu-id="7979d-113">[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) オブジェクトが初期化されていてアクティブなプレビュー ストリームが存在する場合、[**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926711) を呼び出してプレビュー ストリームを取得します。</span><span class="sxs-lookup"><span data-stu-id="7979d-113">If your [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) object is initialized and you have an active preview stream, call [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926711) to get a preview stream.</span></span> <span data-ttu-id="7979d-114">引数には、最後のステップで作成したビデオ フレームを渡し、取得するフレームの形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="7979d-114">Pass in the video frame created in the last step to specify the format of the returned frame.</span></span>

[!code-cs[GetPreviewFrameAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPreviewFrameAsync)]

<span data-ttu-id="7979d-115">プレビュー フレームの [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) 表現は、[**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) オブジェクトの [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) プロパティにアクセスして取得します。</span><span class="sxs-lookup"><span data-stu-id="7979d-115">Get a [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) representation of the preview frame by accessing the [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) property of the [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) object.</span></span> <span data-ttu-id="7979d-116">ソフトウェア ビットマップの保存、読み込み、変更については、「[イメージング](imaging.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7979d-116">For information about saving, loading, and modifying software bitmaps, see [Imaging](imaging.md).</span></span>

[!code-cs[GetPreviewBitmap](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPreviewBitmap)]

<span data-ttu-id="7979d-117">Direct3D API で画像を扱う場合は、プレビュー フレームの [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) 表現を取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="7979d-117">You can also get a [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) representation of the preview frame if you want to use the image with Direct3D APIs.</span></span>

[!code-cs[GetPreviewSurface](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPreviewSurface)]

> [!IMPORTANT]
> <span data-ttu-id="7979d-118">**GetPreviewFrameAsync** の呼び出し方法と、アプリが実行されているデバイスによっては、返される **VideoFrame** の [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) プロパティまたは [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn930920) プロパティのどちらかが null になることがあります。</span><span class="sxs-lookup"><span data-stu-id="7979d-118">Either the [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) property or the [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn930920) property of the returned **VideoFrame** may be null depending on how you call **GetPreviewFrameAsync** and also depending on the device on which your app is running.</span></span>

> - <span data-ttu-id="7979d-119">**VideoFrame** 引数を受け入れる [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926713) のオーバーロードを呼び出した場合、返される **VideoFrame** の **SoftwareBitmap** は null 以外になり、**Direct3DSurface** プロパティは null になります。</span><span class="sxs-lookup"><span data-stu-id="7979d-119">If you call the overload of [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926713) that accepts a **VideoFrame** argument, the returned **VideoFrame** will have a non-null **SoftwareBitmap** and the **Direct3DSurface** property will be null.</span></span>
> - <span data-ttu-id="7979d-120">Direct3D サーフェスを使ってフレームを内部で表すデバイスで引数のない [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926712) のオーバーロードを呼び出した場合、**Direct3DSurface** プロパティは null 以外になり、**SoftwareBitmap** プロパティは null になります。</span><span class="sxs-lookup"><span data-stu-id="7979d-120">If you call the overload of [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926712) that has no arguments on a device that uses a Direct3D surface to represent the frame internally, the **Direct3DSurface** property will be non-null and the **SoftwareBitmap** property will be null.</span></span>
> - <span data-ttu-id="7979d-121">Direct3D サーフェスを使ってフレームを内部で表すデバイスで引数のない [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926712) のオーバーロードを呼び出した場合、**SoftwareBitmap** プロパティは null 以外になり、**Direct3DSurface** プロパティは null になります。</span><span class="sxs-lookup"><span data-stu-id="7979d-121">If you call the overload of [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926712) that has no arguments on a device that does not use a Direct3D surface to represent the frame internally, the **SoftwareBitmap** property will be non-null and the **Direct3DSurface** property will be null.</span></span>

<span data-ttu-id="7979d-122">アプリは、**SoftwareBitmap** プロパティまたは **Direct3DSurface** プロパティによって返されるオブジェクトで動作を試みる前に、必ず null 値をチェックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7979d-122">Your app should always check for a null value before trying to operate on the objects returned by the **SoftwareBitmap** or **Direct3DSurface** properties.</span></span>

<span data-ttu-id="7979d-123">プレビュー フレームが不要になったら必ず、その [**Close**](https://msdn.microsoft.com/library/windows/apps/dn930918) メソッド (C# 内で Dispose に投影される) を呼び出して、フレームによって使われているリソースを解放してください。</span><span class="sxs-lookup"><span data-stu-id="7979d-123">When you are done using the preview frame, be sure to call its [**Close**](https://msdn.microsoft.com/library/windows/apps/dn930918) method (projected to Dispose in C#) to free the resources used by the frame.</span></span> <span data-ttu-id="7979d-124">または、**using** パターンを使ってもかまいません。その場合は、オブジェクトが自動的に破棄されます。</span><span class="sxs-lookup"><span data-stu-id="7979d-124">Or, use the **using** pattern, which automatically disposes of the object.</span></span>

[!code-cs[CleanUpPreviewFrame](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpPreviewFrame)]

## <a name="related-topics"></a><span data-ttu-id="7979d-125">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7979d-125">Related topics</span></span>

* [<span data-ttu-id="7979d-126">カメラ</span><span class="sxs-lookup"><span data-stu-id="7979d-126">Camera</span></span>](camera.md)
* [<span data-ttu-id="7979d-127">MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="7979d-127">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 




