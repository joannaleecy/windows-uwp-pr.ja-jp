---
author: TylerMSFT
title: "ファイルのアクティブ化の処理"
description: "アプリは、特定のファイルの種類の既定のハンドラーとして登録することができます。"
ms.assetid: A0F914C5-62BC-4FF7-9236-E34C5277C363
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: 9c6358bccdea55a7c3749388c35aa770f4325960

---

# ファイルのアクティブ化の処理


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、「[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)」をご覧ください\]


**重要な API**

-   [**Windows.ApplicationModel.Activation.FileActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224716)
-   [**Windows.UI.Xaml.Application.OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331)

アプリは、特定のファイルの種類の既定のハンドラーとして登録することができます。 従来の Windows プラットフォーム (CWP) アプリとユニバーサル Windows プラットフォーム (UWP) アプリの両方を、既定のファイル ハンドラーとして登録できます。 ユーザーがアプリを特定のファイルの種類の既定のハンドラーとして選ぶと、アプリはその種類のファイルを起動したときにアクティブ化されます。

ファイルの種類に登録するのは、その種類のファイルのすべてのファイル起動を処理する場合のみにすることをお勧めします。 アプリをそのファイルの種類に内部的にのみ使う場合、既定のハンドラーに登録する必要はありません。 ファイルの種類に登録する場合は、そのファイルの種類のためにアプリをアクティブ化した際に期待される機能をエンド ユーザーに提供する必要があります。 たとえば、.jpg ファイルを表示する画像ビューアー アプリを登録できます。 ファイルの関連付けについて詳しくは、「[ファイルの種類と URI のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh700321)」をご覧ください。

以下の手順では、カスタムのファイルの種類 .alsdk を登録する方法と、ユーザーによって .alsdk ファイルが起動されたときにアプリをアクティブ化する方法について説明します。

> 
            **注**  UWP アプリでは、組み込みのアプリとオペレーティング システムで使うために、特定の URI とファイル拡張子が予約されています。 予約されている URI またはファイル拡張子にアプリを登録しようとしても無視されます。 詳しくは、「[予約済みのファイルと URI スキーム名](reserved-uri-scheme-names.md)」をご覧ください。

## ステップ 1: パッケージ マニフェストに拡張点を指定する


アプリは、パッケージ マニフェストに一覧表示されるファイル拡張子のアクティブ化イベントだけを受け取ります。 アプリが `.alsdk` 拡張子を持つファイルを処理することを示す方法は次のとおりです。

