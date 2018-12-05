---
ms.assetid: 3FD2AA71-EF67-47B2-9332-3FFA5D3703EA
description: この記事では、BitmapDecoder と BitmapEncoder を使って画像ファイルを読み込んだり保存したりする方法のほか、SoftwareBitmap オブジェクトを使ってビットマップ画像を表現する方法について説明します。
title: ビットマップ画像の作成、編集、保存
ms.date: 03/22/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8c7959231596829e20dc8afea654b2d51977abe4
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8736960"
---
# <a name="create-edit-and-save-bitmap-images"></a>ビットマップ画像の作成、編集、保存



この記事では、[**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) と [**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/br226206) を使って画像ファイルを読み込んだり保存したりする方法のほか、[**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトを使ってビットマップ画像を表現する方法について説明します。

**SoftwareBitmap** クラスは、さまざまなソースから作成できる多用途の API です。画像ファイルや [**WriteableBitmap**](https://msdn.microsoft.com/library/windows/apps/br243259) オブジェクト、Direct3D サーフェスから作成できるほか、コードから作成することもできます。 **SoftwareBitmap** を使うと、異なるピクセル形式間やアルファ モード間の変換、ピクセル データへの低レベル アクセスを簡単に行うことができます。 Windows のさまざまな機能のインターフェイスとしても、**SoftwareBitmap** は広く使われています。その例を以下に挙げます。

-   [**CapturedFrame**](https://msdn.microsoft.com/library/windows/apps/dn278725) では、カメラによってキャプチャされたフレームを **SoftwareBitmap** として取得できます。

-   [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) では、**VideoFrame** の **SoftwareBitmap** 表現を取得することができます。

-   [**FaceDetector**](https://msdn.microsoft.com/library/windows/apps/dn974129) では、**SoftwareBitmap** のフェイスを検出することができます。

この記事のサンプル コードには、以下の名前空間の API が使われています。

[!code-cs[Namespaces](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetNamespaces)]

## <a name="create-a-softwarebitmap-from-an-image-file-with-bitmapdecoder"></a>BitmapDecoder で画像ファイルから SoftwareBitmap を作成する

[**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) をファイルから作成するには、画像データを含んだ [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) のインスタンスを取得します。 この例では、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使用して、ユーザーが画像ファイルを選択できるピッカーを表示しています。

[!code-cs[PickInputFile](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetPickInputFile)]

**StorageFile** オブジェクトの [**OpenAsync**](https://msdn.microsoft.com/library/windows/apps/br227116) メソッドを呼び出して、画像データを含んだランダム アクセス ストリームを取得します。 静的メソッド [**BitmapDecoder.CreateAsync**](https://msdn.microsoft.com/library/windows/apps/br226182) を呼び出して、指定したストリームの [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) クラスのインスタンスを取得します。 [**GetSoftwareBitmapAsync**](https://msdn.microsoft.com/library/windows/apps/dn887332) を呼び出して、画像が格納されている [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトを取得します。

[!code-cs[CreateSoftwareBitmapFromFile](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetCreateSoftwareBitmapFromFile)]

## <a name="save-a-softwarebitmap-to-a-file-with-bitmapencoder"></a>BitmapEncoder で SoftwareBitmap をファイルに保存する

**SoftwareBitmap** をファイルに保存するには、画像の保存先となる **StorageFile** のインスタンスを取得します。 この例では、[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、ユーザーが出力ファイルを選択できるピッカーを表示しています。

[!code-cs[PickOuputFile](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetPickOuputFile)]

**StorageFile** オブジェクトの [**OpenAsync**](https://msdn.microsoft.com/library/windows/apps/br227116) メソッドを呼び出して、画像の書き込み先となるランダム アクセス ストリームを取得します。 静的メソッド [**BitmapEncoder.CreateAsync**](https://msdn.microsoft.com/library/windows/apps/br226211) を呼び出して、指定したストリームの [**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/br226206) クラスのインスタンスを取得します。 **CreateAsync** の第 1 パラメーターは、画像のエンコードに使うコーデックの GUID です。 エンコーダーがサポートしている各コーデックについて、この ID を保持するプロパティが、**BitmapEncoder** クラスによって公開されています ([**JpegEncoderId**](https://msdn.microsoft.com/library/windows/apps/br226226) など)。

エンコードの対象となる画像は、[**SetSoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887337) メソッドを使って設定します。 [**BitmapTransform**](https://msdn.microsoft.com/library/windows/apps/br226254) プロパティの値を設定することで、画像のエンコード中に基本的な変換を適用することができます。 エンコーダーで縮小表示が生成されるかどうかは、[**IsThumbnailGenerated**](https://msdn.microsoft.com/library/windows/apps/br226225) プロパティによって決まります。 ファイル形式によっては縮小表示がサポートされない場合があるので注意してください。この機能を使う場合、縮小表示がサポートされない場合にスローされるエラー (サポート外操作エラー) をキャッチする必要があります。

[**FlushAsync**](https://msdn.microsoft.com/library/windows/apps/br226216) を呼び出すと、指定されたファイルへの画像データの書き込みをエンコーダーが開始します。

[!code-cs[SaveSoftwareBitmapToFile](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetSaveSoftwareBitmapToFile)]

その他のエンコード オプションは、**BitmapEncoder** を作成するときに、新しい [**BitmapPropertySet**](https://msdn.microsoft.com/library/windows/apps/hh974338) オブジェクトを作成し、そこにエンコーダーの設定を表す [**BitmapTypedValue**](https://msdn.microsoft.com/library/windows/apps/hh700687) オブジェクトを渡すことによって指定できます。 サポートされているエンコーダー オプションの一覧については、「[BitmapEncoder オプション リファレンス](bitmapencoder-options-reference.md)」をご覧ください。

[!code-cs[UseEncodingOptions](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetUseEncodingOptions)]

## <a name="use-softwarebitmap-with-a-xaml-image-control"></a>SoftwareBitmap と XAML Image コントロールを使う

[**Image**](https://msdn.microsoft.com/library/windows/apps/br242752) コントロールを使って XAML ページ内に画像を表示するには、まず XAML ページで **Image** コントロールを定義します。

[!code-xml[ImageControl](./code/ImagingWin10/cs/MainPage.xaml#SnippetImageControl)]

現時点では、**Image** コントロールは、BGRA8 エンコードを使用し、プリマルチプライ処理済みまたはアルファ チャネルなしの画像のみをサポートします。 画像を表示する前に、画像の形式が正しいことをテストしてください。形式が不適切な場合は、**SoftwareBitmap** の [**Convert**](https://msdn.microsoft.com/library/windows/apps/dn887362) メソッドを使用して、サポートされる形式に画像を変換してください。

新しい [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/dn997854) オブジェクトを作ります。 [**SetBitmapAsync**](https://msdn.microsoft.com/library/windows/apps/dn997856) を呼び出し、**SoftwareBitmap** で渡して、ソース オブジェクトの内容を設定します。 その新しく作成した **SoftwareBitmapSource** を、**Image** コントロールの [**Source**](https://msdn.microsoft.com/library/windows/apps/br242760) プロパティに設定します。

[!code-cs[SoftwareBitmapToWriteableBitmap](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetSoftwareBitmapToWriteableBitmap)]

**SoftwareBitmapSource** を [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/br210101) の [**ImageSource**](https://msdn.microsoft.com/library/windows/apps/br210105) として使用して **SoftwareBitmap** を設定することもできます。

## <a name="create-a-softwarebitmap-from-a-writeablebitmap"></a>WriteableBitmap から SoftwareBitmap を作成する

[**SoftwareBitmap.CreateCopyFromBuffer**](https://msdn.microsoft.com/library/windows/apps/dn887370) を呼び出して、**WriteableBitmap** の **PixelBuffer** プロパティを指定することで、既存の **WriteableBitmap** から **SoftwareBitmap** を作成し、ピクセル データを設定することができます。 新しく作成する **WriteableBitmap** のピクセル形式は第 2 引数で指定できます。 新しい画像のサイズは、**WriteableBitmap** の [**PixelWidth**](https://msdn.microsoft.com/library/windows/apps/br243253) プロパティと [**PixelHeight**](https://msdn.microsoft.com/library/windows/apps/br243251) プロパティを使って指定してください。

[!code-cs[WriteableBitmapToSoftwareBitmap](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetWriteableBitmapToSoftwareBitmap)]

## <a name="create-or-edit-a-softwarebitmap-programmatically"></a>SoftwareBitmap をプログラムから作成または編集する

ここまでは、画像ファイルを使った方法を紹介してきました。 新しい **SoftwareBitmap** をプログラム コードから作成し、同じ手法を用いて **SoftwareBitmap** のピクセル データにアクセスし、変更を加えることもできます。

**SoftwareBitmap** では、ピクセル データを含んだ RAW バッファーが、COM 相互運用機能を使って公開されます。

COM 相互運用機能を使うには、**System.Runtime.InteropServices** 名前空間の参照をプロジェクトに追加する必要があります。

[!code-cs[InteropNamespace](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetInteropNamespace)]

COM インターフェイス [**IMemoryBufferByteAccess**](https://msdn.microsoft.com/library/windows/desktop/mt297505) を初期化するには、対象の名前空間に以下のコードを追加します。

[!code-cs[COMImport](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetCOMImport)]

必要なピクセル形式とサイズを指定して新しい **SoftwareBitmap** を作成します。 既にある **SoftwareBitmap** のピクセル データを編集する必要がある場合は、その SoftwareBitmap を使ってもかまいません。 [**SoftwareBitmap.LockBuffer**](https://msdn.microsoft.com/library/windows/apps/dn887380) を呼び出して、ピクセル データ バッファーを表す [**BitmapBuffer**](https://msdn.microsoft.com/library/windows/apps/dn887325) クラスのインスタンスを取得します。 **BitmapBuffer** を COM インターフェイス **IMemoryBufferByteAccess** にキャストしたうえで [**IMemoryBufferByteAccess.GetBuffer**](https://msdn.microsoft.com/library/windows/desktop/mt297506) を呼び出し、バイト配列にデータを設定します。 ピクセルごとにバッファーのオフセットを計算しやすいよう、[**BitmapBuffer.GetPlaneDescription**](https://msdn.microsoft.com/library/windows/apps/dn887330) メソッドを使って [**BitmapPlaneDescription**](https://msdn.microsoft.com/library/windows/apps/dn887342) オブジェクトを取得します。

[!code-cs[CreateNewSoftwareBitmap](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetCreateNewSoftwareBitmap)]

このメソッドは、Windows ランタイム型よりも低いレベルの RAW バッファーにアクセスするため、**unsafe** キーワードを使って宣言する必要があります。 また、Microsoft Visual Studio でアンセーフ コードのコンパイルを許可するようにプロジェクトを構成する必要があります。プロジェクトの **[プロパティ]** ページを開き、**[ビルド]** プロパティ ページをクリックして、**[アンセーフ コードの許可]** チェック ボックスをオンにしてください。

## <a name="create-a-softwarebitmap-from-a-direct3d-surface"></a>Direct3D サーフェスから SoftwareBitmap を作成する

Direct3D サーフェスから **SoftwareBitmap** オブジェクトを作成するには、プロジェクトで [**Windows.Graphics.DirectX.Direct3D11**](https://msdn.microsoft.com/library/windows/apps/dn895104) 名前空間を追加する必要があります。

[!code-cs[Direct3DNamespace](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetDirect3DNamespace)]

サーフェスから新しい **SoftwareBitmap** を作成するには、[**CreateCopyFromSurfaceAsync**](https://msdn.microsoft.com/library/windows/apps/dn887373) を呼び出します。 この名前を見るとわかるように、新しい **SoftwareBitmap** には、画像データのコピーが別に存在します。 **SoftwareBitmap** に変更を加えても、Direct3D サーフェスには一切影響しません。

[!code-cs[CreateSoftwareBitmapFromSurface](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetCreateSoftwareBitmapFromSurface)]

## <a name="convert-a-softwarebitmap-to-a-different-pixel-format"></a>SoftwareBitmap を異なるピクセル形式に変換する

**SoftwareBitmap** クラスの静的メソッド [**Convert**](https://msdn.microsoft.com/library/windows/apps/dn887362) を使うと、既にある **SoftwareBitmap** から、指定したピクセル形式とアルファ モードを使った新しい **SoftwareBitmap** を簡単に作成することができます。 新しく作成されたビットマップには、画像データのコピーが別に存在します。 新しいビットマップに変更を加えても、元のビットマップには一切影響しません。

[!code-cs[Convert](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetConvert)]

## <a name="transcode-an-image-file"></a>画像ファイルのトランスコード

画像ファイルを [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) から [**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/br226206) に直接トランスコードすることができます。 トランスコードの対象となるファイルから [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) を作成します。 入力ストリームから新しい **BitmapDecoder** を作成します。 エンコーダーの書き込み先となる新しい [**InMemoryRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241720) を作成し、[**BitmapEncoder.CreateForTranscodingAsync**](https://msdn.microsoft.com/library/windows/apps/br226214) を呼び出します。このとき、引数にインメモリ ストリームとデコーダー オブジェクトを渡します。 トランスコードではエンコード オプションはサポートされません。オプションを指定する場合は、代わりに [**CreateAsync**](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapencoder.createasync) を使う必要があります。 入力画像ファイルのプロパティのうち、エンコーダーに対して明示的に指定しなかったプロパティはすべて元のまま、出力ファイルに書き込まれます。 [**FlushAsync**](https://msdn.microsoft.com/library/windows/apps/br226216) を呼び出すと、インメモリ ストリームへのエンコードをエンコーダーが開始します。 最後に、ファイル ストリームとインメモリ ストリームを先頭までシークし、[**CopyAsync**](https://msdn.microsoft.com/library/windows/apps/hh701827) を呼び出してインメモリ ストリームをファイル ストリームに書き込みます。

[!code-cs[TranscodeImageFile](./code/ImagingWin10/cs/MainPage.xaml.cs#SnippetTranscodeImageFile)]

## <a name="related-topics"></a>関連トピック

* [BitmapEncoder オプション リファレンス](bitmapencoder-options-reference.md)
* [画像のメタデータ](image-metadata.md)
 

 




