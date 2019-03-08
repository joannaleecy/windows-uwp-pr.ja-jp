---
description: このトピックでは、WRL コードを C++/WinRT での同等のコードに移植する方法を示しています。
title: WRL から C++/WinRT への移行
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, WRL
ms.localizationpriority: medium
ms.openlocfilehash: e81f82fe823ee0fdf81741c89576adf268940d91
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630747"
---
# <a name="move-to-cwinrt-from-wrl"></a><span data-ttu-id="4806d-104">WRL から C++/WinRT への移行</span><span class="sxs-lookup"><span data-stu-id="4806d-104">Move to C++/WinRT from WRL</span></span>
<span data-ttu-id="4806d-105">このトピックでは、移植する方法を示しています。 [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) 、それに対応するコードを[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="4806d-105">This topic shows how to port [Windows Runtime C++ Template Library (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) code to its equivalent in [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span>

<span data-ttu-id="4806d-106">C + への移植の最初の手順/cli WinRT は、C + を手動で追加する/cli WinRT のサポートをプロジェクトに (を参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package))。</span><span class="sxs-lookup"><span data-stu-id="4806d-106">The first step in porting to C++/WinRT is to manually add C++/WinRT support to your project (see [Visual Studio support for C++/WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)).</span></span> <span data-ttu-id="4806d-107">インストール、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をプロジェクトにします。</span><span class="sxs-lookup"><span data-stu-id="4806d-107">To do that, install the [Microsoft.Windows.CppWinRT NuGet package](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/) into your project.</span></span> <span data-ttu-id="4806d-108">開いている Visual Studio でプロジェクトをクリックして**プロジェクト** \> **NuGet パッケージの管理.**\> **[参照]** 入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**そのプロジェクトのパッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="4806d-108">Open the project in Visual Studio, click **Project** \> **Manage NuGet Packages...** \> **Browse**, type or paste **Microsoft.Windows.CppWinRT** in the search box, select the item in search results, and then click **Install** to install the package for that project.</span></span> <span data-ttu-id="4806d-109">変更の 1 つの効果をサポートする[C +/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx)は、プロジェクトでは無効になります。</span><span class="sxs-lookup"><span data-stu-id="4806d-109">One effect of that change is that support for [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) is turned off in the project.</span></span> <span data-ttu-id="4806d-110">プロジェクトで C++/CX を使用している場合は、サポートを無効にしたままにし、C++/CX コードを C++/WinRT に更新することもできます (「[C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="4806d-110">If you're using C++/CX in the project, then you can leave support turned off and update your C++/CX code to C++/WinRT as well (see [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md)).</span></span> <span data-ttu-id="4806d-111">サポートを有効にすることができますか (プロジェクトのプロパティで**C/C++** \> **全般** \> **Windows ランタイム拡張機能の使用** \>**はい (/ZW)**)、WRL コードの移植に最初の注目します。</span><span class="sxs-lookup"><span data-stu-id="4806d-111">Or you can turn support back on (in project properties, **C/C++** \> **General** \> **Consume Windows Runtime Extension** \> **Yes (/ZW)**), and first focus on porting your WRL code.</span></span> <span data-ttu-id="4806d-112">C +/cli/CX および C++/cli WinRT コードは、XAML コンパイラ サポート、および Windows ランタイム コンポーネントを除き、同じプロジェクトで共存できます (を参照してください[移動 C +/cli WinRT C +/cli CX](move-to-winrt-from-cx.md))。</span><span class="sxs-lookup"><span data-stu-id="4806d-112">C++/CX and C++/WinRT code can coexist in the same project, with the exception of XAML compiler support, and Windows Runtime Components (see [Move to C++/WinRT from C++/CX](move-to-winrt-from-cx.md)).</span></span>

<span data-ttu-id="4806d-113">プロジェクトのプロパティを設定**全般** \> **ターゲット プラットフォーム バージョン**10.0.17134.0 (Windows 10、バージョン 1803) に以上。</span><span class="sxs-lookup"><span data-stu-id="4806d-113">Set project property **General** \> **Target Platform Version** to 10.0.17134.0 (Windows 10, version 1803) or greater.</span></span>

<span data-ttu-id="4806d-114">プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。</span><span class="sxs-lookup"><span data-stu-id="4806d-114">In your precompiled header file (usually `pch.h`), include `winrt/base.h`.</span></span>

```cppwinrt
#include <winrt/base.h>
```

<span data-ttu-id="4806d-115">C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4806d-115">If you include any C++/WinRT projected Windows API headers (for example, `winrt/Windows.Foundation.h`), then you don't need to explicitly include `winrt/base.h` like this because it will be included automatically for you.</span></span>

## <a name="porting-wrl-com-smart-pointers-microsoftwrlcomptrcppwindowscomptr-class"></a><span data-ttu-id="4806d-116">WRL COM スマート ポインター ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class)) の移植</span><span class="sxs-lookup"><span data-stu-id="4806d-116">Porting WRL COM smart pointers ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class))</span></span>
<span data-ttu-id="4806d-117">使用するコードを移植**Microsoft::WRL::ComPtr\<T\>** を使用する[ **winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr)します。</span><span class="sxs-lookup"><span data-stu-id="4806d-117">Port any code that uses **Microsoft::WRL::ComPtr\<T\>** to use [**winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr).</span></span> <span data-ttu-id="4806d-118">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4806d-118">Here's a before-and-after code example.</span></span> <span data-ttu-id="4806d-119">*変更後の*バージョンでは、[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) メンバー関数は基になる生のポインターを取得して設定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="4806d-119">In the *after* version, the [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) member function retrieves the underlying raw pointer so that it can be set.</span></span>

```cpp
ComPtr<IDXGIAdapter1> previousDefaultAdapter;
DX::ThrowIfFailed(m_dxgiFactory->EnumAdapters1(0, &previousDefaultAdapter));
```

```cppwinrt
winrt::com_ptr<IDXGIAdapter1> previousDefaultAdapter;
winrt::check_hresult(m_dxgiFactory->EnumAdapters1(0, previousDefaultAdapter.put()));
```

> [!IMPORTANT]
> <span data-ttu-id="4806d-120">ある場合、 [ **winrt::com_ptr** ](/uwp/cpp-ref-for-winrt/com-ptr)を既に接続されている (その内部の生のポインターは、ターゲットを既に持って) 再を別のオブジェクトを指す接続クライアント ライセンスするし、最初に割り当てる必要があります`nullptr`&mdash;次のコード例で示すようにします。</span><span class="sxs-lookup"><span data-stu-id="4806d-120">If you have a [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) that's already seated (its internal raw pointer already has a target) and you want to re-seat it to point to a different object, then you first need to assign `nullptr` to it&mdash;as shown in the code example below.</span></span> <span data-ttu-id="4806d-121">ない場合は、既に取り付けられていない**com_ptr**に対処する問題を描画 (を呼び出すと[ **com_ptr::put** ](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)または[ **com_ptr:。put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)) によって、その内部ポインターが null でないことをアサートします。</span><span class="sxs-lookup"><span data-stu-id="4806d-121">If you don't, then an already-seated **com_ptr** will draw the issue to your attention (when you call [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) or [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)) by asserting that its internal pointer is not null.</span></span>

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

<span data-ttu-id="4806d-122">次の例 (*変更後の*バージョン) では、[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) メンバー関数は基になる生のポインターを、無効にするポインターへのポインターとして取得します。</span><span class="sxs-lookup"><span data-stu-id="4806d-122">In this next example (in the *after* version), the [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) member function retrieves the underlying raw pointer as a pointer to a pointer to void.</span></span>

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

<span data-ttu-id="4806d-123">**ComPtr::Get** を [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function) で置換します。</span><span class="sxs-lookup"><span data-stu-id="4806d-123">Replace **ComPtr::Get** with [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function).</span></span>

```cpp
m_d3dDevice->CreateDepthStencilView(m_depthStencil.Get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

```cppwinrt
m_d3dDevice->CreateDepthStencilView(m_depthStencil.get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

<span data-ttu-id="4806d-124">ポインターを受け取る関数に基になる、生のポインターを渡す場合**IUnknown**を使用して、 [ **winrt::get_unknown** ](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function)次に示すように、関数を無料例です。</span><span class="sxs-lookup"><span data-stu-id="4806d-124">When you want to pass the underlying raw pointer to a function that expects a pointer to **IUnknown**, use the [**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function) free function, as shown in this next example.</span></span>

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

## <a name="porting-a-wrl-module-microsoftwrlmodule"></a><span data-ttu-id="4806d-125">WRL モジュール (Microsoft::WRL::Module) の移植</span><span class="sxs-lookup"><span data-stu-id="4806d-125">Porting a WRL module (Microsoft::WRL::Module)</span></span>
<span data-ttu-id="4806d-126">WRL を使用してコンポーネントを実装する既存のプロジェクトに C++/WinRT コードを徐々に追加することができます。既存の WRL クラスは引き続きサポートされます。</span><span class="sxs-lookup"><span data-stu-id="4806d-126">You can gradually add C++/WinRT code to an existing project that uses WRL to implement a component, and your existing WRL classes will continue to be supported.</span></span> <span data-ttu-id="4806d-127">このセクションではその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4806d-127">This section shows how.</span></span>

<span data-ttu-id="4806d-128">Visual Studio でプロジェクトの種類として新しい **Windows ランタイム コンポーネント (C++/WinRT)** を作成する場合は、ファイル `Generated Files\module.g.cpp` が自動的に生成されます。</span><span class="sxs-lookup"><span data-stu-id="4806d-128">If you create a new **Windows Runtime Component (C++/WinRT)** project type in Visual Studio, and build, then the file `Generated Files\module.g.cpp` is generated for you.</span></span> <span data-ttu-id="4806d-129">そのファイルには、以下に示す 2 つ便利な C++/WinRT 関数の定義があり、これをプロジェクトにコピーして追加することができます。</span><span class="sxs-lookup"><span data-stu-id="4806d-129">That file contains the definitions of two useful C++/WinRT functions (listed out below), which you can copy and add to your project.</span></span> <span data-ttu-id="4806d-130">これらの関数は **WINRT_CanUnloadNow** および **WINRT_GetActivationFactory** です。ご覧になってわかるように、これらの関数は移植のどの段階でも開発者にサポートを提供できるように、条件付きで WRL を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4806d-130">Those function are **WINRT_CanUnloadNow** and **WINRT_GetActivationFactory** and, as you can see, they conditionally call WRL in order to support you whatever stage of porting you're at.</span></span>

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

<span data-ttu-id="4806d-131">プロジェクトにこれらの関数を含めたら、[**Module::GetActivationFactory**](/cpp/windows/module-getactivationfactory-method) を直接呼び出すのではなく、**WINRT_GetActivationFactory** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="4806d-131">Once you have these functions in your project, instead of calling [**Module::GetActivationFactory**](/cpp/windows/module-getactivationfactory-method) directly, call **WINRT_GetActivationFactory** (which calls the WRL function internally).</span></span> <span data-ttu-id="4806d-132">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4806d-132">Here's a before-and-after code example.</span></span>

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

<span data-ttu-id="4806d-133">[  **Module::Terminate**](/cpp/windows/module-terminate-method) を直接呼び出す代わりに、**WINRT_CanUnloadNow** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="4806d-133">Instead of calling [**Module::Terminate**](/cpp/windows/module-terminate-method) directly, call **WINRT_CanUnloadNow** (which calls the WRL function internally).</span></span> <span data-ttu-id="4806d-134">変更前と変更後のコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4806d-134">Here's a before-and-after code example.</span></span>

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

## <a name="important-apis"></a><span data-ttu-id="4806d-135">重要な API</span><span class="sxs-lookup"><span data-stu-id="4806d-135">Important APIs</span></span>
* [<span data-ttu-id="4806d-136">winrt::com_ptr 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="4806d-136">winrt::com_ptr struct template</span></span>](/uwp/cpp-ref-for-winrt/com-ptr)
* [<span data-ttu-id="4806d-137">winrt::Windows::Foundation::IUnknown 構造体</span><span class="sxs-lookup"><span data-stu-id="4806d-137">winrt::Windows::Foundation::IUnknown struct</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)

## <a name="related-topics"></a><span data-ttu-id="4806d-138">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4806d-138">Related topics</span></span>
* [<span data-ttu-id="4806d-139">概要 C +/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="4806d-139">Introduction to C++/WinRT</span></span>](intro-to-using-cpp-with-winrt.md)
* [<span data-ttu-id="4806d-140">移動する C +/cli WinRT C +/cli CX</span><span class="sxs-lookup"><span data-stu-id="4806d-140">Move to C++/WinRT from C++/CX</span></span>](move-to-winrt-from-cx.md)
* [<span data-ttu-id="4806d-141">Windows ランタイム C++ テンプレート ライブラリ (WRL)</span><span class="sxs-lookup"><span data-stu-id="4806d-141">Windows Runtime C++ Template Library (WRL)</span></span>](/cpp/windows/windows-runtime-cpp-template-library-wrl)
