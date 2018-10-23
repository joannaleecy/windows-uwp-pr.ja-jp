---
author: stevewhims
description: C++/WinRT に役立つ従来の COM コンポーネントを作成する Windows ランタイム クラスを作成することもでき、同様です。
title: C++/WinRT での COM コンポーネントの作成
ms.author: stwhi
ms.date: 09/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、作成者、COM、コンポーネント
ms.localizationpriority: medium
ms.openlocfilehash: 24fd024ee25a6868b8c25b77ce31edc6662bbb6d
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5432728"
---
# <a name="author-com-components-with-cwinrt"></a><span data-ttu-id="a1a2d-104">C++/WinRT での COM コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="a1a2d-104">Author COM components with C++/WinRT</span></span>

<span data-ttu-id="a1a2d-105">[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)する Windows ランタイム クラスを作成することもでき、同様に、従来コンポーネント オブジェクト モデル (COM) コンポーネント (またはコクラス) を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-105">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) can help you to author classic Component Object Model (COM) components (or coclasses), just as it helps you to author Windows Runtime classes.</span></span> <span data-ttu-id="a1a2d-106">コードを貼り付ける場合をテストする単純な図を次に示します、`pch.h`と`main.cpp`新しい**Windows コンソール アプリケーション (、C++/WinRT)** プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-106">Here's a simple illustration, which you can test out if you paste the code into the `pch.h` and `main.cpp` of a new **Windows Console Application (C++/WinRT)** project.</span></span>

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

<span data-ttu-id="a1a2d-107">」もご覧ください[コンポーネントを消費し、c++/WinRT](consume-com.md)します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-107">Also see [Consume COM components with C++/WinRT](consume-com.md).</span></span>

## <a name="a-more-realistic-and-interesting-example"></a><span data-ttu-id="a1a2d-108">現実的で興味深い例</span><span class="sxs-lookup"><span data-stu-id="a1a2d-108">A more realistic and interesting example</span></span>

<span data-ttu-id="a1a2d-109">このトピックの残りの部分は、C++ を使用する最小限に抑えながらコンソール アプリケーション プロジェクトの作成について説明します/WinRT (COM コンポーネント、または COM クラス) の基本的なコクラスとクラスのファクトリを実装します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-109">The remainder of this topic walks through creating a minimal console application project that uses C++/WinRT to implement a basic coclass (COM component, or COM class) and class factory.</span></span> <span data-ttu-id="a1a2d-110">アプリケーションの例は、コールバックのボタンを含むトースト通知を配信する方法を示していて、(これは**INotificationActivationCallback** COM インターフェイスを実装) コクラスにより、アプリケーションを起動しと呼ばれるタイミング ユーザートーストのボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-110">The example application shows how to deliver a toast notification with a callback button on it, and the coclass (which implements the **INotificationActivationCallback** COM interface) allows the application to be launched and called back when the user clicks that button on the toast.</span></span>

<span data-ttu-id="a1a2d-111">トースト通知の機能領域についての詳しい背景は、[ローカル トースト通知の送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)で入手できます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-111">More background about the toast notification feature area can be found at [Send a local toast notification](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast).</span></span> <span data-ttu-id="a1a2d-112">ドキュメントのセクションのコード例を使用して、C++/WinRT、ただし、これをお勧めしますここに示すようにコードを希望します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-112">None of the code examples in that section of the documentation use C++/WinRT, though, so we recommend that you prefer the code shown in this topic.</span></span>

## <a name="create-a-windows-console-application-project-toastandcallback"></a><span data-ttu-id="a1a2d-113">Windows コンソール アプリケーション プロジェクト (ToastAndCallback) を作成します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-113">Create a Windows Console Application project (ToastAndCallback)</span></span>

<span data-ttu-id="a1a2d-114">まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-114">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="a1a2d-115">**Visual C**を作成 > **Windows デスクトップ** > **Windows コンソール アプリケーション (、C++/WinRT)** プロジェクト、および*ToastAndCallback*名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-115">Create a **Visual C++** > **Windows Desktop** > **Windows Console Application (C++/WinRT)** project, and name it *ToastAndCallback*.</span></span>

<span data-ttu-id="a1a2d-116">開いている`pch.h`、し、追加`#include <unknwn.h>`する前には、c++/WinRT ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-116">Open `pch.h`, and add `#include <unknwn.h>` before the includes for any C++/WinRT headers.</span></span>

