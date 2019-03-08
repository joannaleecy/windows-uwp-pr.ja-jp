---
title: ファイルのアクティブ化の処理
description: アプリは、特定のファイルの種類の既定のハンドラーとして登録することができます。
ms.assetid: A0F914C5-62BC-4FF7-9236-E34C5277C363
ms.date: 07/05/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: eaf6118720ab77931decf93113a13341ab4f51d0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642177"
---
# <a name="handle-file-activation"></a>ファイルのアクティブ化の処理

**重要な API**

-   [**Windows.ApplicationModel.Activation.FileActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224716)
-   [**Windows.UI.Xaml.Application.OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331)

アプリは、特定のファイルの種類の既定のハンドラーを登録できます。 Windows デスクトップ アプリケーションとユニバーサル Windows プラットフォーム (UWP) アプリの両方を、既定のファイル ハンドラーとして登録できます。 ユーザーがアプリを特定のファイルの種類の既定のハンドラーとして選ぶと、アプリはその種類のファイルを起動したときにアクティブ化されます。

ファイルの種類に登録するのは、その種類のファイルのすべてのファイル起動を処理する場合のみにすることをお勧めします。 アプリをそのファイルの種類に内部的にのみ使う場合、既定のハンドラーに登録する必要はありません。 ファイルの種類に登録する場合は、そのファイルの種類のためにアプリをアクティブ化した際に期待される機能をエンド ユーザーに提供する必要があります。 たとえば、.jpg ファイルを表示する画像ビューアー アプリを登録できます。 ファイルの関連付けについて詳しくは、「[ファイルの種類と URI のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh700321)」をご覧ください。

以下の手順では、カスタムのファイルの種類 .alsdk を登録する方法と、ユーザーによって .alsdk ファイルが起動されたときにアプリをアクティブ化する方法について説明します。

> **注**  、UWP アプリで特定の Uri とファイル拡張機能用に予約された組み込みのアプリと、オペレーティング システムでします。 予約されている URI またはファイル拡張子にアプリを登録しようとしても無視されます。 詳しくは、「[予約済みのファイルと URI スキーム名](reserved-uri-scheme-names.md)」をご覧ください。

## <a name="step-1-specify-the-extension-point-in-the-package-manifest"></a>手順 1:パッケージ マニフェストで拡張機能ポイントを指定します。

アプリは、パッケージ マニフェストに一覧表示されるファイル拡張子のアクティブ化イベントだけを受け取ります。 アプリが `.alsdk` 拡張子を持つファイルを処理することを示す方法は次のとおりです。

