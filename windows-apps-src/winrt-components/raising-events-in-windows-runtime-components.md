---
author: msatranjr
title: Windows ランタイム コンポーネントでイベントを生成する
ms.assetid: 3F7744E8-8A3C-4203-A1CE-B18584E89000
description: JavaScript にイベントを受信することができるように、バック グラウンド スレッドで代理人のユーザー定義型のイベントを発生させる方法。
ms.author: misatran
ms.date: 07/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 89c021bb2c094aafc9b534acef9b009817669461
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2864951"
---
# <a name="raising-events-in-windows-runtime-components"></a>Windows ランタイム コンポーネントでイベントを生成する
> [!NOTE]
> イベントを発生させる方法については、 [C + +/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) Windows ランタイム コンポーネントを参照してください[C + でイベントを作成 +/WinRT](../cpp-and-winrt-apis/author-events.md)します。

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

ソリューションに C# Windows ランタイム コンポーネントを追加します。ソリューション エクスプ ローラーで、ソリューションのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。 展開**Visual c# &gt; Microsoft ストア**し、 **Windows ランタイム コンポーネント**を選択します。 プロジェクトに、「ToasterComponent」という名前を付け、**[OK]** ボタンをクリックします。 ToasterComponent は、後の手順で作成するコンポーネントのルート名前空間になります。

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

今すぐにプロジェクトを作成する場合、正常に構築する必要があります。

## <a name="to-program-the-javascript-app"></a>プログラム JavaScript アプリ