```cppwinrt
// pch.h
#pragma once
#include <unknwn.h>
#include <winrt/Windows.Foundation.h>
```

<span data-ttu-id="a1a2d-117">開いている`main.cpp`、削除を使ってディレクティブ プロジェクト テンプレートを生成するとします。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-117">Open `main.cpp`, and remove the using-directives that the project template generates.</span></span> <span data-ttu-id="a1a2d-118">自分の場所で (これにより、ライブラリ、ヘッダーと型名が必要ですが) 次のコードを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-118">In their place, paste the following code (which gives us the libs, headers, and type names that we need).</span></span>

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

## <a name="implement-the-coclass-and-class-factory"></a><span data-ttu-id="a1a2d-119">コクラスとクラスのファクトリを実装します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-119">Implement the coclass and class factory</span></span>

<span data-ttu-id="a1a2d-120">C++/WinRT、実装するコクラス、およびクラスのファクトリを[**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)の基本構造体から派生させることです。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-120">In C++/WinRT, you implement coclasses, and class factories, by deriving from the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct.</span></span> <span data-ttu-id="a1a2d-121">直後に、次の 3 つの using ディレクティブを上に示した (前に`main`)、トースト通知 COM アクティベーター コンポーネントを実装するには、このコードを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-121">Immediately after the three using-directives shown above (and before `main`), paste this code to implement your toast notification COM activator component.</span></span>

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

<span data-ttu-id="a1a2d-122">上記のコクラスの実装に依存して、同じパターンに示す[において、C++ Api の作成/WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class)します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-122">The implementation of the coclass above follows the same pattern that's demonstrated in [Author APIs with C++/WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class).</span></span> <span data-ttu-id="a1a2d-123">そのため、COM インターフェイスとしての Windows ランタイム インターフェイスを実装するのに同じ手法を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-123">So, you can use the same technique to implement COM interfaces as well as Windows Runtime interfaces.</span></span> <span data-ttu-id="a1a2d-124">COM コンポーネントと Windows ランタイム クラス、インターフェイス経由でその機能を公開します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-124">COM components and Windows Runtime classes expose their features via interfaces.</span></span> <span data-ttu-id="a1a2d-125">すべての COM インターフェイスは、最終的に[**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509)インターフェイスから派生します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-125">Every COM interface ultimately derives from the [**IUnknown interface**](https://msdn.microsoft.com/library/windows/desktop/ms680509) interface.</span></span> <span data-ttu-id="a1a2d-126">Windows ランタイムは COM に基づいて&mdash;1 つの区別されている Windows ランタイム インターフェイスは、最終的に[**IInspectable インターフェイス**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)から派生 (および**IUnknown**から派生した**IInspectable** )。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-126">The Windows Runtime is based on COM&mdash;one distinction being that Windows Runtime interfaces ultimately derive from the [**IInspectable interface**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (and **IInspectable** derives from **IUnknown**).</span></span>

<span data-ttu-id="a1a2d-127">上記のコードでコクラスは、 **INotificationActivationCallback::Activate**メソッドは、ユーザーがトースト通知をコールバック ボタンをクリックしたときに呼び出される関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-127">In the coclass in the code above, we implement the **INotificationActivationCallback::Activate** method, which is the function that's called when the user clicks the callback button on a toast notification.</span></span> <span data-ttu-id="a1a2d-128">コクラスのインスタンスを作成する必要があるし、 **IClassFactory::CreateInstance**関数のジョブは前に、この関数を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-128">But before that function can be called, an instance of the coclass needs to be created, and that's the job of the **IClassFactory::CreateInstance** function.</span></span>

<span data-ttu-id="a1a2d-129">実装しましたコクラス、通知の場合、 *COM アクティベーター*と呼ばれの形式で、クラス id (CLSID) がある、`callback_guid`種類の識別子 ( **GUID**) 上に表示されます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-129">The coclass that we just implemented is known as the *COM activator* for notifications, and it has its class id (CLSID) in the form of the `callback_guid` identifier (of type **GUID**) that you see above.</span></span> <span data-ttu-id="a1a2d-130">使用しますその識別子後で、スタート メニューのショートカット、Windows レジストリ エントリの形式でします。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-130">We'll be using that identifier later, in the form of a Start menu shortcut and a Windows Registry entry.</span></span> <span data-ttu-id="a1a2d-131">COM アクティベーター CLSID とその関連 COM サーバー (ここで開発中の実行可能ファイルへのパス) へのパスは、トースト通知が、コールバックのボタンがクリックされたときのインスタンスを作成するクラスを認識するためのメカニズム (かどうか、通知がクリックされたアクション センターでまたはされません)。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-131">The COM activator CLSID, and the path to its associated COM server (which is the path to the executable that we're building here) is the mechanism by which a toast notification knows what class to create an instance of when its callback button is clicked (whether the notification is clicked in Action Center or not).</span></span>

