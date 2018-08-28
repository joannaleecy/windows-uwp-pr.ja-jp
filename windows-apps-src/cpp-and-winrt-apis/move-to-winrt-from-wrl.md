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
ms.openlocfilehash: 3b9afd50b2c360c11b103f676b91d512881eaa71
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2890811"
---
# <a name="move-to-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt-from-wrl"></a>WRL から [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) への移行
このトピックでは、[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) のコードを C++/WinRT の同等のコードに移植する方法について説明します。

C++/WinRT への移植の最初の手順は、C++/WinRT サポートをプロジェクトに手動で追加することです (「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください)。 これを行うには、`.vcxproj` ファイルを編集し、`<PropertyGroup Label="Globals">` を見つけ、そのプロパティ グループ内で、プロパティ `<CppWinRTEnabled>true</CppWinRTEnabled>` を設定します。 その変更の 1 つの効果をサポートするが[C + +/CX](/cpp/cppcx/visual-c-language-reference-c-cx)プロジェクトでオフにします。 プロジェクトで C++/CX を使用している場合は、サポートを無効にしたままにし、C++/CX コードを C++/WinRT に更新することもできます (「[C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)」を参照してください)。 または、サポートをもう一度有効にし (プロジェクトのプロパティで、**[C/C++]** \> **[全般]** \> **[Windows ランタイム拡張機能の使用]** \> **[はい (/ZW)]** の順に選択)、まず WRL コードを移植することに集中することもできます。 C + +/CX と C + +/XAML コンパイラのサポートと Windows ランタイム コンポーネントを除き、同じプロジェクトに WinRT コードを混在させることができます (を参照してください[への変更 C + +/C + から WinRT +/CX](move-to-winrt-from-cx.md)) します。

プロジェクトのプロパティ (**[全般]** \> **[ターゲット プラットフォーム バージョン]**) を 10.0.17134.0 (Windows 10 バージョン 1803) 以上に設定します。

プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。

```cppwinrt
#include <winrt/base.h>
```

C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。

## <a name="porting-wrl-com-smart-pointers-microsoftwrlcomptrcppwindowscomptr-class"></a>WRL COM スマート ポインター ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class)) の移植
**Microsoft::WRL::ComPtr\<T\>** を使用するコードを移植して [**winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr) を使用します。 変更前と変更後のコード例を次に示します。 *変更後の*バージョンでは、[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) メンバー関数は基になる生のポインターを取得して設定できるようにします。

```cpp
ComPtr<IDXGIAdapter1> previousDefaultAdapter;
DX::ThrowIfFailed(m_dxgiFactory->EnumAdapters1(0, &previousDefaultAdapter));
```

```cppwinrt
winrt::com_ptr<IDXGIAdapter1> previousDefaultAdapter;
winrt::check_hresult(m_dxgiFactory->EnumAdapters1(0, previousDefaultAdapter.put()));
```

> [!IMPORTANT]
> 既に固定されている[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)があるかどうかは (その内部生ポインターは既にターゲット) し、もう一度、別のオブジェクトを指すように固定する、まずを割り当てる必要があります`nullptr`に&mdash;コード例を次に示すようにします。 ない場合は、[既に固定**com_ptr**は描画問題 ( [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)または[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)を呼び出す) 場合は、対応するによって、その内部ポインターが null でないことを表明します。

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

次の例 (*変更後の*バージョン) では、[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) メンバー関数は基になる生のポインターを、無効にするポインターへのポインターとして取得します。

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

**ComPtr::Get** を [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function) で置換します。

```cpp
m_d3dDevice->CreateDepthStencilView(m_depthStencil.Get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

```cppwinrt
m_d3dDevice->CreateDepthStencilView(m_depthStencil.get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

**IUnknown**ポインターを要求する関数を基になる生ポインターを通過する場合は、次の例のように、 [**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function)無料関数を使用します。

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

## <a name="porting-a-wrl-module-microsoftwrlmodule"></a>WRL モジュール ([Microsoft::WRL::Module]()) の移植
WRL を使用してコンポーネントを実装する既存のプロジェクトに C++/WinRT コードを徐々に追加することができます。既存の WRL クラスは引き続きサポートされます。 このセクションではその方法を示します。

Visual Studio でプロジェクトの種類として新しい **Windows ランタイム コンポーネント (C++/WinRT)** を作成する場合は、ファイル `Generated Files\module.g.cpp` が自動的に生成されます。 そのファイルには、以下に示す 2 つ便利な C++/WinRT 関数の定義があり、これをプロジェクトにコピーして追加することができます。 これらの関数は **WINRT_CanUnloadNow** および **WINRT_GetActivationFactory** です。ご覧になってわかるように、これらの関数は移植のどの段階でも開発者にサポートを提供できるように、条件付きで WRL を呼び出します。

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

プロジェクトにこれらの関数を含めたら、[**Module::GetActivationFactory**](/cpp/windows/module-getactivationfactory-method) を直接呼び出すのではなく、**WINRT_GetActivationFactory** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。 変更前と変更後のコード例を次に示します。

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

[**Module::Terminate**](/cpp/windows/module-terminate-method) を直接呼び出す代わりに、**WINRT_CanUnloadNow** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。 変更前と変更後のコード例を次に示します。

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

## <a name="important-apis"></a>重要な API
* [winrt::com_ptr](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::Windows::Foundation::IUnknown 構造体](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT の概要](intro-to-using-cpp-with-winrt.md)
* [C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)
* [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)
