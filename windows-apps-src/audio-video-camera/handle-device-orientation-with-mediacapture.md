---
author: drewbatgit
ms.assetid: af3941c0-3508-4ba2-a79e-fc71657c605f
description: この記事では、写真とビデオをキャプチャするときに、ヘルパー クラスを使ってデバイスの向きを処理する方法について説明します。
title: MediaCapture を使ってデバイスの向きを処理する
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 1367c880bd6dde573ab4fc30733ed9d1fefa6b0b
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5617689"
---
# <a name="handle-device-orientation-with-mediacapture"></a>MediaCapture を使ってデバイスの向きを処理する
アプリ外での表示を目的とする写真やビデオ (ユーザーのデバイスにファイルを保存する場合や、オンラインで共有する場合など) をアプリでキャプチャする際は、別のアプリやデバイスで画像を表示するときに正しい向きで表示されるよう、適切な向きのメタデータを使って画像をエンコーディングすることが重要です。 メディア ファイルにどの向きのデータを含めれば良いか特定するのは複雑な作業です。これは、デバイス シャーシの向き、ディスプレイの向き、シャーシ上のカメラの位置 (全面カメラか背面カメラか) など、考慮すべき変数が複数あるためです。 

そこで、向きの処理のプロセスを簡略化するために、**CameraRotationHelper** というヘルパー クラスを使うことをお勧めします。完全な定義についてはこの記事の最後に記載しています。 このクラスをプロジェクトに追加し、本記事の手順に従えば、カメラ アプリに向きのサポートを追加することができます。 また、このヘルパー クラスによって、カメラ UI のコントロールの回転が容易になり、ユーザーの視点から正しくレンダリングされるようになります。

> [!NOTE] 
> この記事の内容は、「[**MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ**](basic-photo-video-and-audio-capture-with-mediacapture.md)」で取り上げたコードや概念に基づいています。 **MediaCapture** クラスの使用についての基本概念を理解してから、向きのサポートをアプリに追加することをお勧めします。

## <a name="namespaces-used-in-this-article"></a>この記事で使われている名前空間
この記事のコード例では、次の名前空間の API を使っています。自分でコードを記述する際はこれらを含める必要があります。 

[!code-cs[OrientationUsing](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetOrientationUsing)]

アプリに向きのサポートを追加するにはまず、ディスプレイをロックして、デバイスの回転時にディスプレイが自動的に回転しないようにします。 UI の自動回転はほとんどの種類のアプリに適していますが、カメラ プレビューについては、回転するとユーザーが操作しにくくなります。 [**DisplayInformation.AutoRotationPreferences**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Display.DisplayInformation.AutoRotationPreferences) プロパティを [**DisplayOrientations.Landscape**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Display.DisplayOrientations) に設定してディスプレイの向きをロックします。 

[!code-cs[AutoRotationPreference](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetAutoRotationPreference)]

## <a name="tracking-the-camera-device-location"></a>カメラ デバイスの位置情報を追跡する
キャプチャしたメディアの正しい向きを計算するには、シャーシ上のカメラ デバイスの位置情報をアプリで特定する必要があります。 ブール値メンバー変数を追加して、(USB 接続型 Web カメラなどのように) カメラがデバイスの外部にあるかどうかを追跡します。 プレビューを左右反転すべきかどうかを追跡するための別のブール変数を追加します。左右反転は、正面カメラが使われている場合に必要になります。 また、選択されたカメラを表す **DeviceInformation** オブジェクトを格納するための変数を追加します。

[!code-cs[CameraDeviceLocationBools](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetCameraDeviceLocationBools)]
[!code-cs[DeclareCameraDevice](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeclareCameraDevice)]

## <a name="select-a-camera-device-and-initialize-the-mediacapture-object"></a>カメラ デバイスを選択し MediaCapture オブジェクトを初期化する
「[**MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ**](basic-photo-video-and-audio-capture-with-mediacapture.md)」では、数行のコードで **MediaCapture** オブジェクトを初期化する方法について説明しています。 カメラの向きをサポートするために、少しだけこの初期化プロセスに手順を追加します。