## <a name="best-practices-for-implementing-com-methods"></a><span data-ttu-id="a1a2d-132">COM メソッドを実装するためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="a1a2d-132">Best practices for implementing COM methods</span></span>

<span data-ttu-id="a1a2d-133">エラー処理とリソース管理のための手法では、手の手でを移動できます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-133">Techniques for error handling and for resource management can go hand-in-hand.</span></span> <span data-ttu-id="a1a2d-134">便利でエラー コードよりも例外を使用するは実用的をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-134">It's more convenient and practical to use exceptions than error codes.</span></span> <span data-ttu-id="a1a2d-135">リソース取得-は-初期化 (RAII) イディオムを使用している場合するを回避するのエラー コードを明示的にチェックとリソースを明示的に解放します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-135">And if you employ the resource-acquisition-is-initialization (RAII) idiom, then you can avoid explicitly checking for error codes and then explicitly releasing resources.</span></span> <span data-ttu-id="a1a2d-136">このような明示的なチェックは必要に応じてより複雑なコードを行い、非表示にする場所はたくさんのバグができます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-136">Such explicit checks make your code more convoluted than necessary, and it gives bugs plenty of places to hide.</span></span> <span data-ttu-id="a1a2d-137">代わりに、RAII を使用し、例外のスロー/キャッチします。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-137">Instead, use RAII, and throw/catch exceptions.</span></span> <span data-ttu-id="a1a2d-138">これにより、リソースの割り当ては例外安全なと、コードは簡単です。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-138">That way, your resource allocations are exception-safe, and your code is simple.</span></span>

<span data-ttu-id="a1a2d-139">ただし、COM メソッドの実装をエスケープする例外を許可照準します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-139">However, you mustn't allow exceptions to escape your COM method implementations.</span></span> <span data-ttu-id="a1a2d-140">使用して行うことができます、 `noexcept` 、COM メソッドで指定子。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-140">You can ensure that by using the `noexcept` specifier on your COM methods.</span></span> <span data-ttu-id="a1a2d-141">メソッドが終了する前にそれらを処理する限り、例外をスローを任意の場所、メソッドの呼び出しグラフ内の ok です。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-141">It's ok for exceptions to be thrown anywhere in the call graph of your method, as long as you handle them before your method exits.</span></span> <span data-ttu-id="a1a2d-142">使用する場合`noexcept`、メソッドをエスケープする例外を許可する場合、アプリは終了します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-142">If you use `noexcept`, but you then allow an exception to escape your method, then your application will terminate.</span></span>

## <a name="add-helper-types-and-functions"></a><span data-ttu-id="a1a2d-143">ヘルパー型と関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-143">Add helper types and functions</span></span>

<span data-ttu-id="a1a2d-144">この手順のコードの残りの部分は、いくつかヘルパー型と関数を使用して追加します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-144">In this step, we'll add some helper types and functions that the rest of the code makes use of.</span></span> <span data-ttu-id="a1a2d-145">前に`main`、以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-145">So, before `main`, add the following.</span></span>

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

## <a name="implement-the-remaining-functions-and-the-wmain-entry-point-function"></a><span data-ttu-id="a1a2d-146">残りの関数と wmain エントリ ポイントの関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-146">Implement the remaining functions, and the wmain entry point function</span></span>

<span data-ttu-id="a1a2d-147">プロジェクト テンプレートを生成する`main`するための関数です。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-147">The project template generates a `main` function for you.</span></span> <span data-ttu-id="a1a2d-148">削除する`main`機能、その場所に、登録情報、コクラスを登録するコードが含まれており、次のコードを貼り付け、アプリケーションのコールバックのトーストを提供します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-148">Delete that `main` function, and in its place paste this code listing, which includes code to register your coclass, and then to deliver a toast capable of calling back your application.</span></span>

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

## <a name="how-to-test-the-example-application"></a><span data-ttu-id="a1a2d-149">サンプル アプリケーションをテストする方法</span><span class="sxs-lookup"><span data-stu-id="a1a2d-149">How to test the example application</span></span>

