---
ms.assetid: 9BA3F85A-970F-411C-ACB1-B65768B8548A
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで XAML ページ内にカメラ プレビュー ストリームをすばやく表示する方法について説明します。
title: カメラ プレビューの表示
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 24b2885597599607ca405e858a9f713f5a6af4c7
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7840350"
---
# <a name="display-the-camera-preview"></a>カメラ プレビューの表示


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで XAML ページ内にカメラ プレビュー ストリームをすばやく表示する方法について説明します。 カメラを使って写真やビデオをキャプチャするアプリを作成するには、デバイスとカメラの向きの処理や、キャプチャされたファイルのエンコーディング オプションの設定などのタスクを実行する必要があります。 アプリ シナリオによっては、このような他の考慮事項について考えなくても、カメラからプレビュー ストリームをそのまま表示することができます。 この記事では、最小限のコードでそれを行う方法を示します。 プレビュー ストリームの操作が完了したら、必ず以下の手順に従ってプレビュー ストリームを正しくシャットダウンする必要がある点に注意してください。

写真やビデオをキャプチャするカメラ アプリの作成方法について詳しくは、「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」をご覧ください。

## <a name="add-capability-declarations-to-the-app-manifest"></a>アプリ マニフェストに機能宣言を追加する

アプリからデバイスのカメラにアクセスするには、アプリでデバイス機能 ( *webcam* と *microphone* ) の使用を宣言する必要があります。 

**アプリ マニフェストに機能を追加する**

1.  Microsoft Visual Studio では、**ソリューション エクスプローラー**で **package.appxmanifest** 項目をダブルクリックし、アプリケーション マニフェストのデザイナーを開きます。
2.  **[機能]** タブをクリックします。
3.  **[Web カメラ]** のボックスと **[マイク]** のボックスをオンにします。

## <a name="add-a-captureelement-to-your-page"></a>ページに CaptureElement コントロールを追加する

[**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) を使って、XAML ページ内にプレビュー ストリームを表示します。

