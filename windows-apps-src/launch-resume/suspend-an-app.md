---
author: TylerMSFT
title: "アプリの中断の処理"
description: "システムがアプリを中断するときに重要なアプリケーション データを保存する方法を説明します。"
ms.assetid: F84F1512-24B9-45EC-BF23-A09E0AC985B0
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: a69bead489f5d155145b7389199e743792f53f85
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="handle-app-suspend"></a>アプリの中断の処理

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

**重要な API**

- [**中断**](https://msdn.microsoft.com/library/windows/apps/br242341)

システムがアプリを中断するときに重要なアプリケーション データを保存する方法を説明します。 このトピックの例では、[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントのイベント ハンドラーを登録して文字列をファイルに保存します。

## <a name="important-change-introduced-in-windows-10-version-1607"></a>Windows 10 バージョン 1607 で導入された重要な変更

Windows 10 バージョン 1607 より前のバージョンでは、状態を保存するコードを中断ハンドラーに記述していました。 今後は、バックグラウンド状態に移行するときにアプリの状態を保存することをお勧めします (「[Windows 10 ユニバーサル Windows プラットフォーム アプリのライフサイクル](app-lifecycle.md)」で説明しています)。

## <a name="register-the-suspending-event-handler"></a>中断イベント ハンドラーを登録する

[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントを処理するために登録します。このイベントは、システムがアプリを中断する前にアプリでアプリケーション データを保存する必要があることを示します。

> [!div class="tabbedCodeSnippets"]
> ```cs
> using System;
> using Windows.ApplicationModel;
> using Windows.ApplicationModel.Activation;
> using Windows.UI.Xaml;
>
> partial class MainPage
> {
>    public MainPage()
>    {
>       InitializeComponent();
>       Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
>    }
> }
> ```
> ```vb
> Public NotInheritable Class MainPage
>
>    Public Sub New()
>       InitializeComponent()
>       AddHandler Application.Current.Suspending, AddressOf App_Suspending
>    End Sub
>    
> End Class
> ```
> ```cpp
> using namespace Windows::ApplicationModel;
> using namespace Windows::ApplicationModel::Activation;
> using namespace Windows::Foundation;
> using namespace Windows::UI::Xaml;
> using namespace AppName;
>
> MainPage::MainPage()
> {
>    InitializeComponent();
>    Application::Current->Suspending +=
>        ref new SuspendingEventHandler(this, &MainPage::App_Suspending);
> }
> ```

## <a name="save-application-data-before-suspension"></a>中断の前にアプリケーション データを保存する

アプリでは、[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントを処理する時点で、ハンドラー関数で重要なアプリケーション データを保存できます。 アプリで [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) Storage API を使って、シンプルなアプリケーション データを同期的に保存する必要があります。

> [!div class="tabbedCodeSnippets"]
> ```cs
> partial class MainPage
> {
>     async void App_Suspending(
>         Object sender,
>         Windows.ApplicationModel.SuspendingEventArgs e)
>     {
>         // TODO: This is the time to save app data in case the process is terminated
>     }
> }
> ```
> ```vb
> Public NonInheritable Class MainPage
>
>     Private Sub App_Suspending(
>         sender As Object,
>         e As Windows.ApplicationModel.SuspendingEventArgs) Handles OnSuspendEvent.Suspending
>
>         ' TODO: This is the time to save app data in case the process is terminated
>     End Sub
>
> End Class
> ```
> ```cpp
> void MainPage::App_Suspending(Object^ sender, SuspendingEventArgs^ e)
> {
>     // TODO: This is the time to save app data in case the process is terminated
> }
> ```

## <a name="release-resources"></a>リソースの解放

また、排他リソースとファイル ハンドルを、自分のアプリが中断されているときに他のアプリがアクセスできるように解放することをお勧めします。 排他リソースには、カメラ、I/O デバイス、外部デバイス、ネットワーク リソースなどがあります。 排他リソースとファイル ハンドルを明示的に解放すると、自分のアプリが中断されているときに他のアプリが排他リソースとファイル ハンドルにアクセスできるようになります。 アプリが再開されるときに、排他リソースとファイル ハンドルを再取得する必要があります。

## <a name="remarks"></a>注釈

ユーザーが別のアプリや、デスクトップまたはスタート画面に切り替えると、システムはアプリを中断します。 ユーザーが元のアプリに戻すと、システムはアプリを再開します。 システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。 システムはアプリを厳密に一時停止前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。

システムは、アプリの一時停止中、アプリとそのデータをメモリに保持するよう試みます。 ただし、アプリをメモリに保持するためのリソースがシステムにない場合、システムはアプリを終了します。 中断されてから終了されたアプリにユーザーが戻るときに、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送って、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドでアプリケーション データを復元する必要があります。

アプリが終了されるときは、システムはアプリに通知を送らないので、アプリは中断されたときにアプリケーション データを保存し、排他リソースとファイル ハンドルを解放して、アプリが終了後アクティブ化されるときにそれらを復元する必要があります。

ハンドラー内で非同期呼び出しを行う場合、制御はその非同期呼び出しからすぐに戻ります。 つまり、非同期呼び出しがまだ完了していない場合でも、イベント ハンドラーから制御が戻り、アプリを次の状態に移行できます。 イベント ハンドラーに渡される [**EnteredBackgroundEventArgs**](http://aka.ms/Ag2yh4) オブジェクトの [**GetDeferral**](http://aka.ms/Kt66iv) メソッドを使用して、[**Windows.Foundation.Deferral**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.aspx) オブジェクトの [**Complete**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.complete.aspx) メソッドを呼び出した後まで中断を延期することができます。

遅延では、アプリが終了する前に、実行する必要があるコードの量を増やす必要はありません。 遅延の *Complete* メソッドが呼び出されるか、または期限になるか、*どちらか早い方*まで、終了が延期されるだけです。

> **注**  Windows 8.1 でシステムの応答性を向上させるために、アプリには中断後にリソースへの優先度の低いアクセスが与えられます。 この新しい優先度をサポートするために、中断操作のタイムアウトが延長され、アプリには通常の優先度と同程度のタイムアウト (Windows では 5 秒、Windows Phone では 1 ～ 10 秒) が与えられます。 このタイムアウトの時間枠を延長したり、変更したりすることはできません。

> **Visual Studio によるデバッグに関する注意事項:**  Visual Studio は、Visual Studio デバッガーにアタッチされているアプリを Windows が中断するのを防ぎます。 これは、アプリが実行されている間、ユーザーが Visual Studio デバッグの UI を確認できるようにするためです。 アプリのデバッグ中は、Visual Studio を使ってそのアプリに中断イベントを送信できます。 **[デバッグの場所]** ツール バーが表示されていることを確認し、**[中断]** アイコンをクリックします。

## <a name="related-topics"></a>関連トピック

* [アプリのライフサイクル](app-lifecycle.md)
* [アプリのアクティブ化の処理](activate-an-app.md)
* [アプリの再開の処理](resume-an-app.md)
* [起動、中断、再開の UX ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn611862)


 

 
