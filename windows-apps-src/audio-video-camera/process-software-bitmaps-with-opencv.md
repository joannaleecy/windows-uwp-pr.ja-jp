---
author: laurenhughes
ms.assetid: ''
description: この記事では、Open Source Computer Vision Library (OpenCV) で、SoftwareBitmap クラスを使用する方法について説明します。
title: OpenCV でのビットマップの処理
ms.author: lahugh
ms.date: 03/19/2018
ms.topic: article
keywords: Windows 10, UWP, OpenCV, SoftwareBitmap
ms.localizationpriority: medium
ms.openlocfilehash: b9f1f2050590267d0a98779eba11bbe0b363da0c
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7149201"
---
# <a name="process-bitmaps-with-opencv"></a>OpenCV でのビットマップの処理

この記事では、さまざまな種類の UWP API で使用されている **[SoftwareBitmap](https://docs.microsoft.com/uwp/api/Windows.Graphics.Imaging.SoftwareBitmap)** クラスを、さまざまな画像処理アルゴリズムを提供するオープン ソースの、ネイティブ コード ライブラリである Open Source Computer Vision Library (OpenCV) で使用する方法について説明します。 

この記事の例は、C# を使用して作成されるアプリを含め、UWP アプリから使用できるネイティブ コードの Windows ランタイム コンポーネントを作成するチュートリアルです。 このヘルパー コンポーネントは、OpenCV の blur 画像処理関数を使用する 1 つのメソッド **Blur** を公開します。 このコンポーネントは、OpenCV ライブラリから直接使用できる、基になる画像データ バッファーへのポインターを取得するプライベート メソッドを実装します。これにより、ヘルパー コンポーネントを拡張して他の OpenCV 処理機能を実装することが容易になります。 

* **SoftwareBitmap** の使用方法の概要については、「[ビットマップ画像の作成、編集、保存](imaging.md)」をご覧ください。 
* OpenCV ライブラリーを使用する方法については、[http://opencv.org](http://opencv.org) をご覧ください。
* この記事で説明する OpenCV ヘルパー コンポーネントを **[MediaFrameReader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframereader)** と共に使用して、カメラからのフレームのリアルタイムの画像処理を実現する方法については、「[OpenCV と MediaFrameReader の使用](use-opencv-with-mediaframereader.md)」をご覧ください。
* 複数の効果を実装する完全なコード例については、Windows ユニバーサル サンプル GitHub リポジトリにある[カメラ フレームと OpenCV のサンプル](https://go.microsoft.com/fwlink/?linkid=854003)をご覧ください。

> [!NOTE] 
> この記事で解説する OpenCVHelper コンポーネントで使用されている手法では、処理される画像データが GPU メモリではなく CPU メモリに格納されている必要があります。 したがって、画像のメモリ位置を要求できる API (**[MediaCapture](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapture)** クラスなど) では、CPU メモリを指定する必要があります。

## <a name="create-a-helper-windows-runtime-component-for-opencv-interop"></a>OpenCV 相互運用のためのヘルパー Windows ランタイム コンポーネントを作成する

### <a name="1-add-a-new-native-code-windows-runtime-component-project-to-your-solution"></a>1. ソリューションに新しいネイティブ コードの Windows ランタイム コンポーネント プロジェクトを追加する

1. ソリューション エクスプローラーで、ソリューションを右クリックして **[追加]、[新しいプロジェクト]** の順に選択し、新しいプロジェクトを Visual Studio のソリューションに追加します。 
2. **[Visual C++]** カテゴリで、**[Windows ランタイム コンポーネント (ユニバーサル Windows)]** を選択します。 この例では、「OpenCVBridge」というプロジェクト名を入力し、**[OK]** をクリックします。 
3. **[新しい Windows ユニバーサル プロジェクト]** ダイアログ ボックスで、アプリのターゲットと最小 OS バージョンを選択して **[OK]** をクリックします。
4. ソリューション エクスプローラーで自動生成された Class1.cpp ファイルを右クリックして **[削除]** を選択し、確認のダイアログ ボックスが表示されたら **[削除]** を選択します。 次に Class1.h ヘッダー ファイルを削除します。
5. OpenCVBridge プロジェクト アイコンを右クリックし、**[追加]、[クラス]** の順に選択します。**[クラスの追加]** ダイアログ ボックスで、**[クラス名]** フィールドに「OpenCVHelper」と入力し、**[OK]** をクリックします。 コードは、後の手順で作成されるクラス ファイルに追加されます。

### <a name="2-add-the-opencv-nuget-packages-to-your-component-project"></a>2. OpenCV NuGet パッケージをコンポーネント プロジェクトに追加する

1. ソリューション エクスプローラーで、OpenCVBridge プロジェクト アイコンを右クリックし、**[NuGet パッケージの管理]** をクリックします。
2. [NuGet パッケージ マネージャー] ダイアログが開いたら、**[参照]** タブを選択し、検索ボックスに「OpenCV.Win」と入力します。
3. [OpenCV.Win.Core] を選択し、**[インストール]** をクリックします。 **[プレビュー]** ダイアログ ボックスで、**[OK]** をクリックします。
4. 同じ手順で "OpenCV.Win.ImgProc" パッケージをインストールします。

> [!NOTE]
> OpenCV.Win.Core と OpenCV.Win.ImgProc は定期的に更新されていませんが、このページの説明に従って OpenCVHelper を作成することをお勧めします。

### <a name="3-implement-the-opencvhelper-class"></a>3. OpenCVHelper クラスを実装する

OpenCVHelper.h ヘッダー ファイルに以下のコードを貼り付けます。 このコードには、インストールした *Core* パッケージと *ImgProc* パッケージの OpenCV ヘッダー ファイルが含まれており、以下の手順で示される 3 つのメソッドを宣言しています。

[!code-cpp[OpenCVHelperHeader](./code/ImagingWin10/cs/OpenCVBridge/OpenCVHelper.h#SnippetOpenCVHelperHeader)]

OpenCVHelper.cpp ファイルの既存の内容を削除し、次の include ディレクティブを追加します。 

[!code-cpp[OpenCVHelperInclude](./code/ImagingWin10/cs/OpenCVBridge/OpenCVHelper.cpp#SnippetOpenCVHelperInclude)]

include ディレクティブの後に、以下の **using** ディレクティブを追加します。 

[!code-cpp[OpenCVHelperUsing](./code/ImagingWin10/cs/OpenCVBridge/OpenCVHelper.cpp#SnippetOpenCVHelperUsing)]

次に、**GetPointerToPixelData** メソッドを OpenCVHelper.cpp に追加します。 このメソッドは、**[SoftwareBitmap](https://docs.microsoft.com/uwp/api/Windows.Graphics.Imaging.SoftwareBitmap)** を受け取り、一連の変換を経て、ピクセル データの COM インターフェイス表現を取得します。これにより、基になるデータ バッファーへのポインターを **char** 配列として取得できます。 

最初に、ピクセル データを格納する **[BitmapBuffer](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapbuffer)** が、**[LockBuffer](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.softwarebitmap.lockbuffer)** を呼び出すことによって取得されます。LockBuffer は読み取り/書き込みバッファーを要求し、OpenCV ライブラリはそのピクセル データを変更できるようにします。  **[CreateReference](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapbuffer.CreateReference)** が呼び出され、**[IMemoryBufferReference](https://docs.microsoft.com/uwp/api/windows.foundation.imemorybufferreference)** オブジェクトが取得されます。 次に、**IMemoryBufferByteAccess** インターフェイスが、すべての Windows ランタイム クラスの基本インターフェイスである **IInspectable** としてキャストされ、**[QueryInterface](https://msdn.microsoft.com/library/windows/desktop/ms682521(v=vs.85).aspx)** が呼び出されて **[IMemoryBufferByteAccess](https://msdn.microsoft.com/library/mt297505(v=vs.85).aspx)** COM インターフェイスが取得されます。これにより、ピクセル データ バッファーを **char** 配列として取得できます。 最後に、**[IMemoryBufferByteAccess::GetBuffer](https://msdn.microsoft.com/library/mt297506(v=vs.85).aspx)** を呼び出して **char** 配列を設定します。 このメソッドの変換手順のいずれかが失敗した場合、メソッドは **false** を返し、処理が続行できないことを示します。

[!code-cpp[OpenCVHelperGetPointerToPixelData](./code/ImagingWin10/cs/OpenCVBridge/OpenCVHelper.cpp#SnippetOpenCVHelperGetPointerToPixelData)]

次に、以下に示すように **TryConvert** メソッドを追加します。 このメソッドは、**SoftwareBitmap** を受け取り、**Mat** オブジェクトへの変換を試行します。このオブジェクトは、OpenCV が画像データ バッファーを表すために使用するマトリックス オブジェクトです。 このメソッドは、上で定義した **GetPointerToPixelData** メソッドを呼び出して、ピクセル データ バッファーの **char** 配列表現を取得します。 これが成功した場合、**Mat** クラスのコンストラクターが呼び出され、ソース **SoftwareBitmap** オブジェクトから取得されたピクセルの幅と高さが渡されます。 

> [!NOTE] 
> この例では、作成された **Mat** オブジェクトのピクセル形式として CV_8UC4 定数を指定します。 つまり、このメソッドに渡される **SoftwareBitmap** の **[BitmapPixelFormat](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.softwarebitmap.BitmapPixelFormat)** プロパティの値は、プリマルチプライ済みアルファを含む **[BGRA8](https://docs.microsoft.com/uwp/api/Windows.Graphics.Imaging.BitmapPixelFormat)** (この例で使用する CV_8UC4 と同等) である必要があります。

作成された **Mat** オブジェクトのシャロー コピーがこのメソッドによって返されるため、それ以降の処理は、バッファーのコピーではなく、**SoftwareBitmap** によって参照される同じデータのピクセル データ バッファーで実行されます。

[!code-cpp[OpenCVHelperTryConvert](./code/ImagingWin10/cs/OpenCVBridge/OpenCVHelper.cpp#SnippetOpenCVHelperTryConvert)]

最後に、この例のヘルパー クラス メソッドは、1 つの画像処理メソッド **Blur** を実装します。これは、上で定義した **TryConvert** メソッドを使用して、ぼかし操作のソース ビットマップとターゲット ビットマップを表す **Mat** オブジェクトを取得し、OpenCV ImgProc ライブラリの **blur** メソッドを呼び出します。 **blur** のその他のパラメーターで、X および Y 方向のぼかし効果のサイズを指定します。

[!code-cpp[OpenCVHelperBlur](./code/ImagingWin10/cs/OpenCVBridge/OpenCVHelper.cpp#SnippetOpenCVHelperBlur)]


## <a name="a-simple-softwarebitmap-opencv-example-using-the-helper-component"></a>ヘルパー コンポーネントを使用するシンプルな SoftwareBitmap OpenCV の例
OpenCVBridge コンポーネントが作成されたので、OpenCV の **blur** メソッドを使用して **SoftwareBitmap** を変更するシンプルな C# アプリを作成できます。 UWP アプリから Windows ランタイム コンポーネントにアクセスするには、最初にコンポーネントへの参照を追加する必要があります。 ソリューション エクスプローラーで、UWP アプリ プロジェクトの下にある **[参照設定] **ノードを右クリックし、**[参照の追加]** を選択します。[参照マネージャー] ダイアログ ボックスで、**[プロジェクト]、[ソリューション]** の順に選択します。 OpenCVBridge プロジェクトの横のボックスをオンにし、**[OK]** をクリックします。

次のコード例では、ユーザーは画像ファイルを選択し、**[BitmapDecoder](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.bitmapencoder)** を使用して画像の  **SoftwareBitmap** 表現を作成できます。 **SoftwareBitmap** の操作について詳しくは、「[ビットマップ画像の作成、編集、保存](https://docs.microsoft.com/windows/uwp/audio-video-camera/imaging)」をご覧ください。

この記事で既に説明したように、**OpenCVHelper** クラスでは、提供されるすべての **SoftwareBitmap** 画像がプリマルチプライ済みアルファ付き BGRA8 ピクセル形式でエンコードされている必要があります。そのため、画像がこの形式ではない場合、このコード例では **[Convert](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.softwarebitmap.BitmapAlphaMode)** を呼び出して画像を予期された形式に変換します。

次に、ぼかし操作のターゲットとして使用される **SoftwareBitmap** が作成されます。 一致する形式のビットマップを作成するために、入力画像のプロパティがコンストラクターの引数として使用されます。

**OpenCVHelper** の新しいインスタンスが作成されると、**Blur** メソッドが呼び出され、ソースとターゲットのビットマップが渡されます。 最後に、**SoftwareBitmapSource** が作成され、出力画像を XAML **Image** コントロールに割り当てます。


[!code-cs[OpenCVBlur](./code/ImagingWin10/cs/MainPage.OpenCV.xaml.cs#SnippetOpenCVBlur)]

## <a name="related-topics"></a>関連トピック

* [BitmapEncoder オプション リファレンス](bitmapencoder-options-reference.md)
* [画像のメタデータ](image-metadata.md)
 

 




