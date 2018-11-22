---
author: Jwmsft
Description: The master/detail pattern displays a master list and the details for the currently selected item. This pattern is frequently used for email and contact lists/address books.
title: マスター/詳細
ms.assetid: 45C9FE8B-ECA6-44BF-8DDE-7D12ED34A7F7
label: Master/details
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b30835e31e86c0c98d0c134ed28adca4413650c9
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7579609"
---
# <a name="masterdetails-pattern"></a>マスター/詳細パターン

 

マスター/詳細パターンには、コンテンツのマスター ウィンドウ (通常は[リスト ビュー](lists.md)も表示されます) と詳細ウィンドウがあります。 マスター リストの項目を選ぶと、詳細ウィンドウが更新されます。 このパターンは、メールやアドレス帳によく使われます。

> **重要な API**: [ListView クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)、[SplitView クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)

![マスター/詳細パターンの例](images/HIGSecOne_MasterDetail.png)

## <a name="is-this-the-right-pattern"></a>適切なパターンの選択

次の場合は、マスター/詳細パターンが適しています。

-   メール アプリ、アドレス帳、またはリスト/詳細レイアウトをベースとするアプリを構築する。
-   大きいコンテンツ コレクションを特定して優先順位を設定する。
-   コンテキスト間を前後に移動しながら、リストから項目をすばやく追加および削除できるようにする。

## <a name="choose-the-right-style"></a>適切なスタイルの選択

マスター/詳細パターンを実装するとき、利用可能な画面領域の量に応じて、スタック スタイルまたは左右に並べるスタイルを使うことをお勧めします。

| 利用可能なウィンドウの幅 | 推奨スタイル |
|------------------------|-------------------|
| 320 epx ～ 640 epx        | スタック           |
| 641 epx 以上       | 左右に並べる      |

 
## <a name="stacked-style"></a>スタック スタイル

スタック スタイルでは、マスター ウィンドウと詳細ウィンドウのうち 1 つのウィンドウだけが一度に表示されます。

![スタック モードのマスター詳細](images/patterns-md-stacked.png)

ユーザーがマスター ウィンドウで作業を始め、マスター リストで項目を選んで詳細ウィンドウに "ドリルダウン" します。 ユーザーから見ると、マスター ビューと詳細ビューが別々の 2 つのページに存在するように表示されます。

### <a name="create-a-stacked-masterdetails-pattern"></a>スタック マスター/詳細パターンの作成

スタック マスター/詳細パターンを作る方法の 1 つは、マスター ウィンドウと詳細ウィンドウにそれぞれ別のページを使うことです。 マスター ビューを 1 つのページに表示し、詳細ウィンドウを別のページに配置します。

![スタック スタイルのマスター詳細の構成要素](images/patterns-md-stacked-parts.png)

マスター ビュー ページでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。 

詳細ビュー ページの場合、最も意味のある[コンテンツ要素](../layout/layout-panels.md) を使います。 多くの個別フィールドがある場合は、**グリッド** レイアウトを使って要素をフォームに配置することを検討します。

ページ間の移動の詳細については、「[UWP アプリのナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。

## <a name="side-by-side-style"></a>左右に並べるスタイル

横に並べるスタイルでは、マスター ウィンドウと詳細ウィンドウを同時に表示できます。

![マスター/詳細パターン](images/patterns-masterdetail-400x227.png)

マスター ウィンドウのリストは、現在選択されている項目を示すために選択ビジュアルを使用します。 マスター リストで新しい項目を選ぶと、詳細ウィンドウが更新されます。

### <a name="create-a-side-by-side-masterdetails-pattern"></a>左右に並べるマスター/詳細パターンの作成

サイド バイ サイドのマスター/詳細パターンを実装する 1 つの方法として、[分割ビュー](split-view.md) コントロールを使用する方法があります。 分割ビューのウィンドウにマスター ビューを配置し、分割ビューのコンテンツに詳細ビューを配置します。

![マスター/詳細分割ビュー部品](images/patterns_md_splitview_parts.png)

マスター ウィンドウでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。

詳細コンテンツの場合、最も意味のある[コンテンツ要素](../layout/layout-panels.md) を使います。 多くの個別フィールドがある場合は、**グリッド** レイアウトを使って要素をフォームに配置することを検討します。

## <a name="adaptive-layout"></a>アダプティブ レイアウト

マスター/詳細パターンをすべての画面サイズで実装するには、[アダプティブ レイアウト](../layout/layouts-with-xaml.md) で応答性の高い UI を作成します。

![アダプティブ マスター詳細レイアウト](images/patterns_masterdetail.png)

### <a name="create-an-adaptive-masterdetails-pattern"></a>アダプティブ マスター/詳細パターンの作成
アダプティブ レイアウトを作成するには、UI のさまざまな [**VisualStates**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.visualstate) を定義し、[**AdaptiveTriggers**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.AdaptiveTrigger) を使用して UI のさまざまな状態のブレークポイントを宣言します。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

次のサンプルでは、アダプティブ レイアウトを使用してマスター/詳細パターンを実装し、静的なリソース、データベース リソース、およびオンライン リソースに対するデータ バインディングを示します。 
- [マスター/詳細のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlMasterDetail) 
- [マスター/詳細と選択のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)
- [Windows Template Studio マスター/詳細のサンプル](https://github.com/Microsoft/WindowsTemplateStudio/tree/master/templates/Uwp/Pages/MasterDetail)
- [顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)
- [RSS リーダーのサンプル](https://github.com/Microsoft/Windows-appsample-rssreader)

## <a name="related-articles"></a>関連記事

- [リスト](lists.md)
- [検索](search.md)
- [アプリ バーとコマンド バー](app-bars.md)
- [ListView クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)
- [SplitView クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)
