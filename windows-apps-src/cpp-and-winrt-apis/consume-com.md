---
author: stevewhims
description: このトピックでは、Direct2D の完全なコード例を使用して、C++ を使用する方法を示して/WinRT COM クラスとインターフェイスを利用します。
title: C++/WinRT での COM コンポーネントの使用
ms.author: stwhi
ms.date: 07/23/2018
ms.topic: article
keywords: windows 10、uwp、標準、c++、cpp、winrt、COM、コンポーネント、クラス、インターフェイス
ms.localizationpriority: medium
ms.openlocfilehash: a07c9877a6d6d953e578d927959b1202444ede21
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6275967"
---
# <a name="consume-com-components-with-cwinrt"></a><span data-ttu-id="f20cc-104">C++/WinRT での COM コンポーネントの使用</span><span class="sxs-lookup"><span data-stu-id="f20cc-104">Consume COM components with C++/WinRT</span></span>

<span data-ttu-id="f20cc-105">機能を使用して、 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) DirectX Api の高パフォーマンスの 2-d および 3-D グラフィックスなどの COM コンポーネントを使用するライブラリ。</span><span class="sxs-lookup"><span data-stu-id="f20cc-105">You can use the facilities of the [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) library to consume COM components, such as the high-performance 2-D and 3-D graphics of the DirectX APIs.</span></span> <span data-ttu-id="f20cc-106">C++/cli/winrt はパフォーマンスを損なうことがなく、DirectX を使用する最も簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="f20cc-106">C++/WinRT is the simplest way to use DirectX without compromising performance.</span></span> <span data-ttu-id="f20cc-107">このトピックでは、Direct2D のコード例を使用して、C++ を使用する方法を示して/WinRT COM クラスとインターフェイスを利用します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-107">This topic uses a Direct2D code example to show how to use C++/WinRT to consume COM classes and interfaces.</span></span> <span data-ttu-id="f20cc-108">同じの C + 内での COM と Windows ランタイムのプログラミングを混在させる、もちろん、/WinRT プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="f20cc-108">You can, of course, mix COM and Windows Runtime programming within the same C++/WinRT project.</span></span>

<span data-ttu-id="f20cc-109">このトピックの最後に、最小限の Direct2D アプリケーションの完全なソース コードの登録情報がわかります。</span><span class="sxs-lookup"><span data-stu-id="f20cc-109">At the end of this topic, you'll find a full source code listing of a minimal Direct2D application.</span></span> <span data-ttu-id="f20cc-110">します。 そのコードからの抜粋を放したしてそれらを使用すると、COM コンポーネントを使用して、C++ を使用する方法を示す/c++ のさまざまな機能を使用して WinRT/WinRT ライブラリ。</span><span class="sxs-lookup"><span data-stu-id="f20cc-110">We'll lift excerpts from that code and use them to illustrate how to consume COM components using C++/WinRT using various facilities of the C++/WinRT library.</span></span>

## <a name="com-smart-pointers-winrtcomptruwpcpp-ref-for-winrtcom-ptr"></a><span data-ttu-id="f20cc-111">COM のスマート ポインター ([**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr))</span><span class="sxs-lookup"><span data-stu-id="f20cc-111">COM smart pointers ([**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr))</span></span>

<span data-ttu-id="f20cc-112">Com プログラミングする (つまりのバック グラウンドでの Windows ランタイム Api では、COM の進化したものである場合は true も) オブジェクトではなく、インターフェイスを直接操作します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-112">When you program with COM, you work directly with interfaces rather than with objects (that's also true behind the scenes for Windows Runtime APIs, which are an evolution of COM).</span></span> <span data-ttu-id="f20cc-113">COM クラスで関数を呼び出す、たとえば、アクティブ化する、クラス、インターフェイスを取得し、そのインターフェイスの関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-113">To call a function on a COM class, for example, you activate the class, get an interface back, and then you call functions on that interface.</span></span> <span data-ttu-id="f20cc-114">オブジェクトの状態にアクセスするにしない直接アクセスする、データ メンバーです。代わりに、インターフェイスのアクセサーとミューテーター関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-114">To access the state of an object, you don't access its data members directly; instead, you call accessor and mutator functions on an interface.</span></span>

