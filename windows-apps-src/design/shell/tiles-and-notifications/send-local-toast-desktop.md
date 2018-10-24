---
author: andrewleader
Description: Learn how Win32 C# apps can send local toast notifications and handle the user clicking the toast.
title: デスクトップ C# アプリからのローカル トースト通知の送信
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Send a local toast notification from desktop C# apps
template: detail.hbs
ms.author: mijacobs
ms.date: 01/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, win32, デスクトップ, トースト通知, トーストの送信, ローカル トーストの送信, デスクトップ ブリッジ, C#, c シャープ
ms.localizationpriority: medium
ms.openlocfilehash: 3bda3e85fd89ef7a8b819fcd809acea4fd9a276b
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5433913"
---
# <a name="send-a-local-toast-notification-from-desktop-c-apps"></a>デスクトップ C# アプリからのローカル トースト通知の送信

デスクトップ アプリ (デスクトップ ブリッジと従来の Win32) は、ユニバーサル Windows プラットフォーム (UWP) アプリと同様の対話型トースト通知を送信できます。 ただし、デスクトップ アプリの場合は、いくつかの特別な手順があります。これは、アクティブ化スキームが異なるためであり、またデスクトップ ブリッジを使用していない場合には、パッケージ ID が存在しない可能性があるためです。

> [!IMPORTANT]
> UWP アプリを作成している場合は、[UWP のドキュメント](send-local-toast.md) をご覧ください。 その他のデスクトップ言語については、[デスクトップ C++ WRLに関するページ](send-local-toast-desktop-cpp-wrl.md) をご覧ください。


## <a name="step-1-enable-the-windows-10-sdk"></a>手順 1: Windows 10 SDK を有効にする

Win32 アプリ向けの Windows 10 SDK がまだ有効でない場合は、まず有効にします。

プロジェクトを右クリックし、**[プロジェクトのアンロード]** をクリックします。

![プロジェクトのアンロード](images/win32-unload-project.png)

プロジェクトをもう一度右クリックし、**[[プロジェクト名].csproj の編集]** をクリックします。

![プロジェクトの編集](images/win32-edit-project.png)

既存の `<TargetFrameworkVersion>` ノードの下に、サポートされる Windows 10 の最小バージョンを指定して、新しい `<TargetPlatformVersion>` ノードを追加します。 使用される実際の SDK は、開発用マシンにインストールされている最新の SDK です。 これだけで、サポートされる最小バージョンが指定されます (また Windows SDK を参照できるようになります)。

```xml
...
<TargetFrameworkVersion>...</TargetFrameworkVersion>
<TargetPlatformVersion>10.0.10240.0</TargetPlatformVersion>
...
```

変更を保存し、プロジェクトを再度読み込みます。

![プロジェクトの再読み込み](images/win32-reload-project.png)


## <a name="step-2-reference-the-apis"></a>手順 2: API を参照する

参照マネージャーを開きます (プロジェクトを右クリックして、**[追加] -> [参照]** を選択)。**[Windows] -> [コア]** を選択し、以下の参照を追加します。

* Windows.Data
* Windows.UI

![参照マネージャー](images/win32-add-windows-reference.png)


## <a name="step-3-copy-compat-library-code"></a>手順 3: compat ライブラリのコードをコピーする

[DesktopNotificationManagerCompat.cs file from GitHub](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CS/DesktopToastsApp/DesktopNotificationManagerCompat.cs) をプロジェクトにコピーします。 compat ライブラリを使用することで、デスクトップ通知の複雑な部分の多くが抽象化されます。 次の手順では、compat ライブラリが必要です。


## <a name="step-4-implement-the-activator"></a>手順 4: アクティベーターを実装する

ユーザーは、トーストをクリックすると、アプリが動作できる、トーストのアクティブ化ハンドラーを実装する必要があります。 これは、アクション センターにトーストを継続的に表示するために必要です (トーストは、数日後、アプリが閉じているときにクリックされる可能性があります)。 このクラスは、プロジェクトの任意の位置に指定できます。

