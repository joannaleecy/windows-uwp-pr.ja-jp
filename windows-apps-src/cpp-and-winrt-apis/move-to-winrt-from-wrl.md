---
author: stevewhims
description: このトピックでは、WRL コードを C++/WinRT での同等のコードに移植する方法を示しています。
title: WRL から C++/WinRT への移行
ms.author: stwhi
ms.date: 05/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, WRL
ms.localizationpriority: medium
ms.openlocfilehash: 935b76e668153c9519bc6516da0c2872c2428f2e
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3851072"
---
# <a name="move-to-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-from-wrl"></a><span data-ttu-id="79fd8-104">WRL から [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) への移行</span><span class="sxs-lookup"><span data-stu-id="79fd8-104">Move to [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) from WRL</span></span>
<span data-ttu-id="79fd8-105">このトピックでは、[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) のコードを C++/WinRT の同等のコードに移植する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-105">This topic shows how to port [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) code to its equivalent in C++/WinRT.</span></span>

<span data-ttu-id="79fd8-106">C++/WinRT への移植の最初の手順は、C++/WinRT サポートをプロジェクトに手動で追加することです (「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="79fd8-106">The first step in porting to C++/WinRT is to manually add C++/WinRT support to your project (see [Visual Studio support for C++/WinRT, and the VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)).</span></span> <span data-ttu-id="79fd8-107">これを行うには、`.vcxproj` ファイルを編集し、`<PropertyGroup Label="Globals">` を見つけ、そのプロパティ グループ内で、プロパティ `<CppWinRTEnabled>true</CppWinRTEnabled>` を設定します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-107">To do that, edit your `.vcxproj` file, find `<PropertyGroup Label="Globals">` and, inside that property group, set the property `<CppWinRTEnabled>true</CppWinRTEnabled>`.</span></span> <span data-ttu-id="79fd8-108">その変更の 1 つの効果は、そのサポート[、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx)がプロジェクトで無効になります。</span><span class="sxs-lookup"><span data-stu-id="79fd8-108">One effect of that change is that support for [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) is turned off in the project.</span></span> <span data-ttu-id="79fd8-109">プロジェクトで C++/CX を使用している場合は、サポートを無効にしたままにし、C++/CX コードを C++/WinRT に更新することもできます (「[C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="79fd8-109">If you're using C++/CX in the project, then you can leave support turned off and update your C++/CX code to C++/WinRT as well (see [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md)).</span></span> <span data-ttu-id="79fd8-110">または、サポートをもう一度有効にし (プロジェクトのプロパティで、**[C/C++]** \> **[全般]** \> **[Windows ランタイム拡張機能の使用]** \> **[はい (/ZW)]** の順に選択)、まず WRL コードを移植することに集中することもできます。</span><span class="sxs-lookup"><span data-stu-id="79fd8-110">Or you can turn support back on (in project properties, **C/C++** \> **General** \> **Consume Windows Runtime Extension** \> **Yes (/ZW)**), and first focus on porting your WRL code.</span></span> <span data-ttu-id="79fd8-111">C++ +/CX と C++/WinRT コードには、XAML コンパイラ サポートと Windows ランタイム コンポーネントを除いて、同じプロジェクトに共存することができます (を参照してください[C への移行 + C + から WinRT/CX](move-to-winrt-from-cx.md))。</span><span class="sxs-lookup"><span data-stu-id="79fd8-111">C++/CX and C++/WinRT code can coexist in the same project, with the exception of XAML compiler support, and Windows Runtime Components (see [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md)).</span></span>

<span data-ttu-id="79fd8-112">プロジェクトのプロパティ (**[全般]** \> **[ターゲット プラットフォーム バージョン]**) を 10.0.17134.0 (Windows 10 バージョン 1803) 以上に設定します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-112">Set project property **General** \> **Target Platform Version** to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="79fd8-113">プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。</span><span class="sxs-lookup"><span data-stu-id="79fd8-113">In your precompiled header file (usually `pch.h`), include `winrt/base.h`.</span></span>

```cppwinrt
#include <winrt/base.h>
```

<span data-ttu-id="79fd8-114">C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。</span><span class="sxs-lookup"><span data-stu-id="79fd8-114">If you include any C++/WinRT projected Windows API headers (for example, `winrt/Windows.Foundation.h`), then you don't need to explicitly include `winrt/base.h` like this because it will be included automatically for you.</span></span>

## <a name="porting-wrl-com-smart-pointers-microsoftwrlcomptrcppwindowscomptr-class"></a><span data-ttu-id="79fd8-115">WRL COM スマート ポインター ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class)) の移植</span><span class="sxs-lookup"><span data-stu-id="79fd8-115">Porting WRL COM smart pointers ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class))</span></span>
<span data-ttu-id="79fd8-116">**Microsoft::WRL::ComPtr\<T\>** を使用するコードを移植して [**winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr) を使用します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-116">Port any code that uses **Microsoft::WRL::ComPtr\<T\>** to use [**winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr).</span></span> <span data-ttu-id="79fd8-117">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-117">Here's a before-and-after code example.</span></span> <span data-ttu-id="79fd8-118">*変更後の*バージョンでは、[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) メンバー関数は基になる生のポインターを取得して設定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="79fd8-118">In the *after* version, the [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) member function retrieves the underlying raw pointer so that it can be set.</span></span>

```cpp
ComPtr<IDXGIAdapter1> previousDefaultAdapter;
DX::ThrowIfFailed(m_dxgiFactory->EnumAdapters1(0, &previousDefaultAdapter));
```

```cppwinrt
winrt::com_ptr<IDXGIAdapter1> previousDefaultAdapter;
winrt::check_hresult(m_dxgiFactory->EnumAdapters1(0, previousDefaultAdapter.put()));
```

> [!IMPORTANT]
> <span data-ttu-id="79fd8-119">既に取り付けられている[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)があるかどうか (その内部の生のポインターは、ターゲットを既に持って) し、再シートさまざまなオブジェクトの場合は、ポイントされるようにする、まずを割り当てる必要があります`nullptr`を&mdash;に次のコード例で示すようにします。</span><span class="sxs-lookup"><span data-stu-id="79fd8-119">If you have a [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) that's already seated (its internal raw pointer already has a target) and you want to re-seat it to point to a different object, then you first need to assign `nullptr` to it&mdash;as shown in the code example below.</span></span> <span data-ttu-id="79fd8-120">ない場合は、し、既に取り付けられている**com_ptr**描画問題に (または呼び出すときに[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function))、注目によって、内部のポインターが null でないことをアサートします。</span><span class="sxs-lookup"><span data-stu-id="79fd8-120">If you don't, then an already-seated **com_ptr** will draw the issue to your attention (when you call [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) or [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)) by asserting that its internal pointer is not null.</span></span>

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

<span data-ttu-id="79fd8-121">次の例 (*変更後の*バージョン) では、[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) メンバー関数は基になる生のポインターを、無効にするポインターへのポインターとして取得します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-121">In this next example (in the *after* version), the [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) member function retrieves the underlying raw pointer as a pointer to a pointer to void.</span></span>

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

<span data-ttu-id="79fd8-122">**ComPtr::Get** を [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function) で置換します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-122">Replace **ComPtr::Get** with [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function).</span></span>

```cpp
m_d3dDevice->CreateDepthStencilView(m_depthStencil.Get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

```cppwinrt
m_d3dDevice->CreateDepthStencilView(m_depthStencil.get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

<span data-ttu-id="79fd8-123">**IUnknown**へのポインターを想定している関数には基になる生のポインターを渡す場合は、次の例に示す[**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function)自由関数を使用します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-123">When you want to pass the underlying raw pointer to a function that expects a pointer to **IUnknown**, use the [**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function) free function, as shown in this next example.</span></span>

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

## <a name="porting-a-wrl-module-microsoftwrlmodule"></a><span data-ttu-id="79fd8-124">WRL モジュール ([Microsoft::WRL::Module]()) の移植</span><span class="sxs-lookup"><span data-stu-id="79fd8-124">Porting a WRL module ([Microsoft::WRL::Module]())</span></span>
<span data-ttu-id="79fd8-125">WRL を使用してコンポーネントを実装する既存のプロジェクトに C++/WinRT コードを徐々に追加することができます。既存の WRL クラスは引き続きサポートされます。</span><span class="sxs-lookup"><span data-stu-id="79fd8-125">You can gradually add C++/WinRT code to an existing project that uses WRL to implement a component, and your existing WRL classes will continue to be supported.</span></span> <span data-ttu-id="79fd8-126">このセクションではその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-126">This section shows how.</span></span>

<span data-ttu-id="79fd8-127">Visual Studio でプロジェクトの種類として新しい **Windows ランタイム コンポーネント (C++/WinRT)** を作成する場合は、ファイル `Generated Files\module.g.cpp` が自動的に生成されます。</span><span class="sxs-lookup"><span data-stu-id="79fd8-127">If you create a new **Windows Runtime Component (C++/WinRT)** project type in Visual Studio, and build, then the file `Generated Files\module.g.cpp` is generated for you.</span></span> <span data-ttu-id="79fd8-128">そのファイルには、以下に示す 2 つ便利な C++/WinRT 関数の定義があり、これをプロジェクトにコピーして追加することができます。</span><span class="sxs-lookup"><span data-stu-id="79fd8-128">That file contains the definitions of two useful C++/WinRT functions (listed out below), which you can copy and add to your project.</span></span> <span data-ttu-id="79fd8-129">これらの関数は **WINRT_CanUnloadNow** および **WINRT_GetActivationFactory** です。ご覧になってわかるように、これらの関数は移植のどの段階でも開発者にサポートを提供できるように、条件付きで WRL を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-129">Those function are **WINRT_CanUnloadNow** and **WINRT_GetActivationFactory** and, as you can see, they conditionally call WRL in order to support you whatever stage of porting you're at.</span></span>

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

<span data-ttu-id="79fd8-130">プロジェクトにこれらの関数を含めたら、[**Module::GetActivationFactory**](/cpp/windows/module-getactivationfactory-method) を直接呼び出すのではなく、**WINRT_GetActivationFactory** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="79fd8-130">Once you have these functions in your project, instead of calling [**Module::GetActivationFactory**](/cpp/windows/module-getactivationfactory-method) directly, call **WINRT_GetActivationFactory** (which calls the WRL function internally).</span></span> <span data-ttu-id="79fd8-131">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-131">Here's a before-and-after code example.</span></span>

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

<span data-ttu-id="79fd8-132">[**Module::Terminate**](/cpp/windows/module-terminate-method) を直接呼び出す代わりに、**WINRT_CanUnloadNow** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="79fd8-132">Instead of calling [**Module::Terminate**](/cpp/windows/module-terminate-method) directly, call **WINRT_CanUnloadNow** (which calls the WRL function internally).</span></span> <span data-ttu-id="79fd8-133">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="79fd8-133">Here's a before-and-after code example.</span></span>

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

## <a name="important-apis"></a><span data-ttu-id="79fd8-134">重要な API</span><span class="sxs-lookup"><span data-stu-id="79fd8-134">Important APIs</span></span>
* [<span data-ttu-id="79fd8-135">winrt::com_ptr 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="79fd8-135">winrt::com_ptr struct template</span></span>](/uwp/cpp-ref-for-winrt/com-ptr)
* [<span data-ttu-id="79fd8-136">winrt::Windows::Foundation::IUnknown 構造体</span><span class="sxs-lookup"><span data-stu-id="79fd8-136">winrt::Windows::Foundation::IUnknown struct</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)

## <a name="related-topics"></a><span data-ttu-id="79fd8-137">関連トピック</span><span class="sxs-lookup"><span data-stu-id="79fd8-137">Related topics</span></span>
* [<span data-ttu-id="79fd8-138">C++/WinRT の概要</span><span class="sxs-lookup"><span data-stu-id="79fd8-138">Introduction to C++/WinRT</span></span>](intro-to-using-cpp-with-winrt.md)
* [<span data-ttu-id="79fd8-139">C++/CX から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="79fd8-139">Move to C++/WinRT from C++/CX</span></span>](move-to-winrt-from-cx.md)
* [<span data-ttu-id="79fd8-140">Windows ランタイム C++ テンプレート ライブラリ (WRL)</span><span class="sxs-lookup"><span data-stu-id="79fd8-140">Windows Runtime C++ Template Library (WRL)</span></span>](/cpp/windows/windows-runtime-cpp-template-library-wrl)
