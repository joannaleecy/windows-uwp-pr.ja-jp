---
ms.assetid: 2b63a4c8-b1c0-4c77-95ab-0b9549ba3c0e
description: このトピックでは、Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリへの非常に単純な Windows Phone Silverlight アプリの移植のケース スタディを表示します。
title: Windows Phone Silverlight は、UWP のケース スタディ、Bookstore1
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 2b9f8de488ad0baea1de9aea5c911f2519385d25
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653867"
---
# <a name="windowsphone-silverlight-to-uwp-case-study-bookstore1"></a>UWP のケース スタディ「Windows Phone Silverlight:Bookstore1


このトピックでは、Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリへの非常に単純な Windows Phone Silverlight アプリの移植のケース スタディを表示します。 Windows 10 ではパッケージを作成する 1 つのアプリをさまざまなデバイス、上に顧客をインストールし、このケース スタディでは何です。 「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください。

移植するアプリは、ビュー モデルにバインドされた **ListBox** で構成されます。 ビュー モデルにはタイトル、著者、表紙を示す書籍の一覧が含まれます。 表紙画像では、**[ビルド アクション]** が **[コンテンツ]** に設定され、**[出力ディレクトリにコピー]** が **[コピーしない]** に設定されています。

このセクションの前のトピックでは、プラットフォーム間の違いについて説明し、ビュー モデルへのバインドを通じて、データへのアクセスに至るまで、XAML マークアップからのアプリのさまざまな要素に対する移植プロセスの詳細とガイダンスを提供しました。 ケース スタディでは、実際の例が動作するようすを示すことにより、このガイダンスを補足することを目的としています。 ケース スタディは、ガイダンスを読み終わっていることを前提としているため、繰り返し説明することはありません。

**注**   Bookstore1Universal を開くときに\_"Visual Studio の更新に必要な"メッセージを表示する場合、Visual Studio での 10 でのターゲット プラットフォーム バージョン管理の選択の手順に従って[TargetPlatformVersion](wpsl-to-uwp-troubleshooting.md)します。

## <a name="downloads"></a>ダウンロード

