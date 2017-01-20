---
author: Jwmsft
Description: "基本的な 2 ページのピア ツー ピア ユニバーサル Windows プラットフォーム (UWP) アプリでのナビゲーションの方法について説明します。"
title: "2 ページ間でのピア ツー ピアのナビゲーション"
ms.assetid: 0A364C8B-715F-4407-9426-92267E8FB525
label: Peer-to-peer navigation between two pages
template: detail.hbs
op-migration-status: ready
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: 324bdcd8ae61826a2be765f6a6a93441036d6984

---

# <a name="peer-to-peer-navigation-between-two-pages"></a>2 ページ間でのピア ツー ピアのナビゲーション

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

基本的な 2 ページのピア ツー ピア ユニバーサル Windows プラットフォーム (UWP) アプリでのナビゲーションの方法について説明します。

![2 ページのピア ツー ピアのナビゲーションの例](images/nav-peertopeer-2page.png)

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**Windows.UI.Xaml.Controls.Frame**](https://msdn.microsoft.com/library/windows/apps/br242682)</li>
<li>[**Windows.UI.Xaml.Controls.Page**](https://msdn.microsoft.com/library/windows/apps/br227503)</li>
<li>[**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300)</li>
</ul>
</div>



## <a name="create-the-blank-app"></a>空のアプリの作成


1.  Microsoft Visual Studio の **[ファイル] メニューで、[新しいプロジェクト]** をクリックします。
2.  **[新しいプロジェクト]** ダイアログ ボックスの左側のウィンドウで、**[Visual C#]、[Windows]、[ユニバーサル]** ノードまたは **[Visual C++]、[Windows]、[ユニバーサル]** ノードの順にクリックします。
3.  中央のウィンドウで、**[空のアプリケーション]** をクリックします。
4.  **[名前]** ボックスに「**NavApp1**」と入力し、**[OK]** をクリックします。

    ソリューションが作られ、プロジェクト ファイルが**ソリューション エクスプローラー**に表示されます。

5.  プログラムを実行するには、メニューで **[デバッグ]** をクリックして **[デバッグの開始]** をクリックするか、F5 キーを押します。

    空白のページが表示されます。

6.  デバッグを終了して Visual Studio に戻るには、Shift キーを押しながら F5 キーを押します。

## <a name="add-basic-pages"></a>基本ページの追加

次に、プロジェクトにコンテンツ ページを 2 つ追加します。

次の手順を 2 回実行して、ナビゲーションを行う 2 つのページを追加します。

1.  **ソリューション エクスプローラー**で、**[BlankApp]** プロジェクト ノードを右クリックして、ショートカット メニューを開きます。
2.  ショートカット メニューで **[追加]**、**[新しい項目]** の順にクリックします。
3.  **[新しい項目の追加]** ダイアログ ボックスの中央のウィンドウで、**[空白のページ]** をクリックします。
4.  **[名前]** ボックスに「**Page1**」(または「**Page2**」) と入力し、**[追加]** をクリックします。

NavApp1 プロジェクトの一部としてこれらのファイルが表示されます。

<table>
<thead>
<tr class="header">
<th align="left">C#</th>
<th align="left">C++</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><ul>
<li>Page1.xaml</li>
<li>Page1.xaml.cs</li>
<li>Page2.xaml</li>
<li>Page2.xaml.cs</li>
</ul></td>
<td style="vertical-align:top;"><ul>
<li>Page1.xaml</li>
<li>Page1.xaml.cpp</li>
<li>Page1.xaml.h</li>
<li>Page2.xaml</li>
<li>Page2.xaml.cpp</li>
<li>Page2.xaml.h

</li>
</ul></td>
</tr>
</tbody>
</table>

 

Page1.xaml の UI に次のコンテンツを追加します。

-   `pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。 [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティを `Page 1` に変更します。

```xaml
<TextBlock x:Name="pageTitle" Text="Page 1" />
```

-   次の [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として、`pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素の後に追加します。

    
```xaml
<HyperlinkButton Content="Click to go to page 2"
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

前に追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを Page1.xaml 分離コード ファイルの `Page1` クラスに追加します。 ここで、Page2.xaml に移動します。

> [!div class="tabbedCodeSnippets"]
```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2));
}
```
```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid));
}
```

Page2.xaml の UI を次のように変更します。

-   `pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。 [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティの値を `Page 2` に変更します。

```xaml
<TextBlock x:Name="pageTitle" Text="Page 2" />
```

-   次の [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として、`pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素の後に追加します。

```xaml
<HyperlinkButton Content="Click to go to page 1" 
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

前に追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを Page2.xaml 分離コード ファイルの `Page2` クラスに追加します。 ここで、Page1.xaml に移動します。

> [!NOTE]
> C++ プロジェクトの場合は、別のページを参照する各ページのヘッダー ファイルに `#include` ディレクティブを追加する必要があります。 ここで示したページ間のナビゲーションの例では、page1.xaml.h ファイルに `#include "Page2.xaml.h"` が、page2.xaml.h に `#include "Page1.xaml.h"` が含まれています。

> [!div class="tabbedCodeSnippets"]
```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page1));
}
```
```cpp
void Page2::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid));
}
```

コンテンツ ページが用意できたら、Page1.xaml をアプリの開始時に表示されるように設定する必要があります。

app.xaml 分離コードファイルを開き、`OnLaunched` ハンドラーを変更します。

次に、[**Frame.Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) の呼び出しに、`MainPage` ではなく `Page1` を追加します。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> protected override void OnLaunched(LaunchActivatedEventArgs e)
> {
>     Frame rootFrame = Window.Current.Content as Frame;
> 
>     // Do not repeat app initialization when the Window already has content,
>     // just ensure that the window is active
>     if (rootFrame == null)
>     {
>         // Create a Frame to act as the navigation context and navigate to the first page
>         rootFrame = new Frame();
> 
>         rootFrame.NavigationFailed += OnNavigationFailed;
> 
>         if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
>         {
>             //TODO: Load state from previously suspended application
>         }
> 
>         // Place the frame in the current Window
>         Window.Current.Content = rootFrame;
>     }
> 
>     if (rootFrame.Content == null)
>     {
>         // When the navigation stack isn&#39;t restored navigate to the first page,
>         // configuring the new page by passing required information as a navigation
>         // parameter
>         rootFrame.Navigate(typeof(Page1), e.Arguments);
>     }
>     // Ensure the current window is active
>     Window.Current.Activate();
> }
> ```
> ```cpp
> void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e)
> {
>     auto rootFrame = dynamic_cast<Frame^>(Window::Current->Content);
> 
>     // Do not repeat app initialization when the Window already has content,
>     // just ensure that the window is active
>     if (rootFrame == nullptr)
>     {
>         // Create a Frame to act as the navigation context and associate it with
>         // a SuspensionManager key
>         rootFrame = ref new Frame();
> 
>         rootFrame->NavigationFailed += 
>             ref new Windows::UI::Xaml::Navigation::NavigationFailedEventHandler(
>                 this, &amp;App::OnNavigationFailed);
> 
>         if (e->PreviousExecutionState == ApplicationExecutionState::Terminated)
>         {
>             // TODO: Load state from previously suspended application
>         }
>         
>         // Place the frame in the current Window
>         Window::Current->Content = rootFrame;
>     }
> 
>     if (rootFrame->Content == nullptr)
>     {
>         // When the navigation stack isn&#39;t restored navigate to the first page,
>         // configuring the new page by passing required information as a navigation
>         // parameter
>         rootFrame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid), e->Arguments);
>     }
> 
>     // Ensure the current window is active
>     Window::Current->Activate();
> }
> ```

**注:** このコードは、アプリの初期ウィンドウ フレームへのナビゲーションが失敗した場合に、[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) の戻り値を使ってアプリの例外をスローします。 **Navigate** が **true** を返す場合は、ナビゲーションが行われます。

次に、アプリをビルドして実行します。 "Click to go to page 2" と書かれているリンクをクリックします。 上部に "Page 2" と書かれた 2 番目のページが読み込まれ、フレームに表示される必要があります。

## <a name="frame-and-page-classes"></a>Frame クラスと Page クラス

アプリにさらに機能を加える前に、追加したページに用意されているアプリのナビゲーション サポートについて見てみましょう。

まず、App.xaml 分離コード ファイルの `App.OnLaunched` メソッドで、アプリの [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) (`rootFrame`) が作成されます。 [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) メソッドを使って、この **Frame** にコンテンツが表示されます。

**注:**  
[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラスは、[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694)、[**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568)、[**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693) などのさまざまなナビゲーション メソッドと、[**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543)、[**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547)、[**BackStackDepth**](https://msdn.microsoft.com/library/windows/apps/hh967995) などのプロパティをサポートしています。

 
この例では、`Page1` が [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) メソッドに渡されます。 このメソッドは、アプリの現在のウィンドウの内容を [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) に設定し、指定したページの内容を **Frame** に読み込みます (この例では Page1.xaml、既定では MainPage.xaml)。

`Page1`  は [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラスのサブクラスです。 **Page** クラスには、**Page** が含まれる [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) を取得する読み取り専用の [**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) プロパティがあります。 [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベント ハンドラーが ` Frame.Navigate(typeof(Page2))` を呼び出すと、アプリのウィンドウ内の **Frame** に Page2.xaml のコンテンツが表示されます。

フレームにページが読み込まれるたびに、そのページが [**PageStackEntry**](https://msdn.microsoft.com/library/windows/apps/dn298572) として、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) の [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543) または [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547) に追加されます。

## <a name="pass-information-between-pages"></a>ページ間での情報の受け渡し

このアプリでは、ページ間の移動は行いますが、実際に何かの処理を行うわけではありません。 多くの場合、アプリに複数のページがあれば、ページ間で情報を共有する必要があります。 最初のページから 2 番目のページへ情報を渡してみましょう。

Page1.xaml で、前に追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) を次の [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) に置き換えます。

次に、テキスト文字列を入力するための [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) ラベルと [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (`name`) を追加します。

```xaml
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Text="Enter your name"/>
    <TextBox HorizontalAlignment="Center" Width="200" Name="name"/>
    <HyperlinkButton Content="Click to go to page 2" 
                     Click="HyperlinkButton_Click"
                     HorizontalAlignment="Center"/>
