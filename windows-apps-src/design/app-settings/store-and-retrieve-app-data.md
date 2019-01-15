---
Description: Learn how to store and retrieve local, roaming, and temporary app data.
title: 設定と他のアプリ データを保存して取得する
ms.assetid: 41676A02-325A-455E-8565-C9EC0BC3A8FE
label: App settings and data
template: detail.hbs
ms.date: 11/14/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3c4f8de32be13f9de776a1c2d0ba0f6af2797329
ms.sourcegitcommit: be52da74f0b3f24973286792afa4f5e80799161b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/15/2019
ms.locfileid: "9009519"
---
# <a name="store-and-retrieve-settings-and-other-app-data"></a><span data-ttu-id="fcc32-103">設定と他のアプリ データを保存して取得する</span><span class="sxs-lookup"><span data-stu-id="fcc32-103">Store and retrieve settings and other app data</span></span>

<span data-ttu-id="fcc32-104">*アプリ データ*とは、特定のアプリに固有の実行可能データです。</span><span class="sxs-lookup"><span data-stu-id="fcc32-104">*App data* is mutable data that is specific to a particular app.</span></span> <span data-ttu-id="fcc32-105">ランタイム状態、ユーザー設定、その他の設定などがあります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-105">It includes runtime state, user preferences, and other settings.</span></span> <span data-ttu-id="fcc32-106">アプリ データは*ユーザー データ*とは異なり、アプリを使用しているときに、ユーザーが作成、管理するデータです。</span><span class="sxs-lookup"><span data-stu-id="fcc32-106">App data is different from *user data*, data that the user creates and manages when using an app.</span></span> <span data-ttu-id="fcc32-107">ユーザー データには、ドキュメント ファイル、メディア ファイル、メール トランスクリプト、通信トランスクリプト、ユーザーが作成したコンテンツを保持するデータベース レコードなどがあります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-107">User data includes document or media files, email or communication transcripts, or database records holding content created by the user.</span></span> <span data-ttu-id="fcc32-108">ユーザー データは複数のアプリで有効な場合があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-108">User data may be useful or meaningful to more than one app.</span></span> <span data-ttu-id="fcc32-109">多くの場合、ユーザー データは、ユーザーがアプリ自体とは無関係にエンティティとして操作または転送するデータ (ドキュメントなど) です。</span><span class="sxs-lookup"><span data-stu-id="fcc32-109">Often, this is data that the user wants to manipulate or transmit as an entity independent of the app itself, such as a document.</span></span>

<span data-ttu-id="fcc32-110">**アプリ データに関する重要な注意:** アプリ データの有効期間は、アプリの有効期間に依存します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-110">**Important note about app data:** The lifetime of the app data is tied to the lifetime of the app.</span></span> <span data-ttu-id="fcc32-111">アプリが削除されると、すべてのアプリ データが失われます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-111">If the app is removed, all of the app data will be lost as a consequence.</span></span> <span data-ttu-id="fcc32-112">ユーザー データや、ユーザーにとって欠かすことができない重要なデータの保存には、アプリ データを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-112">Don't use app data to store user data or anything that users might perceive as valuable and irreplaceable.</span></span> <span data-ttu-id="fcc32-113">そのような情報の保存には、ユーザーのライブラリや Microsoft OneDrive を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-113">We recommend that the user's libraries and Microsoft OneDrive be used to store this sort of information.</span></span> <span data-ttu-id="fcc32-114">アプリ データは、アプリ固有のユーザー設定、設定、お気に入りを保存するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="fcc32-114">App data is ideal for storing app-specific user preferences, settings, and favorites.</span></span>

## <a name="types-of-app-data"></a><span data-ttu-id="fcc32-115">アプリ データの種類</span><span class="sxs-lookup"><span data-stu-id="fcc32-115">Types of app data</span></span>


<span data-ttu-id="fcc32-116">アプリ データには、設定とファイルの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-116">There are two types of app data: settings and files.</span></span>

