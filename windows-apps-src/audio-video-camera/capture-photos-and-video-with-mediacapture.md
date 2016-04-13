---
ms.assetid: 1361E82A-202F-40F7-9239-56F00DFCA54B
description: この記事では、MediaCapture API を使用して写真とビデオをキャプチャする手順について説明します。これには、MediaCapture の初期化とシャットダウン、デバイスの向きに変化が生じた場合の処理などが含まれます。
title: MediaCapture を使った写真とビデオのキャプチャ
---

# MediaCapture を使った写真とビデオのキャプチャ

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


この記事では、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) API を使用して写真とビデオをキャプチャする手順について説明します。これには、**MediaCapture** の初期化とシャットダウン、デバイスの向きに変化が生じた場合の処理などが含まれます。

**MediaCapture** は、メディア キャプチャ プロセスに対する低レベルの制御を必要とするアプリや、高度なキャプチャ機能を要するシナリオを実装するアプリのサポートを目的としています。 **MediaCapture** を使用するには、独自のキャプチャ UI を用意する必要があります。 アプリで写真またはビデオをキャプチャできれば良く、高度なキャプチャ技術を必要としない場合は、[**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) を使用すると、わずか数行のコードで写真やビデオを簡単にキャプチャできるようになります。 詳しくは、「[CameraCaptureUI を使った写真とビデオのキャプチャ](capture-photos-and-video-with-cameracaptureui.md)」をご覧ください。

