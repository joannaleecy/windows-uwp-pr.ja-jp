---
description: ニュースと変更を C +/cli WinRT します。
title: 新しい c++/cli WinRT
ms.date: 01/29/2019
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、プロジェクション、ニュース、ものの新しい
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: cb624a93a010dfe9784cf8c26beed12c6cf2f77d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57639957"
---
# <a name="whats-new-in-cwinrt"></a>新しい c++/cli WinRT

次の表は、ニュースを含むし、への変更[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) 10.0.17763.0 (Windows 10、バージョンは 1809) で一般公開バージョンの最新の Windows SDK であります。 これらの変更も SDK Insider Preview 以降のバージョンに存在する場合があります。

## <a name="news-and-changes-in-windows-sdk-version-100177630-windows-10-version-1809"></a>ニュース、および変更 で、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョンは 1809)

| 新規または変更された機能 | 詳細情報 |
| - | - |
| **互換性に影響する変更**します。 コンパイル、C +/cli WinRT は、Windows SDK からのヘッダーに依存しません。 | 参照してください[Windows SDK ヘッダー ファイルから分離](#isolation-from-windows-sdk-header-files)、後述します。 |
| Visual Studio プロジェクト システムの形式が変更されました。 | 参照してください[、C + の再ターゲットする方法/cli WinRT プロジェクトは、以降のバージョンの Windows SDK を](#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk)、後述します。 |
| 新しい機能と Windows ランタイム関数の場合にコレクション オブジェクトを渡すため、または独自のコレクションのプロパティとコレクション型を実装する基底クラスがあります。 | 参照してください[コレクション c++/cli WinRT](collections.md)します。 |
| 使用することができます、 [{binding}](/windows/uwp/xaml-platform/binding-markup-extension)マークアップ拡張では、C +/cli WinRT ランタイム クラスです。 | 詳細については、およびコード例は、[データ バインディングの概要](/windows/uwp/data-binding/data-binding-quickstart)を参照してください。 |
| コルーチンのキャンセルのサポートを使用すると、取り消しのコールバックを登録できます。 | 詳細については、およびコード例は、[非同期操作、および取り消しのコールバックをキャンセル](concurrency.md#canceling-an-asychronous-operation-and-cancellation-callbacks)を参照してください。 |
| メンバー関数を指すデリゲートを作成するときに、強力なまたは現在のオブジェクトへの弱い参照を確立することができます (未加工ではなく*この*ポインター)、ハンドラーが登録されている時点。 | 詳細については、およびコード例は、次を参照してください、**デリゲートとしてメンバー関数を使用する場合**サブセクションに記載[安全にアクセスする、*これ*イベント処理デリゲートとポインター](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate). |
| C++ 標準に Visual Studio の適合性を向上によって発見されたバグが修正されます。 LLVM と Clang ツール チェーンを活用すると、C + 検証よりも/cli WinRT の標準への準拠。 | 説明されている問題が発生するが不要になった[自分の新しいプロジェクトがコンパイルされない理由でしょうか。Visual Studio 2017 を使用している (15.8.0 バージョンまたはそれ以降)、および SDK version 17134](faq.md#why-wont-my-new-project-compile-im-using-visual-studio-2017-version-1580-or-higher-and-sdk-version-17134) |

その他の変更。

- **互換性に影響する変更**します。 [**winrt::get_abi(winrt::hstring const&)** ](/uwp/cpp-ref-for-winrt/get-abi)返すようになりました`void*`の代わりに`HSTRING`します。 使用することができます`static_cast<HSTRING>(get_abi(my_hstring));`HSTRING を取得します。
- **互換性に影響する変更**します。 [**winrt::put_abi(winrt::hstring&)** ](/uwp/cpp-ref-for-winrt/put-abi)返すようになりました`void**`の代わりに`HSTRING*`します。 使用することができます`reinterpret_cast<HSTRING*>(put_abi(my_hstring));`HSTRING * を取得します。
- **互換性に影響する変更**します。 HRESULT として投影今すぐ**winrt::hresult**します。 HRESULT (に型チェック、または型の特徴をサポートするために)、する必要があるかどうかはその後、 `static_cast` 、 **winrt::hresult**します。 それ以外の場合、 **winrt::hresult** HRESULT に変換します含める限り`unknwn.h`すべて C + インクルードする前に/cli WinRT ヘッダー。
- **互換性に影響する変更**します。 GUID として投影今すぐ**winrt::guid**します。 実装する api を使用する必要があります**winrt::guid** GUID パラメーター。 それ以外の場合、 **winrt::hresult** GUID に変換する限り`unknwn.h`すべて C + インクルードする前に/cli WinRT ヘッダー。
- **互換性に影響する変更**します。 [ **Winrt::handle_type コンス トラクター** ](/uwp/cpp-ref-for-winrt/handle-type#handletypehandletype-constructor) (これは今すぐ困難と不適切なコードを記述する) を明示的にすることで書き込まれています。 未処理のハンドル値を割り当てる必要がある場合は、呼び出し、 [ **handle_type::attach 関数**](/uwp/cpp-ref-for-winrt/handle-type#handletypeattach-function)代わりにします。
- **互換性に影響する変更**します。 シグネチャ**WINRT_CanUnloadNow**と**WINRT_GetActivationFactory**が変更されました。 これらの関数は、まったく宣言しないでください。 代わりに、含める`winrt/base.h`(C + 任意を含める場合に自動的に含まれている/cli WinRT Windows 名前空間のヘッダー ファイル) これらの関数の宣言を含めます。
- [ **Winrt::clock 構造体**](/uwp/cpp-ref-for-winrt/clock)、 **from_FILETIME/to_FILETIME**好評だったは非推奨と**from_file_time/to_file_time**します。
- 期待する Api **IBuffer**パラメーターが簡素化されます。 十分な Api が依存するが、ほとんどの Api には、コレクションまたは配列が必要に応じて、 **IBuffer** C++ からこのような Api を使用して容易になる必要があります。 この更新プログラムの背後にあるデータに直接アクセスを提供する、 **IBuffer** C++ 標準ライブラリ コンテナーで使用される同じデータ名前付け規則を使用して実装します。 これには、競合するメタデータの名前が大文字で始まる規約も回避できます。
- コード生成の向上: コードのサイズを小さくさまざまな機能強化は、インライン展開を向上させるし、工場出荷時のキャッシュを最適化します。
- 不要な再帰を削除します。 ときに、コマンド ラインは、特定ではなく、フォルダーに`.winmd`、`cppwinrt.exe`に対して再帰的に不要になった検索`.winmd`ファイル。 `cppwinrt.exe`ツールも現在処理重複よりインテリジェントに適切な形式は、ユーザー エラー、回復力のある`.winmd`ファイル。
- セキュリティを強化したスマート ポインター。 以前は、ときに失効に失敗したイベント revokers 移動によって割り当てられた新しい値。 これにより、スマート ポインター クラス自己代入; の処理をでした。 確実に問題を発見基盤として、 [ **winrt::com_ptr 構造体のテンプレート**](/uwp/cpp-ref-for-winrt/com-ptr)します。 **winrt::com_ptr**が修正され、し、処理する固定イベント revokers 移動セマンティクスを正しく割り当て時に失効できるようにします。

> [!IMPORTANT]
> 重要な変更を加えました、 [C +/cli WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)1.0.181002.2 のバージョンでどちらもバージョン 1.0.190128.4 で後で。 これらの変更と、既存のプロジェクトへの影響についての詳細については[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)と[VSIX 拡張機能の以前のバージョン](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension)。

## <a name="isolation-from-windows-sdk-header-files"></a>Windows SDK ヘッダー ファイルからの分離

これは、可能性のあるコードの互換性に影響する変更です。

コンパイル、C +/cli WinRT が不要になった Windows SDK からのヘッダー ファイルに依存します。 C ランタイム ライブラリ (CRT) および C++ 標準テンプレート ライブラリ (STL) のヘッダー ファイルは、すべての Windows SDK ヘッダーも含めないでください。 およびを標準への準拠を向上、不慮の依存関係を回避およびを防ぐために必要のあるマクロの数を大幅に短縮します。

この独立性は c++/cli WinRT が移植性に優れてなり標準に準拠して、およびクロス コンパイラとクロス プラットフォーム ライブラリになる可能性を推進します。 意味 c++/cli WinRT ヘッダーが悪影響を及ぼす影響を受けるマクロはありません。

C++ 以前ままの場合/cli WinRT を今すぐそれらを含める必要がありますし、プロジェクトで、任意の Windows ヘッダーを含めます。 いずれの場合も、常のベスト プラクティスを明示的に依存するヘッダーを含めるし、しない別のライブラリに含めることのままにします。

現時点では、Windows SDK ヘッダー ファイルの分離の唯一の例外は組み込み関数、および数値です。 この最後の残りの依存関係に関する既知の問題はありません。

必要がある場合は、プロジェクトの Windows SDK のヘッダーとの相互運用を有効にできます再。 COM インターフェイスを実装する可能性があります、たとえば、(ルートと[ **IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509))。 例では、含める`unknwn.h`すべて C + インクルードする前に/cli WinRT ヘッダー。 そのため、C +/cli WinRT ベースのライブラリにクラシック COM インターフェイスをサポートするためにさまざまなフックを有効にします。 コード例では、[C + での作成者の COM コンポーネント/cli WinRT](author-coclasses.md)を参照してください。 同様に、宣言型や関数を呼び出そうとするその他の Windows SDK ヘッダーに明示的に含まれます。

## <a name="how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk"></a>C++ の再ターゲットする方法/cli 以降のバージョンの Windows SDK に WinRT プロジェクト

最小限のコンパイラとリンカーの問題が発生する可能性があるプロジェクトの再ターゲットのメソッドは、最も手間もあります。 (任意の Windows SDK のバージョンを対象とする) 新しいプロジェクトを作成し、古いからは経由で新しいプロジェクトのファイルをコピーし、そのメソッドが含まれます。 古いのセクションがあります`.vcxproj`と`.vcxproj.filters`できますファイルをコピー以上節約 Visual Studio でファイルを追加します。

ただし、Visual Studio でプロジェクトを再ターゲットするその他の 2 つの方法はあります。

- プロジェクトのプロパティに移動して**全般** \> **Windows SDK バージョン**を選択し、**すべての構成**と**すべてのプラットフォーム**します。 設定**Windows SDK バージョン**を対象とバージョン。
- **ソリューション エクスプ ローラー**は、プロジェクト ノードを右クリックし、**プロジェクトの再ターゲット**をクリックして、ターゲット バージョンを選択**OK**。

これら 2 つのメソッドのいずれかを使用した後、コンパイラやリンカー エラーが発生するかどうかは、ソリューションをクリーニングを再試行してください (**ビルド** > **ソリューションのクリーン**またはすべてを手動で削除一時フォルダーおよびファイル) をもう一度ビルドを試みる前にします。

C++ コンパイラが生成した場合"*エラー C2039:'IUnknown': のメンバーではない '\`グローバル名前空間'*"、追加し、`#include <unknwn.h>`の先頭に、`pch.h`ファイル (C +、インクルードする前に/cli WinRT ヘッダー)。

追加する必要がありますも`#include <hstring.h>`にします。

C++ リンカーが生成した場合"*エラー LNK2019: 未解決の外部シンボル_WINRT_CanUnloadNow@0関数で参照されている_VSDesignerCanUnloadNow@0* "を追加することで解決できます`#define _VSDESIGNER_DONT_LOAD_AS_DLL`を`pch.h`ファイル。