**NotificationActivator** クラスを展開し、以下の 3 つの属性を追加します。任意のオンライン GUID ジェネレーターを使用して、アプリ用に一意の GUID CLSID を作成します。 アクション センターは、この CLSID (クラス識別子) に基づいて、COM アクティブ化するクラスを認識します。

```csharp
// The GUID CLSID must be unique to your app. Create a new GUID if copying this code.
[ClassInterface(ClassInterfaceType.None)]
[ComSourceInterfaces(typeof(INotificationActivationCallback))]
[Guid("replaced-with-your-guid-C173E6ADF0C3"), ComVisible(true)]
public class MyNotificationActivator : NotificationActivator
{
    public override void OnActivated(string invokedArgs, NotificationUserInput userInput, string appUserModelId)
    {
        // TODO: Handle activation
    }
}
```


## <a name="step-5-register-with-notification-platform"></a>手順 5: 通知プラットフォームに登録する

次に、通知プラットフォームに登録します。 デスクトップ ブリッジと従来の Win32 のどちらを使用するかによって、手順が異なります。 両方をサポートする場合は、両方の手順を行う必要があります (コードをフォークする必要はありません。ライブラリがすべて自動的に処理します)。


### <a name="desktop-bridge"></a>デスクトップ ブリッジ

デスクトップ ブリッジを使用する場合 (または両方をサポートする場合) は、**Package.appxmanifest** に以下を追加します。

1. **xmlns:com** のための宣言
2. **xmlns:desktop** のための宣言
3. **IgnorableNamespaces** 属性に **com** と **desktop** を追加
4. 手順 4 で取得した GUID を使用して、COM アクティベーターの **com:Extension** を追加 トーストから起動されたことがわかるように、必ず、`Arguments="-ToastActivated"` を指定します。
5. **windows.toastNotificationActivation** の **desktop:Extension** を追加して、トースト アクティベーター  CLSID (手順 4 の GUID) を宣言します。

**Package.appxmanifest**

```xml
<Package
  ...
  xmlns:com="http://schemas.microsoft.com/appx/manifest/com/windows10"
  xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
  IgnorableNamespaces="... com desktop">
  ...
  <Applications>
    <Application>
      ...
      <Extensions>

        <!--Register COM CLSID LocalServer32 registry key-->
        <com:Extension Category="windows.comServer">
          <com:ComServer>
            <com:ExeServer Executable="YourProject\YourProject.exe" Arguments="-ToastActivated" DisplayName="Toast activator">
              <com:Class Id="replaced-with-your-guid-C173E6ADF0C3" DisplayName="Toast activator"/>
            </com:ExeServer>
          </com:ComServer>
        </com:Extension>

        <!--Specify which CLSID to activate when toast clicked-->
        <desktop:Extension Category="windows.toastNotificationActivation">
          <desktop:ToastNotificationActivation ToastActivatorCLSID="replaced-with-your-guid-C173E6ADF0C3" /> 
        </desktop:Extension>

      </Extensions>
    </Application>
  </Applications>
 </Package>
```


### <a name="classic-win32"></a>従来の Win32

従来の Win32 を使用する場合 (または両方をサポートする場合) は、スタート メニューのアプリのショートカットで、アプリケーション ユーザー モデル ID (AUMID) とトースト アクティベーター CLSID (手順 4 の GUID) を宣言する必要があります。

対象の Win32 アプリを識別する一意の AUMID を選択します。 これは通常、[CompanyName].[AppName] の形式です。すべてのアプリを通じて、一意である必要があります (任意の数字を自由に追加できます)。

#### <a name="step-51-wix-installer"></a>手順 5.1: WiX インストーラー

インストーラーに WiX を使用している場合は、以下に示すように **Product.wxs** ファイルを編集して、スタート メニューのショートカットに 2 つのショートカット プロパティを追加します。 下のように、手順 4 の GUID を必ず `{}` で囲みます。

**Product.wxs**

