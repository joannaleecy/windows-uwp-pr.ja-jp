---
author: TylerMSFT
ms.assetid: 4C59D5AC-58F7-4863-A884-E9E54228A5AD
title: ファイルとフォルダーの列挙と照会
description: フォルダー、ライブラリ、デバイス、またはネットワークの場所にあるファイルやフォルダーにアクセスします。 ファイルやフォルダーのクエリを作成することで、任意の場所にあるファイルやフォルダーを照会することもできます。
---
# ファイルとフォルダーの列挙と照会


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


フォルダー、ライブラリ、デバイス、またはネットワークの場所にあるファイルやフォルダーにアクセスします。 ファイルやフォルダーのクエリを作成することで、任意の場所にあるファイルやフォルダーを照会することもできます。

**注:** [フォルダーの列挙のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619993)に関するページも参照してください。

 
## 必要条件

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

-   **場所へのアクセス許可**

    たとえば、これらの例のコードでは **picturesLibrary** 機能が必要ですが、場所によっては別の機能が必要であったり、機能をまったく必要としない場合もあります。 詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。

## ある場所のファイルやフォルダーを列挙する

> **注:** 必ず **picturesLibrary** 機能を宣言してください。

この例では、まず [**StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227276) メソッドを使って [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) 内のルート フォルダー (サブフォルダーは除く) にあるすべてのファイルを取得し、各ファイルの名前を一覧表示します。 次に、[**GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br227280) メソッドを使って **PicturesLibrary** 内のすべてのサブフォルダーを取得し、各サブフォルダーの名前を一覧表示します。

<!--BUGBUG: IAsyncOperation<IVectorView<StorageFolder^>^>^  causes build to flake out-->
> [!div class="tabbedCodeSnippets"] 
> ```cpp
> //#include <ppltasks.h>
> //#include <string>
> //#include <memory>
> using namespace Windows::Storage;
> using namespace Platform::Collections;
> using namespace concurrency;
> using namespace std;
> 
> // Be sure to specify the Pictures Folder capability in the appxmanifext file.
> StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
> 
> // Use a shared_ptr so that the string stays in memory
> // until the last task is complete.
> auto outputString = make_shared<wstring>();
> *outputString += L"Files:\n";
> 
> // Get a read-only vector of the file objects
> // and pass it to the continuation. 
> create_task(picturesFolder->GetFilesAsync())        
>    // outputString is captured by value, which creates a copy 
>    // of the shared_ptr and increments its reference count.
>    .then ([outputString] (IVectorView\<StorageFile^>^ files)
>    {        
>        for ( unsigned int i = 0 ; i < files->Size; i++)
>        {
>            *outputString += files->GetAt(i)->Name->Data();
>            *outputString += L"\n";
>       }
>    })
>    // We need to explicitly state the return type 
>    // here: -> IAsyncOperation<...>
>    .then([picturesFolder]() -> IAsyncOperation\<IVectorView\<StorageFolder^>^>^ 
>    {
>        return picturesFolder->GetFoldersAsync();
>    })
>    // Capture "this" to access m_OutputTextBlock from within the lambda.
>    .then([this, outputString](IVectorView\<StorageFolder^>^ folders)
>    {        
>        *outputString += L"Folders:\n";
> 
>        for ( unsigned int i = 0; i < folders->Size; i++)
>        {
>           *outputString += folders->GetAt(i)->Name->Data();
>           *outputString += L"\n";
>        }
> 
>        // Assume m_OutputTextBlock is a TextBlock defined in the XAML.
>        m_OutputTextBlock->Text = ref new String((*outputString).c_str());
>     });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> StringBuilder outputText = new StringBuilder();
> 
> IReadOnlyList<StorageFile> fileList = 
>     await picturesFolder.GetFilesAsync();
> 
> outputText.AppendLine("Files:");
> foreach (StorageFile file in fileList)
> {
>     outputText.Append(file.Name + "\n");
> }
> 
> IReadOnlyList<StorageFolder> folderList = 
>     await picturesFolder.GetFoldersAsync();
>            
> outputText.AppendLine("Folders:");
> foreach (StorageFolder folder in folderList)
> {
>     outputText.Append(folder.DisplayName + "\n");
> }
> ```
> ```vb
> Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
> Dim outputText As New StringBuilder
> 
> Dim fileList As IReadOnlyList(Of StorageFile) =
>     Await picturesFolder.GetFilesAsync()
> 
> outputText.AppendLine("Files:")
> For Each file As StorageFile In fileList
> 
>     outputText.Append(file.Name & vbLf)
> 
> Next file
> 
> Dim folderList As IReadOnlyList(Of StorageFolder) =
>     Await picturesFolder.GetFoldersAsync()
> 
> outputText.AppendLine("Folders:")
> For Each folder As StorageFolder In folderList
> 
>     outputText.Append(folder.DisplayName & vbLf)
> 
> Next folder
> ```


> **注:** C# または Visual Basic では、**await** 演算子を使うすべてのメソッドのメソッド宣言で、必ず **async** キーワードを使ってください。
 