<span data-ttu-id="a1a2d-150">アプリケーションをビルドし、少なくとも 1 回、登録とその他のセットアップでは、コードを実行するには管理者として実行します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-150">Build the application, and then run it at least once as Administrator to cause the registration, and other setup, code to run.</span></span> <span data-ttu-id="a1a2d-151">管理者は、それを実行しているし、T キーを押してするかどうか ' を表示するトーストが発生します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-151">Whether or not you're running it as Administrator, then press 'T' to cause a toast to be displayed.</span></span> <span data-ttu-id="a1a2d-152">か、または、アクション センターと、アプリケーションからの pop が起動されること、トースト通知、インスタンス化、コクラス**INotificationActivationCallback から直接**ToastAndCallback コールバック**のボタンをクリックします。: アクティブ化**メソッドを実行します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-152">You can then click the **Call back ToastAndCallback** button either directly from the toast notification that pops up, or from the Action Center, and your application will be launched, the coclass instantiated, and the **INotificationActivationCallback::Activate** method executed.</span></span>

## <a name="in-process-com-server"></a><span data-ttu-id="a1a2d-153">プロセス内での COM サーバー</span><span class="sxs-lookup"><span data-stu-id="a1a2d-153">In-process COM server</span></span>

<span data-ttu-id="a1a2d-154">上記の*ToastAndCallback*例のアプリはローカル (または、アウト プロセス) の COM サーバーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-154">The *ToastAndCallback* example app above functions as a local (or out-of-process) COM server.</span></span> <span data-ttu-id="a1a2d-155">これにより、表示[LocalServer32](/windows/desktop/com/localserver32)レジストリ キーを使ってそのコクラスの CLSID を登録することです。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-155">This is indicated by the [LocalServer32](/windows/desktop/com/localserver32) Windows Registry key that you use to register the CLSID of its coclass.</span></span> <span data-ttu-id="a1a2d-156">ローカルの COM サーバーのホスト実行可能なバイナリ内でその coclass(es) (、 `.exe`)。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-156">A local COM server hosts its coclass(es) inside an executable binary (an `.exe`).</span></span>

<span data-ttu-id="a1a2d-157">また (と間違いなくより可能性があります)、ダイナミック リンク ライブラリ内の coclass(es) をホストすることもできます (、 `.dll`)。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-157">Alternatively (and arguably more likely), you can choose to host your coclass(es) inside a dynamic-link library (a `.dll`).</span></span> <span data-ttu-id="a1a2d-158">DLL の形式での COM サーバーは、プロセス内での COM サーバーと呼ば[InprocServer32](/windows/desktop/com/inprocserver32) Windows レジストリ キーを使用して登録されている Clsid によって表示されます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-158">A COM server in the form of a DLL is known as an in-process COM server, and it's indicated by CLSIDs being registered by using the [InprocServer32](/windows/desktop/com/inprocserver32) Windows Registry key.</span></span>

### <a name="create-a-dynamic-link-library-dll-project"></a><span data-ttu-id="a1a2d-159">ダイナミック リンク ライブラリ (DLL) プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-159">Create a Dynamic-Link Library (DLL) project</span></span>

<span data-ttu-id="a1a2d-160">Microsoft Visual Studio で新しいプロジェクトを作成して、プロセス内での COM サーバーを作成するタスクを開始することができます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-160">You can begin the task of creating an in-process COM server by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="a1a2d-161">**Visual C**を作成 > **Windows デスクトップ** > **ダイナミック リンク ライブラリ (DLL)** プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-161">Create a **Visual C++** > **Windows Desktop** > **Dynamic-Link Library (DLL)** project.</span></span>

<span data-ttu-id="a1a2d-162">C + を追加する//winrt サポート、新しいプロジェクトを説明した手順をで[を追加するには、C++ の Windows デスクトップ アプリケーション プロジェクトを変更する/WinRT サポート](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-162">To add C++/WinRT support to the new project, follow the steps described in [Modify a Windows Desktop application project to add C++/WinRT support](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support).</span></span>

### <a name="implement-the-coclass-class-factory-and-in-proc-server-exports"></a><span data-ttu-id="a1a2d-163">コクラス、クラスの出荷時のインプロセス サーバーのエクスポートを実装します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-163">Implement the coclass, class factory, and in-proc server exports</span></span>

