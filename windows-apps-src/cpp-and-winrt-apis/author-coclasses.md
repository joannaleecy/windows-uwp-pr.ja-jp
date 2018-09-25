---
author: stevewhims
description: C++/WinRT で役立つ従来の COM コンポーネントを作成する Windows ランタイム クラスを作成するのに役立ち、同様です。
title: C++ に COM コンポーネントの作成/WinRT
ms.author: stwhi
ms.date: 09/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、作成者、COM、コンポーネント
ms.localizationpriority: medium
ms.openlocfilehash: 729cfae39f302ae6b5bae275d9e28a39f3d9503b
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4176515"
---
# <a name="author-com-components-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="3f892-104">COM コンポーネントを作成[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="3f892-104">Author COM components with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

<span data-ttu-id="3f892-105">C++/WinRT は、Windows ランタイム クラスを作成するのに役立ち、同様、クラシック コンポーネント オブジェクト モデル (COM) コンポーネント (またはコクラス) を作成するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3f892-105">C++/WinRT can help you to author classic Component Object Model (COM) components (or coclasses), just as it helps you to author Windows Runtime classes.</span></span> <span data-ttu-id="3f892-106">貼り付ける場合をテストする非常に単純な図は、ここでは、`main.cpp`の新しい**Windows コンソール アプリケーション (、C++/WinRT)** プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="3f892-106">Here's a very simple illustration, which you can test out if you paste it into the `main.cpp` of a new **Windows Console Application (C++/WinRT)** project.</span></span>

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

<span data-ttu-id="3f892-107">」もご覧ください[消費 COM コンポーネントにおいて、C++/WinRT](consume-com.md)します。</span><span class="sxs-lookup"><span data-stu-id="3f892-107">Also see [Consume COM components with C++/WinRT](consume-com.md).</span></span>

## <a name="a-more-realistic-and-interesting-example"></a><span data-ttu-id="3f892-108">現実的で興味深い例</span><span class="sxs-lookup"><span data-stu-id="3f892-108">A more realistic and interesting example</span></span>

<span data-ttu-id="3f892-109">このトピックの残りの部分では、C++ を使用する最小限に抑えながらコンソール アプリケーション プロジェクトの作成について説明します/WinRT 基本的なコクラスとクラスのファクトリを実装します。</span><span class="sxs-lookup"><span data-stu-id="3f892-109">The remainder of this topic walks through creating a minimal console application project that uses C++/WinRT to implement a basic coclass and class factory.</span></span> <span data-ttu-id="3f892-110">アプリケーションの例は、それに基づいてコールバックのボタンを含むトースト通知を配信する方法を示していますと ( **INotificationActivationCallback** COM インターフェイスを実装) するコクラスにより、アプリケーションを起動し、と呼ばれるタイミング ユーザー。トースト通知では、そのボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="3f892-110">The example application shows how to deliver a toast notification with a callback button on it, and the coclass (which implements the **INotificationActivationCallback** COM interface) allows the application to be launched and called back when the user clicks that button on the toast.</span></span>

<span data-ttu-id="3f892-111">トースト通知の機能領域についての詳しい背景は、[ローカル トースト通知の送信](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)で入手できます。</span><span class="sxs-lookup"><span data-stu-id="3f892-111">More background about the toast notification feature area can be found at [Send a local toast notification](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast).</span></span> <span data-ttu-id="3f892-112">いずれのドキュメントのセクションのコード例を使用して、C++/WinRT、ただし、お勧めしますここに示すようにコードを希望します。</span><span class="sxs-lookup"><span data-stu-id="3f892-112">None of the code examples in that section of the documentation use C++/WinRT, though, so we recommend that you prefer the code shown in this topic.</span></span>

## <a name="create-a-windows-console-application-project-toastandcallback"></a><span data-ttu-id="3f892-113">Windows コンソール アプリケーション プロジェクト (ToastAndCallback) を作成します。</span><span class="sxs-lookup"><span data-stu-id="3f892-113">Create a Windows Console Application project (ToastAndCallback)</span></span>

