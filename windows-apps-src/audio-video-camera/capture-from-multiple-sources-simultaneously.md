---
author: drewbatgit
ms.assetid: ''
description: この記事では、複数のソースから同時にビデオをキャプチャして、複数のビデオ トラックが埋め込まれている 1 つのファイルを作成する方法について説明します。
title: MediaFrameSourceGroup を使用して複数のソースからキャプチャする
ms.author: drewbat
ms.date: 09/12/2017
ms.topic: article
keywords: Windows 10, UWP, キャプチャ, ビデオ
ms.localizationpriority: medium
ms.openlocfilehash: ae52026d5fb1ab3c140edfdcd1f92f7d3d0fd143
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5945528"
---
# <a name="capture-from-multiple-sources-using-mediaframesourcegroup"></a>MediaFrameSourceGroup を使用して複数のソースからキャプチャする

この記事では、複数のソースから同時にビデオをキャプチャして、複数のビデオ トラックが埋め込まれている 1 つのファイルを作成する方法について説明します。 RS3 以降では、1 つの **[MediaEncodingProfile](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile)** に対して複数の **[VideoStreamDescriptor](https://docs.microsoft.com/uwp/api/windows.media.core.videostreamdescriptor)** オブジェクトを指定できます。 これにより、複数のストリームを同時に 1 つのファイルにエンコードすることができます。 この操作でエンコードされたビデオ ストリームは、1 つの **[MediaFrameSourceGroup](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup)** に含める必要があります。このクラスでは、現在のデバイスが備えている、同時使用が可能なカメラのセットを指定します。 

**[MediaFrameReader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframereader)** クラスと共に **[MediaFrameSourceGroup](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup)** を使用して、複数のカメラを利用するリアルタイムなコンピューター ビジョンのシナリオを実現する方法については、「[MediaFrameReader を使ったメディア フレームの処理](process-media-frames-with-mediaframereader.md)」をご覧ください。

この記事の残りの部分では、2 台のカラー カメラでビデオを録画し、複数のビデオ トラックが埋め込まれている 1 つのファイルを作成する手順について説明します。

## <a name="find-available-sensor-groups"></a>利用可能なセンサー グループを検索する
**MediaFrameSourceGroup** は、同時にアクセスできるフレーム ソース (通常はカメラ) のコレクションを表します。 利用可能なフレーム ソース グループのセットはデバイスごとに異なります。そのため、この例の最初の手順では、利用可能なフレーム ソース グループの一覧を取得し、シナリオで必要となるカメラを含んでいるグループを探します。この例では、2 台のカラー カメラが必要となります。

**[MediaFrameSourceGroup.FindAllAsync](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup.FindAllAsync)** メソッドは、現在のデバイスで利用可能なすべてのソース グループを返します。 返された各 **MediaFrameSourceGroup** には、グループ内にある各フレーム ソースを記述する **[MediaFrameSourceInfo](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourceinfo)** オブジェクトの一覧が含まれています。 Linq クエリを使用して、2 台のカラー カメラ (前面カメラと背面カメラ) を含んでいるソース グループを検索します。 各カラー カメラについて選択した **MediaFrameSourceGroup** と **MediaFrameSourceInfo** を含んでいる匿名オブジェクトが返されます。 Linq 構文を使用する代わりに、各グループをループ処理してから、各 **MediaFrameSourceInfo** をループ処理し、要件を満たしているグループを検索することもできます。

すべてのデバイスが 2 台のカラー カメラを含むソース グループを保持しているわけではありません。そのため、ビデオをキャプチャする前に、ソース グループが検出済みであるかどうかを確認する必要があります

[!code-cs[MultiRecordFindSensorGroups](./code/SimpleCameraPreview_Win10/cs/MainPage.MultiRecord.xaml.cs#SnippetMultiRecordFindSensorGroups)]

## <a name="initialize-the-mediacapture-object"></a>MediaCapture オブジェクトを初期化する
**[MediaCapture](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapture)** クラスは、UWP アプリでのほとんどのオーディオ、ビデオ、および写真のキャプチャ操作で使用されるプライマリ クラスです。 初期化パラメーターを含んでいる **[MediaCaptureInitializationSettings](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacaptureinitializationsettings)** オブジェクトを渡して **[InitializeAsync](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapture.InitializeAsync)** を呼び出し、オブジェクトを初期化します。 この例では、指定した設定は **[SourceGroup](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacaptureinitializationsettings.SourceGroup)** プロパティのみで、前のコード例で取得された **MediaFrameSourceGroup** に設定されています。

メディアをキャプチャする場合に **MediaCapture** や他の UWP アプリの機能を使用して実行できるその他の操作については、「[カメラ](camera.md)」をご覧ください。

[!code-cs[MultiRecordInitMediaCapture](./code/SimpleCameraPreview_Win10/cs/MainPage.MultiRecord.xaml.cs#SnippetMultiRecordInitMediaCapture)]

## <a name="create-a-mediaencodingprofile"></a>MediaEncodingProfile を作成する
**[MediaEncodingProfile](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile)** クラスは、キャプチャしたオーディオやビデオをファイルに書き込む際のエンコードの方法をメディア キャプチャ パイプラインに伝えます。 一般的なキャプチャやコード変換のシナリオでは、このクラスによって、一般的なプロファイル (**[CreateAvi](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createavi)** や **[CreateMp3](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp3)** など) を作成するための一連の静的メソッドが提供されます。 この例では、Mpeg4 コンテナーと H264 ビデオ エンコードを使用して、エンコード プロファイルを手動で作成します。 ビデオ エンコードの設定は、**[VideoEncodingProperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.videoencodingproperties)** オブジェクトを使用して指定します。 このシナリオで使用される各カラー カメラに対して、**VideoStreamDescriptor** オブジェクトを構成します。 記述子は、エンコードを指定する **VideoEncodingProperties** オブジェクトを使用して作成されます。 **VideoStreamDescriptor** の **[Label](https://docs.microsoft.com/uwp/api/windows.media.core.videostreamdescriptor.Label)** プロパティは、ストリームにキャプチャされるメディア フレーム ソースの ID に設定する必要があります。 この方法によって、キャプチャ パイプラインは、どのストリーム記述子とエンコード プロパティが各カメラで使用されるかを識別します。 フレーム ソースの ID は、**MediaFrameSourceGroup** が選択されたときに、**[MediaFrameSourceInfo](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourceinfo)** オブジェクト (前のセクションをご覧ください) によって公開されます。


Windows 10, version 1709 以降では、**[SetVideoTracks](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.setvideotracks)** を呼び出すことによって、**MediaEncodingProfile** に対して複数のエンコード プロパティを設定できます。 ビデオ ストリーム記述子の一覧は、**[GetVideoTracks](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.GetVideoTracks)** を呼び出して取得することができます。 1 つのストリーム記述子を格納する **[Video](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.Video)** プロパティを設定した場合、**SetVideoTracks** を呼び出して設定した記述子の一覧は、指定した 1 つの記述子を含んでいる一覧に置き換えられます。


[!code-cs[MultiRecordMediaEncodingProfile](./code/SimpleCameraPreview_Win10/cs/MainPage.MultiRecord.xaml.cs#SnippetMultiRecordMediaEncodingProfile)]

### <a name="encode-timed-metadata-in-media-files"></a>メディア ファイルでタイミングが設定されたメタデータをエンコードする

Windows 10、バージョン 1803 以降では、オーディオとビデオに加え、タイミングが設定されたメタデータを、サポートされている形式のメディア ファイルにエンコードできます。 たとえば、GoPro メタデータ (gpmd) を MP4 ファイルに格納して、ビデオ ストリームに関連付けられた地理的位置情報を伝達できます。 

メタデータのエンコードでは、オーディオやビデオのエンコードと同様のパターンが使用されます。 [**TimedMetadataEncodingProperties**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.timedmetadataencodingproperties) クラスが、タイプ、サブタイプに加え、メタデータのエンコード プロパティを記述します (ビデオの **VideoEncodingProperties** に相当します)。 [**TimedMetadataStreamDescriptor**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatastreamdescriptor) は、メタデータ ストリームを識別します (ビデオ ストリームの **VideoStreamDescriptor** に相当します)。  

次の例では、**TimedMetadataStreamDescriptor**オブジェクトを初期化する方法を示します。 まず、**TimedMetadataEncodingProperties** オブジェクトが作成されると、**Subtype** が、ストリームに含めるメタデータのタイプを識別する GUID に設定されます。 この例では、GoPro メタデータ (gpmd) の GUID が使用されています。 [**SetFormatUserData**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.timedmetadataencodingproperties.setformatuserdata) メソッドが呼び出されて形式固有のデータが設定されます。 MP4 ファイルの場合、形式固有のデータが SampleDescription ボックス (stsd) に格納されます。 次に、エンコード プロパティから、新しい**TimedMetadataStreamDescriptor** が作成されます。 **Label** プロパティと **Name** プロパティが、エンコードするストリームの ID に設定されます。 

[!code-cs[GetStreamDescriptor](./code/SimpleCameraPreview_Win10/cs/MainPage.MultiRecord.xaml.cs#SnippetGetStreamDescriptor)]

[MediaEncodingProfile.SetTimedMetadataTracks](**https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.settimedmetadatatracks**) を呼び出して、メタデータ ストリーム記述子をエンコード プロファイルに追加します。 次の例では、2 つのビデオ ストリーム記述子、1 つのオーディオ ストリーム記述子、1 つのタイミングが設定されたメタデータ ストリーム記述子を受け取り、ストリームのエンコードに使用できる **MediaEncodingProfile** を返すヘルパー メソッドを示します。

[!code-cs[GetMediaEncodingProfile](./code/SimpleCameraPreview_Win10/cs/MainPage.MultiRecord.xaml.cs#SnippetGetMediaEncodingProfile)]

## <a name="record-using-the-multi-stream-mediaencodingprofile"></a>マルチストリームの MediaEncodingProfile を使用して録画する
この例の最期の手順では、キャプチャしたメディアが書き込まれる **StorageFile** と前のコード例で作成した **MediaEncodingProfile** を渡して **[StartRecordToStorageFileAsync](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapture.startrecordtostoragefileasync)** を呼び出し、ビデオ キャプチャを開始します。 数秒待機した後で、**[StopRecordAsync](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapture.StopRecordAsync)** が呼び出され録画が停止します。

[!code-cs[MultiRecordToFile](./code/SimpleCameraPreview_Win10/cs/MainPage.MultiRecord.xaml.cs#SnippetMultiRecordToFile)]

操作が完了すると、各カメラからキャプチャしたビデオを含むビデオ ファイルが作成されます。このファイルでは、それぞれのビデオが個別のストリームとしてエンコードされています。 複数のビデオ トラックが含まれているメディア ファイルを再生する方法について詳しくは、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [MediaFrameReader を使ったメディア フレームの処理](process-media-frames-with-mediaframereader.md)
* [メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)


 

 




