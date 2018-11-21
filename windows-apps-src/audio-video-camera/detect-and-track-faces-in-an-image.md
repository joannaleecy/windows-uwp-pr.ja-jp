---
author: drewbatgit
ms.assetid: 84729E44-10E9-4D7D-8575-6A9D97467ECD
description: このトピックでは、FaceDetector を使って画像内の顔を検出する方法について説明します。 FaceTracker は、ビデオ フレームのシーケンスで顔を経時的に追跡するように最適化されています。
title: 画像やビデオでの顔の検出
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: be2cfb94c68ed3431199428c87aef4bf038ccbb9
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7437571"
---
# <a name="detect-faces-in-images-or-videos"></a>画像やビデオでの顔の検出



\[一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、マイクロソフトは明示または黙示を問わずいかなる保証をするものでもありません。\]

このトピックでは、[**FaceDetector**](https://msdn.microsoft.com/library/windows/apps/dn974129) を使って画像内の顔を検出する方法について説明します。 [**FaceTracker**](https://msdn.microsoft.com/library/windows/apps/dn974150) は、ビデオ フレームのシーケンスで顔を経時的に追跡するように最適化されています。

[**FaceDetectionEffect**](https://msdn.microsoft.com/library/windows/apps/dn948776) を使った顔を追跡する別の方法については、「[メディア キャプチャのシーン分析](scene-analysis-for-media-capture.md)」をご覧ください。

この記事のコードは、[基本的な顔検出](http://go.microsoft.com/fwlink/p/?LinkId=620512&clcid=0x409)と[基本的な顔追跡](http://go.microsoft.com/fwlink/p/?LinkId=620513&clcid=0x409)のサンプルを基にしています。 これらのサンプルをダウンロードし、該当するコンテキストで使われているコードを確認することも、サンプルを独自のアプリの開始点として使うこともできます。

## <a name="detect-faces-in-a-single-image"></a>1 つの画像内の顔を検出する

[**FaceDetector**](https://msdn.microsoft.com/library/windows/apps/dn974129) クラスを使うと、静止画像内の 1 つまたは複数の顔を検出できます。

この例では、次の名前空間の API を使っています。

[!code-cs[FaceDetectionUsing](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetFaceDetectionUsing)]

[**FaceDetector**](https://msdn.microsoft.com/library/windows/apps/dn974129) オブジェクト用と、画像から検出される [**DetectedFace**](https://msdn.microsoft.com/library/windows/apps/dn974123) オブジェクトの一覧用に、クラス メンバー変数を宣言しています。

[!code-cs[ClassVariables1](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetClassVariables1)]

顔検出は、さまざまな方法で作成できる [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトに対して可能です。 この例では、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使って、顔が検出される画像ファイルをユーザーが選べるようにしています。 ソフトウェア ビットマップの操作の詳細については、「[イメージング](imaging.md)」を参照してください。

[!code-cs[Picker](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetPicker)]

[**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) クラスを使って、**SoftwareBitmap** に画像ファイルをデコードします。 顔検出処理は、画像が小さいほど高速になるため、ソース画像の縮小が必要になる場合があります。 デコード中にこれを行うには、[**BitmapTransform**](https://msdn.microsoft.com/library/windows/apps/br226254) オブジェクトを作成し、[**ScaledWidth**](https://msdn.microsoft.com/library/windows/apps/br226261) および [**ScaledHeight**](https://msdn.microsoft.com/library/windows/apps/br226260) プロパティを設定して、そのオブジェクトを [**GetSoftwareBitmapAsync**](https://msdn.microsoft.com/library/windows/apps/dn887332) の呼び出しに渡します。これにより、デコードされて縮小された **SoftwareBitmap** が返されます。

[!code-cs[Decode](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetDecode)]

現在のバージョンでは、**FaceDetector** クラスでのみ Gray8 または Nv12 の画像がサポートされています。 **SoftwareBitmap** クラスには、ビットマップの形式を変換する [**Convert**](https://msdn.microsoft.com/library/windows/apps/dn887362) メソッドが用意されています。 この例では、ソース画像を Gray8 ピクセル形式に変換しています (まだその形式になっていない場合)。 必要に応じて、[**GetSupportedBitmapPixelFormats**](https://msdn.microsoft.com/library/windows/apps/dn974140) および [**IsBitmapPixelFormatSupported**](https://msdn.microsoft.com/library/windows/apps/dn974142) メソッドを使って、ピクセル形式がサポートされているかどうかを実行時に調べることができます。これにより、サポートされている一連の形式が今後のバージョンで拡張される場合に備えることができます。

[!code-cs[Format](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetFormat)]

[**CreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn974132) を呼び出すことで **FaceDetector** オブジェクトをインスタンス化したら、[**DetectFacesAsync**](https://msdn.microsoft.com/library/windows/apps/dn974134) を呼び出して、適切なサイズに拡大縮小済み、サポートされているピクセル形式に変換済みのビットマップを渡します。 このメソッドは [**DetectedFace**](https://msdn.microsoft.com/library/windows/apps/dn974123) オブジェクトの一覧を返します。 **ShowDetectedFaces** はヘルパー メソッドであり、次に示しているように、画像内の顔の周りに四角形を描画します。

[!code-cs[Detect](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetDetect)]

顔検出処理の実行中に作成されたオブジェクトは必ず破棄してください。

[!code-cs[Dispose](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetDispose)]

画像を表示し、検出された顔の周りに四角形を描画するには、XAML ページに [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) 要素を追加します。

[!code-xml[Canvas](./code/FaceDetection_Win10/cs/MainPage.xaml#SnippetCanvas)]

描画される四角形のスタイルの設定用に、いくつかのメンバー変数を定義します。

[!code-cs[ClassVariables2](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetClassVariables2)]

**ShowDetectedFaces** ヘルパー メソッドでは、新しい [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/br210101) が作成され、ソースが、ソース画像を表す **SoftwareBitmap**  から作成された [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/dn997854) に設定されます。 XAML **Canvas** コントロールの背景がイメージ ブラシに設定されます。

ヘルパー メソッドに渡された顔の一覧が空でない場合は、一覧内の各顔をループし、[**DetectedFace**](https://msdn.microsoft.com/library/windows/apps/dn974123) クラスの [**FaceBox**](https://msdn.microsoft.com/library/windows/apps/dn974126) プロパティを使って、画像内で顔の周りの四角形の位置とサイズを調べます。 **Canvas** コントロールはほとんどの場合、ソース画像と異なるサイズであるため、**FaceBox** の X 座標と Y 座標にも、幅と高さにも、拡大縮小値 (ソース画像のサイズと **Canvas** コントロールの実際のサイズとの比率) を掛ける必要があります。

[!code-cs[ShowDetectedFaces](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetShowDetectedFaces)]

## <a name="track-faces-in-a-sequence-of-frames"></a>フレームのシーケンスで顔を追跡する

ビデオ内の顔を検出する場合は、[**FaceDetector**](https://msdn.microsoft.com/library/windows/apps/dn974129) よりも [**FaceTracker**](https://msdn.microsoft.com/library/windows/apps/dn974150) クラスを使う方が効率的です。実装手順はほとんど同じです。 **FaceTracker** では、前に処理したフレームに関する情報を使って検出処理を最適化します。

[!code-cs[FaceTrackingUsing](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetFaceTrackingUsing)]

**FaceTracker** オブジェクトのクラス変数を宣言します。 この例では、[**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/br230587) を使って、定義した間隔で顔追跡を開始します。 [SemaphoreSlim](https://msdn.microsoft.com/library/system.threading.semaphoreslim.aspx) を使って、同時に 1 つの顔追跡処理のみが実行されるようにします。

[!code-cs[ClassVariables3](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetClassVariables3)]

顔追跡処理を初期化するには、[**CreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn974151) を呼び出して新しい **FaceTracker** オブジェクトを作成します。 目的のタイマー間隔を初期化してから、タイマーを作成します。 指定した間隔が経過するたびに **ProcessCurrentVideoFrame** ヘルパー メソッドが呼び出されます。

[!code-cs[TrackingInit](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetTrackingInit)]

**ProcessCurrentVideoFrame** ヘルパー メソッドはタイマーによって非同期的に呼び出されるため、このメソッドはまず、セマフォの **Wait** メソッドを呼び出して、追跡処理が進行中であるかどうかを調べて、そうであれば、顔を検出しようとせずに戻ります。 このメソッドの最後で、セマフォの **Release** メソッドが呼び出され、後続の **ProcessCurrentVideoFrame** が呼び出されて、処理が続行されます。

[**FaceTracker**](https://msdn.microsoft.com/library/windows/apps/dn974150) クラスは [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) オブジェクトに対して使えます。 **VideoFrame** を取得するには、複数の方法があります。たとえば、実行中の [MediaCapture](capture-photos-and-video-with-mediacapture.md) オブジェクトからプレビュー フレームをキャプチャします。または、[**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) の [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764784) メソッドを実装します。 この例では、ビデオ フレームを返す未定義のヘルパー メソッド **GetLatestFrame** をこの処理のプレースホルダーとして使っています。 実行中のメディア キャプチャ デバイスのプレビュー ストリームからビデオ フレームを取得する方法について詳しくは、「[プレビュー フレームの取得](get-a-preview-frame.md)」をご覧ください。

**FaceDetector** と同様、**FaceTracker** でも、サポートされていないピクセル形式があります。 この例では、渡されたフレームが Nv12 形式でない場合は顔検出を破棄します。

[**ProcessNextFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn974157) を呼び出して、フレーム内の顔を表す [**DetectedFace**](https://msdn.microsoft.com/library/windows/apps/dn974123) オブジェクトの一覧を取得します。 顔の一覧を取得したら、顔検出について先ほど説明した同じ方法でそれらの顔を表示できます。 顔追跡ヘルパー メソッドは UI スレッドで呼び出されないため、[**CoredDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) の呼び出し内で UI の更新をすべて行う必要があります。

[!code-cs[ProcessCurrentVideoFrame](./code/FaceDetection_Win10/cs/MainPage.xaml.cs#SnippetProcessCurrentVideoFrame)]

## <a name="related-topics"></a>関連トピック

* [メディア キャプチャのシーン分析](scene-analysis-for-media-capture.md)
* [基本的な顔検出のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620512&clcid=0x409)
* [基本的な顔追跡のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620513&clcid=0x409)
* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [メディア再生](media-playback.md)
