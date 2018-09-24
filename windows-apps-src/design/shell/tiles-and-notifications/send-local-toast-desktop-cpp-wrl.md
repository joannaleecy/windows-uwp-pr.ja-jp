---
author: andrewleader
Description: Learn how Win32 C++ WRL apps can send local toast notifications and handle the user clicking the toast.
title: デスクトップ C++ WRL アプリからのローカル トースト通知の送信
label: Send a local toast notification from desktop C++ WRL apps
template: detail.hbs
ms.author: mijacobs
ms.date: 03/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, win32, デスクトップ, トースト通知, トーストの送信, ローカル トーストの送信, デスクトップ ブリッジ, C++, cpp, c プラスプラス, WRL
ms.localizationpriority: medium
ms.openlocfilehash: a6134e65a27563f96c03880dea026bed11f46641
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4155591"
---
# <a name="send-a-local-toast-notification-from-desktop-c-wrl-apps"></a>デスクトップ C++ WRL アプリからのローカル トースト通知の送信

デスクトップ アプリ (デスクトップ ブリッジと従来の Win32) は、ユニバーサル Windows プラットフォーム (UWP) アプリと同様の対話型トースト通知を送信できます。 ただし、デスクトップ アプリの場合は、いくつかの特別な手順があります。これは、アクティブ化スキームが異なるためであり、またデスクトップ ブリッジを使用していない場合には、パッケージ ID が存在しない可能性があるためです。

