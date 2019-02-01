---
description: このトピックでは、WRL コードを C++/WinRT での同等のコードに移植する方法を示しています。
title: WRL から C++/WinRT への移行
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, WRL
ms.localizationpriority: medium
ms.openlocfilehash: b2e09bc5d65e9bf3029b4049049de52709e648b2
ms.sourcegitcommit: 2d2483819957619b6de21b678caf887f3b1342af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/01/2019
ms.locfileid: "9042344"
---
# <a name="move-to-cwinrt-from-wrl"></a><span data-ttu-id="69c03-104">WRL から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="69c03-104">Move to C++/WinRT from WRL</span></span>
<span data-ttu-id="69c03-105">このトピックでは、それに対応する[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)コードを移植する方法を示しています[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="69c03-105">This topic shows how to port [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) code to its equivalent in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span>

<span data-ttu-id="69c03-106">C + への移植の最初の手順/WinRT では、手動で追加 C + + WinRT のサポートをプロジェクトに (を参照してください[、C++、Visual Studio サポート/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package))。</span><span class="sxs-lookup"><span data-stu-id="69c03-106">The first step in porting to C++/WinRT is to manually add C++/WinRT support to your project (see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)).</span></span> <span data-ttu-id="69c03-107">そのためには、プロジェクトに[Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をインストールします。</span><span class="sxs-lookup"><span data-stu-id="69c03-107">To do that, install the [Microsoft.Windows.CppWinRT NuGet package](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/) into your project.</span></span> <span data-ttu-id="69c03-108">Visual Studio でプロジェクト クリックの**プロジェクト**を開く \> **NuGet パッケージを管理する.** \> **参照**、入力または**Microsoft.Windows.CppWinRT**を検索ボックスに貼り付ける、検索結果の項目を選択して**インストール**をそのプロジェクトのパッケージをインストールする] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="69c03-108">Open the project in Visual Studio, click **Project** \> **Manage NuGet Packages...** \> **Browse**, type or paste **Microsoft.Windows.CppWinRT** in the search box, select the item in search results, and then click **Install** to install the package for that project.</span></span> <span data-ttu-id="69c03-109">その変更の 1 つの効果は、そのサポート[、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx)がプロジェクトで無効になります。</span><span class="sxs-lookup"><span data-stu-id="69c03-109">One effect of that change is that support for [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) is turned off in the project.</span></span> <span data-ttu-id="69c03-110">プロジェクトで C++/CX を使用している場合は、サポートを無効にしたままにし、C++/CX コードを C++/WinRT に更新することもできます (「[C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="69c03-110">If you're using C++/CX in the project, then you can leave support turned off and update your C++/CX code to C++/WinRT as well (see [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md)).</span></span> <span data-ttu-id="69c03-111">または、サポートをもう一度有効にし (プロジェクトのプロパティで、**[C/C++]** \> **[全般]** \> **[Windows ランタイム拡張機能の使用]** \> **[はい (/ZW)]** の順に選択)、まず WRL コードを移植することに集中することもできます。</span><span class="sxs-lookup"><span data-stu-id="69c03-111">Or you can turn support back on (in project properties, **C/C++** \> **General** \> **Consume Windows Runtime Extension** \> **Yes (/ZW)**), and first focus on porting your WRL code.</span></span> <span data-ttu-id="69c03-112">C++ +/CX と C++/WinRT コードに XAML コンパイラ サポート、および Windows ランタイム コンポーネントを除いて、同じプロジェクトに共存することができます (を参照してください[C + への移行 + C + から WinRT/CX](move-to-winrt-from-cx.md))。</span><span class="sxs-lookup"><span data-stu-id="69c03-112">C++/CX and C++/WinRT code can coexist in the same project, with the exception of XAML compiler support, and Windows Runtime Components (see [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md)).</span></span>

<span data-ttu-id="69c03-113">プロジェクトのプロパティ (**[全般]** \> **[ターゲット プラットフォーム バージョン]**) を 10.0.17134.0 (Windows 10 バージョン 1803) 以上に設定します。</span><span class="sxs-lookup"><span data-stu-id="69c03-113">Set project property **General** \> **Target Platform Version** to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="69c03-114">プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。</span><span class="sxs-lookup"><span data-stu-id="69c03-114">In your precompiled header file (usually `pch.h`), include `winrt/base.h`.</span></span>

```cppwinrt
#include <winrt/base.h>
```

<span data-ttu-id="69c03-115">C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。</span><span class="sxs-lookup"><span data-stu-id="69c03-115">If you include any C++/WinRT projected Windows API headers (for example, `winrt/Windows.Foundation.h`), then you don't need to explicitly include `winrt/base.h` like this because it will be included automatically for you.</span></span>

## <a name="porting-wrl-com-smart-pointers-microsoftwrlcomptrcppwindowscomptr-class"></a><span data-ttu-id="69c03-116">WRL COM スマート ポインター ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class)) の移植</span><span class="sxs-lookup"><span data-stu-id="69c03-116">Porting WRL COM smart pointers ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class))</span></span>
<span data-ttu-id="69c03-117">**Microsoft::WRL::ComPtr\<T\>** を使用するコードを移植して [**winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr) を使用します。</span><span class="sxs-lookup"><span data-stu-id="69c03-117">Port any code that uses **Microsoft::WRL::ComPtr\<T\>** to use [**winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr).</span></span> <span data-ttu-id="69c03-118">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="69c03-118">Here's a before-and-after code example.</span></span> <span data-ttu-id="69c03-119">*変更後の*バージョンでは、[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) メンバー関数は基になる生のポインターを取得して設定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="69c03-119">In the *after* version, the [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) member function retrieves the underlying raw pointer so that it can be set.</span></span>

```cpp
ComPtr<IDXGIAdapter1> previousDefaultAdapter;
DX::ThrowIfFailed(m_dxgiFactory->EnumAdapters1(0, &previousDefaultAdapter));
```

```cppwinrt
winrt::com_ptr<IDXGIAdapter1> previousDefaultAdapter;
winrt::check_hresult(m_dxgiFactory->EnumAdapters1(0, previousDefaultAdapter.put()));
```

> [!IMPORTANT]
> <span data-ttu-id="69c03-120">既に取り付けられている[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)があるかどうか (その内部の生のポインターが既にターゲット) 再シートに別のオブジェクトをポイントするし、最初に割り当てる必要があります`nullptr`に&mdash;次のコード例に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="69c03-120">If you have a [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) that's already seated (its internal raw pointer already has a target) and you want to re-seat it to point to a different object, then you first need to assign `nullptr` to it&mdash;as shown in the code example below.</span></span> <span data-ttu-id="69c03-121">ない場合は、し、既に取り付けられている**com_ptr**描画問題 ( [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)または[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)を呼び出す) と、注意をによって、内部のポインターが null でないことをアサートします。</span><span class="sxs-lookup"><span data-stu-id="69c03-121">If you don't, then an already-seated **com_ptr** will draw the issue to your attention (when you call [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) or [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)) by asserting that its internal pointer is not null.</span></span>

```cppwinrt
winrt::com_ptr<IDXGISwapChain1> m_pDXGISwapChain1;
...
// We execute the code below each time the window size changes.
m_pDXGISwapChain1 = nullptr; // Important because we're about to re-seat 
winrt::check_hresult(
    m_pDxgiFactory->CreateSwapChainForHwnd(
        m_pCommandQueue.get(), // For Direct3D 12, this is a pointer to a direct command queue, and not to the device.
        m_hWnd,
        &swapChainDesc,
        nullptr,
        nullptr,
        m_pDXGISwapChain1.put())
);
```

<span data-ttu-id="69c03-122">次の例 (*変更後の*バージョン) では、[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) メンバー関数は基になる生のポインターを、無効にするポインターへのポインターとして取得します。</span><span class="sxs-lookup"><span data-stu-id="69c03-122">In this next example (in the *after* version), the [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) member function retrieves the underlying raw pointer as a pointer to a pointer to void.</span></span>

```cpp
ComPtr<ID3D12Debug> debugController;
if (SUCCEEDED(D3D12GetDebugInterface(IID_PPV_ARGS(&debugController))))
{
    debugController->EnableDebugLayer();
}
```

```cppwinrt
winrt::com_ptr<ID3D12Debug> debugController;
if (SUCCEEDED(D3D12GetDebugInterface(__uuidof(debugController), debugController.put_void())))
{
    debugController->EnableDebugLayer();
}
```

<span data-ttu-id="69c03-123">**ComPtr::Get** を [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function) で置換します。</span><span class="sxs-lookup"><span data-stu-id="69c03-123">Replace **ComPtr::Get** with [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function).</span></span>

```cpp
m_d3dDevice->CreateDepthStencilView(m_depthStencil.Get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

```cppwinrt
m_d3dDevice->CreateDepthStencilView(m_depthStencil.get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

<span data-ttu-id="69c03-124">**IUnknown**へのポインターを想定している関数には基になる生のポインターを渡す場合は、次の例に示すように、 [**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function)自由関数を使用します。</span><span class="sxs-lookup"><span data-stu-id="69c03-124">When you want to pass the underlying raw pointer to a function that expects a pointer to **IUnknown**, use the [**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function) free function, as shown in this next example.</span></span>

```cpp
ComPtr<IDXGISwapChain1> swapChain;
DX::ThrowIfFailed(
    m_dxgiFactory->CreateSwapChainForCoreWindow(
        m_commandQueue.Get(),
        reinterpret_cast<IUnknown*>(m_window.Get()),
        &swapChainDesc,
        nullptr,
        &swapChain
    )
);
```

```cppwinrt
winrt::agile_ref<winrt::Windows::UI::Core::CoreWindow> m_window; 
winrt::com_ptr<IDXGISwapChain1> swapChain;
winrt::check_hresult(
    m_dxgiFactory->CreateSwapChainForCoreWindow(
        m_commandQueue.get(),
        winrt::get_unknown(m_window.get()),
        &swapChainDesc,
        nullptr,
        swapChain.put()
    )
);
```

## <a name="porting-a-wrl-module-microsoftwrlmodule"></a><span data-ttu-id="69c03-125">WRL モジュール ([Microsoft::WRL::Module]()) の移植</span><span class="sxs-lookup"><span data-stu-id="69c03-125">Porting a WRL module ([Microsoft::WRL::Module]())</span></span>
<span data-ttu-id="69c03-126">WRL を使用してコンポーネントを実装する既存のプロジェクトに C++/WinRT コードを徐々に追加することができます。既存の WRL クラスは引き続きサポートされます。</span><span class="sxs-lookup"><span data-stu-id="69c03-126">You can gradually add C++/WinRT code to an existing project that uses WRL to implement a component, and your existing WRL classes will continue to be supported.</span></span> <span data-ttu-id="69c03-127">このセクションではその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="69c03-127">This section shows how.</span></span>

<span data-ttu-id="69c03-128">Visual Studio でプロジェクトの種類として新しい **Windows ランタイム コンポーネント (C++/WinRT)** を作成する場合は、ファイル `Generated Files\module.g.cpp` が自動的に生成されます。</span><span class="sxs-lookup"><span data-stu-id="69c03-128">If you create a new **Windows Runtime Component (C++/WinRT)** project type in Visual Studio, and build, then the file `Generated Files\module.g.cpp` is generated for you.</span></span> <span data-ttu-id="69c03-129">そのファイルには、以下に示す 2 つ便利な C++/WinRT 関数の定義があり、これをプロジェクトにコピーして追加することができます。</span><span class="sxs-lookup"><span data-stu-id="69c03-129">That file contains the definitions of two useful C++/WinRT functions (listed out below), which you can copy and add to your project.</span></span> <span data-ttu-id="69c03-130">これらの関数は **WINRT_CanUnloadNow** および **WINRT_GetActivationFactory** です。ご覧になってわかるように、これらの関数は移植のどの段階でも開発者にサポートを提供できるように、条件付きで WRL を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="69c03-130">Those function are **WINRT_CanUnloadNow** and **WINRT_GetActivationFactory** and, as you can see, they conditionally call WRL in order to support you whatever stage of porting you're at.</span></span>

```cppwinrt
HRESULT WINRT_CALL WINRT_CanUnloadNow()
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

HRESULT WINRT_CALL WINRT_GetActivationFactory(HSTRING classId, void** factory)
{
    try
    {
        *factory = nullptr;
        wchar_t const* const name = WINRT_WindowsGetStringRawBuffer(classId, nullptr);

        if (0 == wcscmp(name, L"MoveFromWRLTest.Class"))
        {
            *factory = winrt::detach_abi(winrt::make<winrt::MoveFromWRLTest::factory_implementation::Class>());
            return S_OK;
        }

#ifdef _WRL_MODULE_H_
        return ::Microsoft::WRL::Module<::Microsoft::WRL::InProc>::GetModule().GetActivationFactory(classId, reinterpret_cast<::IActivationFactory**>(factory));
#else
        return winrt::hresult_class_not_available().to_abi();
#endif
    }
    catch (...) { return winrt::to_hresult(); }
}
```

<span data-ttu-id="69c03-131">プロジェクトにこれらの関数を含めたら、[**Module::GetActivationFactory**](/cpp/windows/module-getactivationfactory-method) を直接呼び出すのではなく、**WINRT_GetActivationFactory** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="69c03-131">Once you have these functions in your project, instead of calling [**Module::GetActivationFactory**](/cpp/windows/module-getactivationfactory-method) directly, call **WINRT_GetActivationFactory** (which calls the WRL function internally).</span></span> <span data-ttu-id="69c03-132">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="69c03-132">Here's a before-and-after code example.</span></span>

```cpp
HRESULT WINAPI DllGetActivationFactory(_In_ HSTRING activatableClassId, _Out_ ::IActivationFactory **factory)
{
    auto & module = Microsoft::WRL::Module<Microsoft::WRL::InProc>::GetModule();
    return module.GetActivationFactory(activatableClassId, factory);
}
```

```cppwinrt
HRESULT __stdcall WINRT_GetActivationFactory(HSTRING activatableClassId, void** factory);
HRESULT WINAPI DllGetActivationFactory(_In_ HSTRING activatableClassId, _Out_ ::IActivationFactory **factory)
{
    return WINRT_GetActivationFactory(activatableClassId, reinterpret_cast<void**>(factory));
}
```

<span data-ttu-id="69c03-133">[**Module::Terminate**](/cpp/windows/module-terminate-method) を直接呼び出す代わりに、**WINRT_CanUnloadNow** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="69c03-133">Instead of calling [**Module::Terminate**](/cpp/windows/module-terminate-method) directly, call **WINRT_CanUnloadNow** (which calls the WRL function internally).</span></span> <span data-ttu-id="69c03-134">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="69c03-134">Here's a before-and-after code example.</span></span>

```cpp
HRESULT __stdcall DllCanUnloadNow(void)
{
    auto &module = Microsoft::WRL::Module<Microsoft::WRL::InProc>::GetModule();
    HRESULT hr = (module.Terminate() ? S_OK : S_FALSE);
    if (hr == S_OK)
    {
        hr = ...
    }
    return hr;
}
```

```cppwinrt
HRESULT __stdcall WINRT_CanUnloadNow();
HRESULT __stdcall DllCanUnloadNow(void)
{
    HRESULT hr = WINRT_CanUnloadNow();
    if (hr == S_OK)
    {
        hr = ...
    }
    return hr;
}
```

## <a name="important-apis"></a><span data-ttu-id="69c03-135">重要な API</span><span class="sxs-lookup"><span data-stu-id="69c03-135">Important APIs</span></span>
* [<span data-ttu-id="69c03-136">winrt::com_ptr 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="69c03-136">winrt::com_ptr struct template</span></span>](/uwp/cpp-ref-for-winrt/com-ptr)
* [<span data-ttu-id="69c03-137">winrt::Windows::Foundation::IUnknown 構造体</span><span class="sxs-lookup"><span data-stu-id="69c03-137">winrt::Windows::Foundation::IUnknown struct</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)

## <a name="related-topics"></a><span data-ttu-id="69c03-138">関連トピック</span><span class="sxs-lookup"><span data-stu-id="69c03-138">Related topics</span></span>
* [<span data-ttu-id="69c03-139">C++/WinRT の概要</span><span class="sxs-lookup"><span data-stu-id="69c03-139">Introduction to C++/WinRT</span></span>](intro-to-using-cpp-with-winrt.md)
* [<span data-ttu-id="69c03-140">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="69c03-140">Move to C++/WinRT from C++/CX</span></span>](move-to-winrt-from-cx.md)
* [<span data-ttu-id="69c03-141">Windows ランタイム C++ テンプレート ライブラリ (WRL)</span><span class="sxs-lookup"><span data-stu-id="69c03-141">Windows Runtime C++ Template Library (WRL)</span></span>](/cpp/windows/windows-runtime-cpp-template-library-wrl)
