---
author: drewbatgit
ms.assetid: CC0D6E9B-128D-488B-912F-318F5EE2B8D3
description: この記事では、CameraCaptureUI クラスを使用して、Windows に組み込まれているカメラ UI で写真またはビデオをキャプチャする方法を説明します。
title: Windows の組み込みカメラ UI を使った写真とビデオのキャプチャ
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: fd9a347904b83db4bb927a36e466153a9e24d8de
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5923105"
---
# <a name="capture-photos-and-video-with-windows-built-in-camera-ui"></a><span data-ttu-id="870ed-104">Windows の組み込みカメラ UI を使った写真とビデオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="870ed-104">Capture photos and video with Windows built-in camera UI</span></span>



<span data-ttu-id="870ed-105">この記事では、CameraCaptureUI クラスを使用して、Windows に組み込まれているカメラ UI で写真またはビデオをキャプチャする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="870ed-105">This article describes how to use the CameraCaptureUI class to capture photos or videos using the camera UI built into Windows.</span></span> <span data-ttu-id="870ed-106">この機能は使いやすく、わずか数行のコードで、ユーザーがキャプチャした写真やビデオをアプリに取り込むことができます。</span><span class="sxs-lookup"><span data-stu-id="870ed-106">This feature is easy to use and allows your app to get a user-captured photo or video with just a few lines of code.</span></span>

<span data-ttu-id="870ed-107">独自のカメラ用 UI を用意する場合、またはキャプチャ操作に対してより堅牢で低レベルな制御が必要な場合は、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) オブジェクトを使用して、独自のキャプチャ操作を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="870ed-107">If you want to provide your own camera UI or if your scenario requires more robust, low-level control of the capture operation, you should use the [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) object and implement your own capture experience.</span></span> <span data-ttu-id="870ed-108">詳しくは、「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="870ed-108">For more information, see [Basic photo, video, and audio capture with MediaCapture](basic-photo-video-and-audio-capture-with-MediaCapture.md).</span></span>

> [!NOTE]
> <span data-ttu-id="870ed-109">アプリが CameraCaptureUI のみ使用している場合、アプリのマニフェスト ファイルで**web カメラ**または**マイク**機能を指定する必要がありますできません。</span><span class="sxs-lookup"><span data-stu-id="870ed-109">You should not specify the **webcam** or **microphone** capabilities in your app manifest file if your app only uses CameraCaptureUI.</span></span> <span data-ttu-id="870ed-110">指定すると、アプリはデバイスのカメラのプライバシー設定に表示されますが、ユーザーがアプリからのカメラへのアクセスを拒否しても、CameraCaptureUI はメディアをキャプチャできます。</span><span class="sxs-lookup"><span data-stu-id="870ed-110">If you do so, your app will be displayed in the device's camera privacy settings, but even if the user denies camera access to your app, it will not prevent the CameraCaptureUI from capturing media.</span></span> <span data-ttu-id="870ed-111">これは、Windows の組み込みのカメラ アプリが、写真、音声、ビデオのキャプチャをボタンを押して開始する必要がある、信頼されているファースト パーティ アプリであるためです。</span><span class="sxs-lookup"><span data-stu-id="870ed-111">This is because the Windows built-in camera app is a trusted first-party app that requires the user to initiate photo, audio, and video capture with a button press.</span></span> <span data-ttu-id="870ed-112">アプリには、Windows アプリケーション認定キットの証明書ストアに提出する場合は、写真のキャプチャの唯一のメカニズムとして CameraCaptureUI を使用するときに、web カメラまたはマイク機能を指定するときが失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="870ed-112">Your app may fail Windows Application Certification Kit certification when submitted to the Store if you specify the webcam or microphone capabilities when using CameraCaptureUI as your only photo capture mechanism.</span></span>
> <span data-ttu-id="870ed-113">MediaCapture を使用して、音声、写真、またはビデオをプログラムによってキャプチャする場合は、アプリのマニフェスト ファイルで Web カメラまたはマイク機能を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="870ed-113">You must specify the webcam or microphone capabilities in your app manifest file if you are using MediaCapture to capture audio, photos, or video programmatically.</span></span>

## <a name="capture-a-photo-with-cameracaptureui"></a><span data-ttu-id="870ed-114">CameraCaptureUI を使った写真のキャプチャ</span><span class="sxs-lookup"><span data-stu-id="870ed-114">Capture a photo with CameraCaptureUI</span></span>

