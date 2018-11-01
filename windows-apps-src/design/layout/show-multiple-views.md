---
author: Jwmsft
Description: View multiple parts of your app in separate windows.
title: アプリの複数のビューの表示
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 048b62e5131852c917b6ec6cd66273760509ef02
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5869720"
---
# <a name="show-multiple-views-for-an-app"></a>アプリの複数のビューの表示

![複数のウィンドウでアプリを表示するワイヤーフレーム](images/multi-view.gif)

アプリの独立した部分を別々のウィンドウで表示できるようにすることは、ユーザーが生産性を高めるために役立ちます。 アプリの複数のウィンドウを作成すると、各ウィンドウは別々に動作します。 タスク バーには各ウィンドウが別々に表示されます。 ユーザーはアプリ ウィンドウの移動、サイズ変更、表示、非表示を個別に行うことができます。また、個別のアプリの場合と同じように各アプリ ウィンドウを切り替えることができます。 各ウィンドウは、独自のスレッドで動作します。

> **重要な API**: [**ApplicationViewSwitcher**](https://msdn.microsoft.com/library/windows/apps/dn281094)、[**CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278)

## <a name="when-should-an-app-use-multiple-views"></a>アプリが複数のビューを使用する場合
複数のビューによるメリットを活用できる、さまざまなシナリオがあります。 以下に例を示します。
 - 受信したメッセージの一覧を表示しながら、新しいメールを作成できるメール アプリ
 - 複数の連絡先情報を並列に表示して比較できるアドレス帳アプリ
 - 再生中の曲の情報を表示しながら、その他の利用可能な曲のリストを閲覧できるミュージック プレイヤー アプリ
 - ノートの 1 つのページから別のページに情報をコピーできるメモ アプリ
 - すべてのヘッドライン概要に目を通しながら、後から読むための記事を複数開くことができる閲覧アプリ

アプリの別のインスタンスを作成するには、「[マルチインスタンスの UWP アプリの作成](../../launch-resume/multi-instance-uwp.md)」を参照してください。

## <a name="what-is-a-view"></a>ビューとは

アプリのビューは、スレッドとウィンドウが 1:1 で対応したもので、アプリがコンテンツの表示に使います。 ビューは [**Windows.ApplicationModel.Core.CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) オブジェクトによって表現されます。

また、[**CoreApplication**](https://msdn.microsoft.com/library/windows/apps/br225016) オブジェクトによって管理されます。 [**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) を呼び出して、[**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) オブジェクトを作成できます。 **CoreApplicationView** は [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) と [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) ([**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br225019) プロパティと [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/dn433264) プロパティに格納) を関連付けます。 **CoreApplicationView** は、Windows ランタイムがコア Windows システムとのやり取りに使うオブジェクトとして考えることができます。

通常は [**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) を直接操作しません。 代わりに Windows ランタイムでは、[**ApplicationView**](https://msdn.microsoft.com/library/windows/apps/hh701658) クラスは [**Windows.UI.ViewManagement**](https://msdn.microsoft.com/library/windows/apps/br242295) 名前空間にあります。 このクラスには、アプリがウィンドウ システムとのやり取りに使うプロパティ、メソッド、イベントが用意されています。 **ApplicationView** を操作するには、静的メソッド [**ApplicationView.GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/hh701672) を呼び出して、現在の **CoreApplicationView** のスレッドに関連付けられている **ApplicationView** インスタンスを取得します。

同様に、XAML フレーム ワークは [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトを [**Windows.UI.XAML.Window**](https://msdn.microsoft.com/library/windows/apps/br209041) オブジェクトにラップします。 XAML アプリでは通常、**CoreWindow** を直接操作しないで、**Window** オブジェクトを操作します。

## <a name="show-a-new-view"></a>新しいビューの表示

各アプリのレイアウトはそれぞれ異なりますが、「新しいウィンドウ」ボタンを予測可能な場所に含めることを推奨します。たとえば、新しいウィンドウで開くことができるコンテンツの右上隅などです。 さらに、[新しいウィンドウで開く] ためのコンテキスト メニュー オプションを含めることを検討します。

新しいビューを作成する手順を見てみましょう。 ここでは、新しいビューがボタンのクリックに応じて起動されます。

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

    XAML では通常、[**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) の [**Content**](https://msdn.microsoft.com/library/windows/apps/br209051) プロパティに [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) を追加した後、**Frame** から、アプリのコンテンツを定義した XAML [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) に移ります。 詳しくは、「[2 ページ間のピア ツー ピア ナビゲーション](../basics/navigate-between-two-pages.md)」をご覧ください。

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

ユーザーには、セカンダリ ウィンドウから親ウィンドウに戻る方法を提供することを検討します。 そのためには、[**ApplicationViewSwitcher.SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097) メソッドを使用します。 このメソッドを切り替え元のウィンドウのスレッドから呼び出し、切り替え先のウィンドウのビュー ID を渡します。

```csharp
await ApplicationViewSwitcher.SwitchAsync(viewIdToShow);
```

[**SwitchAsync**](https://msdn.microsoft.com/library/windows/apps/dn281097) を使うときは、[**ApplicationViewSwitchingOptions**](https://msdn.microsoft.com/library/windows/apps/dn281105) の値を指定することで、最初のウィンドウを閉じてタスク バーから削除するかどうかを選べます。

## <a name="dos-and-donts"></a>推奨と非推奨

* 「新しいウィンドウを開く」のグリフを利用することにより、セカンダリ ビューへの明確なエントリ ポイントを提供します。
* セカンダリ ビューの目的をユーザーに伝えます。
* アプリが単一のビューでも完全に機能することを確認します。セカンダリ ビューは利便性のためのみに提供します。
* 通知やその他の一時的な視覚効果を提供するためにセカンダリ ビューを使用しないようにします。

## <a name="related-topics"></a>関連トピック

* [ApplicationViewSwitcher](https://msdn.microsoft.com/library/windows/apps/dn281094)
* [CreateNewView](https://msdn.microsoft.com/library/windows/apps/dn297278)
 