<span data-ttu-id="f20cc-115">具体的には、話のインターフェイス*ポインター*を操作します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-115">To be more specific, we're talking about interacting with interface *pointers*.</span></span> <span data-ttu-id="f20cc-116">そのため、おメリット、C++ での COM スマート ポインターの種類の存在と/WinRT&mdash; [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)の種類。</span><span class="sxs-lookup"><span data-stu-id="f20cc-116">And for that, we benefit from the existence of the COM smart pointer type in C++/WinRT&mdash;the [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) type.</span></span>

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
```

<span data-ttu-id="f20cc-117">上記のコードは、 [**ID2D1Factory1**](https://msdn.microsoft.com/library/Hh404596) COM インターフェイスへの初期化されていないスマート ポインターを宣言する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f20cc-117">The code above shows how to declare an uninitialized smart pointer to a [**ID2D1Factory1**](https://msdn.microsoft.com/library/Hh404596) COM interface.</span></span> <span data-ttu-id="f20cc-118">スマート ポインターは、実際のオブジェクト (いないポイント インターフェイスにまったく) に属する**ID2D1Factory1**インターフェイスをポイントされていないために、初期化されていません。</span><span class="sxs-lookup"><span data-stu-id="f20cc-118">The smart pointer is uninitialized, so it's not yet pointing to a **ID2D1Factory1** interface belonging to any actual object (it's not pointing to an interface at all).</span></span> <span data-ttu-id="f20cc-119">これを行う可能性があります。あり (スマート ポインターされている) 経由での COM 参照カウントを指すインターフェイスの所有するオブジェクトの有効期間を管理して、そのインターフェイスの関数を呼び出す中にすることができます。</span><span class="sxs-lookup"><span data-stu-id="f20cc-119">But it has the potential to do so; and (being a smart pointer) it has the ability via COM reference counting to manage the lifetime of the owning object of the interface that it points to, and to be the medium by which you call functions on that interface.</span></span>

## <a name="com-functions-that-return-an-interface-pointer-as-void"></a><span data-ttu-id="f20cc-120">**Void**としてインターフェイス ポインターを返す COM 関数</span><span class="sxs-lookup"><span data-stu-id="f20cc-120">COM functions that return an interface pointer as **void**</span></span>

<span data-ttu-id="f20cc-121">初期化のスマート ポインターの生のポインターを基になるに書き込む[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)関数を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="f20cc-121">You can call the [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) function to write to an uninitialized smart pointer's underlying raw pointer.</span></span>

```cppwinrt
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    &options,
    factory.put_void()
);
```

<span data-ttu-id="f20cc-122">上記のコードは、最後のパラメーターを介して**ID2D1Factory1**インターフェイス ポインターを返す[**D2D1CreateFactory**](/windows/desktop/api/d2d1/nf-d2d1-d2d1createfactory)関数を呼び出し、 \*\*void\ \* \ \*\*\* の種類。</span><span class="sxs-lookup"><span data-stu-id="f20cc-122">The code above calls the [**D2D1CreateFactory**](/windows/desktop/api/d2d1/nf-d2d1-d2d1createfactory) function, which returns an **ID2D1Factory1** interface pointer via its last parameter, which has **void\*\*** type.</span></span> <span data-ttu-id="f20cc-123">多くの COM 関数が返す、 \*\*void\ \* \ \*\*\* します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-123">Many COM functions return a **void\*\***.</span></span> <span data-ttu-id="f20cc-124">このような機能を示す[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)を使用します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-124">For such functions, use [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function) as shown.</span></span>

## <a name="com-functions-that-return-a-specific-interface-pointer"></a><span data-ttu-id="f20cc-125">COM を特定のインターフェイス ポインターを返す関数</span><span class="sxs-lookup"><span data-stu-id="f20cc-125">COM functions that return a specific interface pointer</span></span>

<span data-ttu-id="f20cc-126">[**D3D11CreateDevice**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)関数では、 [**ID3D11Device**](https://msdn.microsoft.com/library/Hh404596)インターフェイス ポインターを返しますがその antepenultimate パラメーターを介して\*\*ID3D11Device\ \* \ \*\*\* の種類。</span><span class="sxs-lookup"><span data-stu-id="f20cc-126">The [**D3D11CreateDevice**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory) function returns an [**ID3D11Device**](https://msdn.microsoft.com/library/Hh404596) interface pointer via its antepenultimate parameter, which has **ID3D11Device\*\*** type.</span></span> <span data-ttu-id="f20cc-127">そのような特定のインターフェイス ポインターを返す関数では、 [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)を使用します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-127">For functions that return a specific interface pointer like that, use [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function).</span></span>

```cppwinrt
winrt::com_ptr<ID3D11Device> device;
D3D11CreateDevice(
    ...
    device.put(),
    ...);
