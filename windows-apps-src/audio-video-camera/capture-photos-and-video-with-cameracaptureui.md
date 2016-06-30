---
author: drewbatgit
ms.assetid: CC0D6E9B-128D-488B-912F-318F5EE2B8D3
description: "この記事では、CameraCaptureUI クラスを使用して、Windows に組み込まれているカメラ UI で写真またはビデオをキャプチャする方法を説明します。"
title: "CameraCaptureUI を使った写真とビデオのキャプチャ"
translationtype: Human Translation
ms.sourcegitcommit: 72abc006de1925c3c06ecd1b78665e72e2ffb816
ms.openlocfilehash: a98edd0b4c52271fad4255af5ab0a005b0c66d68

---

# CameraCaptureUI を使った写真とビデオのキャプチャ

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


この記事では、CameraCaptureUI クラスを使用して、Windows に組み込まれているカメラ UI で写真またはビデオをキャプチャする方法を説明します。 この機能は使いやすく、わずか数行のコードで、ユーザーがキャプチャした写真やビデオをアプリに取り込むことができます。

キャプチャ操作に対して、より堅牢で低レベルな制御が必要であれば、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) オブジェクトを使用して、独自のキャプチャ操作を実装する必要があります。 詳しくは、「[MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)」をご覧ください。

## CameraCaptureUI を使った写真のキャプチャ

カメラ キャプチャ UI を使うには、プロジェクトに [**Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/br226738) 名前空間を含めます。 返された画像ファイルでファイル操作を行うには、[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) を含めます。

[!code-cs[UsingCaptureUI](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetUsingCaptureUI)]