```xml
<Shortcut Id="ApplicationStartMenuShortcut" Name="Wix Sample" Description="Wix Sample" Target="[INSTALLFOLDER]WixSample.exe" WorkingDirectory="INSTALLFOLDER">
                    
    <!--AUMID-->
    <ShortcutProperty Key="System.AppUserModel.ID" Value="YourCompany.YourApp"/>
    
    <!--COM CLSID-->
    <ShortcutProperty Key="System.AppUserModel.ToastActivatorCLSID" Value="{replaced-with-your-guid-C173E6ADF0C3}"/>
    
</Shortcut>
```

> [!IMPORTANT]
> 実際に通知を使用するためには、通常のデバッグ前に、アプリをインストーラー経由でインストールして、AUMID と CLSID を使用したスタート ショートカットを表示する必要があります。 スタート ショートカットが表示された後は、Visual Studio で F5 キーを使用してデバッグできます。


#### <a name="step-52-register-aumid-and-com-server"></a>手順 5.2: AUMID と COM サーバーを登録する

次に、どちらのインストーラーを使用する場合も、(通知 API を呼び出す前に) アプリのスタートアップ コード内で、**RegisterAumidAndComServer** メソッドを呼び出して、上記の手順 4 の通知アクティベーター クラスと AUMID を指定します。

```csharp
// Register AUMID and COM server (for Desktop Bridge apps, this no-ops)
DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("YourCompany.YourApp");
```

デスクトップ ブリッジと従来の Win32 の両方をサポートする場合も、問題なくこのメソッドを呼び出すことができます。 デスクトップ ブリッジで実行する場合、このメソッドは即座に戻ります。 コードをフォークする必要はありません。

このメソッドを使用することで、AUMID を常に提供する必要なしに、compat API を呼び出して通知を送信および管理できます。 またこのメソッドによって、COM サーバーの LocalServer32 レジストリ キーが挿入されます。


## <a name="step-6-register-com-activator"></a>手順 6: COM サーバーを登録する

デスクトップ ブリッジと従来の Win32 アプリのいずれを使用する場合も、トーストのアクティブ化を処理するためには、通知アクティベーター タイプを登録する必要があります。

アプリのスタートアップ コードで、手順 4 で作成した **NotificationActivator** クラスを次の **RegisterActivator** メソッドに渡して呼び出します。 これにより、トーストのアクティブ化を受信できるようになります。

```csharp
// Register COM server and activator type
DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();
```


## <a name="step-7-send-a-notification"></a>手順 7: 通知を送信する

通知を送信する手順は、**DesktopNotificationManagerCompat** クラスを使用して **ToastNotifier** を作成することを除き、UWP アプリとまったく同じです。 デスクトップ ブリッジと従来の Win32 の間で異なる部分は、compat ライブラリによって自動的に処理されるため、コードをフォークする必要はありません。 従来の Win32 では、**RegisterAumidAndComServer** の呼び出し時に、指定した AUMID が compat ライブラリによってキャッシュされるため、AUMID を指定するタイミングや指定するかどうかを検討する必要はありません。

> [!NOTE]
> [Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) をインストールすると、以下に示すように、生の XML ではなく、C# を使って通知を作成できます。

レガシの Windows 8.1 のトースト通知テンプレートでは、手順 4 で作成した COM 通知アクティベーターがアクティブ化されないため、以下に示すように、**ToastContent** (または XML を手作業で作成している場合は、ToastGeneric テンプレート) を必ず使用します。

> [!IMPORTANT]
> http イメージは、マニフェストにインターネット機能を持つデスクトップ ブリッジ アプリでのみサポートされます。 従来の Win32 アプリは http イメージをサポートしていないため、ローカル アプリ データにイメージをダウンロードし、それをローカルに参照する必要があります。

```csharp
// Construct the visuals of the toast (using Notifications library)
ToastContent toastContent = new ToastContent()
{
    // Arguments when the user taps body of toast
    Launch = "action=viewConversation&conversationId=5",

    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Hello world!"
                }
            }
        }
    }
};

// Create the XML document (BE SURE TO REFERENCE WINDOWS.DATA.XML.DOM)
var doc = new XmlDocument();
doc.LoadXml(toastContent.GetContent());

// And create the toast notification
var toast = new ToastNotification(doc);

// And then show it
DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);
```

