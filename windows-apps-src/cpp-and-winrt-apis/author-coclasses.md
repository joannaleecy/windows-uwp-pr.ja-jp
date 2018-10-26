---
author: stevewhims
description: C++/WinRT に役立つ従来の COM コンポーネントを作成する Windows ランタイム クラスを作成することもでき、同様です。
title: C++/WinRT での COM コンポーネントの作成
ms.author: stwhi
ms.date: 09/06/2018
ms.topic: article
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、作成者、COM、コンポーネント
ms.localizationpriority: medium
ms.openlocfilehash: 82ff87e4621d7dda3c3fd37d95d3d8d7812024e6
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5562912"
---
# <a name="author-com-components-with-cwinrt"></a>C++/WinRT での COM コンポーネントの作成

[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)する Windows ランタイム クラスを作成することもでき、同様、従来コンポーネント オブジェクト モデル (COM) コンポーネント (またはコクラス) を作成することができます。 コードを貼り付ける場合をテストする単純な図を次に示します、`pch.h`と`main.cpp`の新しい**Windows コンソール アプリケーション (、C++/WinRT)** プロジェクトです。

```cppwinrt
// pch.h
#pragma once
#include <unknwn.h>
#include <winrt/Windows.Foundation.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"

struct __declspec(uuid("ddc36e02-18ac-47c4-ae17-d420eece2281")) IMyComInterface : ::IUnknown
{
    virtual HRESULT __stdcall Call() = 0;
};

using namespace winrt;
using namespace Windows::Foundation;

int main()
{
    winrt::init_apartment();

    struct MyCoclass : winrt::implements<MyCoclass, IPersist, IStringable, IMyComInterface>
    {
        HRESULT __stdcall Call() noexcept override
        {
            return S_OK;
        }

        HRESULT __stdcall GetClassID(CLSID* id) noexcept override
        {
            *id = IID_IPersist; // Doesn't matter what we return, for this example.
            return S_OK;
        }

        winrt::hstring ToString()
        {
            return L"MyCoclass as a string";
        }
    };

    auto mycoclass_instance{ winrt::make<MyCoclass>() };
    CLSID id{};
    winrt::check_hresult(mycoclass_instance->GetClassID(&id));
    winrt::check_hresult(mycoclass_instance.as<IMyComInterface>()->Call());
}
```

」もご覧ください[消費 COM コンポーネントにおいて、C++/WinRT](consume-com.md)します。

## <a name="a-more-realistic-and-interesting-example"></a>現実的で興味深い例

このトピックの残りの部分が、C++ を使用する最小限に抑えながらコンソール アプリケーション プロジェクトの作成について説明します/WinRT (COM コンポーネント、または COM クラス) の基本的なコクラスとクラス ファクトリを実装します。 アプリケーションの例は、それに対するコールバックのボタンを含むトースト通知を配信する方法を示していて、(これは**INotificationActivationCallback** COM インターフェイスを実装) コクラスにより、アプリケーションを起動すると呼ばれるタイミング ユーザートースト上のボタンをクリックします。

トースト通知の機能領域についての詳しい背景は、[ローカル トースト通知の送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)で入手できます。 いずれのドキュメントのセクションのコード例を使用して、C++/WinRT、ただしをお勧めします、ここに示すコードを希望します。

## <a name="create-a-windows-console-application-project-toastandcallback"></a>Windows コンソール アプリケーション プロジェクト (ToastAndCallback) を作成します。

まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。 **Visual C**を作成 > **Windows デスクトップ** > **Windows コンソール アプリケーション (、C++/WinRT)** プロジェクト、および*ToastAndCallback*名前を付けます。

開いている`pch.h`、追加`#include <unknwn.h>`する前に、c++ が含まれています//winrt ヘッダー。

```cppwinrt
// pch.h
#pragma once
#include <unknwn.h>
#include <winrt/Windows.Foundation.h>
```

開いている`main.cpp`、および削除を使用して、ディレクティブ プロジェクト テンプレートを生成します。 自分の場所では、(これにより、ライブラリ、ヘッダーと型名が必要ですが) 次のコードを貼り付けます。

```cppwinrt
#pragma comment(lib, "shell32")

#include <iomanip>
#include <iostream>
#include <notificationactivationcallback.h>
#include <propkey.h>
#include <propvarutil.h>
#include <shlobj.h>
#include <winrt/Windows.UI.Notifications.h>
#include <winrt/Windows.Data.Xml.Dom.h>

using namespace winrt;
using namespace Windows::Data::Xml::Dom;
using namespace Windows::UI::Notifications;
```

