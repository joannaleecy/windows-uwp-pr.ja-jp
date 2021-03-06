---
ms.assetid: E2B73380-D673-48C6-9026-96976D745017
description: コモン コントロールの概要
title: コモン コントロールの概要
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: ebba5abe0de8014a21d2e651534dacc118705fff
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610627"
---
# <a name="getting-started-common-controls"></a>概要: コモン コントロール


## <a name="common-controls-list"></a>コモン コントロールの一覧

前のセクションで扱ったコントロールは、ボタンとテキストブロックの 2 つのみでした。 もちろん、使用可能な多くの複数のコントロールです。 ここでは、アプリやそれに対応する iOS アプリで使用するいくつかのコモン コントロールを紹介します。 ここでは、iOS コントロールをアルファベット順に並べ、その横に最も似ているユニバーサル Windows プラットフォーム (UWP) コントロールを示しています。

UWP コントロールが優れている点は、実行されているデバイスの種類を検出して、それに応じて外観と機能を変更できることです。 たとえば、プロジェクトが [**DatePicker**](https://msdn.microsoft.com/library/windows/apps/br211681) コントロールを使用している場合、たとえば、電話と比較して、デスクトップ コンピューターで異なる外観と動作に自動的に最適化します。 何もする必要はありません。コントロールが実行時に自動的に調整します。

| iOS のコントロール (クラス/プロトコル) | 同等の UWP コントロール |
|------------------------------|--------------------------------------|
| アクティビティ インジケーター (**UIActivityIndicatorView**) | [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) <br/> 「[クイック スタート: プログレス コントロールの追加](https://msdn.microsoft.com/library/windows/apps/xaml/hh780651)」もご覧ください。 |
| 広告バナー ビュー (**ADBannerView**) と広告バナー ビュー デリゲート (**ADBannerViewDelegate**) | [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) <br/> 「[アプリでの広告の表示](../monetize/display-ads-in-your-app.md)」もご覧ください。 |
| ボタン (UIButton) | [ボタン](https://msdn.microsoft.com/library/windows/apps/br209265) <br/> 参照してください[クイック スタート。ボタン コントロールを追加します。](https://msdn.microsoft.com/library/windows/apps/xaml/jj153346) |
| 日付の選択 (UIDatePicker) | [DatePicker](https://msdn.microsoft.com/library/windows/apps/br211681) |
| 画像ビュー (UIImageView) | [画像](https://msdn.microsoft.com/library/windows/apps/br242752) <br/> 「[Image と ImageBrush](https://msdn.microsoft.com/library/windows/apps/mt280382)」もご覧ください。 |
| ラベル (UILabel) | [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) <br/> 「[クイック スタート: テキストの表示](https://msdn.microsoft.com/library/windows/apps/xaml/hh700392)」もご覧ください。 |
| 地図ビュー (MKMapView) と地図ビュー デリゲート (MKMapViewDelegate) | 参照してください[UWP アプリ用 Bing のマップ](https://go.microsoft.com/fwlink/p/?LinkId=263496) |
| ナビゲーション コント ローラー (UINavigationController) とナビゲーション コント ローラー デリゲート (UINavigationControllerDelegate) | [フレーム](https://msdn.microsoft.com/library/windows/apps/br242682) <br/> 「[ナビゲーション](https://msdn.microsoft.com/library/windows/apps/mt187344)」もご覧ください。 |
| ページ コントロール (UIPageControl) | [ページ](https://msdn.microsoft.com/library/windows/apps/br227503) <br/> 「[ナビゲーション](https://msdn.microsoft.com/library/windows/apps/mt187344)」もご覧ください。 |
| ピッカー ビュー (UIPickerView) とピッカー ビュー デリゲート (UIPickerViewDelegate) | [ComboBox](https://msdn.microsoft.com/library/windows/apps/br209348) <br/> 「[コンボ ボックスとリスト ボックスの追加](https://msdn.microsoft.com/library/windows/apps/xaml/hh780616)」もご覧ください。 |
| 進行状況バー (UIProgressView) | [ProgressBar](https://msdn.microsoft.com/library/windows/apps/br227529) <br/> 「[クイック スタート: プログレス コントロールの追加](https://msdn.microsoft.com/library/windows/apps/xaml/hh780651)」もご覧ください。 |
| スクロール ビュー (UIScrollView) とスクロール ビュー デリゲート (UIScrollViewDelegate) | [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/br209527) <br/>  「[Extensible Application Markup Language (XAML) のスクロール、パン、ズームのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=238577)」もご覧ください。 |
| 検索バー (UISearchBar) と検索バー デリゲート (UISearchBarDelegate) | 「[アプリへの検索の追加](https://msdn.microsoft.com/library/windows/apps/xaml/jj130767)」をご覧ください。 <br/>  参照してください[クイック スタート。アプリに検索の追加](https://msdn.microsoft.com/library/windows/apps/xaml/hh868180) |
| セグメント化されたコントロール (UISegmentedControl) | なし |
| スライダー (UISlider) | [スライダー](https://msdn.microsoft.com/library/windows/apps/br209614) <br/>  「[スライダーを追加する方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh868197)」もご覧ください。 |
| 分割ビュー コントローラー (UISplitViewController) と分割ビュー コントローラー デリゲート (UISplitViewControllerDelegate) | なし |
| スイッチ (UISwitch) | [ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/br209712) <br/>  「[トグル スイッチを追加する方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh868198)」もご覧ください。 |
| タブ バー コントローラー (UITabBarController) とタブ バー コントローラー デリゲート (UITabBarControllerDelegate) | なし |
| テーブル ビュー コントローラー (UITableViewController)、テーブル ビュー (UITableView)、テーブル ビュー デリゲート (UITableViewDelegate)、および表のセル (UITableViewCell) | [ListView](https://msdn.microsoft.com/library/windows/apps/br242878) <br/>  「[クイック スタート: ListView コントロールと GridView コントロールの追加](https://msdn.microsoft.com/library/windows/apps/xaml/hh780650)」もご覧ください。 |
| テキスト フィールド (UITextField) とテキスト フィールド デリゲート (UITextFieldDelegate) | [TextBox](https://msdn.microsoft.com/library/windows/apps/br209683) <br/>  「[テキストの表示と編集](https://msdn.microsoft.com/library/windows/apps/mt280218)」もご覧ください。 |
| テキスト ビュー (UITextView) とテキスト ビュー デリゲート (UITextViewDelegate) | [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) <br/>  「[クイック スタート: テキストの表示](https://msdn.microsoft.com/library/windows/apps/xaml/hh700392)」もご覧ください。 |
| ビュー (UIView) とビュー コントローラー (UIViewController) | [ページ](https://msdn.microsoft.com/library/windows/apps/br227503) <br/>  「[ナビゲーション](https://msdn.microsoft.com/library/windows/apps/mt187344)」もご覧ください。 |
| Web ビュー (UIWebView) と Web ビュー デリゲート (UIWebViewDelegate) | [WebView](https://msdn.microsoft.com/library/windows/apps/br227702) <br/>  「[XAML WebView コントロールのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=238582)」もご覧ください。 |
| ウィンドウ (UIWindow) | [フレーム](https://msdn.microsoft.com/library/windows/apps/br242682) <br/>  「[ナビゲーション](https://msdn.microsoft.com/library/windows/apps/mt187344)」もご覧ください。 |

その他のコントロールについては、「[コントロールの一覧](https://msdn.microsoft.com/library/windows/apps/mt185406)」をご覧ください。

**注**  JavaScript と HTML を使った UWP アプリのコントロールの一覧は、次を参照してください。[コントロール リスト](https://msdn.microsoft.com/library/windows/apps/hh465453)します。

### <a name="next-step"></a>次の手順

[はじめに:ナビゲーション](getting-started-navigation.md)

## <a name="related-topics"></a>関連トピック

* [build 2014:XAML UI とコントロールについて説明します。](https://go.microsoft.com/fwlink/p/?LinkID=397897)
* [build 2014:共通の XAML UI フレームワークを使用するアプリの開発](https://go.microsoft.com/fwlink/p/?LinkID=397898)
* [build 2014:収束済みアプリの Visual Studio を使用して XAML を作成するには](https://go.microsoft.com/fwlink/p/?LinkID=397876)
