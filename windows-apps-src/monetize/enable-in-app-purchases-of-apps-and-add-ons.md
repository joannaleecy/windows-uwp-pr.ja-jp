---
author: Xansky
ms.assetid: B356C442-998F-4B2C-B550-70070C5E4487
description: Windows.Services.Store 名前空間を使用して、アプリまたはそのいずれかのアドオンを購入する方法について説明します。
title: アプリとアドオンのアプリ内購入の有効化
keywords: Windows 10, UWP, アドオン, アプリ内購入, IAP, Windows.Services.Store
ms.author: mhopkins
ms.date: 08/25/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: beb7165586c62770fd6b18fff8c7ad0095bc78ba
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7426583"
---
# <a name="enable-in-app-purchases-of-apps-and-add-ons"></a>アプリとアドオンのアプリ内購入の有効化

この記事では、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間のメンバーを使用して、ユーザーの現在のアプリまたはそのいずれかのアドオンの購入を要求する方法を示します。 たとえば、現在ユーザーがアプリの試用版を使用している場合、このプロセスを使用して、ユーザーの完全なライセンスを購入できます。 また、このプロセスを使用して、ユーザーの新しいゲーム レベルなどのアドオンを購入できます。

アプリまたはアドオンの購入を要求するため、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間には次のようなさまざまなメソッドが備わっています。
* アプリまたはアドオンの[ストア ID](in-app-purchases-and-trials.md#store_ids) がわかっている場合、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [RequestPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestpurchaseasync) メソッドを使用できます。
* アプリまたはアドオンを表す [**StoreProduct**、**StoreSku**、**StoreAvailability**](in-app-purchases-and-trials.md#products-skus) のいずれかのオブジェクトが既にある場合、それらのオブジェクトの **RequestPurchaseAsync** メソッドを使用できます。 コードで **StoreProduct** を取得するさまざまな方法の例については、「[アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)」をご覧ください。

各メソッドは、標準の購入 UI をユーザーに示し、トランザクションが完了すると非同期的に完了します。 メソッドは、トランザクションが成功したかどうかを示すオブジェクトを返します。

> [!NOTE]
> **Windows.Services.Store** 名前空間は、Windows 10 バージョン 1607 で導入され、Visual Studio で、**Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。 アプリが Windows 10 の以前のバージョンをターゲットとする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、[この記事](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)をご覧ください。

## <a name="prerequisites"></a>前提条件

この例には、次の前提条件があります。
* **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* パートナー センター内にある[アプリの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)し、このアプリは、ストアで公開します。 必要に応じで、テスト中にストアでアプリを検索できないようにアプリを構成することも可能です。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。
* アプリのアドオンのアプリ内購入を有効にする場合は、する必要もあります[パートナー センターでのアドオンを作成](../publish/add-on-submissions.md)します。

この例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

> [!NOTE]
> [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションがある場合、この例には示されていないコードを追加して [StoreContext ](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx)オブジェクトを構成することが必要になることがあります。 詳しくは、「[デスクトップ ブリッジを使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## <a name="code-example"></a>コードの例

この例は、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [RequestPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestpurchaseasync) メソッドを使用して、[ストア ID](in-app-purchases-and-trials.md#store-ids) がわかっているアプリまたはアドオンを購入する方法を示しています。 完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

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
