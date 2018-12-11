---
title: アプリの再開の処理
description: システムがアプリを再開するときに表示されるコンテンツを更新する方法について説明します。
ms.assetid: DACCC556-B814-4600-A10A-90B82664EA15
ms.date: 07/06/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: f424a274d3e96b58f32875620f3165ccfac82ba6
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8883807"
---
# <a name="handle-app-resume"></a>アプリの再開の処理

**重要な API**

- [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339)

システムがアプリを再開するときに、どこで UI を更新するかについて説明します。 このトピックの例では、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントのイベント ハンドラーを登録します。

## <a name="register-the-resuming-event-handler"></a>Resuming イベント ハンドラーに登録する

[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントを処理するために登録します。このイベントは、ユーザーがアプリを切り替えてから、アプリに戻ったことを示します。

```csharp
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

```cppwinrt
MainPage::MainPage()
{
    InitializeComponent();
    Windows::UI::Xaml::Application::Current().Resuming({ this, &MainPage::App_Resuming });
}
```

```cpp
MainPage::MainPage()
{
    InitializeComponent();
    Application::Current->Resuming +=
        ref new EventHandler<Platform::Object^>(this, &MainPage::App_Resuming);
}
```

## <a name="refresh-displayed-content-and-reacquire-resources"></a>表示されているコンテンツの更新とリソースの再取得

ユーザーが別のアプリまたはデスクトップに切り替えると、数秒後にシステムがアプリを中断します。 ユーザーが元のアプリに戻すと、システムはアプリを再開します。 システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。 システムは、アプリを中断前の状態に復元します。 ユーザーには、アプリがバックグラウンドで実行されていたかのように見えます。

アプリが [ **Resuming** ](https://msdn.microsoft.com/library/windows/apps/br242339) イベントを処理した時点で、アプリの中断時間が数時間 (あるいは数日間) に及んでいる可能性もあります。 アプリが中断されている間に古くなった可能性があるコンテンツは、すべて更新されます (ニュース フィードやユーザーの所在地など)。

これは、アプリが中断されたときにリリースした排他リソース (ファイル ハンドル、カメラ、I/O デバイス、外部デバイス、およびネットワーク リソースなど) を復元する良い機会でもあります。

```csharp
partial class MainPage
{
    private void App_Resuming(Object sender, Object e)
    {
        // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
    }
}
```

```vb
Public NonInheritable Class MainPage

    Private Sub App_Resuming(sender As Object, e As Object)
 
        ' TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.

    End Sub
>
End Class
```

```cppwinrt
void MainPage::App_Resuming(
    Windows::Foundation::IInspectable const& /* sender */,
    Windows::Foundation::IInspectable const& /* e */)
{
    // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
}
```

```cpp
void MainPage::App_Resuming(Object^ sender, Object^ e)
{
    // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
}
```

> [!NOTE]
> UI スレッドから、 [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339)イベントが発生しないために、UI への呼び出しをディスパッチする、ディスパッチャーをハンドラーで使用する必要があります。

## <a name="remarks"></a>注釈

アプリが Visual Studio のデバッガーにアタッチされている場合、アプリは中断されません。 ただし、アプリをデバッガーから中断した後、アプリに **Resume** イベントを送信してコードをデバッグすることは可能です。 **[デバッグの場所] ツール バー**が表示されていることを確認し、**[中断]** アイコンの横のドロップダウンをクリックします。 次に、**[再開]** をクリックします。

Windows Phone ストア アプリでは、アプリが現在一時停止中で、ユーザーがプライマリ タイルまたはアプリの一覧からアプリを再起動した場合でも、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントの後に、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) イベントが常に発生します。 現在のウィンドウにコンテンツ セットが既にある場合、アプリは初期化をスキップすることがあります。 [**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736) プロパティをチェックすると、アプリがプライマリ タイルとセカンダリ タイルのどちらから起動されたかを調べ、その情報に基づいて新しいアプリ エクスペリエンスを表示するか、アプリ エクスペリエンスを再開するかを判断できます。

## <a name="related-topics"></a>関連トピック

* [アプリのライフサイクル](app-lifecycle.md)
* [アプリのアクティブ化の処理](activate-an-app.md)
* [アプリの中断の処理](suspend-an-app.md)
