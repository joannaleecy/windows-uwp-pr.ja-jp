---
author: stevewhims
description: C++/WinRT は、ヘッダー ファイル ベースのライブラリとして実装された、Windows ランタイム (WinRT) API 用に完全に標準化された最新の C++17 言語プロジェクションです。
title: C++/WinRT
ms.author: stwhi
ms.date: 05/14/2018
ms.topic: article
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション
ms.localizationpriority: medium
ms.openlocfilehash: 9f711ebc8d0d2e8dda87355a7894c9d311c6bbc2
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5947643"
---
# <a name="cwinrt"></a>C++/WinRT

[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) 、完全に標準化された最新の c++ 17 言語プロジェクションで Windows ランタイム (WinRT) Api では、ヘッダー ファイル ベースのライブラリとして実装は、最新の Windows API への最上位アクセスを提供するように設計します。 C++/WinRT の場合、標準に準拠した C++17 のコンパイラを使用して Windows ランタイム API を作成および使用できます。 Windows SDK には C++/WinRT が含まれます。バージョン 10.0.17134.0 (Windows 10、バージョン 1803) で導入されました。

C++/WinRT は、Windows 用の美しく高速なコードの作成に興味のある開発者向けです。 次に、その理由を示します。

## <a name="the-case-for-cwinrt"></a>C++/WinRT の場合
&nbsp;
> [!VIDEO https://www.youtube.com/embed/TLSul1XxppA]

C++ プログラミング言語は、企業*と*アプリケーションの独立系ソフトウェア ベンダー (ISV) セグメントの両方で使用されています。これらでは、正確性、品質、パフォーマンスが高く評価されています。 たとえば、システム プログラミング、リソースが限られた埋め込みシステムやモバイル システム、ゲームやグラフィックス、デバイス ドライバー、工業用、科学技術用、医療用医療アプリケーションなどです。

言語の観点から見ると、C++ では、型が豊富で軽量な抽象化を常に作成および使用します。 ただし、RAW ポインター、RAW ループ、煩雑なメモリ割り当て、C++98 のリリース以降、言語は急激に変化しました。 最新の C++ (C++11 以降) は、アイデアの明確な表現、シンプルさ、読みやすさ、バグ発生の大幅な軽減が中心です。

C++ を使用して Windows ランタイム API を作成および使用する場合は、C++/WinRT を使用します。 これは、マイクロソフトの推奨される代替、 [、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live)言語プロジェクションで、および[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl?branch=live)。

C++/WinRT を使用する場合は、標準的な C++ データ型、アルゴリズム、およびキーワードを使用します。 プロジェクションに独自のカスタム データ型はありませんが、多くの場合、標準型から適切に変換されるため、学習する必要はありません。 このため、使い慣れた標準的な C++ 言語機能と使用中のソース コードを使用し続けることができます。 C++/WinRT では、C++ アプリケーションで Windows ランタイム API を Win32 から UWP に非常に簡単に呼び出すことができます。

Windows ランタイムの他の言語オプションに比べて、C++/WinRT はパフォーマンスが向上し、小さなバイナリを生成します。 ABI インターフェイスを直接使用した手書きのコードよりも優れています。 このため、抽象化では、Visual C++ コンパイラが最適化するように設計されている最新の C++ イディオムを使用します。 これには、C++/WinRT のパフォーマンス向上に特化した最新の Visual C++ の多くの新しい最適化機能だけでなく、マジック static、空の基底クラス、**strlen** の省略も含まれます。

### <a name="topics-about-cwinrt"></a>トピックについては、C++/WinRT

| トピック | 説明 |
| - | - |
| [C++/WinRT の概要](intro-to-using-cpp-with-winrt.md) | C++/WinRT の紹介 &mdash; Windows ランタイム API 用の標準的な C++ 言語プロジェクション。 |
| [C++/WinRT の概要](get-started.md) | C++/WinRT の使用をすぐに開始できるように、このトピックでは、単純なコード例について説明します。 |
| [新機能、C++/WinRT](news.md) | ニュースや変更を C++/WinRT します。 |
| [よく寄せられる質問](faq.md) | C++/WinRT での Windows ランタイム API の作成と使用に関する質問への回答です。 |
| [トラブルシューティング](troubleshooting.md) | このトピックにある現象のトラブルシューティングおよび対処法に関する表は、新しいコードを作成しているか既存のアプリを移植しているかにはかかわらず役立つ可能性があります。 |
| [フォト エディター C++/WinRT サンプル アプリケーション](photo-editor-sample.md) | フォト エディターは、C++/WinRT 言語プロジェクションでの開発を紹介する UWP のサンプル アプリケーションです。 サンプル アプリケーションを使用すると、**画像**ライブラリから写真を取得し、関連する写真効果で選択したイメージを編集できます。 | 
| [文字列の処理](strings.md) | C++/WinRT では、標準的な C++ ワイド文字列型を使用して Windows ランタイム API を呼び出すか、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) 型を使用することができます。 |
| [標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md) | C++/WinRT では、標準的な C++ データ型を使用して Windows ランタイム API を呼び出すことができます。 |
| [IInspectable へのスカラー値のボックス化とボックス化解除](boxing.md) | スカラー値は、**IInspectable** を想定している関数に渡す前に、参照クラス オブジェクト内にラップする必要があります。 このラッピング プロセスは、値の*ボックス化*と呼ばれます。 |
| [C++/WinRT での API の使用](consume-apis.md) | このトピックでは、C++/WinRT API を実装する Windows、サードパーティ コンポーネント ベンダー、またはユーザー自身に応じた使用方法について説明します。 |
| [C++/WinRT での API の作成](author-apis.md) | このトピックでは、直接的または間接的に **winrt::implements** 基本構造体を使用して、C++/WinRT API を作成する方法を示します。 |
| [C++/WinRT でのエラー処理](error-handling.md) | このトピックでは、C++/WinRT でのプログラミング時にエラーを処理するための方法について説明します。 |
| [デリゲートを使用したイベントの処理](handle-events.md) | このトピックでは、C++/WinRT を使用したイベント処理デリゲートの登録方法と取り消し方法について説明します。 |
| [イベントの作成](author-events.md) | このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。 |
| [C++/WinRT でのコレクション](collections.md) | C++/WinRT 機能と、多くの時間と労力を実装やコレクションに合格するときに保存する基底クラスを提供します。 |
| [同時実行操作と非同期操作](concurrency.md) | このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。 |
| [XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md) | XAML コントロールに効果的にバインドできるプロパティは、*監視可能な*プロパティと呼ばれます。 このトピックでは、監視可能なプロパティを実装および使用する方法と、XAML コントロールをバインドする方法を示します。 |
| [XAML アイテム コントロール: C++/WinRT コレクションへのバインド](binding-collection.md) | XAML アイテム コントロールに効果的にバインドできるコレクションは、*監視可能な*コレクションと呼ばれます。 このトピックでは、監視可能なコレクションを実装および使用する方法と、それに XAML アイテム コントロールをバインドする方法を示します。 |
| [C++/WinRT による XAML カスタム (テンプレート化) コントロール](xaml-cust-ctrl.md) | このトピックでは、C++ を使用して、単純なカスタム コントロールを作成する手順について/WinRT します。 次に、独自の機能が豊富でカスタマイズ可能な UI コントロールを作成する情報に基づいて構築できます。 |
| [C++/WinRT での COM コンポーネントの使用](consume-com.md) | このトピックでは、Direct2D の完全なコード例を使用して、C++ を使用する方法を示して/WinRT COM クラスとインターフェイスを利用します。 |
| [C++/WinRT での COM コンポーネントの作成](author-coclasses.md) | C++/WinRT に役立つ従来の COM コンポーネントを作成する Windows ランタイム クラスを作成することもでき、同様です。 |
| [C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md) | このトピックでは、C++/CX コードを C++/WinRT の同等のコードに移植する方法について説明します。 |
| [C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md) | このトピックでは、[C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live) と C++/WinRT オブジェクト間の変換に使用できる 2 つのヘルパー関数について説明します。 |
| [WRL から C++/WinRT への移行](move-to-winrt-from-wrl.md) | このトピックでは、[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) のコードを C++/WinRT の同等のコードに移植する方法について説明します。 |
| [C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md) | このトピックでは、アプリケーション バイナリ インターフェイス (ABI) と C++/WinRT オブジェクト間の変換方法について説明します。 |
| [C++ し、強固で弱参照/WinRT](weak-references.md) | Windows ランタイムは、参照カウントで管理されるシステムです。知っておくは、重要性とを区別する重要なシステムで強力なと弱参照します。 |
| [アジャイル オブジェクト](agile-objects.md) | アジャイル オブジェクトは、いずれかのスレッドからアクセスできます。 お使いの C++/WinRT 型は既定ではアジャイルですが、オプトアウトできます。 |

### <a name="topics-about-the-c-language"></a>C++ 言語についてのトピック

| トピック | 説明 |
| - | - |
| [値のカテゴリとへの参照](cpp-value-categories.md) | このトピックでは、C++ で存在する値のさまざまなカテゴリについて説明します。 左辺値と rvalue の音が間違いが、その他の種類すぎます。 |

## <a name="important-apis"></a>重要な API
* [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl)
