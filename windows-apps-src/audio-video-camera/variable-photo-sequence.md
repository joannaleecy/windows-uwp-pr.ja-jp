---
author: drewbatgit
ms.assetid: 7DBEE5E2-C3EC-4305-823D-9095C761A1CD
description: この記事では、可変の写真シーケンスをキャプチャする方法について説明します。これによって、画像を複数のフレームとして次々とキャプチャし、各フレームに別々のフォーカス、フラッシュ、ISO、露出、露出補正の設定を適用することができます。
title: 可変の写真シーケンス
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 91a7d69d945b2ba2452d5bc477b6c17bf1dc6845
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5755796"
---
# <a name="variable-photo-sequence"></a>可変の写真シーケンス



この記事では、可変の写真シーケンスをキャプチャする方法について説明します。これによって、画像を複数のフレームとして次々とキャプチャし、各フレームに別々のフォーカス、フラッシュ、ISO、露出、露出補正の設定を適用することができます。 この機能により、ハイ ダイナミック レンジ (HDR) 画像を作成するなどのシナリオが実現できます。

HDR 画像をキャプチャするときに、独自の処理アルゴリズムを実装しない場合は、[**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) API を使って、Windows に組み込まれた HDR 機能を利用できます。 詳しくは、「[ハイ ダイナミック レンジ (HDR) 写真のキャプチャ](high-dynamic-range-hdr-photo-capture.md)」をご覧ください。

> [!NOTE] 
> この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

## <a name="set-up-your-app-to-use-variable-photo-sequence-capture"></a>可変の写真シーケンス キャプチャを使うようにアプリを設定する

可変の写真シーケンス キャプチャを実装するためには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間が必要となります。

[!code-cs[VPSUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVPSUsing)]

