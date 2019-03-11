---
title: Windows ランタイム コンポーネントでイベントを生成する
ms.assetid: 3F7744E8-8A3C-4203-A1CE-B18584E89000
description: JavaScript でイベントを受け取ることができるように、バックグラウンド スレッドでユーザー定義のデリゲート型イベントを生成する方法を示します。
ms.date: 07/19/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 851f8a25055c90dfd592d5a68c733258bcd5f7b5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605957"
---
# <a name="raising-events-in-windows-runtime-components"></a>Windows ランタイム コンポーネントでイベントを生成する
> [!NOTE]
> イベントを発生させる方法については、 [C +/cli WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) 、Windows ランタイム コンポーネントを参照してください[C + でのイベントを作成/cli WinRT](../cpp-and-winrt-apis/author-events.md)します。

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

ここからは、C# を使用して基本的な Windows ランタイム コンポーネントを作成した後、C++ を使用してプロキシおよびスタブの DLL を作成する方法について説明します。これにより、非同期操作でコンポーネントにより生成された Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt; イベントを、JavaScript で利用できるようになります。 (C++ または Visual Basic を使用してコンポーネントを作成することもできます。 プロキシとスタブの作成に関連する手順は同じです。)このチュートリアルはベースの Windows ランタイムのインプロセス コンポーネント サンプルを作成する方法 (C +/cli CX) し、その目的について説明します。

このチュートリアルの内容は次のとおりです。

-   ここでは、2 つの基本的な Windows ランタイム クラスを作成します。 1 つのクラスでは、[Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) 型のイベントを公開し、もう 1 つのクラスは、TValue の引数として JavaScript に返される型です。 後の手順を完了するまで、これらのクラスは JavaScript と通信できません。
-   このアプリは、メイン クラス オブジェクトをアクティブ化し、メソッドを呼び出して、Windows ランタイム コンポーネントで生成されたイベントを処理します。
-   これらはプロキシおよびスタブのクラスを生成するツールで必要です。
-   その後、IDL ファイルを使用して、プロキシおよびスタブの C ソース コードを生成します。
-   プロキシ/スタブ オブジェクトを登録すると、COM ランタイムがこれらを認識し、アプリ プロジェクトでプロキシ/スタブ DLL を参照できるようになります。

## <a name="to-create-the-windows-runtime-component"></a>Windows ランタイム コンポーネントを作成するには

Visual Studio のメニュー バーから **[ファイル]、[新しいプロジェクト]** の順にクリックします。 **[新しいプロジェクト]** ダイアログ ボックスで、**[JavaScript]、[ユニバーサル Windows]** の順に展開し、**[空のアプリケーション]** をクリックします。 プロジェクトに、「ToasterApplication」という名前を付け、 **[OK]** ボタンをクリックします。

追加、C#ソリューションへの Windows ランタイム コンポーネント。ソリューション エクスプ ローラーでソリューションのショートカット メニューを開きにして**追加&gt;新しいプロジェクト**します。 展開**Visual C# &gt; Microsoft Store**選び**Windows ランタイム コンポーネント**します。 プロジェクトに、「ToasterComponent」という名前を付け、 **[OK]** ボタンをクリックします。 ToasterComponent は、後の手順で作成するコンポーネントのルート名前空間になります。

ソリューション エクスプローラーでソリューションのショートカット メニューを開き、**[プロパティ]** をクリックします。 **[プロパティ ページ]** ダイアログ ボックスの左側のウィンドウで、**[構成プロパティ]** を選択して、ダイアログ ボックスの上部の **[構成]** を **[デバッグ]** に、**[プラットフォーム]** を [x86]、[x64]、または [ARM] に設定します。 **[OK]** ボタンをクリックします。

**重要な** プラットフォーム = が後で、ソリューションに追加する、ネイティブ コード Win32 DLL の正しくないために、任意の CPU は機能しません。

ソリューション エクスプ ローラーで、「class1.cs」を「ToasterComponent.cs」という名前に変更して、プロジェクトの名前と一致するようにします。 Visual Studio により、新しいファイル名と一致するように、ファイル内のクラス名が自動的に変更されます。

.cs ファイルで、Windows.Foundation 名前空間の using ディレクティブを追加して、TypedEventHandler をスコープに取り込みます。

プロキシとスタブが必要な場合、コンポーネントではインターフェイスを使用して、パブリック メンバーを公開する必要があります。 ToasterComponent.cs では、トースター用に 1 つ、トースターが生成するトースト用にもう 1 つインターフェイスを定義します。

