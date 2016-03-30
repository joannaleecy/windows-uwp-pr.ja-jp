---
Xxxxxxxxxxx: Xxxxx xxxxxxxxxx xx-xxx xxxxxxxx&\#YYYY;xxxxx xxxx xxx xx xxxxxxxxx, xxxx, xxx xxxxxxxxx xxxxx&\#YYYY;xxxxxxx xxx Xxxxx xxxxxxxx xxxxxxxx xx xxxxxxx xxxx xxxxxxxxx xxxx x xxxxxxxx xxxxxxxxxx xxxx xx xxxx xxxxxx xxx xxxxxxxx.
xxxxx: Xxxxxx xxxxxxxxxx xx-xxx xxxxxxx xxxxxxxxx
xx.xxxxxxx: XYYXXYYY-XXXX-YYYY-XXYX-YYXYXYXYXXXY
xxxxxxxx: xx-xxx xxxxx
xxxxxxxx: xxxxxxxxxx
xxxxxxxx: xx-xxx xxxxxxxx
xxxxxxxx: xx-xxx xxxxxxx
xxxxxxxx: xxx xx xxxxxxx xx-xxx
xxxxxxxx: xx-xxx xxxxxxxx xxxx xxxxxx
xxxxxxxx: xx-xxx xxxxx xxxx xxxxxx
---

# Xxxxxx xxxxxxxxxx xx-xxx xxxxxxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxxxxxxxxx xx-xxx xxxxxxxx—xxxxx xxxx xxx xx xxxxxxxxx, xxxx, xxx xxxxxxxxx xxxxx—xxxxxxx xxx Xxxxx xxxxxxxx xxxxxxxx xx xxxxxxx xxxx xxxxxxxxx xxxx x xxxxxxxx xxxxxxxxxx xxxx xx xxxx xxxxxx xxx xxxxxxxx. Xxxx xx xxxxxxxxxx xxxxxx xxx xxxxxx xxxx xx-xxxx xxxxxxxx (xxxx, xxxxx, xxx.) xxxx xxx xx xxxxxxxxx xxx xxxx xxxx xx xxxxxxxx xxxxxxxx xxxxx-xxx.

## Xxxxxxxxxxxxx

-   Xxxx xxxxx xxxxxx xxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxxx xx xxxxxxxxxx xx-xxx xxxxxxxx. Xx xxx xxx xxxxxxxxxx xxxx xx-xxx xxxxxxxx, xxxxxx xxxxxx [Xxxxxx xx-xxx xxxxxxx xxxxxxxxx](enable-in-app-product-purchases.md) xx xxxxx xxxxx xxxxxxx xxxxxxxxxxx, xxx xxx xx xxxxxxxx xxxx xx-xxx xxxxxxxx xx xxx Xxxxx.
-   Xxxx xxx xxxx xxx xxxx xxx xx-xxx xxxxxxxx xxx xxx xxxxx xxxx, xxx xxxx xxx xxx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xxxxxx xxxxxxx xx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xxxxxx. Xxxx xxx xxx xxx xxxxxx xxxx xxxxxxx xxxxx xxxxx xxxxxxxxx xxxxx xx xxx xxxxxxx xxxxxx xxxxxxx xx xxxxxxx xxx xxxx xxxxxx. Xx xx xxxx, xxx xxxx xx xxxxxxxxx xxx xxxx xxxxx "XxxxxxxXxxxxXxxxx.xxx" xx %xxxxxxxxxxx%\\XxxXxxx\\xxxxx\\xxxxxxxx\\&xx;xxxxxxx xxxx&xx;\\XxxxxXxxxx\\Xxxxxxxxx\\Xxxxxxx Xxxxx\\XxxXxxx. Xxx Xxxxxxxxx Xxxxxx Xxxxxx xxxxxxxxx xxxxxxx xxxx xxxx xxxx xxx xxx xxxx xxx xxx xxx xxxxx xxxx—xx xxx xxx xxxx xxxx x xxxxxx xxx xx xxxxxxx. Xxx xxxx xxxx, xxx **XxxxxxxXxxXxxxxxxxx**.
-   Xxxx xxxxx xxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxxx xx xxx [Xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=627610). Xxxx xxxxxx xx x xxxxx xxx xx xxx xxxxx-xx xxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxxxxxxx xxxxxxx xxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx.

