---
author: drewbatgit
ms.assetid: A1A0D99A-DCBF-4A14-80B9-7106BEF045EC
description: Windows.Media.Transcoding API を使って、ビデオ ファイルをある形式から別の形式にコード変換できます。
title: メディア ファイルのコード変換
---

# メディア ファイルのコード変換

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


[
            **Windows.Media.Transcoding**](https://msdn.microsoft.com/library/windows/apps/br207105) API を使って、ビデオ ファイルをある形式から別の形式にコード変換できます。

*コード変換*とは、デジタル メディア ファイル (ビデオ ファイルやオーディオ ファイル) の形式を別の形式に変換することです。 通常は、ファイルをデコードしてエンコードし直すことで行います。 たとえば、MP4 形式をサポートするポータブル デバイスで再生できるように、Windows Media ファイルを MP4 に変換できます。 また、高解像度のビデオ ファイルの解像度を下げることもできます。 この場合、再エンコードしたファイルは元のファイルと同じコーデックを使うことがありますが、エンコード プロファイルは異なります。

## プロジェクトをコード変換用にセットアップする

この記事のコードを使ってメディア ファイルのコード変換を行うには、既定のプロジェクト テンプレートによって参照される名前空間に加えて、これらの名前空間を参照する必要があります。

[!code-cs[Using](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetUsing)]

## 変換元ファイルと変換先ファイルを選択する

アプリでコード変換の変換元ファイルと変換先ファイルを判別する方法は、実装によって異なります。 この例では、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) と [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、ユーザーが変換元ファイルと変換先ファイルを選べるようにします。

[!code-cs[TranscodeGetFile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeGetFile)]

## メディア エンコード プロファイルを作成する

エンコード プロファイルには、変換先ファイルのエンコード方法を決めるための設定が含まれています。 ファイルをコード変換するときのオプションが最も多いのは、このエンコード プロファイルです。

[
            **MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) クラスには、あらかじめ定義されたエンコード プロファイルを作るための静的メソッドが用意されています。

-   Wav
-   AAC オーディオ (M4A)
-   MP3 オーディオ
-   Windows Media Audio (WMA)
-   Avi
-   MP4 ビデオ (H.264 ビデオと AAC オーディオ)
-   Windows Media Video (WMV)

このリストで最初の 4 つのプロファイルには、オーディオのみが含まれます。 残りの 3 つには、ビデオとオーディオが含まれています。

次のコードでは、MP4 ビデオ用のプロファイルが作成されます。

[!code-cs[TranscodeMediaProfile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeMediaProfile)]

静的 [**CreateMp4**](https://msdn.microsoft.com/library/windows/apps/hh701078) メソッドは、MP4 エンコード プロファイルを作ります。 このメソッドのパラメーターで、ビデオのターゲット解像度を指定します。 この場合の [**VideoEncodingQuality.hd720p**](https://msdn.microsoft.com/library/windows/apps/hh701290) は、1280 x 720 ピクセルで 1 秒あたり 30 フレームであることを意味します ("720p" は、プログレッシブ スキャン方式で 1 フレームあたり 720 本を処理することを表します)。あらかじめ定義されたプロファイルを作るその他のメソッドは、すべてこのパターンに従います。

別の方法として、[**MediaEncodingProfile.CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh701047) メソッドを使って現在のメディア ファイルに一致するプロファイルを作成することもできます。 または、必要なエンコード設定が正確にわかれば、新しい [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) オブジェクトを作成してプロファイルの詳細を入力できます。

## ファイルのコード変換を行う

ファイルのコード変換を行うには、新しい [**MediaTranscoder**](https://msdn.microsoft.com/library/windows/apps/br207080) オブジェクトを作成し、[**MediaTranscoder.PrepareFileTranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700936) メソッドを呼び出します。 ソース ファイル、出力先ファイル、エンコード プロファイルを渡します。 次に、非同期コード変換操作から返された [**PrepareTranscodeResult**](https://msdn.microsoft.com/library/windows/apps/hh700941) オブジェクト上の [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) メソッドを呼び出します。

[!code-cs[TranscodeTranscodeFile](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeTranscodeFile)]

## コード変換の進行状況に対して応答する

非同期の [**TranscodeAsync**](https://msdn.microsoft.com/library/windows/apps/hh700946) の進行状況が変化したときに応答するイベントを登録できます。 これらのイベントは、ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミング フレームワークの一部であり、コード変換 API に固有のものではありません。

[!code-cs[TranscodeCallbacks](./code/TranscodeWin10/cs/MainPage.xaml.cs#SnippetTranscodeCallbacks)]

 

 






<!--HONumber=May16_HO2-->


