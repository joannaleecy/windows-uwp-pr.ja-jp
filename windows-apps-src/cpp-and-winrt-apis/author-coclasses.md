---
description: C++/WinRT は、Windows Runtime クラスを作成するのに役立つのと同様に、従来の COM コンポーネントを作成するのに役立ちます。
title: C++/WinRT での COM コンポーネントの作成
ms.date: 09/06/2018
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、プロジェクション、作成者は、COM、コンポーネント
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: e6b77f8be6c75070336ad48f0c6471fc0a824a4c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616567"
---
# <a name="author-com-components-with-cwinrt"></a><span data-ttu-id="ba517-104">C++/WinRT での COM コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="ba517-104">Author COM components with C++/WinRT</span></span>

<span data-ttu-id="ba517-105">[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Windows ランタイム クラスの作成に利用すると同様に、クラシック コンポーネント オブジェクト モデル (COM) コンポーネント (またはコクラス) を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="ba517-105">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) can help you to author classic Component Object Model (COM) components (or coclasses), just as it helps you to author Windows Runtime classes.</span></span> <span data-ttu-id="ba517-106">ここでは、単純な図にコードを貼り付ける場合をテストすることができます、`pch.h`と`main.cpp`新しい**Windows コンソール アプリケーション (C +/cli WinRT)** プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="ba517-106">Here's a simple illustration, which you can test out if you paste the code into the `pch.h` and `main.cpp` of a new **Windows Console Application (C++/WinRT)** project.</span></span>

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

<span data-ttu-id="ba517-107">参照してください[C + での使用の COM コンポーネント/cli WinRT](consume-com.md)します。</span><span class="sxs-lookup"><span data-stu-id="ba517-107">Also see [Consume COM components with C++/WinRT](consume-com.md).</span></span>

## <a name="a-more-realistic-and-interesting-example"></a><span data-ttu-id="ba517-108">現実的で興味深い例</span><span class="sxs-lookup"><span data-stu-id="ba517-108">A more realistic and interesting example</span></span>

<span data-ttu-id="ba517-109">このトピックの残りの部分は、C + を使用して最小限のコンソール アプリケーション プロジェクトを作成する手順について説明します/cli WinRT (COM コンポーネントまたは COM クラス) の基本的なコクラスとクラス ファクトリを実装します。</span><span class="sxs-lookup"><span data-stu-id="ba517-109">The remainder of this topic walks through creating a minimal console application project that uses C++/WinRT to implement a basic coclass (COM component, or COM class) and class factory.</span></span> <span data-ttu-id="ba517-110">アプリケーションの例は、コールバック ボタンと、コクラスのトースト通知を配信する方法を示します (実装する、 **INotificationActivationCallback** COM インターフェイス) により、アプリケーションが起動され、呼び出されますユーザーは、トーストでそのボタンをクリックしたときにバックアップします。</span><span class="sxs-lookup"><span data-stu-id="ba517-110">The example application shows how to deliver a toast notification with a callback button on it, and the coclass (which implements the **INotificationActivationCallback** COM interface) allows the application to be launched and called back when the user clicks that button on the toast.</span></span>

<span data-ttu-id="ba517-111">さらに詳しく知り、トースト通知の機能領域をご覧[ローカル トースト通知を送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)します。</span><span class="sxs-lookup"><span data-stu-id="ba517-111">More background about the toast notification feature area can be found at [Send a local toast notification](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast).</span></span> <span data-ttu-id="ba517-112">ドキュメントのセクションのコード例のいずれを使用して、C +/cli WinRT、ただし、これをお勧めこのトピックに示すようにコードを使用します。</span><span class="sxs-lookup"><span data-stu-id="ba517-112">None of the code examples in that section of the documentation use C++/WinRT, though, so we recommend that you prefer the code shown in this topic.</span></span>

## <a name="create-a-windows-console-application-project-toastandcallback"></a><span data-ttu-id="ba517-113">Windows コンソール アプリケーション プロジェクト (ToastAndCallback) を作成します。</span><span class="sxs-lookup"><span data-stu-id="ba517-113">Create a Windows Console Application project (ToastAndCallback)</span></span>

