---
author: stevewhims
title: Windows ランタイム 8.x から UWP へのケース スタディ - Bookstore1
ms.assetid: e4582717-afb5-4cde-86bb-31fb1c5fc8f3
description: このトピックでは、windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリに非常に単純なユニバーサル 8.1 アプリを移植するケース スタディを示します。
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: cec8171b381a607616e2054784fa888074d3f90e
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6251724"
---
# <a name="windows-runtime-8x-to-uwp-case-study-bookstore1"></a>Windows ランタイム 8.x から UWP へのケース スタディ - Bookstore1


このトピックでは、Windows10Universal Windows プラットフォーム (UWP) アプリに非常に単純なユニバーサル 8.1 アプリを移植するケース スタディを示します。 ユニバーサル 8.1 アプリは、Windows8.1、1 つのアプリ パッケージと Windows Phone 8.1 のさまざまなアプリ パッケージをビルドします。 Windows 10 では、作成できます単一のアプリ パッケージを多様なデバイスにインストールできるし、このケース スタディで行うことです。 「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください。

移植するアプリは、ビュー モデルにバインドされた **ListBox** で構成されます。 ビュー モデルにはタイトル、著者、表紙を示す書籍の一覧が含まれます。 表紙画像では、**[ビルド アクション]** が **[コンテンツ]** に設定され、**[出力ディレクトリにコピー]** が **[コピーしない]** に設定されています。

このセクションの前のトピックでは、プラットフォーム間の違いについて説明し、ビュー モデルへのバインドを通じて、データへのアクセスに至るまで、XAML マークアップからのアプリのさまざまな要素に対する移植プロセスの詳細とガイダンスを提供しました。 ケース スタディでは、実際の例が動作するようすを示すことにより、このガイダンスを補足することを目的としています。 ケース スタディは、ガイダンスを読み終わっていることを前提としているため、繰り返し説明することはありません。

**注:** と Visual Studio で bookstore1universal \_10 を開く「Visual Studio 更新プログラムが必要」、メッセージを表示し、手順に従います[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)します。

## <a name="downloads"></a>ダウンロード