この記事のコードは、[CameraStarterKit サンプル](http://go.microsoft.com/fwlink/?LinkId=619479) を基にしています。 このサンプルをダウンロードし、該当するコンテキストで使用されているコードを確認することも、サンプルを独自のアプリの開始点として使用することもできます。

## プロジェクトを構成する

### アプリ マニフェストに機能宣言を追加する

アプリからデバイスのカメラにアクセスするには、アプリでデバイス機能 (*webcam* と *microphone*) の使用を宣言する必要があります。 キャプチャした写真とビデオをユーザーの画像ライブラリまたはビデオ ライブラリに保存する場合は、*picturesLibrary* 機能と *videosLibrary* 機能も宣言する必要があります。

**アプリ マニフェストに機能を追加する**

1.  Microsoft Visual Studio では、**ソリューション エクスプローラー**で **package.appxmanifest** 項目をダブルクリックし、アプリケーション マニフェストのデザイナーを開きます。
2.  **[機能]** タブをクリックします。
3.  **[Web カメラ]** のボックスと **[マイク]** のボックスをオンにします。
4.  画像ライブラリとビデオ ライブラリにアクセスするには、**画像ライブラリ**のボックスと**ビデオ ライブラリ**のボックスをオンにします。

### メディア キャプチャ関連の API について using ディレクティブを追加する

次のコードでは、この記事のサンプル コードで参照されている名前空間を示し、各名前空間の機能を説明しています。

[!code-cs[Using](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUsing)]

## MediaCapture オブジェクトを初期化する

[
            **Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/br226738) 名前空間の [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) クラスは、すべてのメディア キャプチャ操作で使用される基本的なインターフェイスです。 アプリでは一般的に、単一ページでの使用を対象としてこの型の変数を宣言します。 アプリでは、**MediaCapture** の現在の状態を追跡する必要があるため、このオブジェクトの初期化状態、プレビュー状態、録画状態用にブール変数を宣言します。

[!code-cs[MediaCaptureVariables](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetMediaCaptureVariables)]

プレビュー ビデオを正しい向きで表示するには、外付けカメラかどうか、アプリでプレビュー ストリームを左右反転処理中かどうかを追跡するメンバー変数を作成します。 ビデオ フィードがユーザーをキャプチャしていると判断した場合は、ユーザーから見て自然に感じられるように、アプリでプレビュー ストリームを左右反転処理する必要があります。

[!code-cs[PreviewVariables](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPreviewVariables)]

次の例のメソッドでは、メディア キャプチャ オブジェクトを初期化しています。 最初に、メディア キャプチャに使用できるビデオ キャプチャ デバイスを検索します。 見つかったら、**MediaCapture** オブジェクトを初期化し、イベントのハンドラーを登録します。 次に、ビデオ キャプチャ デバイスの ID を使用して [**MediaCaptureInitializationSettings**](https://msdn.microsoft.com/library/windows/desktop/hh802710) オブジェクトを作成します。 さらに、[**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) を呼び出すことで、**MediaCapture** を初期化します。

[!code-cs[InitializeCameraAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetInitializeCameraAsync)]

-   指定された種類のすべてのデバイスを検索するには、[**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) メソッドを使用できます。 この例では、ビデオ キャプチャ デバイスのみを返すことを示すために、**DeviceClass.VideoCapture** 列挙値が渡されています。 ビデオ キャプチャ デバイスは、写真とビデオの両方のキャプチャに使用されます。

-   **FindAllAsync** は、[**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) オブジェクトを返します。このオブジェクトには、要求された種類の各デバイスに対応する [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) オブジェクトが含まれます。 **System.Linq** 名前空間の **FirstOrDefault** 拡張メソッドは、指定された条件に基づいて一覧から項目を選択するための簡単な構文を提供します。 最初の呼び出しでは、[**EnclosureLocation.Panel**](https://msdn.microsoft.com/library/windows/apps/br229906) の値が **Panel.Back** である (カメラがデバイス エンクロージャの背面にあることを示す) 最初の **DeviceInformation** を一覧から選択しようとしています。 デバイスの背面にカメラがない場合は、最初の利用可能なカメラが使用されます。

-   [
            **MediaCaptureInitializationSettings**](https://msdn.microsoft.com/library/windows/apps/br226573) の初期化時にデバイス ID を指定しなかった場合、デバイスの内部リストから最初のデバイスがシステムによって選択されます。

-   [
            **MediaCapture.InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) を呼び出すと、指定されたキャプチャ デバイスを使用できるようにオブジェクトが初期化されます。 この呼び出しは、**try** ブロックの内部で行われ、呼び出し元アプリからカメラへのアクセスをユーザーが拒否した場合は、**UnauthorizedAccessException** がスローされます。 呼び出しに成功した場合は、**\_isInitialized** 変数が true に設定されます。これにより、キャプチャ デバイスが初期化されているかどうかを以降のメソッド呼び出しで判断できるようになります。

- **重要** 一部のデバイス ファミリでは、アプリがデバイスのカメラへのアクセスを付与される前に、ユーザー同意のプロンプトがユーザーに表示されます。 このため、[**MediaCapture.InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) のみをメイン UI スレッドから呼び出す必要があります。 別のスレッドからカメラを初期化しようとすると、初期化エラーになる可能性があります。

-   キャプチャ デバイスの初期化に成功した場合は、キャプチャ デバイスが外付けかどうか、デバイスのフロント パネルにあるかどうかを反映して、各変数が設定されます。 これらの値は、キャプチャ プレビューがユーザーから見て正しい向きで表示されるように使用されます。 最後に、キャプチャが利用可能であり、プレビュー ストリームがキャプチャ デバイスから開始されたことを反映して、UI が更新されます。 これらのタスクはすべて、この記事で説明するヘルパー メソッドで実行されます。

## キャプチャ プレビューを開始する

キャプチャ結果がどうなるかをユーザーが確認できるようにするには、ビデオ キャプチャ デバイスによる現在のプレビューを UI に渡す必要があります。

**重要:** キャプチャ デバイスでオート フォーカス、自動露出、オート ホワイト バランスを有効にするには、キャプチャ プレビューを開始する必要があります。

キャプチャ プレビューを有効にするには、[**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) コントロールを使います。 次の例では、キャプチャ要素を定義する XAML コードを示します。

[!code-xml[CaptureElement](./code/BasicMediaCaptureWin10/cs/MainPage.xaml#SnippetCaptureElement)]

ユーザーは、ビデオ キャプチャ画面のプレビュー中は、非アクティブな状態になっても画面がオフにならずオンのままであると考えます。 これを可能にするには、[**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) オブジェクトを作成する必要があります。 キャプチャ セッションの間ずっと保持されるように、ページ スコープでこの変数を宣言します。

[!code-cs[DisplayRequest](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDisplayRequest)]

次のメソッドは、メディア キャプチャ プレビューを開始しています。 まず、[**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) の [**RequestActive**](https://msdn.microsoft.com/library/windows/apps/br241818) を呼び出すことによって、画面がアクティブな状態で維持されるよう求めます。 次に、[**StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613) を呼び出してプレビューを開始します。

[!code-cs[StartPreviewAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStartPreviewAsync)]

-   **DisplayRequest** オブジェクトの [**RequestActive**](https://msdn.microsoft.com/library/windows/apps/br241818) メソッドが呼び出され、画面をオンにしておくようにシステムに求めています。

-   プレビューのソースを定義するために、**CaptureElement** の [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) プロパティがアプリの **MediaCapture** オブジェクトに設定されています。

-   双方向対応のユーザー インターフェイスをサポートするために、XAML フレームワークによって [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティが提供されています。 **CaptureElement** のテキストの方向を [**FlowDirection.RightToLeft**](https://msdn.microsoft.com/library/windows/apps/br242397) に設定すると、プレビュー ビデオが水平方向に反転されます。 この処理は、キャプチャ デバイスがデバイスのフロント パネルにある場合に、プレビューがユーザーの視点から適切な向きになるように使用します。

-   [
            **StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613) メソッドは、**CaptureElement** 内でプレビュー ストリームの表示を開始します。 プレビューが正常に開始されると、アプリが現在プレビュー中であることがアプリの他の部分にわかるように、**\_isPreviewing** 変数が設定され、プレビューの回転を設定するためのヘルパー メソッドが呼び出されます。 このメソッドについては、次のセクションで説明します。

## 画面とデバイスの向きを検出する

メディア キャプチャ アプリが電話やタブレットなどのモバイル デバイスで実行されている場合、デバイスの現在の向きがアプリの複数の分野に影響します。 このような分野としては、カメラからのプレビュー ストリームを正しい向きにする処理や、ユーザーから見て適切な向きになるように、キャプチャした画像やビデオを正しくエンコードする処理などがあります。

"表示の向き" という用語は、ユーザーに対して正しい向きになるように、デバイス上でシステムが XAML ページをどのように回転するかを指します。 "デバイスの向き" は、物理空間におけるデバイスの向きを表しているため、物理空間におけるカメラ デバイスの向きを指します。 メディア キャプチャ アプリでは、どちらの種類の向きも使用します。 表示の向きを処理するには、[**DisplayInformation**](https://msdn.microsoft.com/library/windows/apps/dn264258) クラス用にページ スコープの変数を宣言し、初期化します。 ディスプレイの現在の向きを追跡するには、[**DisplayOrientations**](https://msdn.microsoft.com/library/windows/apps/br226142) 型の変数をもう 1 つ宣言します。 デバイスの向きを追跡するには、[**SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/br206400) 変数と [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/br206399) 変数を宣言します。

[!code-cs[DisplayInformationAndOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDisplayInformationAndOrientation)]

次に示す各ヘルパー メソッドでは、[**DisplayInformation.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) イベントと [**SimpleOrientationSensor.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/br206407) イベントのイベント ハンドラーを登録または登録解除し、追跡用の変数を現在の向きで初期化しています。 [
            **SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/br206400) がないデバイスもあるため、ハンドラーの登録や現在の向きの取得を行う前に、チェックが必要です。

[!code-cs[RegisterOrientationEventHandlers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterOrientationEventHandlers)]

[!code-cs[UnregisterOrientationEventHandlers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUnregisterOrientationEventHandlers)]

**SimpleOrientationSensor.OrientationChanged** イベントのイベント ハンドラーでは、デバイスの向きを示す変数を現在の向きで更新しています。 デバイスの面が上向きまたは下向きであれば、向きを更新しないようにします。

[!code-cs[SimpleOrientationChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSimpleOrientationChanged)]

**DisplayInformation.OrientationChanged** イベントのイベント ハンドラーでは、表示の向きの変数を現在の向きで更新しています。 キャプチャ デバイスのビデオ プレビューが表示中であれば、プレビュー ビデオ ストリームの回転状態を更新します。 **SetPreviewRotationAsync** ヘルパー メソッドについては、次のセクションで説明します。

[!code-cs[DisplayOrientationChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDisplayOrientationChanged)]

## メディア キャプチャ プレビューの回転を設定する

ユーザーは、モバイル デバイスの向きが変わると UI コントロールが回転し、UI のテキストが垂直方向に読みやすく揃うと考えます。 ただし **CaptureElement** コントロールについては、デバイスが回転しても、ビデオ プレビューの向きが回転してほしいとは考えないのが普通です。 期待どおりのユーザー エクスペリエンスを提供するには、デバイスの向きに合わせて、プレビュー ストリームを回転する必要があります。

プレビュー ストリームの向きは、角度で表す必要があります。 次に示すヘルパー メソッドは、[**DisplayOrientations**](https://msdn.microsoft.com/library/windows/apps/br226142) 列挙値を角度に変換します。

[!code-cs[ConvertDisplayOrientationToDegrees](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetConvertDisplayOrientationToDegrees)]

このヘルパー メソッドは、デバイスの回転を表すために [**SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/br206400) によって使用される [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/br206399) 列挙値を角度に変換します。

[!code-cs[ConvertDeviceOrientationToDegrees](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetConvertDeviceOrientationToDegrees)]

低レベルでは、ストリームの回転を実際に行っているのは Microsoft メディア ファンデーション フレームワークです。 回転は、[MF\_MT\_VIDEO\_ROTATION](https://msdn.microsoft.com/library/windows/desktop/hh162880) 属性を使用して指定されます。 これは、Windows ランタイム アプリであるため、回転は属性名ではなく、属性の GUID を使用して指定されます。 ビデオの回転属性を識別するために、次の GUID を定義します。

[!code-cs[RotationKey](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRotationKey)]

次に示すメソッドは、プレビュー ストリームの回転を設定します。 メディア キャプチャの [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) の [**GetMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211995) メソッドは、キー/値のペアから成るプロパティ セットを返します。 [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) を指定して、ビデオ録音ストリームやオーディオ ストリームではなく、ビデオ プレビュー ストリームのプロパティが必要であることを示します。 プロパティ セットは、ストリームのプロパティを設定するための汎用目的のインターフェイスですが、このタスクでは、上で定義したビデオ回転の GUID をプロパティ キーとして追加し、ビデオ ストリームの必要な向き (角度) を値として指定します。 [**SetEncodingPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/dn297781) は、エンコード プロパティを新しい値で更新します。 設定しているプロパティがビデオ プレビュー ストリーム用であることを示す **MediaStreamType.VideoPreview** が指定されています。

[!code-cs[SetPreviewRotation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetPreviewRotation)]

-   外付けカメラを搭載したデバイスの場合、ユーザーは、デバイスが回転してもカメラ ストリームが回転するとは考えていません。

-   フロント パネルのカメラ用にプレビューを左右反転する場合、デバイスの回転に一致するように回転方向を反転させる必要があります。

-   電話など一部のデバイスでは、[**DisplayInformation.AutoRotationPreferences**](https://msdn.microsoft.com/library/windows/apps/dn264259) を向きの値 ([**DisplayOrientations.Landscape**](https://msdn.microsoft.com/library/windows/apps/br226142) など) に設定し、ディスプレイをデバイスと共に回転させることができます。 サポートされているデバイスでは快適なエクスペリエンスを提供するため、この値を設定する必要がありますが、自動回転の基本設定がサポートされていないデバイスをサポートするアプリでは、上に示したパターンの実装が必要になります。

-   以前のリリースでは、プレビュー ストリームを回転させるための唯一の方法は [**SetPreviewRotation**](https://msdn.microsoft.com/library/windows/apps/br226611) メソッドでした。 このメソッドは、既存のアプリをサポートするために API サーフェスに存在していますが、このメソッドは非効率的であるため、新しいアプリでは使用しないでください。

## 写真をキャプチャする

次に示すメソッドでは、写真をキャプチャします。[**CapturePhotoToStreamAsync**](https://msdn.microsoft.com/library/windows/apps/hh700840) メソッドを使い、要求されたエンコード プロパティと、キャプチャ操作の結果を格納するための [**InMemoryRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241720) オブジェクトを渡します。 [
            **ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) クラスは、メディア キャプチャでサポートされているファイルの種類に応じてエンコード プロパティを生成するために、[**CreateJpeg**](https://msdn.microsoft.com/library/windows/apps/hh700994) などのヘルパー メソッドを提供します。

[!code-cs[TakePhotoAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetTakePhotoAsync)]

写真をファイルを保存する前に、写真の正しい向きを判断する必要があります。 **MediaCapture** オブジェクトはデバイスの向きを認識できないため、キャプチャ デバイスが既定の向きであると想定して、キャプチャした写真データをエンコードします。 この場合は、キャプチャした写真をユーザーが確認する際に表示される写真の向きが必ずしも正しくないため、結果として否定的なユーザー エクスペリエンスにつながります。 次に示すヘルパー メソッドは写真の向きを正しく判断し、正しい向きでファイルを保存します。

**GetCameraOrientation** ヘルパー メソッドは現在のデバイスの向きから開始し、デバイスのネイティブの向きとデバイスのカメラの位置によって、値を回転させます。 この例の **\_mirroringPreview** 変数で示されているように、カメラがデバイスのフロント パネルに取り付けられている場合は、カメラの向きが反転されます。

[!code-cs[GetCameraOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetCameraOrientation)]

次に示すヘルパー メソッドでは、方位センサーで使用される [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/br206399) 列挙値からの値を、ビットマップ エンコーダーで使用される等価の [**PhotoOrientation**](https://msdn.microsoft.com/library/windows/apps/hh965476) 値に、単純に変換します。この値は、ファイルを保存する際に使用されます。

[!code-cs[ConvertOrientationToPhotoOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetConvertOrientationToPhotoOrientation)]

最後に、キャプチャした写真をエンコードして保存できます。 キャプチャされた写真データが含まれる入力ストリームから、[**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) オブジェクトを作成します。 新しい [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) を作成し、読み取り/書き込み用に開きます。 出力ファイルと、画像データを格納するデコーダーを渡して、[**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/br226206) オブジェクトを作成します。 新しい [**BitmapPropertySet**](https://msdn.microsoft.com/library/windows/apps/hh974338) を作成して、新しいプロパティを追加します。 プロパティのキーである "System.Photo.Orientation" は、写真の向きを表すプロパティを指定します。 値は、あらかじめ計算済みの [**PhotoOrientation**](https://msdn.microsoft.com/library/windows/apps/hh965476) 値です。 [
            **SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) を呼び出してエンコーダーのプロパティを更新し、[**FlushAsync**](https://msdn.microsoft.com/library/dn237883) を呼び出して写真をストレージ ファイルに書き込みます。

[!code-cs[ReencodeAndSavePhotoAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetReencodeAndSavePhotoAsync)]

-   "System.Photo.Orientation" ビットマップ プロパティを設定すると、写真の向きがファイルのメタデータにエンコードされます。 実際の画像データが別途エンコードされることはありません。 メタデータを画像ファイルに埋め込む方法について詳しくは、「[画像のメタデータ](image-metadata.md)」をご覧ください。

-   画像のエンコードやデコードど、画像の操作について詳しくは、「[イメージング](imaging.md)」をご覧ください。

## ビデオをキャプチャする

ビデオのキャプチャを開始するには、まず、ビデオを録画するためのストレージ ファイルを作成します。 次に、ビデオをファイルにエンコードするために **MediaCapture** で使用される [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) を作成します。 **MediaEncodingProfile** クラスには、[**CreateMp4**](https://msdn.microsoft.com/library/windows/apps/hh701078) などのメソッドが用意されています。このメソッドでは、サポートされているビデオ形式に対応するエンコード プロファイルを作成します。 前に説明したヘルパー メソッドを使用して、ビデオの正しい回転 (角度) を取得します。 写真の場合とは異なり、ビデオの回転情報は、**MediaCapture** によってストリームにエンコードされます。 回転情報を [**VideoEncodingProperties.Properties**](https://msdn.microsoft.com/library/windows/apps/hh701254) コレクションに追加することにより、エンコード プロファイルに追加します。 ビデオの回転の定義済み GUID がキーとして使用され、回転 (角度) が値になります。 最後に、エンコードのプロパティと出力ファイルを指定して [**MediaCapture.StartRecordToStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh700863) を呼び出し、録画を開始します。

[!code-cs[StartRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStartRecordingAsync)]

録画を停止するには、[**MediaCapture.StopRecordAsync**](https://msdn.microsoft.com/library/windows/apps/br226623) を呼び出します。

[!code-cs[StopRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStopRecordingAsync)]

[
            **MediaCapture.RecordLimitationExceeded**](https://msdn.microsoft.com/library/windows/apps/hh973312) イベントのハンドラーは、**MediaCapture** を初期化するときに登録されています。 ビデオの録画を停止するには、このイベント ハンドラーで **StopRecordingAsync** メソッドを呼び出します。

[!code-cs[RecordLimitationExceeded](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRecordLimitationExceeded)]

## ビデオ キャプチャを一時停止して再開する

シナリオによっては、進行中のビデオ キャプチャを停止して新しいキャプチャを開始するのではなく、一時停止と再開が必要になることがあります。 録画を一時停止するには、[**PauseRecordAsync**](https://msdn.microsoft.com/library/windows/apps/dn858102) を呼び出します。 [
            **MediaCapturePauseBehavior.RetainHardwareResources**](https://msdn.microsoft.com/library/windows/apps/dn926686) を指定した場合、ビデオと写真の同時キャプチャをサポートしていないデバイスでは、ビデオの一時停止中にアプリが写真をキャプチャすることはできません。 デバイスで写真とビデオの同時キャプチャがサポートされているかどうかを確認する方法については、「[カメラ プロファイル](camera-profiles.md)」をご覧ください。

[!code-cs[PauseRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPauseRecordingAsync)]

一時停止したビデオ キャプチャを再開するには、[**ResumeRecordAsync**](https://msdn.microsoft.com/library/windows/apps/dn858103) を呼び出します。

[!code-cs[ResumeRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetResumeRecordingAsync)]

## キャプチャ リソースをクリーンアップする

メディア キャプチャを適切にシャットダウンしてリソースを解放することは、非常に重要です。 これを怠ると、アプリを閉じた後にカメラで予期しない動作が生じ、その結果アプリのユーザー エクスペリエンスに悪影響を及ぼす可能性があります。 以下のセクションでは、カメラをシャットダウンするために必要な各種の手順について説明します。

### キャプチャ プレビューをシャットダウンする

キャプチャ プレビューをシャットダウンするには、まず [**MediaCapture.StopPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226622) を呼び出します。 [
            **MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) の [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) プロパティを null にします。 次に、必要に応じてシステムがディスプレイをオフにできるように、[**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) 変数に対して [**RequestRelease**](https://msdn.microsoft.com/library/windows/apps/br241819) を呼び出します。

[!code-cs[StopPreviewAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStopPreviewAsync)]

-   非 UI スレッドから UI にアクセスすることはできないため、**MediaElement.Source** プロパティの設定と **RequestRelease** の呼び出しには、[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) メソッドを使用する必要があります。これにより、UI スレッドに対して呼び出しが行われます。

### MediaCapture オブジェクトをシャットダウンして破棄する

**MediaCapture** オブジェクトを破棄する前に、定義済みのヘルパー メソッドを呼び出すことによって、進行中の録画をすべて停止し、プレビュー ストリームを停止する必要があります。 この処理が完了したら、**MediaCapture** に登録されているイベント ハンドラーをすべて削除します。次に、[**Dispose**](https://msdn.microsoft.com/library/windows/apps/dn278858) を呼び出して、このオブジェクトに関連するリソースをすべて解放し、**MediaCapture** 変数を null に設定します。

[!code-cs[CleanupCameraAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanupCameraAsync)]

[
            **MediaCapture.Failed**](https://msdn.microsoft.com/library/windows/apps/br226593) イベントのハンドラーの内部で **MediaCapture** オブジェクトをシャットダウンし、破棄するには、このメソッドを呼び出す必要があります。

[!code-cs[CaptureFailed](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCaptureFailed)]

### アプリの有効期間とページ ナビゲーション イベントを処理する

アプリの有効期間イベントは、アプリでリソースの初期化と解放を行う機会を作ります。 **Application.Suspending** イベントでは特に、アプリでメディア キャプチャ リソースを正しく破棄することが不可欠であるため、この処理が重要になります。

アプリケーションの有効期間イベントのハンドラーは、ページのコンストラクターで登録できます。

[!code-cs[RegisterAppLifetimeEvents](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterAppLifetimeEvents)]

**Application.Suspending** イベントのハンドラーでは、ディスプレイとデバイスの向きに関するイベントのハンドラーを登録解除し、**MediaCapture** オブジェクトをシャットダウンする必要があります。 ここで登録を解除した [**SystemMediaTransportControls.PropertyChanged**](https://msdn.microsoft.com/library/windows/apps/dn278720) イベントは、他のアプリケーション有効期間関連タスクに必要になります。これについては、後で説明します。

**注意** 
中断イベント ハンドラーの先頭で [**SuspendingOperation.GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) を呼び出すことにより、中断の遅延を要求する必要があります。 これにより、アプリを停止する前に、操作が完了したことを伝えるユーザーからの通知を待機するようシステムに要求されます。 **MediaCapture** のシャットダウン処理は非同期であり、カメラが正しくシャットダウンされる前に **Application.Suspending** イベント ハンドラーが完了する可能性があるため、この動作が必要になります。 非同期呼び出しの完了を待機した後、[**SuspendingDeferral.Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) を呼び出すことによって遅延状態を解放する必要があります。

[!code-cs[Suspending](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSuspending)]

**Application.Resuming** イベントのハンドラーでは、ディスプレイとデバイスの向きに関するイベントのハンドラーを登録し、**SystemMediaTransportControls.PropertyChanged** イベントを登録して、**MediaCapture** オブジェクトを初期化する必要があります。

[!code-cs[Resuming](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetResuming)]

[
            **OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) イベントは、ディスプレイとデバイスの向きに関するイベントのハンドラーを最初に登録し、**MediaCapture** オブジェクトを初期化する機会を作ります。

[!code-cs[OnNavigatedTo](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnNavigatedTo)]

アプリに複数のページがある場合は、[**OnNavigatingFrom**](https://msdn.microsoft.com/library/windows/apps/br227509) イベント ハンドラーでメディア キャプチャ オブジェクトをクリーンアップする必要があります。

[!code-cs[OnNavigatingFrom](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnNavigatingFrom)]

同時に複数のウィンドウをサポートするデバイスでアプリを正しく動作させるには、アプリの最小化や復元が発生したときに応答する必要があります。 これには、[**SystemMediaTransportControls.PropertyChanged**](https://msdn.microsoft.com/library/windows/apps/dn278720) イベントを処理する必要があります。 アプリの [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) オブジェクトへの参照を格納するためのメンバー変数を初期化します。

[!code-cs[DeclareSystemMediaTransportControls](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDeclareSystemMediaTransportControls)]

**PropertyChanged** イベントの登録と登録解除を行うコードは、上の例で示されているように、アプリの有効期間イベントに追加する必要があります。 このイベントのハンドラーでは、イベントをトリガーしたプロパティの変化が [**SystemMediaTransportControlsProperty.SoundLevel**](https://msdn.microsoft.com/library/windows/apps/dn278721) プロパティで生じたものかどうかを確認します。 変更を生じたのがこのプロパティであれば、プロパティの値を確認します。 値が [**SoundLevel.Muted**](https://msdn.microsoft.com/library/windows/apps/hh700852) であれば、アプリが最小化されているため、メディア キャプチャ リソースを正しくクリーンアップする必要があります。 それ以外の場合は、アプリ ウィンドウの復元がイベントによって通知されるので、メディア キャプチャ リソースを初期化する必要があります。 **SoundLevel** プロパティには UI スレッドでアクセスする必要があるため、このメソッドのコードは [**Dispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) への呼び出しでラップされています。

[!code-cs[SystemMediaControlsPropertyChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSystemMediaControlsPropertyChanged)]

## メディア キャプチャに関するその他の考慮事項

### 自動回転の基本設定

プレビュー ストリームの回転に関する前のセクションで説明したように、一部のデバイスでは、[**DisplayInformation.AutoRotationPreferences**](https://msdn.microsoft.com/library/windows/apps/dn264259) を設定することによって、デバイスの回転に伴うページ (プレビューを表示する [**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) を含む) の回転を回避できます。 この動作がサポートされているデバイスでは、このように設定すると優れたユーザー エクスペリエンスを確保できます。 この値は、アプリの起動時や、プレビュー表示の開始時に設定します。 自動回転の基本設定がサポートされていないデバイスについては、プレビューの回転処理を実装する必要があります。

[!code-cs[SetAutoRotationPreferences](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetAutoRotationPreferences)]

### UI 要素の向きを処理する

ユーザーは通常、カメラ アプリの UI 要素 (写真やビデオのキャプチャを開始するボタンなど) が、ビデオ プレビューと共に回転すると考えます。 次のメソッドは、向きに関する定義済みのヘルパー メソッドを使用して、カメラ UI のボタンを正しい向きにする方法を示しています。 このメソッドは、アプリが初めて起動する際に、[**DisplayInformation.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) イベント ハンドラーと [**SimpleOrientationSensor.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/br206407) イベント ハンドラーから呼び出す必要があります。 実装内容は、アプリの UI によって異なる場合があります。

[!code-cs[UpdateButtonOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUpdateButtonOrientation)]

アプリをシャットダウンするときや、メディア キャプチャに関係のないページに移動するときは、UI が通常どおりに回転されるように、自動回転設定を [**None**](https://msdn.microsoft.com/library/windows/apps/br226142) に設定します。

[!code-cs[RevertAutoRotationPreferences](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRevertAutoRotationPreferences)]

### 写真とビデオの同時キャプチャをサポートする

[
            **Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/br226738) API を使用すると、写真とビデオを同時にキャプチャできます (デバイスで、この機能がサポートされている必要があります)。 簡潔にするため、この例では [**ConcurrentRecordAndPhotoSupported**](https://msdn.microsoft.com/library/windows/apps/dn278843) プロパティを使ってビデオと写真の同時キャプチャがサポートされているかどうかを調べますが、カメラ プロファイルを使ってこれを行う方が堅牢なため、推奨されます。 詳しくは、「[カメラ プロファイル](camera-profiles.md)」をご覧ください。

次に示すヘルパー メソッドは、アプリの現在のキャプチャ状態に一致するように、アプリのコントロールを更新します。 このメソッドは、ビデオ キャプチャが開始または停止したときなど、アプリのキャプチャ状態が変化するたびに呼び出します。

[!code-cs[UpdateCaptureControls](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUpdateCaptureControls)]

### モバイル固有の UI 機能をサポートする

この記事で示すコードはすべて、ユニバーサル Windows アプリで動作します。 わずか数行のコードを追加するだけで、モバイル デバイスだけに存在する特別な UI 機能を活用できます。 これらの機能を使用するには、ユニバーサル アプリ プラットフォーム用 Microsoft Mobile Extension SDK への参照をプロジェクトに追加する必要があります。

**ハードウェア カメラ ボタンのサポート用にモバイル拡張 SDK への参照を追加するには**

1.  **ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

2.  **[Windows ユニバーサル]** ノードを展開し、**[拡張機能]** を選択します。

3.  **[Microsoft Mobile Extension SDK for Universal App Platform]** の横にあるチェック ボックスをオンにします。

モバイル デバイスには、デバイスに関する状態情報をユーザーに通知する [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) コントロールがあります。 このコントロールが表示される領域は、画面上でメディア キャプチャ UI の表示に干渉する可能性があります。 [
            **HideAsync**](https://msdn.microsoft.com/library/windows/apps/dn610339) を呼び出すことでステータス バーを非表示にできますが、呼び出しは、この API が利用可能かどうかを [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/dn949016) メソッドで確認する条件ブロック内で行う必要があります。 このメソッドは、ステータス バーをサポートするモバイル デバイスでのみ true を返します。 アプリの起動時や、またはカメラからプレビューを開始するときには、ステータス バーを非表示にする必要があります。

[!code-cs[HideStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHideStatusBar)]

アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、コントロールを再び表示します。

[!code-cs[ShowStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetShowStatusBar)]

一部のモバイル デバイスには、専用のハードウェア カメラ ボタンが用意されていることがあります。この仕様は、ユーザーによっては画面上のコントロールより好まれます。 このハードウェア カメラ ボタンが押されたときに通知を受け取るには、[**HardwareButtons.CameraPressed**](https://msdn.microsoft.com/library/windows/apps/dn653805) イベントのハンドラーを登録します。 この API を利用できるのはモバイル デバイスのみであるため、この場合も **IsTypePresent** を使用して、この API が現在のデバイスでサポートされているかどうかをアクセス前に確認する必要があります。

[!code-cs[PhoneUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPhoneUsing)]

[!code-cs[RegisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterCameraButtonHandler)]

**CameraPressed** イベントのハンドラーで、写真のキャプチャを開始できます。

[!code-cs[CameraPressed](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCameraPressed)]

アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、ハードウェア ボタンのハンドラーを登録解除します。

[!code-cs[UnregisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUnregisterCameraButtonHandler)]

**注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください。

## 関連トピック

* [カメラ プロファイル](camera-profiles.md)
* [ハイ ダイナミック レンジ (HDR) 写真のキャプチャ](high-dynamic-range-hdr-photo-capture.md)
* [写真とビデオのキャプチャのためのキャプチャ デバイス コントロール](capture-device-controls-for-photo-and-video-capture.md)
* [ビデオ キャプチャのためのキャプチャ デバイス コントロール](capture-device-controls-for-video-capture.md)
* [ビデオ キャプチャの効果](effects-for-video-capture.md)
* [メディア キャプチャのシーン分析](scene-analysis-for-media-capture.md)
* [可変の写真シーケンス](variable-photo-sequence.md)
* [プレビュー フレームの取得](get-a-preview-frame.md)
* [CameraStarterKit サンプル](http://go.microsoft.com/fwlink/?LinkId=619479)


<!--HONumber=Mar16_HO5-->


