---
author: drewbatgit
ms.assetid: 05E418B4-5A62-42BD-BF66-A0762216D033
description: このトピックでは、メディア キャプチャのプレビュー ストリームから単一のプレビュー フレームを取得する方法について説明します。
title: プレビュー フレームの取得
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 211bd4ce660726030f8b90d29c4ea4d8a14564de
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6034092"
---
# <a name="get-a-preview-frame"></a>プレビュー フレームの取得


このトピックでは、メディア キャプチャのプレビュー ストリームから単一のプレビュー フレームを取得する方法について説明します。

> [!NOTE] 
> この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され適切に初期化されていることと、アクティブなビデオ プレビュー ストリームを含んだ [**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) が存在することを前提としています。

プレビュー フレームをキャプチャするためには、基本的なメディア キャプチャに必要な名前空間に加え、次の名前空間が必要となります。

[!code-cs[PreviewFrameUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPreviewFrameUsing)]

プレビュー フレームを要求するとき、フレームの受信に使う形式を指定するには、必要な形式を指定して [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) オブジェクトを作成します。 この例では、[**VideoDeviceController.GetMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211995) の呼び出しで [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) を指定し、プレビュー ストリームのプロパティを要求することで、プレビュー ストリームと同じ解像度でビデオ フレームを作成します。 プレビュー ストリームの幅と高さを使って新しいビデオ フレームを作成しています。

[!code-cs[CreateFormatFrame](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCreateFormatFrame)]

[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) オブジェクトが初期化されていてアクティブなプレビュー ストリームが存在する場合、[**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926711) を呼び出してプレビュー ストリームを取得します。 引数には、最後のステップで作成したビデオ フレームを渡し、取得するフレームの形式を指定します。

[!code-cs[GetPreviewFrameAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPreviewFrameAsync)]

プレビュー フレームの [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) 表現は、[**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) オブジェクトの [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) プロパティにアクセスして取得します。 ソフトウェア ビットマップの保存、読み込み、変更については、「[イメージング](imaging.md)」を参照してください。

[!code-cs[GetPreviewBitmap](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPreviewBitmap)]

Direct3D API で画像を扱う場合は、プレビュー フレームの [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) 表現を取得することもできます。

[!code-cs[GetPreviewSurface](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetPreviewSurface)]

> [!IMPORTANT]
> **GetPreviewFrameAsync** の呼び出し方法と、アプリが実行されているデバイスによっては、返される **VideoFrame** の [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) プロパティまたは [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn930920) プロパティのどちらかが null になることがあります。

> - **VideoFrame** 引数を受け入れる [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926713) のオーバーロードを呼び出した場合、返される **VideoFrame** の **SoftwareBitmap** は null 以外になり、**Direct3DSurface** プロパティは null になります。
> - Direct3D サーフェスを使ってフレームを内部で表すデバイスで引数のない [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926712) のオーバーロードを呼び出した場合、**Direct3DSurface** プロパティは null 以外になり、**SoftwareBitmap** プロパティは null になります。
> - Direct3D サーフェスを使ってフレームを内部で表すデバイスで引数のない [**GetPreviewFrameAsync**](https://msdn.microsoft.com/library/windows/apps/dn926712) のオーバーロードを呼び出した場合、**SoftwareBitmap** プロパティは null 以外になり、**Direct3DSurface** プロパティは null になります。

アプリは、**SoftwareBitmap** プロパティまたは **Direct3DSurface** プロパティによって返されるオブジェクトで動作を試みる前に、必ず null 値をチェックする必要があります。

プレビュー フレームが不要になったら必ず、その [**Close**](https://msdn.microsoft.com/library/windows/apps/dn930918) メソッド (C# 内で Dispose に投影される) を呼び出して、フレームによって使われているリソースを解放してください。 または、**using** パターンを使ってもかまいません。その場合は、オブジェクトが自動的に破棄されます。

[!code-cs[CleanUpPreviewFrame](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpPreviewFrame)]

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 