> [!IMPORTANT]
> 従来の Win32 アプリでは、レガシ トースト テンプレート (ToastText02 など) を使用できません。 COM CLSID を指定すると、レガシ テンプレートのアクティブ化は失敗します。 上記のように Windows 10 ToastGeneric テンプレートを使用する必要があります。


## <a name="step-8-handling-activation"></a>手順 8: アクティブ化を処理する

ユーザーがトーストをクリックすると、**NotificationActivator** クラスの **OnActivated** メソッドが呼び出されます。

OnActivated メソッド内では、トーストで指定した引数を解析し、ユーザーが入力または選択したユーザー入力を取得したうえで、それに応じてアプリをアクティブ化できます。

> [!NOTE]
> **OnActivated** メソッドは UI スレッドでは呼び出されません。 UI スレッド操作を実行する場合は、`Application.Current.Dispatcher.Invoke(callback)` を呼び出す必要があります。

```csharp
// The GUID must be unique to your app. Create a new GUID if copying this code.
[ClassInterface(ClassInterfaceType.None)]
[ComSourceInterfaces(typeof(INotificationActivationCallback))]
[Guid("replaced-with-your-guid-C173E6ADF0C3"), ComVisible(true)]
public class MyNotificationActivator : NotificationActivator
{
    public override void OnActivated(string invokedArgs, NotificationUserInput userInput, string appUserModelId)
    {
        Application.Current.Dispatcher.Invoke(delegate
        {
            // Tapping on the top-level header launches with empty args
            if (arguments.Length == 0)
            {
                // Perform a normal launch
                OpenWindowIfNeeded();
                return;
            }

            // Parse the query string (using NuGet package QueryString.NET)
            QueryString args = QueryString.Parse(invokedArgs);

            // See what action is being requested 
            switch (args["action"])
            {
                // Open the image
                case "viewImage":

                    // The URL retrieved from the toast args
                    string imageUrl = args["imageUrl"];

                    // Make sure we have a window open and in foreground
                    OpenWindowIfNeeded();

                    // And then show the image
                    (App.Current.Windows[0] as MainWindow).ShowImage(imageUrl);

                    break;

                // Background: Quick reply to the conversation
                case "reply":

                    // Get the response the user typed
                    string msg = userInput["tbReply"];

                    // And send this message
                    SendMessage(msg);

                    // If there's no windows open, exit the app
                    if (App.Current.Windows.Count == 0)
                    {
                        Application.Current.Shutdown();
                    }

                    break;
            }
        });
    }

    private void OpenWindowIfNeeded()
    {
        // Make sure we have a window open (in case user clicked toast while app closed)
        if (App.Current.Windows.Count == 0)
        {
            new MainWindow().Show();
        }

        // Activate the window, bringing it to focus
        App.Current.Windows[0].Activate();

        // And make sure to maximize the window too, in case it was currently minimized
        App.Current.Windows[0].WindowState = WindowState.Normal;
    }
}
```

アプリが閉じている間の起動を適切にサポートするため、`App.xaml.cs` ファイル内で **OnStartup** メソッド (WPF アプリ用) を上書きして、トーストから起動しているかどうかを判定することができます。 トーストから起動している場合は、起動引数が "-ToastActivated" に指定されています。 この引数が指定されている場合、通常の起動アクティブ化コードの実行をすべて停止して、**OnActivated** コードによる起動処理が完了するのを待つ必要があります。

```csharp
protected override async void OnStartup(StartupEventArgs e)
{
    // Register AUMID, COM server, and activator
    DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("YourCompany.YourApp");
    DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();

    // If launched from a toast
    if (e.Args.Contains("-ToastActivated"))
    {
        // Our NotificationActivator code will run after this completes,
        // and will show a window if necessary.
    }

    else
    {
        // Show the window
        // In App.xaml, be sure to remove the StartupUri so that a window doesn't
        // get created by default, since we're creating windows ourselves (and sometimes we
        // don't want to create a window if handling a background activation).
        new MainWindow().Show();
    }

    base.OnStartup(e);
}
```


