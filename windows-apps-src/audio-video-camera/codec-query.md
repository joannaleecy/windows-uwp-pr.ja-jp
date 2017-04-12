---
author: drewbatgit
ms.assetid: 0A360481-B649-4E90-9BC4-4449BA7445EF
description: "デバイスにインストールされているオーディオとビデオのエンコーダーとデコーダーを照会します。"
title: "インストールされているコーデックの照会"
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, コーデック, エンコーダー, デコーダー, クエリ"
ms.openlocfilehash: 1bde2c24db6faa843d9118f330867e7f66b22e7e
ms.sourcegitcommit: 64cfb79fd27b09d49df99e8c9c46792c884593a7
translationtype: HT
---
# <a name="query-for-installed-codecs"></a>インストールされているコーデックの照会
この記事では、デバイスにインストールされているオーディオとビデオのエンコーダーとデコーダーを照会する方法を示します。 OS に含まれている、各デバイス ファミリのコーデックの一覧については、「[サポートされるコーデック](supported-codecs.md)」を参照してください。 個々のデバイスで、ユーザーまたはアプリが追加のコーデックをインストールする場合があります。 [CodecQuery](https://docs.microsoft.com/en-us/uwp/api/windows.media.core.codecquery) クラスを使用して、アプリが実行されているデバイスに現在インストールされているエンコーダーとデコーダーのセットの一覧を取得できます。

**CodecQuery** クラスは、[windows.media.core](https://docs.microsoft.com/en-us/uwp/api/windows.media.core) 名前空間に含まれており、引数を必要としないコンストラクターを提供します。

[!code-cs[CodecQueryUsing](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetCodecQueryUsing)]

[!code-cs[NewCodecQuery](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetNewCodecQuery)]

**CodecQuery** クラスの [FindAllAsync](https://docs.microsoft.com/en-us/uwp/api/windows.media.core.codecquery#Windows_Media_Core_CodecQuery_FindAllAsync_Windows_Media_Core_CodecKind_Windows_Media_Core_CodecCategory_System_String_) メソッドは、インストールされているコーデックのうち、指定されたパラメーターを満たすものをすべて返します。 これらのパラメーターには、オーディオ コーデックとビデオ コーデックのどちらを返すかを指定する [CodecKind](https://docs.microsoft.com/en-us/uwp/api/windows.media.core.codeckind) 列挙体の値や、コーデックのカテゴリを指定する [CodecCategory](https://docs.microsoft.com/en-us/uwp/api/windows.media.core.codeccategory) 値が含まれます。

最後のパラメーターは、H264 ビデオや FLAC オーディオなどのメディア サブタイプを表す文字列で、**FindAllAsync** から返されたコーデックでサポートされている必要があります。 すべてのメディア サブタイプのコーデックを返すには、このパラメーターに null または空の文字列を指定します。 次の例では、現在のデバイスにインストールされているすべてのビデオ エンコーダーの一覧が取得されます。

[!code-cs[FindAllEncoders](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetFindAllEncoders)]

メディア サブタイプを指定する場合は、「[オーディオ サブタイプの GUID](https://msdn.microsoft.com/library/windows/desktop/aa372553(v=vs.85).aspx)」または「[ビデオ サブタイプの GUID](https://msdn.microsoft.com/library/windows/desktop/aa370819(v=vs.85).aspx)」に示されているサブタイプ GUID のいずれかの文字列表現を使用する必要があります [CodecSubtypes](https://docs.microsoft.com/en-us/uwp/api/windows.media.core.codecsubtypes) クラスには、サブタイプ GUID の文字列表現を返す、サポートされているほとんどのメディア サブタイプのプロパティが用意されています。 メディア サブタイプ パラメーターとして、FOURCC コードを指定することもできます。 詳しくは、「[FOURCCコード](https://msdn.microsoft.com/library/windows/desktop/dd375802(v=vs.85).aspx)」を参照してください。 

次の例では、FOURCC コードを使用して、H.264 ビデオをサポートするビデオ デコーダーを照会します。 この操作のシナリオ例では、ビデオ ファイルを再生しようとする前に、ビデオ形式がサポートされているかどうかを確認します。

[!code-cs[IsH264Supported](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetIsH264Supported)]

次の例では、FLAC メディア サブタイプをサポートするオーディオ エンコーダーを照会します。 この例では、AudioEncodingProperties オブジェクトと、サブタイプとして MediaEncodingProfile を作成しています。 これを使用することで、指定された形式でオーディオを録音したり、別の形式からオーディオをトランスコードしたりすることができます。 詳しくは、「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」と「[メディア ファイルのトランスコード](transcode-media-files.md)」を参照してください。

[!code-cs[IsFLACSupported](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetIsFLACSupported)]

## <a name="related-topics"></a>関連トピック

* [サポートされるコーデック](supported-codecs.md)
* [MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [メディア ファイルのトランスコード](transcode-media-files.md)
 

 