<span data-ttu-id="ba517-114">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="ba517-114">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="ba517-115">作成、 **Visual C** > **Windows デスクトップ** > **Windows コンソール アプリケーション (C +/cli WinRT)** プロジェクト、および名前を付けます*ToastAndCallback*します。</span><span class="sxs-lookup"><span data-stu-id="ba517-115">Create a **Visual C++** > **Windows Desktop** > **Windows Console Application (C++/WinRT)** project, and name it *ToastAndCallback*.</span></span>

<span data-ttu-id="ba517-116">オープン`pch.h`、し、追加`#include <unknwn.h>`する前が含まれますすべて C +/cli WinRT ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="ba517-116">Open `pch.h`, and add `#include <unknwn.h>` before the includes for any C++/WinRT headers.</span></span>

```cppwinrt
// pch.h
#pragma once
#include <unknwn.h>
#include <winrt/Windows.Foundation.h>
```

<span data-ttu-id="ba517-117">開いている`main.cpp`ディレクティブを削除を使用して、プロジェクト テンプレートを生成するとします。</span><span class="sxs-lookup"><span data-stu-id="ba517-117">Open `main.cpp`, and remove the using-directives that the project template generates.</span></span> <span data-ttu-id="ba517-118">代わりに、(ライブラリ、ヘッダー、および必要な型名により) 次のコードを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="ba517-118">In their place, paste the following code (which gives us the libs, headers, and type names that we need).</span></span>

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

## <a name="implement-the-coclass-and-class-factory"></a><span data-ttu-id="ba517-119">コクラスとクラス ファクトリを実装します。</span><span class="sxs-lookup"><span data-stu-id="ba517-119">Implement the coclass and class factory</span></span>

<span data-ttu-id="ba517-120">C++/cli WinRT、実装するコクラス、およびクラスのファクトリから派生することによって、 [ **winrt::implements** ](/uwp/cpp-ref-for-winrt/implements)基底構造体。</span><span class="sxs-lookup"><span data-stu-id="ba517-120">In C++/WinRT, you implement coclasses, and class factories, by deriving from the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct.</span></span> <span data-ttu-id="ba517-121">次の 3 つを使用して、ディレクティブは、上記の直後に (前に`main`)、トースト通知 COM のアクティベーター コンポーネントを実装するには、このコードを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="ba517-121">Immediately after the three using-directives shown above (and before `main`), paste this code to implement your toast notification COM activator component.</span></span>

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

<span data-ttu-id="ba517-122">上記のコクラスの実装は」に示したのと同じパターンに従います[作成者 Api c++/cli WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class)します。</span><span class="sxs-lookup"><span data-stu-id="ba517-122">The implementation of the coclass above follows the same pattern that's demonstrated in [Author APIs with C++/WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class).</span></span> <span data-ttu-id="ba517-123">そのため、COM インターフェイスと Windows ランタイム インターフェイスを実装するために、同じ手法を使用できます。</span><span class="sxs-lookup"><span data-stu-id="ba517-123">So, you can use the same technique to implement COM interfaces as well as Windows Runtime interfaces.</span></span> <span data-ttu-id="ba517-124">COM コンポーネントと Windows ランタイム クラス、インターフェイスを使用してその機能を公開します。</span><span class="sxs-lookup"><span data-stu-id="ba517-124">COM components and Windows Runtime classes expose their features via interfaces.</span></span> <span data-ttu-id="ba517-125">すべての COM インターフェイスが最終的に派生、 [ **IUnknown インターフェイス**](https://msdn.microsoft.com/library/windows/desktop/ms680509)インターフェイス。</span><span class="sxs-lookup"><span data-stu-id="ba517-125">Every COM interface ultimately derives from the [**IUnknown interface**](https://msdn.microsoft.com/library/windows/desktop/ms680509) interface.</span></span> <span data-ttu-id="ba517-126">Windows ランタイムは COM に基づいて&mdash;から派生している Windows ランタイムが最終的にインターフェイス 1 つの違い、 [ **IInspectable インターフェイス**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (と**IInspectable**から派生した**IUnknown**)。</span><span class="sxs-lookup"><span data-stu-id="ba517-126">The Windows Runtime is based on COM&mdash;one distinction being that Windows Runtime interfaces ultimately derive from the [**IInspectable interface**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (and **IInspectable** derives from **IUnknown**).</span></span>

