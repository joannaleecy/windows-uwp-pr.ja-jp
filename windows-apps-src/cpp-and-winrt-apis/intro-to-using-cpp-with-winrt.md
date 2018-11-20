---
author: stevewhims
description: C++/WinRT の紹介 &mdash; Windows ランタイム API 用の標準的な C++ 言語プロジェクション。
title: C++/WinRT の概要
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 概要
ms.localizationpriority: medium
ms.openlocfilehash: 8b88eac972cd65b771827d7e3125476265cf671e
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7422160"
---
# <a name="introduction-to-cwinrt"></a>C++/WinRT の概要
&nbsp;
> [!VIDEO https://www.youtube.com/embed/nOFNc2uTmGs]

C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C++/WinRT の場合、標準に準拠した C++17 のコンパイラを使用して Windows ランタイム API を作成および使用できます。 Windows SDK には C++/WinRT が含まれます。バージョン 10.0.17134.0 (Windows 10、バージョン 1803) で導入されました。

C++/WinRT はマイクロソフトの推奨される代替、 [、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live)言語プロジェクションで、および[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl?branch=live)。 完全な一覧[C + に関するトピック/WinRT](index.md#topics-about-cwinrt)との相互運用の両方から、C++ の移植に関する情報を紹介 +/CX と WRL します。

> [!IMPORTANT]
> C++/WinRT の知っておくべき 2 つの最も重要な部分は、「[C++/WinRT の SDK サポート](#sdk-support-for-cwinrt)」と「[C++/WinRT の Visual Studio サポートと VSIX](#visual-studio-support-for-cwinrt-and-the-vsix)」のセクションで説明されています。

## <a name="language-projections"></a>言語プロジェクション
Windows ランタイムは、コンポーネント オブジェクト モデル (COM) API に基づいており、*言語プロジェクション*を使用してアクセスするよう設計されています。 プロジェクションは、COM の詳細を隠し、特定の言語により自然なプログラミング エクスペリエンスを提供します。

### <a name="the-cwinrt-language-projection-in-the-windows-uwp-api-reference-content"></a>Windows UWP API リファレンス コンテンツにおける C++/WinRT 言語プロジェクション
[Windows UWP API](https://docs.microsoft.com/uwp/api/) の閲覧中に、右上隅の **[言語] (Language)** コンボ ボックスをクリックして **[C++/WinRT]** を選択し、API 構文ブロックを C++/WinRT 言語プロジェクションで表示されるように表示します。

## <a name="sdk-support-for-cwinrt"></a>C++/WinRT の SDK サポート
バージョン 10.0.17134.0 (Windows 10 バージョン 1803) の時点で、Windows SDK には、ファーストパーティ Windows API (Windows 名前空間の Windows ランタイム API) を使用するためのヘッダー ファイル ベースの標準的な C++ ライブラリが含まれています。 C++/WinRT には `cppwinrt.exe` ツールも含まれています。このツールは Windows ランタイム メタデータ (`.winmd`) ファイルでポイントして、C++/WinRT コードから使用するためのメタデータに記述されている API を*投影する*ヘッダー ファイル ベースの標準的な C++ ライブラリを生成することができます。 Windows ランタイム メタデータ (`.winmd`) ファイルは、Windows ランタイム API サーフェスを記述する正規の方法を提供します。 メタデータで `cppwinrt.exe` をポイントすることで、セカンド パーティまたはサード パーティの Windows ランタイム コンポーネントに実装された、または独自のアプリケーションに実装された任意のランタイム クラスで使用するためのライブラリを生成することができます。 詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。

C++/WinRT では、COM スタイルのプログラミングを使用せずに、標準的な C++ を使用して独自のランタイム クラスを実装することもできます。 ランタイム クラスでは、IDL ファイルで型を記述するだけです。`midl.exe` および `cppwinrt.exe` が実装のスケルトン ソース コード ファイルを自動的に作成します。 または、C++/WinRT の基本クラスから派生することでインターフェイスを実装することもできます。 詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。

## <a name="visual-studio-support-for-cwinrt-and-the-vsix"></a>C++/WinRT の Visual Studio サポートと VSIX
Visual Studio の C++/WinRT プロジェクト テンプレート、および C++/WinRT MSBuild プロジェクト テンプレートの
プロパティとターゲットでは、[Visual Studio Marketplace](https://marketplace.visualstudio.com/) から [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) をダウンロードし、インストールします。

> [!NOTE]
> バージョン 1.0.181002.2 (またはそれ以降) 新しい: C++ の作成にインストールされると、VSIX の/WinRT プロジェクトは、そのプロジェクトの[Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)を自動的にインストールします。 Microsoft.Windows.CppWinRT NuGet パッケージを提供強化 C + + WinRT プロジェクト ビルドのサポート、開発コンピューターと (NuGet パッケージと、VSIX ではないがインストールされている)、ビルド エージェントの間で移植プロジェクトを作成します。
>
> 既存のプロジェクトの&mdash;1.0.181002.2 のバージョンをインストールした後 (またはそれ以降) の VSIX&mdash;Visual Studio でプロジェクトを開く場合は、**プロジェクト**をクリックすることをお勧めします \> **NuGet パッケージを管理する.** \> **参照**、入力または**Microsoft.Windows.CppWinRT**を検索ボックスに貼り付ける、検索結果、項目を選択して**インストール**をそのプロジェクトのパッケージをインストールする] をクリックします。

Visual Studio 2017 が必要があります (少なくとも必要がありますバージョン 15.6、お勧めします 15.7 以上)、および Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803)。 まだインストールして、Visual Studio インストーラー内から**C++ ユニバーサル Windows プラットフォーム ツール**のオプションをインストールする必要があります。 Windows の**設定**で > **Update \ & セキュリティ** > **開発者のため**、**アプリのサイドローディング**オプションではなく、**開発者モード**のオプションを選択します。

そのことができますを作成し、ビルド、または開くには、c++/WinRT Visual Studio でプロジェクトを作成し展開します。 追加することで、既存のプロジェクトを変換する代わりに、`<CppWinRTEnabled>true</CppWinRTEnabled>`プロパティをその`.vcxproj`ファイル。

```xml
<Project ...>
    <PropertyGroup Label="Globals">
        <CppWinRTEnabled>true</CppWinRTEnabled>
...
```

そのプロパティを追加すると、`cppwinrt.exe` ツールの呼び出しが含まれる、プロジェクトの C++/WinRT MSBuild サポートを取得できます。

C++/WinRT の c++ 17 標準から機能を使用して、プロジェクト プロパティ**C/C++** 必要がある > **言語** > **標準的な C++ 言語** > **ISO C 17 標準 (//std:c では 17)** します。 **Conformance mode: Yes (/permissive-)** を設定することもあるかもしれません。これはコードを標準に準拠するようにさらに制限します。

注意すべきもう 1 つのプロジェクト プロパティは、**[C/C++]** > **[全般]** > **[警告をエラーとして扱う]** です。 これをユーザーの好みに合わせて **[はい (/WX)]** または **[いいえ (/WX-)]** に設定します。 場合によっては、`cppwinrt.exe` ツールによって生成されたソース ファイルは、それらに実装を追加するまで警告を生成します。

また、VSIX は、C++/WinRT の投影された型の Visual Studio ネイティブのデバッグの視覚化 (NatVis) を提供し、C# デバッグと同様のエクスペリエンスを実現します。 Natvis はデバッグ ビルドで自動で行われます。 シンボル WINRT_NATVIS を定義することで、リリース ビルドを選択できます。

VSIX によって提供される Visual Studio プロジェクト テンプレートを次に示します。

### <a name="windows-console-application-cwinrt"></a>Windows コンソール アプリケーション (C++/WinRT)
コンソールのユーザー インターフェイスを含む、Windows デスクトップの C++/WinRT クライアント アプリケーションのプロジェクト テンプレートです。

### <a name="blank-app-cwinrt"></a>空のアプリ (C++/WinRT)
XAML ユーザー インターフェイスを持つユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

Visual Studio では、各 XAML マークアップ ファイルの背後にあるインターフェイス定義言語 (IDL) (`.idl`) ファイルから実装とヘッダーのスタブを生成するために XAML コンパイラ サポートを提供します。 IDL ファイルで、アプリの XAML ページ内で参照する任意のローカルのランタイム クラスを定義してから、プロジェクトを 1 回ビルドして `Generated Files` で実装テンプレート、`Generated Files\sources` でスタブ型定義を生成します。 次にローカルのランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

### <a name="core-app-cwinrt"></a>コア アプリ (C++/WinRT)
XAML を使用しないユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

代わりに、Windows.ApplicationModel.Core 名前空間に C++/WinRT Windows 名前空間ヘッダーを使用します。 ビルドおよび実行した後に、空の領域をクリックして色付きの正方形を追加し、色付きの正方形をクリックしてそれをドラッグします。

### <a name="windows-runtime-component-cwinrt"></a>Windows ランタイム コンポーネント (C++/WinRT)
通常はユニバーサル Windows プラットフォーム (UWP) から使用するための、コンポーネントのプロジェクト テンプレートです。

このテンプレートは、Windows ランタイム メタデータ (`.winmd`) が IDL から生成され、実装とヘッダーのスタブが Windows ランタイム メタデータから生成される、`midl.exe` > `cppwinrt.exe` ツール チェーンを示します。

IDL ファイルでは、コンポーネント、それらの既定インターフェイス、およびそれらが実装している他のすべてのインターフェイスのランタイム クラスを定義します。 プロジェクトを 1 回ビルドして `module.g.cpp`、`module.h.cpp`、`Generated Files` の実装テンプレート、および `Generated Files\sources` のスタブ型定義を生成します。 次にコンポーネント内のランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

ビルドした Windows ランタイム コンポーネントのバイナリとその `.winmd` を、それらを使用する UWP アプリとバンドルします。

## <a name="custom-types-in-the-cwinrt-projection"></a>C++/WinRT プロジェクションにおけるカスタム型
C++//winrt プログラミングでは、標準的な C++ 言語機能を使用して[標準的な C++ データ型と C++/WinRT](std-cpp-data-types.md)&mdash;一部の C++ 標準ライブラリのデータ型を含みます。 ただし、プロジェクションでいくつかのカスタム データ型を認識するようになり、それらを使用することもできます。 たとえば、[C++/WinRT の概要](get-started.md) のクイックスタートのコード例では [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を使用しています。

[**winrt::com_array**](/uwp/cpp-ref-for-winrt/com-array) は、あるポイントで使用する可能性が高い別の型です。 ただし、[**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) などの型を直接使用する可能性は低いです。 または、対応する型が C++ 標準ライブラリに現れた場合に変更すべきコードがないように、使用しないことを選択する場合もあります。

> [!WARNING]
> C++/WinRT Windows 名前空間ヘッダーをよく調査すると見つかる可能性がある型もあります。 例として **winrt::param::hstring** がありますが、コレクションの例もあります。 これらは入力パラメーターのバインディングを最適化するためにのみ存在し、大幅に改善したパフォーマンスをもたらし、関連する標準的な C++ の型とコンテナーでほとんどの呼び出しパターンが "そのまま機能する" ようにします。 これらの型は、ほとんどの値を追加する場合にプロジェクションでのみ使用されます。 高度に最適化され、一般的な用途で使用するものではありません。それらの型を自分で使用しないようにしてください。 また、`winrt::impl` 名前空間からは何も使用しないでください。それらは実装型であるため、変更されることがあります。 引き続き標準型を使用するか、または [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)の型を使用する必要があります。

## <a name="important-apis"></a>重要な API
* [winrt::hstring 構造体](/uwp/cpp-ref-for-winrt/hstring)
* [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)
* [C++/WinRT の概要](get-started.md)
* [標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md)
* [C++/WinRT での文字列の処理](strings.md)
* [Windows UWP API](https://docs.microsoft.com/uwp/api/)
