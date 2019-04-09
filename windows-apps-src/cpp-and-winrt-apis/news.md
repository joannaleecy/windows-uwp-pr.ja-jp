---
description: C++/WinRT に関するニュースと変更内容です。
title: 新しい c++/cli WinRT
ms.date: 04/02/2019
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、プロジェクション、ニュース、ものの新しい
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 8ee10450a7a346c1ae032240aaecc65e7f87822d
ms.sourcegitcommit: 940645c705865ba9635ccae2da9d917420faf608
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/02/2019
ms.locfileid: "58812611"
---
# <a name="whats-new-in-cwinrt"></a>新しい c++/cli WinRT

## <a name="news-and-changes-in-cwinrt-20"></a>ニュース、および変更でC++WinRT 2.0

詳細について、 [ C++WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)、および、`cppwinrt.exe`ツール&mdash;する方法についても取得してインストールする&mdash;を参照してください[Visual Studio のサポートC++/WinRT、XAML、VSIX 拡張機能、および NuGet パッケージ](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

### <a name="changes-to-the-cwinrt-visual-studio-extension-vsix-for-version-20"></a>変更、 C++WinRT Visual Studio Extension (VSIX) バージョン 2.0

- ビジュアライザーのデバッグを Visual Studio 2019; サポートします。Visual Studio 2017 をサポートするために続行します。
- 多くのバグ修正が加えられました。

### <a name="changes-to-the-microsoftwindowscppwinrt-nuget-package-for-version-20"></a>バージョン 2.0 の Microsoft.Windows.CppWinRT NuGet パッケージへの変更

- `cppwinrt.exe` Microsoft.Windows.CppWinRT NuGet パッケージでツールが含まれるようになりましたし、ツールは、必要に応じてプロジェクトごとにトラステッド プラットフォーム プロジェクション ヘッダーを生成します。 その結果、 `cppwinrt.exe` (ただし、引き続き、ツールは、互換性の理由から、SDK が付属しています)、このツールは、不要になった Windows sdk によって異なります。
- `cppwinrt.exe` これで各プラットフォーム/構成固有中間フォルダー ($IntDir) 並行ビルドを有効にするプロジェクション ヘッダーが生成されます。
- C++/WinRT ビルドのサポート (プロパティ/ターゲット) が完全に記述されました、プロジェクト ファイルを手動でカスタマイズする場合。 参照してください[Microsoft.Windows.CppWinRT NuGet パッケージ](https://github.com/Microsoft/xlang/tree/user/sjones/cppwinrt_nuget/src/package/nuget)します。
- 多くのバグ修正が加えられました。

### <a name="changes-to-cwinrt-for-version-20"></a>変更C++/WinRT バージョン 2.0

#### <a name="open-source"></a>オープン ソース

`cppwinrt.exe`ツールは Windows ランタイム メタデータ (`.winmd`) ファイルを開き、そこからヘッダー ファイル ベースの標準が生成されますC++ライブラリを*プロジェクト*メタデータで説明する Api。 そうすることから、それらの Api を使用することができます、 C++/WinRT コード。

このツールは、完全オープン ソース プロジェクト、GitHub で入手できるようになりました。 参照してください[Microsoft\/xlang](https://github.com/Microsoft/xlang)をクリック**src** > **ツール** > **cppwinrt**します。

#### <a name="xlang-libraries"></a>xlang ライブラリ

(Windows ランタイムで使用される ECMA 335 メタデータ形式を解析) を完全に移植のヘッダーのみのライブラリは、すべての Windows ランタイムおよびツールの今後 xlang の基礎を形成します。 またを書き直して特に、`cppwinrt.exe`ツール地表から xlang ライブラリを使用します。 これにより、長期にわたる、いくつかの問題を解決、メタデータのより正確なクエリ、 C++/WinRT 言語プロジェクションです。

#### <a name="fewer-dependencies"></a>依存関係

により、xlang メタデータ リーダー、`cppwinrt.exe`ツール自体は少ない依存しています。 これによりより柔軟なより多くのシナリオで使用できるのと同様&mdash;特にで制約付きの環境を構築します。 特に、不要になった依存`RoMetadata.dll`します。
 
これらの依存関係は、 `cppwinrt.exe` 2.0。
 
- api-ms-win-core-processenvironment-l1-1-0.dll
- api-ms-win-core-libraryloader-l1-2-0.dll
- XmlLite.dll
- api-ms-win-core-memory-l1-1-0.dll
- api-ms-win-core-handle-l1-1-0.dll
- api-ms-win-core-file-l1-1-0.dll
- SHLWAPI.dll
- ADVAPI32.dll
- KERNEL32.dll
- api-ms-win-core-rtlsupport-l1-1-0.dll
- api-ms-win-core-processthreads-l1-1-0.dll
- api-ms-win-core-heap-l1-1-0.dll
- api-ms-win-core-console-l1-1-0.dll
- api-ms-win-core-localization-l1-2-0.dll

これらの依存関係とは対照的が`cppwinrt.exe`1.0 には。

- ADVAPI32.dll
- SHELL32.dll
- api-ms-win-core-file-l1-1-0.dll
- XmlLite.dll
- api-ms-win-core-libraryloader-l1-2-0.dll
- api-ms-win-core-processenvironment-l1-1-0.dll
- RoMetadata.dll
- SHLWAPI.dll
- KERNEL32.dll
- api-ms-win-core-rtlsupport-l1-1-0.dll
- api-ms-win-core-heap-l1-1-0.dll
- api-ms-win-core-timezone-l1-1-0.dll
- api-ms-win-core-console-l1-1-0.dll
- api-ms-win-core-localization-l1-2-0.dll
- OLEAUT32.dll
- api-ms-win-core-winrt-error-l1-1-0.dll
- api-ms-win-core-winrt-error-l1-1-1.dll
- api-ms-win-core-winrt-l1-1-0.dll
- api-ms-win-core-winrt-string-l1-1-0.dll
- api-ms-win-core-synch-l1-1-0.dll
- api-ms-win-core-threadpool-l1-2-0.dll
- api-ms-win-core-com-l1-1-0.dll
- api-ms-win-core-com-l1-1-1.dll
- api-ms-win-core-synch-l1-2-0.dll 

#### <a name="the-windows-runtime-noexcept-attribute"></a>Windows ランタイム`noexcept`属性

Windows ランタイムは新しい`[noexcept]`、属性、メソッドとプロパティを修飾するために使用することが[MIDL 3.0](/uwp/midl-3/predefined-attributes)します。 属性の有無は、実装が例外をスローしないツールのサポートすることを示します (障害のあるを返すも HRESULT)。 これにより、言語プロジェクションが失敗する可能性のあるアプリケーション バイナリ インターフェイス (ABI) の呼び出しをサポートするために必要な例外処理のオーバーヘッドを回避することでコード生成を最適化することができます。

C++/WinRT を生成するこの方法の利点は、 C++ `noexcept`実装、消費し、コードを作成します。 API のメソッドまたは、失敗のないとしているプロパティは、コードのサイズに関する懸念している場合は、この属性を調査できます。

#### <a name="optimized-code-generation"></a>最適化されたコード生成

C++/WinRT を今すぐ生成効率がいっそう高まりますC++ソース コード (バック グラウンドで) ので、C++コンパイラは、最小値と最も効率的なバイナリ コード可能性を生成できます。 例外処理のコストを削減向けと機能強化の多くが不要なを回避することでアンワインド情報。 使用して、大量のバイナリC++WinRT コードが約 4% 削減コードのサイズで表示されます。 コードがより効率的な (より速く実行されます) も、縮小命令数が原因です。

これらの機能強化もが、使用可能な新しい相互運用機能に依存します。 すべてのC++]、[リソースの所有者となっている WinRT 型には、前の 2 段階のアプローチを回避の所有権を直接コンス トラクターにはが含まれます。

```cppwinrt
ABI::Windows::Foundation::IStringable* raw = ...

IStringable projected(raw, take_ownership_from_abi);

printf("%ls\n", projected.ToString().c_str());
```

#### <a name="optimized-exception-handling-eh-code-generation"></a>最適化された例外処理 (EH) のコード生成

この変更は、マイクロソフトが行った作業を補完C++オプティマイザー チーム例外処理のコストを削減できます。 コードで大きく (COM) などのアプリケーション バイナリ インターフェイス (Abi) を使用する場合、多くのこのパターンに従うコードを確認します。

```cpp
int32_t Function() noexcept
{
    try
    {
        // code here constitutes unique value.
    }
    catch (...)
    {
        // code here is always duplicated.
    }
}
```

C++/WinRT 自体は、実装されているすべての API をこのパターンを生成します。 何千もの API 関数のここで最適化を重要なことがあります。 オプティマイザー以前は、その catch ブロックであることを検出はありませんは、多くの (さらにシステム コードで例外を使用して大きなバイナリを生成するという確信に提供) を各 ABI の周囲のコードを複製することがあるために、すべて同じです。 ただしで、Visual Studio 2019 から、C++コンパイラがそれらのすべての圧縮 funclets をキャッチし、固有のものを格納するだけです。 結果は、このパターンに大きく依存するバイナリ コードのサイズの詳細と全体的な 18% 減少します。 だけでなく EH コードようになりましたリターン コードを使用するよりも効率がも大きいバイナリ ファイルに関する問題ようになりました、過去のものです。

#### <a name="incremental-build-improvements"></a>インクリメンタル ビルドの機能強化

`cppwinrt.exe`ツールでは、ディスク上で既存のファイルの内容に対して生成されたヘッダー/ソース ファイルの出力を比較し、ファイルが実際に変更された場合は、ファイルにのみ書き込みます。 ディスク I/O、かなりの時間を短縮し、これにより、ファイルが、「ダーティ」考慮されませんが、C++コンパイラ。 結果は、その再コンパイルを回避、または縮小、多くの場合は。

#### <a name="generic-interfaces-are-now-all-generated"></a>ジェネリック インターフェイスは、生成されたものではようになりました

により、xlang メタデータ リーダー C++/WinRT は、メタデータからすべてのパラメーター化された、または、ジェネリック インターフェイスを生成するようになりました。 ようなインターフェイス[:ivector\<T\> ](/uwp/api/windows.foundation.collections.ivector_t_)は今すぐメタデータから生成されたではなく手作業で記述された`winrt/base.h`します。 その結果、サイズの`winrt/base.h`、半分にカットされた最適化が生成されると、(このアプローチでは手ロールバックを行うは大変でした) コードに右します。

> [!IMPORTANT]
> 指定の例などのインターフェイスは、それぞれの名前空間のヘッダーではなくでを表示`winrt/base.h`します。 そのため、されていない場合は、インターフェイスを使用するには、適切な名前空間のヘッダーを含める必要があります。

#### <a name="component-optimizations"></a>コンポーネントの最適化

この更新プログラムには、いくつか追加のオプトインの最適化のサポートが追加されます。 C++/WinRT、以下のセクションで説明します。 有効にするを明示的に使用する必要がありますので、これらの最適化は中断中の変更 (をサポートするために小さな変更を加える必要があります)、`cppwinrt.exe`ツールの`-opt`フラグ。

(プロジェクト テンプレート) から新しいプロジェクトを使用して`-opt`既定。

##### <a name="uniform-construction-and-direct-implementation-access"></a>Uniform の構築、および直接実装へのアクセス

これら 2 つの最適化は、射影された型のみを使用している場合でも、独自の実装の型に、コンポーネントの直接アクセスを許可します。 使用する必要はありません[**ように**](/uwp/cpp-ref-for-winrt/make)、 [ **make_self**](/uwp/cpp-ref-for-winrt/make-self)も[ **get_self** ](/uwp/cpp-ref-for-winrt/get-self)場合は、パブリック API サーフェイスを使用するだけです。 呼び出しは、実装への直接呼び出しにコンパイルされ、それらできない可能性がありますも完全にインライン化します。

##### <a name="type-erased-factories"></a>ファクトリの型消去

この最適化を回避、# で依存関係を include`module.g.cpp`に必要な再コンパイルされません任意の 1 つの実装クラスの動作を変更するたびにできるようにします。 強化されたビルドのパフォーマンスになります。

#### <a name="smarter-and-more-efficient-modulegcpp-for-large-projects-with-multiple-libs"></a>スマートかつ効率的`module.g.cpp`大規模なプロジェクトに複数のライブラリ

`module.g.cpp`今すぐファイルも、という名前の 2 つの追加構成可能なヘルパーを含む**winrt_can_unload_now**、および**winrt_get_activation_factory**します。 これらは、それぞれに独自のランタイム クラス ライブラリ、多数の DLL がここで構成されますが、大規模なプロジェクトの設計されています。 そのような状況で、DLL を手動で合成する必要があります。 **DllGetActivationFactory**と**DllCanUnloadNow**します。 これらのヘルパーを作成すると、見かけ上の実行元のエラーを回避することでは、はるかに簡単です。 `cppwinrt.exe`ツールの`-lib`フラグが、独自のプリアンブルごとの個々 の lib を提供することも可能性があります (なく`winrt_xxx`) できるように、各ライブラリの関数で個別に名前付きの場合、明確に組み合わせてしたがって可能性があります。

#### <a name="new-winrtcoroutineh-header"></a>新しい`winrt/coroutine.h`ヘッダー

`winrt/coroutine.h`ヘッダーがすべての新しいホームC++/WinRT のコルーチンのサポート。 このサポート、いくつかの場所に存在していた以前とこれが限定的すぎます。 現在ある手作業で記述されたのではなく、Windows ランタイムの非同期インターフェイスが生成されるようになりましたので`winrt/Windows.Foundation.h`します。 サポート可能と保守が容易なであるとは別に意味するコルーチンなどのヘルパー [ **resume_foreground** ](/uwp/cpp-ref-for-winrt/resume-foreground)に数行の特定の名前空間のヘッダーの末尾が不要になった。 代わりに、その依存関係より自然含めることができます。 これにより、さらに**resume_foreground**だけでなくの再開をサポートするために、指定された[ **Windows::UI::Core::CoreDispatcher**](/uwp/api/windows.ui.core.coredispatcher)ができるようになりましたもサポートの再開を指定[ **Windows::System::DispatcherQueue**](/uwp/api/windows.system.dispatcherqueue)します。 以前は、1 つのみをサポートできます。両方ではなく、定義は、1 つの名前空間にのみ存在でしたので。

次の例に示します、 **DispatcherQueue**をサポートします。

```cppwinrt
fire_and_forget Async(DispatcherQueueController controller)
{
    bool queued = co_await resume_foreground(controller.DispatcherQueue());
    assert(queued);

    // This is just to simulate queue failure...
    co_await controller.ShutdownQueueAsync();

    queued = co_await resume_foreground(controller.DispatcherQueue());
    assert(!queued);
}
```

コルーチンのヘルパーもで修飾されたようになりました`[[nodiscard]]`のため、その使いやすさを向上します。 かどうかにもご活用ください (またはする必要があることに気付かず)`co_await`使用するには次に、理由のために`[[nodiscard]]`、このような誤りは、コンパイラの警告を生成します。

#### <a name="help-with-diagnosing-stack-allocations"></a>スタック割り当ての診断に役立ちます

使用してではなく、その他の 1 つはよく間違わを誤って、スタックの実装を作成することが予測と実装のクラス名が (既定) では、同じ名前空間のみが異なるため、 [ **ように**](/uwp/cpp-ref-for-winrt/make)ヘルパーのファミリです。 これは、未解決の参照は引き続きフライト中に、オブジェクトが破棄される可能性がありますので、場合によっては、診断が困難です。 今すぐアサーション ピックアップこれ、デバッグ ビルドの場合。 アサーションは、コルーチン内部でのスタック割り当てを検出は、このような誤りはほとんどの把握に役立つがそれでもです。

#### <a name="improved-capture-helpers-and-variadic-delegates"></a>強化されたキャプチャのヘルパーと可変個引数のデリゲート

この更新プログラムは、射影された型もサポートすることによってキャプチャ ヘルパーの制限を修正します。 これと Windows ランタイムの相互運用 Api では、射影の型が戻るときにされます。

この更新はサポートも追加[ **get_strong** ](/uwp/cpp-ref-for-winrt/implements#implementsget_strong-function)と[ **get_weak** ](/uwp/cpp-ref-for-winrt/implements#implementsget_weak-function)可変個引数 (非 Windows ランタイム) のデリゲートを作成するときにします。

#### <a name="support-for-deferred-destruction-and-safe-qi-during-destruction"></a>遅延の破棄と破棄中に安全な QI のサポート

XAML アプリケーションは難易度を実行する必要があったためにそれ自体を取得できます、 [ **QueryInterface** ](/windows/desktop/api/unknwn/nf-unknwn-iunknown-queryinterface(q_)) (QI) 階層を上下するいくつかのクリーンアップの実装を呼び出すために、デストラクターでします。 ただし、0 に達した後、オブジェクトの参照カウントが既に、呼び出しにはで、QI が含まれています。 この更新プログラムは再生されません。 0 に達したことを確認する、参照カウントを debouncing サポートを追加します。破棄中に必要な一時の QI ができます。 この手順が特定の XAML アプリケーション/コントロール、避けられないとC++/WinRT に回復力のあるようになりました。

静的なを提供することで破壊を延期できる**final_release**関数、およびの所有権を移動、 **unique_ptr**の他のコンテキストにします。

```cppwinrt
struct Sample : implements<Sample, IStringable>
{
    hstring ToString()
    {
        return L"Sample";
    }

    ~Sample()
    {
        // Called when the unique_ptr below is reset.
    }

    static void final_release(std::unique_ptr<Sample> ptr) noexcept
    {
        // Move 'ptr' as needed to delay destruction.
    }
};
```

1 回次の例で、 **MainPage** (の最終的な時間) がリリースされる**final_release**が呼び出されます。 関数が待機している (スレッド プールにある)、5 秒を費やすことし、ページを使用して、再開**ディスパッチャー** (QI/Addref/release 作業が必要する)。 クリアします、 **unique_ptr**、原因となる、 **MainPage**を実際に呼び出されるデストラクター。 ここでも、 **DataContext**を呼び出すの QI を必要とする**IFrameworkElement**。 当然ながら、実装することも、 **final_release**がコルーチンとして。 機能し、破棄を別のスレッドに移動する非常に単純な使用します。

```cppwinrt
struct MainPage : PageT<MainPage>
{
    MainPage()
    {
    }

    ~MainPage()
    {
        DataContext(nullptr);
    }

    static IAsyncAction final_release(std::unique_ptr<MainPage> ptr)
    {
        co_await 5s;

        co_await resume_foreground(ptr->Dispatcher());

        ptr = nullptr;
    }
};
```

#### <a name="improved-support-for-com-style-single-interface-inheritance"></a>COM スタイルの単一のインターフェイスの継承に対するサポートの向上

Windows ランタイム プログラミング用としてもC++/WinRT は作成および COM 専用の Api を使用することも使用されます。 この更新プログラムでは、あるインターフェイスの階層構造が存在する COM サーバーを実装できます。 これには Windows ランタイムは必要ありません。COM 実装の必要があります。

#### <a name="correct-handling-of-out-params"></a>処理の適切な`out`params

使用することはたいへん`out`params。 特に Windows ランタイムの配列。 この更新で、 C++/に関しては WinRT はかなりより堅牢で耐障害性を間違い`out`params と配列は、言語プロジェクションを使用して、または生の ABI を使用しているユーザーと、担当するユーザーは、COM 開発者から、これらのパラメーターが到着したかどうか一貫していない変数の初期化の間違いです。 いずれの場合も、 C++WinRT は適切な処理をようになりましたが (記憶してリソースを解放する)、ABI に射影された型を渡す際と領域の解放または ABI 間で到着するパラメーターを消去するのにあたって/。

#### <a name="events-now-handle-invalid-tokens-reliably"></a>イベントで無効なトークンを確実に処理ようになりました

[ **Winrt::event** ](/uwp/cpp-ref-for-winrt/event)現在の実装は、大文字と小文字を適切に処理をその**削除**トークン値が無効なメソッドが呼び出されます (にない値、配列の場合)。

#### <a name="coroutine-locals-are-now-destroyed-before-the-coroutine-returns"></a>コルーチンが戻る前に、コルーチンのローカル変数が破棄ようになりました

コルーチンの型を実装するは、従来の方法は、コルーチン内部ローカル変数を破棄することを許可*後*コルーチン返します/が完了すると (前の最後の中断) ではありません。 この問題を回避するには、その他の特典の課金、任意の待機処理の再開は最後の中断まで延期ようになりました。

## <a name="news-and-changes-in-windows-sdk-version-100177630-windows-10-version-1809"></a>ニュース、および変更 で、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョンは 1809)

次の表は、ニュースを含むし、への変更[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) 10.0.17763.0 (Windows 10、バージョンは 1809) で一般公開バージョンの最新の Windows SDK であります。 これらの変更も SDK Insider Preview 以降のバージョンに存在する場合があります。

| 新規または変更された機能 | 詳細情報 |
| - | - |
| **互換性に影響する変更**します。 コンパイル、C +/cli WinRT は、Windows SDK からのヘッダーに依存しません。 | 参照してください[Windows SDK ヘッダー ファイルから分離](#isolation-from-windows-sdk-header-files)、後述します。 |
| Visual Studio プロジェクト システムの形式が変更されました。 | 参照してください[、C + の再ターゲットする方法/cli WinRT プロジェクトは、以降のバージョンの Windows SDK を](#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk)、後述します。 |
| 新しい機能と Windows ランタイム関数の場合にコレクション オブジェクトを渡すため、または独自のコレクションのプロパティとコレクション型を実装する基底クラスがあります。 | 参照してください[コレクション c++/cli WinRT](collections.md)します。 |
| 使用することができます、 [{binding}](/windows/uwp/xaml-platform/binding-markup-extension)マークアップ拡張では、C +/cli WinRT ランタイム クラスです。 | 詳細については、およびコード例は、次を参照してください。[データ バインディングの概要](/windows/uwp/data-binding/data-binding-quickstart)します。 |
| コルーチンのキャンセルのサポートを使用すると、取り消しのコールバックを登録できます。 | 詳細については、およびコード例は、次を参照してください。[非同期操作、および取り消しのコールバックをキャンセル](concurrency.md#canceling-an-asychronous-operation-and-cancellation-callbacks)します。 |
| メンバー関数を指すデリゲートを作成するときに、強力なまたは現在のオブジェクトへの弱い参照を確立することができます (未加工ではなく*この*ポインター)、ハンドラーが登録されている時点。 | 詳細については、およびコード例は、次を参照してください、**デリゲートとしてメンバー関数を使用する場合**サブセクションに記載[安全にアクセスする、*これ*イベント処理デリゲートとポインター](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate). |
| C++ 標準に Visual Studio の適合性を向上によって発見されたバグが修正されます。 LLVM と Clang ツール チェーンを活用すると、C + 検証よりも/cli WinRT の標準への準拠。 | 説明されている問題が発生するが不要になった[自分の新しいプロジェクトがコンパイルされない理由でしょうか。Visual Studio 2017 を使用している (15.8.0 バージョンまたはそれ以降)、および SDK version 17134](faq.md#why-wont-my-new-project-compile-im-using-visual-studio-2017-version-1580-or-higher-and-sdk-version-17134) |

その他の変更。

- **互換性に影響する変更**します。 [**winrt::get_abi(winrt::hstring const&)** ](/uwp/cpp-ref-for-winrt/get-abi)返すようになりました`void*`の代わりに`HSTRING`します。 使用することができます`static_cast<HSTRING>(get_abi(my_hstring));`HSTRING を取得します。
- **互換性に影響する変更**します。 [**winrt::put_abi(winrt::hstring&)** ](/uwp/cpp-ref-for-winrt/put-abi)返すようになりました`void**`の代わりに`HSTRING*`します。 使用することができます`reinterpret_cast<HSTRING*>(put_abi(my_hstring));`HSTRING * を取得します。
- **互換性に影響する変更**します。 HRESULT として投影今すぐ**winrt::hresult**します。 HRESULT (に型チェック、または型の特徴をサポートするために)、する必要があるかどうかはその後、 `static_cast` 、 **winrt::hresult**します。 それ以外の場合、 **winrt::hresult** HRESULT に変換します含める限り`unknwn.h`すべて C + インクルードする前に/cli WinRT ヘッダー。
- **互換性に影響する変更**します。 GUID として投影今すぐ**winrt::guid**します。 実装する api を使用する必要があります**winrt::guid** GUID パラメーター。 それ以外の場合、 **winrt::guid** GUID に変換する限り`unknwn.h`いずれかをインクルードする前にC++/WinRT ヘッダー。
- **互換性に影響する変更**します。 [ **Winrt::handle_type コンス トラクター** ](/uwp/cpp-ref-for-winrt/handle-type#handle_typehandle_type-constructor) (これは今すぐ困難と不適切なコードを記述する) を明示的にすることで書き込まれています。 未処理のハンドル値を割り当てる必要がある場合は、呼び出し、 [ **handle_type::attach 関数**](/uwp/cpp-ref-for-winrt/handle-type#handle_typeattach-function)代わりにします。
- **互換性に影響する変更**します。 シグネチャ**WINRT_CanUnloadNow**と**WINRT_GetActivationFactory**が変更されました。 これらの関数は、まったく宣言しないでください。 代わりに、含める`winrt/base.h`(C + 任意を含める場合に自動的に含まれている/cli WinRT Windows 名前空間のヘッダー ファイル) これらの関数の宣言を含めます。
- [ **Winrt::clock 構造体**](/uwp/cpp-ref-for-winrt/clock)、 **from_FILETIME/to_FILETIME**好評だったは非推奨と**from_file_time/to_file_time**します。
- 期待する Api **IBuffer**パラメーターが簡素化されます。 十分な Api が依存するが、ほとんどの Api には、コレクションまたは配列が必要に応じて、 **IBuffer** C++ からこのような Api を使用して容易になる必要があります。 この更新プログラムの背後にあるデータに直接アクセスを提供する、 **IBuffer** C++ 標準ライブラリ コンテナーで使用される同じデータ名前付け規則を使用して実装します。 これには、競合するメタデータの名前が大文字で始まる規約も回避できます。
- コード生成の向上: コードのサイズを小さくさまざまな機能強化は、インライン展開を向上させるし、工場出荷時のキャッシュを最適化します。
- 不要な再帰を削除します。 ときに、コマンド ラインは、特定ではなく、フォルダーに`.winmd`、`cppwinrt.exe`に対して再帰的に不要になった検索`.winmd`ファイル。 `cppwinrt.exe`ツールも現在処理重複よりインテリジェントに適切な形式は、ユーザー エラー、回復力のある`.winmd`ファイル。
- セキュリティを強化したスマート ポインター。 以前は、ときに失効に失敗したイベント revokers 移動によって割り当てられた新しい値。 これにより、スマート ポインター クラス自己代入; の処理をでした。 確実に問題を発見基盤として、 [ **winrt::com_ptr 構造体のテンプレート**](/uwp/cpp-ref-for-winrt/com-ptr)します。 **winrt::com_ptr**が修正され、し、処理する固定イベント revokers 移動セマンティクスを正しく割り当て時に失効できるようにします。

> [!IMPORTANT]
> 重要な変更を加えました、 [C +/cli WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)1.0.181002.2 のバージョンでどちらもバージョン 1.0.190128.4 で後で。 これらの変更と、既存のプロジェクトへの影響についての詳細については[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)と[VSIX 拡張機能の以前のバージョン](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension)。

### <a name="isolation-from-windows-sdk-header-files"></a>Windows SDK ヘッダー ファイルからの分離

これは、可能性のあるコードの互換性に影響する変更です。

コンパイル、C +/cli WinRT が不要になった Windows SDK からのヘッダー ファイルに依存します。 C ランタイム ライブラリ (CRT) および C++ 標準テンプレート ライブラリ (STL) のヘッダー ファイルは、すべての Windows SDK ヘッダーも含めないでください。 およびを標準への準拠を向上、不慮の依存関係を回避およびを防ぐために必要のあるマクロの数を大幅に短縮します。

この独立性は c++/cli WinRT が移植性に優れてなり標準に準拠して、およびクロス コンパイラとクロス プラットフォーム ライブラリになる可能性を推進します。 意味 c++/cli WinRT ヘッダーが悪影響を及ぼす影響を受けるマクロはありません。

C++ 以前ままの場合/cli WinRT を今すぐそれらを含める必要がありますし、プロジェクトで、任意の Windows ヘッダーを含めます。 いずれの場合も、常のベスト プラクティスを明示的に依存するヘッダーを含めるし、しない別のライブラリに含めることのままにします。

現時点では、Windows SDK ヘッダー ファイルの分離の唯一の例外は組み込み関数、および数値です。 この最後の残りの依存関係に関する既知の問題はありません。

必要がある場合は、プロジェクトの Windows SDK のヘッダーとの相互運用を有効にできます再。 COM インターフェイスを実装する可能性があります、たとえば、(ルートと[ **IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509))。 例では、含める`unknwn.h`すべて C + インクルードする前に/cli WinRT ヘッダー。 そのため、C +/cli WinRT ベースのライブラリにクラシック COM インターフェイスをサポートするためにさまざまなフックを有効にします。 コード例では、次を参照してください。 [C + での作成者の COM コンポーネント/cli WinRT](author-coclasses.md)します。 同様に、宣言型や関数を呼び出そうとするその他の Windows SDK ヘッダーに明示的に含まれます。

### <a name="how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk"></a>C++ の再ターゲットする方法/cli 以降のバージョンの Windows SDK に WinRT プロジェクト

最小限のコンパイラとリンカーの問題が発生する可能性があるプロジェクトの再ターゲットのメソッドは、最も手間もあります。 (任意の Windows SDK のバージョンを対象とする) 新しいプロジェクトを作成し、古いからは経由で新しいプロジェクトのファイルをコピーし、そのメソッドが含まれます。 古いのセクションがあります`.vcxproj`と`.vcxproj.filters`できますファイルをコピー以上節約 Visual Studio でファイルを追加します。

ただし、Visual Studio でプロジェクトを再ターゲットするその他の 2 つの方法はあります。

- プロジェクトのプロパティに移動して**全般** \> **Windows SDK バージョン**を選択し、**すべての構成**と**すべてのプラットフォーム**します。 設定**Windows SDK バージョン**を対象とバージョン。
- **ソリューション エクスプ ローラー**は、プロジェクト ノードを右クリックし、**プロジェクトの再ターゲット**をクリックして、ターゲット バージョンを選択**OK**。

これら 2 つのメソッドのいずれかを使用した後、コンパイラやリンカー エラーが発生するかどうかは、ソリューションをクリーニングを再試行してください (**ビルド** > **ソリューションのクリーン**またはすべてを手動で削除一時フォルダーおよびファイル) をもう一度ビルドを試みる前にします。

C++ コンパイラが生成した場合"*エラー C2039:'IUnknown': のメンバーではない '\`グローバル名前空間'*"、追加し、`#include <unknwn.h>`の先頭に、`pch.h`ファイル (C +、インクルードする前に/cli WinRT ヘッダー)。

追加する必要がありますも`#include <hstring.h>`にします。

C++ リンカーが生成した場合"*エラー LNK2019: 未解決の外部シンボル_WINRT_CanUnloadNow@0関数で参照されている_VSDesignerCanUnloadNow@0* "を追加することで解決できます`#define _VSDESIGNER_DONT_LOAD_AS_DLL`を`pch.h`ファイル。
