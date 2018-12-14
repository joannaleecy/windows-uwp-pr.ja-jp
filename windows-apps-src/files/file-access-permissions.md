---
ms.assetid: 3A404CC0-A997-45C8-B2E8-44745539759D
title: ファイル アクセス許可
description: アプリは既定でファイル システムの特定の場所にアクセスできます。 また、ファイル ピッカーを使うか機能を宣言すると、その他の場所にアクセスすることもできます。
ms.date: 06/28/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 05ff8dd78f58910512291b819d59d68f682cc93c
ms.sourcegitcommit: 23748871459931fc838c5e259e4822bffcf3cdea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/14/2018
ms.locfileid: "8970937"
---
# <a name="file-access-permissions"></a>ファイル アクセス許可

ユニバーサル Windows アプリ (アプリ) は、既定でファイル システムの特定の場所にアクセスできます。 また、ファイル ピッカーの使用や機能の宣言によって、その他の場所にアクセスすることもできます。

## <a name="the-locations-that-all-apps-can-access"></a>すべてのアプリからアクセスできる場所

新しいアプリを作成すると、既定でファイル システムの次の場所にアクセスできます。

### <a name="application-install-directory"></a>アプリケーションのインストール ディレクトリ
ユーザーのシステムで、アプリがインストールされているフォルダーです。

ファイルにアクセスする 2 つの主な方法がありますが、フォルダーで、アプリのインストール ディレクトリ。

1. 次のように、アプリのインストール ディレクトリを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) を取得できます。

```csharp
Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
```

```javascript
var installDirectory = Windows.ApplicationModel.Package.current.installedLocation;
```

```cppwinrt
#include <winrt/Windows.Storage.h>
...
Windows::Storage::StorageFolder installedLocation{ Windows::ApplicationModel::Package::Current().InstalledLocation() };
```

```cpp
Windows::Storage::StorageFolder^ installedLocation = Windows::ApplicationModel::Package::Current->InstalledLocation;
```

[**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) メソッドを使って、ディレクトリ内のファイルとフォルダーにアクセスすることができます。 上の例では、この **StorageFolder** が `installDirectory` 変数に格納されています。 アプリ パッケージやインストール ディレクトリの操作について詳しくは、GitHub にある[アプリ パッケージ情報のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Package)をご覧ください。

2. 次のように、アプリの URI を使って、アプリのインストール ディレクトリからファイルを直接取得できます。

```cs
using Windows.Storage;            
StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///file.txt"));
```

```javascript
Windows.Storage.StorageFile.getFileFromApplicationUriAsync("ms-appx:///file.txt").done(
    function(file) {
        // Process file
    }
);
```

```cppwinrt
Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
{
    Windows::Storage::StorageFile file{
        co_await Windows::Storage::StorageFile::GetFileFromApplicationUriAsync(Windows::Foundation::Uri{L"ms-appx:///file.txt"})
    };
    // Process file
}
```

```cpp
auto getFileTask = create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri("ms-appx:///file.txt")));
getFileTask.then([](StorageFile^ file) 
{
    // Process file
});
```

[**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) が完了すると、アプリのインストール ディレクトリにある `file.txt` ファイル (この例では `file`) を表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) が返されます。