1.  **ソリューション エクスプローラー**で、package.appxmanifest をダブルクリックしてマニフェスト デザイナーを開きます。 **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[ファイルの種類の関連付け]** を選んで **[追加]** をクリックします。 ファイルの関連付けで使われる識別子について詳しくは、「[プログラムの識別子](https://msdn.microsoft.com/library/windows/desktop/cc144152)」をご覧ください。

    マニフェスト デザイナーで指定することができる各フィールドについて、以下で簡単に説明します。

| フィールド | 説明 |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **表示名** | ファイルの種類のグループの表示名を指定します。 表示名は、**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) でファイルの種類を識別するために使われます。 |
| **ロゴ** | デスクトップと**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) でファイルの種類を識別するために使われるロゴを指定します。 ロゴを指定しない場合は、アプリケーションの小さいロゴが使われます。 |
| **InfoTip** | ファイルの種類のグループの [InfoTip](https://msdn.microsoft.com/library/windows/desktop/cc144152) を指定します。 このヒントのテキストは、ユーザーがこの種類のファイルのアイコンの上にマウス ポインターを置くと表示されます。 |
| **名前** | 同じ表示名、ロゴ、InfoTip、編集フラグを共有するファイルの種類のグループの名前を選びます。 このグループ名は、アプリの更新後も維持される名前にします。 
            **注**  名前はすべて小文字である必要があります。 |
| **コンテンツの種類** | 特定のファイルの種類の MIME コンテンツの種類 (**image/jpeg** など) を指定します。 
            **許可されるコンテンツの種類に関する重要な注意:**  MIME コンテンツの種類のうち、**application/force-download**、**application/octet-stream**、**application/unknown**、**application/x-msdownload** は予約または禁止されているため、パッケージ マニフェストに入力できません。 |
| **ファイルの種類** | 登録するファイルの種類を指定します。先頭にはピリオドを付けます (例: ".jpeg")。 
            **予約および禁止されているファイルの種類** 予約または禁止されているため、UWP アプリを登録できない組み込みアプリ用のファイルの種類の一覧 (アルファベット順) については、[予約済みの URI スキーム名とファイルの種類](reserved-uri-scheme-names.md)に関するページをご覧ください。 |

2.  **[名前]** に `alsdk` と入力します。
3.  **[ファイルの種類]** に `.alsdk` と入力します。
4.  [ロゴ] に「images\\Icon.png」と入力します。
5.  Ctrl + S キーを押して、変更を package.appxmanifest に保存します。

上記の手順により、次のような [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) 要素がパッケージ マニフェストに追加されます。 **windows.fileTypeAssociation** カテゴリは、アプリが `.alsdk` 拡張子を持つファイルを処理することを示しています。

```xml
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap:FileTypeAssociation Name="alsdk">
            <uap:Logo>images\icon.png</uap:Logo>
            <uap:SupportedFileTypes>
              <uap:FileType>.alsdk</uap:FileType>
            </uap:SupportedFileTypes>
          </uap:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
```

## ステップ 2: 適切なアイコンを追加する


ファイルの種類の既定となるアプリは、そのアイコンがシステムのさまざまな場所に表示されます。 アイコンは、たとえば次の場所に表示されます。

-   エクスプローラーの項目ビュー、コンテキスト メニュー、リボン
-   [既定のプログラム] コントロール パネル
-   ファイル ピッカー
-   スタート画面での検索結果

アプリのタイルのロゴの外観を調和させ、アイコンを透明にするのではなく、アプリの背景色を使います。 パディングせずにロゴを端まで拡張します。 アイコンは、白い背景でテストします。 サンプルのアイコンについては、[関連付けによる起動のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620490)をご覧ください。
![ソリューション エクスプローラーで images フォルダー内にあるファイルを表示した様子。 Icon.targetsize と smallTile-sdk の両方に 16、32、48、256 の各ピクセルのバージョンがあります。](images/seviewofimages.png)

## ステップ 3: アクティブ化イベントを処理する


[**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331) イベント ハンドラーは、すべてのファイル アクティブ化イベントを受け取ります。

> [!div class="tabbedCodeSnippets"]
```vb
Protected Overrides Sub OnFileActivated(ByVal args As Windows.ApplicationModel.Activation.FileActivatedEventArgs)
      ' TODO: Handle file activation
      ' The number of files received is args.Files.Size
      ' The name of the first file is args.Files(0).Name
End Sub
```
```cpp
void App::OnFileActivated(Windows::ApplicationModel::Activation::FileActivatedEventArgs^ args)
{
       // TODO: Handle file activation
       // The number of files received is args->Files->Size
       // The first file is args->Files->GetAt(0)->Name
}
```
```cs
protected override void OnFileActivated(FileActivatedEventArgs args)
{
       // TODO: Handle file activation
       // The number of files received is args.Files.Size
       // The name of the first file is args.Files[0].Name
}
```

    > **Note**  When launched via File Contract, make sure that Back button takes the user back to the screen that launched the app and not to the app's previous content.

[!div class="tabbedCodeSnippets"] 新しいページを開くアクティブ化イベントごとにアプリで新しい XAML フレームを作成することをお勧めします。 こうすると、新しい XAML フレームのナビゲーション バックスタックに、中断されたときに現在のウィンドウに表示されていた以前のコンテンツが含まれなくなります。

起動コントラクトとファイル コントラクトで単一 XAML フレームを使うことにしたアプリは、新しいページに移動する前にフレームのナビゲーション ジャーナルにあるページをクリアする必要があります。

## ファイル アクティブ化によって起動されたときは、アプリの先頭ページに戻ることができる UI を含めることを検討してください。


注釈 受け取るファイルは、信頼できないソースからのファイルである可能性があります。 操作する前に、ファイルのコンテンツを検証することをお勧めします。

> 入力の検証について詳しくは、[安全なコードの記述](http://go.microsoft.com/fwlink/p/?LinkID=142053)をご覧ください。 
            **注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。

 

## Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

**関連トピック**

* [完全な例](http://go.microsoft.com/fwlink/p/?LinkID=231484)

**Association Launching サンプル**

* [概念](https://msdn.microsoft.com/library/windows/desktop/cc144154)
* [既定のプログラム](https://msdn.microsoft.com/library/windows/desktop/hh848047)

**ファイルの種類とプロトコルの関連付けのモデル**

* [処理手順](launch-the-default-app-for-a-file.md)
* [ファイルに応じた既定のアプリの起動](handle-uri-activation.md)

**URI のアクティブ化の処理**

* [ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh700321)

**ファイルの種類と URI のガイドライン**
* [**リファレンス**](https://msdn.microsoft.com/library/windows/apps/br224716)
* [**Windows.ApplicationModel.Activation.FileActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br242331)

 

 



<!--HONumber=Jun16_HO5-->