### <a name="activation-sequence-of-events"></a>イベントのアクティブ化シーケンス

WPF の場合、アクティブ化シーケンスは次のとおりです。

アプリが既に実行されている場合:

1. **NotificationActivator** で **OnActivated** が呼び出されます。

アプリが実行されていない場合:

1. `App.xaml.cs` で、**Args** に "-ToastActivated" を指定して **OnStartup** が呼び出されます。
2. **NotificationActivator** で **OnActivated** が呼び出されます。


### <a name="foreground-vs-background-activation"></a>フォアグラウンドとバックグラウンドのアクティブ化
デスクトップ アプリでは、フォア グラウンドとバック グラウンドのアクティブ化はいずれも、COM アクティベーターの呼び出しという同じ手順で処理されます。 ウィンドウを表示するか、ウィンドウを表示せずに作業を行うだけで終了するかは、アプリのコードによって決定されます。 したがって、トーストのコンテンツで **ActivationType** に **Background** を指定しても、動作は変わりません。


## <a name="step-9-remove-and-manage-notifications"></a>手順 9: 通知を削除および管理する

通知を削除および管理する手順は、UWP アプリと同じです。 ただし、compat ライブラリを使用して **DesktopNotificationHistoryCompat** を取得することをお勧めします。これにより、従来の Win32 を使用している場合も、AUMID を提供する必要がなくなります。

```csharp
// Remove the toast with tag "Message2"
DesktopNotificationManagerCompat.History.Remove("Message2");

// Clear all toasts
DesktopNotificationManagerCompat.History.Clear();
```


## <a name="step-10-deploying-and-debugging"></a>手順 10: 展開とデバッグ

デスクトップ ブリッジ アプリの展開とデバッグについては、「[パッケージ デスクトップ アプリの実行、デバッグ、テスト](/porting/desktop-to-uwp-debug.md)」をご覧ください。

従来の Win32 アプリを展開およびデバッグするには、通常のデバッグ前に、アプリをインストーラー経由でインストールして、AUMID と CLSID を使用したスタート ショートカットを表示する必要があります。 スタート ショートカットが表示された後は、Visual Studio で F5 キーを使用してデバッグできます。

従来の Win32 アプリに通知がまったく表示されない場合 (かつ例外がスローされない場合)、原因として、スタート ショートカットが存在しないか (インストーラー経由でアプリをインストールしてください)、コード内で使用されている AUMID とスタート ショートカットの AUMID が一致していないことが考えられます。

通知は表示されるが、アクション センターに表示されたままにならない (ポップアップを無視すると表示されなくなる) 場合は、COM アクティベーターが正しく実装されていません。

デスクトップ ブリッジ アプリと従来の Win32 アプリの両方をインストールした場合、トーストのアクティブ化を処理するときに、デスクトップ ブリッジ アプリが従来の Win32 アプリに優先することに注意してください。 そのため、従来の Win32 アプリから表示されたトーストをクリックしても、デスクトップ ブリッジ アプリが起動します。 デスクトップ ブリッジ アプリをアンインストールすると、従来の Win32 アプリがアクティブ化されます。


## <a name="known-issues"></a>既知の問題

**修正済み: トーストのクリック後、アプリがフォーカスされない**: ビルド 15063 以前では、COM サーバーをアクティブ化したときに、フォアグラウンドの権利がアプリケーションに移転されませんでした。 そのため、アプリをフォアグラウンドに移動しようとしても、点滅するのみで移動できませんでした。 この問題を解決する方法はありませんでした。 この問題は、16299 以降のビルドでは解決済みです。


## <a name="resources"></a>リソース

* [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/desktop-toasts)
* [デスクトップ アプリからのトースト通知](toast-desktop-apps.md)
* [トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)

