---
author: drewbatgit
ms.assetid: a128edc8-8a80-4645-ac29-908ede2d1c72
description: "この記事では、MediaCapture と共に MediaFrameReader を使って、色、深度、赤外線カメラ、オーディオ デバイスなどの 1 つ以上の利用可能なソースや、スケルタル トラッキング フレームを生成するようなカスタム フレーム ソースから、メディア フレームを取得する方法を示します。"
title: "MediaFrameReader を使ったメディア フレームの処理"
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: bc0cfc468613429d7989c9c0d93bd98246c0195b
ms.sourcegitcommit: 7540962003b38811e6336451bb03d46538b35671
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/26/2017
---
# <a name="process-media-frames-with-mediaframereader"></a>MediaFrameReader を使ったメディア フレームの処理

この記事では、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture) と共に [**MediaFrameReader**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader) を使って、色、深度、赤外線カメラ、オーディオ デバイスなどの 1 つ以上の利用可能なソースや、スケルタル トラッキング フレームを生成するようなカスタム フレーム ソースから、メディア フレームを取得する方法を示します。 この機能は、拡張現実アプリや奥行きを検出するカメラ アプリなど、メディア フレームのリアルタイム処理を実行するアプリで使用するために設計されました。

一般的な写真アプリなど、ビデオや写真を単にキャプチャすることに興味がある場合は、[ **MediaCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture) でサポートされているその他のキャプチャ手法のいずれかを使う方がよいでしょう。 利用可能なメディア キャプチャ手法のリストとそれらの使用方法を示す記事については、「[**カメラ**](camera.md)」をご覧ください。

> [!NOTE] 
> この記事で説明している機能は、Windows 10 バージョン 1607 以降でのみ利用できます。

