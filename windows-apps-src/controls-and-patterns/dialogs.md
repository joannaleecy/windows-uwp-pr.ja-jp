---
author: mijacobs
Description: "ダイアログとポップアップは、ユーザーが要求したとき、または通知や許可を必要とする状況が発生したときに表示される一時的な UI 要素です。"
title: "ダイアログとポップアップ"
label: Dialogs
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: bc428b42324cd584dfaee1db3c9eb834d30cd69d

---
# <a name="dialogs-and-flyouts"></a>ダイアログとポップアップ

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

ダイアログ ボックスとポップアップは、通知、許可、またはユーザーからの追加の情報を必要とする状況が発生したときに表示される一時的な UI 要素です。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[ContentDialog クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)</li>
<li>[Flyout クラス](https://msdn.microsoft.com/library/windows/apps/dn279496)</li>
</ul>
</div>


<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>ダイアログ</b> <br/><br/>
    ![ダイアログの例](images/dialogs/dialog-delete-file-example.png)</p>
<p>ダイアログは、状況依存のアプリ情報を表示するモーダル UI オーバーレイです。 ダイアログは、明示的に閉じられるまでアプリ ウィンドウの対話式操作をブロックします。 多くの場合、ユーザーに何らかの操作を要求します。   
</p><br/>

  </div>
  <div class="side-by-side-content-right">
   <p><b>ポップアップ</b> <br/><br/>
   ![ポップアップの例](images/flyout-example.png)</p>
<p>ポップアップ (flyout) は、ユーザーが現在操作している内容に関係する UI を表示する軽量な状況依存のポップアップです。 このポップアップは、配置ロジックとサイズ設定ロジックを備えており、非表示コントロールを再表示する場合、項目の詳細を表示する場合、またはユーザーに操作の確認を求める場合に使うことができます。 
</p><p>ダイアログとは異なり、ポップアップは、それ以外の場所をタップまたはクリックするか、Esc キーまたは戻るボタンを押すか、アプリ ウィンドウのサイズを変更するか、デバイスの向きを変更することで、すばやく閉じることができます。
</p><br/>

  </div>
</div>
</div>

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

* 重要な情報をユーザーに通知したり、アクションが完了する前に確認や追加情報を要求するために、ダイアログやポップアップを使用します。 
* [ヒント](tooltips.md)や[コンテキスト メニュー](menus.md)の変わりにポップアップを使用しないようにします。 指定した時間が経過すると非表示になる短い説明を表示するには、ヒントを使います。 UI 要素に関連した状況依存の操作 (コピーや貼り付けなど) には、コンテキスト メニューを使います。  


ダイアログとポップアップにより、ユーザーが重要な情報を認識していることを確認できますが、ユーザー エクスペリエンスは中断されます。 ダイアログはモーダル (ブロック) であるため、ユーザーは中断され、ダイアログの操作を行うまで他の操作を行うことはできません。 ポップアップの煩わしさはダイアログより低くなりますが、多用すると、煩わしくなります。 

伝える情報の重要度が、ユーザーを中断させる必要があるものかどうかを、よく検討する必要があります。 また、情報の表示頻度を検討し、数分ごとにダイアログや通知を表示している場合には、代わりにプライマリ UI でこの情報用の領域を割り当てることを検討します。 たとえばチャット クライアントで、友人がログインするたびにポップアップを表示させるよりも、その時点でオンラインである友人の一覧を表示し、ログインが行われたときには強調表示させるなどの方法を検討します。 

ポップアップとダイアログは、アクション (ファイルの削除など) を実行する前に確認するために、よく使用されます。 ユーザーが特定の操作を頻繁に実行することが想定される場合には、ユーザーがアクションを毎回確認する必要があるようにするよりも、誤って操作した場合に、ユーザーが元に戻せる方法を提供することを検討します。 



## <a name="dialogs-vs-flyouts"></a>ダイアログとポップアップの比較

ダイアログかポップアップを使用すると決めた場合には、どちらを選択する必要があります。 

ダイアログは操作をブロックし、ポップアップはブロックしないため、ダイアログの使用は、ユーザーが他のすべてを中断して情報や回答の提供に集中する必要がある状況に限定する必要があります。 一方ポップアップは、ユーザーに情報を知らせるが、ユーザーがそれを無視してもよい場合に使用します。 

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>ダイアログの用途:</b> <br/>
<ul>
<li>続行前にユーザーが読んだり確認したりする**必要のある重要な**情報を表示する場合。 次のようなシナリオが考えられます。
<ul>
  <li>ユーザーのセキュリティが侵害される可能性がある場合</li>
  <li>ユーザーが重要な資産に永続的な変更を加えようとしている場合</li>
  <li>ユーザーが重要な資産を削除しようとしている場合</li>
  <li>アプリ内購入を確認する場合</li>
</ul>

</li>
<li>接続エラーなど、アプリ全体の状況に適用されるエラー メッセージ</li>
<li>アプリからユーザーにブロック質問を表示する必要がある場合 (アプリで自動的に選ぶことができない場合など) ブロック質問とは、無視したり先送りにしたりできない質問です。この質問では、ユーザーに明確な選択肢を提示する必要があります。</li>
</ul> 
</p>
  </div>
  <div class="side-by-side-content-right">
   <p><b>ポップアップの用途:</b> <br/>
<ul>
<li>操作を完了する前に、必要な追加情報を収集する場合。</li>
<li>一部の場合のみに意味がある情報を表示する場合。 たとえばフォト ギャラリー アプリで、ユーザーが画像のサムネイルをクリックした場合に、大きな画像を表示するためにポップアップを使用できます。</li>
<li>警告と確認 (被害が発生する可能性のある操作に関するものなど)。</li>
<li>詳細やページ上の項目の長い説明などの詳しい情報の表示。</li>
</ul></p>
  </div>
</div>
</div>

<div class="microsoft-internal-note">
簡易非表示コントロールは、閉じられるまで一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。 この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。 この動作は、新しい `LightDismissOverlayMode` プロパティを使用して変更できます。 既定では、一時的な UI は Xbox で簡易非表示オーバーレイを描画し、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常に**オン**にするか、常に**オフ**にするかを選択できます。

```xaml
<MenuFlyout LightDismissOverlayMode=\"Off\">
```
</div>

## <a name="dialogs"></a>ダイアログ
### <a name="general-guidelines"></a>一般的なガイドライン

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
    - 次の順番でコミット ボタンを提示します。 
        -   [OK]/[実行する]/[はい]
        -   [実行しない]/[いいえ]
        -   [キャンセル]
        
        (この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。)
   
-   エラー ダイアログでは、ダイアログ ボックスにエラー メッセージと関連情報 (ある場合) を表示します。 エラー ダイアログで使う唯一のボタンは "閉じる" かこれに似た操作である必要があります。
-   パスワード フィールドの検証エラーなど、ページの特定の場所に関連するエラーでは、ダイアログを使わずに、アプリのキャンバス自体を使ってインライン エラーを表示します。

### <a name="confirmation-dialogs-okcancel"></a>確認ダイアログ ([OK]/[キャンセル])
確認ダイアログ ボックスにより、ユーザーはアクションを実行するかどうかを確認できます。 アクションを確認するか、キャンセルを選択することができます。  
一般的な確認ダイアログ ボックスには、確認 ([OK]) ボタンと [キャンセル] ボタンの 2 つのボタンがあります。  

<ul>
    <li>
        <p>一般的に、確認ボタンは左側 (プライマリ ボタン) にあり、[キャンセル] ボタン (セカンダリ ボタン) は右側にあります。</p>
         ![[OK]/[キャンセル] ダイアログ ボックス](images/dialogs/dialog-delete-file-example.png)
        
    </li>
    <li>一般的な推奨事項のセクションで説明したように、テキストを指定したボタンを使って、主な説明またはコンテンツに対する具体的な応答を示します。
    </li>
</ul>

> 一部のプラットフォームでは、左側ではなく、右側に確認ボタンが配置されます。 それでは、左側に確認ボタンを配置するのはなぜでしょうか。  ユーザーの大部分が右利きであり、右手でスマートフォンを保持すると想定した場合、実際に確認ボタンが左側にある方がボタンを押しやすくなります。これは、ボタンがユーザーの親指が描く円弧上にある可能性が高くなるためです。 画面の右側にボタンがある場合、ユーザーは親指を内側に引いて操作しにくい位置に移動する必要があります。

### <a name="create-a-dialog"></a>ダイアログの作成
ダイアログ ボックスを作成するには、[ContentDialog クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)を使用します。 ダイアログはコードまたはマークアップで作成できます。 通常は UI 要素を XAML で定義する方が容易ですが、単純なダイアログの場合には、コードを記述する方が実際には容易です。 この例では、ダイアログを作成して、ユーザーに WiFi 接続がないことの通知を行い、[ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx)メソッドを使ってそれを表示しています。

```csharp
private async void displayNoWifiDialog()
{
    ContentDialog noWifiDialog = new ContentDialog()
    {
        Title = "No wifi connection",
        Content = "Check connection and try again",
        PrimaryButtonText = "Ok"
    };

    ContentDialogResult result = await noWifiDialog.ShowAsync();
}
```

ユーザーがダイアログのボタンをクリックすると、[ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx)メソッドは [ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) を返して、ユーザーがクリックしたボタンを伝えます。 

この例でのダイアログは、質問を行い、[ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) の戻り値を使用してユーザーの応答を確認します。 

```csharp
private async void displayDeleteFileDialog()
{
    ContentDialog deleteFileDialog = new ContentDialog()
    {
        Title = "Delete file permanently?",
        Content = "If you delete this file, you won't be able to recover it. Do you want to delete it?",
        PrimaryButtonText = "Delete",
        SecondaryButtonText = "Cancel"
    };

    ContentDialogResult result = await deleteFileDialog.ShowAsync();
    
    // Delete the file if the user clicked the primary button. 
    /// Otherwise, do nothing. 
    if (result == ContentDialogResult.Primary)
    {
        // Delete the file. 
    }
}
```

## <a name="flyouts"></a>ポップアップ
###  <a name="create-a-flyout"></a>ポップアップの作成

ポップアップは、オープンエンドなコンテナーで、そのコンテンツとして任意の UI を表示することができます。 

<div class="microsoft-internal-note">
これにはポップアップやコンテキスト メニューが含まれ、それらをさらに他のポップアップ内で入れ子にすることができます。
</div>

ポップアップは、特定のコントロールにアタッチされます。 [Placement ](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.placement.aspx) プロパティを使って、ポップアップが表示される場所 (上、左、下、右、またはフル) を指定します。 [完全配置モード](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutplacementmode.aspx)を選択した場合、アプリはポップアップを拡大し、アプリ ウィンドウ内の中央に配置します。 表示するときに、呼び出し元のオブジェクトに固定する必要があり、そのオブジェクトに対して優先する相対位置 (上、下、左、または右) を指定します。 ポップアップには完全配置モードもあります。完全配置モードでは、ポップアップを拡大して、アプリ ウィンドウの中央に配置しようとします。 [Button](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx) などの一部のコントロールは、ポップアップを関連付けるために使用できる [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx) プロパティを提供します。 

この例では、ボタンが押されたときに、いくつかのテキストを表示するシンプルなポップアップを作成します。 
````xaml
<Button Content="Click me">
  <Button.Flyout>
     <Flyout>
        <TextBlock Text="This is a flyout!"/>
     </Flyout>
  </Button.Flyout>
</Button>
````

コントロールに Flyout プロパティがない場合には、代わりに [FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx) 添付プロパティを使用できます。 これを行う場合には、さらに [FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout)メソッドを呼び出して、ポップアップを表示する必要があります。 

この例では、画像に簡単なポップアップを追加します。 ユーザーが画像をタップしたときに、アプリはポップアップを表示します。 

````xaml
<Image Source="Assets/cliff.jpg" Width="50" Height="50" 
  Margin="10" Tapped="Image_Tapped">
  <FlyoutBase.AttachedFlyout>
    <Flyout>
      <TextBlock TextWrapping="Wrap" Text="This is some text in a flyout."  />
    </Flyout>        
  </FlyoutBase.AttachedFlyout>
</Image>
````

````csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
}
````

