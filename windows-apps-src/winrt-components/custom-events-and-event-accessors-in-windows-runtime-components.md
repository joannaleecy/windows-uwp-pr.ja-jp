---
title: Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー
description: .NET Framework が Windows ランタイム コンポーネントをサポートすることにより、ユニバーサル Windows プラットフォーム (UWP) のイベント パターンと .NET Framework のイベント パターンの違いを意識することなく、イベント コンポーネントを簡単に宣言することができます。
ms.assetid: 6A66D80A-5481-47F8-9499-42AC8FDA0EB4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b8c4777e1c34bca36200bf6e8a96c35d6a0b1079
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7836546"
---
# <a name="custom-events-and-event-accessors-in-windows-runtime-components"></a>Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー



.NET Framework が Windows ランタイム コンポーネントをサポートすることにより、ユニバーサル Windows プラットフォーム (UWP) のイベント パターンと .NET Framework のイベント パターンの違いを意識することなく、イベント コンポーネントを簡単に宣言することができます。 ただし、Windows ランタイム コンポーネントのカスタム イベント アクセサーを宣言する場合、UWP で使われるパターンに従う必要があります。

## <a name="registering-events"></a>イベントの登録


UWP のイベントを処理するための登録を行うと、add アクセサーはトークンを返します。 登録を解除するには、このトークンを remove アクセサーに渡します。 これは、UWP イベントの add と remove アクセサーが、これまで使ってきたアクセサーとは異なるシグニチャを持つことを意味します。

Visual Basic と C# コンパイラはこのプロセスを簡略化します。Windows ランタイム コンポーネントのカスタム アクセサーでイベントを宣言すると、コンパイラは自動的に UWP パターンを使います。 たとえば、add アクセサーがトークンを返さない場合、コンパイル エラーが発生します。 .NET Framework には、実装をサポートするための 2 種類の型が用意されています。