> [!NOTE] 
> **MediaFrameReader** を使って色、深度、赤外線カメラなど、さまざまなフレーム ソースからのフレームを表示する方法を示す、ユニバーサル Windows アプリのサンプルがあります。 詳しくは、「[カメラ フレームのサンプル](http://go.microsoft.com/fwlink/?LinkId=823230)」をご覧ください。

## <a name="setting-up-your-project"></a>プロジェクトの設定
**MediaCapture** を使う他のアプリと同様に、カメラ デバイスにアクセスする前にアプリが *webcam* 機能を使うことを宣言する必要があります。 アプリがオーディオ デバイスからキャプチャする場合は、*microphone* デバイス機能も宣言する必要があります。 

**アプリ マニフェストに機能を追加する**

1.  Microsoft Visual Studio では、**ソリューション エクスプローラー**で **package.appxmanifest** 項目をダブルクリックして、アプリケーション マニフェストのデザイナーを開きます。
2.  **[機能]** タブをクリックします。
3.  **[Web カメラ]** のボックスと **[マイク]** のボックスをオンにします。
4.  画像ライブラリとビデオ ライブラリにアクセスするには、**画像ライブラリ**のボックスと**ビデオ ライブラリ**のボックスをオンにします。

この記事のサンプル コードでは、既定のプロジェクト テンプレートに含まれている API に加えて、次の名前空間の API が使っています。

[!code-cs[FramesUsing](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetFramesUsing)]

## <a name="select-frame-sources-and-frame-source-groups"></a>フレーム ソースとフレーム ソース グループを選択する
メディア フレームを処理する多くのアプリは、デバイスの色、深度カメラなど、複数のソースからフレームを一度に取得する必要があります。 [**MediaFrameSourceGroup**] (https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceGroup) オブジェクトは、同時に使用できるメディア フレーム ソースのセットを表します。 静的メソッド [ **MediaFrameSourceGroup.FindAllAsync** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceGroup.FindAllAsync) を呼び出して、現在のデバイスでサポートされているフレーム ソースのすべてのグループの一覧を取得します。

[!code-cs[FindAllAsync](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetFindAllAsync)]

[**DeviceInformation.CreateWatcher**](https://msdn.microsoft.com/library/windows/apps/br225427) と [**MediaFrameSourceGroup.GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceGroup.GetDeviceSelector) から返される値を使って [**DeviceWatcher**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.DeviceWatcher) を作成して、外付けカメラが接続されたときなど、デバイス上の利用可能なフレーム ソース グループが変更されたときに通知を受け取ることもできます。 詳しくは、「[**デバイスの列挙**](https://msdn.microsoft.com/windows/uwp/devices-sensors/enumerate-devices)」をご覧ください。

[**MediaFrameSourceGroup**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceGroup) には、グループに含まれるフレーム ソースを記述する [**MediaFrameSourceInfo**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceInfo) オブジェクトのコレクションがあります。 デバイスで利用可能なフレーム ソース グループを取得した後、目的のフレーム ソースを公開するグループを選択できます。

次の例は、フレーム ソース グループを選択する最も簡単な方法を示しています。 このコードは、すべての利用可能なグループをループで処理してから、[**SourceInfos**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceGroup.SourceInfos) コレクション内の各項目をループで処理します。 各 **MediaFrameSourceInfo** について、目的の機能をサポートしているかどうかがチェックされます。 この場合は、[**MediaStreamType**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceInfo.MediaStreamType) プロパティでデバイスがビデオ プレビュー ストリームを提供するかどうかを示す値 [**VideoPreview**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaStreamType) がチェックされ、[**SourceKind**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceInfo.SourceKind) プロパティでソースが色のフレームを提供するかどうかを示す値 [**Color**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceKind) がチェックされます。

[!code-cs[SimpleSelect](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetSimpleSelect)]

目的のフレーム ソース グループとフレーム ソースを識別するこの方法は、簡単なケースでは機能しますが、より複雑な条件に基づいてフレーム ソースを選択する場合は難しくなります。 別の方法として、Linq 構文と匿名オブジェクトを使って選択する方法があります。 次の例では、**Select** 拡張メソッドを使って、*frameSourceGroups* 一覧内の **MediaFrameSourceGroup** オブジェクトを 2 つのフィールドを持つ匿名オブジェクトに変換します。2 つのフィールドは、グループ自体を表す *sourceGroup* と、グループ内の色のフレーム ソースを表す *colorSourceInfo* です。 *colorSourceInfo* フィールドは、指定された述語が true に解決される最初のオブジェクトを選ぶ **FirstOrDefault** の結果に設定されます。 この場合、述語が true になるのは、ストリーム タイプが **VideoPreview**、ソースの種類が **Color** で、カメラがデバイスのフロント パネルにある場合です。

上記のクエリから返された匿名オブジェクトの一覧から、**Where** 拡張メソッドを使って、*colorSourceInfo* フィールドが null でないオブジェクトのみを選択します。 最後に、**FirstOrDefault** が呼び出されて一覧内で最初の項目が選択されます。

これで、選択したオブジェクトのフィールドを使って、選択した **MediaFrameSourceGroup** とカラー カメラを表す **MediaFrameSourceInfo** オブジェクトへの参照を取得できます。 後でこれらを使って、**MediaCapture** オブジェクトを初期化し、選択したソースの **MediaFrameReader** を作成します。 最後に、ソース グループが null であるかどうかをテストする必要があります。これは、現在のデバイスが要求されたキャプチャ ソースを持っていないことを意味します。

[!code-cs[SelectColor](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetSelectColor)]

次の例では、上記と同様の手法を使って、色、深度、および赤外線カメラを含むソース グループを選択します。

[!code-cs[ColorInfraredDepth](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetColorInfraredDepth)]

## <a name="initialize-the-mediacapture-object-to-use-the-selected-frame-source-group"></a>選択したフレーム ソース グループを使うように MediaCapture オブジェクトを初期化する
次に、前の手順で選択したフレーム ソース グループを使うように **MediaCapture** オブジェクトを初期化します。

通常、**MediaCapture** オブジェクトはアプリ内の複数の場所から使用できるため、それを保持するクラス メンバー変数を宣言する必要があります。

[!code-cs[DeclareMediaCapture](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetDeclareMediaCapture)]

コンス トラクターを呼び出して、**MediaCapture** オブジェクトのインスタンスを作成します。 次に、**MediaCapture** オブジェクトの初期化に使われる [**MediaCaptureSettings**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureSettings) オブジェクトを作成します。 この例では、次の設定を使用しています。

* [**SourceGroup**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureInitializationSettings.SourceGroup) - どのソース グループを使ってフレームを取得するかをシステムに知らせます。 ソース グループは、同時に使用できるメディア フレーム ソースのセットを定義することに注意してください。
* [**SharingMode**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureInitializationSettings.SharingMode) - キャプチャ ソース デバイスに関して排他的な制御が必要かどうかをシステムに知らせます。 これを [**ExclusiveControl**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureSharingMode) に設定すると、生成するフレームの形式など、キャプチャ デバイスの設定を変更することができますが、別のアプリが既に排他的制御を持っている場合、自分のアプリはメディア キャプチャ デバイスを初期化しようとすると失敗します。 これを [**SharedReadOnly**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureSharingMode) に設定すると、別のアプリで使われてもフレーム ソースからフレームを受け取ることができますが、デバイスの設定を変更することはできません。
* [**MemoryPreference**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureInitializationSettings.MemoryPreference) - [**CPU**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureMemoryPreference) を指定すると、システムは CPU メモリを使います。この場合、フレームが到着したとき、それらを [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.SoftwareBitmap) オブジェクトとして利用できることが保証されます。 [**Auto**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureMemoryPreference) を指定すると、システムはフレームを格納するのに最適なメモリの場所を動的に選択します。 システムが GPU メモリの使用を選択した場合、メディア フレームは **SoftwareBitmap** としてではなく、[**IDirect3DSurface** ](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.DirectX.Direct3D11.IDirect3DSurface) オブジェクトとして到着します。
* [**StreamingCaptureMode**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCaptureInitializationSettings.StreamingCaptureMode) - これを [**Video**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.StreamingCaptureMode) に設定すると、オーディオをストリーミングする必要がないことが指定されます。

[**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) を呼び出して、目的の設定で **MediaCapture** を初期化します。 初期化が失敗する場合は、必ず *try* ブロック内でこれを呼び出してください。

[!code-cs[InitMediaCapture](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetInitMediaCapture)]

## <a name="set-the-preferred-format-for-the-frame-source"></a>フレーム ソースの優先形式を設定する
フレーム ソースの優先形式を設定するには、ソースを表す [ **MediaFrameSource** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSource) オブジェクトを取得する必要があります。 このオブジェクトを取得するには、初期化した **MediaCapture** オブジェクトの [**Frames**](https://msdn.microsoft.com/library/windows/apps/Windows.Phone.Media.Capture.CameraCaptureSequence.Frames) ディクショナリにアクセスし、使用するフレーム ソースの識別子を指定します。 これは、フレーム ソース グループを選択していたときに [**MediaFrameSourceInfo**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceInfo) オブジェクトを保存したからです。

[**MediaFrameSource.SupportedFormats**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSource.SupportedFormats) プロパティには、フレーム ソースのサポートされている形式を記述する [**MediaFrameFormat**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameFormat) オブジェクトの一覧が含まれています。 **Where** Linq 拡張メソッドを使って、目的のプロパティに基づいて形式を選択します。 この例では、幅が 1080 ピクセルで、32 ビット RGB 形式のフレームを提供できる形式が選択されています。 **FirstOrDefault** 拡張メソッドは一覧内で最初のエントリを選択します。 選択された形式が null の場合、要求された形式はそのフレーム ソースでサポートされません。 形式がサポートされている場合は、[**SetFormatAsync**](https://msdn.microsoft.com/library/windows/apps/) を呼び出すことでソースがこの形式を使うことを要求できます。

[!code-cs[GetPreferredFormat](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetGetPreferredFormat)]

## <a name="create-a-frame-reader-for-the-frame-source"></a>フレーム ソースのフレーム リーダーを作成する
メディア フレーム ソースのフレームを受け取るには、[**MediaFrameReader**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader) を使います。

[!code-cs[DeclareMediaFrameReader](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetDeclareMediaFrameReader)]

初期化した **MediaCapture** オブジェクトで [**CreateFrameReaderAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture.CreateFrameReaderAsync) を呼び出して、フレーム リーダーをインスタンス化します。 このメソッドの最初の引数は、フレームを受け取るフレーム ソースです。 使用するフレーム ソースごとに、別々のフレーム リーダーを作成できます。 2 番目の引数で、フレームが到着するときの出力形式をシステムに知らせます。 これによって、フレームが到着したときに独自の変換を行う必要がなくなります。 フレーム ソースでサポートされていない形式を指定すると例外がスローされるため、その値が [**SupportedFormats**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSource.SupportedFormats) コレクションにあることを確認してください。  

フレーム リーダーを作成した後、ソースから新しいフレームが利用可能になったときに発生する [**FrameArrived**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader.FrameArrived) イベントのハンドラーを登録します。

[**StartAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader.StartAsync) を呼び出して、ソースからフレームの読み取りを開始するようにシステムに伝えます。

[!code-cs[CreateFrameReader](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetCreateFrameReader)]

## <a name="handle-the-frame-arrived-event"></a>FrameArrived イベントを処理する
新しいフレームが利用可能になると、[**MediaFrameReader.FrameArrived**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader.FrameArrived) イベントが発生します。 到着したすべてのフレームを処理するか、必要なときのみフレームを使うかを選択できます。 フレーム リーダーは自身のスレッドでイベントを発生させるため、何らかの同期ロジックを実装して、複数のスレッドからの同じデータにアクセスしていないことを確認する必要があります。 このセクションでは、XAML ページのイメージ コントロールへの色フレームの描画を同期する方法を示します。 このシナリオでは、XAML コントロールへのすべての更新を UI スレッドで実行するように要求する追加の同期制約について検討します。

XAML でフレームを表示するときの最初の手順は、イメージ コントロールの作成です。 

[!code-xml[ImageElementXAML](./code/Frames_Win10/Frames_Win10/MainPage.xaml#SnippetImageElementXAML)]

コード ビハインド ページで、**SoftwareBitmap** 型のクラス メンバー変数を宣言します。これは、すべての着信イメージのコピー先のバック バッファーとして使用されます。 イメージ データ自体はコピーされず、オブジェクト参照だけがコピーされます。 また、UI 操作が現在実行されているかどうかを追跡するブール値を宣言します。

[!code-cs[DeclareBackBuffer](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetDeclareBackBuffer)]

フレームは **SoftwareBitmap** オブジェクトとして到着するため、**SoftwareBitmap** を XAML **Control** のソースとして使用できるようにする [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.Imaging.SoftwareBitmapSource) オブジェクトを作成する必要があります。 フレーム リーダーを開始する前に、コード内のどこかでイメージ ソースを設定する必要があります。

[!code-cs[ImageElementSource](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetImageElementSource)]

ここで、**FrameArrived** イベント ハンドラーを実装します。 ハンドラーが呼び出されると、*sender* パラメーターにイベントを発生させた **MediaFrameReader** オブジェクトへの参照が含まれます。 このオブジェクトで [**TryAcquireLatestFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader.TryAcquireLatestFrame) を呼び出して、最新のフレームの取得を試みます。 名前からわかるように、**TryAcquireLatestFrame** はフレームを返すことに失敗することがあります。 そのため、VideoMediaFrame プロパティ、SoftwareBitmap プロパティの順にアクセスするときは、必ず null を検査してください。 この例では、null 条件演算子 ? を使って **SoftwareBitmap** にアクセスした後、取得したオブジェクトで null がチェックされています。

**Image** コントロールは、プリマルチプライ処理済みまたはアルファなしの BRGA8 形式でのみイメージを表示できます。 到着するフレームがその形式でない場合は、静的メソッド [**Convert**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Imaging.SoftwareBitmap.Covert) を使ってソフトウェア ビットマップを正しい形式に変換します。

次に、[**Interlocked.Exchange**](https://msdn.microsoft.com/library/bb337971) メソッドを使って、到着するビットマップの参照をバックバッファー ビットマップと交換します。 このメソッドは、スレッド セーフであるアトミック操作でこれらの参照を交換します。 交換後、*softwareBitmap* 変数に格納されている古いバックバッファー イメージは、リソースをクリーンアップするために破棄されます。

次に、**Image** 要素に関連付けられている [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Core.CoreDispatcher) を使って、[**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) を呼び出して UI スレッドで実行されるタスクを作成します。 非同期タスクはタスク内で実行されるため、**RunAsync** に渡されるラムダ式は *async* キーワードを付けて宣言されます。

タスク内で、*_taskRunning* 変数をチェックして、タスクの 1 つのインスタンスだけが一度に実行されていることを確認します。 タスクが既に実行されていない場合は、タスクがもう一度実行されることを防ぐために *_taskRunning* を true に設定します。 *while* ループで、バックバッファー イメージが null になるまで、**Interlocked.Exchange** を呼び出してバックバッファーから一時的な **SoftwareBitmap** にコピーします。 一時的なビットマップが入力されるたびに、**Image** の **Source** プロパティを **SoftwareBitmapSource** にキャストし、[**SetBitmapAsync** ](https://msdn.microsoft.com/library/windows/apps/dn997856) を呼び出してイメージのソースを設定します。

最後に、次回にハンドラーが呼び出されたときにタスクをもう一度実行できるように、*_taskRunning* 変数を false に戻します。

> [!NOTE] 
> [**MediaFrameReference**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReference) の [**VideoMediaFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReference.VideoMediaFrame) プロパティが提供する [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.VideoMediaFrame.SoftwareBitmap) オブジェクトまたは [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.VideoMediaFrame.Direct3DSurface) オブジェクトにアクセスすると、これらのオブジェクトへの強参照がシステムによって作成されます。そのため、それらが含まれている **MediaFrameReference** に対して [**Dispose**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReference.Close) を呼び出してもこれらのオブジェクトは破棄されません。 それらのオブジェクトを即座に破棄するには、**SoftwareBitmap** または **Direct3DSurface** の **Dispose** メソッドを明示的に直接呼び出す必要があります。 そうしない場合、最終的にはガーベジ コレクターによってこれらのオブジェクトのメモリが解放されますが、それがいつになるかは不明であり、割り当てられたビットマップやサーフェスの数がシステムによって許容される最大数を上回った場合、新しいフレームのフローが停止します。


[!code-cs[FrameArrived](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetFrameArrived)]

## <a name="cleanup-resources"></a>リソースをクリーンアップする
フレームの読み込みが終わったら、必ず [**StopAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader.StopAsync) を呼び出してメディア フレーム リーダーを停止して、**FrameArrived** ハンドラーの登録を解除し、**MediaCapture** オブジェクトを破棄してください。

[!code-cs[クリーンアップ](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetCleanup)]

アプリケーションが中断されたときのメディア キャプチャ オブジェクトのクリーンアップについて詳しくは、「[**カメラ プレビューの表示**](simple-camera-preview-access.md)」をご覧ください。

## <a name="the-framerenderer-helper-class"></a>FrameRenderer ヘルパー クラス
ユニバーサル Windows の[カメラ フレームのサンプル](http://go.microsoft.com/fwlink/?LinkId=823230)は、アプリで色、赤外線、および深度のソースからフレームを表示するのを容易にするヘルパー クラスを提供します。 通常、深度や赤外線のデータを画面に表示するだけでなく、データを使ってそれ以上のことを行いたいですが、このヘルパー クラスは、フレーム リーダーの機能を示したり、独自のフレーム リーダーの実装をデバッグしたりするための便利なツールです。

**FrameRenderer** ヘルパー クラスは、次のメソッドを実装します。

* **FrameRenderer** コンストラクター - このコンストラクターは、メディア フレームを表示するために渡す XAML [**Image**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Image) 要素を使うようにヘルパー クラスを初期化します。
* **ProcessFrame** - このメソッドは、コンストラクターに渡した **Image** 要素に、[**MediaFrameReference**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReference) で表されるメディア フレームを表示します。 通常、[**FrameArrived**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader.FrameArrived) イベント ハンドラーからこのメソッドを呼び出し、[**TryAcquireLatestFrame**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader.TryAcquireLatestFrame) から返されるフレームを渡します。
* **ConvertToDisplayableImage** - このメソッドは、メディア フレームの形式をチェックし、必要な場合は表示可能な形式に変換します。 カラー イメージの場合は、色の形式が BGRA8 であり、ビットマップのアルファ モードがプリマルチプライ済みであることを確認します。 深度または赤外線フレームの場合は、各スキャン ラインを処理して、深度または赤外線の値が疑似カラー グラデーションに変換します。これには、サンプルに含まれていて以下に記載される **PseudoColorHelper** クラスを使います。

> [!NOTE] 
> **SoftwareBitmap** イメージ上でピクセル操作を行うには、ネイティブ メモリ バッファーにアクセスする必要があります。 これを行うには、以下のコードに含まれている IMemoryBufferByteAccess COM インターフェイスを使う必要があり、アンセーフ コードのコンパイルを許可するようにプロジェクトのプロパティを更新する必要があります。 詳しくは、「[ビットマップ画像の作成、編集、保存](imaging.md)」をご覧ください。

[!code-cs[FrameArrived](./code/Frames_Win10/Frames_Win10/FrameRenderer.cs#SnippetFrameRenderer)]

## <a name="use-multisourcemediaframereader-to-get-time-corellated-frames-from-multiple-sources"></a>MultiSourceMediaFrameReader を使って複数のソースから時間相関フレームを取得する
Windows 10 Version 1607 以降では、[**MultiSourceMediaFrameReader**](https://docs.microsoft.com/en-us/uwp/api/windows.media.capture.frames.multisourcemediaframereader) を使って複数のソースから時間相関フレームを取得できます。 この API により、[**DepthCorrelatedCoordinateMapper**](https://docs.microsoft.com/en-us/uwp/api/windows.media.devices.core.depthcorrelatedcoordinatemapper) クラスを使う場合など、複数のソースから時間的に近接するフレームを必要とする処理が簡単になります。 ただし、この新しいメソッドを使う場合の制限の 1 つとして、フレーム到着イベントは、最も低速なキャプチャ ソースに合わせて生成されるようになります。 高速なソースからの追加のフレームは取りこぼされます。 また、システムでは、さまざまなソースからさまざまな速度でフレームが到着するものと想定するため、ソースがフレームの生成を完全に停止したかどうかを自動的に認識することはできません。 このセクションのコード例では、イベントを使って独自のタイムアウト ロジックを作成する方法を示します。アプリで定義した制限時間内に相関フレームが到着しなかった場合、タイムアウトが発生します。

[**MultiSourceMediaFrameReader**](https://docs.microsoft.com/en-us/uwp/api/windows.media.capture.frames.multisourcemediaframereader) を使う手順は、この記事で既に説明した [**MediaFrameReader**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameReader) を使う手順と同様です。 この例では、カラー ソースと深度ソースを使います。 メディア フレーム ソース ID を格納する文字列変数をいくつか宣言します。これらの ID は、各ソースからのフレームを選択するために使われます。 次に、サンプルのタイムアウト ロジックを実装するために使う [**ManualResetEventSlim**](https://docs.microsoft.com/dotnet/api/system.threading.manualreseteventslim?view=netframework-4.7)、[**CancellationTokenSource**](https://msdn.microsoft.com/library/system.threading.cancellationtokensource.aspx)、[**EventHandler**](https://msdn.microsoft.com/library/system.eventhandler.aspx) を宣言します。 

[!code-cs[MultiFrameDeclarations](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetMultiFrameDeclarations)]

この記事で既に説明した手法を使って、このサンプル シナリオに必要なカラー ソースと深度ソースを含む [**MediaFrameSourceGroup**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceGroup) を照会します。 目的のフレーム ソース グループを選択したら、各フレーム ソースの [**MediaFrameSourceInfo**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.Frames.MediaFrameSourceInfo) を取得します。

[!code-cs[SelectColorAndDepth](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetSelectColorAndDepth)]

**MediaCapture** オブジェクトを作成し、選択したフレーム ソース グループを初期化設定に渡して初期化します。

[!code-cs[MultiFrameInitMediaCapture](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetMultiFrameInitMediaCapture)]

**MediaCapture** オブジェクトを初期化したら、カラー カメラと深度カメラの [**MediaFrameSource**](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.Frames.MediaFrameSource) オブジェクトを取得します。 各ソースの ID を格納して、対応するソースから到着したフレームを選択できるようにします。

[!code-cs[GetColorAndDepthSource](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetGetColorAndDepthSource)]

**MultiSourceMediaFrameReader** を作成して初期化します。そのためには、[**CreateMultiSourceFrameReaderAsync**](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapture#Windows_Media_Capture_MediaCapture_CreateMultiSourceFrameReaderAsync_Windows_Foundation_Collections_IIterable_Windows_Media_Capture_Frames_MediaFrameSource__) を呼び出して、リーダーで使用するフレーム ソースの配列を渡します。 [**FrameArrived**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader#Windows_Media_Capture_Frames_MultiSourceMediaFrameReader_FrameArrived) イベントに対するイベント ハンドラーを登録します。 この例では、フレームを **Image** コントロールにレンダリングするために、この記事で既に説明した **FrameRenderer** ヘルパー クラスのインスタンスを作成します。 [**StartAsync**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader#Windows_Media_Capture_Frames_MultiSourceMediaFrameReader_StartAsync) を呼び出して、フレーム リーダーを開始します。

この例で既に宣言した **CorellationFailed** イベントに対するイベント ハンドラーを登録します。 使用中のメディア フレーム ソースのいずれかがフレームの生成を停止すると、このイベントが通知されます。 最後に、[**Task.Run**](https://msdn.microsoft.com/en-us/library/hh195051.aspx) を呼び出して、タイムアウト ヘルパー メソッドである **NotifyAboutCorrelationFailure** を別のスレッドで実行します。 このメソッドの実装は後で示します。

[!code-cs[InitMultiFrameReader](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetInitMultiFrameReader)]

**FrameArrived** イベントは、**MultiSourceMediaFrameReader** で管理されているすべてのメディア フレーム ソースで新しいフレームが利用可能になったときに発生します。 つまりこのイベントは、最も低速なメディア ソースに合わせて発生することになります。 低速なソースでフレームが 1 つ生成される間に別のソースで複数のフレームが生成された場合、高速なフレームからの追加のフレームは取りこぼされます。 

[**TryAcquireLatestFrame**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader#Windows_Media_Capture_Frames_MultiSourceMediaFrameReader_TryAcquireLatestFrame) を呼び出して、イベントに関連付けられている [**MultiSourceMediaFrameReference**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereference) を取得します。 [**TryGetFrameReferenceBySourceId**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereference#Windows_Media_Capture_Frames_MultiSourceMediaFrameReference_TryGetFrameReferenceBySourceId_System_String_) を呼び出して、各メディア フレーム ソースに関連付けられている **MediaFrameReference** を取得します。引数には、フレーム リーダーの初期化時に格納した ID 文字列を渡します。

**ManualResetEventSlim** オブジェクトの [**Set**](https://msdn.microsoft.com/library/system.threading.manualreseteventslim.set.aspx) メソッドを呼び出して、フレームが到着したことを通知します。 このイベントは、別のスレッドで実行中の **NotifyCorrelationFailure** メソッドでチェックされます。 

最後に、時間相関メディア フレームに対して任意の処理を実行します。 この例では、深度ソースからのフレームを描画するだけです。

[!code-cs[MultiFrameArrived](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetMultiFrameArrived)]

**NotifyCorrelationFailure** ヘルパー メソッドは、フレーム リーダーの開始後に別のスレッドで実行ました。 このメソッドでは、フレーム受信イベントが通知されたかどうかをチェックします。 既に説明したとおり、このイベントは、相関フレームのセットが到着するたびに **FrameArrived** ハンドラーで設定されます。 アプリで定義した時間内 (適切な値は 5 秒程度) にイベントが通知されなかった場合、**CancellationToken** を使ってタスクが取り消されたのでなければ、いずれかのメディア フレーム ソースでフレームの読み取りが停止した可能性があります。 この場合、通常はフレーム リーダーをシャットダウンすることになります。そこで、アプリ定義の **CorrelationFailed** イベントを発生させます。 このイベントのハンドラーでフレーム リーダーを停止し、この記事で既に説明したように、関連付けられているリソースをクリーンアップします。

[!code-cs[NotifyCorrelationFailure](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetNotifyCorrelationFailure)]

[!code-cs[CorrelationFailure](./code/Frames_Win10/Frames_Win10/MainPage.xaml.cs#SnippetCorrelationFailure)]

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [カメラ フレームのサンプル](http://go.microsoft.com/fwlink/?LinkId=823230)
 

 




