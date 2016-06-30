---
author: mcleanbyron
ms.assetid: 5E722AFF-539D-456E-8C4A-ADE90CF7674A
description: "アプリ内製品のカタログが大きくなる場合、カタログを管理するためにこのトピックで説明するプロセスを採用できます。"
title: "アプリ内製品の大規模なカタログの管理"
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 0927df3cd696e5a6fbd3a235d2b87074f1d63929

---

# アプリ内製品の大規模なカタログの管理


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

アプリ内製品のカタログが大きくなる場合、カタログを管理するためにこのトピックで説明するプロセスを採用できます。 特定の価格帯に対して少数の製品エントリを作成し、個々のエントリで、カタログ内の多数の製品を表します。

この機能を有効にするには、[**RequestProductPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/dn263382) メソッドのオーバーロードを使って、ストアに掲載されたアプリ内製品に関連する、アプリで定義された販売を指定します。 呼び出し中に販売と製品の関連付けを指定することに加えて、アプリでは、大規模なカタログ販売の詳細を格納する [**ProductPurchaseDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/dn263384) オブジェクトも渡す必要があります。 これらの詳細が指定されていない場合、一覧に掲載された製品の詳細が代わりに使われます。

ストアでは、結果の [**PurchaseResults**](https://msdn.microsoft.com/library/windows/apps/dn263392) で、購入要求からの *offerId* のみを使います。 このプロセスは、[ストアにアプリ内製品を掲載した](https://msdn.microsoft.com/library/windows/apps/mt148551)ときに最初に提供された情報を直接変更するわけではありません。

**注**  Windows 10 以降では、開発者アカウントごとに表示されるストアの製品数に制限はありません。 以前のリリースでは、開発者アカウントごとに 200 製品の表示制限があり、このトピックで説明するプロセスを使ってこの制限を回避できます。

## 前提条件

-   このトピックでは、ストアの一覧に表示される 1 つのアプリ内購入製品を使って複数のアプリ内販売を表現することに対する、ストアのサポートについて説明します。 アプリ内購入に詳しくない場合は、「[アプリ内製品購入の有効化](enable-in-app-product-purchases.md)」を読んで、ライセンス情報と、ストアでアプリ内購入を適切に一覧表示する方法を確かめてください。
-   新しいアプリ内販売のコード記述やテストを初めて行うときは、[**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) オブジェクトではなく、[**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) オブジェクトを使う必要があります。 そうすることで、実稼働サーバーを呼び出すのではなく、ライセンス サーバーへのシミュレートされた呼び出しを使って、ライセンス ロジックを検証できます。 そのためには、%userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData で "WindowsStoreProxy.xml" という名前のファイルをカスタマイズする必要があります。 このファイルは、アプリを初めて実行するときに Microsoft Visual Studio シミュレーターによって作られます。カスタマイズされたファイルを実行時に読み込むこともできます。 詳しくは、「**CurrentAppSimulator**」をご覧ください。
-   このトピックでは、[ストア サンプル](http://go.microsoft.com/fwlink/p/?LinkID=627610)で提供されているコード例も参照します。 このサンプルを利用すると、ユニバーサル Windows プラットフォーム (UWP) アプリに提供されるさまざまな収益化オプションを体験できます。

## アプリ内製品に対する購入要求

大規模なカタログ内の特定の製品に対する購入要求は、他のアプリ内購入要求とほとんど同様に処理されます。 アプリが新しい [**RequestProductPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/dn263382) メソッドのオーバーロードを呼び出すときに、アプリは *OfferId* と、アプリ内製品の名前が設定された [**ProductPurchaseDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/dn263390) オブジェクトの両方を提供します。

```CSharp
string offerId = "1234";
string displayPropertiesName = "MusicOffer1";
var displayProperties = new ProductPurchaseDisplayProperties(displayPropertiesName);

try
{
    PurchaseResults purchaseResults = await CurrentAppSimulator.RequestProductPurchaseAsync("product1", offerId, displayProperties);
    switch (purchaseResults.Status)
    {
        case ProductPurchaseStatus.Succeeded:
            // Grant the user their purchase here, and then pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
            // To indicate local fulfillment to the Windows Store.
            break;
        case ProductPurchaseStatus.NotFulfilled:
            // First check for unfulfilled purchases and grant any unfulfilled purchases from an earlier transaction.
            // Once products are fulfilled pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
            // To indicate local fulfillment to the Windows Store.
            break;
        case ProductPurchaseStatus.NotPurchased:
            // Notify user that the purchase was not completed due to cancellation or error.
            break;
    }
}
catch (Exception)
{
    //Notify the user of the purchase error.
}
```

## アプリ内販売のフルフィルメントの報告

アプリでは、販売のローカルのフルフィルメントが完了したらすぐに、ストアに製品フルフィルメントを報告する必要があります。 大規模なカタログのシナリオでは、アプリで販売のフルフィルメントを報告しなかった場合、ユーザーは、その同じストアの製品一覧を使ってアプリ内販売を購入できなくなります。

前に説明したように、ストアでは提供された販売情報のみを使って [**PurchaseResults**](https://msdn.microsoft.com/library/windows/apps/dn263392) を設定し、大規模なカタログ販売とストアの製品一覧の間に永続的な関連付けは作成しません。 その結果、製品に対するユーザーの権限を追跡し、製品固有のコンテキスト (購入される項目の名前やその詳細など) を [**RequestProductPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/dn263382) 操作の外部でユーザーに提供します。

次のコードは、フルフィルメントの呼び出しと、特定の販売情報が挿入される UI メッセージング パターンを示しています。 この特定の製品情報がない場合、この例では製品の [**ListingInformation**](https://msdn.microsoft.com/library/windows/apps/br225163) からの情報を使います。

```CSharp
string offerId = "1234";
product1ListingName = product1.Name;
string displayPropertiesName = "MusicOffer1";

if (String.IsNullOrEmpty(displayPropertiesName))
{
    displayPropertiesName = product1ListingName;
}
var offerIdMsg = " with offer id " + offerId;
if (String.IsNullOrEmpty(offerId))
{
    offerIdMsg = " with no offer id";
}

FulfillmentResult result = await CurrentAppSimulator.ReportConsumableFulfillmentAsync(productId, transactionId);
switch (result)
{
    case FulfillmentResult.Succeeded:
        Log("You bought and fulfilled " + displayPropertiesName + offerIdMsg, NotifyType.StatusMessage);
        break;
    case FulfillmentResult.NothingToFulfill:
        Log("There is no purchased product 1 to fulfill.", NotifyType.StatusMessage);
        break;
    case FulfillmentResult.PurchasePending:
        Log("You bought product 1. The purchase is pending so we cannot fulfill the product.", NotifyType.StatusMessage);
        break;
    case FulfillmentResult.PurchaseReverted:
        Log("You bought product 1. But your purchase has been reverted.", NotifyType.StatusMessage);
        // Since the user' s purchase was revoked, they got their money back.
        // You may want to revoke the user' s access to the consumable content that was granted.
        break;
    case FulfillmentResult.ServerError:
        Log("You bought product 1. There was an error when fulfilling.", NotifyType.StatusMessage);
        break;
}
```

## 関連トピック

* [アプリ内製品購入の有効化](enable-in-app-product-purchases.md)
* [コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)
* [ストア サンプル (試用版とアプリ内購入のデモンストレーション)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
* [**RequestProductPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/dn263382)
* [**ProductPurchaseDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/dn263384)



<!--HONumber=Jun16_HO4-->


