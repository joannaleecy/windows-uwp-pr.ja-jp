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
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6447497"
---
# <a name="open-files-and-folders-with-a-picker"></a>ピッカーでファイルやフォルダーを開く

**重要な API**

-   [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847)
-   [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881)
-   [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171)

ユーザーがピッカーを操作してファイルやフォルダーにアクセスできるようにします。 ファイルへのアクセスには [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラスと [**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) クラス、フォルダーへのアクセスには [**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/br207881) を使います。

> [!NOTE]
> ファイル ピッカーのサンプルについては、[ファイル ピッカーのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=619994)をご覧ください。

## <a name="prerequisites"></a>前提条件


-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

-   **場所へのアクセス許可**

    「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。

## <a name="file-picker-ui"></a>ファイル ピッカーの UI


ファイル ピッカーには、ユーザーを指示する情報やユーザーがファイルを開くまたは保存するときの一貫したエクスペリエンスを提供する情報が表示されます。

次の情報が含まれます。

-   現在の場所
-   ユーザーが選んだ項目
-   ユーザーが参照できる場所のツリー。 これらの場所には、ファイル システム上の場所 (音楽フォルダーやダウンロード フォルダーなど) のほか、ファイル ピッカー コントラクトを実装するアプリ (カメラ、フォト、Microsoft OneDrive など) も含まれます。

メール アプリで添付ファイルを選ぶ機能にファイル ピッカーが表示される場合もあります。

![2 つのファイルが開く対象として選ばれているファイル ピッカー。](images/picker-multifile-600px.png)

## <a name="how-pickers-work"></a>ピッカーのしくみ


アプリでは、ファイル ピッカーを使ってユーザーのシステム上のファイルとフォルダーにアクセスします。 アプリではこれらの選択を [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトと [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) オブジェクトとして受け取ることにより、それらを操作できます。

ピッカーは単一の統一されたインターフェイスを使用して、ユーザーがファイル システムや他のアプリからファイルやフォルダーを選べるように表示します。 他のアプリから選ばれたファイルは、ファイル システムから選ばれたファイルと同様に、[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトとして返されます。 通常、アプリはそれらのオブジェクトも、他のオブジェクトと同じ方法で操作できます。 他のアプリは、ファイル ピッカー コントラクトに参加することで、ユーザーにファイルを表示します。 ファイル、保存場所、またはファイルの更新を他のアプリに提供する場合は、「[ファイル ピッカー コントラクトとの統合](https://msdn.microsoft.com/library/windows/apps/hh465192)」をご覧ください。

たとえば、アプリでファイル ピッカーを呼び出し、ユーザーにファイルを開くように促すことができます。 この場合、アプリは呼び出し元アプリになります。 ファイル ピッカーは、システムや他のアプリと情報をやり取りして、ユーザーがファイルを探して選べるようにします。 ユーザーがファイルを選ぶと、ファイル ピッカーはそのファイルをアプリに返します。 ここでは、ユーザーが OneDrive のような提供元アプリからファイルを選ぶ場合のプロセスを示しています。

![ファイル ピッカーを 2 つのアプリの間のインターフェイスとして使って、一方のアプリのファイルをもう一方のアプリから開くプロセスを示す図。](images/app-to-app-diagram-600px.png)

## <a name="pick-a-single-file-complete-code-listing"></a>1 つのファイルを選ぶ: 完全なコード


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

## <a name="pick-a-single-file-step-by-step"></a>1 つのファイルを選ぶ: ステップ バイ ステップ


ファイル ピッカーが動作するには、ファイル ピッカー オブジェクトを作成してカスタマイズし、ユーザーが項目を選べるようにそのファイル ピッカーを表示する必要があります。

1.  **FileOpenPicker を作成してカスタマイズする**

    ```cs
    var picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
    picker.FileTypeFilter.Add(".jpg");
    picker.FileTypeFilter.Add(".jpeg");
    picker.FileTypeFilter.Add(".png");
    ```
    ファイル ピッカー オブジェクトの、ユーザーとアプリに関連するプロパティを設定します。

    この例では、[**ViewMode**](https://msdn.microsoft.com/library/windows/apps/br207855)、[**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854)、および [**FileTypeFilter**](https://msdn.microsoft.com/library/windows/apps/br207850) という 3 つのプロパティを設定して、ユーザーが画像ファイルを選べる視覚的に優れた表示を作成し、使いやすい場所に配置します。

    -   [**ViewMode**](https://msdn.microsoft.com/library/windows/apps/br207855) を [**PickerViewMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#thumbnail)**Thumbnail** 列挙値に設定すると、ファイル ピッカーで画像ファイルが縮小表示の画像で表され、視覚的に優れた表示が作成されます。 これは、画像やビデオなどの視覚的なファイルを選ぶ場合に設定します。 それ以外の場合は、[**PickerViewMode.List**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#list) を使います。 **画像またはビデオの添付**機能と**ドキュメントの添付**機能がある架空のメール アプリでは、ファイル ピッカーを表示する前に **ViewMode** をそれらの機能に対応させます。

    -   [**PickerLocationId.PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br207890) を使って [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) を Pictures に設定すると、画像を見つけられる可能性が高い場所が最初に表示されます。 選ぶファイルの種類 (音楽、画像、ビデオ、ドキュメントなど) に合わせて **SuggestedStartLocation** を設定します。 ユーザーは、開始場所から別の場所に移動できます。

    -   [**FileTypeFilter**](https://msdn.microsoft.com/library/windows/apps/br207850) を使うと、関連性の高いファイルの種類に絞ってユーザーがファイルを選ぶことができます。 **FileTypeFilter** の以前のファイルの種類を新しいエントリに置き換えるには、[**Add**](https://msdn.microsoft.com/library/windows/apps/br207834) ではなく [**ReplaceAll**](https://msdn.microsoft.com/library/windows/apps/br207844) メソッドを使います。

2.  **FileOpenPicker を表示する**

    - **単一のファイルを選ぶには**

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

    - **複数のファイルを選ぶには**  

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

## <a name="pick-a-folder-complete-code-listing"></a>フォルダーを選ぶ: 完全なコード


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
> アプリがピッカーでファイルまたはフォルダーにアクセスするたびに、ファイルやフォルダーをアプリの [**FutureAccessList**](https://msdn.microsoft.com/library/windows/apps/br207457) または [**MostRecentlyUsedList**](https://msdn.microsoft.com/library/windows/apps/br207458) に追加して、ファイルやフォルダーを追跡します。 これらのリストの使用の詳細については、「[最近使ったファイルやフォルダーを追跡する方法](how-to-track-recently-used-files-and-folders.md)」をご覧ください。