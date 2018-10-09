---
author: msatranjr
title: Windows ランタイム コンポーネントでイベントを生成する
ms.assetid: 3F7744E8-8A3C-4203-A1CE-B18584E89000
description: JavaScript は、イベントを受信することができるように、バック グラウンド スレッドでユーザー定義のデリゲート型のイベントを発生させる方法について説明します。
ms.author: misatran
ms.date: 07/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 89c021bb2c094aafc9b534acef9b009817669461
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4467232"
---
# <a name="raising-events-in-windows-runtime-components"></a>Windows ランタイム コンポーネントでイベントを生成する
> [!NOTE]
> イベントを発生させる方法については、 [、C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) Windows ランタイム コンポーネントを参照してください[、C++ でのイベントの作成/WinRT](../cpp-and-winrt-apis/author-events.md)します。

Windows ランタイム コンポーネントを使って、ユーザー定義のデリゲート型のイベントをバック グラウンド スレッド (ワーカー スレッド) で発生させ、このイベントを JavaScript で受け取る場合、以下のいずれかの方法でイベントを実装し、発生させることができます。

-   (オプション 1) [Windows.UI.Core.CoreDispatcher](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx) でイベントを生成し、JavaScript のスレッド コンテキストにマーシャリングします。 通常はこれが最適な方法ですが、シナリオによっては最速のパフォーマンスを実現できない場合があります。
-   (オプション 2) [Windows.Foundation.EventHandler](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&lt;Object&gt; を使用します。ただし、型情報が失われます (ただし、イベントの型情報が失われます)。 オプション 1 を実行できない場合、または十分なパフォーマンスが得られない場合、型情報が失われても問題がなければ、これは 2 番目に良い方法です。
-   (オプション 3) コンポーネントに対し、独自のプロキシとスタブを作成します。 このオプションは実装が最も難しいですが、型情報も保持され、要求が厳しいシナリオの場合に、オプション 1 よりパフォーマンスが高くなる可能性があります。

これらのオプションをいずれも使用せずに、バックグラウンド スレッドでイベントを生成すると、JavaScript クライアントはイベントを受け取りません。

## <a name="background"></a>背景

すべての Windows ランタイム コンポーネントとアプリは、どの言語を使用して作成しても、基本的に COM オブジェクトです。 Windows API では、ほとんどのコンポーネントはアジャイル COM オブジェクトで、バックグラウンド スレッドと UI スレッドで同じようにオブジェクトと通信できます。 COM オブジェクトをアジャイルにできない場合は、UI スレッドとバックグラウンド スレッドの境界を越えて他の COM オブジェクトと通信できるように、プロキシおよびスタブと呼ばれるヘルパー オブジェクトが必要になります。 (COM の用語では、これをスレッド アパートメント間の通信と呼びます。)

Windows API のほとんどのオブジェクトは、アジャイルであるか、プロキシとスタブが組み込まれています。 ただし、Windows.Foundation.[TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) などのジェネリックな型は、型引数を指定するまでは完全な型ではないため、プロキシとスタブを作成できません。 プロキシまたはスタブがないために問題が発生するのは、JavaScript クライアントのみですが、コンポーネントを C++ や .NET 言語からだけでなく JavaScript からも使用したい場合は、次の 3 つのオプションのいずれかを使用する必要があります。

## <a name="option-1-raise-the-event-through-the-coredispatcher"></a>(オプション 1) CoreDispatcher でイベントを生成する

[Windows.UI.Core.CoreDispatcher](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx) を使用するとユーザー定義のデリゲート型のイベントを送信でき、JavaScript でそのイベントを受け取ることができます。 どのオプションを使用すればよいかわからない場合は、最初にこのオプションを試してください。 イベントの発生からイベントの処理までの待ち時間が問題になる場合は、他のオプションを試してください。

次の例は、CoreDispatcher を使用して厳密に型指定されされたイベントを生成する方法を示します。 型引数は Toast で、Object ではないことに注意してください。

```csharp
public event EventHandler<Toast> ToastCompletedEvent;
private void OnToastCompleted(Toast args)
{
    var completedEvent = ToastCompletedEvent;
    if (completedEvent != null)
    {
        completedEvent(this, args);
    }
}

public void MakeToastWithDispatcher(string message)
{
    Toast toast = new Toast(message);
    // Assume you have a CoreDispatcher at class scope.
    // Initialize it here, then use it from the background thread.
    var window = Windows.UI.Core.CoreWindow.GetForCurrentThread();
    m_dispatcher = window.Dispatcher;

    Task.Run( () =>
    {
        if (ToastCompletedEvent != null)
        {
            m_dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            new DispatchedHandler(() =>
            {
                this.OnToastCompleted(toast);
            })); // end m_dispatcher.RunAsync
         }
     }); // end Task.Run
}
```

## <a name="option-2-use-eventhandlerltobjectgt-but-lose-type-information"></a>(オプション 2) EventHandler&lt;Object&gt; を使用するが、型情報が失われる

バック グラウンド スレッドからイベントを送信するもう 1 つの方法は、[Windows.Foundation.EventHandler](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&lt;Object&gt; をイベントの型として使用することです。 Windows により、ジェネリック型が具体的にインスタンス化され、プロキシとスタブが提供されます。 欠点は、イベント引数の型情報と送信者が失われることです。 C++ および .NET クライアントは、イベントを受け取ったときにキャストする型の情報をドキュメントから得る必要があります。 JavaScript クライアントでは、元の型情報は必要ありません。 メタデータの名前に基づいて、引数のプロパティを見つけます。

次の例は、C# で Windows.Foundation.EventHandler&lt;Object&gt; を使用する方法を示します。

```csharp
public sealed Class1
{
// Declare the event
public event EventHandler<Object> ToastCompletedEvent;

    // Raise the event
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message);
        // Fire the event from a background thread to allow this thread to continue
        Task.Run(() =>
        {
            if (ToastCompletedEvent != null)
            {
                OnToastCompleted(toast);
            }
        });
    }

    private void OnToastCompleted(Toast args)
    {
        var completedEvent = ToastCompletedEvent;
        if (completedEvent != null)
        {
            completedEvent(this, args);
        }
    }
}
```

JavaScript 側では、次のようにこのイベントを利用します。

```javascript
toastCompletedEventHandler: function (event) {
   var toastType = event.toast.toastType;
   document.getElementById("toasterOutput").innerHTML = "<p>Made " + toastType + " toast</p>";
}
```

## <a name="option-3-create-your-own-proxy-and-stub"></a>(オプション 3) 独自のプロキシとスタブを作成する

型情報を完全に保持するユーザー定義のイベント型で十分なパフォーマンスを得るには、独自のプロキシとスタブのオブジェクトを作成し、アプリ パッケージに埋め込む必要があります。 通常、このオプションを使用しなければならないのはまれで、他の 2 つのオプションをどちらも使用できない場合のみです。 また、このオプションで他の 2 つのオプションよりも高いパフォーマンスが実現されるという保証はありません。 実際のパフォーマンスは、さまざまな要因によって決まります。 アプリケーションでの実際のパフォーマンスを測定し、イベントが実際にボトルネックになっているかどうかを判別するには、Visual Studio プロファイラーまたは他のプロファイリング ツールを使用します。

ここからは、C# を使用して基本的な Windows ランタイム コンポーネントを作成した後、C++ を使用してプロキシおよびスタブの DLL を作成する方法について説明します。これにより、非同期操作でコンポーネントにより生成された Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt; イベントを、JavaScript で利用できるようになります。 (C++ または Visual Basic を使用してコンポーネントを作成することもできます。 プロキシとスタブの作成に関連する手順は同じです。このチュートリアルは、Windows ランタイム インプロセス コンポーネントを作成するサンプル (C++/CX) に基づいて、その目的を説明します。

このチュートリアルの内容は次のとおりです。

-   ここでは、2 つの基本的な Windows ランタイム クラスを作成します。 1 つのクラスでは、[Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) 型のイベントを公開し、もう 1 つのクラスは、TValue の引数として JavaScript に返される型です。 後の手順を完了するまで、これらのクラスは JavaScript と通信できません。
-   このアプリは、メイン クラス オブジェクトをアクティブ化し、メソッドを呼び出して、Windows ランタイム コンポーネントで生成されたイベントを処理します。
-   これらはプロキシおよびスタブのクラスを生成するツールで必要です。
-   その後、IDL ファイルを使用して、プロキシおよびスタブの C ソース コードを生成します。
-   プロキシ/スタブ オブジェクトを登録すると、COM ランタイムがこれらを認識し、アプリ プロジェクトでプロキシ/スタブ DLL を参照できるようになります。

## <a name="to-create-the-windows-runtime-component"></a>Windows ランタイム コンポーネントを作成するには

Visual Studio のメニュー バーから **[ファイル]、[新しいプロジェクト]** の順にクリックします。 **[新しいプロジェクト]** ダイアログ ボックスで、**[JavaScript]、[ユニバーサル Windows]** の順に展開し、**[空のアプリケーション]** をクリックします。 プロジェクトに、「ToasterApplication」という名前を付け、**[OK]** ボタンをクリックします。

ソリューションに C# Windows ランタイム コンポーネントを追加します。ソリューション エクスプ ローラーで、ソリューションのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。 展開**Visual C#] &gt; Microsoft Store**し**Windows ランタイム コンポーネント**を選択します。 プロジェクトに、「ToasterComponent」という名前を付け、**[OK]** ボタンをクリックします。 ToasterComponent は、後の手順で作成するコンポーネントのルート名前空間になります。

ソリューション エクスプローラーでソリューションのショートカット メニューを開き、**[プロパティ]** をクリックします。 **[プロパティ ページ]** ダイアログ ボックスの左側のウィンドウで、**[構成プロパティ]** を選択して、ダイアログ ボックスの上部の **[構成]** を **[デバッグ]** に、**[プラットフォーム]** を [x86]、[x64]、または [ARM] に設定します。 **[OK]** をクリックします。

**重要** [プラットフォーム] を [Any CPU] に設定すると、後でソリューションに追加するネイティブ コード Win32 DLL で無効になるため、機能しません。

ソリューション エクスプ ローラーで、「class1.cs」を「ToasterComponent.cs」という名前に変更して、プロジェクトの名前と一致するようにします。 Visual Studio により、新しいファイル名と一致するように、ファイル内のクラス名が自動的に変更されます。

.cs ファイルで、Windows.Foundation 名前空間の using ディレクティブを追加して、TypedEventHandler をスコープに取り込みます。

プロキシとスタブが必要な場合、コンポーネントではインターフェイスを使用して、パブリック メンバーを公開する必要があります。 ToasterComponent.cs では、トースター用に 1 つ、トースターが生成するトースト用にもう 1 つインターフェイスを定義します。

**注** C# ではこの手順を省略できます。 代わりに、クラスを作成した後に、ショートカット メニューを開き、**[リファクター]、[インターフェイスの抽出]** の順にクリックします。 生成されたコードで、インターフェイスのパブリック アクセシビリティを手動で指定します。

```csharp
    public interface IToaster
        {
            void MakeToast(String message);
            event TypedEventHandler<Toaster, Toast> ToastCompletedEvent;

        }
        public interface IToast
        {
            String ToastType { get; }
        }
```

IToast インターフェイスには、トーストの型を取得して書き込むことができる文字列があります。 IToaster インターフェイスには、トーストを作成するメソッドと、トーストが作成されたことを示すイベントがあります。 このイベントでは、トーストの特定の部分 (つまり型) が返されるため型指定されたイベントと呼ばれます。

次に、これらのインターフェイスを実装したクラスをパブリックにしてシールする必要があります。これにより、後でプログラミングする JavaScript アプリからアクセスできるようになります。

```csharp
    public sealed class Toast : IToast
        {
            private string _toastType;

            public string ToastType
            {
                get
                {
                    return _toastType;
                }
            }
            internal Toast(String toastType)
            {
                _toastType = toastType;
            }

        }
        public sealed class Toaster : IToaster
        {
            public event TypedEventHandler<Toaster, Toast> ToastCompletedEvent;

            private void OnToastCompleted(Toast args)
            {
                var completedEvent = ToastCompletedEvent;
                if (completedEvent != null)
                {
                    completedEvent(this, args);
                }
            }

            public void MakeToast(string message)
            {
                Toast toast = new Toast(message);
                // Fire the event from a thread-pool thread to enable this thread to continue
                Windows.System.Threading.ThreadPool.RunAsync(
                (IAsyncAction action) =>
                {
                    if (ToastCompletedEvent != null)
                    {
                        OnToastCompleted(toast);
                    }
                });
           }
        }
```

上記のコードでは、トーストを作成し、スレッド プールの作業項目を起動して、通知を生成します。 IDE では、非同期呼び出しに対して await キーワードを適用することを推奨している場合がありますが、メソッドで操作結果に依存する処理は行わないため、ここでは必要ありません。

**注** 上記のコードの非同期呼び出しでは、ThreadPool.RunAsync のみを使用して、バックグラウンド スレッドでイベントを発生させる簡単な方法を示します。 この特定のメソッドは、次の例で示すように記述することもできます。.NET のタスク スケジューラは、async/await 呼び出しを自動的にマーシャリングして UI スレッドに返すため、正常に動作します。
  
```csharp
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message)
        await Task.Delay(new Random().Next(1000));
        OnToastCompleted(toast);
    }
```

ここでプロジェクトをビルドする場合、正常にビルドする必要があります。

## <a name="to-program-the-javascript-app"></a>JavaScript アプリをプログラミングするには

使うトーストは、クラスを使用することが発生する JavaScript アプリにボタンを追加できます。 これは、前に、先ほど作成した ToasterComponent プロジェクトへの参照を追加しますする必要があります。 ソリューション エクスプ ローラーで ToasterApplication プロジェクトのショートカット メニューを開き、選択**追加&gt;への参照**、および**新しい参照の追加**ボタンをクリックします。 [参照の追加] ダイアログ ボックスで、ソリューションでは、下の左側のウィンドウでコンポーネント プロジェクトを選択し、中央のウィンドウで [ToasterComponent します。 **[OK]** をクリックします。

ソリューション エクスプ ローラーで ToasterApplication プロジェクトのショートカット メニューを開くし、**スタートアップ プロジェクトとして設定**を選択します。

Default.js ファイルの最後に、コンポーネントを呼び出すと、もう一度によって呼び出された関数を含む名前空間を追加します。 名前空間には、トーストを確認し、トースト完了イベントを処理する 1 つの 2 つの関数があります。 MakeToast の実装は、トースター オブジェクトを作成し、イベント ハンドラーを登録、により、トースト通知。 これまでは、イベント ハンドラーはありません、次のようにします。

```javascript
    WinJS.Namespace.define("ToasterApplication"), {
       makeToast: function () {

          var toaster = new ToasterComponent.Toaster();
          //toaster.addEventListener("ontoastcompletedevent", ToasterApplication.toastCompletedEventHandler);
          toaster.ontoastcompletedevent = ToasterApplication.toastCompletedEventHandler;
          toaster.makeToast("Peanut Butter");
       },

       toastCompletedEventHandler: function(event) {
           // The sender of the event (the delegate's first type parameter)
           // is mapped to event.target. The second argument of the delegate
           // is contained in event, which means in this case event is a
           // Toast class, with a toastType string.
           var toastType = event.toastType;

           document.getElementById('toastOutput').innerHTML = "<p>Made " + toastType + " toast</p>";
        },
    });
```

MakeToast 関数は、ボタンにフックする必要があります。 ボタン、トーストの結果を出力する一部の領域など、default.html を更新します。

```html
    <body>
        <h1>Click the button to make toast</h1>
        <button onclick="ToasterApplication.makeToast()">Make Toast!</button>
        <div id="toasterOutput">
            <p>No Toast Yet...</p>
        </div>
    </body>
```

TypedEventHandler を使って減少が生じない場合できるようになりましたできればローカル コンピューターで、アプリを実行し、トーストを作成するボタンをクリックします。 ただし、アプリで何も起こりません。 その理由を確認するには、ToastCompletedEvent を起動するマネージ コードをデバッグしてみましょう。 プロジェクトを停止し、メニュー バーで、次のように選択します。**デバッグ&gt;トースター アプリケーションのプロパティ**します。 **マネージのみ**を**デバッガーの種類**を変更します。 もう一度メニュー バーで、次のように選択します。**デバッグ&gt;例外**、し、**共通言語ランタイム例外**を選択します。

今すぐアプリを実行し、メーカー トースト ボタンをクリックします。 デバッガーは、無効なキャスト例外をキャッチします。 そのメッセージからは分かりありませんが、プロキシは、そのインターフェイスの不足しているために、この例外が発生しています。

![不足しているプロキシ](./images/debuggererrormissingproxy.png)

プロキシとスタブのコンポーネントを作成するのには、最初に、インターフェイスに一意の ID または GUID を追加します。 ただし、GUID 形式を使用するは、c#、Visual Basic、または他の .NET 言語または C++ でをコーディングしているかどうかに応じて異なります。

## <a name="to-generate-guids-for-the-components-interfaces-c-and-other-net-languages"></a>(C# と他の .NET 言語) コンポーネントのインターフェイスの Guid を生成するには

メニュー バーで、選択ツール&gt;GUID の作成します。 ダイアログ ボックスで、5 を選択します。 \[Guid ("…」という xxxx xxxx) \]。 新しい GUID] ボタンを選択し、コピーのボタンをクリックします。

![guid ジェネレーター ツール](./images/guidgeneratortool.png)

戻って、インターフェイスの定義を次の例に示すように、IToaster インターフェイスの直前に新しい GUID を貼り付けます。 (この例でに GUID を使用しないでください。 一意のすべてのインターフェイスがあります、独自の GUID。

```cpp
[Guid("FC198F74-A808-4E2A-9255-264746965B9F")]
        public interface IToaster...
```

追加の using ディレクティブ System.Runtime.InteropServices 名前空間をします。

IToast インターフェイスの次の手順を繰り返します。

## <a name="to-generate-guids-for-the-components-interfaces-c"></a>コンポーネントのインターフェイス (C++) の Guid を生成するには

メニュー バーで、選択ツール&gt;GUID の作成します。 ダイアログ ボックスで 3 を選択します。 静的な const 構造体 GUID = {...} します。 新しい GUID] ボタンを選択し、コピーのボタンをクリックします。

IToaster インターフェイス定義の直前に GUID を貼り付けます。 貼り付けた後 GUID は、次のようになります。 (この例でに GUID を使用しないでください。 一意のすべてのインターフェイスがあります、独自の GUID。
```cpp
// {F8D30778-9EAF-409C-BCCD-C8B24442B09B}
    static const GUID <<name>> = { 0xf8d30778, 0x9eaf, 0x409c, { 0xbc, 0xcd, 0xc8, 0xb2, 0x44, 0x42, 0xb0, 0x9b } };
```
追加の using ディレクティブ プロセスは、そのをスコープに取り込みます Windows.Foundation.Metadata をします。

今すぐに手動で変換 const GUID、プロセスは、そのフォーマットの次の例に示すようにします。 角かっことかっこ、中かっこは置き換えられ、後続のセミコロンを削除することを確認します。
```cpp
// {E976784C-AADE-4EA4-A4C0-B0C2FD1307C3}
    [GuidAttribute(0xe976784c, 0xaade, 0x4ea4, 0xa4, 0xc0, 0xb0, 0xc2, 0xfd, 0x13, 0x7, 0xc3)]
    public interface IToaster
    {...
```
IToast インターフェイスの次の手順を繰り返します。

インターフェイスでは、一意の Id をしたら、しますに winmdidl コマンド ライン ツールでは、.winmd ファイルを与えて IDL ファイルを作成し、MIDL コマンド ライン ツールにその IDL ファイルを与えてプロキシおよびスタブの C ソース コードを生成できます。 Visual Studio これの場合は、次の手順に示すようにビルド後のイベントを作成します。

## <a name="to-generate-the-proxy-and-stub-source-code"></a>プロキシを生成し、ソース コードのスタブ

ソリューション エクスプ ローラーで、ビルド後のカスタム イベントを追加するには、ToasterComponent プロジェクトのショートカット メニューを開くし、プロパティを選択します。 プロパティ ページの左側のウィンドウでビルド イベントを選択し、ビルド後の編集ボタンをクリックします。 ビルド後のコマンド ラインを次のコマンドを追加します。 (バッチ ファイルを呼び出す必要がありますまず winmdidl ツールを見つけるに環境変数を設定します。)

```cpp
call "$(DevEnvDir)..\..\vc\vcvarsall.bat" $(PlatformName)
winmdidl /outdir:output "$(TargetPath)"
midl /metadata_dir "%WindowsSdkDir%References\CommonConfiguration\Neutral" /iid "$(ProjectDir)$(TargetName)_i.c" /env win32 /h "$(ProjectDir)$(TargetName).h" /winmd "Output\$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(ProjectDir)dlldata.c" /proxy "$(ProjectDir)$(TargetName)_p.c" "Output\$(TargetName).idl"
```

**重要です** 腕または x64 の構成をプロジェクトについては、x64、または arm32 MIDL/env パラメーターを変更します。

IDL ファイルは、.winmd ファイルが変更されるたびに再生されるようにするには、変更する**ビルド後のイベントの実行**に**ビルドがプロジェクトの出力を更新する場合**。
このビルド イベントのプロパティ ページのようになります:![ビルド イベント](./images/buildevents.png)

生成し、コンパイル、IDL ソリューションをリビルドします。

MIDL が、ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、および ToasterComponent プロジェクト ディレクトリに dlldata.c を探すことで、ソリューションを正しくコンパイルすることを確認することができます。

## <a name="to-compile-the-proxy-and-stub-code-into-a-dll"></a>コンパイル プロキシとスタブの DLL にコードを

これで、必要なファイルがある、DLL、C++ ファイルを生成することをコンパイルできます。 できるだけ簡単にするには、するには、プロキシの構築をサポートする新しいプロジェクトを追加します。 ToasterApplication ソリューションのショートカット メニューを開くし、選択**追加 > [新しいプロジェクト**します。 **新しいプロジェクト**] ダイアログ ボックスの左側のウィンドウで、展開**Visual C &gt; Windows&gt;ユニバーサル Windows**、し、中央のウィンドウで**DLL (UWP アプリ)** を選択します。 (C++ Windows ランタイム コンポーネント プロジェクトではないことに注意してください)。プロジェクトのプロキシの名前し、 **[ok]** ボタンをクリックします。 これらのファイルは、c# クラスで変更があったときに、ビルド後のイベントによって更新されます。

既定では、プロキシ プロジェクトには、ヘッダー .h ファイルと C++ .cpp ファイルが生成されます。 MIDL から生成されたファイルから、DLL が組み込まれている、ため、.h ファイルと .cpp ファイルは必要ありません。 ソリューション エクスプ ローラーでそれらのショートカット メニューを開き**を削除する**には、選択し、削除を確認します。

これで、プロジェクトが空で、追加できます戻る MIDL で生成したファイル。 プロキシのプロジェクトのショートカット メニューを開き、選択**追加 > [既存項目の**。 ダイアログ ボックスで ToasterComponent プロジェクト ディレクトリに移動し、これらのファイルを選択: ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、および dlldata.c ファイル。 [**追加**] ボタン。

プロジェクトで、プロキシ dlldata.c で説明されている DLL のエクスポートを定義する .def ファイルを作成します。 プロジェクトのショートカット メニューを開き、選択し、**追加 > [新しい項目の**します。 ダイアログ ボックスの左側のウィンドウでコードを選択し、中央のウィンドウでモジュール定義ファイルを選択します。 ファイル proxies.def の名前し、**追加**のボタンをクリックします。 この .def ファイルを開き、dlldata.c で定義されているエクスポートを含むように変更します。

```cpp
EXPORTS
    DllCanUnloadNow         PRIVATE
    DllGetClassObject       PRIVATE
```

ここでプロジェクトをビルドする場合は失敗します。 このプロジェクトで正しくコンパイルするには、プロジェクトのコンパイルし、リンクする方法を変更する必要があります。 ソリューション エクスプ ローラーでプロキシ プロジェクトのショートカット メニューを開くし、**プロパティ**を選択します。 プロパティ ページを次のように変更します。

左側のウィンドウで、選択**C/C++ > プリプロセッサ**とし、右側のウィンドウで、**プリプロセッサの定義**を選択して、下方向キー] をクリックし、**編集**します。 ボックスには、これらの定義を追加します。

```cpp
WIN32;_WINDOWS
```
[ **C/C++ > プリコンパイル済みヘッダー**、**プリコンパイル済みヘッダーを使用しない**を**プリコンパイル済みヘッダー**に変更し、 **[適用**] ボタンを選択します。

[**リンカー > 一般的な**、**キメ**s を**インポート ライブラリの無視**に変更し、 **[適用**] ボタンを選択します。

[**リンカー > 入力**、**追加の依存ファイル**を選択して、下方向キー] をクリックし、**編集**します。 このテキスト ボックスに追加します。

```cpp
rpcrt4.lib;runtimeobject.lib
```

リストの行に直接これらのライブラリを貼り付けられません。 **編集**ボックスを使用して、Visual Studio の MSBuild が適切な追加の依存関係を維持することを確認します。

これらの変更を加えた場合は、**プロパティ ページ**] ダイアログ ボックスで、[ **OK** ] を選択します。

次に、ToasterComponent プロジェクトに対して依存関係を実行します。 これにより、トースターがプロキシ プロジェクトをビルドする前にビルドされます。 トースター プロジェクトは、プロキシをビルドするファイルを生成するために必要です。

プロキシのプロジェクトのショートカット メニューを開き、プロジェクトの依存関係を選択します。 プロキシ プロジェクトを Visual Studio それらのビルドを正しい順序であることを確認する、ToasterComponent プロジェクトに依存することを示すチェック ボックスを選択します。

ソリューションのビルドを選択して正しくことを確認**ビルド > ソリューションのリビルド**Visual Studio のメニュー バー。


## <a name="to-register-the-proxy-and-stub"></a>プロキシとスタブを登録するには

ToasterApplication プロジェクトで、package.appxmanifest のショートカット メニューを開き**で開く**] を選択します。 ファイルを開く] ダイアログ ボックスで、 **XML のテキスト エディター**を選択し、 **[ok]** ボタンをクリックします。 Windows.activatableClass.proxyStub 拡張機能の登録とに基づいてプロキシの Guid を提供するいくつかの XML で貼り付けを行いましょう。 .Appxmanifest ファイルで使用する Guid を検索するには、ToasterComponent_i.c を開きます。 次の例でもののようなエントリを検索します。 IToast、IToaster の定義にも注目してくださいし、3 番目のインターフェイス、2 つのパラメーターを持つ型指定されたイベント ハンドラー: トースターとトーストします。 これにより、トースター クラスで定義されているイベントが一致します。 IToast および IToaster の Guid が C# のコード ファイル内のインターフェイスで定義されている Guid と一致していることを確認します。 型指定されたイベント ハンドラーのインターフェイスが自動生成されたのため、このインターフェイスの GUID も自動的に生成できます。

```cpp
MIDL_DEFINE_GUID(IID, IID___FITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast,0x1ecafeff,0x1ee1,0x504a,0x9a,0xf5,0xa6,0x8c,0x6f,0xb2,0xb4,0x7d);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToast,0xF8D30778,0x9EAF,0x409C,0xBC,0xCD,0xC8,0xB2,0x44,0x42,0xB0,0x9B);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToaster,0xE976784C,0xAADE,0x4EA4,0xA4,0xC0,0xB0,0xC2,0xFD,0x13,0x07,0xC3);
```

Guid をコピーしますここでは、追加のあるノードと名前、拡張機能内の package.appxmanifest に貼り付けし、それらを再フォーマットします。 マニフェスト エントリに、次の例のようになります: が、ここでも、独自の Guid を使用してください。 XML のクラス Id GUID が ITypedEventHandler2 として同じであることに注意してください。 これは、その GUID が ToasterComponent_i.c に記載されている最初の 1 つであるためです。 Guid をここと小文字を区別します。 IToast と IToaster Guid を手動で再フォーマットではなくインターフェイス定義に戻ってし、正しい形式には、プロセスは、その値を取得できます。 C++ では、コメントの正しい形式の GUID があります。 いずれの場合で、クラス Id とイベント ハンドラーの両方に使用される GUID を手動で再フォーマットする必要があります。

```cpp
      <Extensions> <!--Use your own GUIDs!!!-->
        <Extension Category="windows.activatableClass.proxyStub">
          <ProxyStub ClassId="1ecafeff-1ee1-504a-9af5-a68c6fb2b47d">
            <Path>Proxies.dll</Path>
            <Interface Name="IToast" InterfaceId="F8D30778-9EAF-409C-BCCD-C8B24442B09B"/>
            <Interface Name="IToaster"  InterfaceId="E976784C-AADE-4EA4-A4C0-B0C2FD1307C3"/>  
            <Interface Name="ITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast" InterfaceId="1ecafeff-1ee1-504a-9af5-a68c6fb2b47d"/>
          </ProxyStub>      
        </Extension>
      </Extensions>
```

パッケージのノードの直接の子とリソース ノードなどのピアとして、拡張機能の XML ノードに貼り付けます。

に移行する前にすることが重要ことを確認します。

-   ProxyStub クラス Id は、ToasterComponent\_i.c ファイル内の最初の GUID に設定されます。 クラス Id は、このファイルで定義されている最初の GUID を使用します。 (これに ITypedEventHandler2 の GUID と同じ)。
-   パスは、バイナリのプロキシのパッケージ相対パスです。 (このチュートリアルでは proxies.dll は ToasterApplication.winmd と同じフォルダーに) です。
-   Guid は、正しい形式にします。 (これは簡単に正しくない取得できます) です。
-   マニフェストにインターフェイス Id では、ToasterComponent\_i.c ファイルで Iid と一致します。
-   インターフェイス名は、マニフェストに固有です。 これらは、システムによって使用されていない、ために、値を選択できます。 明確に定義されているインターフェイスに一致するインターフェイス名を選択することをお勧めします。 生成されたインターフェイスは、名前は、生成されたインターフェイスの示唆してください。 インターフェイス名を生成するために、ToasterComponent\_i.c ファイルを使用することができます。

ソリューションを今すぐ実行しようとする場合はエラーが表示される proxies.dll がペイロードの一部ではありません。 ToasterApplication プロジェクトで**参照設定**] フォルダーのショートカット メニューを開き、 **[参照の追加**を選択します。 プロキシのプロジェクトの横にあるチェック ボックスを選択します。 また、ToasterComponent の横にあるチェック ボックスも選択されていることを確認してください。 **[OK]** をクリックします。

プロジェクトをビルドするようになりました。 プロジェクトを実行し、トーストを作成できることを確認します。

## <a name="related-topics"></a>関連トピック

* [C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)
