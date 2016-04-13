---
ms.assetid: 3604524F-112A-474F-B0CA-0726DC8DB885
title: Microsoft OneDrive ファイルが利用可能かどうかの確認
description: StorageFile.IsAvailable プロパティを使って、Microsoft OneDrive ファイルが利用可能かどうかを確認します。
---
# Microsoft OneDrive ファイルが利用可能かどうかの確認

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


** 重要な API **

-   [**FileIO クラス**](https://msdn.microsoft.com/library/windows/apps/Hh701440)
-   [**StorageFile クラス**](https://msdn.microsoft.com/library/windows/apps/BR227171)
-   [**StorageFile.IsAvailable プロパティ**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx)

[
            **StorageFile.IsAvailable**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx) プロパティを使って、Microsoft OneDrive ファイルが利用可能かどうかを確認します。

## 必要条件

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/Mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/Mt187334)」をご覧ください。

-   **アプリ機能の宣言**

    「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。

## StorageFile.IsAvailable プロパティの使用

ユーザーは、OneDrive ファイルを "オフラインで利用可能" (既定) または "オンラインのみ" とマークできます。 この機能を使うと、大容量のファイル (写真やビデオなど) を自分の OneDrive に移動し、オンラインのみとマークすることで、ディスク領域を節約できます (ローカルに保存されるのはメタデータ ファイルのみです)。

[**StorageFile.IsAvailable**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx) は、ファイルが現在利用可能であるかどうかを判別するために使われます。 次の表に、さまざまなシナリオでの **StorageFile.IsAvailable** プロパティの値を示します。

| ファイルの種類                              | オンライン | 従量制課金接続        | オフライン |
|-------------------------------------------|--------|------------------------|---------|
| ローカル ファイル                                | True   | True                   | True    |
| オフラインで利用可能とマークされている OneDrive ファイル | True   | True                   | True    |
| オンラインのみとマークされている OneDrive ファイル       | True   | ユーザー設定に基づく | False   |
| ネットワーク ファイル                              | True   | ユーザー設定に基づく | False   |

 

次の手順では、ファイルが現在利用できるかどうかを判別する方法を示しています。

1.  アクセスするライブラリに適した機能を宣言します。
2.  [
            **Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間を含めます。 この名前空間には、ファイル、フォルダー、アプリケーション設定を管理するための型が含まれています。 また、必要な [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) 型も含まれています。
3.  必要なファイルの [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) オブジェクトを取得します。 ライブラリを列挙する場合、通常、この手順は [**StorageFolder.CreateFileQuery**](https://msdn.microsoft.com/library/windows/apps/BR227252) メソッドを呼び出し、結果の [**StorageFileQueryResult**](https://msdn.microsoft.com/library/windows/apps/BR208046) オブジェクトの [**GetFilesAsync**](https://msdn.microsoft.com/en-us/library/windows/apps/br227276.aspx) メソッドを呼び出して行います。 **GetFilesAsync** メソッドは、**StorageFile** オブジェクトの [IReadOnlyList](http://go.microsoft.com/fwlink/p/?LinkId=324970) コレクションを返します。
4.  目的のファイルを表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) オブジェクトにアクセスできるようになると、[**StorageFile.IsAvailable**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx) プロパティの値は、ファイルが利用できるかどうかを表します。

次の汎用的なメソッドは、フォルダーを列挙し、そのフォルダーの [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) オブジェクトのコレクションを返す方法を示しています。 その後、呼び出し元メソッドで、各ファイルの [**StorageFile.IsAvailable**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx) プロパティを参照する返されたコレクションを反復処理します。

```CSharp
/// <summary>
/// Generic function that retrieves all files from the specified folder.
/// </summary>
/// <param name="folder">The folder to be searched.</param>
/// <returns>An IReadOnlyList collection containing the file objects.</returns>
async Task<System.Collections.Generic.IReadOnlyList<StorageFile>> GetLibraryFilesAsync(StorageFolder folder)
{
    var query = folder.CreateFileQuery();
    return await query.GetFilesAsync();
}

...

private async void CheckAvailabilityOfFilesInPicturesLibrary()
{
    // Determine availability of all files within Pictures library.
    var files = await GetLibraryFilesAsync(KnownFolders.PicturesLibrary);
    for (int i = 0; i < files.Count; i++)
    {
        StorageFile file = files[i];

        StringBuilder fileInfo = new StringBuilder();
        fileInfo.AppendFormat("{0} (on {1}) is {2}", 
                    file.Name, 
                    file.Provider.DisplayName, 
                    file.IsAvailable ? "available" : "not available");
    }
}
```

 

 






<!--HONumber=Mar16_HO1-->


