---
author: TylerMSFT
ms.assetid: AC96F645-1BDE-4316-85E0-2FBDE0A0A62A
title: "ファイルのプロパティの取得"
description: "StorageFile オブジェクトで表されるファイルのプロパティ (最上位、基本、拡張) を取得します。"
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 56b83d2f05189b4cbb5bbc015987a4ffce8d86fd

---
# ファイルのプロパティの取得

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


** 重要な API **

-   [**StorageFile.GetBasicPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh701737)
-   [**StorageFile.Properties**](https://msdn.microsoft.com/library/windows/apps/br227225)
-   [**StorageItemContentProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh770652)

[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトで表されるファイルのプロパティ (最上位、基本、拡張) を取得します。


            **注** [ファイル アクセスのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619995) に関するページも参照してください。

 


## 前提条件

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

-   **場所へのアクセス許可**

    たとえば、これらの例のコードでは **picturesLibrary** 機能が必要ですが、場所によっては別の機能が必要であったり、機能をまったく必要としない場合もあります。 詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。

## ファイルの最上位プロパティの取得

多くの最上位ファイル プロパティは、[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) クラスのメンバーとしてアクセスできます。 これらのプロパティには、ファイル属性、コンテンツの種類、作成日、表示名、ファイルの種類などがあります。


            **注:** 必ず **picturesLibrary** 機能を宣言してください。

 

この例では、画像ライブラリ内のすべてのファイルを列挙して、各ファイルの最上位プロパティの一部にアクセスします。

```csharp
// Enumerate all files in the Pictures library.
var folder = Windows.Storage.KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Get top-level file properties.
    fileProperties.AppendLine("File name: " + file.Name);
    fileProperties.AppendLine("File type: " + file.FileType);
}
```

## ファイルの基本プロパティの取得

多くの基本ファイル プロパティは、最初に [**StorageFile.GetBasicPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh701737) メソッドを呼び出して取得します。 このメソッドは、項目 (ファイルまたはフォルダー) のサイズや最終変更日のプロパティを定義する [**BasicProperties**](https://msdn.microsoft.com/library/windows/apps/br212113) オブジェクトを返します。

この例では、画像ライブラリ内のすべてのファイルを列挙して、各ファイルの基本プロパティの一部にアクセスします。

```csharp
// Enumerate all files in the Pictures library.
var folder = Windows.Storage.KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Get file's basic properties.
    Windows.Storage.FileProperties.BasicProperties basicProperties = 
        await file.GetBasicPropertiesAsync();
    string fileSize = string.Format("{0:n0}", basicProperties.Size);
    fileProperties.AppendLine("File size: " + fileSize + " bytes");
    fileProperties.AppendLine("Date modified: " + basicProperties.DateModified);
}
 ```
 
## ファイルの拡張プロパティの取得

最上位と基本ファイル プロパティのほかに、ファイルの内容に関連付けられている多くのプロパティがあります。 これらの拡張プロパティは、[**BasicProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br212124) メソッドを呼び出してアクセスします  ([**BasicProperties**](https://msdn.microsoft.com/library/windows/apps/br212113) オブジェクトは、[**StorageFile.Properties**](https://msdn.microsoft.com/library/windows/apps/br227225) プロパティを呼び出して取得します)。最上位と基本ファイル プロパティは、クラス (それぞれ [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) と **BasicProperties**) のプロパティとしてアクセスできます。拡張プロパティは、取得するプロパティの名前を表す [String](http://go.microsoft.com/fwlink/p/?LinkID=325032) オブジェクトの [IEnumerable](http://go.microsoft.com/fwlink/p/?LinkID=313091) コレクションを **BasicProperties.RetrievePropertiesAsync** メソッドに渡して取得します。 このメソッドは、[IDictionary](http://go.microsoft.com/fwlink/p/?LinkId=325238) コレクションを返します。 各拡張プロパティは、コレクションから名前またはインデックスで取得します。

この例では、画像ライブラリ内のすべてのファイルを列挙し、[List](http://go.microsoft.com/fwlink/p/?LinkID=325246) オブジェクトで目的のプロパティの名前 (**DataAccessed** と **FileOwner**) を指定して、その [List](http://go.microsoft.com/fwlink/p/?LinkID=325246) オブジェクトを [**BasicProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br212124) に渡すことでそれらのプロパティを取得します。その後、返された [IDictionary](http://go.microsoft.com/fwlink/p/?LinkId=325238) オブジェクトから名前でそれらのプロパティを取得します。

```csharp
const string dateAccessedProperty = "System.DateAccessed";
const string fileOwnerProperty = "System.FileOwner";

// Enumerate all files in the Pictures library.
var folder = KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Define property names to be retrieved.
    var propertyNames = new List<string>();
    propertyNames.Add(dateAccessedProperty);
    propertyNames.Add(fileOwnerProperty);

    // Get extended properties.
    IDictionary<string, object> extraProperties = 
        await file.Properties.RetrievePropertiesAsync(propertyNames);

    // Get date-accessed property.
    var propValue = extraProperties[dateAccessedProperty];
    if (propValue != null)
    {
        fileProperties.AppendLine("Date accessed: " + propValue);
    }

    // Get file-owner property.
    propValue = extraProperties[fileOwnerProperty];
    if (propValue != null)
    {
        fileProperties.AppendLine("File owner: " + propValue);
    }
}
```

 

 







<!--HONumber=Jun16_HO4-->


