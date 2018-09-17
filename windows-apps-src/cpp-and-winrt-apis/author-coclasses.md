---
author: stevewhims
description: C++/WinRT で役立つ従来の COM コンポーネントを作成する Windows ランタイム クラスを作成することもでき、同様です。
title: C++ に COM コンポーネントの作成/WinRT
ms.author: stwhi
ms.date: 09/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、作成者、COM、コンポーネント
ms.localizationpriority: medium
ms.openlocfilehash: 729cfae39f302ae6b5bae275d9e28a39f3d9503b
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3985783"
---
# <a name="author-com-components-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>COM コンポーネントを作成[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

C++/WinRT は、Windows ランタイム クラスを作成することもでき、同様、クラシック コンポーネント オブジェクト モデル (COM) コンポーネント (またはコクラス) を作成するために役立ちます。 貼り付ける場合をテストする非常に単純な図では、ここでは、`main.cpp`の新しい**Windows コンソール アプリケーション (、C++/WinRT)** プロジェクトです。

```cppwinrt
// main.cpp : Defines the entry point for the console application.
#include "pch.h"

using namespace winrt;

int main()
{
    init_apartment();

    struct MyCoclass : winrt::implements<MyCoclass, IPersist>
    {
        HRESULT STDMETHODCALLTYPE GetClassID(CLSID* id) noexcept override
        {
            *id = IID_IPersist; // Doesn't matter what we return, for this example.
            return S_OK;
        }
    };

    auto mycoclass_instance{ winrt::make<MyCoclass>() };
    CLSID id{};
    winrt::check_hresult(mycoclass_instance->GetClassID(&id));
}
```

」もご覧ください[コンポーネントを利用し、において、C++/WinRT](consume-com.md)します。

## <a name="a-more-realistic-and-interesting-example"></a>現実的で興味深い例

このトピックの残りの部分では、C++ を使用する最小限に抑えながらコンソール アプリケーション プロジェクトを作成/WinRT コクラスとクラスの基本的なファクトリを実装します。 アプリケーションの例は、それに対するコールバックのボタンを含むトースト通知を配信する方法を示しています、コクラス (これは**INotificationActivationCallback** COM インターフェイスを実装) により、アプリケーションを起動しと呼ばれるタイミング ユーザートースト通知では、そのボタンをクリックします。

トースト通知の機能領域についての詳しい背景は、[ローカル トースト通知の送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)で入手できます。 いずれのドキュメントのセクションのコード例を使用して、C++/WinRT、ただしをお勧めしますここに示すようにコードを希望します。

## <a name="create-a-windows-console-application-project-toastandcallback"></a>Windows コンソール アプリケーション プロジェクト (ToastAndCallback) を作成します。

まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。 **Visual C**を作成 > **Windows デスクトップ** > **Windows コンソール アプリケーション (、C++/WinRT)** プロジェクト、および*ToastAndCallback*名前を付けます。

開いている`main.cpp`、および削除を使用して、ディレクティブ プロジェクト テンプレートを生成します。 自分の場所で (これにより、ライブラリ、ヘッダーと型名が必要ですが) 次のコードを貼り付けます。

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

C++/cli/winrt では、実装するコクラス、およびクラス ファクトリ、 [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)の基本構造体から派生します。 直後に、次の 3 つの using ディレクティブを上に示した (前に`main`)、トースト通知 COM アクティベーター コンポーネントを実装するには、このコードを貼り付けます。

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

上記のコクラスの実装に示すは同じパターンに従います[において、C++ Api の作成/WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class)します。 Windows ランタイム インターフェイス (インターフェイスはすべて最終的に[**IInspectable**](https://msdn.microsoft.com/library/br205821)から派生した) が、COM インターフェイス (最終的に[**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509)から派生したインターフェイス) を実装するだけでなく、この手法を使用することに注意してください。

上記のコードでコクラスは、 **INotificationActivationCallback::Activate**メソッドは、ユーザーがトースト通知をコールバック ボタンをクリックしたときに呼び出される関数を実装します。 コクラスのインスタンスを作成する必要があるし、 **IClassFactory::CreateInstance**関数のジョブは前に、この関数を呼び出すことができます。

実装しましたコクラス、通知の場合、 *COM アクティベーター*と呼ばれ、そのクラス id (CLSID) の形式では、`callback_guid`種類の識別子 ( **GUID**) 上に表示されます。 使用しますその識別子後で、スタート メニューのショートカットと Windows レジストリ エントリの形式でします。 COM アクティベーター CLSID、およびその関連付けられている COM サーバー (ここでは開発中の実行可能ファイルへのパス) へのパスは、トースト通知が、コールバックのボタンがクリックされたときのインスタンスを作成するクラスを認識するためのメカニズム (かどうか、通知がクリックされるアクション センターにまたはされません)。

## <a name="best-practices-for-implementing-com-methods"></a>COM メソッドを実装するためのベスト プラクティス

エラー処理とリソース管理のための手法では、手の手でを移動できます。 便利でエラー コードよりも例外を使用するは実用的です。 リソース取得-は-初期化 (RAII) の手法を使用する場合しするを回避するエラー コードを明示的に確認して、リソースを明示的に解放します。 このような明示的なチェックは必要に応じてより複雑なコードを行い、非表示にする場所はたくさんのバグが提供します。 代わりに、RAII を使用し、例外のキャッチとスローします。 これにより、リソースの割り当ては例外安全なと、コードは簡単です。

ただし、COM メソッドの実装をエスケープする例外を許可する照準します。 使用して行うことができます、 `noexcept` 、COM メソッドで指定子。 メソッドが終了する前にそれらを処理する限り、例外をスローを任意の場所、メソッドの呼び出しグラフ内の ok です。 使用する場合`noexcept`、メソッドをエスケープする例外を許可する場合は、アプリケーションを終了します。

## <a name="add-helper-types-and-functions"></a>ヘルパー型と関数を追加します。

この手順でのコードの残りの部分は、いくつかヘルパー型と関数を使用して追加します。 前に`main`、以下を追加します。

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

## <a name="implement-the-remaining-functions-and-the-wmain-entry-point-function"></a>残りの関数と wmain エントリ ポイント関数を実装します。

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
    init_apartment();

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

アプリケーションをビルドし、少なくとも 1 回、登録され、その他のセットアップでは、コードを実行するには管理者として実行します。 管理者は、それを実行しているし、T キーを押してするかどうか ' を表示するトーストが発生します。 いずれか、または、アクション センターと、アプリケーションからポップが起動されること、トースト通知、インスタンス化され、コクラス**INotificationActivationCallback から直接**ToastAndCallback コールバック**ボタンをクリックします。: アクティブ化**メソッドを実行します。

## <a name="important-apis"></a>重要な API
* [IInspectable インターフェイス](https://msdn.microsoft.com/library/br205821)
* [IUnknown インターフェイス](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [winrt::implements 構造体テンプレート](/uwp/cpp-ref-for-winrt/implements)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の作成](/windows/uwp/cpp-and-winrt-apis/author-apis)
* [C++ に COM コンポーネントを使用/WinRT](consume-com.md)
* [ローカル トースト通知の送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)
