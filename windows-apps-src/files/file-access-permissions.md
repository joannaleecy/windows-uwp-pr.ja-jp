---
ms.assetid: 3A404CC0-A997-45C8-B2E8-44745539759D
title: ファイル アクセス許可
description: アプリは既定でファイル システムの特定の場所にアクセスできます。 また、ファイル ピッカーを使うか機能を宣言すると、その他の場所にアクセスすることもできます。
ms.date: 12/19/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
- javascript
ms.openlocfilehash: 5c3732927c59cb768ef522a847f79f82994852b7
ms.sourcegitcommit: 1cf708443d132306e6c99027662de8ec99177de6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/20/2018
ms.locfileid: "8980400"
---
# <a name="file-access-permissions"></a><span data-ttu-id="96d88-105">ファイル アクセス許可</span><span class="sxs-lookup"><span data-stu-id="96d88-105">File access permissions</span></span>

<span data-ttu-id="96d88-106">ユニバーサル Windows プラットフォーム (UWP) アプリは、既定でファイル システムの特定の場所にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-106">Universal Windows Platform (UWP) apps can access certain file system locations by default.</span></span> <span data-ttu-id="96d88-107">また、ファイル ピッカーを使うか機能を宣言すると、その他の場所にアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-107">Apps can also access additional locations through the file picker, or by declaring capabilities.</span></span>

## <a name="the-locations-that-all-apps-can-access"></a><span data-ttu-id="96d88-108">すべてのアプリからアクセスできる場所</span><span class="sxs-lookup"><span data-stu-id="96d88-108">The locations that all apps can access</span></span>

<span data-ttu-id="96d88-109">新しいアプリを作成すると、既定でファイル システムの次の場所にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-109">When you create a new app, you can access the following file system locations by default:</span></span>

### <a name="application-install-directory"></a><span data-ttu-id="96d88-110">アプリケーションのインストール ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="96d88-110">Application install directory</span></span>
<span data-ttu-id="96d88-111">ユーザーのシステムで、アプリがインストールされているフォルダーです。</span><span class="sxs-lookup"><span data-stu-id="96d88-111">The folder where your app is installed on the user's system.</span></span>

<span data-ttu-id="96d88-112">ファイルにアクセスする 2 つの主な方法がありますが、フォルダーで、アプリのインストール ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="96d88-112">There are two primary ways to access files and folders in your app's install directory:</span></span>

1. <span data-ttu-id="96d88-113">次のように、アプリのインストール ディレクトリを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) を取得できます。</span><span class="sxs-lookup"><span data-stu-id="96d88-113">You can retrieve a [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) that represents your app's install directory, like this:</span></span>

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

    <span data-ttu-id="96d88-114">[**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) メソッドを使って、ディレクトリ内のファイルとフォルダーにアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="96d88-114">You can then access files and folders in the directory using [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) methods.</span></span> <span data-ttu-id="96d88-115">上の例では、この **StorageFolder** が `installDirectory` 変数に格納されています。</span><span class="sxs-lookup"><span data-stu-id="96d88-115">In the example, this **StorageFolder** is stored in the `installDirectory` variable.</span></span> <span data-ttu-id="96d88-116">アプリ パッケージやインストール ディレクトリの操作について詳しくは、GitHub にある[アプリ パッケージ情報のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Package)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-116">You can learn more about working with your app package and install directory from the [App package information sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Package) on GitHub.</span></span>

