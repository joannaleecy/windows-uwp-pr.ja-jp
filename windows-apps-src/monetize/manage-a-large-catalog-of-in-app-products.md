---
xx.xxxxxxx: YXYYYXXX-YYYX-YYYX-YXYX-XXXYYXXYYYYX
xxxxxxxxxxx: Xx xxxx xxx xxxxxx x xxxxx xx-xxx xxxxxxx xxxxxxx, xxx xxx xxxxxxxxxx xxxxxx xxx xxxxxxx xxxxxxxxx xx xxxx xxxxx xx xxxx xxxxxx xxxx xxxxxxx.
xxxxx: Xxxxxx x xxxxx xxxxxxx xx xx-xxx xxxxxxxx
---

# Xxxxxx x xxxxx xxxxxxx xx xx-xxx xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xx xxxx xxx xxxxxx x xxxxx xx-xxx xxxxxxx xxxxxxx, xxx xxx xxxxxxxxxx xxxxxx xxx xxxxxxx xxxxxxxxx xx xxxx xxxxx xx xxxx xxxxxx xxxx xxxxxxx. Xxx xxxx xxxxxx x xxxxxxx xx xxxxxxx xxxxxxx xxx xxxxxxxx xxxxx xxxxx, xxxx xxxx xxx xxxx xx xxxxxxxxx xxxxxxxx xx xxxxxxxx xxxxxx x xxxxxxx.

Xx xxxxxx xxxx xxxxxxxxxx, xxx xxx [**XxxxxxxXxxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263382) xxxxxx xxxxxxxx xxxx xxxxxxxxx xx xxx-xxxxxxx xxxxx xxxxxxxxxx xxxx xx xx-xxx xxxxxxx xxxxxx xx xxx Xxxxx. Xx xxxxxxxx xx xxxxxxxxxx xx xxxxx xxx xxxxxxx xxxxxxxxxxx xxxxxx xxx xxxx, xxxx xxx xxxxxx xxxx xxxx x [**XxxxxxxXxxxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263384) xxxxxx xxxx xxxxxxxx xxx xxxxx xxxxxxx xxxxx xxxxxxx. Xx xxxxx xxxxxxx xxx xxx xxxxxxxx, xxx xxxxxxx xxx xxx xxxxxx xxxxxxx xxxx xx xxxx xxxxxxx.

Xxx Xxxxx xxxx xxxx xxx xxx *xxxxxXx* xxxx xxx xxxxxxxx xxxxxxx xx xxx xxxxxxxxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263392). Xxxx xxxxxxx xxxx xxx xxxxxxxx xxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxxxxxx xxxx [xxxxxxx xxx xx-xxx xxxxxxx xx xxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt148551).

**Xxxx**  Xxxxxxxx xxxx Xxxxxxx YY, xxx Xxxxx xxx xx xxxxx xx xxx xxxxxx xx xxxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxxx. Xx xxxxxxxx xxxxxxxx, xxx Xxxxx xxx x xxxxx xx YYY xxxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxxx, xxx xxx xxxxxxx xxxxxxxxx xx xxxx xxxxx xxx xx xxxx xx xxxx xxxxxx xxxx xxxxxxxxxx.

## Xxxxxxxxxxxxx

-   Xxxx xxxxx xxxxxx Xxxxx xxxxxxx xxx xxx xxxxxxxxxxxxxx xx xxxxxxxx xx-xxx xxxxxx xxxxx x xxxxxx xx-xxx xxxxxxx xxxxxx xx xxx Xxxxx. Xx xxx xxx xxxxxxxxxx xxxx xx-xxx xxxxxxxxx xxxxxx xxxxxx [Xxxxxx xx-xxx xxxxxxx xxxxxxxxx](enable-in-app-product-purchases.md) xx xxxxx xxxxx xxxxxxx xxxxxxxxxxx, xxx xxx xx xxxxxxxx xxxx xxxx xx-xxx xxxxxxxx xx xxx Xxxxx.
-   Xxxx xxx xxxx xxx xxxx xxx xx-xxx xxxxxx xxx xxx xxxxx xxxx, xxx xxxx xxx xxx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xxxxxx xxxxxxx xx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xxxxxx. Xxxx xxx xxx xxx xxxxxx xxxx xxxxxxx xxxxx xxxxx xxxxxxxxx xxxxx xx xxx xxxxxxx xxxxxx xxxxxxx xx xxxxxxx xxx xxxx xxxxxx. Xx xx xxxx, xxx xxxx xx xxxxxxxxx xxx xxxx xxxxx "XxxxxxxXxxxxXxxxx.xxx" xx %xxxxxxxxxxx%\\XxxXxxx\\xxxxx\\xxxxxxxx\\&xx;xxxxxxx xxxx&xx;\\XxxxxXxxxx\\Xxxxxxxxx\\Xxxxxxx Xxxxx\\XxxXxxx. Xxx Xxxxxxxxx Xxxxxx Xxxxxx xxxxxxxxx xxxxxxx xxxx xxxx xxxx xxx xxx xxxx xxx xxx xxx xxxxx xxxx—xx xxx xxx xxxx xxxx x xxxxxx xxx xx xxxxxxx. Xxx xxxx xxxx, xxx **XxxxxxxXxxXxxxxxxxx**.
-   Xxxx xxxxx xxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxxx xx xxx [Xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=627610). Xxxx xxxxxx xx x xxxxx xxx xx xxx xxxxx-xx xxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxxxxxxx xxxxxxx xxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx.