## <a name="implement-the-coclass-and-class-factory"></a>コクラスとクラスのファクトリを実装します。

C++/WinRT を実装するコクラス、およびクラス ファクトリ、 [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)の基本構造体から派生します。 直後に、次の 3 つの using ディレクティブを上に示した (前に`main`)、トースト通知 COM アクティベーター コンポーネントを実装するには、このコードを貼り付けます。

```cppwinrt
static constexpr GUID callback_guid // BAF2FA85-E121-4CC9-A942-CE335B6F917F
{
    0xBAF2FA85, 0xE121, 0x4CC9, {0xA9, 0x42, 0xCE, 0x33, 0x5B, 0x6F, 0x91, 0x7F}
};

std::wstring const this_app_name{ L"ToastAndCallback" };

struct callback : winrt::implements<callback, INotificationActivationCallback>
{
    HRESULT __stdcall Activate(
        LPCWSTR app,
        LPCWSTR args,
        [[maybe_unused]] NOTIFICATION_USER_INPUT_DATA const* data,
        [[maybe_unused]] ULONG count) noexcept final
    {
        try
        {
            std::wcout << this_app_name << L" has been called back from a notification." << std::endl;
            std::wcout << L"Value of the 'app' parameter is '" << app << L"'." << std::endl;
            std::wcout << L"Value of the 'args' parameter is '" << args << L"'." << std::endl;
            return S_OK;
        }
        catch (...)
        {
            return winrt::to_hresult();
        }
    }
};

struct callback_factory : implements<callback_factory, IClassFactory>
{
    HRESULT __stdcall CreateInstance(
        IUnknown* outer,
        GUID const& iid,
        void** result) noexcept final
    {
        *result = nullptr;

        if (outer)
        {
            return CLASS_E_NOAGGREGATION;
        }

        return make<callback>()->QueryInterface(iid, result);
    }

    HRESULT __stdcall LockServer(BOOL) noexcept final
    {
        return S_OK;
    }
};
```

上記のコクラスの実装に示すは同じパターンに従います[において、C++ Api の作成/WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class)します。 そのため、COM インターフェイスとしての Windows ランタイム インターフェイスを実装するのに同じ手法を使用することができます。 COM コンポーネントと Windows ランタイム クラス、インターフェイス経由でその機能を公開します。 すべての COM インターフェイスは、最終的に[**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509)インターフェイスから派生します。 Windows ランタイムは COM に基づいて&mdash;1 つの区別されている Windows ランタイム インターフェイスは、最終的に[**IInspectable インターフェイス**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)から派生 (および**IUnknown**から派生した**IInspectable** )。

上記のコードでは、コクラスで実装**INotificationActivationCallback::Activate**メソッドは、ユーザーがトースト通知をコールバック ボタンをクリックしたときに呼び出される関数されています。 コクラスのインスタンスを作成する必要があるし、 **IClassFactory::CreateInstance**関数のジョブは前に、この関数を呼び出すことができます。

実装しましたコクラス、通知の場合、 *COM アクティベーター*と呼ばれ、そのクラス id (CLSID) の形式では、`callback_guid`種類の識別子 ( **GUID**) 上に表示されます。 We'll be using that identifier later, in the form of a Start menu shortcut and a Windows Registry entry. COM アクティベーター CLSID とその関連 COM サーバー (ここで開発中の実行可能ファイルへのパス) へのパスは、トースト通知が、コールバックのボタンがクリックされたときのインスタンスを作成するクラスを認識するためのメカニズム (かどうか、通知がクリックされるアクション センターにか)。

## <a name="best-practices-for-implementing-com-methods"></a>COM メソッドを実装するためのベスト プラクティス

エラー処理とリソース管理のための手法では、手の手でを移動できます。 便利でエラー コードよりも例外を使用するは実用的です。 リソース取得-は-初期化 (RAII) の手法を使用する場合するを回避するのエラー コードを明示的にチェックとリソースを明示的に解放します。 このような明示的なチェックは必要に応じてより複雑なコードを行い、非表示にする場所はたくさんのバグが提供します。 代わりに、RAII を使用し、例外のキャッチとスローします。 これにより、リソースの割り当ては例外安全なと、コードは簡単です。

ただし、COM メソッドの実装をエスケープする例外を許可する照準します。 使用して行うことができます、 `noexcept` 、COM メソッドで指定子。 メソッドが終了する前にそれらを処理する限り、例外をスローを任意の場所、メソッドの呼び出しグラフ内の ok です。 使用する場合`noexcept`が使用している方法をエスケープする例外を許可しは、アプリケーションを終了します。

