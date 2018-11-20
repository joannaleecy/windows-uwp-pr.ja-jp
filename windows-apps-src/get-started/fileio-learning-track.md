---
author: TylerMSFT
title: ファイルの操作
description: ユニバーサル Windows プラットフォームでファイルを操作する方法について説明します。
ms.author: twhitney
ms.date: 05/01/2018
ms.topic: article
keywords: 概要, uwp, windows 10, 学習トラック, ファイル, ファイル io, ファイルの読み取り, ファイルの書き込み, ファイルの作成, テキストの書き込み, テキストの読み取り
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 68240e5b3d2fb476b731853e6a7d020ecd9e2887
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7420056"
---
# <a name="work-with-files"></a>ファイルの操作

このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリでファイルに対する読み取りと書き込みを始めるために知っておく必要があることについて説明します。 主な API と型を紹介し、詳細情報を確認できるリンクを提供します。

これはチュートリアルではありません。 チュートリアルが必要な場合は、「[ファイルの作成、書き込み、および読み取り](https://docs.microsoft.com/windows/uwp/files/quickstart-reading-and-writing-files)」を参照してください。このチュートリアルでは、ファイルの作成、書き込み、および読み取り方法だけでなく、バッファーとストリームの使用方法を示しています。 また、「[ファイル アクセスのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/FileAccess)」を参照することもできます。このドキュメントでは、ファイルの作成、読み取り、書き込み、コピー、削除方法に加え、ファイル プロパティを取得し、ファイルやフォルダーを記憶して、アプリが再び簡単にアクセスできるようにする方法を示しています。

ファイルからのテキストの書き込みと読み取りを行うためのコード、およびアプリのローカル フォルダー、移動フォルダー、一時フォルダーにアクセスする方法について説明します。

## <a name="what-do-you-need-to-know"></a>理解しておく必要があること

ファイルに対してテキストの読み取りや書き込みを行うために知っておく必要がある主な型を次に示します。

- [Windows.Storage.StorageFile](https://docs.microsoft.com/uwp/api/windows.storage.storagefile) はファイルを表します。 このクラスには、ファイルに関する情報を提供するプロパティ、およびファイルを作成、開く、コピー、削除、名前変更するためのメソッドがあります。
文字列パスの処理には慣れているかもしれません。 文字列パスを指定するいくつかの UWP API がありますが、より多くの場合に、**StorageFile** を使用してファイルを表します。これは、UWP で操作する一部のファイルにパスがないか、または扱うのが難しいパスがあるためです。 [StorageFile.GetFileFromPathAsync()](https://docs.microsoft.com/uwp/api/windows.storage.storagefile.getfilefrompathasync) を使用して文字列パスを **StorageFile** に変換します。 

- [FileIO](https://docs.microsoft.com/uwp/api/windows.storage.fileio) クラスを使用すると、テキストの読み取りと書き込みを簡単に行うことができます。 また、このクラスは、バイトの配列またはバッファーの内容の読み取り/書き込みを行うことができます。 このクラスは [PathIO](https://docs.microsoft.com/uwp/api/windows.storage.pathio) クラスとよく似ています。 主な違いは、**PathIO** が行うように文字列パスを指定する代わりに、**StorageFile** を指定する点です。
- [Windows.Storage.StorageFolder](https://docs.microsoft.com/uwp/api/windows.storage.storagefolder) はフォルダー (ディレクトリ) を表します。 このクラスには、ファイルの作成、フォルダーの内容の照会、フォルダーの作成、名前変更、削除を行うためのメソッド、およびフォルダーに関する情報を提供するプロパティがあります。 

**StorageFolder** を取得する一般的な方法には次のものがあります。

- ユーザーが使用するフォルダーに移動できるようにする [Windows.Storage.Pickers.FolderPicker](https://docs.microsoft.com/uwp/api/windows.storage.pickers.folderpicker)。
- ローカル フォルダー、移動フォルダー、一時フォルダーのようなアプリに対してローカルであるいずれかのフォルダーに固有の **StorageFolder** を提供する [Windows.Storage.ApplicationData.Current](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata.current)。
- ミュージック ライブラリまたは画像ライブラリのような既知のライブラリに **StorageFolder** を提供する [Windows.Storage.KnownFolders](https://docs.microsoft.com/uwp/api/windows.storage.knownfolders)。

## <a name="write-text-to-a-file"></a>ファイルへのテキストの書き込み

 この概要では、テキストの読み取りと書き込みという単純なシナリオを中心に説明します。 まず、**FileIO** クラスを使用してファイルにテキストを書き込む一部のコードを見てみましょう。

```csharp
Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile file = await storageFolder.CreateFileAsync("test.txt",
        Windows.Storage.CreationCollisionOption.OpenIfExists);

await Windows.Storage.FileIO.WriteTextAsync(file, "Example of writing a string\r\n");

// Append a list of strings, one per line, to the file
var listOfStrings = new List<string> { "line1", "line2", "line3" };
await Windows.Storage.FileIO.AppendLinesAsync(file, listOfStrings); // each entry in the list is written to the file on its own line.
```

まず、ファイルがある場所を特定します。 `Windows.Storage.ApplicationData.Current.LocalFolder`  は、アプリのインストール時にアプリ用に作成されるローカル データ フォルダーへのアクセスを提供します。 アプリでアクセスできるフォルダーの詳細については、「[ファイル システムへのアクセス](#access-the-file-system)」を参照してください。

次に、**StorageFolder** を使用してファイルを作成します (またはファイルが既に存在する場合は開きます)。

**FileIO** クラスは、ファイルにテキストを書き込むための便利な方法です。 `FileIO.WriteTextAsync()`  は、ファイルのすべての内容を指定されたテキストで置き換えます。 `FileIO.AppendLinesAsync()`  は、文字列のコレクションをファイルに追加します。1 つの文字列が 1 行に書き込まれます。

## <a name="read-text-from-a-file"></a>ファイルからのテキストの読み取り

ファイルの書き込みと同様に、ファイルの読み取りは、ファイルの場所を指定することから始めます。 上の例と同じ場所を使用します。 その内容を読み取る**FileIO**クラスを使用します。

```csharp
Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("test.txt");

string text = await Windows.Storage.FileIO.ReadTextAsync(file);
```

ファイルの各行を以下を含むコレクション内の個々の文字列に読み取ることもできます。 `IList<string> contents = await Windows.Storage.FileIO.ReadLinesAsync(sampleFile);`

## <a name="access-the-file-system"></a>ファイル システムへのアクセス

UWP プラットフォームでは、フォルダー アクセスは、ユーザーのデータの整合性とプライバシーを確保するために制限されます。 

### <a name="app-folders"></a>アプリのフォルダー

UWP アプリがインストールされると、特にアプリのローカル ファイル、移動ファイル、一時ファイルを格納するための複数のフォルダーが c:\users\<user name>\AppData\Local\Packages\<app package identifier>\ に作成されます。 アプリは、これらのフォルダーにアクセスするためにすべての機能を宣言する必要はありません。また、これらのフォルダーは他のアプリがアクセスすることはできません。 アプリがアンインストールされると、これらのフォルダーも削除されます。

よく使用されるアプリ フォルダーをいくつか次に示します。

- **LocalState**: 現在のデバイスに対してローカルなデータ用です。 デバイスがバックアップされると、このディレクトリ内のデータは OneDrive のバックアップ イメージに保存されます。 ユーザーがデバイスをリセットするか、置き換えると、データは復元されます。 `Windows.Storage.ApplicationData.Current.LocalFolder.` でこのフォルダーにアクセスします。OneDrive にバックアップしないローカル データを **LocalCacheFolder** に保存します。このフォルダーには `Windows.Storage.ApplicationData.Current.LocalCacheFolder` でアクセスできます。

- **RoamingState**: アプリがインストールされているすべてのデバイスでレプリケートされる必要があるデータ用です。 Windows では、ローミングされるデータの量を制限しているため、ここにはユーザー設定と小さなファイルのみ保存します。 `Windows.Storage.ApplicationData.Current.RoamingFolder` で移動フォルダーにアクセスします。

- **TempState**: アプリが実行されていないときに削除される可能性があるデータ用です。 `Windows.Storage.ApplicationData.Current.TemporaryFolder` でこのフォルダーにアクセスします。

### <a name="access-the-rest-of-the-file-system"></a>残りのファイル システムへのアクセス

UWP アプリはそのインテントを宣言し、そのマニフェストに対応する機能を追加することで特定のユーザー ライブラリにアクセスする必要があります。 アプリがインストールされると、ユーザーに確認メッセージが表示され、指定されたライブラリへのアクセスの承認が確認されます。 確認メッセージが表示されない場合は、アプリはインストールされていません。 画像、ビデオ、ミュージック ライブラリにアクセスするための機能があります。 詳しい一覧については、「[アプリ機能の宣言](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations)」を参照してください。 これらのライブラリの **StorageFolder** を取得するには、[Windows.Storage.KnownFolders](https://docs.microsoft.com/uwp/api/windows.storage.knownfolders) クラスを使用します。

#### <a name="documents-library"></a>ドキュメント ライブラリ

ユーザーのドキュメント ライブラリにアクセスするための機能がありますが、その機能は制限されています。つまり、特別な承認を受けるためのプロセスに従わない限り、それを宣言しているアプリは、Microsoft Store によって拒否されます。 通常の使用を意図したものではありません。 代わりに、ファイルまたはフォルダー ピッカーを使用します (「[ピッカーでファイルやフォルダーを開く](https://docs.microsoft.com/windows/uwp/files/quickstart-using-file-and-folder-pickers)」および「[ピッカーによるファイルの保存](https://docs.microsoft.com/windows/uwp/files/quickstart-save-a-file-with-a-picker)」を参照)。これによりユーザーはフォルダーまたはファイルに移動できるようになります。 ユーザーがフォルダーまたはファイルに移動すると、フォルダーやファイルへのアクセス許可が暗黙的にアプリに与えられ、システムでアクセスが許可されます。

#### <a name="general-access"></a>一般的なアクセス

または、アプリは制限された [broadFileSystem](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations) 機能をマニフェストで宣言することができます。これにも Microsoft Store の承認が必要になります。 その後、ファイル ピッカーまたはフォルダー ピッカーを操作する必要なく、ユーザーがアクセス権を持つすべてのファイルにアプリがアクセスできます。

アプリがアクセスできる場所の包括的な一覧については、「[ファイル アクセス許可](https://docs.microsoft.com/windows/uwp/files/file-access-permissions)」を参照してください。

## <a name="useful-apis-and-docs"></a>便利な API とドキュメント

API の簡単な概要と、ファイルやフォルダーの使用を開始するために役立つその他の便利なドキュメントを次に示します。

### <a name="useful-apis"></a>便利な API

| API | 説明 |
|------|---------------|
|  [Windows.Storage.StorageFile](https://docs.microsoft.com/uwp/api/windows.storage.storagefile) | ファイルを作成、開く、コピー、削除、および名前変更する方法に関する情報を提供します。 |
| [Windows.Storage.StorageFolder](https://docs.microsoft.com/uwp/api/windows.storage.storagefolder) | フォルダー、ファイルを作成するためのメソッド、およびフォルダーを作成、名前変更、削除するためのメソッドに関する情報を提供します。 |
| [FileIO](https://docs.microsoft.com/uwp/api/windows.storage.fileio) |  テキストの読み取りと書き込みを行う簡単な方法です。 また、このクラスはバイトの配列またはバッファーの内容の読み取り/書き込みを行うことができます。 |
| [PathIO](https://docs.microsoft.com/uwp/api/windows.storage.pathio) | ファイルの文字列パスを指定されたファイルに対するテキストの読み取り/書き込みを行う簡単な方法です。 また、このクラスはバイトの配列またはバッファーの内容の読み取り/書き込みを行うことができます。 |
| [DataReader](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader) & [DataWriter](https://docs.microsoft.com/uwp/api/windows.storage.streams.datawriter) |  ストリームに対してバッファー、バイト、整数、GUID、TimeSpans などの読み取りと書き込みを行います。 |
| [Windows.Storage.ApplicationData.Current](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata.current) | ローカル フォルダー、移動フォルダー、一時ファイル フォルダーなど、アプリ用に作成されたフォルダーへのアクセスを提供します。 |
| [Windows.Storage.Pickers.FolderPicker](https://docs.microsoft.com/uwp/api/windows.storage.pickers.folderpicker) |  ユーザーがフォルダーを選択できるようにし、そのフォルダーの **StorageFolder** を返します。 このようにして、既定ではアプリがアクセスできない場所にアクセスします。 |
| [Windows.Storage.Pickers.FileOpenPicker](https://docs.microsoft.com/uwp/api/windows.storage.pickers.fileopenpicker) | ユーザーが開くファイルを選択できるようにし、そのファイルの **StorageFile** を返します。 このようにして、既定ではアプリがアクセスできないファイルにアクセスします。 |
| [Windows.Storage.Pickers.FileSavePicker](https://docs.microsoft.com/uwp/api/windows.storage.pickers.filesavepicker) | ユーザーがファイルのファイル名、拡張子、および記憶域の場所を選択できるようにします。 **StorageFile** を返します。 このようにして、既定ではアプリがアクセスできない場所にファイルを保存します。 |
|  [Windows.Storage.Streams namespace](https://docs.microsoft.com/uwp/api/windows.storage.streams) | ストリームの読み取りと書き込みについて説明します。 特に、[DataReader](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader) クラスと [DataWriter](https://docs.microsoft.com/uwp/api/windows.storage.streams.datawriter) クラスに注目します。これらのクラスはバッファー、バイト、整数、GUID、TimeSpans などの読み取りと書き込みを行います。 |

### <a name="useful-docs"></a>役立つドキュメント

| トピック | 説明 |
|-------|----------------|
| [Windows.Storage Namespace](https://docs.microsoft.com/uwp/api/windows.storage) | API リファレンス ドキュメントです。 |
| [ファイル、フォルダー、およびライブラリ](https://docs.microsoft.com/windows/uwp/files/) | 概念に関するドキュメントです。 |
| [ファイルの作成、書き込み、および読み取り](https://docs.microsoft.com/windows/uwp/files/quickstart-reading-and-writing-files) | テキスト、バイナリ データ、およびストリームの作成、読み取り、書き込みについて説明します。 |
| [アプリ データのローカルへの保存に関する概要](https://blogs.windows.com/buildingapps/2016/05/10/getting-started-storing-app-data-locally/#pCbJKGjcShh5DTV5.97) | ローカル データを保存するためのベスト プラクティスだけでなく、LocalSettings および LocalCache フォルダーの目的について説明します。 |
| [アプリのデータのローミングの概要](https://blogs.windows.com/buildingapps/2016/05/03/getting-started-with-roaming-app-data/#RgjgLt5OkU9DbVV8.97) | アプリのデータのローミングを使用する方法に関する 2 部で構成される資料です。 |
| [アプリケーション データのローミングのガイドライン](http://msdn.microsoft.com/library/windows/apps/hh465094) | アプリの設計時にはデータ ローミングのガイドラインに従ってください。 |
| [設定と他のアプリ データを保存して取得する](https://docs.microsoft.com/windows/uwp/design/app-settings/store-and-retrieve-app-data) | ローカル フォルダー、移動フォルダー、および一時フォルダーなど、さまざまなアプリのデータ ストアの概要を示します。 「[ローミング データ](https://docs.microsoft.com/windows/uwp/design/app-settings/store-and-retrieve-app-data#roaming-data)」セクションで、デバイス間でローミングされるデータの書き込みに関する追加の情報とガイドラインを参照してください。 |
| [ファイル アクセス許可](https://docs.microsoft.com/windows/uwp/files/file-access-permissions) | アプリでアクセスできるファイル システムの場所に関する情報です。 |
| [ピッカーでファイルやフォルダーを開く](https://docs.microsoft.com/windows/uwp/files/quickstart-using-file-and-folder-pickers) | ピッカーの UI を介してユーザーが決定できるようにすることでファイルやフォルダーにアクセスする方法を示します。 |
| [Windows.Storage.Streams](https://docs.microsoft.com/uwp/api/windows.storage.streams) | ストリームの読み取りと書き込みに使用される型です。 |
| [ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](https://docs.microsoft.com/windows/uwp/files/quickstart-managing-folders-in-the-music-pictures-and-videos-libraries) | ライブラリからフォルダーを削除したり、ライブラリ内のフォルダーの一覧を取得したり、保存した写真、音楽、ビデオを検索したりする方法について説明します。 |

## <a name="useful-code-samples"></a>役立つコード サンプル

| コード サンプル | 説明 |
|-----------------|---------------|
| [アプリケーション データ サンプル](https://code.msdn.microsoft.com/windowsapps/ApplicationData-sample-fb043eb2) | アプリケーション データ API を使って、ユーザーごとに特有のデータを保存、取得する方法を示します。 |
| [ファイル アクセスのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/FileAccess) | ファイルを作成、読み取り、書き込み、コピー、および削除する方法を示します。 |
| [ファイル ピッカーのサンプル](http://code.msdn.microsoft.com/windowsapps/File-picker-sample-9f294cba) | ユーザーが UI で選択できるようにしてファイルやフォルダーにアクセスする方法、ユーザーが保存するファイルの名前、ファイルの種類、場所を指定できるようにファイルを保存する方法を示します。 |
| [JSON サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Json) | [Windows.Data.Json namespace](https://docs.microsoft.com/uwp/api/Windows.Data.Json) を使用して、JavaScript Object Notation (JSON) オブジェクト、配列、文字列、数値、ブール値をエンコードおよびデコードする方法を示します。 |
| [その他のコード サンプル](https://developer.microsoft.com//windows/samples) | [カテゴリ] ドロップダウン リストで、**[Files, folder, and libraries] (ファイル、フォルダー、およびライブラリ)** を選択します。 |
