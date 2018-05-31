---
author: stevewhims
description: C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。
title: C++/WinRT についてよく寄せられる質問
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、頻繁、質問、質問、faq
ms.localizationpriority: medium
ms.openlocfilehash: aad5c5ed2123af39ebb6aff0c9098586ce958196
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832037"
---
# <a name="frequently-asked-questions-about-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) についてよく寄せられる質問
> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。

## <a name="what-are-the-requirements-for-the-cwinrt-visual-studio-extension-vsixhttpsakamscppwinrtvsix"></a>C++/WinRT [Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) の要件
[VSIX](https://aka.ms/cppwinrt/vsix) の最小要件は、Windows SDK ターゲット バージョン 10.0.17134.0 (Windows 10、バージョン 1803) です。 また、Visual Studio 2017 バージョン 15.6 以降も必要です。 `.vcxproj` ファイルの `<PropertyGroup Label="Globals">` に `<CppWinRTEnabled>true</CppWinRTEnabled>` があるかどうかによって、VSIX を使用するプロジェクトを特定できます。 詳しくは、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」をご覧ください。

## <a name="whats-a-runtime-class"></a>*ランタイム クラス*とは
ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。 ただし、ランタイム クラスは、それを実装するコンパイル ユニット内でも使用できます。 インターフェイス定義言語 (IDL) でランタイム クラスを宣言し、C++/WinRT を使用した標準の C++ で実装することができます。

## <a name="what-do-the-projected-type-and-the-implementation-type-mean"></a>*プロジェクションされる型*と*実装型*とは
Windows ランタイム クラス (ランタイム クラス) を*使用*する場合のみ、*プロジェクションされる型*を排他的に処理します。 C++/WinRT は*言語のプロジェクション*であるため、プロジェクションされる型は、C++/WinRT を使用した C++ に*プロジェクション*される Windows ランタイムの画面に表示されます。 詳しくは、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。

*実装型*にはランタイム クラスの実装が含まれるため、ランタイム クラスを実装するプロジェクトでのみ利用可能です。 ランタイム クラス (Windows ランタイム コンポーネント プロジェクト、つまり XAML UI を使用するプロジェクト) を実装するプロジェクトで作業している場合、ランタイム クラスの実装型と C++/WinRT にプロジェクションされたランタイム クラスを表すプロジェクションされる型との違いを習熟することが重要です。 詳しくは、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。

## <a name="should-i-implement-windowsfoundationiclosableuwpapiwindowsfoundationiclosable-and-if-so-how"></a>[**Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) を実装するかどうかとその方法
自身のデストラクターのリソースを解放するランタイム クラスを使用し、そのランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合、確定終了処理が不足する言語でランタイム クラスの使用をサポートするために、**IClosable** も実装することをお勧めします。 デストラクター、[**IClosable::Close**](/uwp/api/windows.foundation.iclosable.Close)、または両方が呼び出されたときにリソースが解放されるようにしてください。 **IClosable::Close** は必要に応じて呼び出すことができます。

## <a name="do-i-need-to-call-iclosablecloseuwpapiwindowsfoundationiclosablewindowsfoundationiclosableclose-on-runtime-classes-that-i-consume"></a>使用するランタイム クラスで [**IClosable::Close**](/uwp/api/windows.foundation.iclosable#Windows_Foundation_IClosable_Close_) を読み出す必要性
**IClosable** は確定終了処理が不足する言語をサポートします。 そのため、シャットダウン状態やデッドロック状態といった非常にまれな場合を除いて、C++/WinRT から **IClosable::Close** を呼び出さないでください。 たとえば、**Windows.UI.Composition** を使用していて、設定順序でオブジェクトを破棄する場合、その代わりとして、C++/WinRT ラッパーを破棄することができます。

## <a name="do-i-need-to-declare-a-constructor-in-my-runtime-classs-idl"></a>使用するランタイム クラスの IDL でコンストラクターを宣言する必要性
ランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合のみ IDL のコンストラクターを宣言する際の目的と影響について詳しくは、「[ランタイム クラス コンストラクター](author-apis.md#runtime-class-constructors)」をご覧ください。