<span data-ttu-id="870ed-115">カメラ キャプチャ UI を使うには、プロジェクトに [**Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/br226738) 名前空間を含めます。</span><span class="sxs-lookup"><span data-stu-id="870ed-115">To use the camera capture UI, include the [**Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/br226738) namespace in your project.</span></span> <span data-ttu-id="870ed-116">返された画像ファイルでファイル操作を行うには、[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) を含めます。</span><span class="sxs-lookup"><span data-stu-id="870ed-116">To do file operations with the returned image file, include [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346).</span></span>

[!code-cs[UsingCaptureUI](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetUsingCaptureUI)]

<span data-ttu-id="870ed-117">写真をキャプチャするには、新しい [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="870ed-117">To capture a photo, create a new [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) object.</span></span> <span data-ttu-id="870ed-118">オブジェクトの [**PhotoSettings**](https://msdn.microsoft.com/library/windows/apps/br241058) プロパティを使うと、写真の画像形式など、返される写真のプロパティを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="870ed-118">Using the object's [**PhotoSettings**](https://msdn.microsoft.com/library/windows/apps/br241058) property you can specify properties for the returned photo such as the image format of the photo.</span></span> <span data-ttu-id="870ed-119">既定では、ユーザーはカメラ キャプチャ UI を使うことにより、返される前に写真のトリミングを行うことができます。ただし、この機能は [**AllowCropping**](https://msdn.microsoft.com/library/windows/apps/br241042) プロパティを使って無効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="870ed-119">By default, the camera capture UI allows the user to crop the photo before it is returned, although this can be disabled with the [**AllowCropping**](https://msdn.microsoft.com/library/windows/apps/br241042) property.</span></span> <span data-ttu-id="870ed-120">この例では、[**CroppedSizeInPixels**](https://msdn.microsoft.com/library/windows/apps/br241044) を設定して、返される画像のサイズが 200 x 200 ピクセルになるよう要求しています。</span><span class="sxs-lookup"><span data-stu-id="870ed-120">This example sets the [**CroppedSizeInPixels**](https://msdn.microsoft.com/library/windows/apps/br241044) to request that the returned image be 200 x 200 in pixels.</span></span>

> [!NOTE]
> <span data-ttu-id="870ed-121">モバイル デバイス ファミリのデバイスでは、**CameraCaptureUI** での画像のトリミングはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="870ed-121">Imaging cropping in the **CameraCaptureUI** is not supported for devices in the Mobile device family.</span></span> <span data-ttu-id="870ed-122">アプリがこれらのデバイスで実行されている場合、[**AllowCropping**](https://msdn.microsoft.com/library/windows/apps/br241042) プロパティの値は無視されます。</span><span class="sxs-lookup"><span data-stu-id="870ed-122">The value of the [**AllowCropping**](https://msdn.microsoft.com/library/windows/apps/br241042) property is ignored when your app is running on these devices.</span></span>

<span data-ttu-id="870ed-123">写真をキャプチャすることを指定するには、[**CaptureFileAsync**](https://msdn.microsoft.com/library/windows/apps/br241057) を呼び出して、[**CameraCaptureUIMode.Photo**](https://msdn.microsoft.com/library/windows/apps/br241040) を指定します。</span><span class="sxs-lookup"><span data-stu-id="870ed-123">Call [**CaptureFileAsync**](https://msdn.microsoft.com/library/windows/apps/br241057) and specify [**CameraCaptureUIMode.Photo**](https://msdn.microsoft.com/library/windows/apps/br241040) to specify that a photo should be captured.</span></span> <span data-ttu-id="870ed-124">キャプチャに成功すると、このメソッドは、画像が格納された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) インスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="870ed-124">The method returns a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) instance containing the image if the capture is successful.</span></span> <span data-ttu-id="870ed-125">ユーザーがキャプチャを取り消した場合、返されるオブジェクトは null になります。</span><span class="sxs-lookup"><span data-stu-id="870ed-125">If the user cancels the capture, the returned object is null.</span></span>

[!code-cs[CapturePhoto](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetCapturePhoto)]

<span data-ttu-id="870ed-126">キャプチャした写真が格納されている **StorageFile** は、動的に生成された名前が付けられて、アプリのローカル フォルダーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="870ed-126">The **StorageFile** containing the captured photo is given a dynamically generated name and saved in your app's local folder.</span></span> <span data-ttu-id="870ed-127">キャプチャした写真をわかりやすく整理するため、別のフォルダーにファイルを移動することもできます。</span><span class="sxs-lookup"><span data-stu-id="870ed-127">To better organize your captured photos, you may want to move the file to a different folder.</span></span>

[!code-cs[CopyAndDeletePhoto](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetCopyAndDeletePhoto)]

<span data-ttu-id="870ed-128">アプリで写真を使用するために、[ **SoftwareBitmap** ](https://msdn.microsoft.com/library/windows/apps/dn887358)オブジェクトを作成できます。このオブジェクトは、ユニバーサル Windows アプリのさまざまな機能で使用できます。</span><span class="sxs-lookup"><span data-stu-id="870ed-128">To use your photo in your app, you may want to create a [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) object that can be used with several different Universal Windows app features.</span></span>

<span data-ttu-id="870ed-129">まず、プロジェクトに [**Windows.Graphics.Imaging**](https://msdn.microsoft.com/library/windows/apps/br226400) 名前空間を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="870ed-129">First you should include the [**Windows.Graphics.Imaging**](https://msdn.microsoft.com/library/windows/apps/br226400) namespace in your project.</span></span>

[!code-cs[UsingSoftwareBitmap](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetUsingSoftwareBitmap)]

<span data-ttu-id="870ed-130">画像ファイルからストリームを取得するには、[**OpenAsync**](https://msdn.microsoft.com/library/windows/apps/br227116) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="870ed-130">Call [**OpenAsync**](https://msdn.microsoft.com/library/windows/apps/br227116) to get a stream from the image file.</span></span> <span data-ttu-id="870ed-131">ストリームのビットマップ デコーダーを取得するには、[**BitmapDecoder.CreateAsync**](https://msdn.microsoft.com/library/windows/apps/br226182) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="870ed-131">Call [**BitmapDecoder.CreateAsync**](https://msdn.microsoft.com/library/windows/apps/br226182) to get a bitmap decoder for the stream.</span></span> <span data-ttu-id="870ed-132">次に、[**GetSoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887332) を呼び出して、画像の **SoftwareBitmap** 表現を取得します。</span><span class="sxs-lookup"><span data-stu-id="870ed-132">Then call [**GetSoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887332) to get a **SoftwareBitmap** representation of the image.</span></span>

[!code-cs[SoftwareBitmap](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetSoftwareBitmap)]

<span data-ttu-id="870ed-133">UI に画像を表示するには、XAML ページで [**Image**](https://msdn.microsoft.com/library/windows/apps/br242752) コントロールを宣言します。</span><span class="sxs-lookup"><span data-stu-id="870ed-133">To display the image in your UI, declare an [**Image**](https://msdn.microsoft.com/library/windows/apps/br242752) control in your XAML page.</span></span>

[!code-xml[ImageControl](./code/CameraCaptureUIWin10/cs/MainPage.xaml#SnippetImageControl)]

<span data-ttu-id="870ed-134">XAML ページでソフトウェア ビットマップを使用するには、[**Windows.UI.Xaml.Media.Imaging**](https://msdn.microsoft.com/library/windows/apps/br243258) 名前空間の using 指定を含めます。</span><span class="sxs-lookup"><span data-stu-id="870ed-134">To use the software bitmap in your XAML page, include the using [**Windows.UI.Xaml.Media.Imaging**](https://msdn.microsoft.com/library/windows/apps/br243258) namespace in your project.</span></span>

[!code-cs[UsingSoftwareBitmapSource](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetUsingSoftwareBitmapSource)]

<span data-ttu-id="870ed-135">**Image** コントロールでは、画像のソースが BGRA8 形式プリマルチプライ済みアルファまたはアルファなしであることが求められるため、静的メソッド [**SoftwareBitmap.Convert**](https://msdn.microsoft.com/library/windows/apps/dn887362) を呼び出して、目的の形式で新しいソフトウェア ビットマップを作成します。</span><span class="sxs-lookup"><span data-stu-id="870ed-135">The **Image** control requires that the image source be in BGRA8 format with premultiplied alpha or no alpha, so call the static method [**SoftwareBitmap.Convert**](https://msdn.microsoft.com/library/windows/apps/dn887362) to create a new software bitmap with the desired format.</span></span> <span data-ttu-id="870ed-136">次に、新しい [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/dn997854) オブジェクトを作成して [**SetBitmapAsync**](https://msdn.microsoft.com/library/windows/apps/dn997856) を呼び出し、ソフトウェア ビットマップをソースに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="870ed-136">Next, create a new [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/dn997854) object and call [**SetBitmapAsync**](https://msdn.microsoft.com/library/windows/apps/dn997856) to assign the software bitmap to the source.</span></span> <span data-ttu-id="870ed-137">最後に、キャプチャした写真を UI に表示できるように、**Image** コントロールの [**Source**](https://msdn.microsoft.com/library/windows/apps/br242760) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="870ed-137">Finally, set the **Image** control's [**Source**](https://msdn.microsoft.com/library/windows/apps/br242760) property to display the captured photo in the UI.</span></span>

[!code-cs[SetImageSource](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetSetImageSource)]

## <a name="capture-a-video-with-cameracaptureui"></a><span data-ttu-id="870ed-138">CameraCaptureUI を使ったビデオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="870ed-138">Capture a video with CameraCaptureUI</span></span>

<span data-ttu-id="870ed-139">ビデオをキャプチャするには、新しい [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="870ed-139">To capture a video, create a new [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) object.</span></span> <span data-ttu-id="870ed-140">オブジェクトの [**VideoSettings**](https://msdn.microsoft.com/library/windows/apps/br241059) プロパティを使うと、ビデオの形式など、返されるビデオのプロパティを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="870ed-140">Using the object's [**VideoSettings**](https://msdn.microsoft.com/library/windows/apps/br241059) property you can specify properties for the returned video such as the format of the video.</span></span>

<span data-ttu-id="870ed-141">ビデオをキャプチャすることを指定するには、[**CaptureFileAsync**](https://msdn.microsoft.com/library/windows/apps/br241057) を呼び出して、[**Video**](https://msdn.microsoft.com/library/windows/apps/br241059) を指定します。</span><span class="sxs-lookup"><span data-stu-id="870ed-141">Call [**CaptureFileAsync**](https://msdn.microsoft.com/library/windows/apps/br241057) and specify [**Video**](https://msdn.microsoft.com/library/windows/apps/br241059) to specify that a video should be capture.</span></span> <span data-ttu-id="870ed-142">キャプチャに成功すると、このメソッドは、ビデオが格納された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) インスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="870ed-142">The method returns a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) instance containing the video if the capture is successful.</span></span> <span data-ttu-id="870ed-143">ユーザーがキャプチャを取り消した場合、返されるオブジェクトは null になります。</span><span class="sxs-lookup"><span data-stu-id="870ed-143">If the user cancels the capture, the returned object is null.</span></span>

[!code-cs[CaptureVideo](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetCaptureVideo)]

<span data-ttu-id="870ed-144">キャプチャしたビデオ ファイルをどのように使うかは、アプリのシナリオによって異なります。</span><span class="sxs-lookup"><span data-stu-id="870ed-144">What you do with the captured video file depends on the scenario for your app.</span></span> <span data-ttu-id="870ed-145">この記事の残りの部分では、キャプチャした 1 つ以上のビデオからメディア コンポジションをすばやく作成し、UI に表示する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="870ed-145">The rest of this article shows you how to quickly create a media composition from one or more captured videos and show it in your UI.</span></span>

<span data-ttu-id="870ed-146">まず、ビデオ コンポジションを表示する [**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaPlayerElement) コントロールを XAML ページに追加します。</span><span class="sxs-lookup"><span data-stu-id="870ed-146">First, add a [**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MediaPlayerElement) control in which the video composition will be displayed to your XAML page.</span></span>

[!code-xml[MediaElement](./code/CameraCaptureUIWin10/cs/MainPage.xaml#SnippetMediaElement)]


<span data-ttu-id="870ed-147">カメラ キャプチャ UI から返されたビデオ ファイルを使用し、**[CreateFromStorageFile](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.createfromstoragefile)** を呼び出して、新しい [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) を作成します。</span><span class="sxs-lookup"><span data-stu-id="870ed-147">With the video file returned from the camera capture UI, create a new [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) by calling **[CreateFromStorageFile](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.createfromstoragefile)**.</span></span> <span data-ttu-id="870ed-148">**MediaPlayerElement** に関連付けられている既定の **[MediaPlayer](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer)** の **[Play](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.Play)** メソッドを呼び出してビデオを再生します。</span><span class="sxs-lookup"><span data-stu-id="870ed-148">Call the **[Play](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.Play)** method of the default **[MediaPlayer](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer)** associated with the **MediaPlayerElement** to play the video.</span></span>

[!code-cs[PlayVideo](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetPlayVideo)]
 

## <a name="related-topics"></a><span data-ttu-id="870ed-149">関連トピック</span><span class="sxs-lookup"><span data-stu-id="870ed-149">Related topics</span></span>

* [<span data-ttu-id="870ed-150">カメラ</span><span class="sxs-lookup"><span data-stu-id="870ed-150">Camera</span></span>](camera.md)
* [<span data-ttu-id="870ed-151">MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="870ed-151">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [**<span data-ttu-id="870ed-152">CameraCaptureUI</span><span class="sxs-lookup"><span data-stu-id="870ed-152">CameraCaptureUI</span></span>**](https://msdn.microsoft.com/library/windows/apps/br241030) 
 

 




