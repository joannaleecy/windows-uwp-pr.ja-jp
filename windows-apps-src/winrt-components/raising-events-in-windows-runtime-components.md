---
author: msatranjr
title: "Windows ランタイム コンポーネントでイベントを生成する"
ms.assetid: 3F7744E8-8A3C-4203-A1CE-B18584E89000
description: 
translationtype: Human Translation
ms.sourcegitcommit: 4c32b134c704fa0e4534bc4ba8d045e671c89442
ms.openlocfilehash: cd1d92e584616a642a20d3df3ec52f3609061021

---

# Windows ランタイム コンポーネントでイベントを生成する


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


Windows ランタイム コンポーネントを使って、ユーザー定義のデリゲート型のイベントをバック グラウンド スレッド (ワーカー スレッド) で発生させ、このイベントを JavaScript で受け取る場合、以下のいずれかの方法でイベントを実装し、発生させることができます。

-   (オプション 1) [Windows.UI.Core.CoreDispatcher](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx) でイベントを生成し、JavaScript のスレッド コンテキストにマーシャリングします。 通常はこれが最適な方法ですが、シナリオによっては最速のパフォーマンスを実現できない場合があります。
-   (オプション 2) [Windows.Foundation.EventHandler](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&lt;Object&gt; を使用します。ただし、型情報が失われます (ただし、イベントの型情報が失われます)。 オプション 1 を実行できない場合、または十分なパフォーマンスが得られない場合、型情報が失われても問題がなければ、これは 2 番目に良い方法です。
-   (オプション 3) コンポーネントに対し、独自のプロキシとスタブを作成します。 このオプションは実装が最も難しいですが、型情報も保持され、要求が厳しいシナリオの場合に、オプション 1 よりパフォーマンスが高くなる可能性があります。

これらのオプションをいずれも使用せずに、バックグラウンド スレッドでイベントを生成すると、JavaScript クライアントはイベントを受け取りません。

## 背景


すべての Windows ランタイム コンポーネントとアプリは、どの言語を使用して作成しても、基本的に COM オブジェクトです。 Windows API では、ほとんどのコンポーネントはアジャイル COM オブジェクトで、バックグラウンド スレッドと UI スレッドで同じようにオブジェクトと通信できます。 COM オブジェクトをアジャイルにできない場合は、UI スレッドとバックグラウンド スレッドの境界を越えて他の COM オブジェクトと通信できるように、プロキシおよびスタブと呼ばれるヘルパー オブジェクトが必要になります。 (COM の用語では、これをスレッド アパートメント間の通信と呼びます。)

Windows API のほとんどのオブジェクトは、アジャイルであるか、プロキシとスタブが組み込まれています。 ただし、Windows.Foundation.[TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) などのジェネリックな型は、型引数を指定するまでは完全な型ではないため、プロキシとスタブを作成できません。 プロキシまたはスタブがないために問題が発生するのは、JavaScript クライアントのみですが、コンポーネントを C++ や .NET 言語からだけでなく JavaScript からも使用したい場合は、次の 3 つのオプションのいずれかを使用する必要があります。

## (オプション 1) CoreDispatcher でイベントを生成する


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

## (オプション 2) EventHandler&lt;Object&gt; を使用するが、型情報が失われる


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

## (オプション 3) 独自のプロキシとスタブを作成する


型情報を完全に保持するユーザー定義のイベント型で十分なパフォーマンスを得るには、独自のプロキシとスタブのオブジェクトを作成し、アプリ パッケージに埋め込む必要があります。 通常、このオプションを使用しなければならないのはまれで、他の 2 つのオプションをどちらも使用できない場合のみです。 また、このオプションで他の 2 つのオプションよりも高いパフォーマンスが実現されるという保証はありません。 実際のパフォーマンスは、さまざまな要因によって決まります。 アプリケーションでの実際のパフォーマンスを測定し、イベントが実際にボトルネックになっているかどうかを判別するには、Visual Studio プロファイラーまたは他のプロファイリング ツールを使用します。

ここからは、C# を使用して基本的な Windows ランタイム コンポーネントを作成した後、C++ を使用してプロキシおよびスタブの DLL を作成する方法について説明します。これにより、非同期操作でコンポーネントにより生成された Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt; イベントを、JavaScript で利用できるようになります。 (C++ または Visual Basic を使用してコンポーネントを作成することもできます。 プロキシとスタブの作成に関連する手順は同じです。このチュートリアルは、Windows ランタイム インプロセス コンポーネントを作成するサンプル (C++/CX) に基づいて、その目的を説明します。

このチュートリアルの内容は次のとおりです。

-   ここでは、2 つの基本的な Windows ランタイム クラスを作成します。 1 つのクラスでは、[Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) 型のイベントを公開し、もう 1 つのクラスは、TValue の引数として JavaScript に返される型です。 後の手順を完了するまで、これらのクラスは JavaScript と通信できません。
-   このアプリは、メイン クラス オブジェクトをアクティブ化し、メソッドを呼び出して、Windows ランタイム コンポーネントで生成されたイベントを処理します。
-   これらはプロキシおよびスタブのクラスを生成するツールで必要です。
-   その後、IDL ファイルを使用して、プロキシおよびスタブの C ソース コードを生成します。
-   プロキシ/スタブ オブジェクトを登録すると、COM ランタイムがこれらを認識し、アプリ プロジェクトでプロキシ/スタブ DLL を参照できるようになります。

## Windows ランタイム コンポーネントを作成するには

Visual Studio のメニュー バーから **[ファイル]、[新しいプロジェクト]** の順にクリックします。 **[新しいプロジェクト]** ダイアログ ボックスで、**[JavaScript]、[ユニバーサル Windows]** の順に展開し、**[空のアプリケーション]** をクリックします。 プロジェクトに、「ToasterApplication」という名前を付け、**[OK]** ボタンをクリックします。

ソリューションに C# Windows ランタイム コンポーネントを追加します。ソリューション エクスプ ローラーで、ソリューションのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。 **[Visual C#]、[Windows ストア]** の順に展開し、**[Windows ランタイム コンポーネント]** をクリックします。 プロジェクトに、「ToasterComponent」という名前を付け、**[OK]** ボタンをクリックします。 ToasterComponent は、後の手順で作成するコンポーネントのルート名前空間になります。

ソリューション エクスプローラーでソリューションのショートカット メニューを開き、**[プロパティ]** をクリックします。 **[プロパティ ページ]** ダイアログ ボックスの左側のウィンドウで、**[構成プロパティ]** を選択して、ダイアログ ボックスの上部の **[構成]** を **[デバッグ]** に、**[プラットフォーム]** を [x86]、[x64]、または [ARM] に設定します。 **[OK]** をクリックします。

**重要** [プラットフォーム] を [Any CPU] に設定すると、後でソリューションに追加するネイティブ コード Win32 DLL で無効になるため、機能しません。

ソリューション エクスプ ローラーで、「class1.cs」を「ToasterComponent.cs」という名前に変更して、プロジェクトの名前と一致するようにします。 Visual Studio により、新しいファイル名と一致するように、ファイル内のクラス名が自動的に変更されます。

.cs ファイルで、Windows.Foundation 名前空間の using ディレクティブを追加して、TypedEventHandler をスコープに取り込みます。

プロキシとスタブが必要な場合、コンポーネントではインターフェイスを使用して、パブリック メンバーを公開する必要があります。 ToasterComponent.cs では、トースター用に 1 つ、トースターが生成するトースト用にもう 1 つインターフェイスを定義します。

**注** C# ではこの手順を省略できます。 代わりに、クラスを作成した後に、ショートカット メニューを開き、**[リファクター]、[インターフェイスの抽出]**の順にクリックします。 生成されたコードで、インターフェイスのパブリック アクセシビリティを手動で指定します。

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
  
````csharp
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message)
        await Task.Delay(new Random().Next(1000));
        OnToastCompleted(toast);
    }
