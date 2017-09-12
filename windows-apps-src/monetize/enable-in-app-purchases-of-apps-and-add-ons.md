---
author: mcleanbyron
ms.assetid: B356C442-998F-4B2C-B550-70070C5E4487
description: "Windows.Services.Store 名前空間を使用して、アプリまたはそのいずれかのアドオンを購入する方法について説明します。"
title: "アプリとアドオンのアプリ内購入の有効化"
keywords: "Windows 10, UWP, アドオン, アプリ内購入, IAP, Windows.Services.Store"
ms.author: mcleans
ms.date: 06/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: a8da1394bfbee1cedcfdc4606c42b2ed4a41eb96
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="enable-in-app-purchases-of-apps-and-add-ons"></a>アプリとアドオンのアプリ内購入の有効化

Windows 10 バージョン 1607 以降を対象とするアプリは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間のメンバーを使用して、ユーザーの現在のアプリまたはそのいずれかのアドオンの購入を要求できます。 たとえば、現在ユーザーがアプリの試用版を使用している場合、このプロセスを使用して、ユーザーの完全なライセンスを購入できます。 また、このプロセスを使用して、ユーザーの新しいゲーム レベルなどのアドオンを購入できます。

アプリまたはアドオンの購入を要求するため、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) には次のようなさまざまな方法が備わっています。
* アプリまたはアドオンの[ストア ID](in-app-purchases-and-trials.md#store_ids) がわかっている場合、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [RequestPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.requestpurchaseasync.aspx) メソッドを使用できます。
* アプリまたはアドオンを表す [**StoreProduct**、**StoreSku**、**StoreAvailability**](in-app-purchases-and-trials.md#products-skus) のいずれかのオブジェクトが既にある場合、それらのオブジェクトの **RequestPurchaseAsync** メソッドを使用できます。 コードで **StoreProduct** を取得するさまざまな方法の例については、「[アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)」をご覧ください。

各メソッドは、標準の購入 UI をユーザーに示し、トランザクションが完了すると非同期的に完了します。 メソッドは、トランザクションが成功したかどうかを示すオブジェクトを返します。

> [!NOTE]
> この記事は、Windows 10 バージョン 1607 以降をターゲットとするアプリに適用されます。 アプリが Windows 10 の以前のバージョンをターゲットとする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、[この記事](enable-in-app-product-purchases.md)をご覧ください。

## <a name="prerequisites"></a>前提条件

この例には、次の前提条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュボードで[アプリの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)し、このアプリがストアで公開されている。 必要に応じで、テスト中にストアでアプリを検索できないようにアプリを構成することも可能です。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。
* アプリのアドオンのアプリ内購入を有効化する場合、[デベロッパー センター ダッシュボードでアドオンを作成](../publish/add-on-submissions.md)する必要もあります。

この例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

> [!NOTE]
> [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションがある場合、この例には示されていないコードを追加して [StoreContext ](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[デスクトップ ブリッジを使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## <a name="code-example"></a>コードの例

この例は、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [RequestPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.requestpurchaseasync.aspx) メソッドを使用して、[ストア ID](in-app-purchases-and-trials.md#store_ids) がわかっているアプリまたはアドオンを購入する方法を示しています。 完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnablePurchases](./code/InAppPurchasesAndLicenses_RS1/cs/PurchaseAddOnPage.xaml.cs#PurchaseAddOn)]

## <a name="video"></a>ビデオ

このビデオで、アプリでアプリ内購入を実装する方法の概要をご覧ください。
<br/>
<br/>
> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Adding-In-App-Purchases-to-Your-UWP-App/player]

## <a name="related-topics"></a>関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)