前に示した例では、ポップアップはインラインで定義されています。 ポップアップを静的なリソースとして定義して、複数の要素で使用することもできます。 この例では、サムネイルがタップされたときに大きな画像を表示する、より複雑なポップアップを作成します。 

````xaml
<!-- Declare the shared flyout as a resource. -->
<Page.Resources>
    <Flyout x:Key="ImagePreviewFlyout" Placement="Right">
        <!-- The flyout's DataContext must be the Image Source 
             of the image the flyout is attached to. -->
        <Image Source="{Binding Path=Source}" 
            MaxHeight="400" MaxWidth="400" Stretch="Uniform"/>
        <Flyout.FlyoutPresenterStyle>
            <Style TargetType="FlyoutPresenter">
                <Setter Property="ScrollViewer.ZoomMode" Value="Enabled"/>
                <Setter Property="Background" Value="Black"/>
                <Setter Property="BorderBrush" Value="Gray"/>
                <Setter Property="BorderThickness" Value="5"/>
                <Setter Property="MinHeight" Value="300"/>
                <Setter Property="MinWidth" Value="300"/>
            </Style>
        </Flyout.FlyoutPresenterStyle>
    </Flyout>
</Page.Resources>
````

````xaml
<!-- Assign the flyout to each element that shares it. -->
<StackPanel>
    <Image Source="Assets/cliff.jpg" Width="50" Height="50" 
           Margin="10" Tapped="Image_Tapped" 
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
    <Image Source="Assets/grapes.jpg" Width="50" Height="50" 
           Margin="10" Tapped="Image_Tapped" 
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
    <Image Source="Assets/rainier.jpg" Width="50" Height="50" 
           Margin="10" Tapped="Image_Tapped" 
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
</StackPanel>
````

````csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);  
}
````

### <a name="style-a-flyout"></a>ポップアップのスタイルを設定する
ポップアップのスタイルを設定するには、[FlyoutPresenterStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.flyoutpresenterstyle.aspx) を変更します。 次の例では、テキストの折り返しの段落を示し、スクリーン リーダーがテキスト ブロックにアクセスできるようにします。

````xaml
<Flyout>
  <Flyout.FlyoutPresenterStyle>
    <Style TargetType="FlyoutPresenter">
      <Setter Property="ScrollViewer.HorizontalScrollMode" 
          Value="Disabled"/>
      <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
      <Setter Property="IsTabStop" Value="True"/>
      <Setter Property="TabNavigation" Value="Cycle"/>
    </Style>
  </Flyout.FlyoutPresenterStyle>
  <TextBlock Style="{StaticResource BodyTextBlockStyle}" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."/>
</Flyout>
````

## <a name="get-the-samples"></a>サンプルの入手
*   [XAML UI の基本](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)<br/>
    インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事
- [ヒント](tooltips.md)
- [メニューとコンテキスト メニュー](menus.md)
- [**Flyout クラス**](https://msdn.microsoft.com/library/windows/apps/dn279496)
- [**ContentDialog クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)



<!--HONumber=Dec16_HO2-->


