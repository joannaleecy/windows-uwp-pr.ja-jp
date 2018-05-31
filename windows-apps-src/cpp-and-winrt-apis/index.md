---
author: stevewhims
description: Windows SDK には C++/WinRT が含まれます。 これは Windows ランタイム API の標準的な C++ 言語プロジェクションで、ヘッダー ファイルに単独で実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C++/WinRT の場合、標準に準拠した C++ のコンパイラを使用して Windows ランタイム API を作成および使用できます。
title: C++/WinRT
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション
ms.localizationpriority: medium
ms.openlocfilehash: e364283c998179264fc3aa4cb8581d511608f251
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1831816"
---
# [<a name="cwinrt"></a>C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)
<BR/>
> [!VIDEO https://www.youtube.com/embed/TLSul1XxppA]

バージョン 10.0.17134.0 (Windows 10、バージョン 1803) に導入されたため、Windows SDK に C++/WinRT が含まれるようになりました。 C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイルに単独で実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C++/WinRT の場合、標準に準拠した C++17 のコンパイラを使用して Windows ランタイム API を作成および使用できます。

C++/WinRT は、Windows 用の美しく高速なコードの作成に興味のある開発者向けです。 次に、その理由を示します。

## <a name="the-case-for-cwinrt"></a>C++/WinRT の場合
C++ プログラミング言語は、企業*と*アプリケーションの独立系ソフトウェア ベンダー (ISV) セグメントの両方で使用されています。これらでは、正確性、品質、パフォーマンスが高く評価されています。 たとえば、システム プログラミング、リソースが限られた埋め込みシステムやモバイル システム、ゲームやグラフィックス、デバイス ドライバー、工業用、科学技術用、医療用医療アプリケーションなどです。

言語の観点から見ると、C++ では、型が豊富で軽量な抽象化を常に作成および使用します。 ただし、RAW ポインター、RAW ループ、煩雑なメモリ割り当て、C++98 のリリース以降、言語は急激に変化しました。 最新の C++ (C++11 以降) は、アイデアの明確な表現、シンプルさ、読みやすさ、バグ発生の大幅な軽減が中心です。

C++ を使用して Windows ランタイム API を作成および使用する場合は、C++/WinRT を使用します。 これは、[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl?branch=live) と [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live) に代わる Microsoft の推奨です。

C++/WinRT を使用する場合は、標準的な C++ データ型、アルゴリズム、およびキーワードを使用します。 プロジェクションに独自のカスタム データ型はありませんが、多くの場合、標準型から適切に変換されるため、学習する必要はありません。 このため、使い慣れた標準的な C++ 言語機能と使用中のソース コードを使用し続けることができます。 C++/WinRT では、C++ アプリケーションで Windows ランタイム API を Win32 から UWP に非常に簡単に呼び出すことができます。

Windows ランタイムの他の言語オプションに比べて、C++/WinRT はパフォーマンスが向上し、小さなバイナリを生成します。 ABI インターフェイスを直接使用した手書きのコードよりも優れています。 このため、抽象化では、Visual C++ コンパイラが最適化するように設計されている最新の C++ イディオムを使用します。 これには、C++/WinRT のパフォーマンス向上に特化した最新の Visual C++ の多くの新しい最適化機能だけでなく、マジック static、空の基底クラス、**strlen** の省略も含まれます。

| トピック | 説明 |
| - | - |
| [C++/WinRT の概要](intro-to-using-cpp-with-winrt.md) | C++/WinRT の紹介 &mdash; Windows ランタイム API 用の標準的な C++ 言語プロジェクション。 |
| [よく寄せられる質問](faq.md) | C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。 |
| [トラブルシューティング](troubleshooting.md) | このトピックにある現象のトラブルシューティングおよび対処法に関する表は、新しいコードを作成しているか既存のアプリを移植しているかにはかかわらず役立つ可能性があります。 |
| [文字列の処理](strings.md) | C++/WinRT では、標準的な C++ ワイド文字列型を使用して Windows ランタイム API を呼び出すか、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) 型を使用することができます。 |
| [標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md) | C++/WinRT では、標準的な C++ データ型を使用して Windows ランタイム API を呼び出すことができます。 |
| [IInspectable へのスカラー値のボックス化とボックス化解除](boxing.md) | スカラー値は、**IInspectable** を想定している関数に渡す前に、参照クラス オブジェクト内にラップする必要があります。 このラッピング プロセスは、値の*ボックス化*と呼ばれます。 |
| [C++/WinRT での API の使用](consume-apis.md) | このトピックでは、C++/WinRT API を実装する Windows、サードパーティ コンポーネント ベンダー、またはユーザー自身に応じた使用方法について説明します。 |
| [C++/WinRT での API の作成](author-apis.md) | このトピックでは、直接的または間接的に **winrt::implements** 基本構造体を使用して、C++/WinRT API を作成する方法を示します。 |
| [デリゲートを使用したイベントの処理](handle-events.md) | このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。 |
| [イベントの作成](author-events.md) | このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。 |
| [同時実行操作と非同期操作](concurrency.md) | このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。 |
| [XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md) | XAML コントロールに効果的にバインドできるプロパティは、*監視可能な*プロパティと呼ばれます。 このトピックでは、監視可能なプロパティを実装および使用する方法と、XAML コントロールをバインドする方法を示します。 |
| [XAML アイテム コントロール: C++/WinRT コレクションへのバインド](binding-collection.md) | XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 このトピックでは、監視可能なコレクションを実装および使用する方法と、それに XAML アイテム コントロールをバインドする方法を示します。 |
| [C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md) | このトピックでは、[C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live) と C++/WinRT オブジェクト間の変換に使用できる 2 つのヘルパー関数について説明します。 |
| [C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md) | このトピックでは、アプリケーション バイナリ インターフェイス (ABI) と C++/WinRT オブジェクト間の変換方法について説明します。 |
| [弱参照](weak-references.md) | C++/WinRT の弱参照サポートは利用に応じた料金制度であるため、オブジェクトが [**IWeakReferenceSource**](https://msdn.microsoft.com/library/br224609) で照会されない限り、料金はかかりません。 |
| [アジャイル オブジェクト](agile-objects.md) | アジャイル オブジェクトは、いずれかのスレッドからアクセスできます。 お使いの C++/WinRT 型は既定ではアジャイルですが、オプトアウトできます。 |

## <a name="important-apis"></a>重要な API
* [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)
