---
description: フォト エディターは、C++/WinRT 言語プロジェクションでの開発を紹介する UWP のサンプル アプリケーションです。 サンプル アプリケーションを使用すると、画像ライブラリから写真を取得し、関連する写真効果で選択したイメージを編集できます。
title: Photo Editor C++/WinRT サンプル アプリケーション
ms.date: 06/08/2018
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, サンプル, アプリケーション, フォト, エディター
ms.localizationpriority: medium
ms.openlocfilehash: 8c6f668ef3d92f968e75659b0ba1937abadb079c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606707"
---
# <a name="photo-editor-cwinrt-sample-application"></a>Photo Editor C++/WinRT サンプル アプリケーション
[フォト エディター C++/WinRT サンプル アプリケーション](https://github.com/Microsoft/Windows-appsample-photo-editor)の GitHub リポジトリからサンプル アプリケーションを複製またはダウンロードできます。

フォト エディター アプリケーションは、[C++/WinRT](intro-to-using-cpp-with-winrt.md) 言語プロジェクションでの開発を紹介するユニバーサル Windows プラットフォーム (UWP) のサンプル アプリケーションです。 サンプル アプリケーションを使用すると、**画像**ライブラリから写真を取得し、関連する写真効果で選択したイメージを編集できます。 サンプルのソース コードでさまざまな一般的なプラクティスを確認します&mdash;など[データ バインディング](binding-property.md)、および[非同期アクションおよび操作](concurrency.md)&mdash;C + を使用して実行/cli WinRTプロジェクション。 このサンプルで示されている特定の機能の一部を次に示します。
    
- 標準 C++17 の構文およびライブラリと Windows ランタイム (WinRT) API との使用。
- co_await、co_return、[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、 [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) を含むコルーチンの使用。
- Windows ランタイムのカスタム クラス (ランタイム クラス) の投影型と実装型の作成と使用 これらの用語の詳細については、「[C++/WinRT での API の使用](consume-apis.md)」および「[C++/WinRT での API の作成](author-apis.md)」を参照してください。
- 自動失効イベント トークンの使用を含む、[イベント処理](handle-events.md)。
- 画像効果での Win2D NuGet 外部パッケージおよび [Windows::UI::Composition](/uwp/api/windows.ui.composition) の使用。
- [{x:Bind} markup extension](https://docs.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を含む XAML データ バインディング。
- [接続型アニメーション](../design/motion/connected-animation.md)を含む、XAML スタイルと UI のカスタマイズ。