**注** でC#この手順をスキップすることができます。 代わりに、クラスを作成した後に、ショートカット メニューを開き、**[リファクター]、[インターフェイスの抽出]** の順にクリックします。 生成されたコードで、インターフェイスのパブリック アクセシビリティを手動で指定します。

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

**注** 上記のコード内の非同期呼び出しがバック グラウンド スレッドでイベントを発生させる簡単な方法をデモンストレーションするためだけに ThreadPool.RunAsync を使用します。 この特定のメソッドは、次の例で示すように記述することもできます.NET のタスク スケジューラは、async/await 呼び出しを自動的にマーシャリングして UI スレッドに返すため、正常に動作します。
  
```csharp
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message)
        await Task.Delay(new Random().Next(1000));
        OnToastCompleted(toast);
    }
```

ここでプロジェクトをビルドすると、クリーンにビルドされます。

## <a name="to-program-the-javascript-app"></a>JavaScript アプリをプログラミングするには

次に、JavaScript アプリにボタンを追加し、先ほど定義したクラスを使用してトーストを作成できるようにします。 この作業を行う前に、先ほど作成した ToasterComponent プロジェクトへの参照を追加する必要があります。 ソリューション エクスプローラーで、ToasterApplication プロジェクトのショートカット メニューを開き、**[追加] &gt; [参照]** を選択して、**[新しい参照の追加]** を選択します。 [新しい参照の追加] ダイアログ ボックスの、左側のウィンドウの [ソリューション] の下で、コンポーネント プロジェクトを選択してから、中央のウィンドウで [ToasterComponent] を選択します。 **[OK]** ボタンをクリックします。

ソリューション エクスプローラーで、ToasterApplication プロジェクトのショートカット メニューを開き、**[スタートアップ プロジェクトに設定]** をクリックします。

default.js ファイルの末尾に、コンポーネントを呼び出し、コンポーネントに呼び戻される関数を含む名前空間を追加します。 名前空間には、トーストを作成する関数と、トースト完了のイベントを処理する関数の 2 つの関数を含めます。 makeToast を実装すると、Toaster オブジェクトが作成され、イベント ハンドラーが登録されて、トーストが作成されます。 次に示すように、この時点では、イベント ハンドラーで何かをするわけではありません。

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

makeToast 関数をボタンにフックする必要があります。 default.html を更新して、ボタンと、トーストを作成した結果を出力するためのスペースを追加します。

```html
    <body>
        <h1>Click the button to make toast</h1>
        <button onclick="ToasterApplication.makeToast()">Make Toast!</button>
        <div id="toasterOutput">
            <p>No Toast Yet...</p>
        </div>
    </body>
```

TypedEventHandler を使用しない場合、この時点でアプリをローカル コンピューターで実行してボタンをクリックすると、トーストを作成することができます。 でも、このアプリでは何も起こりません。 理由を確認するには、ToastCompletedEvent を生成するマネージ コードをデバッグしてみましょう。 プロジェクトを停止し、メニュー バーで、**[デバッグ] &gt; [ToasterApplication のプロパティ]** を選択します。 **[デバッガーの種類]** を **[マネージのみ]** に変更します。 もう一度メニュー バーで、**[デバッグ] &gt; [例外]** を選択して、**[Common Language Runtime Exceptions]** (共通言語ランタイムの例外) を選択します。

ここでアプリを実行し、トースト作成ボタンをクリックします。 デバッガーは、無効なキャスト例外をキャッチします。 メッセージからはわかりませんが、この例外は、インターフェイスのプロキシが存在しないために発生します。

![プロキシが存在しない](./images/debuggererrormissingproxy.png)

コンポーネントのプロキシとスタブを作成するには、まず、インターフェイスに一意の ID または GUID を追加します。 ただし、使用する GUID の形式は、コーディングに C#、Visual Basic、または他の .NET 言語を使用する場合と、C++ を使用する場合で異なります。

## <a name="to-generate-guids-for-the-components-interfaces-c-and-other-net-languages"></a>コンポーネントのインターフェイスの GUID を生成するには (C# および他の .NET 言語)

メニュー バーで、[ツール] &gt; [GUID の作成] を選択します。 ダイアログ ボックスで、5. の  \[Guid(“xxxxxxxx-xxxx...xxxx)\]. [新規 GUID] ボタンを選択し、次に [コピー] を選択します。

