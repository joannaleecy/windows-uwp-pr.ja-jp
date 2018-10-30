---
author: drewbatgit
ms.assetid: 0A360481-B649-4E90-9BC4-4449BA7445EF
description: デバイスにインストールされているオーディオとビデオのエンコーダーとデコーダーを照会します。
title: インストールされているコーデックの照会
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, コーデック, エンコーダー, デコーダー, クエリ
ms.localizationpriority: medium
ms.openlocfilehash: b74ac269bcba6d15e7c4f5dcb4c34d53573deb5e
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5753713"
---
# <a name="query-for-codecs-installed-on-a-device"></a>デバイスにインストールされているコーデックの照会
**[CodecQuery](https://docs.microsoft.com/uwp/api/windows.media.core.codecquery)** クラスによって、現在のデバイスにインストールされているコーデックを照会できます。 Windows 10 に含まれているさまざまなデバイス ファミリのコーデックの一覧については、「[サポートされるコーデック](supported-codecs.md)」の記事に示されています。ただし、ユーザーやアプリはデバイスに追加のコーデックをインストールできるため、現在のデバイスでどのようなコーデックが利用可能かを特定するために、実行時にコーデックのサポートを照会することができます。

CodecQuery API は、**[Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)** 名前空間のメンバーであるため、この名前空間をアプリに含める必要があります。

CodecQuery API は、**[Windows.Media.Core](https://docs.microsoft.com/uwp/api/windows.media.core)** 名前空間のメンバーであるため、この名前空間をアプリに含める必要があります。

[!code-cs[CodecQueryUsing](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetCodecQueryUsing)]

コンストラクターを呼び出すことによって、**CodecQuery** クラスの新しいインスタンスを初期化します。

[!code-cs[NewCodecQuery](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetNewCodecQuery)]

**[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.media.core.codecquery.findallasync)** メソッドは、指定されたパラメーターに一致するインストール済みのすべてのコーデックを返します。 これらのパラメーターには、オーディオ、ビデオ、またはその両方のどれを照会するかを指定する **[CodecKind](https://docs.microsoft.com/uwp/api/windows.media.core.codeckind)** 値、エンコーダーとデコーダーのどちらを照会するかを指定する **[CodecCategory](https://docs.microsoft.com/uwp/api/windows.media.core.codeccategory)** 値、照会するメディア エンコード サブタイプを表す文字列 (H.264 ビデオや MP3 オーディオなど) が含まれます。

すべてサブタイプのコーデックを返すには、サブタイプ値として空の文字列または null を指定します。 次の例では、デバイスにインストールされているすべてのビデオ エンコーダーの一覧が取得されます。

[!code-cs[FindAllEncoders](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetFindAllEncoders)]

**FindAllAsync** に渡すサブタイプ文字列には、システムで定義されているサブタイプ GUID の文字列表現またはサブタイプの FOURCC コードを指定できます。 一連のサポートされるメディア サブタイプの GUID は、「[オーディオ サブタイプの GUID](https://msdn.microsoft.com/library/windows/desktop/aa372553(v=vs.85).aspx)」と「[ビデオ サブタイプの GUID](https://msdn.microsoft.com/library/windows/desktop/aa370819(v=vs.85).aspx)」の記事に示されていますが、**[CodecSubtypes](https://docs.microsoft.com/uwp/api/windows.media.core.codecsubtypes)** クラスには、サポートされている各サブタイプの GUID 値を返すプロパティが用意されています。 FOURCC コードの詳細については、[FOURCC コードに関する記事](https://msdn.microsoft.com/library/windows/desktop/dd375802(v=vs.85).aspx)をご覧ください。 

次の例では、デバイスに H.264 ビデオ デコーダーがインストールされているかどうかを確認するために、FOURCC コード "H264" を指定しています。 H.264 ビデオ コンテンツを再生する前に、このクエリを実行できます。 また、再生時にサポートされていないコーデックを処理することもできます。 詳しくは、「[メディア項目を開く際にサポートされていないコーデックと不明なエラーを処理する](https://docs.microsoft.com/windows/uwp/audio-video-camera/media-playback-with-mediasource#handle-unsupported-codecs-and-unknown-errors-when-opening-media-items)」をご覧ください。

[!code-cs[IsH264Supported](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetIsH264Supported)]

次の例では、現在のデバイスに FLAC オーディオ エンコーダーがインストールされているかどうかを照会して確認し、インストールされている場合は、オーディオをファイルにキャプチャしたり、オーディオを別の形式から FLAC オーディオ ファイルにトランスコードしたりするために使用できる **[MediaEncodingProfile](https://docs.microsoft.com/uwp/api/Windows.Media.MediaProperties.MediaEncodingProfile)** がこのサブタイプ用に作成されます。

[!code-cs[IsFLACSupported](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetIsFLACSupported)]

## <a name="related-topics"></a>関連トピック

* [メディア再生](media-playback.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [メディア ファイルのトランスコード](transcode-media-files.md)
* [サポートされているコーデック](supported-codecs.md)
 

 




