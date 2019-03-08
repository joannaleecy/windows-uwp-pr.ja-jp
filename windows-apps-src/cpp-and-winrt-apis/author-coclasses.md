---
description: C +/cli WinRT で役立つ、従来型 COM コンポーネントを作成する Windows ランタイム クラスの作成に利用すると同様です。
title: C++/WinRT での COM コンポーネントの作成
ms.date: 09/06/2018
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、プロジェクション、作成者は、COM、コンポーネント
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: e6b77f8be6c75070336ad48f0c6471fc0a824a4c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616567"
---
# <a name="author-com-components-with-cwinrt"></a>C++/WinRT での COM コンポーネントの作成

[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Windows ランタイム クラスの作成に利用すると同様に、クラシック コンポーネント オブジェクト モデル (COM) コンポーネント (またはコクラス) を作成することができます。 ここでは、単純な図にコードを貼り付ける場合をテストすることができます、`pch.h`と`main.cpp`新しい**Windows コンソール アプリケーション (C +/cli WinRT)** プロジェクト。

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

参照してください[C + での使用の COM コンポーネント/cli WinRT](consume-com.md)します。

## <a name="a-more-realistic-and-interesting-example"></a>現実的で興味深い例

このトピックの残りの部分は、C + を使用して最小限のコンソール アプリケーション プロジェクトを作成する手順について説明します/cli WinRT (COM コンポーネントまたは COM クラス) の基本的なコクラスとクラス ファクトリを実装します。 アプリケーションの例は、コールバック ボタンと、コクラスのトースト通知を配信する方法を示します (実装する、 **INotificationActivationCallback** COM インターフェイス) により、アプリケーションが起動され、呼び出されますユーザーは、トーストでそのボタンをクリックしたときにバックアップします。

さらに詳しく知り、トースト通知の機能領域をご覧[ローカル トースト通知を送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)します。 ドキュメントのセクションのコード例のいずれを使用して、C +/cli WinRT、ただし、これをお勧めこのトピックに示すようにコードを使用します。

## <a name="create-a-windows-console-application-project-toastandcallback"></a>Windows コンソール アプリケーション プロジェクト (ToastAndCallback) を作成します。

まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 作成、 **Visual C** > **Windows デスクトップ** > **Windows コンソール アプリケーション (C +/cli WinRT)** プロジェクト、および名前を付けます*ToastAndCallback*します。

オープン`pch.h`、し、追加`#include <unknwn.h>`する前が含まれますすべて C +/cli WinRT ヘッダー。

```cppwinrt
// pch.h
#pragma once
#include <unknwn.h>
#include <winrt/Windows.Foundation.h>
```

開いている`main.cpp`ディレクティブを削除を使用して、プロジェクト テンプレートを生成するとします。 代わりに、(ライブラリ、ヘッダー、および必要な型名により) 次のコードを貼り付けます。

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

## <a name="implement-the-coclass-and-class-factory"></a>コクラスとクラス ファクトリを実装します。

C++/cli WinRT、実装するコクラス、およびクラスのファクトリから派生することによって、 [ **winrt::implements** ](/uwp/cpp-ref-for-winrt/implements)基底構造体。 次の 3 つを使用して、ディレクティブは、上記の直後に (前に`main`)、トースト通知 COM のアクティベーター コンポーネントを実装するには、このコードを貼り付けます。

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

上記のコクラスの実装は」に示したのと同じパターンに従います[作成者 Api c++/cli WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class)します。 そのため、COM インターフェイスと Windows ランタイム インターフェイスを実装するために、同じ手法を使用できます。 COM コンポーネントと Windows ランタイム クラス、インターフェイスを使用してその機能を公開します。 すべての COM インターフェイスが最終的に派生、 [ **IUnknown インターフェイス**](https://msdn.microsoft.com/library/windows/desktop/ms680509)インターフェイス。 Windows ランタイムは COM に基づいて&mdash;から派生している Windows ランタイムが最終的にインターフェイス 1 つの違い、 [ **IInspectable インターフェイス**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (と**IInspectable**から派生した**IUnknown**)。

上記のコードでは、コクラスの実装、 **INotificationActivationCallback::Activate**メソッドは、ユーザーがトースト通知のコールバックのボタンをクリックしたときに呼び出される関数。 その関数を呼び出すことができます、前に、コクラスのインスタンスを作成する必要がありますの仕事です。 この、 **IClassFactory::CreateInstance**関数。

実装しましたコクラスと呼ばれる、 *COM アクティベーター*の通知、およびそれがの形式でクラス id (CLSID) がある、`callback_guid`識別子 (型の**GUID**) を上記を参照してください。 使用する識別子後で、[スタート] メニューのショートカットと Windows レジストリ エントリの形式でします。 COM アクティベーター CLSID、およびその関連付けられている COM サーバー (つまりここで作成している実行可能ファイルへのパス) へのパスは、コールバックのボタンがクリックされたときのインスタンスを作成するクラスをトースト通知が認識するメカニズム (かどうか、通知がクリックされたアクション センターか)。

## <a name="best-practices-for-implementing-com-methods"></a>COM メソッドを実装するためのベスト プラクティス

エラー処理とリソースの管理手法では、手の形に密接に連携を移動できます。 便利でエラー コードよりも例外を使用するは実用的になります。 リソースの取得-がの初期化 (RAII) の表現形式を使用する場合を回避できますエラー コードの明示的に確認し、リソースを明示的に解放します。 このような明示的なチェックは必要に応じてよりもより複雑ですが、コードを行い、場所を非表示にはたくさんのバグを提供します。 代わりに、RAII を使用して、例外のスローと catch これにより、リソースの割り当ては例外セーフと、コードは単純です。

ただし、COM メソッドの実装をエスケープする例外を許可しないでください。 使用して行うことができます、 `noexcept` COM メソッドの指定子。 メソッドが終了する前にそれらを処理する限り、メソッドの呼び出しグラフで任意の場所がスローされる例外では問題が。 使用する場合`noexcept`が、メソッドをエスケープするための例外を許可し、アプリケーションは終了します。

## <a name="add-helper-types-and-functions"></a>ヘルパー型および関数を追加します。

このステップでのコードの残りの部分は、いくつかヘルパー型および関数を使用して追加します。 前に`main`以下を追加します。

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

## <a name="implement-the-remaining-functions-and-the-wmain-entry-point-function"></a>残りの関数では、および wmain のエントリ ポイント関数を実装します。

プロジェクト テンプレートによって生成される、`main`する関数。 削除する`main`関数、およびその場所に貼り付け、コクラスを登録するコードが含まれている一覧から、このコードをクリックし、トースト、アプリケーションのコールバックの対応を配信します。

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

アプリケーションをビルドし、少なくとも 1 回の登録、およびその他のセットアップでは、コードを実行させるに管理者として実行します。 かどうか、管理者として実行しているし、T キーを押して ' を表示するトーストを発生します。 クリックすることができます、 **ToastAndCallback コールバック**ボタン、トースト通知が表示されたら、またはアクション センター、およびアプリケーションから直接起動する、インスタンス化すると、コクラスと**INotificationActivationCallback::Activate**メソッドを実行します。

## <a name="in-process-com-server"></a>インプロセス COM サーバー

*ToastAndCallback*上記の例のアプリはローカル (または、プロセス外の) COM サーバーとして機能します。 これにより、表示、 [LocalServer32](/windows/desktop/com/localserver32) Windows レジストリ キーのコクラスの CLSID を登録するために使用します。 ローカル COM サーバーのホスト実行可能ファイルのバイナリ内の coclass(es) (、 `.exe`)。

または (と可能性の高いほぼ間違いなく)、ダイナミック リンク ライブラリ内で、coclass(es) をホストすることもできます (、 `.dll`)。 DLL の形式での COM サーバーは、インプロセス COM サーバーと呼ばれ、Clsid を使用して登録されているで示された、 [InprocServer32](/windows/desktop/com/inprocserver32) Windows レジストリ キー。

### <a name="create-a-dynamic-link-library-dll-project"></a>ダイナミック リンク ライブラリ (DLL) プロジェクトを作成します。

Microsoft Visual Studio で新しいプロジェクトを作成して、インプロセス COM サーバーを作成するタスクを開始することができます。 作成、 **Visual C** > **Windows デスクトップ** > **ダイナミック リンク ライブラリ (DLL)** プロジェクト。

追加 C +/cli WinRT サポート、新しいプロジェクトに次の記載された手順[C + を追加する Windows デスクトップ アプリケーション プロジェクトを変更する/cli WinRT サポート](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。

### <a name="implement-the-coclass-class-factory-and-in-proc-server-exports"></a>コクラス、クラス ファクトリ、および、インプロセス サーバーのエクスポートを実装します。

開いている`dllmain.cpp`、し、次に示すコード リストを追加します。

C + を実装する DLL があれば/cli WinRT Windows ランタイム クラスを既にがある得られます、 **DllCanUnloadNow**次に示す関数。 コクラスをその DLL に追加するかどうかは、追加することができます、 **DllGetClassObject**関数。

場合は既存の必要はありません[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)に示すコードからパーツのコードを使用すると、互換性を維持するその、WRL を削除することができます。

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

### <a name="support-for-weak-references"></a>弱い参照のサポート

参照してください[c++ の弱い参照/cli WinRT](weak-references.md#weak-references-in-cwinrt)します。

C +/cli WinRT (具体的には、 [ **winrt::implements** ](/uwp/cpp-ref-for-winrt/implements)基底構造体のテンプレート) を実装して[ **IWeakReferenceSource** ](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource)の場合、実装の入力[ **IInspectable** ](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (または任意のインターフェイスから派生した**IInspectable**)。

これは、ため**IWeakReferenceSource**と[ **IWeakReference** ](/windows/desktop/api/weakreference/nn-weakreference-iweakreference) Windows ランタイム型用に設計されています。 そのため、できるサポートを有効に弱い参照、コクラスを追加するだけで**winrt::Windows::Foundation::IInspectable** (またはインターフェイスから派生した**IInspectable**) 実装にします。

```cppwinrt
struct MyCoclass : winrt::implements<MyCoclass, IMyComInterface, winrt::Windows::Foundation::IInspectable>
{
    //  ...
};
```

## <a name="important-apis"></a>重要な API
* [IInspectable インターフェイス](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)
* [IUnknown インターフェイス](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [winrt::implements 構造体のテンプレート](/uwp/cpp-ref-for-winrt/implements)

## <a name="related-topics"></a>関連トピック
* [C + を使用して Api を作成/cli WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis)
* [C + を使用して COM コンポーネントを使用/cli WinRT](consume-com.md)
* [ローカルのトースト通知を送信します。](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)