## <a name="add-helper-types-and-functions"></a>ヘルパー型と関数を追加します。

この手順でのコードの残りの部分は、いくつかヘルパー型と関数を使用して追加します。 前に、その`main`、以下を追加します。

```cppwinrt
struct prop_variant : PROPVARIANT
{
    prop_variant() noexcept : PROPVARIANT{}
    {
    }

    ~prop_variant() noexcept
    {
        clear();
    }

    void clear() noexcept
    {
        WINRT_VERIFY_(S_OK, ::PropVariantClear(this));
    }
};

struct registry_traits
{
    using type = HKEY;

    static void close(type value) noexcept
    {
        WINRT_VERIFY_(ERROR_SUCCESS, ::RegCloseKey(value));
    }

    static constexpr type invalid() noexcept
    {
        return nullptr;
    }
};

using registry_key = winrt::handle_type<registry_traits>;

std::wstring get_module_path()
{
    std::wstring path(100, L'?');
    uint32_t path_size{};
    DWORD actual_size{};

    do
    {
        path_size = static_cast<uint32_t>(path.size());
        actual_size = ::GetModuleFileName(nullptr, path.data(), path_size);

        if (actual_size + 1 > path_size)
        {
            path.resize(path_size * 2, L'?');
        }
    } while (actual_size + 1 > path_size);

    path.resize(actual_size);
    return path;
}

std::wstring get_shortcut_path()
{
    std::wstring format{ LR"(%ProgramData%\Microsoft\Windows\Start Menu\Programs\)" };
    format += (this_app_name + L".lnk");

    auto required{ ::ExpandEnvironmentStrings(format.c_str(), nullptr, 0) };
    std::wstring path(required - 1, L'?');
    ::ExpandEnvironmentStrings(format.c_str(), path.data(), required);
    return path;
}
```

## <a name="implement-the-remaining-functions-and-the-wmain-entry-point-function"></a>残りの関数と wmain エントリ ポイントの関数を実装します。

プロジェクト テンプレートを生成する`main`するための関数です。 削除する`main`機能、その場所に登録情報、コクラスを登録するコードが含まれており、次のコードを貼り付け、アプリケーションのコールバックのトーストを提供します。