<span data-ttu-id="3f892-114">まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="3f892-114">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="3f892-115">**Visual C**を作成 > **Windows デスクトップ** > **Windows コンソール アプリケーション (、C++/WinRT)** プロジェクト、および*ToastAndCallback*名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="3f892-115">Create a **Visual C++** > **Windows Desktop** > **Windows Console Application (C++/WinRT)** project, and name it *ToastAndCallback*.</span></span>

<span data-ttu-id="3f892-116">開いている`main.cpp`、および削除を使用して、ディレクティブ プロジェクト テンプレートを生成します。</span><span class="sxs-lookup"><span data-stu-id="3f892-116">Open `main.cpp`, and remove the using-directives that the project template generates.</span></span> <span data-ttu-id="3f892-117">自分の場所で (これにより、ライブラリ、ヘッダーと型名が必要ですが) 次のコードを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="3f892-117">In their place, paste the following code (which gives us the libs, headers, and type names that we need).</span></span>

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

## <a name="implement-the-coclass-and-class-factory"></a><span data-ttu-id="3f892-118">コクラスとクラスのファクトリを実装します。</span><span class="sxs-lookup"><span data-stu-id="3f892-118">Implement the coclass and class factory</span></span>

<span data-ttu-id="3f892-119">C++/WinRT、実装するコクラス、およびクラスのファクトリを[**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)の基本構造体から派生させることです。</span><span class="sxs-lookup"><span data-stu-id="3f892-119">In C++/WinRT, you implement coclasses, and class factories, by deriving from the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) base struct.</span></span> <span data-ttu-id="3f892-120">直後に、次の 3 つの using ディレクティブを上に示した (前に`main`)、トースト通知 COM アクティベーター コンポーネントを実装するには、このコードを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="3f892-120">Immediately after the three using-directives shown above (and before `main`), paste this code to implement your toast notification COM activator component.</span></span>

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

<span data-ttu-id="3f892-121">上記のコクラスの実装に示す同じパターンに従います[において、C++ Api の作成/WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class)します。</span><span class="sxs-lookup"><span data-stu-id="3f892-121">The implementation of the coclass above follows the same pattern that's demonstrated in [Author APIs with C++/WinRT](/windows/uwp/cpp-and-winrt-apis/author-apis#if-youre-not-authoring-a-runtime-class).</span></span> <span data-ttu-id="3f892-122">Windows ランタイム インターフェイス (インターフェイスはすべて最終的に[**IInspectable**](https://msdn.microsoft.com/library/br205821)から派生した) は COM インターフェイス (最終的に[**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509)から派生したインターフェイス) を実装するだけでなく、この手法を使用することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3f892-122">Notice that you can use this technique not only for Windows Runtime interfaces (any interface that ultimately derives from [**IInspectable**](https://msdn.microsoft.com/library/br205821)), but also to implement COM interfaces (any interface that ultimately derives from [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509)).</span></span>

<span data-ttu-id="3f892-123">上記のコードでコクラスは、 **INotificationActivationCallback::Activate**メソッドは、ユーザーがトースト通知のコールバック ボタンをクリックしたときに呼び出される関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="3f892-123">In the coclass in the code above, we implement the **INotificationActivationCallback::Activate** method, which is the function that's called when the user clicks the callback button on a toast notification.</span></span> <span data-ttu-id="3f892-124">コクラスのインスタンスを作成する必要があるし、 **IClassFactory::CreateInstance**関数のジョブは前に、この関数を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3f892-124">But before that function can be called, an instance of the coclass needs to be created, and that's the job of the **IClassFactory::CreateInstance** function.</span></span>

<span data-ttu-id="3f892-125">実装しましたコクラス、通知の場合、 *COM アクティベーター*と呼ばれ、そのクラス id (CLSID) の形式では、`callback_guid`種類の識別子 ( **GUID**) 上に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3f892-125">The coclass that we just implemented is known as the *COM activator* for notifications, and it has its class id (CLSID) in the form of the `callback_guid` identifier (of type **GUID**) that you see above.</span></span> <span data-ttu-id="3f892-126">おを使ってその識別子後で、スタート メニューのショートカットと Windows レジストリ エントリの形式でします。</span><span class="sxs-lookup"><span data-stu-id="3f892-126">We'll be using that identifier later, in the form of a Start menu shortcut and a Windows Registry entry.</span></span> <span data-ttu-id="3f892-127">COM アクティベーター CLSID とその関連 COM サーバー (ここでは開発中の実行可能ファイルへのパス) へのパスは、トースト通知が、コールバックのボタンがクリックされたときのインスタンスを作成するクラスを認識するためのメカニズム (かどうか、通知がクリックされるアクション センターにまたはされません)。</span><span class="sxs-lookup"><span data-stu-id="3f892-127">The COM activator CLSID, and the path to its associated COM server (which is the path to the executable that we're building here) is the mechanism by which a toast notification knows what class to create an instance of when its callback button is clicked (whether the notification is clicked in Action Center or not).</span></span>