<span data-ttu-id="ba517-127">上記のコードでは、コクラスの実装、 **INotificationActivationCallback::Activate**メソッドは、ユーザーがトースト通知のコールバックのボタンをクリックしたときに呼び出される関数。</span><span class="sxs-lookup"><span data-stu-id="ba517-127">In the coclass in the code above, we implement the **INotificationActivationCallback::Activate** method, which is the function that's called when the user clicks the callback button on a toast notification.</span></span> <span data-ttu-id="ba517-128">その関数を呼び出すことができます、前に、コクラスのインスタンスを作成する必要がありますの仕事です。 この、 **IClassFactory::CreateInstance**関数。</span><span class="sxs-lookup"><span data-stu-id="ba517-128">But before that function can be called, an instance of the coclass needs to be created, and that's the job of the **IClassFactory::CreateInstance** function.</span></span>

<span data-ttu-id="ba517-129">実装しましたコクラスと呼ばれる、 *COM アクティベーター*の通知、およびそれがの形式でクラス id (CLSID) がある、`callback_guid`識別子 (型の**GUID**) を上記を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ba517-129">The coclass that we just implemented is known as the *COM activator* for notifications, and it has its class id (CLSID) in the form of the `callback_guid` identifier (of type **GUID**) that you see above.</span></span> <span data-ttu-id="ba517-130">使用する識別子後で、[スタート] メニューのショートカットと Windows レジストリ エントリの形式でします。</span><span class="sxs-lookup"><span data-stu-id="ba517-130">We'll be using that identifier later, in the form of a Start menu shortcut and a Windows Registry entry.</span></span> <span data-ttu-id="ba517-131">COM アクティベーター CLSID、およびその関連付けられている COM サーバー (つまりここで作成している実行可能ファイルへのパス) へのパスは、コールバックのボタンがクリックされたときのインスタンスを作成するクラスをトースト通知が認識するメカニズム (かどうか、通知がクリックされたアクション センターか)。</span><span class="sxs-lookup"><span data-stu-id="ba517-131">The COM activator CLSID, and the path to its associated COM server (which is the path to the executable that we're building here) is the mechanism by which a toast notification knows what class to create an instance of when its callback button is clicked (whether the notification is clicked in Action Center or not).</span></span>

## <a name="best-practices-for-implementing-com-methods"></a><span data-ttu-id="ba517-132">COM メソッドを実装するためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="ba517-132">Best practices for implementing COM methods</span></span>

<span data-ttu-id="ba517-133">エラー処理とリソースの管理手法では、手の形に密接に連携を移動できます。</span><span class="sxs-lookup"><span data-stu-id="ba517-133">Techniques for error handling and for resource management can go hand-in-hand.</span></span> <span data-ttu-id="ba517-134">便利でエラー コードよりも例外を使用するは実用的になります。</span><span class="sxs-lookup"><span data-stu-id="ba517-134">It's more convenient and practical to use exceptions than error codes.</span></span> <span data-ttu-id="ba517-135">リソースの取得-がの初期化 (RAII) の表現形式を使用する場合を回避できますエラー コードの明示的に確認し、リソースを明示的に解放します。</span><span class="sxs-lookup"><span data-stu-id="ba517-135">And if you employ the resource-acquisition-is-initialization (RAII) idiom, then you can avoid explicitly checking for error codes and then explicitly releasing resources.</span></span> <span data-ttu-id="ba517-136">このような明示的なチェックは必要に応じてよりもより複雑ですが、コードを行い、場所を非表示にはたくさんのバグを提供します。</span><span class="sxs-lookup"><span data-stu-id="ba517-136">Such explicit checks make your code more convoluted than necessary, and it gives bugs plenty of places to hide.</span></span> <span data-ttu-id="ba517-137">代わりに、RAII を使用して、例外のスローと catch</span><span class="sxs-lookup"><span data-stu-id="ba517-137">Instead, use RAII, and throw/catch exceptions.</span></span> <span data-ttu-id="ba517-138">これにより、リソースの割り当ては例外セーフと、コードは単純です。</span><span class="sxs-lookup"><span data-stu-id="ba517-138">That way, your resource allocations are exception-safe, and your code is simple.</span></span>