-   [EventRegistrationToken](https://msdn.microsoft.com/library/windows/apps/windows.foundation.eventregistrationtoken.aspx) 構造体はトークンを表します。
-   [EventRegistrationTokenTable&lt;T&gt;](https://msdn.microsoft.com/library/hh138412.aspx) クラスはトークンを作成し、トークンとイベント ハンドラーの間の対応付けを保持します。 ジェネリック型引数は、イベント引数の型です。 イベント ハンドラーがイベントに対して最初に登録されたときに、イベントごとにこのクラスのインスタンスを作成します。

NumberChanged イベントの次のコードは、UWP イベントの基本パターンを示しています。 この例では、イベント引数オブジェクトのコンストラクターである NumberChangedEventArgs は、変更された数値を表す単一の整数パラメーターを受け取ります。

> **注:** これは、Windows ランタイム コンポーネントで宣言する通常のイベントのコンパイラが使う同じパターンです。

 
> [!div class="tabbedCodeSnippets"]
> ```csharp
> private EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>     m_NumberChangedTokenTable = null;
>
> public event EventHandler<NumberChangedEventArgs> NumberChanged
> {
>     add
>     {
>         return EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>             .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>             .AddEventHandler(value);
>     }
>     remove
>     {
>         EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>             .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>             .RemoveEventHandler(value);
>     }
> }
>
> internal void OnNumberChanged(int newValue)
> {
>     EventHandler<NumberChangedEventArgs> temp =
>         EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>         .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>         .InvocationList;
>     if (temp != null)
>     {
>         temp(this, new NumberChangedEventArgs(newValue));
>     }
> }
> ```
> ```vb
> Private m_NumberChangedTokenTable As  _
>     EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs))
>
> Public Custom Event NumberChanged As EventHandler(Of NumberChangedEventArgs)
>
>     AddHandler(ByVal handler As EventHandler(Of NumberChangedEventArgs))
>         Return EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             AddEventHandler(handler)
>     End AddHandler
>
>     RemoveHandler(ByVal token As EventRegistrationToken)
>         EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             RemoveEventHandler(token)
>     End RemoveHandler
>
>     RaiseEvent(ByVal sender As Class1, ByVal args As NumberChangedEventArgs)
>         Dim temp As EventHandler(Of NumberChangedEventArgs) = _
>             EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             InvocationList
>         If temp IsNot Nothing Then
>             temp(sender, args)
>         End If
>     End RaiseEvent
> End Event
> ```

static (Visual Basic では Shared) GetOrCreateEventRegistrationTokenTable メソッドは、イベントの EventRegistrationTokenTable&lt;T&gt; オブジェクトのインスタンスを限定的に作成します。 トークン テーブルのインスタンスを保持するクラス レベルのフィールドを、このメソッドに渡します。 フィールドが空の場合、メソッドはテーブルを作成し、テーブルへの参照をフィールドに格納し、テーブルへの参照を返します。 フィールドにトークン テーブルへの参照が既に含まれている場合、このメソッドはその参照を返します。

> **重要な**スレッド セーフでは、イベントの EventRegistrationTokenTable インスタンスを保持するフィールドを確認する&lt;T&gt;クラス レベルのフィールドである必要があります。 クラス レベルのフィールドである場合、GetOrCreateEventRegistrationTokenTable メソッドでは、複数のスレッドがトークン テーブルの作成を試みるときに、すべてのスレッドでテーブルの同じインスタンスが取得されます。 特定のイベントでは、GetOrCreateEventRegistrationTokenTable メソッドのすべての呼び出しは、同じクラス レベルのフィールドを使う必要があります。

remove アクセサーや [RaiseEvent](https://msdn.microsoft.com/library/fwd3bwed.aspx) メソッド (C# では OnRaiseEvent メソッド) で GetOrCreateEventRegistrationTokenTable メソッドを呼び出すことによって、イベント ハンドラー デリゲートが追加される前にこれらのメソッドを呼び出した場合、例外は発生しません。

UWP イベント パターンで使われる EventRegistrationTokenTable&lt;T&gt; クラスの他のメンバーには、次のものがあります。

-   [AddEventHandler](https://msdn.microsoft.com/library/hh138458.aspx) メソッドは、イベント ハンドラー デリゲートのトークンを生成し、デリゲートをテーブルに保存し、デリゲートを呼び出しリストに追加して、トークンを返します。
-   [RemoveEventHandler(EventRegistrationToken)](https://msdn.microsoft.com/library/hh138425.aspx) メソッド オーバーロードは、テーブルと呼び出しリストからデリゲートを削除します。

    >**注:**、AddEventHandler と removeeventhandler (eventregistrationtoken) メソッドは、スレッド セーフを確保するためにテーブルをロックします。

-    [InvocationList](https://msdn.microsoft.com/library/hh138465.aspx) プロパティは、イベントを処理するために現在登録されているすべてのイベント ハンドラーを含むデリゲートを返します。 このデリゲートを使ってイベントを発生させるか、Delegate クラスのメソッドを使ってハンドラーを個別に呼び出します。

    >**注:**、この記事の前半での例で示したパターンに従うし、デリゲートを呼び出す前に一時変数にコピーことをお勧めします。 これにより、あるスレッドが最後のハンドラーを削除して、別のスレッドがデリゲートを呼び出す直前にデリゲートが null となる競合状態を回避できます。 デリゲートは変更できないため、コピーは引き続き有効です。

必要に応じて、独自のコードをアクセサーに配置します。 スレッド セーフが問題の場合、独自のロックをコードに提供する必要があります。

C# ユーザー: UWP イベント パターンでカスタム イベント アクセサーを作成すると、コンパイラは通常の構文のショートカットを提供しません。 コードでイベント名を使うとエラーが発生します。

Visual Basic ユーザー: .NET Framework では、イベントは登録されたすべてのイベント ハンドラーを表すマルチキャスト デリゲートにすぎません。 イベントを発生させることは、デリゲートを呼び出すことを意味します。 一般に、Visual Basic の構文はデリゲートとの対話を非表示にします。また、スレッド セーフに関するメモに説明されているように、コンパイラはデリゲートを呼び出す前にデリゲートをコピーします。 Windows ランタイム コンポーネントでカスタム イベントを作成する場合、デリゲートを直接扱う必要があります。 これは、たとえばハンドラーを個別に呼び出す場合、[MulticastDelegate.GetInvocationList](https://msdn.microsoft.com/library/system.multicastdelegate.getinvocationlist.aspx) メソッドを使って、イベント ハンドラーごとに個別のデリゲートが含まれる配列を取得できることも意味します。

## <a name="related-topics"></a>関連トピック

* [イベント (Visual Basic)](https://msdn.microsoft.com/library/ms172877.aspx)
* [イベント (C# プログラミング ガイド)](https://msdn.microsoft.com/library/awbftdfh.aspx)
* [UWP アプリの概要の .NET](https://msdn.microsoft.com/library/windows/apps/xaml/br230302.aspx)
* [UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx)
* [チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)