```cppwinrt
void register_callback()
{
    DWORD registration{};

    winrt::check_hresult(::CoRegisterClassObject(
        callback_guid,
        make<callback_factory>().get(),
        CLSCTX_LOCAL_SERVER,
        REGCLS_SINGLEUSE,
        &registration));
}

void create_shortcut()
{
    auto link{ winrt::create_instance<IShellLink>(CLSID_ShellLink) };
    std::wstring module_path{ get_module_path() };
    winrt::check_hresult(link->SetPath(module_path.c_str()));

    auto store = link.as<IPropertyStore>();
    prop_variant value;
    winrt::check_hresult(::InitPropVariantFromString(this_app_name.c_str(), &value));
    winrt::check_hresult(store->SetValue(PKEY_AppUserModel_ID, value));
    value.clear();
    winrt::check_hresult(::InitPropVariantFromCLSID(callback_guid, &value));
    winrt::check_hresult(store->SetValue(PKEY_AppUserModel_ToastActivatorCLSID, value));

    auto file{ store.as<IPersistFile>() };
    std::wstring shortcut_path{ get_shortcut_path() };
    winrt::check_hresult(file->Save(shortcut_path.c_str(), TRUE));

    std::wcout << L"In " << shortcut_path << L", created a shortcut to " << module_path << std::endl;
}

void update_registry()
{
    std::wstring key_path{ LR"(SOFTWARE\Classes\CLSID\{????????-????-????-????-????????????})" };
    ::StringFromGUID2(callback_guid, key_path.data() + 23, 39);
    key_path += LR"(\LocalServer32)";
    registry_key key;

    winrt::check_win32(::RegCreateKeyEx(
        HKEY_CURRENT_USER,
        key_path.c_str(),
        0,
        nullptr,
        0,
        KEY_WRITE,
        nullptr,
        key.put(),
        nullptr));
    ::RegDeleteValue(key.get(), nullptr);

    std::wstring path{ get_module_path() };

    winrt::check_win32(::RegSetValueEx(
        key.get(),
        nullptr,
        0,
        REG_SZ,
        reinterpret_cast<BYTE const*>(path.c_str()),
        static_cast<uint32_t>((path.size() + 1) * sizeof(wchar_t))));

    std::wcout << L"In " << key_path << L", registered local server at " << path << std::endl;
}

void create_toast()
{
    XmlDocument xml;

    std::wstring toastPayload
    {
        LR"(
<toast>
  <visual>
    <binding template='ToastGeneric'>
      <text>)"
    };
    toastPayload += this_app_name;
    toastPayload += LR"(
      </text>
    </binding>
  </visual>
  <actions>
    <action content='Call back )";
    toastPayload += this_app_name;
    toastPayload += LR"(
' arguments='the_args' activationKind='Foreground' />
  </actions>
</toast>)";
    xml.LoadXml(toastPayload);

    ToastNotification toast{ xml };
    ToastNotifier notifier{ ToastNotificationManager::CreateToastNotifier(this_app_name) };
    notifier.Show(toast);
}

void LaunchedNormally(HANDLE, INPUT_RECORD &, DWORD &);
void LaunchedFromNotification(HANDLE, INPUT_RECORD &, DWORD &);

int wmain(int argc, wchar_t * argv[], wchar_t * /* envp */[])
{
    winrt::init_apartment();

    register_callback();

    HANDLE consoleHandle{ ::GetStdHandle(STD_INPUT_HANDLE) };
    INPUT_RECORD buffer{};
    DWORD events{};
    ::FlushConsoleInputBuffer(consoleHandle);

    if (argc == 1)
    {
        LaunchedNormally(consoleHandle, buffer, events);
    }
    else if (argc == 2 && wcscmp(argv[1], L"-Embedding") == 0)
    {
        LaunchedFromNotification(consoleHandle, buffer, events);
    }
}

void LaunchedNormally(HANDLE consoleHandle, INPUT_RECORD & buffer, DWORD & events)
{
    try
    {
        bool runningAsAdmin{ ::IsUserAnAdmin() == TRUE };
        std::wcout << this_app_name << L" is running" << (runningAsAdmin ? L" (Administrator)." : L".") << std::endl;

        if (runningAsAdmin)
        {
            create_shortcut();
            update_registry();
        }

        std::wcout << std::endl << L"Press 'T' to display a toast notification (press any other key to exit)." << std::endl;

        ::ReadConsoleInput(consoleHandle, &buffer, 1, &events);
        if (towupper(buffer.Event.KeyEvent.uChar.UnicodeChar) == L'T')
        {
            create_toast();
        }
    }
    catch (winrt::hresult_error const& e)
    {
        std::wcout << L"Error: " << e.message().c_str() << L" (" << std::hex << std::showbase << std::setw(8) << static_cast<uint32_t>(e.code()) << L")" << std::endl;
    }
}

void LaunchedFromNotification(HANDLE consoleHandle, INPUT_RECORD & buffer, DWORD & events)
{
    ::Sleep(50); // Give the callback chance to display its message.
    std::wcout << std::endl << L"Press any key to exit." << std::endl;
    ::ReadConsoleInput(consoleHandle, &buffer, 1, &events);
}
```

## <a name="how-to-test-the-example-application"></a>サンプル アプリケーションをテストする方法

アプリケーションをビルドし、少なくとも 1 回登録、およびその他のセットアップでは、コードを実行するが管理者として実行します。 管理者は、それを実行しているし、T キーを押してするかどうか ' がトーストを表示します。 か、または、アクション センターと、アプリケーションからポップが起動されること、トースト通知、インスタンス化され、コクラス**INotificationActivationCallback から直接**ToastAndCallback コールバック**のボタンをクリックします。: アクティブ化**メソッドを実行します。

## <a name="in-process-com-server"></a>プロセス内での COM サーバー

上記の*ToastAndCallback*サンプル アプリはローカル (または、アウト プロセス) の COM サーバーとして機能します。 これにより、表示[LocalServer32](/windows/desktop/com/localserver32)レジストリ キーを使ってそのコクラスの CLSID を登録することです。 ローカルの COM サーバーのホスト実行可能ファイルのバイナリ内には、その coclass(es) (、 `.exe`)。

または、間違いなく可能性があります)、coclass(es) ダイナミック リンク ライブラリ内をホストすることもできます (、 `.dll`)。 DLL の形式での COM サーバーは、プロセス内での COM サーバーと呼ば Clsid [InprocServer32](/windows/desktop/com/inprocserver32) Windows レジストリ キーを使用して登録されることが表示されます。

