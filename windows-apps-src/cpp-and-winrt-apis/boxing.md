---
author: stevewhims
description: スカラー値は、**IInspectable** を想定している関数に渡す前に、参照クラス オブジェクト内にラップする必要があります。 このラッピング プロセスは、値の*ボックス化*と呼ばれます。
title: C++/WinRT を使用した IInspectable へのスカラー値のボックス化とボックス化解除
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、XAML、コントロール、ボックス化、スカラー、値
ms.localizationpriority: medium
ms.openlocfilehash: 7496725d84339de5e318ee6c00aebefb204af751
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5163531"
---
# <a name="boxing-and-unboxing-scalar-values-to-iinspectable-with-cwinrt"></a>C++/WinRT を使用した IInspectable へのスカラー値のボックス化とボックス化解除
 
[**IInspectable インターフェイス**](/windows/desktop/api/inspectable/nn-inspectable-iinspectable) は、Windows ランタイム (WinRT) のすべてのランタイム クラスのルート インターフェイスです。 これは、すべての COM インターフェイスとクラスのルートである [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) や、すべての [共通型システム](https://docs.microsoft.com/dotnet/standard/base-types/common-type-system) クラスのルートである **System.Object** と似た概念です。

つまり、**IInspectable** を想定している関数は、任意のランタイム クラスのインスタンスに渡すことができます。 ただし、数字やテキスト値などのスカラー値を、またはそのような関数へ、直接渡すことはできません。 代わりに、スカラー値を参照クラス オブジェクト内にラップする必要があります。 このラッピング プロセスは、値の*ボックス化*と呼ばれます。

[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)スカラー値を受け取り、 **IInspectable**をボックス化された値を返します[**winrt::box_value**](/uwp/cpp-ref-for-winrt/box-value)関数を提供します。 **IInspectable** をボックス化解除してスカラー値に戻すために、[**winrt::unbox_value**](/uwp/cpp-ref-for-winrt/unbox-value) および [**winrt::unbox_value_or**](/uwp/cpp-ref-for-winrt/unbox-value-or) 関数があります。

## <a name="examples-of-boxing-a-value"></a>値をボックス化する例
[**LaunchActivatedEventArgs::Arguments**](/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.Arguments) アクセサー関数は、スカラー値である [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を返します。 その **hstring** 値をボックス化し、次のように **IInspectable** を想定している関数に渡します。

```cppwinrt
void App::OnLaunched(LaunchActivatedEventArgs const& e)
{
    ...
    rootFrame.Navigate(winrt::xaml_typename<BlankApp1::MainPage>(), winrt::box_value(e.Arguments()));
    ...
}
```

XAML [**Button**](/uwp/api/windows.ui.xaml.controls.button) のコンテンツ プロパティを設定するには、[**Button::Content**](/uwp/api/windows.ui.xaml.controls.contentcontrol.content?) ミューテーター関数を呼び出します。 コンテンツのプロパティを文字列値に設定するには、このコードを使用できます。

```cppwinrt
Button().Content(winrt::box_value(L"Clicked"));
```

まず、[**hstring**](/uwp/cpp-ref-for-winrt/hstring) 変換コンストラクターが文字列リテラルを **hstring** に変換します。 次に **hstring** を受け取る **winrt::box_value** のオーバーロードが呼び出されます。

## <a name="examples-of-unboxing-an-iinspectable"></a>IInspectable をボックス化解除する例
**IInspectable** を想定する独自の関数では、[**winrt::unbox_value**](/uwp/cpp-ref-for-winrt/unbox-value) を使用してボックス化解除することができます。また [**winrt::unbox_value_or**](/uwp/cpp-ref-for-winrt/unbox-value-or) を使用して既定値でボックス化解除することができます。

```cppwinrt
void Unbox(winrt::Windows::Foundation::IInspectable const& object)
{
    hstring hstringValue = unbox_value<hstring>(object); // Throws if object is not a boxed string.
    hstringValue = unbox_value_or<hstring>(object, L"Default"); // Returns L"Default" if object is not a boxed string.
    float floatValue = unbox_value_or<float>(object, 0.f); // Returns 0.0 if object is not a boxed float.
}
```

## <a name="determine-the-type-of-a-boxed-value"></a>ボックス化された値の型の判別
ボックス化された値を受け取って、その値に含まれる型が不明な場合は (型はボックス化解除するために知っておく必要があります)、その [**IPropertyValue**](/uwp/api/windows.foundation.ipropertyvalue) でボックス化された値を照会し、そこで **Type** を呼び出すことができます。 次にコード例を示します。

```cppwinrt
float pi = 3.14f;
auto piInspectable = winrt::box_value(pi);
auto piPropertyValue = piInspectable.as<winrt::Windows::Foundation::IPropertyValue>();
WINRT_ASSERT(piPropertyValue.Type() == winrt::Windows::Foundation::PropertyType::Single);
```

## <a name="important-apis"></a>重要な API
* [IInspectable インターフェイス](/windows/desktop/api/inspectable/nn-inspectable-iinspectable)
* [winrt::box_value 関数テンプレート](/uwp/cpp-ref-for-winrt/box-value)
* [winrt::hstring 構造体](/uwp/cpp-ref-for-winrt/hstring)
* [winrt::unbox_value 関数テンプレート](/uwp/cpp-ref-for-winrt/unbox-value)
* [winrt::unbox_value_or 関数テンプレート](/uwp/cpp-ref-for-winrt/unbox-value-or)
