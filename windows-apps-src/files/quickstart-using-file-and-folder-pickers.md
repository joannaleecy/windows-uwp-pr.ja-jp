---
author: laurenhughes
ms.assetid: F87DBE2F-77DB-4573-8172-29E11ABEFD34
title: ピッカーでファイルやフォルダーを開く
description: ユーザーがピッカーを操作してファイルやフォルダーにアクセスできるようにします。 ファイルへのアクセスには FileOpenPicker クラスと FileSavePicker クラス、フォルダーへのアクセスには FolderPicker を使います。
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b79bfa9ecdf76d2d59e3c0991240d88599dbe6dd
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7145114"
---
# <a name="open-files-and-folders-with-a-picker"></a><span data-ttu-id="bfbf8-105">ピッカーでファイルやフォルダーを開く</span><span class="sxs-lookup"><span data-stu-id="bfbf8-105">Open files and folders with a picker</span></span>

**<span data-ttu-id="bfbf8-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="bfbf8-106">Important APIs</span></span>**

-   [**<span data-ttu-id="bfbf8-107">FileOpenPicker</span><span class="sxs-lookup"><span data-stu-id="bfbf8-107">FileOpenPicker</span></span>**](https://msdn.microsoft.com/library/windows/apps/br207847)
-   [**<span data-ttu-id="bfbf8-108">FolderPicker</span><span class="sxs-lookup"><span data-stu-id="bfbf8-108">FolderPicker</span></span>**](https://msdn.microsoft.com/library/windows/apps/br207881)
-   [**<span data-ttu-id="bfbf8-109">StorageFile</span><span class="sxs-lookup"><span data-stu-id="bfbf8-109">StorageFile</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227171)

<span data-ttu-id="bfbf8-110">ユーザーがピッカーを操作してファイルやフォルダーにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-110">Access files and folders by letting the user interact with a picker.</span></span> <span data-ttu-id="bfbf8-111">ファイルへのアクセスには [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラスと [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) クラス、フォルダーへのアクセスには [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881) を使います。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-111">You can use the [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) and [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) classes to access files, and the [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881) to access a folder.</span></span>

> [!NOTE]
> <span data-ttu-id="bfbf8-112">ファイル ピッカーのサンプルについては、[ファイル ピッカーのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=619994)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-112">For a complete sample, see the [File picker sample](http://go.microsoft.com/fwlink/p/?linkid=619994).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="bfbf8-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="bfbf8-113">Prerequisites</span></span>


-   **<span data-ttu-id="bfbf8-114">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解</span><span class="sxs-lookup"><span data-stu-id="bfbf8-114">Understand async programming for Universal Windows Platform (UWP) apps</span></span>**

    <span data-ttu-id="bfbf8-115">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-115">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="bfbf8-116">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-116">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   **<span data-ttu-id="bfbf8-117">場所へのアクセス許可</span><span class="sxs-lookup"><span data-stu-id="bfbf8-117">Access permissions to the location</span></span>**

    <span data-ttu-id="bfbf8-118">「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-118">See [File access permissions](file-access-permissions.md).</span></span>

## <a name="file-picker-ui"></a><span data-ttu-id="bfbf8-119">ファイル ピッカーの UI</span><span class="sxs-lookup"><span data-stu-id="bfbf8-119">File picker UI</span></span>


<span data-ttu-id="bfbf8-120">ファイル ピッカーには、ユーザーを指示する情報やユーザーがファイルを開くまたは保存するときの一貫したエクスペリエンスを提供する情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-120">A file picker displays information to orient users and provide a consistent experience when opening or saving files.</span></span>

<span data-ttu-id="bfbf8-121">次の情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-121">That information includes:</span></span>

-   <span data-ttu-id="bfbf8-122">現在の場所</span><span class="sxs-lookup"><span data-stu-id="bfbf8-122">The current location</span></span>
-   <span data-ttu-id="bfbf8-123">ユーザーが選んだ項目</span><span class="sxs-lookup"><span data-stu-id="bfbf8-123">The item or items that the user picked</span></span>
-   <span data-ttu-id="bfbf8-124">ユーザーが参照できる場所のツリー。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-124">A tree of locations that the user can browse to.</span></span> <span data-ttu-id="bfbf8-125">これらの場所には、ファイル システム上の場所 (音楽フォルダーやダウンロード フォルダーなど) のほか、ファイル ピッカー コントラクトを実装するアプリ (カメラ、フォト、Microsoft OneDrive など) も含まれます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-125">These locations include file system locations—such as the Music or Downloads folder—as well as apps that implement the file picker contract (such as Camera, Photos, and Microsoft OneDrive).</span></span>

<span data-ttu-id="bfbf8-126">メール アプリで添付ファイルを選ぶ機能にファイル ピッカーが表示される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-126">An email app might display a file picker for the user to pick attachments.</span></span>

![2 つのファイルが開く対象として選ばれているファイル ピッカー。](images/picker-multifile-600px.png)

## <a name="how-pickers-work"></a><span data-ttu-id="bfbf8-128">ピッカーのしくみ</span><span class="sxs-lookup"><span data-stu-id="bfbf8-128">How pickers work</span></span>


<span data-ttu-id="bfbf8-129">アプリでは、ファイル ピッカーを使ってユーザーのシステム上のファイルとフォルダーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-129">With a picker your app can access, browse, and save files and folders on the user's system.</span></span> <span data-ttu-id="bfbf8-130">アプリではこれらの選択を [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトと [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) オブジェクトとして受け取ることにより、それらを操作できます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-130">Your app receives those picks as [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) and [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) objects, which you can then operate on.</span></span>

<span data-ttu-id="bfbf8-131">ピッカーは単一の統一されたインターフェイスを使用して、ユーザーがファイル システムや他のアプリからファイルやフォルダーを選べるように表示します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-131">The picker uses a single, unified interface to let the user pick files and folders from the file system or from other apps.</span></span> <span data-ttu-id="bfbf8-132">他のアプリから選ばれたファイルは、ファイル システムから選ばれたファイルと同様に、[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトとして返されます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-132">Files picked from other apps are like files from the file system: they are returned as [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) objects.</span></span> <span data-ttu-id="bfbf8-133">通常、アプリはそれらのオブジェクトも、他のオブジェクトと同じ方法で操作できます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-133">In general, your app can operate on them in the same ways as other objects.</span></span> <span data-ttu-id="bfbf8-134">他のアプリは、ファイル ピッカー コントラクトに参加することで、ユーザーにファイルを表示します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-134">Other apps make files available by participating in file picker contracts.</span></span> <span data-ttu-id="bfbf8-135">ファイル、保存場所、またはファイルの更新を他のアプリに提供する場合は、「[ファイル ピッカー コントラクトとの統合](https://msdn.microsoft.com/library/windows/apps/hh465192)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-135">If you want your app to provide files, a save location, or file updates to other apps, see [Integrating with file picker contracts](https://msdn.microsoft.com/library/windows/apps/hh465192).</span></span>

<span data-ttu-id="bfbf8-136">たとえば、アプリでファイル ピッカーを呼び出し、ユーザーにファイルを開くように促すことができます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-136">For example, you might call the file picker in your app so that your user can open a file.</span></span> <span data-ttu-id="bfbf8-137">この場合、アプリは呼び出し元アプリになります。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-137">This makes your app the calling app.</span></span> <span data-ttu-id="bfbf8-138">ファイル ピッカーは、システムや他のアプリと情報をやり取りして、ユーザーがファイルを探して選べるようにします。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-138">The file picker interacts with the system and/or other apps to let the user navigate and pick the file.</span></span> <span data-ttu-id="bfbf8-139">ユーザーがファイルを選ぶと、ファイル ピッカーはそのファイルをアプリに返します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-139">When your user chooses a file, the file picker returns that file to your app.</span></span> <span data-ttu-id="bfbf8-140">ここでは、ユーザーが OneDrive のような提供元アプリからファイルを選ぶ場合のプロセスを示しています。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-140">Here's the process for the case of the user choosing a file from a providing app, such as OneDrive.</span></span>

![ファイル ピッカーを 2 つのアプリの間のインターフェイスとして使って、一方のアプリのファイルをもう一方のアプリから開くプロセスを示す図。](images/app-to-app-diagram-600px.png)

## <a name="pick-a-single-file-complete-code-listing"></a><span data-ttu-id="bfbf8-142">1 つのファイルを選ぶ: 完全なコード</span><span class="sxs-lookup"><span data-stu-id="bfbf8-142">Pick a single file: complete code listing</span></span>


```cs
var picker = new Windows.Storage.Pickers.FileOpenPicker();
picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
picker.FileTypeFilter.Add(".jpg");
picker.FileTypeFilter.Add(".jpeg");
picker.FileTypeFilter.Add(".png");

Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
if (file != null)
{
    // Application now has read/write access to the picked file
    this.textBlock.Text = "Picked photo: " + file.Name;
}
else
{
    this.textBlock.Text = "Operation cancelled.";
}
```

## <a name="pick-a-single-file-step-by-step"></a><span data-ttu-id="bfbf8-143">1 つのファイルを選ぶ: ステップ バイ ステップ</span><span class="sxs-lookup"><span data-stu-id="bfbf8-143">Pick a single file: step-by-step</span></span>


<span data-ttu-id="bfbf8-144">ファイル ピッカーが動作するには、ファイル ピッカー オブジェクトを作成してカスタマイズし、ユーザーが項目を選べるようにそのファイル ピッカーを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-144">Using a file picker involves creating and customizing a file picker object, and then showing the file picker so the user can pick one or more items.</span></span>

1.  **<span data-ttu-id="bfbf8-145">FileOpenPicker を作成してカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="bfbf8-145">Create and customize a FileOpenPicker</span></span>**

    ```cs
    var picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
    picker.FileTypeFilter.Add(".jpg");
    picker.FileTypeFilter.Add(".jpeg");
    picker.FileTypeFilter.Add(".png");
    ```
    <span data-ttu-id="bfbf8-146">ファイル ピッカー オブジェクトの、ユーザーとアプリに関連するプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-146">Set properties on the file picker object relevant to your users and app.</span></span>

    <span data-ttu-id="bfbf8-147">この例では、[**ViewMode**](https://msdn.microsoft.com/library/windows/apps/br207855)、[**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854)、および [**FileTypeFilter**](https://msdn.microsoft.com/library/windows/apps/br207850) という 3 つのプロパティを設定して、ユーザーが画像ファイルを選べる視覚的に優れた表示を作成し、使いやすい場所に配置します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-147">This example creates a rich, visual display of pictures in a convenient location that the user can pick from by setting three properties: [**ViewMode**](https://msdn.microsoft.com/library/windows/apps/br207855), [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854), and [**FileTypeFilter**](https://msdn.microsoft.com/library/windows/apps/br207850).</span></span>

    -   <span data-ttu-id="bfbf8-148">[**ViewMode**](https://msdn.microsoft.com/library/windows/apps/br207855) を [**PickerViewMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#thumbnail)**Thumbnail** 列挙値に設定すると、ファイル ピッカーで画像ファイルが縮小表示の画像で表され、視覚的に優れた表示が作成されます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-148">Setting [**ViewMode**](https://msdn.microsoft.com/library/windows/apps/br207855) to the [**PickerViewMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#thumbnail) **Thumbnail** enum value creates a rich, visual display by using picture thumbnails to represent files in the file picker.</span></span> <span data-ttu-id="bfbf8-149">これは、画像やビデオなどの視覚的なファイルを選ぶ場合に設定します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-149">Do this for picking visual files such as pictures or videos.</span></span> <span data-ttu-id="bfbf8-150">それ以外の場合は、[**PickerViewMode.List**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#list) を使います。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-150">Otherwise, use [**PickerViewMode.List**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#list).</span></span> <span data-ttu-id="bfbf8-151">**画像またはビデオの添付**機能と**ドキュメントの添付**機能がある架空のメール アプリでは、ファイル ピッカーを表示する前に **ViewMode** をそれらの機能に対応させます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-151">A hypothetical email app with **Attach Picture or Video** and **Attach Document** features would set the **ViewMode** appropriate to the feature before showing the file picker.</span></span>

    -   <span data-ttu-id="bfbf8-152">[**PickerLocationId.PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br207890) を使って [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) を Pictures に設定すると、画像を見つけられる可能性が高い場所が最初に表示されます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-152">Setting [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) to Pictures using [**PickerLocationId.PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br207890) starts the user in a location where they're likely to find pictures.</span></span> <span data-ttu-id="bfbf8-153">選ぶファイルの種類 (音楽、画像、ビデオ、ドキュメントなど) に合わせて **SuggestedStartLocation** を設定します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-153">Set **SuggestedStartLocation** to a location appropriate for the type of file being picked, for example Music, Pictures, Videos, or Documents.</span></span> <span data-ttu-id="bfbf8-154">ユーザーは、開始場所から別の場所に移動できます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-154">From the start location, the user can navigate to other locations.</span></span>

    -   <span data-ttu-id="bfbf8-155">[**FileTypeFilter**](https://msdn.microsoft.com/library/windows/apps/br207850) を使うと、関連性の高いファイルの種類に絞ってユーザーがファイルを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-155">Using [**FileTypeFilter**](https://msdn.microsoft.com/library/windows/apps/br207850) to specify file types keeps the user focused on picking files that are relevant.</span></span> <span data-ttu-id="bfbf8-156">**FileTypeFilter** の以前のファイルの種類を新しいエントリに置き換えるには、[**Add**](https://msdn.microsoft.com/library/windows/apps/br207834) ではなく [**ReplaceAll**](https://msdn.microsoft.com/library/windows/apps/br207844) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-156">To replace previous file types in the **FileTypeFilter** with new entries, use [**ReplaceAll**](https://msdn.microsoft.com/library/windows/apps/br207844) instead of [**Add**](https://msdn.microsoft.com/library/windows/apps/br207834).</span></span>

2.  **<span data-ttu-id="bfbf8-157">FileOpenPicker を表示する</span><span class="sxs-lookup"><span data-stu-id="bfbf8-157">Show the FileOpenPicker</span></span>**

    - **<span data-ttu-id="bfbf8-158">単一のファイルを選ぶには</span><span class="sxs-lookup"><span data-stu-id="bfbf8-158">To pick a single file</span></span>**

    ```cs
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
    if (file != null)
    {
        // Application now has read/write access to the picked file
        this.textBlock.Text = "Picked photo: " + file.Name;
    }
    else
    {
        this.textBlock.Text = "Operation cancelled.";
    }
    ```

    - **<span data-ttu-id="bfbf8-159">複数のファイルを選ぶには</span><span class="sxs-lookup"><span data-stu-id="bfbf8-159">To pick multiple files</span></span>**  

    ```cs
    var files = await picker.PickMultipleFilesAsync();
    if (files.Count > 0)
    {
        StringBuilder output = new StringBuilder("Picked files:\n");

        // Application now has read/write access to the picked file(s)
        foreach (Windows.Storage.StorageFile file in files)
        {
            output.Append(file.Name + "\n");
        }
        this.textBlock.Text = output.ToString();
    }
    else
    {
        this.textBlock.Text = "Operation cancelled.";
    }
    ```

## <a name="pick-a-folder-complete-code-listing"></a><span data-ttu-id="bfbf8-160">フォルダーを選ぶ: 完全なコード</span><span class="sxs-lookup"><span data-stu-id="bfbf8-160">Pick a folder: complete code listing</span></span>


```cs
var folderPicker = new Windows.Storage.Pickers.FolderPicker();
folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
folderPicker.FileTypeFilter.Add("*");

Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
if (folder != null)
{
    // Application now has read/write access to all contents in the picked folder
    // (including other sub-folder contents)
    Windows.Storage.AccessCache.StorageApplicationPermissions.
    FutureAccessList.AddOrReplace("PickedFolderToken", folder);
    this.textBlock.Text = "Picked folder: " + folder.Name;
}
else
{
    this.textBlock.Text = "Operation cancelled.";
}
```

> [!TIP]
> <span data-ttu-id="bfbf8-161">アプリがピッカーでファイルまたはフォルダーにアクセスするたびに、ファイルやフォルダーをアプリの [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) または [**MostRecentlyUsedList**](https://msdn.microsoft.com/library/windows/apps/br207458) に追加して、ファイルやフォルダーを追跡します。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-161">Whenever your app accesses a file or folder through a picker, add it to your app's [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) or [**MostRecentlyUsedList**](https://msdn.microsoft.com/library/windows/apps/br207458) to keep track of it.</span></span> <span data-ttu-id="bfbf8-162">これらのリストの使用の詳細については、「[最近使ったファイルやフォルダーを追跡する方法](how-to-track-recently-used-files-and-folders.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bfbf8-162">You can learn more about using these lists in [How to track recently-used files and folders](how-to-track-recently-used-files-and-folders.md).</span></span>