2. <span data-ttu-id="96d88-117">次のように、アプリの URI を使って、アプリのインストール ディレクトリからファイルを直接取得できます。</span><span class="sxs-lookup"><span data-stu-id="96d88-117">You can retrieve a file directly from your app's install directory by using an app URI, like this:</span></span>

    ```csharp
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

    <span data-ttu-id="96d88-118">[**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) が完了すると、アプリのインストール ディレクトリにある `file.txt` ファイル (この例では `file`) を表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) が返されます。</span><span class="sxs-lookup"><span data-stu-id="96d88-118">When [**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) completes, it returns a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) that represents the `file.txt` file in the app's install directory (`file` in the example).</span></span>
    
    <span data-ttu-id="96d88-119">URI の "ms-appx:///" プレフィックスは、アプリのインストール ディレクトリを参照します。</span><span class="sxs-lookup"><span data-stu-id="96d88-119">The "ms-appx:///" prefix in the URI refers to the app's install directory.</span></span> <span data-ttu-id="96d88-120">アプリの URI の使用について詳しくは、「[URI を使ってコンテンツを参照する方法](https://msdn.microsoft.com/library/windows/apps/hh781215)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-120">You can learn more about using app URIs in [How to use URIs to reference content](https://msdn.microsoft.com/library/windows/apps/hh781215).</span></span>

<span data-ttu-id="96d88-121">さらに、他の場所とは異なり、[ユニバーサル Windows プラットフォーム (UWP) アプリの Win32 と COM](https://msdn.microsoft.com/library/windows/apps/br205757) や [Microsoft Visual Studio の C/C++ 標準ライブラリ関数](http://msdn.microsoft.com/library/hh875057.aspx)を使ってアプリのインストール ディレクトリ内のファイルにアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-121">In addition, and unlike other locations, you can also access files in your app install directory by using some [Win32 and COM for Universal Windows Platform (UWP) apps](https://msdn.microsoft.com/library/windows/apps/br205757) and some [C/C++ Standard Library functions from Microsoft Visual Studio](http://msdn.microsoft.com/library/hh875057.aspx).</span></span>

<span data-ttu-id="96d88-122">アプリのインストール ディレクトリは読み取り専用です。</span><span class="sxs-lookup"><span data-stu-id="96d88-122">The app's install directory is a read-only location.</span></span> <span data-ttu-id="96d88-123">ファイル ピッカーでは、インストール ディレクトリにアクセスをできなくなります。</span><span class="sxs-lookup"><span data-stu-id="96d88-123">You can't gain access to the install directory through the file picker.</span></span>

### <a name="application-data-locations"></a><span data-ttu-id="96d88-124">アプリケーション データの場所</span><span class="sxs-lookup"><span data-stu-id="96d88-124">Application data locations</span></span>
<span data-ttu-id="96d88-125">アプリがデータを保存できるフォルダーです。</span><span class="sxs-lookup"><span data-stu-id="96d88-125">The folders where your app can store data.</span></span> <span data-ttu-id="96d88-126">これらのフォルダー (ローカル、移動、一時) は、アプリのインストール時に作成されます。</span><span class="sxs-lookup"><span data-stu-id="96d88-126">These folders (local, roaming and temporary) are created when your app is installed.</span></span>

<span data-ttu-id="96d88-127">アプリのデータの場所からファイルとフォルダーにアクセスする 2 つの主要な方法はあります。</span><span class="sxs-lookup"><span data-stu-id="96d88-127">There are two primary ways to access files and folders from your app's data locations:</span></span>

1.  <span data-ttu-id="96d88-128">[**ApplicationData**](https://msdn.microsoft.com/library/windows/apps/br241587) プロパティを使ってアプリ データ フォルダーを取得します。</span><span class="sxs-lookup"><span data-stu-id="96d88-128">Use [**ApplicationData**](https://msdn.microsoft.com/library/windows/apps/br241587) properties to retrieve an app data folder.</span></span>

    <span data-ttu-id="96d88-129">たとえば、次のように、[**ApplicationData**](https://msdn.microsoft.com/library/windows/apps/br241587).[**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) を使って、アプリのローカル フォルダーを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) を取得できます。</span><span class="sxs-lookup"><span data-stu-id="96d88-129">For example, you can use [**ApplicationData**](https://msdn.microsoft.com/library/windows/apps/br241587).[**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) to retrieve a [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) that represents your app's local folder like this:</span></span>
    
    ```csharp
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
    
    <span data-ttu-id="96d88-130">アプリの移動フォルダーまたは一時フォルダーにアクセスする場合は、[**RoamingFolder**](https://msdn.microsoft.com/library/windows/apps/br241623) プロパティまたは [**TemporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="96d88-130">If you want to access your app's roaming or temporary folder, use the [**RoamingFolder**](https://msdn.microsoft.com/library/windows/apps/br241623) or [**TemporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) property instead.</span></span>
    
    <span data-ttu-id="96d88-131">アプリ データの場所を表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) を取得したら、**StorageFolder** メソッドを使って、その場所にあるファイルやフォルダーにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-131">After you retrieve a [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) that represents an app data location, you can access files and folders in that location by using **StorageFolder** methods.</span></span> <span data-ttu-id="96d88-132">上の例では、これらの **StorageFolder** オブジェクトが `localFolder` 変数に格納されています。</span><span class="sxs-lookup"><span data-stu-id="96d88-132">In the example, these **StorageFolder** objects are stored in the `localFolder` variable.</span></span> <span data-ttu-id="96d88-133">アプリ データの場所の使用について詳しくは、[ApplicationData クラス](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata)のページのガイダンスをご覧ください。また、GitHub から[アプリケーション データ サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ApplicationData)をダウンロードしてご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-133">You can learn more about using app data locations from the guidance on the [ApplicationData class](https://docs.microsoft.com/uwp/api/windows.storage.applicationdata) page, and by downloading the [Application data sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ApplicationData) from GitHub.</span></span>

2. <span data-ttu-id="96d88-134">次のように、アプリの URI を使って、アプリのローカル フォルダーから直接ファイルを取得できます。</span><span class="sxs-lookup"><span data-stu-id="96d88-134">You can retrieve a file directly from your app's local folder by using an app URI, like this:</span></span>
    
    ```csharp
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
    
    <span data-ttu-id="96d88-135">[**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) が完了すると、アプリのローカル フォルダーにある `file.txt` ファイル (この例では `file`) を表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) が返されます。</span><span class="sxs-lookup"><span data-stu-id="96d88-135">When [**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) completes, it returns a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) that represents the `file.txt` file in the app's local folder (`file` in the example).</span></span>
    
    <span data-ttu-id="96d88-136">URI の "ms-appdata:///local/" プレフィックスは、アプリのローカル フォルダーを参照します。</span><span class="sxs-lookup"><span data-stu-id="96d88-136">The "ms-appdata:///local/" prefix in the URI refers to the app's local folder.</span></span> <span data-ttu-id="96d88-137">アプリの移動フォルダーまたは一時フォルダーにあるファイルにアクセスするには、"ms-appdata:///roaming/" または "ms-appdata:///temporary/" を使います。</span><span class="sxs-lookup"><span data-stu-id="96d88-137">To access files in the app's roaming or temporary folders use "ms-appdata:///roaming/" or "ms-appdata:///temporary/" instead.</span></span> <span data-ttu-id="96d88-138">アプリの URI の使用について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/hh781229)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-138">You can learn more about using app URIs in [How to load file resources](https://msdn.microsoft.com/library/windows/apps/hh781229).</span></span>

<span data-ttu-id="96d88-139">さらに、他の場所とは異なり、[UWP アプリの Win32 と COM](https://msdn.microsoft.com/library/windows/apps/br205757) や Visual Studio の C/C++ 標準ライブラリ関数を使ってアプリ データの場所にあるファイルにアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-139">In addition, and unlike other locations, you can also access files in your app data locations by using some [Win32 and COM for UWP apps](https://msdn.microsoft.com/library/windows/apps/br205757) and some C/C++ Standard Library functions from Visual Studio.</span></span>

<span data-ttu-id="96d88-140">ファイル ピッカーでローカル、移動、または一時フォルダーにアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="96d88-140">You can't access the local, roaming, or temporary folders through the file picker.</span></span>

### <a name="removable-devices"></a><span data-ttu-id="96d88-141">リムーバブル デバイス</span><span class="sxs-lookup"><span data-stu-id="96d88-141">Removable devices</span></span>
<span data-ttu-id="96d88-142">さらに、接続されているデバイス上の一部のファイルに既定でアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-142">Additionally, your app can access some of the files on connected devices by default.</span></span> <span data-ttu-id="96d88-143">これは、[自動再生拡張機能](https://msdn.microsoft.com/library/windows/apps/xaml/hh464906.aspx#autoplay)を使って、ユーザーがデバイス (カメラや USB サム ドライブなど) をシステムに接続したときに自動的に起動されるようにする場合に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="96d88-143">This is an option if your app uses the [AutoPlay extension](https://msdn.microsoft.com/library/windows/apps/xaml/hh464906.aspx#autoplay) to launch automatically when users connect a device, like a camera or USB thumb drive, to their system.</span></span> <span data-ttu-id="96d88-144">アプリでアクセスできるファイルの種類は、アプリ マニフェストのファイルの種類の関連付けの宣言で指定されたものだけに制限されます。</span><span class="sxs-lookup"><span data-stu-id="96d88-144">The files your app can access are limited to specific file types that are specified via File Type Association declarations in your app manifest.</span></span>

<span data-ttu-id="96d88-145">もちろん、ファイル ピッカー ([**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) と [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881)) を呼び出して、アプリでアクセスするファイルやフォルダーをユーザーが選べるようにすると、リムーバブル デバイス上のファイルやフォルダーにもアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-145">Of course, you can also gain access to files and folders on a removable device by calling the file picker (using [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) and [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881)) and letting the user pick files and folders for your app to access.</span></span> <span data-ttu-id="96d88-146">ファイル ピッカーの使い方については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-146">Learn how to use the file picker in [Open files and folders with a picker](quickstart-using-file-and-folder-pickers.md).</span></span>

> [!NOTE]
> <span data-ttu-id="96d88-147">SD カードやその他のリムーバブル デバイスにアクセスする方法について詳しくは、「[SD カードへのアクセス](access-the-sd-card.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-147">For more info about accessing an SD card or other removable devices, see [Access the SD card](access-the-sd-card.md).</span></span>

## <a name="locations-that-uwp-apps-can-access"></a><span data-ttu-id="96d88-148">UWP アプリがアクセスできる場所</span><span class="sxs-lookup"><span data-stu-id="96d88-148">Locations that UWP apps can access</span></span>
### <a name="users-downloads-folder"></a><span data-ttu-id="96d88-149">ユーザーの"ダウンロード"フォルダー</span><span class="sxs-lookup"><span data-stu-id="96d88-149">User's Downloads folder</span></span>

<span data-ttu-id="96d88-150">ダウンロードされたファイルが保存される既定のフォルダーです。</span><span class="sxs-lookup"><span data-stu-id="96d88-150">The folder where downloaded files are saved by default.</span></span>

<span data-ttu-id="96d88-151">既定では、ユーザーの Downloads フォルダーにあるファイルやフォルダーについては、そのアプリで作成したものにしかアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="96d88-151">By default, your app can only access files and folders in the user's Downloads folder that your app created.</span></span> <span data-ttu-id="96d88-152">ただし、ファイル ピッカー ([**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) または [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881)) を呼び出して、アプリでアクセスするファイルやフォルダーをユーザーが参照して選べるようにすると、ユーザーの Downloads フォルダーにあるファイルやフォルダーにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="96d88-152">However, you can gain access to files and folders in the user's Downloads folder by calling a file picker ([**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) or [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881)) so that users can navigate and pick files or folders for your app to access.</span></span>

- <span data-ttu-id="96d88-153">次のように、ユーザーの Downloads フォルダーにファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="96d88-153">You can create a file in the user's Downloads folder like this:</span></span>

    ```csharp
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

    <span data-ttu-id="96d88-154">[**DownloadsFolder**](https://msdn.microsoft.com/library/windows/apps/br241632).[**CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh996761) は、同じ名前のファイルが既に Downloads フォルダーにある場合の処理を指定できるようにオーバーロードされます。</span><span class="sxs-lookup"><span data-stu-id="96d88-154">[**DownloadsFolder**](https://msdn.microsoft.com/library/windows/apps/br241632).[**CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh996761) is overloaded so that you can specify what the system should do if there is already an existing file in the Downloads folder that has the same name.</span></span> <span data-ttu-id="96d88-155">これらのメソッドが完了すると、作成されたファイルを表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) が返されます。</span><span class="sxs-lookup"><span data-stu-id="96d88-155">When these methods complete, they return a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) that represents the file that was created.</span></span> <span data-ttu-id="96d88-156">上の例では、このファイルの名前は `newFile` です。</span><span class="sxs-lookup"><span data-stu-id="96d88-156">This file is called `newFile` in the example.</span></span>

- <span data-ttu-id="96d88-157">次のように、ユーザーの Downloads フォルダーにサブフォルダーを作成できます。</span><span class="sxs-lookup"><span data-stu-id="96d88-157">You can create a subfolder in the user's Downloads folder like this:</span></span>

    ```csharp
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

    <span data-ttu-id="96d88-158">[**DownloadsFolder**](https://msdn.microsoft.com/library/windows/apps/br241632).[**CreateFolderAsync**](https://msdn.microsoft.com/library/windows/apps/hh996763) は、同じ名前のサブフォルダーが既に Downloads フォルダーにある場合の処理を指定できるようにオーバーロードされます。</span><span class="sxs-lookup"><span data-stu-id="96d88-158">[**DownloadsFolder**](https://msdn.microsoft.com/library/windows/apps/br241632).[**CreateFolderAsync**](https://msdn.microsoft.com/library/windows/apps/hh996763) is overloaded so that you can specify what the system should do if there is already an existing subfolder in the Downloads folder that has the same name.</span></span> <span data-ttu-id="96d88-159">これらのメソッドが完了すると、作成されたサブフォルダーを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) が返されます。</span><span class="sxs-lookup"><span data-stu-id="96d88-159">When these methods complete, they return a [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) that represents the subfolder that was created.</span></span> <span data-ttu-id="96d88-160">上の例では、このファイルの名前は `newFolder` です。</span><span class="sxs-lookup"><span data-stu-id="96d88-160">This file is called `newFolder` in the example.</span></span>

<span data-ttu-id="96d88-161">Downloads フォルダーにファイルやフォルダーを作成する場合は、以降に簡単にアクセスできるように、その項目をアプリの [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) に追加することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="96d88-161">If you create a file or folder in the Downloads folder, we recommend that you add that item to your app's [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) so that your app can readily access that item in the future.</span></span>

## <a name="accessing-additional-locations"></a><span data-ttu-id="96d88-162">その他の場所へのアクセス</span><span class="sxs-lookup"><span data-stu-id="96d88-162">Accessing additional locations</span></span>

<span data-ttu-id="96d88-163">アプリで、既定の場所以外にあるファイルやフォルダーにアクセスするには、アプリ マニフェストで機能を宣言するか、ファイル ピッカーを呼び出してアプリでアクセスするファイルやフォルダーをユーザーが選べるようにします。詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/library/windows/apps/mt270968)」または「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-163">In addition to the default locations, an app can access additional files and folders by declaring capabilities in the app manifest (see [App capability declarations](https://msdn.microsoft.com/library/windows/apps/mt270968)), or by calling a file picker to let the user pick files and folders for the app to access (see [Open files and folders with a picker](quickstart-using-file-and-folder-pickers.md)).</span></span>

<span data-ttu-id="96d88-164">[AppExecutionAlias](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap5-appexecutionalias) 拡張機能を宣言したアプリには、コンソール ウィンドウでアプリが起動されたディレクトリおよびその下位レベルのディレクトリに対する、ファイル システムのアクセス許可が与えられます。</span><span class="sxs-lookup"><span data-stu-id="96d88-164">App's that that declare the [AppExecutionAlias](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap5-appexecutionalias) extension, have file-system permissions from the directory that they are launched from in the console window, and downwards.</span></span>

<span data-ttu-id="96d88-165">次の表に、機能の宣言や関連する [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) API の使用によってアクセスできるその他の場所を示します。</span><span class="sxs-lookup"><span data-stu-id="96d88-165">The following table lists additional locations that you can access by declaring a capability (or capabilities) and using the associated [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) API:</span></span>

| <span data-ttu-id="96d88-166">場所</span><span class="sxs-lookup"><span data-stu-id="96d88-166">Location</span></span> | <span data-ttu-id="96d88-167">機能</span><span class="sxs-lookup"><span data-stu-id="96d88-167">Capability</span></span> | <span data-ttu-id="96d88-168">Windows.Storage API</span><span class="sxs-lookup"><span data-stu-id="96d88-168">Windows.Storage API</span></span> |
|----------|------------|---------------------|
| <span data-ttu-id="96d88-169">ユーザーがアクセス権を持つすべてのファイル。</span><span class="sxs-lookup"><span data-stu-id="96d88-169">All files that the user has access to.</span></span> <span data-ttu-id="96d88-170">例: ドキュメント、画像、写真、ダウンロード、デスクトップ、OneDrive などです。</span><span class="sxs-lookup"><span data-stu-id="96d88-170">For example: documents, pictures, photos, downloads, desktop, OneDrive, etc.</span></span> | <span data-ttu-id="96d88-171">broadFileSystemAccess</span><span class="sxs-lookup"><span data-stu-id="96d88-171">broadFileSystemAccess</span></span><br><br><span data-ttu-id="96d88-172">これは、制限付き機能です。</span><span class="sxs-lookup"><span data-stu-id="96d88-172">This is a restricted capability.</span></span> <span data-ttu-id="96d88-173">**設定**では、アクセス > **プライバシー** > **ファイル システム**です。</span><span class="sxs-lookup"><span data-stu-id="96d88-173">Access is configurable in **Settings** > **Privacy** > **File system**.</span></span> <span data-ttu-id="96d88-174">ユーザーを許可または拒否の**設定**では、いつでも、ため、アプリがこれらの変更に弾力性のあることを行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="96d88-174">Because users can grant or deny the permission any time in **Settings**, you should ensure that your app is resilient to those changes.</span></span> <span data-ttu-id="96d88-175">アプリにはアクセスがない場合は、 [Windows 10 ファイル システムへのアクセスとプライバシー](https://privacy.microsoft.com/en-US/windows-10-file-system-access-and-privacy)の記事へのリンクを提供することで、設定を変更するユーザーに確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="96d88-175">If you find that your app does not have access, you may choose to prompt the user to change the setting by providing a link to the [Windows 10 file system access and privacy](https://privacy.microsoft.com/en-US/windows-10-file-system-access-and-privacy) article.</span></span> <span data-ttu-id="96d88-176">注意ユーザーする必要があります、アプリを閉じる、設定を切り替えて、アプリを再起動します。</span><span class="sxs-lookup"><span data-stu-id="96d88-176">Note that the user must close the app, toggle the setting, and restart the app.</span></span> <span data-ttu-id="96d88-177">場合は、アプリの実行中の設定を切り替えること、状態を保存して新しい設定を適用するために、アプリを強制的に終了できるように、プラットフォームはアプリを中断します。</span><span class="sxs-lookup"><span data-stu-id="96d88-177">If they toggle the setting while the app is running, the platform will suspend your app so that you can save the state, then forcibly terminate the app in order to apply the new setting.</span></span> <span data-ttu-id="96d88-178">2018 年 4 月更新プログラムでは、アクセス許可の既定値は、上はします。</span><span class="sxs-lookup"><span data-stu-id="96d88-178">In the April 2018 update, the default for the permission is On.</span></span> <span data-ttu-id="96d88-179">October 2018 update では、既定値は、オフはします。</span><span class="sxs-lookup"><span data-stu-id="96d88-179">In the October 2018 update, the default is Off.</span></span><br /><br /><span data-ttu-id="96d88-180">この機能を宣言するアプリを Microsoft Store に提出する場合、アプリでこの機能が必要となる理由およびこの機能の使用目的に関する追加の説明を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96d88-180">If you submit an app to the Store that declares this capability, you will need to supply additional descriptions of why your app needs this capability, and how it intends to use it.</span></span><br><span data-ttu-id="96d88-181">この機能は、 [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346)名前空間の Api に対して機能します。</span><span class="sxs-lookup"><span data-stu-id="96d88-181">This capability works for APIs in the [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) namespace.</span></span> <span data-ttu-id="96d88-182">アプリでこの機能を有効にする方法の例は、この記事の最後には、「**例**」セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="96d88-182">See the **Example** section at the end of this article for an example of how to enable this capability in your app.</span></span> | <span data-ttu-id="96d88-183">なし</span><span class="sxs-lookup"><span data-stu-id="96d88-183">n/a</span></span> |
| <span data-ttu-id="96d88-184">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="96d88-184">Documents</span></span> | <span data-ttu-id="96d88-185">DocumentsLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-185">DocumentsLibrary</span></span> <br><br><span data-ttu-id="96d88-186">注: アプリ マニフェストにファイルの種類の関連付けの宣言を追加して、この場所でアクセスできるファイルの種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96d88-186">Note: You must add File Type Associations to your app manifest that declare specific file types that your app can access in this location.</span></span> <br><br><span data-ttu-id="96d88-187">この機能は、アプリが次の条件を満たす場合に使います。</span><span class="sxs-lookup"><span data-stu-id="96d88-187">Use this capability if your app:</span></span><br><span data-ttu-id="96d88-188">- 有効な OneDrive URL またはリソース ID を使った、特定の OneDrive コンテンツへのクロスプラットフォーム オフライン アクセスを容易にする</span><span class="sxs-lookup"><span data-stu-id="96d88-188">- Facilitates cross-platform offline access to specific OneDrive content using valid OneDrive URLs or Resource IDs</span></span><br><span data-ttu-id="96d88-189">、中に自動的にユーザーの OneDrive にファイルを開いて保存オフライン</span><span class="sxs-lookup"><span data-stu-id="96d88-189">- Saves open files to the user's OneDrive automatically while offline</span></span> | [<span data-ttu-id="96d88-190">KnownFolders.DocumentsLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-190">KnownFolders.DocumentsLibrary</span></span>](https://msdn.microsoft.com/library/windows/apps/br227152) |
| <span data-ttu-id="96d88-191">ミュージック</span><span class="sxs-lookup"><span data-stu-id="96d88-191">Music</span></span>     | <span data-ttu-id="96d88-192">MusicLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-192">MusicLibrary</span></span> <br><span data-ttu-id="96d88-193">「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-193">Also see [Files and folders in the Music, Pictures, and Videos libraries](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md).</span></span> | [<span data-ttu-id="96d88-194">KnownFolders.MusicLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-194">KnownFolders.MusicLibrary</span></span>](https://msdn.microsoft.com/library/windows/apps/br227155) |    
| <span data-ttu-id="96d88-195">ピクチャ</span><span class="sxs-lookup"><span data-stu-id="96d88-195">Pictures</span></span>  | <span data-ttu-id="96d88-196">PicturesLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-196">PicturesLibrary</span></span><br> <span data-ttu-id="96d88-197">「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-197">Also see [Files and folders in the Music, Pictures, and Videos libraries](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md).</span></span> | [<span data-ttu-id="96d88-198">KnownFolders.PicturesLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-198">KnownFolders.PicturesLibrary</span></span>](https://msdn.microsoft.com/library/windows/apps/br227156) |  
| <span data-ttu-id="96d88-199">ビデオ</span><span class="sxs-lookup"><span data-stu-id="96d88-199">Videos</span></span>    | <span data-ttu-id="96d88-200">VideosLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-200">VideosLibrary</span></span><br><span data-ttu-id="96d88-201">「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-201">Also see [Files and folders in the Music, Pictures, and Videos libraries](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md).</span></span> | [<span data-ttu-id="96d88-202">KnownFolders.VideosLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-202">KnownFolders.VideosLibrary</span></span>](https://msdn.microsoft.com/library/windows/apps/br227159) |   
| <span data-ttu-id="96d88-203">リムーバブル デバイス</span><span class="sxs-lookup"><span data-stu-id="96d88-203">Removable devices</span></span>  | <span data-ttu-id="96d88-204">RemovableDevices</span><span class="sxs-lookup"><span data-stu-id="96d88-204">RemovableDevices</span></span> <br><br><span data-ttu-id="96d88-205">注  アプリ マニフェストにファイルの種類の関連付けの宣言を追加して、この場所でアクセスできるファイルの種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96d88-205">Note  You must add File Type Associations to your app manifest that declare specific file types that your app can access in this location.</span></span> <br><br><span data-ttu-id="96d88-206">「[SD カードへのアクセス](access-the-sd-card.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-206">Also see [Access the SD card](access-the-sd-card.md).</span></span> | [<span data-ttu-id="96d88-207">KnownFolders.RemovableDevices</span><span class="sxs-lookup"><span data-stu-id="96d88-207">KnownFolders.RemovableDevices</span></span>](https://msdn.microsoft.com/library/windows/apps/br227158) |  
| <span data-ttu-id="96d88-208">ホームグループ ライブラリ</span><span class="sxs-lookup"><span data-stu-id="96d88-208">Homegroup libraries</span></span>  | <span data-ttu-id="96d88-209">次の機能が 1 つ以上必要です。</span><span class="sxs-lookup"><span data-stu-id="96d88-209">At least one of the following capabilities is needed.</span></span> <br><span data-ttu-id="96d88-210">- MusicLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-210">- MusicLibrary</span></span> <br><span data-ttu-id="96d88-211">- PicturesLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-211">- PicturesLibrary</span></span> <br><span data-ttu-id="96d88-212">- VideosLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-212">- VideosLibrary</span></span> | [<span data-ttu-id="96d88-213">KnownFolders.HomeGroup</span><span class="sxs-lookup"><span data-stu-id="96d88-213">KnownFolders.HomeGroup</span></span>](https://msdn.microsoft.com/library/windows/apps/br227153) |      
| <span data-ttu-id="96d88-214">メディア サーバー デバイス (DLNA)</span><span class="sxs-lookup"><span data-stu-id="96d88-214">Media server devices (DLNA)</span></span> | <span data-ttu-id="96d88-215">次の機能が 1 つ以上必要です。</span><span class="sxs-lookup"><span data-stu-id="96d88-215">At least one of the following capabilities is needed.</span></span> <br><span data-ttu-id="96d88-216">- MusicLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-216">- MusicLibrary</span></span> <br><span data-ttu-id="96d88-217">- PicturesLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-217">- PicturesLibrary</span></span> <br><span data-ttu-id="96d88-218">- VideosLibrary</span><span class="sxs-lookup"><span data-stu-id="96d88-218">- VideosLibrary</span></span> | [<span data-ttu-id="96d88-219">KnownFolders.MediaServerDevices</span><span class="sxs-lookup"><span data-stu-id="96d88-219">KnownFolders.MediaServerDevices</span></span>](https://msdn.microsoft.com/library/windows/apps/br227154) |
| <span data-ttu-id="96d88-220">汎用名前付け規則 (UNC) フォルダー</span><span class="sxs-lookup"><span data-stu-id="96d88-220">Universal Naming Convention (UNC) folders</span></span> | <span data-ttu-id="96d88-221">次の機能の組み合わせが必要です。</span><span class="sxs-lookup"><span data-stu-id="96d88-221">A combination of the following capabilities is needed.</span></span> <br><br><span data-ttu-id="96d88-222">ホーム ネットワークと社内ネットワークの機能:</span><span class="sxs-lookup"><span data-stu-id="96d88-222">The home and work networks capability:</span></span> <br><span data-ttu-id="96d88-223">- PrivateNetworkClientServer</span><span class="sxs-lookup"><span data-stu-id="96d88-223">- PrivateNetworkClientServer</span></span> <br><br><span data-ttu-id="96d88-224">インターネットとパブリック ネットワークの 1 つ以上の機能:</span><span class="sxs-lookup"><span data-stu-id="96d88-224">And at least one internet and public networks capability:</span></span> <br><span data-ttu-id="96d88-225">- InternetClient</span><span class="sxs-lookup"><span data-stu-id="96d88-225">- InternetClient</span></span> <br><span data-ttu-id="96d88-226">- InternetClientServer</span><span class="sxs-lookup"><span data-stu-id="96d88-226">- InternetClientServer</span></span> <br><br><span data-ttu-id="96d88-227">ドメイン資格情報の機能 (該当する場合):</span><span class="sxs-lookup"><span data-stu-id="96d88-227">And, if applicable, the domain credentials capability:</span></span><br><span data-ttu-id="96d88-228">- EnterpriseAuthentication</span><span class="sxs-lookup"><span data-stu-id="96d88-228">- EnterpriseAuthentication</span></span> <br><br><span data-ttu-id="96d88-229">注: アプリ マニフェストにファイルの種類の関連付けの宣言を追加して、この場所でアクセスできるファイルの種類を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96d88-229">Note: You must add File Type Associations to your app manifest that declare specific file types that your app can access in this location.</span></span> | <span data-ttu-id="96d88-230">フォルダーを取得する場合:</span><span class="sxs-lookup"><span data-stu-id="96d88-230">Retrieve a folder using:</span></span> <br>[<span data-ttu-id="96d88-231">StorageFolder.GetFolderFromPathAsync</span><span class="sxs-lookup"><span data-stu-id="96d88-231">StorageFolder.GetFolderFromPathAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/br227278) <br><br><span data-ttu-id="96d88-232">ファイルを取得する場合:</span><span class="sxs-lookup"><span data-stu-id="96d88-232">Retrieve a file using:</span></span> <br>[<span data-ttu-id="96d88-233">StorageFile.GetFileFromPathAsync</span><span class="sxs-lookup"><span data-stu-id="96d88-233">StorageFile.GetFileFromPathAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/br227206) |

**<span data-ttu-id="96d88-234">例</span><span class="sxs-lookup"><span data-stu-id="96d88-234">Example</span></span>**

<span data-ttu-id="96d88-235">この例では、制限付きの `broadFileSystemAccess` 機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="96d88-235">This example adds the restricted `broadFileSystemAccess` capability.</span></span> <span data-ttu-id="96d88-236">機能を指定するだけでなく、`rescap` 名前空間を追加し、`IgnorableNamespaces` に追加する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="96d88-236">In addition to specifying the capability, the `rescap` namespace must be added, and is also added to `IgnorableNamespaces`:</span></span>

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
> <span data-ttu-id="96d88-237">すべてのアプリ機能の一覧については、「[アプリ機能の宣言](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96d88-237">For a complete list of app capabilities, see [App capability declarations](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations).</span></span>