</StackPanel>
```

Page1.xaml 分離コード ファイルの `HyperlinkButton_Click` イベント ハンドラーで、`name` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) の `Text` プロパティを参照するパラメーターを `Navigate` メソッドに追加します。

> [!div class="tabbedCodeSnippets"]
```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2), name.Text);
}
```
```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid), name->Text);
}
```

Page2.xaml 分離コード ファイルで、`OnNavigatedTo` メソッドを次のようにオーバーライドします。

> [!div class="tabbedCodeSnippets"]
```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if (e.Parameter is string)
    {
        greeting.Text = "Hi, " + e.Parameter.ToString();
    }
    else
    {
        greeting.Text = "Hi!";
    }
    base.OnNavigatedTo(e);
}
```
```cpp
void Page2::OnNavigatedTo(NavigationEventArgs^ e)
{
    if (dynamic_cast<Platform::String^>(e->Parameter) != nullptr)
    {
        greeting->Text = "Hi," + e->Parameter->ToString();
    }
    else
    {
        greeting->Text = "Hi!";
    }
    ::Windows::UI::Xaml::Controls::Page::OnNavigatedTo(e);
}
```

アプリを実行し、テキスト ボックスに自分の名前を入力し、**[Click to go to page 2]** と書かれているリンクをクリックします。 [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントで `this.Frame.Navigate(typeof(Page2), tb1.Text)` を呼び出したときに、`name.Text` プロパティが `Page2` に渡され、イベント データの値がページに表示されるメッセージに使用されます。

## <a name="cache-a-page"></a>ページのキャッシュ

ページのコンテンツと状態は既定ではキャッシュされないため、アプリの各ページで有効にする必要があります。

この基本的なピア ツー ピアの例では、戻るボタンはありませんが (戻るナビゲーションは「[[戻る] ボタンによるナビゲーション](navigation-history-and-backwards-navigation.md)」で示しました)、`Page2` で戻るボタンをクリックした場合、`Page1` の [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) (およびその他のすべてのフィールド) は既定の状態に設定されます。 これを回避する方法の 1 つは、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) プロパティを使って、ページがフレームのページ キャッシュに追加されるように指定することです。

`Page1` のコンストラクターで、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) を [**Enabled**](https://msdn.microsoft.com/library/windows/apps/br243284) に設定します。 これにより、フレームのページ キャッシュを超えるまで、ページのすべてのコンテンツや状態値が保持されます。

フレームのキャッシュ サイズの制限を無視する場合は、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) を [**Required**](https://msdn.microsoft.com/library/windows/apps/br243284) に設定します。 ただし、キャッシュ サイズの制限は、デバイスのメモリの制限に依存しており、重要である可能性があります。

> [!NOTE]
> [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) プロパティは、フレームにキャッシュできる、ナビゲーション履歴内のページ数を指定します。

> [!div class="tabbedCodeSnippets"]
```csharp
public Page1()
{
    this.InitializeComponent();
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```
```cpp
Page1::Page1()
{
    this->InitializeComponent();
    this->NavigationCacheMode = Windows::UI::Xaml::Navigation::NavigationCacheMode::Enabled;
}
```

## <a name="related-articles"></a>関連記事

* [UWP アプリのナビゲーション デザインの基本](https://msdn.microsoft.com/library/windows/apps/dn958438)
* [タブとピボットのガイドライン](https://msdn.microsoft.com/library/windows/apps/dn997788)
* [ナビゲーション ウィンドウのガイドライン](https://msdn.microsoft.com/library/windows/apps/dn997766)
 

 







<!--HONumber=Dec16_HO2-->