[!code-xml[CaptureElement](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml#SnippetCaptureElement)]



## <a name="use-mediacapture-to-start-the-preview-stream"></a>MediaCapture を使ってプレビュー ストリームを開始する

[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) オブジェクトは、デバイスのカメラに対するアプリのインターフェイスです。 このクラスは、Windows.Media.Capture 名前空間のメンバーです。 この記事の例では、既定のプロジェクト テンプレートに含まれている API に加えて、[**Windows.ApplicationModel**](https://msdn.microsoft.com/library/windows/apps/br224691) 名前空間と [System.Threading.Tasks](https://msdn.microsoft.com/library/windows/apps/xaml/system.threading.tasks.aspx) 名前空間の API も使われます。

ページの .cs ファイルに次の名前空間を含めるには using ディレクティブを追加します。

[!code-cs[SimpleCameraPreviewUsing](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetSimpleCameraPreviewUsing)]

**MediaCapture** オブジェクトのクラス メンバー変数と、カメラが現在プレビューを表示しているかどうかを追跡するブール値を宣言します。 

[!code-cs[DeclareMediaCapture](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeclareMediaCapture)]

プレビューの実行中にディスプレイがオフになっていないことを確認するために使用する、[**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.System.Display.DisplayRequest) 型の変数を宣言します。

[!code-cs[DeclareDisplayRequest](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeclareDisplayRequest)]

カメラのプレビューを起動するヘルパー メソッド (この例では **StartPreviewAsync**) を作成します。 アプリのシナリオによって、ページが読み込まれるときに呼び出される **OnNavigatedTo** イベント ハンドラーからこれを呼び出すことも、UI イベントへの応答でプレビューを待機して起動することもできます。

**MediaCapture** クラスの新しいインスタンスを作成し、[**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) を呼び出してキャプチャ デバイスを初期化します。 カメラがないデバイスなどではこのメソッドが失敗することがあるため、**try** ブロック内から呼び出してください。 ユーザーがデバイスのプライバシー設定でカメラへのアクセスを無効にしている場合、カメラを初期化しようとすると **UnauthorizedAccessException** がスローされます。 この例外は、開発中、アプリ マニフェストに適切な機能を追加し忘れた場合も表示されます。

**重要:** 一部のデバイス ファミリでは、アプリがデバイスのカメラへのアクセスを許可される前に、ユーザー同意のプロンプトがユーザーに表示されます。 このため、[**MediaCapture.InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) のみをメイン UI スレッドから呼び出す必要があります。 別のスレッドからカメラを初期化しようとすると、初期化エラーになる可能性があります。

[**Source**](https://msdn.microsoft.com/library/windows/apps/br209280) プロパティを設定して、**MediaCapture** を **CaptureElement** に接続します。 [**StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613) を呼び出してプレビューを開始します。 別のアプリがキャプチャ デバイスを排他的に制御している場合、このメソッドは **FileLoadException** をスローします。 排他的制御での変更をリッスンについては、次のセクションを参照してください。

[**RequestActive**](https://msdn.microsoft.com/library/windows/apps/Windows.System.Display.DisplayRequest.RequestActive) を呼び出して、プレビューの実行中にデバイスがスリープ状態にならないことを確認します。 最後に、[**DisplayInformation.AutoRotationPreferences**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Display.DisplayInformation.AutoRotationPreferences) プロパティを [**Landscape**](https://msdn.microsoft.com/library/windows/apps/Windows.Graphics.Display.DisplayOrientations) に設定して、ユーザーがデバイスの向きを変更したときに UI と **CaptureElement** が回転することを防ぎます。 デバイスの向きの変更処理について詳しくは、「[**MediaCapture を使ってデバイスの向きを処理する**](handle-device-orientation-with-mediacapture.md)」をご覧ください。  

[!code-cs[StartPreviewAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetStartPreviewAsync)]

## <a name="handle-changes-in-exclusive-control"></a>排他的制御での変更を処理する
前のセクションで説明したように、別のアプリがキャプチャ デバイスを排他的に制御している場合、**StartPreviewAsync** は **FileLoadException** をスローします。 Windows 10 Version 1703 以降では、デバイスの排他的制御の状態が変化するたびに発生する [MediaCapture.CaptureDeviceExclusiveControlStatusChanged](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.MediaCapture.CaptureDeviceExclusiveControlStatusChanged) イベントのハンドラーを登録できます。 このイベントのハンドラーで、[MediaCaptureDeviceExclusiveControlStatusChangedEventArgs.Status](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapturedeviceexclusivecontrolstatuschangedeventargs.Status) プロパティを調べて、現在の状態を確認します。 新しい状態が **SharedReadOnlyAvailable** である場合、現在プレビューを開始できないことがわかり、UI を更新してユーザーに警告することができます。 新しい状態が **ExclusiveControlAvailable** である場合は、カメラのプレビューを再試行することができます。

[!code-cs[ExclusiveControlStatusChanged](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetExclusiveControlStatusChanged)]

## <a name="shut-down-the-preview-stream"></a>プレビュー ストリームをシャットダウンする

プレビュー ストリームを使い終わったら、必ずストリームをシャットダウンして関連するリソースを適切に破棄し、デバイスで他のアプリがカメラを使うことができるようにしてください。 プレビュー ストリームをシャットダウンするために必要な手順は次のとおりです。

-   現在、カメラがプレビューを表示中の場合は、[**StopPreviewAsync** ](https://msdn.microsoft.com/library/windows/apps/br226622) を呼び出してプレビュー ストリームを停止します。 プレビューが実行されていないときに **StopPreviewAsync** を呼び出すと、例外がスローされます。
-   **CaptureElement** の [**Source**](https://msdn.microsoft.com/library/windows/apps/br209280) プロパティを null に設定します。 [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.runasync.aspx) を使用して、この呼び出しが UI スレッドで実行されることを確認します。
-   **MediaCapture** オブジェクトの [**Dispose**](https://msdn.microsoft.com/library/windows/apps/dn278858) メソッドを呼び出してオブジェクトを解放します。 再度、[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.runasync.aspx) を使用して、この呼び出しが UI スレッドで実行されることを確認します。
-   **MediaCapture** メンバー変数を null に設定します。
-   [**RequestRelease**](https://msdn.microsoft.com/library/windows/apps/Windows.System.Display.DisplayRequest.RequestRelease) を呼び出して、アクティブでないときに画面をオフにできるようにします。

[!code-cs[CleanupCameraAsync](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetCleanupCameraAsync)]

[**OnNavigatedFrom**](https://msdn.microsoft.com/library/windows/apps/br227507) メソッドをオーバーライドすることで、ユーザーがページから離れるときにプレビュー ストリームをシャットダウンする必要があります。

[!code-cs[OnNavigatedFrom](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetOnNavigatedFrom)]

アプリの中断中もプレビュー ストリームを適切にシャットダウンする必要があります。 これを行うには、ページのコンストラクターで [**Application.Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントのハンドラーを登録します。

[!code-cs[RegisterSuspending](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetRegisterSuspending)]

**Suspending** イベント ハンドラーで、まずページの種類と [**CurrentSourcePageType**](https://msdn.microsoft.com/library/windows/apps/hh702390) プロパティを比較することで、アプリケーションの [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) にページが表示されることを確認します。 ページが現在表示されていない場合、**OnNavigatedFrom** イベントが既に発生しており、プレビュー ストリームはシャットダウンしています。 現在ページが表示されている場合、ハンドラーに渡されるイベント引数から [**SuspendingDeferral**](https://msdn.microsoft.com/library/windows/apps/br224684) オブジェクトを取得し、プレビュー ストリームがシャットダウンするまでシステムがアプリを中断しないことを確認します。 ストリームをシャットダウンした後、保留の [**Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) メソッドを呼び出し、システムがアプリの中断を続行できるようにします。

[!code-cs[SuspendingHandler](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetSuspendingHandler)]


## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [プレビュー フレームの取得](get-a-preview-frame.md)
