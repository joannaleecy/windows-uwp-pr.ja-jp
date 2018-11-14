---
author: drewbatgit
ms.assetid: B5D915E4-4280-422C-BA0E-D574C534410B
description: この記事では、SceneAnalysisEffect と FaceDetectionEffect を使ってメディア キャプチャのプレビュー ストリームの内容を分析する方法について説明します。
title: カメラ フレームの分析の効果
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d948dee234ad6c49da847324422737b1bae27e30
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6255988"
---
# <a name="effects-for-analyzing-camera-frames"></a>カメラ フレームの分析の効果



この記事では、[**SceneAnalysisEffect**](https://msdn.microsoft.com/library/windows/apps/dn948902) と [**FaceDetectionEffect**](https://msdn.microsoft.com/library/windows/apps/dn948776) を使ってメディア キャプチャのプレビュー ストリームの内容を分析する方法について説明します。

## <a name="scene-analysis-effect"></a>シーン分析効果

[**SceneAnalysisEffect**](https://msdn.microsoft.com/library/windows/apps/dn948902) は、メディア キャプチャのプレビュー ストリームに含まれるビデオ フレームを分析し、キャプチャ結果を向上させるための処理オプションを推奨します。 現時点では、ハイ ダイナミック レンジ (HDR) 処理を使用してキャプチャを向上できるかどうかの検出がサポートされています。

HDR の使用が推奨された場合は、次の方法で実行できます。

-   [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) クラスで、Windows に組み込まれている HDR 処理アルゴリズムを使って写真をキャプチャします。 詳しくは、「[ハイ ダイナミック レンジ (HDR) 写真のキャプチャ](high-dynamic-range-hdr-photo-capture.md)」をご覧ください。

-   [**HdrVideoControl**](https://msdn.microsoft.com/library/windows/apps/dn926680) で、Windows に組み込まれている HDR 処理アルゴリズムを使ってビデオをキャプチャします。 詳しくは、「[ビデオ キャプチャのためのキャプチャ デバイス コントロール](capture-device-controls-for-video-capture.md)」をご覧ください。

-   [**VariablePhotoSequenceControl**](https://msdn.microsoft.com/library/windows/apps/dn640573) でフレームのシーケンスをキャプチャし、カスタム HDR 実装を使って合成します。 詳しくは、「[可変の写真シーケンス](variable-photo-sequence.md)」をご覧ください。

### <a name="scene-analysis-namespaces"></a>シーン分析の名前空間

シーン分析を使うには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間をアプリに追加する必要があります。

[!code-cs[SceneAnalysisUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSceneAnalysisUsing)]

### <a name="initialize-the-scene-analysis-effect-and-add-it-to-the-preview-stream"></a>シーン分析効果を初期化してプレビュー ストリームに追加する

ビデオ効果は、2 つの API を使って実装されます。1 つは効果の定義であり、キャプチャ デバイスで効果を初期化するために必要となる設定を提供します。もう 1 つは効果のインスタンスであり、効果を制御するために使用できます。 効果のインスタンスには、コードのいたるところからアクセスする必要があるので、通常はそのオブジェクトを保持するメンバー変数を宣言する必要があります。

[!code-cs[DeclareSceneAnalysisEffect](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDeclareSceneAnalysisEffect)]

アプリで、**MediaCapture** オブジェクトを初期化した後、[**SceneAnalysisEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn948903) の新しいインスタンスを作成します。

**MediaCapture** オブジェクトに対して [**AddVideoEffectAsync**](https://msdn.microsoft.com/library/windows/apps/dn878035) を呼び出すことで、効果をキャプチャ デバイスに登録します。このとき、**SceneAnalysisEffectDefinition** を指定し、さらに [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) を指定することで、効果をキャプチャ ストリームではなくビデオ プレビュー ストリームに適用することを示します。 **AddVideoEffectAsync** は追加されたエフェクトのインスタンスを返します。 このメソッドは複数の種類の効果について使用できるため、返されたインスタンスは [**SceneAnalysisEffect**](https://msdn.microsoft.com/library/windows/apps/dn948902) オブジェクトにキャストする必要があります。

シーン分析の結果を受け取るには、[**SceneAnalyzed**](https://msdn.microsoft.com/library/windows/apps/dn948920) イベントのハンドラーを登録する必要があります。

現時点では、シーン分析効果にはハイ ダイナミック レンジ アナライザーのみが含まれます。 効果の [**HighDynamicRangeControl.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn948827) を true に設定して、HDR 分析を有効にします。

[!code-cs[CreateSceneAnalysisEffectAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCreateSceneAnalysisEffectAsync)]

### <a name="implement-the-sceneanalyzed-event-handler"></a>SceneAnalyzed イベント ハンドラーを実装する

シーン分析の結果は、**SceneAnalyzed** イベント ハンドラーに返されます。 ハンドラーに渡された [**SceneAnalyzedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn948922) オブジェクトには、[**SceneAnalysisEffectFrame**](https://msdn.microsoft.com/library/windows/apps/dn948907) オブジェクトが含まれ、これには [**HighDynamicRangeOutput**](https://msdn.microsoft.com/library/windows/apps/dn948830) オブジェクトが含まれています。 ハイ ダイナミック レンジ出力の [**Certainty**](https://msdn.microsoft.com/library/windows/apps/dn948833) プロパティの値は、0 ～ 1.0 となります。0 は、HDR 処理によってキャプチャの結果が向上しないことを示します。1.0 は、HDR 処理によって結果が向上することを示します。 HDR を使うかどうかのしきい値を決めておく、またはユーザーに結果を表示してユーザーが決めるようにすることもできます。

[!code-cs[SceneAnalyzed](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSceneAnalyzed)]

ハンドラーに渡された [**HighDynamicRangeOutput**](https://msdn.microsoft.com/library/windows/apps/dn948830) オブジェクトには、[**FrameControllers**](https://msdn.microsoft.com/library/windows/apps/dn948834) プロパティもあります。このプロパティは、HDR 処理用の可変の写真シーケンスをキャプチャするために推奨されるフレーム コントローラーを指定します。 詳しくは、「[可変の写真シーケンス](variable-photo-sequence.md)」をご覧ください。

### <a name="clean-up-the-scene-analysis-effect"></a>シーン分析効果をクリーンアップする

キャプチャが終了したら、**MediaCapture** オブジェクトを破棄する前に、効果の [**HighDynamicRangeAnalyzer.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn948827) プロパティを false に設定してシーン分析効果を無効にし、[**SceneAnalyzed**](https://msdn.microsoft.com/library/windows/apps/dn948920) イベント ハンドラーの登録を解除する必要があります。 効果が追加されたのはビデオ プレビュー ストリームであるため、ビデオ プレビュー ストリームを指定して [**MediaCapture.ClearEffectsAsync**](https://msdn.microsoft.com/library/windows/apps/br226592) を呼び出します。 最後に、メンバー変数を null に設定します。

[!code-cs[CleanUpSceneAnalysisEffectAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpSceneAnalysisEffectAsync)]

## <a name="face-detection-effect"></a>顔検出効果

[**FaceDetectionEffect**](https://msdn.microsoft.com/library/windows/apps/dn948776) は、メディア キャプチャのプレビュー ストリーム内で顔の位置を特定します。 この効果によって、プレビュー ストリーム内で顔が検出されたときに通知を受け取ることができ、プレビュー フレーム内で検出された顔ごとに境界ボックスが表示されます。 サポートされているデバイスでは、シーン内の最も重要な顔に対して露出の強化やフォーカスが行われます。

### <a name="face-detection-namespaces"></a>顔検出の名前空間

顔検出を使うには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間をアプリに追加する必要があります。

[!code-cs[FaceDetectionUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFaceDetectionUsing)]

### <a name="initialize-the-face-detection-effect-and-add-it-to-the-preview-stream"></a>顔検出効果を初期化してプレビュー ストリームに追加する

ビデオ効果は、2 つの API を使って実装されます。1 つは効果の定義であり、キャプチャ デバイスで効果を初期化するために必要となる設定を提供します。もう 1 つは効果のインスタンスであり、効果を制御するために使用できます。 効果のインスタンスには、コードのいたるところからアクセスする必要があるので、通常はそのオブジェクトを保持するメンバー変数を宣言する必要があります。

[!code-cs[DeclareFaceDetectionEffect](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDeclareFaceDetectionEffect)]

アプリで、**MediaCapture** オブジェクトを初期化した後、[**FaceDetectionEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn948778) の新しいインスタンスを作成します。 [**DetectionMode**](https://msdn.microsoft.com/library/windows/apps/dn948781) プロパティを設定して、より高速な顔検出とより正確な顔検出のどちらを優先するかを決めます。 顔検出が完了するまで待機して着信フレームが遅延すると、プレビューがぎくしゃくした感じになる場合があるため、[**SynchronousDetectionEnabled**](https://msdn.microsoft.com/library/windows/apps/dn948786) を設定して、顔検出を待機しないよう指定します。

**MediaCapture** オブジェクトに対して [**AddVideoEffectAsync**](https://msdn.microsoft.com/library/windows/apps/dn878035) を呼び出すことで、効果をキャプチャ デバイスに登録します。このとき、**FaceDetectionEffectDefinition** を指定し、さらに [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) を指定することで、効果をキャプチャ ストリームではなくビデオ プレビュー ストリームに適用することを示します。 **AddVideoEffectAsync** は追加されたエフェクトのインスタンスを返します。 このメソッドは複数の種類の効果について使用できるため、返されたインスタンスは [**FaceDetectionEffect**](https://msdn.microsoft.com/library/windows/apps/dn948776) オブジェクトにキャストする必要があります。

[**FaceDetectionEffect.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn948818) プロパティを設定して、効果を有効または無効にします。 [**FaceDetectionEffect.DesiredDetectionInterval**](https://msdn.microsoft.com/library/windows/apps/dn948814) プロパティを設定して、フレームを分析する頻度を調整します。 これらのプロパティはいずれも、メディア キャプチャの進行中に調整できます。

[!code-cs[CreateFaceDetectionEffectAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCreateFaceDetectionEffectAsync)]

### <a name="receive-notifications-when-faces-are-detected"></a>顔が検出されたときに通知を受け取る

顔が検出されたときに、ビデオ プレビュー内で検出された顔の周りにボックスを描画するなど、特定の操作を実行するには、[**FaceDetected**](https://msdn.microsoft.com/library/windows/apps/dn948820) イベントに登録します。

[!code-cs[RegisterFaceDetectionHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterFaceDetectionHandler)]

イベントのハンドラーで、[**FaceDetectedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn948774) の [**FaceDetectionEffectFrame.DetectedFaces**](https://msdn.microsoft.com/library/windows/apps/dn948792) プロパティにアクセスすることにより、フレームで検出されたすべての顔の一覧を取得できます。 [**FaceBox**](https://msdn.microsoft.com/library/windows/apps/dn974126) プロパティは、プレビュー ストリームのサイズを基準とした単位で検出された顔を含む四角形を描画する [**BitmapBounds**](https://msdn.microsoft.com/library/windows/apps/br226169) 構造体です。 プレビュー ストリームの座標を画面座標に変換するサンプル コードについては、「[顔検出 UWP のサンプル](http://go.microsoft.com/fwlink/?LinkId=619486)」をご覧ください。

[!code-cs[FaceDetected](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetFaceDetected)]

### <a name="clean-up-the-face-detection-effect"></a>顔検出効果をクリーンアップする

キャプチャが終了したら、**MediaCapture** オブジェクトを破棄する前に、[**FaceDetectionEffect.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn948818) で顔検出効果を無効にし、[**FaceDetected**](https://msdn.microsoft.com/library/windows/apps/dn948820) イベント ハンドラーを登録していた場合は登録を解除する必要があります。 効果が追加されたのはビデオ プレビュー ストリームであるため、ビデオ プレビュー ストリームを指定して [**MediaCapture.ClearEffectsAsync**](https://msdn.microsoft.com/library/windows/apps/br226592) を呼び出します。 最後に、メンバー変数を null に設定します。

[!code-cs[CleanUpFaceDetectionEffectAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpFaceDetectionEffectAsync)]

### <a name="check-for-focus-and-exposure-support-for-detected-faces"></a>検出された顔に対するフォーカスや露出のサポートを確認する

すべてのデバイスに、検出された顔に基づいてフォーカスや露出を調整できるキャプチャ デバイスが搭載されているとは限りません。 顔検出はデバイス リソースを消費するため、キャプチャを強化する機能を使用できるデバイスでのみ顔検出を有効にすることもできます。 顔に基づくキャプチャの最適化が利用可能かどうかを確認するには、初期化された [MediaCapture](capture-photos-and-video-with-mediacapture.md) に対する [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) を取得してから、ビデオ デバイス コントローラーの [**RegionsOfInterestControl**](https://msdn.microsoft.com/library/windows/apps/dn279064) を取得します。 [**MaxRegions**](https://msdn.microsoft.com/library/windows/apps/dn279069) で少なくとも 1 つの領域がサポートされているかどうかを確認します。 次に、[**AutoExposureSupported**](https://msdn.microsoft.com/library/windows/apps/dn279065) または [**AutoFocusSupported**](https://msdn.microsoft.com/library/windows/apps/dn279066) のいずれかが true であるかどうかを確認します。 これらの条件が満たされている場合は、デバイスで顔検出を利用してキャプチャを強化できます。

[!code-cs[AreFaceFocusAndExposureSupported](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetAreFaceFocusAndExposureSupported)]

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 




