---
author: mcleanbyron
ms.assetid: 9630AF6D-6887-4BE3-A3CB-D058F275B58F
description: "Windows.Services.Store 名前空間を使って、現在のアプリとそのアドオン ライセンス情報を取得する方法について説明します。"
title: "アプリとアドオンのライセンス情報の取得"
translationtype: Human Translation
ms.sourcegitcommit: 18d5c2ecf7d438355c3103ad2aae32dc84fc89ed
ms.openlocfilehash: 710800bcd5491407d90e8293006a687e27d06d2d

---

# アプリとアドオンのライセンス情報の取得

Windows 10 バージョン 1607 以降をターゲットとするアプリは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスのメソッドを使って、現在のアプリとそのアドオン (アプリ内製品または IAP とも呼ばれます) のライセンス情報を取得できます。 たとえば、この情報を使って、アプリまたはそのアドオンのライセンスがアクティブになっているかどうかや、試用ライセンスであるかどうかなどを確認できます。

>**注**&nbsp;&nbsp;この記事は、Windows 10 バージョン 1607 以降をターゲットとするアプリに適用されます。 アプリが Windows 10 の以前のバージョンをターゲットする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

## 必要条件

この例には、次の必要条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュ ボードでアプリを作成し、このアプリが公開されてストアで入手可能になっている。 これは、ユーザーにリリースするアプリでも、[Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最小要件を満たす、テスト目的でのみ使う基本的なアプリでもかまいません。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。

この例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

>**注:**&nbsp;&nbsp;[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使うデスクトップ アプリケーションがある場合、この例には示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[Desktop Bridge を使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## コードの例

現在のアプリのライセンス情報を取得するには、[GetAppLicenseAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getapplicenseasync.aspx) メソッドを使います。 これは、アプリのライセンス情報を提供する [StoreAppLicense](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.aspx) オブジェクトを返す非同期メソッドです。この情報には、アプリを使用するためのライセンスをユーザーが所有しているかどうかを示すプロパティ ([IsActive](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.isactive.aspx)) や、ライセンスが試用版向けであるかどうかを示すプロパティ ([IsTrial](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.istrial.aspx)) などが含まれます。

アプリのアドオンのライセンスを取得するには、[StoreAppLicense](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.aspx) オブジェクトの [AddOnLicenses](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.addonlicenses.aspx) プロパティを使用します。 このプロパティは、アプリのアドオンのライセンスを表す [StoreLicense](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storelicense.aspx) オブジェクトのコレクションを返します。 アドオンを使用するためのライセンスをユーザーが所有しているかどうかを判断するには、[IsActive](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storelicense.isactive.aspx) プロパティを使用します。

```csharp
private StoreContext context = null;

public async void GetLicenseInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    workingProgressRing.IsActive = true;
    StoreAppLicense appLicense = await context.GetAppLicenseAsync();
    workingProgressRing.IsActive = false;

    if (appLicense == null)
    {
        textBlock.Text = "An error occurred while retrieving the license.";
        return;
    }

    // Use members of the appLicense object to access license info...

    // Access the add on licenses for add-ons for this app.
    foreach (KeyValuePair<string, StoreLicense> item in appLicense.AddOnLicenses)
    {
        StoreLicense addOnLicense = item.Value;
        // Use members of the addOnLicense object to access license info
        // for the add-on...
    }
}
```

完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

## 関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)



<!--HONumber=Nov16_HO1-->


