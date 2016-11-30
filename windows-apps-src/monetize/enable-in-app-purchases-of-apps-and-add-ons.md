---
author: mcleanbyron
ms.assetid: B356C442-998F-4B2C-B550-70070C5E4487
description: "Windows.Services.Store 名前空間を使用して、アプリまたはそのいずれかのアドオンを購入する方法について説明します。"
title: "アプリとアドオンのアプリ内購入の有効化"
keywords: "アプリ内販売コード サンプル"
translationtype: Human Translation
ms.sourcegitcommit: 962bee0cae8c50407fe1509b8000dc9cf9e847f8
ms.openlocfilehash: a28982e05e88b542a0b20bf481e3121d6ac8a247

---

# アプリとアドオンのアプリ内購入の有効化

Windows 10 バージョン 1607 以降を対象とするアプリは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間のメンバーを使用して、ユーザーの現在のアプリまたはそのいずれかのアドオン (アプリ内製品または IAP とも呼ばれます) の購入を要求できます。 たとえば、現在ユーザーがアプリの試用版を使用している場合、このプロセスを使用して、ユーザーの完全なライセンスを購入できます。 また、このプロセスを使用して、ユーザーの新しいゲーム レベルなどのアドオンを購入できます。

アプリまたはアドオンの購入を要求するため、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) には次のようなさまざまな方法が備わっています。
* アプリまたはアドオンの[ストア ID](in-app-purchases-and-trials.md#store_ids) がわかっている場合、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [RequestPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.requestpurchaseasync.aspx) メソッドを使用できます。
* アプリまたはアドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx)、[StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx)、[StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) のいずれかのオブジェクトが既にある場合、それらのオブジェクトの **RequestPurchaseAsync** メソッドを使用できます。

各メソッドは、標準の購入 UI をユーザーに示し、トランザクションが完了すると非同期的に完了します。 メソッドは、トランザクションが成功したかどうかを示すオブジェクトを返します。

>**注**&nbsp;&nbsp;この記事は、Windows 10 バージョン 1607 以降をターゲットとするアプリに適用されます。 アプリが Windows 10 の以前のバージョンをターゲットする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

## 必要条件

この例には、次の必要条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュ ボードでアプリを作成し、このアプリが公開されてストアで入手可能になっている。 これは、ユーザーにリリースするアプリでも、[Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最小要件を満たす、テスト目的でのみ使う基本的なアプリでもかまいません。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。

この例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

>**注:**&nbsp;&nbsp;[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使うデスクトップ アプリケーションがある場合、この例には表示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[Desktop Bridge を使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## コードの例

この例は、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスの [RequestPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.requestpurchaseasync.aspx) メソッドを使用して、[ストア ID](in-app-purchases-and-trials.md#store_ids) がわかっているアプリまたはアドオンを購入する方法を示しています。

```csharp
private StoreContext context = null;

public async void PurchaseAddOn(string storeId)
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    workingProgressRing.IsActive = true;
    StorePurchaseResult result = await context.RequestPurchaseAsync(storeId);
    workingProgressRing.IsActive = false;

    if (result.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {result.ExtendedError.Message}";
        return;
    }

    switch (result.Status)
    {
        case StorePurchaseStatus.AlreadyPurchased:
            textBlock.Text = "The user has already purchased the product.";
            break;

        case StorePurchaseStatus.Succeeded:
            textBlock.Text = "The purchase was successful.";
            break;

        case StorePurchaseStatus.NotPurchased:
            textBlock.Text = "The purchase did not complete. " +
                "The user may have cancelled the purchase.";
            break;

        case StorePurchaseStatus.NetworkError:
            textBlock.Text = "The purchase was unsuccessful due to a network error.";
            break;

        case StorePurchaseStatus.ServerError:
            textBlock.Text = "The purchase was unsuccessful due to a server error.";
            break;

        default:
            textBlock.Text = "The purchase was unsuccessful due to an unknown error.";
            break;
    }
}
```

完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

## 関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)



<!--HONumber=Nov16_HO1-->


