---
author: Jwmsft
Description: "ポップアップ (flyout) は、ユーザーが現在操作している内容に関係する UI を一時的に表示するために使われる軽量なポップアップです。"
title: "コンテキスト メニューとダイアログ"
ms.assetid: 7CA2600C-A1DB-46AE-8F72-24C25E224417
label: Menus, dialogs, and popups
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: c183f7390c5b4f99cf0f31426c1431066e1bc96d
ms.openlocfilehash: e268a5facebbdb80d7cc5cdd52c1a6f944ef7d00

---
# メニュー、ダイアログ、ポップアップ (flyout)

メニュー、ダイアログ、ポップアップ (flyout) は、ユーザーが要求したとき、または通知や許可を必要とする状況が発生したときに表示される一時的な UI 要素です。

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)
-   [Flyout クラス](https://msdn.microsoft.com/library/windows/apps/dn279496)
-   [ContentDialog クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)

コンテキスト メニューは、すぐに実行できる操作をユーザーに表示します。 コンテキスト メニューにはテキストのコマンドを追加できます。 コンテキスト メニューは、外側をタップまたはクリックして簡単に非表示にすることができます。

ダイアログは、状況依存のアプリ情報を表示するモーダル UI オーバーレイです。 ダイアログは、明示的に閉じられまでアプリ ウィンドウの対話式操作をブロックします。 多くの場合、ユーザーに何らかの操作を要求します。

ポップアップ (flyout) は、ユーザーが現在操作している内容に関係する UI を表示する軽量な状況依存のポップアップです。 このポップアップは、配置ロジックとサイズ設定ロジックを備えており、非表示コントロールを再表示する場合、項目の詳細を表示する場合、またはユーザーに操作の確認を求める場合に使うことができます。 ポップアップは、その外側をタップするかクリックすることで簡易非表示にすることができます。


## 適切なコントロールの選択

コンテキスト メニューは、次のような目的で使うことができます。

-   状況依存の操作。
-   操作する必要があるものの、選択できないオブジェクトのためのコマンド。

ダイアログは、次のような目的で使うことができます。

- 続行前にユーザーが読んだり確認したりする必要のある重要な情報を表示する場合。
- ユーザーによる明確な操作を求める場合、またはユーザーが確認する必要のある重要なメッセージを伝える場合。 次のようなシナリオが考えられます。
  - ユーザーのセキュリティが侵害される可能性がある場合
  - ユーザーが重要な資産に永続的な変更を加えようとしている場合
  - ユーザーが重要な資産を削除しようとしている場合
  - アプリ内購入を確認する場合
- 接続エラーなど、アプリ全体の状況に適用されるエラー メッセージ
- アプリからユーザーにブロック質問を表示する必要がある場合 (アプリで自動的に選ぶことができない場合など) ブロック質問とは、無視したり先送りにしたりできない質問です。この質問では、ユーザーに明確な選択肢を提示する必要があります。

ポップアップは次の目的で使うことができます。

-   一時的な状況依存の UI。
-   警告と確認 (被害が発生する可能性のある操作に関するものなど)。
-   詳細やページ上の項目の長い説明などの詳しい情報の表示。


## 例

単純なコマンドの一覧を表示する、一般的な単一ペインのコンテキスト メニューを示します。 必要な場合にスクロールすることができます。 必要に応じて区切り記号を使い、類似のコマンドをグループ化します。

![一般的なコンテキスト メニューの例](images/controls_contextmenu_singlepane.png)

より包括的なコマンドの集合には、カスケード コンテキスト メニューを使えます。 ポップアップ レベルが複数で、スクロール可能です。 必要に応じて区切り記号を使い、類似のコマンドをグループ化します。

![カスケード コンテキスト メニューの例](images/controls_contextmenu_cascading.png)

次に、ボタンを 1 つ備えた確認ダイアログの全画面表示の例を示します。 この種類のダイアログ ボックスでは、ボタンを押して次に進む前に読まれることを想定した、多くの情報が表示されます。

![ボタンを 1 つ備えたダイアログの全画面表示の例](images/controls_dialog_singlebutton.png)

ボタンを 2 つ備えたダイアログの例を次に示します。このダイアログでは二者択一の選択肢が表示されます。 一般に、このダイアログに表示される情報は簡潔にまとめられています。

![フルボタン ダイアログの例](images/controls_dialog_twobutton.png)

## モーダルと簡易非表示

ダイアログはモーダルです。つまり、ユーザーがダイアログのボタンを選択するまで、アプリとのすべての対話式操作をブロックします。 モーダルな動作を視覚的に強調するために、ダイアログはオーバーレイ レイヤーに表示され、一時的に到達できないアプリの UI を部分的に隠します。

**注:** 利用可能なダイアログ オプションの 1 つに [キャンセル] がある場合は、Esc キーを押してダイアログを閉じることをユーザーに許可できます。 この動作は、コントロールには組み込まれていませんが、一般に実装されるショートカットです。

ポップアップとコンテキスト メニューは簡易非表示コントロールです。つまり、ユーザーはさまざまな操作から選択して、一時的な UI を閉じることができます。 このような対話式操作は、軽量でブロックしないことを目的としています。 簡易非表示操作には次のような操作があります。
- 一時的な UI の外側をタップまたはクリックする
- Esc キーを押す
- [戻る] ボタンを押す
- アプリ ウィンドウのサイズを変更する
- デバイスの向きを変更する


## ダイアログの使用に関するガイドライン

-   ダイアログ内のテキストの 1 行目で、問題やユーザーの目的 (実行する内容) を明確に示す必要があります。
-   ダイアログのタイトルは主な説明で、省略可能です。
    -   簡潔なタイトルを使って、ユーザーがそのダイアログで行う必要がある操作を説明します。 タイトルが長い場合は、折り返されず省略されます。
    -   ダイアログを使って、簡単なメッセージ、エラー、または質問を表示する場合は、タイトルを省略することもできます。 主な情報はコンテンツのテキストを使って伝えます。
    -   タイトルは、ボタンの選択に直接関連するものにします。
-   ダイアログ コンテンツには説明のテキストを含め、これは必須です。
    -   メッセージ、エラー、または操作をブロック質問をできる限り簡潔に示します。
    -   ダイアログ タイトルを使う場合は、コンテンツ領域を詳しい情報の提示や用語の定義に使います。 タイトルの言葉づかいを変えただけの文を繰り返さないようにします。
-   少なくとも 1 つのダイアログ ボタンを表示する必要があります。
    -   ボタンは、ユーザーがダイアログ ボックスを非表示にするための唯一のメカニズムです。
    -   テキストを指定したボタンを使って、主な説明またはコンテンツに対する応答を示します。 たとえば、主な説明が "使っているコンピューターへの AppName からのアクセスを許可しますか?" の場合、"許可" ボタンと "ブロック" ボタンを使います。 具体的な応答の言葉はすばやく理解できるので、効率的に判断できます。
-   エラー ダイアログでは、ダイアログ ボックスにエラー メッセージと関連情報 (ある場合) を表示します。 エラー ダイアログで使う唯一のボタンは "閉じる" かこれに似た操作である必要があります。
-   パスワード フィールドの検証エラーなど、ページの特定の場所に関連するエラーでは、ダイアログを使わずに、アプリのキャンバス自体を使ってインライン エラーを表示します。

## コンテキスト メニューとポップアップ

コンテキスト メニューとポップアップは、対話式操作の動作を共有するコントロールと、密接に関連します。 これらのコントロールの主な違いは、受け入れるコンテンツの種類にあります。

### MenuFlyout
コンテキスト メニューは MenuFlyout クラスを使用して実装し、[ **MenuFlyoutItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyoutitem.aspx)、[ **ToggleMenuFlyoutItem**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)、[ **MenuFlyoutSubItem** ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyoutsubitem.aspx)、および [**MenuFlyoutSeparator**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyoutseparator.aspx) を含めることができます。 他の種類の UI を表示するには、ポップアップを使います。

- **使用に関するガイドライン**
  - 次のような場合は、コンテキスト メニューのコマンドのグループ間に区切り記号を使います。
    - 関連するコマンドのグループを区別する場合。
    - コマンドのセットをグループ化する場合。
    - クリップボード コマンド (切り取り/コピー/貼り付け) などの一般的なコマンドのセットを、アプリまたはビューに固有のコマンドと区別する場合。
  -   ノート PC とデスクトップ PC では、コンテキスト メニューとヒントはアプリケーションのウィンドウに限定されず、一部分は外側に描画できます。 アプリが完全にウィンドウの外側にコンテキスト メニューをレンダリングしようとすると、例外がスローされます。

- **推奨と非推奨**
  -   コンテキスト メニューのコマンドは短くします。 長いコマンドは末尾が切り詰められます。
  -   各コマンド名には、文としての大文字表記を使います。
  -   すべてのコンテキスト メニューで、表示するコマンドの数を最小限にします。
  -   UI 要素を直接操作できる場合は、そのコマンドをコンテキスト メニューに入れないようにします。 コンテキスト メニューは、それ以外では画面に表示されない状況依存のコマンドに限定する必要があります。

### ポップアップ

ポップアップは、オープンエンドなコンテナーで、そのコンテンツとして任意の UI を表示することができます。  ポップアップは、独自の表示部分を持たず、シンプルにコンテンツのコントロールになります。 ポップアップは、余白とコンテンツの周囲に追加するオプションのスクロール バーを持ちます。 ポップアップのスタイルを設定するには、その `FlyoutPresenterStyle` を変更します。

次のコードでは、テキストの折り返しの段落を示し、スクリーン リーダーがテキスト ブロックにアクセスできるようにします。

````xaml
<Flyout>
  <Flyout.FlyoutPresenterStyle>
    <Style TargetType="FlyoutPresenter">
      <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Disabled"/>
      <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
      <Setter Property="IsTabStop" Value="True"/>
      <Setter Property="TabNavigation" Value="Cycle"/>
    </Style>
  </Flyout.FlyoutPresenterStyle>
  <TextBlock Style="{StaticResource BodyTextBlockStyle}" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."/>
</Flyout>
````

### 呼び出しと配置

ポップアップとコンテキスト メニューは、特定のコントロールにアタッチされます。 表示するときに、呼び出し元のオブジェクトに固定する必要があり、そのオブジェクトに対して優先する相対位置 (上、下、左、または右) を指定します。 ポップアップには完全配置モードもあります。完全配置モードでは、ポップアップを拡大して、アプリ ウィンドウの中央に配置しようとします。

[Button クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx) には `Flyout` プロパティがあり、これを使うと、ユーザーがボタンをクリックするかタップしたときに表示する一時的な UI を指定できます。

````xaml
<Button Content="Click me">
  <Button.Flyout>
     <Flyout>
        <TextBlock Text="Yay!"/>
     </Flyout>
  </Button.Flyout>
</Button>
````

コンテキスト メニューを開くために、ユーザーは次の操作のいずれかを実行できます。
- マウスで右クリックする
- 指で押してホールドする
- Shift キーを押しながら F10 キーを押す
- キーボードのメニュー キーを押す
- ゲームパッドのメニュー ボタンを押す

上記のいずれかの操作に対する応答として、コンテキスト メニューやポップアップを簡単に開くために、アプリは [UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx) の新しい [`ContextFlyout`](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使うことができます。これは、ほとんどのコントロールの基底クラスです。

````xaml
<Rectangle Height="100" Width="100" Fill="Red">
  <Rectangle.ContextFlyout>
     <MenuFlyout>
        <MenuFlyoutItem Text="Close"/>
     </MenuFlyout>
  </Rectangle.Flyout>
</Rectangle>
````

## 関連記事

**開発者向け**
- [**MenuFlyout クラス**](https://msdn.microsoft.com/library/windows/apps/dn299030)
- [**Flyout クラス**](https://msdn.microsoft.com/library/windows/apps/dn279496)
- [**ContentDialog クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)



<!--HONumber=Jun16_HO4-->


