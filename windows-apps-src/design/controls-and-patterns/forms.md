---
Description: UWP アプリでのフォームのレイアウト ガイドラインです。
title: フォーム
template: detail.hbs
ms.date: 11/07/2017
ms.topic: article
keywords: Windows 10, UWP, Fluent
ms.openlocfilehash: 8a57f13e168a248569bca1beeceed7b4f6c89f69
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658157"
---
# <a name="forms"></a>フォーム
フォームは、収集し、ユーザーからのデータを送信するコントロールのグループです。 フォームは、通常、設定ページの使用調査、アカウント、およびその他を作成します。 

この記事では、フォームのレイアウトを XAML を作成するためのデザイン ガイドラインについて説明します。

![フォームの例](images/PivotHeader.png)

## <a name="when-should-you-use-a-form"></a>フォームを使用する場合
フォームは、明確に関連する他のデータ入力を収集するための専用ページです。 ユーザーから明示的にデータを収集する必要がある場合は、フォームを使用する必要があります。 ユーザーがフォームを作成する場合があります。
- アカウントにログインします。
- アカウントをサインアップします。
- プライバシーなどのアプリ設定を変更またはオプションが表示されます。
- 調査を実施します。
- アイテムを購入します。
- フィードバックの送信

## <a name="types-of-forms"></a>フォームの種類

ユーザー入力が送信され、表示方法を検討する場合は、フォームの 2 つの種類があります。

### <a name="1-instantly-updating"></a>1. すぐに更新しています。
![設定 ページ](images/control-examples/toggle-switch-news.png)

ユーザーがフォーム内の値の変更の結果をすぐに確認する場合は、すぐに更新の形式を使用します。 たとえばの設定 ページで、現在の選択が表示され、選択内容に加えられた変更はすぐに適用されます。 アプリでの変更を確認する必要があります[イベント ハンドラーを追加](controls-and-events-intro.md)を各入力コントロール。 ユーザーは、入力コントロールを変更すると、アプリが適宜ことができます。

### <a name="2-submitting-with-button"></a>2. ボタンを送信します。
フォームの他の種類は、ボタンのクリックでデータを送信するタイミングを選択できます。

![予定表は、新しいイベント ページを追加します。](images/calendar-form.png)

この種類のフォームでは、応答でのユーザーを柔軟です。 通常、この種類のフォームは、自由形式の複数の入力フィールドが含まれていて、したがってより多様な応答を受信します。 確実に有効なユーザー入力と正しく書式設定されたデータを送信すると、次の推奨事項を考慮してください。

- 適切なコントロールを使用して無効な情報を送信することが不可能になります (つまりを使用して、テキスト ボックスではなく、CalendarDatePicker カレンダーの日付)。 後で、入力コントロールのセクションで、フォームに適切な入力コントロールを選択する方法の詳細を参照してください。
- テキスト ボックス コントロールを使用する場合により、ユーザーが必要な入力形式のヒントを提供、 [PlaceholderText](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBox.PlaceholderText)プロパティ。
- 適切なユーザーがスクリーン キーボードを使用して、コントロールの想定される入力の記述を提供する、 [InputScope](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.inputscope)プロパティ。
- マークにアスタリスクを使用して入力が必要な * ラベル。
- すべての必要な情報が入力されるまでは、[送信] ボタンを無効にします。
- 送信時に無効なデータがある場合は、強調表示されたフィールドまたは [境界線] で無効な入力コントロールをマークして、ユーザー フォームを再送信するように要求します。
- 障害が発生したネットワーク接続などの他のエラーの確認をユーザーに適切なエラー メッセージを表示します。 


## <a name="layout"></a>レイアウト

ユーザー エクスペリエンスを容易にし、ユーザーが入力した正しいにできることには、フォームのレイアウトをデザインするための次の推奨事項を検討してください。 

### <a name="labels"></a>ラベル
[ラベル](labels.md)左揃え、入力コントロールの上に配置する必要があります。 多くのコントロールでは、ラベルを表示する組み込みヘッダー プロパティがあります。 Header プロパティがないコントロールの場合、またはコントロールのグループにラベルを付ける場合は、代わりに [TextBlock](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.TextBlock) を使います。

[ユーザー補助のための設計](../accessibility/accessibility.md)、すべての個人とグループの両方の人間にわかりやすくするため、スクリーン リーダーのコントロールのラベルを付けます。 

