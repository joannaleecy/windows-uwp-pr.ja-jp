---
title: カメラ バーコード スキャナーのプレビューのホスト
description: アプリケーションでカメラ バーコード スキャナーのプレビューをホストする方法を説明します。
ms.date: 05/02/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 49d531ea2e699afaf7cfb6872fe0287c6d6a8f85
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610297"
---
# <a name="hosting-a-camera-barcode-scanner-preview-in-your-application"></a>アプリケーションでのカメラ バーコード スキャナーのプレビューのホスト
## <a name="step-1-setup-your-camera-preview"></a>手順 1:プレビュー版のカメラをセットアップします。
カメラ バーコード スキャナーのアプリケーションにプレビューを追加する最初の手順は、「[カメラ プレビューの表示](../audio-video-camera/simple-camera-preview-access.md)」のトピックで説明している手順に従うことによって実現できます。  この手順を完了したら、このトピックに戻って、カメラ バーコード スキャナーに固有の変更を行います。

## <a name="step-2-update-capability-declarations"></a>手順 2:更新プログラム機能の宣言
マイクについてユーザーの同意を求めるメッセージが表示されないようにするには、アプリ マニフェストの機能の一覧からこの機能を除外します。

1. Microsoft Visual Studio の**ソリューション エクスプローラー**で、**package.appxmanifest** 項目をダブルクリックしてアプリケーション マニフェストのデザイナーを開きます。
2. **[機能]** タブをクリックします。
3. **[マイク]** のチェック ボックスをオフにします。

 ## <a name="step-3-add-additional-using-directive-for-media-capture"></a>手順 3:追加のメディアのキャプチャの using ディレクティブを追加

```Csharp
using Windows.Media.Capture;
```

## <a name="step-4-set-up-your-mediacapture-initialization-settings"></a>手順 4:MediaCapture 初期化設定を設定します。
次の例では、[**MediaCaptureInitializationSettings**](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacaptureinitializationsettings) を初期化しています。 

```Csharp
 private void InitCaptureSettings()
{
    _captureInitSettings = new MediaCaptureInitializationSettings();
    _captureInitSettings.VideoDeviceId = BarcodeScanner.VideoDeviceId;
    _captureInitSettings.StreamingCaptureMode = StreamingCaptureMode.Video;
    _captureInitSettings.PhotoCaptureSource = PhotoCaptureSource.VideoPreview;
}
```
## <a name="step-5-associate-your-mediacapture-object-with-the-camera-barcode-scanner"></a>手順 5:カメラのバーコード スキャナー、MediaCapture オブジェクトを関連付ける
*StartPreviewAsync()* 内の既存の mediaCapture.InitializeAsync() を次のように置換します。

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
> アプリケーションでのカメラ プレビューのホストに関するさらに高度なトピックについては、「[カメラ プレビューの表示](https://docs.microsoft.com/windows/uwp/audio-video-camera/simple-camera-preview-access#add-capability-declarations-to-the-app-manifest)」を参照してください。
