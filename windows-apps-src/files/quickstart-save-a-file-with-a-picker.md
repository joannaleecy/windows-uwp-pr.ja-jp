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
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7556881"
---
# <a name="save-a-file-with-a-picker"></a>ピッカーによるファイルの保存

**重要な API**

-   [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871)
-   [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171)

[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、アプリで保存するファイルの名前とその保存場所をユーザーが指定できるようにします。

> [!NOTE]
> また、[ファイル ピッカーのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619994)に関するページも参照してください。

 

## <a name="prerequisites"></a>前提条件


-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

-   **場所へのアクセス許可**

    「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。

## <a name="filesavepicker-step-by-step"></a>FileSavePicker: 手順

[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使って、ユーザーが保存するファイルの名前、種類、場所を指定できるようにします。 ファイル ピッカー オブジェクトを作成、カスタマイズ、および表示し、選ばれたファイルを表す返された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使ってデータを保存します。

1.  **FileSavePicker を作成してカスタマイズする**

```cs
var savePicker = new Windows.Storage.Pickers.FileSavePicker();
savePicker.SuggestedStartLocation =
    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
// Dropdown of file types the user can save the file as
savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
// Default file name if the user does not type one in or select a file to replace
savePicker.SuggestedFileName = "New Document";
```

ファイル ピッカー オブジェクトの、ユーザーとアプリに関連するプロパティを設定します。

この例では、3 つのプロパティ [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880)、[**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875)、および [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878) を設定します。

> [!NOTE]
>[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) オブジェクトは、[**PickerViewMode.List**](https://msdn.microsoft.com/library/windows/apps/br207891) を使ってファイル ピッカーを表示します。
     
- このサンプルでは [**LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) を使って、ドキュメントまたはテキスト ファイルを保存する場所として [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207880) をアプリのローカル フォルダーに設定しています。 [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) を保存するファイルの種類 (音楽、画像、ビデオ、ドキュメントなど) に適切な場所に設定します。 ユーザーは、開始場所から別の場所に移動できます。

- サンプルでは、保存したファイルを確実にアプリから開くことができるように、サポートするファイルの種類 (Microsoft Word 文書とテキスト ファイル) を [**FileTypeChoices**](https://msdn.microsoft.com/library/windows/apps/br207875) を使って指定しています。 指定したすべてのファイルの種類をアプリはサポートする必要があります。 ユーザーは、ファイルの種類を指定して保存できます。 また、別のファイルの種類を選んで、ファイルの種類を変更することもできます。 既定では、リストの先頭にあるファイルの種類が選択されます。これを制御するには、[**DefaultFileExtension**](https://msdn.microsoft.com/library/windows/apps/br207873) プロパティを設定します。

> [!NOTE]
> また、ファイル ピッカーでは、現在選ばれているファイルの種類を使って表示されるファイルがフィルター処理され、選ばれているファイルの種類に一致するファイルの種類だけがユーザーに表示されます。

- ユーザーの入力の手間を多少なりとも軽減するために、この例では [**SuggestedFileName**](https://msdn.microsoft.com/library/windows/apps/br207878) を設定しています。 提示するファイル名は、ユーザーが保存するファイルにできる限り関係のあるものにします。 たとえば、Word のように、ファイルが既にある場合はその名前を提示し、まだ名前のないファイルを保存している場合はドキュメントの 1 行目を提示します。

2.  **FileSavePicker を表示して選ばれたファイルに保存する**

    ファイル ピッカーを表示するには、[**PickSaveFileAsync**](https://msdn.microsoft.com/library/windows/apps/br207876) メソッドを呼び出します。 ユーザーが名前、ファイルの種類、場所を指定し、ファイルの保存を確定すると、**PickSaveFileAsync** は保存するファイルを表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを返します。 これでファイルの読み取りおよび書き込みアクセスが付与されるため、このファイルをキャプチャして処理できます。

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

この例では、ファイルが有効であることをチェックし、ファイルにそのファイル名を書き込みます。 また、「[ファイルの作成、書き込み、および読み取り](quickstart-reading-and-writing-files.md)」もご覧ください。

**ヒント:** が有効で、他の処理を実行する前に確認を保存したファイルを常に確認する必要があります。 その後、アプリに適したコンテンツをファイルに保存できるほか、選ばれたファイルが有効でない場合は適切な動作を実行できます。
