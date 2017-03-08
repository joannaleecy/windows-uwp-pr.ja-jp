---
author: Jwmsft
Description: "アプリの複数の独立した部分を別々のウィンドウで表示できるようにすることは、ユーザーが生産性を高めるために役立ちます。"
title: "アプリの複数のビューの表示"
ms.assetid: BAF9956F-FAAF-47FB-A7DB-8557D2548D88
label: Show multiple views for an app
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 011a6e50c22a1ef245a9be11e3a5d7f9e270d5bc
ms.lasthandoff: 02/07/2017

---

# <a name="show-multiple-views-for-an-app"></a>アプリの複数のビューの表示

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

アプリの複数の独立した部分を別々のウィンドウで表示できるようにすることは、ユーザーが生産性を高めるために役立ちます。 そのわかりやすい例が、メイン UI に電子メールの一覧と選んだ電子メールのプレビューが表示される電子メールアプリです。 しかし、ユーザーはメッセージを別々のウィンドウで開き、並べて表示します。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**ApplicationViewSwitcher**](https://msdn.microsoft.com/library/windows/apps/dn281094)</li>
<li>[**CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278)</li>
</ul>
</div> 

アプリの複数のウィンドウを作成すると、各ウィンドウは別々に動作します。 タスク バーには各ウィンドウが別々に表示されます。 ユーザーはアプリ ウィンドウの移動、サイズ変更、表示、非表示を個別に行うことができます。また、個別のアプリの場合と同じように各アプリ ウィンドウを切り替えることができます。 各ウィンドウは、独自のスレッドで動作します。

## <a name="what-is-a-view"></a>ビューとは


アプリのビューは、スレッドとウィンドウが 1:1 で対応したもので、アプリがコンテンツの表示に使います。 ビューは [**Windows.ApplicationModel.Core.CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) オブジェクトによって表現されます。

また、[**CoreApplication**](https://msdn.microsoft.com/library/windows/apps/br225016) オブジェクトによって管理されます。 [**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) を呼び出して、[**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) オブジェクトを作成できます。 **CoreApplicationView** は [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) と [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) ([**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br225019) プロパティと [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/dn433264) プロパティに格納) を関連付けます。 **CoreApplicationView** は、Windows ランタイムがコア Windows システムとのやり取りに使うオブジェクトとして考えることができます。

通常は [**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) を直接操作しません。 代わりに Windows ランタイムでは、[**ApplicationView**](https://msdn.microsoft.com/library/windows/apps/hh701658) クラスは [**Windows.UI.ViewManagement**](https://msdn.microsoft.com/library/windows/apps/br242295) 名前空間にあります。 このクラスには、アプリがウィンドウ システムとのやり取りに使うプロパティ、メソッド、イベントが用意されています。 **ApplicationView** を操作するには、静的メソッド [**ApplicationView.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh701672) を呼び出して、現在の **CoreApplicationView** のスレッドに関連付けられている **ApplicationView** インスタンスを取得します。

同様に、XAML フレーム ワークは [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトを [**Windows.UI.XAML.Window**](https://msdn.microsoft.com/library/windows/apps/br209041) オブジェクトにラップします。 XAML アプリでは通常、**CoreWindow** を直接操作しないで、**Window** オブジェクトを操作します。

## <a name="show-a-new-view"></a>新しいビューの表示


先に進む前に、新しいビューを作成する手順を見てみましょう。 ここでは、新しいビューがボタンのクリックに応じて起動されます。

```csharp
private async void Button_Click(object sender, RoutedEventArgs e)
{
    CoreApplicationView newView = CoreApplication.CreateNewView();
    int newViewId = 0;
    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        Frame frame = new Frame();
        frame.Navigate(typeof(SecondaryPage), null);   
        Window.Current.Content = frame;
        // You have to activate the window in order to show it later.
        Window.Current.Activate();

        newViewId = ApplicationView.GetForCurrentView().Id;
    });
    bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
}
```

**新しいビューを表示するには**

1.  [**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297291) を呼び出して、ビュー コンテンツに使う新しいウィンドウとスレッドを作成します。

    ```csharp
    CoreApplicationView newView = CoreApplication.CreateNewView();
    ```

2.  新しいビューの [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) を記録します。 これは後でビューの表示に使います。

    作成するビューの追跡に役立つ何らかのインフラストラクチャをアプリに構築することを検討することもできます。 例については、[MultipleViews サンプル](http://go.microsoft.com/fwlink/p/?LinkId=620574)の `ViewLifetimeControl` クラスをご覧ください。

    ```csharp
    int newViewId = 0;
    ```

3.  新しいスレッドで、ウィンドウにコンテンツを読み込みます。

    [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) メソッドを使って、UI スレッドでの新しいビューの操作をスケジュールします。 [ラムダ式](http://go.microsoft.com/fwlink/p/?LinkId=389615)を使って、**RunAsync** メソッドの引数として関数を渡します。 ラムダ関数による操作は新しいビューのスレッドで実行されます。

    XAML では通常、[**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) の [**Content**](https://msdn.microsoft.com/library/windows/apps/br209051) プロパティに [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) を追加した後、**Frame** から、アプリのコンテンツを定義した XAML [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) に移ります。 詳しくは、「[2 ページ間のピア ツー ピア ナビゲーション](navigate-between-two-pages.md)」をご覧ください。

    新しい [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) にコンテンツが読み込まれたら、後で **Window** を表示するには、**Window** の [**Activate**](https://msdn.microsoft.com/library/windows/apps/br209046) メソッドを呼び出す必要があります。 この操作は新しいビューのスレッドで実行されるため、新しい **Window** がアクティブになります。

    最後に、後でビューの表示に使う新しいビューの [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) を取得します。 やはり、この操作も新しいビューのスレッドで実行されるため、[**ApplicationView.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh701672) は新しいビューの **Id** を取得します。

    ```csharp
    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        Frame frame = new Frame();
        frame.Navigate(typeof(SecondaryPage), null);   
        Window.Current.Content = frame;
        // You have to activate the window in order to show it later.
        Window.Current.Activate();

        newViewId = ApplicationView.GetForCurrentView().Id;
    });
    ```

4.  [**ApplicationViewSwitcher.TryShowAsStandaloneAsync**](https://msdn.microsoft.com/library/windows/apps/dn281101) を呼び出して、新しいビューを表示します。

    新しいビューを作成したら、[**ApplicationViewSwitcher.TryShowAsStandaloneAsync**](https://msdn.microsoft.com/library/windows/apps/dn281101) メソッドを呼び出して、そのビューを新しいウィンドウに表示できます。 このメソッドの *viewId* パラメーターはアプリの各ビューを一意に識別する整数です。 ビュー [**Id**](https://msdn.microsoft.com/library/windows/apps/dn281120) は、**ApplicationView.Id** プロパティまたは [**ApplicationView.GetApplicationViewIdForWindow**](https://msdn.microsoft.com/library/windows/apps/dn281109) メソッドを使って取得できます。

    ```csharp
    bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
    ```

## <a name="the-main-view"></a>メイン ビュー


アプリの起動時に最初に作成されるビューは、*メイン ビュー*と呼ばれます。 このビューは、[**CoreApplication.MainView**](https://msdn.microsoft.com/library/windows/apps/hh700465) プロパティに格納され、その [**IsMain**](https://msdn.microsoft.com/library/windows/apps/hh700452) プロパティは true です。 このビューは作成しません。アプリによって作成されます。 メイン ビューのスレッドはアプリのマネージャーとして機能し、すべてのアプリの起動イベントはこのスレッドに振り分けられます。

セカンダリ ビューが開いている場合は、ウィンドウのタイトル バーの閉じるボタン (x) をクリックするなどして、メイン ビューのウィンドウを非表示にすることができます。ただし、そのスレッドはアクティブのままになります。 メイン ビューの [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) で [**Close**](https://msdn.microsoft.com/library/windows/apps/br209049) を呼び出すと、**InvalidOperationException** が発生します  ([**Application.Exit**](https://msdn.microsoft.com/library/windows/apps/br242327) を使ってアプリを閉じます)。メイン ビューのスレッドが終了した場合、アプリは終了します。

## <a name="secondary-views"></a>セカンダリ ビュー


アプリのコードで [**CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) を呼び出すことで作成するすべてのビューなど、その他のビューがセカンダリ ビューです。 メイン ビューとセカンダリ ビューの両方が [**CoreApplication.Views**](https://msdn.microsoft.com/library/windows/apps/br205861) コレクションに格納されます。 通常、ユーザーの操作に応じてセカンダリ ビューを作成します。 システムによってアプリのセカンダリ ビューが作成される場合もあります。

> [!NOTE]
> Windows の*割り当てられたアクセス*機能を使うと、[キオスク モード](https://technet.microsoft.com/library/mt219050.aspx)でアプリを実行できます。 この場合、システムによってロック画面に、アプリの UI を表示するセカンダリ ビューが作成されます。 アプリによるセカンダリ ビューの作成は許可されないため、キオスク モードで独自のセカンダリ ビューを表示しようとすると、例外がスローされます。

## <a name="switch-from-one-view-to-another"></a>ビュー間の切り替え

ユーザーには、セカンダリ ウィンドウからメイン ウィンドウに戻る方法を提供する必要があります。 そのためには、[**ApplicationViewSwitcher.SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097) メソッドを使用します。 このメソッドを切り替え元のウィンドウのスレッドから呼び出し、切り替え先のウィンドウのビュー ID を渡します。

```csharp
await ApplicationViewSwitcher.SwitchAsync(viewIdToShow);
```

[**SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097) を使うときは、[**ApplicationViewSwitchingOptions**](https://msdn.microsoft.com/library/windows/apps/dn281105) の値を指定することで、最初のウィンドウを閉じてタスク バーから削除するかどうかを選べます。

 

 