まず、[**DeviceClass.VideoCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.DeviceClass) というデバイス セレクターを渡して [**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.DeviceInformation.FindAllAsync) を呼び出し、利用可能なすべてのビデオ キャプチャ デバイスの一覧を取得します。 次に、カメラのパネル位置が認識されていて、かつ、指定した値とそのパネル位置が一致するものの中で、一覧の最も上にあるデバイスを選択します。この例では、正面カメラになります。 目的のパネルでカメラが見つからない場合は、先頭にあるカメラか、既定の利用可能なカメラが使用されます。

カメラ デバイスが見つかった場合、新しい [**MediaCaptureInitializationSettings**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureInitializationSettings) オブジェクトを作成し、選択したデバイスに [**VideoDeviceId**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureInitializationSettings.VideoDeviceId) プロパティを設定します。 次に、MediaCapture オブジェクトを作成し、設定オブジェクトを渡して [**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.InitializeAsync) を呼び出し、選択したカメラを使うようシステムに指示します。

最後に、選択したデバイスのパネルが null または unknown になっているかどうかを確認します。 このいずれかであれば、カメラは外付けのものなので、カメラの回転はデバイスの回転とは無関係ということになります。 パネルが認識されていてデバイス シャーシの全面にある場合は、プレビューを左右反転する必要があるため、プレビューを追跡する変数を設定します。

[!code-cs[InitMediaCaptureWithOrientation](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetInitMediaCaptureWithOrientation)]
## <a name="initialize-the-camerarotationhelper-class"></a>CameraRotationHelper クラスを初期化する

ここから **CameraRotationHelper** クラスを使い始めます。 オブジェクトを格納するためのクラス メンバー変数を宣言し、 選択されたカメラの筐体の位置を渡して、コンストラクターを呼び出します。 このヘルパー クラスでは、この情報を使用して、キャプチャしたメディア、プレビュー ストリーム、および UI の正しい向きを計算します。 そして、このヘルパー クラスの **OrientationChanged** イベントのハンドラーを登録します。このイベントは、UI やプレビュー ストリームの向きを更新する必要がある場合に発生します。

[!code-cs[DeclareRotationHelper](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeclareRotationHelper)]

[!code-cs[InitRotationHelper](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetInitRotationHelper)]

## <a name="add-orientation-data-to-the-camera-preview-stream"></a>カメラのプレビュー ストリームに向きのデータを追加する
プレビュー ストリームのメタデータに正しい向きを追加しても、ユーザーに表示されるプレビューには影響しませんが、プレビュー ストリームからキャプチャされるフレームをシステムが正しくエンコーディングしやすくなります。

