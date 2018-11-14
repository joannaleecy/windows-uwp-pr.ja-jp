---
author: drewbatgit
ms.assetid: 7DBEE5E2-C3EC-4305-823D-9095C761A1CD
description: この記事では、可変の写真シーケンスをキャプチャする方法について説明します。これによって、画像を複数のフレームとして次々とキャプチャし、各フレームに別々のフォーカス、フラッシュ、ISO、露出、露出補正の設定を適用することができます。
title: 可変の写真シーケンス
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 91a7d69d945b2ba2452d5bc477b6c17bf1dc6845
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6187291"
---
# <a name="variable-photo-sequence"></a><span data-ttu-id="c0e77-104">可変の写真シーケンス</span><span class="sxs-lookup"><span data-stu-id="c0e77-104">Variable photo sequence</span></span>



<span data-ttu-id="c0e77-105">この記事では、可変の写真シーケンスをキャプチャする方法について説明します。これによって、画像を複数のフレームとして次々とキャプチャし、各フレームに別々のフォーカス、フラッシュ、ISO、露出、露出補正の設定を適用することができます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-105">This article shows you how to capture a variable photo sequence, which allows you to capture multiple frames of images in rapid succession and configure each frame to use different focus, flash, ISO, exposure, and exposure compensation settings.</span></span> <span data-ttu-id="c0e77-106">この機能により、ハイ ダイナミック レンジ (HDR) 画像を作成するなどのシナリオが実現できます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-106">This feature enables scenarios like creating High Dynamic Range (HDR) images.</span></span>

<span data-ttu-id="c0e77-107">HDR 画像をキャプチャするときに、独自の処理アルゴリズムを実装しない場合は、[**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) API を使って、Windows に組み込まれた HDR 機能を利用できます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-107">If you want to capture HDR images but don't want to implement your own processing algorithm, you can use the [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) API to use the HDR capabilities built-in to Windows.</span></span> <span data-ttu-id="c0e77-108">詳しくは、「[ハイ ダイナミック レンジ (HDR) 写真のキャプチャ](high-dynamic-range-hdr-photo-capture.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c0e77-108">For more information, see [High Dynamic Range (HDR) photo capture](high-dynamic-range-hdr-photo-capture.md).</span></span>

> [!NOTE] 
> <span data-ttu-id="c0e77-109">この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。</span><span class="sxs-lookup"><span data-stu-id="c0e77-109">This article builds on concepts and code discussed in [Basic photo, video, and audio capture with MediaCapture](basic-photo-video-and-audio-capture-with-MediaCapture.md), which describes the steps for implementing basic photo and video capture.</span></span> <span data-ttu-id="c0e77-110">そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0e77-110">It is recommended that you familiarize yourself with the basic media capture pattern in that article before moving on to more advanced capture scenarios.</span></span> <span data-ttu-id="c0e77-111">この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="c0e77-111">The code in this article assumes that your app already has an instance of MediaCapture that has been properly initialized.</span></span>

## <a name="set-up-your-app-to-use-variable-photo-sequence-capture"></a><span data-ttu-id="c0e77-112">可変の写真シーケンス キャプチャを使うようにアプリを設定する</span><span class="sxs-lookup"><span data-stu-id="c0e77-112">Set up your app to use variable photo sequence capture</span></span>

<span data-ttu-id="c0e77-113">可変の写真シーケンス キャプチャを実装するためには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間が必要となります。</span><span class="sxs-lookup"><span data-stu-id="c0e77-113">In addition to the namespaces required for basic media capture, implementing a variable photo sequence capture requires the following namespaces.</span></span>

[!code-cs[VPSUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVPSUsing)]

