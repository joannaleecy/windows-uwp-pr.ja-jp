---
ms.assetid: CAC6A7C7-3348-4EC4-8327-D47EB6E0C238
title: SD カードへのアクセス
description: オプションの microSD カードに重要度の低いデータを保存したり、これらのデータにアクセスしたりすることができます (特に内部ストレージに制限がある低コストのモバイル デバイスの場合)。
ms.date: 03/08/2017
ms.topic: article
keywords: Windows 10, UWP, SD カード, ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 9ef97ed489f2dc35aece83821633a583dfba77e2
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8476341"
---
# <a name="access-the-sd-card"></a><span data-ttu-id="a23c2-104">SD カードへのアクセス</span><span class="sxs-lookup"><span data-stu-id="a23c2-104">Access the SD card</span></span>



<span data-ttu-id="a23c2-105">オプションの microSD カードに重要度の低いデータを保存したり、これらのデータにアクセスしたりすることができます (特に内部ストレージに制限があり、microSD カード用のスロットがある低コストのモバイル デバイスの場合)。</span><span class="sxs-lookup"><span data-stu-id="a23c2-105">You can store and access non-essential data on an optional microSD card, especially on low-cost mobile devices that have limited internal storage and have a slot for an SD card.</span></span>

<span data-ttu-id="a23c2-106">ほとんどの場合、アプリで SD カード上のファイルの保存とアクセスを行うには、アプリ マニフェスト ファイルで **removableStorage** 機能を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-106">In most cases, you have to specify the **removableStorage** capability in the app manifest file before your app can store and access files on the SD card.</span></span> <span data-ttu-id="a23c2-107">通常、アプリから保存したりアクセスしたりするファイルの種類を処理対象として登録することも必要です。</span><span class="sxs-lookup"><span data-stu-id="a23c2-107">Typically you also have to register to handle the type of files that your app stores and accesses.</span></span>

<span data-ttu-id="a23c2-108">次の方法を使って、オプションの SD カードに対してファイルの保存とアクセスを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-108">You can store and access files on the optional SD card by using the following methods:</span></span>
- <span data-ttu-id="a23c2-109">ファイル ピッカー</span><span class="sxs-lookup"><span data-stu-id="a23c2-109">File pickers.</span></span>
- <span data-ttu-id="a23c2-110">[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) API</span><span class="sxs-lookup"><span data-stu-id="a23c2-110">The [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) APIs.</span></span>

## <a name="what-you-can-and-cant-access-on-the-sd-card"></a><span data-ttu-id="a23c2-111">SD カードでアクセスできるデータとアクセスできないデータ</span><span class="sxs-lookup"><span data-stu-id="a23c2-111">What you can and can't access on the SD card</span></span>

### <a name="what-you-can-access"></a><span data-ttu-id="a23c2-112">アクセスできるデータ</span><span class="sxs-lookup"><span data-stu-id="a23c2-112">What you can access</span></span>

- <span data-ttu-id="a23c2-113">アプリでファイルの読み取りと書き込みを実行するには、そのファイルの種類が処理対象となるように、アプリでアプリ マニフェスト ファイルに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-113">Your app can only read and write files of file types that the app has registered to handle in the app manifest file.</span></span>
- <span data-ttu-id="a23c2-114">アプリでは、フォルダーの作成と管理も実行できます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-114">Your app can also create and manage folders.</span></span>

### <a name="what-you-cant-access"></a><span data-ttu-id="a23c2-115">アクセスできないデータ</span><span class="sxs-lookup"><span data-stu-id="a23c2-115">What you can't access</span></span>

