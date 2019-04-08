---
title: ナビゲーションの概要
description: ナビゲーションの概要
ms.assetid: F4DF5C5F-C886-4483-BBDA-498C4E2C1BAF
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 682a743e45626939242af963fba47ca82a13a90e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636597"
---
# <a name="getting-started-navigation"></a>概要: ナビゲーション


## <a name="adding-navigation"></a>ナビゲーションの追加

iOS では、アプリのナビゲーション用に **UINavigationController** クラスが用意されています。ビューのプッシュ/ポップ操作を通じて、アプリを定義する **UIViewControllers** の階層を作ることができます。

これに対し、複数のビューを格納している Windows 10 アプリは web サイトのアプローチの詳細はナビゲーションにします。 ユーザーがコントロールをクリックしてページ間を移動し、アプリ内を進むことを考えてみることができます。 詳しくは、「[ナビゲーション デザインの基本](https://msdn.microsoft.com/library/windows/apps/dn958438)」をご覧ください。

使用する Windows 10 アプリでは、このナビゲーションを管理する方法の 1 つは、 [**フレーム**](https://msdn.microsoft.com/library/windows/apps/br242682)クラス。 以下のチュートリアルでは実際に試す方法を示しています。

以前に開始したソリューションに戻り、**MainPage.xaml** ファイルを開いて、**[デザイン]** ビューにボタンを追加します。 このボタンの **Content** プロパティを "Button" から "Go To Page" に変更します。 次に、ボタンの **Click** イベントのハンドラーを、次の図に示すように作成します。 作成方法がわからない場合は、前のセクションのチュートリアルを見直してください (ヒント: **[デザイン]** ビューにあるボタンをダブルクリックします)。

![Visual Studio でのボタンとそのクリック イベントの追加](images/ios-to-uwp/vs-go-to-page.png)

新しいページを追加しましょう。 **[ソリューション]** ビューで、**[プロジェクト]** メニュー、**[新しい項目の追加]** の順にタップします。 次の図に示すように、**[空白のページ]** をタップし、**[追加]** をタップします。

![Visual Studio での新しいページの追加](images/ios-to-uwp/vs-add-new-page.png)

次に、BlankPage.xaml ファイルにボタンを追加します。 ここでは、AppBarButton コントロールを使い、ボタンに "前に戻る矢印" の画像を設定します。**[XAML]** ビューで、` <AppBarButton Icon="Back"/>` を `<Grid> </Grid>` 要素の間に追加します。

ここで、ボタンにイベント ハンドラーを追加しましょう: でコントロールをダブルクリック、**デザイン**ビューおよび Microsoft Visual Studio のテキストを追加します"AppBarButton\_ をクリック"に、 ** をクリック**ボックス、のように、。次の図では、し、追加して BlankPage.xaml.cs ファイルに対応するイベント ハンドラーを表示します。

![Visual Studio での戻るボタンとそのクリック イベントの追加](images/ios-to-uwp/vs-add-back-button.png)

BlankPage.xaml ファイルの **XAML** ビューに戻り、`<AppBarButton>` 要素の Extensible Application Markup Language (XAML) コードが次のようになっていることを確かめます。

` <AppBarButton Icon="Back" Click="AppBarButton_Click"/>`

BlankPage.xaml.cs ファイルに戻り、以下のコードを追加して、ユーザーがボタンをタップすると前のページに戻るようにします。

```csharp
private void AppBarButton_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.    
    Frame.GoBack();
}
```

最後に、MainPage.xaml.cs ファイルを開き、次のコードを追加します。 このコードは、ユーザーがボタンをタップしたときに BlankPage を開くためのコードです。

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.
    Frame.Navigate(typeof(BlankPage1));
}
```

それでは、プログラムを実行してみましょう。 [Go To Page] ボタンをタップすると、他のページに進みます。矢印スタイルの戻るボタンをタップすると、前のページに戻ります。

ページのナビゲーションは、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラスによって管理されます。 として、 **UINavigationController** iOS で使用でクラス**pushViewController**と**popViewController** 、メソッド、**フレーム**クラスUWP アプリの提供[ **Navigate** ](https://msdn.microsoft.com/library/windows/apps/br242694)と[ **GoBack** ](https://msdn.microsoft.com/library/windows/apps/dn996568)メソッド。 **Frame** クラスには、名前から推測されるとおりに動作する [**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693) というメソッドもあります。

このチュートリアルでは、ナビゲーションを行うたびに BlankPage の新しいインスタンスが作成されます。 (前のインスタンスは自動的に*解放*されます)。 毎回新しいインスタンスが作成されることがないようにするには、BlankPage.xaml.cs ファイル内の BlankPage クラスのコンストラクターに以下のコードを追加します。 これにより、[**NavigationCacheMode**](https://msdn.microsoft.com/library/windows/apps/br227506) 動作が有効になります。

```csharp
public BlankPage()
{
    this.InitializeComponent();
    // Add the following line of code.
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```

また、**Frame** クラスの [**CacheSize**](https://msdn.microsoft.com/library/windows/apps/br242683) プロパティを取得または設定すると、キャッシュするナビゲーションの履歴のページ数を管理できます。

ナビゲーションについて詳しくは、「[ナビゲーション](https://msdn.microsoft.com/library/windows/apps/mt187344)」と「[XAML パーソナリティ アニメーションのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=242401)」をご覧ください。

**注**  JavaScript と HTML を使った UWP アプリのナビゲーションについては、次を参照してください。[クイック スタート。単一ページ ナビゲーションを使用して](https://msdn.microsoft.com/library/windows/apps/hh452768)します。
 
### <a name="next-step"></a>次の手順

[はじめに。アニメーション](getting-started-animation.md)