または、[**GetItemsAsync**](https://msdn.microsoft.com/library/windows/apps/br227286) メソッドを使って、特定の場所にあるすべての項目 (ファイルとサブフォルダーの両方) を取得することもできます。 次の例では、**GetItemsAsync** メソッドを使って [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) 内のルート フォルダー (サブフォルダーは除く) にあるすべてのファイルとサブフォルダーを取得します。 その後、各ファイルとサブフォルダーの名前を一覧表示します。 項目がサブフォルダーの場合は、名前に `"folder"` を追加します。

> [!div class="tabbedCodeSnippets"] 
> ```cpp
> // See previous example for comments, namespace and #include info.
> StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
> auto outputString = make_shared<wstring>();
> 
> create_task(picturesFolder->GetItemsAsync())        
>     .then ([this, outputString] (IVectorView<IStorageItem^>^ items)
> {        
>     for ( unsigned int i = 0 ; i < items->Size; i++)
>     {
>         *outputString += items->GetAt(i)->Name->Data();
>         if(items->GetAt(i)->IsOfType(StorageItemTypes::Folder))
>         {
>             *outputString += L"  folder\n";
>         }
>         else
>         {
>             *outputString += L"\n";
>         }
>         m_OutputTextBlock->Text = ref new String((*outputString).c_str());
>     }
> });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> StringBuilder outputText = new StringBuilder();
> 
> IReadOnlyList<IStorageItem> itemsList = 
>     await picturesFolder.GetItemsAsync();
> 
> foreach (var item in itemsList)
> {
>     if (item is StorageFolder)
>     {
>         outputText.Append(item.Name + " folder\n");
> 
>     }
>     else
>     {
>         outputText.Append(item.Name + "\n");
> 
>     }
> }
> ```
> ```vb
> Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
> Dim outputText As New StringBuilder
> 
> Dim itemsList As IReadOnlyList(Of IStorageItem) =
>     Await picturesFolder.GetItemsAsync()
> 
> For Each item In itemsList
> 
>     If TypeOf item Is StorageFolder Then
> 
>         outputText.Append(item.Name & " folder" & vbLf)
> 
>     Else
> 
>         outputText.Append(item.Name & vbLf)
> 
>     End If
> 
> Next item
> ```

## ある場所のファイルのクエリを実行して一致するファイルを列挙する

この例では [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) にある月ごとにグループ化されたすべてのファイルを照会し、今回はサブフォルダーに再帰的に呼び出します。 まず、[**StorageFolder.CreateFolderQuery**](https://msdn.microsoft.com/library/windows/apps/br227262) を呼び出し、[**CommonFolderQuery.GroupByMonth**](https://msdn.microsoft.com/library/windows/apps/br207957) の値をメソッドに渡します。 これで、[**StorageFolderQueryResult**](https://msdn.microsoft.com/library/windows/apps/br208066) オブジェクトが取得されます。

次に、仮想フォルダーを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) のオブジェクトを返す [**StorageFolderQueryResult.GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br208074) を呼び出します。 ここでは月でグループ化されているため、各仮想フォルダーは同じ月にあるファイルのグループを表します。

> [!div class="tabbedCodeSnippets"] 
> ```cpp
> //#include <ppltasks.h>
> //#include <string>
> //#include <memory>
> using namespace Windows::Storage;
> using namespace Windows::Storage::Search;
> using namespace concurrency;
> using namespace Platform::Collections;
> using namespace Windows::Foundation::Collections;
> using namespace std;
> 
> StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
> 
> StorageFolderQueryResult^ queryResult = 
>     picturesFolder->CreateFolderQuery(CommonFolderQuery::GroupByMonth);
> 
> // Use shared_ptr so that outputString remains in memory
> // until the task completes, which is after the function goes out of scope.
> auto outputString = std::make_shared<wstring>();
> 
> create_task( queryResult->GetFoldersAsync()).then([this, outputString] (IVectorView<StorageFolder^>^ view) 
> {        
>     for ( unsigned int i = 0; i < view->Size; i++)
>     {
>         create_task(view->GetAt(i)->GetFilesAsync()).then([this, i, view, outputString](IVectorView<StorageFile^>^ files)
>         {
>             *outputString += view->GetAt(i)->Name->Data();
>             *outputString += L"(";
>             *outputString += to_wstring(files->Size);
>             *outputString += L")\r\n";
>             for (unsigned int j = 0; j < files->Size; j++)
>             {
>                 *outputString += L"     ";
>                 *outputString += files->GetAt(j)->Name->Data();
>                 *outputString += L"\r\n";
>             }
>         }).then([this, outputString]()
>         {
>             m_OutputTextBlock->Text = ref new String((*outputString).c_str());
>         });
>     }    
> });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> 
> StorageFolderQueryResult queryResult = 
>     picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth);
>         
> IReadOnlyList<StorageFolder> folderList = 
>     await queryResult.GetFoldersAsync();
> 
> StringBuilder outputText = new StringBuilder();
> 
> foreach (StorageFolder folder in folderList)
> {
>     IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();
> 
>     // Print the month and number of files in this group.
>     outputText.AppendLine(folder.Name + " (" + fileList.Count + ")");
> 
>     foreach (StorageFile file in fileList)
>     {
>         // Print the name of the file.
>         outputText.AppendLine("   " + file.Name);
>     }
> }
> ```
> ```vb
> Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
> Dim outputText As New StringBuilder
> 
> Dim queryResult As StorageFolderQueryResult =
>     picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth)
> 
> Dim folderList As IReadOnlyList(Of StorageFolder) =
>     Await queryResult.GetFoldersAsync()
> 
> For Each folder As StorageFolder In folderList
> 
>     Dim fileList As IReadOnlyList(Of StorageFile) =
>         Await folder.GetFilesAsync()
> 
>     ' Print the month and number of files in this group.
>     outputText.AppendLine(folder.Name & " (" & fileList.Count & ")")
> 
>     For Each file As StorageFile In fileList
> 
>         ' Print the name of the file.
>         outputText.AppendLine("   " & file.Name)
> 
>     Next file
> 
> Next folder
> ```

この例の出力は次のようになります。

``` syntax
July ‎2015 (2)
   MyImage3.png
   MyImage4.png
‎December ‎2014 (2)
   MyImage1.png
   MyImage2.png
```



<!--HONumber=May16_HO2-->