## Xxxx xxx xxxxxxxx xxxxxxx xxx xxx xx-xxx xxxxxxx

Xxx xxxxxxxx xxxxxxx xxx x xxxxxxxx xxxxxxx xxxxxx x xxxxx xxxxxxx xx xxxxxxx xx xxxx xxx xxxx xxx xx xxx xxxxx xxxxxxxx xxxxxxx xxxxxx xx xxx. Xxxx xxxx xxx xxxxx xxx xxx [**XxxxxxxXxxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263382) xxxxxx xxxxxxxx, xxxx xxx xxxxxxxx xxxx xx *XxxxxXx* xxx x [**XxxxxxxXxxxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263390) xxxxxx xxxxxxxxx xxxx xxx xxxx xx xxx xx-xxx xxxxxxx.

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

## Xxxxxx xxxxxxxxxxx xx xxx xx-xxx xxxxx

Xxxx xxx xxxx xxxx xx xxxxxx xxxxxxx xxxxxxxxxxx xx xxx Xxxxx xx xxxx xx xxx xxxxx xxx xxxx xxxxxxxxx xxxxxxx. Xx x xxxxx xxxxxxx xxxxxxxx, xx xxxx xxx xxxx xxx xxxxxx xxxxx xxxxxxxxxxx, xxx xxxx xxxx xx xxxxxx xx xxxxxxxx xxx xx-xxx xxxxxx xxxxx xxxx xxxx Xxxxx xxxxxxx xxxxxxx.

Xx xxxxxxxxx xxxxxxx, xxx Xxxxx xxxx xxxx xxxxxxxx xxxxx xxxx xx xxxxxxxx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263392), xxx xxxx xxx xxxxxx x xxxxxxxxxx xxxxxxxxxxx xxxxxxx x xxxxx xxxxxxx xxxxx xxx Xxxxx xxxxxxx xxxxxxx. Xx x xxxxxx xxx xxxx xx xxxxx xxxx xxxxxxxxxxx xxx xxxxxxxx, xxx xxxxxxx xxxxxxx-xxxxxxxx xxxxxxx (xxxx xx xxx xxxx xx xxx xxxx xxxxx xxxxxxxxx xx xxxxxxx xxxxx xx) xx xxx xxxx xxxxxxx xx xxx [**XxxxxxxXxxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263382) xxxxxxxxx.

Xxx xxxxxxxxx xxxx xxxxxxxxxxxx xxx xxxxxxxxxxx xxxx, xxx x XX xxxxxxxxx xxxxxxx xx xxxxx xxx xxxxxxxx xxxxx xxxx xx xxxxxxxx. Xx xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxx xxxx, xxx xxxxxxx xxxx xxxx xxxx xxx xxxxxxx [**XxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225163).

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

## Xxxxxxx xxxxxx

* [Xxxxxx xx-xxx xxxxxxx xxxxxxxxx](enable-in-app-product-purchases.md)
* [Xxxxxx xxxxxxxxxx xx-xxx xxxxxxx xxxxxxxxx](enable-consumable-in-app-product-purchases.md)
* [Xxxxx xxxxxx (xxxxxxxxxxxx xxxxxx xxx xx-xxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
* [**XxxxxxxXxxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263382)
* [**XxxxxxxXxxxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263384)
<!--HONumber=Mar16_HO1-->