<span data-ttu-id="ba517-139">ただし、COM メソッドの実装をエスケープする例外を許可しないでください。</span><span class="sxs-lookup"><span data-stu-id="ba517-139">However, you mustn't allow exceptions to escape your COM method implementations.</span></span> <span data-ttu-id="ba517-140">使用して行うことができます、 `noexcept` COM メソッドの指定子。</span><span class="sxs-lookup"><span data-stu-id="ba517-140">You can ensure that by using the `noexcept` specifier on your COM methods.</span></span> <span data-ttu-id="ba517-141">メソッドが終了する前にそれらを処理する限り、メソッドの呼び出しグラフで任意の場所がスローされる例外では問題が。</span><span class="sxs-lookup"><span data-stu-id="ba517-141">It's ok for exceptions to be thrown anywhere in the call graph of your method, as long as you handle them before your method exits.</span></span> <span data-ttu-id="ba517-142">使用する場合`noexcept`が、メソッドをエスケープするための例外を許可し、アプリケーションは終了します。</span><span class="sxs-lookup"><span data-stu-id="ba517-142">If you use `noexcept`, but you then allow an exception to escape your method, then your application will terminate.</span></span>

## <a name="add-helper-types-and-functions"></a><span data-ttu-id="ba517-143">ヘルパー型および関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="ba517-143">Add helper types and functions</span></span>

<span data-ttu-id="ba517-144">このステップでのコードの残りの部分は、いくつかヘルパー型および関数を使用して追加します。</span><span class="sxs-lookup"><span data-stu-id="ba517-144">In this step, we'll add some helper types and functions that the rest of the code makes use of.</span></span> <span data-ttu-id="ba517-145">前に`main`以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="ba517-145">So, before `main`, add the following.</span></span>

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

## <a name="implement-the-remaining-functions-and-the-wmain-entry-point-function"></a><span data-ttu-id="ba517-146">残りの関数では、および wmain のエントリ ポイント関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="ba517-146">Implement the remaining functions, and the wmain entry point function</span></span>

<span data-ttu-id="ba517-147">プロジェクト テンプレートによって生成される、`main`する関数。</span><span class="sxs-lookup"><span data-stu-id="ba517-147">The project template generates a `main` function for you.</span></span> <span data-ttu-id="ba517-148">削除する`main`関数、およびその場所に貼り付け、コクラスを登録するコードが含まれている一覧から、このコードをクリックし、トースト、アプリケーションのコールバックの対応を配信します。</span><span class="sxs-lookup"><span data-stu-id="ba517-148">Delete that `main` function, and in its place paste this code listing, which includes code to register your coclass, and then to deliver a toast capable of calling back your application.</span></span>

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

## <a name="how-to-test-the-example-application"></a><span data-ttu-id="ba517-149">サンプル アプリケーションをテストする方法</span><span class="sxs-lookup"><span data-stu-id="ba517-149">How to test the example application</span></span>

<span data-ttu-id="ba517-150">アプリケーションをビルドし、少なくとも 1 回の登録、およびその他のセットアップでは、コードを実行させるに管理者として実行します。</span><span class="sxs-lookup"><span data-stu-id="ba517-150">Build the application, and then run it at least once as Administrator to cause the registration, and other setup, code to run.</span></span> <span data-ttu-id="ba517-151">かどうか、管理者として実行しているし、T キーを押して ' を表示するトーストを発生します。</span><span class="sxs-lookup"><span data-stu-id="ba517-151">Whether or not you're running it as Administrator, then press 'T' to cause a toast to be displayed.</span></span> <span data-ttu-id="ba517-152">クリックすることができます、 **ToastAndCallback コールバック**ボタン、トースト通知が表示されたら、またはアクション センター、およびアプリケーションから直接起動する、インスタンス化すると、コクラスと**INotificationActivationCallback::Activate**メソッドを実行します。</span><span class="sxs-lookup"><span data-stu-id="ba517-152">You can then click the **Call back ToastAndCallback** button either directly from the toast notification that pops up, or from the Action Center, and your application will be launched, the coclass instantiated, and the **INotificationActivationCallback::Activate** method executed.</span></span>

## <a name="in-process-com-server"></a><span data-ttu-id="ba517-153">インプロセス COM サーバー</span><span class="sxs-lookup"><span data-stu-id="ba517-153">In-process COM server</span></span>

