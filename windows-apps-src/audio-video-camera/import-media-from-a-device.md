---
ms.assetid: dd2a1e01-c284-4d62-963e-f59f58dca61a
description: この記事では、利用可能なメディア ソースの検索、写真やサイドカー ファイルなどのファイルのインポート、ソース デバイスからインポートしたファイルの削除など、デバイスからメディアをインポートする方法について説明します。
title: メディアのインポート
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c08612e48eec7989f3b56fba41a17e1c149b2058
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7971120"
---
# <a name="import-media-from-a-device"></a>デバイスからのメディアのインポート

この記事では、利用可能なメディア ソースの検索、ビデオ、写真、サイドカー ファイルなどのファイルのインポート、ソース デバイスからインポートしたファイルの削除など、デバイスからメディアをインポートする方法について説明します。

> [!NOTE] 
> この記事のコードは、[**MediaImport UWP アプリ サンプル**](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MediaImport)を基にしています。 このサンプルを[**ユニバーサル Windows アプリ サンプル Git リポジトリ**](https://github.com/Microsoft/Windows-universal-samples)から複製またはダウンロードすると、コンテキスト内のコードを確認できます。独自のアプリの出発点として使うこともできます。

## <a name="create-a-simple-media-import-ui"></a>シンプルなメディア インポート UI の作成
この記事の例では、メディア インポートのコア シナリオを実現する最小限の UI を使用します。 メディア インポート アプリ用のより強力な UI を作成する方法については、[**MediaImport サンプル**](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MediaImport)をご覧ください。 次の XAML では、次のコントロールを持つスタック パネルを作成します。
* メディアをインポートできるソースの検索を開始するための [**Button**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Button)。
* 見つかったメディア インポート ソースを一覧にして選択するための [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ComboBox)。
* 選択したインポート ソースのメディア項目を表示して選択するための [**ListView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ListView) コントロール。
* 選択したソースからメディア項目のインポートを開始するための **Button**。
* 選択したソースからインポートされた項目の削除を開始するための **Button**。
* 非同期メディア インポート操作を取り消すための **Button**。

[!code-xml[ImportXAML](./code/PhotoImport_Win10/cs/MainPage.xaml#SnippetImportXAML)]

## <a name="set-up-your-code-behind-file"></a>分離コード ファイルの設定
*using* ディレクティブを追加して、既定のプロジェクト テンプレートにまだ含まれていない、この例で使用する名前空間を含めます。

[!code-cs[Using](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetUsing)]

## <a name="set-up-task-cancellation-for-media-import-operations"></a>メディア インポート操作のタスク取り消しの設定

メディア インポート操作には長い時間がかかる場合があるため、操作は [**IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) を使用して非同期で実行します。 ユーザーがキャンセル ボタンをクリックした場合に、実行中の操作の取り消しに使用する、[**CancellationTokenSource**](https://msdn.microsoft.com/library/system.threading.cancellationtokensource) 型のクラス メンバー変数を宣言します。

[!code-cs[DeclareCts](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetDeclareCts)]

キャンセル ボタンのハンドラーの実装 この記事の後で示す例では、**CancellationTokenSource** を操作が始まったときに初期化して、操作が完了したときに null に設定します。 このキャンセル ボタン ハンドラーでは、トークンが null かどうかを確認し、null でない場合は [**Cancel**](https://msdn.microsoft.com/library/dd321955) を呼び出して操作を取り消します。

[!code-cs[OnCancel](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetOnCancel)]

## <a name="data-binding-helper-classes"></a>データ バインディング ヘルパー クラス

一般的なメディア インポート シナリオでは、インポートできるメディア項目の一覧をユーザーに提示します。選択するメディア ファイルの数は非常に多い可能性があり、通常、各メディア項目のサムネイルを表示します。 このため、この例では 3 つのヘルパー クラスを使用して、ユーザーが一覧をスクロールしていくと ListView コントロールにエントリが段階的に読み込まれるようにします。

* **IncrementalLoadingBase** クラス - [**IList**](https://msdn.microsoft.com/library/system.collections.ilist)、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.isupportincrementalloading)、および [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/system.collections.specialized.inotifycollectionchanged(v=vs.105).aspx) を実装し、段階的な読み込みの基本動作を提供します。
* **GeneratorIncrementalLoadingClass** クラス - 段階的な読み込みの基底クラスの実装を提供します。
* **ImportableItemWrapper** クラス - [**PhotoImportItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportItem) クラスのシン ラッパーで、インポートされる各項目のサムネイル イメージに対するバインディング可能な [**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.Imaging.BitmapImage) プロパティを追加します。

これらのクラスは [**MediaImport サンプル**](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MediaImport)に用意されており、変更なしでプロジェクトに追加できます。 ヘルパー クラスをプロジェクトに追加したら、後でこの例で使用する**GeneratorIncrementalLoadingClass** 型のクラス メンバー変数を宣言します。

[!code-cs[GeneratorIncrementalLoadingClass](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetGeneratorIncrementalLoadingClass)]


## <a name="find-available-sources-from-which-media-can-be-imported"></a>メディアをインポートできる利用可能なソースを見つける

ソース検索ボタンのクリック ハンドラーで、静的メソッド [**PhotoImportManager.FindAllSourcesAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportManager.FindAllSourcesAsync) を呼び出し、メディアをインポート可能なデバイスのシステム検索を開始します。 操作の完了を待機した後、返される一覧内の各 [**PhotoImportSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportSource) オブジェクトをループ処理し、エントリを **ComboBox** に追加します。ソース オブジェクト自体に **Tag** プロパティを設定して、ユーザーが選択するときに簡単にソース オブジェクトを取得できるようにします。

[!code-cs[FindSourcesClick](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetFindSourcesClick)]

ユーザーが選択したインポート ソースを格納するクラス メンバー変数を宣言します。

[!code-cs[DeclareImportSource](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetDeclareImportSource)]

インポート ソース **ComboBox** の [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.Selector.SelectionChanged) ハンドラーで、クラス メンバー変数を選択したソースに設定します。その後、この記事の広範で示す **FindItems** ヘルパー メソッドを呼び出します。 

[!code-cs[SourcesSelectionChanged](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetSourcesSelectionChanged)]

## <a name="find-items-to-import"></a>インポートする項目を見つける

この後の手順で使用する [**PhotoImportSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportSession) 型および [**PhotoImportFindItemsResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult) 型のクラス メンバー 変数を追加します。

[!code-cs[DeclareImport](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetDeclareImport)]

**FindItems** メソッドで、C**CancellationTokenSource** 変数を初期化して、必要に応じて検索操作の取り消しに使用できるようにします。 **try** ブロック内で、ユーザーが選択した [**PhotoImportSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportSource) オブジェクトで [**CreateImportSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportSource.CreateImportSession) を呼び出して、新しいインポート セッションを作成します。 検索操作の進行状況を表示するためのコールバックを提供するために、新しい [**Progress**](https://msdn.microsoft.com/library/hh193692.aspx) オブジェクトを作成します。 次に、**[FindItemsAsync](https://docs.microsoft.com/uwp/api/windows.media.import.photoimportsession.finditemsasync)** を呼び出して、検索操作を開始します。 [**PhotoImportContentTypeFilter**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportContentTypeFilter) の値を提供して、写真、ビデオ、またはその両方を返す必要があるかどうかを指定します。 [**PhotoImportItemSelectionMode**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportItemSelectionMode) の値を提供して、[**IsSelected**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportItem.IsSelected) プロパティが true に設定されているときに、すべてのメディア項目を返すのか、メディア項目を何も返さないのか、新しいメディア項目のみを返すのかを指定します。 このプロパティは、ListBox 項目テンプレートの、各メディア項目のチェック ボックスにバインドされます。

**FindItemsAsync** は [**IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) を返します。 拡張メソッド [**AsTask**](https://msdn.microsoft.com/library/hh779750.aspx) は、待機可能で、キャンセル トークンを使用して取り消し可能であり、提供された **Progress** オブジェクトを使用して進行状況を報告するタスクの作成に使用されます。

次に、データ バインディング ヘルパー クラス **GeneratorIncrementalLoadingClass** が初期化されます。 **FindItemsAsync** は、待機から返されると、[**PhotoImportFindItemsResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult) オブジェクトを返します。 このオブジェクトには、操作の成功、見つかったさまざまな種類のメディア項目の数など、検索操作の状態情報が含まれます。 [**FoundItems**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult.FoundItems) プロパティには、見つかったメディア項目を表す [**PhotoImportItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportItem) オブジェクトの一覧が含まれます。 **GeneratorIncrementalLoadingClass** コンストラクターは、段階的に読み込まれる項目の合計数と、必要に応じて読み込まれる新規項目を生成する関数を引数として受け取ります。 この場合、指定されたラムダ式によって、**ImportableItemWrapper** の新しいインスタンスが作成されます。これは、**PhotoImportItem** をラップして各項目のサムネイルを含めます。 段階的読み込みクラスが初期化されたら、それを UI に含まれる **ListView** コントロールの [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsControl.ItemsSource) プロパティに設定します。 これで、見つかったメディア項目が段階的に読み込まれ、一覧に表示されます。

次に、検索操作の状態情報が出力されます。 一般的なアプリでは、この情報が UI でユーザーに表示されます。しかし、この例では、単純に情報をデバッグ コンソールに出力します。 最後に、操作が完了したのでキャンセル トークンを null に設定します。

[!code-cs[FindItems](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetFindItems)]

## <a name="import-media-items"></a>メディア項目のインポート

インポート操作を実装する前に、インポート操作の結果を格納する [**PhotoImportImportItemsResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportImportItemsResult) オブジェクトを宣言します。 これは後で、ソースから正常にインポートされたメディア項目を削除するために使用します。

[!code-cs[DeclareImportResult](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetDeclareImportResult)]

メディアのインポート操作を開始する前に、**CancellationTokenSource** 変数を初期化し、[**ProgressBar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ProgressBar) コントロールの値を 0 に設定します。

**ListView** コントロールで選択されている項目がない場合、インポートするものはありません。 それ以外の場合は、進行状況バー コントロールを更新する進行状況コールバックを提供するために、[**Progress**](https://msdn.microsoft.com/library/hh193692.aspx) オブジェクトを初期化します。 検索操作によって返される [**PhotoImportFindItemsResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult) の [**ItemImported**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult.ItemImported) イベント用のハンドラーを登録します。 このイベントは、この例の場合、項目がインポートされ、インポートされた各ファイルの名前がデバッグ コンソールに出力されるときに発生します。

[**ImportItemsAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult.ImportItemsAsync) を呼び出して、インポート操作を開始します。 検索操作と同様に、[**AsTask**](https://msdn.microsoft.com/library/hh779750.aspx) 拡張メソッドは、返された操作を、待機可能で、進行状況を報告し、取り消し可能なタスクに変換するために使用されます。

インポート操作が完了したら、[**ImportItemsAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult.ImportItemsAsync) によって返される [**PhotoImportImportItemsResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportImportItemsResult) オブジェクトから操作の状態を取得できます。 この例では、状態情報をデバッグ コンソールに出力して、最後にキャンセル トークンを null に設定します。

[!code-cs[ImportClick](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetImportClick)]

## <a name="delete-imported-items"></a>インポートされた項目の削除
ソースから正常にインポートされた項目をインポート元から削除するには、まず、削除操作を取り消せるようにキャンセル トークンを初期化して、進行状況バーの値を 0 に設定します。 [**ImportItemsAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportFindItemsResult.ImportItemsAsync) から返される [**PhotoImportImportItemsResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportImportItemsResult) が null でないことを確認します。 そうでない場合は、削除操作の進行状況コールバックを提供するために、[**Progress**](https://msdn.microsoft.com/library/hh193692.aspx) オブジェクトをもう一度作成します。 [**DeleteImportedItemsFromSourceAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportImportItemsResult.DeleteImportedItemsFromSourceAsync) を呼び出して、インポートされた項目の削除を開始します。 **AsTask** を使用して、進行状況の報告機能と取り消し機能を持った待機可能なタスクに結果を変換します。 待機後、返された [**PhotoImportDeleteImportedItemsFromSourceResult**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Import.PhotoImportDeleteImportedItemsFromSourceResult) オブジェクトを使用して、削除操作に関する状態情報を取得および表示できます。

[!code-cs[DeleteClick](./code/PhotoImport_Win10/cs/MainPage.xaml.cs#SnippetDeleteClick)]








 


