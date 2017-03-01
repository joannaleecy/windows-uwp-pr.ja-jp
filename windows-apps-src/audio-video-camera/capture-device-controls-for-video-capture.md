---
author: drewbatgit
ms.assetid: 708170E1-777A-4E4A-9F77-5AB28B88B107
description: "この記事では、ビデオ キャプチャの拡張シナリオ (HDR ビデオ、露出の優先順位など) を手動デバイス制御によって有効にする方法を示します。"
title: "ビデオ キャプチャのための手動カメラ制御"
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: cd6326ebad94c33fd03bf39f2dfd11f1c27e9b37
ms.lasthandoff: 02/07/2017

---

# <a name="manual-camera-controls-for-video-capture"></a>ビデオ キャプチャのための手動カメラ制御

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


この記事では、ビデオ キャプチャの拡張シナリオ (HDR ビデオ、露出の優先順位など) を手動デバイス制御によって有効にする方法を示します。

この記事で説明するビデオ デバイス コントロールはすべて同じパターンを使ってアプリに追加されます。 まず、アプリが実行されている現在のデバイスで、コントロールがサポートされているかどうかを確認します。 コントロールがサポートされている場合は、コントロールに対して必要なモードを設定します。 一般的に、現在のデバイスで特定のコントロールがサポートされていない場合は、ユーザーがその機能を有効にできるような UI 要素を無効または非表示にする必要があります。

この記事で説明するデバイス制御 API はすべて、[**Windows.Media.Devices**](https://msdn.microsoft.com/library/windows/apps/br206902) 名前空間のメンバーです。

[!code-cs[VideoControllersUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetVideoControllersUsing)]

> [!NOTE] 
> この記事の内容は、写真やビデオの基本的なキャプチャ機能を実装するための手順を紹介した「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」で取り上げた概念やコードに基づいています。 そちらの記事で基本的なメディア キャプチャのパターンを把握してから、高度なキャプチャ シナリオに進むことをお勧めします。 この記事で紹介しているコードは、MediaCapture のインスタンスが既に作成され、適切に初期化されていることを前提としています。

## <a name="hdr-video"></a>HDR ビデオ

ハイ ダイナミック レンジ (HDR) ビデオ機能では、HDR 処理をキャプチャ デバイスのビデオ ストリームに適用します。 HDR ビデオがサポートされているかどうかを確認するには、[**HdrVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926682) プロパティを選びます。

HDR ビデオ コントロールでは、3 つのモード (オン、オフ、自動) がサポートされています。自動モードでは、HDR ビデオ処理によってメディア キャプチャが改善されるかどうかをデバイスが動的に判断し、改善される場合は HDR ビデオが有効になります。 現在のデバイスで特定のモードがサポートされているかどうかを確認するには、[**HdrVideoControl.SupportedModes**](https://msdn.microsoft.com/library/windows/apps/dn926683) コレクションに目的のモードが含まれているかどうかをチェックします。

HDR ビデオ処理を有効または無効にするには、[**HdrVideoControl.Mode**](https://msdn.microsoft.com/library/windows/apps/dn926681) を目的のモードに設定します。

[!code-cs[SetHdrVideoMode](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetHdrVideoMode)]

## <a name="exposure-priority"></a>露出の優先順位

[**ExposurePriorityVideoControl**](https://msdn.microsoft.com/library/windows/apps/dn926644) は、有効であれば、キャプチャ デバイスからのビデオ フレームを評価し、ローライト シーンのビデオがキャプチャされているかどうかを判断します。 その場合は、各フレームの露出時間を長くし、キャプチャしたビデオの画質を向上するために、キャプチャするビデオのフレーム レートが引き下げられます。

[**ExposurePriorityVideoControl.Supported**](https://msdn.microsoft.com/library/windows/apps/dn926647) プロパティをチェックして、現在のデバイスで露出の優先順位コントロールがサポートされているかどうかを確認してください。

露出の優先順位コントロールを有効または無効にするには、[**ExposurePriorityVideoControl.Enabled**](https://msdn.microsoft.com/library/windows/apps/dn926646) を目的のモードに設定します。

[!code-cs[EnableExposurePriority](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetEnableExposurePriority)]

## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
 

 