<span data-ttu-id="ba517-154">*ToastAndCallback*上記の例のアプリはローカル (または、プロセス外の) COM サーバーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="ba517-154">The *ToastAndCallback* example app above functions as a local (or out-of-process) COM server.</span></span> <span data-ttu-id="ba517-155">これにより、表示、 [LocalServer32](/windows/desktop/com/localserver32) Windows レジストリ キーのコクラスの CLSID を登録するために使用します。</span><span class="sxs-lookup"><span data-stu-id="ba517-155">This is indicated by the [LocalServer32](/windows/desktop/com/localserver32) Windows Registry key that you use to register the CLSID of its coclass.</span></span> <span data-ttu-id="ba517-156">ローカル COM サーバーのホスト実行可能ファイルのバイナリ内の coclass(es) (、 `.exe`)。</span><span class="sxs-lookup"><span data-stu-id="ba517-156">A local COM server hosts its coclass(es) inside an executable binary (an `.exe`).</span></span>

<span data-ttu-id="ba517-157">または (と可能性の高いほぼ間違いなく)、ダイナミック リンク ライブラリ内で、coclass(es) をホストすることもできます (、 `.dll`)。</span><span class="sxs-lookup"><span data-stu-id="ba517-157">Alternatively (and arguably more likely), you can choose to host your coclass(es) inside a dynamic-link library (a `.dll`).</span></span> <span data-ttu-id="ba517-158">DLL の形式での COM サーバーは、インプロセス COM サーバーと呼ばれ、Clsid を使用して登録されているで示された、 [InprocServer32](/windows/desktop/com/inprocserver32) Windows レジストリ キー。</span><span class="sxs-lookup"><span data-stu-id="ba517-158">A COM server in the form of a DLL is known as an in-process COM server, and it's indicated by CLSIDs being registered by using the [InprocServer32](/windows/desktop/com/inprocserver32) Windows Registry key.</span></span>

### <a name="create-a-dynamic-link-library-dll-project"></a><span data-ttu-id="ba517-159">ダイナミック リンク ライブラリ (DLL) プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="ba517-159">Create a Dynamic-Link Library (DLL) project</span></span>

<span data-ttu-id="ba517-160">Microsoft Visual Studio で新しいプロジェクトを作成して、インプロセス COM サーバーを作成するタスクを開始することができます。</span><span class="sxs-lookup"><span data-stu-id="ba517-160">You can begin the task of creating an in-process COM server by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="ba517-161">作成、 **Visual C** > **Windows デスクトップ** > **ダイナミック リンク ライブラリ (DLL)** プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="ba517-161">Create a **Visual C++** > **Windows Desktop** > **Dynamic-Link Library (DLL)** project.</span></span>