### <a name="create-a-dynamic-link-library-dll-project"></a>ダイナミック リンク ライブラリ (DLL) プロジェクトを作成します。

Microsoft Visual Studio で新しいプロジェクトを作成して、プロセス内での COM サーバーを作成するタスクを開始することができます。 **Visual C**を作成 > **Windows デスクトップ** > **ダイナミック リンク ライブラリ (DLL)** プロジェクトです。

C + を追加する//winrt サポート、新しいプロジェクトを説明した手順をで[を追加するには、C++ の Windows デスクトップ アプリケーション プロジェクトを変更する/WinRT サポート](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。

### <a name="implement-the-coclass-class-factory-and-in-proc-server-exports"></a>コクラス、クラスの出荷時のインプロセス サーバーのエクスポートを実装します。

開いている`dllmain.cpp`、次に示すコードの登録情報を追加します。

C + に実装する DLL を既にあるかどうかは + WinRT Windows ランタイム クラス、次に示す**DllCanUnloadNow**関数を既に必要があります。 その DLL をコクラスを追加する場合は、 **DllGetClassObject**関数を追加できます。

場合との互換性を維持する既存の[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)コードがないし、コードから WRL 部分を削除することができます。

```cppwinrt
// dllmain.cpp

struct MyCoclass : winrt::implements<MyCoclass, IPersist>
{
    HRESULT STDMETHODCALLTYPE GetClassID(CLSID* id) noexcept override
    {
        *id = IID_IPersist; // Doesn't matter what we return, for this example.
        return S_OK;
    }
};

struct __declspec(uuid("85d6672d-0606-4389-a50a-356ce7bded09"))
    MyCoclassFactory : winrt::implements<MyCoclassFactory, IClassFactory>
{
    HRESULT STDMETHODCALLTYPE CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppvObject) noexcept override
    {
        try
        {
            *ppvObject = winrt::make<MyCoclass>().get();
            return S_OK;
        }
        catch (...)
        {
            return winrt::to_hresult();
        }
    }

    HRESULT STDMETHODCALLTYPE LockServer(BOOL fLock) noexcept override
    {
        // ...
        return S_OK;
    }

    // ...
};

HRESULT __stdcall DllCanUnloadNow()
{
#ifdef _WRL_MODULE_H_
    if (!::Microsoft::WRL::Module<::Microsoft::WRL::InProc>::GetModule().Terminate())
    {
        return S_FALSE;
    }
#endif

    if (winrt::get_module_lock())
    {
        return S_FALSE;
    }

    winrt::clear_factory_cache();
    return S_OK;
}

HRESULT __stdcall DllGetClassObject(GUID const& clsid, GUID const& iid, void** result)
{
    try
    {
        *result = nullptr;

        if (clsid == __uuidof(MyCoclassFactory))
        {
            return winrt::make<MyCoclassFactory>()->QueryInterface(iid, result);
        }

#ifdef _WRL_MODULE_H_
        return ::Microsoft::WRL::Module<::Microsoft::WRL::InProc>::GetModule().GetClassObject(clsid, iid, result);
#else
        return winrt::hresult_class_not_available().to_abi();
#endif
    }
    catch (...)
    {
        return winrt::to_hresult();
    }
}
```

### <a name="support-for-weak-references"></a>弱参照サポート

」もご覧ください[弱参照 C++/WinRT](weak-references.md#weak-references-in-cwinrt)します。

C++/WinRT (具体的には、 [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)基本構造体テンプレート) [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource)はの実装する場合は、型が[**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (または**IInspectable**から派生したすべてのインターフェイス) を実装します。

これは、 **IWeakReferenceSource**と[**IWeakReference**](/windows/desktop/api/weakreference/nn-weakreference-iweakreference) Windows ランタイム型のように設計されているためにです。 そのため、するに対して有効にできます弱参照サポート、コクラス **:iinspectable** (または**IInspectable**から派生するインターフェイス) を実装に追加するだけです。

```cppwinrt
struct MyCoclass : winrt::implements<MyCoclass, IMyComInterface, winrt::Windows::Foundation::IInspectable>
{
    //  ...
};
```

## <a name="important-apis"></a>重要な API
* [IInspectable インターフェイス](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)
* [IUnknown インターフェイス](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [winrt::implements 構造体テンプレート](/uwp/cpp-ref-for-winrt/implements)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の作成](/windows/uwp/cpp-and-winrt-apis/author-apis)
* [C++/WinRT での COM コンポーネントの使用](consume-com.md)
* [ローカル トースト通知の送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)