<span data-ttu-id="a1a2d-164">開いている`dllmain.cpp`、次に示すコードの登録情報を追加します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-164">Open `dllmain.cpp`, and add to it the code listing shown below.</span></span>

<span data-ttu-id="a1a2d-165">C + を実装する DLL を既にあるかどうかは + WinRT Windows ランタイム クラス、次に示す**DllCanUnloadNow**関数を既に必要があります。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-165">If you already have a DLL that implements C++/WinRT Windows Runtime classes, then you'll already have the **DllCanUnloadNow** function shown below.</span></span> <span data-ttu-id="a1a2d-166">その DLL をコクラスを追加する場合は、 **DllGetClassObject**関数を追加できます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-166">If you want to add coclasses to that DLL, then you can add the **DllGetClassObject** function.</span></span>

<span data-ttu-id="a1a2d-167">場合との互換性を維持する既存の[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)コードがない、コードから WRL 部分を削除することができます。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-167">If don't have existing [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) code that you want to stay compatible with, then you can remove the WRL parts from the code shown.</span></span>

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

### <a name="support-for-weak-references"></a><span data-ttu-id="a1a2d-168">弱参照のサポート</span><span class="sxs-lookup"><span data-stu-id="a1a2d-168">Support for weak references</span></span>

<span data-ttu-id="a1a2d-169">」もご覧ください[弱参照 C++/WinRT](weak-references.md#weak-references-in-cwinrt)します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-169">Also see [Weak references in C++/WinRT](weak-references.md#weak-references-in-cwinrt).</span></span>

<span data-ttu-id="a1a2d-170">C++/WinRT (具体的には、 [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)基本構造体テンプレート) [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource)はの実装する場合は、型が[**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (または**IInspectable**から派生したすべてのインターフェイス) を実装します。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-170">C++/WinRT (specifically, the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct template) implements [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource) for you if your type implements [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (or any interface that derives from **IInspectable**).</span></span>

<span data-ttu-id="a1a2d-171">**IWeakReferenceSource**と[**IWeakReference**](/windows/desktop/api/weakreference/nn-weakreference-iweakreference) Windows ランタイム型のように設計されているためにです。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-171">This is because **IWeakReferenceSource** and [**IWeakReference**](/windows/desktop/api/weakreference/nn-weakreference-iweakreference) are designed for Windows Runtime types.</span></span> <span data-ttu-id="a1a2d-172">そのため、するに対して有効にできます弱参照サポート、コクラス **:iinspectable** (または**IInspectable**から派生するインターフェイス) を実装に追加するだけです。</span><span class="sxs-lookup"><span data-stu-id="a1a2d-172">So, you can turn on weak reference support for your coclass simply by adding **winrt::Windows::Foundation::IInspectable** (or an interface that derives from **IInspectable**) to your implementation.</span></span>

```cppwinrt
struct MyCoclass : winrt::implements<MyCoclass, IMyComInterface, winrt::Windows::Foundation::IInspectable>
{
    //  ...
};
```

## <a name="important-apis"></a><span data-ttu-id="a1a2d-173">重要な API</span><span class="sxs-lookup"><span data-stu-id="a1a2d-173">Important APIs</span></span>
* [<span data-ttu-id="a1a2d-174">IInspectable インターフェイス</span><span class="sxs-lookup"><span data-stu-id="a1a2d-174">IInspectable interface</span></span>](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)
* [<span data-ttu-id="a1a2d-175">IUnknown インターフェイス</span><span class="sxs-lookup"><span data-stu-id="a1a2d-175">IUnknown interface</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [<span data-ttu-id="a1a2d-176">winrt::implements 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="a1a2d-176">winrt::implements struct template</span></span>](/uwp/cpp-ref-for-winrt/implements)

## <a name="related-topics"></a><span data-ttu-id="a1a2d-177">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a1a2d-177">Related topics</span></span>
* [<span data-ttu-id="a1a2d-178">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="a1a2d-178">Author APIs with C++/WinRT</span></span>](/windows/uwp/cpp-and-winrt-apis/author-apis)
* [<span data-ttu-id="a1a2d-179">C++/WinRT での COM コンポーネントの使用</span><span class="sxs-lookup"><span data-stu-id="a1a2d-179">Consume COM components with C++/WinRT</span></span>](consume-com.md)
* [<span data-ttu-id="a1a2d-180">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="a1a2d-180">Send a local toast notification</span></span>](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)
