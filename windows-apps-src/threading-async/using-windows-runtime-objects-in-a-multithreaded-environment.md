---
title: マルチスレッド環境での Windows ランタイム オブジェクトの使用 | Microsoft Docs
description: この記事では、C# および Visual Basic コードからオブジェクト (Windows ランタイム や Windows ランタイム コンポーネントによって提供されるオブジェクト) を呼び出すとき、.NET Framework がどのようにこの呼び出しを処理するかについて説明します。
ms.date: 01/14/2017
ms.topic: article
ms.assetid: 43ffd28c-c4df-405c-bf5c-29c94e0d142b
author: normesta
ms.author: normesta
keywords: Windows 10, UWP, タイマー, スレッド
ms.localizationpriority: medium
ms.openlocfilehash: 9f4b8249a81cb7d71ba1f4775fd858ae87779c85
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7292967"
---
# <a name="using-windows-runtime-objects-in-a-multithreaded-environment"></a>マルチスレッド環境での Windows ランタイム オブジェクトの使用
この記事では、C# および Visual Basic コードからオブジェクト (Windows ランタイム や Windows ランタイム コンポーネントによって提供されるオブジェクト) を呼び出すとき、.NET Framework がどのようにこの呼び出しを処理するかについて説明します。

.NET Framework では、既定で、特別な処理をせずに、複数のスレッドからどのようなオブジェクトにでもアクセスできます。 必要なものは、オブジェクトへの参照だけです。 Windows ランタイム では、このようなオブジェクトは*アジャイル*と呼ばれます。 ほとんどの Windows ランタイム クラスはアジャイルですが、アジャイルでないクラスもいくつかあります。またアジャイル クラスであっても、特別な処理が必要となる場合があります。

可能であれば、Windows ランタイム などの他のソースからのオブジェクトは共通言語ランタイム (CLR) によって処理されます。この場合、これらのオブジェクトは、.NET Framework オブジェクトであるかのように扱われます。

