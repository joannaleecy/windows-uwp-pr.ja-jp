---
title: カメラ バーコード スキャナーのプレビューのホスト
description: アプリケーションでカメラ バーコード スキャナーのプレビューをホストする方法を説明します。
ms.date: 05/1/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 0eb7b1b620fcfa16576d84eaa2564408394d59de
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7826275"
---
# <a name="hosting-a-camera-barcode-scanner-preview-in-your-application"></a><span data-ttu-id="b635d-104">アプリケーションでのカメラ バーコード スキャナーのプレビューのホスト</span><span class="sxs-lookup"><span data-stu-id="b635d-104">Hosting a camera barcode scanner preview in your application</span></span>
## <a name="step-1-setup-your-camera-preview"></a><span data-ttu-id="b635d-105">手順 1: カメラ プレビューをセットアップする</span><span class="sxs-lookup"><span data-stu-id="b635d-105">Step 1: Setup your camera preview</span></span>
<span data-ttu-id="b635d-106">カメラ バーコード スキャナーのアプリケーションにプレビューを追加する最初の手順は、「[カメラ プレビューの表示](../audio-video-camera/simple-camera-preview-access.md)」のトピックで説明している手順に従うことによって実現できます。</span><span class="sxs-lookup"><span data-stu-id="b635d-106">The first step in adding a preview to your application for camera barcode scanner can be accomplished by following the instructions in the [Display the camera preview](../audio-video-camera/simple-camera-preview-access.md) topic.</span></span>  <span data-ttu-id="b635d-107">この手順を完了したら、このトピックに戻って、カメラ バーコード スキャナーに固有の変更を行います。</span><span class="sxs-lookup"><span data-stu-id="b635d-107">Once you have completed this step, return to this topic for camera barcode scanner specific modifications.</span></span>

## <a name="step-2-update-capability-declarations"></a><span data-ttu-id="b635d-108">手順 2: 機能の宣言を更新する</span><span class="sxs-lookup"><span data-stu-id="b635d-108">Step 2: Update capability declarations</span></span>
<span data-ttu-id="b635d-109">マイクについてユーザーの同意を求めるメッセージが表示されないようにするには、アプリ マニフェストの機能の一覧からこの機能を除外します。</span><span class="sxs-lookup"><span data-stu-id="b635d-109">To prevent your users from receiving the consent prompt for microphone you can exclude this from the capabilities listed in your app manifest.</span></span>

1. <span data-ttu-id="b635d-110">Microsoft Visual Studio の**ソリューション エクスプローラー**で、**package.appxmanifest** 項目をダブルクリックしてアプリケーション マニフェストのデザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="b635d-110">In Microsoft Visual Studio, in **Solution Explorer**, open the designer for the application manifest by double-clicking the **package.appxmanifest** item.</span></span>
2. <span data-ttu-id="b635d-111">**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b635d-111">Select the **Capabilities** tab.</span></span>
3. <span data-ttu-id="b635d-112">**[マイク]** のチェック ボックスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="b635d-112">Uncheck the box for **Microphone**</span></span>

 ## <a name="step-3-add-additional-using-directive-for-media-capture"></a><span data-ttu-id="b635d-113">手順 3: メディア キャプチャの using ディレクティブを追加する</span><span class="sxs-lookup"><span data-stu-id="b635d-113">Step 3: Add additional using directive for media capture</span></span>

```Csharp
using Windows.Media.Capture;
```

## <a name="step-4-set-up-your-mediacapture-initialization-settings"></a><span data-ttu-id="b635d-114">手順 4: MediaCapture の初期化設定をセットアップする</span><span class="sxs-lookup"><span data-stu-id="b635d-114">Step 4: Set up your MediaCapture initialization settings</span></span>
<span data-ttu-id="b635d-115">次の例では、[**MediaCaptureInitializationSettings**](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacaptureinitializationsettings) を初期化しています。</span><span class="sxs-lookup"><span data-stu-id="b635d-115">The following example initializes the [**MediaCaptureInitializationSettings**](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacaptureinitializationsettings).</span></span> 

```Csharp
 private void InitCaptureSettings()
{
    _captureInitSettings = new MediaCaptureInitializationSettings();
    _captureInitSettings.VideoDeviceId = BarcodeScanner.VideoDeviceId;
    _captureInitSettings.StreamingCaptureMode = StreamingCaptureMode.Video;
    _captureInitSettings.PhotoCaptureSource = PhotoCaptureSource.VideoPreview;
}
```
## <a name="step-5-associate-your-mediacapture-object-with-the-camera-barcode-scanner"></a><span data-ttu-id="b635d-116">手順 5: MediaCapture オブジェクトをカメラ バーコード スキャナーに関連付ける</span><span class="sxs-lookup"><span data-stu-id="b635d-116">Step 5: Associate your MediaCapture object with the camera barcode scanner</span></span>
<span data-ttu-id="b635d-117">*StartPreviewAsync()* 内の既存の mediaCapture.InitializeAsync() を次のように置換します。</span><span class="sxs-lookup"><span data-stu-id="b635d-117">Replace the existing mediaCapture.InitializeAsync() in *StartPreviewAsync()* with the following:</span></span>

```Csharp
try
    {

        mediaCapture = new MediaCapture();
        await mediaCapture.InitializeAsync(InitCaptureSettings());

        displayRequest.RequestActive();
        DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
    }
```

> [!TIP]
> <span data-ttu-id="b635d-118">アプリケーションでのカメラ プレビューのホストに関するさらに高度なトピックについては、「[カメラ プレビューの表示](https://docs.microsoft.com/windows/uwp/audio-video-camera/simple-camera-preview-access#add-capability-declarations-to-the-app-manifest)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b635d-118">See [Display the camera preview](https://docs.microsoft.com/windows/uwp/audio-video-camera/simple-camera-preview-access#add-capability-declarations-to-the-app-manifest) for more advanced topics on hosting a camera preview in your application.</span></span>