原因をトーストことは、クラスを使用して JavaScript アプリにボタンを追加できます。 これを行う前に作成した ToasterComponent プロジェクトへの参照を追加します。 ソリューション エクスプ ローラーで ToasterApplication プロジェクトのショートカット メニューを開き、選択**追加&gt;参照**、**新しい参照の追加**] ボタンを選びます。 参照の追加] ダイアログ ボックスの [ソリューション] の下の左側のウィンドウで、プロジェクトを選択し、中央のウィンドウで [ToasterComponent します。 **[OK]** をクリックします。

ソリューション エクスプ ローラーで ToasterApplication プロジェクトのショートカット メニューを開くし、[**スタートアップ プロジェクトとして設定**] を選びます。

Default.js の末尾にある、コンポーネントを呼び出すし、してから、関数を含む名前空間を追加します。 名前空間にトーストとトースト完了イベントを処理する 2 つの関数が表示されます。 MakeToast の実装トースター オブジェクトを作成するには、イベント ハンドラー、および、トーストを使用するとします。 現在のところ、イベント ハンドラーは実行されません、次に示すように。

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

MakeToast 関数は、ボタンに接続する必要があります。 ボタンやトーストの結果を出力するには、いくつかスペースを含める default.html を更新します。

```html
    <body>
        <h1>Click the button to make toast</h1>
        <button onclick="ToasterApplication.makeToast()">Make Toast!</button>
        <div id="toasterOutput">
            <p>No Toast Yet...</p>
        </div>
    </body>
```

TypedEventHandler を使ってされなかった場合では、ローカル コンピューター上のアプリを実行して、ボタンをクリックすることを通知することとなります。 アプリで何も起こりません。 理由を確認するには、ToastCompletedEvent を起動するマネージ コードをデバッグしましょう。 プロジェクトを停止し、メニュー バーで、次のように選択します。**デバッグ&gt;トースター アプリケーションのプロパティ**します。 **マネージのみ**に**デバッガーの種類**を変更します。 もう一度、メニュー バーで、[**デバッグ&gt;例外**、し、**共通言語ランタイム例外**を選択します。

これでアプリを実行し、作成トースト] をクリックします。 デバッガーでは、無効なキャスト例外を検出します。 そのメッセージから推測ありませんが、そのインターフェイスのプロキシが表示されないために、この例外が発生しています。

![プロキシが表示されません。](./images/debuggererrormissingproxy.png)

プロキシとコンポーネントのスタブを作成するのには、最初の手順では、インターフェイスに一意の ID または GUID を追加します。 ただし、使用する GUID 形式は、c#、Visual Basic] または他の .NET 言語または c をコーディングしているかどうかによって異なります。

## <a name="to-generate-guids-for-the-components-interfaces-c-and-other-net-languages"></a>コンポーネントのインターフェイス (c# と他の .NET 言語) の Guid を生成するには

メニュー バーで、[ツール] を選びます&gt;GUID を作成します。 ダイアログ ボックスでは、5 を選択します。 \[Guid ("… チーム xxxx xxxx) \]。 [新しい GUID] ボタンを選択し、[コピー] ボタンをクリックします。

![guid ジェネレーター ツール](./images/guidgeneratortool.png)

戻り、インターフェイスの定義を次の例のように、IToaster インターフェイスの直前に新しい GUID を貼り付けます。 (この例でに GUID を使用しないでください。 一意のすべてのインターフェイスが固有の GUID。)

```cpp
[Guid("FC198F74-A808-4E2A-9255-264746965B9F")]
        public interface IToaster...
```

使用して、追加関連付ける名前空間のディレクティブします。

IToast インターフェイスの次の手順を繰り返します。

## <a name="to-generate-guids-for-the-components-interfaces-c"></a>コンポーネントのインターフェイス (C++) の Guid を生成するには

メニュー バーで、[ツール] を選びます&gt;GUID を作成します。 ダイアログ ボックスでは、3 を選択します。 静的な定数構造体 GUID = {...} します。 [新しい GUID] ボタンを選択し、[コピー] ボタンをクリックします。

GUID IToaster インターフェイス定義の直前に貼り付けます。 貼り付けると後、GUID 次のようになります。 (この例でに GUID を使用しないでください。 一意のすべてのインターフェイスが固有の GUID。)
```cpp
// {F8D30778-9EAF-409C-BCCD-C8B24442B09B}
    static const GUID <<name>> = { 0xf8d30778, 0x9eaf, 0x409c, { 0xbc, 0xcd, 0xc8, 0xb2, 0x44, 0x42, 0xb0, 0x9b } };
```
使用して、追加のプロセスは、その範囲に Windows.Foundation.Metadata ディレクティブします。

今すぐに手動で変換定数 GUID するプロセスは、その書式設定された次の例に示すようにできるようにします。 かっこと、かっこを中かっこが置き換えられます末尾; (セミコロン) が削除されることを確認します。
```cpp
// {E976784C-AADE-4EA4-A4C0-B0C2FD1307C3}
    [GuidAttribute(0xe976784c, 0xaade, 0x4ea4, 0xa4, 0xc0, 0xb0, 0xc2, 0xfd, 0x13, 0x7, 0xc3)]
    public interface IToaster
    {...
```
IToast インターフェイスの次の手順を繰り返します。

インターフェイスは、一意の Id をしたら、お winmdidl コマンド ライン ツールに .winmd ファイルを与えて IDL ファイルを作成し、MIDL コマンド ライン ツールにその IDL ファイルを与えてプロキシおよびスタブの C ソース コードを生成できます。 Visual Studio の操作の場合は、次の手順で示すように、ビルド後のイベントを作成します。

## <a name="to-generate-the-proxy-and-stub-source-code"></a>プロキシを生成して、ソース コードを消去するには

ソリューション エクスプ ローラーで、カスタム ビルド後のイベントを追加するに ToasterComponent プロジェクトのショートカット メニューを開くし、[プロパティ] を選びます。 プロパティ ページの左側のウィンドウで、[イベントの作成を選択し、[ビルド後の編集] ボタンをクリックします。 ビルド後のコマンド ラインには、次のコマンドを追加します。 (バッチ ファイルする必要があります最初に呼び出される winmdidl ツールが見つかりません環境変数を設定します。)

```cpp
call "$(DevEnvDir)..\..\vc\vcvarsall.bat" $(PlatformName)
winmdidl /outdir:output "$(TargetPath)"
midl /metadata_dir "%WindowsSdkDir%References\CommonConfiguration\Neutral" /iid "$(ProjectDir)$(TargetName)_i.c" /env win32 /h "$(ProjectDir)$(TargetName).h" /winmd "Output\$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(ProjectDir)dlldata.c" /proxy "$(ProjectDir)$(TargetName)_p.c" "Output\$(TargetName).idl"
```

**重要です** 腕または x64 の構成のプロジェクトについては、x64 または arm32 MIDL/env パラメーターを変更します。

**ビルド後のイベントを実行**するために、変更の .winmd ファイルが変更されるたびに、IDL ファイルが再生されるようにするには、**ビルドがプロジェクトの出力を更新するとき**。
このビルド イベントのプロパティ ページのようになります:![イベントを作成します。](./images/buildevents.png)

ソリューションを生成して IDL のコンパイルを再構築します。

MIDL が、ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、および ToasterComponent プロジェクト ディレクトリに dlldata.c を探すことにより、ソリューションを正しくコンパイルすることを確認できます。

## <a name="to-compile-the-proxy-and-stub-code-into-a-dll"></a>プロキシをコンパイルして dll、コードをスタブ

これで、必要なファイルがある場合は、コンパイルして DLL、C のファイルを生成できます。 できるだけ簡単にするには、構築、プロキシをサポートする新しいプロジェクトを追加します。 ToasterApplication ソリューションのショートカット メニューを開き、を選びます**追加 > 新しいプロジェクト**します。 **新しいプロジェクト**] ダイアログ ボックスの左側のウィンドウで展開**Visual C &gt; Windows&gt;ユニバーサル Windows**、[中央のウィンドウで [ **DLL (UWP アプリ)**] を選びます。 (C Windows ランタイム コンポーネントのプロジェクトではないことに注意してください)。プロキシ プロジェクトの名前し、 **[OK** ] をクリックします。 これらのファイルは、c# クラスの変更があったときに、ビルド後のイベントが更新されます。

既定では、プロキシ プロジェクトには、ヘッダー .h ファイルと C .cpp ファイルが生成されます。 DLL は MIDL から生成されたファイルを作成したら、ため .h と .cpp ファイルは必須ではありません。 ソリューション エクスプ ローラーでしてショートカット メニューを開く、**削除する**には、選択、削除を確認します。

これで、プロジェクトが含まれていないファイルを追加する戻る、MIDL 生成します。 プロキシ、プロジェクトのショートカット メニューを開き、を選びます**追加 > 既存のアイテム**。 ダイアログ ボックスで、ToasterComponent プロジェクトのディレクトリに移動し、これらのファイルを選択: ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、dlldata.c ファイル。 [**追加**] を選択します。

プロキシ プロジェクトでは、dlldata.c で説明する DLL エクスポートを定義する .def ファイルを作成します。 プロジェクトのショートカット メニューを表示し、[**追加 > [新しいアイテム**します。 ダイアログ ボックスの左側のウィンドウでコードを選択し、[中央のウィンドウで [モジュール定義ファイル] を選びます。 ファイル proxies.def の名前を付けるし、[**追加**] ボタンをクリックします。 この .def ファイルを開き、dlldata.c で定義されているファイルのエクスポートを含むように変更します。

```cpp
EXPORTS
    DllCanUnloadNow         PRIVATE
    DllGetClassObject       PRIVATE
```

これで、プロジェクトを作成する場合は失敗します。 このプロジェクトを正しくコンパイルするには、プロジェクトのコンパイルし、リンクする方法を変更するのにがあります。 ソリューション エクスプ ローラーでプロキシ プロジェクトのショートカット メニューを開くし、[**プロパティ**] を選びます。 次のように、プロパティ ページを変更します。

左側のウィンドウで選択**C/C++ > プリプロセッサ**、右側のウィンドウで、[**プロセッサの定義**を選び、下向き矢印をクリックし、[**編集**] を選びます。 これらの定義] ボックスを追加します。

```cpp
WIN32;_WINDOWS
```
[ **C/C++ > プリコンパイル ヘッダー**、**プリコンパイル済みのヘッダー**を**プリコンパイル ヘッダーを使用しない**] に変更し、[**適用**]。

[**リンク ビルダー > 一般的な**、**たぁ**s に**インポート ライブラリの無視**を変更して、[**適用**] ボタンを選択します。

[**リンク ビルダー > 入力**、**追加の依存関係**を選んで、下向き矢印をクリックし、[**編集**] を選びます。 ボックスに、このテキストを追加します。

```cpp
rpcrt4.lib;runtimeobject.lib
```

リストの行に直接これらのライブラリを貼り付けられません。 Visual Studio で MSBuild が正しい追加の依存関係を維持することを確認するのにには、[**編集**] ボックスを使用します。

これらの変更が終了したら、[**ページのプロパティ**] ダイアログ ボックスで、[ **OK** ] を選択します。

次に、ToasterComponent プロジェクトの依存関係を実行します。 これにより、プロキシ プロジェクトを作成する前に、トースターを作成します。 トースター プロジェクトがユーザーの責任において、プロキシを作成するファイルを生成するために必要です。

プロキシのプロジェクトのショートカット メニューを開くし、[プロジェクトの依存関係] を選びます。 プロキシ プロジェクトによって異なります ToasterComponent プロジェクト、Visual Studio それらを構築する適切な順序にことを確認することを示すにはチェック ボックスを選択します。

選択して、ソリューションが正しくビルドことを確認**ビルド > ソリューションの再構築**Visual Studio メニュー バーでします。


## <a name="to-register-the-proxy-and-stub"></a>プロキシとスタブを登録するには

ToasterApplication プロジェクトで、package.appxmanifest のショートカット メニューを開くし、[**開く**] を選びます。 ファイルを開く] ダイアログ ボックスで、**テキストの XML エディター**を選択し、[し、 **[OK** ] をクリックします。 プロキシの Guid に基づく windows.activatableClass.proxyStub 拡張子の登録とは、いくつかの XML に貼り付けます。 .Appxmanifest ファイルで使用する Guid を検索するには、ToasterComponent_i.c を開きます。 次の例のようなエントリを検索します。 IToast、IToaster の定義を確認し、3 つ目のインターフェイス: 2 つのパラメーターを入力したイベント ハンドラー: トースターとトーストします。 これには、トースター クラスで定義されているイベントと一致します。 IToast および IToaster の Guid c# ファイル内のインターフェイスで定義されている Guid と一致していることを確認します。 入力したイベント ハンドラー インターフェイスは自動生成されたのため、このインターフェイスの GUID も自動的に生成します。

```cpp
MIDL_DEFINE_GUID(IID, IID___FITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast,0x1ecafeff,0x1ee1,0x504a,0x9a,0xf5,0xa6,0x8c,0x6f,0xb2,0xb4,0x7d);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToast,0xF8D30778,0x9EAF,0x409C,0xBC,0xCD,0xC8,0xB2,0x44,0x42,0xB0,0x9B);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToaster,0xE976784C,0xAADE,0x4EA4,0xA4,0xC0,0xB0,0xC2,0xFD,0x13,0x07,0xC3);
```

Guid をコピーすると、これで、追加ノードと名前、拡張子 package.appxmanifest に貼り付け、それらの書式を変更します。 マニフェストのエントリは、次の例のようになります: 独自の Guid を使用して、もう一度覚えておいてください。 XML のクラス Id GUID が ITypedEventHandler2 と同じであることを確認します。 これは、その GUID が ToasterComponent_i.c に表示されている最初の 1 つであるためです。 大文字と小文字が Guid を次のとおりです。 IToast と IToaster Guid を手動で再フォーマット] ではなくインターフェイスの定義に戻ってし、正しい形式である場合の値を取得できます。 C では、正しい形式の GUID には、コメントです。 どのような場合は、クラス Id とイベント ハンドラーの両方で使用されている GUID を手動で再フォーマットする必要があります。

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

パッケージのノードの直接の子と、たとえば、リソースのノードのピア拡張子 XML ノードを貼り付けます。

を移動する前にすることが重要ことを確認します。

-   ProxyStub クラス Id は、ToasterComponent\_i.c ファイル内の最初の GUID に設定されます。 [クラス Id は、このファイルで定義されている最初の GUID を使用します。 (これがあります ITypedEventHandler2 の GUID と同じで、。)
-   パスは、バイナリ プロキシのパッケージの相対的なパスです。 (このチュートリアルで proxies.dll は ToasterApplication.winmd と同じフォルダー内) です。
-   Guid は、適切な形式です。 (これは簡単に問題が発生する) です。
-   マニフェストで、インターフェイス Id では、ToasterComponent\_i.c ファイルに Iid と一致します。
-   マニフェスト内で一意ではインターフェイスの名前です。 これらは、システムで使用されていない、ために、値を選択できます。 明確に定義されているインターフェイスと一致するインターフェイスの名前を選択することをお勧めします。 生成されたインターフェイスの名前は生成されたインターフェイスを示すものになります。 インターフェイス名を生成するために、ToasterComponent\_i.c ファイルを使用することができます。

ソリューションを今すぐ実行しようとした場合はエラーが表示される proxies.dll がられましたの一部ではありません。 ToasterApplication プロジェクトの**参照**フォルダーのショートカット メニューを開き、[**参照の追加**] を選びます。 プロキシのプロジェクトの横のチェック ボックスを選択します。 また、ToasterComponent の横にあるチェック ボックスも選択されていることを確認してください。 **[OK]** をクリックします。

プロジェクトの構築する必要があります。 プロジェクトを実行し、[通知を作成したりすることを確認します。

## <a name="related-topics"></a>関連トピック

* [C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)
