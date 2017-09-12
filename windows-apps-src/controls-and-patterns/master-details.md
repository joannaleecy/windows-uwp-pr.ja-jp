---
author: Jwmsft
Description: "マスター/詳細パターンでは、マスター リストと、現在選択されている項目の詳細が表示されます。 このパターンは、メールや連絡先一覧/アドレス帳によく使用されます。"
title: "マスター/詳細"
ms.assetid: 45C9FE8B-ECA6-44BF-8DDE-7D12ED34A7F7
label: Master/details
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 49a586aac0c846cdad02f8448532238bd3eb8551
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="masterdetails-pattern"></a>マスター/詳細パターン

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

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
| 320 epx ～ 719 epx        | スタック           |
| 720 epx 以上       | 左右に並べる      |

 
## <a name="stacked-style"></a>スタック スタイル

スタック スタイルでは、マスター ウィンドウと詳細ウィンドウのうち 1 つのウィンドウだけが一度に表示されます。

![スタック モードのマスター詳細](images/patterns-md-stacked.png)

ユーザーがマスター ウィンドウで作業を始め、マスター リストで項目を選んで詳細ウィンドウに "ドリルダウン" します。 ユーザーから見ると、マスター ビューと詳細ビューが別々の 2 つのページに存在するように表示されます。

### <a name="create-a-stacked-masterdetails-pattern"></a>スタック マスター/詳細パターンの作成

スタック マスター/詳細パターンを作る方法の 1 つは、マスター ウィンドウと詳細ウィンドウにそれぞれ別のページを使うことです。 マスター リストを表示するリスト ビューを 1 つのページに配置し、詳細ウィンドウのコンテンツ要素を別のページに配置します。

![スタック スタイルのマスター詳細の構成要素](images/patterns-md-stacked-parts.png)

マスター ウィンドウでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。

詳細ウィンドウの場合、最も意味のあるコンテンツ要素を使います。 多くの個別フィールドがある場合は、グリッド レイアウトを使って要素をフォームに配置することを検討します。

## <a name="side-by-side-style"></a>左右に並べるスタイル

横に並べるスタイルでは、マスター ウィンドウと詳細ウィンドウを同時に表示できます。

![マスター/詳細パターン](images/patterns-masterdetail-400x227.png)

マスター ウィンドウのリストは、現在選択されている項目を示すために選択ビジュアルを使用します。 マスター リストで新しい項目を選ぶと、詳細ウィンドウが更新されます。

### <a name="create-a-side-by-side-masterdetails-pattern"></a>左右に並べるマスター/詳細パターンの作成

マスター ウィンドウでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。

詳細ウィンドウの場合、最も意味のあるコンテンツ要素を使います。 多くの個別フィールドがある場合は、グリッド レイアウトを使って要素をフォームに配置することを検討します。

## <a name="get-the-code-samples"></a>コード サンプルを入手する

マスター/詳細パターンを示すサンプル コードについては、次のサンプルをご覧ください。 

- [顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database) 
- [ListView と GridView のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619900)
- [RSS リーダーのサンプル](https://github.com/Microsoft/Windows-appsample-rssreader)

## <a name="related-articles"></a>関連記事

- [リスト](lists.md)
- [検索](search.md)
- [アプリ バーとコマンド バー](app-bars.md)
- [ListView クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)
