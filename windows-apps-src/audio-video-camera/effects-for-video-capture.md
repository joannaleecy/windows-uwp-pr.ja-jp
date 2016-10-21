---
author: drewbatgit
ms.assetid: E0189423-1DF3-4052-AB2E-846EA18254C4
description: "このトピックでは、ビデオ手ブレ補正効果を使う方法について説明します。"
title: "ビデオ キャプチャの効果"
translationtype: Human Translation
ms.sourcegitcommit: 367ab34663d66d8c454ff305c829be66834e4ebe
ms.openlocfilehash: 3fe7abcc417db76b4375243d66b1c0ecb9092147

---

# ビデオ キャプチャの効果

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

このトピックでは、ビデオ手ブレ補正効果を使う方法について説明します。

> [!NOTE] 
> この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

## ビデオ手ブレ補正効果

ビデオ手ブレ補正効果は、キャプチャ デバイスを手で支えることによって生じる動きを極力目立たなくするために、ビデオ ストリームのフレームを操作します。 この手法を適用するとピクセルが上下左右に移動されますが、ビデオ フレームのすぐ外側に何があるのかは、手ブレ補正効果のロジックにはわからないため、手ブレ補正後は元のビデオがわずかにトリミングされた状態となります。 ここで紹介しているユーティリティ関数を使いビデオ エンコードの設定を調整することで、手ブレ補正効果によるトリミングをベストな状態に制御することができます。

デバイス側でサポートされていれば、Optical Image Stabilization (OIS) がキャプチャ デバイスを機械的に操作することでビデオのブレが抑えられるため、ビデオ フレームの端をトリミングする必要はありません。 詳しくは、「[ビデオ キャプチャのためのキャプチャ デバイス コントロール](capture-device-controls-for-video-capture.md)」をご覧ください。

### ビデオの手ブレ補正を行うようにアプリを設定する

ビデオ手ブレ補正効果を使うためには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間が必要となります。

[!code-cs[VideoStabilizationEffectUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVideoStabilizationEffectUsing)]

