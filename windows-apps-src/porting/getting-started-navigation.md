---
author: mcleblanc
title: "ナビゲーションの概要"
description: "ナビゲーションの概要"
ms.assetid: F4DF5C5F-C886-4483-BBDA-498C4E2C1BAF
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: c542faa6365c8558988162bee12f266d67474461

---

# はじめに: ナビゲーション

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、「[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)」をご覧ください\]

## ナビゲーションの追加

iOS では、アプリのナビゲーション用に **UINavigationController** クラスが用意されています。ビューのプッシュ/ポップ操作を通じて、アプリを定義する **UIViewControllers** の階層を作ることができます。

これに対して、複数のビューを含む Windows 10 アプリはナビゲーションに対してさらに多くの Web サイト アプローチを行います。 ユーザーがコントロールをクリックしてページ間を移動し、アプリ内を進むことを考えてみることができます。 詳しくは、「[ナビゲーション デザインの基本](https://msdn.microsoft.com/library/windows/apps/dn958438)」をご覧ください。

Windows 10 アプリでこのナビゲーションを管理する方法の 1 つに、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラスを使う方法があります。 以下のチュートリアルでは実際に試す方法を示しています。

以前に開始したソリューションに戻り、**MainPage.xaml** ファイルを開いて、**[デザイン]** ビューにボタンを追加します。 このボタンの **Content** プロパティを "Button" から "Go To Page" に変更します。 次に、ボタンの **Click** イベントのハンドラーを、次の図に示すように作成します。 作成方法がわからない場合は、前のセクションのチュートリアルを見直してください (ヒント: **[デザイン]** ビューにあるボタンをダブルクリックします)。

![Visual Studio でのボタンとそのクリック イベントの追加](images/ios-to-uwp/vs-go-to-page.png)

新しいページを追加しましょう。 **[ソリューション]** ビューで、**[プロジェクト]** メニュー、**[新しい項目の追加]** の順にタップします。 次の図に示すように、**[空白のページ]** をタップし、**[追加]** をタップします。

![Visual Studio での新しいページの追加](images/ios-to-uwp/vs-add-new-page.png)

次に、BlankPage.xaml ファイルにボタンを追加します。 ここでは、AppBarButton コントロールを使い、ボタンに "前に戻る矢印" の画像を設定します。**[XAML]** ビューで、` <AppBarButton Icon="Back"/>` を `<Grid> </Grid>` 要素の間に追加します。

次に、ボタンにイベント ハンドラー追加します。**[デザイン]** ビュー内のコントロールをダブルクリックすると、次の図に示すように、Microsoft Visual Studio によってテキスト "AppBarButton\_Click" が **[Click]** ボックスに追加されます。続いて、対応するイベント ハンドラーが BlankPage.xaml.cs ファイルに追加され、表示されます。

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

ページのナビゲーションは、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラスによって管理されます。 iOS の **UINavigationController** クラスでは **pushViewController** メソッドと **popViewController** メソッドが使われるように、Windows ストア アプリの **Frame** クラスには [**Navigate**](https://msdn.microsoft.com/library/windows/apps/br242694) メソッドと [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568) メソッドが用意されています。 **Frame** クラスには、名前から推測されるとおりに動作する [**GoForward**](https://msdn.microsoft.com/library/windows/apps/br242693) というメソッドもあります。

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

ナビゲーションについて詳しくは、「[ナビゲーション](https://msdn.microsoft.com/library/windows/apps/mt187344)」と「[XAML パーソナリティ アニメーションのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=242401)」をご覧ください。

**注:** JavaScript と HTML を使った Windows ストア アプリのナビゲーションについて詳しくは、「[クイック スタート: 単一ページ ナビゲーションの使用](https://msdn.microsoft.com/library/windows/apps/hh452768)」をご覧ください。
 
### 次のステップ

[はじめに: アニメーション](getting-started-animation.md)




<!--HONumber=Jun16_HO4-->