```

<span data-ttu-id="f20cc-128">前に、のセクションのコード例は、生**D2D1CreateFactory**関数を呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f20cc-128">The code example in the section before this one shows how to call the raw **D2D1CreateFactory** function.</span></span> <span data-ttu-id="f20cc-129">実際には、このトピックのコード例では、 **D2D1CreateFactory**を呼び出し、生の API をラップするヘルパー関数テンプレートを使用し、ためのコード例は、 [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)実際を使用します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-129">But in fact, when the code example for this topic calls **D2D1CreateFactory**, it uses a helper function template that wraps the raw API, and so the code example actually uses [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function).</span></span>

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    options,
    factory.put());
```

## <a name="com-functions-that-return-an-interface-pointer-as-iunknown"></a><span data-ttu-id="f20cc-130">**IUnknown**としてインターフェイス ポインターを返す COM 関数</span><span class="sxs-lookup"><span data-stu-id="f20cc-130">COM functions that return an interface pointer as **IUnknown**</span></span>

<span data-ttu-id="f20cc-131">[**DWriteCreateFactory**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)関数は、 [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509)型には、最後のパラメーターを介して DirectWrite ファクトリのインターフェイス ポインターを返します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-131">The [**DWriteCreateFactory**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory) function returns a DirectWrite factory interface pointer via its last parameter, which has [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) type.</span></span> <span data-ttu-id="f20cc-132">このような関数の場合は、使用[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)が解釈されるにキャスト**IUnknown**。</span><span class="sxs-lookup"><span data-stu-id="f20cc-132">For such a function, use [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function), but reinterpret cast that to **IUnknown**.</span></span>

```cppwinrt
DWriteCreateFactory(
    DWRITE_FACTORY_TYPE_SHARED,
    __uuidof(dwriteFactory2),
    reinterpret_cast<IUnknown**>(dwriteFactory2.put()));
```

## <a name="re-seat-a-winrtcomptr"></a><span data-ttu-id="f20cc-133">**Winrt::com_ptr**を再シートします。</span><span class="sxs-lookup"><span data-stu-id="f20cc-133">Re-seat a **winrt::com_ptr**</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f20cc-134">既に取り付けられている[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)があるかどうか (その内部の生のポインターが既にターゲット) し、再シートを別のオブジェクトを指す場合、最初に割り当てる必要があります`nullptr`に&mdash;次のコード例に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="f20cc-134">If you have a [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) that's already seated (its internal raw pointer already has a target) and you want to re-seat it to point to a different object, then you first need to assign `nullptr` to it&mdash;as shown in the code example below.</span></span> <span data-ttu-id="f20cc-135">ない場合は、し、既に取り付けられている**com_ptr**描画問題 ( [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)または[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)呼び出す) と、注意をによって、内部のポインターが null でないことをアサートします。</span><span class="sxs-lookup"><span data-stu-id="f20cc-135">If you don't, then an already-seated **com_ptr** will draw the issue to your attention (when you call [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function) or [**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)) by asserting that its internal pointer is not null.</span></span>

```cppwinrt
winrt::com_ptr<ID2D1SolidColorBrush> brush;
...
    brush.put()
...
brush = nullptr; // Important because we're about to re-seat
target->CreateSolidColorBrush(
    color_orange,
    D2D1::BrushProperties(0.8f),
    brush.put()));
```

## <a name="handle-hresult-error-codes"></a><span data-ttu-id="f20cc-136">HRESULT エラー コードを処理します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-136">Handle HRESULT error codes</span></span>

