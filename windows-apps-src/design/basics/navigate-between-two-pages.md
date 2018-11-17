---
author: Jwmsft
Description: Learn how to enable peer-to-peer navigation between two basic pages in an Universal Windows Platform (UWP) app.
title: 2 ページ間でのピア ツー ピアのナビゲーション
ms.assetid: 0A364C8B-715F-4407-9426-92267E8FB525
label: Peer-to-peer navigation between two pages
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 07/13/2018
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 91a1ca0ee99833280aaa41ca4d9c94d043a78e0a
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7152221"
---
# <a name="implement-navigation-between-two-pages"></a>2 ページ間でのナビゲーションを実装する

フレームおよびページを使用した、アプリでの基本的なピア ツー ピアのナビゲーションについて説明します。 

> **重要な APIs**: [**Windows.UI.Xaml.Controls.Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラス、[**Windows.UI.Xaml.Controls.Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラス、[**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300) 名前空間

![ピア ツー ピアのナビゲーション](images/peertopeer.png)

## <a name="1-create-a-blank-app"></a>1. 空のアプリの作成

1.  Microsoft Visual Studio のメニューで、**[ファイル]** > **[新しいプロジェクト]** の順にクリックします。
2.  **[新しいプロジェクト]** ダイアログ ボックスの左側のウィンドウで、**[Visual C#]** > **[Windows]** > **[ユニバーサル]** ノード、または **[Visual C++]** > **[Windows]** > **[ユニバーサル]** ノードの順にクリックします。
3.  中央のウィンドウで、**[空のアプリケーション]** をクリックします。
4.  **[名前]** ボックスに「**NavApp1**」と入力し、**[OK]** をクリックします。
    ソリューションが作られ、プロジェクト ファイルが**ソリューション エクスプローラー**に表示されます。
5.  プログラムを実行するには、メニューから **[デバッグ]** > **[デバッグの開始]** の順にクリックするか、F5 キーを押します。
    空白のページが表示されます。
6.  デバッグを終了して Visual Studio に戻るには、アプリを終了するか、メニューから **[デバッグの停止]** クリックします。

## <a name="2-add-basic-pages"></a>2. 基本ページの追加

次に、プロジェクトにページを 2 つ追加します。

1.  **ソリューション エクスプローラー**で、**[BlankApp]** プロジェクト ノードを右クリックして、ショートカット メニューを開きます。
2.  ショートカット メニューから **[追加]** > **[新しい項目]** の順にクリックします。
3.  **[新しい項目の追加]** ダイアログ ボックスの中央のウィンドウで、**[空白のページ]** をクリックします。
4.  **[名前]** ボックスに「**Page1**」(または「**Page2**」) と入力し、**[追加]** をクリックします。
5. 手順 1 ～ 4 を繰り返して、2 つ目のページを追加します。

これで、NavApp1 プロジェクトの一部としてこれらのファイルが表示されます。

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

Page1.xaml に次のコンテンツを追加します。

-   `pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。 [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティを `Page 1` に変更します。
```xaml
<TextBlock x:Name="pageTitle" Text="Page 1" />
```

-   [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739)要素をルート[**グリッド**](https://msdn.microsoft.com/library/windows/apps/br242704)の前後の子要素として、 `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652)要素です。
```xaml
<HyperlinkButton Content="Click to go to page 2"
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

Page1.xaml 分離コード ファイルに、Page2.xaml に移動するために追加した [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを追加します。

```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2));
}
```

```cppwinrt
void Page1::HyperlinkButton_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args)
{
    Frame().Navigate(winrt::xaml_typename<NavApp1::Page2>());
}
```

```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid));
}
```

Page2.xaml に次のコンテンツを追加します。

-   `pageTitle` という名前を付けた [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の子要素として追加します。 [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティの値を `Page 2` に変更します。
```xaml
<TextBlock x:Name="pageTitle" Text="Page 2" />
```

-   [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739)要素をルート[**グリッド**](https://msdn.microsoft.com/library/windows/apps/br242704)の前後の子要素として、 `pageTitle` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652)要素です。
```xaml
<HyperlinkButton Content="Click to go to page 1" 
                 Click="HyperlinkButton_Click"
                 HorizontalAlignment="Center"/>
