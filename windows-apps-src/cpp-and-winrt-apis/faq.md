---
author: stevewhims
description: C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。
title: C++/WinRT についてよく寄せられる質問
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: wwindows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 頻繁, 質問, 質問, faq
ms.localizationpriority: medium
ms.openlocfilehash: e00f387c3dd78353158d93d3b4749345936396f5
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4755146"
---
# <a name="frequently-asked-questions-about-cwinrt"></a>C++/WinRT についてよく寄せられる質問
可能性はの作成と Windows ランタイム Api の使用に関する質問への回答[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。

> [!NOTE]
> 質問の内容が、表示されたエラー メッセージに関するものである場合は、「[C++/WinRT に関する問題のトラブルシューティング](troubleshooting.md)」のトピックも参照してください。

## <a name="how-do-i-retarget-my-cwinrt-project-to-a-later-version-of-the-windows-sdk"></a>方法は I 対象 my C + + 以降のバージョンの Windows SDK に WinRT プロジェクトかどうか。

参照してください[c++ ターゲットを変更する方法/WinRT プロジェクトを Windows SDK のそれ以降のバージョンを](news.md#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk)します。

## <a name="why-wont-my-new-project-compile-im-using-visual-studio-2017-version-1580-or-higher-and-sdk-version-17134"></a>新しいプロジェクトがコンパイルされません。 Visual Studio 2017 を使用している (バージョン 15.8.0 以上)、および SDK バージョン 17134

Visual Studio 2017 を使用している場合 (バージョン 15.8.0 以上) をターゲットとする Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した、C++/WinRT プロジェクトをコンパイル エラーで失敗する可能性が"*エラー C3861: 'from_abi': 識別子されません見つかった*"、および*base.h*でその他のエラー。 解決策は、いずれかのターゲット以降 (詳しく準拠) のバージョンの Windows SDK、またはプロジェクトのプロパティを設定する**C/C++** > **言語** > **Conformance mode: いいえ**(も場合、 **/制限解除-** **プロジェクトのプロパティに表示されますC/C++** > **言語** > **コマンド ライン**[**その他のオプション**を削除します)。

## <a name="what-are-the-requirements-for-the-cwinrt-visual-studio-extension-vsixhttpsakamscppwinrtvsix"></a> [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) の要件
[VSIX](https://aka.ms/cppwinrt/vsix) の最小要件は、Windows SDK ターゲット バージョン 10.0.17134.0 (Windows 10、バージョン 1803) です。 Visual Studio 2017 (バージョン 15.6 以上、15.7 以上を推奨) も必要になります 。 `.vcxproj` ファイルの `<PropertyGroup Label="Globals">` に `<CppWinRTEnabled>true</CppWinRTEnabled>` があるかどうかによって、VSIX を使用するプロジェクトを特定できます。 詳しくは、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」をご覧ください。

## <a name="whats-a-runtime-class"></a>*ランタイム クラス*とは
ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。 ただし、ランタイム クラスは、それを実装するコンパイル ユニット内でも使用できます。 インターフェイス定義言語 (IDL) でランタイム クラスを宣言し、C++/WinRT を使用した標準の C++ で実装することができます。

## <a name="what-do-the-projected-type-and-the-implementation-type-mean"></a>*プロジェクションされる型*と*実装型*とは
Windows ランタイム クラス (ランタイム クラス) を*使用*する場合のみ、*プロジェクションされる型*を排他的に処理します。 C++/WinRT は*言語のプロジェクション*であるため、プロジェクションされる型は、C++/WinRT を使用した C++ に*プロジェクション*される Windows ランタイムの画面に表示されます。 詳しくは、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。

*実装型*にはランタイム クラスの実装が含まれるため、ランタイム クラスを実装するプロジェクトでのみ利用可能です。 ランタイム クラス (Windows ランタイム コンポーネント プロジェクト、つまり XAML UI を使用するプロジェクト) を実装するプロジェクトで作業している場合、ランタイム クラスの実装型と C++/WinRT にプロジェクションされたランタイム クラスを表すプロジェクションされる型との違いを習熟することが重要です。 詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。

## <a name="do-i-need-to-declare-a-constructor-in-my-runtime-classs-idl"></a>使用するランタイム クラスの IDL でコンストラクターを宣言する必要性
ランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合のみ IDL のコンストラクターを宣言する際の目的と影響の詳細については、「[ランタイム クラス コンストラクター](author-apis.md#runtime-class-constructors)」を参照してください。

## <a name="why-is-the-linker-giving-me-a-lnk2019-unresolved-external-symbol-error"></a>リンカーで "LNK2019: 外部シンボルは未解決です" というエラーが表示されるのはなぜですか。
未解決のシンボルが (**winrt** 名前空間内の) C++/WinRT プロジェクションの Windows 名前空間ヘッダーからの API である場合、その API は含まれているヘッダー内で事前宣言されていますが、その定義は含まれていないヘッダー内にあります。 API の名前空間で付けられた名前のヘッダーを含めてから、リビルドしてください。 詳細については、「[C++/WinRT プロジェクション ヘッダー](consume-apis.md#cwinrt-projection-headers)」を参照してください。

未解決のシンボルが[RoInitialize](https://msdn.microsoft.com/library/br224650)などの Windows ランタイム自由関数である場合があります、プロジェクトの[WindowsApp.lib](/uwp/win32-and-com/win32-apis)包括的なライブラリを明示的にリンクする必要があります。 C++/WinRT プロジェクションは、これらの一部の自由 (非メンバー) 関数とエントリ ポイントに依存します。 アプリケーションでいずれかの [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) プロジェクト テンプレートを使用する場合は、`WindowsApp.lib` が自動的にリンクされます。 それ以外の場合、プロジェクトのリンク設定を使用して含めるか、またはソース コードでそれを行うことができます。

```cppwinrt
#pragma comment(lib, "windowsapp")
```

**WindowsApp.lib**をリンクできるリンカーのエラーを解決することお勧めします。 ただし、Visual Studio と Microsoft Store によってしたがってことはできなくアプリケーションに正常にする (つまりの提出を検証するために使用する[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)のテストに合格するようにアプリケーションを必要としない場合取り込まれる、Microsoft Store)、その代わりに代替のスタティック リンク ライブラリをリンクすることができます。 たとえば、リンカーのエラーは、 **CoIncrementMTAUsage** (または**WINRT_CoIncrementMTAUsage**) を参照している場合、解決でく (たとえば、 **WindowsApp.lib**のバージョンがない場合、どうしても必要な場合は、Ole32.lib をリンクして関数をエクスポート)。

## <a name="should-i-implement-windowsfoundationiclosableuwpapiwindowsfoundationiclosable-and-if-so-how"></a>[**Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) を実装するかどうかとその方法
自身のデストラクターのリソースを解放するランタイム クラスを使用し、そのランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合、確定終了処理が不足する言語でランタイム クラスの使用をサポートするために、**IClosable** も実装することをお勧めします。 デストラクター、[**IClosable::Close**](/uwp/api/windows.foundation.iclosable.Close)、または両方が呼び出されたときにリソースが解放されるようにしてください。 **IClosable::Close** は必要に応じて呼び出すことができます。

## <a name="do-i-need-to-call-iclosablecloseuwpapiwindowsfoundationiclosablewindowsfoundationiclosableclose-on-runtime-classes-that-i-consume"></a>使用するランタイム クラスで [**IClosable::Close**](/uwp/api/windows.foundation.iclosable#Windows_Foundation_IClosable_Close_) を読み出す必要性
**IClosable** は確定終了処理が不足する言語をサポートします。 そのため、シャットダウン状態やデッドロック状態といった非常にまれな場合を除いて、C++/WinRT から **IClosable::Close** を呼び出さないでください。 たとえば、**Windows.UI.Composition** を使用していて、設定順序でオブジェクトを破棄する場合、その代わりとして、C++/WinRT ラッパーを破棄することができます。

## <a name="can-i-use-llvmclang-to-compile-with-cwinrt"></a>LLVM/Clang を使用して C++/WinRT でコンパイルすることはできますか。
C++/WinRT の LLVM および Clang ツール チェーンはサポートしていませんが、C++/WinRT の標準への準拠を検証するためにそれを内部で使用します。 たとえば、マイクロソフトが内部で行っている内容をエミュレートする場合は、次に説明するような実験を試してみることができます。

[LLVM ダウンロード ページ](https://releases.llvm.org/download.html)に移動し、**[Download LLVM 6.0.0] (LLVM 6.0.0 のダウンロード)** > **[Pre-Built Binaries] (事前ビルドされたバイナリ)** を探し、**[Clang for Windows (64-bit)] (Windows の Clang (64 ビット))** をダウンロードします。 インストール中に、コマンド プロンプトから起動できるように、PATH システム変数に LLVM を追加することを選択します。 この実験の目的上、"Failed to find MSBuild toolsets directory (MSBuild ツールセット ディレクトリの検索に失敗しました)" または "MSVC integration install failed (MSVC 統合インストールに失敗しました)" というエラーが表示された場合には無視できます。 LLVM/Clang を起動するさまざまな方法があります。次の例は、1 つの方法のみを示しています。

```
C:\ExperimentWithLLVMClang>type main.cpp
// main.cpp
#pragma comment(lib, "windowsapp")
#pragma comment(lib, "ole32")

#include <winrt/Windows.Foundation.h>
#include <stdio.h>
#include <iostream>

using namespace winrt;

int main()
{
    winrt::init_apartment();
    Windows::Foundation::Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    std::wcout << rssFeedUri.Domain().c_str() << std::endl;
}

C:\ExperimentWithLLVMClang>clang-cl main.cpp /EHsc /I ..\.. -Xclang -std=c++17 -Xclang -Wno-delete-non-virtual-dtor -o app.exe

C:\ExperimentWithLLVMClang>app
windows.com
```

C++/WinRT では C++17 標準の機能を使用するため、そのサポートを受けるために必要なコンパイラ フラグを使用する必要があります。そのようなフラグはコンパイラによって異なります。

Visual Studio は、マイクロソフトがサポートし、C++/WinRT 用に推奨する開発ツールです。 「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

## <a name="why-doesnt-the-generated-implementation-function-for-a-read-only-property-have-the-const-qualifier"></a>読み取り専用プロパティに対して生成された関数がない理由、`const`修飾子かどうか。

期待どおり[MIDL 3.0](/uwp/midl-3/)で読み取り専用プロパティを宣言するとき、`cppwinrt.exe`されるツールの実装の機能を生成する`const`-(const 関数は、定数として*この*ポインターを扱う) 修飾します。

可能であれば、定数を使用してを確実にお勧めが、`cppwinrt.exe`のどの実装について関数もあります const とする可能性がある理由ツール自体は行われません。 この例のように、const の実装関数のいずれかに選択できます。

```cppwinrt
struct MyStringable : winrt::implements<MyStringable, winrt::Windows::Foundation::IStringable>
{
    winrt::hstring ToString() const
    {
        return L"MyStringable";
    }
};
```

削除することができます`const` **ToString**の修飾子すべき実装ではいくつかオブジェクトの状態を変更する必要があることを決定します。 各メンバーの両方ではなく関数 const または非定数のいずれか。 つまり、しないオーバー ロードの実装の機能で`const`します。

Const 場所に配置他別、実装関数を除くが使えるように、画像が、Windows ランタイム関数のプロジェクション。 このコードを検討してください。

```cppwinrt
int main()
{
    winrt::Windows::Foundation::IStringable s{ winrt::make<MyStringable>() };
    auto result{ s.ToString() };
}
```

**ToString**上記を呼び出し、Visual Studio で**宣言へ移動**コマンド示されている C++ への Windows ランタイム**istringable::tostring**のプロジェクション/WinRT は次のようです。

```
winrt::hstring ToString() const;
```

プロジェクションの関数は、資格を得ることの実装を選択する方法に関係なく const。 バック グラウンドでは、投影は、アプリケーション バイナリ インターフェイス (ABI)、COM インターフェイス ポインターを使用して、呼び出しをどの金額を呼び出します。 投影された**ToString**と対話する唯一の状態は COM インターフェイス ポインターです。その確実に不要になったため、関数は const そのポインターを変更します。 これにより、 **IStringable**を参照する保証を呼び出している**IStringable**の参照について何も変わりません、これにより、const しても**ToString**を呼び出すことができます。

理解これらの例の`const`、C++ の実装の詳細を/WinRT プロジェクションおよび実装します。やすくするコードに対する予防措置を構成しています。 このようなものはありません`const`COM も (メンバー関数) 用の Windows ランタイム ABI のします。

## <a name="do-you-have-any-recommendations-for-decreasing-the-code-size-for-cwinrt-binaries"></a>C++ コードのサイズを小さくに関する推奨事項がある/WinRT バイナリかどうか。

Windows ランタイム オブジェクトを使用する際は、以上バイナリのコードを生成するために必要なを発生させることによって、アプリケーションに悪影響を与えることがあるできるために、次に示すコーディング パターンを回避する必要があります。

```cppwinrt
anobject.b().c().d();
anobject.b().c().e();
anobject.b().c().f();
```

Windows ランタイムの世界でコンパイラことができないの値をキャッシュする`c()`または間接参照から呼び出されるメソッドでは各インターフェイス ('.")。 介入する場合を除き、複数の仮想呼び出しと参照カウント オーバーヘッドの結果します。 上記のパターンでは、として厳密に必要な 2 回の多くのコードを簡単に作成可能性があります。 代わりに、以下を参照することができる場合は必ずパターンを好みます。 大幅に減少コードを生成し、実行時のパフォーマンスも大幅に向上させることができます。

```cppwinrt
auto a{ anobject.b().c() };
a.d();
a.e();
a.f();
```

上記の推奨パターンの対象だけでなく、C++/WinRT が、すべての Windows ランタイム言語プロジェクションにします。

> [!NOTE]
> このトピックでは、質問に回答していないかどうかは、 [Visual Studio C 開発者コミュニティ](https://developercommunity.visualstudio.com/spaces/62/index.html)にアクセスするかを使用してヘルプ情報を見つけることがあります、 [ `c++-winrt` Stack Overflow でタグ](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt)します。
