---
author: drewbatgit
ms.assetid: 66d0c3dc-81f6-4d9a-904b-281f8a334dd0
description: "この記事では、MediaCapture クラスを使用して写真やビデオをキャプチャする最も簡単な方法を示します。"
title: "MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ"
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: dbdc65fb842c6f8d6439f0041a33d991e27bd6b6
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="basic-photo-video-and-audio-capture-with-mediacapture"></a>MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

この記事では、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture) クラスを使用して写真やビデオをキャプチャする最も簡単な方法を示します。 **MediaCapture** クラスは、キャプチャ パイプラインに対する低レベルの制御を提供し、高度なキャプチャ シナリオを実現する、堅牢な一連の API を公開しますが、この記事では基本的なメディア キャプチャをアプリにすばやく簡単に追加できるようにすることを目的としています。 **MediaCapture** が提供する機能について詳しくは、「[**カメラ**](camera.md)」をご覧ください。

写真やビデオをキャプチャするだけで、他のメディア キャプチャ機能を追加しない場合や、独自のカメラ UI を作成する必要がない場合は、[**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.CameraCaptureUI) クラスを使用することができます。このクラスによって、単に Windows の組み込みカメラ アプリを起動し、キャプチャされた写真やビデオのファイルを受信することができます。 詳しくは、「[**Windows の組み込みカメラ UI を使った写真とビデオのキャプチャ**](capture-photos-and-video-with-cameracaptureui.md)」をご覧ください。

この記事のコードは、[**カメラのスターター キット**](https://go.microsoft.com/fwlink/?linkid=619479)のサンプルを基にしています。 このサンプルをダウンロードし、該当するコンテキストで使用されているコードを確認することも、サンプルを独自のアプリの開始点として使用することもできます。

## <a name="add-capability-declarations-to-the-app-manifest"></a>アプリ マニフェストに機能宣言を追加する

アプリからデバイスのカメラにアクセスするには、アプリでデバイス機能 (*webcam* と *microphone*) の使用を宣言する必要があります。 キャプチャした写真とビデオをユーザーの画像ライブラリまたはビデオ ライブラリに保存する場合は、*picturesLibrary* 機能と *videosLibrary* 機能も宣言する必要があります。

**アプリ マニフェストに機能を追加するには**

1.  Microsoft Visual Studio では、**ソリューション エクスプローラー**で **package.appxmanifest** 項目をダブルクリックし、アプリケーション マニフェストのデザイナーを開きます。
2.  **[機能]** タブをクリックします。
3.  **[Web カメラ]** のボックスと **[マイク]** のボックスをオンにします。
4.  画像ライブラリとビデオ ライブラリにアクセスするには、**画像ライブラリ**のボックスと**ビデオ ライブラリ**のボックスをオンにします。


## <a name="initialize-the-mediacapture-object"></a>MediaCapture オブジェクトを初期化する
この記事で説明されているすべてのキャプチャ メソッドでは、最初の手順として、コンストラクターを呼び出した後、[**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.InitializeAsync) を呼び出すことによって、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture) オブジェクトを初期化する必要があります。 **MediaCapture** オブジェクトはアプリで複数の場所からアクセスされるため、このオブジェクトを保持するためのクラス変数を宣言します。  キャプチャ操作に失敗した場合に通知されるように、**MediaCapture** オブジェクトの [**Failed**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.Failed) イベントのハンドラーを実装します。

[!code-cs[DeclareMediaCapture](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeclareMediaCapture)]

[!code-cs[InitMediaCapture](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetInitMediaCapture)]

## <a name="set-up-the-camera-preview"></a>カメラ プレビューの設定
**MediaCapture** を使用して写真、ビデオ、オーディオをキャプチャする場合、カメラのプレビューを表示しないこともできますが、通常は、ユーザーがキャプチャされる内容を確認できるようにプレビュー ストリームを表示する必要があります。 また、オート フォーカス、自動露出、オート ホワイト バランスなど、**MediaCapture** の一部の機能を有効にするには、プレビュー ストリームが実行されている必要があります。 カメラ プレビューを設定する方法については、「[**カメラ プレビューの表示**](simple-camera-preview-access.md)」をご覧ください。