- オブジェクトによって [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) インターフェイスが実装されるか、オブジェクトの [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) 属性の値が [MarshalingType.Agile](http://go.microsoft.com/fwlink/p/?LinkId=256023) である場合、CLR はこのオブジェクトをアジャイルとして処理します。

- ターゲット オブジェクトのスレッド コンテキストに対して行われるスレッドからの呼び出しを CLR がマーシャリングできる場合、それは透過的に行われます。

- オブジェクトの [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) 属性の値が [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023) である場合、このクラスはマーシャリング情報を提供しません。 CLR は呼び出しをマーシャリングできないため、オブジェクトを使用できるのはそのオブジェクトが作成されたスレッド コンテキスト内のみであることを示すメッセージと共に [InvalidCastException](/dotnet/api/system.invalidcastexception) 例外をスローします。

以下のセクションでは、こうした動作がさまざまなソースからのオブジェクトに対してどのような影響を与えるかについて説明します。

## <a name="objects-from-a-windows-runtime-component-that-is-written-in-c-or-visual-basic"></a>C# または Visual Basic で記述された Windows ランタイム コンポーネントからのオブジェクト
アクティブ化できるコンポーネントのすべての型は、既定でアジャイルになります。

> [!NOTE]
>  アジャイルであるからといって、スレッド セーフでもあるというわけではありません。 Windows ランタイム および .NET Framework のどちらの場合も、ほとんどのクラスはスレッド セーフではありません。これは、スレッド セーフはパフォーマンス コストを伴うためです。また、ほとんどのオブジェクトは、複数のスレッドによってアクセスされることはありません。 必要な場合にのみ、個々のオブジェクトへのアクセスを同期する (またはスレッド セーフなクラスを使用する) ことがより効率的な方法です。

Windows ランタイム コンポーネントを作成する場合、既定値をオーバーライドができます。 [ICustomQueryInterface](/dotnet/api/system.runtime.interopservices.icustomqueryinterface) インターフェイスと [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) インターフェイスをご覧ください。

## <a name="objects-from-the-windows-runtime"></a>Windows ランタイム からのオブジェクト
Windows ランタイム のほとんどのクラスはアジャイルであり、CLR はこれらをアジャイルとして処理します。 これらのクラスに関するドキュメントでは、クラスの属性として "MarshalingBehaviorAttribute(Agile)" が示されています。 ただし、これらのアジャイル クラスの一部に属するメンバー (XAML コントロールなど) は、UI スレッド上で呼び出されない場合、例外をスローします。 たとえば、次のコードでは、バック グラウンド スレッドを使用して、クリックされたボタンのプロパティを設定しようとします。 ボタンの [Content](http://go.microsoft.com/fwlink/p/?LinkId=256025) プロパティは例外をスローします。

```csharp
private async void Button_Click_2(object sender, RoutedEventArgs e)
{
    Button b = (Button) sender;
    await Task.Run(() => {
        b.Content += ".";
    });
}
```

```vb
Private Async Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
    Dim b As Button = CType(sender, Button)
    Await Task.Run(Sub()
                       b.Content &= "."
                   End Sub)
End Sub
```

ボタンの [Dispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256026) プロパティ、または UI スレッドのコンテキスト (ボタンがあるページなど) に存在する任意のオブジェクトの `Dispatcher` プロパティを使用すれば、ボタンに安全にアクセスすることができます。 次のコードでは、[CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) オブジェクトの [RunAsync](http://go.microsoft.com/fwlink/p/?LinkId=256030) メソッドを使用して、UI スレッドに呼び出しをディスパッチします。

```csharp
private async void Button_Click_2(object sender, RoutedEventArgs e)
{
    Button b = (Button) sender;
    await b.Dispatcher.RunAsync(
        Windows.UI.Core.CoreDispatcherPriority.Normal,
        () => {
            b.Content += ".";
    });
}

```

```vb
Private Async Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
    Dim b As Button = CType(sender, Button)
    Await b.Dispatcher.RunAsync(
        Windows.UI.Core.CoreDispatcherPriority.Normal,
        Sub()
            b.Content &= "."
        End Sub)
End Sub
```

> [!NOTE]
>  `Dispatcher` プロパティが別のスレッドから呼び出された場合、このプロパティは例外をスローしません。

UI スレッドで作成された Windows ランタイム オブジェクトの有効期間は、スレッドの有効期間によって制限されます。 ウィンドウが閉じられた後は、UI スレッド上のオブジェクトにはアクセスしないでください。

XAML コントロールを継承したり、XAML コントロールのセットを作成したりすることによって、独自のコントロールを作成する場合、作成したコントロールは .NET Framework オブジェクトであるため、アジャイルになります。 ただし、そのコントロールの基底クラスまたは構成要素であるクラスのメンバーを呼び出す場合や、継承されたメンバーを呼び出す場合は、それらのメンバーは UI スレッド以外のいずれかのスレッドから呼び出されると、例外をスローします。

### <a name="classes-that-cant-be-marshaled"></a>マーシャリングできないクラス
マーシャリング情報が提供されない Windows ランタイム クラスには、値が [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023) である [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) 属性が含まれます。 このようなクラスに関するドキュメントでは、クラスの属性として "MarshalingBehaviorAttribute(None)" が示されています。

次のコードでは、UI スレッドに [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) オブジェクトを作成して、スレッド プールのスレッドからオブジェクトのプロパティを設定しようとします。 CLR は呼び出しをマーシャリングできないため、オブジェクトを使用できるのはそのオブジェクトが作成されたスレッド コンテキスト内のみであることを示すメッセージと共に [System.InvalidCastException](/dotnet/api/system.invalidcastexception) 例外をスローします。

```csharp
Windows.Media.Capture.CameraCaptureUI ccui;

private async void Button_Click_1(object sender, RoutedEventArgs e)
{
    ccui = new Windows.Media.Capture.CameraCaptureUI();

    await Task.Run(() => {
        ccui.PhotoSettings.AllowCropping = true;
    });
}

```

```vb
Private ccui As Windows.Media.Capture.CameraCaptureUI

Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
    ccui = New Windows.Media.Capture.CameraCaptureUI()

    Await Task.Run(Sub()
                       ccui.PhotoSettings.AllowCropping = True
                   End Sub)
End Sub
```

[CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) に関するドキュメントでは、クラスの属性として "ThreadingAttribute(STA)" も示されています。これは、このクラスのオブジェクトが UI スレッドなどシングル スレッドのコンテキストで作成される必要があるためです。

別のスレッドから [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) オブジェクトにアクセスする場合、UI スレッドの [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) オブジェクトをキャッシュしておき、後でこのオブジェクト使用して、その別のスレッドに呼び出しをディスパッチすることができます。 または、次のコードに示すように、ページなどの XAML オブジェクトからディスパッチャーを取得することもできます。

```csharp
Windows.Media.Capture.CameraCaptureUI ccui;

private async void Button_Click_3(object sender, RoutedEventArgs e)
{
    ccui = new Windows.Media.Capture.CameraCaptureUI();

    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () => {
            ccui.PhotoSettings.AllowCropping = true;
        });
}

```

```vb
Dim ccui As Windows.Media.Capture.CameraCaptureUI

Private Async Sub Button_Click_3(sender As Object, e As RoutedEventArgs)

    ccui = New Windows.Media.Capture.CameraCaptureUI()

    Await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                                Sub()
                                    ccui.PhotoSettings.AllowCropping = True
                                End Sub)
End Sub
```

## <a name="objects-from-a-windows-runtime-component-that-is-written-in-c"></a>C++ で記述された Windows ランタイム コンポーネントからのオブジェクト
既定では、アクティブ化できるコンポーネントのクラスはアジャイルです。 ただし、C++ ではスレッド モデルやマーシャリングの動作に対して非常に多数の制御を実行することができます。 この記事で既に説明したように、CLR はアジャイル クラスを認識し、クラスがアジャイルでない場合は呼び出しをマーシャリングしようとします。また、クラスにマーシャリング情報がない場合は、[System.InvalidCastException](/dotnet/api/system.invalidcastexception) 例外をスローします。

UI スレッドで実行され、UI スレッド以外のスレッドから呼び出された場合に例外をスローするオブジェクトでは、UI スレッドの [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) オブジェクトを使用して呼び出しをディスパッチできます。

## <a name="see-also"></a>関連項目
[C# ガイド](/dotnet/articles/csharp/)

[Visual Basic ガイド](/dotnet/articles/visual-basic/)