[**VideoStabilizationEffect**](https://msdn.microsoft.com/library/windows/apps/dn926760) オブジェクトを格納するためのメンバー変数を宣言します。 効果の実装の一部として、キャプチャしたビデオをエンコードするために使うエンコードのプロパティを変更します。 後で効果が無効にされたときに入出力のエンコード プロパティを復元できるよう、初期状態のバックアップ コピーを格納するための 2 つの変数を宣言します。 最後に、[**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) 型のメンバー変数を宣言します。メンバー変数として宣言しているのは、コードのいたるところからこのオブジェクトにアクセスすることになるためです。

[!code-cs[DeclareVideoStabilizationEffect](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDeclareVideoStabilizationEffect)]

このシナリオでは、後からアクセスできるようメディア エンコード プロファイル オブジェクトをメンバー変数に代入する必要があります。

[!code-cs[EncodingProfileMember](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetEncodingProfileMember)]

### ビデオ手ブレ補正効果を初期化する

**MediaCapture** オブジェクトの初期化後、[**VideoStabilizationEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn926762) オブジェクトの新しいインスタンスを作成します。 効果をビデオ パイプラインに追加し、[**VideoStabilizationEffect**](https://msdn.microsoft.com/library/windows/apps/dn926760) クラスのインスタンスを取得するには、[**MediaCapture.AddVideoEffectAsync**](https://msdn.microsoft.com/library/windows/apps/dn878035) を呼び出します。 [**MediaStreamType.VideoRecord**](https://msdn.microsoft.com/library/windows/apps/br226640) を指定すると、ビデオ レコード ストリームに効果を適用する、という意味になります。

[**EnabledChanged**](https://msdn.microsoft.com/library/windows/apps/dn948982) イベントのハンドラーを登録し、ヘルパー メソッド **SetUpVideoStabilizationRecommendationAsync** を呼び出します。詳細については後で説明します。 最後に、[**Enabled**](https://msdn.microsoft.com/library/windows/apps/dn926775) プロパティを true に設定して効果を有効にします。

[!code-cs[CreateVideoStabilizationEffect](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCreateVideoStabilizationEffect)]

### 推奨エンコード プロパティを使う

先ほども触れましたが、ビデオ手ブレ補正効果に使われている手法では必然的に、補正後、わずかですが元のビデオがトリミングされます。 これは手ブレ補正効果の制限です。ビデオ エンコード プロパティを調整して、できるだけ適切に対処するために、以下のヘルパー関数をコードの中で定義してください。 このステップはビデオ手ブレ補正効果を使ううえで必須ではありませんが、これを省略した場合、最終的に得られるビデオが若干アップスケーリングされるために、ビジュアルの再現性がわずかに低下します。

VideoStabilizationEffect のインスタンスの [**GetRecommendedStreamConfiguration**](https://msdn.microsoft.com/library/windows/apps/dn948983) を呼び出します。このメソッドは、ビデオ補正効果に対して現在の入力ストリームのエンコード プロパティを伝える [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) オブジェクトと、現在の出力エンコード プロパティを伝える **MediaEncodingProfile** とを引数として受け取ります。 このメソッドの戻り値である [**VideoStreamConfiguration**](https://msdn.microsoft.com/library/windows/apps/dn926727) オブジェクトには、入力ストリームと出力ストリームの最新の推奨エンコード プロパティが格納されます。

効果のトリミング適用後に失われる解像度を最小限にするために、入力の推奨エンコード プロパティは、デバイスによってサポートされる範囲で、指定した初期設定よりも解像度が高くなります。

新しいエンコード プロパティを設定するには、[**VideoDeviceController.SetMediaStreamPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh700895) を呼び出します。 効果を無効にしたときに設定を元に戻すことができるよう、新しいプロパティを設定する前にメンバー変数を使って初期エンコード プロパティを保存します。

ビデオ手ブレ補正効果で出力ビデオをトリミングする必要がある場合、出力の推奨エンコード プロパティは、トリミングされたビデオのサイズになります。 つまり出力の解像度は、トリミングされたビデオのサイズと一致します。 推奨される出力プロパティを使わなかった場合、最初の出力サイズに合わせてビデオがアップスケーリングされるため、ビジュアルの再現性が低下します。

**MediaEncodingProfile** オブジェクトの [**Video**](https://msdn.microsoft.com/library/windows/apps/hh701124) プロパティを設定します。 効果を無効にしたときに設定を元に戻すことができるよう、新しいプロパティを設定する前にメンバー変数を使って初期エンコード プロパティを保存します。

[!code-cs[SetUpVideoStabilizationRecommendationAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetUpVideoStabilizationRecommendationAsync)]

### ビデオ手ブレ補正効果の無効化イベントを処理する

ピクセル スループットが高すぎて効果の処理が追い付かない場合や、効果の実行に時間がかかっていることをシステムが検出した場合、ビデオ手ブレ補正効果がシステムによって自動的に無効化されます。 このように状態が変化した場合、EnabledChanged イベントが発生します。 最新の効果の状態 (有効または無効) は、*sender* パラメーターに格納された **VideoStabilizationEffect** のインスタンスによって知ることができます。 [**VideoStabilizationEffectEnabledChangedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn948979) に格納される [**VideoStabilizationEffectEnabledChangedReason**](https://msdn.microsoft.com/library/windows/apps/dn948981) の値は、効果が有効または無効にされた理由を示しています。 このイベントは、プログラムから効果を有効または無効にした場合にも発生します。この場合の理由は **Programmatic** になります。

通常、このイベントを使ってアプリの UI を調整し、ビデオ手ブレ補正の現在の状態を示します。

[!code-cs[VideoStabilizationEnabledChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVideoStabilizationEnabledChanged)]

### ビデオ手ブレ補正効果をクリーンアップする

ビデオ手ブレ補正効果をクリーンアップするには、[**ClearEffectsAsync**](https://msdn.microsoft.com/library/windows/apps/br226592) を呼び出してビデオ パイプラインからすべての効果を消去します。 初期エンコード プロパティを格納しているメンバー変数が null 以外であれば、それらの変数を使ってエンコード プロパティを復元します。 最後に、**EnabledChanged** イベント ハンドラーを削除し、効果を null に設定します。

[!code-cs[CleanUpVisualStabilizationEffect](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpVisualStabilizationEffect)]

## 関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 







<!--HONumber=Aug16_HO3-->