## <a name="capture-a-photo-to-a-softwarebitmap"></a>SoftwareBitmap への写真のキャプチャ
[**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.SoftwareBitmap) クラスは、複数の機能間で共通の画像表現を提供するために、Windows 10 で導入されました。 写真をキャプチャした後、ファイルにキャプチャするのではなく、XAML で表示するなど、キャプチャしたイメージをアプリですぐに使用する場合は、**SoftwareBitmap** にキャプチャする必要があります。 後で画像をディスクに保存するオプションもあります。

**MediaCapture** オブジェクトを初期化した後、[**LowLagPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagPhotoCapture) クラスを使用して、写真を **SoftwareBitmap** にキャプチャできます。 このクラスのインスタンスを取得するには、[**PrepareLowLagPhotoCaptureAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.PrepareLowLagPhotoCaptureAsync) を呼び出して、必要な画像形式を指定する [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.ImageEncodingProperties)オブジェクトを渡します。 [**CreateUncompressed**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.ImageEncodingProperties.CreateUncompressed) は、指定されたピクセル形式で非圧縮エンコードを作成します。 写真をキャプチャするには、[**CaptureAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagPhotoCapture.CaptureAsync) を呼び出します。これは、[**CapturedPhoto**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.CapturedPhoto) オブジェクトを返します。 **SoftwareBitmap** を取得するには、[**Frame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.CapturedPhoto.Frame) プロパティにアクセスし、次に [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.CapturedFrame.SoftwareBitmap) プロパティにアクセスします。

必要に応じて、**CaptureAsync** を繰り返し呼び出して、複数の写真をキャプチャできます。 キャプチャが完了したら、[**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.AdvancedPhotoCapture.FinishAsync) を呼び出して **LowLagPhotoCapture** セッションをシャットダウンし、関連するリソースを解放します。 **FinishAsync** を呼び出した後、再び写真のキャプチャを開始するには、もう一度 [**PrepareLowLagPhotoCaptureAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.PrepareLowLagPhotoCaptureAsync) を呼び出して、キャプチャ セッションを再初期化してから、[**CaptureAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagPhotoCapture.CaptureAsync) を呼び出す必要があります。

[!code-cs[CaptureToSoftwareBitmap](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetCaptureToSoftwareBitmap)]

XAML ページに表示する方法など、**SoftwareBitmap** オブジェクトの操作について詳しくは、「[**ビットマップ画像の作成、編集、保存**](imaging.md)」をご覧ください。

## <a name="capture-a-photo-to-a-file"></a>ファイルへの写真のキャプチャ
典型的な写真アプリでは、キャプチャした写真をディスクやクラウド ストレージに保存し、写真の向きなどのメタデータをファイルに追加する必要があります。 次の例では、ファイルに写真をキャプチャする方法を示します。 後で画像ファイルから **SoftwareBitmap** を作成するオプションもあります。 

この例で示されている方法では、写真をインメモリ ストリームにキャプチャし、写真をストリームからディスク上のファイルにコード変換します。 この例では、[**GetLibraryAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.StorageLibrary.GetLibraryAsync) を使ってユーザーのピクチャ ライブラリを取得し、次に [**SaveFolder**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.StorageLibrary.SaveFolder) プロパティを使って既定の保存フォルダーを取得します。 このフォルダーにアクセスするには、必ず**ピクチャ ライブラリ**機能をアプリ マニフェストに追加してください。 [**CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.StorageFolder.CreateFileAsync) は、写真の保存先となる新しい [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.StorageFile) を作成します。

[**InMemoryRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.Streams.InMemoryRandomAccessStream) を作成し、[**CapturePhotoToStreamAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.CapturePhotoToStreamAsync) を呼び出して、ストリームと、使用する画像形式を指定する [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.ImageEncodingProperties) オブジェクトを渡して、写真をストリームにキャプチャします。 自分でオブジェクトを初期化することによって、カスタム エンコード プロパティを作成することもできますが、このクラスには、[**ImageEncodingProperties.CreateJpeg**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.ImageEncodingProperties.CreateJpeg) など、一般的なエンコード形式用の静的メソッドが用意されています。 次に、[**OpenAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.StorageFile.OpenAsync) を呼び出すことにより、出力ファイルへのファイル ストリームを作成します。 [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.BitmapDecoder) を作成して、インメモリ ストリームから画像をデコードします。次に、[**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.BitmapEncoder) を作成して、[**CreateForTranscodingAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.BitmapEncoder.CreateForTranscodingAsync) を呼び出すことによって画像をファイルにエンコードします。

