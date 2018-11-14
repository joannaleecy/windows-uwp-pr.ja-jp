---
author: drewbatgit
ms.assetid: 708170E1-777A-4E4A-9F77-5AB28B88B107
description: この記事では、ビデオ キャプチャの拡張シナリオ (HDR ビデオ、露出の優先順位など) を手動デバイス制御によって有効にする方法を示します。
title: ビデオ キャプチャのための手動カメラ制御
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 91f9d21f6df09bf8f3cad3e5a43f3ed94049338e
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6467668"
---
# <a name="manual-camera-controls-for-video-capture"></a><span data-ttu-id="9b477-104">ビデオ キャプチャのための手動カメラ制御</span><span class="sxs-lookup"><span data-stu-id="9b477-104">Manual camera controls for video capture</span></span>



<span data-ttu-id="9b477-105">この記事では、ビデオ キャプチャの拡張シナリオ (HDR ビデオ、露出の優先順位など) を手動デバイス制御によって有効にする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9b477-105">This article shows you how to use manual device controls to enable enhanced video capture scenarios, including HDR video and exposure priority.</span></span>

<span data-ttu-id="9b477-106">この記事で説明するビデオ デバイス コントロールはすべて同じパターンを使ってアプリに追加されます。</span><span class="sxs-lookup"><span data-stu-id="9b477-106">The video device controls discussed in this article are all added to your app by using the same pattern.</span></span> <span data-ttu-id="9b477-107">まず、アプリが実行されている現在のデバイスで、コントロールがサポートされているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="9b477-107">First, check to see if the control is supported on the current device on which your app is running.</span></span> <span data-ttu-id="9b477-108">コントロールがサポートされている場合は、コントロールに対して必要なモードを設定します。</span><span class="sxs-lookup"><span data-stu-id="9b477-108">If the control is supported, set the desired mode for the control.</span></span> <span data-ttu-id="9b477-109">一般的に、現在のデバイスで特定のコントロールがサポートされていない場合は、ユーザーがその機能を有効にできるような UI 要素を無効または非表示にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9b477-109">Typically, if a particular control is unsupported on the current device, you should disable or hide the UI element that allows the user to enable the feature.</span></span>

