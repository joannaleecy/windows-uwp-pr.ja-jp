---
author: mcleblanc
title: アプリの中断の処理
description: システムがアプリを中断するときに重要なアプリケーション データを保存する方法を説明します。
ms.assetid: F84F1512-24B9-45EC-BF23-A09E0AC985B0
---

# アプリの中断の処理


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**中断**](https://msdn.microsoft.com/library/windows/apps/br242341)

システムがアプリを中断するときに重要なアプリケーション データを保存する方法を説明します。 このトピックの例では、[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントのイベント ハンドラーを登録して文字列をファイルに保存します。

## 中断イベント ハンドラーを登録する


[
            **Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントを処理するために登録します。このイベントは、システムがアプリを中断する前にアプリでアプリケーション データを保存する必要があることを示します。

> [!div class="tabbedCodeSnippets"]
```cs
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

partial class MainPage
{
   public MainPage()
   {
      InitializeComponent();
      Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
   }
}
```
```vb
Public NotInheritable Class MainPage

   Public Sub New()
      InitializeComponent() 
      AddHandler Application.Current.Suspending, AddressOf App_Suspending
   End Sub
   
End Class
```
```cpp
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace AppName;

MainPage::MainPage()
{
   InitializeComponent();
   Application::Current->Suspending += 
       ref new SuspendingEventHandler(this, &MainPage::App_Suspending);
}
```

## 中断の前にアプリケーション データを保存する


アプリでは、[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントを処理する時点で、ハンドラー関数で重要なアプリケーション データを保存できます。 アプリで [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) Storage API を使って、シンプルなアプリケーション データを同期的に保存する必要があります。

> [!div class="tabbedCodeSnippets"]
```cs
partial class MainPage
{
    async void App_Suspending(
        Object sender, 
        Windows.ApplicationModel.SuspendingEventArgs e)
    {
        // TODO: This is the time to save app data in case the process is terminated
    }
}
```
```vb
Public NonInheritable Class MainPage

    Private Sub App_Suspending(
        sender As Object, 
        e As Windows.ApplicationModel.SuspendingEventArgs) Handles OnSuspendEvent.Suspending

        ' TODO: This is the time to save app data in case the process is terminated
    End Sub

End Class
```
```cpp
void MainPage::App_Suspending(Object^ sender, SuspendingEventArgs^ e)
{
    // TODO: This is the time to save app data in case the process is terminated
}
```

## 注釈


ユーザーが別のアプリや、デスクトップまたはスタート画面に切り替えると、システムはアプリを中断します。 ユーザーが元のアプリに戻すと、システムはアプリを再開します。 システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。 システムはアプリを厳密に一時停止前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。

システムは、アプリの一時停止中、アプリとそのデータをメモリに保持するよう試みます。 ただし、アプリをメモリに保持するためのリソースがシステムにない場合、システムはアプリを終了します。 中断されてから終了されたアプリにユーザーが戻るときに、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送って、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドでアプリケーション データを復元する必要があります。

アプリが終了されるときは、システムはアプリに通知を送らないので、アプリは中断されたときにアプリケーション データを保存し、排他リソースとファイル ハンドルを解放して、アプリが終了後アクティブ化されるときにそれらを復元する必要があります。

> **注**   アプリの中断が進められているときに非同期作業が必要になった場合には、その作業が完了するまで中断の完了を遅らせる必要があります。 返された [**SuspendingDeferral**](https://msdn.microsoft.com/library/windows/apps/br224684) オブジェクトに [**Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) メソッドを呼び出すまで中断の完了を遅らせるには、[**SuspendingOperation**](https://msdn.microsoft.com/library/windows/apps/br224688) オブジェクト (イベント引数経由で利用可能) に対して [**GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) メソッドを使います。

> **注**  Windows 8.1 でシステムの応答性を向上させるために、アプリには中断後にリソースへの優先度の低いアクセスが与えられます。 この新しい優先度をサポートするために、中断操作のタイムアウトが延長され、アプリには通常の優先度と同程度のタイムアウト (Windows では 5 秒、Windows Phone では 1 ～ 10 秒) が与えられます。 このタイムアウトの時間枠を延長したり、変更したりすることはできません。

> **Visual Studio によるデバッグに関する注意事項:**  Visual Studio は、Visual Studio デバッガーにアタッチされているアプリを Windows が中断するのを防ぎます。 これは、アプリが実行されている間、ユーザーが Visual Studio デバッグの UI を確認できるようにするためです。 アプリのデバッグ中は、Visual Studio を使ってそのアプリに中断イベントを送信できます。 **[デバッグの場所]** ツール バーが表示されていることを確認し、**[中断]** アイコンをクリックします。

## 関連トピック


* [アプリのアクティブ化の処理](activate-an-app.md)
* [アプリの再開の処理](resume-an-app.md)
* [起動、中断、再開の UX ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn611862)
* [アプリのライフサイクル](app-lifecycle.md)

 

 





<!--HONumber=May16_HO2-->