必要に応じて、[**BitmapPropertySet**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.BitmapPropertySet) オブジェクトを作成し、イメージ エンコーダーで [**SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252.aspx) を呼び出して、画像ファイルに写真に関するメタデータを含めることができます。 エンコード プロパティについて詳しくは、「[**画像のメタデータ**](image-metadata.md)」をご覧ください。 デバイスの向きを正しく処理することは、ほとんどの写真アプリに不可欠です。 詳しくは、「[**MediaCapture を使ってデバイスの向きを処理する**](handle-device-orientation-with-mediacapture.md)」をご覧ください。

最後に、エンコーダー オブジェクトで [**FlushAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.BitmapEncoder.FlushAsync) を呼び出して、写真をインメモリ ストリームからファイルにコード変換します。

[!code-cs[CaptureToFile](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetCaptureToFile)]

ファイルとフォルダーの操作について詳しくは、「[**ファイル、フォルダー、およびライブラリ**](https://msdn.microsoft.com/windows/uwp/files/index)」をご覧ください。

## <a name="capture-a-video"></a>ビデオのキャプチャ
アプリにビデオ キャプチャ機能をすばやく追加するには、[**LowLagMediaRecording**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording) クラスを使用します。 最初に、オブジェクト用のクラス変数を宣言します。

[!code-cs[LowLagMediaRecording](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetLowLagMediaRecording)]

次に、ビデオの保存先となる **StorageFile** オブジェクトを作成します。 この例に示すように、ユーザーのビデオ ライブラリに保存するには、**ビデオ ライブラリ** 機能をアプリ マニフェストに追加する必要があることに注意してください。 [**PrepareLowLagRecordToStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.PrepareLowLagRecordToStorageFileAsync) を呼び出して、ストレージ ファイルと、ビデオのエンコードを指定する [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.MediaEncodingProfile) オブジェクトを渡すことにより、メディアの記録を初期化します。 このクラスには、[**CreateMp4**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.MediaEncodingProfile.CreateMp4) など、一般的なエンコード プロファイルを作成するための静的メソッドが用意されています。

最後に、[**StartAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.StartAsync) を呼び出してビデオのキャプチャを開始します。

[!code-cs[StartVideoCapture](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStartVideoCapture)]

ビデオの録画を停止するには、[**StopAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.StopAsync) を呼び出します。

[!code-cs[StopRecording](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStopRecording)]

**StartAsync** と **StopAsync** の呼び出しを続行して、他のビデオをキャプチャすることもできます。 ビデオのキャプチャが完了したら、[**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.FinishAsync) を呼び出して、キャプチャ セッションを破棄し、関連付けられているリソースをクリーンアップします。 この呼び出しの後は、再び **PrepareLowLagRecordToStorageFileAsync** を呼び出してキャプチャ セッションを再初期化してから、**StartAsync** を呼び出す必要があります。

[!code-cs[FinishAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetFinishAsync)]

ビデオをキャプチャするときに、**MediaCapture** オブジェクトの [**RecordLimitationExceeded**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.RecordLimitationExceeded) イベントのハンドラーを登録する必要があります。このイベントは、1 つの録画の上限 (現在は 3 時間) を超える場合に、オペレーティング システムによって生成されます。 このイベントのハンドラーで、[**StopAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.StopAsync) を呼び出して録画を完了する必要があります。

[!code-cs[RecordLimitationExceeded](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetRecordLimitationExceeded)]

[!code-cs[RecordLimitationExceededHandler](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetRecordLimitationExceededHandler)]

## <a name="pause-and-resume-video-recording"></a>ビデオ録画の一時停止と再開
[**PauseAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.PauseAsync) と [**ResumeAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.ResumeAsync) を呼び出すことによって、ビデオの録画を一時停止し、別の出力ファイルを作成せずに録画を再開することができます

[!code-cs[PauseRecordingSimple](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetPauseRecordingSimple)]

[!code-cs[ResumeRecordingSimple](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetResumeRecordingSimple)]

Windows 10 バージョン 1607 以降では、ビデオの録画を一時停止し、録画を一時停止する前にキャプチャされた最後のフレームを受信できます。 このフレームをカメラ プレビューにオーバーレイすることにより、ユーザーは、録画を再開する前に、一時停止したフレームとカメラの位置合わせをすることができます。 [**PauseWithResultAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.PauseWithResultAsync) を呼び出すと、[**MediaCapturePauseResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapturePauseResult) オブジェクトが返されます。 [**LastFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapturePauseResult.LastFrame) プロパティは、最後のフレームを表す [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.VideoFrame) オブジェクトです。 XAML でこのフレームを表示するには、ビデオ フレームの **SoftwareBitmap** 表現を取得します。 現時点では、BGRA8 形式、プリマルチプライ済みまたは空のアルファ チャネルの画像のみがサポートされているため、適切な形式を取得するには、必要に応じて、[**Convert**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.SoftwareBitmap.Covert) を呼び出します。  新しい [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.Imaging.SoftwareBitmapSource) オブジェクトを作成し、[**SetBitmapAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.Imaging.SoftwareBitmapSource.SetBitmapAsync) を呼び出して初期化します。 最後に、XAML の [**Image**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Image) コントロールの **Source** プロパティを設定して画像を表示します。 この方法が機能するには、画像が **CaptureElement** コントロールと整列されており、不透明度の値が 1 未満である必要があります。 UI は UI スレッドでのみ変更できるため、[**RunAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Core.CoreDispatcher.RunAsync) 内でこの呼び出しを行ってください。

**PauseWithResultAsync** は、録画された合計時間を追跡する必要がある場合に、前のセグメントで録画されたビデオの持続時間も返します。

[!code-cs[PauseCaptureWithResult](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetPauseCaptureWithResult)]

録画を再開するときは、画像のソースを null に設定し、非表示にすることができます。

[!code-cs[ResumeCaptureWithResult](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetResumeCaptureWithResult)]

[**StopWithResultAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.StopWithResultAsync) を呼び出すことによってビデオを停止したときに、結果のフレームを取得することもできます。


## <a name="capture-audio"></a>オーディオのキャプチャ 
前に示したビデオのキャプチャと同じ手法を用いて、アプリにオーディオ キャプチャ機能を簡単に追加することができます。 次の例では、アプリケーション データ フォルダーに **StorageFile** を作成します。 [**PrepareLowLagRecordToStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.PrepareLowLagRecordToStorageFileAsync) を呼び出して、ファイルと、[**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.MediaEncodingProfile) を渡すことによって、キャプチャ セッションを初期化します。この例では、MediaEncodingProfile は静的メソッド [**CreateMp3**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.MediaEncodingProfile.CreateMp3) によって生成されます。 録音を開始するには、[**StartAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.StartAsync) を呼び出します。

[!code-cs[StartAudioCapture](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStartAudioCapture)]


[**StopAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagPhotoSequenceCapture.StopAsync) を呼び出して、オーディオの録音を停止します。

[!code-cs[StopRecording](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStopRecording)]

**StartAsync** と **StopAsync** を複数回呼び出して、複数のオーディオ ファイルを録音します。 オーディオのキャプチャが完了したら、[**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.LowLagMediaRecording.FinishAsync) を呼び出して、キャプチャ セッションを破棄し、関連付けられているリソースをクリーンアップします。 この呼び出しの後は、再び **PrepareLowLagRecordToStorageFileAsync** 呼び出してキャプチャ セッションを再初期化してから、**StartAsync** を呼び出す必要があります。

[!code-cs[FinishAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetFinishAsync)]

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [Windows の組み込みカメラ UI を使った写真とビデオのキャプチャ](capture-photos-and-video-with-cameracaptureui.md)
* [MediaCapture を使ってデバイスの向きを処理する](handle-device-orientation-with-mediacapture.md)
* [ビットマップ画像の作成、編集、保存](imaging.md)
* [ファイル、フォルダー、およびライブラリ](https://msdn.microsoft.com/windows/uwp/files/index)