## <a name="best-practices-for-implementing-com-methods"></a><span data-ttu-id="3f892-128">COM メソッドを実装するためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="3f892-128">Best practices for implementing COM methods</span></span>

<span data-ttu-id="3f892-129">エラー処理とリソース管理のための手法では、手の手でを移動できます。</span><span class="sxs-lookup"><span data-stu-id="3f892-129">Techniques for error handling and for resource management can go hand-in-hand.</span></span> <span data-ttu-id="3f892-130">便利でエラー コードよりも例外を使用するは実用的です。</span><span class="sxs-lookup"><span data-stu-id="3f892-130">It's more convenient and practical to use exceptions than error codes.</span></span> <span data-ttu-id="3f892-131">リソース取得-は-初期化 (RAII) イディオムを使用している場合しするを回避するエラー コードを明示的に確認してリソースを明示的に解放します。</span><span class="sxs-lookup"><span data-stu-id="3f892-131">And if you employ the resource-acquisition-is-initialization (RAII) idiom, then you can avoid explicitly checking for error codes and then explicitly releasing resources.</span></span> <span data-ttu-id="3f892-132">このような明示的なチェックは必要に応じてより複雑なコードを行い、非表示にする場所はたくさんのバグが提供します。</span><span class="sxs-lookup"><span data-stu-id="3f892-132">Such explicit checks make your code more convoluted than necessary, and it gives bugs plenty of places to hide.</span></span> <span data-ttu-id="3f892-133">代わりに、RAII を使用し、例外のキャッチとスローします。</span><span class="sxs-lookup"><span data-stu-id="3f892-133">Instead, use RAII, and throw/catch exceptions.</span></span> <span data-ttu-id="3f892-134">これにより、リソースの割り当ては例外安全と、コードは簡単です。</span><span class="sxs-lookup"><span data-stu-id="3f892-134">That way, your resource allocations are exception-safe, and your code is simple.</span></span>

<span data-ttu-id="3f892-135">ただし、COM メソッドの実装をエスケープする例外を許可する照準します。</span><span class="sxs-lookup"><span data-stu-id="3f892-135">However, you mustn't allow exceptions to escape your COM method implementations.</span></span> <span data-ttu-id="3f892-136">使用して行うことができます、 `noexcept` 、COM メソッドで指定子。</span><span class="sxs-lookup"><span data-stu-id="3f892-136">You can ensure that by using the `noexcept` specifier on your COM methods.</span></span> <span data-ttu-id="3f892-137">メソッドが終了する前にそれらを処理する限り、例外をスローを任意の場所、メソッドの呼び出しグラフ内の ok です。</span><span class="sxs-lookup"><span data-stu-id="3f892-137">It's ok for exceptions to be thrown anywhere in the call graph of your method, as long as you handle them before your method exits.</span></span> <span data-ttu-id="3f892-138">使用する場合`noexcept`、メソッドをエスケープする例外を許可する場合、アプリケーションを終了します。</span><span class="sxs-lookup"><span data-stu-id="3f892-138">If you use `noexcept`, but you then allow an exception to escape your method, then your application will terminate.</span></span>

## <a name="add-helper-types-and-functions"></a><span data-ttu-id="3f892-139">ヘルパー型と関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="3f892-139">Add helper types and functions</span></span>

<span data-ttu-id="3f892-140">この手順の残りのコードは、いくつかヘルパー型と関数を使用して追加します。</span><span class="sxs-lookup"><span data-stu-id="3f892-140">In this step, we'll add some helper types and functions that the rest of the code makes use of.</span></span> <span data-ttu-id="3f892-141">したがって、前に`main`、以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="3f892-141">So, before `main`, add the following.</span></span>

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