```

If you build the project now, it should build cleanly.

## To program the JavaScript app

Now we can add a button to the JavaScript app to cause it to use the class we just defined to make toast. Before we do this, we must add a reference to the ToasterComponent project we just created. In Solution Explorer, open the shortcut menu for the ToasterApplication project, choose **Add &gt; References**, and then choose the **Add New Reference** button. In the Add Reference dialog box, in the left pane under Solution, select the component project, and then in the middle pane, select ToasterComponent. Choose the **OK** button.

In Solution Explorer, open the shortcut menu for the ToasterApplication project and then choose **Set as Startup Project**.

At the end of the default.js file, add a namespace to contain the functions to call the component and be called back by it. The namespace will have two functions, one to make toast and one to handle the toast-complete event. The implementation of makeToast creates a Toaster object, registers the event handler, and makes the toast. So far, the event handler doesn’t do much, as shown here:

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

The makeToast function must be hooked up to a button. Update default.html to include a button and some space to output the result of making toast:

```html
    <body>
        <h1>Click the button to make toast</h1>
        <button onclick="ToasterApplication.makeToast()">Make Toast!</button>
        <div id="toasterOutput">
            <p>No Toast Yet...</p>
        </div>
    </body>
```

If we weren’t using a TypedEventHandler, we would now be able to run the app on the local machine and click the button to make toast. But in our app, nothing happens. To find out why, let’s debug the managed code that fires the ToastCompletedEvent. Stop the project, and then on the menu bar, choose **Debug &gt; Toaster Application properties**. Change **Debugger Type** to **Managed Only**. Again on the menu bar, choose **Debug &gt; Exceptions**, and then select **Common Language Runtime Exceptions**.

Now run the app and click the make-toast button. The debugger catches an invalid cast exception. Although it’s not obvious from its message, this exception is occurring because proxies are missing for that interface.

![missing proxy](./images/debuggererrormissingproxy.png)

The first step in creating a proxy and stub for a component is to add a unique ID or GUID to the interfaces. However, the GUID format to use differs depending on whether you're coding in C#, Visual Basic, or another .NET language, or in C++.

## To generate GUIDs for the component's interfaces (C# and other .NET languages)

On the menu bar, choose Tools &gt; Create GUID. In the dialog box, select 5. \[Guid(“xxxxxxxx-xxxx...xxxx)\]. Choose the New GUID button and then choose the Copy button.

![guid generator tool](./images/guidgeneratortool.png)

Go back to the interface definition, and then paste the new GUID just before the IToaster interface, as shown in the following example. (Don't use the GUID in the example. Every unique interface should have its own GUID.)

```cpp
[Guid("FC198F74-A808-4E2A-9255-264746965B9F")]
        public interface IToaster...