-   **<span data-ttu-id="fcc32-117">設定</span><span class="sxs-lookup"><span data-stu-id="fcc32-117">Settings</span></span>**

    <span data-ttu-id="fcc32-118">設定を使用して、ユーザー設定やとアプリケーションの状態情報を保存します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-118">Use settings to store user preferences and application state info.</span></span> <span data-ttu-id="fcc32-119">アプリ データ API を使用して、設定をを簡単に作成して取得できます (この記事の後半でいくつかの例を紹介します)。</span><span class="sxs-lookup"><span data-stu-id="fcc32-119">The app data API enables you to easily create and retrieve settings (we'll show you some examples later in this article).</span></span>

    <span data-ttu-id="fcc32-120">アプリの設定に使用できるデータ型を次に示します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-120">Here are data types you can use for app settings:</span></span>

    -   <span data-ttu-id="fcc32-121">**UInt8**、**Int16**、**UInt16**、**Int32**、**UInt32**、**Int64**、**UInt64**、**Single**、**Double**</span><span class="sxs-lookup"><span data-stu-id="fcc32-121">**UInt8**, **Int16**, **UInt16**, **Int32**, **UInt32**, **Int64**, **UInt64**, **Single**, **Double**</span></span>
    -   **<span data-ttu-id="fcc32-122">Boolean</span><span class="sxs-lookup"><span data-stu-id="fcc32-122">Boolean</span></span>**
    -   <span data-ttu-id="fcc32-123">**Char16**、**String**</span><span class="sxs-lookup"><span data-stu-id="fcc32-123">**Char16**, **String**</span></span>
    -   <span data-ttu-id="fcc32-124">[**DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576)、[**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/br225996)</span><span class="sxs-lookup"><span data-stu-id="fcc32-124">[**DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576), [**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/br225996)</span></span>
    -   <span data-ttu-id="fcc32-125">**GUID**、[**Point**](https://msdn.microsoft.com/library/windows/apps/br225870)、[**Size**](https://msdn.microsoft.com/library/windows/apps/br225995)、[**Rect**](https://msdn.microsoft.com/library/windows/apps/br225994)</span><span class="sxs-lookup"><span data-stu-id="fcc32-125">**GUID**, [**Point**](https://msdn.microsoft.com/library/windows/apps/br225870), [**Size**](https://msdn.microsoft.com/library/windows/apps/br225995), [**Rect**](https://msdn.microsoft.com/library/windows/apps/br225994)</span></span>
    -   <span data-ttu-id="fcc32-126">[**ApplicationDataCompositeValue**](https://msdn.microsoft.com/library/windows/apps/br241588): 自動的にシリアル化および逆シリアル化する必要がある一連のアプリの設定。</span><span class="sxs-lookup"><span data-stu-id="fcc32-126">[**ApplicationDataCompositeValue**](https://msdn.microsoft.com/library/windows/apps/br241588): A set of related app settings that must be serialized and deserialized atomically.</span></span> <span data-ttu-id="fcc32-127">コンポジット設定を使うと、相互に依存する設定のアトミックな更新が簡単になります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-127">Use composite settings to easily handle atomic updates of interdependent settings.</span></span> <span data-ttu-id="fcc32-128">同時アクセスとローミング時は、システムによってコンポジット設定の整合性が保たれます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-128">The system ensures the integrity of composite settings during concurrent access and roaming.</span></span> <span data-ttu-id="fcc32-129">コンポジット設定は少量のデータに適しており、大きなデータ セットに使うとパフォーマンスが低下する場合があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-129">Composite settings are optimized for small amounts of data, and performance can be poor if you use them for large data sets.</span></span>
-   **<span data-ttu-id="fcc32-130">ファイル</span><span class="sxs-lookup"><span data-stu-id="fcc32-130">Files</span></span>**

    <span data-ttu-id="fcc32-131">ファイルを使うと、バイナリ データを保存したり、独自にカスタマイズされ、シリアル化された型を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-131">Use files to store binary data or to enable your own, customized serialized types.</span></span>

## <a name="storing-app-data-in-the-app-data-stores"></a><span data-ttu-id="fcc32-132">アプリのデータ ストアにアプリ データを保存する</span><span class="sxs-lookup"><span data-stu-id="fcc32-132">Storing app data in the app data stores</span></span>


<span data-ttu-id="fcc32-133">アプリのインストール時には、設定やファイル用に、ユーザーごとの固有のデータ ストアが設定されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-133">When an app is installed, the system gives it its own per-user data stores for settings and files.</span></span> <span data-ttu-id="fcc32-134">物理的ストレージはシステムによって管理されるため、このデータの場所や形式を意識することなく、データは他のアプリやユーザーから確実に分離されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-134">You don't need to know where or how this data exists, because the system is responsible for managing the physical storage, ensuring that the data is kept isolated from other apps and other users.</span></span> <span data-ttu-id="fcc32-135">また、アプリに更新プログラムをインストールするときはデータ ストアの内容が保持され、アプリのアンインストール時にはデータ ストアの内容が完全に削除されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-135">The system also preserves the contents of these data stores when the user installs an update to your app and removes the contents of these data stores completely and cleanly when your app is uninstalled.</span></span>

<span data-ttu-id="fcc32-136">各アプリのデータ ストア内には、ローカル ファイル用、ローミング ファイル用、一時ファイル用に 1 つずつ、システム定義のルート ディレクトリがあります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-136">Within its app data store, each app has system-defined root directories: one for local files, one for roaming files, and one for temporary files.</span></span> <span data-ttu-id="fcc32-137">それぞれのルート ディレクトリに新しいファイルや新しいコンテナーをアプリで追加できます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-137">Your app can add new files and new containers to each of these root directories.</span></span>

## <a name="local-app-data"></a><span data-ttu-id="fcc32-138">ローカル アプリ データ</span><span class="sxs-lookup"><span data-stu-id="fcc32-138">Local app data</span></span>


<span data-ttu-id="fcc32-139">ローカル アプリ データは、アプリ セッション間で保持する必要がある情報のうち、ローミング アプリ データには適していないものに使用されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-139">Local app data should be used for any information that needs to be preserved between app sessions and is not suitable for roaming app data.</span></span> <span data-ttu-id="fcc32-140">また、他のデバイスには適さないデータもここに格納します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-140">Data that is not applicable on other devices should be stored here as well.</span></span> <span data-ttu-id="fcc32-141">ローカルに格納されるデータには、一般的なサイズの制限はありません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-141">There is no general size restriction on local data stored.</span></span> <span data-ttu-id="fcc32-142">ローカル アプリ データ ストアは、ローミングに適さないデータや、大きなデータ セットに使用してください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-142">Use the local app data store for data that it does not make sense to roam and for large data sets.</span></span>

### <a name="retrieve-the-local-app-data-store"></a><span data-ttu-id="fcc32-143">ローカル アプリ データ ストアを取得する</span><span class="sxs-lookup"><span data-stu-id="fcc32-143">Retrieve the local app data store</span></span>

<span data-ttu-id="fcc32-144">ローカル アプリ データを読み書きする前に、ローカル アプリ データ ストアを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-144">Before you can read or write local app data, you must retrieve the local app data store.</span></span> <span data-ttu-id="fcc32-145">ローカル アプリ データ ストアを取得するには、[**ApplicationData.LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) プロパティを使用して、アプリのローカル設定を [**ApplicationDataContainer**](https://msdn.microsoft.com/library/windows/apps/br241599) オブジェクトとして取得します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-145">To retrieve the local app data store, use the [**ApplicationData.LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) property to get the app's local settings as an [**ApplicationDataContainer**](https://msdn.microsoft.com/library/windows/apps/br241599) object.</span></span> <span data-ttu-id="fcc32-146">[**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) オブジェクト内のファイルを取得するには、[**ApplicationData.LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-146">Use the [**ApplicationData.LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) property to get the files in a [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) object.</span></span> <span data-ttu-id="fcc32-147">バックアップや復元に含まれていないファイルを保存できるローカル アプリ データ ストア内のフォルダーを取得するには、[**ApplicationData.LocalCacheFolder**](https://msdn.microsoft.com/library/windows/apps/dn633825) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-147">Use the [**ApplicationData.LocalCacheFolder**](https://msdn.microsoft.com/library/windows/apps/dn633825) property to get the folder in the local app data store where you can save files that are not included in backup and restore.</span></span>

```CSharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;
```

### <a name="create-and-retrieve-a-simple-local-setting"></a><span data-ttu-id="fcc32-148">簡易ローカル設定を作成して取得する</span><span class="sxs-lookup"><span data-stu-id="fcc32-148">Create and retrieve a simple local setting</span></span>

<span data-ttu-id="fcc32-149">設定を作成または書き込むには、[**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) プロパティを使用して、前の手順で取得した `localSettings` コンテナー内の設定にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-149">To create or write a setting, use the [**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) property to access the settings in the `localSettings` container we got in the previous step.</span></span> <span data-ttu-id="fcc32-150">次の例では、`exampleSetting` という名前の設定を作成します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-150">This example creates a setting named `exampleSetting`.</span></span>

```CSharp
// Simple setting

localSettings.Values["exampleSetting"] = "Hello Windows";
```

<span data-ttu-id="fcc32-151">設定を取得するには、設定を作成したときに使ったものと同じ [**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="fcc32-151">To retrieve the setting, you use the same [**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) property that you used to create the setting.</span></span> <span data-ttu-id="fcc32-152">この例では作成した設定を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fcc32-152">This example shows how to retrieve the setting we just created.</span></span>

```CSharp
// Simple setting
Object value = localSettings.Values["exampleSetting"];
```

### <a name="create-and-retrieve-a-local-composite-value"></a><span data-ttu-id="fcc32-153">ローカル コンポジット値を作成して取得する</span><span class="sxs-lookup"><span data-stu-id="fcc32-153">Create and retrieve a local composite value</span></span>

<span data-ttu-id="fcc32-154">コンポジット値を作成または書き込むには、[**ApplicationDataCompositeValue**](https://msdn.microsoft.com/library/windows/apps/br241588) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-154">To create or write a composite value, create an [**ApplicationDataCompositeValue**](https://msdn.microsoft.com/library/windows/apps/br241588) object.</span></span> <span data-ttu-id="fcc32-155">次の例では、`exampleCompositeSetting` という名前のコンポジット設定を作成し、`localSettings` コンテナーに追加します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-155">This example creates a composite setting named `exampleCompositeSetting` and adds it to the `localSettings` container.</span></span>

```CSharp
// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
    new Windows.Storage.ApplicationDataCompositeValue();
composite["intVal"] = 1;
composite["strVal"] = "string";

localSettings.Values["exampleCompositeSetting"] = composite;
```

<span data-ttu-id="fcc32-156">この例では作成したコンポジット値を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fcc32-156">This example shows how to retrieve the composite value we just created.</span></span>

```CSharp
// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
   (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["exampleCompositeSetting"];

if (composite == null)
{
   // No data
}
else
{
   // Access data in composite["intVal"] and composite["strVal"]
}
```

### <a name="create-and-read-a-local-file"></a><span data-ttu-id="fcc32-157">ローカル ファイルを作成して読み取る</span><span class="sxs-lookup"><span data-stu-id="fcc32-157">Create and read a local file</span></span>

<span data-ttu-id="fcc32-158">ローカル アプリ データ ストアにファイルを作成して更新するには、[**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) や [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) などのファイル API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-158">To create and update a file in the local app data store, use the file APIs, such as [**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) and [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505).</span></span> <span data-ttu-id="fcc32-159">次の例では、`localFolder` コンテナーに `dataFile.txt` という名前のファイルを作成し、現在の日付と時刻をファイルに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-159">This example creates a file named `dataFile.txt` in the `localFolder` container and writes the current date and time to the file.</span></span> <span data-ttu-id="fcc32-160">[**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) 列挙体の **ReplaceExisting** 値は、ファイルが既にある場合にファイルを置き換えることを示します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-160">The **ReplaceExisting** value from the [**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) enumeration indicates to replace the file if it already exists.</span></span>

```csharp
async void WriteTimestamp()
{
   Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = 
       new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");

   StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt", 
       CreationCollisionOption.ReplaceExisting);
   await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTimeOffset.Now));
}
```

<span data-ttu-id="fcc32-161">ローカル アプリ データ ストアのファイルを開いて読み取るには、[**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272)、[**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741)、[**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) などのファイル API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-161">To open and read a file in the local app data store, use the file APIs, such as [**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272), [**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741), and [**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482).</span></span> <span data-ttu-id="fcc32-162">この例では、前の手順で作成した `dataFile.txt` ファイルを開き、ファイルから日付を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-162">This example opens the `dataFile.txt` file created in the previous step and reads the date from the file.</span></span> <span data-ttu-id="fcc32-163">さまざまな場所からファイル リソースを読み込む方法について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-163">For details on loading file resources from various locations, see [How to load file resources](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322).</span></span>

```csharp
async void ReadTimestamp()
{
   try
   {
      StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
      String timestamp = await FileIO.ReadTextAsync(sampleFile);
      // Data is contained in timestamp
   }
   catch (Exception)
   {
      // Timestamp not found
   }
}
```

## <a name="roaming-data"></a><span data-ttu-id="fcc32-164">ローミング データ</span><span class="sxs-lookup"><span data-stu-id="fcc32-164">Roaming data</span></span>


<span data-ttu-id="fcc32-165">アプリでローミング データを使用すると、複数のデバイス間でアプリ データを簡単に同期することができます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-165">If you use roaming data in your app, your users can easily keep your app's app data in sync across multiple devices.</span></span> <span data-ttu-id="fcc32-166">アプリを複数のデバイス上にインストールすると、OS によってアプリ データの同期が維持されるため、2 つ目のデバイス上でユーザーが行うアプリのセットアップ作業が軽減されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-166">If a user installs your app on multiple devices, the OS keeps the app data in sync, reducing the amount of setup work that the user needs to do for your app on their second device.</span></span> <span data-ttu-id="fcc32-167">またローミングを使うと、異なるデバイス上でも、一覧の作成などの作業を中断したときの状態から再開することができます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-167">Roaming also enables your users to continue a task, such as composing a list, right where they left off even on a different device.</span></span> <span data-ttu-id="fcc32-168">ローミング データが更新されると、OS によってクラウドにレプリケートされ、アプリがインストールされている別のデバイスに同期されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-168">The OS replicates roaming data to the cloud when it is updated, and synchronizes the data to the other devices on which the app is installed.</span></span>

<span data-ttu-id="fcc32-169">各アプリでローミングできるアプリ データのサイズには OS による制限があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-169">The OS limits the size of the app data that each app may roam.</span></span> <span data-ttu-id="fcc32-170">「[**ApplicationData.RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-170">See [**ApplicationData.RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625).</span></span> <span data-ttu-id="fcc32-171">この制限に達した場合、アプリでローミングされたアプリ データの合計が制限値未満に戻るまで、そのアプリのアプリ データはクラウドにまったくレプリケートされません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-171">If the app hits this limit, none of the app's app data will be replicated to the cloud until the app's total roamed app data is less than the limit again.</span></span> <span data-ttu-id="fcc32-172">このため、ローミング データは、ユーザー設定、リンク、小さなデータ ファイルのみに使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-172">For this reason, it is a best practice to use roaming data only for user preferences, links, and small data files.</span></span>

<span data-ttu-id="fcc32-173">アプリのローミング データは、一定の時間間隔内にユーザーがいずれかのデバイスからアクセスしている限り、クラウドに保持されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-173">Roaming data for an app is available in the cloud as long as it is accessed by the user from some device within the required time interval.</span></span> <span data-ttu-id="fcc32-174">この時間間隔内にアプリが実行されないと、そのローミング データはクラウドから削除されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-174">If the user does not run an app for longer than this time interval, its roaming data is removed from the cloud.</span></span> <span data-ttu-id="fcc32-175">ユーザーがアプリをアンインストールしても、そのローミング データがクラウドから自動的に削除されることはなく、保持されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-175">If a user uninstalls an app, its roaming data isn't automatically removed from the cloud, it's preserved.</span></span> <span data-ttu-id="fcc32-176">時間間隔内にユーザーがアプリを再インストールすると、ローミング データがクラウドから同期されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-176">If the user reinstalls the app within the time interval, the roaming data is synchronized from the cloud.</span></span>

### <a name="roaming-data-dos-and-donts"></a><span data-ttu-id="fcc32-177">データのローミングの推奨事項と非推奨事項</span><span class="sxs-lookup"><span data-stu-id="fcc32-177">Roaming data do's and don'ts</span></span>

-   <span data-ttu-id="fcc32-178">ユーザーの基本設定やカスタマイズ、リンク、小さなデータ ファイルにローミングを使います。</span><span class="sxs-lookup"><span data-stu-id="fcc32-178">Use roaming for user preferences and customizations, links, and small data files.</span></span> <span data-ttu-id="fcc32-179">たとえば、ローミングを使って、ユーザーの背景色の基本設定をすべてのデバイスで保持します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-179">For example, use roaming to preserve a user's background color preference across all devices.</span></span>
-   <span data-ttu-id="fcc32-180">ユーザーがデバイス間で作業を続けられるようにローミングを使います。</span><span class="sxs-lookup"><span data-stu-id="fcc32-180">Use roaming to let users continue a task across devices.</span></span> <span data-ttu-id="fcc32-181">たとえば、下書きしたメールの内容やリーダー アプリで最近表示したページなどのアプリ データをローミングします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-181">For example, roam app data like the contents of an drafted email or the most recently viewed page in a reader app.</span></span>
-   <span data-ttu-id="fcc32-182">アプリ データを更新して、[**DataChanged**](https://msdn.microsoft.com/library/windows/apps/br241620) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-182">Handle the [**DataChanged**](https://msdn.microsoft.com/library/windows/apps/br241620) event by updating app data.</span></span> <span data-ttu-id="fcc32-183">このイベントは、クラウドからのアプリ データの同期が完了したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-183">This event occurs when app data has just finished syncing from the cloud.</span></span>
-   <span data-ttu-id="fcc32-184">生データではなくコンテンツへの参照をローミングします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-184">Roam references to content rather than raw data.</span></span> <span data-ttu-id="fcc32-185">たとえば、オンライン記事のコンテンツではなく URL をローミングします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-185">For example, roam a URL rather than the content of an online article.</span></span>
-   <span data-ttu-id="fcc32-186">タイム クリティカルな重要な設定に対しては、[**RoamingSettings**](https://msdn.microsoft.com/library/windows/apps/br241624) に関連付けられた *HighPriority* 設定を使います。</span><span class="sxs-lookup"><span data-stu-id="fcc32-186">For important, time critical settings, use the *HighPriority* setting associated with [**RoamingSettings**](https://msdn.microsoft.com/library/windows/apps/br241624).</span></span>
-   <span data-ttu-id="fcc32-187">デバイス固有のアプリ データをローミングしないでください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-187">Don't roam app data that is specific to a device.</span></span> <span data-ttu-id="fcc32-188">ローカルにあるファイル リソースのパス名など、ローカルのみに関連した情報もあります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-188">Some info is only pertinent locally, such as a path name to a local file resource.</span></span> <span data-ttu-id="fcc32-189">ローカル情報をローミングする場合は、その情報が別のデバイスで無効なときにアプリを回復できることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-189">If you do decide to roam local information, make sure that the app can recover if the info isn't valid on the secondary device.</span></span>
-   <span data-ttu-id="fcc32-190">大量のアプリ データをローミングしないでください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-190">Don't roam large sets of app data.</span></span> <span data-ttu-id="fcc32-191">アプリでローミングできるアプリ データの量には制限があります。この最大値を取得するには、[**RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625) プロパティを使ってください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-191">There's a limit to the amount of app data an app may roam; use [**RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625) property to get this maximum.</span></span> <span data-ttu-id="fcc32-192">この制限に達した場合、アプリ データのサイズが制限を下回るまで、データはローミングできません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-192">If an app hits this limit, no data can roam until the size of the app data store no longer exceeds the limit.</span></span> <span data-ttu-id="fcc32-193">アプリを設計する際は、この制限を超えないようにサイズの大きいデータをどのように制限するかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-193">When you design your app, consider how to put a bound on larger data so as to not exceed the limit.</span></span> <span data-ttu-id="fcc32-194">たとえば、ゲームの状態を保存するのにそれぞれ 10 KB 必要になる場合は、ユーザーによる保存を 10 ゲームまでに制限したりすると効果的です。</span><span class="sxs-lookup"><span data-stu-id="fcc32-194">For example, if saving a game state requires 10KB each, the app might only allow the user store up to 10 games.</span></span>
-   <span data-ttu-id="fcc32-195">即時同期に依存するデータにローミングを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-195">Don't use roaming for data that relies on instant syncing.</span></span> <span data-ttu-id="fcc32-196">Windows では即時同期が保証されません。ユーザーがオフラインであったり、待ち時間の長いネットワークを使っている場合、ローミングはかなり遅れる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-196">Windows doesn't guarantee an instant sync; roaming could be significantly delayed if a user is offline or on a high latency network.</span></span> <span data-ttu-id="fcc32-197">UI が即時同期に依存しないことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-197">Ensure that your UI doesn't depend on instant syncing.</span></span>
-   <span data-ttu-id="fcc32-198">頻繁に変更されるデータのローミングを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-198">Don't use roaming for frequently changing data.</span></span> <span data-ttu-id="fcc32-199">たとえば、再生中の曲の秒刻みの位置など、頻繁に変更される情報を追跡する場合は、この情報をローミング アプリ データとして保存しないでください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-199">For example, if your app tracks frequently changing info, such as the position in a song by second, don't store this as roaming app data.</span></span> <span data-ttu-id="fcc32-200">代わりに、現在再生中の曲など、変更の頻度が少なく、ユーザー エクスペリエンスも損なわないような情報を利用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-200">Instead, pick a less frequent representation that still provides a good user experience, like the currently playing song.</span></span>

### <a name="roaming-pre-requisites"></a><span data-ttu-id="fcc32-201">ローミングの前提条件</span><span class="sxs-lookup"><span data-stu-id="fcc32-201">Roaming pre-requisites</span></span>

<span data-ttu-id="fcc32-202">アプリ データのローミングは、Microsoft アカウントを使ってデバイスにログインするすべてのユーザーに利点をもたらします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-202">Any user can benefit from roaming app data if they use a Microsoft account to log on to their device.</span></span> <span data-ttu-id="fcc32-203">ただし、いつでもデバイスでアプリ データのローミングを切り替えることができるのは、ユーザーとグループ ポリシーの管理者です。</span><span class="sxs-lookup"><span data-stu-id="fcc32-203">However, users and group policy administrators can switch off roaming app data on a device at any time.</span></span> <span data-ttu-id="fcc32-204">ユーザーが Microsoft アカウントを使わないまたはデータのローミング機能を無効には、彼女は引き続き、アプリを使うことですがアプリ データは各デバイスにローカルになります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-204">If a user chooses not to use a Microsoft account or disables roaming data capabilities, she will still be able to use your app, but app data will be local to each device.</span></span>

<span data-ttu-id="fcc32-205">[**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) に格納されているデータは、ユーザーが "信頼" しているデバイスにしか移行されません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-205">Data stored in the [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) will only transition if a user has made a device “trusted”.</span></span> <span data-ttu-id="fcc32-206">デバイスが信頼されていない場合、この資格情報コンテナーのセキュリティで確保されているデータはローミングされません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-206">If a device isn't trusted, data secured in this vault will not roam.</span></span>

### <a name="conflict-resolution"></a><span data-ttu-id="fcc32-207">競合の解決</span><span class="sxs-lookup"><span data-stu-id="fcc32-207">Conflict resolution</span></span>

<span data-ttu-id="fcc32-208">アプリ データのローミングは、複数のデバイスでの同時使用を想定していません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-208">Roaming app data is not intended for simultaneous use on more than one device at a time.</span></span> <span data-ttu-id="fcc32-209">2 台のデバイスで特定のデータ単位が変更されたことが原因で同期中に競合が発生した場合、最後に書き込まれた値が常に優先されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-209">If a conflict arises during synchronization because a particular data unit was changed on two devices, the system will always favor the value that was written last.</span></span> <span data-ttu-id="fcc32-210">これにより、アプリで最新の情報が利用されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-210">This ensures that the app utilizes the most up-to-date information.</span></span> <span data-ttu-id="fcc32-211">データ単位が設定コンポジットの場合、競合の解決は設定の単位で行われ、最新の変更を含むコンポジットが同期されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-211">If the data unit is a setting composite, conflict resolution will still occur on the level of the setting unit, which means that the composite with the latest change will be synchronized.</span></span>

### <a name="when-to-write-data"></a><span data-ttu-id="fcc32-212">データを書き込むタイミング</span><span class="sxs-lookup"><span data-stu-id="fcc32-212">When to write data</span></span>

<span data-ttu-id="fcc32-213">想定される設定の有効期間に応じて、データを書き込むタイミングを変える必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-213">Depending on the expected lifetime of the setting, data should be written at different times.</span></span> <span data-ttu-id="fcc32-214">変更の頻度が低いアプリ データや変更間隔の長いアプリ データは、変更されたらすぐに書き込むようにします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-214">Infrequently or slowly changing app data should be written immediately.</span></span> <span data-ttu-id="fcc32-215">ただし、頻繁に変更されるアプリ データは、アプリが中断されたとき以外は、一定の間隔 (5 分に 1 回など) でのみ書き込むようにします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-215">However, app data that changes frequently should only be written periodically at regular intervals (such as once every 5 minutes), as well as when the app is suspended.</span></span> <span data-ttu-id="fcc32-216">たとえば、音楽アプリでは、"現在の曲" の設定は新しい曲の再生が始まるたびに書き込みますが、曲の途中の実際の位置は中断したときにのみ書き込みます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-216">For example, a music app might write the “current song” settings whenever a new song starts to play, however, the actual position in the song should only be written on suspend.</span></span>

### <a name="excessive-usage-protection"></a><span data-ttu-id="fcc32-217">使いすぎに対する保護</span><span class="sxs-lookup"><span data-stu-id="fcc32-217">Excessive usage protection</span></span>

<span data-ttu-id="fcc32-218">リソースの不適切な使用を防止するために、システムにはさまざまな保護メカニズムが備わっています。</span><span class="sxs-lookup"><span data-stu-id="fcc32-218">The system has various protection mechanisms in place to avoid inappropriate use of resources.</span></span> <span data-ttu-id="fcc32-219">アプリ データが想定どおりに移行されない場合は、デバイスが一時的に制限されていることが考えられます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-219">If app data does not transition as expected, it is likely that the device has been temporarily restricted.</span></span> <span data-ttu-id="fcc32-220">通常、この状況はしばらくすると自動的に解決されるため、操作は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-220">Waiting for some time will usually resolve this situation automatically and no action is required.</span></span>

### <a name="versioning"></a><span data-ttu-id="fcc32-221">バージョン</span><span class="sxs-lookup"><span data-stu-id="fcc32-221">Versioning</span></span>

<span data-ttu-id="fcc32-222">アプリ データは、バージョンに基づいてデータ構造をアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-222">App data can utilize versioning to upgrade from one data structure to another.</span></span> <span data-ttu-id="fcc32-223">バージョン番号は、アプリのバージョンとは別の番号で、自由に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-223">The version number is different from the app version and can be set at will.</span></span> <span data-ttu-id="fcc32-224">強制ではありませんが、バージョン番号は新しいデータほど大きくすることを強くお勧めします。新しいデータを表すバージョン番号が小さくなると、データ損失などの望ましくない問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-224">Although not enforced, it is highly recommended that you use increasing version numbers, since undesirable complications (including data loss)could occur if you try to transition to a lower data version number that represents newer data.</span></span>

<span data-ttu-id="fcc32-225">アプリ データのローミングは、バージョン番号が同じインストールされたアプリの間でしか行われません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-225">App data only roams between installed apps with the same version number.</span></span> <span data-ttu-id="fcc32-226">たとえば、どちらもバージョン 2 のデバイスの間やどちらもバージョン 3 のデバイスの間ではデータが移行されますが、バージョン 2 を実行中のデバイスとバージョン 3 を実行中のデバイスの間ではローミングは行われません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-226">For example, devices on version 2 will transition data between each other and devices on version 3 will do the same, but no roaming will occur between a device running version 2 and a device running version 3.</span></span> <span data-ttu-id="fcc32-227">他のデバイスでさまざまなバージョン番号を利用していたアプリを新たにインストールする場合、新たにインストールしたアプリは、最も大きいバージョン番号と関連付けられているアプリ データを同期します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-227">If you install a new app that utilized various version numbers on other devices, the newly installed app will sync the app data associated with the highest version number.</span></span>

### <a name="testing-and-tools"></a><span data-ttu-id="fcc32-228">テストとツール</span><span class="sxs-lookup"><span data-stu-id="fcc32-228">Testing and tools</span></span>

<span data-ttu-id="fcc32-229">開発者は、ローミング アプリ データの同期をトリガーするためにデバイスをロックできます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-229">Developers can lock their device in order to trigger a synchronization of roaming app data.</span></span> <span data-ttu-id="fcc32-230">一定の期間にわたってアプリ データが移行されていない場合は、次の点を確認してください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-230">If it seems that the app data does not transition within a certain time frame, please check the following items and make sure that:</span></span>

-   <span data-ttu-id="fcc32-231">ローミング データが最大サイズを超えていないこと (詳しくは、「[**RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="fcc32-231">Your roaming data does not exceed the maximum size (see [**RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625) for details).</span></span>
-   <span data-ttu-id="fcc32-232">ファイルが閉じていて、適切に解放されていること。</span><span class="sxs-lookup"><span data-stu-id="fcc32-232">Your files are closed and released properly.</span></span>
-   <span data-ttu-id="fcc32-233">同じバージョンのアプリを実行しているデバイスが 2 台以上あること。</span><span class="sxs-lookup"><span data-stu-id="fcc32-233">There are at least two devices running the same version of the app.</span></span>


### <a name="register-to-receive-notification-when-roaming-data-changes"></a><span data-ttu-id="fcc32-234">ローミング データが変更された場合に通知を受け取るように登録する</span><span class="sxs-lookup"><span data-stu-id="fcc32-234">Register to receive notification when roaming data changes</span></span>

<span data-ttu-id="fcc32-235">アプリのローミング データを使用するには、ローミング データの変更に備えて登録し、設定を読み書きできるように、ローミング データのコンテナーを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-235">To use roaming app data, you need to register for roaming data changes and retrieve the roaming data containers so you can read and write settings.</span></span>

1.  <span data-ttu-id="fcc32-236">ローミング データが変更されたときに通知を受け取るように登録します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-236">Register to receive notification when roaming data changes.</span></span>

    <span data-ttu-id="fcc32-237">[**DataChanged**](https://msdn.microsoft.com/library/windows/apps/br241620) イベントで、ローミング データが変更されたときに通知します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-237">The [**DataChanged**](https://msdn.microsoft.com/library/windows/apps/br241620) event notifies you when roaming data changes.</span></span> <span data-ttu-id="fcc32-238">この例では、ローミング データの変更のハンドラーとして `DataChangeHandler` を設定します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-238">This example sets `DataChangeHandler` as the handler for roaming data changes.</span></span>

```csharp
void InitHandlers()
    {
       Windows.Storage.ApplicationData.Current.DataChanged += 
          new TypedEventHandler<ApplicationData, object>(DataChangeHandler);
    }

    void DataChangeHandler(Windows.Storage.ApplicationData appData, object o)
    {
       // TODO: Refresh your data
    }
```

2.  <span data-ttu-id="fcc32-239">アプリの設定とファイルのコンテナーを取得します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-239">Get the containers for the app's settings and files.</span></span>

    <span data-ttu-id="fcc32-240">設定を取得するには [**ApplicationData.RoamingSettings**](https://msdn.microsoft.com/library/windows/apps/br241624) プロパティを、ファイルを取得するには [**ApplicationData.RoamingFolder**](https://msdn.microsoft.com/library/windows/apps/br241623) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-240">Use the [**ApplicationData.RoamingSettings**](https://msdn.microsoft.com/library/windows/apps/br241624) property to get the settings and the [**ApplicationData.RoamingFolder**](https://msdn.microsoft.com/library/windows/apps/br241623) property to get the files.</span></span>

```csharp
Windows.Storage.ApplicationDataContainer roamingSettings = 
        Windows.Storage.ApplicationData.Current.RoamingSettings;
    Windows.Storage.StorageFolder roamingFolder = 
        Windows.Storage.ApplicationData.Current.RoamingFolder;
```

### <a name="create-and-retrieve-roaming-settings"></a><span data-ttu-id="fcc32-241">ローミング設定を作成して取得する</span><span class="sxs-lookup"><span data-stu-id="fcc32-241">Create and retrieve roaming settings</span></span>

<span data-ttu-id="fcc32-242">前のセクションで取得した `roamingSettings` コンテナー内の設定にアクセスするには、[**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-242">Use the [**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) property to access the settings in the `roamingSettings` container we got in the previous section.</span></span> <span data-ttu-id="fcc32-243">次の例では、`exampleSetting` という名前の簡易設定と、`composite` という名前のコンポジット値を作成します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-243">This example creates a simple setting named `exampleSetting` and a composite value named `composite`.</span></span>

```csharp
// Simple setting

roamingSettings.Values["exampleSetting"] = "Hello World";
// High Priority setting, for example, last page position in book reader app
roamingSettings.values["HighPriority"] = "65";

// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
    new Windows.Storage.ApplicationDataCompositeValue();
composite["intVal"] = 1;
composite["strVal"] = "string";

roamingSettings.Values["exampleCompositeSetting"] = composite;

```

<span data-ttu-id="fcc32-244">この例では作成した設定を取得します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-244">This example retrieves the settings we just created.</span></span>

```csharp
// Simple setting

Object value = roamingSettings.Values["exampleSetting"];

// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
   (Windows.Storage.ApplicationDataCompositeValue)roamingSettings.Values["exampleCompositeSetting"];

if (composite == null)
{
   // No data
}
else
{
   // Access data in composite["intVal"] and composite["strVal"]
}
```

### <a name="create-and-retrieve-roaming-files"></a><span data-ttu-id="fcc32-245">ローミング ファイルを作成して取得する</span><span class="sxs-lookup"><span data-stu-id="fcc32-245">Create and retrieve roaming files</span></span>

<span data-ttu-id="fcc32-246">ローミング アプリ データ ストアでファイルを作成して更新するには、[**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) や [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) などのファイル API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-246">To create and update a file in the roaming app data store, use the file APIs, such as [**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) and [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505).</span></span> <span data-ttu-id="fcc32-247">次の例では、`roamingFolder` コンテナーに `dataFile.txt` という名前のファイルを作成し、現在の日付と時刻をファイルに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-247">This example creates a file named `dataFile.txt` in the `roamingFolder` container and writes the current date and time to the file.</span></span> <span data-ttu-id="fcc32-248">[**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) 列挙体の **ReplaceExisting** 値は、ファイルが既にある場合にファイルを置き換えることを示します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-248">The **ReplaceExisting** value from the [**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) enumeration indicates to replace the file if it already exists.</span></span>

```csharp
async void WriteTimestamp()
{
   Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = 
       new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");

   StorageFile sampleFile = await roamingFolder.CreateFileAsync("dataFile.txt", 
       CreationCollisionOption.ReplaceExisting);
   await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTimeOffset.Now));
}
```

<span data-ttu-id="fcc32-249">ローミング アプリ データ ストアのファイルを開いて読み取るには、[**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272)、[**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741)、[**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) などのファイル API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-249">To open and read a file in the roaming app data store, use the file APIs, such as [**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272), [**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741), and [**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482).</span></span> <span data-ttu-id="fcc32-250">この例では、前のセクションで作成した `dataFile.txt` ファイルを開き、ファイルから日付を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-250">This example opens the `dataFile.txt` file created in the previous section and reads the date from the file.</span></span> <span data-ttu-id="fcc32-251">さまざまな場所からファイル リソースを読み込む方法について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-251">For details on loading file resources from various locations, see [How to load file resources](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322).</span></span>

```csharp
async void ReadTimestamp()
{
   try
   {
      StorageFile sampleFile = await roamingFolder.GetFileAsync("dataFile.txt");
      String timestamp = await FileIO.ReadTextAsync(sampleFile);
      // Data is contained in timestamp
   }
   catch (Exception)
   {
      // Timestamp not found
   }
}
```


## <a name="temporary-app-data"></a><span data-ttu-id="fcc32-252">一時アプリ データ</span><span class="sxs-lookup"><span data-stu-id="fcc32-252">Temporary app data</span></span>


<span data-ttu-id="fcc32-253">一時アプリ データ ストアは、キャッシュのような働きをします。</span><span class="sxs-lookup"><span data-stu-id="fcc32-253">The temporary app data store works like a cache.</span></span> <span data-ttu-id="fcc32-254">ファイルはローミングされず、任意の時点で削除されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-254">Its files do not roam and could be removed at any time.</span></span> <span data-ttu-id="fcc32-255">システム メンテナンス タスクを使うと、この場所に格納されているデータをいつでも自動的に削除できます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-255">The System Maintenance task can automatically delete data stored at this location at any time.</span></span> <span data-ttu-id="fcc32-256">ディスク クリーンアップを使って、一時データ ストアからファイルを削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-256">The user can also clear files from the temporary data store using Disk Cleanup.</span></span> <span data-ttu-id="fcc32-257">一時アプリ データは、アプリ セッションの一時的な情報の格納に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-257">Temporary app data can be used for storing temporary information during an app session.</span></span> <span data-ttu-id="fcc32-258">このデータは、アプリ セッションの終了後に保持されるという保証はありません。必要に応じて使用領域が再利用されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-258">There is no guarantee that this data will persist beyond the end of the app session as the system might reclaim the used space if needed.</span></span> <span data-ttu-id="fcc32-259">この場所には、[**temporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-259">The location is available via the [**temporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) property.</span></span>

### <a name="retrieve-the-temporary-data-container"></a><span data-ttu-id="fcc32-260">一時データコンテナーを取得する</span><span class="sxs-lookup"><span data-stu-id="fcc32-260">Retrieve the temporary data container</span></span>

<span data-ttu-id="fcc32-261">ファイルを取得するには [**ApplicationData.TemporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-261">Use the [**ApplicationData.TemporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) property to get the files.</span></span> <span data-ttu-id="fcc32-262">以降の手順では、この手順の `temporaryFolder` 変数を使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-262">The next steps use the `temporaryFolder` variable from this step.</span></span>

```csharp
Windows.Storage.StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;
```

### <a name="create-and-read-temporary-files"></a><span data-ttu-id="fcc32-263">一時ファイルを作成して読み取る</span><span class="sxs-lookup"><span data-stu-id="fcc32-263">Create and read temporary files</span></span>

<span data-ttu-id="fcc32-264">一時アプリ データ ストアにファイルを作成して更新するには、[**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) や [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) などのファイル API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-264">To create and update a file in the temporary app data store, use the file APIs, such as [**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) and [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505).</span></span> <span data-ttu-id="fcc32-265">次の例では、`temporaryFolder` コンテナーに `dataFile.txt` という名前のファイルを作成し、現在の日付と時刻をファイルに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-265">This example creates a file named `dataFile.txt` in the `temporaryFolder` container and writes the current date and time to the file.</span></span> <span data-ttu-id="fcc32-266">[**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) 列挙体の **ReplaceExisting** 値は、ファイルが既にある場合にファイルを置き換えることを示します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-266">The **ReplaceExisting** value from the [**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) enumeration indicates to replace the file if it already exists.</span></span>


```csharp
async void WriteTimestamp()
{
   Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = 
       new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");

   StorageFile sampleFile = await temporaryFolder.CreateFileAsync("dataFile.txt", 
       CreateCollisionOption.ReplaceExisting);
   await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTimeOffset.Now));
}
```

<span data-ttu-id="fcc32-267">一時アプリ データ ストアのファイルを開いて読み取るには、[**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272)、[**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741)、[**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) などのファイル API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-267">To open and read a file in the temporary app data store, use the file APIs, such as [**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272), [**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741), and [**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482).</span></span> <span data-ttu-id="fcc32-268">この例では、前の手順で作成した `dataFile.txt` ファイルを開き、ファイルから日付を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="fcc32-268">This example opens the `dataFile.txt` file created in the previous step and reads the date from the file.</span></span> <span data-ttu-id="fcc32-269">さまざまな場所からファイル リソースを読み込む方法について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-269">For details on loading file resources from various locations, see [How to load file resources](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322).</span></span>

```csharp
async void ReadTimestamp()
{
   try
   {
      StorageFile sampleFile = await temporaryFolder.GetFileAsync("dataFile.txt");
      String timestamp = await FileIO.ReadTextAsync(sampleFile);
      // Data is contained in timestamp
   }
   catch (Exception)
   {
      // Timestamp not found
   }
}
```

## <a name="organize-app-data-with-containers"></a><span data-ttu-id="fcc32-270">コンテナーでアプリ データを整理する</span><span class="sxs-lookup"><span data-stu-id="fcc32-270">Organize app data with containers</span></span>


<span data-ttu-id="fcc32-271">アプリ データの設定とファイルを整理するには、ディレクトリで直接作業するのではなく、コンテナー ([**ApplicationDataContainer**](https://msdn.microsoft.com/library/windows/apps/br241599) オブジェクトで表されます) を作成します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-271">To help you organize your app data settings and files, you create containers (represented by [**ApplicationDataContainer**](https://msdn.microsoft.com/library/windows/apps/br241599) objects) instead of working directly with directories.</span></span> <span data-ttu-id="fcc32-272">コンテナーは、ローカル アプリ データ ストア、ローミング アプリ データ ストア、一時アプリ データ ストアに追加できます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-272">You can add containers to the local, roaming, and temporary app data stores.</span></span> <span data-ttu-id="fcc32-273">コンテナーは 32 階層まで入れ子にすることができます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-273">Containers can be nested up to 32 levels deep.</span></span>

<span data-ttu-id="fcc32-274">設定コンテナーを作成するには、[**ApplicationDataContainer.CreateContainer**](https://msdn.microsoft.com/library/windows/apps/br241611) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-274">To create a settings container, call the [**ApplicationDataContainer.CreateContainer**](https://msdn.microsoft.com/library/windows/apps/br241611) method.</span></span> <span data-ttu-id="fcc32-275">次の例では、`exampleContainer` という名前のローカル設定コンテナーを作成し、`exampleSetting` という名前の設定を追加します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-275">This example creates a local settings container named `exampleContainer` and adds a setting named `exampleSetting`.</span></span> <span data-ttu-id="fcc32-276">[**ApplicationDataCreateDisposition**](https://msdn.microsoft.com/library/windows/apps/br241616) 列挙体の **Always** 値は、コンテナーがまだない場合に作成されることを示します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-276">The **Always** value from the [**ApplicationDataCreateDisposition**](https://msdn.microsoft.com/library/windows/apps/br241616) enumeration indicates that the container is created if it doesn't already exist.</span></span>

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Setting in a container
Windows.Storage.ApplicationDataContainer container = 
   localSettings.CreateContainer("exampleContainer", Windows.Storage.ApplicationDataCreateDisposition.Always);

if (localSettings.Containers.ContainsKey("exampleContainer"))
{
   localSettings.Containers["exampleContainer"].Values["exampleSetting"] = "Hello Windows";
}
```

## <a name="delete-app-settings-and-containers"></a><span data-ttu-id="fcc32-277">アプリの設定とコンテナーを削除する</span><span class="sxs-lookup"><span data-stu-id="fcc32-277">Delete app settings and containers</span></span>


<span data-ttu-id="fcc32-278">アプリでもう必要のない簡易設定を削除するには、[**ApplicationDataContainerSettings.Remove**](https://msdn.microsoft.com/library/windows/apps/br241608) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-278">To delete a simple setting that your app no longer needs, use the [**ApplicationDataContainerSettings.Remove**](https://msdn.microsoft.com/library/windows/apps/br241608) method.</span></span> <span data-ttu-id="fcc32-279">この例では、前の手順で作成した `exampleSetting` ローカル設定を削除します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-279">This example deletesthe `exampleSetting` local setting that we created earlier.</span></span>

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Delete simple setting

localSettings.Values.Remove("exampleSetting");
```

<span data-ttu-id="fcc32-280">コンポジット設定を削除するには、[**ApplicationDataCompositeValue.Remove**](https://msdn.microsoft.com/library/windows/apps/br241597) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-280">To delete a composite setting, use the [**ApplicationDataCompositeValue.Remove**](https://msdn.microsoft.com/library/windows/apps/br241597) method.</span></span> <span data-ttu-id="fcc32-281">この例では、前の例で作成したローカルの `exampleCompositeSetting` コンポジット設定を削除します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-281">This example deletes the local `exampleCompositeSetting` composite setting we created in an earlier example.</span></span>

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Delete composite setting

localSettings.Values.Remove("exampleCompositeSetting");
```

<span data-ttu-id="fcc32-282">コンテナーを削除するには、[**ApplicationDataContainer.DeleteContainer**](https://msdn.microsoft.com/library/windows/apps/br241612) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-282">To delete a container, call the [**ApplicationDataContainer.DeleteContainer**](https://msdn.microsoft.com/library/windows/apps/br241612) method.</span></span> <span data-ttu-id="fcc32-283">この例では、前の手順で作成したローカルの `exampleContainer` 設定コンテナーを削除します。</span><span class="sxs-lookup"><span data-stu-id="fcc32-283">This example deletes the local `exampleContainer` settings container we created earlier.</span></span>

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Delete container

localSettings.DeleteContainer("exampleContainer");
```

## <a name="versioning-your-app-data"></a><span data-ttu-id="fcc32-284">アプリ データのバージョン管理</span><span class="sxs-lookup"><span data-stu-id="fcc32-284">Versioning your app data</span></span>


<span data-ttu-id="fcc32-285">必要に応じて、アプリのアプリ データをバージョン管理することもできます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-285">You can optionally version the app data for your app.</span></span> <span data-ttu-id="fcc32-286">これにより、将来作成するアプリのバージョンでアプリ データの形式を変更しても、以前のバージョンとの互換性に問題が起こりません。</span><span class="sxs-lookup"><span data-stu-id="fcc32-286">This would enable you to create a future version of your app that changes the format of its app data without causing compatibility problems with the previous version of your app.</span></span> <span data-ttu-id="fcc32-287">データ ストア内のアプリ データのバージョンをアプリが確認し、以前のバージョンであった場合、アプリ データは新しい形式に更新され、バージョンも更新されます。</span><span class="sxs-lookup"><span data-stu-id="fcc32-287">The app checks the version of the app data in the data store, and if the version is less than the version the app expects, the app should update the app data to the new format and update the version.</span></span> <span data-ttu-id="fcc32-288">詳しくは、「[**Application.Version**](https://msdn.microsoft.com/library/windows/apps/br241630) プロパティ」と「[**ApplicationData.SetVersionAsync**](https://msdn.microsoft.com/library/windows/apps/hh701429) メソッド」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fcc32-288">For more info, see the[**Application.Version**](https://msdn.microsoft.com/library/windows/apps/br241630) property and the [**ApplicationData.SetVersionAsync**](https://msdn.microsoft.com/library/windows/apps/hh701429) method.</span></span>

## <a name="related-articles"></a><span data-ttu-id="fcc32-289">関連記事</span><span class="sxs-lookup"><span data-stu-id="fcc32-289">Related articles</span></span>

* [**<span data-ttu-id="fcc32-290">Windows.Storage.ApplicationData</span><span class="sxs-lookup"><span data-stu-id="fcc32-290">Windows.Storage.ApplicationData</span></span>**](https://msdn.microsoft.com/library/windows/apps/br241587)
* [**<span data-ttu-id="fcc32-291">Windows.Storage.ApplicationData.RoamingSettings</span><span class="sxs-lookup"><span data-stu-id="fcc32-291">Windows.Storage.ApplicationData.RoamingSettings</span></span>**](https://msdn.microsoft.com/library/windows/apps/br241624)
* [**<span data-ttu-id="fcc32-292">Windows.Storage.ApplicationData.RoamingFolder</span><span class="sxs-lookup"><span data-stu-id="fcc32-292">Windows.Storage.ApplicationData.RoamingFolder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br241623)
* [**<span data-ttu-id="fcc32-293">Windows.Storage.ApplicationData.RoamingStorageQuota</span><span class="sxs-lookup"><span data-stu-id="fcc32-293">Windows.Storage.ApplicationData.RoamingStorageQuota</span></span>**](https://msdn.microsoft.com/library/windows/apps/br241625)
* [**<span data-ttu-id="fcc32-294">Windows.Storage.ApplicationDataCompositeValue</span><span class="sxs-lookup"><span data-stu-id="fcc32-294">Windows.Storage.ApplicationDataCompositeValue</span></span>**](https://msdn.microsoft.com/library/windows/apps/br241588)
