---
author: JoshuaPartlow
description: フォト エディターは、C++/WinRT 言語プロジェクションでの開発を紹介する UWP のサンプル アプリケーションです。 サンプル アプリケーションを使用すると、画像ライブラリから写真を取得し、関連する写真効果で選択したイメージを編集できます。
title: フォト エディター C++/WinRT サンプル アプリケーション
ms.author: wdg-dev-content
ms.date: 06/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, サンプル, アプリケーション, フォト, エディター
ms.localizationpriority: medium
ms.openlocfilehash: 8c87933247a302bceb43d1f7434d14f37cfbfc8f
ms.sourcegitcommit: ee77826642fe8fd9cfd9858d61bc05a96ff1bad7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/11/2018
ms.locfileid: "2018462"
---
# <a name="photo-editor-cwinrt-sample-application"></a><span data-ttu-id="6f819-105">フォト エディター C++/WinRT サンプル アプリケーション</span><span class="sxs-lookup"><span data-stu-id="6f819-105">Photo Editor C++/WinRT sample application</span></span>
<span data-ttu-id="6f819-106">[フォト エディター C++/WinRT サンプル アプリケーション](https://github.com/Microsoft/Windows-appsample-photo-editor)の GitHub リポジトリからサンプル アプリケーションを複製またはダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="6f819-106">You can clone or download the sample application from the [Photo Editor C++/WinRT sample application](https://github.com/Microsoft/Windows-appsample-photo-editor) GitHub repository.</span></span>

<span data-ttu-id="6f819-107">フォト エディター アプリケーションは、[C++/WinRT](intro-to-using-cpp-with-winrt.md) 言語プロジェクションでの開発を紹介するユニバーサル Windows プラットフォーム (UWP) のサンプル アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="6f819-107">The Photo Editor application is a Universal Windows Platform (UWP) sample application that showcases development with the [C++/WinRT](intro-to-using-cpp-with-winrt.md) language projection.</span></span> <span data-ttu-id="6f819-108">サンプル アプリケーションを使用すると、**画像**ライブラリから写真を取得し、関連する写真効果で選択したイメージを編集できます。</span><span class="sxs-lookup"><span data-stu-id="6f819-108">The sample application allows you to retrieve photos from the **Pictures** library, and then edit the selected image with assorted photo effects.</span></span> <span data-ttu-id="6f819-109">サンプルのソース コードには、C++/WinRT プロジェクションを使用して実行された[データ バインディング](binding-property.md)や[非同期アクションと非同期操作](concurrency.md)など多くの一般的な方法が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6f819-109">In the sample's source code, you'll see a number of common practices&mdash;such as [data binding](binding-property.md), and [asynchronous actions and operations](concurrency.md)&mdash;performed using the C++/WinRT projection.</span></span> <span data-ttu-id="6f819-110">このサンプルで示されている特定の機能の一部を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6f819-110">Here are some of the specific features demonstrated by the sample.</span></span>
    
- <span data-ttu-id="6f819-111">標準 C++17 の構文およびライブラリと Windows ランタイム (WinRT) API との使用。</span><span class="sxs-lookup"><span data-stu-id="6f819-111">Use of Standard C++17 syntax and libraries with Windows Runtime (WinRT) APIs.</span></span>
- <span data-ttu-id="6f819-112">co_await、co_return、[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、 [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) を含むコルーチンの使用。</span><span class="sxs-lookup"><span data-stu-id="6f819-112">Use of coroutines, including the use of co_await, co_return, [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction), and [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_).</span></span>
- <span data-ttu-id="6f819-113">Windows ランタイムのカスタム クラス (ランタイム クラス) の投影型と実装型の作成と使用</span><span class="sxs-lookup"><span data-stu-id="6f819-113">Creation and use of custom Windows Runtime class (runtime class) projected types and implementation types.</span></span> <span data-ttu-id="6f819-114">これらの用語の詳細については、「[C++/WinRT での API の使用](consume-apis.md)」および「[C++/WinRT での API の作成](author-apis.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6f819-114">For more info about these terms, see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>
- <span data-ttu-id="6f819-115">自動失効イベント トークンの使用を含む、[イベント処理](handle-events.md)。</span><span class="sxs-lookup"><span data-stu-id="6f819-115">[Event handling](handle-events.md), including the use of auto-revoking event tokens.</span></span>
- <span data-ttu-id="6f819-116">画像効果での Win2D NuGet 外部パッケージおよび [Windows::UI::Composition](/uwp/api/windows.ui.composition) の使用。</span><span class="sxs-lookup"><span data-stu-id="6f819-116">Use of the external Win2D NuGet package, and [Windows::UI::Composition](/uwp/api/windows.ui.composition), for image effects.</span></span>
- <span data-ttu-id="6f819-117">[{x:Bind} markup extension](https://docs.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension) を含む XAML データ バインディング。</span><span class="sxs-lookup"><span data-stu-id="6f819-117">XAML data binding, including the [{x:Bind} markup extension](https://docs.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension).</span></span>
- <span data-ttu-id="6f819-118">[接続型アニメーション](../design/motion/connected-animation.md)を含む、XAML スタイルと UI のカスタマイズ。</span><span class="sxs-lookup"><span data-stu-id="6f819-118">XAML styling and UI customization, including [connected animations](../design/motion/connected-animation.md).</span></span>