![GUID ジェネレーター ツール](./images/guidgeneratortool.png)

インターフェイスの定義に戻り、次の例のように、IToaster インターフェイスの直前に、新しい GUID を貼り付けます。 (この例の GUID は使用しないでください。 一意のインターフェイスごとに固有の GUID が必要です。)

```cpp
[Guid("FC198F74-A808-4E2A-9255-264746965B9F")]
        public interface IToaster...
```

System.Runtime.InteropServices 名前空間の using ディレクティブを追加します。

 IToast インターフェイスについても、これらの手順を繰り返します。

## <a name="to-generate-guids-for-the-components-interfaces-c"></a>コンポーネントのインターフェイスの GUID を生成するには (C++)

メニュー バーで、[ツール] &gt; [GUID の作成] を選択します。 ダイアログ ボックスで、3. の  [static const struct GUID = {...}] を選択します。 [新規 GUID] ボタンを選択し、次に [コピー] を選択します。

IToaster インターフェイスの定義の直前に GUID を貼り付けます。 貼り付けた後、GUID は次の例のようになります。 (この例の GUID は使用しないでください。 一意のインターフェイスごとに固有の GUID が必要です。)
```cpp
// {F8D30778-9EAF-409C-BCCD-C8B24442B09B}
    static const GUID <<name>> = { 0xf8d30778, 0x9eaf, 0x409c, { 0xbc, 0xcd, 0xc8, 0xb2, 0x44, 0x42, 0xb0, 0x9b } };
```
Windows.Foundation.Metadata の using ディレクティブを追加して、GuidAttribute をスコープに取り込みます。

ここで、const GUID を手動で GuidAttribute に変換すると、次の例のようにフォーマットされます。 中かっこが角かっこと丸かっこに置き換えられ、末尾のセミコロンが削除されていることがわかります。
```cpp
// {E976784C-AADE-4EA4-A4C0-B0C2FD1307C3}
    [GuidAttribute(0xe976784c, 0xaade, 0x4ea4, 0xa4, 0xc0, 0xb0, 0xc2, 0xfd, 0x13, 0x7, 0xc3)]
    public interface IToaster
    {...
```
 IToast インターフェイスについても、これらの手順を繰り返します。

これで、インターフェイスに一意の ID が付与されたため、winmdidl コマンド ライン ツールに .winmd ファイルを入力して、IDL ファイルを作成してから、MIDL コマンド ライン ツールにその IDL ファイルを入力して、プロキシおよびスタブの C ソース コードを生成できます。 次の手順に示すようにビルド後のイベントを作成すると、Visual Studio でこれが実行されます。

## <a name="to-generate-the-proxy-and-stub-source-code"></a>プロキシおよびスタブのソース コードを生成するには

カスタム ビルド後のイベントを追加するには、ソリューション エクスプローラーで、ToasterComponent プロジェクトのショートカット メニューを開き、[プロパティ] をクリックします。 プロパティ ページの左側のウィンドウで、[ビルド イベント] を選択し、[ビルド後の編集] ボタンをクリックします。 次のコマンドを、ビルド後のコマンド ラインに追加します。 (先にバッチ ファイルを呼び出して、winmdidl ツールを認識できるように環境変数を設定する必要があります。)

```cpp
call "$(DevEnvDir)..\..\vc\vcvarsall.bat" $(PlatformName)
winmdidl /outdir:output "$(TargetPath)"
midl /metadata_dir "%WindowsSdkDir%References\CommonConfiguration\Neutral" /iid "$(ProjectDir)$(TargetName)_i.c" /env win32 /h "$(ProjectDir)$(TargetName).h" /winmd "Output\$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(ProjectDir)dlldata.c" /proxy "$(ProjectDir)$(TargetName)_p.c" "Output\$(TargetName).idl"
```

**重要な**  For an ARM または x64 プロジェクトの構成で、x64、または arm32 MIDL/env パラメーターを変更します。

.winmd ファイルが変更されるたびに、IDL ファイルを再生成するには、**[ビルド後のコマンドラインの実行条件]** を **[ビルドがプロジェクト出力を更新したとき]** に変更します。
このビルド イベントのプロパティ ページのようになります:![ビルド イベント](./images/buildevents.png)

ソリューションをリビルドし、IDL を生成してコンパイルします。

ToasterComponent プロジェクト ディレクトリ内で ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、および dlldata.c を探すことで、MIDL がソリューションを正しくコンパイルしたことを確認できます。

