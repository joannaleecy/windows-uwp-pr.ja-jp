---
author: mcleanbyron
ms.assetid: FD381669-F962-465E-940B-AED9C8D19C90
description: "Windows.Services.Store 名前空間を使ってコンシューマブルなアドオンを操作する方法について説明します。"
title: "コンシューマブルなアドオン購入の有効化"
keywords: "アプリ内販売コード サンプル"
translationtype: Human Translation
ms.sourcegitcommit: 962bee0cae8c50407fe1509b8000dc9cf9e847f8
ms.openlocfilehash: eb188ed8e69f90727c5b57af1c407fac07eaf87d

---

# コンシューマブルなアドオン購入の有効化

Windows 10 バージョン 1607 以降をターゲットとするアプリは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間で [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスのメソッドを使って、ユーザーによる UWP アプリでのコンシューマブルなアドオンフルフィルメント (アドオンはアプリ内製品または IAP とも呼ばれます) を管理できます。 コンシューマブルなアドオンは、購入、使用、再購入可能なアイテムに使います。 これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。

>**注**&nbsp;&nbsp;この記事は、Windows 10 バージョン 1607 以降をターゲットとするアプリに適用されます。 アプリが Windows 10 の以前のバージョンをターゲットする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

## コンシューマブルなアドオンの概要

Windows 10 バージョン 1607 以降をターゲットとするアプリは、フルフィルメントを管理する方法が異なる 2 種類のコンシューマブルなアドオンを提供することができます。

* **開発者により管理されるコンシューマブル**。 この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量を追跡し、ユーザーによってすべてのアイテムが消費されたらアドオンの購入をフルフィルメント完了としてストアに報告する義務が開発者にあります。 以前のアドオン購入をフルフィルメント完了としてアプリで報告するまで、ユーザーがそのアドオンを再購入することはできません。

  たとえば、アドオンがゲーム内の 100 コインを表しており、ユーザーによって 10 コインが消費されている場合、アプリまたはサービスでは、ユーザーの 90 コインの残高を保持する必要があります。 ユーザーによって 100 コインすべてが消費されたら、アプリでそのアドオンをフルフィルメント完了として報告する必要があります。その後、ユーザーは 100 コイン アドオンを再購入できます。

* **ストアで管理されるコンシューマブル**。 この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量はストアで追跡します。 ユーザーによりアイテムが消費されたら、そのアイテムをフルフィルメント完了としてストアに報告する義務が開発者にあり、ストアによってユーザーの残量が更新されます。 アプリでは、ユーザーのアイテムの現在の残量をいつでも照会できます。 ユーザーは、すべてのアイテムを消費したら、そのアドオンを再購入できます。

  たとえば、アドオンがゲーム内の 100 のコインの初期量を表しており、ユーザーによって 10 コインが消費された場合、そのアドオンの 10 ユニットがフルフィルメント完了したことをアプリでストアに報告すると、ストアにより残高が更新されます。 ユーザーは、100 コインすべてを消費した後、その 100 コインのアドオンを再購入できます。

  >**注**&nbsp;&nbsp;ストアで管理されるコンシューマブルは Windows 10 バージョン 1607 以降で利用できます。 Windows デベロッパー センター ダッシュボードでストアで管理されるコンシューマブルを作成する機能は、近日公開される予定です。

コンシューマブルなアドオンをユーザーに提供するには、この一般的なプロセスに従います。

1. ユーザーがアプリから[アドオンを購入](enable-in-app-purchases-of-apps-and-add-ons.md)するようにしてください。
3. ユーザーがアドオンを消費するとき (たとえば、ゲームでコインを消費する場合)、[アドオンをフルフィルメント完了として報告](enable-consumable-add-on-purchases.md#report_fulfilled)します。

さらに、ストアで管理されるコンシューマブルの場合、いつでも[残高を取得する](enable-consumable-add-on-purchases.md#get_balance)ことができます。

## 必要条件

これらの例には、次の必要条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュ ボードでコンシューマブルなアドオン (アプリ内製品または IAP とも呼ばれます) を含むアプリを作成し、そのアプリが公開されてストアで入手可能になっている。 これは、ユーザーにリリースするアプリでも、[Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最小要件を満たす、テスト目的でのみ使う基本的なアプリでもかまいません。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。

これらの例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

>**注:**&nbsp;&nbsp;[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使うデスクトップ アプリケーションがある場合、これらの例には表示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[Desktop Bridge を使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

<span id="report_fulfilled" />
## コンシューマブルなアドオンをフルフィルメント完了として報告する

ユーザーがアプリから[アドオンを購入](enable-in-app-purchases-of-apps-and-add-ons.md)してアドオンを消費したら、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [ReportConsumableFulfillmentAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.reportconsumablefulfillmentasync.aspx) メソッドを呼び出すことでアドオンをフルフィルメント完了として報告する必要があります。 次の情報をこのメソッドに渡す必要があります。

* フルフィルメント完了として報告するアドオンの[ストア ID](in-app-purchases-and-trials.md#store_ids)
* フルフィルメント完了として報告するアドオンの単位。
  * 開発者により管理されるコンシューマブルの場合、*quantity* パラメーターには 1 を指定します。 これにより、コンシューマブルのフルフィルメントが完了したことがストアに通知され、ユーザーがそのコンシューマブルをもう一度購入できるようになります。 ユーザーは、アプリがストアにフルフィルメント完了を通知するまで、コンシューマブルをもう一度購入することができません。
  * ストアで管理されるコンシューマブルの場合、消費された単位の実際の数を指定します。 ストアにより、コンシューマブルの残高が更新されます。
* フルフィルメントの追跡 ID。 これは、開発者が指定する GUID で、追跡目的でフルフィルメント操作が関連付けられている特定のトランザクションを識別します。 詳しくは、「[ReportConsumableFulfillmentAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.reportconsumablefulfillmentasync.aspx)」の解説をご覧ください。

この例では、ストアで管理されるコンシューマブルをフルフィルメント完了として報告する方法を示します。

```csharp
private StoreContext context = null;

public async void ConsumeAddOn(string storeId)
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    // This is an example for a Store-managed consumable, where you specify the actual number
    // of units that you want to report as consumed so the Store can update the remaining
    // balance. For a developer-managed consumable where you maintain the balance, specify 1
    // to just report the add-on as fulfilled to the Store.
    uint quantity = 10;
    string addOnStoreId = "9NBLGGH4TNNR";
    Guid trackingId = Guid.NewGuid();

    workingProgressRing.IsActive = true;
    StoreConsumableResult result = await context.ReportConsumableFulfillmentAsync(
        addOnStoreId, quantity, trackingId);
    workingProgressRing.IsActive = false;

    if (result.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {result.ExtendedError.Message}";
        return;
    }

    switch (result.Status)
    {
        case StoreConsumableStatus.Succeeded:
            textBlock.Text = "The fulfillment was successful. Remaining balance: " +
                result.BalanceRemaining;
            break;

        case StoreConsumableStatus.InsufficentQuantity:
            textBlock.Text = "The fulfillment was unsuccessful because the user " +
            "doesn't have enough remaining balance." + result.BalanceRemaining;
            break;

        case StoreConsumableStatus.NetworkError:
            textBlock.Text = "The fulfillment was unsuccessful due to a network error.";
            break;

        case StoreConsumableStatus.ServerError:
            textBlock.Text = "The fulfillment was unsuccessful due to a server error.";
            break;

        default:
            textBlock.Text = "The fulfillment was unsuccessful due to an unknown error.";
            break;
    }
}
```

<span id="get_balance" />
## ストアで管理されるコンシューマブルの残高の取得

この例では、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [GetConsumableBalanceRemainingAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getconsumablebalanceremainingasync.aspx) メソッドを使って、ストアで管理されるコンシューマブルなアドオンを取得する方法を示します。

```csharp
private StoreContext context = null;

public async void GetRemainingBalance(string storeId)
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    string addOnStoreId = "9NBLGGH4TNNR";

    workingProgressRing.IsActive = true;
    StoreConsumableResult result = await context.GetConsumableBalanceRemainingAsync(addOnStoreId);
    workingProgressRing.IsActive = false;

    if (result.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {result.ExtendedError.Message}";
        return;
    }

    switch (result.Status)
    {
        case StoreConsumableStatus.Succeeded:
            textBlock.Text = "Remaining balance: " + result.BalanceRemaining;
            break;

        case StoreConsumableStatus.NetworkError:
            textBlock.Text = "Could not retrieve balance due to a network error.";
            break;

        case StoreConsumableStatus.ServerError:
            textBlock.Text = "Could not retrieve balance due to a server error.";
            break;

        default:
            textBlock.Text = "Could not retrieve balance due to an unknown error.";
            break;
    }
}
```

## 関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)



<!--HONumber=Nov16_HO1-->