> [!IMPORTANT]
> UWP アプリを作成している場合は、[UWP のドキュメント](send-local-toast.md) をご覧ください。 その他のデスクトップ言語については、[Desktop C# に関するページ](send-local-toast-desktop.md) をご覧ください。


## <a name="step-1-enable-the-windows-10-sdk"></a>手順 1: Windows 10 SDK を有効にする

Win32 アプリ向けの Windows 10 SDK がまだ有効でない場合は、まず有効にします。 主な手順は次のとおりです。

1. **[追加の依存ファイル]** に `runtimeobject.lib` を追加する
2. Windows 10 SDK をターゲットとして設定する

プロジェクトを右クリックし、**[プロパティ]** をクリックします。

上部にある **[構成]** メニューで、**[すべての構成]** を選択し、[Debug] と [Release] の両方で次の変更を行います。

**[リンカー] -> [入力]** で、**[追加の依存ファイル]** に `runtimeobject.lib` を追加します。

次に、**[全般]** の下で、**[Windows SDK バージョン]** が 10.0 以上のいずれかのバージョンであること (Windows 8.1 ではないこと) を確認します。


## <a name="step-2-copy-compat-library-code"></a>手順 2: compat ライブラリのコードをコピーする

GitHub の [DesktopNotificationManagerCompat.h](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CPP-WRL/DesktopToastsCppWrlApp/DesktopNotificationManagerCompat.h) ファイルと [DesktopNotificationManagerCompat.cpp](https://raw.githubusercontent.com/WindowsNotifications/desktop-toasts/master/CPP-WRL/DesktopToastsCppWrlApp/DesktopNotificationManagerCompat.cpp) ファイルをプロジェクトにコピーします。 compat ライブラリを使用することで、デスクトップ通知の複雑な部分の多くが抽象化されます。 次の手順では、compat ライブラリが必要です。

プリコンパイル済みヘッダーを使用している場合は、必ず `#include "stdafx.h"` を DesktopNotificationManagerCompat.cpp ファイルの最初の行として指定します。


## <a name="step-3-include-the-header-files-and-namespaces"></a>手順 3: ヘッダー ファイルと名前空間をインクルードする

compat ライブラリのヘッダー ファイル、および UWP トースト API の使用に関連するヘッダー ファイルと名前空間をインクルードします。

```cpp
#include "DesktopNotificationManagerCompat.h"
#include "NotificationActivationCallback.h"
#include <windows.ui.notifications.h>

using namespace ABI::Windows::Data::Xml::Dom;
using namespace ABI::Windows::UI::Notifications;
using namespace Microsoft::WRL;
```


## <a name="step-4-implement-the-activator"></a>手順 4: アクティベーターを実装する

ユーザーがトーストをクリックしたときにアプリが動作できるように、トーストをアクティブ化するためのハンドラーを実装する必要があります。 これは、アクション センターにトーストを継続的に表示するために必要です (トーストは、数日後、アプリが閉じているときにクリックされる可能性があります)。 このクラスは、プロジェクトの任意の位置に指定できます。

以下に示すように、UUID を含めて **INotificationActivationCallback** インターフェイスを実装し、**CoCreatableClass** を呼び出して、クラスを COM 作成可能としてフラグ設定します。 UUID は、任意のオンライン GUID ジェネレーターを使用して、一意の GUID を作成します。 アクション センターは、この GUID CLSID (クラス識別子) に基づいて、COM アクティブ化するクラスを認識します。

```cpp
// The UUID CLSID must be unique to your app. Create a new GUID if copying this code.
class DECLSPEC_UUID("replaced-with-your-guid-C173E6ADF0C3") NotificationActivator WrlSealed WrlFinal
    : public RuntimeClass<RuntimeClassFlags<ClassicCom>, INotificationActivationCallback>
{
public:
    virtual HRESULT STDMETHODCALLTYPE Activate(
        _In_ LPCWSTR appUserModelId,
        _In_ LPCWSTR invokedArgs,
        _In_reads_(dataCount) const NOTIFICATION_USER_INPUT_DATA* data,
        ULONG dataCount) override
    {
        // TODO: Handle activation
    }
};

// Flag class as COM creatable
CoCreatableClass(NotificationActivator);
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

```cpp
// Register AUMID and COM server (for Desktop Bridge apps, this no-ops)
hr = DesktopNotificationManagerCompat::RegisterAumidAndComServer(L"YourCompany.YourApp", __uuidof(NotificationActivator));
```

デスクトップ ブリッジと従来の Win32 の両方をサポートする場合も、問題なくこのメソッドを呼び出すことができます。 デスクトップ ブリッジで実行する場合、このメソッドは即座に戻ります。 コードをフォークする必要はありません。

このメソッドを使用することで、AUMID を常に提供する必要なしに、compat API を呼び出して通知を送信および管理できます。 またこのメソッドによって、COM サーバーの LocalServer32 レジストリ キーが挿入されます。


## <a name="step-6-register-com-activator"></a>手順 6: COM サーバーを登録する

デスクトップ ブリッジと従来の Win32 アプリのいずれを使用する場合も、トーストのアクティブ化を処理するためには、通知アクティベーター タイプを登録する必要があります。

アプリのスタートアップ コードで、次の **RegisterActivator**メソッドを呼び出します。 これにより、トーストのアクティブ化を受信できるようになります。

```cpp
// Register activator type
hr = DesktopNotificationManagerCompat::RegisterActivator();
```


## <a name="step-7-send-a-notification"></a>手順 7: 通知を送信する

通知を送信する手順は、**DesktopNotificationManagerCompat** を使用して **ToastNotifier** を作成することを除き、UWP アプリとまったく同じです。 デスクトップ ブリッジと従来の Win32 の間で異なる部分は、compat ライブラリによって自動的に処理されるため、コードをフォークする必要はありません。 従来の Win32 では、**RegisterAumidAndComServer** の呼び出し時に、指定した AUMID が compat ライブラリによってキャッシュされるため、AUMID を指定するタイミングや指定するかどうかを検討する必要はありません。

レガシの Windows 8.1 のトースト通知テンプレートでは、手順 4 で作成した COM 通知アクティベーターがアクティブ化されないため、以下に示すように、**ToastGeneric** バインディングを必ず使用します。

> [!IMPORTANT]
> http イメージは、マニフェストにインターネット機能を持つデスクトップ ブリッジ アプリでのみサポートされます。 従来の Win32 アプリは http イメージをサポートしていないため、ローカル アプリ データにイメージをダウンロードし、それをローカルに参照する必要があります。

```cpp
// Construct XML
ComPtr<IXmlDocument> doc;
hr = DesktopNotificationManagerCompat::CreateXmlDocumentFromString(
    L"<toast><visual><binding template='ToastGeneric'><text>Hello world</text></binding></visual></toast>",
    &doc);
if (SUCCEEDED(hr))
{
    // See full code sample to learn how to inject dynamic text, buttons, and more

    // Create the notifier
    // Classic Win32 apps MUST use the compat method to create the notifier
    ComPtr<IToastNotifier> notifier;
    hr = DesktopNotificationManagerCompat::CreateToastNotifier(&notifier);
    if (SUCCEEDED(hr))
    {
        // Create the notification itself (using helper method from compat library)
        ComPtr<IToastNotification> toast;
        hr = DesktopNotificationManagerCompat::CreateToastNotification(doc, &toast);
        if (SUCCEEDED(hr))
        {
            // And show it!
            hr = notifier->Show(toast.Get());
        }
    }
}
```

> [!IMPORTANT]
> 従来の Win32 アプリでは、レガシ トースト テンプレート (ToastText02 など) を使用できません。 COM CLSID を指定すると、レガシ テンプレートのアクティブ化は失敗します。 上記のように Windows 10 ToastGeneric テンプレートを使用する必要があります。


## <a name="step-8-handling-activation"></a>手順 8: アクティブ化を処理する

ユーザーがトースト、またはトーストのボタンをクリックすると、**NotificationActivator** クラスの **Activate** メソッドが呼び出されます。

Activate メソッド内では、トーストで指定した引数を解析し、ユーザーが入力または選択したユーザー入力を取得したうえで、それに応じてアプリをアクティブ化できます。

> [!NOTE]
> **Activate** メソッドは、メイン スレッドとは別のスレッドで呼び出されます。

```cpp
// The GUID must be unique to your app. Create a new GUID if copying this code.
class DECLSPEC_UUID("replaced-with-your-guid-C173E6ADF0C3") NotificationActivator WrlSealed WrlFinal
    : public RuntimeClass<RuntimeClassFlags<ClassicCom>, INotificationActivationCallback>
{
public: 
    virtual HRESULT STDMETHODCALLTYPE Activate(
        _In_ LPCWSTR appUserModelId,
        _In_ LPCWSTR invokedArgs,
        _In_reads_(dataCount) const NOTIFICATION_USER_INPUT_DATA* data,
        ULONG dataCount) override
    {
        std::wstring arguments(invokedArgs);
        HRESULT hr = S_OK;

        // Background: Quick reply to the conversation
        if (arguments.find(L"action=reply") == 0)
        {
            // Get the response user typed.
            // We know this is first and only user input since our toasts only have one input
            LPCWSTR response = data[0].Value;

            hr = DesktopToastsApp::SendResponse(response);
        }

        else
        {
            // The remaining scenarios are foreground activations,
            // so we first make sure we have a window open and in foreground
            hr = DesktopToastsApp::GetInstance()->OpenWindowIfNeeded();
            if (SUCCEEDED(hr))
            {
                // Open the image
                if (arguments.find(L"action=viewImage") == 0)
                {
                    hr = DesktopToastsApp::GetInstance()->OpenImage();
                }

                // Open the app itself
                // User might have clicked on app title in Action Center which launches with empty args
                else
                {
                    // Nothing to do, already launched
                }
            }
        }

        if (FAILED(hr))
        {
            // Log failed HRESULT
        }

        return S_OK;
    }

    ~NotificationActivator()
    {
        // If we don't have window open
        if (!DesktopToastsApp::GetInstance()->HasWindow())
        {
            // Exit (this is for background activation scenarios)
            exit(0);
        }
    }
};

// Flag class as COM creatable
CoCreatableClass(NotificationActivator);
```

アプリが閉じている間の起動を適切にサポートするため、WinMain 関数内で、トーストから起動しているかどうかを判定することができます。 トーストから起動している場合は、起動引数が "-ToastActivated" に指定されています。 この引数が指定されている場合、通常の起動アクティブ化コードの実行をすべて停止し、必要に応じて **NotificationActivator** によるウィンドウの起動処理が完了するのを待つ必要があります。

```cpp
// Main function
int WINAPI wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE, _In_ LPWSTR cmdLineArgs, _In_ int)
{
    RoInitializeWrapper winRtInitializer(RO_INIT_MULTITHREADED);

    HRESULT hr = winRtInitializer;
    if (SUCCEEDED(hr))
    {
        // Register AUMID and COM server (for Desktop Bridge apps, this no-ops)
        hr = DesktopNotificationManagerCompat::RegisterAumidAndComServer(L"WindowsNotifications.DesktopToastsCpp", __uuidof(NotificationActivator));
        if (SUCCEEDED(hr))
        {
            // Register activator type
            hr = DesktopNotificationManagerCompat::RegisterActivator();
            if (SUCCEEDED(hr))
            {
                DesktopToastsApp app;
                app.SetHInstance(hInstance);

                std::wstring cmdLineArgsStr(cmdLineArgs);

                // If launched from toast
                if (cmdLineArgsStr.find(TOAST_ACTIVATED_LAUNCH_ARG) != std::string::npos)
                {
                    // Let our NotificationActivator handle activation
                }

                else
                {
                    // Otherwise launch like normal
                    app.Initialize(hInstance);
                }

                app.RunMessageLoop();
            }
        }
    }

    return SUCCEEDED(hr);
}
```


### <a name="activation-sequence-of-events"></a>イベントのアクティブ化シーケンス

アクティブ化シーケンスは、次のとおりです。

アプリが既に実行されている場合:

1. **NotificationActivator** で **Activate** が呼び出されます。

アプリが実行されていない場合:

1. アプリが EXE 起動され、"-ToastActivated" というコマンド ライン引数を取得します。
2. **NotificationActivator** で **Activate** が呼び出されます。


### <a name="foreground-vs-background-activation"></a>フォアグラウンドとバックグラウンドのアクティブ化
デスクトップ アプリでは、フォア グラウンドとバック グラウンドのアクティブ化はいずれも、COM アクティベーターの呼び出しという同じ手順で処理されます。 ウィンドウを表示するか、ウィンドウを表示せずに作業を行うだけで終了するかは、アプリのコードによって決定されます。 したがって、トーストのコンテンツで **activationType** に **background** を指定しても、動作は変わりません。


## <a name="step-9-remove-and-manage-notifications"></a>手順 9: 通知を削除および管理する

通知を削除および管理する手順は、UWP アプリと同じです。 ただし、compat ライブラリを使用して **DesktopNotificationHistoryCompat** を取得することをお勧めします。これにより、従来の Win32 を使用している場合も、AUMID を提供する必要がなくなります。

```cpp
std::unique_ptr<DesktopNotificationHistoryCompat> history;
auto hr = DesktopNotificationManagerCompat::get_History(&history);
if (SUCCEEDED(hr))
{
    // Remove a specific toast
    hr = history->Remove(L"Message2");

    // Clear all toasts
    hr = history->Clear();
}
```


## <a name="step-10-deploying-and-debugging"></a>手順 10: 展開とデバッグ

デスクトップ ブリッジ アプリの展開とデバッグについては、「[パッケージ デスクトップ アプリの実行、デバッグ、テスト](/porting/desktop-to-uwp-debug.md)」をご覧ください。

従来の Win32 アプリを展開およびデバッグするには、通常のデバッグ前に、アプリをインストーラー経由でインストールして、AUMID と CLSID を使用したスタート ショートカットを表示する必要があります。 スタート ショートカットが表示された後は、Visual Studio で F5 キーを使用してデバッグできます。

従来の Win32 アプリに通知がまったく表示されない場合 (かつ例外がスローされない場合)、原因として、スタート ショートカットが存在しないか (インストーラー経由でアプリをインストールしてください)、コード内で使用されている AUMID とスタート ショートカットの AUMID が一致していないことが考えられます。

通知は表示されるが、アクション センターに表示されたままにならない (ポップアップを無視すると表示されなくなる) 場合は、COM アクティベーターが正しく実装されていません。

デスクトップ ブリッジ アプリと従来の Win32 アプリの両方をインストールした場合、トーストのアクティブ化を処理するときに、デスクトップ ブリッジ アプリが従来の Win32 アプリに優先することに注意してください。 そのため、従来の Win32 アプリから表示されたトーストをクリックしても、デスクトップ ブリッジ アプリが起動します。 デスクトップ ブリッジ アプリをアンインストールすると、従来の Win32 アプリがアクティブ化されます。

`HRESULT 0x800401f0 CoInitialize has not been called.` が発生する場合は、アプリで `CoInitialize(nullptr)` を呼び出した後に API を呼び出していることを確認してください。

compat API の呼び出し中に、`HRESULT 0x8000000e A method was called at an unexpected time.` が発生する場合は、必要な Register メソッドが呼び出されていない可能性があります (またはデスクトップ ブリッジ アプリの場合、現在、デスクトップ ブリッジのコンテキストでアプリが実行されていません)。

多数の `unresolved external symbol` コンパイル エラーが発生する場合、手順 1 で **[追加の依存ファイル]** に `runtimeobject.lib` を追加していない (または [Debug] の構成にのみ追加し、[Release] の構成には追加していない) 可能性があります。


## <a name="handling-older-versions-of-windows"></a>従来のバージョンの Windows の処理

Windows 8.1 以下をサポートする場合は、実行時に Windows 10 を実行しているかどうかを確認した後、**DesktopNotificationManagerCompat** API の呼び出しや、ToastGeneric トースト通知の送信を行います。

トースト通知は Windows 8 で導入されましたが、ToastText01 などの[レガシ トースト テンプレート](https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh761494(v=win.10))が使用されていました。 トーストは短時間のポップアップにすぎず、継続的に表示されるものではなかったため、**ToastNotification** クラスのインメモリ **Activated** イベントによって処理されていました。 Windows 10 では、[対話型の ToastGeneric トースト](adaptive-interactive-toasts.md) が導入され、さらに通知が数日間継続して表示されるアクション センターが導入されました。 アクション センターの導入には、トーストが作成から数日後もアクティブ化できるように、COM アクティベーターの導入が必須でした。

| OS | ToastGeneric | COM アクティベーター | レガシ トースト テンプレート |
| -- | ------------ | ------------- | ---------------------- |
| Windows 10 | サポート対象 | サポート対象 | サポート対象 (ただし COM サーバーをアクティブ化しない) |
| Windows 8.1 / 8 | 該当せず | 該当せず | サポート対象 |
| Windows 7 以下 | 該当せず | なし | 該当せず |

Windows 10 で実行しているかどうかを確認するには、`<VersionHelpers.h>` ヘッダーをインクルードし、**IsWindows10OrGreater** メソッドを確認します。 これが true を返す場合は、続いてこのドキュメントで説明されているすべてのメソッドを呼び出してください。 

```cpp
#include <VersionHelpers.h>

if (IsWindows10OrGreater())
{
    // Running Windows 10, continue with sending Windows 10 toasts!
}
```


## <a name="known-issues"></a>既知の問題

**修正済み: トーストのクリック後、アプリがフォーカスされない**: ビルド 15063 以前では、COM サーバーをアクティブ化したときに、フォアグラウンドの権利がアプリケーションに移転されませんでした。 そのため、アプリをフォアグラウンドに移動しようとしても、点滅するのみで移動できませんでした。 この問題を解決する方法はありませんでした。 この問題は、16299 以降のビルドでは解決済みです。


## <a name="resources"></a>リソース

* [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/desktop-toasts)
* [デスクトップ アプリからのトースト通知](toast-desktop-apps.md)
* [トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)