フォント スタイルの既定値を使用して、 [UWP の種類ごとの傾斜増加](../style/typography.md)します。 使用`TitleTextBlockStyle`ページのタイトルの`SubtitleTextBlockStyle`グループの見出しと`BodyTextBlockStyle`のコントロールのラベル。

<div class="mx-responsive-img">
<table>
<tr><th>推奨される事項</th><th>非推奨</th></tr>
<tr>
<td><img src="../controls-and-patterns/images/forms-shortform1col.png" alt="form with top labels"></td>
<td><img src="../controls-and-patterns/images/forms-leftlabel-donot1.png" alt="form with left labels don't"></td>
</tr>
</table>
</div>

### <a name="spacing"></a>間隔
使用を互いからコントロールのグループを視覚的に分離、[配置、余白、および埋め込み](../layout/alignment-margin-padding.md)。 個々 の入力コントロールの高さ 80px は、スペース区切り 24px 離れている必要があります。 入力コントロールのグループには、スペース区切り 48px 離れている必要があります。

![フォームのグループ](images/forms-groups.png)

### <a name="columns"></a>列
列を作成すると、特に大きい画面サイズでのフォームで不要な空白を削減できます。 ただし、複数列のフォームを作成する場合は、列の数は、ページの入力コントロールの数と、アプリ ウィンドウの画面サイズに依存する必要があります。 多数の入力コントロールを含む画面を過負荷ではなく、フォームの複数のページの作成を検討してください。  

<div class="mx-responsive-img">
<table>
<tr><th>推奨される事項</th><th>非推奨</th></tr>
<tr>
<td><img src="../controls-and-patterns/images/forms-2cols.png" alt="form with 2 columns"></td>
<td><img src="../controls-and-patterns/images/forms-2cols-bad.png" alt="form with 2 bad columns"></td>
</tr>
<tr><td><img src="../controls-and-patterns/images/forms-3cols.png" alt="form with 3 columns"></td></tr>
</table>

</div>

### <a name="responsive-layout"></a>レスポンシブ レイアウト
ユーザーが任意の入力フィールドを見落とさないように画面やウィンドウ サイズの変更としてフォーム サイズを変更する必要があります。 詳細については、次を参照してください。[レスポンシブ デザイン手法](../layout/responsive-design.md)します。 たとえば、画面サイズに関係なく、ビューで、フォームの特定のリージョンを常に保持する可能性があります。

![フォームのフォーカス](images/forms-focus2.png)