## Xxxx Y: Xxxxxx xxx xxxxxxxx xxxxxxx

Xxx xxxxxxx xxxxxxxx xxxxxxx xx xxxx xxxx [**XxxxxxxXxxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263381) xxxx xxx xxxxx xxxxxxxx xxxx xxxxxxx xxx Xxxxx. Xxx xxxxxxxxxx xxx xxxxxxxxxx xx-xxx xxxxxxxx xx xxxx xxxxx x xxxxxxxxxx xxxxxxxx, x xxxxxxxx xxxxxx xxxxxxxx xxx xxxx xxxxxxx xxxxx xxxxx xxx xxx xxx xxxxxxxx xxx Xxxxx xxxx xxx xxxxxxxx xxxxxxxx xxx xxxxxxxxxxxx xxxxxxxxx. Xx'x xxxx xxx'x xxxxxxxxxxxxxx xx xxxxxxx xxxxxxxxx xxxxxxxxxxx xxx xxxxxx xxx Xxxxx xx xxx xxxxxxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxx x xxxxxxxxxx xx-xxx xxxxxxx xxxxxxxx xxxxxxx. Xxx'xx xxxxxx xxxx xxxxxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxx xxxxxxx xxx xxxxx xxxxxxxxxxx xx xxx xxxxxxxxxx xx-xxx xxxxxxx xxx xxx xxxxxxxxx xxxxxxxxx—xxxx xxx xxxxxxx xx xxxxxxxxxx, xxx xxxx xxx xxxxxxx xx xxx xxxxxxxxxx xxxxxxx xx xx xxxxxxxxxxx xxxxxxxx xx xxxx xxxx xxxxxxx.

```CSharp
PurchaseResults purchaseResults = await CurrentAppSimulator.RequestProductPurchaseAsync("product1");
switch (purchaseResults.Status)
{
    case ProductPurchaseStatus.Succeeded:
        product1TempTransactionId = purchaseResults.TransactionId;

        // Grant the user their purchase here, and then pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
        // To indicate local fulfillment to the Windows Store.
        break;

    case ProductPurchaseStatus.NotFulfilled:
        product1TempTransactionId = purchaseResults.TransactionId;

        // First check for unfulfilled purchases and grant any unfulfilled purchases from an earlier transaction.
        // Once products are fulfilled pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
        // To indicate local fulfillment to the Windows Store.
        break;
}
```

## Xxxx Y: Xxxxxxxx xxxxx xxxxxxxxxxx xx xxx xxxxxxxxxx

Xxxx xxxxxxxx xxxx xxxxxxxx xxxxxx xx xxx xxxxxxxxxx xx-xxx xxxxxxx, xx'x xxxxxxxxx xx xxxx xxxxx xx xxxxx xxxxxxx xx xxxxxxxxx (*xxxxxxxXx*), xxx xxxxx xxxxxxxxxxx xxxx xxxxxxxxxxx xx xxxxxxxxxx xxxx (*xxxxxxxxxxxXx*).

**Xxxxxxxxx**  Xxxx xxx xx xxxxxxxxxxx xxx xxx xxxxxxxxxx xxxxxxxxx xxxxxxxxxxx xx xxx Xxxxx. Xxxx xxxx xx xxxxxxxxx xx xxxxxxxxxxx x xxxx xxx xxxxxxxx xxxxxxxx xxxxxxxxxx xxx xxxx xxxxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxxxxxxx xxx xx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263392) xxxxxxxxxx xxxx xxx [**XxxxxxxXxxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263381) xxxx xx xxx xxxxxxxx xxxx xx xxxxxxxx xxx xxxxxxxxx xxxxxxx xxx xxxxxxxxxxx. Xx xxxxx xx xxxx xx xxxxx xxx xxxxxxx xxxxxxxxxxx xx x xxxxxxxx xxxx xxx xxxxx xx xxxxxxxxxx xx xxxxxxx xxxx xxxxx xxxxxxxxxxx xxx xxxxxxxxxx.

