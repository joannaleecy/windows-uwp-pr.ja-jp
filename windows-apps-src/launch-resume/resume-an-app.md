---
title: アプリの再開の処理
description: システムがアプリを再開するときに表示されるコンテンツを更新する方法について説明します。
ms.assetid: DACCC556-B814-4600-A10A-90B82664EA15
---

# アプリの再開の処理


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339)

システムがアプリを再開するときに表示されるコンテンツを更新する方法について説明します。 このトピックの例では、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントのイベント ハンドラーを登録します。

**ロードマップ:** このトピックと他のトピックとの関連については、 以下をご覧ください。

-   [C# または Visual Basic を使った Windows ランタイム アプリのためのロードマップ](https://msdn.microsoft.com/library/windows/apps/br229583)
-   [C++ を使った Windows ランタイム アプリのためのロードマップ](https://msdn.microsoft.com/library/windows/apps/hh700360)

## Resuming イベント ハンドラーに登録する

[
            **Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントを処理するために登録します。このイベントは、ユーザーがアプリを切り替えてから、アプリに戻ったことを示します。

> [!div class="tabbedCodeSnippets"]
```cs
partial class MainPage
{
   public MainPage()
   {
      InitializeComponent();
      Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
   }
}
```
```vb
Public NonInheritable Class MainPage

   Public Sub New()
      InitializeComponent() 
      AddHandler Application.Current.Resuming, AddressOf App_Resuming
   End Sub

End Class
```
```cpp
MainPage::MainPage()
{
    InitializeComponent();
    Application::Current->Resuming += 
        ref new EventHandler<Platform::Object^>(this, &amp;MainPage::App_Resuming);
}
```

## 一時停止の後で表示されるコンテンツを更新する

アプリでは、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントを処理する時点で、表示されているコンテンツを更新できます。

> [!div class="tabbedCodeSnippets"]
```cs
partial class MainPage
{
    private void App_Resuming(Object sender, Object e)
    {
        // TODO: Refresh network data
    }
}
```
```vb
Public NonInheritable Class MainPage

    Private Sub App_Resuming(sender As Object, e As Object)
 
        ' TODO: Refresh network data

    End Sub

End Class
```
```cpp
void MainPage::App_Resuming(Object^ sender, Object^ e)
{
    // TODO: Refresh network data
}
```

> **注**  [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントは UI スレッドからは生成されないため、ハンドラーでこのような処理が必要な場合は、ディスパッチャーを使って UI スレッドにアクセスし、UI に更新を流し込む必要があります。

## 注釈


ユーザーが別のアプリまたはデスクトップに切り替えると、システムはアプリを中断します。 ユーザーが元のアプリに戻すと、システムはアプリを再開します。 システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。 システムはアプリを厳密に一時停止前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。 しかし、アプリは長時間一時停止している場合があるので、ニュース フィードやユーザーの位置情報など、アプリが一時停止している間に変化した可能性のある表示コンテンツを更新する必要があります。

アプリに更新する表示コンテンツがない場合、アプリで [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントを処理する必要はありません。

**Visual Studio によるデバッグに関する注意事項: ** アプリが Visual Studio デバッガーにアタッチされている場合、そのアプリに **Resume** イベントを送信できます。 **[デバッグの場所]** ツール バーが表示されていることを確認し、**[中断]** アイコンの横のドロップダウンをクリックします。 次に、**[再開]** をクリックします。

> **注**  Windows Phone ストア アプリでは、アプリが現在一時停止中で、ユーザーがプライマリ タイルまたはアプリの一覧からアプリを再起動した場合でも、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントの後に、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) イベントが常に発生します。 現在のウィンドウにコンテンツ セットが既にある場合、アプリは初期化をスキップすることがあります。 [
            **LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736) プロパティをチェックすると、アプリがプライマリ タイルとセカンダリ タイルのどちらから起動されたかを調べ、その情報に基づいて新しいアプリ エクスペリエンスを表示するか、アプリ エクスペリエンスを再開するかを判断できます。

## 関連トピック

* [アプリのアクティブ化の処理](activate-an-app.md)
* [アプリの中断の処理](suspend-an-app.md)
* [アプリの中断と再開のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [アプリのライフサイクル](app-lifecycle.md)




<!--HONumber=Mar16_HO1-->


