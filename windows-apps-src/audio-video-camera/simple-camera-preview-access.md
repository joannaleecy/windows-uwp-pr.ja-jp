---
ms.assetid: 9BA3F85A-970F-411C-ACB1-B65768B8548A
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで XAML ページ内にカメラ プレビュー ストリームをすばやく表示する方法について説明します。
title: シンプルなカメラ プレビューへのアクセス
---

# シンプルなカメラ プレビューへのアクセス

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで XAML ページ内にカメラ プレビュー ストリームをすばやく表示する方法について説明します。 カメラを使って写真やビデオをキャプチャするアプリを作成するには、デバイスとカメラの向きの処理や、キャプチャされたファイルのエンコーディング オプションの設定などのタスクを実行する必要があります。 アプリ シナリオによっては、このような他の考慮事項について考えなくても、カメラからプレビュー ストリームをそのまま表示することができます。 この記事では、最小限のコードでそれを行う方法を示します。 プレビュー ストリームの操作が完了したら、必ず以下の手順に従ってプレビュー ストリームを正しくシャットダウンする必要がある点に注意してください。

写真やビデオをキャプチャするカメラ アプリの作成方法について詳しくは、「[MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)」をご覧ください。

## アプリ マニフェストに機能宣言を追加する

アプリからデバイスのカメラにアクセスするには、アプリでデバイス機能 (*webcam* と *microphone*) の使用を宣言する必要があります。 キャプチャした写真とビデオをユーザーの画像ライブラリまたはビデオ ライブラリに保存する場合は、*picturesLibrary* 機能と *videosLibrary* 機能も宣言する必要があります。

**アプリ マニフェストに機能を追加する**

1.  Microsoft Visual Studio では、**ソリューション エクスプローラー**で **package.appxmanifest** 項目をダブルクリックし、アプリケーション マニフェストのデザイナーを開きます。
2.  **[機能]** タブをクリックします。
3.  **[Web カメラ]** のボックスと **[マイク]** のボックスをオンにします。
4.  画像ライブラリとビデオ ライブラリにアクセスするには、**画像ライブラリ**のボックスと**ビデオ ライブラリ**のボックスをオンにします。

## ページに CaptureElement コントロールを追加する

[
            **CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) を使って、XAML ページ内にプレビュー ストリームを表示します。

[!code-xml[CaptureElement](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml#SnippetCaptureElement)]

## MediaCapture を使ってプレビュー ストリームを開始する

[
            **MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) オブジェクトは、デバイスのカメラに対するアプリのインターフェイスです。 このクラスは、Windows.Media.Capture 名前空間のメンバーです。 この記事の例では、既定のプロジェクト テンプレートに含まれている API に加えて、[**Windows.ApplicationModel**](https://msdn.microsoft.com/library/windows/apps/br224691) 名前空間と [System.Threading.Tasks](https://msdn.microsoft.com/library/windows/apps/xaml/system.threading.tasks.aspx) 名前空間の API も使われます。

[!code-cs[CaptureElement](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml#SnippetCaptureElement)]

ページの .cs ファイルに次の名前空間を含めるには using ディレクティブを追加します。

[!code-cs[SimpleCameraPreviewUsing](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetSimpleCameraPreviewUsing)]

**MediaCapture** オブジェクトのクラス変数を宣言します。

[!code-cs[DeclareMediaCapture](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeclareMediaCapture)]

**MediaCapture** クラスの新しいインスタンスを作成し、[**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) を呼び出してキャプチャ デバイスを初期化します。 カメラがないデバイスなどではこのメソッドが失敗することがあるため、**try** ブロック内から呼び出してください。 ユーザーがデバイスのプライバシー設定でカメラへのアクセスを無効にしている場合、カメラを初期化しようとすると **UnauthorizedAccessException** がスローされます。 この例外は、開発中、アプリ マニフェストに適切な機能を追加し忘れた場合も表示されます。

**重要** 一部のデバイス ファミリでは、アプリがデバイスのカメラへのアクセスを付与される前に、ユーザー同意のプロンプトがユーザーに表示されます。 このため、[**MediaCapture.InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) のみをメイン UI スレッドから呼び出す必要があります。 別のスレッドからカメラを初期化しようとすると、初期化エラーになる可能性があります。

[
            **Source**](https://msdn.microsoft.com/library/windows/apps/br209280) プロパティを設定して、**MediaCapture** を **CaptureElement** に接続します。 最後に、[**StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613) を呼び出してプレビューを開始します。

[!code-cs[StartPreviewAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStartPreviewAsync)]


## プレビュー ストリームをシャットダウンする

プレビュー ストリームを使い終わったら、必ずストリームをシャットダウンして関連するリソースを適切に破棄し、デバイスで他のアプリがカメラを使うことができるようにしてください。 プレビュー ストリームをシャットダウンするために必要な手順は次のとおりです。

-   [
            **StopPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226622) を呼び出してプレビュー ストリームを停止します。
-   **CaptureElement** の [**Source**](https://msdn.microsoft.com/library/windows/apps/br209280) プロパティを null に設定します。
-   **MediaCapture** オブジェクトの [**Dispose**](https://msdn.microsoft.com/library/windows/apps/dn278858) メソッドを呼び出してオブジェクトを解放します。
-   **MediaCapture** メンバー変数を null に設定します。

[!code-cs[CleanupCameraAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetCleanupCameraAsync)]

[
            **OnNavigatedFrom**](https://msdn.microsoft.com/library/windows/apps/br227507) メソッドをオーバーライドすることで、ユーザーがページから離れるときにプレビュー ストリームをシャットダウンする必要があります。

[!code-cs[OnNavigatedFrom](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetOnNavigatedFrom)]

アプリの中断中もプレビュー ストリームを適切にシャットダウンする必要があります。 これを行うには、ページのコンストラクターで [**Application.Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントのハンドラーを登録します。

[!code-cs[RegisterSuspending](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetRegisterSuspending)]

**Suspending** イベント ハンドラーで、まずページの種類と [**CurrentSourcePageType**](https://msdn.microsoft.com/library/windows/apps/hh702390) プロパティを比較することで、アプリケーションの [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) にページが表示されることを確認します。 ページが現在表示されていない場合、**OnNavigatedFrom** イベントが既に発生しており、プレビュー ストリームはシャットダウンしています。 現在ページが表示されている場合、ハンドラーに渡されるイベント引数から [**SuspendingDeferral**](https://msdn.microsoft.com/library/windows/apps/br224684) オブジェクトを取得し、プレビュー ストリームがシャットダウンするまでシステムがアプリを中断しないことを確認します。 ストリームをシャットダウンした後、保留の [**Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) メソッドを呼び出し、システムがアプリの中断を続行できるようにします。

[!code-cs[SuspendingHandler](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetSuspendingHandler)]

## プレビュー ストリームから静止画像をキャプチャする

メディア キャプチャのプレビュー ストリームから、[**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) 形式で静止画像を取得するのは簡単です。 詳しくは、「[プレビュー フレームの取得](get-a-preview-frame.md)」をご覧ください。

## 関連トピック

* [MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)
* [プレビュー フレームの取得](get-a-preview-frame.md)


<!--HONumber=Mar16_HO5-->


