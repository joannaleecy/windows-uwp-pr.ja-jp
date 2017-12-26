---
author: laurenhughes
description: "この記事では、LowLightFusion クラスを使用してビットマップを処理する方法について説明します。"
title: "低光量 Fusion API を使用したビットマップの処理"
ms.author: lahugh
ms.date: 11/02/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 低光量 Fusion, ビットマップ, 画像処理"
localizationpriority: medium
ms.openlocfilehash: 989571063603a7133f39961b4b32bdc60fc373dc
ms.sourcegitcommit: d0c93d734639bd31f264424ae5b6fead903a951d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2017
---
# <a name="process-bitmaps-with-the-lowlightfusion-api"></a><span data-ttu-id="1d9e5-104">LowLightFusion を使用したビットマップの処理</span><span class="sxs-lookup"><span data-stu-id="1d9e5-104">Process bitmaps with the LowLightFusion API</span></span>

<span data-ttu-id="1d9e5-105">低光量画像は高画質でキャプチャするのが難しい画像です。絞りとセンサー サイズが固定されているモバイル デバイスでは、特にキャプチャするのが難しくなります。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-105">Low-light images are difficult to capture with good image quality, especially on mobile devices with fixed aperture and sensor size.</span></span> <span data-ttu-id="1d9e5-106">低光量を補正するために、デバイスでは露出時間を長くしたり、センサー ゲインを上げたりする場合がありますが、これにより、モーション ブラーが発生したり、画像のノイズが増えたりする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-106">To compensate for low-lighting, devices may increase exposure time or sensor gain, which can lead to motion blur and increased noise in images.</span></span> 

<span data-ttu-id="1d9e5-107">[LowLightFusion class](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion) を使用すると、時間的に非常に近接している複数のフレームからのピクセル情報をサンプリングすることによって、低光量画像の画質が向上します。つまり、短時間のバースト画像によって、ノイズとモーション ブラーが減少します。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-107">The [LowLightFusion class](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion) improves the quality of low-light images by sampling pixel information from multiple frames in close temporal proximity, i.e., short burst images, to reduce noise and motion blur.</span></span> <span data-ttu-id="1d9e5-108">これは、写真編集アプリなどに追加できる便利な機能です。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-108">This is useful capability to add to a photo editing app, for example.</span></span>