## <a name="to-compile-the-proxy-and-stub-code-into-a-dll"></a>プロキシおよびスタブのコードをコンパイルして DLL を生成するには

これで、必要なファイルがそろったので、ファイルをコンパイルして、C++ ファイルの DLL を生成できます。 できる限り作業を簡単に行うために、プロキシのビルドをサポートする新しいプロジェクトを追加します。 ToasterApplication ソリューションのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。 左側のウィンドウで、**新しいプロジェクト** ダイアログ ボックスで、展開**Visual C &gt; Windows&gt;ユニバーサル Windows**、中央のペインで選択します**DLL (UWP アプリ)**. (C++ Windows ランタイム コンポーネント プロジェクトではないことに注意してください)。Proxies プロジェクトの名前し、選択し、 **OK**ボタン。 これらのファイルは、C# クラスで変更が発生したときに、ビルド後のイベントで更新されます。

Proxies プロジェクトは既定で、ヘッダーの .h ファイルと C++ の .cpp ファイルを生成します。 DLL は MIDL から生成されたファイルでビルドされるため、.h ファイルと .cpp ファイルは必要ありません。 ソリューション エクスプローラーでこれらのショートカット メニューを開き、**[削除]** をクリックして、メッセージが表示されたら削除を確定します。

この時点ではプロジェクトは空なので、MIDL で生成されたファイルを再び追加することができます。 Proxies プロジェクトのショートカット メニューを開き、**[追加] > [既存の項目]** の順に選択します。 ダイアログ ボックスで、ToasterComponent プロジェクト ディレクトリに移動し、これらのファイルを選択します。ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、および dlldata.c ファイル。 **[追加]** ボタンをクリックします。

Proxies プロジェクトで .def ファイルを作成し、dlldata.c に記述されている DLL エクスポートを定義します。 プロジェクトのショートカット メニューを開き、**[追加]、[新しい項目]** の順にクリックします。 ダイアログ ボックスの左側のウィンドウで [コード] を選択し、中央のウィンドウで [モジュール定義ファイル] を選択します。 ファイルに「proxies.def」という名前を付け、**[追加]** ボタンをクリックします。 この .def ファイルを開き、dlldata.c で定義されている EXPORTS を含むように変更します。

```cpp
EXPORTS
    DllCanUnloadNow         PRIVATE
    DllGetClassObject       PRIVATE
```

ここでプロジェクトをビルドすると、失敗します。 このプロジェクトを正しくコンパイルするには、プロジェクトをコンパイルする方法およびプロジェクトがリンクされる方法を変更する必要があります。 ソリューション エクスプローラーで、Proxies プロジェクト ノードのショートカット メニューを開き、**[プロパティ]** を選択します。 プロパティ ページを次のように変更します。

左側のウィンドウで **[C/C++] > [プリプロセッサ]** の順に選択します。右側のウィンドウで **[プリプロセッサの定義]** を選択して下矢印ボタンを選択し、**[編集]** を選択します。 ボックスに次の定義を追加します。

```cpp
WIN32;_WINDOWS
```
**[C/C++] の [プリコンパイル済みヘッダー]** の下で、**[プリコンパイル済みヘッダー]** を **[プリコンパイル済みヘッダーを使用しない]** に変更し、**[適用]** を選択します。

**[リンカー] > [全般]** の下で、**[インポート ライブラリの無視]** を **[はい]** に変更し、**[適用]** を選択します。

**[リンカー] の [入力]** の下で、**[追加の依存ファイル]** をクリックして下矢印ボタンをクリックし、**[編集]** をクリックします。 ボックスに次のテキストを追加します。

```cpp
rpcrt4.lib;runtimeobject.lib
```

これらの lib を list 行に直接貼り付けないでください。 **[編集]** ボックスを使用して、Visual Studio の MSBuild で正しい追加の依存ファイルが維持されるようにします。

これらの変更を行ったら、**[プロパティ ページ]** ダイアログ ボックスの **[OK]** ボタンをクリックします。

次に、ToasterComponent プロジェクトへの依存関係を設定します。 この設定により、常に Toaster がビルドされてからプロキシ プロジェクトがビルドされます。 Toaster プロジェクトでプロキシをビルドするファイルを生成するため、この設定が必要となります。

Proxies プロジェクトのショートカット メニューを開き、[プロジェクトの依存関係] をクリックします。 Proxies プロジェクトが ToasterComponent プロジェクトに依存していることを示すようにチェック ボックスをオンにして、Visual Studio が正しい順序でビルドされるようにします。

