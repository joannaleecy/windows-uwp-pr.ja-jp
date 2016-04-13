---
Description: Windows 10 と新しい開発者ツールを使うと、新しいユニバーサル Windows プラットフォーム (UWP) によって強化されたツール、機能、そしてエクスペリエンスが利用できます。
title: Windows 10 の開発者向け新着情報 (RTM - 2015 年 7 月)
---

# Windows 10 の開発者向け新着情報 (RTM: 2015 年 7 月)


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

Windows 10 と新しい開発者ツールを使うと、新しいユニバーサル Windows プラットフォーム (UWP) によって強化されたツール、機能、そしてエクスペリエンスが利用できます。 Windows 10 への[ツールと SDK のインストール](https://dev.windows.com/downloads)が完了したら、[新しいユニバーサル Windows アプリを作成](https://msdn.microsoft.com/library/windows/apps/bg124288)したり、[Windows の既存のアプリ コード](https://msdn.microsoft.com/library/windows/apps/mt238321)を試したりすることができます。

以下では、Windows 10 RTM 版の新機能をそれぞれ見ていきます。

## アダプティブ レイアウト


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">複数のビューによるコンテンツのカスタマイズ</td>
<td align="left">XAML で、同じコード ファイルを共有する複数のカスタム ビュー (.xaml ファイル) を定義できるようになりました。 特定のデバイス ファミリや特定のシナリオ向けにカスタマイズしたさまざまなビューを従来よりも簡単に作成、管理することができます。 状況によってまったく異なる UI コンテンツやレイアウト、ナビゲーション モデルをアプリで使い分ける場合は、複数のビューを作成しましょう。 たとえば、モバイル アプリには片手での操作に最適なナビゲーションと[<strong>ピボット</strong>](https://msdn.microsoft.com/library/windows/apps/dn608241)を、デスクトップ アプリにはマウスでの操作に最適なナビゲーション メニューと [<strong>SplitView</strong>](https://msdn.microsoft.com/library/windows/apps/dn864360) を組み合わせることができます。</td>
</tr>
<tr class="even">
<td align="left">StateTriggers</td>
<td align="left">新しい [<strong>VisualState.StateTriggers</strong>](https://msdn.microsoft.com/library/windows/apps/dn890396) 機能を使うと、ウィンドウの高さや幅、カスタム トリガーを基準とし、条件に従ってプロパティを設定することができます。 従来は、ウィンドウの [<strong>SizeChanged</strong>](https://msdn.microsoft.com/library/windows/apps/br209055) イベントをコード内で処理し、[<strong>VisualStateManager.GoToState</strong>](https://msdn.microsoft.com/library/windows/apps/br209025) を呼び出す必要がありました。</td>
</tr>
<tr class="odd">
<td align="left">Setter</td>
<td align="left"><p>[<strong>VisualStateManager</strong>](https://msdn.microsoft.com/library/windows/apps/br209021) でプロパティの変更を定義する際に使うマークアップが、新しい [<strong>VisualState.Setters</strong>](https://msdn.microsoft.com/library/windows/apps/dn890395) 構文によって簡素化されています。 以前は、[<strong>StackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/br209635)の向きを横から縦にするなど、プロパティの変更を適用するときは、ストーリーボードを使ってアニメーションを作成する必要がありました。 ユニバーサル Windows アプリでは、次のように単純化された Setter 構文を使うことができます。</p>
<p><code>&lt;setter target=&quot;stackPanel1.Orientation&quot; value=&quot;Vertical&quot; /&gt;</code></p></td>
</tr>
</tbody>
</table>

 

## XAML の機能


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">データ バインディングのコンパイル (x:Bind)</td>
<td align="left"><p>ユニバーサル Windows アプリで、コンパイラ ベースのバインディングを行うことができるようになりました。この機構を有効にするには、x:Bind プロパティを使います。 コンパイルの時点で厳密に型指定されたうえで処理されることから、コンパイラ ベースのバインディングには、高速化できることに加え、バインディングの型が一致しないときにはコンパイル時にエラーを検出できるという 2 つの利点があります。 また、バインディングはコンパイル済みのアプリ コードに変換されるため、Visual Studio からコードをステップ実行してデバッグすることにより、バインディングの問題を詳しく診断することができます。 また、次のように、x:Bind を使ってメソッドにバインドすることもできます。</p>
<p><code>&lt;textblock text=&quot;{x:Bind Customer.Address.ToString()}&quot; /&gt;</code></p>
<p>一般的なバインディングのシナリオでは、Binding の代わりに x:Bind を使うことができます。x:Bind に置き換えることでパフォーマンスが向上し、メンテナンスもしやすくなります。</p></td>
</tr>
<tr class="even">
<td align="left">宣言型の段階的レンダリングによるリストの表示 (x:Phase)</td>
<td align="left"><p>ユニバーサル Windows アプリで新しい x:Phase 属性を使うと、コードからではなく XAML を使ってリストを段階的にレンダリングすることができます。 複雑な項目がいくつも連なったようなリストをパンすると、項目のレンダリングがパンの速度に追い付かず、アプリのユーザーにネガティブな印象を与える可能性があります。 高速にパン操作を実行しなければならない状況では、リストの要素ごとにレンダリングの優先順位を指定して、特に重要な部分だけをレンダリングすることができます。 よりスムーズなパンが可能となり、アプリの操作感が向上します。</p>
<p>Windows 8.1 でも、必要なコードを [<strong>ContainerContentChanging</strong>](https://msdn.microsoft.com/library/windows/apps/dn298914) イベント処理に記述すれば、リスト項目を段階的にレンダリングすることはできます。 UWP アプリでは、x:Phase 属性で宣言して段階的なレンダリングを行うことが可能です。 バインディングのコンパイルを行う x:Bind と組み合わせれば、バインド対象の要素ごとにレンダリングの優先順位をデータ テンプレートで簡単に指定することができます。 リスト項目をレンダリングする処理には、パン操作の実行中、段階に応じてタイム スライスが割り当てられ、それによって項目を少しずつ描画することが可能となります。</p></td>
</tr>
<tr class="odd">
<td align="left">UI 要素の遅延読み込み (x:DeferLoadingStrategy)</td>
<td align="left">ユニバーサル Windows アプリでは、新しい x:DeferLoadingStrategy ディレクティブで遅延読み込みするインターフェイスの部分を指定して、起動パフォーマンスを改善したり、アプリのメモリ使用量を抑えることができます。 たとえば、間違ったデータが入力された時だけ表示されるデータ検証要素がアプリの UI にある場合、必要な時までその要素の読み込みを遅らせることができます。 ページが読み込まれた時にエレメント オブジェクトは作成されず、データ エラーがある時のみ作成されるため、ページのビジュアル ツリーに追加する必要があります。</td>
</tr>
<tr class="even">
<td align="left">SplitView</td>
<td align="left">新しい [<strong>SplitView</strong>](https://msdn.microsoft.com/library/windows/apps/dn864360) コントロールを使うことで、表示と非表示を簡単に切り替えることができます。 このコントロールは一般的に、トップレベルのナビゲーションに使われます。たとえば、「ハンバーガーのメニュー」でナビゲーション コンテンツを非表示にしておき、ユーザーの操作の結果、必要であればメニューをフェード インさせるといった具合です。</td>
</tr>
<tr class="odd">
<td align="left">RelativePanel</td>
<td align="left">[<strong>RelativePanel</strong>](https://msdn.microsoft.com/library/windows/apps/dn879546) は、オブジェクトの位置を他のオブジェクト (または親パネル) との位置関係で指定して配置できる新しいレイアウト パネルです。 たとえば、テキストは常にパネルの左側に配置し、ボタンは必ずそのテキストの下に来るように指定することができます。 ユーザー インターフェイスを作成するとき、はっきりとした線に沿って位置決めできるようなパターンであれば、[<strong>StackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/br209635) や [<strong>Grid</strong>](https://msdn.microsoft.com/library/windows/apps/br242704) を使いますが、そうしたパターンがないときには <strong>RelativePanel</strong> を使います。</td>
</tr>
<tr class="even">
<td align="left">CalendarView</td>
<td align="left">[<strong>CalendarView</strong>](https://msdn.microsoft.com/library/windows/apps/dn890052) は、カスタマイズ可能な月単位のビューで日付や日付範囲を簡単に表示および選択できるコントロールです。 <strong>CalendarView</strong> は最小日付、最大日付、ブラックアウト日などの機能をサポートし、選択できる日付を制限します。 特定の日におけるスケジュールのおおよその「埋まり具合」を示すカスタムの予約状況バーを設定することもできます。</td>
</tr>
<tr class="odd">
<td align="left">CalendarDatePicker</td>
<td align="left">[<strong>CalendarDatePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn950083) はカレンダーの曜日や埋まり具合などのコンテキスト情報が必要となる [<strong>CalendarView</strong>](https://msdn.microsoft.com/library/windows/apps/dn890052) から、単一の日付を選ぶ場合に最適なドロップダウン コントロールです。 [<strong>DatePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn298584) コントロールと同様、<strong>DatePicker</strong> も、誕生日など既知の日付が選びやすいように配慮されています。</td>
</tr>
<tr class="even">
<td align="left">MediaTransportControls</td>
<td align="left">[<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926) のトランスポート コントロールは、新しい [<strong>MediaTransportControls</strong>](https://msdn.microsoft.com/library/windows/apps/dn831962) クラスで簡単にカスタマイズすることができます。 Windows 8.1 でも、<strong>MediaElement</strong> の組み込みのトランスポート コントロールを有効にするか、<strong>MediaElement</strong> のメソッドを呼び出すトランスポート コントロールを独自に作成することはできます。 しかし今や、<strong>MediaTransportControls</strong> の組み込み機能を使いながら、アプリに合わせて外観を簡単にカスタマイズすることができます。</td>
</tr>
<tr class="odd">
<td align="left">プロパティ変更通知</td>
<td align="left"><p>ユニバーサル Windows アプリでは、[<strong>DependencyObject</strong>](https://msdn.microsoft.com/library/windows/apps/br242356) でプロパティの変化をリッスンすることができ、対応する変更イベントを持たないプロパティの変化まで検出することができます。</p>
<p>通知はイベントと同様に動作しますが、実際にはコールバックとして公開されます。 コールバックは、イベント ハンドラーと同じように sender 引数を受け取りますが、イベント引数は受け取りません。 代わりに、どのプロパティかを示すためにプロパティ識別子のみが渡されます。 アプリでは、この情報を使って、いくつかのプロパティ通知に対応した単一のハンドラーを定義できます。 詳しくは、[<strong>RegisterPropertyChangedCallback</strong>](https://msdn.microsoft.com/library/windows/apps/dn831902) および [<strong>UnregisterPropertyChangedCallback</strong>](https://msdn.microsoft.com/library/windows/apps/dn831910) に関するページをご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left">マップ</td>
<td align="left"><p>[<strong>MapControl</strong>](https://msdn.microsoft.com/library/windows/apps/dn637004) クラスが更新されて、航空写真の 3D 表示と道路地図表示が可能になりました。 ユニバーサル Windows アプリでは、これらの新機能と以前のマッピング機能の両方を使うことができます。 マッピングをアプリに追加するには、次の API を使います。</p>
<ul>
<li>[<strong>Windows.UI.Xaml.Controls.Maps</strong>](https://msdn.microsoft.com/library/windows/apps/dn610751) 名前空間 - マップを表示します。</li>
<li>[<strong>Windows.Services.Maps</strong>](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間 - 場所とルートを検索します。</li>
</ul>
<p>ユニバーサル Windows アプリでこれらの API をすぐにでも使うには、まず [Bing Maps Developer Center](https://www.bingmapsportal.com/) からキーを取得します。 詳しくは、「マップ アプリを認証する方法 ([How to authenticate a Maps app](https://msdn.microsoft.com/library/windows/apps/xaml/dn741528))」をご覧ください。 また、Windows 10 の新機能として、PC ユーザーと携帯電話ユーザーが設定アプリからオフライン マップをダウンロードできるようになりました。 インターネットにアクセスできないとき、オフライン マップが利用可能な場合は、[<strong>MapControl</strong>](https://msdn.microsoft.com/library/windows/apps/dn637004) はオフライン マップを使います。</p></td>
</tr>
<tr class="odd">
<td align="left">入力ボタンのマッピング</td>
<td align="left">[<strong>Windows.UI.Xaml.Input.KeyRoutedEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/hh943072) クラスには、新しい [<strong>OriginalKey</strong>](https://msdn.microsoft.com/library/windows/apps/dn960168) プロパティがあり、[<strong>Windows.System.VirtualKey</strong>](https://msdn.microsoft.com/library/windows/apps/br241812) への対応する更新と共に、キーボードの入力イベントに関連付けられている、マッピングされていない元の入力ボタンの取得を可能にします。</td>
</tr>
<tr class="even">
<td align="left">手描き入力</td>
<td align="left"><p>[<strong>InkCanvas</strong>](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールと基になる [<strong>InkPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn922011) クラスにより、C++、C#、または Visual Basic で Windows ランタイム アプリに堅牢な手書き入力機能をさらに簡単に実装できるようになりました。</p>
<p>The [<strong>InkCanvas</strong>](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールは、インク ストロークの描画とレンダリングのためのオーバーレイ領域を定義します。 このコントロールの機能 (入力、処理、レンダリング) は、[<strong>InkPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn922011)、[<strong>InkStroke</strong>](https://msdn.microsoft.com/library/windows/apps/br208485)、[<strong>InkRecognizer</strong>](https://msdn.microsoft.com/library/windows/apps/br208478)、そして [<strong>InkSynchronizer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903979) の各クラスから提供されます。</p>
<p></p>
<div class="alert">
<strong>重要</strong>  これらのクラスは、JavaScript を使っている Windows アプリではサポートされていません。
</div>
<div>
 
</div></td>
</tr>
</tbody>
</table>

 

## 更新された XAML の機能


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">CommandBar と AppBar の更新</td>
<td align="left"><p>異なるデバイス ファミリ間で一貫性のある API と動作、ユーザー エクスペリエンスを UWP アプリで実現できるように、[<strong>CommandBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn279427) コントロールと [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) コントロールが更新されています。</p>
<p>ユニバーサル Windows アプリの [<strong>CommandBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn279427) コントロールは、[<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) スーパーセットとなる機能を備え、アプリでの用途も広がっています。 Windows 10 では、新しいユニバーサル Windows アプリにはすべて <strong>CommandBar</strong> を使うことをお勧めします。 Windows 8.1 の <strong>CommandBar</strong> では、利用可能なコントロールが [<strong>AppBarButton</strong>](https://msdn.microsoft.com/library/windows/apps/dn279244) など [<strong>ICommandBarElement</strong>](https://msdn.microsoft.com/library/windows/apps/dn251969) を実装するコントロールに限られていました。 ユニバーサル Windows アプリでは、<strong>CommandBar</strong> に <strong>AppBarButton</strong> だけでなくカスタム コンテンツを追加することができます。</p>
<p><strong>AppBar</strong> が使われている Windows 8.1 アプリをユニバーサル Windows プラットフォームに移行しやすいように、[<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) コントロールが更新されています。 <strong>AppBar</strong> は、全画面表示アプリで画面端のジェスチャを使って呼び出す使い方を想定して設計されました。 Window 10 でアプリにウィンドウが存在するケースや、画面端のジェスチャがないなどの問題がこの変更で解消されます。</p>
<p>これまで Windows Phone に限定されていた [<strong>AppBar.ClosedDisplayMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn633872) の Hidden モードが今やすべてのデバイス ファミリでサポートされ、さまざまなレベルのヒントをコマンドで使い分けることができます。 Windows 8.1 アプリをユニバーサル Windows アプリにアップグレードすると、プラットフォームに備わっている画面端のジェスチャ機能を利用することができなくなります。一貫性の確保のため、既定では [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) に最小限のヒントが表示されます。</p>
<p><strong>新しい </strong> [<strong>AppBar</strong>](https://msdn.microsoft.com/library/windows/apps/hh701927) <strong>API:</strong>[<strong>Closing</strong>](https://msdn.microsoft.com/library/windows/apps/dn996483)、[<strong>OnClosing</strong>](https://msdn.microsoft.com/library/windows/apps/dn996484)、[<strong>Opening</strong>](https://msdn.microsoft.com/library/windows/apps/dn996486)、[<strong>OnOpening</strong>](https://msdn.microsoft.com/library/windows/apps/dn996485)、[<strong>TemplateSettings</strong>](https://msdn.microsoft.com/library/windows/apps/dn996487)</p>
<p><strong>新しい</strong> [<strong>CommandBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn279427) <strong>API:</strong>[<strong>CommandBarOverflowPresenterStyle</strong>](https://msdn.microsoft.com/library/windows/apps/dn975227)、[<strong>CommandBarOverflowPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn975225)</p></td>
</tr>
<tr class="even">
<td align="left">GridView の更新</td>
<td align="left">Windows 10 より前のバージョンでは、[<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) レイアウトの方向が、Windows では水平方向、Windows Phone では垂直方向に既定されていました。 UWP アプリの <strong>GridView</strong> では、エクスペリエンスの一貫性を確保するため、すべてのデバイス ファミリにおいて垂直方向のレイアウトを既定としています。</td>
</tr>
<tr class="odd">
<td align="left">AreStickyGroupHeadersEnabled プロパティ</td>
<td align="left">グループ化されたデータを表示している [<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) または [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) でリストがスクロールされたとき、グループ ヘッダーが常時表示されるようになりました。 ユーザーが閲覧しているデータのコンテキストはヘッダーに表示されるので、大きなデータセットではこのことが重要となります。 ただし、各グループの項目数がわずかであれば、それらの項目と一緒にヘッダーを画面外にスクロールした方がよい場合もあります。 この動作は、[<strong>ItemsStackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/dn298795) と [<strong>ItemsWrapGrid</strong>](https://msdn.microsoft.com/library/windows/apps/dn298849) の [<strong>AreStickyGroupHeadersEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn932028) プロパティを設定することで制御できます。</td>
</tr>
<tr class="even">
<td align="left">GroupHeaderContainerFromItemContainer メソッド</td>
<td align="left">グループ化されたデータを [<strong>ItemsControl</strong>](https://msdn.microsoft.com/library/windows/apps/br242803) で表示するとき、[<strong>GroupHeaderContainerFromItemContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903984) メソッドを呼び出すことで、そのグループの親ヘッダーの参照を取得することができます。 たとえば、グループ内の最後の項目がユーザーによって削除されるとき、そのグループ ヘッダーの参照を取得すれば、項目とグループ ヘッダーの両方をまとめて削除することができます。</td>
</tr>
<tr class="odd">
<td align="left">ChoosingGroupHeaderContainer イベント</td>
<td align="left">[<strong>ListViewBase</strong>](https://msdn.microsoft.com/library/windows/apps/br242879) の新しい [<strong>ChoosingGroupHeaderContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn899082) イベントにより、[<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) または [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) のグループ ヘッダーの状態を設定することができます。 たとえば、このイベントの処理でグループ ヘッダーの [<strong>AutomationProperties.NameProperty</strong>](https://msdn.microsoft.com/library/windows/apps/br209099) を設定することによって、支援技術のグループを表すことができます。</td>
</tr>
<tr class="even">
<td align="left">ChoosingItemContainer イベント</td>
<td align="left">[<strong>ListViewBase</strong>](https://msdn.microsoft.com/library/windows/apps/br242879) の新しい [<strong>ChoosingItemContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903989) イベントにより、[<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) または [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) の UI の仮想化をこれまでに増して自由に制御できるようになりました。 [<strong>ContainerContentChanging</strong>](https://msdn.microsoft.com/library/windows/apps/dn298914) イベントと一緒に使うことで、再利用されたコンテナーの独自のキューを管理し、そこから必要に応じて描画することができます。 たとえば、フィルタリングによってデータ ソースがリセットされた場合は、作成済みの一連のビジュアル (ItemContainers) とそのデータをすばやく突き合わせて、パフォーマンスを最大限に高めることができます。</td>
</tr>
<tr class="odd">
<td align="left">リストのスクロールの仮想化</td>
<td align="left"><p>XAML の [<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) コントロールと [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) コントロールに用意されている新しい [<strong>ListViewBase.ChoosingItemContainer</strong>](https://msdn.microsoft.com/library/windows/apps/dn903989) イベントは、データ コレクションに変更が生じた際にコントロールのパフォーマンスを改善します。</p>
<p>リストを完全にリセットして開始アニメーションを再生するのではなく、現在表示されている項目をフォーカスや選択状態も含めて維持します。ビューポート内の新しい項目と削除された項目は、アニメーション化されてスムーズに表示されたり消えたりします。 コンテナーが破棄されないデータ コレクションへの変更の後、アプリは「古い」項目を以前のコンテナーとすばやく比較し、コンテナー ライフサイクルをオーバーライドするメソッドの以降の処理をスキップします。 そうして「新しい」項目のみが処理され、リサイクルされたコンテナーまたは新しいコンテナーに関連付けられます。</p></td>
</tr>
<tr class="even">
<td align="left">SelectRange メソッドと SelectedRanges プロパティ</td>
<td align="left">ユニバーサル Windows アプリでは、[<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) コントロールと [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) コントロールにより、項目オブジェクトの参照ではなく、項目インデックスの範囲という観点から項目を選択することができます。 この方法は、選択した項目ごとに項目オブジェクトを作成する必要がないため、項目の選択を記述するうえでより効率的です。 詳しくは、[<strong>ListViewBase.SelectedRanges</strong>](https://msdn.microsoft.com/library/windows/apps/dn904244)、[<strong>ListViewBase.SelectRange</strong>](https://msdn.microsoft.com/library/windows/apps/dn904245)、および [<strong>ListViewBase.DeselectRange</strong>](https://msdn.microsoft.com/library/windows/apps/dn904241) に関するページをご覧ください。</td>
</tr>
<tr class="odd">
<td align="left">新しい ListViewItemPresenter API</td>
<td align="left">[<strong>ListView</strong>](https://msdn.microsoft.com/library/windows/apps/br242878) と [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/br242705) は、項目プレゼンターを使って、選択とフォーカスについて既定のビジュアルを提供します。 UWP アプリでは、[<strong>ListViewItemPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn298500) と [<strong>GridViewItemPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/dn279298) に、リスト項目のビジュアルをさらにカスタマイズできる新しいプロパティがあります。 [<strong>CheckBoxBrush</strong>](https://msdn.microsoft.com/library/windows/apps/dn913905)、[<strong>CheckMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn913923)、[<strong>FocusSecondaryBorderBrush</strong>](https://msdn.microsoft.com/library/windows/apps/dn898370)、[<strong>PointerOverForeground</strong>](https://msdn.microsoft.com/library/windows/apps/dn898372)、[<strong>PressedBackground</strong>](https://msdn.microsoft.com/library/windows/apps/dn913931)、そして [<strong>SelectedPressedBackground</strong>](https://msdn.microsoft.com/library/windows/apps/dn913937) がその新しいプロパティです。</td>
</tr>
<tr class="even">
<td align="left">SemanticZoom の更新</td>
<td align="left"><p>[<strong>SemanticZoom</strong>](https://msdn.microsoft.com/library/windows/apps/hh702601) コントロールは、UWP アプリでは、すべてのデバイス ファミリにおいて動作が一貫しています。</p>
<p>拡大表示ビューと縮小表示ビューを切り替える既定のアクションは、拡大表示ビューでグループ ヘッダーをタップすることです。 これは Windows Phone 8.1 での動作と同じですが、ズームにピンチ ジェスチャを使っていた Windows 8.1 でのそれとは異なります。 ピンチによるズームを使ってビューを変更するには、[<strong>SemanticZoom</strong>](https://msdn.microsoft.com/library/windows/apps/hh702601) の内部 [<strong>ScrollViewer</strong>](https://msdn.microsoft.com/library/windows/apps/br209527) で [<strong>ScrollViewer.ZoomMode</strong>](https://msdn.microsoft.com/library/windows/apps/br209601) を "Enabled" に設定します。</p>
<p>ユニバーサル Windows アプリでは、拡大表示ビューが縮小表示ビューに置き換えられます。この縮小表示ビューのサイズは、置き換える前のビューと同じです。 これは Windows 8.1 での動作と同じですが、縮小表示ビューが画面全体を占有し、他のすべてのコンテンツの上にレンダリングされていた Windows Phone 8.1 でのそれとは異なります。</p></td>
</tr>
<tr class="odd">
<td align="left">DatePicker および TimePicker の更新</td>
<td align="left">[<strong>DatePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn298584) コントロールと [<strong>TimePicker</strong>](https://msdn.microsoft.com/library/windows/apps/dn299280) コントロールは、ユニバーサル Windows アプリでは、すべてのデバイス ファミリにおいて一貫した実装がなされます。 Windows 10 向けに見た目も刷新されています。 ポップアップについては、すべてのデバイスで [<strong>DatePickerFlyout</strong>](https://msdn.microsoft.com/library/windows/apps/dn625013) コントロールと [<strong>TimePickerFlyout</strong>](https://msdn.microsoft.com/library/windows/apps/dn608313) コントロールを使います。 これは、Windows Phone 8.1 での動作と同じですが、[<strong>ComboBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209348) コントロールを使っていた Windows 8.1 でのそれとは異なります。 ポップアップ コントロールを使うと、カスタマイズされた日付と時刻の選択機能をこれまでに増して簡単に作成することができます。</td>
</tr>
<tr class="even">
<td align="left">新しい ScrollViewer API</td>
<td align="left">[<strong>ScrollViewer</strong>](https://msdn.microsoft.com/library/windows/apps/br209527) に、タッチによるパンが開始および停止したときにアプリに通知する新しい [<strong>DirectManipulationStarted</strong>](https://msdn.microsoft.com/library/windows/apps/dn858544) イベントと [<strong>DirectManipulationCompleted</strong>](https://msdn.microsoft.com/library/windows/apps/dn858543) イベントが追加されました。 これらのイベントを処理することで、これらのユーザー アクションに合わせて UI を調整できます。</td>
</tr>
<tr class="odd">
<td align="left">MenuFlyout の更新</td>
<td align="left">ユニバーサル Windows アプリには、すぐれたショートカット メニューをより簡単に作成できる新しい API があります。 新しい [<strong>MenuFlyout.ShowAt</strong>](https://msdn.microsoft.com/library/windows/apps/dn913174) メソッドでは、別の要素の位置を基準にポップアップを表示する場所を指定できます ([<strong>MenuFlyout</strong>](https://msdn.microsoft.com/library/windows/apps/dn299030) は、アプリのウィンドウの境界線上に重ねることもできるようになりました)。カスケード メニューを作成するには、新しい [<strong>MenuFlyoutSubItem</strong>](https://msdn.microsoft.com/library/windows/apps/dn913170) クラスを使います。</td>
</tr>
<tr class="even">
<td align="left">ContentPresenter、Grid、StackPanel の新しい Border プロパティ</td>
<td align="left">一般的なコンテナー コントロールに、XAML に Border 要素を追加せずに周囲に境界線を描画できる、新しい境界線プロパティが追加されました。 [<strong>ContentPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/br209378)、[<strong>Grid</strong>](https://msdn.microsoft.com/library/windows/apps/br242704)、そして [<strong>StackPanel</strong>](https://msdn.microsoft.com/library/windows/apps/br209635) に、[<strong>BorderBrush</strong>](https://msdn.microsoft.com/library/windows/apps/dn960179)、[<strong>BorderThickness</strong>](https://msdn.microsoft.com/library/windows/apps/dn960181)、[<strong>CornerRadius</strong>](https://msdn.microsoft.com/library/windows/apps/dn960183)、[<strong>Padding</strong>](https://msdn.microsoft.com/library/windows/apps/dn960187) という新しいプロパティが追加されました。</td>
</tr>
<tr class="odd">
<td align="left">ContentPresenter の新しいテキスト API</td>
<td align="left">[<strong>ContentPresenter</strong>](https://msdn.microsoft.com/library/windows/apps/br209378) に、[<strong>LineHeight</strong>](https://msdn.microsoft.com/library/windows/apps/dn903982)、[<strong>LineStackingStrategy</strong>](https://msdn.microsoft.com/library/windows/apps/dn831933)、[<strong>MaxLines</strong>](https://msdn.microsoft.com/library/windows/apps/dn831935)、そして[<strong>TextWrapping</strong>](https://msdn.microsoft.com/library/windows/apps/dn831937) というテキスト表示をより詳細に制御するための新しい API が追加されました。</td>
</tr>
<tr class="even">
<td align="left">システムのフォーカスのビジュアル</td>
<td align="left">XAML コントロールのフォーカスのビジュアルは、コントロール テンプレートの XAML 要素として宣言するのではなく、システムによって作成されるようになりました。 フォーカスのビジュアルは通常、モバイル デバイスでは必要ないため、必要に応じてシステムで作成および管理するようにすれば、アプリのパフォーマンスが向上します。 フォーカスのビジュアルをさらに制御する場合は、システムの動作を上書きし、フォーカスのビジュアルを定義するカスタム コントロール テンプレートを使います。 詳しくは、[<strong>UseSystemFocusVisuals</strong>](https://msdn.microsoft.com/library/windows/apps/dn899076) および [<strong>IsTemplateFocusTarget</strong>](https://msdn.microsoft.com/library/windows/apps/dn899074) に関するページをご覧ください。</td>
</tr>
<tr class="odd">
<td align="left">PasswordBox.PasswordRevealMode</td>
<td align="left"><p>ユニバーサル Windows アプリでは、[<strong>IsPasswordRevealButtonEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/hh702579) に代わって [<strong>PasswordRevealMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn890867) プロパティが導入され、デバイス ファミリにまたがる一貫した動作を実現します。</p>
<p></p>
<div class="alert">
<strong>注</strong>  Windows 10 より前のバージョンでは、パスワードを表示するボタンは既定では表示されませんでしたが、ユニバーサル Windows アプリでは既定で表示されます。 アプリのセキュリティ上の理由によりパスワードを常に非表示にする必要がある場合は、[<strong>PasswordRevealMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn890867) を "Hidden" に設定します。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left">Control.IsTextScaleFactorEnabled</td>
<td align="left">Windows Phone 8.1 で利用可能だった [<strong>IsTextScaleFactorEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn624997) プロパティが、ユニバーサル Windows アプリでは、すべてのデバイス ファミリにおいて利用可能になりました。</td>
</tr>
<tr class="odd">
<td align="left">AutoSuggestBox</td>
<td align="left">Windows Phone 8.1 の [<strong>AutoSuggestBox</strong>](https://msdn.microsoft.com/library/windows/apps/dn633874) コントロールが、ユニバーサル Windows アプリでは、すべてのデバイス ファミリにおいて利用可能になりました。[<strong>SearchBox</strong>](https://msdn.microsoft.com/library/windows/apps/dn252771) の代わりに使ってください。 <strong>AutoSuggestBox</strong> は、ユーザーによる入力の際に候補を提供します。タッチ、キーボード、入力方式エディターなど、さまざまな種類の入力に対応しています。 [<strong>QueryIcon</strong>](https://msdn.microsoft.com/library/windows/apps/dn996494) プロパティと [<strong>QuerySubmitted</strong>](https://msdn.microsoft.com/library/windows/apps/dn996497) イベントという、検索ボックスとしての機能を高める新しいメンバーも追加されています。</td>
</tr>
<tr class="even">
<td align="left">ContentDialog</td>
<td align="left">Windows Phone 8.1 の [<strong>ContentDialog</strong>](https://msdn.microsoft.com/library/windows/apps/dn633972) コントロールが、ユニバーサル Windows アプリでは、すべてのデバイス ファミリにおいて利用可能になりました。 <strong>ContentDialog</strong> を使えば、ありとあらゆるデバイスで適切に機能するカスタマイズ可能なモーダル ダイアログを表示できます。</td>
</tr>
<tr class="odd">
<td align="left">Pivot</td>
<td align="left">Windows Phone 8.1 の [<strong>Pivot</strong>](https://msdn.microsoft.com/library/windows/apps/dn608241) コントロールが、ユニバーサル Windows アプリでは、すべてのデバイス ファミリにおいて利用可能になりました。 すなわち、モバイル デバイスとデスクトップ デバイスに対応するアプリで、同じ <strong>Pivot</strong> コントロールを使うことができます。 <strong>Pivot</strong> は、画面サイズと入力の種類に基づいてアダプティブ動作を提供します。 各ピボット項目の異なる情報のビューで、タブに似た動作をするように <strong>Pivot</strong> コントロールのスタイルを指定できます。</td>
</tr>
</tbody>
</table>

 

## テキスト


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Windows の基本的なテキスト API</td>
<td align="left"><p>新しい [<strong>Windows.UI.Text.Core</strong>](https://msdn.microsoft.com/library/windows/apps/dn958238) 名前空間は、キーボード入力の処理を単一のサーバーで一元管理するクライアント サーバー システムを備えています。</p>
<p>そのシステムを使ってカスタム テキスト入力コントロールの編集バッファーを操作できます。 テキスト入力サーバーは、アプリとサーバーの間の非同期通信チャネルを介して、テキスト入力コントロールの内容と、そのコントロール独自の編集バッファーの内容を常に同期した状態に保ちます。</p></td>
</tr>
<tr class="even">
<td align="left">ベクター アイコン</td>
<td align="left">[<strong>Glyphs</strong>](https://msdn.microsoft.com/library/windows/apps/br209921) 要素に、カラー フォントをサポートする [<strong>IsColorFontEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn900468) プロパティと [<strong>ColorFontPalleteIndex</strong>](https://msdn.microsoft.com/library/windows/apps/dn900466) プロパティが追加されました。 カラー パレットの切り替えに <strong>ColorFontPalleteIndex</strong> を使うと、1 つのアイコンを異なるカラー セットでレンダリングできます。たとえば、アイコンの有効バージョンと無効バージョンを表示できます。</td>
</tr>
<tr class="odd">
<td align="left">入力方式エディター ウィンドウのイベント</td>
<td align="left">ユーザーは、テキスト入力ボックスのすぐ下のウィンドウに表示される入力方式エディターを使ってテキストを入力することがあります (特に東アジア言語の場合)。 [<strong>TextBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209683) や [<strong>RichEditBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227548) の [<strong>CandidateWindowBoundsChanged</strong>](https://msdn.microsoft.com/library/windows/apps/dn955144) イベントや [<strong>DesiredCandidateWindowAlignment</strong>](https://msdn.microsoft.com/library/windows/apps/dn955145) プロパティを使うと、アプリの UI と IME ウィンドウをより効果的に融合することができます。</td>
</tr>
<tr class="even">
<td align="left">テキスト作成イベント</td>
<td align="left">[<strong>TextBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209683) と [<strong>RichEditBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227548) には、入力方式エディターを使ってテキストを作成するときにアプリに通知する [<strong>TextCompositionStarted</strong>](https://msdn.microsoft.com/library/windows/apps/dn891458)、[<strong>TextCompositionEnded</strong>](https://msdn.microsoft.com/library/windows/apps/dn891457)、そして [<strong>TextCompositionChanged</strong>](https://msdn.microsoft.com/library/windows/apps/dn891456) という新しいイベントがあります。 これらのイベントを処理することで、IME のテキスト作成プロセスに合わせてアプリのコードを調整できます。 たとえば、東アジア言語のインライン オートコンプリート機能を実装できます。</td>
</tr>
<tr class="odd">
<td align="left">双方向テキストの処理の改善</td>
<td align="left"><p>XAML テキスト コントロールの新しい API により、双方向テキストの処理が改善され、さまざまな入力言語においてテキストの配置と段落の方向がより正確に認識されるようになりました。</p>
<p>[<strong>TextReadingOrder</strong>](https://msdn.microsoft.com/library/windows/apps/dn949133) プロパティの既定値は、"<strong>DetectFromContent</strong>" に変更されました。つまり、読む方向の検出に対するサポートが既定で有効になっています。 [<strong>PasswordBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227519)、[<strong>RichEditBox</strong>](https://msdn.microsoft.com/library/windows/apps/br227548)、そして [<strong>TextBox</strong>](https://msdn.microsoft.com/library/windows/apps/br209683) には、<strong>TextReadingOrder</strong> プロパティも追加されました。</p>
<p>テキスト コントロールの [<strong>TextAlignment</strong>](https://msdn.microsoft.com/library/windows/apps/br209703) プロパティを新しい値である "<strong>DetectFromContent</strong>" に設定すれば、コンテンツから配置を自動的に検出します。</p></td>
</tr>
<tr class="even">
<td align="left">テキストの描画</td>
<td align="left">Windows 10 では、ほとんどの状況で、XAML アプリのテキストが Windows 8.1 のほぼ 2 倍の速度で描画されます。 ほとんどの場合は、変更しなくても、アプリでこの速度向上の恩恵を受けることができます。 また、描画速度の向上のほか、XAML アプリの一般的なメモリ消費量が 5% 減少します。</td>
</tr>
</tbody>
</table>

 

## アプリケーション モデル


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Cortana</td>
<td align="left"><p>音声コマンドが <strong>Cortana</strong> の基本機能を拡張し、外部アプリケーションで単一の操作を起動して実行します。</p>
<p>アプリの基本的な機能を統合して、ユーザーが直接アプリを開かずにほとんどのタスクを実行できる中心的エントリ ポイントを提供することで、<strong>Cortana</strong> は、アプリとユーザーの仲介役となります。 多くの場合、これによってユーザーの時間と労力を大幅に軽減することができます。</p>
<p>アプリをコルタナのキャンバスに統合する方法については、「Cortana の操作 (XAML) ([integrate your app into the Cortana canvas](https://msdn.microsoft.com/library/windows/apps/xaml/dn974230))」をご覧ください。 アイデアが必要な場合は、「ユニバーサル Windows アプリのデザインの基礎 ([Design basics for Universal Windows apps](https://dev.windows.com/design/design-basics))」にて、<strong>Cortana </strong> 特有の推奨されるデザインとユーザー エクスペリエンスのガイドラインをご参照ください。</p></td>
</tr>
<tr class="even">
<td align="left">エクスプローラー</td>
<td align="left">新しい [<strong>Windows.System.Launcher.LaunchFolderAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn889616) メソッドにより、エクスプローラーを起動して、指定したフォルダーの内容を表示することができます。</td>
</tr>
<tr class="odd">
<td align="left">共有ストレージ</td>
<td align="left">新しい [<strong>Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager</strong>](https://msdn.microsoft.com/library/windows/apps/dn889985) クラスとそのメソッドにより、URI のアクティブ化を介して他のアプリを起動するとき、共有トークンを渡し、別のアプリとファイルを共有することができます。 ターゲット アプリはトークンを利用して、ソース アプリが共有しているファイルを取得します。</td>
</tr>
<tr class="even">
<td align="left">設定</td>
<td align="left"><p>ms-settings プロトコルと [<strong>LaunchUriAsync</strong>](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを使うと、組み込みの設定ページを表示できます。 たとえば、次のコードは Wi-Fi の設定ページを表示します。</p>
<p><code>bool result = await Launcher.LaunchUriAsync(new Uri(&quot;ms-settings://network/wifi&quot;));</code></p>
<p>表示できる設定ページのリストについては、「Windows Phone 8 の起動、再開、マルチタスク ([How to display built-in settings pages by using the ms-settings protocol](https://msdn.microsoft.com/library/windows/apps/jj207014.aspx))」をご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left">アプリ間通信</td>
<td align="left"><p>Windows 10 の新しい [アプリ間通信app-to-app communication](https://msdn.microsoft.com/library/windows/apps/xaml/dn997827) API により、Windows アプリケーション (および Windows Web アプリケーション) 間での相互起動やデータとファイルの交換が可能になります。</p>
<p>これらの新しい API を使うと、複数のアプリケーションを使う必要のあった複雑な作業をシームレスに処理できるようになります。 たとえば、アプリでソーシャル ネットワー キング アプリを起動して連絡先を選択したり、チェックアウト アプリケーションを起動して支払処理を完了したりできます。</p></td>
</tr>
<tr class="even">
<td align="left">アプリ サービス</td>
<td align="left">アプリ サービスは、Windows 10 でアプリが他のアプリにサービスを提供する方法の 1 つです。 アプリ サービスは、バックグラウンド タスクの形式を取ります。 フォアグラウンド アプリは、別のアプリでアプリ サービスを呼び出してバックグラウンドでタスクを実行できます。 アプリ サービス API のリファレンス情報については、[<strong>Windows.ApplicationModel.AppService</strong>](https://msdn.microsoft.com/library/windows/apps/dn921731) に関するページをご覧ください。</td>
</tr>
<tr class="odd">
<td align="left">アプリ パッケージ マニフェスト</td>
<td align="left"><p>Windows 10 の[パッケージ マニフェスト スキーマpackage manifest schema](https://msdn.microsoft.com/library/windows/apps/br211474)のリファレンスに対する更新には、追加、削除、変更された要素が含まれています。</p>
<p>このスキーマのすべての要素、属性、タイプに関するリファレンス情報については、要素の階層 ([Element Hierarchy](https://msdn.microsoft.com/library/windows/apps/dn934819)) に関するページをご覧ください。</p></td>
</tr>
</tbody>
</table>

 

## デバイス


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Microsoft Surface Hub</td>
<td align="left"><p>Microsoft Surface Hub は、高性能な共同作業デバイスであり、Surface Hub または接続されているデバイスからネイティブに実行されるユニバーサル Windows アプリに対応する大画面プラットフォームです。</p>
<p>ビジネス向けの独自アプリを作成し、大画面、タッチ入力、手描き入力、広範なオンボード ハードウェア (カメラ、センサーなど) を活用しましょう。</p>
<p>[ユニバーサル Windows アプリのデザインの基礎Design basics for Universal Windows apps](https://dev.windows.com/design/design-basics)に関するページで、Surface ハブ特有の推奨デザインとユーザー エクスペリエンスのガイドラインをご参照ください。 次のドキュメントでは、ユニバーサル Windows アプリのレスポンシブ デザイン手法を説明しています。</p>
<p>共同の共有アプリのサポートについては、[<strong>SharedModeSettings</strong>](https://msdn.microsoft.com/library/windows/apps/dn949019) に関するページをご覧ください。</p>
<p>新しい [<strong>InkCanvas</strong>](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールでのマルチポイント手描き入力のサポートについて詳しくは、[<strong>Windows.UI.Input.Inking</strong>](https://msdn.microsoft.com/library/windows/apps/br208524) と [<strong>Windows.UI.Input.Inking.Core</strong>](https://msdn.microsoft.com/library/windows/apps/dn958452) に関するページをご覧ください。</p>
<p>センサー入力の処理については、「デバイス、プリンター、センサーの統合 (XAML) ([Integrating devices, printers, and sensors](https://msdn.microsoft.com/library/windows/apps/br229563))」をご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left">場所</td>
<td align="left"><p>Windows 10 では、位置情報へのアクセス許可をユーザーに求める画面を表示する新しいメソッド、[<strong>RequestAccessAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn859152) が導入されています。</p>
<p>ユーザーが<strong>設定</strong>アプリの<strong>位置情報に関するプライバシー設定</strong>で位置情報に関するプライバシーを設定します。 次の場合にのみ、アプリでユーザーの位置情報にアクセスできます。</p>
<ul>
<li><strong>このデバイスの位置情報</strong>がオンになっている (Windows 10 for phones には適用されません)。</li>
<li>位置情報サービス設定の <strong>[位置情報]</strong> が<strong>オン</strong>になっている。</li>
<li><strong>[位置情報を使うことができるアプリを選ぶ]</strong> で、アプリが<strong>オン</strong>になっている。</li>
</ul>
<p>ユーザーの位置情報にアクセスする前に、[<strong>RequestAccessAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出すことが重要です。 このとき、アプリをフォアグラウンドで実行し、<strong>RequestAccessAsync</strong> を UI スレッドから呼び出す必要があります。 位置情報に対するアクセス許可をユーザーがアプリに与えるまで、アプリは位置情報データにアクセスできません。</p></td>
</tr>
<tr class="odd">
<td align="left">AllJoyn</td>
<td align="left"><p>[<strong>Windows.Devices.AllJoyn</strong>](https://msdn.microsoft.com/library/windows/apps/dn894971) Windows ランタイム名前空間には、AllJoyn オープン ソース ソフトウェア フレームワークとサービスのマイクロソフトによる実装が導入されています。 これらの API により、Windows デバイス用のユニバーサル アプリは、AllJoyn に基づくモノのインターネット (IoT) のシナリオに他のデバイスと共に参加できるようになります。 AllJoyn C API について詳しくは、[The AllSeen Alliance](https://allseenalliance.org/) からドキュメントをダウンロードして、ご確認ください。</p>
<p>デバイス アプリで AllJoyn シナリオの実現させるための Windows コンポーネントを生成するには、このリリースに含まれている [AllJoynCodeGen tool](https://msdn.microsoft.com/library/windows/apps/dn913809) ツールを使います。</p>
<div class="alert">
<strong>注</strong>  小型デバイス向け Windows 10 IoT Core がリリースされました。これにより、Windows と Visual Studio を使っていわゆる「モノのインターネット (IoT)」のデバイスが開発できます。 Windows IoT について詳しくは、[WindowsOnDevices.com](http://www.windowsondevices.com/) をご覧ください。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left">モバイルでの印刷 API (XAML)</td>
<td align="left">モバイル デバイスを含む、さまざまなデバイス ファミリで XAML ベースの UWP アプリから印刷できる単一の統合された API のセットがあります。 [<strong>Windows.Graphics.Printing</strong>](https://msdn.microsoft.com/library/windows/apps/br226489) 名前空間と [<strong>Windows.UI.Xaml.Printing</strong>](https://msdn.microsoft.com/library/windows/apps/br243325) 名前空間の慣れ親しんだ印刷関連の API を使って、印刷機能をモバイル アプリに追加できるようになりました。</td>
</tr>
<tr class="odd">
<td align="left">バッテリー</td>
<td align="left"><p>[<strong>Windows.Devices.Power</strong>](https://msdn.microsoft.com/library/windows/apps/dn895017) 名前空間のバッテリー API を使うと、アプリを実行しているデバイスに接続されたバッテリーについて詳しい情報をアプリで取得できます。</p>
<p>個々のバッテリー コントローラーまたはすべてのバッテリー コントローラーの集合体を表す [<strong>Battery</strong>](https://msdn.microsoft.com/library/windows/apps/dn895004) オブジェクトを作成します (それぞれ、[<strong>FromIdAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn895013) または [<strong>AggregateBattery</strong>](https://msdn.microsoft.com/library/windows/apps/dn895011) によって作成されている場合)。</p>
<p>[<strong>GetReport</strong>](https://msdn.microsoft.com/library/windows/apps/dn895015) メソッドを使って、対応するバッテリーの充電量、容量、状態を示す [<strong>BatteryReport</strong>](https://msdn.microsoft.com/library/windows/apps/dn895005) オブジェクトを返します。</p></td>
</tr>
<tr class="even">
<td align="left">MIDI デバイス</td>
<td align="left"><p>新しい [<strong>Windows.Devices.Midi</strong>](https://msdn.microsoft.com/library/windows/apps/dn895002) 名前空間により、次を作成することができます。</p>
<ul>
<li>外部 MIDI デバイスと通信可能なアプリ。</li>
<li>Microsoft GS MIDI ソフトウェア シンセサイザーと直接通信するアプリと外部デバイス。</li>
<li>複数のクライアントが同時に 1 つの MIDI ポートにアクセスするシナリオ。</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">カスタム センサーのサポート</td>
<td align="left">[<strong>Windows.Devices.Sensors.Custom</strong>](https://msdn.microsoft.com/library/windows/apps/dn895032) 名前空間により、ハードウェアの開発者は CO2 センサーのような新しいカスタム センサーの種類を定義することができます。</td>
</tr>
<tr class="even">
<td align="left">ホスト ベースのカード エミュレーション (HCE)</td>
<td align="left"><p>ホスト カード エミュレーションを使うと、OS でホストされている NFC カード エミュレーション サービスを実装すると同時に、NFC 無線経由で外部リーダー ターミナルと通信することができます。</p>
<p>バックグラウンド タスクを実装して NFC 経由でスマートカードをエミュレートします。 バックグラウンド タスクをトリガーするには、[<strong>SmartCardTrigger</strong>](https://msdn.microsoft.com/library/windows/apps/dn624853) クラスを使います。</p>
<p>[<strong>SmartCardTriggerType</strong>](https://msdn.microsoft.com/library/windows/apps/dn608017) 列挙型の <strong>EmulatorHostApplicationActivated</strong> 値により、アプリは HCE イベントが発生したことを認識します。</p></td>
</tr>
</tbody>
</table>

 

## グラフィックス


|                      |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| DirectX              | Windows 10 の DirectX 12 では、DirectX の中核を担う 3D グラフィックス API である Microsoft Direct3D の次世代バージョンが導入されます。 [Direct3D 12 グラフィックス](https://msdn.microsoft.com/library/windows/desktop/dn903821)は、下位レベルのコンソールのような API の効率性とパフォーマンスを実現します。 Direct3D 12 は、これまで以上に高速で高い効率性を発揮します。 より豊かなシーン、より多くのオブジェクト、より複雑な効果を実現し、最新のグラフィックス ハードウェアをより有効に活用できます。                                                                                                                                                                                                                                                                                     |
| SoftwareBitmapSource | ユニバーサル Windows アプリでは、XAML 画像のソースとして新しい [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/dn997854) 型を使うことができます。 これにより、エンコードされていない画像を XAML フレームワークに渡し、XAML フレームワークによる画像のデコードをバイパスして、すぐに画面に表示することができます。 カメラから直接低遅延で写真をレンダリングする、カスタムの画像デコーダーを使う、DirectX サーフェイスからフレームをキャプチャする、メモリ内の画像をゼロから作成し、待機時間とメモリのオーバーヘッドを低く抑えながら XAML で直接すべてレンダリングするなど、非常に高速な画像のレンダリングを実現できます。                                                                                                     |
| 遠近投影カメラ   | ユニバーサル Windows アプリでは、XAML の新しい Transform3D API を使って、XAML ツリー (シーン) に遠近法変換を適用することができます。適用すると、その 1 つのシーン全体の変換 (カメラ) に従ってすべての XAML 子要素が変換されます。 従来は、これを実現するには、MatrixTransform と複雑な数式を使う必要がありましたが、Transform3D によりその作業が大幅に簡略化されるうえに、この効果をアニメーション化することもできます。 詳しくは、[**UIElement.Transform3D**](https://msdn.microsoft.com/library/windows/apps/dn906919) プロパティ、[**Transform3D**](https://msdn.microsoft.com/library/windows/apps/dn914748)、[**CompositeTransform3D**](https://msdn.microsoft.com/library/windows/apps/dn914714)、および [**PerspectiveTransform3D**](https://msdn.microsoft.com/library/windows/apps/dn914740) に関するページをご覧ください。 |

 

## メディア


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">HTTP ライブ ストリーミング</td>
<td align="left">新しい [<strong>AdaptiveMediaSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn946912) クラスを使うと、アダプティブ ビデオ ストリーミング機能をアプリに追加できます。 ストリーミング マニフェスト ファイルを指定してオブジェクトを初期化します。 サポートされているマニフェストの形式として、Http Live Streaming (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) があります。 オブジェクトの XAML メディア要素にバインドされると、アダプティブ再生が始まります。 利用可能なビットレート、最小ビットレート、最大ビットレートなどのストリームのプロパティを照会して、必要に応じて設定できます。</td>
</tr>
<tr class="even">
<td align="left">メディア ファンデーションの Transcode Video Processor (XVP) によるメディア ファンデーション トランスフォーム (MFT) のサポート</td>
<td align="left"><p>メディア ファンデーション トランスフォーム (MFT) を利用する Windows アプリでは、<strong>メディア ファンデーションのトランスコード ビデオ プロセッサー</strong> (XVP) を使って、生のビデオ データを変換、拡大縮小、変形することができます。</p>
<p>新しい [MF_XVP_CALLER_ALLOCATES_OUTPUT](https://msdn.microsoft.com/library/windows/desktop/dn803919) 属性で、Microsoft DirectX ビデオ アクセラレーション (DXVA) モードであっても、呼び出し元によって割り当てられたテクスチャへの出力が可能です。</p>
<p>新しい [<strong>IMFVideoProcessorControl2</strong>](https://msdn.microsoft.com/library/windows/desktop/dn800741) インターフェイスにより、アプリでハードウェア効果を有効にし、サポートされているハードウェア効果を照会してビデオ プロセッサによって実行される回転操作をオーバーライドすることができます。</p></td>
</tr>
<tr class="odd">
<td align="left">コード変換</td>
<td align="left">新しい [<strong>MediaProcessingTrigger</strong>](https://msdn.microsoft.com/library/windows/apps/dn806005) API により、アプリでメディアのトランスコードをバックグラウンド タスクとして実行することができます。これにより、フォアグラウンド アプリが終了してもトランスコード処理を続けられます。</td>
</tr>
<tr class="even">
<td align="left">MediaElement のメディア エラー イベント</td>
<td align="left">ユニバーサル Windows アプリでは、メディア コンテンツに少なくとも 1 つの有効なストリームがある限り、いずれかのストリームのデコードでエラーが発生しても、[<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926) が複数のストリームを含むコンテンツを再生します。 たとえば、オーディオとビデオ ストリームを含むコンテンツのビデオ ストリームが失敗した場合は、<strong>MediaElement</strong> がオーディオ ストリームの再生を続けます。 [<strong>PartialMediaFailureDetected</strong>](https://msdn.microsoft.com/library/windows/apps/dn889635) イベントによって、ストリーム内のいずれかのストリームがデコードできなかったことが通知されます。 また、失敗したストリームの種類も通知されるため、その情報を UI に反映することができます。 メディア ストリーム内のすべてのストリームが失敗した場合は、[<strong>MediaFailed</strong>](https://msdn.microsoft.com/library/windows/apps/br227393) イベントがトリガーされます。</td>
</tr>
<tr class="odd">
<td align="left">MediaElement を使ったアダプティブ ビデオ ストリーミングのサポート</td>
<td align="left">[<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926) には、アダプティブ ビデオ ストリーミングをサポートする新しい [<strong>SetPlaybackSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn899085) メソッドが追加されました。 メディア ソースを [<strong>AdaptiveMediaSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn946912) に設定するには、このメソッドを使います。</td>
</tr>
<tr class="even">
<td align="left">MediaElement と Image を使ったキャスト</td>
<td align="left">[<strong>MediaElement</strong>](https://msdn.microsoft.com/library/windows/apps/br242926) コントロールと [<strong>Image</strong>](https://msdn.microsoft.com/library/windows/apps/br242752) コントロールには新しい [<strong>GetAsCastingSource</strong>](https://msdn.microsoft.com/library/windows/apps/dn920012) メソッドが追加されました。 このメソッドを使うと、メディア要素や画像要素のコンテンツを Miracast、Bluetooth、DLNA などのさまざまなリモート デバイスにプログラムで送信できます。この機能は、<strong>MediaElement</strong> で [<strong>AreTransportControlsEnabled</strong>](https://msdn.microsoft.com/library/windows/apps/dn298977) を "true" に設定することで自動的に有効になります。</td>
</tr>
<tr class="odd">
<td align="left">デスクトップ アプリ用メディア トランスポート コントロール</td>
<td align="left">[<strong>ISystemMediaTransportControls</strong>](https://msdn.microsoft.com/library/windows/desktop/dn892299) インターフェイスと、その関連の API により、デスクトップ アプリは組み込みのシステム メディア トランスポート コントロールを操作することができます。 これには、トランスポート コントロール ボタンによるユーザー操作に応答することと、現在再生中のメディア コンテンツに関するメタデータを表示するトランスポート コントロールの表示を更新することが含まれます。</td>
</tr>
<tr class="even">
<td align="left">ランダム アクセス JPEG エンコードとデコード</td>
<td align="left">新しい WIC メソッドである [<strong>IWICJpegFrameEncode</strong>](https://msdn.microsoft.com/library/windows/desktop/dn903864) と [<strong>IWICJpegFrameDecode</strong>](https://msdn.microsoft.com/library/windows/desktop/dn903834) は、JPEG 画像のエンコードとデコードを可能にします。 画像データのインデックス化もできるようになり、メモリを大量に消費する大きい画像のランダム アクセスも効率的に実行することができます。</td>
</tr>
<tr class="odd">
<td align="left">メディア コンポジション用オーバーレイ</td>
<td align="left">新しい [<strong>MediaOverlay</strong>](https://msdn.microsoft.com/library/windows/apps/dn764793) API と [<strong>MediaOverlayLayer</strong>](https://msdn.microsoft.com/library/windows/apps/dn764795) API により、静的または動的なメディア コンテンツからなる複数のレイヤーをメディア コンポジションに追加することがこれまでに増して簡単になりました。 レイヤーごとに不透明度、位置、およびタイミングを調整することができるだけでなく、入力レイヤー用の独自のカスタム コンポジターを実装することもできます。</td>
</tr>
<tr class="even">
<td align="left">新しいエフェクト フレームワーク</td>
<td align="left">[<strong>Windows.Media.Effects</strong>](https://msdn.microsoft.com/library/windows/apps/dn278802) 名前空間は、オーディオとビデオ ストリームにエフェクトを追加する、シンプルで直感的なフレームワークを提供します。 このフレームワークには、独自のオーディオ エフェクトやビデオ エフェクトを作成してメディア パイプラインに挿入するために実装できる基本的なインターフェイスが含まれています。</td>
</tr>
</tbody>
</table>

 

## ネットワーク


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">ソケット</td>
<td align="left"><p>ソケットの更新内容には、次の項目が含まれます。</p>
<ul>
<li><strong>ソケット ブローカー: </strong> ソケット ブローカーは、アプリのライフサイクルのすべての状態において、アプリに代わってソケット接続を確立し、閉じることができます。 これにより、アプリとアプリの提供するサービスが、より見つけやすくなります。 ソケット ブローカーを経由すると、たとえば Win32 サービスは、実行中でないときでも受信ソケット接続を受け付けることができます。</li>
<li><strong>スループットの向上: </strong> ソケットのスループットが、[<strong>Windows.Networking.Sockets</strong>](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間を使うアプリ向けに最適化されています。</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">バックグラウンド転送の後処理タスク</td>
<td align="left">[<strong>Windows.Networking.BackgroundTransfer</strong>](https://msdn.microsoft.com/library/windows/apps/br207242) 名前空間の新しい API により、後処理タスクのグループを登録することができます。 これによりアプリは、フォアグラウンドでない場合でも、バックグラウンド転送の成功または失敗にすぐ対応でき、ユーザーが次回アプリを再開するまで待つ必要がありません。</td>
</tr>
<tr class="odd">
<td align="left">広告に対する Bluetooth サポート</td>
<td align="left">[<strong>Windows.Devices.Bluetooth.Advertisement</strong>](https://msdn.microsoft.com/library/windows/apps/dn894325) 名前空間により、アプリは、Bluetooth LE の広告を送信、受信、およびフィルターすることができます。</td>
</tr>
<tr class="even">
<td align="left">Wi-Fi Direct API の更新内容</td>
<td align="left"><p>デバイス ブローカーが更新され、アプリから離れることなくデバイスのペアリングができるようになりました。 [<strong>Windows.Devices.WiFiDirect</strong>](https://msdn.microsoft.com/library/windows/apps/dn297687) 名前空間が更新され、デバイスを他のデバイスから検出できるようにしたり、デバイスで着信接続の通知をリッスンしたりできるようになりました。</p>
<div class="alert">
<strong>注</strong>  このリリースでは、Wi-Fi Direct の機能強化は UX に組み込まれておらず、プッシュ ボタンによるペアリングのみがサポートされています。 また、このリリースでは、サポートされるアクティブな接続は 1 つだけです。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left">JSON サポートの強化</td>
<td align="left">[<strong>Windows.Data.Json</strong>](https://msdn.microsoft.com/library/windows/apps/br240639) 名前空間では、デバッグ セッションで JSON オブジェクトを変換する際の、既存の標準定義のサポートと開発者エクスペリエンスが強化されました。</td>
</tr>
</tbody>
</table>

 

## セキュリティ


|                             |                                                                      |
|-----------------------------|----------------------------------------------------------------------|
| ECC 暗号化              | [
            **Windows.Security.Cryptography**](https://msdn.microsoft.com/library/windows/apps/br241404) 名前空間の新しい API では、楕円曲線暗号 (ECC) がサポートされています。ECC は、有限体上の楕円曲線に基づく公開キー暗号化の実装です。 ECC は数学的に RSA よりも複雑であり、キーのサイズが小さいため、メモリ消費が削減されてパフォーマンスが向上します。 ECC は Microsoft サービスとお客様に、RSA キーや NIST によって承認された曲線のパラメーターに代わる方法を提供します。 |
| Microsoft Passport          | Microsoft Passport は、パスワードの代わりに非対称暗号方式とジェスチャを使う、もう 1 つの認証方法です。 [
            **KeyCredentialManager**](https://msdn.microsoft.com/library/windows/apps/dn973043) といった [**Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) 名前空間のクラスにより、複雑な暗号または生体認証を使わずに、Microsoft Passport で簡単にアプリケーションを開発することができます。  |
| 業務用 Microsoft Passport | 業務用 Microsoft Passport は、パスワード、スマート カード、仮想スマート カードを使用しない Azure Active Directory アカウントを使って Windows にサインインする、もう 1 つの方法です。 このポリシー設定は、有効にするか、無効するかを選択できます。 |
| トークン ブローカー                | トークンのブローカーは、アプリがオンライン ID プロバイダー (Facebook など) に接続しやすくなる新しい認証フレームワークです。 アカウントのユーザー名とパスワードの管理や、効率の高い UI などの機能により、ユーザーの認証エクスペリエンスが大幅に改善されます。 |

 

## システム サービス


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">電源</td>
<td align="left"><p>バッテリー節約機能が有効または無効になった時は、Windows デスクトップ アプリケーションに通知されるようになりました。 電源状態の変化が把握できるので、アプリを調整してバッテリー駆動時間を向上できます。</p>
<p>[<strong>GUID_POWER_SAVING_STATUS</strong>](https://msdn.microsoft.com/library/windows/desktop/hh448380): この新しい GUID を [<strong>PowerSettingRegisterNotification</strong>](https://msdn.microsoft.com/library/windows/desktop/hh769082) 関数と使うと、バッテリー節約機能が有効または無効になったときに通知されるようにできます。</p>
<p>[<strong>SYSTEM_POWER_STATUS</strong>](https://msdn.microsoft.com/library/windows/desktop/aa373232): この構造体は更新され、バッテリー節約機能をサポートするようになりました。 4 つ目の <strong>SystemStatusFlag</strong> (旧 Reserved1) は、バッテリー節約機能が使用中かどうかを示すようになりました。 [<strong>GetSystemPowerStatus</strong>](https://msdn.microsoft.com/library/windows/desktop/aa372693) 関数を使うと、この構造体へのポインターが取得できます。</p></td>
</tr>
<tr class="even">
<td align="left">バージョン</td>
<td align="left"><p>バージョン ヘルパー関数 ([Version Helper functions](https://msdn.microsoft.com/library/windows/desktop/dn424972)) を使うと、オペレーティング システムのバージョンを調べることができます。 Windows 10 では、これらのヘルパー関数に新しい関数である [<strong>IsWindows10OrGreater</strong>](https://msdn.microsoft.com/library/windows/desktop/dn905474) が追加されました。 オペレーティング システムのバージョンを調べる場合は、非推奨の [<strong>GetVersionEx</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724451) 関数や [<strong>GetVersion</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724439) 関数ではなく、ヘルパー関数を使いましょう。 詳しくは、[システムのバージョンを取得する方法Getting the System Version](https://msdn.microsoft.com/library/windows/desktop/ms724429)に関するページをご覧ください。</p>
<p>非推奨の [<strong>GetVersionEx</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724451) 関数または [<strong>GetVersion</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724439) 関数を使って、[<strong>OSVERSIONINFOEX</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724833) 構造体または [<strong>OSVERSIONINFO</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724834) 構造体からバージョン情報を取得する場合は、これらの構造体に含まれるバージョン番号が、Windows 8.1 と Windows Server 2012 R2 のバージョン番号である 6.3 から、Windows 10 のバージョン番号である 10.0 に増加する点に注意してください。 詳しくは、オペレーティング システムのバージョン番号 ([Operating System Version](https://msdn.microsoft.com/library/windows/desktop/ms724832)) に関するページをご覧ください。</p>
<p>また、[<strong>GetVersionEx</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724451) 関数または [<strong>GetVersion</strong>](https://msdn.microsoft.com/library/windows/desktop/ms724439) 関数でこれらのバージョンの正しいバージョン情報を取得するには、アプリで Windows 8.1 または Windows 10 を明示的に指定する必要があります。 詳しくは、Windows をアプリで指定する方法 ([Targeting your application for Windows](https://msdn.microsoft.com/library/windows/desktop/dn481241)) に関するページをご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left">ユーザー情報</td>
<td align="left">[<strong>Windows.System</strong>](https://msdn.microsoft.com/library/windows/apps/br241814) 名前空間の新しい API により、ユーザー名やアカウントの画像など、ユーザーに関する情報にアクセスしやすくなりました。 ログインやログアウトなどのユーザー イベントに応答する機能も提供されます。</td>
</tr>
<tr class="even">
<td align="left">メモリ管理とプロファイリング</td>
<td align="left">[<strong>Windows.System</strong>](https://msdn.microsoft.com/library/windows/apps/br241814) のメモリ プロファイリング API のサポートがすべてのプラットフォームに拡張され、その全体的な機能が、新しいクラスと関数で強化されました。</td>
</tr>
</tbody>
</table>

 

## 記憶域


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Windows Phone で利用可能なファイル検索 API</td>
<td align="left"><p>アプリの発行者は、アプリ マニフェストに拡張機能を追加し、アプリを登録して、発行する他のアプリとストレージ フォルダーを共有できます。 共有ストレージの場所を取得するには、[<strong>Windows.Storage.ApplicationData.GetPublisherCacheFolder</strong>](https://msdn.microsoft.com/library/windows/apps/dn889607) メソッドを呼び出します。</p>
<p>Windows ランタイム アプリの強力なセキュリティ モデルでは、一般的にアプリ間でのデータ共有はできません。 しかし、同じ発行元のアプリ間では、ユーザー単位でファイルと設定を共有すると便利な場合があります。</p></td>
</tr>
</tbody>
</table>

 

## ツール


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Visual Studio のライブ ビジュアル ツリー機能</td>
<td align="left">Visual Studio に、新しいライブ ビジュアル ツリー機能が搭載されました。 デバッグの際にこの機能を使うことで、アプリのビジュアル ツリーの状態をすばやく把握し、要素のプロパティの設定を検出することができます。 また、この機能を利用するとアプリの実行中にプロパティ値を変更できるため、アプリを再起動せずに調整したり、さまざまな設定を試したりできます。</td>
</tr>
<tr class="even">
<td align="left">トレース ログ</td>
<td align="left"><p>[TraceLogging](https://msdn.microsoft.com/library/windows/desktop/dn904636) は、ユーザー モード アプリとカーネル モード ドライバー用の新しいイベント トレース API です。[Event Tracing for Windows](https://msdn.microsoft.com/library/windows/desktop/bb968803) (ETW) を基に構築されています。 この API は、インストルメンテーション マニフェストの XML ファイルを別に用意する必要なく、コードを実装して構造化データをイベントに含めるためのシンプルな方法を提供します。</p>
<p>対象となるさまざまな開発者に対応するために、WinRT、.NET、C/C++ の TraceLogging API が用意されています。</p></td>
</tr>
</tbody>
</table>

 

## ユーザー エクスペリエンス


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">音声認識</td>
<td align="left">長時間ディクテーション シナリオ向けの継続的な音声認識が、ユニバーサル Windows プラットフォームでサポートされるようになりました。 継続的なディクテーションを有効にする方法については、音声操作に関するドキュメントをご覧ください。</td>
</tr>
<tr class="even">
<td align="left">さまざまなアプリケーション プラットフォーム間でのドラッグ アンド ドロップ機能</td>
<td align="left"><p>新しい [<strong>Windows.ApplicationModel.DataTransfer.DragDrop</strong>](https://msdn.microsoft.com/library/windows/apps/dn894216) 名前空間により、ユニバーサル Windows アプリでドラッグ アンド ドロップ機能が追加されました。 かつてデスクトップ プログラムの一般的なドラッグ アンド ドロップ シナリオ (フォルダーから Outlook のメール メッセージにドキュメントをドラッグして添付するなど) は、ユニバーサル Windows アプリでは不可能でした。 これらの新しい API をアプリで使うことで、ユーザーはさまざまなユニバーサル Windows アプリとデスクトップの間でデータを簡単に移動できます。</p>
<p>アプリ間でのドラッグ アンド ドロップをサポートするために、次の新しい API が XAML に追加されました。</p>
<ul>
<li>[<strong>ListViewBase.DragItemsCompleted</strong>](https://msdn.microsoft.com/library/windows/apps/dn831959)</li>
<li>[<strong>UIElement</strong>](https://msdn.microsoft.com/library/windows/apps/br208911): [<strong>CanDrag</strong>](https://msdn.microsoft.com/library/windows/apps/dn903558)、[<strong>DragStarting</strong>](https://msdn.microsoft.com/library/windows/apps/dn903560)、[<strong>StartDragAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn903562)、[<strong>DropCompleted</strong>](https://msdn.microsoft.com/library/windows/apps/dn903561)</li>
<li>[<strong>DragOperationDeferral</strong>](https://msdn.microsoft.com/library/windows/apps/dn831917)、[<strong>DragUI</strong>](https://msdn.microsoft.com/library/windows/apps/dn985714)、[<strong>DragUIOverride</strong>](https://msdn.microsoft.com/library/windows/apps/dn985715)</li>
<li>[<strong>DragEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/br242372): [<strong>AcceptedOperation</strong>](https://msdn.microsoft.com/library/windows/apps/dn831912)、[<strong>DataView</strong>](https://msdn.microsoft.com/library/windows/apps/dn831913)、[<strong>DragUIOverride</strong>](https://msdn.microsoft.com/library/windows/apps/dn985710)、[<strong>GetDeferral</strong>](https://msdn.microsoft.com/library/windows/apps/dn831914)、[<strong>Modifiers</strong>](https://msdn.microsoft.com/library/windows/apps/dn831915)</li>
<li>[<strong>DragItemsCompletedEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/dn831953)、[<strong>DropCompletedEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/dn903549)、[<strong>DragStartingEventArgs</strong>](https://msdn.microsoft.com/library/windows/apps/dn903540)</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">カスタム ウィンドウ タイトル バー</td>
<td align="left">デスクトップ デバイス ファミリの UWP アプリで、[<strong>ApplicationViewTitleBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn906115) クラスと、[<strong>ApplicationView.TitleBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn906131) プロパティおよび [<strong>Window.SetTitleBar</strong>](https://msdn.microsoft.com/library/windows/apps/dn965560) メソッドを組み合わせることで、タイトル バーの既定のコンテンツを独自のカスタム XAML コンテンツに置き換えることができるようになりました。 カスタム XAML はシステム クロムとして扱われるため、入力イベントはアプリではなく Windows によって処理されます。 そのため、カスタム タイトル バーのコンテンツをクリックした場合でも、ユーザーはウィンドウをドラッグしたり、サイズを変更したりできます。</td>
</tr>
</tbody>
</table>

 

## Web


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Internet Explorer</td>
<td align="left"><p>Internet Explorer にエッジ モードが導入されました。エッジ モードは、他の最新のブラウザーや現代的な Web コンテンツとの相互運用性を最大限に高めることを目的とした、新しい「生きた」ドキュメント モードです。 試験的なこのモードは、ランダムに選ばれた Windows 10 ユーザーに対して段階的に提供されます。 エッジ モードは、IE の新しい <strong>about:flags</strong> メカニズムを通じて手動で有効または無効にすることができます。 詳しくは、次をご覧ください。</p>
<ul>
<li>「[Living on the Edge – our next step in helping the web just work](http://blogs.msdn.com/b/ie/archive/2014/11/11/living-on-the-edge-our-next-step-in-interoperability.aspx)」</li>
<li>「[The Internet Explorer for Windows 10 Developer Guide](https://dev.windows.com/microsoft-edge/)」</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">WebView Edge モード ブラウズ</td>
<td align="left">[<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) コントロールは、新しい Edge ブラウザーと同じレンダリング エンジンを使います。 これにより、最も正確な、HTML 規格に準拠したモードでレンダリングを実行することができます。</td>
</tr>
<tr class="odd">
<td align="left">オフ スレッド WebView</td>
<td align="left">[<strong>WebView.ExecutionMode</strong>](https://msdn.microsoft.com/library/windows/apps/dn932034) を指定することで、Web コンテンツの処理と表示を別々のバック グラウンド スレッドで実行できます。 これにより、特定のシナリオでパフォーマンスを改善することができます。</td>
</tr>
<tr class="even">
<td align="left">WebView.UnsupportedUriSchemeIdentified イベント</td>
<td align="left"><p>新しい [<strong>WebView.UnsupportedUriSchemeIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn974400) イベントにより、アプリでのサポートされない URI スキームの処理方法を指定することができます。 このイベントを処理することで、サポートされない URI スキームのカスタム処理をアプリで実行できます。</p>
<p>HTML WebView コントロールについては、[<strong>MSWebViewUnsupportedUriSchemeIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn803906.aspx) イベントに関するページをご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left">WebView.NewWindowRequested イベント</td>
<td align="left"><p>新しい [<strong>WebView.NewWindowRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn974397) イベントにより、WebView のスクリプトで新しいブラウザー ウィンドウが要求されたときに応答することができます。</p>
<p>HTML WebView コントロールについては、[<strong>MSWebViewNewWindowRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn806030) イベントに関するページをご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left">WebView.PermissionRequested イベント</td>
<td align="left"><p>新しい [<strong>WebView.PermissionRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn974398) イベントにより、位置情報といった、ユーザーの特別許可が必要な、リッチで新しい HTML5 API を WebView コンテンツで利用できるようになりました。</p>
<p>HTML WebView コントロールについては、[<strong>MSWebViewPermissionRequested</strong>](https://msdn.microsoft.com/library/windows/apps/dn806030.aspx) イベントに関するページをご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left">WebView.UnviewableContentIdentified イベント</td>
<td align="left"><p>新しい [<strong>WebView.UnviewableContentIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn299351) イベントにより、[<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) が PDF ファイルや Office ドキュメントなどの Web 以外のコンテンツに移動したときに応答することができます。</p>
<p>HTML WebView コントロールについては、[<strong>MSWebViewUnviewableContentIdentified</strong>](https://msdn.microsoft.com/library/windows/apps/dn609716) イベントに関するページをご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left">WebView.AddWebAllowedObject メソッド</td>
<td align="left"><p>新しい [<strong>WebView.AddWebAllowedObject</strong>](https://msdn.microsoft.com/library/windows/apps/dn903993) メソッドを呼び出すと、XAML の [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) に WinRT オブジェクトを挿入し、その <strong>WebView</strong> でホストされている信頼できる JavaScript から関数を呼び出すことができます。 たとえば、親アプリが [<strong>ToastNotificationManager</strong>](https://msdn.microsoft.com/library/windows/apps/br208642) WinRT API を呼び出すことを要求することで、Web コンテンツでシステム通知を表示することができます。</p>
<p>HTML [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) コントロールについては、[<strong>addWebAllowedObject</strong>](https://msdn.microsoft.com/library/windows/apps/dn926632) メソッドに関するページをご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left">WebView.ClearTemporaryWebDataAync メソッド</td>
<td align="left">ユーザーが XAML [<strong>WebView</strong>](https://msdn.microsoft.com/library/windows/apps/br227702) で Web コンテンツを操作すると、ユーザーのセッションに基づき <strong>WebView</strong> コントロールがデータをキャッシュします。 新しい [<strong>ClearTemporaryWebDataAsync</strong>](https://msdn.microsoft.com/library/windows/apps/dn974394) メソッドを呼び出すと、このキャッシュを消去できます。 たとえば、あるユーザーがアプリからログアウトしたときにキャッシュを消去して、別のユーザーが前のセッションのデータにアクセスできないようにすることができます。</td>
</tr>
</tbody>
</table>



<!--HONumber=Mar16_HO5-->