[Bookstore1\_81 ユニバーサル 8.1 アプリをダウンロードします](http://go.microsoft.com/fwlink/?linkid=532946)。

[ダウンロード bookstore1universal \_10 windows 10 アプリ](http://go.microsoft.com/fwlink/?linkid=532950)。

## <a name="the-universal-81-app"></a>ユニバーサル 8.1 アプリ

次に、ここで移植するアプリ Bookstore1\_81 の外観を示します。 これは、アプリ名とページ タイトルの見出しの下に、縦方向にスクロールする書籍のリスト ボックスを示すシンプルなアプリです。

![Windows での Bookstore1\-81 の外観](images/w8x-to-uwp-case-studies/c01-01-win81-how-the-app-looks.png)

Windows での Bookstore1\_81

![Windows Phone での Bookstore1\-81 の外観](images/w8x-to-uwp-case-studies/c01-02-wp81-how-the-app-looks.png)

Windows Phone での Bookstore1\_81

##  <a name="porting-to-a-windows10-project"></a>Windows 10 プロジェクトへの移植

Bookstore1\_81 ソリューションは、8.1 ユニバーサル アプリ プロジェクトであり、次のプロジェクトを含んでいます。

-   Bookstore1\_81.Windows。 これは、Windows8.1 用アプリ パッケージを構築するプロジェクトです。
-   Bookstore1\_81.WindowsPhone。 これは、Windows Phone 8.1 用アプリ パッケージを構築するプロジェクトです。
-   Bookstore1\_81.Shared。 これは、他の 2 つのプロジェクトの両方で使われるソース コード、マークアップ ファイル、および他のアセットやリソースを含むプロジェクトです。

このケース スタディでは、サポートするデバイスに関して、「[ユニバーサル 8.1 アプリがある場合](w8x-to-uwp-root.md)」で説明した通常のオプションを使います。 意思決定をここでは、単純なもの: このアプリと同じの機能があり、Windows8.1 と Windows Phone 8.1 の両方の形式で、同じコードで、ほとんどの場合。 そのためを移植します (とその他のプロジェクトから必要なもの) を共有プロジェクトの内容を (1 つは多様なデバイスにインストールすることができます)、ユニバーサル デバイス ファミリを対象とした windows 10。

Visual Studio で新しいプロジェクトを作成し、そこへ Bookstore1\_81 からファイルをコピーし、コピーしたファイルを新しいプロジェクトに含めるという作業は、非常に短時間で実行できます。 最初に、"新しいアプリケーション (Windows ユニバーサル)" プロジェクトを新規作成します。 そして、"Bookstore1Universal\_10" という名前を付けます。 Bookstore1\_81 から Bookstore1Universal\_10 にコピーするファイルを、以下に示します。

**共有プロジェクトから**

-   ブック カバーの画像の PNG ファイルを含むフォルダー (フォルダーは \\Assets\\CoverImages) をコピーします。 フォルダーをコピーしたら、**ソリューション エクスプローラー**で **[すべてのファイルを表示]** がオンであることを確認します。 コピーしたフォルダーを右クリックし、**[プロジェクトに含める]** をクリックします。 このコマンドは、ファイルまたはフォルダーをプロジェクトに "含める" ことを意味します。 ファイルやフォルダーをコピーするたびに、**ソリューション エクスプローラー**で **[更新]** をクリックしてから、ファイルまたはフォルダーをプロジェクトに含めます。 コピー先で置き換えるファイルについては、この手順を実行する必要はありません。
-   ビュー モデル ソース ファイルを含むフォルダー (フォルダーは \\ViewModel) をコピーします。
-   MainPage.xaml をコピーして、コピー先のファイルを置き換えます。

**Windows プロジェクトから**

-   BookstoreStyles.xaml をコピーします。 このファイル内のすべてのリソース キーは、windows 10 アプリで解決されるため、出発点として 1 つ使用します同等の WindowsPhone ファイル内にある一部のではありません。

コピーしたソース コードとマークアップ ファイルを編集し、Bookstore1\_81 名前空間への参照をすべて、Bookstore1Universal\_10 に変更します。 これをすばやく行うには、**[フォルダーを指定して置換]** 機能を使います。 ビュー モデルでも、その他の命令型コードでも、コードを変更する必要はありません。 ただし、どのバージョンのアプリが実行されているかをわかりやすくするために、**Bookstore1Universal\_10.BookstoreViewModel.AppName** プロパティによって返される値を、"BOOKSTORE1\_81" から "BOOKSTORE1UNIVERSAL\_10" に変更します。

これで、ビルドして実行することができます。 Windows 10 へ移植するためにまだ具体的な作業を行っていませんが、新しい UWP アプリの外観を次に示します。

![最初のソース コードの変更を加えた Windows 10 アプリ](images/w8x-to-uwp-case-studies/c01-03-desk10-initial-source-code-changes.png)

デスクトップ デバイスで実行されている最初のソース コードの変更を使った windows 10 アプリ

![最初のソース コードの変更を加えた Windows 10 アプリ](images/w8x-to-uwp-case-studies/c01-04-mob10-initial-source-code-changes.png)

モバイル デバイスで実行されている最初のソース コードの変更を使った windows 10 アプリ

ビューおよびビュー モデルは、適切に連携しており、**ListBox** が機能しています。 修正が必要なのは、スタイル設定だけです。 淡色テーマのモバイル デバイスでは、リスト ボックスの境界線が表示されますが、これは、簡単に非表示にすることができます。 そして、文字体裁が大きすぎるため、ここで使うスタイルを変更します。 また、既定のような外観にしたい場合は、デスクトップ デバイスでの実行時のアプリの色を淡色にする必要があります。 では、それを変更しましょう。

## <a name="universal-styling"></a>ユニバーサル スタイル設定

Bookstore1 \_81 アプリでは、Windows8.1 と Windows Phone 8.1 のオペレーティング システムには、そのスタイルを調整するのに 2 つの異なるリソース ディクショナリ (BookstoreStyles.xaml) を使用します。 これら 2 つの BookstoreStyles.xaml ファイルのどちらも、windows 10 アプリに必要なスタイル正確が含まれています。 ただし、さいわいなことに、目的としているのは、そのどちらよりもはるかに単純なスタイルです。 したがって、以降の手順で行うのはほとんど、プロジェクト ファイルとマークアップの削除と簡素化の作業です。 手順は次のとおりです。 このトピックの上部にあるリンクを使用して、プロジェクトをダウンロードし、この時点とケース スタディの終了時の間のすべての変更の結果を参照できます。

-   項目間のスペースを縮めるために、MainPage.xaml で `BookTemplate` データ テンプレートを探し、`Margin="0,0,0,8"` をルートの **Grid** から削除します。
-   また、`BookTemplate` には、`BookTemplateTitleTextBlockStyle` と `BookTemplateAuthorTextBlockStyle` への参照があります。 Bookstore1\_81 は、それらのキーを間接参照として使うため、2 つのアプリで 1 つのキーの実装が異なります。 その間接参照は、必要ではなくなりました。システム スタイルを直接参照できます。 そこで、これらの参照をそれぞれ、`TitleTextBlockStyle` と `SubtitleTextBlockStyle` で置き換えます。
-   ここで、`LayoutRoot` の Background を適切な既定値に設定して、テーマが何であるかに関係なく、すべてのデバイスでの実行時にアプリが適切に表示されるようにする必要があります。 これを、`"Transparent"` から `"{ThemeResource ApplicationPageBackgroundThemeBrush}"` に変更します。
-   `TitlePanel` で、`TitleTextBlockStyle` (今では少し大きすぎる) への参照を `CaptionTextBlockStyle` への参照に変更します。 `PageTitleTextBlockStyle`  も、もう不要になった Bookstore1\_81 間接参照です。 これは、代わりに `HeaderTextBlockStyle` を参照するように変更します。
-   **ListBox** で特別な Background、Style、ItemContainerStyle を設定する必要はなくなったので、この 3 つの属性とその値をマークアップから削除します。 ただし、**ListBox** の境界線を非表示にする必要があるため、これに `BorderBrush="{x:Null}"` を追加します。
-   BookstoreStyles.xaml (**ResourceDictionary** ファイル) 内のリソースはすべて、参照されなくなります。 これらのリソースはすべて削除できます。 ただし、BookstoreStyles.xaml ファイル自体を削除しないでください。次のセクションで示すように、まだ、最後の用途があります。

スタイル設定操作の最後のシーケンスで、アプリの外観は次のようになります。

![ほとんどの移植が行われた Windows 10 アプリ](images/w8x-to-uwp-case-studies/c01-05-desk10-almost-ported.png)

デスクトップ デバイスで実行されている、ほとんどの移植が行われた windows 10 アプリ

![ほとんどの移植が行われた Windows 10 アプリ](images/w8x-to-uwp-case-studies/c01-06-mob10-almost-ported.png)

モバイル デバイスで実行されている、ほとんどの移植が行われた windows 10 アプリ

## <a name="an-optional-adjustment-to-the-list-box-for-mobile-devices"></a>モバイル デバイス向けのリスト ボックスの調整 (オプション)

モバイル デバイスでのアプリの実行中には、両方のテーマで既定で、リスト ボックスの背景は淡色です。 このスタイルを使うことができます。使う場合は、整理以外の作業はありません。つまり、BookstoreStyles.xaml リソース ディクショナリ ファイルと、それを MainPage.xaml にマージするマークアップをプロジェクトから削除するだけです。

コントロールは、動作に影響を及ぼすことなく、表示形式をカスタマイズできるように設計されています。 元のアプリの外観のように、濃色のテーマでリスト ボックスを濃色にする場合は、次のセクションで説明する方法をご覧ください。

変更をアプリに反映させる必要があるのは、モバイル デバイスでアプリを実行するときだけです。 したがって、モバイル デバイス ファミリで実行するときには、わずかにカスタマイズしたリスト ボックスのスタイルを使い、それ以外のすべてのデバイスで実行するときには、既定のスタイルを引き続き使います。 これを行うには、BookstoreStyles.xaml のコピーを作成し、それに、特別な MRT 修飾名を付けて、モバイル デバイスでのみ読み込まれるようにします。

新しい **ResourceDictionary** プロジェクト項目を追加し、BookstoreStyles.DeviceFamily-Mobile.xaml という名前を付けます。 これで、両方の論理名が BookstoreStyles.xaml (これが、マークアップとコードで使用する名前です) である 2 つのファイルができました。 ただし、これらのファイルの物理名は異なっているため、異なるマークアップを含めることができます。 この MRT 修飾名の名前付けスキームは、どの xaml ファイルでも使用できますが、同じ論理名を持つすべての xaml ファイルは、1 つの xaml.cs 分離コード ファイルを共有することに注意してください (この場合、適用されるのは 1 つです)。

リスト ボックスのコントロール テンプレートのコピーを編集し、新しいリソース ディクショナリである BookstoreStyles.DeviceFamily Mobile.xaml 内の `BookstoreListBoxStyle` キーで保存します。 今度は、setter のうち、3 つに単純な変更を加えます。

-   Foreground setter で、値を `"{x:Null}"` に変更します。 プロパティを要素で直接、`"{x:Null}"` に設定することは、コードで `null` に設定することと同じであることに注意してください。 ただし、`"{x:Null}"` の値を setter で使うと、独自の効果があります。既定のスタイルで (同じプロパティの) setter がオーバーライドされ、ターゲット要素でプロパティの既定値が復元されます。
-   Background setter で、値を `"Transparent"` に変更して、その淡色の背景を削除します。
-   Template setter で、`Focused` という名前の表示状態を見つけ、そのストーリー ボードを削除して空のタグにします。
-   その他のすべての setter をマークアップから削除します。

最後に、`BookstoreListBoxStyle` を BookstoreStyles.xaml にコピーし、その 3 つの setter を削除して、空のタグにします。 このようにすると、モバイル以外のデバイスで、BookstoreStyles.xaml と `BookstoreListBoxStyle` への参照が解決されますが、その影響はありません。

![移植された Windows 10 アプリ](images/w8x-to-uwp-case-studies/c01-07-mob10-ported.png)

モバイル デバイスで実行されている、移植された windows 10 アプリ

## <a name="conclusion"></a>まとめ

このケース スタディでは、非常に単純なアプリ (実在しないと考えらえる単純なアプリ) を移植するプロセスを示しました。 たとえば、リスト ボックスは、選択を行ったり、ナビゲーションのコンテキストを確立したりするときに使うことができます。アプリは、タップされた項目に関する詳細を提示するページに移動します。 この特定のアプリは、ユーザーの選択に対して何も処理せず、またナビゲーション機能がありません。 それでも、このケース スタディは、まず移植プロセスを導入し、実際の UWP  アプリで使うことができる重要な手法をデモする役割を果たします。

また、新しいビュー モデルを移行することは、概してスムーズなプロセスであることを確認しました。 ただし、ユーザー インターフェイスや、フォーム ファクターのサポートは、移植する際に注意が必要と考えられる項目です。

次のケース スタディは「[Bookstore2](w8x-to-uwp-case-study-bookstore2.md)」です。ここでは、グループ化されたデータへのアクセスと表示について説明します。
