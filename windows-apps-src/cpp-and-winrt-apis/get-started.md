---
description: C++/WinRT の使用をすぐに開始できるように、このトピックでは、単純なコード例について説明します。
title: C++/WinRT の使用を開始する
ms.date: 10/19/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 取得, 取得, 開始
ms.localizationpriority: medium
ms.openlocfilehash: c0d11a8718f61666d6285d8a1c91b48992044b22
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602237"
---
# <a name="get-started-with-cwinrt"></a>C++/WinRT の使用を開始する

使用して短縮にするため[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、このトピックでは、新しいに基づいて単純なコード例によって説明**Windows コンソール アプリケーション (C +/cli WinRT)** プロジェクト。 このトピックで説明する方法[追加 C +/cli WinRT サポートし、Windows デスクトップ アプリケーション プロジェクトに](#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。

> [!IMPORTANT]
> Visual Studio 2017 を使用している場合 (バージョン 15.8.0 またはそれ以降)、およびターゲットの Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した C +/cli WinRT プロジェクトがエラーでコンパイルに失敗する可能性があります"*エラー C3861: 'from_abi'。識別子が見つかりません*"、発信元がその他のエラーの*base.h*します。 いずれかのターゲットに以降 (詳細について準拠) は、ソリューションのバージョンの Windows SDK、またはプロジェクトのプロパティを設定**C/C++** > **言語** > **準拠モード。いいえ**(また場合、 **/permissive -** プロジェクト プロパティに表示されます**C/C++** > **言語** > **コマンドライン** **追加オプション**から削除します)。

## <a name="a-cwinrt-quick-start"></a>C++/WinRT のクイックスタート

> [!NOTE]
> 詳細については、インストールと使用すると、C +/cli WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレートのサポートを提供します) を参照してください[Visual Studio のサポートの C +/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

新しい **Windows コンソール アプリケーション (C++/WinRT)** プロジェクトを作成します。

`pch.h` と `main.cpp` を次のように編集します。

```cppwinrt
// pch.h
...
#include <iostream>
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
...
```

```cppwinrt
// main.cpp
#include "pch.h"

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
        winrt::hstring titleAsHstring = syndicationItem.Title().Text();
        std::wcout << titleAsHstring.c_str() << std::endl;
    }
}
```

上の簡単なコード例を 1 つずつ参照し、各部分に何が起こっているかを説明します。

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
```

インクルードするヘッダーは SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt` フォルダー内にあります。 Visual Studio には、その *IncludePath* マクロにそのパスが含まれています。 このヘッダーには、C++/WinRT に投影された Windows API が含まれます。 つまり、Windows の種類ごとに、C++/WinRT は C++ 対応の同等の型 (*投影された型*と呼ばれます) を定義します。 投影された型には Windows の型と同じ完全修飾名がありますが、C++ **winrt** 名前空間に配置されます。 これらのインクルードをプリコンパイル済みヘッダーに配置すると、段階的なビルド時間が短縮されます。

> [!IMPORTANT]
> Windows 名前空間から型を使用する場合は、次に示すように、対応する C++/WinRT Windows 名前空間ヘッダー ファイルを含めます。 *対応する*ヘッダーは、その型の名前空間と同じ名前を持つヘッダーです。 たとえば、C++/WinRT プロジェクションを [**Windows::Foundation::Collections::PropertySet**](/uwp/api/windows.foundation.collections.propertyset) ランタイム クラスに使用するには、`#include <winrt/Windows.Foundation.Collections.h>` を指定します。

```cppwinrt
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;
```

`using namespace` ディレクティブはオプションですが、便利です。 (**winrt** 名前空間で非修飾名による参照を許可する) ディレクティブに関する上記のパターンは、新しいプロジェクトを開始する場合に最適です。また、C++/WinRT はそのプロジェクト内で使用する唯一の言語プロジェクションです)。 一方、C++/WinRT コードを [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) および SDK アプリケーション バイナリ インターフェイス (ABI) コードと混在させている (これらのモデルのいずれかまたは両方から移植しているか、相互運用している) 場合は、「[C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md)」、「[C++/CX から C++/WinRT への移動](move-to-winrt-from-cx.md)」、「[C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)」のトピックを参照してください。

```cppwinrt
winrt::init_apartment();
```

**winrt::init_apartment** への呼び出しにより、既定では、マルチスレッド アパートメントで COM が初期化されます。

```cppwinrt
Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
SyndicationClient syndicationClient;
```

2 つのオブジェクトをスタックに割り当てます。これらのオブジェクトは Windows ブログの URI と配信クライアントを表します。 単純なワイド文字列リテラルで URI を作成します (その他の文字列の操作方法については、「[C++/WinRT での文字列の処理](strings.md)」を参照してください)。

```cppwinrt
SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
```

[**SyndicationClient::RetrieveFeedAsync** ](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)非同期 Windows ランタイム関数の例を示します。 コード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、呼び出しスレッドをブロックし、その結果 (この場合は配信フィード) を待機するように、このオブジェクトで **get** を呼び出します。 同時実行、および非ブロッキングの手法の詳細については、「[C++/WinRT での同時実行と非同期操作](concurrency.md)」を参照してください。

```cppwinrt
for (const SyndicationItem syndicationItem : syndicationFeed.Items()) { ... }
```

[**SyndicationFeed.Items** ](/uwp/api/windows.web.syndication.syndicationfeed.items)から返された反復子によって定義された範囲は、**開始**と**エンド**関数 (または、定数、反転、および定数反転のバリアント)。 このため、範囲ベースの `for` ステートメント、または **std::for_each** テンプレート関数とともに **Items** を列挙できます。

```cppwinrt
winrt::hstring titleAsHstring = syndicationItem.Title().Text();
std::wcout << titleAsHstring.c_str() << std::endl;
```

フィードのタイトル テキストを、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) オブジェクトとして取得します (詳細については「[C++/WinRT での文字列処理](strings.md)」を参照してください)。 次に **c_str** 関数で **hstring** が出力され、C++ 標準ライブラリの文字列で使用されるパターンが反映されます。

