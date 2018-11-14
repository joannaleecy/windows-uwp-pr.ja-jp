---
author: laurenhughes
ms.assetid: 8BDDE64A-77D2-4F9D-A1A0-E4C634BCD890
title: ピッカーによるファイルの保存
description: FileSavePicker を使って、ユーザーがアプリで保存するファイルの名前とその保存場所を指定できるようにします。
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2a053047324fcb795a30951d70c5e0e78fbb5547
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6447753"
---
# <a name="save-a-file-with-a-picker"></a><span data-ttu-id="cecbd-104">ピッカーによるファイルの保存</span><span class="sxs-lookup"><span data-stu-id="cecbd-104">Save a file with a picker</span></span>

**<span data-ttu-id="cecbd-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="cecbd-105">Important APIs</span></span>**

-   [**<span data-ttu-id="cecbd-106">FileSavePicker</span><span class="sxs-lookup"><span data-stu-id="cecbd-106">FileSavePicker</span></span>**](https://msdn.microsoft.com/library/windows/apps/br207871)
-   [**<span data-ttu-id="cecbd-107">StorageFile</span><span class="sxs-lookup"><span data-stu-id="cecbd-107">StorageFile</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227171)

<span data-ttu-id="cecbd-108">[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、アプリで保存するファイルの名前とその保存場所をユーザーが指定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="cecbd-108">Use [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) to let users specify the name and location where they want your app to save a file.</span></span>

> [!NOTE]
> <span data-ttu-id="cecbd-109">また、[ファイル ピッカーのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619994)に関するページも参照してください。</span><span class="sxs-lookup"><span data-stu-id="cecbd-109">Also see the [File picker sample](http://go.microsoft.com/fwlink/p/?linkid=619994).</span></span>

 

## <a name="prerequisites"></a><span data-ttu-id="cecbd-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="cecbd-110">Prerequisites</span></span>


-   **<span data-ttu-id="cecbd-111">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解</span><span class="sxs-lookup"><span data-stu-id="cecbd-111">Understand async programming for Universal Windows Platform (UWP) apps</span></span>**

    <span data-ttu-id="cecbd-112">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cecbd-112">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="cecbd-113">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cecbd-113">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   **<span data-ttu-id="cecbd-114">場所へのアクセス許可</span><span class="sxs-lookup"><span data-stu-id="cecbd-114">Access permissions to the location</span></span>**

    <span data-ttu-id="cecbd-115">「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cecbd-115">See [File access permissions](file-access-permissions.md).</span></span>

## <a name="filesavepicker-step-by-step"></a><span data-ttu-id="cecbd-116">FileSavePicker: 手順</span><span class="sxs-lookup"><span data-stu-id="cecbd-116">FileSavePicker: step-by-step</span></span>

<span data-ttu-id="cecbd-117">[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、ユーザーが保存するファイルの名前、種類、場所を指定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="cecbd-117">Use a [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) so that your users can specify the name, type, and location of a file to save.</span></span> <span data-ttu-id="cecbd-118">ファイル ピッカー オブジェクトを作成、カスタマイズ、および表示し、選ばれたファイルを表す返された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使ってデータを保存します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-118">Create, customize, and show a file picker object, and then save data via the returned [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object that represents the file picked.</span></span>

1.  **<span data-ttu-id="cecbd-119">FileSavePicker を作成してカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="cecbd-119">Create and customize the FileSavePicker</span></span>**

```cs
var savePicker = new Windows.Storage.Pickers.FileSavePicker();
savePicker.SuggestedStartLocation =
    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
// Dropdown of file types the user can save the file as
savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
// Default file name if the user does not type one in or select a file to replace
savePicker.SuggestedFileName = "New Document";
```

<span data-ttu-id="cecbd-120">ファイル ピッカー オブジェクトの、ユーザーとアプリに関連するプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-120">Set properties on the file picker object that are relevant to your users and your app.</span></span>

<span data-ttu-id="cecbd-121">この例では、3 つのプロパティ [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880)、[**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875)、および [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878) を設定します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-121">This example sets three properties: [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880), [**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875) and [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878).</span></span>

> [!NOTE]
><span data-ttu-id="cecbd-122">[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) オブジェクトは、[**PickerViewMode.List**](https://msdn.microsoft.com/library/windows/apps/br207891) を使ってファイル ピッカーを表示します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-122">[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) objects display the file picker using the [**PickerViewMode.List**](https://msdn.microsoft.com/library/windows/apps/br207891).</span></span>
     
- <span data-ttu-id="cecbd-123">このサンプルでは [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) を使って、ドキュメントまたはテキスト ファイルを保存する場所として [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880) をアプリのローカル フォルダーに設定しています。</span><span class="sxs-lookup"><span data-stu-id="cecbd-123">Because our user is saving a document or text file, the sample sets [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880) to the app's local folder by using [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621).</span></span> <span data-ttu-id="cecbd-124">[**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) を保存するファイルの種類 (音楽、画像、ビデオ、ドキュメントなど) に適切な場所に設定します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-124">Set [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) to a location appropriate for the type of file being saved, for example Music, Pictures, Videos, or Documents.</span></span> <span data-ttu-id="cecbd-125">ユーザーは、開始場所から別の場所に移動できます。</span><span class="sxs-lookup"><span data-stu-id="cecbd-125">From the start location, the user can navigate to other locations.</span></span>

- <span data-ttu-id="cecbd-126">サンプルでは、保存したファイルを確実にアプリから開くことができるように、サポートするファイルの種類 (Microsoft Word 文書とテキスト ファイル) を [**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875) を使って指定しています。</span><span class="sxs-lookup"><span data-stu-id="cecbd-126">Because we want to make sure our app can open the file after it is saved, we use [**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875) to specify file types that the sample supports (Microsoft Word documents and text files).</span></span> <span data-ttu-id="cecbd-127">指定したすべてのファイルの種類をアプリはサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cecbd-127">Make sure all the file types that you specify are supported by your app.</span></span> <span data-ttu-id="cecbd-128">ユーザーは、ファイルの種類を指定して保存できます。</span><span class="sxs-lookup"><span data-stu-id="cecbd-128">Users will be able to save their file as any of the file types you specify.</span></span> <span data-ttu-id="cecbd-129">また、別のファイルの種類を選んで、ファイルの種類を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="cecbd-129">They can also change the file type by selecting another of the file types that you specified.</span></span> <span data-ttu-id="cecbd-130">既定では、リストの先頭にあるファイルの種類が選択されます。これを制御するには、[**DefaultFileExtension**](https://msdn.microsoft.com/library/windows/apps/br207873) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-130">The first file type choice in the list will be selected by default: to control that, set the [**DefaultFileExtension**](https://msdn.microsoft.com/library/windows/apps/br207873) property.</span></span>

> [!NOTE]
> <span data-ttu-id="cecbd-131">また、ファイル ピッカーでは、現在選ばれているファイルの種類を使って表示されるファイルがフィルター処理され、選ばれているファイルの種類に一致するファイルの種類だけがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="cecbd-131">The file picker also uses the currently selected file type to filter which files it displays, so that only file types that match the selected files types are displayed to the user.</span></span>

- <span data-ttu-id="cecbd-132">ユーザーの入力の手間を多少なりとも軽減するために、この例では [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878) を設定しています。</span><span class="sxs-lookup"><span data-stu-id="cecbd-132">To save the user some typing, the example sets a [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878).</span></span> <span data-ttu-id="cecbd-133">提示するファイル名は、ユーザーが保存するファイルにできる限り関係のあるものにします。</span><span class="sxs-lookup"><span data-stu-id="cecbd-133">Make your suggested file name relevant to the file being saved.</span></span> <span data-ttu-id="cecbd-134">たとえば、Word のように、ファイルが既にある場合はその名前を提示し、まだ名前のないファイルを保存している場合はドキュメントの 1 行目を提示します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-134">For example, like Word, you can suggest the existing file name if there is one, or the first line of a document if the user is saving a file that does not yet have a name.</span></span>

2.  **<span data-ttu-id="cecbd-135">FileSavePicker を表示して選ばれたファイルに保存する</span><span class="sxs-lookup"><span data-stu-id="cecbd-135">Show the FileSavePicker and save to the picked file</span></span>**

    <span data-ttu-id="cecbd-136">ファイル ピッカーを表示するには、[**PickSaveFileAsync**](https://msdn.microsoft.com/library/windows/apps/br207876) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-136">Display the file picker by calling [**PickSaveFileAsync**](https://msdn.microsoft.com/library/windows/apps/br207876).</span></span> <span data-ttu-id="cecbd-137">ユーザーが名前、ファイルの種類、場所を指定し、ファイルの保存を確定すると、**PickSaveFileAsync** は保存するファイルを表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="cecbd-137">After the user specifies the name, file type, and location, and confirms to save the file, **PickSaveFileAsync** returns a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object that represents the saved file.</span></span> <span data-ttu-id="cecbd-138">これでファイルの読み取りおよび書き込みアクセスが付与されるため、このファイルをキャプチャして処理できます。</span><span class="sxs-lookup"><span data-stu-id="cecbd-138">You can capture and process this file now that you have read and write access to it.</span></span>

    ```cs
    Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
        if (file != null)
        {
            // Prevent updates to the remote version of the file until
            // we finish making changes and call CompleteUpdatesAsync.
            Windows.Storage.CachedFileManager.DeferUpdates(file);
            // write to file
            await Windows.Storage.FileIO.WriteTextAsync(file, file.Name);
            // Let Windows know that we're finished changing the file so
            // the other app can update the remote version of the file.
            // Completing updates may require Windows to ask for user input.
            Windows.Storage.Provider.FileUpdateStatus status =
                await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
            if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
            {
                this.textBlock.Text = "File " + file.Name + " was saved.";
            }
            else
            {
                this.textBlock.Text = "File " + file.Name + " couldn't be saved.";
            }
        }
        else
        {
            this.textBlock.Text = "Operation cancelled.";
        }
    ```

<span data-ttu-id="cecbd-139">この例では、ファイルが有効であることをチェックし、ファイルにそのファイル名を書き込みます。</span><span class="sxs-lookup"><span data-stu-id="cecbd-139">The example checks that the file is valid and writes its own file name into it.</span></span> <span data-ttu-id="cecbd-140">また、「[ファイルの作成、書き込み、および読み取り](quickstart-reading-and-writing-files.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cecbd-140">Also see [Creating, writing, and reading a file](quickstart-reading-and-writing-files.md).</span></span>

<span data-ttu-id="cecbd-141">**ヒント:** が有効で、他の処理を実行する前に確認を保存したファイルを常に確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cecbd-141">**Tip**You should always check the saved file to make sure it is valid before you perform any other processing.</span></span> <span data-ttu-id="cecbd-142">その後、アプリに適したコンテンツをファイルに保存できるほか、選ばれたファイルが有効でない場合は適切な動作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="cecbd-142">Then, you can save content to the file as appropriate for your app, and provide appropriate behavior if the picked file is not valid.</span></span>