## <a name="implement-the-remaining-functions-and-the-wmain-entry-point-function"></a><span data-ttu-id="3f892-142">残りの関数と wmain エントリ ポイント関数を実装します。</span><span class="sxs-lookup"><span data-stu-id="3f892-142">Implement the remaining functions, and the wmain entry point function</span></span>

<span data-ttu-id="3f892-143">プロジェクト テンプレートを生成する`main`するための関数です。</span><span class="sxs-lookup"><span data-stu-id="3f892-143">The project template generates a `main` function for you.</span></span> <span data-ttu-id="3f892-144">削除する`main`機能、その場所に、登録情報にコクラスを登録するコードが含まれており、次のコードを貼り付け、アプリケーションをもう一度呼び出すことのできるトーストを提供します。</span><span class="sxs-lookup"><span data-stu-id="3f892-144">Delete that `main` function, and in its place paste this code listing, which includes code to register your coclass, and then to deliver a toast capable of calling back your application.</span></span>

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

## <a name="how-to-test-the-example-application"></a><span data-ttu-id="3f892-145">サンプル アプリケーションをテストする方法</span><span class="sxs-lookup"><span data-stu-id="3f892-145">How to test the example application</span></span>

<span data-ttu-id="3f892-146">アプリケーションをビルドし、少なくとも 1 回、登録され、その他のセットアップでは、コードを実行するには管理者として実行します。</span><span class="sxs-lookup"><span data-stu-id="3f892-146">Build the application, and then run it at least once as Administrator to cause the registration, and other setup, code to run.</span></span> <span data-ttu-id="3f892-147">管理者は、それを実行しているし、T キーを押してするかどうか ' を表示するトーストが発生します。</span><span class="sxs-lookup"><span data-stu-id="3f892-147">Whether or not you're running it as Administrator, then press 'T' to cause a toast to be displayed.</span></span> <span data-ttu-id="3f892-148">どちらか、または、アクション センターと、アプリケーションからポップが起動されること、トースト通知、インスタンス化され、コクラス**INotificationActivationCallback から直接**ToastAndCallback コールバック**のボタンをクリックします。: アクティブ化**メソッドを実行します。</span><span class="sxs-lookup"><span data-stu-id="3f892-148">You can then click the **Call back ToastAndCallback** button either directly from the toast notification that pops up, or from the Action Center, and your application will be launched, the coclass instantiated, and the **INotificationActivationCallback::Activate** method executed.</span></span>

## <a name="important-apis"></a><span data-ttu-id="3f892-149">重要な API</span><span class="sxs-lookup"><span data-stu-id="3f892-149">Important APIs</span></span>
* [<span data-ttu-id="3f892-150">IInspectable インターフェイス</span><span class="sxs-lookup"><span data-stu-id="3f892-150">IInspectable interface</span></span>](https://msdn.microsoft.com/library/br205821)
* [<span data-ttu-id="3f892-151">IUnknown インターフェイス</span><span class="sxs-lookup"><span data-stu-id="3f892-151">IUnknown interface</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms680509)
* [<span data-ttu-id="3f892-152">winrt::implements 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="3f892-152">winrt::implements struct template</span></span>](/uwp/cpp-ref-for-winrt/implements)

## <a name="related-topics"></a><span data-ttu-id="3f892-153">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3f892-153">Related topics</span></span>
* [<span data-ttu-id="3f892-154">C++/WinRT での API の作成</span><span class="sxs-lookup"><span data-stu-id="3f892-154">Author APIs with C++/WinRT</span></span>](/windows/uwp/cpp-and-winrt-apis/author-apis)
* [<span data-ttu-id="3f892-155">C++ に COM コンポーネントを使用/WinRT</span><span class="sxs-lookup"><span data-stu-id="3f892-155">Consume COM components with C++/WinRT</span></span>](consume-com.md)
* [<span data-ttu-id="3f892-156">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="3f892-156">Send a local toast notification</span></span>](/windows/uwp/design/shell/tiles-and-notifications/send-local-toast)