おわかりのように、C++/WinRT では、`syndicationItem.Title().Text()` などの、最新のクラスのような C++ の式を奨励しています。 これは、従来の COM プログラミングとは異なる、よりクリーンなプログラミング スタイルです。 直接 COM を初期化し、COM ポインターを操作する必要はありません。

HRESULT リターン コードを処理する必要もありません。 C++/WinRT では、エラーの HRESULT を [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) のような自然かつ最新のプログラミング スタイルの例外に変換します。 エラー処理の詳細とコード例の詳細については、「[C++/WinRT でのエラー処理](error-handling.md)」を参照してください。

## <a name="modify-a-windows-desktop-application-project-to-add-cwinrt-support"></a>C + を追加する Windows デスクトップ アプリケーション プロジェクトを変更する/cli WinRT のサポート

このセクションで説明する追加方法 C +/cli WinRT サポートを所持している Windows デスクトップ アプリケーション プロジェクト。 場合は、既存の Windows デスクトップ アプリケーション プロジェクトは、最初の作成のいずれかでと共に次の手順に従うことができますし、必要はありません。 たとえば、Visual Studio を開き、作成、 **Visual C** \> **Windows デスクトップ** \> **Windows デスクトップ アプリケーション**プロジェクト。

必要に応じてインストールすることができます、 [C +/cli WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)します。 詳細については、次を参照してください。 [Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。

### <a name="set-project-properties"></a>プロジェクト プロパティの設定

プロジェクトのプロパティに移動して**全般** \> **Windows SDK バージョン**を選択し、**すべての構成**と**すべてのプラットフォーム**します。 いることを確認**Windows SDK バージョン**10.0.17134.0 (Windows 10、バージョン 1803) に設定されているか、大きい。

発生していないを確認[自分の新しいプロジェクトがコンパイルされない理由ですか?](/windows/uwp/cpp-and-winrt-apis/faq)します。

ため、C +/cli WinRT は、c++ 17 標準的な設定のプロジェクト プロパティから機能を使用して**C/C++** > **言語** > **C 言語標準**に*ISO c++ 17 標準 (//std:c + + 17)* します。

### <a name="the-precompiled-header"></a>プリコンパイル済みヘッダー

名前の変更、`stdafx.h`と`stdafx.cpp`に`pch.h`と`pch.cpp`、それぞれします。 プロジェクトのプロパティを設定**C/C++** > **プリコンパイル済みヘッダー** > **プリコンパイル済みヘッダー ファイル**に*pch.h*します。

検索し、置換すべて`#include "stdafx.h"`で`#include "pch.h"`します。

`pch.h`、含める`winrt/base.h`します。

```cppwinrt
// pch.h
...
#include <winrt/base.h>
```

### <a name="linking"></a>リンク

C++/cli へのリンクは WinRT 言語プロジェクションは、特定の (メンバーではない) 関数の無料で Windows ランタイム、およびエントリ ポイントに依存するを必要と、 [WindowsApp.lib](/uwp/win32-and-com/win32-apis)包括的なライブラリ。 このセクションでは、リンカーが満たされる 3 つの方法について説明します。

最初のオプションは、Visual Studio に追加するプロジェクトのすべての c++/cli WinRT MSBuild プロパティとターゲット。 これを行うには、インストール、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をプロジェクトにします。 開いている Visual Studio でプロジェクトをクリックして**プロジェクト** \> **NuGet パッケージの管理.**\> **[参照]** 入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**そのプロジェクトのパッケージをインストールします。

明示的にリンクするプロジェクト リンクの設定を使用することもできます。`WindowsApp.lib`します。 または、ソース コードで行うことができます (で`pch.h`など) のようです。

```cppwinrt
#pragma comment(lib, "windowsapp")
```

コンパイルおよびリンク、および追加 C +/cli WinRT コードをプロジェクトに (たとえば、コードに示すように、 [A C+/cli WinRT のクイック スタート](#a-cwinrt-quick-start)セクションで、上記の)

## <a name="important-apis"></a>重要な API
* [SyndicationClient::RetrieveFeedAsync メソッド](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [SyndicationFeed.Items プロパティ](/uwp/api/windows.web.syndication.syndicationfeed.items)
* [winrt::hstring 構造体](/uwp/cpp-ref-for-winrt/hstring)
* [winrt::hresult エラー構造体](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [エラー処理と C +/cli WinRT](error-handling.md)
* [C + 間相互運用機能/cli WinRT および C++/cli CX](interop-winrt-cx.md)
* [C + 間相互運用機能/cli WinRT と ABI](interop-winrt-abi.md)
* [移動する C +/cli WinRT C +/cli CX](move-to-winrt-from-cx.md)
* [文字列処理 c++/cli WinRT](strings.md)
