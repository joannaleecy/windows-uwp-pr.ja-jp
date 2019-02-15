---
description: C++/WinRT の紹介 &mdash; Windows ランタイム API 用の標準的な C++ 言語プロジェクション。
title: C++/WinRT の概要
ms.date: 01/31/2019
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 概要
ms.localizationpriority: medium
ms.openlocfilehash: 883463f291864016ebc32f2d510936452c931366
ms.sourcegitcommit: fde2d41ef4b5658785723359a8c4b856beae8f95
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/15/2019
ms.locfileid: "9079220"
---
# <a name="introduction-to-cwinrt"></a>C++/WinRT の概要
&nbsp;
> [!VIDEO https://www.youtube.com/embed/nOFNc2uTmGs]

C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C++/WinRT の場合、標準に準拠した C++17 のコンパイラを使用して Windows ランタイム API を作成および使用できます。 Windows SDK には C++/WinRT が含まれます。バージョン 10.0.17134.0 (Windows 10、バージョン 1803) で導入されました。

C++/WinRT はマイクロソフトの推奨される代替、 [、C++/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live)言語プロジェクションで、および[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl?branch=live)。 完全な一覧[C + に関するトピック/WinRT](index.md#topics-about-cwinrt)との相互運用の両方から、C++ の移植に関する情報を紹介 +/CX と WRL します。

> [!IMPORTANT]
> 2 つの最も重要な部分 C + + 注意すべき WinRT は」のセクションで説明されています[C + の SDK サポート/WinRT](#sdk-support-for-cwinrt)と[、C++、Visual Studio サポート/WinRT、XAML では、VSIX 拡張機能と、NuGet パッケージ](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

## <a name="language-projections"></a>言語プロジェクション
Windows ランタイムは、コンポーネント オブジェクト モデル (COM) API に基づいており、*言語プロジェクション*を使用してアクセスするよう設計されています。 プロジェクションは、COM の詳細を隠し、特定の言語により自然なプログラミング エクスペリエンスを提供します。

### <a name="the-cwinrt-language-projection-in-the-windows-uwp-api-reference-content"></a>Windows UWP API リファレンス コンテンツにおける C++/WinRT 言語プロジェクション
[Windows UWP API](https://docs.microsoft.com/uwp/api/) の閲覧中に、右上隅の **[言語] (Language)** コンボ ボックスをクリックして **[C++/WinRT]** を選択し、API 構文ブロックを C++/WinRT 言語プロジェクションで表示されるように表示します。

## <a name="sdk-support-for-cwinrt"></a>C++/WinRT の SDK サポート
バージョン 10.0.17134.0 (Windows 10 バージョン 1803) の時点で、Windows SDK には、ファーストパーティ Windows API (Windows 名前空間の Windows ランタイム API) を使用するためのヘッダー ファイル ベースの標準的な C++ ライブラリが含まれています。 C++/WinRT には `cppwinrt.exe` ツールも含まれています。このツールは Windows ランタイム メタデータ (`.winmd`) ファイルでポイントして、C++/WinRT コードから使用するためのメタデータに記述されている API を*投影する*ヘッダー ファイル ベースの標準的な C++ ライブラリを生成することができます。 Windows ランタイム メタデータ (`.winmd`) ファイルは、Windows ランタイム API サーフェスを記述する正規の方法を提供します。 メタデータで `cppwinrt.exe` をポイントすることで、セカンド パーティまたはサード パーティの Windows ランタイム コンポーネントに実装された、または独自のアプリケーションに実装された任意のランタイム クラスで使用するためのライブラリを生成することができます。 詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。

C++/WinRT では、COM スタイルのプログラミングを使用せずに、標準的な C++ を使用して独自のランタイム クラスを実装することもできます。 ランタイム クラスでは、IDL ファイルで型を記述するだけです。`midl.exe` および `cppwinrt.exe` が実装のスケルトン ソース コード ファイルを自動的に作成します。 または、C++/WinRT の基本クラスから派生することでインターフェイスを実装することもできます。 詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。

## <a name="visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package"></a>Visual Studio のサポート、C++/WinRT、XAML では、VSIX 拡張機能と、NuGet パッケージ
Visual Studio にサポートするだけでなく、最小の Windows SDK ターゲット バージョン 10.0.17134.0 (Windows 10、バージョン 1803) の必要があります Visual Studio 2017 (少なくともバージョン 15.6 以上、15.7 をお勧めします)、または Visual Studio 2019 します。 まだインストールして、Visual Studio インストーラー内から**C++ ユニバーサル Windows プラットフォーム ツール**のオプションをインストールする必要があります。 Windows の**設定**で > **\& セキュリティを更新** > **開発者のため**、**アプリのサイドローディング**オプションではなく、**開発者モード**のオプションを選択します。

ダウンロードおよびの最新バージョンをインストールする必要があります、 [、C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix) [Visual Studio Marketplace](https://marketplace.visualstudio.com/)からです。

- VSIX 拡張機能を提供するには、C++/WinRT プロジェクト テンプレートと項目テンプレート、Visual Studio で、C++ を開始できるように/WinRT 開発します。
- さらに、することにより、Visual Studio ネイティブのデバッグの視覚化 (natvis) の C + +/winrt の投影された型です。c# デバッグと同様、エクスペリエンスを提供します。 Natvis はデバッグ ビルドで自動で行われます。 シンボル WINRT_NATVIS を定義することで、リリース ビルドを選択できます。

Visual Studio のプロジェクト テンプレートの C + + WinRT について以下に説明します。 作成した場合、新しい C + + WinRT プロジェクト、VSIX は、インストールされると、拡張機能、新しい C + の最新バージョンを/WinRT プロジェクトが自動的に[Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をインストールします。 **Microsoft.Windows.CppWinRT** NuGet パッケージを提供 C + + WinRT ビルド (MSBuild プロパティとターゲット) をサポート開発コンピューターと、ビルド エージェントの間で移植プロジェクトを作成 (にのみ、NuGet パッケージと VSIX 拡張子ではなく、インストールされます)。

> [!IMPORTANT]
> 作成した (またはアップグレードを扱う) されているプロジェクトがある場合、VSIX 拡張機能の以前のバージョン 1.0.190128.4 よりが表示[VSIX 拡張機能の以前のバージョン](#earlier-versions-of-the-vsix-extension)。 そのセクションには、アップグレード、VSIX 拡張機能の最新バージョンを使用することを知っている必要がありますプロジェクトの構成に関する重要な情報が含まれています。

C++/WinRT の c++ 17 標準から機能を使用して、プロジェクト プロパティ**C/C++** 必要がある > **言語** > **標準的な C++ 言語** > **ISO C 17 標準 (//std:c では 17)** します。 **Conformance mode: Yes (/permissive-)** を設定することもあるかもしれません。これはコードを標準に準拠するようにさらに制限します。

注意すべきもう 1 つのプロジェクト プロパティは、**[C/C++]** > **[全般]** > **[警告をエラーとして扱う]** です。 これをユーザーの好みに合わせて **[はい (/WX)]** または **[いいえ (/WX-)]** に設定します。 場合によっては、`cppwinrt.exe` ツールによって生成されたソース ファイルは、それらに実装を追加するまで警告を生成します。

前述のように最大設定、システムにすることができますを作成し、ビルド、または開くには、c++/WinRT Visual Studio でプロジェクトを作成し展開します。

または、 **Microsoft.Windows.CppWinRT** NuGet パッケージを手動でインストールすることによって既存のプロジェクトを変換することができます。 後のインストール (または更新する)、VSIX 拡張機能の最新バージョン Visual Studio で、既存のプロジェクトを開き、[**プロジェクト** \> **NuGet パッケージを管理する.** \> **参照**、入力または**Microsoft.Windows.CppWinRT**を検索ボックスに貼り付ける、検索結果の項目を選択して**インストール**をそのプロジェクトのパッケージをインストールする] をクリックします。 パッケージを追加すると表示されます C + + 呼び出しが含まれる、プロジェクトの/winrt MSBuild サポート、`cppwinrt.exe`ツールです。

C++ を使用するプロジェクトを識別する/ **Microsoft.Windows.CppWinRT** NuGet パッケージをプロジェクト内でインストールの有無を/winrt MSBuild サポートします。

VSIX 拡張機能によって提供される Visual Studio プロジェクト テンプレートを次に示します。

### <a name="windows-console-application-cwinrt"></a>Windows コンソール アプリケーション (C++/WinRT)
コンソールのユーザー インターフェイスを含む、Windows デスクトップの C++/WinRT クライアント アプリケーションのプロジェクト テンプレートです。

### <a name="blank-app-cwinrt"></a>空のアプリ (C++/WinRT)
XAML ユーザー インターフェイスを持つユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

Visual Studio では、各 XAML マークアップ ファイルの背後にあるインターフェイス定義言語 (IDL) (`.idl`) ファイルから実装とヘッダーのスタブを生成するために XAML コンパイラ サポートを提供します。 IDL ファイルで、アプリの XAML ページ内で参照する任意のローカルのランタイム クラスを定義してから、プロジェクトを 1 回ビルドして `Generated Files` で実装テンプレート、`Generated Files\sources` でスタブ型定義を生成します。 次にローカルのランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

C++ には、XAML デザイン サーフェイスのサポートを visual Studio の/WinRT は、c# と同等の近くです。 **[プロパティ**] ウィンドウの [**イベント**] タブは例外です。 C# プロジェクトをイベント ハンドラーを追加するのにその] タブを使用することができます。c++/WinRT プロジェクトでは、その機能が存在しません。 表示が[C + でデリゲートを使用してイベントを処理/WinRT](handle-events.md)コードにイベント ハンドラーを追加する方法について詳しくはします。

### <a name="core-app-cwinrt"></a>コア アプリ (C++/WinRT)
XAML を使用しないユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

代わりに、Windows.ApplicationModel.Core 名前空間に C++/WinRT Windows 名前空間ヘッダーを使用します。 ビルドおよび実行した後に、空の領域をクリックして色付きの正方形を追加し、色付きの正方形をクリックしてそれをドラッグします。

### <a name="windows-runtime-component-cwinrt"></a>Windows ランタイム コンポーネント (C++/WinRT)
通常はユニバーサル Windows プラットフォーム (UWP) から使用するための、コンポーネントのプロジェクト テンプレートです。

このテンプレートは、Windows ランタイム メタデータ (`.winmd`) が IDL から生成され、実装とヘッダーのスタブが Windows ランタイム メタデータから生成される、`midl.exe` > `cppwinrt.exe` ツール チェーンを示します。

IDL ファイルでは、コンポーネント、それらの既定インターフェイス、およびそれらが実装している他のすべてのインターフェイスのランタイム クラスを定義します。 プロジェクトを 1 回ビルドして `module.g.cpp`、`module.h.cpp`、`Generated Files` の実装テンプレート、および `Generated Files\sources` のスタブ型定義を生成します。 次にコンポーネント内のランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

ビルドした Windows ランタイム コンポーネントのバイナリとその `.winmd` を、それらを使用する UWP アプリとバンドルします。

## <a name="earlier-versions-of-the-vsix-extension"></a>VSIX 拡張機能の以前のバージョン
インストールすることをお勧めします (または更新) [VSIX 拡張機能](https://aka.ms/cppwinrt/vsix)の最新バージョンです。 既定ではそれ自体を更新することが構成されます。 VSIX 拡張 1.0.190128.4、し、このセクションでより前のバージョンで作成されたプロジェクトを使用して、その場合は、新しいバージョンで動作するには、そのプロジェクトのアップグレードに関する重要な情報が含まれています。 更新しない場合、引き続き情報このセクションで役に立ちます。

Windows SDK と Visual Studio のバージョンでは、Visual Studio の構成ではサポートされている、 [、C++、Visual Studio サポート/WinRT、XAML では、VSIX 拡張機能と、NuGet パッケージ](#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)VSIX の以前のバージョンに前のセクションが適用されます拡張機能です。 以下の情報には、動作に関する重要な相違点について説明します。 と構成のプロジェクトで作成した (またはを操作するアップグレード後) 以前のバージョン。

### <a name="created-earlier-than-101810022"></a>1.0.181002.2 よりも前の手順
VSIX 拡張 1.0.181002.2、C++ より前のバージョンで、プロジェクトが作成された場合 + VSIX 拡張機能のバージョンに WinRT ビルドのサポートが組み込まれています。 プロジェクトには、`<CppWinRTEnabled>true</CppWinRTEnabled>`プロパティで設定、`.vcxproj`ファイル。

```xml
<Project ...>
    <PropertyGroup Label="Globals">
        <CppWinRTEnabled>true</CppWinRTEnabled>
...
```

**Microsoft.Windows.CppWinRT** NuGet パッケージを手動でインストールすることによって、プロジェクトをアップグレードすることができます。 後のインストール (またはアップグレードする)、VSIX 拡張機能の最新バージョン Visual Studio でプロジェクトを開き、[**プロジェクト** \> **NuGet パッケージを管理する.** \> **参照**を、入力または**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、貼り付け**をインストール**して、プロジェクトのパッケージをインストールする] をクリックします。

### <a name="created-with-or-upgraded-to-between-101810022-and-101901283"></a>作成した (またはアップグレード) 1.0.181002.2 と 1.0.190128.3 間
1.0.181002.2 と 1.0.190128.3 の間、VSIX 拡張機能のバージョンで、プロジェクトが作成された場合、包括性を備えたし、 **Microsoft.Windows.CppWinRT** NuGet パッケージがプロジェクトでによって自動的にインストール プロジェクト テンプレートです。 この範囲で、VSIX 拡張機能のバージョンを使用する以前のプロジェクトをアップグレードしたも可能性があります。 行った場合、その&mdash;ビルドのサポートがこの範囲で VSIX 拡張機能のバージョンで引き続き存在していたもため&mdash;、アップグレード後のプロジェクトがまたは**Microsoft.Windows.CppWinRT** NuGet パッケージがインストールされていない可能性があります。

プロジェクトをアップグレードするには、前のセクションの指示に従って、プロジェクトの**Microsoft.Windows.CppWinRT** NuGet パッケージがインストールされていることを確認します。

### <a name="invalid-upgrade-configurations"></a>無効なアップグレードの構成
VSIX 拡張機能の最新のバージョンでことはできませんが、プロジェクトの`<CppWinRTEnabled>true</CppWinRTEnabled>` **Microsoft.Windows.CppWinRT** NuGet パッケージをインストールもされていない場合は、プロパティ。 この構成を持つプロジェクトがビルドのエラー メッセージを生成"c++/WinRT VSIX プロジェクト ビルドのサポートが提供されなくなります。  追加してください Microsoft.Windows.CppWinRT Nuget パッケージへの参照をプロジェクト。"

前述した、C + + WinRT プロジェクトが NuGet パッケージがインストールされていることを今すぐ必要があります。

`<CppWinRTEnabled>`要素は廃止されました、必要に応じてを編集できます、 `.vcxproj`、要素を削除します。 厳密に必要はありませんが、これは、オプション。

また場合、`.vcxproj`が含まれています`<RequiredBundles>$(RequiredBundles);Microsoft.Windows.CppWinRT</RequiredBundles>`、c++ を必要とせずに構築するために削除することができます/WinRT VSIX の拡張機能をインストールします。

## <a name="custom-types-in-the-cwinrt-projection"></a>C++/WinRT プロジェクションにおけるカスタム型
C++//winrt プログラミングでは、標準 C++ 言語機能を使用して[標準的な C++ データ型と C++/WinRT](std-cpp-data-types.md)&mdash;一部の C++ 標準ライブラリのデータ型を含みます。 ただし、プロジェクションでいくつかのカスタム データ型を認識するようになり、それらを使用することもできます。 たとえば、[C++/WinRT の概要](get-started.md) のクイックスタートのコード例では [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を使用しています。

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