```

Page2.xaml 分離コード ファイルに、Page1.xaml に移動するための [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739) の `Click` イベントを処理する次のコードを追加します。

```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page1));
}
```

```cppwinrt
void Page2::HyperlinkButton_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args)
{
    Frame().Navigate(winrt::xaml_typename<NavApp1::Page1>());
}
```

```cpp
void Page2::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid));
}
```

> [!NOTE]
> C++ プロジェクトの場合は、別のページを参照する各ページのヘッダー ファイルに `#include` ディレクティブを追加する必要があります。 ここで示したページ間のナビゲーションの例では、page1.xaml.h ファイルに `#include "Page2.xaml.h"` が、page2.xaml.h に `#include "Page1.xaml.h"` が含まれています。

ページが用意できたら、Page1.xaml をアプリの開始時に表示されるように設定する必要があります。

App.xaml 分離コードファイルを開き、`OnLaunched` ハンドラーを変更します。

次に、[**Frame.Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) の呼び出しに、`MainPage` ではなく `Page1` を追加します。

```csharp
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;
 
    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == null)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();
        rootFrame.NavigationFailed += OnNavigationFailed;
 
        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
            //TODO: Load state from previously suspended application
        }
 
        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
    }
 
    if (rootFrame.Content == null)
    {
        // When the navigation stack isn't restored navigate to the first page,
        // configuring the new page by passing required information as a navigation
        // parameter
        rootFrame.Navigate(typeof(Page1), e.Arguments);
    }
    // Ensure the current window is active
    Window.Current.Activate();
}
```

```cppwinrt
void App::OnLaunched(LaunchActivatedEventArgs const& e)
{
    Frame rootFrame{ nullptr };
    auto content = Window::Current().Content();
    if (content)
    {
        rootFrame = content.try_as<Frame>();
    }

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == nullptr)
    {
        // Create a Frame to act as the navigation context and associate it with
        // a SuspensionManager key
        rootFrame = Frame();

        rootFrame.NavigationFailed({ this, &App::OnNavigationFailed });

        if (e.PreviousExecutionState() == ApplicationExecutionState::Terminated)
        {
            // Restore the saved session state only when appropriate, scheduling the
            // final launch steps after the restore is complete
        }

        if (e.PrelaunchActivated() == false)
        {
            if (rootFrame.Content() == nullptr)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(xaml_typename<NavApp1::Page1>(), box_value(e.Arguments()));
            }
            // Place the frame in the current Window
            Window::Current().Content(rootFrame);
            // Ensure the current window is active
            Window::Current().Activate();
        }
    }
    else
    {
        if (e.PrelaunchActivated() == false)
        {
            if (rootFrame.Content() == nullptr)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(xaml_typename<NavApp1::Page1>(), box_value(e.Arguments()));
            }
            // Ensure the current window is active
            Window::Current().Activate();
        }
    }
}
```

```cpp
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e)
{
    auto rootFrame = dynamic_cast<Frame^>(Window::Current->Content);

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active
    if (rootFrame == nullptr)
    {
        // Create a Frame to act as the navigation context and associate it with
        // a SuspensionManager key
        rootFrame = ref new Frame();

        rootFrame->NavigationFailed += 
            ref new Windows::UI::Xaml::Navigation::NavigationFailedEventHandler(
                this, &App::OnNavigationFailed);

        if (e->PreviousExecutionState == ApplicationExecutionState::Terminated)
        {
            // TODO: Load state from previously suspended application
        }
        
        // Place the frame in the current Window
        Window::Current->Content = rootFrame;
    }

    if (rootFrame->Content == nullptr)
    {
        // When the navigation stack isn't restored navigate to the first page,
        // configuring the new page by passing required information as a navigation
        // parameter
        rootFrame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page1::typeid), e->Arguments);
    }

    // Ensure the current window is active
    Window::Current->Activate();
}
```

