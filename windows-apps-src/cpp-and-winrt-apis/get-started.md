---
author: stevewhims
description: C++/WinRT の使用をすぐに開始できるように、このトピックでは、単純なコード例について説明します。
title: C++/WinRT の概要
ms.author: stwhi
ms.date: 10/19/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 取得, 取得, 開始
ms.localizationpriority: medium
ms.openlocfilehash: 6cb8e18904f61976103689c8d83475ec248eb38b
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5558022"
---
# <a name="get-started-with-cwinrt"></a>C++/WinRT の使用を開始する

使用してにすぐ開始[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、このトピックでは、新しいに基づいて単純なコード例について説明します**Windows コンソール アプリケーション (、C++/WinRT)** プロジェクトです。 このトピックで説明する方法[追加 C + + Windows デスクトップ アプリケーション プロジェクトに WinRT サポート](#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。

> [!IMPORTANT]
> Visual Studio 2017 を使用している場合 (バージョン 15.8.0 以上) をターゲットとする Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) し、新しく作成した、C++/WinRT プロジェクトをコンパイル エラーで失敗する可能性が"*エラー C3861: 'from_abi': 識別子しません。見つかった*"、および*base.h*でその他のエラー。 解決策は、いずれかのターゲット以降 (詳しく準拠) のバージョンの Windows SDK、またはプロジェクトのプロパティを設定する**C/C++** > **言語** > **Conformance mode: いいえ**(また場合、 **/制限解除-** **プロジェクトのプロパティに表示されますC/C++** > **言語** > **コマンド ライン**[**その他のオプション**を削除します)。

## <a name="a-cwinrt-quick-start"></a>C++/WinRT のクイックスタート

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

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

[**SyndicationClient::RetrieveFeedAsync**](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、非同期 Windows ランタイム関数の例です。 コード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、呼び出しスレッドをブロックし、その結果 (この場合は配信フィード) を待機するように、このオブジェクトで **get** を呼び出します。 同時実行、および非ブロッキングの手法の詳細については、「[C++/WinRT での同時実行と非同期操作](concurrency.md)」を参照してください。

```cppwinrt
for (const SyndicationItem syndicationItem : syndicationFeed.Items()) { ... }
```

[**SyndicationFeed.Items**](/uwp/api/windows.web.syndication.syndicationfeed.items) は、**begin** および **end** 関数 (またはそれらの定数、逆、および定数逆バリアント) から返される反復子によって定義される範囲です。 このため、範囲ベースの `for` ステートメント、または **std::for_each** テンプレート関数とともに **Items** を列挙できます。

```cppwinrt
winrt::hstring titleAsHstring = syndicationItem.Title().Text();
std::wcout << titleAsHstring.c_str() << std::endl;
```

フィードのタイトル テキストを、[**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) オブジェクトとして取得します (詳細については「[C++/WinRT での文字列処理](strings.md)」を参照してください)。 次に **c_str** 関数で **hstring** が出力され、C++ 標準ライブラリの文字列で使用されるパターンが反映されます。

おわかりのように、C++/WinRT では、`syndicationItem.Title().Text()` などの、最新のクラスのような C++ の式を奨励しています。 これは、従来の COM プログラミングとは異なる、よりクリーンなプログラミング スタイルです。 直接 COM を初期化し、COM ポインターを操作する必要はありません。

HRESULT リターン コードを処理する必要もありません。 C++/WinRT では、エラーの HRESULT を [**winrt::hresult-error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) のような自然かつ最新のプログラミング スタイルの例外に変換します。 エラー処理の詳細とコード例の詳細については、「[C++/WinRT でのエラー処理](error-handling.md)」を参照してください。

## <a name="modify-a-windows-desktop-application-project-to-add-cwinrt-support"></a>追加するには、C++ の Windows デスクトップ アプリケーション プロジェクトを変更する/WinRT のサポート

このセクションでは、追加する方法、C++/cli/winrt サポートする必要があります Windows デスクトップ アプリケーション プロジェクトをします。 しないでくださいがある場合、既存の Windows デスクトップ アプリケーション プロジェクトを作成する最初の 1 つと共に、次の手順に従うことができます。 たとえば、Visual Studio を開き、 **Visual C**を作成 \> **Windows デスクトップ** \> **Windows デスクトップ アプリケーション**プロジェクトです。

### <a name="set-project-properties"></a>プロジェクトのプロパティを設定します。

**一般的な**プロパティをプロジェクトに移動する \> **Windows SDK バージョン**、および選択の**すべての構成**と**すべてのプラットフォーム**です。 **Windows SDK バージョン**を 10.0.17134.0 (Windows 10、バージョン 1803) に設定されていることを確認またはそれ以上。

いる影響を受けないことを確認[新しいプロジェクトがコンパイルされませんなぜかどうか。](/windows/uwp/cpp-and-winrt-apis/faq)します。

C++/WinRT の c++ 17 標準から機能を使用して、プロジェクト プロパティ**C/C++** 設定 > **言語** > **標準的な C++ 言語**に*ISO C 17 標準 (//std:c では 17)* します。

### <a name="the-precompiled-header"></a>プリコンパイル済みヘッダー

名前の変更、`stdafx.h`と`stdafx.cpp`に`pch.h`と`pch.cpp`、それぞれします。 **C/C++** プロジェクトのプロパティを設定 > **プリコンパイル済みヘッダー** >  *pch.h*を**プリコンパイル済みヘッダー ファイル**です。

検索し、置換すべて`#include "stdafx.h"`と`#include "pch.h"`します。

`pch.h`、含める`winrt/base.h`します。

```cppwinrt
// pch.h
...
#include <winrt/base.h>
```

### <a name="linking"></a>リンク

C++/cli [WindowsApp.lib](/uwp/win32-and-com/win32-apis)包括的なライブラリへのリンクは/winrt 言語プロジェクションは、特定の Windows ランタイムの自由 (非メンバー) 関数とエントリ ポイントに依存するを必要とします。 このセクションでは、リンカーを満たすの 3 つの方法について説明します。

最初のオプションは、Visual Studio を追加するプロジェクトのすべての c++/cli/winrt MSBuild プロパティとターゲットします。 編集、`.vcxproj`ファイルで、見つけ`<PropertyGroup Label="Globals">`そのプロパティ グループ内でプロパティを設定して、`<CppWinRTEnabled>true</CppWinRTEnabled>`します。

明示的にリンクするプロジェクトのリンク設定を使用する代わりに、`WindowsApp.lib`します。

または、ソース コードで行うことができます (で`pch.h`など) のようにします。

```cppwinrt
#pragma comment(lib, "windowsapp")
```

できるようになりましたコンパイルし、リンクを追加でき、C++/cli をプロジェクトに WinRT コード (に示すようにコード例を[A 内容//winrt のクイック スタート](#a-cwinrt-quick-start)セクションは、上記の)

## <a name="important-apis"></a>重要な API
* [Syndicationclient::retrievefeedasync メソッド](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [SyndicationFeed.Items プロパティ](/uwp/api/windows.web.syndication.syndicationfeed.items)
* [winrt::hstring 構造体](/uwp/cpp-ref-for-winrt/hstring)
* [:hresult-error 構造体](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [C++/WinRT でのエラー処理](error-handling.md)
* [C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md)
* [C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)
* [C++/CX から C++/WinRT への移行](move-to-winrt-from-cx.md)
* [C++/WinRT での文字列の処理](strings.md)
