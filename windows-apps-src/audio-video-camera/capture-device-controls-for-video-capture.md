---
ms.assetid: 708170E1-777A-4E4A-9F77-5AB28B88B107
description: この記事では、ビデオ キャプチャの拡張シナリオ (HDR ビデオ、露出の優先順位など) を手動デバイス制御によって有効にする方法を示します。
title: ビデオ キャプチャのための手動カメラ制御
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f144ef398fc55e79d2f0190c61214cdf1aa93b68
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8348995"
---
# <a name="manual-camera-controls-for-video-capture"></a>ビデオ キャプチャのための手動カメラ制御



この記事では、ビデオ キャプチャの拡張シナリオ (HDR ビデオ、露出の優先順位など) を手動デバイス制御によって有効にする方法を示します。

この記事で説明するビデオ デバイス コントロールはすべて同じパターンを使ってアプリに追加されます。 まず、アプリが実行されている現在のデバイスで、コントロールがサポートされているかどうかを確認します。 コントロールがサポートされている場合は、コントロールに対して必要なモードを設定します。 一般的に、現在のデバイスで特定のコントロールがサポートされていない場合は、ユーザーがその機能を有効にできるような UI 要素を無効または非表示にする必要があります。

この記事で説明するデバイス制御 API はすべて、[**Windows.Media.Devices**](https://msdn.microsoft.com/library/windows/apps/br206902) 名前空間のメンバーです。

[!code-cs[VideoControllersUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVideoControllersUsing)]

> [!NOTE] 
> この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

## <a name="hdr-video"></a>HDR ビデオ

ハイ ダイナミック レンジ (HDR) ビデオ機能では、HDR 処理をキャプチャ デバイスのビデオ ストリームに適用します。 HDR ビデオがサポートされているかどうかを確認するには、[**HdrVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926682) プロパティを選びます。

HDR ビデオ コントロールでは、3 つのモード (オン、オフ、自動) がサポートされています。自動モードでは、HDR ビデオ処理によってメディア キャプチャが改善されるかどうかをデバイスが動的に判断し、改善される場合は HDR ビデオが有効になります。 現在のデバイスで特定のモードがサポートされているかどうかを確認するには、[**HdrVideoControl.SupportedModes**](https://msdn.microsoft.com/library/windows/apps/dn926683) コレクションに目的のモードが含まれているかどうかをチェックします。

HDR ビデオ処理を有効または無効にするには、[**HdrVideoControl.Mode**](https://msdn.microsoft.com/library/windows/apps/dn926681) を目的のモードに設定します。

[!code-cs[SetHdrVideoMode](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetHdrVideoMode)]

## <a name="exposure-priority"></a>露出の優先順位

[**ExposurePriorityVideoControl**](https://msdn.microsoft.com/library/windows/apps/dn926644) は、有効であれば、キャプチャ デバイスからのビデオ フレームを評価し、ローライト シーンのビデオがキャプチャされているかどうかを判断します。 その場合は、各フレームの露出時間を長くし、キャプチャしたビデオの画質を向上するために、キャプチャするビデオのフレーム レートが引き下げられます。

[**ExposurePriorityVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926647) プロパティをチェックして、現在のデバイスで露出の優先順位コントロールがサポートされているかどうかを確認してください。

露出の優先順位コントロールを有効または無効にするには、[**ExposurePriorityVideoControl.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn926646) を目的のモードに設定します。

[!code-cs[EnableExposurePriority](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetEnableExposurePriority)]

## <a name="temporal-denoising"></a>一時的なノイズ除去
Windows 10、バージョン 1803 以降では、デバイスでサポートされている場合、そのデバイスのビデオに対して一時的なノイズ除去を有効できます。 この機能では、隣接する複数のフレームの画像データがリアル タイムで融合されて、画像ノイズの少ないビデオ フレームが生成されます。

アプリは、[**VideoTemporalDenoisingControl**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol) によって、一時的なノイズ除去が現在のデバイスでサポートされているかどうか、またサポートされている場合は、サポートされている一時的なノイズ除去のモードを判定します。 利用可能な一時的なノイズ除去モードは、[**Off**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode)、[**On**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode)、[**Auto**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode) です。デバイスはすべてのモードをサポートする必要はありませんが、すべてのデバイスは、**Auto** または **On** と **Off** をサポートする必要があります。

次の例では、シンプルな UI を使用して、ユーザーが一時的なノイズ除去の複数モードを切り替えられるラジオ ボタンを配置します。

[!code-cs[SnippetDenoiseXAML](./code/BasicMediaCaptureWin10/cs/MainPage.xaml#SnippetDenoiseXAML)]

次のメソッドでは、[**VideoTemporalDenoisingControl.Supported**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol.supported) プロパティを確認し、現在のデバイスで一時的なノイズ除去がサポートされているかどうかをまず判断します。 サポートされている場合は、さらに **Off** および **Auto** か**On** がサポートされていることを確認し、サポートされていればラジオボタンを表示します。 次に **Auto** と **On** のボタンのメソッドがサポートされている場合は、それらのボタンを表示します。

[!code-cs[SnippetUpdateDenoiseCapabilities](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetUpdateDenoiseCapabilities)]

ラジオ ボタンの **Checked** イベント ハンドラーで、ボタン名を確認し、[**VideoTemporalDenoisingControl.Mode**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol.mode) プロパティを設定して、対応するモードを設定します。

[!code-cs[SnippetDenoiseButtonChecked](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDenoiseButtonChecked)]

### <a name="disabling-temporal-denoising-while-processing-frames"></a>フレームの処理中に一時的なノイズ除去を無効にする
一時的なノイズ除去を使用して処理されたビデオは、人間の目にはより快適です。 しかし一時的なノイズ除去は画像の一貫性に影響を及ぼし、フレーム内の詳細さが低下するため、登録や OCR など、フレーム内の画像処理を行うアプリでは、画像処理を有効にする間、プログラムによる一時的なノイズ除去の無効化が必要になることがあります。

次の例では、サポートされているノイズ除去モードを判断し、この情報をいくつかのクラス変数に格納します。

[!code-cs[SnippetDenoiseFrameReaderVars](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDenoiseFrameReaderVars)]

[!code-cs[SnippetDenoiseCapabilitiesForFrameProcessing](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDenoiseCapabilitiesForFrameProcessing)]

アプリはフレーム処理を有効にするとき、そのモードがサポートされている場合は、ノイズ除去機能を **Off** に設定します。これにより、フレーム処理がノイズ除去されない未加工のフレームを使用できるようになります。

[!code-cs[SnippetEnableFrameProcessing](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetEnableFrameProcessing)]

アプリはフレーム処理を無効にするとき、サポートされているモードに応じて、ノイズ除去モードを **On** または **Auto** に設定します。

[!code-cs[SnippetDisableFrameProcessing](./code/BasicMediaCaptureWin10/cs/MainPage.ManualControls.xaml.cs#SnippetDisableFrameProcessing)]

画像処理用にビデオ フレームを取得する方法について詳しくは、「[MediaFrameReader を使ったメディア フレームの処理](process-media-frames-with-mediaframereader.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [MediaFrameReader を使ったメディア フレームの処理](process-media-frames-with-mediaframereader.md)
*  [**VideoTemporalDenoisingControl**](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol)
 




