---
description: このトピックでは、WRL コードを C++/WinRT での同等のコードに移植する方法を示しています。
title: WRL から C++/WinRT への移行
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, WRL
ms.localizationpriority: medium
ms.openlocfilehash: 1d11d0dcdf13982e0754a84de00f22c02090e822
ms.sourcegitcommit: 9031a51f9731f0b675769e097aa4d914b4854e9e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/29/2019
ms.locfileid: "58618389"
---
# <a name="move-to-cwinrt-from-wrl"></a>WRL から C++/WinRT への移行
このトピックでは、移植する方法を示しています。 [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) 、それに対応するコードを[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。

C + への移植の最初の手順/cli WinRT は、C + を手動で追加する/cli WinRT のサポートをプロジェクトに (を参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package))。 インストール、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をプロジェクトにします。 開いている Visual Studio でプロジェクトをクリックして**プロジェクト** \> **NuGet パッケージの管理.**\> **[参照]** 入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**そのプロジェクトのパッケージをインストールします。 変更の 1 つの効果をサポートする[C +/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx)は、プロジェクトでは無効になります。 プロジェクトで C++/CX を使用している場合は、サポートを無効にしたままにし、C++/CX コードを C++/WinRT に更新することもできます (「[C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)」を参照してください)。 サポートを有効にすることができますか (プロジェクトのプロパティで**C/C++** \> **全般** \> **Windows ランタイム拡張機能の使用** \>**はい (/ZW)**)、WRL コードの移植に最初の注目します。 C +/cli/CX および C++/cli WinRT コードは、XAML コンパイラ サポート、および Windows ランタイム コンポーネントを除き、同じプロジェクトで共存できます (を参照してください[移動 C +/cli WinRT C +/cli CX](move-to-winrt-from-cx.md))。

プロジェクトのプロパティを設定**全般** \> **ターゲット プラットフォーム バージョン**10.0.17134.0 (Windows 10、バージョン 1803) に以上。

プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。

```cppwinrt
#include <winrt/base.h>
```

C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。

## <a name="porting-wrl-com-smart-pointers-microsoftwrlcomptrcppwindowscomptr-class"></a>WRL COM スマート ポインター ([Microsoft::WRL::ComPtr](/cpp/windows/comptr-class)) の移植
使用するコードを移植**Microsoft::WRL::ComPtr\<T\>** を使用する[ **winrt::com_ptr\<T\>**](/uwp/cpp-ref-for-winrt/com-ptr)します。 変更前と変更後のコード例を次に示します。 *変更後の*バージョンでは、[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#com_ptrput-function) メンバー関数は基になる生のポインターを取得して設定できるようにします。

```cpp
ComPtr<IDXGIAdapter1> previousDefaultAdapter;
DX::ThrowIfFailed(m_dxgiFactory->EnumAdapters1(0, &previousDefaultAdapter));
```

```cppwinrt
winrt::com_ptr<IDXGIAdapter1> previousDefaultAdapter;
winrt::check_hresult(m_dxgiFactory->EnumAdapters1(0, previousDefaultAdapter.put()));
```

> [!IMPORTANT]
> ある場合、 [ **winrt::com_ptr** ](/uwp/cpp-ref-for-winrt/com-ptr)を既に接続されている (その内部の生のポインターは、ターゲットを既に持って) 再を別のオブジェクトを指す接続クライアント ライセンスするし、最初に割り当てる必要があります`nullptr`&mdash;次のコード例で示すようにします。 ない場合は、既に取り付けられていない**com_ptr**に対処する問題を描画 (を呼び出すと[ **com_ptr::put** ](/uwp/cpp-ref-for-winrt/com-ptr#com_ptrput-function)または[ **com_ptr:。put_void**](/uwp/cpp-ref-for-winrt/com-ptr#com_ptrput_void-function)) によって、その内部ポインターが null でないことをアサートします。

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

次の例 (*変更後の*バージョン) では、[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#com_ptrput_void-function) メンバー関数は基になる生のポインターを、無効にするポインターへのポインターとして取得します。

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

**ComPtr::Get** を [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#com_ptrget-function) で置換します。

```cpp
m_d3dDevice->CreateDepthStencilView(m_depthStencil.Get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

```cppwinrt
m_d3dDevice->CreateDepthStencilView(m_depthStencil.get(), &dsvDesc, m_dsvHeap->GetCPUDescriptorHandleForHeapStart());
```

ポインターを受け取る関数に基になる、生のポインターを渡す場合**IUnknown**を使用して、 [ **winrt::get_unknown** ](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#get_unknown-function)次に示すように、関数を無料例です。

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

## <a name="porting-a-wrl-module-microsoftwrlmodule"></a>WRL モジュール (Microsoft::WRL::Module) の移植
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

[  **Module::Terminate**](/cpp/windows/module-terminate-method) を直接呼び出す代わりに、**WINRT_CanUnloadNow** を呼び出します (これにより WRL 関数が内部的に呼び出されます)。 変更前と変更後のコード例を次に示します。

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
* [winrt::com_ptr 構造体のテンプレート](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::Windows::Foundation::IUnknown 構造体](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT の概要](intro-to-using-cpp-with-winrt.md)
* [C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)
* [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)
