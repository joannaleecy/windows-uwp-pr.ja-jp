---
author: stevewhims
description: C++/WinRT の紹介 &mdash; Windows ランタイム API 用の標準的な C++ 言語プロジェクション。
title: C++/WinRT の概要
ms.author: stwhi
ms.date: 05/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション
ms.localizationpriority: medium
ms.openlocfilehash: 968afd6fdad1e7bf6b3c38d929ab79eefa71819a
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832326"
---
# <a name="introduction-to-cwinrt"></a>C++/WinRT の概要
> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

バージョン 10.0.17134.0 (Windows 10、バージョン 1803) に導入されたため、Windows SDK に C++/WinRT が含まれるようになりました。

> [!IMPORTANT]
> C++/WinRT の知っておくべき最も重要な部分は、「[C++/WinRT の SDK](#sdk-support-for-cwinrt)」と「[C++/WinRT の Visual Studio サポートと VSIX](#visual-studio-support-for-cwinrt-and-the-vsix)」のセクションで説明されています。

C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイルに単独で実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C++/WinRT の場合、標準に準拠した C++17 のコンパイラを使用して Windows ランタイム API を作成および使用できます。

## <a name="language-projections"></a>言語プロジェクション
Windows ランタイムは、コンポーネント オブジェクト モデル (COM) API に基づいており、*言語プロジェクション*を使用してアクセスするよう設計されています。 プロジェクションは、COM の詳細を隠し、特定の言語により自然なプログラミング エクスペリエンスを提供します。

### <a name="the-cwinrt-language-projection-in-the-windows-uwp-api-reference-content"></a>Windows UWP API リファレンス コンテンツにおける C++/WinRT 言語プロジェクション
[Windows UWP API](https://docs.microsoft.com/uwp/api/) の閲覧中に、右上隅の **[言語] (Language)** コンボ ボックスをクリックして **[C++/WinRT]** を選択し、API 構文ブロックを C++/WinRT 言語プロジェクションで表示されるように表示します。

## <a name="sdk-support-for-cwinrt"></a>C++/WinRT の SDK サポート
バージョン 10.0.17134.0 (Windows 10、バージョン 1803) の時点で Windows SDK には C++/WinRT プロジェクション Windows 名前空間のヘッダーとツールが含まれています。 1 つの重要なツールは `cppwinrt.exe` で、これは `.winmd` から、メタデータを C++/WinRT 内に投影するソース コード ファイルを生成します。 Windows ランタイム メタデータ (`.winmd`) ファイルは、Windows ランタイム API サーフェスを記述する正規の方法を提供します。 `cppwinrt.exe` は、Windows ランタイム メタデータから、Windows API であっても、またはサード パーティ製の Windows ランタイム コンポーネント API であっても、API サーフェスを完全に記述する (*投影する*) 標準の C++ ライブラリを生成します。 `Cppwinrt.exe` ファーストパーティおよびサードパーティの API のどちらの使用にも、また独自の API コンポーネントを作成するために、開発ワークフローにおいて重要な役割を果たします。

## <a name="visual-studio-support-for-cwinrt-and-the-vsix"></a>C++/WinRT の Visual Studio サポートと VSIX
Visual Studio の C++/WinRT プロジェクト テンプレート、および C++/WinRT MSBuild プロジェクト テンプレートの
プロパティとターゲットでは、[Visual Studio Marketplace](https://marketplace.visualstudio.com/) から [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) をダウンロードし、インストールします。

Visual Studio 2017 バージョン 15.6、またはそれ以降、および Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) が必要になります。 Visual Studio で新しいプロジェクトを作成、または、`<CppWinRTProject>true</CppWinRTProject>` プロパティを [プロジェクト] > [プロパティグループ] 内のその `.vcxproj` ファイルに追加することで既存のプロジェクトを変換することができます。 そのプロパティを追加すると、`cppwinrt.exe` ツールの呼び出しが含まれる、プロジェクトの C++/WinRT MSBuild サポートを取得できます。

C++/WinRT では C++17 標準から機能するので、プロジェクト プロパティ **[C/C++]** > **[言語]** > **[ISO C++17 標準 (/std:c++17)]** が必要です。 **Conformance mode: Yes (/permissive-)** を設定することもあるかもしれません。これはコードを標準に準拠するようにさらに制限します。

注意すべきもう 1 つのプロジェクト プロパティは、**[C/C++]** > **[全般]** > **[警告をエラーとして扱う]** です。 これをユーザーの好みに合わせて **[はい (/WX)]** または **[いいえ (/WX-)]** に設定します。 場合によっては、`cppwinrt.exe` ツールによって生成されたソース ファイルは、それらに実装を追加するまで警告を生成します。

これらは、VSIX によって提供される Visual Studio プロジェクト テンプレートです。

### <a name="windows-console-application-cwinrt"></a>Windows コンソール アプリケーション (C++/WinRT)
コンソールのユーザー インターフェイスを含む、Windows デスクトップの C++/WinRT クライアント アプリケーションのプロジェクト テンプレートです。

### <a name="blank-app-cwinrt"></a>空のアプリ (C++/WinRT)
XAML ユーザー インターフェイスを持つユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

Visual Studio では、各 XAML マークアップ ファイルの背後にあるインターフェイス定義言語 (IDL) (`.idl`) ファイルから実装とヘッダーのスタブを生成するために XAML コンパイラ サポートを提供します。 IDL ファイルで、アプリの XAML ページ内で参照する任意のローカルのランタイム クラスを定義してから、プロジェクトを 1 回ビルドして `Generated Files` で実装テンプレート、`Generated Files\sources` でスタブ型定義を生成します。 次にローカルのランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

### <a name="core-app-cwinrt"></a>コア アプリ (C++/WinRT)
XAML を使用しないユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

代わりに、Windows.ApplicationModel.Core 名前空間に C++/WinRT プロジェクション Windows 名前空間ヘッダーを使用します。 ビルドおよび実行した後に、空の領域をクリックして色付きの正方形を追加し、色付きの正方形をクリックしてそれをドラッグします。

### <a name="windows-runtime-component-cwinrt"></a>Windows ランタイム コンポーネント (C++/WinRT)
通常はユニバーサル Windows プラットフォーム (UWP) から使用するための、コンポーネントのプロジェクト テンプレートです。

このテンプレートは、Windows ランタイム メタデータ (`.winmd`) が IDL から生成され、実装とヘッダーのスタブが Windows ランタイム メタデータから生成される、`midl.exe` > `cppwinrt.exe` ツール チェーンを示します。

IDL ファイルでは、コンポーネント、それらの既定インターフェイス、およびそれらが実装している他のすべてのインターフェイスのランタイム クラスを定義します。 プロジェクトを 1 回ビルドして `module.g.cpp`、`module.h.cpp`、`Generated Files` の実装テンプレート、および `Generated Files\sources` のスタブ型定義を生成します。 次にコンポーネント内のランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

ビルドした Windows ランタイム コンポーネントのバイナリとその `.winmd` を、それらを使用する UWP アプリとバンドルします。

## <a name="a-cwinrt-quick-start"></a>C++/WinRT のクイックスタート
新しい**Windows コンソール アプリケーション (C++/WinRT)** プロジェクトを作成します。 `main.cpp` を次のように編集します。

```cppwinrt
// main.cpp

#include "pch.h"
#include <iostream>
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

int main()
{
    winrt::init_apartment();

    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;
    SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
    for (const SyndicationItem syndicationItem : syndicationFeed.Items())
    {
        hstring titleAsHstring = syndicationItem.Title().Text();
        std::wcout << titleAsHstring.c_str() << std::endl;
    }
}
```

インクルードするヘッダー `winrt/Windows.Foundation.h` および `winrt/Windows.Web.Syndication.h` は SDK に含まれるもので、フォルダー `%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt\` 内にあります。 Visual Studio には、その *IncludePath* マクロにそのパスが含まれています。 このヘッダーには、C++/WinRT に投影された Windows API が含まれます。 Windows 名前空間から型を使用する場合は常に、このように対応する C++/WinRT プロジェクション Windows 名前空間ヘッダーを含めます。 `using namespace` ディレクティブはオプションですが、便利です。

投影されたすべての型は C++/WinRT ルート名前空間 **winrt** にあります。 [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) と Windows SDK の両方で、ルート名前空間 **Windows** で型を宣言します。 これらの異なる名前空間では、独自のペースで C++/CX から C++/WinRT へ移行できます。

[**SyndicationClient::RetrieveFeedAsync**](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、非同期 Windows ランタイム関数の例です。 コード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、呼び出しスレッドをブロックし、その結果を待機するように、このオブジェクトで **get** を呼び出します。 同時実行、および非ブロッキングの手法の詳細については、「[C++/WinRT での同時実行と非同期操作](concurrency.md)」を参照してください。

[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) は、**begin** および **end** 関数 (またはそれらの定数、逆、および定数逆バリアント) から返される反復子によって定義される範囲です。 このため、範囲ベースの `for` ステートメント、または **std::for_each** テンプレート関数とともに **Items** を列挙できます。

次にコードがフィードのタイトル テキストを、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) オブジェクトとして取得します (「[C++/WinRT での文字列処理](strings.md)」を参照してください)。 次に **c_str** 経由で **Hstring** が出力されます。これは、C++ 標準ライブラリから文字列を使用している場合は見覚えがあるでしょう。

おわかりのように、C++/WinRT では、`syndicationItem.Title().Text()` などの、最新のクラスのような C++ の式を奨励しています。 これは、従来の COM プログラミングとは異なる、よりクリーンなプログラミング スタイルです。 COM を明示的に初期化したり (**winrt::init_apartment** が代わりに行います)、COM ポインターを使用したり、HRESULT リターン コードを処理したりする必要はありません。 C++/WinRT では、エラーの HRESULT を自然かつ最新のプログラミング スタイルの例外に変換します。

## <a name="custom-types-in-the-cwinrt-projection"></a>C++/WinRT プロジェクションにおけるカスタム型
標準 C++ 言語機能および[標準 C++ データ型と C++/WinRT](std-cpp-data-types.md) (一部の C++ 標準ライブラリのデータ型を含む) を C++/WinRT プログラミングで使用できます。 ただし、プロジェクションでいくつかのカスタム データ型を認識するようになり、それらを使用することもできます。 たとえば、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を上記のクイック スタートで使用しました。

[**winrt::com_array**](/uwp/cpp-ref-for-winrt/com-array) は、あるポイントで使用する可能性が高い別の型です。 ただし、[**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) などの型を直接使用する可能性は低いです。 または、対応する型が C++ 標準ライブラリに現れた場合に変更すべきコードがないように、使用しないことを選択する場合もあります。

C++/WinRT プロジェクション Windows 名前空間ヘッダーをよく調査すると見つかる可能性がある型もあります。 例として、**winrt::param::hstring** があります。 これらは、効率化のためにのみ存在し、コードで使用する必要はありません。

## <a name="important-apis"></a>重要な API
* [SyndicationClient::RetrieveFeedAsync](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [SyndicationFeed.Items](/uwp/api/windows.web.syndication.syndicationfeed.items)
* [winrt::hstring 構造体](/uwp/cpp-ref-for-winrt/hstring)
* [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [C++/WinRT での文字列の処理](strings.md)
* [Visual Studio Marketplace](https://marketplace.visualstudio.com/)
* [Windows UWP API](https://docs.microsoft.com/uwp/api/)