Visual Studio のメニュー バーで **[ビルド]、[ソリューションのリビルド]** を順にクリックして、ソリューションが正しくビルドされることを確認します。


## <a name="to-register-the-proxy-and-stub"></a>プロキシおよびスタブを登録するには

ToasterApplication プロジェクトで、package.appxmanifest のショートカット メニューを開き、**[プログラムから開く]** をクリックします。 [プログラムから開く] ダイアログ ボックスで、**[XML テキスト エディター]** を選択し、**[OK]** を選択します。 プロキシの GUID に基づいて windows.activatableClass.proxyStub 拡張機能を登録する複数の XML を貼り付けます。 .appxmanifest ファイルで使用する GUID を調べるには、ToasterComponent_i.c を開きます。 次の例のようなエントリを見つけます。 また、IToast、IToaster、および 3 つ目のインターフェイス (Toaster と Toast の 2 つのパラメーターを持つ型指定されたイベント ハンドラー) の定義も確認します。 これは Toaster クラスで定義されているイベントと一致します。 IToast および IToaster の GUID が、C# ファイル内のインターフェイスで定義されている GUID と一致することを確認します。 型指定されたイベント ハンドラーのインターフェイスは自動生成されるため、このインターフェイスの GUID も自動生成されます。

```cpp
MIDL_DEFINE_GUID(IID, IID___FITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast,0x1ecafeff,0x1ee1,0x504a,0x9a,0xf5,0xa6,0x8c,0x6f,0xb2,0xb4,0x7d);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToast,0xF8D30778,0x9EAF,0x409C,0xBC,0xCD,0xC8,0xB2,0x44,0x42,0xB0,0x9B);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToaster,0xE976784C,0xAADE,0x4EA4,0xA4,0xC0,0xB0,0xC2,0xFD,0x13,0x07,0xC3);
```

ここで GUID をコピーし、追加して Extensions という名前をつけたノードにある package.appxmanifest に貼り付けて、再フォーマットします。 マニフェスト エントリは次の例のようになりますが、ここでも自分の GUID を使用してください。 XML の ClassId の GUID が ITypedEventHandler2 と同じであることに注目します。 これは、その GUID が ToasterComponent_i.c の最初に記載されているためです。 この GUID は、大文字と小文字が区別されません。 IToast および IToaster の GUID を手動で再フォーマットする代わりに、インターフェイスの定義に戻ると、正しい形式である GuidAttribute 値を取得できます。 C++ では、コメントに正しい形式の GUID があります。 いずれの場合も、ClassId とイベント ハンドラーの両方に使用される GUID は手動で再フォーマットする必要があります。

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

Extensions XML ノードを Package ノードの直接の子として、かつ Resources ノードなどのピアとして貼り付けます。

先に進む前に、次のことを確認してください。

-   ProxyStub ClassId が、ToasterComponent の最初の GUID に設定されている\_i.c ファイル。 ClassId には、このファイルに定義されている最初の GUID を使用します。 (これは、ITypedEventHandler2 の GUID と同じである可能性があります。)
-   Path は、プロキシ バイナリのパッケージの相対パスである。 (このチュートリアルでは、proxies.dll は ToasterApplication.winmd と同じフォルダーにあります。)
-   GUID が正しい形式である。 (間違えやすいです。)
-   マニフェスト内のインターフェイス Id の ToasterComponent の Iid と一致\_i.c ファイル。
-   インターフェイス名は、マニフェスト内で一意である。 これらの名前はシステムでは使用されないため、値を選ぶことができます。 定義済みのインターフェイスに一致するわかりやすいインターフェイス名にすることをお勧めします。 生成されたインターフェイスの場合、名前は生成されたインターフェイスを示すものになります。 ToasterComponent を使用する\_インターフェイス名を生成するために i.c ファイル。

ここでソリューションを実行しようとすると、proxies.dll がペイロードの一部ではないことを示すエラーが発生します。 ToasterApplication プロジェクトの **[参照設定]** フォルダーのショートカット メニューを開き、**[参照の追加]** をクリックします。 Proxies プロジェクトの横のチェック ボックスをオンにします。 また、ToasterComponent の横のチェック ボックスもオンにしてください。 **[OK]** ボタンをクリックします。

これでプロジェクトがビルドされます。 プロジェクトを実行し、トーストを作成できることを確認します。

## <a name="related-topics"></a>関連トピック

* [C++ で Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)