[ダウンロード Bookstore1WPSL8 の Windows Phone Silverlight アプリ](https://go.microsoft.com/fwlink/?linkid=517053)します。

[ダウンロード、Bookstore1Universal\_10 の Windows 10 アプリ](https://go.microsoft.com/fwlink/?linkid=532950)します。

## <a name="the-windowsphone-silverlight-app"></a>Windows Phone Silverlight アプリ

次に、ここで移植するアプリ Bookstore1WPSL8 の外観を示します。 これは、アプリ名とページ タイトルの見出しの下に、縦方向にスクロールする書籍のリスト ボックスを示すシンプルなアプリです。

![bookstore1wpsl8 の外観](images/wpsl-to-uwp-case-studies/c01-01-wpsl-how-the-app-looks.png)

## <a name="porting-to-a-windows10-project"></a>Windows 10 プロジェクトへの移植

Visual Studio で新しいプロジェクトを作成し、そこへ Bookstore1WPSL8 からファイルをコピーし、コピーしたファイルを新しいプロジェクトに含めるというタスクは、非常に短時間で実行できます。 最初に、"新しいアプリケーション (Windows ユニバーサル)" プロジェクトを新規作成します。 名前を付けます Bookstore1Universal\_10。 これらの Bookstore1Universal Bookstore1WPSL8 から経由でコピーするファイルは\_10。

-   書籍カバーの画像の PNG ファイルを含むフォルダーにコピー (フォルダーが\\資産\\CoverImages)。 フォルダーをコピーしたら、**ソリューション エクスプローラー**で **[すべてのファイルを表示]** がオンであることを確認します。 コピーしたフォルダーを右クリックし、**[プロジェクトに含める]** をクリックします。 このコマンドは、ファイルまたはフォルダーをプロジェクトに "含める" ことを意味します。 ファイルやフォルダーをコピーするたびに、**ソリューション エクスプローラー**で **[更新]** をクリックしてから、ファイルまたはフォルダーをプロジェクトに含めます。 コピー先で置き換えるファイルについては、この手順を実行する必要はありません。
-   ビュー モデルのソース ファイルを含むフォルダーをコピー (フォルダーが\\ViewModel)。
-   MainPage.xaml をコピーして、コピー先のファイルを置き換えます。

私たちは、App.xaml、および Visual Studio によって生成された Windows 10 プロジェクトで App.xaml.cs を保持できます。

コピーしたソース コードとマークアップ ファイルを編集して Bookstore1Universal に Bookstore1WPSL8 名前空間への参照を変更\_10。 これをすばやく行うには、**[フォルダーを指定して置換]** 機能を使います。 ビュー モデルのソース ファイルに含まれている命令型コードでは、移植作業のために次の変更を行う必要があります。

-   `System.ComponentModel.DesignerProperties` を `DesignMode` に変更した後、これに対して **[解決]** コマンドを使います。 `IsInDesignTool` プロパティを削除し、IntelliSense を使って適切なプロパティ名 (`DesignModeEnabled`) を追加します。
-   `ImageSource` に対して **[解決]** コマンドを使います。
-   `BitmapImage` に対して **[解決]** コマンドを使います。
-   using `System.Windows.Media;` と `using System.Windows.Media.Imaging;` を削除します。
-   によって返される値の変更、 **Bookstore1Universal\_10.BookstoreViewModel.AppName**プロパティを"BOOKSTORE1WPSL8"から"BOOKSTORE1UNIVERSAL"にします。

MainPage.xaml では、移植作業のために次の変更を行う必要があります。

-   `phone:PhoneApplicationPage` を `Page` に変更します (プロパティ要素構文での使用回数を考慮してください)。
-   `phone` と `shell` の名前空間のプレフィックス宣言を削除します。
-   その他の名前空間のプレフィックス宣言で、"clr-namespace" を "using" に変更します。

一時的にマークアップを削除することになっても、すぐに結果を確認したい場合は、マークアップ コンパイル エラーを非常に単純に修正することもできます。 ただしここでは、そうすることでとりあえず先に進み、後で見直すことにしましょう。 次に、このための手順を示します。

1.  **MainPage.xaml** のルート **Page** 要素で、`SupportedOrientations="Portrait"` を削除します。
2.  **MainPage.xaml** のルート **Page** 要素で、`Orientation="Portrait"` を削除します。
3.  **MainPage.xaml** のルート **Page** 要素で、`shell:SystemTray.IsVisible="True"` を削除します。
4.  `BookTemplate` データ テンプレートで、`PhoneTextExtraLargeStyle` および `PhoneTextSubtleStyle` の  **TextBlock** スタイルへの参照を削除します。
5.  `TitlePanel`   **StackPanel** で、`PhoneTextNormalStyle` および `PhoneTextTitle1Style` の  **TextBlock** スタイルへの参照を削除します。

最初にモバイル デバイス ファミリの UI の作業を行い、その後でその他のフォーム ファクターについて検討します。 これで、アプリをビルドして実行できるようになりました。 モバイル エミュレーターでは次のように表示されます。

![最初のソース コードの変更を加えたモバイルの UWP アプリ](images/wpsl-to-uwp-case-studies/c01-02-mob10-initial-source-code-changes.png)

ビューおよびビュー モデルは、適切に連携しており、**ListBox** が機能しています。 ほとんどの場合、若干スタイルを修正して、画像を表示する必要があります。

## <a name="paying-off-the-debt-items-and-some-initial-styling"></a>削除した項目と一部の初期スタイルを戻す

既定では、すべての向きがサポートされます。 自体は、Windows Phone Silverlight アプリが明示的に制約を縦専用に、その負債項目\#1 と\#2 が新しいプロジェクトで、アプリ パッケージのマニフェストに移動し完済**縦****向きをサポートされている**します。

このアプリでは、項目\#3 は、負債ので (旧称: システム トレイ) ステータス バーは既定で表示されます。 項目の\#4 と\#5、4 つのユニバーサル Windows プラットフォーム (UWP) を検索する必要があります **TextBlock**を使用していた Windows Phone Silverlight スタイルに対応するスタイル。 Windows Phone Silverlight アプリをエミュレーターで実行でき、比較の図と並行して、[テキスト](wpsl-to-uwp-porting-xaml-and-ui.md)セクション。 これを行う、および Windows Phone Silverlight のシステム スタイルのプロパティを見てから、このテーブルを実行できます。

| Windows Phone Silverlight スタイル キー | UWP スタイル キー          |
|-------------------------------------|------------------------|
| PhoneTextExtraLargeStyle            | TitleTextBlockStyle    |
| PhoneTextSubtleStyle                | SubtitleTextBlockStyle |
| PhoneTextNormalStyle                | CaptionTextBlockStyle  |
| PhoneTextTitle1Style                | HeaderTextBlockStyle   |
 
こうしたスタイルを設定するために、マークアップ エディターに単純に入力するか、Visual Studio XAML ツールを使えば入力なしで設定できます。 右クリック、 **TextBlock**クリック**スタイルの編集** &gt; **リソースの適用**。 **TextBlock**内の項目テンプレートを右クリックして、 **ListBox**  をクリック**追加テンプレートの編集** &gt; **編集生成された項目 (ItemTemplate)** します。

**ListBox** コントロールの既定のスタイルでは背景に `ListBoxBackgroundThemeBrush` システム リソースが設定されるため、項目の背景は 80% の不透明な白になります。 **ListBox** で `Background="Transparent"` を設定し、背景をクリアします。 項目テンプレートで **TextBlock** を左揃えにするには、前記と同様に再度編集し、両方の **TextBlock** で `"9.6,0"` の **Margin** を設定します。

これが終わったら、[表示ピクセルに関連する変更](wpsl-to-uwp-porting-xaml-and-ui.md)のために、まだ変更していないすべての固定サイズの寸法 (余白、幅、高さなど) について、0.8 を乗算する必要があります。 したがって、たとえば画像は 70 x 70px から 56 x 56px に変更する必要があります。

ただし、スタイルの結果を示す前に、画像を描画しましょう。

## <a name="binding-an-image-to-a-view-model"></a>ビュー モデルへの画像のバインド

Bookstore1WPSL8 では、次のことを適用しました。

```csharp
    // this.BookCoverImagePath contains a path of the form "/Assets/CoverImages/one.png".
    return new BitmapImage(new Uri(this.CoverImagePath, UriKind.Relative));
```

Bookstore1Universal では、ms-appx [URI スキーム](https://msdn.microsoft.com/library/windows/apps/jj655406)を使います。 残るコードを変更せずに維持するために、**System.Uri** コンストラクターの異なるオーバーロードを使って、ベース URI に ms-appx URI スキームを格納し、パスの残る部分を追加できます。 次に例を示します。

```csharp
    // this.BookCoverImagePath contains a path of the form "/Assets/CoverImages/one.png".
    return new BitmapImage(new Uri(new Uri("ms-appx://"), this.CoverImagePath));
```

## <a name="universal-styling"></a>ユニバーサル スタイル設定

後は、いくつかの最終的なスタイルの調整を行い、アプリがデスクトップ (およびその他) のフォーム ファクターとモバイルで適切に表示されることを確認するだけです。 手順は次のとおりです。 このトピックの上部にあるリンクを使用して、プロジェクトをダウンロードし、この時点とケース スタディの終了時の間のすべての変更の結果を参照できます。

-   項目間のスペースを縮めるために、MainPage.xaml で `BookTemplate` データ テンプレートを探し、`Margin` 属性をルート **Grid** から削除します。
-   ページ タイトルに少しゆとりを与える場合は、`-5.6` の下部の余白をページ タイトル **TextBlock** で `0` に設定します。
-   ここで、`LayoutRoot` の Background を適切な既定値に設定して、テーマが何であるかに関係なく、すべてのデバイスでの実行時にアプリが適切に表示されるようにする必要があります。 これを、`"Transparent"` から `"{ThemeResource ApplicationPageBackgroundThemeBrush}"` に変更します。

ここで、より洗練されたアプリにより、「[フォーム ファクターとユーザー エクスペリエンスのための移植](wpsl-to-uwp-form-factors-and-ux.md)」のガイダンスを参考にして、実際にアプリで実行できる多くのデバイスのそれぞれで、フォーム ファクターを最適に利用します。 このシンプルなアプリでは、ここで停止し、スタイル操作の最後の手順を行った後のアプリの外観を確認します。 実際には、モバイル デバイスとデスクトップ デバイスで同じに表示されますが、広いフォーム ファクターの領域を最大限に活用していません (ただし、後のケース スタディで、これを行う方法を調査します)。

アプリのテーマの管理方法については、「[テーマの変更](wpsl-to-uwp-porting-xaml-and-ui.md)」をご覧ください。

![移植された Windows 10 アプリ](images/w8x-to-uwp-case-studies/c01-07-mob10-ported.png)

モバイル デバイスで実行されている Windows 10 アプリのインポート

## <a name="an-optional-adjustment-to-the-list-box-for-mobile-devices"></a>モバイル デバイス向けのリスト ボックスの調整 (オプション)

モバイル デバイスでのアプリの実行中には、両方のテーマで既定で、リスト ボックスの背景は淡色です。 このスタイルで問題なければ、それ以上の操作は必要ありません。 コントロールは、動作に影響を及ぼすことなく、表示形式をカスタマイズできるように設計されています。 元のアプリの外観のように、濃色のテーマでリスト ボックスを濃色にする場合は、[このページ](w8x-to-uwp-case-study-bookstore1.md)の「モバイル デバイス向けのリスト ボックスの調整 (オプション)」の手順に従います。

## <a name="conclusion"></a>まとめ

このケース スタディでは、非常に単純なアプリ (実在しないと考えらえる単純なアプリ) を移植するプロセスを示しました。 たとえば、リスト コントロールは、選択用またはナビゲーション コンテキストの確立用に使うことができます。アプリは、タップされた項目に関する詳細を提示するページに移動します。 この特定のアプリは、ユーザーの選択に対して何も処理せず、またナビゲーション機能がありません。 それでも、このケース スタディは、まず移植プロセスを導入し、実際の UWP  アプリで使うことができる重要な手法をデモする役割を果たします。

次のケース スタディは「[Bookstore2](wpsl-to-uwp-case-study-bookstore2.md)」です。ここでは、グループ化されたデータへのアクセスと表示について説明します。