```CSharp
private void GrantFeatureLocally(string productId, Guid transactionId)
{
    if (!grantedConsumableTransactionIds.ContainsKey(productId))
    {
        grantedConsumableTransactionIds.Add(productId, new List<Guid>());
    }
    grantedConsumableTransactionIds[productId].Add(transactionId);

    // Grant the user their content. You will likely increase some kind of gold/coins/some other asset count.
}
```

Xxxx xxxx xxxxxxx xxxxx xxx xx xxx xxx xxxxx xxxx xxx xxxxxxxx xxxxxxx xx xxxxxx xxxxxxx XX/xxxxxxxxxxx XX xxxxx xxxx xxx xxxxx xxxx xxxx xxxxxxxxx xxxxxxxxxxx xx xxx Xxxxx.

**Xxxxxxxxx**  Xxxxxxxx xxxxxxxxxxx xxxx xxx xxxx xx xxxxx xxx xxxxxxx xxxxxxxxxxx, xxxx xxx xxxx xxxxxxxxxxx xxx xxxxxxxxx xx xxxxxx xxxx xxxx xxxxxxxxx xxx xxx xxxxxxx xxx xxxxx xxxx xxxxx'x xxxxxxxx.

```CSharp
private Boolean IsLocallyFulfilled(string productId, Guid transactionId)
{
    return grantedConsumableTransactionIds.ContainsKey(productId) &amp;&amp; grantedConsumableTransactionIds[productId].Contains(transactionId);
}
```

## Xxxx Y: Xxxxxxxxx xxxxxxx xxxxxxxxxxx xx xxx Xxxxx

Xxxxx xxxxx xxxxxxxxxxx xx xxxxxxxxx, xxxx xxx xxxx xxxx x [**XxxxxxXxxxxxxxxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263380) xxxx xxxx xxxxxxxx xxx *xxxxxxxXx* xxx xxx xxxxxxxxxxx xxx xxxxxxx xxxxxxxx xx xxxxxxxx xx.

**Xxxxxxxxx**  Xxxxxxx xx xxxxxx xxxxxxxxx xxxxxxxxxx xx-xxx xxxxxxxx xx xxx Xxxxx xxxx xxxxxx xx xxx xxxx xxxxx xxxxxx xx xxxxxxxx xxxx xxxxxxx xxxxx xxxxx xxxxxxxxxxx xxx xxx xxxxxxxx xxxxxxxx xx xxxxxxxx.

```CSharp
FulfillmentResult result = await CurrentAppSimulator.ReportConsumableFulfillmentAsync("product2", product2TempTransactionId);
```

## Xxxx Y: Xxxxxxxxxxx xxxxxxxxxxx xxxxxxxxx

Xxxx xxx xxx xxx xxx [**XxxXxxxxxxxxxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263379) xxxxxx xx xxxxx xxx xxxxxxxxxxx xxxxxxxxxx xx-xxx xxxxxxxx xx xxx xxxx. Xxxx xxxxxx xxxxxx xx xxxxxx xx x xxxxxxx xxxxx xx xxxxx xxx xxxxxxxxxxx xxxxxxxxxxx xxxx xxxxx xxx xx xxxxxxxxxxxxx xxx xxxxxx xxxx xx xxxxxxxxxxxx xx xxxxxxx xxxxxxxxxxxx xx xxx xxxxxxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxxxxxxx xxx [**XxxXxxxxxxxxxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263379) xxx xx xxxx xx xxxxxxxxx xxxxxxxxxxx xxxxxxxxxxx, xxx xxx xxxx xxx xxx xxxxxxx xxxxxxx xxxx xxxx xx xxxxxxxx xxxxx xxxxxxxxxxx.

```CSharp
private async void GetUnfulfilledConsumables()
{
    products = await CurrentApp.GetUnfulfilledConsumablesAsync();

    foreach (UnfulfilledConsumable product in products)
    {
        logMessage += "\nProduct Id: " + product.ProductId + " Transaction Id: " + product.TransactionId;
        // This is where you would pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
    // To indicate local fulfillment to the Windows Store.
    }
}
```

## Xxxxxxx xxxxxx

* [Xxxxxx xx-xxx xxxxxxx xxxxxxxxx](enable-in-app-product-purchases.md)
* [Xxxxx xxxxxx (xxxxxxxxxxxx xxxxxx xxx xx-xxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
* [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225197)
 

 




<!--HONumber=Mar16_HO1-->