- <span data-ttu-id="a23c2-116">アプリでは、システム フォルダーとそのフォルダー内のファイルを参照したり、アクセスしたりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="a23c2-116">Your app can't see or access system folders and the files that they contain.</span></span>
- <span data-ttu-id="a23c2-117">隠し属性でマークされたファイルを参照することはできません。</span><span class="sxs-lookup"><span data-stu-id="a23c2-117">Your app can't see files that are marked with the Hidden attribute.</span></span> <span data-ttu-id="a23c2-118">通常、隠し属性は、データを誤って削除するというリスクを減らすために使われます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-118">The Hidden attribute is typically used to reduce the risk of deleting data accidentally.</span></span>
- <span data-ttu-id="a23c2-119">[**KnownFolders.DocumentsLibrary**](https://msdn.microsoft.com/library/windows/apps/br227152) を使ってドキュメント ライブラリを参照したり、ドキュメント ライブラリにアクセスしたりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="a23c2-119">Your app can't see or access the Documents library by using [**KnownFolders.DocumentsLibrary**](https://msdn.microsoft.com/library/windows/apps/br227152).</span></span> <span data-ttu-id="a23c2-120">ただしファイル システムを走査することによって、SD カード上のドキュメント ライブラリにアクセスすることはできます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-120">However you can access the Documents library on the SD card by traversing the file system.</span></span>

## <a name="security-and-privacy-considerations"></a><span data-ttu-id="a23c2-121">セキュリティとプライバシーに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="a23c2-121">Security and privacy considerations</span></span>

<span data-ttu-id="a23c2-122">アプリが SD カードのグローバルな場所にファイルを保存する場合、それらのファイルは暗号化されないため、通常は他のアプリからアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-122">When an app saves files in a global location on the SD card, those files are not encrypted so they are typically accessible to other apps.</span></span>

- <span data-ttu-id="a23c2-123">SD カードがデバイスに挿入されている間、SD カード上のファイルは、同じファイルの種類を処理対象として登録している他のアプリからアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-123">While the SD card is in the device, your files are accessible to other apps that have registered to handle the same file type.</span></span>
- <span data-ttu-id="a23c2-124">SD カードをデバイスから取り外し、PC で開くと、ファイルはエクスプローラーに表示されるため、他のアプリからアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-124">When the SD card is removed from the device and opened from a PC, your files are visible in File Explorer and accessible to other apps.</span></span>

<span data-ttu-id="a23c2-125">アプリを SD カードにインストールし、ファイルを SD カードの [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) に保存する場合、それらのファイルは暗号化されるため、他のアプリからアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="a23c2-125">When an app installed on the SD card saves files in its [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621), however, those files are encrypted and are not accessible to other apps.</span></span>

## <a name="requirements-for-accessing-files-on-the-sd-card"></a><span data-ttu-id="a23c2-126">SD カード上のファイルへアクセスするための要件</span><span class="sxs-lookup"><span data-stu-id="a23c2-126">Requirements for accessing files on the SD card</span></span>

<span data-ttu-id="a23c2-127">SD カードのファイルにアクセスするには通常、次のことを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-127">To access files on the SD card, typically you have to specify the following things.</span></span>

1.  <span data-ttu-id="a23c2-128">アプリ マニフェスト ファイルで **removableStorage** 機能を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-128">You have to specify the **removableStorage** capability in the app manifest file.</span></span>
2.  <span data-ttu-id="a23c2-129">また、アクセスするメディアの種類に関連付けられたファイル拡張子を処理対象として登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-129">You also have to register to handle the file extensions associated with the type of media that you want to access.</span></span>

<span data-ttu-id="a23c2-130">**KnownFolders.MusicLibrary** などの既知のフォルダーを参照せずに SD カード上のメディア ファイルにアクセスしたり、メディア ライブラリ フォルダーの外部に格納されているメディア ファイルにアクセスしたりするに場合にも、上記の方法を使います。</span><span class="sxs-lookup"><span data-stu-id="a23c2-130">Use the preceding method also to access media files on the SD card without referencing a known folder like **KnownFolders.MusicLibrary**, or to access media files that are stored outside of the media library folders.</span></span>

<span data-ttu-id="a23c2-131">ミュージック、写真、ビデオなどのメディア ライブラリに格納されているメディア ファイルに既知のフォルダーを使ってアクセスする場合は、関連付けられている機能 (**musicLibrary**、**picturesLibrary**、**videoLibrary**) をアプリ マニフェスト ファイルで指定するだけで十分です。</span><span class="sxs-lookup"><span data-stu-id="a23c2-131">To access media files stored in the media libraries—Music, Photos, or Videos—by using known folders, you only have to specify the associated capability in the app manifest file—**musicLibrary**, **picturesLibrary**, or **videoLibrary**.</span></span> <span data-ttu-id="a23c2-132">**removableStorage** 機能を指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a23c2-132">You do not have to specify the **removableStorage** capability.</span></span> <span data-ttu-id="a23c2-133">詳しくは、「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a23c2-133">For more info, see [Files and folders in the Music, Pictures, and Videos libraries](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md).</span></span>

## <a name="accessing-files-on-the-sd-card"></a><span data-ttu-id="a23c2-134">SD カード上のファイルへのアクセス</span><span class="sxs-lookup"><span data-stu-id="a23c2-134">Accessing files on the SD card</span></span>

### <a name="getting-a-reference-to-the-sd-card"></a><span data-ttu-id="a23c2-135">SD カードへの参照の取得</span><span class="sxs-lookup"><span data-stu-id="a23c2-135">Getting a reference to the SD card</span></span>

<span data-ttu-id="a23c2-136">[**KnownFolders.RemovableDevices**](https://msdn.microsoft.com/library/windows/apps/br227158) フォルダーは、デバイスに現在接続されている一連のリムーバブル デバイスに対する論理ルートである [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) です。</span><span class="sxs-lookup"><span data-stu-id="a23c2-136">The [**KnownFolders.RemovableDevices**](https://msdn.microsoft.com/library/windows/apps/br227158) folder is the logical root [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) for the set of removable devices currently connected to the device.</span></span> <span data-ttu-id="a23c2-137">SD カードが取り付けられている場合は、**KnownFolders.RemovableDevices** フォルダーの下にある、最初の (唯一の) **StorageFolder** が SD カードを表します。</span><span class="sxs-lookup"><span data-stu-id="a23c2-137">If an SD card is present, the first (and only) **StorageFolder** underneath the **KnownFolders.RemovableDevices** folder represents the SD card.</span></span>

<span data-ttu-id="a23c2-138">次のようなコードを使って、SD カードが存在するかどうかを判断し、SD カードへの参照を [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) として取得します。</span><span class="sxs-lookup"><span data-stu-id="a23c2-138">Use code like the following to determine whether an SD card is present and to get a reference to it as a [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230).</span></span>

```csharp
using Windows.Storage;

// Get the logical root folder for all external storage devices.
StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;

// Get the first child folder, which represents the SD card.
StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();

if (sdCard != null)
{
    // An SD card is present and the sdCard variable now contains a reference to it.
}
else
{
    // No SD card is present.
}
```

> [!NOTE]
> <span data-ttu-id="a23c2-139">SDカード リーダーが内蔵のリーダー (ノート PC や PC のスロットなど) である場合、KnownFolders.RemovableDevices によってアクセスできない場合があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-139">If your SD card reader is an embedded reader (e.g., a slot in the laptop or PC itself), it may not be accessible through KnownFolders.RemovableDevices.</span></span>

### <a name="querying-the-contents-of-the-sd-card"></a><span data-ttu-id="a23c2-140">SD カードのコンテンツの照会</span><span class="sxs-lookup"><span data-stu-id="a23c2-140">Querying the contents of the SD card</span></span>

<span data-ttu-id="a23c2-141">SD カードには、既知のフォルダーとして認識されないさまざまなフォルダーやファイルを含めることができますが、[**KnownFolders**](https://msdn.microsoft.com/library/windows/apps/br227151) の場所の情報を使って照会することはできません。</span><span class="sxs-lookup"><span data-stu-id="a23c2-141">The SD card can contain many folders and files that aren't recognized as known folders and can't be queried by using a location from [**KnownFolders**](https://msdn.microsoft.com/library/windows/apps/br227151).</span></span> <span data-ttu-id="a23c2-142">ファイルを検索するには、アプリでファイル システムを再帰的に走査して、SD カードのコンテンツを列挙する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-142">To find files, your app has to enumerate the contents of the card by traversing the file system recursively.</span></span> <span data-ttu-id="a23c2-143">SD カードのコンテンツを効率的に取得するには、[**GetFilesAsync (CommonFileQuery.DefaultQuery)**](https://msdn.microsoft.com/library/windows/apps/br227274) と [**GetFoldersAsync (CommonFolderQuery.DefaultQuery)**](https://msdn.microsoft.com/library/windows/apps/br227281) を使います。</span><span class="sxs-lookup"><span data-stu-id="a23c2-143">Use [**GetFilesAsync (CommonFileQuery.DefaultQuery)**](https://msdn.microsoft.com/library/windows/apps/br227274) and [**GetFoldersAsync (CommonFolderQuery.DefaultQuery)**](https://msdn.microsoft.com/library/windows/apps/br227281) to get the contents of the SD card efficiently.</span></span>

<span data-ttu-id="a23c2-144">SD カードを走査するにはバックグラウンド スレッドを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a23c2-144">We recommend that you use a background thread to traverse the SD card.</span></span> <span data-ttu-id="a23c2-145">SD カードには、かなりのギガバイト数のデータを格納できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-145">An SD card may contain many gigabytes of data.</span></span>

<span data-ttu-id="a23c2-146">また、アプリでは、ユーザーに対してフォルダー ピッカーを使って特定のフォルダーを選ぶように要求することもできます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-146">Your app can also require the user to choose specific folders by using the folder picker.</span></span>

<span data-ttu-id="a23c2-147">[**KnownFolders.RemovableDevices**](https://msdn.microsoft.com/library/windows/apps/br227158) から取得したパスを使って SD カード上のファイル システムにアクセスした場合のメソッドの動作を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a23c2-147">When you access the file system on the SD card with a path that you derived from [**KnownFolders.RemovableDevices**](https://msdn.microsoft.com/library/windows/apps/br227158), the following methods behave in the following way.</span></span>

-   <span data-ttu-id="a23c2-148">[**GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227273) メソッドは、処理対象として登録したファイル拡張子と、指定したメディア ライブラリ機能に関連付けられているファイル拡張子との和集合を返します。</span><span class="sxs-lookup"><span data-stu-id="a23c2-148">The [**GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227273) method returns the union of the file extensions that you have registered to handle and the file extensions associated with any media library capabilities that you have specified.</span></span>
-   <span data-ttu-id="a23c2-149">アクセスしようとするファイルの拡張子を処理対象として登録しなかった場合、[**GetFileFromPathAsync**](https://msdn.microsoft.com/library/windows/apps/br227206) メソッドは失敗します。</span><span class="sxs-lookup"><span data-stu-id="a23c2-149">The [**GetFileFromPathAsync**](https://msdn.microsoft.com/library/windows/apps/br227206) method fails if you have not registered to handle the file extension of the file you are trying to access.</span></span>

## <a name="identifying-the-individual-sd-card"></a><span data-ttu-id="a23c2-150">個々の SD カードの識別</span><span class="sxs-lookup"><span data-stu-id="a23c2-150">Identifying the individual SD card</span></span>

<span data-ttu-id="a23c2-151">SD カードが最初にマウントされると、オペレーティング システムによって、そのカードの一意の識別子が生成されます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-151">When the SD card is first mounted, the operating system generates a unique identifier for the card.</span></span> <span data-ttu-id="a23c2-152">この ID は、カードのルートにある WPSystem フォルダー内のファイルに格納されます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-152">It stores this ID in a file in the WPSystem folder at the root of the card.</span></span> <span data-ttu-id="a23c2-153">アプリはこの ID を使って、カードを認識できるかどうかを判断することができます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-153">An app can use this ID to determine whether it recognizes the card.</span></span> <span data-ttu-id="a23c2-154">カードがアプリによって認識されると、アプリでは、既に完了している特定の操作を後で実行できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-154">If an app recognizes the card, the app may be able to postpone certain operations that were completed previously.</span></span> <span data-ttu-id="a23c2-155">ただし、アプリが前回カードにアクセスした以降、カードのコンテンツが変更されている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a23c2-155">However the contents of the card may have changed since the card was last accessed by the app.</span></span>

<span data-ttu-id="a23c2-156">たとえば、電子ブックにインデックスを付けるアプリについて考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="a23c2-156">For example, consider an app that indexes ebooks.</span></span> <span data-ttu-id="a23c2-157">アプリが以前に SD カード全体を走査して電子ブックのファイルを探し、電子ブックのインデックスを作成した場合、カードをもう一度挿入し、アプリがカードを認識すると、直ちにインデックスの一覧を表示できます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-157">If the app has previously scanned the whole SD card for ebook files and created an index of the ebooks, it can display the list immediately if the card is reinserted and the app recognizes the card.</span></span> <span data-ttu-id="a23c2-158">これとは別に、新しい電子ブックを検索する優先度の低いバックグラウンド スレッドを開始することもできます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-158">Separately it can start a low-priority background thread to search for new ebooks.</span></span> <span data-ttu-id="a23c2-159">また、削除された電子ブックへアクセスしようとしたとき、以前に存在していた電子ブックが見つからなかった場合のエラーを処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="a23c2-159">It can also handle a failure to find an ebook that existed previously when the user tries to access the deleted ebook.</span></span>

<span data-ttu-id="a23c2-160">この ID を含むプロパティの名前は、**WindowsPhone.ExternalStorageId** です。</span><span class="sxs-lookup"><span data-stu-id="a23c2-160">The name of the property that contains this ID is **WindowsPhone.ExternalStorageId**.</span></span>

```csharp
using Windows.Storage;

// Get the logical root folder for all external storage devices.
StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;

// Get the first child folder, which represents the SD card.
StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();

if (sdCard != null)
{
    var allProperties = sdCard.Properties;
    IEnumerable<string> propertiesToRetrieve = new List<string> { "WindowsPhone.ExternalStorageId" };

    var storageIdProperties = await allProperties.RetrievePropertiesAsync(propertiesToRetrieve);

    string cardId = (string)storageIdProperties["WindowsPhone.ExternalStorageId"];

    if (...) // If cardID matches the cached ID of a recognized card.
    {
        // Card is recognized. Index contents opportunistically.
    }
    else
    {
        // Card is not recognized. Index contents immediately.
    }
}
```

 

 
