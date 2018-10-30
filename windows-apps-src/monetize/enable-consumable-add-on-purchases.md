---
author: Xansky
ms.assetid: FD381669-F962-465E-940B-AED9C8D19C90
description: Windows.Services.Store 名前空間を使ってコンシューマブルなアドオンを操作する方法について説明します。
title: コンシューマブルなアドオン購入の有効化
keywords: Windows 10, UWP, コンシューマブル, アドオン, アプリ内購入, IAP, Windows.Services.Store
ms.author: mhopkins
ms.date: 05/09/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: fc67e2b48779e7b22f20dc4adfbe28580bc325fc
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5754699"
---
# <a name="enable-consumable-add-on-purchases"></a>コンシューマブルなアドオン購入の有効化

この記事では、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスのメソッドを使って、ユーザーによる UWP アプリでのコンシューマブルなアドオンフルフィルメントを管理する方法を示します。 コンシューマブルなアドオンは、購入、使用、再購入可能なアイテムに使います。 これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。

> [!NOTE]
> **Windows.Services.Store** 名前空間は、Windows 10 バージョン 1607 で導入され、Visual Studio で、**Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。 アプリが Windows 10 の以前のバージョンをターゲットとする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、[この記事](enable-consumable-in-app-product-purchases.md)をご覧ください。

## <a name="overview-of-consumable-add-ons"></a>コンシューマブルなアドオンの概要

アプリは、フルフィルメントを管理する方法が異なる 2 種類のコンシューマブルなアドオンを提供することができます。

* **開発者により管理されるコンシューマブル**。 この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量を追跡し、ユーザーによってすべてのアイテムが消費されたらアドオンの購入をフルフィルメント完了としてストアに報告する義務が開発者にあります。 以前のアドオン購入をフルフィルメント完了としてアプリで報告するまで、ユーザーがそのアドオンを再購入することはできません。

  たとえば、アドオンがゲーム内の 100 コインを表しており、ユーザーによって 10 コインが消費されている場合、アプリまたはサービスでは、ユーザーの 90 コインの残高を保持する必要があります。 ユーザーによって 100 コインすべてが消費されたら、アプリでそのアドオンをフルフィルメント完了として報告する必要があります。その後、ユーザーは 100 コイン アドオンを再購入できます。

* **ストアで管理されるコンシューマブル**。 この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量はストアで追跡します。 ユーザーによりアイテムが消費されたら、そのアイテムをフルフィルメント完了としてストアに報告する義務が開発者にあり、ストアによってユーザーの残量が更新されます。 ユーザーは、必要な回数だけアドオンを購入できます (最初にアイテムを使用する必要はありません)。 アプリでは、ユーザーのアイテムの現在の残量をいつでも Microsoft Store に照会できます。

  たとえば、アドオンがゲーム内の 100 のコインの初期量を表しており、ユーザーによって 50 コインが消費された場合、そのアドオンの 50 ユニットがフルフィルメント完了したことをアプリで Microsoft Store に報告すると、Microsoft Store により残高が更新されます。 ユーザーがアドオンを再購入して 100 個以上のコインを獲得した場合、合計で 150 個のコインを手にします。
    > [!NOTE]
    > Microsoft Store で管理されるコンシューマブルは Windows 10 バージョン 1607 で導入されました。

コンシューマブルなアドオンをユーザーに提供するには、この一般的なプロセスに従います。

1. ユーザーがアプリから[アドオンを購入](enable-in-app-purchases-of-apps-and-add-ons.md)するようにしてください。
3. ユーザーがアドオンを消費するとき (たとえば、ゲームでコインを消費する場合)、[アドオンをフルフィルメント完了として報告](enable-consumable-add-on-purchases.md#report_fulfilled)します。

さらに、ストアで管理されるコンシューマブルの場合、いつでも[残高を取得する](enable-consumable-add-on-purchases.md#get_balance)ことができます。

## <a name="prerequisites"></a>前提条件

これらの例には、次の前提条件があります。
* **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュボードで[アプリの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)し、このアプリが Microsoft Store で公開されている。 必要に応じで、テスト中にストアでアプリを検索できないようにアプリを構成することも可能です。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。
* デベロッパー センター ダッシュボードで[アプリのコンシューマブルなアドオンを作成](../publish/add-on-submissions.md)した。

これらの例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

> [!NOTE]
> [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションがある場合、これらの例には示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[デスクトップ ブリッジを使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

<span id="report_fulfilled" />

## <a name="report-a-consumable-add-on-as-fulfilled"></a>コンシューマブルなアドオンをフルフィルメント完了として報告する

ユーザーがアプリから[アドオンを購入](enable-in-app-purchases-of-apps-and-add-ons.md)してアドオンを消費したら、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [ReportConsumableFulfillmentAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.reportconsumablefulfillmentasync) メソッドを呼び出すことでアドオンをフルフィルメント完了として報告する必要があります。 次の情報をこのメソッドに渡す必要があります。

* フルフィルメント完了として報告するアドオンの[ストア ID](in-app-purchases-and-trials.md#store-ids)
* フルフィルメント完了として報告するアドオンの単位。
  * 開発者により管理されるコンシューマブルの場合、*quantity* パラメーターには 1 を指定します。 これにより、コンシューマブルのフルフィルメントが完了したことがストアに通知され、ユーザーがそのコンシューマブルをもう一度購入できるようになります。 ユーザーは、アプリがストアにフルフィルメント完了を通知するまで、コンシューマブルをもう一度購入することができません。
  * ストアで管理されるコンシューマブルの場合、消費された単位の実際の数を指定します。 ストアにより、コンシューマブルの残高が更新されます。
* フルフィルメントの追跡 ID。 これは、開発者が指定する GUID で、追跡目的でフルフィルメント操作が関連付けられている特定のトランザクションを識別します。 詳しくは、「[ReportConsumableFulfillmentAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.reportconsumablefulfillmentasync)」の解説をご覧ください。

この例では、ストアで管理されるコンシューマブルをフルフィルメント完了として報告する方法を示します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableConsumables](./code/InAppPurchasesAndLicenses_RS1/cs/ConsumeAddOnPage.xaml.cs#ConsumeAddOn)]

<span id="get_balance" />

## <a name="get-the-remaining-balance-for-a-store-managed-consumable"></a>ストアで管理されるコンシューマブルの残高の取得

この例では、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [GetConsumableBalanceRemainingAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getconsumablebalanceremainingasync) メソッドを使って、ストアで管理されるコンシューマブルなアドオンを取得する方法を示します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableConsumables](./code/InAppPurchasesAndLicenses_RS1/cs/GetRemainingAddOnBalancePage.xaml.cs#GetRemainingAddOnBalance)]

## <a name="related-topics"></a>関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)