<span data-ttu-id="f20cc-137">COM 関数から返された HRESULT の値をチェックして、エラー コードを表すことで例外がスロー、 [**winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-137">To check the value of a HRESULT returned from a COM function, and throw an exception in the event that it represents an error code, call [**winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult).</span></span>

```cppwinrt
winrt::check_hresult(D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    options,
    factory.put_void()));
```

## <a name="com-functions-that-take-a-specific-interface-pointer"></a><span data-ttu-id="f20cc-138">特定のインターフェイス ポインターを受け取る COM 関数</span><span class="sxs-lookup"><span data-stu-id="f20cc-138">COM functions that take a specific interface pointer</span></span>

<span data-ttu-id="f20cc-139">同じ種類の特定のインターフェイス ポインターを受け取る関数に渡すと、 **com_ptr**に[**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function)関数を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="f20cc-139">You can call the [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function) function to pass your **com_ptr** to a function that takes a specific interface pointer of the same type.</span></span>

```cppwinrt
... ExampleFunction(
    winrt::com_ptr<ID2D1Factory1> const& factory,
    winrt::com_ptr<IDXGIDevice> const& dxdevice)
{
    ...
    winrt::check_hresult(factory->CreateDevice(dxdevice.get(), ...));
    ...
}
```

## <a name="com-functions-that-take-an-iunknown-interface-pointer"></a><span data-ttu-id="f20cc-140">**IUnknown**インターフェイス ポインターを受け取る COM 関数</span><span class="sxs-lookup"><span data-stu-id="f20cc-140">COM functions that take an **IUnknown** interface pointer</span></span>

<span data-ttu-id="f20cc-141">**IUnknown**インターフェイス ポインターを受け取る関数に渡すと、 **com_ptr**に[**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function)自由関数を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="f20cc-141">You can call the [**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function) free function to pass your **com_ptr** to a function that takes an **IUnknown** interface pointer.</span></span>

```cppwinrt
winrt::check_hresult(factory->CreateSwapChainForCoreWindow(
    ...
    winrt::get_unknown(CoreWindow::GetForCurrentThread()),
    ...));
```

## <a name="passing-and-returning-com-smart-pointers"></a><span data-ttu-id="f20cc-142">スマート ポインターを渡すと、COM を返す</span><span class="sxs-lookup"><span data-stu-id="f20cc-142">Passing and returning COM smart pointers</span></span>

<span data-ttu-id="f20cc-143">**Winrt::com_ptr**の形式での COM スマート ポインターを受ける関数な定数の参照によってや参照によって。</span><span class="sxs-lookup"><span data-stu-id="f20cc-143">A function taking a COM smart pointer in the form of a **winrt::com_ptr** should do so by constant reference, or by reference.</span></span>

```cppwinrt
... GetDxgiFactory(winrt::com_ptr<ID3D11Device> const& device) ...

... CreateDevice(..., winrt::com_ptr<ID3D11Device>& device) ...
```

<span data-ttu-id="f20cc-144">**Winrt::com_ptr**を返す関数で行ってください値。</span><span class="sxs-lookup"><span data-stu-id="f20cc-144">A function that returns a **winrt::com_ptr** should do so by value.</span></span>

```cppwinrt
winrt::com_ptr<ID2D1Factory1> CreateFactory() ...
```

## <a name="query-a-com-smart-pointer-for-a-different-interface"></a><span data-ttu-id="f20cc-145">さまざまなインターフェイスの COM スマート ポインターを照会します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-145">Query a COM smart pointer for a different interface</span></span>

<span data-ttu-id="f20cc-146">[**Com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function)関数を使用すると、さまざまなインターフェイスの COM スマート ポインターを照会します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-146">You can use the [**com_ptr::as**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function) function to query a COM smart pointer for a different interface.</span></span> <span data-ttu-id="f20cc-147">関数は、クエリに失敗する場合に例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="f20cc-147">The function throws an exception if the query doesn't succeed.</span></span>

```cppwinrt
void ExampleFunction(winrt::com_ptr<ID3D11Device> const& device)
{
    ...
    winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };
    ...
}
```

<span data-ttu-id="f20cc-148">また、 [**com_ptr::try_as**](/uwp/cpp-ref-for-winrt/com-ptr#comptrtryas-function)、に対してチェックできる数値を返します。 これを使用して`nullptr`クエリが成功したかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-148">Alternatively, use [**com_ptr::try_as**](/uwp/cpp-ref-for-winrt/com-ptr#comptrtryas-function), which returns a value that you can check against `nullptr` to see whether the query succeeded.</span></span>

## <a name="full-source-code-listing-of-a-minimal-direct2d-application"></a><span data-ttu-id="f20cc-149">Direct2D アプリケーションを最小限の完全なソース コードの一覧</span><span class="sxs-lookup"><span data-stu-id="f20cc-149">Full source code listing of a minimal Direct2D application</span></span>

<span data-ttu-id="f20cc-150">ビルドして Visual Studio で、このソース コード例、最初を実行する場合は、作成、新しい**コア アプリ (、C++/WinRT)** します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-150">If you want to build and run this source code example then first, in Visual Studio, create a new **Core App (C++/WinRT)**.</span></span> `Direct2D` <span data-ttu-id="f20cc-151">プロジェクトの適切な名前ですが、どのようなという名前ことができます。</span><span class="sxs-lookup"><span data-stu-id="f20cc-151">is a reasonable name for the project, but you can name it anything you like.</span></span> <span data-ttu-id="f20cc-152">開いている`App.cpp`、その内容全体を削除し、以下のリストを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="f20cc-152">Open `App.cpp`, delete its entire contents, and paste in the listing below.</span></span>

```cppwinrt
#include "pch.h"
#include <d2d1_1.h>
#include <d3d11.h>
#include <dxgi1_2.h>
#include <winrt/Windows.Graphics.Display.h>

using namespace winrt;

using namespace Windows;
using namespace Windows::ApplicationModel::Core;
using namespace Windows::UI;
using namespace Windows::UI::Core;
using namespace Windows::Graphics::Display;

namespace
{
    winrt::com_ptr<ID2D1Factory1> CreateFactory()
    {
        D2D1_FACTORY_OPTIONS options{};

#ifdef _DEBUG
        options.debugLevel = D2D1_DEBUG_LEVEL_INFORMATION;
#endif

        winrt::com_ptr<ID2D1Factory1> factory;

        winrt::check_hresult(D2D1CreateFactory(
            D2D1_FACTORY_TYPE_SINGLE_THREADED,
            options,
            factory.put()));

        return factory;
    }

    HRESULT CreateDevice(D3D_DRIVER_TYPE const type, winrt::com_ptr<ID3D11Device>& device)
    {
        WINRT_ASSERT(!device);

        return D3D11CreateDevice(
            nullptr,
            type,
            nullptr,
            D3D11_CREATE_DEVICE_BGRA_SUPPORT,
            nullptr, 0,
            D3D11_SDK_VERSION,
            device.put(),
            nullptr,
            nullptr);
    }

    winrt::com_ptr<ID3D11Device> CreateDevice()
    {
        winrt::com_ptr<ID3D11Device> device;
        HRESULT hr{ CreateDevice(D3D_DRIVER_TYPE_HARDWARE, device) };

        if (DXGI_ERROR_UNSUPPORTED == hr)
        {
            hr = CreateDevice(D3D_DRIVER_TYPE_WARP, device);
        }

        winrt::check_hresult(hr);
        return device;
    }

    winrt::com_ptr<ID2D1DeviceContext> CreateRenderTarget(
        winrt::com_ptr<ID2D1Factory1> const& factory,
        winrt::com_ptr<ID3D11Device> const& device)
    {
        WINRT_ASSERT(factory);
        WINRT_ASSERT(device);

        winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };

        winrt::com_ptr<ID2D1Device> d2device;
        winrt::check_hresult(factory->CreateDevice(dxdevice.get(), d2device.put()));

        winrt::com_ptr<ID2D1DeviceContext> target;
        winrt::check_hresult(d2device->CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS_NONE, target.put()));
        return target;
    }

    winrt::com_ptr<IDXGIFactory2> GetDxgiFactory(winrt::com_ptr<ID3D11Device> const& device)
    {
        WINRT_ASSERT(device);

        winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };

        winrt::com_ptr<IDXGIAdapter> adapter;
        winrt::check_hresult(dxdevice->GetAdapter(adapter.put()));

        winrt::com_ptr<IDXGIFactory2> factory;
        winrt::check_hresult(adapter->GetParent(__uuidof(factory), factory.put_void()));
        return factory;
    }

    void CreateDeviceSwapChainBitmap(
        winrt::com_ptr<IDXGISwapChain1> const& swapchain,
        winrt::com_ptr<ID2D1DeviceContext> const& target)
    {
        WINRT_ASSERT(swapchain);
        WINRT_ASSERT(target);

        winrt::com_ptr<IDXGISurface> surface;
        winrt::check_hresult(swapchain->GetBuffer(0, __uuidof(surface), surface.put_void()));

        D2D1_BITMAP_PROPERTIES1 const props{ D2D1::BitmapProperties1(
            D2D1_BITMAP_OPTIONS_TARGET | D2D1_BITMAP_OPTIONS_CANNOT_DRAW,
            D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_IGNORE)) };

        winrt::com_ptr<ID2D1Bitmap1> bitmap;

        winrt::check_hresult(target->CreateBitmapFromDxgiSurface(surface.get(),
            props,
            bitmap.put()));

        target->SetTarget(bitmap.get());
    }

    winrt::com_ptr<IDXGISwapChain1> CreateSwapChainForCoreWindow(winrt::com_ptr<ID3D11Device> const& device)
    {
        WINRT_ASSERT(device);

        winrt::com_ptr<IDXGIFactory2> const factory{ GetDxgiFactory(device) };

        DXGI_SWAP_CHAIN_DESC1 props{};
        props.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
        props.SampleDesc.Count = 1;
        props.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
        props.BufferCount = 2;
        props.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL;

        winrt::com_ptr<IDXGISwapChain1> swapChain;

        winrt::check_hresult(factory->CreateSwapChainForCoreWindow(
            device.get(),
            winrt::get_unknown(CoreWindow::GetForCurrentThread()),
            &props,
            nullptr, // all or nothing
            swapChain.put()));

        return swapChain;
    }

    constexpr D2D1_COLOR_F color_white{ 1.0f,  1.0f,  1.0f,  1.0f };
    constexpr D2D1_COLOR_F color_orange{ 0.92f,  0.38f,  0.208f,  1.0f };
}

struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    winrt::com_ptr<ID2D1Factory1> m_factory;
    winrt::com_ptr<ID2D1DeviceContext> m_target;
    winrt::com_ptr<IDXGISwapChain1> m_swapChain;
    winrt::com_ptr<ID2D1SolidColorBrush> m_brush;
    float m_dpi{};

    IFrameworkView CreateView()
    {
        return *this;
    }

    void Initialize(CoreApplicationView const&)
    {
    }

    void Load(hstring const&)
    {
        CoreWindow const window{ CoreWindow::GetForCurrentThread() };

        window.SizeChanged([&](auto&&...)
        {
            if (m_target)
            {
                ResizeSwapChainBitmap();
                Render();
            }
        });

        DisplayInformation const display{ DisplayInformation::GetForCurrentView() };
        m_dpi = display.LogicalDpi();

        display.DpiChanged([&](DisplayInformation const& display, IInspectable const&)
        {
            if (m_target)
            {
                m_dpi = display.LogicalDpi();
                m_target->SetDpi(m_dpi, m_dpi);
                CreateDeviceSizeResources();
                Render();
            }
        });

        m_factory = CreateFactory();
        CreateDeviceIndependentResources();
    }

    void Uninitialize()
    {
    }

    void Run()
    {
        CoreWindow const window{ CoreWindow::GetForCurrentThread() };
        window.Activate();

        Render();
        CoreDispatcher const dispatcher{ window.Dispatcher() };
        dispatcher.ProcessEvents(CoreProcessEventsOption::ProcessUntilQuit);
    }

    void SetWindow(CoreWindow const&) {}

    void Draw()
    {
        m_target->Clear(color_white);

        D2D1_SIZE_F const size{ m_target->GetSize() };
        D2D1_RECT_F const rect{ 100.0f, 100.0f, size.width - 100.0f, size.height - 100.0f };
        m_target->DrawRectangle(rect, m_brush.get(), 100.0f);

        WINRT_TRACE("Draw %.2f x %.2f @ %.2f\n", size.width, size.height, m_dpi);
    }

    void Render()
    {
        if (!m_target)
        {
            winrt::com_ptr<ID3D11Device> const device{ CreateDevice() };
            m_target = CreateRenderTarget(m_factory, device);
            m_swapChain = CreateSwapChainForCoreWindow(device);

            CreateDeviceSwapChainBitmap(m_swapChain, m_target);

            m_target->SetDpi(m_dpi, m_dpi);

            CreateDeviceResources();
            CreateDeviceSizeResources();
        }

        m_target->BeginDraw();
        Draw();
        m_target->EndDraw();

        HRESULT const hr{ m_swapChain->Present(1, 0) };

        if (S_OK != hr && DXGI_STATUS_OCCLUDED != hr)
        {
            ReleaseDevice();
        }
    }

    void ReleaseDevice()
    {
        m_target = nullptr;
        m_swapChain = nullptr;

        ReleaseDeviceResources();
    }

    void ResizeSwapChainBitmap()
    {
        WINRT_ASSERT(m_target);
        WINRT_ASSERT(m_swapChain);

        m_target->SetTarget(nullptr);

        if (S_OK == m_swapChain->ResizeBuffers(0, // all buffers
            0, 0, // client area
            DXGI_FORMAT_UNKNOWN, // preserve format
            0)) // flags
        {
            CreateDeviceSwapChainBitmap(m_swapChain, m_target);
            CreateDeviceSizeResources();
        }
        else
        {
            ReleaseDevice();
        }
    }

    void CreateDeviceIndependentResources()
    {
    }

    void CreateDeviceResources()
    {
        winrt::check_hresult(m_target->CreateSolidColorBrush(
            color_orange,
            D2D1::BrushProperties(0.8f),
            m_brush.put()));
    }

    void CreateDeviceSizeResources()
    {
    }

    void ReleaseDeviceResources()
    {
        m_brush = nullptr;
    }
};

int __stdcall wWinMain(HINSTANCE, HINSTANCE, PWSTR, int)
{
    CoreApplication::Run(App());
}
```

## <a name="working-with-com-types-such-as-bstr-and-variant"></a><span data-ttu-id="f20cc-153">BSTR バリアントなど、COM 型の操作</span><span class="sxs-lookup"><span data-stu-id="f20cc-153">Working with COM types, such as BSTR and VARIANT</span></span>

<span data-ttu-id="f20cc-154">わかるように、C + + WinRT の両方を実装して、COM インターフェイスの呼び出しのサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="f20cc-154">As you can see, C++/WinRT provides support for both implementing and calling COM interfaces.</span></span> <span data-ttu-id="f20cc-155">BSTR バリアントなどの COM 型の使用は常に (適切な Api) と共に、raw 形式でそれらを使用するオプション。</span><span class="sxs-lookup"><span data-stu-id="f20cc-155">For using COM types, such as BSTR and VARIANT, there is always the option to use those in their raw form (together with the appropriate APIs).</span></span> <span data-ttu-id="f20cc-156">または、[アクティブなテンプレート ライブラリ (ATL)](/cpp/atl/active-template-library-atl-concepts)などのフレームワークまたは Visual C コンパイラの[COM のサポート](/cpp/cpp/compiler-com-support)、または独自のラッパーによっても提供されているラッパーを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="f20cc-156">Alternatively, you can use wrappers provided by a framework such as the [Active Template Library (ATL)](/cpp/atl/active-template-library-atl-concepts), or by the Visual C++ compiler's [COM Support](/cpp/cpp/compiler-com-support), or even by your own wrappers.</span></span>

## <a name="important-apis"></a><span data-ttu-id="f20cc-157">重要な API</span><span class="sxs-lookup"><span data-stu-id="f20cc-157">Important APIs</span></span>
* [<span data-ttu-id="f20cc-158">winrt::check_hresult 関数</span><span class="sxs-lookup"><span data-stu-id="f20cc-158">winrt::check_hresult function</span></span>](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)
* [<span data-ttu-id="f20cc-159">winrt::com_ptr 構造体テンプレート</span><span class="sxs-lookup"><span data-stu-id="f20cc-159">winrt::com_ptr struct template</span></span>](/uwp/cpp-ref-for-winrt/com-ptr)
* [<span data-ttu-id="f20cc-160">winrt::Windows::Foundation::IUnknown 構造体</span><span class="sxs-lookup"><span data-stu-id="f20cc-160">winrt::Windows::Foundation::IUnknown struct</span></span>](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)