<span data-ttu-id="c0e77-114">写真シーケンス キャプチャを開始するために使用される [**VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) オブジェクトを格納するためのメンバー変数を宣言します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-114">Declare a member variable to store the [**VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) object, which is used to initiate the photo sequence capture.</span></span> <span data-ttu-id="c0e77-115">シーケンス内でキャプチャされた各画像を格納するための [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトの配列を宣言します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-115">Declare an array of [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) objects to store each captured image in the sequence.</span></span> <span data-ttu-id="c0e77-116">また、各フレームの [**CapturedFrameControlValues**](https://msdn.microsoft.com/library/windows/apps/dn608020) オブジェクトを格納するための配列も宣言します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-116">Also, declare an array to store the [**CapturedFrameControlValues**](https://msdn.microsoft.com/library/windows/apps/dn608020) object for each frame.</span></span> <span data-ttu-id="c0e77-117">この配列は、画像処理アルゴリズムで、各フレームのキャプチャにどのような設定が使用されたかを確認するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-117">This can be used by your image processing algorithm to determine what settings were used to capture each frame.</span></span> <span data-ttu-id="c0e77-118">最後に、シーケンス内で現在キャプチャされているのがどの画像かを追跡するために使用される、インデックスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-118">Finally, declare an index that will be used to track which image in the sequence is currently being captured.</span></span>

[!code-cs[VPSMemberVariables](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVPSMemberVariables)]

## <a name="prepare-the-variable-photo-sequence-capture"></a><span data-ttu-id="c0e77-119">可変の写真シーケンス キャプチャを準備する</span><span class="sxs-lookup"><span data-stu-id="c0e77-119">Prepare the variable photo sequence capture</span></span>

<span data-ttu-id="c0e77-120">[MediaCapture](capture-photos-and-video-with-mediacapture.md) を初期化した後は、可変の写真シーケンスが現在のデバイスでサポートされていることを確認します。そのためには、[**VariablePhotoSequenceController**](https://msdn.microsoft.com/library/windows/apps/dn640573) のインスタンスをメディア キャプチャの [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) から取得し、[**Supported**](https://msdn.microsoft.com/library/windows/apps/dn640580) プロパティを調べます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-120">After you have initialized your [MediaCapture](capture-photos-and-video-with-mediacapture.md), make sure that variable photo sequences are supported on the current device by getting an instance of the [**VariablePhotoSequenceController**](https://msdn.microsoft.com/library/windows/apps/dn640573) from the media capture's [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) and checking the [**Supported**](https://msdn.microsoft.com/library/windows/apps/dn640580) property.</span></span>

[!code-cs[IsVPSSupported](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetIsVPSSupported)]

<span data-ttu-id="c0e77-121">可変の写真シーケンスのコントローラーから [**FrameControlCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652548) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-121">Get a [**FrameControlCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652548) object from the variable photo sequence controller.</span></span> <span data-ttu-id="c0e77-122">このオブジェクトには、写真シーケンスのフレームごとに構成できるすべての設定のプロパティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c0e77-122">This object has a property for every setting that can be configured per frame of a photo sequence.</span></span> <span data-ttu-id="c0e77-123">次のようなプロパティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c0e77-123">These include:</span></span>

-   [**<span data-ttu-id="c0e77-124">Exposure</span><span class="sxs-lookup"><span data-stu-id="c0e77-124">Exposure</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn652552)
-   [**<span data-ttu-id="c0e77-125">ExposureCompensation</span><span class="sxs-lookup"><span data-stu-id="c0e77-125">ExposureCompensation</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn652560)
-   [**<span data-ttu-id="c0e77-126">Flash</span><span class="sxs-lookup"><span data-stu-id="c0e77-126">Flash</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn652566)
-   [**<span data-ttu-id="c0e77-127">Focus</span><span class="sxs-lookup"><span data-stu-id="c0e77-127">Focus</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn652570)
-   [**<span data-ttu-id="c0e77-128">IsoSpeed</span><span class="sxs-lookup"><span data-stu-id="c0e77-128">IsoSpeed</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn652574)
-   [**<span data-ttu-id="c0e77-129">PhotoConfirmation</span><span class="sxs-lookup"><span data-stu-id="c0e77-129">PhotoConfirmation</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn652578)

<span data-ttu-id="c0e77-130">この例では、フレームごとに異なる露出補正の値を設定します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-130">This example will set a different exposure compensation value for each frame.</span></span> <span data-ttu-id="c0e77-131">現在のデバイスの写真シーケンスで露出補正がサポートされているかどうかを確認するには、**ExposureCompensation** プロパティからアクセスできる [**FrameExposureCompensationCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652628) オブジェクトの [**Supported**](https://msdn.microsoft.com/library/windows/apps/dn278905) プロパティを調べます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-131">To verify that exposure compensation is supported for photo sequences on the current device, check the [**Supported**](https://msdn.microsoft.com/library/windows/apps/dn278905) property of the [**FrameExposureCompensationCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652628) object accessed through the **ExposureCompensation** property.</span></span>

[!code-cs[IsExposureCompensationSupported](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetIsExposureCompensationSupported)]

<span data-ttu-id="c0e77-132">キャプチャする各フレームに対して新しい [**FrameController**](https://msdn.microsoft.com/library/windows/apps/dn652582) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-132">Create a new [**FrameController**](https://msdn.microsoft.com/library/windows/apps/dn652582) object for each frame you want to capture.</span></span> <span data-ttu-id="c0e77-133">この例では、3 つのフレームをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="c0e77-133">This example captures three frames.</span></span> <span data-ttu-id="c0e77-134">フレームごとに変更するコントロールの値を設定します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-134">Set the values for the controls you want to vary for each frame.</span></span> <span data-ttu-id="c0e77-135">次に、**VariablePhotoSequenceController** の [**DesiredFrameControllers**](https://msdn.microsoft.com/library/windows/apps/dn640574) コレクションをクリアし、コレクションに各フレーム コントローラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-135">Then, clear the [**DesiredFrameControllers**](https://msdn.microsoft.com/library/windows/apps/dn640574) collection of the **VariablePhotoSequenceController** and add each frame controller to the collection.</span></span>

[!code-cs[InitFrameControllers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetInitFrameControllers)]

<span data-ttu-id="c0e77-136">キャプチャした画像に対して使用するエンコードを設定するための [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-136">Create an [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) object to set the encoding you want to use for the captured images.</span></span> <span data-ttu-id="c0e77-137">静的メソッド [**MediaCapture.PrepareVariablePhotoSequenceCaptureAsync**](https://msdn.microsoft.com/library/windows/apps/dn608097) を呼び出し、エンコード プロパティを渡します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-137">Call the static method [**MediaCapture.PrepareVariablePhotoSequenceCaptureAsync**](https://msdn.microsoft.com/library/windows/apps/dn608097), passing in the encoding properties.</span></span> <span data-ttu-id="c0e77-138">このメソッドは、[**VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-138">This method returns a [**VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) object.</span></span> <span data-ttu-id="c0e77-139">最後に、[**PhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/dn652573) イベントと [**Stopped**](https://msdn.microsoft.com/library/windows/apps/dn652585) イベントのイベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-139">Finally, register event handlers for the [**PhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/dn652573) and [**Stopped**](https://msdn.microsoft.com/library/windows/apps/dn652585) events.</span></span>

[!code-cs[PrepareVPS](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPrepareVPS)]

## <a name="start-the-variable-photo-sequence-capture"></a><span data-ttu-id="c0e77-140">可変の写真シーケンス キャプチャを開始する</span><span class="sxs-lookup"><span data-stu-id="c0e77-140">Start the variable photo sequence capture</span></span>

<span data-ttu-id="c0e77-141">可変の写真シーケンスのキャプチャを開始するには、[**VariablePhotoSequenceCapture.StartAsync**](https://msdn.microsoft.com/library/windows/apps/dn652577) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-141">To start the capture of the variable photo sequence, call [**VariablePhotoSequenceCapture.StartAsync**](https://msdn.microsoft.com/library/windows/apps/dn652577).</span></span> <span data-ttu-id="c0e77-142">必ず、キャプチャした画像とフレーム コントロールの値を格納するための配列を初期化し、現在のインデックスを 0 に設定してください。</span><span class="sxs-lookup"><span data-stu-id="c0e77-142">Be sure to initialize the arrays for storing the captured images and frame control values and set the current index to 0.</span></span> <span data-ttu-id="c0e77-143">アプリの記録状態の変数を設定し、このキャプチャの進行中は別のキャプチャを開始できないように UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-143">Set your app's recording state variable and update your UI to disable starting another capture while this capture is in progress.</span></span>

[!code-cs[StartVPSCapture](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStartVPSCapture)]

## <a name="receive-the-captured-frames"></a><span data-ttu-id="c0e77-144">キャプチャされたフレームを受け取る</span><span class="sxs-lookup"><span data-stu-id="c0e77-144">Receive the captured frames</span></span>

<span data-ttu-id="c0e77-145">[**PhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/dn652573) イベントは、キャプチャされたフレームごとに発生します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-145">The [**PhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/dn652573) event is raised for each captured frame.</span></span> <span data-ttu-id="c0e77-146">フレーム コントロールの値とフレームのキャプチャされた画像を保存してから、現在のフレームのインデックスを増分します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-146">Save the frame control values and captured image for the frame and then increment the current frame index.</span></span> <span data-ttu-id="c0e77-147">次の例は、各フレームの [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) 表現を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c0e77-147">This example shows how to get a [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) representation of each frame.</span></span> <span data-ttu-id="c0e77-148">**SoftwareBitmap** の使用方法について詳しくは、「[イメージング](imaging.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c0e77-148">For more information on using **SoftwareBitmap**, see [Imaging](imaging.md).</span></span>

[!code-cs[OnPhotoCaptured](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnPhotoCaptured)]

## <a name="handle-the-completion-of-the-variable-photo-sequence-capture"></a><span data-ttu-id="c0e77-149">可変の写真シーケンスのキャプチャの完了を処理する</span><span class="sxs-lookup"><span data-stu-id="c0e77-149">Handle the completion of the variable photo sequence capture</span></span>

<span data-ttu-id="c0e77-150">[**Stopped**](https://msdn.microsoft.com/library/windows/apps/dn652585) イベントは、シーケンス内のすべてのフレームがキャプチャされると発生します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-150">The [**Stopped**](https://msdn.microsoft.com/library/windows/apps/dn652585) event is raised when all of the frames in the sequence have been captured.</span></span> <span data-ttu-id="c0e77-151">アプリの記録状態を更新し、ユーザーが新しいキャプチャを開始できるように UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-151">Update the recording state of your app and update your UI to allow the user to initiate new captures.</span></span> <span data-ttu-id="c0e77-152">この時点で、キャプチャされた画像とフレーム コントロールの値を画像処理コードに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-152">At this point, you can pass the captured images and frame control values to your image processing code.</span></span>

[!code-cs[OnStopped](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnStopped)]

## <a name="update-frame-controllers"></a><span data-ttu-id="c0e77-153">フレーム コントローラーを更新する</span><span class="sxs-lookup"><span data-stu-id="c0e77-153">Update frame controllers</span></span>

<span data-ttu-id="c0e77-154">フレームごとの設定を変更して、可変の写真シーケンス キャプチャを新たに実行する場合、**VariablePhotoSequenceCapture** を完全に再初期化する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c0e77-154">If you want to perform another variable photo sequence capture with different per frame settings, you don't need to completely reinitialize the **VariablePhotoSequenceCapture**.</span></span> <span data-ttu-id="c0e77-155">[**DesiredFrameControllers**](https://msdn.microsoft.com/library/windows/apps/dn640574) コレクションをクリアして新しいフレーム コントローラーを追加するか、または既存のフレーム コントローラーの値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-155">You can either clear the [**DesiredFrameControllers**](https://msdn.microsoft.com/library/windows/apps/dn640574) collection and add new frame controllers or you can modify the existing frame controller values.</span></span> <span data-ttu-id="c0e77-156">次の例では、[**FrameFlashCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652657) オブジェクトを調べて、現在のデバイスが可変の写真シーケンス フレームに対してフラッシュとフラッシュの電源をサポートしているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-156">The following example checks the [**FrameFlashCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652657) object to verify that the current device supports flash and flash power for variable photo sequence frames.</span></span> <span data-ttu-id="c0e77-157">サポートしている場合は、100% の電力でフラッシュを有効にするよう各フレームが更新されます。</span><span class="sxs-lookup"><span data-stu-id="c0e77-157">If so, each frame is updated to enable the flash at 100% power.</span></span> <span data-ttu-id="c0e77-158">各フレームに対して前の手順で設定した露出補正の値は、引き続き有効です。</span><span class="sxs-lookup"><span data-stu-id="c0e77-158">The exposure compensation values that were previously set for each frame are still active.</span></span>

[!code-cs[UpdateFrameControllers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUpdateFrameControllers)]

## <a name="clean-up-the-variable-photo-sequence-capture"></a><span data-ttu-id="c0e77-159">可変の写真シーケンス キャプチャをクリーンアップする</span><span class="sxs-lookup"><span data-stu-id="c0e77-159">Clean up the variable photo sequence capture</span></span>

<span data-ttu-id="c0e77-160">可変の写真シーケンスのキャプチャが完了するか、アプリが中断された場合は、[**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/dn652569) を呼び出して、可変の写真シーケンスのオブジェクトをクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="c0e77-160">When you are done capturing variable photo sequences or your app is suspending, clean up the variable photo sequence object by calling [**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/dn652569).</span></span> <span data-ttu-id="c0e77-161">オブジェクトのイベント ハンドラーの登録を解除し、null に設定します。</span><span class="sxs-lookup"><span data-stu-id="c0e77-161">Unregister the object's event handlers and set it to null.</span></span>

[!code-cs[CleanUpVPS](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpVPS)]

## <a name="related-topics"></a><span data-ttu-id="c0e77-162">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c0e77-162">Related topics</span></span>

* [<span data-ttu-id="c0e77-163">カメラ</span><span class="sxs-lookup"><span data-stu-id="c0e77-163">Camera</span></span>](camera.md)
* [<span data-ttu-id="c0e77-164">MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="c0e77-164">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 




