---
author: drewbatgit
ms.assetid: A1A0D99A-DCBF-4A14-80B9-7106BEF045EC
description: Windows.Media.Transcoding API を使うと、ビデオ ファイルをある形式から別の形式にトランスコードできます。
title: メディア ファイルのトランスコード
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: babf91e681004942bb3b66eb43622742fa183125
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5930144"
---
# <a name="transcode-media-files"></a>メディア ファイルのトランスコード



[**Windows.Media.Transcoding**](https://msdn.microsoft.com/library/windows/apps/br207105) API を使って、ビデオ ファイルをある形式から別の形式にコード変換できます。

*コード変換*とは、デジタル メディア ファイル (ビデオ ファイルやオーディオ ファイル) の形式を別の形式に変換することです。 通常は、ファイルをデコードしてエンコードし直すことで行います。 たとえば、MP4 形式をサポートするポータブル デバイスで再生できるように、Windows Media ファイルを MP4 に変換できます。 また、高解像度のビデオ ファイルの解像度を下げることもできます。 この場合、再エンコードしたファイルは元のファイルと同じコーデックを使うことがありますが、エンコード プロファイルは異なります。

## <a name="set-up-your-project-for-transcoding"></a>プロジェクトをコード変換用にセットアップする

この記事のコードを使ってメディア ファイルのコード変換を行うには、既定のプロジェクト テンプレートによって参照される名前空間に加えて、これらの名前空間を参照する必要があります。

[!code-cs[Using](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetUsing)]

## <a name="select-source-and-destination-files"></a>変換元ファイルと変換先ファイルを選択する

アプリでコード変換の変換元ファイルと変換先ファイルを判別する方法は、実装によって異なります。 この例では、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) と [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、ユーザーが変換元ファイルと変換先ファイルを選べるようにします。

[!code-cs[TranscodeGetFile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeGetFile)]

## <a name="create-a-media-encoding-profile"></a>メディア エンコード プロファイルを作成する

エンコード プロファイルには、変換先ファイルのエンコード方法を決めるための設定が含まれています。 ファイルをコード変換するときのオプションが最も多いのは、このエンコード プロファイルです。

[**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) クラスには、あらかじめ定義されたエンコード プロファイルを作るための静的メソッドが用意されています。

### <a name="methods-for-creating-audio-only-encoding-profiles"></a>オーディオ専用のエンコード プロファイルを作成するメソッド

メソッド  |プロファイル  |
---------|---------|
[**CreateAlac**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createalac)     |Apple Lossless Audio Codec (ALAC) オーディオ         |
[**CreateFlac**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createflac)     |Free Lossless Audio Codec (FLAC) オーディオ         |
[**CreateM4a**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createm4a)     |AAC オーディオ (M4A)         |
[**CreateMp3**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp3)     |MP3 オーディオ         |
[**CreateWav**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createwav)     |WAV オーディオ         |
[**CreateWmv**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createwmv)     |Windows Media Audio (WMA)         |

### <a name="methods-for-creating-audio--video-encoding-profiles"></a>オーディオ/ビデオのエンコード プロファイルを作成するメソッド

メソッド  |プロファイル  |
---------|---------|
[**CreateAvi**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createavi) |AVI |
[**CreateHevc**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createhevc) |High Efficiency Video Coding (HEVC) ビデオ、H.265 ビデオとも呼ばれます |
[**CreateMp4**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp4) |MP4 ビデオ (H.264 ビデオと AAC オーディオ) |
[**CreateWmv**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createwmv) |Windows Media Video (WMV) |


次のコードでは、MP4 ビデオ用のプロファイルが作成されます。

[!code-cs[TranscodeMediaProfile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeMediaProfile)]

静的 [**CreateMp4**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp4) メソッドは、MP4 エンコード プロファイルを作ります。 このメソッドのパラメーターで、ビデオのターゲット解像度を指定します。 この場合の [**VideoEncodingQuality.hd720p**](https://msdn.microsoft.com/library/windows/apps/hh701290) は、1280 x 720 ピクセルで 1 秒あたり 30 フレームであることを意味します  ("720p" は、プログレッシブ スキャン方式で 1 フレームあたり 720 本を処理することを表します)。あらかじめ定義されたプロファイルを作るその他のメソッドは、すべてこのパターンに従います。

別の方法として、[**MediaEncodingProfile.CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh701047) メソッドを使って現在のメディア ファイルに一致するプロファイルを作成することもできます。 または、必要なエンコード設定が正確にわかれば、新しい [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) オブジェクトを作成してプロファイルの詳細を入力できます。

## <a name="transcode-the-file"></a>ファイルのコード変換を行う

ファイルのコード変換を行うには、新しい [**MediaTranscoder**](https://msdn.microsoft.com/library/windows/apps/br207080) オブジェクトを作成し、[**MediaTranscoder.PrepareFileTranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700936) メソッドを呼び出します。 ソース ファイル、出力先ファイル、エンコード プロファイルを渡します。 次に、非同期コード変換操作から返された [**PrepareTranscodeResult**](https://msdn.microsoft.com/library/windows/apps/hh700941) オブジェクト上の [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) メソッドを呼び出します。

[!code-cs[TranscodeTranscodeFile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeTranscodeFile)]

## <a name="respond-to-transcoding-progress"></a>コード変換の進行状況に対して応答する

非同期の [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) の進行状況が変化したときに応答するイベントを登録できます。 これらのイベントは、ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミング フレームワークの一部であり、コード変換 API に固有のものではありません。

[!code-cs[TranscodeCallbacks](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeCallbacks)]


## <a name="encode-a-metadata-stream"></a>メタデータ ストリームをエンコードする
Windows 10、バージョン 1803 以降でタイミングが設定されたメタデータを含めることができますとメディア ファイルのコード変換します。 上記のビデオ トランス コード例とは異なり組み込みのメディア エンコード プロファイルの作成方法、 [**MediaEncodingProfile.CreateMp4**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile.createmp4)などを使用する必要があります手動で作成するメタデータのエンコード プロファイルをエンコードするメタデータの種類をサポートするには.

このメタデータ incoding プロファイルを作成するのには、まずトランス コードするメタデータのエンコード方法を説明する [**TimedMetadataEncodingProperties**] のオブジェクトを作成します。 サブタイプのプロパティは、メタデータの種類を指定する GUID です。 各メタデータの種類のエンコードの詳細は、専用が Windows によって指定されていません。 この例では、GoPro メタデータ (gprs) の GUID が使用されます。 次に、 [**SetFormatUserData**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.timedmetadataencodingproperties.setformatuserdata)は、メタデータの形式に固有のストリーム形式を記述するデータのバイナリ blob を設定すると呼ばれます。 次に、 **TimedMetadataStreamDescriptor**(https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatastreamdescriptor)エンコードのプロパティから作成される、トラックのラベルと名前が、アプリケーション、メタデータ ストリームを識別し、必要に応じて UI にストリーム名を表示する endcoded ストリームの読み取りできるようにします。 
 
[!code-cs[GetStreamDescriptor](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetGetStreamDescriptor)]

**TimedMetadataStreamDescriptor**を作成した後は、ビデオ、オーディオ、およびファイルにエンコードするメタデータを説明する**MediaEncodingProfile**を作成できます。 最後の例で作成した**TimedMetadataStreamDescriptor**では、この例のヘルパー関数に渡されたされ、 [**SetTimedMetadataTracks**](https://docs.microsoft.com/en-us/uwp/api/windows.media.mediaproperties.mediaencodingprofile.settimedmetadatatracks)を呼び出すことによって**MediaEncodingProfile**に追加されます。

[!code-cs[GetMediaEncodingProfile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetGetMediaEncodingProfile)]
 

 