1.  **ソリューション エクスプローラー**で、package.appxmanifest をダブルクリックしてマニフェスト デザイナーを開きます。 **[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[ファイルの種類の関連付け]** を選んで **[追加]** をクリックします。 ファイルの関連付けで使われる識別子について詳しくは、「[プログラムの識別子](https://msdn.microsoft.com/library/windows/desktop/cc144152)」をご覧ください。

    マニフェスト デザイナーで指定することができる各フィールドについて、以下で簡単に説明します。

| フィールド | 説明 |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **表示名** | ファイルの種類のグループの表示名を指定します。 表示名は、**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) でファイルの種類を識別するために使われます。 |
| **ロゴ** | デスクトップと**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) でファイルの種類を識別するために使われるロゴを指定します。 ロゴを指定しない場合は、アプリケーションの小さいロゴが使われます。 |
| **に関するヒント** | ファイルの種類のグループの [InfoTip](https://msdn.microsoft.com/library/windows/desktop/cc144152) を指定します。 このヒントのテキストは、ユーザーがこの種類のファイルのアイコンの上にマウス ポインターを置くと表示されます。 |
| **名前** | 同じ表示名、ロゴ、InfoTip、編集フラグを共有するファイルの種類のグループの名前を選びます。 このグループ名は、アプリの更新後も維持される名前にします。 **注**  名前はすべて小文字である必要があります。 |
| **コンテンツの種類** | 特定のファイルの種類の MIME コンテンツの種類 (**image/jpeg** など) を指定します。 **許可されているコンテンツの種類についての重要な注意事項:** 予約または禁止されるため、パッケージ マニフェストに入力することはできませんの MIME コンテンツ タイプのアルファベット順の一覧を次に示します:**アプリケーション/強制ダウンロード**、**アプリケーションまたはオクテット ストリーム**、**アプリケーション、または不明な**、**アプリケーション/x-msdownload**します。 |
| **ファイルの種類** | 登録するファイルの種類を指定します。先頭にはピリオドを付けます (例: ".jpeg")。 **予約されており、禁止されているファイルの種類:** 参照してください[予約済みの URI スキームの名前とファイルの種類](reserved-uri-scheme-names.md)のアルファベット順の一覧ファイルの種類の組み込みのアプリを予約または禁止されるため、UWP アプリを登録することはできません。 |

2.  **[名前]** に `alsdk` と入力します。
3.  **[ファイルの種類]** に `.alsdk` と入力します。
4.  入力"イメージ\\Icon.png"のロゴとして。
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

## <a name="step-2-add-the-proper-icons"></a>手順 2:適切なアイコンを追加します。

ファイルの種類の既定となるアプリは、そのアイコンがシステムのさまざまな場所に表示されます。 アイコンは、たとえば次の場所に表示されます。

-   エクスプローラーの項目ビュー、コンテキスト メニュー、リボン
-   [既定のプログラム] コントロール パネル
-   ファイル ピッカー
-   スタート画面での検索結果

ロゴがこれらの場所に表示されるように、プロジェクトに 44 x 44 のアイコンを含めます。 アプリのタイルのロゴの外観を調和させ、アイコンを透明にするのではなく、アプリの背景色を使います。 パディングせずにロゴを端まで拡張します。 アイコンは、白い背景でテストします。 アイコンについて詳しくは、「[タイルとアイコン アセットのガイドライン](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/app-assets)」をご覧ください。

## <a name="step-3-handle-the-activated-event"></a>手順 3:アクティブ化されたイベントを処理します。

[  **OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331) イベント ハンドラーは、すべてのファイル アクティブ化イベントを受け取ります。

```csharp
protected override void OnFileActivated(FileActivatedEventArgs args)
{
       // TODO: Handle file activation
       // The number of files received is args.Files.Size
       // The name of the first file is args.Files[0].Name
}
```

```vb
Protected Overrides Sub OnFileActivated(ByVal args As Windows.ApplicationModel.Activation.FileActivatedEventArgs)
      ' TODO: Handle file activation
      ' The number of files received is args.Files.Size
      ' The name of the first file is args.Files(0).Name
End Sub
```

```cppwinrt
void App::OnFileActivated(Windows::ApplicationModel::Activation::FileActivatedEventArgs const& args)
{
    // TODO: Handle file activation.
    auto numberOfFilesReceived{ args.Files().Size() };
    auto nameOfTheFirstFile{ args.Files().GetAt(0).Name() };
}
```

```cpp
void App::OnFileActivated(Windows::ApplicationModel::Activation::FileActivatedEventArgs^ args)
{
    // TODO: Handle file activation
    // The number of files received is args->Files->Size
    // The name of the first file is args->Files->GetAt(0)->Name
}
```

> [!NOTE]
> ファイルのコントラクトを使用してを起動するとその [戻る] ボタンを受け取り、ユーザー バックアップ、アプリの起動画面にアプリの前のコンテンツにしないことを確認します。

新しい XAML を作成することをお勧めします。**フレーム**アクティブ化イベントのごとに新しいページが開きます。 これにより、新しい XAML フレームのナビゲーション バック スタックは、アプリが中断されている場合は、現在のウィンドウに対して持つ前のコンテンツが含まれません。 1 つの XAML を使用する場合**フレーム**起動、ファイルの契約では、しする必要がありますをオフにする、ページで、**フレーム**の新しいページに移動する前にジャーナルのナビゲーションです。

ファイルのアクティブ化を使用して、アプリを起動すると、ユーザー、アプリの最上位のページに戻るには、UI などを検討してください。

## <a name="remarks"></a>注釈

受け取るファイルは、信頼できないソースからのファイルである可能性があります。 操作する前に、ファイルのコンテンツを検証することをお勧めします。 入力の検証について詳しくは、[安全なコードの記述](https://go.microsoft.com/fwlink/p/?LinkID=142053)をご覧ください。

## <a name="related-topics"></a>関連トピック

### <a name="complete-example"></a>完全な例

* [アソシエーションの起動のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=231484)

### <a name="concepts"></a>概念

* [既定のプログラム](https://msdn.microsoft.com/library/windows/desktop/cc144154)
* [ファイルの種類とプロトコルの関連付けのモデル](https://msdn.microsoft.com/library/windows/desktop/hh848047)

### <a name="tasks"></a>タスク

* [ファイルに応じた既定のアプリの起動](launch-the-default-app-for-a-file.md)
* [URI のアクティブ化の処理](handle-uri-activation.md)

### <a name="guidelines"></a>ガイドライン

* [ファイルの種類と Uri のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh700321)

### <a name="reference"></a>リファレンス
* [Windows.ApplicationModel.Activation.FileActivatedEventArgs](https://msdn.microsoft.com/library/windows/apps/br224716)
* [Windows.UI.Xaml.Application.OnFileActivated](https://msdn.microsoft.com/library/windows/apps/br242331)