写真シーケンス キャプチャを開始するために使用される [**VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) オブジェクトを格納するためのメンバー変数を宣言します。 シーケンス内でキャプチャされた各画像を格納するための [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトの配列を宣言します。 また、各フレームの [**CapturedFrameControlValues**](https://msdn.microsoft.com/library/windows/apps/dn608020) オブジェクトを格納するための配列も宣言します。 この配列は、画像処理アルゴリズムで、各フレームのキャプチャにどのような設定が使用されたかを確認するために使うことができます。 最後に、シーケンス内で現在キャプチャされているのがどの画像かを追跡するために使用される、インデックスを宣言します。

[!code-cs[VPSMemberVariables](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVPSMemberVariables)]

## <a name="prepare-the-variable-photo-sequence-capture"></a>可変の写真シーケンス キャプチャを準備する

[MediaCapture](capture-photos-and-video-with-mediacapture.md) を初期化した後は、可変の写真シーケンスが現在のデバイスでサポートされていることを確認します。そのためには、[**VariablePhotoSequenceController**](https://msdn.microsoft.com/library/windows/apps/dn640573) のインスタンスをメディア キャプチャの [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) から取得し、[**Supported**](https://msdn.microsoft.com/library/windows/apps/dn640580) プロパティを調べます。

[!code-cs[IsVPSSupported](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetIsVPSSupported)]

可変の写真シーケンスのコントローラーから [**FrameControlCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652548) オブジェクトを取得します。 このオブジェクトには、写真シーケンスのフレームごとに構成できるすべての設定のプロパティが含まれています。 次のようなプロパティが含まれています。

-   [**Exposure**](https://msdn.microsoft.com/library/windows/apps/dn652552)
-   [**ExposureCompensation**](https://msdn.microsoft.com/library/windows/apps/dn652560)
-   [**Flash**](https://msdn.microsoft.com/library/windows/apps/dn652566)
-   [**Focus**](https://msdn.microsoft.com/library/windows/apps/dn652570)
-   [**IsoSpeed**](https://msdn.microsoft.com/library/windows/apps/dn652574)
-   [**PhotoConfirmation**](https://msdn.microsoft.com/library/windows/apps/dn652578)

この例では、フレームごとに異なる露出補正の値を設定します。 現在のデバイスの写真シーケンスで露出補正がサポートされているかどうかを確認するには、**ExposureCompensation** プロパティからアクセスできる [**FrameExposureCompensationCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652628) オブジェクトの [**Supported**](https://msdn.microsoft.com/library/windows/apps/dn278905) プロパティを調べます。

[!code-cs[IsExposureCompensationSupported](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetIsExposureCompensationSupported)]

キャプチャする各フレームに対して新しい [**FrameController**](https://msdn.microsoft.com/library/windows/apps/dn652582) オブジェクトを作成します。 この例では、3 つのフレームをキャプチャします。 フレームごとに変更するコントロールの値を設定します。 次に、**VariablePhotoSequenceController** の [**DesiredFrameControllers**](https://msdn.microsoft.com/library/windows/apps/dn640574) コレクションをクリアし、コレクションに各フレーム コントローラーを追加します。

[!code-cs[InitFrameControllers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetInitFrameControllers)]

キャプチャした画像に対して使用するエンコードを設定するための [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) オブジェクトを作成します。 静的メソッド [**MediaCapture.PrepareVariablePhotoSequenceCaptureAsync**](https://msdn.microsoft.com/library/windows/apps/dn608097) を呼び出し、エンコード プロパティを渡します。 このメソッドは、[**VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) オブジェクトを返します。 最後に、[**PhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/dn652573) イベントと [**Stopped**](https://msdn.microsoft.com/library/windows/apps/dn652585) イベントのイベント ハンドラーを登録します。

[!code-cs[PrepareVPS](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPrepareVPS)]

## <a name="start-the-variable-photo-sequence-capture"></a>可変の写真シーケンス キャプチャを開始する

可変の写真シーケンスのキャプチャを開始するには、[**VariablePhotoSequenceCapture.StartAsync**](https://msdn.microsoft.com/library/windows/apps/dn652577) を呼び出します。 必ず、キャプチャした画像とフレーム コントロールの値を格納するための配列を初期化し、現在のインデックスを 0 に設定してください。 アプリの記録状態の変数を設定し、このキャプチャの進行中は別のキャプチャを開始できないように UI を更新します。

[!code-cs[StartVPSCapture](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStartVPSCapture)]

## <a name="receive-the-captured-frames"></a>キャプチャされたフレームを受け取る

[**PhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/dn652573) イベントは、キャプチャされたフレームごとに発生します。 フレーム コントロールの値とフレームのキャプチャされた画像を保存してから、現在のフレームのインデックスを増分します。 次の例は、各フレームの [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) 表現を取得する方法を示しています。 **SoftwareBitmap** の使用方法について詳しくは、「[イメージング](imaging.md)」をご覧ください。

[!code-cs[OnPhotoCaptured](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnPhotoCaptured)]

## <a name="handle-the-completion-of-the-variable-photo-sequence-capture"></a>可変の写真シーケンスのキャプチャの完了を処理する

[**Stopped**](https://msdn.microsoft.com/library/windows/apps/dn652585) イベントは、シーケンス内のすべてのフレームがキャプチャされると発生します。 アプリの記録状態を更新し、ユーザーが新しいキャプチャを開始できるように UI を更新します。 この時点で、キャプチャされた画像とフレーム コントロールの値を画像処理コードに渡すことができます。

[!code-cs[OnStopped](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnStopped)]

## <a name="update-frame-controllers"></a>フレーム コントローラーを更新する

フレームごとの設定を変更して、可変の写真シーケンス キャプチャを新たに実行する場合、**VariablePhotoSequenceCapture** を完全に再初期化する必要はありません。 [**DesiredFrameControllers**](https://msdn.microsoft.com/library/windows/apps/dn640574) コレクションをクリアして新しいフレーム コントローラーを追加するか、または既存のフレーム コントローラーの値を変更できます。 次の例では、[**FrameFlashCapabilities**](https://msdn.microsoft.com/library/windows/apps/dn652657) オブジェクトを調べて、現在のデバイスが可変の写真シーケンス フレームに対してフラッシュとフラッシュの電源をサポートしているかどうかを確認します。 サポートしている場合は、100% の電力でフラッシュを有効にするよう各フレームが更新されます。 各フレームに対して前の手順で設定した露出補正の値は、引き続き有効です。

[!code-cs[UpdateFrameControllers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUpdateFrameControllers)]

## <a name="clean-up-the-variable-photo-sequence-capture"></a>可変の写真シーケンス キャプチャをクリーンアップする

可変の写真シーケンスのキャプチャが完了するか、アプリが中断された場合は、[**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/dn652569) を呼び出して、可変の写真シーケンスのオブジェクトをクリーンアップします。 オブジェクトのイベント ハンドラーの登録を解除し、null に設定します。

[!code-cs[CleanUpVPS](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpVPS)]

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 




