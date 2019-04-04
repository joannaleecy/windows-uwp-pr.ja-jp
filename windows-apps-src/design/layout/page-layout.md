---
title: UWP アプリのページ レイアウト
description: アプリを設計するときに最初に検討することは、レイアウト構造です。 この記事では、基本的なページ レイアウト、UI 要素を含む必要があります、およびページが出るの一般的な構造について説明します。 各ページで UWP アプリでは、ナビゲーション、コマンド、およびコンテンツの要素が通常持っています。
ms.date: 03/19/2018
ms.topic: article
keywords: windows 10, uwp
localizationpriority: medium
ms.openlocfilehash: edda9948e70b1757ddb46fae45a579bb2fdb8de1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633717"
---
# <a name="page-layout"></a>ページのレイアウト

UWP アプリで各[**ページ**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page)通常、ナビゲーション、コマンド、およびコンテンツの要素が存在します。 

アプリが複数のページがあることができます: ユーザーが、UWP アプリを起動、アプリケーション コードを作成、 [**フレーム**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame)アプリケーションの内部に配置する[**ウィンドウ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window). フレームできますし、[移動](../basics/navigate-between-two-pages.md)アプリケーションの間で[**ページ**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page)インスタンス。 

ほとんどのページの次の一般的なレイアウト構造体と、この記事で説明する UI 要素が必要、およびページが出る。 

![ページの構造](images/page-components.svg)

## <a name="navigation"></a>ナビゲーション
ユーザーがアプリでページ間で移動する方法を定義するナビゲーション モデルを選択すると、アプリのレイアウトを開始します。 この記事では、2 つの一般的なナビゲーション パターンについて説明します左のナビゲーションと上部のナビゲーション。 その他のナビゲーション オプションを選択する方法のガイダンスについては、[UWP アプリのナビゲーション設計の基本](../basics/navigation-basics.md)を参照してください。

![上部と左側のナビゲーション パターン](images/top-left-nav.svg)

### <a name="left-nav"></a>左側のナビゲーション
左のナビゲーションで、または[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)パターン、一般に、アプリ レベルのナビゲーションに予約されている、つまり常にある表示および使用できる、アプリ内で最上位レベルに存在します。 左側のナビゲーションは、複数の 5 つのナビゲーション項目、または、アプリ内の 5 つ以上のページがある場合にお勧めします。 ナビゲーション ウィンドウのパターンが通常含まれています。
- ナビゲーション項目
- アプリの設定へのエントリ ポイント
- アカウントの設定へのエントリ ポイント

[NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)コントロールは、UWP の左側のナビゲーション パターンを実装します。

ナビゲーション項目を選択すると、フレームが選択した項目のページに移動します。

![ナビゲーション ウィンドウの展開](images/navview-expanded.svg)

メニュー ボタンでは、ナビゲーション ウィンドウを閉じたりすることができます。 画面のサイズが 640 よりも大きい場合 px、メニュー ボタンをクリックすると、バーにナビゲーション ウィンドウを折りたたみます。

![compact のナビゲーション ウィンドウ](images/navview-compact.svg)

画面のサイズが 640 よりも小さい場合 px、ナビゲーション ウィンドウが完全に折りたたまれています。

![最小限のナビゲーション ウィンドウ](images/navview-minimal.svg)

### <a name="top-nav"></a>上部のナビゲーション

上部のナビゲーションは、最上位レベルのナビゲーションとしても機能できます。 左側のナビゲーションは、折りたたみ可能な上部のナビゲーションが常に表示します。 [NavigationView](../controls-and-patterns/navigationview.md)コントロールは、UWP の上部のナビゲーションとタブのパターンを実装します。

![上部のナビゲーション](images/pivot-large.svg)

## <a name="command-bar"></a>コマンド バー

次に、アプリの最も一般的なタスクに簡単にアクセスをユーザーに提供する可能性があります。 A[コマンド バー](../controls-and-patterns/app-bars.md)アプリ レベルまたはページ レベルのコマンドにアクセスできるようにし、すべてのナビゲーション パターンを持つために使用できます。

![上部にあるコマンド バーの配置 ](images/app-bar-desktop.svg)

上部またはページの下部にあるコマンド バーを配置できるアプリのどちらかをお勧めします。

![下部にあるコマンド バーの配置](images/app-bar-mobile.svg)

## <a name="content"></a>コンテンツ

最後に、さまざまな方法でコンテンツを表示できるように、コンテンツは、広くからアプリにアプリによって異なります。 ここでは、アプリで使用する場合がありますいくつかの一般的なページ パターンについて説明します。 多くのアプリは、これらの一般的なページ パターンの一部またはすべてを使用して、さまざまな種類のコンテンツを表示します。 同様に、自由に混在させるし、アプリを最適化するためにこれらのパターンに一致します。

## <a name="landing"></a>ランディング

![ランディング ページ](images/hero-screen.svg)

通常、ランディング ページ (ヒーロー画面とも呼ばれる) は、アプリのエクスペリエンスのトップ レベルに表示されます。 大きいサーフェス領域は、ユーザーが参照および使用する可能性があるコンテンツを、アプリが強調表示するためのステージとして機能します。

## <a name="collections"></a>コレクション

![ギャラリー](images/gridview.svg)

コレクションを使用すると、ユーザーはコンテンツやデータのグループを参照することができます。 [グリッド ビュー](../controls-and-patterns/item-templates-gridview.md)は写真またはメディアを中心とするコンテンツに適していて、[リスト ビュー](../controls-and-patterns/item-templates-listview.md)はテキストが多いコンテンツやデータに適しています。

## <a name="masterdetail"></a>マスター/詳細

![マスター/詳細](images/master-detail.svg)

[マスター/詳細](../controls-and-patterns/master-details.md)モデルは、リスト ビュー (マスター) とコンテンツ ビュー (詳細) で構成されます。 両方のウィンドウは固定されていて、垂直方向にスクロールできます。 リスト ビュー内のアイテムを選択すると、コンテンツ ビューがそれに応じて更新されます。 

## <a name="forms"></a>フォーム
![フォーム](images/form.svg)

[フォーム](../controls-and-patterns/forms.md)は、ユーザーからデータを収集して送信するコントロールのグループです。 すべてではなくても、ほとんどのアプリが、設定ページ、ログイン ポータル、フィードバック Hub、アカウントの作成などのために、何らかのフォームを使用しています。 

## <a name="sample-apps"></a>サンプル アプリ
これらのパターンを実装する方法については、チェック アウト、 [UWP サンプル アプリ](https://developer.microsoft.com/en-us/windows/samples):
- [BuildCast ビデオ プレーヤー](https://github.com/Microsoft/BuildCast)
- [ランチ スケジューラ](https://github.com/Microsoft/Windows-appsample-lunch-scheduler)
- [塗り絵帳](https://github.com/Microsoft/Windows-appsample-coloringbook)
- [顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database)