<span data-ttu-id="1d9e5-109">この機能は、[AdvancedPhotoCapture クラス](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.AdvancedPhotoCapture)を介して利用することもできます。このクラスでは、必要に応じて、画像のキャプチャの直後に低光量 Fusion アルゴリズムを一連の画像に適用します。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-109">This feature is also made available through the [AdvancedPhotoCapture class](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.AdvancedPhotoCapture), which applies the Low Light Fusion algorithm to a sequence of images directly after the images are captured, if needed.</span></span> <span data-ttu-id="1d9e5-110">この機能の実装方法については、「[低光量写真](https://docs.microsoft.com/windows/uwp/audio-video-camera/high-dynamic-range-hdr-photo-capture#low-light-photo-capture)のキャプチャ」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-110">See [Low-light photo](https://docs.microsoft.com/windows/uwp/audio-video-camera/high-dynamic-range-hdr-photo-capture#low-light-photo-capture) capture to learn how to implement this feature.</span></span>

## <a name="prepare-the-images-for-processing"></a><span data-ttu-id="1d9e5-111">処理する画像を準備する</span><span class="sxs-lookup"><span data-stu-id="1d9e5-111">Prepare the images for processing</span></span>

<span data-ttu-id="1d9e5-112">この例では、[LowLightFusion クラス](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion) および [FileOpenPicker](https://docs.microsoft.com/uwp/api/Windows.Storage.Pickers.FileOpenPicker) を使用して、ユーザーが低光量 Fusion を実行する複数の画像を選択できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-112">In this example, we'll demonstrate how to use the [LowLightFusion class](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion), as well as the [FileOpenPicker](https://docs.microsoft.com/uwp/api/Windows.Storage.Pickers.FileOpenPicker) to allow a user to select multiple images to perform Low Light Fusion on.</span></span>

<span data-ttu-id="1d9e5-113">最初に、アルゴリズムで受け入れる画像の枚数 (フレームとも呼ばれます) を決定し、これらのフレームを格納するリストを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-113">First, we'll need to determine how many images (also known as frames) the algorithm accepts, and create a list to hold these frames.</span></span>

[!code-cs[SnippetGetMaxLLFFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetGetMaxLLFFrames)]

<span data-ttu-id="1d9e5-114">低光量 Fusion アルゴリズムで受け入れるフレームの枚数を決定したら、[FileOpenPicker](https://docs.microsoft.com/uwp/api/Windows.Storage.Pickers.FileOpenPicker) を使用して、アルゴリズムで利用される画像をユーザーが選択できるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-114">Once we determine how many frames the Low Light Fusion algorithm accepts, we can use the [FileOpenPicker](https://docs.microsoft.com/uwp/api/Windows.Storage.Pickers.FileOpenPicker) to allow the user to choose which images should be used in the algorithm.</span></span>

[!code-cs[SnippetGetFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetGetFrames)]

<span data-ttu-id="1d9e5-115">適切な枚数のフレームが選択されているので、次に、フレームを [SoftwareBitmaps](https://docs.microsoft.com/uwp/api/Windows.Graphics.Imaging.SoftwareBitmap) にデコードし、SoftwareBitmaps が LowLightFusion の正しい形式になっていることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-115">Now that we have the correct number of frames selected, we need to decode the frames into [SoftwareBitmaps](https://docs.microsoft.com/uwp/api/Windows.Graphics.Imaging.SoftwareBitmap) and ensure that the SoftwareBitmaps are in the correct format for LowLightFusion.</span></span>

[!code-cs[SnippetDecodeFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetDecodeFrames)]


## <a name="fuse-the-bitmaps-into-a-single-bitmap"></a><span data-ttu-id="1d9e5-116">複数のビットマップを 1 つのビットマップに合成する</span><span class="sxs-lookup"><span data-stu-id="1d9e5-116">Fuse the bitmaps into a single bitmap</span></span>

<span data-ttu-id="1d9e5-117">適切な枚数のフレームが受け付け可能な形式になっているので、次に、**[FuseAsync](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion#Windows_Media_Core_LowLightFusion_FuseAsync_Windows_Foundation_Collections_IIterable_Windows_Graphics_Imaging_SoftwareBitmap__)** メソッドを使用して、低光量 Fusion アルゴリズムを適用します。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-117">Now that we have a correct number of frames in an acceptable format, we can use the **[FuseAsync](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion#Windows_Media_Core_LowLightFusion_FuseAsync_Windows_Foundation_Collections_IIterable_Windows_Graphics_Imaging_SoftwareBitmap__)** method to apply the Low Light Fusion algorithm.</span></span> <span data-ttu-id="1d9e5-118">結果として生成される処理済みの画像は、鮮明度が向上しており、SoftwareBitmap の形式になります。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-118">Our result will be the processed image, with improved clarity, in the form of a SoftwareBitmap.</span></span> 

[!code-cs[SnippetFuseFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetFuseFrames)]

<span data-ttu-id="1d9e5-119">最後に、ユーザーが使い慣れた "通常" の画像形式 (作業を開始したときと同様の画像形式) にエンコードし保存することによって、生成された SoftwareBitmap をクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-119">Finally, we'll clean up the resulting SoftwareBitmap by encoding and saving it into a user friendly, "regular" image, similar to the input images that we started with.</span></span>

[!code-cs[SnippetEncodeFrame](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetEncodeFrame)]


## <a name="before-and-after"></a><span data-ttu-id="1d9e5-120">適用前と適用後</span><span class="sxs-lookup"><span data-stu-id="1d9e5-120">Before and after</span></span>

<span data-ttu-id="1d9e5-121">2 つの入力画像と、低光量 Fusion アルゴリズムを適用した結果の出力画像の例を示します。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-121">Here's an example of two input images and the resulting output image after applying the Low Light Fusion algorithm.</span></span>

> [!div class="mx-tableFixed"] 
| <span data-ttu-id="1d9e5-122">フレーム 1</span><span class="sxs-lookup"><span data-stu-id="1d9e5-122">Frame 1</span></span> | <span data-ttu-id="1d9e5-123">フレーム 2</span><span class="sxs-lookup"><span data-stu-id="1d9e5-123">Frame 2</span></span> | <span data-ttu-id="1d9e5-124">低光量 Fusion による出力</span><span class="sxs-lookup"><span data-stu-id="1d9e5-124">Low Light Fusion Output</span></span> | 
|---------|---------|-------------------------|
| ![低光量 Fusion アルゴリズムを適用する最初の入力](./images/LLF-Input1.png) | ![低光量 Fusion アルゴリズムを適用する 2 番目の入力](./images/LLF-Input2.png) | ![低光量 Fusion アルゴリズムを適用した結果のフレーム](./images/LLF-Output.png) |

<span data-ttu-id="1d9e5-128">入力フレーム、およびカップのライティングと鮮明度が改善された出力フレームを見ると、周囲に写っているもの (カーペットの横にある装飾物など) の鮮明度が改善されたことも確認できます。</span><span class="sxs-lookup"><span data-stu-id="1d9e5-128">You can see from the input frames and the output frame that the lighting and clarity of the cup has been improved, as well as the clarity of the surroundings, such as the molding next to the carpet.</span></span>

## <a name="related-topics"></a><span data-ttu-id="1d9e5-129">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1d9e5-129">Related topics</span></span> 
[<span data-ttu-id="1d9e5-130">LowLightFusion クラス</span><span class="sxs-lookup"><span data-stu-id="1d9e5-130">LowLightFusion Class</span></span>](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion)  
[<span data-ttu-id="1d9e5-131">LowLightFusionResult クラス</span><span class="sxs-lookup"><span data-stu-id="1d9e5-131">LowLightFusionResult Class</span></span>](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusionresult)