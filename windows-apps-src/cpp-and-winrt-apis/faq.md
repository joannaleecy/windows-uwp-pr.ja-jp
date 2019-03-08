---
description: C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。
title: C++/WinRT についてよく寄せられる質問
ms.date: 10/26/2018
ms.topic: article
keywords: wwindows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 頻繁, 質問, 質問, faq
ms.localizationpriority: medium
ms.openlocfilehash: 9dd051ffe3af9e18370666f5c6c772b7f188e54a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635577"
---
# <a name="frequently-asked-questions-about-cwinrt"></a>C++/WinRT についてよく寄せられる質問
作成と使用の Windows ランタイム Api を利用する可能性がある質問の回答を[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。

> [!NOTE]
> 質問の内容が、表示されたエラー メッセージに関するものである場合は、「[C++/WinRT に関する問題のトラブルシューティング](troubleshooting.md)」のトピックも参照してください。

## <a name="how-do-i-retarget-my-cwinrt-project-to-a-later-version-of-the-windows-sdk"></a>方法は再ターゲット、C +/cli WinRT プロジェクトは、以降のバージョンの Windows SDK をでしょうか。
参照してください[方法の再ターゲットすると、C +/cli WinRT プロジェクトは、以降のバージョンの Windows SDK を](news.md#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk)します。

## <a name="why-wont-my-new-project-compile-im-using-visual-studio-2017-version-1580-or-higher-and-sdk-version-17134"></a>新しいプロジェクトがコンパイルされません。 Visual Studio 2017 を使用している (15.8.0 バージョンまたはそれ以降)、および SDK version 17134
Visual Studio 2017 を使用している場合 (バージョン 15.8.0 またはそれ以降)、およびターゲットの Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した C +/cli WinRT プロジェクトがエラーでコンパイルに失敗する可能性があります"*エラー C3861: 'from_abi'。識別子が見つかりません*"、発信元がその他のエラーの*base.h*します。 いずれかのターゲットに以降 (詳細について準拠) は、ソリューションのバージョンの Windows SDK、またはプロジェクトのプロパティを設定**C/C++** > **言語** > **準拠モード。いいえ**(また場合、 **/permissive -** プロジェクト プロパティに表示されます**C/C++** > **コマンド ライン****追加のオプション**から削除します)。

## <a name="how-do-i-resolve-the-build-error-the-cwinrt-vsix-no-longer-provides-project-build-support--please-add-a-project-reference-to-the-microsoftwindowscppwinrt-nuget-package"></a>ビルド エラーを解決する方法"c++/cli WinRT VSIX プロジェクトのビルドのサポートは提供されなくなりました。  追加してください、Microsoft.Windows.CppWinRT Nuget パッケージへの参照をプロジェクト"でしょうか。
インストール、 **Microsoft.Windows.CppWinRT**をプロジェクトに NuGet パッケージ。 詳細については、次を参照してください。 [VSIX 拡張機能の以前のバージョン](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension)します。

## <a name="what-are-the-requirements-for-the-cwinrt-visual-studio-extension-vsix"></a>C++ の要件は何/cli WinRT Visual Studio Extension (VSIX) でしょうか。
バージョン 1.0.190128.4 VSIX 拡張機能と後で、次を参照してください。 [Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。 その他のバージョンでは、次を参照してください。 [VSIX 拡張機能の以前のバージョン](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension)します。

## <a name="whats-a-runtime-class"></a>*ランタイム クラス*とは
ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。 ただし、ランタイム クラスは、それを実装するコンパイル ユニット内でも使用できます。 インターフェイス定義言語 (IDL) でランタイム クラスを宣言し、C++/WinRT を使用した標準の C++ で実装することができます。

## <a name="what-do-the-projected-type-and-the-implementation-type-mean"></a>*プロジェクションされる型*と*実装型*とは
Windows ランタイム クラス (ランタイム クラス) を*使用*する場合のみ、*プロジェクションされる型*を排他的に処理します。 C++/WinRT は*言語のプロジェクション*であるため、プロジェクションされる型は、C++/WinRT を使用した C++ に*プロジェクション*される Windows ランタイムの画面に表示されます。 詳細については、次を参照してください。 [C + を使用して Api を消費する/cli WinRT](consume-apis.md)します。

*実装型*にはランタイム クラスの実装が含まれるため、ランタイム クラスを実装するプロジェクトでのみ利用可能です。 ランタイム クラス (Windows ランタイム コンポーネント プロジェクト、つまり XAML UI を使用するプロジェクト) を実装するプロジェクトで作業している場合、ランタイム クラスの実装型と C++/WinRT にプロジェクションされたランタイム クラスを表すプロジェクションされる型との違いを習熟することが重要です。 詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。

## <a name="do-i-need-to-declare-a-constructor-in-my-runtime-classs-idl"></a>使用するランタイム クラスの IDL でコンストラクターを宣言する必要性
ランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合のみ IDL のコンストラクターを宣言する際の目的と影響の詳細については、「[ランタイム クラス コンストラクター](author-apis.md#runtime-class-constructors)」を参照してください。

## <a name="why-is-the-linker-giving-me-a-lnk2019-unresolved-external-symbol-error"></a>理由は、リンカーを与えてくれた、"LNK2019:未解決の外部シンボル"エラーでしょうか。
未解決のシンボルが (**winrt** 名前空間内の) C++/WinRT プロジェクションの Windows 名前空間ヘッダーからの API である場合、その API は含まれているヘッダー内で事前宣言されていますが、その定義は含まれていないヘッダー内にあります。 API の名前空間で付けられた名前のヘッダーを含めてから、リビルドしてください。 詳細については、「[C++/WinRT プロジェクション ヘッダー](consume-apis.md#cwinrt-projection-headers)」を参照してください。

未解決のシンボルなど、Windows ランタイムの free 関数は、かどうか[RoInitialize](https://msdn.microsoft.com/library/br224650)を明示的にリンクする必要があります、 [WindowsApp.lib](/uwp/win32-and-com/win32-apis)プロジェクトでの包括的なライブラリ。 C++/WinRT プロジェクションは、これらの一部の自由 (非メンバー) 関数とエントリ ポイントに依存します。 アプリケーションでいずれかの [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) プロジェクト テンプレートを使用する場合は、`WindowsApp.lib` が自動的にリンクされます。 それ以外の場合、プロジェクトのリンク設定を使用して含めるか、またはソース コードでそれを行うことができます。

```cppwinrt
#pragma comment(lib, "windowsapp")
```

リンクすることによって、リンカー エラーを解決することを強く**WindowsApp.lib** 、代替のスタティック リンク ライブラリではなくそれ以外の場合、アプリケーションに渡さない、 [Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)テストが Visual Studio では、Microsoft Store で送信 (したがってできませんが、Microsoft Store に正常に取り込まれたデータに、アプリケーションの意味) を検証するために使用します。

## <a name="should-i-implement-windowsfoundationiclosableuwpapiwindowsfoundationiclosable-and-if-so-how"></a>[  **Windows::Foundation::IClosable**](/uwp/api/windows.foundation.iclosable) を実装するかどうかとその方法
自身のデストラクターのリソースを解放するランタイム クラスを使用し、そのランタイム クラスが実装するコンパイル ユニット (Windows ランタイム クライアント アプリで一般的に使用するための Windows ランタイム コンポーネント) 以外で使用されるように設計されている場合、確定終了処理が不足する言語でランタイム クラスの使用をサポートするために、**IClosable** も実装することをお勧めします。 デストラクター、[**IClosable::Close**](/uwp/api/windows.foundation.iclosable.close)、または両方が呼び出されたときにリソースが解放されるようにしてください。 **IClosable::Close** は必要に応じて呼び出すことができます。

## <a name="do-i-need-to-call-iclosablecloseuwpapiwindowsfoundationiclosableclose-on-runtime-classes-that-i-consume"></a>使用するランタイム クラスで [**IClosable::Close**](/uwp/api/windows.foundation.iclosable.close) を読み出す必要性
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

Visual Studio は、マイクロソフトがサポートし、C++/WinRT 用に推奨する開発ツールです。 参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

## <a name="why-doesnt-the-generated-implementation-function-for-a-read-only-property-have-the-const-qualifier"></a>読み取り専用プロパティの実装が生成された関数がない理由、`const`修飾子ですか?
読み取り専用プロパティを宣言するときに[MIDL 3.0](/uwp/midl-3/)、想像、`cppwinrt.exe`実装の機能を生成するツールが`const`-修飾 (const 関数の処理、*この*定数としてのポインター)。

確かに可能な限り、定数の使用をお勧めは`cppwinrt.exe`ツール自体の実装について関数が考えも const とする可能性がある理由は行われません。 この例のように、const、実装する関数のいずれかのことを選択することができます。

```cppwinrt
struct MyStringable : winrt::implements<MyStringable, winrt::Windows::Foundation::IStringable>
{
    winrt::hstring ToString() const
    {
        return L"MyStringable";
    }
};
```

削除することができます`const`で修飾子**ToString**実装でいくつかのオブジェクト状態を変更する必要がありますを決定する必要があります。 メンバーの両方ではなく関数 const または非定数のいずれか。 つまり、しないオーバー ロードの実装の機能で`const`します。

別に、実装関数では、const が配置他別に画像が Windows ランタイム関数の射影では。 このコードを検討してください。

```cppwinrt
int main()
{
    winrt::Windows::Foundation::IStringable s{ winrt::make<MyStringable>() };
    auto result{ s.ToString() };
}
```

呼び出しに**ToString** 、上、**宣言へ移動**Visual Studio でのコマンドを示します Windows ランタイムの投影**IStringable::ToString** C +/cliWinRT は、次のように検索します。

```
winrt::hstring ToString() const;
```

投影の関数は、それらの実装を修飾するために選択する方法に関係なく const です。 バック グラウンドでは、プロジェクションは、アプリケーション バイナリ インターフェイス (ABI) COM インターフェイス ポインターからの呼び出しには、その場合を呼び出します。 唯一の状態、射影された**ToString**対話は COM インターフェイス ポインター。 が確実に必要としないので、関数が const、そのポインターを変更します。 これにより、確実にについて何も変更されません、 **IStringable**参照を通じて、呼び出し先を呼び出すことができるようになります**ToString** へのconst参照でも**IStringable**します。

理解これらの例の`const`C + の実装の詳細は/cli WinRT プロジェクションと実装には、特典のコードの検疫が構成します。 ようなものがない`const`COM も (メンバー関数) 用の Windows ランタイム ABI にします。

## <a name="do-you-have-any-recommendations-for-decreasing-the-code-size-for-cwinrt-binaries"></a>C++ コードのサイズを減らすための推奨事項がある/cli WinRT バイナリでしょうか。
Windows ランタイム オブジェクトを使用する場合は、バイナリ コードを生成するために必要なは、それによって、アプリケーションに悪影響を及ぼすことがあるできますので、次に示すコーディング パターンを避ける必要があります。

```cppwinrt
anobject.b().c().d();
anobject.b().c().e();
anobject.b().c().f();
```

Windows ランタイムの世界も、コンパイラの値をキャッシュできる`c()`または間接参照を通じて呼び出される各メソッドのインターフェイス ('. ')。 介入した場合を除き、複数の仮想呼び出しおよび参照カウントのオーバーヘッドが発生します。 上記のパターンに厳密に必要な 2 回の多くのコードを生成簡単でした。 代わりに、できる任意の場所の下に示すパターンを使用します。 少量のコードを生成し、実行時のパフォーマンスを向上させることができますも大幅にします。

```cppwinrt
auto a{ anobject.b().c() };
a.d();
a.e();
a.f();
```

上記の推奨されるパターンは、C + にだけでなく適用/cli WinRT がすべての Windows ランタイム言語プロジェクションにします。

## <a name="how-do-i-turn-a-string-into-a-typemdashfor-navigation-for-example"></a>型に文字列にどのように&mdash;例については、ナビゲーションのでしょうか。
最後に、[ナビゲーションの表示のコード例](/windows/uwp/design/controls-and-patterns/navigationview#code-example)(のほとんどの場合はC#) は c++/cli これを行う方法を示す、WinRT コード スニペット。

> [!NOTE]
> このトピックでは、質問に答えしていないかどうかを参照してくださいヘルプを見つけることがあります、[開発者コミュニティの Visual Studio C](https://developercommunity.visualstudio.com/spaces/62/index.html)、またはを使用して、 [ `c++-winrt` Stack Overflow でタグ付け](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt)します。