<span data-ttu-id="ba517-162">追加 C +/cli WinRT サポート、新しいプロジェクトに次の記載された手順[C + を追加する Windows デスクトップ アプリケーション プロジェクトを変更する/cli WinRT サポート](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。</span><span class="sxs-lookup"><span data-stu-id="ba517-162">To add C++/WinRT support to the new project, follow the steps described in [Modify a Windows Desktop application project to add C++/WinRT support](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support).</span></span>

### <a name="implement-the-coclass-class-factory-and-in-proc-server-exports"></a><span data-ttu-id="ba517-163">コクラス、クラス ファクトリ、および、インプロセス サーバーのエクスポートを実装します。</span><span class="sxs-lookup"><span data-stu-id="ba517-163">Implement the coclass, class factory, and in-proc server exports</span></span>

<span data-ttu-id="ba517-164">開いている`dllmain.cpp`、し、次に示すコード リストを追加します。</span><span class="sxs-lookup"><span data-stu-id="ba517-164">Open `dllmain.cpp`, and add to it the code listing shown below.</span></span>

<span data-ttu-id="ba517-165">C + を実装する DLL があれば/cli WinRT Windows ランタイム クラスを既にがある得られます、 **DllCanUnloadNow**次に示す関数。</span><span class="sxs-lookup"><span data-stu-id="ba517-165">If you already have a DLL that implements C++/WinRT Windows Runtime classes, then you'll already have the **DllCanUnloadNow** function shown below.</span></span> <span data-ttu-id="ba517-166">コクラスをその DLL に追加するかどうかは、追加することができます、 **DllGetClassObject**関数。</span><span class="sxs-lookup"><span data-stu-id="ba517-166">If you want to add coclasses to that DLL, then you can add the **DllGetClassObject** function.</span></span>

<span data-ttu-id="ba517-167">場合は既存の必要はありません[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)に示すコードからパーツのコードを使用すると、互換性を維持するその、WRL を削除することができます。</span><span class="sxs-lookup"><span data-stu-id="ba517-167">If don't have existing [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) code that you want to stay compatible with, then you can remove the WRL parts from the code shown.</span></span>

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

### <a name="support-for-weak-references"></a><span data-ttu-id="ba517-168">弱い参照のサポート</span><span class="sxs-lookup"><span data-stu-id="ba517-168">Support for weak references</span></span>

<span data-ttu-id="ba517-169">参照してください[c++ の弱い参照/cli WinRT](weak-references.md#weak-references-in-cwinrt)します。</span><span class="sxs-lookup"><span data-stu-id="ba517-169">Also see [Weak references in C++/WinRT](weak-references.md#weak-references-in-cwinrt).</span></span>

<span data-ttu-id="ba517-170">C +/cli WinRT (具体的には、 [ **winrt::implements** ](/uwp/cpp-ref-for-winrt/implements)基底構造体のテンプレート) を実装して[ **IWeakReferenceSource** ](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource)の場合、実装の入力[ **IInspectable** ](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (または任意のインターフェイスから派生した**IInspectable**)。</span><span class="sxs-lookup"><span data-stu-id="ba517-170">C++/WinRT (specifically, the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct template) implements [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource) for you if your type implements [**IInspectable**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) (or any interface that derives from **IInspectable**).</span></span>

<span data-ttu-id="ba517-171">これは、ため**IWeakReferenceSource**と[ **IWeakReference** ](/windows/desktop/api/weakreference/nn-weakreference-iweakreference) Windows ランタイム型用に設計されています。</span><span class="sxs-lookup"><span data-stu-id="ba517-171">This is because **IWeakReferenceSource** and [**IWeakReference**](/windows/desktop/api/weakreference/nn-weakreference-iweakreference) are designed for Windows Runtime types.</span></span> <span data-ttu-id="ba517-172">そのため、できるサポートを有効に弱い参照、コクラスを追加するだけで**winrt::Windows::Foundation::IInspectable** (またはインターフェイスから派生した**IInspectable**) 実装にします。</span><span class="sxs-lookup"><span data-stu-id="ba517-172">So, you can turn on weak reference support for your coclass simply by adding **winrt::Windows::Foundation::IInspectable** (or an interface that derives from **IInspectable**) to your implementation.</span></span>

```cppwinrt
struct MyCoclass : winrt::implements<MyCoclass, IMyComInterface, winrt::Windows::Foundation::IInspectable>
{
    //  ...
};
```

## <a name="important-apis"></a><span data-ttu-id="ba517-173">重要な API</span><span class="sxs-lookup"><span data-stu-id="ba517-173">Important APIs</span></span>
* [<span data-ttu-id="ba517-174">IInspectable インターフェイス</span><span class="sxs-lookup"><span data-stu-id="ba517-174">IInspectable interface</span></span>](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)
* [<span data-ttu-id="ba517-175">IUnknown インターフェイス</span><span class="sxs-lookup"><span data-stu-id="ba517-175">IUnknown interface</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [<span data-ttu-id="ba517-176">winrt::implements 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="ba517-176">winrt::implements struct template</span></span>](/uwp/cpp-ref-for-winrt/implements)

## <a name="related-topics"></a><span data-ttu-id="ba517-177">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ba517-177">Related topics</span></span>
* [<span data-ttu-id="ba517-178">C++/WinRT で API を作成する</span><span class="sxs-lookup"><span data-stu-id="ba517-178">Author APIs with C++/WinRT</span></span>](/windows/uwp/cpp-and-winrt-apis/author-apis)
* [<span data-ttu-id="ba517-179">C++/WinRT での COM コンポーネントの使用</span><span class="sxs-lookup"><span data-stu-id="ba517-179">Consume COM components with C++/WinRT</span></span>](consume-com.md)
* [<span data-ttu-id="ba517-180">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="ba517-180">Send a local toast notification</span></span>](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)
