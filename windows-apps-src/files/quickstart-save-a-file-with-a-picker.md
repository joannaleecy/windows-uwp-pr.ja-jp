---
ms.assetid: 8BDDE64A-77D2-4F9D-A1A0-E4C634BCD890
title: ピッカーによるファイルの保存
description: FileSavePicker を使って、アプリで保存するファイルの名前とその保存場所をユーザーが指定できるようにします。
ms.date: 12/19/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 4c61a34b983b0faaedc509b68fd4225ea0859a7d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660527"
---
# <a name="save-a-file-with-a-picker"></a><span data-ttu-id="17b02-104">ピッカーによるファイルの保存</span><span class="sxs-lookup"><span data-stu-id="17b02-104">Save a file with a picker</span></span>

<span data-ttu-id="17b02-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="17b02-105">**Important APIs**</span></span>

-   [<span data-ttu-id="17b02-106">**FileSavePicker**</span><span class="sxs-lookup"><span data-stu-id="17b02-106">**FileSavePicker**</span></span>](https://msdn.microsoft.com/library/windows/apps/br207871)
-   [<span data-ttu-id="17b02-107">**StorageFile**</span><span class="sxs-lookup"><span data-stu-id="17b02-107">**StorageFile**</span></span>](https://msdn.microsoft.com/library/windows/apps/br227171)

<span data-ttu-id="17b02-108">[  **FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使ってユーザーがアプリで保存するファイルの名前とその保存場所を指定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="17b02-108">Use [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) to let users specify the name and location where they want your app to save a file.</span></span>

> [!NOTE]
><span data-ttu-id="17b02-109"> 完全なサンプルを参照してください、[ファイル ピッカー サンプル](https://go.microsoft.com/fwlink/p/?linkid=619994)します。</span><span class="sxs-lookup"><span data-stu-id="17b02-109"> For a complete sample, see the [File picker sample](https://go.microsoft.com/fwlink/p/?linkid=619994).</span></span>

 

## <a name="prerequisites"></a><span data-ttu-id="17b02-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="17b02-110">Prerequisites</span></span>


-   <span data-ttu-id="17b02-111">**ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングを理解します。**</span><span class="sxs-lookup"><span data-stu-id="17b02-111">**Understand async programming for Universal Windows Platform (UWP) apps**</span></span>

    <span data-ttu-id="17b02-112">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="17b02-112">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="17b02-113">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="17b02-113">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   <span data-ttu-id="17b02-114">**場所へのアクセス許可**</span><span class="sxs-lookup"><span data-stu-id="17b02-114">**Access permissions to the location**</span></span>

    <span data-ttu-id="17b02-115">「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="17b02-115">See [File access permissions](file-access-permissions.md).</span></span>

## <a name="filesavepicker-step-by-step"></a><span data-ttu-id="17b02-116">FileSavePicker: 手順</span><span class="sxs-lookup"><span data-stu-id="17b02-116">FileSavePicker: step-by-step</span></span>

<span data-ttu-id="17b02-117">[  **FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、ユーザーが保存するファイルの名前、種類、場所を指定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="17b02-117">Use a [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) so that your users can specify the name, type, and location of a file to save.</span></span> <span data-ttu-id="17b02-118">ファイル ピッカー オブジェクトを作成、カスタマイズ、および表示し、選ばれたファイルを表す返された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使ってデータを保存します。</span><span class="sxs-lookup"><span data-stu-id="17b02-118">Create, customize, and show a file picker object, and then save data via the returned [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object that represents the file picked.</span></span>

1.  <span data-ttu-id="17b02-119">**作成し、FileSavePicker をカスタマイズします。**</span><span class="sxs-lookup"><span data-stu-id="17b02-119">**Create and customize the FileSavePicker**</span></span>

    ```cs
    var savePicker = new Windows.Storage.Pickers.FileSavePicker();
    savePicker.SuggestedStartLocation =
        Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
    // Dropdown of file types the user can save the file as
    savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
    // Default file name if the user does not type one in or select a file to replace
    savePicker.SuggestedFileName = "New Document";
    ```

<span data-ttu-id="17b02-120">ファイル ピッカー オブジェクトの、ユーザーとアプリに関連するプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="17b02-120">Set properties on the file picker object that are relevant to your users and your app.</span></span> <span data-ttu-id="17b02-121">この例は、3 つのプロパティを設定します。[**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880)、 [ **FileTypeChoices** ](https://msdn.microsoft.com/library/windows/apps/br207875)と[ **SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878)します。</span><span class="sxs-lookup"><span data-stu-id="17b02-121">This example sets three properties: [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880), [**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875) and [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878).</span></span>
     
- <span data-ttu-id="17b02-122">このサンプルでは [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) を使って、ドキュメントまたはテキスト ファイルを保存する場所として [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880) をアプリのローカル フォルダーに設定しています。</span><span class="sxs-lookup"><span data-stu-id="17b02-122">Because our user is saving a document or text file, the sample sets [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880) to the app's local folder by using [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621).</span></span> <span data-ttu-id="17b02-123">[  **SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) を保存するファイルの種類 (音楽、画像、ビデオ、ドキュメントなど) に適切な場所に設定します。</span><span class="sxs-lookup"><span data-stu-id="17b02-123">Set [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) to a location appropriate for the type of file being saved, for example Music, Pictures, Videos, or Documents.</span></span> <span data-ttu-id="17b02-124">ユーザーは、開始場所から別の場所に移動できます。</span><span class="sxs-lookup"><span data-stu-id="17b02-124">From the start location, the user can navigate to other locations.</span></span>

- <span data-ttu-id="17b02-125">サンプルでは、保存したファイルを確実にアプリから開くことができるように、サポートするファイルの種類 (Microsoft Word 文書とテキスト ファイル) を [**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875) を使って指定しています。</span><span class="sxs-lookup"><span data-stu-id="17b02-125">Because we want to make sure our app can open the file after it is saved, we use [**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875) to specify file types that the sample supports (Microsoft Word documents and text files).</span></span> <span data-ttu-id="17b02-126">指定したすべてのファイルの種類をアプリはサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="17b02-126">Make sure all the file types that you specify are supported by your app.</span></span> <span data-ttu-id="17b02-127">ユーザーは、ファイルの種類を指定して保存できます。</span><span class="sxs-lookup"><span data-stu-id="17b02-127">Users will be able to save their file as any of the file types you specify.</span></span> <span data-ttu-id="17b02-128">また、別のファイルの種類を選んで、ファイルの種類を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="17b02-128">They can also change the file type by selecting another of the file types that you specified.</span></span> <span data-ttu-id="17b02-129">既定では、リストの先頭にあるファイルの種類が選択されます。これを制御するには、[**DefaultFileExtension**](https://msdn.microsoft.com/library/windows/apps/br207873) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="17b02-129">The first file type choice in the list will be selected by default: to control that, set the [**DefaultFileExtension**](https://msdn.microsoft.com/library/windows/apps/br207873) property.</span></span>

    > [!NOTE]
    ><span data-ttu-id="17b02-130"> ファイル ピッカーは、選択したファイルの種類に一致するファイルの種類のみがユーザーに表示されるように、表示するファイルをフィルター処理にも、現在選択されているファイルの種類を使用します。</span><span class="sxs-lookup"><span data-stu-id="17b02-130"> The file picker also uses the currently selected file type to filter which files it displays, so that only file types that match the selected files types are displayed to the user.</span></span>

- <span data-ttu-id="17b02-131">ユーザーの入力の手間を多少なりとも軽減するために、この例では [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878) を設定しています。</span><span class="sxs-lookup"><span data-stu-id="17b02-131">To save the user some typing, the example sets a [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878).</span></span> <span data-ttu-id="17b02-132">提示するファイル名は、ユーザーが保存するファイルにできる限り関係のあるものにします。</span><span class="sxs-lookup"><span data-stu-id="17b02-132">Make your suggested file name relevant to the file being saved.</span></span> <span data-ttu-id="17b02-133">たとえば、Word のように、ファイルが既にある場合はその名前を提示し、まだ名前のないファイルを保存している場合はドキュメントの 1 行目を提示します。</span><span class="sxs-lookup"><span data-stu-id="17b02-133">For example, like Word, you can suggest the existing file name if there is one, or the first line of a document if the user is saving a file that does not yet have a name.</span></span>

> [!NOTE]
><span data-ttu-id="17b02-134"> [*\*FileSavePicker** ](https://msdn.microsoft.com/library/windows/apps/br207871)オブジェクトを表示、ファイル ピッカーを使用して、 [ *\*PickerViewMode.List** ](https://msdn.microsoft.com/library/windows/apps/br207891)表示モード。</span><span class="sxs-lookup"><span data-stu-id="17b02-134"> [*\*FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) objects display the file picker using the [*\*PickerViewMode.List**](https://msdn.microsoft.com/library/windows/apps/br207891) view mode.</span></span>

2.  <span data-ttu-id="17b02-135">**FileSavePicker を表示し、選択されたファイルに保存**</span><span class="sxs-lookup"><span data-stu-id="17b02-135">**Show the FileSavePicker and save to the picked file**</span></span>

    <span data-ttu-id="17b02-136">ファイル ピッカーを表示するには、[**PickSaveFileAsync**](https://msdn.microsoft.com/library/windows/apps/br207876) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="17b02-136">Display the file picker by calling [**PickSaveFileAsync**](https://msdn.microsoft.com/library/windows/apps/br207876).</span></span> <span data-ttu-id="17b02-137">ユーザーが名前、ファイルの種類、場所を指定し、ファイルの保存を確定すると、**PickSaveFileAsync** は保存するファイルを表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="17b02-137">After the user specifies the name, file type, and location, and confirms to save the file, **PickSaveFileAsync** returns a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object that represents the saved file.</span></span> <span data-ttu-id="17b02-138">これでファイルの読み取りおよび書き込みアクセスが付与されるため、このファイルをキャプチャして処理できます。</span><span class="sxs-lookup"><span data-stu-id="17b02-138">You can capture and process this file now that you have read and write access to it.</span></span>

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

<span data-ttu-id="17b02-139">この例では、ファイルが有効であることをチェックし、ファイルにそのファイル名を書き込みます。</span><span class="sxs-lookup"><span data-stu-id="17b02-139">The example checks that the file is valid and writes its own file name into it.</span></span> <span data-ttu-id="17b02-140">また、「[ファイルの作成、書き込み、および読み取り](quickstart-reading-and-writing-files.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="17b02-140">Also see [Creating, writing, and reading a file](quickstart-reading-and-writing-files.md).</span></span>

> [!TIP]
><span data-ttu-id="17b02-141"> 確認が有効で、他の処理を実行する前に保存したファイルを常に確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="17b02-141"> You should always check the saved file to make sure it is valid before you perform any other processing.</span></span> <span data-ttu-id="17b02-142">その後、アプリに適したコンテンツをファイルに保存できるほか、選ばれたファイルが有効でない場合は適切な動作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="17b02-142">Then, you can save content to the file as appropriate for your app, and provide appropriate behavior if the picked file is not valid.</span></span>
