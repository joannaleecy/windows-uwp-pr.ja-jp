---
description: C++/WinRT の紹介 &mdash; Windows ランタイム API 用の標準的な C++ 言語プロジェクション。
title: C++/WinRT の概要
ms.date: 04/02/2019
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 概要
ms.localizationpriority: medium
ms.openlocfilehash: e9e84370f0503a8f361df9b43b60a2870be745a3
ms.sourcegitcommit: 940645c705865ba9635ccae2da9d917420faf608
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/02/2019
ms.locfileid: "58812601"
---
# <a name="introduction-to-cwinrt"></a>C++/WinRT の概要
&nbsp;
> [!VIDEO https://www.youtube.com/embed/nOFNc2uTmGs]

C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。 C++/WinRT の場合、標準に準拠した C++17 のコンパイラを使用して Windows ランタイム API を作成および使用できます。 Windows SDK には C++/WinRT が含まれます。バージョン 10.0.17134.0 (Windows 10、バージョン 1803) で導入されました。

C +/cli WinRT は Microsoft の推奨される代替、 [C +/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx?branch=live)言語プロジェクションでは、および[Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl?branch=live)します。 完全な一覧[について C +/cli WinRT](index.md#topics-about-cwinrt)との相互運用とからの移植、C + の両方に関する情報が含まれます/cli CX および WRL します。

> [!IMPORTANT]
> いくつかの最も重要な情報のC++注意すべき WinRT のセクションで説明されている/ [SDK サポートC++/WinRT](#sdk-support-for-cwinrt)と[Visual Studio のサポートC++/WinRT、XAML、VSIX 拡張機能、および NuGetパッケージ](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

## <a name="language-projections"></a>言語プロジェクション
Windows ランタイムは、コンポーネント オブジェクト モデル (COM) API に基づいており、*言語プロジェクション*を使用してアクセスするよう設計されています。 プロジェクションは、COM の詳細を隠し、特定の言語により自然なプログラミング エクスペリエンスを提供します。

### <a name="the-cwinrt-language-projection-in-the-windows-uwp-api-reference-content"></a>Windows UWP API リファレンス コンテンツにおける C++/WinRT 言語プロジェクション
[Windows UWP API](https://docs.microsoft.com/uwp/api/) の閲覧中に、右上隅の **[言語] (Language)** コンボ ボックスをクリックして **[C++/WinRT]** を選択し、API 構文ブロックを C++/WinRT 言語プロジェクションで表示されるように表示します。

## <a name="sdk-support-for-cwinrt"></a>C++/WinRT の SDK サポート
バージョン 10.0.17134.0 (Windows 10 バージョン 1803) の時点で、Windows SDK には、ファーストパーティ Windows API (Windows 名前空間の Windows ランタイム API) を使用するためのヘッダー ファイル ベースの標準的な C++ ライブラリが含まれています。

互換性のため、Windows SDK も付属しています、`cppwinrt.exe`ツール。 ただし、お勧めする代わりにインストールして使用する最新バージョンの`cppwinrt.exe`に含まれている、 **Microsoft.Windows.CppWinRT** NuGet パッケージ。 そのパッケージと`cppwinrt.exe`は、次のセクションで説明します。

## <a name="visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package"></a>Visual Studio のサポートの C +/cli WinRT、XAML、VSIX 拡張機能と NuGet パッケージ
Visual Studio サポートについては、10.0.17134.0 (Windows 10、バージョン 1803) の最小の SDK の Windows ターゲット バージョンに加えて、または必要な Visual Studio 2019 Visual Studio 2017 (少なくともバージョン 15.6; 15.7 では、少なくともお勧めします)。 まだインストールしていない場合、インストールする必要があります、 **C++ ユニバーサル Windows プラットフォーム ツール**オプションを Visual Studio インストーラー内で。 Windows**設定** > **Update\&セキュリティ** > **開発者向け**、選択、**開発者モード**オプションではなく、**アプリのサイドロード**オプション。

ダウンロードしての最新バージョンをインストールする必要があります、 [C +/cli WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)から、 [Visual Studio Marketplace](https://marketplace.visualstudio.com/)します。

- VSIX 拡張機能を提供する C +/cli Visual Studio で、WinRT プロジェクトと項目テンプレート C + で始めることができるように/cli WinRT 開発します。
- さらに、使用すると Visual Studio のネイティブのデバッグの視覚化 (natvis) of C/cli WinRT の型を射影します。ような体験C#デバッグします。 Natvis はデバッグ ビルドで自動で行われます。 シンボル WINRT_NATVIS を定義することで、リリース ビルドを選択できます。

Visual Studio のプロジェクト テンプレートの C +/cli WinRT は次のとおりです。 作成すると新しい C +/cli WinRT プロジェクトは最新の VSIX 拡張機能をインストールして、新しい C +/cli WinRT プロジェクトは自動的にインストール、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)します。 **Microsoft.Windows.CppWinRT** NuGet パッケージは、C +/cli WinRT のビルド (MSBuild のプロパティとターゲット) のサポート、開発用コンピューターからビルド エージェントの間で移植可能なプロジェクトを作成 (を NuGet パッケージとVSIX 拡張子ではなくがインストールされている)。

> [!IMPORTANT]
> 使用して作成された (またはアップグレードを使用する) プロジェクトがあるかどうかは VSIX 拡張機能を以前のバージョンより 1.0.190128.4、しを参照してください[VSIX 拡張機能の以前のバージョン](#earlier-versions-of-the-vsix-extension)します。 そのセクションには、VSIX 拡張機能の最新バージョンを使用するようにアップグレードするために知っておく必要がありますプロジェクトの構成に関する重要な情報が含まれています。

> [!NOTE]
> C++/WinRT は、標準の c++ 17 から機能を使用して、NuGet パッケージがプロジェクトのプロパティを設定**C/C++** > **言語** >   **C++言語標準** > **ISO c++ 17 標準 (//std:c + + 17)** Visual Studio でします。 また、 [/bigobj](/cpp/build/reference/bigobj-increase-number-of-sections-in-dot-obj-file)コンパイラ オプション。
> 
> 設定することがありますも**準拠モード。[はい] (/permissive -)** 標準に準拠したコードをさらに制限します。 注意すべきもう 1 つのプロジェクト プロパティは、**[C/C++]** > **[全般]** > **[警告をエラーとして扱う]** です。 これをユーザーの好みに合わせて **[はい (/WX)]** または **[いいえ (/WX-)]** に設定します。 場合によっては、`cppwinrt.exe` ツールによって生成されたソース ファイルは、それらに実装を追加するまで警告を生成します。

上記で説明した、システムにことができますを作成し、ビルド、または開くには、c++/cli WinRT は Visual Studio でプロジェクトし、デプロイします。

または、手動でインストールすることで、既存のプロジェクトを変換、 **Microsoft.Windows.CppWinRT** NuGet パッケージ。 後にインストール (または更新) VSIX 拡張機能の最新バージョンの Visual Studio で既存のプロジェクトを開く **プロジェクト** \> **NuGet パッケージの管理.**\> **参照**入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**そのプロジェクトのパッケージをインストールします。 パッケージを追加すると表示されます C +/cli の呼び出しを含む、プロジェクトの WinRT MSBuild のサポート、`cppwinrt.exe`ツール。 バージョン 2.0 では、時点で、 **Microsoft.Windows.CppWinRT** NuGet パッケージに含まれる、`cppwinrt.exe`ツール。

ポイントすることができます、 `cppwinrt.exe` Windows ランタイム メタデータ ツール (`.winmd`) ヘッダー ファイル ベースの標準を生成するファイルC++ライブラリを*プロジェクト*から消費のメタデータで記述された Api C++/WinRT コードです。 Windows ランタイム メタデータ (`.winmd`) ファイルは、Windows ランタイム API サーフェスを記述する正規の方法を提供します。 メタデータで `cppwinrt.exe` をポイントすることで、セカンド パーティまたはサード パーティの Windows ランタイム コンポーネントに実装された、または独自のアプリケーションに実装された任意のランタイム クラスで使用するためのライブラリを生成することができます。 詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。

C++/WinRT では、COM スタイルのプログラミングを使用せずに、標準的な C++ を使用して独自のランタイム クラスを実装することもできます。 ランタイム クラスでは、IDL ファイルで型を記述するだけです。`midl.exe` および `cppwinrt.exe` が実装のスケルトン ソース コード ファイルを自動的に作成します。 または、C++/WinRT の基本クラスから派生することでインターフェイスを実装することもできます。 詳細については、「[C++/WinRT での API の作成](author-apis.md)」を参照してください。

C + を使用してプロジェクトを特定する/cli WinRT の MSBuild のサポートの有無によって、 **Microsoft.Windows.CppWinRT** NuGet パッケージをプロジェクト内でインストールします。

ここで、VSIX 拡張機能によって提供される Visual Studio プロジェクト テンプレートです。

### <a name="windows-console-application-cwinrt"></a>Windows コンソール アプリケーション (C++/WinRT)
コンソールのユーザー インターフェイスを含む、Windows デスクトップの C++/WinRT クライアント アプリケーションのプロジェクト テンプレートです。

### <a name="blank-app-cwinrt"></a>空のアプリ (C++/WinRT)
XAML ユーザー インターフェイスを持つユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

Visual Studio では、各 XAML マークアップ ファイルの背後にあるインターフェイス定義言語 (IDL) (`.idl`) ファイルから実装とヘッダーのスタブを生成するために XAML コンパイラ サポートを提供します。 IDL ファイルで、アプリの XAML ページ内で参照する任意のローカルのランタイム クラスを定義してから、プロジェクトを 1 回ビルドして `Generated Files` で実装テンプレート、`Generated Files\sources` でスタブ型定義を生成します。 次にローカルのランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

Visual Studio の XAML デザイン サーフェスのサポート C +/cli WinRT と同等の近くにあるC#します。 1 つの例外は、**イベント**のタブ、**プロパティ**ウィンドウ。 C#プロジェクト、イベント ハンドラーを追加するタブを使用することができますC +/cli WinRT プロジェクト、その機能が存在しません。 参照が[C + でデリゲートを使用してイベントを処理/cli WinRT](handle-events.md)をコードにイベント ハンドラーを追加する方法の詳細について。

### <a name="core-app-cwinrt"></a>コア アプリ (C++/WinRT)
XAML を使用しないユニバーサル Windows プラットフォーム (UWP) アプリのプロジェクト テンプレートです。

代わりに、Windows.ApplicationModel.Core 名前空間に C++/WinRT Windows 名前空間ヘッダーを使用します。 ビルドおよび実行した後に、空の領域をクリックして色付きの正方形を追加し、色付きの正方形をクリックしてそれをドラッグします。

### <a name="windows-runtime-component-cwinrt"></a>Windows ランタイム コンポーネント (C++/WinRT)
通常はユニバーサル Windows プラットフォーム (UWP) から使用するための、コンポーネントのプロジェクト テンプレートです。

このテンプレートは、Windows ランタイム メタデータ (`.winmd`) が IDL から生成され、実装とヘッダーのスタブが Windows ランタイム メタデータから生成される、`midl.exe` > `cppwinrt.exe` ツール チェーンを示します。

IDL ファイルでは、コンポーネント、それらの既定インターフェイス、およびそれらが実装している他のすべてのインターフェイスのランタイム クラスを定義します。 プロジェクトを 1 回ビルドして `module.g.cpp`、`module.h.cpp`、`Generated Files` の実装テンプレート、および `Generated Files\sources` のスタブ型定義を生成します。 次にコンポーネント内のランタイム クラスの実装への参照にこれらのスタブ型定義を使用します。 各ランタイム クラスをその独自の IDL ファイル内で宣言することをお勧めします。

ビルドした Windows ランタイム コンポーネントのバイナリとその `.winmd` を、それらを使用する UWP アプリとバンドルします。

## <a name="earlier-versions-of-the-vsix-extension"></a>VSIX 拡張機能の以前のバージョン
インストールすることをお勧めします。 (または更新する) の最新バージョン、 [VSIX 拡張機能](https://aka.ms/cppwinrt/vsix)します。 既定で自動的に更新する構成されます。 VSIX 拡張機能、1.0.190128.4 し、このセクションでより前のバージョンで作成されたプロジェクトを使用して、その場合に、新しいバージョンで動作するこれらのプロジェクトのアップグレードに関する重要な情報が含まれています。 更新しない場合も表示されますについては、このセクションでは便利です。

観点で、Windows SDK と Visual Studio のバージョンでは、Visual Studio の構成情報はサポートされている、 [Visual Studio のサポートを c++/cli WinRT、XAML、VSIX 拡張機能と NuGet パッケージ](#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)前に前のセクションが適用されますVSIX 拡張機能のバージョン。 以下の情報が、動作に関する重要な相違点について説明し、構成のプロジェクトで作成した (またはを使用するアップグレードされた) 以前のバージョン。

### <a name="created-earlier-than-101810022"></a>1.0.181002.2 よりも前に作成
VSIX 拡張機能、1.0.181002.2、C + より前のバージョンで、プロジェクトが作成された場合/cli WinRT ビルドのサポートは、VSIX 拡張機能のバージョンに組み込まれていた。 プロジェクトが、`<CppWinRTEnabled>true</CppWinRTEnabled>`でプロパティを設定、`.vcxproj`ファイル。

```xml
<Project ...>
    <PropertyGroup Label="Globals">
        <CppWinRTEnabled>true</CppWinRTEnabled>
...
```

手動でインストールすることで、プロジェクトをアップグレードすることができます、 **Microsoft.Windows.CppWinRT** NuGet パッケージ。 After をインストールする (またはにアップグレードする) VSIX 拡張機能の最新バージョンの Visual Studio でプロジェクトを開き、をクリックして**プロジェクト** \> **NuGet パッケージの管理.**\> **[参照]** 入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**プロジェクトのパッケージをインストールします。

### <a name="created-with-or-upgraded-to-between-101810022-and-101901283"></a>作成された (またはにアップグレード) 1.0.181002.2 と 1.0.190128.3 間
1.0.181002.2 と 1.0.190128.3、両端を含む VSIX 拡張機能のバージョンで、プロジェクトが作成された場合、 **Microsoft.Windows.CppWinRT**プロジェクトで自動的に使用するプロジェクトで NuGet パッケージがインストールされましたテンプレート。 この範囲内で VSIX 拡張機能のバージョンを使用する以前のプロジェクトをアップグレードしたも可能性があります。 実行した場合、し&mdash;ビルドのサポートがこの範囲内で VSIX 拡張機能のバージョンに引き続き存在も&mdash;、アップグレードされたプロジェクトの場合がありますまたはいない可能性があります、 **Microsoft.Windows.CppWinRT** NuGet パッケージインストールされています。

プロジェクトをアップグレードするには、前のセクションの指示に従って、し、プロジェクトがあることを確認、 **Microsoft.Windows.CppWinRT** NuGet パッケージをインストールします。

### <a name="invalid-upgrade-configurations"></a>無効なアップグレードの構成
VSIX 拡張機能の最新のバージョンで無効ですが、プロジェクトの`<CppWinRTEnabled>true</CppWinRTEnabled>`プロパティもされていない場合は、 **Microsoft.Windows.CppWinRT** NuGet パッケージをインストールします。 この構成では、プロジェクト ビルド エラーのメッセージを生成する"c++/cli WinRT VSIX プロジェクトのビルドのサポートは提供されなくなりました。  追加してください、Microsoft.Windows.CppWinRT Nuget パッケージへの参照をプロジェクト。"

上記のとおり、c++/cli WinRT プロジェクトは、NuGet パッケージがインストールされていることを今すぐ必要があります。

以降、`<CppWinRTEnabled>`要素は廃止されました、必要に応じて編集することができます、 `.vcxproj`、および要素を削除します。 厳密に必要はありませんが、これは、オプションです。

また場合、`.vcxproj`が含まれています`<RequiredBundles>$(RequiredBundles);Microsoft.Windows.CppWinRT</RequiredBundles>`、c++ を必要とせずに作成できるように削除することができます/cli WinRT VSIX 拡張機能のインストールします。

## <a name="custom-types-in-the-cwinrt-projection"></a>C++/WinRT プロジェクションにおけるカスタム型
C +/cli WinRT プログラミング、標準の C++ 言語の機能を使用することができますと[標準 C++ のデータ型および C++/cli WinRT](std-cpp-data-types.md)&mdash;C++ 標準ライブラリの一部のデータ型を含みます。 ただし、プロジェクションでいくつかのカスタム データ型を認識するようになり、それらを使用することもできます。 たとえば、[C++/WinRT の概要](get-started.md) のクイックスタートのコード例では [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) を使用しています。

[**winrt::com_array** ](/uwp/cpp-ref-for-winrt/com-array)はいくつかの時点で使用する可能性がある別の型です。 ただし、[**winrt::array_view**](/uwp/cpp-ref-for-winrt/array-view) などの型を直接使用する可能性は低いです。 または、対応する型が C++ 標準ライブラリに現れた場合に変更すべきコードがないように、使用しないことを選択する場合もあります。

> [!WARNING]
> C++/WinRT Windows 名前空間ヘッダーをよく調査すると見つかる可能性がある型もあります。 例として **winrt::param::hstring** がありますが、コレクションの例もあります。 これらは入力パラメーターのバインディングを最適化するためにのみ存在し、大幅に改善したパフォーマンスをもたらし、関連する標準的な C++ の型とコンテナーでほとんどの呼び出しパターンが "そのまま機能する" ようにします。 これらの型は、ほとんどの値を追加する場合にプロジェクションでのみ使用されます。 高度に最適化され、一般的な用途で使用するものではありません。それらの型を自分で使用しないようにしてください。 また、`winrt::impl` 名前空間からは何も使用しないでください。それらは実装型であるため、変更されることがあります。 引き続き標準型を使用するか、または [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)の型を使用する必要があります。

## <a name="important-apis"></a>重要な API
* [winrt::hstring 構造体](/uwp/cpp-ref-for-winrt/hstring)
* [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [C +/cli WinRT Visual Studio 拡張機能 (VSIX)](https://aka.ms/cppwinrt/vsix)
* [C++/WinRT の使用を開始する](get-started.md)
* [標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md)
* [文字列処理 c++/cli WinRT](strings.md)
* [Windows の UWP Api](https://docs.microsoft.com/uwp/api/)