写真をキャプチャするには、新しい [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) オブジェクトを作成します。 オブジェクトの [**PhotoSettings**](https://msdn.microsoft.com/library/windows/apps/br241058) プロパティを使うと、写真の画像形式など、返される写真のプロパティを指定することができます。 既定では、ユーザーはカメラ キャプチャ UI を使うことにより、返される前に写真のトリミングを行うことができます。ただし、この機能は [**AllowCropping**](https://msdn.microsoft.com/library/windows/apps/br241042) プロパティを使って無効にすることもできます。 この例では、[**CroppedSizeInPixels**](https://msdn.microsoft.com/library/windows/apps/br241044) を設定して、返される画像のサイズが 200 x 200 ピクセルになるよう要求しています。

**注:** モバイル デバイス ファミリのデバイスでは、CameraCaptureUI での画像のトリミングはサポートされていません。 アプリがこれらのデバイスで実行されている場合、[**AllowCropping**](https://msdn.microsoft.com/library/windows/apps/br241042) プロパティの値は無視されます。

写真をキャプチャすることを指定するには、[**CaptureFileAsync**](https://msdn.microsoft.com/library/windows/apps/br241057) を呼び出して、[**CameraCaptureUIMode.Photo**](https://msdn.microsoft.com/library/windows/apps/br241040) を指定します。 キャプチャに成功すると、このメソッドは、画像が格納された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) インスタンスを返します。 ユーザーがキャプチャを取り消した場合、返されるオブジェクトは null になります。

[!code-cs[CapturePhoto](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetCapturePhoto)]

キャプチャした写真が格納された **StorageFile** が返されたら、[**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトを作成できます。このオブジェクトは、ユニバーサル Windows アプリのさまざまな機能で使用できます。

まず、プロジェクトに [**Windows.Graphics.Imaging**](https://msdn.microsoft.com/library/windows/apps/br226400) 名前空間を含める必要があります。

[!code-cs[UsingSoftwareBitmap](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetUsingSoftwareBitmap)]

画像ファイルからストリームを取得するには、[**OpenAsync**](https://msdn.microsoft.com/library/windows/apps/br227116) を呼び出します。 ストリームのビットマップ デコーダーを取得するには、[**BitmapDecoder.CreateAsync**](https://msdn.microsoft.com/library/windows/apps/br226182) を呼び出します。 次に、[**GetSoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887332) を呼び出して、画像の **SoftwareBitmap** 表現を取得します。

[!code-cs[SoftwareBitmap](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetSoftwareBitmap)]

UI に画像を表示するには、XAML ページで [**Image**](https://msdn.microsoft.com/library/windows/apps/br242752) コントロールを宣言します。

[!code-xml[ImageControl](./code/CameraCaptureUIWin10/cs/MainPage.xaml#SnippetImageControl)]

XAML ページでソフトウェア ビットマップを使用するには、[**Windows.UI.Xaml.Media.Imaging**](https://msdn.microsoft.com/library/windows/apps/br243258) 名前空間の using 指定を含めます。

[!code-cs[UsingSoftwareBitmapSource](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetUsingSoftwareBitmapSource)]

**Image** コントロールでは、画像のソースが BGRA8 形式プリマルチプライ済みアルファまたはアルファなしであることが求められるため、静的メソッド [**SoftwareBitmap.Convert**](https://msdn.microsoft.com/library/windows/apps/dn887362) を呼び出して、目的の形式で新しいソフトウェア ビットマップを作成します。 次に、新しい [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/dn997854) オブジェクトを作成して [**SetBitmapAsync**](https://msdn.microsoft.com/library/windows/apps/dn997856) を呼び出し、ソフトウェア ビットマップをソースに割り当てます。 最後に、キャプチャした写真を UI に表示できるように、**Image** コントロールの [**Source**](https://msdn.microsoft.com/library/windows/apps/br242760) プロパティを設定します。

[!code-cs[SetImageSource](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetSetImageSource)]

## CameraCaptureUI を使ったビデオのキャプチャ

ビデオをキャプチャするには、新しい [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) オブジェクトを作成します。 オブジェクトの [**VideoSettings**](https://msdn.microsoft.com/library/windows/apps/br241059) プロパティを使うと、ビデオの形式など、返されるビデオのプロパティを指定することができます。

ビデオをキャプチャすることを指定するには、[**CaptureFileAsync**](https://msdn.microsoft.com/library/windows/apps/br241057) を呼び出して、[**Video**](https://msdn.microsoft.com/library/windows/apps/br241059) を指定します。 キャプチャに成功すると、このメソッドは、ビデオが格納された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) インスタンスを返します。 ユーザーがキャプチャを取り消した場合、返されるオブジェクトは null になります。

[!code-cs[CaptureVideo](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetCaptureVideo)]

キャプチャしたビデオ ファイルをどのように使うかは、アプリのシナリオによって異なります。 この記事の残りの部分では、キャプチャした 1 つ以上のビデオからメディア コンポジションをすばやく作成し、UI に表示する方法を説明します。

まず、ビデオ コンポジションを表示する [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) コントロールを XAML ページに追加します。

[!code-xml[MediaElement](./code/CameraCaptureUIWin10/cs/MainPage.xaml#SnippetMediaElement)]

[
            **Windows.Media.Editing**](https://msdn.microsoft.com/library/windows/apps/dn640565) 名前空間と [**Windows.Media.Core**](https://msdn.microsoft.com/library/windows/apps/dn278962) 名前空間をプロジェクトに追加します。


[!code-cs[UsingMediaComposition](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetUsingMediaComposition)]

[
            **MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646) オブジェクトおよび [**MediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn282716) のメンバー変数を宣言します。これらは、ページの有効期間の間、スコープ内で存続します。

[!code-cs[DeclareMediaComposition](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetDeclareMediaComposition)]

ビデオをキャプチャする前に 1 回だけ、**MediaComposition** クラスの新しいインスタンスを作成する必要があります。

[!code-cs[InitComposition](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetInitComposition)]

カメラ キャプチャ UI から返されたビデオ ファイルを使用し、[**MediaClip.CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn652607) を呼び出して、新しい [**MediaClip**](https://msdn.microsoft.com/library/windows/apps/dn652596) を作成します。 メディア クリップをコンポジションの [**Clips**](https://msdn.microsoft.com/library/windows/apps/dn652648) コレクションに追加します。

コンポジションから **MediaStreamSource** オブジェクトを作成するには、[**GeneratePreviewMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn652674) を呼び出します。

[!code-cs[AddToComposition](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetAddToComposition)]

最後に、コンポジションを UI に表示するには、メディア要素の [**SetMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn299029) メソッドを使用して、ストリーム ソースを設定します。

[!code-cs[SetMediaElementSource](./code/CameraCaptureUIWin10/cs/MainPage.xaml.cs#SnippetSetMediaElementSource)]

ビデオ クリップのキャプチャを続行して、コンポジションに追加することもできます。 メディア コンポジションについて詳しくは、「[メディア コンポジションと編集](media-compositions-and-editing.md)」をご覧ください。

**注:**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください。

 

## 関連トピック

* [MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)
* [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030)
 

 







<!--HONumber=Jun16_HO4-->