```

Add a using directive for the System.Runtime.InteropServices namespace.

Repeat these steps for the IToast interface.

## To generate GUIDs for the component's interfaces (C++)

On the menu bar, choose Tools &gt; Create GUID. In the dialog box, select 3. static const struct GUID = {...}. Choose the New GUID button and then choose the Copy button.

Paste the GUID just before the IToaster interface definition. After you paste, the GUID should resemble the following example. (Don't use the GUID in the example. Every unique interface should have its own GUID.)
```cpp
// {F8D30778-9EAF-409C-BCCD-C8B24442B09B}
    static const GUID <<name>> = { 0xf8d30778, 0x9eaf, 0x409c, { 0xbc, 0xcd, 0xc8, 0xb2, 0x44, 0x42, 0xb0, 0x9b } };
```
Add a using directive for Windows.Foundation.Metadata to bring GuidAttribute into scope.

Now manually convert the const GUID to a GuidAttribute so that it's formatted as shown in the following example. Notice that the curly braces are replaced with brackets and parentheses, and the trailing semicolon is removed.
```cpp
// {E976784C-AADE-4EA4-A4C0-B0C2FD1307C3}
    [GuidAttribute(0xe976784c, 0xaade, 0x4ea4, 0xa4, 0xc0, 0xb0, 0xc2, 0xfd, 0x13, 0x7, 0xc3)]
    public interface IToaster
    {...
```
Repeat these steps for the IToast interface.

Now that the interfaces have unique IDs, we can create an IDL file by feeding the .winmd file into the winmdidl command-line tool, and then generate the C source code for the proxy and stub by feeding that IDL file into the MIDL command-line tool. Visual Studio do this for us if we create post-build events as shown in the following steps.

## To generate the proxy and stub source code

To add a custom post-build event, in Solution Explorer, open the shortcut menu for the ToasterComponent project and then choose Properties. In the left pane of the property pages, select Build Events, and then choose the Edit Post-build button. Add the following commands to the post-build command line. (The batch file must be called first to set the environment variables to find the winmdidl tool.)
```cpp
call "$(DevEnvDir)..\..\vc\vcvarsall.bat" $(PlatformName)
winmdidl /outdir:output "$(TargetPath)"
midl /metadata_dir "%WindowsSdkDir%References\CommonConfiguration\Neutral" /iid "$(ProjectDir)$(TargetName)_i.c" /env win32 /h "$(ProjectDir)$(TargetName).h" /winmd "Output\$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(ProjectDir)dlldata.c" /proxy "$(ProjectDir)$(TargetName)_p.c" "Output\$(TargetName).idl"
```
**Important**  For an ARM or x64 project configuration, change the MIDL /env parameter to x64 or arm32.

To make sure the IDL file is regenerated every time the .winmd file is changed, change **Run the post-build event** to **When the build updates the project output.**
The Build Events property page should resemble this:
![build events](./images/buildevents.png)

Rebuild the solution to generate and compile the IDL.

You can verify that MIDL correctly compiled the solution by looking for ToasterComponent.h, ToasterComponent_i.c, ToasterComponent_p.c, and dlldata.c in the ToasterComponent project directory.

## To compile the proxy and stub code into a DLL

Now that you have the required files, you can compile them to produce a DLL, which is a C++ file. To make this as easy as possible, add a new project to support building the proxies. Open the shortcut menu for the ToasterApplication solution and then choose **Add > New Project**. In the left pane of the **New Project** dialog box, expand **Visual C++ &gt; Windows &gt; Univeral Windows**, and then in the middle pane, select **DLL (Windows Store apps)**. (Notice that this is NOT a C++ Windows Runtime Component project.) Name the project Proxies and then choose the **OK** button. These files will be updated by the post-build events when something changes in the C# class.

By default, the Proxies project generates header .h files and C++ .cpp files. Because the DLL is built from the files produced from MIDL, the .h and .cpp files are not required. In Solution Explorer, open the shortcut menu for them, choose **Remove**, and then confirm the deletion.

Now that the project is empty, you can add back the MIDL-generated files. Open the shortcut menu for the Proxies project, and then choose **Add > Existing Item.** In the dialog box, navigate to the ToasterComponent project directory and select these files: ToasterComponent.h, ToasterComponent_i.c, ToasterComponent_p.c, and dlldata.c files. Choose the **Add** button.

In the Proxies project, create a .def file to define the DLL exports described in dlldata.c. Open the shortcut menu for the project, and then choose **Add > New Item**. In the left pane of the dialog box, select Code and then in the middle pane, select Module-Definition File. Name the file proxies.def and then choose the **Add** button. Open this .def file and modify it to include the EXPORTS that are defined in dlldata.c:

```cpp
EXPORTS
    DllCanUnloadNow         PRIVATE
    DllGetClassObject       PRIVATE
```

If you build the project now, it will fail. To correctly compile this project, you have to change how the project is compiled and linked. In Solution Explorer, open the shortcut menu for the Proxies project and then choose **Properties**. Change the property pages as follows.

In the left pane, select **C/C++ > Preprocessor**, and then in the right pane, select **Preprocessor Definitions**, choose the down-arrow button, and then select **Edit**. Add these definitions in the box:

```cpp
WIN32;_WINDOWS
```
Under **C/C++ > Precompiled Headers**, change **Precompiled Header** to **Not Using Precompiled Headers**, and then choose the **Apply** button.

Under **Linker > General**, change **Ignore Import Library** to **Ye**s, and then choose the **Apply** button.

Under **Linker > Input**, select **Additional Dependencies**, choose the down-arrow button, and then select **Edit**. Add this text in the box:

```cpp
rpcrt4.lib;runtimeobject.lib
```

Do not paste these libs directly into the list row. Use the **Edit** box to ensure that MSBuild in Visual Studio will maintain the correct additional dependencies.

When you have made these changes, choose the **OK** button in the **Property Pages** dialog box.

Next, take a dependency on the ToasterComponent project. This ensures that the Toaster will build before the proxy project builds. This is required because the Toaster project is responsible for generating the files to build the proxy.

Open the shortcut menu for the Proxies project and then choose Project Dependencies. Select the check boxes to indicate that the Proxies project depends on the ToasterComponent project, to ensure that Visual Studio builds them in the correct order.

Verify that the solution builds correctly by choosing **Build > Rebuild Solution** on the Visual Studio menu bar.


## To register the proxy and stub

In the ToasterApplication project, open the shortcut menu for package.appxmanifest and then choose **Open With**. In the Open With dialog box, select **XML Text Editor** and then choose the **OK** button. We're going to paste in some XML that provides a windows.activatableClass.proxyStub extension registration and which are based on the GUIDs in the proxy. To find the GUIDs to use in the .appxmanifest file, open ToasterComponent_i.c. Find entries that resemble the ones in the following example. Also notice the definitions for IToast, IToaster, and a third interface—a typed event handler that has two parameters: a Toaster and Toast. This matches the event that's defined in the Toaster class. Notice that the GUIDs for IToast and IToaster match the GUIDs that are defined on the interfaces in the C# file. Because the typed event handler interface is autogenerated, the GUID for this interface is also autogenerated.

```cpp
MIDL_DEFINE_GUID(IID, IID___FITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast,0x1ecafeff,0x1ee1,0x504a,0x9a,0xf5,0xa6,0x8c,0x6f,0xb2,0xb4,0x7d);


MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToast,0xF8D30778,0x9EAF,0x409C,0xBC,0xCD,0xC8,0xB2,0x44,0x42,0xB0,0x9B);


MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToaster,0xE976784C,0xAADE,0x4EA4,0xA4,0xC0,0xB0,0xC2,0xFD,0x13,0x07,0xC3);
```

Now we copy the GUIDs, paste them in package.appxmanifest in a node that we add and name Extensions, and then reformat them. The manifest entry resembles the following example—but again, remember to use your own GUIDs. Notice that the ClassId GUID in the XML is the same as ITypedEventHandler2. This is because that GUID is the first one that's listed in ToasterComponent_i.c. The GUIDs here are case-insensitive. Instead of manually reformatting the GUIDs for IToast and IToaster, you can go back into the interface definitions and get the GuidAttribute value, which has the correct format. In C++, there is a correctly-formatted GUID in the comment. In any case, you must manually reformat the GUID that's used for both the ClassId and the event handler.

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

Paste the Extensions XML node as a direct child of the Package node, and a peer of, for example, the Resources node.

Before moving on, it’s important to ensure that:

-   The ProxyStub ClassId is set to the first GUID in the ToasterComponent\_i.c file. Use the first GUID that's defined in this file for the classId. (This might be the same as the GUID for ITypedEventHandler2.)
-   The Path is the package relative path of the proxy binary. (In this walkthrough, proxies.dll is in the same folder as ToasterApplication.winmd.)
-   The GUIDs are in the correct format. (This is easy to get wrong.)
-   The interface IDs in the manifest match the IIDs in ToasterComponent\_i.c file.
-   The interface names are unique in the manifest. Because these are not used by the system, you can choose the values. It is a good practice to choose interface names that clearly match interfaces that you have defined. For generated interfaces, the names should be indicative of the generated interfaces. You can use the ToasterComponent\_i.c file to help you generate interface names.

If you try to run the solution now, you will get an error that proxies.dll is not part of the payload. Open the shortcut menu for the **References** folder in the ToasterApplication project and then choose **Add Reference**. Select the check box next to the Proxies project. Also, make sure that the check box next to ToasterComponent is also selected. Choose the **OK** button.

The project should now build. Run the project and verify that you can make toast.

## Related topics

* [Creating Windows Runtime Components in C++](creating-windows-runtime-components-in-cpp.md)



<!--HONumber=Aug16_HO3-->


