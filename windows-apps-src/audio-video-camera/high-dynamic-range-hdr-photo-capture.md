---
author: drewbatgit
ms.assetid: 0186EA01-8446-45BA-A109-C5EB4B80F368
description: ハイ ダイナミック レンジ (HDR) の写真は、AdvancedPhotoCapture クラスを使ってキャプチャできます。
title: ハイ ダイナミック レンジ (HDR) 写真のキャプチャ
---

# ハイ ダイナミック レンジ (HDR) 写真のキャプチャ

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、「[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)」をご覧ください\]


ハイ ダイナミック レンジ (HDR) の写真は、[**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) クラスを使ってキャプチャできます。 最終的な画像の処理が完了する前に、この API を使って、HDR キャプチャから参照フレームを取得することもできます。

HDR キャプチャに関連したその他の記事を以下に示します。

-   [
            **SceneAnalysisEffect**](https://msdn.microsoft.com/library/windows/apps/dn948902) でメディア キャプチャのプレビュー ストリームの内容をシステムで評価し、HDR 処理によるキャプチャ結果の向上が期待できるかどうかを判断できます。 詳しくは、「[メディア キャプチャのシーン分析](scene-analysis-for-media-capture.md)」をご覧ください

-   [
            **HdrVideoControl**](https://msdn.microsoft.com/library/windows/apps/dn926680) で、Windows に組み込まれている HDR 処理アルゴリズムを使ってビデオをキャプチャします。 詳しくは、「[ビデオ キャプチャのためのキャプチャ デバイス コントロール](capture-device-controls-for-video-capture.md)」をご覧ください。

-   [
            **VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) を使うと、キャプチャ設定がそれぞれ異なる一連の写真をキャプチャすることができます。HDR またはその他の処理アルゴリズムを独自に実装することが可能です。 詳しくは、「[可変の写真シーケンス](variable-photo-sequence.md)」をご覧ください。

**注**
-   **AdvancedPhotoCapture** を使ってビデオの録画と写真のキャプチャを同時に行うことはサポートされていません。

-   高度な写真キャプチャ時にカメラのフラッシュを使うことはできません。

**注** この記事は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)」で取り上げた概念やコードを基に執筆されています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

## HDR 写真キャプチャの名前空間

HDR 写真キャプチャを使うには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間をアプリに追加する必要があります。

[!code-cs[HDRPhotoUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHDRPhotoUsing)]


## HDR 写真キャプチャが現在のデバイスでサポートされているかどうかを調べる

この記事で説明されている HDR キャプチャ手法には、[**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) オブジェクトが使われています。 デバイスによっては、**AdvancedPhotoCapture** での HDR キャプチャがサポートされません。 現在アプリを実行しているデバイスが、この手法をサポートしているかどうかを調べるには、**MediaCapture** オブジェクトの [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) を取得し、その [**AdvancedPhotoControl**](https://msdn.microsoft.com/library/windows/apps/mt147840) プロパティを取得します。 ビデオ デバイス コントローラーの [**SupportedModes**](https://msdn.microsoft.com/library/windows/apps/mt147844) コレクションに [**AdvancedPhotoMode.Hdr**](https://msdn.microsoft.com/library/windows/apps/mt147845) が含まれているかどうかを確認してください。 コレクションに含まれている場合、**AdvancedPhotoCapture** を使った HDR キャプチャがサポートされています。

[!code-cs[HdrSupported](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHdrSupported)]

## AdvancedPhotoCapture オブジェクトを構成して準備する

[
            **AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) インスタンスにはコード内の複数の場所からアクセスする必要があるので、そのオブジェクトを保持するメンバー変数を宣言する必要があります。

[!code-cs[DeclareAdvancedCapture](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDeclareAdvancedCapture)]

アプリのコードで、**MediaCapture** オブジェクトを初期化した後、[**AdvancedPhotoCaptureSettings**](https://msdn.microsoft.com/library/windows/apps/mt147837) オブジェクトを作成し、そのモードを [**AdvancedPhotoMode.Hdr**](https://msdn.microsoft.com/library/windows/apps/mt147845) に設定します。 作成した **AdvancedPhotoCaptureSettings** オブジェクトを [**AdvancedPhotoControl**](https://msdn.microsoft.com/library/windows/apps/mt147840) オブジェクトの [**Configure**](https://msdn.microsoft.com/library/windows/apps/mt147841) メソッドに渡して呼び出します。

**MediaCapture** オブジェクトの [**PrepareAdvancedPhotoCaptureAsync**](https://msdn.microsoft.com/library/windows/apps/mt181403) を呼び出す際に [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) オブジェクトを渡し、キャプチャで使うエンコードの種類を指定します。 **ImageEncodingProperties** には、**MediaCapture** でサポートされる画像エンコードを作成するための静的メソッドがあります

**PrepareAdvancedPhotoCaptureAsync** からは [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) オブジェクトが返されます。写真キャプチャの初期化にはこのオブジェクトを使うことになります。 後ほど説明する [**OptionalReferencePhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181392) と [**AllPhotosCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181387) のハンドラーは、このオブジェクトを使って登録することができます。

[!code-cs[CreateAdvancedCaptureAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCreateAdvancedCaptureAsync)]

## HDR 写真をキャプチャする

HDR 写真をキャプチャするには、[**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) オブジェクトの [**CaptureAsync**](https://msdn.microsoft.com/library/windows/apps/mt181388) メソッドを呼び出します。 このメソッドから返される [**AdvancedCapturedPhoto**](https://msdn.microsoft.com/library/windows/apps/mt181378) オブジェクトの [**Frame**](https://msdn.microsoft.com/library/windows/apps/mt181382) プロパティに、キャプチャされた写真が格納されています。

[!code-cs[CaptureHdrPhotoAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCaptureHdrPhotoAsync)]

**ConvertOrientationToPhotoOrientation** と **ReencodeAndSavePhotoAsync** は、ヘルパー メソッドです。「[MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)」の記事で紹介した基本的なメディア キャプチャのシナリオの中で取り上げました。

## 必要に応じて参照フレームを取得する

HDR プロセスは複数のフレームをキャプチャします。そのすべてのフレームがキャプチャされると、それらが単一の画像として合成されます。 フレームがキャプチャされた後、HDR プロセス全体が完了する前に、[**OptionalReferencePhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181392) イベントを処理することでそのフレームにアクセスすることができます。 HDR 写真の最終的な結果だけが目的であれば、この処理は不要です。

**重要**
            
          
            ハードウェア HDR をサポートしていて参照フレームを生成しないデバイスでは、[
              **OptionalReferencePhotoCaptured**
            ](https://msdn.microsoft.com/library/windows/apps/mt181392) は発生しません。 アプリ側で、このイベントが生成されないケースに対処する必要があります。

参照フレームは **CaptureAsync** 呼び出しのコンテキストから離れて届くため、**OptionalReferencePhotoCaptured** ハンドラーにコンテキスト情報を渡すためのしくみが用意されています。 まず、コンテキスト情報を保持するオブジェクトが必要です。 このオブジェクトの名前と内容は自由に設定してください。 この例のオブジェクトには、キャプチャのファイル名とカメラの向きを追跡するためのメンバーが定義されています。

[!code-cs[AdvancedCaptureContext](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetAdvancedCaptureContext)]

コンテキスト オブジェクトの新しいインスタンスを作成して、そのメンバーにデータを設定した後、パラメーターとしてオブジェクトを受け取る [**CaptureAsync**](https://msdn.microsoft.com/library/windows/apps/mt181388) のオーバーロードにそのオブジェクトを渡します。

[!code-cs[CaptureWithContext](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCaptureWithContext)]

[
            **OptionalReferencePhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181392) イベント ハンドラーで、[**OptionalReferencePhotoCapturedEventArgs**](https://msdn.microsoft.com/library/windows/apps/mt181404) オブジェクトの [**Context**](https://msdn.microsoft.com/library/windows/apps/mt181405) プロパティを、先ほど定義したコンテキスト オブジェクト クラスにキャストします。 この例では、最終的な HDR 画像と区別するために参照フレーム画像のファイル名を変更した上で **ReencodeAndSavePhotoAsync** ヘルパー メソッドを呼び出し、画像を保存しています。

[!code-cs[OptionalReferencePhotoCaptured](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOptionalReferencePhotoCaptured)]

## すべてのフレームがキャプチャされたときに通知を受け取る

HDR 写真のキャプチャには、2 つのステップがあります。 複数のフレームをキャプチャするステップと、その後、それらのフレームが最終的な HDR 画像に加工するステップです。 ソース HDR フレームのキャプチャ中に別のキャプチャを開始することはできませんが、すべてのフレームがキャプチャされた後であれば、HDR の後処理が完了していなくても、キャプチャを開始することができます。 HDR キャプチャが完了すると [**AllPhotosCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181387) イベントが発生するので、そのタイミングで別のキャプチャを開始することができます。 たとえば HDR キャプチャの開始時に UI のキャプチャ ボタンを無効にし、その後 **AllPhotosCaptured** が発生した時点で再度ボタンを有効にする、という使い方が考えられます。

[!code-cs[AllPhotosCaptured](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetAllPhotosCaptured)]

## AdvancedPhotoCapture オブジェクトのクリーンアップ

キャプチャが終了したら、**MediaCapture** オブジェクトを破棄する前に、[**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/mt181391) を呼び出し、メンバー変数を null に設定して [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) オブジェクトをシャットダウンする必要があります。

[!code-cs[CleanUpAdvancedPhotoCapture](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpAdvancedPhotoCapture)]

## 関連トピック

* [MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)


<!--HONumber=May16_HO2-->