<span data-ttu-id="9b477-110">この記事で説明するデバイス制御 API はすべて、[**Windows.Media.Devices**](https://msdn.microsoft.com/library/windows/apps/br206902) 名前空間のメンバーです。</span><span class="sxs-lookup"><span data-stu-id="9b477-110">All of the device control APIs discussed in this article are members of the [**Windows.Media.Devices**](https://msdn.microsoft.com/library/windows/apps/br206902) namespace.</span></span>

[!code-cs[VideoControllersUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVideoControllersUsing)]

> [!NOTE] 
> <span data-ttu-id="9b477-111">この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。</span><span class="sxs-lookup"><span data-stu-id="9b477-111">This article builds on concepts and code discussed in [Basic photo, video, and audio capture with MediaCapture](basic-photo-video-and-audio-capture-with-MediaCapture.md), which describes the steps for implementing basic photo and video capture.</span></span> <span data-ttu-id="9b477-112">そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9b477-112">We recommend that you familiarize yourself with the basic media capture pattern in that article before moving on to more advanced capture scenarios.</span></span> <span data-ttu-id="9b477-113">この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="9b477-113">The code in this article assumes that your app already has an instance of MediaCapture that has been properly initialized.</span></span>

## <a name="hdr-video"></a><span data-ttu-id="9b477-114">HDR ビデオ</span><span class="sxs-lookup"><span data-stu-id="9b477-114">HDR video</span></span>

<span data-ttu-id="9b477-115">ハイ ダイナミック レンジ (HDR) ビデオ機能では、HDR 処理をキャプチャ デバイスのビデオ ストリームに適用します。</span><span class="sxs-lookup"><span data-stu-id="9b477-115">The high dynamic range (HDR) video feature applies HDR processing to the video stream of the capture device.</span></span> <span data-ttu-id="9b477-116">HDR ビデオがサポートされているかどうかを確認するには、[**HdrVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926682) プロパティを選びます。</span><span class="sxs-lookup"><span data-stu-id="9b477-116">Determine if HDR video is supported by selecting the [**HdrVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926682) property.</span></span>

<span data-ttu-id="9b477-117">HDR ビデオ コントロールでは、3 つのモード (オン、オフ、自動) がサポートされています。自動モードでは、HDR ビデオ処理によってメディア キャプチャが改善されるかどうかをデバイスが動的に判断し、改善される場合は HDR ビデオが有効になります。</span><span class="sxs-lookup"><span data-stu-id="9b477-117">The HDR video control supports three modes: on, off, and automatic, which means that the device dynamically determines if HDR video processing would improve the media capture and, if so, enables HDR video.</span></span> <span data-ttu-id="9b477-118">現在のデバイスで特定のモードがサポートされているかどうかを確認するには、[**HdrVideoControl.SupportedModes**](https://msdn.microsoft.com/library/windows/apps/dn926683) コレクションに目的のモードが含まれているかどうかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="9b477-118">To determine if a particular mode is supported on the current device, check to see if the [**HdrVideoControl.SupportedModes**](https://msdn.microsoft.com/library/windows/apps/dn926683) collection contains the desired mode.</span></span>

<span data-ttu-id="9b477-119">HDR ビデオ処理を有効または無効にするには、[**HdrVideoControl.Mode**](https://msdn.microsoft.com/library/windows/apps/dn926681) を目的のモードに設定します。</span><span class="sxs-lookup"><span data-stu-id="9b477-119">Enable or disable HDR video processing by setting the [**HdrVideoControl.Mode**](https://msdn.microsoft.com/library/windows/apps/dn926681) to the desired mode.</span></span>

[!code-cs[SetHdrVideoMode](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetHdrVideoMode)]

## <a name="exposure-priority"></a><span data-ttu-id="9b477-120">露出の優先順位</span><span class="sxs-lookup"><span data-stu-id="9b477-120">Exposure priority</span></span>

<span data-ttu-id="9b477-121">[**ExposurePriorityVideoControl**](https://msdn.microsoft.com/library/windows/apps/dn926644) は、有効であれば、キャプチャ デバイスからのビデオ フレームを評価し、ローライト シーンのビデオがキャプチャされているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="9b477-121">The [**ExposurePriorityVideoControl**](https://msdn.microsoft.com/library/windows/apps/dn926644), when enabled, evaluates the video frames from the capture device to determine if the video is capturing a low-light scene.</span></span> <span data-ttu-id="9b477-122">その場合は、各フレームの露出時間を長くし、キャプチャしたビデオの画質を向上するために、キャプチャするビデオのフレーム レートが引き下げられます。</span><span class="sxs-lookup"><span data-stu-id="9b477-122">If so, the control lowers the frame rate of the captured video in order to increase the exposure time for each frame and improve the visual quality of the captured video.</span></span>

<span data-ttu-id="9b477-123">[**ExposurePriorityVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926647) プロパティをチェックして、現在のデバイスで露出の優先順位コントロールがサポートされているかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="9b477-123">Determine if the exposure priority control is supported on the current device by checking the [**ExposurePriorityVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926647) property.</span></span>

<span data-ttu-id="9b477-124">露出の優先順位コントロールを有効または無効にするには、[**ExposurePriorityVideoControl.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn926646) を目的のモードに設定します。</span><span class="sxs-lookup"><span data-stu-id="9b477-124">Enable or disable the exposure priority control by setting the [**ExposurePriorityVideoControl.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn926646) to the desired mode.</span></span>

[!code-cs[EnableExposurePriority](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetEnableExposurePriority)]

## <a name="temporal-denoising"></a><span data-ttu-id="9b477-125">一時的なノイズ除去</span><span class="sxs-lookup"><span data-stu-id="9b477-125">Temporal denoising</span></span>
<span data-ttu-id="9b477-126">Windows 10、バージョン 1803 以降では、デバイスでサポートされている場合、そのデバイスのビデオに対して一時的なノイズ除去を有効できます。</span><span class="sxs-lookup"><span data-stu-id="9b477-126">Starting with Windows 10, version 1803, you can enable temporal denoising for video on devices that support it.</span></span> <span data-ttu-id="9b477-127">この機能では、隣接する複数のフレームの画像データがリアル タイムで融合されて、画像ノイズの少ないビデオ フレームが生成されます。</span><span class="sxs-lookup"><span data-stu-id="9b477-127">This feature fuses the image data from multiple adjacent frames in real time to produce video frames that have less visual noise.</span></span>

<span data-ttu-id="9b477-128">アプリは、[**VideoTemporalDenoisingControl**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol) によって、一時的なノイズ除去が現在のデバイスでサポートされているかどうか、またサポートされている場合は、サポートされている一時的なノイズ除去のモードを判定します。</span><span class="sxs-lookup"><span data-stu-id="9b477-128">The [**VideoTemporalDenoisingControl**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol) allows your app to determine if temporal denoising is supported on the current device, and if so, which denoising modes are supported.</span></span> <span data-ttu-id="9b477-129">利用可能な一時的なノイズ除去モードは、[**Off**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode)、[**On**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode)、[**Auto**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode) です。デバイスはすべてのモードをサポートする必要はありませんが、すべてのデバイスは、**Auto** または **On** と **Off** をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9b477-129">The available denoising modes are [**Off**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode), [**On**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode), and [**Auto**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode). A device may not support all modes, but every device must support either **Auto** or **On** and **Off**.</span></span>

<span data-ttu-id="9b477-130">次の例では、シンプルな UI を使用して、ユーザーが一時的なノイズ除去の複数モードを切り替えられるラジオ ボタンを配置します。</span><span class="sxs-lookup"><span data-stu-id="9b477-130">The following example uses a simple UI to provide radio buttons allowing the user to switch between denoising modes.</span></span>

[!code-cs[SnippetDenoiseXAML](./code/BasicMediaCaptureWin10/cs/MainPage.xaml#SnippetDenoiseXAML)]

<span data-ttu-id="9b477-131">次のメソッドでは、[**VideoTemporalDenoisingControl.Supported**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol.supported) プロパティを確認し、現在のデバイスで一時的なノイズ除去がサポートされているかどうかをまず判断します。</span><span class="sxs-lookup"><span data-stu-id="9b477-131">In the following method, the [**VideoTemporalDenoisingControl.Supported**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol.supported) property is checked to see if temporal denoising is supported at all on the current device.</span></span> <span data-ttu-id="9b477-132">サポートされている場合は、さらに **Off** および **Auto** か**On** がサポートされていることを確認し、サポートされていればラジオボタンを表示します。</span><span class="sxs-lookup"><span data-stu-id="9b477-132">If so, then we check to make sure that **Off** and **Auto** or **On** is supported, in which case we make our radio buttons visible.</span></span> <span data-ttu-id="9b477-133">次に **Auto** と **On** のボタンのメソッドがサポートされている場合は、それらのボタンを表示します。</span><span class="sxs-lookup"><span data-stu-id="9b477-133">Next, the **Auto** and **On** buttons are made visible if those methods are supported.</span></span>

[!code-cs[SnippetUpdateDenoiseCapabilities](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetUpdateDenoiseCapabilities)]

<span data-ttu-id="9b477-134">ラジオ ボタンの **Checked** イベント ハンドラーで、ボタン名を確認し、[**VideoTemporalDenoisingControl.Mode**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol.mode) プロパティを設定して、対応するモードを設定します。</span><span class="sxs-lookup"><span data-stu-id="9b477-134">In the **Checked** event handler for the radio buttons, the name of the button is checked and the corresponding mode is set by setting the [**VideoTemporalDenoisingControl.Mode**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol.mode) property.</span></span>

[!code-cs[SnippetDenoiseButtonChecked](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDenoiseButtonChecked)]

### <a name="disabling-temporal-denoising-while-processing-frames"></a><span data-ttu-id="9b477-135">フレームの処理中に一時的なノイズ除去を無効にする</span><span class="sxs-lookup"><span data-stu-id="9b477-135">Disabling temporal denoising while processing frames</span></span>
<span data-ttu-id="9b477-136">一時的なノイズ除去を使用して処理されたビデオは、人間の目にはより快適です。</span><span class="sxs-lookup"><span data-stu-id="9b477-136">Video that has been processed using temporal denoising can be more pleasing to the human eye.</span></span> <span data-ttu-id="9b477-137">しかし一時的なノイズ除去は画像の一貫性に影響を及ぼし、フレーム内の詳細さが低下するため、登録や OCR など、フレーム内の画像処理を行うアプリでは、画像処理を有効にする間、プログラムによる一時的なノイズ除去の無効化が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="9b477-137">However, because temporal denoising can impact image consistency and decrease the amount of details in the frame, apps that perform image processing on the frames, such as registration or optical character recognition, may want to programmatically disable denoising when image processing is enabled.</span></span>

<span data-ttu-id="9b477-138">次の例では、サポートされているノイズ除去モードを判断し、この情報をいくつかのクラス変数に格納します。</span><span class="sxs-lookup"><span data-stu-id="9b477-138">The following example determines which denoising modes are supported and stores this information in some class variables.</span></span>

[!code-cs[SnippetDenoiseFrameReaderVars](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDenoiseFrameReaderVars)]

[!code-cs[SnippetDenoiseCapabilitiesForFrameProcessing](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDenoiseCapabilitiesForFrameProcessing)]

<span data-ttu-id="9b477-139">アプリはフレーム処理を有効にするとき、そのモードがサポートされている場合は、ノイズ除去機能を **Off** に設定します。これにより、フレーム処理がノイズ除去されない未加工のフレームを使用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="9b477-139">When the app enables frame processing, it sets the denoising mode to **Off** if that mode is supported so that the frame processing can use raw frames that have not been denoised.</span></span>

[!code-cs[SnippetEnableFrameProcessing](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetEnableFrameProcessing)]

<span data-ttu-id="9b477-140">アプリはフレーム処理を無効にするとき、サポートされているモードに応じて、ノイズ除去モードを **On** または **Auto** に設定します。</span><span class="sxs-lookup"><span data-stu-id="9b477-140">When the app disables frame prcessing, it sets the denoising mode to **On** or **Auto**, depending on which mode is supported.</span></span>

[!code-cs[SnippetDisableFrameProcessing](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDisableFrameProcessing)]

<span data-ttu-id="9b477-141">画像処理用にビデオ フレームを取得する方法について詳しくは、「[MediaFrameReader を使ったメディア フレームの処理](process-media-frames-with-mediaframereader.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9b477-141">For more information on obtaining video frames for image processing, see [Process media frames with MediaFrameReader](process-media-frames-with-mediaframereader.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="9b477-142">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9b477-142">Related topics</span></span>

* [<span data-ttu-id="9b477-143">カメラ</span><span class="sxs-lookup"><span data-stu-id="9b477-143">Camera</span></span>](camera.md)
* [<span data-ttu-id="9b477-144">MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="9b477-144">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [<span data-ttu-id="9b477-145">MediaFrameReader を使ったメディア フレームの処理</span><span class="sxs-lookup"><span data-stu-id="9b477-145">Process media frames with MediaFrameReader</span></span>](process-media-frames-with-mediaframereader.md)
*  [**<span data-ttu-id="9b477-146">VideoTemporalDenoisingControl</span><span class="sxs-lookup"><span data-stu-id="9b477-146">VideoTemporalDenoisingControl</span></span>**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol)
 