[**MediaCapture.StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.StartPreviewAsync) を呼び出してカメラ プレビューを開始します。 その前に、(正面カメラのために) プレビューを左右反転する必要があるかどうか、メンバー変数を確認してください。 左右反転する必要があれば、[**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.CaptureElement) の [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティ (この例では *PreviewControl* という名前になっています) を [**FlowDirection.RightToLeft**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.FlowDirection) に設定します。 プレビューを開始したら、**SetPreviewRotationAsync** というヘルパー メソッドを呼び出してプレビューの回転を設定します。 以下に、このメソッドの実装を示します。

[!code-cs[StartPreviewWithRotationAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStartPreviewWithRotationAsync)]

スマートフォンの向きが変わったときプレビュー ストリームを再初期化することなく更新できるように、プレビューの回転を別個のメソッドに設定します。 外付けのカメラの場合、処理は行われませんが、 それ以外の場合は **CameraRotationHelper** メソッドの **GetCameraPreviewOrientation** が呼び出され、プレビュー ストリームの正しい向きが返されます。 

メタデータを設定するには [**VideoDeviceController.GetMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Devices.VideoDeviceController.GetMediaStreamProperties) を呼び出して、プレビュー ストリームのプロパティを取得します。 次に、ビデオ ストリームの回転状態のメディア ファンデーション トランスフォーム (MFT) 属性を表す GUID を作成します。 C++ では [**MF_MT_VIDEO_ROTATION**](https://msdn.microsoft.com/library/windows/desktop/hh162880.aspx) 定数を使用できますが、C# では GUID 値を手動で指定する必要があります。 

キーに GUID を、値にプレビューの回転を指定して、ストリーム プロパティ オブジェクトにプロパティ値を追加します。 このプロパティは、値が反時計回りの角度の単位であることを想定しているため、単なる向きの値を変換するのに **CameraRotationHelper** メソッドの **ConvertSimpleOrientationToClockwiseDegrees** を使用します。 最後に、[**SetEncodingPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.SetEncodingPropertiesAsync(Windows.Media.Capture.MediaStreamType,Windows.Media.MediaProperties.IMediaEncodingProperties,Windows.Media.MediaProperties.MediaPropertySet)) を呼び出して新しい回転プロパティをストリームに適用します。

[!code-cs[SetPreviewRotationAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetSetPreviewRotationAsync)]

次に、**CameraRotationHelper.OrientationChanged** イベントのハンドラーを追加します。 このイベントは、プレビュー ストリームが回転する必要があるかどうかを通知する引数を渡します。 デバイスの向きが表向きまたは裏向きに変わった場合、この値は false になります。 プレビューを回転する必要がある場合は、先ほど定義した **SetPreviewRotationAsync** を呼び出します。

次に、**OrientationChanged** イベント ハンドラーで、必要に応じて UI を更新します。 **GetUIOrientation** を呼び出して、現在推奨される UI の向きをヘルパー クラスから取得し、値を時計回りに変換します。この値は XAML の変換に使われます。 向きの値から [**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.RotateTransform) を作成し、XAML コントロールの [**RenderTransform**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.RenderTransform) プロパティを設定します。 UI レイアウトによっては、単なるコントロールの回転に加え、追加の調整が必要になる場合があります。 また、UI へのすべての更新は UI スレッドで実行される必要があるため、このコードを [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Core.CoreDispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority,Windows.UI.Core.DispatchedHandler)) の呼び出しの中に配置する必要があることに注意してください。  

[!code-cs[HelperOrientationChanged](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetHelperOrientationChanged)]

## <a name="capture-a-photo-with-orientation-data"></a>向きのデータを使って写真をキャプチャする
「[**MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ**](basic-photo-video-and-audio-capture-with-mediacapture.md)」では、写真をファイルにキャプチャする方法について説明しています。このためには、まず写真をインメモリ ストリームにキャプチャしたら、デコーダーを使ってストリームから画像データを読み取り、エンコーダーを使って画像データをファイルにコード変換します。 **CameraRotationHelper** クラスから取得した向きのデータを、変換操作中に画像ファイルに追加することができます。

次の例では、[**CapturePhotoToStreamAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.CapturePhotoToStreamAsync) を呼び出すことで写真を [**InMemoryRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.Streams.InMemoryRandomAccessStream) にキャプチャし、ストリームから [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.BitmapDecoder) を作成しています。 次に、[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.StorageFile) を作成して、ファイルに書き込む [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.Streams.IRandomAccessStream) を取得するために開きます。 

ファイルをコード変換する前に、**GetCameraCaptureOrientation** というヘルパー クラス メソッドから写真の向きを取得します。 このメソッドは、**ConvertSimpleOrientationToPhotoOrientation** というヘルパー メソッドによって [**PhotoOrientation**](https://msdn.microsoft.com/library/windows/apps/Windows.Storage.FileProperties.PhotoOrientation) オブジェクトに変換される [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Sensors.SimpleOrientation) オブジェクトを返します。 次に、新しい **BitmapPropertySet** オブジェクトを作成し、キーが "System.Photo.Orientation" で、値が (**BitmapTypedValue** として表される) 写真の向きであるプロパティを追加します。 "System.Photo.Orientation" は、メタデータとして画像ファイルに追加できる多くの Windows プロパティのうちの 1 つです。 写真に関連するプロパティの全一覧については、「[**Windows プロパティ - 写真**](https://msdn.microsoft.com/library/windows/desktop/ff516600)」をご覧ください。 画像のメタデータの使い方について詳しくは、「[**画像のメタデータ**](image-metadata.md)」をご覧ください。

最後に、[**SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/) を呼び出すことで、向きのデータを含むプロパティ セットをエンコーダーに設定し、[**FlushAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.BitmapEncoder.FlushAsync) を呼び出すことで、画像をコード変換します。

[!code-cs[CapturePhotoWithOrientation](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetCapturePhotoWithOrientation)]

## <a name="capture-a-video-with-orientation-data"></a>向きのデータを使ってビデオをキャプチャする
基本的なビデオ キャプチャについては、「[**MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ**](basic-photo-video-and-audio-capture-with-mediacapture.md)」で説明しています。 キャプチャしたビデオのエンコーディングに向きのデータを追加するには、向きのデータをプレビュー ストリームに追加するセクションで説明したのと同じ手法を用います。

次の例では、キャプチャしたビデオを書き込むファイルを作成します。 [**CreateMp4**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaProperties.MediaEncodingProfile.CreateMp4) という静的メソッドを使用して、MP4 エンコード プロファイルを作成します。 ビデオの正しい向きは、**GetCameraCaptureOrientation** を呼び出すことで **CameraRotationHelper** クラスから取得します。回転プロパティでは、向きを反時計回りの角度で表す必要があるため、**ConvertSimpleOrientationToClockwiseDegrees** ヘルパー メソッドを呼び出して向きの値を変換します。 次に、ビデオ ストリームの回転状態のメディア ファンデーション トランスフォーム (MFT) 属性を表す GUID を作成します。 C++ では [**MF_MT_VIDEO_ROTATION**](https://msdn.microsoft.com/library/windows/desktop/hh162880.aspx) 定数を使用できますが、C# では GUID 値を手動で指定する必要があります。 キーに GUID を、値に回転状態を指定して、ストリーム プロパティ オブジェクトにプロパティ値を追加します。 最後に、[**StartRecordToStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.StartRecordToStorageFileAsync(Windows.Media.MediaProperties.MediaEncodingProfile,Windows.Storage.IStorageFile)) を呼び出して、向きのデータによってエンコーディングされたビデオの録画を開始します。

[!code-cs[StartRecordingWithOrientationAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStartRecordingWithOrientationAsync)]

## <a name="camerarotationhelper-full-code-listing"></a>CameraRotationHelper の完全なコード
以下のコード スニペットに、**CameraRotationHelper** クラスの完全なコードを示します。このクラスは、ハードウェアの方位センサーを管理したり、写真やビデオの正しい向きの値を計算したりします。また、各種 Windows 機能で使われる、向きのさまざまな表示間で変換を実行するヘルパー メソッドを提供します。 上記の記事の手順に従えば、変更を加えることなくプロジェクトにこのクラスを追加することができます。 もちろん、特定のシナリオに合わせて、以下のコードを自由にカスタマイズすることも可能です。

このヘルパー クラスは、デバイスの [**SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Sensors.SimpleOrientationSensor) を使用してデバイス シャーシの現在の向きを特定し、[**DisplayInformation**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Display.DisplayInformation) クラスを使用してディスプレイの現在の向きを特定します。 これらの各クラスは、現在の向きが変更されたときに発生するイベントを提供します。 キャプチャ デバイスが取り付けられている、正面、背面、または外部のパネルは、プレビュー ストリームを左右反転する必要があるかどうかを特定するために使われます。 また、一部のデバイスでサポートされる [**EnclosureLocation.RotationAngleInDegreesClockwise**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.EnclosureLocation.RotationAngleInDegreesClockwise) プロパティは、シャーシに取り付けられているカメラの向きを特定するために使われます。

以下のメソッドを使えば、特定のカメラ アプリのタスクに推奨される向きの値を取得することができます。

* **GetUIOrientation** - カメラの UI 要素に対する向きの候補が返されます。
* **GetCameraCaptureOrientation** - 画像のメタデータへのエンコーディングに対する向きの候補が返されます。
* **GetCameraPreviewOrientation** - 自然なユーザー エクスペリエンスを実現するための、プレビュー ストリームの向きの候補が返されます。

[!code-cs[CameraRotationHelperFull](./code/SimpleCameraPreview_Win10/cs/CameraRotationHelper.cs#SnippetCameraRotationHelperFull)]



## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 