> [!NOTE]
> このコードは、アプリの初期ウィンドウ フレームへのナビゲーションが失敗した場合にアプリの例外をスローするのに[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694)の戻り値を使用します。 **Navigate** が **true** を返す場合は、ナビゲーションが行われます。

次に、アプリをビルドして実行します。 "Click to go to page 2" と書かれているリンクをクリックします。 上部に "Page 2" と書かれた 2 番目のページが読み込まれ、フレームに表示される必要があります。

### <a name="about-the-frame-and-page-classes"></a>Frame クラスと Page クラスについて

アプリにさらに機能を加える前に、追加したページに用意されているアプリ内のナビゲーションについて見てみましょう。

まず、App.xaml 分離コード ファイルの `App.OnLaunched` メソッドで、アプリの [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) (`rootFrame`) が作成されます。 **Frame** クラスは、[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694)、[**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568)、[**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693) などのさまざまなナビゲーション メソッドと、[**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543)、[**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547)、[**BackStackDepth**](https://msdn.microsoft.com/library/windows/apps/hh967995) などのプロパティをサポートしています。
 
[**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) メソッドを使って、この **Frame** にコンテンツが表示されます。 既定では、このメソッドは MainPage.xaml を読み込みます。 この例では、`Page1` が **Navigate** メソッドに渡されるため、メソッドは **Frame** に `Page1` を読み込みます。 

`Page1`  は [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラスのサブクラスです。 **Page** クラスには、**Page** が含まれる **Frame** を取得する読み取り専用の **Frame** プロパティがあります。 `Page1` で **HyperlinkButton** の **Click** イベント ハンドラーが `this.Frame.Navigate(typeof(Page2))` を呼び出すと、**Frame** に Page2.xaml のコンテンツが表示されます。

最後に、フレームにページが読み込まれるたびに、そのページが [**PageStackEntry**](https://msdn.microsoft.com/library/windows/apps/dn298572) として、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br227504) の [**BackStack**](https://msdn.microsoft.com/library/windows/apps/dn279543) または [**ForwardStack**](https://msdn.microsoft.com/library/windows/apps/dn279547) に追加され、[履歴と前に戻る移動](navigation-history-and-backwards-navigation.md)が可能になります。

## <a name="3-pass-information-between-pages"></a>3. ページ間での情報の受け渡し

このアプリでは、ページ間の移動は行いますが、実際に何かの処理を行うわけではありません。 多くの場合、アプリに複数のページがあれば、ページ間で情報を共有する必要があります。 最初のページから 2 番目のページへ情報を渡してみましょう。

Page1.xaml、追加した**HyperlinkButton**を次[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635)で以前置き換えます。

次に、テキスト文字列を入力するための [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) ラベルと [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) `name` を追加します。

```xaml
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Text="Enter your name"/>
    <TextBox HorizontalAlignment="Center" Width="200" Name="name"/>
    <HyperlinkButton Content="Click to go to page 2" 
                     Click="HyperlinkButton_Click"
                     HorizontalAlignment="Center"/>
</StackPanel>
```

Page1.xaml 分離コード ファイルの `HyperlinkButton_Click` イベント ハンドラーで、`name`**TextBox** の `Text` プロパティを参照するパラメーターを `Navigate` メソッドに追加します。

```csharp
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
{
    this.Frame.Navigate(typeof(Page2), name.Text);
}
```

```cppwinrt
void Page1::HyperlinkButton_Click(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args)
{
    Frame().Navigate(winrt::xaml_typename<NavApp1::Page2>(), winrt::box_value(name().Text()));
}
```

```cpp
void Page1::HyperlinkButton_Click(Platform::Object^ sender, RoutedEventArgs^ e)
{
    this->Frame->Navigate(Windows::UI::Xaml::Interop::TypeName(Page2::typeid), name->Text);
}
```

Page2.xaml で、前に追加した **HyperlinkButton** を次の **StackPanel** に置き換えます。

次に、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) を追加して、Page1 から渡された文字列を表示します。

```xaml
<StackPanel>
    <TextBlock HorizontalAlignment="Center" Name="greeting"/>
    <HyperlinkButton Content="Click to go to page 1" 
                     Click="HyperlinkButton_Click"
                     HorizontalAlignment="Center"/>
</StackPanel>
```

Page2.xaml 分離コード ファイルで、次のコードを追加して `OnNavigatedTo` メソッドをオーバーライドします。

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
    {
        greeting.Text = $"Hi, {e.Parameter.ToString()}";
    }
    else
    {
        greeting.Text = "Hi!";
    }
    base.OnNavigatedTo(e);
}
```

```cppwinrt
void Page2::OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs const& e)
{
    auto propertyValue{ e.Parameter().as<Windows::Foundation::IPropertyValue>() };
    if (propertyValue.Type() == Windows::Foundation::PropertyType::String)
    {
        greeting().Text(L"Hi, " + winrt::unbox_value<winrt::hstring>(e.Parameter()));
    }
    else
    {
        greeting().Text(L"Hi!");
    }
    __super::OnNavigatedTo(e);
}
```

```cpp
void Page2::OnNavigatedTo(NavigationEventArgs^ e)
{
    if (dynamic_cast<Platform::String^>(e->Parameter) != nullptr)
    {
        greeting->Text = "Hi, " + e->Parameter->ToString();
    }
    else
    {
        greeting->Text = "Hi!";
    }
    ::Windows::UI::Xaml::Controls::Page::OnNavigatedTo(e);
}
```

アプリを実行し、テキスト ボックスに自分の名前を入力し、**[Click to go to page 2]** と書かれているリンクをクリックします。 

`Page1` の **HyperlinkButton** の **Click** イベントで `this.Frame.Navigate(typeof(Page2), name.Text)` を呼び出すと、`name.Text` プロパティが `Page2` に渡され、イベント データの値がページに表示されるメッセージに使用されます。

## <a name="4-cache-a-page"></a>4. ページのキャッシュ

ページのコンテンツと状態は既定ではキャッシュされないため、情報をキャッシュする場合は、アプリの各ページでキャッシュを有効にする必要があります。

この基本的なピア ツー ピアの例では、戻るボタンはありませんが (戻るナビゲーションは「[前に戻る移動](navigation-history-and-backwards-navigation.md)」で示しました)、`Page2` で戻るボタンをクリックした場合、`Page1` の **TextBox** (およびその他のすべてのフィールド) は既定の状態に設定されます。 これを回避する方法の 1 つは、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) プロパティを使って、ページがフレームのページ キャッシュに追加されるように指定することです。 

`Page1` のコンストラクターで、**NavigationCacheMode** を **Enabled** に設定して、フレームのページ キャッシュを超えるまでページのすべてのコンテンツと状態の値を保持することができます。 [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) の制限を無視する場合は、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) を [**Required**](https://msdn.microsoft.com/library/windows/apps/br243284) に設定します。これで、フレームにキャッシュできる、ナビゲーション履歴内のページ数を指定します。 ただし、キャッシュ サイズの制限は、デバイスのメモリの制限に依存しており、重要である可能性があることに注意してください。

```csharp
public Page1()
{
    this.InitializeComponent();
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```

```cppwinrt
Page1::Page1()
{
    InitializeComponent();
    NavigationCacheMode(Windows::UI::Xaml::Navigation::NavigationCacheMode::Enabled);
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