URI の "ms-appx:///" プレフィックスは、アプリのインストール ディレクトリを参照します。 アプリの URI の使用について詳しくは、「[URI を使ってコンテンツを参照する方法](https://msdn.microsoft.com/library/windows/apps/hh781215)」をご覧ください。

さらに、他の場所とは異なり、[ユニバーサル Windows プラットフォーム (UWP) アプリの Win32 と COM](https://msdn.microsoft.com/library/windows/apps/br205757) や [Microsoft Visual Studio の C/C++ 標準ライブラリ関数](http://msdn.microsoft.com/library/hh875057.aspx)を使ってアプリのインストール ディレクトリ内のファイルにアクセスすることもできます。

アプリのインストール ディレクトリは読み取り専用です。 ファイル ピッカーでは、インストール ディレクトリにアクセスをできなくなります。

### <a name="application-data-locations"></a>アプリケーション データの場所
アプリがデータを保存できるフォルダーです。 これらのフォルダー (ローカル、移動、一時) は、アプリのインストール時に作成されます。

アプリのデータの場所からファイルとフォルダーにアクセスする 2 つの主要な方法はあります。

1.  [**ApplicationData**](https://msdn.microsoft.com/library/windows/apps/br241587) プロパティを使ってアプリ データ フォルダーを取得します。

たとえば、次のように、[**ApplicationData**](https://msdn.microsoft.com/library/windows/apps/br241587).[**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) を使って、アプリのローカル フォルダーを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) を取得できます。

```cs
using Windows.Storage;
StorageFolder localFolder = ApplicationData.Current.LocalFolder;
```

```javascript
var localFolder = Windows.Storage.ApplicationData.current.localFolder;
```

```cppwinrt
Windows::Storage::StorageFolder storageFolder{
    Windows::Storage::ApplicationData::Current().LocalFolder()
};
```

```cpp
using namespace Windows::Storage;
StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
```

アプリの移動フォルダーまたは一時フォルダーにアクセスする場合は、[**RoamingFolder**](https://msdn.microsoft.com/library/windows/apps/br241623) プロパティまたは [**TemporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティを使います。

アプリ データの場所を表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) を取得したら、**StorageFolder** メソッドを使って、その場所にあるファイルやフォルダーにアクセスできます。 上の例では、これらの **StorageFolder** オブジェクトが `localFolder` 変数に格納されています。 アプリ データの場所の使用について詳しくは、[ApplicationData クラス](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata)のページのガイダンスをご覧ください。また、GitHub から[アプリケーション データ サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ApplicationData)をダウンロードしてご覧ください。

2. たとえば、次のように、アプリの URI を使って、アプリのローカル フォルダーからファイルを直接取得できます。

```cs
using Windows.Storage;
StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/file.txt"));
```

```javascript
Windows.Storage.StorageFile.getFileFromApplicationUriAsync("ms-appdata:///local/file.txt").done(
    function(file) {
        // Process file
    }
);
```

```cppwinrt
Windows::Storage::StorageFile file{
    co_await Windows::Storage::StorageFile::GetFileFromApplicationUriAsync(Windows::Foundation::Uri{ L"ms-appdata:///local/file.txt" })
};
// Process file
```

```cpp
using Windows::Storage;
auto getFileTask = create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri("ms-appdata:///local/file.txt")));
getFileTask.then([](StorageFile^ file) 
{
    // Process file
});
```

[**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) が完了すると、アプリのローカル フォルダーにある `file.txt` ファイル (この例では `file`) を表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) が返されます。

URI の "ms-appdata:///local/" プレフィックスは、アプリのローカル フォルダーを参照します。 アプリの移動フォルダーまたは一時フォルダーにあるファイルにアクセスするには、"ms-appdata:///roaming/" または "ms-appdata:///temporary/" を使います。 アプリの URI の使用について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/hh781229)」をご覧ください。

さらに、他の場所とは異なり、[UWP アプリの Win32 と COM](https://msdn.microsoft.com/library/windows/apps/br205757) や Visual Studio の C/C++ 標準ライブラリ関数を使ってアプリ データの場所にあるファイルにアクセスすることもできます。

ファイル ピッカーでローカル、移動、または一時フォルダーにアクセスすることはできません。

### <a name="removable-devices"></a>リムーバブル デバイス
さらに、接続されているデバイス上の一部のファイルに既定でアクセスできます。 これは、[自動再生拡張機能](https://msdn.microsoft.com/library/windows/apps/xaml/hh464906.aspx#autoplay)を使って、ユーザーがデバイス (カメラや USB サム ドライブなど) をシステムに接続したときに自動的に起動されるようにする場合に使うことができます。 アプリでアクセスできるファイルの種類は、アプリ マニフェストのファイルの種類の関連付けの宣言で指定されたものだけに制限されます。

もちろん、ファイル ピッカー ([**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) と [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881)) を呼び出して、アプリでアクセスするファイルやフォルダーをユーザーが選べるようにすると、リムーバブル デバイス上のファイルやフォルダーにもアクセスできます。 ファイル ピッカーの使い方については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。

> [!NOTE]
> SD カードやその他のリムーバブル デバイスにアクセスする方法について詳しくは、「[SD カードへのアクセス](access-the-sd-card.md)」をご覧ください。

## <a name="locations-that-uwp-apps-can-access"></a>UWP アプリがアクセスできる場所
### <a name="users-downloads-folder"></a>ユーザーの"ダウンロード"フォルダー

ダウンロードされたファイルが保存される既定のフォルダーです。

既定では、ユーザーの Downloads フォルダーにあるファイルやフォルダーについては、そのアプリで作成したものにしかアクセスできません。 ただし、ファイル ピッカー ([**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) または [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881)) を呼び出して、アプリでアクセスするファイルやフォルダーをユーザーが参照して選べるようにすると、ユーザーの Downloads フォルダーにあるファイルやフォルダーにアクセスできるようになります。

- 次のように、ユーザーの Downloads フォルダーにファイルを作成できます。

```cs
using Windows.Storage;
StorageFile newFile = await DownloadsFolder.CreateFileAsync("file.txt");
```

```javascript
Windows.Storage.DownloadsFolder.createFileAsync("file.txt").done(
    function(newFile) {
        // Process file
    }
);
```

```cppwinrt
Windows::Storage::StorageFile newFile{
    co_await Windows::Storage::DownloadsFolder::CreateFileAsync(L"file.txt")
};
// Process file
```

```cpp
using Windows::Storage;
auto createFileTask = create_task(DownloadsFolder::CreateFileAsync(L"file.txt"));
createFileTask.then([](StorageFile^ newFile)
{
    // Process file
});
```

[**DownloadsFolder**](https://msdn.microsoft.com/library/windows/apps/br241632).[**CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh996761) は、同じ名前のファイルが既に Downloads フォルダーにある場合の処理を指定できるようにオーバーロードされます。 これらのメソッドが完了すると、作成されたファイルを表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) が返されます。 上の例では、このファイルの名前は `newFile` です。

- 次のように、ユーザーの Downloads フォルダーにサブフォルダーを作成できます。

```cs
using Windows.Storage;
StorageFolder newFolder = await DownloadsFolder.CreateFolderAsync("New Folder");
```

```javascript
Windows.Storage.DownloadsFolder.createFolderAsync("New Folder").done(
    function(newFolder) {
        // Process folder
    }
);
```

```cppwinrt
Windows::Storage::StorageFolder newFolder{
    co_await Windows::Storage::DownloadsFolder::CreateFolderAsync(L"New Folder")
};
// Process folder
```

```cpp
using Windows::Storage;
auto createFolderTask = create_task(DownloadsFolder::CreateFolderAsync(L"New Folder"));
createFolderTask.then([](StorageFolder^ newFolder)
{
    // Process folder
});
```

[**DownloadsFolder**](https://msdn.microsoft.com/library/windows/apps/br241632).[**CreateFolderAsync**](https://msdn.microsoft.com/library/windows/apps/hh996763) は、同じ名前のサブフォルダーが既に Downloads フォルダーにある場合の処理を指定できるようにオーバーロードされます。 これらのメソッドが完了すると、作成されたサブフォルダーを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) が返されます。 上の例では、このファイルの名前は `newFolder` です。

Downloads フォルダーにファイルやフォルダーを作成する場合は、以降に簡単にアクセスできるように、その項目をアプリの [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) に追加することをお勧めします。

## <a name="accessing-additional-locations"></a>その他の場所へのアクセス

アプリで、既定の場所以外にあるファイルやフォルダーにアクセスするには、アプリ マニフェストで機能を宣言するか、ファイル ピッカーを呼び出してアプリでアクセスするファイルやフォルダーをユーザーが選べるようにします。詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/library/windows/apps/mt270968)」または「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。

[AppExecutionAlias](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap5-appexecutionalias) 拡張機能を宣言したアプリには、コンソール ウィンドウでアプリが起動されたディレクトリおよびその下位レベルのディレクトリに対する、ファイル システムのアクセス許可が与えられます。

次の表に、機能の宣言や関連する [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) API の使用によってアクセスできるその他の場所を示します。

| 場所 | 機能 | Windows.Storage API |
|----------|------------|---------------------|
| ユーザーがアクセス権を持つすべてのファイル。 例: ドキュメント、画像、写真、ダウンロード、デスクトップ、OneDrive などです。 | broadFileSystemAccess<br><br>これは、制限付き機能です。 **設定**では、アクセス > **プライバシー** > **ファイル システム**です。 ユーザーを許可または拒否の**設定**では、いつでも、ため、アプリがこれらの変更に弾力性のあることを行う必要があります。 アプリにはアクセスがない場合は、 [Windows 10 ファイル システムへのアクセスとプライバシー](https://privacy.microsoft.com/en-US/windows-10-file-system-access-and-privacy)の記事へのリンクを提供することで、設定を変更するユーザーに確認することもできます。 注意ユーザーする必要があります、アプリを閉じる、設定を切り替えて、アプリを再起動します。 場合は、アプリの実行中の設定を切り替えること、状態を保存して新しい設定を適用するために、アプリを強制的に終了できるように、プラットフォームはアプリを中断します。 2018 年 4 月更新プログラムでは、アクセス許可の既定値は、上はします。 October 2018 update では、既定値は、オフはします。<br /><br />この機能を宣言するアプリを Microsoft Store に提出する場合、アプリでこの機能が必要となる理由およびこの機能の使用目的に関する追加の説明を提供する必要があります。<br>この機能は、 [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346)名前空間の Api に対して機能します。 アプリでこの機能を有効にする方法の例は、この記事の最後には、「**例**」セクションを参照してください。 | なし |
| ドキュメント | DocumentsLibrary <br><br>注: アプリ マニフェストにファイルの種類の関連付けの宣言を追加して、この場所でアクセスできるファイルの種類を指定する必要があります。 <br><br>この機能は、アプリが次の条件を満たす場合に使います。<br>- 有効な OneDrive URL またはリソース ID を使った、特定の OneDrive コンテンツへのクロスプラットフォーム オフライン アクセスを容易にする<br>、中に自動的にユーザーの OneDrive にファイルを開いて保存オフライン | [KnownFolders.DocumentsLibrary](https://msdn.microsoft.com/library/windows/apps/br227152) |
| ミュージック     | MusicLibrary <br>「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」もご覧ください。 | [KnownFolders.MusicLibrary](https://msdn.microsoft.com/library/windows/apps/br227155) |    
| ピクチャ  | PicturesLibrary<br> 「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」もご覧ください。 | [KnownFolders.PicturesLibrary](https://msdn.microsoft.com/library/windows/apps/br227156) |  
| ビデオ    | VideosLibrary<br>「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」もご覧ください。 | [KnownFolders.VideosLibrary](https://msdn.microsoft.com/library/windows/apps/br227159) |   
| リムーバブル デバイス  | RemovableDevices <br><br>注  アプリ マニフェストにファイルの種類の関連付けの宣言を追加して、この場所でアクセスできるファイルの種類を指定する必要があります。 <br><br>「[SD カードへのアクセス](access-the-sd-card.md)」もご覧ください。 | [KnownFolders.RemovableDevices](https://msdn.microsoft.com/library/windows/apps/br227158) |  
| ホームグループ ライブラリ  | 次の機能が 1 つ以上必要です。 <br>- MusicLibrary <br>- PicturesLibrary <br>- VideosLibrary | [KnownFolders.HomeGroup](https://msdn.microsoft.com/library/windows/apps/br227153) |      
| メディア サーバー デバイス (DLNA) | 次の機能が 1 つ以上必要です。 <br>- MusicLibrary <br>- PicturesLibrary <br>- VideosLibrary | [KnownFolders.MediaServerDevices](https://msdn.microsoft.com/library/windows/apps/br227154) |
| 汎用名前付け規則 (UNC) フォルダー | 次の機能の組み合わせが必要です。 <br><br>ホーム ネットワークと社内ネットワークの機能: <br>- PrivateNetworkClientServer <br><br>インターネットとパブリック ネットワークの 1 つ以上の機能: <br>- InternetClient <br>- InternetClientServer <br><br>ドメイン資格情報の機能 (該当する場合):<br>- EnterpriseAuthentication <br><br>注: アプリ マニフェストにファイルの種類の関連付けの宣言を追加して、この場所でアクセスできるファイルの種類を指定する必要があります。 | フォルダーを取得する場合: <br>[StorageFolder.GetFolderFromPathAsync](https://msdn.microsoft.com/library/windows/apps/br227278) <br><br>ファイルを取得する場合: <br>[StorageFile.GetFileFromPathAsync](https://msdn.microsoft.com/library/windows/apps/br227206) |

**例**

この例では、制限付きの `broadFileSystemAccess` 機能を追加します。 機能を指定するだけでなく、`rescap` 名前空間を追加し、`IgnorableNamespaces` に追加する必要もあります。

```xaml
<Package
  ...
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
  IgnorableNamespaces="uap mp uap5 rescap">
...
<Capabilities>
    <rescap:Capability Name="broadFileSystemAccess" />
</Capabilities>
```

> [!NOTE]
> すべてのアプリ機能の一覧については、「[アプリ機能の宣言](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。