### <a name="tab-stops"></a>タブ位置
ユーザーがキーボードを使用してコントロールを移動する[タブ ストップ](../input/keyboard-interactions.md#tab-stops)します。 既定では、コントロールのタブ オーダーは、XAML で作成された順序を反映します。 既定の動作を上書きするには、変更、 **IsTabStop**または**TabIndex**コントロールのプロパティ。 

![フォーム内のコントロールにフォーカスをタブ](images/forms-focus1.png)

## <a name="input-controls"></a>入力コントロール
入力コントロールは、ユーザーがフォームに情報を入力できる UI 要素です。 フォームに追加できるいくつかの一般的なコントロールは、使用する状況に関する情報と、以下に示します。

### <a name="text-input"></a>テキスト入力
コントロール | 使用 | 例
 - | - | -
[TextBox](text-box.md) | 1 つまたは複数の行のテキストをキャプチャします。 | 名前や自由形式の応答、フィードバック
[PasswordBox](password-box.md) | 文字を表示してプライベート データを収集します。 | パスワード、社会保障番号 (SSN)、Pin、クレジット カード情報 
[AutoSuggestBox](auto-suggest-box.md) | 入力するときに、対応する一連のデータの修正候補の一覧をユーザーに表示します。 | データベースの検索、メールを: 行を前のクエリ
[RichEditBox](rich-edit-box.md) | 書式設定されたテキスト、ハイパーリンク、およびイメージを持つテキスト ファイルを編集します。 | ファイルのアップロード、preview、およびアプリでの編集

### <a name="selection"></a>選択
コントロール | 使用 | 例
- | - | - 
| [チェック ボックス](checkbox.md) | 選択するか、1 つまたは複数のアクション アイテムの選択を解除 | 使用条件に同意する、省略可能な項目の追加、該当するものすべてを選択します
[オプション ボタン](radio-button.md) | 2 つまたは複数の選択肢から 1 つのオプションを選択します。 | メソッドなどの配布の種類を選択します。
[ToggleSwitch](toggles.md) | 2 つの相互に排他的なオプションのいずれかを選択します。 | オン/オフ

> **注意**:5 つ以上の選択項目がある場合は、リスト コントロールを使用します。

### <a name="lists"></a>リスト
コントロール | 使用 | 例
- | - | -
[ComboBox](https://docs.microsoft.com/windows/uwp/controls-and-patterns/lists.md#drop-down-lists) | コンパクトな状態で起動して、選択可能な項目の一覧を表示する展開 | 州または国などの項目の長い一覧から選択します
[ListView](https://docs.microsoft.com/windows/uwp/controls-and-patterns/lists#list-views) | 項目を分類し、グループ ヘッダーを割り当て、ドラッグし項目を削除、キュレーション コンテンツ、および項目の順序を変更 | 順位付けのオプション
[GridView](https://docs.microsoft.com/windows/uwp/controls-and-patterns/lists#grid-views) | 配置し、イメージ ベースのコレクションの参照 | 画像、色の選択、テーマの表示

### <a name="numeric-input"></a>数値入力
コントロール | 使用 | 例
- | - | -
[スライダー](slider.md) | 連続する数値の範囲から数値を選択します。 | パーセンテージ、ボリューム、再生速度
[評価](rating.md) | 星を評価します。 | カスタマー フィードバック

### <a name="date-and-time"></a>日時

コントロール | 使用 
- | - 
[予定表ビュー](calendar-view.md) | 1 つの日付または、常に表示されるカレンダーから日付の範囲を選択します。 
[CalendarDatePicker](calendar-date-picker.md) | コンテキストの予定表から 1 つの日付を選択します。 
[DatePicker](date-picker.md) | コンテキスト情報が重要でない 1 つのローカライズされた日付を選択します。
[TimePicker](time-picker.md) | 1 つの時間の値を選択します。

### <a name="additional-controls"></a>その他のコントロール 
UWP コントロールの完全な一覧を参照してください。[関数によってコントロールのインデックス](controls-by-function.md)します。

複雑で、カスタムの UI コントロールを参照してください企業から使用可能な UWP リソースなど[Telerik](https://www.telerik.com/)、 [SyncFusion](https://www.syncfusion.com/products/uwp)、 [DevExpress](https://www.devexpress.com/Products/NET/Controls/Win10Apps/)、 [Infragistics](https://www.infragistics.com/products/universal-windows-platform)、 [ComponentOne](https://www.componentone.com/Studio/Platform/UWP)、および[ActiPro](https://www.actiprosoftware.com/products/controls/universal)します。

## <a name="one-column-form-example"></a>フォームの例を 1 つの列
この例で使用するアクリル[マスター/詳細](master-details.md)[リスト ビュー](lists.md)と[NavigationView](navigationview.md)コントロール。
![別の形式の例のスクリーン ショット](images/FormExample2.png)
```xaml
<StackPanel>
    <TextBlock Text="New Customer" Style="{StaticResource TitleTextBlockStyle}"/>
    <Button Height="100" Width="100" Background="LightGray" Content="Add photo" Margin="0,24" Click="AddPhotoButton_Click"/>
    <TextBox x:Name="Name" Header= "Name" Margin="0,24,0,0" MaxLength="32" Width="400" HorizontalAlignment="Left" InputScope="PersonalFullName"/>
    <TextBox x:Name="PhoneNumber" Header="Phone Number" Margin="0,24,0,0" MaxLength="15" Width="400" HorizontalAlignment="Left" InputScope="TelephoneNumber" />
    <TextBox x:Name="Email" Header="Email" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
    <TextBox x:Name="Address" Header="Address" PlaceholderText="Address" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
    <TextBox x:Name="Address2" Margin="0,24,0,0" PlaceholderText="Address 2" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
    <RelativePanel>
        <TextBox x:Name="City" PlaceholderText="City" Margin="0,24,0,0" MaxLength="50" Width="200" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
        <ComboBox x:Name="State" PlaceholderText="State" Margin="24,24,0,0"  Width="100" RelativePanel.RightOf="City">
             <x:String>WA</x:String>
        </ComboBox>
    </RelativePanel>
    <TextBox x:Name="ZipCode" PlaceholderText="Zip Code" Margin="0,24,0,0" MaxLength="6" Width="100" HorizontalAlignment="Left" InputScope="Number" />
    <StackPanel Orientation="Horizontal">
        <Button Content="Save" Margin="0,24" Click="SaveButton_Click"/>
        <Button Content="Cancel" Margin="24" Click="CancelButton_Click"/>
    </StackPanel>  
</StackPanel>
```

## <a name="two-column-form-example"></a>フォームの例を 2 つの列
この例では、[ピボット](pivot.md)コントロール、[アクリル](../style/acrylic.md)の背景と[CommandBar](app-bars.md)入力コントロールだけでなく。
![フォームの例のスクリーン ショット](images/FormExample.png)
```xaml
<Grid>
    <Pivot Background="{ThemeResource SystemControlAccentAcrylicWindowAccentMediumHighBrush}" >
        <Pivot.TitleTemplate>
            <DataTemplate>
                <Grid>
                    <TextBlock Text="Company Name" Style="{ThemeResource HeaderTextBlockStyle}"/>
                </Grid>
            </DataTemplate>
        </Pivot.TitleTemplate>
        <PivotItem Header="Orders" Margin="0"/>    
        <PivotItem Header="Customers" Margin="0">
            <!--Form Example-->
            <Grid Background="White">
                <RelativePanel>
                    <StackPanel x:Name="Customer" Margin="20">
                        <TextBox x:Name="CustomerName" Header= "Customer Name" Margin="0,24,0,0" MaxLength="320" Width="400" HorizontalAlignment="Left" InputScope="PersonalFullName"/>
                        <TextBox x:Name="CustomerPhoneNumber" Header="Phone Number" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="TelephoneNumber" />
                        <TextBox x:Name="Address" Header="Address" PlaceholderText="Address" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="AlphanumericFullWidth" />
                        <TextBox x:Name="Address2" Margin="0,24,0,0" PlaceholderText="Address 2" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="AlphanumericFullWidth" />
                        <RelativePanel>
                            <TextBox x:Name="City" PlaceholderText="City" Margin="0,24,0,0" MaxLength="50" Width="200" HorizontalAlignment="Left" InputScope="Text" />
                            <ComboBox x:Name="State" PlaceholderText="State" Margin="24,24,0,0"  Width="100" RelativePanel.RightOf="City">
                                <x:String>WA</x:String>
                            </ComboBox>
                        </RelativePanel>
                        <TextBox x:Name="ZipCode" PlaceholderText="Zip Code" Margin="0,24,0,0" MaxLength="6" Width="100" HorizontalAlignment="Left" InputScope="Number" />
                    </StackPanel>
                    <StackPanel x:Name="Associate" Margin="20" RelativePanel.RightOf="Customer">
                        <TextBox x:Name="AssociateName" Header= "Associate" Margin="0,24,0,0" MaxLength="320" Width="400" HorizontalAlignment="Left" InputScope="PersonalFullName"/>
                        <TextBox x:Name="AssociatePhoneNumber" Header="Phone Number" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="TelephoneNumber" />
                        <DatePicker x:Name="TargetInstallDate" Header="Target install Date" HorizontalAlignment="Left" Margin="0,24,0,0"></DatePicker>
                        <TimePicker x:Name="InstallTime" Header="Install Time" HorizontalAlignment="Left" Margin="0,24,0,0"></TimePicker>
                    </StackPanel>
                </RelativePanel>
            </Grid>
        </PivotItem>
        <PivotItem Header="Invoices"/>
        <PivotItem Header="Stock"/>
        <Pivot.RightHeader>
            <CommandBar OverflowButtonVisibility="Collapsed" Background="Transparent">
                <AppBarButton Icon="Add"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Edit" />
                <AppBarButton Icon="Delete"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Save"/>
            </CommandBar>
        </Pivot.RightHeader>
    </Pivot>
</Grid>
```

## <a name="customer-orders-database-sample"></a>顧客注文データベース サンプル
![顧客注文データベースのスクリーン ショット](images/customerorderform.png)フォームの入力に接続する方法について、 **Azure**を参照してください、完全に実装されたフォームを参照してください。 データベースにあり、[顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database)アプリのサンプル。

## <a name="related-topics"></a>関連トピック
- [入力コントロール](controls-and-events-intro.md)
- [文字体裁](../style/typography.md)
